

namespace CSLGaming.Data
{
    public class DbService : IDbService
    {
        private readonly CSLGamingContext _context;
        


        public Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class
        {
            throw new NotImplementedException();
        }

        public Task<List<TDto>> GetAsync<TEntity, TDto>()
            where TEntity : class
            where TDto : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDbService.DeleteAsync<TEntity>(int id)
        {
            throw new NotImplementedException();
        }

        Task<TDto> IDbService.SingleAsync<TEntity, TDto>(int id)
        {
            throw new NotImplementedException();
        }

        void IDbService.Update<TEntity, TDto>(TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
