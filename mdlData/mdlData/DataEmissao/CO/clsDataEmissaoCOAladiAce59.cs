using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOAladiAce59.
	/// </summary>
	public class clsDataEmissaoCOAladiAce59 : clsDataEmissaoCO
	{
		#region Construtors
			public clsDataEmissaoCOAladiAce59(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 29)
			{
				this.Name = "Aladi Ace 59";
			}
		#endregion

		#region Carregamento de Dados
		#endregion

	}
}
