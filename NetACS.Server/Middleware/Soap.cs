using Microsoft.AspNetCore.Http;
using NetACS.Server.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace NetACS.Server.Middleware
{
    class SoapMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _endpointPath;
        private readonly MessageEncoder _messageEncoder;
        private readonly ServiceDescription _service;

        public SoapMiddleware(RequestDelegate next, Type serviceType, string path, MessageEncoder encoder)
        {
            _next = next;
            _endpointPath = path;
            _messageEncoder = encoder;
            _service = new ServiceDescription(serviceType);
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.Request.Path.Equals(_endpointPath, StringComparison.Ordinal))
            {
                Message responseMessage;

                var requestMessage = _messageEncoder.ReadMessage(context.Request.Body, 0x10000, context.Request.ContentType);

                var soapAction = context.Request.Headers["SOAPAction"].ToString().Trim('\"');

                if (!string.IsNullOrEmpty(soapAction))
                {
                    requestMessage.Headers.Action = soapAction;
                }

                var operation = _service.Operations.Where(o => o.SoapAction.Equals(requestMessage.Headers.Action, StringComparison.Ordinal)).FirstOrDefault();

                if (operation == null)
                {
                    throw new InvalidOperationException($"No Operation Found for Specified Action: {requestMessage.Headers.Action}");
                }

                var serviceInstance = serviceProvider.GetService(_service.ServiceType);
                var arguments = GetRequestArguments(requestMessage, operation);
                var responseObject = operation.DispatchMethod.Invoke(serviceInstance, arguments.ToArray());

                var resultName = operation.DispatchMethod.ReturnParameter.GetCustomAttribute<MessageParameterAttribute>()?.Name ?? operation.Name + "Result";
                var bodyWriter = new ServiceBodyWriter(operation.Contract.Namespace, operation.Name + "Response", resultName, responseObject);
                responseMessage = Message.CreateMessage(_messageEncoder.MessageVersion, operation.ReplyAction, bodyWriter);

                context.Response.ContentType = context.Request.ContentType;
                context.Response.Headers["SOAPAction"] = responseMessage.Headers.Action;

                _messageEncoder.WriteMessage(responseMessage, context.Response.Body);
            }
            else
            {
                await _next(context);
            }
        }

        private object[] GetRequestArguments(Message requestMessage, OperationDescription operation)
        {
            var parameters = operation.DispatchMethod.GetParameters();
            var arguments = new List<object>();

            using (var xmlReader = requestMessage.GetReaderAtBodyContents())
            {
                xmlReader.ReadStartElement(operation.Name, operation.Contract.Namespace);

                for (int i = 0; i < parameters.Length; i++)
                {
                    var parameterName = parameters[i].GetCustomAttribute<MessageParameterAttribute>()?.Name ?? parameters[i].Name;
                    xmlReader.MoveToStartElement(parameterName, operation.Contract.Namespace);
                    if (xmlReader.IsStartElement(parameterName, operation.Contract.Namespace))
                    {
                        var serializer = new DataContractSerializer(parameters[i].ParameterType, parameterName, operation.Contract.Namespace);
                        arguments.Add(serializer.ReadObject(xmlReader, verifyObjectName: true));
                    }
                }
            }

            return arguments.ToArray();
        }
    }

    #region Descriptions
    public class ServiceDescription
    {
        public Type ServiceType { get; private set; }
        public IEnumerable<ContractDescription> Contracts { get; private set; }
        public IEnumerable<OperationDescription> Operations => Contracts.SelectMany(c => c.Operations);

        public ServiceDescription(Type serviceType)
        {
            ServiceType = serviceType;

            var contracts = new List<ContractDescription>();

            foreach (var contractType in ServiceType.GetInterfaces())
            {
                foreach (var serviceContract in contractType.GetTypeInfo().GetCustomAttributes<ServiceContractAttribute>())
                {
                    contracts.Add(new ContractDescription(this, contractType, serviceContract));
                }
            }

            Contracts = contracts;
        }
    }

    public class ContractDescription
    {
        public ServiceDescription Service { get; private set; }
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public Type ContractType { get; private set; }
        public IEnumerable<OperationDescription> Operations { get; private set; }

        public ContractDescription(ServiceDescription service, Type contractType, ServiceContractAttribute attribute)
        {
            Service = service;
            ContractType = contractType;
            Namespace = attribute.Namespace ?? "cwmp";
            Name = attribute.Name ?? ContractType.Name; // Name defaults to the type name

            var operations = new List<OperationDescription>();
            foreach (var operationMethodInfo in ContractType.GetTypeInfo().DeclaredMethods)
            {
                foreach (var operationContract in operationMethodInfo.GetCustomAttributes<OperationContractAttribute>())
                {
                    operations.Add(new OperationDescription(this, operationMethodInfo, operationContract));
                }
            }
            Operations = operations;
        }
    }

    public class OperationDescription
    {
        public ContractDescription Contract { get; private set; }
        public string SoapAction { get; private set; }
        public string ReplyAction { get; private set; }
        public string Name { get; private set; }
        public MethodInfo DispatchMethod { get; private set; }
        public bool IsOneWay { get; private set; }

        public OperationDescription(ContractDescription contract, MethodInfo operationMethod, OperationContractAttribute contractAttribute)
        {
            Contract = contract;
            Name = contractAttribute.Name ?? operationMethod.Name;
            SoapAction = contractAttribute.Action ?? $"{contract.Namespace.TrimEnd('/')}/{contract.Name}/{Name}";
            IsOneWay = contractAttribute.IsOneWay;
            ReplyAction = contractAttribute.ReplyAction;
            DispatchMethod = operationMethod;
        }
    }
    #endregion

    public class ServiceBodyWriter: BodyWriter
    {
        string ServiceNamespace;
        string EnvelopeName;
        string ResultName;
        object Result;

        public ServiceBodyWriter(string serviceNamespace, string envelopeName, string resultName, object result): base(isBuffered: true)
        {
            ServiceNamespace = serviceNamespace;
            EnvelopeName = envelopeName;
            ResultName = resultName;
            Result = result;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement(EnvelopeName, ServiceNamespace);
            var serializer = new DataContractSerializer(Result.GetType(), ResultName, ServiceNamespace);
            serializer.WriteObject(writer, Result);
            writer.WriteEndElement();
        }
    }
}

namespace Microsoft.AspNetCore.Builder
{
    public static class SoapExtensions
    {
        public static IApplicationBuilder UseSoap<T>(this IApplicationBuilder builder, string path, Binding binding)
        {
            var encoder = binding.CreateBindingElements().Find<MessageEncodingBindingElement>()?.CreateMessageEncoderFactory().Encoder;
            return builder.UseMiddleware<SoapMiddleware>(typeof(T), path, encoder);
        }
    }
}
