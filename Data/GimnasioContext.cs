// DbContext para la aplicación - contiene los DbSet y la configuración mínima de relaciones.
using Microsoft.EntityFrameworkCore;
using GimnasioGrupo2.Models;

namespace GimnasioGrupo2.Data
{
 public class GimnasioContext : DbContext
 {
 public GimnasioContext(DbContextOptions<GimnasioContext> options) : base(options)
 {
 }

 // DbSets
 public DbSet<Cliente> Clientes { get; set; } = null!;
 public DbSet<Rutina> Rutinas { get; set; } = null!;
 public DbSet<TipoMembresia> TiposMembresia { get; set; } = null!;
 public DbSet<TipoRutina> TiposRutina { get; set; } = null!;
 public DbSet<ClienteMembresia> ClienteMembresias { get; set; } = null!;
 public DbSet<Gimnasio> Gimnasios { get; set; } = null!;

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
 base.OnModelCreating(modelBuilder);

 // Asegurar keys y relaciones esperadas
 modelBuilder.Entity<Gimnasio>().HasKey(g => g.Id);

 // Cliente -> Gimnasio (opcional)
 modelBuilder.Entity<Cliente>()
 .HasOne<Gimnasio>()
 .WithMany(g => g.Clientes)
 .HasForeignKey(c => c.GimnasioId)
 .OnDelete(DeleteBehavior.SetNull);

 // Rutina -> Cliente (opcional)
 modelBuilder.Entity<Rutina>()
 .HasOne(r => r.Cliente)
 .WithMany(c => c.Rutinas)
 .HasForeignKey(r => r.ClienteDni)
 .OnDelete(DeleteBehavior.SetNull);

 // Rutina -> TipoRutina
 modelBuilder.Entity<Rutina>()
 .HasOne(r => r.TipoRutina)
 .WithMany(t => t.Rutinas)
 .HasForeignKey(r => r.TipoRutinaId)
 .OnDelete(DeleteBehavior.Cascade);

 // ClienteMembresia -> Cliente
 modelBuilder.Entity<ClienteMembresia>()
 .HasOne(cm => cm.Cliente)
 .WithMany(c => c.ClienteMembresias)
 .HasForeignKey(cm => cm.ClienteDni)
 .OnDelete(DeleteBehavior.Cascade);

 // ClienteMembresia -> TipoMembresia
 modelBuilder.Entity<ClienteMembresia>()
 .HasOne(cm => cm.TipoMembresia)
 .WithMany(t => t.ClienteMembresias)
 .HasForeignKey(cm => cm.TipoMembresiaId)
 .OnDelete(DeleteBehavior.Cascade);
 }
 }
}
