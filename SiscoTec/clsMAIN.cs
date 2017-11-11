using System;

namespace SiscoTec
{
	/// <summary>
	/// Summary description for clsMAIN.
	/// </summary>
	public class clsMAIN
	{
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] strArgs) 
		{
			clsSiscoTec sisco = new clsSiscoTec();
			sisco.ShowDialog();
		}
		#endregion
	}
}
