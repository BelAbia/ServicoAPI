using Dominio;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Data.Common;

namespace Infraestrutura
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly ProdutoDb _conexao;
        public RepositorioProduto(ProdutoDb conexao) {
            _conexao = conexao;
        }
        public Produto Adicionar(Produto produto)
        {
            if(produto is null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não foi informado.");
            }

           _conexao.Insert(produto);
            return produto;
        }

        public void Atualizar(Produto produto)
        {
            if (produto is null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não foi informado.");
            }

            _conexao.Update(produto);
        }

        public void Deletar(int id)
        {
            _conexao.Produto.Where(person => person.Id == id).Delete();
        }

        public Produto ObterPorId(int id)
        {
            return _conexao.Produto.FirstOrDefault(produto => produto.Id == id) 
                ?? throw new Exception("Produto não encontrado.");
        }

        public List<ProdutoDTO> ObterDashboard()
        {
            return _conexao.Produto
                .GroupBy(produto => produto.Tipo)
                .Select(produto => new ProdutoDTO
                {
                    Tipo = produto.Key,
                    Quantidade = produto.Count(),
                    PrecoMedio = produto.Average(produto => produto.PrecoUnitario)
                })
                .ToList();
        }

        public List<Produto> ObterTodos()
        {
            return _conexao.Produto.ToList();
        }
    }
}
