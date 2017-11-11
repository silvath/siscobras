using System;

namespace mdlControladoraModulos
{
	/// <summary>
	/// Summary description for clsControladoraModulos.
	/// </summary>
	public class clsControladoraModulos
	{
		#region Enums
			private enum Formulario
			{
				Contas,
				Cadastros,
				Bibliotecas,
				Cotacoes,
				PEInfo,
				FaturaCotacao,
				Sumario,
				FaturaProforma,
				FaturaComercial,
				CertificadoOrigem,
				Romaneio,
				Saque,
				InstrucaoEmbarque,
				Bordero,
				RelatorioIndefinido
			}
		#endregion

		#region Constants
			private const string SYSCOTRAY_NAME = "SyscoTray.exe";
			private const string TEXTO_CAPTION_DELIMITADOR = " > ";
			private const string TEXTO_CAPTION_SEPARADOR = " : ";
			private const string TEXTO_CAPTION_SISCOBRAS = "Siscobras";
			private const string TEXTO_CAPTION_CONTA = "Conta";
			private const string TEXTO_CAPTION_PE = "PE";
			private const string TEXTO_CAPTION_SESSAO = "Sessão";
			private const string TEXTO_CAPTION_COTACAO = "Cotação";
		#endregion
		#region Atributos
			// Funcionanemto Geral 
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel;
			private bool m_bPrestadorServico = false;

			private int m_nIdExportador; 
			private string m_strConta = "";
			private string m_strIdPE = ""; 
			private string m_strSessao = "";
			private string m_strIdCotacao = "";

			// Idioma
			//private int m_nIdioma = 1;

			// MdiSiscobras
			private frmMdiSiscobras m_formMdiSiscobras;

			// Forms 
			private mdlContas.clsContas m_cls_cnt_Contas = null;
			private mdlCadastros.clsCadastros m_cls_cad_Cadastros = null;
			private mdlBiblioteca.clsBiblioteca m_cls_bbt_Biblioteca = null;
			private mdlCotacoes.clsCotacoes m_cls_bbc_Cotacoes = null;
			private mdlPEInfo.clsPEInfo m_cls_pei_PEInformacoes = null;


			// Forms Relatorios
			private mdlRelatoriosCotacao.frmRelatoriosCotacao m_cls_frm_FaturaCotacao = null;
			private mdlRelatoriosSumario.frmRelatoriosSumario m_cls_frm_Sumario = null;
			private mdlRelatoriosFaturaProforma.frmRelatoriosFaturaProforma m_cls_frm_FaturaProforma = null;
			private mdlRelatoriosFaturaComercial.frmRelatoriosFaturaComercial m_cls_frm_FaturaComercial = null;
			private mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem m_cls_frm_CertificadoOrigem = null;
			private mdlRelatoriosRomaneio.frmRelatoriosRomaneio m_cls_frm_Romaneio = null;
			private mdlRelatoriosSaque.frmRelatoriosSaque m_cls_frm_Saque = null;
			private mdlRelatoriosInstrucaoEmbarque.frmRelatoriosInstrucaoEmbarque m_cls_frm_InstrucaoEmbarque = null;
			private mdlRelatoriosBordero.frmRelatoriosBordero m_cls_frm_Bordero = null;
			private mdlRelatoriosIndefinido.frmFRelatoriosIndefinido m_cls_frm_RelatorioIndefinido = null;
		#endregion
		#region Properties 
			private string PE 
			{
				get
				{
					return(m_strIdPE);
				}
				set
				{
					m_strIdPE = value;
					m_strIdCotacao = "";
				}
			}

			private string Cotacao 
			{
				get
				{
					return(m_strIdCotacao);
				}
				set
				{
					m_strIdCotacao = value;
					m_strIdPE = "";
				}
			}
		#endregion
		#region Constructors and Destructors
		public clsControladoraModulos(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

	        m_cls_cnt_Contas = null;
			m_cls_bbt_Biblioteca = null;
		}
		#endregion

		#region TextForm
			private void vRefreshTextForm()
			{
				string strText = TEXTO_CAPTION_SISCOBRAS;
				if (m_strConta != "")
				{
					strText += TEXTO_CAPTION_DELIMITADOR;
					strText += TEXTO_CAPTION_CONTA;
					strText += TEXTO_CAPTION_SEPARADOR;
					strText += m_strConta;
					if (m_strIdPE != "")
					{
						strText += TEXTO_CAPTION_DELIMITADOR;
						strText += TEXTO_CAPTION_PE;
						strText += TEXTO_CAPTION_SEPARADOR;
						strText += m_strIdPE;
						if (m_strSessao != "")
						{
							strText += TEXTO_CAPTION_DELIMITADOR;
							strText += TEXTO_CAPTION_SESSAO;
							strText += TEXTO_CAPTION_SEPARADOR;
							strText += m_strSessao;
						}
					}
					else
					{
						if (m_strIdCotacao != "")
						{
							strText += TEXTO_CAPTION_DELIMITADOR;
							strText += TEXTO_CAPTION_COTACAO;
							strText += TEXTO_CAPTION_DELIMITADOR;
							strText += m_strIdCotacao;
						}
					}
				}
				m_formMdiSiscobras.Text = strText;
			}
		#endregion

