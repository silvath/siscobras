using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemMercosul.
	/// </summary>
	public class clsProdutosCertificadoOrigemMercosul : clsProdutosCertificadoOrigemComNormas
	{
		#region Construtores & Destrutores
		public clsProdutosCertificadoOrigemMercosul(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, MERCOSUL, NCM, ref ilBandeiras)
		{
			m_enumClassificacao = Classificacao.Ncm;
		}
		#endregion
	}
}
