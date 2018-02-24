using System.Reflection;
using System.Windows.Forms;

namespace Lab3
{
	class FieldDto
	{
		public string AccessModifier { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }

		public FieldDto(FieldInfo x)
		{
			if (x.IsPublic)
			{
				AccessModifier = "Public";
			}
			else if (x.IsPrivate)
			{
				AccessModifier = "Private";
			}
			else if (x.IsFamily)
			{
				AccessModifier = "Protected";
			}
			else if(x.IsFamilyAndAssembly)
			{
				AccessModifier = "Internal";
			}
			else if(x.IsFamilyOrAssembly)
			{
				AccessModifier = "Protected internal";
			}

			Name = x.Name;
			Type = x.DeclaringType.Name;
		}

		public TreeNode ToTree()
		{
			return new TreeNode(Name, new[]
			{
				new TreeNode("AccessModifier", new[]{ new TreeNode(AccessModifier)}),
				new TreeNode("Name", new[]{ new TreeNode(Name) }),
				new TreeNode("Type", new[]{ new TreeNode(Type) }),
			});
		}
	}
}
