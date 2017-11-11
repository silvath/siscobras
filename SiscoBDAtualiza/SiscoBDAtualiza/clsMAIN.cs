using System;

namespace SiscoBDAtualiza
{
	public class clsMAIN
	{
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] strArgs) 
		{
			clsSiscoBDAtualiza sisco = new clsSiscoBDAtualiza();
			sisco.ShowDialog();
		}
		#endregion
	}
}
