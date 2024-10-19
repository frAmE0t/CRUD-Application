namespace GamesMarket.DataContext.Entities
{
    public class DeveloperEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<GameEntity>? Games { get; set; }
    }
}
