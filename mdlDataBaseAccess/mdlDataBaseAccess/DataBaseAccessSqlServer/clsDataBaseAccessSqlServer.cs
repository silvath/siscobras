using System;

namespace mdlDataBaseAccess
{
	/// <summary>
	/// Sql Server / MSDE 
	/// </summary>
	public class clsDataBaseAccessSqlServer :clsDataBaseAccess
	{
		#region Atributos
			// ************************************************************************
			// Atributos 
			// ************************************************************************
			private System.Data.SqlClient.SqlConnection m_Connection = new System.Data.SqlClient.SqlConnection();
			private System.Data.SqlClient.SqlDataAdapter m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			private System.Data.SqlClient.SqlCommandBuilder m_CommandBuilder;
			private System.Data.SqlClient.SqlCommand m_CommandSelect = new System.Data.SqlClient.SqlCommand();
			private System.Data.SqlClient.SqlTransaction m_Transaction = null;

			private string m_strHost = "";
			private string m_strPort = "";
			private string m_strDataBaseName = "";

			private string m_strConnectionString = "";
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
			public clsDataBaseAccessSqlServer(ref mdlTratamentoErro.clsTratamentoErro TratadorErro,string strHost,string strPort,string strDataBaseName,string strUser,string strPassword) : base(ref TratadorErro,strUser,strPassword)
			{
				m_enumConnectionType = ConnectionType.PATH;

				m_strHost = strHost;
				m_strPort = m_strPort;
				m_strDataBaseName = strDataBaseName;

				GenerateConnectionString();
				m_DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
				m_CommandSelect = new System.Data.SqlClient.SqlCommand();
				m_CommandSelect.Connection =  m_Connection;
				m_DataAdapter.SelectCommand = m_CommandSelect;
				m_CommandBuilder = new System.Data.SqlClient.SqlCommandBuilder(m_DataAdapter);
				m_nDefaultPort = 1433;
			}
		#endregion

		#region DataBase
			private System.Data.SqlClient.SqlConnection scUser()
			{
				string strConnectionString = "Server=" + m_strDBHost + ";Database=master;Integrated Security=false;User ID=" + m_strDBUser + ";" + "Password=" + m_strDBPassword + ";";
				return(new System.Data.SqlClient.SqlConnection(strConnectionString));					
			}

			private System.Data.SqlClient.SqlConnection scAdmin()
			{
				string strConnectionString;
				if (m_strDBAdminUser == "")
					strConnectionString = "Server=" + m_strDBHost + ";Database=" + m_strDBDataBaseName + ";Integrated Security=SSPI;";
				else
					strConnectionString = "Server=" + m_strDBHost + ";Database=" + m_strDBDataBaseName + ";Integrated Security=false;User ID=" + m_strDBAdminUser + ";" + "Password=" + m_strDBAdminPassword + ";";
				return(new System.Data.SqlClient.SqlConnection(strConnectionString));					
			}

			private System.Data.SqlClient.SqlConnection scAdminMaster()
			{
				string strConnectionString;
				if (m_strDBAdminUser == "")
					strConnectionString = "Server=" + m_strDBHost + ";Database=master;Integrated Security=SSPI;";
				else
					strConnectionString = "Server=" + m_strDBHost + ";Database=master;Integrated Security=false;User ID=" + m_strDBAdminUser + ";" + "Password=" + m_strDBAdminPassword + ";";
				return(new System.Data.SqlClient.SqlConnection(strConnectionString));					
			}

			public override bool bServerAvailable()
			{
				System.Data.SqlClient.SqlConnection sqlConnection = scAdminMaster();					
				try
				{
					sqlConnection.Open();
					if (sqlConnection.State == System.Data.ConnectionState.Open)
					{
						sqlConnection.Close();
						return(true);
					}else{
						return(false);
					}
				}catch{
					return(false);
				}
			}

			public override bool bDataBaseAvailable()
			{
				System.Data.SqlClient.SqlConnection sqlConnection = scAdmin();
				try
				{
					sqlConnection.Open();
					if (sqlConnection.State == System.Data.ConnectionState.Open)
					{
						sqlConnection.Close();
						return(true);
					}
					else
					{
						return(false);
					}
				}
				catch
				{
					return(false);
				}
			}

