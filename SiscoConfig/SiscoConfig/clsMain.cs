using System;

namespace SiscoConfig
{
	/// <summary>
	/// Summary description for clsMain.
	/// </summary>
	public class clsMain
	{
		#region MAIN
			[STAThread]
			static void Main() 
			{
				clsConfig obj = new clsConfig();
				obj.ShowDialog();
			}
		#endregion
	}
}
