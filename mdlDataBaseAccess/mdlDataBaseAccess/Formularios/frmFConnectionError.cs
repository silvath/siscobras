using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlDataBaseAccess.Formularios
{
	/// <summary>
	/// Summary description for frmFConnectionError.
	/// </summary>
	public class frmFConnectionError : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btFechar;
			private System.Windows.Forms.Label m_lbInfo;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors 
			public frmFConnectionError()
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConnectionError));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btFechar = new System.Windows.Forms.Button();
			this.m_lbInfo = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btFechar);
			this.m_gbGeral.Controls.Add(this.m_lbInfo);
			this.m_gbGeral.Location = new System.Drawing.Point(1, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(287, 75);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btFechar
			// 
			this.m_btFechar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btFechar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFechar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btFechar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFechar.Image = ((System.Drawing.Image)(resources.GetObject("m_btFechar.Image")));
			this.m_btFechar.Location = new System.Drawing.Point(114, 44);
			this.m_btFechar.Name = "m_btFechar";
			this.m_btFechar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFechar.Size = new System.Drawing.Size(57, 25);
			this.m_btFechar.TabIndex = 9;
			this.m_btFechar.Click += new System.EventHandler(this.m_btFechar_Click);
			// 
			// m_lbInfo
			// 
			this.m_lbInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfo.Location = new System.Drawing.Point(11, 14);
			this.m_lbInfo.Name = "m_lbInfo";
			this.m_lbInfo.Size = new System.Drawing.Size(269, 34);
			this.m_lbInfo.TabIndex = 10;
			this.m_lbInfo.Text = "Houve falhas na conexão com  banco de dados.  É possível que o mesmo esteja inace" +
				"ssível.";
			// 
			// frmFConnectionError
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 80);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConnectionError";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras";
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Botoes
				private void m_btFechar_Click(object sender, System.EventArgs e)
				{
                    this.Close();				
				}
			#endregion
		#endregion
	}
}
