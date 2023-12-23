using Microsoft.EntityFrameworkCore;
using TransactionManager.API.Entities;

namespace TransactionManager.API.Configs
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategoriesModelConfigure(modelBuilder);
            UsersModelConfigure(modelBuilder);
            TransactionModelConfigure(modelBuilder);
        }
        private void CategoriesModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();
        }
        private void UsersModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();
        }
        private  void TransactionModelConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.UserId)
                .IsRequired();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Amount)
                .IsRequired();
        }

    }
}
