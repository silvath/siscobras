using System;

namespace SiscoMensagem
{
	/// <summary>
	/// Summary description for clsMessenger.
	/// </summary>
	public class clsMessenger
	{
		#region Atributes
			private string m_strHost = "127.0.0.1";
			private string m_strPathConfigFile = "";
			private int m_nPort = 9009;
			private bool m_bRunning = false;
			private int m_nSleep = 100;
		#endregion
		#region Constructors
			public clsMessenger(string strEnderecoExecutavel)
			{
				m_strPathConfigFile = strEnderecoExecutavel + "\\" + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME;
				vConfigure();
			}
		#endregion

		#region Configutarion
			private void vConfigure()
			{
				// Port
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_man_Current = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strPathConfigFile);
				string strPort =cls_man_Current.retornaValor(mdlConstantes.clsConstantes.SESSION_SISCOMENSAGEM,"PORT","9009");
				try
				{
					m_nPort = Int32.Parse(strPort);
				}catch{
					m_nPort = 9009;
				}
			}
		#endregion

		#region Server
			public string strListem()
			{
				m_bRunning = true;

				Byte[] byBuffer = new Byte[256];
				string strData = null;

				System.Net.Sockets.TcpListener tcplCurrent = null;
				try
				{
					tcplCurrent = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse(m_strHost),m_nPort);
				}catch{
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_CANRUN);
				}
				tcplCurrent.Start();
				while (m_bRunning)
				{
					if (tcplCurrent.Pending())
					{
						// Command
						System.Net.Sockets.TcpClient tcpcCurrent = tcplCurrent.AcceptTcpClient();
						System.Net.Sockets.NetworkStream nsCurrent = tcpcCurrent.GetStream();
						// Send Hello
						byBuffer = System.Text.Encoding.ASCII.GetBytes(strHello() + System.Environment.NewLine + System.Environment.NewLine);
						nsCurrent.Write(byBuffer, 0, byBuffer.Length);
						bool bExit = false;
						while (!bExit)
						{
							int i;
							try
							{
								strData = "";
								while(strData.IndexOf(System.Environment.NewLine + System.Environment.NewLine) == -1)
								{
									if ((i = nsCurrent.Read(byBuffer, 0, byBuffer.Length))!= 0)
										strData = strData + System.Text.Encoding.ASCII.GetString(byBuffer, 0, i);
								}
								strData = strData.Replace(System.Environment.NewLine + System.Environment.NewLine,"");
							}
							catch
							{
								strData = mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_CONNECTIONPROBLEM;
							}
							// Execute Command
							switch(strData)
							{
								// SiscoMensagem
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_EXIT:
									bExit = true;
									strData = mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS;
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STATE:
									if (m_bRunning)
										strData = mdlConstantes.clsConstantes.STATE_RUNNING;
									else
										strData = mdlConstantes.clsConstantes.STATE_STOPED;
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_HELP:
									strData = strHelp();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STOP:
									bExit = true;
									strData = strSiscoMensagemStop();
									break;

								// ControladoraMensagens
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START:
									strData = strControladoraMensagensStart();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE:
									strData = strControladoraMensagensPause();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE:
									strData = strControladoraMensagensContinue();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP:
									strData = strControladoraMensagensStop();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE:
									strData = strControladoraMensagensClose();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE:
									strData = strControladoraMensagensState();
									break;
								case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_UPDATE:
									strData = strControladoraMensagensUpdate();
									break;
								default:
									strData = mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_UNKNOWCOMMAND;
									break;
							}
							// Response 
							byBuffer = System.Text.Encoding.ASCII.GetBytes(strData + System.Environment.NewLine + System.Environment.NewLine);
							nsCurrent.Write(byBuffer, 0, byBuffer.Length);
						}
						nsCurrent.Close();
						tcpcCurrent.Close();
					}else{
						System.Windows.Forms.Application.DoEvents();
						System.Threading.Thread.Sleep(m_nSleep);
					}

				}
				tcplCurrent.Stop();
				return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
			}

			private string strHello()
			{
				string strReturn = "";
				strReturn += "**************************" + System.Environment.NewLine;
				strReturn += "Bem vindo ao SiscoMensagem" + System.Environment.NewLine;
				strReturn += "**************************" + System.Environment.NewLine;
				strReturn += "Digite '/HELP' + <Enter> + <Enter> para maiores informacoes" + System.Environment.NewLine;
				strReturn += "**************************";
				return(strReturn);
			}

			private string strHelp()
			{
				string strReturn = "";
				strReturn += "**************************" + System.Environment.NewLine;
				strReturn += "HELP do SiscoMensagem" + System.Environment.NewLine;
				strReturn += "**************************" + System.Environment.NewLine;
				strReturn += "   SiscoMensgem" + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_START + " -> Inicia o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_HELP + " -> Estas informacoes." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STOP + " -> Para o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STATE + " -> Estado do servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_EXIT + " -> Fecha a conexao." + System.Environment.NewLine;
				strReturn += "   Controladora Mensagens" + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START + " -> Inicia o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE + " -> Estado do servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE + " -> Pausa o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE + " -> Continua o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP + " -> Para o servico." + System.Environment.NewLine;
				strReturn += mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE + " -> Fecha o servico." + System.Environment.NewLine;
				strReturn += "**************************";
				return(strReturn);
			}
		#endregion
		#region Client
			public string strSendComand(string strCommand)
			{
				System.Net.Sockets.TcpClient tcpcCurrent;
				Byte[] byBuffer;
				try
				{
					tcpcCurrent = new System.Net.Sockets.TcpClient(m_strHost,m_nPort);
				}catch{
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_CANTCONNECT);
				}
				System.Net.Sockets.NetworkStream nsCurrent = tcpcCurrent.GetStream();
				while(!nsCurrent.DataAvailable)
				{
				}
				// Receive
				int i;
				string strResponse = "";
				byBuffer = new Byte[256];
				if ((i = nsCurrent.Read(byBuffer, 0, byBuffer.Length))!=0) 
					strResponse = System.Text.Encoding.ASCII.GetString(byBuffer, 0, i);

				// Send 
				byBuffer = System.Text.Encoding.ASCII.GetBytes(strCommand + System.Environment.NewLine + System.Environment.NewLine);         
				try
				{
					nsCurrent.Write(byBuffer, 0, byBuffer.Length);
				}catch{
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_CONNECTIONPROBLEM);
				}

				while(!nsCurrent.DataAvailable)
				{
				}
				// Receive
				i = 0;
				strResponse = "";
				byBuffer = new Byte[256];
				if ((i = nsCurrent.Read(byBuffer, 0, byBuffer.Length))!=0) 
					strResponse = System.Text.Encoding.ASCII.GetString(byBuffer, 0, i);


				// Send Exit
				try
				{
					byBuffer = System.Text.Encoding.ASCII.GetBytes(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_EXIT + System.Environment.NewLine + System.Environment.NewLine);
					nsCurrent.Write(byBuffer, 0, byBuffer.Length);
				}
				catch
				{
					return(strResponse);
				}

				// Close everything.
				tcpcCurrent.Close();
				return(strResponse);
			}
		#endregion

		#region SiscoMensagem
			#region Stop
				private string strSiscoMensagemStop()
				{
					strControladoraMensagensStop();
					if (!m_bRunning)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					m_bRunning = false;
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
		#endregion
		#region ControladoraMensagens
			#region State
				private string strControladoraMensagensState()
				{
					string strReturn = mdlConstantes.clsConstantes.STATE_UNKNOW;
					if (!mdlControladoraMensagens.clsControladoraMensagens.bExists())
						strReturn = mdlConstantes.clsConstantes.STATE_UNKNOW;
					switch(mdlControladoraMensagens.clsControladoraMensagens.New().State)
					{
						case mdlConstantes.SiscoMensagemState.Running:
							strReturn = mdlConstantes.clsConstantes.STATE_RUNNING;
							break;
						case mdlConstantes.SiscoMensagemState.Paused:
							strReturn = mdlConstantes.clsConstantes.STATE_PAUSED;
							break;
						case mdlConstantes.SiscoMensagemState.Stoped:
							strReturn = mdlConstantes.clsConstantes.STATE_STOPED;
							break;
						case mdlConstantes.SiscoMensagemState.Unknown:
							strReturn = mdlConstantes.clsConstantes.STATE_UNKNOW;
							break;
					}
					return(strReturn);
				}
			#endregion
			#region Update
				private string strControladoraMensagensUpdate()
				{
					if(mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						mdlControladoraMensagens.clsControladoraMensagens.New().vUpdate();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion

			#region Start
				private string strControladoraMensagensStart()
				{
					if(mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					mdlControladoraMensagens.clsControladoraMensagens.New().bStart();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
			#region Pause
				private string strControladoraMensagensPause()
				{
					if(!mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					if (mdlControladoraMensagens.clsControladoraMensagens.New().Paused)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					mdlControladoraMensagens.clsControladoraMensagens.New().bPause();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
			#region Continue
				private string strControladoraMensagensContinue()
				{
					if(!mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					if (!mdlControladoraMensagens.clsControladoraMensagens.New().Paused)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					mdlControladoraMensagens.clsControladoraMensagens.New().bContinue();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
			#region Stop
				private string strControladoraMensagensStop()
				{
					if(!mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
					mdlControladoraMensagens.clsControladoraMensagens.New().bStop();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
			#region Close
				private string strControladoraMensagensClose()
				{
					if (mdlControladoraMensagens.clsControladoraMensagens.New().Running)
						mdlControladoraMensagens.clsControladoraMensagens.New().bStop();
					mdlControladoraMensagens.clsControladoraMensagens.New().vClose();
					return(mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_SUCCESS);
				}
			#endregion
		#endregion
	}
}
