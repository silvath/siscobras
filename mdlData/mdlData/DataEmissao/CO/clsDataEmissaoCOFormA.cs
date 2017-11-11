using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOFormA.
	/// </summary>
	public class clsDataEmissaoCOFormA : clsDataEmissaoCO
	{
		#region Construtores and Destrutors
			public clsDataEmissaoCOFormA(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 8)
			{
				this.Name = "Form A";
			}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
