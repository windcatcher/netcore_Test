using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiUserService
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            lifetime.ApplicationStarted.Register(onStart);
            app.UseMvc();
        }

        private void onStart()
        {
            var client = new ConsulClient();
            var consulUrl = Configuration["ConsulUrl"];

            client.Config.Address = new Uri(consulUrl);
            var userUrl = Configuration["RegisterServerUrl"];

            //健康检查
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1), //服务1分钟后失效，consul则移除该服务
                Interval = TimeSpan.FromSeconds(30),//每30秒进行一次健康检查
                HTTP = $"{userUrl}/HealthCheck"
            };
            var userUri = new Uri(userUrl);
            var ipAdress = System.Net.Dns.GetHostAddresses(userUri.Host).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
            var serviceName = Configuration["RegisterServiceName"];
            var serviceId = $"{serviceName}_{ipAdress.ToString()}_{userUri.Port}";
            var agentReg = new AgentServiceRegistration()
            {
                Checks = new AgentServiceCheck[] { httpCheck },
                Address = userUri.Host,      //API服务地址
                ID = serviceId,     //API服务id
                Name = serviceName,      //服务名称
                Port = userUri.Port                  //api端口
            };

            //注册服务
            client.Agent.ServiceRegister(agentReg);
        }
    }
}
