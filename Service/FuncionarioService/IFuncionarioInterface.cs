using GerenciadorDeFuncionários.Models;

namespace GerenciadorDeFuncionários.Service.FuncionarioService
{
	public interface IFuncionarioInterface
	{
		Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
		Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
		Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
		Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editarFuncionario);
		Task<ServiceResponse<List<FuncionarioModel>>> RemoverUsuario(int id);
		Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionario(int id);

	}
}
