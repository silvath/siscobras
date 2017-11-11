using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemMercosulChile.
	/// </summary>
	public class clsProdutosCertificadoOrigemMercosulChile : clsProdutosCertificadoOrigemComNormas
	{
		#region Construtores & Destrutores
			public clsProdutosCertificadoOrigemMercosulChile(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, MERCOSULCHILE, NALADI, ref ilBandeiras)
			{
				m_enumClassificacao = Classificacao.Naladi;
			}
		#endregion
	}
}