		#region ShowDialog 
		public void ShowDialog()
		{
			try
			{
				m_formMdiSiscobras = new frmMdiSiscobras(m_strEnderecoExecutavel);
				InitializeEventsFormMdiSiscobras(ref m_formMdiSiscobras);
				m_formMdiSiscobras.ShowDialog();
			}catch (System.Exception eErro){
				m_cls_ter_tratadorErro.trataErro(ref eErro);
			}
		}
		private void InitializeEventsFormMdiSiscobras(ref frmMdiSiscobras m_formMdiSiscobras)
		{
			m_formMdiSiscobras.eCallShowStart += new mdlControladoraModulos.frmMdiSiscobras.delCallShowStart(ShowStart);

			m_formMdiSiscobras.eCallShowContas += new frmMdiSiscobras.delCallShowContas(ShowContas);
			m_formMdiSiscobras.eCallShowPrestadorServicoCadastros += new mdlControladoraModulos.frmMdiSiscobras.delCallShowPrestadorServicoCadastros(ShowFormPrestadorServicoProdutos);
			m_formMdiSiscobras.eCallShowExportadorCadastros += new mdlControladoraModulos.frmMdiSiscobras.delCallShowExportadorCadastros(ShowFormExportadorProdutos);

			m_formMdiSiscobras.eCallShowBibliotecas += new frmMdiSiscobras.delCallShowBibliotecas(ShowBibliotecas);
			m_formMdiSiscobras.eCallShowCotacoes += new frmMdiSiscobras.delCallShowCotacoes(ShowCotacoes);

			m_formMdiSiscobras.eCallShowDialogImportadores += new frmMdiSiscobras.delCallShowDialogImportadores(ShowDialogImportadores);
			m_formMdiSiscobras.eCallShowDialogProdutos += new frmMdiSiscobras.delCallShowDialogProdutos(ShowDialogProdutos);
			m_formMdiSiscobras.eCallShowDialogBancos += new frmMdiSiscobras.delCallShowDialogBancos(ShowDialogBancos);
			m_formMdiSiscobras.eCallShowDialogContratosCambio += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogContratosCambio(ShowDialogContratosCambio);

			m_formMdiSiscobras.eCallShowDialogSumario += new frmMdiSiscobras.delCallShowDialogSumario(ShowDialogSumario);
			m_formMdiSiscobras.eCallShowDialogFaturaProforma += new frmMdiSiscobras.delCallShowDialogFaturaProforma(ShowDialogFaturaProforma);
			m_formMdiSiscobras.eCallShowDialogFaturaComercial += new frmMdiSiscobras.delCallShowDialogFaturaComercial(ShowDialogFaturaComercial);
			m_formMdiSiscobras.eCallShowDialogCertificadoOrigem += new frmMdiSiscobras.delCallShowDialogCertificadoOrigem(ShowDialogCertificadoOrigem);
			m_formMdiSiscobras.eCallShowDialogRomaneio += new frmMdiSiscobras.delCallShowDialogRomaneio(ShowDialogRomaneio);
			m_formMdiSiscobras.eCallShowDialogSaque += new frmMdiSiscobras.delCallShowDialogSaque(ShowDialogSaque);
			m_formMdiSiscobras.eCallShowDialogInstrucaoEmbarque += new frmMdiSiscobras.delCallShowDialogInstrucaoEmbarque(ShowDialogInstrucaoEmbarque);
			m_formMdiSiscobras.eCallShowDialogBordero += new frmMdiSiscobras.delCallShowDialogBordero(ShowDialogBordero);
			m_formMdiSiscobras.eCallShowDialogRelatorioIndefinido += new frmMdiSiscobras.delCallShowDialogRelatorioIndefinido(ShowDialogRelatorioIndefinido);

			m_formMdiSiscobras.eCallShowDialogExportacaoDocumentos += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogExportacaoDocumentos(ShowDialogExportacaoDocumentos);

			m_formMdiSiscobras.eCallShowDialogSiscoEstatistico += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogSiscoEstatistico(ShowDialogSiscoEstatistico);
			m_formMdiSiscobras.eCallShowDialogPesquisarClassificacaoTarifaria += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogPesquisarClassificacaoTarifaria(ShowDialogPesquisaClassificacaoTarifaria);
			m_formMdiSiscobras.eCallShowDialogPreferencias += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogPreferencias(ShowDialogPreferencias);
			m_formMdiSiscobras.eCallShowDialogPreferencesNeeded += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogPreferencesNeeded(ShowDialogPreferencesNeeded);

			m_formMdiSiscobras.eCallShowDialogBancoDados += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogBancoDados(ShowDialogBancoDados);
			m_formMdiSiscobras.eCallShowDialogEnviaErros += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogEnviaErros(ShowDialogEnviaErros);
			m_formMdiSiscobras.eCallShowDialogAtualizacao += new mdlControladoraModulos.frmMdiSiscobras.delCallShowDialogAtualizacao(ShowDialogAtualizacao);

			// Existencias 
			m_formMdiSiscobras.eCallExisteFaturaComercial += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteFaturaComercial(bExisteFaturaComercial);
			m_formMdiSiscobras.eCallExisteCertificadoOrigem += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteCertificadoOrigem(bExisteCertificadoOrigem);
			m_formMdiSiscobras.eCallExisteRomaneio += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteRomaneio(bExisteRomaneio);
			m_formMdiSiscobras.eCallExisteSaque += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteSaque(bExisteSaque);
			m_formMdiSiscobras.eCallExisteInstrucaoEmbarque += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteInstrucaoEmbarque(bExisteInstrucaoEmbarque);
			m_formMdiSiscobras.eCallExisteBordero += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteBordero(bExisteBordero);
			m_formMdiSiscobras.eCallExisteSumario += new mdlControladoraModulos.frmMdiSiscobras.delCallExisteSumario(bExisteSumario);
		}

