using System;

namespace mdlObservacoes.CO
{
	/// <summary>
	/// Summary description for clsObservacoesCOMercosulChile.
	/// </summary>
	public class clsObservacoesCOMercosulChile : clsObservacoesCO
	{
		#region Construtores & Destrutores
		public clsObservacoesCOMercosulChile(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 3)
		{
			m_strCaption = "Mercosul Chile"; 
		}
		#endregion
	}
}
