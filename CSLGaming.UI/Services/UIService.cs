

using CSLGaming.API.DTO;
using CSLGaming.UI.Models.Link;

namespace CSLGaming.UI.Services
{
    

    public class UIService(CategoryHttpClient categoryHttp)
    {
        public int CurrentCategoryId { get; set; }

        List<CategoryGetDTO> Categories { get; set; } = [];

        public List<LinkGroup> CategoryLinkGroups { get; private set; } =
        [
            new LinkGroup { Name = "Categories",
            LinkOptions = new(){
                new LinkOption { Id = 1, Name = "Women", IsSelected = true },
                new LinkOption { Id = 2, Name = "Men", IsSelected = false },
                new LinkOption { Id = 3, Name = "Children", IsSelected = false }
            }
            }
        ];
    }
}
