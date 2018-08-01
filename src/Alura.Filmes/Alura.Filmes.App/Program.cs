using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
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
                var categoria = "Action";
                var paramCategoria = new SqlParameter("@categoria", categoria);

                var paramTotal = new SqlParameter()
                {
                    ParameterName = "@total",
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 4

                };
                context.Database
                    .ExecuteSqlCommand("total_actors_from_given_category @categoria, @total OUT", paramCategoria, paramTotal);

                Console.WriteLine($"O total da categoria '{categoria}' é {paramTotal.Value}");

            }
            Console.ReadKey();
        }
    }
}