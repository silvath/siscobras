using System;

namespace mdlRegistro
{
	#region Enums
		public enum Registro
		{
			Cancelar = 1,
			Ok = 2,
			AquisicaoDadosCadastro = 3,
			EnviarCadastro = 4,
			ClienteDadosRequisicao = 5,
			MaquinaDadosRequisicao = 6, 
			ClienteForaValidade = 7,
			MaquinaForaValidade = 8
		}

		internal enum RegistroClasse
		{
			None = 0,
			PessoaJuridicaExportador = 1,
			PessoaJuridicaPrestadorServico = 2,
			PessoaFisicaExportador = 3,
			PessoaFisicaPrestadorServico = 4,
			PessoaFisicaEstudante = 5,
			PessoaFisicaProfessor = 6
		}

		internal enum Janelas
		{
			Categoria = 1,
			Classificacao = 2,
			Usuario = 3,
			Informacoes = 4,
			OK = 5
		}

		public enum Resposta
		{
			Indefinida = 0,
			Voltar = 1,
			Cancelar = 2,
			Continuar = 3,
			Concluir = 4
		}
	#endregion
	/// <summary>
	/// Summary description for clsRegistro.
	/// </summary>
	public class clsRegistro
	{
		#region Constants 
		private const string KEYFILE = "mdlProdutosConfiguracao.dll";
		internal const string CONFIGEXE = "SiscoConfig.exe";

		private const int CATEGORIA_PESSOAJURIDICA_EXPORTADOR = 1;
		private const int CATEGORIA_PESSOAJURIDICA_PRESTADORSERVICO = 2;
		private const int CATEGORIA_PESSOAFISICA_EXPORTADOR = 1;
		private const int CATEGORIA_PESSOAFISICA_PRESTADORSERVICO = 2;
		private const int CATEGORIA_PESSOAFISICA_ESTUDANTE = 3;
		private const int CATEGORIA_PESSOAFISICA_PROFESSOR = 4;

		internal const int ERRO_CADASTROCLIENTE_CLIENTE_NAO_CADASTRADO = 0;
		internal const int ERRO_CADASTROCLIENTE_DESCONHECIDO = -1;
		internal const int ERRO_CADASTROCLIENTE_EMAIL_NAO_CONFERE = -2;
		internal const int ERRO_CADASTROCLIENTE_CODIGO_NAO_CONFERE = -3;
		internal const int ERRO_CADASTROCLIENTE_PROBLEMAS_OCORRERAM_ACESSO_SERVIDOR = -4;
		internal const int ERRO_CADASTROCLIENTE_ERRO_ATUALIZACAO_WEBSERVICES = -5;

		private const int ERRO_REQUISICAODADOS_NONE = 1;
		private const int ERRO_REQUISICAODADOS_CLIENTE_NAO_CADASTRADO = 0;
		private const int ERRO_REQUISICAODADOS_DESCONHECIDO = -1;
		private const int ERRO_REQUISICAODADOS_CLIENTE_NAO_LIBERADO = -2;
		private const int ERRO_REQUISICAODADOS_DATAVENCIMENTO_INDISPONIVEL = -3;
		private const int ERRO_REQUISICAODADOS_ATUALIZACAO_DATA_ATUALIZACAO = -4;
		#endregion
		#region Atributes
		// Dados de Funcionamento 
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		private string m_strEnderecoExecutavel;

		private clsRegistroWebService m_cls_wbsv_Registro;

		// Data Padrao 
		private System.DateTime m_dtDataPadrao = new System.DateTime(1900,1,1);

		// Silent 
		private bool bSilent = true;

		// Cliente
		private string m_strCodigoCliente = "";
		private string m_strEmailCliente = "";
		private bool m_bDadosCadastroEnviados = false;
		private string m_strKeyCliente = "";
		private System.DateTime m_dtClienteHoje;
		private System.DateTime m_dtClienteAtualizacao;
		private System.DateTime m_dtClienteVencimento;

		// TypedDataSets 
		private System.Collections.SortedList m_sortListEstadosBrasileiros = null; 
			
		// **********************************************
		// Dados de Configuracao
		// **********************************************
		private RegistroClasse m_enumRegistroClasse = RegistroClasse.None;

		// Pessoa Juridica Exportador 
		private string m_strRegistroPessoaJuridicaExportadorRazaoSocial = "";
		private string m_strRegistroPessoaJuridicaExportadorNomeFantasia = "";
		private string m_strRegistroPessoaJuridicaExportadorCNPJ = "";
		private string m_strRegistroPessoaJuridicaExportadorLogradouro = "";
		private string m_strRegistroPessoaJuridicaExportadorComplemento = "";
		private string m_strRegistroPessoaJuridicaExportadorBairro = "";
		private string m_strRegistroPessoaJuridicaExportadorCidade = "";
		private int m_nRegistroPessoaJuridicaExportadorEstado = -1;
		private string m_strRegistroPessoaJuridicaExportadorCep = "";
		private string m_strRegistroPessoaJuridicaExportadorTelefone = "";
		private string m_strRegistroPessoaJuridicaExportadorTelefoneDDD = "";
		private string m_strRegistroPessoaJuridicaExportadorFax = "";
		private string m_strRegistroPessoaJuridicaExportadorFaxDDD = "";
		private string m_strRegistroPessoaJuridicaExportadorEmail = "";
		private string m_strRegistroPessoaJuridicaExportadorSite = "";
		private string m_strRegistroPessoaJuridicaExportadorSetorAtividade = "";
		private int m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais = 0;
		private int m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios = 0;
		private int m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos = 0;
		private bool m_bRegistroPessoaJuridicaExportadorImportacoes = false;

		private string m_strRegistroPessoaJuridicaExportadorUsuarioNome = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioCPF = "";
		private bool m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino = false;
		private System.DateTime m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento;
		private int m_nRegistroPessoaJuridicaExportadorUsuarioFuncao = 0;
		private string m_strRegistroPessoaJuridicaExportadorUsuarioTelefone = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioTelefoneDDD = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioEmail = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioRamal = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioFax = "";
		private string m_strRegistroPessoaJuridicaExportadorUsuarioFaxDDD = "";

		// Pessoa Juridica Prestador Servico 
		private string m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoCNPJ = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoLogradouro = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoComplemento = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoBairro = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoCidade = "";
		private int m_nRegistroPessoaJuridicaPrestadorServicoEstado = 1;
		private string m_strRegistroPessoaJuridicaPrestadorServicoCEP = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoTelefone = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoTelefoneDDD = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoFax = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoFaxDDD = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoEmail = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoSite = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoServicos = "";
		private int m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores = 0;
		private int m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios = 0;
		private bool m_bRegistroPessoaJuridicaPrestadorServicoImportacoes = false;

		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF = "";
		private bool m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino = false;
		private System.DateTime m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento;
		private int m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao = 0;
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefoneDDD = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax = "";
		private string m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFaxDDD = "";

		// Pessoa Fisica Exportador 
		private string m_strRegistroPessoaFisicaExportadorNome = "";
		private string m_strRegistroPessoaFisicaExportadorCPF = "";
		private bool m_bRegistroPessoaFisicaExportadorSexoMasculino = false;
		private System.DateTime m_dtRegistroPessoaFisicaExportadorDataNascimento; 
		private string m_strRegistroPessoaFisicaExportadorLogradouro = "";
		private string m_strRegistroPessoaFisicaExportadorComplemento = "";
		private string m_strRegistroPessoaFisicaExportadorBairro = "";
		private string m_strRegistroPessoaFisicaExportadorCidade = "";
		private int m_nRegistroPessoaFisicaExportadorEstado = 0;
		private string m_strRegistroPessoaFisicaExportadorCEP = "";
		private string m_strRegistroPessoaFisicaExportadorTelefone = "";
		private string m_strRegistroPessoaFisicaExportadorTelefoneDDD = "";
		private string m_strRegistroPessoaFisicaExportadorFax = "";
		private string m_strRegistroPessoaFisicaExportadorFaxDDD = "";
		private string m_strRegistroPessoaFisicaExportadorEmail = "";
		private string m_strRegistroPessoaFisicaExportadorSite = "";
		private string m_strRegistroPessoaFisicaExportadorSetorAtividade = "";
		private int m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais = 0;
		private int m_nRegistroPessoaFisicaExportadorQuantidadeFuncionarios = 0;
		private int m_nRegistroPessoaFisicaExportadorExportaQuantosAnos = 0;
		private bool m_bRegistroPessoaFisicaExportadorImportacoes = false;

		// Pessoa Fisica Prestador Servico 
		private string m_strRegistroPessoaFisicaPrestadorServicoNome = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoCPF = "";
		private bool m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino = false;
		private System.DateTime m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento;
		private string m_strRegistroPessoaFisicaPrestadorServicoLogradouro = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoComplemento = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoBairro = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoCidade = "";
		private int m_nRegistroPessoaFisicaPrestadorServicoEstado = 0;
		private string m_strRegistroPessoaFisicaPrestadorServicoCEP = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoTelefone = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoTelefoneDDD = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoFax = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoFaxDDD = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoEmail = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoSite = "";
		private string m_strRegistroPessoaFisicaPrestadorServicoServicos = "";
		private int m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores = 0;
		private int m_nRegistroPessoaFisicaPrestadorServicoQuantidadeFuncionarios = 0;
		private bool m_bRegistroPessoaFisicaPrestadorServicoImportacoes = false;
					
		// Pessoa Fisica Estudante 
		private string m_strRegistroPessoaFisicaEstudanteNome = "";
		private string m_strRegistroPessoaFisicaEstudanteCPF = "";
		private bool m_bRegistroPessoaFisicaEstudanteSexoMasculino = true;
		private System.DateTime m_dtRegistroPessoaFisicaEstudanteDataNascimento;
		private string m_strRegistroPessoaFisicaEstudanteEmail = "";
		private string m_strRegistroPessoaFisicaEstudanteTelefone = "";
		private string m_strRegistroPessoaFisicaEstudanteTelefoneDDD = "";
		private string m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino = "";
		private string m_strRegistroPessoaFisicaEstudanteCurso = "";
		private string m_strRegistroPessoaFisicaEstudanteFase = "";
		private string m_strRegistroPessoaFisicaEstudanteLogradouro = "";
		private string m_strRegistroPessoaFisicaEstudanteComplemento = "";
		private string m_strRegistroPessoaFisicaEstudanteBairro = "";
		private string m_strRegistroPessoaFisicaEstudanteCidade = "";
		private int  m_nRegistroPessoaFisicaEstudanteEstado = 0;
		private string m_strRegistroPessoaFisicaEstudanteCep = "";	

		// Pessoa Fisica Professor
		private string m_strRegistroPessoaFisicaProfessorNome = "";
		private string m_strRegistroPessoaFisicaProfessorCPF = "";
		private bool m_bRegistroPessoaFisicaProfessorSexoMasculino = true;
		private System.DateTime m_dtRegistroPessoaFisicaProfessorDataNascimento;
		private string m_strRegistroPessoaFisicaProfessorEmail = "";
		private string m_strRegistroPessoaFisicaProfessorTelefone = "";
		private string m_strRegistroPessoaFisicaProfessorTelefoneDDD = "";
		private string m_strRegistroPessoaFisicaProfessorInstituicaoEnsino = "";
		private string m_strRegistroPessoaFisicaProfessorCurso = "";
		private string m_strRegistroPessoaFisicaProfessorFase = "";
		private string m_strRegistroPessoaFisicaProfessorLogradouro = "";
		private string m_strRegistroPessoaFisicaProfessorComplemento = "";
		private string m_strRegistroPessoaFisicaProfessorBairro = "";
		private string m_strRegistroPessoaFisicaProfessorCidade = "";
		private int m_nRegistroPessoaFisicaProfessorEstado = 0;
		private string m_strRegistroPessoaFisicaProfessorCep = "";	


		// Informacoes Registro Globais 
		private int m_nRegistroRealizacaoProcessosExportacao = 1;
		private string m_strRegistroRealizacaoProcessosExportacao = "";
		private int m_nRegistroConhecimentoSiscobras = 1;
		private string m_strRegistroConhecimentoSiscobras = "";
						
		// **********************************************

		private Janelas m_enumJanelaAtual = Janelas.Categoria;
		private bool m_bCancelou = false;

