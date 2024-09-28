using System.Data.Entity;
using DOANTD.Entities;

namespace DOANTD.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; } // Định nghĩa DbSet cho Job
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
            // Cấu hình thêm cho các thuộc tính nếu cần
        }
    }
}