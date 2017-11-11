using System;

namespace mdlNumero.Reserva
{
	/// <summary>
	/// Summary description for clsNumeroReserva.
	/// </summary>
	public class clsNumeroReserva : clsNumero
	{
		#region Atributes
			private mdlDataBaseAccess.Tabelas.XsdTbReservas m_typDatSetReservas = null;
		#endregion
		#region Constructors and Destructors
			public clsNumeroReserva(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador) 
			{
				m_strIdPE = idPE;
				carregaTypDatSet();
				carregaDadosBD();
				m_bMascaraEditavel = false;
				m_bMascaraPEs = false;
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

				m_typDatSetReservas = m_cls_dba_ConnectionBD.GetTbReservas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				if (m_typDatSetReservas.tbReservas.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetReservas.tbReservas[0];
					if (!dtrwReserva.IsstrNumeroNull())
					{
						m_strNumero = dtrwReserva.strNumero;
						m_strNumeroNovo = dtrwReserva.strNumero;
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
		#region Interface
		protected override void carregaDadosInterfaceTextGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "Número Reserva (Booking)";
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void montaLabelSugestao(ref System.Windows.Forms.Label lSugestao)
		{
			try
			{
				lSugestao.Visible = false;
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
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_strNumero != m_strNumeroNovo)
				{
					if (m_typDatSetReservas.tbReservas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow dtrwReserva = (mdlDataBaseAccess.Tabelas.XsdTbReservas.tbReservasRow)m_typDatSetReservas.tbReservas.Rows[0];
						dtrwReserva.strNumero = m_strNumeroNovo;
						m_cls_dba_ConnectionBD.SetTbReservas(m_typDatSetReservas);
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

	}
}
