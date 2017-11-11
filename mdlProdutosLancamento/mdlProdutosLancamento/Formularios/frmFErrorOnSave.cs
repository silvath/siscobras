using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for frmFErrorOnSave.
	/// </summary>
	public class frmFErrorOnSave : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel; 

			private System.Windows.Forms.GroupBox m_gbGeral;
			public System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Label m_lbInfo;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors 
			public frmFErrorOnSave(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFErrorOnSave));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lbInfo = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lbInfo);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(364, 74);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbInfo
			// 
			this.m_lbInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfo.Location = new System.Drawing.Point(6, 10);
			this.m_lbInfo.Name = "m_lbInfo";
			this.m_lbInfo.Size = new System.Drawing.Size(352, 30);
			this.m_lbInfo.TabIndex = 12;
			this.m_lbInfo.Text = "Ocorreram erros ao salvar as modificações. Tente novamente.  Possível causa: Falh" +
				"a de comunicação com o banco de dados.";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(150, 43);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 11;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFErrorOnSave
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(370, 80);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFErrorOnSave";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Conexão com banco de Dados";
			this.Load += new System.EventHandler(this.frmFErrorOnSave_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFErrorOnSave_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
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