			public override bool bDataBaseCreate()
			{
				if (bDataBaseAvailable())
					return(true);
				System.Data.SqlClient.SqlConnection scConnection = scAdminMaster();
				System.Data.SqlClient.SqlCommand scomExecute = new System.Data.SqlClient.SqlCommand("CREATE DATABASE " + m_strDBDataBaseName);
				scomExecute.Connection = scConnection;
				try
				{
					scConnection.Open();
					scomExecute.ExecuteNonQuery();
					scConnection.Close();
					System.Threading.Thread.Sleep(2000);
					return(true);
				}catch{
					return(false);
				}
			}

			public override bool bUserAvailable()
			{
				System.Data.SqlClient.SqlConnection scConnection = scAdminMaster();
				System.Data.SqlClient.SqlCommand scomUser = new System.Data.SqlClient.SqlCommand("sp_helplogins",scConnection);
				scomUser.CommandType = System.Data.CommandType.StoredProcedure;
				System.Data.SqlClient.SqlParameter sparUser = scomUser.Parameters.Add("@LoginNamePattern",System.Data.SqlDbType.NVarChar,30);
				sparUser.Value = m_strDBUser;
				try
				{
					scConnection.Open();
					System.Data.SqlClient.SqlDataReader sreUser = scomUser.ExecuteReader();
					if (sreUser.HasRows)
					{
						scConnection.Close();
						return(true);
					}
					else
					{
						scConnection.Close();
						return(false);
					}
				}
				catch
				{
					if (scConnection.State == System.Data.ConnectionState.Open)
						scConnection.Close();
					return(false);
				}
			}

			public override bool bUserCreate()
			{
				if (bUserAvailable())
					return(true);

				System.Data.SqlClient.SqlConnection scConnection = scAdminMaster();
				System.Data.SqlClient.SqlCommand scomAddLogin = new System.Data.SqlClient.SqlCommand("sp_addlogin",scConnection);
				scomAddLogin.CommandType = System.Data.CommandType.StoredProcedure;
				System.Data.SqlClient.SqlParameter sparAddLogin = null;
				sparAddLogin = scomAddLogin.Parameters.Add("@loginame",System.Data.SqlDbType.NVarChar,30);
				sparAddLogin.Value = m_strDBUser;
				sparAddLogin = scomAddLogin.Parameters.Add("@passwd",System.Data.SqlDbType.NVarChar,30);
				sparAddLogin.Value = m_strDBPassword;
				try
				{
					scConnection.Open();
					scomAddLogin.ExecuteReader();
					scConnection.Close();
					System.Threading.Thread.Sleep(2000);
					return(true);
				}
				catch
				{
					if (scConnection.State == System.Data.ConnectionState.Open)
						scConnection.Close();
					return(false);
				}
			}

			public override bool bUserAssociated()
			{
				bool bReturn = false;
				System.Data.SqlClient.SqlConnection scConnection = scAdmin();
				System.Data.SqlClient.SqlCommand scomUser = new System.Data.SqlClient.SqlCommand("sp_helpuser",scConnection);
				scomUser.CommandType = System.Data.CommandType.StoredProcedure;
				try
				{
					scConnection.Open();
					System.Data.SqlClient.SqlDataReader sreUser = scomUser.ExecuteReader();
					while(sreUser.HasRows)
					{
						sreUser.Read();
						if (sreUser["LoginName"].ToString() == m_strDBUser)
						{
							bReturn = true;
							break;
						}
					}
					sreUser.Close();
					scConnection.Close();
					return(bReturn);
				}
				catch
				{
					if (scConnection.State == System.Data.ConnectionState.Open)
						scConnection.Close();
					return(false);
				}
			}

