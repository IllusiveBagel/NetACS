using System.ServiceModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetACS.CWMP.Interfaces;
using NetACS.CWMP.Services;
using SoapCore;

namespace NetACS.CWMP
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSoapCore();
            services.TryAddSingleton<ICWMPService, CWMPService>();
            services.AddSoapExceptionTransformer((ex) => ex.Message);
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSoapEndpoint<ICWMPService>("/Service.asmx", new BasicHttpBinding());
            app.UseMvc();
        }
    }
}
