using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiProductService.config;
using Consul;
using DnsClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

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
            services.Configure<ServiceDisvoveryOptions>(Configuration);
            services.AddSingleton<IConsulClient>(p => new ConsulClient(cfg =>
            {
                cfg.Address = new Uri(Configuration["ConsulUrl"]);
            }));

            //服务间发现dns的地址
            services.AddSingleton<IDnsQuery>(p =>
            {
                var uri = new Uri(Configuration["DiscoverDnsUrl"]);
                var ipdrs = Dns.GetHostAddresses(uri.Host).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                return new LookupClient(ipdrs, uri.Port);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ProdcutService接口文档",
                    Description = "RESTful API for ProdcutService接口文档"
                    //TermsOfService = "None",
                    //Contact = new Contact { Name = "lms", Email = "asdasdasd@outlook.com", Url = ""
                });
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env
            , IApplicationLifetime lifetime, IConsulClient consul,ILoggerFactory loggerFac)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService接口文档 API V1");
            });
            app.UseMvc();
            var logger = loggerFac.CreateLogger("App");
            RegisterConsul(lifetime, consul,logger);
        }

        private void RegisterConsul( IApplicationLifetime lifetime, IConsulClient consul, ILogger logger)
        {
            
            var consulUrl = Configuration["ConsulUrl"];
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
                    consul.Agent.ServiceRegister(agentReg);
                });

            ////取消注册
            //lifetime.ApplicationStopping.Register(() =>
            //{
            //    consul.Agent.ServiceDeregister(serviceId);
            //});

        }
    }

}