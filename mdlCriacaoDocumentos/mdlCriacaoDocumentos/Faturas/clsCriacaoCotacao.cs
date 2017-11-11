using System;

namespace mdlCriacaoDocumentos.Faturas
{
	/// <summary>
	/// Summary description for clsCriacaoCotacao.
	/// </summary>
	public class clsCriacaoCotacao : clsCriacao
	{
		#region Atributos
		private string m_strIdCotacao = "";
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwTbFaturasCotacoes;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwTbFaturasCotacoesNew;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwTbProdutosFaturaCotacao;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwTbProdutosFaturaCotacaoNew;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwTbProdutosFaturaComercial;

		private System.Collections.ArrayList m_arlCondicoesCampo = new System.Collections.ArrayList();
		private System.Collections.ArrayList m_arlCondicoesComparador = new System.Collections.ArrayList();
		private System.Collections.ArrayList m_arlCondicoesValor = new System.Collections.ArrayList();
		#endregion
		#region Construtors and Destrutors
			public clsCriacaoCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, ref System.Windows.Forms.ImageList ilBandeiras) : base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador, ref ilBandeiras)
			{
				sugereNumeroCotacao();
			}
			public clsCriacaoCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string idCotacao, ref System.Windows.Forms.ImageList ilBandeiras) : base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador, ref ilBandeiras)
			{
				m_strIdCotacao = idCotacao;
			}
		#endregion

		#region InitializeEventsFormAssistentePrincipal
		private void InitializeEventsFormAssistentePrincipal()
		{
			// Interface
			m_formFAssistentePrincipal.eCallCarregaDadosInterface += new Frames.frmFAssistentePrincipal.delCallCarregaDadosInterface(carregaDadosInterfaceAssistentePrincipal);

//			// clique Numero da Fatura
//			m_formFAssistentePrincipal.eCallSelecionaNumeroFatura += new Frames.frmFAssistentePrincipal.delCallSelecionaNumeroFatura(selecionaNumeroFatura);

			// Clique Número Fatura - Testando com o mesmo da Comercial
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
			m_clsNumero = new mdlNumero.Faturas.clsNumeroFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
				mdlIdioma.clsIdioma clsIdioma = new mdlIdioma.clsIdiomaFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao, ref m_ilBandeiras);
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
			mdlMoeda.clsMoeda clsMoeda = new mdlMoeda.clsMoedaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlImportador.clsImportador clsImportador = new mdlImportador.clsImportadorCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao, ref m_ilBandeiras);
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
			mdlProdutosLancamento.clsLancamentoProdutos clsLancamentoProdutos = new mdlProdutosLancamento.clsLancamentoProdutosFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, ref m_ilBandeiras, m_nIdExportador, m_strIdCotacao);
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
			mdlPesos.clsPesos clsPesos = new mdlPesos.clsPesosFaturasCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlNumeroOrdemCompra.clsNumeroOrdemCompra clsNumeroOrdemCompra = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlIncoterm.clsIncoterm clsIncoterm = new mdlIncoterm.Faturas.clsIncotermCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlLocais.clsLocais clsLocais = new mdlLocais.clsLocaisFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlEsquemaPagamento.clsEsquemaPagamento clsEsquemaPagamento = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, ref m_ilBandeiras, m_nIdExportador, m_strIdCotacao);
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
			m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(m_arlCondicoesCampo,m_arlCondicoesComparador,m_arlCondicoesValor,null,null);
			dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
			if (dtrwTbFaturasCotacoesNew != null)
			{
				if (!dtrwTbFaturasCotacoesNew.IscondAvistaNull())
					if (dtrwTbFaturasCotacoesNew.condAvista > 0)
						bPerguntarBancoImportador = true;

				if (!dtrwTbFaturasCotacoesNew.IscondPostecipadoNull())
					if (dtrwTbFaturasCotacoesNew.condPostecipado > 0)
						bPerguntarBancoImportador = true;
			}
			//m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes); É necessário??????????
			if (bPerguntarBancoImportador)
			{
				mdlBancos.clsBancoImportador clsBancoImportador = new mdlBancos.BancoImportador.clsBancoImportadorCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(m_arlCondicoesCampo,m_arlCondicoesComparador,m_arlCondicoesValor,null,null);
			dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
			if (dtrwTbFaturasCotacoesNew != null)
			{
				bPerguntarBancoExportador = true;
			}
			//m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes); É necessário??????????
			if (bPerguntarBancoExportador)
			{
				mdlBancos.clsBancoExportador clsBancoExportador = new mdlBancos.BancoExportador.clsBancoExportadorCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlObservacoes.clsObservacoes clsObservacoes = new mdlObservacoes.Faturas.clsObservacoesFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
			mdlAssinatura.clsAssinatura clsAssinatura = new mdlAssinatura.clsAssinaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
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
				formAssistentePrincipal.Text = "Assistente"/* Fatura Cotação"*/;
				gbFields.Text = "Itens"/* da Fatura Cotação"*/;
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
		private void carregaTypDatSetTbProdutosFaturaCotacaoAtual()
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
				
				arlCondicoesCampo.Add("idCotacao");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_strIdCotacao);

				m_typDatSetTbProdutosFaturaCotacao = m_cls_dbaConnnectionDB.GetTbProdutosFaturaCotacao(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
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

				arlOrdenacaoValor.Clear();
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

				arlCondicoesCampo.Add("idPE");
				arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicoesValor.Add(m_strIdCodigoModelo);

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
		#endregion
		#region Interface
		private void carregaDadosInterfaceCadastro(ref System.Windows.Forms.GroupBox gbFields, out string strCadastroText, ref System.Windows.Forms.RadioButton rbProforma, ref System.Windows.Forms.RadioButton rbComercial)
		{
			strCadastroText = "Cotação";
			try
			{
				gbFields.Text = "Emissão de Fatura Proforma";
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

		#region Sugestao de Numero de Cotacao
		private void sugereNumeroCotacao()
		{
			try
			{
				int nMaiorNumero = 0, nTemporario = 0, nTamanhoString = 0;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwTbFaturasCotacoes = null;
				for (int nCount = 0; nCount < m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count; nCount++)
				{
					try
					{
						dtrwTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[nCount];
						nTemporario = Int32.Parse(dtrwTbFaturasCotacoes.idCotacao);
						if (nTemporario > nMaiorNumero)
							nMaiorNumero = nTemporario;
						nTemporario = dtrwTbFaturasCotacoes.idCotacao.Length;
						if (nTemporario > nTamanhoString)
							nTamanhoString = nTemporario;
					}catch (Exception err){
						nTemporario = 0;
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
				m_strIdCotacao = strCodigo;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}

		private string strNextNumeroCotacao()
		{
			string strReturn = "";
			int nReturn = 1;
			for(int i = 0; i < m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwCotacao = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[i];
				int nCurrent = 0;
				try
				{
					nCurrent = Int32.Parse(dtrwCotacao.mstrNumero);
				}catch{
					nCurrent = 0;
				}
				if (nCurrent > nReturn)
					nReturn = nCurrent;
			}
			nReturn++;
			if (nReturn < 99)
				strReturn = nReturn.ToString("000");
			else
				strReturn = nReturn.ToString();
			return(strReturn);
		}
		#endregion

		#region Cadastra Documento
			public override void cadastraDocumento()
			{
				try
				{
					bool bNovoRegistro = false;
					m_arlCondicoesCampo.Add("idExportador");
					m_arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					m_arlCondicoesValor.Add(m_nIdExportador);
					
					m_formFCadastro = new Frames.frmFCadastro(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormCadastro();
					m_formFCadastro.ShowDialog();
					m_formFCadastro.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCadastro.Refresh();
					if (m_formFCadastro.m_bModificado)
					{
						sugereNumeroCotacao();
						m_strIdCodigo = m_strIdCotacao;
						#region Switch
						switch (m_enumTipoCadastro)
						{
							case TIPOCRIACAO.ASSISTENTE:
								#region ASSISTENTE
								#region Inicialização
								if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
									dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
								else
									return;
								dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
								if (dtrwTbFaturasCotacoesNew != null)
									dtrwTbFaturasCotacoesNew.Delete();
								dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.NewtbFaturasCotacoesRow();
								dtrwTbFaturasCotacoesNew.idRelatorio = 0;
								dtrwTbFaturasCotacoesNew.idExportador = m_nIdExportador;
								dtrwTbFaturasCotacoesNew.idCotacao = m_strIdCotacao;
								dtrwTbFaturasCotacoesNew.mstrNumero = m_strIdCotacao;
								dtrwTbFaturasCotacoesNew.dataEmissao = System.DateTime.Now;
								dtrwTbFaturasCotacoesNew.idIdioma = 3;
								dtrwTbFaturasCotacoesNew.idMoeda = 28;
								dtrwTbFaturasCotacoesNew.bDetalharProdutos = true;
								if (!dtrwTbExportadores.IsidRelatorioCotacaoNull())
									dtrwTbFaturasCotacoesNew.idRelatorio = dtrwTbExportadores.idRelatorioCotacao;
								if (!dtrwTbExportadores.IscolunaCodigoNull())
									dtrwTbFaturasCotacoesNew.colunaCodigo = dtrwTbExportadores.colunaCodigo;
								if (!dtrwTbExportadores.IstamanhoColunaCodigoNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaCodigo = dtrwTbExportadores.tamanhoColunaCodigo;
								if (!dtrwTbExportadores.IscolunaDescricaoNull())
									dtrwTbFaturasCotacoesNew.colunaDescricao = dtrwTbExportadores.colunaDescricao;
								if (!dtrwTbExportadores.IstamanhoColunaDescricaoNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaDescricao = dtrwTbExportadores.tamanhoColunaDescricao;
								if (!dtrwTbExportadores.IscolunaDescricaoLinguaEstrangeiraNull())
									dtrwTbFaturasCotacoesNew.colunaDescricaoLinguaEstrangeira = dtrwTbExportadores.colunaDescricaoLinguaEstrangeira;
								if (!dtrwTbExportadores.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbExportadores.tamanhoColunaDescricaoLinguaEstrangeira;
								if (!dtrwTbExportadores.IscolunaQuantidadeNull())
									dtrwTbFaturasCotacoesNew.colunaQuantidade = dtrwTbExportadores.colunaQuantidade;
								if (!dtrwTbExportadores.IstamanhoColunaQuantidadeNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaQuantidade = dtrwTbExportadores.tamanhoColunaQuantidade;
								if (!dtrwTbExportadores.IscolunaPrecoUnitarioNull())
									dtrwTbFaturasCotacoesNew.colunaPrecoUnitario = dtrwTbExportadores.colunaPrecoUnitario;
								if (!dtrwTbExportadores.IstamanhoColunaPrecoUnitarioNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaPrecoUnitario = dtrwTbExportadores.tamanhoColunaPrecoUnitario;
								if (!dtrwTbExportadores.IscolunaUnidadeNull())
									dtrwTbFaturasCotacoesNew.colunaUnidade = dtrwTbExportadores.colunaUnidade;
								if (!dtrwTbExportadores.IstamanhoColunaUnidadeNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaUnidade = dtrwTbExportadores.tamanhoColunaUnidade;
								m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.AddtbFaturasCotacoesRow(dtrwTbFaturasCotacoesNew);
								m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
								#endregion
								#region Assistente Principal
								Assistentes.clsAssistente clsAssistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteFaturaCotacao(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
								clsAssistente.Automatic = true;
								clsAssistente.ForceAllItens = true;
								clsAssistente.ShowDialog();
								if (clsAssistente.Confirm == false)
								{
									m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(m_arlCondicoesCampo,m_arlCondicoesComparador,m_arlCondicoesValor,null,null);
									dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
									if (dtrwTbFaturasCotacoesNew != null)
										dtrwTbFaturasCotacoesNew.Delete();
									m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
									m_bModificado = false;
									return;
								}
								m_bModificado = true;
								#endregion
								#endregion
								break;
							case TIPOCRIACAO.MODELO1:
								#region MODELO1
								m_formFLista = new Frames.frmFLista(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
								InitializeEventsFormListaCotacao();						
								m_formFLista.ShowDialog();
								m_formFLista.Cursor = System.Windows.Forms.Cursors.WaitCursor;
								m_formFLista.Refresh();
								if (m_formFLista.m_bModificado)
								{
									m_formFLista = null;
									PE.clsProcessoExportacaoCopia objCopiador = new mdlCriacaoDocumentos.PE.clsProcessoExportacaoCopia(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB);
									if (objCopiador.bCopiaCotacaoCotacao(m_nIdExportador,m_strIdCodigoModelo,m_strIdCotacao,strNextNumeroCotacao()))
									{
										m_clsNumero = new mdlNumero.Faturas.clsNumeroFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
										m_clsNumero.ShowDialog();
										if (m_clsNumero.m_bModificado)
										{
											m_bModificado = true;
										}
										else
										{
											m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(m_arlCondicoesCampo,m_arlCondicoesComparador,m_arlCondicoesValor,null,null);
											dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
											if (dtrwTbFaturasCotacoesNew != null)
												dtrwTbFaturasCotacoesNew.Delete();
											m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
										}
									}else{
										m_bModificado = false;
									}
								}
								else
								{
									m_bModificado = false;
								}
								#endregion
								break;
							case TIPOCRIACAO.MODELO2:
								#region MODELO2
								m_formFLista = new Frames.frmFLista(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
								InitializeEventsFormListaComercial();						
								m_formFLista.ShowDialog();
								m_formFLista.Cursor = System.Windows.Forms.Cursors.WaitCursor;
								m_formFLista.Refresh();
								if (m_formFLista.m_bModificado)
								{
									m_formFLista = null;
									#region Atribuições
									#region Tabela Faturas Comerciais
									#region Criação dos registros
									dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador, m_strIdCotacao);
									if (dtrwTbFaturasCotacoesNew == null)
									{
										dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.NewtbFaturasCotacoesRow();
										bNovoRegistro = true;
									}
									dtrwTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador, m_strIdCodigoModelo);
									dtrwTbFaturasCotacoesNew.idExportador = m_nIdExportador;
									dtrwTbFaturasCotacoesNew.idCotacao = m_strIdCotacao;
									dtrwTbFaturasCotacoesNew.mstrNumero = m_strIdCotacao;
									#endregion									
									#region Relatório
									if (!dtrwTbFaturasComerciais.IsidRelatorioNull())
										dtrwTbFaturasCotacoesNew.idRelatorio = dtrwTbFaturasComerciais.idRelatorio;
									#endregion
									#region Dados Gerais
									if (!dtrwTbFaturasComerciais.IsidIdiomaNull())
										dtrwTbFaturasCotacoesNew.idIdioma = dtrwTbFaturasComerciais.idIdioma;
									if (!dtrwTbFaturasComerciais.IsidMoedaNull())
										dtrwTbFaturasCotacoesNew.idMoeda = dtrwTbFaturasComerciais.idMoeda;
									if (!dtrwTbFaturasComerciais.IsidExportadorBancoNull())
										dtrwTbFaturasCotacoesNew.idExportadorBanco = dtrwTbFaturasComerciais.idExportadorBanco;
									if (!dtrwTbFaturasComerciais.IsmstrIdExportadorBancoInstrPgtoNull())
										dtrwTbFaturasCotacoesNew.mstrIdExportadorBancoInstrPgto = dtrwTbFaturasComerciais.mstrIdExportadorBancoInstrPgto;
									if (!dtrwTbFaturasComerciais.IsidExportadorBancoAgenciaNull())
										dtrwTbFaturasCotacoesNew.idExportadorBancoAgencia = dtrwTbFaturasComerciais.idExportadorBancoAgencia;
									if (!dtrwTbFaturasComerciais.IsidExportadorBancoContaNull())
										dtrwTbFaturasCotacoesNew.idExportadorBancoConta = dtrwTbFaturasComerciais.idExportadorBancoConta;
									if (!dtrwTbFaturasComerciais.IsidImportadorNull())
										dtrwTbFaturasCotacoesNew.idImportador = dtrwTbFaturasComerciais.idImportador;
									if (!dtrwTbFaturasComerciais.IsidImportadorEndEntregaNull())
										dtrwTbFaturasCotacoesNew.idImportadorEndEntrega = dtrwTbFaturasComerciais.idImportadorEndEntrega;
									if (!dtrwTbFaturasComerciais.IsidImportadorConsignatarioNull())
										dtrwTbFaturasCotacoesNew.idImportadorConsignatario = dtrwTbFaturasComerciais.idImportadorConsignatario;
									if (!dtrwTbFaturasComerciais.IsidImportadorBancoNull())
										dtrwTbFaturasCotacoesNew.idImportadorBanco = dtrwTbFaturasComerciais.idImportadorBanco;
									dtrwTbFaturasCotacoesNew.dataEmissao = System.DateTime.Now;
									#endregion
									#region Condições de Pagamento
									if (!dtrwTbFaturasComerciais.IscondAntecipadoNull())
										dtrwTbFaturasCotacoesNew.condAntecipado = dtrwTbFaturasComerciais.condAntecipado;
									if (!dtrwTbFaturasComerciais.IscondAvistaNull())
										dtrwTbFaturasCotacoesNew.condAvista = dtrwTbFaturasComerciais.condAvista;
									if (!dtrwTbFaturasComerciais.IscondPostecipadoNull())
										dtrwTbFaturasCotacoesNew.condPostecipado = dtrwTbFaturasComerciais.condPostecipado;
									if (!dtrwTbFaturasComerciais.IscondSemCoberturaCambialNull())
										dtrwTbFaturasCotacoesNew.condSemCoberturaCambial = dtrwTbFaturasComerciais.condSemCoberturaCambial;
									if (!dtrwTbFaturasComerciais.IscondConsignacaoNull())
										dtrwTbFaturasCotacoesNew.condConsignacao = dtrwTbFaturasComerciais.condConsignacao;
									if (!dtrwTbFaturasComerciais.IsmodAntecipadoNull())
										dtrwTbFaturasCotacoesNew.modAntecipado = dtrwTbFaturasComerciais.modAntecipado;
									if (!dtrwTbFaturasComerciais.IsmodAvistaNull())
										dtrwTbFaturasCotacoesNew.modAvista = dtrwTbFaturasComerciais.modAvista;
									if (!dtrwTbFaturasComerciais.IsmodPostecipadoNull())
										dtrwTbFaturasCotacoesNew.modPostecipado = dtrwTbFaturasComerciais.modPostecipado;
									if (!dtrwTbFaturasComerciais.IspostQuantTempoNull())
										dtrwTbFaturasCotacoesNew.postQuantTempo = dtrwTbFaturasComerciais.postQuantTempo;
									if (!dtrwTbFaturasComerciais.IspostUnidadeTempoNull())
										dtrwTbFaturasCotacoesNew.postUnidadeTempo = dtrwTbFaturasComerciais.postUnidadeTempo;
									if (!dtrwTbFaturasComerciais.IspostCondicaoNull())
										dtrwTbFaturasCotacoesNew.postCondicao = dtrwTbFaturasComerciais.postCondicao;
									if (!dtrwTbFaturasComerciais.IspostQuantParcelasNull())
										dtrwTbFaturasCotacoesNew.postQuantParcelas = dtrwTbFaturasComerciais.postQuantParcelas;
									if (!dtrwTbFaturasComerciais.IspostIntervaloNull())
										dtrwTbFaturasCotacoesNew.postIntervalo = dtrwTbFaturasComerciais.postIntervalo;
									if (!dtrwTbFaturasComerciais.IsmstrEsquemaPagamentoNull())
										dtrwTbFaturasCotacoesNew.mstrEsquemaPagamento = dtrwTbFaturasComerciais.mstrEsquemaPagamento;
									#endregion
									#region Produtos
									if (!dtrwTbFaturasComerciais.IscolunaCodigoNull())
										dtrwTbFaturasCotacoesNew.colunaCodigo = dtrwTbFaturasComerciais.colunaCodigo;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaCodigoNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaCodigo = dtrwTbFaturasComerciais.tamanhoColunaCodigo;
									if (!dtrwTbFaturasComerciais.IscolunaDescricaoNull())
										dtrwTbFaturasCotacoesNew.colunaDescricao = dtrwTbFaturasComerciais.colunaDescricao;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaDescricaoNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaDescricao = dtrwTbFaturasComerciais.tamanhoColunaDescricao;
									if (!dtrwTbFaturasComerciais.IscolunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasCotacoesNew.colunaDescricaoLinguaEstrangeira = dtrwTbFaturasComerciais.colunaDescricaoLinguaEstrangeira;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbFaturasComerciais.tamanhoColunaDescricaoLinguaEstrangeira;
									if (!dtrwTbFaturasComerciais.IscolunaQuantidadeNull())
										dtrwTbFaturasCotacoesNew.colunaQuantidade = dtrwTbFaturasComerciais.colunaQuantidade;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaQuantidadeNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaQuantidade = dtrwTbFaturasComerciais.tamanhoColunaQuantidade;
									if (!dtrwTbFaturasComerciais.IscolunaPrecoUnitarioNull())
										dtrwTbFaturasCotacoesNew.colunaPrecoUnitario = dtrwTbFaturasComerciais.colunaPrecoUnitario;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaPrecoUnitarioNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaPrecoUnitario = dtrwTbFaturasComerciais.tamanhoColunaPrecoUnitario;
									if (!dtrwTbFaturasComerciais.IscolunaUnidadeNull())
										dtrwTbFaturasCotacoesNew.colunaUnidade = dtrwTbFaturasComerciais.colunaUnidade;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaUnidadeNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaUnidade = dtrwTbFaturasComerciais.tamanhoColunaUnidade;
									#endregion
									#region Incoterms
									if (!dtrwTbFaturasComerciais.IsidMeioTransporteNull())
										dtrwTbFaturasCotacoesNew.idMeioTransporte = dtrwTbFaturasComerciais.idMeioTransporte;
									if (!dtrwTbFaturasComerciais.IsidIncotermNull())
										dtrwTbFaturasCotacoesNew.idIncoterm = dtrwTbFaturasComerciais.idIncoterm;
									if (!dtrwTbFaturasComerciais.IsfreteInternoNull())
										dtrwTbFaturasCotacoesNew.freteInterno = dtrwTbFaturasComerciais.freteInterno;
									if (!dtrwTbFaturasComerciais.IsfreteInternacionalNull())
										dtrwTbFaturasCotacoesNew.freteInternacional = dtrwTbFaturasComerciais.freteInternacional;
									if (!dtrwTbFaturasComerciais.IsseguroNull())
										dtrwTbFaturasCotacoesNew.seguro = dtrwTbFaturasComerciais.seguro;
									if (!dtrwTbFaturasComerciais.IsoutrosNull())
										dtrwTbFaturasCotacoesNew.outros = dtrwTbFaturasComerciais.outros;
									if (!dtrwTbFaturasComerciais.IsoutrosNomeNull())
										dtrwTbFaturasCotacoesNew.outrosNome = dtrwTbFaturasComerciais.outrosNome;
									if (!dtrwTbFaturasComerciais.IsratiarDespesasNull())
										dtrwTbFaturasCotacoesNew.ratiarDespesas = dtrwTbFaturasComerciais.ratiarDespesas;
									#endregion
									#region Locais Exportação
									if (!dtrwTbFaturasComerciais.IslocalColetaNull())
										dtrwTbFaturasCotacoesNew.localColeta = dtrwTbFaturasComerciais.localColeta;
									if (!dtrwTbFaturasComerciais.IslocalDespachoNull())
										dtrwTbFaturasCotacoesNew.localDespacho = dtrwTbFaturasComerciais.localDespacho;
									if (!dtrwTbFaturasComerciais.IslocalDestinoNull())
										dtrwTbFaturasCotacoesNew.localDestino = dtrwTbFaturasComerciais.localDestino;
									if (!dtrwTbFaturasComerciais.IslocalEmbarqueNull())
										dtrwTbFaturasCotacoesNew.localEmbarque = dtrwTbFaturasComerciais.localEmbarque;
									if (!dtrwTbFaturasComerciais.IslocalEntregaNull())
										dtrwTbFaturasCotacoesNew.localEntrega = dtrwTbFaturasComerciais.localEntrega;
									#endregion
									#region Pesos
									if (!dtrwTbFaturasComerciais.IspesoLiquidoNull())
										dtrwTbFaturasCotacoesNew.pesoLiquido = dtrwTbFaturasComerciais.pesoLiquido;
									if (!dtrwTbFaturasComerciais.IspesoBrutoNull())
										dtrwTbFaturasCotacoesNew.pesoBruto = dtrwTbFaturasComerciais.pesoBruto;
									if (!dtrwTbFaturasComerciais.IsnUnidadeMassaPesoLiquidoNull())
										dtrwTbFaturasCotacoesNew.nUnidadeMassaPesoLiquido = dtrwTbFaturasComerciais.nUnidadeMassaPesoLiquido;
									if (!dtrwTbFaturasComerciais.IsnUnidadeMassaPesoBrutoNull())
										dtrwTbFaturasCotacoesNew.nUnidadeMassaPesoBruto = dtrwTbFaturasComerciais.nUnidadeMassaPesoBruto;
									#endregion
									#region Observações
									if (!dtrwTbFaturasComerciais.IsmstrObservacaoNull())
										dtrwTbFaturasCotacoesNew.mstrObservacao = dtrwTbFaturasComerciais.mstrObservacao;
									#endregion
									#region Dados Gerais
									if (!dtrwTbFaturasComerciais.IsidAssinaturaNull())
										dtrwTbFaturasCotacoesNew.idAssinatura = dtrwTbFaturasComerciais.idAssinatura;
									if (!dtrwTbFaturasComerciais.IsordemCompraNull())
										dtrwTbFaturasCotacoesNew.ordemCompra = dtrwTbFaturasComerciais.ordemCompra;
									if (!dtrwTbFaturasComerciais.IsformatoDatasNull())
										dtrwTbFaturasCotacoesNew.formatoDatas = dtrwTbFaturasComerciais.formatoDatas;
									if (!dtrwTbFaturasComerciais.IsdataEmbarqueNull())
									{
										dtrwTbFaturasCotacoesNew.dataEmbarque = dtrwTbFaturasComerciais.dataEmbarque;
									}
									else
									{
										dtrwTbFaturasCotacoesNew.dataEmbarque = System.DateTime.Now;
									}
									if (!dtrwTbFaturasComerciais.IsnavioNull())
										dtrwTbFaturasCotacoesNew.navio = dtrwTbFaturasComerciais.navio;
									#endregion
									#region Campo Necessário
									if (!dtrwTbFaturasComerciais.IsidClassificacaoTarifariaMostrarNull())
										dtrwTbFaturasCotacoesNew.idClassificacaoTarifariaMostrar = dtrwTbFaturasComerciais.idClassificacaoTarifariaMostrar;
									#endregion
									#region Colunas & Tamanhos
									if (!dtrwTbFaturasComerciais.IscolunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasCotacoesNew.colunaDescricaoLinguaEstrangeira = dtrwTbFaturasComerciais.colunaDescricaoLinguaEstrangeira;
									if (!dtrwTbFaturasComerciais.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
										dtrwTbFaturasCotacoesNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbFaturasComerciais.tamanhoColunaDescricaoLinguaEstrangeira;
									#endregion
									dtrwTbFaturasCotacoesNew.bDetalharProdutos = true;
									if (bNovoRegistro)
										m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.AddtbFaturasCotacoesRow(dtrwTbFaturasCotacoesNew);
									m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
									#endregion
									#region Tabela Produtos Fatura Comercial
									carregaTypDatSetTbProdutosFaturaComercial();
									int nRegistrosTypDatSet = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;
									for (int nCount = 0; nCount < nRegistrosTypDatSet; nCount++)
									{
										bNovoRegistro = false;
										dtrwTbProdutosFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCount];
										dtrwTbProdutosFaturaCotacaoNew = m_typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.FindByidExportadoridCotacaoidOrdem(m_nIdExportador, m_strIdCotacao, dtrwTbProdutosFaturaComercial.idOrdem);
										if (dtrwTbProdutosFaturaCotacaoNew == null)
										{
											dtrwTbProdutosFaturaCotacaoNew = m_typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.NewtbProdutosFaturaCotacaoRow();
											bNovoRegistro = true;
										}
										dtrwTbProdutosFaturaCotacaoNew.idExportador = m_nIdExportador;
										dtrwTbProdutosFaturaCotacaoNew.idCotacao = m_strIdCotacao;
										if (!dtrwTbProdutosFaturaComercial.IsidProdutoNull())
											dtrwTbProdutosFaturaCotacaoNew.idProduto = dtrwTbProdutosFaturaComercial.idProduto;
										if (!dtrwTbProdutosFaturaComercial.IsdPrecoUnitarioNull())
											dtrwTbProdutosFaturaCotacaoNew.dPrecoUnitario = dtrwTbProdutosFaturaComercial.dPrecoUnitario;
										if (!dtrwTbProdutosFaturaComercial.IsstrUnidadeNull())
											dtrwTbProdutosFaturaCotacaoNew.strUnidade = dtrwTbProdutosFaturaComercial.strUnidade;
										if (!dtrwTbProdutosFaturaComercial.IsdQuantidadeNull())
											dtrwTbProdutosFaturaCotacaoNew.dQuantidade = dtrwTbProdutosFaturaComercial.dQuantidade;
										dtrwTbProdutosFaturaCotacaoNew.idOrdem = dtrwTbProdutosFaturaComercial.idOrdem;
										if (!dtrwTbProdutosFaturaComercial.IsidOrdemLancamentoNull())
											dtrwTbProdutosFaturaCotacaoNew.idOrdemLancamento = dtrwTbProdutosFaturaComercial.idOrdemLancamento;
										if (!dtrwTbProdutosFaturaComercial.IsbDetalharChildsNull())
											dtrwTbProdutosFaturaCotacaoNew.bDetalharChilds = dtrwTbProdutosFaturaComercial.bDetalharChilds;
										if (!dtrwTbProdutosFaturaComercial.IsnIdOrdemProdutoParentNull())
											dtrwTbProdutosFaturaCotacaoNew.nIdOrdemProdutoParent = dtrwTbProdutosFaturaComercial.nIdOrdemProdutoParent;
										if (bNovoRegistro)
											m_typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows.Add((System.Data.DataRow)dtrwTbProdutosFaturaCotacaoNew);
									}									
									#endregion
									#region Número da Fatura
									m_clsNumero = new mdlNumero.Faturas.clsNumeroFaturaCotacao(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
									m_clsNumero.salvaDiretoSemMostrarInterface();
	//									m_clsNumero.ShowDialog();
	//									if (m_clsNumero.m_bModificado == false)
	//									{
	//										m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
	//										dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
	//										if (dtrwTbFaturasCotacoesNew != null)
	//											dtrwTbFaturasCotacoesNew.Delete();
	//										m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
	//									}
									#endregion
									#endregion
								}
								else
								{
									m_bModificado = false;
									m_typDatSetTbFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(m_arlCondicoesCampo,m_arlCondicoesComparador,m_arlCondicoesValor,null,null);
									dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
									if (dtrwTbFaturasCotacoesNew != null)
										dtrwTbFaturasCotacoesNew.Delete();
									m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
									return;
								}
								m_cls_dbaConnnectionDB.SetTbProdutosFaturaCotacao(m_typDatSetTbProdutosFaturaCotacao);
								m_bModificado = true;
								#endregion
								break;
							case TIPOCRIACAO.NULO:
								#region EM BRANCO
								if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
									dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
								else
									return;
								dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strIdCotacao);
								if (dtrwTbFaturasCotacoesNew != null)
									dtrwTbFaturasCotacoesNew.Delete();
								dtrwTbFaturasCotacoesNew = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.NewtbFaturasCotacoesRow();
								dtrwTbFaturasCotacoesNew.idRelatorio = 0;
								dtrwTbFaturasCotacoesNew.idExportador = m_nIdExportador;
								dtrwTbFaturasCotacoesNew.idCotacao = m_strIdCotacao;
								dtrwTbFaturasCotacoesNew.mstrNumero = m_strIdCotacao;
								dtrwTbFaturasCotacoesNew.dataEmissao = System.DateTime.Now;
								dtrwTbFaturasCotacoesNew.idIdioma = 3;
								dtrwTbFaturasCotacoesNew.idMoeda = 28;
								dtrwTbFaturasCotacoesNew.bDetalharProdutos = true;
								if (!dtrwTbExportadores.IsidRelatorioCotacaoNull())
									dtrwTbFaturasCotacoesNew.idRelatorio = dtrwTbExportadores.idRelatorioCotacao;
								if (!dtrwTbExportadores.IscolunaCodigoNull())
									dtrwTbFaturasCotacoesNew.colunaCodigo = dtrwTbExportadores.colunaCodigo;
								if (!dtrwTbExportadores.IstamanhoColunaCodigoNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaCodigo = dtrwTbExportadores.tamanhoColunaCodigo;
								if (!dtrwTbExportadores.IscolunaDescricaoNull())
									dtrwTbFaturasCotacoesNew.colunaDescricao = dtrwTbExportadores.colunaDescricao;
								if (!dtrwTbExportadores.IstamanhoColunaDescricaoNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaDescricao = dtrwTbExportadores.tamanhoColunaDescricao;
								if (!dtrwTbExportadores.IscolunaDescricaoLinguaEstrangeiraNull())
									dtrwTbFaturasCotacoesNew.colunaDescricaoLinguaEstrangeira = dtrwTbExportadores.colunaDescricaoLinguaEstrangeira;
								if (!dtrwTbExportadores.IstamanhoColunaDescricaoLinguaEstrangeiraNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaDescricaoLinguaEstrangeira = dtrwTbExportadores.tamanhoColunaDescricaoLinguaEstrangeira;
								if (!dtrwTbExportadores.IscolunaQuantidadeNull())
									dtrwTbFaturasCotacoesNew.colunaQuantidade = dtrwTbExportadores.colunaQuantidade;
								if (!dtrwTbExportadores.IstamanhoColunaQuantidadeNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaQuantidade = dtrwTbExportadores.tamanhoColunaQuantidade;
								if (!dtrwTbExportadores.IscolunaPrecoUnitarioNull())
									dtrwTbFaturasCotacoesNew.colunaPrecoUnitario = dtrwTbExportadores.colunaPrecoUnitario;
								if (!dtrwTbExportadores.IstamanhoColunaPrecoUnitarioNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaPrecoUnitario = dtrwTbExportadores.tamanhoColunaPrecoUnitario;
								if (!dtrwTbExportadores.IscolunaUnidadeNull())
									dtrwTbFaturasCotacoesNew.colunaUnidade = dtrwTbExportadores.colunaUnidade;
								if (!dtrwTbExportadores.IstamanhoColunaUnidadeNull())
									dtrwTbFaturasCotacoesNew.tamanhoColunaUnidade = dtrwTbExportadores.tamanhoColunaUnidade;
								m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.AddtbFaturasCotacoesRow(dtrwTbFaturasCotacoesNew);
								m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
								m_bModificado = true;
								#endregion
								mdlNumero.clsNumero obj = new mdlNumero.Faturas.clsNumeroFaturaCotacao(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCotacao);
								obj.ShowDialog();
								if (!obj.m_bModificado)
								{
									System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
									System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
									System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
									arlCondicaoCampo.Add("idExportador");
									arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
									arlCondicaoValor.Add(m_nIdExportador);
									arlCondicaoCampo.Add("idCotacao");
									arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
									arlCondicaoValor.Add(m_strIdCotacao);
									m_cls_dbaConnnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
									mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetFaturasCotacoes = m_cls_dbaConnnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
									if (typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
									{
										typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows[0].Delete();
										m_cls_dbaConnnectionDB.SetTbFaturasCotacoes(typDatSetFaturasCotacoes);
									}
									m_bModificado = false;
								}
								break;
						}
						#endregion
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
				m_strIdCodigo = m_strIdCotacao;
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
				carregaTypDatSetTbProdutosFaturaCotacaoAtual();
				dtrwTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador, m_strIdCotacao);
				if (dtrwTbFaturasCotacoes != null)
				{
					#region Idioma
					if ((!dtrwTbFaturasCotacoes.IsidIdiomaNull()) && (dtrwTbFaturasCotacoes.idIdioma != -1))
						m_bIdiomaOK = true;
					#endregion
					#region Moeda
					if ((!dtrwTbFaturasCotacoes.IsidMoedaNull()) && (dtrwTbFaturasCotacoes.idMoeda != -1))
						m_bMoedaOK = true;
					#endregion
					#region Importador
					if ((!dtrwTbFaturasCotacoes.IsidImportadorNull()) && (dtrwTbFaturasCotacoes.idImportador != -1))
						m_bImportadorOK = true;
					#endregion
					#region Produtos
					if (m_typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows.Count > 0)
						m_bProdutosOK = true;
					#endregion
					#region Pesos
					if ((!dtrwTbFaturasCotacoes.IspesoLiquidoNull()) && (!dtrwTbFaturasCotacoes.IspesoBrutoNull()) && (!dtrwTbFaturasCotacoes.IsnUnidadeMassaPesoLiquidoNull()) && (!dtrwTbFaturasCotacoes.IsnUnidadeMassaPesoBrutoNull()) && (dtrwTbFaturasCotacoes.nUnidadeMassaPesoBruto != -1) && (dtrwTbFaturasCotacoes.nUnidadeMassaPesoLiquido != -1))
						m_bPesosOK = true;
					#endregion
					#region Número Ordem Compra
					if ((!dtrwTbFaturasCotacoes.IsordemCompraNull()) && (dtrwTbFaturasCotacoes.ordemCompra.Trim() != ""))
						m_bNumeroOrdemCompraOK = true;
					#endregion
					#region Incoterms
					if ((!dtrwTbFaturasCotacoes.IsidIncotermNull()) && (dtrwTbFaturasCotacoes.idIncoterm != -1))
						m_bIncotermsOK = true;
					#endregion
					#region Locais
					if ((!dtrwTbFaturasCotacoes.IslocalColetaNull()) || (!dtrwTbFaturasCotacoes.IslocalDespachoNull()) || (!dtrwTbFaturasCotacoes.IslocalDestinoNull()) || (!dtrwTbFaturasCotacoes.IslocalEmbarqueNull()) || (!dtrwTbFaturasCotacoes.IslocalEntregaNull()))
						m_bLocaisOK = true;
					#endregion
					#region Condições de Pagamento
					if ((!dtrwTbFaturasCotacoes.IscondAntecipadoNull()) && (!dtrwTbFaturasCotacoes.IscondAvistaNull()) && (!dtrwTbFaturasCotacoes.IscondPostecipadoNull()) && (!dtrwTbFaturasCotacoes.IscondSemCoberturaCambialNull()) && (!dtrwTbFaturasCotacoes.IscondConsignacaoNull()))
						m_bCondicoesPagamentoOK = true;
					#endregion
					#region BancoImportador
					if (!dtrwTbFaturasCotacoes.IscondAvistaNull())
						if (dtrwTbFaturasCotacoes.condAvista > 0)
							bPerguntarBancoImportador = true;

					if (!dtrwTbFaturasCotacoes.IscondPostecipadoNull())
						if (dtrwTbFaturasCotacoes.condPostecipado > 0)
							bPerguntarBancoImportador = true;
					if (bPerguntarBancoImportador)
					{
						if ((!dtrwTbFaturasCotacoes.IsidImportadorBancoNull()) && (dtrwTbFaturasCotacoes.idImportadorBanco != -1))
							m_bBancoImportadorOK = true;
					}
					else
					{
						m_bBancoImportadorOK = true;
					}
					#endregion
					#region BancoExportador
					if (!dtrwTbFaturasCotacoes.IsidExportadorBancoNull() && (dtrwTbFaturasCotacoes.idExportadorBanco != -1))
						m_bBancoExportadorOK = true;
					#endregion
					#region Observações
					if ((!dtrwTbFaturasCotacoes.IsmstrObservacaoNull()) && (dtrwTbFaturasCotacoes.mstrObservacao.Trim() != ""))
						m_bObservacoesOK = true;
					#endregion
					#region Número Fatura
					if ((!dtrwTbFaturasCotacoes.IsmstrNumeroNull()) && (dtrwTbFaturasCotacoes.mstrNumero.Trim() != ""))
						m_bNumeroFaturaOK = true;
					#endregion
					#region Assinatura
					if ((!dtrwTbFaturasCotacoes.IsidAssinaturaNull()) && (dtrwTbFaturasCotacoes.idAssinatura != -1))
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
