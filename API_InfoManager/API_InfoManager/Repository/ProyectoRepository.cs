using API_InfoManager.Data;
using API_InfoManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using API_InfoManager.Models.Entity;

namespace API_InfoManager.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string ProyectoCacheKey = "ProyectoCacheKey";
        private readonly int CacheExpirationTime = 3600;

        public ProyectoRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<ICollection<ProyectoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(ProyectoCacheKey, out ICollection<ProyectoEntity> proyectosCached))
                return proyectosCached;

            var proyectosFromDb = await _context.Proyectos.OrderBy(p => p.Nombre).ToListAsync();
            _cache.Set(ProyectoCacheKey, proyectosFromDb, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime)));

            return proyectosFromDb;
        }

        public async Task<ProyectoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(ProyectoCacheKey, out ICollection<ProyectoEntity> proyectosCached))
            {
                var proyecto = proyectosCached.FirstOrDefault(p => p.ID == id);
                if (proyecto != null)
                    return proyecto;
            }

            return await _context.Proyectos.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Proyectos.AnyAsync(p => p.ID == id);
        }

        public async Task<bool> CreateAsync(ProyectoEntity proyecto)
        {
            _context.Proyectos.Add(proyecto);
            return await Save();
        }

        public async Task<bool> UpdateAsync(ProyectoEntity proyecto)
        {
            _context.Proyectos.Update(proyecto);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var proyecto = await GetAsync(id);
            if (proyecto == null)
                return false;

            _context.Proyectos.Remove(proyecto);
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
            _cache.Remove(ProyectoCacheKey);
        }
    }
}