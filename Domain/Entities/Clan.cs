using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Clan : AuditableBaseEntity
    {
        public required string Tag { get; set; }
        public ClanChestStatusEnum ClanChestStatus { get; set; }
        public int ClanChestLevel { get; set; }
        public int ClanScore { get; set; }
        public int ClanChestMaxLevel { get; set; }
        public int ClanWarTrophies { get; set; }
        public int RequiredTrophies { get; set; }
        public int DonationsPerWeek { get; set; }
        public int BadgeId { get; set; }
        public int Name { get; set; }
        public required Location Location { get; set; }
        public ClanTypeEnum ClanType { get; set; }
        public int Members { get; set; }
        public string? Description { get; set; }
        public int ClanChestPoints { get; set; }

    }
}
