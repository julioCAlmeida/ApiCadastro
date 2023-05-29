using ApiCadastro.Models;

namespace ApiCadastro.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAll();
		Task<UserModel> GetById(int id);
		Task<UserModel> Add(UserModel model);
		Task<UserModel> Update(UserModel model, int id);
		Task<bool> Delete(int id);
	}
}
