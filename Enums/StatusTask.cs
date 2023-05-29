using System.ComponentModel;

namespace ApiCadastro.Enums
{
	public enum StatusTask
	{
		[Description("A fazer")]
		ToDo = 1,

		[Description("Em andamento")]
		InProgress = 2,

		[Description("Concluído")]
		Concluded = 3,
	}
}
