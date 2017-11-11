using System;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for clsEnderecoEntregaImportadorProforma.
	/// </summary>
	public class clsEnderecoEntregaImportadorProforma : clsEnderecoEntregaImportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas;
		#endregion

		#region Construtores & Destrutores
		public clsEnderecoEntregaImportadorProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
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

			m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
		}
		protected override void carregaBDEspecificos()
		{
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowFaturasProformas;
			dtrwRowFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowFaturasProformas != null)
			{
				if (!dtrwRowFaturasProformas.IsidImportadorNull())
				{
					m_nIdImportador = dtrwRowFaturasProformas.idImportador;
					if (!dtrwRowFaturasProformas.IsidImportadorEndEntregaNull())
					{
						m_nIdEnderecoEntrega = dtrwRowFaturasProformas.idImportadorEndEntrega;
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
			mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
			dtrwRowTbFaturasProformas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbFaturasProformas != null)
			{
				dtrwRowTbFaturasProformas.idImportadorEndEntrega = m_nIdEnderecoEntrega;
			}
			m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
		}
		#endregion
	}
}
