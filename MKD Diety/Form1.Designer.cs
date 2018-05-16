/*
 * Created by SharpDevelop.
 * User: Martin Boor
 * Date: 13.10.2017
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MKD_Diety
{
	partial class Form1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label spzLabel;
		private System.Windows.Forms.Button dietButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.nameLabel = new System.Windows.Forms.Label();
			this.spzLabel = new System.Windows.Forms.Label();
			this.dietButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Načítať";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 59);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(961, 729);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			// 
			// nameLabel
			// 
			this.nameLabel.Location = new System.Drawing.Point(111, 13);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(100, 23);
			this.nameLabel.TabIndex = 2;
			this.nameLabel.Text = "Meno";
			// 
			// spzLabel
			// 
			this.spzLabel.Location = new System.Drawing.Point(273, 13);
			this.spzLabel.Name = "spzLabel";
			this.spzLabel.Size = new System.Drawing.Size(100, 23);
			this.spzLabel.TabIndex = 4;
			this.spzLabel.Text = "ŠPZ";
			// 
			// dietButton
			// 
			this.dietButton.Location = new System.Drawing.Point(847, 13);
			this.dietButton.Name = "dietButton";
			this.dietButton.Size = new System.Drawing.Size(127, 23);
			this.dietButton.TabIndex = 5;
			this.dietButton.Text = "Vytvor dietny list";
			this.dietButton.UseVisualStyleBackColor = true;
			this.dietButton.Click += new System.EventHandler(this.DietButtonClick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(986, 800);
			this.Controls.Add(this.dietButton);
			this.Controls.Add(this.spzLabel);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MKD Diety";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
