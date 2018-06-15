using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Repository;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();

                var filmeRepository = new FilmeRepository();
                var filme = filmeRepository.BuscaPrimeiroFilmeRelacionado(1);
                Console.WriteLine($"{filme.Id}  - {filme.Titulo}({filme.AnoLancamento})");
                foreach(var ator in filme.Atores)
                {
                    Console.WriteLine($"{ator.Ator.Id} - {ator.Ator.UltimoNome},{ator.Ator.PrimeiroNome}");
                }
            }

            Console.ReadKey();
        }
    }
}