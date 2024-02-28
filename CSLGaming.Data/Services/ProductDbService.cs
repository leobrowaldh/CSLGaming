using System.Drawing;

namespace CSLGaming.Data.Services
{
    public class ProductDbService(CSLGamingContext db, IMapper mapper) : DbService(db, mapper)
    {
        private readonly CSLGamingContext _ctx;

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
                .Select(pc => pc.ProductId); // Det är iquierible som gör att man kan bygga ut metoder med extra metoder, läs på om delegates. Den reutneras som en i quieribalbe. Vi hämtar all produvct id med matchande category id
            var products = await GetAsync<Product>(p => productIds.Contains(p.Id)).ToListAsync(); // Här tar vi den skiten och koverterar den till en list.
            return MapList<Product, ProductGetDTO>(products);
        }



        public override Task<ProductGetDTO> SingleAsync<TEntity, ProductGetDTO>(int id)
        {
            IncludeNavigationsFor<AgeRestriction>();
            IncludeNavigationsFor<Genere>();
            IncludeNavigationsFor<Category>();
            
            

            return base.SingleAsync<TEntity, ProductGetDTO>(id);
        }
    }
}
