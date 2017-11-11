using System;

namespace mdlDataBaseConfig
{
	#region Enuns
	internal enum TiposBancoDados
	{
		None,
		SqlServer,
		MySql,
		Jet40,
		Firebird
	}
	#endregion
	/// <summary>
	/// Summary description for clsDataBaseConfig.
	/// </summary>
	public class clsDataBaseConfig
	{
		#region Static
			#region Test Data Access
			internal static bool bDataAccessRight(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				bool bRetorno = false;
				try
				{
					bool bShowDialogErrors = cls_dba_ConnectionDB.ShowDialogsErrors;
					cls_dba_ConnectionDB.ShowDialogsErrors = false;
					cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

					// Servidores 
					if (!bExistServer(ref cls_dba_ConnectionDB))
					{
						vInsertServer(ref cls_dba_ConnectionDB);
						if (!bExistServer(ref cls_dba_ConnectionDB))
						{
							return(false);
						}
					}

					// Servicoes
					if (!bExistService(ref cls_dba_ConnectionDB))
					{
						vInsertService(ref cls_dba_ConnectionDB);
						if (!bExistService(ref cls_dba_ConnectionDB))
						{
							return(false);
						}
					}

					// Servidores Servicos 
					if (!bExistServerService(ref cls_dba_ConnectionDB))
					{
						vInsertServerService(ref cls_dba_ConnectionDB);
						if (!bExistServerService(ref cls_dba_ConnectionDB))
						{
							return(false);
						}
					}
					bRetorno = true;
					cls_dba_ConnectionDB.ShowDialogsErrors = bShowDialogErrors;
				}
				catch
				{ 
					bRetorno = false;
				}
				return(bRetorno);
			}

			private static bool bExistServer(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores typDatSetServidores = cls_dba_ConnectionDB.GetTbWebServiceServidores(null,null,null,null,null);
				return(typDatSetServidores.tbWebServiceServidores.Rows.Count > 0);
			}

