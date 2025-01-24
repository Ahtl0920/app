using MauiApp1.Services; // Importa los servicios AlbaranService y LineaAlbaranService.

namespace MauiApp1
{
    // Define la página principal de la aplicación.
    public partial class MainPage : ContentPage
    {
        private readonly AlbaranService _albaranService; // Servicio para manejar albaranes.
        private readonly LineaAlbaranService _lineaAlbaranService; // Servicio para manejar líneas de albaranes.

        // Constructor que recibe las instancias de los servicios.
        public MainPage(AlbaranService albaranService, LineaAlbaranService lineaAlbaranService)
        {
            InitializeComponent(); // Inicializa los componentes definidos en el archivo XAML asociado.

            _albaranService = albaranService;
            _lineaAlbaranService = lineaAlbaranService;
        }

        // Evento que se dispara cuando se hace clic en un botón para cargar datos de un albarán.
        private async void OnLoadAlbaranClicked(object sender, EventArgs e)
        {
            // Llama al servicio para obtener un albarán específico.
            var albaran = await _albaranService.GetAlbaranOrigenAsync("AV2023", 1457);

            if (albaran != null)
            {
                // Muestra información del albarán en una alerta.
                await DisplayAlert("Albarán Origen",
                    $"Serie: {albaran.Serie}\n" +
                    $"Número: {albaran.NumDoc}\n" +
                    $"Remitente: {albaran.RazonRemitente}\n" +
                    $"Fecha de Efecto: {albaran.FechaEfecto.ToShortDateString()}",
                    "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se encontró el albarán.", "OK");
            }
        }

        // Evento que se dispara cuando se hace clic en un botón para cargar líneas de un albarán.
        private async void OnLoadLineasClicked(object sender, EventArgs e)
        {
            // Llama al servicio para obtener las líneas de un albarán.
            var lineas = await _lineaAlbaranService.GetLineasByAlbaranIdAsync(5210);

            if (lineas.Any())
            {
                // Crea un detalle de las líneas para mostrar en una alerta.
                string detalles = string.Join("\n", lineas.Select(l =>
                    $"Artículo: {l.CodigoArticulo}, Unidades: {l.Unidades}, Estado: {l.Estado}"));
                await DisplayAlert("Líneas del Albarán", detalles, "OK");
            }
            else
            {
                await DisplayAlert("Sin líneas", "No se encontraron líneas para este albarán.", "OK");
            }
        }
    }
}
