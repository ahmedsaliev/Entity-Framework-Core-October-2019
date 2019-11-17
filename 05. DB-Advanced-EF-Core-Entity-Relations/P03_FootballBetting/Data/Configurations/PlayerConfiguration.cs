using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity
                    .HasKey(p => p.PlayerId);

            entity
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            entity
                .Property(p => p.SquadNumber)
                .HasMaxLength(3)
                .IsRequired(true)
                .IsUnicode(false);

            entity
                .Property(p => p.IsInjured)
                .IsRequired(true);

            entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            entity
                .HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId);
        }
    }
}