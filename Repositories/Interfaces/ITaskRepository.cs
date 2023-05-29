﻿using ApiCadastro.Models;

namespace ApiCadastro.Repositories.Interfaces
{
	public interface ITaskRepository
	{
		Task<List<TaskModel>> GetAll();
		Task<TaskModel> GetById(int id);
		Task<TaskModel> Add(TaskModel task);
		Task<TaskModel> Update(TaskModel task, int id);
		Task<bool> Delete(int id);
	}
}
