using System;

namespace mdlValidacao
{
	/// <summary>
	/// Summary description for clsCNPJ.
	/// </summary>
	public sealed class clsCNPJ
	{
		#region Construtores & Destrutores
		private clsCNPJ()
		{
		}
		#endregion

		#region Valida CNPJ
		/// <summary>
		/// Método para validar um CNPJ
		/// </summary>
		/// <param name="strCNPJ">CNPJ no formato NN.NNN.NNN/NNNN-NN, onde N == Número</param>
		/// <returns>Retorna um booleano TRUE se CNPJ for válido e FALSE se CNPJ incorreto</returns>
		public static bool validaCNPJ(string strCNPJ)
		{
			try
			{
				int intSoma1 = 0, intSoma = 0, intSoma2 = 0, intMais = 0, intNumero = 0, intResto = 0, intDig1 = 0, intDig2 = 0;
				string strConf = "", strCampo = "", strCaracter = "", strCGC = "", strDigVer = "", strCNPJSohNumeros = "";
				if (strCNPJ.Length != 18)
				{
					return false;
				}
				else
				{
					for (int nCount = 0; nCount < strCNPJ.Length; nCount++)
					{
						if ((nCount != 2) && (nCount != 6) && (nCount != 10) && (nCount != 15))
						{
							strCNPJSohNumeros += strCNPJ[nCount];
						}
					}
					// Não entendi o que exatamente eh feito aqui, mas copiei igual ao código antigo!!!!!!!
					strDigVer = strCNPJSohNumeros.Substring(strCNPJSohNumeros.Length - 2);
					strCampo = strCNPJSohNumeros.Substring(0,8);
					strCGC = strCNPJSohNumeros.Substring(strCNPJSohNumeros.Length - 6, 4);
					strCampo = strCampo.Substring(strCampo.Length - 4) + strCGC;
					// O que está sendo feito neste loop é somar os numeros da posição
					// 4(3 em C#) ateh a 12(11 em C#), multiplicando pelo contador do laço
					// que vai de 2 a 9. Os números são lidos de trás pra frente!
					for (int nCount = 2; nCount < 10; nCount++)
					{
						strCaracter = strCampo.Substring(strCampo.Length - (nCount - 1), 1);
						intNumero = Int32.Parse(strCaracter);
						intMais = intNumero * nCount;
						intSoma1 += intMais;
					}
					// Separar os 4 primeiros números do CNPJ
					strCampo = strCNPJSohNumeros.Substring(0,4);
					for (int nCount = 2; nCount < 6; nCount++)
					{
						strCaracter = strCampo.Substring(strCampo.Length - (nCount - 1), 1);
						intNumero = Int32.Parse(strCaracter);
						intMais = intNumero * nCount;
						intSoma2 += intMais;
					}
					intSoma = intSoma1 + intSoma2;
					intResto = intSoma % 11;
					if ((intResto == 0) || (intResto == 1))
					{
						intDig1 = 0;
					}
					else
					{
						intDig1 = 11 - intResto;
					}
					// Zerando variáveis.....................
					intSoma = 0;
					intSoma1 = 0;
					intSoma2 = 0;
					intNumero = 0;
					intMais = 0;
					// Vai entender.......................
					strCampo = strCNPJSohNumeros.Substring(0,8);
					strCGC = strCNPJSohNumeros.Substring(strCNPJSohNumeros.Length - 6, 4);
					strCampo = strCampo.Substring(strCampo.Length - 3) + strCGC + intDig1.ToString();
					// O que está sendo feito neste loop é somar os numeros da posição
					// 4(3 em C#) ateh a 12(11 em C#), multiplicando pelo contador do laço
					// que vai de 2 a 9. Os números são lidos de trás pra frente!
					for (int nCount = 2; nCount < 10; nCount++)
					{
						strCaracter = strCampo.Substring(strCampo.Length - (nCount - 1), 1);
						intNumero = Int32.Parse(strCaracter);
						intMais = intNumero * nCount;
						intSoma1 += intMais;
					}
					// Separar os 5 primeiros números do CNPJ
					strCampo = strCNPJSohNumeros.Substring(0,5);
					for (int nCount = 2; nCount < 7; nCount++)
					{
						strCaracter = strCampo.Substring(strCampo.Length - (nCount - 1), 1);
						intNumero = Int32.Parse(strCaracter);
						intMais = intNumero * nCount;
						intSoma2 += intMais;
					}
					intSoma = intSoma1 + intSoma2;
					intResto = intSoma % 11;
					if ((intResto == 0) || (intResto == 1))
					{
						intDig2 = 0;
					}
					else
					{
						intDig2 = 11 - intResto;
					}
					strConf = intDig1.ToString() + intDig2.ToString();
					if (strConf == strDigVer)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch
			{
				return false;
			}
		}
		#endregion
		#region Check CNPJ
		public static bool bCheckCNPJ(string strCNPJ)
		{
			if (strCNPJ.Length != 18)
				return (false);
			strCNPJ = strCNPJ.Replace(".","");
			strCNPJ = strCNPJ.Replace("-","");
			strCNPJ = strCNPJ.Replace("/","");
			return ((clsModuloOnze.bCheckModula11(strCNPJ.Substring(0,strCNPJ.Length -1),true))
			&& ((clsModuloOnze.bCheckModula11(strCNPJ,true))));
		}
		#endregion
	}
}
