using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DAL.Models;
using Microsoft.Data.Entity;

namespace DAL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<NorthwindContextBase>(opt =>
                {
                    opt.UseSqlServer("Data Source=ALEKSEY-SIDOROV\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
                });
            //.AddDbContext<NorthwindContextBase>(opt=> {
            //    opt.UseSqlServer("Data Source=KRIPTEKS-ПК\\SQLEXPRESS;Initial Catalog=Northiwnd;Integrated Security=True");
            //});
        }


        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; set; }
    }
}
