using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosCertificadoOrigem.Frames
{
	/// <summary>
	/// Summary description for frmFProdutosCertificado.
	/// </summary>
	internal class frmFProdutosCertificado : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallRefreshProdutos(ref mdlComponentesGraficos.TreeView tvProdutos);
			public delegate void delCallRefreshNormas(ref mdlComponentesGraficos.ListView lvNormas);
			public delegate void delCallRefreshProdutosAssociados(ref mdlComponentesGraficos.TreeView tvProdutosAssociados);
			public delegate bool delCallNormaEdita(int nIdNorma);
			public delegate bool delCallPossuiProdutosSemClassificacao();
			public delegate bool delCallShowDialogProdutosVincular();
			public delegate bool delCallCarregaDadosProdutos();
			public delegate bool delCallCarregaDadosClassificacao();
			public delegate bool delCallSalvaDadosBD();
			public delegate bool delCallInsereProdutos(ref System.Collections.ArrayList arlProdutos,int nIdNorma);
			public delegate bool delCallRemoveProdutos(ref System.Collections.ArrayList arlProdutos);
			public delegate bool delCallShowDialogPersonalizarClassificacao(System.Collections.ArrayList arlProdutos);
			public delegate bool delCallShowDialogPersonalizarProduto(int nIdProdutoCertificadoOrigem);
		#endregion
		#region Events
			public event delCallRefreshProdutos eCallRefreshProdutos;
			public event delCallRefreshNormas eCallRefreshNormas;
			public event delCallRefreshProdutosAssociados eCallRefreshProdutosAssociados;
			public event delCallNormaEdita eCallNormaEdita;
			public event delCallPossuiProdutosSemClassificacao eCallPossuiProdutosSemClassificacao;
			public event delCallShowDialogProdutosVincular eCallShowDialogProdutosVincular;
			public event delCallCarregaDadosProdutos eCallCarregaDadosProdutos;
			public event delCallCarregaDadosClassificacao eCallCarregaDadosClassificacao;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
			public event delCallInsereProdutos eCallInsereProdutos;
			public event delCallRemoveProdutos eCallRemoveProdutos;
			public event delCallShowDialogPersonalizarClassificacao eCallShowDialogPersonalizarClassificacao;
			public event delCallShowDialogPersonalizarProduto eCallShowDialogPersonalizarProduto;
			#endregion
		#region Events Methods
			protected void OnCallRefreshProdutos()
			{
				if (eCallRefreshProdutos != null)
					eCallRefreshProdutos(ref m_tvProdutos);
			}

			protected void OnCallRefreshNormas()
			{
				if (eCallRefreshNormas != null)
					eCallRefreshNormas(ref m_lvNormas);
			}

			protected void OnCallRefreshProdutosAssociados()
			{
				if (eCallRefreshProdutosAssociados != null)
					eCallRefreshProdutosAssociados(ref m_tvProdutosNormas);
			}

			protected bool OnCallNormaEdita()
			{
				bool bRetorno = false; 
				if (eCallNormaEdita != null)
				{
					if (m_lvNormas.SelectedItems.Count > 0)
						bRetorno = eCallNormaEdita(Int32.Parse(m_lvNormas.SelectedItems[0].Tag.ToString()));
				}
				return(bRetorno);
			}

			protected bool OnCallPossuiProdutosSemClassificacao()
			{
				bool bRetorno = false; 
				if (eCallPossuiProdutosSemClassificacao != null)
					bRetorno = eCallPossuiProdutosSemClassificacao();
				return(bRetorno);
			}

			protected bool OnCallShowDialogProdutosVincular()
			{
				bool bRetorno = false; 
				if (eCallShowDialogProdutosVincular != null)
					bRetorno = eCallShowDialogProdutosVincular();
				return(bRetorno);
			}

			protected bool OnCallCarregaDadosProdutos()
			{
				bool bRetorno = false; 
				if (eCallCarregaDadosProdutos != null)
					bRetorno = eCallCarregaDadosProdutos();
				return(bRetorno);
			}

			protected bool OnCallCarregaDadosClassificacao()
			{
				bool bRetorno = false;
				if (eCallCarregaDadosClassificacao != null)
					bRetorno = eCallCarregaDadosClassificacao();
				return(bRetorno);
			}	

			protected virtual bool OnCallSalvaDadosBD()
			{
				bool bRetorno = false;
				if (eCallSalvaDadosBD != null)
					bRetorno = eCallSalvaDadosBD();
				return(bRetorno);
			}

			protected virtual bool OnCallInsereProdutos()
			{
				bool bRetorno = false;
				if (eCallInsereProdutos != null)
				{
					if (m_tvProdutos.SelectedNode != null)
					{
						// Com Normas
						if ((eCallRefreshNormas != null) && (m_lvNormas.SelectedItems.Count == 0))
						{
							mdlMensagens.clsMensagens.ShowInformation("Você deve selecionar uma norma para vincular o produto.");
							return(false);
						}


						// Norma
						int nIdNorma = -1;
						if (m_lvNormas.SelectedItems.Count > 0)
							nIdNorma = Int32.Parse(m_lvNormas.SelectedItems[0].Tag.ToString());
						// Produtos
						System.Collections.ArrayList arlProdutos = new ArrayList();
						if (m_tvProdutos.SelectedNode.Parent == null)
						{
							// Classificacao
							foreach(System.Windows.Forms.TreeNode tvnNodoChild in m_tvProdutos.SelectedNode.Nodes)
								arlProdutos.Add(Int32.Parse(tvnNodoChild.Tag.ToString()));
						}else{
							// Produto
							arlProdutos.Add(Int32.Parse(m_tvProdutos.SelectedNode.Tag.ToString()));
						}
						bRetorno = eCallInsereProdutos(ref arlProdutos,nIdNorma);
					}
				}
				return(bRetorno);
			}

			protected virtual bool OnCallRemoveProdutos()
			{
				bool bRetorno = false;
				if (eCallRemoveProdutos != null)
				{
					if (m_tvProdutosNormas.SelectedNode != null)
					{
						System.Collections.ArrayList arlProdutos = new ArrayList();
						if (m_tvProdutosNormas.SelectedNode.Parent == null)
						{
							// Com Normas 
							foreach(System.Windows.Forms.TreeNode tvnNodoClass in m_tvProdutosNormas.SelectedNode.Nodes)
							{
								if (tvnNodoClass.Nodes.Count > 0)
								{
									foreach(System.Windows.Forms.TreeNode tvnNodoProd in tvnNodoClass.Nodes)
										arlProdutos.Add(Int32.Parse(tvnNodoProd.Tag.ToString()));
								}else{
									arlProdutos.Add(Int32.Parse(tvnNodoClass.Tag.ToString()));
								}
							}
						}
						else
						{
							if (m_tvProdutosNormas.SelectedNode.Nodes.Count > 0)
							{
								// Classificacao
								foreach(System.Windows.Forms.TreeNode tvnNodoChild in m_tvProdutosNormas.SelectedNode.Nodes)
									arlProdutos.Add(Int32.Parse(tvnNodoChild.Tag.ToString()));
							}
							else
							{
								// Produto
								arlProdutos.Add(Int32.Parse(m_tvProdutosNormas.SelectedNode.Tag.ToString()));
							}
						}

						bRetorno = eCallRemoveProdutos(ref arlProdutos);
					}
				}
				return(bRetorno);
			}

			private bool OnCallShowDialogPersonalizar(System.Windows.Forms.TreeNode tvnPersonalizar)
			{
				if (!m_lvNormas.Visible)
					return(OnCallShowDialogPersonalizarSemNormas(tvnPersonalizar));
				else
					return(OnCallShowDialogPersonalizarComNormas(tvnPersonalizar));
			}

			private bool OnCallShowDialogPersonalizarComNormas(System.Windows.Forms.TreeNode tvnPersonalizar)
			{
				if (tvnPersonalizar.Parent != null)
				{
					if (tvnPersonalizar.Parent.Parent == null)
					{
						// Classificacao
						if (eCallShowDialogPersonalizarClassificacao == null)
							return(false);
						System.Collections.ArrayList arlProdutos = new ArrayList();
						for(int i = 0; i < tvnPersonalizar.Nodes.Count;i++)
						{
							int nIdProdutoCertificado = -1;
							try
							{
								nIdProdutoCertificado = Int32.Parse(tvnPersonalizar.Nodes[i].Tag.ToString());
							}
							catch
							{
								nIdProdutoCertificado = -1;
							}
							if (nIdProdutoCertificado != -1)
								arlProdutos.Add(nIdProdutoCertificado);
						}
						if (arlProdutos.Count == 0)
							return(false);
						return(eCallShowDialogPersonalizarClassificacao(arlProdutos));
					}else{
						// Produto
						if (eCallShowDialogPersonalizarProduto == null)
							return(false);
						int nIdProdutoCertificado = -1;
						try
						{
							nIdProdutoCertificado = Int32.Parse(tvnPersonalizar.Tag.ToString());
						}
						catch
						{
							nIdProdutoCertificado = -1;
						}
						if (nIdProdutoCertificado == -1)
							return(false);
						return(eCallShowDialogPersonalizarProduto(nIdProdutoCertificado));
					}
				}
				return(false);
			} 

			private bool OnCallShowDialogPersonalizarSemNormas(System.Windows.Forms.TreeNode tvnPersonalizar)
			{
				if (tvnPersonalizar.Parent == null)
				{
					// Classificacao
					if (eCallShowDialogPersonalizarClassificacao == null)
						return(false);
					System.Collections.ArrayList arlProdutos = new ArrayList();
					for(int i = 0; i < tvnPersonalizar.Nodes.Count;i++)
					{
						int nIdProdutoCertificado = -1;
						try
						{
							nIdProdutoCertificado = Int32.Parse(tvnPersonalizar.Nodes[i].Tag.ToString());
						}
						catch
						{
							nIdProdutoCertificado = -1;
						}
						if (nIdProdutoCertificado != -1)
							arlProdutos.Add(nIdProdutoCertificado);
					}
					if (arlProdutos.Count == 0)
						return(false);
					return(eCallShowDialogPersonalizarClassificacao(arlProdutos));
				}
				else
				{
					// Produto
					if (eCallShowDialogPersonalizarProduto == null)
						return(false);
					int nIdProdutoCertificado = -1;
					try
					{
						nIdProdutoCertificado = Int32.Parse(tvnPersonalizar.Tag.ToString());
					}
					catch
					{
						nIdProdutoCertificado = -1;
					}
					if (nIdProdutoCertificado == -1)
						return(false);
					return(eCallShowDialogPersonalizarProduto(nIdProdutoCertificado));
				}
			} 
		#endregion

		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected string m_strEnderecoExecutavel;

			protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
			protected bool m_bMostrarBaloes = true;

			private static int m_nContadorProdutosLivresBalao = 0;
			private static int m_nContadorNormasBalao = 0;
			private static int m_nContadorInsereBalao = 0;

			private System.Drawing.Color m_clrPositive = System.Drawing.Color.Green;
			private System.Drawing.Color m_clrNegative = System.Drawing.Color.Red;

			public bool m_bModificado = false;
			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.GroupBox m_gbProdutos;
			private System.Windows.Forms.GroupBox m_gbNormas;
			private System.Windows.Forms.GroupBox m_gbBotoes;
			private System.Windows.Forms.GroupBox m_gbProdutosNormas;
			private mdlComponentesGraficos.TreeView m_tvProdutos;
			private mdlComponentesGraficos.TreeView m_tvProdutosNormas;
			private mdlComponentesGraficos.ListView m_lvNormas;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btTrocarCor;
			private System.Windows.Forms.Button m_btInsereProduto;
			private System.Windows.Forms.Button m_btRetiraProduto;
			private System.Windows.Forms.PictureBox m_pbInsere;
			private System.Windows.Forms.PictureBox m_pbRetira;
			private System.Windows.Forms.ColumnHeader m_chFirst;
			private System.Windows.Forms.ToolTip m_ttProdutosCOs;
			private System.Windows.Forms.Button m_btVincular;
			private System.Windows.Forms.Timer m_tiLoad;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Construtors and Destructos
			public frmFProdutosCertificado(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				m_cls_ter_tratadorErro = clstratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
			public frmFProdutosCertificado(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bMostrarBaloes)
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				m_cls_ter_tratadorErro = clstratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_bMostrarBaloes = bMostrarBaloes;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosCertificado));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_tvProdutos = new mdlComponentesGraficos.TreeView();
			this.m_gbProdutosNormas = new System.Windows.Forms.GroupBox();
			this.m_tvProdutosNormas = new mdlComponentesGraficos.TreeView();
			this.m_gbNormas = new System.Windows.Forms.GroupBox();
			this.m_lvNormas = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_gbBotoes = new System.Windows.Forms.GroupBox();
			this.m_btVincular = new System.Windows.Forms.Button();
			this.m_pbRetira = new System.Windows.Forms.PictureBox();
			this.m_pbInsere = new System.Windows.Forms.PictureBox();
			this.m_btRetiraProduto = new System.Windows.Forms.Button();
			this.m_btInsereProduto = new System.Windows.Forms.Button();
			this.m_ttProdutosCOs = new System.Windows.Forms.ToolTip(this.components);
			this.m_tiLoad = new System.Windows.Forms.Timer(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbGeral.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.m_gbProdutosNormas.SuspendLayout();
			this.m_gbNormas.SuspendLayout();
			this.m_gbBotoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbGeral);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(734, 510);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 8);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 12;
			this.m_ttProdutosCOs.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(305, 480);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttProdutosCOs.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(369, 480);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttProdutosCOs.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbProdutos);
			this.m_gbGeral.Controls.Add(this.m_gbProdutosNormas);
			this.m_gbGeral.Controls.Add(this.m_gbNormas);
			this.m_gbGeral.Controls.Add(this.m_gbBotoes);
			this.m_gbGeral.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbGeral.Location = new System.Drawing.Point(8, 7);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(717, 466);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutos.Controls.Add(this.m_tvProdutos);
			this.m_gbProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutos.Location = new System.Drawing.Point(8, 11);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(344, 234);
			this.m_gbProdutos.TabIndex = 0;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Produtos da Fatura Comercial";
			// 
			// m_tvProdutos
			// 
			this.m_tvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvProdutos.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_tvProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tvProdutos.HideSelection = false;
			this.m_tvProdutos.ImageIndex = -1;
			this.m_tvProdutos.Location = new System.Drawing.Point(8, 15);
			this.m_tvProdutos.Name = "m_tvProdutos";
			this.m_tvProdutos.SelectedImageIndex = -1;
			this.m_tvProdutos.Size = new System.Drawing.Size(328, 211);
			this.m_tvProdutos.TabIndex = 0;
			this.m_tvProdutos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvProdutos_AfterSelect);
			// 
			// m_gbProdutosNormas
			// 
			this.m_gbProdutosNormas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutosNormas.Controls.Add(this.m_tvProdutosNormas);
			this.m_gbProdutosNormas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosNormas.Location = new System.Drawing.Point(8, 308);
			this.m_gbProdutosNormas.Name = "m_gbProdutosNormas";
			this.m_gbProdutosNormas.Size = new System.Drawing.Size(701, 150);
			this.m_gbProdutosNormas.TabIndex = 3;
			this.m_gbProdutosNormas.TabStop = false;
			this.m_gbProdutosNormas.Text = "Produtos Inseridos no Certificado";
			// 
			// m_tvProdutosNormas
			// 
			this.m_tvProdutosNormas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvProdutosNormas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tvProdutosNormas.HideSelection = false;
			this.m_tvProdutosNormas.ImageIndex = -1;
			this.m_tvProdutosNormas.Location = new System.Drawing.Point(8, 15);
			this.m_tvProdutosNormas.Name = "m_tvProdutosNormas";
			this.m_tvProdutosNormas.SelectedImageIndex = -1;
			this.m_tvProdutosNormas.Size = new System.Drawing.Size(685, 127);
			this.m_tvProdutosNormas.TabIndex = 0;
			this.m_tvProdutosNormas.DoubleClick += new System.EventHandler(this.m_tvProdutosNormas_DoubleClick);
			// 
			// m_gbNormas
			// 
			this.m_gbNormas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbNormas.Controls.Add(this.m_lvNormas);
			this.m_gbNormas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbNormas.Location = new System.Drawing.Point(356, 11);
			this.m_gbNormas.Name = "m_gbNormas";
			this.m_gbNormas.Size = new System.Drawing.Size(352, 234);
			this.m_gbNormas.TabIndex = 1;
			this.m_gbNormas.TabStop = false;
			this.m_gbNormas.Text = "Normas";
			// 
			// m_lvNormas
			// 
			this.m_lvNormas.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvNormas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvNormas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_chFirst});
			this.m_lvNormas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvNormas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvNormas.HideSelection = false;
			this.m_lvNormas.Location = new System.Drawing.Point(8, 15);
			this.m_lvNormas.Name = "m_lvNormas";
			this.m_lvNormas.Size = new System.Drawing.Size(336, 211);
			this.m_lvNormas.TabIndex = 0;
			this.m_lvNormas.View = System.Windows.Forms.View.Details;
			this.m_lvNormas.DoubleClick += new System.EventHandler(this.m_lvNormas_DoubleClick);
			this.m_lvNormas.SelectedIndexChanged += new System.EventHandler(this.m_lvNormas_SelectedIndexChanged);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 500;
			// 
			// m_gbBotoes
			// 
			this.m_gbBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbBotoes.Controls.Add(this.m_btVincular);
			this.m_gbBotoes.Controls.Add(this.m_pbRetira);
			this.m_gbBotoes.Controls.Add(this.m_pbInsere);
			this.m_gbBotoes.Controls.Add(this.m_btRetiraProduto);
			this.m_gbBotoes.Controls.Add(this.m_btInsereProduto);
			this.m_gbBotoes.Location = new System.Drawing.Point(8, 243);
			this.m_gbBotoes.Name = "m_gbBotoes";
			this.m_gbBotoes.Size = new System.Drawing.Size(701, 61);
			this.m_gbBotoes.TabIndex = 2;
			this.m_gbBotoes.TabStop = false;
			// 
			// m_btVincular
			// 
			this.m_btVincular.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVincular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVincular.Location = new System.Drawing.Point(8, 24);
			this.m_btVincular.Name = "m_btVincular";
			this.m_btVincular.Size = new System.Drawing.Size(144, 24);
			this.m_btVincular.TabIndex = 6;
			this.m_btVincular.Text = "Classificação Tarifária";
			this.m_btVincular.Click += new System.EventHandler(this.m_btVincular_Click);
			// 
			// m_pbRetira
			// 
			this.m_pbRetira.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_pbRetira.Image = ((System.Drawing.Image)(resources.GetObject("m_pbRetira.Image")));
			this.m_pbRetira.Location = new System.Drawing.Point(584, 126);
			this.m_pbRetira.Name = "m_pbRetira";
			this.m_pbRetira.Size = new System.Drawing.Size(60, 40);
			this.m_pbRetira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.m_pbRetira.TabIndex = 4;
			this.m_pbRetira.TabStop = false;
			this.m_pbRetira.Visible = false;
			// 
			// m_pbInsere
			// 
			this.m_pbInsere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_pbInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_pbInsere.Image")));
			this.m_pbInsere.Location = new System.Drawing.Point(512, 126);
			this.m_pbInsere.Name = "m_pbInsere";
			this.m_pbInsere.Size = new System.Drawing.Size(60, 40);
			this.m_pbInsere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.m_pbInsere.TabIndex = 3;
			this.m_pbInsere.TabStop = false;
			this.m_pbInsere.Visible = false;
			// 
			// m_btRetiraProduto
			// 
			this.m_btRetiraProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRetiraProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btRetiraProduto.Image")));
			this.m_btRetiraProduto.Location = new System.Drawing.Point(355, 14);
			this.m_btRetiraProduto.Name = "m_btRetiraProduto";
			this.m_btRetiraProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btRetiraProduto.TabIndex = 5;
			this.m_ttProdutosCOs.SetToolTip(this.m_btRetiraProduto, "Retira");
			this.m_btRetiraProduto.Click += new System.EventHandler(this.m_btRetiraProduto_Click);
			// 
			// m_btInsereProduto
			// 
			this.m_btInsereProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInsereProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btInsereProduto.Image")));
			this.m_btInsereProduto.Location = new System.Drawing.Point(283, 14);
			this.m_btInsereProduto.Name = "m_btInsereProduto";
			this.m_btInsereProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btInsereProduto.TabIndex = 4;
			this.m_ttProdutosCOs.SetToolTip(this.m_btInsereProduto, "Insere");
			this.m_btInsereProduto.Click += new System.EventHandler(this.m_btInsereProduto_Click);
			// 
			// m_ttProdutosCOs
			// 
			this.m_ttProdutosCOs.AutomaticDelay = 100;
			this.m_ttProdutosCOs.AutoPopDelay = 5000;
			this.m_ttProdutosCOs.InitialDelay = 100;
			this.m_ttProdutosCOs.ReshowDelay = 20;
			// 
			// m_tiLoad
			// 
			this.m_tiLoad.Enabled = true;
			this.m_tiLoad.Tick += new System.EventHandler(this.m_tiLoad_Tick);
			// 
			// frmFProdutosCertificado
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(738, 512);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosCertificado";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Produtos do Certificado de Origem";
			this.Load += new System.EventHandler(this.frmFProdutosCertificado_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.m_gbProdutosNormas.ResumeLayout(false);
			this.m_gbNormas.ResumeLayout(false);
			this.m_gbBotoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formularios
				private void frmFProdutosCertificado_Load(object sender, System.EventArgs e)
				{
					vRefreshInterface();
					this.vMostraCor();
					OnCallRefreshProdutos();
					OnCallRefreshNormas();
					OnCallRefreshProdutosAssociados();
				}
			#endregion
			#region tvProdutos
				private void m_tvProdutos_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					fechaBalao();
					if ((m_tvProdutosNormas.Nodes.Count == 0) && (m_lvNormas.Visible))
						mostraBalaoNormas(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_SelecionarNorma.ToString()));
					else
						mostraBalaoInsere(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_InserirProduto.ToString()));
				}
			#endregion
			#region tvNormas
				private void m_lvNormas_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					fechaBalao();
					mostraBalaoInsere(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_InserirProduto.ToString()));
				}

				private void m_lvNormas_DoubleClick(object sender, System.EventArgs e)
				{
					if (OnCallNormaEdita())
					{
						OnCallRefreshNormas();
						OnCallRefreshProdutosAssociados();
					}
				}
			#endregion
			#region tvProdutosNormas
				private void m_tvProdutosNormas_DoubleClick(object sender, System.EventArgs e)
				{
					if (m_tvProdutosNormas.SelectedNode != null)
						if (OnCallShowDialogPersonalizar(m_tvProdutosNormas.SelectedNode))
							OnCallRefreshProdutosAssociados();
				}
			#endregion
			#region Timers
				private void m_tiLoad_Tick(object sender, System.EventArgs e)
				{
					m_tiLoad.Enabled = false;
					vProdutosSemClassificacao();
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try 
					{
						this.vMostraCor();
					} 
					catch (Exception err) 
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btVincular_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogProdutosVincular())
					{
						OnCallCarregaDadosProdutos();
						OnCallCarregaDadosClassificacao();
						OnCallRefreshProdutos();
						if (!OnCallPossuiProdutosSemClassificacao())
							m_btVincular.ForeColor = m_clrPositive;
						else
							m_btVincular.ForeColor = m_clrNegative;
					}
				}

				private void m_btInsereProduto_Click(object sender, System.EventArgs e)
				{
					try
					{
						fechaBalao();
						if (OnCallInsereProdutos())
						{
							OnCallRefreshProdutos();
							OnCallRefreshNormas();
							OnCallRefreshProdutosAssociados();
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btRetiraProduto_Click(object sender, System.EventArgs e)
				{
					try
					{
						fechaBalao();
						if (OnCallRemoveProdutos())
						{
							OnCallRefreshProdutos();
							OnCallRefreshNormas();
							OnCallRefreshProdutosAssociados();
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					try 
					{
						fechaBalao();
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (this.m_bModificado = OnCallSalvaDadosBD())
							this.Close();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					} 
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					fechaBalao();
					this.Close();
				}

			#endregion
		#endregion

		#region Interface
			private void vRefreshInterface()
			{
				if (eCallRefreshNormas == null)
				{
					m_lvNormas.Visible = false;
					m_gbNormas.Visible = false;
					m_gbProdutos.Width = m_gbGeral.Width - 15;
					m_btInsereProduto.Image = m_pbInsere.Image;
					m_btRetiraProduto.Image = m_pbRetira.Image;
				}
			}
		#endregion

		#region BalloonTip
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}

		public void mostraBalaoProdutosLivres(string strMensagem)
		{
			try
			{
				if (m_tvProdutosNormas.Nodes.Count == 0)
				{
					if (m_mgblBalaoToolTip != null)
						m_mgblBalaoToolTip.Close();
					if ((m_bMostrarBaloes) && (m_nContadorProdutosLivresBalao == 0))
					{
						m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
						m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
						m_mgblBalaoToolTip.Content = strMensagem;
						m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
						m_mgblBalaoToolTip.CloseOnMouseClick = true;
						m_mgblBalaoToolTip.CloseOnDeactivate = false;
						m_mgblBalaoToolTip.CloseOnKeyPress = false;
						m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)m_tvProdutos);
						m_nContadorProdutosLivresBalao++;
					}
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		public void mostraBalaoNormas(string strMensagem)
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				if ((m_bMostrarBaloes) && (m_nContadorNormasBalao == 0))
				{
					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					m_mgblBalaoToolTip.Content = strMensagem;
					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
					m_mgblBalaoToolTip.CloseOnMouseClick = true;
					m_mgblBalaoToolTip.CloseOnDeactivate = false;
					m_mgblBalaoToolTip.CloseOnKeyPress = false;
					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)m_lvNormas);
					m_nContadorNormasBalao++;
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		public void mostraBalaoInsere(string strMensagem)
		{
			try
			{
				if ((m_tvProdutos.SelectedNode != null) && ((m_lvNormas.SelectedItems.Count > 0) || (!m_lvNormas.Visible)))
				{
					if (m_mgblBalaoToolTip != null)
						m_mgblBalaoToolTip.Close();
					if ((m_bMostrarBaloes) && (m_nContadorInsereBalao == 0))
					{
						m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
						m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
						m_mgblBalaoToolTip.Content = strMensagem;
						m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
						m_mgblBalaoToolTip.CloseOnMouseClick = true;
						m_mgblBalaoToolTip.CloseOnDeactivate = false;
						m_mgblBalaoToolTip.CloseOnKeyPress = false;
						m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)m_btInsereProduto);
						m_nContadorInsereBalao++;
					}
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
					case "mdlComponentesGraficos.TreeView":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion
		#region Produtos sem Vinculo
			private void vProdutosSemClassificacao()
			{
				if (OnCallPossuiProdutosSemClassificacao())
				{
					if (mdlMensagens.clsMensagens.ShowQuestion("Você possui produtos sem vinculação com a classificação tarifária necessária. Deseja vincular agora ?") == System.Windows.Forms.DialogResult.Yes)
					{
						if (OnCallShowDialogProdutosVincular())
						{
							OnCallCarregaDadosProdutos();
							OnCallCarregaDadosClassificacao();
							OnCallRefreshProdutos();
							if (!OnCallPossuiProdutosSemClassificacao())
								m_btVincular.ForeColor = m_clrPositive;
							else
								m_btVincular.ForeColor = m_clrNegative;
						}else{
							m_btVincular.ForeColor = m_clrNegative;
						}
					}else{
						m_btVincular.ForeColor = m_clrNegative;
					}
				}else{
					m_btVincular.ForeColor = m_clrPositive;
				}
			}
		#endregion
	}
}
