using Microsoft.EntityFrameworkCore;
using Projeect_ITStep.Models;

namespace Projeect_ITStep.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.AuthorId)
            //    .WithMany(a => a.Books)
            //    .HasForeignKey(b => b.Id);

            modelBuilder.Entity<Book>()
        .HasOne(b => b.BookAuthor)
        .WithMany(a => a.Books)
        .HasForeignKey(b => b.AuthorId);


        }
    }
}
