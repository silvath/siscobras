using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlIncoterm
{
	/// <summary>
	/// Summary description for frmFValorSaque.
	/// </summary>
	internal class frmFValorSaque : System.Windows.Forms.Form
	{
		#region Atributes
		private bool m_bModificado = false;
		private string m_strEnderecoExecutavel = "";

		private System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbValor;
		private mdlComponentesGraficos.TextBox m_txtValorFatura;
		private System.Windows.Forms.ToolTip m_ttDicas;
		private System.Windows.Forms.Label m_lbAntecipado;
		private mdlComponentesGraficos.TextBox m_txtValorAntecipado;
		private mdlComponentesGraficos.TextBox m_txtValorSaque;
		private System.Windows.Forms.Label m_lbSaque;
		private System.Windows.Forms.Label m_lbMoedaSaque;
		private System.Windows.Forms.Label m_lbFatura;
		private System.Windows.Forms.Label m_lbMoedaFatura;
		private System.Windows.Forms.Label m_lbMoedaAntecipado;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
		public bool Modified
		{
			get
			{
				return(m_bModificado);
			}
		}
		#endregion
		#region Constructors and Destructors
		public frmFValorSaque(string strEnderecoExecutavel,string strSimboloMoeda,double dValorFatura,double dValorAntecipado,double dValorSaque)
		{
			InitializeComponent();
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_lbMoedaFatura.Text = strSimboloMoeda;
			m_lbMoedaAntecipado.Text = strSimboloMoeda;
			m_lbMoedaSaque.Text = strSimboloMoeda;
			m_txtValorFatura.Text = dValorFatura.ToString("F");
			m_txtValorAntecipado.Text = dValorAntecipado.ToString("F");
			m_txtValorSaque.Text = dValorSaque.ToString("F");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFValorSaque));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbValor = new System.Windows.Forms.GroupBox();
			this.m_lbAntecipado = new System.Windows.Forms.Label();
			this.m_txtValorAntecipado = new mdlComponentesGraficos.TextBox();
			this.m_txtValorSaque = new mdlComponentesGraficos.TextBox();
			this.m_lbSaque = new System.Windows.Forms.Label();
			this.m_lbMoedaSaque = new System.Windows.Forms.Label();
			this.m_txtValorFatura = new mdlComponentesGraficos.TextBox();
			this.m_lbFatura = new System.Windows.Forms.Label();
			this.m_lbMoedaFatura = new System.Windows.Forms.Label();
			this.m_lbMoedaAntecipado = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbValor.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbValor);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(6, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(213, 127);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbValor
			// 
			this.m_gbValor.Controls.Add(this.m_lbAntecipado);
			this.m_gbValor.Controls.Add(this.m_txtValorAntecipado);
			this.m_gbValor.Controls.Add(this.m_txtValorSaque);
			this.m_gbValor.Controls.Add(this.m_lbSaque);
			this.m_gbValor.Controls.Add(this.m_lbMoedaSaque);
			this.m_gbValor.Controls.Add(this.m_txtValorFatura);
			this.m_gbValor.Controls.Add(this.m_lbFatura);
			this.m_gbValor.Controls.Add(this.m_lbMoedaFatura);
			this.m_gbValor.Controls.Add(this.m_lbMoedaAntecipado);
			this.m_gbValor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbValor.Location = new System.Drawing.Point(5, 7);
			this.m_gbValor.Name = "m_gbValor";
			this.m_gbValor.Size = new System.Drawing.Size(203, 89);
			this.m_gbValor.TabIndex = 22;
			this.m_gbValor.TabStop = false;
			this.m_gbValor.Text = "Valor";
			// 
			// m_lbAntecipado
			// 
			this.m_lbAntecipado.Location = new System.Drawing.Point(8, 37);
			this.m_lbAntecipado.Name = "m_lbAntecipado";
			this.m_lbAntecipado.Size = new System.Drawing.Size(72, 16);
			this.m_lbAntecipado.TabIndex = 28;
			this.m_lbAntecipado.Text = "Antecipado:";
			// 
			// m_txtValorAntecipado
			// 
			this.m_txtValorAntecipado.Location = new System.Drawing.Point(120, 36);
			this.m_txtValorAntecipado.Name = "m_txtValorAntecipado";
			this.m_txtValorAntecipado.OnlyNumbers = true;
			this.m_txtValorAntecipado.ReadOnly = true;
			this.m_txtValorAntecipado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtValorAntecipado.Size = new System.Drawing.Size(72, 20);
			this.m_txtValorAntecipado.TabIndex = 27;
			this.m_txtValorAntecipado.Text = "0";
			// 
			// m_txtValorSaque
			// 
			this.m_txtValorSaque.Location = new System.Drawing.Point(119, 58);
			this.m_txtValorSaque.MaxDecimalNumbers = 2;
			this.m_txtValorSaque.Name = "m_txtValorSaque";
			this.m_txtValorSaque.OnlyNumbers = true;
			this.m_txtValorSaque.Size = new System.Drawing.Size(73, 20);
			this.m_txtValorSaque.TabIndex = 25;
			this.m_txtValorSaque.Text = "0";
			this.m_txtValorSaque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbSaque
			// 
			this.m_lbSaque.Location = new System.Drawing.Point(8, 60);
			this.m_lbSaque.Name = "m_lbSaque";
			this.m_lbSaque.Size = new System.Drawing.Size(48, 16);
			this.m_lbSaque.TabIndex = 24;
			this.m_lbSaque.Text = "Saque:";
			// 
			// m_lbMoedaSaque
			// 
			this.m_lbMoedaSaque.Location = new System.Drawing.Point(87, 59);
			this.m_lbMoedaSaque.Name = "m_lbMoedaSaque";
			this.m_lbMoedaSaque.Size = new System.Drawing.Size(32, 16);
			this.m_lbMoedaSaque.TabIndex = 26;
			this.m_lbMoedaSaque.Text = "US$";
			this.m_lbMoedaSaque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtValorFatura
			// 
			this.m_txtValorFatura.Location = new System.Drawing.Point(120, 12);
			this.m_txtValorFatura.Name = "m_txtValorFatura";
			this.m_txtValorFatura.OnlyNumbers = true;
			this.m_txtValorFatura.ReadOnly = true;
			this.m_txtValorFatura.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtValorFatura.Size = new System.Drawing.Size(72, 20);
			this.m_txtValorFatura.TabIndex = 22;
			this.m_txtValorFatura.Text = "0";
			// 
			// m_lbFatura
			// 
			this.m_lbFatura.Location = new System.Drawing.Point(8, 18);
			this.m_lbFatura.Name = "m_lbFatura";
			this.m_lbFatura.Size = new System.Drawing.Size(48, 16);
			this.m_lbFatura.TabIndex = 21;
			this.m_lbFatura.Text = "Fatura:";
			// 
			// m_lbMoedaFatura
			// 
			this.m_lbMoedaFatura.Location = new System.Drawing.Point(87, 15);
			this.m_lbMoedaFatura.Name = "m_lbMoedaFatura";
			this.m_lbMoedaFatura.Size = new System.Drawing.Size(32, 16);
			this.m_lbMoedaFatura.TabIndex = 23;
			this.m_lbMoedaFatura.Text = "US$";
			this.m_lbMoedaFatura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lbMoedaAntecipado
			// 
			this.m_lbMoedaAntecipado.Location = new System.Drawing.Point(87, 37);
			this.m_lbMoedaAntecipado.Name = "m_lbMoedaAntecipado";
			this.m_lbMoedaAntecipado.Size = new System.Drawing.Size(32, 16);
			this.m_lbMoedaAntecipado.TabIndex = 29;
			this.m_lbMoedaAntecipado.Text = "US$";
			this.m_lbMoedaAntecipado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(50, 98);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 19;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(114, 98);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 20;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFValorSaque
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 127);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFValorSaque";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurações";
			this.Load += new System.EventHandler(this.frmFConfiguracoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbValor.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		#region Formulario
		private void frmFConfiguracoes_Load(object sender, System.EventArgs e)
		{
			vMostraCor();
		}
		#endregion
		#region Buttons
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.m_bModificado = true;
			this.Close();
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

		#region Retorno 
			public void vRetornaValores(out double dValorSaque)
			{
				dValorSaque = 0;
				if (m_txtValorSaque.Text.Trim() != "")
					dValorSaque = double.Parse(m_txtValorSaque.Text);
			}
		#endregion
	}
}
