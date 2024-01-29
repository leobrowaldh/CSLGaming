using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CSLGaming.Data
{
    public class DbService : IDbService
    {
        private readonly CSLGamingContext _db;
        private readonly IMapper _mapper;


        public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _db.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public bool Delete<TEntity, TDto>(TDto dto)
        where TEntity : class where TDto : class
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                if (entity is null) return false;
                _db.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TDto>> GetAsync<TEntity, TDto>()
            where TEntity : class
            where TDto : class
        {
            var entities = await _db.Set<TEntity>().ToListAsync();
            return _mapper.Map<List<TDto>>(entities);
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
