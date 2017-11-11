using System;
using mdlDataBaseAccess.Tabelas;

namespace mdlDataBaseAccess
{

	#region Enums
		public enum Comparador
		{
			Igual = 1,
			Diferente = 2,
			Menor = 3,
			Maior = 4,
			MenorOuIgual = 5,
			MaiorOuIgual = 6
		}

		public enum TipoOrdenacao
		{
			Crescente = 1,
			Decrestente = 2
		}

		internal enum ConnectionType
		{
			None,
			TCP,
			PATH
		}
		
		public enum FonteDados
		{
			DataBase = 0,
			Resource = 1,
			Directory = 2
		}

		public enum Mode
		{
			Developer,
			User
		}
	#endregion

	/// <summary>
	/// Base
	/// </summary>
	public abstract class clsDataBaseAccess
	{
		#region Delegates
			public delegate void delCallDBUpdateInfoClear();
			public delegate void delCallDBUpdateInfoInsert(string text);
		#endregion
		#region Events
			public event delCallDBUpdateInfoClear eCallDBUpdateInfoClear;
			public event delCallDBUpdateInfoInsert eCallDBUpdateInfoInsert;
		#endregion
		#region Events Methods
			private void OnCallDBUpdateInfoClear()
			{
				if (eCallDBUpdateInfoClear != null)
					eCallDBUpdateInfoClear();
			}

			private void OnCallDBUpdateInfoInsert()
			{
				OnCallDBUpdateInfoInsert("**********************************");
			}

			private void OnCallDBUpdateInfoInsert(string text)
			{
				if (eCallDBUpdateInfoInsert != null)
					eCallDBUpdateInfoInsert(text);
			}
		#endregion

		#region Constantes
			private const int ERROR_UPDATE_CREATE_TABLE = -1;
			private const int ERROR_UPDATE_ALTER_TABLE_ADD = -2;

			private const string PATHDATASOURCEFILE = "C:\\";
		#endregion
		#region Atributos
			// ************************************************************************
			// Atributos 
			// ************************************************************************
			protected mdlTratamentoErro.clsTratamentoErro m_cls_tre_tratadorErro;

			internal ConnectionType m_enumConnectionType = ConnectionType.None;
			protected string m_strUser = "";
			protected string m_strPassword = "";

			protected string m_strDBHost = "";
			protected string m_strDBPort = "";
			protected string m_strDBDataBaseName = "";
			protected string m_strDBUser = "";
			protected string m_strDBPassword = "";

			protected string m_strDBAdminUser = "";
			protected string m_strDBAdminPassword = "";
						
			protected int m_nDefaultPort = -1;

			protected bool m_bUserCanSelectDB = true;
			protected bool m_bUserCanUpdateDB = true;

			protected bool m_bCheckIntegrityFieldMemo = false;
			protected bool m_bCheckIntegrityInsertedRow = true;
			protected bool m_bCheckIntegrityDeletedRow = true;
			protected bool m_bCheckIntegrityUpdateRow = false;
			protected bool m_bShowDialogsErrors = true;
			protected bool m_bLog = false;
			protected string m_strLogFileName = System.AppDomain.CurrentDomain.BaseDirectory + "mdlDataBaseAccess.log";
			protected bool m_bRefreshConnectionObjects = false;

			// Configuration
			protected Tabelas.XsdTbConfiguracoes m_typDatSetTbConfiguracoes = null;

			// Colecao de SQLs
			protected System.Collections.SortedList m_sortListSQLSelect = new System.Collections.SortedList();

			// Data Resource
			protected string m_strDataResourceSelect = "";
			protected string m_strDataResourceOrder = "";

			// DirectoryFiles
			protected string m_strDirectoryFiles = null;
		
			// Data Persist
			protected bool m_bDataPersist = false;
			protected System.Collections.ArrayList m_arlDataPersistTables = null;
			protected System.Collections.ArrayList m_arlDataPersistSelect = null;
			protected System.Collections.ArrayList m_arlDataPersistDataSets = null;

			// Data Source 
			protected FonteDados m_enumFonteDados = FonteDados.DataBase;

			// Mode
			protected Mode m_enumSystemMode = Mode.User;

			protected bool m_bWriteXml = false;

			// Exception 
			protected System.Exception m_excError = null;
		#endregion
		#region Properties
			public bool UserCanSelectDB
			{
				set
				{
					m_bUserCanSelectDB = value;
				}				
				get
				{
					return(m_bUserCanSelectDB); 
				}
			}

			public bool UserCanUpdateDB
			{
				set
				{
					m_bUserCanUpdateDB = value;
				}				
				get
				{
					return(m_bUserCanUpdateDB); 
				}
			} 

			public int DefaultPort
			{
				get
				{
					return(m_nDefaultPort);
				}
			}

			public string DBHost
			{
				set
				{
					m_strDBHost = value;

				}
				get
				{
					return(m_strDBHost);
				}
			}

			public virtual string DBDataBaseName
			{
				set
				{
					m_strDBDataBaseName = value;

				}
				get
				{
					return(m_strDBDataBaseName);
				}
			}

			public string DBPort
			{
				set
				{
					m_strDBPort = value;

				}
				get
				{
					return(m_strDBPort);
				}
			}

			public string DBUser
			{
				set
				{
					m_strDBUser = value;
				}
				get
				{
					return(m_strDBUser);
				}
			}

			public string DBPassword
			{
				set
				{
					m_strDBPassword = value;
				}
				get
				{
					return(m_strDBPassword);
				}
			}

			public string DBAdminUser
			{
				set
				{
					m_strDBAdminUser = value;
				}
				get
				{
					return(m_strDBAdminUser);
				}
			}

			public string DBAdminPassword
			{
				set
				{
					m_strDBAdminPassword = value;
				}
				get
				{
					return(m_strDBAdminPassword);
				}
			}

			public bool DataPersist
			{
				set
				{
					m_bDataPersist = value;
					if (m_bDataPersist)
					{
						m_arlDataPersistTables = new System.Collections.ArrayList();
						m_arlDataPersistSelect = new System.Collections.ArrayList();
						m_arlDataPersistDataSets = new System.Collections.ArrayList();
					}else{
						m_arlDataPersistTables = null;
						m_arlDataPersistSelect = null;
						m_arlDataPersistDataSets = null;
					}
				}
				get
				{
					return(m_bDataPersist);
				}
			}

			public Mode SystemMode
			{
				set
				{
					m_enumSystemMode = value;
				}
				get
				{
					return(m_enumSystemMode);
				}
			}

			public bool ShowDialogsErrors
			{
				set
				{
					m_bShowDialogsErrors = value;
				}
				get
				{
					return(m_bShowDialogsErrors);
				}
			}

			public bool WriteXML
			{
				set
				{
					m_bWriteXml = value;
				}
				get
				{
					return(m_bWriteXml);
				}
			}

			public bool Log
			{
				set
				{
					m_bLog = value;
				}
				get
				{
					return(m_bLog);
				}
			}

			public string LogFile
			{
				set
				{
					m_strLogFileName = value;
				}
				get
				{
					return(m_strLogFileName);
				}
			}
				
			public bool RefreshConnectionObjects
			{
				set
				{
					m_bRefreshConnectionObjects = value;
				}
				get
				{
					return(m_bRefreshConnectionObjects);
				}
			}

			public bool CheckIntegrityUpdate
			{
				set
				{
					m_bCheckIntegrityUpdateRow = value;
				}
				get
				{
					return(m_bCheckIntegrityUpdateRow);
				}
			}

			public FonteDados FonteDosDados
			{
				set
				{
					m_enumFonteDados = value;
				}
				get{
					return(m_enumFonteDados);
				}
			}

			public System.Exception Erro
			{
				get
				{
					return(m_excError);
				}
			}

			public string DirectoryFiles
			{
				set
				{
					if (System.IO.Directory.Exists(value))
					{
						m_strDirectoryFiles = value;
					}else{
						try
						{
							System.IO.Directory.CreateDirectory(value);
							m_strDirectoryFiles = value;
						}catch{
							m_strDirectoryFiles = null;
						}
					}
				}
				get
				{
					return(m_strDirectoryFiles);
				}
			}

			private bool IsDirectoryFilesExists
			{
				get
				{
					if (this.DirectoryFiles == null)
						return(false);
					return(System.IO.Directory.Exists(this.DirectoryFiles));
				}
			}
		#endregion
		#region Constructor 
		public clsDataBaseAccess(ref mdlTratamentoErro.clsTratamentoErro TratadorErro,string strUser,string strPassword)
		{
			m_cls_tre_tratadorErro = TratadorErro;
			m_strUser = strUser;
			m_strPassword = strPassword;
		}
		#endregion

		#region Net
			public string[] astrComputersAvailables()
			{
				string[] strReturn = null;
				System.Collections.ArrayList arlMachines = new System.Collections.ArrayList();
				// Machine Ip
				System.Net.IPHostEntry ipheMaquina = System.Net.Dns.Resolve(System.Environment.MachineName);
				foreach(System.Net.IPAddress ipaMachine in ipheMaquina.AddressList)
				{
					byte[] arrbyBase = ipaMachine.GetAddressBytes();
					for (byte byIpRange = 1; byIpRange < 255; byIpRange++)
					{
						arrbyBase[3] = byIpRange;
						string strIp = arrbyBase[0] + "." + arrbyBase[1] + "." + arrbyBase[2] + "." + arrbyBase[3];
						string strHost = "";
						if (bComputerAvailable(strIp,out strHost))
						{
							if (!arlMachines.Contains(strHost))
								arlMachines.Add(strHost);
						}
					}
				}
				strReturn = new string[arlMachines.Count];
				for(int i = 0;i < arlMachines.Count;i++)
					strReturn[i] = arlMachines[i].ToString();
				return(strReturn);
			}

			protected bool bComputerAvailable(string strIp,out string strHost)
			{
				try
				{
					System.Net.IPHostEntry ipheInfo = System.Net.Dns.GetHostByAddress(strIp);
					strHost = ipheInfo.HostName;
					return(true);
				}
				catch
				{
					strHost = strIp;
					return(false);
				}
			}

			public bool bComputerAvailable(string strHost)
			{
				try
				{
					System.Net.IPHostEntry ipheInfo = System.Net.Dns.Resolve(strHost);
					strHost = ipheInfo.HostName;
					return(true);
				}
				catch
				{
					return(false);
				}
			}
		#endregion
		#region DataBase
			public abstract bool bServerAvailable();
			public abstract bool bDataBaseAvailable();
			public abstract bool bDataBaseCreate();
			public abstract bool bUserAvailable();
			public abstract bool bUserCreate();
			public abstract bool bUserAssociated();
			public abstract bool bUserAssociate();

			public string[] astrServersAvailables()
			{
				return(astrServersAvailables(astrComputersAvailables()));
			}

			public string[] astrServersAvailables(string[] astrComputers)
			{
				string[] astrReturn = null;
				System.Collections.ArrayList arlServers = new System.Collections.ArrayList();
				// Searching Computers
				foreach(string strComputer in astrComputers)
				{
					this.DBHost = strComputer;
					if (bServerAvailable())
						if (!arlServers.Contains(strComputer))
							arlServers.Add(strComputer);
				}
				astrReturn = new string[arlServers.Count];
				for(int i = 0; i < arlServers.Count;i++)
					astrReturn[i] = arlServers[i].ToString();
				return(astrReturn);
			}

			public string[] astrDataBaseAvailables()
			{
				return(astrDataBaseAvailables(astrServersAvailables()));
			}

			public string[] astrDataBaseAvailables(string[] astrServers)
			{
				string[] astrReturn = null;
				System.Collections.ArrayList arlDataBase = new System.Collections.ArrayList();
				foreach(string strServer in astrServers)
				{
					this.DBHost = strServer;
					if (bDataBaseAvailable())
						if (!arlDataBase.Contains(strServer))
							arlDataBase.Add(strServer);
				}
				astrReturn = new string[arlDataBase.Count];
				for(int i = 0; i < arlDataBase.Count;i++)
					astrReturn[i] = arlDataBase[i].ToString();
				return(astrReturn);
			}

			public bool bSetDefaultData(out string strReturn)
			{
				bool bReturn = false;
				strReturn = "";
				bool bShowErrors = this.ShowDialogsErrors;
				this.ShowDialogsErrors = false;
				if (this.GetConfiguracao(mdlConstantes.clsConstantes.FIELDVERSION,"") == "")
				{
					this.SetConfiguracao(mdlConstantes.clsConstantes.FIELDVERSION,mdlConstantes.clsConstantes.CURRENTVERSION);
					if (!(bReturn = this.GetConfiguracao(mdlConstantes.clsConstantes.FIELDVERSION,"") == mdlConstantes.clsConstantes.CURRENTVERSION))
						strReturn = "Não foi possível colocar os dados iniciais do banco de dados";
				}else{
					bReturn = true;
					strReturn = "Já existe uma versão no servidor";
				}
				this.ShowDialogsErrors = bShowErrors;
				return(bReturn);
			}
		#endregion

		#region ShowDialogs
			protected void ShowDialogConnectionError(string strError)
			{
				if (m_bShowDialogsErrors)
				{
					mdlDataBaseAccess.Formularios.frmFConnectionError formFConnectionError = new mdlDataBaseAccess.Formularios.frmFConnectionError();
					formFConnectionError.ShowDialog();
					formFConnectionError = null;
				}
				if (m_excError != null)
				{
					vWriteInLogFile("CONECTION_ERROR: " + strError);
					vWriteExceptionInLogFile(m_excError);
				}
			}

			protected void ShowDialogFillError(string strError)
			{
				if ((m_bShowDialogsErrors) && (m_excError != null))
				{
					switch(m_enumSystemMode)
					{
						case Mode.User:
							mdlDataBaseAccess.Formularios.frmFFillError formFFillError = new mdlDataBaseAccess.Formularios.frmFFillError();
							formFFillError.ShowDialog();
							formFFillError = null;
							break;

						case Mode.Developer:
							System.Windows.Forms.MessageBox.Show(m_excError.ToString());
							break;
					}
				}
				if (m_excError != null)
				{
					vWriteInLogFile("FILL_ERROR: " + strError);
					vWriteExceptionInLogFile(m_excError);
				}
			}

			protected void ShowDialogUpdateError(string strError)
			{
				if ((m_bShowDialogsErrors) && (m_excError != null))
				{
					switch(m_enumSystemMode)
					{
						case Mode.User:
							mdlDataBaseAccess.Formularios.frmFUpdateError formFUpdateError = new mdlDataBaseAccess.Formularios.frmFUpdateError();
							formFUpdateError.ShowDialog();
							formFUpdateError = null;
							break;

						case Mode.Developer:
							System.Windows.Forms.MessageBox.Show(m_excError.ToString());
							break;
					}
				}
				if (m_excError != null)
				{
					vWriteInLogFile("UPDATE_ERROR: " + strError);
					vWriteExceptionInLogFile(m_excError);
				}
			}
		#endregion
		#region Log
			protected void vCreateLogFile()
			{
				if (m_bLog)
				{
					System.IO.FileStream flstFile = new System.IO.FileStream(m_strLogFileName,System.IO.FileMode.OpenOrCreate,System.IO.FileAccess.Write);
					flstFile.Close();
				}
			}

			protected void vWriteInLogFile(string strLog)
			{
				if (m_bLog)
				{
					System.IO.FileStream flstFile = new System.IO.FileStream(m_strLogFileName,System.IO.FileMode.Append,System.IO.FileAccess.Write);
					System.IO.StreamWriter stwrFile = new System.IO.StreamWriter(flstFile);
					stwrFile.WriteLine(System.Environment.NewLine);
					stwrFile.WriteLine(System.DateTime.Now.ToString() + " - " + strLog);
					stwrFile.Close();
					flstFile.Close();
				}
			}

			protected void vDestroyLogFile()
			{
				if (System.IO.File.Exists(m_strLogFileName))
				{
					System.IO.File.Delete(m_strLogFileName);
				}
			}

			public void vWriteExceptionInLogFile(System.Exception eExc)
			{
				vCreateLogFile();
				vWriteInLogFile(eExc.Message);
				vWriteInLogFile(eExc.Source);
				vWriteInLogFile(eExc.StackTrace);
				vWriteInLogFile(eExc.TargetSite.ToString());
				vWriteInLogFile(eExc.ToString());
			}
		#endregion

		#region Sql
			public abstract System.Data.DataTable dttbExecuteSql(string sqlCommand);
		#endregion

		#region CommandSelect
			#region Abstracts 
				protected abstract void SetCommandSelect(string strTable,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo);
				protected abstract void SetCommandSelect(string strSql);
				protected abstract string GetCommandSelect();
				protected abstract string strReturnCommandSelect();
				protected abstract string strReturnFullSelect(System.Data.DataTable dttbTable);
			#endregion
			#region Data Resource
				protected void SetCommandSelect(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					m_strDataResourceSelect = "";
					m_strDataResourceOrder = "";
					string strSQL = "";

					// Condicoes
					if ((arlCondicaoCampo != null ) && (arlCondicaoValor != null) && (arlCondicaoComparador != null) && (arlCondicaoCampo.Count == arlCondicaoComparador.Count) && (arlCondicaoCampo.Count == arlCondicaoValor.Count) && (arlCondicaoValor.Count > 0))
					{
						for (int nCont = 0; nCont < arlCondicaoCampo.Count;nCont++)
						{
							strSQL += arlCondicaoCampo[nCont].ToString();
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
								strSQL += " '" + arlCondicaoValor[nCont].ToString() + "' ";
							else
								strSQL += arlCondicaoValor[nCont].ToString() + " ";
							if ((nCont + 1) < arlCondicaoCampo.Count)
								strSQL += " AND ";
						}
						m_strDataResourceSelect = strSQL;
					}
					strSQL = "";

					// Ordem 
					if ((arlOrdenacaoCampo != null ) && (arlOrdenacaoTipo != null) && (arlOrdenacaoCampo.Count > 0) && (arlOrdenacaoTipo.Count > 0) && (arlOrdenacaoCampo.Count == arlOrdenacaoTipo.Count))
					{
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
						m_strDataResourceOrder = strSQL;
					}
				}
			#endregion
			#region Update
				protected void vSetCommandSelectFullSelect(ref System.Data.DataTable dttbTable)
				{
					string strSQL = "SELECT ";
					foreach(System.Data.DataColumn dtclCurrent in dttbTable.Columns)
						strSQL += dtclCurrent.ColumnName + ",";
					strSQL = strSQL.Substring(0,strSQL.Length - 1);
					strSQL += " FROM " + dttbTable.TableName;
					SetCommandSelect(strSQL);
				}

				protected string strReturnFullSelect(string strTableName)
				{
					return("SELECT * FROM " + strTableName);
				}

				protected void vSetCommandSelectOneColumn(ref System.Data.DataTable dttbTable,System.Data.DataColumn dtclColuna)
				{
					string strSQL = "SELECT ";
					strSQL += dtclColuna; 
					strSQL += " FROM " + dttbTable.TableName;
					SetCommandSelect(strSQL);
				}
			#endregion
		#endregion
		#region CommandDelete
			protected virtual string GetDeleteFull(string strTableName)
			{
				return("DELETE * FROM " + strTableName);
			}
		#endregion

		#region Conection
		public abstract bool bCanOpenConnection();
		protected abstract void OpenConnection();
		protected abstract void CloseConnection(); 
		#endregion
		#region DataAdapter
		protected abstract void DataAdapterFill(ref System.Data.DataSet tabela,string strNomeTabela);
		protected abstract void DataAdapterUpdate(System.Data.DataSet tabela,string strNomeTabela);
		#endregion

		#region SortedList SQL
		protected void SetSQLSelect(string strTableName,string strSQL)
		{
			if (!m_sortListSQLSelect.Contains(strTableName))
			{
				m_sortListSQLSelect.Add(strTableName,strSQL);
			}
			else
			{
				m_sortListSQLSelect[strTableName] = strSQL;

			}
		}

		protected string GetSQLSelect(string strTableName)
		{
			string strRetorno = "";
			if (m_sortListSQLSelect.Contains(strTableName))
			{
				strRetorno = m_sortListSQLSelect[strTableName].ToString();
			}else{
				strRetorno = strReturnFullSelect(strTableName);
			}
			return(strRetorno);
		}

		protected string GetSQLSelect(System.Data.DataTable dttbTable)
		{
			return(strReturnFullSelect(dttbTable));
		}

		#endregion

