using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosBordero
{
	/// <summary>
	/// Summary description for frmFProdutosBordero.
	/// </summary>
	internal class frmFProdutosBordero : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaValores(out string strValorFatura,out string strValorVinculado,out string strSaldo);
			public delegate void delCallRefreshContratosCambio(ref mdlComponentesGraficos.ListView lvContratos);
			public delegate void delCallRefreshProdutosBordero(ref mdlComponentesGraficos.ListView lvBordero);
			public delegate bool delCallShowContratosCambio();
			public delegate bool delCallProdutoAdiciona(int nIdContratoCambio);
			public delegate bool delCallProdutoRemove(int nIdContratoCambio);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events 
			public event delCallCarregaValores eCallCarregaValores;
			public event delCallRefreshContratosCambio eCallRefreshContratosCambio;
			public event delCallRefreshProdutosBordero eCallRefreshProdutosBordero;
			public event delCallShowContratosCambio eCallShowContratosCambio;
			public event delCallProdutoAdiciona eCallProdutoAdiciona;
			public event delCallProdutoRemove eCallProdutoRemove;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallCarregaValores()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallCarregaValores != null)
				{
					string strValorFatura,strValorVinculado,strSaldo;
					eCallCarregaValores(out strValorFatura,out strValorVinculado,out strSaldo);
					m_txtValorFatura.Text = strValorFatura;
					m_txtTotalVinculado.Text = strValorVinculado;
					m_txtSaldo.Text = strSaldo;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallRefreshContratosCambio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshContratosCambio != null)
					eCallRefreshContratosCambio(ref m_lvContratosCambio);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallRefreshProdutosBordero()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshProdutosBordero != null)
					eCallRefreshProdutosBordero(ref m_lvBordero);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void OnCallShowContratosCambio()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowContratosCambio != null)
					eCallShowContratosCambio();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void OnCallProdutoAdiciona()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallProdutoAdiciona != null)
				{
					if (m_lvContratosCambio.SelectedItems.Count > 0)
					{
						int nIdContratoCambio = Int32.Parse(m_lvContratosCambio.SelectedItems[0].Tag.ToString());
						if (eCallProdutoAdiciona(nIdContratoCambio))
						{
							this.OnCallCarregaValores();
							this.OnCallRefreshContratosCambio();
							this.OnCallRefreshProdutosBordero();
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void OnCallProdutoRemove()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallProdutoRemove != null)
				{
					if (m_lvBordero.SelectedItems.Count > 0)
					{
						int nIdContratoCambio = Int32.Parse(m_lvBordero.SelectedItems[0].Tag.ToString());
						if (eCallProdutoRemove(nIdContratoCambio))
						{
							this.OnCallCarregaValores();
							this.OnCallRefreshContratosCambio();
							this.OnCallRefreshProdutosBordero();
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbContratosCambio;
			private mdlComponentesGraficos.ListView m_lvContratosCambio;
			private System.Windows.Forms.Button m_btContratoInsere;
			private System.Windows.Forms.Button m_btContratoRemove;
			private System.Windows.Forms.GroupBox m_gbBordero;
			private mdlComponentesGraficos.ListView m_lvBordero;
			public System.Windows.Forms.Button m_btContratosCambio;
			private System.Windows.Forms.ColumnHeader m_colhNumero;
			private System.Windows.Forms.ColumnHeader m_colhBanco;
			private System.Windows.Forms.ColumnHeader m_colhTipoContratacao;
			private System.Windows.Forms.ColumnHeader m_colhValorTotal;
			private System.Windows.Forms.ColumnHeader m_colhSaldo;
			private System.Windows.Forms.ColumnHeader m_colhDataVencimento;
			private System.Windows.Forms.ColumnHeader m_colhDataEmissao;
			private System.Windows.Forms.Label m_lbValorFatura;
			private System.Windows.Forms.TextBox m_txtValorFatura;
			private System.Windows.Forms.TextBox m_txtTotalVinculado;
			private System.Windows.Forms.Label m_lbTotalVinculado;
			private System.Windows.Forms.TextBox m_txtSaldo;
			private System.Windows.Forms.Label m_lbSaldo;
			private System.Windows.Forms.ColumnHeader m_colhPNumero;
			private System.Windows.Forms.ColumnHeader m_colhPValorFatura;
			private System.Windows.Forms.ColumnHeader m_colhPValorContrato;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors 
			public frmFProdutosBordero(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosBordero));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtSaldo = new System.Windows.Forms.TextBox();
			this.m_lbSaldo = new System.Windows.Forms.Label();
			this.m_txtTotalVinculado = new System.Windows.Forms.TextBox();
			this.m_lbTotalVinculado = new System.Windows.Forms.Label();
			this.m_txtValorFatura = new System.Windows.Forms.TextBox();
			this.m_lbValorFatura = new System.Windows.Forms.Label();
			this.m_btContratosCambio = new System.Windows.Forms.Button();
			this.m_gbBordero = new System.Windows.Forms.GroupBox();
			this.m_lvBordero = new mdlComponentesGraficos.ListView();
			this.m_colhPNumero = new System.Windows.Forms.ColumnHeader();
			this.m_colhPValorFatura = new System.Windows.Forms.ColumnHeader();
			this.m_colhPValorContrato = new System.Windows.Forms.ColumnHeader();
			this.m_btContratoRemove = new System.Windows.Forms.Button();
			this.m_btContratoInsere = new System.Windows.Forms.Button();
			this.m_gbContratosCambio = new System.Windows.Forms.GroupBox();
			this.m_lvContratosCambio = new mdlComponentesGraficos.ListView();
			this.m_colhNumero = new System.Windows.Forms.ColumnHeader();
			this.m_colhBanco = new System.Windows.Forms.ColumnHeader();
			this.m_colhTipoContratacao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDataEmissao = new System.Windows.Forms.ColumnHeader();
			this.m_colhDataVencimento = new System.Windows.Forms.ColumnHeader();
			this.m_colhValorTotal = new System.Windows.Forms.ColumnHeader();
			this.m_colhSaldo = new System.Windows.Forms.ColumnHeader();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbBordero.SuspendLayout();
			this.m_gbContratosCambio.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtSaldo);
			this.m_gbGeral.Controls.Add(this.m_lbSaldo);
			this.m_gbGeral.Controls.Add(this.m_txtTotalVinculado);
			this.m_gbGeral.Controls.Add(this.m_lbTotalVinculado);
			this.m_gbGeral.Controls.Add(this.m_txtValorFatura);
			this.m_gbGeral.Controls.Add(this.m_lbValorFatura);
			this.m_gbGeral.Controls.Add(this.m_btContratosCambio);
			this.m_gbGeral.Controls.Add(this.m_gbBordero);
			this.m_gbGeral.Controls.Add(this.m_btContratoRemove);
			this.m_gbGeral.Controls.Add(this.m_btContratoInsere);
			this.m_gbGeral.Controls.Add(this.m_gbContratosCambio);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(735, 369);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtSaldo
			// 
			this.m_txtSaldo.Location = new System.Drawing.Point(616, 216);
			this.m_txtSaldo.Name = "m_txtSaldo";
			this.m_txtSaldo.ReadOnly = true;
			this.m_txtSaldo.Size = new System.Drawing.Size(112, 20);
			this.m_txtSaldo.TabIndex = 26;
			this.m_txtSaldo.Text = "R$1.000.000";
			this.m_txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbSaldo
			// 
			this.m_lbSaldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSaldo.Location = new System.Drawing.Point(576, 218);
			this.m_lbSaldo.Name = "m_lbSaldo";
			this.m_lbSaldo.Size = new System.Drawing.Size(40, 16);
			this.m_lbSaldo.TabIndex = 25;
			this.m_lbSaldo.Text = "Saldo:";
			// 
			// m_txtTotalVinculado
			// 
			this.m_txtTotalVinculado.Location = new System.Drawing.Point(616, 194);
			this.m_txtTotalVinculado.Name = "m_txtTotalVinculado";
			this.m_txtTotalVinculado.ReadOnly = true;
			this.m_txtTotalVinculado.Size = new System.Drawing.Size(112, 20);
			this.m_txtTotalVinculado.TabIndex = 24;
			this.m_txtTotalVinculado.Text = "R$1.000.000";
			this.m_txtTotalVinculado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbTotalVinculado
			// 
			this.m_lbTotalVinculado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTotalVinculado.Location = new System.Drawing.Point(464, 196);
			this.m_lbTotalVinculado.Name = "m_lbTotalVinculado";
			this.m_lbTotalVinculado.Size = new System.Drawing.Size(152, 16);
			this.m_lbTotalVinculado.TabIndex = 23;
			this.m_lbTotalVinculado.Text = "Total Vinculado Contratos:";
			// 
			// m_txtValorFatura
			// 
			this.m_txtValorFatura.Location = new System.Drawing.Point(616, 171);
			this.m_txtValorFatura.Name = "m_txtValorFatura";
			this.m_txtValorFatura.ReadOnly = true;
			this.m_txtValorFatura.Size = new System.Drawing.Size(112, 20);
			this.m_txtValorFatura.TabIndex = 22;
			this.m_txtValorFatura.Text = "R$1.000.000";
			this.m_txtValorFatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbValorFatura
			// 
			this.m_lbValorFatura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValorFatura.Location = new System.Drawing.Point(540, 174);
			this.m_lbValorFatura.Name = "m_lbValorFatura";
			this.m_lbValorFatura.Size = new System.Drawing.Size(80, 16);
			this.m_lbValorFatura.TabIndex = 21;
			this.m_lbValorFatura.Text = "Valor Fatura:";
			// 
			// m_btContratosCambio
			// 
			this.m_btContratosCambio.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContratosCambio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratosCambio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContratosCambio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContratosCambio.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratosCambio.Image")));
			this.m_btContratosCambio.Location = new System.Drawing.Point(12, 189);
			this.m_btContratosCambio.Name = "m_btContratosCambio";
			this.m_btContratosCambio.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContratosCambio.Size = new System.Drawing.Size(25, 25);
			this.m_btContratosCambio.TabIndex = 20;
			this.m_btContratosCambio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btContratosCambio, "Contratos de Câmbio");
			this.m_btContratosCambio.Click += new System.EventHandler(this.m_btContratosCambio_Click);
			// 
			// m_gbBordero
			// 
			this.m_gbBordero.Controls.Add(this.m_lvBordero);
			this.m_gbBordero.Location = new System.Drawing.Point(8, 238);
			this.m_gbBordero.Name = "m_gbBordero";
			this.m_gbBordero.Size = new System.Drawing.Size(718, 95);
			this.m_gbBordero.TabIndex = 7;
			this.m_gbBordero.TabStop = false;
			this.m_gbBordero.Text = "Contratos Câmbio associados ao Borderô";
			// 
			// m_lvBordero
			// 
			this.m_lvBordero.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.m_colhPNumero,
																						  this.m_colhPValorFatura,
																						  this.m_colhPValorContrato});
			this.m_lvBordero.FullRowSelect = true;
			this.m_lvBordero.HideSelection = false;
			this.m_lvBordero.Location = new System.Drawing.Point(8, 16);
			this.m_lvBordero.Name = "m_lvBordero";
			this.m_lvBordero.Size = new System.Drawing.Size(704, 72);
			this.m_lvBordero.TabIndex = 0;
			this.m_lvBordero.View = System.Windows.Forms.View.Details;
			// 
			// m_colhPNumero
			// 
			this.m_colhPNumero.Text = "Número";
			this.m_colhPNumero.Width = 83;
			// 
			// m_colhPValorFatura
			// 
			this.m_colhPValorFatura.Text = "Valor Fatura";
			this.m_colhPValorFatura.Width = 106;
			// 
			// m_colhPValorContrato
			// 
			this.m_colhPValorContrato.Text = "Valor Contrato";
			this.m_colhPValorContrato.Width = 128;
			// 
			// m_btContratoRemove
			// 
			this.m_btContratoRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratoRemove.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratoRemove.Image")));
			this.m_btContratoRemove.Location = new System.Drawing.Point(366, 183);
			this.m_btContratoRemove.Name = "m_btContratoRemove";
			this.m_btContratoRemove.Size = new System.Drawing.Size(60, 40);
			this.m_btContratoRemove.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btContratoRemove, "Desvincular");
			this.m_btContratoRemove.Click += new System.EventHandler(this.m_btContratoRemove_Click);
			// 
			// m_btContratoInsere
			// 
			this.m_btContratoInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratoInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratoInsere.Image")));
			this.m_btContratoInsere.Location = new System.Drawing.Point(302, 183);
			this.m_btContratoInsere.Name = "m_btContratoInsere";
			this.m_btContratoInsere.Size = new System.Drawing.Size(60, 40);
			this.m_btContratoInsere.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btContratoInsere, "Vincular");
			this.m_btContratoInsere.Click += new System.EventHandler(this.m_btContratoInsere_Click);
			// 
			// m_gbContratosCambio
			// 
			this.m_gbContratosCambio.Controls.Add(this.m_lvContratosCambio);
			this.m_gbContratosCambio.Location = new System.Drawing.Point(5, 8);
			this.m_gbContratosCambio.Name = "m_gbContratosCambio";
			this.m_gbContratosCambio.Size = new System.Drawing.Size(723, 160);
			this.m_gbContratosCambio.TabIndex = 0;
			this.m_gbContratosCambio.TabStop = false;
			this.m_gbContratosCambio.Text = "Contratos de Câmbio ";
			// 
			// m_lvContratosCambio
			// 
			this.m_lvContratosCambio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.m_colhNumero,
																								  this.m_colhBanco,
																								  this.m_colhTipoContratacao,
																								  this.m_colhDataEmissao,
																								  this.m_colhDataVencimento,
																								  this.m_colhValorTotal,
																								  this.m_colhSaldo});
			this.m_lvContratosCambio.FullRowSelect = true;
			this.m_lvContratosCambio.HideSelection = false;
			this.m_lvContratosCambio.Location = new System.Drawing.Point(8, 16);
			this.m_lvContratosCambio.Name = "m_lvContratosCambio";
			this.m_lvContratosCambio.Size = new System.Drawing.Size(704, 136);
			this.m_lvContratosCambio.TabIndex = 0;
			this.m_lvContratosCambio.View = System.Windows.Forms.View.Details;
			this.m_lvContratosCambio.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvContratosCambio_MouseUp);
			// 
			// m_colhNumero
			// 
			this.m_colhNumero.Text = "Número";
			this.m_colhNumero.Width = 71;
			// 
			// m_colhBanco
			// 
			this.m_colhBanco.Text = "Banco";
			this.m_colhBanco.Width = 160;
			// 
			// m_colhTipoContratacao
			// 
			this.m_colhTipoContratacao.Text = "Contratação";
			this.m_colhTipoContratacao.Width = 96;
			// 
			// m_colhDataEmissao
			// 
			this.m_colhDataEmissao.Text = "Data Emissão";
			this.m_colhDataEmissao.Width = 84;
			// 
			// m_colhDataVencimento
			// 
			this.m_colhDataVencimento.Text = "Data Vencimento";
			this.m_colhDataVencimento.Width = 101;
			// 
			// m_colhValorTotal
			// 
			this.m_colhValorTotal.Text = "Principal";
			this.m_colhValorTotal.Width = 95;
			// 
			// m_colhSaldo
			// 
			this.m_colhSaldo.Text = "Saldo";
			this.m_colhSaldo.Width = 93;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(369, 337);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(305, 337);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 1000;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 1000;
			this.m_ttDica.ReshowDelay = 200;
			// 
			// frmFProdutosBordero
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 376);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosBordero";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vincular Contratos de Câmbio";
			this.Load += new System.EventHandler(this.frmFProdutosBordero_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbBordero.ResumeLayout(false);
			this.m_gbContratosCambio.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFProdutosBordero_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaValores();
					OnCallRefreshContratosCambio();
					OnCallRefreshProdutosBordero();
					vBalloonTip();
				}
			#endregion
			#region Botoes
				private void m_btContratoInsere_Click(object sender, System.EventArgs e)
				{
					OnCallProdutoAdiciona();
				}

				private void m_btContratoRemove_Click(object sender, System.EventArgs e)
				{
					OnCallProdutoRemove();
				}

				private void m_btContratosCambio_Click(object sender, System.EventArgs e)
				{
					OnCallShowContratosCambio();
					vBalloonTip();
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
				private void m_lvContratosCambio_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
				{
					if (m_lvContratosCambio.SelectedItems.Count == 0)
					{
						OnCallShowContratosCambio();
					}
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
		#region BalloonTip
			private void  vBalloonTip()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_iniFile = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				if (cls_iniFile.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO,mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,true))
				{
					if (m_lvContratosCambio.Items.Count == 0)
					{
						mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
						mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
						mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_CrieUmContratoCambio);
						mb.Icon = System.Drawing.SystemIcons.Information;
						mb.CloseOnMouseClick = true;
						mb.CloseOnDeactivate = true;
						mb.CloseOnKeyPress = true;
						mb.ShowBalloon((System.Windows.Forms.Control)m_btContratosCambio);
					}
					else
					{
						if (m_lvBordero.Items.Count == 0)
						{
							mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_VincularContratoCambio);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btContratoInsere);
						}
						else
						{
							mdlComponentesGraficos.MessageBalloon mb = new mdlComponentesGraficos.MessageBalloon();
							mb.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							mb.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_DesvincularContratoCambio);
							mb.Icon = System.Drawing.SystemIcons.Information;
							mb.CloseOnMouseClick = true;
							mb.CloseOnDeactivate = true;
							mb.CloseOnKeyPress = true;
							mb.ShowBalloon((System.Windows.Forms.Control)m_btContratoRemove);
						}
					}
				}
			}
		#endregion
	}
}
