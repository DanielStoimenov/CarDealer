using AutoMapper;
using CarDealer.Mapping;
using CarDealer.Persistence;
using CarDealer.Services.Implementations;
using CarDealer.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web
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
            services.AddDbContext<CarDealerDbContext>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddControllersWithViews();

            var mapperConfig = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new CarDealerProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Middlewares
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
           
                app.UseHsts();
            }

            // check https protocol
            app.UseHttpsRedirection();

            // check for static files
            app.UseStaticFiles();

            app.UseRouting();

            // check for autorization
            app.UseAuthorization();

            // default endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
