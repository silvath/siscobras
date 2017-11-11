using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOMercosul.
	/// </summary>
	public class clsAssistenteCOMercosul : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOMercosul(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOMercosulNumero("N�mero");
			vInsertItemCOMercosulData("Data");
			vInsertItemCOMercosulProdutos("Produtos");
			vInsertItemCOMercosulObservacoes("Observa��es");
		}
		#endregion
	}
}
