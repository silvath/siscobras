using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace executavel
{
	/// <summary>
	/// Summary description for frmAbrirRelatorio.
	/// </summary>
	public class frmAbrirRelatorio : System.Windows.Forms.Form
	{
		#region Atributos
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;

			protected mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatorios = null;
			protected mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatoriosPadrao = null;
			protected int m_nIdExportador = 0;
			protected int m_nIdTipo = 0;
			protected int m_nIdRelatorio = 0;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Button btnOK;
			private System.Windows.Forms.Button btnCancelar;
			private System.Windows.Forms.Label lblIDs;
			private System.Windows.Forms.Label label2;
			private System.Windows.Forms.TextBox txtProcura;
			private System.Windows.Forms.ListView m_lvRelatorios;
			private System.Windows.Forms.ColumnHeader columnHeader1;

			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmAbrirRelatorio( ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionBD )
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
				m_cls_dba_ConnectionBD = cls_dba_ConnectionBD;
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblIDs = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProcura = new System.Windows.Forms.TextBox();
			this.m_lvRelatorios = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Lista de Relatórios no BD:";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(91, 312);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(171, 312);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "&Cancelar";
			// 
			// lblIDs
			// 
			this.lblIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblIDs.Location = new System.Drawing.Point(16, 288);
			this.lblIDs.Name = "lblIDs";
			this.lblIDs.Size = new System.Drawing.Size(296, 16);
			this.lblIDs.TabIndex = 4;
			this.lblIDs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Procurar:";
			// 
			// txtProcura
			// 
			this.txtProcura.Location = new System.Drawing.Point(64, 16);
			this.txtProcura.Name = "txtProcura";
			this.txtProcura.TabIndex = 6;
			this.txtProcura.Text = "";
			this.txtProcura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProcura_KeyPress);
			// 
			// m_lvRelatorios
			// 
			this.m_lvRelatorios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1});
			this.m_lvRelatorios.FullRowSelect = true;
			this.m_lvRelatorios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvRelatorios.HideSelection = false;
			this.m_lvRelatorios.Location = new System.Drawing.Point(8, 64);
			this.m_lvRelatorios.MultiSelect = false;
			this.m_lvRelatorios.Name = "m_lvRelatorios";
			this.m_lvRelatorios.Size = new System.Drawing.Size(304, 216);
			this.m_lvRelatorios.TabIndex = 7;
			this.m_lvRelatorios.View = System.Windows.Forms.View.Details;
			this.m_lvRelatorios.DoubleClick += new System.EventHandler(this.m_lvRelatorios_DoubleClick);
			this.m_lvRelatorios.SelectedIndexChanged += new System.EventHandler(this.m_lvRelatorios_SelectedIndexChanged);
			// 
			// frmAbrirRelatorio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 344);
			this.Controls.Add(this.m_lvRelatorios);
			this.Controls.Add(this.txtProcura);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblIDs);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmAbrirRelatorio";
			this.Text = "Abrir Relatorio";
			this.Load += new System.EventHandler(this.frmAbrirRelatorio_Load);
			this.Activated += new System.EventHandler(this.frmAbrirRelatorio_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmAbrirRelatorio_Load(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ListViewItem lviRelatorio = null;
					m_lvRelatorios.Columns[0].Width = m_lvRelatorios.Width - 25;
					m_lvRelatorios.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;

					// Relatorios Padroes 
					m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbRelatoriosPadrao = m_cls_dba_ConnectionBD.GetTbRelatorios(null,null,null,null,null);
					for (int nCont = 0; nCont < m_typDatSetTbRelatoriosPadrao.tbRelatorios.Rows.Count;nCont++)
					{
						dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)m_typDatSetTbRelatoriosPadrao.tbRelatorios.Rows[nCont];
						if (dtrwRelatorio.nIdRelatorio < 1)
						{
							lviRelatorio = m_lvRelatorios.Items.Add(dtrwRelatorio.strNomeRelatorio);
							lviRelatorio.Font = new System.Drawing.Font(lviRelatorio.Font,System.Drawing.FontStyle.Bold);
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdExportador.ToString());
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdTipo.ToString());
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdRelatorio.ToString());
						}
					}

					// Relatorios 
					m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbRelatorios = m_cls_dba_ConnectionBD.GetTbRelatorios(null,null,null,null,null);
					for (int nCont = 0; nCont < m_typDatSetTbRelatorios.tbRelatorios.Rows.Count;nCont++)
					{
						dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)m_typDatSetTbRelatorios.tbRelatorios.Rows[nCont];
						if (dtrwRelatorio.nIdRelatorio > 0)
						{
							lviRelatorio = m_lvRelatorios.Items.Add(dtrwRelatorio.strNomeRelatorio);
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdExportador.ToString());
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdTipo.ToString());
							lviRelatorio.SubItems.Add(dtrwRelatorio.nIdRelatorio.ToString());
						}
					}
				}

				private void frmAbrirRelatorio_Activated(object sender, System.EventArgs e)
				{
					txtProcura.Focus();
				}

			#endregion
			#region ListView Relatorios
				private void m_lvRelatorios_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					if (m_lvRelatorios.SelectedItems.Count > 0)
					{
						m_nIdExportador = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[1].Text);
						m_nIdTipo = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[2].Text);
						m_nIdRelatorio = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[3].Text); 
					}else{
						m_nIdExportador = 0;
						m_nIdTipo = 0;
						m_nIdRelatorio = 0;
					}
				}

				private void m_lvRelatorios_DoubleClick(object sender, System.EventArgs e)
				{
					if (m_lvRelatorios.SelectedItems.Count > 0)
					{
						btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
					}
				}
			#endregion
			#region Botoes
				private void btnOK_Click(object sender, System.EventArgs e)
				{
				}
			#endregion
			#region TextBoxes
				private void txtProcura_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
				{
					if ( e.KeyChar == 13 )
					{
						vProcuraRelatorio();
					}
				}
			#endregion
		#endregion
		#region Procura
			private void vProcuraRelatorio()
			{
				m_lvRelatorios.SelectedItems.Clear();
				for (int nCont = 0; nCont < m_lvRelatorios.Items.Count;nCont++)
				{
					if (m_lvRelatorios.Items[nCont].Text.StartsWith(txtProcura.Text))
					{
						m_lvRelatorios.Items[nCont].Selected = true;
						break;
					}
				}
			}
		#endregion
		#region Retorno
			public int nIdExportador()
			{
				return(m_nIdExportador);
			}

			public int nIdRelatorio()
			{
				return(m_nIdRelatorio);
			}

			public int nIdTipo()
			{
				return(m_nIdTipo);
			}
		#endregion
	}
}
