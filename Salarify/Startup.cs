using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

namespace Salarify
    {
    public class Startup
        {
        public Startup (IConfiguration configuration)
            {
            Configuration = configuration;
            }

        public IConfiguration Configuration
            {
            get;
            }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
            {
            services.AddDbContext<Salarify.DataLayer.SalarifyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
            {
            if ( env.IsDevelopment() )
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
                routes.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routes.MapODataServiceRoute("odata", "odata", GetEdmModel());
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if ( env.IsDevelopment() )
                    {
                    spa.UseAngularCliServer(npmScript: "start");
                    }
            });
            }

        private static IEdmModel GetEdmModel ()
            {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            
            builder.EntitySet<Salarify.DataLayer.Models.Employee>("Employees");
            builder.EntitySet<Salarify.DataLayer.Models.BaseSalary>("BaseSalaries");
            builder.EntitySet<Salarify.DataLayer.Models.Manager>("Managers");
            var function = builder.Function("EmployeesWithSalary");
            function.ReturnsCollectionViaEntitySetPath<Salarify.DataLayer.Models.Employee>("Employees");
            return builder.GetEdmModel();
            }
        }
    }
