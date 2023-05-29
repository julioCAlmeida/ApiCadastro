using ApiCadastro.Models;
using ApiCadastro.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly ITaskRepository _taskRepository;

		public TaskController(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
		{
			List<TaskModel> tasks = await _taskRepository.GetAll();

			return Ok(tasks);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<TaskModel>> GetById(int id)
		{ 
			TaskModel task = await _taskRepository.GetById(id);

			return Ok(task);
		}
		[HttpPost]
		public async Task<ActionResult<TaskModel>> Add([FromBody] TaskModel taskModel)
		{

			TaskModel task = await _taskRepository.Add(taskModel);

			Console.WriteLine(task.ToString());

			return Ok(task);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
		{
			taskModel.Id = id;
			TaskModel task = await _taskRepository.Update(taskModel, id);

			return Ok(task);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<TaskModel>> Delete(int id)
		{
			Boolean deleted = await _taskRepository.Delete(id);

			return Ok(deleted);
		}
	}
}
