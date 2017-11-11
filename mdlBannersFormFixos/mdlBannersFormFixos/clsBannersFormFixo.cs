using System;

namespace mdlBannersFormFixos
{
	/// <summary>
	/// Summary description for clsBannersFormFixo.
	/// </summary>
	public sealed class clsBannersFormFixo
	{
		#region Limites
		private static int LIMITEMINIMO = 1;
		private static int LIMITEMAXIMO = 2;
		#endregion
		#region Constantes
		private const int CENTRALDOEXPORTADOR1 = 1;
		private const int CENTRALDOEXPORTADOR2 = 2;
		#endregion

		#region Link
		private static string m_strLinkInternet = "";
		public static string LINK
		{
			get
			{
				return m_strLinkInternet;
			}
		}
		#endregion
		#region ToolTip
		private static string m_strToolTip = "";
		public static string TOOLTIP
		{
			get
			{
				return m_strToolTip;
			}
		}
		#endregion

		#region Construtores & Destrutores
		private clsBannersFormFixo()
		{
		}
		#endregion

		#region RetornaImagem
		public static System.Drawing.Image retornaImagem()
		{
			string strBannerName = "bImg";
			System.Random objRdm = new System.Random();
			int nIdIndiceImagem = objRdm.Next(LIMITEMINIMO,LIMITEMAXIMO + 1);
			linkInternetEToolTip(nIdIndiceImagem);
			strBannerName += nIdIndiceImagem.ToString();
			System.Drawing.Image imgRetorno = null;
			System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
			string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
			foreach(string strCurrent in arrStrAssembly)
			{
				if (("MDLBANNERSFORMFIXOS.IMAGENS." + strBannerName.ToUpper()) == strCurrent.Substring(0, strCurrent.Length - 4).ToUpper())
				{
					System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
					imgRetorno = System.Drawing.Image.FromStream(stmResource);
					break;
				}
			}
			return(imgRetorno);
		}
		#endregion

		#region LinkInternet
		private static void linkInternetEToolTip(int nIdImagem)
		{
			switch(nIdImagem)
			{
				case CENTRALDOEXPORTADOR1: // 1
					m_strLinkInternet = "http://www.centraldoexportador.com.br/";
					m_strToolTip = "Visite o site";
					break;
				case CENTRALDOEXPORTADOR2: // 2
					m_strLinkInternet = "http://www.centraldoexportador.com.br/";
					m_strToolTip = "Visite o site";
					break;
				default:
					m_strLinkInternet = "http://www.siscobras.com.br/";
					m_strToolTip = "Visite o site";
					break;
			}
		}
		#endregion
	}
}
