using System;

namespace mdlControladoraWindowsServices
{
	/// <summary>
	/// Summary description for clsManagerWSSiscoMensagem.
	/// </summary>
	public class clsManagerWSSiscoMensagem
	{
		#region Atributes
			private string m_strEnderecoExecutavel = "";
			private string m_strAppInstallUtil = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + "InstallUtil.exe"; 
			private static bool m_bAlwaysApp = false;
			private int m_nSecondsBeforeExit = 3000;
		#endregion
		#region Properties
			#region Always
				public bool AlwaysApp
				{
					set
					{
						m_bAlwaysApp = value;
					}
				}
			#endregion
			#region Initialization
				public mdlConstantes.SiscoMensagemInit Initialization
				{
					get
					{
						if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
							return(InitializationRegistry);
						else
							return(InitializationWindowsService);
					}
					set
					{
						if (clsManagerWindowsService.bWindowsServiceSupport())
							InitializationWindowsService = value;
						else
							InitializationRegistry = value;
					}
				}

				private mdlConstantes.SiscoMensagemInit InitializationWindowsService
				{
					get
					{
						if (bWindowsServiceInstaled())
						{
							try
							{
								Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_NAME,true);
								if (cKey == null)
									return(mdlConstantes.SiscoMensagemInit.Never);
								if ((cKey.GetValue("Start",null)) == null)
									return(mdlConstantes.SiscoMensagemInit.Never);
								switch((int)cKey.GetValue("Start",null))
								{
									case 2:
										return(mdlConstantes.SiscoMensagemInit.ComputerStartup);
									case 3:
										return(mdlConstantes.SiscoMensagemInit.Siscobras);
									default:
										return(mdlConstantes.SiscoMensagemInit.Never);
								}
							}
							catch
							{
								return(mdlConstantes.SiscoMensagemInit.Never);
							}
						}
						else
						{
							return(mdlConstantes.SiscoMensagemInit.Never);
						}
					}
					set
					{
						switch(value)
						{
							case mdlConstantes.SiscoMensagemInit.Never:
								if (bWindowsServiceInstaled())
									bWindowsServiceUninstall();
								break;
							case mdlConstantes.SiscoMensagemInit.Siscobras:
							case mdlConstantes.SiscoMensagemInit.ComputerStartup:
								if (!bWindowsServiceInstaled())
									bWindowsServiceInstall();
								if (bWindowsServiceInstaled())
								{
									try
									{
										int nValue = 2;
										if (value == mdlConstantes.SiscoMensagemInit.Siscobras)
											nValue = 3;
										Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_NAME,true);
										if (cKey != null)
											cKey.SetValue("Start",nValue);
									}
									catch
									{

									}
								}
								break;
						}
					}
				}

				private mdlConstantes.SiscoMensagemInit InitializationRegistry
				{
					get
					{
						try
						{
							Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Siscobras\Siscobras",true);
							if (cKey == null)
								return(mdlConstantes.SiscoMensagemInit.Never);
							return((mdlConstantes.SiscoMensagemInit)cKey.GetValue(mdlConstantes.clsConstantes.REGISTRY_SISCOMENSAGEM_INIT,mdlConstantes.SiscoMensagemInit.Never));
						}catch{
							return(mdlConstantes.SiscoMensagemInit.Never);
						}
					}
					set
					{
						int nValue = (int)value;
						Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Siscobras\Siscobras",true);
						if (cKey != null)
							cKey.SetValue(mdlConstantes.clsConstantes.REGISTRY_SISCOMENSAGEM_INIT,nValue);
					}
				}
			#endregion
			#region State
				public mdlConstantes.SiscoMensagemState State
				{
					get
					{
						if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
							return(StateRegistry);
						else
							return(StateWindowsService);
					}
				}
				private mdlConstantes.SiscoMensagemState StateWindowsService
				{
					get
					{
						if (!bWindowsServiceInstaled())
							return(mdlConstantes.SiscoMensagemState.Unknown);

						mdlConstantes.SiscoMensagemState enumReturn = mdlConstantes.SiscoMensagemState.Unknown;
						System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
						if (scSiscoMensagem != null)
						{
							switch(scSiscoMensagem.Status)
							{
								case System.ServiceProcess.ServiceControllerStatus.Running:
									enumReturn = mdlConstantes.SiscoMensagemState.Running;
									break;
								case System.ServiceProcess.ServiceControllerStatus.Paused:
									enumReturn = mdlConstantes.SiscoMensagemState.Paused;
									break;
								case System.ServiceProcess.ServiceControllerStatus.Stopped:
									enumReturn = mdlConstantes.SiscoMensagemState.Stoped;
									break;
								case System.ServiceProcess.ServiceControllerStatus.ContinuePending:
								case System.ServiceProcess.ServiceControllerStatus.PausePending:
								case System.ServiceProcess.ServiceControllerStatus.StartPending:
								case System.ServiceProcess.ServiceControllerStatus.StopPending:
									System.Threading.Thread.Sleep(5000);
									enumReturn = this.State;
									break;
							}
						}
						return(enumReturn);
					}
				}

				private mdlConstantes.SiscoMensagemState StateRegistry
				{
					get
					{
						mdlConstantes.SiscoMensagemState enumReturn = mdlConstantes.SiscoMensagemState.Unknown;
						if(System.Diagnostics.Process.GetProcessesByName(mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_PROCESS).Length == 0)
							return(mdlConstantes.SiscoMensagemState.Stoped);
						switch(nSiscoMensagemStatus())
						{
							case mdlConstantes.clsConstantes.ID_STATE_RUNNING:
								enumReturn = mdlConstantes.SiscoMensagemState.Running;
								break;
							case mdlConstantes.clsConstantes.ID_STATE_PAUSED:
								enumReturn = mdlConstantes.SiscoMensagemState.Paused;
								break;
							case mdlConstantes.clsConstantes.ID_STATE_STOPED:
								enumReturn = mdlConstantes.SiscoMensagemState.Stoped;
								break;
						}
						return(enumReturn);
					}
				}

				public mdlConstantes.SiscoMensagemState StateControladoraMensagens
				{
					get
					{
						mdlConstantes.SiscoMensagemState enumReturn = mdlConstantes.SiscoMensagemState.Unknown;
						switch(nSiscoMensagemControladoraMensagensStatus())
						{
							case mdlConstantes.clsConstantes.ID_STATE_RUNNING:
								enumReturn = mdlConstantes.SiscoMensagemState.Running;
								break;
							case mdlConstantes.clsConstantes.ID_STATE_PAUSED:
								enumReturn = mdlConstantes.SiscoMensagemState.Paused;
								break;
							case mdlConstantes.clsConstantes.ID_STATE_STOPED:
								enumReturn = mdlConstantes.SiscoMensagemState.Stoped;
								break;
						}
						return(enumReturn);
					}
				}
			#endregion	
		#endregion
		#region Constructors and Destructors
			public clsManagerWSSiscoMensagem(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Install and Uninstall
			public bool bInstaled()
			{
				if (clsManagerWindowsService.bWindowsServiceSupport())
					return(bWindowsServiceInstaled());
				else
					return(bRegistryInstaled());
			}

			public bool bInstall()
			{
				if (clsManagerWindowsService.bWindowsServiceSupport())
					return(bWindowsServiceInstall());
				else
					return(bRegistryInstall());
			}

			public bool bUninstall()
			{
				if (clsManagerWindowsService.bWindowsServiceSupport())
					return(bWindowsServiceUninstall());
				else
					return(bRegistryUninstall());
			}
		#endregion
		#region WindowsService
			#region Running
				public static bool bServiceRunning()
				{
					return(clsManagerWindowsService.bServiceRunning(mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_NAME));
				}
			#endregion
			#region Search
				private System.ServiceProcess.ServiceController scReturnSiscoMensagem()
				{
					System.ServiceProcess.ServiceController[] scWindowsServices = System.ServiceProcess.ServiceController.GetServices(System.Environment.MachineName);
					foreach(System.ServiceProcess.ServiceController scCurrentService in scWindowsServices)
					{
						if (scCurrentService.ServiceName == mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_NAME)
							return(scCurrentService);
					}
					return(null);
				}
			#endregion
			#region Install and Uninstall
				private bool bWindowsServiceInstaled()
				{
					return(scReturnSiscoMensagem() != null);
				}

				private bool bWindowsServiceInstall()
				{
					try
					{
						if (bWindowsServiceInstaled())
							return(true);

						if (!System.IO.File.Exists(m_strAppInstallUtil))
							return(false);

                 		System.Diagnostics.Process proInstallUtil = new System.Diagnostics.Process();
						proInstallUtil.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strAppInstallUtil," \"" + m_strEnderecoExecutavel + mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_FILENAME + "\"");
						proInstallUtil.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
						proInstallUtil.Start();
						proInstallUtil.WaitForExit();
						vInitializeRegistryToInteractWithDesktop();
						return(bWindowsServiceInstaled());
					}
					catch
					{
						return(false);
					}
				}
				private bool bWindowsServiceUninstall()
				{
					try
					{
						bCloseRegistry();

						if (!bWindowsServiceInstaled())
							return(true);

						if (!System.IO.File.Exists(m_strAppInstallUtil))
							return(false);

						System.Diagnostics.Process proInstallUtil = new System.Diagnostics.Process();
						proInstallUtil.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strAppInstallUtil," /u \"" + m_strEnderecoExecutavel + mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_FILENAME + "\"");
						proInstallUtil.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
						proInstallUtil.Start();
						proInstallUtil.WaitForExit();
						System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
						return(!bWindowsServiceInstaled());
					}
					catch
					{
						return(false);
					}
				}
			#endregion
			#region Allow Service to Interact with Desktop
				private void vInitializeRegistryToInteractWithDesktop()
				{
					try
					{
						System.Management.ConnectionOptions coOptions = new System.Management.ConnectionOptions();
						coOptions.Impersonation = System.Management.ImpersonationLevel.Impersonate;
						System.Management.ManagementScope mgmtScope = new System.Management.ManagementScope(@"root\CIMV2", coOptions);
						mgmtScope.Connect();
						System.Management.ManagementObject wmiService;
						wmiService = new System.Management.ManagementObject("Win32_Service.Name='" + mdlConstantes.clsConstantes.WINDOWSSERVICE_SISCOMENSAGEM_NAME + "'");
						System.Management.ManagementBaseObject InParam = wmiService.GetMethodParameters("Change");
						InParam["DesktopInteract"] = true;
						System.Management.ManagementBaseObject OutParam = wmiService.InvokeMethod("Change", InParam, null);
					}
					catch
					{
						// Cant access the registry
					}
				}
			#endregion
		#endregion
		#region Registry
			#region Install and Uninstall
				private bool bRegistryInstaled()
				{
					try
					{
						Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",false);
						if (cKey != null)
							return((cKey.GetValue(mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME,null)) != null);
						else
							return(false);
					}
					catch
					{
						return(false);
					}
				}

				private bool bRegistryInstall()
				{
					try
					{
						if (bRegistryInstaled())
							return(true);
						Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);
						if (cKey != null)
							cKey.SetValue(mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME,m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						return(bRegistryInstaled());
					}catch{
						return(false);
					}
				}

				public bool bRegistryUninstall()
				{
					try
					{
						if (!bWindowsServiceInstaled())
							return(true);
						Microsoft.Win32.RegistryKey cKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",false);
						if (cKey != null)
							cKey.DeleteValue(mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						return(!bRegistryInstaled());
					}
					catch
					{
						return(false);
					}
				}
			#endregion
			#region Execute
				private void vSiscoMensagemExecute(string strArgs)
				{
					if (System.IO.File.Exists(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME))
					{
						System.Diagnostics.Process proSiscoMensagem = new System.Diagnostics.Process();
						proSiscoMensagem.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						proSiscoMensagem.StartInfo.Arguments = strArgs;
						proSiscoMensagem.Start();
					}
				}

				private int nSiscoMensagemExecute(string strArgs)
				{
					if (System.IO.File.Exists(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME))
					{
						System.Diagnostics.Process proSiscoMensagem = new System.Diagnostics.Process();
						proSiscoMensagem.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						proSiscoMensagem.StartInfo.Arguments = strArgs;
						proSiscoMensagem.Start();
						proSiscoMensagem.WaitForExit(m_nSecondsBeforeExit);
						if (proSiscoMensagem.HasExited)
							return(proSiscoMensagem.ExitCode);
						else
						return(0);
					}else{
						return(0);
					}
				}

				private int nSiscoMensagemStatus()
				{
					int nReturn = mdlConstantes.clsConstantes.ID_STATE_UNKNOW;
					if (System.IO.File.Exists(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME))
					{
						System.Diagnostics.Process proSiscoMensagem = new System.Diagnostics.Process();
						proSiscoMensagem.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						proSiscoMensagem.StartInfo.Arguments = mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STATE;
						proSiscoMensagem.Start();
						proSiscoMensagem.WaitForExit(10000);
						if (proSiscoMensagem.HasExited)
							nReturn = proSiscoMensagem.ExitCode;
					}
					return(nReturn);
				}

				private int nSiscoMensagemControladoraMensagensStatus()
				{
					int nReturn = mdlConstantes.clsConstantes.ID_STATE_UNKNOW;
					if (StateRegistry != mdlConstantes.SiscoMensagemState.Running)
						return(mdlConstantes.clsConstantes.ID_STATE_STOPED);
					if (System.IO.File.Exists(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME))
					{
						System.Diagnostics.Process proSiscoMensagem = new System.Diagnostics.Process();
						proSiscoMensagem.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_FILENAME);
						proSiscoMensagem.StartInfo.Arguments = mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE;
						proSiscoMensagem.Start();
						proSiscoMensagem.WaitForExit(10000);
						if (proSiscoMensagem.HasExited)
							nReturn = proSiscoMensagem.ExitCode;
					}
					return(nReturn);
				}
			#endregion	
		#endregion

		#region SiscoMensagem
			#region Start
				public bool bStart()
				{
					if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
						return(bStartRegistry());
					else
						return(bStartWindowsService());
				}

				private bool bStartSiscoMensagem()
				{
					if (((int)StateRegistry) != mdlConstantes.clsConstantes.ID_STATE_RUNNING)
					{
						nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_START);
						return((((int)StateRegistry) == mdlConstantes.clsConstantes.ID_STATE_RUNNING));
					}else{
						return(true);
					}
				}

				private bool bStartWindowsService()
				{
					if (!bWindowsServiceInstaled())
						bWindowsServiceInstall();
					if (!bWindowsServiceInstaled())
						return(false);
					System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
					switch(scSiscoMensagem.Status)
					{
						case System.ServiceProcess.ServiceControllerStatus.StopPending:
						case System.ServiceProcess.ServiceControllerStatus.Stopped:
							try
							{
								scSiscoMensagem.Start();
							}catch{
								return(false);
							}
							break;
					}
					return(this.State == mdlConstantes.SiscoMensagemState.Running);
				}

				private bool bStartRegistry()
				{
					if (bStartSiscoMensagem())
					{
						if (((int)StateControladoraMensagens) != mdlConstantes.clsConstantes.ID_STATE_RUNNING)
							return((nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START) == mdlConstantes.clsConstantes.ID_STATE_RUNNING));
						return(StateControladoraMensagens == mdlConstantes.SiscoMensagemState.Running);
					}else{
						return(false);
					}
				}
			#endregion
			#region Pause
				public bool bPause()
				{
					if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
						return(bPauseRegistry());
					else
						return(bPauseWindowsService());
				}

				private bool bPauseWindowsService()
				{
					if (!bWindowsServiceInstaled())
						bWindowsServiceInstall();
					if (!bWindowsServiceInstaled())
						return(false);

					System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
					switch(scSiscoMensagem.Status)
					{
						case System.ServiceProcess.ServiceControllerStatus.StartPending:
						case System.ServiceProcess.ServiceControllerStatus.Running:
							try
							{
								scSiscoMensagem.Pause();
							}catch{
								return(false);
							}
							break;
					}
					return(this.State == mdlConstantes.SiscoMensagemState.Paused);
				}

				private bool bPauseRegistry()
				{
					if (bStartSiscoMensagem())
					{
						if (((int)StateControladoraMensagens) == mdlConstantes.clsConstantes.ID_STATE_RUNNING)
							return(nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE) == mdlConstantes.clsConstantes.ID_STATE_PAUSED);
						return(StateControladoraMensagens == mdlConstantes.SiscoMensagemState.Paused);
					}else{
						return(false);
					}
				}
			#endregion
			#region Continue
				public bool bContinue()
				{
					if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
						return(bContinueRegistry());
					else
						return(bContinueWindowsService());
				}

				private bool bContinueWindowsService()
				{
					if (!bWindowsServiceInstaled())
						bWindowsServiceInstall();
					if (!bWindowsServiceInstaled())
						return(false);

					System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
					switch(scSiscoMensagem.Status)
					{
						case System.ServiceProcess.ServiceControllerStatus.PausePending:
						case System.ServiceProcess.ServiceControllerStatus.Paused:
							try
							{
								scSiscoMensagem.Continue();
							}catch{
								return(false);
							}
							break;
					}
					return(this.State == mdlConstantes.SiscoMensagemState.Running);
				}

				private bool bContinueRegistry()
				{
					if (bStartSiscoMensagem())
					{
						if (((int)StateControladoraMensagens) == mdlConstantes.clsConstantes.ID_STATE_PAUSED)
							return(nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE) == mdlConstantes.clsConstantes.ID_STATE_RUNNING);
						return(StateControladoraMensagens == mdlConstantes.SiscoMensagemState.Running);
					}else{
						return(false);
					}
				}
			#endregion
			#region Stop
				public bool bStop()
				{
					if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
						return(bStopRegistry());
					else
						return(bStopWindowsService());
				}

				private bool bStopWindowsService()
				{
					if (!bWindowsServiceInstaled())
						bWindowsServiceInstall();
					if (!bWindowsServiceInstaled())
						return(false);
					System.ServiceProcess.ServiceController scSiscoMensagem = scReturnSiscoMensagem();
					switch(scSiscoMensagem.Status)
					{
						case System.ServiceProcess.ServiceControllerStatus.ContinuePending:
						case System.ServiceProcess.ServiceControllerStatus.Running:
						case System.ServiceProcess.ServiceControllerStatus.StartPending:
						case System.ServiceProcess.ServiceControllerStatus.Paused:
						case System.ServiceProcess.ServiceControllerStatus.PausePending:
							try
							{
								scSiscoMensagem.Stop();
							}catch{
								return(false);
							}
							break;
					}
					return(this.State == mdlConstantes.SiscoMensagemState.Stoped);
				}

				private bool bStopRegistry()
				{
					if (((int)StateControladoraMensagens) != mdlConstantes.clsConstantes.ID_STATE_STOPED)
						return(nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP) == mdlConstantes.clsConstantes.ID_STATE_STOPED);
					return(StateControladoraMensagens == mdlConstantes.SiscoMensagemState.Stoped);
				}
			#endregion
			#region Close
				public bool bClose()
				{
					if ((!clsManagerWindowsService.bWindowsServiceSupport()) || (m_bAlwaysApp))
						return(bCloseRegistry());
					else
						return(bCloseWindowsService());
				}

				private bool bCloseWindowsService()
				{
					bStop();
					bCloseRegistry();
					return(true);
				}

				private bool bCloseRegistry()
				{
					nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE);
					nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STOP);
					return(true);
				}
			#endregion
			#region Update
				public void vUpdate()
				{
					try
					{
						if (((int)StateRegistry) == mdlConstantes.clsConstantes.ID_STATE_RUNNING)
							nSiscoMensagemExecute(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_UPDATE);
					}catch{
						//TODO: Ocorreu um problema na Lince neste metodo em: 26/08/2005
					}
				}
			#endregion
		#endregion
	}
}
