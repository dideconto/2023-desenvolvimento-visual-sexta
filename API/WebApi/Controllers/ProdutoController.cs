using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public ProdutoController(AppDataContext ctx) => _ctx = ctx;

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Produto> produtos = _ctx.Produtos.ToList();
        return produtos.Count == 0 ? NotFound() : Ok(produtos);
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        _ctx.Produtos.Add(produto);
        _ctx.SaveChanges();
        return Created("", produto);
    }

    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        //Expressão lambda para buscar um registro na base de dados com EF
        foreach (Produto produtoCadatrado in _ctx.Produtos.ToList())
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