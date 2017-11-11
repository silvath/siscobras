using System;

namespace mdlDocumentacao
{
	/// <summary>
	/// Summary description for clsDocumentacaoSumario.
	/// </summary>
	public class clsDocumentacaoSumario
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";

		public bool m_bModificado = false;

		#region Seguro
		private bool m_bIncotermSeguro = false;
		private string m_strIdentificacaoSeguro = "";
		private System.DateTime m_dtEmissaoSeguro = System.DateTime.Now;
		#endregion
		#region Fitossanitário
		private string m_strIdentificacaoFito = "";
		private System.DateTime m_dtEmissaoFito = System.DateTime.Now;
		#endregion
		#region Peso
		private string m_strIdentificacaoPeso = "";
		private System.DateTime m_dtEmissaoPeso = System.DateTime.Now;
		#endregion
		#region Análise
		private string m_strIdentificacaoAnalise = "";
		private System.DateTime m_dtEmissaoAnalise = System.DateTime.Now;
		#endregion

		private Frames.frmFSumario m_formFSumario = null;

		// Tabelas Banco de Dados
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		#endregion

		#region Construtores & Destrutores
		public clsDocumentacaoSumario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string enderecoExecutavel, int idExportador, string strIdCodigo)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdCodigo;
			carregaTypDatSet();
			carregaDadosIncoterm();
			carregaDadosBD();
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
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosIncoterm()
		{
			try
			{
				double dSeguro, dNull;
				bool bNull;
				string strNull;
				int nIdIncoterm;
				mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				obj.retornaIdIncoterm(out nIdIncoterm);
				obj.retornaValores(out strNull, out dNull, out dNull, out bNull, out dNull, out dNull, out dNull, out dSeguro, out strNull, out dNull, out dNull, out bNull, out strNull);
				switch((mdlIncoterm.INCOTERMS)nIdIncoterm)
				{
					case mdlIncoterm.INCOTERMS.EXW:
					case mdlIncoterm.INCOTERMS.FOB:
					case mdlIncoterm.INCOTERMS.FCA:
					case mdlIncoterm.INCOTERMS.FAS:
					case mdlIncoterm.INCOTERMS.CFR:
					case mdlIncoterm.INCOTERMS.CPT:
													m_bIncotermSeguro = false;
													break;
					case mdlIncoterm.INCOTERMS.CIF:
					case mdlIncoterm.INCOTERMS.CIP:
					case mdlIncoterm.INCOTERMS.DAF:
					case mdlIncoterm.INCOTERMS.DEQ:
					case mdlIncoterm.INCOTERMS.DES:
					case mdlIncoterm.INCOTERMS.DDU:
					case mdlIncoterm.INCOTERMS.DDP:
													m_bIncotermSeguro = true;
													break;
					default:
						m_bIncotermSeguro = false;
						break;
				}
				if (m_bIncotermSeguro)
				{
					if (dSeguro == 0)
						m_bIncotermSeguro = false;
				}
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
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					#region Seguro
					m_strIdentificacaoSeguro = (dtrwTbPes.IsstrIdSeguroNull() ? "" : dtrwTbPes.strIdSeguro);
					m_dtEmissaoSeguro = (dtrwTbPes.IsdtEmissaoSeguroNull() ? System.DateTime.Now : dtrwTbPes.dtEmissaoSeguro);
					#endregion
					#region Fitossanitario
					m_strIdentificacaoFito = (dtrwTbPes.IsstrIdFitossanitarioNull() ? "" : dtrwTbPes.strIdFitossanitario);
					m_dtEmissaoFito = (dtrwTbPes.IsdtEmissaoFitoSanitarioNull() ? System.DateTime.Now : dtrwTbPes.dtEmissaoFitoSanitario);
					#endregion
					#region Peso
					m_strIdentificacaoPeso = (dtrwTbPes.IsstrIdCertificadoPesoNull() ? "" : dtrwTbPes.strIdCertificadoPeso);
					m_dtEmissaoPeso = (dtrwTbPes.IsdtEmissaoCertificadoPesoNull() ? System.DateTime.Now : dtrwTbPes.dtEmissaoCertificadoPeso);
					#endregion
					#region Analise
					m_strIdentificacaoAnalise = (dtrwTbPes.IsstrIdCertificadoAnaliseNull() ? "" : dtrwTbPes.strIdCertificadoAnalise);
					m_dtEmissaoAnalise = (dtrwTbPes.IsdtEmissaoCertificadoAnaliseNull() ? System.DateTime.Now : dtrwTbPes.dtEmissaoCertificadoAnalise);
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
		private void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbSeguro, ref System.Windows.Forms.DateTimePicker dtpkSeguro, ref mdlComponentesGraficos.TextBox tbFito, ref System.Windows.Forms.DateTimePicker dtpkFito, ref mdlComponentesGraficos.TextBox tbPeso, ref System.Windows.Forms.DateTimePicker dtpkPeso, ref mdlComponentesGraficos.TextBox tbAnalise, ref System.Windows.Forms.DateTimePicker dtpkAnalise)
		{
			try
			{
				#region Seguro
				if (m_bIncotermSeguro)
				{
					tbSeguro.Enabled = true;
					dtpkSeguro.Enabled = true;
					tbSeguro.Text = m_strIdentificacaoSeguro;
					dtpkSeguro.Value = m_dtEmissaoSeguro;
				}
				else
				{
					tbSeguro.Enabled = false;
					dtpkSeguro.Enabled = false;
					tbSeguro.Text = "";
					dtpkSeguro.Value = System.DateTime.Now;
				}
				#endregion
				#region Fito
				tbFito.Text = m_strIdentificacaoFito;
				dtpkFito.Value = m_dtEmissaoFito;
				#endregion
				#region Peso
				tbPeso.Text = m_strIdentificacaoPeso;
				dtpkPeso.Value = m_dtEmissaoPeso;
				#endregion
				#region Analise
				tbAnalise.Text = m_strIdentificacaoAnalise;
				dtpkAnalise.Value = m_dtEmissaoAnalise;
				#endregion
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
		private void salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbSeguro, ref System.Windows.Forms.DateTimePicker dtpkSeguro, ref mdlComponentesGraficos.TextBox tbFito, ref System.Windows.Forms.DateTimePicker dtpkFito, ref mdlComponentesGraficos.TextBox tbPeso, ref System.Windows.Forms.DateTimePicker dtpkPeso, ref mdlComponentesGraficos.TextBox tbAnalise, ref System.Windows.Forms.DateTimePicker dtpkAnalise)
		{
			try
			{
				#region Seguro
				if (m_bIncotermSeguro)
				{
					m_strIdentificacaoSeguro = tbSeguro.Text;
					m_dtEmissaoSeguro = dtpkSeguro.Value;
				}
				else
				{
					m_strIdentificacaoSeguro = "";
					m_dtEmissaoSeguro = System.DateTime.Now;
				}
				#endregion
				#region Fito
				m_strIdentificacaoFito = tbFito.Text;
				m_dtEmissaoFito = dtpkFito.Value;
				#endregion
				#region Peso
				m_strIdentificacaoPeso = tbPeso.Text;
				m_dtEmissaoPeso = dtpkPeso.Value;
				#endregion
				#region Analise
				m_strIdentificacaoAnalise = tbAnalise.Text;
				m_dtEmissaoAnalise = dtpkAnalise.Value;
				#endregion
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
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = null;
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					#region Seguro
					if (m_bIncotermSeguro)
					{
						dtrwTbPes.strIdSeguro = m_strIdentificacaoSeguro;
						dtrwTbPes.dtEmissaoSeguro = m_dtEmissaoSeguro;
					}
					else
					{
						dtrwTbPes.SetstrIdSeguroNull();
						dtrwTbPes.SetdtEmissaoSeguroNull();
					}
					#endregion
					#region Fitossanitario
					dtrwTbPes.strIdFitossanitario = m_strIdentificacaoFito;
					dtrwTbPes.dtEmissaoFitoSanitario = m_dtEmissaoFito;
					#endregion
					#region Peso
					dtrwTbPes.strIdCertificadoPeso = m_strIdentificacaoPeso;
					dtrwTbPes.dtEmissaoCertificadoPeso = m_dtEmissaoPeso;
					#endregion
					#region Analise
					dtrwTbPes.strIdCertificadoAnalise = m_strIdentificacaoAnalise;
					dtrwTbPes.dtEmissaoCertificadoAnalise = m_dtEmissaoAnalise;
					#endregion
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
		#endregion

		#region InitializeEventsFormSumario
		private void InitializeEventsFormSumario()
		{
			// Carrega Dados Interface
			m_formFSumario.eCallCarregaDadosInterface += new Frames.frmFSumario.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFSumario.eCallSalvaDadosInterface += new Frames.frmFSumario.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFSumario.eCallSalvaDadosBD += new Frames.frmFSumario.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFSumario = new Frames.frmFSumario(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormSumario();
				m_formFSumario.ShowDialog();
				m_formFSumario = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region RetornaValores
		public void retornaValores(out string strIdentificacaoSeguro, out string strEmissaoSeguro, out string strIdentificaoFito, out string strEmissaoFito, out string strIdentificaoPeso, out string strEmissaoPeso, out string strIdentificaoAnalise, out string strEmissaoAnalise)
		{
			strIdentificacaoSeguro = (m_bIncotermSeguro ? m_strIdentificacaoSeguro : "");
			strEmissaoSeguro = (m_bIncotermSeguro ? m_dtEmissaoSeguro.ToString("dd/MM/yyyy") : "");
			strIdentificaoFito = m_strIdentificacaoFito;
			strEmissaoFito = (m_strIdentificacaoFito.Trim() == "" ? "" : m_dtEmissaoFito.ToString("dd/MM/yyyy"));
			strIdentificaoPeso = m_strIdentificacaoPeso;
			strEmissaoPeso = (m_strIdentificacaoPeso.Trim() == "" ? "" : m_dtEmissaoPeso.ToString("dd/MM/yyyy"));
			strIdentificaoAnalise = m_strIdentificacaoAnalise;
			strEmissaoAnalise = (m_strIdentificacaoAnalise.Trim() == "" ? "" : m_dtEmissaoAnalise.ToString("dd/MM/yyyy"));
		}
		#endregion
	}
}
