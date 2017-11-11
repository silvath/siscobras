using System;

namespace mdlNumero.Faturas
{
	/// <summary>
	/// Summary description for clsNumeroCotacao.
	/// </summary>
	public class clsNumeroCotacao : clsNumero
	{
		#region Atributos
			private string m_strIdCotacao = "";
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		#endregion
		#region Construtors and Destrutors
			public clsNumeroCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idCotacao): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdCotacao = idCotacao;
				carregaTypDatSet();
				carregaDadosBD();
				m_bMascaraEditavel = false;
			}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

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
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador, m_strIdCotacao);
					if (dtrwRowTbFaturasCotacoes != null)
					{
						m_strNumero = dtrwRowTbFaturasCotacoes.idCotacao.Replace("\0","");
					}
					else
					{
						m_strNumero = m_strIdCotacao;
					}
				}
				else
				{
					m_strNumero = m_strIdCotacao;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "Cotação";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				lSugestao.Visible = false;
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
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwReturnCotacao(string strNumero)
		{
			foreach(mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwCurrent in m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows)
				if ((dtrwCurrent.RowState != System.Data.DataRowState.Deleted) && (!dtrwCurrent.IsmstrNumeroNull()) && (dtrwCurrent.idExportador == m_nIdExportador) && (dtrwCurrent.mstrNumero == strNumero))
					return(dtrwCurrent);
			return(null);
		}
		protected override void salvaDadosBDEspecifico()
		{
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
			if (m_strNumero != m_strNumeroNovo)
			{
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = dtrwReturnCotacao(m_strNumeroNovo);
					if (dtrwRowTbFaturasCotacoes != null)
						dtrwRowTbFaturasCotacoes.mstrNumero = m_strNumeroNovo;
					m_cls_dba_ConnectionBD.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
				}
			}
		}
		#endregion
	}
}
