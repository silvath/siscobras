using System;

namespace mdlCriacaoDocumentos.Bordero
{
	/// <summary>
	/// Summary description for clsCriacaoBordero.
	/// </summary>
	public class clsCriacaoBordero
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dbaConnnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_terTratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		private string m_strLinkInternet = "";

		public bool m_bModificado = false;

		private bool m_bNumeroPreenchido = false;
		private bool m_bBancoExportadorPreenchido = false;
		private bool m_bBancoImportadorPreenchido = false;
		private bool m_bDocumentacaoPreenchido = false;
		private bool m_bDataEmbarquePreenchido = false;
		private bool m_bDescricaoMercadoriasPreenchido = false;
		private bool m_bPagamentoPreenchido = false;
		private bool m_bContratoCambioPreenchido = false;
		private bool m_bCobrancaPreenchido = false;

		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private Frames.frmFAssistenteBordero m_formFAssistenteBordero = null;

		protected System.Windows.Forms.ImageList m_ilBandeiras = null;

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero m_typDatSetTbProdutosBordero = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadosOrigem = null;
		#endregion

		#region Construtores & Destrutores
		public clsCriacaoBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			m_cls_terTratadorErro = tratadorErro;
			m_cls_dbaConnnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
			m_ilBandeiras = ilBandeiras;
			carregaTypDatSet();
			verificaCamposPreenchidos();
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

