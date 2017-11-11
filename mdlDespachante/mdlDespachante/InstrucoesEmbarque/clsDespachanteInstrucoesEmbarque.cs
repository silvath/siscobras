using System;

namespace mdlDespachante.InstrucoesEmbarque
{
	/// <summary>
	/// Summary description for clsDespachanteInstrucoesEmbarque.
	/// </summary>
	public class clsDespachanteInstrucoesEmbarque //: clsDespachante
	{
//		#region Atributos
//		private int m_nIdExportador = -1;
//		private string m_strIdPE = "";
//
//		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
//		#endregion
//
//		#region Construtores & Destrutores
//		public clsDespachanteInstrucoesEmbarque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel)
//		{
//			m_nIdExportador = nIdExportador;
//			m_strIdPE = strIdPE;
//			this.carregaTypDatSet();
//			carregaDadosBDEspecificos();
//			carregaDadosBDDespachantes();
//		}
//		#endregion
//
//		#region Inicializa Variáveis TypDatSet
//		private void carregaTypDatSet()
//		{
//			try
//			{
//				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
//				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
//				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
//
//				arlCondicaoCampo.Add("idExportador");
//				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
//				arlCondicaoValor.Add(m_nIdExportador);
//
//				arlCondicaoCampo.Add("idPE");
//				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
//				arlCondicaoValor.Add(m_strIdPE);
//
//				m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//		}
//		#endregion
//
//		#region Carregamento Dos Dados
//		protected override void carregaDadosBDEspecificos()
//		{
//			try
//			{
//				if ((m_typDatSetTbInstrucoesEmbarque != null) && (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0))
//				{
//					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
//					if ((dtrwTbInstrucoesEmbarque != null) && (!dtrwTbInstrucoesEmbarque.IsnIdDespachanteNull()))
//						m_nIdDespachante = dtrwTbInstrucoesEmbarque.nIdDespachante;
//				}
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//		}
//		#endregion
//
//		#region Salvamento Dos Dados
//		#region Banco de Dados
//		protected override void salvaDadosBDEspecifico()
//		{
//			try
//			{
//				if ((m_typDatSetTbInstrucoesEmbarque != null) && (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0))
//				{
//					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
//					if (dtrwTbInstrucoesEmbarque != null)
//						dtrwTbInstrucoesEmbarque.nIdDespachante = m_nIdDespachante;
//					m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
//				}
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//		}
//		#endregion
//		#endregion
//

	}
}
