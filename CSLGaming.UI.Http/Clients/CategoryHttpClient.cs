

using System.Text.Json;

namespace CSLGaming.UI.Http.Clients;



public class CategoryHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAdress = "https://localhost:7042/api"; // Vi ser till att Httplienten delar samma adress osm vårat api

    public CategoryHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = (new Uri($"{_baseAdress}/categorys"));
    }

    public async Task<List<CategoryGetDTO>> GetCategoriesAsync()
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(""); // Detta funkar som en Irseult, ger felmeddelande 404 bla bla bla
            response.EnsureSuccessStatusCode(); // Denna gör att att koderna bara kör vidare ifall den är inom 200 spannet, basically OK meddelanden.
                                                // Om den inte är det, så säger den att den skall till exceptionet och returnerar en tom lista
                                                // Då 404 är valid vanligtvist, så hade den kört vidare utan en exception, men nu krävar vi 200 meddelanden är det enda som tillåts,
                                                // allt annat är exceptions. 

            var result = JsonSerializer.Deserialize<List<CategoryGetDTO>>(await response.Content.ReadAsStreamAsync(), // Denna gör att datat som varibeln får, istället för att sparas, streamas för att spara resurser. Ifall man har många kategorier. I en json
               new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); // Detta gör man för att data i c# använder stora bokstäver i början (pascal) så ser den till att ta hänsyn till det (json filen) annars kan man förlora eller få fel, då json inte kommer känna igen med stora bokstäver i början.

            return result ?? [];
        }
        catch (Exception ex)
        {

            return [];
        }
    }
}
