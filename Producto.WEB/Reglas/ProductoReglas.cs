using Abstracciones.Modelos;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class ProductoReglas
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductoReglas(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        private string BaseUrl()
        {
            return _configuration["ApiProductos"];
        }

        public async Task<List<ProductoResponse>> Obtener()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductoResponse>>(BaseUrl() + "Producto");
        }

        public async Task<ProductoResponse> Obtener(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductoResponse>(BaseUrl() + $"Producto/{id}");
        }

        public async Task Agregar(ProductoRequest producto)
        {
            await _httpClient.PostAsJsonAsync(BaseUrl() + "Producto", producto);
        }

        public async Task Editar(Guid id, ProductoRequest producto)
        {
            await _httpClient.PutAsJsonAsync(BaseUrl() + $"Producto/{id}", producto);
        }

        public async Task Eliminar(Guid id)
        {
            await _httpClient.DeleteAsync(BaseUrl() + $"Producto/{id}");
        }
    }
}