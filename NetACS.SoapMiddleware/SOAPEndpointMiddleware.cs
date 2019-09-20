using Microsoft.AspNetCore.Http;
using System;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace NetACS.SoapMiddleware
{
    public class SOAPEndpointMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _endpointPath;
        private readonly MessageEncoder _messageEncoder;
        private readonly ServiceDescription _service;

        public SOAPEndpointMiddleware(RequestDelegate next, Type serviceType, string path, MessageEncoder encoder)
        {
            _next = next;
            _endpointPath = path;
            _messageEncoder = encoder;
            _service = new ServiceDescription(serviceType);
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.Equals(_endpointPath, StringComparison.Ordinal))
            {
                Message responseMessage;

                // Read Request Message
                var requestMessage = _messageEncoder.ReadMessage(context.Request.Body, 0x10000, context.Request.ContentType);

                var soapAction = context.Request.Headers["SOAPAction"].ToString().Trim('\"');
                if (!string.IsNullOrEmpty(soapAction))
                {
                    requestMessage.Headers.Action = soapAction;
                }

                //TODO
            }
            else
            {
                await _next(context);
            }
        }
    }
}
