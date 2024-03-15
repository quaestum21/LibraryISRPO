using LibraryISRPO.Core.Models;
using LibraryISRPO.DataAccess.Entities;
using LibraryISRPO.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess.Repositories
{
    class VisitorsRepository : IVisitorRepository
    {
        private readonly LibraryISRPODbContext _context;

        public VisitorsRepository(LibraryISRPODbContext context)
        {
            _context = context;
        }

        public async Task<List<Visitor>> GetAll()
        {
            var visitorEntities = await _context.Visitors
                .AsNoTracking()
                .ToListAsync();
            var visitors = visitorEntities
                .Select(v => Visitor.Create(v.Id, v.Name, v.Email).Visitor)
                .ToList();
            return visitors;
        }

        public async Task<Visitor> GetById(Guid id)
        {
            var visitorEntity = await _context.Visitors
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);
            if (visitorEntity != null)
            {
                return Visitor.Create(visitorEntity.Id, visitorEntity.Name, visitorEntity.Email).Visitor;
            }
            return null;
        }

        public async Task<Guid> Create(Visitor visitor)
        {
            var visitorEntity = new VisitorEntity
            {
                Id = visitor.Id,
                Name = visitor.Name,
                Email = visitor.Email
            };
            await _context.Visitors.AddAsync(visitorEntity);
            await _context.SaveChangesAsync();

            return visitorEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string email)
        {
            await _context.Visitors
                .Where(v => v.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(v => v.Name, v => name)
                .SetProperty(v => v.Email, v => email));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            var visitorEntity = await _context.Visitors
                .FirstOrDefaultAsync(v => v.Id == id);
            if (visitorEntity != null)
            {
                _context.Visitors.Remove(visitorEntity);
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
