using System;
using mdlControladoraWindowsServices;

namespace mdlControladoraMensagens
{
	#region Enums
		internal enum Time
		{
			Dia,
			Hora,
			Minuto
		}

		public enum Intervalo
		{
			Dia = 1,
			Semana = 2,
			Mes = 3,
			Ano = 4,
			Tudo = 5
		}
	#endregion

	/// <summary>
	/// Summary description for clsControladoraMensagens.
	/// </summary>
	public class clsControladoraMensagens
	{
		#region Static
			#region Atributes
				private static System.Drawing.Color m_clrBackColor = System.Drawing.Color.AliceBlue;
				private static System.Threading.Mutex ms_Mutex = new System.Threading.Mutex();
			#endregion
			#region Properties
				internal static System.Drawing.Color BackColor
				{
					get
					{
						return(m_clrBackColor);
					}
				}
			#endregion
			#region Time
				internal static Time enumNextTime(Time enumTime)
				{
					Time enumReturn = Time.Dia;
					switch(enumTime)
					{
						case Time.Dia:
							enumReturn = Time.Hora;
							break;
						case Time.Hora:
							enumReturn = Time.Minuto;
							break;
						case Time.Minuto:
							enumReturn = Time.Dia;
							break;
					}
					return(enumReturn);
				}
		
				internal static string strTextTime(Time enumTime)
				{
					string strReturn = "";
					switch(enumTime)
					{
						case Time.Dia:
							strReturn = "dia(s)";
							break;
						case Time.Hora:
							strReturn = "hora(s)";
							break;
						case Time.Minuto:
							strReturn = "minuto(s)";
							break;
					}
					return(strReturn);
				}

				internal static double dConvertTime(Time enumTimeBefore,Time enumTimeAfter,double dValue)
				{
					double dReturn = dValue;

					//Converting to Minutes
					switch(enumTimeBefore)
					{
						case Time.Dia:
							dReturn = dValue * 60 * 24;
							break;
						case Time.Hora:
							dReturn = dValue * 60;
							break;
					}

					// Converting Minutes to Output Unit
					switch(enumTimeAfter)
					{
						case Time.Dia:
							dReturn  = ((dReturn / 60) / 24);
							break;
						case Time.Hora:
							dReturn  = (dReturn / 60);
							break;
					}
					return(dReturn);
				}
			#endregion
		#endregion
		#region Singleton
			public static bool bExists()
			{
				return(m_Instance != null);
			}
							 

			public static clsControladoraMensagens New()
			{
				if (m_Instance == null)
				{
					m_Instance = new clsControladoraMensagens();
					if (m_Instance.m_cls_dba_ConnectionDB == null)
						m_Instance = null;
				}
				return(m_Instance);
			}

			public static clsControladoraMensagens New(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				if (m_Instance == null)
				{
					// Creating the Singleton
					m_Instance = new clsControladoraMensagens(ref cls_dba_ConnectionDB);
				}
				// Returning the instance 
				return(m_Instance);
			}
		#endregion

		#region Delegates
			public delegate void delCallMessageLog(string strLog);
			public delegate void delCallClose();
		#endregion
		#region Events
			public event delCallMessageLog eCallMessageLog;
			public event delCallClose eCallClose;
		#endregion
		#region Events Methods
			protected virtual void OnCallMessageLog(string strLog)
			{
				if ((eCallMessageLog != null) && (m_bLogDelegate))
					eCallMessageLog(strLog);
			}

			protected virtual void OnCallClose()
			{
				m_bRunning = false;
				m_bPaused = false;
				if ((eCallClose != null))
					eCallClose();
				m_bCloseApp = true;
			}
		#endregion

		#region Constants
			internal const int DATE_SCHEDULER_IMAGE = 1;
			internal const int CONTRATOCAMBIO_SCHEDULER_IMAGE = 2;
			internal const int PERSONALIZED_SCHEDULER_IMAGE = 3;

			internal const int SESSION_MAIN = 0;
			internal const int SESSION_DEADLINES = 1;
			internal const int SESSION_CONTRATOSCAMBIO = 2;
			internal const int SESSION_PERSONALIZED = 3;

			internal const string SCHEDULER_CONTRATOCAMBIO_NAME = "Contrato Câmbio";
			internal const string SCHEDULER_DEADLINE_NAME = "Deadlines";
			internal const string SCHEDULER_PERSONALIZED_NAME = "Personalizadas";

			public const string TAG_DATA_DIA = "[DIA]";
			public const string TAG_DATA_MES = "[MES]";
			public const string TAG_DATA_ANO = "[ANO]";
			public const string TAG_DATA_HORA = "[HORA]";
			public const string TAG_DATA_MINUTO = "[MINUTO]";
			public const string TAG_DATA_SEGUNDO = "[SEGUNDO]";
			public const string TAG_EXPORTADOR_NOME = "[EXPORTADOR]";
			public const string TAG_PROCESSO_NUMERO = "[PE]";
			public const string TAG_PROCESSO_NAVIO = "[NAVIO]";
			public const string TAG_CONTRATOCAMBIO_NUMERO = "[CONTRATOCAMBIO]";
			public const string TAG_OUTRO_DEADLINE = "[OUTRO]";
		#endregion
		#region Atributes
			private static clsControladoraMensagens m_Instance = null;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private string m_strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";

			private Forms.frmMain m_formMain = null;
			private bool m_bShowSystemTray = true;

			private System.Threading.Thread m_thr_Messages = null;

			private double m_dMinutesWaitingTime = 60d;
			private int m_nSecondsTimeToShow = 1000;
			private int m_nSecondsTimeToStay = 5000;
			private int m_nSecondsTimeToHide = 1000;
			private double m_dMinutesRemark = 5d;

			// Flags
			private bool m_bRunning = false;
			private bool m_bPaused = false;
			private bool m_bStop = false;
			private bool m_bClose = false;
			private bool m_bCloseApp = false;

			// Logs
			private bool m_bLogDelegate = false;
			private bool m_bLogFile = false;
			private string m_strPathLog = System.Environment.CurrentDirectory + "\\clsControladoraMensagens.log";

			// Forms
			private Forms.frmMessages m_formMessages;
			private Forms.frmConfig m_formConfig;
			private Forms.frmMessage m_formMessage;

			// Scheduler Date 
			private bool m_bSchedulerDeadlineEnabled = true;
			private clsSchedulerDates m_cls_sch_Dates = null;
			private System.Drawing.Color m_clrSchedulerDate = System.Drawing.Color.FromArgb(15,96,202);

			// Scheduler Contrato Cambio
			private bool m_bSchedulerContatoCambioEnabled = true;
			private clsSchedulerContratosCambio m_cls_sch_ContratosCambio = null;
			private System.Drawing.Color m_clrSchedulerContratoCambio = System.Drawing.Color.FromArgb(143,91,143);

			// Scheduler Personalized
			private bool m_bSchedulerPersonalizedEnabled = true;
			private clsSchedulerPersonalized m_cls_sch_Personalized = null;
			private System.Drawing.Color m_clrSchedulerPersonalized = System.Drawing.Color.FromArgb(147,85,85);

			// Messages
			private System.DateTime m_dtMessagesSelectStart = System.DateTime.Now;
			private System.DateTime m_dtMessagesSelectEnd = System.DateTime.Now;
			private	bool m_bMessagesShowDeadlines = true;
			private	bool m_bMessagesShowContratosCambio = true;
			private	bool m_bMessagesShowPersonalized = true;
			private bool m_bMessagesShowed = true;
			private bool m_bMessagesShow = true;
			private Intervalo m_enumIntervalo = Intervalo.Dia;
		#endregion
		#region Properties
			public bool ShowSystemTray
			{
				set
				{
					m_bShowSystemTray = value;
					if (m_formMain != null)
						m_formMain.ShowInSystemTray = value;
				}
				get
				{
					return(m_bShowSystemTray);
				}
			}
			
			public bool Running
			{
				get
				{
					return(m_bRunning);
				}
			}

			public bool Paused
			{
				get
				{
					return(m_bPaused);
				}
			}

			public bool Close
			{
				get
				{
					return(m_bCloseApp);
				}
			}

			public bool LogDelegate
			{
				get
				{
					return(m_bLogDelegate);
				}
				set
				{
					m_bLogDelegate = value;
				}
			}

			public bool LogFile
			{
				get
				{
					return(m_bLogFile);
				}
				set
				{
					m_bLogFile = value;
				}
			}
		#endregion
		#region Constructors and Destructors
			private clsControladoraMensagens()
			{
				vLogCreate();
				vLogWrite("clsControladoraMensagens - DBA - No");
				vInitialize();
				// Config File Path
				string strEnderecoExecutavel = strReturnConfigFilePathRegistry();
				vLogWrite("strReturnConfigFilePathRegistry - " + strEnderecoExecutavel);
				if (strEnderecoExecutavel != "")
					m_cls_dba_ConnectionDB = dbcDataBaseConnection(strEnderecoExecutavel);
				if (m_cls_dba_ConnectionDB == null)
				{
					strEnderecoExecutavel = strReturnConfigFilePathCurrentDiretory();
					vLogWrite("strReturnConfigFilePathCurrentDiretory - " + strEnderecoExecutavel);
					if (strEnderecoExecutavel != "")
						m_cls_dba_ConnectionDB = dbcDataBaseConnection(strEnderecoExecutavel);
				}else{

				}
				vInitializeSchedulers();
				bLoadConfiguration();
			}

			private clsControladoraMensagens(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				vLogCreate();
				vLogWrite("clsControladoraMensagens - DBA - Yes");
				vInitialize();
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				vInitializeSchedulers();
				bLoadConfiguration();
			}

			private void vInitialize()
			{
				m_bRunning = false;
				m_bPaused = false;
				m_bCloseApp = false;
			}

