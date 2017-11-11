using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContratoCambio
{
	/// <summary>
	/// Summary description for frmFConfiguracoes.
	/// </summary>
	internal class frmFConfiguracoes : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbSaldo;
			private System.Windows.Forms.GroupBox m_gbTiposContrato;
			private System.Windows.Forms.CheckBox m_ckContratosSemSaldo;
			private System.Windows.Forms.CheckBox m_ckContratosComSaldo;
			private System.Windows.Forms.CheckBox m_ckACC;
			private System.Windows.Forms.CheckBox m_ckACE;
		#endregion
		private System.Windows.Forms.ToolTip m_ttDica;
		private System.ComponentModel.IContainer components;
		#region Constructors and Destructors
			public frmFConfiguracoes(string strEnderecoExecutavel,bool bMostrarContratosComSaldo,bool bMostrarContratosSemSaldo,bool bMostrarAcc, bool bMostrarAce)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();

				m_ckContratosComSaldo.Checked = bMostrarContratosComSaldo;
				m_ckContratosSemSaldo.Checked = bMostrarContratosSemSaldo;
				m_ckACC.Checked = bMostrarAcc;
				m_ckACE.Checked = bMostrarAce;
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConfiguracoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbTiposContrato = new System.Windows.Forms.GroupBox();
			this.m_ckACC = new System.Windows.Forms.CheckBox();
			this.m_ckACE = new System.Windows.Forms.CheckBox();
			this.m_gbSaldo = new System.Windows.Forms.GroupBox();
			this.m_ckContratosSemSaldo = new System.Windows.Forms.CheckBox();
			this.m_ckContratosComSaldo = new System.Windows.Forms.CheckBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbTiposContrato.SuspendLayout();
			this.m_gbSaldo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbTiposContrato);
			this.m_gbGeral.Controls.Add(this.m_gbSaldo);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(221, 168);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbTiposContrato
			// 
			this.m_gbTiposContrato.Controls.Add(this.m_ckACC);
			this.m_gbTiposContrato.Controls.Add(this.m_ckACE);
			this.m_gbTiposContrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTiposContrato.Location = new System.Drawing.Point(7, 73);
			this.m_gbTiposContrato.Name = "m_gbTiposContrato";
			this.m_gbTiposContrato.Size = new System.Drawing.Size(209, 55);
			this.m_gbTiposContrato.TabIndex = 18;
			this.m_gbTiposContrato.TabStop = false;
			this.m_gbTiposContrato.Text = "Tipos adiantamento";
			// 
			// m_ckACC
			// 
			this.m_ckACC.Location = new System.Drawing.Point(9, 15);
			this.m_ckACC.Name = "m_ckACC";
			this.m_ckACC.Size = new System.Drawing.Size(56, 16);
			this.m_ckACC.TabIndex = 0;
			this.m_ckACC.Text = "ACC";
			// 
			// m_ckACE
			// 
			this.m_ckACE.Location = new System.Drawing.Point(8, 32);
			this.m_ckACE.Name = "m_ckACE";
			this.m_ckACE.Size = new System.Drawing.Size(88, 16);
			this.m_ckACE.TabIndex = 1;
			this.m_ckACE.Text = "ACE";
			// 
			// m_gbSaldo
			// 
			this.m_gbSaldo.Controls.Add(this.m_ckContratosSemSaldo);
			this.m_gbSaldo.Controls.Add(this.m_ckContratosComSaldo);
			this.m_gbSaldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbSaldo.Location = new System.Drawing.Point(7, 10);
			this.m_gbSaldo.Name = "m_gbSaldo";
			this.m_gbSaldo.Size = new System.Drawing.Size(209, 62);
			this.m_gbSaldo.TabIndex = 17;
			this.m_gbSaldo.TabStop = false;
			this.m_gbSaldo.Text = "Contratos";
			// 
			// m_ckContratosSemSaldo
			// 
			this.m_ckContratosSemSaldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckContratosSemSaldo.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_ckContratosSemSaldo.Location = new System.Drawing.Point(10, 35);
			this.m_ckContratosSemSaldo.Name = "m_ckContratosSemSaldo";
			this.m_ckContratosSemSaldo.Size = new System.Drawing.Size(190, 16);
			this.m_ckContratosSemSaldo.TabIndex = 16;
			this.m_ckContratosSemSaldo.Text = "Sem saldo.";
			// 
			// m_ckContratosComSaldo
			// 
			this.m_ckContratosComSaldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckContratosComSaldo.ForeColor = System.Drawing.Color.Maroon;
			this.m_ckContratosComSaldo.Location = new System.Drawing.Point(10, 17);
			this.m_ckContratosComSaldo.Name = "m_ckContratosComSaldo";
			this.m_ckContratosComSaldo.Size = new System.Drawing.Size(182, 16);
			this.m_ckContratosComSaldo.TabIndex = 14;
			this.m_ckContratosComSaldo.Text = "Com saldo.";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(50, 133);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(114, 133);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFConfiguracoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 168);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConfiguracoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Visualizar";
			this.Load += new System.EventHandler(this.frmFConfiguracoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTiposContrato.ResumeLayout(false);
			this.m_gbSaldo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFConfiguracoes_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

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
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out bool bMostrarContratosComSaldo,out bool bMostrarContratosSemSaldo,out bool bMostrarAcc,out bool bMostrarAce)
			{
				bMostrarContratosComSaldo = m_ckContratosComSaldo.Checked;
				bMostrarContratosSemSaldo = m_ckContratosSemSaldo.Checked;
				bMostrarAcc = m_ckACC.Checked;
				bMostrarAce = m_ckACE.Checked;
			}
		#endregion
	}
}
