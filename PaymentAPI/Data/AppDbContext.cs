using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Mappings;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
