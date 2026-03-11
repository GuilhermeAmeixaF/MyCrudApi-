using Microsoft.EntityFrameworkCore;

namespace MyCrudApi.Models;

public class AppDbContext : DbContext
{
    //CONSTRUCTO QUE RECEBE AS OPCOES DO BANCO (CONFIGURADAS NO Program.cs)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    // DbSet representa a tabela "Produtos" no BANCO
    public DbSet<Produto> Produtos { get; set; }
}
