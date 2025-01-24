/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/


using Microsoft.EntityFrameworkCore;
using MauiApp1.Data;
using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class LineaAlbaranService
    {
        private readonly AppDbContext _context; // Contexto de la base de datos.

        public LineaAlbaranService(AppDbContext context)
        {
            _context = context; // Inicializa el contexto inyectado.
        }

        // Obtiene todas las líneas de un albarán específico por su ID.
        public async Task<List<LineaAlbaran>> GetLineasByAlbaranIdAsync(int albaranId)
        {
            return await _context.LineasAlbaranes
                .Where(l => l.AlbaranId == albaranId) // Filtra por ID de albarán.
                .Select(l => new LineaAlbaran
                {
                    Id = l.Id,
                    AlbaranId = l.AlbaranId,
                    CodigoArticulo = l.CodigoArticulo,
                    Unidades = l.Unidades,
                    Estado = l.Estado,
                    Marca = l.Marca,
                    Modelo = l.Modelo,
                    Referencia = l.Referencia,
                    Bultos = l.Bultos,
                    Largo = l.Largo,
                    Ancho = l.Ancho,
                    Alto = l.Alto,
                    Peso = l.Peso,
                    Contenido = l.Contenido,
                    NumeroSerie = l.NumeroSerie
                })
                .ToListAsync(); // Convierte el resultado en una lista.
        }

        // Obtiene las líneas de un albarán que cumplen con la condición de componente "T".
        public async Task<List<LineaAlbaran>> GetLineasByComponentAsync(int albaranId)
        {
            return await _context.LineasAlbaranes
                .Where(l => l.AlbaranId == albaranId && l.Contenido == "T") // Filtra por componente "T".
                .Select(l => new LineaAlbaran
                {
                    Id = l.Id,
                    AlbaranId = l.AlbaranId,
                    CodigoArticulo = l.CodigoArticulo,
                    Unidades = l.Unidades,
                    Estado = l.Estado,
                    Marca = l.Marca,
                    Modelo = l.Modelo,
                    Referencia = l.Referencia,
                    Bultos = l.Bultos,
                    Largo = l.Largo,
                    Ancho = l.Ancho,
                    Alto = l.Alto,
                    Peso = l.Peso,
                    Contenido = l.Contenido,
                    NumeroSerie = l.NumeroSerie
                })
                .ToListAsync();
        }

        // Obtiene líneas específicas relacionadas con destino.
        public async Task<List<LineaAlbaran>> GetLineasDestinoAsync(int albaranId)
        {
            return await _context.LineasAlbaranes
                .Where(l => l.AlbaranId == albaranId) // Filtra por ID de albarán.
                .Select(l => new LineaAlbaran
                {
                    Id = l.Id,
                    AlbaranId = l.AlbaranId,
                    CodigoArticulo = l.CodigoArticulo,
                    Unidades = l.Unidades,
                    Estado = l.Estado, // Ejemplo: embalado, protegido, etc.
                    Marca = l.Marca,
                    Modelo = l.Modelo,
                    Referencia = l.Referencia,
                    Bultos = l.Bultos,
                    Largo = l.Largo,
                    Ancho = l.Ancho,
                    Alto = l.Alto,
                    Peso = l.Peso,
                    Contenido = l.Contenido,
                    NumeroSerie = l.NumeroSerie // Identificador único de serie.
                })
                .ToListAsync();
        }

        // Actualiza información de una línea de albarán específica.
        public async Task<bool> UpdateLineaAlbaranAsync(int lineaId, LineaAlbaran updatedData)
        {
            var linea = await _context.LineasAlbaranes.FindAsync(lineaId);

            if (linea == null) return false;

            // Actualiza los campos de la línea de albarán.
            linea.Estado = updatedData.Estado;
            linea.Marca = updatedData.Marca;
            linea.Modelo = updatedData.Modelo;
            linea.Referencia = updatedData.Referencia;
            linea.Bultos = updatedData.Bultos;
            linea.Largo = updatedData.Largo;
            linea.Ancho = updatedData.Ancho;
            linea.Alto = updatedData.Alto;
            linea.Peso = updatedData.Peso;
            linea.Contenido = updatedData.Contenido;
            linea.NumeroSerie = updatedData.NumeroSerie;

            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
            return true;
        }

        // Elimina una línea de albarán por su ID.
        public async Task<bool> DeleteLineaAlbaranAsync(int lineaId)
        {
            var linea = await _context.LineasAlbaranes.FindAsync(lineaId);

            if (linea == null) return false;

            _context.LineasAlbaranes.Remove(linea); // Elimina la línea.
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
