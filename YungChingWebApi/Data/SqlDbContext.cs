using Microsoft.EntityFrameworkCore;
using YungChingWebApi.Models.Entities;

namespace YungChingWebApi.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<House> Houses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee 設定
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Ext).HasMaxLength(10);
                entity.Property(e => e.Address).HasMaxLength(200);
            });

            // House 設定
            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Name).IsRequired().HasMaxLength(100);
                entity.Property(h => h.Address).IsRequired().HasMaxLength(200);
                entity.Property(h => h.Area).HasPrecision(10, 2);
                entity.Property(h => h.Floor).HasMaxLength(20);
                entity.Property(h => h.Layout).HasMaxLength(50);
                entity.Property(h => h.UnitPrice).HasPrecision(18, 2);
                entity.Property(h => h.TotalPrice).HasPrecision(18, 2);

                // 設定與 Employee 的關係
                entity.HasOne(h => h.Employee)
                    .WithMany()
                    .HasForeignKey(h => h.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
