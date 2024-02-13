﻿

using System.Text.Json;

namespace CSLGaming.UI.Http.Clients;



public class ProductHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAdress = "https://localhost:7042/api"; // Vi ser till att Httplienten delar samma adress osm vårat api

    public ProductHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = (new Uri($"{_baseAdress}/Products"));
    }

    public async Task<List<ProductGetDTO>> GetProductsAsync(int categoryId)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"productsbycategory/{categoryId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<ProductGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            return [];
        }
    }
}
