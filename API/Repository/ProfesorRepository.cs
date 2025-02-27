using DesignAPI.Data;
using DesignAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using DesignAPI.Models.Entity;

namespace DesignAPI.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ProfesorCacheKey = "ProfesorCacheKey";
        private readonly int CacheExpirationTime = 3600;

        public ProfesorRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<ICollection<ProfesorEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ProfesorCacheKey, out ICollection<ProfesorEntity> profesoresCached))
                return profesoresCached;

            var profesoresFromDb = await _context.Profesores.OrderBy(p => p.Nombre).ToListAsync();
            _cache.Set(ProfesorCacheKey, profesoresFromDb, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime)));

            return profesoresFromDb;
        }

        public async Task<ProfesorEntity> GetAsync(int id)
        {
            return await _context.Profesores.FirstOrDefaultAsync(p => p.DNI == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Profesores.AnyAsync(p => p.DNI == id);
        }

        public async Task<bool> CreateAsync(ProfesorEntity profesor)
        {
            _context.Profesores.Add(profesor);
            return await Save();
        }

        public async Task<bool> UpdateAsync(ProfesorEntity profesor)
        {
            _context.Profesores.Update(profesor);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profesor = await GetAsync(id);
            if (profesor == null)
                return false;

            _context.Profesores.Remove(profesor);
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
            _cache.Remove(ProfesorCacheKey);
        }
    }
}