using System;

namespace mdlProdutosVinculacao
{
	/// <summary>
	/// Summary description for clsClassificacaoTarifaria.
	/// </summary>
	public class clsClassificacaoTarifaria
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private string m_strSugestao = "";
		private string m_strClassificacao = "";

		public bool m_bModificado = false;

		protected const int MERCOSUL = 1;
		protected const int MERCOSULBOLIVIA = 2;
		protected const int MERCOSULCHILE = 3;
		protected const int ALADIAPTR04 = 4;
		protected const int ALADIACE39 = 5;
		protected const int ANEXO3 = 6;
		protected const int COMUM = 7;
		protected const int FORMA = 8;

		protected const int NCM = 1;
		protected const int NALADI = 2;

		private Frames.frmFClassificacaoTarifaria m_formFClassificacaoTarifaria = null;

		private System.Collections.ArrayList m_arlClassificacoesNCM = null;
		private System.Collections.ArrayList m_arlClassificacoesNALADI = null;

		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = null;
		#endregion

		#region Construtores & Destrutores
		public clsClassificacaoTarifaria(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string idPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = Exportador;
			m_strIdPE = idPE;
			m_arlClassificacoesNCM = new System.Collections.ArrayList();
			m_arlClassificacoesNALADI = new System.Collections.ArrayList();
			carregaTypDatSet();
			carregaDadosBD();
			carregaTextosBD();
		}
		#endregion

		#region InitializeEventsFormClassificacaoTarifaria
		private void InitializeEventsFormClassificacaoTarifaria()
		{
			// Carrega Dados Interface
			m_formFClassificacaoTarifaria.eCallCarregaDadosInterface += new Frames.frmFClassificacaoTarifaria.delCallCarregaDadosInterface(carregaDadosInterface);

			// Copia sugestao
			m_formFClassificacaoTarifaria.eCallCopiaSugestao += new Frames.frmFClassificacaoTarifaria.delCallCopiaSugestao(aplicarSugestao);

			// Salva Dados Interface
			m_formFClassificacaoTarifaria.eCallSalvaDadosInterface += new Frames.frmFClassificacaoTarifaria.delCallSalvaDadosInterface(salvaDadosInterface);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFClassificacaoTarifaria = new Frames.frmFClassificacaoTarifaria(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormClassificacaoTarifaria();
				m_formFClassificacaoTarifaria.ShowDialog();
				m_bModificado = m_formFClassificacaoTarifaria.m_bModificado;
				m_formFClassificacaoTarifaria = null;
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

				m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(null,null,null,null,null);

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwTbProdutosFaturaComercial = null;
				foreach (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwTbProdutosCertificadoOrigem in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
				{
					dtrwTbProdutos = null;
					dtrwTbProdutosFaturaComercial = null;
					dtrwTbProdutosFaturaComercial = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador, m_strIdPE, dtrwTbProdutosCertificadoOrigem.idOrdemProduto);
					if ((dtrwTbProdutosFaturaComercial != null) && (!dtrwTbProdutosFaturaComercial.IsidProdutoNull()))
					{
						dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador, dtrwTbProdutosFaturaComercial.idProduto);
						if (dtrwTbProdutos != null)
						{
							switch (dtrwTbProdutosCertificadoOrigem.idTipoCO)
							{
								case MERCOSUL:
								case COMUM:
									if (!dtrwTbProdutos.IsstrNcmNull())
									{
										if (!m_arlClassificacoesNCM.Contains(dtrwTbProdutos.strNcm))
											m_arlClassificacoesNCM.Add(dtrwTbProdutos.strNcm);
									}
									break;
								case MERCOSULBOLIVIA:
								case MERCOSULCHILE:
								case ALADIACE39:
								case ANEXO3:
								case ALADIAPTR04:
								case FORMA:
									if (!dtrwTbProdutos.IsstrNaladiNull())
									{
										if (!m_arlClassificacoesNALADI.Contains(dtrwTbProdutos.strNaladi))
											m_arlClassificacoesNALADI.Add(dtrwTbProdutos.strNaladi);
									}
									break;
							}
						}
					}
					dtrwTbProdutos = null;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTextosBD()
		{
			try
			{
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					m_strClassificacao = (dtrwTbInstrucoesEmbarque.IsmstrCodigoTarifarioNull() ? "" : dtrwTbInstrucoesEmbarque.mstrCodigoTarifario);
				}
				m_strSugestao = strRetornaSugestao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		private void carregaDadosInterface(ref System.Windows.Forms.TextBox tbSugestao, ref System.Windows.Forms.TextBox tbClassificacao)
		{
			try
			{
				tbSugestao.Text = m_strSugestao;
				tbClassificacao.Text = m_strClassificacao;
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
		private void aplicarSugestao(ref System.Windows.Forms.TextBox tbClassificacao)
		{
			try
			{
				tbClassificacao.Text = m_strSugestao;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosInterface(ref System.Windows.Forms.TextBox tbClassificacao)
		{
			try
			{
				m_strClassificacao = tbClassificacao.Text;
				salvaDadosBD();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD()
		{
			try
			{
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					dtrwTbInstrucoesEmbarque.mstrCodigoTarifario = m_strClassificacao;
					m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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
		public void retornaValores(out string strClassificacaoTarifaria)
		{
			strClassificacaoTarifaria = m_strClassificacao;
		}
		private string strRetornaSugestao()
		{
			m_strSugestao = "";
			for (int nCount = 0; nCount < m_arlClassificacoesNCM.Count; nCount++)
			{
				if (nCount == 0)
				{
					m_strSugestao += "NCM: " + m_arlClassificacoesNCM[nCount].ToString();
					if (m_arlClassificacoesNCM.Count > 1)
						m_strSugestao += ", ";
					else if (m_arlClassificacoesNALADI.Count > 0)
						m_strSugestao += "; ";
				}
				else if (nCount == (m_arlClassificacoesNCM.Count - 1))
				{
					m_strSugestao += m_arlClassificacoesNCM[nCount].ToString();
					if (m_arlClassificacoesNALADI.Count > 0)
						m_strSugestao += "; ";
				}
				else
				{
					m_strSugestao += m_arlClassificacoesNCM[nCount].ToString() + ", ";
				}
			}
			for (int nCount = 0; nCount < m_arlClassificacoesNALADI.Count; nCount++)
			{
				if (nCount == 0)
				{
					m_strSugestao += "NALADI: " + m_arlClassificacoesNALADI[nCount].ToString();
					if (m_arlClassificacoesNALADI.Count > 1)
						m_strSugestao += ", ";
				}
				else if (nCount == (m_arlClassificacoesNALADI.Count - 1))
				{
					m_strSugestao += m_arlClassificacoesNALADI[nCount].ToString();
				}
				else
				{
					m_strSugestao += m_arlClassificacoesNALADI[nCount].ToString() + ", ";
				}
			}
			return m_strSugestao;
		}
		#endregion
	}
}