		private void ShowContas()
		{
			ShowForm(Formulario.Contas);
		}

		private void ShowBibliotecas()
		{
			ShowForm(Formulario.Bibliotecas,false);
		}

		private void ShowCotacoes()
		{
			ShowForm(Formulario.Cotacoes);
		}

		private void ShowDialogImportadores()
		{
			System.Windows.Forms.ImageList ilBandeiras = m_formMdiSiscobras.m_ilBandeiras;
			mdlImportador.clsImportador cls_imp_Importadores = new mdlImportador.clsImportadorExportador(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,ref ilBandeiras);
			cls_imp_Importadores.ShowDialog();
            cls_imp_Importadores = null;
		}

		private void ShowDialogProdutos()
		{
			System.Windows.Forms.ImageList ilBandeiras = m_formMdiSiscobras.m_ilBandeiras;
			mdlProdutosGeral.clsProdutos cls_prod_Geral = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,1,ref ilBandeiras);
			// Pe
			if (m_strIdPE != "")
			{
				cls_prod_Geral.Codigo = m_strIdPE;
			}
			// Cotacao
			if (m_strIdCotacao != "")
			{
				cls_prod_Geral.DataSourceCodigo = mdlProdutosGeral.DataSource.FaturaCotacao;
				cls_prod_Geral.Codigo = m_strIdCotacao;
			}

			cls_prod_Geral.ShowDialogProdutos();
			cls_prod_Geral = null;
		}

		private void ShowDialogBancos()
		{
			mdlBancos.clsBancoExportador cls_bnc_Exportador = new mdlBancos.BancoExportador.clsBancoExportadorGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
			cls_bnc_Exportador.ShowDialog();
			cls_bnc_Exportador = null;
		}

		private void ShowDialogContratosCambio()
		{
			mdlContratoCambio.clsContratoCambio cls_cc_Exportador = new mdlContratoCambio.clsContratoCambio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
			cls_cc_Exportador.ShowDialog();
			cls_cc_Exportador = null;
		}

		private void ShowDialogSumario()
		{
			ShowForm(Formulario.Sumario);
		}

		private void ShowDialogFaturaProforma()
		{
			ShowForm(Formulario.FaturaProforma);
		}

		private void ShowDialogFaturaComercial()
		{
			ShowForm(Formulario.FaturaComercial);
		}

		private void ShowDialogCertificadoOrigem()
		{
			ShowForm(Formulario.CertificadoOrigem);
		}

		private void ShowDialogRomaneio()
		{
			ShowForm(Formulario.Romaneio);
		}

		private void ShowDialogSaque()
		{
			ShowForm(Formulario.Saque);
		}

		private void ShowDialogInstrucaoEmbarque()
		{
			ShowForm(Formulario.InstrucaoEmbarque);
		}

		private void ShowDialogBordero()
		{
			ShowForm(Formulario.Bordero);
		}

		private void ShowDialogRelatorioIndefinido()
		{
			ShowForm(Formulario.RelatorioIndefinido);
		}

