using System;

namespace Siscobras
{
	/// <summary>
	/// Summary description for clsSiscobras.
	/// </summary>
	public class clsSiscobras
	{
		#region Constantes
			private const int ERROR_SYSCOTRAY_LOADED = -10;
			private const int ERROR_UPDATE_MOVING_FILE = -101;
		
			private const string SYSCOTRAY = "SyscoTray.exe";
			private const string SYSCOTRAYPARAMETERS = " /Finalize";
			private const string DATAACCESS = "mdlDataBaseAccess.dll";
			
			private const string CONSOLE_SISCOBRAS = "SISCOBRAS: ";
			private const string CONSOLE_USUARIO = "> ";
		#endregion
		#region Atributos
			private string m_strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;

			private string m_strURLPing = "http://www.siscobras.com.br/index.htm";

			private bool m_bInfo = false;
			private bool m_bHelp = false;
			private bool m_bRegistryReSend = false;
			private bool m_bRegistryKill = false;
			private string m_strVCNew = "";
			private string m_strVSNew = "";
			private string m_strProxyHost = "";
			private string m_strProxyPort = "";
			private string m_strProxyUser = "";
			private string m_strProxyPassword = "";
			private bool m_bProxy = false;
			private bool m_bInternet = false;
			private bool m_bUpdateDB = false;
			private bool m_bChangeDB = false;
			private bool m_bRestoreDB = false;
			private bool m_bDevelopMode = false;
			private bool m_bSendErrors = false;
			private bool m_bConsole = false;
			private bool m_bExit = false;
			private bool m_bSilent = false;

			private bool m_bSiscobrasStartedSiscoMensagem = false;
		#endregion
		#region Properties
		
			public bool Info
			{
				set
				{
					m_bInfo = value;
				}
			}

			public bool Help
			{
				set
				{
					m_bHelp = value;
				}
			}

			public bool RegistryReSend
			{
				set
				{
					m_bRegistryReSend = value;
				}
			}

			public bool RegistryKill
			{
				set
				{
					m_bRegistryKill = value;
				}
			}

			public bool Console
			{
				set
				{
					m_bConsole = value;
				}
			}

			public string VCNew
			{
				set
				{
					m_strVCNew = value;
				}
			}

			public string VSNew
			{
				set
				{
					m_strVSNew = value;
				}
			}

			public string ProxyHost
			{
				set
				{
					m_strProxyHost = value;
				}
			}

			public string ProxyPort
			{
				set
				{
					m_strProxyPort = value;
				}
			}

			public string ProxyUser
			{
				set
				{
					m_strProxyUser = value;
				}
			}

			public string ProxyPassword
			{
				set
				{
					m_strProxyPassword = value;
				}
			}

			public bool Proxy
			{
				set
				{
					m_bProxy = value;
				}
			}

			public bool Internet
			{
				set
				{
					m_bInternet = value;
				}
			}

			public bool UpdateDB
			{
				set
				{
					m_bUpdateDB = value;
				}
			}

			public bool ChangeDB
			{
				set
				{
					m_bChangeDB = value;
				}
			}

			public bool RestoreDB
			{
				set
				{
					m_bRestoreDB = value;
				}
			}

			public bool DevelopMode
			{
				set
				{
					m_bDevelopMode = value;
				}
			}

			public bool SendErrors
			{
				set
				{
					m_bSendErrors = value;
				}
			}

			public bool Exit
			{
				set
				{
					m_bExit = value;
				}
			}

			public bool Silent
			{
				set
				{
					m_bSilent = value;
				}
			}
		#endregion
		#region Constructor and Destructors
		public clsSiscobras()
		{
		}
		#endregion

		#region ShowDialog
		public bool ShowDialog()
		{
			bool bRetorno = false;

			// Console
			if (m_bConsole)
				vShowConsole();

			// Siscobras Executando
//			if (bSiscobrasExecutando())
//				return (false);

			mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro;
			mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB;

			// Tratamento de Erro
			bInicializaTratamentoErros(out cls_ter_TratadorErro);

			// Insere SyscoTray no Registro
			bInsereSyscoTrayRegistro();

			// Configura arquivo XML de Configuração
			if (bConfiguraArquivoXMLConfiguracao())
			{
				// Cria Banco de Dados
				if (bCriaBancoDados(ref cls_ter_TratadorErro,out cls_dba_ConnectionDB)) 
				{
					vExecutaParametros(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB);
					if (!m_bExit)
					{
						// Proxy 
						if (!m_bProxy)
							vInitializeProxy();

						// Splash
						if (bShowDialogSplash(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB))
						{
							// SiscoMensagem
							vSiscoMensagemInitialize();

							// Controladora Modulos
							ShowControladoraModulos(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB);

							// SiscoMensagem
							vSiscoMensagemFinalize();

							// Backup
							vInitializeBackup(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB);
						}
					}
					// Destroi Banco de Dados 
					DestroiBancoDados(ref cls_dba_ConnectionDB);
					bRetorno = true;
				}
			}
			return(bRetorno);
		}
		#endregion

