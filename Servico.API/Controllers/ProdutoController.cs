using Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace Produto.API.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
       private readonly IRepositorioProduto _repositorioProduto;
       public ProdutoController(IRepositorioProduto repositorioProduto) {
            _repositorioProduto = repositorioProduto;
        }


    }
}
