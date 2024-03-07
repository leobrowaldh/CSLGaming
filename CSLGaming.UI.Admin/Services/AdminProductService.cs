using CSLGaming.API.DTO;
using CSLGaming.UI.Http.Clients;

namespace CSLGaming.UI.Admin.Services
{
    public class AdminProductService
    {
        private readonly AdminProductHttpClient _httpClient;
        private readonly AdminCategoryService _categoryService;
        

        public List<ProductGetDTO> Products { get; set; }

        public List<CategoryGetDTO> Categories { get; set; } = new List<CategoryGetDTO>();

        public List<GenereGetDTO> Generes {  get; set; }

        public List<AgeRestrictionGetDTO> AgeRestrictions { get; set; }

        public AdminProductService(AdminProductHttpClient httpClient, AdminCategoryService categoryService)
        {
                _httpClient = httpClient;
            
            _categoryService = categoryService;
            Categories = _categoryService.Categories;
        }

        public async Task Addproduct(ProductPostDTO product)
        {
            

     
            await _httpClient.AddProduct(product);

        }

        public async Task UpdateConnections(int productId, int CatId,int GenereId)
        {
            await _httpClient.PostProductWithKopplingar(productId, CatId, GenereId);
        }

        public async Task GetAllProducts() => Products = await _httpClient.GetProducts();

        public async Task DeleteProd(int id) => await _httpClient.DeleteProductAdmin(id); 


        
        public async Task GetGeneres()
        {
            try
            {
                Generes = await _httpClient.GetGen();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task GetAgeRestrictions()
        {
            try
            {
                AgeRestrictions = await _httpClient.GetAge();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
