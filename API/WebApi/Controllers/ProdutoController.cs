using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public ProdutoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Produto> produtos = _ctx.Produtos.ToList();
            return produtos.Count == 0 ? NotFound() : Ok(produtos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        try
        {
            _ctx.Produtos.Add(produto);
            _ctx.SaveChanges();
            return Created("", produto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        try
        {
            Produto? produtoCadastrado = _ctx.Produtos.FirstOrDefault(x => x.Nome == nome);
            if (produtoCadastrado != null)
            {
                return Ok(produtoCadastrado);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Produto? produtoCadastrado = _ctx.Produtos.Find(id);
            if (produtoCadastrado != null)
            {
                _ctx.Produtos.Remove(produtoCadastrado);
                _ctx.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id,
        [FromBody] Produto produto)
    {
        try
        {
            //Expressões lambda
            Produto? produtoCadastrado =
                _ctx.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (produtoCadastrado != null)
            {
                produtoCadastrado.Nome = produto.Nome;
                produtoCadastrado.Descricao = produto.Descricao;
                produtoCadastrado.Quantidade = produto.Quantidade;
                produtoCadastrado.Preco = produto.Preco;
                _ctx.Produtos.Update(produtoCadastrado);
                _ctx.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}