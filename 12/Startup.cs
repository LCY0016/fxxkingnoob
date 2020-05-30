using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

    
        public void ConfigureServices(IServiceCollection services){

             services.AddDbContextPool<TodoContext>(options => options
                .UseMySql(Configuration.GetConnectionString("todoDatabase"), 
                    mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(5, 7, 30), ServerType.MySql)
            ));
            services.AddControllers(); 
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()){ /
                app.UseDeveloperExceptionPage(); 
            }
            app.UseDefaultFiles(); 
            app.UseStaticFiles(); 

            app.UseHttpsRedirection(); 
            app.UseRouting();  
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>{
                endpoints.MapControllers(); 
            });            
        }
    }
}
