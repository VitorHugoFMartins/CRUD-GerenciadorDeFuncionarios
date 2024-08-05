using GerenciadorDeFuncionários.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeFuncionários.DataContext
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }

    }
}
