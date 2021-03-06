﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DALs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capstone.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

			services.AddDistributedMemoryCache();
            
            // We need to add the Session to Startup before it can be saved
            services.AddSession();

			services.AddTransient<IParkSqlDAL>(d => new ParkSqlDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True"));
			services.AddTransient<IWeatherSqlDAL>(d => new WeatherSqlDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True"));
			services.AddTransient<ISurveySqlDAL>(d => new SurveySqlDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True"));


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(" / Home/Error");
            }

            app.UseStaticFiles();
			app.UseCookiePolicy();

            // This is needed to save the user's choice of temperature
			app.UseSession();

			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
