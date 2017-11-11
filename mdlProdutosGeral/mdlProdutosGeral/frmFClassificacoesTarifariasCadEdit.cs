using System;
using System.Collections;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for frmFClassificacoesTarifariasCadEdit.
	/// </summary>
	internal class frmFClassificacoesTarifariasCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";
		private System.ComponentModel.IContainer components;

		    private mdlProdutosGeral.TipoClassificacaoTarifaria m_enumClassTar;

		    private mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi = null;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;

            private string m_strCodigo = "";
			private string m_strDenominacao = "";

		    private bool m_bCadastro = false;
			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbFields;
			private mdlComponentesGraficos.TextBox m_tbCodigo;
			private System.Windows.Forms.Label m_lbCodigo;
			private System.Windows.Forms.Label m_lbDenominacao;
			private System.Windows.Forms.TextBox m_tbDenominacao;
			private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.ToolTip m_ttClassificacao;
	
			public bool m_bModificado = false;
			// ***************************************************************************************************
		#endregion
		#region Construtores e Destrutores
			/// <summary>
			/// Constructor do Cadastro NCM
			/// </summary>
			/// <param name="CorForm"></param>
			public frmFClassificacoesTarifariasCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm, mdlProdutosGeral.TipoClassificacaoTarifaria tipoClassTar)
			{
				m_bCadastro = true;
				m_typDatSetTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)typDatSetTbProdutosNcm.Copy();
				m_enumClassTar = tipoClassTar;
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;

				InitializeComponent();

				if (m_enumClassTar == mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm)
				{
					this.Text = "Cadastro Ncm";
				}else{
					this.Text = "Cadastro Naladi";
				}
				
			}

			/// <summary>
			/// Constructor da Edição NCM
			/// </summary>
			/// <param name="CorForm"></param>
			/// <param name="arlClassTar"></param>
			/// <param name="tipoClassTar"></param>
			public frmFClassificacoesTarifariasCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm, mdlProdutosGeral.TipoClassificacaoTarifaria tipoClassTar,string Codigo, string Denominacao)
			{
				m_bCadastro = false;
				m_typDatSetTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)typDatSetTbProdutosNcm.Copy();
				m_enumClassTar = tipoClassTar;
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;

				InitializeComponent();

				if (m_enumClassTar == mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm)
				{
					this.Text = "Edição Ncm";
				}
				else
				{
					this.Text = "Edição Naladi";
				}
                m_tbCodigo.Text = m_strCodigo = Codigo;
				m_tbDenominacao.Text = m_strDenominacao = Denominacao;
			}


			/// <summary>
			/// Constructor do Cadastro NALDI
			/// </summary>
			/// <param name="CorForm"></param>
			public frmFClassificacoesTarifariasCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria tipoClassTar)
			{
				m_bCadastro = true;
				m_typDatSetTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)typDatSetTbProdutosNaladi.Copy();
				m_enumClassTar = tipoClassTar;
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;

				InitializeComponent();

				if (m_enumClassTar == mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm)
				{
					this.Text = "Cadastro Ncm";
				}
				else
				{
					this.Text = "Cadastro Naladi";
				}
					
			}

			/// <summary>
			/// Constructor da Edição NALADI
			/// </summary>
			/// <param name="CorForm"></param>
			/// <param name="arlClassTar"></param>
			/// <param name="tipoClassTar"></param>
			public frmFClassificacoesTarifariasCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi, mdlProdutosGeral.TipoClassificacaoTarifaria tipoClassTar,string Codigo, string Denominacao)
			{
				m_bCadastro = false;
				m_typDatSetTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)typDatSetTbProdutosNaladi.Copy();
				m_enumClassTar = tipoClassTar;
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;

				InitializeComponent();

				if (m_enumClassTar == mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm)
				{
					this.Text = "Edição Ncm";
				}
				else
				{
					this.Text = "Edição Naladi";
				}
				m_tbCodigo.Text = m_strCodigo = Codigo;
				m_tbDenominacao.Text = m_strDenominacao = Denominacao;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFClassificacoesTarifariasCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbDenominacao = new System.Windows.Forms.TextBox();
			this.m_tbCodigo = new mdlComponentesGraficos.TextBox();
			this.m_lbCodigo = new System.Windows.Forms.Label();
			this.m_lbDenominacao = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttClassificacao = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 158);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttClassificacao.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbDenominacao);
			this.m_gbFields.Controls.Add(this.m_tbCodigo);
			this.m_gbFields.Controls.Add(this.m_lbCodigo);
			this.m_gbFields.Controls.Add(this.m_lbDenominacao);
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 114);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_tbDenominacao
			// 
			this.m_tbDenominacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbDenominacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDenominacao.Location = new System.Drawing.Point(100, 36);
			this.m_tbDenominacao.Multiline = true;
			this.m_tbDenominacao.Name = "m_tbDenominacao";
			this.m_tbDenominacao.Size = new System.Drawing.Size(258, 71);
			this.m_tbDenominacao.TabIndex = 2;
			this.m_tbDenominacao.Text = "";
			this.m_ttClassificacao.SetToolTip(this.m_tbDenominacao, "Denominação obrigatória");
			// 
			// m_tbCodigo
			// 
			this.m_tbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_tbCodigo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCodigo.Location = new System.Drawing.Point(100, 12);
			this.m_tbCodigo.Mask = true;
			this.m_tbCodigo.MaskAutomaticSpecialCharacters = true;
			this.m_tbCodigo.MaskText = "NNNN.NN.NN";
			this.m_tbCodigo.Name = "m_tbCodigo";
			this.m_tbCodigo.Size = new System.Drawing.Size(61, 20);
			this.m_tbCodigo.TabIndex = 1;
			this.m_tbCodigo.Text = "0000.00.00";
			this.m_ttClassificacao.SetToolTip(this.m_tbCodigo, "Código no formato XXXX.XX.XX");
			this.m_tbCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbCodigo_KeyUp);
			this.m_tbCodigo.Enter += new System.EventHandler(this.m_tbCodigo_Enter);
			// 
			// m_lbCodigo
			// 
			this.m_lbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lbCodigo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCodigo.Location = new System.Drawing.Point(8, 12);
			this.m_lbCodigo.Name = "m_lbCodigo";
			this.m_lbCodigo.Size = new System.Drawing.Size(47, 16);
			this.m_lbCodigo.TabIndex = 0;
			this.m_lbCodigo.Text = "Código:";
			// 
			// m_lbDenominacao
			// 
			this.m_lbDenominacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lbDenominacao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDenominacao.Location = new System.Drawing.Point(8, 36);
			this.m_lbDenominacao.Name = "m_lbDenominacao";
			this.m_lbDenominacao.Size = new System.Drawing.Size(84, 16);
			this.m_lbDenominacao.TabIndex = 0;
			this.m_lbDenominacao.Text = "Denominação:";
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 127);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttClassificacao.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 127);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttClassificacao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttClassificacao
			// 
			this.m_ttClassificacao.AutomaticDelay = 100;
			this.m_ttClassificacao.AutoPopDelay = 5000;
			this.m_ttClassificacao.InitialDelay = 100;
			this.m_ttClassificacao.ReshowDelay = 20;
			// 
			// frmFClassificacoesTarifariasCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 160);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFClassificacoesTarifariasCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Classificações Tarifárias";
			this.Load += new System.EventHandler(this.frmFClassificacoesTarifariasCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulario
			private void m_btOk_Click(object sender, System.EventArgs e)
			{
				if (bPossuiIntegridadeDados())
				{
					m_bModificado = true;
					Close();
				}
			}
			private void m_btCancelar_Click(object sender, System.EventArgs e)
			{
				m_bModificado = false;
				Close();
			}
			private void m_btTrocarCor_Click(object sender, System.EventArgs e)
			{
				try
				{
					this.trocaCor();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void frmFClassificacoesTarifariasCadEdit_Load(object sender, System.EventArgs e)
			{
				try
				{
					this.mostraCor();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void m_tbCodigo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				try
				{
//					if ((m_tbCodigo.Text.Length > 0 && (e.KeyCode != System.Windows.Forms.Keys.Back)))
//					{
//						switch (m_tbCodigo.Text.Length)
//						{
//							case 4: m_tbCodigo.Text += ".";
//								break;
//							case 7: m_tbCodigo.Text += ".";
//								break;
//							//case 10: m_tbDenominacao.Focus();
//							//	break;
//						}
//						//m_tbCodigo.SelectionStart = m_tbCodigo.Text.Length;
//					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void m_tbCodigo_Enter(object sender, System.EventArgs e)
			{
				try
				{
					if (m_tbCodigo.Text == "0000.00.00")
					{
						m_tbCodigo.Text = "";
						m_tbCodigo.SelectionStart = m_tbCodigo.Text.Length;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
		#region Métodos do Formulário Referentes ao Cadastro

			private bool bPossuiIntegridadeDadosComoCadastro()
			{
				bool bRetorno = true;
				string strCodigo = m_tbCodigo.Text;
				try
				{
					switch(m_enumClassTar)
					{
						case mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm:
							for(int nCont = 0 ; nCont < m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows.Count;nCont++)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow)m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows[nCont];
								if (dtrwTbProdutosNcm.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwTbProdutosNcm.strNcm == strCodigo)
										bRetorno = false;
									if (!bRetorno)
										break;
								}
							}
							break;	
						case mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi:
							for(int nCont = 0 ; nCont < m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows.Count;nCont++)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow)m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows[nCont];
								if (dtrwTbProdutosNaladi.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwTbProdutosNaladi.strNaladi == strCodigo)
										bRetorno = false;
									if (!bRetorno)
										break;
								}
							}
							break;
					}					
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return(bRetorno);
			}
		#endregion
		#region Métodos do Formulário Referentes a Edição

			private bool bPossuiIntegridadeDadosComoEdicao()
			{
				bool bRetorno = true;
				string strCodigo = m_tbCodigo.Text;
				try
				{
					switch(m_enumClassTar)
					{
						case mdlProdutosGeral.TipoClassificacaoTarifaria.Ncm:
							for(int nCont = 0 ; nCont < m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows.Count;nCont++)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow)m_typDatSetTbProdutosNcm.tbProdutosNcm.Rows[nCont];
								if (dtrwTbProdutosNcm.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwTbProdutosNcm.strNcm == strCodigo && dtrwTbProdutosNcm.strNcm != m_strCodigo)
										bRetorno = false;
									if (!bRetorno)
										break;
								}
							}
							break;	
						case mdlProdutosGeral.TipoClassificacaoTarifaria.Naladi:
							for(int nCont = 0 ; nCont < m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows.Count;nCont++)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = (mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow)m_typDatSetTbProdutosNaladi.tbProdutosNaladi.Rows[nCont];
								if (dtrwTbProdutosNaladi.RowState != System.Data.DataRowState.Deleted)
								{
									if (dtrwTbProdutosNaladi.strNaladi == strCodigo && dtrwTbProdutosNaladi.strNaladi != m_strCodigo)
										bRetorno = false;
									if (!bRetorno)
										break;
								}
							}
							break;
					}					
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				return(bRetorno);
			}
		#endregion
		#region Métodos do Formulário

		private bool bPossuiCodigoValido()
		{
			bool bRetorno = false;
			string strCodigo = m_tbCodigo.Text.Trim();
			if (strCodigo != "")
			{
				if (strCodigo.Length == 10)
				{
					if ((strCodigo[4] == '.') && (strCodigo[7] == '.') )
					{	
						try	
						{
							if ((Int32.Parse(strCodigo.Substring(0,4)) >= 0) && (Int32.Parse(strCodigo.Substring(5,2)) >= 0 ) && (Int32.Parse(strCodigo.Substring(8,2)) >= 0 ))
							{
		                        bRetorno = true;
							}
							// Numero
						}catch{
						}
					}
				}
			}
			return (bRetorno);
		}

		private bool bPossuiIntegridadeDados()
		{
			bool bRetorno = false;

			if (bPossuiCodigoValido())
			{
				if (bPossuiCodigoEDescricao())
				{
					if (m_bCadastro)
					{ // Cadastro
						if (bPossuiIntegridadeDadosComoCadastro())
						{
							m_strCodigo = m_tbCodigo.Text;
							m_strDenominacao = m_tbDenominacao.Text;
							bRetorno = true;
						}
						else
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_CodigoJaExiste));
							//MessageBox.Show("O código digitado já existe.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
							m_tbCodigo.Focus();
						}
					}
					else
					{ // Edição
						if (bPossuiIntegridadeDadosComoEdicao())
						{
							m_strCodigo = m_tbCodigo.Text;
							m_strDenominacao = m_tbDenominacao.Text;
							bRetorno = true;
						}
						else
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_CodigoJaExiste));
							//MessageBox.Show("O código digitado já existe.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
							m_tbCodigo.Focus();
						}
					}
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text, mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_PreencherTudo));
					m_tbDenominacao.Focus();
				}
			}else{
				mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_CodigoInvalido));
                //MessageBox.Show("O código digitado não é válido.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				m_tbCodigo.Focus();
			}
			return(bRetorno);
   		}
		private bool bPossuiCodigoEDescricao()
		{
			if (m_tbCodigo.Text.Trim() != "")
			{
				if (m_tbDenominacao.Text.Trim() != "")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		#endregion
		#region Métodos Referentes ao Retorno dos Dados
			public void retornaDados(out string Codigo, out string Denominacao)
			{
				Codigo = m_strCodigo;
				Denominacao = m_strDenominacao;
			}		
			public void retornaDados(out mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi)
			{
				typDatSetTbProdutosNaladi = m_typDatSetTbProdutosNaladi;
			}
			public void retornaDados(out mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm)
			{
				typDatSetTbProdutosNcm = m_typDatSetTbProdutosNcm;
			}
		#endregion
	}
}
