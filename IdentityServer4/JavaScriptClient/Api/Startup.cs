using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();

            #region use IdentityServer4.AccessTokenValidation
            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //     .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, (option) =>
            //     {
            //         option.Authority = "http://localhost:5000";//identityserver4地址
            //         option.RequireHttpsMetadata = false;//使用https
            //         option.ApiName = "api1";//api scope
            //     });
            #endregion

            //web客户端 允许跨域使用
            services.AddAuthentication("Bearer")
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = "http://localhost:5000";
                  options.RequireHttpsMetadata = false;

                  options.ApiName = "api1";
              });


            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:5003", "http://localhost:8082")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //services.AddCors(options =>
            //{
            //    // this defines a CORS policy called "default"
            //    options.AddPolicy("CorsPolicy", policy =>
            //    {
            //        policy.WithOrigins("http://localhost:5003")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});

            #region use Microsoft.AspNetCore.Authentication.JwtBearer


            /* services.AddAuthentication((options) =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer((options) =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters();
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";//api范围
                    options.Authority = "http://localhost:5000";//identityserver地址
                });
                */
            //services.AddMvc();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.Use((context, next) =>
            {
                var user = context.User;

                context.Response.StatusCode = user.Identity.IsAuthenticated ? 200 : 401;

                return next.Invoke();
            });
            app.UseMvc();
        }
    }
}