		#region Integrity 
		#region CheckIntegrityDataSet
		private void CheckIntegrityDataSet(ref System.Data.DataSet dtstCheck)
		{
			mdlDataBaseAccess.FonteDados fontOld = this.FonteDosDados;
			this.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			CheckIntegrityFieldMemo(ref dtstCheck);
			string strCommandSelect = GetCommandSelect();
			if (m_bCheckIntegrityDeletedRow)
				CheckIntegrityRowDeleted(ref dtstCheck);
			if (m_bCheckIntegrityUpdateRow)
				CheckIntegrityRowUpdated(ref dtstCheck);
			SetCommandSelect(strCommandSelect);
			this.FonteDosDados = fontOld;
		}
		#endregion
		#region CheckIntegrityFieldString
		private void CheckIntegrityFieldMemo(ref System.Data.DataSet dtstCheck)
		{
			if (m_bCheckIntegrityFieldMemo)
			{
				for(int nContTable = 0; nContTable < dtstCheck.Tables.Count ; nContTable++)
				{
					for(int nContColumn = 0 ; nContColumn < dtstCheck.Tables[nContTable].Columns.Count;nContColumn++)
					{
						if (dtstCheck.Tables[nContTable].Columns[nContColumn].DataType.ToString() == "System.String")
						{
							for(int nContRows = 0;nContRows < dtstCheck.Tables[nContTable].Rows.Count ;nContRows++)
							{
								if (!(dtstCheck.Tables[nContTable].Rows[nContRows].RowState == System.Data.DataRowState.Deleted))
								{
									if (dtstCheck.Tables[nContTable].Rows[nContRows][nContColumn].ToString() == "")
									{
										dtstCheck.Tables[nContTable].Rows[nContRows][nContColumn] = '\0'.ToString();
									}
								}
							}
						}
					}
				}
			}
		}
		#endregion
		#region CheckIntegrityRowDeleted
		private void CheckIntegrityRowDeleted(ref System.Data.DataSet dtstCheck)
		{
			// Searching in the tables 
			for (int nContTables = 0;nContTables < dtstCheck.Tables.Count;nContTables++)
			{
				for (int nContRows = 0 ; nContRows < dtstCheck.Tables[nContTables].Rows.Count;nContRows++)
				{
					if (dtstCheck.Tables[nContTables].Rows[nContRows].RowState == System.Data.DataRowState.Deleted)
					{
						System.Data.DataRow dtrwDeleted = dtstCheck.Tables[nContTables].Rows[nContRows];
						switch(dtstCheck.Tables[nContTables].GetType().ToString())
						{
								// tbAgentesCargas
							case "mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas+tbAgentesCargasDataTable":
								CheckIntegrityRowDeletedTbAgentesCargas((mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow)dtrwDeleted);
								break;
								// tbArmadores
							case "mdlDataBaseAccess.Tabelas.XsdTbArmadores+tbArmadoresDataTable":
								CheckIntegrityRowDeletedTbArmadores((mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow)dtrwDeleted);
								break;
								// tbBorderos
							case "mdlDataBaseAccess.Tabelas.XsdTbBorderos+tbBorderosDataTable":
								CheckIntegrityRowDeletedTbBorderos((mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)dtrwDeleted);
								break;
								// tbCertificadosOrigem
							case "mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem+tbCertificadosOrigemDataTable":
								CheckIntegrityRowDeletedTbCertificadosOrigem((mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)dtrwDeleted);
								break;
								// tbContratosCambio
							case "mdlDataBaseAccess.Tabelas.XsdTbContratosCambio+tbContratosCambioDataTable":
								CheckIntegrityRowDeletedTbContratosCambio((mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow)dtrwDeleted);
								break;
								// tbDSEs
							case "mdlDataBaseAccess.Tabelas.XsdTbDSEs+tbDSEsDataTable":
								CheckIntegrityRowDeletedTbDSEs((mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)dtrwDeleted);
								break;
								// tbExportadores
							case "mdlDataBaseAccess.Tabelas.XsdTbExportadores+tbExportadoresDataTable":
								CheckIntegrityRowDeletedTbExportadores((mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)dtrwDeleted);
								break;
								// tbExportadoresBancos
							case "mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos+tbExportadoresBancosDataTable":
								CheckIntegrityRowDeletedTbExportadoresBancos((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow)dtrwDeleted);
								break;
								// tbExportadoresBancosAgencias
							case "mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias+tbExportadoresBancosAgenciasDataTable":
								CheckIntegrityRowDeletedTbExportadoresBancosAgencias((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow)dtrwDeleted);
								break;
								// tbImportadores
							case "mdlDataBaseAccess.Tabelas.XsdTbImportadores+tbImportadoresDataTable":
								CheckIntegrityRowDeletedTbImportadores((mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)dtrwDeleted);
								break;
								// tbPes
							case "mdlDataBaseAccess.Tabelas.XsdTbPes+tbPEsDataTable":
								CheckIntegrityRowDeletedTbPes((mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)dtrwDeleted);
								break;
								// tbFaturasComerciais
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais+tbFaturasComerciaisDataTable":
								CheckIntegrityRowDeletedTbFaturasComerciais((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)dtrwDeleted);
								break;
								// tbFaturasCotacoes
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes+tbFaturasCotacoesDataTable":
								CheckIntegrityRowDeletedTbFaturasCotacoes((mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)dtrwDeleted);
								break;
								// tbFaturasProformas
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas+tbFaturasProformasDataTable":
								CheckIntegrityRowDeletedTbFaturasProformas((mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)dtrwDeleted);
								break;
								// tbProdutos
							case "mdlDataBaseAccess.Tabelas.XsdTbProdutos+tbProdutosDataTable":
								CheckIntegrityRowDeletedTbProdutos((mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)dtrwDeleted);
								break;
								// tbProdutosFaturaComercial
							case "mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial+tbProdutosFaturaComercialDataTable":
								CheckIntegrityRowDeletedTbProdutosFaturaComercial((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)dtrwDeleted);
								break;
								// tbProdutosFaturaCotacao
							case "mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao+tbProdutosFaturaCotacaoDataTable":
								CheckIntegrityRowDeletedTbProdutosFaturaCotacao((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)dtrwDeleted);
								break;
								// tbProdutosFaturaProforma
							case "mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma+tbProdutosFaturaProformaDataTable":
								CheckIntegrityRowDeletedTbProdutosFaturaProforma((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)dtrwDeleted);
								break;
								// tbPropriedadesProdutos
							case "mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos+tbPropriedadesProdutosDataTable":
								CheckIntegrityRowDeletedTbPropriedadesProdutos((mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow)dtrwDeleted);
								break;
								// tbRelatorios
							case "mdlDataBaseAccess.Tabelas.XsdTbRelatorios+tbRelatoriosDataTable":
								CheckIntegrityRowDeletedTbRelatorios((mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow)dtrwDeleted);
								break;
								// tbREs
							case "mdlDataBaseAccess.Tabelas.XsdTbREs+tbREs":
								CheckIntegrityRowDeletedTbREs((mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)dtrwDeleted);
								break;
								// tbRomaneios
							case "mdlDataBaseAccess.Tabelas.XsdTbRomaneios+tbRomaneiosDataTable":
								CheckIntegrityRowDeletedTbRomaneios((mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)dtrwDeleted);
								break;
								// tbTerminais
							case "mdlDataBaseAccess.Tabelas.XsdTbTerminais+tbTerminaisDataTable":
								CheckIntegrityRowDeletedTbTerminais((mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow)dtrwDeleted);
								break;
								// tbTransportadoras
							case "mdlDataBaseAccess.Tabelas.XsdTbTransportadoras+tbTransportadorasDataTable":
								CheckIntegrityRowDeletedTbTransportadoras((mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow)dtrwDeleted);
								break;
						} 
					}
				}
			}
		}	
		#endregion
		#region CheckIntegrityRowUpdated
		private void CheckIntegrityRowUpdated(ref System.Data.DataSet dtstCheck)
		{
			// Searching in the tables 
			for (int nContTables = 0;nContTables < dtstCheck.Tables.Count;nContTables++)
			{
				for (int nContRows = 0 ; nContRows < dtstCheck.Tables[nContTables].Rows.Count;nContRows++)
				{
					if (dtstCheck.Tables[nContTables].Rows[nContRows].RowState == System.Data.DataRowState.Modified)
					{
						System.Data.DataRow dtrwDeleted = dtstCheck.Tables[nContTables].Rows[nContRows];
						switch(dtstCheck.Tables[nContTables].GetType().ToString())
						{
								// tbCertificadosOrigem
							case "mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem+tbCertificadosOrigemDataTable":
								CheckIntegrityRowUpdatedTbCertificadosOrigem((mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)dtrwDeleted);
								break;
								// tbExportadoresBancosAgencias
							case "mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias+tbExportadoresBancosAgenciasDataTable":
								CheckIntegrityRowUpdatedTbExportadoresBancosAgencias((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow)dtrwDeleted);
								break;
								// tbPes
							case "mdlDataBaseAccess.Tabelas.XsdTbPes+tbPEsDataTable":
								CheckIntegrityRowUpdatedTbPes((mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)dtrwDeleted);
								break;
								// tbFaturasComerciais
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais+tbFaturasComerciaisDataTable":
								CheckIntegrityRowUpdatedTbFaturasComerciais((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)dtrwDeleted);
								break;
								// tbFaturasCotacoes
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes+tbFaturasCotacoesDataTable":
								CheckIntegrityRowUpdatedTbFaturasCotacoes((mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)dtrwDeleted);
								break;
								// tbFaturasProformas
							case "mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas+tbFaturasProformasDataTable":
								CheckIntegrityRowUpdatedTbFaturasProformas((mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)dtrwDeleted);
								break;
								// tbProdutosFaturaComercial
							case "mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial+tbProdutosFaturaComercialDataTable":
								CheckIntegrityRowUpdatedTbProdutosFaturaComercial((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)dtrwDeleted);
								break;
								// tbRomaneios
							case "mdlDataBaseAccess.Tabelas.XsdTbRomaneios+tbRomaneiosDataTable":
								CheckIntegrityRowUpdatedTbRomaneios((mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)dtrwDeleted);
								break;
						} 
					}
				}
			}
		}	
		#endregion
		#endregion
		#region Integrity Tables
		#region Integrity Tables Deleted
		#region CheckIntegrityRowDeletedFullDelete
		private void CheckIntegrityRowDeletedFullDeleteRows(System.Data.DataTable dttbDelete)
		{
			for (int nCont = 0;nCont < dttbDelete.Rows.Count; nCont++)
			{
				dttbDelete.Rows[nCont].Delete();
			}
		}
		#endregion

		#region tbAgentesCargas
			private void CheckIntegrityRowDeletedTbAgentesCargas(mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwDeleted)
			{
				// tbAgentesCargasContatos
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdAgenteCarga");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdAgenteCarga",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos typDatSetTbAgentesCargasContatos = this.GetTbAgentesCargasContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbAgentesCargasContatos.tbAgentesCargasContatos);
				this.SetTbAgentesCargasContatos(typDatSetTbAgentesCargasContatos);
			}
		#endregion
		#region tbAgentesCargasContatos
		// NADA
		#endregion

