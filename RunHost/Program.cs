using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using SiteHost;


namespace RunHost
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Server!");

            var webhost = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5433")
                .Build();

            webhost.Run();

            Console.ReadLine();


        }

        public class Startup
        {
            public void Configure(IApplicationBuilder app)
            {

                var xmlName = "Doesnt.Matter.xml";
                var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), xmlName);

                app.UseMagicOnionSwagger(new SwaggerOptions("SiteHost.Site", "Site Test", "/")
                {
                    XmlDocumentPath = xmlPath
                });
            }
        }
    }

}
