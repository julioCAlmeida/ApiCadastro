using ApiCadastro.Data;
using ApiCadastro.Models;
using ApiCadastro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastro.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly TaskDBContext _dbContext;
		public UserRepository(TaskDBContext taskDBContext)
		{
			_dbContext = taskDBContext;
		}

		public async Task<List<UserModel>> GetAll()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<UserModel> GetById(int id)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<UserModel> Add(UserModel usuario)
		{
			await _dbContext.Users.AddAsync(usuario);
			await _dbContext.SaveChangesAsync();

			return usuario;
		}
		public async Task<UserModel> Update(UserModel usuario, int id)
		{
			UserModel userById = await GetById(id);

			if(userById == null)
			{
				throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
			}

			userById.Name = usuario.Name;
			userById.Email = usuario.Email;

			_dbContext.Users.Update(userById);
			await _dbContext.SaveChangesAsync();

			return userById;
		}

		public async Task<bool> Delete(int id)
		{
			UserModel userById = await GetById(id);

			if (userById == null)
			{
				throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados");
			}

			_dbContext.Users.Remove(userById);
			await _dbContext.SaveChangesAsync();

			return true;
		}

	}
}
