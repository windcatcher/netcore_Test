using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UseMidware
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }


        public static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/map", HandleMapTest2);

            app.Map("/task", taskApp =>
            {
                taskApp.Run(async context =>
                {
                    await context.Response.WriteAsync("this is a task");
                });
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("1:before start...");
                await next.Invoke();
            });

            app.Use((next) =>{
               return (context) =>
               {
                   context.Response.WriteAsync("2:middwr start...");
                   return next(context);
               };
           });

            app.UseMyRequestMiddle();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("start ....");
            });
        }


    }
}
