using System.Reflection;
using System.Windows.Forms;

namespace Lab3
{
	class VirtualDto
	{
		public bool IsVirtual { get; set; }
		public string DefinitionType { get; set; }

		public VirtualDto(MethodInfo info)
		{
			IsVirtual = info.IsVirtual;
			DefinitionType = info.DeclaringType.Name;
		}

		public TreeNode ToTree()
		{
			return new TreeNode("Virtuality", new[]
			{
				new TreeNode("IsVirtual", new[] {new TreeNode(IsVirtual.ToString())}),
				new TreeNode("DefinitionType", new[] {new TreeNode(DefinitionType)}),
			});
		}
	}
}
