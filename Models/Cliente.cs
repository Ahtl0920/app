using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiApp1.Models
{
    public class Cliente
    {
        public int Id { get; set; } // Identificador único del cliente.
        public string Nombre { get; set; } = string.Empty; // Nombre del cliente.
        public string Direccion { get; set; } = string.Empty; // Dirección del cliente.
        public string Telefono { get; set; } = string.Empty; // Teléfono del cliente.
    }
}
