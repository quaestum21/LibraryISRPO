using LibraryISRPO.Core.Models;

namespace LibraryISRPO.DataAccess.Repositories
{
    internal interface IVisitorRepository
    {
        Task<Guid> Create(Visitor visitor);
        Task<Guid> Delete(Guid id);
        Task<List<Visitor>> GetAll();
        Task<Visitor> GetById(Guid id);
        Task<Guid> Update(Guid id, string name, string email);
    }
}