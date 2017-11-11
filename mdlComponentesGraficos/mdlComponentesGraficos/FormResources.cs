using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for FormResources.
	/// </summary>
	public class FormResources : System.Windows.Forms.Form
	{
		#region Atributes

		private System.Windows.Forms.PictureBox m_picCancelLeave;
		private System.Windows.Forms.PictureBox m_picCancelEnter;
		private System.Windows.Forms.PictureBox m_picOkEnter;
		private System.Windows.Forms.PictureBox m_picOkLeave;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Drawing.Image ImageOkEnter
			{
				get
				{
					return(m_picOkEnter.Image);
				}
			}

			public System.Drawing.Image ImageOkLeave
			{
				get
				{
					return(m_picOkLeave.Image);
				}
			}

			public System.Drawing.Image ImageCancelEnter
			{
				get
				{
					return(m_picCancelEnter.Image);
				}
			}

			public System.Drawing.Image ImageCancelLeave
			{
				get
				{
					return(m_picCancelLeave.Image);
				}
			}
		#endregion
		#region Constructors
			public FormResources()
			{
				InitializeComponent();
			}

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormResources));
			this.m_picCancelLeave = new System.Windows.Forms.PictureBox();
			this.m_picCancelEnter = new System.Windows.Forms.PictureBox();
			this.m_picOkEnter = new System.Windows.Forms.PictureBox();
			this.m_picOkLeave = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// m_picCancelLeave
			// 
			this.m_picCancelLeave.Image = ((System.Drawing.Image)(resources.GetObject("m_picCancelLeave.Image")));
			this.m_picCancelLeave.Location = new System.Drawing.Point(24, 48);
			this.m_picCancelLeave.Name = "m_picCancelLeave";
			this.m_picCancelLeave.Size = new System.Drawing.Size(64, 24);
			this.m_picCancelLeave.TabIndex = 0;
			this.m_picCancelLeave.TabStop = false;
			// 
			// m_picCancelEnter
			// 
			this.m_picCancelEnter.Image = ((System.Drawing.Image)(resources.GetObject("m_picCancelEnter.Image")));
			this.m_picCancelEnter.Location = new System.Drawing.Point(24, 16);
			this.m_picCancelEnter.Name = "m_picCancelEnter";
			this.m_picCancelEnter.Size = new System.Drawing.Size(64, 24);
			this.m_picCancelEnter.TabIndex = 1;
			this.m_picCancelEnter.TabStop = false;
			// 
			// m_picOkEnter
			// 
			this.m_picOkEnter.Image = ((System.Drawing.Image)(resources.GetObject("m_picOkEnter.Image")));
			this.m_picOkEnter.Location = new System.Drawing.Point(114, 16);
			this.m_picOkEnter.Name = "m_picOkEnter";
			this.m_picOkEnter.Size = new System.Drawing.Size(64, 24);
			this.m_picOkEnter.TabIndex = 2;
			this.m_picOkEnter.TabStop = false;
			// 
			// m_picOkLeave
			// 
			this.m_picOkLeave.Image = ((System.Drawing.Image)(resources.GetObject("m_picOkLeave.Image")));
			this.m_picOkLeave.Location = new System.Drawing.Point(114, 48);
			this.m_picOkLeave.Name = "m_picOkLeave";
			this.m_picOkLeave.Size = new System.Drawing.Size(64, 24);
			this.m_picOkLeave.TabIndex = 3;
			this.m_picOkLeave.TabStop = false;
			// 
			// FormResources
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.m_picOkLeave);
			this.Controls.Add(this.m_picOkEnter);
			this.Controls.Add(this.m_picCancelEnter);
			this.Controls.Add(this.m_picCancelLeave);
			this.Name = "FormResources";
			this.Text = "FormResources";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
