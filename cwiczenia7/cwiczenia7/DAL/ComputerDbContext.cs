using cwiczenia7.Entities;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia7.DAL;

public class ComputerDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentTypes>  ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<PC> PC { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

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

        modelBuilder.Entity<PC>(entity =>
        {
            entity.HasKey(k => k.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("float(5)");

        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(c => c.Code);
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Description).HasColumnType("nvarchar(max)");
        });
        
        modelBuilder.Entity<Component>().HasOne(c => c.ComponentManufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.IdManufacurer);
        
        modelBuilder.Entity<Component>().HasOne(c => c.ComponentTypes)
            .WithMany(t => t.Components)
            .HasForeignKey(c => c.ComponentTypeId);

        modelBuilder.Entity<PCComponent>(entity =>
        {
            entity.HasKey(e => new
            { e.PCId, e.ComponentCode });
        });

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.PC)
            .WithMany(pcc => pcc.PCComponents)
            .HasForeignKey(pc => pc.PCId);
        
        modelBuilder.Entity<PCComponent>().HasOne(pc => pc.Component)
            .WithMany(pcc => pcc.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode);
    }
}