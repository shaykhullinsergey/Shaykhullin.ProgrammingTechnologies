using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab3
{
	class ImplementedInterfaceDto
	{
		public List<FieldDto> Fields { get; set; }
		public List<PropertyDto> Properties { get; set; }
		public List<MethodDto> Methods { get; set; }

		public ImplementedInterfaceDto(Type type)
		{
			Fields = type.GetFields()
				.Select(fieldInfo => new FieldDto(fieldInfo))
				.ToList();

			Properties = type.GetProperties()
				.Select(propertyInfo => new PropertyDto(propertyInfo))
				.ToList();

			Methods = type.GetMethods()
				.Select(methodInfo => new MethodDto(methodInfo))
				.ToList();
		}

		public TreeNode ToTree()
		{
			return new TreeNode("Implemented", new[]
			{
				new TreeNode("Fields", Fields
					.Select(x => x.ToTree())
					.ToArray()),

				new TreeNode("Properties",
					Properties
						.Select(x => x.ToTree())
						.ToArray()),

				new TreeNode("Methods", Methods
					.Select(x => x.ToTree())
					.ToArray())
			});
		}
	}
}
