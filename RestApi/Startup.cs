using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestApi.Domain.Core;
using RestApi.Domain.Interfaces;
using RestApi.Implementations.Data;
using RestApi.Models;
using RestApi.Services.Implementations;
using RestApi.Services.Interfaces;

namespace RestApi
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
               x => x.MigrationsAssembly("RestApi.Infrastructure.Data")));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddIdentity<User, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRestaurantService, RestaurantService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
