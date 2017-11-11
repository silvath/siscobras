using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOMercosulChile.
	/// </summary>
	public class clsDataEmissaoCOMercosulChile : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOMercosulChile(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 3)
			{
				this.Name = "Mercosul Chile";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
