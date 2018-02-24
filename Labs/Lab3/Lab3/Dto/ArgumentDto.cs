using System.Reflection;
using System.Windows.Forms;

namespace Lab3
{
	class ArgumentDto
	{
		public string Name { get; set; }
		public string Type { get; set; }

		public ArgumentDto(ParameterInfo x)
		{
			Name = x.Name;
			Type = x.ParameterType.Name;
		}

		public TreeNode ToTree()
		{
			return new TreeNode(Name, new[]
			{
				new TreeNode(Name),
				new TreeNode(Type)
			});
		}
	}
}
