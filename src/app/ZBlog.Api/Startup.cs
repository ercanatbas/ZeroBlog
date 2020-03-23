using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using ZBlog.Api.Extensions;
using ZBlog.Core.Authentication;
using ZBlog.Core.Container;
using ZBlog.Core.Error;

namespace ZBlog.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = ContainerManager.Instance.Resolve<ITokenProvider>().GetTokenValidationParameters();
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("LocalCorsPolicy", b => b
                    .SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            services.AddSwaggerDocumentation();
            services.AddMvcCore().AddApiExplorer();
            services.AddResponseCompression();
            var provider = WindsorRegistrationHelper.CreateServiceProvider(ContainerManager.Instance.WindsorContainer, services);
            return provider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            BootStrapper.InitializeContainer();
            BootStrapper.InitializeSettings();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("LocalCorsPolicy");
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSwaggerDocumentation();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseResponseCompression();
        }
    }
}
