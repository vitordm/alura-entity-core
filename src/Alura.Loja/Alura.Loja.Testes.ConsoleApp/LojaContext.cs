using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder.Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder.Entity<Endereco>()
                .HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=WKS14\SQLEXPRESS;Database=vtr_alura_entity;User Id=sa;Password=12345;");
        }

        public void ExibeEntries()
        {
            var entries = ChangeTracker.Entries();
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
    }
}