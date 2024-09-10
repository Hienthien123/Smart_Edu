using System;
using System.Collections.Generic;
using API_Sample.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace API_Sample.Data.EF;

public partial class MainDbContext : DbContext
{
    public MainDbContext()  
    {
    }

    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3213E83F47534C37");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", tb => tb.HasComment("fruit-to-seed conversion rate"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RatioTransfer).HasComment("Tỉ lệ chuyển đổi Quả -> Nhân");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
