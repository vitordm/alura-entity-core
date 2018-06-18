using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Alura.Filmes.App.Extensions;

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

        public IList<Filme> BuscaFilmesRelacionadosIdiomas()
        {
            using (var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();
                return context.Filmes
                    .Include(f => f.IdiomaFalado)
                    .Include(f => f.IdiomaOriginal)
                    .OrderBy(f => f.Id)
                    .ToList();
            }

        }
    }
}
