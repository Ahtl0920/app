using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MauiApp1.Models;

namespace MauiApp1.Services
{
    public class BackendService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://tu-backend-url.com/api"; // Reemplazar con la URL del backend

        public BackendService()
        {
            _httpClient = new HttpClient();
        }

        //  Métodos para Albaranes
        public async Task<List<Albaran>> GetAlbaranesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Albaran>>($"{BaseUrl}/albaranes") ?? new List<Albaran>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo albaranes: {ex.Message}");
                return new List<Albaran>();
            }
        }

        // ✅ Nuevo método para obtener un albarán por Serie y Número de Documento
        public async Task<Albaran?> GetAlbaranBySerieAndNumAsync(string serie, int numDoc)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Albaran>($"{BaseUrl}/albaranes/serie/{serie}/num/{numDoc}") ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo albarán Serie: {serie} NumDoc: {numDoc} -> {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateAlbaranAsync(Albaran albaran)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/albaranes/{albaran.Id}", albaran);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando albarán {albaran.Id}: {ex.Message}");
                return false;
            }
        }

        //  Métodos para Clientes
        public async Task<List<Cliente>> GetClientesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cliente>>($"{BaseUrl}/clientes") ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo clientes: {ex.Message}");
                return new List<Cliente>();
            }
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cliente>($"{BaseUrl}/clientes/{id}") ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo cliente {id}: {ex.Message}");
                return null;
            }
        }

        //  Métodos para Líneas de Albarán
        public async Task<List<LineaAlbaran>> GetLineasByAlbaranIdAsync(int albaranId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<LineaAlbaran>>($"{BaseUrl}/lineas/{albaranId}") ?? new List<LineaAlbaran>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo líneas del albarán {albaranId}: {ex.Message}");
                return new List<LineaAlbaran>();
            }
        }

        public async Task<bool> UpdateLineaAlbaranAsync(LineaAlbaran linea)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/lineas/{linea.Id}", linea);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando línea {linea.Id}: {ex.Message}");
                return false;
            }
        }

        //  Métodos para Mercancía
        public async Task<List<Mercancia>> GetMercanciasAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Mercancia>>($"{BaseUrl}/mercancias") ?? new List<Mercancia>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo mercancías: {ex.Message}");
                return new List<Mercancia>();
            }
        }

        public async Task<Mercancia?> GetMercanciaByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Mercancia>($"{BaseUrl}/mercancias/{id}") ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo mercancía {id}: {ex.Message}");
                return null;
            }
        }

        //  Métodos para Repartidores
        public async Task<List<Repartidor>> GetRepartidoresAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Repartidor>>($"{BaseUrl}/repartidores") ?? new List<Repartidor>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo repartidores: {ex.Message}");
                return new List<Repartidor>();
            }
        }
    }
}
