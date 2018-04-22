using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiOderService.Infrastructure.Filters;
using Consul;
using DotNetCore.CAP.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiOderService
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
            //  var logger = loggerFac.CreateLogger("app.StartupService");
            services.AddDbContext<OrderContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"],
                    mySqlOptionsAction: sqlAction =>
                    {
                        sqlAction.EnableRetryOnFailure(
                            maxRetryCount: 5, //重试5次
                            maxRetryDelay: TimeSpan.FromSeconds(30), //每个30s重试一次
                            errorNumbersToAdd: null
                                );
                    });
            });
            services.AddCap(x =>
            {
                x.UseEntityFramework<OrderContext>();
                x.UseDashboard();
                x.UseRabbitMQ(Configuration["ConStrRabbitMq"]);
                x.FailedRetryCount = 4;//FailedRetryCount 设置建议大于3，因为三次以内不走重试处理器，处理不到FailedCallback
                x.FailedCallback = new Action<MessageType, string, string>(FailCallbackFoo);
                var consulUrl = Configuration["ConsulUrl"];
                var userUrl = Configuration["RegisterServerUrl"];
                var consulUri = new Uri(consulUrl);
                var userUri = new Uri(userUrl);
                var ipAdress = System.Net.Dns.GetHostAddresses(userUri.Host).Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                var serviceName = Configuration["RegisterServiceName"];
                var serviceId = $"{serviceName}_{ipAdress.ToString()}_{userUri.Port}";
                // logger.LogInformation($"serviceId:{serviceId}");
                // Register to Consul
                x.UseDiscovery(d =>
                {
                    d.DiscoveryServerHostName = consulUri.Host;
                    d.DiscoveryServerPort = consulUri.Port;
                    d.CurrentNodeHostName = ipAdress.ToString();
                    d.CurrentNodePort = userUri.Port;
                    d.NodeId = 2;
                    d.NodeName = serviceName;

                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "OrderService接口文档",
                    Description = "RESTful API for OrderService接口文档"
                    //TermsOfService = "None",
                    //Contact = new Contact { Name = "lms", Email = "asdasdasd@outlook.com", Url = ""
                });
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });
        }


        private void FailCallbackFoo(MessageType msgType, string name, string content)
        {
            Console.WriteLine($"fail msg Name:{name},content:{content}");
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseCap();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderService接口文档 API V1");
            });

        }

        private void RegisterConsul(IApplicationLifetime lifetime, ILogger logger)
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
            logger.LogInformation($"serviceId:{serviceId}");
            var agentReg = new AgentServiceRegistration()
            {
                Checks = new AgentServiceCheck[] { httpCheck },
                //Address = userUri.Host,      //API服务地址
                Address = ipAdress.ToString(),      //API服务地址
                ID = serviceId,     //API服务id
                Name = serviceName,      //服务名称
                Port = userUri.Port                  //api端口
            };

            //注册服务
            lifetime.ApplicationStarted.Register(() =>
            {
                client.Agent.ServiceRegister(agentReg);
            });
        }
    }
}
