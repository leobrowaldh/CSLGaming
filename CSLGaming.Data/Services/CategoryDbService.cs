using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLGaming.Data.Services
{
    public class CategoryDbService(CSLGamingContext db, IMapper mapper) : DbService(db, mapper)
    {

        public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
        {
            //IncludeNavigationsFor<Filter>();
            //IncludeNavigationsFor<Product>(); // Detta skall reflektera de many to many props som entiteten har. Inkludera navigations för entititer som finns i denna.
            return await base.GetAsync<TEntity, TDto>();
        }

    }
}
