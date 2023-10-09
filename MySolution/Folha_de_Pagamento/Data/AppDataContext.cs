
using Folha_de_Pagamento.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }

    //Classes que vão se tornar tabelas no banco de dados
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FolhaDePagamento> FolhaDePagamentos { get; set; }
}