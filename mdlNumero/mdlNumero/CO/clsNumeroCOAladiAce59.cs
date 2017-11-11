using System;

namespace mdlNumero.CO
{
	/// <summary>
	/// Summary description for clsNumeroCOAladiAce59.
	/// </summary>
	public class clsNumeroCOAladiAce59 : clsNumeroCO
	{
		#region Construtors
		public clsNumeroCOAladiAce59(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 29)
		{
		}
		#endregion

		#region Carregamento de Dados
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "AladiAce59";
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
