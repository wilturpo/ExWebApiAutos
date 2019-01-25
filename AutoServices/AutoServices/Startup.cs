using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServices.Models;
using AutoServices.Models.Repositories;
using Domain;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Domain.IRepositories;

namespace AutoServices
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
            services.AddDbContext<AutoDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:Auto:ConnectionString"]));            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:AutoIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();            services.AddTransient<IMarcaRepository, EFMarcaRepository>();            services.AddTransient<IAutoRepository, EFAutoRepository>();

            //DE LOS SERVICIOS
            services.AddTransient<IMarcaService, MarcaService>();            services.AddTransient<IAutoService, AutoService>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "AutoServices", Version = "v1" });
            });            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            /*else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();*/

            app.UseAuthentication();
            app.UseMvc();
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
