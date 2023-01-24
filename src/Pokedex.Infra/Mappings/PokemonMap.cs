using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Business.Entities;

namespace Pokedex.Infra.Mappings;

public class PokemonMap : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.ToTable("POKEMON");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("PokemonId");

        builder.Property(x => x.Gender)
            .HasColumnName("Gender");

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .IsUnicode()
            .HasMaxLength(50);

        builder.Property(x => x.CategoryId)
            .HasColumnName("CategoryId");

        builder.Property(x => x.Hp)
            .HasColumnName("Hp");

        builder.Property(x => x.Attack)
            .HasColumnName("Attack");

        builder.Property(x => x.Defense)
            .HasColumnName("Defense");

        builder.Property(x => x.Speed)
            .HasColumnName("Speed");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt");
    }
}
