using System;

namespace SiscoEstatistico
{
	/// <summary>
	/// Summary description for clsMain.
	/// </summary>
	public class clsMain
	{
		#region MAIN
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] strArgs) 
		{
			string strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";
			mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
			mdlDataBaseConfig.clsDataBaseConfig cls_cnf_dataBaseConfig = new mdlDataBaseConfig.clsDataBaseConfig(ref cls_ter_tratadorErro,strEnderecoExecutavel);
			if (cls_cnf_dataBaseConfig.bDataBaseConfiguratedRight())
			{
				mdlDataBaseAccess.clsDataBaseAccess cls_dba_DBConnection = null;
				cls_cnf_dataBaseConfig.ReturnDataBaseAccess(out cls_dba_DBConnection);
				if (cls_dba_DBConnection != null)
				{
					mdlEstatistica.clsEstatistica clsEstatistica = new mdlEstatistica.clsEstatistica(ref cls_dba_DBConnection);
					clsEstatistica.TratadorErro = cls_ter_tratadorErro;
					clsEstatistica.EnderecoExecutavel = strEnderecoExecutavel;
					clsEstatistica.ShowDialog();
				}
			}
		}
		#endregion
	}
}
