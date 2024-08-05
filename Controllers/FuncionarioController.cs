using GerenciadorDeFuncionários.Models;
using GerenciadorDeFuncionários.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeFuncionários.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FuncionarioController : ControllerBase
	{
		private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }
        [HttpGet]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
		{
			return Ok(await _funcionarioInterface.GetFuncionarios());
		}
		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateNewFuncionario(FuncionarioModel novoFuncionario)
		{
			return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
		{
			ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);
			return Ok(serviceResponse);
		}
		[HttpPut("StatusDoUsuário")]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> AtualizarStatus(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativarFuncionario(id);
			return Ok(serviceResponse);
		}
		[HttpPut("AtualizarFuncionário")]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editarFuncionario)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editarFuncionario);
			return Ok(serviceResponse);
		}
		[HttpDelete("DeletarUsuário")]
		public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> RemoverFuncionario(int id)
		{
			ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.RemoverUsuario(id);
			return Ok(serviceResponse);
		}
	}
}
