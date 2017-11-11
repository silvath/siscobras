using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteSaque.
	/// </summary>
	public class clsAssistenteSaque : clsAssistente
	{
		#region Constructors and Destructors
			public clsAssistenteSaque(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
			{
				this.Exportador = nIdExportador;
				this.Codigo = IdPe;

				//Insere Itens
				vInsertItemSaqueNumero("Número");
				vInsertItemSaqueData("Data");
				if (bSaqueUtilizaDataEmbarque(nIdExportador,IdPe))
					vInsertItemFaturaComercialDataEmbarque("Data Embarque");
				vInsertItemSaqueObservacoes("Observações");
			}
		#endregion
		#region Data Embarque
			private bool bSaqueUtilizaDataEmbarque(int nIdExportador,string strIdPe)
			{
				System.Windows.Forms.ImageList ilBandeiras = mdlIdioma.clsIdioma.Bandeiras();
				mdlEsquemaPagamento.clsEsquemaPagamento objEsquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,nIdExportador,strIdPe);
				return((objEsquemaPagamento.CondicaoPostecipado > 0) && (objEsquemaPagamento.PostecipadoCondicao == mdlEsquemaPagamento.DocumentoCondicao.Conhecimento));
			}
		#endregion

	}
}
