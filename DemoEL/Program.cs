using DemoBLL.Interfaces;
using DemoBLL.Repositores;
using DemoDAL.Context;
using DemoDAL.Models;
using DemoEL.ProfilesMaping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);




            /////////
            ///
            Builder.Services.AddControllersWithViews();
            Builder.Services.AddDbContext<AppDbContext>(options =>
            {

                options.UseSqlServer(Builder.Configuration.GetConnectionString("DefaultConnection"));
            }
           );

           Builder.Services.AddScoped<IDepurtmentRepositore, DepurtmentReposatore>();
         
           Builder.Services.AddScoped<IEmployeeRopositore, EmployeeRopositore>();
     
           Builder.Services.AddAutoMapper(E => E.AddProfile(new EmployeeProfaile()));
          
           Builder.Services.AddAutoMapper(E => E.AddProfile(new DepurtmentProfaile()));
          
           Builder.Services.AddAutoMapper(E => E.AddProfile(new UserProfaile()));
          
           Builder.Services.AddAutoMapper(E => E.AddProfile(new RoleProfaile()));
        
           Builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Auth
            Builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            //services.AddScoped<UserManager<Register>>();
            Builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LogoutPath = "Account/Login";
                    option.AccessDeniedPath = "Home/Error";

                });


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            var app = Builder.Build();

            if (app.Environment.IsDevelopment())
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });

            app.Run();
        }

        
    }
}
