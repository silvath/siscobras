using System;

namespace mdlConstantes
{
	/// <summary>
	/// Summary description for clsConstantes.
	/// </summary>
	
	public class clsConstantes
	{
		// Version 
		public const string FIELDVERSION = "STRVERSION";
		public const string CURRENTVERSION = "2005-09-20-14-00";
		public const string VERSAOTEXTO = "Versão 2.13";

		// Registry
		public const string REGISTRY_SISCOMENSAGEM_INIT = "SiscoMensagemInit";

		// MeiosTranporte
		public const int MEIOTRANSPORTE_AEREO = 1;
		public const int MEIOTRANSPORTE_MARITIMO = 2;
		public const int MEIOTRANSPORTE_RODOVIARIO = 3;
		public const int MEIOTRANSPORTE_FERROVIARIO = 4;
		public const int MEIOTRANSPORTE_CORREIO = 5;


		public static System.DateTime DATANULA = new System.DateTime(1,1,1);
		public static string DATEFORMATDEFAULT = "dd/MMM/aaaa";
		public static string DEADLINEDATEFORMATDEFAULT = "dd/MM/aaaa HH:mm";
		public static string BALLONTIP_DEFAULT_CAPTION = "Siscobras";
		public static string SHOW_BALLOONTIP_SESSAO = "SHOWBALLOONTIP";
		public static string SHOW_BALLOONTIP_VARIAVEL = "ShowBalloonTipSiscobras";
		public static string SHOW_ASSISTENTE_SESSAO = "SHOWASSISTENTE";
		public static string SHOW_ASSISTENTE_VARIAVEL = "ShowAssistenteSiscobras";
		public static string SHOW_DICAINICIAL_SESSAO = "SHOWDICAINICIAL";
		public static string SHOW_DICAINICIAL_VARIAVEL = "ShowDicaInicialSiscobras";
		public static string PREFERENCIAS = "PREFERENCIAS";
		public static string ULTIMAOPCAOPREFERENCIAS = "ULTIMAOPCAOPREFERENCIAS";
		public static string CAMPONUMEROPE = "NUMEROPE";
		public static string CAMPOIDEXPORTADOR = "IDEXPORTADOR";
		public static string CAMPOINICIARFATURAOUBIBLIOTECA = "INICIARFATURAOUBIBLIOTECA";
		public static string CAMPOINICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA = "INICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA";
		public static string CAMPOENDERECOBACKUP = "STRCAMPOENDERECOBACKUP";
		public static string CAMPOFREQUENCIABACKUP = "STRCAMPOFREQUENCIABACKUP";
		public static string CAMPOQUANTIDADEBACKUP = "STRCAMPOQUANTIDADEBACKUP";
		public static string CAMPOPERGUNTARBACKUP = "STRCAMPOPERGUNTARBACKUP";
		public static string CAMPODATAULTIMOBACKUP = "STRCAMPODATAULTIMOBACKUP";
		public static string CAMPODATAPROXIMOBACKUP = "STRCAMPODATAPROXIMOBACKUP";
		public static string CAMPOREGISTROCATEGORIA = "STRREGISTROCATEGORIA";
		public static string CAMPOIDCLIENTE = "STRIDCLIENTE";

		public static string DEFAULT_SERVIDOR = "www.siscobras.com.br";
		public static string DEFAULT_SERVICO = "SiscoWebServices";
		public static string DEFAULT_SERVIDORSERVICO = "http://www.siscobras.com.br/wbsvSiscoWebServices.asmx";

		public static string DEFAULT_SESSION_SISCOBRAS = "Siscobras";
		public static string DEFAULT_VARIABLE_BIBLIOTECA_VIEW = "Biblioteca_View";

		public static string VARIAVEL_ENTRAR_ULTIMA_CONTA = "EntrarUltimaContaUtilizada";
		public static string VARIAVEL_ENTRAR_ULTIMO_PE = "EntrarUltimoPeUtilizado";
		public static string VARIAVEL_ENTRAR_ULTIMO_DOCUMENTO = "EntrarUltimoDocumentoUtilizado";
		public static string VARIAVEL_ENTRAR_QUAL_DOCUMENTO = "EntrarQualDocumentoUtilizado";
		public static string VARIAVEL_ULTIMA_CONTA = "UltimaContaUtilizada";

		public static string DEFAULT_CONFIG_FILENAME = "Sisco.ini";

		public static double DEFAULT_PRECISAO = 0.00001;

