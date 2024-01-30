﻿

namespace CSLGaming.Data.Services
{
    public class CategoryDbService(CSLGamingContext db, IMapper mapper) : DbService(db, mapper)
    {
        

        private readonly Category _category;

        public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
        {
            //IncludeNavigationsFor<Filter>();
            //IncludeNavigationsFor<Product>(); // Detta skall reflektera de many to many props som entiteten har. Inkludera navigations för entititer som finns i denna.
            return await base.GetAsync<TEntity, TDto>();
        }

        public override async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
        {
            var entity = mapper.Map<TEntity>(dto);
   
            if (entity is Category categoryEntity)
            {
                
                if (!Enum.IsDefined(typeof(enCategory), categoryEntity.CategoryType) ||
                    !Enum.IsDefined(typeof(enOptionType), categoryEntity.OptionType))
                {
                    
                    throw new ArgumentException("Invalid enum values in CategoryType or OptionType");
                }
 
                await db.Set<TEntity>().AddAsync(entity);
            }

            return entity;
        }

    }
}
