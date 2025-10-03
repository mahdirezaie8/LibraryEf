using Microsoft.EntityFrameworkCore;
using Quiz2.entity;
namespace Quiz2.Infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=mahdire82\SQLEXPRESS; Initial Catalog = Bank; Integrated Security = True; Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasKey(u => u.Id);
            modelBuilder.Entity<Transaction1>().HasKey(b => b.TransactionId);
            modelBuilder.Entity<Transaction1>().HasOne(t=>t.FirstCard).WithMany(t=>t.FirstTransactions).HasForeignKey(t=>t.FirstCardId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction1>().HasOne(t => t.LastCard).WithMany(t=>t.lastTransactions).HasForeignKey(t => t.LastCardId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction1> Transactions { get; set; }
    }
}
