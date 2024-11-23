using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
using GamesMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesMarket.DataContext.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GamesMarketContext _db;

        public DeveloperRepository(GamesMarketContext db)
        {
            _db = db;
        }

        public async Task<DeveloperEntity> CreateDeveper(Guid id, string name)
        {
            Developer developer = new(id, name);
            
            DeveloperEntity developerEntityEntity = new()
            {
                Id = developer.Id,
                Name = developer.Name,
            };

            List<GameEntity> games = await _db.Games.Where(g => g.DeveloperId == developer.Id).ToListAsync();
            
            developerEntityEntity.Games.AddRange(games);
            
            await _db.Developers.AddAsync(developerEntityEntity);
            await _db.SaveChangesAsync();

            return developerEntityEntity;
        }

        public async Task<bool> DeleteDeveper(Guid id)
        {
            var developer = await _db.Developers.FirstOrDefaultAsync(d => d.Id == id);

            if (developer is null)
                return false;

            List<GameEntity> games = await _db.Games.Where(g => g.DeveloperId == developer.Id).ToListAsync();
            foreach (GameEntity game in games)
            {
                game.DeveloperId = null;
                game.Developer = null;
            }
            
            _db.Developers.Remove(developer);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<DeveloperEntity>?> GetAllDevepers()
        {
            return await _db.Developers.ToListAsync();
        }

        public async Task<DeveloperEntity?> GetDeveper(Guid id)
        {
            return await _db.Developers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DeveloperEntity?> UpdateDeveper(Guid id, string name)
        {
            var developer = await _db.Developers.FirstOrDefaultAsync(d => d.Id == id);

            developer.Name = name;

            await _db.SaveChangesAsync();
            return developer;
        }
    }
}
