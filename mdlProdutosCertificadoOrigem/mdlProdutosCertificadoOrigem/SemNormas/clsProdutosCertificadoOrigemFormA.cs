using System;

namespace mdlProdutosCertificadoOrigem.SemNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemFormA.
	/// </summary>
	public class clsProdutosCertificadoOrigemFormA : clsProdutosCertificadoOrigemSemNormas
	{
		#region Construtors and Destrutors
			public clsProdutosCertificadoOrigemFormA(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, FORMA, -1, ref ilBandeiras)
			{
				m_enumClassificacao = Classificacao.Naladi;
			}
		#endregion
	}
}
