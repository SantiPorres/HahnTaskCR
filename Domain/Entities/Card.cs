using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class Card : AuditableBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public required string Name { get; set; }
        public required string Rarity { get; set; }
        public int MaxLevel { get; set; }
        public int ElixirCost { get; set; }
        public int? MaxEvolutionLevel { get; set; }
    }
}
