using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace wsSiscoMensagem
{
	public class wsSiscoMensagem : System.ServiceProcess.ServiceBase
	{
		#region Atributes
			private string m_strApplicationSiscoMensagemPath = "";

			private System.ComponentModel.Container components = null;
			private System.Diagnostics.EventLog m_elSiscoMensagem;
		#endregion
		#region Constructors and Destructors
			public wsSiscoMensagem()
			{
				InitializeComponent();
				if (!System.Diagnostics.EventLog.SourceExists("SiscoMensagem")) 
					System.Diagnostics.EventLog.CreateEventSource("SiscoMensagem","Siscobras");
				m_elSiscoMensagem.Source = "SiscoMensagem";
				m_elSiscoMensagem.Log = "Siscobras";
			}

			protected override void Dispose( bool disposing ) 
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion
		#region Component Designer generated code
			/// <summary> 
			/// Required method for Designer support - do not modify 
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				this.m_elSiscoMensagem = new System.Diagnostics.EventLog();
				((System.ComponentModel.ISupportInitialize)(this.m_elSiscoMensagem)).BeginInit();
				// 
				// wsSiscoMensagem
				// 
				this.CanPauseAndContinue = true;
				this.ServiceName = "wsSiscoMensagem";
				((System.ComponentModel.ISupportInitialize)(this.m_elSiscoMensagem)).EndInit();

			}
		#endregion

		#region MAIN
			static void Main()
			{
				System.ServiceProcess.ServiceBase[] ServicesToRun;
				ServicesToRun = new System.ServiceProcess.ServiceBase[] { new wsSiscoMensagem() };
				System.ServiceProcess.ServiceBase.Run(ServicesToRun);
			}
		#endregion

		#region SiscoMensagem
			private mdlControladoraWindowsServices.clsManagerWSSiscoMensagem clsManagerSiscoMensagem()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objReturn = null;
				string strPath = "";
				try
				{
					Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Siscobras\Siscobras",false);
					if (cKey != null)
						strPath = cKey.GetValue("Path","").ToString();
					if (strPath != "")
					{
						objReturn = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(strPath + "\\");
						objReturn.AlwaysApp = true;
					}
				}catch{
					objReturn = null;
				}
				return(objReturn);
			}
		#endregion

		#region OnStart
			protected override void OnStart(string[] args)
			{
				string strLog = "###OnStart###";
				base.OnStart(args);
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objManagerSiscoMensagem = clsManagerSiscoMensagem();
				if (objManagerSiscoMensagem != null)
					objManagerSiscoMensagem.bStart();
				m_elSiscoMensagem.WriteEntry(strLog);
			}
		#endregion
		#region OnPause
			protected override void OnPause()
			{
				string strLog = "###OnPause###";
				base.OnPause ();
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objManagerSiscoMensagem = clsManagerSiscoMensagem();
				if (objManagerSiscoMensagem != null)
					objManagerSiscoMensagem.bPause();
				m_elSiscoMensagem.WriteEntry(strLog);
			}
		#endregion
		#region OnContinue
			protected override void OnContinue()
			{
				string strLog = "###OnContinue###";
				base.OnContinue ();
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objManagerSiscoMensagem = clsManagerSiscoMensagem();
				if (objManagerSiscoMensagem != null)
					objManagerSiscoMensagem.bContinue();
				m_elSiscoMensagem.WriteEntry(strLog);
			}
		#endregion
		#region OnStop
			protected override void OnStop()
			{
				string strLog = "###OnStop###";
				base.OnStop();
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objManagerSiscoMensagem = clsManagerSiscoMensagem();
				if (objManagerSiscoMensagem != null)
				{
					objManagerSiscoMensagem.bStop();
					objManagerSiscoMensagem.bClose();
				}
				m_elSiscoMensagem.WriteEntry(strLog);
			}
		#endregion
		#region OnShutdown
			protected override void OnShutdown()
			{
				string strLog = "###OnShutdown###";
				base.OnShutdown ();
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objManagerSiscoMensagem = clsManagerSiscoMensagem();
				if (objManagerSiscoMensagem != null)
					objManagerSiscoMensagem.bStop();
				m_elSiscoMensagem.WriteEntry(strLog);
			}
		#endregion
	}
}
