using System;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for clsEnderecoEntregaImportadorCotacao.
	/// </summary>
	public class clsEnderecoEntregaImportadorCotacao : clsEnderecoEntregaImportador
	{
		#region Atributos
		protected string m_strIdCotacao = "";

		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes;
		#endregion

		#region Construtores & Destrutores
		public clsEnderecoEntregaImportadorCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string idCotacao): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdCotacao = idCotacao;
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
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCotacao);

				m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			protected override void carregaBDEspecificos()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowFaturasCotacoes;
				dtrwRowFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
				if (dtrwRowFaturasCotacoes != null)
				{
					if (!dtrwRowFaturasCotacoes.IsidImportadorNull())
					{
						m_nIdImportador = dtrwRowFaturasCotacoes.idImportador;
						if (!dtrwRowFaturasCotacoes.IsidImportadorEndEntregaNull())
						{
							m_nIdEnderecoEntrega = dtrwRowFaturasCotacoes.idImportadorEndEntrega;
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
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
			dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
			if (dtrwRowTbFaturasCotacoes != null)
			{
				dtrwRowTbFaturasCotacoes.idImportadorEndEntrega = m_nIdEnderecoEntrega;
			}
			m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
		}
		#endregion
	}
}
