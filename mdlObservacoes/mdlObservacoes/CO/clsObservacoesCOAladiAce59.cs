using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOAladiAce59.
	/// </summary>
	public class clsObservacoesCOAladiAce59 : clsObservacoesCO
	{
		#region Construtors 
		public clsObservacoesCOAladiAce59(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 29)
		{
			m_strCaption = "Aladi Ace 59";
		}
		#endregion
	}
}
