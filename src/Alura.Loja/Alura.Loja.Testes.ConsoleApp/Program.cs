using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = new Cliente
            {
                Nome = "Vitor Oliveira",
                EnderecoDeEntrega = new Endereco
                {
                    Numero = 1819,
                    Logradouro = "Rua das Avenidas",
                    Complemento = "Perto",
                    Bairro = "Pureza",
                    Cidade = "Não me toque"
                }
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(pessoa);
                contexto.SaveChanges();
                var clientes = contexto.Clientes.ToList();
                clientes.ForEach(c => Console.WriteLine(c));
            }

            Console.ReadKey();

        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto
            {
                Nome = "Harry Potter e a Pedra Filosofal",
                Categoria = "Livros",
                PrecoUnitario = 19.89
            };

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

        private static void NToM()
        {
            /*
            var promocao = new Promocao();
            promocao.Descricao = "Promoção de Informática";
            promocao.DataInicio = DateTime.Now;
            promocao.DataTermino = DateTime.Now.AddDays(7);

            promocao.IncluirProduto(new Produto { Nome = "Monitor AOC 19'", PrecoUnitario = 155.68, Unidade = "Un"});
            promocao.IncluirProduto(new Produto { Nome = "Mouse Logitec ", PrecoUnitario = 19.88, Unidade = "Un" });
            promocao.IncluirProduto(new Produto { Nome = "Teclado Logitec", PrecoUnitario = 25.69, Unidade = "Un" });
            */
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                /*contexto.Promocoes.Add(promocao);*/
                /*contexto.ExibeEntries();*/
                //var promocao = contexto.Promocoes.Find(1);
                //Console.WriteLine(promocao);

                //contexto.Promocoes.Remove(promocao);

                //contexto.SaveChanges();
            }

            Console.ReadKey();
        }

    }
}