		#region SiscobrasExecutando
			private bool bSiscobrasExecutando()
			{
				return((System.Diagnostics.Process.GetProcessesByName("Siscobras").Length > 1));
			}
		#endregion
		#region Proxy
			private void vInitializeProxy()
			{
				mdlInet.clsProxy cls_Proxy = new mdlInet.clsProxy(m_strEnderecoExecutavel);
				cls_Proxy.vSetProxy();
			}
		#endregion
		#region Tratamento de Erro
			private bool bInicializaTratamentoErros(out mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro)
			{
				cls_ter_TratadorErro = new mdlTratamentoErro.clsTratamentoErro();
				cls_ter_TratadorErro.EnderecoExecutavel = m_strEnderecoExecutavel;
				return(true);
			}
			
			private void ConfiguraTratamentoErro()
			{

			}

			private void vEnviaErros(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros cls_wbsb_SendErrors = new mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				if (cls_wbsb_SendErrors.bEnviaDados())
				{
					if (!m_bSilent)
						mdlMensagens.clsMensagens.Show("Envio Erros: Ok");
				}else{
					if (!m_bSilent)
						mdlMensagens.clsMensagens.Show("Envio Erros: Falhou/Nao havia");
				}
			}
		#endregion

		#region SyscoTray
			private bool bInsereSyscoTrayRegistro()
			{
				bool bRetorno = false;
				try
				{
					Microsoft.Win32.RegistryKey regKeyRegistro = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\RUN",true);
					if (regKeyRegistro != null)
					{
						regKeyRegistro.SetValue(SYSCOTRAY,m_strEnderecoExecutavel + SYSCOTRAY);
						bRetorno = true;
					}
				}catch{
					bRetorno = false;
				}
				return(bRetorno);
			}
		#endregion
		#region SiscoMessage
			private void vSiscoMensagemInitialize()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem cls_cws_SiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
				if (m_bSiscobrasStartedSiscoMensagem = (cls_cws_SiscoMensagem.Initialization == mdlConstantes.SiscoMensagemInit.Siscobras))
				{
					System.Threading.Thread threSiscoMensagem = new System.Threading.Thread(new System.Threading.ThreadStart(vSiscoMensagemStart));
					threSiscoMensagem.Start();
				}
			}

