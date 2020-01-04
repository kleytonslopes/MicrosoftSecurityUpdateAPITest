using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Services;
using MicrosoftSecurityUpdateAPITest.Services.Behaviours;
using MicrosoftSecurityUpdateAPITest.Services.Hosted;
using System;

namespace MicrosoftSecurityUpdateAPITest
{
    public class Startup
    {
        private string HTTP_CLIENT_MICROSOFT_API_URI;
        private string HTTP_CLIENT_MICROSOFT_API_KEY;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            HTTP_CLIENT_MICROSOFT_API_URI = Environment.GetEnvironmentVariable("HTTP_CLIENT_MICROSOFT_API_URI");
            HTTP_CLIENT_MICROSOFT_API_KEY = Environment.GetEnvironmentVariable("HTTP_CLIENT_MICROSOFT_API_KEY");

            Globals.SetTimeCheckUpdates(Environment.GetEnvironmentVariable("TIMER_CHECK_UPDATES_IN_MINUTES"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CheckUpdatesHostedService>();

            services.AddHttpClient(Globals.HTTP_CLIENT_MICROSOFT_API, cli => {
                cli.BaseAddress = new Uri(HTTP_CLIENT_MICROSOFT_API_URI);
                cli.DefaultRequestHeaders.Add("Accept", "application/json");
                cli.DefaultRequestHeaders.Add("api-key", HTTP_CLIENT_MICROSOFT_API_KEY);
            });

            services.AddTransient<IUpdatesService, UpdatesService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
