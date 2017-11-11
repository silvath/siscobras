using System;

namespace mdlDataBaseAccess
{
	/// <summary>
	/// Jet40 - Access 2000
	/// </summary>
	public class clsDataBaseAccessOleDbJet40 : clsDataBaseAccess
	{
		#region Atributos
			// ************************************************************************
			// Atributos 
			// ************************************************************************
			private System.Data.OleDb.OleDbConnection m_Connection = new System.Data.OleDb.OleDbConnection();
			private System.Data.OleDb.OleDbDataAdapter m_DataAdapter = new System.Data.OleDb.OleDbDataAdapter();
			private System.Data.OleDb.OleDbCommandBuilder m_CommandBuilder;
			private System.Data.OleDb.OleDbCommand m_CommandSelect = new System.Data.OleDb.OleDbCommand();
			private System.Data.OleDb.OleDbTransaction m_Transaction = null;

			private string m_strConnectionString = "";
			protected string m_strPathDB = "";
			// ************************************************************************
		#endregion
		#region Properties
			// ************************************************************************
			// Properties
			// ************************************************************************
			protected string ConnectionString
			{
				set
				{
					m_strConnectionString = value;
					m_Connection.ConnectionString = m_strConnectionString;
				}
				get
				{
					return(m_strConnectionString); 
				}
			}
			// ************************************************************************
		#endregion
		#region Constructor
			public clsDataBaseAccessOleDbJet40(ref mdlTratamentoErro.clsTratamentoErro TratadorErro,string strPathDB,string strUser,string strPassword) : base(ref TratadorErro,strUser,strPassword)
			{
				m_enumConnectionType = ConnectionType.PATH;

				m_strPathDB = strPathDB;

				m_CommandSelect.Connection = m_Connection;
				m_DataAdapter.SelectCommand = m_CommandSelect;
				GenerateConnectionString();
				m_CommandBuilder = new System.Data.OleDb.OleDbCommandBuilder(m_DataAdapter);
			}
		#endregion

		#region DataBase
			public override bool bServerAvailable()
			{
				return(false);
			}

			public override bool bDataBaseAvailable()
			{
				return(false);
			}
			
			public override bool bDataBaseCreate()
			{
				return(false);
			}

			public override bool bUserAvailable()
			{
				return(false);
			}

			public override bool bUserCreate()
			{
				return(false);
			}

			public override bool bUserAssociated()
			{
				return(false);
			}

			public override bool bUserAssociate()
			{
				return(false);
			}
		#endregion

