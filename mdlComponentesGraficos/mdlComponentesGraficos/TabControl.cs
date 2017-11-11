using System;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for TabControl.
	/// </summary>
	public class TabControl : System.Windows.Forms.TabControl
	{
		#region Atributes
			private bool m_bShowTabNames = true;
		#endregion
		#region Properties
			public bool ShowTabNames
			{
				get
				{
					return(m_bShowTabNames);
				}
				set
				{
					m_bShowTabNames = value;
					ResizeRegion();
				}
			}
		#endregion

		#region ResizeRegion
			private void ResizeRegion()
			{
				System.Drawing.Drawing2D.GraphicsPath grap = new System.Drawing.Drawing2D.GraphicsPath();
				if (m_bShowTabNames)
				{
					grap.AddRectangle(new System.Drawing.Rectangle(0,0,this.Width,this.Height));
				}
				else
				{
					if (this.TabCount > 0)
					{
						System.Drawing.Rectangle recRegion = new System.Drawing.Rectangle(this.TabPages[0].Location.X,this.TabPages[0].Location.Y,this.TabPages[0].Width,this.TabPages[0].Height);
						grap.AddRectangle(recRegion);
					}
					else
					{
						grap.AddRectangle(new System.Drawing.Rectangle(0,0,this.Width,this.Height));
					}
				}
				this.Region = new System.Drawing.Region(grap);
			}
		#endregion
	}
}
