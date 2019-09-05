using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using GAP.Test.Domain.Core.Base;
using GAP.Test.Domain.Core.Contracts;
using GAP.Test.Domain.Infraestructure;
using GAP.Test.Front.Application.Services;
using GAP.Test.Front.Application.Services.Contracts;
using GAP.Test.Front.Infrastructure;
using GAP.Test.Front.Infrastructure.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GAP.Test.Front
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddEntityFrameworkMySql().AddDbContext<TestContext>(options =>
            {
                options.UseMySql(Configuration.GetSection("ConnectionString").Value,
                mySqlOptionsAction: mysqlOpt =>
                {
                    mysqlOpt.MigrationsAssembly(typeof(TestContext).Assembly.GetName().Name);
                });
            }, ServiceLifetime.Scoped);
            services.AddScoped<IDbContext, TestContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPolizaService, PolizaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ITipoCoberturaService, TipoCoberturaService>();
            services.AddTransient<ITipoRiesgoService, TipoRiesgoService>();
            
            services.AddCors(setup => setup.AddPolicy("gaptest", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("atlas-ordermang-cors-policy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            var context = (TestContext)app.ApplicationServices.GetService(typeof(TestContext));
            if (!context.AllMigrationsApplied())
            {
                context.Database.Migrate();
                context.EnsureSeed(app.ApplicationServices.GetService<IHostingEnvironment>(),
                                   app.ApplicationServices.GetService<ILogger<TestContext>>());
            }

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
