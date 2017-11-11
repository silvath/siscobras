using System;

namespace Siscobras
{
	public class clsMAIN
	{
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] strArgs) 
		{
			clsSiscobras Siscobras = new clsSiscobras();
			foreach(string strArg in strArgs)
			{
				switch(strArg.Trim().ToUpper())
				{
					case "/SENDERRORS":
						Siscobras.SendErrors = true;
						break;
					case "/UPDATEDB":
						Siscobras.UpdateDB = true;
						break;
					case "/CHANGEDB":
						Siscobras.ChangeDB = true;
						break;
					case "/DEVELOPMODE":
						Siscobras.DevelopMode = true;
						break;
					case "/SILENT":
						Siscobras.Silent = true;
						break;
					case "/EXIT":
						Siscobras.Exit = true;
						break;
					case "/INFO":
						Siscobras.Info = true;
						break;
					case "/REGISTRYRESEND":
						Siscobras.RegistryReSend = true;
						break;
					case "/REGISTRYKILL":
						Siscobras.RegistryKill = true;
						break;
					case "/CONSOLE":
						Siscobras.Console = true;
						break;
					case "/PROXY":
						Siscobras.Proxy = true;
						break;
					case "/INTERNET":
						Siscobras.Internet = true;
						break;
					case "/HELP":
					case "/?":
                        Siscobras.Help = true;
						break;
					default: // Parametros com Parametros
						if (strArg.ToUpper().StartsWith("/VC:"))
							Siscobras.VCNew = strArg.Substring(4);
						if (strArg.ToUpper().StartsWith("/VS:"))
							Siscobras.VSNew = strArg.Substring(4);

						if (strArg.ToUpper().StartsWith("/PROXYHOST:"))
							Siscobras.ProxyHost = strArg.Substring(11);
						if (strArg.ToUpper().StartsWith("/PROXYPORT:"))
							Siscobras.ProxyPort = strArg.Substring(11);
						if (strArg.ToUpper().StartsWith("/PROXYUSER:"))
							Siscobras.ProxyUser = strArg.Substring(11);
						if (strArg.ToUpper().StartsWith("/PROXYPASSWORD:"))
							Siscobras.ProxyPassword = strArg.Substring(15);
						break;
				}
			}

			bool bControl =((System.Windows.Forms.Form.ModifierKeys & System.Windows.Forms.Keys.Control) == System.Windows.Forms.Keys.Control);
			bool bShift = ((System.Windows.Forms.Form.ModifierKeys & System.Windows.Forms.Keys.Shift) == System.Windows.Forms.Keys.Shift);
			bool bAlt = ((System.Windows.Forms.Form.ModifierKeys & System.Windows.Forms.Keys.Alt) == System.Windows.Forms.Keys.Alt);

			if (bControl && !bShift && !bAlt)
				Siscobras.DevelopMode = true;
			if (bControl && bShift && !bAlt)
				Siscobras.UpdateDB = true;
			if (!bControl && bShift && !bAlt)
				Siscobras.ChangeDB = true;
			if (bControl && !bShift && bAlt)
				Siscobras.RestoreDB = true;
		
			Siscobras.ShowDialog();
		}
		#endregion
	}
}
