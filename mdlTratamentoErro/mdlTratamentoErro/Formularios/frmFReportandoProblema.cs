using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTratamentoErro.Formularios
{
	/// <summary>
	/// Summary description for frmFReportandoProblema.
	/// </summary>
	public class frmFReportandoProblema : System.Windows.Forms.Form
	{
		#region Atributos
			internal System.Windows.Forms.PictureBox picImagem;
			internal System.Windows.Forms.Label lbInfo;
			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.CheckBox m_ckReabrirSiscobras;
			internal System.Windows.Forms.Label m_lbAviso;
			internal System.Windows.Forms.Button m_btDetalhes;
			internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.CheckBox m_ckClose;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Delegates
			public delegate void delCallShowDialogInformacoesProblema();
			public delegate void delCallReabrirSiscobras(bool bClose,bool bReabrirSiscobras);
		#endregion
		#region Events
			public event delCallShowDialogInformacoesProblema eCallShowDialogInformacoesProblema;
			public event delCallReabrirSiscobras eCallReabrirSiscobras;
		#endregion
		#region Events Methods
			protected virtual void OnCallShowDialogInformacoesProblema()
			{
				if (eCallShowDialogInformacoesProblema != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogInformacoesProblema();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallReabrirSiscobras()
			{
				if (eCallReabrirSiscobras != null)
				{
					eCallReabrirSiscobras(m_ckClose.Checked,m_ckReabrirSiscobras.Checked);
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFReportandoProblema()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFReportandoProblema));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_ckClose = new System.Windows.Forms.CheckBox();
			this.m_ckReabrirSiscobras = new System.Windows.Forms.CheckBox();
			this.picImagem = new System.Windows.Forms.PictureBox();
			this.m_lbAviso = new System.Windows.Forms.Label();
			this.m_btDetalhes = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.lbInfo = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.BackColor = System.Drawing.SystemColors.Control;
			this.m_gbGeral.Controls.Add(this.m_ckClose);
			this.m_gbGeral.Controls.Add(this.m_ckReabrirSiscobras);
			this.m_gbGeral.Controls.Add(this.picImagem);
			this.m_gbGeral.Controls.Add(this.m_lbAviso);
			this.m_gbGeral.Controls.Add(this.m_btDetalhes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.lbInfo);
			this.m_gbGeral.Location = new System.Drawing.Point(0, -4);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(464, 380);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_ckClose
			// 
			this.m_ckClose.Checked = true;
			this.m_ckClose.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckClose.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.m_ckClose.Location = new System.Drawing.Point(8, 304);
			this.m_ckClose.Name = "m_ckClose";
			this.m_ckClose.Size = new System.Drawing.Size(272, 16);
			this.m_ckClose.TabIndex = 6;
			this.m_ckClose.Text = "Fechar Siscobras (Recomendado)";
			// 
			// m_ckReabrirSiscobras
			// 
			this.m_ckReabrirSiscobras.Checked = true;
			this.m_ckReabrirSiscobras.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckReabrirSiscobras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckReabrirSiscobras.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.m_ckReabrirSiscobras.Location = new System.Drawing.Point(8, 322);
			this.m_ckReabrirSiscobras.Name = "m_ckReabrirSiscobras";
			this.m_ckReabrirSiscobras.Size = new System.Drawing.Size(240, 16);
			this.m_ckReabrirSiscobras.TabIndex = 5;
			this.m_ckReabrirSiscobras.Text = "Reabrir o Siscobras automaticamente.";
			// 
			// picImagem
			// 
			this.picImagem.Image = ((System.Drawing.Image)(resources.GetObject("picImagem.Image")));
			this.picImagem.Location = new System.Drawing.Point(8, 16);
			this.picImagem.Name = "picImagem";
			this.picImagem.Size = new System.Drawing.Size(448, 200);
			this.picImagem.TabIndex = 4;
			this.picImagem.TabStop = false;
			// 
			// m_lbAviso
			// 
			this.m_lbAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbAviso.ForeColor = System.Drawing.Color.MediumBlue;
			this.m_lbAviso.Location = new System.Drawing.Point(9, 219);
			this.m_lbAviso.Name = "m_lbAviso";
			this.m_lbAviso.Size = new System.Drawing.Size(52, 16);
			this.m_lbAviso.TabIndex = 3;
			this.m_lbAviso.Text = "AVISO:";
			// 
			// m_btDetalhes
			// 
			this.m_btDetalhes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDetalhes.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.m_btDetalhes.Location = new System.Drawing.Point(236, 342);
			this.m_btDetalhes.Name = "m_btDetalhes";
			this.m_btDetalhes.Size = new System.Drawing.Size(88, 32);
			this.m_btDetalhes.TabIndex = 2;
			this.m_btDetalhes.Text = "&Detalhes";
			this.m_btDetalhes.Click += new System.EventHandler(this.m_btDetalhes_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.m_btOk.Location = new System.Drawing.Point(139, 342);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(88, 32);
			this.m_btOk.TabIndex = 1;
			this.m_btOk.Text = "&Ok";
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// lbInfo
			// 
			this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbInfo.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.lbInfo.Location = new System.Drawing.Point(8, 240);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(432, 64);
			this.lbInfo.TabIndex = 0;
			this.lbInfo.Text = "O Siscobras Exporta Fácil identificou uma discrepância. Os dados serão salvos e e" +
				"nviados automaticamente durante a próxima atualização.  A discrepância será corr" +
				"igida e você será informado oportunamente.O Siscobras Exporta Fácil será fechado" +
				". ";
			// 
			// frmFReportandoProblema
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 376);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFReportandoProblema";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Siscobras";
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallReabrirSiscobras();
                    this.Close();				
				}

				private void m_btDetalhes_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogInformacoesProblema();
				}
			#endregion
		#endregion
	}
}
