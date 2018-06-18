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

            var filmeRepository = new FilmeRepository();
            foreach(var filme in filmeRepository.BuscaFilmesRelacionadosIdiomas())
            {
                Console.WriteLine(filme.ToString());
                Console.WriteLine(filme.IdiomaFalado);
                Console.WriteLine(filme.IdiomaOriginal);
                Console.WriteLine("--------------------");
            }
        

            Console.ReadKey();
        }
    }
}