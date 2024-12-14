using Domain.Entities;
using Domain.Interfaces;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IBaseRepository<Card> _cardRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IBaseRepository<Card> CardRepository => _cardRepository ?? new BaseRepository<Card>(_context);
    
    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }
}