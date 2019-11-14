using System.ServiceModel;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using NetACS.ACS.Services;
using NetACS.ACS.Interfaces;

using SoapCore;

namespace NetACS.ACS
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IInformService, InformService>();
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddSoapCore();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSoapEndpoint<IInformService>("/Service.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);

            app.UseMvc();
        }
    }
}
