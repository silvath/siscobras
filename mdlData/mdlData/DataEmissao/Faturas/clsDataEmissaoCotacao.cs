using System;

namespace mdlData.DataEmissao.Faturas
{
	/// <summary>
	/// Summary description for clsDataEmissaoCotacao.
	/// </summary>
	public class clsDataEmissaoCotacao : clsData
	{
		#region Atributos
		private string m_strIdCotacao = "";
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion
		#region Construtors and Destrutors
			public clsDataEmissaoCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idCotacao): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdCotacao = idCotacao;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.Name = "Fatura Proforma";
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

					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdCotacao);

					m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionBD.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
					{
						dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
						// Idioma 
						if (!dtrwRowTbFaturasCotacoes.IsidIdiomaNull())
							this.Idioma = dtrwRowTbFaturasCotacoes.idIdioma;
						if (!dtrwRowTbFaturasCotacoes.IsdataEmissaoNull())
							m_dtData = dtrwRowTbFaturasCotacoes.dataEmissao;
						if (!dtrwRowTbFaturasCotacoes.IsformatoDatasNull())
							m_strFormat = dtrwRowTbFaturasCotacoes.formatoDatas;
						else if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
						{
							dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
							if (!dtrwRowTbExportadores.IsformatoDataFaturaNull())
								m_strFormat = dtrwRowTbExportadores.formatoDataFatura;
						}
					}
					if (!bFormatValid())
						m_strFormat = "dd/MM/aaaa";					
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwRowTbFaturasCotacoes.formatoDatas = m_strFormat;
					dtrwRowTbFaturasCotacoes.dataEmissao = m_dtData;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				 {
					 dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					 dtrwRowTbExportadores.formatoDataFatura = m_strFormat;
				 }
				m_cls_dba_ConnectionBD.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
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
