using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lab3
{
	class PublicInterfaceDto
	{
		public List<FieldDto> Fields { get; set; }
		public List<PropertyDto> Properties { get; set; }
		public List<MethodDto> Methods { get; set; }

		public PublicInterfaceDto(Type type)
		{
			Fields = GetFieldInfo(type)
				.Select(x => new FieldDto(x))
				.ToList();

			Properties = GetPropertyInfo(type)
				.Select(x => new PropertyDto(x))
				.ToList();

			Methods = GetMethodInfo(type)
				.Select(x => new MethodDto(x))
				.ToList();
		}

		private IEnumerable<FieldInfo> GetFieldInfo(Type type)
		{
			while (type != null)
			{
				foreach (var info in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
					yield return info;
				type = type.BaseType;
			}
		}

		private IEnumerable<PropertyInfo> GetPropertyInfo(Type type)
		{
			while (type != null)
			{
				foreach (var info in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
					yield return info;
				type = type.BaseType;
			}
		}

		private IEnumerable<MethodInfo> GetMethodInfo(Type type)
		{
			while (type != null)
			{
				foreach (var info in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
					yield return info;
				type = type.BaseType;
			}
		}

		public TreeNode ToTree()
		{
			return new TreeNode("Public Interface", new[]
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
