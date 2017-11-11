using System;
using System.Resources;
using System.Collections;

namespace mdlMensagens
{
	#region Enums
	public enum Mensagem
	{// ULTIMOID = 273
		mdlAssinatura_clsAssinatura_ApagarAssinaturas = 1,
		mdlAssinatura_frmFAssinatura_MaisDeUmaAssinaturaSelecionada = 2,
		mdlAssinatura_frmFAssinatura_NenhumaAssinaturaSelecionadaParaEdicao = 3,
		mdlAssinatura_frmFAssinatura_NenhumaAssinaturaSelecionadaParaExclusao = 4,
		mdlAssinatura_frmFAssinatura_NenhumaAssinaturaSelecionada = 5,
		mdlAssinatura_frmFAssinaturaCadEdit_NenhumaAssinaturaDigitada = 6,
		mdlBackup_clsBackup_TarefaConcluida = 7,
		mdlBancos_clsBancoExportador_ApagarBancos = 8,
		mdlBancos_clsBancoExportador_ApagarAgencias = 9,
		mdlBancos_clsBancoExportador_ApagarContas = 10,
		mdlBancos_clsBancoExportador_MaisDeUmBancoSelecionado = 11,
		mdlBancos_clsBancoExportador_MaisDeUmaAgenciaSelecionada = 12,
		mdlBancos_clsBancoExportador_MaisDeUmaContaSelecionada = 13,
		mdlBancos_frmFBancoExportador_SelecionarApenasUmBanco = 14,
		mdlBancos_frmFBancoExportador_SelecionarApenasUmaAgencia = 15,
		mdlBancos_frmFBancoExportador_SelecionarApenasUmaConta = 16,
		mdlBancos_frmFBancoExportador_SelecionarTodosItensParaEdicao = 17,
		mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarBanco = 18,
		mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarAgencia = 19,
		mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarConta = 20,
		mdlBancos_frmFBancoExportadorCadEdit_SelecionarEstado = 21,
		mdlBancos_frmFBancoExportadorCadEdit_CorrigirCEP = 22,
		mdlBancos_frmFBancoExportadorCadEdit_EditarBanco = 23,
		mdlBancos_frmFBancoExportadorCadEdit_EditarAgencia = 24,
		mdlBancos_frmFBancoExportadorCadEdit_EditarConta = 25,
		mdlBancos_clsBancoImportador_ApagarBancos = 26,
		mdlBancos_clsBancoImportador_MaisDeUmBancoSelecionado = 27,
		mdlBancos_frmFBancoImportador_SelecionarApenasUmBanco = 28,
		mdlBancos_frmFBancoImportador_NenhumBancoSelecionadoParaEdicao = 29,
		mdlBancos_frmFBancoImportador_NenhumBancoSelecionadoParaExclusao = 30,
		mdlBancos_frmFBancoImportador_NenhumBancoSelecionado = 31,
		mdlBancos_frmFBancoImportadorCadEdit_DigitarNomeBanco = 32,
		mdlBancos_frmFBancoImportadorCadEdit_SelecionarPais = 33,
		mdlBiblioteca_clsBiblioteca_ApagarPEs = 34,
		mdlBiblioteca_frmFNumeroPE_NumeroPEInvalido = 35,
		mdlBorderoCobranca_frmFBorderoCobranca_DiasInvalido = 36,
		mdlClassificacao_clsNaladi_ApagarNaladi = 37,
		mdlClassificacao_clsNcm_ApagarNcm = 38,
		mdlClassificacao_frmFClassificacao_ClassificacaoNaoSelecionadaParaEdicao = 39,
		mdlClassificacao_frmFClassificacao_ClassificacaoNaoSelecionadaParaExclusao = 40,
		mdlConsignatario_clsConsignatario_ApagarConsignatario = 41,
		mdlConsignatario_clsConsignatario_MaisDeUmConsignatarioSelecionado = 42,
		mdlConsignatario_frmFConsignatario_MaisDeUmConsignatarioSelecionado = 43,
		mdlConsignatario_frmFConsignatario_SelecionarConsignatarioParaEdicao = 44,
		mdlConsignatario_frmFConsignatario_SelecionarConsignatarioParaExclusao = 45,
		mdlConsignatario_frmFConsignatarioCadEdit_NomeConsignatarioInvalido = 46,
		mdlConsignatario_frmFConsignatarioCadEdit_SelecionarPais = 47,
		mdlContas_clsContas_ApagarExportador = 48,
		mdlContas_frmFContasCadEdit_NomeExportadorInvalido = 50,
		mdlContas_frmFContasCadEdit_NomeFantasiaInvalido = 51,
		mdlContas_frmFContasCadEdit_CNPJFormatoInvalido = 52,
		mdlContas_frmFContasCadEdit_CNPJInvalido = 53,
		mdlContas_frmFContasCadEdit_LogradouroInvalido = 54,
		mdlContas_frmFContasCadEdit_BairroInvalido = 55,
		mdlContas_frmFContasCadEdit_CidadeInvalida = 56,
		mdlContas_frmFContasCadEdit_EstadoInvalido = 57,
		mdlContas_frmFContasCadEdit_CEPFormatoInvalido = 58,
		mdlContratoCambio_clsContratoCambio_ColoqueUmBancoValido = 59,
		mdlContratoCambio_clsContratoCambio_VoceNaoPodeCriarUmCCSemNumero = 60,
		mdlContratoCambio_clsContratoCambio_VoceNaoPodeExcluirUmContratoComVinculos = 61,
		mdlContratoCambio_clsContratoCambio_NumeroContratoCambioJaExiste = 62,
		mdlContratoCambio_clsContratoCambio_SeuContratoCambioDeveTerUmValorMaioqQueZero = 63,
		mdlControladoraModulos_clsControladoraModulos_BorderoIndisponivel = 64,
		mdlCotacoes_clsCotacao_ApagarCotacoes = 65,
		mdlCriacaoDocumentos_clsCriacaoProcesso_SobreEscreverPE = 66,
		mdlCriacaoDocumentos_frmFLista_SelecionarFatura = 67,
		mdlCriacaoDocumentos_frmFNumeroPE_NumeroInvalido = 68,
		mdlEmailInterface_frmFEmailConfiguracao_SMTPInvalido = 69,
		mdlEmailInterface_frmFEmailConfiguracao_UsuarioInvalido = 70,
		mdlEmailInterface_frmFEmailConfiguracao_SenhaInvalida = 71,
		mdlEmailInterface_frmFEmailInterface_DestinatarioInvalido = 72,
		mdlEmailInterface_frmFEmailInterface_RemetenteInvalido = 73,
		mdlEnderecoEntrega_clsEnderecoEntregaImportador_ApagarEnderecos = 74,
		mdlEnderecoEntrega_clsEnderecoEntregaImportador_MaisDeUmEnderecoSelecionado = 75,
		mdlEnderecoEntrega_frmFEnderecoEntregaImportador_MaisDeUmEnderecoSelecionado = 76,
		mdlEnderecoEntrega_frmFEnderecoEntregaImportador_EnderecoNaoSelecionadoExclusao = 77,
		mdlEnderecoEntrega_frmFEnderecoEntregaImportador_EnderecoNaoSelecionadoEdicao = 78,
		mdlEnderecoEntrega_frmFEnderecoEntregaImportadorCadEdit_PaisNaoSelecionado = 79,
		mdlEsquemaPagamento_clsEsquemaPagamento_CombinacaoInvalida = 80,
		mdlEsquemaPagamento_clsEsquemaPagamento_NaoHaProdutos = 81,
		mdlIdioma_frmFIdioma_SelecionarUmIdioma = 82,
		mdlImportador_clsImportador_ApagarImportador = 83,
		mdlImportador_frmFImportador_ImportadorNaoSelecionadoEdicao = 84,
		mdlImportador_frmFImportador_ImportadorNaoSelecionadoExclusao = 85,
		mdlImportador_frmFImportadorCadEdit_PaisNaoSelecionado = 86,
		mdlIncoterm_frmFIncoterm_IncotermNaoSelecionado = 87,
		mdlMoeda_frmFMoeda_SelecionarUmaMoeda = 88,
		mdlNotaFiscal_clsNotaFiscal_ApagarNotas = 89,
		mdlNotaFiscal_clsNotaFiscal_NotaExistente = 90,
		mdlNumero_clsNumeroCotacao_NumeroExiste = 91,
		mdlNumero_frmFNumero_NumeroInvalido = 92,
		mdlPeso_frmFPeso_PesoNaoSelecionado = 93,
		mdlPreferencias_usrCtrlBackup_AguardarRestauracao = 202,
		mdlPreferencias_usrCtrlBackup_BackupTerminou = 203,
		mdlPreferencias_usrCtrlBackup_RestauracaoTerminou = 204,
		mdlProdutosGeral_clsProdutos_ExcluirCategorias = 94,
		mdlProdutosGeral_clsProdutos_ProdutosModificados = 95,
		mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_PreencherTudo = 49,
		mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_CodigoJaExiste = 96,
		mdlProdutosGeral_frmFClassificacoesTarifariasCadEdit_CodigoInvalido = 97,
		mdlProdutosGeral_frmFProdutos_TrocarDenominacaoNCM = 98,
		mdlProdutosGeral_frmFProdutos_TrocarDenominacaoNALADI = 99,
		mdlProdutosGeral_frmFProdutos_ExcluirProdutos = 100,
		mdlProdutosGeral_frmFProdutos_ExcluirNCM = 101,
		mdlProdutosGeral_frmFProdutos_ExcluirNALADI = 102,
		mdlProdutosGeral_frmFProdutos_ExcluirSemCategoria = 103,
		mdlProdutosGeral_frmFProdutos_ExcluirTodas = 104,
		mdlProdutosGeral_frmFProdutos_IncluirComoProdutoFilho = 105,
		mdlProdutosGeral_frmFProdutosCad_CodigoDoProdutoDuplicado = 106,
		mdlProdutosGeral_frmFProdutosCad_DescricaoDoProdutoDuplicada = 107,
		mdlProdutosRomaneio_clsProdutosRomaneio_ExcluirEmbalagem = 108,
		mdlProdutosRomaneio_clsProdutosRomaneio_ExcluirVolume = 109,
		mdlProdutosRomaneio_frmFEmbalagemInformacoes_ExcluirProdutosDaEmbalagem = 110,
		mdlProdutosRomaneio_frmFEmbalagemInformacoes_IdentificarEmbalagem = 111,
		mdlProdutosRomaneio_frmFEmbalagemInformacoes_EmbalagemDuplicada = 112,
		mdlProdutosRomaneio_frmFEmbalagemNova_MensagemOK = 113,
		mdlProdutosRomaneio_frmFProdutos_SoltarEmbalagens = 114,
		mdlProdutosRomaneio_frmFProdutosConteudoP1C1_MensagemOK = 115,
		mdlProdutosRomaneio_frmFVolumeInformacoes_EdicaoMultipla = 116,
		mdlProdutosRomaneio_frmFVolumeInformacoes_PerguntaGeral = 117,
		mdlProdutosRomaneio_frmFVolumeInformacoes_IdentificarEmbalagem = 118,
		mdlProdutosRomaneio_frmFVolumeInformacoes_EmbalagemDuplicada = 119,
		mdlProdutosRomaneio_frmFVolumeNovo_SetarIntervalo = 120,
		mdlProdutosRomaneio_frmFVolumeNovo_AlturaInvalida = 121,
		mdlProdutosRomaneio_frmFVolumeNovo_LarguraInvalida = 122,
		mdlProdutosRomaneio_frmFVolumeNovo_ComprimentoInvalido = 123,
		mdlProdutosRomaneio_frmFVolumeNovo_VolumeInvalido = 124,
		mdlProdutosRomaneio_frmFVolumeNovo_PesoLiquidoInvalido = 125,
		mdlProdutosRomaneio_frmFVolumeNovo_PesoBrutoInvalido = 126,
		mdlProdutosRomaneio_frmFVolumeNovo_EmbalagemDuplicada = 127,
		mdlProdutosRomaneio_frmFVolumeNovo_IntervaloInvalido = 128,
		mdlRelatoriosBase_frmRelatoriosBase_SalvarRelatorioPadraoInvalido = 130,
		mdlRelatoriosBase_frmRelatoriosBase_SairSemSalvar = 131,
		mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorio = 132,
		mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorioPadrao = 133,
		mdlRelatoriosBase_frmRelatoriosBase_ExcluirRelatorioPadraoInvalido = 134,
		mdlRelatoriosCallBack_clsRelatoriosCallBack_CondicaoPagamentoInvalida = 135,
		mdlRelatoriosCertificadosOrigem_frmFRelatoriosCertificadosOrigem_NecessitaVincular = 136,
		mdlRelatoriosFaturaComercial_frmRelatoriosFaturaComercial_TrocarClassificacaoParaNCM = 137,
		mdlRelatoriosFaturaComercial_frmRelatoriosFaturaComercial_TrocarClassificacaoParaNALADI = 138,
		mdlRelatoriosJanelas_frmFRelatoriosImagens_ApagarImagem = 139,
		mdlRelatoriosJanelas_frmFRelatoriosTrocaRelatorio_EscolherRelatorio = 140,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarNome = 141,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCPF = 142,
		mdlRegistro_frmFRegistroCategoriaACEstudante_IncorretoCPF = 143,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarEmail = 144,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarInstituicaoEnsino = 145,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCurso = 146,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarFase = 147,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarLogradouro = 148,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarBairro = 149,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCidade = 150,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarEstado = 151,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCEP = 152,
		mdlRegistro_frmFRegistroCategoriaPFExportador_InformarSetorAtividade = 153,
		mdlRegistro_frmFRegistroCategoriaPFPrestadorServico_InformarServico = 154,
		mdlRegistro_frmFRegistroCategoriaPJExportador_InformarRazaoSocial = 155,
		mdlRegistro_frmFRegistroCategoriaPJExportador_InformarNomeFantasia = 156,
		mdlRegistro_frmFRegistroCategoriaPJExportador_InformarCNPJ = 157,
		mdlRegistro_frmFRegistroCategoriaPJExportador_IncorretoCNPJ = 158,
		mdlRegistro_frmFRegistroCategoriaPJExportador_Telefone = 159,
		mdlSysAtualizacao_frmMainForm_ModuloLabel = 160,
		mdlSysAtualizacao_clsAtualizacao_AtualizacaoDisponivel = 161,
		mdlSysAtualizacao_clsAtualizacao_SemAtualizacao = 162,
		mdlSysAtualizacao_clsSysAtualizacao_Retry = 163,
		mdlSysAtualizacao_clsSysAtualizacao_DownloadError = 164,
		mdlSysAtualizacao_clsSysAtualizacao_GenericError = 165,
		mdlSysAtualizacao_clsSysAtualizacao_DBError = 166,
		mdlSysAtualizacao_frmMainForm_SucessoNoDownload = 167,
		mdlSysAtualizacao_frmMainForm_ErroNoDownload = 168,
		mdlSysAtualizacao_frmMainForm_BotaoIniciar = 169,
		mdlSysAtualizacao_frmMainForm_BotaoCancelar = 170,
		mdlSysAtualizacao_frmMainForm_BotaoFechar = 171,
		mdlSysControladoraModulos_clsSysControladoraModulos_EnviarErros = 172,
		mdlSysControladoraModulos_clsSysControladoraModulos_EnviarErrosSucesso = 173,
		mdlSysControladoraModulos_clsSysControladoraModulos_EnviarErrosErro = 174,
		mdlSysControladoraModulos_clsSysControladoraModulos_InitDownload = 175,
		mdlSysControladoraModulos_clsSysControladoraModulos_ErroAoEnviarErros = 177,
		mdlSysControladoraModulos_clsSysControladoraModulos_ResponsavelParte1 = 178,
		mdlSysControladoraModulos_clsSysControladoraModulos_ResponsavelParte2 = 179,
		mdlSysControladoraModulos_clsSysControladoraModulos_UploadSucess = 180,
		mdlSysControladoraModulos_clsSysControladoraModulos_UploadError = 181,
		mdlSysControladoraModulos_clsSysControladoraModulos_UploadTerminated = 182,
		mdlTempo_clsTempo_TempoInvalido = 183,
		mdlTempo_clsTempo_TempoInvalidoMenorQueZero = 184,
		mdlUsuarios_frmFCadastroUsuario_UsuarioJaExistente = 185,
		mdlUsuarios_frmFCadastroUsuario_RedigitacaoSenhaIncorreta = 186,
		mdlUsuarios_frmFLoginUsuarios_UsuarioSenhaIncorreta = 187,
		Siscobras_clsSiscobras_PermissaoEscritaCriacaoArquivoConfiguracao = 188,
		Siscobras_clsSiscobras_ImpossivelCriarArquivoConfiguracao = 189,
		Siscobras_clsSiscobras_CriarNovamenteArquivoConfiguracao = 190,
		Siscobras_clsSiscobras_SistemaPrecisaDefinirUmBD = 191,
		Siscobras_clsSiscobras_SistemaNaoConsegueAcessarBD = 192,
		SyscoTray_clsSyscoTray_SiscobrasCarregado = 193,
		SyscoTray_clsMain_Finalize = 194,
		BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_CrieUmContratoCambio = 195,
		BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_VincularContratoCambio = 196,
		BALLOONTIP_mdlProdutosBordero_frmFProdutosBordero_DesvincularContratoCambio = 197,
		BALLOONTIP_mdlContas_clsContas_CriarNovaConta = 198,
		BALLOONTIP_Geral_DuploClique = 199,
		BALLOONTIP_mdlBiblioteca_clsBiblioteca_CriarNovoPE = 200,
		BALLOONTIP_mdlCotacoes_clsCotacoes_CriarNovaCotacao = 201,
		mdlProdutosRomaneio_frmFProdutos_PesosRomaneioNaoBatemComFatura = 205,
		BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_CriarVolumes = 206,
		BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_AssociarProdutoFaturaVolume = 207,
		BALLOONTIP_mdlProdutosRomaneio_frmFProdutos_DepoisPrimeiraAssociacao = 208,
		BALLOONTIP_mdlImportador_clsImportador_NovoImportador = 209,
		BALLOONTIP_mdlBancos_clsBancoImportador_NovoBancoImportador = 210,
		BALLOONTIP_mdlBancos_clsBancoExportador_NovoBancoExportador = 211,
		BALLOONTIP_mdlAssinatura_clsAssinatura_NovaAssinatura = 212,
		mdlRegistro_clsRegistro_ClienteNaoCadastrado = 213,
		mdlRegistro_clsRegistro_Desconhecido = 214,
		mdlRegistro_clsRegistro_EmailNaoConfere = 215,
		mdlRegistro_clsRegistro_CodigoNaoConfere = 216,
		mdlRegistro_clsRegistro_ConectarInternetOuServidorForaAr = 217,
		mdlRegistro_clsRegistro_RequisicaoErroDesconhecido = 218,
		mdlRegistro_clsRegistro_RequisicaoClienteNaoLiberado = 219,
		mdlRegistro_clsRegistro_RequisicaoDataVencimentoIndisponivel = 220,
		mdlRegistro_clsRegistro_RequisicaoDataAtualizacao = 221,
		mdlRegistro_clsRegistro_DataComputadorIncorreta = 222,
		mdlRegistro_clsRegistro_ClienteForaValidade = 223,
		mdlRegistro_clsRegistro_MaquinaForaValidade = 224,
		mdlImportador_frmFImportadorCadEdit_NomeImportadorInvalido = 225,
		mdlProdutosRomaneio_frmFVolumeNovo_EscolhaTipoVolume = 226,
		mdlAgentes_frmFCadastroAgentes_NomeInvalido = 227,
		mdlAgentes_frmFCadastroAgentes_ContatoInvalido = 228,
		BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_VincularProdutos = 229,
		BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_SelecionarClassificacao = 230,
		BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_SelecionarNorma = 231,
		BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_InserirProduto = 232,
		mdlPreferencias_clsPreferencias_ConfiguraBancoDeDados = 233,
		BALLOONTIP_mdlProdutosLancamento_frmFProdutos_OrdenarColunas = 234,
		BALLOONTIP_mdlProdutosLancamento_frmFColunas_ComoOrdenarColunas = 235,
		BALLOONTIP_mdlProdutosLancamento_frmFProdutos_SentidoDeslocamento = 236,
		BALLOONTIP_mdlProdutosLancamento_frmFProdutos_ProdutoIntegrante = 237,
		BALLOONTIP_mdlProdutosLancamento_frmFProdutos_DeslocamentoProdutos = 238,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarDDDTelefone = 239,
		mdlRegistro_frmFRegistroCategoriaACEstudante_InformarDDDFax = 240,
		BALLOONTIP_mdlEsquemaPagamento_frmFEsquemaPagamento_InformacoesCondicoes = 241,
		BALLOONTIP_mdlEsquemaPagamento_frmFEsquemaPagamento_ModificarVisualizacao = 242,
		BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarModalidade = 243,
		BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm = 244,
		mdlBackup_clsBackup_PerguntarBackup = 245,
		BALLOONTIP_mdlNotaFiscal_frmFNotaFiscal_CriarNovaNota = 246,
		mdlNotaFiscal_frmFNotaFiscalCadEdit_SemNumero = 247,
		mdlNotaFiscal_frmFNotaFiscalCadEdit_ValorInvalido = 248,
		mdlNotaFiscal_frmFNotaFiscalCadEdit_ValorIgualAZero = 249,
		BALLOONTIP_mdlPEInfo_frmFPEInfo_Imprimir = 250,
		mdlPEInfo_clsPEInfo_FPNaoExiste = 251,
		mdlPEInfo_clsPEInfo_CONaoExiste = 252,
		mdlPEInfo_clsPEInfo_OENaoExiste = 253,
		mdlPEInfo_clsPEInfo_RMNaoExiste = 254,
		mdlPEInfo_clsPEInfo_SQNaoExiste = 255,
		mdlPEInfo_clsPEInfo_BDNaoExiste = 256,
		mdlContratoCambio_clsContratoCambio_NumeroContratoCambioSemFormatacao = 257,
		BALLOONTIP_mdlProdutosCertificadoOrigem_frmFProdutosCertificadoOrigem_Finalizar = 258,
		BALLOONTIP_mdlEmailInterface_frmFEmailInterface_VerificarConfiguracao = 259,
		BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarCategoria = 260,
		BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarProduto = 261,
		BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarNcm = 262,
		BALLOONTIP_mdlProdutosGeral_frmFProdutos_CadastrarNaladi = 263,
		BALLOONTIP_mdlProdutosGeral_frmFProdutos_MensagemGeral = 264,
		BALLOONTIP_mdlContratoCambio_frmFContratoCambio_ConfigurarContratosCambio = 265,
		mdlEsquemaPagamento_frmFValor_ValorInvalido = 266,
		mdlControladoraModulos_clsControladoraModulos_EnvioErrosSucesso = 267,
		mdlControladoraModulos_clsControladoraModulos_EnvioErrosFalha = 268,
		mdlControladoraModulos_clsControladoraModulos_ReiniciarSistemaTrocaBD = 269,
		mdlIdioma_clsPaisIdioma_PaisSelecionadoInvalido = 270,
		mdlProdutosRomaneio_frmFProdutosSimplificadoVincular_QuantidadeProdutoMaiorMaximoPermitido = 271,
		mdlRegistro_clsRegistro_Problemas_Acessar_Servidor = 272,
		mdlRegistro_clsRegistro_Erro_Atualizar_WebServices = 273
	}
	#endregion
	public class clsRepositorioMensagens
	{
		#region Atributes
			private static System.Resources.ResourceManager rmMensagens = new System.Resources.ResourceManager("mdlMensagens",System.Reflection.Assembly.GetExecutingAssembly());
		#endregion

