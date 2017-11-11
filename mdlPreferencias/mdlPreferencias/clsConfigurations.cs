using System;

namespace mdlPreferencias
{
	/// <summary>
	/// Summary description for clsConfigurations.
	/// </summary>
	public class clsConfigurations
	{
		#region Static
			public static bool bRegistroPrestadorServico(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
			{
				string strCodigoCliente = cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOIDCLIENTE,"");
				if ((strCodigoCliente.Length > 2) && (((strCodigoCliente.Substring(0,2) == "12") || (strCodigoCliente.Substring(0,2) == "22"))))
					return(true);
				else
					return(false);
			}

			public static System.Data.DataSet dtstUpdateInformation()
			{
				System.Data.DataSet dtstReturn = null;
				System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetAssembly((new mdlConstantes.clsConstantes()).GetType());
				string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
				foreach(string strCurrent in arrStrAssembly)
				{
					if (("mdlConstantes.Files.Updates.xml" == strCurrent))
					{
						try
						{
							System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(strCurrent);
							dtstReturn = new System.Data.DataSet();
							dtstReturn.ReadXml(stmResource);
							stmResource.Close();
						}catch{
							dtstReturn = null;
						}
						break;
					}
				}
				return(dtstReturn);
			}
		#endregion
	}
}

