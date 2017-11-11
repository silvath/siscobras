using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosPropriedadesObjetoTexto.
	/// </summary>
	public class frmFRelatoriosPropriedadesObjetoTexto : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private string m_strEnderecoExecutavel; 
		private string m_strTexto; 
		private System.Drawing.Font m_fntFonte; 
		private System.Drawing.Color m_clrTexto; 
		private bool m_bVisivelImpressao; 
		public bool m_bModificado; 

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.Label m_lbFonte;
		internal System.Windows.Forms.Button m_btFonte;
		internal System.Windows.Forms.CheckBox m_ckVisivelImpressao;
		internal System.Windows.Forms.Label m_lbTexto;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_txtTexto;
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
		public frmFRelatoriosPropriedadesObjetoTexto(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,string strEnderecoExecutavel,string strTexto,int nCor,System.Drawing.Font fntFonte, bool bVisivelImpressao)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_strTexto = strTexto;
			m_clrTexto = System.Drawing.Color.FromArgb(nCor);
			m_fntFonte = fntFonte;
			m_bVisivelImpressao = bVisivelImpressao;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosPropriedadesObjetoTexto));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtTexto = new mdlComponentesGraficos.TextBox();
			this.m_lbFonte = new System.Windows.Forms.Label();
			this.m_btFonte = new System.Windows.Forms.Button();
			this.m_ckVisivelImpressao = new System.Windows.Forms.CheckBox();
			this.m_lbTexto = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtTexto);
			this.m_gbGeral.Controls.Add(this.m_lbFonte);
			this.m_gbGeral.Controls.Add(this.m_btFonte);
			this.m_gbGeral.Controls.Add(this.m_ckVisivelImpressao);
			this.m_gbGeral.Controls.Add(this.m_lbTexto);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(406, 160);
			this.m_gbGeral.TabIndex = 4;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtTexto
			// 
			this.m_txtTexto.Location = new System.Drawing.Point(48, 15);
			this.m_txtTexto.Name = "m_txtTexto";
			this.m_txtTexto.Size = new System.Drawing.Size(336, 20);
			this.m_txtTexto.TabIndex = 1;
			this.m_txtTexto.Text = "Coloque o seu texto aqui";
			this.m_txtTexto.TextChanged += new System.EventHandler(this.m_txtTexto_TextChanged);
			// 
			// m_lbFonte
			// 
			this.m_lbFonte.BackColor = System.Drawing.Color.White;
			this.m_lbFonte.Location = new System.Drawing.Point(48, 48);
			this.m_lbFonte.Name = "m_lbFonte";
			this.m_lbFonte.Size = new System.Drawing.Size(344, 64);
			this.m_lbFonte.TabIndex = 13;
			// 
			// m_btFonte
			// 
			this.m_btFonte.Image = ((System.Drawing.Image)(resources.GetObject("m_btFonte.Image")));
			this.m_btFonte.Location = new System.Drawing.Point(8, 60);
			this.m_btFonte.Name = "m_btFonte";
			this.m_btFonte.Size = new System.Drawing.Size(24, 24);
			this.m_btFonte.TabIndex = 3;
			this.m_btFonte.Click += new System.EventHandler(this.m_btFonte_Click);
			// 
			// m_ckVisivelImpressao
			// 
			this.m_ckVisivelImpressao.Location = new System.Drawing.Point(9, 112);
			this.m_ckVisivelImpressao.Name = "m_ckVisivelImpressao";
			this.m_ckVisivelImpressao.Size = new System.Drawing.Size(176, 16);
			this.m_ckVisivelImpressao.TabIndex = 4;
			this.m_ckVisivelImpressao.Text = "Visivel na Impressao.";
			// 
			// m_lbTexto
			// 
			this.m_lbTexto.Location = new System.Drawing.Point(8, 19);
			this.m_lbTexto.Name = "m_lbTexto";
			this.m_lbTexto.Size = new System.Drawing.Size(40, 16);
			this.m_lbTexto.TabIndex = 8;
			this.m_lbTexto.Text = "Texto:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(142, 129);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 2;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(206, 129);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosPropriedadesObjetoTexto
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 166);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosPropriedadesObjetoTexto";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Texto";
			this.Load += new System.EventHandler(this.frmFRelatoriosPropriedadesObjetoTexto_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
		#region Formulario
		private void frmFRelatoriosPropriedadesObjetoTexto_Load(object sender, System.EventArgs e)
		{
			MostraCor();
			RefreshInterface();
		}
		#endregion
		#region Diversos
		private void m_txtTexto_TextChanged(object sender, System.EventArgs e)
		{
			m_lbFonte.Text = m_txtTexto.Text;
		}

		private void m_btFonte_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.FontDialog dlgFonte = new System.Windows.Forms.FontDialog();
			try
			{
				dlgFonte.Font = m_fntFonte;
			}catch{
				dlgFonte.Font = new System.Drawing.Font("Arial",12);
			}
			dlgFonte.Color = m_clrTexto;
			dlgFonte.ShowColor = true;
			dlgFonte.FontMustExist = true;
			if (dlgFonte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				try
				{
					m_fntFonte = dlgFonte.Font;
				}catch{
					m_fntFonte = new System.Drawing.Font("Arial",12);
				}
				// Check the font size
				if (m_fntFonte.Size != System.Math.Ceiling(m_fntFonte.Size))
				{
					FontStyle fs = new FontStyle();
					if ( m_fntFonte.Bold )
						fs = fs | FontStyle.Bold;
					if ( m_fntFonte.Italic)
						fs = fs | FontStyle.Italic;
					if ( m_fntFonte.Strikeout)
						fs = fs | FontStyle.Strikeout;
					if ( m_fntFonte.Underline)
						fs = fs | FontStyle.Underline;
					try
					{
						m_fntFonte = new System.Drawing.Font(m_fntFonte.FontFamily,(int)m_fntFonte.Size,fs);
					}catch{
						m_fntFonte = new System.Drawing.Font("Arial",12);
					}
				}
				m_clrTexto = dlgFonte.Color;
				try
				{
					m_lbFonte.Font = m_fntFonte;
				}catch{
					m_lbFonte.Font = new System.Drawing.Font("Arial",12);
				}
				m_lbFonte.ForeColor = m_clrTexto;
			}
			dlgFonte = null;
		}
		#endregion
		#region Botoes
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			m_strTexto = m_txtTexto.Text;
			m_bVisivelImpressao = m_ckVisivelImpressao.Checked;
			m_bModificado = true;
			this.Close();
		}

		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#endregion
		#region Cores
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region Refresh
		private void RefreshInterface()
		{
			m_txtTexto.Text = m_strTexto;
			m_txtTexto.SelectAll();
			m_lbFonte.Text = m_txtTexto.Text;
			if (m_fntFonte != null)
			{
				m_lbFonte.Font = new Font(m_fntFonte,m_fntFonte.Style);
			}
			m_lbFonte.ForeColor = m_clrTexto;
			m_ckVisivelImpressao.Checked = m_bVisivelImpressao;
		}
		#endregion

		#region Retorno
			public void RetornaValores(out string strTexto , out System.Drawing.Color clrCor, out System.Drawing.Font fntFonte, out bool bVisivelImpressao)
			{
	            strTexto = m_strTexto;
		        clrCor = m_clrTexto;
			    fntFonte = m_fntFonte;
				bVisivelImpressao = m_bVisivelImpressao;
			}
		#endregion
	}
}
