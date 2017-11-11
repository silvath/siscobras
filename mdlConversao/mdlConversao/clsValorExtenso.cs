using System;

namespace mdlConversao
{
	/// <summary>
	/// Summary description for clsValorExtenso.
	/// </summary>
	public class clsValorExtenso
	{
		#region Constantes
			// Moedas
			private const int ID_MOEDA_COROA_NORUEGUESA = 24;
			private const int ID_MOEDA_COROA_SUECA = 25;
			private const int ID_MOEDA_DOLAR_AUSTRALIANO = 26;
			private const int ID_MOEDA_DOLAR_CANADENSE = 33;
			private const int ID_MOEDA_DOLAR_ESTADOS_UNIDOS = 28; 
		    private const int ID_MOEDA_EURO = 29;
			private const int ID_MOEDA_FRANCO_SUICO = 34;
			private const int ID_MOEDA_IENE_JAPONES = 31;
			private const int ID_MOEDA_LIBRA_ESTERLINA = 32;

			private const int ID_IDIOMA_PORTUGUES = 1;
			private const int ID_IDIOMA_INGLES = 3;
			private const string COD_PORTUGUES = "pt-BR";
			private const string COD_INGLES = "en-US";

			private const int FRACIONARIA = 0;
			private const int UNIDADE = 1;
			private const int MILHAR = 2;
			private const int MILHAO = 3;
			private const int BILHAR = 4;
		#endregion
		#region RetornaValorExtenso
		public static string strRetornaValorExtenso(double dValor,int nIdMoeda)
		{
			return(strRetornaValorExtenso(dValor,ID_IDIOMA_PORTUGUES,nIdMoeda));
		}

		public static string strRetornaValorExtenso(double dValor,string strIdioma_Glob,int nIdMoeda)
		{
			string strRetorno = "";
			switch(strIdioma_Glob)
			{
				case COD_PORTUGUES:
					strRetorno = strRetornaValorExtenso(dValor,ID_IDIOMA_PORTUGUES,nIdMoeda);
					break;
				case COD_INGLES:
					strRetorno = strRetornaValorExtenso(dValor,ID_IDIOMA_INGLES,nIdMoeda);
					break;
			}
			return(strRetorno);
		}

		public static string strRetornaValorExtenso(double dValor,int nIdIdioma,int nIdMoeda)
		{
            string strRetorno = "";
			string strValor = "";

			// Formating 
			if (dValor > 1000)
				strValor = dValor.ToString("0,000.00000000");
			else
				strValor = dValor.ToString("0.00000000");
			int nUnidadeAtual = nRetornaUnidadeMaxima(strValor);
			while(nUnidadeAtual >= 0)
			{
				string strValorAtual = strRetornaValor(strValor,nUnidadeAtual);
				switch(nUnidadeAtual)
				{
					case BILHAR:
						switch(strValorAtual.Length)
						{
							case 1:
								strRetorno = strRetorno + " " + strRetornaTextoUnidade(strValorAtual,nIdIdioma);
								break;
							case 2:
								strRetorno = strRetorno + " " + strRetornaTextoDezena(strValorAtual,nIdIdioma);
								break;
							case 3:
								strRetorno = strRetorno + " " + strRetornaTextoCentena(strValorAtual,nIdIdioma);
								break;
						}
						strRetorno = strRetorno + " " + strRetornaTextoBilhao(strValorAtual,nIdIdioma);
						break;
					case MILHAO:
						switch(strValorAtual.Length)
						{
							case 1:
								strRetorno = strRetorno + " " + strRetornaTextoUnidade(strValorAtual,nIdIdioma);
								break;
							case 2:
								strRetorno = strRetorno + " " + strRetornaTextoDezena(strValorAtual,nIdIdioma);
								break;
							case 3:
								strRetorno = strRetorno + " " + strRetornaTextoCentena(strValorAtual,nIdIdioma);
								break;
						}
						strRetorno = strRetorno + " " + strRetornaTextoMilhao(strValorAtual,nIdIdioma);
						break;
					case MILHAR:
						switch(strValorAtual.Length)
						{
							case 1:
								strRetorno = strRetorno + " " + strRetornaTextoUnidade(strValorAtual,nIdIdioma);
								break;
							case 2:
								strRetorno = strRetorno + " " + strRetornaTextoDezena(strValorAtual,nIdIdioma);
								break;
							case 3:
								strRetorno = strRetorno + " " + strRetornaTextoCentena(strValorAtual,nIdIdioma);
								break;
						}
						strRetorno = strRetorno + " " + strRetornaTextoMilhar(strValorAtual,nIdIdioma);
						break;
					case UNIDADE:
						switch(strValorAtual.Length)
						{
							case 1:
								strRetorno = strRetorno + " " + strRetornaTextoUnidade(strValorAtual,nIdIdioma);
								break;
							case 2:
								strRetorno = strRetorno + " " + strRetornaTextoDezena(strValorAtual,nIdIdioma);
								break;
							case 3:
								strRetorno = strRetorno + " " + strRetornaTextoCentena(strValorAtual,nIdIdioma);
								break;
						}
						strRetorno = strRetorno + " " + strRetornaTextoUnitario(strValorAtual,nIdIdioma,nIdMoeda);
						break;
					case FRACIONARIA:
						if ((strRetorno != "") && (nIdIdioma == ID_IDIOMA_PORTUGUES) && (strValorAtual.Length > 0) && (strValorAtual != "0") && (strValorAtual != "00"))
							strRetorno = strRetorno + " e";
						if ((strValorAtual.Length > 0) && (strValorAtual != "0") && (strValorAtual != "00"))
							strRetorno = strRetorno + " " + strValorAtual + "/100";
//						switch(strValorAtual.Length)
//						{
//							case 1:
//								strRetorno = strRetorno + " " + strRetornaTextoUnidade(strValorAtual,nIdIdioma);
//								if (strValorAtual != "0")
//									strRetorno = strRetorno + " " + strRetornaTextoCentavos(strValorAtual,nIdIdioma);
//								break;
//							case 2:
//								strRetorno = strRetorno + " " + strRetornaTextoDezena(strValorAtual,nIdIdioma);
//								strRetorno = strRetorno + " " + strRetornaTextoCentavos(strValorAtual,nIdIdioma);
//								break;
//							case 3:
//								strRetorno = strRetorno + " " + strRetornaTextoCentena(strValorAtual,nIdIdioma);
//								strRetorno = strRetorno + " " + strRetornaTextoCentavos(strValorAtual,nIdIdioma);
//								break;
//						}
						break;
				}
				nUnidadeAtual--;
			}
			return(strRetorno);
		}
		#endregion

