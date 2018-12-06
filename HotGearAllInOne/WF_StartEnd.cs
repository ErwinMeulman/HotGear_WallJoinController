using HotGearAllInOne.Globol;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class WF_StartEnd : Form
	{
		internal int count = 0;

		private IContainer components = null;

		private CheckBox Start;

		private CheckBox End;

		private Label label1;

		private Button button1;

		private ToolTip toolTip1;

		private Label label2;

		public WF_StartEnd()
		{
			this.InitializeComponent();
			this.label2.Text = "Wall Join Type : " + GlobolVar.G_JoinWay;
			this.Start.Checked = true;
			this.End.Checked = true;
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			if (this.count == 0)
			{
				GlobolVar.G_JoinStatus = -1;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GlobolVar.G_JoinStatus = -1;
			if (this.Start.Checked && this.End.Checked)
			{
				GlobolVar.G_JoinStatus = 0;
			}
			else if (this.Start.Checked && !this.End.Checked)
			{
				GlobolVar.G_JoinStatus = 1;
			}
			else if (!this.Start.Checked && this.End.Checked)
			{
				GlobolVar.G_JoinStatus = 2;
			}
			else
			{
				GlobolVar.G_JoinStatus = -1;
			}
			this.count++;
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.Start = new CheckBox();
			this.End = new CheckBox();
			this.label1 = new Label();
			this.button1 = new Button();
			this.toolTip1 = new ToolTip(this.components);
			this.label2 = new Label();
			base.SuspendLayout();
			this.Start.AutoSize = true;
			this.Start.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Start.Location = new Point(12, 54);
			this.Start.Name = "Start";
			this.Start.Size = new Size(72, 17);
			this.Start.TabIndex = 0;
			this.Start.Text = "Start Side";
			this.toolTip1.SetToolTip(this.Start, "Check = Effect on this Side");
			this.Start.UseVisualStyleBackColor = true;
			this.End.AutoSize = true;
			this.End.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.End.Location = new Point(90, 54);
			this.End.Name = "End";
			this.End.Size = new Size(69, 17);
			this.End.TabIndex = 1;
			this.End.Text = "End Side";
			this.toolTip1.SetToolTip(this.End, "Check = Effect on this Side");
			this.End.UseVisualStyleBackColor = true;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(9, 33);
			this.label1.Name = "label1";
			this.label1.Size = new Size(64, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Side Setting";
			this.button1.FlatStyle = FlatStyle.Flat;
			this.button1.Location = new Point(12, 84);
			this.button1.Name = "button1";
			this.button1.Size = new Size(140, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(9, 9);
			this.label2.Name = "label2";
			this.label2.Size = new Size(51, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Join Way";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(164, 119);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.End);
			base.Controls.Add(this.Start);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "WF_StartEnd";
			this.Text = "Wall Join Controller";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