		#region GetMensagem
			#region Enum
			// Default
			public static string GetMensagem(Mensagem enumMensagem)
			{
				return(GetMensagem(System.Globalization.CultureInfo.CurrentUICulture,enumMensagem));
			}

			// Culture
			public static string GetMensagem(System.Globalization.CultureInfo ciMensagem,Mensagem enumMensagem)
			{
				string strRetorno = "";
				System.Resources.ResourceManager rmMensagens = null;
				switch (ciMensagem.Name)
				{
					case "en":
						rmMensagens = new System.Resources.ResourceManager("mdlMensagens.MensagensEn", System.Reflection.Assembly.GetExecutingAssembly());
						break;
					default:
						rmMensagens = new System.Resources.ResourceManager("mdlMensagens.Mensagens", System.Reflection.Assembly.GetExecutingAssembly());
						break;
				}
				strRetorno = rmMensagens.GetString(enumMensagem.ToString(),System.Globalization.CultureInfo.CurrentUICulture);
				if (strRetorno == null)
				{
					rmMensagens = new System.Resources.ResourceManager("mdlMensagens.Mensagens", System.Reflection.Assembly.GetExecutingAssembly());
					strRetorno = rmMensagens.GetString(enumMensagem.ToString(),System.Globalization.CultureInfo.CurrentUICulture);
				}
				if (strRetorno == null)
				{
					strRetorno = "INDEFINIDO: Idioma: " + ciMensagem.Name + " MENSAGEM: " + enumMensagem.ToString();
				}
				return(strRetorno); 
			}
			#endregion
			#region Constantes Strings
			// Default
			public static string GetMensagem(string strMensagem)
			{
				return(GetMensagem(System.Globalization.CultureInfo.CurrentUICulture,strMensagem));
			}

			// Culture
			public static string GetMensagem(System.Globalization.CultureInfo ciMensagem, string strMensagem)
			{
				string strRetorno = "";
				System.Resources.ResourceManager rmMensagens = null;
				switch (ciMensagem.Name)
				{
					case "en":
						rmMensagens = new System.Resources.ResourceManager("mdlMensagens.MensagensEn", System.Reflection.Assembly.GetExecutingAssembly());
						break;
					default:
						rmMensagens = new System.Resources.ResourceManager("mdlMensagens.Mensagens", System.Reflection.Assembly.GetExecutingAssembly());
						break;
				}
				strRetorno = rmMensagens.GetString(strMensagem,System.Globalization.CultureInfo.CurrentUICulture);
				if (strRetorno == null)
					strRetorno = "";
				if (strRetorno == "")
				{
					strRetorno = "INDEFINIDO: Idioma: " + ciMensagem.Name + " MENSAGEM: " + strMensagem;
				}
				return(strRetorno); 
			}
			#endregion
		#endregion
	}
}
