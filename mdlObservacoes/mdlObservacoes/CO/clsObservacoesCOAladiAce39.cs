using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOAladiAce39.
	/// </summary>
	public class clsObservacoesCOAladiAce39 : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOAladiAce39(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 5)
		{
			m_strCaption = "Aladi Ace 39";
		}
		#endregion
	}
}
