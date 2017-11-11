using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOAladiAce39.
	/// </summary>
	public class clsDataEmissaoCOAladiAce39 : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOAladiAce39(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 5)
			{
				this.Name = "Aladi Ace 39";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
