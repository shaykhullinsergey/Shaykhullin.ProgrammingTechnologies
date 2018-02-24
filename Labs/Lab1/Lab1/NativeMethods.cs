using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lab1
{
	static class DynamicUnmanaged
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void Func6Delegate([MarshalAs(UnmanagedType.BStr)]out string data);


		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		[DllImport("kernel32.dll")]
		public static extern Int32 GetLastError();

		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);

		public static string GetUnmanagedString()
		{
			var dllPtr = LoadLibrary(Application.StartupPath + "\\unmlib2.dll");
			var methodPtr = GetProcAddress(dllPtr, "Func6");

			var unmanagedStringMethod = (Func6Delegate)Marshal.GetDelegateForFunctionPointer(methodPtr, typeof(Func6Delegate));
			unmanagedStringMethod(out string str1);

			FreeLibrary(dllPtr);

			return str1;
		}
	}
}
