using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicrosoftSecurityUpdateAPITest.Core.Connection;
using MicrosoftSecurityUpdateAPITest.Core.Connection.Behaviours;
using MicrosoftSecurityUpdateAPITest.Repository;
using MicrosoftSecurityUpdateAPITest.Repository.Behaviours;
using MicrosoftSecurityUpdateAPITest.Repository.Mappings.Utils;
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

            HTTP_CLIENT_MICROSOFT_API_URI = Configuration.GetValue<string>("HTTP_CLIENT_MICROSOFT_API_URI");//Environment.GetEnvironmentVariable("HTTP_CLIENT_MICROSOFT_API_URI");
            HTTP_CLIENT_MICROSOFT_API_KEY = Configuration.GetValue<string>("HTTP_CLIENT_MICROSOFT_API_KEY");//Environment.GetEnvironmentVariable("HTTP_CLIENT_MICROSOFT_API_KEY");

            Globals.SetTimeCheckPatch(Configuration.GetValue<string>("TIMER_CHECK_PATCH_IN_MINUTES"));
            Globals.SetConnectionString(Configuration.GetValue<string>("CONNECTION_STRING"));

            MappingSystem.Register();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<CheckPatchHostedService>();

            services.AddHttpClient(Globals.HTTP_CLIENT_MICROSOFT_API, cli => {
                cli.BaseAddress = new Uri(HTTP_CLIENT_MICROSOFT_API_URI);
                cli.DefaultRequestHeaders.Add("Accept", "application/json");
                cli.DefaultRequestHeaders.Add("Accept", "application/xml");
                cli.DefaultRequestHeaders.Add("api-key", HTTP_CLIENT_MICROSOFT_API_KEY);
            });

            services.AddHttpClient(Globals.HTTP_CLIENT_MICROSOFT_API_XML, cli =>
            {
                cli.BaseAddress = new Uri(HTTP_CLIENT_MICROSOFT_API_URI);
                cli.DefaultRequestHeaders.Add("Accept", "application/xml");
                cli.DefaultRequestHeaders.Add("api-key", HTTP_CLIENT_MICROSOFT_API_KEY);
            });

            services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

            services.AddSingleton<IPatchService, PatchService>();
            services.AddSingleton<ICvrfdocService, CvrfdocService>();
            services.AddSingleton<IRemediationService, RemediationService>();
            services.AddSingleton<IPatchCatalogService, PatchCatalogService>();

            services.AddTransient<IPatchRepository, PatchRepository>();
            services.AddTransient<IRemediationRepository, RemediationRepository>();
            services.AddTransient<IPatchCatalogTemplateRepository, PatchCatalogTemplateRepository>();

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
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
