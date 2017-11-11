using System;

namespace mdlDataBaseAccess
{
	/// <summary>
	/// MySql
	/// </summary>
	public class clsDataBaseAccessMySql :clsDataBaseAccess
	{
	#region Enums
		public enum TableType
		{
			InnoDB,
			MyISAM
		}
	#endregion
	#region Atributos
			// ************************************************************************
			// Atributos 
			// ************************************************************************
			private MySql.Data.MySqlClient.MySqlConnection m_Connection = new MySql.Data.MySqlClient.MySqlConnection();
			private MySql.Data.MySqlClient.MySqlDataAdapter m_DataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
			private MySql.Data.MySqlClient.MySqlCommandBuilder m_CommandBuilder;
			private MySql.Data.MySqlClient.MySqlCommand m_CommandSelect = new MySql.Data.MySqlClient.MySqlCommand();
			private MySql.Data.MySqlClient.MySqlTransaction m_Transaction = null;

			private string m_strHost = "";
			private string m_strPort = "";
			private string m_strDataBaseName = "";

			private string m_strConnectionString = "";

			private TableType m_enumTableType = TableType.InnoDB;
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

			public override string DBDataBaseName
			{
				get
				{
					return base.DBDataBaseName;
				}
				set
				{
					base.DBDataBaseName = value.ToLower();
				}
			}

			public TableType TableTypes
			{
				set
				{
					m_enumTableType = value;
				}
				get
				{
					return(m_enumTableType);
				}
			}	
	#endregion
	#region Constructor
			public clsDataBaseAccessMySql(ref mdlTratamentoErro.clsTratamentoErro TratadorErro,string strHost,string strPort,string strDataBaseName,string strUser,string strPassword) : base(ref TratadorErro,strUser,strPassword)
			{
				m_enumConnectionType = ConnectionType.PATH;

				m_strHost = strHost;
				m_strPort = m_strPort;
				m_strDataBaseName = strDataBaseName.ToLower();

				GenerateConnectionString();
				m_DataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
				m_CommandSelect = new MySql.Data.MySqlClient.MySqlCommand();
				m_CommandSelect.Connection =  m_Connection;
				m_DataAdapter.SelectCommand = m_CommandSelect;
				m_CommandBuilder = new MySql.Data.MySqlClient.MySqlCommandBuilder(m_DataAdapter);
				m_nDefaultPort = 3306;
			}
	#endregion

	#region DataBase
			private MySql.Data.MySqlClient.MySqlConnection scUser()
			{
				string strConnectionString = "Server=" + m_strDBHost + ";Database=master;User ID=" + m_strDBUser + ";" + "Password=" + m_strDBPassword + ";";
				return(new MySql.Data.MySqlClient.MySqlConnection(strConnectionString));					
			}

			private MySql.Data.MySqlClient.MySqlConnection scAdmin()
			{
				string strConnectionString;
				if (m_strDBAdminUser == "")
					return(null);
				else
					strConnectionString = "Server=" + m_strDBHost + ";Database=" + m_strDBDataBaseName + ";User ID=" + m_strDBAdminUser + ";" + "Password=" + m_strDBAdminPassword + ";";
				return(new MySql.Data.MySqlClient.MySqlConnection(strConnectionString));					
			}

			private MySql.Data.MySqlClient.MySqlConnection scAdminMaster()
			{
				string strConnectionString;
				if (m_strDBAdminUser == "")
					return(null);
				else
					strConnectionString = "Server=" + m_strDBHost + ";Database=mysql;User ID=" + m_strDBAdminUser + ";" + "Password=" + m_strDBAdminPassword + ";";
				return(new MySql.Data.MySqlClient.MySqlConnection(strConnectionString));					
			}