			private static void vInsertServer(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores typDatSetServidores = cls_dba_ConnectionDB.GetTbWebServiceServidores(null,null,null,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores.tbWebServiceServidoresRow dtrwServidor = typDatSetServidores.tbWebServiceServidores.NewtbWebServiceServidoresRow();
				dtrwServidor.nIdServidor = 1;
				dtrwServidor.strHost = mdlConstantes.clsConstantes.DEFAULT_SERVIDOR;
				typDatSetServidores.tbWebServiceServidores.AddtbWebServiceServidoresRow(dtrwServidor);
				try
				{
					cls_dba_ConnectionDB.SetTbWebServiceServidores(typDatSetServidores);
				}catch{
				}
			}	

			private static bool bExistService(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos typDatSetServicos = cls_dba_ConnectionDB.GetTbWebServiceServicos(null,null,null,null,null);
				return(typDatSetServicos.tbWebServiceServicos.Rows.Count > 0);
			}

			private static void vInsertService(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos typDatSetServicos = cls_dba_ConnectionDB.GetTbWebServiceServicos(null,null,null,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos.tbWebServiceServicosRow dtrwServico = typDatSetServicos.tbWebServiceServicos.NewtbWebServiceServicosRow();
				dtrwServico.nIdServico = 1;
				dtrwServico.strServico = mdlConstantes.clsConstantes.DEFAULT_SERVICO;
				typDatSetServicos.tbWebServiceServicos.AddtbWebServiceServicosRow(dtrwServico);
				try
				{
					cls_dba_ConnectionDB.SetTbWebServiceServicos(typDatSetServicos);
				}
				catch
				{
				}
			}	


			private static bool bExistServerService(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos typDatSetServidoresServicos = cls_dba_ConnectionDB.GetTbWebServiceServidoresServicos(null,null,null,null,null);
				return(typDatSetServidoresServicos.tbWebServiceServidoresServicos.Rows.Count > 0);
			}

			private static void vInsertServerService(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos typDatSetServidoresServicos = cls_dba_ConnectionDB.GetTbWebServiceServidoresServicos(null,null,null,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos.tbWebServiceServidoresServicosRow dtrwServidorServico = typDatSetServidoresServicos.tbWebServiceServidoresServicos.NewtbWebServiceServidoresServicosRow();
				dtrwServidorServico.nIdServidor = 1;
				dtrwServidorServico.nIdServico = 1;
				dtrwServidorServico.mstrUrl = mdlConstantes.clsConstantes.DEFAULT_SERVIDORSERVICO;
				typDatSetServidoresServicos.tbWebServiceServidoresServicos.AddtbWebServiceServidoresServicosRow(dtrwServidorServico);
				try
				{
					cls_dba_ConnectionDB.SetTbWebServiceServidoresServicos(typDatSetServidoresServicos);
				}
				catch
				{
				}
			}	
			#endregion
		#endregion

		#region Constantes
		// Access Data Access
		internal const string DEFAULT_SQLSERVER_PORT = "1433";
		internal const string DEFAULT_MYSQL_PORT = "3306";
		internal const string DEFAULT_DATABASE = "Siscobras";
		internal const string DEFAULT_USER = "Siscobras";
		internal const string DEFAULT_PASSWORD = "Siscobras";

		// Arquivo de Configuração
		internal const string ARQUIVO_CONFIGURACAO = "Sisco.ini";

		// Data Access
		internal const string NONE = "NONE";
		internal const string JET40 = "JET40";
		internal const string SQLSERVER = "SQLSERVER";
		internal const string MYSQL = "MYSQL";
		
		// Data Access Atributes
		internal const string HOST = "HOST";
		internal const string USER = "USER";
		internal const string PASSWORD = "PASSWORD";
		internal const string PATH = "PATH";
		internal const string DATABASENAME = "DATABASENAME";
		internal const string PORT = "PORT";

		#endregion

		#region Atributos
			public bool m_bModificado = false;

			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
			private string m_strEnderecoExecutavel;
			private System.Drawing.Color m_clrFundo = System.Drawing.Color.GreenYellow;

			// DataBase
			TiposBancoDados m_enumDataBaseType = TiposBancoDados.None;
			TiposBancoDados m_enumDataBaseTypeBackup = TiposBancoDados.None;
			private bool m_bDevelopMode = false;

			// DataBaseAccessJet40
			string m_strDataBaseAccessJet40Path = "";
			string m_strDataBaseAccessJet40PathBackup = "";
			string m_strDataBaseAccessJet40User = "";
			string m_strDataBaseAccessJet40UserBackup = "";
			string m_strDataBaseAccessJet40Password = "";
			string m_strDataBaseAccessJet40PasswordBackup = "";

			// DataBaseAccessSqlServer
			string m_strDataBaseAccessSqlServerHost = "";
			string m_strDataBaseAccessSqlServerHostBackup = "";
			string m_strDataBaseAccessSqlServerPort = "";
			string m_strDataBaseAccessSqlServerPortBackup = "";
			string m_strDataBaseAccessSqlServerDataBaseName = "";
			string m_strDataBaseAccessSqlServerDataBaseNameBackup = "";
			string m_strDataBaseAccessSqlServerUser = "";
			string m_strDataBaseAccessSqlServerUserBackup = "";
			string m_strDataBaseAccessSqlServerPassword = "";
			string m_strDataBaseAccessSqlServerPasswordBackup = "";

			// DataBaseAccessMySql
			string m_strDataBaseAccessMySqlHost = "";
			string m_strDataBaseAccessMySqlHostBackup = "";
			string m_strDataBaseAccessMySqlPort = "";
			string m_strDataBaseAccessMySqlPortBackup = "";
			string m_strDataBaseAccessMySqlDataBaseName = "";
			string m_strDataBaseAccessMySqlDataBaseNameBackup = "";
			string m_strDataBaseAccessMySqlUser = "";
			string m_strDataBaseAccessMySqlUserBackup = "";
			string m_strDataBaseAccessMySqlPassword = "";
			string m_strDataBaseAccessMySqlPasswordBackup = "";
		#endregion
		#region Constructors and Destructors
		public clsDataBaseConfig(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
		{
			m_cls_ter_TratadorErro = cls_ter_TratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			vCarregaCor();
		}
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDadosConfiguracao()
			{
				// Selected DataBase 
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Configuracao = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + ARQUIVO_CONFIGURACAO);
				string strDataAccess = cls_arq_Configuracao.retornaValor("Siscobras","DataBaseAccess");
				switch(strDataAccess.Trim().ToUpper())
				{
					case JET40:
						m_enumDataBaseType = TiposBancoDados.Jet40;
						break;
					case SQLSERVER:
						m_enumDataBaseType = TiposBancoDados.SqlServer;
						break;
					case MYSQL:
						m_enumDataBaseType = TiposBancoDados.MySql;
						break;
					default:
						m_enumDataBaseType = TiposBancoDados.None;
						break;
				}

				// DevelopMode
				m_bDevelopMode = cls_arq_Configuracao.retornaValor("Siscobras","DevelopMode",false);

                // DataBaseAccessJet40
				m_strDataBaseAccessJet40Path = cls_arq_Configuracao.retornaValor(JET40,PATH);
				m_strDataBaseAccessJet40User = strBase64ToString(cls_arq_Configuracao.retornaValor(JET40,USER));
				m_strDataBaseAccessJet40Password = strBase64ToString(cls_arq_Configuracao.retornaValor(JET40,PASSWORD));

				// DataBaseAccessSqlServer
				m_strDataBaseAccessSqlServerHost = cls_arq_Configuracao.retornaValor(SQLSERVER,HOST);
				m_strDataBaseAccessSqlServerPort = cls_arq_Configuracao.retornaValor(SQLSERVER,PORT);
				m_strDataBaseAccessSqlServerDataBaseName = cls_arq_Configuracao.retornaValor(SQLSERVER,DATABASENAME);
				m_strDataBaseAccessSqlServerUser = strBase64ToString(cls_arq_Configuracao.retornaValor(SQLSERVER,USER));
				m_strDataBaseAccessSqlServerPassword = strBase64ToString(cls_arq_Configuracao.retornaValor(SQLSERVER,PASSWORD));

				// DataBaseAccessMysql
				m_strDataBaseAccessMySqlHost = cls_arq_Configuracao.retornaValor(MYSQL,HOST);
				m_strDataBaseAccessMySqlPort = cls_arq_Configuracao.retornaValor(MYSQL,PORT);
				m_strDataBaseAccessMySqlDataBaseName = cls_arq_Configuracao.retornaValor(MYSQL,DATABASENAME);
				m_strDataBaseAccessMySqlUser = strBase64ToString(cls_arq_Configuracao.retornaValor(MYSQL,USER));
				m_strDataBaseAccessMySqlPassword = strBase64ToString(cls_arq_Configuracao.retornaValor(MYSQL,PASSWORD));
			}
		#endregion
		#region Salvamento dos Dados
			private void vSalvaDadosConfiguracao()
			{
				// Selected DataBase 
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_arq_Configuracao = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + ARQUIVO_CONFIGURACAO);
				switch(m_enumDataBaseType)
				{
					case TiposBancoDados.Jet40:
						cls_arq_Configuracao.colocaValor("Siscobras","DataBaseAccess",JET40);
						break;
					case TiposBancoDados.SqlServer:
						cls_arq_Configuracao.colocaValor("Siscobras","DataBaseAccess",SQLSERVER);
						break;
					case TiposBancoDados.MySql:
						cls_arq_Configuracao.colocaValor("Siscobras","DataBaseAccess",MYSQL);
						break;
					default:
						cls_arq_Configuracao.colocaValor("Siscobras","DataBaseAccess",NONE);
						break;
				}

				// DataBaseAccessJet40
				cls_arq_Configuracao.colocaValor(JET40,PATH,m_strDataBaseAccessJet40Path);
				cls_arq_Configuracao.colocaValor(JET40,USER,strStringToBase64(m_strDataBaseAccessJet40User));
				cls_arq_Configuracao.colocaValor(JET40,PASSWORD,strStringToBase64(m_strDataBaseAccessJet40Password));

				// DataBaseAccessSqlServer
				cls_arq_Configuracao.colocaValor(SQLSERVER,HOST,m_strDataBaseAccessSqlServerHost);
				cls_arq_Configuracao.colocaValor(SQLSERVER,PORT,m_strDataBaseAccessSqlServerPort);
				cls_arq_Configuracao.colocaValor(SQLSERVER,DATABASENAME,m_strDataBaseAccessSqlServerDataBaseName);
				cls_arq_Configuracao.colocaValor(SQLSERVER,USER,strStringToBase64(m_strDataBaseAccessSqlServerUser));
				cls_arq_Configuracao.colocaValor(SQLSERVER,PASSWORD,strStringToBase64(m_strDataBaseAccessSqlServerPassword));

				// DataBaseAccessMysql
				cls_arq_Configuracao.colocaValor(MYSQL,HOST,m_strDataBaseAccessMySqlHost);
				cls_arq_Configuracao.colocaValor(MYSQL,PORT,m_strDataBaseAccessMySqlPort);
				cls_arq_Configuracao.colocaValor(MYSQL,DATABASENAME,m_strDataBaseAccessMySqlDataBaseName);
				cls_arq_Configuracao.colocaValor(MYSQL,USER,strStringToBase64(m_strDataBaseAccessMySqlUser));
				cls_arq_Configuracao.colocaValor(MYSQL,PASSWORD,strStringToBase64(m_strDataBaseAccessMySqlPassword));
			}
		#endregion

		#region bDataBaseConfigurated
		public bool bDataBaseConfigurated()
		{
			bool bRetorno = false;
			vCarregaDadosConfiguracao();
			if (m_enumDataBaseType != TiposBancoDados.None)
			{
				bRetorno = true;
			}
			return(bRetorno);
		}
		#endregion
		#region bDataBaseConfiguratedRight
		private void vDataBaseConfigBackup()
		{
			// DataBase
			m_enumDataBaseTypeBackup = m_enumDataBaseType; 

			// DataBaseAccessJet40
			m_strDataBaseAccessJet40PathBackup = m_strDataBaseAccessJet40Path;
			m_strDataBaseAccessJet40UserBackup = m_strDataBaseAccessJet40User;
			m_strDataBaseAccessJet40PasswordBackup = m_strDataBaseAccessJet40Password;

			// DataBaseAccessSqlServer
			m_strDataBaseAccessSqlServerHostBackup = m_strDataBaseAccessSqlServerHost;
			m_strDataBaseAccessSqlServerPortBackup = m_strDataBaseAccessSqlServerPort;
			m_strDataBaseAccessSqlServerDataBaseNameBackup = m_strDataBaseAccessSqlServerDataBaseName; 
			m_strDataBaseAccessSqlServerUserBackup = m_strDataBaseAccessSqlServerUser;
			m_strDataBaseAccessSqlServerPasswordBackup = m_strDataBaseAccessSqlServerPassword;

			// DataBaseAccessMySql
			m_strDataBaseAccessMySqlHostBackup = m_strDataBaseAccessMySqlHost;
			m_strDataBaseAccessMySqlPortBackup = m_strDataBaseAccessMySqlPort;
			m_strDataBaseAccessMySqlDataBaseNameBackup = m_strDataBaseAccessMySqlDataBaseName; 
			m_strDataBaseAccessMySqlUserBackup = m_strDataBaseAccessMySqlUser;
			m_strDataBaseAccessMySqlPasswordBackup = m_strDataBaseAccessMySqlPassword;
		}

		private void vDataBaseConfigRestore()
		{
			// DataBase
			m_enumDataBaseType = m_enumDataBaseTypeBackup; 

			// DataBaseAccessJet40
			m_strDataBaseAccessJet40Path = m_strDataBaseAccessJet40PathBackup;
			m_strDataBaseAccessJet40User = m_strDataBaseAccessJet40UserBackup;
			m_strDataBaseAccessJet40Password = m_strDataBaseAccessJet40PasswordBackup;

			// DataBaseAccessSqlServer
			m_strDataBaseAccessSqlServerHost = m_strDataBaseAccessSqlServerHostBackup;
			m_strDataBaseAccessSqlServerPort = m_strDataBaseAccessSqlServerPortBackup;
			m_strDataBaseAccessSqlServerDataBaseName = m_strDataBaseAccessSqlServerDataBaseNameBackup; 
			m_strDataBaseAccessSqlServerUser = m_strDataBaseAccessSqlServerUserBackup;
			m_strDataBaseAccessSqlServerPassword = m_strDataBaseAccessSqlServerPasswordBackup;

			// DataBaseAccessMySql
			m_strDataBaseAccessMySqlHost = m_strDataBaseAccessMySqlHostBackup;
			m_strDataBaseAccessMySqlPort = m_strDataBaseAccessMySqlPortBackup;
			m_strDataBaseAccessMySqlDataBaseName = m_strDataBaseAccessMySqlDataBaseNameBackup; 
			m_strDataBaseAccessMySqlUser = m_strDataBaseAccessMySqlUserBackup;
			m_strDataBaseAccessMySqlPassword = m_strDataBaseAccessMySqlPasswordBackup;
		}

		public bool bDataBaseConfiguratedRight()
		{
			return(bDataBaseConfiguratedRight(true));
		}

		private bool bDataBaseConfiguratedRight(bool bLoadConfiguration)
		{
			bool bRetorno = false;
			if (bLoadConfiguration)
			{
				vCarregaDadosConfiguracao();
			}
			mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = null;
			switch(m_enumDataBaseType)
			{
				case TiposBancoDados.Jet40:
					cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_ter_TratadorErro,m_strDataBaseAccessJet40Path,m_strDataBaseAccessJet40User,m_strDataBaseAccessJet40Password);
					bRetorno = bDataAccessRight(ref cls_dba_ConnectionDB);
					break;
				case TiposBancoDados.SqlServer:
					cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_ter_TratadorErro,m_strDataBaseAccessSqlServerHost,m_strDataBaseAccessSqlServerPort,m_strDataBaseAccessSqlServerDataBaseName,m_strDataBaseAccessSqlServerUser,m_strDataBaseAccessSqlServerPassword);
					bRetorno = bDataAccessRight(ref cls_dba_ConnectionDB);
					break;

				case TiposBancoDados.MySql:
					cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strDataBaseAccessMySqlHost,m_strDataBaseAccessMySqlPort ,m_strDataBaseAccessMySqlUser,m_strDataBaseAccessMySqlPassword,m_strDataBaseAccessMySqlDataBaseName);
					bRetorno = bDataAccessRight(ref cls_dba_ConnectionDB);
					break;
			}
			return(bRetorno);
		}
		#endregion

