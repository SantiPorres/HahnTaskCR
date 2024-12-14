using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Card : AuditableBaseEntity
    {
        public required string Name { get; set; }
        public CardRarity Rarity { get; set; }
        public int MaxLevel { get; set; }
        public int ElixirCost { get; set; }
        public int MaxEvolutionLevel { get; set; }
    }
}
