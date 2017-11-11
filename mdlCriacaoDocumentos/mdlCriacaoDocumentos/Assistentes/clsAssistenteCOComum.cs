using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOComum.
	/// </summary>
	public class clsAssistenteCOComum : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOComum(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOComumNumero("Número");
			vInsertItemCOComumData("Data");
			vInsertItemCOComumProdutos("Produtos");
			vInsertItemCOComumObservacoes("Observações");
		}
		#endregion
	}
}
