using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using MatrixSoftLabs.TestTask.Entity;
using MatrixSoftLabs.TestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace MatrixSoftLabs.TestTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MatrixSoftLabsDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MatrixSoftLabsDbContext")));

            builder.Services.AddScoped<GoogleCalendarFeedService>();
            builder.Services.AddScoped<MicrosoftCalendarFeedService>();
            builder.Services.AddScoped<CalendarService>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();

                return new CalendarService(new BaseClientService.Initializer()
                {
                    ApiKey = configuration?.GetValue<string>("GoogleApiKey")
                });
            });

            var app = builder.Build();

            //Create and migrate database if not exist
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<MatrixSoftLabsDbContext>();
                await dataContext.Database.MigrateAsync();
            }
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Calendar}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