			private void vInitializeSchedulers()
			{
				if (m_cls_dba_ConnectionDB != null)
				{
					m_cls_sch_Dates = new clsSchedulerDates(ref m_cls_dba_ConnectionDB,ref m_strEnderecoExecutavel);
					m_cls_sch_ContratosCambio = new clsSchedulerContratosCambio(ref m_cls_dba_ConnectionDB,ref m_strEnderecoExecutavel);
					m_cls_sch_Personalized = new clsSchedulerPersonalized(ref m_cls_dba_ConnectionDB,ref m_strEnderecoExecutavel);
				}
			}
		#endregion

		#region Load
			private bool bLoadConfiguration()
			{
				// Color 
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorPrimaria");
				m_clrBackColor = clsPaletaCores.retornaCorAtual();

				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_man_Current = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
				// Main
				try
				{
					m_bSchedulerContatoCambioEnabled = bool.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerContatoCambioEnabled",m_bSchedulerContatoCambioEnabled.ToString()));
				}catch{
				}
				try
				{
					m_bSchedulerDeadlineEnabled = bool.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerDeadlineEnabled",m_bSchedulerDeadlineEnabled.ToString()));
				}
				catch
				{
				}
				try
				{
					m_bSchedulerPersonalizedEnabled = bool.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerPersonalizedEnabled",m_bSchedulerPersonalizedEnabled.ToString()));
				}
				catch
				{
				}
				try
				{
					m_dMinutesWaitingTime = double.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"dMinutesWaitingTime",m_dMinutesWaitingTime.ToString()));
				}
				catch
				{
				}
				try
				{
					m_nSecondsTimeToShow = Int32.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToShow",m_nSecondsTimeToShow.ToString()));
				}
				catch
				{
				}
				try
				{
					m_nSecondsTimeToStay = Int32.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToStay",m_nSecondsTimeToStay.ToString()));
				}
				catch
				{
				}
				try
				{
					m_nSecondsTimeToHide = Int32.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToHide",m_nSecondsTimeToHide.ToString()));
				}
				catch
				{
				}
				try
				{
					m_dMinutesRemark = double.Parse(cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"dMinutesRemark",m_dMinutesRemark.ToString()));
				}
				catch
				{
				}

				if (m_cls_dba_ConnectionDB == null)
					return(false);

				// Contrato Cambio
				m_cls_sch_ContratosCambio.MinutesBeforeACCVencimento = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowACCVencimento",m_cls_sch_ContratosCambio.MinutesBeforeACCVencimento);
				m_cls_sch_ContratosCambio.MinutesBeforeACEVencimento = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowACEVencimento",m_cls_sch_ContratosCambio.MinutesBeforeACEVencimento);
				m_cls_sch_ContratosCambio.MessageBaseACCVencimento = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseACCVencimento",m_cls_sch_ContratosCambio.MessageBaseACCVencimento);
				m_cls_sch_ContratosCambio.MessageBaseACEVencimento = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseACEVencimento",m_cls_sch_ContratosCambio.MessageBaseACEVencimento);

				//Deadline
				m_cls_sch_Dates.MinutesBeforeShowChegadaTransporte = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowChegadaTransporte",m_cls_sch_Dates.MinutesBeforeShowChegadaTransporte);
				m_cls_sch_Dates.MinutesBeforeShowListaCarga = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowListaCarga",m_cls_sch_Dates.MinutesBeforeShowListaCarga);
				m_cls_sch_Dates.MinutesBeforeShowEspelhoBL = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowEspelhoBL",m_cls_sch_Dates.MinutesBeforeShowEspelhoBL);
				m_cls_sch_Dates.MinutesBeforeShowRetiradaContainer = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowRetiradaContainerTerminal",m_cls_sch_Dates.MinutesBeforeShowRetiradaContainer);
				m_cls_sch_Dates.MinutesBeforeShowAberturaPortao = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowAberturaPortao",m_cls_sch_Dates.MinutesBeforeShowAberturaPortao);
				m_cls_sch_Dates.MinutesBeforeShowFechamentoPortao = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowFechamentoPortao",m_cls_sch_Dates.MinutesBeforeShowFechamentoPortao);
				m_cls_sch_Dates.MinutesBeforeShowLiberacaoRF = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowLiberacaoRF",m_cls_sch_Dates.MinutesBeforeShowLiberacaoRF);
				m_cls_sch_Dates.MinutesBeforeShowOutro = m_cls_dba_ConnectionDB.GetConfiguracao("dMinutesBeforeShowOutro",m_cls_sch_Dates.MinutesBeforeShowOutro);
				m_cls_sch_Dates.MessageBaseChegadaTransporte = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseChegadaTransporte",m_cls_sch_Dates.MessageBaseChegadaTransporte);
				m_cls_sch_Dates.MessageBaseListaCarga = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseListaCarga",m_cls_sch_Dates.MessageBaseListaCarga);
				m_cls_sch_Dates.MessageBaseEspelhoBL = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseEspelhoBL",m_cls_sch_Dates.MessageBaseEspelhoBL);
				m_cls_sch_Dates.MessageBaseRetiradaContainer = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseRetiradaContainerTerminal",m_cls_sch_Dates.MessageBaseRetiradaContainer);
				m_cls_sch_Dates.MessageBaseAberturaPortao = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseAberturaPortao",m_cls_sch_Dates.MessageBaseAberturaPortao);
				m_cls_sch_Dates.MessageBaseFechamentoPortao = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseFechamentoPortao",m_cls_sch_Dates.MessageBaseFechamentoPortao);
				m_cls_sch_Dates.MessageBaseLiberacaoRF = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseLiberacaoRF",m_cls_sch_Dates.MessageBaseLiberacaoRF);
				m_cls_sch_Dates.MessageBaseOutro = m_cls_dba_ConnectionDB.GetConfiguracao("strMessageBaseOutro",m_cls_sch_Dates.MessageBaseOutro);
				return(true);
			}
		#endregion
		#region Save
			private bool bSaveConfiguration()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_man_Current = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
				// Main
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerContatoCambioEnabled",m_bSchedulerContatoCambioEnabled.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerDeadlineEnabled",m_bSchedulerDeadlineEnabled.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"bSchedulerPersonalizedEnabled",m_bSchedulerPersonalizedEnabled.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"dMinutesWaitingTime",m_dMinutesWaitingTime.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToShow",m_nSecondsTimeToShow.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToStay",m_nSecondsTimeToStay.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"nSecondsTimeToHide",m_nSecondsTimeToHide.ToString());
				cls_man_Current.colocaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"dMinutesRemark",m_dMinutesRemark.ToString());

				if (m_cls_dba_ConnectionDB == null)
					return(false);

				// Contrato Cambio
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowACCVencimento",m_cls_sch_ContratosCambio.MinutesBeforeACCVencimento.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowACEVencimento",m_cls_sch_ContratosCambio.MinutesBeforeACEVencimento.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseACCVencimento",m_cls_sch_ContratosCambio.MessageBaseACCVencimento.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseACEVencimento",m_cls_sch_ContratosCambio.MessageBaseACEVencimento.ToString());

				//Deadline
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowChegadaTransporte",m_cls_sch_Dates.MinutesBeforeShowChegadaTransporte.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowListaCarga",m_cls_sch_Dates.MinutesBeforeShowListaCarga.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowEspelhoBL",m_cls_sch_Dates.MinutesBeforeShowEspelhoBL.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowRetiradaContainerTerminal",m_cls_sch_Dates.MinutesBeforeShowRetiradaContainer.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowAberturaPortao",m_cls_sch_Dates.MinutesBeforeShowAberturaPortao.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowFechamentoPortao",m_cls_sch_Dates.MinutesBeforeShowFechamentoPortao.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowLiberacaoRF",m_cls_sch_Dates.MinutesBeforeShowLiberacaoRF.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("dMinutesBeforeShowOutro",m_cls_sch_Dates.MinutesBeforeShowOutro.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseChegadaTransporte",m_cls_sch_Dates.MessageBaseChegadaTransporte.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseListaCarga",m_cls_sch_Dates.MessageBaseListaCarga.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseEspelhoBL",m_cls_sch_Dates.MessageBaseEspelhoBL.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseRetiradaContainerTerminal",m_cls_sch_Dates.MessageBaseRetiradaContainer.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseAberturaPortao",m_cls_sch_Dates.MessageBaseAberturaPortao.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseFechamentoPortao",m_cls_sch_Dates.MessageBaseFechamentoPortao.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseLiberacaoRF",m_cls_sch_Dates.MessageBaseLiberacaoRF.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("strMessageBaseOutro",m_cls_sch_Dates.MessageBaseOutro.ToString());
				return(true);
			}
		#endregion

		#region Log
			private void vLogCreate()
			{
				try
				{
					if (m_bLogFile)
					{
						if (System.IO.File.Exists(m_strPathLog))
							System.IO.File.Delete(m_strPathLog);
						System.IO.File.Create(m_strPathLog).Close();
					}
				}
				catch
				{

				}
			}

			private void vLogWrite(string strLog)
			{
				OnCallMessageLog(strLog);
				if ((m_bLogFile) && (System.IO.File.Exists(m_strPathLog)))
				{
					System.IO.FileStream fsFile = new System.IO.FileStream(m_strPathLog, System.IO.FileMode.Append, System.IO.FileAccess.Write);
					System.IO.TextWriter twFile = new System.IO.StreamWriter(fsFile);
					twFile.WriteLine(System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " # " + strLog);
					twFile.Close();
					fsFile.Close();
				}
			}
		#endregion
		#region PathConfigFile
			private string strReturnConfigFilePathRegistry()
			{
				string strReturn = "";
				try
				{
					Microsoft.Win32.RegistryKey regKeyRegistro = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Siscobras\\Siscobras",false);
					if (regKeyRegistro != null)
						strReturn = regKeyRegistro.GetValue("Path","").ToString() + "\\";
				}catch{
					strReturn = "";
				}
				return(strReturn);
			}

			private string strReturnConfigFilePathCurrentDiretory()
			{
				return(System.Environment.CurrentDirectory + "\\");
			}
		#endregion
		#region DataBaseConnection
			private mdlDataBaseAccess.clsDataBaseAccess dbcDataBaseConnection(string strEnderecoExecutavel)
			{
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB = null;
				mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
				mdlDataBaseConfig.clsDataBaseConfig objConfigDataBase = new mdlDataBaseConfig.clsDataBaseConfig(ref cls_ter_tratadorErro,strEnderecoExecutavel);
				if (objConfigDataBase.bDataBaseConfigurated())
					if (objConfigDataBase.bDataBaseConfiguratedRight())
						objConfigDataBase.ReturnDataBaseAccess(out cls_dba_ConnectionDB);
				cls_ter_tratadorErro.ConnectionDB = cls_dba_ConnectionDB;
				return(cls_dba_ConnectionDB);
			}
		#endregion
		#region SystemTray
			private void vInitializeSystemTray()
			{
				if (m_formMain != null)
					m_formMain.ShowInSystemTray = true;
			}
				
			private void vFinalizeSystemTray()
			{
				if (m_formMain != null)
					m_formMain.ShowInSystemTray = false;
			}
		#endregion
		#region Image
			private System.Drawing.Image imgReturnImage(int nIdImage)
			{
				System.Drawing.Image imgReturn = null;
				string strImage = "SiscobrasBase.jpg";

				// Choosing the Image
				switch(nIdImage)
				{
					case DATE_SCHEDULER_IMAGE:
						strImage = "SiscobrasDeadline.jpg";
						break;
					case CONTRATOCAMBIO_SCHEDULER_IMAGE:
						strImage = "SiscobrasContratosCambio.jpg";
						break;
					case PERSONALIZED_SCHEDULER_IMAGE:
						strImage = "SiscobrasPersonalized.jpg";
						break;
				}

				// Loading the Imagem
				System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
				string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
				foreach(string strCurrent in arrStrAssembly)
				{
					if (("MDLCONTROLADORAMENSAGENS.IMAGES." + strImage.ToUpper()) == strCurrent.ToUpper())
					{
						System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
						imgReturn = System.Drawing.Image.FromStream(stmResource);
						break;
					}
				}
				return(imgReturn);
			}
		#endregion

		#region ManagerSiscoMensagem
			private clsManagerWSSiscoMensagem manSiscoReturn()
			{
				string strEnderecoExecutavel = strReturnConfigFilePathRegistry();
				if (strEnderecoExecutavel != "")
					strEnderecoExecutavel = strReturnConfigFilePathCurrentDiretory();
				if ((strEnderecoExecutavel != null) && (System.IO.Directory.Exists(strEnderecoExecutavel)))
					return(new clsManagerWSSiscoMensagem(strEnderecoExecutavel));
				else
					return(null);
			}
		#endregion

		#region State
			public mdlConstantes.SiscoMensagemState State
			{
				get
				{
					if ((m_bRunning) && (!m_bPaused))
						return(mdlConstantes.SiscoMensagemState.Running);
					if ((m_bRunning) && (m_bPaused))
						return(mdlConstantes.SiscoMensagemState.Paused);
					if (!m_bRunning) 
						return(mdlConstantes.SiscoMensagemState.Stoped);
					return(mdlConstantes.SiscoMensagemState.Unknown);
				}
			}
		#endregion
		#region Update
			public void vUpdate()
			{
				vSchedulersSyncronizate(true);
				ms_Mutex.ReleaseMutex();
				ms_Mutex.WaitOne();
			}
		#endregion
		#region Start
			private void vStart()
			{
				clsManagerWSSiscoMensagem obj = manSiscoReturn();
				obj.AlwaysApp = !mdlControladoraWindowsServices.clsManagerWSSiscoMensagem.bServiceRunning();
				if (obj != null)
					obj.bStart();
				this.bStart();
			}

			public bool bStart()
			{
				m_bStop = m_bClose = false;
				vLogWrite("bStart#Start");

				// Main Form
				vInitializeMainForm();

				// System Tray
				vInitializeSystemTray();

				// Schedulers 
				vStartDateScheduler();
				vStartContratoCambioScheduler();
				vStartPersonalizedScheduler();

				// LoopProccess
				ms_Mutex.WaitOne();
				m_thr_Messages = new System.Threading.Thread(new System.Threading.ThreadStart(vLoopProccess));
				m_thr_Messages.Start();
				m_bRunning = true;
				vLogWrite("bStart#End");
				return(true);
			}
		#endregion
		#region Pause
		private void vPause()
		{
			clsManagerWSSiscoMensagem obj = manSiscoReturn();
			obj.AlwaysApp = !mdlControladoraWindowsServices.clsManagerWSSiscoMensagem.bServiceRunning();
			if (obj != null)
				obj.bPause();
			this.bPause();
		}

		public bool bPause()
		{
			vLogWrite("bPause#Start");
			m_bPaused = true;
			vPauseContratoCambioScheduler();
			vPauseDateScheduler();
			vPausePersonalizedScheduler();
			vLogWrite("bPause#End");
			return(true);
		}
		#endregion
		#region Continue
			private void vContinue()
			{
				clsManagerWSSiscoMensagem obj = manSiscoReturn();
				obj.AlwaysApp = !mdlControladoraWindowsServices.clsManagerWSSiscoMensagem.bServiceRunning();
				if (obj != null)
					obj.bContinue();
				this.bContinue();
			}

			public bool bContinue()
			{
				vLogWrite("bContinue#Start");
				vContinueContratoCambioScheduler();
				vContinueDateScheduler();
				vContinuePersonalizedScheduler();
				m_bPaused = false;
				vLogWrite("bContinue#End");
				return(true);
			}
		#endregion
		#region Stop
			private void vStop()
			{
				clsManagerWSSiscoMensagem obj = manSiscoReturn();
				obj.AlwaysApp = !mdlControladoraWindowsServices.clsManagerWSSiscoMensagem.bServiceRunning();
				if (obj != null)
				{
					obj.bStop();
					if (m_bRunning)
						this.bStop();
				}else{
					this.bStop();
				}
			}

			public bool bStop()
			{
				vLogWrite("bStop#Start");
				// Form Messages
				if ((m_formMessages != null) && (m_formMessages.Visible))
					m_formMessages.Close();

				// Form Config
				if ((m_formConfig != null) && (m_formConfig.Visible))
					m_formConfig.Close();

				// Form Message
				if (((m_formMessage != null) && (m_formMessage.Visible)))
					m_formMessage.Close();
                
				// Schedulers 
				vStopDateScheduler();
				vStopContratoCambioScheduler();
				vStopPersonalizedScheduler();

				m_bStop = true;
				if (m_thr_Messages != null)
					m_thr_Messages.Abort();
				m_thr_Messages = null;
				m_bRunning = false;
				vLogWrite("bStop#End");
				return(true);
			}
		#endregion
		#region Close
			public void vClose()
			{
				vClose(true);
			}
			public void vClose(bool bForceClose)
			{
				vLogWrite("vClose#Start");
				clsManagerWSSiscoMensagem obj = manSiscoReturn();
				obj.AlwaysApp = !mdlControladoraWindowsServices.clsManagerWSSiscoMensagem.bServiceRunning();
				if (obj != null)
				{
					obj.bClose();
					this.bClose();
				}else{
					this.bClose();
				}
				vLogWrite("vClose#End");
				if (bForceClose)
					OnCallClose();
			}

			private bool bClose()
			{
				vLogWrite("bClose#Start");
				// Form Messages
				if ((m_formMessages != null) && (m_formMessages.Visible))
					m_formMessages.Close();

				// Form Config
				if ((m_formConfig != null) && (m_formConfig.Visible))
					m_formConfig.Close();

				// Form Message
				if (((m_formMessage != null) && (m_formMessage.Visible)))
					m_formMessage.Close();
				ShowSystemTray = false;
				bStop();
				m_bClose = true;
				m_bCloseApp = true;
				vLogWrite("bClose#End");
				return(true);
			}
		#endregion

		#region FormMain
			private void vInitializeMainForm()
			{
				vLogWrite("vInitializeMainForm#Start");
				if (m_formMain == null)
				{
					m_formMain = new mdlControladoraMensagens.Forms.frmMain();
					vInitializeEvents(ref m_formMain);
					vLogWrite("vInitializeMainForm#Oks");
				}
				vLogWrite("vInitializeMainForm#End");
			}

			private void vInitializeEvents(ref mdlControladoraMensagens.Forms.frmMain formMain)
			{
				// Main Form Popup
				formMain.eCallMenuItemPopup += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemPopup(vMainFormPopup);

				// Messages
				formMain.eCallMenuItemMessages += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemMessages(vShowMessages);

				// Configurate
				formMain.eCallMenuItemConfigurate += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemConfigurate(vShowConfig);

				// Personalized 
				formMain.eCallMenuItemPersonalized += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemPersonalized(vMessagePersonalizedAdd);

				// Start
				formMain.eCallMenuItemStart += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemStart(vStart);

				// Pause
				formMain.eCallMenuItemPause += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemPause(vPause);

				// Continue
				formMain.eCallMenuItemContinue += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemContinue(vContinue);

				// Stop
				formMain.eCallMenuItemStop += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemStop(vStop);

				// Close
				formMain.eCallMenuItemClose += new mdlControladoraMensagens.Forms.frmMain.delCallMenuItemClose(vClose);
			}

			private void vMainFormPopup(out bool bMessages, out bool bConfigurate,out bool bPersonalized, out bool bStart,out bool bPause,out bool bContinue,out bool bStop, out bool bClose)
			{
				bMessages = (((m_formMessages == null) || (!m_formMessages.Visible)) && (m_bRunning));
				bConfigurate = (((m_formConfig == null) || (!m_formConfig.Visible)) && (m_bRunning));
				bPersonalized = bRunningSchedulerPersonalized();
				bStart = !m_bRunning;
				bPause = (m_bRunning && (!m_bPaused));
				bContinue = m_bRunning && m_bPaused; 
				bStop = m_bRunning;
				bClose = true;
			}
		#endregion
		#region FormMessages
			private void vShowMessages()
			{
				if ((m_formConfig != null) && (m_formConfig.Visible))
					m_formConfig.Close();

				if (!((m_formMessages != null) && (m_formMessages.Visible)))
				{
					m_formMessages = new mdlControladoraMensagens.Forms.frmMessages();
					vInitializeEvents(ref m_formMessages);
				}
				m_formMessages.Show();
				m_formMessages.Activate();
			}

			private void vInitializeEvents(ref Forms.frmMessages formMessages)
			{
				// Load Message Configurations Colors
				formMessages.eCallCarregaConfiguracaoCores += new mdlControladoraMensagens.Forms.frmMessages.delCallCarregaConfiguracaoCores(vLoadMessageConfigurationColors);

				// Load Message Configurations
				formMessages.eCallCarregaConfiguracao += new mdlControladoraMensagens.Forms.frmMessages.delCallCarregaConfiguracao(vLoadMessageConfiguration);

				// Save Message Configurations
				formMessages.eCallSalvaConfiguracao += new mdlControladoraMensagens.Forms.frmMessages.delCallSalvaConfiguracao(vSaveMessageConfiguration);

				// Messages Refresh
				formMessages.eCallMessagesRefresh += new mdlControladoraMensagens.Forms.frmMessages.delCallMessagesRefresh(vMessagesRefresh);

				// Message New
				formMessages.eCallMessageNew += new mdlControladoraMensagens.Forms.frmMessages.delCallMessageNew(bMessagePersonalizedAdd);

				// Show Message
				formMessages.eCallShowMessage += new mdlControladoraMensagens.Forms.frmMessages.delCallShowMessage(bShowMessage);

				// Message Delete
				formMessages.eCallMessageDelete += new mdlControladoraMensagens.Forms.frmMessages.delCallMessageDelete(bMessageDelete);
			}

			private void vLoadMessageConfigurationColors(out System.Drawing.Color clrScheduleContratosCambio,out System.Drawing.Color clrScheduleDeadlines,out System.Drawing.Color clrSchedulePersonalized)
			{
				clrScheduleContratosCambio = m_clrSchedulerContratoCambio;
  			    clrScheduleDeadlines = m_clrSchedulerDate;
			    clrSchedulePersonalized = m_clrSchedulerPersonalized;
			}


			private void vLoadMessageConfiguration(out System.DateTime dtMessagesSelectStart,out System.DateTime dtMessagesSelectEnd,out bool bMessagesShowDeadlines,out bool bMessagesShowContratosCambio,out bool bMessagesShowPersonalized,out bool bMessagesShowed,out bool bMessagesShow,out Intervalo enumIntervalo)
			{
				dtMessagesSelectStart = m_dtMessagesSelectStart;
				dtMessagesSelectEnd = m_dtMessagesSelectEnd;
				bMessagesShowDeadlines = m_bMessagesShowDeadlines;
				bMessagesShowContratosCambio = m_bMessagesShowContratosCambio;
				bMessagesShowPersonalized = m_bMessagesShowPersonalized;
				bMessagesShowed = m_bMessagesShowed;
				bMessagesShow = m_bMessagesShow;
				enumIntervalo = m_enumIntervalo;
			}

			private void vSaveMessageConfiguration(System.DateTime dtMessagesSelectStart,System.DateTime dtMessagesSelectEnd,bool bMessagesShowDeadlines,bool bMessagesShowContratosCambio,bool bMessagesShowPersonalized,bool bMessagesShowed,bool bMessagesShow,Intervalo enumIntervalo)
			{
				m_dtMessagesSelectStart = dtMessagesSelectStart;
				m_dtMessagesSelectEnd = dtMessagesSelectEnd;
				m_bMessagesShowDeadlines = bMessagesShowDeadlines;
				m_bMessagesShowContratosCambio = bMessagesShowContratosCambio;
				m_bMessagesShowPersonalized = bMessagesShowPersonalized;
				m_bMessagesShowed = bMessagesShowed;
				m_bMessagesShow = bMessagesShow;
				m_enumIntervalo = enumIntervalo;
			}

			private void vDatePeriod(out System.DateTime dtMessagesSelectStart,out System.DateTime dtMessagesSelectEnd)
			{
				// Dia
				dtMessagesSelectStart = m_dtMessagesSelectStart;
				dtMessagesSelectEnd = m_dtMessagesSelectEnd;
				switch(m_enumIntervalo)
				{
					case Intervalo.Semana:
						while(((int)dtMessagesSelectStart.DayOfWeek) != 0)
							dtMessagesSelectStart = dtMessagesSelectStart.AddDays(-1);
						while(((int)dtMessagesSelectEnd.DayOfWeek) != 6)
							dtMessagesSelectEnd = dtMessagesSelectEnd.AddDays(+1);
						break;
					case Intervalo.Mes:
						dtMessagesSelectStart = new System.DateTime(m_dtMessagesSelectStart.Year,m_dtMessagesSelectStart.Month,1);
						dtMessagesSelectEnd = new System.DateTime(m_dtMessagesSelectStart.Year,m_dtMessagesSelectStart.Month,System.DateTime.DaysInMonth(m_dtMessagesSelectStart.Year,m_dtMessagesSelectStart.Month));
						break;
					case Intervalo.Ano:
						dtMessagesSelectStart = new System.DateTime(m_dtMessagesSelectStart.Year,1,1);
						dtMessagesSelectEnd = new System.DateTime(m_dtMessagesSelectStart.Year,12,System.DateTime.DaysInMonth(m_dtMessagesSelectStart.Year,12));
						break;
					case Intervalo.Tudo:
						dtMessagesSelectStart = System.DateTime.MinValue;
						dtMessagesSelectEnd = System.DateTime.MaxValue;
						break;
				}
			}

			private void vMessagesRefresh(ref System.Windows.Forms.ListView lvMessages)
			{
				System.Windows.Forms.ListViewItem lviMessage = null;
				lvMessages.Items.Clear();

				System.Collections.SortedList sortLstMessages = new System.Collections.SortedList();

				System.DateTime dtMessagesSelectStart,dtMessagesSelectEnd;
				vDatePeriod(out dtMessagesSelectStart,out dtMessagesSelectEnd);

				// Scheduler Deadline
				if (m_bMessagesShowDeadlines)
				{
					for(int i = 0;i < m_cls_sch_Dates.nMessages_Count();i++)
					{
						clsMessage objMessage = m_cls_sch_Dates.Message_CopyByIndex(i);
						if (objMessage.Deleted)
							continue;
						if (bDateInPeriod(dtMessagesSelectStart,dtMessagesSelectEnd,objMessage.DateEvent))
						{
							System.DateTime dtLastShow;
							// Showed
							if (((m_bMessagesShowed) && (objMessage.bLastShow(out dtLastShow))) || ((m_bMessagesShow) && (!objMessage.bLastShow(out dtLastShow))))
							{
								string strDate = objMessage.DateEvent.ToString("yyyyMMddHHmmss");
								while (sortLstMessages.ContainsKey(strDate))
									strDate += "x";
								sortLstMessages.Add(strDate,objMessage);
							}
						}
					}
				}

				// Scheduler Contrato Cambio
				if (m_bMessagesShowContratosCambio)
				{
					for(int i = 0;i < m_cls_sch_ContratosCambio.nMessages_Count();i++)
					{
						clsMessage objMessage = m_cls_sch_ContratosCambio.Message_CopyByIndex(i);
						if (objMessage.Deleted)
							continue;
						if (bDateInPeriod(dtMessagesSelectStart,dtMessagesSelectEnd,objMessage.DateEvent))
						{
							System.DateTime dtLastShow;
							if (((m_bMessagesShowed) && (objMessage.bLastShow(out dtLastShow))) || ((m_bMessagesShow) && (!objMessage.bLastShow(out dtLastShow))))
							{
								string strDate = objMessage.DateEvent.ToString("yyyyMMddHHmmss");
								while (sortLstMessages.ContainsKey(strDate))
									strDate += "x";
								sortLstMessages.Add(strDate,objMessage);
							}
						}
					}
				}

				// Scheduler Personalized
				if (m_bMessagesShowPersonalized)
				{
					for(int i = 0;i < m_cls_sch_Personalized.nMessages_Count();i++)
					{
						clsMessage objMessage = m_cls_sch_Personalized.Message_CopyByIndex(i);
						if (objMessage.Deleted)
							continue;
						if (bDateInPeriod(dtMessagesSelectStart,dtMessagesSelectEnd,objMessage.DateEvent))
						{
							System.DateTime dtLastShow;
							if (((m_bMessagesShowed) && (objMessage.bLastShow(out dtLastShow))) || ((m_bMessagesShow) && (!objMessage.bLastShow(out dtLastShow))))
							{
								string strDate = objMessage.DateEvent.ToString("yyyyMMddHHmmss");
								while (sortLstMessages.ContainsKey(strDate))
									strDate += "x";
								sortLstMessages.Add(strDate,objMessage);
							}
						}
					}
				}

				// Inserting Messages
				for(int i = 0; i < sortLstMessages.Count;i++)
				{
					clsMessage objMessage = (clsMessage)sortLstMessages.GetByIndex(i);
					lviMessage = lvMessages.Items.Add(objMessage.DateEvent.ToString("dd/MM/yyyy HH:mm:ss"));
					lviMessage.SubItems.Add(objMessage.Message);

					// Showed
					System.DateTime dtLastShow;
					if (!objMessage.bLastShow(out dtLastShow))
						lviMessage.Font = new System.Drawing.Font(lviMessage.Font,System.Drawing.FontStyle.Bold);

					switch(objMessage.Scheduler.Name)
					{
						case SCHEDULER_CONTRATOCAMBIO_NAME:
							lviMessage.Tag = SESSION_CONTRATOSCAMBIO + "#" + objMessage.Id;
							lviMessage.ForeColor = m_clrSchedulerContratoCambio;
							break;
						case SCHEDULER_DEADLINE_NAME:
							lviMessage.Tag = SESSION_DEADLINES + "#" + objMessage.Id;
							lviMessage.ForeColor = m_clrSchedulerDate;
							break;
						case SCHEDULER_PERSONALIZED_NAME:
							lviMessage.Tag = SESSION_PERSONALIZED + "#" + objMessage.Id;
							lviMessage.ForeColor = m_clrSchedulerPersonalized;
							break;
					}
				}
			}

			private bool bDateInPeriod(System.DateTime dtPeriodStart,System.DateTime dtPeriodEnd,System.DateTime dtCheck)
			{
				dtPeriodStart = new DateTime(dtPeriodStart.Year,dtPeriodStart.Month,dtPeriodStart.Day);
				dtPeriodEnd = new DateTime(dtPeriodEnd.Year,dtPeriodEnd.Month,dtPeriodEnd.Day);
				dtCheck = new DateTime(dtCheck.Year,dtCheck.Month,dtCheck.Day);
				if (dtCheck.Subtract(dtPeriodStart).Days >= 0)
					if (dtPeriodEnd.Subtract(dtCheck).Days >= 0)
						return(true);
				return(false);
			}

			private void vFormMessagesRefreshMessages()
			{
				// Form Messages
				if ((m_formMessages != null) && (m_formMessages.Visible))
					m_formMessages.OnCallMessagesRefresh();
			}

		#endregion
		#region FormConfig
			private void vShowConfig()
			{
				if ((m_formMessages != null) && (m_formMessages.Visible))
					m_formMessages.Close();

				if (!((m_formConfig != null) && (m_formConfig.Visible)))
				{
					m_formConfig = new mdlControladoraMensagens.Forms.frmConfig();
					vInitializeEvents(ref m_formConfig);
					m_formConfig.Show();
				}
			}

			private void vInitializeEvents(ref Forms.frmConfig formConfig)
			{
				// Sessao Refresh
				formConfig.eCallSessoesRefresh += new mdlControladoraMensagens.Forms.frmConfig.delCallSessoesRefresh(vSessaoRefresh);

				// Sessao Carrega
				formConfig.eCallSessaoCarrega += new mdlControladoraMensagens.Forms.frmConfig.delCallSessaoCarrega(bSessaoCarrega);

				// Carrega Dados
				formConfig.eCallCarregaDados += new mdlControladoraMensagens.Forms.frmConfig.delCallCarregaDados(bLoadConfiguration);

				// Salva Dados
				formConfig.eCallSalvaDados += new mdlControladoraMensagens.Forms.frmConfig.delCallSalvaDados(bSaveConfiguration);
			}

			private void vSessaoRefresh(ref System.Windows.Forms.TreeView tvSessoes)
			{
				System.Windows.Forms.TreeNode tvnCurrent;

				tvSessoes.Nodes.Clear();
				tvSessoes.Nodes.Add("Intervalos").Tag = SESSION_MAIN;
				tvnCurrent = tvSessoes.Nodes.Add("Contratos Câmbio");
				tvnCurrent.Tag = SESSION_CONTRATOSCAMBIO;
				tvnCurrent.Nodes.Add("ACC").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC;
				tvnCurrent.Nodes.Add("ACE").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE;
				tvnCurrent = tvSessoes.Nodes.Add("Deadlines");
				tvnCurrent.Tag = SESSION_DEADLINES;
				tvnCurrent.Nodes.Add("Abertura portão").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO;
				tvnCurrent.Nodes.Add("Chegada prevista transporte").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE;
				tvnCurrent.Nodes.Add("Espelho BL").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL;
				tvnCurrent.Nodes.Add("Fechamento portão").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO;
				tvnCurrent.Nodes.Add("Liberação Receita Federal").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL;
				tvnCurrent.Nodes.Add("Lista carga").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA;
				tvnCurrent.Nodes.Add("Outro").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO;
				tvnCurrent.Nodes.Add("Retirada Container").Tag = mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL;
				tvSessoes.Nodes.Add("Personalizadas").Tag = SESSION_PERSONALIZED;
				tvSessoes.SelectedNode = null;
			}

			private bool bSessaoCarrega(ref System.Windows.Forms.GroupBox gbOpcoes,int nIdSessao)
			{
				gbOpcoes.Controls.Clear();
				System.Windows.Forms.UserControl usrCtrlBase = null;
				switch(nIdSessao)
				{
					case SESSION_MAIN:
						usrCtrlBase = new UserControls.usrCtrlMain();
						UserControls.usrCtrlMain uctrMain = (UserControls.usrCtrlMain)usrCtrlBase;
						vInitializeEvents(ref uctrMain);
						break;
					case SESSION_CONTRATOSCAMBIO:
						usrCtrlBase = new UserControls.usrCtrlContratosCambio();
						UserControls.usrCtrlContratosCambio uctrContratoCambio = (UserControls.usrCtrlContratosCambio)usrCtrlBase;
						vInitializeEvents(ref uctrContratoCambio);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC:
						usrCtrlBase = new UserControls.usrCtrlContratosCambioACC();
						UserControls.usrCtrlContratosCambioACC uctrCCACC = (UserControls.usrCtrlContratosCambioACC)usrCtrlBase;
						vInitializeEvents(ref uctrCCACC);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE:
						usrCtrlBase = new UserControls.usrCtrlContratosCambioACE();
						UserControls.usrCtrlContratosCambioACE uctrCCACE = (UserControls.usrCtrlContratosCambioACE)usrCtrlBase;
						vInitializeEvents(ref uctrCCACE);
						break;
					case SESSION_DEADLINES:
						usrCtrlBase = new UserControls.usrCtrlDeadlines();
						UserControls.usrCtrlDeadlines uctrDeadLine = (UserControls.usrCtrlDeadlines)usrCtrlBase;
						vInitializeEvents(ref uctrDeadLine);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesAberturaPortao();
						UserControls.usrCtrlDeadlinesAberturaPortao uctrDeadlineAberturaPortao = (UserControls.usrCtrlDeadlinesAberturaPortao)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineAberturaPortao);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesChegadaPrevista();
						UserControls.usrCtrlDeadlinesChegadaPrevista uctrDeadlineChegadaTransporte = (UserControls.usrCtrlDeadlinesChegadaPrevista)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineChegadaTransporte);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesEspelhoBL();
						UserControls.usrCtrlDeadlinesEspelhoBL uctrDeadlineEspelhoBL = (UserControls.usrCtrlDeadlinesEspelhoBL)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineEspelhoBL);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesFechamentoPortao();
						UserControls.usrCtrlDeadlinesFechamentoPortao uctrDeadlineFechamentoPortao = (UserControls.usrCtrlDeadlinesFechamentoPortao)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineFechamentoPortao);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesLiberacaoRF();
						UserControls.usrCtrlDeadlinesLiberacaoRF uctrDeadlineLiberacaoRF = (UserControls.usrCtrlDeadlinesLiberacaoRF)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineLiberacaoRF);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesListaCarga();
						UserControls.usrCtrlDeadlinesListaCarga uctrDeadlineListaCarga = (UserControls.usrCtrlDeadlinesListaCarga)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineListaCarga);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesOutro();
						UserControls.usrCtrlDeadlinesOutro uctrDeadlineOutro = (UserControls.usrCtrlDeadlinesOutro)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineOutro);
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL:
						usrCtrlBase = new UserControls.usrCtrlDeadlinesRetiradaContainer();
						UserControls.usrCtrlDeadlinesRetiradaContainer uctrDeadlineRetiradaContainerTerminal = (UserControls.usrCtrlDeadlinesRetiradaContainer)usrCtrlBase;
						vInitializeEvents(ref uctrDeadlineRetiradaContainerTerminal);
						break;
					case SESSION_PERSONALIZED:
						usrCtrlBase = new UserControls.usrCtrlPersonalized();
						UserControls.usrCtrlPersonalized uctrPersonalized = (UserControls.usrCtrlPersonalized)usrCtrlBase;
						vInitializeEvents(ref uctrPersonalized);
						break;
				}
				if (usrCtrlBase != null)
				{
					usrCtrlBase.Visible = false;
					gbOpcoes.Controls.Add(usrCtrlBase);
					usrCtrlBase.SetBounds(4, 9, (gbOpcoes.Width - 9), (gbOpcoes.Height - 14));
					usrCtrlBase.Visible = true;
					usrCtrlBase.BringToFront();
					return(true);
				}else{
					return(false);
				}
			}

			private void vInitializeEvents(ref UserControls.usrCtrlMain uctrlMain)
			{
				// Message Refresh
				uctrlMain.eCallMessageRefresh += new mdlControladoraMensagens.UserControls.usrCtrlMain.delCallMessageRefresh(vSchedulersSyncronizate);

				// Load Configurations
				uctrlMain.eCallLoadConfigurations += new mdlControladoraMensagens.UserControls.usrCtrlMain.delCallLoadConfigurations(vLoadConfigurations);

				// Save Configurations
				uctrlMain.eCallSaveConfigurations += new mdlControladoraMensagens.UserControls.usrCtrlMain.delCallSaveConfigurations(vSaveConfigurations);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlContratosCambio uctrCurrent)
			{
				// Load Scheduler Activated
				uctrCurrent.eCallLoadSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambio.delCallLoadSchedulerActivated(vLoadSchedulerActivated);

				// Save Scheduler Activated
				uctrCurrent.eCallSaveSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambio.delCallSaveSchedulerActivated(vSaveSchedulerActivated);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlContratosCambioACC uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACC.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACC.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACC.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACC.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlContratosCambioACE uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACE.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACE.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACE.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlContratosCambioACE.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlines uctrDeadLine)
			{
				// Load Scheduler Activated
				uctrDeadLine.eCallLoadSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlDeadlines.delCallLoadSchedulerActivated(vLoadSchedulerActivated);

				// Save Scheduler Activated
				uctrDeadLine.eCallSaveSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlDeadlines.delCallSaveSchedulerActivated(vSaveSchedulerActivated);

			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesAberturaPortao uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesAberturaPortao.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesAberturaPortao.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesAberturaPortao.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesAberturaPortao.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesChegadaPrevista uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesChegadaPrevista.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesChegadaPrevista.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesChegadaPrevista.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesChegadaPrevista.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesEspelhoBL uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesEspelhoBL.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesEspelhoBL.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesEspelhoBL.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesEspelhoBL.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesFechamentoPortao uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesFechamentoPortao.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesFechamentoPortao.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesFechamentoPortao.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesFechamentoPortao.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesLiberacaoRF uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesLiberacaoRF.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesLiberacaoRF.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesLiberacaoRF.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesLiberacaoRF.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesListaCarga uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesListaCarga.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesListaCarga.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesListaCarga.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesListaCarga.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesOutro uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesOutro.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesOutro.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesOutro.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesOutro.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlDeadlinesRetiradaContainer uctrCurrent)
			{
				// Load MessageBase
				uctrCurrent.eCallLoadMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesRetiradaContainer.delCallLoadMessageBase(vLoadMessageBase);

				// Show MessageBase
				uctrCurrent.eCallShowMessageBase += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesRetiradaContainer.delCallShowMessageBase(bShowDialogMessageBaseGenerate);

				// Load Minutes Before Show
				uctrCurrent.eCallLoadMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesRetiradaContainer.delCallLoadMinutesBeforeShow(vLoadMinutesBeforeShow);

				// Save Minutes Before Show
				uctrCurrent.eCallSaveMinutesBeforeShow += new mdlControladoraMensagens.UserControls.usrCtrlDeadlinesRetiradaContainer.delCallSaveMinutesBeforeShow(vSaveMinutesBeforeShow);
			}

			private void vInitializeEvents(ref UserControls.usrCtrlPersonalized uctrCurrent)
			{
				// Load Scheduler Activated
				uctrCurrent.eCallLoadSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlPersonalized.delCallLoadSchedulerActivated(vLoadSchedulerActivated);

				// Save Scheduler Activated
				uctrCurrent.eCallSaveSchedulerActivated += new mdlControladoraMensagens.UserControls.usrCtrlPersonalized.delCallSaveSchedulerActivated(vSaveSchedulerActivated);
			}
		#endregion
		#region FormFMessageBaseGenerate
			private bool bShowDialogMessageBaseGenerate(int nIdSubType)
			{
				bool bReturn = false;
				string strMessageBase;
				vLoadMessageBase(nIdSubType,out strMessageBase);
				Forms.frmFMessageBaseGenerate formFMessageBaseGenerate = new mdlControladoraMensagens.Forms.frmFMessageBaseGenerate(strMessageBase);
				// Set Type
				int nType = Int32.Parse(nIdSubType.ToString().Substring(0,1));
				switch(nType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO:
						formFMessageBaseGenerate.ContratoCambio = true;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE:
						formFMessageBaseGenerate.Deadline = true;
						break;
				}
				// Set SubType
				switch(nIdSubType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						formFMessageBaseGenerate.DeadlineChegadaPrevista = true;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						formFMessageBaseGenerate.DeadlineOutro = true;
						break;
				}


				formFMessageBaseGenerate.ShowDialog();
				if (bReturn = formFMessageBaseGenerate.m_bModificado)
				{
					formFMessageBaseGenerate.vReturnValues(out strMessageBase);
					vSaveMessageBase(nIdSubType,strMessageBase);
				}
				return(bReturn);
			}
		#endregion
		#region FormMessage
			private bool bShowMessage(string strIdMessage)
			{
				bool bReturn = false;
				if (((m_formMessage != null) && (m_formMessage.Visible)))
					m_formMessage.Close();
				if (!bMessageExists(strIdMessage))
					return(false);
				m_formMessage = new mdlControladoraMensagens.Forms.frmMessage(strIdMessage);
				vInitializeEvents(ref m_formMessage);
				m_formMessage.ShowDialog();
				bReturn = m_formMessage.m_bModificado;
				return(bReturn);
			}

			private bool bMessagePersonalizedAdd()
			{
				// Show Message
				if (((m_formMessage != null) && (m_formMessage.Visible)))
					m_formMessage.Close();
				m_formMessage = new mdlControladoraMensagens.Forms.frmMessage(SESSION_PERSONALIZED + "#-1");
				m_formMessage.VisibleDiscardButton = false;
				vInitializeEvents(ref m_formMessage);
				m_formMessage.ShowDialog();
				return(m_formMessage.m_bModificado);
			}

			private void vMessagePersonalizedAdd()
			{
				// Show Message
				if (((m_formMessage != null) && (m_formMessage.Visible)))
					m_formMessage.Close();
				m_formMessage = new mdlControladoraMensagens.Forms.frmMessage(SESSION_PERSONALIZED + "#-1");
				m_formMessage.VisibleDiscardButton = false;
				vInitializeEvents(ref m_formMessage);
				m_formMessage.Show();
			}

			private void vInitializeEvents(ref mdlControladoraMensagens.Forms.frmMessage formMessage)
			{
				// Message Type
				formMessage.eCallLoadConfigurationMessageType +=new mdlControladoraMensagens.Forms.frmMessage.delCallLoadConfigurationMessageType(formMessage_eCallLoadConfigurationMessageType);

				// Load Message Data
				formMessage.eCallLoadData += new mdlControladoraMensagens.Forms.frmMessage.delCallLoadData(vMessageLoad);

				// Message Save
				formMessage.eCallMessageSave += new mdlControladoraMensagens.Forms.frmMessage.delCallMessageSave(bMessageSave);

				// Message Discard 
				formMessage.eCallMessageDelete += new mdlControladoraMensagens.Forms.frmMessage.delCallMessageDelete(bMessageDelete);
			}

			private void formMessage_eCallLoadConfigurationMessageType(string strIdMessage,out System.Drawing.Color clrMessageType,out string strMessageType)
			{
				int nMessageType,nIdMessage;
				if (bReturnMessageInformation(strIdMessage,out nMessageType,out nIdMessage))
				{
					switch(nMessageType)
					{
						case SESSION_CONTRATOSCAMBIO:
							clrMessageType = m_clrSchedulerContratoCambio;
							strMessageType = SCHEDULER_CONTRATOCAMBIO_NAME;
							break;
						case SESSION_DEADLINES:
							clrMessageType = m_clrSchedulerDate;
							strMessageType = SCHEDULER_DEADLINE_NAME;
							break;
						case SESSION_PERSONALIZED:
							clrMessageType = m_clrSchedulerPersonalized;
							strMessageType = SCHEDULER_PERSONALIZED_NAME;
							break;
						default:
							clrMessageType = System.Drawing.Color.Black;
							strMessageType = "";
							break;
					}
				}else{
					clrMessageType = System.Drawing.Color.Black;
					strMessageType = "";
				}
			}
		#endregion

		#region Loop
			private int nReturnIddleTime()
			{
				int nReturn = (int)(m_dMinutesWaitingTime * 60000);
				clsMessage[] objMessages = null;

				// Data Scheduler
				objMessages = m_cls_sch_Dates.msgHasMessagesToShow(System.DateTime.Now.AddMilliseconds(nReturn));
				if ((objMessages != null) && (objMessages.Length > 0))
					nReturn = (objMessages[0].DateShow.Subtract(System.DateTime.Now)).Milliseconds;
				// Contrato Cambio Scheduler
				objMessages = m_cls_sch_ContratosCambio.msgHasMessagesToShow(System.DateTime.Now.AddMilliseconds(nReturn));
				if ((objMessages != null) && (objMessages.Length > 0))
					nReturn = (int)(objMessages[0].DateShow.Subtract(System.DateTime.Now)).TotalMilliseconds;
				// Personalized Scheduler
				objMessages = m_cls_sch_Personalized.msgHasMessagesToShow(System.DateTime.Now.AddMilliseconds(nReturn));
				if ((objMessages != null) && (objMessages.Length > 0))
					nReturn = (int)(objMessages[0].DateShow.Subtract(System.DateTime.Now)).TotalMilliseconds;

				return(nReturn);
			}

			private void vLoopProccess()
			{
				vLogWrite("vLoopProccess#Start");
				while(true)
				{
					clsMessage currMessage = null;

					// Date Scheduler 
					while(((currMessage = m_cls_sch_Dates.msgHasNextMessageToShow()) != null) && (!m_bStop) && (!m_bClose))
					{
						m_cls_sch_Dates.vMessageDateShowedAdd(currMessage.Id,System.DateTime.Now);
						vShowMessage(DATE_SCHEDULER_IMAGE,m_clrSchedulerDate,SESSION_DEADLINES + "#" + currMessage.Id,currMessage.DateEvent.ToString("dd/MM/yyyy hh:mm:ss"),currMessage.Message,m_nSecondsTimeToShow,m_nSecondsTimeToStay,m_nSecondsTimeToHide);
						m_cls_sch_Dates.vMessageRemarkNextShow(currMessage.Id,m_dMinutesRemark);

						// Stopping
						if (m_bStop)
							break;
						// Closing
						if (m_bClose)
                            break;
					}

					System.Windows.Forms.Application.DoEvents();

					// Contratos Cambio Scheduler
					while(((currMessage = m_cls_sch_ContratosCambio.msgHasNextMessageToShow()) != null) && (!m_bStop) && (!m_bClose))
					{
						m_cls_sch_ContratosCambio.vMessageDateShowedAdd(currMessage.Id,System.DateTime.Now);
						vShowMessage(CONTRATOCAMBIO_SCHEDULER_IMAGE,m_clrSchedulerContratoCambio,SESSION_CONTRATOSCAMBIO + "#" + currMessage.Id,currMessage.DateEvent.ToString("dd/MM/yyyy hh:mm:ss"),currMessage.Message,m_nSecondsTimeToShow ,m_nSecondsTimeToStay,m_nSecondsTimeToHide);
						m_cls_sch_ContratosCambio.vMessageRemarkNextShow(currMessage.Id,m_dMinutesRemark);

						// Stopping
						if (m_bStop)
							break;
						// Closing
						if (m_bClose)
							break;
					}

					System.Windows.Forms.Application.DoEvents();

					// Personalized Scheduler
					while(((currMessage = m_cls_sch_Personalized.msgHasNextMessageToShow()) != null) && (!m_bStop) && (!m_bClose))
					{
						m_cls_sch_Personalized.vMessageDateShowedAdd(currMessage.Id,System.DateTime.Now);
						vShowMessage(PERSONALIZED_SCHEDULER_IMAGE,m_clrSchedulerPersonalized,SESSION_PERSONALIZED + "#" + currMessage.Id,currMessage.DateEvent.ToString("dd/MM/yyyy hh:mm:ss"),currMessage.Message,m_nSecondsTimeToShow,m_nSecondsTimeToStay,m_nSecondsTimeToHide);
						m_cls_sch_Personalized.vMessageRemarkNextShow(currMessage.Id,m_dMinutesRemark);

						// Stopping
						if (m_bStop)
							break;
						// Closing
						if (m_bClose)
							break;
					}

					System.Windows.Forms.Application.DoEvents();

					// Stopping
					if (m_bStop)
						break;

					// Closing 
					if (m_bClose)
						break;

					// Return 
					ms_Mutex.WaitOne(nReturnIddleTime(),false);
					try
					{
						ms_Mutex.ReleaseMutex();
					}catch{

					}
					System.GC.Collect();
				}
				vLogWrite("vLoopProccess#End");
				if (m_bClose)
					vClose(false);
			}
		#endregion
		#region ShowMensagem
			private void vShowMessage(int nImagem,System.Drawing.Color clrColor,string strTag,string strTitle,string strContent,int nTimeToShow,int nTimeToStay,int nTimeToHide)
			{
				vLogWrite("vShowMessage#Start");
				mdlComponentesGraficos.TaskbarNotifier formTask = new mdlComponentesGraficos.TaskbarNotifier();
				formTask.SetBackgroundBitmap(imgReturnImage(nImagem),System.Drawing.Color.Black);
				formTask.TitleRectangle = new System.Drawing.Rectangle(45,-40,200,200);
				formTask.NormalTitleFont = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				formTask.NormalTitleColor = clrColor;
				formTask.ContentRectangle = new System.Drawing.Rectangle(10,40,180,170);
				formTask.Content2Rectangle = new System.Drawing.Rectangle(35,120,135,130);
				formTask.NormalContentFont = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				formTask.NormalContent2Font = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				formTask.NormalContentColor = System.Drawing.Color.Black;
				formTask.NormalContent2Color = System.Drawing.Color.Red;
				formTask.HoverContentFont = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				formTask.HoverContent2Font = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				formTask.HoverContentColor = System.Drawing.Color.Red;
				formTask.HoverContent2Color = System.Drawing.Color.Red;
				formTask.Tag = strTag;
				formTask.Icon = m_formMain.Icon;
				formTask.Text = "SiscoMensagem";
				formTask.ContentClick += new EventHandler(formTask_ContentClick);
				formTask.Content2Click += new EventHandler(formTask_Content2Click);
				formTask.Show(strTitle,strContent,"Excluir",nTimeToShow,nTimeToStay,nTimeToHide);
				while(formTask.Visible)
				{
					System.Windows.Forms.Application.DoEvents();
				}
				vFormMessagesRefreshMessages();
				vLogWrite("vShowMessage#End");
			}

			private void formTask_ContentClick(object sender, EventArgs e)
			{
				bShowMessage(((mdlComponentesGraficos.TaskbarNotifier)sender).Tag.ToString());
			}

			private void formTask_Content2Click(object sender, EventArgs e)
			{
				bMessageDelete(((mdlComponentesGraficos.TaskbarNotifier)sender).Tag.ToString(),false);
			}
		#endregion

		#region Message
			private bool bReturnMessageInformation(string strIdMessage,out int nMessageType,out int nIdMessage)
			{
				bool bReturn = false;
				int nIndex;
				if (bReturn = ((nIndex = strIdMessage.IndexOf("#")) > 0))
				{
					nMessageType = Int32.Parse(strIdMessage.Substring(0,nIndex));
					nIdMessage = Int32.Parse(strIdMessage.Substring(nIndex + 1));
				}else{
					nMessageType = -1;
					nIdMessage = -1;
				}
				return(bReturn);
			}

			private bool bMessageExists(string strIdMessage)
			{
				int nMessageType,nIdMessage;
				if (bReturnMessageInformation(strIdMessage,out nMessageType,out nIdMessage))
				{
					clsScheduler objScheduler = null;
					switch(nMessageType)
					{
						case SESSION_CONTRATOSCAMBIO:
							objScheduler = m_cls_sch_ContratosCambio;
							break;
						case SESSION_DEADLINES:
							objScheduler = m_cls_sch_Dates;
							break;
						case SESSION_PERSONALIZED:
							objScheduler = m_cls_sch_Personalized;
							break;
					}
					if (objScheduler != null)
					{
						clsMessage objMessage = objScheduler.Message_Copy(nIdMessage);
						if(objMessage != null)
						{
							return(true);
						}else{
							return(false);
						}
					}else{
						return(false);
					}
				}else{
					return(false);
				}
			}

			private void vMessageLoad(string strIdMessage, out DateTime dtShow, out bool bShow, out DateTime dtEvent, out string strMessage)
			{
				int nMessageType,nIdMessage;
				if (bReturnMessageInformation(strIdMessage,out nMessageType,out nIdMessage))
				{
					clsScheduler objScheduler = null;
					switch(nMessageType)
					{
						case SESSION_CONTRATOSCAMBIO:
							objScheduler = m_cls_sch_ContratosCambio;
							break;
						case SESSION_DEADLINES:
							objScheduler = m_cls_sch_Dates;
							break;
						case SESSION_PERSONALIZED:
							objScheduler = m_cls_sch_Personalized;
							break;
					}
					if (objScheduler != null)
					{
						clsMessage objMessage = objScheduler.Message_Copy(nIdMessage);
						if(objMessage != null)
						{
							dtShow = objMessage.DateShow;
							bShow = objMessage.Show;
							dtEvent = objMessage.DateEvent;
							strMessage = objMessage.Message;
						}
						else
						{
							dtShow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
							bShow = true;
							dtEvent = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
							strMessage = "";
						}
					}else{
						dtShow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
						bShow = true;
						dtEvent = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
						strMessage = "";
					}
				}
				else
				{
					dtShow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
					bShow = true;
					dtEvent = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day,0,0,0);
					strMessage = "";
				}
			}

			private bool bMessageDelete(ref System.Collections.ArrayList arlMessages)
			{
				bool bReturn = false;

				if (mdlMensagens.clsMensagens.ShowQuestion("Deseja mesmo excluir esta(s) mensagem(s) ?") == System.Windows.Forms.DialogResult.No)
					return(false);
				
				bReturn = true;
				for(int i = 0; i < arlMessages.Count;i++)
				{
					string strMessage = arlMessages[i].ToString();
					if (!bMessageDelete(strMessage,true))
					{
						bReturn = false;
						break;
					}
				}
				if (!bReturn)
					mdlMensagens.clsMensagens.ShowInformation("Não foi possível excluir as mensagens selecionadas.");
				return (bReturn);
			}

			private bool bMessageDelete(string strIdMessage,bool bSilent)
			{
				int nMessageType,nIdMessage;

				if (!bMessageExists(strIdMessage))
					return(true);

				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowQuestion("Deseja mesmo excluir esta mensagem ?") == System.Windows.Forms.DialogResult.No)
						return(false);

				if (bReturnMessageInformation(strIdMessage,out nMessageType,out nIdMessage))
				{
					clsScheduler objScheduler = null;
					switch(nMessageType)
					{
						case SESSION_CONTRATOSCAMBIO:
							objScheduler = m_cls_sch_ContratosCambio;
							break;
						case SESSION_DEADLINES:
							objScheduler = m_cls_sch_Dates;
							break;
						case SESSION_PERSONALIZED:
							objScheduler = m_cls_sch_Personalized;
							break;
					}
					if (objScheduler != null)
						return(objScheduler.bMessage_Delete(nIdMessage));
					else
						return false;
				}else{
					return false;
				}
			}

			private bool bMessageSave(string strIdMessage, DateTime dtShow, bool bShow, DateTime dtEvent, string strMessage)
			{
				bool bReturn = false;
				int nMessageType,nIdMessage;
				if (bReturnMessageInformation(strIdMessage,out nMessageType,out nIdMessage))
				{
					clsScheduler objScheduler = null;
					switch(nMessageType)
					{
						case SESSION_CONTRATOSCAMBIO:
							objScheduler = m_cls_sch_ContratosCambio;
							break;
						case SESSION_DEADLINES:
							objScheduler = m_cls_sch_Dates;
							break;
						case SESSION_PERSONALIZED:
							objScheduler = m_cls_sch_Personalized;
							break;
					}
					if (objScheduler != null)
					{
						if (objScheduler != m_cls_sch_Personalized)
						{
							// Another Schedulers 
							objScheduler.bMessage_Delete(nIdMessage);
							if (bReturn = m_cls_sch_Personalized.bAdd(true,dtEvent,dtShow,strMessage,bShow))
							{
								m_cls_sch_Personalized.bSaveMessage(m_cls_sch_Personalized.LastMessageAdded);
								vFormMessagesRefreshMessages();
							}
						}else{
							// Personalized Scheduler
							if (m_cls_sch_Personalized.Message_Copy(nIdMessage) == null)
							{
								// New
								if (bReturn = m_cls_sch_Personalized.bAdd(true,dtEvent,dtShow,strMessage,bShow))
								{
									m_cls_sch_Personalized.bSaveMessage(m_cls_sch_Personalized.LastMessageAdded);
									vFormMessagesRefreshMessages();
								}
							}else{
								// Update
								if (bReturn = m_cls_sch_Personalized.bUpdate(nIdMessage,dtEvent,dtShow, strMessage,bShow))
								{
									m_cls_sch_Personalized.bSaveMessage(m_cls_sch_Personalized.LastMessageUpdated);
									vFormMessagesRefreshMessages();
								}
							}
							try
							{
								ms_Mutex.ReleaseMutex();
								ms_Mutex.WaitOne();
							}catch{

							}
						}
					}
				}else{
					bReturn = false;
				}
				return(bReturn);
			}
		#endregion
		#region MessageBase
			private void vLoadMessageBase(int nIdSubType,out string strMessageBase)
			{
				strMessageBase = "";
				switch(nIdSubType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseChegadaTransporte;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseListaCarga;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseEspelhoBL;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseRetiradaContainer;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseAberturaPortao;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseFechamentoPortao;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseLiberacaoRF;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						if (m_cls_sch_Dates != null)
							strMessageBase = m_cls_sch_Dates.MessageBaseOutro;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC:
						if (m_cls_sch_ContratosCambio != null)
							strMessageBase = m_cls_sch_ContratosCambio.MessageBaseACCVencimento;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE:
						if (m_cls_sch_ContratosCambio != null)
							strMessageBase = m_cls_sch_ContratosCambio.MessageBaseACEVencimento;
						break;
				}
			}

			private void vSaveMessageBase(int nIdSubType,string strMessageBase)
			{
				switch(nIdSubType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseChegadaTransporte = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseListaCarga = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseEspelhoBL = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseRetiradaContainer = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseAberturaPortao = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseFechamentoPortao = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseLiberacaoRF = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MessageBaseOutro = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC:
						if (m_cls_sch_ContratosCambio != null)
							m_cls_sch_ContratosCambio.MessageBaseACCVencimento = strMessageBase;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE:
						if (m_cls_sch_ContratosCambio != null)
							m_cls_sch_ContratosCambio.MessageBaseACEVencimento = strMessageBase;
						break;
				}
			}
		#endregion
		#region Times
			private void vLoadConfigurations(out double dWaitingTime, out int nTimeToUp, out int nTimeToStay, out int nTimeToDown,out double dTimeToRemark)
			{
				dWaitingTime = m_dMinutesWaitingTime;
				nTimeToUp = m_nSecondsTimeToShow;
				nTimeToStay = m_nSecondsTimeToStay;
				nTimeToDown = m_nSecondsTimeToHide;
				dTimeToRemark = m_dMinutesRemark;
			}

			private void vSaveConfigurations(double dWaitingTime, int nTimeToUp, int nTimeToStay, int nTimeToDown,double dTimeToRemark)
			{
				m_dMinutesWaitingTime = dWaitingTime;
				m_nSecondsTimeToShow = nTimeToUp;
				m_nSecondsTimeToStay = nTimeToStay;
				m_nSecondsTimeToHide = nTimeToDown;
				m_dMinutesRemark = dTimeToRemark;
			}

			private void vLoadMinutesBeforeShow(int nIdSubType,out double dMinutes)
			{
				dMinutes = 0;
				switch(nIdSubType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowChegadaTransporte;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowListaCarga;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowEspelhoBL;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowRetiradaContainer;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowAberturaPortao;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowFechamentoPortao;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowLiberacaoRF;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						if (m_cls_sch_Dates != null)
							dMinutes = m_cls_sch_Dates.MinutesBeforeShowOutro;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC:
						if (m_cls_sch_ContratosCambio != null)
							dMinutes = m_cls_sch_ContratosCambio.MinutesBeforeACCVencimento;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE:
						if (m_cls_sch_ContratosCambio != null)
							dMinutes = m_cls_sch_ContratosCambio.MinutesBeforeACEVencimento;
						break;
				}
			}

			private void vSaveMinutesBeforeShow(int nIdSubType,double dMinutes)
			{
				switch(nIdSubType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowChegadaTransporte = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowListaCarga = dMinutes;;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowEspelhoBL = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowRetiradaContainer = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowAberturaPortao = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowFechamentoPortao = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowLiberacaoRF = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO:
						if (m_cls_sch_Dates != null)
							m_cls_sch_Dates.MinutesBeforeShowOutro = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC:
						if (m_cls_sch_ContratosCambio != null)
							m_cls_sch_ContratosCambio.MinutesBeforeACCVencimento = dMinutes;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACE:
						if (m_cls_sch_ContratosCambio != null)
							m_cls_sch_ContratosCambio.MinutesBeforeACEVencimento = dMinutes;
						break;
				}
			}

		#endregion

		#region Schedulers
			public void vSchedulersSyncronizate(bool bReloadMessages)
			{
				if (m_cls_sch_Dates != null)
					m_cls_sch_Dates.bSyncronizeMessages();
				if (m_cls_sch_ContratosCambio  != null)
					m_cls_sch_ContratosCambio.bSyncronizeMessages();
				if (bReloadMessages)
				{
					if (m_cls_sch_Dates != null)
						m_cls_sch_Dates.bLoadMessages();
					if (m_cls_sch_ContratosCambio  != null)
						m_cls_sch_ContratosCambio.bLoadMessages();
				}
			}

			private void vLoadSchedulerActivated(int nIdType, out bool bActivated)
			{
				bActivated = false;
				switch(nIdType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO:
						bActivated = m_cls_sch_ContratosCambio.Enabled;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE:
						bActivated = m_cls_sch_Dates.Enabled;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED:
						bActivated = m_cls_sch_Personalized.Enabled;
						break;
				}
			}

			private void vSaveSchedulerActivated(int nIdType, bool bActivated)
			{
				switch(nIdType)
				{
					case mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO:
						m_cls_sch_ContratosCambio.Enabled = bActivated;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE:
						m_cls_sch_Dates.Enabled = bActivated;
						break;
					case mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED:
						bActivated = m_cls_sch_Personalized.Enabled;
						break;
				}
			}
		#endregion
		#region Date Scheduler
			#region Start
				private void vStartDateScheduler()
				{
					m_cls_sch_Dates.Enabled = m_bSchedulerDeadlineEnabled;
					m_cls_sch_Dates.vStart();
				}
			#endregion
			#region Running
				private bool bRunningSchedulerDate()
				{
					return((m_cls_sch_Dates != null) && (m_cls_sch_Dates.Enabled));
				}
			#endregion
			#region Pause
				private void vPauseDateScheduler()
				{
					if (m_cls_sch_Dates != null)
						m_cls_sch_Dates.Paused = true;
				}
			#endregion
			#region Continue
				private void vContinueDateScheduler()
				{
					if (m_cls_sch_Dates != null)
						m_cls_sch_Dates.Paused = false;
				}
			#endregion
			#region Stop
				private void vStopDateScheduler()
				{
					if (m_cls_sch_Dates != null)
						m_cls_sch_Dates.vStop();
				}
			#endregion
		#endregion
		#region ContratoCambio Scheduler
			#region Start
				private void vStartContratoCambioScheduler()
				{
					m_cls_sch_ContratosCambio.Enabled = m_bSchedulerContatoCambioEnabled;
					m_cls_sch_ContratosCambio.vStart();
				}
			#endregion
			#region Running
				private bool bRunningSchedulerContratoCambio()
				{
					return((m_cls_sch_ContratosCambio != null) && (m_cls_sch_ContratosCambio.Enabled));
				}
			#endregion
			#region Pause
				private void vPauseContratoCambioScheduler()
				{
					if (m_cls_sch_ContratosCambio != null)
						m_cls_sch_ContratosCambio.Paused = true;
				}
			#endregion
			#region Continue
				private void vContinueContratoCambioScheduler()
				{
					if (m_cls_sch_ContratosCambio != null)
						m_cls_sch_ContratosCambio.Paused = false;
				}
			#endregion
			#region Stop
				private void vStopContratoCambioScheduler()
				{
					if (m_cls_sch_ContratosCambio != null)
						m_cls_sch_ContratosCambio.vStop();
				}
			#endregion
		#endregion
		#region Personalized Scheduler
			#region Start
				private void vStartPersonalizedScheduler()
				{
					m_cls_sch_Personalized.Enabled = m_bSchedulerPersonalizedEnabled;
					m_cls_sch_Personalized.vStart();
				}
			#endregion
			#region Running
				private bool bRunningSchedulerPersonalized()
				{
					return((m_cls_sch_Personalized != null) && (m_cls_sch_Personalized.Enabled));
				}
			#endregion
			#region Pause
				private void vPausePersonalizedScheduler()
				{
					if (m_cls_sch_Personalized != null)
						m_cls_sch_Personalized.Paused = true;
				}
			#endregion
			#region Continue
				private void vContinuePersonalizedScheduler()
				{
					if (m_cls_sch_Personalized != null)
						m_cls_sch_Personalized.Paused = false;
				}
			#endregion
			#region Stop
				private void vStopPersonalizedScheduler()
				{
					if (m_cls_sch_Personalized != null)
						m_cls_sch_Personalized.vStop();
				}
			#endregion
		#endregion
	}
}
