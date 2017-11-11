using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosBordero
{
	/// <summary>
	/// Summary description for frmFProdutosBorderoAssociarTaxaCambio.
	/// </summary>
	public class frmFProdutosBorderoAssociarTaxaCambio : System.Windows.Forms.Form
	{
		#region	 Atributes
			private string m_strEnderecoExecutavel = "";
			private int m_nIdContratoCambio = -1;
			private int m_nMoedaFatura = -1;
			private int m_nMoedaContrato = -1;
			private decimal m_dcValorMaxFatura = 0;
			private decimal m_dcValorMaxContrato = 0;
			private decimal m_dcTaxaCambial = 1;
			private decimal m_dcValor = 0;
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Label m_lbTaxaCambio;
			private mdlComponentesGraficos.TextBox m_txtTaxaCambio;
			private System.Windows.Forms.Label m_lbValorVincular;
			private System.Windows.Forms.Label m_lbValorVincular2;
			private System.Windows.Forms.Label m_lbSimboloMoedaFatura;
			private mdlComponentesGraficos.TextBox m_txtValorFatura;
			private System.Windows.Forms.Label m_lbSimboloMoedaContrato;
			private mdlComponentesGraficos.TextBox m_txtValorContrato;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructor and Destructors 
			public frmFProdutosBorderoAssociarTaxaCambio(string strEnderecoExecutavel,int nIdContratoCambio,int nMoedaFatura,string strSimboloMoedaFatura,int nMoedaContrato,string strSimboloMoedaContrato,decimal dcValorMaxFatura,decimal dcValorMaxContrato)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nMoedaFatura = nMoedaFatura;
				m_nMoedaContrato = nMoedaContrato;

				m_nIdContratoCambio = nIdContratoCambio;
				m_dcValorMaxFatura = dcValorMaxFatura;
				m_dcValorMaxContrato = dcValorMaxContrato;

				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();
				m_lbSimboloMoedaFatura.Text = strSimboloMoedaFatura;
				m_lbSimboloMoedaContrato.Text = strSimboloMoedaContrato;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosBorderoAssociarTaxaCambio));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_txtTaxaCambio = new mdlComponentesGraficos.TextBox();
			this.m_lbSimboloMoedaFatura = new System.Windows.Forms.Label();
			this.m_txtValorFatura = new mdlComponentesGraficos.TextBox();
			this.m_lbValorVincular = new System.Windows.Forms.Label();
			this.m_lbTaxaCambio = new System.Windows.Forms.Label();
			this.m_lbSimboloMoedaContrato = new System.Windows.Forms.Label();
			this.m_txtValorContrato = new mdlComponentesGraficos.TextBox();
			this.m_lbValorVincular2 = new System.Windows.Forms.Label();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_txtTaxaCambio);
			this.m_gbGeral.Controls.Add(this.m_lbSimboloMoedaFatura);
			this.m_gbGeral.Controls.Add(this.m_txtValorFatura);
			this.m_gbGeral.Controls.Add(this.m_lbValorVincular);
			this.m_gbGeral.Controls.Add(this.m_lbTaxaCambio);
			this.m_gbGeral.Controls.Add(this.m_lbSimboloMoedaContrato);
			this.m_gbGeral.Controls.Add(this.m_txtValorContrato);
			this.m_gbGeral.Controls.Add(this.m_lbValorVincular2);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 120);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_txtTaxaCambio
			// 
			this.m_txtTaxaCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.m_txtTaxaCambio.Location = new System.Drawing.Point(144, 40);
			this.m_txtTaxaCambio.Name = "m_txtTaxaCambio";
			this.m_txtTaxaCambio.OnlyNumbers = true;
			this.m_txtTaxaCambio.Size = new System.Drawing.Size(57, 20);
			this.m_txtTaxaCambio.TabIndex = 2;
			this.m_txtTaxaCambio.Text = "1,00";
			this.m_txtTaxaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtTaxaCambio.TextChanged += new System.EventHandler(this.m_txtTaxaCambio_TextChanged);
			// 
			// m_lbSimboloMoedaFatura
			// 
			this.m_lbSimboloMoedaFatura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSimboloMoedaFatura.Location = new System.Drawing.Point(104, 16);
			this.m_lbSimboloMoedaFatura.Name = "m_lbSimboloMoedaFatura";
			this.m_lbSimboloMoedaFatura.Size = new System.Drawing.Size(40, 16);
			this.m_lbSimboloMoedaFatura.TabIndex = 18;
			this.m_lbSimboloMoedaFatura.Text = "R$";
			this.m_lbSimboloMoedaFatura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtValorFatura
			// 
			this.m_txtValorFatura.Location = new System.Drawing.Point(144, 16);
			this.m_txtValorFatura.MaxDecimalNumbers = 2;
			this.m_txtValorFatura.Name = "m_txtValorFatura";
			this.m_txtValorFatura.OnlyNumbers = true;
			this.m_txtValorFatura.Size = new System.Drawing.Size(152, 20);
			this.m_txtValorFatura.TabIndex = 1;
			this.m_txtValorFatura.Text = "";
			this.m_txtValorFatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtValorFatura.TextChanged += new System.EventHandler(this.m_txtValorFatura_TextChanged);
			// 
			// m_lbValorVincular
			// 
			this.m_lbValorVincular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValorVincular.Location = new System.Drawing.Point(9, 17);
			this.m_lbValorVincular.Name = "m_lbValorVincular";
			this.m_lbValorVincular.Size = new System.Drawing.Size(85, 16);
			this.m_lbValorVincular.TabIndex = 16;
			this.m_lbValorVincular.Text = "Valor Vincular:";
			// 
			// m_lbTaxaCambio
			// 
			this.m_lbTaxaCambio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTaxaCambio.Location = new System.Drawing.Point(8, 40);
			this.m_lbTaxaCambio.Name = "m_lbTaxaCambio";
			this.m_lbTaxaCambio.Size = new System.Drawing.Size(85, 16);
			this.m_lbTaxaCambio.TabIndex = 15;
			this.m_lbTaxaCambio.Text = "Taxa Cambio:";
			// 
			// m_lbSimboloMoedaContrato
			// 
			this.m_lbSimboloMoedaContrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSimboloMoedaContrato.Location = new System.Drawing.Point(102, 65);
			this.m_lbSimboloMoedaContrato.Name = "m_lbSimboloMoedaContrato";
			this.m_lbSimboloMoedaContrato.Size = new System.Drawing.Size(40, 16);
			this.m_lbSimboloMoedaContrato.TabIndex = 14;
			this.m_lbSimboloMoedaContrato.Text = "R$";
			this.m_lbSimboloMoedaContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtValorContrato
			// 
			this.m_txtValorContrato.Location = new System.Drawing.Point(143, 64);
			this.m_txtValorContrato.Name = "m_txtValorContrato";
			this.m_txtValorContrato.OnlyNumbers = true;
			this.m_txtValorContrato.ReadOnly = true;
			this.m_txtValorContrato.Size = new System.Drawing.Size(152, 20);
			this.m_txtValorContrato.TabIndex = 3;
			this.m_txtValorContrato.Text = "";
			this.m_txtValorContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbValorVincular2
			// 
			this.m_lbValorVincular2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValorVincular2.Location = new System.Drawing.Point(9, 64);
			this.m_lbValorVincular2.Name = "m_lbValorVincular2";
			this.m_lbValorVincular2.Size = new System.Drawing.Size(85, 16);
			this.m_lbValorVincular2.TabIndex = 12;
			this.m_lbValorVincular2.Text = "Valor Vincular:";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(160, 89);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
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
			this.m_btOk.Location = new System.Drawing.Point(96, 89);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 4;
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
			// frmFProdutosBorderoAssociarTaxaCambio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 126);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosBorderoAssociarTaxaCambio";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vincular Contrato Cambio ao Borderô";
			this.Load += new System.EventHandler(this.frmFProdutosBorderoAssociarTaxaCambio_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulário
				private void frmFProdutosBorderoAssociarTaxaCambio_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vRefreshValorMaxFatura();
					vRefreshValorTaxaCambial();
				}
			#endregion
			#region TextBoxes
				private void m_txtValorFatura_TextChanged(object sender, System.EventArgs e)
				{
					if (m_txtValorFatura.Text != "")
						m_dcValor = mdlMoeda.clsMoeda.dcReturnValueFromCurrencyFormated(0,m_txtValorFatura.Text);
					else
						m_dcValor = 0;
					vRefreshValorMaxContrato();
				}

				private void m_txtTaxaCambio_TextChanged(object sender, System.EventArgs e)
				{
					if (m_txtTaxaCambio.Text != "")
						m_dcTaxaCambial = mdlMoeda.clsMoeda.dcReturnValueFromCurrencyFormated(0,m_txtTaxaCambio.Text);
					else
						m_dcTaxaCambial = 0;
					vRefreshValorMaxContrato();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					// Valor Igual Zero
					if (m_dcValor == 0)
					{
						vRefreshValorMaxFatura();
					}else{
						// Taxa Cambial igual Zero
						if (m_dcTaxaCambial == 0)
						{
							vRefreshValorTaxaCambial();
						}else{
							if (bCalculaTaxaCambial())
							{
								m_bModificado = true;
								this.Close();
							}
						}
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
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

		#region Refresh
			private void vRefreshValorMaxFatura()
			{
				m_txtValorFatura.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(0,m_dcValorMaxFatura,false);
				m_txtValorFatura.SelectAll();
			}

			private void vRefreshValorTaxaCambial()
			{
				m_txtTaxaCambio.Text = "0,00";
				vRefreshValorMaxContrato();
			}

			private void vRefreshValorMaxContrato()
			{
				m_txtValorContrato.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoedaContrato,m_dcValor * m_dcTaxaCambial,false);
			}
		#endregion
		#region Calculo
			private bool bCalculaTaxaCambial()
			{
				bool bRetorno = false;
				decimal dcValor = (m_dcValor * m_dcTaxaCambial);
				dcValor = dcValor - m_dcValorMaxContrato;
				if (dcValor > 0)
				{
					dcValor = dcValor / m_dcTaxaCambial;
					m_dcValor = m_dcValor - dcValor;
					dcValor = m_dcValor - System.Math.Round(m_dcValor,2);
					if (dcValor != 0)
					{
						m_dcTaxaCambial = ((m_dcValor * m_dcTaxaCambial) / System.Math.Round(m_dcValor,2));
						m_dcValor = System.Math.Round(m_dcValor,2);
					} 
				}
				bRetorno = true;
				return(bRetorno);
			}
		#endregion

		#region Retorno 
			public void vRetornaValores(out decimal dcValor,out decimal dcTaxaCambial)
			{
				dcValor = m_dcValor;
				dcTaxaCambial = m_dcTaxaCambial;
			}
		#endregion
	}
}
