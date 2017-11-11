using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFProdutos.
	/// </summary>
	internal class frmFProdutos : System.Windows.Forms.Form
	{
		#region Delegates
		#region Carregamento dos Dados
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TreeView tvProdutosFatura,ref mdlComponentesGraficos.ListView lvEmbalagens,ref mdlComponentesGraficos.ListView lvVolumes,out int nOrdenacao);
			public delegate void delCallCarregaDadosInterfaceProdutosFatura(ref mdlComponentesGraficos.TreeView tvProdutosFatura);
			public delegate void delCallCarregaDadosInterfaceEmbalagens(ref mdlComponentesGraficos.ListView lvEmbalagens);
			public delegate void delCallCarregaDadosInterfaceVolumes(ref mdlComponentesGraficos.ListView lvVolumes);
			public delegate void delCallCarregaDadosFaturaComercial(out string strPesoLiquido,out string strPesoBruto);
			public delegate void delCallCarregaDadosRomaneio(out string strPesoLiquido,out string strPesoBruto,out double dDiferencaPesoLiquido,out double dDiferencaPesoBruto);
			public delegate void delCallCarregaDadosMostrarQuantidadeTotal(out bool bMostrarQuantidadeTotal);
		#endregion 
		#region Embalagens
		public delegate bool delCallEmbalagemNova();
		public delegate void delCallEmbalagemEdita();
		public delegate bool delCallEmbalagemExclui(ref System.Collections.ArrayList arlEmbalagens);
		public delegate bool delCallEmbalagemInformacoes(ref System.Windows.Forms.ImageList ilEmbalagens, ref System.Collections.ArrayList arlEmbalagens);
		public delegate bool delCallEmbalagemDragDropProdutos(ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlEmbalagens);
		#endregion
		#region Volumes
		public delegate bool delCallVolumeNovo(ref System.Windows.Forms.ImageList ilVolumes);
		public delegate void delCallVolumeEdita();
		public delegate bool delCallVolumeExclui(System.Collections.ArrayList arlVolumes);
		public delegate bool delCallVolumeInformacoes(ref System.Windows.Forms.ImageList ilVolumes,ref System.Windows.Forms.ImageList ilEmbalagens,ref System.Collections.ArrayList arlVolumes);
		public delegate void delCallSetMostrarQuantidadeTotal(bool bMostrarQuantidadeTotal);
		public delegate bool delCallVolumeDragDropProdutos(ref System.Collections.ArrayList arlProdutos,ref System.Collections.ArrayList arlVolumes);
		public delegate bool delCallVolumeDragDropEmbalagens(string strNumeroVolume,ref System.Collections.ArrayList arlEmbalagens);
		#endregion
		#region ShowDialog
			public delegate bool delCallShowDialogConfiguracoes();
		#endregion
		#region Salvamento dos Dados
		public delegate void delCallSalvaDadosBD();
		#endregion
		public delegate bool delCallShowDialogAutomatico();
		#endregion
		#region Events
		#region Carregamento dos Dados
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfaceProdutosFatura eCallCarregaDadosInterfaceProdutosFatura;
		public event delCallCarregaDadosInterfaceEmbalagens eCallCarregaDadosInterfaceEmbalagens;
		public event delCallCarregaDadosInterfaceVolumes eCallCarregaDadosInterfaceVolumes;
		public event delCallCarregaDadosFaturaComercial eCallCarregaDadosFaturaComercial;
		public event delCallCarregaDadosRomaneio eCallCarregaDadosRomaneio;
		public event delCallCarregaDadosMostrarQuantidadeTotal eCallCarregaDadosMostrarQuantidadeTotal;
		#endregion 
		#region Embalagens
		public event delCallEmbalagemNova eCallEmbalagemNova;
		public event delCallEmbalagemEdita eCallEmbalagemEdita;
		public event delCallEmbalagemExclui eCallEmbalagemExclui;
		public event delCallEmbalagemInformacoes eCallEmbalagemInformacoes;
		public event delCallEmbalagemDragDropProdutos eCallEmbalagemDragDropProdutos;
		#endregion
		#region Volumes
		public event delCallVolumeNovo eCallVolumeNovo;
		public event delCallVolumeEdita eCallVolumeEdita;
		public event delCallVolumeExclui eCallVolumeExclui;
		public event delCallVolumeInformacoes eCallVolumeInformacoes;
		public event delCallSetMostrarQuantidadeTotal eCallSetMostrarQuantidadeTotal;
		public event delCallVolumeDragDropProdutos eCallVolumeDragDropProdutos;
		public event delCallVolumeDragDropEmbalagens eCallVolumeDragDropEmbalagens;
		#endregion
		#region ShowDialog
			public event delCallShowDialogConfiguracoes eCallShowDialogConfiguracoes;
		#endregion
		#region Salvamento dos Dados
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		public event delCallShowDialogAutomatico eCallShowDialogAutomatico;
		#endregion
		#region Events Methods
		#region Carregamento dos Dados
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
			{
				int nOrdenacao;
				eCallCarregaDadosInterface(ref m_tvProdutosFatura,ref m_lvEmbalagens,ref m_lvVolumes,out nOrdenacao);
			}
		}

		protected virtual void OnCallCarregaDadosInterfaceProdutosFatura()
		{
			if (eCallCarregaDadosInterfaceProdutosFatura != null)
				eCallCarregaDadosInterfaceProdutosFatura(ref m_tvProdutosFatura);
			OnCallCarregaDadosRomaneio();
		}

		protected virtual void OnCallCarregaDadosInterfaceEmbalagens()
		{
			if (eCallCarregaDadosInterfaceEmbalagens != null)
				eCallCarregaDadosInterfaceEmbalagens(ref m_lvEmbalagens);
		}

		protected virtual void OnCallCarregaDadosInterfaceVolumes()
		{
			if (eCallCarregaDadosInterfaceVolumes != null)
				eCallCarregaDadosInterfaceVolumes(ref m_lvVolumes);
			OnCallCarregaDadosRomaneio();
					
		}

		protected virtual void OnCallCarregaDadosFaturaComercial()
		{
			if (eCallCarregaDadosFaturaComercial != null)
			{
				string strPesoLiquido, strPesoBruto;
				eCallCarregaDadosFaturaComercial(out strPesoLiquido,out strPesoBruto);
				m_txtPesoLiquidoFaturaComercial.Text = strPesoLiquido;
				m_txtPesoBrutoFaturaComercial.Text = strPesoBruto;
			}
		}

		protected virtual void OnCallCarregaDadosRomaneio()
		{
			if (eCallCarregaDadosRomaneio != null)
			{
				string strPesoLiquido, strPesoBruto;
				double dDiferencaPesoLiquido,dDiferencaPesoBruto;
				eCallCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto,out dDiferencaPesoLiquido,out dDiferencaPesoBruto);
											
				// Peso Liquido 
				m_txtPesoLiquidoRomaneio.Text = strPesoLiquido;
				if (dDiferencaPesoLiquido == 0)
				{
					m_lbPesoLiquidoRomaneio.ForeColor = m_clrNeutral;
				}
				else
				{
					if (dDiferencaPesoLiquido > 0)
					{
						m_lbPesoLiquidoRomaneio.ForeColor = m_clrPositive;
					}
					else
					{
						m_lbPesoLiquidoRomaneio.ForeColor = m_clrNegative;
					}
				}

				// Peso Bruto
				m_txtPesoBrutoRomaneio.Text = strPesoBruto;
				if (dDiferencaPesoBruto == 0)
				{
					m_lbPesoBrutoRomaneio.ForeColor = m_clrNeutral;
				}
				else
				{
					if (dDiferencaPesoBruto > 0)
					{
						m_lbPesoBrutoRomaneio.ForeColor = m_clrPositive;
					}
					else
					{
						m_lbPesoBrutoRomaneio.ForeColor = m_clrNegative;
					}
				}
			}
		}

		protected virtual bool OnCallPesosCorretos()
		{
			bool bRetorno = false;
			if (eCallCarregaDadosRomaneio != null)
			{
				string strPesoLiquido, strPesoBruto;
				double dDiferencaPesoLiquido,dDiferencaPesoBruto;
				eCallCarregaDadosRomaneio(out strPesoLiquido,out strPesoBruto,out dDiferencaPesoLiquido,out dDiferencaPesoBruto);
				if ((dDiferencaPesoLiquido == 0) && (dDiferencaPesoBruto == 0))
				{
					bRetorno = true;
				}
				else
				{
					if (mdlMensagens.clsMensagens.ShowQuestion(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFProdutos_PesosRomaneioNaoBatemComFatura)) == System.Windows.Forms.DialogResult.Yes)
					{
						bRetorno = true;
					}
				}
			}
			return(bRetorno);
		}

		protected virtual bool OnCallCarregaDadosMostrarQuantidadeTotal()
		{
			bool bRetorno = false;
			//TODO:Modify
//			if (eCallCarregaDadosMostrarQuantidadeTotal != null)
//			{
//				bool bMostrarQuantidadeTotal;
//				eCallCarregaDadosMostrarQuantidadeTotal(out bMostrarQuantidadeTotal);
//				m_ckVolumeMostrarQuantidadeTotal.Checked = bMostrarQuantidadeTotal;
//			}
			return(bRetorno);
		}
		#endregion 
		#region Embalagens
		protected virtual bool OnCallEmbalagemNova()
		{
			bool bRetorno = false;
			if (eCallEmbalagemNova != null)
				bRetorno = eCallEmbalagemNova();
			return (bRetorno);
		}
		protected virtual void OnCallEmbalagemEdita()
		{
			if (eCallEmbalagemEdita != null)
				eCallEmbalagemEdita();
		}
		protected virtual bool OnCallEmbalagemExclui()
		{
			bool bRetorno = false;
			if (eCallEmbalagemExclui != null)
			{
				System.Collections.ArrayList arlEmbalagens = new System.Collections.ArrayList();
				for(int nCont = 0;nCont < m_lvEmbalagens.SelectedItems.Count;nCont++)
				{
					arlEmbalagens.Add(m_lvEmbalagens.SelectedItems[nCont].Text);
				} 
				if(arlEmbalagens.Count > 0)
					bRetorno = eCallEmbalagemExclui(ref arlEmbalagens);
			}
			return(bRetorno);
		}

		protected virtual bool OnCallEmbalagemInformacoes()
		{
			bool bRetorno = false;
			if (eCallEmbalagemInformacoes != null)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				System.Collections.ArrayList arlEmbalagens = new System.Collections.ArrayList();
				for(int nCont = 0;nCont < m_lvEmbalagens.SelectedItems.Count;nCont++)
				{
					arlEmbalagens.Add(m_lvEmbalagens.SelectedItems[nCont].Text);
				} 
				if(arlEmbalagens.Count > 0)
				{
					if (bRetorno = eCallEmbalagemInformacoes(ref m_ilEmbalagens, ref arlEmbalagens))
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceEmbalagens();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			return(bRetorno);
		}

		protected virtual void OnCallEmbalagemDragDropProdutos()
		{
			if (eCallEmbalagemDragDropProdutos != null)
			{
				System.Collections.ArrayList arlProdutos,arlEmbalagens;
				arlProdutos = arlRetornaProdutosSelecionados();
				arlEmbalagens = arlRetornaEmbalagensSelecionados();
				if ((arlProdutos != null) && (arlEmbalagens != null))
				{
					if (eCallEmbalagemDragDropProdutos(ref arlProdutos,ref arlEmbalagens))
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceEmbalagens();
						vSelecionaProdutos(ref arlProdutos);
						vSelecionaEmbalagens(ref arlEmbalagens);
					}
				}
			}
		}
		#endregion
		#region Volume
		protected virtual bool OnCallVolumeNovo()
		{
			bool bRetorno = false;
			if (eCallVolumeNovo != null)
				bRetorno = eCallVolumeNovo(ref m_ilVolumes);
			return (bRetorno);
		}
		protected virtual void OnCallVolumeEdita()
		{
			if (eCallVolumeEdita != null)
				eCallVolumeEdita();
		}
		protected virtual bool OnCallVolumeExclui()
		{
			bool bRetorno = false;
			if (eCallVolumeExclui != null)
			{
				System.Collections.ArrayList arlVolumes = new System.Collections.ArrayList();
				for(int nCont = 0;nCont < m_lvVolumes.SelectedItems.Count;nCont++)
				{
					arlVolumes.Add(m_lvVolumes.SelectedItems[nCont].Tag.ToString());
				} 
				if(arlVolumes.Count > 0)
					bRetorno = eCallVolumeExclui(arlVolumes);
			}
			return(bRetorno);
		}

		protected virtual bool OnCallVolumeInformacoes()
		{
			bool bRetorno = false;
			if (eCallVolumeInformacoes != null)
			{
				if (m_lvVolumes.SelectedItems.Count > 0)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Collections.ArrayList arlVolumes = new System.Collections.ArrayList();
					for(int nCont = 0;nCont < m_lvVolumes.SelectedItems.Count;nCont++)
					{
						arlVolumes.Add(m_lvVolumes.SelectedItems[nCont].Tag.ToString());
					} 
					if(arlVolumes.Count > 0)
					{
						if (bRetorno = eCallVolumeInformacoes(ref m_ilVolumes,ref m_ilEmbalagens,ref arlVolumes))
						{
							OnCallCarregaDadosInterfaceProdutosFatura();
							OnCallCarregaDadosInterfaceEmbalagens();
							OnCallCarregaDadosInterfaceVolumes();
						}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			return(bRetorno);
		}

		public virtual void OnCallSetMostrarQuantidadeTotal()
		{
			//TODO:Modify
//			if (eCallSetMostrarQuantidadeTotal != null)
//				eCallSetMostrarQuantidadeTotal(m_ckVolumeMostrarQuantidadeTotal.Checked);
		}

		protected virtual void OnCallVolumeDragDropProdutos()
		{
			if (eCallVolumeDragDropProdutos != null)
			{
				System.Collections.ArrayList arlProdutos,arlVolumes;
				arlProdutos = arlRetornaProdutosSelecionados();
				arlVolumes = arlRetornaVolumesSelecionados();
				if ((arlProdutos != null) && (arlVolumes != null))
				{
					if (eCallVolumeDragDropProdutos(ref arlProdutos,ref arlVolumes))
					{
						bool bDepoisPrimeiraAssociacao = true;
						foreach(System.Windows.Forms.TreeNode tvNode in m_tvProdutosFatura.Nodes)
						{
							if (tvNode.ForeColor != System.Drawing.Color.Red)
							{
								bDepoisPrimeiraAssociacao = false;
								break;
							}
						}
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceVolumes();
						vSelecionaProdutos(ref arlProdutos);
						vSelecionaVolumes(ref arlVolumes);
						if (bDepoisPrimeiraAssociacao)
							vShowBalloonTipDepoisPrimeiraAssociacao();
					}
				}
			}
		}

		protected virtual void OnCallVolumeDragDropEmbalagens()
		{
			if (eCallVolumeDragDropEmbalagens != null)
			{
				System.Collections.ArrayList arlEmbalagens;
				arlEmbalagens = arlRetornaEmbalagensSelecionados();
				if (arlEmbalagens != null)
				{
					string strNumeroVolume = "";
					if (m_lvVolumes.SelectedItems.Count == 1)
					{
						strNumeroVolume = m_lvVolumes.SelectedItems[0].Tag.ToString();
						if (eCallVolumeDragDropEmbalagens(strNumeroVolume,ref arlEmbalagens))
						{
							OnCallCarregaDadosInterfaceEmbalagens();
						}
					}
					else
					{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFProdutos_SoltarEmbalagens));
						//MessageBox.Show("Você deve soltar as embalagens(intermediárias) em cima de apenas uma embalagem(final).","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
					}
				}
			}
		}
		#endregion
		#region ShowDialog
			protected virtual bool OnShowDialogConfiguracoes()
			{
				if (eCallShowDialogConfiguracoes != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bool bReturn = eCallShowDialogConfiguracoes();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					return(bReturn);
				}else{
					return(false);
				}
			}
		#endregion
		#region Salvamento dos Dados
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				eCallSalvaDadosBD();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		#endregion
		protected virtual bool OnCallShowDialogAutomatico()
		{
			if (eCallShowDialogAutomatico == null)
				return(false);
			return(eCallShowDialogAutomatico());
		}
		#endregion

		#region Constants
			private const string CONTROL_PRODUTOS = "Produtos";
			private const string CONTROL_EMBALAGENS = "Embalagens";
			private const string CONTROL_VOLUMES = "Volumes";
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			public bool m_bModificado = false;
			public bool m_bResposta = false;

			private bool m_bShowBalloonTips = true;

			private System.Drawing.Color m_clrPositive = System.Drawing.Color.DarkSalmon;
			private System.Drawing.Color m_clrNeutral = System.Drawing.Color.Green;
			private System.Drawing.Color m_clrNegative = System.Drawing.Color.Red;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.GroupBox m_gbProdutosFaturaComercial;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.ImageList m_ilEmbalagens;
			private System.Windows.Forms.ToolTip m_ttDica;
			private mdlComponentesGraficos.TreeView m_tvProdutosFatura;
			internal System.Windows.Forms.GroupBox m_gbVolumes;
			private System.Windows.Forms.GroupBox m_gbEmbalagens;
			internal mdlComponentesGraficos.ListView m_lvVolumes;
			public System.Windows.Forms.Button m_btVolumeExcluir;
			public System.Windows.Forms.Button m_btVolumeEditar;
			public System.Windows.Forms.Button m_btVolumeNovo;
			internal mdlComponentesGraficos.ListView m_lvEmbalagens;
			public System.Windows.Forms.Button m_btEmbalagemExcluir;
			public System.Windows.Forms.Button m_btEmbalagemEditar;
			public System.Windows.Forms.Button m_btEmbalagemNova;
			internal System.Windows.Forms.ImageList m_ilVolumes;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.GroupBox m_gbFaturaComercial;
			private System.Windows.Forms.Label m_lbPesoLiquidoFaturaComercial;
			private System.Windows.Forms.TextBox m_txtPesoLiquidoFaturaComercial;
			private System.Windows.Forms.TextBox m_txtPesoBrutoFaturaComercial;
			private System.Windows.Forms.Label m_lbPesoBrutoFaturaComercial;
			private System.Windows.Forms.GroupBox m_gbRomaneio;
			private System.Windows.Forms.TextBox m_txtPesoBrutoRomaneio;
			private System.Windows.Forms.Label m_lbPesoBrutoRomaneio;
			private System.Windows.Forms.TextBox m_txtPesoLiquidoRomaneio;
			private System.Windows.Forms.Label m_lbPesoLiquidoRomaneio;
		private System.Windows.Forms.Button m_btConfiguracoes;
		private System.Windows.Forms.Button m_btAutomatico;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool UsarEmbalagemIntermediaria
			{
				set
				{
					if (value)
					{
						// Usar embalagens intermediarias
						m_gbEmbalagens.Visible = true;
						m_gbProdutosFaturaComercial.Width = 376;
					}else{
						// Nao usar embalagens intermediarias
						m_gbEmbalagens.Visible = false;
						m_gbProdutosFaturaComercial.Width = 720;
					}
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFProdutos(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();

				// BallonTips
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
				m_bShowBalloonTips = cls_ini_File.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true);

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutos));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_gbRomaneio = new System.Windows.Forms.GroupBox();
			this.m_txtPesoBrutoRomaneio = new System.Windows.Forms.TextBox();
			this.m_lbPesoBrutoRomaneio = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoRomaneio = new System.Windows.Forms.TextBox();
			this.m_lbPesoLiquidoRomaneio = new System.Windows.Forms.Label();
			this.m_gbFaturaComercial = new System.Windows.Forms.GroupBox();
			this.m_txtPesoBrutoFaturaComercial = new System.Windows.Forms.TextBox();
			this.m_lbPesoBrutoFaturaComercial = new System.Windows.Forms.Label();
			this.m_txtPesoLiquidoFaturaComercial = new System.Windows.Forms.TextBox();
			this.m_lbPesoLiquidoFaturaComercial = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbVolumes = new System.Windows.Forms.GroupBox();
			this.m_btAutomatico = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btVolumeExcluir = new System.Windows.Forms.Button();
			this.m_btVolumeEditar = new System.Windows.Forms.Button();
			this.m_btVolumeNovo = new System.Windows.Forms.Button();
			this.m_lvVolumes = new mdlComponentesGraficos.ListView();
			this.m_ilEmbalagens = new System.Windows.Forms.ImageList(this.components);
			this.m_ilVolumes = new System.Windows.Forms.ImageList(this.components);
			this.m_gbProdutosFaturaComercial = new System.Windows.Forms.GroupBox();
			this.m_tvProdutosFatura = new mdlComponentesGraficos.TreeView();
			this.m_gbEmbalagens = new System.Windows.Forms.GroupBox();
			this.m_btEmbalagemExcluir = new System.Windows.Forms.Button();
			this.m_btEmbalagemEditar = new System.Windows.Forms.Button();
			this.m_btEmbalagemNova = new System.Windows.Forms.Button();
			this.m_lvEmbalagens = new mdlComponentesGraficos.ListView();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbRomaneio.SuspendLayout();
			this.m_gbFaturaComercial.SuspendLayout();
			this.m_gbVolumes.SuspendLayout();
			this.m_gbProdutosFaturaComercial.SuspendLayout();
			this.m_gbEmbalagens.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbVolumes);
			this.m_gbGeral.Controls.Add(this.m_gbProdutosFaturaComercial);
			this.m_gbGeral.Controls.Add(this.m_gbEmbalagens);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(731, 463);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbInformacoes.Controls.Add(this.m_gbRomaneio);
			this.m_gbInformacoes.Controls.Add(this.m_gbFaturaComercial);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(6, 374);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(720, 56);
			this.m_gbInformacoes.TabIndex = 9;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_gbRomaneio
			// 
			this.m_gbRomaneio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbRomaneio.Controls.Add(this.m_txtPesoBrutoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_lbPesoBrutoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_txtPesoLiquidoRomaneio);
			this.m_gbRomaneio.Controls.Add(this.m_lbPesoLiquidoRomaneio);
			this.m_gbRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbRomaneio.Location = new System.Drawing.Point(363, 12);
			this.m_gbRomaneio.Name = "m_gbRomaneio";
			this.m_gbRomaneio.Size = new System.Drawing.Size(345, 38);
			this.m_gbRomaneio.TabIndex = 1;
			this.m_gbRomaneio.TabStop = false;
			this.m_gbRomaneio.Text = "Romaneio";
			// 
			// m_txtPesoBrutoRomaneio
			// 
			this.m_txtPesoBrutoRomaneio.Location = new System.Drawing.Point(241, 12);
			this.m_txtPesoBrutoRomaneio.Name = "m_txtPesoBrutoRomaneio";
			this.m_txtPesoBrutoRomaneio.ReadOnly = true;
			this.m_txtPesoBrutoRomaneio.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoBrutoRomaneio.TabIndex = 3;
			this.m_txtPesoBrutoRomaneio.Text = "";
			// 
			// m_lbPesoBrutoRomaneio
			// 
			this.m_lbPesoBrutoRomaneio.Location = new System.Drawing.Point(175, 15);
			this.m_lbPesoBrutoRomaneio.Name = "m_lbPesoBrutoRomaneio";
			this.m_lbPesoBrutoRomaneio.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBrutoRomaneio.TabIndex = 2;
			this.m_lbPesoBrutoRomaneio.Text = "Peso Bruto:";
			// 
			// m_txtPesoLiquidoRomaneio
			// 
			this.m_txtPesoLiquidoRomaneio.Location = new System.Drawing.Point(81, 12);
			this.m_txtPesoLiquidoRomaneio.Name = "m_txtPesoLiquidoRomaneio";
			this.m_txtPesoLiquidoRomaneio.ReadOnly = true;
			this.m_txtPesoLiquidoRomaneio.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoLiquidoRomaneio.TabIndex = 1;
			this.m_txtPesoLiquidoRomaneio.Text = "";
			// 
			// m_lbPesoLiquidoRomaneio
			// 
			this.m_lbPesoLiquidoRomaneio.Location = new System.Drawing.Point(9, 15);
			this.m_lbPesoLiquidoRomaneio.Name = "m_lbPesoLiquidoRomaneio";
			this.m_lbPesoLiquidoRomaneio.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquidoRomaneio.TabIndex = 0;
			this.m_lbPesoLiquidoRomaneio.Text = "Peso Líquido:";
			// 
			// m_gbFaturaComercial
			// 
			this.m_gbFaturaComercial.Controls.Add(this.m_txtPesoBrutoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_lbPesoBrutoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_txtPesoLiquidoFaturaComercial);
			this.m_gbFaturaComercial.Controls.Add(this.m_lbPesoLiquidoFaturaComercial);
			this.m_gbFaturaComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFaturaComercial.Location = new System.Drawing.Point(7, 12);
			this.m_gbFaturaComercial.Name = "m_gbFaturaComercial";
			this.m_gbFaturaComercial.Size = new System.Drawing.Size(345, 38);
			this.m_gbFaturaComercial.TabIndex = 0;
			this.m_gbFaturaComercial.TabStop = false;
			this.m_gbFaturaComercial.Text = "Fatura Comercial";
			// 
			// m_txtPesoBrutoFaturaComercial
			// 
			this.m_txtPesoBrutoFaturaComercial.Location = new System.Drawing.Point(241, 12);
			this.m_txtPesoBrutoFaturaComercial.Name = "m_txtPesoBrutoFaturaComercial";
			this.m_txtPesoBrutoFaturaComercial.ReadOnly = true;
			this.m_txtPesoBrutoFaturaComercial.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoBrutoFaturaComercial.TabIndex = 3;
			this.m_txtPesoBrutoFaturaComercial.Text = "";
			// 
			// m_lbPesoBrutoFaturaComercial
			// 
			this.m_lbPesoBrutoFaturaComercial.Location = new System.Drawing.Point(175, 15);
			this.m_lbPesoBrutoFaturaComercial.Name = "m_lbPesoBrutoFaturaComercial";
			this.m_lbPesoBrutoFaturaComercial.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoBrutoFaturaComercial.TabIndex = 2;
			this.m_lbPesoBrutoFaturaComercial.Text = "Peso Bruto:";
			// 
			// m_txtPesoLiquidoFaturaComercial
			// 
			this.m_txtPesoLiquidoFaturaComercial.Location = new System.Drawing.Point(81, 12);
			this.m_txtPesoLiquidoFaturaComercial.Name = "m_txtPesoLiquidoFaturaComercial";
			this.m_txtPesoLiquidoFaturaComercial.ReadOnly = true;
			this.m_txtPesoLiquidoFaturaComercial.Size = new System.Drawing.Size(87, 20);
			this.m_txtPesoLiquidoFaturaComercial.TabIndex = 1;
			this.m_txtPesoLiquidoFaturaComercial.Text = "";
			// 
			// m_lbPesoLiquidoFaturaComercial
			// 
			this.m_lbPesoLiquidoFaturaComercial.Location = new System.Drawing.Point(9, 15);
			this.m_lbPesoLiquidoFaturaComercial.Name = "m_lbPesoLiquidoFaturaComercial";
			this.m_lbPesoLiquidoFaturaComercial.Size = new System.Drawing.Size(80, 16);
			this.m_lbPesoLiquidoFaturaComercial.TabIndex = 0;
			this.m_lbPesoLiquidoFaturaComercial.Text = "Peso Líquido:";
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(304, 434);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(368, 434);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 7;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbVolumes
			// 
			this.m_gbVolumes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbVolumes.Controls.Add(this.m_btAutomatico);
			this.m_gbVolumes.Controls.Add(this.m_btConfiguracoes);
			this.m_gbVolumes.Controls.Add(this.m_btVolumeExcluir);
			this.m_gbVolumes.Controls.Add(this.m_btVolumeEditar);
			this.m_gbVolumes.Controls.Add(this.m_btVolumeNovo);
			this.m_gbVolumes.Controls.Add(this.m_lvVolumes);
			this.m_gbVolumes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbVolumes.Location = new System.Drawing.Point(6, 168);
			this.m_gbVolumes.Name = "m_gbVolumes";
			this.m_gbVolumes.Size = new System.Drawing.Size(720, 200);
			this.m_gbVolumes.TabIndex = 2;
			this.m_gbVolumes.TabStop = false;
			this.m_gbVolumes.Text = "Embalagem Final";
			// 
			// m_btAutomatico
			// 
			this.m_btAutomatico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btAutomatico.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAutomatico.Image = ((System.Drawing.Image)(resources.GetObject("m_btAutomatico.Image")));
			this.m_btAutomatico.Location = new System.Drawing.Point(652, 14);
			this.m_btAutomatico.Name = "m_btAutomatico";
			this.m_btAutomatico.Size = new System.Drawing.Size(25, 25);
			this.m_btAutomatico.TabIndex = 15;
			this.m_ttDica.SetToolTip(this.m_btAutomatico, "Automatizar o preenchimento do Romaneio");
			this.m_btAutomatico.Click += new System.EventHandler(this.m_btAutomatico_Click);
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(680, 14);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.Size = new System.Drawing.Size(25, 25);
			this.m_btConfiguracoes.TabIndex = 14;
			this.m_btConfiguracoes.Click += new System.EventHandler(this.m_btConfiguracoes_Click);
			// 
			// m_btVolumeExcluir
			// 
			this.m_btVolumeExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVolumeExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVolumeExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVolumeExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btVolumeExcluir.Image")));
			this.m_btVolumeExcluir.Location = new System.Drawing.Point(376, 13);
			this.m_btVolumeExcluir.Name = "m_btVolumeExcluir";
			this.m_btVolumeExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVolumeExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btVolumeExcluir.TabIndex = 12;
			this.m_btVolumeExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btVolumeExcluir, "Remover volumes");
			this.m_btVolumeExcluir.Click += new System.EventHandler(this.m_btVolumeExcluir_Click);
			// 
			// m_btVolumeEditar
			// 
			this.m_btVolumeEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVolumeEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVolumeEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVolumeEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVolumeEditar.Image")));
			this.m_btVolumeEditar.Location = new System.Drawing.Point(344, 13);
			this.m_btVolumeEditar.Name = "m_btVolumeEditar";
			this.m_btVolumeEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVolumeEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btVolumeEditar.TabIndex = 11;
			this.m_btVolumeEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btVolumeEditar, "Editar volumes");
			this.m_btVolumeEditar.Click += new System.EventHandler(this.m_btVolumeEditar_Click);
			// 
			// m_btVolumeNovo
			// 
			this.m_btVolumeNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVolumeNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVolumeNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVolumeNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVolumeNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btVolumeNovo.Image")));
			this.m_btVolumeNovo.Location = new System.Drawing.Point(312, 13);
			this.m_btVolumeNovo.Name = "m_btVolumeNovo";
			this.m_btVolumeNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVolumeNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btVolumeNovo.TabIndex = 10;
			this.m_btVolumeNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btVolumeNovo, "Adicionar volumes");
			this.m_btVolumeNovo.Click += new System.EventHandler(this.m_btVolumeNovo_Click);
			// 
			// m_lvVolumes
			// 
			this.m_lvVolumes.AllowDrop = true;
			this.m_lvVolumes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvVolumes.HideSelection = false;
			this.m_lvVolumes.LargeImageList = this.m_ilEmbalagens;
			this.m_lvVolumes.Location = new System.Drawing.Point(16, 40);
			this.m_lvVolumes.Name = "m_lvVolumes";
			this.m_lvVolumes.Size = new System.Drawing.Size(688, 152);
			this.m_lvVolumes.SmallImageList = this.m_ilVolumes;
			this.m_lvVolumes.TabIndex = 1;
			this.m_lvVolumes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvVolumes_KeyDown);
			this.m_lvVolumes.DoubleClick += new System.EventHandler(this.m_lvVolumes_DoubleClick);
			this.m_lvVolumes.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvVolumes_DragOver);
			this.m_lvVolumes.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvVolumes_DragDrop);
			this.m_lvVolumes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvVolumes_MouseUp);
			// 
			// m_ilEmbalagens
			// 
			this.m_ilEmbalagens.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilEmbalagens.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilEmbalagens.ImageStream")));
			this.m_ilEmbalagens.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ilVolumes
			// 
			this.m_ilVolumes.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilVolumes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilVolumes.ImageStream")));
			this.m_ilVolumes.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_gbProdutosFaturaComercial
			// 
			this.m_gbProdutosFaturaComercial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutosFaturaComercial.Controls.Add(this.m_tvProdutosFatura);
			this.m_gbProdutosFaturaComercial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosFaturaComercial.Location = new System.Drawing.Point(8, 10);
			this.m_gbProdutosFaturaComercial.Name = "m_gbProdutosFaturaComercial";
			this.m_gbProdutosFaturaComercial.Size = new System.Drawing.Size(376, 158);
			this.m_gbProdutosFaturaComercial.TabIndex = 1;
			this.m_gbProdutosFaturaComercial.TabStop = false;
			this.m_gbProdutosFaturaComercial.Text = "Produtos ";
			// 
			// m_tvProdutosFatura
			// 
			this.m_tvProdutosFatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvProdutosFatura.HideSelection = false;
			this.m_tvProdutosFatura.ImageIndex = -1;
			this.m_tvProdutosFatura.Location = new System.Drawing.Point(8, 15);
			this.m_tvProdutosFatura.Name = "m_tvProdutosFatura";
			this.m_tvProdutosFatura.SelectedImageIndex = -1;
			this.m_tvProdutosFatura.Size = new System.Drawing.Size(360, 137);
			this.m_tvProdutosFatura.TabIndex = 0;
			this.m_tvProdutosFatura.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_tvProdutosFatura_MouseDown);
			this.m_tvProdutosFatura.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_tvProdutosFatura_ItemDrag);
			// 
			// m_gbEmbalagens
			// 
			this.m_gbEmbalagens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbEmbalagens.Controls.Add(this.m_btEmbalagemExcluir);
			this.m_gbEmbalagens.Controls.Add(this.m_btEmbalagemEditar);
			this.m_gbEmbalagens.Controls.Add(this.m_btEmbalagemNova);
			this.m_gbEmbalagens.Controls.Add(this.m_lvEmbalagens);
			this.m_gbEmbalagens.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbEmbalagens.Location = new System.Drawing.Point(389, 10);
			this.m_gbEmbalagens.Name = "m_gbEmbalagens";
			this.m_gbEmbalagens.Size = new System.Drawing.Size(336, 158);
			this.m_gbEmbalagens.TabIndex = 8;
			this.m_gbEmbalagens.TabStop = false;
			this.m_gbEmbalagens.Text = "Embalagens Intermediária (Não obrigatória)";
			// 
			// m_btEmbalagemExcluir
			// 
			this.m_btEmbalagemExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEmbalagemExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEmbalagemExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEmbalagemExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEmbalagemExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btEmbalagemExcluir.Image")));
			this.m_btEmbalagemExcluir.Location = new System.Drawing.Point(160, 16);
			this.m_btEmbalagemExcluir.Name = "m_btEmbalagemExcluir";
			this.m_btEmbalagemExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEmbalagemExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btEmbalagemExcluir.TabIndex = 15;
			this.m_btEmbalagemExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEmbalagemExcluir, "Remover embalagens");
			this.m_btEmbalagemExcluir.Click += new System.EventHandler(this.m_btEmbalagemExcluir_Click);
			// 
			// m_btEmbalagemEditar
			// 
			this.m_btEmbalagemEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEmbalagemEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEmbalagemEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEmbalagemEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEmbalagemEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEmbalagemEditar.Image")));
			this.m_btEmbalagemEditar.Location = new System.Drawing.Point(128, 16);
			this.m_btEmbalagemEditar.Name = "m_btEmbalagemEditar";
			this.m_btEmbalagemEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEmbalagemEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEmbalagemEditar.TabIndex = 14;
			this.m_btEmbalagemEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEmbalagemEditar, "Editar embalagens");
			this.m_btEmbalagemEditar.Click += new System.EventHandler(this.m_btEmbalagemEditar_Click);
			// 
			// m_btEmbalagemNova
			// 
			this.m_btEmbalagemNova.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEmbalagemNova.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEmbalagemNova.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEmbalagemNova.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEmbalagemNova.Image = ((System.Drawing.Image)(resources.GetObject("m_btEmbalagemNova.Image")));
			this.m_btEmbalagemNova.Location = new System.Drawing.Point(96, 16);
			this.m_btEmbalagemNova.Name = "m_btEmbalagemNova";
			this.m_btEmbalagemNova.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEmbalagemNova.Size = new System.Drawing.Size(25, 25);
			this.m_btEmbalagemNova.TabIndex = 13;
			this.m_btEmbalagemNova.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btEmbalagemNova, "Adicionar embalagens");
			this.m_btEmbalagemNova.Click += new System.EventHandler(this.m_btEmbalagemNova_Click);
			// 
			// m_lvEmbalagens
			// 
			this.m_lvEmbalagens.AllowDrop = true;
			this.m_lvEmbalagens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lvEmbalagens.HideSelection = false;
			this.m_lvEmbalagens.LargeImageList = this.m_ilEmbalagens;
			this.m_lvEmbalagens.Location = new System.Drawing.Point(8, 45);
			this.m_lvEmbalagens.Name = "m_lvEmbalagens";
			this.m_lvEmbalagens.Size = new System.Drawing.Size(320, 107);
			this.m_lvEmbalagens.SmallImageList = this.m_ilEmbalagens;
			this.m_lvEmbalagens.TabIndex = 2;
			this.m_lvEmbalagens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvEmbalagens_KeyDown);
			this.m_lvEmbalagens.DoubleClick += new System.EventHandler(this.m_lvEmbalagens_DoubleClick);
			this.m_lvEmbalagens.DragOver += new System.Windows.Forms.DragEventHandler(this.m_lvEmbalagens_DragOver);
			this.m_lvEmbalagens.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lvEmbalagens_DragDrop);
			this.m_lvEmbalagens.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvEmbalagens_MouseUp);
			this.m_lvEmbalagens.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_lvEmbalagens_ItemDrag);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFProdutos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 471);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(25, 25);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Lançamento dos produtos no romaneio.";
			this.Load += new System.EventHandler(this.frmFProdutos_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbRomaneio.ResumeLayout(false);
			this.m_gbFaturaComercial.ResumeLayout(false);
			this.m_gbVolumes.ResumeLayout(false);
			this.m_gbProdutosFaturaComercial.ResumeLayout(false);
			this.m_gbEmbalagens.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutos_Load(object sender, System.EventArgs e)
				{
					vResize();
					MostraCor();
					OnCallCarregaDadosInterface();
					OnCallCarregaDadosFaturaComercial();
					OnCallCarregaDadosRomaneio();
					OnCallCarregaDadosMostrarQuantidadeTotal();
					vShowBallonTip();
				}
			#endregion
			#region Botoes
				#region  Formulario
					private void m_btOk_Click(object sender, System.EventArgs e)
					{
						if (OnCallPesosCorretos())
						{
							OnCallSalvaDadosBD();
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
				#region  Embalagens
					private void m_btEmbalagemNova_Click(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (OnCallEmbalagemNova())
							OnCallCarregaDadosInterfaceEmbalagens();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}

					private void m_btEmbalagemEditar_Click(object sender, System.EventArgs e)
					{
						OnCallEmbalagemInformacoes();
					}

					private void m_btEmbalagemExcluir_Click(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (OnCallEmbalagemExclui())
						{
							OnCallCarregaDadosInterfaceProdutosFatura();
							OnCallCarregaDadosInterfaceEmbalagens();
						}
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				#endregion
				#region  Volumes
					private void m_btVolumeNovo_Click(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (OnCallVolumeNovo())
						{
							OnCallCarregaDadosInterfaceVolumes();
							vShowBallonTip();
						}
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}

					private void m_btVolumeEditar_Click(object sender, System.EventArgs e)
					{
						OnCallVolumeInformacoes();
					}

					private void m_btVolumeExcluir_Click(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (OnCallVolumeExclui())
						{
							OnCallCarregaDadosInterfaceProdutosFatura();
							OnCallCarregaDadosInterfaceEmbalagens();
							OnCallCarregaDadosInterfaceVolumes();
						}
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
				#endregion
				#region Configuracoes
				private void m_btConfiguracoes_Click(object sender, System.EventArgs e)
				{
					if (OnShowDialogConfiguracoes())
						OnCallCarregaDadosInterfaceVolumes();
				}

				private void m_btAutomatico_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowDialogAutomatico())
					{
						OnCallCarregaDadosInterfaceProdutosFatura();
						OnCallCarregaDadosInterfaceEmbalagens();
						OnCallCarregaDadosInterfaceVolumes();
						OnCallCarregaDadosRomaneio();
					}
				}
				#endregion
			#endregion
			#region DragDrop
				#region ProdutosFatura
					private void m_tvProdutosFatura_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
					{
						m_tvProdutosFatura.DoDragDrop(CONTROL_PRODUTOS,System.Windows.Forms.DragDropEffects.Move);
					}
				#endregion
				#region Embalagens
					private void m_lvEmbalagens_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
					{
						m_lvEmbalagens.DoDragDrop(CONTROL_EMBALAGENS,System.Windows.Forms.DragDropEffects.Move);
					}

					private void m_lvEmbalagens_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
					{
						System.Windows.Forms.ListViewItem lviItemMouse;
						System.Drawing.Point ptMouse = m_lvEmbalagens.PointToClient(new System.Drawing.Point(e.X,e.Y));
						lviItemMouse = m_lvEmbalagens.GetItemAt(ptMouse.X,ptMouse.Y);
						if (lviItemMouse != null)
						{
							string strLastFormControl = (string)e.Data.GetData("System.String"); 
							switch(strLastFormControl)
							{
								case CONTROL_PRODUTOS:
									e.Effect = System.Windows.Forms.DragDropEffects.Move;
									break;

								default:
									e.Effect = System.Windows.Forms.DragDropEffects.None;
									break;
							}
						}else{
							e.Effect = System.Windows.Forms.DragDropEffects.None;
						}
					}

					private void m_lvEmbalagens_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
					{
						if (e.Effect == System.Windows.Forms.DragDropEffects.Move)
						{
							System.Windows.Forms.ListViewItem lviItemMouse;
							System.Drawing.Point ptMouse = m_lvEmbalagens.PointToClient(new System.Drawing.Point(e.X,e.Y));
							lviItemMouse = m_lvEmbalagens.GetItemAt(ptMouse.X,ptMouse.Y);
							if (lviItemMouse != null)
							{
								if (System.Windows.Forms.Form.ModifierKeys != System.Windows.Forms.Keys.Control)
									m_lvEmbalagens.SelectedItems.Clear();
								if (lviItemMouse.Selected == false)
									lviItemMouse.Selected = true;
							}
							OnCallEmbalagemDragDropProdutos();
						}
					}
				#endregion
				#region Volumes
					private void m_lvVolumes_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
					{
						System.Windows.Forms.ListViewItem lviItemMouse;
						System.Drawing.Point ptMouse = m_lvVolumes.PointToClient(new System.Drawing.Point(e.X,e.Y));
						lviItemMouse = m_lvVolumes.GetItemAt(ptMouse.X,ptMouse.Y);
						if (lviItemMouse != null)
						{
							string strLastFormControl = (string)e.Data.GetData("System.String"); 
							switch(strLastFormControl)
							{
								case CONTROL_PRODUTOS:
									e.Effect = System.Windows.Forms.DragDropEffects.Move;
									break;
								case CONTROL_EMBALAGENS:
									e.Effect = System.Windows.Forms.DragDropEffects.Move;
									break;
								default:
									e.Effect = System.Windows.Forms.DragDropEffects.None;
									break;
							}
						}
						else
						{
							e.Effect = System.Windows.Forms.DragDropEffects.None;
						}
					}

					private void m_lvVolumes_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
					{
						if (e.Effect == System.Windows.Forms.DragDropEffects.Move)
						{
							System.Windows.Forms.ListViewItem lviItemMouse;
							System.Drawing.Point ptMouse = m_lvVolumes.PointToClient(new System.Drawing.Point(e.X,e.Y));
							lviItemMouse = m_lvVolumes.GetItemAt(ptMouse.X,ptMouse.Y);
							if (lviItemMouse != null)
							{
								if (lviItemMouse.Selected == false)
								{
									m_lvVolumes.SelectedItems.Clear();
									lviItemMouse.Selected = true;
								}
							} 
							string strLastFormControl = (string)e.Data.GetData("System.String"); 
							switch(strLastFormControl)
							{
								case CONTROL_PRODUTOS:
									OnCallVolumeDragDropProdutos();
									break;
								case CONTROL_EMBALAGENS:
									OnCallVolumeDragDropEmbalagens();
									break;
							}
						}
					}
				#endregion
			#endregion
			#region Componentes
				#region CheckBoxes
					private void m_ckVolumeMostrarQuantidadeTotal_CheckedChanged(object sender, System.EventArgs e)
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						OnCallSetMostrarQuantidadeTotal();
						OnCallCarregaDadosInterfaceVolumes();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
			#endregion
				#region tvProdutosFatura
				private void m_tvProdutosFatura_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					System.Windows.Forms.TreeNode tvnNodo;
					System.Drawing.Point ptMouse = m_tvProdutosFatura.PointToClient(new System.Drawing.Point(e.X,e.Y));
					tvnNodo = m_tvProdutosFatura.GetNodeAt(e.X,e.Y);
					if (tvnNodo != null)
						m_tvProdutosFatura.SelectedNode = tvnNodo;
				}
				#endregion
				#region lvEmbalagens
					private void m_lvEmbalagens_DoubleClick(object sender, System.EventArgs e)
					{
						OnCallEmbalagemInformacoes();			
					}

					private void m_lvEmbalagens_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
					{
						switch(e.KeyCode)
						{
							case System.Windows.Forms.Keys.Delete:
								if (OnCallEmbalagemExclui())
								{
									OnCallCarregaDadosInterfaceProdutosFatura();
									OnCallCarregaDadosInterfaceEmbalagens();
								}
								break;
						}
					}

					private void m_lvEmbalagens_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
					{
//						if (m_lvEmbalagens.SelectedItems.Count == 0)
//							if (OnCallEmbalagemNova())
//								OnCallCarregaDadosInterfaceEmbalagens();
					}
				#endregion
				#region lvVolumes
					private void m_lvVolumes_DoubleClick(object sender, System.EventArgs e)
					{
						OnCallVolumeInformacoes();			
					}

					private void m_lvVolumes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
					{
						switch(e.KeyCode)
						{
							case System.Windows.Forms.Keys.Delete:
								if (OnCallVolumeExclui())
								{
									OnCallCarregaDadosInterfaceProdutosFatura();
									OnCallCarregaDadosInterfaceVolumes();
								}
								break;
						}
					}

					private void m_lvVolumes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
					{
//						if (m_lvVolumes.SelectedItems.Count == 0)
//							if (OnCallVolumeNovo())
//								OnCallCarregaDadosInterfaceVolumes();
					}
				#endregion
			#endregion
		#endregion
		#region Controls
			#region tvProdutosFatura
				private System.Collections.ArrayList arlRetornaProdutosSelecionados()
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
					if (m_tvProdutosFatura.SelectedNode != null)
                        arlRetorno.Add(Int32.Parse(m_tvProdutosFatura.SelectedNode.Tag.ToString()));
					if (arlRetorno.Count == 0)
						arlRetorno = null;
					return(arlRetorno); 
				}

				private void vSelecionaProdutos(ref System.Collections.ArrayList arlSelecao)
				{
					m_tvProdutosFatura.SelectedNode = null;
					for(int i = 0; i < m_tvProdutosFatura.Nodes.Count;i++)
					{
						if (arlSelecao.Contains(Int32.Parse(m_tvProdutosFatura.Nodes[i].Tag.ToString())))
						{
							m_tvProdutosFatura.SelectedNode = m_tvProdutosFatura.Nodes[i];
							break;
						}
					}
				}
			#endregion
			#region lvEmbalagens
				private System.Collections.ArrayList arlRetornaEmbalagensSelecionados()
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvEmbalagens.SelectedItems.Count;nCont++)
						arlRetorno.Add(m_lvEmbalagens.SelectedItems[nCont].Text);					
					if (arlRetorno.Count == 0)
						arlRetorno = null;
					return(arlRetorno); 
				}

				private void vSelecionaEmbalagens(ref System.Collections.ArrayList arlSelecao)
				{
					m_lvEmbalagens.SelectedItems.Clear();
					for(int i = 0; i < m_lvEmbalagens.Items.Count;i++)
						if (arlSelecao.Contains(Int32.Parse(m_lvEmbalagens.Items[i].Tag.ToString())))
							m_lvEmbalagens.Items[i].Selected = true;
				}
			#endregion
			#region lvVolumes
				private System.Collections.ArrayList arlRetornaVolumesSelecionados()
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
					for (int nCont = 0 ; nCont < m_lvVolumes.SelectedItems.Count;nCont++)
						arlRetorno.Add(m_lvVolumes.SelectedItems[nCont].Tag.ToString());					
					if (arlRetorno.Count == 0)
						arlRetorno = null;
					return(arlRetorno); 
				}

				private void vSelecionaVolumes(ref System.Collections.ArrayList arlSelecao)
				{
					System.Windows.Forms.ListViewItem lviFirst = null;
					m_lvVolumes.SelectedItems.Clear();
					for(int i = 0; i < m_lvVolumes.Items.Count;i++)
						if (arlSelecao.Contains(m_lvVolumes.Items[i].Tag.ToString()))
						{
							if (lviFirst == null)
								lviFirst = m_lvVolumes.Items[i];
							m_lvVolumes.Items[i].Selected = true;
						}
					if (lviFirst != null)
					{
						lviFirst.Focused = true;
						m_lvVolumes.EnsureVisible(lviFirst.Index);
					}
				}
			#endregion
		#endregion 

		#region Resize
		private void vResize()
		{
			this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - 50;
			this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 50;

			// Buttons
			m_btOk.Left = ((int)(m_gbGeral.Width / 2)) - 61;
			m_btCancelar.Left = m_btOk.Left + m_btOk.Width + 4;


			m_btVolumeEditar.Left = ((int)(m_gbVolumes.Width / 2) - 10);
			m_btVolumeNovo.Left = m_btVolumeEditar.Left - 30;
			m_btVolumeExcluir.Left = m_btVolumeEditar.Left + 30;
 		}
		#endregion
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
							}
						}
					}
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void TrocaCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					clsPaletaCores.mostraCorAtual();
					MostraCor();
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion
		#region BalloonTips
			private void vShowBallonTip()
			{
				if (m_bShowBalloonTips)
				{
					if (m_lvVolumes.Items.Count == 0)
					{
						vShowBalloonTipCriarVolumes();
					}
					else
					{
						bool bExist = false;
						foreach(System.Windows.Forms.TreeNode tvNode in m_tvProdutosFatura.Nodes)
						{
							if (tvNode.ForeColor == System.Drawing.Color.Green)
							{
								bExist = true;
								break;
							}
						}
						if (!bExist)
							vShowBalloonTipAssociarProdutoVolume();
					}
				}
			}

			private void vShowBalloonTipCriarVolumes()
			{
				mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
				mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
				mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_CriarVolumes).Replace("\\n",System.Environment.NewLine);
				mb.Icon = System.Drawing.SystemIcons.Information;
				mb.ShowBalloon((System.Windows.Forms.Control)m_btVolumeNovo);
			}

			private void vShowBalloonTipAssociarProdutoVolume()
			{
				mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
				mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
				mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_AssociarProdutoFaturaVolume).Replace("\\n",System.Environment.NewLine);
				mb.Icon = System.Drawing.SystemIcons.Information;
				mb.CloseOnMouseClick = true;
				mb.CloseOnDeactivate = true;
				mb.CloseOnKeyPress = true;
				mb.ShowBalloon((System.Windows.Forms.Control)m_tvProdutosFatura);
			}

			private void vShowBalloonTipDepoisPrimeiraAssociacao()
			{
				if (m_bShowBalloonTips)
				{
					mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
					mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_DepoisPrimeiraAssociacao).Replace("\\n",System.Environment.NewLine);
					mb.Icon = System.Drawing.SystemIcons.Information;
					mb.CloseOnMouseClick = true;
					mb.CloseOnDeactivate = true;
					mb.CloseOnKeyPress = true;
					mb.ShowBalloon((System.Windows.Forms.Control)m_tvProdutosFatura);
				}
			}
		#endregion


	}
}
