using System;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for clsMoedaCotacao.
	/// </summary>
	public class clsMoedaCotacao : clsMoeda
	{
		#region Atributos
			// ***************************************************************************************************
			// Atributos 
			// ***************************************************************************************************
		    private int m_nIdExportador;
			private string m_strIdCotacao;
			// ***************************************************************************************************
		#endregion
		#region Constructor
			public clsMoedaCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdCotacao) : base(ref tratadorErro, ref ConnectionDB,strEnderecoExecutavel)
			{
				m_nIdExportador = nIdExportador;
				m_strIdCotacao = strIdCotacao;
				this.CarregaMoedaBD();
   			}
		#endregion

		#region Carrega Dados
			protected override void CarregaMoedaBD()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwTbFaturasCotacoes = null;
				m_nIdMoeda = -1;
				m_bValorCarregado = true;
				System.Collections.ArrayList arlCondictionField = new System.Collections.ArrayList();
				arlCondictionField.Add("idExportador");
				arlCondictionField.Add("idCotacao");
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				System.Collections.ArrayList arlCondictionValue = new System.Collections.ArrayList();
				arlCondictionValue.Add(m_nIdExportador);
				arlCondictionValue.Add(m_strIdCotacao);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes tbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)tbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					// IdMoeda
					if (m_bHasValue = !dtrwTbFaturasCotacoes.IsidMoedaNull())
						m_nIdMoeda = Int32.Parse(dtrwTbFaturasCotacoes.idMoeda.ToString());
					// bMostrarSimboloMoeda
					if (!dtrwTbFaturasCotacoes.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwTbFaturasCotacoes.bMostrarSimboloMoeda;
					}
				}
				tbFaturasCotacoes.Dispose();
			}
		#endregion
		#region Salva Dados
			protected override void SalvaMoedaBD()
			{
				System.Collections.ArrayList arlCondictionField = new System.Collections.ArrayList();
				arlCondictionField.Add("idExportador");
				arlCondictionField.Add("idCotacao");
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				System.Collections.ArrayList arlCondictionValue = new System.Collections.ArrayList();
				arlCondictionValue.Add(m_nIdExportador);
				arlCondictionValue.Add(m_strIdCotacao);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes tbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondictionField,arlCondicaoComparador,arlCondictionValue,null,null);
				if (tbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFatura = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)tbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwFatura.idMoeda = m_nIdMoeda;
					dtrwFatura.bMostrarSimboloMoeda = m_bMostrarSimboloMoeda;
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(tbFaturasCotacoes);
				}
			}
		#endregion
	}
}
