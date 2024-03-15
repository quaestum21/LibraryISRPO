using LibraryISRPO.DataAccess.Entities;
using LibraryISRPO.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryISRPO.DataAccess.Repositories
{
    class VisitorRepository : IVisitorRepository { 
    private readonly LibraryISRPODbContext _context;

    public VisitorRepository(LibraryISRPODbContext context)
    {
        _context = context;
    }

    public async Task<VisitorEntity> GetByIdAsync(Guid id)
    {
        return await _context.Visitors.FindAsync(id);
    }

    public async Task<IEnumerable<VisitorEntity>> GetAllAsync()
    {
        return await _context.Visitors.ToListAsync();
    }

    public async Task AddAsync(VisitorEntity visitor)
    {
        await _context.Visitors.AddAsync(visitor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VisitorEntity visitor)
    {
        _context.Entry(visitor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var visitor = await _context.Visitors.FindAsync(id);
        if (visitor != null)
        {
            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }
    }
    }
}
