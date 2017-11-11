using System;

namespace mdlTrocaBooleano.Saque
{
	/// <summary>
	/// Summary description for clsTrocaCondicaoPagamentoAVista.
	/// </summary>
	public class clsTrocaCondicaoPagamentoAVista : clsTrocaBooleano
	{
		#region Atributos
		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		#endregion

		#region Construtores & Destrutores
		public clsTrocaCondicaoPagamentoAVista(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel)
		{
			m_nIdExportador = idExportador;
			m_strIdPE = strIdPE;
			this.carregaTypDatSet();
			this.carregaDadosBD();
		}
		#endregion

		#region Carregamento dos Dados
		protected override void carregaTypDatSet()
		{
			try
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

				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBD()
		{
			try
			{
				if (m_typDatSetTbSaques != null)
				{
					if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
						if (!dtrwTbSaque.IsbCondicaoPagamentoAvistaNull())
							m_bValorBooleano = dtrwTbSaque.bCondicaoPagamentoAvista;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecificos()
		{
			try
			{
				if (m_typDatSetTbSaques != null)
				{
					if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
						dtrwTbSaque.bCondicaoPagamentoAvista = m_bValorBooleano;
					}
					m_cls_dba_ConnectionDB.SetTbSaques(m_typDatSetTbSaques);
				}
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
