using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace mdlPreferencias
{
	/// <summary>
	/// Summary description for usrCtrlAtualizacoes.
	/// </summary>
	public class usrCtrlAtualizacoes : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate string delCallCarregaDados();
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaDados != null)
					m_txtAtualizacoes.Text = eCallCarregaDados();
				else
					m_txtAtualizacoes.Text = "";
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.Label m_lbAtualizacoes;
			private mdlComponentesGraficos.TextBox m_txtAtualizacoes;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public usrCtrlAtualizacoes()
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_lbAtualizacoes = new System.Windows.Forms.Label();
			this.m_txtAtualizacoes = new mdlComponentesGraficos.TextBox();
			this.SuspendLayout();
			// 
			// m_lbAtualizacoes
			// 
			this.m_lbAtualizacoes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAtualizacoes.Location = new System.Drawing.Point(85, 8);
			this.m_lbAtualizacoes.Name = "m_lbAtualizacoes";
			this.m_lbAtualizacoes.Size = new System.Drawing.Size(217, 24);
			this.m_lbAtualizacoes.TabIndex = 8;
			this.m_lbAtualizacoes.Text = "Atualizações e Ampliações";
			// 
			// m_txtAtualizacoes
			// 
			this.m_txtAtualizacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtAtualizacoes.Location = new System.Drawing.Point(6, 32);
			this.m_txtAtualizacoes.Multiline = true;
			this.m_txtAtualizacoes.Name = "m_txtAtualizacoes";
			this.m_txtAtualizacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtAtualizacoes.Size = new System.Drawing.Size(386, 328);
			this.m_txtAtualizacoes.TabIndex = 9;
			this.m_txtAtualizacoes.Text = "";
			// 
			// usrCtrlAtualizacoes
			// 
			this.Controls.Add(this.m_txtAtualizacoes);
			this.Controls.Add(this.m_lbAtualizacoes);
			this.Name = "usrCtrlAtualizacoes";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlAtualizacoes_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void usrCtrlAtualizacoes_Load(object sender, System.EventArgs e)
			{
				OnCallCarregaDados();
			}
		#endregion
	}
}
