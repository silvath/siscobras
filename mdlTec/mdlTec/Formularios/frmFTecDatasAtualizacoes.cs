using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTecDatasAtualizacoes.
	/// </summary>
	public class frmFTecDatasAtualizacoes : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.Label label3;
			private System.Windows.Forms.Label label4;
			private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txtTecSiscobras;
		private System.Windows.Forms.TextBox m_txtNcm;
		private System.Windows.Forms.TextBox m_txtNaladi;
		private System.Windows.Forms.TextBox m_txtNesh;
		private System.Windows.Forms.TextBox m_txtAliquotas;
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

			public System.DateTime DataAtualizacaoTecSiscobras
			{
				set
				{
					m_txtTecSiscobras.Text = value.ToString("dd/MMM/yyyy");
				}
			}

			public System.DateTime DataAtualizacaoNcm
			{
				set
				{
					m_txtNcm.Text = value.ToString("dd/MMM/yyyy");
				}
			}

			public System.DateTime DataAtualizacaoNaladi
			{
				set
				{
					m_txtNaladi.Text = value.ToString("dd/MMM/yyyy");
				}
			}

			public System.DateTime DataAtualizacaoNesh
			{
				set
				{
					m_txtNesh.Text = value.ToString("dd/MMM/yyyy");
				}
			}

			public System.DateTime DataAtualizacaoAliquotas
			{
				set
				{
					m_txtAliquotas.Text = value.ToString("dd/MMM/yyyy");
				}
			}
		#endregion
		#region Constructors
			public frmFTecDatasAtualizacoes()
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTecDatasAtualizacoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtTecSiscobras = new System.Windows.Forms.TextBox();
			this.m_txtNcm = new System.Windows.Forms.TextBox();
			this.m_txtNaladi = new System.Windows.Forms.TextBox();
			this.m_txtNesh = new System.Windows.Forms.TextBox();
			this.m_txtAliquotas = new System.Windows.Forms.TextBox();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_txtAliquotas);
			this.m_gbMain.Controls.Add(this.m_txtNesh);
			this.m_gbMain.Controls.Add(this.m_txtNaladi);
			this.m_gbMain.Controls.Add(this.m_txtNcm);
			this.m_gbMain.Controls.Add(this.m_txtTecSiscobras);
			this.m_gbMain.Controls.Add(this.label5);
			this.m_gbMain.Controls.Add(this.label4);
			this.m_gbMain.Controls.Add(this.label3);
			this.m_gbMain.Controls.Add(this.label2);
			this.m_gbMain.Controls.Add(this.label1);
			this.m_gbMain.Location = new System.Drawing.Point(4, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(234, 142);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(17, 114);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Aliquotas:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(17, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Nesh:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(17, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Naladi:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(17, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "NCM:";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "TecSiscobras:";
			// 
			// m_txtTecSiscobras
			// 
			this.m_txtTecSiscobras.Location = new System.Drawing.Point(117, 15);
			this.m_txtTecSiscobras.Name = "m_txtTecSiscobras";
			this.m_txtTecSiscobras.ReadOnly = true;
			this.m_txtTecSiscobras.Size = new System.Drawing.Size(104, 20);
			this.m_txtTecSiscobras.TabIndex = 9;
			this.m_txtTecSiscobras.Text = "";
			// 
			// m_txtNcm
			// 
			this.m_txtNcm.Location = new System.Drawing.Point(117, 37);
			this.m_txtNcm.Name = "m_txtNcm";
			this.m_txtNcm.ReadOnly = true;
			this.m_txtNcm.Size = new System.Drawing.Size(104, 20);
			this.m_txtNcm.TabIndex = 10;
			this.m_txtNcm.Text = "";
			// 
			// m_txtNaladi
			// 
			this.m_txtNaladi.Location = new System.Drawing.Point(117, 62);
			this.m_txtNaladi.Name = "m_txtNaladi";
			this.m_txtNaladi.ReadOnly = true;
			this.m_txtNaladi.Size = new System.Drawing.Size(104, 20);
			this.m_txtNaladi.TabIndex = 11;
			this.m_txtNaladi.Text = "";
			// 
			// m_txtNesh
			// 
			this.m_txtNesh.Location = new System.Drawing.Point(117, 88);
			this.m_txtNesh.Name = "m_txtNesh";
			this.m_txtNesh.ReadOnly = true;
			this.m_txtNesh.Size = new System.Drawing.Size(104, 20);
			this.m_txtNesh.TabIndex = 12;
			this.m_txtNesh.Text = "";
			// 
			// m_txtAliquotas
			// 
			this.m_txtAliquotas.Location = new System.Drawing.Point(117, 111);
			this.m_txtAliquotas.Name = "m_txtAliquotas";
			this.m_txtAliquotas.ReadOnly = true;
			this.m_txtAliquotas.Size = new System.Drawing.Size(104, 20);
			this.m_txtAliquotas.TabIndex = 13;
			this.m_txtAliquotas.Text = "";
			// 
			// frmFTecDatasAtualizacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(242, 144);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTecDatasAtualizacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Datas das Atualizações";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
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
