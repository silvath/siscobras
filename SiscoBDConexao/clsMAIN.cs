using System;

namespace SiscoBDConexao
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
			clsSiscoBDConexao sisco = new clsSiscoBDConexao();
			sisco.ShowDialog();
		}
		#endregion
	}
}
