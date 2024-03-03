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
            //new LinkGroup { Name = "Categories" }
            new LinkGroup()
            {
            Name = "Categories",
            Id = 0,
            LinkOptions= new(){
                new LinkOption { Id = 0, CategoryType = "zero", IsSelected = true },
                new LinkOption { Id = 1, CategoryType = "one", IsSelected = false },
                new LinkOption { Id = 2, CategoryType = "two", IsSelected = false }
                }
            }
        ];

        public async Task GetLinkGroup()
        {
            Categories = await categoryHttpClient.GetCategoriesAsync();
            CategoryLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Categories);
            var linkOption = CategoryLinkGroups[0].LinkOptions.FirstOrDefault();
            linkOption!.IsSelected = true;
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

        #region Local storage

        public async Task<T?> GetLocalStorageAsync<T>(string key) => await localStorageService.GetItemAsync<T>(key);
        public async Task SetLocalStorageAsync<T>(string key, T value) => await localStorageService.SetItemAsync(key, value);
        public async Task RemoveLocalStorageAsync<T>(string key) => await localStorageService.RemoveItemAsync(key);

        #endregion
    }
}
