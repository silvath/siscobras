using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlComponentesColecoes
{
	/// <summary>
	/// Summary description for ListViewOrder.
	/// </summary>
	public class ListViewOrder : IComparer
	{
		
		#region Atributes
			private int m_nColumn;
			private System.Windows.Forms.SortOrder m_sortOrder = System.Windows.Forms.SortOrder.Ascending;
		#endregion
		#region Constructors
			public ListViewOrder(System.Windows.Forms.SortOrder sortOrder,int nColumn)
			{
				m_sortOrder = sortOrder;
				m_nColumn = nColumn;
			}
        #endregion

		#region IComparer Members
			public int Compare(object x, object y)
			{
				ListViewItem objetoA = (ListViewItem) x;
				ListViewItem objetoB = (ListViewItem) y;
				if ((objetoA.SubItems.Count <= m_nColumn) || (objetoB.SubItems.Count <= m_nColumn))
					return(0);
				if (this.m_sortOrder.Equals(System.Windows.Forms.SortOrder.Ascending))
					return objetoA.SubItems[this.m_nColumn].Text.CompareTo(objetoB.SubItems[this.m_nColumn].Text);
				else
					return objetoB.SubItems[this.m_nColumn].Text.CompareTo(objetoA.SubItems[this.m_nColumn].Text);
			}
		#endregion
	}
}
