using System;

namespace mdlData.DataEmbarque.Faturas
{
	/// <summary>
	/// Summary description for clsDataEmbarqueProforma.
	/// </summary>
	public class clsDataEmbarqueProforma : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion

		#region Construtors and Destructors
			public clsDataEmbarqueProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.Name = "Data Embarque";
			}
		#endregion

		#region Carregamento de Dados
			protected void carregaTypDatSet()
			{
				try
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionBD.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected override void carregaDadosBDEspecificos()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
					{
						dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
						// Idioma 
						if (!dtrwRowTbFaturasProformas.IsidIdiomaNull())
							this.Idioma = dtrwRowTbFaturasProformas.idIdioma;
						if (!dtrwRowTbFaturasProformas.IsdataEmbarqueNull())
							m_dtData = dtrwRowTbFaturasProformas.dataEmbarque;
						if (!dtrwRowTbFaturasProformas.IsformatoDatasNull())
							m_strFormat = dtrwRowTbFaturasProformas.formatoDatas;
						else if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
						{
							dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
							if (!dtrwRowTbExportadores.IsformatoDataFaturaNull())
								m_strFormat = dtrwRowTbExportadores.formatoDataFatura;
						}
					}				
					if (m_strFormat != null)
					{
						if (m_strFormat.Trim() == "")
						{
							m_strFormat = "dd/MMM/aaaa";
						}
					}
					else
					{
						m_strFormat = "dd/MMM/aaaa";
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region Salvamento de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					dtrwRowTbFaturasProformas.formatoDatas = m_strFormat;
					dtrwRowTbFaturasProformas.dataEmbarque = m_dtData;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwRowTbExportadores.formatoDataFatura = m_strFormat;
				}
				m_cls_dba_ConnectionBD.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
				m_cls_dba_ConnectionBD.SetTbExportadores(m_typDatSetTbExportadores);
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
