namespace GamesMarket.DataContext.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid DeveloperId { get; set; }
        public DeveloperEntity? Developer { get; set; }
    }
}
