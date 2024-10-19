using GamesMarket.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesMarket.DataContext.Configuration
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<DeveloperEntity>
    {
        public void Configure(EntityTypeBuilder<DeveloperEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .HasMany(d => d.Games)
                .WithOne(g => g.Developer)
                .HasForeignKey(g => g.DeveloperId);
        }
    }
}
