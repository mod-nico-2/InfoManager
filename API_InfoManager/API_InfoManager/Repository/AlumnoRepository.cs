using API_InfoManager.Data;
using API_InfoManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using API_InfoManager.Models.Entity;

namespace API_InfoManager.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string AlumnoCacheKey = "AlumnoCacheKey";
        private readonly int CacheExpirationTime = 3600;

        public AlumnoRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<ICollection<AlumnoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(AlumnoCacheKey, out ICollection<AlumnoEntity> alumnosCached))
                return alumnosCached;

            var alumnosFromDb = await _context.Alumnos.OrderBy(a => a.Nombre).ToListAsync();
            _cache.Set(AlumnoCacheKey, alumnosFromDb, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime)));

            return alumnosFromDb;
        }

        public async Task<AlumnoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(AlumnoCacheKey, out ICollection<AlumnoEntity> alumnosCached))
            {
                var alumno = alumnosCached.FirstOrDefault(a => a.DNI == id);
                if (alumno != null)
                    return alumno;
            }

            return await _context.Alumnos.FirstOrDefaultAsync(a => a.DNI == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Alumnos.AnyAsync(a => a.DNI == id);
        }

        public async Task<bool> CreateAsync(AlumnoEntity alumno)
        {
            _context.Alumnos.Add(alumno);
            return await Save();
        }

        public async Task<bool> UpdateAsync(AlumnoEntity alumno)
        {
            _context.Alumnos.Update(alumno);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alumno = await GetAsync(id);
            if (alumno == null)
                return false;

            _context.Alumnos.Remove(alumno);
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
            _cache.Remove(AlumnoCacheKey);
        }
    }
}