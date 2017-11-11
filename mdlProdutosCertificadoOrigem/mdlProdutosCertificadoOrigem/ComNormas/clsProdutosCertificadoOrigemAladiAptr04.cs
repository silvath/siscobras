using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemAladiAptr04.
	/// </summary>
	public class clsProdutosCertificadoOrigemAladiAptr04 : clsProdutosCertificadoOrigemComNormas
	{
		#region Constructors and Destructors
			public clsProdutosCertificadoOrigemAladiAptr04(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, ALADIAPTR04, NALADI, ref ilBandeiras)
			{
				m_enumClassificacao = Classificacao.Naladi;
			}
		#endregion
	}
}
