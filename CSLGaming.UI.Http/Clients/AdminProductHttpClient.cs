using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace CSLGaming.UI.Http.Clients
{
    public class AdminProductHttpClient
    {
        private readonly HttpClient _httpClient;
        string _baseAdress = "https://localhost:5500"; // Hämta basadressen som är densamma som api!

        public AdminProductHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"{_baseAdress}/api"); // clientens basadress samma som api.
        }

        public async Task<List<ProductGetDTO>> GetProducts()
        {
            try
            {
                string geturl = "/api/products";

                using HttpResponseMessage response = await _httpClient.GetAsync(geturl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<List<ProductGetDTO>>();

                return result ?? [];
            }
            catch (Exception)
            {
                return [];
                throw;
            }

           
        }

        public async Task DeleteProductAdmin(int id)
        {
            try
            {
                string deleteUrl = $"/api/products/{id}";

                using HttpResponseMessage response = await _httpClient.DeleteAsync(deleteUrl);
            }
            catch (Exception ex)
            {

                throw;
            }

        }   

    }
}
