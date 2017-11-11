using System;

namespace mdlComponentesColecoes
{
	/// <summary>
	/// Summary description for clsComparerListViewItem.
	/// </summary>
	public class clsComparerListViewItem :	System.Collections.IComparer
	{
		#region Atributes
			private int m_nColumn = 0;
			private bool m_bCrescent = true;
		#endregion
		#region Properties
			public int Column
			{
				get
				{
					return(m_nColumn);
				}
			}

			public bool OrderCrescent
			{
				get
				{
					return(m_bCrescent);
				}
				set
				{
					m_bCrescent = value;
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsComparerListViewItem()
			{
			}

			public clsComparerListViewItem(int nColumn)
			{
				m_nColumn = nColumn;
			}
		#endregion
		#region Compare
			public int Compare(object x, object y) 
			{
				if (m_bCrescent)
					return String.Compare(((System.Windows.Forms.ListViewItem)x).SubItems[m_nColumn].Text, ((System.Windows.Forms.ListViewItem)y).SubItems[m_nColumn].Text);
				else
					return String.Compare(((System.Windows.Forms.ListViewItem)y).SubItems[m_nColumn].Text, ((System.Windows.Forms.ListViewItem)x).SubItems[m_nColumn].Text);
			}
		#endregion
	}
}
