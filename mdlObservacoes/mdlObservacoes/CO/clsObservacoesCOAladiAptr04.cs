using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOAladiAptr04.
	/// </summary>
	public class clsObservacoesCOAladiAptr04 : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOAladiAptr04(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 4)
		{
			m_strCaption = "Aladi Aptr 04";
		}
		#endregion
	}
}
