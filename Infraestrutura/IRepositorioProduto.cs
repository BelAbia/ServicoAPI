using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public interface IRepositorioProduto
    {
        public Produto ObterPorId(int id);
        public List<Produto> ObterTodos();
        public Produto Adicionar(Produto produto);
        public void Atualizar(Produto produto);
        public List<ProdutoDTO> ObterDashboard();
        public void Deletar (int id);
    }
}
