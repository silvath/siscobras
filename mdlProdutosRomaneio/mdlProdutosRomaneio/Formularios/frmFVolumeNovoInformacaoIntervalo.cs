using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFVolumeNovoInformacaoIntervalo.
	/// </summary>
	internal class frmFVolumeNovoInformacaoIntervalo : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private string m_strIntervalo = "";
			private string m_strPrefixo = "";
			private string m_strSufixo = "";
			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Label m_lbInfoIntervalos;
			private System.Windows.Forms.GroupBox m_gbExemplos;
			private System.Windows.Forms.GroupBox m_gbTeste;
			private mdlComponentesGraficos.TextBox m_txtIntervalo;
			private mdlComponentesGraficos.TextBox m_txtIgual;
			private System.Windows.Forms.Label m_lbTeste;
			private System.Windows.Forms.Label m_lbIgual;
			private System.Windows.Forms.Label m_lbIntervalo;
			private System.Windows.Forms.Label m_lbTeste4;
			private System.Windows.Forms.Label m_lbTeste1;
			private System.Windows.Forms.Label m_lbTeste3;
			private System.Windows.Forms.Label m_lbTeste2;
		private mdlComponentesGraficos.TextBox m_txtPrefixo;
		private System.Windows.Forms.Label m_lbPrefixo;
		private mdlComponentesGraficos.TextBox m_txtSufixo;
		private System.Windows.Forms.Label m_lbSufixo;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFVolumeNovoInformacaoIntervalo(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeNovoInformacaoIntervalo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lbTeste = new System.Windows.Forms.Label();
			this.m_gbTeste = new System.Windows.Forms.GroupBox();
			this.m_txtSufixo = new mdlComponentesGraficos.TextBox();
			this.m_lbSufixo = new System.Windows.Forms.Label();
			this.m_txtPrefixo = new mdlComponentesGraficos.TextBox();
			this.m_lbPrefixo = new System.Windows.Forms.Label();
			this.m_txtIgual = new mdlComponentesGraficos.TextBox();
			this.m_lbIgual = new System.Windows.Forms.Label();
			this.m_txtIntervalo = new mdlComponentesGraficos.TextBox();
			this.m_lbIntervalo = new System.Windows.Forms.Label();
			this.m_gbExemplos = new System.Windows.Forms.GroupBox();
			this.m_lbTeste4 = new System.Windows.Forms.Label();
			this.m_lbTeste1 = new System.Windows.Forms.Label();
			this.m_lbTeste3 = new System.Windows.Forms.Label();
			this.m_lbTeste2 = new System.Windows.Forms.Label();
			this.m_lbInfoIntervalos = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbTeste.SuspendLayout();
			this.m_gbExemplos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_lbTeste);
			this.m_gbGeral.Controls.Add(this.m_gbTeste);
			this.m_gbGeral.Controls.Add(this.m_gbExemplos);
			this.m_gbGeral.Controls.Add(this.m_lbInfoIntervalos);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(221, 337);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbTeste
			// 
			this.m_lbTeste.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTeste.Location = new System.Drawing.Point(16, 143);
			this.m_lbTeste.Name = "m_lbTeste";
			this.m_lbTeste.Size = new System.Drawing.Size(197, 32);
			this.m_lbTeste.TabIndex = 72;
			this.m_lbTeste.Text = "Pratique aqui os intervalos caso ainda tenha dúvidas.";
			// 
			// m_gbTeste
			// 
			this.m_gbTeste.Controls.Add(this.m_txtSufixo);
			this.m_gbTeste.Controls.Add(this.m_lbSufixo);
			this.m_gbTeste.Controls.Add(this.m_txtPrefixo);
			this.m_gbTeste.Controls.Add(this.m_lbPrefixo);
			this.m_gbTeste.Controls.Add(this.m_txtIgual);
			this.m_gbTeste.Controls.Add(this.m_lbIgual);
			this.m_gbTeste.Controls.Add(this.m_txtIntervalo);
			this.m_gbTeste.Controls.Add(this.m_lbIntervalo);
			this.m_gbTeste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTeste.Location = new System.Drawing.Point(8, 175);
			this.m_gbTeste.Name = "m_gbTeste";
			this.m_gbTeste.Size = new System.Drawing.Size(208, 121);
			this.m_gbTeste.TabIndex = 1;
			this.m_gbTeste.TabStop = false;
			this.m_gbTeste.Text = "Teste";
			// 
			// m_txtSufixo
			// 
			this.m_txtSufixo.Location = new System.Drawing.Point(72, 64);
			this.m_txtSufixo.Name = "m_txtSufixo";
			this.m_txtSufixo.Size = new System.Drawing.Size(128, 20);
			this.m_txtSufixo.TabIndex = 7;
			this.m_txtSufixo.Text = "";
			this.m_txtSufixo.TextChanged += new System.EventHandler(this.m_txtSufixo_TextChanged);
			// 
			// m_lbSufixo
			// 
			this.m_lbSufixo.Location = new System.Drawing.Point(3, 67);
			this.m_lbSufixo.Name = "m_lbSufixo";
			this.m_lbSufixo.Size = new System.Drawing.Size(56, 16);
			this.m_lbSufixo.TabIndex = 6;
			this.m_lbSufixo.Text = "Sufixo:";
			// 
			// m_txtPrefixo
			// 
			this.m_txtPrefixo.Location = new System.Drawing.Point(72, 15);
			this.m_txtPrefixo.Name = "m_txtPrefixo";
			this.m_txtPrefixo.Size = new System.Drawing.Size(128, 20);
			this.m_txtPrefixo.TabIndex = 5;
			this.m_txtPrefixo.Text = "";
			this.m_txtPrefixo.TextChanged += new System.EventHandler(this.m_txtPrefixo_TextChanged);
			// 
			// m_lbPrefixo
			// 
			this.m_lbPrefixo.Location = new System.Drawing.Point(3, 19);
			this.m_lbPrefixo.Name = "m_lbPrefixo";
			this.m_lbPrefixo.Size = new System.Drawing.Size(56, 16);
			this.m_lbPrefixo.TabIndex = 4;
			this.m_lbPrefixo.Text = "Prefixo:";
			// 
			// m_txtIgual
			// 
			this.m_txtIgual.Location = new System.Drawing.Point(72, 94);
			this.m_txtIgual.Name = "m_txtIgual";
			this.m_txtIgual.ReadOnly = true;
			this.m_txtIgual.Size = new System.Drawing.Size(128, 20);
			this.m_txtIgual.TabIndex = 3;
			this.m_txtIgual.Text = "";
			// 
			// m_lbIgual
			// 
			this.m_lbIgual.Location = new System.Drawing.Point(4, 94);
			this.m_lbIgual.Name = "m_lbIgual";
			this.m_lbIgual.Size = new System.Drawing.Size(63, 16);
			this.m_lbIgual.TabIndex = 2;
			this.m_lbIgual.Text = "Resultado:";
			// 
			// m_txtIntervalo
			// 
			this.m_txtIntervalo.Location = new System.Drawing.Point(72, 40);
			this.m_txtIntervalo.Name = "m_txtIntervalo";
			this.m_txtIntervalo.Size = new System.Drawing.Size(128, 20);
			this.m_txtIntervalo.TabIndex = 2;
			this.m_txtIntervalo.Text = "";
			this.m_txtIntervalo.TextChanged += new System.EventHandler(this.m_txtIntervalo_TextChanged);
			// 
			// m_lbIntervalo
			// 
			this.m_lbIntervalo.Location = new System.Drawing.Point(2, 44);
			this.m_lbIntervalo.Name = "m_lbIntervalo";
			this.m_lbIntervalo.Size = new System.Drawing.Size(56, 16);
			this.m_lbIntervalo.TabIndex = 0;
			this.m_lbIntervalo.Text = "Intervalo:";
			// 
			// m_gbExemplos
			// 
			this.m_gbExemplos.Controls.Add(this.m_lbTeste4);
			this.m_gbExemplos.Controls.Add(this.m_lbTeste1);
			this.m_gbExemplos.Controls.Add(this.m_lbTeste3);
			this.m_gbExemplos.Controls.Add(this.m_lbTeste2);
			this.m_gbExemplos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbExemplos.Location = new System.Drawing.Point(8, 48);
			this.m_gbExemplos.Name = "m_gbExemplos";
			this.m_gbExemplos.Size = new System.Drawing.Size(208, 88);
			this.m_gbExemplos.TabIndex = 70;
			this.m_gbExemplos.TabStop = false;
			this.m_gbExemplos.Text = "Exemplos";
			// 
			// m_lbTeste4
			// 
			this.m_lbTeste4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTeste4.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTeste4.Location = new System.Drawing.Point(8, 65);
			this.m_lbTeste4.Name = "m_lbTeste4";
			this.m_lbTeste4.Size = new System.Drawing.Size(192, 16);
			this.m_lbTeste4.TabIndex = 3;
			this.m_lbTeste4.Text = "1-3;7;10-13 = 1,2,3,7,10,11,12,13";
			// 
			// m_lbTeste1
			// 
			this.m_lbTeste1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTeste1.Location = new System.Drawing.Point(7, 16);
			this.m_lbTeste1.Name = "m_lbTeste1";
			this.m_lbTeste1.Size = new System.Drawing.Size(176, 16);
			this.m_lbTeste1.TabIndex = 2;
			this.m_lbTeste1.Text = "1;2;5;6 = 1,2,5,6";
			// 
			// m_lbTeste3
			// 
			this.m_lbTeste3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTeste3.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTeste3.Location = new System.Drawing.Point(8, 48);
			this.m_lbTeste3.Name = "m_lbTeste3";
			this.m_lbTeste3.Size = new System.Drawing.Size(192, 16);
			this.m_lbTeste3.TabIndex = 1;
			this.m_lbTeste3.Text = "1;3-5  =  1,3,4,5";
			// 
			// m_lbTeste2
			// 
			this.m_lbTeste2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTeste2.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTeste2.Location = new System.Drawing.Point(8, 32);
			this.m_lbTeste2.Name = "m_lbTeste2";
			this.m_lbTeste2.Size = new System.Drawing.Size(192, 16);
			this.m_lbTeste2.TabIndex = 0;
			this.m_lbTeste2.Text = "1-5   =  1,2,3,4,5";
			// 
			// m_lbInfoIntervalos
			// 
			this.m_lbInfoIntervalos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfoIntervalos.Location = new System.Drawing.Point(9, 14);
			this.m_lbInfoIntervalos.Name = "m_lbInfoIntervalos";
			this.m_lbInfoIntervalos.Size = new System.Drawing.Size(197, 32);
			this.m_lbInfoIntervalos.TabIndex = 69;
			this.m_lbInfoIntervalos.Text = "Aprenda como funciona intervalos com os exemplos abaixo:";
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(81, 307);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFVolumeNovoInformacaoIntervalo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 344);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFVolumeNovoInformacaoIntervalo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Intervalos";
			this.Load += new System.EventHandler(this.frmFVolumeNovoInformacaoIntervalo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTeste.ResumeLayout(false);
			this.m_gbExemplos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFVolumeNovoInformacaoIntervalo_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
				}
			#endregion
			#region TextBoxes
				private void m_txtIntervalo_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshInterface();
				}

				private void m_txtPrefixo_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshInterface();
				}

				private void m_txtSufixo_TextChanged(object sender, System.EventArgs e)
				{
					vRefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					System.Collections.ArrayList arlIntervalos = clsProdutosRomaneio.arlRetornaIntervalo(m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text);
					if (arlIntervalos != null)
					{
						m_strIntervalo = m_txtIntervalo.Text;
						m_strPrefixo = m_txtPrefixo.Text;
						m_strSufixo = m_txtSufixo.Text;
					}
					this.Close();
				}
			#endregion
		#endregion

		#region Interface
			private void vRefreshInterface()
			{
				System.Collections.ArrayList arlIntervalos = clsProdutosRomaneio.arlRetornaIntervalo(m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text);
				if (arlIntervalos != null)
				{
					string strIgual = "";
					for (int i = 0; i < arlIntervalos.Count;i++)
					{
						if (strIgual != "")
							strIgual = strIgual +",";
						strIgual = strIgual + arlIntervalos[i].ToString();
					}
					m_txtIgual.Text = strIgual;
				}
				else
				{
					m_txtIgual.Text = "Inválido";
				}
			}
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
			public void vRetornaValores(out string strIntervalo,out string strPrefixo,out string strSufixo)
			{
                strIntervalo = m_strIntervalo;
				strPrefixo = m_strPrefixo;
				strSufixo = m_strSufixo;
			}
		#endregion
	}
}
