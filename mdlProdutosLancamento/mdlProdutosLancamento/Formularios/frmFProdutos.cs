using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for frmFProdutos.
	/// </summary>
	internal class frmFProdutos : System.Windows.Forms.Form
	{
		#region Constantes
		private string TEXT_SENTIDO = "Altera direção da tecla enter";
		#endregion
		#region Atributos
		// ***********************************************
		// Atributos
		// ***********************************************
		public bool m_bModificado = false;
		public bool m_bResposta = false;
		protected bool m_bHierarquiaProdutos = false;
		internal mdlProdutosLancamento.RespostaPergunta m_enumResposta = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
		public bool m_bAtivadoModificacaoLinha = true;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 

		// Balloon
		private int m_nBalloon = -1;
	            
		// Posicao das Colunas
		private System.Windows.Forms.DataGridCell m_dtgdclCelulaAtual; 
		private string m_strEnderecoExecutavel = "";
		private string m_strUltimaUnidade = "";
		private string m_strUltimoGrupo = "";
		private bool m_bLastMovementVertical = false;

		internal mdlProdutosLancamento.SentidoDeslocamento m_Sentido = mdlProdutosLancamento.SentidoDeslocamento.Horizontal; 
		private mdlComponentesGraficos.ComboBox m_cbProdutos = new mdlComponentesGraficos.ComboBox();
		private mdlComponentesGraficos.ComboBox m_cbCodigos = new mdlComponentesGraficos.ComboBox();
		private mdlComponentesGraficos.ComboBox m_cbProdutosLinguaEstrangeira = new mdlComponentesGraficos.ComboBox();

		internal System.Windows.Forms.GroupBox m_gbGeral;
		public System.Windows.Forms.Button m_btExportarAreaTransferencia;
		public System.Windows.Forms.Button m_btImportarAreaTransferencia;
		private System.Windows.Forms.PictureBox m_picImagemHorizontal;
		private System.Windows.Forms.PictureBox m_picImagemVertical;
		public System.Windows.Forms.Button m_btSentido;
		public System.Windows.Forms.Button m_btProdutoAcima;
		public System.Windows.Forms.Button m_btProdutoAbaixo;
		internal System.Windows.Forms.Button m_btTrocarCor;
		public System.Windows.Forms.Button m_btColunas;
		public System.Windows.Forms.Button m_btOk;
		public System.Windows.Forms.Button m_btCancelar;
		internal mdlComponentesGraficos.DataGrid m_dgProdutos;
		private System.Windows.Forms.ToolTip m_ttDica;
		public System.Windows.Forms.Button m_btProdutoPai;
		public System.Windows.Forms.Button m_btProdutosFilho;
		private System.Windows.Forms.Label m_lbHierarquia;
		internal System.Windows.Forms.Label m_lbSubTotal;
		internal System.Windows.Forms.Label m_lbSubtotalText;
		private System.Windows.Forms.ImageList m_ilIcones;
		private System.Windows.Forms.Timer m_tBalloonTip;
		private System.ComponentModel.IContainer components;
		// ***********************************************
		#endregion

		#region Delegates
		public delegate void delCallCarregaDadosComboBoxProdutos(ref mdlComponentesGraficos.ComboBox cbProdutos);
		public delegate void delCallCarregaDadosComboBoxCodigos(ref mdlComponentesGraficos.ComboBox cbCodigos);
		public delegate void delCallCarregaDadosComboBoxProdutosLinguaEstrangeira(ref mdlComponentesGraficos.ComboBox cbProdutosLinguaEstrangeira);

		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.DataGrid dgProdutos,out bool bDetalharProdutos);
		public delegate bool delCallProdutosFilhos(int nIdProduto);
		public delegate bool delCallProdutoPai();
		public delegate void delCallRefreshColunas(ref mdlComponentesGraficos.DataGrid dgProdutos);
		public delegate void delCallRefreshProdutos(ref System.Data.DataTable dttbProdutos);
		public delegate void delCallRefreshSubTotal(ref System.Windows.Forms.Label lbSubTotal);
		public delegate void delCallDetalharProdutos(bool bDetalharProdutos);
		public delegate void delCallRefreshHierarquia(out int nLevelAtual,out string strHierarquiaAtual);
		public delegate bool delCallTrocaLinhas(int nIdOrdem1,int nIdOrdem2);
		public delegate bool delCallLinhaInsere(int nIdOrdem);
		public delegate void delCallSalvaTamanhoColunas(ref mdlComponentesGraficos.DataGrid dgProdutos);
		public delegate void delCallSalvaDadosInterface(bool bDetalharProdutos);
		public delegate bool delCallSalvaDadosBD();

		public delegate void delCallShowDialogColunas(ref mdlComponentesGraficos.DataGrid dgProdutos);
		public delegate void delCallShowDialogError();
		#endregion
		#region Events 
		public event delCallCarregaDadosComboBoxProdutos eCallCarregaDadosComboBoxProdutos;
		public event delCallCarregaDadosComboBoxCodigos eCallCarregaDadosComboBoxCodigos;
		public event delCallCarregaDadosComboBoxProdutosLinguaEstrangeira eCallCarregaDadosComboBoxProdutosLinguaEstrangeira;

		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallProdutosFilhos eCallProdutosFilhos;
		public event delCallProdutoPai eCallProdutoPai;
		public event delCallRefreshColunas eCallRefreshColunas;
		public event delCallRefreshProdutos eCallRefreshProdutos;
		public event delCallRefreshSubTotal eCallRefreshSubTotal;
		public event delCallRefreshHierarquia eCallRefreshHierarquia;
		public event delCallTrocaLinhas eCallTrocaLinhas;
		public event delCallLinhaInsere eCallLinhaInsere;
		public event delCallSalvaTamanhoColunas eCallSalvaTamanhoColunas;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;

		public event delCallShowDialogColunas eCallShowDialogColunas;
		public event delCallShowDialogError eCallShowDialogError;

		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosComboBoxProdutos()
		{
			if (eCallCarregaDadosComboBoxProdutos != null)
			{
				eCallCarregaDadosComboBoxProdutos(ref m_cbProdutos);
				m_cbProdutos.TextChanged += new System.EventHandler(m_ComboBox_TextChanged);
				m_cbProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(m_cbProdutos_KeyDown);
				m_cbProdutos.KeyUp += new System.Windows.Forms.KeyEventHandler(m_cbProdutos_KeyUp);
				m_cbProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
				m_cbProdutos.BackColor = System.Drawing.Color.Black;
				m_cbProdutos.ForeColor = System.Drawing.Color.White;
				m_cbProdutos.AutoComplete = false;
				m_cbProdutos.GotoNextControlWithKeyRightAtEnd = true;
				m_cbProdutos.GotoPreviusControlWithKeyLeftAtStart = true;
			}
		}

		protected virtual void OnCallCarregaDadosComboBoxCodigos()
		{
			if (eCallCarregaDadosComboBoxCodigos != null)
				eCallCarregaDadosComboBoxCodigos(ref this.m_cbCodigos);
		}

		protected virtual void OnCallCarregaDadosComboBoxProdutosLinguaEstrangeira()
		{
			if (eCallCarregaDadosComboBoxProdutosLinguaEstrangeira != null)
				eCallCarregaDadosComboBoxProdutosLinguaEstrangeira(ref this.m_cbProdutosLinguaEstrangeira);
		}

		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		} 

		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
			{
				bool bDetalharProdutos = false;
				eCallCarregaDadosInterface(ref this.m_dgProdutos,out bDetalharProdutos);
				OnCallRefreshHierarquia();
			}
		} 

		protected virtual bool OnCallProdutosFilhos()
		{
			bool bRetorno = false;
			if ((eCallProdutosFilhos != null) && (m_bHierarquiaProdutos))
			{
				if (m_dgProdutos.CurrentRowIndex >= 0)
				{
					System.Data.DataRow dtrwProduto = ((System.Data.DataTable)m_dgProdutos.DataSource).Rows[m_dgProdutos.CurrentRowIndex];
					bRetorno = eCallProdutosFilhos(Int32.Parse(dtrwProduto[mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM].ToString()));
					if (bRetorno)
						OnCallRefreshColunas();
				}
			}
			return (bRetorno);
		}

		protected virtual bool OnCallProdutoPai()
		{
			bool bRetorno = false;
			if (eCallProdutoPai != null)
			{
				bRetorno = eCallProdutoPai();
				if (bRetorno)
					OnCallRefreshColunas();
			}
			return (bRetorno);
		} 

		protected virtual void OnCallRefreshColunas()
		{
			if (eCallRefreshColunas != null)
			{
				eCallRefreshColunas(ref this.m_dgProdutos);
			}
		}

		protected virtual void OnCallRefreshProdutos()
		{
			if (eCallRefreshProdutos != null)
			{
				System.Data.DataTable dttbProdutos = (System.Data.DataTable)this.m_dgProdutos.DataSource;
				eCallRefreshProdutos(ref dttbProdutos);
				OnCallRefreshHierarquia();
			}
		}

		public virtual void OnCallRefreshSubTotal()
		{
			if (eCallRefreshSubTotal != null)
			{
				eCallRefreshSubTotal(ref m_lbSubTotal);
			}
		}

			protected virtual void OnCallRefreshHierarquia()
			{
				if (eCallRefreshProdutos != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					int nLevelAtual = 0;
					string strHierarquiaAtual; 
					System.Drawing.Color clrBack = this.BackColor;

					eCallRefreshHierarquia(out nLevelAtual,out strHierarquiaAtual);
						
					if (m_dgProdutos.CurrentRowIndex >= 0)
					{
						try
						{
							System.Data.DataRow dtrwProduto = ((System.Data.DataTable)m_dgProdutos.DataSource).Rows[m_dgProdutos.CurrentRowIndex];
							if (strHierarquiaAtual != "")
							{
								strHierarquiaAtual += " " + mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_DIVISOR_HIERARQUIA + " ";
							}
							strHierarquiaAtual += dtrwProduto[mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO].ToString();
						}
						catch
						{
						}
					}
					
					if (nLevelAtual == 0)
					{
						m_btColunas.Enabled = true;
						m_btProdutoPai.Enabled = false;
					}
					else
					{
						m_btColunas.Enabled = false;
						m_btProdutoPai.Enabled = true;
					}
					clrBack = clrCorLevel(nLevelAtual);
					m_dgProdutos.TableStyles[0].AlternatingBackColor = clrBack;
					m_dgProdutos.TableStyles[0].HeaderBackColor = clrBack;
					this.m_lbHierarquia.Text = strHierarquiaAtual;
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual bool OnCallTrocaLinhas(int nOrdem1,int nOrdem2)
			{
				bool bRetorno = false;
				if (eCallTrocaLinhas != null)
				{
					bRetorno = eCallTrocaLinhas(nOrdem1,nOrdem2);
				}
				return(bRetorno);
			}

			protected virtual bool OnCallLinhaInsere(int nOrdem)
			{
				bool bRetorno = false;
				if (eCallLinhaInsere != null)
				{
					bRetorno = eCallLinhaInsere(nOrdem);
				}
				return(bRetorno);
			}

			protected virtual void OnCallSalvaTamanhoColunas()
			{
				if (eCallSalvaTamanhoColunas != null)
					eCallSalvaTamanhoColunas(ref this.m_dgProdutos);
			}

			protected virtual bool OnCallSalvaDadosBD()
			{
				bool bRetorno = false;
				if (eCallSalvaDadosBD != null)
					bRetorno = eCallSalvaDadosBD();
				return(bRetorno);
			} 

			protected virtual void OnCallShowDialogColunas()
			{
				if (eCallShowDialogColunas != null)
					eCallShowDialogColunas(ref this.m_dgProdutos);
			}

			protected virtual void OnCallShowDialogError()
			{
				if (eCallShowDialogError != null)
					eCallShowDialogError();
			}
		#endregion

		#region Constructor e Destructor
		public frmFProdutos(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel,bool bHierarquiaProdutos)
		{
			m_cls_ter_tratadorErro = TratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bHierarquiaProdutos = bHierarquiaProdutos;
			InitializeComponent();
			m_ttDica.SetToolTip(m_btSentido,TEXT_SENTIDO);
			RefreshHierarquiaProdutos();
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
			this.m_lbHierarquia = new System.Windows.Forms.Label();
			this.m_btProdutosFilho = new System.Windows.Forms.Button();
			this.m_ilIcones = new System.Windows.Forms.ImageList(this.components);
			this.m_btProdutoPai = new System.Windows.Forms.Button();
			this.m_btExportarAreaTransferencia = new System.Windows.Forms.Button();
			this.m_btImportarAreaTransferencia = new System.Windows.Forms.Button();
			this.m_picImagemHorizontal = new System.Windows.Forms.PictureBox();
			this.m_picImagemVertical = new System.Windows.Forms.PictureBox();
			this.m_btSentido = new System.Windows.Forms.Button();
			this.m_lbSubTotal = new System.Windows.Forms.Label();
			this.m_btProdutoAcima = new System.Windows.Forms.Button();
			this.m_btProdutoAbaixo = new System.Windows.Forms.Button();
			this.m_lbSubtotalText = new System.Windows.Forms.Label();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btColunas = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_dgProdutos = new mdlComponentesGraficos.DataGrid();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_tBalloonTip = new System.Windows.Forms.Timer(this.components);
			this.m_gbGeral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgProdutos)).BeginInit();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lbHierarquia);
			this.m_gbGeral.Controls.Add(this.m_btProdutosFilho);
			this.m_gbGeral.Controls.Add(this.m_btProdutoPai);
			this.m_gbGeral.Controls.Add(this.m_btExportarAreaTransferencia);
			this.m_gbGeral.Controls.Add(this.m_btImportarAreaTransferencia);
			this.m_gbGeral.Controls.Add(this.m_picImagemHorizontal);
			this.m_gbGeral.Controls.Add(this.m_picImagemVertical);
			this.m_gbGeral.Controls.Add(this.m_btSentido);
			this.m_gbGeral.Controls.Add(this.m_lbSubTotal);
			this.m_gbGeral.Controls.Add(this.m_btProdutoAcima);
			this.m_gbGeral.Controls.Add(this.m_btProdutoAbaixo);
			this.m_gbGeral.Controls.Add(this.m_lbSubtotalText);
			this.m_gbGeral.Controls.Add(this.m_btTrocarCor);
			this.m_gbGeral.Controls.Add(this.m_btColunas);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_dgProdutos);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(732, 513);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbHierarquia
			// 
			this.m_lbHierarquia.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.m_lbHierarquia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lbHierarquia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbHierarquia.ForeColor = System.Drawing.Color.Black;
			this.m_lbHierarquia.Location = new System.Drawing.Point(32, 13);
			this.m_lbHierarquia.Name = "m_lbHierarquia";
			this.m_lbHierarquia.Size = new System.Drawing.Size(688, 23);
			this.m_lbHierarquia.TabIndex = 70;
			this.m_lbHierarquia.Text = "Produtos";
			// 
			// m_btProdutosFilho
			// 
			this.m_btProdutosFilho.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutosFilho.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutosFilho.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutosFilho.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutosFilho.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btProdutosFilho.ImageIndex = 1;
			this.m_btProdutosFilho.ImageList = this.m_ilIcones;
			this.m_btProdutosFilho.Location = new System.Drawing.Point(4, 103);
			this.m_btProdutosFilho.Name = "m_btProdutosFilho";
			this.m_btProdutosFilho.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutosFilho.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutosFilho.TabIndex = 69;
			this.m_ttDica.SetToolTip(this.m_btProdutosFilho, "Visualiza produtos filhos");
			this.m_btProdutosFilho.Click += new System.EventHandler(this.m_btProdutosFilho_Click);
			// 
			// m_ilIcones
			// 
			this.m_ilIcones.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilIcones.ImageStream")));
			this.m_ilIcones.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btProdutoPai
			// 
			this.m_btProdutoPai.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoPai.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoPai.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoPai.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoPai.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btProdutoPai.ImageIndex = 0;
			this.m_btProdutoPai.ImageList = this.m_ilIcones;
			this.m_btProdutoPai.Location = new System.Drawing.Point(4, 76);
			this.m_btProdutoPai.Name = "m_btProdutoPai";
			this.m_btProdutoPai.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoPai.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoPai.TabIndex = 68;
			this.m_ttDica.SetToolTip(this.m_btProdutoPai, "Visualiza produto pai");
			this.m_btProdutoPai.Click += new System.EventHandler(this.m_btProdutoPai_Click);
			// 
			// m_btExportarAreaTransferencia
			// 
			this.m_btExportarAreaTransferencia.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExportarAreaTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExportarAreaTransferencia.Enabled = false;
			this.m_btExportarAreaTransferencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExportarAreaTransferencia.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExportarAreaTransferencia.Image = ((System.Drawing.Image)(resources.GetObject("m_btExportarAreaTransferencia.Image")));
			this.m_btExportarAreaTransferencia.Location = new System.Drawing.Point(232, 477);
			this.m_btExportarAreaTransferencia.Name = "m_btExportarAreaTransferencia";
			this.m_btExportarAreaTransferencia.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExportarAreaTransferencia.Size = new System.Drawing.Size(25, 25);
			this.m_btExportarAreaTransferencia.TabIndex = 67;
			this.m_ttDica.SetToolTip(this.m_btExportarAreaTransferencia, "Copia as linhas selecionadas para a área de transferência");
			this.m_btExportarAreaTransferencia.Visible = false;
			this.m_btExportarAreaTransferencia.Click += new System.EventHandler(this.m_btExportarAreaTransferencia_Click);
			// 
			// m_btImportarAreaTransferencia
			// 
			this.m_btImportarAreaTransferencia.BackColor = System.Drawing.SystemColors.Control;
			this.m_btImportarAreaTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btImportarAreaTransferencia.Enabled = false;
			this.m_btImportarAreaTransferencia.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btImportarAreaTransferencia.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btImportarAreaTransferencia.Image = ((System.Drawing.Image)(resources.GetObject("m_btImportarAreaTransferencia.Image")));
			this.m_btImportarAreaTransferencia.Location = new System.Drawing.Point(264, 477);
			this.m_btImportarAreaTransferencia.Name = "m_btImportarAreaTransferencia";
			this.m_btImportarAreaTransferencia.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btImportarAreaTransferencia.Size = new System.Drawing.Size(25, 25);
			this.m_btImportarAreaTransferencia.TabIndex = 66;
			this.m_ttDica.SetToolTip(this.m_btImportarAreaTransferencia, "Cola as linhas da área de transferência");
			this.m_btImportarAreaTransferencia.Visible = false;
			this.m_btImportarAreaTransferencia.Click += new System.EventHandler(this.m_btImportarAreaTransferencia_Click);
			// 
			// m_picImagemHorizontal
			// 
			this.m_picImagemHorizontal.BackColor = System.Drawing.Color.Silver;
			this.m_picImagemHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagemHorizontal.Image")));
			this.m_picImagemHorizontal.Location = new System.Drawing.Point(8, 424);
			this.m_picImagemHorizontal.Name = "m_picImagemHorizontal";
			this.m_picImagemHorizontal.Size = new System.Drawing.Size(16, 16);
			this.m_picImagemHorizontal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picImagemHorizontal.TabIndex = 65;
			this.m_picImagemHorizontal.TabStop = false;
			this.m_picImagemHorizontal.Visible = false;
			// 
			// m_picImagemVertical
			// 
			this.m_picImagemVertical.BackColor = System.Drawing.Color.Silver;
			this.m_picImagemVertical.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagemVertical.Image")));
			this.m_picImagemVertical.Location = new System.Drawing.Point(8, 407);
			this.m_picImagemVertical.Name = "m_picImagemVertical";
			this.m_picImagemVertical.Size = new System.Drawing.Size(16, 16);
			this.m_picImagemVertical.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picImagemVertical.TabIndex = 64;
			this.m_picImagemVertical.TabStop = false;
			this.m_picImagemVertical.Visible = false;
			// 
			// m_btSentido
			// 
			this.m_btSentido.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSentido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSentido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSentido.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSentido.Image = ((System.Drawing.Image)(resources.GetObject("m_btSentido.Image")));
			this.m_btSentido.Location = new System.Drawing.Point(5, 44);
			this.m_btSentido.Name = "m_btSentido";
			this.m_btSentido.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSentido.Size = new System.Drawing.Size(25, 25);
			this.m_btSentido.TabIndex = 63;
			this.m_ttDica.SetToolTip(this.m_btSentido, "Altera a direção da tecla enter.");
			this.m_btSentido.Click += new System.EventHandler(this.m_btSentido_Click);
			// 
			// m_lbSubTotal
			// 
			this.m_lbSubTotal.BackColor = System.Drawing.Color.White;
			this.m_lbSubTotal.Location = new System.Drawing.Point(592, 474);
			this.m_lbSubTotal.Name = "m_lbSubTotal";
			this.m_lbSubTotal.Size = new System.Drawing.Size(128, 16);
			this.m_lbSubTotal.TabIndex = 62;
			this.m_lbSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btProdutoAcima
			// 
			this.m_btProdutoAcima.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAcima.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAcima.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAcima.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAcima.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAcima.Image")));
			this.m_btProdutoAcima.Location = new System.Drawing.Point(6, 201);
			this.m_btProdutoAcima.Name = "m_btProdutoAcima";
			this.m_btProdutoAcima.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAcima.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAcima.TabIndex = 60;
			this.m_ttDica.SetToolTip(this.m_btProdutoAcima, "Move a linha selecionada para cima.");
			this.m_btProdutoAcima.Click += new System.EventHandler(this.m_btProdutoAcima_Click);
			// 
			// m_btProdutoAbaixo
			// 
			this.m_btProdutoAbaixo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAbaixo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAbaixo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAbaixo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAbaixo.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAbaixo.Image")));
			this.m_btProdutoAbaixo.Location = new System.Drawing.Point(6, 230);
			this.m_btProdutoAbaixo.Name = "m_btProdutoAbaixo";
			this.m_btProdutoAbaixo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAbaixo.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAbaixo.TabIndex = 61;
			this.m_ttDica.SetToolTip(this.m_btProdutoAbaixo, "Move a linha selecionada para baixo.");
			this.m_btProdutoAbaixo.Click += new System.EventHandler(this.m_btProdutoAbaixo_Click);
			// 
			// m_lbSubtotalText
			// 
			this.m_lbSubtotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSubtotalText.ForeColor = System.Drawing.Color.Black;
			this.m_lbSubtotalText.Location = new System.Drawing.Point(528, 475);
			this.m_lbSubtotalText.Name = "m_lbSubtotalText";
			this.m_lbSubtotalText.Size = new System.Drawing.Size(61, 16);
			this.m_lbSubtotalText.TabIndex = 58;
			this.m_lbSubtotalText.Text = "Subtotal:";
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(6, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 57;
			this.m_ttDica.SetToolTip(this.m_btTrocarCor, "Troca a cor da janela.");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btColunas
			// 
			this.m_btColunas.BackColor = System.Drawing.SystemColors.Control;
			this.m_btColunas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btColunas.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btColunas.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btColunas.Image = ((System.Drawing.Image)(resources.GetObject("m_btColunas.Image")));
			this.m_btColunas.Location = new System.Drawing.Point(5, 19);
			this.m_btColunas.Name = "m_btColunas";
			this.m_btColunas.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btColunas.Size = new System.Drawing.Size(25, 25);
			this.m_btColunas.TabIndex = 12;
			this.m_ttDica.SetToolTip(this.m_btColunas, "Configurar Colunas");
			this.m_btColunas.Click += new System.EventHandler(this.m_btColunas_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(304, 481);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(368, 481);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_dgProdutos
			// 
			this.m_dgProdutos.AcceptsEnter = false;
			this.m_dgProdutos.AcceptsTab = false;
			this.m_dgProdutos.AllowSorting = false;
			this.m_dgProdutos.BackgroundColor = System.Drawing.Color.White;
			this.m_dgProdutos.CaptionBackColor = System.Drawing.Color.Green;
			this.m_dgProdutos.CaptionVisible = false;
			this.m_dgProdutos.DataMember = "";
			this.m_dgProdutos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgProdutos.Location = new System.Drawing.Point(32, 40);
			this.m_dgProdutos.Name = "m_dgProdutos";
			this.m_dgProdutos.PreferredRowHeight = 40;
			this.m_dgProdutos.RowHeaderWidth = 50;
			this.m_dgProdutos.Size = new System.Drawing.Size(688, 432);
			this.m_dgProdutos.SortedColumnAscendent = false;
			this.m_dgProdutos.TabIndex = 0;
			this.m_dgProdutos.CurrentCellChanged += new System.EventHandler(this.m_dgProdutos_CurrentCellChanged);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 50;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 50;
			this.m_ttDica.ReshowDelay = 10;
			// 
			// m_tBalloonTip
			// 
			this.m_tBalloonTip.Enabled = true;
			this.m_tBalloonTip.Tick += new System.EventHandler(this.m_tBalloonTip_Tick);
			// 
			// frmFProdutos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 518);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lançamento de Produtos";
			this.Load += new System.EventHandler(this.frmFProdutos_Load);
			this.m_gbGeral.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgProdutos)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region ProccessCmdKey
			protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg,System.Windows.Forms.Keys keyData)
			{
				bool bRetorno = false;
				switch (keyData)
				{
					case System.Windows.Forms.Keys.Enter:
					case System.Windows.Forms.Keys.Tab:
						vMoveNoSentido(true);
						bRetorno = true;
						break;
					case System.Windows.Forms.Keys.F8:
						vTrocaSentido();
						bRetorno = true;
						break;
					case System.Windows.Forms.Keys.F1:
						m_tBalloonTip.Enabled = true;
						return(false);
						//break;
					case System.Windows.Forms.Keys.Insert:
						vInsereLinha();
						bRetorno = true;
						break;
				}
				if (bRetorno)
					return(bRetorno);
				else
					return base.ProcessCmdKey(ref msg,keyData);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutos_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosBD();
					OnCallCarregaDadosComboBoxProdutos();
					OnCallCarregaDadosComboBoxCodigos();
					OnCallCarregaDadosComboBoxProdutosLinguaEstrangeira();
					OnCallCarregaDadosInterface();
					OnCallRefreshSubTotal();
					vFocusLastDataGridCellRow();
					//vBalloonTip();
				}
			#endregion
			#region DataGrid
				private void m_dgProdutos_CurrentCellChanged(object sender, System.EventArgs e)
				{
					try
					{
						if (m_dgProdutos.TableStyles.Count > 0)
						{
							if (m_dgProdutos.TableStyles[0].GridColumnStyles[m_dgProdutos.CurrentCell.ColumnNumber].ReadOnly)
								FocusFirstDataGridCellRow();
						}
						OnCallRefreshHierarquia();

						System.Data.DataTable dttbTableMaster = (System.Data.DataTable)m_dgProdutos.DataSource;
						switch(dttbTableMaster.Columns[m_dgProdutos.CurrentCell.ColumnNumber].ColumnName)
						{
							case clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO: // DESCRICAO
								m_cbProdutos.Text = m_dgProdutos[m_dgProdutos.CurrentCell].ToString();
								m_cbProdutos.BringToFront();
								m_cbProdutos.Focus();
								m_cbProdutos.SelectionStart = m_cbProdutos.Text.Length;
								m_cbProdutos.SelectionLength = 0;
								break;
							case clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE: // UNIDADE
								if (m_bLastMovementVertical)
								{
									if (m_dgProdutos[m_dgProdutos.CurrentCell] != null)
									{
										if (m_dgProdutos[m_dgProdutos.CurrentCell].ToString() == "")
											m_dgProdutos[m_dgProdutos.CurrentCell] = m_strUltimaUnidade;
									}
									else
									{
										m_dgProdutos[m_dgProdutos.CurrentCell] = m_strUltimaUnidade;
									}
								}
								break;
						}
					}catch{
					}
					m_bLastMovementVertical = false;
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					TrocaCor();
				}

				private void m_btColunas_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallSalvaTamanhoColunas();
					OnCallShowDialogColunas();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btProdutoAcima_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (m_dgProdutos.CurrentRowIndex > 0)
					{
						System.Data.DataTable dttbDados = (System.Data.DataTable)m_dgProdutos.DataSource;
						int nIdOrdem1 = Int32.Parse(dttbDados.Rows[m_dgProdutos.CurrentRowIndex][clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
						int nIdOrdem2 = Int32.Parse(dttbDados.Rows[m_dgProdutos.CurrentRowIndex - 1][clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
						if (OnCallTrocaLinhas(nIdOrdem1,nIdOrdem2))
						{
							int nIndex = m_dgProdutos.CurrentRowIndex - 1;
							OnCallRefreshProdutos();
							m_dgProdutos.Select(nIndex);
							m_dgProdutos.CurrentRowIndex = nIndex;
						}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btProdutoAbaixo_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (m_dgProdutos.CurrentRowIndex < ((System.Data.DataTable)m_dgProdutos.DataSource).Rows.Count - 1)
					{
						System.Data.DataTable dttbDados = (System.Data.DataTable)m_dgProdutos.DataSource;
						int nIdOrdem1 = Int32.Parse(dttbDados.Rows[m_dgProdutos.CurrentRowIndex][clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
						int nIdOrdem2 = Int32.Parse(dttbDados.Rows[m_dgProdutos.CurrentRowIndex + 1][clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
						if (OnCallTrocaLinhas(nIdOrdem1,nIdOrdem2))
						{
							int nIndex = m_dgProdutos.CurrentRowIndex + 1;
							OnCallRefreshProdutos();
							m_dgProdutos.Select(nIndex);
							m_dgProdutos.CurrentRowIndex = nIndex;
						}
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btExportarAreaTransferencia_Click(object sender, System.EventArgs e)
				{
					AreaTransferenciaExportar();
				}

				private void m_btImportarAreaTransferencia_Click(object sender, System.EventArgs e)
				{
					AreaTransferenciaImportar();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					while(OnCallProdutoPai())
					{
					} 
					OnCallSalvaTamanhoColunas();
					if (OnCallSalvaDadosBD())
					{
						m_bModificado = true;
						this.Cursor = System.Windows.Forms.Cursors.Default;
						this.Close();
					}else{
						OnCallShowDialogError();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();					
				}
			#endregion
		#endregion

		#region Cores
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","Produtos");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
							}
						}
					}
					if (m_dgProdutos.TableStyles.Count > 0)
					{
						m_dgProdutos.TableStyles[0].BackColor = System.Drawing.Color.White;
						m_dgProdutos.TableStyles[0].HeaderBackColor = this.BackColor;
					}
					this.m_lbSubTotal.BackColor = this.BackColor;

					this.m_lbHierarquia.BackColor = System.Drawing.Color.DarkGray;
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void TrocaCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","Produtos");
					clsPaletaCores.mostraCorAtual();
					MostraCor();
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private System.Drawing.Color clrCorLevel(int nLevel)
			{
				System.Drawing.Color clrCor = System.Drawing.Color.FromArgb(220,240,220);
				int nRed,nGreen,nBlue;
				while (nLevel > 0)
				{
                    nRed = clrCor.R;
					nGreen = clrCor.R;
					nBlue = clrCor.B;
					nRed = nRed - 15;
					nBlue = nBlue - 15;
                    clrCor = System.Drawing.Color.FromArgb(nRed,nGreen,nBlue);
					nLevel--;
				}
				return(clrCor);
			}
		#endregion
		#region Sentido de Deslocamento
			private void m_btSentido_Click(object sender, System.EventArgs e)
			{
				vTrocaSentido();
			}

			private void vTrocaSentido()
			{
				try
				{
					switch (m_Sentido)
					{
						case mdlProdutosLancamento.SentidoDeslocamento.Horizontal:
							m_Sentido = mdlProdutosLancamento.SentidoDeslocamento.Vertical;
							break;
						case mdlProdutosLancamento.SentidoDeslocamento.Vertical:
							m_Sentido = mdlProdutosLancamento.SentidoDeslocamento.Horizontal;
							break;
					}
					vRefreshDeslocamento();
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void vRefreshDeslocamento()
			{
				try
				{
					switch (m_Sentido)
					{
						case mdlProdutosLancamento.SentidoDeslocamento.Horizontal:
							m_btSentido.Image = m_picImagemHorizontal.Image;
							break;
						case mdlProdutosLancamento.SentidoDeslocamento.Vertical:
							m_btSentido.Image = m_picImagemVertical.Image;
							break;
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void vMoveNoSentido(bool bNewLine)
			{
				try
				{
					switch (m_Sentido)
					{
						case mdlProdutosLancamento.SentidoDeslocamento.Horizontal:
							m_bLastMovementVertical = false;
							vMoveEmSentidoHorizontal(bNewLine);
							break;
						case mdlProdutosLancamento.SentidoDeslocamento.Vertical:
							m_bLastMovementVertical = true;
							vMoveEmSentidoVertical(bNewLine);
							break;
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void vMoveEmSentidoHorizontal(bool bNewLine)
			{
				if (m_dgProdutos.CurrentCell.ColumnNumber < m_dgProdutos.TableStyles[0].GridColumnStyles.Count - 1) 
					m_dgProdutos.CurrentCell = new System.Windows.Forms.DataGridCell(m_dgProdutos.CurrentCell.RowNumber,m_dgProdutos.CurrentCell.ColumnNumber + 1);
				else
					m_dgProdutos.CurrentCell = new System.Windows.Forms.DataGridCell(m_dgProdutos.CurrentCell.RowNumber + 1,1);
			}

			private void vMoveEmSentidoVertical(bool bNewLine)
			{
				if (bNewLine)
					vAddNewLineIfNecessary();					
				m_dgProdutos.CurrentCell = new System.Windows.Forms.DataGridCell(m_dgProdutos.CurrentCell.RowNumber + 1,m_dgProdutos.CurrentCell.ColumnNumber);
			}

			private void vAddNewLineIfNecessary()
			{
				if (m_dgProdutos.CurrentCell.RowNumber == ((System.Data.DataTable)(m_dgProdutos.DataSource)).Rows.Count)
				{
					System.Windows.Forms.DataGridCell dtgdclCurrent = m_dgProdutos.CurrentCell;
					System.Data.DataRow dtrwLinha = ((System.Data.DataTable)(m_dgProdutos.DataSource)).NewRow();
					((System.Data.DataTable)(m_dgProdutos.DataSource)).Rows.Add(dtrwLinha);
					m_dgProdutos.CurrentCell = dtgdclCurrent;
				}
			}
		#endregion

		#region ComponentesGraficos
			public int nRetornaIdProdutoSegundoComboBoxProdutos(string strDescricao)
			{
				int nRetorno = -1;
				m_cbProdutos.Text = strDescricao;
				try{
					nRetorno = Int32.Parse(m_cbProdutos.ReturnObjectSelectedItem().ToString());
				}catch{
					nRetorno = -1;
				}
				return(nRetorno);
			}

			public int nRetornaIdProdutoSegundoComboBoxProdutosLinguaEstrangeira(string strDescricaoLinguaEstrangeira)
			{
				int nRetorno = -1;
				m_cbProdutosLinguaEstrangeira.Text = strDescricaoLinguaEstrangeira;
				try
				{
					nRetorno = Int32.Parse(m_cbProdutosLinguaEstrangeira.ReturnObjectSelectedItem().ToString());
				}
				catch
				{
					nRetorno = -1;
				}
				return(nRetorno);
			}
		
			public int nRetornaIdProdutoSegundoComboBoxCodigosProdutos(string strCodigoProduto)
			{
				int nRetorno = -1;
				m_cbCodigos.Text = strCodigoProduto;
				try{
					nRetorno = Int32.Parse(m_cbCodigos.ReturnObjectSelectedItem().ToString());
				}catch{
					nRetorno = -1;
				}
				return(nRetorno);
			}
		#endregion
		#region HierarquiaProdutos
			private void RefreshHierarquiaProdutos()
			{
				if (m_bHierarquiaProdutos)
				{
					m_btProdutosFilho.Enabled = true;
					m_btProdutoPai.Enabled = true;
				}else{
					m_btProdutosFilho.Enabled = false;
					m_btProdutoPai.Enabled = false;
					bool bRefresh = false;
					while (OnCallProdutoPai())
					{
						bRefresh = true;
					}
					if (bRefresh)
						OnCallRefreshProdutos();
				}
			}

		#endregion
		#region Colunas
			private bool ColumnVisible(int columnNumber)
			{
				bool bRetorno = false;
				if (this.m_dgProdutos.TableStyles.Count > 0)
				{
					if (this.m_dgProdutos.TableStyles[0].GridColumnStyles[columnNumber].Width == 0)
					{
						bRetorno = false;
					}else{
						bRetorno = true;
					}
				}
				return (bRetorno);
			}
		#endregion

		#region Level
			private void m_btProdutoPai_Click(object sender, System.EventArgs e)
			{
				if (OnCallProdutoPai())
					OnCallRefreshProdutos();
			}

			private void m_btProdutosFilho_Click(object sender, System.EventArgs e)
			{
				if (OnCallProdutosFilhos())
					OnCallRefreshProdutos();
			}
		#endregion
		#region DataGridCell
			private void vFocusLastDataGridCellRow()
			{
                System.Data.DataTable dttbData = (System.Data.DataTable)m_dgProdutos.DataSource;
				if ((dttbData.Columns.Count > 0) && (dttbData.Rows.Count > 0))
				{
					m_dgProdutos.CurrentCell = new DataGridCell(dttbData.Rows.Count - 1,0);
				}
			}

			private void FocusFirstDataGridCell()
			{
				if (!ColumnVisible(this.m_dgProdutos.CurrentCell.ColumnNumber))
				{
					if (m_dgProdutos.TableStyles.Count > 0)
					{
						for (int nCont = 0; nCont < m_dgProdutos.TableStyles[0].GridColumnStyles.Count; nCont++)
						{
							if ((m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].Width > 0 ) && (!m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].ReadOnly))
							{
								m_dgProdutos.CurrentCell = new System.Windows.Forms.DataGridCell(0,nCont);
								break;
							}
						}
					}
				}
			}

			private void FocusFirstDataGridCellRow()
			{
				if (!ColumnVisible(this.m_dgProdutos.CurrentCell.ColumnNumber))
				{
					if (m_dgProdutos.TableStyles.Count > 0)
					{
						for (int nCont = 0; nCont < m_dgProdutos.TableStyles[0].GridColumnStyles.Count; nCont++)
						{
							if ((m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].Width > 0 ) && (!m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].ReadOnly))
							{
								m_dgProdutos.CurrentCell = new System.Windows.Forms.DataGridCell(m_dgProdutos.CurrentCell.RowNumber,nCont);

								break;
							}
						}
					}
				}
			}

			private void vSelectCurrentLineOfCurrentCell()
			{
				m_dgProdutos.Select(m_dgProdutos.CurrentRowIndex);
			}
		#endregion
		#region LinhaInsere
			private void vInsereLinha()
			{
				try
				{
					if (m_dgProdutos.CurrentCell.RowNumber < ((System.Data.DataTable)(m_dgProdutos.DataSource)).Rows.Count)
					{
						System.Data.DataTable dttbMaster = (System.Data.DataTable)this.m_dgProdutos.DataSource;
						int nIdOrdem = Int32.Parse(dttbMaster.Rows[m_dgProdutos.CurrentCell.RowNumber][mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
						if (nIdOrdem >= 0)
						{
							if (OnCallLinhaInsere(nIdOrdem))
							{
								System.Windows.Forms.DataGridCell dtgdCell = m_dgProdutos.CurrentCell;
								OnCallRefreshProdutos();
								m_dgProdutos.CurrentCell = dtgdCell;
							}
						}
					}
				}catch{
				}
			}
		#endregion

		#region DataGridTextBoxColumn
			public void DataGridTextBoxColumn_Click(object sender, System.EventArgs e)
			{
				vSelectCurrentLineOfCurrentCell();
			}

			public void DataGridTextBoxColumn_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
			{
				m_dtgdclCelulaAtual = this.m_dgProdutos.CurrentCell;
				System.Data.DataTable dttbTableMaster = (System.Data.DataTable)m_dgProdutos.DataSource;
				switch(dttbTableMaster.Columns[m_dgProdutos.CurrentCell.ColumnNumber].ColumnName)
				{
					case clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO: // DESCRICAO
						e.Handled = true;
						break;
				}
			}

			public void DataGridTextBoxColumn_KeyUp(object sender,System.Windows.Forms.KeyEventArgs e)
			{
				this.m_dgProdutos.CurrentCell = m_dtgdclCelulaAtual; 
			}

			public void DataGridTextBoxColumn_Enter(object sender, System.EventArgs e)
			{
				FocusFirstDataGridCellRow();
				vAddNewLineIfNecessary();
				System.Windows.Forms.DataGridTextBox dtgdtxtProduto = (System.Windows.Forms.DataGridTextBox)sender;
				dtgdtxtProduto.BackColor = System.Drawing.Color.Black;
				dtgdtxtProduto.ForeColor = System.Drawing.Color.White;
				if (dtgdtxtProduto.Name == mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE)
				{
					if (dtgdtxtProduto.Text == "")
					{
						dtgdtxtProduto.Text = m_strUltimaUnidade;
						m_dgProdutos[m_dgProdutos.CurrentCell] = m_strUltimaUnidade;
					}
				}
				if (dtgdtxtProduto.Name == mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_GRUPO)
				{
					if (dtgdtxtProduto.Text == "")
					{
						dtgdtxtProduto.Text = m_strUltimoGrupo;
						m_dgProdutos[m_dgProdutos.CurrentCell] = m_strUltimoGrupo;
					}
				}
			}

			public void DataGridTextBoxColumnDescricao_Enter(object sender, System.EventArgs e)
			{
				vAddNewLineIfNecessary();
				System.Windows.Forms.DataGridTextBox dtgdtxtProduto = (System.Windows.Forms.DataGridTextBox)sender;
				dtgdtxtProduto.BackColor = System.Drawing.Color.Black;
                dtgdtxtProduto.ForeColor = System.Drawing.Color.White;
				m_cbProdutos.Width = dtgdtxtProduto.Width;
				m_cbProdutos.Text = dtgdtxtProduto.Text;
				dtgdtxtProduto.Controls.Add(m_cbProdutos);

			    m_cbProdutos.BringToFront();
				m_cbProdutos.Focus();
				m_cbProdutos.SelectionStart = m_cbProdutos.Text.Length;
				m_cbProdutos.SelectionLength = 0;
			}

			public void DataGridTextBoxColumnDescricao_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				System.Windows.Forms.DataGridTextBox gtbcColumn = (System.Windows.Forms.DataGridTextBox)sender;
				e.Handled = true;
//				m_cbProdutos.BringToFront();
//				m_cbProdutos.Focus();
//                m_cbProdutos.Text += e.KeyChar;
//				m_cbProdutos.SelectionStart = m_cbProdutos.Text.Length;
//				m_cbProdutos.SelectionLength = 0;
			}

			public void DataGridTextBoxColumn_Leave(object sender, System.EventArgs e)
			{
				System.Windows.Forms.DataGridTextBox dtgdtxtProduto = (System.Windows.Forms.DataGridTextBox)sender;
				if (dtgdtxtProduto.Controls.Contains(m_cbProdutos))
					dtgdtxtProduto.Controls.Clear();
				dtgdtxtProduto.BackColor = System.Drawing.Color.White;
				dtgdtxtProduto.ForeColor = System.Drawing.Color.Black;
			}

			public void DataGridTextBoxColumn_TextChanged(object sender, System.EventArgs e)
			{
				System.Windows.Forms.DataGridTextBox gtbcColumn = (System.Windows.Forms.DataGridTextBox)sender;
				if (gtbcColumn.Name == mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE)
					if (gtbcColumn.Text != "")
						m_strUltimaUnidade = gtbcColumn.Text;
				if (gtbcColumn.Name == mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_GRUPO)
					if (gtbcColumn.Text != "")
						m_strUltimoGrupo = gtbcColumn.Text;
			}

			public void DataGridTextBoxColumnNumerico_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				try
				{
					System.Windows.Forms.DataGridTextBox gtbcColumn = (System.Windows.Forms.DataGridTextBox)sender;
					// Verificando o Alinhamento, se for a direita eh numero
					if (gtbcColumn.TextAlign == System.Windows.Forms.HorizontalAlignment.Right)
					{
						bool bPossuiVirgula = (gtbcColumn.Text.IndexOf(",") != -1);
						bool bNovaVirgula = (e.KeyChar == '.') || (e.KeyChar == ',') ;
						if (e.KeyChar != 8)
						{
							if (((48 <= (int)e.KeyChar) && ((int)e.KeyChar <= 57)) || (bNovaVirgula && !bPossuiVirgula))
							{
								if (e.KeyChar == '.')
								{
									int nPos = gtbcColumn.SelectionStart;
									string strTextoAnterior;
									string strTextoPosterior;
									strTextoAnterior = gtbcColumn.Text.Substring(0,nPos);
									strTextoPosterior = gtbcColumn.Text.Substring(nPos);
									gtbcColumn.Text = strTextoAnterior + "," + strTextoPosterior;
									gtbcColumn.SelectionStart = nPos + 1;
									e.Handled = true;
								}
							}
							else
								e.Handled = true;
						}
					}
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

		#endregion
		#region cbProdutos

			public void RefreshCBProdutos()
			{
				OnCallCarregaDadosComboBoxProdutos();
			}

			private void m_ComboBox_TextChanged(object sender,System.EventArgs e)
			{
				try
				{
					if (m_dgProdutos.TableStyles[0].GridColumnStyles[m_dgProdutos.CurrentCell.ColumnNumber].HeaderText == mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO)
						m_dgProdutos[m_dgProdutos.CurrentCell] = ((mdlComponentesGraficos.ComboBox)sender).Text;
				}catch{
				}
			}

			private void m_cbProdutos_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
			{
				try
				{
					switch (e.KeyCode)
					{
						case System.Windows.Forms.Keys.Left:
							if (m_cbProdutos.SelectionStart == 0)
							{
								System.Windows.Forms.SendKeys.Send("+{TAB}");
							}
							break;
						case System.Windows.Forms.Keys.Right:
							if (m_cbProdutos.SelectionStart == m_cbProdutos.Text.Length)
							{
								System.Windows.Forms.SendKeys.Send("{TAB}");
							}
							break;
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void m_cbProdutos_KeyUp(object sender,System.Windows.Forms.KeyEventArgs e)
			{
				switch (e.KeyCode)
				{
					case System.Windows.Forms.Keys.Space:
						if (e.Control)
						{
							int nIndex = m_cbProdutos.FindString(m_cbProdutos.Text);
							if (nIndex >= 0)
							{
								e.Handled = true;
								m_cbProdutos.Text = m_cbProdutos.Items[nIndex].ToString();
								m_cbProdutos.SelectionStart = m_cbProdutos.Text.Length;
								m_cbProdutos.SelectionLength = 0;
							}
						}
						break;
				}
			}
		#endregion
		#region cbCodigos
			public void RefreshCBCodigos()
			{
				OnCallCarregaDadosComboBoxCodigos();
			}
		#endregion

		#region BalloonTip
			private void  vBalloonTip()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
				{
					if (m_nBalloon == -1)
					{
						System.Random rnd = new Random(System.DateTime.Now.Millisecond);
						m_nBalloon = rnd.Next(1,5);
					}else{
						switch(m_nBalloon)
						{
							case 4:
								m_nBalloon = 1;
								break;
							default:
								m_nBalloon++;
								break;
						}
					}
					mdlComponentesGraficos.MessageBalloon mb;
					switch(m_nBalloon)
					{
						case 1:
							// Colunas
							mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosLancamento_frmFProdutos_OrdenarColunas).Replace("\\n",System.Environment.NewLine);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btColunas);
							break;
						case 2:
							// Sentido Deslocamento
							mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosLancamento_frmFProdutos_SentidoDeslocamento).Replace("\\n",System.Environment.NewLine);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btSentido);
							break;
						case 3:
							// Produto Integrante
							mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosLancamento_frmFProdutos_ProdutoIntegrante).Replace("\\n",System.Environment.NewLine);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btProdutosFilho);
							break;
						case 4:
							// Deslocamento Produtos
							mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosLancamento_frmFProdutos_DeslocamentoProdutos).Replace("\\n",System.Environment.NewLine);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btProdutoAbaixo);
							break;
					}
				}
			}
		#endregion

		#region REMOVER Area de Transferencia
		#region Exportar
		private void AreaTransferenciaExportar()
		{
			try
			{
				//				System.Data.DataTable dtProdutos = (System.Data.DataTable)this.m_dgProdutos.DataSource;
				//				System.Data.DataRow dtrwLinha;
				//
				//				// Criando a Lista dos Produtos Selecinados
				//				System.Collections.ArrayList arlSelecao = new System.Collections.ArrayList();
				//				for (int nCont = 0 ; nCont < dtProdutos.Rows.Count; nCont++)
				//				{
				//					if (this.m_dgProdutos.IsSelected(nCont))
				//						arlSelecao.Add(nCont);
				//				}
				//				if (arlSelecao.Count == 0)
				//				{
				//					for (int nCont = 0 ; nCont < dtProdutos.Rows.Count; nCont++)
				//						arlSelecao.Add(nCont);
				//				}
				//
				//				// Varendo a Lista de Produtos Selecionados
				//				string strTextoEnviarAreaTransferencia = "";
				//				string strLinhaAtual = "";
				//				for (int nCont = 0 ; nCont < arlSelecao.Count; nCont++)
				//				{
				//					strLinhaAtual = "";
				//					dtrwLinha = dtProdutos.Rows[(int)arlSelecao[nCont]];
				//					for (int nCont2 = 0 ; nCont2 < dtProdutos.Columns.Count; nCont2++)
				//					{
				//						if ((nCont2 != m_nPosColOrdemLancamento) && (this.m_dgProdutos.TableStyles[0].GridColumnStyles[nCont2].Width != 0))
				//						{
				//							if (strLinhaAtual != "")
				//								strLinhaAtual += "\t";
				//							strLinhaAtual += dtrwLinha[nCont2];
				//						}
				//					}
				//					if (strLinhaAtual != "")
				//					{
				//						if (strTextoEnviarAreaTransferencia != "")
				//						{
				//							strTextoEnviarAreaTransferencia += System.Environment.NewLine;
				//						}
				//						strTextoEnviarAreaTransferencia += strLinhaAtual;
				//					}
				//				}
				//				System.Windows.Forms.Clipboard.SetDataObject(strTextoEnviarAreaTransferencia,true);
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Importar

		private int nReturnVisibleColumn(int nColumnNumber)
		{
			int nReturn = -1;
			int nColumnVisible = 0;
			for (int nCont = 0; nCont < this.m_dgProdutos.TableStyles[0].GridColumnStyles.Count;nCont++)
			{
				if ((this.m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].Width != 0) && (!this.m_dgProdutos.TableStyles[0].GridColumnStyles[nCont].ReadOnly))
					nColumnVisible++;
				if (nColumnVisible == nColumnNumber)
				{
					nReturn = nCont;
					break;
				}

			}
			return (nReturn);
		}

		private void AreaTransferenciaImportar()
		{
			try
			{
				//						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				//						System.Windows.Forms.IDataObject iData = System.Windows.Forms.Clipboard.GetDataObject();
				//						if(iData.GetDataPresent(System.Windows.Forms.DataFormats.Text)) 
				//						{
				//							bool bErro = false;
				//							string strErro = "";
				//							string strTextoImportar = (String)iData.GetData(DataFormats.Text); 						
				//							string strLinhaAtual = "";
				//							string strColunaAtual = "";
				//							int nPosNewLine,nPosNewColumn;
				//							int nContLinhas = 0, nContColunas = 0,nColumnIndex;
				//							System.Collections.ArrayList arlLinhas = new System.Collections.ArrayList();
				//							System.Data.DataRow dtrwLinha;
				//							while (strTextoImportar != "")
				//							{
				//								nContLinhas++;
				//								// Adquirindo a Próxima linha
				//								nPosNewLine = strTextoImportar.IndexOf(System.Environment.NewLine);
				//								if (nPosNewLine >= 0)
				//								{
				//									strLinhaAtual = strTextoImportar.Substring(0,nPosNewLine);
				//									strTextoImportar = strTextoImportar.Substring(nPosNewLine + System.Environment.NewLine.ToString().Length);
				//								}
				//								else
				//								{
				//									strLinhaAtual = strTextoImportar;
				//									strTextoImportar = "";
				//								}
				//
				//								// Inserindo a Linha na Colecao
				//								nContColunas = 0;
				//								dtrwLinha = ((System.Data.DataTable)this.m_dgProdutos.DataSource).NewRow();
				//								dtrwLinha[m_nPosColIdProduto] = -1;
				//								while (strLinhaAtual != "")
				//								{
				//									nContColunas++;
				//									// Adquirindo a Coluna linha
				//									nPosNewColumn = strLinhaAtual.IndexOf("\t");
				//									if (nPosNewColumn >= 0)
				//									{
				//										strColunaAtual = strLinhaAtual.Substring(0,nPosNewColumn);
				//										strLinhaAtual = strLinhaAtual.Substring(nPosNewColumn + 1);
				//									}
				//									else
				//									{
				//										strColunaAtual = strLinhaAtual;
				//										strLinhaAtual = "";
				//									}
				//									nColumnIndex = nReturnVisibleColumn(nContColunas);
				//									if (nColumnIndex != -1 )
				//									{
				//										if (this.m_dgProdutos.TableStyles[0].GridColumnStyles[nColumnIndex].Alignment == System.Windows.Forms.HorizontalAlignment.Right)
				//										{
				//											try
				//											{
				//												if ((strColunaAtual != null) && (strColunaAtual.Trim() != ""))
				//												{
				//													double dValor = Double.Parse(strColunaAtual);
				//													dtrwLinha[nColumnIndex] = dValor.ToString();
				//												}
				//											}catch{
				//												bErro = true;
				//												strErro = "O texto na linha " + nContLinhas + " e coluna " + nContColunas + " deve ser um valor numérico.";
				//											}
				//										}else{
				//											dtrwLinha[nColumnIndex] = strColunaAtual;
				//										}
				//									}
				//								}
				//								if (!bErro)
				//									arlLinhas.Add(dtrwLinha);
				//							}
				//							// Caso nao tenha problemas Insere as linhas importadas
				//							if (!bErro)
				//							{
				//								for (int nCont = 0 ; nCont < arlLinhas.Count;nCont++)
				//								{
				//									dtrwLinha = (System.Data.DataRow)arlLinhas[nCont];
				//									((System.Data.DataTable)this.m_dgProdutos.DataSource).Rows.Add(dtrwLinha);
				//								}
				//							}else{
				//								System.Windows.Forms.MessageBox.Show(strErro,"Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
				//							}
				//						}
				//						this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		private void m_tBalloonTip_Tick(object sender, System.EventArgs e)
		{
			m_tBalloonTip.Enabled = false;
			vBalloonTip();
		}
		#endregion
	}
}
