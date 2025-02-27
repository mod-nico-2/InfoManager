using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DesignAPI.Models.Entity;

namespace DesignAPI.Data
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

        //Add models here
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AlumnoEntity> Alumnos { get; set; }
        public DbSet<DepartamentoEntity> Departamentos { get; set; }
        public DbSet<ProfesorEntity> Profesores { get; set; }
        public DbSet<ProyectoEntity> Proyectos { get; set; }
        public DbSet<ReunionEntity> Reuniones { get; set; }
    }
}