		public const int RELATORIO_ROMANEIO_PRODUTOS = 11;
		public const int RELATORIO_ROMANEIO_VOLUMES = 25;
		public const int RELATORIO_ROMANEIO_SIMPLIFICADO = 26;
		public const int RELATORIO_ORDEM_EMBARQUE = 15;
		public const int RELATORIO_RESERVA = 27;
		public const int RELATORIO_GUIA_ENTRADA = 28;

		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS_ARREDONDAR = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS_ARREDONDAR"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS_ARREDONDAR = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS_ARREDONDAR"; 
		public const string CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR = "CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR"; 

		public const string CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL = "CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL"; 
		public const string CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL = "CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL"; 
		public const string CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR = "CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR"; 
		public const string CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR = "CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR"; 

		// SiscoMensagem
		public const string SESSION_SISCOMENSAGEM = "SiscoMensagem";
		public const string WINDOWSSERVICE_SISCOMENSAGEM_NAME = "wsSiscoMensagem";
		public const string WINDOWSSERVICE_SISCOMENSAGEM_FILENAME = "wsSiscoMensagem.exe";
		public const string APPLICATION_SISCOMENSAGEM_FILENAME = "SiscoMensagem.exe";
		public const string APPLICATION_SISCOMENSAGEM_PROCESS = "SiscoMensagem";
		public const string WINDOWSSERVICE_SISCOMENSAGEM_INIT = "wsSiscoMensagemInit";
		public const string STATE_UNKNOW = "300:Unknow";
		public const string STATE_RUNNING = "301:Running";
		public const string STATE_PAUSED = "302:Paused";
		public const string STATE_STOPED = "303:Stoped";
		public const int ID_STATE_UNKNOW = 300;
		public const int ID_STATE_RUNNING = 301;
		public const int ID_STATE_PAUSED = 302;
		public const int ID_STATE_STOPED = 303;
		
		// Commands
		public const string COMMAND_SISCOMENSAGEM_START = "/START";
		public const string COMMAND_SISCOMENSAGEM_HELP = "/HELP";
		public const string COMMAND_SISCOMENSAGEM_EXIT = "/EXIT";
		public const string COMMAND_SISCOMENSAGEM_STATE = "/STATE";
		public const string COMMAND_SISCOMENSAGEM_STOP = "/STOP";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE = "/CMSTATE";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START = "/CMSTART";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE = "/CMPAUSE";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE = "/CMCONTINUE";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP = "/CMSTOP";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE = "/CMCLOSE";
		public const string COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_UPDATE = "/CMUPDATE";
		
		// Responses
		public const string RESPONSE_SISCOMENSAGEM_ERROR_INDEFINED = "001:Unknow";
		public const string RESPONSE_SISCOMENSAGEM_ERROR_UNKNOWCOMMAND = "002:Unknow Command";
		public const string RESPONSE_SISCOMENSAGEM_ERROR_ALREDYRUNNING = "003:Alredy Running";
		public const string RESPONSE_SISCOMENSAGEM_ERROR_CANRUN = "004:Cant Run";
		public const string RESPONSE_SISCOMENSAGEM_ERROR_CANTCONNECT = "005:Cant Connect";
		public const string RESPONSE_SISCOMENSAGEM_ERROR_CONNECTIONPROBLEM = "006:Connection Problem";
		public const string RESPONSE_SISCOMENSAGEM_SUCCESS = "100:Sucess";
		
		// Schedulers
		public const int ID_SCHEDULER_DEADLINE = 1;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE = 11;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA = 12;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL = 13;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL = 14;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO = 15;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO = 16;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL = 17;
		public const int ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO = 18;
		public const int ID_SCHEDULER_CONTRATOCAMBIO = 2;
		public const int ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC = 21;
		public const int ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE = 22;
		public const int ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_COMUM = 23;
		public const int ID_SCHEDULER_PERSONALIZED = 3;

		// Contratos Cambio
		public const int ID_CONTRATOCAMBIO_ACC = 1;
		public const int ID_CONTRATOCAMBIO_ACE = 2;
		public const int ID_CONTRATOCAMBIO_COMUM = 3;

		// Preferences
		public const string FIELDNEEDSHOWPREFERENCES = "BNEEDSHOWPREFERENCES";

		#region Properties
			public static System.Windows.Forms.ImageList ListaBandeiras
			{
				get
				{
					frmFRepositorio form = new frmFRepositorio();
					return(form.ListaBandeiras);
				}
			}
		#endregion
	}
}
