using System;
using System.Windows.Forms;

namespace Lab3
{
	class TypeDto
	{
		public string Name { get; set; }
		public string BaseTypeName { get; set; }
		public string Namespace { get; set; }
		public string AssemblyName { get; set; }
		public PublicInterfaceDto PublicInterface { get; set; }
		public ImplementedInterfaceDto ImplementedInterface { get; set; }

		public TypeDto BaseType { get; set; }

		public TypeDto(Type type)
		{
			Name = type.Name;
			BaseTypeName = type.BaseType?.Name;
			Namespace = type.Namespace;
			AssemblyName = type.Assembly.FullName;
			PublicInterface = new PublicInterfaceDto(type);
			ImplementedInterface = new ImplementedInterfaceDto(type);

			if (type.BaseType != null)
			{
				BaseType = new TypeDto(type.BaseType);
			}
		}

		public TreeNode ToTree()
		{
			return new TreeNode(Name, new[]
			{
				new TreeNode("Name", new[] { new TreeNode(Name) }),
				new TreeNode("BaseTypeName", new[] { new TreeNode(BaseTypeName) }),
				new TreeNode("Namespace", new[] { new TreeNode(Namespace) }),
				new TreeNode("AssemblyName", new[] { new TreeNode(AssemblyName) }),
				PublicInterface.ToTree(),
				ImplementedInterface.ToTree(),
				BaseType?.ToTree() ?? new TreeNode("Empty base type")
			});
		}
	}
}
