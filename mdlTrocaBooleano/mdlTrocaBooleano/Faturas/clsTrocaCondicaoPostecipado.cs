using System;

namespace mdlTrocaBooleano.Faturas
{
	/// <summary>
	/// Summary description for clsTrocaCondicaoPostecipado.
	/// </summary>
	public class clsTrocaCondicaoPostecipado : clsTrocaBooleano
	{
		#region Atributos
		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		#endregion

		#region Construtores & Destrutores
		public clsTrocaCondicaoPostecipado(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE) : base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel)
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

				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				if (m_typDatSetTbFaturasComerciais != null)
				{
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwTbFaturasComerciais.IscondPostecipadoNull())
							m_bValorBooleano = (dtrwTbFaturasComerciais.condPostecipado > 0 ? true : false);
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
//				if (m_typDatSetTbFaturasComerciais != null)
//				{
//					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
//					{
//						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
//						dtrwTbFaturasComerciais.condAvista = m_bValorBooleano;
//					}
//					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
//				}
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
