using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SiscoBDAtualiza
{
	/// <summary>
	/// Summary description for frmFSiscoBDAtualiza.
	/// </summary>
	public class frmFSiscoBDAtualiza : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallStart();
		#endregion
		#region Events
			public event delCallStart eCallStart;
		#endregion
		#region Events Methods
			protected virtual bool OnCallStart()
			{
				if (eCallStart == null)
					return(false);
				return(eCallStart());
			}
		#endregion

		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.RichTextBox m_txtInformacao;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public System.Windows.Forms.RichTextBox Informacoes
			{
				get
				{
					return(m_txtInformacao);
				}
			}
		#endregion
		#region Constructors
			public frmFSiscoBDAtualiza()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSiscoBDAtualiza));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_txtInformacao = new System.Windows.Forms.RichTextBox();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_txtInformacao);
			this.m_gbMain.Location = new System.Drawing.Point(2, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(689, 468);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_txtInformacao
			// 
			this.m_txtInformacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtInformacao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtInformacao.Location = new System.Drawing.Point(6, 13);
			this.m_txtInformacao.Name = "m_txtInformacao";
			this.m_txtInformacao.ReadOnly = true;
			this.m_txtInformacao.Size = new System.Drawing.Size(676, 444);
			this.m_txtInformacao.TabIndex = 0;
			this.m_txtInformacao.Text = "";
			// 
			// frmFSiscoBDAtualiza
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 468);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSiscoBDAtualiza";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras - Atualização do Banco de Dados";
			this.Load += new System.EventHandler(this.frmFSiscoBDAtualiza_Load);
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFSiscoBDAtualiza_Load(object sender, System.EventArgs e)
				{
					OnCallStart();
				}
			#endregion
		#endregion
	}
}