		#region ShowDataBaseConfig
		public bool ShowDataBaseConfig()
		{
			bool bRetorno = false;
			vCarregaDadosConfiguracao();
			frmFDataBaseConfig formFDataBaseConfig = new frmFDataBaseConfig();
			InitializeFormFDataBaseConfig(ref formFDataBaseConfig);
			formFDataBaseConfig.ShowDialog();
			m_bModificado = bRetorno = formFDataBaseConfig.m_bModificado;
			return(bRetorno);
		}

		private void InitializeFormFDataBaseConfig(ref frmFDataBaseConfig formFDataBaseConfig)
		{
			// Cor
			formFDataBaseConfig.eCallCarregaCor +=new mdlDataBaseConfig.frmFDataBaseConfig.delCallCarregaCor(formFDataBaseConfig_eCallCarregaCor);

			// Carrega Base Dados
			formFDataBaseConfig.eCallCarregaBaseDados += new mdlDataBaseConfig.frmFDataBaseConfig.delCallCarregaBaseDados(formFDataBaseConfig_eCallCarregaBaseDados);

			// Change DataBase
			formFDataBaseConfig.eCallChangeDataBase += new mdlDataBaseConfig.frmFDataBaseConfig.delCallChangeDataBase(formFDataBaseConfig_eCallChangeDataBase);

			// ShowDialogConfigEspecific
			formFDataBaseConfig.eCallShowDialogConfigEspecific += new mdlDataBaseConfig.frmFDataBaseConfig.delCallShowDialogConfigEspecific(ShowDialogConfigEspecific);

			// Configurated Right
			formFDataBaseConfig.eCallDataBaseConfiguratedRight += new mdlDataBaseConfig.frmFDataBaseConfig.delCallDataBaseConfiguratedRight(formFDataBaseConfig_eCallDataBaseConfiguratedRight);

			// Salva Base Dados 
			formFDataBaseConfig.eCallSalvaBaseDados += new mdlDataBaseConfig.frmFDataBaseConfig.delCallSalvaBaseDados(formFDataBaseConfig_eCallSalvaBaseDados);
			
		}

