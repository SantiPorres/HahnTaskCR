using Domain.Entities;
using Domain.Interfaces;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Cards = new BaseRepository<Card>(_context);
    }

    public IBaseRepository<Card> Cards { get; set; }
    
    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }
}