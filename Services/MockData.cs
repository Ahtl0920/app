/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using MauiApp1.Models; // Importa los modelos
using System.Collections.Generic;
using System.Linq;

namespace MauiApp1.Data
    

{
    public static class MockData
    {
        // Lista de albaranes simulados en memoria
        public static List<Albaran> Albaranes { get; set; } = new List<Albaran>
        {
            new Albaran
            {
                Id = 1,
                Serie = "2001",
                NumDoc = 123,
                CodRemitente = "R001",
                RazonRemitente = "Remitente 1",
                Observaciones = "Entrega Urgente",
                FechaEfecto = DateTime.Now,
                HoraLlegada = "10:00",
                HoraSalida = "10:30",
                TipoServicio = "Express",
                TipoTransporte = "Camión",
                Destinatario = "Destinatario 1",
                Poblacion = "Madrid",
                Provincia = "Madrid",
                DocCliente = "Documento 123",
                Operarios = 2,
                MediosEspeciales = "Elevador",
                Vehiculo = "Camión 123",
                Semirremolque = "Semi 456",
                DcFirmada = true,
                NombreRecepcionista = "Recepcionista 1",
                DniRecepcionista = "12345678X",
                Conforme = true,
                MotivoNoConforme = "",
                Lineas = new List<LineaAlbaran>
                {
                    new LineaAlbaran
                    {
                        Id = 1,
                        AlbaranId = 1,
                        CodigoArticulo = "ART001",
                        Unidades = 10,
                        Estado = "Embalado",
                        Marca = "Marca A",
                        Modelo = "Modelo X",
                        Referencia = "Ref001",
                        Bultos = 2,
                        Largo = 1.5m,
                        Ancho = 0.8m,
                        Alto = 1.2m,
                        Peso = 25.5m,
                        Contenido = "Cajas de Producto A",
                        NumeroSerie = "123456789"
                    }
                }
            }
        };

        // Método para obtener la lista de albaranes simulados
        public static List<Albaran> GetAlbaranes()
        {
            return Albaranes;
        }

        // Método para obtener líneas de un albarán específico
        public static List<LineaAlbaran> GetLineasAlbaran(int albaranId)
        {
            return Albaranes.FirstOrDefault(a => a.Id == albaranId)?.Lineas ?? new List<LineaAlbaran>();
        }

        // Método para agregar un nuevo albarán
        public static void AddAlbaran(Albaran nuevoAlbaran)
        {
            // Asigna un nuevo ID automáticamente
            nuevoAlbaran.Id = Albaranes.Count + 1;

            // Si no tiene líneas, inicializa la lista vacía
            if (nuevoAlbaran.Lineas == null)
            {
                nuevoAlbaran.Lineas = new List<LineaAlbaran>();
            }

            Albaranes.Add(nuevoAlbaran);
        }
    }
}
