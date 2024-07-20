using curso_api_part1.Model;
using curso_api_part1.Service;
using Microsoft.AspNetCore.Mvc;

namespace curso_api_part1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : Controller
{
    private readonly ICategoriaRepository _ICategoriaRepository;

    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _ICategoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categorias = await _ICategoriaRepository.GetAll();

            if (categorias is null)
            {
                return NotFound("Categorias não encontradas.");
            }

            return Ok(categorias);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
        }
    }

    [HttpGet("categoria-com-produto")]
    public async Task<IActionResult> GetCategoriaProduto()
    {
        try
        {
            var categoriaEProduto = await _ICategoriaRepository.GetAllProdutoCategoria();

            if (categoriaEProduto is null)
            {
                return NotFound("Categorias e produtos não encontrados.");
            }

            return Ok(categoriaEProduto);
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar a sua solicitação");
        }
    }

    [HttpGet("id:int")]
    public async Task<IActionResult>GetById(int? id)
    {
        try
        {
            if (id is null)
            {
                return BadRequest("Informe um id");
            }

            var categorias = await _ICategoriaRepository.GetById(id.Value);

            if (categorias is null)
            {
                return NotFound($"Categoria com o id {id} não encontrado...");
            }

            return Ok(categorias);
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                     "Ocorreu um erro ao tratar a sua solicitação");
        }
       

    }

    [HttpPost]
    public async Task<IActionResult>Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
            {
                return BadRequest("Dados invalidos");
            }

            await _ICategoriaRepository.Create(categoria);

            return new CreatedAtActionResult("get", "Categoria",
                new { id = categoria.CategoriaId }, categoria);
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
    public async Task<IActionResult>Put(int id ,Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Dados invalidos");
            }

            await _ICategoriaRepository.Update(categoria);

            return Ok(categoria);
        }
        catch(Exception)
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
                return BadRequest("Informe um id");
            }

            await _ICategoriaRepository.Delete(id.Value);

            return Ok();
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                     "Ocorreu um erro ao tratar a sua solicitação");
        }
    }
}
