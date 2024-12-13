using Domain.Common;

namespace Domain.Interfaces;

public interface IBaseRepository<T> where T : AuditableBaseEntity
{
    IAsyncEnumerable<T> List();
    Task<T> GetById(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
}