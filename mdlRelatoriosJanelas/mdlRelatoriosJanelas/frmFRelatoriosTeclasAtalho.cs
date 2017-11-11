using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosTeclasAtalho.
	/// </summary>
	public class frmFRelatoriosTeclasAtalho : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel; 
			// Teclas de Atalho 
			private System.Collections.ArrayList m_arlTeclasAtalhoNomes; 
			private System.Collections.ArrayList m_arlTeclasAtalhoTeclas; 
			private System.Collections.ArrayList m_arlTeclasAtalhoTeclasTemp;
			private System.Collections.ArrayList m_arlTeclasAtalhoNomesNoIni;
			private System.Collections.ArrayList m_arlTeclasAtalhoAcoes;
			public bool m_bModificado; 

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.ListView m_lvTeclas;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.ToolTip m_ttDica;
		internal System.Windows.Forms.ColumnHeader m_colhComando;
		internal System.Windows.Forms.ColumnHeader m_colhTecla;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructor and Destructors
			public frmFRelatoriosTeclasAtalho(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, string strEnderecoExecutavel,ref System.Collections.ArrayList arlTeclasAtalhoNomes,ref System.Collections.ArrayList arlTeclasAtalhoTeclas, ref System.Collections.ArrayList arlTeclasAtalhoNomesNoIni ,ref System.Collections.ArrayList arlTeclasAtalhoAcoes )
			{
		        m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_arlTeclasAtalhoNomes = arlTeclasAtalhoNomes;
				m_arlTeclasAtalhoTeclas = arlTeclasAtalhoTeclas;
				m_arlTeclasAtalhoTeclasTemp = (System.Collections.ArrayList)m_arlTeclasAtalhoTeclas.Clone();
				m_arlTeclasAtalhoNomesNoIni = arlTeclasAtalhoNomesNoIni;
				m_arlTeclasAtalhoAcoes = arlTeclasAtalhoAcoes;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosTeclasAtalho));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lvTeclas = new System.Windows.Forms.ListView();
			this.m_colhComando = new System.Windows.Forms.ColumnHeader();
			this.m_colhTecla = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lvTeclas);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(386, 289);
			this.m_gbGeral.TabIndex = 4;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lvTeclas
			// 
			this.m_lvTeclas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.m_colhComando,
																						 this.m_colhTecla});
			this.m_lvTeclas.FullRowSelect = true;
			this.m_lvTeclas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvTeclas.Location = new System.Drawing.Point(9, 12);
			this.m_lvTeclas.MultiSelect = false;
			this.m_lvTeclas.Name = "m_lvTeclas";
			this.m_lvTeclas.Size = new System.Drawing.Size(367, 245);
			this.m_lvTeclas.TabIndex = 7;
			this.m_lvTeclas.View = System.Windows.Forms.View.Details;
			this.m_lvTeclas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvTeclas_KeyDown);
			// 
			// m_colhComando
			// 
			this.m_colhComando.Text = "Comando";
			this.m_colhComando.Width = 231;
			// 
			// m_colhTecla
			// 
			this.m_colhTecla.Text = "Tecla";
			this.m_colhTecla.Width = 132;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(133, 260);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
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
			this.m_btCancelar.Location = new System.Drawing.Point(197, 260);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
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
			// frmFRelatoriosTeclasAtalho
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 294);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosTeclasAtalho";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Teclas de Atalho";
			this.Load += new System.EventHandler(this.frmFRelatoriosTeclasAtalho_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRelatoriosTeclasAtalho_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					RefreshTeclasAtalho();
				}
			#endregion
			#region m_lvTeclas
				private void m_lvTeclas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (m_lvTeclas.SelectedItems.Count > 0)
					{
						bool bExiste = false;
						for (int nCont = 0;nCont < m_arlTeclasAtalhoTeclasTemp.Count;nCont++)
						{
							if (((System.Windows.Forms.KeyEventArgs)m_arlTeclasAtalhoTeclasTemp[nCont]).KeyData == e.KeyData)
							{
								bExiste = true;
								break;
							}
						}
						if (!bExiste)
						{
							if (bKeyValido(e))
							{
								m_arlTeclasAtalhoTeclasTemp[m_lvTeclas.SelectedItems[0].Index] = e;
								m_lvTeclas.SelectedItems[0].SubItems[1].Text = strRetornaTextoCorrespondenteAoKeyEventArgs(e);
							}
						}
						e.Handled = true;
					}
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					//m_arlTeclasAtalhoTeclas = m_arlTeclasAtalhoTeclasTemp;
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
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

		#region Refresh
			private void RefreshTeclasAtalho()
			{
		        System.Windows.Forms.ListViewItem lviItem; 
				m_lvTeclas.Columns[0].Width = 200;
				m_lvTeclas.Columns[1].Width = 130;

				m_lvTeclas.Items.Clear();
				for(int nCont = 0; nCont < m_arlTeclasAtalhoNomes.Count;nCont++)
				{
					lviItem = m_lvTeclas.Items.Add(m_arlTeclasAtalhoNomes[nCont].ToString());
					lviItem.SubItems.Add(strRetornaTextoCorrespondenteAoKeyEventArgs((System.Windows.Forms.KeyEventArgs)m_arlTeclasAtalhoTeclas[nCont]));
				}
			}
		#endregion 
		#region Métodos
			private string strRetornaTextoCorrespondenteAoKeyEventArgs(System.Windows.Forms.KeyEventArgs key)
			{
			    string strRetorno = "";
				if (key.Control)
				{
					strRetorno = "Ctrl";
				}
				if (key.Alt)
				{
					if (strRetorno != "")
					{
						strRetorno += " + ";
					}
					strRetorno += "Alt";
				} 
				if (key.Shift)
				{
					if (strRetorno != "")
					{
						strRetorno += " + ";
					}
					strRetorno += "Shift";
				} 
				switch(key.KeyCode)
				{
					case System.Windows.Forms.Keys.Add:
						if (strRetorno != "")
						{
							strRetorno += " + ";
						}
						strRetorno += "Mais";
						break;
					case System.Windows.Forms.Keys.Subtract:
						if (strRetorno != "")
						{
							strRetorno += " + ";
						}
						strRetorno += "Menos";
						break;
					case System.Windows.Forms.Keys.Oemplus:
						if (strRetorno != "")
						{
							strRetorno += " + ";
						}
						strRetorno += "Igual";
						break;
					default:
						if (strRetorno != "")
						{
							strRetorno += " + ";
						}
						strRetorno += key.KeyCode.ToString();
						break;
				}
				return (strRetorno);
			}

			private bool bKeyValido(System.Windows.Forms.KeyEventArgs key)
			{
				bool bRetorno = true;
				switch(key.KeyCode)
				{
					case System.Windows.Forms.Keys.ControlKey: // Control 
						bRetorno = false;
						break;
					case System.Windows.Forms.Keys.Alt: // Alt Apenas
						bRetorno = false;
						break;
					case System.Windows.Forms.Keys.ShiftKey: // Shift Apenas
						bRetorno = false;
						break;
					case System.Windows.Forms.Keys.Tab: // Altertando no sistema
						if (key.Alt) 
							bRetorno = false;
						break;
					case System.Windows.Forms.Keys.F4: // Fechando Sistema
						if ((key.Alt) || (key.Control)) 
							bRetorno = false;
						break;
					case System.Windows.Forms.Keys.Delete: // Del + Control + Alt 
						if ((key.Alt) && (key.Control))
							 bRetorno = false;
						break;
				}
				return (bRetorno);

			}
		#endregion

		#region Retorno
			public void vRetornaValores(out System.Collections.ArrayList arlTeclasAtalhoTeclas)
			{
				arlTeclasAtalhoTeclas = m_arlTeclasAtalhoTeclasTemp;
			}
		#endregion
	}
}
