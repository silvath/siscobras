using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteReserva.
	/// </summary>
	public class clsAssistenteReserva : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteReserva(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemReservaNumero("Número Reserva");
				vInsertItemReservaData("Data Reserva");
				vInsertItemOrdemEmbarqueAgenteCarga("Agente de Carga");
				vInsertItemOrdemEmbarqueAgenteCargaContato("Contato do Agente de Carga");
				vInsertItemOrdemEmbarqueArmador("Armador");
				vInsertItemOrdemEmbarqueArmadorNavio("Navio");
				vInsertItemReservaContainers("Containers");
				vInsertItemReservaDataChegadaPrevista("Data Chegada Prevista");
				vInsertItemReservaDataEspelhoBL("Data Espelho BL");
				vInsertItemReservaDataAberturaPortao("Data Abertura Portão");
				vInsertItemReservaDataFechamentoPortao("Data Fechamento Portão");
				vInsertItemReservaDataLiberacaoRF("Data Liberação RF");
				vInsertItemReservaDataListaCarga("Data Lista Carga");
				vInsertItemReservaDataRetiradaTerminal("Data Retirada Containers Terminal");
			}
		#endregion
	}
}
