namespace CSLGaming.UI.Services
{
    

    public class UIService(CategoryHttpClient categoryHttpClient, ProductHttpClient productHttpClient, IMapper mapper)
    {
        public int CurrentCategoryId { get; set; }

        public List<CategoryGetDTO> Categories { get; set; } = [];

        public List<ProductGetDTO> Products { get; set; } = [];

        public List<LinkGroup> CategoryLinkGroups { get; private set; } =
        [
            new LinkGroup { Name = "Categories" }
        ];

        public async Task GetIdByName(string categoryName)
        {
            if (Categories == null || Categories.Count == 0)
            {
               Categories = await categoryHttpClient.GetCategoriesAsync();
            }

            var category = Categories.FirstOrDefault(c => c.CategoryType.Equals(categoryName));

            if (category != null)
            {
                CurrentCategoryId = category.Id;
            }

            else
            {
                return;
            }

            
        }

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

        public async Task GetProductsByNameAsync(string productName)
        {
            Products = await productHttpClient.GetAllProductsAsync();
            Products = Products.Where(p => p.Name != null && p.Name.Equals(productName)).ToList();
        }

        public async Task GetProductsByGenereAsync(string productGenere)
        {
            Products = await productHttpClient.GetAllProductsAsync();
            Products = Products
                .Where(p => p.Generes != null && p.Generes.Any(g => g.GenereType != null && g.GenereType.Equals(productGenere)))
                .ToList();
        }




    }
}
