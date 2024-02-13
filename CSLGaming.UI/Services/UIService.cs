﻿namespace CSLGaming.UI.Services
{
    

    public class UIService(CategoryHttpClient categoryHttp, ProductHttpClient productHttp, IMapper mapper)
    {
        public int CurrentCategoryId { get; set; }

        List<CategoryGetDTO> Categories { get; set; } = [];

        public List<ProductGetDTO> Products { get; set; } = [];

        public List<LinkGroup> CategoryLinkGroups { get; private set; } =
        [
            new LinkGroup { Name = "Categories"
           /* LinkOptions = new(){
                new LinkOption { Id = 1, Name = "Women", IsSelected = true },
                new LinkOption { Id = 2, Name = "Men", IsSelected = false },
                new LinkOption { Id = 3, Name = "Children", IsSelected = false }
            }*/
            }
        ];

        public async Task GetLinkGroup()
        {
            Categories = await categoryHttp.GetCategoriesAsync();
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
       Products = await productHttp.GetProductsAsync(CurrentCategoryId);
    }
}
