using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOFormA.
	/// </summary>
	public class clsObservacoesCOFormA : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOFormA(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 8)
		{
			m_strCaption = "Form A";
		}
		#endregion
	}
}