		private System.Drawing.Color formFDataBaseConfig_eCallCarregaCor()
		{
			return(m_clrFundo);
		}

		private mdlDataBaseConfig.TiposBancoDados formFDataBaseConfig_eCallCarregaBaseDados()
		{
			return(m_enumDataBaseType);
		}	

		private void formFDataBaseConfig_eCallChangeDataBase(TiposBancoDados enumDataBaseType)
		{
			m_enumDataBaseType = enumDataBaseType;
		}

		private bool formFDataBaseConfig_eCallDataBaseConfiguratedRight()
		{
			return(bDataBaseConfiguratedRight(false));
		}

		private void formFDataBaseConfig_eCallSalvaBaseDados()
		{
			vSalvaDadosConfiguracao();
		}
		#endregion
		#region ShowDialogConfigEspecific
		private bool ShowDialogConfigEspecific()
		{
			bool bRetorno = false;
			switch (m_enumDataBaseType)
			{
				case TiposBancoDados.Jet40:
					bRetorno = ShowDialogConfigEspecificJet40();
					break;
				case TiposBancoDados.SqlServer:
					bRetorno = ShowDialogConfigEspecificSqlServer();
					break;
				case TiposBancoDados.MySql:
					bRetorno = ShowDialogConfigEspecificMySql();
					break;
			}
			return(bRetorno);
		}
		#endregion
		#region ShowDialogConfigEspecificSqlServer
			private bool ShowDialogConfigEspecificSqlServer()
			{
				bool bRetorno = true;
				frmFDataBaseConfigSqlServer formFConfigDataBaseSqlServer = new frmFDataBaseConfigSqlServer(ref m_cls_ter_TratadorErro,m_strDataBaseAccessSqlServerHost,m_strDataBaseAccessSqlServerPort,m_strDataBaseAccessSqlServerDataBaseName,m_strDataBaseAccessSqlServerUser,m_strDataBaseAccessSqlServerUser);
				InitializeEventsFormDataBaseSqlServer(ref formFConfigDataBaseSqlServer);
				formFConfigDataBaseSqlServer.ShowDialog();
				formFConfigDataBaseSqlServer = null;
				return(bRetorno); 
			}

