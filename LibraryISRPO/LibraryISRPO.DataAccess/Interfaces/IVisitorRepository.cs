using LibraryISRPO.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryISRPO.DataAccess.Interfaces
{
    public interface IVisitorRepository
    {
        Task<VisitorEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<VisitorEntity>> GetAllAsync();
        Task AddAsync(VisitorEntity visitor);
        Task UpdateAsync(VisitorEntity visitor);
        Task DeleteAsync(Guid id);
    }
}