		#region tbArmadores
			private void CheckIntegrityRowDeletedTbArmadores(mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwDeleted)
			{
				// tbArmadoresNavios
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdArmador");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdArmador",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios typDatSetTbArmadoresNavios = this.GetTbArmadoresNavios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbArmadoresNavios.tbArmadoresNavios);
				this.SetTbArmadoresNavios(typDatSetTbArmadoresNavios);
			}
		#endregion
		#region tbArmadoresNavios
		//NADA
		#endregion

		#region tbAssinaturas
		// NADA 
		#endregion

		#region tbBorderos
			private void CheckIntegrityRowDeletedTbBorderos(mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwDeleted)
			{
				// tbProdutosBordero
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("strIdPE");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetTbProdutosBordero = this.GetTbProdutosBordero(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosBordero.tbProdutosBordero);
				this.SetTbProdutosBordero(typDatSetTbProdutosBordero);
			}
		#endregion
		#region tbBorderosSecundarios
		// NADA
		#endregion

		#region tbCartasCredito
		// NADA 
		#endregion

		#region tbCertificadosOrigem
		private void CheckIntegrityRowDeletedTbCertificadosOrigem(mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwDeleted)
		{
			// tbProdutosCertificadoOrigem
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("idTipoCO");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdTipoCO",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem = this.GetTbProdutosCertificadoOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem);
			this.SetTbProdutosCertificadoOrigem(typDatSetTbProdutosCertificadoOrigem);
		}
		#endregion
		#region tbCertificadosOrigemNormas
		// NADA
		#endregion

		#region tbConfiguracoes
		// NADA 
		#endregion

		#region tbConhecimentos
		// NADA
		#endregion

		#region tbContratosCambio
			private void CheckIntegrityRowDeletedTbContratosCambio(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwDeleted)
			{
				// tbProdutosBordero
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("nIdContratoCambio");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdContratoCambio",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetTbProdutosBordero = this.GetTbProdutosBordero(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosBordero.tbProdutosBordero);
				this.SetTbProdutosBordero(typDatSetTbProdutosBordero);
			}
		#endregion

		#region tbDespachantes
		// NADA 
		#endregion

		#region tbDSEs
			private void CheckIntegrityRowDeletedTbDSEs(mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDeleted)
			{
							
				// tbDSEsPEs
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoCampo.Add("nIdDSE");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdDSE",System.Data.DataRowVersion.Original]);

				mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs typDatSetTbDSEsPEs = this.GetTbDSEsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbDSEsPEs.tbDSEsPEs);
				this.SetTbDSEsPEs(typDatSetTbDSEsPEs);
			}
		#endregion

		#region tbEstadosBrasileiros
		// NADA 
		#endregion 

		#region tbErros
		// NADA 
		#endregion

		#region tbExportadores
		private void CheckIntegrityRowDeletedTbExportadores(mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwDeleted)
		{
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);

			// tbContratosCambio
			mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetTbContratosCambio = this.GetTbContratosCambio(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbContratosCambio.tbContratosCambio);
			this.SetTbContratosCambio(typDatSetTbContratosCambio);

			// tbExportadoresAgentesVendas
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas typDatSetTbExportadoresAgentesVendas = this.GetTbExportadoresAgentesVendas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas);
			this.SetTbExportadoresAgentesVendas(typDatSetTbExportadoresAgentesVendas);

			// tbExportadoresBancos
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos typDatSetExportadoresBancos = this.GetTbExportadoresBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetExportadoresBancos.tbExportadoresBancos);
			this.SetTbExportadoresBancos(typDatSetExportadoresBancos);

			// tbProdutosCategorias
			mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias typDatSetTbProdutosCategorias = this.GetTbProdutosCategorias(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosCategorias.tbProdutosCategorias);
			this.SetTbProdutosCategorias(typDatSetTbProdutosCategorias);

			// tbProdutosNcm
			mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm = this.GetTbProdutosNcm(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosNcm.tbProdutosNcm);
			this.SetTbProdutosNcm(typDatSetTbProdutosNcm);

			// tbProdutosNaladi
			mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi = this.GetTbProdutosNaladi(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosNaladi.tbProdutosNaladi);
			this.SetTbProdutosNaladi(typDatSetTbProdutosNaladi);

			// tbPropriedadesProdutos
			mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetTbPropriedadesProdutos = this.GetTbPropriedadesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbPropriedadesProdutos.tbPropriedadesProdutos);
			this.SetTbPropriedadesProdutos(typDatSetTbPropriedadesProdutos);

			// tbRelatorios
			mdlDataBaseAccess.Tabelas.XsdTbRelatorios typDatSetTbRelatorios = this.GetTbRelatorios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorios.tbRelatorios);
			this.SetTbRelatorios(typDatSetTbRelatorios);

			// tbREs
			mdlDataBaseAccess.Tabelas.XsdTbREs typDatSetTbREs = this.GetTbREs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbREs.tbREs);
			this.SetTbREs(typDatSetTbREs);

			// tbDSEs
			mdlDataBaseAccess.Tabelas.XsdTbDSEs typDatSetTbDSEs = this.GetTbDSEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbDSEs.tbDSEs);
			this.SetTbDSEs(typDatSetTbDSEs);

			// tbSDs
			mdlDataBaseAccess.Tabelas.XsdTbSDs typDatSetTbSDs = this.GetTbSDs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbSDs.tbSDs);
			this.SetTbSDs(typDatSetTbSDs);

			// tbExportadoresVolumes
			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("idExportador");
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes typDatSetTbExportadoresVolumes = this.GetTbExportadoresVolumes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbExportadoresVolumes.tbExportadoresVolumes);
			this.SetTbExportadoresVolumes(typDatSetTbExportadoresVolumes);

			// tbImportadores
			mdlDataBaseAccess.Tabelas.XsdTbImportadores typDatSetTbImportadores = this.GetTbImportadores(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbImportadores.tbImportadores);
			this.SetTbImportadores(typDatSetTbImportadores);

			// tbPes
			mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetTbPes = this.GetTbPes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbPes.tbPEs);
			this.SetTbPes(typDatSetTbPes);

			// tbFaturasCotacoes
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetTbFaturasCotacoes = this.GetTbFaturasCotacoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasCotacoes.tbFaturasCotacoes);
			this.SetTbFaturasCotacoes(typDatSetTbFaturasCotacoes);

			// tbProdutos
			mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos = this.GetTbProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutos.tbProdutos);
			this.SetTbProdutos(typDatSetTbProdutos);
		}
		#endregion 
		#region tbExportadoresAgentesContatos
		// NADA 
		#endregion
		#region tbExportadoresAgentesVendas
			private void CheckIntegrityRowDeletedTbExportadoresAgentesVendas(mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwDeleted)
			{
				// tbExportadoresAgentesVendasBancos
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("nIdAgente");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdAgente",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos typDatSetExportadoresAgentesVendasBancos = this.GetTbExportadoresAgentesVendasBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos);
				this.SetTbExportadoresAgentesVendasBancos(typDatSetExportadoresAgentesVendasBancos);
			}
		#endregion
		#region tbExportadoresAgentesVendasBancos
		// NADA
		#endregion
		#region tbExportadoresBancos
		private void CheckIntegrityRowDeletedTbExportadoresBancos(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwDeleted)
		{
			// tbExportadoresBancosAgencias
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("nIdBanco");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdBanco",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias typDatSetExportadoresBancosAgencias = this.GetTbExportadoresBancosAgencias(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetExportadoresBancosAgencias.tbExportadoresBancosAgencias);
			this.SetTbExportadoresBancosAgencias(typDatSetExportadoresBancosAgencias);
		}
		#endregion
		#region tbExportadoresBancosAgencias
		private void CheckIntegrityRowDeletedTbExportadoresBancosAgencias(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwDeleted)
		{
			// tbExportadoresBancosAgenciasContas
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("nIdBanco");
			m_arlCondicaoCampo.Add("strAgencia");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdBanco",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["strAgencia",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas typDatSetExportadoresBancosAgenciasContas = this.GetTbExportadoresBancosAgenciasContas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas);
			this.SetTbExportadoresBancosAgenciasContas(typDatSetExportadoresBancosAgenciasContas);

			// tbExportadoresBancosAgenciasContatos
//			m_arlCondicaoCampo.Clear();
//			m_arlCondicaoCampo.Add("idExportador");
//			m_arlCondicaoCampo.Add("idBanco");
//			m_arlCondicaoCampo.Add("idAgencia");
//			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas typDatSetExportadoresBancosAgenciasContas = this.GetTbExportadoresBancosAgenciasContas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
//			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas);
//			this.SetTbExportadoresBancosAgenciasContas(typDatSetExportadoresBancosAgenciasContas);

		}
		#endregion
		#region tbExportadoresBancosAgenciasContas
		// NADA
		#endregion
		#region tbExportadoresBancosAgenciasContatos
		// NADA
		#endregion
		#region tbExportadoresVolumes
		// NADA 
		#endregion

		#region tbFaturasComerciais
		private void CheckIntegrityRowDeletedTbFaturasComerciais(mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwDeleted)
		{
			// tbProdutosFaturaComercial
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial = this.GetTbProdutosFaturaComercial(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial);
			this.SetTbProdutosFaturaComercial(typDatSetTbProdutosFaturaComercial);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");

			//tbFaturasComerciaisColunas
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas typDatSetTbFaturasComerciaisColunas = this.GetTbFaturasComerciaisColunas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasComerciaisColunas.tbFaturasComerciaisColunas);
			this.SetTbFaturasComerciaisColunas(typDatSetTbFaturasComerciaisColunas);

		}
		#endregion
		#region tbFaturasCotacoes
		private void CheckIntegrityRowDeletedTbFaturasCotacoes(mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwDeleted)
		{
			// tbProdutosFaturaCotacao
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idCotacao");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idCotacao",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFaturaCotacao = this.GetTbProdutosFaturaCotacao(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao);
			this.SetTbProdutosFaturaCotacao(typDatSetTbProdutosFaturaCotacao);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdCotacao");

			//tbFaturasCotacoesColunas
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetTbFaturasCotacoesColunas = this.GetTbFaturasCotacoesColunas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasCotacoesColunas.tbFaturasCotacoesColunas);
			this.SetTbFaturasCotacoesColunas(typDatSetTbFaturasCotacoesColunas);
		}
		#endregion
		#region tbFaturasProformas
		private void CheckIntegrityRowDeletedTbFaturasProformas(mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwDeleted)
		{
			// tbProdutosFaturaProforma
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFaturaProforma = this.GetTbProdutosFaturaProforma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaProforma.tbProdutosFaturaProforma);
			this.SetTbProdutosFaturaProforma(typDatSetTbProdutosFaturaProforma);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");

			//tbFaturasProformasColunas
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas typDatSetTbFaturasProformasColunas = this.GetTbFaturasProformasColunas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasProformasColunas.tbFaturasProformasColunas);
			this.SetTbFaturasProformasColunas(typDatSetTbFaturasProformasColunas);

		}
		#endregion

		#region tbIdiomas
		// NADA
		#endregion
		#region tbIdiomasTextos
		// NADA 
		#endregion

		#region tbImagens
		// NADA
		#endregion

		#region tbImportadores
		private void CheckIntegrityRowDeletedTbImportadores(mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwDeleted)
		{
			// tbImportadoresBancos
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("nIdImportador");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idImportador",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos typDatSetTbImportadoresBancos = this.GetTbImportadoresBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbImportadoresBancos.tbImportadoresBancos);
			this.SetTbImportadoresBancos(typDatSetTbImportadoresBancos);

			// tbImportadoresConsignatarios
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios typDatSetTbImportadoresConsignatarios = this.GetTbImportadoresConsignatarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios);
			this.SetTbImportadoresConsignatarios(typDatSetTbImportadoresConsignatarios);

			// tbImportadoresEndEntrega
			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idImportador");
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega typDatSetTbImportadoresEndEntrega = this.GetTbImportadoresEndEntrega(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega);
			this.SetTbImportadoresEndEntrega(typDatSetTbImportadoresEndEntrega);
		}
		#endregion
		#region tbImportadoresBancos
		// NADA 
		#endregion
		#region tbImportadoresConsignatarios
		// NADA 
		#endregion
		#region tbImportadoresEndEntrega
		// NADA 
		#endregion

		#region tbIncoterms
		// NADA
		#endregion

		#region tbInstrucoesEmbarque
		// NADA
		#endregion

		#region tbLogMedicaoTempo
		// NADA
		#endregion

		#region tbMaquinas
		// NADA 
		#endregion

		#region tbModulos
		// NADA
		#endregion

		#region tbMoedas
		// NADA
		#endregion

		#region tbNotasFiscais
		// NADA 
		#endregion

		#region tbPaises
		// NADA
		#endregion
		#region tbPaisesIdiomas
		// NADA
		#endregion

		#region tbPes
		private void CheckIntegrityRowDeletedTbPes(mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwDeleted)
		{
			// tbBorderos
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetTbBorderos = this.GetTbBorderos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbBorderos.tbBorderos);
			this.SetTbBorderos(typDatSetTbBorderos);

			// tbCertificadosOrigem
			mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetTbCertificadosOrigem = this.GetTbCertificadosOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbCertificadosOrigem.tbCertificadosOrigem);
			this.SetTbCertificadosOrigem(typDatSetTbCertificadosOrigem);

			// tbFaturasComerciais
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = this.GetTbFaturasComerciais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasComerciais.tbFaturasComerciais);
			this.SetTbFaturasComerciais(typDatSetTbFaturasComerciais);

			// tbFaturasProformas
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetTbFaturasProformas = this.GetTbFaturasProformas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbFaturasProformas.tbFaturasProformas);
			this.SetTbFaturasProformas(typDatSetTbFaturasProformas);

			// tbInstrucoesEmbarque
			mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = this.GetTbInstrucoesEmbarque(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque);
			this.SetTbInstrucoesEmbarque(typDatSetTbInstrucoesEmbarque);

			// tbRomaneios
			mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetTbRomaneios = this.GetTbRomaneios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRomaneios.tbRomaneios);
			this.SetTbRomaneios(typDatSetTbRomaneios);

			// tbSaques
			mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetTbSaques = this.GetTbSaques(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbSaques.tbSaques);
			this.SetTbSaques(typDatSetTbSaques);

			// tbSumarios
			mdlDataBaseAccess.Tabelas.XsdTbSumarios typDatSetTbSumarios = this.GetTbSumarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbSumarios.tbSumarios);
			this.SetTbSumarios(typDatSetTbSumarios);

			// tbBorderosSecundarios
			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");
			mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios typDatSetTbBorderosSecundarios = this.GetTbBorderosSecundarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbBorderosSecundarios.tbBorderosSecundarios);
			this.SetTbBorderosSecundarios(typDatSetTbBorderosSecundarios);

			// tbNotasFiscais
			mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais typDatSetTbNotasFiscais = this.GetTbNotasFiscais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbNotasFiscais.tbNotasFiscais);
			this.SetTbNotasFiscais(typDatSetTbNotasFiscais);

			// tbProcessosContainers
			mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers typDatSetTbProcessosContainers = this.GetTbProcessosContainers(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProcessosContainers.tbProcessosContainers);
			this.SetTbProcessosContainers(typDatSetTbProcessosContainers);

			// tbREsPEs
			mdlDataBaseAccess.Tabelas.XsdTbREsPEs typDatSetTbREsPEs = this.GetTbREsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbREsPEs.tbREsPEs);
			this.SetTbREsPEs(typDatSetTbREsPEs);

			// tbDSEsPEs
			mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs typDatSetTbDSEsPEs = this.GetTbDSEsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbDSEsPEs.tbDSEsPEs);
			this.SetTbDSEsPEs(typDatSetTbDSEsPEs);
		}
		#endregion

		#region tbProdutos
		private void CheckIntegrityRowDeletedTbProdutos(mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwDeleted)
		{
									
			// tbProdutosFaturaComercial
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idProduto");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idProduto",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial = this.GetTbProdutosFaturaComercial(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial);
			this.SetTbProdutosFaturaComercial(typDatSetTbProdutosFaturaComercial);

			// tbProdutosFaturaProforma
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFaturaProforma = this.GetTbProdutosFaturaProforma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaProforma.tbProdutosFaturaProforma);
			this.SetTbProdutosFaturaProforma(typDatSetTbProdutosFaturaProforma);

			// tbProdutosFaturaCotacao
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFaturaCotacao = this.GetTbProdutosFaturaCotacao(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao);
			this.SetTbProdutosFaturaCotacao(typDatSetTbProdutosFaturaCotacao);
		}
		#endregion
		#region tbProdutosBordero
		// NADA
		#endregion
		#region tbProdutosCategorias
		// NADA
		#endregion
		#region tbProdutosCertificadoOrigem
		// NADA
		#endregion
		#region tbProdutosFaturaComercial
		private void CheckIntegrityRowDeletedTbProdutosFaturaComercial(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwDeleted)
		{
			// tbProdutosCertificadoOrigem
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("idOrdemProduto");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPE",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idOrdem",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem = this.GetTbProdutosCertificadoOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem);
			this.SetTbProdutosCertificadoOrigem(typDatSetTbProdutosCertificadoOrigem);

			// tbProdutosRomaneioEmbalagensProdutos
			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("nIdOrdemProduto");
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos = this.GetTbProdutosRomaneioEmbalagensProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos);
			this.SetTbProdutosRomaneioEmbalagensProdutos(typDatSetTbProdutosRomaneioEmbalagensProdutos);

			// tbProdutosRomaneioVolumesProdutos
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos = this.GetTbProdutosRomaneioVolumesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos);
			this.SetTbProdutosRomaneioVolumesProdutos(typDatSetTbProdutosRomaneioVolumesProdutos);

			// tbProdutosRomaneioSimplificado
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetTbProdutosRomaneioSimplificado = this.GetTbProdutosRomaneioSimplificado(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado);
			this.SetTbProdutosRomaneioSimplificado(typDatSetTbProdutosRomaneioSimplificado);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");
			m_arlCondicaoCampo.Add("nIdOrdem");

			// tbProdutosFaturaComercialPropriedades
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetTbProdutosFaturaComercialPropriedades = this.GetTbProdutosFaturaComercialPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedades);
			this.SetTbProdutosFaturaComercialPropriedades(typDatSetTbProdutosFaturaComercialPropriedades);

		}	
		#endregion
		#region tbProdutosFaturaCotacao
		private void CheckIntegrityRowDeletedTbProdutosFaturaCotacao(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwDeleted)
		{
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdCotacao");
			m_arlCondicaoCampo.Add("nIdOrdem");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idCotacao",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idOrdem",System.Data.DataRowVersion.Original]);

			// tbProdutosFaturaCotacaoPropriedades
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetTbProdutosFaturaCotacaoPropriedades = this.GetTbProdutosFaturaCotacaoPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades);
			this.SetTbProdutosFaturaCotacaoPropriedades(typDatSetTbProdutosFaturaCotacaoPropriedades);
		}

		#endregion
		#region tbProdutosFaturaProforma
			private void CheckIntegrityRowDeletedTbProdutosFaturaProforma(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwDeleted)
			{
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("strIdPe");
				m_arlCondicaoCampo.Add("nIdOrdem");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["idOrdem",System.Data.DataRowVersion.Original]);

				// tbProdutosFaturaProformaPropriedades
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetTbProdutosFaturaProformaPropriedades = this.GetTbProdutosFaturaProformaPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedades);
				this.SetTbProdutosFaturaProformaPropriedades(typDatSetTbProdutosFaturaProformaPropriedades);
			}
		#endregion
		#region tbProdutosIdiomas
		// NADA
		#endregion
		#region tbProdutosNaladi
		//NADA
		#endregion
		#region tbProdutosNcm
		// NADA 
		#endregion
		#region tbProdutosParents
		// NADA

		#endregion
		#region tbProdutosRomaneioEmbalagens
		// NADA
		#endregion
		#region tbProdutosRomaneioEmbalagensProdutos
		// NADA
		#endregion
		#region tbProdutosRomaneioVolumes
		// NADA 
		#endregion
		#region tbProdutosRomaneioVolumesProdutos
		// NADA
		#endregion
		#region tbPropriedadesProdutos
			private void CheckIntegrityRowDeletedTbPropriedadesProdutos(mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwDeleted)
			{
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("nIdPropriedade");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdPropriedade",System.Data.DataRowVersion.Original]);

				// tbProdutosFaturaComercialPropriedades
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetTbProdutosFaturaComercialPropriedades = this.GetTbProdutosFaturaComercialPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedades);
				this.SetTbProdutosFaturaComercialPropriedades(typDatSetTbProdutosFaturaComercialPropriedades);

				// tbProdutosFaturaCotacaoPropriedades
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetTbProdutosFaturaCotacaoPropriedades = this.GetTbProdutosFaturaCotacaoPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedades);
				this.SetTbProdutosFaturaCotacaoPropriedades(typDatSetTbProdutosFaturaCotacaoPropriedades);

				// tbProdutosFaturaProformaPropriedades
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetTbProdutosFaturaProformaPropriedades = this.GetTbProdutosFaturaProformaPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedades);
				this.SetTbProdutosFaturaProformaPropriedades(typDatSetTbProdutosFaturaProformaPropriedades);
			}
		#endregion

		#region tbRelatorioCampoBD
		// NADA
		#endregion
		#region tbRelatorioCirculos
		// NADA
		#endregion
		#region tbRelatorioEtiquetas
		// NADA
		#endregion
		#region tbRelatorioImagens
		// NADA
		#endregion
		#region tbRelatorioLinhas
		// NADA
		#endregion
		#region tbRelatorioRetangulos
		// NADA
		#endregion
		#region tbRelatorios
			private void CheckIntegrityRowDeletedTbRelatorios(mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwDeleted)
			{
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);

				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);

				m_arlCondicaoCampo.Add("nIdTipo");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);

				m_arlCondicaoCampo.Add("nIdRelatorio");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);

				// tbRelatorioLinhas
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas typDatSetTbRelatorioLinhas = this.GetTbRelatorioLinhas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioLinhas.tbRelatorioLinhas);
				this.SetTbRelatorioLinhas(typDatSetTbRelatorioLinhas);

				// tbRelatorioRetangulos
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos typDatSetTbRelatorioRetangulos = this.GetTbRelatorioRetangulos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioRetangulos.tbRelatorioRetangulos);
				this.SetTbRelatorioRetangulos(typDatSetTbRelatorioRetangulos);

				// tbRelatorioCirculos
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos typDatSetTbRelatorioCirculos = this.GetTbRelatorioCirculos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioCirculos.tbRelatorioCirculos);
				this.SetTbRelatorioCirculos(typDatSetTbRelatorioCirculos);

				// tbRelatorioEtiquetas
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas typDatSetTbRelatorioEtiquetas = this.GetTbRelatorioEtiquetas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioEtiquetas.tbRelatorioEtiquetas);
				this.SetTbRelatorioEtiquetas(typDatSetTbRelatorioEtiquetas);

				// tbRelatorioImagens
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens typDatSetTbRelatorioImagens = this.GetTbRelatorioImagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioImagens.tbRelatorioImagens);
				this.SetTbRelatorioImagens(typDatSetTbRelatorioImagens);

				// tbRelatorioCamposBD
				mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD typDatSetTbRelatorioCamposBD = this.GetTbRelatorioCamposBD(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRelatorioCamposBD.tbRelatorioCamposBD);
				this.SetTbRelatorioCamposBD(typDatSetTbRelatorioCamposBD);
			}
		#endregion
		#region tbRelatoriosCamposBDPreRequisitos
		// NADA
		#endregion
		#region tbRelatoriosCamposBDRelatorios
		// NADA
		#endregion
		#region tbRelatoriosTodosCamposBD
		// NADA
		#endregion
		#region tbRelatorioTipo
		// NADA
		#endregion

		#region tbREs
		private void CheckIntegrityRowDeletedTbREs(mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwDeleted)
		{
						
			// tbREsPEs
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoCampo.Add("nIdRE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["nIdRE",System.Data.DataRowVersion.Original]);


			mdlDataBaseAccess.Tabelas.XsdTbREsPEs typDatSetTbREsPEs = this.GetTbREsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbREsPEs.tbREsPEs);
			this.SetTbREsPEs(typDatSetTbREsPEs);
		}
		#endregion

		#region tbRomaneios
		private void CheckIntegrityRowDeletedTbRomaneios(mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwDeleted)
		{
						
			// tbProdutosRomaneioEmbalagens
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwDeleted["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwDeleted["idPe",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens = this.GetTbProdutosRomaneioEmbalagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens);
			this.SetTbProdutosRomaneioEmbalagens(typDatSetTbProdutosRomaneioEmbalagens);

			// tbProdutosRomaneioEmbalagensProdutos
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos = this.GetTbProdutosRomaneioEmbalagensProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos);
			this.SetTbProdutosRomaneioEmbalagensProdutos(typDatSetTbProdutosRomaneioEmbalagensProdutos);

			// tbProdutosRomaneioVolumes
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes = this.GetTbProdutosRomaneioVolumes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes);
			this.SetTbProdutosRomaneioVolumes(typDatSetTbProdutosRomaneioVolumes);

			// tbProdutosRomaneioVolumesProdutos
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos = this.GetTbProdutosRomaneioVolumesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos);
			this.SetTbProdutosRomaneioVolumesProdutos(typDatSetTbProdutosRomaneioVolumesProdutos);

			// tbProdutosRomaneioSimplificado
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetTbProdutosRomaneioSimplificado = this.GetTbProdutosRomaneioSimplificado(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado);
			this.SetTbProdutosRomaneioSimplificado(typDatSetTbProdutosRomaneioSimplificado);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");
			// tbRomaneiosSecundarios
			mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios typDatSetTbRomaneioSecundarios = this.GetTbRomaneiosSecundarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbRomaneioSecundarios.tbRomaneiosSecundarios);
			this.SetTbRomaneiosSecundarios(typDatSetTbRomaneioSecundarios);
		}
		#endregion

		#region tbSaques
		// NADA
		#endregion

		#region tbSumarios
		// NADA
		#endregion

		#region tbTerminais
			private void CheckIntegrityRowDeletedTbTerminais(mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwDeleted)
			{
				// tbTerminaisContatos
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdTerminal");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdTerminal",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos typDatSetTbTerminaisContatos = this.GetTbTerminaisContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbTerminaisContatos.tbTerminaisContatos);
				this.SetTbTerminaisContatos(typDatSetTbTerminaisContatos);
			}
		#endregion
		#region tbTerminaisContatos
			// NADA
		#endregion

		#region tbTipoCO
		// NADA
		#endregion

		#region tbTransportadoras
			private void CheckIntegrityRowDeletedTbTransportadoras(mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwDeleted)
			{
				// tbTransportadorasContatos
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("nIdTransportadora");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwDeleted["nIdTransportadora",System.Data.DataRowVersion.Original]);
				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos typDatSetTbTransportadorasContatos = this.GetTbTransportadorasContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbTransportadorasContatos.tbTransportadorasContatos);
				this.SetTbTransportadorasContatos(typDatSetTbTransportadorasContatos);

				// tbTransportadorasMotoristas
				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas typDatSetTbTransportadorasMotoristas = this.GetTbTransportadorasMotoristas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbTransportadorasMotoristas.tbTransportadorasMotoristas);
				this.SetTbTransportadorasMotoristas(typDatSetTbTransportadorasMotoristas);

				// tbTransportadorasVeiculos
				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos typDatSetTbTransportadorasVeiculos = this.GetTbTransportadorasVeiculos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				CheckIntegrityRowDeletedFullDeleteRows((System.Data.DataTable)typDatSetTbTransportadorasVeiculos.tbTransportadorasVeiculos);
				this.SetTbTransportadorasVeiculos(typDatSetTbTransportadorasVeiculos);
			}
		#endregion
		#region tbTransportadorasContatos
			//NADA
		#endregion
		#region tbTransportadorasMotoristas
			//NADA
		#endregion
		#region tbTransportadorasVeiculos
			//NADA
		#endregion

		#region tbTransportes
		// NADA
		#endregion

		#region tbUnidadesEspaco
		// NADA
		#endregion
		#region tbUnidadesEspacoIdioma
		// NADA
		#endregion
		#region tbUnidadesMassa
		// NADA
		#endregion
		#region tbUnidadesMassaIdioma
		// NADA
		#endregion

		#region tbUsuarios
		// NADA 
		#endregion
		#region tbUsuariosAtivos
		// NADA
		#endregion
		#region tbUsuariosConcessoes
		// NADA 
		#endregion
		#region tbUsuariosConcessoesPermissoes
		// NADA
		#endregion
		#region tbUsuariosMsgs
		// NADA
		#endregion
		#region tbUsuariosPermissoes
		// NADA 
		#endregion
		#region tbUsuariosPermissoesConcessoes
		// NADA
		#endregion

		#region tbVersao
		// NADA
		#endregion
		#region tbVersaoModulo
		// NADA
		#endregion

		#region tbVolumes
		// NADA
		#endregion

		#region tbWebServicesServicos
		// NADA
		#endregion
		#region tbWebServicesServidores
		// NADA
		#endregion
		#region tbWebServicesServidoresServicos
		// NADA
		#endregion
	
		#endregion
		#region Integrity Tables Updated
		#region vCheckIntegrityRowUpdatedRows
		private void vCheckIntegrityRowUpdatedRows(ref System.Data.DataTable dttbUpdate,string strColumnName,object objValue)
		{
			for (int nCont = 0;nCont < dttbUpdate.Rows.Count; nCont++)
			{
				dttbUpdate.Rows[nCont][strColumnName] = objValue;
			}
		}
		#endregion

		#region tbCertificadosOrigem
		private void CheckIntegrityRowUpdatedTbCertificadosOrigem(mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbProdutosCertificadoOrigem
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("idTipoCO");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idPe",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["nIdTipoCO",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem = this.GetTbProdutosCertificadoOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosCertificadoOrigem(typDatSetTbProdutosCertificadoOrigem);
		}
		#endregion
		#region tbExportadoresBancosAgencias
		private void CheckIntegrityRowUpdatedTbExportadoresBancosAgencias(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbExportadoresBancosAgenciasContas
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("nIdBanco");
			m_arlCondicaoCampo.Add("strAgencia");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["nIdExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["nIdBanco",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["strAgencia",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas typDatSetExportadoresBancosAgenciasContas = this.GetTbExportadoresBancosAgenciasContas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strAgencia",dtrwUpdated["strAgencia",System.Data.DataRowVersion.Current]);
			this.SetTbExportadoresBancosAgenciasContas(typDatSetExportadoresBancosAgenciasContas);
		}
		#endregion

		#region tbFaturasComerciais
		private void CheckIntegrityRowUpdatedTbFaturasComerciais(mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbProdutosFaturaComercial
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idPe",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial = this.GetTbProdutosFaturaComercial(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosFaturaComercial(typDatSetTbProdutosFaturaComercial);
		}
		#endregion
		#region tbFaturasCotacoes
		private void CheckIntegrityRowUpdatedTbFaturasCotacoes(mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbProdutosFaturaCotacao
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idCotacao");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idCotacao",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFaturaCotacao = this.GetTbProdutosFaturaCotacao(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idCotacao",dtrwUpdated["idCotacao",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosFaturaCotacao(typDatSetTbProdutosFaturaCotacao);
		}
		#endregion
		#region tbFaturasProformas
		private void CheckIntegrityRowUpdatedTbFaturasProformas(mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbProdutosFaturaProforma
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idPe",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFaturaProforma = this.GetTbProdutosFaturaProforma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosFaturaProforma.tbProdutosFaturaProforma;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPe",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosFaturaProforma(typDatSetTbProdutosFaturaProforma);
		}
		#endregion

		#region tbPes
		private void CheckIntegrityRowUpdatedTbPes(mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbBorderos
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idPe",System.Data.DataRowVersion.Original]);
			mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetTbBorderos = this.GetTbBorderos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbBorderos.tbBorderos;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbBorderos(typDatSetTbBorderos);

			// tbCertificadosOrigem
			mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetTbCertificadosOrigem = this.GetTbCertificadosOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbCertificadosOrigem.tbCertificadosOrigem;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbCertificadosOrigem(typDatSetTbCertificadosOrigem);

			// tbFaturasComerciais
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = this.GetTbFaturasComerciais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbFaturasComerciais.tbFaturasComerciais;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbFaturasComerciais(typDatSetTbFaturasComerciais);

			// tbFaturasProformas
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetTbFaturasProformas = this.GetTbFaturasProformas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbFaturasProformas.tbFaturasProformas;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbFaturasProformas(typDatSetTbFaturasProformas);

			// tbInstrucoesEmbarque
			mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = this.GetTbInstrucoesEmbarque(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbInstrucoesEmbarque(typDatSetTbInstrucoesEmbarque);

			// tbRomaneios
			mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetTbRomaneios = this.GetTbRomaneios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbRomaneios.tbRomaneios;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbRomaneios(typDatSetTbRomaneios);

			// tbSaques
			mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetTbSaques = this.GetTbSaques(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbSaques.tbSaques;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current].ToString());
			this.SetTbSaques(typDatSetTbSaques);

			// tbSumarios
			mdlDataBaseAccess.Tabelas.XsdTbSumarios typDatSetTbSumarios = this.GetTbSumarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbSumarios.tbSumarios;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbSumarios(typDatSetTbSumarios);

			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("nIdExportador");
			m_arlCondicaoCampo.Add("strIdPE");

			// tbGuiasEntrada
			mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada typDatSetTbGuiasEntrada = this.GetTbGuiasEntrada(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbGuiasEntrada.tbGuiasEntrada;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strIdPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbGuiasEntrada(typDatSetTbGuiasEntrada);

			// tbReservas
			mdlDataBaseAccess.Tabelas.XsdTbReservas typDatSetTbReservas = this.GetTbReservas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbReservas.tbReservas;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strIdPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbReservas(typDatSetTbReservas);

			// tbREsPEs
			mdlDataBaseAccess.Tabelas.XsdTbREsPEs typDatSetTbREsPEs = this.GetTbREsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbREsPEs.tbREsPEs;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strIdPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbREsPEs(typDatSetTbREsPEs);

			// tbDSEsPEs
			mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs typDatSetTbDSEsPEs = this.GetTbDSEsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbDSEsPEs.tbDSEsPEs;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strIdPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			this.SetTbDSEsPEs(typDatSetTbDSEsPEs);
		}
		#endregion

		#region tbProdutosFaturaComercial
		private void CheckIntegrityRowUpdatedTbProdutosFaturaComercial(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwUpdated)
		{
			System.Data.DataTable dttbTabela;

			// tbProdutosCertificadoOrigem
			System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("idOrdemProduto");
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idPE",System.Data.DataRowVersion.Original]);
			m_arlCondicaoValor.Add(dtrwUpdated["idOrdem",System.Data.DataRowVersion.Original]);

			mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem = this.GetTbProdutosCertificadoOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idOrdemProduto",dtrwUpdated["idOrdem",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosCertificadoOrigem(typDatSetTbProdutosCertificadoOrigem);

			// tbProdutosRomaneioEmbalagensProdutos
			m_arlCondicaoCampo.Clear();
			m_arlCondicaoCampo.Add("idExportador");
			m_arlCondicaoCampo.Add("idPE");
			m_arlCondicaoCampo.Add("nIdOrdemProduto");
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos = this.GetTbProdutosRomaneioEmbalagensProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"nIdOrdemProduto",dtrwUpdated["idOrdem",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosRomaneioEmbalagensProdutos(typDatSetTbProdutosRomaneioEmbalagensProdutos);

			// tbProdutosRomaneioVolumesProdutos
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos = this.GetTbProdutosRomaneioVolumesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
			dttbTabela = typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos;
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
			vCheckIntegrityRowUpdatedRows(ref dttbTabela,"nIdOrdemProduto",dtrwUpdated["idOrdem",System.Data.DataRowVersion.Current]);
			this.SetTbProdutosRomaneioVolumesProdutos(typDatSetTbProdutosRomaneioVolumesProdutos);
		}	
		#endregion
		#region tbRomaneios
			private void CheckIntegrityRowUpdatedTbRomaneios(mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwUpdated)
			{
				System.Data.DataTable dttbTabela;

				// tbProdutosRomaneioEmbalagens
				System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();
				m_arlCondicaoCampo.Add("idExportador");
				m_arlCondicaoCampo.Add("idPE");
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				m_arlCondicaoValor.Add(dtrwUpdated["idExportador",System.Data.DataRowVersion.Original]);
				m_arlCondicaoValor.Add(dtrwUpdated["idPe",System.Data.DataRowVersion.Original]);

				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetTbProdutosRomaneioEmbalagens = this.GetTbProdutosRomaneioEmbalagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbProdutosRomaneioEmbalagens(typDatSetTbProdutosRomaneioEmbalagens);

				// tbProdutosRomaneioEmbalagensProdutos
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetTbProdutosRomaneioEmbalagensProdutos = this.GetTbProdutosRomaneioEmbalagensProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbProdutosRomaneioEmbalagensProdutos(typDatSetTbProdutosRomaneioEmbalagensProdutos);

				// tbProdutosRomaneioVolumes
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetTbProdutosRomaneioVolumes = this.GetTbProdutosRomaneioVolumes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumes;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbProdutosRomaneioVolumes(typDatSetTbProdutosRomaneioVolumes);

				// tbProdutosRomaneioVolumesProdutos
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetTbProdutosRomaneioVolumesProdutos = this.GetTbProdutosRomaneioVolumesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbProdutosRomaneioVolumesProdutos(typDatSetTbProdutosRomaneioVolumesProdutos);

				// tbProdutosRomaneioSimplificado
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetTbProdutosRomaneioSimplificado = this.GetTbProdutosRomaneioSimplificado(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"idPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbProdutosRomaneioSimplificado(typDatSetTbProdutosRomaneioSimplificado);

				m_arlCondicaoCampo.Clear();
				m_arlCondicaoCampo.Add("nIdExportador");
				m_arlCondicaoCampo.Add("strIdPE");
				// tbRomaneiosSecundarios
				mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios typDatSetTbRomaneioSecundarios = this.GetTbRomaneiosSecundarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				dttbTabela = typDatSetTbRomaneioSecundarios.tbRomaneiosSecundarios;
				vCheckIntegrityRowUpdatedRows(ref dttbTabela,"strIdPE",dtrwUpdated["idPe",System.Data.DataRowVersion.Current]);
				this.SetTbRomaneiosSecundarios(typDatSetTbRomaneioSecundarios);
			}
		#endregion
		#endregion
		#endregion

		#region Configuration
		public void vLoadConfigurationInMemory()
		{
			m_typDatSetTbConfiguracoes = new mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes();
			SetCommandSelect("SELECT * FROM tbConfiguracoes");
			SetSQLSelect("tbConfiguracoes",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)m_typDatSetTbConfiguracoes;
			DataAdapterFill(ref dtstTabela,"tbConfiguracoes");
		}

		public void vSaveConfigurationFromMemory()
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)m_typDatSetTbConfiguracoes;
			SetCommandSelect("SELECT * FROM tbConfiguracoes"); 
			DataAdapterUpdate(dtstGeneric,"tbConfiguracoes");
			m_typDatSetTbConfiguracoes.Dispose();
			m_typDatSetTbConfiguracoes = null;
		}
			
		public void vClearConfigurationInMemory()
		{
			m_typDatSetTbConfiguracoes.Dispose();
			m_typDatSetTbConfiguracoes = null;
		}

		public bool bConfigurationInMemory()
		{
			return(m_typDatSetTbConfiguracoes != null);
		}
		#endregion

		#region Data
		/// <summary>
		/// Fill the Data Set, Pleaseeeee Optimize this
		/// </summary>
		/// <param name="dtstData"></param>
		private void DataSetFill(System.Data.DataSet dtstData)
		{
			System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetAssembly((new mdlDataBaseData.clsIdentificacao()).GetType());
			// Getting all types in current assembly
			string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
			System.Data.DataTable dttbData = dtstData.Tables[0];
			foreach(string strCurrent in arrStrAssembly)
			{
				if (("MDLDATABASEDATA.DADOS.XML" + dtstData.Tables[0].TableName.ToUpper() + ".XML" == strCurrent.ToUpper()))
				{
					System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
					if ((m_strDataResourceSelect == "") && (m_strDataResourceOrder == ""))
					{
						// Doesnt exist Select or Order 
						dtstData.ReadXml(stmResource);
					}else{
						// Have Select or Order 
						System.Data.DataSet dtstTemp = dtstData.Clone();
						dtstTemp.ReadXml(stmResource);
						System.Data.DataRow[] dtrwProdutos = dtstTemp.Tables[0].Select(m_strDataResourceSelect,m_strDataResourceOrder,System.Data.DataViewRowState.CurrentRows);
						System.Data.DataRow dtrwProdutoAdd = null;
						foreach(System.Data.DataRow dtrwProduto in dtrwProdutos)
						{
							dtrwProdutoAdd = dtstData.Tables[0].NewRow();
							for(int nCont = 0; nCont < dtrwProduto.ItemArray.GetLength(0);nCont++)
								dtrwProdutoAdd[nCont] = dtrwProduto[nCont];
							dtstData.Tables[0].Rows.Add(dtrwProdutoAdd);
						}
						dtstData.AcceptChanges();
					}
   					break;
				}
			}
		}
		#endregion

		#region UpdateDataBase
			protected abstract bool bErrorMessageTableDoesntExist(System.Exception eError,string strTableName);
			protected abstract bool bErrorMessageColumnDoesntExist(System.Exception eError,string strColumnName);

			public int nUpdateDataBase()
			{
				OnCallDBUpdateInfoClear();
				OnCallDBUpdateInfoInsert();
				OnCallDBUpdateInfoInsert("Iniciando Atualização da Base de Dados");
				OnCallDBUpdateInfoInsert();

				int nRetorno = 0;
				System.Data.DataSet dtstCurrent = null;
				System.Data.DataTable dttbCurrent = null;
				// Getting the current assembly
				System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
				// Getting all types in current assembly
				System.Type[] arrTypAssembly = assCurrent.GetTypes();
				foreach(System.Type typCurrent in arrTypAssembly)
				{
					// Only Types that have 'Tabelas' with namespace and Without + in your name // All TypedDataSets
					if ((typCurrent.Namespace == "mdlDataBaseAccess.Tabelas") && (typCurrent.ToString().IndexOf("+") == -1))
					{
						nRetorno++;
						// Creating a instance off the table
						System.Reflection.ConstructorInfo consCurrent = typCurrent.GetConstructor(System.Type.EmptyTypes);
						dtstCurrent = (System.Data.DataSet)consCurrent.Invoke(null);
						// Trying to use the DataSet
						dttbCurrent = dtstCurrent.Tables[0]; 
						vSetCommandSelectFullSelect(ref dttbCurrent);
						DataAdapterFill(ref dtstCurrent,dttbCurrent.TableName);
						if (m_excError != null)
						{
							OnCallDBUpdateInfoInsert(dttbCurrent.TableName);
							string strSQL = "";
							if (bErrorMessageTableDoesntExist(m_excError,dttbCurrent.TableName))
							{
								// Table Doesnt exist
								strSQL = strReturnCommandCreateTable(ref dttbCurrent);
								OnCallDBUpdateInfoInsert(strSQL);
								vExecuteCommand(strSQL);
								if (m_excError != null)
								{
									OnCallDBUpdateInfoInsert();
									OnCallDBUpdateInfoInsert("Erro ao Criar Tabela");
									OnCallDBUpdateInfoInsert();
									OnCallDBUpdateInfoInsert(m_excError.ToString());
									OnCallDBUpdateInfoInsert();
									return(ERROR_UPDATE_CREATE_TABLE);
								}
							}else{
								// Table need be Modified
								System.Collections.ArrayList arlColumns = new System.Collections.ArrayList();
								foreach(System.Data.DataColumn dtclCurrent in dttbCurrent.Columns)
								{
									// Verifiing if the Column is not Primary Key
									bool bPrimaryKey = false;
									for (int nCont = 0;nCont < dttbCurrent.PrimaryKey.Length;nCont++)
									{
										if (dttbCurrent.PrimaryKey[nCont].ColumnName == dtclCurrent.ColumnName)
										{
											bPrimaryKey = true;
											break;
										}
									}
									if (!bPrimaryKey)
									{
										vSetCommandSelectOneColumn(ref dttbCurrent,dtclCurrent);
										DataAdapterFill(ref dtstCurrent,dttbCurrent.TableName);
										if (bErrorMessageColumnDoesntExist(m_excError,dtclCurrent.ColumnName))
										{
											// Column need be Added
											arlColumns.Add(dtclCurrent);
										}
									}
								}
								if (arlColumns.Count > 0)
								{
									strSQL = strReturnCommandAlterTableAdd(ref dttbCurrent,ref arlColumns);
									OnCallDBUpdateInfoInsert(strSQL);
									vExecuteCommand(strSQL);
									if (m_excError != null)
									{
										OnCallDBUpdateInfoInsert();
										OnCallDBUpdateInfoInsert("Erro ao Alterar Tabela");
										OnCallDBUpdateInfoInsert();
										OnCallDBUpdateInfoInsert(m_excError.ToString());
										OnCallDBUpdateInfoInsert();
										return(ERROR_UPDATE_ALTER_TABLE_ADD);
									}
								}
							}
						}
					}
				}
				OnCallDBUpdateInfoInsert();
				OnCallDBUpdateInfoInsert("Sucesso");
				OnCallDBUpdateInfoInsert();
				OnCallDBUpdateInfoInsert(nRetorno.ToString() + " tabelas");
				OnCallDBUpdateInfoInsert();
				return(nRetorno);
			}

			protected bool bIsPrimaryKey(System.Data.DataColumn[] dtclPrimaryKey,System.Data.DataColumn dtclCurrent)
			{
				for(int i = 0;i < dtclPrimaryKey.Length;i++)
				{
					if (dtclPrimaryKey[i] == dtclCurrent)
						return(true);
				}
				return(false);
			}

			protected abstract string strReturnTypeDataColumn(System.Data.DataColumn dtclColuna);
			protected abstract string strReturnCommandCreateTable(ref System.Data.DataTable dttbTable);
			protected abstract string strReturnCommandAlterTableAdd(ref System.Data.DataTable dttbTable,ref System.Collections.ArrayList arlColumns);
			protected abstract void vExecuteCommand(string strSQL);
		#endregion
		#region DeteleDataBase
			public virtual bool DeleteAllDataBase()
			{
				this.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				Object[] ObjParametros = { null, null, null, null, null };
				System.Type typDB = (typeof(mdlDataBaseAccess.clsDataBaseAccess));
				System.Reflection.MethodInfo[] mtInfoTempArray = typDB.GetMethods();
				foreach(System.Reflection.MethodInfo mtInfo in mtInfoTempArray)
				{
					if (mtInfo.Name.StartsWith("GetTb"))
					{
						System.Data.DataSet dataSetClear = (System.Data.DataSet)mtInfo.Invoke(this, ObjParametros);
						for(int i = 0; i < dataSetClear.Tables.Count;i++)
						{
							System.Data.DataTable table = dataSetClear.Tables[i];
							for(int j = 0; j < table.Rows.Count;j++)
							{
								System.Data.DataRow row = table.Rows[j];
								row.Delete();
							}
						}
						this.SetDataSetMultiTableStructIn(dataSetClear);
					}
				}
				return(true);
			}
		#endregion

		#region Data Persist
			protected System.Data.DataSet vDataPersistGetData(string strTable,string strSelect)
			{
				System.Data.DataSet dtstReturn = null;
				if ((m_arlDataPersistSelect != null) && (m_arlDataPersistSelect.Contains(strSelect))){
					dtstReturn = ((System.Data.DataSet)m_arlDataPersistDataSets[m_arlDataPersistSelect.IndexOf(strSelect)]).Copy();
				}
				return(dtstReturn);
			}
        
			protected void vDataPersistSetData(string strTable,string strSelect,System.Data.DataSet dtstData)
			{
				if (m_arlDataPersistTables != null)
				{
					// Check if the table is in the Data Persist
					if (m_arlDataPersistTables.Contains(strTable))
					{
						// Removing the DataSet from DataPersist 
						int nIndex = m_arlDataPersistTables.IndexOf(strTable);
						m_arlDataPersistTables.RemoveAt(nIndex);
						m_arlDataPersistSelect.RemoveAt(nIndex);
						m_arlDataPersistDataSets.RemoveAt(nIndex);
					}
					// Inserting the DataSet int DataPersist
					m_arlDataPersistTables.Add(strTable);
					m_arlDataPersistSelect.Add(strSelect);
					m_arlDataPersistDataSets.Add(dtstData.Copy());
				}
			}
		#endregion

		#region Tabelas
			#region MultiTableBackup
				public void SetDataSetMultiTableStructIn(System.Data.DataSet dtstDataSetMultiTable)
				{
					foreach(System.Data.DataTable dttbTabela in dtstDataSetMultiTable.Tables)
					{
						SetCommandSelect(GetSQLSelect(dttbTabela)); 
						DataAdapterUpdate(dtstDataSetMultiTable,dttbTabela.TableName);
						if (m_excError != null)
						{
							vWriteInLogFile(System.Environment.NewLine + System.Environment.NewLine + dttbTabela.TableName);
							break;
						}
					} 
				}
			#endregion

			#region MultiTable
				public void SetDataSetMultiTable(System.Data.DataSet dtstDataSetMultiTable)
				{
					foreach(System.Data.DataTable dttbTabela in dtstDataSetMultiTable.Tables)
					{
						SetCommandSelect(GetSQLSelect(dttbTabela.TableName)); 
						DataAdapterUpdate(dtstDataSetMultiTable,dttbTabela.TableName);
						if (m_excError != null)
						{
							vWriteInLogFile(System.Environment.NewLine + System.Environment.NewLine + dttbTabela.TableName);
							break;
						}
					} 
				}
			#endregion

			#region tbAgentesCargas
				public mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas GetTbAgentesCargas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas tbAgentesCargas = new mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas();
					SetCommandSelect("tbAgentesCargas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbAgentesCargas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbAgentesCargas;
					DataAdapterFill(ref dtstTabela,"tbAgentesCargas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas)dtstTabela);
				}
				public void SetTbAgentesCargas(mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas tbAgentesCargas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbAgentesCargas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbAgentesCargas")); 
					DataAdapterUpdate((System.Data.DataSet)tbAgentesCargas,"tbAgentesCargas");
				}
			#endregion
			#region tbAgentesCargasContatos
				public mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos GetTbAgentesCargasContatos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos tbAgentesCargasContatos = new mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos();
					SetCommandSelect("tbAgentesCargasContatos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbAgentesCargasContatos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbAgentesCargasContatos;
					DataAdapterFill(ref dtstTabela,"tbAgentesCargasContatos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos)dtstTabela);
				}
				public void SetTbAgentesCargasContatos(mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos tbAgentesCargasContatos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbAgentesCargasContatos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbAgentesCargasContatos")); 
					DataAdapterUpdate((System.Data.DataSet)tbAgentesCargasContatos,"tbAgentesCargasContatos");
				}
			#endregion
			#region tbArmadores
				public mdlDataBaseAccess.Tabelas.XsdTbArmadores GetTbArmadores(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadores tbArmadores = new mdlDataBaseAccess.Tabelas.XsdTbArmadores();
					SetCommandSelect("tbArmadores",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbArmadores",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbArmadores;
					DataAdapterFill(ref dtstTabela,"tbArmadores");
					return ((mdlDataBaseAccess.Tabelas.XsdTbArmadores)dtstTabela);
				}
				public void SetTbArmadores(mdlDataBaseAccess.Tabelas.XsdTbArmadores tbArmadores)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbArmadores;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbArmadores")); 
					DataAdapterUpdate((System.Data.DataSet)tbArmadores,"tbArmadores");
				}
			#endregion
			#region tbArmadoresNavios
				public mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios GetTbArmadoresNavios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios tbArmadoresNavios = new mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios();
					SetCommandSelect("tbArmadoresNavios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbArmadoresNavios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbArmadoresNavios;
					DataAdapterFill(ref dtstTabela,"tbArmadoresNavios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios)dtstTabela);
				}
				public void SetTbArmadoresNavios(mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios tbArmadoresNavios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbArmadoresNavios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbArmadoresNavios")); 
					DataAdapterUpdate((System.Data.DataSet)tbArmadoresNavios,"tbArmadoresNavios");
				}
			#endregion

			#region tbAssinaturas
				public mdlDataBaseAccess.Tabelas.XsdTbAssinaturas GetTbAssinaturas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAssinaturas tbAssinaturas = new mdlDataBaseAccess.Tabelas.XsdTbAssinaturas();
					SetCommandSelect("tbAssinaturas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbAssinaturas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbAssinaturas;
					DataAdapterFill(ref dtstTabela,"tbAssinaturas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbAssinaturas)dtstTabela);
				}
				public void SetTbAssinaturas(mdlDataBaseAccess.Tabelas.XsdTbAssinaturas tbAssinaturas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbAssinaturas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbAssinaturas")); 
					DataAdapterUpdate((System.Data.DataSet)tbAssinaturas,"tbAssinaturas");
				}
			#endregion

			#region tbBorderos
				public mdlDataBaseAccess.Tabelas.XsdTbBorderos GetTbBorderos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos tbBorderos = new mdlDataBaseAccess.Tabelas.XsdTbBorderos();
					SetCommandSelect("tbBorderos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbBorderos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbBorderos;
					DataAdapterFill(ref dtstTabela,"tbBorderos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbBorderos)dtstTabela);
				}
				public void SetTbBorderos(mdlDataBaseAccess.Tabelas.XsdTbBorderos tbBorderos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbBorderos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbBorderos")); 
					DataAdapterUpdate((System.Data.DataSet)tbBorderos,"tbBorderos");
				}
			#endregion
			#region tbBorderosSecundarios
				public mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios GetTbBorderosSecundarios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios tbBorderosSecundarios = new mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios();
					SetCommandSelect("tbBorderosSecundarios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbBorderosSecundarios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbBorderosSecundarios;
					DataAdapterFill(ref dtstTabela,"tbBorderosSecundarios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios)dtstTabela);
				}
				public void SetTbBorderosSecundarios(mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios tbBorderosSecundarios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbBorderosSecundarios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbBorderosSecundarios")); 
					DataAdapterUpdate((System.Data.DataSet)tbBorderosSecundarios,"tbBorderosSecundarios");
				}
			#endregion

			#region tbCartasCredito
				public mdlDataBaseAccess.Tabelas.XsdTbCartasCredito GetTbCartasCredito(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCartasCredito tbCartasCredito = new mdlDataBaseAccess.Tabelas.XsdTbCartasCredito();
					SetCommandSelect("tbCartasCredito",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbCartasCredito",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbCartasCredito;
					DataAdapterFill(ref dtstTabela,"tbCartasCredito");
					return ((mdlDataBaseAccess.Tabelas.XsdTbCartasCredito)dtstTabela);
				}
				public void SetTbCartasCredito(mdlDataBaseAccess.Tabelas.XsdTbCartasCredito tbCartasCredito)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbCartasCredito;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbCartasCredito")); 
					DataAdapterUpdate((System.Data.DataSet)tbCartasCredito,"tbCartasCredito");
				}
			#endregion

			#region tbCertificadosOrigem
				public mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem GetTbCertificadosOrigem(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem tbCertificadosOrigem = new mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem();
					SetCommandSelect("tbCertificadosOrigem",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbCertificadosOrigem",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbCertificadosOrigem;
					DataAdapterFill(ref dtstTabela,"tbCertificadosOrigem");
					return ((mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem)dtstTabela);
				}
				public void SetTbCertificadosOrigem(mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem tbCertificadosOrigem)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbCertificadosOrigem;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbCertificadosOrigem")); 
					DataAdapterUpdate((System.Data.DataSet)tbCertificadosOrigem,"tbCertificadosOrigem");
				}
			#endregion
			#region tbCertificadosOrigemNormas
				public mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas GetTbCertificadosOrigemNormas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas tbCertificadosOrigemNormas = new mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbCertificadosOrigemNormas);
							break;
						case FonteDados.DataBase:
							SetCommandSelect("tbCertificadosOrigemNormas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbCertificadosOrigemNormas",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbCertificadosOrigemNormas;
							DataAdapterFill(ref dtstTabela,"tbCertificadosOrigemNormas");
							if (m_bWriteXml)
								tbCertificadosOrigemNormas.WriteXml("C:\\XmlTbCertificadosOrigemNormas.xml");
							break;
					}
					return (tbCertificadosOrigemNormas);
				}
				public void SetTbCertificadosOrigemNormas(mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas tbCertificadosOrigemNormas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbCertificadosOrigemNormas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbCertificadosOrigemNormas")); 
					DataAdapterUpdate((System.Data.DataSet)tbCertificadosOrigemNormas,"tbCertificadosOrigemNormas");
				}
			#endregion

			#region tbConfiguracoes
				#region Get
					public mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes GetTbConfiguracoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
					{
						mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes tbConfiguracoes = new mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes();
						SetCommandSelect("tbConfiguracoes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
						SetSQLSelect("tbConfiguracoes",strReturnCommandSelect());
						System.Data.DataSet dtstTabela = (System.Data.DataSet)tbConfiguracoes;
						DataAdapterFill(ref dtstTabela,"tbConfiguracoes");
						return ((mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes)dtstTabela);
					}

					private mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes GetTbConfiguracoes(string strCampo)
					{
						mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes tbConfiguracoes = new mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes();
						SetCommandSelect("SELECT * FROM tbConfiguracoes WHERE (strVariavel = '" + strCampo + "' )");
						SetSQLSelect("tbConfiguracoes",strReturnCommandSelect());
						System.Data.DataSet dtstTabela = (System.Data.DataSet)tbConfiguracoes;
						DataAdapterFill(ref dtstTabela,"tbConfiguracoes");
						return((mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes)dtstTabela);
					}

					public string GetConfiguracao(string strVariavel,string strValorDefault)
					{
						string strRetorno = strValorDefault;
						strVariavel = strVariavel.Trim().ToUpper();
						if (strVariavel != "")
						{
							if (m_typDatSetTbConfiguracoes == null) // DataBase
							{
								Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
								if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
								{
									strRetorno = typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"].ToString();	
								}
							}
							else
							{ // Memory
								System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
								if (dtrwCollection.Length > 0)
								{
									strRetorno = dtrwCollection[0]["mstrValor"].ToString();	
								}
							}
						}
						return(strRetorno);
					}

					public int GetConfiguracao(string strVariavel,int nValorDefault)
					{
						strVariavel = strVariavel.Trim().ToUpper();
						string strRetorno = "";
						int nRetorno = nValorDefault;
						if (m_typDatSetTbConfiguracoes == null) // DataBase
						{
							Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
							if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
							{
								strRetorno = typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"].ToString();	
								try
								{
									nRetorno = Int32.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}else{ // Memory
							System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
							if (dtrwCollection.Length > 0)
							{
								strRetorno = dtrwCollection[0]["mstrValor"].ToString();	
								try
								{
									nRetorno = Int32.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}
						return(nRetorno);
					}

					public double GetConfiguracao(string strVariavel,double dValorDefault)
					{
						strVariavel = strVariavel.Trim().ToUpper();
						string strRetorno = "";
						double dRetorno = dValorDefault;
						if (m_typDatSetTbConfiguracoes == null) // DataBase
						{
							Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
							if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
							{
								strRetorno = typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"].ToString();	
								try
								{
									dRetorno = double.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}
						else
						{ // Memory
							System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
							if (dtrwCollection.Length > 0)
							{
								strRetorno = dtrwCollection[0]["mstrValor"].ToString();	
								try
								{
									dRetorno = double.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}
						return(dRetorno);
					}

					public bool GetConfiguracao(string strVariavel,bool bValorDefault)
					{
						strVariavel = strVariavel.Trim().ToUpper();
						bool bRetorno = bValorDefault;
						string strRetorno = "";
						if (m_typDatSetTbConfiguracoes == null) // DataBase
						{
							Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
							if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
							{
								strRetorno = typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"].ToString();	
								try
								{
									bRetorno = bool.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}else{
							System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
							if (dtrwCollection.Length > 0)
							{
								strRetorno = dtrwCollection[0]["mstrValor"].ToString();	
								try
								{
									bRetorno = bool.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}
						return(bRetorno);
					}

					public System.DateTime GetConfiguracao(string strVariavel,System.DateTime dtValorDefault)
					{
						strVariavel = strVariavel.Trim().ToUpper();
						System.DateTime dtRetorno = dtValorDefault;
						string strRetorno = "";
						if (m_typDatSetTbConfiguracoes == null) // DataBase
						{
							Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
							if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
							{
								strRetorno = typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"].ToString();	
								try
								{
									dtRetorno = System.DateTime.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}else{ // Memory 
							System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
							if (dtrwCollection.Length > 0)
							{
								strRetorno = dtrwCollection[0]["mstrValor"].ToString();	
								try
								{
									dtRetorno = System.DateTime.Parse(strRetorno);
								}
								catch
								{
								}
							}
						}
						return(dtRetorno);
					}
				#endregion
				#region Set
					public void SetTbConfiguracoes(mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes tbConfiguracoes)
					{
						System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbConfiguracoes;
						CheckIntegrityDataSet(ref dtstGeneric);
						SetCommandSelect(GetSQLSelect("tbConfiguracoes")); 
						DataAdapterUpdate((System.Data.DataSet)tbConfiguracoes,"tbConfiguracoes");
					}

					public void SetConfiguracao(string strVariavel,string strValor)
					{
						strVariavel = strVariavel.Trim().ToUpper();
						System.Data.DataRow dtrwConfiguracao;
						if (m_typDatSetTbConfiguracoes == null) // DataBase
						{
							Tabelas.XsdTbConfiguracoes typDatSetTbConfiguracoes = this.GetTbConfiguracoes(strVariavel);
							if (typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Count > 0)
							{
								typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["strVariavel"] = strVariavel;
								typDatSetTbConfiguracoes.tbConfiguracoes.Rows[0]["mstrValor"] = strValor;
							}
							else
							{
								dtrwConfiguracao = typDatSetTbConfiguracoes.tbConfiguracoes.NewRow();
								dtrwConfiguracao["strVariavel"] = strVariavel;
								dtrwConfiguracao["mstrValor"] = strValor;
								typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Add(dtrwConfiguracao);
							}
							this.SetTbConfiguracoes(typDatSetTbConfiguracoes);
						}else{ // Memory 
							System.Data.DataRow[] dtrwCollection = m_typDatSetTbConfiguracoes.tbConfiguracoes.Select("strVariavel = \'" + strVariavel + "\'");
							if (dtrwCollection.Length == 0) // Add
							{
								dtrwConfiguracao = m_typDatSetTbConfiguracoes.tbConfiguracoes.NewRow();
								dtrwConfiguracao["strVariavel"] = strVariavel;
								dtrwConfiguracao["mstrValor"] = strValor;
								m_typDatSetTbConfiguracoes.tbConfiguracoes.Rows.Add(dtrwConfiguracao);
							}
							else
							{ // Update 
								dtrwCollection[0]["mstrValor"] = strValor;	
							}
						}
					}
				#endregion
			#endregion
			
			#region tbContratosCambio
				public mdlDataBaseAccess.Tabelas.XsdTbContratosCambio GetTbContratosCambio(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbContratosCambio tbContratosCambio = new mdlDataBaseAccess.Tabelas.XsdTbContratosCambio();
					SetCommandSelect("tbContratosCambio",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbContratosCambio",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbContratosCambio;
					DataAdapterFill(ref dtstTabela,"tbContratosCambio");
					return ((mdlDataBaseAccess.Tabelas.XsdTbContratosCambio)dtstTabela);
				}
				public void SetTbContratosCambio(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio tbContratosCambio)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbContratosCambio;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbContratosCambio")); 
					DataAdapterUpdate((System.Data.DataSet)tbContratosCambio,"tbContratosCambio");
				}
			#endregion

			#region tbDespachantes 
				public mdlDataBaseAccess.Tabelas.XsdTbDespachantes GetTbDespachantes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantes tbDespachantes = new mdlDataBaseAccess.Tabelas.XsdTbDespachantes();
					SetCommandSelect("tbDespachantes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbDespachantes",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbDespachantes;
					DataAdapterFill(ref dtstTabela,"tbDespachantes");
					return ((mdlDataBaseAccess.Tabelas.XsdTbDespachantes)dtstTabela);
				}
				public void SetTbDespachantes(mdlDataBaseAccess.Tabelas.XsdTbDespachantes tbDespachantes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbDespachantes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbDespachantes")); 
					DataAdapterUpdate((System.Data.DataSet)tbDespachantes,"tbDespachantes");
				}
			#endregion
			#region tbDespachantesContatos
				public mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos GetTbDespachantesContatos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos tbDespachantesContatos = new mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos();
					SetCommandSelect("tbDespachantesContatos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbDespachantesContatos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbDespachantesContatos;
					DataAdapterFill(ref dtstTabela,"tbDespachantesContatos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos)dtstTabela);
				}
				public void SetTbDespachantesContatos(mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos tbDespachantesContatos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbDespachantesContatos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbDespachantesContatos")); 
					DataAdapterUpdate((System.Data.DataSet)tbDespachantesContatos,"tbDespachantesContatos");
				}
			#endregion

			#region tbDSEs
				public mdlDataBaseAccess.Tabelas.XsdTbDSEs GetTbDSEs(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEs tbDSEs = new mdlDataBaseAccess.Tabelas.XsdTbDSEs();
					SetCommandSelect("tbDSEs",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbDSEs",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbDSEs;
					DataAdapterFill(ref dtstTabela,"tbDSEs");
					return ((mdlDataBaseAccess.Tabelas.XsdTbDSEs)dtstTabela);
				}
				public void SetTbDSEs(mdlDataBaseAccess.Tabelas.XsdTbDSEs tbDSEs)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbDSEs;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbDSEs")); 
					DataAdapterUpdate((System.Data.DataSet)tbDSEs,"tbDSEs");
				}
			#endregion
			#region tbDSEsPEs
				public mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs GetTbDSEsPEs(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs tbDSEsPEs = new mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs();
					SetCommandSelect("tbDSEsPES",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbDSEsPEs",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbDSEsPEs;
					DataAdapterFill(ref dtstTabela,"tbDSEsPEs");
					return ((mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs)dtstTabela);
				}
				public void SetTbDSEsPEs(mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs tbDSEsPEs)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbDSEsPEs;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbDSEsPEs")); 
					DataAdapterUpdate((System.Data.DataSet)tbDSEsPEs,"tbDSEsPEs");
				}
			#endregion

			#region tbEstadosBrasileiros
				public mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros GetTbEstadosBrasileiros(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros tbEstadosBrasileiros = new mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbEstadosBrasileiros);
							break;
					}
					return (tbEstadosBrasileiros);
				}
				public void SetTbEstadosBrasileiros(mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros tbEstadosBrasileiros)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbEstadosBrasileiros;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbEstadosBrasileiros")); 
					DataAdapterUpdate((System.Data.DataSet)tbEstadosBrasileiros,"tbEstadosBrasileiros");
				}
			#endregion 

			#region tbErros
				public mdlDataBaseAccess.Tabelas.XsdTbErros GetTbErros(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbErros tbErros = new mdlDataBaseAccess.Tabelas.XsdTbErros();
					SetCommandSelect("tbErros",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbErros",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbErros;
					DataAdapterFill(ref dtstTabela,"tbErros");
					return ((mdlDataBaseAccess.Tabelas.XsdTbErros)dtstTabela);
				}
				public void SetTbErros(mdlDataBaseAccess.Tabelas.XsdTbErros tbErros)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbErros;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbErros")); 
					DataAdapterUpdate((System.Data.DataSet)tbErros,"tbErros");
				}
			#endregion

			#region tbExportadores
				public mdlDataBaseAccess.Tabelas.XsdTbExportadores GetTbExportadores(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadores tbExportadores = new mdlDataBaseAccess.Tabelas.XsdTbExportadores();
					SetCommandSelect("tbExportadores",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbExportadores",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadores;
					DataAdapterFill(ref dtstTabela,"tbExportadores");
					return ((mdlDataBaseAccess.Tabelas.XsdTbExportadores)dtstTabela);
				}
				public void SetTbExportadores(mdlDataBaseAccess.Tabelas.XsdTbExportadores tbExportadores)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadores;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbExportadores")); 
					DataAdapterUpdate((System.Data.DataSet)tbExportadores,"tbExportadores");
				}
			#endregion
			#region tbExportadoresAgentesVendas
				public mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas GetTbExportadoresAgentesVendas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas tbExportadoresAgentesVendas = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas();
					SetCommandSelect("tbExportadoresAgentesVendas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbExportadoresAgentesVendas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresAgentesVendas;
					DataAdapterFill(ref dtstTabela,"tbExportadoresAgentesVendas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas)dtstTabela);
				}
				public void SetTbExportadoresAgentesVendas(mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas tbExportadoresAgentesVendas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresAgentesVendas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbExportadoresAgentesVendas")); 
					DataAdapterUpdate((System.Data.DataSet)tbExportadoresAgentesVendas,"tbExportadoresAgentesVendas");
				}
			#endregion
			#region tbExportadoresAgentesVendasBancos
				public mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos GetTbExportadoresAgentesVendasBancos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos tbExportadoresAgentesVendasBancos = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos();
					SetCommandSelect("tbExportadoresAgentesVendasBancos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbExportadoresAgentesVendasBancos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresAgentesVendasBancos;
					DataAdapterFill(ref dtstTabela,"tbExportadoresAgentesVendasBancos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos)dtstTabela);
				}
				public void SetTbExportadoresAgentesVendasBancos(mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos tbExportadoresAgentesVendasBancos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresAgentesVendasBancos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbExportadoresAgentesVendasBancos")); 
					DataAdapterUpdate((System.Data.DataSet)tbExportadoresAgentesVendasBancos,"tbExportadoresAgentesVendasBancos");
				}
			#endregion
			#region tbExportadoresBancos
		public mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos GetTbExportadoresBancos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos tbExportadoresBancos = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos();
			SetCommandSelect("tbExportadoresBancos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbExportadoresBancos",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresBancos;
			DataAdapterFill(ref dtstTabela,"tbExportadoresBancos");
			return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos)dtstTabela);
		}
		public void SetTbExportadoresBancos(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos tbExportadoresBancos)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresBancos;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbExportadoresBancos")); 
			DataAdapterUpdate((System.Data.DataSet)tbExportadoresBancos,"tbExportadoresBancos");
		}
			#endregion
			#region tbExportadoresBancosAgencias
		public mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias GetTbExportadoresBancosAgencias(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias tbExportadoresBancosAgencias = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias();
			SetCommandSelect("tbExportadoresBancosAgencias",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbExportadoresBancosAgencias",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresBancosAgencias;
			DataAdapterFill(ref dtstTabela,"tbExportadoresBancosAgencias");
			return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias)dtstTabela);
		}
		public void SetTbExportadoresBancosAgencias(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias tbExportadoresBancosAgencias)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresBancosAgencias;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbExportadoresBancosAgencias")); 
			DataAdapterUpdate((System.Data.DataSet)tbExportadoresBancosAgencias,"tbExportadoresBancosAgencias");
		}
			#endregion
			#region tbExportadoresBancosAgenciasContas
		public mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas GetTbExportadoresBancosAgenciasContas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas tbExportadoresBancosAgenciasContas = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas();
			SetCommandSelect("tbExportadoresBancosAgenciasContas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbExportadoresBancosAgenciasContas",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresBancosAgenciasContas;
			DataAdapterFill(ref dtstTabela,"tbExportadoresBancosAgenciasContas");
			return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas)dtstTabela);
		}
		public void SetTbExportadoresBancosAgenciasContas(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas tbExportadoresBancosAgenciasContas)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresBancosAgenciasContas;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbExportadoresBancosAgenciasContas")); 
			DataAdapterUpdate((System.Data.DataSet)tbExportadoresBancosAgenciasContas,"tbExportadoresBancosAgenciasContas");
		}
			#endregion
			#region tbExportadoresColunas
				public mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas GetTbExportadoresColunas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas tbExportadoresColunas = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas();
					SetCommandSelect("tbExportadoresColunas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbExportadoresColunas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresColunas;
					DataAdapterFill(ref dtstTabela,"tbExportadoresColunas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas)dtstTabela);
				}
				public void SetTbExportadoresColunas(mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas tbExportadoresColunas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresColunas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbExportadoresColunas")); 
					DataAdapterUpdate((System.Data.DataSet)tbExportadoresColunas,"tbExportadoresColunas");
				}
			#endregion
			#region tbExportadoresVolumes
		public mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes GetTbExportadoresVolumes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes tbExportadoresVolumes = new mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes();
			SetCommandSelect("tbExportadoresVolumes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbExportadoresVolumes",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbExportadoresVolumes;
			DataAdapterFill(ref dtstTabela,"tbExportadoresVolumes");
			return ((mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes)dtstTabela);
		}
		public void SetTbExportadoresVolumes(mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes tbExportadoresVolumes)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbExportadoresVolumes;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbExportadoresVolumes")); 
			DataAdapterUpdate((System.Data.DataSet)tbExportadoresVolumes,"tbExportadoresVolumes");
		}
			#endregion

			#region tbFaturasComerciais
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais GetTbFaturasComerciais(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais tbFaturasComerciais = new mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais();
					SetCommandSelect("tbFaturasComerciais",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasComerciais",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasComerciais;
					DataAdapterFill(ref dtstTabela,"tbFaturasComerciais");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais)dtstTabela);
				}

				public void SetTbFaturasComerciais(mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais tbFaturasComerciais)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasComerciais;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasComerciais")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasComerciais,"tbFaturasComerciais");
				}
			#endregion
			#region tbFaturasComerciaisColunas
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas GetTbFaturasComerciaisColunas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas tbFaturasComerciaisColunas = new mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas();
					SetCommandSelect("tbFaturasComerciaisColunas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasComerciaisColunas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasComerciaisColunas;
					DataAdapterFill(ref dtstTabela,"tbFaturasComerciaisColunas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas)dtstTabela);
				}

				public void SetTbFaturasComerciaisColunas(mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas tbFaturasComerciaisColunas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasComerciaisColunas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasComerciaisColunas")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasComerciaisColunas,"tbFaturasComerciaisColunas");
				}
			#endregion
			#region tbFaturasCotacoes
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes GetTbFaturasCotacoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes tbFaturasCotacoes = new mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes();
					SetCommandSelect("tbFaturasCotacoes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasCotacoes",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasCotacoes;
					DataAdapterFill(ref dtstTabela,"tbFaturasCotacoes");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes)dtstTabela);
				}
				public void SetTbFaturasCotacoes(mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes tbFaturasCotacoes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasCotacoes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasCotacoes")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasCotacoes,"tbFaturasCotacoes");
				}
			#endregion
			#region tbFaturasCotacoesColunas
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas GetTbFaturasCotacoesColunas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas tbFaturasCotacoesColunas = new mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas();
					SetCommandSelect("tbFaturasCotacoesColunas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasCotacoesColunasColunas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasCotacoesColunas;
					DataAdapterFill(ref dtstTabela,"tbFaturasCotacoesColunas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas)dtstTabela);
				}
				public void SetTbFaturasCotacoesColunas(mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas tbFaturasCotacoesColunas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasCotacoesColunas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasCotacoesColunas")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasCotacoesColunas,"tbFaturasCotacoesColunas");
				}
			#endregion
			#region tbFaturasProformas
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas GetTbFaturasProformas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas tbFaturasProformas = new mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas();
					SetCommandSelect("tbFaturasProformas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasProformas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasProformas;
					DataAdapterFill(ref dtstTabela,"tbFaturasProformas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas)dtstTabela);
				}

				public void SetTbFaturasProformas(mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas tbFaturasProformas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasProformas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasProformas")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasProformas,"tbFaturasProformas");
				}
			#endregion
			#region tbFaturasProformasColunas
				public mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas GetTbFaturasProformasColunas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas tbFaturasProformasColunas = new mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas();
					SetCommandSelect("tbFaturasProformasColunas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbFaturasProformasColunas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbFaturasProformasColunas;
					DataAdapterFill(ref dtstTabela,"tbFaturasProformasColunas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas)dtstTabela);
				}

				public void SetTbFaturasProformasColunas(mdlDataBaseAccess.Tabelas.XsdTbFaturasProformasColunas tbFaturasProformasColunas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbFaturasProformasColunas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbFaturasProformasColunas")); 
					DataAdapterUpdate((System.Data.DataSet)tbFaturasProformasColunas,"tbFaturasProformasColunas");
				}
			#endregion

			#region tbGuiasEntrada
				public mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada GetTbGuiasEntrada(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada tbGuiasEntrada = new mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada();
					SetCommandSelect("tbGuiasEntrada",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbGuiasEntrada",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbGuiasEntrada;
					DataAdapterFill(ref dtstTabela,"tbGuiasEntrada");
					return ((mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada)dtstTabela);
				}

				public void SetTbGuiasEntrada(mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada tbGuiasEntrada)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbGuiasEntrada;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbGuiasEntrada")); 
					DataAdapterUpdate((System.Data.DataSet)tbGuiasEntrada,"tbGuiasEntrada");
				}
			#endregion

			#region tbIdiomas
				public mdlDataBaseAccess.Tabelas.XsdTbIdiomas GetTbIdiomas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas tbIdiomas = new mdlDataBaseAccess.Tabelas.XsdTbIdiomas();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbIdiomas);
							break;
						case FonteDados.DataBase:
//							SetCommandSelect("tbIdiomas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
//							SetSQLSelect("tbIdiomas",strReturnCommandSelect());
//							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbIdiomas;
//							DataAdapterFill(ref dtstTabela,"tbIdiomas");
//							if (m_bWriteXml)
//								tbIdiomas.WriteXml("C:\\XmlTbIdiomas.xml");
							break;
					}
					return (tbIdiomas);
				}	

				public void SetTbIdiomas(mdlDataBaseAccess.Tabelas.XsdTbIdiomas tbIdiomas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbIdiomas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbIdiomas")); 
					DataAdapterUpdate((System.Data.DataSet)tbIdiomas,"tbIdiomas");
				}
			#endregion
			#region tbIdiomasTextos
				public mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos GetTbIdiomasTextos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos tbIdiomasTextos = new mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbIdiomasTextos);
							break;
						case FonteDados.DataBase:
//							SetCommandSelect("tbIdiomasTextos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
//							SetSQLSelect("tbIdiomasTextos",strReturnCommandSelect());
//							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbIdiomasTextos;
//							DataAdapterFill(ref dtstTabela,"tbIdiomasTextos");
//							if (m_bWriteXml)
//								tbIdiomasTextos.WriteXml("C:\\XmlTbIdiomasTextos.xml");
							break;
					}
					return (tbIdiomasTextos);
				}

				public void SetTbIdiomasTextos(mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos tbIdiomasTextos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbIdiomasTextos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbIdiomasTextos")); 
					DataAdapterUpdate((System.Data.DataSet)tbIdiomasTextos,"tbIdiomasTextos");
				}
			#endregion

			#region tbImagens
				public mdlDataBaseAccess.Tabelas.XsdTbImagens GetTbImagens(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbImagens tbImagens = new mdlDataBaseAccess.Tabelas.XsdTbImagens();
					SetCommandSelect("tbImagens",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbImagens",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbImagens;
					DataAdapterFill(ref dtstTabela,"tbImagens");
					return ((mdlDataBaseAccess.Tabelas.XsdTbImagens)dtstTabela);
				}

				public void SetTbImagens(mdlDataBaseAccess.Tabelas.XsdTbImagens tbImagens)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbImagens;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbImagens")); 
					DataAdapterUpdate((System.Data.DataSet)tbImagens,"tbImagens");
				}
			#endregion

			#region tbImportadores
		public mdlDataBaseAccess.Tabelas.XsdTbImportadores GetTbImportadores(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadores tbImportadores = new mdlDataBaseAccess.Tabelas.XsdTbImportadores();
			SetCommandSelect("tbImportadores",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbImportadores",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbImportadores;
			DataAdapterFill(ref dtstTabela,"tbImportadores");
			return ((mdlDataBaseAccess.Tabelas.XsdTbImportadores)dtstTabela);
		}

		public void SetTbImportadores(mdlDataBaseAccess.Tabelas.XsdTbImportadores tbImportadores)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbImportadores;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbImportadores")); 
			DataAdapterUpdate((System.Data.DataSet)tbImportadores,"tbImportadores");
		}
			#endregion
			#region tbImportadoresBancos
		public mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos GetTbImportadoresBancos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos tbImportadoresBancos = new mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos();
			SetCommandSelect("tbImportadoresBancos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbImportadoresBancos",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbImportadoresBancos;
			DataAdapterFill(ref dtstTabela,"tbImportadoresBancos");
			return ((mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos)dtstTabela);
		}
		public void SetTbImportadoresBancos(mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos tbImportadoresBancos)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbImportadoresBancos;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbImportadoresBancos")); 
			DataAdapterUpdate((System.Data.DataSet)tbImportadoresBancos,"tbImportadoresBancos");
		}
			#endregion
			#region tbImportadoresConsignatarios
		public mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios GetTbImportadoresConsignatarios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios tbImportadoresConsignatarios = new mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios();
			SetCommandSelect("tbImportadoresConsignatarios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbImportadoresConsignatarios",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbImportadoresConsignatarios;
			DataAdapterFill(ref dtstTabela,"tbImportadoresConsignatarios");
			return ((mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios)dtstTabela);
		}

		public void SetTbImportadoresConsignatarios(mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios tbImportadoresConsignatarios)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbImportadoresConsignatarios;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbImportadoresConsignatarios")); 
			DataAdapterUpdate((System.Data.DataSet)tbImportadoresConsignatarios,"tbImportadoresConsignatarios");
		}
			#endregion
			#region tbImportadoresEndEntrega
		public mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega GetTbImportadoresEndEntrega(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega tbImportadoresEndEntrega = new mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega();
			SetCommandSelect("tbImportadoresEndEntrega",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbImportadoresEndEntrega",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbImportadoresEndEntrega;
			DataAdapterFill(ref dtstTabela,"tbImportadoresEndEntrega");
			return ((mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega)dtstTabela);
		}

		public void SetTbImportadoresEndEntrega(mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega tbImportadoresEndEntrega)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbImportadoresEndEntrega;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbImportadoresEndEntrega")); 
			DataAdapterUpdate((System.Data.DataSet)tbImportadoresEndEntrega,"tbImportadoresEndEntrega");
		}
			#endregion]

			#region	tbInstrucoesEmbarque
				public mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque GetTbInstrucoesEmbarque(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque tbInstrucoesEmbarque = new mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque();
					SetCommandSelect("tbInstrucoesEmbarque",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbInstrucoesEmbarque",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbInstrucoesEmbarque;
					DataAdapterFill(ref dtstTabela,"tbInstrucoesEmbarque");
					return ((mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque)dtstTabela);
				}
				public void SetTbInstrucoesEmbarque(mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque tbInstrucoesEmbarque)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbInstrucoesEmbarque;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbInstrucoesEmbarque")); 
					DataAdapterUpdate((System.Data.DataSet)tbInstrucoesEmbarque,"tbInstrucoesEmbarque");
				}
			#endregion

			#region tbLogMedicaoTempos
				public mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo GetTbLogMedicaoTempo(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo tbLogMedicaoTempo = new mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo();
					SetCommandSelect("tbLogMedicaoTempo",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbLogMedicaoTempo",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbLogMedicaoTempo;
					DataAdapterFill(ref dtstTabela,"tbLogMedicaoTempo");
					return ((mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo)dtstTabela);
				}

				public void SetTbLogMedicaoTempo(mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo tbLogMedicaoTempo)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbLogMedicaoTempo;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbLogMedicaoTempo")); 
					DataAdapterUpdate((System.Data.DataSet)tbLogMedicaoTempo,"tbLogMedicaoTempo");
				}
			#endregion

			#region tbMaquinas
				public mdlDataBaseAccess.Tabelas.XsdTbMaquinas GetTbMaquinas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbMaquinas tbMaquinas = new mdlDataBaseAccess.Tabelas.XsdTbMaquinas();
					SetCommandSelect("tbMaquinas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbMaquinas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbMaquinas;
					DataAdapterFill(ref dtstTabela,"tbMaquinas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbMaquinas)dtstTabela);
				}

				public void SetTbMaquinas(mdlDataBaseAccess.Tabelas.XsdTbMaquinas tbMaquinas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbMaquinas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbMaquinas")); 
					DataAdapterUpdate((System.Data.DataSet)tbMaquinas,"tbMaquinas");
				}
			#endregion

			#region tbMensagens
				public mdlDataBaseAccess.Tabelas.XsdTbMensagens GetTbMensagens(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbMensagens tbMensagens = new mdlDataBaseAccess.Tabelas.XsdTbMensagens();
					SetCommandSelect("tbMensagens",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbMensagens",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbMensagens;
					DataAdapterFill(ref dtstTabela,"tbMensagens");
					return ((mdlDataBaseAccess.Tabelas.XsdTbMensagens)dtstTabela);
				}

				public void SetTbMensagens(mdlDataBaseAccess.Tabelas.XsdTbMensagens tbMensagens)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbMensagens;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbMensagens")); 
					DataAdapterUpdate((System.Data.DataSet)tbMensagens,"tbMensagens");
				}
			#endregion

			#region tbModulos
				public mdlDataBaseAccess.Tabelas.XsdTbModulos GetTbModulos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbModulos tbModulos = new mdlDataBaseAccess.Tabelas.XsdTbModulos();
					SetCommandSelect("tbModulos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbModulos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbModulos;
					DataAdapterFill(ref dtstTabela,"tbModulos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbModulos)dtstTabela);
				}

				public void SetTbModulos(mdlDataBaseAccess.Tabelas.XsdTbModulos tbModulos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbModulos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbModulos")); 
					DataAdapterUpdate((System.Data.DataSet)tbModulos,"tbModulos");
				}
			#endregion

			#region tbMoedas
				public mdlDataBaseAccess.Tabelas.XsdTbMoedas GetTbMoedas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbMoedas tbMoedas = new mdlDataBaseAccess.Tabelas.XsdTbMoedas();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbMoedas);
							break;
					}
					return (tbMoedas);
				}

				public void SetTbMoedas(mdlDataBaseAccess.Tabelas.XsdTbMoedas tbMoedas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbMoedas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbMoedas")); 
					DataAdapterUpdate((System.Data.DataSet)tbMoedas,"tbMoedas");
				}
			#endregion

			#region tbNotasFiscais
				public mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais GetTbNotasFiscais(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais tbNotasFiscais = new mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais();
					SetCommandSelect("tbNotasFiscais",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbNotasFiscais",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbNotasFiscais;
					DataAdapterFill(ref dtstTabela,"tbNotasFiscais");
					return ((mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais)dtstTabela);
				}

				public void SetTbNotasFiscais(mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais tbNotasFiscais)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbNotasFiscais;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbNotasFiscais")); 
					DataAdapterUpdate((System.Data.DataSet)tbNotasFiscais,"tbNotasFiscais");
				}
			#endregion

			#region tbPaises
				public mdlDataBaseAccess.Tabelas.XsdTbPaises GetTbPaises(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPaises tbPaises = new mdlDataBaseAccess.Tabelas.XsdTbPaises();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbPaises);
							break;
					}
					return (tbPaises);
				}

				public void SetTbPaises(mdlDataBaseAccess.Tabelas.XsdTbPaises tbPaises)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbPaises;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbPaises")); 
					DataAdapterUpdate((System.Data.DataSet)tbPaises,"tbPaises");
				}
			#endregion
			#region tbPaisesIdiomas
				public mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas GetTbPaisesIdiomas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas tbPaisesIdiomas = new mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas();
					SetCommandSelect("tbPaisesIdiomas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbPaisesIdiomas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbPaisesIdiomas;
					DataAdapterFill(ref dtstTabela,"tbPaisesIdiomas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas)dtstTabela);
				}

				public void SetTbPaisesIdiomas(mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas tbPaisesIdiomas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbPaisesIdiomas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbPaisesIdiomas")); 
					DataAdapterUpdate((System.Data.DataSet)tbPaisesIdiomas,"tbPaisesIdiomas");
				}
			#endregion

			#region tbPes
				public mdlDataBaseAccess.Tabelas.XsdTbPes GetTbPes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes tbPes = new mdlDataBaseAccess.Tabelas.XsdTbPes();
					SetCommandSelect("tbPes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbPes",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbPes;
					DataAdapterFill(ref dtstTabela,"tbPes");
					return ((mdlDataBaseAccess.Tabelas.XsdTbPes)dtstTabela);
				}

				public void SetTbPes(mdlDataBaseAccess.Tabelas.XsdTbPes tbPes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbPes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbPes")); 
					DataAdapterUpdate((System.Data.DataSet)tbPes,"tbPes");
				}
			#endregion

			#region tbProcessosContainers
				public mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers GetTbProcessosContainers(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers tbProcessosContainers = new mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers();
					SetCommandSelect("tbProcessosContainers",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProcessosContainers",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProcessosContainers;
					DataAdapterFill(ref dtstTabela,"tbProcessosContainers");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers)dtstTabela);
				}

				public void SetTbProcessosContainers(mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers tbProcessosContainers)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProcessosContainers;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProcessosContainers")); 
					DataAdapterUpdate((System.Data.DataSet)tbProcessosContainers,"tbProcessosContainers");
				}
			#endregion
			
			#region tbProdutos
				public mdlDataBaseAccess.Tabelas.XsdTbProdutos GetTbProdutos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos tbProdutos = new mdlDataBaseAccess.Tabelas.XsdTbProdutos();
					SetCommandSelect("tbProdutos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutos;
					DataAdapterFill(ref dtstTabela,"tbProdutos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutos)dtstTabela);
				}

				public void SetTbProdutos(mdlDataBaseAccess.Tabelas.XsdTbProdutos tbProdutos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutos")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutos,"tbProdutos");
				}
			#endregion
			#region tbProdutosBordero
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero GetTbProdutosBordero(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero tbProdutosBordero = new mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero();
					SetCommandSelect("tbProdutosBordero",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosBordero",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosBordero;
					DataAdapterFill(ref dtstTabela,"tbProdutosBordero");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero)tbProdutosBordero);
				}

				public void SetTbProdutosBordero(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero tbProdutosBordero)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosBordero;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosBordero")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosBordero,"tbProdutosBordero");
				}
			#endregion
			#region tbProdutosCategorias
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias GetTbProdutosCategorias(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias tbProdutosCategorias = new mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias();
					SetCommandSelect("tbProdutosCategorias",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosCategorias",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosCategorias;
					DataAdapterFill(ref dtstTabela,"tbProdutosCategorias");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias)dtstTabela);
				}

				public void SetTbProdutosCategorias(mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias tbProdutosCategorias)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosCategorias;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosCategorias")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosCategorias,"tbProdutosCategorias");
				}
			#endregion
			#region tbProdutosCertificadoOrigem
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem GetTbProdutosCertificadoOrigem(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem tbProdutosCertificadoOrigem = new mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem();
					SetCommandSelect("tbProdutosCertificadoOrigem",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosCertificadoOrigem",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosCertificadoOrigem;
					DataAdapterFill(ref dtstTabela,"tbProdutosCertificadoOrigem");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem)dtstTabela);
				}

				public void SetTbProdutosCertificadoOrigem(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem tbProdutosCertificadoOrigem)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosCertificadoOrigem;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosCertificadoOrigem")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosCertificadoOrigem,"tbProdutosCertificadoOrigem");
				}
			#endregion
			#region tbProdutosCertificadoOrigemFormA
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA GetTbProdutosCertificadoOrigemFormA(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA tbProdutosCertificadoOrigemFormA = new mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA();
					SetCommandSelect("tbProdutosCertificadoOrigemFormA",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosCertificadoOrigemFormA",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosCertificadoOrigemFormA;
					DataAdapterFill(ref dtstTabela,"tbProdutosCertificadoOrigemFormA");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA)dtstTabela);
				}

				public void SetTbProdutosCertificadoOrigemFormA(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA tbProdutosCertificadoOrigemFormA)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosCertificadoOrigemFormA;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosCertificadoOrigemFormA")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosCertificadoOrigemFormA,"tbProdutosCertificadoOrigemFormA");
				}
			#endregion
			#region tbProdutosCertificadoOrigemFormARE
			public mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE GetTbProdutosCertificadoOrigemFormARE(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE tbProdutosCertificadoOrigemFormARE = new mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE();
				SetCommandSelect("tbProdutosCertificadoOrigemFormARE",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				SetSQLSelect("tbProdutosCertificadoOrigemFormARE",strReturnCommandSelect());
				System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosCertificadoOrigemFormARE;
				DataAdapterFill(ref dtstTabela,"tbProdutosCertificadoOrigemFormARE");
				return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE)dtstTabela);
			}

			public void SetTbProdutosCertificadoOrigemFormARE(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE tbProdutosCertificadoOrigemFormARE)
			{
				System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosCertificadoOrigemFormARE;
				CheckIntegrityDataSet(ref dtstGeneric);
				SetCommandSelect(GetSQLSelect("tbProdutosCertificadoOrigemFormARE")); 
				DataAdapterUpdate((System.Data.DataSet)tbProdutosCertificadoOrigemFormARE,"tbProdutosCertificadoOrigemFormARE");
			}
			#endregion
			#region tbProdutosFaturaComercial
		public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial GetTbProdutosFaturaComercial(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial tbProdutosFaturaComercial = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial();
			SetCommandSelect("tbProdutosFaturaComercial",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbProdutosFaturaComercial",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaComercial;
			DataAdapterFill(ref dtstTabela,"tbProdutosFaturaComercial");
			return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial)dtstTabela);

		}

		public void SetTbProdutosFaturaComercial(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial tbProdutosFaturaComercial)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaComercial;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbProdutosFaturaComercial")); 
			DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaComercial,"tbProdutosFaturaComercial");
		}
			#endregion
			#region tbProdutosFaturaComercialPropriedades
			public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades GetTbProdutosFaturaComercialPropriedades(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades tbProdutosFaturaComercialPropriedades = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades();
				SetCommandSelect("tbProdutosFaturaComercialPropriedades",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				SetSQLSelect("tbProdutosFaturaComercialPropriedades",strReturnCommandSelect());
				System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaComercialPropriedades;
				DataAdapterFill(ref dtstTabela,"tbProdutosFaturaComercialPropriedades");
				return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades)dtstTabela);
			}

			public void SetTbProdutosFaturaComercialPropriedades(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades tbProdutosFaturaComercialPropriedades)
			{
				System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaComercialPropriedades;
				CheckIntegrityDataSet(ref dtstGeneric);
				SetCommandSelect(GetSQLSelect("tbProdutosFaturaComercialPropriedades")); 
				DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaComercialPropriedades,"tbProdutosFaturaComercialPropriedades");
			}
			#endregion
			#region tbProdutosFaturaCotacao
		public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao GetTbProdutosFaturaCotacao(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao tbProdutosFaturaCotacao = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao();
			SetCommandSelect("tbProdutosFaturaCotacao",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbProdutosFaturaCotacao",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaCotacao;
			DataAdapterFill(ref dtstTabela,"tbProdutosFaturaCotacao");
			return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao)dtstTabela);
		}

		public void SetTbProdutosFaturaCotacao(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao tbProdutosFaturaCotacao)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaCotacao;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbProdutosFaturaCotacao")); 
			DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaCotacao,"tbProdutosFaturaCotacao");
		}
			#endregion
			#region tbProdutosFaturaCotacaoPropriedades
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades GetTbProdutosFaturaCotacaoPropriedades(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades tbProdutosFaturaCotacaoPropriedades = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades();
					SetCommandSelect("tbProdutosFaturaCotacaoPropriedades",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosFaturaCotacaoPropriedades",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaCotacaoPropriedades;
					DataAdapterFill(ref dtstTabela,"tbProdutosFaturaCotacaoPropriedades");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades)dtstTabela);
				}

				public void SetTbProdutosFaturaCotacaoPropriedades(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades tbProdutosFaturaCotacaoPropriedades)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaCotacaoPropriedades;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosFaturaCotacaoPropriedades")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaCotacaoPropriedades,"tbProdutosFaturaCotacaoPropriedades");
				}
			#endregion
			#region tbProdutosFaturaProforma
		public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma GetTbProdutosFaturaProforma(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma tbProdutosFaturaProforma = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma();
			SetCommandSelect("tbProdutosFaturaProforma",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbProdutosFaturaProforma",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaProforma;
			DataAdapterFill(ref dtstTabela,"tbProdutosFaturaProforma");
			return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma)dtstTabela);
		}

		public void SetTbProdutosFaturaProforma(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma tbProdutosFaturaProforma)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaProforma;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbProdutosFaturaProforma")); 
			DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaProforma,"tbProdutosFaturaProforma");
		}
			#endregion
			#region tbProdutosFaturaProformaPropriedades
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades GetTbProdutosFaturaProformaPropriedades(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades tbProdutosFaturaProformaPropriedades = new mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades();
					SetCommandSelect("tbProdutosFaturaProformaPropriedades",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosFaturaProformaPropriedades",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosFaturaProformaPropriedades;
					DataAdapterFill(ref dtstTabela,"tbProdutosFaturaProformaPropriedades");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades)dtstTabela);
				}

				public void SetTbProdutosFaturaProformaPropriedades(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades tbProdutosFaturaProformaPropriedades)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosFaturaProformaPropriedades;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosFaturaProformaPropriedades")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosFaturaProformaPropriedades,"tbProdutosFaturaProformaPropriedades");
				}
			#endregion
			#region tbProdutosIdiomas
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas GetTbProdutosIdiomas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas tbProdutosIdiomas = new mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas();
					SetCommandSelect("tbProdutosIdiomas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosIdiomas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosIdiomas;
					DataAdapterFill(ref dtstTabela,"tbProdutosIdiomas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas)dtstTabela);
				}

				public void AddTbProdutosIdiomas(mdlDataBaseAccess.Tabelas.XsdTbProdutos tbProdutos,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas tbProdutosIdiomas = GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasDataTable dttbProdutosIdiomas = tbProdutosIdiomas.tbProdutosIdiomas;
					tbProdutosIdiomas.Tables.Clear();
					tbProdutos.Tables.Add(dttbProdutosIdiomas);
					tbProdutos.Relations.Add("tbProdutosXtbProdutosIdioma",tbProdutos.tbProdutos.idProdutoColumn,dttbProdutosIdiomas.idProdutoColumn,true);
				}

				public void SetTbProdutosIdiomas(mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas tbProdutosIdiomas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosIdiomas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosIdiomas"));
					DataAdapterUpdate((System.Data.DataSet)tbProdutosIdiomas,"tbProdutosIdiomas");
				}
			#endregion
			#region tbProdutosNaladi
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi GetTbProdutosNaladi(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi tbProdutosNaladi = new mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi();
					SetCommandSelect("tbProdutosNaladi",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosNaladi",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosNaladi;
					DataAdapterFill(ref dtstTabela,"tbProdutosNaladi");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)dtstTabela);
				}

				public void SetTbProdutosNaladi(mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi tbProdutosNaladi)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosNaladi;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosNaladi")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosNaladi,"tbProdutosNaladi");
				}
			#endregion
			#region tbProdutosNcm
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm GetTbProdutosNcm(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm tbProdutosNcm = new mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm();
					SetCommandSelect("tbProdutosNcm",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosNcm",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosNcm;
					DataAdapterFill(ref dtstTabela,"tbProdutosNcm");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)dtstTabela);
				}

				public void SetTbProdutosNcm(mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm tbProdutosNcm)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosNcm;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosNcm")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosNcm,"tbProdutosNcm");
				}
			#endregion
			#region tbProdutosParents
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosParents GetTbProdutosParents(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosParents tbProdutosParents = new mdlDataBaseAccess.Tabelas.XsdTbProdutosParents();
					SetCommandSelect("tbProdutosParents",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosParents",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosParents;
					DataAdapterFill(ref dtstTabela,"tbProdutosParents");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosParents)dtstTabela);
				}

				public void SetTbProdutosParents(mdlDataBaseAccess.Tabelas.XsdTbProdutosParents tbProdutosParents)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosParents;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosParents")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosParents,"tbProdutosParents");
				}
			#endregion
			#region	tbProdutosRomaneioEmbalagens
		public mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens GetTbProdutosRomaneioEmbalagens(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens tbProdutosRomaneioEmbalagens = new mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens();
			SetCommandSelect("tbProdutosRomaneioEmbalagens",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbProdutosRomaneioEmbalagens",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosRomaneioEmbalagens;
			DataAdapterFill(ref dtstTabela,"tbProdutosRomaneioEmbalagens");
			return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens)dtstTabela);
		}

		public void SetTbProdutosRomaneioEmbalagens(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens tbProdutosRomaneioEmbalagens)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosRomaneioEmbalagens;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbProdutosRomaneioEmbalagens")); 
			DataAdapterUpdate((System.Data.DataSet)tbProdutosRomaneioEmbalagens,"tbProdutosRomaneioEmbalagens");
		}
			#endregion
			#region	tbProdutosRomaneioEmbalagensProdutos
		public mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos GetTbProdutosRomaneioEmbalagensProdutos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
		{
			mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos tbProdutosRomaneioEmbalagensProdutos = new mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos();
			SetCommandSelect("tbProdutosRomaneioEmbalagensProdutos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			SetSQLSelect("tbProdutosRomaneioEmbalagensProdutos",strReturnCommandSelect());
			System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosRomaneioEmbalagensProdutos;
			DataAdapterFill(ref dtstTabela,"tbProdutosRomaneioEmbalagensProdutos");
			return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos)dtstTabela);
		}

		public void SetTbProdutosRomaneioEmbalagensProdutos(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos tbProdutosRomaneioEmbalagensProdutos)
		{
			System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosRomaneioEmbalagensProdutos;
			CheckIntegrityDataSet(ref dtstGeneric);
			SetCommandSelect(GetSQLSelect("tbProdutosRomaneioEmbalagensProdutos")); 
			DataAdapterUpdate((System.Data.DataSet)tbProdutosRomaneioEmbalagensProdutos,"tbProdutosRomaneioEmbalagensProdutos");
		}
			#endregion
			#region tbProdutosRomaneioSimplificado
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado GetTbProdutosRomaneioSimplificado(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado tbProdutosRomaneioSimplificado = new mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado();
					SetCommandSelect("tbProdutosRomaneioSimplificado",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosRomaneioSimplificado",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosRomaneioSimplificado;
					DataAdapterFill(ref dtstTabela,"tbProdutosRomaneioSimplificado");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado)dtstTabela);
				}

				public void SetTbProdutosRomaneioSimplificado(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado tbProdutosRomaneioSimplificado)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosRomaneioSimplificado;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosRomaneioSimplificado")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosRomaneioSimplificado,"tbProdutosRomaneioSimplificado");
				}
			#endregion
			#region	tbProdutosRomaneioVolumes
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes GetTbProdutosRomaneioVolumes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes tbProdutosRomaneioVolumes = new mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes();
					SetCommandSelect("tbProdutosRomaneioVolumes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosRomaneioVolumes",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosRomaneioVolumes;
					DataAdapterFill(ref dtstTabela,"tbProdutosRomaneioVolumes");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes)dtstTabela);
				}

				public void SetTbProdutosRomaneioVolumes(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes tbProdutosRomaneioVolumes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosRomaneioVolumes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosRomaneioVolumes")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosRomaneioVolumes,"tbProdutosRomaneioVolumes");
				}
			#endregion
			#region	tbProdutosRomaneioVolumesProdutos
				public mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos GetTbProdutosRomaneioVolumesProdutos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos tbProdutosRomaneioVolumesProdutos = new mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos();
					SetCommandSelect("tbProdutosRomaneioVolumesProdutos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbProdutosRomaneioVolumesProdutos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbProdutosRomaneioVolumesProdutos;
					DataAdapterFill(ref dtstTabela,"tbProdutosRomaneioVolumesProdutos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos)dtstTabela);
				}

				public void SetTbProdutosRomaneioVolumesProdutos(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos tbProdutosRomaneioVolumesProdutos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbProdutosRomaneioVolumesProdutos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbProdutosRomaneioVolumesProdutos")); 
					DataAdapterUpdate((System.Data.DataSet)tbProdutosRomaneioVolumesProdutos,"tbProdutosRomaneioVolumesProdutos");
				}
			#endregion
			#region tbPropriedadesProdutos
				public mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos GetTbPropriedadesProdutos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos tbPropriedadesProdutos = new mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos();
					SetCommandSelect("tbPropriedadesProdutos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbPropriedadesProdutos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbPropriedadesProdutos;
					DataAdapterFill(ref dtstTabela,"tbPropriedadesProdutos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos)dtstTabela);
				}

				public void SetTbPropriedadesProdutos(mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos tbPropriedadesProdutos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbPropriedadesProdutos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbPropriedadesProdutos")); 
					DataAdapterUpdate((System.Data.DataSet)tbPropriedadesProdutos,"tbPropriedadesProdutos");
				}
			#endregion

			#region tbRelatorioCamposBD
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD GetTbRelatorioCamposBD(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD tbRelatorioCamposBD = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioCamposBD",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioCamposBD",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioCamposBD;
							DataAdapterFill(ref dtstTabela,"tbRelatorioCamposBD");
							if (m_bWriteXml)
								tbRelatorioCamposBD.WriteXml("C:\\XmlTbRelatorioCamposBD.xml");
							break;
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioCamposBD);
							break;
					}
					return (tbRelatorioCamposBD);
				}

				public void AddTbRelatorioCamposBD(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD tbRelatorioCamposBD = GetTbRelatorioCamposBD(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD.tbRelatorioCamposBDDataTable dttbRelatorioCamposBD = tbRelatorioCamposBD.tbRelatorioCamposBD;
					tbRelatorioCamposBD.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioCamposBD);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioCamposBD",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioCamposBD.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioCamposBD(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD tbRelatorioCamposBD)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioCamposBD;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioCamposBD")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioCamposBD,"tbRelatorioCamposBD");
				}
			#endregion
			#region tbRelatorioCirculos
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos GetTbRelatorioCirculos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos tbRelatorioCirculos = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioCirculos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioCirculos",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioCirculos;
							DataAdapterFill(ref dtstTabela,"tbRelatorioCirculos");
							if (m_bWriteXml)
								tbRelatorioCirculos.WriteXml("C:\\XmlTbRelatorioCirculos.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioCirculos);
							break;
					}
					return (tbRelatorioCirculos);
				}

				public void AddTbRelatorioCirculos(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos tbRelatorioCirculos = GetTbRelatorioCirculos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos.tbRelatorioCirculosDataTable dttbRelatorioCirculos = tbRelatorioCirculos.tbRelatorioCirculos;
					tbRelatorioCirculos.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioCirculos);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioCirculos",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioCirculos.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioCirculos(mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos tbRelatorioCirculos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioCirculos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioCirculos")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioCirculos,"tbRelatorioCirculos");
				}
			#endregion
			#region tbRelatorioEtiquetas
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas GetTbRelatorioEtiquetas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas tbRelatorioEtiquetas = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioEtiquetas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioEtiquetas",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioEtiquetas;
							DataAdapterFill(ref dtstTabela,"tbRelatorioEtiquetas");
							if (m_bWriteXml)
								tbRelatorioEtiquetas.WriteXml("C:\\XmlTbRelatorioEtiquetas.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioEtiquetas);
							break;
					}
					return (tbRelatorioEtiquetas);
				}

				public void AddTbRelatorioEtiquetas(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas tbRelatorioEtiquetas = GetTbRelatorioEtiquetas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas.tbRelatorioEtiquetasDataTable dttbRelatorioEtiquetas = tbRelatorioEtiquetas.tbRelatorioEtiquetas;
					tbRelatorioEtiquetas.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioEtiquetas);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioEtiquetas",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioEtiquetas.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioEtiquetas(mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas tbRelatorioEtiquetas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioEtiquetas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioEtiquetas")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioEtiquetas,"tbRelatorioEtiquetas");
				}
			#endregion
			#region tbRelatorioImagens
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens GetTbRelatorioImagens(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens tbRelatorioImagens = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioImagens",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioImagens",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioImagens;
							DataAdapterFill(ref dtstTabela,"tbRelatorioImagens");
							if (m_bWriteXml)
								tbRelatorioImagens.WriteXml("C:\\XmlTbRelatorioImagens.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioImagens);
							break;
					}
					return (tbRelatorioImagens);
				}

				public void AddTbRelatorioImagens(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens tbRelatorioImagens = GetTbRelatorioImagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens.tbRelatorioImagensDataTable dttbRelatorioImagens = tbRelatorioImagens.tbRelatorioImagens;
					tbRelatorioImagens.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioImagens);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioImagens",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioImagens.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioImagens(mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens tbRelatorioImagens)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioImagens;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioImagens")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioImagens,"tbRelatorioImagens");
				}
			#endregion
			#region tbRelatorioLinhas
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas GetTbRelatorioLinhas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas tbRelatorioLinhas = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioLinhas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioLinhas",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioLinhas;
							DataAdapterFill(ref dtstTabela,"tbRelatorioLinhas");
							if (m_bWriteXml)
								tbRelatorioLinhas.WriteXml("C:\\XmlTbRelatorioLinhas.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioLinhas);
							break;
					}
					return (tbRelatorioLinhas);
				}

				public void AddTbRelatorioLinhas(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas tbRelatorioLinhas = GetTbRelatorioLinhas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas.tbRelatorioLinhasDataTable dttbRelatorioLinhas = tbRelatorioLinhas.tbRelatorioLinhas;
					tbRelatorioLinhas.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioLinhas);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioLinhas",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioLinhas.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioLinhas(mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas tbRelatorioLinhas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioLinhas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioLinhas")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioLinhas,"tbRelatorioLinhas");
				}
			#endregion
			#region tbRelatorioRetangulos
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos GetTbRelatorioRetangulos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos tbRelatorioRetangulos = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorioRetangulos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorioRetangulos",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorioRetangulos;
							DataAdapterFill(ref dtstTabela,"tbRelatorioRetangulos");
							if (m_bWriteXml)
								tbRelatorioRetangulos.WriteXml("C:\\XmlTbRelatorioRetangulos.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioRetangulos);
							break;
					}
					return (tbRelatorioRetangulos);
				}

				public void AddTbRelatorioRetangulos(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios,System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos tbRelatorioRetangulos = GetTbRelatorioRetangulos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos.tbRelatorioRetangulosDataTable dttbRelatorioRetangulos = tbRelatorioRetangulos.tbRelatorioRetangulos;
					tbRelatorioRetangulos.Tables.Clear();
					tbRelatorios.Tables.Add(dttbRelatorioRetangulos);
					tbRelatorios.Relations.Add("tbRelatoriosXtbRelatorioRetangulos",tbRelatorios.tbRelatorios.nIdRelatorioColumn, dttbRelatorioRetangulos.nIdRelatorioColumn,true);
				}

				public void SetTbRelatorioRetangulos(mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos tbRelatorioRetangulos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioRetangulos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioRetangulos")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioRetangulos,"tbRelatorioRetangulos");
				}
			#endregion
			#region tbRelatorios
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorios GetTbRelatorios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios = new mdlDataBaseAccess.Tabelas.XsdTbRelatorios();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbRelatorios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbRelatorios",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatorios;
							DataAdapterFill(ref dtstTabela,"tbRelatorios");
							if (m_bWriteXml)
								tbRelatorios.WriteXml("C:\\XmlTbRelatorios.xml");
							return ((mdlDataBaseAccess.Tabelas.XsdTbRelatorios)dtstTabela);
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorios);
							break;
					} 
					return (tbRelatorios);
				}

				public void SetTbRelatorios(mdlDataBaseAccess.Tabelas.XsdTbRelatorios tbRelatorios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorios")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorios,"tbRelatorios");
				}
			#endregion
			#region tbRelatoriosCamposBDPreRequisitos
				public mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDPreRequisitos GetTbRelatoriosCamposBDPreRequisitos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDPreRequisitos tbRelatoriosCamposBDPreRequisitos = new mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDPreRequisitos();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatoriosCamposBDPreRequisitos);
							break;
					}
					return (tbRelatoriosCamposBDPreRequisitos);
				}

				public void SetTbRelatoriosCamposBDPreRequisitos(mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDPreRequisitos tbRelatoriosCamposBDPreRequisitos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatoriosCamposBDPreRequisitos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatoriosCamposBDPreRequisitos")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatoriosCamposBDPreRequisitos,"tbRelatoriosCamposBDPreRequisitos");
				}
			#endregion
			#region tbRelatoriosCamposBDRelatorios
				public mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios GetTbRelatoriosCamposBDRelatorios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios tbRelatoriosCamposBDRelatorios = new mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatoriosCamposBDRelatorios);
							break;
						case FonteDados.DataBase:
