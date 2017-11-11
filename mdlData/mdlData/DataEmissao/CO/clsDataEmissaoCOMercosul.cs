using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataCOMercosul.
	/// </summary>
	public class clsDataEmissaoCOMercosul : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOMercosul(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 1)
			{
				this.Name = "Mercosul";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
