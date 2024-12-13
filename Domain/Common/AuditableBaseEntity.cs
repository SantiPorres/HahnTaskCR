using Domain.Interfaces;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity : IAuditableBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
