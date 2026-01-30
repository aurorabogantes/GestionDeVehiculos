using GestionDeVehiculos.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDeVehiculos.DA;

public class VehiculosDbContext : DbContext
{
    public VehiculosDbContext(DbContextOptions<VehiculosDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Marca).IsRequired();
            entity.Property(e => e.Modelo).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Año).IsRequired();
            entity.Property(e => e.DobleTraccion).IsRequired();
        });
    }
}

