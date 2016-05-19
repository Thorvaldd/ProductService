using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Repository.Interfaces;
using Repository.Services;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //application services
            services.AddEntityFramework()
             .AddSqlServer()
             .AddDbContext<NorthwindContextBase>(opt =>
             {
                 opt.UseSqlServer("Data Source=ALEKSEY-SIDOROV\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
             });
            
            services.AddMvcCore()
                .AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddCors(opt =>
            {
                opt.AddPolicy("Sepcific",
                    b=>b.AllowAnyHeader()
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                    );
            });

            services.AddMvc();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc(r =>
            {
                r.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Products}/{id?}");
            });
            app.UseDeveloperExceptionPage();
            app.UseCors("Sepcific");

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
