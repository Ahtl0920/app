using MauiApp1.Data;
using MauiApp1.Services;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder(); // Crea y configura la aplicación MAUI.

            builder
                .UseMauiApp<App>() // Especifica que "App" es la clase principal de la aplicación.
                .ConfigureFonts(fonts =>
                {
                    // Configura las fuentes personalizadas para la aplicación.
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configuración de la base de datos con SQL Server.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=TuBaseDeDatos;User Id=Usuario;Password=Contraseña;"));

            // Registro de servicios en el contenedor de dependencias.
            builder.Services.AddScoped<AlbaranService>(); // Servicio para gestionar Albaranes.
            builder.Services.AddScoped<LineaAlbaranService>(); // Servicio para gestionar Líneas de Albaranes.

            return builder.Build(); // Construye y devuelve la aplicación MAUI configurada.
        }
    }
}
