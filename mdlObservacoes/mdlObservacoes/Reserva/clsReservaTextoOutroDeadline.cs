using System;

namespace mdlObservacoes.Reserva
{
	/// <summary>
	/// Summary description for clsReservaTextoOutroDeadline.
	/// </summary>
	public class clsReservaTextoOutroDeadline : clsObservacoes
	{
		#region Atributes
			private string m_strIdPE = "";

			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes;
		#endregion
		#region Constructors and Destructors
			public clsReservaTextoOutroDeadline(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = strIdPE;
				carregaTypDatSet();
				carregaDadosBD();
				m_strCaption = "Outro Deadline";
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

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetPes = m_cls_dba_ConnectionBD.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				if (m_typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];;
					if (!dtrwRowPe.IsstrDeadlineOutroNull())
						m_strObservacoes = dtrwRowPe.strDeadlineOutro;
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
			if (m_typDatSetPes.tbPEs.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];;
				dtrwRowPe.strDeadlineOutro = m_strObservacoes;
				m_cls_dba_ConnectionBD.SetTbPes(m_typDatSetPes);
			}
		}
		#endregion
		#endregion

	}
}
