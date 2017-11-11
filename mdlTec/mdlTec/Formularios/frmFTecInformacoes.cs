using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFTecInformacoes.
	/// </summary>
	public class frmFTecInformacoes : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.RichTextBox m_rtbInformacoes;
			private System.Windows.Forms.Button m_btCopiar;
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public string Informacoes
			{
				set
				{
					m_rtbInformacoes.Text = value;
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
			public frmFTecInformacoes()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTecInformacoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_rtbInformacoes = new System.Windows.Forms.RichTextBox();
			this.m_btCopiar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btCopiar);
			this.m_gbMain.Controls.Add(this.m_rtbInformacoes);
			this.m_gbMain.Location = new System.Drawing.Point(4, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(586, 360);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_rtbInformacoes
			// 
			this.m_rtbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_rtbInformacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rtbInformacoes.Location = new System.Drawing.Point(8, 40);
			this.m_rtbInformacoes.Name = "m_rtbInformacoes";
			this.m_rtbInformacoes.Size = new System.Drawing.Size(568, 312);
			this.m_rtbInformacoes.TabIndex = 0;
			this.m_rtbInformacoes.Text = "";
			// 
			// m_btCopiar
			// 
			this.m_btCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCopiar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCopiar.Image")));
			this.m_btCopiar.Location = new System.Drawing.Point(11, 11);
			this.m_btCopiar.Name = "m_btCopiar";
			this.m_btCopiar.Size = new System.Drawing.Size(25, 25);
			this.m_btCopiar.TabIndex = 12;
			this.m_ttDicas.SetToolTip(this.m_btCopiar, "Copiar");
			this.m_btCopiar.Click += new System.EventHandler(this.m_btCopiar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFTecInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 368);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTecInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Informações";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region Buttons
				private void m_btCopiar_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.Clipboard.SetDataObject(m_rtbInformacoes.Text,true);
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
					case "System.Windows.Forms.RichTextBox":
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