		private string m_strRegistroCodigo = "";
		#endregion
		#region Constructor and Destructors
		public clsRegistro(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel)
		{
			m_cls_ter_TratadorErro = cls_ter_TratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

			// Datas Padroes
			m_dtClienteHoje = m_dtDataPadrao;
			m_dtClienteAtualizacao = m_dtDataPadrao;
			m_dtClienteVencimento = m_dtDataPadrao;
			m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento = m_dtDataPadrao;
			m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento = m_dtDataPadrao;
			m_dtRegistroPessoaFisicaExportadorDataNascimento = m_dtDataPadrao;
			m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento = m_dtDataPadrao;
			m_dtRegistroPessoaFisicaEstudanteDataNascimento = m_dtDataPadrao;
			m_dtRegistroPessoaFisicaProfessorDataNascimento = m_dtDataPadrao;
			vCarregaDados();
			m_cls_wbsv_Registro = new clsRegistroWebService(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
		}
		#endregion

		#region Carregamento dos Dados
		private void vCarregaDados()
		{
			m_cls_dba_ConnectionDB.vLoadConfigurationInMemory();
			vCarregaDadosCliente();
			vCarregaDadosEnvioDadosCadastro();
			vCarregaDadosCadastro();
			vCarregaDadosKey();
			m_cls_dba_ConnectionDB.vClearConfigurationInMemory();
		}

		private void vCarregaDadosCliente()
		{
			m_strCodigoCliente = m_cls_dba_ConnectionDB.GetConfiguracao("strIdCliente","");
		}

		private void vCarregaDadosEnvioDadosCadastro()
		{
			m_bDadosCadastroEnviados = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroDadosCadastroEnviados",false);
		}

		private void vCarregaDadosCadastro()
		{
			// Loading Config from DataBase

			// Pessoa Juridica Exportador
			m_strRegistroPessoaJuridicaExportadorRazaoSocial = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorRazaoSocial","");
			m_strRegistroPessoaJuridicaExportadorNomeFantasia = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorNomeFantasia","");
			m_strRegistroPessoaJuridicaExportadorCNPJ = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorCNPJ","");
			m_strRegistroPessoaJuridicaExportadorLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorLogradouro","");
			m_strRegistroPessoaJuridicaExportadorComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorComplemento","");
			m_strRegistroPessoaJuridicaExportadorBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorBairro","");
			m_strRegistroPessoaJuridicaExportadorCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorCidade","");
			m_nRegistroPessoaJuridicaExportadorEstado = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaExportadorEstado",0);
			m_strRegistroPessoaJuridicaExportadorCep = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorCep","");
			m_strRegistroPessoaJuridicaExportadorTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorTelefone","");
			m_strRegistroPessoaJuridicaExportadorFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorFax","");
			m_strRegistroPessoaJuridicaExportadorEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorEmail","");
			m_strRegistroPessoaJuridicaExportadorSite = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorSite","");
			m_strRegistroPessoaJuridicaExportadorSetorAtividade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorSetorAtividade","");
			m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais",0);
			m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios",0);
			m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaExportadorExportaQuantosAnos",0);

			m_strRegistroPessoaJuridicaExportadorUsuarioNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioNome","");
			m_strRegistroPessoaJuridicaExportadorUsuarioCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioCPF","");
			m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioSexoMasculino",true);
			m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento",m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento);
			m_nRegistroPessoaJuridicaExportadorUsuarioFuncao = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioFuncao",0);
			m_strRegistroPessoaJuridicaExportadorUsuarioTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioTelefone","");
			m_strRegistroPessoaJuridicaExportadorUsuarioEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioEmail","");
			m_strRegistroPessoaJuridicaExportadorUsuarioRamal = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioRamal","");
			m_strRegistroPessoaJuridicaExportadorUsuarioFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioFax","");

			// Pessoa Juridica Prestador Servico
			m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoRazaoSocial","");
			m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoNomeFantasia","");
			m_strRegistroPessoaJuridicaPrestadorServicoCNPJ = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCNPJ","");
			m_strRegistroPessoaJuridicaPrestadorServicoLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoLogradouro","");
			m_strRegistroPessoaJuridicaPrestadorServicoComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoComplemento","");
			m_strRegistroPessoaJuridicaPrestadorServicoBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoBairro","");
			m_strRegistroPessoaJuridicaPrestadorServicoCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCidade","");
			m_nRegistroPessoaJuridicaPrestadorServicoEstado = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoEstado",0);
			m_strRegistroPessoaJuridicaPrestadorServicoCEP = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCEP","");
			m_strRegistroPessoaJuridicaPrestadorServicoTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoTelefone","");
			m_strRegistroPessoaJuridicaPrestadorServicoFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoFax","");
			m_strRegistroPessoaJuridicaPrestadorServicoEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoEmail","");
			m_strRegistroPessoaJuridicaPrestadorServicoSite = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoSite","");
			m_strRegistroPessoaJuridicaPrestadorServicoServicos = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoServicos","");
			m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores",0);
			m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios",0);
			m_bRegistroPessoaJuridicaPrestadorServicoImportacoes = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaJuridicaPrestadorServicoImportacoes",false);

			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioNome","");
			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF","");
			m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino",true);
			m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento",m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento);
			m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao",0);
			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone","");
			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail","");
			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal","");
			m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioFax","");

			// Pessoa Fisica Exportador 
			m_strRegistroPessoaFisicaExportadorNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorNome","");
			m_strRegistroPessoaFisicaExportadorCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorCPF","");
			m_bRegistroPessoaFisicaExportadorSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaExportadorSexoMasculino",true);
			m_dtRegistroPessoaFisicaExportadorDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaFisicaExportadorDataNascimento",m_dtDataPadrao);
			m_strRegistroPessoaFisicaExportadorLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorLogradouro","");
			m_strRegistroPessoaFisicaExportadorComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorComplemento","");
			m_strRegistroPessoaFisicaExportadorBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorBairro","");
			m_strRegistroPessoaFisicaExportadorCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorCidade","");
			m_nRegistroPessoaFisicaExportadorEstado = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaExportadorEstado",0);
			m_strRegistroPessoaFisicaExportadorCEP = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorCEP","");
			m_strRegistroPessoaFisicaExportadorTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorTelefone","");
			m_strRegistroPessoaFisicaExportadorFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorFax","");
			m_strRegistroPessoaFisicaExportadorEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorEmail","");
			m_strRegistroPessoaFisicaExportadorSite = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorSite","");
			m_strRegistroPessoaFisicaExportadorSetorAtividade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaExportadorSetorAtividade","");
			m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais",0);
			m_nRegistroPessoaFisicaExportadorQuantidadeFuncionarios = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaExportadorQuantidadeFuncionarios",0);
			m_nRegistroPessoaFisicaExportadorExportaQuantosAnos = m_cls_dba_ConnectionDB.GetConfiguracao("m_nRegistroPessoaFisicaExportadorExportaQuantosAnos",0);
			m_bRegistroPessoaFisicaExportadorImportacoes = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaExportadorImportacoes",false);

			// Pessoa Fisica Prestador Servico 
			m_strRegistroPessoaFisicaPrestadorServicoNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoNome","");
			m_strRegistroPessoaFisicaPrestadorServicoCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCPF","");
			m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaPrestadorServicoSexoMasculino",true);
			m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaFisicaPrestadorServicoDataNascimento",m_dtDataPadrao);
			m_strRegistroPessoaFisicaPrestadorServicoLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoLogradouro","");
			m_strRegistroPessoaFisicaPrestadorServicoComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoComplemento","");
			m_strRegistroPessoaFisicaPrestadorServicoBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoBairro","");
			m_strRegistroPessoaFisicaPrestadorServicoCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCidade","");
			m_nRegistroPessoaFisicaPrestadorServicoEstado = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaPrestadorServicoEstado",0);
			m_strRegistroPessoaFisicaPrestadorServicoCEP = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCEP","");
			m_strRegistroPessoaFisicaPrestadorServicoTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoTelefone","");
			m_strRegistroPessoaFisicaPrestadorServicoFax = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoFax","");
			m_strRegistroPessoaFisicaPrestadorServicoEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoEmail","");
			m_strRegistroPessoaFisicaPrestadorServicoSite = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoSite","");
			m_strRegistroPessoaFisicaPrestadorServicoServicos = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoServicos","");
			m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores",0);
			m_nRegistroPessoaFisicaPrestadorServicoQuantidadeFuncionarios = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaPrestadorServicoQuantidadeFuncionarios",0);
			m_bRegistroPessoaFisicaPrestadorServicoImportacoes = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaPrestadorServicoImportacoes",false);

			// Pessoa Fisica Estudante
			m_strRegistroPessoaFisicaEstudanteNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteNome","");
			m_strRegistroPessoaFisicaEstudanteCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteCPF","");
			m_bRegistroPessoaFisicaEstudanteSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaEstudanteSexoMasculino",true);
			m_dtRegistroPessoaFisicaEstudanteDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaFisicaEstudanteDataNascimento",m_dtRegistroPessoaFisicaEstudanteDataNascimento);
			m_strRegistroPessoaFisicaEstudanteEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteEmail","");
			m_strRegistroPessoaFisicaEstudanteTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteTelefone","");
			m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteInstituicaoEnsino","");
			m_strRegistroPessoaFisicaEstudanteCurso = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteCurso","");
			m_strRegistroPessoaFisicaEstudanteFase = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteFase","");
			m_strRegistroPessoaFisicaEstudanteLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteLogradouro","");
			m_strRegistroPessoaFisicaEstudanteComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteComplemento","");
			m_strRegistroPessoaFisicaEstudanteBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteBairro","");
			m_strRegistroPessoaFisicaEstudanteCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteCidade","");
			m_nRegistroPessoaFisicaEstudanteEstado = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteEstado",0);
			m_strRegistroPessoaFisicaEstudanteCep = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaEstudanteCep","");

			// Pessoa Fisica Professor
			m_strRegistroPessoaFisicaProfessorNome = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorNome","");
			m_strRegistroPessoaFisicaProfessorCPF = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorCPF","");
			m_bRegistroPessoaFisicaProfessorSexoMasculino = m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaProfessorSexoMasculino",true);
			m_dtRegistroPessoaFisicaProfessorDataNascimento = m_cls_dba_ConnectionDB.GetConfiguracao("dtRegistroPessoaFisicaProfessorDataNascimento",m_dtRegistroPessoaFisicaProfessorDataNascimento);
			m_strRegistroPessoaFisicaProfessorEmail = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorEmail","");
			m_strRegistroPessoaFisicaProfessorTelefone = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorTelefone","");
			m_strRegistroPessoaFisicaProfessorInstituicaoEnsino = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorInstituicaoEnsino","");
			m_strRegistroPessoaFisicaProfessorCurso = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorCurso","");
			m_strRegistroPessoaFisicaProfessorFase = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorFase","");
			m_strRegistroPessoaFisicaProfessorLogradouro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorLogradouro","");
			m_strRegistroPessoaFisicaProfessorComplemento = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorComplemento","");
			m_strRegistroPessoaFisicaProfessorBairro = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorBairro","");
			m_strRegistroPessoaFisicaProfessorCidade = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorCidade","");
			m_nRegistroPessoaFisicaProfessorEstado = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaProfessorEstado",0);
			m_strRegistroPessoaFisicaProfessorCep = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaProfessorCep","");

			// Informacoes a Todos
			m_nRegistroRealizacaoProcessosExportacao = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroRealizacaoProcessosExportacao",m_nRegistroRealizacaoProcessosExportacao);
			m_strRegistroRealizacaoProcessosExportacao = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroRealizacaoProcessosExportacao","");
			m_nRegistroConhecimentoSiscobras = m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroConhecimentoSiscobras",m_nRegistroRealizacaoProcessosExportacao);
			m_strRegistroConhecimentoSiscobras = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroConhecimentoSiscobras","");

			// Classe Registro
			int nRegistroCategoria = m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroCategoria",0);
			m_enumRegistroClasse = (RegistroClasse)nRegistroCategoria;
			vRefreshEmailCliente();
		}

		private void vCarregaDadosKey()
		{
			m_strKeyCliente = m_cls_dba_ConnectionDB.GetConfiguracao("strKey","");
		}
		#endregion
		#region Salvamento dos Dados 
		private void vSalvaDados()
		{
			vSalvaDadosCliente();
			vSalvaDadosEnvioDadosCadastro();
			vSalvaDadosCadastro();
			vSalvaDadosKey();
		}

		private void vSalvaDadosCliente()
		{
			m_cls_dba_ConnectionDB.SetConfiguracao("strIdCliente",m_strCodigoCliente);
		}

		private void vSalvaDadosEnvioDadosCadastro()
		{
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroDadosCadastroEnviados",m_bDadosCadastroEnviados.ToString());
		}

		private void vSalvaDadosCadastro()
		{
			m_cls_dba_ConnectionDB.vLoadConfigurationInMemory();

			// Saving Config to DataBase
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroCategoria",((int)m_enumRegistroClasse).ToString());

			// Pessoa Juridica Exportador
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorRazaoSocial",m_strRegistroPessoaJuridicaExportadorRazaoSocial);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorNomeFantasia",m_strRegistroPessoaJuridicaExportadorNomeFantasia);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorCNPJ",m_strRegistroPessoaJuridicaExportadorCNPJ);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorLogradouro",m_strRegistroPessoaJuridicaExportadorLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorComplemento",m_strRegistroPessoaJuridicaExportadorComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorBairro",m_strRegistroPessoaJuridicaExportadorBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorCidade",m_strRegistroPessoaJuridicaExportadorCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaExportadorEstado",m_nRegistroPessoaJuridicaExportadorEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorCep",m_strRegistroPessoaJuridicaExportadorCep);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorTelefone",m_strRegistroPessoaJuridicaExportadorTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorFax",m_strRegistroPessoaJuridicaExportadorFax);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorEmail",m_strRegistroPessoaJuridicaExportadorEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorSite",m_strRegistroPessoaJuridicaExportadorSite);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorSetorAtividade",m_strRegistroPessoaJuridicaExportadorSetorAtividade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais",m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios",m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaExportadorExportaQuantosAnos",m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos.ToString());

			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioNome",m_strRegistroPessoaJuridicaExportadorUsuarioNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioCPF",m_strRegistroPessoaJuridicaExportadorUsuarioCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino",m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento",m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaExportadorUsuarioFuncao",m_nRegistroPessoaJuridicaExportadorUsuarioFuncao.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioTelefone",m_strRegistroPessoaJuridicaExportadorUsuarioTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioEmail",m_strRegistroPessoaJuridicaExportadorUsuarioEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioRamal",m_strRegistroPessoaJuridicaExportadorUsuarioRamal);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaExportadorUsuarioFax",m_strRegistroPessoaJuridicaExportadorUsuarioFax);

			// Pessoa Juridica Prestador Servico
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoRazaoSocial",m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoNomeFantasia",m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCNPJ",m_strRegistroPessoaJuridicaPrestadorServicoCNPJ);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoLogradouro",m_strRegistroPessoaJuridicaPrestadorServicoLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoComplemento",m_strRegistroPessoaJuridicaPrestadorServicoComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoBairro",m_strRegistroPessoaJuridicaPrestadorServicoBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCidade",m_strRegistroPessoaJuridicaPrestadorServicoCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoEstado",m_nRegistroPessoaJuridicaPrestadorServicoEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoCEP",m_strRegistroPessoaJuridicaPrestadorServicoCEP);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoTelefone",m_strRegistroPessoaJuridicaPrestadorServicoTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoFax",m_strRegistroPessoaJuridicaPrestadorServicoFax);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoEmail",m_strRegistroPessoaJuridicaPrestadorServicoEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoSite",m_strRegistroPessoaJuridicaPrestadorServicoSite);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoServicos",m_strRegistroPessoaJuridicaPrestadorServicoServicos);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores",m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios",m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaJuridicaPrestadorServicoImportacoes",m_bRegistroPessoaJuridicaPrestadorServicoImportacoes.ToString());

			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioNome",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino",m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento",m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao",m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaJuridicaPrestadorServicoUsuarioFax",m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax);

