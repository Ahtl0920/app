using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiApp1.Models
{
    public class Mercancia
    {
        public int Id { get; set; } // Identificador único de la mercancía.
        public required string Descripcion { get; set; } // Descripción de la mercancía.
        public int Cantidad { get; set; } // Cantidad de mercancías.
        public int AlbaranId { get; set; } // ID del albarán al que pertenece la mercancía.

        public required Albaran Albaran { get; set; } // Relación con el albarán.
    }
}
