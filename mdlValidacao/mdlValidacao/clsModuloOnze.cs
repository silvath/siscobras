using System;

namespace mdlValidacao
{
	/// <summary>
	/// Summary description for clsModuloOnze.
	/// </summary>
	public sealed class clsModuloOnze
	{
		#region Static
			public static int m_nDigitoVerificadorDefault = 0;
		#endregion
		#region Construtor
		private clsModuloOnze()
		{
		}
		#endregion

		#region Modulo 11
		public static int calculaModuloOnze(string strDigitos)
		{
			try
			{
				int nRetorno = 0, nMultiplicador = 2, nSoma = 0;
				for (int nCount = strDigitos.Length - 1; nCount >= 0; nCount--)
				{
					nSoma += (Int32.Parse(strDigitos[nCount].ToString()) * nMultiplicador);
					if (nMultiplicador == 9)
						nMultiplicador = 2;
					else
						nMultiplicador++;
				}
				nRetorno = nSoma % 11;
				if ((nRetorno == 0) || (nRetorno == 1))
					nRetorno = 0;
				else
					nRetorno = 11 - nRetorno;
				return(nRetorno);
			}
			catch (Exception err)
			{
				throw(err);
			}
		}
		#endregion
		#region Modula 11
			public static bool bCheckModula11(string strNumbers,bool bMaxNine)
			{
				if (strNumbers.Length > 1)
				{
					return(strNumbers.Substring(strNumbers.Length - 1,1) == nReturnModula11(strNumbers.Substring(0,strNumbers.Length - 1),bMaxNine).ToString());
				}
				else
				{
					return(false);
				}
			}

			public static int nReturnModula11(string strNumbers,bool bMaxNine)
			{
				int nSum = 0,nMulp = 1;
				for (int nCont = strNumbers.Length - 1; nCont >= 0;nCont--)
				{
					nMulp++;
					if (bMaxNine)
						if (nMulp > 9)
							nMulp = 2; 
					nSum += (Int32.Parse(strNumbers[(nCont)].ToString()) * nMulp);
				}
				if ((11 - (nSum % 11)) > 9)
					return(m_nDigitoVerificadorDefault);
				else
					return((11 - (nSum % 11)));
			}
		#endregion
	}
}
