using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using siteHost;


namespace RunHost
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Server!");

            var webhost = new WebHostBuilder()
                .UseKestrel()
                .UseSockets()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5432")
                .Build();

            webhost.Run();

            Console.ReadLine();

           //Application will stop right here.
        }

        public class Startup
        {
            public void Configure(IApplicationBuilder app)
            {
                app.UseSite(new SiteOptions());
            }
        }
    }

}