//							SetCommandSelect("tbRelatoriosCamposBDRelatorios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
//							SetSQLSelect("tbRelatoriosCamposBDRelatorios",strReturnCommandSelect());
//							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatoriosCamposBDRelatorios;
//							DataAdapterFill(ref dtstTabela,"tbRelatoriosCamposBDRelatorios");
//							tbRelatoriosCamposBDRelatorios.WriteXml("C:\\XmlTbRelatoriosCamposBDRelatorios.xml");
							break;
					}
					return (tbRelatoriosCamposBDRelatorios);
				}

				public void SetTbRelatoriosCamposBDRelatorios(mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios tbRelatoriosCamposBDRelatorios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatoriosCamposBDRelatorios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatoriosCamposBDRelatorios")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatoriosCamposBDRelatorios,"tbRelatoriosCamposBDRelatorios");
				}
			#endregion
			#region tbRelatoriosTodosCamposBD
				public mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD GetTbRelatoriosTodosCamposBD(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD tbRelatoriosTodosCamposBD = new mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatoriosTodosCamposBD);
							break;
						case FonteDados.DataBase:
//							SetCommandSelect("tbRelatoriosTodosCamposBD",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
//							SetSQLSelect("tbRelatoriosTodosCamposBD",strReturnCommandSelect());
//							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRelatoriosTodosCamposBD;
//							DataAdapterFill(ref dtstTabela,"tbRelatoriosTodosCamposBD");
//							tbRelatoriosTodosCamposBD.WriteXml("C:\\XmlTbRelatoriosTodosCamposBD.xml");
							break;
					}
					return (tbRelatoriosTodosCamposBD);
				}

				public void SetTbRelatoriosTodosCamposBD(mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD tbRelatoriosTodosCamposBD)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatoriosTodosCamposBD;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatoriosTodosCamposBD")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatoriosTodosCamposBD,"tbRelatoriosTodosCamposBD");
				}
			#endregion
			#region tbRelatorioTipo
				public mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo GetTbRelatorioTipo(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo tbRelatorioTipo = new mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbRelatorioTipo);
							break;
					}
					return (tbRelatorioTipo);
				}

				public void SetTbRelatorioTipo(mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo tbRelatorioTipo)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRelatorioTipo;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRelatorioTipo")); 
					DataAdapterUpdate((System.Data.DataSet)tbRelatorioTipo,"tbRelatorioTipo");
				}
			#endregion

			#region tbREs
				public mdlDataBaseAccess.Tabelas.XsdTbREs GetTbREs(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs tbREs = new mdlDataBaseAccess.Tabelas.XsdTbREs();
					SetCommandSelect("tbREs",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbREs",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbREs;
					DataAdapterFill(ref dtstTabela,"tbREs");
					return ((mdlDataBaseAccess.Tabelas.XsdTbREs)dtstTabela);
				}
				public void SetTbREs(mdlDataBaseAccess.Tabelas.XsdTbREs tbREs)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbREs;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbREs")); 
					DataAdapterUpdate((System.Data.DataSet)tbREs,"tbREs");
				}
			#endregion
				
			#region tbReservas
				public mdlDataBaseAccess.Tabelas.XsdTbReservas GetTbReservas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas tbReservas = new mdlDataBaseAccess.Tabelas.XsdTbReservas();
					SetCommandSelect("tbReservas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbReservas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbReservas;
					DataAdapterFill(ref dtstTabela,"tbReservas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbReservas)dtstTabela);
				}
				public void SetTbReservas(mdlDataBaseAccess.Tabelas.XsdTbReservas tbReservas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbReservas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbReservas")); 
					DataAdapterUpdate((System.Data.DataSet)tbReservas,"tbReservas");
				}
			#endregion

			#region tbREsEspelhos
				public mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos GetTbREsEspelhos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos tbREsEspelhos = new mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos();
					if (this.FonteDosDados == mdlDataBaseAccess.FonteDados.DataBase)
					{
						SetCommandSelect("tbREsEspelhos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
						SetSQLSelect("tbREsEspelhos",strReturnCommandSelect());
						System.Data.DataSet dtstTabela = (System.Data.DataSet)tbREsEspelhos;
						DataAdapterFill(ref dtstTabela,"tbREsEspelhos");
						return ((mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos)dtstTabela);
					}else if ((this.FonteDosDados == mdlDataBaseAccess.FonteDados.Directory) && (this.IsDirectoryFilesExists)){
						if (System.IO.File.Exists(this.DirectoryFiles + "\\tbREsEspelhos.xml"))
							tbREsEspelhos.ReadXml(this.DirectoryFiles + "\\tbREsEspelhos.xml");
						return(tbREsEspelhos);
					}else{
						return(tbREsEspelhos);
					}

				}
				public void SetTbREsEspelhos(mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos tbREsEspelhos)
				{
					if (this.FonteDosDados == mdlDataBaseAccess.FonteDados.DataBase)
					{
						System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbREsEspelhos;
						CheckIntegrityDataSet(ref dtstGeneric);
						SetCommandSelect(GetSQLSelect("tbREsEspelhos")); 
						DataAdapterUpdate((System.Data.DataSet)tbREsEspelhos,"tbREsEspelhos");
					}else if ((this.FonteDosDados == mdlDataBaseAccess.FonteDados.Directory) && (this.IsDirectoryFilesExists)){
						tbREsEspelhos.WriteXml(this.DirectoryFiles + "\\tbREsEspelhos.xml");
					}
				}
			#endregion
			#region tbREsEspelhosAnexos
				public mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos GetTbREsEspelhosAnexos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos tbREsEspelhosAnexos = new mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos();
					if (this.FonteDosDados == mdlDataBaseAccess.FonteDados.DataBase)
					{
						SetCommandSelect("tbREsEspelhosAnexos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
						SetSQLSelect("tbREsEspelhosAnexos",strReturnCommandSelect());
						System.Data.DataSet dtstTabela = (System.Data.DataSet)tbREsEspelhosAnexos;
						DataAdapterFill(ref dtstTabela,"tbREsEspelhosAnexos");
						return ((mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos)dtstTabela);
					}else if ((this.FonteDosDados == mdlDataBaseAccess.FonteDados.Directory) && (this.IsDirectoryFilesExists))
					{
						if (System.IO.File.Exists(this.DirectoryFiles + "\\tbREsEspelhosAnexos.xml"))
							tbREsEspelhosAnexos.ReadXml(this.DirectoryFiles + "\\tbREsEspelhosAnexos.xml");
						return(tbREsEspelhosAnexos);
					}else{
						return(tbREsEspelhosAnexos);
					}
				}
				public void SetTbREsEspelhosAnexos(mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos tbREsEspelhosAnexos)
				{
					if (this.FonteDosDados == mdlDataBaseAccess.FonteDados.DataBase)
					{
						System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbREsEspelhosAnexos;
						CheckIntegrityDataSet(ref dtstGeneric);
						SetCommandSelect(GetSQLSelect("tbREsEspelhosAnexos")); 
						DataAdapterUpdate((System.Data.DataSet)tbREsEspelhosAnexos,"tbREsEspelhosAnexos");
					}else if ((this.FonteDosDados == mdlDataBaseAccess.FonteDados.Directory) && (this.IsDirectoryFilesExists)){
						tbREsEspelhosAnexos.WriteXml(this.DirectoryFiles + "\\tbREsEspelhosAnexos.xml");
					}
				}
			#endregion

			#region tbREsPEs
				public mdlDataBaseAccess.Tabelas.XsdTbREsPEs GetTbREsPEs(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs tbREsPEs = new mdlDataBaseAccess.Tabelas.XsdTbREsPEs();
					SetCommandSelect("tbREsPEs",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbREsPEs",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbREsPEs;
					DataAdapterFill(ref dtstTabela,"tbREsPEs");
					return ((mdlDataBaseAccess.Tabelas.XsdTbREsPEs)dtstTabela);
				}
				public void SetTbREsPEs(mdlDataBaseAccess.Tabelas.XsdTbREsPEs tbREsPEs)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbREsPEs;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbREsPEs")); 
					DataAdapterUpdate((System.Data.DataSet)tbREsPEs,"tbREsPEs");
				}
			#endregion
			
			#region tbRomaneios
				public mdlDataBaseAccess.Tabelas.XsdTbRomaneios GetTbRomaneios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios tbRomaneios = new mdlDataBaseAccess.Tabelas.XsdTbRomaneios();
					SetCommandSelect("tbRomaneios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbRomaneios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRomaneios;
					DataAdapterFill(ref dtstTabela,"tbRomaneios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbRomaneios)dtstTabela);
				}
				public void SetTbRomaneios(mdlDataBaseAccess.Tabelas.XsdTbRomaneios tbRomaneios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRomaneios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("TbRomaneios")); 
					DataAdapterUpdate((System.Data.DataSet)tbRomaneios,"tbRomaneios");
				}
			#endregion
			#region tbRomaneiosSecundarios
				public mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios GetTbRomaneiosSecundarios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios tbRomaneiosSecundarios = new mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios();
					SetCommandSelect("tbRomaneiosSecundarios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbRomaneiosSecundarios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbRomaneiosSecundarios;
					DataAdapterFill(ref dtstTabela,"tbRomaneiosSecundarios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios)dtstTabela);
				}
				public void SetTbRomaneiosSecundarios(mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios tbRomaneiosSecundarios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbRomaneiosSecundarios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbRomaneiosSecundarios")); 
					DataAdapterUpdate((System.Data.DataSet)tbRomaneiosSecundarios,"tbRomaneiosSecundarios");
				}
			#endregion
			
			#region tbSaques
				public mdlDataBaseAccess.Tabelas.XsdTbSaques GetTbSaques(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques tbSaques = new mdlDataBaseAccess.Tabelas.XsdTbSaques();
					SetCommandSelect("tbSaques",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbSaques",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbSaques;
					DataAdapterFill(ref dtstTabela,"tbSaques");
					return ((mdlDataBaseAccess.Tabelas.XsdTbSaques)dtstTabela);
				}
				public void SetTbSaques(mdlDataBaseAccess.Tabelas.XsdTbSaques tbSaques)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbSaques;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbSaques")); 
					DataAdapterUpdate((System.Data.DataSet)tbSaques,"tbSaques");
				}
			#endregion

			#region tbSDs
				public mdlDataBaseAccess.Tabelas.XsdTbSDs GetTbSDs(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSDs tbSDs = new mdlDataBaseAccess.Tabelas.XsdTbSDs();
					SetCommandSelect("tbSDs",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbSDs",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbSDs;
					DataAdapterFill(ref dtstTabela,"tbSDs");
					return ((mdlDataBaseAccess.Tabelas.XsdTbSDs)dtstTabela);
				}
				public void SetTbSDs(mdlDataBaseAccess.Tabelas.XsdTbSDs tbSDs)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbSDs;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbSDs")); 
					DataAdapterUpdate((System.Data.DataSet)tbSDs,"tbSDs");
				}
			#endregion

			#region tbStatisticDataManipulators
				public mdlDataBaseAccess.Tabelas.XsdTbStatisticDataManipulators GetTbStatisticDataManipulators(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbStatisticDataManipulators tbStatisticDataManipulators = new mdlDataBaseAccess.Tabelas.XsdTbStatisticDataManipulators();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbStatisticDataManipulators",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbStatisticDataManipulators",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbStatisticDataManipulators;
							DataAdapterFill(ref dtstTabela,"tbStatisticDataManipulators");
							if (m_bWriteXml)
								tbStatisticDataManipulators.WriteXml("C:\\XmlTbStatisticDataManipulators.xml");
							break;
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbStatisticDataManipulators);
							break;
					} 
					return (tbStatisticDataManipulators);
				}
				public void SetTbStatisticDataManipulators(mdlDataBaseAccess.Tabelas.XsdTbStatisticDataManipulators tbStatisticDataManipulators)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbStatisticDataManipulators;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbStatisticDataManipulators")); 
					DataAdapterUpdate((System.Data.DataSet)tbStatisticDataManipulators,"tbStatisticDataManipulators");
				}
			#endregion
			#region tbStatisticReports
				public mdlDataBaseAccess.Tabelas.XsdTbStatisticReports GetTbStatisticReports(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbStatisticReports tbStatisticReports = new mdlDataBaseAccess.Tabelas.XsdTbStatisticReports();
					switch(m_enumFonteDados)
					{
						case FonteDados.DataBase:
							SetCommandSelect("tbStatisticReports",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							SetSQLSelect("tbStatisticReports",strReturnCommandSelect());
							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbStatisticReports;
							DataAdapterFill(ref dtstTabela,"tbStatisticReports");
							if (m_bWriteXml)
								tbStatisticReports.WriteXml("C:\\XmlTbStatisticReports.xml");
							break;
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbStatisticReports);
							break;
					} 
					return (tbStatisticReports);
				}
				public void SetTbStatisticReports(mdlDataBaseAccess.Tabelas.XsdTbStatisticReports tbStatisticReports)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbStatisticReports;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbStatisticReports")); 
					DataAdapterUpdate((System.Data.DataSet)tbStatisticReports,"tbStatisticReports");
				}
			#endregion

			#region TbSumarios
				public mdlDataBaseAccess.Tabelas.XsdTbSumarios GetTbSumarios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSumarios tbSumarios = new mdlDataBaseAccess.Tabelas.XsdTbSumarios();
					SetCommandSelect("tbSumarios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("TbSumarios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbSumarios;
					DataAdapterFill(ref dtstTabela,"tbSumarios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbSumarios)dtstTabela);
				}
				public void SetTbSumarios(mdlDataBaseAccess.Tabelas.XsdTbSumarios tbSumarios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbSumarios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("TbSumarios")); 
					DataAdapterUpdate((System.Data.DataSet)tbSumarios,"tbSumarios");
				}
			#endregion

			#region tbTerminais
				public mdlDataBaseAccess.Tabelas.XsdTbTerminais GetTbTerminais(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminais tbTerminais = new mdlDataBaseAccess.Tabelas.XsdTbTerminais();
					SetCommandSelect("tbTerminais",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTerminais",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTerminais;
					DataAdapterFill(ref dtstTabela,"tbTerminais");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTerminais)dtstTabela);
				}
				public void SetTbTerminais(mdlDataBaseAccess.Tabelas.XsdTbTerminais tbTerminais)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTerminais;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTerminais")); 
					DataAdapterUpdate((System.Data.DataSet)tbTerminais,"tbTerminais");
				}
			#endregion
			#region tbTerminaisContatos
				public mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos GetTbTerminaisContatos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos tbTerminaisContatos = new mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos();
					SetCommandSelect("tbTerminaisContatos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTerminaisContatos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTerminaisContatos;
					DataAdapterFill(ref dtstTabela,"tbTerminaisContatos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos)dtstTabela);
				}
				public void SetTbTerminaisContatos(mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos tbTerminaisContatos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTerminaisContatos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTerminaisContatos")); 
					DataAdapterUpdate((System.Data.DataSet)tbTerminaisContatos,"tbTerminaisContatos");
				}
			#endregion

			#region tbTransportadoras
				public mdlDataBaseAccess.Tabelas.XsdTbTransportadoras GetTbTransportadoras(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadoras tbTransportadoras = new mdlDataBaseAccess.Tabelas.XsdTbTransportadoras();
					SetCommandSelect("tbTransportadoras",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTransportadoras",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTransportadoras;
					DataAdapterFill(ref dtstTabela,"tbTransportadoras");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTransportadoras)dtstTabela);
				}
				public void SetTbTransportadoras(mdlDataBaseAccess.Tabelas.XsdTbTransportadoras tbTransportadoras)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTransportadoras;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTransportadoras")); 
					DataAdapterUpdate((System.Data.DataSet)tbTransportadoras,"tbTransportadoras");
				}
			#endregion
			#region tbTransportadorasContatos
				public mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos GetTbTransportadorasContatos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos tbTransportadorasContatos = new mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos();
					SetCommandSelect("tbTransportadorasContatos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTransportadorasContatos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTransportadorasContatos;
					DataAdapterFill(ref dtstTabela,"tbTransportadorasContatos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos)dtstTabela);
				}
				public void SetTbTransportadorasContatos(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos tbTransportadorasContatos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTransportadorasContatos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTransportadorasContatos")); 
					DataAdapterUpdate((System.Data.DataSet)tbTransportadorasContatos,"tbTransportadorasContatos");
				}
			#endregion
			#region tbTransportadorasMotoristas
				public mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas GetTbTransportadorasMotoristas(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas tbTransportadorasMotoristas = new mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas();
					SetCommandSelect("tbTransportadorasMotoristas",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTransportadorasMotoristas",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTransportadorasMotoristas;
					DataAdapterFill(ref dtstTabela,"tbTransportadorasMotoristas");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas)dtstTabela);
				}
				public void SetTbTransportadorasMotoristas(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas tbTransportadorasMotoristas)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTransportadorasMotoristas;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTransportadorasMotoristas")); 
					DataAdapterUpdate((System.Data.DataSet)tbTransportadorasMotoristas,"tbTransportadorasMotoristas");
				}
			#endregion
			#region tbTransportadorasVeiculos
				public mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos GetTbTransportadorasVeiculos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos tbTransportadorasVeiculos = new mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos();
					SetCommandSelect("tbTransportadorasVeiculos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbTransportadorasVeiculos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbTransportadorasVeiculos;
					DataAdapterFill(ref dtstTabela,"tbTransportadorasVeiculos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos)dtstTabela);
				}
				public void SetTbTransportadorasVeiculos(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos tbTransportadorasVeiculos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbTransportadorasVeiculos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbTransportadorasVeiculos")); 
					DataAdapterUpdate((System.Data.DataSet)tbTransportadorasVeiculos,"tbTransportadorasVeiculos");
				}
			#endregion

			#region tbUnidadesEspaco
				public mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco GetTbUnidadesEspaco(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco tbUnidadesEspaco = new mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUnidadesEspaco);
							break;
					}
					return (tbUnidadesEspaco);
				}
			#endregion
			#region tbUnidadesEspacoIdioma 
				public mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma GetTbUnidadesEspacoIdioma(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma tbUnidadesEspacoIdioma = new mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUnidadesEspacoIdioma);
							break;
					}
					return (tbUnidadesEspacoIdioma);
				}
			#endregion
			#region tbUnidadesMassa 
				public mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa GetTbUnidadesMassa(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa tbUnidadesMassa = new mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUnidadesMassa);
							break;
					}
					return (tbUnidadesMassa);
				}
			#endregion
			#region tbUnidadesMassaIdioma 
				public mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma GetTbUnidadesMassaIdioma(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma tbUnidadesMassaIdioma = new mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUnidadesMassaIdioma);
							break;
					}
					return (tbUnidadesMassaIdioma);
				}
			#endregion

			#region tbUsuarios 
				public mdlDataBaseAccess.Tabelas.XsdTbUsuarios GetTbUsuarios(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUsuarios tbUsuarios = new mdlDataBaseAccess.Tabelas.XsdTbUsuarios();
					SetCommandSelect("tbUsuarios",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbUsuarios",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbUsuarios;
					DataAdapterFill(ref dtstTabela,"tbUsuarios");
					return ((mdlDataBaseAccess.Tabelas.XsdTbUsuarios)dtstTabela);
				}

				public void SetTbUsuarios(mdlDataBaseAccess.Tabelas.XsdTbUsuarios tbUsuarios)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbUsuarios;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbUsuarios")); 
					DataAdapterUpdate((System.Data.DataSet)tbUsuarios,"tbUsuarios");
				}
			#endregion
			#region tbUsuariosConcessoes
				public mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes GetTbUsuariosConcessoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes tbUsuariosConcessoes = new mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUsuariosConcessoes);
							break;
					}
					return (tbUsuariosConcessoes);
				}

				public void SetTbUsuariosConcessoes(mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes tbUsuariosConcessoes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbUsuariosConcessoes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbUsuariosConcessoes")); 
					DataAdapterUpdate((System.Data.DataSet)tbUsuariosConcessoes,"tbUsuariosConcessoes");
				}
			#endregion
			#region tbUsuariosConcessoesPermissoes
				public mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes GetTbUsuariosConcessoesPermissoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes tbUsuariosConcessoesPermissoes = new mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUsuariosConcessoesPermissoes);
							break;
					}
					return (tbUsuariosConcessoesPermissoes);
				}

				public void SetTbUsuariosConcessoesPermissoes(mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes tbUsuariosConcessoesPermissoes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbUsuariosConcessoesPermissoes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbUsuariosConcessoesPermissoes")); 
					DataAdapterUpdate((System.Data.DataSet)tbUsuariosConcessoesPermissoes,"tbUsuariosConcessoesPermissoes");
				}
			#endregion
			#region tbUsuariosPermissoes
				public mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes GetTbUsuariosPermissoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes tbUsuariosPermissoes = new mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbUsuariosPermissoes);
							break;
					}
					return (tbUsuariosPermissoes);
				}

				public void SetTbUsuariosPermissoes(mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes tbUsuariosPermissoes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbUsuariosPermissoes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbUsuariosPermissoes")); 
					DataAdapterUpdate((System.Data.DataSet)tbUsuariosPermissoes,"tbUsuariosPermissoes");
				}
			#endregion
			#region tbUsuariosPermissoesConcessoes
				public mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes GetTbUsuariosPermissoesConcessoes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes tbUsuariosPermissoesConcessoes = new mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes();
					SetCommandSelect("tbUsuariosPermissoesConcessoes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbUsuariosPermissoesConcessoes",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbUsuariosPermissoesConcessoes;
					DataAdapterFill(ref dtstTabela,"tbUsuariosPermissoesConcessoes");
					return ((mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes)dtstTabela);
				}

				public void SetTbUsuariosPermissoesConcessoes(mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes tbUsuariosPermissoesConcessoes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbUsuariosPermissoesConcessoes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbUsuariosPermissoesConcessoes")); 
					DataAdapterUpdate((System.Data.DataSet)tbUsuariosPermissoesConcessoes,"tbUsuariosPermissoesConcessoes");
				}
			#endregion
		
			#region tbVersao
				public mdlDataBaseAccess.Tabelas.XsdTbVersao GetTbVersao(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbVersao tbVersao = new mdlDataBaseAccess.Tabelas.XsdTbVersao();
					SetCommandSelect("tbVersao",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbVersao",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbVersao;
					DataAdapterFill(ref dtstTabela,"tbVersao");
					return ((mdlDataBaseAccess.Tabelas.XsdTbVersao)dtstTabela);
				}

				public void SetTbVersao(mdlDataBaseAccess.Tabelas.XsdTbVersao tbVersao)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbVersao;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbVersao")); 
					DataAdapterUpdate((System.Data.DataSet)tbVersao,"tbVersao");
				}
			#endregion
			#region tbVersaoModulo
				public mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo GetTbVersaoModulo(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo tbVersaoModulo = new mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo();
					SetCommandSelect("tbVersaoModulo",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbVersaoModulo",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbVersaoModulo;
					DataAdapterFill(ref dtstTabela,"tbVersaoModulo");
					return ((mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo)dtstTabela);
				}

				public void SetTbVersaoModulo(mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo tbVersaoModulo)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbVersaoModulo;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbVersaoModulo")); 
					DataAdapterUpdate((System.Data.DataSet)tbVersaoModulo,"tbVersaoModulo");
				}
			#endregion

			#region tbVolumes
				public mdlDataBaseAccess.Tabelas.XsdTbVolumes GetTbVolumes(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbVolumes tbVolumes = new mdlDataBaseAccess.Tabelas.XsdTbVolumes();
					switch(m_enumFonteDados)
					{
						case FonteDados.Resource:
							SetCommandSelect(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
							DataSetFill((System.Data.DataSet)tbVolumes);
							break;
						case FonteDados.DataBase:
//							SetCommandSelect("tbVolumes",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
//							SetSQLSelect("tbVolumes",strReturnCommandSelect());
//							System.Data.DataSet dtstTabela = (System.Data.DataSet)tbVolumes;
//							DataAdapterFill(ref dtstTabela,"tbVolumes");
//							if (m_bWriteXml)
//								tbVolumes.WriteXml("C:\\XmlTbVolumes.xml");
							break;

					}
					return (tbVolumes);
				}

				public void SetTbVolumes(mdlDataBaseAccess.Tabelas.XsdTbVolumes tbVolumes)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbVolumes;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbVolumes")); 
					DataAdapterUpdate((System.Data.DataSet)tbVolumes,"tbVolumes");
				}
			#endregion

			#region tbWebServicesServicos
				public mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos GetTbWebServiceServicos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos tbWebServiceServicos = new mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos();
					SetCommandSelect("tbWebServiceServicos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbWebServicesServicos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbWebServiceServicos;
					DataAdapterFill(ref dtstTabela,"tbWebServiceServicos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos)dtstTabela);
				}

				public void SetTbWebServiceServicos(mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos tbWebServiceServicos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbWebServiceServicos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbWebServicesServicos")); 
					DataAdapterUpdate((System.Data.DataSet)tbWebServiceServicos,"tbWebServiceServicos");
				}
			#endregion
			#region tbWebServicesServidores
				public mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores GetTbWebServiceServidores(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores tbWebServiceServidores = new mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores();
					SetCommandSelect("tbWebServiceServidores",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbWebServicesServidores",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbWebServiceServidores;
					DataAdapterFill(ref dtstTabela,"tbWebServiceServidores");
					return ((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores)dtstTabela);
				}

				public void SetTbWebServiceServidores(mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores tbWebServiceServidores)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbWebServiceServidores;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbWebServicesServidores")); 
					DataAdapterUpdate((System.Data.DataSet)tbWebServiceServidores,"tbWebServiceServidores");
				}
			#endregion
			#region tbWebServicesServidoresServicos
				public mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos GetTbWebServiceServidoresServicos(System.Collections.ArrayList arlCondicaoCampo,System.Collections.ArrayList arlCondicaoComparador,System.Collections.ArrayList arlCondicaoValor,System.Collections.ArrayList arlOrdenacaoCampo,System.Collections.ArrayList arlOrdenacaoTipo)
				{
					mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos tbWebServiceServidoresServicos = new mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos();
					SetCommandSelect("tbWebServiceServidoresServicos",arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					SetSQLSelect("tbWebServicesServidoresServicos",strReturnCommandSelect());
					System.Data.DataSet dtstTabela = (System.Data.DataSet)tbWebServiceServidoresServicos;
					DataAdapterFill(ref dtstTabela,"tbWebServiceServidoresServicos");
					return ((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos)dtstTabela);
				}

				public void SetTbWebServiceServidoresServicos(mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos tbWebServiceServidoresServicos)
				{
					System.Data.DataSet dtstGeneric = (System.Data.DataSet)tbWebServiceServidoresServicos;
					CheckIntegrityDataSet(ref dtstGeneric);
					SetCommandSelect(GetSQLSelect("tbWebServicesServidoresServicos")); 
					DataAdapterUpdate((System.Data.DataSet)tbWebServiceServidoresServicos,"tbWebServiceServidoresServicos");
				}
			#endregion

		#endregion 

	}
}
