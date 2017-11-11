using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosMargens.
	/// </summary>
	public class frmFRelatoriosMargens : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;  
		private string m_strEnderecoExecutavel; 
		private double m_dAcima; 
		private double m_dDireita;
		private double m_dAbaixo; 
		private double m_dEsquerda; 
		public bool m_bModificado; 

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Panel m_pnFormato;
		internal System.Windows.Forms.Label m_lbFolha;
		internal System.Windows.Forms.Panel m_pnFolha;
		private mdlComponentesGraficos.TextBox m_txtAcima;
		private mdlComponentesGraficos.TextBox m_txtDireita;
		private mdlComponentesGraficos.TextBox m_txtEsquerda;
		private mdlComponentesGraficos.TextBox m_txtAbaixo;
		private System.ComponentModel.Container components = null;
		#endregion 
		#region Constructor and Destructors
		public frmFRelatoriosMargens(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, string strEnderecoExecutavel, double dAcima,double dDireita, double dAbaixo, double dEsquerda)
		{
			m_cls_ter_tratadorErro = m_cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_dAcima = dAcima;
			m_dDireita = dDireita;
			m_dAbaixo = dAbaixo;
			m_dEsquerda = dEsquerda;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosMargens));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtAbaixo = new mdlComponentesGraficos.TextBox();
			this.m_txtEsquerda = new mdlComponentesGraficos.TextBox();
			this.m_txtDireita = new mdlComponentesGraficos.TextBox();
			this.m_txtAcima = new mdlComponentesGraficos.TextBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_pnFormato = new System.Windows.Forms.Panel();
			this.m_lbFolha = new System.Windows.Forms.Label();
			this.m_pnFolha = new System.Windows.Forms.Panel();
			this.m_gbGeral.SuspendLayout();
			this.m_pnFormato.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtAbaixo);
			this.m_gbGeral.Controls.Add(this.m_txtEsquerda);
			this.m_gbGeral.Controls.Add(this.m_txtDireita);
			this.m_gbGeral.Controls.Add(this.m_txtAcima);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_pnFormato);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(235, 223);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtAbaixo
			// 
			this.m_txtAbaixo.Location = new System.Drawing.Point(88, 163);
			this.m_txtAbaixo.Mask = false;
			this.m_txtAbaixo.MaskText = "";
			this.m_txtAbaixo.Name = "m_txtAbaixo";
			this.m_txtAbaixo.OnlyNumbers = true;
			this.m_txtAbaixo.Size = new System.Drawing.Size(48, 20);
			this.m_txtAbaixo.TabIndex = 24;
			this.m_txtAbaixo.Text = "";
			// 
			// m_txtEsquerda
			// 
			this.m_txtEsquerda.Location = new System.Drawing.Point(7, 96);
			this.m_txtEsquerda.Mask = false;
			this.m_txtEsquerda.MaskText = "";
			this.m_txtEsquerda.Name = "m_txtEsquerda";
			this.m_txtEsquerda.OnlyNumbers = true;
			this.m_txtEsquerda.Size = new System.Drawing.Size(48, 20);
			this.m_txtEsquerda.TabIndex = 23;
			this.m_txtEsquerda.Text = "";
			// 
			// m_txtDireita
			// 
			this.m_txtDireita.Location = new System.Drawing.Point(173, 93);
			this.m_txtDireita.Mask = false;
			this.m_txtDireita.MaskText = "";
			this.m_txtDireita.Name = "m_txtDireita";
			this.m_txtDireita.OnlyNumbers = true;
			this.m_txtDireita.Size = new System.Drawing.Size(48, 20);
			this.m_txtDireita.TabIndex = 22;
			this.m_txtDireita.Text = "";
			// 
			// m_txtAcima
			// 
			this.m_txtAcima.Location = new System.Drawing.Point(92, 12);
			this.m_txtAcima.Mask = false;
			this.m_txtAcima.MaskText = "";
			this.m_txtAcima.Name = "m_txtAcima";
			this.m_txtAcima.OnlyNumbers = true;
			this.m_txtAcima.Size = new System.Drawing.Size(48, 20);
			this.m_txtAcima.TabIndex = 21;
			this.m_txtAcima.Text = "";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(52, 189);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(116, 189);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_pnFormato
			// 
			this.m_pnFormato.BackColor = System.Drawing.Color.Gainsboro;
			this.m_pnFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_pnFormato.Controls.Add(this.m_lbFolha);
			this.m_pnFormato.Controls.Add(this.m_pnFolha);
			this.m_pnFormato.Location = new System.Drawing.Point(65, 38);
			this.m_pnFormato.Name = "m_pnFormato";
			this.m_pnFormato.Size = new System.Drawing.Size(104, 120);
			this.m_pnFormato.TabIndex = 20;
			// 
			// m_lbFolha
			// 
			this.m_lbFolha.BackColor = System.Drawing.Color.White;
			this.m_lbFolha.Location = new System.Drawing.Point(36, 51);
			this.m_lbFolha.Name = "m_lbFolha";
			this.m_lbFolha.Size = new System.Drawing.Size(36, 16);
			this.m_lbFolha.TabIndex = 21;
			this.m_lbFolha.Text = "folha";
			// 
			// m_pnFolha
			// 
			this.m_pnFolha.BackColor = System.Drawing.Color.White;
			this.m_pnFolha.ForeColor = System.Drawing.Color.Yellow;
			this.m_pnFolha.Location = new System.Drawing.Point(12, 12);
			this.m_pnFolha.Name = "m_pnFolha";
			this.m_pnFolha.Size = new System.Drawing.Size(77, 96);
			this.m_pnFolha.TabIndex = 21;
			// 
			// frmFRelatoriosMargens
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(242, 232);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosMargens";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Margens (cm)";
			this.Load += new System.EventHandler(this.frmFRelatoriosMargens_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_pnFormato.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
		#region Formulario
		private void frmFRelatoriosMargens_Load(object sender, System.EventArgs e)
		{
			MostraCor();
			CarregaDadosInterface();
		}
		#endregion
		#region Botoes
			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				if (bSalvaDadosInterface())
				{
					m_bModificado = true;
					this.Close();
				}
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
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
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

		#region Carregamento dos Dados
		private void CarregaDadosInterface()
		{
            m_txtAcima.Text = m_dAcima.ToString();
            m_txtDireita.Text = m_dDireita.ToString();
            m_txtAbaixo.Text = m_dAbaixo.ToString();
            m_txtEsquerda.Text = m_dEsquerda.ToString();
		}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDadosInterface()
			{
				bool bRetorno = false;
				try
				{
					m_dAcima = double.Parse(m_txtAcima.Text); 
					m_dDireita = double.Parse(m_txtDireita.Text);
					m_dAbaixo = double.Parse(m_txtAbaixo.Text); 
					m_dEsquerda = double.Parse(m_txtEsquerda.Text);
					bRetorno = true;
				}
				catch
				{
					bRetorno = false;
   				}
				return(bRetorno);
			}
		#endregion

	}
}
