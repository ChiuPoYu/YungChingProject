using Microsoft.EntityFrameworkCore;
using YungChingWebApi.Models.Entities;

namespace YungChingWebApi.Data
{
    /// <summary>
    /// SQL Server 資料庫上下文
    /// </summary>
    public class SqlDbContext : DbContext
    {
        /// <summary>
        /// 建構函式
        /// </summary>
        /// <param name="options">DbContext 選項</param>
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 員工資料集
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        
        /// <summary>
        /// 房屋資料集
        /// </summary>
        public DbSet<House> Houses { get; set; }

        /// <summary>
        /// 模型建立時的配置
        /// </summary>
        /// <param name="modelBuilder">模型建構器</param>
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

                // 全局查詢過濾器：自動過濾已刪除的資料
                entity.HasQueryFilter(e => e.DeletedAt == DateTime.MaxValue);
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

                // 全局查詢過濾器：自動過濾已刪除的資料
                entity.HasQueryFilter(h => h.DeletedAt == DateTime.MaxValue);
            });
        }
    }
}
