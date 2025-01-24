using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Repartidor
    {
        public int Id { get; set; } // Identificador único del repartidor.
        public string Nombre { get; set; } = string.Empty; // Nombre del repartidor.
        public string Apellidos { get; set; } = string.Empty; // Apellidos del repartidor.
        public string Telefono { get; set; } = string.Empty; // Teléfono de contacto del repartidor.
    }
}
