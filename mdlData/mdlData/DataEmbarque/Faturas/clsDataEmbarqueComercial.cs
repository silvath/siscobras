using System;

namespace mdlData.DataEmbarque.Faturas
{
	/// <summary>
	/// Summary description for clsDataEmbarqueComercial.
	/// </summary>
	public class clsDataEmbarqueComercial : clsData
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
			private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion
		#region Construtors and Destrutors
		public clsDataEmbarqueComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
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

					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionBD.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						// Idioma 
						if (!dtrwRowTbFaturasComerciais.IsidIdiomaNull())
							this.Idioma = dtrwRowTbFaturasComerciais.idIdioma;
						if (!dtrwRowTbFaturasComerciais.IsdataEmbarqueNull())
							m_dtData = dtrwRowTbFaturasComerciais.dataEmbarque;
						if (!dtrwRowTbFaturasComerciais.IsformatoDatasNull())
							m_strFormat = dtrwRowTbFaturasComerciais.formatoDatas;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					dtrwRowTbFaturasComerciais.formatoDatas = m_strFormat;
					dtrwRowTbFaturasComerciais.dataEmbarque = m_dtData;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwRowTbExportadores.formatoDataFatura = m_strFormat;
				}
				m_cls_dba_ConnectionBD.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
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
