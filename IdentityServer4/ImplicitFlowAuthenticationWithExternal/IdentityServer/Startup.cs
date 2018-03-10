using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer
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
            services.AddMvc();
            //使用内存存储，密钥，客户端和资源来配置身份服务器
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResource())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetApiClients())
                .AddTestUsers(Config.GetUsers());

            services.AddAuthentication()
               .AddGoogle("Google", options =>
               {
                   options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                   //options.ClientId = "your ClientId";
                   //options.ClientSecret = "your ClientSecret";
                   options.ClientId = "434483408261-55tc8n0cs4ff1fe21ea8df2o443v2iuc.apps.googleusercontent.com";
                   options.ClientSecret = "3gcoTrEDPPJ0ukn_aYYT6PWo";
               })
              .AddMicrosoftAccount(microsoftOptions =>
               {
                   microsoftOptions.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                   microsoftOptions.ClientId = "your ClientId";
                   microsoftOptions.ClientSecret = "your ClientSecret";
               })
               .AddOpenIdConnect("oidc", "OpenID Connect", options =>
               {
                   options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                   options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                   options.Authority = "https://demo.identityserver.io/";
                   options.ClientId = "implicit";

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       NameClaimType = "name",
                       RoleClaimType = "role"
                   };
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIdentityServer();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
