using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Webapi_mysql_dockercompose.Models;

namespace Webapi_mysql_dockercompose {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<StudentContext> (options => { options.UseMySql (Configuration["ConnectionString"]); });
            services.AddScoped<IStudentRepository, StudentRepository> ();
            services.AddMvc ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            System.Console.WriteLine (env.EnvironmentName);
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc ();
            //如果没有数据库则自动创建
            InitStudentDb (app);
        }

        public void InitStudentDb (IApplicationBuilder app) {
            using (var scope = app.ApplicationServices.CreateScope ()) {
                var dbContext = scope.ServiceProvider.GetService<StudentContext> ();
                dbContext.Database.Migrate (); //使用这行代码会制动迁移和创建数据库
                //如果没有数据，则填充数据
                if (!dbContext.Students.Any ()) {
                    dbContext.Students.Add (new Student () { Name = "s1" });
                    dbContext.Students.Add (new Student () { Name = "s2" });
                    dbContext.Students.Add (new Student () { Name = "s3" });
                    dbContext.SaveChanges ();
                }
            }
        }

    }
}