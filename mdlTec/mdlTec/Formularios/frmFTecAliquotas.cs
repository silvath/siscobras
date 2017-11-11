using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTecAliquotas.
	/// </summary>
	public class frmFTecAliquotas : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate bool delCallCarregaDados(string strCodigo,out string strValorIPI,out System.DateTime dtInicioIPI,out System.DateTime dtFinalIPI,out string strValorII,out System.DateTime dtInicioII,out System.DateTime dtFinalII,out string strValorIIM,out System.DateTime dtInicioIIM,out System.DateTime dtFinalIIM);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
		#endregion
		#region Events Methods
			protected virtual bool OnCallCarregaDados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallCarregaDados != null)
				{
					string strValorIPI;
					System.DateTime dtInicioIPI;
					System.DateTime dtFinalIPI;
					string strValorII;
					System.DateTime dtInicioII;
					System.DateTime dtFinalII;
					string strValorIIM;
					System.DateTime dtInicioIIM;
					System.DateTime dtFinalIIM;
					bRetorno = eCallCarregaDados(m_strCodigo,out strValorIPI,out dtInicioIPI,out dtFinalIPI,out strValorII,out dtInicioII,out dtFinalII,out strValorIIM,out dtInicioIIM,out dtFinalIIM);
					m_txtIPIValor.Text = GetValor(strValorIPI);
					m_txtIPIInicio.Text = dtInicioIPI.ToString("dd/MMM/yyyy");
					m_txtIPIFinal.Text = dtFinalIPI.ToString("dd/MMM/yyyy");
					m_txtIIValor.Text = GetValor(strValorII);
					m_txtIIInicio.Text = dtInicioII.ToString("dd/MMM/yyyy");
					m_txtIIFinal.Text = dtFinalII.ToString("dd/MMM/yyyy");
					m_txtIIMValor.Text = GetValor(strValorIIM);
					m_txtIIMInicio.Text = dtInicioIIM.ToString("dd/MMM/yyyy");
					m_txtIIMFinal.Text = dtFinalIIM.ToString("dd/MMM/yyyy");
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private string m_strCodigo = "";

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.TextBox m_txtClassificacao;
		private System.Windows.Forms.GroupBox m_gbIPI;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtIPIValor;
		private System.Windows.Forms.TextBox m_txtIPIInicio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox m_gbImpostoImportacao;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox m_txtIPIFinal;
		private System.Windows.Forms.TextBox m_txtIIFinal;
		private System.Windows.Forms.TextBox m_txtIIInicio;
		private System.Windows.Forms.TextBox m_txtIIValor;
		private System.Windows.Forms.TextBox m_txtIIMFinal;
		private System.Windows.Forms.TextBox m_txtIIMInicio;
		private System.Windows.Forms.TextBox m_txtIIMValor;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public System.Drawing.Color Cor
			{
				set
				{
					vMostraCor(value);
				}
			}
		#endregion
		#region Constructors
			public frmFTecAliquotas(string strEnderecoExecutavel,string strCodigo,string strDescricao)
			{
				m_strCodigo = strCodigo;
				InitializeComponent();
				m_txtClassificacao.Text = strDescricao;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTecAliquotas));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_txtIIMFinal = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtIIMInicio = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.m_txtIIMValor = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.m_gbImpostoImportacao = new System.Windows.Forms.GroupBox();
			this.m_txtIIFinal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtIIInicio = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtIIValor = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_gbIPI = new System.Windows.Forms.GroupBox();
			this.m_txtIPIFinal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtIPIInicio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtIPIValor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtClassificacao = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gbMain.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.m_gbImpostoImportacao.SuspendLayout();
			this.m_gbIPI.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.groupBox2);
			this.m_gbMain.Controls.Add(this.m_gbImpostoImportacao);
			this.m_gbMain.Controls.Add(this.m_gbIPI);
			this.m_gbMain.Controls.Add(this.m_txtClassificacao);
			this.m_gbMain.Controls.Add(this.label1);
			this.m_gbMain.Location = new System.Drawing.Point(4, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(370, 142);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_txtIIMFinal);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.m_txtIIMInicio);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.m_txtIIMValor);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(367, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 96);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Imp. Importação Mercosul";
			this.groupBox2.Visible = false;
			// 
			// m_txtIIMFinal
			// 
			this.m_txtIIMFinal.Location = new System.Drawing.Point(56, 68);
			this.m_txtIIMFinal.Name = "m_txtIIMFinal";
			this.m_txtIIMFinal.ReadOnly = true;
			this.m_txtIIMFinal.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIMFinal.TabIndex = 5;
			this.m_txtIIMFinal.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 69);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 4;
			this.label8.Text = "Final:";
			// 
			// m_txtIIMInicio
			// 
			this.m_txtIIMInicio.Location = new System.Drawing.Point(56, 46);
			this.m_txtIIMInicio.Name = "m_txtIIMInicio";
			this.m_txtIIMInicio.ReadOnly = true;
			this.m_txtIIMInicio.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIMInicio.TabIndex = 3;
			this.m_txtIIMInicio.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(9, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 2;
			this.label9.Text = "Inicio:";
			// 
			// m_txtIIMValor
			// 
			this.m_txtIIMValor.Location = new System.Drawing.Point(56, 22);
			this.m_txtIIMValor.Name = "m_txtIIMValor";
			this.m_txtIIMValor.ReadOnly = true;
			this.m_txtIIMValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtIIMValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIMValor.TabIndex = 1;
			this.m_txtIIMValor.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 25);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 0;
			this.label10.Text = "Valor:";
			// 
			// m_gbImpostoImportacao
			// 
			this.m_gbImpostoImportacao.Controls.Add(this.m_txtIIFinal);
			this.m_gbImpostoImportacao.Controls.Add(this.label5);
			this.m_gbImpostoImportacao.Controls.Add(this.m_txtIIInicio);
			this.m_gbImpostoImportacao.Controls.Add(this.label6);
			this.m_gbImpostoImportacao.Controls.Add(this.m_txtIIValor);
			this.m_gbImpostoImportacao.Controls.Add(this.label7);
			this.m_gbImpostoImportacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbImpostoImportacao.Location = new System.Drawing.Point(8, 40);
			this.m_gbImpostoImportacao.Name = "m_gbImpostoImportacao";
			this.m_gbImpostoImportacao.Size = new System.Drawing.Size(176, 96);
			this.m_gbImpostoImportacao.TabIndex = 3;
			this.m_gbImpostoImportacao.TabStop = false;
			this.m_gbImpostoImportacao.Text = "Imposto Importação";
			// 
			// m_txtIIFinal
			// 
			this.m_txtIIFinal.Location = new System.Drawing.Point(56, 68);
			this.m_txtIIFinal.Name = "m_txtIIFinal";
			this.m_txtIIFinal.ReadOnly = true;
			this.m_txtIIFinal.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIFinal.TabIndex = 5;
			this.m_txtIIFinal.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(5, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Final:";
			// 
			// m_txtIIInicio
			// 
			this.m_txtIIInicio.Location = new System.Drawing.Point(56, 46);
			this.m_txtIIInicio.Name = "m_txtIIInicio";
			this.m_txtIIInicio.ReadOnly = true;
			this.m_txtIIInicio.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIInicio.TabIndex = 3;
			this.m_txtIIInicio.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(5, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Inicio:";
			// 
			// m_txtIIValor
			// 
			this.m_txtIIValor.Location = new System.Drawing.Point(56, 22);
			this.m_txtIIValor.Name = "m_txtIIValor";
			this.m_txtIIValor.ReadOnly = true;
			this.m_txtIIValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtIIValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtIIValor.TabIndex = 1;
			this.m_txtIIValor.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(60, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Aliquota:";
			// 
			// m_gbIPI
			// 
			this.m_gbIPI.Controls.Add(this.m_txtIPIFinal);
			this.m_gbIPI.Controls.Add(this.label4);
			this.m_gbIPI.Controls.Add(this.m_txtIPIInicio);
			this.m_gbIPI.Controls.Add(this.label3);
			this.m_gbIPI.Controls.Add(this.m_txtIPIValor);
			this.m_gbIPI.Controls.Add(this.label2);
			this.m_gbIPI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIPI.Location = new System.Drawing.Point(187, 40);
			this.m_gbIPI.Name = "m_gbIPI";
			this.m_gbIPI.Size = new System.Drawing.Size(176, 96);
			this.m_gbIPI.TabIndex = 2;
			this.m_gbIPI.TabStop = false;
			this.m_gbIPI.Text = "IPI";
			// 
			// m_txtIPIFinal
			// 
			this.m_txtIPIFinal.Location = new System.Drawing.Point(56, 68);
			this.m_txtIPIFinal.Name = "m_txtIPIFinal";
			this.m_txtIPIFinal.ReadOnly = true;
			this.m_txtIPIFinal.Size = new System.Drawing.Size(112, 20);
			this.m_txtIPIFinal.TabIndex = 5;
			this.m_txtIPIFinal.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Final:";
			// 
			// m_txtIPIInicio
			// 
			this.m_txtIPIInicio.Location = new System.Drawing.Point(56, 46);
			this.m_txtIPIInicio.Name = "m_txtIPIInicio";
			this.m_txtIPIInicio.ReadOnly = true;
			this.m_txtIPIInicio.Size = new System.Drawing.Size(112, 20);
			this.m_txtIPIInicio.TabIndex = 3;
			this.m_txtIPIInicio.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Inicio:";
			// 
			// m_txtIPIValor
			// 
			this.m_txtIPIValor.Location = new System.Drawing.Point(56, 22);
			this.m_txtIPIValor.Name = "m_txtIPIValor";
			this.m_txtIPIValor.ReadOnly = true;
			this.m_txtIPIValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.m_txtIPIValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtIPIValor.TabIndex = 1;
			this.m_txtIPIValor.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Aliquota:";
			// 
			// m_txtClassificacao
			// 
			this.m_txtClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtClassificacao.Location = new System.Drawing.Point(91, 14);
			this.m_txtClassificacao.Name = "m_txtClassificacao";
			this.m_txtClassificacao.ReadOnly = true;
			this.m_txtClassificacao.Size = new System.Drawing.Size(269, 20);
			this.m_txtClassificacao.TabIndex = 1;
			this.m_txtClassificacao.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Classificação:";
			// 
			// frmFTecAliquotas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(378, 144);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTecAliquotas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Aliquotas";
			this.Load += new System.EventHandler(this.frmFTecAliquotas_Load);
			this.m_gbMain.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.m_gbImpostoImportacao.ResumeLayout(false);
			this.m_gbIPI.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Form
				private void frmFTecAliquotas_Load(object sender, System.EventArgs e)
				{
					CarregaDados();
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
		#region CarregaDados
			private void CarregaDados()
			{
				System.Threading.Thread threadCarregaDados = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaDadosStart));
				threadCarregaDados.Start();
			}

			private void CarregaDadosStart()
			{
				OnCallCarregaDados();
			}
		#endregion
		#region Valor
			private string GetValor(string strValor)
			{
				try
				{
					decimal dcValor = decimal.Parse(strValor);
					return(strValor + " %");

				}catch{
					return(strValor);
				}
			}
		#endregion
	}
}
