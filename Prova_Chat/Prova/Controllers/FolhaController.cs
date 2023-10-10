using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Models;

[Route("api/folha")]
[ApiController]
public class FolhaController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public FolhaController(AppDataContext ctx) =>
        _ctx = ctx;

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Folha> folhas = _ctx.Folhas
                    .Include(f => f.Funcionario)
                    .ToList();

        if (folhas.Count == 0)
        {
            return NotFound();
        }
        return Ok(folhas);
    }

    [HttpGet()]
    [Route("buscar/{cpf}/{mes}/{ano}")]
    public IActionResult GetFolhaPorCPFAnoMes([FromRoute] string cpf,
        [FromRoute] int mes, [FromRoute] int ano)
    {
        Folha? folha = _ctx.Folhas
            .Include(f => f.Funcionario)
            .FirstOrDefault(f => f.Funcionario.CPF == cpf &&
                f.Ano == ano &&
                f.Mes == mes);
        if (folha == null)
        {
            return NotFound();
        }
        return Ok(folha);
    }


    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Folha folha)
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
}
