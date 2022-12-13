using Product.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Middleware;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            ConfigureServices(services, connectionString);
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseMiddleware<DbInitializerMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(connectionString));
            services.AddSession();
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("AllCaching",
                new CacheProfile()
                {
                    Duration = 266
                });
            });
            services.AddControllers();
        }
    }
}