using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;

namespace WebApiKalum
{
    public class KalumDbContext : DbContext
    {
        public DbSet<CarreraTecnica> CarreraTecnica {get;set;}
        public DbSet<Jornada> Jornda {get;set;}
        public DbSet<Aspirante> Aspirante {get;set;}
        public DbSet<ExamenAdmision> ExamenAdminision {get;set;}
        public DbSet<Inscripcion> Inscripcion {get;set;}
        public DbSet<Alumno> Alumno {get;set;}
        public DbSet<Cargo> Cargo {get;set;}
        
        public KalumDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarreraTecnica>().ToTable("CarreraTecnica").HasKey(ct => new {ct.CarreraId});
            modelBuilder.Entity<Jornada>().ToTable("Jornada").HasKey(j => new {j.JornadaId});
            modelBuilder.Entity<ExamenAdmision>().ToTable("ExamenAdminision").HasKey(ex => new {ex.ExamenId});
            modelBuilder.Entity<Aspirante>().ToTable("Aspirante").HasKey(a => new {a.NoExpediente});
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripcion").HasKey(i => new {i.InscripcionId});
            modelBuilder.Entity<Alumno>().ToTable("Alumno").HasKey(a => new {a.Carne});
            modelBuilder.Entity<Cargo>().ToTable("Cargo").HasKey(c => c.CargoId);

           modelBuilder.Entity<Aspirante>()
                .HasOne<CarreraTecnica>( a => a.CarreraTecnica)
                .WithMany(ct => ct.Aspirantes)
                .HasForeignKey(c => c.CarreraId);
            
            modelBuilder.Entity<Aspirante>()
                .HasOne<Jornada>(aspirante => aspirante.Jornada)
                .WithMany(jornada => jornada.Aspirantes)
                .HasForeignKey(a => a.JornadaId);

            modelBuilder.Entity<Aspirante>()
                .HasOne<ExamenAdmision>(a => a.ExamenAdmision)
                .WithMany(ex => ex.Aspirante)
                .HasForeignKey(a => a.ExamenId);

            modelBuilder.Entity<Inscripcion>()
                .HasOne<CarreraTecnica>(i => i.CarreraTecnica)
                .WithMany(ct => ct.Inscripciones)
                .HasForeignKey(i => i.CarreraId);
            
            modelBuilder.Entity<Inscripcion>()
                .HasOne<Jornada>(i => i.Jornada)
                .WithMany(j => j.Inscripciones)
                .HasForeignKey(i => i.JornadaId);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Alumno)
                .WithMany(a => a.Inscripcion)
                .HasForeignKey(i => i.Carne);

            

        }   
    }
}