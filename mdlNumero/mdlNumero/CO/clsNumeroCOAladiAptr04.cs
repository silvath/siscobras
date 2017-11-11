using System;

namespace mdlNumero.CO
{
	/// <summary>
	/// Summary description for clsNumeroCOAladiAptr04.
	/// </summary>
	public class clsNumeroCOAladiAptr04 : clsNumeroCO
	{
		#region Construtores & Destrutores
		public clsNumeroCOAladiAptr04(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, 4)
		{
		}
		#endregion

		#region Carregamento de Dados
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "AladiAptr04";
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
