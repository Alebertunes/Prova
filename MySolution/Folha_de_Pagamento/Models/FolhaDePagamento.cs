namespace Folha_de_Pagamento.Models;
public class FolhaDePagamento
{
    public int FolhaDePagamentoId { get; set; }
    public double? Valor { get; set; }
    public double? Quantidade { get; set; }
    public int? Mes { get; set; }
    public int? Ano { get; set; }
    public double? salarioBruto { get; set; }
    public double? impostoIrrf { get; set; }
    public double? impostoInss { get; set; }
    public double? impostoFgts { get; set; }
    public double? SalarioLiquido { get; set; }
    public Funcionario? Funcionario { get; set; }
    public int? FuncionarioId { get; set; }

}