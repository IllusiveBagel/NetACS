using System.ServiceModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSoapEndpoint<ICWMPService>("/Service.asmx", new BasicHttpBinding(), SoapSerializer.DataContractSerializer);
        }
    }
}
