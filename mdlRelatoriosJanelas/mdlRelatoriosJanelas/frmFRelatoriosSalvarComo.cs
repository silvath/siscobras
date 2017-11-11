using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosSalvarComo.
	/// </summary>
	public class frmFRelatoriosSalvarComo : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB; 
			private string m_strEnderecoExecutavel; 
			private int m_nIdExportador; 
			private int m_nTipoRelatorio; 
			private int m_nIdRelatorio; 
			private bool m_bReportAlreadyExists = false;
			private bool m_bReportDefault = false;
			private string m_strNomeRelatorio; 
			private bool m_bMostrarPadroes; 
			public bool m_bModificado;

			// TypedDataSet
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatorios = null;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.GroupBox m_gbNovo;
			internal System.Windows.Forms.Label m_lbNome;
			internal System.Windows.Forms.GroupBox m_gbSobreEscrever;
			internal System.Windows.Forms.ListView m_lvRelatorios;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			private mdlComponentesGraficos.TextBox m_txtRelatorio;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
		public frmFRelatoriosSalvarComo(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel, int nIdExportador, int nIdTipoRelatorio, bool bMostrarPadroes)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_nTipoRelatorio = nIdTipoRelatorio;
			m_bMostrarPadroes = false;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosSalvarComo));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbNovo = new System.Windows.Forms.GroupBox();
			this.m_txtRelatorio = new mdlComponentesGraficos.TextBox();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_gbSobreEscrever = new System.Windows.Forms.GroupBox();
			this.m_lvRelatorios = new System.Windows.Forms.ListView();
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbNovo.SuspendLayout();
			this.m_gbSobreEscrever.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbNovo);
			this.m_gbGeral.Controls.Add(this.m_gbSobreEscrever);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(8, 3);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(331, 251);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbNovo
			// 
			this.m_gbNovo.Controls.Add(this.m_txtRelatorio);
			this.m_gbNovo.Controls.Add(this.m_lbNome);
			this.m_gbNovo.Location = new System.Drawing.Point(6, 163);
			this.m_gbNovo.Name = "m_gbNovo";
			this.m_gbNovo.Size = new System.Drawing.Size(314, 51);
			this.m_gbNovo.TabIndex = 0;
			this.m_gbNovo.TabStop = false;
			this.m_gbNovo.Text = "Criando um novo ";
			// 
			// m_txtRelatorio
			// 
			this.m_txtRelatorio.Location = new System.Drawing.Point(48, 20);
			this.m_txtRelatorio.Name = "m_txtRelatorio";
			this.m_txtRelatorio.Size = new System.Drawing.Size(257, 20);
			this.m_txtRelatorio.TabIndex = 0;
			this.m_txtRelatorio.Text = "";
			// 
			// m_lbNome
			// 
			this.m_lbNome.Location = new System.Drawing.Point(8, 22);
			this.m_lbNome.Name = "m_lbNome";
			this.m_lbNome.Size = new System.Drawing.Size(40, 16);
			this.m_lbNome.TabIndex = 0;
			this.m_lbNome.Text = "Nome:";
			// 
			// m_gbSobreEscrever
			// 
			this.m_gbSobreEscrever.Controls.Add(this.m_lvRelatorios);
			this.m_gbSobreEscrever.Location = new System.Drawing.Point(7, 10);
			this.m_gbSobreEscrever.Name = "m_gbSobreEscrever";
			this.m_gbSobreEscrever.Size = new System.Drawing.Size(313, 150);
			this.m_gbSobreEscrever.TabIndex = 8;
			this.m_gbSobreEscrever.TabStop = false;
			this.m_gbSobreEscrever.Text = "Sobrepondo um existente";
			// 
			// m_lvRelatorios
			// 
			this.m_lvRelatorios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.ColumnHeader1});
			this.m_lvRelatorios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvRelatorios.Location = new System.Drawing.Point(7, 15);
			this.m_lvRelatorios.MultiSelect = false;
			this.m_lvRelatorios.Name = "m_lvRelatorios";
			this.m_lvRelatorios.Size = new System.Drawing.Size(297, 129);
			this.m_lvRelatorios.TabIndex = 7;
			this.m_lvRelatorios.View = System.Windows.Forms.View.Details;
			this.m_lvRelatorios.Click += new System.EventHandler(this.m_lvRelatorios_Click);
			this.m_lvRelatorios.SelectedIndexChanged += new System.EventHandler(this.m_lvRelatorios_SelectedIndexChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(104, 219);
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
			this.m_btCancelar.Location = new System.Drawing.Point(168, 219);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosSalvarComo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 262);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosSalvarComo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Salvando Relatório";
			this.Load += new System.EventHandler(this.frmFRelatoriosSalvarComo_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbNovo.ResumeLayout(false);
			this.m_gbSobreEscrever.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRelatoriosSalvarComo_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					CarregaDadosBD();
					RefreshRelatorios();
				}
			#endregion
			#region m_lvRelatorios
				private void m_lvRelatorios_Click(object sender, System.EventArgs e)
				{
					RefreshNomeRelatorio();
				}

				private void m_lvRelatorios_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					RefreshNomeRelatorio();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_strNomeRelatorio = m_txtRelatorio.Text;

					// Verificando o tipo de relatorio 
					if ((m_bMostrarPadroes) && (System.Windows.Forms.Form.ModifierKeys == (System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)))
					{ // Padrão
						m_bReportDefault = true;
						for(int nCont = 0; nCont < m_lvRelatorios.Items.Count;nCont++)
						{
							if (m_lvRelatorios.Items[nCont].Font.Bold)
							{
								if (m_lvRelatorios.Items[nCont].Text == m_txtRelatorio.Text.Trim())
								{
									m_nIdRelatorio = Int32.Parse(m_lvRelatorios.Items[nCont].Tag.ToString());
									m_bReportAlreadyExists = true;
									break;
								}
							} 
						}
					} 
					if (!m_bReportAlreadyExists){ // Normal
						for(int nCont = 0; nCont < m_lvRelatorios.Items.Count;nCont++)
						{
							if (!m_lvRelatorios.Items[nCont].Font.Bold)
							{
								if (m_lvRelatorios.Items[nCont].Text == m_txtRelatorio.Text.Trim())
								{
									m_nIdRelatorio = Int32.Parse(m_lvRelatorios.Items[nCont].Tag.ToString());
									m_bReportAlreadyExists = true;
									break;
								}
							}                         
						} 
					}
					if (m_bReportAlreadyExists)
					{
						m_bModificado = true;
						this.Close();
					}else{
						if (m_txtRelatorio.Text.Trim() != "")
						{
							m_bModificado = true;
							m_strNomeRelatorio = m_txtRelatorio.Text.Trim();
							this.Close();
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
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Label"))
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
			}
		#endregion
		#region Refresh

		private void RefreshRelatorios()
		{
			System.Windows.Forms.ListViewItem lviItem; 
			System.Collections.SortedList sortLstRelatoriosPadrao = new System.Collections.SortedList();
			System.Collections.SortedList sortLstRelatorios = new System.Collections.SortedList();

			m_lvRelatorios.Columns[0].Width = m_lvRelatorios.Width - 30;
            m_lvRelatorios.Items.Clear();

			// Ordenando os Relatorios
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio;
			for(int nCont = 0; nCont < m_typDatSetTbRelatorios.tbRelatorios.Rows.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)m_typDatSetTbRelatorios.tbRelatorios.Rows[nCont];
				if (dtrwRelatorio.nIdRelatorio > 0)
					if (dtrwRelatorio.nIdExportador == m_nIdExportador)
						if (!sortLstRelatorios.Contains(dtrwRelatorio.strNomeRelatorio))
							sortLstRelatorios.Add(dtrwRelatorio.strNomeRelatorio,dtrwRelatorio);
			}

			// Inserindo os Relatorios na Lista View
			if (m_bMostrarPadroes)
			{ // Padroes
				for (int nCont = 0;nCont < sortLstRelatoriosPadrao.Count;nCont++)
				{
					dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)sortLstRelatoriosPadrao.GetByIndex(nCont);
		            lviItem = m_lvRelatorios.Items.Add(dtrwRelatorio.strNomeRelatorio);
		            lviItem.Tag = dtrwRelatorio.nIdRelatorio;
			        lviItem.Font = new System.Drawing.Font(lviItem.Font, System.Drawing.FontStyle.Bold);
				}
			}
			// Demais 
			for (int nCont = 0;nCont < sortLstRelatorios.Count;nCont++)
			{
				dtrwRelatorio = (mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)sortLstRelatorios.GetByIndex(nCont);
				lviItem = m_lvRelatorios.Items.Add(dtrwRelatorio.strNomeRelatorio);
				lviItem.Tag = dtrwRelatorio.nIdRelatorio;
			}
		}

		private void RefreshNomeRelatorio()
		{
			if (m_lvRelatorios.SelectedItems.Count > 0)
			{
				m_txtRelatorio.Text = m_lvRelatorios.SelectedItems[0].Text;
			}
		}
		#endregion

		#region Retorno
			public void RetornaValores(out bool bReportAlreadyExists,out bool bReportDefault,out int nIdRelatorio,out string strNomeRelatorio)
			{
				bReportAlreadyExists = m_bReportAlreadyExists;
				bReportDefault = m_bReportDefault;
				nIdRelatorio = m_nIdRelatorio;
				strNomeRelatorio = m_strNomeRelatorio;
			}
		#endregion

	}
}
