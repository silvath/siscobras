using System;

namespace mdlCriacaoDocumentos.Faturas
{
	/// <summary>
	/// Summary description for clsCriacaoProcesso.
	/// </summary>
	public class clsCriacaoProcesso : clsCriacao
	{
		#region Atributos
		private string m_strIdPE = "";
		private Frames.frmFNumeroPE m_formFNumeroPE = null;

		private mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes;
		private mdlDataBaseAccess.Tabelas.XsdTbRelatorios.tbRelatoriosRow dtrwTbRelatorios;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwTbFaturasCotacoes;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwTbFaturasProformasNew;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciaisNew;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwTbProdutosFaturaCotacao;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwTbProdutosFaturaProformaNew;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwTbProdutosFaturaComercial;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwTbProdutosFaturaComercialNew;

		private System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
		private System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
		private System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
		#endregion
		#region Construtors and Destrutors
		public clsCriacaoProcesso(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, ref System.Windows.Forms.ImageList ilBandeiras) : base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador, ref ilBandeiras)
		{
			sugereNumeroPE();
		}
		public clsCriacaoProcesso(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string idPE, ref System.Windows.Forms.ImageList ilBandeiras) : base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador, ref ilBandeiras)
		{
			m_strIdPE = idPE;
		}
		#endregion

		#region InitializeEventsFormAssistentePrincipal
		private void InitializeEventsFormAssistentePrincipal()
		{
			// Interface
			m_formFAssistentePrincipal.eCallCarregaDadosInterface += new Frames.frmFAssistentePrincipal.delCallCarregaDadosInterface(carregaDadosInterfaceAssistentePrincipal);

			// clique Numero da Fatura
			m_formFAssistentePrincipal.eCallSelecionaNumeroFaturaComercial += new Frames.frmFAssistentePrincipal.delCallSelecionaNumeroFaturaComercial(selecionaNumeroFatura);

			// clique Idioma
			m_formFAssistentePrincipal.eCallSelecionaIdioma += new Frames.frmFAssistentePrincipal.delCallSelecionaIdioma(selecionaIdioma);

			// clique Moeda
			m_formFAssistentePrincipal.eCallSelecionaMoeda += new Frames.frmFAssistentePrincipal.delCallSelecionaMoeda(selecionaMoeda);
			
			// Clique Importador
			m_formFAssistentePrincipal.eCallSelecionaImportador += new Frames.frmFAssistentePrincipal.delCallSelecionaImportador(selecionaImportador);
            
			// Clique Produtos
			m_formFAssistentePrincipal.eCallSelecionaProdutos += new Frames.frmFAssistentePrincipal.delCallSelecionaProdutos(selecionaProdutos);

			// Clique Pesos
			m_formFAssistentePrincipal.eCallSelecionaPesos += new Frames.frmFAssistentePrincipal.delCallSelecionaPesos(selecionaPesos);

			// Clique NumeroOrdemcompra
			m_formFAssistentePrincipal.eCallSelecionaNumeroOrdemCompra += new Frames.frmFAssistentePrincipal.delCallSelecionaNumeroOrdemCompra(selecionaNumeroOrdemCompra);

			// Clique Incoterm
			m_formFAssistentePrincipal.eCallSelecionaIncoterm += new Frames.frmFAssistentePrincipal.delCallSelecionaIncoterm(selecionaIncoterm);

			// Clique Locais
			m_formFAssistentePrincipal.eCallSelecionaLocais += new Frames.frmFAssistentePrincipal.delCallSelecionaLocais(selecionaLocais);

			// Clique CondicoesPagamento
			m_formFAssistentePrincipal.eCallSelecionaCondicoesPagamento += new Frames.frmFAssistentePrincipal.delCallSelecionaCondicoesPagamento(selecionaCondicoesPagamento);

			// Clique BancoImportador
			m_formFAssistentePrincipal.eCallSelecionaBancoImportador += new Frames.frmFAssistentePrincipal.delCallSelecionaBancoImportador(selecionaBancoImportador);
			
			// Clique BancoExportador
			m_formFAssistentePrincipal.eCallSelecionaBancoExportador += new Frames.frmFAssistentePrincipal.delCallSelecionaBancoExportador(selecionaBancoExportador);

			// Clique Observacoes
			m_formFAssistentePrincipal.eCallSelecionaObservacoes += new Frames.frmFAssistentePrincipal.delCallSelecionaObservacoes(selecionaObservacoes);

			// Clique Assinatura
			m_formFAssistentePrincipal.eCallSelecionaAssinatura += new Frames.frmFAssistentePrincipal.delCallSelecionaAssinatura(selecionaAssinatura);

			// Altera Banner
			m_formFAssistentePrincipal.eCallAlteraBanner += new Frames.frmFAssistentePrincipal.delCallAlteraBanner(alteraBanner);

			// Click Banner
			m_formFAssistentePrincipal.eCallClickBanner += new Frames.frmFAssistentePrincipal.delCallClickBanner(clickBanner);
		}
		#endregion

		#region Modulos Assistentes
		#region Número da Fatura
		private void selecionaNumeroFatura(ref System.Windows.Forms.PictureBox pbOkNumeroFatura, ref System.Windows.Forms.PictureBox pbNOKNumeroFatura)
		{
			m_clsNumero = new mdlNumero.Faturas.clsNumeroComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			m_clsNumero.ShowDialog();
			if (m_clsNumero.m_bModificado)
			{
				//m_clsNumero.retornaValores(out m_strIdCodigo);
				pbOkNumeroFatura.Visible = true;
				pbNOKNumeroFatura.Visible = false;
				m_clsNumero = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Idioma
		private void selecionaIdioma(ref System.Windows.Forms.PictureBox pbOkIdioma, ref System.Windows.Forms.PictureBox pbNOKIdioma)
		{
			try
			{
				mdlIdioma.clsIdioma clsIdioma = new mdlIdioma.clsIdiomaFaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_ilBandeiras);
				clsIdioma.ShowDialog();
				if (clsIdioma.m_bModificado == false)
				{
					return;
				}
				else
				{
					pbOkIdioma.Visible = true;
					pbNOKIdioma.Visible = false;
				}
				clsIdioma = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Moeda
		private void selecionaMoeda(ref System.Windows.Forms.PictureBox pbOkMoeda, ref System.Windows.Forms.PictureBox pbNOKMoeda)
		{
			mdlMoeda.clsMoeda clsMoeda = new mdlMoeda.clsMoedaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsMoeda.ShowDialog();
			if (clsMoeda.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkMoeda.Visible = true;
				pbNOKMoeda.Visible = false;
			}
			clsMoeda = null;
		}
		#endregion
		#region Importador
		private void selecionaImportador(ref System.Windows.Forms.PictureBox pbOkImportador, ref System.Windows.Forms.PictureBox pbNOKImportador)
		{
			mdlImportador.clsImportador clsImportador = new mdlImportador.clsImportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_ilBandeiras);
			clsImportador.ShowDialog();
			if (clsImportador.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkImportador.Visible = true;
				pbNOKImportador.Visible = false;
			}
			clsImportador = null;
		}
		#endregion
		#region Produtos
		private void selecionaProdutos(ref System.Windows.Forms.PictureBox pbOkProdutos, ref System.Windows.Forms.PictureBox pbNOKProdutos)
		{
			mdlProdutosLancamento.clsLancamentoProdutos clsLancamentoProdutos = new mdlProdutosLancamento.clsLancamentoProdutosFaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, ref m_ilBandeiras, m_nIdExportador, m_strIdPE);
			clsLancamentoProdutos.ShowDialog();
			if (clsLancamentoProdutos.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkProdutos.Visible = true;
				pbNOKProdutos.Visible = false;
			}
			clsLancamentoProdutos = null;
		}
		#endregion
		#region Pesos
		private void selecionaPesos(ref System.Windows.Forms.PictureBox pbOkPesos, ref System.Windows.Forms.PictureBox pbNOKPesos)
		{
			mdlPesos.clsPesos clsPesos = new mdlPesos.clsPesosFaturasComercias(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsPesos.ShowDialog();
			if (clsPesos.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkPesos.Visible = true;
				pbNOKPesos.Visible = false;
			}
			clsPesos = null;
		}
		#endregion
		#region Numero Ordem Compra
		private void selecionaNumeroOrdemCompra(ref System.Windows.Forms.PictureBox pbOkNumeroOrdemCompra, ref System.Windows.Forms.PictureBox pbNOKNumeroOrdemCompra)
		{
			mdlNumeroOrdemCompra.clsNumeroOrdemCompra clsNumeroOrdemCompra = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsNumeroOrdemCompra.ShowDialog();
			if (clsNumeroOrdemCompra.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkNumeroOrdemCompra.Visible = true;
				pbNOKNumeroOrdemCompra.Visible = false;
			}
			clsNumeroOrdemCompra = null;
		}
		#endregion
		#region Incoterm
		private void selecionaIncoterm(ref System.Windows.Forms.PictureBox pbOkIncoterm, ref System.Windows.Forms.PictureBox pbNOKIncoterm)
		{
			mdlIncoterm.clsIncoterm clsIncoterm = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsIncoterm.ShowDialog();
			if (clsIncoterm.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkIncoterm.Visible = true;
				pbNOKIncoterm.Visible = false;
			}
			clsIncoterm = null;
		}
		#endregion
		#region Locais
		private void selecionaLocais(ref System.Windows.Forms.PictureBox pbOkLocais, ref System.Windows.Forms.PictureBox pbNOKLocais)
		{
			mdlLocais.clsLocais clsLocais = new mdlLocais.clsLocaisFaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsLocais.ShowDialog();
			if (clsLocais.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkLocais.Visible = true;
				pbNOKLocais.Visible = false;
			}
			clsLocais = null;
		}
		#endregion
		#region Condições de Pagamento
		private void selecionaCondicoesPagamento(ref System.Windows.Forms.PictureBox pbOkCondicoesPagamento, ref System.Windows.Forms.PictureBox pbNOKCondicoesPagamento)
		{
			mdlEsquemaPagamento.clsEsquemaPagamento clsEsquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, ref m_ilBandeiras, m_nIdExportador, m_strIdPE);
			clsEsquemaPagamento.ShowDialog();
			if (clsEsquemaPagamento.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkCondicoesPagamento.Visible = true;
				pbNOKCondicoesPagamento.Visible = false;
			}
			clsEsquemaPagamento = null;
		}
		#endregion
		#region BancoImportador
		private void selecionaBancoImportador(ref System.Windows.Forms.PictureBox pbOkBancos, ref System.Windows.Forms.PictureBox pbNOKBancos)
		{
			bool bPerguntarBancoImportador = false, bOKImportador = false;
			m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
			dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwTbFaturasComerciaisNew != null)
			{
				if (!dtrwTbFaturasComerciaisNew.IscondAvistaNull())
					if (dtrwTbFaturasComerciaisNew.condAvista > 0)
						bPerguntarBancoImportador = true;

				if (!dtrwTbFaturasComerciaisNew.IscondPostecipadoNull())
					if (dtrwTbFaturasComerciaisNew.condPostecipado > 0)
						bPerguntarBancoImportador = true;
			}
			if (bPerguntarBancoImportador)
			{
				mdlBancos.clsBancoImportador clsBancoImportador = new mdlBancos.BancoImportador.clsBancoImportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				clsBancoImportador.ShowDialog();
				if (clsBancoImportador.m_bModificado == false)
				{
					return;
				}
				else
				{
					bOKImportador = true;
				}
				clsBancoImportador = null;
			}
			else
			{
				bOKImportador = true;
			}
			if (bOKImportador)
			{
				pbOkBancos.Visible = true;
				pbNOKBancos.Visible = false;
			}
		}
		#endregion
		#region BancoExportador
		private void selecionaBancoExportador(ref System.Windows.Forms.PictureBox pbOkBancos, ref System.Windows.Forms.PictureBox pbNOKBancos)
		{
			bool bPerguntarBancoExportador = false, bOKExportador = false;
			m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
			dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwTbFaturasComerciaisNew != null)
			{
				bPerguntarBancoExportador = true;

			}
			if (bPerguntarBancoExportador)
			{
				mdlBancos.clsBancoExportador clsBancoExportador = new mdlBancos.BancoExportador.clsBancoExportadorComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				clsBancoExportador.ShowDialog();
				if (clsBancoExportador.m_bModificado == false)
				{
					return;
				}
				else
				{
					bOKExportador = true;
				}
				clsBancoExportador = null;
			}
			else
			{
				bOKExportador = true;
			}
			
			if (bOKExportador)
			{
				pbOkBancos.Visible = true;
				pbNOKBancos.Visible = false;
			}
		}
		#endregion
		#region Observacoes
		private void selecionaObservacoes(ref System.Windows.Forms.PictureBox pbOkObservacoes, ref System.Windows.Forms.PictureBox pbNOKObservacoes)
		{
			mdlObservacoes.clsObservacoes clsObservacoes = new mdlObservacoes.Faturas.clsObservacoesFaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsObservacoes.ShowDialog();
			if (clsObservacoes.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkObservacoes.Visible = true;
				pbNOKObservacoes.Visible = false;
			}
		}
		#endregion
		#region Assinatura
		private void selecionaAssinatura(ref System.Windows.Forms.PictureBox pbOkAssinatura, ref System.Windows.Forms.PictureBox pbNOKAssinatura)
		{
			mdlAssinatura.clsAssinatura clsAssinatura = new mdlAssinatura.clsAssinaturaComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			clsAssinatura.ShowDialog();
			if (clsAssinatura.m_bModificado == false)
			{
				return;
			}
			else
			{
				pbOkAssinatura.Visible = true;
				pbNOKAssinatura.Visible = false;
			}
		}
		#endregion
		#endregion

		#region Interface Assistente Principal
		private void carregaDadosInterfaceAssistentePrincipal(ref mdlComponentesGraficos.FormFlutuante formAssistentePrincipal, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				formAssistentePrincipal.Text = "Assistente"/* Fatura Comercial"*/;
				gbFields.Text = "Itens"/* da Fatura Comercial"*/;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSetTbProdutosFaturaCotacao()
		{
			try
			{
				// Cria os Arrays para pesquisa no Banco de Dados
				System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				arlCondicoesCampo.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);
				arlCondicoesCampo.Add("idCotacao");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_strIdCodigoModelo);

				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("idOrdem");

				m_typDatSetTbProdutosFaturaCotacao = m_cls_dbaConnnectionDB.GetTbProdutosFaturaCotacao(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTypDatSetTbProdutosFaturaComercial()
		{
			try
			{
				// Cria os Arrays para pesquisa no Banco de Dados
				System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				arlCondicoesCampo.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);

				m_typDatSetTbProdutosFaturaCotacao = m_cls_dbaConnnectionDB.GetTbProdutosFaturaCotacao(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);

//				arlCondicoesCampo.Add("idPE");
//				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
//				arlCondicoesValor.Add(m_strIdCodigoModelo);

				arlOrdenacaoValor.Clear();
				arlOrdenacaoValor.Add("idOrdem");

				m_typDatSetTbProdutosFaturaComercial = m_cls_dbaConnnectionDB.GetTbProdutosFaturaComercial(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTypDatSetTbProdutosFaturaComercialAtual()
		{
			try
			{
				// Cria os Arrays para pesquisa no Banco de Dados
				System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();

				arlCondicoesCampo.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);

				arlCondicoesCampo.Add("idPE");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_strIdPE);

				m_typDatSetTbProdutosFaturaComercial = m_cls_dbaConnnectionDB.GetTbProdutosFaturaComercial(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTypDatSetTbProdutosComercialProforma()
		{
			try
			{
				System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
				arlCondicoesCampo.Add("idExportador");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_nIdExportador);

				m_typDatSetTbProdutosFaturaComercial = m_cls_dbaConnnectionDB.GetTbProdutosFaturaComercial(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
				m_typDatSetTbProdutosFaturaProforma = m_cls_dbaConnnectionDB.GetTbProdutosFaturaProforma(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		private void carregaDadosInterfaceCadastro(ref System.Windows.Forms.GroupBox gbFields, out string strCadastroText, ref System.Windows.Forms.RadioButton rbProforma, ref System.Windows.Forms.RadioButton rbComercial)
		{
			strCadastroText = "Assistente: Processo de Exportação (PE)";
			try
			{
				gbFields.Text = "Opções";
				rbProforma.Text = "Baseado em uma Cotação (Fatura Proforma)";
				if (!m_bPossuiAlgumaCotacao)
					rbProforma.Enabled = false;
				else
					rbProforma.Enabled = true;
				if (!m_bPossuiAlgumPE)
					rbComercial.Enabled = false;
				else
					rbComercial.Enabled = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}			
		}
		#endregion
		#endregion
		
		#region Certificado de Origem
		private void copiaCertificadoDeOrigem(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetCOCount = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count;
				int nTypDatSetProdutosCOCount = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = null;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigemNew = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwTbProdutosCertificadosOrigem = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwTbProdutosCertificadosOrigemNew = null;

				#region Certificados de Origem
				for (int nCount = 0; nCount < nTypDatSetCOCount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[nCount];
					if (dtrwTbCertificadosOrigem.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwTbCertificadosOrigem.idPE == strIdPEOrigem)
						{
							dtrwTbCertificadosOrigemNew = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.FindByidExportadoridPEnIdTipoCO(m_nIdExportador, strIdPEDestino, dtrwTbCertificadosOrigem.nIdTipoCO);
							if (dtrwTbCertificadosOrigemNew == null)
							{
								dtrwTbCertificadosOrigemNew = m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.NewtbCertificadosOrigemRow();
								bNovoRegistro = true;
							}
							dtrwTbCertificadosOrigemNew.idExportador = m_nIdExportador;
							dtrwTbCertificadosOrigemNew.idPE = strIdPEDestino;
							dtrwTbCertificadosOrigemNew.nIdRelatorio = dtrwTbCertificadosOrigem.nIdRelatorio;
							dtrwTbCertificadosOrigemNew.nIdTipoCO = dtrwTbCertificadosOrigem.nIdTipoCO;
							dtrwTbCertificadosOrigemNew.dtDataCO = dtEmissao;
							if (!dtrwTbCertificadosOrigem.IsmstrNmConsignatarioCONull())
								dtrwTbCertificadosOrigemNew.mstrNmConsignatarioCO = dtrwTbCertificadosOrigem.mstrNmConsignatarioCO;
							if (!dtrwTbCertificadosOrigem.IsmstrObsCONull())
								dtrwTbCertificadosOrigemNew.mstrObsCO = dtrwTbCertificadosOrigem.mstrObsCO;
							if (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull())
								dtrwTbCertificadosOrigemNew.strNumeroCertificadoOrigem = dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem;
							if (!dtrwTbCertificadosOrigem.IsstrFormatoDatasNull())
								dtrwTbCertificadosOrigemNew.strFormatoDatas = dtrwTbCertificadosOrigem.strFormatoDatas;
							if (bNovoRegistro)
								m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.AddtbCertificadosOrigemRow(dtrwTbCertificadosOrigemNew);
						}
						else
						{
							continue;
						}
					}
				}
				for (int nCount = 0; nCount < nTypDatSetProdutosCOCount; nCount++)
				{
					dtrwTbProdutosCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCount];
					if (dtrwTbProdutosCertificadosOrigem.RowState != System.Data.DataRowState.Deleted)
					{
						bNovoRegistro = false;
						if (dtrwTbProdutosCertificadosOrigem.idPE == strIdPEOrigem)
						{
							dtrwTbProdutosCertificadosOrigemNew = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador, strIdPEDestino, dtrwTbProdutosCertificadosOrigem.idTipoCO, dtrwTbProdutosCertificadosOrigem.idOrdemProduto);
							if (dtrwTbProdutosCertificadosOrigemNew == null)
							{
								dtrwTbProdutosCertificadosOrigemNew = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.NewtbProdutosCertificadoOrigemRow();
								bNovoRegistro = true;
							}
							dtrwTbProdutosCertificadosOrigemNew.idExportador = m_nIdExportador;
							dtrwTbProdutosCertificadosOrigemNew.idPE = strIdPEDestino;
							dtrwTbProdutosCertificadosOrigemNew.idTipoCO = dtrwTbProdutosCertificadosOrigem.idTipoCO;
							dtrwTbProdutosCertificadosOrigemNew.idOrdemProduto = dtrwTbProdutosCertificadosOrigem.idOrdemProduto;
							if (!dtrwTbProdutosCertificadosOrigem.IsidNormaNull())
								dtrwTbProdutosCertificadosOrigemNew.idNorma = dtrwTbProdutosCertificadosOrigem.idNorma;
							dtrwTbProdutosCertificadosOrigemNew.idOrdem = dtrwTbProdutosCertificadosOrigem.idOrdem;
							if (bNovoRegistro)
								m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.AddtbProdutosCertificadoOrigemRow(dtrwTbProdutosCertificadosOrigemNew);
						}
					}
				}
				m_cls_dbaConnnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
				m_cls_dbaConnnectionDB.SetTbProdutosCertificadoOrigem(m_typDatSetTbProdutosCertificadoOrigem);
				#endregion

				#region PEs
				dtrwTbPEs = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,strIdPEOrigem);
				int nIdUltimoPaisImportadorTemp = -1;
				if (dtrwTbPEs != null && !dtrwTbPEs.IsnIdUltimoPaisImportadorNull())
					nIdUltimoPaisImportadorTemp = dtrwTbPEs.nIdUltimoPaisImportador;
				dtrwTbPEs = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,strIdPEDestino);
				if (dtrwTbPEs != null)
					dtrwTbPEs.nIdUltimoPaisImportador = nIdUltimoPaisImportadorTemp;
				m_cls_dbaConnnectionDB.SetTbPes(m_typDatSetTbPes);
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Instruções de Embarque
		private void copiaInstrucoesEmbarque(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetIECount = m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = null;
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarqueNew = null;

				#region Instruções de Embarque
				for (int nCount = 0; nCount < nTypDatSetIECount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[nCount];
					if (dtrwTbInstrucoesEmbarque.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwTbInstrucoesEmbarque.idPE == strIdPEOrigem)
						{
							dtrwTbInstrucoesEmbarqueNew = m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.FindByidExportadoridPE(m_nIdExportador, strIdPEDestino);
							if (dtrwTbInstrucoesEmbarqueNew == null)
							{
								dtrwTbInstrucoesEmbarqueNew = m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.NewtbInstrucoesEmbarqueRow();
								bNovoRegistro = true;
							}
							dtrwTbInstrucoesEmbarqueNew.idExportador = m_nIdExportador;
							dtrwTbInstrucoesEmbarqueNew.idPE = strIdPEDestino;
							dtrwTbInstrucoesEmbarqueNew.nIdRelatorio = (dtrwTbInstrucoesEmbarque.IsnIdRelatorioNull() ? 0 : dtrwTbInstrucoesEmbarque.nIdRelatorio);
							dtrwTbInstrucoesEmbarqueNew.nIdDespachante = (dtrwTbInstrucoesEmbarque.IsnIdDespachanteNull() ? -1 : dtrwTbInstrucoesEmbarque.nIdDespachante);
							dtrwTbInstrucoesEmbarqueNew.nIdAgente = (dtrwTbInstrucoesEmbarque.IsnIdAgenteNull() ? -1 : dtrwTbInstrucoesEmbarque.nIdAgente);
							dtrwTbInstrucoesEmbarqueNew.nIdContato = (dtrwTbInstrucoesEmbarque.IsnIdContatoNull() ? -1 : dtrwTbInstrucoesEmbarque.nIdContato);
							dtrwTbInstrucoesEmbarqueNew.dtDataEmissao = dtEmissao;
							dtrwTbInstrucoesEmbarqueNew.strNumero = "";
							dtrwTbInstrucoesEmbarqueNew.strNumeroReserva = "";
							dtrwTbInstrucoesEmbarqueNew.strNotificacao1 = (dtrwTbInstrucoesEmbarque.IsstrNotificacao1Null() ? "" : dtrwTbInstrucoesEmbarque.strNotificacao1);
							dtrwTbInstrucoesEmbarqueNew.strNotificacao2 = (dtrwTbInstrucoesEmbarque.IsstrNotificacao2Null() ? "" : dtrwTbInstrucoesEmbarque.strNotificacao2);
							dtrwTbInstrucoesEmbarqueNew.mstrDescricaoGeralMercadorias = (dtrwTbInstrucoesEmbarque.IsmstrDescricaoGeralMercadoriasNull() ? "" : dtrwTbInstrucoesEmbarque.mstrDescricaoGeralMercadorias);
							dtrwTbInstrucoesEmbarqueNew.mstrCodigoTarifario = (dtrwTbInstrucoesEmbarque.IsmstrCodigoTarifarioNull() ? "" : dtrwTbInstrucoesEmbarque.mstrCodigoTarifario);
							dtrwTbInstrucoesEmbarqueNew.mstrObservacao = (dtrwTbInstrucoesEmbarque.IsmstrObservacaoNull() ? "" : dtrwTbInstrucoesEmbarque.mstrObservacao);
							dtrwTbInstrucoesEmbarqueNew.nIdAssinatura = (dtrwTbInstrucoesEmbarque.IsnIdAssinaturaNull() ? -1 : dtrwTbInstrucoesEmbarque.nIdAssinatura);
							dtrwTbInstrucoesEmbarqueNew.nTransitTimePrevisto = (dtrwTbInstrucoesEmbarque.IsnTransitTimePrevistoNull() ? 0 : dtrwTbInstrucoesEmbarque.nTransitTimePrevisto);
							dtrwTbInstrucoesEmbarqueNew.dtDeadLineEspelho = System.DateTime.Now;
							dtrwTbInstrucoesEmbarqueNew.dtDeadLineInstrucaoEmbarque = System.DateTime.Now;
							dtrwTbInstrucoesEmbarqueNew.dtDeadLineLiberacao = System.DateTime.Now;
							dtrwTbInstrucoesEmbarqueNew.dtReserva = System.DateTime.Now;
							dtrwTbInstrucoesEmbarqueNew.bPermitirEmbarquesParciais = (dtrwTbInstrucoesEmbarque.IsbPermitirEmbarquesParciaisNull() ? true : dtrwTbInstrucoesEmbarque.bPermitirEmbarquesParciais);
							dtrwTbInstrucoesEmbarqueNew.bPermitirTransbordo = (dtrwTbInstrucoesEmbarque.IsbPermitirTransbordoNull() ? true : dtrwTbInstrucoesEmbarque.bPermitirTransbordo);
							dtrwTbInstrucoesEmbarqueNew.mstrInstrucoesProcedimento = (dtrwTbInstrucoesEmbarque.IsmstrInstrucoesProcedimentoNull() ? "" : dtrwTbInstrucoesEmbarque.mstrInstrucoesProcedimento);
							if (bNovoRegistro)
								m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.AddtbInstrucoesEmbarqueRow(dtrwTbInstrucoesEmbarqueNew);
						}
						else
						{
							continue;
						}
					}
				}
				m_cls_dbaConnnectionDB.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
				mdlNumero.clsNumero objNumero = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, strIdPEDestino);
				objNumero.salvaDiretoSemMostrarInterface();
				objNumero = null;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Borderô
		private void copiaBordero(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetBDCount = m_typDatSetTbBorderos.tbBorderos.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = null;
				mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderosNew = null;

				#region Borderô
				for (int nCount = 0; nCount < nTypDatSetBDCount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[nCount];
					if (dtrwTbBorderos.idPE == strIdPEOrigem)
					{
						dtrwTbBorderosNew = m_typDatSetTbBorderos.tbBorderos.FindByidExportadoridPE(m_nIdExportador, strIdPEDestino);
						if (dtrwTbBorderosNew == null)
						{
							dtrwTbBorderosNew = m_typDatSetTbBorderos.tbBorderos.NewtbBorderosRow();
							bNovoRegistro = true;
						}
						dtrwTbBorderosNew.idExportador = m_nIdExportador;
						dtrwTbBorderosNew.idPE = strIdPEDestino;
						dtrwTbBorderosNew.idRelatorio = (dtrwTbBorderos.IsidRelatorioNull() ? 0 : dtrwTbBorderos.idRelatorio);
						dtrwTbBorderosNew.dtDataEmissao = dtEmissao;
						dtrwTbBorderosNew.mstrObservacao = (dtrwTbBorderos.IsmstrObservacaoNull() ? "" : dtrwTbBorderos.mstrObservacao);
						dtrwTbBorderosNew.mstrCompromisso = (dtrwTbBorderos.IsmstrCompromissoNull() ? "" : dtrwTbBorderos.mstrCompromisso);
						#region Qde Documentos
						dtrwTbBorderosNew.nQtdeDocOriginalFaturaComercial = (dtrwTbBorderos.IsnQtdeDocOriginalFaturaComercialNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalFaturaComercial);
						dtrwTbBorderosNew.nQtdeDocOriginalConhecimentoEmbarque = (dtrwTbBorderos.IsnQtdeDocOriginalConhecimentoEmbarqueNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalConhecimentoEmbarque);
						dtrwTbBorderosNew.nQtdeDocOriginalSeguro = (dtrwTbBorderos.IsnQtdeDocOriginalSeguroNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalSeguro);
						dtrwTbBorderosNew.nQtdeDocOriginalCertificadoOrigem = (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoOrigemNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalCertificadoOrigem);
						dtrwTbBorderosNew.nQtdeDocOriginalRomaneio = (dtrwTbBorderos.IsnQtdeDocOriginalRomaneioNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalRomaneio);
						dtrwTbBorderosNew.nQtdeDocOriginalCertificadoPeso = (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoPesoNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalCertificadoPeso);
						dtrwTbBorderosNew.nQtdeDocOriginalCertificadoAnalise = (dtrwTbBorderos.IsnQtdeDocOriginalCertificadoAnaliseNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalCertificadoAnalise);
						dtrwTbBorderosNew.nQtdeDocOriginalSaque = (dtrwTbBorderos.IsnQtdeDocOriginalSaqueNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalSaque);
						dtrwTbBorderosNew.nQtdeDocOriginalFitoSanitario = (dtrwTbBorderos.IsnQtdeDocOriginalFitoSanitarioNull() ? 0 : dtrwTbBorderos.nQtdeDocOriginalFitoSanitario);
						dtrwTbBorderosNew.nQtdeDocCopiaFaturaComercial = (dtrwTbBorderos.IsnQtdeDocCopiaFaturaComercialNull() ? 0 : dtrwTbBorderos.nQtdeDocCopiaFaturaComercial);
						dtrwTbBorderosNew.nQtdeDocCopialConhecimentoEmbarque = (dtrwTbBorderos.IsnQtdeDocCopialConhecimentoEmbarqueNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialConhecimentoEmbarque);
						dtrwTbBorderosNew.nQtdeDocCopialSeguro = (dtrwTbBorderos.IsnQtdeDocCopialSeguroNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialSeguro);
						dtrwTbBorderosNew.nQtdeDocCopialCertificadoOrigem = (dtrwTbBorderos.IsnQtdeDocCopialCertificadoOrigemNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialCertificadoOrigem);
						dtrwTbBorderosNew.nQtdeDocCopialRomaneio = (dtrwTbBorderos.IsnQtdeDocCopialRomaneioNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialRomaneio);
						dtrwTbBorderosNew.nQtdeDocCopialCertificadoPeso = (dtrwTbBorderos.IsnQtdeDocCopialCertificadoPesoNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialCertificadoPeso);
						dtrwTbBorderosNew.nQtdeDocCopialCertificadoAnalise = (dtrwTbBorderos.IsnQtdeDocCopialCertificadoAnaliseNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialCertificadoAnalise);
						dtrwTbBorderosNew.nQtdeDocCopialSaque = (dtrwTbBorderos.IsnQtdeDocCopialSaqueNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialSaque);
						dtrwTbBorderosNew.nQtdeDocCopialFitoSanitario = (dtrwTbBorderos.IsnQtdeDocCopialFitoSanitarioNull() ? 0 : dtrwTbBorderos.nQtdeDocCopialFitoSanitario);
						#endregion
						dtrwTbBorderosNew.mstrEsquemaPagamento = (dtrwTbBorderos.IsmstrEsquemaPagamentoNull() ? "" : dtrwTbBorderos.mstrEsquemaPagamento);
						dtrwTbBorderosNew.nEntregaDocumentos = (dtrwTbBorderos.IsnEntregaDocumentosNull() ? 1 : dtrwTbBorderos.nEntregaDocumentos);
						dtrwTbBorderosNew.nCobrancaDiasVencimento = (dtrwTbBorderos.IsnCobrancaDiasVencimentoNull() ? 0 : dtrwTbBorderos.nCobrancaDiasVencimento);
						dtrwTbBorderosNew.bCobrancaProtestar = (dtrwTbBorderos.IsbCobrancaProtestarNull() ? false : dtrwTbBorderos.bCobrancaProtestar);
						dtrwTbBorderosNew.nIdAssinatura = (dtrwTbBorderos.IsnIdAssinaturaNull() ? 0 : dtrwTbBorderos.nIdAssinatura);
						dtrwTbBorderosNew.strFormatoNumero = (dtrwTbBorderos.IsstrFormatoNumeroNull() ? "" : dtrwTbBorderos.strFormatoNumero);
						if (bNovoRegistro)
							m_typDatSetTbBorderos.tbBorderos.AddtbBorderosRow(dtrwTbBorderosNew);
					}
					else
					{
						continue;
					}
				}
				m_cls_dbaConnnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
				mdlNumero.clsNumero objNumero = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, strIdPEDestino);
				objNumero.salvaDiretoSemMostrarInterface();
				objNumero = null;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Saque
		private void copiaSaque(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetSQCount = m_typDatSetTbSaques.tbSaques.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaques = null;
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaquesNew = null;

				#region Saque
				for (int nCount = 0; nCount < nTypDatSetSQCount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[nCount];
					if (dtrwTbSaques.idPE == strIdPEOrigem)
					{
						dtrwTbSaquesNew = m_typDatSetTbSaques.tbSaques.FindByidExportadoridPE(m_nIdExportador, strIdPEDestino);
						if (dtrwTbSaquesNew == null)
						{
							dtrwTbSaquesNew = m_typDatSetTbSaques.tbSaques.NewtbSaquesRow();
							bNovoRegistro = true;
						}
						dtrwTbSaquesNew.idExportador = m_nIdExportador;
						dtrwTbSaquesNew.idPE = strIdPEDestino;
						dtrwTbSaquesNew.nIdRelatorio = (dtrwTbSaques.IsnIdRelatorioNull() ? 0 : dtrwTbSaques.nIdRelatorio);
						dtrwTbSaquesNew.dtDataEmissao = dtEmissao;
						dtrwTbSaquesNew.nIdIdioma = (dtrwTbSaques.IsnIdIdiomaNull() ? 0 : dtrwTbSaques.nIdIdioma);
						dtrwTbSaquesNew.bCondicaoPagamentoAvista = (dtrwTbSaques.IsbCondicaoPagamentoAvistaNull() ? false : dtrwTbSaques.bCondicaoPagamentoAvista);
						dtrwTbSaquesNew.strNumeroSaque = "";
						if (bNovoRegistro)
							m_typDatSetTbSaques.tbSaques.AddtbSaquesRow(dtrwTbSaquesNew);
					}
					else
					{
						continue;
					}
				}
				m_cls_dbaConnnectionDB.SetTbSaques(m_typDatSetTbSaques);
				mdlNumero.clsNumero objNumero = new mdlNumero.Saque.clsSaque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, strIdPEDestino);
				objNumero.salvaDiretoSemMostrarInterface();
				objNumero = null;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Romaneio
		private void copiaRomaneio(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetRMCount = m_typDatSetTbRomaneios.tbRomaneios.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios = null;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneiosNew = null;

				#region Romaneio
				for (int nCount = 0; nCount < nTypDatSetRMCount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[nCount];
					if (dtrwTbRomaneios.idPE == strIdPEOrigem)
					{
						dtrwTbRomaneiosNew = m_typDatSetTbRomaneios.tbRomaneios.FindByidExportadoridPE(m_nIdExportador, strIdPEDestino);
						if (dtrwTbRomaneiosNew == null)
						{
							dtrwTbRomaneiosNew = m_typDatSetTbRomaneios.tbRomaneios.NewtbRomaneiosRow();
							bNovoRegistro = true;
						}
						dtrwTbRomaneiosNew.idExportador = m_nIdExportador;
						dtrwTbRomaneiosNew.idPE = strIdPEDestino;
						dtrwTbRomaneiosNew.idRelatorio = (dtrwTbRomaneios.IsidRelatorioNull() ? 0 : dtrwTbRomaneios.idRelatorio);
						dtrwTbRomaneiosNew.dtDataEmissao = dtEmissao;
						dtrwTbRomaneiosNew.nIdIdioma = (dtrwTbRomaneios.IsnIdIdiomaNull() ? 0 : dtrwTbRomaneios.nIdIdioma);
						dtrwTbRomaneiosNew.strObservacao = (dtrwTbRomaneios.IsstrObservacaoNull() ? "" : dtrwTbRomaneios.strObservacao);
						dtrwTbRomaneiosNew.strTotalVolumes = (dtrwTbRomaneios.IsstrTotalVolumesNull() ? "" : dtrwTbRomaneios.strTotalVolumes);
						dtrwTbRomaneiosNew.nIdAssinatura = (dtrwTbRomaneios.IsnIdAssinaturaNull() ? 0 : dtrwTbRomaneios.nIdAssinatura);
						dtrwTbRomaneiosNew.nTipoOrdenacao = (dtrwTbRomaneios.IsnTipoOrdenacaoNull() ? 0 : dtrwTbRomaneios.nTipoOrdenacao);
						dtrwTbRomaneiosNew.bMostrarEmbalagensConsecutivas = (dtrwTbRomaneios.IsbMostrarEmbalagensConsecutivasNull() ? true : dtrwTbRomaneios.bMostrarEmbalagensConsecutivas);
						dtrwTbRomaneiosNew.bMostrarVolumesConsecutivos = (dtrwTbRomaneios.IsbMostrarVolumesConsecutivosNull() ? false : dtrwTbRomaneios.bMostrarVolumesConsecutivos);
						if (bNovoRegistro)
							m_typDatSetTbRomaneios.tbRomaneios.AddtbRomaneiosRow(dtrwTbRomaneiosNew);
					}
					else
					{
						continue;
					}
				}
				m_cls_dbaConnnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
				mdlNumero.clsNumero objNumero = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, strIdPEDestino);
				objNumero.salvaDiretoSemMostrarInterface();
				objNumero = null;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Sumário
		private void copiaSumario(string strIdPEOrigem, string strIdPEDestino)
		{
			try
			{
				System.DateTime dtEmissao = System.DateTime.Now;
				bool bNovoRegistro = false;
				int nTypDatSetSMCount = m_typDatSetTbSumarios.tbSumarios.Rows.Count;
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwTbSumarios = null;
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwTbSumariosNew = null;

				#region Sumario
				for (int nCount = 0; nCount < nTypDatSetSMCount; nCount++)
				{
					bNovoRegistro = false;
					dtrwTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[nCount];
					if (dtrwTbSumarios.idPE == strIdPEOrigem)
					{
						dtrwTbSumariosNew = m_typDatSetTbSumarios.tbSumarios.FindByidExportadoridPE(m_nIdExportador, strIdPEDestino);
						if (dtrwTbSumariosNew == null)
						{
							dtrwTbSumariosNew = m_typDatSetTbSumarios.tbSumarios.NewtbSumariosRow();
							bNovoRegistro = true;
						}
						dtrwTbSumariosNew.idExportador = m_nIdExportador;
						dtrwTbSumariosNew.idPE = strIdPEDestino;
						dtrwTbSumariosNew.idRelatorio = (dtrwTbSumarios.IsidRelatorioNull() ? 0 : dtrwTbSumarios.idRelatorio);
						dtrwTbSumariosNew.dtEmissao = dtEmissao;
						dtrwTbSumariosNew.mstrObservacao = (dtrwTbSumarios.IsmstrObservacaoNull() ? "" : dtrwTbSumarios.mstrObservacao);
						if (bNovoRegistro)
							m_typDatSetTbSumarios.tbSumarios.AddtbSumariosRow(dtrwTbSumariosNew);
					}
					else
					{
						continue;
					}
				}
				m_cls_dbaConnnectionDB.SetTbSumarios(m_typDatSetTbSumarios);
				//mdlNumero.clsNumero objNumero = new mdlNumero.sum.clsNumeroRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, strIdPEDestino);
				//objNumero.salvaDiretoSemMostrarInterface();
				//objNumero = null;
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Métodos frmFNumeroPE
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				gbFields.Text = "Número PE";
				tbNumero.Text = m_strIdCodigo;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		private void salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNumero)
		{
			m_strIdPE = tbNumero.Text;
		}
		#endregion
		#endregion

		#region Sugestao de Numero do PE
		private void sugereNumeroPE()
		{
			try
			{
				int nMaiorNumero = 0, nTemporario = 0, nTamanhoString = 0;
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPesLocal = null;
				for (int nCount = 0; nCount < m_typDatSetTbPes.tbPEs.Rows.Count; nCount++)
				{
					try
					{
						dtrwTbPesLocal = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[nCount];
						nTemporario = Int32.Parse(dtrwTbPesLocal.idPE);
						if (nTemporario > nMaiorNumero)
							nMaiorNumero = nTemporario;
						nTemporario = dtrwTbPesLocal.idPE.Length;
						if (nTemporario > nTamanhoString)
							nTamanhoString = nTemporario;
					}
					catch (Exception err)
					{
						if (err.GetType().ToString() == "System.FormatException")
						{
							nTemporario = 0;
						}
						else
							throw err;
					}
				}
				nMaiorNumero++;
				string strCodigo = nMaiorNumero.ToString();
				nTemporario = nTamanhoString - strCodigo.Length;
				for (int nCount = 0; nCount < nTemporario; nCount++)
				{
					strCodigo = "0" + strCodigo;
				}
				if ((nMaiorNumero == 1) && (strCodigo.Length == 1))
					strCodigo = "001";
				m_strIdCodigo = strCodigo;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Cadastra Documento
			public override void cadastraDocumento()
			{
				try
				{
					int nIdRelatorioProforma = 0, nIdRelatorioComercial = 0;
					bool bNovoRegistro = false, bNovoRegistroProforma = false;
					System.Collections.ArrayList arlCondicoesCampoTbPE = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparadorTbPE = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValorTbPE = new System.Collections.ArrayList();
					arlCondicoesCampo.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesCampoTbPE.Add("idExportador");
					arlCondicoesComparadorTbPE.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValorTbPE.Add(m_nIdExportador);
					
					m_formFCadastro = new Frames.frmFCadastro(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormCadastro();
					if (m_bMostrarInterface)
						m_formFCadastro.ShowDialog();
					else
					{
						m_enumTipoCadastro = TIPOCRIACAO.MODELO1;
						m_formFCadastro.m_bModificado = true;
					}
					m_formFCadastro.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCadastro.Refresh();

					// Numero Processo
					if (m_formFCadastro.m_bModificado)
					{
						m_formFCadastro = null;
						m_formFNumeroPE = new Frames.frmFNumeroPE(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
						InitializeEventsFormNumeroPE();
						m_formFNumeroPE.ShowDialog();
						m_formFNumeroPE.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFNumeroPE.Refresh();
						if (m_formFNumeroPE.m_bModificado)
						{
							m_strIdCodigo = m_strIdPE;
							dtrwTbPes = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
							if (dtrwTbPes == null)
							{
								dtrwTbPes = m_typDatSetTbPes.tbPEs.NewtbPEsRow();
								dtrwTbPes.idExportador = m_nIdExportador;
								dtrwTbPes.idPE = m_strIdPE;
								dtrwTbPes.dtDataCriacao = System.DateTime.Now;
								m_typDatSetTbPes.tbPEs.AddtbPEsRow(dtrwTbPes);
								m_cls_dbaConnnectionDB.SetTbPes(m_typDatSetTbPes);
							}
							else
							{
								mdlMensagens.clsMensagens.ShowInformation("Criação de PE",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlCriacaoDocumentos_clsCriacaoProcesso_SobreEscreverPE).Replace("\\n","\n"));
								//System.Windows.Forms.MessageBox.Show("O PE já existe.\n O antigo PE será sobreescrito.");
								dtrwTbPes.dtDataCriacao = System.DateTime.Now;
								m_cls_dbaConnnectionDB.SetTbPes(m_typDatSetTbPes);
							}
							m_strIdCodigo = m_strIdPE;
							// Switch
							switch (m_enumTipoCadastro)
							{
								case TIPOCRIACAO.ASSISTENTE:
									#region ASSISTENTE
									#region Inicialização
									if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
										dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
									else
										return;
									dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
									if (dtrwTbFaturasComerciaisNew == null)
									{
										dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.NewtbFaturasComerciaisRow();								
										bNovoRegistro = true;
									}
									dtrwTbFaturasComerciaisNew.idRelatorio = 0;
									dtrwTbFaturasComerciaisNew.idExportador = m_nIdExportador;
									dtrwTbFaturasComerciaisNew.idPE = m_strIdPE;
									dtrwTbFaturasComerciaisNew.dataEmissao = System.DateTime.Now;
									dtrwTbFaturasComerciaisNew.idMoeda = 28;
									dtrwTbFaturasComerciaisNew.idIdioma = 3;
									dtrwTbFaturasComerciaisNew.bDetalharProdutos = true;
									if (!dtrwTbExportadores.IsidRelatorioFaturaComercialNull())
										dtrwTbFaturasComerciaisNew.idRelatorio = dtrwTbExportadores.idRelatorioFaturaComercial;

									// Coluna Codigo
									if (!dtrwTbExportadores.IscolunaCodigoNull())
										dtrwTbFaturasComerciaisNew.colunaCodigo = dtrwTbExportadores.colunaCodigo;
									else
										dtrwTbFaturasComerciaisNew.colunaCodigo = 0;
									if (!dtrwTbExportadores.IstamanhoColunaCodigoNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaCodigo = dtrwTbExportadores.tamanhoColunaCodigo;
									else
										dtrwTbFaturasComerciaisNew.tamanhoColunaCodigo = 0;
									// Coluna Descricao
									if (!dtrwTbExportadores.IscolunaDescricaoNull())
										dtrwTbFaturasComerciaisNew.colunaDescricao = dtrwTbExportadores.colunaDescricao;
									else
										dtrwTbFaturasComerciaisNew.colunaDescricao = 0;
									if (!dtrwTbExportadores.IstamanhoColunaDescricaoNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricao = dtrwTbExportadores.tamanhoColunaDescricao;
									else
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricao = 0;
									// Coluna Descricao Lingua Estrangeira 
									if (!dtrwTbExportadores.IscolunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasComerciaisNew.colunaDescricaoLinguaEstrangeira = dtrwTbExportadores.colunaDescricaoLinguaEstrangeira;
									else
										dtrwTbFaturasComerciaisNew.colunaDescricaoLinguaEstrangeira = 0;
									if (!dtrwTbExportadores.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbExportadores.tamanhoColunaDescricaoLinguaEstrangeira;
									else
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricaoLinguaEstrangeira = 0;
									// Coluna Quantidade
									if (!dtrwTbExportadores.IscolunaQuantidadeNull())
										dtrwTbFaturasComerciaisNew.colunaQuantidade = dtrwTbExportadores.colunaQuantidade;
									else
										dtrwTbFaturasComerciaisNew.colunaQuantidade = 0;
									if (!dtrwTbExportadores.IstamanhoColunaQuantidadeNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaQuantidade = dtrwTbExportadores.tamanhoColunaQuantidade;
									else
										dtrwTbFaturasComerciaisNew.tamanhoColunaQuantidade = 0;
									// Coluna Preco Unitario
									if (!dtrwTbExportadores.IscolunaPrecoUnitarioNull())
										dtrwTbFaturasComerciaisNew.colunaPrecoUnitario = dtrwTbExportadores.colunaPrecoUnitario;
									else
										dtrwTbFaturasComerciaisNew.colunaPrecoUnitario = 0;
									if (!dtrwTbExportadores.IstamanhoColunaPrecoUnitarioNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaPrecoUnitario = dtrwTbExportadores.tamanhoColunaPrecoUnitario;
									else
										dtrwTbFaturasComerciaisNew.tamanhoColunaPrecoUnitario = 0;
									// Coluna Unidade
									if (!dtrwTbExportadores.IscolunaUnidadeNull())
										dtrwTbFaturasComerciaisNew.colunaUnidade = dtrwTbExportadores.colunaUnidade;
									else
										dtrwTbFaturasComerciaisNew.colunaUnidade = 0;
									if (!dtrwTbExportadores.IstamanhoColunaUnidadeNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaUnidade = dtrwTbExportadores.tamanhoColunaUnidade;
									// Coluna Detalhar Produtos
									dtrwTbFaturasComerciaisNew.nColunaDetalharProdutos = 0;
									dtrwTbFaturasComerciaisNew.nTamanhoColunaDetalharProdutos = 0;
									// Coluna Ordem Lancamento
									dtrwTbFaturasComerciaisNew.nColunaOrdemLancamento = 0;
									dtrwTbFaturasComerciaisNew.nTamanhoColunaOrdemLancamento = 0;

									if (bNovoRegistro)
										m_typDatSetTbFaturasComerciais.tbFaturasComerciais.AddtbFaturasComerciaisRow(dtrwTbFaturasComerciaisNew);
									m_cls_dbaConnnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
									#endregion
									#region Assistente Principal
									Assistentes.clsAssistente clsAssistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteFaturaComercial(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
									clsAssistente.Automatic = true;
									clsAssistente.ForceAllItens = true;
									clsAssistente.ShowDialog();
									if (clsAssistente.Confirm == false && bNovoRegistro)
									{
										m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
										dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
										if (dtrwTbFaturasComerciaisNew != null)
											dtrwTbFaturasComerciaisNew.Delete();
										m_cls_dbaConnnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
										m_typDatSetTbPes = m_cls_dbaConnnectionDB.GetTbPes(arlCondicoesCampoTbPE,arlCondicoesComparadorTbPE,arlCondicoesValorTbPE,null,null);
										dtrwTbPes = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
										if (dtrwTbPes != null)
										{
											dtrwTbPes.Delete();
											m_cls_dbaConnnectionDB.SetTbPes(m_typDatSetTbPes);
										}
										m_bModificado = false;
										return;
									}
									m_strIdCodigo = m_strIdPE;
									m_bModificado = true;
									#endregion
									#endregion
									break;
								case TIPOCRIACAO.MODELO1:
									m_formFLista = new Frames.frmFLista(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
									InitializeEventsFormListaCotacao();
									if (m_bMostrarInterface)
										m_formFLista.ShowDialog();
									m_formFLista.Cursor = System.Windows.Forms.Cursors.WaitCursor;
									m_formFLista.Refresh();
									if (m_formFLista.m_bModificado == true || m_bMostrarInterface == false)
									{
										m_formFLista = null;
										// Copia Pe da Cotacao
										PE.clsProcessoExportacaoCopia cls_pe_Cria = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB);
										cls_pe_Cria.bCopiaCotacao(m_nIdExportador,m_strIdCodigoModelo,m_strIdPE);
										m_clsNumero = new mdlNumero.Faturas.clsNumeroComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										m_clsNumero.carregaDadosBD();
										m_clsNumero.vAjustaNumeroAcordoFormato();
										m_clsNumero.salvaDiretoSemMostrarInterface();
										m_bModificado = true;
									}else{
										PE.clsProcessoExportacaoCopia cls_pe_Cria = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB);
										cls_pe_Cria.bRemovePe(m_nIdExportador,m_strIdPE);
										m_bModificado = false;
									}
									break;
								case TIPOCRIACAO.MODELO2:
									m_formFLista = new Frames.frmFLista(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
									InitializeEventsFormListaComercial();
									if (m_bMostrarInterface)
										m_formFLista.ShowDialog();
									m_formFLista.Cursor = System.Windows.Forms.Cursors.WaitCursor;
									m_formFLista.Refresh();
									if (m_formFLista.m_bModificado == true || m_bMostrarInterface == false)
									{
										m_formFLista = null;
										// Copia Pe
										PE.clsProcessoExportacaoCopia cls_pe_Cria = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB);
										cls_pe_Cria.bCopia(m_nIdExportador,m_strIdCodigoModelo,m_strIdPE);
										// Numero Fatura Comercial
										m_clsNumero = new mdlNumero.Faturas.clsNumeroComercial(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										m_clsNumero.carregaDadosBD();
										m_clsNumero.vAjustaNumeroAcordoFormato();
										m_clsNumero.salvaDiretoSemMostrarInterface();
										// Numero Saque
										mdlNumero.clsNumero cls_Num_Saque = new mdlNumero.Saque.clsSaque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										cls_Num_Saque.carregaDadosBD();
										cls_Num_Saque.vAjustaNumeroAcordoFormato();
										cls_Num_Saque.salvaDiretoSemMostrarInterface();
										// Numero Romaneio
										mdlNumero.clsNumero cls_Num_Romaneio = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										cls_Num_Romaneio.carregaDadosBD();
										cls_Num_Romaneio.vAjustaNumeroAcordoFormato();
										cls_Num_Romaneio.salvaDiretoSemMostrarInterface();
										// Numero Instrucoes Embarque
										mdlNumero.clsNumero cls_Num_InstrucoesEmbarque = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										cls_Num_InstrucoesEmbarque.carregaDadosBD();
										cls_Num_InstrucoesEmbarque.vAjustaNumeroAcordoFormato();
										cls_Num_InstrucoesEmbarque.salvaDiretoSemMostrarInterface();
										// Numero Bordero
										mdlNumero.clsNumero cls_Num_Bordero = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
										cls_Num_Bordero.carregaDadosBD();
										cls_Num_Bordero.vAjustaNumeroAcordoFormato();
										cls_Num_Bordero.salvaDiretoSemMostrarInterface();
										m_bModificado = true;
									}else{
										PE.clsProcessoExportacaoCopia cls_pe_Cria = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB);
										cls_pe_Cria.bRemovePe(m_nIdExportador,m_strIdPE);
										m_bModificado = false;
									}
									break;
								case TIPOCRIACAO.NULO:
									#region EM BRANCO
									#region Inicialização
									if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
										dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
									else
										return;
									dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
									if (dtrwTbFaturasComerciaisNew == null)
									{
										dtrwTbFaturasComerciaisNew = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.NewtbFaturasComerciaisRow();								
										bNovoRegistro = true;
									}
									dtrwTbFaturasComerciaisNew.idRelatorio = 0;
									dtrwTbFaturasComerciaisNew.idExportador = m_nIdExportador;
									dtrwTbFaturasComerciaisNew.idPE = m_strIdPE;
									dtrwTbFaturasComerciaisNew.dataEmissao = System.DateTime.Now;
									dtrwTbFaturasComerciaisNew.idIdioma = 3;
									dtrwTbFaturasComerciaisNew.idMoeda = 28;
									dtrwTbFaturasComerciaisNew.bDetalharProdutos = true;
									if (!dtrwTbExportadores.IsidRelatorioFaturaComercialNull())
										dtrwTbFaturasComerciaisNew.idRelatorio = dtrwTbExportadores.idRelatorioFaturaComercial;
									if (!dtrwTbExportadores.IscolunaCodigoNull())
										dtrwTbFaturasComerciaisNew.colunaCodigo = dtrwTbExportadores.colunaCodigo;
									if (!dtrwTbExportadores.IstamanhoColunaCodigoNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaCodigo = dtrwTbExportadores.tamanhoColunaCodigo;
									if (!dtrwTbExportadores.IscolunaDescricaoNull())
										dtrwTbFaturasComerciaisNew.colunaDescricao = dtrwTbExportadores.colunaDescricao;
									if (!dtrwTbExportadores.IstamanhoColunaDescricaoNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricao = dtrwTbExportadores.tamanhoColunaDescricao;
									if (!dtrwTbExportadores.IscolunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasComerciaisNew.colunaDescricaoLinguaEstrangeira = dtrwTbExportadores.colunaDescricaoLinguaEstrangeira;
									if (!dtrwTbExportadores.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbExportadores.tamanhoColunaDescricaoLinguaEstrangeira;
									if (!dtrwTbExportadores.IscolunaQuantidadeNull())
										dtrwTbFaturasComerciaisNew.colunaQuantidade = dtrwTbExportadores.colunaQuantidade;
									if (!dtrwTbExportadores.IstamanhoColunaQuantidadeNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaQuantidade = dtrwTbExportadores.tamanhoColunaQuantidade;
									if (!dtrwTbExportadores.IscolunaPrecoUnitarioNull())
										dtrwTbFaturasComerciaisNew.colunaPrecoUnitario = dtrwTbExportadores.colunaPrecoUnitario;
									if (!dtrwTbExportadores.IstamanhoColunaPrecoUnitarioNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaPrecoUnitario = dtrwTbExportadores.tamanhoColunaPrecoUnitario;
									if (!dtrwTbExportadores.IscolunaUnidadeNull())
										dtrwTbFaturasComerciaisNew.colunaUnidade = dtrwTbExportadores.colunaUnidade;
									if (!dtrwTbExportadores.IstamanhoColunaUnidadeNull())
										dtrwTbFaturasComerciaisNew.tamanhoColunaUnidade = dtrwTbExportadores.tamanhoColunaUnidade;
									if (bNovoRegistro)
										m_typDatSetTbFaturasComerciais.tbFaturasComerciais.AddtbFaturasComerciaisRow(dtrwTbFaturasComerciaisNew);
									m_cls_dbaConnnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
									m_bModificado = true;
									#endregion
									#endregion
									break;
							}
						}
					}
					else
					{
						m_bModificado = false;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_terTratadorErro.trataErro(ref erro);
				}
				m_strIdCodigo = m_strIdPE;
			}

			private void InitializeEventsFormCadastro()
			{
				// Carrega Dados Interface
				m_formFCadastro.eCallCarregaDadosInterface += new Frames.frmFCadastro.delCallCarregaDadosInterface(carregaDadosInterfaceCadastro);

				// Seleciona Tipo Criação
				m_formFCadastro.eCallSelecionaTipoCriacao += new Frames.frmFCadastro.delCallSelecionaTipoCriacao(selecionaTipoCriacao);
			}

			private void InitializeEventsFormListaCotacao()
			{
				// Carrega Dados Interface
				m_formFLista.eCallCarregaDadosInterface += new Frames.frmFLista.delCallCarregaDadosInterface(carregaDadosCotacao);

				// Salva Item Selecionado
				m_formFLista.eCallSelecionaItemLista += new Frames.frmFLista.delCallSelecionaItemLista(selecionaItemModelo);
			}
			private void InitializeEventsFormListaComercial()
			{
				// Carrega Dados Interface
				m_formFLista.eCallCarregaDadosInterface += new Frames.frmFLista.delCallCarregaDadosInterface(carregaDadosComerciais);

				// Salva Item Selecionado
				m_formFLista.eCallSelecionaItemLista += new Frames.frmFLista.delCallSelecionaItemLista(selecionaItemModelo);
			}

			private void InitializeEventsFormNumeroPE()
			{
				// Carrega Dados Interface
				m_formFNumeroPE.eCallCarregaDadosInterface += new Frames.frmFNumeroPE.delCallCarregaDadosInterface(carregaDadosInterface);

				// Salva Dados Interface
				m_formFNumeroPE.eCallSalvaDadosInterface += new Frames.frmFNumeroPE.delCallSalvaDadosInterface(salvaDadosInterface);
			}
		#endregion
		#region Assistente
		public override void ShowAssistente()
		{
			try
			{
				m_formFAssistentePrincipal = new Frames.frmFAssistentePrincipal(ref m_cls_terTratadorErro, m_strEnderecoExecutavel, Boolean.TrueString);
				InitializeEventsFormAssistentePrincipal();
				carregaDadosEstadoAssistente();
				m_formFAssistentePrincipal.setaEstadoAssistente(m_bIdiomaOK, m_bMoedaOK, m_bImportadorOK, m_bProdutosOK, m_bPesosOK, m_bNumeroOrdemCompraOK, m_bIncotermsOK, m_bLocaisOK, m_bCondicoesPagamentoOK, m_bBancoImportadorOK, m_bBancoExportadorOK, m_bObservacoesOK, m_bNumeroFaturaOK, m_bAssinaturaOK);
				m_formFAssistentePrincipal.ShowDialog();
				m_formFAssistentePrincipal = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosEstadoAssistente()
		{
			try
			{
				bool bPerguntarBancoImportador = false;
				carregaTypDatSetTbProdutosFaturaComercialAtual();
				dtrwTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador, m_strIdPE);
				if (dtrwTbFaturasComerciais != null)
				{
					#region Idioma
					if ((!dtrwTbFaturasComerciais.IsidIdiomaNull()) && (dtrwTbFaturasComerciais.idIdioma != -1))
						m_bIdiomaOK = true;
					#endregion
					#region Moeda
					if ((!dtrwTbFaturasComerciais.IsidMoedaNull()) && (dtrwTbFaturasComerciais.idMoeda != -1))
						m_bMoedaOK = true;
					#endregion
					#region Importador
					if ((!dtrwTbFaturasComerciais.IsidImportadorNull()) && (dtrwTbFaturasComerciais.idImportador != -1))
						m_bImportadorOK = true;
					#endregion
					#region Produtos
					if (m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count > 0)
						m_bProdutosOK = true;
					#endregion
					#region Pesos
					if ((!dtrwTbFaturasComerciais.IspesoLiquidoNull()) && (!dtrwTbFaturasComerciais.IspesoBrutoNull()) && (!dtrwTbFaturasComerciais.IsnUnidadeMassaPesoLiquidoNull()) && (!dtrwTbFaturasComerciais.IsnUnidadeMassaPesoBrutoNull()) && (dtrwTbFaturasComerciais.nUnidadeMassaPesoBruto != -1) && (dtrwTbFaturasComerciais.nUnidadeMassaPesoLiquido != -1))
						m_bPesosOK = true;
					#endregion
					#region Número Ordem Compra
					if ((!dtrwTbFaturasComerciais.IsordemCompraNull()) && (dtrwTbFaturasComerciais.ordemCompra.Trim() != ""))
						m_bNumeroOrdemCompraOK = true;
					#endregion
					#region Incoterms
					if ((!dtrwTbFaturasComerciais.IsidIncotermNull()) && (dtrwTbFaturasComerciais.idIncoterm != -1))
						m_bIncotermsOK = true;
					#endregion
					#region Locais
					if ((!dtrwTbFaturasComerciais.IslocalColetaNull()) || (!dtrwTbFaturasComerciais.IslocalDespachoNull()) || (!dtrwTbFaturasComerciais.IslocalDestinoNull()) || (!dtrwTbFaturasComerciais.IslocalEmbarqueNull()) || (!dtrwTbFaturasComerciais.IslocalEntregaNull()))
						m_bLocaisOK = true;
					#endregion
					#region Condições de Pagamento
					if ((!dtrwTbFaturasComerciais.IscondAntecipadoNull()) && (!dtrwTbFaturasComerciais.IscondAvistaNull()) && (!dtrwTbFaturasComerciais.IscondPostecipadoNull()) && (!dtrwTbFaturasComerciais.IscondSemCoberturaCambialNull()) && (!dtrwTbFaturasComerciais.IscondConsignacaoNull()))
						m_bCondicoesPagamentoOK = true;
					#endregion
					#region BancoImportador
					if (!dtrwTbFaturasComerciais.IscondAvistaNull())
						if (dtrwTbFaturasComerciais.condAvista > 0)
							bPerguntarBancoImportador = true;

					if (!dtrwTbFaturasComerciais.IscondPostecipadoNull())
						if (dtrwTbFaturasComerciais.condPostecipado > 0)
							bPerguntarBancoImportador = true;
					if (bPerguntarBancoImportador)
					{
						if ((!dtrwTbFaturasComerciais.IsidImportadorBancoNull()) && (dtrwTbFaturasComerciais.idImportadorBanco != -1))
							m_bBancoImportadorOK = true;
					}
					else
					{
						m_bBancoImportadorOK = true;
					}
					#endregion
					#region BancoExportador
					if ((!dtrwTbFaturasComerciais.IsidExportadorBancoNull()) && (dtrwTbFaturasComerciais.idExportadorBanco != -1))
						m_bBancoExportadorOK = true;
					#endregion
					#region Observações
					if ((!dtrwTbFaturasComerciais.IsmstrObservacaoNull()) && (dtrwTbFaturasComerciais.mstrObservacao.Trim() != ""))
						m_bObservacoesOK = true;
					#endregion
					#region Número Fatura
					if ((!dtrwTbFaturasComerciais.IsnumeroFaturaNull()) && (dtrwTbFaturasComerciais.numeroFatura.Trim() != ""))
						m_bNumeroFaturaOK = true;
					#endregion
					#region Assinatura
					if ((!dtrwTbFaturasComerciais.IsidAssinaturaNull()) && (dtrwTbFaturasComerciais.idAssinatura != -1))
						m_bAssinaturaOK = true;
					#endregion
				}
			}
			catch (Exception erro)
			{
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
