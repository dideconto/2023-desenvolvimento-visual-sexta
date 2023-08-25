using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar() =>
        produtos.Count == 0 ? NotFound() : Ok(produtos);

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        produtos.Add(produto);
        return Created("", produto);
    }

    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        foreach (Produto produtoCadatrado in produtos)
        {
            if (produtoCadatrado.Nome == nome)
            {
                return Ok(produtoCadatrado);
            }
        }
        return NotFound();
    }
}

//Listar tradicional
// {
//     // if (produtos.Count == 0)
//     // {
//     //     return NotFound();
//     // }
//     // return Ok(produtos);
//     return produtos.Count == 0 ? NotFound() : Ok(produtos);
// }