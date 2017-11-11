using System;

namespace mdlData.DataReserva
{
	/// <summary>
	/// Summary description for clsDataReservaInstrucoesEmbarque.
	/// </summary>
	public class clsDataReservaInstrucoesEmbarque : clsData
	{
		#region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		#endregion

		#region Construtores & Destrutores
		public clsDataReservaInstrucoesEmbarque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			vCarregaDadosBD();
			this.Name = "Reserva";
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
			protected override void carregaDadosBDEspecificos()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
					{
						dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
						if (!dtrwRowTbInstrucoesEmbarque.IsdtReservaNull())
							m_dtData = dtrwRowTbInstrucoesEmbarque.dtReserva;
					}
					if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
					{
						dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
						if (!dtrwRowTbExportadores.IsformatoDataFaturaNull())
							m_strFormat = dtrwRowTbExportadores.formatoDataFatura;
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
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwRowTbInstrucoesEmbarque;
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					dtrwRowTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					dtrwRowTbInstrucoesEmbarque.dtReserva = m_dtData;
				}
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwRowTbExportadores.formatoDataFatura = m_strFormat;
				}
				m_cls_dba_ConnectionBD.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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
