using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContext : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer($"Server=192.168.0.25;Database=AluraFilmes;User Id=SA;Password={DatabasePassword.Password};");
        }
    }
}