			private void vSiscoMensagemStart()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem cls_cws_SiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
				cls_cws_SiscoMensagem.bStart();
			}

			private void vSiscoMensagemFinalize()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem cls_cws_SiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
				if ((m_bSiscobrasStartedSiscoMensagem) && (cls_cws_SiscoMensagem.State == mdlConstantes.SiscoMensagemState.Running))
					cls_cws_SiscoMensagem.bClose();
			}
		#endregion

		#region Arquivo XML Configuração
			private bool bConfiguraArquivoXMLConfiguracao()
			{
				bool bRetorno = false;
				System.Data.DataSet dtsetArquivoConfiguracao = new System.Data.DataSet("Siscobras");
				if (System.IO.File.Exists(m_strEnderecoExecutavel + "Sisco.ini"))
				{
					try
					{
						dtsetArquivoConfiguracao.ReadXml(m_strEnderecoExecutavel + "Sisco.ini");
						bRetorno = true;
					}catch{
						if (mdlMensagens.clsMensagens.ShowQuestion(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.Siscobras_clsSiscobras_CriarNovamenteArquivoConfiguracao)) == System.Windows.Forms.DialogResult.Yes)
						{
							dtsetArquivoConfiguracao = new System.Data.DataSet("Siscobras");
							try
							{
								dtsetArquivoConfiguracao.WriteXml(m_strEnderecoExecutavel + "Sisco.ini");
								bRetorno = true;
							}
							catch
							{
								mdlMensagens.clsMensagens.ShowError(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.Siscobras_clsSiscobras_PermissaoEscritaCriacaoArquivoConfiguracao));
							}
						}
					}
				}else{
					try
					{
						dtsetArquivoConfiguracao.WriteXml(m_strEnderecoExecutavel + "Sisco.ini");
						bRetorno = true;
					}catch{
						mdlMensagens.clsMensagens.ShowError(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.Siscobras_clsSiscobras_ImpossivelCriarArquivoConfiguracao));
					}
				}
				return(bRetorno);
			}
		#endregion
		#region Banco Dados
			private bool bCriaBancoDados(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,out mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				cls_dba_ConnectionDB = null;
				bool bRetorno = false;
				// Configurada
				mdlDataBaseConfig.clsDataBaseConfig cls_dbc_Config = new mdlDataBaseConfig.clsDataBaseConfig(ref cls_ter_TratadorErro,m_strEnderecoExecutavel);
				if ((!cls_dbc_Config.bDataBaseConfigurated()) || (m_bChangeDB))
				{
					if ((m_bChangeDB) || (System.Windows.Forms.MessageBox.Show("Você precisa definir um banco de dados para o Siscobras. Deseja definí-lo agora ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
					{
						if (!cls_dbc_Config.ShowDataBaseConfig())
						{
							return(false); 
						}
					}else{
						return(false); 
					}
   				}
				// Configurada Corretamente 
				if (!cls_dbc_Config.bDataBaseConfiguratedRight())
				{
					if (System.Windows.Forms.MessageBox.Show("O Siscobras não está conseguindo acessar o banco de dados. Você precisa configurá-lo. Continuar ?","Siscobras.NET",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question,System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						if (!cls_dbc_Config.ShowDataBaseConfig())
						{
							return(false); 
						}else{
							return(false); 
						}
					}else{
						return(false); 
					}
				}
				if (cls_dbc_Config.bDataBaseConfiguratedRight())
				{
					cls_dbc_Config.ReturnDataBaseAccess(out cls_dba_ConnectionDB);
					cls_ter_TratadorErro.ConnectionDB = cls_dba_ConnectionDB;
					if (m_bDevelopMode)
						cls_dba_ConnectionDB.SystemMode = mdlDataBaseAccess.Mode.Developer;
					bRetorno = true;
				}
				return(bRetorno);
			}

			private void DestroiBancoDados(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				cls_dba_ConnectionDB = null;
			}

			private void vUpdateDataBase(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				string strOutPut = "";
				int nError = 0;
				cls_dba_ConnectionDB.ShowDialogsErrors = false;
				switch(nError = cls_dba_ConnectionDB.nUpdateDataBase())
				{
					case -1:
						strOutPut = "ERRO - CREATE TABLES" + System.Environment.NewLine + cls_dba_ConnectionDB.Erro.ToString();
						break;
					case -2:
						strOutPut = "ERRO - ALTER TABLES - ADD" + System.Environment.NewLine + cls_dba_ConnectionDB.Erro.ToString();
						break;
					default:
						strOutPut = "SUCESSO - " + nError.ToString() + " tabelas";
						break;
				}
				if (!m_bSilent)
					mdlMensagens.clsMensagens.Show(strOutPut);
				System.Console.WriteLine(strOutPut);
			}
		#endregion
		#region Splash
			private bool bShowDialogSplash(ref mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB)
			{
				bool bRetorno = false;
                mdlSplash.clsSplash cls_slp_Siscobras = new mdlSplash.clsSplash(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				cls_slp_Siscobras.ShowDialog();
				bRetorno = cls_slp_Siscobras.Habilitado;
				return(bRetorno);
			}
		#endregion
		#region Registro
		#endregion
		#region Controladora Modulos
			private void ShowControladoraModulos(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				try
				{
					mdlControladoraModulos.clsControladoraModulos cls_cnm_Controladora = new mdlControladoraModulos.clsControladoraModulos(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB,m_strEnderecoExecutavel);
					cls_cnm_Controladora.ShowDialog();
					cls_cnm_Controladora = null;
				}catch (System.Exception expErro){
					object objErro = (object)expErro;
					cls_ter_TratadorErro.trataErro(ref objErro);
				}
			}
		#endregion
		#region Backup
			private void vInitializeBackup(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				mdlBackup.clsBackup cls_bkp_Siscobras = new mdlBackup.clsBackup(ref cls_ter_TratadorErro,ref cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				cls_bkp_Siscobras.criaBackupSeNecessario();
				cls_bkp_Siscobras = null;
			}
		#endregion

		#region Parametros
			private void vExecutaParametros(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				// Help 
				if (m_bHelp)
				{
					string strOutput = "        Siscobras HELP      ";
					strOutput += System.Environment.NewLine + "/HELP : Esta janela.";
					strOutput += System.Environment.NewLine + "/INFO : Informações do Sistema.";
					strOutput += System.Environment.NewLine + "/SENDERRORS : Força envio dos erros para os webservices.";
					strOutput += System.Environment.NewLine + "/UPDATEDB : Força a atualização do Banco de dados.";
					strOutput += System.Environment.NewLine + "/VC:<VersaoCliente> : Modifica a versao do Cliente.";
					strOutput += System.Environment.NewLine + "/VS:<VersaoServidor> : Modifica a versao do Servidor.";
					strOutput += System.Environment.NewLine + "/UPDATEDB : Força a atualização do Banco de dados.";
					strOutput += System.Environment.NewLine + "/REGISTRYRESEND : Força o reenvio dos dados do registro.";
					strOutput += System.Environment.NewLine + "/REGISTRYKILL : Apaga os dados do registro do Banco de Dados.";
					strOutput += System.Environment.NewLine + "/PROXY : Modifica configurações do proxy.";
					strOutput += System.Environment.NewLine + "/SILENT : Realiza a operacao sem saida.";
					strOutput += System.Environment.NewLine + "/EXIT : Apenas executa os parametros.";
					System.Windows.Forms.MessageBox.Show(strOutput);
					this.Exit = true;
				}

				// Versao Cliente
				if (m_strVCNew != "")
				{
					mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
					cls_ini_File.colocaValor("Siscobras","VersaoCliente",m_strVCNew);
				}

				// Versao Servidor 
				if (m_strVSNew != "")
				{
					cls_dba_ConnectionDB.SetConfiguracao("STRVERSION",m_strVSNew);
				}

				// Proxy
				if (m_bProxy)
				{
					mdlInet.clsProxy obj = new mdlInet.clsProxy();
					obj.vSetProxy(m_strProxyHost,m_strProxyPort,m_strProxyUser,m_strProxyPassword);
				}

				// Internet
				if (m_bInternet)
				{
					string strProxy = "";
					if (m_bProxy)
						strProxy = "Ativado";
					else
						strProxy = "Desativado";
					string strOutput = "             Internet    ";
					strOutput += System.Environment.NewLine + "****************************";
					strOutput += System.Environment.NewLine + "Proxy: " + strProxy;
					strOutput += System.Environment.NewLine + "Host: " + m_strProxyHost;
					strOutput += System.Environment.NewLine + "Port: " + m_strProxyPort;
					strOutput += System.Environment.NewLine + "User: " + m_strProxyUser;
					strOutput += System.Environment.NewLine + "Password: " + m_strProxyPassword;
					strOutput += System.Environment.NewLine + "****************************";
					strOutput += System.Environment.NewLine + "Internet: ";
					int nTime;
					if (mdlInet.clsPing.PingHostHttp(m_strURLPing,out nTime) == mdlInet.clsPing.ICMPErrors.ERROR_NONE)
						strOutput += "Ativada";
					else
						strOutput += "Desativada";
					strOutput += System.Environment.NewLine + "Tempo = " + nTime.ToString();
					strOutput += System.Environment.NewLine + "****************************";
					System.Windows.Forms.MessageBox.Show(strOutput);
				}

				// Registro Re Enviar 
				if (m_bRegistryReSend)
				{
					cls_dba_ConnectionDB.SetConfiguracao("BREGISTRODADOSCADASTROENVIADOS","False");
				}

				// Registro Apagar 
				if (m_bRegistryKill)
				{
					cls_dba_ConnectionDB.SetConfiguracao("STRIDCLIENTE","");
					cls_dba_ConnectionDB.SetConfiguracao("STRREGISTROCATEGORIA","");
				}

				// Info
				if (m_bInfo)
				{
					string strOutput = "        Siscobras INFO        ";
					mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
					string strVersaoCliente = cls_ini_File.retornaValor("Siscobras","VersaoCliente","");
					string strVersaoServidor = cls_dba_ConnectionDB.GetConfiguracao("STRVERSION","");
					strOutput += System.Environment.NewLine + "Versão Cliente : " + strVersaoCliente;
					strOutput += System.Environment.NewLine + "Versão Servidor : " + strVersaoServidor;
					System.Windows.Forms.MessageBox.Show(strOutput);
					this.Exit = true;
				}

				// Envia Erros
				if (m_bSendErrors)
				{
					vEnviaErros(ref cls_ter_tratadorErro,ref  cls_dba_ConnectionDB);
				}

				// Atualizacao banco dados 
				if (m_bUpdateDB)
				{
					vUpdateDataBase(ref  cls_dba_ConnectionDB);
					if ((m_bSilent) && (m_bExit))
						cls_dba_ConnectionDB.SetConfiguracao(mdlConstantes.clsConstantes.FIELDNEEDSHOWPREFERENCES,true.ToString());
				}

				// Restore DataBase
				if (m_bRestoreDB)
				{
					mdlBackup.clsBackupRestore objBackupRestore = new mdlBackup.clsBackupRestore(ref cls_ter_tratadorErro,ref cls_dba_ConnectionDB,m_strEnderecoExecutavel);
					objBackupRestore.ShowDialog();
				}
			}
		#endregion

		#region Console
			private void vShowConsole()
			{
				frmFConsole formFConsole = new frmFConsole();
				vInitializeEvents(ref formFConsole);
				formFConsole.ShowDialog();
				System.Environment.Exit(0);
			}

			private void vInitializeEvents(ref frmFConsole formFConsole)
			{
				// Execute Command 
				formFConsole.eCallExecuteCommand +=new Siscobras.frmFConsole.delCallExecuteCommand(strExecuteCommand);
			}

			private string strExecuteCommand(ref frmFConsole Sender,string strCommand)
			{
				string strRetorno = CONSOLE_USUARIO + strCommand + System.Environment.NewLine;
				string[] strCommandSplit = strCommand.ToUpper().Trim().Split(null);
				switch(strCommandSplit[0])
				{
					case "INIT":
						strRetorno = strCommandInit();
						break;
					case "CLEAR":
						Sender.vClear();
						strRetorno = "";
						break;
					case "DB":
						strRetorno += strCommandDb(strCommandSplit);
						break;
					case "PROXY":
						strRetorno += strCommandProxy(strCommandSplit);
						break;
					case "SEND":
						strRetorno += strCommandSend(strCommandSplit);
						break;
					case "REGISTRY":
						strRetorno += strCommandRegistry(strCommandSplit);
						break;
					case "STATUS":
						strRetorno += strCommandStatus(strCommandSplit);
						break;
					case "START":
						strRetorno += strCommandStart(strCommandSplit);
						break;
					case "STOP":
						strRetorno += strCommandStop(strCommandSplit);
						break;
					case "SET":
						strRetorno += strCommandSet(strCommandSplit);
						break;
					case "QUIT":
					case "EXIT":
						vCommandExit();
						break;
					case "HELP":
						strRetorno += strCommandHelp(strCommandSplit);
						break;
					default:
						strRetorno += "Comando Inválido" + System.Environment.NewLine;
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Commands
			#region HELP
				private string strCommandHelp(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "DB":
								strRetorno = strCommandHelpDb();
								break;
							case "SEND":
								strRetorno = strCommandHelpSend();
								break;
							case "STATUS":
								strRetorno = strCommandHelpStatus();
								break;
							case "START":
								strRetorno = strCommandHelpStart();
								break;
							case "STOP":
								strRetorno = strCommandHelpStop();
								break;
							case "SQL":
								strRetorno = strCommandHelpSql();
								break;
							case "SET":
								strRetorno = strCommandHelpSet();
								break;
							case "REGISTRY":
								strRetorno = strCommandHelpRegistry();
								break;
							default:
								strRetorno = strCommandHelpGeral();
								break;
						}

					}else{
						strRetorno = strCommandHelpGeral();
					}
					return(strRetorno);
				}

				private string strCommandHelpGeral()
				{
					string strRetorno = "";
					strRetorno += "-------------Help-------------";
					strRetorno += System.Environment.NewLine + " HELP - Este menu";
					strRetorno += System.Environment.NewLine + "      Operacional";
					strRetorno += System.Environment.NewLine + " CLEAR - Limpa a Tela";
					strRetorno += System.Environment.NewLine + "      Sistema";
					strRetorno += System.Environment.NewLine + " REGISTRY - Registro do Siscobras";
					strRetorno += System.Environment.NewLine + " SEND - Envio de Dados";
					strRetorno += System.Environment.NewLine + " STATUS - Estado dos objetos";
					strRetorno += System.Environment.NewLine + " START - Inicia os objetos";
					strRetorno += System.Environment.NewLine + " STOP - Para os objetos";
					strRetorno += System.Environment.NewLine + " SET - Ajusta os objetos";
					strRetorno += System.Environment.NewLine + " BD - Banco de Dados";
					strRetorno += System.Environment.NewLine + " QUIT - Sair do Console";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpDb()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Bd -------------";
					strRetorno += System.Environment.NewLine + " DB - Banco de Dados";
					strRetorno += System.Environment.NewLine + "Sintaxe: DB action";
					strRetorno += System.Environment.NewLine + "action = Ação a ser executada no registro";
					strRetorno += System.Environment.NewLine + "(UPDATE | SQL)";
					strRetorno += System.Environment.NewLine + "Ex.: DB UPDATE";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpProxy()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Proxy -------------";
					strRetorno += System.Environment.NewLine + " PROXY - Proxy da conexao Internet";
					strRetorno += System.Environment.NewLine + "Sintaxe: PROXY action";
					strRetorno += System.Environment.NewLine + "action = Ação a ser executada no proxy";
					strRetorno += System.Environment.NewLine + "(USE | DONTUSE | HOST | PORT | USER | PASSWORD)";
					strRetorno += System.Environment.NewLine + "Ex.: DB UPDATE";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpRegistry()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Registry -------------";
					strRetorno += System.Environment.NewLine + " REGISTRY - Registro";
					strRetorno += System.Environment.NewLine + "Sintaxe: REGISTRY action";
					strRetorno += System.Environment.NewLine + "action = Ação a ser executada no registro";
					strRetorno += System.Environment.NewLine + "(KILL | RESEND)";
					strRetorno += System.Environment.NewLine + "Ex.: REGISTRY KILL";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpSend()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Send -------------";
					strRetorno += System.Environment.NewLine + " SEND - Envio de Dados";
					strRetorno += System.Environment.NewLine + "Sintaxe: SEND action";
					strRetorno += System.Environment.NewLine + "action = Ação de envio a ser executada";
					strRetorno += System.Environment.NewLine + "(ERRORS)";
					strRetorno += System.Environment.NewLine + "Ex.: SEND ERRORS";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}


				private string strCommandHelpStatus()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Status -------------";
					strRetorno += System.Environment.NewLine + " STATUS - Status Geral do Siscobras";
					strRetorno += System.Environment.NewLine + "Sintaxe: STATUS (obj)";
					strRetorno += System.Environment.NewLine + "obj = Objeto que sera obtido status";
					strRetorno += System.Environment.NewLine + "(SISCOBRAS | REGISTRY | INTERNET | PROXY)";
					strRetorno += System.Environment.NewLine + "Ex.: START SISCOBRAS";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpStart()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Start -------------";
					strRetorno += System.Environment.NewLine + " START - Inicia objetos";
					strRetorno += System.Environment.NewLine + "Sintaxe: START obj";
					strRetorno += System.Environment.NewLine + "obj = Objeto que sera iniciado";
					strRetorno += System.Environment.NewLine + "(TRATADORRERRO | CONEXAOBD | ALL)";
					strRetorno += System.Environment.NewLine + "Ex.: START TRATADORRERRO";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpStop()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Stop -------------";
					strRetorno += System.Environment.NewLine + " STOP - Para objetos";
					strRetorno += System.Environment.NewLine + "Sintaxe: STOP obj";
					strRetorno += System.Environment.NewLine + "obj = Objeto que sera iniciado";
					strRetorno += System.Environment.NewLine + "(TRATADORRERRO | CONEXAOBD | ALL)";
					strRetorno += System.Environment.NewLine + "Ex.: STOP TRATADORRERRO";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpSet()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Set -------------";
					strRetorno += System.Environment.NewLine + " SET - Para objetos";
					strRetorno += System.Environment.NewLine + "Sintaxe: SET obj valor";
					strRetorno += System.Environment.NewLine + "obj = Objeto que sera setado";
					strRetorno += System.Environment.NewLine + "(VC | VS)";
					strRetorno += System.Environment.NewLine + "Ex.: SET VC 2002-12-01-20-55";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandHelpSql()
				{
					string strRetorno = "";
					strRetorno += "-------------Help Sql -------------";
					strRetorno += System.Environment.NewLine + " SQL - Executa SQL";
					strRetorno += System.Environment.NewLine + "Sintaxe: SQL comando";
					strRetorno += System.Environment.NewLine + "comando = Comando sql que sera enviado ao banco de dados";
					strRetorno += System.Environment.NewLine + "Ex.: SQL SELECT * FROM tbExportadores";
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}
			#endregion
			#region INIT
				private string strCommandInit()
				{
					string strRetorno = "";
					strRetorno += "-------------- Console : Siscobras Exporta Fácil --------------";
					strRetorno += System.Environment.NewLine + " E-mail: suporte@siscobras.com.br";
					strRetorno += System.Environment.NewLine + " Telefone: (48)3028-2244";
					return(strRetorno);
				}
			#endregion
			#region BD
				private string strCommandDb(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch (strCommandArgs[1])
						{
							case "UPDATE":
								strRetorno = strCommandBDUpdate();
								break;
							case "SQL":
								if (strCommandArgs.Length > 2)
								{
									string strCommand = "";
									for(int i = 2;i <  strCommandArgs.Length; i++)
									{
										strCommand += strCommandArgs[i].ToString() + " ";
									}
									strRetorno = strCommandBDSql(strCommand);
								}else{
									strRetorno = strCommandHelpSql();
								}
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpDb();
					}
					return(strRetorno);
				}

				private string strCommandBDUpdate()
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB == null)
					{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					else
					{
						int nTableNumber = m_cls_dba_ConnectionDB.nUpdateDataBase();
						if (nTableNumber > 0)
						{
							strRetorno = "OK :" + nTableNumber.ToString() + " tabelas atuais";
						}else{
							strRetorno = "ERRO: UPDATEDB FALHOU";
						}
					}
					return(strRetorno);
				}

				private string strCommandBDSql(string strCommando)
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB == null)
					{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					else
					{
						System.Data.DataTable dttbDados = m_cls_dba_ConnectionDB.dttbExecuteSql(strCommando);
						if (m_cls_dba_ConnectionDB.Erro != null)
						{
							strRetorno = m_cls_dba_ConnectionDB.Erro.ToString();
						}else{
							if (dttbDados == null)
							{
								strRetorno = "OK (IUD)";
							}else{
								strRetorno += System.Environment.NewLine + "----------------------------------";
								strRetorno = System.Environment.NewLine + "COLUNAS" + System.Environment.NewLine;
								strRetorno += "----------------------------------" + System.Environment.NewLine;
								// Colunas
								foreach(System.Data.DataColumn dtclColuna in dttbDados.Columns)
								{
									strRetorno += dtclColuna.ColumnName + " | ";
								}
								// Dados
								strRetorno += System.Environment.NewLine + "----------------------------------";
								strRetorno += System.Environment.NewLine + "DADOS";
								strRetorno += System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine;
								foreach(System.Data.DataRow dtrwDado in dttbDados.Rows)
								{
									foreach(System.Data.DataColumn dtclColuna in dttbDados.Columns)
									{
										strRetorno += dtrwDado[dtclColuna].ToString() + " | ";
									}
									strRetorno += System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine;
								}
							}
						}
					}
					return(strRetorno);
				}
			#endregion
			#region PROXY
				private string strCommandProxy(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch (strCommandArgs[1])
						{
							case "USE":
								strRetorno = strCommandProxyUse();
								break;
							case "DONTUSE":
								strRetorno = strCommandProxyDontUse();
								break;
							case "HOST":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandProxyHost(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpProxy();
								break;
							case "PORT":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandProxyPort(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpProxy();
								break;
							case "USER":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandProxyUser(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpProxy();
								break;
							case "PASSWORD":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandProxyPassword(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpProxy();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpProxy();
					}
					return(strRetorno);
				}

				private string strCommandProxyUse()
				{
					m_bProxy = true;
					mdlInet.clsProxy obj = new mdlInet.clsProxy();
					obj.vSetProxy(m_strProxyHost,m_strProxyPort,m_strProxyUser,m_strProxyPassword);
					return("Ok");
				} 

				private string strCommandProxyDontUse()
				{
					m_bProxy = false;
					System.Net.GlobalProxySelection.Select = System.Net.GlobalProxySelection.GetEmptyWebProxy();
					return("Ok");
				} 

				private string strCommandProxyHost(string strHost)
				{
					m_strProxyHost = strHost;
					return("Ok");
				}

				private string strCommandProxyPort(string strPort)
				{
					m_strProxyPort = strPort;
					return("Ok");
				}

				private string strCommandProxyUser(string strUser)
				{
					m_strProxyUser = strUser;
					return("Ok");
				}

				private string strCommandProxyPassword(string strPassword)
				{
					m_strProxyPassword = strPassword;
					return("Ok");
				}
			#endregion
			#region REGISTRY
				private string strCommandRegistry(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "KILL":
								strRetorno = strCommandRegistryKill();
								break;
							case "RESEND":
								strRetorno = strCommandRegistryReSend();
								break;
							default:
								strRetorno = strCommandHelpRegistry();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpRegistry();
					}
					return(strRetorno);
				}

				private string strCommandRegistryKill()
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB != null)
					{
						m_cls_dba_ConnectionDB.SetConfiguracao("STRIDCLIENTE","");
						m_cls_dba_ConnectionDB.SetConfiguracao("STRREGISTROCATEGORIA","");
						strRetorno = "OK";
					}
					else
					{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					return(strRetorno);
				}

				private string strCommandRegistryReSend()
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB != null)
					{
						m_cls_dba_ConnectionDB.SetConfiguracao("BREGISTRODADOSCADASTROENVIADOS","False");
						strRetorno = "OK";
					}
					else
					{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					return(strRetorno);
				}
			#endregion
			#region SEND 
				private string strCommandSend(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "ERRORS":
								strRetorno = strCommandSendErrors();
								break;
							default:
								strRetorno = strCommandHelpSend();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpSend();
					}
					return(strRetorno);
				}

				private string strCommandSendErrors()
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB != null)
					{
						if (m_cls_ter_TratadorErro != null)
						{
							mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros cls_wbsb_SendErrors = new mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
							if (cls_wbsb_SendErrors.bEnviaDados())
							{
								strRetorno = "OK";
							}
							else
							{
								strRetorno = "ERRO: Envio dos erros";
							}
						}else{
							strRetorno = "ERRO: TRATADORERRO não inicializado";
						}
					}else{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					return(strRetorno);
				}
			#endregion
			#region STATUS
				private string strCommandStatus(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "SISCOBRAS":
								strRetorno = strCommandStatusSiscobras();
								break;
							case "REGISTRY":
								strRetorno = strCommandStatusRegistry();
								break;
							case "INTERNET":
								strRetorno = strCommandStatusInternet();
								break;
							case "PROXY":
								strRetorno = strCommandStatusProxy();
								break;
							default:
								strRetorno = strCommandStatusGeral();
								break;
						}
					}else{
						strRetorno = strCommandStatusGeral();
					}
					return(strRetorno);
				}

				private string strCommandStatusGeral()
				{
					string strRetorno = "";
					// Arquivo Configuracao
					string strConfigFile = "Não";
					string strConfigFileStatus = "Não";
					if (System.IO.File.Exists(m_strEnderecoExecutavel + "Sisco.ini"))
					{
						strConfigFile = "Sim";
						try
						{
							System.Data.DataSet dtstTemp = new System.Data.DataSet();
							dtstTemp.ReadXml(m_strEnderecoExecutavel + "Sisco.ini");
							strConfigFileStatus = "Sim";
						}catch{
							strConfigFileStatus = "Não";
						}
					}
                    
					// Tratador Erro
					string strTratadorErro = "";
					if (m_cls_ter_TratadorErro == null)
						strTratadorErro = "Nulo";
					else
						strTratadorErro = "Instanciado";
					// Conexao BD 
					string strConexaoBD = "";
					if (m_cls_dba_ConnectionDB == null)
						strConexaoBD = "Nulo";
					else
						strConexaoBD = "Instanciado";
					strRetorno += "-------------Status-------------";
					strRetorno += System.Environment.NewLine + " ENDERECOEXECUTAVEL -> " + m_strEnderecoExecutavel;
					strRetorno += System.Environment.NewLine + " CONFIG_FILE_EXISTE -> " + strConfigFile;
					strRetorno += System.Environment.NewLine + " CONFIG_FILE_VALIDO -> " + strConfigFileStatus;
					strRetorno += System.Environment.NewLine + " TRATADORERRO -> " + strTratadorErro;
					strRetorno += System.Environment.NewLine + " CONEXAOBD -> " + strConexaoBD;
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandStatusRegistry()
				{
					string strRetorno = "";
					string strIdCliente = "";
					string strRegistroCategoria = "";
					string strDadosCadastroEnviados = "Não";
					
					if (m_cls_dba_ConnectionDB != null)
					{
						strIdCliente = m_cls_dba_ConnectionDB.GetConfiguracao("STRIDCLIENTE","");
						strRegistroCategoria = m_cls_dba_ConnectionDB.GetConfiguracao("STRREGISTROCATEGORIA","");
						if (m_cls_dba_ConnectionDB.GetConfiguracao("BREGISTRODADOSCADASTROENVIADOS",false))
							strDadosCadastroEnviados = "Sim";
					}else{
						strIdCliente = "CONEXAOBD NÃO INICIALIZADA"; 
						strRegistroCategoria = "CONEXAOBD NÃO INICIALIZADA"; 
						strDadosCadastroEnviados = "CONEXAOBD NÃO INICIALIZADA"; 
					}

					strRetorno += "-------------Status Registry -------------";
					strRetorno += System.Environment.NewLine + " Cliente -> " + strIdCliente;
					strRetorno += System.Environment.NewLine + " Categoria -> " + strRegistroCategoria;
					strRetorno += System.Environment.NewLine + " Dados Enviados -> " + strDadosCadastroEnviados;
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandStatusSiscobras()
				{
					string strRetorno = "";
					string strVersaoCliente = "";
					string strVersaoServidor = "";

					try
					{
						mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
						strVersaoCliente = cls_ini_File.retornaValor("Siscobras","VersaoCliente","");
					}catch{
						strVersaoCliente = "ARQUIVO CONFIGURAÇÃO INVÁLIDO";
					}
					if (m_cls_dba_ConnectionDB != null)
					{
						strVersaoServidor = m_cls_dba_ConnectionDB.GetConfiguracao("STRVERSION","");
					}else{
						strVersaoServidor = "CONEXAOBD NÃO INICIALIZADA"; 
					}

					strRetorno += "-------------Status Siscobras -------------";
					strRetorno += System.Environment.NewLine + " Versão Cliente -> " + strVersaoCliente;
					strRetorno += System.Environment.NewLine + " Versão Servidor -> " + strVersaoServidor;
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandStatusInternet()
				{
					string strRetorno = "";
					string strInternet = "";
					int nTime = 0;
					if (mdlInet.clsPing.PingHostHttp(m_strURLPing,out nTime) == mdlInet.clsPing.ICMPErrors.ERROR_NONE)
						strInternet = "Ativada";
					else
						strInternet = "Desativada";

					strRetorno += "-------------Status Internet -------------";
					strRetorno += System.Environment.NewLine + " Conexão: " + strInternet;
					strRetorno += System.Environment.NewLine + " Tempo Conexão: " + nTime.ToString();
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

				private string strCommandStatusProxy()
				{
					string strRetorno = "";
					string strProxy = "";
					if (m_bProxy)
						strProxy = "Ativado";
					else
						strProxy = "Desativado";
					strRetorno += "-------------Status Proxy -------------";
					strRetorno += System.Environment.NewLine + " Proxy: " + strProxy;
					strRetorno += System.Environment.NewLine + " Host: " + m_strProxyHost;
					strRetorno += System.Environment.NewLine + " Port: " + m_strProxyPort;
					strRetorno += System.Environment.NewLine + " User: " + m_strProxyUser;
					strRetorno += System.Environment.NewLine + " Password: " + m_strProxyPassword;
					strRetorno += System.Environment.NewLine + "----------------------------------";
					return(strRetorno);
				}

			#endregion
			#region START
				private string strCommandStart(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "TRATADORERRO":
								strRetorno = strCommandStartTratadorErro();
								break;
							case "CONEXAOBD":
								strRetorno = strCommandStartConexaoBD();
								break;
							case "ALL":
								strRetorno = "TRATADORERRO: " + strCommandStartTratadorErro();
								strRetorno += System.Environment.NewLine + "CONEXAOBD: " + strCommandStartConexaoBD();
								break;
							default:
								strRetorno = strCommandHelpStart();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpStart();
					}
					return(strRetorno);
				}

				private string strCommandStartTratadorErro()
				{
					string strRetorno = "";
					if (bInicializaTratamentoErros(out m_cls_ter_TratadorErro))
					{
						strRetorno = "START";
						if (m_cls_dba_ConnectionDB != null)
							m_cls_ter_TratadorErro.ConnectionDB = m_cls_dba_ConnectionDB;
					}else{
						strRetorno = "Error";
					}
					return(strRetorno);
				}

				private string strCommandStartConexaoBD()
				{
					string strRetorno = "";
					if (bCriaBancoDados(ref m_cls_ter_TratadorErro,out m_cls_dba_ConnectionDB))
					{
						strRetorno = "START";
					}
					else
					{
						strRetorno = "Error";
					}
					return(strRetorno);
				}
			#endregion
			#region STOP
				private string strCommandStop(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "TRATADORERRO":
								strRetorno = strCommandStopTratadorErro();
								break;
							case "CONEXAOBD":
								strRetorno = strCommandStopConexaoBD();
								break;
							case "ALL":
								strRetorno = "TRATADORERRO: " + strCommandStopTratadorErro();
								strRetorno += System.Environment.NewLine + "CONEXAOBD: " + strCommandStopConexaoBD();
								break;
							default:
								strRetorno = strCommandHelpStop();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpStop();
					}
					return(strRetorno);
				}

				private string strCommandStopTratadorErro()
				{
					string strRetorno = "";
					m_cls_ter_TratadorErro = null;
					strRetorno = "STOP";
					return(strRetorno);
				}

				private string strCommandStopConexaoBD()
				{
					string strRetorno = "";
					m_cls_dba_ConnectionDB = null;
					strRetorno = "STOP";
					return(strRetorno);
				}
			#endregion
			#region SET
				private string strCommandSet(string[] strCommandArgs)
				{
					string strRetorno = "";
					if (strCommandArgs.Length > 1)
					{
						switch(strCommandArgs[1])
						{
							case "VC":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandSetVC(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpSet();
								break;
							case "VS":
								if (strCommandArgs.Length > 2)
									strRetorno = strCommandSetVS(strCommandArgs[2]);
								else
									strRetorno = strCommandHelpSet();
								break;
							default:
								strRetorno = strCommandHelpSet();
								break;
						}
					}
					else
					{
						strRetorno = strCommandHelpSet();
					}
					return(strRetorno);
				}

				private string strCommandSetVC(string strVersao)
				{
					string strRetorno = "";
					try
					{
						mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
						cls_ini_File.colocaValor("Siscobras","VersaoCliente",strVersao);
						strRetorno = "OK";
					}catch{
						strRetorno = "ERRO: Falha na atualização da versao do cliente";
					}
					return(strRetorno);
				}

				private string strCommandSetVS(string strVersao)
				{
					string strRetorno = "";
					if (m_cls_dba_ConnectionDB != null)
					{
						m_cls_dba_ConnectionDB.SetConfiguracao("STRVERSION",strVersao);
						strRetorno = "OK";
					}else{
						strRetorno = "ERRO: CONEXAOBD não inicializada";
					}
					return(strRetorno);
				}
			#endregion
			#region EXIT
				private void vCommandExit()
				{
					System.Environment.Exit(0);
				}
			#endregion
		#endregion
	}
}

