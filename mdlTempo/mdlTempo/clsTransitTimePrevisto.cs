using System;

namespace mdlTempo
{
	/// <summary>
	/// Summary description for clsTransitTimePrevisto.
	/// </summary>
	public class clsTransitTimePrevisto : clsTempo
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores;
		#endregion

		#region Construtores & Destrutores
		public clsTransitTimePrevisto(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
		{
			m_strIdPE = strIdPE;
			m_strGroupBoxTitulo = "Transit Time";
			carregaTypDatSet();
			carregaDadosBD();
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

				m_typDatSetTbExportadores = m_cls_dba_ConnectionBD.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionBD.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if (!dtrwRowTbInstrucoesEmbarque.IsnTransitTimePrevistoNull())
						m_nTempo = dtrwRowTbInstrucoesEmbarque.nTransitTimePrevisto;
				}
				if (m_nTempo == -1 && m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if (!dtrwRowTbExportadores.IsultimoTransitTimePrevistoNull())
						m_nTempo = dtrwRowTbExportadores.ultimoTransitTimePrevisto;
					else
					{
						m_nTempo = 1;
						m_bVazio = true;
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
		#endregion
		#region Salvamento dos Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if ((dtrwRowTbInstrucoesEmbarque != null) && (m_nTempo != -1))
						dtrwRowTbInstrucoesEmbarque.nTransitTimePrevisto = m_nTempo;
					else if (m_nTempo == -1)
						dtrwRowTbInstrucoesEmbarque.SetnTransitTimePrevistoNull();
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					if ((dtrwRowTbExportadores != null) && (m_nTempo != -1))
						dtrwRowTbExportadores.ultimoTransitTimePrevisto = m_nTempo;
				}
				m_cls_dba_ConnectionBD.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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
