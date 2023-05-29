using ApiCadastro.Data.Map;
using ApiCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastro.Data
{
	public class TaskDBContext: DbContext
	{
		public TaskDBContext(DbContextOptions<TaskDBContext> options) 
			:base(options)
		{
		}
		public DbSet<UserModel> Users { get; set; }
		public DbSet<TaskModel> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMap());
			modelBuilder.ApplyConfiguration(new TaskMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