			private void InitializeEventsFormDataBaseSqlServer(ref frmFDataBaseConfigSqlServer formFConfigDataBaseSqlServer)
			{
				// Cor 
				formFConfigDataBaseSqlServer.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigSqlServer.delCallCarregaCor(formFConfigDataBaseSqlServer_eCallCarregaCor);

				// Backup
				formFConfigDataBaseSqlServer.eCallConfigBackup +=new mdlDataBaseConfig.frmFDataBaseConfigSqlServer.delCallConfigBackup(vDataBaseConfigBackup);

				// Restore
				formFConfigDataBaseSqlServer.eCallConfigRestore += new mdlDataBaseConfig.frmFDataBaseConfigSqlServer.delCallConfigRestore(vDataBaseConfigRestore);

				// SalvaDados
				formFConfigDataBaseSqlServer.eCallSalvaDados += new mdlDataBaseConfig.frmFDataBaseConfigSqlServer.delCallSalvaDados(formFConfigDataBaseSqlServer_eCallSalvaDados);

				// Configurated Right
				formFConfigDataBaseSqlServer.eCallConfiguratedRight += new mdlDataBaseConfig.frmFDataBaseConfigSqlServer.delCallConfiguratedRight(formFConfigDataBaseSqlServer_eCallConfiguratedRight);
			}
	        
