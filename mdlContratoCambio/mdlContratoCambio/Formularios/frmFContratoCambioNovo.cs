using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContratoCambio
{
	/// <summary>
	/// Summary description for frmFContratoCambioNovo.
	/// </summary>
	internal class frmFContratoCambioNovo : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaBancos(ref mdlComponentesGraficos.ComboBox cbBancos);
			public delegate void delCallCarregaSimboloMoeda(out string strMoeda);
			public delegate bool delCallShowDialogBancos();
			public delegate bool delCallShowDialogMoeda();
			public delegate bool delCallSalvaDados(TipoContratacao enumTipoContratacao,int nIdBanco,string strNumero,System.DateTime dtEmissao,System.DateTime dtVencimento,double dValor,double dTaxaCambial);
		#endregion
		#region Events
			public event delCallCarregaBancos eCallCarregaBancos;
			public event delCallCarregaSimboloMoeda eCallCarregaSimboloMoeda;
			public event delCallShowDialogBancos eCallShowDialogBancos;
			public event delCallShowDialogMoeda eCallShowDialogMoeda;	
			public event delCallSalvaDados eCallSalvaDados;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaBancos()
			{
				if (eCallCarregaBancos != null)
					eCallCarregaBancos(ref m_cbBancos);
			}

			protected virtual void OnCallCarregaSimboloMoeda()
			{
				if (eCallCarregaSimboloMoeda != null)
				{
					string strSimboloMoeda;
					eCallCarregaSimboloMoeda(out strSimboloMoeda);
					m_btMoeda.Text = strSimboloMoeda;
				}
			}

			protected virtual void OnCallShowDialogBancos()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDialogBancos != null)
				{
					if (eCallShowDialogBancos())
					{
						OnCallCarregaBancos();
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowDialogMoeda()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowDialogMoeda != null)
				{
					if (eCallShowDialogMoeda())
						OnCallCarregaSimboloMoeda();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
				{
					// Tipo Contrato
					TipoContratacao enumTipoContratacao = TipoContratacao.Indefinido;
					if (m_rbACC.Checked)
						enumTipoContratacao = TipoContratacao.ACC;
					if (m_rbACE.Checked)
						enumTipoContratacao = TipoContratacao.ACE;
					if (m_rbSemAdiantamento.Checked)
						enumTipoContratacao = TipoContratacao.Normal;
					// Banco
					int nIdBanco = -1;
					object obj = m_cbBancos.ReturnObjectSelectedItem();
					if (obj != null)
						nIdBanco = Int32.Parse(obj.ToString());
					// Numero
					string strNumero = m_txtNumero.Text.Trim();
					// Data Emissao
					System.DateTime dtEmissao = m_dpEmissao.Value;
					// Data Vencimento 
					System.DateTime dtVencimento = m_dpVencimento.Value;
					// Valor 
					double dValor = 0;
					if (m_txtValor.Text != "")
						dValor = double.Parse(m_txtValor.Text);
					// Taxa Cambial
					double dTaxaCambial = 0;
					if (m_txtTaxaCambial.Text != "")
						dTaxaCambial = double.Parse(m_txtTaxaCambial.Text);
					bRetorno = eCallSalvaDados(enumTipoContratacao,nIdBanco,strNumero,dtEmissao,dtVencimento,dValor,dTaxaCambial);
				}
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strEnderecoExecutavel = "";

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.RadioButton m_rbACC;
			private System.Windows.Forms.GroupBox m_gbInformacoes;
			private mdlComponentesGraficos.ComboBox m_cbBancos;
			private mdlComponentesGraficos.TextBox m_txtNumero;
			private System.Windows.Forms.Button m_btMoeda;
			private mdlComponentesGraficos.TextBox m_txtValorTotal;
			private System.Windows.Forms.Label m_lbValorTotal;
			private mdlComponentesGraficos.TextBox m_txtValor;
			private System.Windows.Forms.Label m_lbValor;
			private mdlComponentesGraficos.TextBox m_txtTaxaCambial;
			private System.Windows.Forms.Label m_lbTaxaCambial;
			private System.Windows.Forms.DateTimePicker m_dpVencimento;
			private System.Windows.Forms.Label m_lbVencimento;
			private System.Windows.Forms.DateTimePicker m_dpEmissao;
			private System.Windows.Forms.Label m_lbEmissao;
			private System.Windows.Forms.Label m_lbNumero;
			private System.Windows.Forms.Label m_lbBanco;
			private System.Windows.Forms.GroupBox m_gbTiposContrato;
			private System.Windows.Forms.RadioButton m_rbSemAdiantamento;
			private System.Windows.Forms.RadioButton m_rbACE;
			public System.Windows.Forms.Button m_btBancoExportador;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructor and Destructors
			public frmFContratoCambioNovo(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContratoCambioNovo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_btBancoExportador = new System.Windows.Forms.Button();
			this.m_txtValorTotal = new mdlComponentesGraficos.TextBox();
			this.m_lbValorTotal = new System.Windows.Forms.Label();
			this.m_txtValor = new mdlComponentesGraficos.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_txtTaxaCambial = new mdlComponentesGraficos.TextBox();
			this.m_btMoeda = new System.Windows.Forms.Button();
			this.m_lbTaxaCambial = new System.Windows.Forms.Label();
			this.m_dpVencimento = new System.Windows.Forms.DateTimePicker();
			this.m_lbVencimento = new System.Windows.Forms.Label();
			this.m_dpEmissao = new System.Windows.Forms.DateTimePicker();
			this.m_lbEmissao = new System.Windows.Forms.Label();
			this.m_txtNumero = new mdlComponentesGraficos.TextBox();
			this.m_lbNumero = new System.Windows.Forms.Label();
			this.m_cbBancos = new mdlComponentesGraficos.ComboBox();
			this.m_lbBanco = new System.Windows.Forms.Label();
			this.m_gbTiposContrato = new System.Windows.Forms.GroupBox();
			this.m_rbACC = new System.Windows.Forms.RadioButton();
			this.m_rbSemAdiantamento = new System.Windows.Forms.RadioButton();
			this.m_rbACE = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbTiposContrato.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_gbTiposContrato);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(277, 321);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.m_btBancoExportador);
			this.m_gbInformacoes.Controls.Add(this.m_txtValorTotal);
			this.m_gbInformacoes.Controls.Add(this.m_lbValorTotal);
			this.m_gbInformacoes.Controls.Add(this.m_txtValor);
			this.m_gbInformacoes.Controls.Add(this.m_lbValor);
			this.m_gbInformacoes.Controls.Add(this.m_txtTaxaCambial);
			this.m_gbInformacoes.Controls.Add(this.m_btMoeda);
			this.m_gbInformacoes.Controls.Add(this.m_lbTaxaCambial);
			this.m_gbInformacoes.Controls.Add(this.m_dpVencimento);
			this.m_gbInformacoes.Controls.Add(this.m_lbVencimento);
			this.m_gbInformacoes.Controls.Add(this.m_dpEmissao);
			this.m_gbInformacoes.Controls.Add(this.m_lbEmissao);
			this.m_gbInformacoes.Controls.Add(this.m_txtNumero);
			this.m_gbInformacoes.Controls.Add(this.m_lbNumero);
			this.m_gbInformacoes.Controls.Add(this.m_cbBancos);
			this.m_gbInformacoes.Controls.Add(this.m_lbBanco);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(7, 92);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(264, 196);
			this.m_gbInformacoes.TabIndex = 2;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações Adicionais";
			// 
			// m_btBancoExportador
			// 
			this.m_btBancoExportador.BackColor = System.Drawing.SystemColors.Control;
			this.m_btBancoExportador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBancoExportador.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btBancoExportador.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btBancoExportador.Image = ((System.Drawing.Image)(resources.GetObject("m_btBancoExportador.Image")));
			this.m_btBancoExportador.Location = new System.Drawing.Point(235, 19);
			this.m_btBancoExportador.Name = "m_btBancoExportador";
			this.m_btBancoExportador.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btBancoExportador.Size = new System.Drawing.Size(25, 25);
			this.m_btBancoExportador.TabIndex = 12;
			this.m_btBancoExportador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btBancoExportador, "Bancos");
			this.m_btBancoExportador.Click += new System.EventHandler(this.m_btBancoExportador_Click);
			// 
			// m_txtValorTotal
			// 
			this.m_txtValorTotal.Enabled = false;
			this.m_txtValorTotal.Location = new System.Drawing.Point(103, 167);
			this.m_txtValorTotal.Name = "m_txtValorTotal";
			this.m_txtValorTotal.OnlyNumbers = true;
			this.m_txtValorTotal.Size = new System.Drawing.Size(152, 20);
			this.m_txtValorTotal.TabIndex = 14;
			this.m_txtValorTotal.Text = "";
			this.m_txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbValorTotal
			// 
			this.m_lbValorTotal.Location = new System.Drawing.Point(7, 168);
			this.m_lbValorTotal.Name = "m_lbValorTotal";
			this.m_lbValorTotal.Size = new System.Drawing.Size(98, 16);
			this.m_lbValorTotal.TabIndex = 13;
			this.m_lbValorTotal.Text = "Valor Total:     R$";
			// 
			// m_txtValor
			// 
			this.m_txtValor.Location = new System.Drawing.Point(104, 120);
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.OnlyNumbers = true;
			this.m_txtValor.Size = new System.Drawing.Size(152, 20);
			this.m_txtValor.TabIndex = 7;
			this.m_txtValor.Text = "";
			this.m_txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtValor.TextChanged += new System.EventHandler(this.m_txtValor_TextChanged);
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(6, 124);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(43, 16);
			this.m_lbValor.TabIndex = 11;
			this.m_lbValor.Text = "Valor:";
			// 
			// m_txtTaxaCambial
			// 
			this.m_txtTaxaCambial.Location = new System.Drawing.Point(103, 144);
			this.m_txtTaxaCambial.Name = "m_txtTaxaCambial";
			this.m_txtTaxaCambial.OnlyNumbers = true;
			this.m_txtTaxaCambial.Size = new System.Drawing.Size(48, 20);
			this.m_txtTaxaCambial.TabIndex = 8;
			this.m_txtTaxaCambial.Text = "0,00";
			this.m_txtTaxaCambial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtTaxaCambial.TextChanged += new System.EventHandler(this.m_txtTaxaCambial_TextChanged);
			// 
			// m_btMoeda
			// 
			this.m_btMoeda.Location = new System.Drawing.Point(54, 119);
			this.m_btMoeda.Name = "m_btMoeda";
			this.m_btMoeda.Size = new System.Drawing.Size(48, 24);
			this.m_btMoeda.TabIndex = 11;
			this.m_btMoeda.Click += new System.EventHandler(this.m_btMoeda_Click);
			// 
			// m_lbTaxaCambial
			// 
			this.m_lbTaxaCambial.Location = new System.Drawing.Point(4, 148);
			this.m_lbTaxaCambial.Name = "m_lbTaxaCambial";
			this.m_lbTaxaCambial.Size = new System.Drawing.Size(104, 16);
			this.m_lbTaxaCambial.TabIndex = 8;
			this.m_lbTaxaCambial.Text = "Taxa Cambial:  R$";
			// 
			// m_dpVencimento
			// 
			this.m_dpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpVencimento.Location = new System.Drawing.Point(82, 94);
			this.m_dpVencimento.Name = "m_dpVencimento";
			this.m_dpVencimento.Size = new System.Drawing.Size(88, 20);
			this.m_dpVencimento.TabIndex = 6;
			// 
			// m_lbVencimento
			// 
			this.m_lbVencimento.Location = new System.Drawing.Point(5, 96);
			this.m_lbVencimento.Name = "m_lbVencimento";
			this.m_lbVencimento.Size = new System.Drawing.Size(72, 16);
			this.m_lbVencimento.TabIndex = 6;
			this.m_lbVencimento.Text = "Vencimento:";
			// 
			// m_dpEmissao
			// 
			this.m_dpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpEmissao.Location = new System.Drawing.Point(82, 70);
			this.m_dpEmissao.Name = "m_dpEmissao";
			this.m_dpEmissao.Size = new System.Drawing.Size(88, 20);
			this.m_dpEmissao.TabIndex = 5;
			// 
			// m_lbEmissao
			// 
			this.m_lbEmissao.Location = new System.Drawing.Point(6, 72);
			this.m_lbEmissao.Name = "m_lbEmissao";
			this.m_lbEmissao.Size = new System.Drawing.Size(56, 16);
			this.m_lbEmissao.TabIndex = 4;
			this.m_lbEmissao.Text = "Emissão:";
			// 
			// m_txtNumero
			// 
			this.m_txtNumero.Location = new System.Drawing.Point(64, 46);
			this.m_txtNumero.Mask = true;
			this.m_txtNumero.MaskAutomaticSpecialCharacters = true;
			this.m_txtNumero.MaskText = "AA/AAAAAA";
			this.m_txtNumero.Name = "m_txtNumero";
			this.m_txtNumero.Size = new System.Drawing.Size(104, 20);
			this.m_txtNumero.TabIndex = 4;
			this.m_txtNumero.Text = "";
			// 
			// m_lbNumero
			// 
			this.m_lbNumero.Location = new System.Drawing.Point(7, 48);
			this.m_lbNumero.Name = "m_lbNumero";
			this.m_lbNumero.Size = new System.Drawing.Size(52, 16);
			this.m_lbNumero.TabIndex = 2;
			this.m_lbNumero.Text = "Número:";
			// 
			// m_cbBancos
			// 
			this.m_cbBancos.Location = new System.Drawing.Point(64, 21);
			this.m_cbBancos.Name = "m_cbBancos";
			this.m_cbBancos.Size = new System.Drawing.Size(168, 22);
			this.m_cbBancos.TabIndex = 3;
			// 
			// m_lbBanco
			// 
			this.m_lbBanco.Location = new System.Drawing.Point(7, 24);
			this.m_lbBanco.Name = "m_lbBanco";
			this.m_lbBanco.Size = new System.Drawing.Size(48, 16);
			this.m_lbBanco.TabIndex = 0;
			this.m_lbBanco.Text = "Banco:";
			// 
			// m_gbTiposContrato
			// 
			this.m_gbTiposContrato.Controls.Add(this.m_rbACC);
			this.m_gbTiposContrato.Controls.Add(this.m_rbSemAdiantamento);
			this.m_gbTiposContrato.Controls.Add(this.m_rbACE);
			this.m_gbTiposContrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTiposContrato.Location = new System.Drawing.Point(8, 11);
			this.m_gbTiposContrato.Name = "m_gbTiposContrato";
			this.m_gbTiposContrato.Size = new System.Drawing.Size(264, 80);
			this.m_gbTiposContrato.TabIndex = 1;
			this.m_gbTiposContrato.TabStop = false;
			this.m_gbTiposContrato.Text = "Tipo de Contrato";
			// 
			// m_rbACC
			// 
			this.m_rbACC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbACC.Location = new System.Drawing.Point(8, 24);
			this.m_rbACC.Name = "m_rbACC";
			this.m_rbACC.Size = new System.Drawing.Size(96, 16);
			this.m_rbACC.TabIndex = 14;
			this.m_rbACC.Text = "ACC";
			// 
			// m_rbSemAdiantamento
			// 
			this.m_rbSemAdiantamento.Checked = true;
			this.m_rbSemAdiantamento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbSemAdiantamento.Location = new System.Drawing.Point(8, 56);
			this.m_rbSemAdiantamento.Name = "m_rbSemAdiantamento";
			this.m_rbSemAdiantamento.Size = new System.Drawing.Size(136, 16);
			this.m_rbSemAdiantamento.TabIndex = 16;
			this.m_rbSemAdiantamento.TabStop = true;
			this.m_rbSemAdiantamento.Text = "Sem adiantamento";
			// 
			// m_rbACE
			// 
			this.m_rbACE.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbACE.Location = new System.Drawing.Point(8, 40);
			this.m_rbACE.Name = "m_rbACE";
			this.m_rbACE.Size = new System.Drawing.Size(96, 16);
			this.m_rbACE.TabIndex = 15;
			this.m_rbACE.Text = "ACE";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(80, 291);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 9;
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
			this.m_btCancelar.Location = new System.Drawing.Point(144, 291);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 10;
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
			// frmFContratoCambioNovo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 328);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContratoCambioNovo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Novo Contrato de Câmbio";
			this.Load += new System.EventHandler(this.frmFContratoCambioNovo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbTiposContrato.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFContratoCambioNovo_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallCarregaBancos();
					OnCallCarregaSimboloMoeda();
				}
			#endregion
			#region Botoes
				private void m_btBancoExportador_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogBancos();
				}

				private void m_btMoeda_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogMoeda();
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
			#region TextBoxes
				private void m_txtValor_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshValorTotal();
				}

				private void m_txtTaxaCambial_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshValorTotal();
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

		#region Refresh
			private void vRefreshValorTotal()
			{
				double dValor = 0;
				double dTaxaCambial = 0;
				if ((m_txtValor.Text != "") && (m_txtTaxaCambial.Text != ""))
				{
					dValor = double.Parse( m_txtValor.Text);
					dTaxaCambial = double.Parse(m_txtTaxaCambial.Text);
					dValor = dValor * dTaxaCambial;
				}
				m_txtValorTotal.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(0,dValor,false);
			}
		#endregion
	}
}
