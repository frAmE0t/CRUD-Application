using GamesMarket.DataContext.Entities;

namespace GamesMarket.DataContext.Interfaces
{
    public interface IGameRepository
    {
        Task<GameEntity> CreateGame(Guid id, string name, string description, decimal price);
        Task<GameEntity?> GetGame(Guid id);
        Task<List<GameEntity>?> GetAllGames();
        Task<GameEntity?> UpdateGame(Guid id, string name, string description, decimal price);
        Task<bool> DeleteGame(Guid id);
    }
}
