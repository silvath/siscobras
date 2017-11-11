using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteRomaneioSimplificado.
	/// </summary>
	public class clsAssistenteRomaneioSimplificado : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteRomaneioSimplificado(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemRomaneioNumero("Número");
				vInsertItemRomaneioData("Data");
				vInsertItemRomaneioProdutosSimplificado("Produtos");
				vInsertItemRomaneioObservacoes("Observações");
				vInsertItemRomaneioAssinatura("Assinatura");
			}
		#endregion
	}
}
