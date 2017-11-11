using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOAladiAptr04.
	/// </summary>
	public class clsAssistenteCOAladiAptr04 : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOAladiAptr04(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOAladiAptr04Numero("Número");
			vInsertItemCOAladiAptr04Data("Data");
			vInsertItemCOAladiAptr04Produtos("Produtos");
			vInsertItemCOAladiAptr04Observacoes("Observações");
		}
		#endregion
	}
}
