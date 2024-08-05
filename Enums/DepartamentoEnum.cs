using System.Text.Json.Serialization;

namespace GerenciadorDeFuncionários.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum DepartamentoEnum
	{
		RH,
		Financeiro,
		Compras,
		Atendimento,
		Zeladoria
	}
}
