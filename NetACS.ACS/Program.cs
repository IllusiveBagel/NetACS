using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NetACS.ACS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                    .UseKestrel(x => x.AllowSynchronousIO = true)
                    .UseUrls("http://*:5000")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .ConfigureLogging(x =>
                    {
                        x.AddDebug();
                        x.AddConsole();
                    })
                    .Build();

            host.Run();
        }
    }
}
