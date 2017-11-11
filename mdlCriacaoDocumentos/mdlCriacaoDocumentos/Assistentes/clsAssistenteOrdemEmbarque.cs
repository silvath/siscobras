using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteOrdemEmbarque.
	/// </summary>
	public class clsAssistenteOrdemEmbarque : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteOrdemEmbarque(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemOrdemEmbarqueNumero("N�mero");
				vInsertItemReservaNumero("N�mero Reserva");
				vInsertItemReservaData("Data Reserva");
				vInsertItemOrdemEmbarqueConsignatario("Consignat�rio");
				vInsertItemOrdemEmbarqueAgenteCarga("Agente de Carga");
				vInsertItemOrdemEmbarqueAgenteCargaContato("Contato do Agente de Carga");
				vInsertItemOrdemEmbarqueNotificar("Notificar");
				vInsertItemOrdemEmbarqueNotificar2("Notificar Tambem");
				vInsertItemOrdemEmbarqueDescricaoMercadorias("Descri��o das Mercadorias");
				vInsertItemOrdemEmbarqueClassificacaoTarifaria("Classificacao Tarif�ria");
				vInsertItemOrdemEmbarqueDespachante("Despachante");
				vInsertItemOrdemEmbarqueDespachanteContato("Contato do Despachante");
				vInsertItemOrdemEmbarqueSiscomex("Siscomex");
				vInsertItemOrdemEmbarqueObservacoes("Observa��es");
			}
		#endregion
	}
}
