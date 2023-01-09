namespace DependencyInjectionScopes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddSingleton<IMyManager, MyManager>();   // Uyg boyunca sadece 1 nesne new ler.
            //builder.Services.AddTransient<IMyManager, MyManager>();   // Her istenilen yerde yeni bir instance new ler.
            builder.Services.AddScoped<IMyManager, MyManager>();        // Her request de yeni bir instance new ler.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}