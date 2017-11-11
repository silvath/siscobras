using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio.Formularios
{
	/// <summary>
	/// Summary description for frmFAutomacao.
	/// </summary>
	public class frmFAutomacao : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallRefreshProdutosFatura(ref System.Windows.Forms.ListView lvProdutosFatura);
			public delegate bool delCallRefreshProdutosRomaneio(ref System.Windows.Forms.ListView lvProdutosRomaneio);
			public delegate bool delCallInsereProdutos(int[] nIdOrdemProdutos);
			public delegate bool delCallRemoverProdutos(int[] nIdOrdemProdutos);
			public delegate bool delCallShowDialogProdutos();
		#endregion
		#region Events
			public event delCallRefreshProdutosFatura eCallRefreshProdutosFatura;
			public event delCallRefreshProdutosRomaneio eCallRefreshProdutosRomaneio;
			public event delCallInsereProdutos eCallInsereProdutos;
			public event delCallRemoverProdutos eCallRemoverProdutos;
			public event delCallShowDialogProdutos eCallShowDialogProdutos;
		#endregion
		#region Events Methods
			protected virtual bool OnCallRefreshProdutosFatura()
			{
				if (eCallRefreshProdutosFatura == null)
					return(false);
				return(eCallRefreshProdutosFatura(ref m_lvProdutosFatura));
			}

			protected virtual bool OnCallRefreshProdutosRomaneio()
			{
				if (eCallRefreshProdutosRomaneio == null)
					return(false);
				return(eCallRefreshProdutosRomaneio(ref m_lvProdutosRomaneio));
			}

			protected bool OnCallInsereProdutos()
			{
				if (eCallInsereProdutos == null)
					return(false);
				if (m_lvProdutosFatura.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Primeiro você deve selecionar os produtos da fatura a inserir.");
					return(false);
				}
				int[] nIdOrdemProdutos = new int[m_lvProdutosFatura.SelectedItems.Count];
				for(int i = 0; i < m_lvProdutosFatura.SelectedItems.Count;i++)
					nIdOrdemProdutos[i] =  Int32.Parse(m_lvProdutosFatura.SelectedItems[i].Tag.ToString());
				return(eCallInsereProdutos(nIdOrdemProdutos));
			} 

			protected bool OnCallRemoverProdutos()
			{
				if (eCallInsereProdutos == null)
					return(false);
				if (m_lvProdutosRomaneio.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Primeiro você deve selecionar os produtos do romaneio a remover.");
					return(false);
				}
				int[] nIdOrdemProdutos = new int[m_lvProdutosRomaneio.SelectedItems.Count];
				for(int i = 0; i < m_lvProdutosRomaneio.SelectedItems.Count;i++)
					nIdOrdemProdutos[i] =  Int32.Parse(m_lvProdutosRomaneio.SelectedItems[i].Tag.ToString());
				return(eCallRemoverProdutos(nIdOrdemProdutos));
			} 

			private bool OnCallShowDialogProdutos()
			{
				if (eCallShowDialogProdutos == null)
					return(false);
				return(eCallShowDialogProdutos());
			}
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbProdutosFatura;
			private System.Windows.Forms.GroupBox m_gbProdutosRomaneio;
			private System.Windows.Forms.ListView m_lvProdutosFatura;
			private System.Windows.Forms.ListView m_lvProdutosRomaneio;
			private System.Windows.Forms.ColumnHeader m_colhQuantidade;
			private System.Windows.Forms.ColumnHeader m_colhUnidade;
			private System.Windows.Forms.ColumnHeader m_colhDescricao;
			private System.Windows.Forms.ColumnHeader m_colhRomaneioQuantidade;
			private System.Windows.Forms.ColumnHeader m_colhRomaneioUnidade;
			private System.Windows.Forms.ColumnHeader m_colhRomaneioDescricao;
			private System.Windows.Forms.Button m_btProdutoRemove;
			private System.Windows.Forms.Button m_btProdutoInsere;
		private System.Windows.Forms.Button m_btProdutos;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Confirmed
			{
				get
				{
					return(m_bConfirmed);
				}
			}
		#endregion
		#region Constructors
			public frmFAutomacao(string strEnderecoExecutavel)
			{
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAutomacao));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btProdutoRemove = new System.Windows.Forms.Button();
			this.m_btProdutoInsere = new System.Windows.Forms.Button();
			this.m_gbProdutosRomaneio = new System.Windows.Forms.GroupBox();
			this.m_lvProdutosRomaneio = new System.Windows.Forms.ListView();
			this.m_colhRomaneioQuantidade = new System.Windows.Forms.ColumnHeader();
			this.m_colhRomaneioUnidade = new System.Windows.Forms.ColumnHeader();
			this.m_colhRomaneioDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_gbProdutosFatura = new System.Windows.Forms.GroupBox();
			this.m_lvProdutosFatura = new System.Windows.Forms.ListView();
			this.m_colhQuantidade = new System.Windows.Forms.ColumnHeader();
			this.m_colhUnidade = new System.Windows.Forms.ColumnHeader();
			this.m_colhDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btProdutos = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbProdutosRomaneio.SuspendLayout();
			this.m_gbProdutosFatura.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btProdutos);
			this.m_gbMain.Controls.Add(this.m_btProdutoRemove);
			this.m_gbMain.Controls.Add(this.m_btProdutoInsere);
			this.m_gbMain.Controls.Add(this.m_gbProdutosRomaneio);
			this.m_gbMain.Controls.Add(this.m_gbProdutosFatura);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(586, 466);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btProdutoRemove
			// 
			this.m_btProdutoRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoRemove.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoRemove.Image")));
			this.m_btProdutoRemove.Location = new System.Drawing.Point(292, 201);
			this.m_btProdutoRemove.Name = "m_btProdutoRemove";
			this.m_btProdutoRemove.Size = new System.Drawing.Size(60, 40);
			this.m_btProdutoRemove.TabIndex = 15;
			this.m_btProdutoRemove.Click += new System.EventHandler(this.m_btProdutoRemove_Click);
			// 
			// m_btProdutoInsere
			// 
			this.m_btProdutoInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoInsere.Image")));
			this.m_btProdutoInsere.Location = new System.Drawing.Point(220, 201);
			this.m_btProdutoInsere.Name = "m_btProdutoInsere";
			this.m_btProdutoInsere.Size = new System.Drawing.Size(60, 40);
			this.m_btProdutoInsere.TabIndex = 14;
			this.m_btProdutoInsere.Click += new System.EventHandler(this.m_btProdutoInsere_Click);
			// 
			// m_gbProdutosRomaneio
			// 
			this.m_gbProdutosRomaneio.Controls.Add(this.m_lvProdutosRomaneio);
			this.m_gbProdutosRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosRomaneio.Location = new System.Drawing.Point(8, 240);
			this.m_gbProdutosRomaneio.Name = "m_gbProdutosRomaneio";
			this.m_gbProdutosRomaneio.Size = new System.Drawing.Size(570, 192);
			this.m_gbProdutosRomaneio.TabIndex = 11;
			this.m_gbProdutosRomaneio.TabStop = false;
			this.m_gbProdutosRomaneio.Text = "Proutos no Romaneio";
			// 
			// m_lvProdutosRomaneio
			// 
			this.m_lvProdutosRomaneio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutosRomaneio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								   this.m_colhRomaneioQuantidade,
																								   this.m_colhRomaneioUnidade,
																								   this.m_colhRomaneioDescricao});
			this.m_lvProdutosRomaneio.FullRowSelect = true;
			this.m_lvProdutosRomaneio.HideSelection = false;
			this.m_lvProdutosRomaneio.Location = new System.Drawing.Point(9, 16);
			this.m_lvProdutosRomaneio.Name = "m_lvProdutosRomaneio";
			this.m_lvProdutosRomaneio.Size = new System.Drawing.Size(552, 168);
			this.m_lvProdutosRomaneio.TabIndex = 1;
			this.m_lvProdutosRomaneio.View = System.Windows.Forms.View.Details;
			// 
			// m_colhRomaneioQuantidade
			// 
			this.m_colhRomaneioQuantidade.Text = "Quantidade";
			this.m_colhRomaneioQuantidade.Width = 79;
			// 
			// m_colhRomaneioUnidade
			// 
			this.m_colhRomaneioUnidade.Text = "Unidade";
			this.m_colhRomaneioUnidade.Width = 77;
			// 
			// m_colhRomaneioDescricao
			// 
			this.m_colhRomaneioDescricao.Text = "Descrição";
			this.m_colhRomaneioDescricao.Width = 388;
			// 
			// m_gbProdutosFatura
			// 
			this.m_gbProdutosFatura.Controls.Add(this.m_lvProdutosFatura);
			this.m_gbProdutosFatura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosFatura.Location = new System.Drawing.Point(8, 9);
			this.m_gbProdutosFatura.Name = "m_gbProdutosFatura";
			this.m_gbProdutosFatura.Size = new System.Drawing.Size(570, 191);
			this.m_gbProdutosFatura.TabIndex = 10;
			this.m_gbProdutosFatura.TabStop = false;
			this.m_gbProdutosFatura.Text = "Proutos Fatura";
			// 
			// m_lvProdutosFatura
			// 
			this.m_lvProdutosFatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutosFatura.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.m_colhQuantidade,
																								 this.m_colhUnidade,
																								 this.m_colhDescricao});
			this.m_lvProdutosFatura.FullRowSelect = true;
			this.m_lvProdutosFatura.HideSelection = false;
			this.m_lvProdutosFatura.Location = new System.Drawing.Point(8, 16);
			this.m_lvProdutosFatura.Name = "m_lvProdutosFatura";
			this.m_lvProdutosFatura.Size = new System.Drawing.Size(552, 167);
			this.m_lvProdutosFatura.TabIndex = 0;
			this.m_lvProdutosFatura.View = System.Windows.Forms.View.Details;
			// 
			// m_colhQuantidade
			// 
			this.m_colhQuantidade.Text = "Quantidade";
			this.m_colhQuantidade.Width = 81;
			// 
			// m_colhUnidade
			// 
			this.m_colhUnidade.Text = "Unidade";
			this.m_colhUnidade.Width = 71;
			// 
			// m_colhDescricao
			// 
			this.m_colhDescricao.Text = "Descrição";
			this.m_colhDescricao.Width = 391;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(232, 434);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
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
			this.m_btCancelar.Location = new System.Drawing.Point(296, 434);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btProdutos
			// 
			this.m_btProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutos.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutos.Image")));
			this.m_btProdutos.Location = new System.Drawing.Point(551, 208);
			this.m_btProdutos.Name = "m_btProdutos";
			this.m_btProdutos.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutos.TabIndex = 16;
			this.m_btProdutos.Click += new System.EventHandler(this.m_btProdutos_Click);
			// 
			// frmFAutomacao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 468);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAutomacao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Produtos Romaneio";
			this.Load += new System.EventHandler(this.frmFAutomacao_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbProdutosRomaneio.ResumeLayout(false);
			this.m_gbProdutosFatura.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
					case "System.Windows.Forms.ListView":
					case "System.Windows.Forms.TextBox":
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

		#region Eventos
			#region Form	
				private void frmFAutomacao_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshProdutosFatura();
					OnCallRefreshProdutosRomaneio();
				}
			#endregion
			#region Buttons
				private void m_btProdutoInsere_Click(object sender, System.EventArgs e)
				{
					if (OnCallInsereProdutos())
					{
						OnCallRefreshProdutosFatura();
						OnCallRefreshProdutosRomaneio();
					}
				}

				private void m_btProdutoRemove_Click(object sender, System.EventArgs e)
				{
					if (OnCallRemoverProdutos())
					{
						OnCallRefreshProdutosFatura();
						OnCallRefreshProdutosRomaneio();
					}
				}

				private void m_btProdutos_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					if (OnCallShowDialogProdutos())
					{
						OnCallRefreshProdutosFatura();
						OnCallRefreshProdutosRomaneio();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion
	}
}
