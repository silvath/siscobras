using System;

namespace mdlData.Reserva
{
	/// <summary>
	/// Summary description for clsReservaDeadlineChegadaPrevista.
	/// </summary>
	public class clsReservaDeadlineChegadaPrevista : clsData
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		#endregion
		#region Constructors and Destructors
			public clsReservaDeadlineChegadaPrevista(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				m_strFormat = "dd/MM/aaaa";
				carregaTypDatSet();
				vCarregaDadosBD();
				this.EditFormat = true;
				this.Name = "Chegada Prevista";
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

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbPes = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
						if (!dtrwPe.IsdtDeadlineChegadaPrevistaTransporteNull())
							m_dtData = dtrwPe.dtDeadlineChegadaPrevistaTransporte;
						if (!dtrwPe.IsstrFormatDeadlineChegadaPrevistaTransporteNull())
							m_strFormat = dtrwPe.strFormatDeadlineChegadaPrevistaTransporte;
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
				try
				{
					if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
						dtrwPe.dtDeadlineChegadaPrevistaTransporte = m_dtData;
						dtrwPe.strFormatDeadlineChegadaPrevistaTransporte = m_strFormat;
					}
					m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetTbPes);
					vSiscoMensagemUpdate();
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
