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

        public UIAdminService(AdminCategoryClient catAdminClient) // Vi vill använda en instans hela tiden, därför injeserar vi en instans (singleton i dettafall) så att en ny instans inte skapas varje gång vi kallar denna klass. Vi injeserar den som redan körs sålänge programmet körs. 
        {
            _catAdminClient = catAdminClient; 
        }

        public async Task AddAdminCategory(string categoryName)
        {
            // Argument string som skall reflektera namn på kategorin.
            CategoryPostDTO cat = new CategoryPostDTO
            {
                CategoryType = categoryName // Sätt objektets namn i en instans av CategoryDto
            };

            await _catAdminClient.AddAdminCategory(cat); // Skicka in den som argument
        }

        public async Task DeleteAdminCategory(int catId)
        {
            await _catAdminClient.DeleteAdminCategory(catId);
        }

        public async Task AdminGetAllCategories() => Categories = await _catAdminClient.GetAdminCategories();

        public async Task GetAdminCategory(int categoryId)
        {
            Categories = new List<CategoryGetDTO> { await _catAdminClient.GetAdminCategory(categoryId) }; // Återanvände listan för att spara en kategory, vet inte om detta är bra!
        }

        public async Task GetAdminCategoryUpdate(int id) => CategoryToUpdate = await _catAdminClient.GetAdminCategoryToUpdate(id); // Hämta kategorin, som skall uppdateras.

        public async Task UpdateAdminCategory(int id, CategoryPutDTO cat)
        {
            if (CategoryToUpdate != null)
            {
                // Assuming CategoryToUpdate has been modified based on user input
                await _catAdminClient.UpdateAdminCategory(CategoryToUpdate.Id, CategoryToUpdate); // Här uppdateras den sen.
            }
        }
    }
}
