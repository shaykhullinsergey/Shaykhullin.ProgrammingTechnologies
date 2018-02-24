using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnTask1(object sender, EventArgs e) =>
			result.Text = new Regex("^0x[0-9a-fA-F]{1,8}$")
				.IsMatch(task1.Text)
				.ToString();

		private void OnTask2(object sender, EventArgs e) =>
			result.Text = new Regex(@"^([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$")
				.IsMatch(task2.Text)
				.ToString();


		private void OnTask3(object sender, EventArgs e) =>
			result.Text = string.Join("  -|-  ",
				new Regex("\\b[A-Z][a-z]+\\b")
					.Matches(task3.Text)
					.OfType<Match>()
					.Select(m => m.Value)
					.ToArray());
	}
}
