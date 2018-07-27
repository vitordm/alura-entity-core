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
                try
                {
                    context.LogSQLToConsole();
                    var vitor1 = new Ator { PrimeiroNome = "Vitor", UltimoNome = "Oliveira" };
                    var vitor2 = new Ator { PrimeiroNome = "Vitor", UltimoNome = "Oliveira" };
                    context.Atores.AddRange(vitor1, vitor2);
                    context.SaveChanges();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }
            Console.ReadKey();
        }
    }
}