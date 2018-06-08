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

                var novoAtor = new Ator()
                {
                    PrimeiroNome = "Lisa",
                    UltimoNome = "Simpson"
                };

                context.Atores.Add(novoAtor);
                //context.Entry(novoAtor).Property("last_update").CurrentValue = DateTime.Now;
                context.SaveChanges();

                foreach (var ator in context.Atores)
                {
                    Console.WriteLine($"{ator.Id} - {ator.PrimeiroNome} - " + context.Entry(ator).Property("last_update").CurrentValue);
                }
            }

            Console.ReadKey();
        }
    }
}