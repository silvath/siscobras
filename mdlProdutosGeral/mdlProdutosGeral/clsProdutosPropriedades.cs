using System;

namespace mdlProdutosGeral
{
	/// <summary>
	/// Summary description for clsProdutosPropriedades.
	/// </summary>
	public class clsProdutosPropriedades
	{
		#region Constants
			internal const string TEXTO_MASTER = "Master";

			internal const string TEXT_COLUMN_IDORDEM = "nIdOrdem";
		#endregion
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador = -1;

			private frmFPropriedades m_frmFPropriedades = null;

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas m_typDatSetIdiomas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos m_typDatSetPropriedades = null;

			private bool m_bDataTableEvents = true;
		#endregion
		#region Properties

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas TypDatSetIdiomas
			{
				get
				{
					if (m_typDatSetIdiomas != null)
						return(m_typDatSetIdiomas);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(null,null,null,null,null);
					return(m_typDatSetIdiomas);
          		}
			}
			
			private mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos TypDatSetPropriedades
			{
				get
				{
					if (m_typDatSetPropriedades != null)
						return(m_typDatSetPropriedades);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_typDatSetPropriedades = m_cls_dba_ConnectionDB.GetTbPropriedadesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetPropriedades);
				}
			}
		#endregion
		#region Constructors
			public clsProdutosPropriedades(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD,string EnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = conexaoBD;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = nIdExportador;
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				m_frmFPropriedades = new frmFPropriedades(m_strEnderecoExecutavel);
				InitializeEvents(m_frmFPropriedades);
				m_frmFPropriedades.ShowDialog();
				return(m_frmFPropriedades.Confirmed);
			}

			private void InitializeEvents(frmFPropriedades form)
			{
				form.eCallConfigure += new mdlProdutosGeral.frmFPropriedades.delCallConfigure(BuildTableStyles);
				form.eCallRefreshPropriedades += new mdlProdutosGeral.frmFPropriedades.delCallRefreshPropriedades(RefreshPropriedades);

				form.eCallSalvaDados += new mdlProdutosGeral.frmFPropriedades.delCallSalvaDados(SalvaDados);
			}
		#endregion

		#region Salvamento dos Dados
			private bool SalvaDados()
			{
				if (!SalvaDadosPropriedades())
					return(false);
				return(true);
			}	

			private bool SalvaDadosPropriedades()
			{
				RemovendoPropriedadesIguais();
				m_cls_dba_ConnectionDB.SetTbPropriedadesProdutos(this.TypDatSetPropriedades);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private void RemovendoPropriedadesIguais()
			{
				for(int i = this.TypDatSetPropriedades.tbPropriedadesProdutos.Count - 1;i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedades = this.TypDatSetPropriedades.tbPropriedadesProdutos[i];
					if (dtrwPropriedades.RowState == System.Data.DataRowState.Deleted)
						continue;
					for(int j = (i - 1); j >= 0;j--)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedadesRemove = this.TypDatSetPropriedades.tbPropriedadesProdutos[j];
						if (dtrwPropriedadesRemove.RowState == System.Data.DataRowState.Deleted)
							continue;
						if ((dtrwPropriedades.nIdIdioma == dtrwPropriedadesRemove.nIdIdioma) && (dtrwPropriedades.mstrDescricao.Trim().ToLower() == dtrwPropriedadesRemove.mstrDescricao.Trim().ToLower()))
							dtrwPropriedadesRemove.Delete();
					}
				}
			}
		#endregion

