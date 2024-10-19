using GamesMarket.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesMarket.DataContext.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .IsRequired();

            builder.Property(g => g.Price)
                .IsRequired();

            builder.Property(g => g.Description)
                .HasMaxLength(250);

            builder.Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(g => g.Developer)
                .WithMany(d => d.Games);
        }
    }
}
