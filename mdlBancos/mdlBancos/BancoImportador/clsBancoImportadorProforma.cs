using System;

namespace mdlBancos.BancoImportador
{
	/// <summary>
	/// Summary description for clsBancoImportadorProforma.
	/// </summary>
	public class clsBancoImportadorProforma : clsBancoImportador
	{
		#region Atributos
		protected string m_strIdPE = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas;
		#endregion

		#region Construtores & Destrutores
		public clsBancoImportadorProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_bDocumento = true;
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
						if (!dtrwRowFaturasProformas.IsidImportadorBancoNull())
							m_nIdBanco = dtrwRowFaturasProformas.idImportadorBanco;
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
				dtrwRowTbFaturasProformas.idImportadorBanco = m_nIdBanco;
			m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
		}
		#endregion
	}
}
