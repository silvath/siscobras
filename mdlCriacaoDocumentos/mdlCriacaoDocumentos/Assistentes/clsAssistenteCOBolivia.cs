using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOBolivia.
	/// </summary>
	public class clsAssistenteCOBolivia : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOBolivia(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOMercosulBoliviaNumero("Número");
			vInsertItemCOMercosulBoliviaData("Data");
			vInsertItemCOMercosulBoliviaProdutos("Produtos");
			vInsertItemCOMercosulBoliviaObservacoes("Observações");
		}
		#endregion
	}
}
