using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lab1
{
	public partial class MainWindow : Form
  {
		public MainWindow()
    {
      InitializeComponent();
    }

		public string GetManagedString()
		{
			return "Managed string: Шайхуллин Сергей ИСБО-11-16";
		}

		private void button1_Click(object sender, EventArgs e) => Show(this.GetManagedString());
		private void button2_Click(object sender, EventArgs e) => Show(new Library.LibraryClass().GetManagedString());
		private void button3_Click(object sender, EventArgs e) => Show(new ManagedLibrary.LibraryClass().GetManagedString());
		private void button4_Click(object sender, EventArgs e) => Show(DynamicManaged.GetManagedString());
		private void button5_Click(object sender, EventArgs e) => Show(StaticUnmanaged.GetUnmanagedString());
		private void button6_Click(object sender, EventArgs e) => Show(NativeMethods.GetUnmanagedString());

		private void Show(string message) => MessageBox.Show(message);
	}
}
