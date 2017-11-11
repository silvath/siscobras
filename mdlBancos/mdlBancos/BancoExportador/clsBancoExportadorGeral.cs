using System;

namespace mdlBancos.BancoExportador
{
	/// <summary>
	/// Summary description for clsBancoExportadorGeral.
	/// </summary>
	public class clsBancoExportadorGeral : clsBancoExportador
	{
		#region Construtores & Destrutores
		public clsBancoExportadorGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador)
		{
			m_bDocumento = false;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		protected override void carregaBDEspecificos()
		{
		}
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
		}
		#endregion
	}
}
