using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContratoCambio
{
	/// <summary>
	/// Summary description for frmFContratoCambio.
	/// </summary>
	internal class frmFContratoCambio : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshContratosCambio(ref mdlComponentesGraficos.ListView lvContratos);
			public delegate void delCallShowConfiguracoes();
			public delegate void delCallShowContratoNovo();
			public delegate bool delCallShowContratoRemover(int nIdContratoCambio);
			public delegate bool delCallShowContratoInformacoes(int nIdContratoCambio);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallRefreshContratosCambio eCallRefreshContratosCambio;
			public event delCallShowConfiguracoes eCallShowConfiguracoes;
			public event delCallShowContratoNovo eCallShowContratoNovo;
			public event delCallShowContratoRemover eCallShowContratoRemover;
			public event delCallShowContratoInformacoes eCallShowContratoInformacoes;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshContratosCambio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshContratosCambio != null)
					eCallRefreshContratosCambio(ref m_lvContratos);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowConfiguracoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowConfiguracoes != null)
					eCallShowConfiguracoes();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowContratoNovo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowContratoNovo != null)
					eCallShowContratoNovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowContratoRemover()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowContratoRemover != null)
				{
					if (m_lvContratos.SelectedItems.Count > 0)
					{
						int nContratoCambio = Int32.Parse(m_lvContratos.SelectedItems[0].Tag.ToString());
						if (eCallShowContratoRemover(nContratoCambio))
							OnCallRefreshContratosCambio();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowContratoInformacoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowContratoInformacoes != null)
				{
					if (m_lvContratos.SelectedItems.Count > 0)
					{
						int nContratoCambio = Int32.Parse(m_lvContratos.SelectedItems[0].Tag.ToString());
						if (eCallShowContratoInformacoes(nContratoCambio))
							OnCallRefreshContratosCambio();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallSalvaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";
			public bool m_bModificado = false;
			private int m_nColumn = 0;

			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private mdlComponentesGraficos.ListView m_lvContratos;
			public System.Windows.Forms.Button m_btConfiguracoes;
			public System.Windows.Forms.Button m_btContratoExclui;
			public System.Windows.Forms.Button m_btContratoNovo;
			private System.Windows.Forms.ColumnHeader m_colhNumero;
			private System.Windows.Forms.ColumnHeader m_colhBanco;
			private System.Windows.Forms.ColumnHeader m_colhTipoContratacao;
			private System.Windows.Forms.ColumnHeader m_colhValorTotal;
			private System.Windows.Forms.ColumnHeader m_colhSaldo;
			private System.Windows.Forms.ColumnHeader m_colhDataVencimento;
			private System.Windows.Forms.ColumnHeader m_colhDataEmissao;
			private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.Timer m_tBalloonTip;
			private System.Windows.Forms.GroupBox m_gbContratos;
		#endregion
		#region Constructors and Destructors
			public frmFContratoCambio(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContratoCambio));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbContratos = new System.Windows.Forms.GroupBox();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btContratoExclui = new System.Windows.Forms.Button();
			this.m_btContratoNovo = new System.Windows.Forms.Button();
			this.m_lvContratos = new mdlComponentesGraficos.ListView();
			this.m_colhNumero = new System.Windows.Forms.ColumnHeader();
			this.m_colhBanco = new System.Windows.Forms.ColumnHeader();
			this.m_colhTipoContratacao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDataEmissao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDataVencimento = new System.Windows.Forms.ColumnHeader();
			this.m_colhValorTotal = new System.Windows.Forms.ColumnHeader();
			this.m_colhSaldo = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_tBalloonTip = new System.Windows.Forms.Timer(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbContratos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbContratos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(8, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(728, 408);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbContratos
			// 
			this.m_gbContratos.Controls.Add(this.m_btConfiguracoes);
			this.m_gbContratos.Controls.Add(this.m_btContratoExclui);
			this.m_gbContratos.Controls.Add(this.m_btContratoNovo);
			this.m_gbContratos.Controls.Add(this.m_lvContratos);
			this.m_gbContratos.Location = new System.Drawing.Point(8, 16);
			this.m_gbContratos.Name = "m_gbContratos";
			this.m_gbContratos.Size = new System.Drawing.Size(712, 360);
			this.m_gbContratos.TabIndex = 12;
			this.m_gbContratos.TabStop = false;
			this.m_gbContratos.Text = "Contratos Câmbio";
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfiguracoes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(9, 18);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConfiguracoes.Size = new System.Drawing.Size(25, 25);
			this.m_btConfiguracoes.TabIndex = 19;
			this.m_btConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btConfiguracoes, "Visualizar");
			this.m_btConfiguracoes.Click += new System.EventHandler(this.m_btConfiguracoes_Click);
			// 
			// m_btContratoExclui
			// 
			this.m_btContratoExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContratoExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratoExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContratoExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContratoExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratoExclui.Image")));
			this.m_btContratoExclui.Location = new System.Drawing.Point(363, 16);
			this.m_btContratoExclui.Name = "m_btContratoExclui";
			this.m_btContratoExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContratoExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btContratoExclui.TabIndex = 18;
			this.m_btContratoExclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btContratoExclui, "Excluir");
			this.m_btContratoExclui.Click += new System.EventHandler(this.m_btContratoExclui_Click);
			// 
			// m_btContratoNovo
			// 
			this.m_btContratoNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContratoNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratoNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContratoNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContratoNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratoNovo.Image")));
			this.m_btContratoNovo.Location = new System.Drawing.Point(331, 16);
			this.m_btContratoNovo.Name = "m_btContratoNovo";
			this.m_btContratoNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContratoNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btContratoNovo.TabIndex = 16;
			this.m_btContratoNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btContratoNovo, "Novo");
			this.m_btContratoNovo.Click += new System.EventHandler(this.m_btContratoNovo_Click);
			// 
			// m_lvContratos
			// 
			this.m_lvContratos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.m_colhNumero,
																							this.m_colhBanco,
																							this.m_colhTipoContratacao,
																							this.m_colhDataEmissao,
																							this.m_colhDataVencimento,
																							this.m_colhValorTotal,
																							this.m_colhSaldo});
			this.m_lvContratos.FullRowSelect = true;
			this.m_lvContratos.HideSelection = false;
			this.m_lvContratos.Location = new System.Drawing.Point(8, 48);
			this.m_lvContratos.MultiSelect = false;
			this.m_lvContratos.Name = "m_lvContratos";
			this.m_lvContratos.Size = new System.Drawing.Size(696, 304);
			this.m_lvContratos.TabIndex = 0;
			this.m_lvContratos.View = System.Windows.Forms.View.Details;
			this.m_lvContratos.DoubleClick += new System.EventHandler(this.m_lvContratos_DoubleClick);
			this.m_lvContratos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lvContratos_ColumnClick);
			// 
			// m_colhNumero
			// 
			this.m_colhNumero.Text = "Número";
			this.m_colhNumero.Width = 87;
			// 
			// m_colhBanco
			// 
			this.m_colhBanco.Text = "Banco";
			this.m_colhBanco.Width = 159;
			// 
			// m_colhTipoContratacao
			// 
			this.m_colhTipoContratacao.Text = "Contratação";
			this.m_colhTipoContratacao.Width = 75;
			// 
			// m_colhDataEmissao
			// 
			this.m_colhDataEmissao.Text = "Data Emissão";
			this.m_colhDataEmissao.Width = 80;
			// 
			// m_colhDataVencimento
			// 
			this.m_colhDataVencimento.Text = "Data Vencimento";
			this.m_colhDataVencimento.Width = 95;
			// 
			// m_colhValorTotal
			// 
			this.m_colhValorTotal.Text = "Principal";
			this.m_colhValorTotal.Width = 100;
			// 
			// m_colhSaldo
			// 
			this.m_colhSaldo.Text = "Saldo";
			this.m_colhSaldo.Width = 95;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(305, 377);
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
			this.m_btCancelar.Location = new System.Drawing.Point(369, 377);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// m_tBalloonTip
			// 
			this.m_tBalloonTip.Enabled = true;
			this.m_tBalloonTip.Tick += new System.EventHandler(this.m_tBalloonTip_Tick);
			// 
			// frmFContratoCambio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 416);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContratoCambio";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Contratos de Câmbio";
			this.Load += new System.EventHandler(this.frmFContratoCambio_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbContratos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContratoCambio_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallRefreshContratosCambio();
				}
			#endregion
			#region Botoes
				private void m_btConfiguracoes_Click(object sender, System.EventArgs e)
				{
					OnCallShowConfiguracoes();
				}

				private void m_btContratoNovo_Click(object sender, System.EventArgs e)
				{
					OnCallShowContratoNovo();
				}

				private void m_btContratoExclui_Click(object sender, System.EventArgs e)
				{
					OnCallShowContratoRemover();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
			#region ListView
				private void m_lvContratos_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
				{
					mdlComponentesColecoes.clsComparerListViewItem objComp = new mdlComponentesColecoes.clsComparerListViewItem(e.Column);
					if (m_nColumn == e.Column)
					{
						if (m_lvContratos.Sorting == System.Windows.Forms.SortOrder.Descending)
						{
							objComp.OrderCrescent = true;
							m_lvContratos.Sorting = System.Windows.Forms.SortOrder.Ascending;
						}else{
							objComp.OrderCrescent = false;
							m_lvContratos.Sorting = System.Windows.Forms.SortOrder.Descending;
						}
					}else{
						m_nColumn = e.Column;
					}
					m_lvContratos.ListViewItemSorter = objComp;
					m_lvContratos.Sort();
				}

				private void m_lvContratos_DoubleClick(object sender, System.EventArgs e)
				{
					if (m_lvContratos.SelectedItems.Count == 0)
					{
						OnCallShowContratoNovo();
					}else{
						OnCallShowContratoInformacoes();
					}
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

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.ListView"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion
		#region BalloonTip
			private void  vBalloonTip()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
				{
					mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
					mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlContratoCambio_frmFContratoCambio_ConfigurarContratosCambio);
					mb.Icon = System.Drawing.SystemIcons.Information;
					mb.CloseOnMouseClick = true;
					mb.CloseOnDeactivate = true;
					mb.CloseOnKeyPress = true;
					mb.ShowBalloon((System.Windows.Forms.Control)m_btConfiguracoes);
				}
			}
		#endregion
	}
}
