using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace RouteMiddleWare
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var trackPakegaRouteHandler = new RouteHandler((context) =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync($"hello routeValues,{string.Join(',', routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, trackPakegaRouteHandler);
            routeBuilder.MapRoute("Track Package Route",
                "package/{operation:regex(^(track|create|detonate)$)}/{id:int}");

            routeBuilder.MapGet("hello/{home}",(context)=> {
                var values = context.GetRouteValue("home");
                // This is the route handler when HTTP GET "hello/<anything>"  matches
                // To match HTTP GET "hello/<anything>/<anything>,
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi,{values}");
            });
            var routes = routeBuilder.Build();
            app.UseRouter(routes);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
