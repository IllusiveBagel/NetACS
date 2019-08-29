using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace NetACS.Server.Middleware
{
    class SoapManagement
    {
        private readonly RequestDelegate _next;

        public SoapManagement(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine(await Desearialize(context.Request));

            var originalBodyStream = context.Response.Body;

            await _next(context);
        }

        private async Task<object> Desearialize(HttpRequest request)
        {
            IFormatter formatter;
            MemoryStream stream = null;
            Object soap = null;

            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            try
            {
                byte[] bytes = new byte[bodyAsText.Length];
                Encoding.ASCII.GetBytes(bodyAsText, 0, bodyAsText.Length, bytes, 0);
                stream = new MemoryStream(bytes);
                formatter = new SoapFormatter();
                soap = formatter.Deserialize(stream);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null) stream.Close();
            }

            return soap;
        }
    }
}
