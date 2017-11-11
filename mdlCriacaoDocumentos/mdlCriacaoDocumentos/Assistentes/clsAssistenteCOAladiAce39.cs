using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistenteCOAladiAce39.
	/// </summary>
	public class clsAssistenteCOAladiAce39 : clsAssistente
	{
		#region Constructors and Destructors
		public clsAssistenteCOAladiAce39(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel,int nIdExportador,string IdPe):base(ref cls_ter_TratadorErro,ref cls_dba_ConnnectionDB,strEnderecoExecutavel)
		{
			this.Exportador = nIdExportador;
			this.Codigo = IdPe;

			//Insere Itens
			vInsertItemCOAladiAce39Numero("Número");
			vInsertItemCOAladiAce39Data("Data");
			vInsertItemCOAladiAce39Produtos("Produtos");
			vInsertItemCOAladiAce39Observacoes("Observações");
		}
		#endregion
	}
}
