using API.Data;
using Folha_de_Pagamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/funcionario")]
public class FuncionarioController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FuncionarioController(AppDataContext ctx)
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
            List<Funcionario> funcionarios =
                _ctx.Funcionarios
                .ToList();
            return funcionarios.Count == 0 ? NotFound() : Ok(funcionarios);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Funcionario funcionario)
    {
        try
        {
            _ctx.Funcionarios.Add(funcionario);
            _ctx.SaveChanges();
            return Created("", funcionario);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

   
}