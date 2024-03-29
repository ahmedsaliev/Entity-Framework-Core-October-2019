﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .HasKey(u => u.UserId);

            entity
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            entity
                .Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(false);

            entity
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            entity
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            entity
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}