		#region Configurations
			protected void GenerateConnectionString()
			{
				this.ConnectionString = "PROVIDER=MSDataShape;DATA PROVIDER=MICROSOFT.JET.OLEDB.4.0;Data Source=" + this.m_strPathDB + ";Persist Security Info=False;";
			}
		#endregion 
		#region CommandSelect 
			protected override void SetCommandSelect(string strTable,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
			{
				string strSQL = "SELECT * FROM " + strTable + " ";

				// Condicoes
				if ((arlCondicaoCampo != null ) && (arlCondicaoValor != null) && (arlCondicaoComparador != null) && (arlCondicaoCampo.Count == arlCondicaoComparador.Count) && (arlCondicaoCampo.Count == arlCondicaoValor.Count) && (arlCondicaoValor.Count > 0))
				{
					strSQL += " WHERE ";
					for (int nCont = 0; nCont < arlCondicaoCampo.Count;nCont++)
					{
						strSQL += " ( " + arlCondicaoCampo[nCont].ToString();
						switch ((mdlDataBaseAccess.Comparador)arlCondicaoComparador[nCont])
						{
							case mdlDataBaseAccess.Comparador.Igual:
								strSQL += " = "; 
								break;
							case mdlDataBaseAccess.Comparador.Diferente:
								strSQL += " <> "; 
								break;
							case mdlDataBaseAccess.Comparador.Menor:
								strSQL += " < "; 
								break;
							case mdlDataBaseAccess.Comparador.Maior:
								strSQL += " > "; 
								break;
							case mdlDataBaseAccess.Comparador.MenorOuIgual:
								strSQL += " <= "; 
								break;
							case mdlDataBaseAccess.Comparador.MaiorOuIgual:
								strSQL += " >= "; 
								break;
							default:
								strSQL += " = "; 
								break;
						}
                        if (arlCondicaoValor[nCont].GetType().ToString() == "System.String")
							strSQL += " \"" + arlCondicaoValor[nCont].ToString() + "\"  ) ";
						else
							strSQL += arlCondicaoValor[nCont].ToString() + " ) ";
                        if ((nCont + 1) < arlCondicaoCampo.Count)
							strSQL += " AND ";
					}
				}

				// Ordem 
				if ((arlOrdenacaoCampo != null ) && (arlOrdenacaoTipo != null) && (arlOrdenacaoCampo.Count > 0) && (arlOrdenacaoTipo.Count > 0) && (arlOrdenacaoCampo.Count == arlOrdenacaoTipo.Count))
				{
					strSQL += " ORDER BY ";
					for (int nCont = 0; nCont < arlOrdenacaoCampo.Count;nCont++)
					{
						strSQL += " " + arlOrdenacaoCampo[nCont].ToString() + " ";
						switch ((mdlDataBaseAccess.TipoOrdenacao)arlOrdenacaoTipo[nCont])
						{
							case mdlDataBaseAccess.TipoOrdenacao.Crescente:
								break;
							case mdlDataBaseAccess.TipoOrdenacao.Decrestente:
								strSQL += " DESC ";
								break;
						}
						if ((nCont + 1) < arlOrdenacaoCampo.Count)
							strSQL += " , ";
					}
				}
				m_CommandSelect.CommandText = strSQL;
				m_CommandBuilder.RefreshSchema();
   			}

			protected override void SetCommandSelect(string strSql)
			{
				m_CommandSelect.CommandText = strSql;
				m_CommandBuilder.RefreshSchema();
			}

			protected override string GetCommandSelect()
			{
				return(m_CommandSelect.CommandText);
			}

			protected override string strReturnCommandSelect()
			{
				return(m_CommandSelect.CommandText);
			}

			protected override string strReturnFullSelect(System.Data.DataTable dttbTable)
			{
				string strRetorno = "SELECT ";
				foreach(System.Data.DataColumn dtclColumn in dttbTable.Columns)
					strRetorno = strRetorno + dtclColumn.ColumnName + " , ";
				
				strRetorno = strRetorno.Substring(0,strRetorno.Length - 2);
				strRetorno = strRetorno + " FROM " + dttbTable.TableName;
 				return(strRetorno);
			}
		#endregion

		#region Sql
			public override System.Data.DataTable dttbExecuteSql(string sqlCommand)
			{
				System.Data.DataTable dttbRetorno = null;

				sqlCommand = sqlCommand.Trim().ToUpper();
				if (sqlCommand.StartsWith("SELECT"))
				{
					try
					{
						dttbRetorno = new System.Data.DataTable();
						SetCommandSelect(sqlCommand);
						m_excError = null;
						OpenConnection();
						m_DataAdapter.Fill(dttbRetorno);
						CloseConnection();
					}
					catch(System.Exception eEcp)
					{
						m_excError = eEcp;
					}
				}
				else
				{
					vExecuteCommand(sqlCommand);
				}
				return(dttbRetorno);
			}
		#endregion

		#region Conection
			public override bool bCanOpenConnection()
			{
				bool bRetorno = false;
				try
				{
					m_Connection.Open();
					m_Connection.Close();
					bRetorno = true;
				}
				catch
				{
				}
				return(bRetorno); 
			}

			protected override void OpenConnection()
			{
				if (m_Connection.State == 0)
					m_Connection.Open();
			}

			protected override void CloseConnection()
			{
				m_Connection.Close();
			} 
		#endregion
		#region DataAdapter
			protected override bool bErrorMessageTableDoesntExist(Exception eError, string strTableName)
			{
				return(eError.Message.IndexOf(strTableName) != -1);
			}

			protected override bool bErrorMessageColumnDoesntExist(System.Exception eError,string strColumnName)
			{
				return((eError != null) && (!eError.Message.StartsWith("Failed")));
			}

			protected override void DataAdapterFill(ref System.Data.DataSet tabela,string strNomeTabela)
			{
				if (m_bUserCanSelectDB)
				{
					try
					{
						m_excError = null;
						System.Data.DataSet dtstDadaPersist = null;
						if (m_bDataPersist)
						{
							dtstDadaPersist = vDataPersistGetData(strNomeTabela,m_CommandSelect.CommandText);
							if (dtstDadaPersist != null)
								tabela = dtstDadaPersist;
						}
						if ((!m_bDataPersist) || (dtstDadaPersist == null))
						{
							OpenConnection();
							m_DataAdapter.Fill(tabela,strNomeTabela);
							CloseConnection();
						}
						if ((m_bDataPersist) && (dtstDadaPersist == null))
							vDataPersistSetData(strNomeTabela,m_CommandSelect.CommandText,tabela);
					}
					catch(System.Exception eEcp)
					{
						m_excError = eEcp;
						m_excError.Source = strNomeTabela;
						ShowDialogFillError(strNomeTabela);
					}
				}
			}

			protected override void DataAdapterUpdate(System.Data.DataSet tabela,string strNomeTabela)
			{
				if (m_bUserCanUpdateDB)
				{
					OpenConnection();
					if (m_Connection.State == System.Data.ConnectionState.Open)
					{
						if (tabela.GetChanges() != null)
						{
							m_Transaction = m_Connection.BeginTransaction();
							m_CommandSelect.Transaction = m_Transaction;
							try
							{
								m_DataAdapter.Update(tabela,strNomeTabela);
								m_Transaction.Commit();
								DataPersist = false;
							}
							catch(System.Exception eEcp) 
							{
								m_excError = eEcp;
								m_excError.Source = strNomeTabela;
								m_Transaction.Rollback();
								ShowDialogUpdateError(strNomeTabela);
							}
						}
					}
					CloseConnection();
				}
			}
		#endregion

		#region UpdateDataBase
			protected override string strReturnTypeDataColumn(System.Data.DataColumn dtclColuna)
			{
				string strType = "";
				switch(dtclColuna.DataType.Name)
				{
					case "Int16":
						strType = "SMALLINT";
						break;
					case "Int32":
						strType = "INTEGER";
						break;
					case "String":
						if (dtclColuna.ColumnName.StartsWith("mstr"))
						{
							strType ="MEMO"; 
						}else{
							strType = "VARCHAR(255)";
						}
						break;
					case "DateTime":
						strType = "DateTime";
						break;
					case "Boolean":
							strType = "Bit";
							break;
					case "Byte[]":
						strType = "LONGBINARY";
						break;
					default:
						strType = dtclColuna.DataType.Name;
						break;
				}
				return(strType);
			} 

			protected override string strReturnCommandCreateTable(ref System.Data.DataTable dttbTable)
			{
				string strSQL = "CREATE TABLE " + dttbTable.TableName + " (";
				// Fields
				foreach(System.Data.DataColumn dtclCurrent in dttbTable.Columns)
				{
					strSQL += dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent) + ",";
				}
				// Primary Keys
				strSQL += " PRIMARY KEY ("; 
				foreach(System.Data.DataColumn dtclCurrent in dttbTable.PrimaryKey)
				{
					strSQL += dtclCurrent.ColumnName + ",";
				}
				strSQL = strSQL.Substring(0,strSQL.Length - 1);
				strSQL += " )) ;";
				return (strSQL);
			}	
			protected override string strReturnCommandAlterTableAdd(ref System.Data.DataTable dttbTable,ref System.Collections.ArrayList arlColumns)
			{
				string strSQL = "ALTER TABLE " + dttbTable.TableName + " ADD ";
				// Fields
				foreach(System.Data.DataColumn dtclCurrent in arlColumns)
				{
					strSQL += dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent) + ",";
				}
				// Primary Keys
				strSQL = strSQL.Substring(0,strSQL.Length - 1);
				strSQL += " ;";
				return (strSQL);
			}

			protected override void vExecuteCommand(string strSQL)
			{
				OpenConnection();
				m_CommandSelect.CommandText = strSQL;
				try
				{
					m_excError = null;
					m_CommandSelect.ExecuteNonQuery();
				}catch(System.Exception excErro){
					m_excError = excErro;
					m_excError.Source = strSQL;
				}
			}
		#endregion
	}
}
