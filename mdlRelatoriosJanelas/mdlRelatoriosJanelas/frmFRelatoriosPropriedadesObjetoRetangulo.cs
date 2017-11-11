using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosPropriedadesObjetoRetangulo.
	/// </summary>
	public class frmFRelatoriosPropriedadesObjetoRetangulo : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private string m_strEnderecoExecutavel; 
		private bool m_bVisivelImpressao; 
		public bool m_bModificado; 

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.CheckBox m_ckVisivelImpressao;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
		public frmFRelatoriosPropriedadesObjetoRetangulo(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,string strEnderecoExecutavel, bool bVisivelImpressao)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bVisivelImpressao = bVisivelImpressao;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosPropriedadesObjetoRetangulo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_ckVisivelImpressao = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_ckVisivelImpressao);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(182, 73);
			this.m_gbGeral.TabIndex = 5;
			this.m_gbGeral.TabStop = false;
			// 
			// m_ckVisivelImpressao
			// 
			this.m_ckVisivelImpressao.Location = new System.Drawing.Point(8, 16);
			this.m_ckVisivelImpressao.Name = "m_ckVisivelImpressao";
			this.m_ckVisivelImpressao.Size = new System.Drawing.Size(152, 16);
			this.m_ckVisivelImpressao.TabIndex = 3;
			this.m_ckVisivelImpressao.Text = "Visivel na Impressao.";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(32, 43);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
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
			this.m_btCancelar.Location = new System.Drawing.Point(96, 43);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosPropriedadesObjetoRetangulo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(192, 78);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosPropriedadesObjetoRetangulo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Retangulo";
			this.Load += new System.EventHandler(this.frmFRelatoriosPropriedadesObjetoCirculo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
		#region Formulario
		private void frmFRelatoriosPropriedadesObjetoCirculo_Load(object sender, System.EventArgs e)
		{
			MostraCor();
			m_ckVisivelImpressao.Checked = m_bVisivelImpressao;
		}
		#endregion 
		#region Botoes
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			m_bVisivelImpressao = m_ckVisivelImpressao.Checked;
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
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region Retorno
		public void RetornaValores(out bool bVisivelImpressao)
		{
			bVisivelImpressao = m_bVisivelImpressao;
		} 
		#endregion
	}
}
