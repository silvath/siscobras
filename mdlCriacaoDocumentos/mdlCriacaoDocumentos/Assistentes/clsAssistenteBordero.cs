using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteBordero.
	/// </summary>
	public class clsAssistenteBordero : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteBordero(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemBorderoNumero("N�mero");
				vInsertItemFaturaComercialBancoExportador("Banco do Exportador");
				vInsertItemFaturaComercialBancoImportador("Banco do Importador");
				vInsertItemBorderoDocumentosAnexo("Documentos em Anexo");
				vInsertItemFaturaComercialDataEmbarque("Data de Embarque");
				vInsertItemOrdemEmbarqueDescricaoMercadorias("Descri��o geral das mercadorias");
				vInsertItemBorderoPagamento("Pagamento");
				vInsertItemBorderoContratoCambio("Contrato de C�mbio");
				vInsertItemBorderoCobranca("Cobran�a");
			}
		#endregion
	}
}
