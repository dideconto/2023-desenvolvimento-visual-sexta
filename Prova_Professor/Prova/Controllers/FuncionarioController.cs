
using Microsoft.AspNetCore.Mvc;
using Prova.Data;
using Prova.Models;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FuncionarioController(AppDataContext context) =>
        _ctx = context;

    // POST: api/funcionario/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Funcionario funcionario)
    {
        try
        {
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();
            return Created("", funcionario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/funcionario/listar
    [HttpGet]
    [Route("listar")]
    public ActionResult Listar()
    {
        try
        {
            List<Funcionario> funcionarios = _ctx.Funcionarios.ToList();
            return funcionarios.Count == 0 ? NotFound() : Ok(funcionarios);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}