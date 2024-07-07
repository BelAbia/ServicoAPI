using Infraestrutura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Dominio.Modelos;
using static Dominio.Modelos.TipoEnum;

namespace ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepositorioProduto _repositorio;
        public ProdutoController(IRepositorioProduto repositorioProduto) 
        {
            _repositorio = repositorioProduto;
        }

        [HttpGet]
        public ActionResult ObterTodos()
        {
            try
            {
                var ListaDeProdutos = _repositorio.ObterTodos();
                return Ok(ListaDeProdutos);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")] 
        public ActionResult ObterPorId([FromRoute] int id) 
        {
            try
            {
                var produto = _repositorio.ObterPorId(id);
                return Ok(produto);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("dashboard")]
        public ActionResult ObterQuantidadeEPrecoMedioPorTipo()
        {
            try
            {
                var QuantidadeEPrecoMedio = _repositorio.ObterQuantidadeEPrecoMedioPorTipo();
                return Ok(QuantidadeEPrecoMedio);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                _repositorio.Adicionar(produto);
                return Created(produto.Id.ToString(), produto);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                _repositorio.Atualizar(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto([FromRoute] int id)
        {
            try
            {
                _repositorio.Deletar(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}