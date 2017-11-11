using System;

namespace mdlCartaCredito
{
	/// <summary>
	/// Summary description for clsCartaCreditoGeral.
	/// </summary>
	public class clsCartaCreditoGeral : clsCartaCredito
	{
		#region Construtores & Destrutores
		public clsCartaCreditoGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, int idImportador) : base (ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador, idImportador)
		{
			base.carregaTypDatSet();
			base.carregaNomeImportador();
		}
		#endregion

		#region Carregamento dos Dados
		#region Interface
		protected override void carregaDadosInterfaceGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
