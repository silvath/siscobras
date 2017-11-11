using System;

namespace mdlValidacao
{
	/// <summary>
	/// Summary description for clsContainer.
	/// </summary>
	public class clsContainer
	{
		#region Static
			public static int m_nDigitoVerificadorDefault = 0;
		#endregion

		#region Check
			public static bool bCheckContainerDigit(string strNumbers)
			{
				if (strNumbers.Length > 1)
					return(strNumbers.Substring(strNumbers.Length - 1,1) == nReturnContainerDigitCheck(strNumbers.Substring(0,strNumbers.Length - 1)).ToString());
				else
					return(false);
			}
		#endregion
		#region Return
			internal static int nReturnDigitDigit(char chrNumber)
			{
				int nReturn = 0;
				switch(chrNumber)
				{
					case '0':
						nReturn = 0;
					break;
					case '1':
						nReturn = 1;
						break;
					case '2':
						nReturn = 2;
						break;
					case '3':
						nReturn = 3;
						break;
					case '4':
						nReturn = 4;
						break;
					case '5':
						nReturn = 5;
						break;
					case '6':
						nReturn = 6;
						break;
					case '7':
						nReturn = 7;
						break;
					case '8':
						nReturn = 8;
						break;
					case '9':
						nReturn = 9;
						break;
					case 'A':
						nReturn = 10;
						break;
					case 'B':
						nReturn = 12;
						break;
					case 'C':
						nReturn = 13;
						break;
					case 'D':
						nReturn = 14;
						break;
					case 'E':
						nReturn = 15;
						break;
					case 'F':
						nReturn = 16;
						break;
					case 'G':
						nReturn = 17;
						break;
					case 'H':
						nReturn = 18;
						break;
					case 'I':
						nReturn = 19;
						break;
					case 'J':
						nReturn = 20;
						break;
					case 'K':
						nReturn = 21;
						break;
					case 'L':
						nReturn = 23;
						break;
					case 'M':
						nReturn = 24;
						break;
					case 'N':
						nReturn = 25;
						break;
					case 'O':
						nReturn = 26;
						break;
					case 'P':
						nReturn = 27;
						break;
					case 'Q':
						nReturn = 28;
						break;
					case 'R':
						nReturn = 29;
						break;
					case 'S':
						nReturn = 30;
						break;
					case 'T':
						nReturn = 31;
						break;
					case 'U':
						nReturn = 32;
						break;
					case 'V':
						nReturn = 34;
						break;
					case 'X':
						nReturn = 36;
						break;
					case 'Y':
						nReturn = 37;
						break;
					case 'Z':
						nReturn = 38;
						break;
				}
				return(nReturn);
			}

			public static int nReturnContainerDigitCheck(string strNumbers)
			{
				int nSum = 0,nMulp = 1;
				strNumbers = strNumbers.Trim().ToUpper();
				if (strNumbers.Length != 10)
					return(-1);
				for (int i = 0; i < strNumbers.Length ; i++)
				{
					nSum += (nReturnDigitDigit(strNumbers[i]) * nMulp);
					nMulp = nMulp * 2;
				}
				if (((nSum % 11)) > 9)
					return(m_nDigitoVerificadorDefault);
				else
					return(((nSum % 11)));
			}
		#endregion
	}
}
