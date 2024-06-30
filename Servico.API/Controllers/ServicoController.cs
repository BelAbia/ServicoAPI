using Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace Servico.API.Controllers
{
    [ApiController]
    public class ServicoController : ControllerBase
    {
       private readonly IRepositorioServico _repositorioServico;
       public ServicoController(IRepositorioServico repositorioServico) {
            _repositorioServico = repositorioServico;
        }


    }
}
