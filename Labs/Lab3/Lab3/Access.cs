using System.Reflection;

namespace Lab3
{
	public static class Access
	{
		public static string GetAccess(MethodBase x)
		{
			if (x == null)
			{
				return null;
			}

			if (x.IsPublic)
			{
				return "Public";
			}
			else if (x.IsPrivate)
			{
				return "Private";
			}
			else if (x.IsFamily)
			{
				return "Protected";
			}
			else if (x.IsFamilyAndAssembly)
			{
				return "Internal";
			}
			else if (x.IsFamilyOrAssembly)
			{
				return "Protected internal";
			}

			return null;
		}
	}
}
