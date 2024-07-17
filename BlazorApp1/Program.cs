using BlazorApp1.Components;
using BlazorApp1.Components.Pages;
using BlazorApp1.Data;
using BlazorApp1.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configurăm baza de date
            builder.Services.AddDbContext<ExpenseTrackerContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ExpenseTrackerDatabase"))
            );

            // Adăugăm serviciile necesare
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<ExpenseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
