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
        public DbSet<CuentaporCobrar> CuentaporCobrar {get;set;}
        public DbSet<InversionCarreraTecnica> InversionCarreraTecnica {get;set;}
        public DbSet<ResultadoExamenAdmision> ResultadoExamenAdmision {get;set;}
        public DbSet<InscripcionPago> InscripcionPago {get;set;}

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
            modelBuilder.Entity<CuentaporCobrar>().ToTable("CuentaporCobrar").HasKey(cc => new{cc.Correlativo, cc.Anio, cc.Carne});
            modelBuilder.Entity<InversionCarreraTecnica>().ToTable("InversionCarreraTecnica").HasKey(ict => new{ict.InversionId});
            modelBuilder.Entity<ResultadoExamenAdmision>().ToTable("ResultadoExamenAdmision").HasKey(rea => new{rea.NoExpediente, rea.Anio});
            modelBuilder.Entity<InscripcionPago>().ToTable("InscripcionPago").HasKey(ip => new{ip.NoExpediente});

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
                .HasOne<Alumno>(i => i.Alumno)
                .WithMany(a => a.Inscripcion)
                .HasForeignKey(i => i.Carne);


            modelBuilder.Entity<CuentaporCobrar>()
                .HasOne<Alumno>(cc => cc.Alumno)
                .WithMany(a => a.CuentaporCobrar)
                .HasForeignKey(cc => cc.Carne);

            modelBuilder.Entity<InversionCarreraTecnica>()
                .HasOne<CarreraTecnica>(ict => ict.CarreraTecnica)
                .WithMany(ct => ct.Inversiones)
                .HasForeignKey(ict => ict.InversionId);

            modelBuilder.Entity<ResultadoExamenAdmision>()
                .HasOne<Aspirante>(rea => rea.Aspirante)
                .WithMany(a => a.ResultadosExamenAdmisiones)
                .HasForeignKey(rea => rea.NoExpediente);
            
            modelBuilder.Entity<InscripcionPago>()
                .HasOne<Aspirante>(ip => ip.Aspirante)
                .WithMany(a => a.IncripcionesPagos)
                .HasForeignKey(ip => ip.NoExpediente);

            

        }   
    }
}