using System;

namespace SiscoConfig
{
	/// <summary>
	/// Summary description for clsConfig.
	/// </summary>
	public class clsConfig
	{
		#region Constants
			private const string APPNAME = "Siscobras.exe";
			
			private const string DATASET_NAME = "Siscobras";
			private const string DATASET_PROXY_NAME = "Proxy";
			private const string DATASET_HOST_NAME = "Host";
			private const string DATASET_PORT_NAME = "Port";
			private const string DATASET_USER_NAME = "User";
			private const string DATASET_PASSWORD_NAME = "Password";
		#endregion
		#region Atributes
			private string m_strFileConfigPath = System.Environment.CurrentDirectory + "\\";
			private string m_strFileConfigName = "Proxy.xml";
		#endregion
		#region Constructors and Destructors
			public clsConfig()
			{
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				frmFConfig formFConfig = new frmFConfig();
				vInitializeEvents(ref formFConfig);
				formFConfig.ShowDialog();
			}
			
			private void vInitializeEvents(ref frmFConfig formFConfig)
			{
				// Carrega Dados Internet
				formFConfig.eCallCarregaDadosInternet += new SiscoConfig.frmFConfig.delCallCarregaDadosInternet(bCarregaDadosInternet);

				// Salva Dados Internet
				formFConfig.eCallSalvaDadosInternet += new SiscoConfig.frmFConfig.delCallSalvaDadosInternet(bSalvaDadosInternet);

				// Siscobras
				formFConfig.eCallSiscobras += new SiscoConfig.frmFConfig.delCallSiscobras(vSiscobrasOpen);
			}
		#endregion

		#region Carrega Dados
			private bool bCarregaDadosInternet(out bool bProxy,out string strProxyHost,out string strProxyPort,out bool bProxyAutentication,out string strProxyUser,out string strProxyPassword)
			{
				bool bRetorno = true;
				
				bProxy = bProxyAutentication = false;
				strProxyHost = strProxyPort = strProxyUser = strProxyPassword = "";

				if (System.IO.File.Exists(m_strFileConfigPath + m_strFileConfigName))
				{
					System.Data.DataSet dtstProxy = new System.Data.DataSet();
					try
					{
						dtstProxy.ReadXml(m_strFileConfigPath + m_strFileConfigName);
						if (dtstProxy.Tables[DATASET_PROXY_NAME].Rows.Count > 0)
						{
							string strHost = "";
							string strPort = "";
							string strUser = "";
							string strPassword = "";
							if (dtstProxy.Tables[DATASET_PROXY_NAME].Columns[DATASET_HOST_NAME] != null)
								strHost = dtstProxy.Tables[DATASET_PROXY_NAME].Rows[0][DATASET_HOST_NAME].ToString();
							if (dtstProxy.Tables[DATASET_PROXY_NAME].Columns[DATASET_PORT_NAME] != null)
								strPort = dtstProxy.Tables[DATASET_PROXY_NAME].Rows[0][DATASET_PORT_NAME].ToString();
							if (dtstProxy.Tables[DATASET_PROXY_NAME].Columns[DATASET_USER_NAME] != null)
								strUser = dtstProxy.Tables[DATASET_PROXY_NAME].Rows[0][DATASET_USER_NAME].ToString();
							if (dtstProxy.Tables[DATASET_PROXY_NAME].Columns[DATASET_PASSWORD_NAME] != null)
								strPassword = dtstProxy.Tables[DATASET_PROXY_NAME].Rows[0][DATASET_PASSWORD_NAME].ToString();
							if (bProxy = (strHost != ""))
							{
								strProxyHost = strHost;
								strProxyPort = strPort;
								if (bProxyAutentication = (strUser != ""))
								{
									strProxyUser = strUser;
									strProxyPassword = strPassword;
								}
							}
						}
					}
					catch
					{
						bRetorno = false;
					}
				}
				return(bRetorno);
			}
		#endregion
		#region Salva Dados
			private bool bSalvaDadosInternet(bool bProxy,string strProxyHost,string strProxyPort,bool bProxyAutentication,string strProxyUser,string strProxyPassword)
			{
				bool bRetorno = true;
				System.Data.DataSet dtstProxy = new System.Data.DataSet(DATASET_NAME);
				System.Data.DataTable dttbProxy = new System.Data.DataTable(DATASET_PROXY_NAME);
				dttbProxy.Columns.Add(DATASET_HOST_NAME);
				dttbProxy.Columns.Add(DATASET_PORT_NAME);
				dttbProxy.Columns.Add(DATASET_USER_NAME);
				dttbProxy.Columns.Add(DATASET_PASSWORD_NAME);
				dtstProxy.Tables.Add(dttbProxy);

				System.Data.DataRow dtrwProxy = dttbProxy.NewRow();
				dtrwProxy[DATASET_HOST_NAME] = strProxyHost;
				dtrwProxy[DATASET_PORT_NAME] = strProxyPort;
				dtrwProxy[DATASET_USER_NAME] = strProxyUser;
				dtrwProxy[DATASET_PASSWORD_NAME] = strProxyPassword;
				dttbProxy.Rows.Add(dtrwProxy);
				
				try{
					dtstProxy.WriteXml(m_strFileConfigPath + m_strFileConfigName);
				}catch{
					bRetorno = false;
				}
				return(bRetorno);
			}
		#endregion

		#region Siscobras
			private void vSiscobrasOpen()
			{
				if (System.IO.File.Exists(m_strFileConfigPath + APPNAME))
				{
					System.Diagnostics.Process proc = new System.Diagnostics.Process();
					proc.StartInfo = new System.Diagnostics.ProcessStartInfo (m_strFileConfigPath + APPNAME);
					proc.StartInfo.WorkingDirectory = m_strFileConfigPath;
					proc.Start();
				}
			}
		#endregion
	}
}
