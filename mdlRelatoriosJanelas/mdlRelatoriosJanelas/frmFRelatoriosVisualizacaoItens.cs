using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosVisualizacaoItens.
	/// </summary>
	public class frmFRelatoriosVisualizacaoItens : System.Windows.Forms.Form
	{
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel; 
			// Geral 
			private bool m_bGrade; 
			private bool m_bMargens;
			private bool m_bAreaProdutos ;
			// Objetos 
			private bool m_bLinhas;
			private bool m_bCirculos;
			private bool m_bRetangulos;
			private bool m_bImagens;
			private bool m_bTextos; 
			private bool m_bCamposBD;
			private bool m_bCamposBDDados; 
			public bool m_bModificado;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.GroupBox m_gbGerais;
			internal System.Windows.Forms.CheckBox m_ckAreaProdutos;
			internal System.Windows.Forms.CheckBox m_ckMargens;
			internal System.Windows.Forms.CheckBox m_ckGrade;
			internal System.Windows.Forms.GroupBox m_gbObjetos;
			internal System.Windows.Forms.CheckBox m_ckCamposBancoDadosDados;
			internal System.Windows.Forms.CheckBox m_ckImagens;
			internal System.Windows.Forms.CheckBox m_ckCamposBancoDados;
			internal System.Windows.Forms.CheckBox m_ckEtiquetas;
			internal System.Windows.Forms.CheckBox m_ckRetangulos;
			internal System.Windows.Forms.CheckBox m_ckCirculos;
			internal System.Windows.Forms.CheckBox m_ckLinhas;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
		public frmFRelatoriosVisualizacaoItens(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,string strEnderecoExecutavel, bool bGrade, bool bMargens,bool bAreaProdutos , bool bLinhas , bool bCirculos , bool bRetangulos , bool bImagens , bool bTextos , bool bCamposBD , bool bcamposBDDados)
		{

	        m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

			//Gerais
			m_bGrade = bGrade;
			m_bMargens = bMargens;
			m_bAreaProdutos = bAreaProdutos;

			// Objetos 
			m_bLinhas = bLinhas;
			m_bCirculos = bCirculos;
			m_bRetangulos = bRetangulos;
			m_bImagens = bImagens;
			m_bTextos = bTextos;
			m_bCamposBD = bCamposBD;
			m_bCamposBDDados = bcamposBDDados;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosVisualizacaoItens));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbGerais = new System.Windows.Forms.GroupBox();
			this.m_ckAreaProdutos = new System.Windows.Forms.CheckBox();
			this.m_ckMargens = new System.Windows.Forms.CheckBox();
			this.m_ckGrade = new System.Windows.Forms.CheckBox();
			this.m_gbObjetos = new System.Windows.Forms.GroupBox();
			this.m_ckCamposBancoDadosDados = new System.Windows.Forms.CheckBox();
			this.m_ckImagens = new System.Windows.Forms.CheckBox();
			this.m_ckCamposBancoDados = new System.Windows.Forms.CheckBox();
			this.m_ckEtiquetas = new System.Windows.Forms.CheckBox();
			this.m_ckRetangulos = new System.Windows.Forms.CheckBox();
			this.m_ckCirculos = new System.Windows.Forms.CheckBox();
			this.m_ckLinhas = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbGerais.SuspendLayout();
			this.m_gbObjetos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbGerais);
			this.m_gbGeral.Controls.Add(this.m_gbObjetos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(220, 258);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbGerais
			// 
			this.m_gbGerais.Controls.Add(this.m_ckAreaProdutos);
			this.m_gbGerais.Controls.Add(this.m_ckMargens);
			this.m_gbGerais.Controls.Add(this.m_ckGrade);
			this.m_gbGerais.Location = new System.Drawing.Point(8, 11);
			this.m_gbGerais.Name = "m_gbGerais";
			this.m_gbGerais.Size = new System.Drawing.Size(200, 76);
			this.m_gbGerais.TabIndex = 69;
			this.m_gbGerais.TabStop = false;
			this.m_gbGerais.Text = "Gerais";
			// 
			// m_ckAreaProdutos
			// 
			this.m_ckAreaProdutos.Location = new System.Drawing.Point(8, 48);
			this.m_ckAreaProdutos.Name = "m_ckAreaProdutos";
			this.m_ckAreaProdutos.Size = new System.Drawing.Size(128, 16);
			this.m_ckAreaProdutos.TabIndex = 3;
			this.m_ckAreaProdutos.Text = "Área de Produtos";
			// 
			// m_ckMargens
			// 
			this.m_ckMargens.Location = new System.Drawing.Point(8, 32);
			this.m_ckMargens.Name = "m_ckMargens";
			this.m_ckMargens.Size = new System.Drawing.Size(104, 16);
			this.m_ckMargens.TabIndex = 2;
			this.m_ckMargens.Text = "Margens";
			// 
			// m_ckGrade
			// 
			this.m_ckGrade.Location = new System.Drawing.Point(8, 16);
			this.m_ckGrade.Name = "m_ckGrade";
			this.m_ckGrade.Size = new System.Drawing.Size(104, 16);
			this.m_ckGrade.TabIndex = 1;
			this.m_ckGrade.Text = "Grade";
			// 
			// m_gbObjetos
			// 
			this.m_gbObjetos.Controls.Add(this.m_ckCamposBancoDadosDados);
			this.m_gbObjetos.Controls.Add(this.m_ckImagens);
			this.m_gbObjetos.Controls.Add(this.m_ckCamposBancoDados);
			this.m_gbObjetos.Controls.Add(this.m_ckEtiquetas);
			this.m_gbObjetos.Controls.Add(this.m_ckRetangulos);
			this.m_gbObjetos.Controls.Add(this.m_ckCirculos);
			this.m_gbObjetos.Controls.Add(this.m_ckLinhas);
			this.m_gbObjetos.Location = new System.Drawing.Point(8, 88);
			this.m_gbObjetos.Name = "m_gbObjetos";
			this.m_gbObjetos.Size = new System.Drawing.Size(200, 136);
			this.m_gbObjetos.TabIndex = 68;
			this.m_gbObjetos.TabStop = false;
			this.m_gbObjetos.Text = "Objetos";
			// 
			// m_ckCamposBancoDadosDados
			// 
			this.m_ckCamposBancoDadosDados.Location = new System.Drawing.Point(8, 112);
			this.m_ckCamposBancoDadosDados.Name = "m_ckCamposBancoDadosDados";
			this.m_ckCamposBancoDadosDados.Size = new System.Drawing.Size(176, 16);
			this.m_ckCamposBancoDadosDados.TabIndex = 6;
			this.m_ckCamposBancoDadosDados.Text = "Textos Dinâmicos - Dados";
			// 
			// m_ckImagens
			// 
			this.m_ckImagens.Location = new System.Drawing.Point(8, 64);
			this.m_ckImagens.Name = "m_ckImagens";
			this.m_ckImagens.Size = new System.Drawing.Size(104, 16);
			this.m_ckImagens.TabIndex = 5;
			this.m_ckImagens.Text = "Imagens";
			// 
			// m_ckCamposBancoDados
			// 
			this.m_ckCamposBancoDados.Location = new System.Drawing.Point(8, 96);
			this.m_ckCamposBancoDados.Name = "m_ckCamposBancoDados";
			this.m_ckCamposBancoDados.Size = new System.Drawing.Size(176, 16);
			this.m_ckCamposBancoDados.TabIndex = 4;
			this.m_ckCamposBancoDados.Text = "Textos Dinâmicos - Etiquetas";
			// 
			// m_ckEtiquetas
			// 
			this.m_ckEtiquetas.Location = new System.Drawing.Point(8, 80);
			this.m_ckEtiquetas.Name = "m_ckEtiquetas";
			this.m_ckEtiquetas.Size = new System.Drawing.Size(112, 16);
			this.m_ckEtiquetas.TabIndex = 3;
			this.m_ckEtiquetas.Text = "Textos Estáticos";
			// 
			// m_ckRetangulos
			// 
			this.m_ckRetangulos.Location = new System.Drawing.Point(8, 48);
			this.m_ckRetangulos.Name = "m_ckRetangulos";
			this.m_ckRetangulos.Size = new System.Drawing.Size(104, 16);
			this.m_ckRetangulos.TabIndex = 2;
			this.m_ckRetangulos.Text = "Retangulos";
			// 
			// m_ckCirculos
			// 
			this.m_ckCirculos.Location = new System.Drawing.Point(8, 32);
			this.m_ckCirculos.Name = "m_ckCirculos";
			this.m_ckCirculos.Size = new System.Drawing.Size(104, 16);
			this.m_ckCirculos.TabIndex = 1;
			this.m_ckCirculos.Text = "Circulos";
			// 
			// m_ckLinhas
			// 
			this.m_ckLinhas.Location = new System.Drawing.Point(8, 16);
			this.m_ckLinhas.Name = "m_ckLinhas";
			this.m_ckLinhas.Size = new System.Drawing.Size(104, 16);
			this.m_ckLinhas.TabIndex = 0;
			this.m_ckLinhas.Text = "Linhas";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(50, 228);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 66;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(114, 228);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 67;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosVisualizacaoItens
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 262);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosVisualizacaoItens";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Visualizar";
			this.Load += new System.EventHandler(this.frmFRelatoriosVisualizacaoItens_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbGerais.ResumeLayout(false);
			this.m_gbObjetos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRelatoriosVisualizacaoItens_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					RefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
		            //Gerais
					m_bGrade = m_ckGrade.Checked;
					m_bMargens = m_ckMargens.Checked;
					m_bAreaProdutos = m_ckAreaProdutos.Checked;
					// Objetos 
					m_bLinhas = m_ckLinhas.Checked;
					m_bCirculos = m_ckCirculos.Checked;
					m_bRetangulos = m_ckRetangulos.Checked;
					m_bImagens = m_ckImagens.Checked;
					m_bTextos = m_ckEtiquetas.Checked;
					m_bCamposBD = m_ckCamposBancoDados.Checked;
					m_bCamposBDDados = m_ckCamposBancoDadosDados.Checked;
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
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

		#region Refresh
		private void RefreshInterface()
		{
            //Gerais
            m_ckGrade.Checked = m_bGrade;
            m_ckMargens.Checked = m_bMargens;
            m_ckAreaProdutos.Checked = m_bAreaProdutos;

            // Objetos 
            m_ckLinhas.Checked = m_bLinhas;
            m_ckCirculos.Checked = m_bCirculos;
            m_ckRetangulos.Checked = m_bRetangulos;
            m_ckImagens.Checked = m_bImagens;
            m_ckEtiquetas.Checked = m_bTextos;
            m_ckCamposBancoDados.Checked = m_bCamposBD;
            m_ckCamposBancoDadosDados.Checked = m_bCamposBDDados;
		}

		#endregion

		#region Retorno
		public void RetornaValores(out bool bGrade,out bool bMargens,out bool bAreaProdutos,out bool bLinhas,out bool bCirculos,out bool bRetangulos,out bool bImagens,out bool bTextos,out bool bCamposBD,out bool bCamposBDDados)
		{
			bGrade = m_bGrade; 
			bMargens = m_bMargens;
			bAreaProdutos = m_bAreaProdutos ;
			
			bLinhas = m_bLinhas;
			bCirculos = m_bCirculos;
			bRetangulos = m_bRetangulos;
			bImagens = m_bImagens;
			bTextos = m_bTextos; 
			bCamposBD = m_bCamposBD;
			bCamposBDDados = m_bCamposBDDados; 
		}
		#endregion
	}
}
