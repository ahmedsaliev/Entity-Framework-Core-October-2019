using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> entity)
        {
            entity
                   .HasKey(t => t.ColorId);

            entity
                .Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}