using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemMercosulBolivia.
	/// </summary>
	public class clsProdutosCertificadoOrigemMercosulBolivia : clsProdutosCertificadoOrigemComNormas
	{
		#region Construtores & Destrutores
		public clsProdutosCertificadoOrigemMercosulBolivia(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, MERCOSULBOLIVIA, NALADI, ref ilBandeiras)
		{
			m_enumClassificacao = Classificacao.Naladi;
		}
		#endregion
	}
}
