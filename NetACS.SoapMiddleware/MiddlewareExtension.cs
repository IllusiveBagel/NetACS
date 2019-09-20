using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;
using NetACS.SoapMiddleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class SOAPEndpointExtensions
    {
        public static IApplicationBuilder UseSOAPEndpoint<T>(this IApplicationBuilder builder, string path, Binding binding)
        {
            var encoder = binding.CreateBindingElements().Find<MessageEncodingBindingElement>()?.CreateMessageEncoderFactory().Encoder;
            return builder.UseMiddleware<SOAPEndpointMiddleware>(typeof(T), path, encoder);
        }
    }
}
