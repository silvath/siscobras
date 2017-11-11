using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlEsquemaPagamento
{
	/// <summary>
	/// Summary description for frmFEsquemaPagamento.
	/// </summary>
	internal class frmFEsquemaPagamento : System.Windows.Forms.Form
	{
		#region Atributes
            // Padrao
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		    private string m_strEnderecoExecutavel;

		    public bool m_bModificado = false;
		    public bool m_bTreeViewAtivada = false;

			private bool m_bBalloonTips = false;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.PictureBox m_picIdioma;
			internal System.Windows.Forms.TextBox m_txtEsquemaPagamento;
			internal System.Windows.Forms.Label m_lbIdioma;
			internal System.Windows.Forms.Label m_lbValorTotalNumero;
			internal System.Windows.Forms.Label m_lbValorTotal;
			internal System.Windows.Forms.GroupBox m_gbLinha;
			internal System.Windows.Forms.Label m_lbSaldoNumero;
			internal System.Windows.Forms.Label m_lbSaldo;
			internal System.Windows.Forms.TreeView m_tvCondicoesPagamento;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.CheckBox m_ckMostrarPorValores;
			private System.Windows.Forms.Timer m_tBalloonTip;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Delegates
			#region IO
				public delegate void delCallCarregaDadosInterface();
				public delegate void delCallSalvaDados(string strEsquemaPagamento);
			#endregion
		    #region TreeView
				public delegate void delCallRefreshCoresTreeView();
				public delegate void delCallTreeViewNodoChecado(System.Windows.Forms.TreeNode tvnNodo);
		        public delegate void delCallTreeViewNodoClicado(System.Windows.Forms.TreeNode tvnNodo);
			#endregion
			#region Configuracoes
				public delegate void delCallChangeCondictionsView(bool bByVal);
			#endregion
		#endregion
		#region Events
			#region IO
				public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
				public event delCallSalvaDados eCallSalvaDados;
			#endregion 
			#region TreeView
				public event delCallRefreshCoresTreeView eCallRefreshCoresTreeView;
		        public event delCallTreeViewNodoChecado eCallTreeViewNodoChecado;
		        public event delCallTreeViewNodoClicado eCallTreeViewNodoClicado;
			#endregion 
			#region Configuracoes
				public event delCallChangeCondictionsView eCallChangeCondictionsView;
			#endregion
		#endregion
		#region Events Methods
			#region IO
				protected virtual void OnCallCarregaDadosInterface()
				{
					if (eCallCarregaDadosInterface != null)
						eCallCarregaDadosInterface();
				}

				protected virtual void OnCallSalvaDados()
				{
					if (eCallSalvaDados != null)
						eCallSalvaDados(m_txtEsquemaPagamento.Text);
				}
			#endregion
			#region TreeView
				protected virtual void OnCallRefreshCoresTreeView()
				{
					if (eCallRefreshCoresTreeView != null)
						eCallRefreshCoresTreeView();
				}

				protected virtual void OnCallTreeViewNodoChecado(System.Windows.Forms.TreeNode tvnNodo)
				{
					if (eCallTreeViewNodoChecado != null)
					{
						bool bNodosHabilitados = bTodosNodosHabilitados();
						eCallTreeViewNodoChecado(tvnNodo);
						if (bNodosHabilitados && !bTodosNodosHabilitados())  
							vBalloonTipoModificaVisualizacao();
					}
				}

				protected virtual void OnCallTreeViewNodoClicado(System.Windows.Forms.TreeNode tvnNodo)
				{
					if (eCallTreeViewNodoClicado != null)
					{
						bool bNodosHabilitados = bTodosNodosHabilitados();
						eCallTreeViewNodoClicado(tvnNodo);
						if (bNodosHabilitados && !bTodosNodosHabilitados())  
							vBalloonTipoModificaVisualizacao();
					}
				}
			#endregion
			#region Configuracoes
				protected virtual void OnCallChangeCondictionsView()
				{
					if (eCallChangeCondictionsView != null)
						eCallChangeCondictionsView(m_ckMostrarPorValores.Checked);
				}
			#endregion
		#endregion
		#region Constructor and Destructor
			public frmFEsquemaPagamento(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEsquemaPagamento));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_ckMostrarPorValores = new System.Windows.Forms.CheckBox();
			this.m_picIdioma = new System.Windows.Forms.PictureBox();
			this.m_txtEsquemaPagamento = new System.Windows.Forms.TextBox();
			this.m_lbIdioma = new System.Windows.Forms.Label();
			this.m_lbValorTotalNumero = new System.Windows.Forms.Label();
			this.m_lbValorTotal = new System.Windows.Forms.Label();
			this.m_gbLinha = new System.Windows.Forms.GroupBox();
			this.m_lbSaldoNumero = new System.Windows.Forms.Label();
			this.m_lbSaldo = new System.Windows.Forms.Label();
			this.m_tvCondicoesPagamento = new System.Windows.Forms.TreeView();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_tBalloonTip = new System.Windows.Forms.Timer(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_ckMostrarPorValores);
			this.m_gbGeral.Controls.Add(this.m_picIdioma);
			this.m_gbGeral.Controls.Add(this.m_txtEsquemaPagamento);
			this.m_gbGeral.Controls.Add(this.m_lbIdioma);
			this.m_gbGeral.Controls.Add(this.m_lbValorTotalNumero);
			this.m_gbGeral.Controls.Add(this.m_lbValorTotal);
			this.m_gbGeral.Controls.Add(this.m_gbLinha);
			this.m_gbGeral.Controls.Add(this.m_lbSaldoNumero);
			this.m_gbGeral.Controls.Add(this.m_lbSaldo);
			this.m_gbGeral.Controls.Add(this.m_tvCondicoesPagamento);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(442, 360);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_ckMostrarPorValores
			// 
			this.m_ckMostrarPorValores.Location = new System.Drawing.Point(9, 296);
			this.m_ckMostrarPorValores.Name = "m_ckMostrarPorValores";
			this.m_ckMostrarPorValores.Size = new System.Drawing.Size(207, 16);
			this.m_ckMostrarPorValores.TabIndex = 29;
			this.m_ckMostrarPorValores.Text = "Apresentar condições por valores.";
			this.m_ckMostrarPorValores.CheckedChanged += new System.EventHandler(this.m_ckMostrarPorValores_CheckedChanged);
			// 
			// m_picIdioma
			// 
			this.m_picIdioma.Image = ((System.Drawing.Image)(resources.GetObject("m_picIdioma.Image")));
			this.m_picIdioma.Location = new System.Drawing.Point(13, 218);
			this.m_picIdioma.Name = "m_picIdioma";
			this.m_picIdioma.Size = new System.Drawing.Size(24, 24);
			this.m_picIdioma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picIdioma.TabIndex = 28;
			this.m_picIdioma.TabStop = false;
			// 
			// m_txtEsquemaPagamento
			// 
			this.m_txtEsquemaPagamento.HideSelection = false;
			this.m_txtEsquemaPagamento.Location = new System.Drawing.Point(9, 248);
			this.m_txtEsquemaPagamento.Multiline = true;
			this.m_txtEsquemaPagamento.Name = "m_txtEsquemaPagamento";
			this.m_txtEsquemaPagamento.Size = new System.Drawing.Size(423, 48);
			this.m_txtEsquemaPagamento.TabIndex = 26;
			this.m_txtEsquemaPagamento.Text = "";
			// 
			// m_lbIdioma
			// 
			this.m_lbIdioma.Location = new System.Drawing.Point(40, 225);
			this.m_lbIdioma.Name = "m_lbIdioma";
			this.m_lbIdioma.Size = new System.Drawing.Size(214, 16);
			this.m_lbIdioma.TabIndex = 25;
			this.m_lbIdioma.Text = "Idioma:";
			// 
			// m_lbValorTotalNumero
			// 
			this.m_lbValorTotalNumero.BackColor = System.Drawing.Color.White;
			this.m_lbValorTotalNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValorTotalNumero.Location = new System.Drawing.Point(296, 224);
			this.m_lbValorTotalNumero.Name = "m_lbValorTotalNumero";
			this.m_lbValorTotalNumero.Size = new System.Drawing.Size(136, 16);
			this.m_lbValorTotalNumero.TabIndex = 23;
			this.m_lbValorTotalNumero.Text = "Valor ";
			this.m_lbValorTotalNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lbValorTotal
			// 
			this.m_lbValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValorTotal.Location = new System.Drawing.Point(216, 224);
			this.m_lbValorTotal.Name = "m_lbValorTotal";
			this.m_lbValorTotal.Size = new System.Drawing.Size(80, 16);
			this.m_lbValorTotal.TabIndex = 22;
			this.m_lbValorTotal.Text = "Valor Total:";
			// 
			// m_gbLinha
			// 
			this.m_gbLinha.Location = new System.Drawing.Point(296, 295);
			this.m_gbLinha.Name = "m_gbLinha";
			this.m_gbLinha.Size = new System.Drawing.Size(136, 8);
			this.m_gbLinha.TabIndex = 21;
			this.m_gbLinha.TabStop = false;
			// 
			// m_lbSaldoNumero
			// 
			this.m_lbSaldoNumero.BackColor = System.Drawing.Color.White;
			this.m_lbSaldoNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSaldoNumero.ForeColor = System.Drawing.Color.Black;
			this.m_lbSaldoNumero.Location = new System.Drawing.Point(296, 309);
			this.m_lbSaldoNumero.Name = "m_lbSaldoNumero";
			this.m_lbSaldoNumero.Size = new System.Drawing.Size(136, 16);
			this.m_lbSaldoNumero.TabIndex = 20;
			this.m_lbSaldoNumero.Text = "Valor ";
			this.m_lbSaldoNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lbSaldo
			// 
			this.m_lbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSaldo.Location = new System.Drawing.Point(240, 309);
			this.m_lbSaldo.Name = "m_lbSaldo";
			this.m_lbSaldo.Size = new System.Drawing.Size(48, 16);
			this.m_lbSaldo.TabIndex = 19;
			this.m_lbSaldo.Text = "Saldo:";
			// 
			// m_tvCondicoesPagamento
			// 
			this.m_tvCondicoesPagamento.CheckBoxes = true;
			this.m_tvCondicoesPagamento.HideSelection = false;
			this.m_tvCondicoesPagamento.ImageIndex = -1;
			this.m_tvCondicoesPagamento.Location = new System.Drawing.Point(8, 16);
			this.m_tvCondicoesPagamento.Name = "m_tvCondicoesPagamento";
			this.m_tvCondicoesPagamento.SelectedImageIndex = -1;
			this.m_tvCondicoesPagamento.Size = new System.Drawing.Size(424, 200);
			this.m_tvCondicoesPagamento.TabIndex = 10;
			this.m_tvCondicoesPagamento.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_tvCondicoesPagamento_AfterCheck);
			this.m_tvCondicoesPagamento.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvCondicoesPagamento_AfterSelect);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(160, 330);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(224, 330);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_tBalloonTip
			// 
			this.m_tBalloonTip.Enabled = true;
			this.m_tBalloonTip.Tick += new System.EventHandler(this.m_tBalloonTip_Tick);
			// 
			// frmFEsquemaPagamento
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 366);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFEsquemaPagamento";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Esquema de Pagamento";
			this.Load += new System.EventHandler(this.frmFEsquemaPagamento_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFEsquemaPagamento_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosInterface();
					OnCallRefreshCoresTreeView();
					m_bTreeViewAtivada = true;
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallSalvaDados();
					m_bModificado = true;
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
			#region TreeView
				private void m_tvCondicoesPagamento_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					if (m_bTreeViewAtivada)
					{
						m_bTreeViewAtivada = false;
						OnCallTreeViewNodoChecado(e.Node);
						m_bTreeViewAtivada = true;
					}
				}

				private void m_tvCondicoesPagamento_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
				{
					if (m_bTreeViewAtivada)
					{
						m_bTreeViewAtivada = false;
						OnCallTreeViewNodoClicado(e.Node);
						m_bTreeViewAtivada = true;
					}
				}
			#endregion
			#region CheckBox
			private void m_ckMostrarPorValores_CheckedChanged(object sender, System.EventArgs e)
			{
				OnCallChangeCondictionsView();
			}
			#endregion
			#region Timer
				private void m_tBalloonTip_Tick(object sender, System.EventArgs e)
				{
					m_tBalloonTip.Enabled = false;
					vBalloonTip();
				}
			#endregion
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
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
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

			private void TrocaCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					clsPaletaCores.mostraCorAtual();
					MostraCor();
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

		#endregion

		#region BalloonTip
		private void  vBalloonTip()
		{
			mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			if (m_bBalloonTips = cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
			{
				if (bTodosNodosHabilitados())
					vBalloonTipInformacoesCondicoes();
			}
		}

		private bool bTodosNodosHabilitados()
		{
			bool bRetorno = true;
			foreach(System.Windows.Forms.TreeNode tvnNode in m_tvCondicoesPagamento.Nodes)
			{
				if (tvnNode.ForeColor != System.Drawing.Color.DarkSalmon)
				{
					bRetorno = false;
					break;
				}
			}
			return(bRetorno);
		}

		private void vBalloonTipInformacoesCondicoes()
		{
			mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
			mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
			mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlEsquemaPagamento_frmFEsquemaPagamento_InformacoesCondicoes);
			mb.Icon = System.Drawing.SystemIcons.Information;
			mb.CloseOnMouseClick = true;
			mb.CloseOnDeactivate = true;
			mb.CloseOnKeyPress = true;
			mb.ShowBalloon((System.Windows.Forms.Control)m_tvCondicoesPagamento);
		}

		private void vBalloonTipoModificaVisualizacao()
		{
			if (m_bBalloonTips)
			{
				mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
				mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
				mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlEsquemaPagamento_frmFEsquemaPagamento_ModificarVisualizacao);
				mb.Icon = System.Drawing.SystemIcons.Information;
				mb.CloseOnMouseClick = true;
				mb.CloseOnDeactivate = true;
				mb.CloseOnKeyPress = true;
				mb.ShowBalloon((System.Windows.Forms.Control)m_ckMostrarPorValores);
			}
		}
		#endregion

	}
}
