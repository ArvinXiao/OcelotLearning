using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace OcelotLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });

            var webHost = builder.UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseApplicationInsights()
                .Build();

            return webHost;
        }
    }
}
