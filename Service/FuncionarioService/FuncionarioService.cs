using GerenciadorDeFuncionários.DataContext;
using GerenciadorDeFuncionários.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeFuncionários.Service.FuncionarioService
{
	public class FuncionarioService : IFuncionarioInterface
	{
		private readonly ApplicationDbContext _context;
		public FuncionarioService(ApplicationDbContext dbContext)
		{
			_context = dbContext;
		}
		public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				if (novoFuncionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Informe os dados corretamente";
					serviceResponse.Sucesso = false;
					return serviceResponse;
				}
				_context.Add(novoFuncionario);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();
			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}
			return serviceResponse;
		}

		public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
		{
			ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
			try
			{
				FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não localizado";
					serviceResponse.Sucesso = false;
				}

				serviceResponse.Dados = funcionario;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
			try
			{
				serviceResponse.Dados = _context.Funcionarios.ToList();
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionarioModel = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
				if (funcionarioModel == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Informe os dados corretamente";
					serviceResponse.Sucesso = false;
					return serviceResponse;
				}

				funcionarioModel.Status = funcionarioModel.Status;
				funcionarioModel.DataDeAltercao = DateTime.Now.ToLocalTime();

				_context.Funcionarios.Update(funcionarioModel);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();
			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> RemoverUsuario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
				if (funcionario == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Usuário não encontrado";
					serviceResponse.Sucesso = false;
				}
				_context.Funcionarios.Remove(funcionario);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();


			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editarFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

			try
			{
				FuncionarioModel funcionarioModel = _context.Funcionarios.FirstOrDefault(x => x.Id == editarFuncionario.Id);
				if (funcionarioModel == null)
				{
					serviceResponse.Dados = null;
					serviceResponse.Mensagem = "Informe os dados corretamente";
					serviceResponse.Sucesso = false;
					return serviceResponse;
				}

				funcionarioModel.Name = editarFuncionario.Name;
				funcionarioModel.Sobrenome = editarFuncionario.Sobrenome;
				funcionarioModel.Turno = editarFuncionario.Turno;
				funcionarioModel.Status = editarFuncionario.Status;
				funcionarioModel.Departamento = editarFuncionario.Departamento;

				funcionarioModel.DataDeAltercao = DateTime.Now.ToLocalTime();

				_context.Funcionarios.Update(funcionarioModel);
				await _context.SaveChangesAsync();

				serviceResponse.Dados = _context.Funcionarios.ToList();
			}
			catch (Exception ex)
			{
				serviceResponse.Mensagem = ex.Message;
				serviceResponse.Sucesso = false;
			}

			return serviceResponse;
		}
	}
}
