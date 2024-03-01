namespace CSLGaming.UI.Services
{


    public class UIService(CategoryHttpClient categoryHttpClient, ProductHttpClient productHttpClient, IMapper mapper)
    {
        public int CurrentCategoryId { get; set; }

        public List<CategoryGetDTO> Categories { get; set; } = [];

        public List<ProductGetDTO> Products { get; set; } = [];

        public List<LinkGroup> CategoryLinkGroups { get; private set; } =
        [
            new LinkGroup()
            {
            Name = "Category",
            Id = 1,
            LinkOptions= new(){
                new LinkOption { Id = 1, CategoryType = "Women", IsSelected = true },
                new LinkOption { Id = 2, CategoryType = "Men", IsSelected = false },
                new LinkOption { Id = 3, CategoryType = "Children", IsSelected = false }
                }
            },
            new LinkGroup()
            {
            Name = "Games",
            Id =2,
            LinkOptions= new(){
                new LinkOption { Id = 1, CategoryType = "Women", IsSelected = true },
                new LinkOption { Id = 2, CategoryType = "Men", IsSelected = false },
                new LinkOption { Id = 3, CategoryType = "Children", IsSelected = false }
                }
            },
            new LinkGroup()
            {
            Name = "Genere",
            Id =3,
            LinkOptions= new(){
                new LinkOption { Id = 1, CategoryType = "Women", IsSelected = true },
                new LinkOption { Id = 2, CategoryType = "Men", IsSelected = false },
                new LinkOption { Id = 3, CategoryType = "Children", IsSelected = false }
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
    }
}
