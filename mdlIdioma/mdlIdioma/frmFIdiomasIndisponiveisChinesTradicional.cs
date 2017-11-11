using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for frmFIdiomasIndisponiveisChinesTradicional.
	/// </summary>
	public class frmFIdiomasIndisponiveisChinesTradicional : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox m_gbWin2000;
		private System.Windows.Forms.GroupBox m_gbSO;
		private System.Windows.Forms.GroupBox m_gbOutros;
		private System.Windows.Forms.Label m_lbOutrosInfo;
		private System.Windows.Forms.Label m_lbWin2000Info1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFIdiomasIndisponiveisChinesTradicional(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFIdiomasIndisponiveisChinesTradicional));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gbWin2000 = new System.Windows.Forms.GroupBox();
			this.m_gbSO = new System.Windows.Forms.GroupBox();
			this.m_gbOutros = new System.Windows.Forms.GroupBox();
			this.m_lbOutrosInfo = new System.Windows.Forms.Label();
			this.m_lbWin2000Info1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbWin2000.SuspendLayout();
			this.m_gbSO.SuspendLayout();
			this.m_gbOutros.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbSO);
			this.m_gbGeral.Controls.Add(this.m_gbInformacoes);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(388, 288);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(166, 257);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 10;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Controls.Add(this.label1);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.Location = new System.Drawing.Point(6, 9);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.Size = new System.Drawing.Size(378, 79);
			this.m_gbInformacoes.TabIndex = 11;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Informações";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(368, 54);
			this.label1.TabIndex = 0;
			this.label1.Text = "O seu sistema operacional não possui suporte, no momento, para a utilizacão dos i" +
				"deogramas do idioma Chines Simplificado. Para instalar o suporte ao idioma menci" +
				"onado siga os passos descritos abaixo segundo o seu sistema operacional.";
			// 
			// m_gbWin2000
			// 
			this.m_gbWin2000.Controls.Add(this.label7);
			this.m_gbWin2000.Controls.Add(this.label6);
			this.m_gbWin2000.Controls.Add(this.label5);
			this.m_gbWin2000.Controls.Add(this.label4);
			this.m_gbWin2000.Controls.Add(this.label3);
			this.m_gbWin2000.Controls.Add(this.label2);
			this.m_gbWin2000.Controls.Add(this.m_lbWin2000Info1);
			this.m_gbWin2000.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbWin2000.Location = new System.Drawing.Point(5, 12);
			this.m_gbWin2000.Name = "m_gbWin2000";
			this.m_gbWin2000.Size = new System.Drawing.Size(371, 118);
			this.m_gbWin2000.TabIndex = 12;
			this.m_gbWin2000.TabStop = false;
			this.m_gbWin2000.Text = "Windows 2000";
			// 
			// m_gbSO
			// 
			this.m_gbSO.Controls.Add(this.m_gbOutros);
			this.m_gbSO.Controls.Add(this.m_gbWin2000);
			this.m_gbSO.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbSO.Location = new System.Drawing.Point(5, 88);
			this.m_gbSO.Name = "m_gbSO";
			this.m_gbSO.Size = new System.Drawing.Size(379, 168);
			this.m_gbSO.TabIndex = 13;
			this.m_gbSO.TabStop = false;
			this.m_gbSO.Text = "Sistemas Operacionais";
			// 
			// m_gbOutros
			// 
			this.m_gbOutros.Controls.Add(this.m_lbOutrosInfo);
			this.m_gbOutros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbOutros.Location = new System.Drawing.Point(4, 129);
			this.m_gbOutros.Name = "m_gbOutros";
			this.m_gbOutros.Size = new System.Drawing.Size(368, 36);
			this.m_gbOutros.TabIndex = 13;
			this.m_gbOutros.TabStop = false;
			this.m_gbOutros.Text = "Outros ";
			// 
			// m_lbOutrosInfo
			// 
			this.m_lbOutrosInfo.Location = new System.Drawing.Point(6, 16);
			this.m_lbOutrosInfo.Name = "m_lbOutrosInfo";
			this.m_lbOutrosInfo.Size = new System.Drawing.Size(352, 16);
			this.m_lbOutrosInfo.TabIndex = 1;
			this.m_lbOutrosInfo.Text = "Idioma não suportado no sistema operacional ou desconhecido";
			// 
			// m_lbWin2000Info1
			// 
			this.m_lbWin2000Info1.Location = new System.Drawing.Point(9, 13);
			this.m_lbWin2000Info1.Name = "m_lbWin2000Info1";
			this.m_lbWin2000Info1.Size = new System.Drawing.Size(352, 16);
			this.m_lbWin2000Info1.TabIndex = 2;
			this.m_lbWin2000Info1.Text = "Passos                                        ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "1. Painel de Controle";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(352, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "2. Opções regionais e de Idioma";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(352, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "4. Suporte a idioma suplementar.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(10, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(352, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "3. Idiomas";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(29, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(311, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "a. Instalar arquivos para idiomas de escrita complexa.";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(30, 99);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(290, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "b. Instalar arquivos para idiomas do Leste Asiático.";
			// 
			// frmFIdiomasIndisponiveisChinesTradicional
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(394, 288);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFIdiomasIndisponiveisChinesTradicional";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chinês Simplificado";
			this.Load += new System.EventHandler(this.frmFIdiomasIndisponiveisChinesTradicional_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbWin2000.ResumeLayout(false);
			this.m_gbSO.ResumeLayout(false);
			this.m_gbOutros.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFIdiomasIndisponiveisChinesTradicional_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
				}
			#endregion
			#region Botoes
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
					case "System.Windows.Forms.ListView":
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
