using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for TextBox.
	/// </summary>
	public class TextBox : System.Windows.Forms.TextBox
	{
		#region Constantes
			private const  char MASK_NUMBER = 'N';
			private const  char MASK_CHARACTER = 'C';
			private const  char MASK_NUMBER_OR_CHARACTER = 'A';
		#endregion

		#region Atributes
			// ***********************************************************************************
			// Atrtibutes
			// ***********************************************************************************
			private bool m_bShadow = false;
			private string m_strShadow = "";
			private int m_nSelectionStart = -1;
			private bool m_bOnlyNumbers = false;
			private int m_nMaxDecimalNumbers = -1;
			private bool m_bMask = false;
			private string m_strMask = "";
			private bool m_bMaskAutomaticSpecialCharacters = false;
			private bool m_bEnterGotoNextControl = true;
			private bool m_bOnEnterFullSelect = true;
		#endregion
		#region Properties
		// ***********************************************************************************
		// Properties
		// ***********************************************************************************
		[DefaultValue(false)]
		public virtual bool Shadow
		{
			set
			{
				m_bShadow = value;
				if (m_bShadow)
				{
					m_bMask = false;
					m_bOnlyNumbers = false;
				}else{
					this.Text = m_strShadow;
				}
			}
			get
			{
				return(m_bShadow);
			}
		}

		[DefaultValue(false)]
		public virtual bool OnlyNumbers
		{
			set
			{
				m_bOnlyNumbers = value;
				if (m_bOnlyNumbers)
				{
					m_bMask = false;
					m_bShadow = false;
				}
			}
			get
			{
				return(m_bOnlyNumbers);
			}
		}

		[DefaultValue(true)]
		public virtual bool OnEnterFullSelect
		{
			set
			{
				m_bOnEnterFullSelect = value;
			}
			get
			{
				return(m_bOnEnterFullSelect);
			}
		}
		
		[DefaultValue(true)]
		public bool EnterGotoNextControl
		{
			set
			{
				m_bEnterGotoNextControl = value;
			}
			get
			{
				return(m_bEnterGotoNextControl);
			}
		}

		[DefaultValue(-1)]
		public virtual int MaxDecimalNumbers
		{
			set
			{
				if (value >= -1)
					m_nMaxDecimalNumbers = value;
			}
			get
			{
				return(m_nMaxDecimalNumbers);
			}
		}

		[DefaultValue(false)]
		public virtual bool Mask
		{
			set
			{
				m_bMask = value;
				if (m_bMask)
				{
					m_bOnlyNumbers = false;
					m_bShadow = false;
				}
			}
			get
			{
				return(m_bMask);
			}
		}

		[DefaultValue("")]
		public virtual string MaskText
		{
			set
			{
				if (value.Trim() != "")
					OnlyNumbers = false;
				m_strMask = value.Trim();
			}
			get
			{
                return(m_strMask);
			}
		}

		[DefaultValue(false)]
		public virtual bool MaskAutomaticSpecialCharacters
		{
			set
			{
				m_bMaskAutomaticSpecialCharacters = value;
			}
			get
			{
				return(m_bMaskAutomaticSpecialCharacters);
			}
		}

		public override string Text
		{
			get
			{
				if (!m_bShadow)
				{
					return base.Text;
				}else{
					return(m_strShadow);
				}
			}
			set
			{
				base.Text = value;
			}
		}
		// ***********************************************************************************
		#endregion

		#region Events
			protected override void OnEnter(EventArgs e)
			{
				base.OnEnter (e);
				if (m_bOnEnterFullSelect)
					this.SelectAll();
			}

			protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
			{
				base.OnKeyPress(e);
				switch((int)e.KeyChar)
				{
					case 13: // Enter
						if (m_bEnterGotoNextControl)
							System.Windows.Forms.SendKeys.Send("{TAB}");
						break;
					default:
						// Numeros 
						if (m_bOnlyNumbers)
						{
							bool bPossuiVirgula = (this.Text.IndexOf(",") != -1);
							bool bNovaVirgula = (e.KeyChar == '.') || (e.KeyChar == ',') ;
							if (e.KeyChar != 8)
							{
								if (((48 <= (int)e.KeyChar) && ((int)e.KeyChar <= 57)) || (bNovaVirgula && !bPossuiVirgula && (m_nMaxDecimalNumbers != 0)))
								{
									if (e.KeyChar == '.')
									{
										int nPos = this.SelectionStart;
										string strTextoAnterior;
										string strTextoPosterior;
										strTextoAnterior = this.Text.Substring(0,nPos);
										strTextoPosterior = this.Text.Substring(nPos);
										this.Text = strTextoAnterior + "," + strTextoPosterior;
										this.SelectionStart = nPos + 1;
										e.Handled = true;
									}else{
										// Max Decimal Numbers 
										if ((bPossuiVirgula) && (m_nMaxDecimalNumbers > 0))
										{
											if ((m_nMaxDecimalNumbers == ((this.Text.Length - this.Text.IndexOf(",")) - 1)) && (this.SelectedText != this.Text))
												e.Handled = true;
										}
									}
								}
								else
									e.Handled = true;
							}
						}
						// Mascara
						if (m_bMask)
						{
							if (!bValidKey(e.KeyChar,false))
							{
								if (m_bMaskAutomaticSpecialCharacters)
								{
									if (bIsInTheFinal())
									{
										if (bNextCharacterIsSpecialCharacter())
										{
											if (bValidKey(e.KeyChar,true))
											{
												e.Handled = true;
												vInsertNextCharacterMask();
												this.Text += e.KeyChar;
												this.SelectionStart = this.Text.Length;
											}else{
												e.Handled = true;
											}
										}else{
											e.Handled = true;
										}
									}else{
										e.Handled = true;
									}
								}else{
									e.Handled = true;
								}
							}
						}

						// Shadow
						if (m_bShadow)
						{
							vInsertCharInShadow((int)e.KeyChar);
							vRefreshTextShadow();
							e.Handled = true;
							this.SelectionStart = m_nSelectionStart;
						}
						break;
				}
			}
		#endregion

		#region Mask
			#region ValidKey
				private bool bValidKey(char chrKey,bool bNextChar)
				{
					bool bRetorno = false;

					if (chrKey == 8) // BackSpace
					{
						bRetorno = true;
					}else{
						// O Texto já possui o tamanho da mascara
						if (this.Text.Length >= m_strMask.Length)
						{
							bRetorno = false;
						}else{
							int nPos = this.SelectionStart;
							string strTextoAnterior = this.Text.Substring(0,nPos);
							string strTextoPosterior = this.Text.Substring(nPos);
							if (bNextChar)
								nPos++;
							char chrMask = m_strMask[nPos];
							switch(chrMask)
							{
								case MASK_NUMBER:
									if (bIsNumeric(chrKey))
									{
										bRetorno = true;
									}
									break;
								case MASK_CHARACTER:
									if (bIsCharacter(chrKey))
									{
										bRetorno = true;
									}
									break;
								case MASK_NUMBER_OR_CHARACTER:
									if (bIsNumeric(chrKey) || bIsCharacter(chrKey))
									{
										bRetorno = true;
									}
									break;
								default:
									if ((bIsSpecialCharacter(chrKey)) && (chrMask == chrKey))
									{
										bRetorno = true;
									}
									break;
							}
						}
					}
					return(bRetorno);
				}
			#endregion
			#region Checks
				private bool bIsInTheFinal()
				{
					return(this.SelectionStart == this.Text.Length);
				}

				private bool bIsNumeric(char chrKey)
				{
					bool bRetorno = false;
					if ((48 <= (int)chrKey) && ((int)chrKey <= 57))
					{
						bRetorno = true;
					}
					return(bRetorno);
				}

				private bool bIsCharacter(char chrKey)
				{
					bool bRetorno = false;
					if (((97 <= (int)chrKey) && ((int)chrKey <= 122)) || ((65 <= (int)chrKey) && ((int)chrKey <= 90)))
					{
						bRetorno = true;
					}
					return(bRetorno);
				}

				private bool bNextCharacterIsSpecialCharacter()
				{
					if (m_strMask.Length > this.SelectionStart)
					{
						char chrMask = m_strMask[this.SelectionStart];
						return(bIsSpecialCharacter(chrMask));
					}else{
						return(false);
					}
				}

				private void vInsertNextCharacterMask()
				{
					if (m_strMask.Length > this.SelectionStart)
					{
						this.Text += m_strMask[this.SelectionStart];
					}
				}	

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
			#endregion
			#region ValidText
				public bool bTextValidWithTheMask()
				{
					bool bRetorno = false;

					if (m_bMask)
					{
						if (m_strMask.Length == this.Text.Length)
						{
							char chrKey;  
							char chrMask;
							for (int nCont = 0; nCont < m_strMask.Length;nCont++)
							{
								chrKey = this.Text[nCont];
								chrMask = m_strMask[nCont];
								switch(chrMask)
								{
									case MASK_NUMBER:
										if (!bIsNumeric(chrKey))
										{
											return(false);
										}
										break;
									case MASK_CHARACTER:
										if (!bIsCharacter(chrKey))
										{
											return(false);
										}
										break;
									case MASK_NUMBER_OR_CHARACTER:
										if (!bIsNumeric(chrKey) || (!bIsCharacter(chrKey)))
										{
											return(false);
										}
										break;
									default:
										if (!(bIsSpecialCharacter(chrKey)) && (chrMask == chrKey))
										{
											return(false);
										}
										break;
								}
							}
							return(true);
						}  
					}
					return(bRetorno);
				}
			#endregion
		#endregion
		#region Shadow
			private void vInsertCharInShadow(int nChar)
			{
				m_nSelectionStart = this.SelectionStart;
				switch(nChar)
				{
					case 8: // Backspace
						if (m_nSelectionStart > 0)
						{
							if (m_strShadow.Length > 0)
							{
								m_strShadow = m_strShadow.Remove(m_nSelectionStart - 1,1);
							}
							m_nSelectionStart--;
						}
						break;
					default:
						m_strShadow = m_strShadow + (char)nChar;
						m_nSelectionStart++;
						break;
				}
			}

			private void vRefreshTextShadow()
			{
                this.Text = new string('*',m_strShadow.Length);
			}
		#endregion
	}
}
