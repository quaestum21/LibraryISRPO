using LibraryISRPO.DataAccess.Entities;
using LibraryISRPO.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess.Repositories
{
    public class BorrowedBookRepository : IBorrowedBookRepository
    {
        private readonly LibraryISRPODbContext _context;

        public BorrowedBookRepository(LibraryISRPODbContext context)
        {
            _context = context;
        }

        public async Task<BorrowedBookEntity> GetByIdAsync(Guid bookId, Guid visitorId)
        {
            return await _context.BorrowedBooks.FindAsync(bookId, visitorId);
        }

        public async Task<IEnumerable<BorrowedBookEntity>> GetAllAsync()
        {
            return await _context.BorrowedBooks.ToListAsync();
        }

        public async Task AddAsync(BorrowedBookEntity borrowedBook)
        {
            await _context.BorrowedBooks.AddAsync(borrowedBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BorrowedBookEntity borrowedBook)
        {
            _context.Entry(borrowedBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid bookId, Guid visitorId)
        {
            var borrowedBook = await _context.BorrowedBooks.FindAsync(bookId, visitorId);
            if (borrowedBook != null)
            {
                _context.BorrowedBooks.Remove(borrowedBook);
                await _context.SaveChangesAsync();
            }
        }
    }

}
