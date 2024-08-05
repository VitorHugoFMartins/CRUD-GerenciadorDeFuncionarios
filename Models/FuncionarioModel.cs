using GerenciadorDeFuncionários.Enums;
using System.ComponentModel.DataAnnotations;
namespace GerenciadorDeFuncionários.Models
{
	public class FuncionarioModel
	{
		[Key]
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Sobrenome { get; set; }
		public DepartamentoEnum Departamento { get; set; }
        public StatusEnum Status { get; set; }
        public TurnoEnum Turno { get; set; }
		public DateTime DataDeCricao { get; set; } = DateTime.Now.ToLocalTime();
		public DateTime DataDeAltercao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