		#region Refresh
			private bool RefreshPropriedades(ref mdlComponentesGraficos.DataGrid dgPropriedades)
			{
				m_bDataTableEvents = false;
				System.Data.DataTable dataTable = this.GetDataTableMaster();
				System.Data.DataRow[] dtrwPropriedades = this.TypDatSetPropriedades.tbPropriedadesProdutos.Select("","nIdPropriedade",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.ModifiedCurrent | System.Data.DataViewRowState.Unchanged);
				if (dtrwPropriedades != null)
				{
					int nIdPropriedade = -1;
					System.Data.DataRow dtrwInserir = null;
					bool bInserted = false;
					for(int i = 0; i < dtrwPropriedades.Length;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = (mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow)dtrwPropriedades[i];
						if (dtrwPropriedade.RowState == System.Data.DataRowState.Deleted)
							continue;
						if (nIdPropriedade != dtrwPropriedade.nIdPropriedade)
						{
							if ((dtrwInserir != null) && (!bInserted))
							{
								dataTable.Rows.Add(dtrwInserir);
								bInserted = true;
							}
							dtrwInserir = dataTable.NewRow();
							bInserted = false;
							dtrwInserir[TEXT_COLUMN_IDORDEM] = dtrwPropriedade.nIdPropriedade;
						}
						//Inserindo Propriedade no Idioma
						System.Data.DataColumn dtclColuna = dtrwInserir.Table.Columns[GetIdioma(dtrwPropriedade.nIdIdioma)];
						if (dtclColuna != null)
							dtrwInserir[dtclColuna] = dtrwPropriedade.mstrDescricao;
						if (nIdPropriedade != dtrwPropriedade.nIdPropriedade)
						{
							if (nIdPropriedade != -1)
							{
								dataTable.Rows.Add(dtrwInserir);
								bInserted = true;
							}
							nIdPropriedade = dtrwPropriedade.nIdPropriedade;
						}
					}
					if ((dtrwInserir != null) && (!bInserted))
						dataTable.Rows.Add(dtrwInserir);
				}
				dgPropriedades.DataSource = dataTable;
				m_bDataTableEvents = true;
				return(true);
			}
		#endregion