			public override bool bUserAssociate()
			{
				System.Data.SqlClient.SqlConnection scConnection = scAdmin();
				System.Data.SqlClient.SqlCommand scomAddLogin = null;
				System.Data.SqlClient.SqlParameter sparAddLogin = null;
				System.Data.SqlClient.SqlDataReader sdrUser = null;
				if (!bUserAssociated())
				{
					scomAddLogin = new System.Data.SqlClient.SqlCommand("sp_grantdbaccess",scConnection);
					scomAddLogin.CommandType = System.Data.CommandType.StoredProcedure;
					sparAddLogin = scomAddLogin.Parameters.Add("@loginame",System.Data.SqlDbType.NVarChar,30);
					sparAddLogin.Value = m_strDBUser;
					sparAddLogin = scomAddLogin.Parameters.Add("@name_in_db",System.Data.SqlDbType.NVarChar,30);
					sparAddLogin.Value = m_strDBUser;
					try
					{
						scConnection.Open();
						sdrUser = scomAddLogin.ExecuteReader();
						sdrUser.Close();
						System.Threading.Thread.Sleep(2000);
					}
					catch
					{
						if ((sdrUser != null) &&(!sdrUser.IsClosed))
							sdrUser.Close();
					}
				}

				// Role
				try
				{
					scomAddLogin = new System.Data.SqlClient.SqlCommand("sp_addrolemember",scConnection);
					scomAddLogin.CommandType = System.Data.CommandType.StoredProcedure;
					sparAddLogin = scomAddLogin.Parameters.Add("@rolename",System.Data.SqlDbType.NVarChar,30);
					sparAddLogin.Value = "db_owner";
					sparAddLogin = scomAddLogin.Parameters.Add("@membername",System.Data.SqlDbType.NVarChar,30);
					sparAddLogin.Value = m_strDBUser;
					if (scConnection.State == System.Data.ConnectionState.Open)
						sdrUser = scomAddLogin.ExecuteReader();
					else
						return(false);
					sdrUser.Close();
					scConnection.Close();
				}catch 
				{
					if ((sdrUser != null) &&(!sdrUser.IsClosed))
						sdrUser.Close();
					if ((scConnection != null) && (scConnection.State == System.Data.ConnectionState.Open))
						scConnection.Close();
					return(false);
				}
				return(true);
			}
		#endregion

		#region Configurations
			protected void GenerateConnectionString()
			{
				string strConnectionString = "Server=" + m_strHost + ";" + "Database=" + m_strDataBaseName + ";" + "User ID=" + m_strUser + ";" + "Password=" + m_strPassword + ";";
				m_Connection = new System.Data.SqlClient.SqlConnection(strConnectionString);
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
							strSQL += " '" + arlCondicaoValor[nCont].ToString() + "'  ) ";
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
		#region CommandDelete
			protected override string GetDeleteFull(string strTableName)
			{
				return("DELETE FROM " + strTableName);
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
								//HACK:Testing timeout
								if (m_DataAdapter.InsertCommand != null)
									m_DataAdapter.InsertCommand.CommandTimeout = 600;
								if (m_DataAdapter.UpdateCommand != null)
									m_DataAdapter.UpdateCommand.CommandTimeout = 600;
								if (m_DataAdapter.DeleteCommand != null)
									m_DataAdapter.DeleteCommand.CommandTimeout = 600;
								//END
								m_DataAdapter.Update(tabela,strNomeTabela);
								m_Transaction.Commit();
								DataPersist = false;
							}
							catch(System.Exception eEcp) 
							{
								m_excError = eEcp;
								ShowDialogUpdateError(strNomeTabela);
								m_Transaction.Rollback();
							}
						}
					}
					CloseConnection();
				}
			}
		#endregion

		#region UpdateDataBase
			protected override bool bErrorMessageTableDoesntExist(Exception eError, string strTableName)
			{
				return(eError.Message.IndexOf(strTableName) != -1);
			}

			protected override bool bErrorMessageColumnDoesntExist(System.Exception eError,string strColumnName)
			{
				return((eError != null) && (!eError.Message.StartsWith("Failed")));
			}

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
							strType ="TEXT"; 
						}
						else
						{
							strType = "VARCHAR(255)";
						}
						break;
					case "DateTime":
						strType = "DATETIME";
						break;
					case "Boolean":
						strType = "BIT";
						break;
					case "Byte[]":
						strType = "VARBINARY";
						break;
					case "Double":
						strType = "FLOAT";
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
				}
				catch(System.Exception excErro)
				{
					m_excError = excErro;
				}
			}
		#endregion
	}
}