			private System.Drawing.Color formFConfigDataBaseSqlServer_eCallCarregaCor()
			{
				return (m_clrFundo);
			}

			private void formFConfigDataBaseSqlServer_eCallSalvaDados(string strHost,string strPort,string strDataBaseName,string strUser,string strPassword)
			{
				m_strDataBaseAccessSqlServerHost = strHost;
				m_strDataBaseAccessSqlServerPort = strPort;
				m_strDataBaseAccessSqlServerDataBaseName = strDataBaseName;
				m_strDataBaseAccessSqlServerUser = strUser;
				m_strDataBaseAccessSqlServerPassword = strPassword;
			}

			private bool formFConfigDataBaseSqlServer_eCallConfiguratedRight()
			{
				return(this.bDataBaseConfiguratedRight(false));
			}
		#endregion
		#region ShowDialogConfigEspecificMySql
			private bool ShowDialogConfigEspecificMySql()
			{
				bool bRetorno = true;
				frmFDataBaseConfigMySql formFConfigDataBaseMysql = new frmFDataBaseConfigMySql(ref m_cls_ter_TratadorErro,m_strDataBaseAccessMySqlHost,m_strDataBaseAccessMySqlPort,m_strDataBaseAccessMySqlDataBaseName,m_strDataBaseAccessMySqlUser,m_strDataBaseAccessMySqlUser);
				InitializeEventsFormDataBaseMySql(ref formFConfigDataBaseMysql);
				formFConfigDataBaseMysql.ShowDialog();
				formFConfigDataBaseMysql = null;
				return(bRetorno); 
			}

