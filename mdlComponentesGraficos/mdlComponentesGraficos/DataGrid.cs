using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for DataGrid.
	/// </summary>
	public class DataGrid : System.Windows.Forms.DataGrid 
	{
		#region Atributos
		   private int m_nIndexColumnSorted = -1;
		   private bool m_bSorterOrderAscendent = true;
		   private bool m_bAcceptsEnter = true;
		   private bool m_bAcceptsTab = true;
		#endregion
		#region Properties
			[DefaultValue(true)]
			public bool AcceptsEnter
			{
				set
				{
					m_bAcceptsEnter = value;
				}
				get
				{
					return(m_bAcceptsEnter);
				}
			}

			[DefaultValue(true)]
			public bool AcceptsTab
			{
				set
				{
					m_bAcceptsTab = value;
				}
				get
				{
					return(m_bAcceptsTab);
				}
			}

			[DefaultValue(-1)]
			public int SortedColumnIndex
			{
				set
				{
					if ((this.TableStyles.Count > 0) && (value <= this.TableStyles[0].GridColumnStyles.Count) && (value >= -1))
					{ 
						if (m_nIndexColumnSorted == value)
						{
							m_bSorterOrderAscendent = !m_bSorterOrderAscendent;
						}
						else
						{
							m_nIndexColumnSorted = value;
							m_bSorterOrderAscendent = true;
						}
					}
				}
				get
				{
					return (m_nIndexColumnSorted);
				}
			}

			[DefaultValue(true)]
			public bool SortedColumnAscendent
			{
				set
				{
					m_bSorterOrderAscendent = value;
				}
				get
				{
                   return(m_bSorterOrderAscendent);
				}
			}
		#endregion 
		#region Colunas
			public int GetColumnAt(System.Drawing.Point ptMousePosition)
			{
				int nReturn = -1;
				int nTamMaxCol = 35; 
				if (ptMousePosition.Y <= 20)
				{
					if (this.TableStyles.Count > 0){
						for (int nCont = 0; nCont < this.TableStyles[0].GridColumnStyles.Count ; nCont++)
						{
							if ((ptMousePosition.X >= nTamMaxCol) && (ptMousePosition.X <= nTamMaxCol + this.TableStyles[0].GridColumnStyles[nCont].Width )) 
							{
								nReturn = nCont;
								break;
							}
							nTamMaxCol = nTamMaxCol + this.TableStyles[0].GridColumnStyles[nCont].Width;
						}
					}
				}
				return(nReturn);
			}
		#endregion

		#region ProccessCmdKey
			protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg,System.Windows.Forms.Keys keyData)
			{
				if ((m_bAcceptsEnter) && (keyData == System.Windows.Forms.Keys.Enter))
				{
					return true;
				}

				if ((m_bAcceptsTab) && (keyData == System.Windows.Forms.Keys.Tab))
				{
					return true;
				}
				return base.ProcessCmdKey(ref msg,keyData);
			}
		#endregion
	}
}
