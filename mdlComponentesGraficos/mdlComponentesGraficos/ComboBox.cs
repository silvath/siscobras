using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for ComboBox.
	/// </summary>
	public class ComboBox : System.Windows.Forms.ComboBox
	{
		#region Atributos
			// ***********************************************************************************
			// Atributos 
			// ***********************************************************************************
				System.Collections.ArrayList m_arlObjects = new System.Collections.ArrayList(); 
		        bool m_bAutoComplete = true;
				bool m_bAutoCompleteCaseSensitive = true;
				bool m_bGoToNextControlWithEnter = false;
				bool m_bGotoPreviusControlWithKeyLeftAtStart = false;
				bool m_bGotoNextControlWithKeyRightAtEnd = false;
			// ***********************************************************************************
		#endregion
		#region Properties
			// ***********************************************************************************
			// Properties
			[DefaultValue(true)]
			public bool AutoComplete
			{
				set
				{
					m_bAutoComplete  = value;
				}
				get
				{
					return(m_bAutoComplete);
				}
			}

			[DefaultValue(true)]
			public bool AutoCompleteCaseSensitive
			{
				set
				{
					m_bAutoCompleteCaseSensitive = value;
				}
				get
				{
					return(m_bAutoCompleteCaseSensitive);
				}
			}

			[DefaultValue(false)]
			public bool GoToNextControlWithEnter
			{
				set
				{
					m_bGoToNextControlWithEnter  = value;
				}
				get
				{
					return(m_bGoToNextControlWithEnter);
				}
			}

			[DefaultValue(false)]
			public bool GotoPreviusControlWithKeyLeftAtStart
			{
				set
				{
					m_bGotoPreviusControlWithKeyLeftAtStart = value;
				}
				get
				{
					return(m_bGotoPreviusControlWithKeyLeftAtStart);
				}
			}

			[DefaultValue(false)]
			public bool GotoNextControlWithKeyRightAtEnd
			{
				set
				{
					m_bGotoNextControlWithKeyRightAtEnd = value;
				}
				get
				{
					return(m_bGotoNextControlWithKeyRightAtEnd);
				}
			}
			// ***********************************************************************************
		#endregion
		#region Methods Array Ids
			public void Clear()
			{
				this.Items.Clear();
		        this.Text = "";
				m_arlObjects.Clear();
			}

			public void AddItem(string TextToAdd,object ObjToAdd)
			{
				this.Items.Add(TextToAdd);
                m_arlObjects.Add(ObjToAdd);
			} 

			public void DeleteCurrentItemSelected()
			{
				if (this.SelectedItem != null)
				{
                    m_arlObjects.RemoveAt(this.SelectedIndex);
					this.Items.RemoveAt(this.SelectedIndex);
					this.Text = "";
				}
			}

			public void SelectItem(object objToSelect)
			{
				this.Text = "";
				for(int nCont = 0; nCont < m_arlObjects.Count;nCont++)
				{
					if (objToSelect.Equals(m_arlObjects[nCont]))
					{
						this.Text = this.Items[nCont].ToString();
						break;
					}
				} 
			}

			public object ReturnObjectSelectedItem()
			{
				object objReturn = null;
				for(int nCont = 0; nCont < this.Items.Count; nCont++)
				{
					if (this.Items[nCont].ToString().Trim().ToUpper() == this.Text.Trim().ToUpper())
					{
						if (m_arlObjects.Count > nCont)
							objReturn = m_arlObjects[nCont];
						break;
					}
				}
				return (objReturn);
			}

			public string ReturnItem(object objItem)
			{
				string  strReturn = "";
				for(int nCont = 0; nCont < m_arlObjects.Count;nCont++)
				{
					if (objItem.Equals(m_arlObjects[nCont]))
					{
						strReturn = this.Items[nCont].ToString();
						break;
					}
				} 
				return (strReturn);
			}
		#endregion
		#region Auto Complete Methods
			protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
			{
				base.OnKeyUp(e);
				switch(e.KeyCode)
				{
					case System.Windows.Forms.Keys.Enter:
						if (m_bGoToNextControlWithEnter)
							System.Windows.Forms.SendKeys.Send("{TAB}");
						break;
					case System.Windows.Forms.Keys.Left:
						if ((m_bGotoPreviusControlWithKeyLeftAtStart) && (this.SelectionStart == 0))
							System.Windows.Forms.SendKeys.Send("+{TAB}");
						break;
					case System.Windows.Forms.Keys.Right:
						if ((m_bGotoNextControlWithKeyRightAtEnd) && (this.SelectionStart == this.Text.Length))
							System.Windows.Forms.SendKeys.Send("{TAB}");
						break;
				}
			}

			protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
			{
				base.OnKeyUp(e);
				bool bDoNothing = false;
				if (m_bAutoComplete)
				{
					switch(e.KeyCode)
					{
						case System.Windows.Forms.Keys.Back: // BackSpace
							if (this.Text != "")
							{
								if (this.SelectionStart > 0)
								{
									this.SelectionStart--;
									this.SelectionLength++;
									this.Text = this.Text.Substring(0,this.Text.Length - this.SelectionLength);
								}
							}
							break;
						case System.Windows.Forms.Keys.Left:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						case System.Windows.Forms.Keys.Right:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						case System.Windows.Forms.Keys.Up:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						case System.Windows.Forms.Keys.Down:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						case System.Windows.Forms.Keys.Enter:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						case System.Windows.Forms.Keys.Tab:
							// NAO DESLOCA O CURSOR
							bDoNothing = true;
							break;
						default:
							this.Text = this.Text.Substring(0,this.Text.Length - this.SelectionLength);
							break;
					}
					int nTextSize = -1; 
					if ((this.Text != "") && (!bDoNothing))
					{
						string strTextItem = "";
						string strTextActual = this.Text;
						if (!m_bAutoCompleteCaseSensitive)
							strTextActual = strTextActual.ToUpper();
						for (int nCont = 0;nCont < this.Items.Count;nCont++)
						{
							strTextItem = this.Items[nCont].ToString();
							if (!m_bAutoCompleteCaseSensitive)
								strTextItem = strTextItem.ToUpper();
							if (strTextItem.IndexOf(strTextActual) == 0)
							{
								nTextSize = this.Text.Length;
								this.Text = this.Items[nCont].ToString();
								break;
							}
						}
					}
					if (nTextSize != -1)
					{
						this.SelectionStart = nTextSize;
						this.SelectionLength = this.Text.Length;
						this.SelectionStart = nTextSize;
					}
					else
					{
						if (!bDoNothing)
						{
							this.SelectionStart = this.Text.Length;
							this.SelectionLength = 0;
						}
					}
				}
			}

			
			protected override void OnLeave(System.EventArgs e)
			{
				base.OnLeave(e);
				if (m_bAutoComplete)
				{
//					this.SelectionStart = 0;
//					this.SelectionLength = 0;
				}
			} 
		#endregion
	}
}
