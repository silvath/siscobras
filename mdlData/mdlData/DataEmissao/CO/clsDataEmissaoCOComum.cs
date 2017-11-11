using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOComum.
	/// </summary>
	public class clsDataEmissaoCOComum : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOComum(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 7)
			{
				this.Name = "Comum";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
