using ApiCadastro.Data;
using ApiCadastro.Models;
using ApiCadastro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastro.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		private readonly TaskDBContext _dbContext;
		public TaskRepository(TaskDBContext taskDBContext)
		{
			_dbContext = taskDBContext;
		}

		public async Task<List<TaskModel>> GetAll()
		{
			return await _dbContext.Tasks
				.Include(x => x.User)
				.ToListAsync();
		}

		public async Task<TaskModel> GetById(int id)
		{
			return await _dbContext.Tasks
				.Include(x => x.User)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<TaskModel> Add(TaskModel task)
		{
			await _dbContext.Tasks.AddAsync(task);
			await _dbContext.SaveChangesAsync();

			return task;
		}
		public async Task<TaskModel> Update(TaskModel task, int id)
		{
			TaskModel taskById = await GetById(id);

			if(taskById == null)
			{
				throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
			}

			taskById.Name = task.Name;
			taskById.Description = task.Description;
			taskById.Status = task.Status;
			taskById.UserId = task.UserId;

			_dbContext.Tasks.Update(taskById);
			await _dbContext.SaveChangesAsync();

			return taskById;
		}

		public async Task<bool> Delete(int id)
		{
			TaskModel taskById = await GetById(id);

			if (taskById == null)
			{
				throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados");
			}

			_dbContext.Tasks.Remove(taskById);
			await _dbContext.SaveChangesAsync();

			return true;
		}

	}
}
