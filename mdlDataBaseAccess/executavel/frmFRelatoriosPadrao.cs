using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace executavel
{
	/// <summary>
	/// Summary description for frmFRelatoriosPadrao.
	/// </summary>
	public class frmFRelatoriosPadrao : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strPathXmlFiles = "C:\\";
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorios m_typDatSetTbRelatorios = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas m_typDatSetTbRelatorioLinhas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos m_typDatSetTbRelatorioRetangulos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos m_typDatSetTbRelatorioCirculos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens m_typDatSetTbRelatorioImagens = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas m_typDatSetTbRelatorioEtiquetas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD m_typDatSetTbRelatorioCamposBD = null;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.ListView m_lvRelatorios;
			private System.Windows.Forms.ColumnHeader m_colhTipo;
			private System.Windows.Forms.ColumnHeader m_colhRelatorio;
			private System.Windows.Forms.ColumnHeader m_colhExportador;
			private System.Windows.Forms.ColumnHeader m_colhNome;
			private	System.Windows.Forms.Button m_btGenerate;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor
			public frmFRelatoriosPadrao(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lvRelatorios = new System.Windows.Forms.ListView();
			this.m_colhTipo = new System.Windows.Forms.ColumnHeader();
			this.m_colhRelatorio = new System.Windows.Forms.ColumnHeader();
			this.m_colhExportador = new System.Windows.Forms.ColumnHeader();
			this.m_colhNome = new System.Windows.Forms.ColumnHeader();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btGenerate = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btGenerate);
			this.m_gbGeral.Controls.Add(this.m_lvRelatorios);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(448, 304);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lvRelatorios
			// 
			this.m_lvRelatorios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.m_colhTipo,
																							 this.m_colhRelatorio,
																							 this.m_colhExportador,
																							 this.m_colhNome});
			this.m_lvRelatorios.FullRowSelect = true;
			this.m_lvRelatorios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lvRelatorios.HideSelection = false;
			this.m_lvRelatorios.Location = new System.Drawing.Point(10, 16);
			this.m_lvRelatorios.MultiSelect = false;
			this.m_lvRelatorios.Name = "m_lvRelatorios";
			this.m_lvRelatorios.Size = new System.Drawing.Size(430, 248);
			this.m_lvRelatorios.TabIndex = 2;
			this.m_lvRelatorios.View = System.Windows.Forms.View.Details;
			this.m_lvRelatorios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvRelatorios_KeyDown);
			this.m_lvRelatorios.DoubleClick += new System.EventHandler(this.m_lvRelatorios_DoubleClick);
			// 
			// m_colhTipo
			// 
			this.m_colhTipo.Text = "Tipo";
			this.m_colhTipo.Width = 50;
			// 
			// m_colhRelatorio
			// 
			this.m_colhRelatorio.Text = "Relatorio";
			// 
			// m_colhExportador
			// 
			this.m_colhExportador.Text = "Exportador";
			this.m_colhExportador.Width = 76;
			// 
			// m_colhNome
			// 
			this.m_colhNome.Text = "Nome";
			this.m_colhNome.Width = 239;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Location = new System.Drawing.Point(232, 272);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.Size = new System.Drawing.Size(72, 24);
			this.m_btCancelar.TabIndex = 1;
			this.m_btCancelar.Text = "Cancelar";
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Location = new System.Drawing.Point(152, 272);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(72, 24);
			this.m_btOk.TabIndex = 0;
			this.m_btOk.Text = "Ok";
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btGenerate
			// 
			this.m_btGenerate.Location = new System.Drawing.Point(12, 272);
			this.m_btGenerate.Name = "m_btGenerate";
			this.m_btGenerate.Size = new System.Drawing.Size(72, 24);
			this.m_btGenerate.TabIndex = 3;
			this.m_btGenerate.Text = "Generate";
			this.m_btGenerate.Click += new System.EventHandler(this.m_btGenerate_Click);
			// 
			// frmFRelatoriosPadrao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 310);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosPadrao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Relatorios Padrão";
			this.Load += new System.EventHandler(this.frmFRelatoriosPadrao_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFRelatoriosPadrao_Load(object sender, System.EventArgs e)
				{
					vCarregaDados();
					vRefreshRelatorios();
				}
			#endregion
			#region ListView
				private void m_lvRelatorios_DoubleClick(object sender, System.EventArgs e)
				{
					if (bRelatorioSelecionadoAtualiza())
						vRefreshRelatorios();
				}

				private void m_lvRelatorios_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					switch (e.KeyCode)
					{
						case System.Windows.Forms.Keys.Delete:
							if (bRelatorioSelecionadoRemove())
								vRefreshRelatorios();
							break;
					}
				}
			#endregion
			#region Botoes
				private void m_btGenerate_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					vGenerateXmlFiles();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					System.Windows.Forms.MessageBox.Show("XML criados");
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					vSalvaDados();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDados()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbRelatorios = m_cls_dba_ConnectionDB.GetTbRelatorios(null,null,null,null,null);
				m_typDatSetTbRelatorioLinhas = m_cls_dba_ConnectionDB.GetTbRelatorioLinhas(null,null,null,null,null);
				m_typDatSetTbRelatorioRetangulos = m_cls_dba_ConnectionDB.GetTbRelatorioRetangulos(null,null,null,null,null);
				m_typDatSetTbRelatorioCirculos = m_cls_dba_ConnectionDB.GetTbRelatorioCirculos(null,null,null,null,null);
				m_typDatSetTbRelatorioImagens = m_cls_dba_ConnectionDB.GetTbRelatorioImagens(null,null,null,null,null);
				m_typDatSetTbRelatorioEtiquetas = m_cls_dba_ConnectionDB.GetTbRelatorioEtiquetas(null,null,null,null,null);
				m_typDatSetTbRelatorioCamposBD = m_cls_dba_ConnectionDB.GetTbRelatorioCamposBD(null,null,null,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private void vSalvaDados()
			{
				m_cls_dba_ConnectionDB.CheckIntegrityUpdate = false;
				m_cls_dba_ConnectionDB.SetTbRelatorioLinhas(m_typDatSetTbRelatorioLinhas);
				m_cls_dba_ConnectionDB.SetTbRelatorioRetangulos(m_typDatSetTbRelatorioRetangulos);
				m_cls_dba_ConnectionDB.SetTbRelatorioCirculos(m_typDatSetTbRelatorioCirculos);
				m_cls_dba_ConnectionDB.SetTbRelatorioImagens(m_typDatSetTbRelatorioImagens);
				m_cls_dba_ConnectionDB.SetTbRelatorioEtiquetas(m_typDatSetTbRelatorioEtiquetas);
				m_cls_dba_ConnectionDB.SetTbRelatorioCamposBD(m_typDatSetTbRelatorioCamposBD);
			    m_cls_dba_ConnectionDB.SetTbRelatorios(m_typDatSetTbRelatorios);
			}
		#endregion

		#region Relatorios
			private void vRefreshRelatorios()
			{
				m_lvRelatorios.Items.Clear();
				System.Windows.Forms.ListViewItem lviItem = null;
				for (int i = 0; i < 40;i++)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio in m_typDatSetTbRelatorios.tbRelatorios.Rows)
					{
						if (dtrwRelatorio.RowState != System.Data.DataRowState.Deleted)
						{
							if (i == dtrwRelatorio.nIdTipo)
							{
								lviItem = m_lvRelatorios.Items.Add(dtrwRelatorio.nIdTipo.ToString());
								lviItem.SubItems.Add(dtrwRelatorio.nIdRelatorio.ToString());
								lviItem.SubItems.Add(dtrwRelatorio.nIdExportador.ToString());
								lviItem.SubItems.Add(dtrwRelatorio.strNomeRelatorio);
								switch(dtrwRelatorio.RowState)
								{
									case System.Data.DataRowState.Unchanged:
										lviItem.ForeColor = System.Drawing.Color.Red;
										break;
									case System.Data.DataRowState.Modified:
										lviItem.ForeColor = System.Drawing.Color.Green;
										break;
								}
							}
						}
					}
				}
			}

			private bool bRelatorioSelecionadoRemove()
			{
				bool bRetorno = false;
				if (m_lvRelatorios.SelectedItems.Count > 0)
				{
					int nIdTipo = Int32.Parse(m_lvRelatorios.SelectedItems[0].Text);
					int nIdRelatorio = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[1].Text);
					int nIdExportador = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[2].Text);
					if (bRetorno = (System.Windows.Forms.MessageBox.Show("Deseja mesmo remover este relatorio?","Relatorios Padrao",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes))
						vRelatorioRemove(nIdTipo,nIdRelatorio,nIdExportador);
				}
				return(bRetorno);
			}

			private void vRelatorioRemove(int nIdTipo,int nIdRelatorio,int nIdExportador)
			{
				// tbRelatorios
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio in m_typDatSetTbRelatorios.tbRelatorios.Rows)
				{
					if (dtrwRelatorio.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwRelatorio.nIdTipo == nIdTipo) && (dtrwRelatorio.nIdRelatorio == nIdRelatorio) && (dtrwRelatorio.nIdExportador == nIdExportador))
							dtrwRelatorio.Delete();
				}

				// tbRelatoriosLinhas
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasRow dtrwLinha in m_typDatSetTbRelatorioLinhas.tbRelatorioLinhas.Rows)
				{
					if (dtrwLinha.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwLinha.nIdTipo == nIdTipo) && (dtrwLinha.nIdRelatorio == nIdRelatorio) && (dtrwLinha.nIdExportador == nIdExportador))
							dtrwLinha.Delete();
				}

				// tbRelatoriosRetangulos
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosRow dtrwRetangulo in m_typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows)
				{
					if (dtrwRetangulo.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwRetangulo.nIdTipo == nIdTipo) && (dtrwRetangulo.nIdRelatorio == nIdRelatorio) && (dtrwRetangulo.nIdExportador == nIdExportador))
							dtrwRetangulo.Delete();
				}

				// tbRelatoriosCirculos
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosRow dtrwCirculo in m_typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows)
				{
					if (dtrwCirculo.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwCirculo.nIdTipo == nIdTipo) && (dtrwCirculo.nIdRelatorio == nIdRelatorio) && (dtrwCirculo.nIdExportador == nIdExportador))
							dtrwCirculo.Delete();
				}

				// tbRelatoriosImagens
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensRow dtrwImagem in m_typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows)
				{
					if (dtrwImagem.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwImagem.nIdTipo == nIdTipo) && (dtrwImagem.nIdRelatorio == nIdRelatorio) && (dtrwImagem.nIdExportador == nIdExportador))
							dtrwImagem.Delete();
				}

				// tbRelatoriosEtiquetas
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasRow dtrwEtiqueta in m_typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows)
				{
					if (dtrwEtiqueta.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwEtiqueta.nIdTipo == nIdTipo) && (dtrwEtiqueta.nIdRelatorio == nIdRelatorio) && (dtrwEtiqueta.nIdExportador == nIdExportador))
							dtrwEtiqueta.Delete();
				}

				// tbRelatoriosCamposBD
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDRow dtrwCampoBD in m_typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows)
				{
					if (dtrwCampoBD.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwCampoBD.nIdTipo == nIdTipo) && (dtrwCampoBD.nIdRelatorio == nIdRelatorio) && (dtrwCampoBD.nIdExportador == nIdExportador))
							dtrwCampoBD.Delete();
				}
			}

			private bool bRelatorioSelecionadoAtualiza()
			{
				bool bRetorno = false;
				if (m_lvRelatorios.SelectedItems.Count > 0)
				{
					int nIdTipo = Int32.Parse(m_lvRelatorios.SelectedItems[0].Text);
					int nIdRelatorio = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[1].Text);
					int nIdExportador = Int32.Parse(m_lvRelatorios.SelectedItems[0].SubItems[2].Text);
					frmFRelatorioPadraoModificar formFRelatorioPadraoModificar = new frmFRelatorioPadraoModificar(nIdTipo,nIdRelatorio,nIdExportador,m_lvRelatorios.SelectedItems[0].SubItems[3].Text);
					formFRelatorioPadraoModificar.ShowDialog();
					if (bRetorno = formFRelatorioPadraoModificar.m_bModificado)
					{
						int nIdTipoNovo;
						int nIdRelatorioNovo; 
						int nIdExportadorNovo; 
						string strNomeNovo;
						formFRelatorioPadraoModificar.vRetornoValores(out nIdExportadorNovo,out nIdTipoNovo,out nIdRelatorioNovo,out strNomeNovo);
						vRelatorioSelecionadoAtualiza(nIdTipo,nIdRelatorio,nIdExportador,nIdTipoNovo,nIdRelatorioNovo,nIdExportadorNovo,strNomeNovo);
					}
				}
				return(bRetorno);
			}

			private void vRelatorioSelecionadoAtualiza(int nIdTipo,int nIdRelatorio,int nIdExportador,int nIdTipoNew,int nIdRelatorioNew,int nIdExportadorNew,string strNomeNew)
			{
				// tbRelatorios
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwRelatorio in m_typDatSetTbRelatorios.tbRelatorios.Rows)
				{
					if (dtrwRelatorio.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwRelatorio.nIdTipo == nIdTipo) && (dtrwRelatorio.nIdRelatorio == nIdRelatorio) && (dtrwRelatorio.nIdExportador == nIdExportador))
						{
							dtrwRelatorio.nIdTipo = nIdTipoNew;
							dtrwRelatorio.nIdRelatorio = nIdRelatorioNew;
							dtrwRelatorio.nIdExportador = nIdExportadorNew;
							dtrwRelatorio.strNomeRelatorio = strNomeNew;
						}
				}

				// tbRelatoriosLinhas
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasRow dtrwLinha in m_typDatSetTbRelatorioLinhas.tbRelatorioLinhas.Rows)
				{
					if (dtrwLinha.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwLinha.nIdTipo == nIdTipo) && (dtrwLinha.nIdRelatorio == nIdRelatorio) && (dtrwLinha.nIdExportador == nIdExportador))
						{
							dtrwLinha.nIdTipo = nIdTipoNew;
							dtrwLinha.nIdRelatorio = nIdRelatorioNew;
							dtrwLinha.nIdExportador = nIdExportadorNew;
						}
				}

				// tbRelatoriosRetangulos
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosRow dtrwRetangulo in m_typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos.Rows)
				{
					if (dtrwRetangulo.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwRetangulo.nIdTipo == nIdTipo) && (dtrwRetangulo.nIdRelatorio == nIdRelatorio) && (dtrwRetangulo.nIdExportador == nIdExportador))
						{
							dtrwRetangulo.nIdTipo = nIdTipoNew;
							dtrwRetangulo.nIdRelatorio = nIdRelatorioNew;
							dtrwRetangulo.nIdExportador = nIdExportadorNew;
						}
				}

				// tbRelatoriosCirculos
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosRow dtrwCirculo in m_typDatSetTbRelatorioCirculos.tbRelatorioCirculos.Rows)
				{
					if (dtrwCirculo.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwCirculo.nIdTipo == nIdTipo) && (dtrwCirculo.nIdRelatorio == nIdRelatorio) && (dtrwCirculo.nIdExportador == nIdExportador))
						{
							dtrwCirculo.nIdTipo = nIdTipoNew;
							dtrwCirculo.nIdRelatorio = nIdRelatorioNew;
							dtrwCirculo.nIdExportador = nIdExportadorNew;
						}
				}

				// tbRelatoriosImagens
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensRow dtrwImagem in m_typDatSetTbRelatorioImagens.tbRelatorioImagens.Rows)
				{
					if (dtrwImagem.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwImagem.nIdTipo == nIdTipo) && (dtrwImagem.nIdRelatorio == nIdRelatorio) && (dtrwImagem.nIdExportador == nIdExportador))
						{
							dtrwImagem.nIdTipo = nIdTipoNew;
							dtrwImagem.nIdRelatorio = nIdRelatorioNew;
							dtrwImagem.nIdExportador = nIdExportadorNew;
						}
				}

				// tbRelatoriosEtiquetas
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasRow dtrwEtiqueta in m_typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas.Rows)
				{
					if (dtrwEtiqueta.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwEtiqueta.nIdTipo == nIdTipo) && (dtrwEtiqueta.nIdRelatorio == nIdRelatorio) && (dtrwEtiqueta.nIdExportador == nIdExportador))
						{
							dtrwEtiqueta.nIdTipo = nIdTipoNew;
							dtrwEtiqueta.nIdRelatorio = nIdRelatorioNew;
							dtrwEtiqueta.nIdExportador = nIdExportadorNew;
						}
				}

				// tbRelatoriosCamposBD
				foreach(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDRow dtrwCampoBD in m_typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD.Rows)
				{
					if (dtrwCampoBD.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwCampoBD.nIdTipo == nIdTipo) && (dtrwCampoBD.nIdRelatorio == nIdRelatorio) && (dtrwCampoBD.nIdExportador == nIdExportador))
						{
							dtrwCampoBD.nIdTipo = nIdTipoNew;
							dtrwCampoBD.nIdRelatorio = nIdRelatorioNew;
							dtrwCampoBD.nIdExportador = nIdExportadorNew;
						}
				}
			}
		#endregion
		#region Generate
			private void vGenerateXmlFiles()
			{
				m_typDatSetTbRelatorios.WriteXml(m_strPathXmlFiles + "XmlTbRelatorios.xml");
				m_typDatSetTbRelatorioLinhas.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioLinhas.xml");
				m_typDatSetTbRelatorioRetangulos.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioRetangulos.xml");
				m_typDatSetTbRelatorioCirculos.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioCirculos.xml");
				m_typDatSetTbRelatorioImagens.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioImagens.xml");
				m_typDatSetTbRelatorioEtiquetas.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioEtiquetas.xml");
				m_typDatSetTbRelatorioCamposBD.WriteXml(m_strPathXmlFiles + "XmlTbRelatorioCamposBD.xml");
			}
		#endregion
	}
}
