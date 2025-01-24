namespace MauiApp1.Models
{
    public class LineaAlbaran
    {
        public int Id { get; set; } // Identificador único de la línea de albarán.   // IDLIN
        public int AlbaranId { get; set; } // Relación con el albarán al que pertenece la línea (clave foránea).   // IDALBV
        public string CodigoArticulo { get; set; } = string.Empty; // Código del artículo relacionado con esta línea.    // CODART
        public int Unidades { get; set; } // Cantidad de unidades en esta línea.  // UNIDADES
        public string Estado { get; set; } = string.Empty; // Estado del artículo (por ejemplo, embalado, protegido, etc.).  // EXT0_ESTADO
        public string Marca { get; set; } = string.Empty; // Marca del artículo.    // EXT0_MARCA
        public string Modelo { get; set; } = string.Empty; // Modelo del artículo.  // EXT0_MODELO
        public string Referencia { get; set; } = string.Empty; // Referencia del artículo.   // EXT0_REFERENCIA
        public int Bultos { get; set; } // Número de bultos relacionados con esta línea.    // EXT0_BULTOS
        public decimal Largo { get; set; } // Largo del artículo.  // EXT0_LARGO
        public decimal Ancho { get; set; } // Ancho del artículo. // EXT0_ANCHO
        public decimal Alto { get; set; } // Alto del artículo. // EXT0_ALTO
        public decimal Peso { get; set; } // Peso del artículo. // EXT0_PESO

        // campos para "destino":
        public string Contenido { get; set; } = string.Empty; // Descripción del contenido (EXT0_CONTENIDO).
        public string NumeroSerie { get; set; } = string.Empty; // Número de serie del artículo (NUMSERIE).

        // Relación con la cabecera del albarán.
        public Albaran Albaran { get; set; } // Referencia al albarán al que pertenece esta línea.
    }
}
