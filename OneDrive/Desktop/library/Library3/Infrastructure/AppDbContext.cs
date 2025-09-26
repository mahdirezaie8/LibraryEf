using Library3.ntts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library3.Infrastructure
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=mahdire82\SQLEXPRESS; Initial Catalog = Library; Integrated Security = True; Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<Review>().Property(r => r.Comment).HasColumnType("nvarchar(500)").HasMaxLength(500);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnType("nvarchar(200)").HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(b =>b.Name).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<Book>().Property(b =>b.Author).HasColumnType("nvarchar(250)").HasMaxLength(250);
            modelBuilder.Entity<User>().HasKey(u=>u.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.ID);
            modelBuilder.Entity<BorrowedBook>().HasKey(b => b.Id);
            modelBuilder.Entity<Review>().HasKey(r => r.ID);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<BorrowedBook>().ToTable("BorrowedBooks");
            modelBuilder.Entity<Review>().ToTable("Reviews");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
