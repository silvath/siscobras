using System;

namespace mdlImagensSplash
{
	/// <summary>
	/// Summary description for clsImagensSplash.
	/// </summary>
	public sealed class clsImagensSplash
	{
		#region Limites
		private static int LIMITEMINIMO = 1;
		private static int LIMITEMAXIMO = 1;
		#endregion

		#region Construtores & Destrutores
		private clsImagensSplash()
		{
		}
		#endregion

		#region RetornaImagem
		public static System.Drawing.Image retornaImagem()
		{
			string strBannerName = "bImg";
			System.Random objRdm = new System.Random(System.DateTime.Now.Second);
			strBannerName += objRdm.Next(LIMITEMINIMO,LIMITEMAXIMO + 1).ToString();
			System.Drawing.Image imgRetorno = null;
			System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
			string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
			foreach(string strCurrent in arrStrAssembly)
			{
				if (("MDLIMAGENSSPLASH.IMAGENS." + strBannerName.ToUpper()) == strCurrent.Substring(0, strCurrent.Length - 4).ToUpper())
				{
					System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
					imgRetorno = System.Drawing.Image.FromStream(stmResource);
					break;
				}
			}
			return(imgRetorno);
		}
		#endregion
	}
}
