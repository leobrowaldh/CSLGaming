using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSLGaming.UI.Http.Clients
{
    public class AdminCategoryClient
    {
        private readonly HttpClient _httpClient;
        string _baseAdress = "https://localhost:7042";

        public AdminCategoryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"{_baseAdress}/api");
        }

        public async Task AddAdminCategory(CategoryPostDTO categoryPostDTO)
        {
            try
            {
                // Serialize the CategoryPostDTO object to JSON and send it in the request body
                var jsonContent = new StringContent(JsonSerializer.Serialize(categoryPostDTO), Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _httpClient.PostAsync("api/categorys", jsonContent);
                response.EnsureSuccessStatusCode();

                
                
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if necessary
                throw;
            }
        }

        public async Task DeleteAdminCategory(int categoryId)
        {
            try
            {
                // Construct the endpoint URL for the specific category
                string deleteUrl = $"/api/categorys/{categoryId}";

                // Send the DELETE request to the API
                using HttpResponseMessage response = await _httpClient.DeleteAsync(deleteUrl);
                response.EnsureSuccessStatusCode();

                // Optionally handle the response content if needed
                // var result = await response.Content.ReadFromJsonAsync<ResponseType>();
            }
            catch (Exception ex)
            {
                // Log or inspect the exception details
                Console.WriteLine($"Exception during category deletion: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                // Rethrow the exception if necessary
                throw;
            }

        }

        public async Task<List<CategoryGetDTO>> GetAdminCategories()
        {
            try
            {
                // Construct the endpoint URL for retrieving all categories
                string getUrl = "/api/categorys";

                // Perform the GET request using getUrl
                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();

                // Deserialize the response body to get the list of categories
                var result = await response.Content.ReadFromJsonAsync<List<CategoryGetDTO>>();

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if necessary
                throw;
            }
        }

        public async Task<CategoryGetDTO> GetAdminCategory(int id)
        {
            try
            {
                // Construct the endpoint URL for retrieving all categories
                string getUrl = $"/api/categorys/{id}";

                // Perform the GET request using getUrl
                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();

                // Deserialize the response body to get the list of categories
                var result = await response.Content.ReadFromJsonAsync<CategoryGetDTO>();

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if necessary
                throw;
            }
        }

        public async Task<CategoryPutDTO> GetAdminCategoryToUpdate(int id)
        {
            try
            {
                // Construct the endpoint URL for retrieving all categories
                string getUrl = $"/api/categorys/{id}";

                // Perform the GET request using getUrl
                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();

                // Deserialize the response body to get the list of categories
                var result = await response.Content.ReadFromJsonAsync<CategoryGetDTO>();

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if necessary
                throw;
            }
        }



        public async Task UpdateAdminCategory(int id, CategoryPutDTO catUpdate)
        {
            try
            {
                string putUrl = $"/api/categorys/{id}";

                // Serialize the CategoryPutDTO object to JSON and send it in the request body
                var jsonContent = new StringContent(JsonSerializer.Serialize(catUpdate), Encoding.UTF8, "application/json");

                // Send the updated data to the server
                using HttpResponseMessage response = await _httpClient.PutAsync(putUrl, jsonContent);
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if necessary
                throw;
            }
        }


    }

    
}