		#region TableStyles
			private bool BuildTableStyles(ref mdlComponentesGraficos.DataGrid dgPropriedades)
			{
				// Limpando os anteriores 
				dgPropriedades.TableStyles.Clear();

				// Criando o Table Style
				System.Windows.Forms.DataGridTableStyle dtgdtbstMaster = new System.Windows.Forms.DataGridTableStyle(false);

				// Configurando 
				dtgdtbstMaster.MappingName = TEXTO_MASTER;
				dtgdtbstMaster.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid;
				dtgdtbstMaster.GridLineColor = System.Drawing.Color.Gray;
				dtgdtbstMaster.AlternatingBackColor = dgPropriedades.BackColor;
				dtgdtbstMaster.BackColor = System.Drawing.Color.White;
				dtgdtbstMaster.HeaderBackColor = dgPropriedades.BackColor;
				dtgdtbstMaster.AllowSorting = false;

				// Configurando os GridColumnStyles
				dtgdtbstMaster.GridColumnStyles.Clear();

				dtgdtbstMaster.GridColumnStyles.Add(GetColumnIdOrdem());
				InsertDataGridColumnStyleIdiomas(ref dtgdtbstMaster);

				dgPropriedades.TableStyles.Add(dtgdtbstMaster);
				
				return(true);
			}
		#endregion
		#region DataGridColumnStyles
			private System.Windows.Forms.DataGridColumnStyle GetColumnIdOrdem()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_IDORDEM;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_IDORDEM;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = true;
				dtgdcsColuna.Width = 0;
				return(dtgdcsColuna);
			}

			private void InsertDataGridColumnStyleIdiomas(ref System.Windows.Forms.DataGridTableStyle dtgdtbstMaster)
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = null;
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetIdiomas = this.TypDatSetIdiomas;
				for(int i = 0; i < typDatSetIdiomas.tbIdiomas.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = typDatSetIdiomas.tbIdiomas[i];
					if (dtrwIdioma.IsmstrIdiomaNull())
						continue;
					dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
					dtgdcsColuna.MappingName = dtrwIdioma.mstrIdioma;
					dtgdcsColuna.HeaderText = dtrwIdioma.mstrIdioma;
					dtgdcsColuna.NullText = "";
					dtgdcsColuna.ReadOnly = false;
					dtgdcsColuna.Width = 100;
					dtgdtbstMaster.GridColumnStyles.Add(dtgdcsColuna);
				}
			}
		#endregion
		#region DataTable
			private System.Data.DataTable GetDataTableMaster()
			{
				System.Data.DataTable dtTable = new System.Data.DataTable(TEXTO_MASTER);

				// Changed 
				dtTable.RowChanged += new System.Data.DataRowChangeEventHandler(dtTableMaster_RowChanged);
				// Deleting 
				dtTable.RowDeleting += new System.Data.DataRowChangeEventHandler(dtTableMaster_RowDeleting);

				dtTable.Columns.Add(this.GetDataColumnIdOrdem());
				InsertDataColumnsIdiomas(ref dtTable);

				return(dtTable);
			}

			// Row Changed
			private void dtTableMaster_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
			{
				if (m_bDataTableEvents)
				{
					switch (e.Action)
					{
						case System.Data.DataRowAction.Add: // Add a Line
							DataTable_RowInserting(e.Row);
							break;
											
						case System.Data.DataRowAction.Change: // Update a Line
							DataTable_RowUpdating(e.Row);
							break;
					}
				}
			}

			// Row Inserting
			private void DataTable_RowInserting(System.Data.DataRow dtrwProduto)
			{
				int nIdPropriedade = GetNextIdPropriedade();
				mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedades = this.TypDatSetPropriedades;
				for(int i = 0;i < dtrwProduto.Table.Columns.Count;i++)
				{
					System.Data.DataColumn dtclColuna = dtrwProduto.Table.Columns[i];
					int nIdIdioma = GetIdIdioma(dtclColuna.ColumnName);
					if (nIdIdioma == -1)
						continue;
					string strDescricao = dtrwProduto[dtclColuna].ToString();
					if ((strDescricao == null) || (strDescricao.Trim() == ""))
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedades.tbPropriedadesProdutos.NewtbPropriedadesProdutosRow();
					dtrwPropriedade.nIdExportador = m_nIdExportador;
					dtrwPropriedade.nIdIdioma = nIdIdioma;
				    dtrwPropriedade.nIdPropriedade = nIdPropriedade;
				    dtrwPropriedade.mstrDescricao = strDescricao;
					typDatSetPropriedades.tbPropriedadesProdutos.AddtbPropriedadesProdutosRow(dtrwPropriedade);
				}
			}

			// Row Updating
			private void DataTable_RowUpdating(System.Data.DataRow dtrwProduto)
			{
				//Removendo ...
				int nIdPropriedade = Int32.Parse(dtrwProduto[TEXT_COLUMN_IDORDEM].ToString());
				mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedades = this.TypDatSetPropriedades;
				for(int i = typDatSetPropriedades.tbPropriedadesProdutos.Count - 1;i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedades.tbPropriedadesProdutos[i];
					if (dtrwPropriedade.nIdPropriedade == nIdPropriedade)
						dtrwPropriedade.Delete();
				}
				// Inserindo
				for(int i = 0;i < dtrwProduto.Table.Columns.Count;i++)
				{
					System.Data.DataColumn dtclColuna = dtrwProduto.Table.Columns[i];
					int nIdIdioma = GetIdIdioma(dtclColuna.ColumnName);
					if (nIdIdioma == -1)
						continue;
					string strDescricao = dtrwProduto[dtclColuna].ToString();
					if ((strDescricao == null) || (strDescricao.Trim() == ""))
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedades.tbPropriedadesProdutos.NewtbPropriedadesProdutosRow();
					dtrwPropriedade.nIdExportador = m_nIdExportador;
					dtrwPropriedade.nIdIdioma = nIdIdioma;
					dtrwPropriedade.nIdPropriedade = nIdPropriedade;
					dtrwPropriedade.mstrDescricao = strDescricao;
					typDatSetPropriedades.tbPropriedadesProdutos.AddtbPropriedadesProdutosRow(dtrwPropriedade);
				}
			}

			// Row Deleting
			private void dtTableMaster_RowDeleting(object sender, System.Data.DataRowChangeEventArgs e)
			{
				int nIdPropriedade = Int32.Parse(e.Row[TEXT_COLUMN_IDORDEM].ToString());
                mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedades = this.TypDatSetPropriedades;
				for(int i = typDatSetPropriedades.tbPropriedadesProdutos.Count - 1;i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedades.tbPropriedadesProdutos[i];
					if (dtrwPropriedade.RowState == System.Data.DataRowState.Deleted)
						continue;
					if (dtrwPropriedade.nIdPropriedade == nIdPropriedade)
						dtrwPropriedade.Delete();
				}
			}
		#endregion
		#region DataColumns
			private System.Data.DataColumn GetDataColumnIdOrdem()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_IDORDEM);
				dtclRetorno.ReadOnly = true;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private void InsertDataColumnsIdiomas(ref System.Data.DataTable dtTable)
			{
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetIdiomas = this.TypDatSetIdiomas;
				for(int i = 0; i < typDatSetIdiomas.tbIdiomas.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = typDatSetIdiomas.tbIdiomas[i];
					if (dtrwIdioma.IsmstrIdiomaNull())
						continue;
					System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(dtrwIdioma.mstrIdioma);
					dtclRetorno.ReadOnly = false;
					dtclRetorno.DataType = System.Type.GetType("System.String");
					dtclRetorno.DefaultValue = "";
					dtTable.Columns.Add(dtclRetorno);
				}
			}
		#endregion

		#region Idiomas
			private int GetIdIdioma(string strIdioma)
			{
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetIdiomas = this.TypDatSetIdiomas;
				for(int i = 0; i < typDatSetIdiomas.tbIdiomas.Count;i++)
					if (typDatSetIdiomas.tbIdiomas[i].mstrIdioma == strIdioma)
						return(typDatSetIdiomas.tbIdiomas[i].idIdioma);
				return(-1);
			}

			private string GetIdioma(int nIdIdioma)
			{
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = this.TypDatSetIdiomas.tbIdiomas.FindByidIdioma(nIdIdioma);
				if (dtrwIdioma == null)
					return("");
				return(dtrwIdioma.mstrIdioma);
			}
		#endregion
		#region Propriedades
			private int GetNextIdPropriedade()
			{
				int nId = 1;
				mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedades = this.TypDatSetPropriedades;
				System.Data.DataRow[] dtrwPropriedades = typDatSetPropriedades.tbPropriedadesProdutos.Select("","nIdPropriedade",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.ModifiedCurrent | System.Data.DataViewRowState.Unchanged);
				if ((dtrwPropriedades != null) && (dtrwPropriedades.Length > 0))
					nId = Int32.Parse(dtrwPropriedades[dtrwPropriedades.Length - 1]["nIdPropriedade"].ToString()) + 1;
				return(nId);
			}
		#endregion

		#region PropriedadesFaturas
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades GetPropriedadesFaturaCotacao(int nIdPropriedade)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("nIdPropriedade");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdPropriedade);

				return(m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacaoPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades GetPropriedadesFaturaProforma(int nIdPropriedade)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("nIdPropriedade");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdPropriedade);

				return(m_cls_dba_ConnectionDB.GetTbProdutosFaturaProformaPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades GetPropriedadesFaturaComercial(int nIdPropriedade)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("nIdPropriedade");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdPropriedade);

				return(m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercialPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}
			
			private bool IsPropriedadeVinculadaFatura(int nIdPropriedade)
			{
				if (GetPropriedadesFaturaCotacao(nIdPropriedade).tbProdutosFaturaCotacaoPropriedades.Rows.Count > 0)
					return(true);
				if (GetPropriedadesFaturaProforma(nIdPropriedade).tbProdutosFaturaProformaPropriedades.Rows.Count > 0)
					return(true);
				if (GetPropriedadesFaturaComercial(nIdPropriedade).tbProdutosFaturaComercialPropriedades.Rows.Count > 0)
					return(true);
				return(false);
			}
		#endregion

	}
}

