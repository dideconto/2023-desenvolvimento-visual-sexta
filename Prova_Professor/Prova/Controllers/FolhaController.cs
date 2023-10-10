
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Models;

[ApiController]
[Route("api/folha")]
public class FolhaController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FolhaController(AppDataContext context) =>
        _ctx = context;

    // POST: api/folha/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public ActionResult Cadastrar([FromBody] Folha folha)
    {
        try
        {
            Funcionario? funcionario = _ctx.Funcionarios.Find(folha.FuncionarioId);
            if (funcionario == null)
            {
                return NotFound();
            }
            folha.Funcionario = funcionario;
            _ctx.Folhas.Add(folha);
            _ctx.SaveChanges();
            return Created("", folha);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/folha/listar
    [HttpGet]
    [Route("listar")]
    public ActionResult Listar()
    {
        try
        {
            List<Folha> folhas = _ctx.Folhas.Include(x => x.Funcionario).ToList();
            return folhas.Count == 0 ? NotFound() : Ok(folhas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    // GET: api/folha/buscar
    [HttpGet]
    [Route("buscar/{cpf}/{mes}/{ano}")]
    public ActionResult Buscar(string cpf, int mes, int ano)
    {
        try
        {
            Folha? folha = _ctx.Folhas
                .Include(x => x.Funcionario)
                .FirstOrDefault(x => x.Funcionario!.Cpf == cpf &&
                    x.Mes == mes && x.Ano == ano);
            if (folha == null)
            {
                return NotFound();
            }
            return Ok(folha);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}