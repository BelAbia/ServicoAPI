using Dominio;

namespace Infraestrutura
{
    public class RepositorioServico : IRepositorioServico
    {
        public Servico Adicionar(Servico servico)
        {
            throw new NotImplementedException();
        }

        public Servico Atualizar(string id)
        {
            throw new NotImplementedException();
        }

        public Servico ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Servico ObterPorQuery(ServicoDTO filtro)
        {
            throw new NotImplementedException();
        }

        public List<Servico> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
