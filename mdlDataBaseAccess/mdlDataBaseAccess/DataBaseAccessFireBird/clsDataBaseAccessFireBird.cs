using System;

namespace mdlDataBaseAccess
{
	/// <summary>
	/// FireBird
	/// </summary>
//	public class clsDataBaseAccessFireBird :clsDataBaseAccess
//	{
//		#region Atributos
//		// ************************************************************************
//		// Atributos 
//		// ************************************************************************
//		private FirebirdSql.Data.Firebird.FbConnection m_Connection = new FirebirdSql.Data.Firebird.FbConnection();
//		private FirebirdSql.Data.Firebird.FbDataAdapter m_DataAdapter = new FirebirdSql.Data.Firebird.FbDataAdapter();
//		private FirebirdSql.Data.Firebird.FbCommandBuilder m_CommandBuilder;
//		private FirebirdSql.Data.Firebird.FbCommand m_CommandSelect = new FirebirdSql.Data.Firebird.FbCommand();
//		private FirebirdSql.Data.Firebird.FbTransaction m_Transaction = null;
//
//		private string m_strHost = "";
//		private string m_strPort = "";
//		private string m_strDataBaseName = "";
//
//		private string m_strConnectionString = "";
//		// ************************************************************************
//		#endregion
//		#region Properties
//		// ************************************************************************
//		// Properties
//		// ************************************************************************
//		protected string ConnectionString
//		{
//			set
//			{
//				m_strConnectionString = value;
//				m_Connection.ConnectionString = m_strConnectionString;
//			}
//			get
//			{
//				return(m_strConnectionString); 
//			}
//		}
//		// ************************************************************************
//		#endregion
//		#region Constructor
//		public clsDataBaseAccessFireBird(ref mdlTratamentoErro.clsTratamentoErro TratadorErro,string strHost,string strPort,string strDataBaseName,string strUser,string strPassword) : base(ref TratadorErro,strUser,strPassword)
//		{
//			m_enumConnectionType = ConnectionType.PATH;
//
//			m_strHost = strHost;
//			m_strPort = m_strPort;
//			m_strDataBaseName = strDataBaseName;
//
//			GenerateConnectionString();
//			m_DataAdapter = new FirebirdSql.Data.Firebird.FbDataAdapter();
//			m_CommandSelect = new FirebirdSql.Data.Firebird.FbCommand();
//			m_CommandSelect.Connection =  m_Connection;
//			m_DataAdapter.SelectCommand = m_CommandSelect;
//			m_CommandBuilder = new FirebirdSql.Data.Firebird.FbCommandBuilder(m_DataAdapter);
//		}
//		#endregion
//
//		#region Configurations
//		protected void GenerateConnectionString()
//		{
//			string strConnectionString = "Server=" + m_strHost + ";" + "Database=" + m_strDataBaseName + ";" + "User ID=" + m_strUser + ";" + "Password=" + m_strPassword + ";";
//			m_Connection = new FirebirdSql.Data.Firebird.FbConnection(strConnectionString);
//		}
//		#endregion 
//		#region CommandSelect 
//		protected override void SetCommandSelect(string strTable,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
//		{
//			string strSQL = "SELECT * FROM " + strTable + " ";
//
//			// Condicoes
//			if ((arlCondicaoCampo != null ) && (arlCondicaoValor != null) && (arlCondicaoComparador != null) && (arlCondicaoCampo.Count == arlCondicaoComparador.Count) && (arlCondicaoCampo.Count == arlCondicaoValor.Count) && (arlCondicaoValor.Count > 0))
//			{
//				strSQL += " WHERE ";
//				for (int nCont = 0; nCont < arlCondicaoCampo.Count;nCont++)
//				{
//					strSQL += " ( " + arlCondicaoCampo[nCont].ToString();
//					switch ((mdlDataBaseAccess.Comparador)arlCondicaoComparador[nCont])
//					{
//						case mdlDataBaseAccess.Comparador.Igual:
//							strSQL += " = "; 
//							break;
//						case mdlDataBaseAccess.Comparador.Diferente:
//							strSQL += " <> "; 
//							break;
//						case mdlDataBaseAccess.Comparador.Menor:
//							strSQL += " < "; 
//							break;
//						case mdlDataBaseAccess.Comparador.Maior:
//							strSQL += " > "; 
//							break;
//						case mdlDataBaseAccess.Comparador.MenorOuIgual:
//							strSQL += " <= "; 
//							break;
//						case mdlDataBaseAccess.Comparador.MaiorOuIgual:
//							strSQL += " >= "; 
//							break;
//						default:
//							strSQL += " = "; 
//							break;
//					}
//					if (arlCondicaoValor[nCont].GetType().ToString() == "System.String")
//						strSQL += " '" + arlCondicaoValor[nCont].ToString() + "'  ) ";
//					else
//						strSQL += arlCondicaoValor[nCont].ToString() + " ) ";
//					if ((nCont + 1) < arlCondicaoCampo.Count)
//						strSQL += " AND ";
//				}
//			}
//
//			// Ordem 
//			if ((arlOrdenacaoCampo != null ) && (arlOrdenacaoTipo != null) && (arlOrdenacaoCampo.Count > 0) && (arlOrdenacaoTipo.Count > 0) && (arlOrdenacaoCampo.Count == arlOrdenacaoTipo.Count))
//			{
//				strSQL += " ORDER BY ";
//				for (int nCont = 0; nCont < arlOrdenacaoCampo.Count;nCont++)
//				{
//					strSQL += " " + arlOrdenacaoCampo[nCont].ToString() + " ";
//					switch ((mdlDataBaseAccess.TipoOrdenacao)arlOrdenacaoTipo[nCont])
//					{
//						case mdlDataBaseAccess.TipoOrdenacao.Crescente:
//							break;
//						case mdlDataBaseAccess.TipoOrdenacao.Decrestente:
//							strSQL += " DESC ";
//							break;
//					}
//					if ((nCont + 1) < arlOrdenacaoCampo.Count)
//						strSQL += " , ";
//				}
//			}
//			m_CommandSelect.CommandText = strSQL;
//			m_CommandBuilder.RefreshSchema();
//		}
//
//		protected override void SetCommandSelect(string strSql)
//		{
//			m_CommandSelect.CommandText = strSql;
//			m_CommandBuilder.RefreshSchema();
//		}
//
//		protected override string GetCommandSelect()
//		{
//			return(m_CommandSelect.CommandText);
//		}
//
//		protected override string strReturnCommandSelect()
//		{
//			return(m_CommandSelect.CommandText);
//		}
//
//		protected override string strReturnFullSelect(System.Data.DataTable dttbTable)
//		{
//			string strRetorno = "SELECT ";
//			foreach(System.Data.DataColumn dtclColumn in dttbTable.Columns)
//				strRetorno = strRetorno + dtclColumn.ColumnName + " , ";
//			strRetorno = strRetorno.Substring(0,strRetorno.Length - 2);
//			strRetorno = strRetorno + " FROM " + dttbTable.TableName;
//			return(strRetorno);
//		}
//		#endregion
//
//		#region Sql
//		public override System.Data.DataTable dttbExecuteSql(string sqlCommand)
//		{
//			System.Data.DataTable dttbRetorno = null;
//
//			sqlCommand = sqlCommand.Trim().ToUpper();
//			if (sqlCommand.StartsWith("SELECT"))
//			{
//				try
//				{
//					dttbRetorno = new System.Data.DataTable();
//					SetCommandSelect(sqlCommand);
//					m_excError = null;
//					OpenConnection();
//					m_DataAdapter.Fill(dttbRetorno);
//					CloseConnection();
//				}
//				catch(System.Exception eEcp)
//				{
//					m_excError = eEcp;
//				}
//			}
//			else
//			{
//				vExecuteCommand(sqlCommand);
//			}
//			return(dttbRetorno);
//		}
//		#endregion
//
//		#region Conection
//		public override bool bCanOpenConnection()
//		{
//			bool bRetorno = false;
//			try
//			{
//				m_Connection.Open();
//				m_Connection.Close();
//				bRetorno = true;
//			}
//			catch
//			{
//			}
//			return(bRetorno); 
//		}
//
//		protected override void OpenConnection()
//		{
//			if (m_Connection.State == 0)
//				m_Connection.Open();
//		}
//
//		protected override void CloseConnection()
//		{
//			m_Connection.Close();
//		} 
//		#endregion
//		#region DataAdapter
//			protected override void DataAdapterFill(ref System.Data.DataSet tabela,string strNomeTabela)
//			{
//				if (m_bUserCanSelectDB)
//				{
//					try
//					{
//						m_excError = null;
//						System.Data.DataSet dtstDadaPersist = null;
//						if (m_bDataPersist)
//						{
//							dtstDadaPersist = vDataPersistGetData(strNomeTabela,m_CommandSelect.CommandText);
//							if (dtstDadaPersist != null)
//								tabela = dtstDadaPersist;
//						}
//						if ((!m_bDataPersist) || (dtstDadaPersist == null))
//						{
//							OpenConnection();
//							m_DataAdapter.Fill(tabela,strNomeTabela);
//							CloseConnection();
//						}
//						if ((m_bDataPersist) && (dtstDadaPersist == null))
//							vDataPersistSetData(strNomeTabela,m_CommandSelect.CommandText,tabela);
//					}
//					catch(System.Exception eEcp)
//					{
//						m_excError = eEcp;
//						ShowDialogFillError(strNomeTabela);
//					}
//				}
//			}
//
//			protected override void DataAdapterUpdate(System.Data.DataSet tabela,string strNomeTabela)
//			{
//				if (m_bUserCanUpdateDB)
//				{
//					OpenConnection();
//					if (m_Connection.State == System.Data.ConnectionState.Open)
//					{
//						if (tabela.GetChanges() != null)
//						{
//							m_Transaction = m_Connection.BeginTransaction();
//							m_CommandSelect.Transaction = m_Transaction;
//							try
//							{
//								m_DataAdapter.Update(tabela,strNomeTabela);
//								m_Transaction.Commit();
//								DataPersist = false;
//							}
//							catch(System.Exception eEcp) 
//							{
//								m_excError = eEcp;
//								m_Transaction.Rollback();
//								ShowDialogUpdateError(strNomeTabela);
//							}
//						}
//					}
//					CloseConnection();
//				}
//			}
//		#endregion
//
//		#region UpdateDataBase
//			protected override bool bErrorMessageTableDoesntExist(Exception eError, string strTableName)
//			{
//				return(eError.Message.IndexOf(strTableName.ToUpper()) != -1);
//			}
//
//		protected override string strReturnTypeDataColumn(System.Data.DataColumn dtclColuna)
//		{
//			string strType = "";
//			switch(dtclColuna.DataType.Name)
//			{
//				case "Int16":
//					strType = "SMALLINT";
//					break;
//				case "Int32":
//					strType = "INTEGER";
//					break;
//				case "String":
//					if (dtclColuna.ColumnName.StartsWith("mstr"))
//					{
//						strType ="BLOB"; 
//					}
//					else
//					{
//						strType = "VARCHAR(255)";
//					}
//					break;
//				case "DateTime":
//					strType = "TIMESTAMP";
//					break;
//				case "Boolean":
//					strType = "SMALLINT";
//					break;
//				case "Byte[]":
//					strType = "VARBINARY";
//					break;
//				case "Double":
//					strType = "FLOAT";
//					break;
//				default:
//					strType = dtclColuna.DataType.Name;
//					break;
//			}
//			return(strType);
//		} 
//
//		private string strReturnCommandCreateTableConstraintNotNull(ref System.Data.DataTable dttbTable,string strColumnName)
//		{
//			string strReturn = "";
//			foreach(System.Data.DataColumn dtclCurrent in dttbTable.PrimaryKey)
//			{
//				if (dtclCurrent.ColumnName == strColumnName)
//				{
//					return(" NOT NULL ");
//				}
//			}
//			return(strReturn);
//		}
//
//		protected override string strReturnCommandCreateTable(ref System.Data.DataTable dttbTable)
//		{
//			string strSQL = "CREATE TABLE " + dttbTable.TableName + " (";
//			// Fields
//			foreach(System.Data.DataColumn dtclCurrent in dttbTable.Columns)
//			{
//				strSQL += dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent) + strReturnCommandCreateTableConstraintNotNull(ref dttbTable,dtclCurrent.ColumnName) + ",";
//			}
//			// Primary Keys
//			strSQL += " PRIMARY KEY ("; 
//			foreach(System.Data.DataColumn dtclCurrent in dttbTable.PrimaryKey)
//			{
//				strSQL += dtclCurrent.ColumnName + ",";
//			}
//			strSQL = strSQL.Substring(0,strSQL.Length - 1);
//			strSQL += " )) ;";
//			return (strSQL);
//		}	
//		protected override string strReturnCommandAlterTableAdd(ref System.Data.DataTable dttbTable,ref System.Collections.ArrayList arlColumns)
//		{
//			string strSQL = "ALTER TABLE " + dttbTable.TableName + " ADD ";
//			// Fields
//			foreach(System.Data.DataColumn dtclCurrent in arlColumns)
//			{
//				strSQL += dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent) + ",";
//			}
//			// Primary Keys
//			strSQL = strSQL.Substring(0,strSQL.Length - 1);
//			strSQL += " ;";
//			return (strSQL);
//		}
//
//		protected override void vExecuteCommand(string strSQL)
//		{
//			OpenConnection();
//			m_CommandSelect.CommandText = strSQL;
//			try
//			{
//				m_excError = null;
//				m_CommandSelect.ExecuteNonQuery();
//			}
//			catch(System.Exception excErro)
//			{
//				m_excError = excErro;
//			}
//		}
//		#endregion
//	}
}
