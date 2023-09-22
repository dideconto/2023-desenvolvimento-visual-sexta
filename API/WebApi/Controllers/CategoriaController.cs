namespace WebApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

[ApiController]
[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public CategoriaController(AppDataContext context)
    {
        _ctx = context;
    }

    // GET: api/categoria/listar
    [HttpGet]
    [Route("listar")]
    public ActionResult Listar()
    {
        try
        {
            List<Categoria> categorias = _ctx.Categorias.ToList();
            return categorias.Count == 0 ? NotFound() : Ok(categorias);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/categoria/buscar/{nome}
    [HttpGet]
    [Route("buscar/{nome}")]
    public ActionResult Buscar([FromRoute] string nome)
    {
        try
        {
            Categoria? categoriaCadastrada = _ctx.Categorias.FirstOrDefault(x => x.Nome == nome);
            if (categoriaCadastrada != null)
            {
                return Ok(categoriaCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/categoria/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Categoria categoria)
    {
        try
        {
            _ctx.Categorias.Add(categoria);
            _ctx.SaveChanges();
            return Created("", categoria);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // PUT: api/categoria/alterar/5
    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id,
        [FromBody] Categoria categoria)
    {
        try
        {
            Categoria? categoriaCadastrada =
                _ctx.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            if (categoriaCadastrada != null)
            {
                categoriaCadastrada.Nome = categoria.Nome;
                _ctx.SaveChanges();
                return Ok(categoria);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // DELETE: api/categoria/deletar/5
    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Categoria? categoriaCadastrada = _ctx.Categorias.Find(id);
            if (categoriaCadastrada != null)
            {
                _ctx.Categorias.Remove(categoriaCadastrada);
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

