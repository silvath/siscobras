using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOComum.
	/// </summary>
	public class clsObservacoesCOComum : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOComum(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 7)
		{
			m_strCaption = "Comum";;
		}
		#endregion
	}
}
