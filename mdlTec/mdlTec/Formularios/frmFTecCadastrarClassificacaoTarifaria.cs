using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTecCadastrarClassificacaoTarifaria.
	/// </summary>
	public class frmFTecCadastrarClassificacaoTarifaria : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.TextBox m_txtCodigo;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.TextBox m_txtDenominacao;
			private System.ComponentModel.Container components = null;

			private bool m_bConfirmado = false;
		#endregion
		#region Properties
			public bool Confirmado
			{
				get
				{
					return(m_bConfirmado);
				}
			}

			public string Codigo
			{
				get
				{
					return(m_txtCodigo.Text );
				}
			}

			public string Denominacao 
			{
				get
				{
					return(m_txtDenominacao.Text );
				}
			}

			public System.Drawing.Color Cor
			{
				set
				{
					vMostraCor(value);
				}
			}

		#endregion 
		#region Constructors
		public frmFTecCadastrarClassificacaoTarifaria(string strEnderecoExecutavel,string strCodigo,string strDenominacao)
		{
			InitializeComponent();
			vMostraCor(strEnderecoExecutavel);
			m_txtCodigo.Text = strCodigo.Substring(0,4) + "." + strCodigo.Substring(4,2) + "." + strCodigo.Substring(6,2);
			m_txtDenominacao.Text = strDenominacao;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTecCadastrarClassificacaoTarifaria));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtDenominacao = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.groupBox1);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(3, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(421, 217);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_txtDenominacao);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_txtCodigo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(7, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 178);
			this.groupBox1.TabIndex = 68;
			this.groupBox1.TabStop = false;
			// 
			// m_txtDenominacao
			// 
			this.m_txtDenominacao.Location = new System.Drawing.Point(8, 66);
			this.m_txtDenominacao.Multiline = true;
			this.m_txtDenominacao.Name = "m_txtDenominacao";
			this.m_txtDenominacao.Size = new System.Drawing.Size(392, 102);
			this.m_txtDenominacao.TabIndex = 3;
			this.m_txtDenominacao.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Denominação:";
			// 
			// m_txtCodigo
			// 
			this.m_txtCodigo.Location = new System.Drawing.Point(8, 28);
			this.m_txtCodigo.Name = "m_txtCodigo";
			this.m_txtCodigo.ReadOnly = true;
			this.m_txtCodigo.Size = new System.Drawing.Size(392, 20);
			this.m_txtCodigo.TabIndex = 1;
			this.m_txtCodigo.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(150, 185);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 66;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(214, 185);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 67;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFTecCadastrarClassificacaoTarifaria
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(426, 216);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTecCadastrarClassificacaoTarifaria";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastrar Classificacao Tarifária";
			this.m_gbMain.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(System.Drawing.Color color)
			{
				this.BackColor = color;
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

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
					case "System.Windows.Forms.TreeView":
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
	}
}

