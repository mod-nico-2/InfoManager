using API_InfoManager.Data;
using API_InfoManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using API_InfoManager.Models.Entity;

namespace API_InfoManager.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string DepartamentoCacheKey = "DepartamentoCacheKey";
        private readonly int CacheExpirationTime = 3600;

        public DepartamentoRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<ICollection<DepartamentoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(DepartamentoCacheKey, out ICollection<DepartamentoEntity> departamentosCached))
                return departamentosCached;

            var departamentosFromDb = await _context.Departamentos.OrderBy(d => d.Nombre).ToListAsync();
            _cache.Set(DepartamentoCacheKey, departamentosFromDb, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime)));

            return departamentosFromDb;
        }

        public async Task<DepartamentoEntity> GetAsync(int id)
        {
            return await _context.Departamentos.FirstOrDefaultAsync(d => d.ID == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Departamentos.AnyAsync(d => d.ID == id);
        }

        public async Task<bool> CreateAsync(DepartamentoEntity departamento)
        {
            _context.Departamentos.Add(departamento);
            return await Save();
        }

        public async Task<bool> UpdateAsync(DepartamentoEntity departamento)
        {
            _context.Departamentos.Update(departamento);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var departamento = await GetAsync(id);
            if (departamento == null)
                return false;

            _context.Departamentos.Remove(departamento);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(DepartamentoCacheKey);
        }
    }
}