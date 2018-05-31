using CacheManager.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace OcelotLearning
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("configuration.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(Configuration)
                .AddCacheManager((x) =>
                {
                    x.WithMicrosoftLogging(log =>
                    {
                        log.AddConsole(LogLevel.Debug);

                    }).WithDictionaryHandle();
                });

            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            await app.UseOcelot();

            //app.UseMvc();
        }
    }
}
