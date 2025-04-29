using Microsoft.Extensions.Logging;
using ProyectoLambda.Services;
using ProyectoLambda.Services.Interface;
using ProyectoLambda.Data.Context;
using ProyectoLambda.Data.UnitOfWork.Interface;
using ProyectoLambda.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ProyectoLambda
{
    public static partial class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                    .UseMauiCommunityToolkit(options =>
                    {
                        options.SetShouldEnableSnackbarOnWindows(true);                     
                    })
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        fonts.AddFont("OpenSans-SemiBold.ttf", "OpenSansSemiBold");
                        fonts.AddFont("FontAwesome.ttf", "FontAwesome");
                    });
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton(AppInfo.Current);


            // Inyeccion servicios
            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

            builder.Services.AddSingleton<IDisplayService, DisplayService>();

            // Inyeccion db
            string ruta = Path.Combine(FileSystem.AppDataDirectory, "app.db");

            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseSqlite($"Data Source={ruta}");
            });

          

#if DEBUG
            // Caution: Recommended to enable Developer Tools only for development!!!
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            // Inyeccion de la base de datos
            Task.Run(async () => await Seeding.AddSeeding(builder.Services)).Wait();

            return builder.Build();
        }
    }
}
