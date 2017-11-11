using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosTrocaRelatorio.
	/// </summary>
	public class frmFRelatoriosTrocaRelatorio : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos 
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB; 
		private string m_strEnderecoExecutavel; 
		private int m_nIdExportador;
		private int m_nTipoRelatorio;
		private int m_nIdRelatorio;
		public bool m_bModificado; 

		// Typed Data Set 
		private mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatorios;
		private mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatoriosPadrao;
		private System.Windows.Forms.GroupBox m_gbGeral;
		private System.Windows.Forms.GroupBox m_gbCriados;
		private System.Windows.Forms.ListView m_lvCriados;
		private System.Windows.Forms.GroupBox m_gbPadrao;
		private System.Windows.Forms.ListView m_lvPadrao;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors 
		public frmFRelatoriosTrocaRelatorio(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador, int nIdTipoRelatorio)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_nTipoRelatorio = nIdTipoRelatorio;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosTrocaRelatorio));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbCriados = new System.Windows.Forms.GroupBox();
			this.m_lvCriados = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_gbPadrao = new System.Windows.Forms.GroupBox();
			this.m_lvPadrao = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbCriados.SuspendLayout();
			this.m_gbPadrao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbCriados);
			this.m_gbGeral.Controls.Add(this.m_gbPadrao);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(2, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(412, 344);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbCriados
			// 
			this.m_gbCriados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbCriados.Controls.Add(this.m_lvCriados);
			this.m_gbCriados.Location = new System.Drawing.Point(8, 158);
			this.m_gbCriados.Name = "m_gbCriados";
			this.m_gbCriados.Size = new System.Drawing.Size(396, 151);
			this.m_gbCriados.TabIndex = 67;
			this.m_gbCriados.TabStop = false;
			this.m_gbCriados.Text = "Relatórios Criados pelo Usuário";
			// 
			// m_lvCriados
			// 
			this.m_lvCriados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvCriados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader2});
			this.m_lvCriados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvCriados.HideSelection = false;
			this.m_lvCriados.Location = new System.Drawing.Point(8, 17);
			this.m_lvCriados.MultiSelect = false;
			this.m_lvCriados.Name = "m_lvCriados";
			this.m_lvCriados.Size = new System.Drawing.Size(380, 127);
			this.m_lvCriados.TabIndex = 0;
			this.m_lvCriados.View = System.Windows.Forms.View.Details;
			this.m_lvCriados.Click += new System.EventHandler(this.m_lvCriados_Click);
			this.m_lvCriados.SelectedIndexChanged += new System.EventHandler(this.m_lvCriados_SelectedIndexChanged);
			// 
			// m_gbPadrao
			// 
			this.m_gbPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPadrao.Controls.Add(this.m_lvPadrao);
			this.m_gbPadrao.Location = new System.Drawing.Point(8, 8);
			this.m_gbPadrao.Name = "m_gbPadrao";
			this.m_gbPadrao.Size = new System.Drawing.Size(396, 144);
			this.m_gbPadrao.TabIndex = 66;
			this.m_gbPadrao.TabStop = false;
			this.m_gbPadrao.Text = "Relatórios Padrão";
			// 
			// m_lvPadrao
			// 
			this.m_lvPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvPadrao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1});
			this.m_lvPadrao.FullRowSelect = true;
			this.m_lvPadrao.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvPadrao.HideSelection = false;
			this.m_lvPadrao.Location = new System.Drawing.Point(8, 17);
			this.m_lvPadrao.MultiSelect = false;
			this.m_lvPadrao.Name = "m_lvPadrao";
			this.m_lvPadrao.Size = new System.Drawing.Size(379, 119);
			this.m_lvPadrao.TabIndex = 0;
			this.m_lvPadrao.View = System.Windows.Forms.View.Details;
			this.m_lvPadrao.Click += new System.EventHandler(this.m_lvPadrao_Click);
			this.m_lvPadrao.SelectedIndexChanged += new System.EventHandler(this.m_lvPadrao_SelectedIndexChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(146, 313);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 64;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(210, 313);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 65;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosTrocaRelatorio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 346);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosTrocaRelatorio";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trocar Relatório";
			this.Load += new System.EventHandler(this.frmFRelatoriosTrocaRelatorio_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbCriados.ResumeLayout(false);
			this.m_gbPadrao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region Formulario
		private void frmFRelatoriosTrocaRelatorio_Load(object sender, System.EventArgs e)
		{
			MostraCor();
			CarregaDadosBD();
			RefreshRelatoriosPadrao();
			RefreshRelatoriosNormal();
		}
		#endregion 
		#region m_lvPadrao
			private void m_lvPadrao_Click(object sender, System.EventArgs e)
			{
				if (m_lvPadrao.SelectedItems.Count > 0)
				{
					if (m_lvCriados.SelectedItems.Count > 0)
					{
						m_lvCriados.SelectedItems[0].Selected = false;
					}
				}
			}
			private void m_lvPadrao_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				if (m_lvPadrao.SelectedItems.Count > 0)
				{
					if (m_lvCriados.SelectedItems.Count > 0)
					{
						m_lvCriados.SelectedItems[0].Selected = false;
					}
				}
			}
		#endregion
		#region m_lvCriados
			private void m_lvCriados_Click(object sender, System.EventArgs e)
			{
				if (m_lvCriados.SelectedItems.Count > 0)
				{
					if (m_lvPadrao.SelectedItems.Count > 0)
					{
						m_lvPadrao.SelectedItems[0].Selected = false;
					}
				}
			}

			private void m_lvCriados_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				if (m_lvCriados.SelectedItems.Count > 0)
				{
					if (m_lvPadrao.SelectedItems.Count > 0)
					{
						m_lvPadrao.SelectedItems[0].Selected = false;
					}
				}
			}
		#endregion
		#region Botoes
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			
            if (m_lvPadrao.SelectedItems.Count > 0)
			{
                m_nIdRelatorio = Int32.Parse(m_lvPadrao.SelectedItems[0].Tag.ToString());
                m_bModificado = true;
				this.Close();
			}else{
				if (m_lvCriados.SelectedItems.Count > 0)
				{
                    m_nIdRelatorio = Int32.Parse(m_lvCriados.SelectedItems[0].Tag.ToString());
                    m_bModificado = true;
                    this.Close();
				}else{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosJanelas_frmFRelatoriosTrocaRelatorio_EscolherRelatorio));
					//MessageBox.Show("Você precisa escolher um relatório.","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
				}
			}
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

		#region Carregamento dos Dados
			private void CarregaDadosBD()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nTipoRelatorio);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbRelatoriosPadrao = m_cls_dba_ConnectionDB.GetTbRelatorios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
		#endregion
		#region Refresh
		private void RefreshRelatoriosPadrao()
		{
			System.Windows.Forms.ListViewItem lviItem; 
			System.Collections.SortedList sortLstRelatoriosPadrao = new System.Collections.SortedList();

			m_lvPadrao.Columns[0].Width = m_lvPadrao.Width - 20;

			m_lvPadrao.Items.Clear();

			// Ordenando e Dividindo os Relatorios
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;
			for(int nCont = 0; nCont < m_typDatSetTbRelatoriosPadrao.tbRelatorios.Rows.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)m_typDatSetTbRelatoriosPadrao.tbRelatorios.Rows[nCont];
				if (dtrwRelatorio.nIdRelatorio < 1)
				{ // Padrao
					if (!sortLstRelatoriosPadrao.Contains(dtrwRelatorio.strNomeRelatorio))
						sortLstRelatoriosPadrao.Add(dtrwRelatorio.strNomeRelatorio,dtrwRelatorio);
				}
			}

			// Inserindo os Relatorios na Lista View
			for (int nCont = 0;nCont < sortLstRelatoriosPadrao.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)sortLstRelatoriosPadrao.GetByIndex(nCont);
				lviItem = m_lvPadrao.Items.Add(dtrwRelatorio.strNomeRelatorio);
				lviItem.Tag = dtrwRelatorio.nIdRelatorio;
				lviItem.Font = new System.Drawing.Font(lviItem.Font, System.Drawing.FontStyle.Bold);
			}
		}

		private void RefreshRelatoriosNormal()
		{
			System.Windows.Forms.ListViewItem lviItem; 
			System.Collections.SortedList sortLstRelatorios = new System.Collections.SortedList();

			m_lvCriados.Columns[0].Width = m_lvCriados.Width - 20;

			m_lvCriados.Items.Clear();

			// Ordenando e Dividindo os Relatorios
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;
			for(int nCont = 0; nCont < m_typDatSetTbRelatorios.tbRelatorios.Rows.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)m_typDatSetTbRelatorios.tbRelatorios.Rows[nCont];
				if (dtrwRelatorio.nIdRelatorio > 0 && dtrwRelatorio.nIdExportador == m_nIdExportador)
				{ // Normal
					if (!sortLstRelatorios.Contains(dtrwRelatorio.strNomeRelatorio))
						sortLstRelatorios.Add(dtrwRelatorio.strNomeRelatorio,dtrwRelatorio);
				}
			}

			// Inserindo os Relatorios na Lista View
			for (int nCont = 0;nCont < sortLstRelatorios.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)sortLstRelatorios.GetByIndex(nCont);
				lviItem = m_lvCriados.Items.Add(dtrwRelatorio.strNomeRelatorio);
				lviItem.Tag = dtrwRelatorio.nIdRelatorio;
			}
		}
		#endregion

		#region Retorno
		public void RetornaValores(out int nIdRelatorio)
		{
			nIdRelatorio = m_nIdRelatorio;
		}
		#endregion

	}
}
