using System;
using System.Collections.Generic;

namespace MauiApp1.Models
{
    public class Albaran
    {
        public int Id { get; set; } // IDALBV: Identificador del albarán.
        public string Serie { get; set; } = string.Empty; // SERIE: Serie del albarán.
        public int NumDoc { get; set; } // NUMDOC: Número de documento del albarán.

        // Parte "origen":
        public string CodRemitente { get; set; } = string.Empty; // EXT0_OREMITENTE: Código del remitente.
        public string RazonRemitente { get; set; } = string.Empty; // EXT0_ORAZONREMITENTE: Razón social del remitente.
        public string Observaciones { get; set; } = string.Empty; // EXT0_OSOBSERVACIONES: Observaciones del albarán.
        public DateTime FechaEfecto { get; set; } // EXT0_OFECHAEFECTO: Fecha de efecto del albarán.
        public List<LineaAlbaran> Lineas { get; set; } = new(); // Relación con líneas.

        public string HoraLlegada { get; set; } = string.Empty; // EXT0_OHORADELLEGADA: Primera hora de llegada.
        public string HoraSalida { get; set; } = string.Empty; // EXT0_OHORADESALIDA: Primera hora de salida.
        public string HoraLlegada2 { get; set; } = string.Empty; // EXT0_OHORADELLEGADA2: Segunda hora de llegada.
        public string HoraSalida2 { get; set; } = string.Empty; // EXT0_OHORADESALIDA2: Segunda hora de salida.

        // Parte "destino":
        public string TipoServicio { get; set; } = string.Empty; // EXT0_DCABETIPOSERVICIO: Tipo de servicio.
        public string TipoTransporte { get; set; } = string.Empty; // EXT0_DESCTIPODESERVICIO: Tipo de transporte.
        public string Destinatario { get; set; } = string.Empty; // EXT0_DRAZONDESTINATARIO: Razón social del destinatario.
        public string Poblacion { get; set; } = string.Empty; // EXT0_DPOBLACION: Población del destinatario.
        public string Provincia { get; set; } = string.Empty; // EXT0_DNOMPROVI: Provincia del destinatario.
        public string DocCliente { get; set; } = string.Empty; // EXT0_DDOCUMERCACLI: Documentación del cliente.
        public int Operarios { get; set; } // EXT0_DNUMOPERARIOS: Número de operarios.
        public string MediosEspeciales { get; set; } = string.Empty; // EXT0_DMEDIOSESPECIALES: Medios especiales utilizados.
        public string Vehiculo { get; set; } = string.Empty; // EXT0_DMVEHICULODEREP: Vehículo asignado.
        public string Semirremolque { get; set; } = string.Empty; // EXT0_DMSEMIRREMOLQUEREP: Semirremolque asignado.
        public bool DcFirmada { get; set; } // EXT0_DCONFFIRMADO: Indica si el albarán fue firmado.
        public bool DcSellada { get; set; } // EXT0_DCONFSELLADO: Indica si el albarán fue sellado.
        public bool PendienteRevision { get; set; } // EXT0_DCONFPENDREVISION: Indica si está pendiente de revisión.
        public string NombreRecepcionista { get; set; } = string.Empty; // EXT0_DCONFNOMBRECLI: Nombre del recepcionista.
        public string DniRecepcionista { get; set; } = string.Empty; // EXT0_DCONFDNICLI: DNI del recepcionista.
        public bool Conforme { get; set; } // EXT0_DSICONFCLI: Indica si el recepcionista está conforme.
        public string MotivoNoConforme { get; set; } = string.Empty; // EXT0_DMOTIVONOCONFCLI: Motivo de no conformidad.

        // Campos adicionales:
        public string ServirHojaRuta { get; set; } = string.Empty; // EXT0_DSERVIRHC: Indica si se puede gestionar el servicio.
        public string HoraDeRuta { get; set; } = string.Empty; // EXT0_DHOJADERUTANUM: Número de hoja de ruta.
        public string LectorCodigoBarras => $"{Serie}/{NumDoc}"; // Campo calculado para el lector de código de barras.
    }
}
