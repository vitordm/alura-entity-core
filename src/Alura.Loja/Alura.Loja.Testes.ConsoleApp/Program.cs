using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //RemoveProduto();
            //AtualizarProduto();
            //RecuperarProdutos();
            //// -- GravarUsandoAdoNet(); -- ////
            //Console.ReadKey();
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Pedra Filosofal";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p);
            }
        }

        private static void RecuperarProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                List<Produto> produtos = context.Produtos();
                Console.WriteLine($"Foram encontrados {produtos.Count} registros!");
                produtos.ForEach(p => Console.WriteLine(p));
            }
        }

        private static void RemoveProduto()
        {
            using (var context = new ProdutoDAOEntity())
            {
                Produto produto = context.Produtos().Last();
                if (produto != null)
                {
                    context.Remover(produto);
                }
            }
        }

        private static void AtualizarProduto()
        {
            using (var context = new ProdutoDAOEntity())
            {
                //Produto produto = context.Produtos.Where(p => p.Nome.Contains("Pedra")).FirstOrDefault();
                Produto produto = context.Produtos().Where(p => p.Nome.Contains("Pedra")).FirstOrDefault();
                if (produto != null)
                {
                    produto.PrecoUnitario = 15.94;
                    context.Atualizar(produto);
                }
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
