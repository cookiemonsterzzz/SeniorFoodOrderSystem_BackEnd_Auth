using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace senior_food_order_system_auth;

public partial class SeniorFoodOrderSystemDatabaseContext : DbContext
{
    public SeniorFoodOrderSystemDatabaseContext()
    {
    }

    public SeniorFoodOrderSystemDatabaseContext(DbContextOptions<SeniorFoodOrderSystemDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07B553F209");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateTimeCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateTimeUpdated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Passcode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.RoleType)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
