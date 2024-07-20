using curso_api_part1.Model;
using Microsoft.EntityFrameworkCore;

namespace curso_api_part1.Data;

public class AppDbContext : DbContext
{
    public DbSet<Produtos> Produtos  { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "Data Source=ANDREY;Initial Catalog=ApiCategoriaCurso;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.Equals(optionsBuilder);
    }
}
