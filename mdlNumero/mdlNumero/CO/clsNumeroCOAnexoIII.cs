using System;

namespace mdlNumero.CO
{
	/// <summary>
	/// Summary description for clsNumeroCOAnexoIII.
	/// </summary>
	public class clsNumeroCOAnexoIII : clsNumeroCO
	{
		#region Construtores & Destrutores
		public clsNumeroCOAnexoIII(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 6)
		{
		}
		#endregion

		#region Carregamento de Dados
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "AnexoIII";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
