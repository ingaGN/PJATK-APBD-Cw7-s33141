using cwiczenia7.Entities;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia7.DAL;

public class ComputerDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentTypes>  ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ComponentTypes>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(e => e.Abreviation)
                    .HasMaxLength(30);
                entity.Property(e => e.Name).
                    HasMaxLength(150);
            }
        );


        modelBuilder.Entity<ComponentManufacturers>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(e => e.Abreviation)
                .HasMaxLength(30);
            entity.Property(e => e.FullName)
                .HasMaxLength(300);

        });
        
        
    }
}