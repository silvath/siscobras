using System;

namespace mdlAssinatura.Reserva
{
	/// <summary>
	/// Summary description for clsAssinaturaReserva.
	/// </summary>
	public class clsAssinaturaReserva : clsAssinatura
	{
		#region Atributos
			private string m_strIdPE = "";

			protected mdlDataBaseAccess.Tabelas.XsdTbReservas m_typDatSetTbReservas;
		#endregion
		#region Constructors and Destructors
			public clsAssinaturaReserva(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE) : base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,nIdExportador)
			{
				m_strIdPE = idPE;
				this.carregaTypDatSet();
				carregaDadosBD();
			}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
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
				base.carregaTypDatSet();
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
				if (m_typDatSetTbReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetTbReservas.tbReservas.Rows[0];
					if (!dtrwReserva.IsnIdAssinaturaNull())
						m_nIdAssinatura = dtrwReserva.nIdAssinatura;
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
		#region Salvamento de Dados
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_typDatSetTbReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetTbReservas.tbReservas.Rows[0];
					dtrwReserva.nIdAssinatura = m_nIdAssinatura;
				}
				m_cls_dba_ConnectionBD.SetTbReservas(m_typDatSetTbReservas);
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