		private void ShowDialogExportacaoDocumentos()
		{
			mdlPEInfo.clsPDF cls_pdfExportacaoDoc = new mdlPEInfo.clsPDF(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
			cls_pdfExportacaoDoc.ShowDialog();
		}

		private void ShowDialogSiscoEstatistico()
		{
			mdlEstatistica.clsEstatistica cls_statistic = new mdlEstatistica.clsEstatistica(ref m_cls_dba_ConnectionDB);
			cls_statistic.EnderecoExecutavel = m_strEnderecoExecutavel;
			cls_statistic.TratadorErro = m_cls_ter_tratadorErro;
			cls_statistic.ShowDialog();
		}

		private void ShowDialogPesquisaClassificacaoTarifaria()
		{
			mdlTec.clsTec tec = new	 mdlTec.clsTec(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			tec.Exportador = m_nIdExportador;
			tec.ShowDialog();
		}

		private void ShowDialogPreferencias()
		{
			mdlPreferencias.clsPreferencias cls_pref = new mdlPreferencias.clsPreferencias(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			cls_pref.ShowDialog();
			if (cls_pref.m_bModificado)
			{
				// Relatorio Fatura Comercial
				if (cls_pref.m_bRelatorioFaturaComercialRecarregar)
				{
					if (m_cls_frm_FaturaComercial != null)
						m_cls_frm_FaturaComercial.bMostrarRelatorio();
				}

				// Relatorio Preferencias 
				if (cls_pref.m_bRelatorioRomaneioRecarregar)
				{
					if (m_cls_frm_Romaneio != null)
						m_cls_frm_Romaneio.bMostrarRelatorio();
				}
			}
			if (cls_pref.CoresModificadas)
				m_formMdiSiscobras.vMostraCor();
			cls_pref = null;
		}

		private void ShowDialogPreferencesNeeded()
		{
			mdlPreferencias.clsPreferencias cls_pref = new mdlPreferencias.clsPreferencias(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			cls_pref.ShowDialogNeeded();
			if (cls_pref.m_bModificado)
			{
				// Relatorio Fatura Comercial
				if (cls_pref.m_bRelatorioFaturaComercialRecarregar)
				{
					if (m_cls_frm_FaturaComercial != null)
						m_cls_frm_FaturaComercial.bMostrarRelatorio();
				}

				// Relatorio Preferencias 
				if (cls_pref.m_bRelatorioRomaneioRecarregar)
				{
					if (m_cls_frm_Romaneio != null)
						m_cls_frm_Romaneio.bMostrarRelatorio();
				}
			}
			cls_pref = null;
		}

		private void ShowDialogBancoDados()
		{
			mdlDataBaseConfig.clsDataBaseConfig cls_dbaConfig = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
			cls_dbaConfig.ShowDataBaseConfig();
			if (cls_dbaConfig.m_bModificado)
			{
				mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlControladoraModulos_clsControladoraModulos_ReiniciarSistemaTrocaBD));
				System.Environment.Exit(0);
			}
		}

		private void vInicializaSincronizacao()
		{
			mdlRegistro.clsRegistro cls_reg_Registro = new mdlRegistro.clsRegistro(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			cls_reg_Registro.bRequisicaoDadosWebService(false);
		}

		private void ShowDialogEnviaErros()
		{
			vInicializaSincronizacao();
			mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros cls_wbsvEnviaDados = new mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
			if (cls_wbsvEnviaDados.bEnviaDados())
				mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlControladoraModulos_clsControladoraModulos_EnvioErrosSucesso));
			else
				mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlControladoraModulos_clsControladoraModulos_EnvioErrosFalha));
		}

		private void ShowDialogAtualizacao()
		{
			vInicializaSincronizacao();
			mdlSysAtualizacao.clsSysAtualizacao cls_Atualizacao = new mdlSysAtualizacao.clsSysAtualizacao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
			if (cls_Atualizacao.CheckForUpdate())
			{
				if (mdlMensagens.clsMensagens.ShowQuestion(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlSysAtualizacao_clsAtualizacao_AtualizacaoDisponivel)) == System.Windows.Forms.DialogResult.Yes)
				{
					vInitializeSyscoTray();
					System.Environment.Exit(0);
				}
			}else{
				if (cls_Atualizacao.CheckForUpdateFromDB())
				{
					if (mdlMensagens.clsMensagens.ShowQuestion(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlSysAtualizacao_clsAtualizacao_AtualizacaoDisponivel)) == System.Windows.Forms.DialogResult.Yes)
					{
						vInitializeSyscoTray();
						System.Environment.Exit(0);
					}
				}else{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlSysAtualizacao_clsAtualizacao_SemAtualizacao));
				}
			}
		}
		#endregion 
		#region ShowForm
			private void ShowForm(Formulario enumNomeFormulario)
			{
				ShowForm(enumNomeFormulario,true);
			}

			private void ShowForm(Formulario enumNomeFormulario,bool bCanJump)
			{
				int nIdUltimoDocumento = -1;
				bool bShow = false;

                // Abrindo o Formulario
				switch(enumNomeFormulario)
				{
					case Formulario.Contas:
						bShow = ShowFormContas();
						break;
					case Formulario.Bibliotecas:
						bShow = ShowFormBibliotecas(bCanJump);
						break;
					case Formulario.Cotacoes:
						bShow = ShowFormCotacoes();
						break;
					case Formulario.PEInfo:
						nIdUltimoDocumento = 0;
						bShow = ShowFormPEInfo(bCanJump);
						break;
					case Formulario.FaturaCotacao:
						bShow = ShowFormFaturaCotacao();
						break;
					case Formulario.Sumario:
						nIdUltimoDocumento = 21;
						bShow = ShowFormSumario();
						break;
					case Formulario.FaturaProforma:
						nIdUltimoDocumento = 2;
						bShow = ShowFormFaturaProforma();
						break;
					case Formulario.FaturaComercial:
						nIdUltimoDocumento = 3;
						bShow = ShowFormFaturaComercial();
						break;
					case Formulario.CertificadoOrigem:
						nIdUltimoDocumento = 4;
						bShow = ShowFormCertificadoOrigem();
						break;
					case Formulario.Romaneio:
						nIdUltimoDocumento = 11;	
						bShow = ShowFormRomaneio();
						break;
					case Formulario.Saque:
						nIdUltimoDocumento = 14;
						bShow = ShowFormSaque();
						break;
					case Formulario.InstrucaoEmbarque:
						nIdUltimoDocumento = 15;
						bShow = ShowFormInstrucaoEmbarque();
						break;
					case Formulario.Bordero:
						nIdUltimoDocumento = 12;
						bShow = ShowFormBordero();
						break;
					case Formulario.RelatorioIndefinido:
						nIdUltimoDocumento = 23;
						bShow = ShowFormRelatorioIndefinido();
						break;
				} 

				// Salvando ultimo documento
				if ((bShow) && (nIdUltimoDocumento != -1))
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
						dtrwPe.strUltimoDocumentoUtilizado = nIdUltimoDocumento.ToString();
						m_cls_dba_ConnectionDB.SetTbPes(typDatSetPes);
					}
				}

				vRefreshTextForm();
				m_formMdiSiscobras.vMostraCorRelatorios();

				if (bShow)
				{
					// Fechando os Formularios
					if ((m_cls_cnt_Contas != null) && (enumNomeFormulario != Formulario.Contas))
					{
						CloseFormContas();
					}
					if ((m_cls_bbt_Biblioteca != null) && (enumNomeFormulario != Formulario.Bibliotecas))
					{
						CloseFormBibliotecas();
					}
					if ((m_cls_bbc_Cotacoes != null) && (enumNomeFormulario != Formulario.Cotacoes))
					{
						CloseFormCotacoes();
					}
					// Informacoes do PE 
					if ((m_cls_pei_PEInformacoes != null) && (enumNomeFormulario != Formulario.PEInfo))
					{
						CloseFormPEInfo();
					}

					// Fatura Cotacao
					if ((m_cls_frm_FaturaCotacao != null) && (enumNomeFormulario != Formulario.FaturaCotacao))
					{
						CloseFormFaturaCotacao();
					}

					// Sumario
					if ((m_cls_frm_Sumario != null) && (enumNomeFormulario != Formulario.Sumario))
					{
						CloseFormSumario();
					}

					// Fatura Proforma
					if ((m_cls_frm_FaturaProforma != null) && (enumNomeFormulario != Formulario.FaturaProforma))
					{
						CloseFormFaturaProforma();
					}

					// Fatura Comercial
					if ((m_cls_frm_FaturaComercial != null) && (enumNomeFormulario != Formulario.FaturaComercial))
					{
						CloseFormFaturaComercial();
					}

					// CertificadoOrigem,
					if ((m_cls_frm_CertificadoOrigem != null) && (enumNomeFormulario != Formulario.CertificadoOrigem))
					{
						CloseFormCertificadoOrigem();
					}

					// Romaneio,
					if ((m_cls_frm_Romaneio != null) && (enumNomeFormulario != Formulario.Romaneio))
					{
						CloseFormRomaneio();
					}

					// Saque,
					if ((m_cls_frm_Saque != null) && (enumNomeFormulario != Formulario.Saque))
					{
						CloseFormSaque();
					}

					// InstrucoesEmbarque,
					if ((m_cls_frm_InstrucaoEmbarque != null) && (enumNomeFormulario != Formulario.InstrucaoEmbarque))
					{
						CloseFormInstrucaoEmbarque();
					}

					// Bordero
					if ((m_cls_frm_Bordero != null) && (enumNomeFormulario != Formulario.Bordero))
					{
						CloseFormBordero();
					}

					// Relatorio Indefinido
					if ((m_cls_frm_RelatorioIndefinido != null) && (enumNomeFormulario != Formulario.RelatorioIndefinido))
					{
						CloseFormRelatorioIndefinido();
					}
				}

				// Desalocando Memoria 
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		#endregion

		#region ShowForm Especificos 
			#region ShowStart
				private void ShowStart()
				{
					string strCodigoCliente = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOIDCLIENTE,"");
					if ((strCodigoCliente.Length > 2) && (((strCodigoCliente.Substring(0,2) == "12") || (strCodigoCliente.Substring(0,2) == "22"))))
						m_bPrestadorServico = true;
					if(m_bPrestadorServico)
					{
						int nIdExportador = -1;
						string strNomeConta = "";
						if (bEntrarUltimaConta(out nIdExportador,out strNomeConta))
						{
							FormContasContaSelecionada(nIdExportador,strNomeConta);
						}else{
							ShowContas();
						}
					}else{
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
						mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(null,null,null,null,null);
						if (typDatSetExportadores.tbExportadores.Rows.Count == 1)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)typDatSetExportadores.tbExportadores.Rows[0];
							FormContasContaSelecionada(dtrwExportador.idExportador,dtrwExportador.nmEmp);
						}else{
							ShowContas();
						}
					}
					if (m_bPrestadorServico)
						m_formMdiSiscobras.vSetModePrestadorServico();
					else
						m_formMdiSiscobras.vSetModeExportador();
				}
			#endregion

			#region ShowFormContas
				private bool ShowFormContas()
				{
					bool bRetorno = false;

					m_strConta = "";
					m_strIdPE = "";
					m_strIdCotacao = "";
					m_strSessao = "";
					 
		            m_formMdiSiscobras.m_btTrocarConta.Visible = true;
					m_formMdiSiscobras.m_btExportadorProcessos.Visible = false;
					m_formMdiSiscobras.m_btExportadorCotacoes.Visible = false;

					// Menu Vertical
					m_formMdiSiscobras.m_gbDocumentos.Visible = false;
					m_formMdiSiscobras.m_gbExportador.Visible = false;
					m_formMdiSiscobras.m_gbPe.Visible = false;
                    
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_cnt_Contas = new mdlContas.clsContas(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_nIdExportador);
					InitializeEventsFormContas(ref m_cls_cnt_Contas);
					m_cls_cnt_Contas.Show();
					bRetorno = true;
					return(bRetorno);
				}

				private void InitializeEventsFormContas(ref mdlContas.clsContas cls_cnt_Contas)
				{
					cls_cnt_Contas.eCallContaSelecionada += new mdlContas.clsContas.delCallContaSelecionada(FormContasContaSelecionada);
				}

				private void FormContasContaSelecionada(int nIdExportador,string strNomeConta)
				{
					m_nIdExportador = nIdExportador;
					m_strConta = strNomeConta;
					m_cls_dba_ConnectionDB.SetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ULTIMA_CONTA,nIdExportador.ToString());
					ShowForm(Formulario.Bibliotecas);
				}
			#endregion
			#region ShowFormPrestadorServicoProdutos
				private void ShowFormPrestadorServicoProdutos()
				{
					m_strSessao = "Produtos";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_cad_Cadastros = new mdlCadastros.clsCadastros(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_bPrestadorServico,-1,"");
					m_cls_cad_Cadastros.Bandeiras = m_formMdiSiscobras.m_ilBandeiras;
					m_cls_cad_Cadastros.Show();
				}
			#endregion
			#region ShowFormExportadorProdutos
				private void ShowFormExportadorProdutos()
				{
					m_strSessao = "Produtos";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_cad_Cadastros = new mdlCadastros.clsCadastros(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_bPrestadorServico,m_nIdExportador,m_strIdPE);
					m_cls_cad_Cadastros.Bandeiras = m_formMdiSiscobras.m_ilBandeiras;
					m_cls_cad_Cadastros.Show();
				}
			#endregion
			#region ShowFormBibliotecas
				private bool ShowFormBibliotecas(bool bCanJump)
				{
					bool bRetorno = false;
					m_strIdPE = "";
					m_strIdCotacao = "";
					m_strSessao = "";

					// Menu Horizontal 
					m_formMdiSiscobras.m_btTrocarConta.Visible = true;
					m_formMdiSiscobras.m_btExportadorProcessos.Visible = true;
					m_formMdiSiscobras.m_btExportadorCotacoes.Visible = true;


					// Menu Vertical
					m_formMdiSiscobras.m_gbExportador.Visible = true;
					m_formMdiSiscobras.m_gbDocumentos.Visible = false;

					string strIdPe = "";
					if ((bCanJump) && (bEntrarUltimoPe(ref m_nIdExportador,ref strIdPe)))
					{
						FormBibliotecasPESelecionado(strIdPe);
					}else{
						System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
						System.Windows.Forms.ImageList ilBandeiras = m_formMdiSiscobras.m_ilBandeiras;
						m_cls_bbt_Biblioteca = new mdlBiblioteca.clsBiblioteca(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_nIdExportador,ref ilBandeiras);
						InitializeEventsFormBibliotecas(ref m_cls_bbt_Biblioteca);
						m_cls_bbt_Biblioteca.Show();
						bRetorno = true;
					}
					return(bRetorno);
				}

				private void InitializeEventsFormBibliotecas(ref mdlBiblioteca.clsBiblioteca cls_bbt_Biblioteca)
				{
					// PE Selecionado
					cls_bbt_Biblioteca.eCallPESelecionado += new mdlBiblioteca.clsBiblioteca.delCallPESelecionado(FormBibliotecasPESelecionado);

					// PE Criado
					cls_bbt_Biblioteca.eCallPeCriado += new mdlBiblioteca.clsBiblioteca.delCallPeCriado(vCalllCarregaPE);
				} 

				private void FormBibliotecasPESelecionado(string strIdPE)
				{
					m_strIdPE = strIdPE;

					// Marcando o Pe como ultimo utilizado
					System.Collections.ArrayList arlCondicaoCampo = new	 System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetExportadores.tbExportadores.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)typDatSetExportadores.tbExportadores.Rows[0];
						dtrwExportador.strUltimoPeUtilizado = strIdPE;
						m_cls_dba_ConnectionDB.SetTbExportadores(typDatSetExportadores);
					}
					ShowForm(Formulario.PEInfo,true);
				}
			#endregion
			#region ShowFormCotacoes
				private bool ShowFormCotacoes()
				{
					bool bRetorno = false;
					m_strIdPE = "";
					m_strIdCotacao = "";
					m_strSessao = "";

					// Menu Horizontal 
					m_formMdiSiscobras.m_btTrocarConta.Visible = true;
					m_formMdiSiscobras.m_btExportadorProcessos.Visible = true;

					// Menu Vertical
					m_formMdiSiscobras.m_gbDocumentos.Visible = false;
					m_formMdiSiscobras.m_gbExportador.Visible = true;
					m_formMdiSiscobras.m_gbPe.Visible = false;

					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					System.Windows.Forms.ImageList ilBandeiras = m_formMdiSiscobras.m_ilBandeiras;
					m_cls_bbc_Cotacoes = new mdlCotacoes.clsCotacoes(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_nIdExportador,ref ilBandeiras);
					InitializeEventsFormCotacoes(ref m_cls_bbc_Cotacoes);
					m_cls_bbc_Cotacoes.Show();
					bRetorno = true;
					return(bRetorno);
				}

				private void InitializeEventsFormCotacoes(ref mdlCotacoes.clsCotacoes cls_bbc_Cotacoes)
				{
					cls_bbc_Cotacoes.eCallCotacoesSelecionada += new mdlCotacoes.clsCotacoes.delCallCotacoesSelecionada(FormCotacoesCotacaoSelecionada); 
				}

				private void FormCotacoesCotacaoSelecionada(string strIdCotacao)
				{
					m_strIdCotacao = strIdCotacao;
					ShowForm(Formulario.FaturaCotacao);
				}
			#endregion
			#region ShowFormPEInfo
				private bool ShowFormPEInfo(bool bCanJump)
				{
					bool bRetorno = false;
					m_strSessao = "";

		            // Menu Horizontal 
					m_formMdiSiscobras.m_btTrocarConta.Visible = true;
					m_formMdiSiscobras.m_btExportadorProcessos.Visible = true;

					// Fatura Proforma
					m_formMdiSiscobras.VisibilidadeFaturaProforma = bExisteFaturaProforma();

					// Menu Vertical
					m_formMdiSiscobras.m_gbDocumentos.Visible = true;
					m_formMdiSiscobras.m_gbExportador.Visible = true;
					m_formMdiSiscobras.m_gbPe.Visible = true;

					int nIdDocumento = 0;
					if ((bCanJump) && (bEntrarUltimoDocumento(ref nIdDocumento)))
					{
						switch(nIdDocumento)
						{
							case 0:
								ShowFormPEInfo(false);
								break;
							case 2: // Fatura Proforma
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.FaturaProforma);
								break;
							case 3: // Fatura Comercial
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.FaturaComercial);
								break;
							case 4: // Certificado Origem
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.CertificadoOrigem);
								break;
							case 11: // Romaneio
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.Romaneio);
								break;
							case 12: // Bordero
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.Bordero);
								break;
							case 14: // Saque
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.Saque);
								break;
							case 15: // Instrucao Embarque
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.InstrucaoEmbarque);
								break;
							case 21: // Sumario
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.Sumario);
								break;
							case 23: // Indefinido
								ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.RelatorioIndefinido);
								break;
						}
					}
					else
					{
						System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
						m_cls_pei_PEInformacoes = new mdlPEInfo.clsPEInfo(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_frmMdiSiscobras,m_nIdExportador,m_strIdPE);
						InitializeEventsFormPEInfo(ref m_cls_pei_PEInformacoes);
						m_cls_pei_PEInformacoes.Show();
						bRetorno = true;
					}
					return(bRetorno);
				}
			
				private void InitializeEventsFormPEInfo(ref mdlPEInfo.clsPEInfo cls_pei_PEInformacoes)
				{
					
				}
			#endregion

			#region ShowFormFaturaCotacao
				private bool ShowFormFaturaCotacao()
				{
					bool bRetorno = false;
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_FaturaCotacao = new mdlRelatoriosCotacao.frmRelatoriosCotacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCotacao);
					vInitializeEvents(ref m_cls_frm_FaturaCotacao);
					m_cls_frm_FaturaCotacao.Show();
					bRetorno = true;
					return(bRetorno);
				}

				private void vInitializeEvents(ref mdlRelatoriosCotacao.frmRelatoriosCotacao m_cls_frm_FaturaCotacao)
				{
					// Carrega PE
					m_cls_frm_FaturaCotacao.eCallCarregaPE += new mdlRelatoriosCotacao.frmRelatoriosCotacao.delCallCarregaPE(vCalllCarregaPE);
				}

				private void vCalllCarregaPE(string strIdPE)
				{
                    m_strIdPE = strIdPE;

					m_strSessao = "";

					// Menu Horizontal 
					m_formMdiSiscobras.m_btTrocarConta.Visible = true;
					m_formMdiSiscobras.m_btExportadorProcessos.Visible = true;

					// Fatura Proforma
					m_formMdiSiscobras.VisibilidadeFaturaProforma = bExisteFaturaProforma();

					// Menu Vertical
					m_formMdiSiscobras.m_gbDocumentos.Visible = true;
					m_formMdiSiscobras.m_gbExportador.Visible = true;
					m_formMdiSiscobras.m_gbPe.Visible = true;
					ShowForm(mdlControladoraModulos.clsControladoraModulos.Formulario.FaturaComercial);
				}
			#endregion	
			#region ShowFormSumario
				private bool ShowFormSumario()
				{
					bool bRetorno = false;
					m_strSessao = "Sumário";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_Sumario = new mdlRelatoriosSumario.frmRelatoriosSumario(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_Sumario.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormFaturaProforma
				private bool ShowFormFaturaProforma()
				{
					bool bRetorno = false;
					m_strSessao = "Fatura Proforma";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_FaturaProforma = new mdlRelatoriosFaturaProforma.frmRelatoriosFaturaProforma(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_FaturaProforma.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion	
			#region ShowFormFaturaComercial
				private bool ShowFormFaturaComercial()
				{
					bool bRetorno = false;
					m_strSessao = "Fatura Comercial";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_FaturaComercial = new mdlRelatoriosFaturaComercial.frmRelatoriosFaturaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_FaturaComercial.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormCertificadoOrigem
				private bool ShowFormCertificadoOrigem()
				{
					bool bRetorno = false;
					m_strSessao = "Certificado de Origem";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_CertificadoOrigem = new mdlRelatoriosCertificadosOrigem.frmRelatoriosCertificadosOrigem(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_CertificadoOrigem.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormRomaneio
				private bool ShowFormRomaneio()
				{
					bool bRetorno = false;
					m_strSessao = "Romaneio";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_Romaneio = new mdlRelatoriosRomaneio.frmRelatoriosRomaneio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_Romaneio.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormSaque
				private bool ShowFormSaque()
				{
					bool bRetorno = false;
					m_strSessao = "Saque";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_Saque = new mdlRelatoriosSaque.frmRelatoriosSaque(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_Saque.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormInstrucaoEmbarque
				private bool ShowFormInstrucaoEmbarque()
				{
					bool bRetorno = false;
					m_strSessao = "Instrução de Embarque";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_InstrucaoEmbarque = new mdlRelatoriosInstrucaoEmbarque.frmRelatoriosInstrucaoEmbarque(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_InstrucaoEmbarque.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormBordero
				private bool ShowFormBordero()
				{
					bool bRetorno = false;
					m_strSessao = "Borderô";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_Bordero = new mdlRelatoriosBordero.frmRelatoriosBordero(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_Bordero.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region ShowFormRelatorioIndefinido
				private bool ShowFormRelatorioIndefinido()
				{
					bool bRetorno = false;
					m_strSessao = "Relatórios Diversos";
					System.Windows.Forms.Form m_frmMdiSiscobras = (System.Windows.Forms.Form)m_formMdiSiscobras;
					m_cls_frm_RelatorioIndefinido = new mdlRelatoriosIndefinido.frmFRelatoriosIndefinido(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,ref m_frmMdiSiscobras,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					m_cls_frm_RelatorioIndefinido.Show();
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
		#endregion
		#region CloseForm Especificos
			#region  CloseFormContas
				private void CloseFormContas()
				{
					m_cls_cnt_Contas.Close();
					m_cls_cnt_Contas = null;
				}
			#endregion
			#region  CloseFormBibliotecas
				private void CloseFormBibliotecas()
				{
					m_cls_bbt_Biblioteca.Close();
					m_cls_bbt_Biblioteca = null;
				}
			#endregion
			#region CloseFormCotacoes
				private void CloseFormCotacoes()
				{
					m_cls_bbc_Cotacoes.Close();
					m_cls_bbc_Cotacoes = null;
				}
			#endregion
			#region CloseFormPEInfo
				private void CloseFormPEInfo()
				{
					m_cls_pei_PEInformacoes.Close();
					m_cls_pei_PEInformacoes = null;
				}
			#endregion

			#region CloseFormFaturaCotacao
				private void CloseFormFaturaCotacao()
				{
					m_cls_frm_FaturaCotacao.Close();
					m_cls_frm_FaturaCotacao = null;
				}
			#endregion
			#region CloseFormSumario
				private void CloseFormSumario()
				{
					m_cls_frm_Sumario.Close();
					m_cls_frm_Sumario = null;
				}
			#endregion
			#region CloseFormFaturaProforma
				private void CloseFormFaturaProforma()
				{
					m_cls_frm_FaturaProforma.Close();
					m_cls_frm_FaturaProforma = null;
				}
			#endregion
			#region CloseFormFaturaComercial
				private void CloseFormFaturaComercial()
				{
					m_cls_frm_FaturaComercial.Close();
					m_cls_frm_FaturaComercial = null;
				}
			#endregion
			#region CloseFormCertificadoOrigem
				private void CloseFormCertificadoOrigem()
				{
					m_cls_frm_CertificadoOrigem.Close();
					m_cls_frm_CertificadoOrigem = null;
				}
			#endregion
			#region CloseFormRomaneio
				private void CloseFormRomaneio()
				{
					m_cls_frm_Romaneio.Close();
					m_cls_frm_Romaneio = null;
				}
			#endregion
			#region CloseFormSaque
				private void CloseFormSaque()
				{
					m_cls_frm_Saque.Close();
					m_cls_frm_Saque = null;
				}
			#endregion
			#region CloseFormInstrucaoEmbarque
				private void CloseFormInstrucaoEmbarque()
				{
					m_cls_frm_InstrucaoEmbarque.Close();
					m_cls_frm_InstrucaoEmbarque = null;
				}
			#endregion
			#region CloseFormBordero
				private void CloseFormBordero()
				{
					m_cls_frm_Bordero.Close();
					m_cls_frm_Bordero = null;
				}
			#endregion
			#region CloseFormRelatorioIndefinido
				private void CloseFormRelatorioIndefinido()
				{
					m_cls_frm_RelatorioIndefinido.Close();
					m_cls_frm_RelatorioIndefinido = null;
				}
			#endregion
		#endregion

		#region SyscoTray
			private void vInitializeSyscoTray()
			{
				System.Diagnostics.Process proSyscoTray = new System.Diagnostics.Process();
				proSyscoTray.StartInfo = new System.Diagnostics.ProcessStartInfo(m_strEnderecoExecutavel + SYSCOTRAY_NAME," /UPDATE");
				proSyscoTray.Start();
			}
		#endregion

		#region Existencia
			private bool bExisteFaturaProforma()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0);
			}

			private bool bExisteFaturaComercial()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0);
			}

			private bool bExisteCertificadoOrigem()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0);
			}

			private bool bExisteRomaneio()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0);
			}

			private bool bExisteSaque()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbSaques.tbSaques.Rows.Count > 0);
			}

			private bool bExisteInstrucaoEmbarque()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0);
			}

			private bool bExisteBordero()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbBorderos.tbBorderos.Rows.Count > 0);
			}

			private bool bExisteSumario()
			{
				System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbSumarios typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(typDatSetTbSumarios.tbSumarios.Rows.Count > 0);
			}
		#endregion
		#region Preferencias 
			private bool bEntrarUltimaConta(out int nIdExportador,out string strNomeConta)
			{
				 nIdExportador = 0;
				strNomeConta = "";

				bool bRetorno = false;
				if (m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMA_CONTA,false))
				{
					nIdExportador = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ULTIMA_CONTA,-1);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetExportadores.tbExportadores.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)typDatSetExportadores.tbExportadores.Rows[0];
						nIdExportador = dtrwExportador.idExportador;
						strNomeConta = dtrwExportador.marca;
						bRetorno = true;
					}
				}
				return(bRetorno);
			}

			private bool bEntrarUltimoPe(ref int nIdExportador, ref string strIdPe)
			{
				bool bRetorno = false;
				if (m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_PE,false))
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetExportadores.tbExportadores.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)typDatSetExportadores.tbExportadores.Rows[0];
						if (!dtrwExportador.IsstrUltimoPeUtilizadoNull())
							strIdPe = dtrwExportador.strUltimoPeUtilizado;
						else
							strIdPe = "";

						arlCondicaoCampo.Add("idPe");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(strIdPe);

						mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPe = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
						if (typDatSetPe.tbPEs.Rows.Count > 0)
							bRetorno = true;
					}
				}
				return(bRetorno);
			}

			private bool bEntrarUltimoDocumento(ref int nIdDocumento)
			{
				bool bRetorno = false;
				if (m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_DOCUMENTO,false))
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPe = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetPe.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPe.tbPEs.Rows[0];
						if (!dtrwPe.IsstrUltimoDocumentoUtilizadoNull())
						{
							nIdDocumento = Int32.Parse(dtrwPe.strUltimoDocumentoUtilizado);
						}
						int nIdDocumentoEntrar = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_QUAL_DOCUMENTO,0);
						if (nIdDocumentoEntrar != -1)
							nIdDocumento = nIdDocumentoEntrar;
						bRetorno = true;
					}
				}
				return(bRetorno);
			}
		#endregion
	}
}
