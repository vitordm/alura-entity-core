﻿using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Repository;
using Microsoft.EntityFrameworkCore;
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
                var top5Atores = context.Atores.FromSql(@" select a.*
        from actor a
            inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id")
                .Include(a => a.Filmografia);

                foreach (var ator in top5Atores)
                {
                    Console.WriteLine($"{ator.PrimeiroNome} - {ator.Filmografia.Count()}");
                }

            }
            Console.ReadKey();
        }
    }
}