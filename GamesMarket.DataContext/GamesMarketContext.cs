using GamesMarket.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesMarket.DataContext
{
    public class GamesMarketContext : DbContext
    {
        public DbSet<GameEntity>? Games { get; set; }
        public DbSet<DeveloperEntity>? Developers { get; set; }

        public GamesMarketContext()
        {
        }

        public GamesMarketContext(DbContextOptions<GamesMarketContext> options)
            : base(options) 
        {
        }
    }
}
