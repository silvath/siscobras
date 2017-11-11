using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOMercosulChile.
	/// </summary>
	public class clsAssistenteCOMercosulChile : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOMercosulChile(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOMercosulChileNumero("Número");
			vInsertItemCOMercosulChileData("Data");
			vInsertItemCOMercosulChileProdutos("Produtos");
			vInsertItemCOMercosulChileObservacoes("Observações");
		}
		#endregion
	}
}
