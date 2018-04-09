using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dockcomposeSimple
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
            services.Configure<AppSettings>(Configuration);
            services.AddMvc();
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
            Console.WriteLine($"TestEnv={Configuration["TestEnv"]}");
            Console.WriteLine($"HostName={Configuration["HostName"]}");
            Console.WriteLine($"ASPNETCORE_URLS={Configuration["ASPNETCORE_URLS"]}");

            //获取docker下的ip地址
            var hostName = Configuration["HostName"];
            var aspurl = Configuration["ASPNETCORE_URLS"];
            Uri.TryCreate(aspurl, UriKind.Absolute, out Uri uri);
            var ipEndPoint = GetHostIpEndPoint(hostName, aspurl);

            Console.WriteLine($"realIP={ipEndPoint.ToString()}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private IPEndPoint GetHostIpEndPoint(string hostName,string aspcoreUrl)
        {
            IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            var hostip = ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            Uri.TryCreate(aspcoreUrl, UriKind.Absolute, out Uri uri);
            return new IPEndPoint(hostip, uri.Port);
        }
    }
}
