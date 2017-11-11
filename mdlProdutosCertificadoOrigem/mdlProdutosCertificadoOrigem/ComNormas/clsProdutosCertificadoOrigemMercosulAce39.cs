using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemMercosulAce39.
	/// </summary>
	public class clsProdutosCertificadoOrigemMercosulAce39 : clsProdutosCertificadoOrigemComNormas
	{
		#region Construtores & Destrutores
		public clsProdutosCertificadoOrigemMercosulAce39(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, ALADIACE39, NALADI, ref ilBandeiras)
		{
			m_enumClassificacao = Classificacao.Naladi;
		}
		#endregion
	}
}
