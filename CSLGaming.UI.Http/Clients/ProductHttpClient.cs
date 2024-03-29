﻿

using System.Text.Json;

namespace CSLGaming.UI.Http.Clients;



public class ProductHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAdress = "https://localhost:5500/api"; // Vi ser till att Httplienten delar samma adress osm vårat api

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
            string relativePath = $"{_httpClient.BaseAddress}bycategory/{categoryId}";
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

    public async Task<List<ProductGetDTO>> GetTopRatedProductsAsync(int numberOfProducts)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"{_httpClient.BaseAddress}/toprated/{numberOfProducts}";
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

    public async Task<ProductGetDTO> GetProductByName(string ProductName)
    {
        try
        {
            string relativePath = $"{_httpClient.BaseAddress}/productname/{ProductName}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();
            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<ProductGetDTO>(resultStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;

        }
        catch (Exception)
        {

            return null;
        }
    }
}
