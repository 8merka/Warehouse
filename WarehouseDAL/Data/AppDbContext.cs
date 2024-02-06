using Microsoft.EntityFrameworkCore;
using WarehouseDAL.Models;

namespace WarehouseDAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerDepartment> WorkerDepartments { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkerDepartment>()
                .HasKey(a => new { a.WorkerId, a.DepartmentId });
            modelBuilder.Entity<WorkerDepartment>()
                .HasOne(wd => wd.Worker)
                .WithMany(w => w.WorkerDepartments)
                .HasForeignKey(wd => wd.WorkerId);
            modelBuilder.Entity<WorkerDepartment>()
                .HasOne(wd => wd.Department)
                .WithMany(d => d.WorkerDepartments)
                .HasForeignKey(wd => wd.DepartmentId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DepartmentId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Warehouse;Username=postgres;Password=9100");
        }
    }
}
