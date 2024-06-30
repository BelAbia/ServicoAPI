using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public interface IRepositorioServico
    {
        public Servico ObterPorId(int id);
        public List<Servico> ObterTodos();
        public Servico Adicionar(Servico servico);
        public Servico Atualizar(string id);
        public Servico ObterPorQuery(ServicoDTO filtro);
    }
}
