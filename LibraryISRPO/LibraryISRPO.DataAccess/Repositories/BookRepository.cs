using LibraryISRPO.DataAccess.Entities;
using LibraryISRPO.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryISRPODbContext _context;

        public BookRepository(LibraryISRPODbContext context)
        {
            _context = context;
        }

        public async Task<BookEntity> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddAsync(BookEntity book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookEntity book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

    }
}
