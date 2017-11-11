using System;

namespace mdlConstantes
{
	/// <summary>
	/// Summary description for clsConfig.
	/// </summary>
	public class clsConfig
	{
		#region Atributes
			private static System.Drawing.Color m_clrBackColor = System.Drawing.Color.Green;
			private static System.Drawing.Color m_clrFirstColor = System.Drawing.Color.FromArgb(220,240,220);
			private static System.Drawing.Color m_clrSecondColor = System.Drawing.Color.FromArgb(220,240,220);
		#endregion
		#region Properties
			public static System.Drawing.Color BackColor
			{
				set
				{
					m_clrBackColor = value;
				}
				get
				{
					return(m_clrBackColor);
				}
			}

			public static System.Drawing.Color FirstColor
			{
				set
				{
					m_clrFirstColor = value;
				}
				get
				{
					return(m_clrFirstColor);
				}
			}

			public static System.Drawing.Color SecondColor
			{
				set
				{
					m_clrSecondColor = value;
				}
				get
				{
					return(m_clrSecondColor);
				}
			}
		#endregion
	}
}
