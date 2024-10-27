using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            _db.SaveChanges();

            if (addedGame is null)
                return null;
            return game;
        }

        public async Task<bool> DeleteGame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            _db.Games.Remove(game);

            int affected = _db.SaveChanges();

            if (affected == 1)
                return true;
            return false;
        }

        public Task<List<GameEntity?>> GetAllGames()
        {
            return _db.Games.ToListAsync();
        }

        public async Task<GameEntity?> GetGame(Guid id)
        {
            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            return game;
        }

        public async Task<GameEntity?> UpdateGame(Guid id, string name, string description, decimal price)
        {
            GameEntity newGame = new()
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price
            };

            var game = await _db.Games.FirstOrDefaultAsync(g => g.Id == id);

            _db.Games.Entry(game).CurrentValues.SetValues(newGame);

            int affected = _db.SaveChanges();

            if (affected == 1)
                return newGame;
            return null;
        }
    }
}
