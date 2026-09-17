using Microsoft.EntityFrameworkCore;
using GymManagement;
using GymManagement.AppDpContext;

namespace GymManagement;

public class Program
{
        public static void Main(string[] args)
        {
            var builder = global::Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register DbContext so controllers can receive AppDpContext via DI
            var connection= builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<GymManagement.AppDpContext.AppDpContext>(options =>
                options.UseSqlServer("connection"));

            var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
