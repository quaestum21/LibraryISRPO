using LibraryISRPO.Core.Models;
using LibraryISRPO.DataAccess.Entities;
using LibraryISRPO.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess.Repositories
{
    public class BorrowedBooksRepository : IBorrowedBookRepository
    {
        private readonly LibraryISRPODbContext _context;

        public BorrowedBooksRepository(LibraryISRPODbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(BorrowedBook borrowedBook)
        {
            var borrowedBookEntity = new BorrowedBookEntity
            {
                BookId = borrowedBook.BookId,
                VisitorId = borrowedBook.VisitorId,
                BorrowedDate = borrowedBook.BorrowedDate,
                ReturnedDate = borrowedBook.ReturnedDate
            };
            await _context.BorrowedBooks.AddAsync(borrowedBookEntity);
            await _context.SaveChangesAsync();

            return borrowedBookEntity.BookId; // Или borrowedBookEntity.VisitorId, в зависимости от того, какой идентификатор вы хотите вернуть
        }

        public async Task<Guid> Update(Guid bookId, Guid visitorId, DateTime borrowedDate, DateTime? returnedDate)
        {
            await _context.BorrowedBooks
                .Where(bb => bb.BookId == bookId && bb.VisitorId == visitorId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(bb => bb.BorrowedDate, bb => borrowedDate)
                .SetProperty(bb => bb.ReturnedDate, bb => returnedDate));
            return bookId; // Или visitorId, в зависимости от того, какой идентификатор вы хотите вернуть
        }

        public async Task<Guid> Delete(Guid bookId, Guid visitorId)
        {
            var borrowedBookEntity = await _context.BorrowedBooks
                .FirstOrDefaultAsync(bb => bb.BookId == bookId && bb.VisitorId == visitorId);
            if (borrowedBookEntity != null)
            {
                _context.BorrowedBooks.Remove(borrowedBookEntity);
                await _context.SaveChangesAsync();
            }
            return bookId; // Или visitorId, в зависимости от того, какой идентификатор вы хотите вернуть
        }

        public async Task<List<BorrowedBook>> Get()
        {
            var borroweBookEntities = await _context.BorrowedBooks
                  .AsNoTracking()
                  .ToListAsync();
            var books = borroweBookEntities
                .Select(b => BorrowedBook.Create(b.BookId, b.VisitorId, b.BorrowedDate).BorrowedBook)
                .ToList();
            return books;
        }
    }

}