			// Pessoa Fisica Exportador 
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorNome",m_strRegistroPessoaFisicaExportadorNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorCPF",m_strRegistroPessoaFisicaExportadorCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaFisicaExportadorSexoMasculino",m_bRegistroPessoaFisicaExportadorSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaFisicaExportadorDataNascimento",m_dtRegistroPessoaFisicaExportadorDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorLogradouro",m_strRegistroPessoaFisicaExportadorLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorComplemento",m_strRegistroPessoaFisicaExportadorComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorBairro",m_strRegistroPessoaFisicaExportadorBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorCidade",m_strRegistroPessoaFisicaExportadorCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaExportadorEstado",m_nRegistroPessoaFisicaExportadorEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorCEP",m_strRegistroPessoaFisicaExportadorCEP);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorTelefone",m_strRegistroPessoaFisicaExportadorTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorFax",m_strRegistroPessoaFisicaExportadorFax);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorEmail",m_strRegistroPessoaFisicaExportadorEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorSite",m_strRegistroPessoaFisicaExportadorSite);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaExportadorSetorAtividade",m_strRegistroPessoaFisicaExportadorSetorAtividade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais",m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaExportadorQuantidadeFuncionarios",m_nRegistroPessoaFisicaExportadorQuantidadeFuncionarios.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("m_nRegistroPessoaFisicaExportadorExportaQuantosAnos",m_nRegistroPessoaFisicaExportadorExportaQuantosAnos.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaFisicaExportadorImportacoes",m_bRegistroPessoaFisicaExportadorImportacoes.ToString());

			// Pessoa Fisica Prestador Servico 
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoNome",m_strRegistroPessoaFisicaPrestadorServicoNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCPF",m_strRegistroPessoaFisicaPrestadorServicoCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaFisicaPrestadorServicoSexoMasculino",m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaFisicaPrestadorServicoDataNascimento",m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoLogradouro",m_strRegistroPessoaFisicaPrestadorServicoLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoComplemento",m_strRegistroPessoaFisicaPrestadorServicoComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoBairro",m_strRegistroPessoaFisicaPrestadorServicoBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCidade",m_strRegistroPessoaFisicaPrestadorServicoCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaPrestadorServicoEstado",m_nRegistroPessoaFisicaPrestadorServicoEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoCEP",m_strRegistroPessoaFisicaPrestadorServicoCEP);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoTelefone",m_strRegistroPessoaFisicaPrestadorServicoTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoFax",m_strRegistroPessoaFisicaPrestadorServicoFax);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoEmail",m_strRegistroPessoaFisicaPrestadorServicoEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaPrestadorServicoSite",m_strRegistroPessoaFisicaPrestadorServicoSite);
			m_cls_dba_ConnectionDB.GetConfiguracao("strRegistroPessoaFisicaPrestadorServicoServicos",m_strRegistroPessoaFisicaPrestadorServicoServicos); 
			m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores",m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores);  
			m_cls_dba_ConnectionDB.GetConfiguracao("nRegistroPessoaFisicaPrestadorServicoQuantidadeFuncionarios",m_nRegistroPessoaFisicaPrestadorServicoQuantidadeFuncionarios); 
			m_cls_dba_ConnectionDB.GetConfiguracao("bRegistroPessoaFisicaPrestadorServicoImportacoes",m_bRegistroPessoaFisicaPrestadorServicoImportacoes ); 

			// Pessoa Fisica Estudante
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteNome",m_strRegistroPessoaFisicaEstudanteNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteCPF",m_strRegistroPessoaFisicaEstudanteCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaFisicaEstudanteSexoMasculino",m_bRegistroPessoaFisicaEstudanteSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaFisicaEstudanteDataNascimento",m_dtRegistroPessoaFisicaEstudanteDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteEmail",m_strRegistroPessoaFisicaEstudanteEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteTelefone",m_strRegistroPessoaFisicaEstudanteTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteInstituicaoEnsino",m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteCurso",m_strRegistroPessoaFisicaEstudanteCurso);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteFase",m_strRegistroPessoaFisicaEstudanteFase);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteLogradouro",m_strRegistroPessoaFisicaEstudanteLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteComplemento",m_strRegistroPessoaFisicaEstudanteComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteBairro",m_strRegistroPessoaFisicaEstudanteBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteCidade",m_strRegistroPessoaFisicaEstudanteCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaEstudanteEstado",m_nRegistroPessoaFisicaEstudanteEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaEstudanteCep",m_strRegistroPessoaFisicaEstudanteCep);

			// Pessoa Fisica Professor
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorNome",m_strRegistroPessoaFisicaProfessorNome);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorCPF",m_strRegistroPessoaFisicaProfessorCPF);
			m_cls_dba_ConnectionDB.SetConfiguracao("bRegistroPessoaFisicaProfessorSexoMasculino",m_bRegistroPessoaFisicaProfessorSexoMasculino.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("dtRegistroPessoaFisicaProfessorDataNascimento",m_dtRegistroPessoaFisicaProfessorDataNascimento.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorEmail",m_strRegistroPessoaFisicaProfessorEmail);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorTelefone",m_strRegistroPessoaFisicaProfessorTelefone);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorInstituicaoEnsino",m_strRegistroPessoaFisicaProfessorInstituicaoEnsino);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorCurso",m_strRegistroPessoaFisicaProfessorCurso);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorFase",m_strRegistroPessoaFisicaProfessorFase);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorLogradouro",m_strRegistroPessoaFisicaProfessorLogradouro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorComplemento",m_strRegistroPessoaFisicaProfessorComplemento);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorBairro",m_strRegistroPessoaFisicaProfessorBairro);
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorCidade",m_strRegistroPessoaFisicaProfessorCidade);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroPessoaFisicaProfessorEstado",m_nRegistroPessoaFisicaProfessorEstado.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroPessoaFisicaProfessorCep",m_strRegistroPessoaFisicaProfessorCep);

			// Informacoes a Todos
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroRealizacaoProcessosExportacao",m_nRegistroRealizacaoProcessosExportacao.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroRealizacaoProcessosExportacao",m_strRegistroRealizacaoProcessosExportacao);
			m_cls_dba_ConnectionDB.SetConfiguracao("nRegistroConhecimentoSiscobras",m_nRegistroConhecimentoSiscobras.ToString());
			m_cls_dba_ConnectionDB.SetConfiguracao("strRegistroConhecimentoSiscobras",m_strRegistroConhecimentoSiscobras);

			m_cls_dba_ConnectionDB.vSaveConfigurationFromMemory();
		}

		private void vSalvaDadosKey()
		{
			m_cls_dba_ConnectionDB.SetConfiguracao("strKey",m_strKeyCliente);
		}
		#endregion

		#region Registro
		public bool bRegistroOK()
		{
//			//Unlock
//			if (System.Windows.Forms.Keys.Control == (System.Windows.Forms.Form.ModifierKeys & System.Windows.Forms.Keys.Control))
//				return(true);

			bool bRetorno = false;
			bool bCancel = false;
			Registro enumRegistro;
			Resposta enumResposta;
			while (((enumRegistro = enumRegistroOK()) != Registro.Ok) && (!bCancel))
			{
				switch(enumRegistro)
				{
						// Cadastro
					case Registro.AquisicaoDadosCadastro:
						if (!ShowDialogCadastro())
						{
							bCancel = true;
						}
						break;

						// Enviando os Dados do Cadastro
					case Registro.EnviarCadastro:
						enumResposta = ShowDialogEnvioDadosCadastro();
					switch(enumResposta)
					{
						case Resposta.Voltar:
							m_strCodigoCliente = "";
							break;
						case Resposta.Cancelar:
							bCancel = true;
							break;
						case Resposta.Continuar:
							m_bDadosCadastroEnviados = true;
							vSalvaDadosEnvioDadosCadastro();
							vCadastraPrimeiraContaExportadora();
							break;
					}
						break;
						// Requisicao Dados Cliente
					case Registro.ClienteDadosRequisicao:
						enumResposta = ShowDialogRequisicaoDadosWebService();
					switch(enumResposta)
					{
						case Resposta.Voltar:
							break;
						case Resposta.Cancelar:
							bCancel = true;
							break;
						case Resposta.Continuar:
							break;
					}
						break;

						// Requisicao Dados Maquina
					case Registro.MaquinaDadosRequisicao:
						enumResposta = ShowDialogRequisicaoDadosWebService();
					switch(enumResposta)
					{
						case Resposta.Voltar:
							break;
						case Resposta.Cancelar:
							bCancel = true;
							break;
						case Resposta.Continuar:
							break;
					}
						break;
						// Cliente Fora Validade
					case Registro.ClienteForaValidade:
						enumResposta = ShowDialogRequisicaoDadosWebService();
					switch(enumResposta)
					{
						case Resposta.Voltar:
							break;
						case Resposta.Cancelar:
							bCancel = true;
							break;
						case Resposta.Continuar:
							break;
					}
						break;

						// Maquina Fora Validade
					case Registro.MaquinaForaValidade:
						enumResposta = ShowDialogRequisicaoDadosWebService();
					switch(enumResposta)
					{
						case Resposta.Voltar:
							break;
						case Resposta.Cancelar:
							bCancel = true;
							break;
						case Resposta.Continuar:
							break;
					}
						break;
						// Saida Inesperada
					case Registro.Cancelar:
						bCancel = true;
						break;
				}
			}
			bRetorno = (enumRegistro == Registro.Ok);
			return(bRetorno);
		}

		public Registro enumRegistroOK()
		{
			Registro enumRetorno = Registro.Cancelar;
			if (bDadosCadastroJaAdquiridos())
			{
				if (bCadastroJaEnviado())
				{
					if (bClienteDadosOk())
					{
						if (bMaquinaDadosOk())
						{
							if (bClienteDentroValidade())
							{
								if (bMaquinaDentroValidade())
								{
									enumRetorno = Registro.Ok;
								}
								else
								{
									enumRetorno = Registro.MaquinaForaValidade;
								}
							}
							else
							{
								enumRetorno = Registro.ClienteForaValidade;
							}
						}
						else
						{
							enumRetorno = Registro.MaquinaDadosRequisicao;
						}
					}
					else
					{
						vMaquinaInvalida();
						enumRetorno = Registro.ClienteDadosRequisicao;
					}
				}
				else
				{
					enumRetorno = Registro.EnviarCadastro;
				}
			}
			else
			{
				enumRetorno = Registro.AquisicaoDadosCadastro;
			}
			return(enumRetorno);
		}
		#endregion

		#region Cadastro
		private bool bDadosCadastroJaAdquiridos()
		{
			bool bRetorno = false;
			if (m_enumRegistroClasse != RegistroClasse.None)
			{
				if (m_strCodigoCliente != "")
				{
					bRetorno = true;
				}
			}
			return(bRetorno);
		}
		#endregion
		#region Criacao Primeira Conta Exportadora
		private int nRetornNextIdExportador()
		{
			int nRetorno = 1;
			mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(null,null,null,null,null);
			while (typDatSetExportadores.tbExportadores.FindByidExportador(nRetorno) != null)
				nRetorno++;
			return(nRetorno);
		}

		private void vCadastraPrimeiraContaExportadora()
		{
			int nIdExportador = nRetornNextIdExportador();
			if (nIdExportador == 1)
			{
				switch(m_enumRegistroClasse)
				{
					case RegistroClasse.PessoaJuridicaExportador:
						vCadastraPrimeiraContaExportadora(nIdExportador,m_strRegistroPessoaJuridicaExportadorRazaoSocial,m_strRegistroPessoaJuridicaExportadorNomeFantasia,m_strRegistroPessoaJuridicaExportadorLogradouro,m_strRegistroPessoaJuridicaExportadorTelefone,m_strRegistroPessoaJuridicaExportadorFax,"",m_strRegistroPessoaJuridicaExportadorEmail,m_strRegistroPessoaJuridicaExportadorSite,m_strRegistroPessoaJuridicaExportadorBairro,m_strRegistroPessoaJuridicaExportadorCidade,m_strRegistroPessoaJuridicaExportadorCep,m_nRegistroPessoaJuridicaExportadorEstado,m_strRegistroPessoaJuridicaExportadorCNPJ);
						break;
					case RegistroClasse.PessoaJuridicaPrestadorServico:
						vCadastraPrimeiraContaExportadora(nIdExportador,m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial,m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia,m_strRegistroPessoaJuridicaPrestadorServicoLogradouro,m_strRegistroPessoaJuridicaPrestadorServicoTelefone,m_strRegistroPessoaJuridicaPrestadorServicoFax,"",m_strRegistroPessoaJuridicaPrestadorServicoEmail,m_strRegistroPessoaJuridicaPrestadorServicoSite,m_strRegistroPessoaJuridicaPrestadorServicoBairro,m_strRegistroPessoaJuridicaPrestadorServicoCidade,m_strRegistroPessoaJuridicaPrestadorServicoCEP,m_nRegistroPessoaJuridicaPrestadorServicoEstado,m_strRegistroPessoaJuridicaPrestadorServicoCNPJ);
						break;
				}
			}
		}

		private void vCadastraPrimeiraContaExportadora(int nIdExportador,string strNome,string strMarca,string strEndereco,string strTelefone,string strFax,string strCelular,string strEmail,string strSite,string strBairro,string strCidade,string strCep,int nEstado,string strCnpj)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(null,null,null,null,null);
			mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwExportador = typDatSetExportadores.tbExportadores.NewtbExportadoresRow();

			dtrwExportador.idExportador = nIdExportador;
			dtrwExportador.nmEmp = strNome;
			dtrwExportador.marca = strMarca;
			dtrwExportador.mstrEndEmp = strEndereco;
			dtrwExportador.mstrTelEmp = strTelefone;
			dtrwExportador.mstrFaxEmp = strFax;
			dtrwExportador.mstrTel2Emp = strFax; 
			dtrwExportador.mstrCelEmp = strCelular;
			dtrwExportador.mstrEmailEmp = strEmail;
			dtrwExportador.mstrSiteEmp = strSite;
			dtrwExportador.mstrBairroEmp = strBairro;
			dtrwExportador.mstrCidadeEmp = strCidade;
			dtrwExportador.mstrCepEmp = strCep;
			dtrwExportador.idEstadoEmp = nEstado;
			dtrwExportador.mstrCnpj = strCnpj;

			// Default dos Relatorios 
			dtrwExportador.idRelatorioBordero = 0;
			dtrwExportador.idRelatorioCertificadoOrigemAladiAce39 = 0;
			dtrwExportador.idRelatorioCertificadoOrigemAladiAptr04 = 0;
			dtrwExportador.idRelatorioCertificadoOrigemAnexoIII = 0;
			dtrwExportador.idRelatorioCertificadoOrigemComum = 0;
			dtrwExportador.idRelatorioCertificadoOrigemMercosul = 0;
			dtrwExportador.idRelatorioCertificadoOrigemMercosulBolivia = 0;
			dtrwExportador.idRelatorioCertificadoOrigemMercosulChile = 0;
			dtrwExportador.idRelatorioCotacao = 0;
			dtrwExportador.idRelatorioDocBancInstrucaoDeRemessa = 0;
			dtrwExportador.idRelatorioFaturaComercial = 0;
			dtrwExportador.idRelatorioFaturaProforma = 0;
			dtrwExportador.idRelatorioFaturaProforma = 0;
			dtrwExportador.idRelatorioInstrucaoEmbarque = 0;
			dtrwExportador.idRelatorioRomaneio = 0;
			dtrwExportador.idRelatorioSaque = 0;

			// Opcoes Padrao dos novos Exportadores
			dtrwExportador.colunaCodigo = 1;
			dtrwExportador.tamanhoColunaCodigo = 60;
			dtrwExportador.colunaQuantidade = 2;
			dtrwExportador.tamanhoColunaQuantidade = 60;
			dtrwExportador.colunaDescricao = 3;
			dtrwExportador.tamanhoColunaDescricao = 250;
			dtrwExportador.colunaUnidade = 4;
			dtrwExportador.tamanhoColunaUnidade = 50;
			dtrwExportador.colunaPrecoUnitario = 5;
			dtrwExportador.tamanhoColunaPrecoUnitario = 60;
			dtrwExportador.colunaDescricaoLinguaEstrangeira = 6;
			dtrwExportador.tamanhoColunaDescricaoLinguaEstrangeira = 150;

			dtrwExportador.nColunaDetalharProdutos = 0;
			dtrwExportador.nTamanhoColunaDetalharProdutos = 0;
			dtrwExportador.nColunaOrdemLancamento = 0;
			dtrwExportador.nTamanhoColunaOrdemLancamento = 0;

			// Padroes
			dtrwExportador.formatoNumero = "PPP.MMDD.NNN";
			dtrwExportador.bProdutosVisualizarNcm = true;
			dtrwExportador.bProdutosVisualizarNaladi = true;

			typDatSetExportadores.tbExportadores.AddtbExportadoresRow(dtrwExportador);
			m_cls_dba_ConnectionDB.SetTbExportadores(typDatSetExportadores);
		}
		#endregion
		#region Envio Dados Cadastro
		private bool bCadastroJaEnviado()
		{
			return(m_bDadosCadastroEnviados);
		}
		
		private bool bEnviaDadosCadastroWebService()
		{
			bool bRetorno = false;
			// Verificando se esta conectado a internet 
			if (mdlInet.clsPing.bEstaConectado())
			{
				int nResposta = 0;
				System.DateTime dtPrimeiraExportacao;
				System.DateTime dtAntiga = new DateTime(1800,1,1);
				clsRegistroWebService cls_webService_Registro =  new clsRegistroWebService(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				switch(m_enumRegistroClasse)
				{
					case RegistroClasse.PessoaJuridicaExportador:
						dtPrimeiraExportacao = new System.DateTime(System.DateTime.Now.Year - m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos,1,1);
						nResposta = cls_webService_Registro.nCadastraPessoaJuridica(CATEGORIA_PESSOAJURIDICA_EXPORTADOR,m_strCodigoCliente,m_strRegistroPessoaJuridicaExportadorRazaoSocial,m_strRegistroPessoaJuridicaExportadorNomeFantasia,m_strRegistroPessoaJuridicaExportadorEmail,m_strRegistroPessoaJuridicaExportadorSite,-1,m_strRegistroPessoaJuridicaExportadorSetorAtividade,m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais,m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios,dtPrimeiraExportacao,m_bRegistroPessoaJuridicaExportadorImportacoes,m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras,m_strRegistroPessoaJuridicaExportadorUsuarioNome,m_nRegistroPessoaJuridicaExportadorUsuarioFuncao,m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino,m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento,true,dtAntiga,m_strRegistroPessoaJuridicaExportadorUsuarioRamal,m_strRegistroPessoaJuridicaExportadorUsuarioEmail,-1,-1,m_strRegistroPessoaJuridicaExportadorCNPJ,m_strRegistroPessoaJuridicaExportadorLogradouro,m_strRegistroPessoaJuridicaExportadorComplemento,m_strRegistroPessoaJuridicaExportadorBairro,m_strRegistroPessoaJuridicaExportadorCep,m_strRegistroPessoaJuridicaExportadorCidade,m_nRegistroPessoaJuridicaExportadorEstado,m_strRegistroPessoaJuridicaExportadorEmail,m_strRegistroPessoaJuridicaExportadorSite,m_nRegistroPessoaJuridicaExportadorEstado,m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios,m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais,m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais,false,"(" + m_strRegistroPessoaJuridicaExportadorFaxDDD + ")"+ m_strRegistroPessoaJuridicaExportadorFax,"(" + m_strRegistroPessoaJuridicaExportadorTelefoneDDD + ")" + m_strRegistroPessoaJuridicaExportadorTelefone);
						break;
					case RegistroClasse.PessoaJuridicaPrestadorServico:
						nResposta = cls_webService_Registro.nCadastraPessoaJuridica(CATEGORIA_PESSOAJURIDICA_PRESTADORSERVICO,m_strCodigoCliente,m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial,m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia,m_strRegistroPessoaJuridicaPrestadorServicoEmail,m_strRegistroPessoaJuridicaPrestadorServicoSite,-1,m_strRegistroPessoaJuridicaPrestadorServicoServicos,m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores,m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios,dtAntiga,m_bRegistroPessoaJuridicaPrestadorServicoImportacoes,m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras,m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome,m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao,m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino,m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento,true,dtAntiga,m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal,m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail,-1,-1,m_strRegistroPessoaJuridicaPrestadorServicoCNPJ,m_strRegistroPessoaJuridicaPrestadorServicoLogradouro,m_strRegistroPessoaJuridicaPrestadorServicoComplemento,m_strRegistroPessoaJuridicaPrestadorServicoBairro,m_strRegistroPessoaJuridicaPrestadorServicoCEP,m_strRegistroPessoaJuridicaPrestadorServicoCidade,m_nRegistroPessoaJuridicaPrestadorServicoEstado,m_strRegistroPessoaJuridicaPrestadorServicoEmail,m_strRegistroPessoaJuridicaPrestadorServicoSite,m_nRegistroPessoaJuridicaPrestadorServicoEstado,m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios,-1,-1,false,"(" + m_strRegistroPessoaJuridicaPrestadorServicoFaxDDD + ")"+  m_strRegistroPessoaJuridicaPrestadorServicoFax,"(" + m_strRegistroPessoaJuridicaPrestadorServicoTelefoneDDD + ")"+ m_strRegistroPessoaJuridicaPrestadorServicoTelefone);
						break;
					case RegistroClasse.PessoaFisicaExportador:
						dtPrimeiraExportacao = new System.DateTime(System.DateTime.Now.Year - m_nRegistroPessoaFisicaExportadorExportaQuantosAnos,1,1);
						nResposta = cls_webService_Registro.nCadastraPessoaFisica(CATEGORIA_PESSOAFISICA_EXPORTADOR,m_strCodigoCliente,m_strRegistroPessoaFisicaExportadorNome,m_strRegistroPessoaFisicaExportadorCPF,m_bRegistroPessoaFisicaExportadorSexoMasculino,m_dtRegistroPessoaFisicaExportadorDataNascimento,m_strRegistroPessoaFisicaExportadorLogradouro,m_strRegistroPessoaFisicaExportadorComplemento,m_strRegistroPessoaFisicaExportadorBairro,m_strRegistroPessoaFisicaExportadorCidade,m_nRegistroPessoaFisicaExportadorEstado,m_strRegistroPessoaFisicaExportadorCEP,"(" + m_strRegistroPessoaFisicaExportadorTelefoneDDD + ")" + m_strRegistroPessoaFisicaExportadorTelefone,"(" + m_strRegistroPessoaFisicaExportadorFaxDDD + ")" + m_strRegistroPessoaFisicaExportadorFax,m_strRegistroPessoaFisicaExportadorEmail,m_strRegistroPessoaFisicaExportadorSite,-1,m_strRegistroPessoaFisicaExportadorSetorAtividade,m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais,dtPrimeiraExportacao,m_bRegistroPessoaFisicaExportadorImportacoes,"","","",m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras);
						break;
					case RegistroClasse.PessoaFisicaPrestadorServico:
						nResposta = cls_webService_Registro.nCadastraPessoaFisica(CATEGORIA_PESSOAFISICA_PRESTADORSERVICO,m_strCodigoCliente,m_strRegistroPessoaFisicaPrestadorServicoNome,m_strRegistroPessoaFisicaPrestadorServicoCPF,m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino,m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento,m_strRegistroPessoaFisicaPrestadorServicoLogradouro,m_strRegistroPessoaFisicaPrestadorServicoComplemento,m_strRegistroPessoaFisicaPrestadorServicoBairro,m_strRegistroPessoaFisicaPrestadorServicoCidade,m_nRegistroPessoaFisicaPrestadorServicoEstado,m_strRegistroPessoaFisicaPrestadorServicoCEP,"(" + m_strRegistroPessoaFisicaPrestadorServicoTelefoneDDD + ")" + m_strRegistroPessoaFisicaPrestadorServicoTelefone,"(" + m_strRegistroPessoaFisicaPrestadorServicoFaxDDD + ")" + m_strRegistroPessoaFisicaPrestadorServicoFax,m_strRegistroPessoaFisicaPrestadorServicoEmail,m_strRegistroPessoaFisicaPrestadorServicoSite,-1,m_strRegistroPessoaFisicaPrestadorServicoServicos,m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores,System.DateTime.Now,m_bRegistroPessoaJuridicaPrestadorServicoImportacoes,"","","",m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras);
						break;
					case RegistroClasse.PessoaFisicaEstudante:
						nResposta = cls_webService_Registro.nCadastraPessoaFisica(CATEGORIA_PESSOAFISICA_ESTUDANTE,m_strCodigoCliente,m_strRegistroPessoaFisicaEstudanteNome,m_strRegistroPessoaFisicaEstudanteCPF,m_bRegistroPessoaFisicaEstudanteSexoMasculino,m_dtRegistroPessoaFisicaEstudanteDataNascimento,m_strRegistroPessoaFisicaEstudanteLogradouro,m_strRegistroPessoaFisicaEstudanteComplemento,m_strRegistroPessoaFisicaEstudanteBairro,m_strRegistroPessoaFisicaEstudanteCidade,m_nRegistroPessoaFisicaEstudanteEstado,m_strRegistroPessoaFisicaEstudanteCep,"(" + m_strRegistroPessoaFisicaEstudanteTelefoneDDD + ")" + m_strRegistroPessoaFisicaEstudanteTelefone,"",m_strRegistroPessoaFisicaEstudanteEmail,"",-1,"",-1,System.DateTime.Now,false,m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino,m_strRegistroPessoaFisicaEstudanteCurso,m_strRegistroPessoaFisicaEstudanteFase,m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras);
						break;
					case RegistroClasse.PessoaFisicaProfessor:
						nResposta = cls_webService_Registro.nCadastraPessoaFisica(CATEGORIA_PESSOAFISICA_PROFESSOR,m_strCodigoCliente,m_strRegistroPessoaFisicaProfessorNome,m_strRegistroPessoaFisicaProfessorCPF,m_bRegistroPessoaFisicaProfessorSexoMasculino,m_dtRegistroPessoaFisicaProfessorDataNascimento,m_strRegistroPessoaFisicaProfessorLogradouro,m_strRegistroPessoaFisicaProfessorComplemento,m_strRegistroPessoaFisicaProfessorBairro,m_strRegistroPessoaFisicaProfessorCidade,m_nRegistroPessoaFisicaProfessorEstado,m_strRegistroPessoaFisicaProfessorCep,"(" + m_strRegistroPessoaFisicaProfessorTelefoneDDD + ")" + m_strRegistroPessoaFisicaProfessorTelefone,"",m_strRegistroPessoaFisicaProfessorEmail,"",-1,"",-1,System.DateTime.Now,false,m_strRegistroPessoaFisicaProfessorInstituicaoEnsino,m_strRegistroPessoaFisicaProfessorCurso,m_strRegistroPessoaFisicaProfessorFase,m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras);
						break;
				}
				switch (nResposta)
				{
					case ERRO_CADASTROCLIENTE_CLIENTE_NAO_CADASTRADO:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_ClienteNaoCadastrado));
						break;
					case ERRO_CADASTROCLIENTE_DESCONHECIDO:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_Desconhecido));
						break;
					case ERRO_CADASTROCLIENTE_EMAIL_NAO_CONFERE:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_EmailNaoConfere).Replace("\\n",System.Environment.NewLine));
						break;
					case ERRO_CADASTROCLIENTE_CODIGO_NAO_CONFERE:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_CodigoNaoConfere));
						break;
					case ERRO_CADASTROCLIENTE_PROBLEMAS_OCORRERAM_ACESSO_SERVIDOR:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_Problemas_Acessar_Servidor));
						break;
					case ERRO_CADASTROCLIENTE_ERRO_ATUALIZACAO_WEBSERVICES:
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_Erro_Atualizar_WebServices));
						break;
					default:
						bRetorno = (nResposta > 0);
						if (bRetorno)
							bRequisicaoDadosWebService(false);
						break;
				}
			}
			else
			{
				mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_ConectarInternetOuServidorForaAr));
			}

			return(bRetorno);
		}
		#endregion
		#region Requisicao Dados WebService
		public bool bRequisicaoDadosWebService(bool bShowErrors)
		{
			bool bRetorno = false;
			// Verificando se esta conectado a internet 
			if (mdlInet.clsPing.bEstaConectado())
			{
				// Cliente
				int nResposta = 0;
				clsRegistroWebService cls_webService_Registro =  new clsRegistroWebService(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				nResposta = cls_webService_Registro.nRequisicaoDadosVencimentoCliente(m_strCodigoCliente,out m_dtClienteHoje, out m_dtClienteAtualizacao,out m_dtClienteVencimento);
				switch (nResposta)
				{
					case ERRO_REQUISICAODADOS_CLIENTE_NAO_CADASTRADO:
						if (bShowErrors)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_ClienteNaoCadastrado));
						break;
					case ERRO_REQUISICAODADOS_DESCONHECIDO:
						if (bShowErrors)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_Desconhecido));
						break;
					case ERRO_REQUISICAODADOS_CLIENTE_NAO_LIBERADO:
						if (bShowErrors)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_RequisicaoClienteNaoLiberado));
						break;
					case ERRO_REQUISICAODADOS_DATAVENCIMENTO_INDISPONIVEL: 
						if (bShowErrors)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_RequisicaoDataVencimentoIndisponivel));
						break;
					case ERRO_REQUISICAODADOS_ATUALIZACAO_DATA_ATUALIZACAO:
						if (bShowErrors)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_RequisicaoDataAtualizacao));
						break;
					default:
						bRetorno = (nResposta > 0);
						if (bRetorno)
						{
							vKeyTimeGenerate(out m_strKeyCliente,m_dtClienteHoje,m_dtClienteAtualizacao,m_dtClienteVencimento);
							vSalvaDadosKey();
							vSincronizaDados(nResposta,ref m_cls_wbsv_Registro);
						}
						break;
				}
				if (bRetorno)
				{
					// Maquinas
					vRequisicaoDadosWebServiceMaquinas(ref cls_webService_Registro,nResposta);
				}

			}
			else
			{
				if (bShowErrors)
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_ConectarInternetOuServidorForaAr));
			}
			return(bRetorno);
		}

		private void vRequisicaoDadosWebServiceMaquinas(ref clsRegistroWebService cls_webService_Registro,int nIdCliente)
		{
			// Carregando as Maquinas 
			int nMaquinaAtual = -1;
			System.DateTime dtHojeMaquina = new DateTime(1900,1,1);
			System.DateTime dtHoje = new DateTime(1800,1,1);
			System.DateTime dtAtualizacao = new DateTime(1800,1,1);
			System.DateTime dtVencimento = new DateTime(1800,1,1);
			string strKeyFile = "";
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbMaquinas typDatSetTbMaquinas = m_cls_dba_ConnectionDB.GetTbMaquinas(null,null,null,null,null);
			mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow dtrwMaquina = null;
			for (int nCont = 0; nCont < typDatSetTbMaquinas.tbMaquinas.Rows.Count;nCont++)
			{
				dtrwMaquina = (mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow)typDatSetTbMaquinas.tbMaquinas.Rows[nCont];
				if (!dtrwMaquina.IsstrNomeNull())
				{
					cls_webService_Registro.nRequisicaoDadosVencimentoClienteMaquina(nIdCliente,dtrwMaquina.strNome,out dtHoje,out dtAtualizacao,out dtVencimento);
					//TODO: Mod Here
					//vKeyTimeGenerate(out strKeyFile,dtHoje,dtAtualizacao,dtVencimento);
					vKeyTimeGenerate(out strKeyFile,System.DateTime.Now,dtAtualizacao,dtVencimento);
					dtrwMaquina.strKeyFile = strKeyFile;
					if (dtrwMaquina.strNome == System.Environment.MachineName.ToUpper())
					{
						dtHojeMaquina = dtHoje;
						nMaquinaAtual = nCont; 
					}
				}
			}
			// Maquina atual ainda nao esta inserida no BD
			if (nMaquinaAtual == -1)
			{
				int nIdMaquina = 1;
				while (typDatSetTbMaquinas.tbMaquinas.FindBynIdMaquina(nIdMaquina) != null)
					nIdMaquina++;
				dtrwMaquina = typDatSetTbMaquinas.tbMaquinas.NewtbMaquinasRow();
				dtrwMaquina.nIdMaquina = nIdMaquina;
				dtrwMaquina.strNome = System.Environment.MachineName.ToUpper();
				cls_webService_Registro.nRequisicaoDadosVencimentoClienteMaquina(nIdCliente,dtrwMaquina.strNome,out dtHoje,out dtAtualizacao,out dtVencimento);
				vKeyTimeGenerate(out strKeyFile,System.DateTime.Now,dtAtualizacao,dtVencimento);
				dtrwMaquina.strKeyFile = strKeyFile;
				typDatSetTbMaquinas.tbMaquinas.AddtbMaquinasRow(dtrwMaquina);
				dtHojeMaquina = dtHoje;
			}
			m_cls_dba_ConnectionDB.SetTbMaquinas(typDatSetTbMaquinas);

			// Criando o KeyFile
			//bKeyFileGenerate((new System.DateTime(dtHojeMaquina.Year,dtHojeMaquina.Month,dtHojeMaquina.Day)).ToString());
		}
		#endregion
		#region Cliente
		private bool bClienteDadosOk()
		{
			bool bRetorno = false;
			if (bKeyTimeReturn(m_strKeyCliente,out m_dtClienteHoje,out m_dtClienteAtualizacao,out m_dtClienteVencimento))
			{
				bRetorno = true;
				System.DateTime dtNow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
				// Verificando se o dtHoje eh menor que o dia de hoje
				if (bRetorno)
				{
					if ((dtNow.Subtract(m_dtClienteHoje)).Days < 0)
					{
						if (!bSilent)
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_DataComputadorIncorreta));
						bRetorno = false;
					}
				}
				//  Verificando se o usuario necessita conectar a internet
				if (bRetorno)
					if ((dtNow.Subtract(m_dtClienteAtualizacao)).Days < 0)
						bRetorno = false;

				// Removendo KeyFile 
				if (!bRetorno)
					vKeyFileKill();
			}
			return(bRetorno);
		}

		private bool bClienteDentroValidade()
		{
			bool bRetorno = false;
			if (bKeyTimeReturn(m_strKeyCliente,out m_dtClienteHoje,out m_dtClienteAtualizacao,out m_dtClienteVencimento))
			{
				bRetorno = true;
				System.DateTime dtNow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);

				// Verificando se o Cliente esta dentro da validade
				if ((m_dtClienteVencimento.Subtract(dtNow)).Days < 0)
				{
					if (!bSilent)
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_ClienteForaValidade));
					bRetorno = false;
				}
			}
			return(bRetorno);
		}
		#endregion
		#region Maquina
		public bool bMaquinaDadosOk()
		{
			bool bRetorno = false;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			arlCondicaoCampo.Add("strNome");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(System.Environment.MachineName.ToUpper());
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbMaquinas typDatSetTbMaquinas = m_cls_dba_ConnectionDB.GetTbMaquinas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (typDatSetTbMaquinas.tbMaquinas.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow dtrwMaquina = (mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow)typDatSetTbMaquinas.tbMaquinas.Rows[0];
				if (!dtrwMaquina.IsstrKeyFileNull())
				{
					System.DateTime dtNow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
					System.DateTime dtMaquinaHoje;
					System.DateTime dtMaquinaAtualizacao;
					System.DateTime dtMaquinaVencimento;
					if (bKeyTimeReturn(dtrwMaquina.strKeyFile,out dtMaquinaHoje,out dtMaquinaAtualizacao,out dtMaquinaVencimento))
					{
						bRetorno = true;
						// Verificando se o dtHoje eh menor que o dia de hoje
						if (bRetorno)
						{
							if ((dtNow.Subtract(dtMaquinaHoje)).Days < 0)
							{
								if (!bSilent)
									mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_DataComputadorIncorreta));
								bRetorno = false;
							}
						}
						//  Verificando se a Maquina necessita conectar a internet
						if (bRetorno)
						{
							if ((dtNow.Subtract(dtMaquinaAtualizacao)).Days < 0)
							{
								return(false);
							}
						}
						//TODO: Disabled
						//							// KeyFile 
						//							if (bRetorno)
						//							{
						//								if (!bKeyFileCheck((new System.DateTime(dtMaquinaHoje.Year,dtMaquinaHoje.Month,dtMaquinaHoje.Day).ToString())))
						//								{
						//									return(false);
						//								}
						//							}
						//							// Removendo KeyFile 
						//							if (!bRetorno)
						//								vKeyFileKill();
					}
				}
			}
			return(bRetorno);
		}

		private bool bMaquinaDentroValidade()
		{
			bool bRetorno = false;
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			arlCondicaoCampo.Add("strNome");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(System.Environment.MachineName.ToUpper());
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbMaquinas typDatSetTbMaquinas = m_cls_dba_ConnectionDB.GetTbMaquinas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (typDatSetTbMaquinas.tbMaquinas.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow dtrwMaquina = (mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow)typDatSetTbMaquinas.tbMaquinas.Rows[0];
				if (!dtrwMaquina.IsstrKeyFileNull())
				{
					System.DateTime dtNow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
					System.DateTime dtMaquinaHoje;
					System.DateTime dtMaquinaAtualizacao;
					System.DateTime dtMaquinaVencimento;
					if (bKeyTimeReturn(dtrwMaquina.strKeyFile,out dtMaquinaHoje,out dtMaquinaAtualizacao,out dtMaquinaVencimento))
					{
						bRetorno = true;
						// Verificando se a Maquina esta dentro da validade
						if ((dtMaquinaVencimento.Subtract(dtNow)).Days < 0)
						{
							if (!bSilent)
								mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_MaquinaForaValidade));
							bRetorno = false;
						}
						// Verificando se a Maquina esta com a data Errada
						if ((System.DateTime.Now.Subtract(dtMaquinaHoje)).Seconds < 0)
						{
							if (!bSilent)
								mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_clsRegistro_MaquinaForaValidade));
							bRetorno = false;
						}
						else
						{
							string strKeyTime = "";
							vKeyTimeGenerate(out strKeyTime,System.DateTime.Now,dtMaquinaAtualizacao,dtMaquinaVencimento);
							dtrwMaquina.strKeyFile = strKeyTime;
							m_cls_dba_ConnectionDB.SetTbMaquinas(typDatSetTbMaquinas);
						}

						if (!bRetorno)
						{
							string strKeyTime = "";
							vKeyTimeGenerate(out strKeyTime,dtMaquinaVencimento.AddDays(1),dtMaquinaAtualizacao,dtMaquinaVencimento);
							dtrwMaquina.strKeyFile = strKeyTime;
							m_cls_dba_ConnectionDB.SetTbMaquinas(typDatSetTbMaquinas);
						}
					}
				}
			}
			return(bRetorno);
		}

		private void vMaquinaInvalida()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			arlCondicaoCampo.Add("strNome");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(System.Environment.MachineName.ToUpper());
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbMaquinas typDatSetTbMaquinas = m_cls_dba_ConnectionDB.GetTbMaquinas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (typDatSetTbMaquinas.tbMaquinas.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow dtrwMaquina = (mdlDataBaseAccess.Tabelas.XsdTbMaquinas.tbMaquinasRow)typDatSetTbMaquinas.tbMaquinas.Rows[0];
				if (!dtrwMaquina.IsstrKeyFileNull())
				{
					System.DateTime dtNow = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
					System.DateTime dtMaquinaHoje;
					System.DateTime dtMaquinaAtualizacao;
					System.DateTime dtMaquinaVencimento;
					if (bKeyTimeReturn(dtrwMaquina.strKeyFile,out dtMaquinaHoje,out dtMaquinaAtualizacao,out dtMaquinaVencimento))
					{
						string strKeyTime = "";
						vKeyTimeGenerate(out strKeyTime,dtMaquinaVencimento.AddDays(1),dtMaquinaAtualizacao,dtMaquinaVencimento);
						dtrwMaquina.strKeyFile = strKeyTime;
						m_cls_dba_ConnectionDB.SetTbMaquinas(typDatSetTbMaquinas);
					}
				}
			}
		}
		#endregion

		#region ShowDialogs
			#region Cadastro
				#region ShowDialogCadastro
					public bool ShowDialogCadastro()
					{
						bool bRetorno = false;
						m_enumJanelaAtual = mdlRegistro.Janelas.Categoria;
						while ((m_enumJanelaAtual != Janelas.OK) && (!m_bCancelou))
						{
							m_bCancelou = !ShowDialogJanelaAtual();                                                
						}
						if (m_enumJanelaAtual == Janelas.OK)
						{
							bRetorno = true;
						}
						return(bRetorno);
					}
				#endregion
				#region ShowDialogJanelaAtual
					private bool ShowDialogJanelaAtual()
					{
						bool bRetorno = false;
						switch(m_enumJanelaAtual)
						{
							case Janelas.Categoria:
								bRetorno = ShowDialogCategoria(); 
								break;
							case Janelas.Classificacao:
								bRetorno = ShowDialogClassificacao();
								break;
							case Janelas.Usuario:
								switch(m_enumRegistroClasse)
								{
									case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
										bRetorno = ShowDialogPJExportadorUsuario();
										break;
									case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
										bRetorno = ShowDialogPJPrestadorServicoUsuario();
										break;
								}
								break;
							case Janelas.Informacoes:
								bRetorno = ShowDialogInformacoes();
								break;
						}
						return(bRetorno);
					}
				#endregion
				#region ShowDialogCategoria
					private bool ShowDialogCategoria()
					{
						bool bRetorno = false;
						frmFRegistroCategoria formFRegistroCategoria = new frmFRegistroCategoria(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel,m_enumRegistroClasse);
						formFRegistroCategoria.ShowDialog();
						if (bRetorno = formFRegistroCategoria.m_bModificado)
						{
							formFRegistroCategoria.RetornaValores(out m_enumRegistroClasse);
							JanelaProxima();
						}
						return(bRetorno);
					}
				#endregion
				#region ShowDialogClassificacao
					private bool ShowDialogClassificacao()
					{
						bool bRetorno = false;
						switch(m_enumRegistroClasse)
						{
							case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
								bRetorno = ShowDialogClassificacaoPJExportador();
								break;
							case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
								bRetorno = ShowDialogClassificacaoPJPrestadorServico();
								break;
							case mdlRegistro.RegistroClasse.PessoaFisicaExportador:
								bRetorno = ShowDialogClassificacaoPFExportador();
								break;
							case mdlRegistro.RegistroClasse.PessoaFisicaPrestadorServico:
								bRetorno = ShowDialogClassificacaoPFPrestadorServico();
								break;
							case mdlRegistro.RegistroClasse.PessoaFisicaEstudante:
								bRetorno = ShowDialogClassificacaoACEstudante();
								break;
							case mdlRegistro.RegistroClasse.PessoaFisicaProfessor:
								bRetorno = ShowDialogClassificacaoACProfessor();
								break;
						}
						return(bRetorno);
					}
							
					#region ShowDialogClassificacaoPJ
						private bool ShowDialogClassificacaoPJExportador()
						{
							bool bRetorno = false;
							frmFRegistroCategoriaPJExportador formFCategoriaPJExportador = new frmFRegistroCategoriaPJExportador(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
							vInitializeEvents(ref formFCategoriaPJExportador);
							formFCategoriaPJExportador.ShowDialog();
							switch(formFCategoriaPJExportador.m_enumResposta)
							{
								case mdlRegistro.Resposta.Voltar:
									JanelaAnterior();
									bRetorno = true;
									break;
								case mdlRegistro.Resposta.Cancelar:
									bRetorno = false;
									break;
								case mdlRegistro.Resposta.Continuar:
									JanelaProxima();
									bRetorno = true;
									break;
							}
							return(bRetorno);
						}
						#region InitializeEvents
							private void vInitializeEvents(ref frmFRegistroCategoriaPJExportador formFCategoriaPJExportador)
							{
								// Refresh Estados
								formFCategoriaPJExportador.eCallRefreshEstados += new mdlRegistro.frmFRegistroCategoriaPJExportador.delCallRefreshEstados(vRefreshEstados);

								// Carrega Dados
								formFCategoriaPJExportador.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaPJExportador.delCallCarregaDados(formFCategoriaPJExportador_eCallCarregaDados);

								// Salva Dados
								formFCategoriaPJExportador.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaPJExportador.delCallSalvaDados(formFCategoriaPJExportador_eCallSalvaDados);

							}

							private void formFCategoriaPJExportador_eCallCarregaDados(out string strRazaoSocial,out string strNomeFantasia,out string strCNPJ,out string strLogradouro,out string strComplemento,out string strBairro,out string strCidade,out int nEstado,out string strCEP,out string strTelefone,out string strTelefoneDDD,out string strFax,out string strFaxDDD,out string strEmail, out string strSite,out string strSetorAtividade,out int nQuantidadeExportacoesAnuais,out int nQuantidadeFuncionarios,out int nExportaQuantosAnos ,out bool bRealizaImportacao)
							{
								strRazaoSocial = m_strRegistroPessoaJuridicaExportadorRazaoSocial;
								strNomeFantasia = m_strRegistroPessoaJuridicaExportadorNomeFantasia;
								strCNPJ = m_strRegistroPessoaJuridicaExportadorCNPJ;
								strLogradouro = m_strRegistroPessoaJuridicaExportadorLogradouro;
								strComplemento = m_strRegistroPessoaJuridicaExportadorComplemento;
								strBairro = m_strRegistroPessoaJuridicaExportadorBairro;
								strCidade = m_strRegistroPessoaJuridicaExportadorCidade;
								nEstado = m_nRegistroPessoaJuridicaExportadorEstado;
								strCEP = m_strRegistroPessoaJuridicaExportadorCep;
								strTelefone = m_strRegistroPessoaJuridicaExportadorTelefone;
								strTelefoneDDD = m_strRegistroPessoaJuridicaExportadorTelefoneDDD;
								strFax = m_strRegistroPessoaJuridicaExportadorFax;
								strFaxDDD = m_strRegistroPessoaJuridicaExportadorFaxDDD;
								strEmail = m_strRegistroPessoaJuridicaExportadorEmail;
								strSite = m_strRegistroPessoaJuridicaExportadorSite;
								strSetorAtividade = m_strRegistroPessoaJuridicaExportadorSetorAtividade;
								nQuantidadeExportacoesAnuais = m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais;
								nQuantidadeFuncionarios = m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios;
								nExportaQuantosAnos = m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos;
								bRealizaImportacao = m_bRegistroPessoaJuridicaExportadorImportacoes;
							}

							private void formFCategoriaPJExportador_eCallSalvaDados(string strRazaoSocial,string strNomeFantasia,string strCNPJ,string strLogradouro,string strComplemento,string strBairro,string strCidade,int nEstado,string strCEP,string strTelefone,string strTelefoneDDD,string strFax,string strFaxDDD,string strEmail,string strSite,string strSetorAtividade,int nQuantidadeExportacoesAnuais,int nQuantidadeFuncionarios,int nExportaQuantosAnos ,bool bRealizaImportacao)
							{
								m_strRegistroPessoaJuridicaExportadorRazaoSocial = strRazaoSocial;
								m_strRegistroPessoaJuridicaExportadorNomeFantasia = strNomeFantasia;
								m_strRegistroPessoaJuridicaExportadorCNPJ = strCNPJ;
								m_strRegistroPessoaJuridicaExportadorLogradouro = strLogradouro;
								m_strRegistroPessoaJuridicaExportadorComplemento = strComplemento;
								m_strRegistroPessoaJuridicaExportadorBairro = strBairro;
								m_strRegistroPessoaJuridicaExportadorCidade = strCidade;
								m_nRegistroPessoaJuridicaExportadorEstado = nEstado;
								m_strRegistroPessoaJuridicaExportadorCep = strCEP;
								m_strRegistroPessoaJuridicaExportadorTelefoneDDD = strTelefoneDDD;
								m_strRegistroPessoaJuridicaExportadorTelefone = strTelefone;
								if (m_strRegistroPessoaJuridicaExportadorTelefone == "")
								{
									m_strRegistroPessoaJuridicaExportadorUsuarioTelefoneDDD = strTelefoneDDD;
									m_strRegistroPessoaJuridicaExportadorUsuarioTelefone = strTelefone;
								}
								m_strRegistroPessoaJuridicaExportadorFaxDDD = strFaxDDD;
								m_strRegistroPessoaJuridicaExportadorFax = strFax;
								if (m_strRegistroPessoaJuridicaExportadorUsuarioFax == "")
								{
									m_strRegistroPessoaJuridicaExportadorUsuarioFaxDDD = strFaxDDD;
									m_strRegistroPessoaJuridicaExportadorUsuarioFax = strFax;
								}
								m_strRegistroPessoaJuridicaExportadorEmail = strEmail;
								if (m_strRegistroPessoaJuridicaExportadorUsuarioEmail == "")
									m_strRegistroPessoaJuridicaExportadorUsuarioEmail = m_strRegistroPessoaJuridicaExportadorEmail;
								m_strRegistroPessoaJuridicaExportadorSite = strSite;
								m_strRegistroPessoaJuridicaExportadorSetorAtividade = strSetorAtividade;
								m_nRegistroPessoaJuridicaExportadorQuantidadeExportacoesAnuais = nQuantidadeExportacoesAnuais;
								m_nRegistroPessoaJuridicaExportadorQuantidadeFuncionarios = nQuantidadeFuncionarios;
								m_nRegistroPessoaJuridicaExportadorExportaQuantosAnos = nExportaQuantosAnos;
								m_bRegistroPessoaJuridicaExportadorImportacoes = bRealizaImportacao;
							}
						#endregion

						private bool ShowDialogClassificacaoPJPrestadorServico()
						{
							bool bRetorno = false;
							frmFRegistroCategoriaPJPrestadorServico formFCategoriaPJPrestadorServico = new frmFRegistroCategoriaPJPrestadorServico(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
							vInitializeEvents(ref formFCategoriaPJPrestadorServico);
							formFCategoriaPJPrestadorServico.ShowDialog();
							switch(formFCategoriaPJPrestadorServico.m_enumResposta)
							{
								case mdlRegistro.Resposta.Voltar:
									JanelaAnterior();
									bRetorno = true;
									break;
								case mdlRegistro.Resposta.Cancelar:
									bRetorno = false;
									break;
								case mdlRegistro.Resposta.Continuar:
									JanelaProxima();
									bRetorno = true;
									break;
							}
							return(bRetorno);
						}
						#region InitializeEvents
							private void vInitializeEvents(ref frmFRegistroCategoriaPJPrestadorServico formFCategoriaPJPrestadorServico)
							{
								// Refresh Estados
								formFCategoriaPJPrestadorServico.eCallRefreshEstados += new frmFRegistroCategoriaPJPrestadorServico.delCallRefreshEstados(vRefreshEstados);

								// Refresh Servicos
								formFCategoriaPJPrestadorServico.eCallRefreshServicos += new frmFRegistroCategoriaPJPrestadorServico.delCallRefreshServicos(vRefreshServicos);

								// Carrega Dados
								formFCategoriaPJPrestadorServico.eCallCarregaDados += new frmFRegistroCategoriaPJPrestadorServico.delCallCarregaDados(formFCategoriaPJPrestadorServico_eCallCarregaDados);

								// Salva Dados
								formFCategoriaPJPrestadorServico.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaPJPrestadorServico.delCallSalvaDados(formFCategoriaPJPrestadorServico_eCallSalvaDados);
							}

							private void formFCategoriaPJPrestadorServico_eCallCarregaDados(out string strRazaoSocial,out string strNomeFantasia,out string strCNPJ,out string strLogradouro,out string strComplemento,out string strBairro,out string strCidade,out int nEstado,out string strCEP,out string strTelefone,out string strTelefoneDDD,out string strFax,out string strFaxDDD,out string strEmail, out string strSite,out string strServicos,out int nQuantidadeClientesExportadores,out int nQuantidadeFuncionarios,out bool bRealizaImportacao)
							{
								strRazaoSocial = m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial;
								strNomeFantasia = m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia;
								strCNPJ = m_strRegistroPessoaJuridicaPrestadorServicoCNPJ;
								strLogradouro = m_strRegistroPessoaJuridicaPrestadorServicoLogradouro;
								strComplemento = m_strRegistroPessoaJuridicaPrestadorServicoComplemento;
								strBairro = m_strRegistroPessoaJuridicaPrestadorServicoBairro;
								strCidade = m_strRegistroPessoaJuridicaPrestadorServicoCidade;
								nEstado = m_nRegistroPessoaJuridicaPrestadorServicoEstado;
								strCEP = m_strRegistroPessoaJuridicaPrestadorServicoCEP;
								strTelefone = m_strRegistroPessoaJuridicaPrestadorServicoTelefone;
								strTelefoneDDD = m_strRegistroPessoaJuridicaPrestadorServicoTelefoneDDD;
								strFax = m_strRegistroPessoaJuridicaPrestadorServicoFax;
								strFaxDDD = m_strRegistroPessoaJuridicaPrestadorServicoFaxDDD;
								strEmail = m_strRegistroPessoaJuridicaPrestadorServicoEmail;
								strSite = m_strRegistroPessoaJuridicaPrestadorServicoSite;
								strServicos = m_strRegistroPessoaJuridicaPrestadorServicoServicos;
								nQuantidadeClientesExportadores = m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores;
								nQuantidadeFuncionarios = m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios;
								bRealizaImportacao = m_bRegistroPessoaJuridicaPrestadorServicoImportacoes;
							}

							private void formFCategoriaPJPrestadorServico_eCallSalvaDados(string strRazaoSocial,string strNomeFantasia,string strCNPJ,string strLogradouro,string strComplemento,string strBairro,string strCidade,int nEstado,string strCEP,string strTelefone,string strTelefoneDDD,string strFax,string strFaxDDD,string strEmail,string strSite,string strServicos,int nQuantidadeClientesExportadores,int nQuantidadeFuncionarios,bool bRealizaImportacao)
							{
								m_strRegistroPessoaJuridicaPrestadorServicoRazaoSocial = strRazaoSocial;
								m_strRegistroPessoaJuridicaPrestadorServicoNomeFantasia = strNomeFantasia ;
								m_strRegistroPessoaJuridicaPrestadorServicoCNPJ = strCNPJ;
								m_strRegistroPessoaJuridicaPrestadorServicoLogradouro = strLogradouro;
								m_strRegistroPessoaJuridicaPrestadorServicoComplemento = strComplemento;
								m_strRegistroPessoaJuridicaPrestadorServicoBairro = strBairro;
								m_strRegistroPessoaJuridicaPrestadorServicoCidade = strCidade;
								m_nRegistroPessoaJuridicaPrestadorServicoEstado = nEstado;
								m_strRegistroPessoaJuridicaPrestadorServicoCEP = strCEP;
								m_strRegistroPessoaJuridicaPrestadorServicoTelefone = strTelefone;
								m_strRegistroPessoaJuridicaPrestadorServicoTelefoneDDD = strTelefoneDDD;
								if (m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone == "")
								{
									m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone = strTelefone;
									m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefoneDDD = strTelefoneDDD;
								}
								m_strRegistroPessoaJuridicaPrestadorServicoFax = strFax;
								m_strRegistroPessoaJuridicaPrestadorServicoFaxDDD = strFaxDDD;
								if (m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax == "")
								{
									m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax = strFax;
									m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFaxDDD = strFaxDDD;
								}
								m_strRegistroPessoaJuridicaPrestadorServicoEmail = strEmail;
								if (m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail == "")
									m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail = m_strRegistroPessoaJuridicaPrestadorServicoEmail;
								m_strRegistroPessoaJuridicaPrestadorServicoSite = strSite;
								m_strRegistroPessoaJuridicaPrestadorServicoServicos = strServicos;
								m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeClientesExportadores = nQuantidadeClientesExportadores;
								m_nRegistroPessoaJuridicaPrestadorServicoQuantidadeFuncionarios = nQuantidadeFuncionarios;
								m_bRegistroPessoaJuridicaPrestadorServicoImportacoes = bRealizaImportacao;
							}
						#endregion
					#endregion
					#region ShowDialogClassificacaoPF
						#region ShowDialogClassificacaoPFExportador
							private bool ShowDialogClassificacaoPFExportador()
							{
								bool bRetorno = false;
								frmFRegistroCategoriaPFExportador formFCategoriaPFExportador = new frmFRegistroCategoriaPFExportador(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
								vInitializeEvents(ref formFCategoriaPFExportador);
								formFCategoriaPFExportador.ShowDialog();
								switch(formFCategoriaPFExportador.m_enumResposta)
								{
									case mdlRegistro.Resposta.Voltar:
										JanelaAnterior();
										bRetorno = true;
										break;
									case mdlRegistro.Resposta.Cancelar:
										bRetorno = false;
										break;
									case mdlRegistro.Resposta.Continuar:
										JanelaProxima();
										bRetorno = true;
										break;
								}
								return(bRetorno);
							}
							#region InitializeEvents
								private void vInitializeEvents(ref frmFRegistroCategoriaPFExportador formFCategoriaPFExportador)
								{
									// Refresh Sexo
									formFCategoriaPFExportador.eCallRefreshSexo +=new mdlRegistro.frmFRegistroCategoriaPFExportador.delCallRefreshSexo(vRefreshSexo);

									// Refresh Estado 
									formFCategoriaPFExportador.eCallRefreshEstado +=new mdlRegistro.frmFRegistroCategoriaPFExportador.delCallRefreshEstado(vRefreshEstados);

									// Carrega Dados 
									formFCategoriaPFExportador.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaPFExportador.delCallCarregaDados(formFCategoriaPFExportador_eCallCarregaDados);

									// Salva Dados 
									formFCategoriaPFExportador.eCallSalvaDados +=new mdlRegistro.frmFRegistroCategoriaPFExportador.delCallSalvaDados(formFCategoriaPFExportador_eCallSalvaDados);
								}

								private void formFCategoriaPFExportador_eCallCarregaDados(out string strNome ,out string strCPF ,out bool bSexoMasculino ,out System.DateTime dtDataNascimento ,out string strLogradouro ,out string strComplemento ,out string strBairro ,out string strCidade ,out int nEstado ,out string strCEP ,out string strTelefone,out string strTelefoneDDD ,out string strFax,out string strFaxDDD,out string strEmail ,out string strSite ,out string strSetorAtividade ,out int nQuantidadeExportacoesAnuais ,out int nExportaQuantosAnos ,out bool bRealizaImportacao)
								{
									strNome = m_strRegistroPessoaFisicaExportadorNome;
									strCPF = m_strRegistroPessoaFisicaExportadorCPF; 
									bSexoMasculino = m_bRegistroPessoaFisicaExportadorSexoMasculino; 
									dtDataNascimento = m_dtRegistroPessoaFisicaExportadorDataNascimento; 
									strLogradouro = m_strRegistroPessoaFisicaExportadorLogradouro; 
									strComplemento = m_strRegistroPessoaFisicaExportadorComplemento; 
									strBairro = m_strRegistroPessoaFisicaExportadorBairro; 
									strCidade = m_strRegistroPessoaFisicaExportadorCidade; 
									nEstado = m_nRegistroPessoaFisicaExportadorEstado; 
									strCEP = m_strRegistroPessoaFisicaExportadorCEP; 
									strTelefone = m_strRegistroPessoaFisicaExportadorTelefone; 
									strTelefoneDDD = m_strRegistroPessoaFisicaExportadorTelefoneDDD; 
									strFax = m_strRegistroPessoaFisicaExportadorFax; 
									strFaxDDD = m_strRegistroPessoaFisicaExportadorFaxDDD; 
									strEmail = m_strRegistroPessoaFisicaExportadorEmail; 
									strSite = m_strRegistroPessoaFisicaExportadorSite; 
									strSetorAtividade = m_strRegistroPessoaFisicaExportadorSetorAtividade; 
									nQuantidadeExportacoesAnuais = m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais; 
									nExportaQuantosAnos = m_nRegistroPessoaFisicaExportadorExportaQuantosAnos; 
									bRealizaImportacao = m_bRegistroPessoaFisicaExportadorImportacoes;
								}

								private void formFCategoriaPFExportador_eCallSalvaDados(string strNome ,string strCPF ,bool bSexoMasculino ,System.DateTime dtDataNascimento ,string strLogradouro ,string strComplemento ,string strBairro ,string strCidade ,int nEstado ,string strCEP ,string strTelefone,string strTelefoneDDD,string strFax,string strFaxDDD,string strEmail ,string strSite ,string strSetorAtividade ,int nQuantidadeExportacoesAnuais ,int nExportaQuantosAnos ,bool bRealizaImportacao )
								{
									m_strRegistroPessoaFisicaExportadorNome = strNome;
									m_strRegistroPessoaFisicaExportadorCPF = strCPF; 
									m_bRegistroPessoaFisicaExportadorSexoMasculino = bSexoMasculino; 
									m_dtRegistroPessoaFisicaExportadorDataNascimento = dtDataNascimento; 
									m_strRegistroPessoaFisicaExportadorLogradouro = strLogradouro; 
									m_strRegistroPessoaFisicaExportadorComplemento = strComplemento; 
									m_strRegistroPessoaFisicaExportadorBairro = strBairro; 
									m_strRegistroPessoaFisicaExportadorCidade = strCidade; 
									m_nRegistroPessoaFisicaExportadorEstado = nEstado; 
									m_strRegistroPessoaFisicaExportadorCEP = strCEP; 
									m_strRegistroPessoaFisicaExportadorTelefone = strTelefone; 
									m_strRegistroPessoaFisicaExportadorTelefoneDDD = strTelefoneDDD; 
									m_strRegistroPessoaFisicaExportadorFax = strFax; 
									m_strRegistroPessoaFisicaExportadorFaxDDD = strFaxDDD; 
									m_strRegistroPessoaFisicaExportadorEmail = strEmail; 
									m_strRegistroPessoaFisicaExportadorSite = strSite; 
									m_strRegistroPessoaFisicaExportadorSetorAtividade = strSetorAtividade; 
									m_nRegistroPessoaFisicaExportadorQuantidadeExportacoesAnuais = nQuantidadeExportacoesAnuais; 
									m_nRegistroPessoaFisicaExportadorExportaQuantosAnos = nExportaQuantosAnos; 
									m_bRegistroPessoaFisicaExportadorImportacoes = bRealizaImportacao;
								}
							#endregion

						#endregion
						#region ShowDialogClassificacaoPFPrestadorServico
							private bool ShowDialogClassificacaoPFPrestadorServico()
							{
								bool bRetorno = false;
								frmFRegistroCategoriaPFPrestadorServico formFCategoriaPFPrestadorServico = new frmFRegistroCategoriaPFPrestadorServico(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
								vInitializeEvents(ref formFCategoriaPFPrestadorServico);
								formFCategoriaPFPrestadorServico.ShowDialog();
								switch(formFCategoriaPFPrestadorServico.m_enumResposta)
								{
									case mdlRegistro.Resposta.Voltar:
										JanelaAnterior();
										bRetorno = true;
										break;
									case mdlRegistro.Resposta.Cancelar:
										bRetorno = false;
										break;
									case mdlRegistro.Resposta.Continuar:
										JanelaProxima();
										bRetorno = true;
										break;
								}
								return(bRetorno);
							}
					
							#region InitializeEvents
								private void vInitializeEvents(ref frmFRegistroCategoriaPFPrestadorServico formFCategoriaPFPrestadorServico)
								{
									// Refresh Sexo
									formFCategoriaPFPrestadorServico.eCallRefreshSexo +=new mdlRegistro.frmFRegistroCategoriaPFPrestadorServico.delCallRefreshSexo(vRefreshSexo);

									// Refresh Estado 
									formFCategoriaPFPrestadorServico.eCallRefreshEstado += new mdlRegistro.frmFRegistroCategoriaPFPrestadorServico.delCallRefreshEstado(vRefreshEstados);

									// Servicos
									formFCategoriaPFPrestadorServico.eCallRefreshServicos += new mdlRegistro.frmFRegistroCategoriaPFPrestadorServico.delCallRefreshServicos(vRefreshServicos);

									// Carrega Dados 
									formFCategoriaPFPrestadorServico.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaPFPrestadorServico.delCallCarregaDados(formFCategoriaPFPrestadorServico_eCallCarregaDados);

									// Salva Dados 
									formFCategoriaPFPrestadorServico.eCallSalvaDados +=new mdlRegistro.frmFRegistroCategoriaPFPrestadorServico.delCallSalvaDados(formFCategoriaPFPrestadorServico_eCallSalvaDados);
								}
							#endregion

							private void formFCategoriaPFPrestadorServico_eCallCarregaDados(out string strNome ,out string strCPF ,out bool bSexoMasculino ,out System.DateTime dtDataNascimento ,out string strLogradouro ,out string strComplemento ,out string strBairro ,out string strCidade ,out int nEstado ,out string strCEP ,out string strTelefone,out string strTelefoneDDD ,out string strFax,out string strFaxDDD,out string strEmail ,out string strSite ,out string strServicos ,out int nQuantidadeClientesExportadores, out bool bRealizaImportacao)
							{
								strNome = m_strRegistroPessoaFisicaPrestadorServicoNome;
								strCPF = m_strRegistroPessoaFisicaPrestadorServicoCPF; 
								bSexoMasculino = m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino; 
								dtDataNascimento = m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento; 
								strLogradouro = m_strRegistroPessoaFisicaPrestadorServicoLogradouro; 
								strComplemento = m_strRegistroPessoaFisicaPrestadorServicoComplemento; 
								strBairro = m_strRegistroPessoaFisicaPrestadorServicoBairro; 
								strCidade = m_strRegistroPessoaFisicaPrestadorServicoCidade; 
								nEstado = m_nRegistroPessoaFisicaPrestadorServicoEstado; 
								strCEP = m_strRegistroPessoaFisicaPrestadorServicoCEP; 
								strTelefone = m_strRegistroPessoaFisicaPrestadorServicoTelefone; 
								strTelefoneDDD = m_strRegistroPessoaFisicaPrestadorServicoTelefoneDDD; 
								strFax = m_strRegistroPessoaFisicaPrestadorServicoFax; 
								strFaxDDD = m_strRegistroPessoaFisicaPrestadorServicoFaxDDD; 
								strEmail = m_strRegistroPessoaFisicaPrestadorServicoEmail; 
								strSite = m_strRegistroPessoaFisicaPrestadorServicoSite; 
								strServicos = m_strRegistroPessoaFisicaPrestadorServicoServicos;
								nQuantidadeClientesExportadores = m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores;
								bRealizaImportacao = m_bRegistroPessoaFisicaPrestadorServicoImportacoes;
							}

							private void formFCategoriaPFPrestadorServico_eCallSalvaDados(string strNome ,string strCPF ,bool bSexoMasculino ,System.DateTime dtDataNascimento ,string strLogradouro ,string strComplemento ,string strBairro ,string strCidade ,int nEstado ,string strCEP ,string strTelefone,string strTelefoneDDD ,string strFax,string strFaxDDD,string strEmail ,string strSite ,string strServicos ,int nQuantidadeClientesExportadores,bool bRealizaImportacao)
							{
								m_strRegistroPessoaFisicaPrestadorServicoNome = strNome;
								m_strRegistroPessoaFisicaPrestadorServicoCPF = strCPF; 
								m_bRegistroPessoaFisicaPrestadorServicoSexoMasculino = bSexoMasculino; 
								m_dtRegistroPessoaFisicaPrestadorServicoDataNascimento = dtDataNascimento; 
								m_strRegistroPessoaFisicaPrestadorServicoLogradouro = strLogradouro;  
								m_strRegistroPessoaFisicaPrestadorServicoComplemento = strComplemento; 
								m_strRegistroPessoaFisicaPrestadorServicoBairro = strBairro;  
								m_strRegistroPessoaFisicaPrestadorServicoCidade = strCidade; 
								m_nRegistroPessoaFisicaPrestadorServicoEstado = nEstado; 
								m_strRegistroPessoaFisicaPrestadorServicoCEP = strCEP; 
								m_strRegistroPessoaFisicaPrestadorServicoTelefone = strTelefone; 
								m_strRegistroPessoaFisicaPrestadorServicoTelefoneDDD = strTelefoneDDD; 
								m_strRegistroPessoaFisicaPrestadorServicoFax = strFax; 
								m_strRegistroPessoaFisicaPrestadorServicoFaxDDD = strFaxDDD; 
								m_strRegistroPessoaFisicaPrestadorServicoEmail = strEmail; 
								m_strRegistroPessoaFisicaPrestadorServicoSite = strSite; 
								m_strRegistroPessoaFisicaPrestadorServicoServicos = strServicos;
								m_nRegistroPessoaFisicaPrestadorServicoQuantidadeClientesExportadores = nQuantidadeClientesExportadores;
								m_bRegistroPessoaFisicaPrestadorServicoImportacoes = bRealizaImportacao;
							}
						#endregion
					#endregion
					#region ShowDialogClassificacaoAC
						#region ShowDialogClassificacaoACEstudante
							private bool ShowDialogClassificacaoACEstudante()
							{
								bool bRetorno = false;
								frmFRegistroCategoriaACEstudante formFCategoriaACEstudante = new frmFRegistroCategoriaACEstudante(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
								vInitializeEvents(ref formFCategoriaACEstudante);
								formFCategoriaACEstudante.ShowDialog();
								switch(formFCategoriaACEstudante.m_enumResposta)
								{
									case mdlRegistro.Resposta.Voltar:
										JanelaAnterior();
										bRetorno = true;
										break;
									case mdlRegistro.Resposta.Cancelar:
										bRetorno = false;
										break;
									case mdlRegistro.Resposta.Continuar:
										JanelaProxima();
										bRetorno = true;
										break;
								}
								return(bRetorno);
							}

							#region InitializeEvents
								private void vInitializeEvents(ref frmFRegistroCategoriaACEstudante formFCategoriaACEstudante)
								{
									// Refresh Sexo
									formFCategoriaACEstudante.eCallRefreshSexo += new mdlRegistro.frmFRegistroCategoriaACEstudante.delCallRefreshSexo(vRefreshSexo);

									// Refresh Estados
									formFCategoriaACEstudante.eCallRefreshEstado +=new mdlRegistro.frmFRegistroCategoriaACEstudante.delCallRefreshEstado(vRefreshEstados);

									// Carrega Dados 
									formFCategoriaACEstudante.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaACEstudante.delCallCarregaDados(formFCategoriaACEstudante_eCallCarregaDados);

									// Salva Dados 
									formFCategoriaACEstudante.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaACEstudante.delCallSalvaDados(formFCategoriaACEstudante_eCallSalvaDados);
								}

								private void formFCategoriaACEstudante_eCallCarregaDados(out string strNome ,out string strCPF,out bool bSexoMasculino ,out System.DateTime dtDataNascimento,out string strEmail,out string strTelefone,out string strTelefoneDDD,out string strInstituicaoEnsino ,out string strCurso ,out string strFase ,out string strLogradouro ,out string strComplemento ,out string strBairro ,out string strCidade ,out int nEstado ,out string strCEP)
								{
									strNome = m_strRegistroPessoaFisicaEstudanteNome;
									strCPF = m_strRegistroPessoaFisicaEstudanteCPF;
									bSexoMasculino = m_bRegistroPessoaFisicaEstudanteSexoMasculino;
									dtDataNascimento = m_dtRegistroPessoaFisicaEstudanteDataNascimento;
									strEmail = m_strRegistroPessoaFisicaEstudanteEmail;
									strTelefone = m_strRegistroPessoaFisicaEstudanteTelefone; 
									strTelefoneDDD = m_strRegistroPessoaFisicaEstudanteTelefoneDDD; 
									strInstituicaoEnsino = m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino; 
									strCurso = m_strRegistroPessoaFisicaEstudanteCurso; 
									strFase = m_strRegistroPessoaFisicaEstudanteFase; 
									strLogradouro = m_strRegistroPessoaFisicaEstudanteLogradouro; 
									strComplemento = m_strRegistroPessoaFisicaEstudanteComplemento; 
									strBairro = m_strRegistroPessoaFisicaEstudanteBairro; 
									strCidade = m_strRegistroPessoaFisicaEstudanteCidade; 
									nEstado = m_nRegistroPessoaFisicaExportadorEstado; 
									strCEP = m_strRegistroPessoaFisicaEstudanteCep;
								}

								private void formFCategoriaACEstudante_eCallSalvaDados(string strNome ,string strCPF,bool bSexoMasculino ,System.DateTime dtDataNascimento,string strEmail,string strTelefone,string strTelefoneDDD,string strInstituicaoEnsino ,string strCurso ,string strFase ,string strLogradouro ,string strComplemento ,string strBairro ,string strCidade ,int nEstado ,string strCEP)
								{
									m_strRegistroPessoaFisicaEstudanteNome = strNome;
									m_strRegistroPessoaFisicaEstudanteCPF = strCPF;
									m_bRegistroPessoaFisicaEstudanteSexoMasculino = bSexoMasculino;
									m_dtRegistroPessoaFisicaEstudanteDataNascimento = dtDataNascimento;
									m_strRegistroPessoaFisicaEstudanteEmail = strEmail;
									m_strRegistroPessoaFisicaEstudanteTelefone = strTelefone; 
									m_strRegistroPessoaFisicaEstudanteTelefoneDDD = strTelefoneDDD; 
									m_strRegistroPessoaFisicaEstudanteInstituicaoEnsino = strInstituicaoEnsino; 
									m_strRegistroPessoaFisicaEstudanteCurso = strCurso; 
									m_strRegistroPessoaFisicaEstudanteFase = strFase; 
									m_strRegistroPessoaFisicaEstudanteLogradouro = strLogradouro; 
									m_strRegistroPessoaFisicaEstudanteComplemento = strComplemento; 
									m_strRegistroPessoaFisicaEstudanteBairro = strBairro; 
									m_strRegistroPessoaFisicaEstudanteCidade = strCidade; 
									m_nRegistroPessoaFisicaEstudanteEstado = nEstado; 
									m_strRegistroPessoaFisicaEstudanteCep = strCEP;
								}
							#endregion
						#endregion
						#region ShowDialogClassificacaoACProfessor
							private bool ShowDialogClassificacaoACProfessor()
							{
								bool bRetorno = false;
								frmFRegistroCategoriaACProfessor formFCategoriaACProfessor = new frmFRegistroCategoriaACProfessor(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
								vInitializeEvents(ref formFCategoriaACProfessor);
								formFCategoriaACProfessor.ShowDialog();
								switch(formFCategoriaACProfessor.m_enumResposta)
								{
									case mdlRegistro.Resposta.Voltar:
										JanelaAnterior();
										bRetorno = true;
										break;
									case mdlRegistro.Resposta.Cancelar:
										bRetorno = false;
										break;
									case mdlRegistro.Resposta.Continuar:
										JanelaProxima();
										bRetorno = true;
										break;
								}
								return(bRetorno);
							}
							
							#region InitializeEvents
								private void vInitializeEvents(ref frmFRegistroCategoriaACProfessor formFCategoriaACProfessor)
								{
									// Refresh Sexo
									formFCategoriaACProfessor.eCallRefreshSexo +=new mdlRegistro.frmFRegistroCategoriaACProfessor.delCallRefreshSexo(vRefreshSexo);
									
									// Refresh Estados
									formFCategoriaACProfessor.eCallRefreshEstado += new mdlRegistro.frmFRegistroCategoriaACProfessor.delCallRefreshEstado(vRefreshEstados);

									// Carrega Dados 
									formFCategoriaACProfessor.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaACProfessor.delCallCarregaDados(formFCategoriaACProfessor_eCallCarregaDados);

									// Salva Dados 
									formFCategoriaACProfessor.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaACProfessor.delCallSalvaDados(formFCategoriaACProfessor_eCallSalvaDados);
								}

								private void formFCategoriaACProfessor_eCallCarregaDados(out string strNome ,out string strCPF,out bool bSexoMasculino ,out System.DateTime dtDataNascimento,out string strEmail,out string strTelefone,out string strTelefoneDDD,out string strInstituicaoEnsino ,out string strCurso ,out string strFase ,out string strLogradouro ,out string strComplemento ,out string strBairro ,out string strCidade ,out int nEstado ,out string strCEP)
								{
									strNome = m_strRegistroPessoaFisicaProfessorNome;
									strCPF = m_strRegistroPessoaFisicaProfessorCPF;
									bSexoMasculino = m_bRegistroPessoaFisicaProfessorSexoMasculino;
									dtDataNascimento = m_dtRegistroPessoaFisicaProfessorDataNascimento;
									strEmail = m_strRegistroPessoaFisicaProfessorEmail;
									strTelefone = m_strRegistroPessoaFisicaProfessorTelefone; 
									strTelefoneDDD = m_strRegistroPessoaFisicaProfessorTelefoneDDD; 
									strInstituicaoEnsino = m_strRegistroPessoaFisicaProfessorInstituicaoEnsino; 
									strCurso = m_strRegistroPessoaFisicaProfessorCurso; 
									strFase = m_strRegistroPessoaFisicaProfessorFase; 
									strLogradouro = m_strRegistroPessoaFisicaProfessorLogradouro; 
									strComplemento = m_strRegistroPessoaFisicaProfessorComplemento; 
									strBairro = m_strRegistroPessoaFisicaProfessorBairro; 
									strCidade = m_strRegistroPessoaFisicaProfessorCidade; 
									nEstado = m_nRegistroPessoaFisicaProfessorEstado; 
									strCEP = m_strRegistroPessoaFisicaProfessorCep;
								}

								private void formFCategoriaACProfessor_eCallSalvaDados(string strNome ,string strCPF,bool bSexoMasculino ,System.DateTime dtDataNascimento,string strEmail,string strTelefone,string strTelefoneDDD,string strInstituicaoEnsino ,string strCurso ,string strFase ,string strLogradouro ,string strComplemento ,string strBairro ,string strCidade ,int nEstado ,string strCEP)
								{
									m_strRegistroPessoaFisicaProfessorNome = strNome;
									m_strRegistroPessoaFisicaProfessorCPF = strCPF;
									m_bRegistroPessoaFisicaProfessorSexoMasculino = bSexoMasculino;
									m_dtRegistroPessoaFisicaProfessorDataNascimento = dtDataNascimento;
									m_strRegistroPessoaFisicaProfessorEmail = strEmail;
									m_strRegistroPessoaFisicaProfessorTelefone = strTelefone;  
									m_strRegistroPessoaFisicaProfessorTelefoneDDD = strTelefoneDDD;  
									m_strRegistroPessoaFisicaProfessorInstituicaoEnsino = strInstituicaoEnsino; 
									m_strRegistroPessoaFisicaProfessorCurso = strCurso; 
									m_strRegistroPessoaFisicaProfessorFase = strFase; 
									m_strRegistroPessoaFisicaProfessorLogradouro = strLogradouro; 
									m_strRegistroPessoaFisicaProfessorComplemento = strComplemento; 
									m_strRegistroPessoaFisicaProfessorBairro = strBairro; 
									m_strRegistroPessoaFisicaProfessorCidade = strCidade; 
									m_nRegistroPessoaFisicaProfessorEstado = nEstado; 
									m_strRegistroPessoaFisicaProfessorCep = strCEP;
								}
							#endregion
						#endregion
					#endregion
				#endregion
				#region ShowDialogPJExportadorUsuario
					private bool ShowDialogPJExportadorUsuario()
					{
						bool bRetorno = false;
						frmFRegistroCategoriaPJExportadorUsuario formFCategoriaPJExportadorUsuario = new frmFRegistroCategoriaPJExportadorUsuario(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
						vInitializeEvents(ref formFCategoriaPJExportadorUsuario);
						formFCategoriaPJExportadorUsuario.ShowDialog();
						switch(formFCategoriaPJExportadorUsuario.m_enumResposta)
						{
							case mdlRegistro.Resposta.Voltar:
								JanelaAnterior();
								bRetorno = true;
								break;
							case mdlRegistro.Resposta.Cancelar:
								bRetorno = false;
								break;
							case mdlRegistro.Resposta.Continuar:
								JanelaProxima();
								bRetorno = true;
								break;
						}
						return(bRetorno);
					}

					#region InitializeEvents 
						private void vInitializeEvents(ref frmFRegistroCategoriaPJExportadorUsuario formFCategoriaPJExportadorUsuario)
						{
							// Refresh Funcao
							formFCategoriaPJExportadorUsuario.eCallRefreshFuncao += new mdlRegistro.frmFRegistroCategoriaPJExportadorUsuario.delCallRefreshFuncao(vRefreshFuncao);

							// Refresh Sexo
							formFCategoriaPJExportadorUsuario.eCallRefreshSexo += new mdlRegistro.frmFRegistroCategoriaPJExportadorUsuario.delCallRefreshSexo(vRefreshSexo);

							// Carregamento dos Dados 
							formFCategoriaPJExportadorUsuario.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaPJExportadorUsuario.delCallCarregaDados(formFCategoriaPJExportadorUsuario_eCallCarregaDados);

							// Salvamento dos Dados
							formFCategoriaPJExportadorUsuario.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaPJExportadorUsuario.delCallSalvaDados(formFCategoriaPJExportadorUsuario_eCallSalvaDados);
						}

						private void formFCategoriaPJExportadorUsuario_eCallCarregaDados(out string strNome,out string strCPF,out bool bSexoMasculino,out System.DateTime dtDataNascimento,out int nFuncao,out string strTelefone,out string strTelefoneDDD,out string strEmail,out string strRamal ,out string strFax,out string strFaxDDD)
						{
							strNome = m_strRegistroPessoaJuridicaExportadorUsuarioNome;
							strCPF = m_strRegistroPessoaJuridicaExportadorUsuarioCPF;
							bSexoMasculino = m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino;
							dtDataNascimento = m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento;
							nFuncao = m_nRegistroPessoaJuridicaExportadorUsuarioFuncao;
							strTelefone = m_strRegistroPessoaJuridicaExportadorUsuarioTelefone;
							strTelefoneDDD = m_strRegistroPessoaJuridicaExportadorUsuarioTelefoneDDD;
							strEmail = m_strRegistroPessoaJuridicaExportadorUsuarioEmail;
							strRamal = m_strRegistroPessoaJuridicaExportadorUsuarioRamal;
							strFax = m_strRegistroPessoaJuridicaExportadorUsuarioFax;
							strFaxDDD = m_strRegistroPessoaJuridicaExportadorUsuarioFaxDDD;
						}

						private void formFCategoriaPJExportadorUsuario_eCallSalvaDados(string strNome,string strCPF,bool bSexoMasculino, System.DateTime dtDataNascimento,int nFuncao,string strTelefone,string strTelefoneDDD,string strEmail,string strRamal ,string strFax,string strFaxDDD)
						{
							m_strRegistroPessoaJuridicaExportadorUsuarioNome = strNome;
							m_strRegistroPessoaJuridicaExportadorUsuarioCPF = strCPF;
							m_bRegistroPessoaJuridicaExportadorUsuarioSexoMasculino = bSexoMasculino;
							m_dtRegistroPessoaJuridicaExportadorUsuarioDataNascimento = dtDataNascimento;
							m_nRegistroPessoaJuridicaExportadorUsuarioFuncao = nFuncao;
							m_strRegistroPessoaJuridicaExportadorUsuarioTelefone = strTelefone;
							m_strRegistroPessoaJuridicaExportadorUsuarioTelefoneDDD = strTelefoneDDD;
							m_strRegistroPessoaJuridicaExportadorUsuarioEmail = strEmail;
							m_strRegistroPessoaJuridicaExportadorUsuarioRamal = strRamal;
							m_strRegistroPessoaJuridicaExportadorUsuarioFax = strFax;
							m_strRegistroPessoaJuridicaExportadorUsuarioFaxDDD = strFaxDDD;
						}
					#endregion
				#endregion
				#region ShowDialogPJPrestadorServicoUsuario
					private bool ShowDialogPJPrestadorServicoUsuario()
					{
						bool bRetorno = false;
						frmFRegistroCategoriaPJPrestadorServicoUsuario formFCategoriaPJPrestadorServicoUsuario = new frmFRegistroCategoriaPJPrestadorServicoUsuario(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
						vInitializeEvents(ref formFCategoriaPJPrestadorServicoUsuario);
						formFCategoriaPJPrestadorServicoUsuario.ShowDialog();
						switch(formFCategoriaPJPrestadorServicoUsuario.m_enumResposta)
						{
							case mdlRegistro.Resposta.Voltar:
								JanelaAnterior();
								bRetorno = true;
								break;
							case mdlRegistro.Resposta.Cancelar:
								bRetorno = false;
								break;
							case mdlRegistro.Resposta.Continuar:
								JanelaProxima();
								bRetorno = true;
								break;
						}
						return(bRetorno);
					}
					
					#region InitializeEvents
						private void vInitializeEvents(ref frmFRegistroCategoriaPJPrestadorServicoUsuario formFCategoriaPJPrestadorServicoUsuario)
						{
							// Refresh Sexo
							formFCategoriaPJPrestadorServicoUsuario.eCallRefreshSexo += new mdlRegistro.frmFRegistroCategoriaPJPrestadorServicoUsuario.delCallRefreshSexo(vRefreshSexo);

							// Refresh Funcao 
							formFCategoriaPJPrestadorServicoUsuario.eCallRefreshFuncao +=new mdlRegistro.frmFRegistroCategoriaPJPrestadorServicoUsuario.delCallRefreshFuncao(vRefreshFuncao);

							// Carrega Dados 
							formFCategoriaPJPrestadorServicoUsuario.eCallCarregaDados += new mdlRegistro.frmFRegistroCategoriaPJPrestadorServicoUsuario.delCallCarregaDados(formFCategoriaPJPrestadorServicoUsuario_eCallCarregaDados);

							// Salva Dados 
							formFCategoriaPJPrestadorServicoUsuario.eCallSalvaDados += new mdlRegistro.frmFRegistroCategoriaPJPrestadorServicoUsuario.delCallSalvaDados(formFCategoriaPJPrestadorServicoUsuario_eCallSalvaDados);
						}

						private void formFCategoriaPJPrestadorServicoUsuario_eCallCarregaDados(out string strNome,out string strCPF,out bool bSexoMasculino,out System.DateTime dtDataNascimento,out int nFuncao,out string strTelefone,out string strTelefoneDDD,out string strEmail,out string strRamal ,out string strFax,out string strFaxDDD)
						{
							strNome = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome;
							strCPF = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF;
							bSexoMasculino = m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino;
							dtDataNascimento = m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento;
							nFuncao = m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao;
							strTelefone = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone;
							strTelefoneDDD = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefoneDDD;
							strEmail = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail;
							strRamal = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal;
							strFax = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax;
							strFaxDDD = m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFaxDDD;
						}

						private void formFCategoriaPJPrestadorServicoUsuario_eCallSalvaDados(string strNome,string strCPF,bool bSexoMasculino, System.DateTime dtDataNascimento,int nFuncao,string strTelefone,string strTelefoneDDD,string strEmail,string strRamal ,string strFax,string strFaxDDD)
						{
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioNome = strNome;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioCPF = strCPF;
							m_bRegistroPessoaJuridicaPrestadorServicoUsuarioSexoMasculino = bSexoMasculino;
							m_dtRegistroPessoaJuridicaPrestadorServicoUsuarioDataNascimento = dtDataNascimento;
							m_nRegistroPessoaJuridicaPrestadorServicoUsuarioFuncao = nFuncao;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefone = strTelefone;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioTelefoneDDD = strTelefoneDDD;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioEmail = strEmail;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioRamal = strRamal;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFax = strFax;
							m_strRegistroPessoaJuridicaPrestadorServicoUsuarioFaxDDD = strFaxDDD;
						}
					#endregion

				#endregion
				#region ShowDialogInformacoes
					private bool ShowDialogInformacoes()
					{
						bool bRetorno = false;
						frmFRegistroInformacoes formFRegistroInformacoes = new frmFRegistroInformacoes(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
						vInitializeEvents(ref formFRegistroInformacoes);
						formFRegistroInformacoes.ShowDialog();
						switch(formFRegistroInformacoes.m_enumResposta)
						{
							case mdlRegistro.Resposta.Voltar:
								JanelaAnterior();
								bRetorno = true;
								break;
							case mdlRegistro.Resposta.Cancelar:
								bRetorno = false;
								break;
							case mdlRegistro.Resposta.Continuar:
								m_enumJanelaAtual = Janelas.OK;
								bRetorno = true;
								break;
						}
						return(bRetorno);
					}
					#region Initialize Events 
						private void vInitializeEvents(ref frmFRegistroInformacoes formFRegistroInformacoes)
						{
							// Carrega os Dados 
							formFRegistroInformacoes.eCallCarregaDados += new mdlRegistro.frmFRegistroInformacoes.delCallCarregaDados(formFRegistroInformacoes_eCallCarregaDados);

							// Salva os Dados 
							formFRegistroInformacoes.eCallSalvaDados += new mdlRegistro.frmFRegistroInformacoes.delCallSalvaDados(formFRegistroInformacoes_eCallSalvaDados);

							// Generate Cod Client
							formFRegistroInformacoes.eCallCodigoClienteGenerate += new mdlRegistro.frmFRegistroInformacoes.delCallCodigoClienteGenerate(bGenerateCodigoCliente);

							// Salva os Dados no BD
							formFRegistroInformacoes.eCallSalvaDadosBD += new mdlRegistro.frmFRegistroInformacoes.delCallSalvaDadosBD(vSalvaDados);
						}

						private void formFRegistroInformacoes_eCallCarregaDados(out int nRegistroRealizacaoProcessosExportacao,out string strRegistroRealizacaoProcessosExportacao,out int nRegistroConhecimentoSiscobras,out string strRegistroConhecimentoSiscobras)
						{
							nRegistroRealizacaoProcessosExportacao = m_nRegistroRealizacaoProcessosExportacao;
							strRegistroRealizacaoProcessosExportacao = m_strRegistroRealizacaoProcessosExportacao;
							nRegistroConhecimentoSiscobras = m_nRegistroConhecimentoSiscobras;
							strRegistroConhecimentoSiscobras = m_strRegistroConhecimentoSiscobras;
						}

						private void formFRegistroInformacoes_eCallSalvaDados(int nRegistroRealizacaoProcessosExportacao,string strRegistroRealizacaoProcessosExportacao,int nRegistroConhecimentoSiscobras, string strRegistroConhecimentoSiscobras)
						{
							m_nRegistroRealizacaoProcessosExportacao = nRegistroRealizacaoProcessosExportacao;
							m_strRegistroRealizacaoProcessosExportacao = strRegistroRealizacaoProcessosExportacao;
							m_nRegistroConhecimentoSiscobras = nRegistroConhecimentoSiscobras;
							m_strRegistroConhecimentoSiscobras = strRegistroConhecimentoSiscobras;
							vRefreshEmailCliente();
						}
					#endregion
  				#endregion

				#region Checagens 
				internal bool bCadastroRealizado()
				{
					bool bRetorno = false;
					if (enumRetornaJanelaAtual() == Janelas.OK)
					{
						bRetorno = true;
					}  
					return(bRetorno);
				}

				private Janelas enumRetornaJanelaAtual()
				{
					Janelas enumJanela = Janelas.OK;

					// Categoria 
					if (!bCadastroRealizadoCategoria())
					{
						return(Janelas.Categoria);
					}

					// Classificacao
					if (!bCadastroRealizadoClassificacao())
					{
						return(Janelas.Classificacao);
					}
					return(enumJanela);
				}

				private bool bCadastroRealizadoCategoria()
				{
					bool bRetorno = false;
					if (m_enumRegistroClasse != mdlRegistro.RegistroClasse.None)
					{
						bRetorno = true;
					}
					return(bRetorno);
				}

				private bool bCadastroRealizadoClassificacao()
				{
					bool bRetorno = false;
					if (m_strRegistroCodigo != "")
					{
						bRetorno = true;
					}
					return(bRetorno);
				}

				#endregion
				#region Deslocamento 
				private void JanelaAnterior()
				{
					switch(m_enumJanelaAtual)
					{
						case Janelas.Classificacao:
							m_enumJanelaAtual = Janelas.Categoria;
							break;
						case Janelas.Usuario:
							m_enumJanelaAtual = Janelas.Classificacao;
							break;
						case Janelas.Informacoes:
							switch (m_enumRegistroClasse)
							{
								case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
									m_enumJanelaAtual = Janelas.Usuario;
									break;
								case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
									m_enumJanelaAtual = Janelas.Usuario;
									break;
								default:
									m_enumJanelaAtual = Janelas.Classificacao;
									break;
							}
							break;
					}
				}

				private void JanelaProxima()
				{
					switch(m_enumJanelaAtual)
					{
						case Janelas.Categoria:
							m_enumJanelaAtual = Janelas.Classificacao;
							break;
						case Janelas.Classificacao:
							switch (m_enumRegistroClasse)
							{
								case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
									m_enumJanelaAtual = Janelas.Usuario;
									break;
								case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
									m_enumJanelaAtual = Janelas.Usuario;
									break;
								default:
									m_enumJanelaAtual = Janelas.Informacoes;
									break;
							}
							break;
						case Janelas.Usuario:
							m_enumJanelaAtual = Janelas.Informacoes;
							break;
					}
				}
				#endregion
			#endregion
			#region EnvioDados
				public mdlRegistro.Resposta ShowDialogEnvioDadosCadastro()
				{
					bSilent = false;
					frmFEnviaDados formFEnviaDados = new frmFEnviaDados(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
					vInitializeEvents(ref formFEnviaDados);
					formFEnviaDados.ShowDialog();
					mdlRegistro.Resposta enumResposta = mdlRegistro.Resposta.Cancelar;
					formFEnviaDados.vRetornaDados(out enumResposta);
					formFEnviaDados = null;
					return(enumResposta);
				}
			
				private void vInitializeEvents(ref frmFEnviaDados formFEnviaDados)
				{
					// Envio de Dados para o WebService 
					formFEnviaDados.eCallEnviaDadosWebService += new mdlRegistro.frmFEnviaDados.delCallEnviaDadosWebService(bEnviaDadosCadastroWebService);
				}
			#endregion
			#region RequisicaoDados
				public mdlRegistro.Resposta ShowDialogRequisicaoDadosWebService()
				{
					bSilent = false;
					frmFRequisicaoDadosWebService formFRequisicaoDadosWebService = new frmFRequisicaoDadosWebService(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
					vInitializeEvents(ref formFRequisicaoDadosWebService);
					formFRequisicaoDadosWebService.ShowDialog();
					mdlRegistro.Resposta enumResposta = mdlRegistro.Resposta.Cancelar;
					formFRequisicaoDadosWebService.vRetornaDados(out enumResposta);
					if (enumResposta == mdlRegistro.Resposta.Cancelar)
						bSilent = true;
					formFRequisicaoDadosWebService = null;
					return(enumResposta);
				}

				private void vInitializeEvents(ref frmFRequisicaoDadosWebService formFRequisicaoDadosWebService)
				{
					// Requisicao Dados WebService
					formFRequisicaoDadosWebService.eCallRequisicaoDadosWebService += new mdlRegistro.frmFRequisicaoDadosWebService.delCallRequisicaoDadosWebService(bRequisicaoDadosWebService); 
				}
			#endregion
		#endregion
		#region Refresh ComboBoxes
			#region Estados 
				private void vRefreshEstados(ref mdlComponentesGraficos.ComboBox cbEstados)
				{
					// Loading Data if necessary
					if (m_sortListEstadosBrasileiros == null)
					{
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						m_sortListEstadosBrasileiros = new System.Collections.SortedList();
						mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros m_typDatSetEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,null,null);
						mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwEstadoBrasileiro;
						for (int nCont = 0; nCont < m_typDatSetEstadosBrasileiros.tbEstadosBrasileiros.Rows.Count;nCont++)
						{
							dtrwEstadoBrasileiro = (mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow)m_typDatSetEstadosBrasileiros.tbEstadosBrasileiros.Rows[nCont];
							m_sortListEstadosBrasileiros.Add(dtrwEstadoBrasileiro.strSigla,dtrwEstadoBrasileiro.nIdEstado);
						}
						m_typDatSetEstadosBrasileiros = null;
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					}

					// Refreshing the ComboBox 
					cbEstados.Clear();
					for (int nCont = 0 ; nCont < m_sortListEstadosBrasileiros.Count;nCont++)
					{
						cbEstados.AddItem(m_sortListEstadosBrasileiros.GetKey(nCont).ToString(),m_sortListEstadosBrasileiros.GetByIndex(nCont));
					}
				}
			#endregion	
			#region Setor Atividade
				private void vRefreshSetorAtividade(ref mdlComponentesGraficos.ComboBox cbSetorAtividade)
				{
				}
			#endregion
			#region Servicos
				private void vRefreshServicos(ref mdlComponentesGraficos.ComboBox cbServicos)
				{
					cbServicos.Clear();
					cbServicos.AddItem("Assessoria",1);
					cbServicos.AddItem("Auditoria",2);
					cbServicos.AddItem("Consultoria",3);
					cbServicos.AddItem("Despacho Aduaneiro",4);
					cbServicos.AddItem("Transporte",5);
				}
			#endregion
			#region Funcao
				private void vRefreshFuncao(ref mdlComponentesGraficos.ComboBox cbFuncao)
				{
					cbFuncao.Clear();
                    cbFuncao.AddItem("Presidente",1);
					cbFuncao.AddItem("Diretor",2);
					cbFuncao.AddItem("Chefe Setor",3);
					cbFuncao.AddItem("Chefe Departamento",4);
					cbFuncao.AddItem("Assessor",5);
					cbFuncao.AddItem("Estagiário",6);
					cbFuncao.AddItem("Secretário",7);
					cbFuncao.AddItem("Proprietário",8);
				}
			#endregion
			#region Sexo
				private void vRefreshSexo(ref mdlComponentesGraficos.ComboBox cbSexo)
				{
					cbSexo.Clear();
					cbSexo.AddItem("F",0);
					cbSexo.AddItem("M",1);
				}
			#endregion
		#endregion

		#region CodigoCliente
			private string strReturnTextClean(string strText)
			{
				strText = strText.Replace("/","");
				strText = strText.Replace(".","");
				strText = strText.Replace("-","");
				return(strText);
			}

			private bool bGenerateCodigoCliente()
			{
				bool bRetorno = false;
				switch(m_enumRegistroClasse)
				{
					case mdlRegistro.RegistroClasse.PessoaJuridicaExportador:
						m_strCodigoCliente = "11";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaJuridicaExportadorCNPJ);
						bRetorno = (m_strCodigoCliente.Length == 16);
						break;
					case mdlRegistro.RegistroClasse.PessoaJuridicaPrestadorServico:
						m_strCodigoCliente = "12";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaJuridicaPrestadorServicoCNPJ);
						bRetorno = (m_strCodigoCliente.Length == 16);
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaExportador:
						m_strCodigoCliente = "21";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaFisicaExportadorCPF);
						bRetorno = (m_strCodigoCliente.Length == 13);
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaPrestadorServico:
						m_strCodigoCliente = "22";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaFisicaPrestadorServicoCPF);
						bRetorno = (m_strCodigoCliente.Length == 13);
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaEstudante:
						m_strCodigoCliente = "23";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaFisicaEstudanteCPF);
						bRetorno = (m_strCodigoCliente.Length == 13);
						break;
					case mdlRegistro.RegistroClasse.PessoaFisicaProfessor:
						m_strCodigoCliente = "24";
						m_strCodigoCliente += strReturnTextClean(m_strRegistroPessoaFisicaProfessorCPF);
						bRetorno = (m_strCodigoCliente.Length == 13);
						break;
				}
				return(bRetorno);
			}
		#endregion
		#region Email do Cliente
			private void vRefreshEmailCliente()
			{
				// Classe Registro
				switch (m_enumRegistroClasse)
				{
					case RegistroClasse.None:
						m_strEmailCliente = "";
						break;
					case RegistroClasse.PessoaJuridicaExportador:
						m_strEmailCliente = m_strRegistroPessoaJuridicaExportadorEmail;
						break;
					case RegistroClasse.PessoaJuridicaPrestadorServico:
						m_strEmailCliente = m_strRegistroPessoaJuridicaPrestadorServicoEmail;
						break;
					case RegistroClasse.PessoaFisicaExportador:
						m_strEmailCliente = m_strRegistroPessoaFisicaExportadorEmail;
						break;
					case RegistroClasse.PessoaFisicaPrestadorServico:
						m_strEmailCliente = m_strRegistroPessoaFisicaPrestadorServicoEmail;
						break;
					case RegistroClasse.PessoaFisicaEstudante:
						m_strEmailCliente = m_strRegistroPessoaFisicaEstudanteEmail;
						break;
					case RegistroClasse.PessoaFisicaProfessor:
						m_strEmailCliente = m_strRegistroPessoaFisicaProfessorEmail;
						break;
					default:
						m_strEmailCliente = "";
						break;
				}
			}
		#endregion
		#region KeyTime
			public void vKeyTimeGenerate(out string strKeyTime,System.DateTime dtDia,System.DateTime dtAtualizacao,System.DateTime dtVencimento)
			{
				string strRetorno = "";

				// Grouping 
				strRetorno += dtDia.Day.ToString("0#");
				strRetorno += dtAtualizacao.Day.ToString("0#");
				strRetorno += dtVencimento.Day.ToString("0#");
				strRetorno += dtDia.Month.ToString("0#");
				strRetorno += dtAtualizacao.Month.ToString("0#");
				strRetorno += dtVencimento.Month.ToString("0#");
				strRetorno += dtDia.Year.ToString();
				strRetorno += dtAtualizacao.Year.ToString();
				strRetorno += dtVencimento.Year.ToString();
				strRetorno += dtDia.Hour.ToString("0#");
				strRetorno += dtDia.Minute.ToString("0#");
				strRetorno += dtDia.Second.ToString("0#");

				// Inverting 
				strKeyTime = "";
				for(int nCont = 0; nCont < strRetorno.Length;nCont++)
				{
					strKeyTime += char.Parse((9 - Int32.Parse(strRetorno[nCont].ToString())).ToString());
				}

				// Crypt
				strKeyTime = mdlCriptografia.clsCriptografia.strCifraString(strKeyTime);
			}

			public bool bKeyTimeReturn(string strKeyTime,out System.DateTime dtDia,out System.DateTime dtAtualizacao,out System.DateTime dtVencimento)
			{
				bool bRetorno = false;
				System.DateTime dtDiaRetorno = System.DateTime.Now;
				System.DateTime dtAtualizacaoRetorno = System.DateTime.Now;
				System.DateTime dtVencimentoRetorno = System.DateTime.Now;
			
				// Decrypt
				strKeyTime = mdlCriptografia.clsCriptografia.strDecifraString(strKeyTime);

				// Inverting 
				string strKeyTimeRight = "";
				for(int nCont = 0; nCont < strKeyTime.Length;nCont++)
				{
					strKeyTimeRight += char.Parse((9 - Int32.Parse(strKeyTime[nCont].ToString())).ToString());
				}

				//Ungrouping 
				if (strKeyTimeRight.Length == 30)
				{
					dtDiaRetorno = new System.DateTime(Int32.Parse(strKeyTimeRight.Substring(12,4)),Int32.Parse(strKeyTimeRight.Substring(6,2)),Int32.Parse(strKeyTimeRight.Substring(0,2)),Int32.Parse(strKeyTimeRight.Substring(24,2)),Int32.Parse(strKeyTimeRight.Substring(26,2)),Int32.Parse(strKeyTimeRight.Substring(28,2)));
					dtAtualizacaoRetorno = new System.DateTime(Int32.Parse(strKeyTimeRight.Substring(16,4)),Int32.Parse(strKeyTimeRight.Substring(8,2)),Int32.Parse(strKeyTimeRight.Substring(2,2)));
					dtVencimentoRetorno = new System.DateTime(Int32.Parse(strKeyTimeRight.Substring(20,4)),Int32.Parse(strKeyTimeRight.Substring(10,2)),Int32.Parse(strKeyTimeRight.Substring(4,2)));
					bRetorno = true;
				}
				dtDia = dtDiaRetorno;
				dtAtualizacao = dtAtualizacaoRetorno;
				dtVencimento = dtVencimentoRetorno;
				return(bRetorno);
			}
		#endregion
		#region KeyFile
			private void vKeyFileKill()
			{
				if (System.IO.File.Exists(m_strEnderecoExecutavel + KEYFILE))
					System.IO.File.Delete(m_strEnderecoExecutavel + KEYFILE);
			}

			public bool bKeyFileGenerate(string strMessage)
			{
				bool bReturn = false;
				if (System.IO.File.Exists(m_strEnderecoExecutavel + KEYFILE))
					System.IO.File.Delete(m_strEnderecoExecutavel + KEYFILE);
				if (strMessage.Trim() != "")
				{
					string strMensagemCifrada = mdlCriptografia.clsCriptografia.strCifraString(strMessage);
					System.IO.Stream stFile = System.IO.File.OpenWrite(m_strEnderecoExecutavel + KEYFILE);
					System.IO.BinaryWriter biwtFile = new System.IO.BinaryWriter(stFile);
					System.DateTime dtKey = new System.DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
					biwtFile.Write(dtKey.ToString());
					biwtFile.Write(strMensagemCifrada);
					biwtFile.Close();
					stFile.Close();
					System.IO.File.SetLastWriteTime(m_strEnderecoExecutavel + KEYFILE,dtKey);
					bReturn = true;
				}
				return(bReturn);
			}

			public bool bKeyFileCheck(string strMessage)
			{
				bool bReturn = false;
				if (strMessage.Trim() != "")
				{
					if (!System.IO.File.Exists(m_strEnderecoExecutavel + KEYFILE))
						bKeyFileGenerate(strMessage);
					if (!System.IO.File.Exists(m_strEnderecoExecutavel + KEYFILE))
						return(false);
					System.DateTime dtLastWriteTime = System.IO.File.GetLastWriteTime(m_strEnderecoExecutavel + KEYFILE);
					System.IO.Stream stFile = System.IO.File.OpenRead(m_strEnderecoExecutavel + KEYFILE);
					System.IO.BinaryReader birdFile = new System.IO.BinaryReader(stFile);
					birdFile.ReadChar();
					string strDataKeyInFile = new string(birdFile.ReadChars(System.DateTime.Now.ToString().Length));
					System.DateTime dtKey;
					try
					{
						dtKey = System.DateTime.Parse(strDataKeyInFile);
					}catch{
						return(false);
					}
					string strMensagemCifrada = "";
					birdFile.ReadChar();
					while (birdFile.PeekChar() != -1)
						strMensagemCifrada += birdFile.ReadChar();
					birdFile.Close();
					stFile.Close();
					string strMensagemDecifrada = mdlCriptografia.clsCriptografia.strDecifraString(strMensagemCifrada);
					bReturn = ((strMessage == strMensagemDecifrada) && (dtLastWriteTime.Subtract(dtKey).Seconds == 0));
				}
				return(bReturn);
			}
		#endregion
		#region Sincronismo
			public void vSincronizaDados(int nIdCliente,ref clsRegistroWebService cls_webService_Registro)
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_cls_dba_ConnectionDB.DataPersist = false;
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(null,null,null,null,null);
				cls_webService_Registro.bSincronizacaoAdiciona(nIdCliente,mdlCriptografia.clsCriptografia.strCifraString(typDatSetTbPes.tbPEs.Count.ToString()));
			}
		#endregion
	}
}
