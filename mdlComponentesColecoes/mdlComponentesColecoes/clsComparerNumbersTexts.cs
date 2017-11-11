using System;

namespace mdlComponentesColecoes
{
	/// <summary>
	/// Summary description for clsComparerNumbersTexts.
	/// </summary>
	public class clsComparerNumbersTexts :	System.Collections.IComparer
	{
		#region Métodos
		public int Compare(Object obj1 ,Object obj2)
		{
			int nReturn = 0;
			double dNumberObj1 = 0;
			double dNumberObj2 = 0;

			bool bObj1IsNumeric = true;
			bool bObj2IsNumeric = true;

			if (bObj1IsNumeric = bIsNumeric(obj1.ToString()))
			{
				try
				{
					dNumberObj1 = System.Double.Parse(obj1.ToString());
				}catch{
					bObj1IsNumeric = false;
				}
			}
			if (bObj2IsNumeric = bIsNumeric(obj2.ToString()))
			{
				try
				{
					dNumberObj2 = System.Double.Parse(obj2.ToString());
				}catch{
					bObj2IsNumeric= false;
				}
			}
               
			if (bObj1IsNumeric)
			{
				if (bObj2IsNumeric)
				{
					if (dNumberObj1 < dNumberObj2)
						nReturn = -1;
					else
						if (dNumberObj2 < dNumberObj1)
						nReturn = 1;
				}
				else
				{
					if (((string)obj2).Trim() == "")
						nReturn = 1;
					else
						nReturn = -1;
				}
			}
			else
			{
				if (bObj2IsNumeric)
					nReturn = 1;
				else
				{
					if (obj1.ToString().Trim() == "")
						nReturn = -1;
					else
						if (obj2.ToString().Trim() == "")
						nReturn = 1;
					else
						nReturn = obj1.ToString().CompareTo(obj2.ToString());
						//nReturn = nCompareStrings((string)obj1,(string)obj2);
				}
			}
			return(nReturn);
		}
		#endregion
		#region Método Comparacao entre Strings
		private int nCompareStrings(string strTexto1,string strTexto2)
		{
			int nReturn = 0;
			while ((strTexto1.Length > 0) && (strTexto2.Length > 0))
			{
				if (strTexto1[0] != strTexto2[0])
				{
					nReturn = (int)strTexto1[0] - (int)strTexto2[0];
					break;
				}
				strTexto1 = strTexto1.Substring(1);
				strTexto2 = strTexto2.Substring(1);
			}
			return (nReturn);
		}
		#endregion
		#region Método Identificacao Numeros
			private bool bIsNumeric(string strText)
			{
				bool bRetorno = false;
				int nDot = 0;
				int nComma = 0;
				if (strText.Length > 0)
				{
					bRetorno = true;
					foreach(char chrChar in strText)
					{
						switch(chrChar)
						{
							case '.':
								if ((nComma > 1) && (nDot < 2))
									return(false);
								nDot++;
								break;
							case ',':
								if ((nDot > 1) && (nComma < 2))
									return(false);
								nComma++;
								break;
							case '0':
							case '1':
							case '2':
							case '3':
							case '4':
							case '5':
							case '6':
							case '7':
							case '8':
							case '9':
								break;
							default:
								return(false);
						}
					}
				}
				return(bRetorno);
			}
		#endregion
	}
}
