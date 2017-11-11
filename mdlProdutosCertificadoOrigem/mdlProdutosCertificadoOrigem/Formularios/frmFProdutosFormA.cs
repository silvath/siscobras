using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosCertificadoOrigem.Formularios
{
	/// <summary>
	/// Summary description for frmFProdutosFormA.
	/// </summary>
	internal class frmFProdutosFormA : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallConfigureInterface(ref mdlComponentesGraficos.DataGrid dgProdutos);
			public delegate void delCallRefreshProdutosFatura(ref System.Windows.Forms.ListView lvProdutosFatura);
			public delegate void delCallRefreshProdutosCertificado(ref mdlComponentesGraficos.DataGrid dgProdutosCertificado);
			public delegate bool delCallPropriedadesProduto(int nIdOrdemProduto);
			public delegate bool delCallShowDialogInserir(int nIdOrdemProduto);
			public delegate bool delCallShowDialogRemover(int nIdOrdemProduto);
			public delegate bool delCallInverterLinhas(int nIdOrdemProduto1,int nIdOrdemProduto2);
		#endregion
		#region Events
			public event delCallConfigureInterface eCallConfigureInterface;
			public event delCallRefreshProdutosFatura eCallRefreshProdutosFatura;
			public event delCallRefreshProdutosCertificado eCallRefreshProdutosCertificado;
			public event delCallPropriedadesProduto eCallPropriedadesProduto;
			public event delCallShowDialogInserir eCallShowDialogInserir;
			public event delCallShowDialogRemover eCallShowDialogRemover;
			public event delCallInverterLinhas eCallInverterLinhas;
		#endregion
		#region Events Methods
			protected void OnCallConfigureInterface()
			{
				if (eCallConfigureInterface != null)
					eCallConfigureInterface(ref m_dgProdutosFormA);
			}

			internal void OnCallRefreshProdutosFatura()
			{
				if (eCallRefreshProdutosFatura != null)
					eCallRefreshProdutosFatura(ref m_lvProdutosFatura);
			}

			internal void OnCallRefreshProdutosCertificado()
			{
				if (eCallRefreshProdutosCertificado!= null)
					eCallRefreshProdutosCertificado(ref m_dgProdutosFormA);
			}

			protected void OnCallPropriedadesProduto()
			{
				if (m_lvProdutosFatura.SelectedItems.Count == 0)
				{
				}
				else
				{
					if (eCallPropriedadesProduto!= null)
						eCallPropriedadesProduto(Int32.Parse(m_lvProdutosFatura.SelectedItems[0].Tag.ToString()));
				}
			}

			protected void OnCallShowDialogInserir()
			{
				if (m_lvProdutosFatura.SelectedItems.Count == 0)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar o produto da fatura.");
				}else{
					if (eCallShowDialogInserir!= null)
					{
						if(eCallShowDialogInserir(Int32.Parse(m_lvProdutosFatura.SelectedItems[0].Tag.ToString())))
						{
							OnCallRefreshProdutosFatura();
							OnCallRefreshProdutosCertificado();
						}
					}
				}
			}

			protected void OnCallShowDialogRemover()
			{
				if (m_dgProdutosFormA.CurrentRowIndex == -1)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro selecionar o produto da certificado.");
				}
				else
				{
					if (eCallShowDialogRemover != null)
					{
                        System.Data.DataRow row = this.GetCurrentDataRow();
						if (row != null)
						{
							if(eCallShowDialogRemover(Int32.Parse(row[clsProdutosFormA.TEXT_COLUMN_IDORDEM].ToString())))
							{
								OnCallRefreshProdutosFatura();
								OnCallRefreshProdutosCertificado();
							}
						}
					}
				}
			}

			protected bool OnCallInverterLinhas(int nIdOrdemProduto1,int nIdOrdemProduto2)
			{
				if (eCallInverterLinhas == null)
					return(false);
				return(eCallInverterLinhas(nIdOrdemProduto1,nIdOrdemProduto2));
   			}

			protected bool OnCallMoverLinhaParaBaixo()
			{
				System.Data.DataRow dtrwCurrent = this.GetCurrentDataRow();
				System.Data.DataRow dtrwNext = this.GetNextDataRow();
				if ((dtrwCurrent == null) || (dtrwNext == null))
					return(false);
				return(OnCallInverterLinhas(Int32.Parse(dtrwCurrent[clsProdutosFormA.TEXT_COLUMN_IDORDEM].ToString()),Int32.Parse(dtrwNext[clsProdutosFormA.TEXT_COLUMN_IDORDEM].ToString())));
			}

			protected bool OnCallMoverLinhaParaCima()
			{
				System.Data.DataRow dtrwCurrent = this.GetCurrentDataRow();
				System.Data.DataRow dtrwPrevius = this.GetPreviusDataRow();
				if ((dtrwCurrent == null) || (dtrwPrevius == null))
					return(false);
				return(OnCallInverterLinhas(Int32.Parse(dtrwCurrent[clsProdutosFormA.TEXT_COLUMN_IDORDEM].ToString()),Int32.Parse(dtrwPrevius[clsProdutosFormA.TEXT_COLUMN_IDORDEM].ToString())));
			}
		#endregion

		#region Atributes
			private bool m_bConfirmed = false;
			
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbProdutosFatura;
			private System.Windows.Forms.ListView m_lvProdutosFatura;
			private System.Windows.Forms.GroupBox m_gbProdutosCertificado;
			private System.Windows.Forms.Button m_btRetiraProduto;
			private System.Windows.Forms.Button m_btInsereProduto;
			public System.Windows.Forms.Button m_btProdutoAcima;
			public System.Windows.Forms.Button m_btProdutoAbaixo;
			private System.Windows.Forms.ColumnHeader m_colhDescricao;
			private System.Windows.Forms.ColumnHeader m_colhCodigo;
			private System.Windows.Forms.ColumnHeader m_colhOrdem;
			private mdlComponentesGraficos.DataGrid m_dgProdutosFormA;
		private System.Windows.Forms.Button m_btVincular;
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

	
			public bool ClassificacaoTarifaria
			{
				set
				{
					m_btVincular.Visible = value;
				}
			}
		#endregion
		#region Constructors 
			public frmFProdutosFormA(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosFormA));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btRetiraProduto = new System.Windows.Forms.Button();
			this.m_btInsereProduto = new System.Windows.Forms.Button();
			this.m_gbProdutosCertificado = new System.Windows.Forms.GroupBox();
			this.m_btProdutoAcima = new System.Windows.Forms.Button();
			this.m_btProdutoAbaixo = new System.Windows.Forms.Button();
			this.m_dgProdutosFormA = new mdlComponentesGraficos.DataGrid();
			this.m_gbProdutosFatura = new System.Windows.Forms.GroupBox();
			this.m_lvProdutosFatura = new System.Windows.Forms.ListView();
			this.m_colhOrdem = new System.Windows.Forms.ColumnHeader();
			this.m_colhCodigo = new System.Windows.Forms.ColumnHeader();
			this.m_colhDescricao = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btVincular = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbProdutosCertificado.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgProdutosFormA)).BeginInit();
			this.m_gbProdutosFatura.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Controls.Add(this.m_btVincular);
			this.m_gbMain.Controls.Add(this.m_btRetiraProduto);
			this.m_gbMain.Controls.Add(this.m_btInsereProduto);
			this.m_gbMain.Controls.Add(this.m_gbProdutosCertificado);
			this.m_gbMain.Controls.Add(this.m_gbProdutosFatura);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(684, 513);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btRetiraProduto
			// 
			this.m_btRetiraProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRetiraProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btRetiraProduto.Image")));
			this.m_btRetiraProduto.Location = new System.Drawing.Point(349, 212);
			this.m_btRetiraProduto.Name = "m_btRetiraProduto";
			this.m_btRetiraProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btRetiraProduto.TabIndex = 17;
			this.m_btRetiraProduto.Click += new System.EventHandler(this.m_btRetiraProduto_Click);
			// 
			// m_btInsereProduto
			// 
			this.m_btInsereProduto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInsereProduto.Image = ((System.Drawing.Image)(resources.GetObject("m_btInsereProduto.Image")));
			this.m_btInsereProduto.Location = new System.Drawing.Point(277, 212);
			this.m_btInsereProduto.Name = "m_btInsereProduto";
			this.m_btInsereProduto.Size = new System.Drawing.Size(60, 40);
			this.m_btInsereProduto.TabIndex = 16;
			this.m_btInsereProduto.Click += new System.EventHandler(this.m_btInsereProduto_Click);
			// 
			// m_gbProdutosCertificado
			// 
			this.m_gbProdutosCertificado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutosCertificado.Controls.Add(this.m_btProdutoAcima);
			this.m_gbProdutosCertificado.Controls.Add(this.m_btProdutoAbaixo);
			this.m_gbProdutosCertificado.Controls.Add(this.m_dgProdutosFormA);
			this.m_gbProdutosCertificado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosCertificado.Location = new System.Drawing.Point(8, 256);
			this.m_gbProdutosCertificado.Name = "m_gbProdutosCertificado";
			this.m_gbProdutosCertificado.Size = new System.Drawing.Size(672, 224);
			this.m_gbProdutosCertificado.TabIndex = 15;
			this.m_gbProdutosCertificado.TabStop = false;
			this.m_gbProdutosCertificado.Text = "Produtos Form A";
			// 
			// m_btProdutoAcima
			// 
			this.m_btProdutoAcima.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAcima.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAcima.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAcima.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAcima.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAcima.Image")));
			this.m_btProdutoAcima.Location = new System.Drawing.Point(5, 77);
			this.m_btProdutoAcima.Name = "m_btProdutoAcima";
			this.m_btProdutoAcima.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAcima.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAcima.TabIndex = 62;
			this.m_btProdutoAcima.Click += new System.EventHandler(this.m_btProdutoAcima_Click);
			// 
			// m_btProdutoAbaixo
			// 
			this.m_btProdutoAbaixo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btProdutoAbaixo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btProdutoAbaixo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btProdutoAbaixo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btProdutoAbaixo.Image = ((System.Drawing.Image)(resources.GetObject("m_btProdutoAbaixo.Image")));
			this.m_btProdutoAbaixo.Location = new System.Drawing.Point(5, 106);
			this.m_btProdutoAbaixo.Name = "m_btProdutoAbaixo";
			this.m_btProdutoAbaixo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btProdutoAbaixo.Size = new System.Drawing.Size(25, 25);
			this.m_btProdutoAbaixo.TabIndex = 63;
			this.m_btProdutoAbaixo.Click += new System.EventHandler(this.m_btProdutoAbaixo_Click);
			// 
			// m_dgProdutosFormA
			// 
			this.m_dgProdutosFormA.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.m_dgProdutosFormA.DataMember = "";
			this.m_dgProdutosFormA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgProdutosFormA.Location = new System.Drawing.Point(32, 16);
			this.m_dgProdutosFormA.Name = "m_dgProdutosFormA";
			this.m_dgProdutosFormA.Size = new System.Drawing.Size(632, 200);
			this.m_dgProdutosFormA.TabIndex = 0;
			// 
			// m_gbProdutosFatura
			// 
			this.m_gbProdutosFatura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbProdutosFatura.Controls.Add(this.m_lvProdutosFatura);
			this.m_gbProdutosFatura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbProdutosFatura.Location = new System.Drawing.Point(6, 8);
			this.m_gbProdutosFatura.Name = "m_gbProdutosFatura";
			this.m_gbProdutosFatura.Size = new System.Drawing.Size(673, 200);
			this.m_gbProdutosFatura.TabIndex = 14;
			this.m_gbProdutosFatura.TabStop = false;
			this.m_gbProdutosFatura.Text = "Produtos Fatura Comercial";
			// 
			// m_lvProdutosFatura
			// 
			this.m_lvProdutosFatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvProdutosFatura.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.m_colhOrdem,
																								 this.m_colhCodigo,
																								 this.m_colhDescricao});
			this.m_lvProdutosFatura.FullRowSelect = true;
			this.m_lvProdutosFatura.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvProdutosFatura.HideSelection = false;
			this.m_lvProdutosFatura.Location = new System.Drawing.Point(8, 16);
			this.m_lvProdutosFatura.Name = "m_lvProdutosFatura";
			this.m_lvProdutosFatura.Size = new System.Drawing.Size(656, 176);
			this.m_lvProdutosFatura.TabIndex = 0;
			this.m_lvProdutosFatura.View = System.Windows.Forms.View.Details;
			this.m_lvProdutosFatura.DoubleClick += new System.EventHandler(this.m_lvProdutosFatura_DoubleClick);
			// 
			// m_colhOrdem
			// 
			this.m_colhOrdem.Text = "Ordem";
			this.m_colhOrdem.Width = 73;
			// 
			// m_colhCodigo
			// 
			this.m_colhCodigo.Text = "Código";
			this.m_colhCodigo.Width = 122;
			// 
			// m_colhDescricao
			// 
			this.m_colhDescricao.Text = "Descrição";
			this.m_colhDescricao.Width = 432;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(282, 483);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(346, 483);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btVincular
			// 
			this.m_btVincular.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVincular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVincular.Location = new System.Drawing.Point(43, 221);
			this.m_btVincular.Name = "m_btVincular";
			this.m_btVincular.Size = new System.Drawing.Size(144, 24);
			this.m_btVincular.TabIndex = 18;
			this.m_btVincular.Text = "Classificação Tarifária";
			this.m_btVincular.Visible = false;
			// 
			// frmFProdutosFormA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 518);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosFormA";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Produtos Form A";
			this.Load += new System.EventHandler(this.frmFProdutosFormA_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbProdutosCertificado.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgProdutosFormA)).EndInit();
			this.m_gbProdutosFatura.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Form
				private void frmFProdutosFormA_Load(object sender, System.EventArgs e)
				{
					//OnCallConfigureInterface();
					OnCallRefreshProdutosFatura();
					OnCallRefreshProdutosCertificado();
				}
			#endregion
			#region ListView
				private void m_lvProdutosFatura_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallPropriedadesProduto();
				}
			#endregion
			#region Buttons
				private void m_btInsereProduto_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogInserir();
				}

				private void m_btRetiraProduto_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogRemover();
				}

				private void m_btProdutoAcima_Click(object sender, System.EventArgs e)
				{
					if (OnCallMoverLinhaParaCima())
					{
						int nCurrentRow = this.m_dgProdutosFormA.CurrentRowIndex;
						OnCallRefreshProdutosCertificado();
						this.m_dgProdutosFormA.CurrentRowIndex = nCurrentRow - 1;
						this.m_dgProdutosFormA.Select(nCurrentRow - 1);
					}
				}

				private void m_btProdutoAbaixo_Click(object sender, System.EventArgs e)
				{
					if (OnCallMoverLinhaParaBaixo())
					{
						int nCurrentRow = this.m_dgProdutosFormA.CurrentRowIndex;
						OnCallRefreshProdutosCertificado();
						this.m_dgProdutosFormA.CurrentRowIndex = nCurrentRow + 1;
						this.m_dgProdutosFormA.Select(nCurrentRow + 1);
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}
			#endregion
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

		#region DataRow
			private System.Data.DataRow GetCurrentDataRow()
			{
				System.Data.DataRow row = null;
				System.Data.DataTable table = (System.Data.DataTable)m_dgProdutosFormA.DataSource;
				row = table.Rows[m_dgProdutosFormA.CurrentRowIndex];
				return(row);
			}

			private System.Data.DataRow GetPreviusDataRow()
			{
				System.Data.DataRow row = null;
				System.Data.DataTable table = (System.Data.DataTable)m_dgProdutosFormA.DataSource;
				try
				{
					row = table.Rows[m_dgProdutosFormA.CurrentRowIndex - 1];
				}catch{
					row = null;
				}
				return(row);
			}

			private System.Data.DataRow GetNextDataRow()
			{
				System.Data.DataRow row = null;
				System.Data.DataTable table = (System.Data.DataTable)m_dgProdutosFormA.DataSource;
				try
				{
					row = table.Rows[m_dgProdutosFormA.CurrentRowIndex + 1];
				}
				catch
				{
					row = null;
				}
				return(row);
			}
		#endregion
	}
}
