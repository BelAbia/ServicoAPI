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
                    ?? throw new Exception($"Produto com id [{id}] não encontrado.");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
                produto.Id = _conexao.InsertWithInt32Identity(produto);
                return produto;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
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

                var produtoDoBanco = ObterPorId(produto.Id);

                if (produtoDoBanco is null)
                {
                    throw new Exception("Este produto não existe na base de dados.");
                }

                _validador.ValidateAndThrow(produto);
                _conexao.Update(produto);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var produtoDoBanco = ObterPorId(id);

                if (produtoDoBanco is null)
                {
                    throw new Exception("Este produto não existe na base de dados.");
                }

                _conexao.Delete(produtoDoBanco);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}