using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for TextBoxDateTime.
	/// </summary>
	public class TextBoxDateTime : System.Windows.Forms.TextBox
	{
		#region Constants
			private const char DAY = 'd';
			private const char MONTH = 'M';
			private const char YEAR = 'y';
		#endregion
		#region Atributes
			private string m_strFormat = "dd/MM/yyyy";
			private System.DateTime m_dtValue = System.DateTime.Now; 
			private bool m_bValueValid = false;
		#endregion
		#region Properties
			[DefaultValue("dd/MM/yyyy")]
			public string Format
			{
				set
				{
					m_strFormat = value;
				}
				get
				{
					return(m_strFormat);
				}
			}

			public System.DateTime Value
			{
				set
				{
				}
				get
				{
					return(m_dtValue);
				}
			}

			public bool ValueValid
			{
				get
				{
					return(m_bValueValid);
				}
			}
		#endregion

		#region Events
			protected override void OnTextChanged(EventArgs e)
			{
				base.OnTextChanged (e);
				vRefreshValue();
			}

			protected override void OnLeave(EventArgs e)
			{
				this.Value.CompareTo(null);
				if (((m_bValueValid == false) && (this.Text == "")) || (m_bValueValid == true))
				{
					 this.Text = m_dtValue.ToString(m_strFormat);
					base.OnLeave (e);
				}else{
					this.Text = "";
					this.Focus();
				}
			}
		#endregion

		#region Checks
			private bool bIsSpecialCharacter(char chrKey)
			{
				bool bRetorno = false;
				switch(chrKey)
				{
					case '!':
						bRetorno = true;
						break;
					case '@':
						bRetorno = true;
						break;
					case '#':
						bRetorno = true;
						break;
					case '$':
						bRetorno = true;
						break;
					case '%':
						bRetorno = true;
						break;
					case '¨':
						bRetorno = true;
						break;
					case '&':
						bRetorno = true;
						break;
					case '*':
						bRetorno = true;
						break;
					case '(':
						bRetorno = true;
						break;
					case ')':
						bRetorno = true;
						break;
					case '-':
						bRetorno = true;
						break;
					case '+':
						bRetorno = true;
						break;
					case ',':
						bRetorno = true;
						break;
					case '.':
						bRetorno = true;
						break;
					case '/':
						bRetorno = true;
						break;
					case '\\':
						bRetorno = true;
						break;
				}
				return(bRetorno);
			}

			private bool bIsValidNumber(string strNumber,int nMax)
			{
				bool bRetorno = false;
				try
				{
					int nNumber = Int32.Parse(strNumber);
					bRetorno = nNumber <= nMax;
				}catch{
				}
				return(bRetorno);
			} 
		#endregion

		#region Formating
			private void vRefreshValue()
			{
				m_bValueValid = false;
				string strText = "",strFormat = "",strDay = "",strMonth = "",strYear = "";
				foreach(char chrText in this.Text.Replace(" ",""))
				{
					if (!bIsSpecialCharacter(chrText))
						strText += chrText.ToString();
				} 
				foreach(char chrFormat in this.m_strFormat)
				{
					if (!bIsSpecialCharacter(chrFormat))
						strFormat += chrFormat.ToString();
				}
				for(int i = 0;i < strFormat.Length;i++)
				{
					if (strText.Length <= i)
						break;
					switch(strFormat[i])
					{
						case DAY:
							if (bIsValidNumber(strDay + strText[i],31))
								strDay += strText[i];
							break;
						case MONTH:
							if (bIsValidNumber(strMonth + strText[i],12))
								strMonth += strText[i];
							break;
						case YEAR:
							if (bIsValidNumber(strYear + strText[i],12))
								strYear += strText[i];
							break;
					}
				}
			}
		#endregion
	}
}
