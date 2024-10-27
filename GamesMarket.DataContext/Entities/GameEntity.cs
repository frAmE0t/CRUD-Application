using System.ComponentModel.DataAnnotations.Schema;

namespace GamesMarket.DataContext.Entities
{
    public class GameEntity
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public Guid DeveloperId { get; set; }
        public DeveloperEntity? Developer { get; set; } = null;
    }
}
