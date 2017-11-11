using System;

namespace mdlCartaCredito.PE
{
	/// <summary>
	/// Summary description for clsCartaCreditoPE.
	/// </summary>
	public class clsCartaCreditoPE : clsCartaCredito
	{
		#region Atributos
		protected string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		#endregion

		#region Construtores & Destrutores
		public clsCartaCreditoPE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, int idImportador,string strIdPE) : base (ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, idExportador, idImportador)
		{
			m_strIdPE = strIdPE;
			carregaTypDatSetPE();
			carregaDadosPE();
			carregaDadosFC();
			carregaDadosMoeda();
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSetPE()
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

				m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosPE()
		{
			try
			{
				if ((m_typDatSetTbPes != null) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					if (!dtrwTbPes.IsnIdCartaCreditoNull())
						m_nIdCartaCredito = dtrwTbPes.nIdCartaCredito;
					else
						m_nIdCartaCredito = -1;
				}
				base.carregaTypDatSet();
				base.carregaNomeImportador();
				if ((m_typDatSetTbCartasCredito != null) && (m_typDatSetTbCartasCredito.tbCartasCredito.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito = m_typDatSetTbCartasCredito.tbCartasCredito.FindBynIdCartaCreditonIdExportadornIdImportador(m_nIdCartaCredito, m_nIdExportador, m_nIdImportador);
					if (dtrwTbCartasCredito != null)
					{
						if (!dtrwTbCartasCredito.IsstrrNumeroNull())
							m_strNumeroCartaCredito = dtrwTbCartasCredito.strrNumero;
						else
							m_strNumeroCartaCredito = "";
						if (!dtrwTbCartasCredito.IsdtEmissaoNull())
							m_dtDataEmissao = dtrwTbCartasCredito.dtEmissao;
						else
							m_dtDataEmissao = System.DateTime.Now;
						if (!dtrwTbCartasCredito.IsdValorNull())
							m_dValor = dtrwTbCartasCredito.dValor;
						else
							m_dValor = 0;
						if (!dtrwTbCartasCredito.IsbEmendasNull())
							m_bEmendas = dtrwTbCartasCredito.bEmendas;
						else
							m_bEmendas = false;
						if (!dtrwTbCartasCredito.IsbDiscrepanciasNull())
							m_bDiscrepancias = dtrwTbCartasCredito.bDiscrepancias;
						else
							m_bDiscrepancias = false;
						if (!dtrwTbCartasCredito.IsnIdMoedaNull())
							m_nIdMoeda = dtrwTbCartasCredito.nIdMoeda;
						else
							m_nIdMoeda = 28;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosFC()
		{
			try
			{
				if (m_nIdMoeda == -1)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = null;
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwTbFaturasComerciais.IsidMoedaNull())
							m_nIdMoeda = dtrwTbFaturasComerciais.idMoeda;
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
		protected override void carregaDadosInterfaceGroupBox(ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "PE: " + m_strIdPE;
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
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if ((m_typDatSetTbPes != null) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					dtrwTbPes.nIdCartaCredito = m_nIdCartaCredito;
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
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