			private void InitializeEventsFormDataBaseMySql(ref frmFDataBaseConfigMySql formFConfigDataBaseMysql)
			{
				// Cor 
				formFConfigDataBaseMysql.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigMySql.delCallCarregaCor(formFConfigDataBaseMysql_eCallCarregaCor);

				// Backup
				formFConfigDataBaseMysql.eCallConfigBackup +=new mdlDataBaseConfig.frmFDataBaseConfigMySql.delCallConfigBackup(vDataBaseConfigBackup);

				// Restore
				formFConfigDataBaseMysql.eCallConfigRestore += new mdlDataBaseConfig.frmFDataBaseConfigMySql.delCallConfigRestore(vDataBaseConfigRestore);

				// SalvaDados
				formFConfigDataBaseMysql.eCallSalvaDados += new mdlDataBaseConfig.frmFDataBaseConfigMySql.delCallSalvaDados(formFConfigDataBaseMysql_eCallSalvaDados);

				// Configurated Right
				formFConfigDataBaseMysql.eCallConfiguratedRight += new mdlDataBaseConfig.frmFDataBaseConfigMySql.delCallConfiguratedRight(formFConfigDataBaseMysql_eCallConfiguratedRight);

			}
        
			private System.Drawing.Color formFConfigDataBaseMysql_eCallCarregaCor()
			{
				return (m_clrFundo);
			}

			private void formFConfigDataBaseMysql_eCallSalvaDados(string strHost,string strPort,string strDataBaseName,string strUser,string strPassword)
			{
				m_strDataBaseAccessMySqlHost = strHost;
				m_strDataBaseAccessMySqlPort = strPort;
				m_strDataBaseAccessMySqlDataBaseName = strDataBaseName;
				m_strDataBaseAccessMySqlUser = strUser;
				m_strDataBaseAccessMySqlPassword = strPassword;
			}

			private bool formFConfigDataBaseMysql_eCallConfiguratedRight()
			{
				return(this.bDataBaseConfiguratedRight(false));
			}
		#endregion
		#region ShowDialogConfigEspecificJet40
			private bool ShowDialogConfigEspecificJet40()
			{
				bool bRetorno = false;
				frmFDataBaseConfigJet40 formFConfigDataBaseJet40 = new frmFDataBaseConfigJet40(ref m_cls_ter_TratadorErro,m_strDataBaseAccessJet40Path,m_strDataBaseAccessJet40User,m_strDataBaseAccessJet40Password);
				vInitializeEventsFormConfigDataBaseJet40(ref formFConfigDataBaseJet40);
				formFConfigDataBaseJet40.ShowDialog();
				bRetorno = formFConfigDataBaseJet40.m_bModificado;
				formFConfigDataBaseJet40 = null;
				return(bRetorno);
			}

			private void vInitializeEventsFormConfigDataBaseJet40(ref frmFDataBaseConfigJet40 formFConfigDataBaseJet40)
			{
				// Cores
				formFConfigDataBaseJet40.eCallCarregaCor += new mdlDataBaseConfig.frmFDataBaseConfigJet40.delCallCarregaCor(formFConfigDataBaseJet40_eCallCarregaCor);

				// Backup
				formFConfigDataBaseJet40.eCallConfigBackup += new mdlDataBaseConfig.frmFDataBaseConfigJet40.delCallConfigBackup(vDataBaseConfigBackup);

				// Restore
				formFConfigDataBaseJet40.eCallConfigRestore +=new mdlDataBaseConfig.frmFDataBaseConfigJet40.delCallConfigRestore(vDataBaseConfigRestore);

				// SalvaDados
				formFConfigDataBaseJet40.eCallSalvaDados += new mdlDataBaseConfig.frmFDataBaseConfigJet40.delCallSalvaDados(formFConfigDataBaseJet40_eCallSalvaDados);

				// Configurated Right
				formFConfigDataBaseJet40.eCallConfiguratedRight += new mdlDataBaseConfig.frmFDataBaseConfigJet40.delCallConfiguratedRight(formFConfigDataBaseJet40_eCallConfiguratedRight);

			}

