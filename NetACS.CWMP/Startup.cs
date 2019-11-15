using System.ServiceModel;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using NetACS.CWMP.Services;
using NetACS.CWMP.Interfaces;
using NetACS.Database.Services;
using NetACS.Database.Interfaces;

using SoapCore;
using Microsoft.Extensions.Configuration;

namespace NetACS.CWMP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IInformService, InformService>();
            services.AddTransient<IDatabase, SQLServer>();
            
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
