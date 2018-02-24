using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lab3
{
	class MethodDto
	{
		public string AccessModifier { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public VirtualDto IsVirtual { get; set; }
		public List<ArgumentDto> Arguments { get; set; }

		public MethodDto(MethodInfo info)
		{
			AccessModifier = Access.GetAccess(info);
			Name = info.Name;
			Type = info.ReturnType.Name;
			IsVirtual = new VirtualDto(info);
			Arguments = info.GetParameters()
				.Select(x => new ArgumentDto(x))
				.ToList();
		}

		public TreeNode ToTree()
		{
			return new TreeNode(Name, new[]
			{
				new TreeNode(AccessModifier),
				new TreeNode(Name),
				new TreeNode(Type),
				IsVirtual.ToTree(),
				new TreeNode("Arguments", Arguments
					.Select(x => x.ToTree())
					.ToArray())
			});
		}
	}
}
