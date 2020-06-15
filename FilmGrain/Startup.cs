using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using FilmGrain.Models;
using Services;
using FilmGrain.Mapping;
using AutoMapper;
using FilmGrain.Repositories;
using FilmGrain.Logic;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Logic;
using DAL.Access;
using FilmGrain.DAL.Concrete;
using DAL.Concrete;

namespace FilmGrain
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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }
            );
            services.AddHttpContextAccessor();
            services.AddScoped<PasswordSalt>();
            services.AddScoped<PasswordHash>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IMovieContext, MovieContext>();
            services.AddScoped<IMovieLogic, MovieLogic>();
            services.AddAutoMapper(typeof(MappingBootstrapper));
            DBAccess._connectionstring = (Configuration.GetConnectionString("DefaultConnection"));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
