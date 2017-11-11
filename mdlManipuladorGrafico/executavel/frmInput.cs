using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DrawingCanvasPackage;

namespace executavel
{
	/// <summary>
	/// Summary description for frmInput.
	/// </summary>
	public class frmInput : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Windows.Forms.Label lblMensagem;
			private System.Windows.Forms.Button btnCancelar;
			private System.Windows.Forms.Button btnOK;
			private System.Windows.Forms.TextBox txtEntrada;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;

			protected String m_strDado;
			protected bool m_bReportDefault;
			protected String m_strCaption;
			private System.Windows.Forms.CheckBox m_ckReportDefault;
			protected String m_strMsg;
		#endregion
		#region Constructors and Destructors
			public frmInput( String strCaption, String strMsg, String strDefault)
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
				m_strDado = strDefault;
				m_strMsg = strMsg;
				m_strCaption = strCaption;
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
			this.lblMensagem = new System.Windows.Forms.Label();
			this.txtEntrada = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.m_ckReportDefault = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lblMensagem
			// 
			this.lblMensagem.AutoSize = true;
			this.lblMensagem.Location = new System.Drawing.Point(7, 13);
			this.lblMensagem.Name = "lblMensagem";
			this.lblMensagem.Size = new System.Drawing.Size(63, 16);
			this.lblMensagem.TabIndex = 0;
			this.lblMensagem.Text = "Mensagem:";
			// 
			// txtEntrada
			// 
			this.txtEntrada.Location = new System.Drawing.Point(7, 29);
			this.txtEntrada.Name = "txtEntrada";
			this.txtEntrada.Size = new System.Drawing.Size(409, 20);
			this.txtEntrada.TabIndex = 1;
			this.txtEntrada.Text = "txtEntrada";
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(344, 72);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "&Cancelar";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(256, 72);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// m_ckReportDefault
			// 
			this.m_ckReportDefault.Location = new System.Drawing.Point(8, 56);
			this.m_ckReportDefault.Name = "m_ckReportDefault";
			this.m_ckReportDefault.Size = new System.Drawing.Size(200, 16);
			this.m_ckReportDefault.TabIndex = 4;
			this.m_ckReportDefault.Text = "Report Default ";
			// 
			// frmInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 109);
			this.Controls.Add(this.m_ckReportDefault);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.txtEntrada);
			this.Controls.Add(this.lblMensagem);
			this.Name = "frmInput";
			this.Text = "Caption";
			this.Load += new System.EventHandler(this.frmInput_Load);
			this.Activated += new System.EventHandler(this.frmInput_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void btnOK_Click(object sender, System.EventArgs e)
				{
					m_strDado = txtEntrada.Text;
					m_bReportDefault = m_ckReportDefault.Checked;
				}

				public String getEntrada()
				{
					return( m_strDado );
				}

				public bool getReportDefault()
				{
					return(m_bReportDefault);
				}

				private void frmInput_Load(object sender, System.EventArgs e)
				{
				}

				private void frmInput_Activated(object sender, System.EventArgs e)
				{
					this.Text = m_strCaption;
					this.lblMensagem.Text = m_strMsg;
					this.txtEntrada.Text = m_strDado;
					this.txtEntrada.Focus();
				}
			#endregion
		#endregion
	}
}
