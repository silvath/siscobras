using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosCertificadosOrigem
{
	/// <summary>
	/// Summary description for frmFConfiguracoes.
	/// </summary>
	public class frmFConfiguracoes : System.Windows.Forms.Form
	{
		#region Atributes
			private bool m_bModificado = false;

			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbApresentar;
			private System.Windows.Forms.CheckBox m_ckDetalhesProdutosFilhos;
			private System.Windows.Forms.CheckBox m_ckDetalhesProdutos;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public bool MostrarProdutos
			{
				set
				{
					m_ckDetalhesProdutos.Checked = value;
					if (!m_ckDetalhesProdutos.Checked)
						m_ckDetalhesProdutosFilhos.Enabled = m_ckDetalhesProdutosFilhos.Checked = false;
					else
						m_ckDetalhesProdutosFilhos.Enabled = true;
				}
				get
				{
					return(m_ckDetalhesProdutos.Checked);
				}
			}

			public bool MostrarProdutosFilhos
			{
				set
				{
					m_ckDetalhesProdutosFilhos.Checked = value;
				}
				get
				{
					return(m_ckDetalhesProdutosFilhos.Checked);
				}
			}
		#endregion
		#region Constructor
			public frmFConfiguracoes(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConfiguracoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbApresentar = new System.Windows.Forms.GroupBox();
			this.m_ckDetalhesProdutos = new System.Windows.Forms.CheckBox();
			this.m_ckDetalhesProdutosFilhos = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbApresentar.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbApresentar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(4, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(178, 98);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbApresentar
			// 
			this.m_gbApresentar.Controls.Add(this.m_ckDetalhesProdutos);
			this.m_gbApresentar.Controls.Add(this.m_ckDetalhesProdutosFilhos);
			this.m_gbApresentar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbApresentar.Location = new System.Drawing.Point(9, 7);
			this.m_gbApresentar.Name = "m_gbApresentar";
			this.m_gbApresentar.Size = new System.Drawing.Size(162, 56);
			this.m_gbApresentar.TabIndex = 23;
			this.m_gbApresentar.TabStop = false;
			this.m_gbApresentar.Text = "Detalhar";
			// 
			// m_ckDetalhesProdutos
			// 
			this.m_ckDetalhesProdutos.Location = new System.Drawing.Point(6, 15);
			this.m_ckDetalhesProdutos.Name = "m_ckDetalhesProdutos";
			this.m_ckDetalhesProdutos.Size = new System.Drawing.Size(151, 16);
			this.m_ckDetalhesProdutos.TabIndex = 1;
			this.m_ckDetalhesProdutos.Text = "Produtos";
			this.m_ckDetalhesProdutos.CheckedChanged += new System.EventHandler(this.m_ckDetalhesProdutos_CheckedChanged);
			// 
			// m_ckDetalhesProdutosFilhos
			// 
			this.m_ckDetalhesProdutosFilhos.Location = new System.Drawing.Point(6, 31);
			this.m_ckDetalhesProdutosFilhos.Name = "m_ckDetalhesProdutosFilhos";
			this.m_ckDetalhesProdutosFilhos.Size = new System.Drawing.Size(151, 16);
			this.m_ckDetalhesProdutosFilhos.TabIndex = 0;
			this.m_ckDetalhesProdutosFilhos.Text = "Produtos filhos";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(30, 68);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 21;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(94, 68);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 22;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFConfiguracoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(186, 99);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConfiguracoes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurações";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbApresentar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region CheckBoxes
				private void m_ckDetalhesProdutos_CheckedChanged(object sender, System.EventArgs e)
				{
					this.MostrarProdutos = m_ckDetalhesProdutos.Checked;
				}
			#endregion
			#region Botoes
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
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
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
