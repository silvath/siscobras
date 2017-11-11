using System;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for clsImportadorExportador.
	/// </summary>
	public class clsImportadorExportador : clsImportador
	{
		#region Construtor & Destrutor
		public clsImportadorExportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,ref System.Windows.Forms.ImageList bandeiras) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, ref bandeiras)
		{
			m_strCaptionFrame = "Cadastro de Importadores";
			this.inicializaTypDatSet();
			this.carregaDadosBD();
			this.carregaDadosBDCadEdit();
		}
		#endregion

		#region Inicializa variável TypDatSet
		protected new void inicializaTypDatSet()
		{
			base.inicializaTypDatSet();
		}
		#endregion

		#region Carregamento dos Dados
		protected override void carregaDadosBDEspecificos()
		{
		}
		protected override void carregaDadosInterfaceEspecifico()
		{
		}
		#endregion

		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecifico()
		{			
		}
		#endregion
	}
}
