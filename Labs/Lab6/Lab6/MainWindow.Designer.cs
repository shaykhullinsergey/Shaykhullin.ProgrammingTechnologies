namespace Lab6
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.task1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.task2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.task3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.result = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// task1
			// 
			this.task1.Location = new System.Drawing.Point(12, 35);
			this.task1.Name = "task1";
			this.task1.Size = new System.Drawing.Size(547, 20);
			this.task1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Хекс";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Домен";
			// 
			// task2
			// 
			this.task2.Location = new System.Drawing.Point(12, 86);
			this.task2.Name = "task2";
			this.task2.Size = new System.Drawing.Size(547, 20);
			this.task2.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Все имена";
			// 
			// task3
			// 
			this.task3.Location = new System.Drawing.Point(12, 138);
			this.task3.Name = "task3";
			this.task3.Size = new System.Drawing.Size(547, 20);
			this.task3.TabIndex = 5;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(565, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Run";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnTask1);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(565, 84);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Run";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.OnTask2);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(565, 137);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Run";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.OnTask3);
			// 
			// result
			// 
			this.result.Location = new System.Drawing.Point(12, 209);
			this.result.Multiline = true;
			this.result.Name = "result";
			this.result.Size = new System.Drawing.Size(628, 297);
			this.result.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 193);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Результат";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 518);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.result);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.task3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.task2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.task1);
			this.Name = "Form1";
			this.Text = "Шайхуллин Сергей ИСБО-11-16";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox task1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox task2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox task3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox result;
		private System.Windows.Forms.Label label4;
	}
}

