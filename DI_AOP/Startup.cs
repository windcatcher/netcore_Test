using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_AOP.Data;
using DI_AOP.Interfaces;
using DI_AOP.Models;
using DI_AOP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI_AOP {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole> ()
                .AddEntityFrameworkStores<ApplicationDbContext> ()
                .AddDefaultTokenProviders ();

            // Add application services.
            //临时的，每次实例化新的对象
            services.AddTransient<IEmailSender, EmailSender> ();

            services.AddMvc ();
            services.AddScoped<ICharacterRepository, CharacterRepository> ();
            //临时的，每次实例化新的对象
            services.AddTransient<IOperationTransient, Operation> ();
            //每次请求都实例化新的对象
            services.AddScoped<IOperationScoped, Operation> ();
             //单例对象
            services.AddSingleton<IOperationSingleton, Operation> ();
            services.AddSingleton<IOperationSingletonInstance> (new Operation (Guid.Empty));
            services.AddTransient<OperationService, OperationService> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseBrowserLink ();
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();

            app.UseAuthentication ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}