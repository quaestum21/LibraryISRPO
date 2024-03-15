using LibraryISRPO.DataAccess.Configurations;
using LibraryISRPO.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess
{
    public class LibraryISRPODbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<BorrowedBookEntity> BorrowedBooks { get; set; }
        public LibraryISRPODbContext(DbContextOptions<LibraryISRPODbContext> options): base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new VisitorConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowedBookConfiguration());
        }
    }
}
