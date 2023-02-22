using ProjektSklep.Models;
using ProjektSklep.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjektSklep.Services;

namespace ProjektSklep
{
    public class Program
    {

        public static void Main(string[] args)
        {
            string envDev = "dev";
            string envProd = "prod";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ProjektSklepContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(envDev)));
            builder.Services.AddIdentity<Client,IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ProjektSklepContext>();
            builder.Services.AddScoped<IShopService, ShopService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
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