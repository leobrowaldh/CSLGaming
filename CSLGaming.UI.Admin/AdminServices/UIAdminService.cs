using CSLGaming.API.DTO;
using CSLGaming.UI.Http;
using CSLGaming.UI.Http.Clients;


namespace CSLGaming.UI.Admin.AdminServices
{
    public class UIAdminService
    {
        private readonly AdminCategoryClient _catAdminClient;

        public List<CategoryGetDTO> Categories { get; set; }

        public CategoryPutDTO CategoryToUpdate { get; set; }

        public UIAdminService(AdminCategoryClient catAdminClient)
        {
            _catAdminClient = catAdminClient;
        }

        public async Task AddAdminCategory(string categoryName)
        {
            // Assuming your CategoryPostDTO has a property named 'CategoryType'
            CategoryPostDTO cat = new CategoryPostDTO
            {
                CategoryType = categoryName
            };

            await _catAdminClient.AddAdminCategory(cat);
        }

        public async Task DeleteAdminCategory(int catId)
        {
            await _catAdminClient.DeleteAdminCategory(catId);
        }

        public async Task AdminGetAllCategories() => Categories = await _catAdminClient.GetAdminCategories();

        public async Task GetAdminCategory(int categoryId)
        {
            Categories = new List<CategoryGetDTO> { await _catAdminClient.GetAdminCategory(categoryId) }; // Update the list with a single item
        }

        public async Task GetAdminCategoryUpdate(int id) => CategoryToUpdate = await _catAdminClient.GetAdminCategoryToUpdate(id);

        public async Task UpdateAdminCategory(int id, CategoryPutDTO cat)
        {
            if (CategoryToUpdate != null)
            {
                // Assuming CategoryToUpdate has been modified based on user input
                await _catAdminClient.UpdateAdminCategory(CategoryToUpdate.Id, CategoryToUpdate);
            }
        }
    }
}
