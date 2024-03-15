using LibraryISRPO.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryISRPO.DataAccess.Interfaces
{
    public interface IBorrowedBookRepository
    {
        Task<BorrowedBookEntity> GetByIdAsync(Guid bookId, Guid visitorId);
        Task<IEnumerable<BorrowedBookEntity>> GetAllAsync();
        Task AddAsync(BorrowedBookEntity borrowedBook);
        Task UpdateAsync(BorrowedBookEntity borrowedBook);
        Task DeleteAsync(Guid bookId, Guid visitorId);
    }
}
