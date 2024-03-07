using CSLGaming.API.DTO;
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

        public async Task AddProduct(ProductPostDTO product)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _httpClient.PostAsync("/api/products", jsonContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task PostProductWithKopplingar(int ProductId, int CatId, int GenereId)
        {
            

            ProductCategoryPostDTO ProductCategory = new()
            {
                ProductId = ProductId,
                CategoryId = CatId
            };

            ProductGenerePostDTO ProductGenere = new() { GenereId = GenereId, ProductId = ProductId };

            

            try
            {
                
                
                var jsonContentC = new StringContent(JsonSerializer.Serialize(ProductCategory), Encoding.UTF8, "application/json");

                using HttpResponseMessage responseC = await _httpClient.PostAsync("/api/categoryproducts", jsonContentC);
                responseC.EnsureSuccessStatusCode();

                var jsonContentG = new StringContent(JsonSerializer.Serialize(ProductGenere), Encoding.UTF8, "application/json");

                using HttpResponseMessage responseG = await _httpClient.PostAsync("/api/genereproducts", jsonContentG);
                responseG.EnsureSuccessStatusCode();



            }
            catch (Exception ex)
            {

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


        public async Task <List<GenereGetDTO>> GetGen()
        {
            try
            {
                string geturl = "/api/Generes";

                using HttpResponseMessage response = await _httpClient.GetAsync(geturl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<List<GenereGetDTO>>();

                return result ?? [];
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<List<AgeRestrictionGetDTO>> GetAge()
        {
            try
            {
                string geturl = "/api/Generes";

                using HttpResponseMessage response = await _httpClient.GetAsync(geturl);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<List<AgeRestrictionGetDTO>>();

                return result ?? [];
            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}
