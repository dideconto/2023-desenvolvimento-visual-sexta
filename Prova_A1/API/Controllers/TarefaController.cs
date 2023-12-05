using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers;

[Route("api/tarefa")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly AppDataContext _context;

    public TarefaController(AppDataContext context) =>
        _context = context;

    // GET: api/tarefa/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.Include(x => x.Categoria).ToList();
            return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/tarefa/naoconcluidas
    [HttpGet]
    [Route("naoconcluidas")]
    public IActionResult ListarNaoConcluidas()
    {
        try
        {
            List<Tarefa> tarefas = _context.
                Tarefas.
                Include(x => x.Categoria).
                Where(x => x.Status != "Concluída").
                ToList();

            return Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/tarefa/concluidas
    [HttpGet]
    [Route("concluidas")]
    public IActionResult ListarConcluidas()
    {
        try
        {
            List<Tarefa> tarefas = _context.Tarefas.Include(x => x.Categoria).ToList();
            List<Tarefa> concluidas = new List<Tarefa>();

            foreach (Tarefa tarefaCadastrada in tarefas)
            {
                if (tarefaCadastrada.Status == "Concluída")
                {
                    concluidas.Add(tarefaCadastrada);
                }
            }

            return Ok(concluidas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/tarefa/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Tarefa tarefa)
    {
        try
        {
            Categoria? categoria = _context.Categorias.Find(tarefa.CategoriaId);
            if (categoria == null)
            {
                return NotFound();
            }
            tarefa.Categoria = categoria;
            tarefa.Status = "Não iniciada";
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Created("", tarefa);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id)
    {
        Tarefa? tarefa = _context.Tarefas.Find(id);
        if (tarefa == null)
            return NotFound();

        if (tarefa.Status == "Não iniciada")
            tarefa.Status = "Em andamento";
        else
            tarefa.Status = "Concluída";

        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
        return Ok(tarefa);
    }
}
