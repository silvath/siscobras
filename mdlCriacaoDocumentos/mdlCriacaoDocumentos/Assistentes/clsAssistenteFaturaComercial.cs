using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteFaturaComercial.
	/// </summary>
	public class clsAssistenteFaturaComercial : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				this.vInsertItemFaturaComercialIdioma("Idioma");
				this.vInsertItemFaturaComercialMoeda("Moeda");
				this.vInsertItemFaturaComercialImportador("Importador");
				this.vInsertItemFaturaComercialProdutos("Produtos");
				this.vInsertItemFaturaComercialPesos("Pesos");
				this.vInsertItemFaturaComercialNumeroOrdemCompra("Número Ordem Compra");
				this.vInsertItemFaturaComercialIncoterms("Incoterm");
				this.vInsertItemFaturaComercialCondicoesPagamento("Esquema Pagamento");
			    this.vInsertItemFaturaComercialBancoImportador("Banco Importador");
			    this.vInsertItemFaturaComercialBancoExportador("Banco Exportador");
			    this.vInsertItemFaturaComercialObservacoes("Observações");
			    this.vInsertItemFaturaComercialAssinatura("Assinatura");
			    this.vInsertItemFaturaComercialNumero("Número");
			}
		#endregion
	}
}
