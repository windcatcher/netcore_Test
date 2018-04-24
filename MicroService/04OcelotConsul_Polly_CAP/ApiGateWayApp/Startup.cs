using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateWayApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "TestKey";
            var identitySrvUrl = Configuration["IdentityServerUrl"];
            Console.WriteLine($"identitySrvUrl={identitySrvUrl}");

            //identityServer 认证模式
            services.AddAuthentication()
                .AddIdentityServerAuthentication(authenticationProviderKey, (options) =>
                {
                    options.Authority = identitySrvUrl;
                    options.ApiName = "product";
                    options.SupportedTokens = SupportedTokens.Both;
                    options.RequireHttpsMetadata = false;//使用https
                    options.ApiSecret = "secret";
                });


            /* jwtbearer 认证模式
            services.AddAuthentication((options) =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(authenticationProviderKey, (options) =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters();
                     options.RequireHttpsMetadata = false;
                     options.Audience = "api1";//api范围
                    options.Authority = "http://localhost:8010";//identityserver地址
                });
             */
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseOcelot().Wait();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
