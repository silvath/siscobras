using System;

namespace mdlData.Reserva
{
	/// <summary>
	/// Summary description for clsReservaDeadlineOutra.
	/// </summary>
	public class clsReservaDeadlineOutra : clsData
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		#endregion
		#region Constructors and Destructors
			public clsReservaDeadlineOutra(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador)
			{
				m_strIdPE = idPE;
				m_strFormat = mdlConstantes.clsConstantes.DEADLINEDATEFORMATDEFAULT;
				carregaTypDatSet();
				vCarregaDadosBD();
				this.EditFormat = true;
				this.Name = "Outro Deadline";
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
						if (!dtrwPe.IsdtDeadlineOutroNull())
							m_dtData = dtrwPe.dtDeadlineOutro;
						if (!dtrwPe.IsstrFormatDeadlineOutroNull())
							m_strFormat = dtrwPe.strFormatDeadlineOutro;
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
						dtrwPe.dtDeadlineOutro = m_dtData;
						dtrwPe.strFormatDeadlineOutro = m_strFormat;
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
