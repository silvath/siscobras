using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlTec.Formularios
{
	/// <summary>
	/// Summary description for frmFProcurar.
	/// </summary>
	public class frmFProcurar : System.Windows.Forms.Form
	{
		#region Atributes
			private bool m_bConfirmed = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.TextBox m_txtDescricao;
			private System.Windows.Forms.Label m_lbDescricao;
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

			public string Localizar
			{
				set
				{
					m_txtDescricao.Text = value;
				}
				get
				{
					return(m_txtDescricao.Text);
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
		public frmFProcurar()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFProcurar));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_txtDescricao = new System.Windows.Forms.TextBox();
			this.m_lbDescricao = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Controls.Add(this.m_txtDescricao);
			this.m_gbMain.Controls.Add(this.m_lbDescricao);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, 1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(536, 72);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_txtDescricao
			// 
			this.m_txtDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDescricao.Location = new System.Drawing.Point(72, 13);
			this.m_txtDescricao.Name = "m_txtDescricao";
			this.m_txtDescricao.Size = new System.Drawing.Size(456, 20);
			this.m_txtDescricao.TabIndex = 0;
			this.m_txtDescricao.Text = "";
			this.m_txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDescricao_KeyDown);
			// 
			// m_lbDescricao
			// 
			this.m_lbDescricao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDescricao.Location = new System.Drawing.Point(8, 15);
			this.m_lbDescricao.Name = "m_lbDescricao";
			this.m_lbDescricao.Size = new System.Drawing.Size(64, 16);
			this.m_lbDescricao.TabIndex = 5;
			this.m_lbDescricao.Text = "Descri��o:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(212, 40);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(276, 40);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFProcurar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 78);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFProcurar";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Localizar";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
			#region TextBoxes
				private void m_txtDescricao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Enter)
					{
						Ok();
					}
				}
			#endregion
			#region Buttons
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					Ok();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirmed = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Ok
			private void Ok()
			{
				if (m_txtDescricao.Text.Trim() != "")
				{
					m_bConfirmed = true;
					this.Close();
				}
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
