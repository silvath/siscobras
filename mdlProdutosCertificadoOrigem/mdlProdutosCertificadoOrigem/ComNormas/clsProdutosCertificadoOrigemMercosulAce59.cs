using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemMercosulAce59.
	/// </summary>
	public class clsProdutosCertificadoOrigemMercosulAce59 : clsProdutosCertificadoOrigemComNormas
	{
		#region Construtors 
			public clsProdutosCertificadoOrigemMercosulAce59(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, ALADIACE59, NALADI, ref ilBandeiras)
			{
				m_enumClassificacao = Classificacao.Naladi;
			}
		#endregion
	}
}
