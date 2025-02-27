using DesignAPI.Data;
using DesignAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using DesignAPI.Models.Entity;

namespace DesignAPI.Repository
{
    public class ReunionRepository : IReunionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ReunionCacheKey = "ReunionCacheKey";
        private readonly int CacheExpirationTime = 3600;

        public ReunionRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<ICollection<ReunionEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ReunionCacheKey, out ICollection<ReunionEntity> reunionesCached))
                return reunionesCached;

            var reunionesFromDb = await _context.Reuniones.OrderBy(r => r.Fecha).ToListAsync();
            _cache.Set(ReunionCacheKey, reunionesFromDb, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime)));

            return reunionesFromDb;
        }

        public async Task<ReunionEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(ReunionCacheKey, out ICollection<ReunionEntity> reunionesCached))
            {
                var reunion = reunionesCached.FirstOrDefault(r => r.ID == id);
                if (reunion != null)
                    return reunion;
            }

            return await _context.Reuniones.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Reuniones.AnyAsync(r => r.ID == id);
        }

        public async Task<bool> CreateAsync(ReunionEntity reunion)
        {
            _context.Reuniones.Add(reunion);
            return await Save();
        }

        public async Task<bool> UpdateAsync(ReunionEntity reunion)
        {
            _context.Reuniones.Update(reunion);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reunion = await GetAsync(id);
            if (reunion == null)
                return false;

            _context.Reuniones.Remove(reunion);
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
            _cache.Remove(ReunionCacheKey);
        }
    }
}