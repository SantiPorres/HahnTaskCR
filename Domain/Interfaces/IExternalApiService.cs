using Domain.Common;

namespace Domain.Interfaces
{
    public interface IExternalApiService<T> where T : AuditableBaseEntity
    {
        Task<string> GetDataAsync();
    }
}
