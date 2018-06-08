using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContext : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(DatabasePassword.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ator>().ToTable("actor");
            modelBuilder.Entity<Ator>()
                .Property(a => a.Id)
                .HasColumnName("actor_id");
            modelBuilder.Entity<Ator>()
                .Property(a => a.PrimeiroNome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();
            modelBuilder.Entity<Ator>()
                .Property(a => a.UltimoNome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();
            modelBuilder.Entity<Ator>()
                .Property<DateTime>("last_update")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
