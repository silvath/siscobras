using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaGeral.
	/// </summary>
	public class clsIdiomaGeral: clsIdioma
	{
		#region Atributos
			private string m_strGroupBoxTexto = "Geral";
			//private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaGeral(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int nIdIdioma, ref System.Windows.Forms.ImageList bandeiras, string strTextoGroupBox): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,nIdIdioma, ref bandeiras)
		{
			try 
			{
				m_strGroupBoxTexto = strTextoGroupBox;
				this.carregaDadosBD();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaDadosBDEspecificos()
			{
			}
			#endregion
			#region Interface
			protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.GroupBox gbFields)
			{
				try
				{
					gbFields.Text = m_strGroupBoxTexto;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion
		#region Salvamento de Dados
			#region Banco Dados 
			protected override void SalvaDadosBDEspecificos()
			{
			}
			#endregion
		#endregion
	}
}
