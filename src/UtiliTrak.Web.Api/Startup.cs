using System;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Hazeltek.Data.EFx;
using Hazeltek.UtiliTrak.Data;
using Hazeltek.UtiliTrak.Web.Common.Routing;
using Hazeltek.UtiliTrak.Services.Network;
using Hazeltek.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hazeltek.UtiliTrak.Web.Common;
using Hazeltek.Infrastructure.DependencyManagement;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;



namespace Hazeltek.UtiliTrak.Web
{
    public class Startup
    {
        public IContainer Container { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettigns.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettigns.{env.EnvironmentName}.json", optional: true);
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
               ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();

            // if you want to dispose of resources that have been resolved in
            // the application container, register for ApplicationStopped
            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
            
            // exception handler
            app.UseExceptionHandler(options => {
                options.Run(async context => {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/html";
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null) {
                        var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                        await context.Response.WriteAsync(err).ConfigureAwait(false);
                    }
                });
            });
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRouting(options => 
                options.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionRouteConstraint)));

            // core asp.net settings
            services.AddDbContext<Context>(options => options.UseSqlite("Filename=utilitrak.db"));
            services.AddScoped<IDbContext, Context>();

            // populate IoC container
            var builder = new ContainerBuilder();
            ConfigureAutoMapper(builder);

            builder.Populate(services);
            this.Container = builder.Build();

            // initialize engine
            EngineContext.Initialize(new ContainerManager(Container), 
                new AppProcessTypeFinder(), new ConfigProvider());

            return new AutofacServiceProvider(this.Container);
        }

        private void ConfigureAutoMapper(ContainerBuilder builder)
        {
            var sourceAssembly = GetType().GetTypeInfo().Assembly;
            AutoMapperAdapter.LoadMappingsFrom(sourceAssembly);
            builder.RegisterType<AutoMapperAdapter>().As<IAutoMapper>()
                   .SingleInstance();
        }
    }

}