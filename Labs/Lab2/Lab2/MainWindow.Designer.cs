namespace Lab2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.axShockwaveFlash1);
			this.groupBox1.Location = new System.Drawing.Point(43, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1221, 682);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// axShockwaveFlash1
			// 
			this.axShockwaveFlash1.Enabled = true;
			this.axShockwaveFlash1.Location = new System.Drawing.Point(413, 363);
			this.axShockwaveFlash1.Name = "axShockwaveFlash1";
			this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
			this.axShockwaveFlash1.Size = new System.Drawing.Size(412, 338);
			this.axShockwaveFlash1.TabIndex = 0;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1315, 745);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainWindow";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
	}
}

