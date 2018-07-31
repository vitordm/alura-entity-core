using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Repository;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new AluraFilmesContext())
            {
                context.LogSQLToConsole();
                var c = context.Clientes.First();

                foreach(var cliente in context.Clientes)
                {
                    Console.WriteLine(cliente);
                }

            }
            Console.ReadKey();
        }
    }
}