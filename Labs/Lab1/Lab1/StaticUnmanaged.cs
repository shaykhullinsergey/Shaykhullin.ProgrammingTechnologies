using System.Runtime.InteropServices;

namespace Lab1
{
	static class StaticUnmanaged
	{
		[DllImport("unmlib1.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern void Func5([MarshalAs(UnmanagedType.BStr)]out string data);

		public static string GetUnmanagedString()
		{
			Func5(out string data);
			return data;
		}
	}
}
