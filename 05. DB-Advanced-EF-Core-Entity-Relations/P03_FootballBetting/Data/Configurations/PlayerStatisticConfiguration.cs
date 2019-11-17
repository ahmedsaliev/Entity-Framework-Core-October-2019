using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> entity)
        {
            entity
                    .HasKey(ps => new { ps.GameId, ps.PlayerId });

            entity
                .Property(ps => ps.ScoredGoals)
                .IsRequired(true);

            entity
                .Property(ps => ps.Assists)
                .IsRequired(true);

            entity
                .Property(ps => ps.MinutesPlayed)
                .IsRequired(true);

            entity
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            entity
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);
        }
    }
}