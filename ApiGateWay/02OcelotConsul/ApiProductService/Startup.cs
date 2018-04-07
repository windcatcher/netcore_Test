using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProductService.config;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiProductService
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
            services.AddMvc();
            services.AddOptions();
            services.Configure<ServiceDisvoveryOptions>(Configuration.GetSection("ServiceDiscovery"));
            services.AddSingleton<IConsulClient>(p => new ConsulClient(cfg =>
            {
                var serviceConfiguration = p.GetRequiredService<IOptions<ServiceDisvoveryOptions>>().Value;

                if (!string.IsNullOrEmpty(serviceConfiguration.Consul.HttpEndpoint))
                {
                    // if not configured, the client will use the default value "127.0.0.1:8500"
                    cfg.Address = new Uri(serviceConfiguration.Consul.HttpEndpoint);
                }
            }));
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IOptions<ServiceDisvoveryOptions> serviceOptions, IConsulClient consul)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            RegisterConsul(app, lifetime, serviceOptions, consul);
           
        }

        private void RegisterConsul(IApplicationBuilder app, IApplicationLifetime lifetime, IOptions<ServiceDisvoveryOptions> serviceOptions, IConsulClient consul)
        {

            //从配置获取ip端口信息，服务名称信息
            var features = app.Properties["server.Features"] as FeatureCollection;
            var addresses = features.Get<IServerAddressesFeature>().Addresses.Select(p => new Uri(p));

            foreach (var address in addresses)
            {
                var serviceId = $"{serviceOptions.Value.ServiceName}_{address.Host}:{address.Port}";
                //健康检查
                var httpCheck = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1),//服务1分钟后失效，consul则移除该服务
                    Interval = TimeSpan.FromSeconds(30),//每30秒进行一次健康检查
                    HTTP = new Uri(address, "HealthCheck").OriginalString
                };

                var registration = new AgentServiceRegistration()
                {
                    Checks = new[] { httpCheck },
                    Address = address.Host,//API服务地址
                    ID = serviceId,//API服务id
                    Name = serviceOptions.Value.ServiceName,//服务名称
                    Port = address.Port//api端口
                };

                //注册服务
                lifetime.ApplicationStarted.Register(() =>
                {
                    consul.Agent.ServiceRegister(registration);
                });

                ////取消注册
                //lifetime.ApplicationStopping.Register(() =>
                //{
                //    consul.Agent.ServiceDeregister(serviceId);
                //});

            }
        }
    }

}
