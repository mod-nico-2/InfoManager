using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using API_InfoManager.Models.Entity;

namespace API_InfoManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Agregar modelos aquí
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }
        public DbSet<ProfesorEntity> Profesores { get; set; }
        public DbSet<ProyectoEntity> Proyectos { get; set; }
        public DbSet<ReunionEntity> Reuniones { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
