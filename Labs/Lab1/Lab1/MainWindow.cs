using System;
using System.Windows.Forms;

namespace Lab1
{
	public partial class MainWindow : Form
  {
		public MainWindow()
    {
      InitializeComponent();
    }

		public string GetManagedString() => "Managed string: Шайхуллин Сергей ИСБО-11-16";

		private void StaticManagedCurrentCurrent(object sender, EventArgs e) => Show(this.GetManagedString());
		private void StaticManagedCurrentOther(object sender, EventArgs e) => Show(new Library.LibraryClass().GetManagedString());
		private void StaticManagedOther(object sender, EventArgs e) => Show(new ManagedLibrary.LibraryClass().GetManagedString());
		private void DynamicManagedOther(object sender, EventArgs e) => Show(DynamicManaged.GetManagedString());
		private void StaticUnmanaged(object sender, EventArgs e) => Show(Lab1.StaticUnmanaged.GetUnmanagedString());
		private void DynamicUnmanaged(object sender, EventArgs e) => Show(Lab1.DynamicUnmanaged.GetUnmanagedString());

		private void Show(string message) => MessageBox.Show(message);
	}
}