		#region Aux Methods
			private static int nRetornaUnidadeMaxima(string strValor)
			{
				int nUnidadeMaxima = UNIDADE;
				char[] Char = new char[] {'.'};
				int nPonto = strValor.Split(Char).Length;
				if (nPonto == 0)
				{
					if (strValor.IndexOf(",") != -1)
						nUnidadeMaxima = FRACIONARIA;
				}
				else
					nUnidadeMaxima = nPonto;
				return(nUnidadeMaxima);
			}

			private static string strRetornaValor(string strValor,int nUnidade)
			{
				string strRetorno = "";
				if (nUnidade != FRACIONARIA)
				{
					char[] Char = new char[] {'.'};
					if (strValor.IndexOf(",") != -1)
						strValor = strValor.Substring(0,strValor.IndexOf(","));
					string[] strSplit = strValor.Split(Char);
					strRetorno = strSplit[strSplit.Length - nUnidade];
				}else{
					int nIndexVirgula = strValor.IndexOf(",");
					if (nIndexVirgula >= 0)
					{
						strRetorno = strValor.Substring(nIndexVirgula + 1);
						while((strRetorno.EndsWith("0")) && (strRetorno.Length > 2))
							strRetorno = strRetorno.Substring(0,strRetorno.Length - 1);
					}
				}
				return(strRetorno);
			}
		#endregion

