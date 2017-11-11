using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosPropriedadesObjetoTextoDB.
	/// </summary>
	public class frmFRelatoriosPropriedadesObjetoTextoDB : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos 
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB; 
			private string m_strEnderecoExecutavel; 
			private mdlRelatoriosCallBack.clsRelatoriosCallBack m_cls_call_CallBack; 
			private int m_nIdExportador; 
			private string m_strIdCodigo; 
			private int m_nIdTipoRelatorio; 
			private int m_nIdIdioma; 
			private int m_nIdCampoBD; 
			private string m_strTexto; 
			private System.Drawing.Font m_fntFonte; 
			private System.Drawing.Color m_clrTexto; 
			private bool m_bVisivelImpressao; 
			private bool m_bCallBack; 
			private bool m_bPertenceAreaProdutos; 
			private bool m_bAlinhamentoInferiorAreaProdutos; 
			private int m_nAlinhamento; 
			private bool m_bImprimirSomenteUltimaPagina; 
			private int m_nFormatoNumero; 

			private System.Drawing.Color m_clrEtiqueta;
			private System.Drawing.Color m_clrCampos;
			private System.Drawing.Color m_clrFundo;

			private bool m_bAtivado = true;
			public bool m_bModificado; 

			// TypedDataSet
			private mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD m_typDatSetTbRelatoriosTodosCamposBD;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios m_typDatSetTbRelatoriosCamposBDRelatorios;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.PictureBox m_picBandeira;
			internal System.Windows.Forms.Label m_lbTextoEdicao;
			internal System.Windows.Forms.Label m_lbEdicao;
			internal System.Windows.Forms.GroupBox m_gbCampos;
			internal System.Windows.Forms.ListView m_lvCampos;
			internal System.Windows.Forms.GroupBox m_gbEtiquetas;
			internal System.Windows.Forms.ListView m_lvEtiquetas;
			internal System.Windows.Forms.Label m_lbFonte;
			internal System.Windows.Forms.Button m_btFonte;
			internal System.Windows.Forms.CheckBox m_ckVisivelImpressao;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Label m_lbVisualizacao;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
		public frmFRelatoriosPropriedadesObjetoTextoDB(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel,int nIdExportador, int nIdTipoRelatorio, int nIdIdioma,string strIdCodigo,System.Drawing.Color clrEtiqueta,System.Drawing.Color clrCampos, System.Drawing.Color clrFundo,System.Drawing.Image imgBandeiraIdioma, bool bCallBack, bool bPertenceAreaProdutos, bool bAlinhamentoInferiorAreaProdutos,int nAlinhamento, bool bImprimirSomenteUltimaPagina,int nFormatoNumero, int nCor,System.Drawing.Font fntFonte, bool bVisivelImpressao)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
     	    m_nIdExportador = nIdExportador;
			m_strIdCodigo = strIdCodigo;
			m_nIdTipoRelatorio = nIdTipoRelatorio;
			m_nIdIdioma = nIdIdioma;
			m_bCallBack = bCallBack;
			m_bPertenceAreaProdutos = bPertenceAreaProdutos;
			m_bAlinhamentoInferiorAreaProdutos = bAlinhamentoInferiorAreaProdutos;
			m_nAlinhamento = nAlinhamento;
			m_bImprimirSomenteUltimaPagina = bImprimirSomenteUltimaPagina;
			m_nFormatoNumero = nFormatoNumero;

			m_clrEtiqueta = clrEtiqueta;
			m_clrCampos = clrCampos;
			m_clrFundo = clrFundo;

			m_cls_call_CallBack = new mdlRelatoriosCallBack.clsRelatoriosCallBack(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
			m_cls_call_CallBack.Idioma = nIdIdioma;

			m_clrTexto = System.Drawing.Color.FromArgb(nCor);
			if (fntFonte != null)
			{
				m_fntFonte = fntFonte;
			}else{
				m_fntFonte = new System.Drawing.Font("Arial",8);
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosPropriedadesObjetoTextoDB));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_picBandeira = new System.Windows.Forms.PictureBox();
			this.m_lbTextoEdicao = new System.Windows.Forms.Label();
			this.m_lbEdicao = new System.Windows.Forms.Label();
			this.m_gbCampos = new System.Windows.Forms.GroupBox();
			this.m_lvCampos = new System.Windows.Forms.ListView();
			this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_gbEtiquetas = new System.Windows.Forms.GroupBox();
			this.m_lvEtiquetas = new System.Windows.Forms.ListView();
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_lbFonte = new System.Windows.Forms.Label();
			this.m_btFonte = new System.Windows.Forms.Button();
			this.m_ckVisivelImpressao = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_lbVisualizacao = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.m_gbCampos.SuspendLayout();
			this.m_gbEtiquetas.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_picBandeira);
			this.m_gbGeral.Controls.Add(this.m_lbTextoEdicao);
			this.m_gbGeral.Controls.Add(this.m_lbEdicao);
			this.m_gbGeral.Controls.Add(this.m_gbCampos);
			this.m_gbGeral.Controls.Add(this.m_gbEtiquetas);
			this.m_gbGeral.Controls.Add(this.m_lbFonte);
			this.m_gbGeral.Controls.Add(this.m_btFonte);
			this.m_gbGeral.Controls.Add(this.m_ckVisivelImpressao);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_lbVisualizacao);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(578, 410);
			this.m_gbGeral.TabIndex = 5;
			this.m_gbGeral.TabStop = false;
			// 
			// m_picBandeira
			// 
			this.m_picBandeira.Image = ((System.Drawing.Image)(resources.GetObject("m_picBandeira.Image")));
			this.m_picBandeira.Location = new System.Drawing.Point(16, 284);
			this.m_picBandeira.Name = "m_picBandeira";
			this.m_picBandeira.Size = new System.Drawing.Size(24, 24);
			this.m_picBandeira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picBandeira.TabIndex = 19;
			this.m_picBandeira.TabStop = false;
			// 
			// m_lbTextoEdicao
			// 
			this.m_lbTextoEdicao.BackColor = System.Drawing.Color.White;
			this.m_lbTextoEdicao.Location = new System.Drawing.Point(78, 232);
			this.m_lbTextoEdicao.Name = "m_lbTextoEdicao";
			this.m_lbTextoEdicao.Size = new System.Drawing.Size(488, 64);
			this.m_lbTextoEdicao.TabIndex = 18;
			this.m_lbTextoEdicao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lbEdicao
			// 
			this.m_lbEdicao.Location = new System.Drawing.Point(20, 249);
			this.m_lbEdicao.Name = "m_lbEdicao";
			this.m_lbEdicao.Size = new System.Drawing.Size(48, 16);
			this.m_lbEdicao.TabIndex = 16;
			this.m_lbEdicao.Text = "Edição:";
			// 
			// m_gbCampos
			// 
			this.m_gbCampos.Controls.Add(this.m_lvCampos);
			this.m_gbCampos.Location = new System.Drawing.Point(288, 10);
			this.m_gbCampos.Name = "m_gbCampos";
			this.m_gbCampos.Size = new System.Drawing.Size(280, 216);
			this.m_gbCampos.TabIndex = 15;
			this.m_gbCampos.TabStop = false;
			this.m_gbCampos.Text = "Dados";
			// 
			// m_lvCampos
			// 
			this.m_lvCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.ColumnHeader2});
			this.m_lvCampos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvCampos.Location = new System.Drawing.Point(8, 15);
			this.m_lvCampos.MultiSelect = false;
			this.m_lvCampos.Name = "m_lvCampos";
			this.m_lvCampos.Size = new System.Drawing.Size(264, 192);
			this.m_lvCampos.TabIndex = 1;
			this.m_lvCampos.View = System.Windows.Forms.View.Details;
			this.m_lvCampos.Click += new System.EventHandler(this.m_lvCampos_Click);
			this.m_lvCampos.SelectedIndexChanged += new System.EventHandler(this.m_lvCampos_SelectedIndexChanged);
			// 
			// m_gbEtiquetas
			// 
			this.m_gbEtiquetas.Controls.Add(this.m_lvEtiquetas);
			this.m_gbEtiquetas.Location = new System.Drawing.Point(5, 10);
			this.m_gbEtiquetas.Name = "m_gbEtiquetas";
			this.m_gbEtiquetas.Size = new System.Drawing.Size(280, 216);
			this.m_gbEtiquetas.TabIndex = 14;
			this.m_gbEtiquetas.TabStop = false;
			this.m_gbEtiquetas.Text = "Etiquetas";
			// 
			// m_lvEtiquetas
			// 
			this.m_lvEtiquetas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.ColumnHeader1});
			this.m_lvEtiquetas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvEtiquetas.Location = new System.Drawing.Point(8, 16);
			this.m_lvEtiquetas.MultiSelect = false;
			this.m_lvEtiquetas.Name = "m_lvEtiquetas";
			this.m_lvEtiquetas.Size = new System.Drawing.Size(264, 192);
			this.m_lvEtiquetas.TabIndex = 0;
			this.m_lvEtiquetas.View = System.Windows.Forms.View.Details;
			this.m_lvEtiquetas.Click += new System.EventHandler(this.m_lvEtiquetas_Click);
			this.m_lvEtiquetas.SelectedIndexChanged += new System.EventHandler(this.m_lvEtiquetas_SelectedIndexChanged);
			// 
			// m_lbFonte
			// 
			this.m_lbFonte.BackColor = System.Drawing.Color.White;
			this.m_lbFonte.Location = new System.Drawing.Point(79, 301);
			this.m_lbFonte.Name = "m_lbFonte";
			this.m_lbFonte.Size = new System.Drawing.Size(488, 64);
			this.m_lbFonte.TabIndex = 13;
			this.m_lbFonte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btFonte
			// 
			this.m_btFonte.Image = ((System.Drawing.Image)(resources.GetObject("m_btFonte.Image")));
			this.m_btFonte.Location = new System.Drawing.Point(48, 284);
			this.m_btFonte.Name = "m_btFonte";
			this.m_btFonte.Size = new System.Drawing.Size(24, 24);
			this.m_btFonte.TabIndex = 12;
			this.m_btFonte.Click += new System.EventHandler(this.m_btFonte_Click);
			// 
			// m_ckVisivelImpressao
			// 
			this.m_ckVisivelImpressao.Location = new System.Drawing.Point(8, 368);
			this.m_ckVisivelImpressao.Name = "m_ckVisivelImpressao";
			this.m_ckVisivelImpressao.Size = new System.Drawing.Size(176, 16);
			this.m_ckVisivelImpressao.TabIndex = 11;
			this.m_ckVisivelImpressao.Text = "Visivel na Impressao.";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(227, 378);
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
			this.m_btCancelar.Location = new System.Drawing.Point(291, 378);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_lbVisualizacao
			// 
			this.m_lbVisualizacao.Location = new System.Drawing.Point(8, 322);
			this.m_lbVisualizacao.Name = "m_lbVisualizacao";
			this.m_lbVisualizacao.Size = new System.Drawing.Size(72, 16);
			this.m_lbVisualizacao.TabIndex = 17;
			this.m_lbVisualizacao.Text = "Visualização:";
			// 
			// frmFRelatoriosPropriedadesObjetoTextoDB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 422);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosPropriedadesObjetoTextoDB";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Textos Dinâmicos ";
			this.Load += new System.EventHandler(this.frmFRelatoriosPropriedadesObjetoTextoDB_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbCampos.ResumeLayout(false);
			this.m_gbEtiquetas.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
		#region Formulario
		private void frmFRelatoriosPropriedadesObjetoTextoDB_Load(object sender, System.EventArgs e)
		{
			try
			{
				MostraCor();
				CarregaDadosBD();
				RefreshInterface();
				RefreshLvCamposBD();
			}catch(System.Exception eErro){
				m_cls_ter_tratadorErro.trataErro(ref eErro);
			}
		}
		#endregion
		#region m_lvEtiquetas
			private void m_lvEtiquetas_Click(object sender, System.EventArgs e)
			{
				RefreshTxtCamposBDEtiqueta();
			}

			private void m_lvEtiquetas_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				RefreshTxtCamposBDEtiqueta();
			}
		#endregion
		#region m_lvCampos
			private void m_lvCampos_Click(object sender, System.EventArgs e)
			{
				RefreshTxtCamposBDDados();
			}

			private void m_lvCampos_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				RefreshTxtCamposBDDados();			
			}
		#endregion
		#region Diversos
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
				if (dlgFonte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						m_fntFonte = dlgFonte.Font;
					}catch{
						dlgFonte.Font = new System.Drawing.Font("Arial",12);
					}
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
					m_lbTextoEdicao.Font = m_fntFonte;
					m_lbTextoEdicao.ForeColor = m_clrTexto;
				}
				dlgFonte = null;
			}
		#endregion
		#region Botoes

		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			if (m_lvEtiquetas.SelectedItems.Count > 0)
			{
                m_nIdCampoBD = Int32.Parse(m_lvEtiquetas.SelectedItems[0].Tag.ToString());
                m_bVisivelImpressao = m_ckVisivelImpressao.Checked;
                m_bCallBack = bool.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[1].Text);
                m_bPertenceAreaProdutos = bool.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[2].Text);
                m_bAlinhamentoInferiorAreaProdutos = bool.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[3].Text);
                m_nAlinhamento = Int32.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[4].Text);
                m_bImprimirSomenteUltimaPagina = bool.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[5].Text);
                m_nFormatoNumero = Int32.Parse(m_lvEtiquetas.SelectedItems[0].SubItems[6].Text);
				m_bModificado = true;
				this.Close();
			}else{
				if (m_lvCampos.SelectedItems.Count > 0)
				{
					m_nIdCampoBD = Int32.Parse(m_lvCampos.SelectedItems[0].Tag.ToString());
					m_bVisivelImpressao = m_ckVisivelImpressao.Checked;
					m_bCallBack = bool.Parse(m_lvCampos.SelectedItems[0].SubItems[1].Text);
					m_bPertenceAreaProdutos = bool.Parse(m_lvCampos.SelectedItems[0].SubItems[2].Text);
					m_bAlinhamentoInferiorAreaProdutos = bool.Parse(m_lvCampos.SelectedItems[0].SubItems[3].Text);
					m_nAlinhamento = Int32.Parse(m_lvCampos.SelectedItems[0].SubItems[4].Text);
					m_bImprimirSomenteUltimaPagina = bool.Parse(m_lvCampos.SelectedItems[0].SubItems[5].Text);
					m_nFormatoNumero = Int32.Parse(m_lvCampos.SelectedItems[0].SubItems[6].Text);
					m_bModificado = true;
					this.Close();
				}
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
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.Panel"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
		        m_lbFonte.BackColor = System.Drawing.Color.White;
				m_lbTextoEdicao.BackColor = System.Drawing.Color.White;
				m_lvEtiquetas.BackColor = m_clrEtiqueta;
				m_lvCampos.BackColor = m_clrCampos;
				m_lbFonte.BackColor = m_clrFundo;
			}
		#endregion

		#region Carregamento dos Dados 
			private void CarregaDadosBD()
			{
				try
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("nIdTipoRelatorio");
					arlCondicaoComparador.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					arlCondicaoValor.Add(m_nIdTipoRelatorio);
					arlOrdenacaoCampo.Add("strNomeCampoNoRelatorio");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbRelatoriosTodosCamposBD = m_cls_dba_ConnectionDB.GetTbRelatoriosTodosCamposBD(null,null,null,null,null);
					m_typDatSetTbRelatoriosCamposBDRelatorios = m_cls_dba_ConnectionDB.GetTbRelatoriosCamposBDRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					CarregaDadosBDDinamicos(ref m_typDatSetTbRelatoriosCamposBDRelatorios);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				}catch(System.Exception eErro){
					m_cls_ter_tratadorErro.trataErro(ref eErro);
				}
			}

			private void CarregaDadosBDDinamicos(ref mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios typDatSetRelatoriosCamposBDRelatorios)
			{
				mdlRelatoriosCallBack.clsRelatoriosCallBack callBack = new mdlRelatoriosCallBack.clsRelatoriosCallBack(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
				callBack.InsertTextosDinamicos(m_nIdTipoRelatorio,ref typDatSetRelatoriosCamposBDRelatorios);
				mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos callBackAreaProdutos = new mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				callBackAreaProdutos.InsertCamposBDDinamicos(m_nIdExportador,m_nIdTipoRelatorio,ref typDatSetRelatoriosCamposBDRelatorios);
			} 
			
		#endregion

		#region Refresh
			private void RefreshInterface()
			{
				m_lbFonte.Font = m_fntFonte;
				m_ckVisivelImpressao.Checked = m_bVisivelImpressao;
			}

			private void RefreshLvCamposBD()
			{
				RefreshLvCamposBDEtiqueta();
				RefreshLvCamposBDDados();
			}

			private void RefreshLvCamposBDEtiqueta()
			{
				System.Windows.Forms.ListViewItem lviItem; 
				bool bPossuiEtiqueta = false; 

				m_lvEtiquetas.Columns[0].Width = m_lvEtiquetas.Width - 30;
				m_lvEtiquetas.Items.Clear();

                mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow dtrwCampoRelatorio;
				mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBDRow dtrwCampoTotalRelatorio;
				for (int nCont = 0; nCont < m_typDatSetTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.Rows.Count;nCont++)
				{
					dtrwCampoRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow)m_typDatSetTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.Rows[nCont];
					if (dtrwCampoRelatorio.nIdCampoBD.ToString().EndsWith("00"))
					{
						dtrwCampoTotalRelatorio = m_typDatSetTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBD.FindBynIdCampoBD(dtrwCampoRelatorio.nIdCampoBD);
						if (dtrwCampoTotalRelatorio != null)
						{
							lviItem = m_lvEtiquetas.Items.Add(dtrwCampoRelatorio.strNomeCampoNoRelatorio);
							lviItem.Tag = dtrwCampoRelatorio.nIdCampoBD;
							lviItem.SubItems.Add(dtrwCampoRelatorio.bCallbackClicavel.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bPertenceAreaProdutos.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bAlinhamentoInferiorAreaProdutos.ToString());
							lviItem.SubItems.Add(dtrwCampoRelatorio.nAlinhamento.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bImprimirSomenteUltimaPagina.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.nFormatoNumero.ToString());
							bPossuiEtiqueta = true;
						}
					}
					if (dtrwCampoRelatorio.nIdCampoBD.ToString().EndsWith("98"))
					{
						lviItem = m_lvEtiquetas.Items.Add(dtrwCampoRelatorio.strNomeCampoNoRelatorio);
						lviItem.Tag = dtrwCampoRelatorio.nIdCampoBD;
						lviItem.SubItems.Add(dtrwCampoRelatorio.bCallbackClicavel.ToString());
						lviItem.SubItems.Add(false.ToString());
						lviItem.SubItems.Add(false.ToString());
						lviItem.SubItems.Add(dtrwCampoRelatorio.nAlinhamento.ToString());
						lviItem.SubItems.Add(false.ToString());
						lviItem.SubItems.Add("0");
						bPossuiEtiqueta = true;
					}
				}
				if (!bPossuiEtiqueta)
				{
					m_gbCampos.Size = new System.Drawing.Size(m_gbCampos.Size.Width + 280, m_gbCampos.Size.Height);
					m_lvCampos.Size = new System.Drawing.Size(m_lvCampos.Size.Width + 280, m_lvCampos.Size.Height);
					m_gbCampos.Left = m_gbEtiquetas.Left;
					m_lvCampos.Left = m_lvEtiquetas.Left;
					m_gbEtiquetas.Visible = false;
					m_lvEtiquetas.Visible = false;
				}
			}

			private void RefreshLvCamposBDDados()
			{
				System.Windows.Forms.ListViewItem lviItem; 

				m_lvCampos.Columns[0].Width = m_lvCampos.Width - 30;
				m_lvCampos.Items.Clear();

				mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow dtrwCampoRelatorio;
				mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBDRow dtrwCampoTotalRelatorio;
				for (int nCont = 0; nCont < m_typDatSetTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.Rows.Count;nCont++)
				{
					dtrwCampoRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow)m_typDatSetTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.Rows[nCont];
					if ((!dtrwCampoRelatorio.nIdCampoBD.ToString().EndsWith("00")) && (!dtrwCampoRelatorio.nIdCampoBD.ToString().EndsWith("98")))
					{
						dtrwCampoTotalRelatorio = m_typDatSetTbRelatoriosTodosCamposBD.tbRelatoriosTodosCamposBD.FindBynIdCampoBD(dtrwCampoRelatorio.nIdCampoBD);
						if (dtrwCampoTotalRelatorio != null)
						{
							lviItem = m_lvCampos.Items.Add(dtrwCampoRelatorio.strNomeCampoNoRelatorio);
							lviItem.Tag = dtrwCampoRelatorio.nIdCampoBD;
							lviItem.SubItems.Add(dtrwCampoRelatorio.bCallbackClicavel.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bPertenceAreaProdutos.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bAlinhamentoInferiorAreaProdutos.ToString());
							lviItem.SubItems.Add(dtrwCampoRelatorio.nAlinhamento.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.bImprimirSomenteUltimaPagina.ToString());
							lviItem.SubItems.Add(dtrwCampoTotalRelatorio.nFormatoNumero.ToString());
						}
						else
						{
							if (dtrwCampoRelatorio.nIdCampoBD.ToString().EndsWith("97"))
							{
								lviItem = m_lvCampos.Items.Add(dtrwCampoRelatorio.strNomeCampoNoRelatorio);
								lviItem.Tag = dtrwCampoRelatorio.nIdCampoBD;
								lviItem.SubItems.Add(false.ToString());
								lviItem.SubItems.Add(true.ToString());
								lviItem.SubItems.Add(false.ToString());
								lviItem.SubItems.Add(dtrwCampoRelatorio.nAlinhamento.ToString());
								lviItem.SubItems.Add(false.ToString());
								lviItem.SubItems.Add("0");
							}
						}
					}
				}
			}

			private void RefreshTxtCamposBDEtiqueta()
			{
				try
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_lvEtiquetas.SelectedItems.Count > 0)
						{
							m_strTexto = m_lvEtiquetas.SelectedItems[0].Text;
							m_lbTextoEdicao.Text = m_strTexto;
							m_lbTextoEdicao.BackColor = m_lvEtiquetas.BackColor;
							m_lbFonte.Text = m_cls_call_CallBack.strCarregaDados(Int32.Parse(m_lvEtiquetas.SelectedItems[0].Tag.ToString()));
							if (m_lvCampos.SelectedItems.Count > 0)
								m_lvCampos.SelectedItems[0].Selected = false;

						}
						m_bAtivado = !m_bAtivado;
					}
				}catch(System.Exception eErro){
					m_cls_ter_tratadorErro.trataErro(ref eErro);
				}
			}

			private void RefreshTxtCamposBDDados()
			{
				try
				{
					if (m_bAtivado)
					{
						m_bAtivado = !m_bAtivado;
						if (m_lvCampos.SelectedItems.Count > 0)
						{
							m_strTexto = m_lvCampos.SelectedItems[0].Text;
							m_lbTextoEdicao.Text = m_strTexto;
							m_lbTextoEdicao.BackColor = m_lvCampos.BackColor;
							m_lbFonte.Text = m_cls_call_CallBack.strCarregaDados(Int32.Parse(m_lvCampos.SelectedItems[0].Tag.ToString()));
							if (m_lvEtiquetas.SelectedItems.Count > 0)
								m_lvEtiquetas.SelectedItems[0].Selected = false;
						}
						m_bAtivado = !m_bAtivado;
					}
				}catch(System.Exception eErro){
					m_cls_ter_tratadorErro.trataErro(ref eErro);
				}
			}
		#endregion

		#region Retorno
			public void RetornaValores(out int nIdCampoBD,out string strTexto, out System.Drawing.Font fntFonte,out System.Drawing.Color clrCor,out bool bVisivelImpressao, out bool bCallBack, out bool bPertenceAreaProdutos,out bool bAlinhamentoInferiorAreaProdutos, out int nAlinhamento, out bool bImprimirSomenteUltimaPagina, out int nFormatoNumero)
			{
				nIdCampoBD = m_nIdCampoBD;
				strTexto = m_strTexto;
				fntFonte = m_fntFonte;
				clrCor = m_clrTexto;
				bVisivelImpressao = m_bVisivelImpressao;
				bCallBack = m_bCallBack;
				bPertenceAreaProdutos = m_bPertenceAreaProdutos;
				bAlinhamentoInferiorAreaProdutos = m_bAlinhamentoInferiorAreaProdutos;
				nAlinhamento = m_nAlinhamento;
				bImprimirSomenteUltimaPagina = m_bImprimirSomenteUltimaPagina;
				nFormatoNumero = m_nFormatoNumero;
			}
		#endregion

	}
}
