using System;

namespace mdlConversao.ValorExtenso
{
	/// <summary>
	/// Summary description for clsConverteValorExtenso.
	/// </summary>
	public sealed class clsConverteValorExtenso
	{
		#region Atributos
		private static int m_nIdIdioma = -1;
		private static int m_nIdMoeda = -1;
		#endregion

		#region Construtor Privado
		private clsConverteValorExtenso()
		{
		}
		#endregion

		#region Converte Valor
		public static string strConverteValorPorExtenso(double dValor, int nIdIdioma)
		{
			m_nIdIdioma = nIdIdioma;
			string strValorExtenso = "", strValorNumerico = dValor.ToString("F"), strValorTemporario = "";
			try
			{
				bool bUm = false;
				int nTamanhoDoValorNumerico = strValorNumerico.Length, nPosicaoAtualDeLeitura = 0, nPosicaoRealDeLeitura = 0;
				if (nTamanhoDoValorNumerico > 15)
					throw new Exception("Somente aceita conversão de número menores que 1000000000000,00");
				nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - 3) % 3);
				double dTeste = (((double)nTamanhoDoValorNumerico - 3) / 3);
				if (dTeste > 3)
				{// Bilhão
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
						{
							if (bUm)
								strValorExtenso += " bilhão, ";
							else
								strValorExtenso += " bilhões, ";
						}
						else if (m_nIdIdioma == 3)
						{
							strValorExtenso += " billion ";
						}
					}
					bUm = false;
				}
				if (dTeste > 2)
				{// Milhão
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
						{
							if (bUm)
								strValorExtenso += " milhão, ";
							else
								strValorExtenso += " milhões, ";
						}
						else if (m_nIdIdioma == 3)
						{
							strValorExtenso += " million ";
						}
					}
					bUm = false;
				}
				if (dTeste > 1)
				{// Mil
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
							strValorExtenso += " mil, ";
						else if (m_nIdIdioma == 3)
							strValorExtenso += " thousand ";
					}
					bUm = false;
				}
				if (dTeste > 0)
				{// Centena
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
					}
					bUm = false;
				}
				if ((strValorNumerico.Substring(nPosicaoRealDeLeitura, 1) == ",") || (strValorNumerico.Substring(nPosicaoRealDeLeitura, 1) == "."))
				{
					nPosicaoRealDeLeitura++;
					if (strValorNumerico.Substring(nPosicaoRealDeLeitura).Length == 2)
					{
						strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura);
						if (Int32.Parse(strValorTemporario) == 1)
							bUm = true;
						strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
						if (strValorTemporario.Trim() != "")
						{
							if (m_nIdIdioma == 1)
							{
								strValorExtenso += ", e " + strValorTemporario;
								if (bUm)
									strValorExtenso += " centavo";
								else
									strValorExtenso += " centavos";
							}
							else if (m_nIdIdioma == 3)
							{
								strValorExtenso += " and " + strValorTemporario;
								if (bUm)
									strValorExtenso += " cent";
								else
									strValorExtenso += " cents";
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				throw err;
			}
			return strValorExtenso;
		}
		public static string strConverteValorPorExtenso(double dValor, int nIdIdioma, int nIdMoeda)
		{
			m_nIdIdioma = nIdIdioma;
			m_nIdMoeda = nIdMoeda;
			string strValorExtenso = "", strValorNumerico = dValor.ToString("F"), strValorTemporario = "";
			try
			{
				bool bUm = false;
				int nTamanhoDoValorNumerico = strValorNumerico.Length, nPosicaoAtualDeLeitura = 0, nPosicaoRealDeLeitura = 0;
				if (nTamanhoDoValorNumerico > 15)
					throw new Exception("Somente aceita conversão de número menores que 1000000000000,00");
				nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - 3) % 3);
				double dTeste = (((double)nTamanhoDoValorNumerico - 3) / 3);
				if (dTeste > 3)
				{// Bilhão
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
						{
							if (bUm)
								strValorExtenso += " bilhão, ";
							else
								strValorExtenso += " bilhões, ";
						}
						else if (m_nIdIdioma == 3)
						{
							strValorExtenso += " billion ";
						}
					}
					bUm = false;
				}
				if (dTeste > 2)
				{// Milhão
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
						{
							if (bUm)
								strValorExtenso += " milhão, ";
							else
								strValorExtenso += " milhões, ";
						}
						else if (m_nIdIdioma == 3)
						{
							strValorExtenso += " million ";
						}
					}
					bUm = false;
				}
				if (dTeste > 1)
				{// Mil
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
						if (m_nIdIdioma == 1)
							strValorExtenso += " mil, ";
						else if (m_nIdIdioma == 3)
							strValorExtenso += " thousand ";
					}
					bUm = false;
				}
				if (dTeste > 0)
				{// Centena
					strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura, (nPosicaoAtualDeLeitura == 0 ? nPosicaoAtualDeLeitura = 3 : nPosicaoAtualDeLeitura));
					if (Int32.Parse(strValorTemporario) == 1)
						bUm = true;
					nPosicaoRealDeLeitura += nPosicaoAtualDeLeitura;
					nPosicaoAtualDeLeitura = ((nTamanhoDoValorNumerico - nPosicaoRealDeLeitura) % 3);
					switch (strValorTemporario.Length)
					{
						case 3: strValorTemporario = strRetornaCentenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 2: strValorTemporario = strRetornaDezenaExtenso(strValorTemporario).Replace("zero","");
							break;
						case 1: strValorTemporario = strRetornaUnidadeExtenso(strValorTemporario).Replace("zero","");
							break;
					}
					if (strValorTemporario.Trim() != "")
					{
						strValorExtenso += strValorTemporario;
					}
					if (m_nIdIdioma == 3)
					{
						if (bUm)
						{
							switch(m_nIdMoeda)
							{
								case 24: //Coroa Norueguesa
									strValorExtenso += " Norwegian Krone";
									break;
								case 25: //Coroa Sueca
									strValorExtenso += " Swidish Krone";
									break;
								case 26: //Dólar Australiano
									strValorExtenso += " Australian dollar";
									break;
								case 28: //Dólar dos Estados Unidos
									strValorExtenso += " US dollar";
									break;
								case 29: //Euro
									strValorExtenso += " Euro";
									break;
								case 31: //Iene Japonês
									strValorExtenso += " Yen";
									break;
								case 32: //Libra Esterlina
									strValorExtenso += " British Pound";
									break;
								case 33: //Dólar Canadense
									strValorExtenso += " Canadian dollar";
									break;
								case 34: //Franco Suíço
									strValorExtenso += " Swiss Frank";
									break;
							}
						}
						else
						{
							switch(m_nIdMoeda)
							{
								case 24: //Coroa Norueguesa
									strValorExtenso += " Norwegian Kroner";
									break;
								case 25: //Coroa Sueca
									strValorExtenso += " Swidish Kronor";
									break;
								case 26: //Dólar Australiano
									strValorExtenso += " Australian dollars";
									break;
								case 28: //Dólar dos Estados Unidos
									strValorExtenso += " US dollars";
									break;
								case 29: //Euro
									strValorExtenso += " Euros";
									break;
								case 31: //Iene Japonês
									strValorExtenso += " Yen";
									break;
								case 32: //Libra Esterlina
									strValorExtenso += " British Pounds";
									break;
								case 33: //Dólar Canadense
									strValorExtenso += " Canadian dollars";
									break;
								case 34: //Franco Suíço
									strValorExtenso += " Swiss Franken";
									break;
							}
						}
					}
					bUm = false;
				}
				if ((strValorNumerico.Substring(nPosicaoRealDeLeitura, 1) == ",") || (strValorNumerico.Substring(nPosicaoRealDeLeitura, 1) == "."))
				{
					nPosicaoRealDeLeitura++;
					if (strValorNumerico.Substring(nPosicaoRealDeLeitura).Length == 2)
					{
						strValorTemporario = strValorNumerico.Substring(nPosicaoRealDeLeitura);
						if (Int32.Parse(strValorTemporario) == 1)
							bUm = true;
						strValorExtenso += " " + strValorTemporario + "/100";
					}
				}
			}
			catch (Exception err)
			{
				throw err;
			}
			return strValorExtenso;
		}
		#endregion

		#region Unidade
		private static string strRetornaUnidadeExtenso(string strUnidade)
		{
			string strUnidadeExtenso = "";
			try
			{
				if (strUnidade.Length > 1)
					throw new Exception("Erro na conversão da unidade " + strUnidade);
				#region Português
				if (m_nIdIdioma == 1)
				{
					switch (Int32.Parse(strUnidade.Substring(0)))
					{
						case 0: strUnidadeExtenso = "zero";
							break;
						case 1: strUnidadeExtenso = "um";
							break;
						case 2: strUnidadeExtenso = "dois";
							break;
						case 3: strUnidadeExtenso = "tres";
							break;
						case 4: strUnidadeExtenso = "quatro";
							break;
						case 5: strUnidadeExtenso = "cinco";
							break;
						case 6: strUnidadeExtenso = "seis";
							break;
						case 7: strUnidadeExtenso = "sete";
							break;
						case 8: strUnidadeExtenso = "oito";
							break;
						case 9: strUnidadeExtenso = "nove";
							break;
					}
				}
				#endregion
				#region Inglês
				else if (m_nIdIdioma == 3)
				{
					switch (Int32.Parse(strUnidade.Substring(0)))
					{
						case 0: strUnidadeExtenso = "zero";
							break;
						case 1: strUnidadeExtenso = "one";
							break;
						case 2: strUnidadeExtenso = "two";
							break;
						case 3: strUnidadeExtenso = "three";
							break;
						case 4: strUnidadeExtenso = "four";
							break;
						case 5: strUnidadeExtenso = "five";
							break;
						case 6: strUnidadeExtenso = "six";
							break;
						case 7: strUnidadeExtenso = "seven";
							break;
						case 8: strUnidadeExtenso = "eight";
							break;
						case 9: strUnidadeExtenso = "nine";
							break;
					}
				}
				#endregion
			}
			catch (Exception err)
			{
				throw err;
			}
			return strUnidadeExtenso;
		}
		#endregion
		#region Dezena
		private static string strRetornaDezenaExtenso(string strDezena)
		{
			string strDezenaExtenso = "";
			try
			{
				if (strDezena.Length > 2)
					throw new Exception("Erro na conversão da dezena " + strDezena);
				#region Português
				if (m_nIdIdioma == 1)
				{
					switch (Int32.Parse(strDezena.Substring(0,1)))
					{
						case 0: strDezenaExtenso = strRetornaUnidadeExtenso(strDezena.Substring(1,1));
							break;
						case 1: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "dez ";
										break;
									case 1: strDezenaExtenso = "onze ";
										break;
									case 2: strDezenaExtenso = "doze ";
										break;
									case 3: strDezenaExtenso = "treze ";
										break;
									case 4: strDezenaExtenso = "quatorze ";
										break;
									case 5: strDezenaExtenso = "quinze ";
										break;
									case 6: strDezenaExtenso = "dezesseis ";
										break;
									case 7: strDezenaExtenso = "dezessete ";
										break;
									case 8: strDezenaExtenso = "dezoito ";
										break;
									case 9: strDezenaExtenso = "dezenove ";
										break;
								}
							break;
						case 2: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "vinte ";
										break;
									default: strDezenaExtenso = "vinte e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 3: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "trinta ";
										break;
									default: strDezenaExtenso = "trinta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 4: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "quarenta ";
										break;
									default: strDezenaExtenso = "quarenta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 5: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "cinquenta ";
										break;
									default: strDezenaExtenso = "cinquenta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 6: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "sessenta ";
										break;
									default: strDezenaExtenso = "sessenta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 7: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "setenta ";
										break;
									default: strDezenaExtenso = "setenta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 8: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "oitenta ";
										break;
									default: strDezenaExtenso = "oitenta e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 9: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "noventa ";
										break;
									default: strDezenaExtenso = "noventa e " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
					}
				}
				#endregion
				#region Inglês
				else if (m_nIdIdioma == 3)
				{
					switch (Int32.Parse(strDezena.Substring(0,1)))
					{
						case 0: strDezenaExtenso = strRetornaUnidadeExtenso(strDezena.Substring(1,1));
							break;
						case 1: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "ten ";
										break;
									case 1: strDezenaExtenso = "eleven ";
										break;
									case 2: strDezenaExtenso = "twelve ";
										break;
									case 3: strDezenaExtenso = "thirteen ";
										break;
									case 4: strDezenaExtenso = "fourteen ";
										break;
									case 5: strDezenaExtenso = "fifteen ";
										break;
									case 6: strDezenaExtenso = "sixteen ";
										break;
									case 7: strDezenaExtenso = "seventeen ";
										break;
									case 8: strDezenaExtenso = "eighteen ";
										break;
									case 9: strDezenaExtenso = "nineteen ";
										break;
								}
							break;
						case 2: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "twenty ";
										break;
									default: strDezenaExtenso = "twenty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 3: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "thirty ";
										break;
									default: strDezenaExtenso = "thirty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 4: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "fourty ";
										break;
									default: strDezenaExtenso = "fourty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 5: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "fifty ";
										break;
									default: strDezenaExtenso = "fifty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 6: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "sixty ";
										break;
									default: strDezenaExtenso = "sixty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 7: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "seventy ";
										break;
									default: strDezenaExtenso = "seventy " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 8: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "eighty ";
										break;
									default: strDezenaExtenso = "eighty " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
						case 9: switch (Int32.Parse(strDezena.Substring(1,1)))
								{
									case 0: strDezenaExtenso = "ninety ";
										break;
									default: strDezenaExtenso = "ninety " + strRetornaUnidadeExtenso(strDezena.Substring(1,1));
										break;
								}
							break;
					}
				}
				#endregion
			}
			catch (Exception err)
			{
				throw err;
			}
			if (strDezenaExtenso == "zero")
				strDezenaExtenso.Replace("zero","");
			return strDezenaExtenso;
		}
		#endregion
		#region Centena
		private static string strRetornaCentenaExtenso(string strCentena)
		{
			string strCentenaExtenso = "";
			try
			{
				if (strCentena.Length > 3)
					throw new Exception("Erro na conversão da centena " + strCentena);
				bool bTemDezena = (Int32.Parse(strCentena.Substring(1)) != 0 ? true : false);
				#region Português
				if (m_nIdIdioma == 1)
				{
					switch (Int32.Parse(strCentena.Substring(0,1)))
					{
						case 0: strCentenaExtenso = strRetornaDezenaExtenso(strCentena.Substring(1));
							break;
						case 1: if (bTemDezena)
									strCentenaExtenso = "cento e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "cem ";
							break;
						case 2: if (bTemDezena)
									strCentenaExtenso = "duzentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "duzentos ";
							break;
						case 3: if (bTemDezena)
									strCentenaExtenso = "trezentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "trezentos ";
							break;
						case 4: if (bTemDezena)
									strCentenaExtenso = "quatrocentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "quatrocentos ";
							break;
						case 5: if (bTemDezena)
									strCentenaExtenso = "quinhentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "quinhentos ";
							break;
						case 6: if (bTemDezena)
									strCentenaExtenso = "seiscentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "seiscentos ";
							break;
						case 7: if (bTemDezena)
									strCentenaExtenso = "setecentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "setecentos ";
							break;
						case 8: if (bTemDezena)
									strCentenaExtenso = "oitocentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "oitocentos ";
							break;
						case 9: if (bTemDezena)
									strCentenaExtenso = "novecentos e " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "novecentos ";
							break;
					}
				}
				#endregion
				#region Inglês
				else if (m_nIdIdioma == 3)
				{
					switch (Int32.Parse(strCentena.Substring(0,1)))
					{
						case 0: strCentenaExtenso = strRetornaDezenaExtenso(strCentena.Substring(1));
							break;
						case 1: if (bTemDezena)
									strCentenaExtenso = "one hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "one hundred ";
							break;
						case 2: if (bTemDezena)
									strCentenaExtenso = "two hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "two hundred ";
							break;
						case 3: if (bTemDezena)
									strCentenaExtenso = "three hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "three hundred ";
							break;
						case 4: if (bTemDezena)
									strCentenaExtenso = "four hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "four hundred ";
							break;
						case 5: if (bTemDezena)
									strCentenaExtenso = "five hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "five hundred ";
							break;
						case 6: if (bTemDezena)
									strCentenaExtenso = "six hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "six hundred ";
							break;
						case 7: if (bTemDezena)
									strCentenaExtenso = "seven hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "seven hundred ";
							break;
						case 8: if (bTemDezena)
									strCentenaExtenso = "eight hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "eight hundred ";
							break;
						case 9: if (bTemDezena)
									strCentenaExtenso = "nine hundred " + strRetornaDezenaExtenso(strCentena.Substring(1));
								else
									strCentenaExtenso = "nine hundred ";
							break;
					}
				}
				#endregion
			}
			catch (Exception err)
			{
				throw err;
			}
			if (strCentenaExtenso == "zero")
				strCentenaExtenso.Replace("zero","");
			return strCentenaExtenso;
		}
		#endregion
	}
}
