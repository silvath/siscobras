using System;

namespace mdlObservacoes.Faturas
{
	/// <summary>
	/// Summary description for clsObervacoesFaturaCotacao.
	/// </summary>
	public class clsObservacoesFaturaCotacao : clsObservacoes
	{
		#region Atributos
		private string m_strIdCotacao = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes;
		#endregion

		#region Construtores & Destrutores
		public clsObservacoesFaturaCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdCotacao): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdCotacao = strIdCotacao;
			carregaTypDatSet();
			carregaDadosBD();
			m_strCaption = "Observa��es da Cota��o";
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
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
		protected override void carregaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowTbFaturasCotacoes.mstrObservacao;
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (dtrwRowTbFaturasCotacoes != null)
						dtrwRowTbFaturasCotacoes.mstrObservacao = m_strObservacoes;
				}
				m_cls_dba_ConnectionBD.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
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
