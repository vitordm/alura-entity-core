using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
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

                var filmes = context.Filmes;
                foreach (var filme in filmes)
                {
                    Console.WriteLine($"{filme.Id} - {filme.Titulo} ({filme.AnoLancamento})");
                }
            }

            Console.ReadKey();
        }
    }
}