			private System.Drawing.Color formFConfigDataBaseJet40_eCallCarregaCor()
			{
				return(m_clrFundo);
			}

			private void formFConfigDataBaseJet40_eCallSalvaDados(string strPath,string strUser,string strPassword)
			{
				m_strDataBaseAccessJet40Path = strPath;
				m_strDataBaseAccessJet40User = strUser;
				m_strDataBaseAccessJet40Password = strPassword;
			}

			private bool formFConfigDataBaseJet40_eCallConfiguratedRight()
			{
				return(this.bDataBaseConfiguratedRight(false));
			}
		#endregion

		#region Cores 
		private void vCarregaCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
			m_clrFundo = clsPaletaCores.retornaCorAtual();
		}
		#endregion

		#region ReturnDataBaseAccess
		public void ReturnDataBaseAccess(out mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
		{
			ReturnDataBaseAccess(true,out cls_dba_ConnectionDB);
		}

		private void ReturnDataBaseAccess(bool bLoadConfiguration,out mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
		{
			mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionReturn = null;
			if (bLoadConfiguration)
			{
				vCarregaDadosConfiguracao();
			}
			switch(m_enumDataBaseType)
			{
				case TiposBancoDados.Jet40:
					cls_dba_ConnectionReturn = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_ter_TratadorErro,m_strDataBaseAccessJet40Path,m_strDataBaseAccessJet40User,m_strDataBaseAccessJet40Password);
					break;
				case TiposBancoDados.SqlServer:
					cls_dba_ConnectionReturn = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_ter_TratadorErro,m_strDataBaseAccessSqlServerHost,m_strDataBaseAccessSqlServerPort,m_strDataBaseAccessSqlServerDataBaseName,m_strDataBaseAccessSqlServerUser,m_strDataBaseAccessSqlServerPassword);
					break;
				case TiposBancoDados.MySql:
					cls_dba_ConnectionReturn = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_TratadorErro,m_strDataBaseAccessMySqlHost,m_strDataBaseAccessMySqlPort,m_strDataBaseAccessMySqlUser,m_strDataBaseAccessMySqlPassword,m_strDataBaseAccessMySqlDataBaseName);
					break;
			}
			if (m_bDevelopMode)
				cls_dba_ConnectionReturn.SystemMode = mdlDataBaseAccess.Mode.Developer;
			else
				cls_dba_ConnectionReturn.SystemMode = mdlDataBaseAccess.Mode.User;
			cls_dba_ConnectionDB = cls_dba_ConnectionReturn;
		}
		#endregion

		#region Conversao
		private string strStringToBase64(string strString)
		{
			long arrLenght = 0;
			byte[] bytDados = new byte[strString.Length];
			for(int nCont = 0; nCont < strString.Length;nCont++)
			{
				bytDados[nCont] = (byte)strString[nCont];
			}
			// Convertendo
			arrLenght = 4 * bytDados.Length;
			arrLenght /= 3;
			if ((arrLenght % 4) != 0)
				arrLenght += 4 - arrLenght % 4;
			char[] base64CharArray = new char[arrLenght];
			System.Convert.ToBase64CharArray(bytDados, 0, bytDados.Length, base64CharArray, 0);
			return (new String(base64CharArray));
		}

		private string strBase64ToString(string strStringBase64)
		{
			try
			{
				if (strStringBase64 != "")
				{
					Byte[] byDados;
					byDados = System.Convert.FromBase64CharArray(strStringBase64.ToCharArray(), 0, strStringBase64.Length);
					char[] chrDados = new char[byDados.Length];
					for(int nCont = 0; nCont < byDados.Length;nCont++)
					{
						chrDados[nCont] = (char)byDados[nCont];
					} 
					return(new System.String(chrDados));
				}
				else
				{
					return("");
				}
			}
			catch
			{
				return("");
			}
		}
		#endregion

	}
}
