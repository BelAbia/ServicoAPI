using Infraestrutura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Dominio.Modelos;

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
        public IActionResult ObterTodos()
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
        public ActionResult ObterPorId(int id) 
        {
            try
            {
                const int vazio = 0;
                if(id == vazio)
                {
                    return NotFound();
                }

                var produto = _repositorio.ObterPorId(id);
                return Ok(produto);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao obter o produto");
            }
        }

        [HttpPost]
        public CreatedResult AdicionarProduto(Produto produto)
        {
            try
            {
                if (produto is null)
                {
                    throw new Exception("Produto não informado");
                }

                _repositorio.Adicionar(produto);
                return Created(produto.Id.ToString(), produto);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletarProduto(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    return NotFound();
                }

                var ProdutoASerDeletado = _repositorio.ObterPorId(Id);
                _repositorio.Deletar(ProdutoASerDeletado.Id);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarProduto(Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return NotFound();
                }

                _repositorio.Atualizar(produto);
                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("dashboard")]
        public IActionResult ObterQuantidadeEPrecoMedioPorTipo()
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
    }
}