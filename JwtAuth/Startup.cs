using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuth {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            //
            services.Configure<JwtSetting> (Configuration.GetSection("JwtSetting"));
            var jwtSetting = new JwtSetting ();
            Configuration.Bind ("JwtSetting", jwtSetting);
            services.AddAuthentication (Options => {
                    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (o => {
                    o.TokenValidationParameters = new TokenValidationParameters () {
                    ValidAudience = jwtSetting.Audience,
                    ValidIssuer = jwtSetting.Issuser,
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (jwtSetting.ScrectKey))
                    };
                });

            services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseAuthentication ();
            app.UseMvcWithDefaultRoute();
        }
    }
}