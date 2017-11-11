using System;

namespace SiscoBDConexao
{
	/// <summary>
	/// Summary description for clsSiscoBDConexao.
	/// </summary>
	public class clsSiscoBDConexao
	{
		#region Constantes
		#endregion
		#region Atributos
			private string m_strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";
			private frmSiscoBDConexao m_formSiscoBDConexao = null;
		#endregion
		#region Constructors 
			public clsSiscoBDConexao()
			{
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				m_formSiscoBDConexao = new frmSiscoBDConexao();

				m_formSiscoBDConexao.eCallServidor += new SiscoBDConexao.frmSiscoBDConexao.delCallServidor(ServidorExiste);
				m_formSiscoBDConexao.eCallServidorSqlServer += new SiscoBDConexao.frmSiscoBDConexao.delCallServidorSqlServer(ServidorSqlServerExiste);
				m_formSiscoBDConexao.eCallServidorSqlServerAdmin += new SiscoBDConexao.frmSiscoBDConexao.delCallServidorSqlServerAdmin(ServidorSqlServerExisteAdmin);
				m_formSiscoBDConexao.eCallServidorSqlServerWindows += new SiscoBDConexao.frmSiscoBDConexao.delCallServidorSqlServerWindows(ServidorSqlServerExisteWindows);


				m_formSiscoBDConexao.ShowDialog();
				return(false);
			}
		#endregion

		#region Servidor
			private string ServidorExiste(string strHost)
			{
				try
				{
					System.Net.IPHostEntry ipheInfo = System.Net.Dns.GetHostByAddress(strHost);
					strHost = ipheInfo.HostName;
					return("Sucesso: Maquina servidora encontrada");
				}
				catch
				{
					return("Falha: Impossivel encontrar maquina servidora.");
				}
			}
		#endregion
		#region Servidor SqlServer
			private string ServidorSqlServerExiste(string strHost, string strPort,string strUser, string strPassword)
			{
				string strStringConnnection = "Server=" + strHost + ";Database=master;Integrated Security=false;User ID=" + strUser + ";" + "Password=" + strPassword + ";";
				System.Data.SqlClient.SqlConnection scServer = new System.Data.SqlClient.SqlConnection(strStringConnnection);
				try
				{
					scServer.Open();
					if (scServer.State == System.Data.ConnectionState.Open)
					{
						scServer.Close();
						return("Sucesso: Servidor SQLServer Encontrado");
					}
					else
					{
						return("Falha: Não foi possivel abrir a conexao com o Servidor");
					}
				}
				catch(System.Exception e)
				{
					string strRetorno = "ServidorSqlServerExiste " + System.Environment.NewLine;
					strRetorno = strRetorno + "ConnectionString: " + scServer.ConnectionString + System.Environment.NewLine;
					strRetorno = strRetorno + "Falha: " + e.ToString();
					return(strRetorno);
				}
			}

			private string ServidorSqlServerExisteAdmin(string strHost, string strPort, string strAdminUser, string strAdminPassword)
			{
				string strStringConnnection = "Server=" + strHost + ";Database=master;Integrated Security=false;User ID=" + strAdminUser + ";" + "Password=" + strAdminPassword + ";";
				System.Data.SqlClient.SqlConnection scServer = new System.Data.SqlClient.SqlConnection(strStringConnnection);
				try
				{
					scServer.Open();
					if (scServer.State == System.Data.ConnectionState.Open)
					{
						scServer.Close();
						return("Sucesso: Servidor SQLServer Encontrado");
					}
					else
					{
						return("Falha: Não foi possivel abrir a conexao com o Servidor");
					}
				}
				catch(System.Exception e)
				{
					string strRetorno = "ServidorSqlServerExisteAdmin " + System.Environment.NewLine;
					strRetorno = strRetorno + "ConnectionString: " + scServer.ConnectionString + System.Environment.NewLine;
					strRetorno = strRetorno + "Falha: " + e.ToString();
					return(strRetorno);
				}
			}

			private string ServidorSqlServerExisteWindows(string strHost, string strPort)
			{
				string strStringConnnection = "Server=" + strHost + ";Database=master;Integrated Security=SSPI;";
				System.Data.SqlClient.SqlConnection scServer = new System.Data.SqlClient.SqlConnection(strStringConnnection);
				try
				{
					scServer.Open();
					if (scServer.State == System.Data.ConnectionState.Open)
					{
						scServer.Close();
						return("Sucesso: Servidor SQLServer Encontrado");
					}
					else
					{
						return("Falha: Não foi possivel abrir a conexao com o Servidor");
					}
				}
				catch(System.Exception e)
				{
					string strRetorno = "ServidorSqlServerExisteWindows" + System.Environment.NewLine;
					strRetorno = strRetorno + "ConnectionString: " + scServer.ConnectionString + System.Environment.NewLine;
					strRetorno = strRetorno + "Falha: " + e.ToString();
					return(strRetorno);
				}
			}
		#endregion
	}
}
