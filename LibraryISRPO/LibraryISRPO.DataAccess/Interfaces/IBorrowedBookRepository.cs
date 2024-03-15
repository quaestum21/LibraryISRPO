using LibraryISRPO.Core.Models;

namespace LibraryISRPO.DataAccess.Interfaces
{
    public interface IBorrowedBookRepository
    {
        Task<Guid> Create(BorrowedBook borrowedBook);
        Task<Guid> Delete(Guid bookId, Guid visitorId);
        Task<List<BorrowedBook>> Get();
        Task<Guid> Update(Guid bookId, Guid visitorId, DateTime borrowedDate, DateTime? returnedDate);
    }
}