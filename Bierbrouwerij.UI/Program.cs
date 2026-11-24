using Bierbrouwerij.Application;
using Bierbrouwerij.Application.Interfaces;
using Bierbrouwerij.Application.Service;
using Bierbrouwerij.Infrastructure;
using Bierbrouwerij.Infrastructure.Data;
using Bierbrouwerij.UI.Components;
using Microsoft.EntityFrameworkCore;

namespace Bierbrouwerij.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")! 
                ?? "Data Source=bierbrouwerij.db";

            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(connectionString);

            var app = builder.Build();

            // Automatisch migraties toepassen bij opstarten
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BierbrouwerijDbContext>();
                db.Database.Migrate();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}