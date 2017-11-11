using System;

namespace mdlConversao
{
	/// <summary>
	/// Summary description for clsTruncamento.
	/// </summary>
	public sealed class clsTruncamento
	{
		public static double dTrunca(double dValor,double dPrecisao,long nlMinDecimals,int nMaxDecimals)
		{
			return(System.Math.Round(dTrunca(dValor,dPrecisao,nlMinDecimals),nMaxDecimals));
		}

		public static double dTrunca(double dValor,double dPrecisao,int nMaxDecimals)
		{
			return(System.Math.Round(dTrunca(dValor,dPrecisao,2L),nMaxDecimals));
		}

		public static double dTrunca(double dValor,double dPrecisao)
		{
			return(dTrunca(dValor,dPrecisao,2L));
		}

		public static double dTrunca(double dValor,double dPrecisao,long nlMinDecimals)
		{
			int nDecimalsValor = nQuantidadeDecimals(dValor);
			int nDecimalsValorDefault = nDecimalsValor;
			int nDecimalsValorPrecisao;
			double dValorPrecisao;
			double dValorOtimo;
			double dRetornoMenor = dValor,dRetornoMaior = dValor;

			if (nDecimalsValor > 0)
			{

				// Menor
				dValorPrecisao = dValor - dPrecisao;
				nDecimalsValorPrecisao = nQuantidadeDecimals(dValorPrecisao);
				dValorOtimo = dValor;
				if (nDecimalsValorPrecisao > 0)
					if ((nDecimalsValorPrecisao - 1) <= nDecimalsValor)
						while((nDecimalsValorPrecisao > nlMinDecimals) && ((dValorPrecisao < dValorOtimo) && (dValorOtimo <= dValor)))
						{
							nDecimalsValorPrecisao--;
							dValorOtimo = dRound(dValor,nDecimalsValorPrecisao);
						}
					else
						while((nDecimalsValor > 0) && ((dValorPrecisao < dValorOtimo) && (dValorOtimo <= dValor)))
						{
							nDecimalsValor--;
							dValorOtimo = dRound(dValor,nDecimalsValor);
						}
				else
					dValorOtimo = dValorPrecisao;
				if ((dValorPrecisao < dValorOtimo) && (dValorOtimo <= dValor))
					dRetornoMenor = dValorOtimo;
		
				// Maior 
				dValorPrecisao = dValor + dPrecisao;
				nDecimalsValor = nDecimalsValorDefault; 
				nDecimalsValorPrecisao = nQuantidadeDecimals(dValorPrecisao);
				dValorOtimo = dValorPrecisao;
				if (nDecimalsValorPrecisao > 0)
					if ((nDecimalsValorPrecisao - 1) <= nDecimalsValor)
						while((nDecimalsValorPrecisao > nlMinDecimals) && ((dValor < dValorOtimo) && (dValorOtimo <= dValorPrecisao)))
						{
							nDecimalsValorPrecisao--;
							dValorOtimo = dRound(dValorPrecisao,nDecimalsValorPrecisao);
						}
					else
						while((nDecimalsValor > 0) && ((dValor < dValorOtimo) && (dValorOtimo <= dValorPrecisao)))
						{
							nDecimalsValor--;
							dValorOtimo = dRound(dValorPrecisao,nDecimalsValor);
						}
				else
					dValorOtimo = dValorPrecisao;
				if ((dValor < dValorOtimo) && (dValorOtimo <= dValorPrecisao))
					dRetornoMaior = dValorOtimo;

				if (nQuantidadeDecimals(dRetornoMaior) > nQuantidadeDecimals(dRetornoMenor))
					return(dRetornoMenor);
				else
					return(dRetornoMaior);
			}

			// Sem casas decimais
			return(dValor);
		}

		public static double dRound(double dValor,int nDecimals)
		{
			int nDecimalsValor = nQuantidadeDecimals(dValor);
			if (nDecimalsValor > nDecimals)
			{
				string strValor = dValor.ToString("R");
				int nIndex = dValor.ToString("R").IndexOf(",");
				strValor = strValor.Substring(0,nIndex + nDecimals + 1);
				dValor = double.Parse(strValor);
				return(dValor);
			}
			else
			{
				return(dValor);
			}
		}

		private static int nQuantidadeDecimals(double dValor)
		{
			int nIndex = dValor.ToString("R").IndexOf(",");
			if (nIndex == -1)
			{
				string strValorE = dValor.ToString("R");
				nIndex = strValorE.IndexOf("E-");
				if (nIndex != -1)
				{
					int nQuant = Int32.Parse(strValorE.Substring(nIndex + 2));
					if (nQuant <= 15)
						return(nQuant);
					else
						return(15);
				}
				else
				{
					return(0);
				}
			}else{
				if (nIndex >= 0)
				{
					int nQuant = (dValor.ToString("R").Length - 1) - nIndex;
					if (nQuant <= 15)
						return(nQuant);
					else
						return(15);
				}else{
					return(0);
				}
			}
		}
	}
}
