using System;

namespace mdlControladoraImagens
{
	#region Enum
	public enum LOCALIMAGEM { FORMFIXO = 0, ASSISTENTE = 1, PREFERENCIAS = 2, SPLASH = 3, REGISTRO = 4 };
	#endregion
	/// <summary>
	/// Summary description for clsControladoraImagens.
	/// </summary>
	public sealed class clsControladoraImagens
	{
		#region Atributos
		private static string m_strLinkInternetImagem = "";
		public static string LINKINTERNET
		{
			get
			{
				return m_strLinkInternetImagem;
			}
		}
		private static string m_strToolTipImagem = "";
		public static string TOOLTIPIMAGEM
		{
			get
			{
				return m_strToolTipImagem;
			}
		}
		#endregion

		#region Construtores & Destrutores
		private clsControladoraImagens()
		{
		}
		#endregion

		#region Retorna Imagem
		public static System.Drawing.Image retornaImagem(LOCALIMAGEM localImagem)
		{
			System.Drawing.Image objRetorno = null;
			try
			{
				switch(localImagem)
				{
					case LOCALIMAGEM.FORMFIXO:
						objRetorno = mdlBannersFormFixos.clsBannersFormFixo.retornaImagem();
						m_strLinkInternetImagem = mdlBannersFormFixos.clsBannersFormFixo.LINK;
						m_strToolTipImagem = mdlBannersFormFixos.clsBannersFormFixo.TOOLTIP;
						break;
					case LOCALIMAGEM.ASSISTENTE:
						objRetorno = mdlBannersAssistente.clsBannersAssistente.retornaImagem();
						m_strLinkInternetImagem = mdlBannersAssistente.clsBannersAssistente.LINK;
						m_strToolTipImagem = mdlBannersAssistente.clsBannersAssistente.TOOLTIP;
						break;
					case LOCALIMAGEM.PREFERENCIAS:
						objRetorno = mdlBannersPreferencias.clsBannersPreferencias.retornaImagem();
						m_strLinkInternetImagem = mdlBannersPreferencias.clsBannersPreferencias.LINK;
						m_strToolTipImagem = mdlBannersPreferencias.clsBannersPreferencias.TOOLTIP;
						break;
					case LOCALIMAGEM.SPLASH:
						objRetorno = mdlImagensSplash.clsImagensSplash.retornaImagem();
						break;
					case LOCALIMAGEM.REGISTRO:
						objRetorno = mdlImagensRegistro.clsImagensRegistro.retornaImagem();
						m_strLinkInternetImagem = mdlImagensRegistro.clsImagensRegistro.LINK;
						m_strToolTipImagem = mdlImagensRegistro.clsImagensRegistro.TOOLTIP;
						break;
				}
			}
			catch
			{
			}
			return objRetorno;
		}
		public static System.Drawing.Image retornaImagem(LOCALIMAGEM localImagem, int nIdImagem)
		{
			System.Drawing.Image objRetorno = null;
			try
			{
				switch(localImagem)
				{
					case LOCALIMAGEM.REGISTRO:
						objRetorno = mdlImagensRegistro.clsImagensRegistro.retornaImagem(nIdImagem);
						m_strLinkInternetImagem = mdlImagensRegistro.clsImagensRegistro.LINK;
						m_strToolTipImagem = mdlImagensRegistro.clsImagensRegistro.TOOLTIP;
						break;
				}
			}
			catch
			{
			}
			return objRetorno;
		}
		#endregion
	}
}
