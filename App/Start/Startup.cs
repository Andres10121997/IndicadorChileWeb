using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IndicadorChileWeb.App.Start
{
    public static class Startup
    {
        #region Init
        public static WebApplication InitApp(string[] args)
        {
            #region Objects
            WebApplicationBuilder builder;
            WebApplication app;
            #endregion

            builder = WebApplication.CreateBuilder(args: args);

            ConfigureServices(Builder: builder);

            app = builder.Build();

            Configure(App: app);

            return app;
        }
        #endregion



        #region Configure
        private static void ConfigureServices(WebApplicationBuilder Builder)
        {
            // Add services to the container.
            Builder.Services.AddControllersWithViews();
        }

        private static void Configure(WebApplication App)
        {
            // Configure the HTTP request pipeline.
            if (!App.Environment.IsDevelopment())
            {
                App.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                App.UseHsts();
            }

            App.UseHttpsRedirection();
            App.UseRouting();

            App.UseAuthorization();

            App.MapStaticAssets();
            App.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
        }
        #endregion
    }
}