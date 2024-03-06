using CSLGaming.API.DTO;
using CSLGaming.UI.Http.Clients;

namespace CSLGaming.UI.Admin.Services
{
    public class AdminProductService
    {
        private readonly AdminProductHttpClient _httpClient;

        public List<ProductGetDTO> Products { get; set; }

        public AdminProductService(AdminProductHttpClient httpClient)
        {
                _httpClient = httpClient;
        }

        public async Task GetAllProducts() => Products = await _httpClient.GetProducts();
        
        

    }
}
