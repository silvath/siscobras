using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteFaturaCotacao.
	/// </summary>
	public class clsAssistenteFaturaCotacao : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteFaturaCotacao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdCotacao):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
				this.Exportador = nIdExportador;
				this.Codigo = IdCotacao;

				//Insere Itens
				this.vInsertItemFaturaCotacaoIdioma("Idioma");
				this.vInsertItemFaturaCotacaoMoeda("Moeda");
				this.vInsertItemFaturaCotacaoImportador("Importador");
				this.vInsertItemFaturaCotacaoProdutos("Produtos");
				this.vInsertItemFaturaCotacaoPesos("Pesos");
				this.vInsertItemFaturaCotacaoNumeroOrdemCompra("Número Ordem Compra");
				this.vInsertItemFaturaCotacaoIncoterms("Incoterm");
				this.vInsertItemFaturaCotacaoCondicoesPagamento("Esquema Pagamento");
				this.vInsertItemFaturaCotacaoBancoImportador("Banco Importador");
				this.vInsertItemFaturaCotacaoBancoExportador("Banco Exportador");
				this.vInsertItemFaturaCotacaoObservacoes("Observações");
				this.vInsertItemFaturaCotacaoAssinatura("Assinatura");
				this.vInsertItemFaturaCotacaoNumero("Número");
		}
		#endregion
	}
}
