using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOMercosul.
	/// </summary>
	public class clsObservacoesCOMercosul : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOMercosul(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 1)
		{
			m_strCaption = "Mercosul";
		}
		#endregion
	}
}
