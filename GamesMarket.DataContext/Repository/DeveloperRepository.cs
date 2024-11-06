using GamesMarket.DataContext.Entities;
using GamesMarket.DataContext.Interfaces;
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

        public async Task<DeveloperEntity> CreateDeveper(DeveloperEntity developer)
        {
            await _db.Developers.AddAsync(developer);
            await _db.SaveChangesAsync();

            return developer;
        }

        public async Task<bool> DeleteDeveper(Guid id)
        {
            var game = await _db.Developers.FirstOrDefaultAsync(d => d.Id == id);

            if (game is null)
                return false;

            _db.Developers.Remove(game);
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
