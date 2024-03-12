using Blazored.LocalStorage;
using System.Xml.Linq;

namespace CSLGaming.UI.Services
{


    public class UIService(CategoryHttpClient categoryHttpClient, ProductHttpClient productHttpClient, IMapper mapper,
        ILocalStorageService localStorageService)
    {
        public int CurrentCategoryId { get; set; }

        public List<CategoryGetDTO> Categories { get; set; } = [];

        public List<ProductGetDTO> Products { get; set; } = [];
        public List<CartDTO> CartItems { get; set; } = [];

        public List<LinkGroup> CategoryLinkGroups { get; private set; } =
        [
            new LinkGroup { Name = "Categories" }
        ];

        public List<ProductGetDTO> TopRatedProducts { get; set; } = [];

        public async Task GetLinkGroup()
        {
            Categories = await categoryHttpClient.GetCategoriesAsync();
            CategoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
            var linkOption = CategoryLinkGroups[0].LinkOptions.FirstOrDefault();
        }

        public async Task OnCategoryLinkClick(int id)
        {
            CurrentCategoryId = id;
            await GetProductsAsync();
            CategoryLinkGroups[0].LinkOptions.ForEach(l => l.IsSelected = false);
            CategoryLinkGroups[0].LinkOptions.Single(l => l.Id.Equals(CurrentCategoryId)).IsSelected = true;
        }

        public async Task GetProductsAsync() =>
        Products = await productHttpClient.GetProductsAsync(CurrentCategoryId);

        public async Task GetTopRatedProductsAsync(int numberOfProducts) =>
            TopRatedProducts = await productHttpClient.GetTopRatedProductsAsync(numberOfProducts);

        #region Local storage

        public async Task GetLocalStorageAsync() => 
            CartItems = await localStorageService.GetItemAsync<List<CartDTO>>("CartItems") ?? [];
       
        public async Task SetLocalStorageAsync() => await localStorageService.SetItemAsync("CartItems", CartItems);
        public async Task RemoveLocalStorageAsync(string key) => await localStorageService.RemoveItemAsync(key);

        #endregion
    }
}
