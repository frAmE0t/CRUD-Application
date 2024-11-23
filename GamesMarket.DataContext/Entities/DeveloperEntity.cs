using System.ComponentModel.DataAnnotations.Schema;

namespace GamesMarket.DataContext.Entities
{
    public class DeveloperEntity
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Name { get; set; } = string.Empty;

        public List<GameEntity>? Games { get; set; } = null;
    }
}
