using API.Data;
using Folha_de_Pagamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/folha")]
public class FolhaPagamentoController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public FolhaPagamentoController(AppDataContext context)
    {
        _ctx = context;
    }

    // GET: api/folha/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<FolhaDePagamento> folhaDePagamentos = _ctx.FolhaDePagamentos.Include(x => x.Funcionario).ToList();
            return Ok(folhaDePagamentos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    //GET: api/folha/buscar
    [HttpGet]
    [Route("buscar/{cpf}/{mes}/{ano}")]
    public IActionResult buscarFolha(string? cpf, int? mes, int? ano)
    {
        try
        {
            FolhaDePagamento? folhaDePagamentos = _ctx.FolhaDePagamentos.Include(x => x.Funcionario)
            .FirstOrDefault(x => x.Funcionario.Cpf == cpf && x.Mes == mes && x.Ano == ano);
            return Ok(folhaDePagamentos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // POST: api/categoria/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] FolhaDePagamento folhaDePagamento)
    {
        try
        {
            Funcionario? funcionario =
                _ctx.Funcionarios.Find(folhaDePagamento.FuncionarioId);
            if (funcionario == null)
            {
                return NotFound();
            }
            folhaDePagamento.Funcionario = funcionario;

            folhaDePagamento.salarioBruto = folhaDePagamento.Quantidade * folhaDePagamento.Valor;
            
            double? impostoRenda = null;
            if (folhaDePagamento.salarioBruto <= 1903.98)
            {
                impostoRenda = 0;
            }else if(folhaDePagamento.salarioBruto <= 2826.65){
                impostoRenda = (folhaDePagamento.salarioBruto / 100)*7.5 - 142.80;
            }else if(folhaDePagamento.salarioBruto <= 3751.05){
                impostoRenda = (folhaDePagamento.salarioBruto / 100)*15 - 354.80;
            }else if(folhaDePagamento.salarioBruto <= 4664.68){
                impostoRenda = (folhaDePagamento.salarioBruto / 100)*22.5 - 636.13;
            }else{
                impostoRenda = (folhaDePagamento.salarioBruto / 100)*27.5 - 869.36;
            }
            folhaDePagamento.impostoIrrf = impostoRenda;

            double? impostoInss = null;
             if (folhaDePagamento.salarioBruto <= 1693.72)
            {
                impostoInss = (folhaDePagamento.salarioBruto / 100)*8;
            }else if(folhaDePagamento.salarioBruto <= 2822.90){
                impostoInss = (folhaDePagamento.salarioBruto / 100)*9;
            }else if(folhaDePagamento.salarioBruto <= 5645.80){
                impostoInss = (folhaDePagamento.salarioBruto / 100)*11;
            }else{
                impostoInss = 621.03;
            }
            folhaDePagamento.impostoInss = impostoInss;

            folhaDePagamento.impostoFgts = (folhaDePagamento.salarioBruto / 100)*8;

            folhaDePagamento.SalarioLiquido = folhaDePagamento.salarioBruto -impostoRenda - impostoInss;

            _ctx.FolhaDePagamentos.Add(folhaDePagamento);
            _ctx.SaveChanges();
            return Created("", folhaDePagamento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}