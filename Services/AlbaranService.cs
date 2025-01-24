/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/


using Microsoft.EntityFrameworkCore; // Importa las herramientas de Entity Framework Core.
using MauiApp1.Data; // Contexto de base de datos.
using MauiApp1.Models; // Modelos del proyecto.

namespace MauiApp1.Services // Espacio de nombres del servicio.
{
    // Servicio para gestionar operaciones relacionadas con los albaranes.
    public class AlbaranService
    {
        private readonly AppDbContext _context; // Contexto de base de datos.

        // Constructor que recibe el contexto a través de inyección de dependencias.
        public AlbaranService(AppDbContext context)
        {
            _context = context;
        }

        // Obtiene un albarán específico con datos de origen y destino.
        public async Task<Albaran?> GetAlbaranDestinoAsync(string serie, int numDoc)
        {
            return await _context.Albaranes
                .Where(a => a.Serie == serie && a.NumDoc == numDoc)
                .Select(a => new Albaran
                {
                    Id = a.Id, // IDALBV
                    Serie = a.Serie, // SERIE
                    NumDoc = a.NumDoc, // NUMDOC

                    // Datos de origen:
                    CodRemitente = a.CodRemitente,
                    RazonRemitente = a.RazonRemitente,
                    Observaciones = a.Observaciones,
                    FechaEfecto = a.FechaEfecto,
                    HoraLlegada = a.HoraLlegada,
                    HoraSalida = a.HoraSalida,
                    HoraLlegada2 = a.HoraLlegada2,
                    HoraSalida2 = a.HoraSalida2,

                    // Datos de destino:
                    TipoServicio = a.TipoServicio,
                    TipoTransporte = a.TipoTransporte,
                    Destinatario = a.Destinatario,
                    Poblacion = a.Poblacion,
                    Provincia = a.Provincia,
                    DocCliente = a.DocCliente,
                    Operarios = a.Operarios,
                    MediosEspeciales = a.MediosEspeciales,
                    Vehiculo = a.Vehiculo,
                    Semirremolque = a.Semirremolque,
                    DcFirmada = a.DcFirmada,
                    DcSellada = a.DcSellada,
                    PendienteRevision = a.PendienteRevision,
                    NombreRecepcionista = a.NombreRecepcionista,
                    DniRecepcionista = a.DniRecepcionista,
                    Conforme = a.Conforme,
                    MotivoNoConforme = a.MotivoNoConforme,
                    ServirHojaRuta = a.ServirHojaRuta,
                    HoraDeRuta = a.HoraDeRuta
                })
                .FirstOrDefaultAsync();
        }



        // Obtiene un albarán específico con datos de origen.
        public async Task<Albaran?> GetAlbaranOrigenAsync(string serie, int numDoc)
        {
            return await _context.Albaranes
                .Where(a => a.Serie == serie && a.NumDoc == numDoc)
                .Select(a => new Albaran
                {
                    Id = a.Id, // IDALBV
                    Serie = a.Serie, // SERIE
                    NumDoc = a.NumDoc, // NUMDOC

                    // Datos de origen:
                    CodRemitente = a.CodRemitente,
                    RazonRemitente = a.RazonRemitente,
                    Observaciones = a.Observaciones,
                    FechaEfecto = a.FechaEfecto,
                    HoraLlegada = a.HoraLlegada,
                    HoraSalida = a.HoraSalida,
                    HoraLlegada2 = a.HoraLlegada2,
                    HoraSalida2 = a.HoraSalida2,
                    Operarios = a.Operarios,
                    MediosEspeciales = a.MediosEspeciales,
                    Vehiculo = a.Vehiculo,
                    Semirremolque = a.Semirremolque,
                    DcFirmada = a.DcFirmada,
                    NombreRecepcionista = a.NombreRecepcionista,
                    DniRecepcionista = a.DniRecepcionista,
                    Conforme = a.Conforme,
                    MotivoNoConforme = a.MotivoNoConforme
                })
                .FirstOrDefaultAsync();
        }





        // Actualiza los datos específicos de destino en un albarán.
        public async Task<bool> UpdateAlbaranDestinoAsync(int albaranId, Albaran updatedData)
        {
            var albaran = await _context.Albaranes.FindAsync(albaranId);

            if (albaran == null) return false;

            // Actualiza los campos de destino.
            albaran.TipoServicio = updatedData.TipoServicio;
            albaran.TipoTransporte = updatedData.TipoTransporte;
            albaran.Destinatario = updatedData.Destinatario;
            albaran.Poblacion = updatedData.Poblacion;
            albaran.Provincia = updatedData.Provincia;
            albaran.DocCliente = updatedData.DocCliente;
            albaran.HoraLlegada = updatedData.HoraLlegada;
            albaran.HoraSalida = updatedData.HoraSalida;
            albaran.HoraLlegada2 = updatedData.HoraLlegada2;
            albaran.HoraSalida2 = updatedData.HoraSalida2;
            albaran.Operarios = updatedData.Operarios;
            albaran.MediosEspeciales = updatedData.MediosEspeciales;
            albaran.Vehiculo = updatedData.Vehiculo;
            albaran.Semirremolque = updatedData.Semirremolque;
            albaran.DcFirmada = updatedData.DcFirmada;
            albaran.DcSellada = updatedData.DcSellada;
            albaran.PendienteRevision = updatedData.PendienteRevision;
            albaran.NombreRecepcionista = updatedData.NombreRecepcionista;
            albaran.DniRecepcionista = updatedData.DniRecepcionista;
            albaran.Conforme = updatedData.Conforme;
            albaran.MotivoNoConforme = updatedData.MotivoNoConforme;

            await _context.SaveChangesAsync(); // Guarda los cambios.
            return true;
        }

        // Valida si un albarán está listo para ser modificado.
        public async Task<bool> IsAlbaranEditableAsync(string serie, int numDoc)
        {
            var albaran = await _context.Albaranes
                .FirstOrDefaultAsync(a => a.Serie == serie && a.NumDoc == numDoc);

            return albaran != null && albaran.ServirHojaRuta == "T";
        }

        // Obtiene todos los albaranes pendientes.
        public async Task<List<Albaran>> GetPendingAlbaranesAsync()
        {
            return await _context.Albaranes
                .Where(a => a.ServirHojaRuta != "T") // Condición para pendientes.
                .ToListAsync();
        }
    }
}
