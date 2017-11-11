using System;

namespace mdlValidacao
{
	/// <summary>
	/// Summary description for clsCPF.
	/// </summary>
	public class clsCPF
	{
		#region Construtor
		private clsCPF()
		{
		}
		#endregion
		#region Valida CPF
		/// <summary>
		/// Método para validar um CPF
		/// </summary>
		/// <param name="strCPF">CPF no formato NNN.NNN.NNN-NN, onde N == Número</param>
		/// <returns>Retorna um booleano TRUE se CPF for válido e FALSE se CPF incorreto</returns>
		public static bool validaCPF(string strCPF)
		{
			try
			{
				string strCPFSohNumeros = "", strDigVer = "", strCampo = "", strDigitosVerificados = "";
				int nDigitoCalculado = -1;
				if (strCPF.Length != 14)
				{
					return false;
				}
				else
				{
					for (int nCount = 0; nCount < strCPF.Length; nCount++)
					{
						if ((nCount != 3) && (nCount != 7) && (nCount != 11))
						{
							strCPFSohNumeros += strCPF[nCount];
						}
					}
					strDigVer = strCPFSohNumeros.Substring(strCPFSohNumeros.Length - 2);
					strCampo = strCPFSohNumeros.Substring(0, 9);
					nDigitoCalculado = clsModuloOnze.calculaModuloOnze(strCampo);
					strDigitosVerificados = nDigitoCalculado.ToString();
					strCampo += strDigitosVerificados;
					nDigitoCalculado = clsModuloOnze.calculaModuloOnze(strCampo);
					strDigitosVerificados += nDigitoCalculado.ToString();
					if (strDigitosVerificados == strDigVer)
						return true;
					else
						return false;
				}
			}
			catch 
			{
				return false;
			}
		}
		#endregion
		#region Check CPF
			public static bool bCheckCPF(string strCPF)
			{
				if (strCPF.Length != 14)
					return (false);
				strCPF = strCPF.Replace(".","");
				strCPF = strCPF.Replace("-","");
				return ((clsModuloOnze.bCheckModula11(strCPF.Substring(0,strCPF.Length -1),false))
				&& ((clsModuloOnze.bCheckModula11(strCPF,false))));
			}
		#endregion
	}
}
