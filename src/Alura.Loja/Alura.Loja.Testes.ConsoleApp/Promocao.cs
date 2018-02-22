﻿using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataTermino { get; internal set; }
        public IList<PromocaoProduto> Produtos { get; internal set; }

        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        internal void IncluirProduto(Produto produto)
        {
            Produtos.Add(new PromocaoProduto() { Produto = produto, Promocao = this });
        }

        public override string ToString()
        {
            return $"{Id} - {Descricao} (de {DataInicio.ToString("dd/MM/yyyy HH:mm")} até {DataTermino.ToString("dd/MM/yyyy HH:mm")})";
        }
    }
}
