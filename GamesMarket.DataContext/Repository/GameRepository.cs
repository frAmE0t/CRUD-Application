using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesMarket.DataContext.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GamesMarketContext _db;

        public GameRepository(GamesMarketContext db)
        {
            _db = db;
        }

        public async Task<GameEntity> CreateGame(Guid id, string name, string description, decimal price, Guid? developerId)
        {
            Game game = new(id, name, description, price, developerId);
            
            GameEntity gameEntity = new()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Price = game.Price,
                DeveloperId = developerId
            };

            if (developerId is not null)
            {
                var developer = await _db.Developers.FirstOrDefaultAsync(d => d.Id == developerId);

                if (developer is not null)
                {
                    gameEntity.Developer = developer;
                    
                    if (developer.Games is null)
                        developer.Games = new();
                    developer.Games.Add(gameEntity);
                }
            }
            
            await _db.Games.AddAsync(gameEntity);
            await _db.SaveChangesAsync();
            
            return gameEntity;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game is null)
                return false;
            
            var developer = await _db.Developers.FirstOrDefaultAsync(d => d.Games.Contains(game));
            if (developer is not null)
                developer.Games!.Remove(game);
            
            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task<List<GameEntity>?> GetAllGames()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<GameEntity?> GetGame(Guid id)
        {
            return await _db.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GameEntity?> UpdateGame(Guid id, string name, string description, decimal price, Guid? developerId)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
                return null;

            game.Name = name;
            game.Description = description;
            game.Price = price;
            game.DeveloperId = developerId;

            await _db.SaveChangesAsync();

            return game;
        }
    }
}
