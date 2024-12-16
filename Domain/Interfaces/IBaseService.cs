using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseService<T> where T : AuditableBaseEntity
    {
        Task<IEnumerable<Card>> GetAll(List<Dictionary<string, string>>? filters = null);
    }
}
