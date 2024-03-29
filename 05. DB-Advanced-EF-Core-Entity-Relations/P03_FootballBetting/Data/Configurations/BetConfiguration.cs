﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> entity)
        {
            entity
                    .HasKey(b => b.BetId);

            entity
                .Property(b => b.Amount)
                .IsRequired(true);

            entity
                .Property(b => b.Prediction)
                .IsRequired(true);

            entity
                .Property(b => b.DateTime)
                .IsRequired(true);

            entity
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            entity
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}