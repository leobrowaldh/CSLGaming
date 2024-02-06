using System.Drawing;

namespace CSLGaming.Data.Services
{
    public class ProductDbService(CSLGamingContext db, IMapper mapper) : DbService(db, mapper)
    {
        public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
        {

            IncludeNavigationsFor<AgeRestriction>();
            IncludeNavigationsFor<Genere>();
            IncludeNavigationsFor<Category>();
            return await base.GetAsync<TEntity, TDto>();
        }

        public async Task<List<ProductGetDTO>> GetProductsByCategoryAsync(int categoryId)
        {
            IncludeNavigationsFor<AgeRestriction>();
            IncludeNavigationsFor<Genere>();
            var productIds = GetAsync<CategoryProduct>(pc => pc.CategoryId.Equals(categoryId))
                .Select(pc => pc.ProductId);
            var products = await GetAsync<Product>(p => productIds.Contains(p.Id)).ToListAsync();
            return MapList<Product, ProductGetDTO>(products);
        }
    }
}
