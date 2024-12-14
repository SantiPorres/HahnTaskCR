using Domain.Common;

namespace Domain.Interfaces
{
    public interface IExternalApiService<T> where T : AuditableBaseEntity
    {
        Task<IEnumerable<T>> GetDataAsync();
    }
}
