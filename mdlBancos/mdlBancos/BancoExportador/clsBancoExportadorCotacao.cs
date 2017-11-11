using System;

namespace mdlBancos.BancoExportador
{
	/// <summary>
	/// Summary description for clsBancoExportadorCotacao.
	/// </summary>
	public class clsBancoExportadorCotacao : clsBancoExportador
	{
		#region Atributos
		private string m_strIdCotacao = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes;
		#endregion

		#region Construtores & Destrutores
		public clsBancoExportadorCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string idCotacao) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador)
		{
			m_bDocumento = true;
			m_strIdCotacao = idCotacao;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento de Dados
		protected new void carregaTypDatSet()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idCotacao");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdCotacao);

			m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionBD.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			base.carregaTypDatSet();
		}
		protected override void carregaBDEspecificos()
		{
			try 
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
				if (dtrwRowTbFaturasCotacoes != null)
				{
					if (!dtrwRowTbFaturasCotacoes.IsidExportadorBancoNull())
                        m_nIdBanco = dtrwRowTbFaturasCotacoes.idExportadorBanco;
					if (!dtrwRowTbFaturasCotacoes.IsidExportadorBancoAgenciaNull())
                        m_strIdAgencia = dtrwRowTbFaturasCotacoes.idExportadorBancoAgencia;
					if (!dtrwRowTbFaturasCotacoes.IsidExportadorBancoContaNull())
                        m_strIdConta = dtrwRowTbFaturasCotacoes.idExportadorBancoConta;
					if (!dtrwRowTbFaturasCotacoes.IsmstrIdExportadorBancoInstrPgtoNull())
                        m_strInstrucoesPagamento = dtrwRowTbFaturasCotacoes.mstrIdExportadorBancoInstrPgto;
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
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
			dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
			if (dtrwRowTbFaturasCotacoes != null)
			{
				dtrwRowTbFaturasCotacoes.idExportadorBanco = m_nIdBanco;
				dtrwRowTbFaturasCotacoes.idExportadorBancoAgencia = m_strIdAgencia;
				dtrwRowTbFaturasCotacoes.idExportadorBancoConta = m_strIdConta;
				dtrwRowTbFaturasCotacoes.mstrIdExportadorBancoInstrPgto = m_strInstrucoesPagamento;
			}
			m_cls_dba_ConnectionBD.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
		}
		#endregion
	}
}