		#region Unidade
			private static string strRetornaTextoUnidade(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						switch(strValor)
						{
							case "1":
								strRetorno = "um";
								break;
							case "2":
								strRetorno = "dois";
								break;
							case "3":
								strRetorno = "três";
								break;
							case "4":
								strRetorno = "quatro";
								break;
							case "5":
								strRetorno = "cinco";
								break;
							case "6":
								strRetorno = "seis";
								break;
							case "7":
								strRetorno = "sete";
								break;
							case "8":
								strRetorno = "oito";
								break;
							case "9":
								strRetorno = "nove";
								break;
						}
					break;
					case ID_IDIOMA_INGLES:
					switch(strValor)
					{
						case "1":
							strRetorno = "one";
							break;
						case "2":
							strRetorno = "two";
							break;
						case "3":
							strRetorno = "three";
							break;
						case "4":
							strRetorno = "four";
							break;
						case "5":
							strRetorno = "five";
							break;
						case "6":
							strRetorno = "six";
							break;
						case "7":
							strRetorno = "seven";
							break;
						case "8":
							strRetorno = "eight";
							break;
						case "9":
							strRetorno = "nine";
							break;
					}
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Dezena
			private static string strRetornaTextoDezena(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						switch (strValor.Substring(0,1))
						{
							case "0": 
								strRetorno = strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
							case "1": 
							switch (strValor.Substring(1,1))
							{
								case "0": 
									strRetorno = "dez";
									break;
								case "1":
									strRetorno = "onze";
									break;
								case "2":
									strRetorno = "doze";
									break;
								case "3":
									strRetorno = "treze";
									break;
								case "4":
									strRetorno = "quatorze";
									break;
								case "5":
									strRetorno = "quinze";
									break;
								case "6":
									strRetorno = "dezesseis";
									break;
								case "7":
									strRetorno = "dezessete";
									break;
								case "8":
									strRetorno = "dezoito";
									break;
								case "9":
									strRetorno = "dezenove";
									break;
							}
								break;
							case "2": 
							switch (strValor.Substring(1,1))
							{
								case "0":
									strRetorno = "vinte ";
									break;
								default:
									strRetorno = "vinte e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "3": 
							switch (strValor.Substring(1,1))
							{
								case "0": 
									strRetorno = "trinta ";
									break;
								default: 
									strRetorno = "trinta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "4":
							switch (strValor.Substring(1,1))
							{
								case "0": 
									strRetorno = "quarenta ";
									break;
								default: 
									strRetorno = "quarenta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "5": 
							switch (strValor.Substring(1,1))
							{
								case "0": 
									strRetorno = "cinquenta ";
									break;
								default: 
									strRetorno = "cinquenta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "6": 
							switch (strValor.Substring(1,1))
							{
								case "0": strRetorno = "sessenta ";
									break;
								default: strRetorno = "sessenta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "7": 
							switch (strValor.Substring(1,1))
							{
								case "0": strRetorno = "setenta ";
									break;
								default: strRetorno = "setenta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "8": 
							switch (strValor.Substring(1,1))
							{
								case "0": strRetorno = "oitenta ";
									break;
								default: strRetorno = "oitenta e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
								break;
							case "9": 
							switch (strValor.Substring(1,1))
							{
								case "0": strRetorno = "noventa ";
									break;
								default: strRetorno = "noventa e " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
									break;
							}
							break;
						}
					break;

					case ID_IDIOMA_INGLES:
					switch (strValor.Substring(0,1))
					{
						case "0": 
							strRetorno = strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
							break;
						case "1": 
						switch (strValor.Substring(1,1))
						{
							case "0": 
								strRetorno = "ten";
								break;
							case "1":
								strRetorno = "eleven";
								break;
							case "2":
								strRetorno = "twelve";
								break;
							case "3":
								strRetorno = "thirteen";
								break;
							case "4":
								strRetorno = "fourteen";
								break;
							case "5":
								strRetorno = "fifteen";
								break;
							case "6":
								strRetorno = "sixteen";
								break;
							case "7":
								strRetorno = "seventeen";
								break;
							case "8":
								strRetorno = "eighteen";
								break;
							case "9":
								strRetorno = "nineteen";
								break;
						}
							break;
						case "2": 
						switch (strValor.Substring(1,1))
						{
							case "0":
								strRetorno = "twenty ";
								break;
							default:
								strRetorno = "twenty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "3": 
						switch (strValor.Substring(1,1))
						{
							case "0": 
								strRetorno = "thirty ";
								break;
							default: 
								strRetorno = "thirty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "4":
						switch (strValor.Substring(1,1))
						{
							case "0": 
								strRetorno = "fourty ";
								break;
							default: 
								strRetorno = "fourty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "5": 
						switch (strValor.Substring(1,1))
						{
							case "0": 
								strRetorno = "fifty ";
								break;
							default: 
								strRetorno = "fifty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "6": 
						switch (strValor.Substring(1,1))
						{
							case "0": strRetorno = "sixty ";
								break;
							default: strRetorno = "sixty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "7": 
						switch (strValor.Substring(1,1))
						{
							case "0": strRetorno = "seventy ";
								break;
							default: strRetorno = "seventy " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "8": 
						switch (strValor.Substring(1,1))
						{
							case "0": strRetorno = "eighty ";
								break;
							default: strRetorno = "eighty " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
						case "9": 
						switch (strValor.Substring(1,1))
						{
							case "0": strRetorno = "ninety ";
								break;
							default: strRetorno = "ninety " + strRetornaTextoUnidade(strValor.Substring(1,1),nIdIdioma);
								break;
						}
							break;
					}
					break;
				}
				return(strRetorno);
			}
		#endregion
		#region Centena
			private static string strRetornaTextoCentena(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						string strMore = "";
						if (strValor.Substring(0,1) != "0")
							strMore = "e ";
						if (strValor == "100")
							return("cem");
						if (strValor.EndsWith("00"))
							strMore = "";
						switch (strValor.Substring(0,1))
						{
							case "0":
								strRetorno = strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "1":
								strRetorno = "cento " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "2":
								strRetorno = "duzentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "3":
								strRetorno = "trezentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "4":
								strRetorno = "quatrocentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "5":
								strRetorno = "quinhentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "6": 
								strRetorno = "seiscentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "7":
								strRetorno = "setecentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "8":
								strRetorno = "oitocentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "9":
								strRetorno = "novecentos " + strMore + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
						}
						break;
					case ID_IDIOMA_INGLES:
						switch (strValor.Substring(0,1))
						{
							case "0":
								strRetorno = strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "1":
								strRetorno = "one hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "2":
								strRetorno = "two hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "3":
								strRetorno = "three hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "4":
								strRetorno = "four hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "5":
								strRetorno = "five hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "6": 
								strRetorno = "six hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "7":
								strRetorno = "seven hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "8":
								strRetorno = "eight hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
							case "9":
								strRetorno = "nine hundred " + strRetornaTextoDezena(strValor.Substring(1),nIdIdioma);
								break;
						}
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Texto Centavos
			private static string strRetornaTextoCentavos(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "centavo";
						else
							strRetorno = "centavos";
						break;
					case ID_IDIOMA_INGLES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "cent";
						else
							strRetorno = "cents";
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Texto Unidade 
			private static string strRetornaTextoUnitario(string strValor,int nIdIdioma,int nIdMoeda)
			{
				string strRetorno = "";
				switch(nIdMoeda)
				{
					case ID_MOEDA_DOLAR_ESTADOS_UNIDOS:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "dólar dos estados unidos";
								else
									strRetorno = "dólares dos estados unidos";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "US dollar";
								else
									strRetorno = "US dollars";
								break;
						}
						break;
					case ID_MOEDA_COROA_NORUEGUESA:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "coroa norueguesa";
								else
									strRetorno = "coroas norueguesas";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "Norwegian krona";
								else
									strRetorno = "Norwegian kroner";
								break;
						}
						break;
					case ID_MOEDA_COROA_SUECA:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "coroa sueca";
								else
									strRetorno = "coroas suecas";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "Swedish krona";
								else
									strRetorno = "Swedish kroner";
								break;
						}
						break;
					case ID_MOEDA_DOLAR_AUSTRALIANO:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "dólar australiano";
								else
									strRetorno = "dólares australianos";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "Australian Dollar";
								else
									strRetorno = "Australian Dollars";
								break;
						}
						break;
					case ID_MOEDA_DOLAR_CANADENSE:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "dólar canadense";
								else
									strRetorno = "dólares canadenses";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "Canadian dollar";
								else
									strRetorno = "Canadian dollars";
								break;
						}
						break;
					case ID_MOEDA_EURO:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "euro";
								else
									strRetorno = "euros";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "euro";
								else
									strRetorno = "euros";
								break;
						}
						break;
					case ID_MOEDA_FRANCO_SUICO:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "franco suiço";
								else
									strRetorno = "francos suiços";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "Swiss franc";
								else
									strRetorno = "Swiss francs";
								break;
						}
						break;
					case ID_MOEDA_IENE_JAPONES:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "iene";
								else
									strRetorno = "ienes";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "yen";
								else
									strRetorno = "yen";
								break;
						}
						break;
					case ID_MOEDA_LIBRA_ESTERLINA:
						switch(nIdIdioma)
						{
							case ID_IDIOMA_PORTUGUES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "libra esterlina";
								else
									strRetorno = "libras esterlinas";
								break;
							case ID_IDIOMA_INGLES:
								if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
									strRetorno = "British pound";
								else
									strRetorno = "British pounds";
								break;
						}
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Texto Milhar
			private static string strRetornaTextoMilhar(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "mil";
						else
							strRetorno = "mil";
						break;
					case ID_IDIOMA_INGLES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "thousand";
						else
							strRetorno = "thousand";
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Texto Milhao
			private static string strRetornaTextoMilhao(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "milhão";
						else
							strRetorno = "milhões";
						break;
					case ID_IDIOMA_INGLES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "million";
						else
							strRetorno = "million";
						break;
				}
				return(strRetorno);
			}
		#endregion
		#region Texto Bilhao
			private static string strRetornaTextoBilhao(string strValor,int nIdIdioma)
			{
				string strRetorno = "";
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "bilhão";
						else
							strRetorno = "bilhões";
						break;
					case ID_IDIOMA_INGLES:
						if ((strValor.Substring(0,1) == "1") && (strValor.Length == 1))
							strRetorno = "billion";
						else
							strRetorno = "billion";
						break;
				}
				return(strRetorno);
			}
		#endregion
	}
}
