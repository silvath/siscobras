using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFVolumeTipo.
	/// </summary>
	internal class frmFVolumeTipo : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDadosInterfaceVolumeTipo(ref mdlComponentesGraficos.ListView lvTiposVolumes,ref System.Windows.Forms.ImageList ilVolumes);
		#endregion
		#region Events
			public event delCallCarregaDadosInterfaceVolumeTipo eCallCarregaDadosInterfaceVolumeTipo;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterfaceVolumeTipo()
			{
				if (eCallCarregaDadosInterfaceVolumeTipo != null)
				{
					eCallCarregaDadosInterfaceVolumeTipo(ref this.m_lvTipos,ref m_ilVolumes);
				}
			}
		#endregion

		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;
			private System.Windows.Forms.ImageList m_ilVolumes;

			private int m_nIdVolume = -1;
			private int m_nIdEspecieSelect = -1;

			public bool m_bModificado = false;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal mdlComponentesGraficos.ListView m_lvTipos;
			private System.Windows.Forms.GroupBox m_gbTiposVolumes;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.Windows.Forms.ColumnHeader m_colhTipoVolume;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public int EspecieSelect
			{
				set
				{
					m_nIdEspecieSelect = value;
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFVolumeTipo(ref mdlTratamentoErro.clsTratamentoErro TratadorErro, string strEnderecoExecutavel,ref System.Windows.Forms.ImageList ilVolumes)
			{
				m_cls_ter_tratadorErro = TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_ilVolumes = ilVolumes;
				InitializeComponent();
				m_lvTipos.SmallImageList = m_ilVolumes;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeTipo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbTiposVolumes = new System.Windows.Forms.GroupBox();
			this.m_lvTipos = new mdlComponentesGraficos.ListView();
			this.m_colhTipoVolume = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbTiposVolumes.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbTiposVolumes);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, -3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(285, 335);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbTiposVolumes
			// 
			this.m_gbTiposVolumes.Controls.Add(this.m_lvTipos);
			this.m_gbTiposVolumes.Location = new System.Drawing.Point(8, 16);
			this.m_gbTiposVolumes.Name = "m_gbTiposVolumes";
			this.m_gbTiposVolumes.Size = new System.Drawing.Size(272, 288);
			this.m_gbTiposVolumes.TabIndex = 0;
			this.m_gbTiposVolumes.TabStop = false;
			// 
			// m_lvTipos
			// 
			this.m_lvTipos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.m_colhTipoVolume});
			this.m_lvTipos.FullRowSelect = true;
			this.m_lvTipos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvTipos.HideSelection = false;
			this.m_lvTipos.Location = new System.Drawing.Point(8, 16);
			this.m_lvTipos.Name = "m_lvTipos";
			this.m_lvTipos.Size = new System.Drawing.Size(256, 264);
			this.m_lvTipos.TabIndex = 0;
			this.m_lvTipos.View = System.Windows.Forms.View.Details;
			this.m_lvTipos.DoubleClick += new System.EventHandler(this.m_lvTipos_DoubleClick);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(83, 305);
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
			this.m_btCancelar.Location = new System.Drawing.Point(147, 305);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFVolumeTipo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 336);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFVolumeTipo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Espécies de Embalagens";
			this.Load += new System.EventHandler(this.frmFVolumeTipo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTiposVolumes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFVolumeTipo_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDadosInterfaceVolumeTipo();
					vSelect();
				}
			#endregion
			#region ListView
				private void m_lvTipos_DoubleClick(object sender, System.EventArgs e)
				{
					if (m_lvTipos.SelectedItems.Count > 0)
					{
						m_nIdVolume = Int32.Parse(m_lvTipos.SelectedItems[0].Tag.ToString());
						m_bModificado = true;
						this.Close();
					}
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_lvTipos.SelectedItems.Count > 0)
					{
						m_nIdVolume = Int32.Parse(m_lvTipos.SelectedItems[0].Tag.ToString());
						m_bModificado = true;
						this.Close();
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ListView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ListView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
							}
						}
					}
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion

		#region Select
			private void vSelect()
			{
				for(int i = 0; i < m_lvTipos.Items.Count; i++)
					if (Int32.Parse(m_lvTipos.Items[i].Tag.ToString()) == m_nIdEspecieSelect)
					{
						m_lvTipos.Items[i].Selected = true;
						m_lvTipos.EnsureVisible(i);
						break;
					}
				m_nIdEspecieSelect = -1;
				m_lvTipos.EnsureVisible(18);
			}
		#endregion

		#region Retorno
			public void RetornaValores(out int nIdVolume)
			{
				nIdVolume = m_nIdVolume;
			}
		#endregion
	}
}