				m_typDatSetTbPes = m_cls_dbaConnnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbSaques = m_cls_dbaConnnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbBorderos = m_cls_dbaConnnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbRomaneios = m_cls_dbaConnnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				m_typDatSetTbInstrucoesEmbarque = m_cls_dbaConnnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				m_typDatSetTbCertificadosOrigem = m_cls_dbaConnnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosCertificadosOrigem = m_cls_dbaConnnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoCampo.Add("strIdPE");
				m_typDatSetTbProdutosBordero = m_cls_dbaConnnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		private void verificaCamposPreenchidos()
		{
			try
			{
				#region Banco Exportador
				string strBanco, strAgencia, strConta;
				mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				obj.retornaValores(out strBanco, out strAgencia, out strConta);
				if (strBanco.Trim() != "" && strAgencia.Trim() != "" && strConta.Trim() != "")
				{
					m_bBancoExportadorPreenchido = true;
				}
				#endregion
				#region Banco Importador
				mdlBancos.clsBancoImportador objBI = new mdlBancos.BancoImportador.clsBancoImportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				objBI.retornaValores(out strBanco);
				if (strBanco.Trim() != "")
				{
					m_bBancoImportadorPreenchido = true;
				}
				#endregion
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
				}
				if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					#region Número
					if (!dtrwTbBorderos.IsstrNumeroNull())
						m_bNumeroPreenchido = true;
					#endregion
					#region Esquema Pagamento
					if (!dtrwTbBorderos.IsmstrEsquemaPagamentoNull())
						m_bPagamentoPreenchido = true;
					#endregion
					#region Documentação
					bool bFC = true, bSG = true, bCE = true, bCO = true, bRM = true, bCP = true, bCA = true, bSQ = true, bFS = true;
					#region Fatura Comercial
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						if (dtrwTbBorderos.IsnQtdeDocCopiaFaturaComercialNull())
							bFC = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalFaturaComercialNull())
							bFC = false;
					}
					#endregion
					#region Certificado Origem
					if (m_typDatSetTbProdutosCertificadosOrigem.tbProdutosCertificadoOrigem.Rows.Count > 0)
					{
						if (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoOrigemNull())
							bCO = false;
						if (dtrwTbBorderos.IsnQtdeDocCopialCertificadoOrigemNull())
							bCO = false;
					}
					#endregion
					#region Romaneio
					if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
					{
						if (dtrwTbBorderos.IsnQtdeDocCopialRomaneioNull())
							bRM = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalRomaneioNull())
							bRM = false;
					}
					#endregion
					#region Saque
					if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
					{
						if (dtrwTbBorderos.IsnQtdeDocCopialSaqueNull())
							bSQ = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalSaqueNull())
							bSQ = false;
					}
					#endregion
					#region PE
					if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
						#region Conhecimento Embarque
						if (dtrwTbPes.IsstrIdConhecimentoEmbarqueNull())
							bCE = false;
						if (dtrwTbBorderos.IsnQtdeDocCopialConhecimentoEmbarqueNull())
							bCE = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalConhecimentoEmbarqueNull())
							bCE = false;
						#endregion
						#region Certificado Peso
						if (dtrwTbPes.IsstrIdCertificadoPesoNull())
							bCP = false;
						if (dtrwTbBorderos.IsnQtdeDocCopialCertificadoPesoNull())
							bCP = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoPesoNull())
							bCP = false;
						#endregion
						#region Certificado Análise
						if (dtrwTbPes.IsstrIdCertificadoAnaliseNull())
							bCA = false;
						if (dtrwTbBorderos.IsnQtdeDocCopialCertificadoAnaliseNull())
							bCA = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoAnaliseNull())
							bCA = false;
						#endregion
						#region Fito Sanitário
						if (dtrwTbPes.IsstrIdFitossanitarioNull())
							bFS = false;
						if (dtrwTbBorderos.IsnQtdeDocCopialFitoSanitarioNull())
							bFS = false;
						if (dtrwTbBorderos.IsnQtdeDocOriginalFitoSanitarioNull())
							bFS = false;
						#endregion
					}
					#endregion
					m_bDocumentacaoPreenchido = (bFC && bSG && bCE && bCO && bRM && bCP && bCA && bSQ && bFS);
					#endregion
					#region Número
					if (!dtrwTbBorderos.IsnEntregaDocumentosNull())
						m_bCobrancaPreenchido = true;
					#endregion
				}
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					#region Data Embarque
					if (!dtrwTbFaturasComerciais.IsdataEmbarqueNull())
						m_bDataEmbarquePreenchido = true;
					#endregion
				}
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					#region Descrição Mercadorias
					if (!dtrwTbInstrucoesEmbarque.IsmstrDescricaoGeralMercadoriasNull())
						m_bDescricaoMercadoriasPreenchido = true;
					#endregion
				}
				#region Contrato Cambio
				if (m_typDatSetTbProdutosBordero.tbProdutosBordero.Rows.Count > 0)
				{
					m_bContratoCambioPreenchido = true;
				}
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region InitializeEventsFormAssistenteBordero
		private void InitializeEventsFormAssistenteBordero()
		{
			// Número Borderô
			m_formFAssistenteBordero.eCallSelecionaNumero += new Frames.frmFAssistenteBordero.delCallSelecionaNumero(selecionaNumeroBordero);

			// Banco Exportador
			m_formFAssistenteBordero.eCallSelecionaBancoExportador += new Frames.frmFAssistenteBordero.delCallSelecionaBancoExportador(selecionaBancoExportador);

			// Banco Importador
			m_formFAssistenteBordero.eCallSelecionaBancoImportador += new Frames.frmFAssistenteBordero.delCallSelecionaBancoImportador(selecionaBancoImportador);

			// Documentação
			m_formFAssistenteBordero.eCallSelecionaDocumentos += new Frames.frmFAssistenteBordero.delCallSelecionaDocumentos(selecionaDocumentacao);

			// Data Embarque
			m_formFAssistenteBordero.eCallSelecionaDataEmbarque += new Frames.frmFAssistenteBordero.delCallSelecionaDataEmbarque(selecionaDataEmbarque);

			// Descrição Mercadorias
			m_formFAssistenteBordero.eCallSelecionaDescricaoMercadorias += new Frames.frmFAssistenteBordero.delCallSelecionaDescricaoMercadorias(selecionaDescricaoMercadorias);

			// Pagamento
			m_formFAssistenteBordero.eCallSelecionaPagamento += new Frames.frmFAssistenteBordero.delCallSelecionaPagamento(selecionaPagamento);

			// Contrato Cambio
			m_formFAssistenteBordero.eCallSelecionaContratoCambio += new Frames.frmFAssistenteBordero.delCallSelecionaContratoCambio(selecionaContratoCambio);

			// Cobrança
			m_formFAssistenteBordero.eCallSelecionaCobranca += new Frames.frmFAssistenteBordero.delCallSelecionaCobranca(selecionaCobranca);

			// Banner
			m_formFAssistenteBordero.eCallAlteraBanner += new Frames.frmFAssistenteBordero.delCallAlteraBanner(alteraBanner);

			// Click Banner
			m_formFAssistenteBordero.eCallClickBanner += new Frames.frmFAssistenteBordero.delCallClickBanner(clickBanner);
		}
		#endregion

		#region Modulos Assistentes
		#region Número do Borderô
		private void selecionaNumeroBordero(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero)
		{
			mdlNumero.clsNumero obj = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkNumero.Visible = true;
				pbNOKNumero.Visible = false;
				m_bNumeroPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Banco do Exportador
		private void selecionaBancoExportador(ref System.Windows.Forms.PictureBox pbOkBancoExportador, ref System.Windows.Forms.PictureBox pbNOKBancoExportador)
		{
			mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkBancoExportador.Visible = true;
				pbNOKBancoExportador.Visible = false;
				m_bBancoExportadorPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Banco do Importador
		private void selecionaBancoImportador(ref System.Windows.Forms.PictureBox pbOkBancoImportador, ref System.Windows.Forms.PictureBox pbNOKBancoImportador)
		{
			mdlBancos.clsBancoImportador obj = new mdlBancos.BancoImportador.clsBancoImportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkBancoImportador.Visible = true;
				pbNOKBancoImportador.Visible = false;
				m_bBancoImportadorPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Documentação
		private void selecionaDocumentacao(ref System.Windows.Forms.PictureBox pbOkDocumentos, ref System.Windows.Forms.PictureBox pbNOKDocumentos)
		{
			mdlDocumentacao.clsDocumentacao obj = new mdlDocumentacao.clsDocumentacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkDocumentos.Visible = true;
				pbNOKDocumentos.Visible = false;
				m_bDocumentacaoPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Data Embarque
		private void selecionaDataEmbarque(ref System.Windows.Forms.PictureBox pbOkDataEmbarque, ref System.Windows.Forms.PictureBox pbNOKDataEmbarque)
		{
			mdlData.clsData obj = new mdlData.DataEmbarque.Faturas.clsDataEmbarqueComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkDataEmbarque.Visible = true;
				pbNOKDataEmbarque.Visible = false;
				m_bDataEmbarquePreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Descrição Mercadorias
		private void selecionaDescricaoMercadorias(ref System.Windows.Forms.PictureBox pbOkDescricaoMercadorias, ref System.Windows.Forms.PictureBox pbNOKDescricaoMercadorias)
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueDescricaoGeralMercadoria(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkDescricaoMercadorias.Visible = true;
				pbNOKDescricaoMercadorias.Visible = false;
				m_bDescricaoMercadoriasPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Pagamento
		private void selecionaPagamento(ref System.Windows.Forms.PictureBox pbOkPagamento, ref System.Windows.Forms.PictureBox pbNOKPagamento)
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Bordero.clsBorderoModalidadePagamento(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkPagamento.Visible = true;
				pbNOKPagamento.Visible = false;
				m_bPagamentoPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region ContratoCambio
		private void selecionaContratoCambio(ref System.Windows.Forms.PictureBox pbOkContratoCambio, ref System.Windows.Forms.PictureBox pbNOKContratoCambio)
		{
			mdlProdutosBordero.clsProdutosBordero obj = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkContratoCambio.Visible = true;
				pbNOKContratoCambio.Visible = false;
				m_bContratoCambioPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Cobrança
		private void selecionaCobranca(ref System.Windows.Forms.PictureBox pbOkCobranca, ref System.Windows.Forms.PictureBox pbNOKCobranca)
		{
			mdlBorderoCobranca.clsBorderoCobranca obj = new mdlBorderoCobranca.clsBorderoCobranca(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkCobranca.Visible = true;
				pbNOKCobranca.Visible = false;
				m_bCobrancaPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#endregion

		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.ASSISTENTE);
				m_strLinkInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				if (m_formFAssistenteBordero != null)
					m_formFAssistenteBordero.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ClickBanner
		protected void clickBanner()
		{
			try
			{
				if (m_strLinkInternet != "")
					System.Diagnostics.Process.Start(m_strLinkInternet);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFAssistenteBordero = new Frames.frmFAssistenteBordero(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormAssistenteBordero();
				m_formFAssistenteBordero.setaEstadoAssistente(m_bNumeroPreenchido, m_bBancoExportadorPreenchido, m_bBancoImportadorPreenchido, m_bDocumentacaoPreenchido, m_bDataEmbarquePreenchido, m_bDescricaoMercadoriasPreenchido, m_bPagamentoPreenchido, m_bContratoCambioPreenchido, m_bCobrancaPreenchido);
				m_formFAssistenteBordero.ShowDialog();
				m_bModificado = m_formFAssistenteBordero.m_bModificado;
				m_formFAssistenteBordero = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		public void ShowDialogPrincipal()
		{
			try
			{
				m_formFAssistenteBordero = new Frames.frmFAssistenteBordero(ref m_cls_terTratadorErro, m_strEnderecoExecutavel, false, false);
				InitializeEventsFormAssistenteBordero();
				m_formFAssistenteBordero.setaEstadoAssistente(m_bNumeroPreenchido, m_bBancoExportadorPreenchido, m_bBancoImportadorPreenchido, m_bDocumentacaoPreenchido, m_bDataEmbarquePreenchido, m_bDescricaoMercadoriasPreenchido, m_bPagamentoPreenchido, m_bContratoCambioPreenchido, m_bCobrancaPreenchido);
				m_formFAssistenteBordero.ShowDialog();
				m_bModificado = m_formFAssistenteBordero.m_bModificado;
				m_formFAssistenteBordero = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
