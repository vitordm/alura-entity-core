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

                var idiomas = context.Idiomas;
                foreach(var idioma in idiomas)
                {
                    Console.WriteLine(idioma);
                }
            }

            Console.ReadKey();
        }
    }
}