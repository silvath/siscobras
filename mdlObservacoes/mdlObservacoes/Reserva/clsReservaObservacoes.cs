using System;

namespace mdlObservacoes.Reserva
{
	/// <summary>
	/// Summary description for clsReservaObservacoes.
	/// </summary>
	public class clsReservaObservacoes : clsObservacoes
	{
		#region Atributes
			private string m_strIdPE = "";

			private mdlDataBaseAccess.Tabelas.XsdTbReservas m_typDatSetReservas;
		#endregion
		#region Constructors and Destructors
			public clsReservaObservacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string strIdPE): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = strIdPE;
				carregaTypDatSet();
				carregaDadosBD();
				m_strCaption = "Observações";
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
				
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetReservas = m_cls_dba_ConnectionBD.GetTbReservas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				if (m_typDatSetReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwRowReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetReservas.tbReservas.Rows[0];;
					if (!dtrwRowReserva.IsmstrObservacaoNull())
						m_strObservacoes = dtrwRowReserva.mstrObservacao;
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
			if (m_typDatSetReservas.tbReservas.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetReservas.tbReservas.Rows[0];;
				dtrwReserva.mstrObservacao = m_strObservacoes;
				m_cls_dba_ConnectionBD.SetTbReservas(m_typDatSetReservas);
			}
		}
		#endregion
		#endregion
	}
}
