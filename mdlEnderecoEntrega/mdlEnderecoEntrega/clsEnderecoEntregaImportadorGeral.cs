using System;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for clsEnderecoEntregaImportadorGeral.
	/// </summary>
	public class clsEnderecoEntregaImportadorGeral : clsEnderecoEntregaImportador
	{
		#region Construtores & Destrutores
		public clsEnderecoEntregaImportadorGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, int nIdImportador): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_nIdImportador = nIdImportador;
			m_nIdEnderecoEntrega = 0;
			carregaTypDatSet();
			carregaDadosBD();
			carregaDadosBDEndereco();
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaBDEspecificos()
			{				
			}
			private void carregaBDEndEntrega()
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
