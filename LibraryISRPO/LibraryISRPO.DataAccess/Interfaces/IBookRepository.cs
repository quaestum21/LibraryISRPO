using LibraryISRPO.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryISRPO.DataAccess.Interfaces
{
    public interface IBookRepository
    {
        Task<BookEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<BookEntity>> GetAllAsync();
        Task AddAsync(BookEntity book);
        Task UpdateAsync(BookEntity book);
        Task DeleteAsync(Guid id);
    }
}
