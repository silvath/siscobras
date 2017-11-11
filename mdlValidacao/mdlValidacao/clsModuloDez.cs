using System;

namespace mdlValidacao
{
	/// <summary>
	/// Summary description for clsModuloDez.
	/// </summary>
	public sealed class clsModuloDez
	{
		#region Modulo 10
			public static bool bCheckModula10(string strNumbers)
			{
				if (strNumbers.Length > 1)
				{
					 return(strNumbers.Substring(strNumbers.Length - 1,1) == nReturnModula10(strNumbers.Substring(0,strNumbers.Length - 1)).ToString());
				}else{
					return(false);
				}
			}

			public static int nReturnModula10(string strNumbers)
			{
				int nReturn = 0,nNumber,nSum = 0,nMulp = 2;
				for(int i = (strNumbers.Length - 1); i >= 0;i--)
				{
					nNumber = (Int32.Parse(strNumbers[(i)].ToString()) * nMulp);
					if (nNumber.ToString().Length == 2)
						nNumber = Int32.Parse(nNumber.ToString().Substring(0,1)) + Int32.Parse(nNumber.ToString().Substring(1,1));
					nSum += nNumber;
					if (nMulp == 2)
						nMulp = 1;
					else
						nMulp = 2;
				}
				if (nSum.ToString().Substring(nSum.ToString().Length - 1,1) == "0")
				{
					return(0);
				}else{
					if (nSum <= 10)
						return(10 - nSum);
					string strNumero = (Int32.Parse(nSum.ToString().Substring(0,1)) + 1).ToString();
					strNumero = strNumero + nSum.ToString().Substring(1,nSum.ToString().Length - 2);
					strNumero = strNumero + "0";
					return(Int32.Parse(strNumero) - nSum);
				}
				return(nReturn);
			}
		#endregion
	}
}
