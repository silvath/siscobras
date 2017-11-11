using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosCertificadoOrigem.Formularios
{
	/// <summary>
	/// Summary description for frmFProdutoPropriedades.
	/// </summary>
	public class frmFProdutoPropriedades : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(int nIdProduto, out string strDescricao,out bool bPossuiMaterialImportado,out double dPorcentagemValorNacional);
			public delegate bool delCallSalvaDados(int nIdProduto,bool bPossuiMaterialImportado,double dPorcentagemValorNacional);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					string strDescricao = "";
					bool bPossuiMaterialImportado = false;
					double dPorcentagemValorNacional = 0;
					eCallCarregaDados(m_nIdProduto,out strDescricao,out bPossuiMaterialImportado,out dPorcentagemValorNacional);
					m_txtDescricao.Text = strDescricao;
					m_rdbtSim.Checked = bPossuiMaterialImportado;
					m_rdbtNao.Checked = !bPossuiMaterialImportado;
					m_txtPercentagem.Text = dPorcentagemValorNacional.ToString();
				}
			}

			protected bool OnCallSalvaDados()
			{
				if (eCallSalvaDados == null)
					return(false);
				double dPorcentagemValorNacional = 0;
				try
				{
					dPorcentagemValorNacional = double.Parse(m_txtPercentagem.Text);
				}catch{
					mdlMensagens.clsMensagens.Show("O valor da percentagem deve estar preenchido corretamente.");
					return(false);
				}
				return(eCallSalvaDados(m_nIdProduto,m_rdbtSim.Checked,dPorcentagemValorNacional));
			}
		#endregion

		#region Atributes
			private int m_nIdProduto = -1;

			private bool m_bConfirmed = false;	
			
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Label m_lbDescricao;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.RadioButton m_rdbtSim;
			private System.Windows.Forms.RadioButton m_rdbtNao;
			private System.Windows.Forms.TextBox m_txtDescricao;
			private System.Windows.Forms.GroupBox m_gbNacionalidade;
			private System.Windows.Forms.Label m_lbProdutoNacional1;
			private mdlComponentesGraficos.TextBox m_txtPercentagem;
			private System.Windows.Forms.Label m_lbProdutoNacional2;
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
			public frmFProdutoPropriedades(string strEnderecoExecutavel,int nIdProduto)
			{
				m_nIdProduto = nIdProduto;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProdutoPropriedades));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbNacionalidade = new System.Windows.Forms.GroupBox();
			this.m_lbProdutoNacional2 = new System.Windows.Forms.Label();
			this.m_txtPercentagem = new mdlComponentesGraficos.TextBox();
			this.m_lbProdutoNacional1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rdbtNao = new System.Windows.Forms.RadioButton();
			this.m_rdbtSim = new System.Windows.Forms.RadioButton();
			this.m_txtDescricao = new System.Windows.Forms.TextBox();
			this.m_lbDescricao = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbNacionalidade.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbNacionalidade);
			this.m_gbMain.Controls.Add(this.groupBox1);
			this.m_gbMain.Controls.Add(this.m_txtDescricao);
			this.m_gbMain.Controls.Add(this.m_lbDescricao);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(3, 1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(588, 180);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbNacionalidade
			// 
			this.m_gbNacionalidade.Controls.Add(this.m_lbProdutoNacional2);
			this.m_gbNacionalidade.Controls.Add(this.m_txtPercentagem);
			this.m_gbNacionalidade.Controls.Add(this.m_lbProdutoNacional1);
			this.m_gbNacionalidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbNacionalidade.Location = new System.Drawing.Point(8, 95);
			this.m_gbNacionalidade.Name = "m_gbNacionalidade";
			this.m_gbNacionalidade.Size = new System.Drawing.Size(576, 48);
			this.m_gbNacionalidade.TabIndex = 19;
			this.m_gbNacionalidade.TabStop = false;
			this.m_gbNacionalidade.Text = "Composição do Produto";
			// 
			// m_lbProdutoNacional2
			// 
			this.m_lbProdutoNacional2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProdutoNacional2.Location = new System.Drawing.Point(221, 18);
			this.m_lbProdutoNacional2.Name = "m_lbProdutoNacional2";
			this.m_lbProdutoNacional2.Size = new System.Drawing.Size(167, 16);
			this.m_lbProdutoNacional2.TabIndex = 2;
			this.m_lbProdutoNacional2.Text = "% de material nacional.";
			// 
			// m_txtPercentagem
			// 
			this.m_txtPercentagem.Location = new System.Drawing.Point(171, 15);
			this.m_txtPercentagem.MaxDecimalNumbers = 2;
			this.m_txtPercentagem.Name = "m_txtPercentagem";
			this.m_txtPercentagem.OnlyNumbers = true;
			this.m_txtPercentagem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtPercentagem.Size = new System.Drawing.Size(45, 20);
			this.m_txtPercentagem.TabIndex = 1;
			this.m_txtPercentagem.Text = "100";
			// 
			// m_lbProdutoNacional1
			// 
			this.m_lbProdutoNacional1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbProdutoNacional1.Location = new System.Drawing.Point(9, 18);
			this.m_lbProdutoNacional1.Name = "m_lbProdutoNacional1";
			this.m_lbProdutoNacional1.Size = new System.Drawing.Size(167, 16);
			this.m_lbProdutoNacional1.TabIndex = 0;
			this.m_lbProdutoNacional1.Text = "Este produto é composto de ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_rdbtNao);
			this.groupBox1.Controls.Add(this.m_rdbtSim);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(7, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(577, 58);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Este produto foi produzido utilizando material importado ?";
			// 
			// m_rdbtNao
			// 
			this.m_rdbtNao.Location = new System.Drawing.Point(8, 32);
			this.m_rdbtNao.Name = "m_rdbtNao";
			this.m_rdbtNao.Size = new System.Drawing.Size(152, 16);
			this.m_rdbtNao.TabIndex = 1;
			this.m_rdbtNao.Text = "Não";
			// 
			// m_rdbtSim
			// 
			this.m_rdbtSim.Location = new System.Drawing.Point(8, 16);
			this.m_rdbtSim.Name = "m_rdbtSim";
			this.m_rdbtSim.Size = new System.Drawing.Size(152, 16);
			this.m_rdbtSim.TabIndex = 0;
			this.m_rdbtSim.Text = "Sim";
			this.m_rdbtSim.CheckedChanged += new System.EventHandler(this.m_rdbtSim_CheckedChanged);
			// 
			// m_txtDescricao
			// 
			this.m_txtDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDescricao.Location = new System.Drawing.Point(73, 12);
			this.m_txtDescricao.Name = "m_txtDescricao";
			this.m_txtDescricao.ReadOnly = true;
			this.m_txtDescricao.Size = new System.Drawing.Size(510, 20);
			this.m_txtDescricao.TabIndex = 17;
			this.m_txtDescricao.Text = "";
			// 
			// m_lbDescricao
			// 
			this.m_lbDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDescricao.Location = new System.Drawing.Point(8, 14);
			this.m_lbDescricao.Name = "m_lbDescricao";
			this.m_lbDescricao.Size = new System.Drawing.Size(64, 16);
			this.m_lbDescricao.TabIndex = 16;
			this.m_lbDescricao.Text = "Descrição:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(232, 146);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 14;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(296, 146);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 15;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFProdutoPropriedades
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 184);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProdutoPropriedades";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Propriedades do Produto";
			this.Load += new System.EventHandler(this.frmFProdutoPropriedades_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbNacionalidade.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Form
				private void frmFProdutoPropriedades_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDados();
					RefreshInterface();
				}
			#endregion
			#region RadioButtons
				private void m_rdbtSim_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}
			#endregion
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (OnCallSalvaDados())
					{
						m_bConfirmed = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
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

		#region Refresh
			private void RefreshInterface()
			{
				m_gbNacionalidade.Enabled = m_rdbtSim.Checked;
				if (!m_rdbtSim.Checked)
				{
					m_txtPercentagem.Text = "100";	
				}
			}
		#endregion
	}
}
