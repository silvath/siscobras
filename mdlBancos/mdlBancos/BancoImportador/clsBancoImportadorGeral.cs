using System;

namespace mdlBancos.BancoImportador
{
	/// <summary>
	/// Summary description for clsBancoImportadorGeral.
	/// </summary>
	public class clsBancoImportadorGeral : clsBancoImportador
	{
		#region Construtores & Destrutores
			public clsBancoImportadorGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,int idImportador): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_bDocumento = false;
				m_nIdImportador = idImportador;
				carregaTypDatSet();
				carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaBDEspecificos()
			{
			}
			#endregion
			#region Interface
			protected override void carregaDadosInterfaceEspecifico()
			{
			}
			#endregion
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{	
		}
		#endregion
	}
}
