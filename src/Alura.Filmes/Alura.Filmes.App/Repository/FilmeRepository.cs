using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alura.Filmes.App.Repository
{
    public class FilmeRepository
    {

        public Filme BuscaPrimeiroFilmeRelacionado(int id)
        {
            using (var context = new AluraFilmesContext())
            {

                var filme = context.Filmes.Where(f => f.Id == id)
                   .Include(f => f.Atores)
                   .ThenInclude(fa => fa.Ator)
                   .First();
                return filme;
            }

        }
    }
}
