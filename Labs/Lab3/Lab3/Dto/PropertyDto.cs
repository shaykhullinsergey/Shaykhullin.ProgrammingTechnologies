using System.Reflection;
using System.Windows.Forms;

namespace Lab3
{
	class PropertyDto
	{
		public string AccessModifier { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public bool HasGet { get; set; }
		public bool HasSet { get; set; }

		public PropertyDto(PropertyInfo x)
		{
			var get = x.GetGetMethod();
			var set = x.GetSetMethod();

			AccessModifier = Access.GetAccess(get) ?? Access.GetAccess(set);
			Name = x.Name;
			Type = x.PropertyType.Name;
			HasGet = x.GetGetMethod() != null;
			HasSet = x.GetSetMethod() != null;
		}

		public TreeNode ToTree()
		{
			return new TreeNode(Name, new[]
			{
				new TreeNode("AccessModifier", new[]{ new TreeNode(AccessModifier)}),
				new TreeNode("Name", new[]{ new TreeNode(Name) }),
				new TreeNode("Type", new[]{ new TreeNode(Type) }),
				new TreeNode("HasGet", new[]{ new TreeNode(HasGet.ToString()) }),
				new TreeNode("HasSet", new[]{ new TreeNode(HasSet.ToString()) })
			});
		}
	}
}
