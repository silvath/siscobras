using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOAnexoIII.
	/// </summary>
	public class clsDataEmissaoCOAnexoIII : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
			public clsDataEmissaoCOAnexoIII(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 6)
			{
				this.Name = "Anexo III";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
