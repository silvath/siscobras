using System;

namespace mdlProdutosCertificadoOrigem.SemNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemAnexoIII.
	/// </summary>
	public class clsProdutosCertificadoOrigemAnexoIII : clsProdutosCertificadoOrigemSemNormas
	{
		#region Construtors and Destrutors
			public clsProdutosCertificadoOrigemAnexoIII(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, ANEXO3, NALADI, ref ilBandeiras)
			{
			}
		#endregion
	}
}
