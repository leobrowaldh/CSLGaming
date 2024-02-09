

namespace CSLGaming.UI.Http.Clients;



public class CategoryHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAdress = "https://localhost:7042/api"; // Vi ser till att Httplienten delar samma adress osm vårat api

    public CategoryHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = (new Uri($"{_baseAdress}/categories"));
    }
}
