using System;

namespace mdlDocumentacao
{
	/// <summary>
	/// Summary description for clsDocumentacaoBorderoSecundario.
	/// </summary>
	public class clsDocumentacaoBorderoSecundario
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected int m_nIdBancoExportadorBordero = -1;

		public bool m_bModificado = false;

		private string m_strConhecimentoEmbarqueIdentificacao = "";
		private int m_nConhecimentoEmbarqueCopias = 0;
		private string m_strFaturaComercialIdentificacao = "";
		private int m_nFaturaComercialCopias = 0;

		private Frames.frmFBordero m_formFBordero = null;

		// Tabelas Banco de Dados
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios m_typDatSetTbBorderosSecundarios = null;
		#endregion

		#region Construtores & Destrutores
		public clsDocumentacaoBorderoSecundario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string enderecoExecutavel, int idExportador, string strIdCodigo, int idBancoExportadorBordero)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdCodigo;
			m_nIdBancoExportadorBordero = idBancoExportadorBordero;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region InitializeEventsFormBordero
		private void InitializeEventsFormBordero()
		{
			// Carrega Dados Interface
			m_formFBordero.eCallCarregaDadosInterface += new Frames.frmFBordero.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFBordero.eCallSalvaDadosInterface += new Frames.frmFBordero.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFBordero.eCallSalvaDadosBD += new Frames.frmFBordero.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFBordero = new Frames.frmFBordero(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormBordero();
				m_formFBordero.ShowDialog();
				m_formFBordero = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
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

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlCondicaoCampo.Add("nIdBancoExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdBancoExportadorBordero);

				m_typDatSetTbBorderosSecundarios = m_cls_dba_ConnectionDB.GetTbBorderosSecundarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosBD()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = null;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwTbBorderosSecundarios = null;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					#region Fatura Comercial
					m_strFaturaComercialIdentificacao = (dtrwTbFaturasComerciais.IsnumeroFaturaNull() ? "" : dtrwTbFaturasComerciais.numeroFatura);
					#endregion
				}
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					#region Conhecimento Embarque
					m_strConhecimentoEmbarqueIdentificacao = (dtrwTbPes.IsstrIdConhecimentoEmbarqueNull() ? "" : dtrwTbPes.strIdConhecimentoEmbarque);
					#endregion
				}
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					#region Fatura Comercial
					m_nFaturaComercialCopias = (dtrwTbBorderosSecundarios.IsnQtdeDocCopiaFaturaComercialNull() ? 0 : dtrwTbBorderosSecundarios.nQtdeDocCopiaFaturaComercial);
					#endregion
					#region Conhecimento Embarque
					m_nConhecimentoEmbarqueCopias = (dtrwTbBorderosSecundarios.IsnQtdeDocCopialConhecimentoEmbarqueNull() ? 0 : dtrwTbBorderosSecundarios.nQtdeDocCopialConhecimentoEmbarque);
					#endregion
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
		private void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbFCIdentificacao, ref mdlComponentesGraficos.TextBox tbFCCopias, ref mdlComponentesGraficos.TextBox tbCEIdentificacao, ref mdlComponentesGraficos.TextBox tbCECopias)
		{
			try
			{
				tbFCIdentificacao.Text = m_strFaturaComercialIdentificacao;
				tbFCCopias.Text = m_nFaturaComercialCopias.ToString();
				tbCEIdentificacao.Text = m_strConhecimentoEmbarqueIdentificacao;
				tbCECopias.Text = m_nConhecimentoEmbarqueCopias.ToString();
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
		#region Interface
		private void salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbFCCopias, ref mdlComponentesGraficos.TextBox tbCECopias)
		{
			try
			{
				m_nFaturaComercialCopias = (tbFCCopias.Text.Trim() == "" ? 0 : Int32.Parse(tbFCCopias.Text));
				m_nConhecimentoEmbarqueCopias = (tbCECopias.Text.Trim() == "" ? 0 : Int32.Parse(tbCECopias.Text));
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow dtrwTbBorderosSecundarios = null;
				if (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0)
				{
					dtrwTbBorderosSecundarios = (mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios.tbBorderosSecundariosRow)m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows[0];
					#region Fatura Comercial
					dtrwTbBorderosSecundarios.nQtdeDocCopiaFaturaComercial = m_nFaturaComercialCopias;
					#endregion
					#region Conhecimento Embarque
					dtrwTbBorderosSecundarios.nQtdeDocCopialConhecimentoEmbarque = m_nConhecimentoEmbarqueCopias;
					#endregion
					m_cls_dba_ConnectionDB.SetTbBorderosSecundarios(m_typDatSetTbBorderosSecundarios);
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

		#region Retorna Valores
		public void retornaValores(out string strIdentificacaoFC, out int nCopiasFC, out string strIdentificaoCE, out int nCopiasCE)
		{
			strIdentificacaoFC = m_strFaturaComercialIdentificacao;
			nCopiasFC = m_nFaturaComercialCopias;
			strIdentificaoCE = m_strConhecimentoEmbarqueIdentificacao;
			nCopiasCE = m_nConhecimentoEmbarqueCopias;
		}
		#endregion
	}
}
