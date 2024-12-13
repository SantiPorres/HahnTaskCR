using Domain.Common;

namespace Domain.Entities
{
    public class Location : AuditableBaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsCountry { get; set; } = false;
        public string? CountryCode { get; set; }
    }
}
