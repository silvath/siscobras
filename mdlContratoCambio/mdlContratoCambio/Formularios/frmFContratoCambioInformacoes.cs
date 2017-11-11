using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContratoCambio
{
	/// <summary>
	/// Summary description for frmFContratoCambioInformacoes.
	/// </summary>
	internal class frmFContratoCambioInformacoes : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(int nContratoCambio,out string strNumero,out string strContratacao,out string strValor,out string strSaldo,out bool bCancelarSaldo);
			public delegate void delCallRefreshVinculos(int nContratoCambio,ref mdlComponentesGraficos.ListView lvVinculos);
			public delegate bool delCallCancelarSaldo(int nContratoCambio,bool bCancelarSaldo);
			public delegate bool delCallVinculacaoLiquidar(int nContratoCambio,string strIdPe);
			public delegate bool delCallVinculacaoExcluir(int nContratoCambio,string strIdPe);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallRefreshVinculos eCallRefreshVinculos;
			public event delCallCancelarSaldo eCallCancelarSaldo;
			public event delCallVinculacaoLiquidar eCallVinculacaoLiquidar;
			public event delCallVinculacaoExcluir eCallVinculacaoExcluir;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					m_bCheckBoxesEnabled = false;
					string strNumero,strContratacao,strValor,strSaldo;
					bool bCancelarSaldo;
					eCallCarregaDados(m_nContratoCambio,out strNumero,out strContratacao,out strValor,out strSaldo,out bCancelarSaldo);
					m_txtNumero.Text = strNumero;
					m_txtContratacao.Text = strContratacao;
					m_txtValor.Text = strValor;
					m_txtSaldo.Text = strSaldo;
					m_ckCancelarSaldo.Checked = bCancelarSaldo;
					m_bCheckBoxesEnabled = true;
				}
			}

			protected virtual void OnCallRefreshVinculos()
			{
				if (eCallRefreshVinculos != null)
					eCallRefreshVinculos(m_nContratoCambio,ref m_lvVinculos);
			}

			protected virtual bool OnCallCancelarSaldo()
			{
				bool bRetorno = false;
				if (eCallCancelarSaldo != null)
				{
					if (bRetorno = eCallCancelarSaldo(m_nContratoCambio,m_ckCancelarSaldo.Checked))
					{
						OnCallCarregaDados();
						OnCallRefreshVinculos();
					}
				}
				return(bRetorno);
			}

			protected virtual bool OnCallVinculacaoLiquidar()
			{
				bool bRetorno = false;
				if (eCallVinculacaoLiquidar != null)
				{
					if (m_lvVinculos.SelectedItems.Count > 0)
					{
						if (bRetorno = eCallVinculacaoLiquidar(m_nContratoCambio,m_lvVinculos.SelectedItems[0].Text))
							OnCallRefreshVinculos();
					}
				}
				return(bRetorno);
			}

			protected virtual bool OnCallVinculacaoExcluir()
			{
				bool bRetorno = false;
				if (eCallVinculacaoExcluir != null)
				{
					if (m_lvVinculos.SelectedItems.Count > 0)
					{
						if (bRetorno = eCallVinculacaoExcluir(m_nContratoCambio,m_lvVinculos.SelectedItems[0].Text))
						{
							OnCallCarregaDados();
							OnCallRefreshVinculos();
						}
					}
				}
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private int m_nContratoCambio = -1;

			private bool m_bCheckBoxesEnabled = false;

			public bool m_bModificado = false;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private System.Windows.Forms.GroupBox m_gbBorderos;
			private System.Windows.Forms.Label m_lbNumero;
			private System.Windows.Forms.TextBox m_txtNumero;
			private mdlComponentesGraficos.ListView m_lvVinculos;
			private System.Windows.Forms.TextBox m_txtValor;
			private System.Windows.Forms.Label m_lbValor;
			private System.Windows.Forms.TextBox m_txtSaldo;
			private System.Windows.Forms.Label m_lbSaldo;
			private System.Windows.Forms.TextBox m_txtContratacao;
			private System.Windows.Forms.Label m_lbContratacao;
			private System.Windows.Forms.ColumnHeader m_colhPE;
			private System.Windows.Forms.ColumnHeader m_colhValorContrato;
			private System.Windows.Forms.ColumnHeader m_colhValorFatura;
			private System.Windows.Forms.ColumnHeader m_colhLiquidado;
			public System.Windows.Forms.Button m_btVinculacaoLiquidar;
			public System.Windows.Forms.Button m_btVinculacaoExcluir;
		private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.CheckBox m_ckCancelarSaldo;
			internal System.Windows.Forms.Button m_btCancelar;
		#endregion
		#region Constructor and Destructors
			public frmFContratoCambioInformacoes(string strEnderecoExecutavel,int nContratoCambio)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nContratoCambio = nContratoCambio;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContratoCambioInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbBorderos = new System.Windows.Forms.GroupBox();
			this.m_btVinculacaoExcluir = new System.Windows.Forms.Button();
			this.m_btVinculacaoLiquidar = new System.Windows.Forms.Button();
			this.m_lvVinculos = new mdlComponentesGraficos.ListView();
			this.m_colhPE = new System.Windows.Forms.ColumnHeader();
			this.m_colhValorContrato = new System.Windows.Forms.ColumnHeader();
			this.m_colhValorFatura = new System.Windows.Forms.ColumnHeader();
			this.m_colhLiquidado = new System.Windows.Forms.ColumnHeader();
			this.m_ckCancelarSaldo = new System.Windows.Forms.CheckBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_txtContratacao = new System.Windows.Forms.TextBox();
			this.m_lbContratacao = new System.Windows.Forms.Label();
			this.m_txtSaldo = new System.Windows.Forms.TextBox();
			this.m_lbSaldo = new System.Windows.Forms.Label();
			this.m_txtValor = new System.Windows.Forms.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_txtNumero = new System.Windows.Forms.TextBox();
			this.m_lbNumero = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbBorderos.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbBorderos);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(405, 417);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbBorderos
			// 
			this.m_gbBorderos.Controls.Add(this.m_btVinculacaoExcluir);
			this.m_gbBorderos.Controls.Add(this.m_btVinculacaoLiquidar);
			this.m_gbBorderos.Controls.Add(this.m_lvVinculos);
			this.m_gbBorderos.Controls.Add(this.m_ckCancelarSaldo);
			this.m_gbBorderos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBorderos.Location = new System.Drawing.Point(7, 88);
			this.m_gbBorderos.Name = "m_gbBorderos";
			this.m_gbBorderos.Size = new System.Drawing.Size(393, 288);
			this.m_gbBorderos.TabIndex = 15;
			this.m_gbBorderos.TabStop = false;
			this.m_gbBorderos.Text = "Borderôs";
			// 
			// m_btVinculacaoExcluir
			// 
			this.m_btVinculacaoExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVinculacaoExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVinculacaoExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVinculacaoExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVinculacaoExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btVinculacaoExcluir.Image")));
			this.m_btVinculacaoExcluir.Location = new System.Drawing.Point(202, 12);
			this.m_btVinculacaoExcluir.Name = "m_btVinculacaoExcluir";
			this.m_btVinculacaoExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVinculacaoExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btVinculacaoExcluir.TabIndex = 18;
			this.m_btVinculacaoExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btVinculacaoExcluir, "Excluir");
			this.m_btVinculacaoExcluir.Click += new System.EventHandler(this.m_btVinculacaoExcluir_Click);
			// 
			// m_btVinculacaoLiquidar
			// 
			this.m_btVinculacaoLiquidar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVinculacaoLiquidar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVinculacaoLiquidar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVinculacaoLiquidar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVinculacaoLiquidar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVinculacaoLiquidar.Image")));
			this.m_btVinculacaoLiquidar.Location = new System.Drawing.Point(171, 12);
			this.m_btVinculacaoLiquidar.Name = "m_btVinculacaoLiquidar";
			this.m_btVinculacaoLiquidar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVinculacaoLiquidar.Size = new System.Drawing.Size(25, 25);
			this.m_btVinculacaoLiquidar.TabIndex = 17;
			this.m_btVinculacaoLiquidar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btVinculacaoLiquidar, "Liquidar");
			this.m_btVinculacaoLiquidar.Click += new System.EventHandler(this.m_btVinculacaoLiquidar_Click);
			// 
			// m_lvVinculos
			// 
			this.m_lvVinculos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.m_colhPE,
																						   this.m_colhValorContrato,
																						   this.m_colhValorFatura,
																						   this.m_colhLiquidado});
			this.m_lvVinculos.FullRowSelect = true;
			this.m_lvVinculos.HideSelection = false;
			this.m_lvVinculos.Location = new System.Drawing.Point(8, 40);
			this.m_lvVinculos.Name = "m_lvVinculos";
			this.m_lvVinculos.Size = new System.Drawing.Size(376, 224);
			this.m_lvVinculos.TabIndex = 0;
			this.m_lvVinculos.View = System.Windows.Forms.View.Details;
			this.m_lvVinculos.DoubleClick += new System.EventHandler(this.m_lvVinculos_DoubleClick);
			// 
			// m_colhPE
			// 
			this.m_colhPE.Text = "PE";
			this.m_colhPE.Width = 77;
			// 
			// m_colhValorContrato
			// 
			this.m_colhValorContrato.Text = "Valor Contrato";
			this.m_colhValorContrato.Width = 118;
			// 
			// m_colhValorFatura
			// 
			this.m_colhValorFatura.Text = "Valor Fatura";
			this.m_colhValorFatura.Width = 105;
			// 
			// m_colhLiquidado
			// 
			this.m_colhLiquidado.Text = "Liquidado";
			this.m_colhLiquidado.Width = 69;
			// 
			// m_ckCancelarSaldo
			// 
			this.m_ckCancelarSaldo.Location = new System.Drawing.Point(9, 268);
			this.m_ckCancelarSaldo.Name = "m_ckCancelarSaldo";
			this.m_ckCancelarSaldo.Size = new System.Drawing.Size(128, 16);
			this.m_ckCancelarSaldo.TabIndex = 8;
			this.m_ckCancelarSaldo.Text = "Cancelar Saldo";
			this.m_ckCancelarSaldo.CheckedChanged += new System.EventHandler(this.m_ckCancelarSaldo_CheckedChanged);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_txtContratacao);
			this.m_gbInformacoes.Controls.Add(this.m_lbContratacao);
			this.m_gbInformacoes.Controls.Add(this.m_txtSaldo);
			this.m_gbInformacoes.Controls.Add(this.m_lbSaldo);
			this.m_gbInformacoes.Controls.Add(this.m_txtValor);
			this.m_gbInformacoes.Controls.Add(this.m_lbValor);
			this.m_gbInformacoes.Controls.Add(this.m_txtNumero);
			this.m_gbInformacoes.Controls.Add(this.m_lbNumero);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(7, 8);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(393, 80);
			this.m_gbInformacoes.TabIndex = 14;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// m_txtContratacao
			// 
			this.m_txtContratacao.Location = new System.Drawing.Point(268, 20);
			this.m_txtContratacao.Name = "m_txtContratacao";
			this.m_txtContratacao.ReadOnly = true;
			this.m_txtContratacao.Size = new System.Drawing.Size(112, 20);
			this.m_txtContratacao.TabIndex = 7;
			this.m_txtContratacao.Text = "";
			// 
			// m_lbContratacao
			// 
			this.m_lbContratacao.Location = new System.Drawing.Point(191, 24);
			this.m_lbContratacao.Name = "m_lbContratacao";
			this.m_lbContratacao.Size = new System.Drawing.Size(80, 16);
			this.m_lbContratacao.TabIndex = 6;
			this.m_lbContratacao.Text = "Contratação:";
			// 
			// m_txtSaldo
			// 
			this.m_txtSaldo.Location = new System.Drawing.Point(268, 47);
			this.m_txtSaldo.Name = "m_txtSaldo";
			this.m_txtSaldo.ReadOnly = true;
			this.m_txtSaldo.Size = new System.Drawing.Size(112, 20);
			this.m_txtSaldo.TabIndex = 5;
			this.m_txtSaldo.Text = "";
			// 
			// m_lbSaldo
			// 
			this.m_lbSaldo.Location = new System.Drawing.Point(193, 49);
			this.m_lbSaldo.Name = "m_lbSaldo";
			this.m_lbSaldo.Size = new System.Drawing.Size(40, 16);
			this.m_lbSaldo.TabIndex = 4;
			this.m_lbSaldo.Text = "Saldo:";
			// 
			// m_txtValor
			// 
			this.m_txtValor.Location = new System.Drawing.Point(70, 46);
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.ReadOnly = true;
			this.m_txtValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtValor.TabIndex = 3;
			this.m_txtValor.Text = "";
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(11, 48);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(56, 16);
			this.m_lbValor.TabIndex = 2;
			this.m_lbValor.Text = "Principal:";
			// 
			// m_txtNumero
			// 
			this.m_txtNumero.Location = new System.Drawing.Point(70, 20);
			this.m_txtNumero.Name = "m_txtNumero";
			this.m_txtNumero.ReadOnly = true;
			this.m_txtNumero.Size = new System.Drawing.Size(112, 20);
			this.m_txtNumero.TabIndex = 1;
			this.m_txtNumero.Text = "";
			// 
			// m_lbNumero
			// 
			this.m_lbNumero.Location = new System.Drawing.Point(10, 25);
			this.m_lbNumero.Name = "m_lbNumero";
			this.m_lbNumero.Size = new System.Drawing.Size(56, 16);
			this.m_lbNumero.TabIndex = 0;
			this.m_lbNumero.Text = "Número:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(140, 381);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
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
			this.m_btCancelar.Location = new System.Drawing.Point(204, 381);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
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
			// frmFContratoCambioInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 424);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContratoCambioInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informações do Contrato de Câmbio";
			this.Load += new System.EventHandler(this.frmFContratoCambioInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbBorderos.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContratoCambioInformacoes_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaDados();
					OnCallRefreshVinculos();
				}
			#endregion
			#region lvVinculos
				private void m_lvVinculos_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallVinculacaoLiquidar();
				}
			#endregion
			#region CheckBoxes
				private void m_ckCancelarSaldo_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bCheckBoxesEnabled)
						OnCallCancelarSaldo();
				}
			#endregion
			#region Botoes
				private void m_btVinculacaoLiquidar_Click(object sender, System.EventArgs e)
				{
					OnCallVinculacaoLiquidar();
				}

				private void m_btVinculacaoExcluir_Click(object sender, System.EventArgs e)
				{
                    OnCallVinculacaoExcluir();				
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
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
	}
}
