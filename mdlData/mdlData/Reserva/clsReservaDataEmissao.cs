using System;

namespace mdlData.Reserva
{
	/// <summary>
	/// Summary description for clsReservaDataEmissao.
	/// </summary>
	public class clsReservaDataEmissao : clsData
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbReservas m_typDatSetTbReservas = null;
		#endregion
		#region Constructors and Destructors
			public clsReservaDataEmissao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				m_strFormat = mdlConstantes.clsConstantes.DATEFORMATDEFAULT;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.EditFormat = true;
				this.Name = "Data Emissão";
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
				
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbReservas = m_cls_dba_ConnectionBD.GetTbReservas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
					if (m_typDatSetTbReservas.tbReservas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetTbReservas.tbReservas.Rows[0];
						if (!dtrwReserva.IsdtEmissaoNull())
							m_dtData = dtrwReserva.dtEmissao;
						if (!dtrwReserva.IsstrFormatDateEmissaoNull())
							m_strFormat = dtrwReserva.strFormatDateEmissao;
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
					if (m_typDatSetTbReservas.tbReservas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetTbReservas.tbReservas.Rows[0];
						dtrwReserva.dtEmissao = m_dtData;
						dtrwReserva.strFormatDateEmissao = m_strFormat;
					}
					m_cls_dba_ConnectionBD.SetTbReservas(m_typDatSetTbReservas);
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
