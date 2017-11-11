using System;

namespace SiscoMensagem
{
	/// <summary>
	/// Summary description for clsMain.
	/// </summary>
	public class clsMain
	{
		#region MAIN
			[STAThread]
			static void Main(string[] strArgs) 
			{
				int nExit = 0;
				string strReturn = "";
				int nProcessCount = System.Diagnostics.Process.GetProcessesByName(mdlConstantes.clsConstantes.APPLICATION_SISCOMENSAGEM_PROCESS).Length;
				if ((strArgs.Length > 0) && (nProcessCount <= 2))
				{
					clsMessenger objMessenger = new clsMessenger(System.Environment.CurrentDirectory);
					switch(strArgs[0].ToUpper())
					{
						// SiscoMensagem
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_START:
							if (nProcessCount == 1)
								strReturn = objMessenger.strListem();
							else
								strReturn = mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_ALREDYRUNNING;
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STATE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STATE);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STOP:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_STOP);
							break;

						// Controladora Mensagens
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_START);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_PAUSE);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CONTINUE);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STOP);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_CLOSE);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_STATE);
							break;
						case mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_UPDATE:
							strReturn = objMessenger.strSendComand(mdlConstantes.clsConstantes.COMMAND_SISCOMENSAGEM_CONTROLADORAMENSAGENS_UPDATE);
							break;
						default:
							strReturn = mdlConstantes.clsConstantes.RESPONSE_SISCOMENSAGEM_ERROR_UNKNOWCOMMAND;
							break;
					}
					if (strReturn.Length > 3)
						nExit = Int32.Parse(strReturn.Substring(0,3));
				}
				// Show
				if ((strArgs.Length > 1) && (strArgs[1].ToUpper() == "/SHOW"))
					System.Windows.Forms.MessageBox.Show(strReturn);
				System.Environment.Exit(nExit);
			}
		#endregion
	}
}
