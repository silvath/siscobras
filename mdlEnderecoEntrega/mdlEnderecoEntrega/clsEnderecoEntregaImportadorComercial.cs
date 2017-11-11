using System;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for clsEnderecoEntregaImportadorComercial.
	/// </summary>
	public class clsEnderecoEntregaImportadorComercial : clsEnderecoEntregaImportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		#endregion

		#region Construtores & Destrutores
		public clsEnderecoEntregaImportadorComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected override void carregaTypDatSet()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			protected override void carregaBDEspecificos()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowFaturasComerciais;
				dtrwRowFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwRowFaturasComerciais != null)
				{
					if (!dtrwRowFaturasComerciais.IsidImportadorNull())
					{
						m_nIdImportador = dtrwRowFaturasComerciais.idImportador;
						if (!dtrwRowFaturasComerciais.IsidImportadorEndEntregaNull())
						{
							m_nIdEnderecoEntrega = dtrwRowFaturasComerciais.idImportadorEndEntrega;
						}
					}
				}
				base.carregaTypDatSet();
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
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
			dtrwRowTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbFaturasComerciais != null)
			{
				dtrwRowTbFaturasComerciais.idImportadorEndEntrega = m_nIdEnderecoEntrega;
			}
			m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
		}
		#endregion
	}
}
