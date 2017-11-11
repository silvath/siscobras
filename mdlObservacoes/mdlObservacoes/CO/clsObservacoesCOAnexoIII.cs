using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOAnexoIII.
	/// </summary>
	public class clsObservacoesCOAnexoIII : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOAnexoIII(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 6)
		{
			m_strCaption = "Anexo III";
		}
		#endregion
	}
}
