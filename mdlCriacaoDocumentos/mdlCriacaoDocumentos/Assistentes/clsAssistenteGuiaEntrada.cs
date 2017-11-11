using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteGuiaEntrada.
	/// </summary>
	public class clsAssistenteGuiaEntrada : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteGuiaEntrada(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemFaturaComercialLocais("Locais");
				vInsertItemFaturaComercialLocalUnitizacao("Unitização");
				vInsertItemOrdemEmbarqueArmadorNavio("Navio");
				vInsertItemFaturaComercialNotaFiscal("Notas Fiscais");
				vInsertItemOrdemEmbarqueDescricaoMercadorias("Descricao Geral das Mercadorias");
				vInsertItemGuiaEntradaObservacoes("Observações");
			}
		#endregion
	}
}
