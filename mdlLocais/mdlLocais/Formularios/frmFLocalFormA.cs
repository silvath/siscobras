using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlLocais.Formularios
{
	/// <summary>
	/// Summary description for frmFLocalFormA.
	/// </summary>
	public class frmFLocalFormA : System.Windows.Forms.Form
	{
		#region Atributes
			private bool m_bConfirmed  = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			public System.Windows.Forms.Button m_btPadraoParaPersonalizavel;
			private System.Windows.Forms.GroupBox m_gbPersonalizavel;
			private System.Windows.Forms.TextBox m_txtPersonalizavel;
			private System.Windows.Forms.GroupBox m_gbDefault;
			private System.Windows.Forms.TextBox m_txtDefault;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
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

			public string Default
			{
				set
				{
					m_txtDefault.Text = value;
				}
				get
				{
					return(m_txtDefault.Text);
				}
			}

			public string Personalizavel
			{
				set
				{
					m_txtPersonalizavel.Text = value;
				}
				get
				{
					return(m_txtPersonalizavel.Text);
				}
			}
		#endregion
		#region Constructors
			public frmFLocalFormA(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFLocalFormA));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btPadraoParaPersonalizavel = new System.Windows.Forms.Button();
			this.m_gbPersonalizavel = new System.Windows.Forms.GroupBox();
			this.m_txtPersonalizavel = new System.Windows.Forms.TextBox();
			this.m_gbDefault = new System.Windows.Forms.GroupBox();
			this.m_txtDefault = new System.Windows.Forms.TextBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbPersonalizavel.SuspendLayout();
			this.m_gbDefault.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btPadraoParaPersonalizavel);
			this.m_gbMain.Controls.Add(this.m_gbPersonalizavel);
			this.m_gbMain.Controls.Add(this.m_gbDefault);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, 0);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(371, 247);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_btPadraoParaPersonalizavel
			// 
			this.m_btPadraoParaPersonalizavel.BackColor = System.Drawing.SystemColors.Control;
			this.m_btPadraoParaPersonalizavel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPadraoParaPersonalizavel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btPadraoParaPersonalizavel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btPadraoParaPersonalizavel.Image = ((System.Drawing.Image)(resources.GetObject("m_btPadraoParaPersonalizavel.Image")));
			this.m_btPadraoParaPersonalizavel.Location = new System.Drawing.Point(172, 99);
			this.m_btPadraoParaPersonalizavel.Name = "m_btPadraoParaPersonalizavel";
			this.m_btPadraoParaPersonalizavel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btPadraoParaPersonalizavel.Size = new System.Drawing.Size(25, 25);
			this.m_btPadraoParaPersonalizavel.TabIndex = 64;
			this.m_btPadraoParaPersonalizavel.Click += new System.EventHandler(this.m_btPadraoParaPersonalizavel_Click);
			// 
			// m_gbPersonalizavel
			// 
			this.m_gbPersonalizavel.Controls.Add(this.m_txtPersonalizavel);
			this.m_gbPersonalizavel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPersonalizavel.Location = new System.Drawing.Point(5, 124);
			this.m_gbPersonalizavel.Name = "m_gbPersonalizavel";
			this.m_gbPersonalizavel.Size = new System.Drawing.Size(361, 88);
			this.m_gbPersonalizavel.TabIndex = 7;
			this.m_gbPersonalizavel.TabStop = false;
			this.m_gbPersonalizavel.Text = "Personalizável";
			// 
			// m_txtPersonalizavel
			// 
			this.m_txtPersonalizavel.Location = new System.Drawing.Point(8, 13);
			this.m_txtPersonalizavel.Multiline = true;
			this.m_txtPersonalizavel.Name = "m_txtPersonalizavel";
			this.m_txtPersonalizavel.Size = new System.Drawing.Size(344, 64);
			this.m_txtPersonalizavel.TabIndex = 1;
			this.m_txtPersonalizavel.Text = "";
			// 
			// m_gbDefault
			// 
			this.m_gbDefault.Controls.Add(this.m_txtDefault);
			this.m_gbDefault.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDefault.Location = new System.Drawing.Point(6, 9);
			this.m_gbDefault.Name = "m_gbDefault";
			this.m_gbDefault.Size = new System.Drawing.Size(361, 88);
			this.m_gbDefault.TabIndex = 6;
			this.m_gbDefault.TabStop = false;
			this.m_gbDefault.Text = "Padrão";
			// 
			// m_txtDefault
			// 
			this.m_txtDefault.Location = new System.Drawing.Point(8, 16);
			this.m_txtDefault.Multiline = true;
			this.m_txtDefault.Name = "m_txtDefault";
			this.m_txtDefault.ReadOnly = true;
			this.m_txtDefault.Size = new System.Drawing.Size(344, 64);
			this.m_txtDefault.TabIndex = 0;
			this.m_txtDefault.Text = "";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(124, 214);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 4;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(188, 214);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 5;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFLocalFormA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(378, 248);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFLocalFormA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Local e Data";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbPersonalizavel.ResumeLayout(false);
			this.m_gbDefault.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btPadraoParaPersonalizavel_Click(object sender, System.EventArgs e)
				{
					m_txtPersonalizavel.Text = m_txtDefault.Text;
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
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
					case "System.Windows.Forms.TextBox":
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
