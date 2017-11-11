using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOMercosulBolivia.
	/// </summary>
	public class clsObservacoesCOMercosulBolivia : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOMercosulBolivia(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 2)
		{
			m_strCaption = "Mercosul Bolívia";
		}
		#endregion
	}
}
