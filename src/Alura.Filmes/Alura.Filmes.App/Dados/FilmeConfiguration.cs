using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");
            builder
                .Property(f => f.Id)
                .HasColumnName("film_id");
            builder
                .Property(f => f.Titulo)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder
                .Property(f => f.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");
            builder
                .Property(f => f.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            /*
             builder
                .Property(f => f.IdiomaId)
                .HasColumnName("language_id")
                .HasColumnType("tinyint")
                .IsRequired();
            builder
                .Property(f => f.IdiomaOriginalId)
                .HasColumnName("original_language_id")
                .HasColumnType("tinyint");
            */
            builder
                .Property(f => f.Duracao)
                .HasColumnName("length")
                .HasColumnType("smallint");
            builder
                .Property(f => f.Avaliacao)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property<byte>("language_id");
            builder.Property<byte?>("original_language_id");

            builder.HasOne(f => f.IdiomaFalado)
                .WithMany(i => i.FilmesFalados)
                .HasForeignKey("language_id");

            builder.HasOne(f => f.IdiomaOriginal)
                .WithMany(i => i.FilmesOriginais)
                .HasForeignKey("original_language_id");
        }
    }
}
