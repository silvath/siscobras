using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosBordero
{
	/// <summary>
	/// Summary description for frmFProdutosBorderoAssociar.
	/// </summary>
	public class frmFProdutosBorderoAssociar : System.Windows.Forms.Form
	{
		#region Atributos
			private string m_strEnderecoExecutavel = "";
			private int m_nIdContratoCambio = -1;
			private int m_nMoeda = -1;
			private decimal m_dcValorMax = 0;
			private decimal m_dcValor = 0;
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Label m_lbValor;
			private mdlComponentesGraficos.TextBox m_txtValor;
			private System.Windows.Forms.Label m_lbSimboloMoeda;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFProdutosBorderoAssociar(string strEnderecoExecutavel,int nIdContratoCambio,int nMoeda,string strSimboloMoeda,decimal dcValorMax)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nMoeda = nMoeda;
				m_nIdContratoCambio = nIdContratoCambio;
				m_dcValorMax = dcValorMax;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();
				m_lbSimboloMoeda.Text = strSimboloMoeda;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutosBorderoAssociar));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lbSimboloMoeda = new System.Windows.Forms.Label();
			this.m_txtValor = new mdlComponentesGraficos.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lbSimboloMoeda);
			this.m_gbGeral.Controls.Add(this.m_txtValor);
			this.m_gbGeral.Controls.Add(this.m_lbValor);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 73);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbSimboloMoeda
			// 
			this.m_lbSimboloMoeda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSimboloMoeda.Location = new System.Drawing.Point(100, 20);
			this.m_lbSimboloMoeda.Name = "m_lbSimboloMoeda";
			this.m_lbSimboloMoeda.Size = new System.Drawing.Size(40, 16);
			this.m_lbSimboloMoeda.TabIndex = 14;
			this.m_lbSimboloMoeda.Text = "R$";
			this.m_lbSimboloMoeda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtValor
			// 
			this.m_txtValor.Location = new System.Drawing.Point(144, 16);
			this.m_txtValor.MaxDecimalNumbers = 2;
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.OnlyNumbers = true;
			this.m_txtValor.Size = new System.Drawing.Size(152, 20);
			this.m_txtValor.TabIndex = 1;
			this.m_txtValor.Text = "";
			this.m_txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbValor
			// 
			this.m_lbValor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbValor.Location = new System.Drawing.Point(11, 20);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(85, 16);
			this.m_lbValor.TabIndex = 12;
			this.m_lbValor.Text = "Valor Vincular:";
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(158, 42);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 3;
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
			this.m_btOk.Location = new System.Drawing.Point(94, 42);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 2;
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
			// frmFProdutosBorderoAssociar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 80);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutosBorderoAssociar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vincular Contrato Cambio ao Borderô";
			this.Load += new System.EventHandler(this.frmFProdutosBorderoAssociar_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFProdutosBorderoAssociar_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vRefreshValorMax();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_dcValor = mdlMoeda.clsMoeda.dcReturnValueFromCurrencyFormated(0,m_txtValor.Text);
					if (m_bModificado = (m_dcValor <= m_dcValorMax))
					{
						this.Close();
					}else{
						m_dcValor = 0;
						vRefreshValorMax();
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
			private void vRefreshValorMax()
			{
				m_txtValor.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(0,m_dcValorMax,false);
				m_txtValor.SelectAll();
			}
		#endregion

		#region Retorno 
			public void vRetornaValores(out decimal dcValor)
			{
				dcValor = m_dcValor;
			}
		#endregion

	}
}
