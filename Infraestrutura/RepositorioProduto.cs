using Dominio.Modelos;
using FluentValidation;
using LinqToDB;

namespace Infraestrutura
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly ProdutoDb _conexao;
        private readonly IValidator<Produto> _validador;

        public RepositorioProduto(ProdutoDb conexao, IValidator<Produto> validador) {
            _conexao = conexao;
            _validador = validador;
        }

        public List<Produto> ObterTodos()
        {
            try
            {
                return _conexao.Produto.ToList();
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao obter a lista de produtos no servidor.");
            }
        }

        public Produto ObterPorId(int id)
        {
            try
            {
                return _conexao.Produto.FirstOrDefault(produto => produto.Id == id) 
                    ?? throw new Exception("Produto não encontrado.");
            }catch
            {
                throw new Exception("Ocorreu um erro ao obter o produto no servidor.");
            }
        }

        public List<ProdutoDTO> ObterQuantidadeEPrecoMedioPorTipo()
        {
            try
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
            catch
            {
                throw new Exception("Ocorreu um erro ao obter a quantidade e preço médio dos produtos no servidor.");
            }
        }

        public Produto Adicionar(Produto produto)
        {
            try
            {
                if(produto is null)
                {
                    throw new ArgumentNullException(nameof(produto), "O produto não foi informado.");
                }

                _validador.ValidateAndThrow(produto);
                _conexao.Insert(produto);
                return produto;
            }
            catch
            {
                throw new Exception("Ocorreu um erro no servidor ao tentar criar o produto.");
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                if (produto is null)
                {
                    throw new ArgumentNullException(nameof(produto), "O produto não foi informado.");
                }

                _validador.ValidateAndThrow(produto);
                _conexao.Update(produto);
            }
            catch
            {
                throw new Exception("Ocorreu um erro no servidor ao tentar atualizar o produto.");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _conexao.Produto.Where(person => person.Id == id).Delete();
            }
            catch
            {
                throw new Exception("Ocorreu um erro no servidor ao tentar deletar o produto.");
            }
        }
    }
}