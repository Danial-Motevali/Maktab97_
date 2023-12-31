using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Services;
using App.Infrastructure.Data.EF;
using App.Infrastructure.DataAccess.Repository;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // Test(cancellation); // this need to go with cancellation in Main


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //connect to database
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                     option.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"))
            );

            //Add Identity 
            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(typeof(Program)/*.Assembly*/);

            //configure the services in dependency class
            builder.Services.Infstracture();

            // add hangfire
            builder.Services.AddHangfire((sp, config) =>
            {
                var connection = sp.GetRequiredService<IConfiguration>().GetConnectionString("DefultConnection");
                config.UseSqlServerStorage(connection);
            });
            builder.Services.AddHangfireServer();

            builder.Services.AddSingleton(new AppSetting(builder.Configuration));

            var app = builder.Build();

            //data seeder
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetService<ApplicationDbContext>();
            //    DataSeeder.Seedfordata(context);
            //}

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}