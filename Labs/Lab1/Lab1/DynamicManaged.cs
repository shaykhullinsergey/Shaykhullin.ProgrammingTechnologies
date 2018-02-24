using System;
using System.IO;
using System.Reflection;

namespace Lab1
{
	static class DynamicManaged
	{
		public static string GetManagedString()
		{
			var asm = Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, "Lab1.DynamicManagedLibrary.dll"));
			var type = asm.GetType("Lab1.DynamicManagedLibrary.LibraryClass");
			var m = type.GetMethod("GetManagedString", BindingFlags.Public | BindingFlags.Instance);
			return (string)m.Invoke(Activator.CreateInstance(type), null);
		}
	}
}
