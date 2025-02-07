using MauiApp1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //  Registrar BackendService para la comunicación con el backend
            builder.Services.AddSingleton<BackendService>();

            return builder.Build();
        }
    }
}