			public override bool bServerAvailable()
			{
				MySql.Data.MySqlClient.MySqlConnection sqlConnection = scAdminMaster();					
				if (sqlConnection == null)
					return(false);
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
				MySql.Data.MySqlClient.MySqlConnection sqlConnection = scAdmin();
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
				MySql.Data.MySqlClient.MySqlConnection scConnection = scAdminMaster();
				MySql.Data.MySqlClient.MySqlCommand scomExecute = new MySql.Data.MySqlClient.MySqlCommand("CREATE DATABASE " + m_strDBDataBaseName);
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
				bool bReturn = false;
				MySql.Data.MySqlClient.MySqlConnection scConnection = scAdminMaster();
				MySql.Data.MySqlClient.MySqlCommand scomUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT User FROM user WHERE (User = '"+ m_strDBUser + "')",scConnection);
				try
				{
					scConnection.Open();
					MySql.Data.MySqlClient.MySqlDataReader sreUser = scomUser.ExecuteReader();
					if(sreUser.HasRows)
					{
						sreUser.Read();
						if (sreUser["User"].ToString() == m_strDBUser)
							bReturn = true;
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

			public override bool bUserCreate()
			{
				if (bUserAvailable())
					return(true);
				MySql.Data.MySqlClient.MySqlConnection scConnection = scAdminMaster();
				MySql.Data.MySqlClient.MySqlCommand scomUser = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO user (Host,User,Password) VALUES('%','" + m_strDBUser + "', PASSWORD('" + m_strDBPassword + "'))",scConnection);
				try
				{
					scConnection.Open();
					MySql.Data.MySqlClient.MySqlDataReader sreUser = scomUser.ExecuteReader();
					sreUser.Close();
					scConnection.Close();
					return(bUserAvailable());
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
				MySql.Data.MySqlClient.MySqlConnection scConnection = scAdminMaster();
				MySql.Data.MySqlClient.MySqlCommand scomUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT Select_priv,Insert_priv,Update_priv,Delete_priv,Create_priv,Drop_priv,Alter_priv FROM db WHERE ((Db = '" + m_strDBDataBaseName + "') AND  (User = '"+ m_strDBUser + "'))",scConnection);
				try
				{
					scConnection.Open();
					MySql.Data.MySqlClient.MySqlDataReader sreUser = scomUser.ExecuteReader();
					if(sreUser.HasRows)
					{
						sreUser.Read();
						if ((sreUser["Select_priv"].ToString() == "Y") && (sreUser["Insert_priv"].ToString() == "Y") && (sreUser["Update_priv"].ToString() == "Y") && (sreUser["Delete_priv"].ToString() == "Y") && (sreUser["Alter_priv"].ToString() == "Y"))
							bReturn = true;
						sreUser.Close();
						scConnection.Close();
					}
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
				if (bUserAssociated())
					return(true);
				MySql.Data.MySqlClient.MySqlConnection scConnection = scAdminMaster();
				MySql.Data.MySqlClient.MySqlCommand scomUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT Select_priv,Insert_priv,Update_priv,Delete_priv,Create_priv,Drop_priv,Alter_priv FROM db WHERE ((Host = '%') AND (Db = '" + m_strDBDataBaseName + "') AND  (User = '"+ m_strDBUser + "'))",scConnection);
				try
				{
					scConnection.Open();
					string strSQL = "";
					MySql.Data.MySqlClient.MySqlDataReader sreUser = scomUser.ExecuteReader();
					if(sreUser.HasRows)
						strSQL = "UPDATE db SET Select_priv = 'Y',Insert_priv = 'Y',Update_priv = 'Y',Delete_priv = 'Y',Create_priv = 'Y',Drop_priv = 'Y',Alter_priv = 'Y' WHERE ((Host = '%') AND (Db = '" + m_strDBDataBaseName + "') AND  (User = '"+ m_strDBUser + "'))";
					else
						strSQL = "INSERT INTO db (Host,Db,User,Select_priv,Insert_priv,Update_priv,Delete_priv,Create_priv,Drop_priv,Alter_Priv) VALUES ('%','" + m_strDBDataBaseName + "','"+ m_strDBUser + "', 'Y','Y','Y','Y','Y','Y','Y')";
					sreUser.Close();
					scomUser = new MySql.Data.MySqlClient.MySqlCommand(strSQL,scConnection);
					sreUser = scomUser.ExecuteReader();
					sreUser.Close();
					strSQL = "FLUSH PRIVILEGES";
					scomUser = new MySql.Data.MySqlClient.MySqlCommand(strSQL,scConnection);
					sreUser = scomUser.ExecuteReader();
					sreUser.Close();
					scConnection.Close();
					return(bUserAssociated());
				}
				catch
				{
					if (scConnection.State == System.Data.ConnectionState.Open)
						scConnection.Close();
					return(false);
				}
			}
	#endregion

	#region Configurations
			protected void GenerateConnectionString()
			{
				string strConnectionString = "Server=" + m_strHost + ";" + "Database=" + m_strDataBaseName + ";" + "User ID=" + m_strUser + ";" + "Password=" + m_strPassword + ";";
				m_Connection = new MySql.Data.MySqlClient.MySqlConnection(strConnectionString);
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
								m_DataAdapter.Update(tabela,strNomeTabela);
								m_Transaction.Commit();
								DataPersist = false;
							}
							catch(System.Exception eEcp) 
							{
								m_excError = eEcp;
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
			protected override bool bErrorMessageTableDoesntExist(Exception eError, string strTableName)
			{
				return((eError.Message.IndexOf("Table") != -1) && (eError.Message.IndexOf("doesn't exist") != -1));
			}

			protected override bool bErrorMessageColumnDoesntExist(System.Exception eError,string strColumnName)
			{
				return((eError != null) && (eError.Message.IndexOf("Unknow") != -1) && (eError.Message.IndexOf(strColumnName) != -1));
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
						strType = "INT";
						break;
					case "String":
						if (dtclColuna.ColumnName.StartsWith("mstr"))
						{
							//strType ="TEXT"; 
							strType ="LONGTEXT"; 
						}
						else
						{
							strType = "VARCHAR(240)";
						}
						break;
					case "DateTime":
						strType = "DATETIME";
						break;
					case "Boolean":
						strType = "BIT";
						break;
					case "Byte[]":
						strType = "BLOB";
						break;
					case "Double":
						//strType = "FLOAT";
						strType = "DOUBLE";
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
					strSQL += dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent);
					if (bIsPrimaryKey(dttbTable.PrimaryKey,dtclCurrent))
						strSQL += " NOT NULL ";
					strSQL += " ,";
				}
				// Primary Keys
				strSQL += " PRIMARY KEY ("; 
				foreach(System.Data.DataColumn dtclCurrent in dttbTable.PrimaryKey)
				{
					strSQL += dtclCurrent.ColumnName + ",";
				}
				strSQL = strSQL.Substring(0,strSQL.Length - 1);
				strSQL += " )) ";
				strSQL += GetTableType();
				strSQL += " ;";
				return (strSQL);
			}	

			private string GetTableType()
			{
				string strTableType = "";
				switch (m_enumTableType)
				{
					case TableType.MyISAM:
						strTableType = " ENGINE = MyISAM ";
						break;
				}
				return(strTableType);
			}
			protected override string strReturnCommandAlterTableAdd(ref System.Data.DataTable dttbTable,ref System.Collections.ArrayList arlColumns)
			{
				string strSQL = "ALTER TABLE " + dttbTable.TableName;
				// Fields
				foreach(System.Data.DataColumn dtclCurrent in arlColumns)
				{
					strSQL += " ADD " + dtclCurrent.ColumnName + " " + strReturnTypeDataColumn(dtclCurrent) + ",";
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
	#region DeleteDataBase
		public override bool DeleteAllDataBase()
		{
			System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
			// Getting all types in current assembly
			string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
			foreach(string strCurrent in arrStrAssembly)
			{
				if (strCurrent.StartsWith("mdlDataBaseAccess.Tabelas"))
				{
					string strTableName = strCurrent.Substring("mdlDataBaseAccess.Tabelas.Xsd".Length);
					strTableName = strTableName.Substring(0,strTableName.Length - 4);
					strTableName = strTableName.Substring(0,1).ToLower() + strTableName.Substring(1);
					if (strTableName == "tbModulos")
						continue;
					string strSQL = GetDeleteFull(strTableName);
					vExecuteCommand(strSQL);
					if (m_excError != null)
						return(false);
				}
			}
			return(true);
		}
	#endregion
	}
}
