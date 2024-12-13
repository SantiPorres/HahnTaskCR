using Domain.Common;
using Domain.Interfaces;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T: AuditableBaseEntity
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<T> Entities;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        Entities = context.Set<T>();
    }
    
    public IAsyncEnumerable<T> List()
    {
        return Entities.AsAsyncEnumerable();
    }

    public async Task<T> GetById(int id)
    {
        return await Entities.FindAsync(id) ?? throw new KeyNotFoundException();
    }

    public async Task<T> Add(T entity)
    {
        EntityEntry<T> result = await Entities.AddAsync(entity);
        return result.Entity;
    }

    public async Task Update(T entity)
    {
        Entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        T entity = await GetById(id);
        entity.DeletedAt = DateTime.Now;
        await Update(entity);
    }
}