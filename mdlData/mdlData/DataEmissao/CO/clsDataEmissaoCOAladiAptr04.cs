using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOAladiAptr04.
	/// </summary>
	public class clsDataEmissaoCOAladiAptr04 : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOAladiAptr04(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 4)
			{
				this.Name = "Aladi Aptr 04";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
