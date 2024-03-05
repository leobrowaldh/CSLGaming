using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSLGaming.UI.Http.Clients
{
    public class AdminCategoryHttpClient
    {
        private readonly HttpClient _httpClient;
        string _baseAdress = "https://localhost:7042"; // Hämta basadressen som är densamma som api!

        public AdminCategoryHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"{_baseAdress}/api"); // clientens basadress samma som api.
        }

        public async Task AddAdminCategory(CategoryPostDTO categoryPostDTO)
        {
            try
            {
                // Serialisera catagegorypost dto till Json, så apit httpclient kan ta emot och sedan göra samma sak för att lägga till den till databasen.
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
                // Matcha APIs url för att kunna deleta. Skicka in Idt så den skall veta vilken den skall ta bort.
                string deleteUrl = $"/api/categorys/{categoryId}";

                // Vi använder oss av _httpvlient som vars basadress är vårat api, och skicka med den nya strängen så den använder cataegory/delete med id, så den kan veta vilken den skall ta bort.
                using HttpResponseMessage response = await _httpClient.DeleteAsync(deleteUrl);
                response.EnsureSuccessStatusCode();


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
                // Använder oss av api url för att hämta alla kategorier.
                string getUrl = "/api/categorys";

                // Använder den url, läger den inom get metoden så den skall veta vilken basadress + delen i url som är för att getta.
                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();

                // Ta den i jsonformat, mappa tillbaka den till en Lista av catgetdto
                var result = await response.Content.ReadFromJsonAsync<List<CategoryGetDTO>>();

                return result ?? []; // returnera resultatet, ifall den ör null tom lista.
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Could'nt get Category");

                return [];
                throw;
            }
        }

        public async Task<CategoryGetDTO> GetAdminCategory(int id)
        {
            try
            {
                // Lägg url för att hämta en category i API
                string getUrl = $"/api/categorys/{id}";

                // Samma princip som ovan
                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();

                // Deserialisera json till en CatGetDto
                var result = await response.Content.ReadFromJsonAsync<CategoryGetDTO>();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CategoryPutDTO> GetAdminCategoryToUpdate(int id)
        {
            try
            {
                // Samma som ovan, kanske bör ta bort denna
                string getUrl = $"/api/categorys/{id}";


                using HttpResponseMessage response = await _httpClient.GetAsync(getUrl);
                response.EnsureSuccessStatusCode();


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
                // Samma som add, fast skall upddatera
                string putUrl = $"/api/categorys/{id}";

                // Serialisera DTO objektet till en Json, kolla upp exakt vad Encodingen gör och json/application gör!
                var jsonContent = new StringContent(JsonSerializer.Serialize(catUpdate), Encoding.UTF8, "application/json");

                // Använd urlen och JsonContenten för att kunna uppdatera via apit som sen skickas till db.
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
