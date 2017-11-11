using System;

namespace mdlData.DataEmissao.CO
{
	/// <summary>
	/// Summary description for clsDataEmissaoCOMercosulBolivia.
	/// </summary>
	public class clsDataEmissaoCOMercosulBolivia : clsDataEmissaoCO
	{
		#region Construtors and Destrutors
		public clsDataEmissaoCOMercosulBolivia(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 2)
		{
			this.Name = "Mercosul Bolívia";
		}
		#endregion

		#region Carregamento de Dados
		#endregion
	}
}
