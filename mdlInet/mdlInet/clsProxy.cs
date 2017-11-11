using System;

namespace mdlInet
{
	/// <summary>
	/// Summary description for clsProxy.
	/// </summary>
	public class clsProxy
	{
		#region Constants
			private const string DATASET_NAME = "Siscobras";
			private const string DATASET_PROXY_NAME = "Proxy";
			private const string DATASET_HOST_NAME = "Host";
			private const string DATASET_PORT_NAME = "Port";
			private const string DATASET_USER_NAME = "User";
			private const string DATASET_PASSWORD_NAME = "Password";
		#endregion
		#region Atributes
			private string m_strFileConfigPath = ".\\";
			private string m_strFileConfigName = "Proxy.xml";
		#endregion
		#region Constructor and Destructors
			public clsProxy()
			{
			}

			public clsProxy(string strFileConfigPath)
			{
				m_strFileConfigPath = strFileConfigPath;
			}

			public clsProxy(string strFileConfigPath,string strFileConfigName)
			{
				m_strFileConfigPath = strFileConfigPath;
				m_strFileConfigName = strFileConfigName;
			}
		#endregion

		#region Proxy
			public void vSetProxy()
			{
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
							if (strHost != "")
							{
								System.Net.WebProxy wbpxProxy = new System.Net.WebProxy(strHost,Int32.Parse(strPort));
								if (strUser != "")
								{
									System.Net.NetworkCredential ntcr = new System.Net.NetworkCredential(strUser,strPassword);
									wbpxProxy.Credentials = ntcr;
								}
								System.Net.GlobalProxySelection.Select = wbpxProxy;
							}
						}
					}catch
					{
					}
				}
			}

			public void vSetProxy(string strHost,string strPort,string strUser,string strPassword)
			{
				strHost = strHost.Trim();
				strPort = strPort.Trim();
				strUser = strUser.Trim();
				strPassword = strPassword.Trim();
				try
				{
					if ((strHost != "") && (strPort != ""))
					{
						System.Net.WebProxy wbpxProxy = new System.Net.WebProxy(strHost,Int32.Parse(strPort));
						if (strUser != "")
						{
							System.Net.NetworkCredential ntcr = new System.Net.NetworkCredential(strUser,strPassword);
							wbpxProxy.Credentials = ntcr;
						}
						System.Net.GlobalProxySelection.Select = wbpxProxy;
					}
				}catch{

				}
			}
		#endregion
	}
}

