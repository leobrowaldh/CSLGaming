namespace CSLGaming.Data.Services
{
    public class ProductDbService(CSLGamingContext db, IMapper mapper) : DbService(db, mapper)
    {
        public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
        {
            //IncludeNavigationsFor<Category>();
            //IncludeNavigationsFor<Genere>(); // Detta skall reflektera de many to many props som entiteten har. Inkludera navigations för entititer som finns i denna.
            return await base.GetAsync<TEntity, TDto>();
        }
    }
}
