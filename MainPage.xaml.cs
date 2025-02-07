using MauiApp1.Services;
using System.Linq;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly BackendService _backendService; // Servicio para manejar la comunicación con el backend.

        //  Constructor que recibe la instancia del servicio BackendService.
        public MainPage(BackendService backendService)
        {
            InitializeComponent();
            _backendService = backendService;
        }

        //  Evento para cargar datos de la cabecera origen.
        private async void OnLoadAlbaranClicked(object sender, EventArgs e)
        {
            string serie = await DisplayPromptAsync("Cargar Albarán Origen", "Introduce la serie del albarán:");
            string numDocStr = await DisplayPromptAsync("Cargar Albarán Origen", "Introduce el número de documento:", keyboard: Keyboard.Numeric);

            if (string.IsNullOrEmpty(serie) || string.IsNullOrEmpty(numDocStr) || !int.TryParse(numDocStr, out int numDoc))
            {
                await DisplayAlert("Error", "Debes introducir una serie y un número de documento válidos.", "OK");
                return;
            }

            var albaran = await _backendService.GetAlbaranBySerieAndNumAsync(serie, numDoc);

            if (albaran != null)
            {
                await DisplayAlert("Albarán Origen",
                    $"Serie: {albaran.Serie}\n" +
                    $"Número: {albaran.NumDoc}\n" +
                    $"Remitente: {albaran.RazonRemitente}\n" +
                    $"Fecha de Efecto: {albaran.FechaEfecto.ToShortDateString()}",
                    "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se encontró el albarán origen.", "OK");
            }
        }

        //  Evento para cargar datos de la cabecera destino.
        private async void OnLoadAlbaranDestinoClicked(object sender, EventArgs e)
        {
            string serie = await DisplayPromptAsync("Cargar Albarán Destino", "Introduce la serie del albarán:");
            string numDocStr = await DisplayPromptAsync("Cargar Albarán Destino", "Introduce el número de documento:", keyboard: Keyboard.Numeric);

            if (string.IsNullOrEmpty(serie) || string.IsNullOrEmpty(numDocStr) || !int.TryParse(numDocStr, out int numDoc))
            {
                await DisplayAlert("Error", "Debes introducir una serie y un número de documento válidos.", "OK");
                return;
            }

            var albaran = await _backendService.GetAlbaranBySerieAndNumAsync(serie, numDoc);

            if (albaran != null)
            {
                await DisplayAlert("Albarán Destino",
                    $"Serie: {albaran.Serie}\n" +
                    $"Número: {albaran.NumDoc}\n" +
                    $"Destinatario: {albaran.Destinatario}\n" +
                    $"Población: {albaran.Poblacion}\n" +
                    $"Observaciones: {albaran.Observaciones}",
                    "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se encontró el albarán destino.", "OK");
            }
        }

        //  Evento para cargar las líneas de un albarán.
        private async void OnLoadLineasClicked(object sender, EventArgs e)
        {
            string idAlbaranStr = await DisplayPromptAsync("Cargar Líneas", "Introduce el ID del albarán:", keyboard: Keyboard.Numeric);

            if (string.IsNullOrEmpty(idAlbaranStr) || !int.TryParse(idAlbaranStr, out int idAlbaran))
            {
                await DisplayAlert("Error", "Debes introducir un ID de albarán válido.", "OK");
                return;
            }

            var lineas = await _backendService.GetLineasByAlbaranIdAsync(idAlbaran);

            if (lineas.Any())
            {
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
