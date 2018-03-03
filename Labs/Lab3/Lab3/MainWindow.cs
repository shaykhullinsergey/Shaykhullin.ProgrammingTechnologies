using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnGenerate(object sender, EventArgs e)
		{
			if(string.IsNullOrWhiteSpace(textBox1.Text))
			{
				MessageBox.Show("Empty string!");
				return;
			}

			var type = AppDomain.CurrentDomain.GetAssemblies()
				.Select(x => x.GetType(textBox1.Text))
				.FirstOrDefault(x => x != null);

			if(type == null)
			{
				MessageBox.Show("Type not found!");
				return;
			}

			classTree.Nodes.Add(new TypeDto(type).ToTree());
		}
	}
}
