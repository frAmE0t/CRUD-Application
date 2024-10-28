using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GamesMarket.DataContext.Repository
{
    public class GameRepository : IGameRepository
    {
        private GamesMarketContext _db { get; set; }

        public GameRepository(GamesMarketContext db)
        {
            _db = db;
        }

        public async Task<GameEntity?> CreateGame(Guid id, string name, string description, decimal price)
        {
            GameEntity game = new()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price
            };

            var addedGame = await _db.Games.AddAsync(game);
            await _db.SaveChangesAsync();

            if (addedGame is null)
                return null;
            return game;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            _db.Games.Remove(game);

            int affected = await _db.SaveChangesAsync();

            if (affected == 1)
                return true;
            return false;
        }

        public async Task<List<GameEntity?>> GetAllGames()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<GameEntity?> GetGame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            return game;
        }

        public async Task<GameEntity?> UpdateGame(Guid id, string name, string description, decimal price)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
                return null;

            game.Name = name;
            game.Description = description;
            game.Price = price;

            await _db.SaveChangesAsync();

            return game;
        }
    }
}
