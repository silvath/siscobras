using System;

namespace mdlProdutosCertificadoOrigem.SemNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemComum.
	/// </summary>
	public class clsProdutosCertificadoOrigemComum : clsProdutosCertificadoOrigemSemNormas
	{
		#region Construtores & Destrutores
		public clsProdutosCertificadoOrigemComum(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, COMUM, NCM, ref ilBandeiras)
		{
			m_enumClassificacao = Classificacao.Ncm;
		}
		#endregion
	}
}
