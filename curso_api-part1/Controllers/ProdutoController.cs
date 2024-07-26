using curso_api_part1.Model;
using curso_api_part1.Service;
using Microsoft.AspNetCore.Mvc;

namespace curso_api_part1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produto = await _produtoRepository.GetAll();
                if (produto is null)
                {
                    NotFound("Produtos não encontrados.");
                }

                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
        }

        [HttpGet("primeiro")]
        public async Task<IActionResult> GetFirst()
        {
            try
            {
                var primeiroProduto = await _produtoRepository.FirstProduct();

                if (primeiroProduto is null)
                {
                    return NotFound("Produto não encontrado");
                }

                return Ok(primeiroProduto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
        }

        //int:min(1) para colocar uma restrição na rota, evitando valores indesejaveis 
        [HttpGet("{id:int:min(1)}/{teste}", Name="get")]
        public async Task<IActionResult>Get(int? id,string teste)
        {
            try
            {
                string par = teste;

                if(id == null)
                {
                    return BadRequest("Informe um id");
                }

                var produto = await _produtoRepository.GetById(id.Value);

                if (produto is null)
                {
                    NotFound($"Produto com id {id} não encontrada...");
                }

                return Ok(produto);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
        }

        [HttpPost]
        public async Task<IActionResult>Post(Produtos produto)
        {
            try
            {
                if (produto is null)
                {
                    return BadRequest("Dados invalidos");
                }

                await _produtoRepository.Create(produto);


                return new CreatedAtActionResult("get", "Produto",
                    new { id = produto.ProdutoId }, produto);

                // Retorna um status 201 Created, incluindo o local do novo recurso criado no cabeçalho 'Location'.
                // O método CreatedAtActionResult é usado para gerar a resposta.
                // "get" é o nome da ação que será chamada para obter o recurso recém-criado.
                // "Produto" é o nome do controlador onde a ação está localizada.
                // new { id = produto.ProdutoId } cria um objeto anônimo contendo o ID do produto criado, usado para construir a URL.
                // produto é o valor retornado no corpo da resposta, que é o próprio produto criado.
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Produtos produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest("Id invalidos");
                }

                await _produtoRepository.Update(produto);

                return Ok(produto);
            }
            catch( Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
        }

        [HttpDelete]
        public async Task<IActionResult>Delete(int? id)
        {
            try
            {
                if (id is null)
                {
                    return BadRequest("Informe um Id...");
                }

                await _produtoRepository.Delete(id.Value);

                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
            }
        }

        [HttpPatch]
        public async Task<IActionResult>Produto(Produtos produto)
        {
             await _produtoRepository.PathUpLoad(produto);

            return Ok();
        }
    }
}
