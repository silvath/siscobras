using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace wsSiscoMensagem
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class iSiscoMensagem : System.Configuration.Install.Installer
	{
		#region Atributes
			private System.ServiceProcess.ServiceProcessInstaller SiscoMensagemProcessInstaller;
			private System.ServiceProcess.ServiceInstaller SiscoMensagemInstaller;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public iSiscoMensagem()
			{
				InitializeComponent();
//				Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wsSiscoMensagem",true);
//				if (cKey != null)
//					if(cKey.GetValue("Type") != null)
//						cKey.SetValue("Type", ((int)cKey.GetValue("Type") | 256));
			}
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
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
				this.SiscoMensagemProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
				this.SiscoMensagemInstaller = new System.ServiceProcess.ServiceInstaller();
				// 
				// SiscoMensagemProcessInstaller
				// 
				this.SiscoMensagemProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
				this.SiscoMensagemProcessInstaller.Password = null;
				this.SiscoMensagemProcessInstaller.Username = null;
				// 
				// SiscoMensagemInstaller
				// 
				this.SiscoMensagemInstaller.DisplayName = "Serviço de mensagens do Siscobras Exporta Fácil";
				this.SiscoMensagemInstaller.ServiceName = "wsSiscoMensagem";
				this.SiscoMensagemInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
				// 
				// iSiscoMensagem
				// 
				this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																						  this.SiscoMensagemInstaller,
																						  this.SiscoMensagemProcessInstaller});

			}
		#endregion
	}
}
