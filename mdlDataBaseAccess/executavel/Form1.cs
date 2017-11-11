using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region MAIN
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Constantes
			private const string COMPARADOR_IGUAL = "=";
			private const string COMPARADOR_DIFERENTE = "!=";
			private const string COMPARADOR_MAIOR = ">";
			private const string COMPARADOR_MENOR = "<";
			private const string COMPARADOR_MAIOR_IGUAL = ">=";
			private const string COMPARADOR_MENOR_IGUAL = "<=";
		#endregion
		#region Atributos
		    private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_conexaoBD;
		    private System.Collections.ArrayList m_arlCondicaoCampo = new System.Collections.ArrayList();
			private System.Collections.ArrayList m_arlCondicaoComparador = new System.Collections.ArrayList();
			private System.Collections.ArrayList m_arlCondicaoValor = new System.Collections.ArrayList();

		    private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
        	
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbOutPut;
			private System.Windows.Forms.DataGrid m_dgOutput;
			private System.Windows.Forms.GroupBox m_gbDataAccess;
			private System.Windows.Forms.RadioButton m_rbDataAccessOleDBJet;
			private System.Windows.Forms.GroupBox m_gbDados;
			private System.Windows.Forms.GroupBox m_gbAcao;
			private System.Windows.Forms.Button m_btGet;
			private System.Windows.Forms.Button m_btSet;
			private System.Windows.Forms.RadioButton m_rbTbProdutos;
			private System.Windows.Forms.GroupBox m_dgPath;
			private System.Windows.Forms.RadioButton m_rbTbExportadores;
			private System.Windows.Forms.RadioButton m_rbDataAccessMySQL;
			private System.Windows.Forms.TextBox m_txtPathFireBird;
			private System.Windows.Forms.Label m_lbPathFirebird;
			private System.Windows.Forms.TextBox m_txtPathJet40;
			private System.Windows.Forms.Label m_lbPathJet40;
			private System.Windows.Forms.Label m_lbDataBaseName;
			private System.Windows.Forms.TextBox m_txtDataBaseName;
			private System.Windows.Forms.RadioButton m_rbTbMoedas;
			private System.Windows.Forms.RadioButton m_rbTbFaturasComerciais;
			private System.Windows.Forms.RadioButton m_rbTbFaturasCotacoes;
			private System.Windows.Forms.RadioButton m_rbTbFaturasProformas;
			private System.Windows.Forms.GroupBox m_gbLogin;
			private System.Windows.Forms.Label m_lbUser;
			private System.Windows.Forms.Label m_lbPassword;
			private System.Windows.Forms.TextBox m_txtUser;
			private System.Windows.Forms.TextBox m_txtPassword;
			private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaComercial;
			private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaProforma;
			private System.Windows.Forms.RadioButton m_rbTbProdutosIdiomas;
			private System.Windows.Forms.RadioButton m_rbTbIdiomas;
			private System.Windows.Forms.Label m_lbHost;
			private System.Windows.Forms.TextBox m_txtHost;
			private System.Windows.Forms.GroupBox m_gbCondicoes;
			private System.Windows.Forms.TextBox m_txtCondicaoCampo;
			private System.Windows.Forms.ComboBox m_cbCondicaoComparador;
			private System.Windows.Forms.TextBox m_txtCondicaoValor;
			private System.Windows.Forms.Button m_btCondicaoClear;
			private System.Windows.Forms.Button m_btCondicaoInsert;
			private System.Windows.Forms.RadioButton m_rbTbIdiomasTextos;
			private System.Windows.Forms.RadioButton m_rbTbPaises;
			private System.Windows.Forms.RadioButton m_rbTbPaisesIdiomas;
			private System.Windows.Forms.RadioButton m_rbTbImportadores;
			private System.Windows.Forms.RadioButton m_rbTbImportadoresConsignatarios;
			private System.Windows.Forms.RadioButton m_rbTbImportadoresEndEntrega;
			private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioEmbalagens;
			private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaCotacao;
			private System.Windows.Forms.RadioButton m_rbTbEstadosBrasileiros;
			private System.Windows.Forms.RadioButton m_rbTbExportadoresBancos;
			private System.Windows.Forms.RadioButton m_rbTbExportadoresBancosAgencias;
			private System.Windows.Forms.RadioButton m_rbTbExportadoresBancosAgenciasContas;
			private System.Windows.Forms.RadioButton m_rbTbImportadoresBancos;
			private System.Windows.Forms.RadioButton m_rbTbExportadoresVolumes;
			private System.Windows.Forms.RadioButton m_rbTbVolumes;
			private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioEmbalagensProdutos;
			private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioVolumes;
			private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioVolumesEmbalagens;
			private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioVolumesProdutos;
		private System.Windows.Forms.RadioButton m_rbTbUnidadesEspaco;
		private System.Windows.Forms.RadioButton m_rbTbUnidadesEspacoIdioma;
		private System.Windows.Forms.RadioButton m_rbTbUnidadesMassa;
		private System.Windows.Forms.RadioButton m_rbTbUnidadesMassaIdioma;
		private System.Windows.Forms.RadioButton m_rbTbPes;
		private System.Windows.Forms.RadioButton m_rbTbAssinaturas;
		private System.Windows.Forms.RadioButton m_rbTbCertificadosOrigem;
		private System.Windows.Forms.RadioButton m_rbTbInstrucoesEmbarque;
		private System.Windows.Forms.RadioButton m_rbTbSaques;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioCamposBD;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioRetangulos;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioLinhas;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioImagens;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioEtiquetas;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioCirculos;
		private System.Windows.Forms.RadioButton m_rbTbRelatorios;
		private System.Windows.Forms.RadioButton m_rbTbImagens;
		private System.Windows.Forms.RadioButton m_rbTbRelatoriosCamposBDPreRequisitos;
		private System.Windows.Forms.RadioButton m_rbTbRelatoriosCamposBDRelatorios;
		private System.Windows.Forms.RadioButton m_rbTbRelatoriosTodosCamposBD;
		private System.Windows.Forms.RadioButton m_rbTbRelatorioTipo;
		private System.Windows.Forms.RadioButton m_rbTbBorderos;
		private System.Windows.Forms.RadioButton m_rbTbRomaneios;
		private System.Windows.Forms.RadioButton m_rbTbSumarios;
		private System.Windows.Forms.RadioButton m_rbTbProdutosParents;
		private System.Windows.Forms.RadioButton m_rbTbProdutosCertificadoOrigem;
		private System.Windows.Forms.RadioButton m_rbTbProdutosNaladi;
		private System.Windows.Forms.RadioButton m_rbTbProdutosNcm;
		private System.Windows.Forms.RadioButton m_rbTbProdutosCategoria;
		private System.Windows.Forms.RadioButton m_rbTbModulos;
		private System.Windows.Forms.RadioButton m_rbTbVersao;
		private System.Windows.Forms.RadioButton m_rbTbVersaoModulo;
		private System.Windows.Forms.RadioButton m_rbTbWebServiceServicos;
		private System.Windows.Forms.RadioButton m_rbTbWebServiceServidores;
		private System.Windows.Forms.RadioButton m_rbTbWebServiceServidoresServicos;
		private System.Windows.Forms.RadioButton m_rbTbCertificadosOrigemNormas;
		private System.Windows.Forms.RadioButton m_rbTbUsuarios;
		private System.Windows.Forms.GroupBox m_gbConfiguracao;
		private System.Windows.Forms.TextBox m_txtConfiguracaoVariavel;
		private System.Windows.Forms.Label m_lbConfiguracaoVariavel;
		private System.Windows.Forms.Label m_lbConfiguracaoValor;
		private System.Windows.Forms.TextBox m_txtConfiguracaoValor;
		private System.Windows.Forms.Label m_lbConfiguracaoValorDefault;
		private System.Windows.Forms.TextBox m_txtConfiguracaoValorDefault;
		private System.Windows.Forms.Button m_btConfiguracaoGetStr;
		private System.Windows.Forms.Button m_btConfiguracaoGetInt;
		private System.Windows.Forms.Button m_btConfiguracaoGetDataTime;
		private System.Windows.Forms.Button m_btConfiguracaoSet;
		private System.Windows.Forms.TextBox m_txtConfiguracaoRetorno;
		private System.Windows.Forms.RadioButton m_rbTbUsuariosConcessoes;
		private System.Windows.Forms.RadioButton m_rbTbUsuariosConcessoesPermissoes;
		private System.Windows.Forms.RadioButton m_rbTbUsuariosPermissoes;
		private System.Windows.Forms.RadioButton m_rbTbUsuariosPermissoesConcessoes;
		private System.Windows.Forms.RadioButton m_rbTbErros;
		private System.Windows.Forms.GroupBox m_gbIntegridade;
		private System.Windows.Forms.RadioButton m_rbTbLogMedicaoTempo;
		private System.Windows.Forms.Label m_lbPortMysql;
		private System.Windows.Forms.TextBox m_txtPortMysql;
		private System.Windows.Forms.GroupBox m_gbConnectionType;
		private System.Windows.Forms.RadioButton m_rbConnectionTypeTCP;
		private System.Windows.Forms.RadioButton m_rbConnectionTypePath;
		private System.Windows.Forms.CheckBox m_ckMultiTable;
		private System.Windows.Forms.RadioButton m_rbTbDespachantes;
		private System.Windows.Forms.RadioButton m_rbTbMaquinas;
		private System.Windows.Forms.RadioButton m_rbTbExportadoresAgentesVendas;
		private System.Windows.Forms.RadioButton m_rbTbExportadoresAgentesVendasBancos;
		private System.Windows.Forms.Button m_btConfiguracaoLoad;
		private System.Windows.Forms.Button m_btConfiguracaoClear;
		private System.Windows.Forms.Button m_btConfiguracaoSave;
		private System.Windows.Forms.Button m_btUpdateDataBase;
		private System.Windows.Forms.CheckBox m_ckFonteDadosResource;
		private System.Windows.Forms.RadioButton m_rbTbCartasCredito;
		private System.Windows.Forms.GroupBox m_gbPersistencia;
		private System.Windows.Forms.CheckBox m_ckPersistData;
		private System.Windows.Forms.CheckBox m_ckPersistDB;
		private System.Windows.Forms.RadioButton m_rbTbContratosCambio;
		private System.Windows.Forms.RadioButton m_rbTbProdutosBordero;
		private System.Windows.Forms.RadioButton m_rbTbNotasFiscais;
		private System.Windows.Forms.RadioButton m_rbTbBorderosSecundarios;
		private System.Windows.Forms.RadioButton m_rbDataAccessSQLSERVER;
		private System.Windows.Forms.TextBox m_txtPortSqlServer;
		private System.Windows.Forms.Label m_lbPortSqlServer;
		private System.Windows.Forms.CheckBox m_ckDontPutDataInDataGrid;
		private System.Windows.Forms.Button m_btAllRowsNew;
		private System.Windows.Forms.CheckBox m_ckIntegrityUpdate;
		private System.Windows.Forms.Button m_btRelatoriosPadrao;
		private System.Windows.Forms.CheckBox m_ckWriteXML;
		private System.Windows.Forms.RadioButton m_rbTbRomaneiosSecundarios;
		private System.Windows.Forms.RadioButton m_rbTbProdutosRomaneioSimplificado;
		private System.Windows.Forms.RadioButton m_rbTbConfiguracoes;
		private System.Windows.Forms.RadioButton m_rbTbProcessosContainers;
		private System.Windows.Forms.RadioButton m_rbTbAgentesCargas;
		private System.Windows.Forms.RadioButton m_rbTbAgentesCargasContatos;
		private System.Windows.Forms.RadioButton m_rbTbArmadores;
		private System.Windows.Forms.RadioButton m_rbTbArmadoresNavios;
		private System.Windows.Forms.RadioButton m_rbTbTransportadoras;
		private System.Windows.Forms.RadioButton m_rbTbTransportadorasMotoristas;
		private System.Windows.Forms.RadioButton m_rbTbTransportadorasVeiculos;
		private System.Windows.Forms.RadioButton m_rbTbTransportadorasContatos;
		private System.Windows.Forms.RadioButton m_rbTbTerminais;
		private System.Windows.Forms.RadioButton m_rbTbTerminaisContatos;
		private System.Windows.Forms.RadioButton m_rbTbReservas;
		private System.Windows.Forms.RadioButton m_rbTbGuiasEntrada;
		private System.Windows.Forms.RadioButton m_rbTbDespachantesContatos;
		private System.Windows.Forms.RadioButton m_rbTbMensagens;
		private System.Windows.Forms.RadioButton m_rbDataAccessFireBird;
		private System.Windows.Forms.TextBox m_txtPortFireBird;
		private System.Windows.Forms.Label m_lbPortFireBird;
		private System.Windows.Forms.GroupBox m_gbAdmin;
		private System.Windows.Forms.Label m_lbAdminUser;
		private System.Windows.Forms.Label m_lbAdminPassword;
		private System.Windows.Forms.TextBox m_txtAdminUser;
		private System.Windows.Forms.TextBox m_txtAdminPassword;
		private System.Windows.Forms.Button m_btAdminCreateDataBase;
		private System.Windows.Forms.Button m_btUserAvailable;
		private System.Windows.Forms.Button m_btAdminUserAssociated;
		private System.Windows.Forms.Button m_btAdminDataBaseAvailable;
		private System.Windows.Forms.Button m_btAdminCreateUser;
		private System.Windows.Forms.Button m_btAdminUserAssociate;
		private System.Windows.Forms.RadioButton m_rbTbDSEs;
		private System.Windows.Forms.RadioButton m_rbTbREs;
		private System.Windows.Forms.RadioButton m_rbTbSDs;
		private System.Windows.Forms.RadioButton m_rbTbREsPEs;
		private System.Windows.Forms.RadioButton m_rbTbDSEsPEs;
		private System.Windows.Forms.RadioButton m_rbtbStatisticReports;
		private System.Windows.Forms.RadioButton m_rbtbStatisticDataManipuators;
		private System.Windows.Forms.RadioButton m_rbTbProdutosCertificadoOrigemFormA;
		private System.Windows.Forms.RadioButton m_rbTbProdutosCertificadoOrigemFormARE;
		private System.Windows.Forms.RadioButton m_rbTbPropriedadesProdutos;
		private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaComercialPropriedades;
		private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaCotacaoPropriedades;
		private System.Windows.Forms.RadioButton m_rbTbProdutosFaturaProformaPropriedades;
		private System.Windows.Forms.Button m_btDeleteAllDataBase;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor and Destructors
			public Form1()
			{
				InitializeComponent();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbAdmin = new System.Windows.Forms.GroupBox();
			this.m_btAdminUserAssociate = new System.Windows.Forms.Button();
			this.m_btAdminDataBaseAvailable = new System.Windows.Forms.Button();
			this.m_btAdminUserAssociated = new System.Windows.Forms.Button();
			this.m_btAdminCreateUser = new System.Windows.Forms.Button();
			this.m_btUserAvailable = new System.Windows.Forms.Button();
			this.m_btAdminCreateDataBase = new System.Windows.Forms.Button();
			this.m_txtAdminPassword = new System.Windows.Forms.TextBox();
			this.m_txtAdminUser = new System.Windows.Forms.TextBox();
			this.m_lbAdminPassword = new System.Windows.Forms.Label();
			this.m_lbAdminUser = new System.Windows.Forms.Label();
			this.m_ckWriteXML = new System.Windows.Forms.CheckBox();
			this.m_btAllRowsNew = new System.Windows.Forms.Button();
			this.m_ckDontPutDataInDataGrid = new System.Windows.Forms.CheckBox();
			this.m_gbPersistencia = new System.Windows.Forms.GroupBox();
			this.m_ckPersistDB = new System.Windows.Forms.CheckBox();
			this.m_ckPersistData = new System.Windows.Forms.CheckBox();
			this.m_btUpdateDataBase = new System.Windows.Forms.Button();
			this.m_gbConnectionType = new System.Windows.Forms.GroupBox();
			this.m_btRelatoriosPadrao = new System.Windows.Forms.Button();
			this.m_ckFonteDadosResource = new System.Windows.Forms.CheckBox();
			this.m_rbConnectionTypePath = new System.Windows.Forms.RadioButton();
			this.m_rbConnectionTypeTCP = new System.Windows.Forms.RadioButton();
			this.m_gbIntegridade = new System.Windows.Forms.GroupBox();
			this.m_ckIntegrityUpdate = new System.Windows.Forms.CheckBox();
			this.m_ckMultiTable = new System.Windows.Forms.CheckBox();
			this.m_gbConfiguracao = new System.Windows.Forms.GroupBox();
			this.m_btConfiguracaoSave = new System.Windows.Forms.Button();
			this.m_btConfiguracaoClear = new System.Windows.Forms.Button();
			this.m_btConfiguracaoLoad = new System.Windows.Forms.Button();
			this.m_txtConfiguracaoRetorno = new System.Windows.Forms.TextBox();
			this.m_btConfiguracaoSet = new System.Windows.Forms.Button();
			this.m_btConfiguracaoGetDataTime = new System.Windows.Forms.Button();
			this.m_btConfiguracaoGetInt = new System.Windows.Forms.Button();
			this.m_btConfiguracaoGetStr = new System.Windows.Forms.Button();
			this.m_lbConfiguracaoValorDefault = new System.Windows.Forms.Label();
			this.m_txtConfiguracaoValorDefault = new System.Windows.Forms.TextBox();
			this.m_lbConfiguracaoValor = new System.Windows.Forms.Label();
			this.m_txtConfiguracaoValor = new System.Windows.Forms.TextBox();
			this.m_lbConfiguracaoVariavel = new System.Windows.Forms.Label();
			this.m_txtConfiguracaoVariavel = new System.Windows.Forms.TextBox();
			this.m_gbCondicoes = new System.Windows.Forms.GroupBox();
			this.m_btCondicaoInsert = new System.Windows.Forms.Button();
			this.m_btCondicaoClear = new System.Windows.Forms.Button();
			this.m_txtCondicaoValor = new System.Windows.Forms.TextBox();
			this.m_cbCondicaoComparador = new System.Windows.Forms.ComboBox();
			this.m_txtCondicaoCampo = new System.Windows.Forms.TextBox();
			this.m_gbLogin = new System.Windows.Forms.GroupBox();
			this.m_txtHost = new System.Windows.Forms.TextBox();
			this.m_lbHost = new System.Windows.Forms.Label();
			this.m_txtPassword = new System.Windows.Forms.TextBox();
			this.m_txtUser = new System.Windows.Forms.TextBox();
			this.m_lbPassword = new System.Windows.Forms.Label();
			this.m_lbUser = new System.Windows.Forms.Label();
			this.m_dgPath = new System.Windows.Forms.GroupBox();
			this.m_txtDataBaseName = new System.Windows.Forms.TextBox();
			this.m_lbDataBaseName = new System.Windows.Forms.Label();
			this.m_txtPathFireBird = new System.Windows.Forms.TextBox();
			this.m_lbPathFirebird = new System.Windows.Forms.Label();
			this.m_txtPathJet40 = new System.Windows.Forms.TextBox();
			this.m_lbPathJet40 = new System.Windows.Forms.Label();
			this.m_gbAcao = new System.Windows.Forms.GroupBox();
			this.m_btSet = new System.Windows.Forms.Button();
			this.m_btGet = new System.Windows.Forms.Button();
			this.m_gbDados = new System.Windows.Forms.GroupBox();
			this.m_rbTbProdutosFaturaProformaPropriedades = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosFaturaCotacaoPropriedades = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosCertificadoOrigemFormARE = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosCertificadoOrigemFormA = new System.Windows.Forms.RadioButton();
			this.m_rbtbStatisticReports = new System.Windows.Forms.RadioButton();
			this.m_rbtbStatisticDataManipuators = new System.Windows.Forms.RadioButton();
			this.m_rbTbDSEsPEs = new System.Windows.Forms.RadioButton();
			this.m_rbTbREsPEs = new System.Windows.Forms.RadioButton();
			this.m_rbTbSDs = new System.Windows.Forms.RadioButton();
			this.m_rbTbREs = new System.Windows.Forms.RadioButton();
			this.m_rbTbDSEs = new System.Windows.Forms.RadioButton();
			this.m_rbTbDespachantesContatos = new System.Windows.Forms.RadioButton();
			this.m_rbTbGuiasEntrada = new System.Windows.Forms.RadioButton();
			this.m_rbTbReservas = new System.Windows.Forms.RadioButton();
			this.m_rbTbTerminaisContatos = new System.Windows.Forms.RadioButton();
			this.m_rbTbTerminais = new System.Windows.Forms.RadioButton();
			this.m_rbTbTransportadorasContatos = new System.Windows.Forms.RadioButton();
			this.m_rbTbTransportadorasVeiculos = new System.Windows.Forms.RadioButton();
			this.m_rbTbTransportadorasMotoristas = new System.Windows.Forms.RadioButton();
			this.m_rbTbTransportadoras = new System.Windows.Forms.RadioButton();
			this.m_rbTbArmadoresNavios = new System.Windows.Forms.RadioButton();
			this.m_rbTbArmadores = new System.Windows.Forms.RadioButton();
			this.m_rbTbAgentesCargasContatos = new System.Windows.Forms.RadioButton();
			this.m_rbTbAgentesCargas = new System.Windows.Forms.RadioButton();
			this.m_rbTbProcessosContainers = new System.Windows.Forms.RadioButton();
			this.m_rbTbConfiguracoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioSimplificado = new System.Windows.Forms.RadioButton();
			this.m_rbTbRomaneiosSecundarios = new System.Windows.Forms.RadioButton();
			this.m_rbTbBorderosSecundarios = new System.Windows.Forms.RadioButton();
			this.m_rbTbNotasFiscais = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosBordero = new System.Windows.Forms.RadioButton();
			this.m_rbTbContratosCambio = new System.Windows.Forms.RadioButton();
			this.m_rbTbCartasCredito = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresAgentesVendasBancos = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresAgentesVendas = new System.Windows.Forms.RadioButton();
			this.m_rbTbMaquinas = new System.Windows.Forms.RadioButton();
			this.m_rbTbDespachantes = new System.Windows.Forms.RadioButton();
			this.m_rbTbLogMedicaoTempo = new System.Windows.Forms.RadioButton();
			this.m_rbTbErros = new System.Windows.Forms.RadioButton();
			this.m_rbTbUsuariosPermissoesConcessoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbUsuariosPermissoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbUsuariosConcessoesPermissoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbUsuariosConcessoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbUsuarios = new System.Windows.Forms.RadioButton();
			this.m_rbTbCertificadosOrigemNormas = new System.Windows.Forms.RadioButton();
			this.m_rbTbWebServiceServidoresServicos = new System.Windows.Forms.RadioButton();
			this.m_rbTbWebServiceServidores = new System.Windows.Forms.RadioButton();
			this.m_rbTbWebServiceServicos = new System.Windows.Forms.RadioButton();
			this.m_rbTbVersaoModulo = new System.Windows.Forms.RadioButton();
			this.m_rbTbVersao = new System.Windows.Forms.RadioButton();
			this.m_rbTbModulos = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosCategoria = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosNcm = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosNaladi = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosCertificadoOrigem = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosParents = new System.Windows.Forms.RadioButton();
			this.m_rbTbSumarios = new System.Windows.Forms.RadioButton();
			this.m_rbTbRomaneios = new System.Windows.Forms.RadioButton();
			this.m_rbTbBorderos = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioTipo = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatoriosTodosCamposBD = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatoriosCamposBDRelatorios = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatoriosCamposBDPreRequisitos = new System.Windows.Forms.RadioButton();
			this.m_rbTbImagens = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioCamposBD = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioRetangulos = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioLinhas = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioImagens = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioEtiquetas = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorioCirculos = new System.Windows.Forms.RadioButton();
			this.m_rbTbRelatorios = new System.Windows.Forms.RadioButton();
			this.m_rbTbSaques = new System.Windows.Forms.RadioButton();
			this.m_rbTbCertificadosOrigem = new System.Windows.Forms.RadioButton();
			this.m_rbTbAssinaturas = new System.Windows.Forms.RadioButton();
			this.m_rbTbPes = new System.Windows.Forms.RadioButton();
			this.m_rbTbUnidadesMassaIdioma = new System.Windows.Forms.RadioButton();
			this.m_rbTbUnidadesMassa = new System.Windows.Forms.RadioButton();
			this.m_rbTbUnidadesEspacoIdioma = new System.Windows.Forms.RadioButton();
			this.m_rbTbUnidadesEspaco = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioVolumesProdutos = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioVolumesEmbalagens = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioVolumes = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioEmbalagensProdutos = new System.Windows.Forms.RadioButton();
			this.m_rbTbVolumes = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresVolumes = new System.Windows.Forms.RadioButton();
			this.m_rbTbImportadoresBancos = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresBancosAgenciasContas = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresBancosAgencias = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadoresBancos = new System.Windows.Forms.RadioButton();
			this.m_rbTbEstadosBrasileiros = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosRomaneioEmbalagens = new System.Windows.Forms.RadioButton();
			this.m_rbTbImportadoresConsignatarios = new System.Windows.Forms.RadioButton();
			this.m_rbTbImportadores = new System.Windows.Forms.RadioButton();
			this.m_rbTbPaisesIdiomas = new System.Windows.Forms.RadioButton();
			this.m_rbTbPaises = new System.Windows.Forms.RadioButton();
			this.m_rbTbIdiomasTextos = new System.Windows.Forms.RadioButton();
			this.m_rbTbIdiomas = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosIdiomas = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosFaturaProforma = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosFaturaComercial = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosFaturaCotacao = new System.Windows.Forms.RadioButton();
			this.m_rbTbFaturasProformas = new System.Windows.Forms.RadioButton();
			this.m_rbTbFaturasCotacoes = new System.Windows.Forms.RadioButton();
			this.m_rbTbFaturasComerciais = new System.Windows.Forms.RadioButton();
			this.m_rbTbMoedas = new System.Windows.Forms.RadioButton();
			this.m_rbTbExportadores = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutos = new System.Windows.Forms.RadioButton();
			this.m_rbTbInstrucoesEmbarque = new System.Windows.Forms.RadioButton();
			this.m_rbTbMensagens = new System.Windows.Forms.RadioButton();
			this.m_rbTbImportadoresEndEntrega = new System.Windows.Forms.RadioButton();
			this.m_rbTbPropriedadesProdutos = new System.Windows.Forms.RadioButton();
			this.m_rbTbProdutosFaturaComercialPropriedades = new System.Windows.Forms.RadioButton();
			this.m_gbDataAccess = new System.Windows.Forms.GroupBox();
			this.m_txtPortFireBird = new System.Windows.Forms.TextBox();
			this.m_lbPortFireBird = new System.Windows.Forms.Label();
			this.m_rbDataAccessFireBird = new System.Windows.Forms.RadioButton();
			this.m_txtPortSqlServer = new System.Windows.Forms.TextBox();
			this.m_lbPortSqlServer = new System.Windows.Forms.Label();
			this.m_txtPortMysql = new System.Windows.Forms.TextBox();
			this.m_lbPortMysql = new System.Windows.Forms.Label();
			this.m_rbDataAccessSQLSERVER = new System.Windows.Forms.RadioButton();
			this.m_rbDataAccessMySQL = new System.Windows.Forms.RadioButton();
			this.m_rbDataAccessOleDBJet = new System.Windows.Forms.RadioButton();
			this.m_gbOutPut = new System.Windows.Forms.GroupBox();
			this.m_dgOutput = new System.Windows.Forms.DataGrid();
			this.m_btDeleteAllDataBase = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbAdmin.SuspendLayout();
			this.m_gbPersistencia.SuspendLayout();
			this.m_gbConnectionType.SuspendLayout();
			this.m_gbIntegridade.SuspendLayout();
			this.m_gbConfiguracao.SuspendLayout();
			this.m_gbCondicoes.SuspendLayout();
			this.m_gbLogin.SuspendLayout();
			this.m_dgPath.SuspendLayout();
			this.m_gbAcao.SuspendLayout();
			this.m_gbDados.SuspendLayout();
			this.m_gbDataAccess.SuspendLayout();
			this.m_gbOutPut.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_btDeleteAllDataBase);
			this.m_gbGeral.Controls.Add(this.m_gbAdmin);
			this.m_gbGeral.Controls.Add(this.m_ckWriteXML);
			this.m_gbGeral.Controls.Add(this.m_btAllRowsNew);
			this.m_gbGeral.Controls.Add(this.m_ckDontPutDataInDataGrid);
			this.m_gbGeral.Controls.Add(this.m_gbPersistencia);
			this.m_gbGeral.Controls.Add(this.m_btUpdateDataBase);
			this.m_gbGeral.Controls.Add(this.m_gbConnectionType);
			this.m_gbGeral.Controls.Add(this.m_gbIntegridade);
			this.m_gbGeral.Controls.Add(this.m_gbConfiguracao);
			this.m_gbGeral.Controls.Add(this.m_gbCondicoes);
			this.m_gbGeral.Controls.Add(this.m_gbLogin);
			this.m_gbGeral.Controls.Add(this.m_dgPath);
			this.m_gbGeral.Controls.Add(this.m_gbAcao);
			this.m_gbGeral.Controls.Add(this.m_gbDados);
			this.m_gbGeral.Controls.Add(this.m_gbDataAccess);
			this.m_gbGeral.Controls.Add(this.m_gbOutPut);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(1107, 791);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbAdmin
			// 
			this.m_gbAdmin.Controls.Add(this.m_btAdminUserAssociate);
			this.m_gbAdmin.Controls.Add(this.m_btAdminDataBaseAvailable);
			this.m_gbAdmin.Controls.Add(this.m_btAdminUserAssociated);
			this.m_gbAdmin.Controls.Add(this.m_btAdminCreateUser);
			this.m_gbAdmin.Controls.Add(this.m_btUserAvailable);
			this.m_gbAdmin.Controls.Add(this.m_btAdminCreateDataBase);
			this.m_gbAdmin.Controls.Add(this.m_txtAdminPassword);
			this.m_gbAdmin.Controls.Add(this.m_txtAdminUser);
			this.m_gbAdmin.Controls.Add(this.m_lbAdminPassword);
			this.m_gbAdmin.Controls.Add(this.m_lbAdminUser);
			this.m_gbAdmin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAdmin.Location = new System.Drawing.Point(728, 8);
			this.m_gbAdmin.Name = "m_gbAdmin";
			this.m_gbAdmin.Size = new System.Drawing.Size(368, 88);
			this.m_gbAdmin.TabIndex = 29;
			this.m_gbAdmin.TabStop = false;
			this.m_gbAdmin.Text = "Admin";
			// 
			// m_btAdminUserAssociate
			// 
			this.m_btAdminUserAssociate.Location = new System.Drawing.Point(248, 56);
			this.m_btAdminUserAssociate.Name = "m_btAdminUserAssociate";
			this.m_btAdminUserAssociate.Size = new System.Drawing.Size(112, 24);
			this.m_btAdminUserAssociate.TabIndex = 18;
			this.m_btAdminUserAssociate.Text = "User Associate";
			this.m_btAdminUserAssociate.Click += new System.EventHandler(this.m_btAdminUserAssociate_Click);
			// 
			// m_btAdminDataBaseAvailable
			// 
			this.m_btAdminDataBaseAvailable.Location = new System.Drawing.Point(135, 9);
			this.m_btAdminDataBaseAvailable.Name = "m_btAdminDataBaseAvailable";
			this.m_btAdminDataBaseAvailable.Size = new System.Drawing.Size(112, 24);
			this.m_btAdminDataBaseAvailable.TabIndex = 17;
			this.m_btAdminDataBaseAvailable.Text = "DataBase Exists";
			this.m_btAdminDataBaseAvailable.Click += new System.EventHandler(this.m_btAdminDataBaseAvailable_Click);
			// 
			// m_btAdminUserAssociated
			// 
			this.m_btAdminUserAssociated.Location = new System.Drawing.Point(248, 32);
			this.m_btAdminUserAssociated.Name = "m_btAdminUserAssociated";
			this.m_btAdminUserAssociated.Size = new System.Drawing.Size(112, 24);
			this.m_btAdminUserAssociated.TabIndex = 16;
			this.m_btAdminUserAssociated.Text = "User Associated";
			this.m_btAdminUserAssociated.Click += new System.EventHandler(this.m_btAdminUserAssociated_Click);
			// 
			// m_btAdminCreateUser
			// 
			this.m_btAdminCreateUser.Location = new System.Drawing.Point(248, 8);
			this.m_btAdminCreateUser.Name = "m_btAdminCreateUser";
			this.m_btAdminCreateUser.Size = new System.Drawing.Size(112, 24);
			this.m_btAdminCreateUser.TabIndex = 15;
			this.m_btAdminCreateUser.Text = "Create User";
			this.m_btAdminCreateUser.Click += new System.EventHandler(this.m_btUserAdd_Click);
			// 
			// m_btUserAvailable
			// 
			this.m_btUserAvailable.Location = new System.Drawing.Point(135, 57);
			this.m_btUserAvailable.Name = "m_btUserAvailable";
			this.m_btUserAvailable.Size = new System.Drawing.Size(112, 24);
			this.m_btUserAvailable.TabIndex = 14;
			this.m_btUserAvailable.Text = "User Available";
			this.m_btUserAvailable.Click += new System.EventHandler(this.m_btUserAvailable_Click);
			// 
			// m_btAdminCreateDataBase
			// 
			this.m_btAdminCreateDataBase.Location = new System.Drawing.Point(135, 33);
			this.m_btAdminCreateDataBase.Name = "m_btAdminCreateDataBase";
			this.m_btAdminCreateDataBase.Size = new System.Drawing.Size(112, 24);
			this.m_btAdminCreateDataBase.TabIndex = 13;
			this.m_btAdminCreateDataBase.Text = "Create DataBase";
			this.m_btAdminCreateDataBase.Click += new System.EventHandler(this.m_btAdminCreateDataBase_Click);
			// 
			// m_txtAdminPassword
			// 
			this.m_txtAdminPassword.Location = new System.Drawing.Point(72, 32);
			this.m_txtAdminPassword.Name = "m_txtAdminPassword";
			this.m_txtAdminPassword.Size = new System.Drawing.Size(56, 20);
			this.m_txtAdminPassword.TabIndex = 12;
			this.m_txtAdminPassword.Text = "Siscobras@03";
			// 
			// m_txtAdminUser
			// 
			this.m_txtAdminUser.Location = new System.Drawing.Point(72, 10);
			this.m_txtAdminUser.Name = "m_txtAdminUser";
			this.m_txtAdminUser.Size = new System.Drawing.Size(56, 20);
			this.m_txtAdminUser.TabIndex = 11;
			this.m_txtAdminUser.Text = "root";
			// 
			// m_lbAdminPassword
			// 
			this.m_lbAdminPassword.Location = new System.Drawing.Point(8, 32);
			this.m_lbAdminPassword.Name = "m_lbAdminPassword";
			this.m_lbAdminPassword.Size = new System.Drawing.Size(64, 16);
			this.m_lbAdminPassword.TabIndex = 1;
			this.m_lbAdminPassword.Text = "Password:";
			// 
			// m_lbAdminUser
			// 
			this.m_lbAdminUser.Location = new System.Drawing.Point(8, 16);
			this.m_lbAdminUser.Name = "m_lbAdminUser";
			this.m_lbAdminUser.Size = new System.Drawing.Size(48, 16);
			this.m_lbAdminUser.TabIndex = 0;
			this.m_lbAdminUser.Text = "User:";
			// 
			// m_ckWriteXML
			// 
			this.m_ckWriteXML.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckWriteXML.Location = new System.Drawing.Point(208, 552);
			this.m_ckWriteXML.Name = "m_ckWriteXML";
			this.m_ckWriteXML.Size = new System.Drawing.Size(72, 24);
			this.m_ckWriteXML.TabIndex = 27;
			this.m_ckWriteXML.Text = "Write Xml";
			this.m_ckWriteXML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btAllRowsNew
			// 
			this.m_btAllRowsNew.Location = new System.Drawing.Point(723, 579);
			this.m_btAllRowsNew.Name = "m_btAllRowsNew";
			this.m_btAllRowsNew.Size = new System.Drawing.Size(104, 32);
			this.m_btAllRowsNew.TabIndex = 26;
			this.m_btAllRowsNew.Text = "All Rows New";
			this.m_btAllRowsNew.Click += new System.EventHandler(this.m_btAllRowsNew_Click);
			// 
			// m_ckDontPutDataInDataGrid
			// 
			this.m_ckDontPutDataInDataGrid.Location = new System.Drawing.Point(760, 552);
			this.m_ckDontPutDataInDataGrid.Name = "m_ckDontPutDataInDataGrid";
			this.m_ckDontPutDataInDataGrid.Size = new System.Drawing.Size(192, 16);
			this.m_ckDontPutDataInDataGrid.TabIndex = 25;
			this.m_ckDontPutDataInDataGrid.Text = "Nao colocar dados no DataGrid";
			// 
			// m_gbPersistencia
			// 
			this.m_gbPersistencia.Controls.Add(this.m_ckPersistDB);
			this.m_gbPersistencia.Controls.Add(this.m_ckPersistData);
			this.m_gbPersistencia.Location = new System.Drawing.Point(8, 120);
			this.m_gbPersistencia.Name = "m_gbPersistencia";
			this.m_gbPersistencia.Size = new System.Drawing.Size(184, 48);
			this.m_gbPersistencia.TabIndex = 14;
			this.m_gbPersistencia.TabStop = false;
			this.m_gbPersistencia.Text = "Persist";
			// 
			// m_ckPersistDB
			// 
			this.m_ckPersistDB.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckPersistDB.Location = new System.Drawing.Point(9, 16);
			this.m_ckPersistDB.Name = "m_ckPersistDB";
			this.m_ckPersistDB.Size = new System.Drawing.Size(80, 24);
			this.m_ckPersistDB.TabIndex = 1;
			this.m_ckPersistDB.Text = "DB Persist";
			this.m_ckPersistDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_ckPersistData
			// 
			this.m_ckPersistData.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_ckPersistData.Location = new System.Drawing.Point(94, 16);
			this.m_ckPersistData.Name = "m_ckPersistData";
			this.m_ckPersistData.Size = new System.Drawing.Size(80, 24);
			this.m_ckPersistData.TabIndex = 0;
			this.m_ckPersistData.Text = "Data Persist";
			this.m_ckPersistData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btUpdateDataBase
			// 
			this.m_btUpdateDataBase.Location = new System.Drawing.Point(830, 579);
			this.m_btUpdateDataBase.Name = "m_btUpdateDataBase";
			this.m_btUpdateDataBase.Size = new System.Drawing.Size(128, 32);
			this.m_btUpdateDataBase.TabIndex = 13;
			this.m_btUpdateDataBase.Text = "Update DataBase";
			this.m_btUpdateDataBase.Click += new System.EventHandler(this.m_btUpdateDataBase_Click);
			// 
			// m_gbConnectionType
			// 
			this.m_gbConnectionType.Controls.Add(this.m_btRelatoriosPadrao);
			this.m_gbConnectionType.Controls.Add(this.m_ckFonteDadosResource);
			this.m_gbConnectionType.Controls.Add(this.m_rbConnectionTypePath);
			this.m_gbConnectionType.Controls.Add(this.m_rbConnectionTypeTCP);
			this.m_gbConnectionType.Location = new System.Drawing.Point(6, 577);
			this.m_gbConnectionType.Name = "m_gbConnectionType";
			this.m_gbConnectionType.Size = new System.Drawing.Size(402, 35);
			this.m_gbConnectionType.TabIndex = 12;
			this.m_gbConnectionType.TabStop = false;
			// 
			// m_btRelatoriosPadrao
			// 
			this.m_btRelatoriosPadrao.Location = new System.Drawing.Point(364, 8);
			this.m_btRelatoriosPadrao.Name = "m_btRelatoriosPadrao";
			this.m_btRelatoriosPadrao.Size = new System.Drawing.Size(32, 24);
			this.m_btRelatoriosPadrao.TabIndex = 3;
			this.m_btRelatoriosPadrao.Text = "RP";
			this.m_btRelatoriosPadrao.Click += new System.EventHandler(this.m_btRelatoriosPadrao_Click);
			// 
			// m_ckFonteDadosResource
			// 
			this.m_ckFonteDadosResource.Location = new System.Drawing.Point(167, 14);
			this.m_ckFonteDadosResource.Name = "m_ckFonteDadosResource";
			this.m_ckFonteDadosResource.Size = new System.Drawing.Size(144, 16);
			this.m_ckFonteDadosResource.TabIndex = 2;
			this.m_ckFonteDadosResource.Text = "Fonte Dados Resource";
			// 
			// m_rbConnectionTypePath
			// 
			this.m_rbConnectionTypePath.Checked = true;
			this.m_rbConnectionTypePath.Location = new System.Drawing.Point(80, 16);
			this.m_rbConnectionTypePath.Name = "m_rbConnectionTypePath";
			this.m_rbConnectionTypePath.Size = new System.Drawing.Size(56, 16);
			this.m_rbConnectionTypePath.TabIndex = 1;
			this.m_rbConnectionTypePath.TabStop = true;
			this.m_rbConnectionTypePath.Text = "PATH";
			// 
			// m_rbConnectionTypeTCP
			// 
			this.m_rbConnectionTypeTCP.Location = new System.Drawing.Point(8, 14);
			this.m_rbConnectionTypeTCP.Name = "m_rbConnectionTypeTCP";
			this.m_rbConnectionTypeTCP.Size = new System.Drawing.Size(56, 16);
			this.m_rbConnectionTypeTCP.TabIndex = 0;
			this.m_rbConnectionTypeTCP.Text = "TCP";
			// 
			// m_gbIntegridade
			// 
			this.m_gbIntegridade.Controls.Add(this.m_ckIntegrityUpdate);
			this.m_gbIntegridade.Controls.Add(this.m_ckMultiTable);
			this.m_gbIntegridade.Location = new System.Drawing.Point(416, 577);
			this.m_gbIntegridade.Name = "m_gbIntegridade";
			this.m_gbIntegridade.Size = new System.Drawing.Size(288, 35);
			this.m_gbIntegridade.TabIndex = 11;
			this.m_gbIntegridade.TabStop = false;
			// 
			// m_ckIntegrityUpdate
			// 
			this.m_ckIntegrityUpdate.Location = new System.Drawing.Point(122, 12);
			this.m_ckIntegrityUpdate.Name = "m_ckIntegrityUpdate";
			this.m_ckIntegrityUpdate.Size = new System.Drawing.Size(103, 16);
			this.m_ckIntegrityUpdate.TabIndex = 1;
			this.m_ckIntegrityUpdate.Text = "Integrity Update";
			// 
			// m_ckMultiTable
			// 
			this.m_ckMultiTable.Location = new System.Drawing.Point(9, 12);
			this.m_ckMultiTable.Name = "m_ckMultiTable";
			this.m_ckMultiTable.Size = new System.Drawing.Size(103, 16);
			this.m_ckMultiTable.TabIndex = 0;
			this.m_ckMultiTable.Text = "MultiTable";
			// 
			// m_gbConfiguracao
			// 
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoSave);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoClear);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoLoad);
			this.m_gbConfiguracao.Controls.Add(this.m_txtConfiguracaoRetorno);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoSet);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoGetDataTime);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoGetInt);
			this.m_gbConfiguracao.Controls.Add(this.m_btConfiguracaoGetStr);
			this.m_gbConfiguracao.Controls.Add(this.m_lbConfiguracaoValorDefault);
			this.m_gbConfiguracao.Controls.Add(this.m_txtConfiguracaoValorDefault);
			this.m_gbConfiguracao.Controls.Add(this.m_lbConfiguracaoValor);
			this.m_gbConfiguracao.Controls.Add(this.m_txtConfiguracaoValor);
			this.m_gbConfiguracao.Controls.Add(this.m_lbConfiguracaoVariavel);
			this.m_gbConfiguracao.Controls.Add(this.m_txtConfiguracaoVariavel);
			this.m_gbConfiguracao.Location = new System.Drawing.Point(8, 390);
			this.m_gbConfiguracao.Name = "m_gbConfiguracao";
			this.m_gbConfiguracao.Size = new System.Drawing.Size(192, 188);
			this.m_gbConfiguracao.TabIndex = 10;
			this.m_gbConfiguracao.TabStop = false;
			this.m_gbConfiguracao.Text = "Configuracao";
			// 
			// m_btConfiguracaoSave
			// 
			this.m_btConfiguracaoSave.Location = new System.Drawing.Point(120, 152);
			this.m_btConfiguracaoSave.Name = "m_btConfiguracaoSave";
			this.m_btConfiguracaoSave.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoSave.TabIndex = 19;
			this.m_btConfiguracaoSave.Text = "Save";
			this.m_btConfiguracaoSave.Click += new System.EventHandler(this.m_btConfiguracaoSave_Click);
			// 
			// m_btConfiguracaoClear
			// 
			this.m_btConfiguracaoClear.Location = new System.Drawing.Point(64, 152);
			this.m_btConfiguracaoClear.Name = "m_btConfiguracaoClear";
			this.m_btConfiguracaoClear.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoClear.TabIndex = 18;
			this.m_btConfiguracaoClear.Text = "Clear";
			this.m_btConfiguracaoClear.Click += new System.EventHandler(this.m_btConfiguracaoClear_Click);
			// 
			// m_btConfiguracaoLoad
			// 
			this.m_btConfiguracaoLoad.Location = new System.Drawing.Point(8, 152);
			this.m_btConfiguracaoLoad.Name = "m_btConfiguracaoLoad";
			this.m_btConfiguracaoLoad.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoLoad.TabIndex = 17;
			this.m_btConfiguracaoLoad.Text = "Load";
			this.m_btConfiguracaoLoad.Click += new System.EventHandler(this.m_btConfiguracaoLoad_Click);
			// 
			// m_txtConfiguracaoRetorno
			// 
			this.m_txtConfiguracaoRetorno.Location = new System.Drawing.Point(72, 112);
			this.m_txtConfiguracaoRetorno.Name = "m_txtConfiguracaoRetorno";
			this.m_txtConfiguracaoRetorno.Size = new System.Drawing.Size(107, 20);
			this.m_txtConfiguracaoRetorno.TabIndex = 16;
			this.m_txtConfiguracaoRetorno.Text = "";
			// 
			// m_btConfiguracaoSet
			// 
			this.m_btConfiguracaoSet.Location = new System.Drawing.Point(8, 112);
			this.m_btConfiguracaoSet.Name = "m_btConfiguracaoSet";
			this.m_btConfiguracaoSet.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoSet.TabIndex = 15;
			this.m_btConfiguracaoSet.Text = "Set";
			this.m_btConfiguracaoSet.Click += new System.EventHandler(this.m_btConfiguracaoSet_Click);
			// 
			// m_btConfiguracaoGetDataTime
			// 
			this.m_btConfiguracaoGetDataTime.Location = new System.Drawing.Point(108, 85);
			this.m_btConfiguracaoGetDataTime.Name = "m_btConfiguracaoGetDataTime";
			this.m_btConfiguracaoGetDataTime.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoGetDataTime.TabIndex = 14;
			this.m_btConfiguracaoGetDataTime.Text = "Get dt";
			this.m_btConfiguracaoGetDataTime.Click += new System.EventHandler(this.m_btConfiguracaoGetDataTime_Click);
			// 
			// m_btConfiguracaoGetInt
			// 
			this.m_btConfiguracaoGetInt.Location = new System.Drawing.Point(57, 85);
			this.m_btConfiguracaoGetInt.Name = "m_btConfiguracaoGetInt";
			this.m_btConfiguracaoGetInt.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoGetInt.TabIndex = 13;
			this.m_btConfiguracaoGetInt.Text = "Get n";
			this.m_btConfiguracaoGetInt.Click += new System.EventHandler(this.m_btConfiguracaoGetInt_Click);
			// 
			// m_btConfiguracaoGetStr
			// 
			this.m_btConfiguracaoGetStr.Location = new System.Drawing.Point(7, 85);
			this.m_btConfiguracaoGetStr.Name = "m_btConfiguracaoGetStr";
			this.m_btConfiguracaoGetStr.Size = new System.Drawing.Size(49, 24);
			this.m_btConfiguracaoGetStr.TabIndex = 12;
			this.m_btConfiguracaoGetStr.Text = "Get str";
			this.m_btConfiguracaoGetStr.Click += new System.EventHandler(this.m_btConfiguracaoGetStr_Click);
			// 
			// m_lbConfiguracaoValorDefault
			// 
			this.m_lbConfiguracaoValorDefault.Location = new System.Drawing.Point(11, 62);
			this.m_lbConfiguracaoValorDefault.Name = "m_lbConfiguracaoValorDefault";
			this.m_lbConfiguracaoValorDefault.Size = new System.Drawing.Size(56, 16);
			this.m_lbConfiguracaoValorDefault.TabIndex = 11;
			this.m_lbConfiguracaoValorDefault.Text = "ValorDefault";
			// 
			// m_txtConfiguracaoValorDefault
			// 
			this.m_txtConfiguracaoValorDefault.Location = new System.Drawing.Point(69, 60);
			this.m_txtConfiguracaoValorDefault.Name = "m_txtConfiguracaoValorDefault";
			this.m_txtConfiguracaoValorDefault.Size = new System.Drawing.Size(107, 20);
			this.m_txtConfiguracaoValorDefault.TabIndex = 10;
			this.m_txtConfiguracaoValorDefault.Text = "";
			// 
			// m_lbConfiguracaoValor
			// 
			this.m_lbConfiguracaoValor.Location = new System.Drawing.Point(10, 40);
			this.m_lbConfiguracaoValor.Name = "m_lbConfiguracaoValor";
			this.m_lbConfiguracaoValor.Size = new System.Drawing.Size(56, 16);
			this.m_lbConfiguracaoValor.TabIndex = 9;
			this.m_lbConfiguracaoValor.Text = "Valor";
			// 
			// m_txtConfiguracaoValor
			// 
			this.m_txtConfiguracaoValor.Location = new System.Drawing.Point(69, 38);
			this.m_txtConfiguracaoValor.Name = "m_txtConfiguracaoValor";
			this.m_txtConfiguracaoValor.Size = new System.Drawing.Size(107, 20);
			this.m_txtConfiguracaoValor.TabIndex = 8;
			this.m_txtConfiguracaoValor.Text = "C:\\";
			// 
			// m_lbConfiguracaoVariavel
			// 
			this.m_lbConfiguracaoVariavel.Location = new System.Drawing.Point(8, 20);
			this.m_lbConfiguracaoVariavel.Name = "m_lbConfiguracaoVariavel";
			this.m_lbConfiguracaoVariavel.Size = new System.Drawing.Size(56, 16);
			this.m_lbConfiguracaoVariavel.TabIndex = 7;
			this.m_lbConfiguracaoVariavel.Text = "Variavel";
			// 
			// m_txtConfiguracaoVariavel
			// 
			this.m_txtConfiguracaoVariavel.Location = new System.Drawing.Point(69, 16);
			this.m_txtConfiguracaoVariavel.Name = "m_txtConfiguracaoVariavel";
			this.m_txtConfiguracaoVariavel.Size = new System.Drawing.Size(107, 20);
			this.m_txtConfiguracaoVariavel.TabIndex = 1;
			this.m_txtConfiguracaoVariavel.Text = "STRIDCLIENTE";
			// 
			// m_gbCondicoes
			// 
			this.m_gbCondicoes.Controls.Add(this.m_btCondicaoInsert);
			this.m_gbCondicoes.Controls.Add(this.m_btCondicaoClear);
			this.m_gbCondicoes.Controls.Add(this.m_txtCondicaoValor);
			this.m_gbCondicoes.Controls.Add(this.m_cbCondicaoComparador);
			this.m_gbCondicoes.Controls.Add(this.m_txtCondicaoCampo);
			this.m_gbCondicoes.Location = new System.Drawing.Point(8, 259);
			this.m_gbCondicoes.Name = "m_gbCondicoes";
			this.m_gbCondicoes.Size = new System.Drawing.Size(192, 80);
			this.m_gbCondicoes.TabIndex = 9;
			this.m_gbCondicoes.TabStop = false;
			this.m_gbCondicoes.Text = "Condicoes";
			// 
			// m_btCondicaoInsert
			// 
			this.m_btCondicaoInsert.Location = new System.Drawing.Point(109, 44);
			this.m_btCondicaoInsert.Name = "m_btCondicaoInsert";
			this.m_btCondicaoInsert.Size = new System.Drawing.Size(75, 30);
			this.m_btCondicaoInsert.TabIndex = 4;
			this.m_btCondicaoInsert.Text = "Insert";
			this.m_btCondicaoInsert.Click += new System.EventHandler(this.m_btCondicaoInsert_Click);
			// 
			// m_btCondicaoClear
			// 
			this.m_btCondicaoClear.Location = new System.Drawing.Point(109, 12);
			this.m_btCondicaoClear.Name = "m_btCondicaoClear";
			this.m_btCondicaoClear.Size = new System.Drawing.Size(75, 30);
			this.m_btCondicaoClear.TabIndex = 3;
			this.m_btCondicaoClear.Text = "Clear";
			this.m_btCondicaoClear.Click += new System.EventHandler(this.m_btCondicaoClear_Click);
			// 
			// m_txtCondicaoValor
			// 
			this.m_txtCondicaoValor.Location = new System.Drawing.Point(3, 54);
			this.m_txtCondicaoValor.Name = "m_txtCondicaoValor";
			this.m_txtCondicaoValor.Size = new System.Drawing.Size(101, 20);
			this.m_txtCondicaoValor.TabIndex = 2;
			this.m_txtCondicaoValor.Text = "";
			// 
			// m_cbCondicaoComparador
			// 
			this.m_cbCondicaoComparador.Location = new System.Drawing.Point(4, 32);
			this.m_cbCondicaoComparador.Name = "m_cbCondicaoComparador";
			this.m_cbCondicaoComparador.Size = new System.Drawing.Size(100, 21);
			this.m_cbCondicaoComparador.TabIndex = 1;
			// 
			// m_txtCondicaoCampo
			// 
			this.m_txtCondicaoCampo.Location = new System.Drawing.Point(4, 13);
			this.m_txtCondicaoCampo.Name = "m_txtCondicaoCampo";
			this.m_txtCondicaoCampo.TabIndex = 0;
			this.m_txtCondicaoCampo.Text = "";
			// 
			// m_gbLogin
			// 
			this.m_gbLogin.Controls.Add(this.m_txtHost);
			this.m_gbLogin.Controls.Add(this.m_lbHost);
			this.m_gbLogin.Controls.Add(this.m_txtPassword);
			this.m_gbLogin.Controls.Add(this.m_txtUser);
			this.m_gbLogin.Controls.Add(this.m_lbPassword);
			this.m_gbLogin.Controls.Add(this.m_lbUser);
			this.m_gbLogin.Location = new System.Drawing.Point(8, 167);
			this.m_gbLogin.Name = "m_gbLogin";
			this.m_gbLogin.Size = new System.Drawing.Size(192, 88);
			this.m_gbLogin.TabIndex = 8;
			this.m_gbLogin.TabStop = false;
			this.m_gbLogin.Text = "Login";
			// 
			// m_txtHost
			// 
			this.m_txtHost.Location = new System.Drawing.Point(62, 14);
			this.m_txtHost.Name = "m_txtHost";
			this.m_txtHost.Size = new System.Drawing.Size(122, 20);
			this.m_txtHost.TabIndex = 10;
			this.m_txtHost.Text = "CRON";
			// 
			// m_lbHost
			// 
			this.m_lbHost.Location = new System.Drawing.Point(12, 19);
			this.m_lbHost.Name = "m_lbHost";
			this.m_lbHost.Size = new System.Drawing.Size(32, 16);
			this.m_lbHost.TabIndex = 9;
			this.m_lbHost.Text = "Host";
			// 
			// m_txtPassword
			// 
			this.m_txtPassword.Location = new System.Drawing.Point(62, 64);
			this.m_txtPassword.Name = "m_txtPassword";
			this.m_txtPassword.Size = new System.Drawing.Size(122, 20);
			this.m_txtPassword.TabIndex = 8;
			this.m_txtPassword.Text = "Siscobras";
			// 
			// m_txtUser
			// 
			this.m_txtUser.Location = new System.Drawing.Point(62, 39);
			this.m_txtUser.Name = "m_txtUser";
			this.m_txtUser.Size = new System.Drawing.Size(122, 20);
			this.m_txtUser.TabIndex = 7;
			this.m_txtUser.Text = "Siscobras";
			// 
			// m_lbPassword
			// 
			this.m_lbPassword.Location = new System.Drawing.Point(7, 64);
			this.m_lbPassword.Name = "m_lbPassword";
			this.m_lbPassword.Size = new System.Drawing.Size(56, 16);
			this.m_lbPassword.TabIndex = 6;
			this.m_lbPassword.Text = "Password";
			// 
			// m_lbUser
			// 
			this.m_lbUser.Location = new System.Drawing.Point(9, 41);
			this.m_lbUser.Name = "m_lbUser";
			this.m_lbUser.Size = new System.Drawing.Size(32, 16);
			this.m_lbUser.TabIndex = 5;
			this.m_lbUser.Text = "User";
			// 
			// m_dgPath
			// 
			this.m_dgPath.Controls.Add(this.m_txtDataBaseName);
			this.m_dgPath.Controls.Add(this.m_lbDataBaseName);
			this.m_dgPath.Controls.Add(this.m_txtPathFireBird);
			this.m_dgPath.Controls.Add(this.m_lbPathFirebird);
			this.m_dgPath.Controls.Add(this.m_txtPathJet40);
			this.m_dgPath.Controls.Add(this.m_lbPathJet40);
			this.m_dgPath.Location = new System.Drawing.Point(203, 7);
			this.m_dgPath.Name = "m_dgPath";
			this.m_dgPath.Size = new System.Drawing.Size(525, 89);
			this.m_dgPath.TabIndex = 7;
			this.m_dgPath.TabStop = false;
			this.m_dgPath.Text = "Diversos";
			// 
			// m_txtDataBaseName
			// 
			this.m_txtDataBaseName.Location = new System.Drawing.Point(96, 65);
			this.m_txtDataBaseName.Name = "m_txtDataBaseName";
			this.m_txtDataBaseName.Size = new System.Drawing.Size(416, 20);
			this.m_txtDataBaseName.TabIndex = 9;
			this.m_txtDataBaseName.Text = "Siscobras";
			// 
			// m_lbDataBaseName
			// 
			this.m_lbDataBaseName.Location = new System.Drawing.Point(6, 65);
			this.m_lbDataBaseName.Name = "m_lbDataBaseName";
			this.m_lbDataBaseName.Size = new System.Drawing.Size(90, 16);
			this.m_lbDataBaseName.TabIndex = 8;
			this.m_lbDataBaseName.Text = "DataBaseName";
			// 
			// m_txtPathFireBird
			// 
			this.m_txtPathFireBird.Location = new System.Drawing.Point(96, 39);
			this.m_txtPathFireBird.Name = "m_txtPathFireBird";
			this.m_txtPathFireBird.Size = new System.Drawing.Size(416, 20);
			this.m_txtPathFireBird.TabIndex = 7;
			this.m_txtPathFireBird.Text = "F:\\Projetos\\Siscobras\\BINARIOS\\Siscobras.fdb";
			// 
			// m_lbPathFirebird
			// 
			this.m_lbPathFirebird.Location = new System.Drawing.Point(8, 43);
			this.m_lbPathFirebird.Name = "m_lbPathFirebird";
			this.m_lbPathFirebird.Size = new System.Drawing.Size(70, 16);
			this.m_lbPathFirebird.TabIndex = 6;
			this.m_lbPathFirebird.Text = "PathFireBird";
			// 
			// m_txtPathJet40
			// 
			this.m_txtPathJet40.Location = new System.Drawing.Point(95, 16);
			this.m_txtPathJet40.Name = "m_txtPathJet40";
			this.m_txtPathJet40.Size = new System.Drawing.Size(417, 20);
			this.m_txtPathJet40.TabIndex = 5;
			this.m_txtPathJet40.Text = "F:\\Projetos\\Siscobras\\Binarios\\Siscobras.mdb";
			// 
			// m_lbPathJet40
			// 
			this.m_lbPathJet40.Location = new System.Drawing.Point(10, 19);
			this.m_lbPathJet40.Name = "m_lbPathJet40";
			this.m_lbPathJet40.Size = new System.Drawing.Size(60, 16);
			this.m_lbPathJet40.TabIndex = 4;
			this.m_lbPathJet40.Text = "PathJet40";
			// 
			// m_gbAcao
			// 
			this.m_gbAcao.Controls.Add(this.m_btSet);
			this.m_gbAcao.Controls.Add(this.m_btGet);
			this.m_gbAcao.Location = new System.Drawing.Point(6, 340);
			this.m_gbAcao.Name = "m_gbAcao";
			this.m_gbAcao.Size = new System.Drawing.Size(192, 48);
			this.m_gbAcao.TabIndex = 6;
			this.m_gbAcao.TabStop = false;
			this.m_gbAcao.Text = "Acao";
			// 
			// m_btSet
			// 
			this.m_btSet.Location = new System.Drawing.Point(96, 16);
			this.m_btSet.Name = "m_btSet";
			this.m_btSet.Size = new System.Drawing.Size(72, 24);
			this.m_btSet.TabIndex = 2;
			this.m_btSet.Text = "Set";
			this.m_btSet.Click += new System.EventHandler(this.m_btSet_Click);
			// 
			// m_btGet
			// 
			this.m_btGet.Location = new System.Drawing.Point(16, 16);
			this.m_btGet.Name = "m_btGet";
			this.m_btGet.Size = new System.Drawing.Size(72, 24);
			this.m_btGet.TabIndex = 1;
			this.m_btGet.Text = "Get";
			this.m_btGet.Click += new System.EventHandler(this.m_btGet_Click);
			// 
			// m_gbDados
			// 
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaProformaPropriedades);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaCotacaoPropriedades);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosCertificadoOrigemFormARE);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosCertificadoOrigemFormA);
			this.m_gbDados.Controls.Add(this.m_rbtbStatisticReports);
			this.m_gbDados.Controls.Add(this.m_rbtbStatisticDataManipuators);
			this.m_gbDados.Controls.Add(this.m_rbTbDSEsPEs);
			this.m_gbDados.Controls.Add(this.m_rbTbREsPEs);
			this.m_gbDados.Controls.Add(this.m_rbTbSDs);
			this.m_gbDados.Controls.Add(this.m_rbTbREs);
			this.m_gbDados.Controls.Add(this.m_rbTbDSEs);
			this.m_gbDados.Controls.Add(this.m_rbTbDespachantesContatos);
			this.m_gbDados.Controls.Add(this.m_rbTbGuiasEntrada);
			this.m_gbDados.Controls.Add(this.m_rbTbReservas);
			this.m_gbDados.Controls.Add(this.m_rbTbTerminaisContatos);
			this.m_gbDados.Controls.Add(this.m_rbTbTerminais);
			this.m_gbDados.Controls.Add(this.m_rbTbTransportadorasContatos);
			this.m_gbDados.Controls.Add(this.m_rbTbTransportadorasVeiculos);
			this.m_gbDados.Controls.Add(this.m_rbTbTransportadorasMotoristas);
			this.m_gbDados.Controls.Add(this.m_rbTbTransportadoras);
			this.m_gbDados.Controls.Add(this.m_rbTbArmadoresNavios);
			this.m_gbDados.Controls.Add(this.m_rbTbArmadores);
			this.m_gbDados.Controls.Add(this.m_rbTbAgentesCargasContatos);
			this.m_gbDados.Controls.Add(this.m_rbTbAgentesCargas);
			this.m_gbDados.Controls.Add(this.m_rbTbProcessosContainers);
			this.m_gbDados.Controls.Add(this.m_rbTbConfiguracoes);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioSimplificado);
			this.m_gbDados.Controls.Add(this.m_rbTbRomaneiosSecundarios);
			this.m_gbDados.Controls.Add(this.m_rbTbBorderosSecundarios);
			this.m_gbDados.Controls.Add(this.m_rbTbNotasFiscais);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosBordero);
			this.m_gbDados.Controls.Add(this.m_rbTbContratosCambio);
			this.m_gbDados.Controls.Add(this.m_rbTbCartasCredito);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresAgentesVendasBancos);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresAgentesVendas);
			this.m_gbDados.Controls.Add(this.m_rbTbMaquinas);
			this.m_gbDados.Controls.Add(this.m_rbTbDespachantes);
			this.m_gbDados.Controls.Add(this.m_rbTbLogMedicaoTempo);
			this.m_gbDados.Controls.Add(this.m_rbTbErros);
			this.m_gbDados.Controls.Add(this.m_rbTbUsuariosPermissoesConcessoes);
			this.m_gbDados.Controls.Add(this.m_rbTbUsuariosPermissoes);
			this.m_gbDados.Controls.Add(this.m_rbTbUsuariosConcessoesPermissoes);
			this.m_gbDados.Controls.Add(this.m_rbTbUsuariosConcessoes);
			this.m_gbDados.Controls.Add(this.m_rbTbUsuarios);
			this.m_gbDados.Controls.Add(this.m_rbTbCertificadosOrigemNormas);
			this.m_gbDados.Controls.Add(this.m_rbTbWebServiceServidoresServicos);
			this.m_gbDados.Controls.Add(this.m_rbTbWebServiceServidores);
			this.m_gbDados.Controls.Add(this.m_rbTbWebServiceServicos);
			this.m_gbDados.Controls.Add(this.m_rbTbVersaoModulo);
			this.m_gbDados.Controls.Add(this.m_rbTbVersao);
			this.m_gbDados.Controls.Add(this.m_rbTbModulos);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosCategoria);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosNcm);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosNaladi);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosCertificadoOrigem);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosParents);
			this.m_gbDados.Controls.Add(this.m_rbTbSumarios);
			this.m_gbDados.Controls.Add(this.m_rbTbRomaneios);
			this.m_gbDados.Controls.Add(this.m_rbTbBorderos);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioTipo);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatoriosTodosCamposBD);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatoriosCamposBDRelatorios);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatoriosCamposBDPreRequisitos);
			this.m_gbDados.Controls.Add(this.m_rbTbImagens);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioCamposBD);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioRetangulos);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioLinhas);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioImagens);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioEtiquetas);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorioCirculos);
			this.m_gbDados.Controls.Add(this.m_rbTbRelatorios);
			this.m_gbDados.Controls.Add(this.m_rbTbSaques);
			this.m_gbDados.Controls.Add(this.m_rbTbCertificadosOrigem);
			this.m_gbDados.Controls.Add(this.m_rbTbAssinaturas);
			this.m_gbDados.Controls.Add(this.m_rbTbPes);
			this.m_gbDados.Controls.Add(this.m_rbTbUnidadesMassaIdioma);
			this.m_gbDados.Controls.Add(this.m_rbTbUnidadesMassa);
			this.m_gbDados.Controls.Add(this.m_rbTbUnidadesEspacoIdioma);
			this.m_gbDados.Controls.Add(this.m_rbTbUnidadesEspaco);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioVolumesProdutos);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioVolumesEmbalagens);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioVolumes);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioEmbalagensProdutos);
			this.m_gbDados.Controls.Add(this.m_rbTbVolumes);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresVolumes);
			this.m_gbDados.Controls.Add(this.m_rbTbImportadoresBancos);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresBancosAgenciasContas);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresBancosAgencias);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadoresBancos);
			this.m_gbDados.Controls.Add(this.m_rbTbEstadosBrasileiros);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosRomaneioEmbalagens);
			this.m_gbDados.Controls.Add(this.m_rbTbImportadoresConsignatarios);
			this.m_gbDados.Controls.Add(this.m_rbTbImportadores);
			this.m_gbDados.Controls.Add(this.m_rbTbPaisesIdiomas);
			this.m_gbDados.Controls.Add(this.m_rbTbPaises);
			this.m_gbDados.Controls.Add(this.m_rbTbIdiomasTextos);
			this.m_gbDados.Controls.Add(this.m_rbTbIdiomas);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosIdiomas);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaProforma);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaComercial);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaCotacao);
			this.m_gbDados.Controls.Add(this.m_rbTbFaturasProformas);
			this.m_gbDados.Controls.Add(this.m_rbTbFaturasCotacoes);
			this.m_gbDados.Controls.Add(this.m_rbTbFaturasComerciais);
			this.m_gbDados.Controls.Add(this.m_rbTbMoedas);
			this.m_gbDados.Controls.Add(this.m_rbTbExportadores);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutos);
			this.m_gbDados.Controls.Add(this.m_rbTbInstrucoesEmbarque);
			this.m_gbDados.Controls.Add(this.m_rbTbMensagens);
			this.m_gbDados.Controls.Add(this.m_rbTbImportadoresEndEntrega);
			this.m_gbDados.Controls.Add(this.m_rbTbPropriedadesProdutos);
			this.m_gbDados.Controls.Add(this.m_rbTbProdutosFaturaComercialPropriedades);
			this.m_gbDados.Location = new System.Drawing.Point(202, 96);
			this.m_gbDados.Name = "m_gbDados";
			this.m_gbDados.Size = new System.Drawing.Size(894, 448);
			this.m_gbDados.TabIndex = 3;
			this.m_gbDados.TabStop = false;
			this.m_gbDados.Text = "Dados";
			// 
			// m_rbTbProdutosFaturaProformaPropriedades
			// 
			this.m_rbTbProdutosFaturaProformaPropriedades.Location = new System.Drawing.Point(408, 376);
			this.m_rbTbProdutosFaturaProformaPropriedades.Name = "m_rbTbProdutosFaturaProformaPropriedades";
			this.m_rbTbProdutosFaturaProformaPropriedades.Size = new System.Drawing.Size(183, 16);
			this.m_rbTbProdutosFaturaProformaPropriedades.TabIndex = 118;
			this.m_rbTbProdutosFaturaProformaPropriedades.Text = "tbProdutosFaturaProformaPropriedades";
			// 
			// m_rbTbProdutosFaturaCotacaoPropriedades
			// 
			this.m_rbTbProdutosFaturaCotacaoPropriedades.Location = new System.Drawing.Point(408, 360);
			this.m_rbTbProdutosFaturaCotacaoPropriedades.Name = "m_rbTbProdutosFaturaCotacaoPropriedades";
			this.m_rbTbProdutosFaturaCotacaoPropriedades.Size = new System.Drawing.Size(183, 16);
			this.m_rbTbProdutosFaturaCotacaoPropriedades.TabIndex = 117;
			this.m_rbTbProdutosFaturaCotacaoPropriedades.Text = "tbProdutosFaturaCotacaoPropriedades";
			// 
			// m_rbTbProdutosCertificadoOrigemFormARE
			// 
			this.m_rbTbProdutosCertificadoOrigemFormARE.Location = new System.Drawing.Point(407, 294);
			this.m_rbTbProdutosCertificadoOrigemFormARE.Name = "m_rbTbProdutosCertificadoOrigemFormARE";
			this.m_rbTbProdutosCertificadoOrigemFormARE.Size = new System.Drawing.Size(175, 16);
			this.m_rbTbProdutosCertificadoOrigemFormARE.TabIndex = 113;
			this.m_rbTbProdutosCertificadoOrigemFormARE.Text = "tbProdutosCertificadoOrigemFormARE";
			// 
			// m_rbTbProdutosCertificadoOrigemFormA
			// 
			this.m_rbTbProdutosCertificadoOrigemFormA.Location = new System.Drawing.Point(407, 278);
			this.m_rbTbProdutosCertificadoOrigemFormA.Name = "m_rbTbProdutosCertificadoOrigemFormA";
			this.m_rbTbProdutosCertificadoOrigemFormA.Size = new System.Drawing.Size(175, 16);
			this.m_rbTbProdutosCertificadoOrigemFormA.TabIndex = 112;
			this.m_rbTbProdutosCertificadoOrigemFormA.Text = "tbProdutosCertificadoOrigem";
			// 
			// m_rbtbStatisticReports
			// 
			this.m_rbtbStatisticReports.Location = new System.Drawing.Point(746, 99);
			this.m_rbtbStatisticReports.Name = "m_rbtbStatisticReports";
			this.m_rbtbStatisticReports.Size = new System.Drawing.Size(152, 16);
			this.m_rbtbStatisticReports.TabIndex = 111;
			this.m_rbtbStatisticReports.Text = "tbStatisticReports";
			// 
			// m_rbtbStatisticDataManipuators
			// 
			this.m_rbtbStatisticDataManipuators.Location = new System.Drawing.Point(746, 81);
			this.m_rbtbStatisticDataManipuators.Name = "m_rbtbStatisticDataManipuators";
			this.m_rbtbStatisticDataManipuators.Size = new System.Drawing.Size(152, 16);
			this.m_rbtbStatisticDataManipuators.TabIndex = 110;
			this.m_rbtbStatisticDataManipuators.Text = "tbStaticDataManipulators";
			// 
			// m_rbTbDSEsPEs
			// 
			this.m_rbTbDSEsPEs.Location = new System.Drawing.Point(168, 104);
			this.m_rbTbDSEsPEs.Name = "m_rbTbDSEsPEs";
			this.m_rbTbDSEsPEs.Size = new System.Drawing.Size(88, 16);
			this.m_rbTbDSEsPEs.TabIndex = 109;
			this.m_rbTbDSEsPEs.Text = "tbDSEsPEs";
			// 
			// m_rbTbREsPEs
			// 
			this.m_rbTbREsPEs.Location = new System.Drawing.Point(273, 308);
			this.m_rbTbREsPEs.Name = "m_rbTbREsPEs";
			this.m_rbTbREsPEs.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbREsPEs.TabIndex = 108;
			this.m_rbTbREsPEs.Text = "tbREsPEs";
			// 
			// m_rbTbSDs
			// 
			this.m_rbTbSDs.Location = new System.Drawing.Point(569, 139);
			this.m_rbTbSDs.Name = "m_rbTbSDs";
			this.m_rbTbSDs.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbSDs.TabIndex = 107;
			this.m_rbTbSDs.Text = "tbSDs";
			// 
			// m_rbTbREs
			// 
			this.m_rbTbREs.Location = new System.Drawing.Point(273, 294);
			this.m_rbTbREs.Name = "m_rbTbREs";
			this.m_rbTbREs.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbREs.TabIndex = 106;
			this.m_rbTbREs.Text = "tbREs";
			// 
			// m_rbTbDSEs
			// 
			this.m_rbTbDSEs.Location = new System.Drawing.Point(17, 87);
			this.m_rbTbDSEs.Name = "m_rbTbDSEs";
			this.m_rbTbDSEs.Size = new System.Drawing.Size(150, 16);
			this.m_rbTbDSEs.TabIndex = 105;
			this.m_rbTbDSEs.Text = "tbDSEs";
			// 
			// m_rbTbDespachantesContatos
			// 
			this.m_rbTbDespachantesContatos.Location = new System.Drawing.Point(17, 72);
			this.m_rbTbDespachantesContatos.Name = "m_rbTbDespachantesContatos";
			this.m_rbTbDespachantesContatos.Size = new System.Drawing.Size(150, 16);
			this.m_rbTbDespachantesContatos.TabIndex = 103;
			this.m_rbTbDespachantesContatos.Text = "tbDespachantesContatos";
			// 
			// m_rbTbGuiasEntrada
			// 
			this.m_rbTbGuiasEntrada.Location = new System.Drawing.Point(736, 48);
			this.m_rbTbGuiasEntrada.Name = "m_rbTbGuiasEntrada";
			this.m_rbTbGuiasEntrada.Size = new System.Drawing.Size(120, 16);
			this.m_rbTbGuiasEntrada.TabIndex = 102;
			this.m_rbTbGuiasEntrada.Text = "tbGuiasEntrada";
			// 
			// m_rbTbReservas
			// 
			this.m_rbTbReservas.Location = new System.Drawing.Point(736, 30);
			this.m_rbTbReservas.Name = "m_rbTbReservas";
			this.m_rbTbReservas.Size = new System.Drawing.Size(112, 16);
			this.m_rbTbReservas.TabIndex = 101;
			this.m_rbTbReservas.Text = "tbReservas";
			// 
			// m_rbTbTerminaisContatos
			// 
			this.m_rbTbTerminaisContatos.Location = new System.Drawing.Point(731, 289);
			this.m_rbTbTerminaisContatos.Name = "m_rbTbTerminaisContatos";
			this.m_rbTbTerminaisContatos.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbTerminaisContatos.TabIndex = 100;
			this.m_rbTbTerminaisContatos.Text = "tbTerminaisContatos";
			// 
			// m_rbTbTerminais
			// 
			this.m_rbTbTerminais.Location = new System.Drawing.Point(731, 273);
			this.m_rbTbTerminais.Name = "m_rbTbTerminais";
			this.m_rbTbTerminais.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbTerminais.TabIndex = 99;
			this.m_rbTbTerminais.Text = "tbTerminais";
			// 
			// m_rbTbTransportadorasContatos
			// 
			this.m_rbTbTransportadorasContatos.Location = new System.Drawing.Point(728, 360);
			this.m_rbTbTransportadorasContatos.Name = "m_rbTbTransportadorasContatos";
			this.m_rbTbTransportadorasContatos.Size = new System.Drawing.Size(160, 16);
			this.m_rbTbTransportadorasContatos.TabIndex = 98;
			this.m_rbTbTransportadorasContatos.Text = "tbTransportadorasContatos";
			// 
			// m_rbTbTransportadorasVeiculos
			// 
			this.m_rbTbTransportadorasVeiculos.Location = new System.Drawing.Point(728, 391);
			this.m_rbTbTransportadorasVeiculos.Name = "m_rbTbTransportadorasVeiculos";
			this.m_rbTbTransportadorasVeiculos.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbTransportadorasVeiculos.TabIndex = 97;
			this.m_rbTbTransportadorasVeiculos.Text = "tbTransportadorasVeiculos";
			// 
			// m_rbTbTransportadorasMotoristas
			// 
			this.m_rbTbTransportadorasMotoristas.Location = new System.Drawing.Point(728, 375);
			this.m_rbTbTransportadorasMotoristas.Name = "m_rbTbTransportadorasMotoristas";
			this.m_rbTbTransportadorasMotoristas.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbTransportadorasMotoristas.TabIndex = 96;
			this.m_rbTbTransportadorasMotoristas.Text = "tbTransportadorasMotoristas";
			// 
			// m_rbTbTransportadoras
			// 
			this.m_rbTbTransportadoras.Location = new System.Drawing.Point(728, 344);
			this.m_rbTbTransportadoras.Name = "m_rbTbTransportadoras";
			this.m_rbTbTransportadoras.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbTransportadoras.TabIndex = 95;
			this.m_rbTbTransportadoras.Text = "tbTransportadoras";
			// 
			// m_rbTbArmadoresNavios
			// 
			this.m_rbTbArmadoresNavios.Location = new System.Drawing.Point(576, 364);
			this.m_rbTbArmadoresNavios.Name = "m_rbTbArmadoresNavios";
			this.m_rbTbArmadoresNavios.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbArmadoresNavios.TabIndex = 94;
			this.m_rbTbArmadoresNavios.Text = "tbArmadoresNavios";
			// 
			// m_rbTbArmadores
			// 
			this.m_rbTbArmadores.Location = new System.Drawing.Point(576, 351);
			this.m_rbTbArmadores.Name = "m_rbTbArmadores";
			this.m_rbTbArmadores.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbArmadores.TabIndex = 93;
			this.m_rbTbArmadores.Text = "tbArmadores";
			// 
			// m_rbTbAgentesCargasContatos
			// 
			this.m_rbTbAgentesCargasContatos.Location = new System.Drawing.Point(576, 336);
			this.m_rbTbAgentesCargasContatos.Name = "m_rbTbAgentesCargasContatos";
			this.m_rbTbAgentesCargasContatos.Size = new System.Drawing.Size(160, 16);
			this.m_rbTbAgentesCargasContatos.TabIndex = 92;
			this.m_rbTbAgentesCargasContatos.Text = "tbAgentesCargasContatos";
			// 
			// m_rbTbAgentesCargas
			// 
			this.m_rbTbAgentesCargas.Location = new System.Drawing.Point(576, 323);
			this.m_rbTbAgentesCargas.Name = "m_rbTbAgentesCargas";
			this.m_rbTbAgentesCargas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbAgentesCargas.TabIndex = 91;
			this.m_rbTbAgentesCargas.Text = "tbAgentesCargas";
			// 
			// m_rbTbProcessosContainers
			// 
			this.m_rbTbProcessosContainers.Location = new System.Drawing.Point(128, 430);
			this.m_rbTbProcessosContainers.Name = "m_rbTbProcessosContainers";
			this.m_rbTbProcessosContainers.Size = new System.Drawing.Size(144, 16);
			this.m_rbTbProcessosContainers.TabIndex = 90;
			this.m_rbTbProcessosContainers.Text = "tbProcessosContainers";
			// 
			// m_rbTbConfiguracoes
			// 
			this.m_rbTbConfiguracoes.Location = new System.Drawing.Point(16, 168);
			this.m_rbTbConfiguracoes.Name = "m_rbTbConfiguracoes";
			this.m_rbTbConfiguracoes.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbConfiguracoes.TabIndex = 89;
			this.m_rbTbConfiguracoes.Text = "tbConfiguracoes";
			// 
			// m_rbTbProdutosRomaneioSimplificado
			// 
			this.m_rbTbProdutosRomaneioSimplificado.Location = new System.Drawing.Point(272, 90);
			this.m_rbTbProdutosRomaneioSimplificado.Name = "m_rbTbProdutosRomaneioSimplificado";
			this.m_rbTbProdutosRomaneioSimplificado.Size = new System.Drawing.Size(216, 16);
			this.m_rbTbProdutosRomaneioSimplificado.TabIndex = 88;
			this.m_rbTbProdutosRomaneioSimplificado.Text = "tbProdutosRomaneioSimplificado";
			// 
			// m_rbTbRomaneiosSecundarios
			// 
			this.m_rbTbRomaneiosSecundarios.Location = new System.Drawing.Point(569, 111);
			this.m_rbTbRomaneiosSecundarios.Name = "m_rbTbRomaneiosSecundarios";
			this.m_rbTbRomaneiosSecundarios.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbRomaneiosSecundarios.TabIndex = 87;
			this.m_rbTbRomaneiosSecundarios.Text = "tbRomaneiosSecundarios";
			// 
			// m_rbTbBorderosSecundarios
			// 
			this.m_rbTbBorderosSecundarios.Location = new System.Drawing.Point(165, 34);
			this.m_rbTbBorderosSecundarios.Name = "m_rbTbBorderosSecundarios";
			this.m_rbTbBorderosSecundarios.Size = new System.Drawing.Size(107, 16);
			this.m_rbTbBorderosSecundarios.TabIndex = 86;
			this.m_rbTbBorderosSecundarios.Text = "tbBorderosSecundarios";
			// 
			// m_rbTbNotasFiscais
			// 
			this.m_rbTbNotasFiscais.Location = new System.Drawing.Point(273, 326);
			this.m_rbTbNotasFiscais.Name = "m_rbTbNotasFiscais";
			this.m_rbTbNotasFiscais.Size = new System.Drawing.Size(104, 16);
			this.m_rbTbNotasFiscais.TabIndex = 85;
			this.m_rbTbNotasFiscais.Text = "tbNotasFiscais";
			// 
			// m_rbTbProdutosBordero
			// 
			this.m_rbTbProdutosBordero.Location = new System.Drawing.Point(16, 428);
			this.m_rbTbProdutosBordero.Name = "m_rbTbProdutosBordero";
			this.m_rbTbProdutosBordero.Size = new System.Drawing.Size(120, 16);
			this.m_rbTbProdutosBordero.TabIndex = 84;
			this.m_rbTbProdutosBordero.Text = "tbProdutosBordero";
			// 
			// m_rbTbContratosCambio
			// 
			this.m_rbTbContratosCambio.Location = new System.Drawing.Point(168, 88);
			this.m_rbTbContratosCambio.Name = "m_rbTbContratosCambio";
			this.m_rbTbContratosCambio.Size = new System.Drawing.Size(126, 16);
			this.m_rbTbContratosCambio.TabIndex = 83;
			this.m_rbTbContratosCambio.Text = "tbContratosCambio";
			// 
			// m_rbTbCartasCredito
			// 
			this.m_rbTbCartasCredito.Location = new System.Drawing.Point(168, 72);
			this.m_rbTbCartasCredito.Name = "m_rbTbCartasCredito";
			this.m_rbTbCartasCredito.Size = new System.Drawing.Size(104, 16);
			this.m_rbTbCartasCredito.TabIndex = 82;
			this.m_rbTbCartasCredito.Text = "tbCartasCredito";
			// 
			// m_rbTbExportadoresAgentesVendasBancos
			// 
			this.m_rbTbExportadoresAgentesVendasBancos.Location = new System.Drawing.Point(16, 152);
			this.m_rbTbExportadoresAgentesVendasBancos.Name = "m_rbTbExportadoresAgentesVendasBancos";
			this.m_rbTbExportadoresAgentesVendasBancos.Size = new System.Drawing.Size(224, 16);
			this.m_rbTbExportadoresAgentesVendasBancos.TabIndex = 81;
			this.m_rbTbExportadoresAgentesVendasBancos.Text = "tbExportadoresAgentesVendasBancos";
			// 
			// m_rbTbExportadoresAgentesVendas
			// 
			this.m_rbTbExportadoresAgentesVendas.Location = new System.Drawing.Point(16, 136);
			this.m_rbTbExportadoresAgentesVendas.Name = "m_rbTbExportadoresAgentesVendas";
			this.m_rbTbExportadoresAgentesVendas.Size = new System.Drawing.Size(192, 16);
			this.m_rbTbExportadoresAgentesVendas.TabIndex = 80;
			this.m_rbTbExportadoresAgentesVendas.Text = "tbExportadoresAgentesVendas";
			// 
			// m_rbTbMaquinas
			// 
			this.m_rbTbMaquinas.Location = new System.Drawing.Point(585, 305);
			this.m_rbTbMaquinas.Name = "m_rbTbMaquinas";
			this.m_rbTbMaquinas.Size = new System.Drawing.Size(104, 16);
			this.m_rbTbMaquinas.TabIndex = 79;
			this.m_rbTbMaquinas.Text = "tbMaquinas";
			// 
			// m_rbTbDespachantes
			// 
			this.m_rbTbDespachantes.Location = new System.Drawing.Point(18, 56);
			this.m_rbTbDespachantes.Name = "m_rbTbDespachantes";
			this.m_rbTbDespachantes.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbDespachantes.TabIndex = 78;
			this.m_rbTbDespachantes.Text = "tbDespachantes";
			// 
			// m_rbTbLogMedicaoTempo
			// 
			this.m_rbTbLogMedicaoTempo.Location = new System.Drawing.Point(128, 414);
			this.m_rbTbLogMedicaoTempo.Name = "m_rbTbLogMedicaoTempo";
			this.m_rbTbLogMedicaoTempo.Size = new System.Drawing.Size(129, 16);
			this.m_rbTbLogMedicaoTempo.TabIndex = 75;
			this.m_rbTbLogMedicaoTempo.Text = "tbLogMedicaoTempo";
			// 
			// m_rbTbErros
			// 
			this.m_rbTbErros.Location = new System.Drawing.Point(17, 410);
			this.m_rbTbErros.Name = "m_rbTbErros";
			this.m_rbTbErros.Size = new System.Drawing.Size(103, 16);
			this.m_rbTbErros.TabIndex = 74;
			this.m_rbTbErros.Text = "tbErros";
			// 
			// m_rbTbUsuariosPermissoesConcessoes
			// 
			this.m_rbTbUsuariosPermissoesConcessoes.Location = new System.Drawing.Point(224, 405);
			this.m_rbTbUsuariosPermissoesConcessoes.Name = "m_rbTbUsuariosPermissoesConcessoes";
			this.m_rbTbUsuariosPermissoesConcessoes.Size = new System.Drawing.Size(192, 16);
			this.m_rbTbUsuariosPermissoesConcessoes.TabIndex = 73;
			this.m_rbTbUsuariosPermissoesConcessoes.Text = "tbUsuariosPermissoesConcessoes";
			// 
			// m_rbTbUsuariosPermissoes
			// 
			this.m_rbTbUsuariosPermissoes.Location = new System.Drawing.Point(224, 391);
			this.m_rbTbUsuariosPermissoes.Name = "m_rbTbUsuariosPermissoes";
			this.m_rbTbUsuariosPermissoes.Size = new System.Drawing.Size(186, 16);
			this.m_rbTbUsuariosPermissoes.TabIndex = 72;
			this.m_rbTbUsuariosPermissoes.Text = "tbUsuariosPermissoes";
			// 
			// m_rbTbUsuariosConcessoesPermissoes
			// 
			this.m_rbTbUsuariosConcessoesPermissoes.Location = new System.Drawing.Point(224, 376);
			this.m_rbTbUsuariosConcessoesPermissoes.Name = "m_rbTbUsuariosConcessoesPermissoes";
			this.m_rbTbUsuariosConcessoesPermissoes.Size = new System.Drawing.Size(184, 16);
			this.m_rbTbUsuariosConcessoesPermissoes.TabIndex = 71;
			this.m_rbTbUsuariosConcessoesPermissoes.Text = "tbUsuariosConcessoesPermissoes";
			// 
			// m_rbTbUsuariosConcessoes
			// 
			this.m_rbTbUsuariosConcessoes.Location = new System.Drawing.Point(224, 360);
			this.m_rbTbUsuariosConcessoes.Name = "m_rbTbUsuariosConcessoes";
			this.m_rbTbUsuariosConcessoes.Size = new System.Drawing.Size(176, 16);
			this.m_rbTbUsuariosConcessoes.TabIndex = 70;
			this.m_rbTbUsuariosConcessoes.Text = "tbUsuariosConcessoes";
			// 
			// m_rbTbUsuarios
			// 
			this.m_rbTbUsuarios.Location = new System.Drawing.Point(224, 346);
			this.m_rbTbUsuarios.Name = "m_rbTbUsuarios";
			this.m_rbTbUsuarios.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbUsuarios.TabIndex = 69;
			this.m_rbTbUsuarios.Text = "tbUsuarios";
			// 
			// m_rbTbCertificadosOrigemNormas
			// 
			this.m_rbTbCertificadosOrigemNormas.Location = new System.Drawing.Point(11, 41);
			this.m_rbTbCertificadosOrigemNormas.Name = "m_rbTbCertificadosOrigemNormas";
			this.m_rbTbCertificadosOrigemNormas.Size = new System.Drawing.Size(173, 16);
			this.m_rbTbCertificadosOrigemNormas.TabIndex = 68;
			this.m_rbTbCertificadosOrigemNormas.Text = "tbCertificadosOrigemNormas";
			// 
			// m_rbTbWebServiceServidoresServicos
			// 
			this.m_rbTbWebServiceServidoresServicos.Location = new System.Drawing.Point(568, 416);
			this.m_rbTbWebServiceServidoresServicos.Name = "m_rbTbWebServiceServidoresServicos";
			this.m_rbTbWebServiceServidoresServicos.Size = new System.Drawing.Size(196, 16);
			this.m_rbTbWebServiceServidoresServicos.TabIndex = 67;
			this.m_rbTbWebServiceServidoresServicos.Text = "tbWebServiceServidoresServicos";
			// 
			// m_rbTbWebServiceServidores
			// 
			this.m_rbTbWebServiceServidores.Location = new System.Drawing.Point(568, 400);
			this.m_rbTbWebServiceServidores.Name = "m_rbTbWebServiceServidores";
			this.m_rbTbWebServiceServidores.Size = new System.Drawing.Size(176, 16);
			this.m_rbTbWebServiceServidores.TabIndex = 66;
			this.m_rbTbWebServiceServidores.Text = "tbWebServiceServidores";
			// 
			// m_rbTbWebServiceServicos
			// 
			this.m_rbTbWebServiceServicos.Location = new System.Drawing.Point(568, 384);
			this.m_rbTbWebServiceServicos.Name = "m_rbTbWebServiceServicos";
			this.m_rbTbWebServiceServicos.Size = new System.Drawing.Size(184, 16);
			this.m_rbTbWebServiceServicos.TabIndex = 65;
			this.m_rbTbWebServiceServicos.Text = "tbWebServiceServicos";
			// 
			// m_rbTbVersaoModulo
			// 
			this.m_rbTbVersaoModulo.Location = new System.Drawing.Point(585, 289);
			this.m_rbTbVersaoModulo.Name = "m_rbTbVersaoModulo";
			this.m_rbTbVersaoModulo.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbVersaoModulo.TabIndex = 64;
			this.m_rbTbVersaoModulo.Text = "tbVersaoModulo";
			// 
			// m_rbTbVersao
			// 
			this.m_rbTbVersao.Location = new System.Drawing.Point(585, 274);
			this.m_rbTbVersao.Name = "m_rbTbVersao";
			this.m_rbTbVersao.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbVersao.TabIndex = 63;
			this.m_rbTbVersao.Text = "tbVersao";
			// 
			// m_rbTbModulos
			// 
			this.m_rbTbModulos.Location = new System.Drawing.Point(585, 259);
			this.m_rbTbModulos.Name = "m_rbTbModulos";
			this.m_rbTbModulos.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbModulos.TabIndex = 62;
			this.m_rbTbModulos.Text = "tbModulos";
			// 
			// m_rbTbProdutosCategoria
			// 
			this.m_rbTbProdutosCategoria.Location = new System.Drawing.Point(424, 200);
			this.m_rbTbProdutosCategoria.Name = "m_rbTbProdutosCategoria";
			this.m_rbTbProdutosCategoria.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutosCategoria.TabIndex = 61;
			this.m_rbTbProdutosCategoria.Text = "tbProdutosCategorias";
			// 
			// m_rbTbProdutosNcm
			// 
			this.m_rbTbProdutosNcm.Location = new System.Drawing.Point(424, 234);
			this.m_rbTbProdutosNcm.Name = "m_rbTbProdutosNcm";
			this.m_rbTbProdutosNcm.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutosNcm.TabIndex = 60;
			this.m_rbTbProdutosNcm.Text = "tbProdutosNcm";
			// 
			// m_rbTbProdutosNaladi
			// 
			this.m_rbTbProdutosNaladi.Location = new System.Drawing.Point(424, 216);
			this.m_rbTbProdutosNaladi.Name = "m_rbTbProdutosNaladi";
			this.m_rbTbProdutosNaladi.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutosNaladi.TabIndex = 59;
			this.m_rbTbProdutosNaladi.Text = "tbProdutosNaladi";
			// 
			// m_rbTbProdutosCertificadoOrigem
			// 
			this.m_rbTbProdutosCertificadoOrigem.Location = new System.Drawing.Point(407, 263);
			this.m_rbTbProdutosCertificadoOrigem.Name = "m_rbTbProdutosCertificadoOrigem";
			this.m_rbTbProdutosCertificadoOrigem.Size = new System.Drawing.Size(175, 16);
			this.m_rbTbProdutosCertificadoOrigem.TabIndex = 58;
			this.m_rbTbProdutosCertificadoOrigem.Text = "tbProdutosCertificadoOrigem";
			// 
			// m_rbTbProdutosParents
			// 
			this.m_rbTbProdutosParents.Location = new System.Drawing.Point(408, 310);
			this.m_rbTbProdutosParents.Name = "m_rbTbProdutosParents";
			this.m_rbTbProdutosParents.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutosParents.TabIndex = 57;
			this.m_rbTbProdutosParents.Text = "tbProdutosParents";
			// 
			// m_rbTbSumarios
			// 
			this.m_rbTbSumarios.Location = new System.Drawing.Point(569, 154);
			this.m_rbTbSumarios.Name = "m_rbTbSumarios";
			this.m_rbTbSumarios.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbSumarios.TabIndex = 56;
			this.m_rbTbSumarios.Text = "tbSumarios";
			// 
			// m_rbTbRomaneios
			// 
			this.m_rbTbRomaneios.Location = new System.Drawing.Point(568, 96);
			this.m_rbTbRomaneios.Name = "m_rbTbRomaneios";
			this.m_rbTbRomaneios.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbRomaneios.TabIndex = 55;
			this.m_rbTbRomaneios.Text = "tbRomaneios";
			// 
			// m_rbTbBorderos
			// 
			this.m_rbTbBorderos.Location = new System.Drawing.Point(143, 16);
			this.m_rbTbBorderos.Name = "m_rbTbBorderos";
			this.m_rbTbBorderos.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbBorderos.TabIndex = 54;
			this.m_rbTbBorderos.Text = "tbBorderos";
			// 
			// m_rbTbRelatorioTipo
			// 
			this.m_rbTbRelatorioTipo.Location = new System.Drawing.Point(496, 80);
			this.m_rbTbRelatorioTipo.Name = "m_rbTbRelatorioTipo";
			this.m_rbTbRelatorioTipo.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbRelatorioTipo.TabIndex = 53;
			this.m_rbTbRelatorioTipo.Text = "tbRelatorioTipo";
			// 
			// m_rbTbRelatoriosTodosCamposBD
			// 
			this.m_rbTbRelatoriosTodosCamposBD.Location = new System.Drawing.Point(496, 64);
			this.m_rbTbRelatoriosTodosCamposBD.Name = "m_rbTbRelatoriosTodosCamposBD";
			this.m_rbTbRelatoriosTodosCamposBD.Size = new System.Drawing.Size(184, 16);
			this.m_rbTbRelatoriosTodosCamposBD.TabIndex = 52;
			this.m_rbTbRelatoriosTodosCamposBD.Text = "tbRelatoriosTodosCamposBD";
			// 
			// m_rbTbRelatoriosCamposBDRelatorios
			// 
			this.m_rbTbRelatoriosCamposBDRelatorios.Location = new System.Drawing.Point(496, 48);
			this.m_rbTbRelatoriosCamposBDRelatorios.Name = "m_rbTbRelatoriosCamposBDRelatorios";
			this.m_rbTbRelatoriosCamposBDRelatorios.Size = new System.Drawing.Size(208, 16);
			this.m_rbTbRelatoriosCamposBDRelatorios.TabIndex = 51;
			this.m_rbTbRelatoriosCamposBDRelatorios.Text = "tbRelatoriosCamposBDRelatorios";
			// 
			// m_rbTbRelatoriosCamposBDPreRequisitos
			// 
			this.m_rbTbRelatoriosCamposBDPreRequisitos.Location = new System.Drawing.Point(496, 32);
			this.m_rbTbRelatoriosCamposBDPreRequisitos.Name = "m_rbTbRelatoriosCamposBDPreRequisitos";
			this.m_rbTbRelatoriosCamposBDPreRequisitos.Size = new System.Drawing.Size(224, 16);
			this.m_rbTbRelatoriosCamposBDPreRequisitos.TabIndex = 50;
			this.m_rbTbRelatoriosCamposBDPreRequisitos.Text = "tbRelatoriosCamposBDPreRequisitos";
			// 
			// m_rbTbImagens
			// 
			this.m_rbTbImagens.Location = new System.Drawing.Point(496, 16);
			this.m_rbTbImagens.Name = "m_rbTbImagens";
			this.m_rbTbImagens.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbImagens.TabIndex = 49;
			this.m_rbTbImagens.Text = "tbImagens";
			// 
			// m_rbTbRelatorioCamposBD
			// 
			this.m_rbTbRelatorioCamposBD.Location = new System.Drawing.Point(274, 184);
			this.m_rbTbRelatorioCamposBD.Name = "m_rbTbRelatorioCamposBD";
			this.m_rbTbRelatorioCamposBD.Size = new System.Drawing.Size(142, 16);
			this.m_rbTbRelatorioCamposBD.TabIndex = 48;
			this.m_rbTbRelatorioCamposBD.Text = "tbRelatorioCamposBD";
			// 
			// m_rbTbRelatorioRetangulos
			// 
			this.m_rbTbRelatorioRetangulos.Location = new System.Drawing.Point(274, 264);
			this.m_rbTbRelatorioRetangulos.Name = "m_rbTbRelatorioRetangulos";
			this.m_rbTbRelatorioRetangulos.Size = new System.Drawing.Size(150, 16);
			this.m_rbTbRelatorioRetangulos.TabIndex = 47;
			this.m_rbTbRelatorioRetangulos.Text = "tbRelatorioRetangulos";
			// 
			// m_rbTbRelatorioLinhas
			// 
			this.m_rbTbRelatorioLinhas.Location = new System.Drawing.Point(274, 248);
			this.m_rbTbRelatorioLinhas.Name = "m_rbTbRelatorioLinhas";
			this.m_rbTbRelatorioLinhas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbRelatorioLinhas.TabIndex = 46;
			this.m_rbTbRelatorioLinhas.Text = "tbRelatorioLinhas";
			// 
			// m_rbTbRelatorioImagens
			// 
			this.m_rbTbRelatorioImagens.Location = new System.Drawing.Point(274, 232);
			this.m_rbTbRelatorioImagens.Name = "m_rbTbRelatorioImagens";
			this.m_rbTbRelatorioImagens.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbRelatorioImagens.TabIndex = 45;
			this.m_rbTbRelatorioImagens.Text = "tbRelatorioImagens";
			// 
			// m_rbTbRelatorioEtiquetas
			// 
			this.m_rbTbRelatorioEtiquetas.Location = new System.Drawing.Point(274, 216);
			this.m_rbTbRelatorioEtiquetas.Name = "m_rbTbRelatorioEtiquetas";
			this.m_rbTbRelatorioEtiquetas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbRelatorioEtiquetas.TabIndex = 44;
			this.m_rbTbRelatorioEtiquetas.Text = "tbRelatorioEtiquetas";
			// 
			// m_rbTbRelatorioCirculos
			// 
			this.m_rbTbRelatorioCirculos.Location = new System.Drawing.Point(274, 200);
			this.m_rbTbRelatorioCirculos.Name = "m_rbTbRelatorioCirculos";
			this.m_rbTbRelatorioCirculos.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbRelatorioCirculos.TabIndex = 43;
			this.m_rbTbRelatorioCirculos.Text = "tbRelatorioCirculos";
			// 
			// m_rbTbRelatorios
			// 
			this.m_rbTbRelatorios.Location = new System.Drawing.Point(273, 280);
			this.m_rbTbRelatorios.Name = "m_rbTbRelatorios";
			this.m_rbTbRelatorios.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbRelatorios.TabIndex = 42;
			this.m_rbTbRelatorios.Text = "tbRelatorios";
			// 
			// m_rbTbSaques
			// 
			this.m_rbTbSaques.Location = new System.Drawing.Point(569, 125);
			this.m_rbTbSaques.Name = "m_rbTbSaques";
			this.m_rbTbSaques.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbSaques.TabIndex = 41;
			this.m_rbTbSaques.Text = "tbSaques";
			// 
			// m_rbTbCertificadosOrigem
			// 
			this.m_rbTbCertificadosOrigem.Location = new System.Drawing.Point(11, 26);
			this.m_rbTbCertificadosOrigem.Name = "m_rbTbCertificadosOrigem";
			this.m_rbTbCertificadosOrigem.Size = new System.Drawing.Size(149, 16);
			this.m_rbTbCertificadosOrigem.TabIndex = 39;
			this.m_rbTbCertificadosOrigem.Text = "tbCertificadosOrigem";
			// 
			// m_rbTbAssinaturas
			// 
			this.m_rbTbAssinaturas.Location = new System.Drawing.Point(12, 14);
			this.m_rbTbAssinaturas.Name = "m_rbTbAssinaturas";
			this.m_rbTbAssinaturas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbAssinaturas.TabIndex = 38;
			this.m_rbTbAssinaturas.Text = "tbAssinaturas";
			// 
			// m_rbTbPes
			// 
			this.m_rbTbPes.Location = new System.Drawing.Point(144, 344);
			this.m_rbTbPes.Name = "m_rbTbPes";
			this.m_rbTbPes.Size = new System.Drawing.Size(56, 16);
			this.m_rbTbPes.TabIndex = 37;
			this.m_rbTbPes.Text = "tbPes";
			// 
			// m_rbTbUnidadesMassaIdioma
			// 
			this.m_rbTbUnidadesMassaIdioma.Location = new System.Drawing.Point(569, 215);
			this.m_rbTbUnidadesMassaIdioma.Name = "m_rbTbUnidadesMassaIdioma";
			this.m_rbTbUnidadesMassaIdioma.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbUnidadesMassaIdioma.TabIndex = 36;
			this.m_rbTbUnidadesMassaIdioma.Text = "tbUnidadesMassaIdioma";
			// 
			// m_rbTbUnidadesMassa
			// 
			this.m_rbTbUnidadesMassa.Location = new System.Drawing.Point(569, 199);
			this.m_rbTbUnidadesMassa.Name = "m_rbTbUnidadesMassa";
			this.m_rbTbUnidadesMassa.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbUnidadesMassa.TabIndex = 35;
			this.m_rbTbUnidadesMassa.Text = "tbUnidadesMassa";
			// 
			// m_rbTbUnidadesEspacoIdioma
			// 
			this.m_rbTbUnidadesEspacoIdioma.Location = new System.Drawing.Point(569, 183);
			this.m_rbTbUnidadesEspacoIdioma.Name = "m_rbTbUnidadesEspacoIdioma";
			this.m_rbTbUnidadesEspacoIdioma.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbUnidadesEspacoIdioma.TabIndex = 34;
			this.m_rbTbUnidadesEspacoIdioma.Text = "tbUnidadesEspacoIdioma";
			// 
			// m_rbTbUnidadesEspaco
			// 
			this.m_rbTbUnidadesEspaco.Location = new System.Drawing.Point(569, 169);
			this.m_rbTbUnidadesEspaco.Name = "m_rbTbUnidadesEspaco";
			this.m_rbTbUnidadesEspaco.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbUnidadesEspaco.TabIndex = 33;
			this.m_rbTbUnidadesEspaco.Text = "tbUnidadesEspaco";
			// 
			// m_rbTbProdutosRomaneioVolumesProdutos
			// 
			this.m_rbTbProdutosRomaneioVolumesProdutos.Location = new System.Drawing.Point(272, 168);
			this.m_rbTbProdutosRomaneioVolumesProdutos.Name = "m_rbTbProdutosRomaneioVolumesProdutos";
			this.m_rbTbProdutosRomaneioVolumesProdutos.Size = new System.Drawing.Size(216, 16);
			this.m_rbTbProdutosRomaneioVolumesProdutos.TabIndex = 32;
			this.m_rbTbProdutosRomaneioVolumesProdutos.Text = "tbProdutosRomaneioVolumesProdutos";
			// 
			// m_rbTbProdutosRomaneioVolumesEmbalagens
			// 
			this.m_rbTbProdutosRomaneioVolumesEmbalagens.Location = new System.Drawing.Point(272, 152);
			this.m_rbTbProdutosRomaneioVolumesEmbalagens.Name = "m_rbTbProdutosRomaneioVolumesEmbalagens";
			this.m_rbTbProdutosRomaneioVolumesEmbalagens.Size = new System.Drawing.Size(240, 16);
			this.m_rbTbProdutosRomaneioVolumesEmbalagens.TabIndex = 31;
			this.m_rbTbProdutosRomaneioVolumesEmbalagens.Text = "tbProdutosRomaneioVolumesEmbalagens";
			// 
			// m_rbTbProdutosRomaneioVolumes
			// 
			this.m_rbTbProdutosRomaneioVolumes.Location = new System.Drawing.Point(273, 136);
			this.m_rbTbProdutosRomaneioVolumes.Name = "m_rbTbProdutosRomaneioVolumes";
			this.m_rbTbProdutosRomaneioVolumes.Size = new System.Drawing.Size(216, 16);
			this.m_rbTbProdutosRomaneioVolumes.TabIndex = 30;
			this.m_rbTbProdutosRomaneioVolumes.Text = "tbProdutosRomaneioVolumes";
			// 
			// m_rbTbProdutosRomaneioEmbalagensProdutos
			// 
			this.m_rbTbProdutosRomaneioEmbalagensProdutos.Location = new System.Drawing.Point(272, 120);
			this.m_rbTbProdutosRomaneioEmbalagensProdutos.Name = "m_rbTbProdutosRomaneioEmbalagensProdutos";
			this.m_rbTbProdutosRomaneioEmbalagensProdutos.Size = new System.Drawing.Size(240, 16);
			this.m_rbTbProdutosRomaneioEmbalagensProdutos.TabIndex = 29;
			this.m_rbTbProdutosRomaneioEmbalagensProdutos.Text = "tbProdutosRomaneioEmbalagensProdutos";
			// 
			// m_rbTbVolumes
			// 
			this.m_rbTbVolumes.Location = new System.Drawing.Point(571, 238);
			this.m_rbTbVolumes.Name = "m_rbTbVolumes";
			this.m_rbTbVolumes.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbVolumes.TabIndex = 28;
			this.m_rbTbVolumes.Text = "tbVolumes";
			// 
			// m_rbTbExportadoresVolumes
			// 
			this.m_rbTbExportadoresVolumes.Location = new System.Drawing.Point(16, 232);
			this.m_rbTbExportadoresVolumes.Name = "m_rbTbExportadoresVolumes";
			this.m_rbTbExportadoresVolumes.Size = new System.Drawing.Size(156, 16);
			this.m_rbTbExportadoresVolumes.TabIndex = 27;
			this.m_rbTbExportadoresVolumes.Text = "tbExportadoresVolumes";
			// 
			// m_rbTbImportadoresBancos
			// 
			this.m_rbTbImportadoresBancos.Location = new System.Drawing.Point(16, 264);
			this.m_rbTbImportadoresBancos.Name = "m_rbTbImportadoresBancos";
			this.m_rbTbImportadoresBancos.Size = new System.Drawing.Size(140, 16);
			this.m_rbTbImportadoresBancos.TabIndex = 26;
			this.m_rbTbImportadoresBancos.Text = "tbImportadoresBancos";
			// 
			// m_rbTbExportadoresBancosAgenciasContas
			// 
			this.m_rbTbExportadoresBancosAgenciasContas.Location = new System.Drawing.Point(16, 216);
			this.m_rbTbExportadoresBancosAgenciasContas.Name = "m_rbTbExportadoresBancosAgenciasContas";
			this.m_rbTbExportadoresBancosAgenciasContas.Size = new System.Drawing.Size(224, 16);
			this.m_rbTbExportadoresBancosAgenciasContas.TabIndex = 25;
			this.m_rbTbExportadoresBancosAgenciasContas.Text = "tbExportadoresBancosAgenciasContas";
			// 
			// m_rbTbExportadoresBancosAgencias
			// 
			this.m_rbTbExportadoresBancosAgencias.Location = new System.Drawing.Point(16, 200);
			this.m_rbTbExportadoresBancosAgencias.Name = "m_rbTbExportadoresBancosAgencias";
			this.m_rbTbExportadoresBancosAgencias.Size = new System.Drawing.Size(192, 16);
			this.m_rbTbExportadoresBancosAgencias.TabIndex = 24;
			this.m_rbTbExportadoresBancosAgencias.Text = "tbExportadoresBancosAgencias";
			// 
			// m_rbTbExportadoresBancos
			// 
			this.m_rbTbExportadoresBancos.Location = new System.Drawing.Point(16, 184);
			this.m_rbTbExportadoresBancos.Name = "m_rbTbExportadoresBancos";
			this.m_rbTbExportadoresBancos.Size = new System.Drawing.Size(168, 16);
			this.m_rbTbExportadoresBancos.TabIndex = 23;
			this.m_rbTbExportadoresBancos.Text = "tbExportadoresBancos";
			// 
			// m_rbTbEstadosBrasileiros
			// 
			this.m_rbTbEstadosBrasileiros.Location = new System.Drawing.Point(17, 103);
			this.m_rbTbEstadosBrasileiros.Name = "m_rbTbEstadosBrasileiros";
			this.m_rbTbEstadosBrasileiros.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbEstadosBrasileiros.TabIndex = 22;
			this.m_rbTbEstadosBrasileiros.Text = "tbEstadosBrasileiros";
			// 
			// m_rbTbProdutosRomaneioEmbalagens
			// 
			this.m_rbTbProdutosRomaneioEmbalagens.Location = new System.Drawing.Point(272, 104);
			this.m_rbTbProdutosRomaneioEmbalagens.Name = "m_rbTbProdutosRomaneioEmbalagens";
			this.m_rbTbProdutosRomaneioEmbalagens.Size = new System.Drawing.Size(216, 16);
			this.m_rbTbProdutosRomaneioEmbalagens.TabIndex = 18;
			this.m_rbTbProdutosRomaneioEmbalagens.Text = "tbProdutosRomaneioEmbalagens";
			// 
			// m_rbTbImportadoresConsignatarios
			// 
			this.m_rbTbImportadoresConsignatarios.Location = new System.Drawing.Point(16, 280);
			this.m_rbTbImportadoresConsignatarios.Name = "m_rbTbImportadoresConsignatarios";
			this.m_rbTbImportadoresConsignatarios.Size = new System.Drawing.Size(175, 16);
			this.m_rbTbImportadoresConsignatarios.TabIndex = 16;
			this.m_rbTbImportadoresConsignatarios.Text = "tbImportadoresConsignatarios";
			// 
			// m_rbTbImportadores
			// 
			this.m_rbTbImportadores.Location = new System.Drawing.Point(16, 248);
			this.m_rbTbImportadores.Name = "m_rbTbImportadores";
			this.m_rbTbImportadores.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbImportadores.TabIndex = 15;
			this.m_rbTbImportadores.Text = "tbImportadores";
			// 
			// m_rbTbPaisesIdiomas
			// 
			this.m_rbTbPaisesIdiomas.Location = new System.Drawing.Point(16, 344);
			this.m_rbTbPaisesIdiomas.Name = "m_rbTbPaisesIdiomas";
			this.m_rbTbPaisesIdiomas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbPaisesIdiomas.TabIndex = 14;
			this.m_rbTbPaisesIdiomas.Text = "tbPaisesIdiomas";
			// 
			// m_rbTbPaises
			// 
			this.m_rbTbPaises.Location = new System.Drawing.Point(16, 328);
			this.m_rbTbPaises.Name = "m_rbTbPaises";
			this.m_rbTbPaises.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbPaises.TabIndex = 13;
			this.m_rbTbPaises.Text = "tbPaises";
			// 
			// m_rbTbIdiomasTextos
			// 
			this.m_rbTbIdiomasTextos.Location = new System.Drawing.Point(144, 328);
			this.m_rbTbIdiomasTextos.Name = "m_rbTbIdiomasTextos";
			this.m_rbTbIdiomasTextos.Size = new System.Drawing.Size(112, 16);
			this.m_rbTbIdiomasTextos.TabIndex = 12;
			this.m_rbTbIdiomasTextos.Text = "tbIdiomasTextos";
			// 
			// m_rbTbIdiomas
			// 
			this.m_rbTbIdiomas.Location = new System.Drawing.Point(181, 312);
			this.m_rbTbIdiomas.Name = "m_rbTbIdiomas";
			this.m_rbTbIdiomas.Size = new System.Drawing.Size(96, 16);
			this.m_rbTbIdiomas.TabIndex = 11;
			this.m_rbTbIdiomas.Text = "tbIdiomas";
			// 
			// m_rbTbProdutosIdiomas
			// 
			this.m_rbTbProdutosIdiomas.Location = new System.Drawing.Point(281, 76);
			this.m_rbTbProdutosIdiomas.Name = "m_rbTbProdutosIdiomas";
			this.m_rbTbProdutosIdiomas.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutosIdiomas.TabIndex = 10;
			this.m_rbTbProdutosIdiomas.Text = "tbProdutosIdiomas";
			// 
			// m_rbTbProdutosFaturaProforma
			// 
			this.m_rbTbProdutosFaturaProforma.Location = new System.Drawing.Point(280, 62);
			this.m_rbTbProdutosFaturaProforma.Name = "m_rbTbProdutosFaturaProforma";
			this.m_rbTbProdutosFaturaProforma.Size = new System.Drawing.Size(160, 16);
			this.m_rbTbProdutosFaturaProforma.TabIndex = 9;
			this.m_rbTbProdutosFaturaProforma.Text = "tbProdutosFaturaProforma";
			// 
			// m_rbTbProdutosFaturaComercial
			// 
			this.m_rbTbProdutosFaturaComercial.Location = new System.Drawing.Point(281, 32);
			this.m_rbTbProdutosFaturaComercial.Name = "m_rbTbProdutosFaturaComercial";
			this.m_rbTbProdutosFaturaComercial.Size = new System.Drawing.Size(167, 16);
			this.m_rbTbProdutosFaturaComercial.TabIndex = 8;
			this.m_rbTbProdutosFaturaComercial.Text = "tbProdutosFaturaComercial";
			// 
			// m_rbTbProdutosFaturaCotacao
			// 
			this.m_rbTbProdutosFaturaCotacao.Location = new System.Drawing.Point(281, 46);
			this.m_rbTbProdutosFaturaCotacao.Name = "m_rbTbProdutosFaturaCotacao";
			this.m_rbTbProdutosFaturaCotacao.Size = new System.Drawing.Size(167, 16);
			this.m_rbTbProdutosFaturaCotacao.TabIndex = 7;
			this.m_rbTbProdutosFaturaCotacao.Text = "tbProdutosFaturaCotacao";
			// 
			// m_rbTbFaturasProformas
			// 
			this.m_rbTbFaturasProformas.Location = new System.Drawing.Point(16, 392);
			this.m_rbTbFaturasProformas.Name = "m_rbTbFaturasProformas";
			this.m_rbTbFaturasProformas.Size = new System.Drawing.Size(129, 16);
			this.m_rbTbFaturasProformas.TabIndex = 6;
			this.m_rbTbFaturasProformas.Text = "tbFaturasProformas";
			// 
			// m_rbTbFaturasCotacoes
			// 
			this.m_rbTbFaturasCotacoes.Location = new System.Drawing.Point(16, 376);
			this.m_rbTbFaturasCotacoes.Name = "m_rbTbFaturasCotacoes";
			this.m_rbTbFaturasCotacoes.Size = new System.Drawing.Size(121, 16);
			this.m_rbTbFaturasCotacoes.TabIndex = 5;
			this.m_rbTbFaturasCotacoes.Text = "tbFaturasCotacoes";
			// 
			// m_rbTbFaturasComerciais
			// 
			this.m_rbTbFaturasComerciais.Checked = true;
			this.m_rbTbFaturasComerciais.Location = new System.Drawing.Point(16, 360);
			this.m_rbTbFaturasComerciais.Name = "m_rbTbFaturasComerciais";
			this.m_rbTbFaturasComerciais.Size = new System.Drawing.Size(130, 16);
			this.m_rbTbFaturasComerciais.TabIndex = 4;
			this.m_rbTbFaturasComerciais.TabStop = true;
			this.m_rbTbFaturasComerciais.Text = "tbFaturasComerciais";
			// 
			// m_rbTbMoedas
			// 
			this.m_rbTbMoedas.Location = new System.Drawing.Point(181, 296);
			this.m_rbTbMoedas.Name = "m_rbTbMoedas";
			this.m_rbTbMoedas.Size = new System.Drawing.Size(104, 16);
			this.m_rbTbMoedas.TabIndex = 3;
			this.m_rbTbMoedas.Text = "tbMoedas";
			// 
			// m_rbTbExportadores
			// 
			this.m_rbTbExportadores.Location = new System.Drawing.Point(16, 119);
			this.m_rbTbExportadores.Name = "m_rbTbExportadores";
			this.m_rbTbExportadores.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbExportadores.TabIndex = 2;
			this.m_rbTbExportadores.Text = "tbExportadores";
			// 
			// m_rbTbProdutos
			// 
			this.m_rbTbProdutos.Location = new System.Drawing.Point(280, 16);
			this.m_rbTbProdutos.Name = "m_rbTbProdutos";
			this.m_rbTbProdutos.Size = new System.Drawing.Size(128, 16);
			this.m_rbTbProdutos.TabIndex = 1;
			this.m_rbTbProdutos.Text = "tbProdutos";
			// 
			// m_rbTbInstrucoesEmbarque
			// 
			this.m_rbTbInstrucoesEmbarque.Location = new System.Drawing.Point(16, 312);
			this.m_rbTbInstrucoesEmbarque.Name = "m_rbTbInstrucoesEmbarque";
			this.m_rbTbInstrucoesEmbarque.Size = new System.Drawing.Size(141, 16);
			this.m_rbTbInstrucoesEmbarque.TabIndex = 40;
			this.m_rbTbInstrucoesEmbarque.Text = "tbInstrucoesEmbarque";
			// 
			// m_rbTbMensagens
			// 
			this.m_rbTbMensagens.Location = new System.Drawing.Point(184, 248);
			this.m_rbTbMensagens.Name = "m_rbTbMensagens";
			this.m_rbTbMensagens.Size = new System.Drawing.Size(96, 16);
			this.m_rbTbMensagens.TabIndex = 104;
			this.m_rbTbMensagens.Text = "tbMensagens";
			// 
			// m_rbTbImportadoresEndEntrega
			// 
			this.m_rbTbImportadoresEndEntrega.Location = new System.Drawing.Point(16, 296);
			this.m_rbTbImportadoresEndEntrega.Name = "m_rbTbImportadoresEndEntrega";
			this.m_rbTbImportadoresEndEntrega.Size = new System.Drawing.Size(175, 16);
			this.m_rbTbImportadoresEndEntrega.TabIndex = 17;
			this.m_rbTbImportadoresEndEntrega.Text = "tbImportadoresEndEntrega";
			// 
			// m_rbTbPropriedadesProdutos
			// 
			this.m_rbTbPropriedadesProdutos.Location = new System.Drawing.Point(408, 328);
			this.m_rbTbPropriedadesProdutos.Name = "m_rbTbPropriedadesProdutos";
			this.m_rbTbPropriedadesProdutos.Size = new System.Drawing.Size(144, 16);
			this.m_rbTbPropriedadesProdutos.TabIndex = 115;
			this.m_rbTbPropriedadesProdutos.Text = "tbPropriedadesProdutos";
			// 
			// m_rbTbProdutosFaturaComercialPropriedades
			// 
			this.m_rbTbProdutosFaturaComercialPropriedades.Location = new System.Drawing.Point(409, 344);
			this.m_rbTbProdutosFaturaComercialPropriedades.Name = "m_rbTbProdutosFaturaComercialPropriedades";
			this.m_rbTbProdutosFaturaComercialPropriedades.Size = new System.Drawing.Size(183, 16);
			this.m_rbTbProdutosFaturaComercialPropriedades.TabIndex = 116;
			this.m_rbTbProdutosFaturaComercialPropriedades.Text = "tbProdutosFaturaComercialPropriedades";
			// 
			// m_gbDataAccess
			// 
			this.m_gbDataAccess.Controls.Add(this.m_txtPortFireBird);
			this.m_gbDataAccess.Controls.Add(this.m_lbPortFireBird);
			this.m_gbDataAccess.Controls.Add(this.m_rbDataAccessFireBird);
			this.m_gbDataAccess.Controls.Add(this.m_txtPortSqlServer);
			this.m_gbDataAccess.Controls.Add(this.m_lbPortSqlServer);
			this.m_gbDataAccess.Controls.Add(this.m_txtPortMysql);
			this.m_gbDataAccess.Controls.Add(this.m_lbPortMysql);
			this.m_gbDataAccess.Controls.Add(this.m_rbDataAccessSQLSERVER);
			this.m_gbDataAccess.Controls.Add(this.m_rbDataAccessMySQL);
			this.m_gbDataAccess.Controls.Add(this.m_rbDataAccessOleDBJet);
			this.m_gbDataAccess.Location = new System.Drawing.Point(8, 16);
			this.m_gbDataAccess.Name = "m_gbDataAccess";
			this.m_gbDataAccess.Size = new System.Drawing.Size(192, 104);
			this.m_gbDataAccess.TabIndex = 2;
			this.m_gbDataAccess.TabStop = false;
			this.m_gbDataAccess.Text = "Data Access";
			// 
			// m_txtPortFireBird
			// 
			this.m_txtPortFireBird.Location = new System.Drawing.Point(137, 69);
			this.m_txtPortFireBird.Name = "m_txtPortFireBird";
			this.m_txtPortFireBird.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortFireBird.TabIndex = 16;
			this.m_txtPortFireBird.Text = "3050";
			this.m_txtPortFireBird.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPortFireBird
			// 
			this.m_lbPortFireBird.Location = new System.Drawing.Point(101, 69);
			this.m_lbPortFireBird.Name = "m_lbPortFireBird";
			this.m_lbPortFireBird.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortFireBird.TabIndex = 15;
			this.m_lbPortFireBird.Text = "Port:";
			// 
			// m_rbDataAccessFireBird
			// 
			this.m_rbDataAccessFireBird.Enabled = false;
			this.m_rbDataAccessFireBird.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDataAccessFireBird.Location = new System.Drawing.Point(6, 69);
			this.m_rbDataAccessFireBird.Name = "m_rbDataAccessFireBird";
			this.m_rbDataAccessFireBird.Size = new System.Drawing.Size(82, 16);
			this.m_rbDataAccessFireBird.TabIndex = 14;
			this.m_rbDataAccessFireBird.Text = "FireBird";
			// 
			// m_txtPortSqlServer
			// 
			this.m_txtPortSqlServer.Location = new System.Drawing.Point(137, 48);
			this.m_txtPortSqlServer.Name = "m_txtPortSqlServer";
			this.m_txtPortSqlServer.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortSqlServer.TabIndex = 13;
			this.m_txtPortSqlServer.Text = "1433";
			this.m_txtPortSqlServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPortSqlServer
			// 
			this.m_lbPortSqlServer.Location = new System.Drawing.Point(101, 49);
			this.m_lbPortSqlServer.Name = "m_lbPortSqlServer";
			this.m_lbPortSqlServer.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortSqlServer.TabIndex = 12;
			this.m_lbPortSqlServer.Text = "Port:";
			// 
			// m_txtPortMysql
			// 
			this.m_txtPortMysql.Location = new System.Drawing.Point(137, 24);
			this.m_txtPortMysql.Name = "m_txtPortMysql";
			this.m_txtPortMysql.Size = new System.Drawing.Size(40, 20);
			this.m_txtPortMysql.TabIndex = 11;
			this.m_txtPortMysql.Text = "3306";
			this.m_txtPortMysql.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_lbPortMysql
			// 
			this.m_lbPortMysql.Location = new System.Drawing.Point(100, 32);
			this.m_lbPortMysql.Name = "m_lbPortMysql";
			this.m_lbPortMysql.Size = new System.Drawing.Size(32, 16);
			this.m_lbPortMysql.TabIndex = 10;
			this.m_lbPortMysql.Text = "Port:";
			// 
			// m_rbDataAccessSQLSERVER
			// 
			this.m_rbDataAccessSQLSERVER.Checked = true;
			this.m_rbDataAccessSQLSERVER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDataAccessSQLSERVER.Location = new System.Drawing.Point(6, 48);
			this.m_rbDataAccessSQLSERVER.Name = "m_rbDataAccessSQLSERVER";
			this.m_rbDataAccessSQLSERVER.Size = new System.Drawing.Size(82, 16);
			this.m_rbDataAccessSQLSERVER.TabIndex = 9;
			this.m_rbDataAccessSQLSERVER.TabStop = true;
			this.m_rbDataAccessSQLSERVER.Text = "SqlServer";
			// 
			// m_rbDataAccessMySQL
			// 
			this.m_rbDataAccessMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDataAccessMySQL.Location = new System.Drawing.Point(6, 32);
			this.m_rbDataAccessMySQL.Name = "m_rbDataAccessMySQL";
			this.m_rbDataAccessMySQL.Size = new System.Drawing.Size(74, 16);
			this.m_rbDataAccessMySQL.TabIndex = 7;
			this.m_rbDataAccessMySQL.Text = "MySQL";
			// 
			// m_rbDataAccessOleDBJet
			// 
			this.m_rbDataAccessOleDBJet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDataAccessOleDBJet.Location = new System.Drawing.Point(6, 16);
			this.m_rbDataAccessOleDBJet.Name = "m_rbDataAccessOleDBJet";
			this.m_rbDataAccessOleDBJet.Size = new System.Drawing.Size(98, 16);
			this.m_rbDataAccessOleDBJet.TabIndex = 3;
			this.m_rbDataAccessOleDBJet.Text = "Jet40";
			// 
			// m_gbOutPut
			// 
			this.m_gbOutPut.Controls.Add(this.m_dgOutput);
			this.m_gbOutPut.Location = new System.Drawing.Point(6, 611);
			this.m_gbOutPut.Name = "m_gbOutPut";
			this.m_gbOutPut.Size = new System.Drawing.Size(1090, 175);
			this.m_gbOutPut.TabIndex = 1;
			this.m_gbOutPut.TabStop = false;
			this.m_gbOutPut.Text = "Output";
			// 
			// m_dgOutput
			// 
			this.m_dgOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dgOutput.DataMember = "";
			this.m_dgOutput.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgOutput.Location = new System.Drawing.Point(8, 17);
			this.m_dgOutput.Name = "m_dgOutput";
			this.m_dgOutput.Size = new System.Drawing.Size(1072, 152);
			this.m_dgOutput.TabIndex = 0;
			// 
			// m_btDeleteAllDataBase
			// 
			this.m_btDeleteAllDataBase.Location = new System.Drawing.Point(424, 547);
			this.m_btDeleteAllDataBase.Name = "m_btDeleteAllDataBase";
			this.m_btDeleteAllDataBase.Size = new System.Drawing.Size(64, 32);
			this.m_btDeleteAllDataBase.TabIndex = 30;
			this.m_btDeleteAllDataBase.Text = "Delete DataBase";
			this.m_btDeleteAllDataBase.Click += new System.EventHandler(this.m_btDeleteAllDataBase_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1120, 798);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Base Access";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbAdmin.ResumeLayout(false);
			this.m_gbPersistencia.ResumeLayout(false);
			this.m_gbConnectionType.ResumeLayout(false);
			this.m_gbIntegridade.ResumeLayout(false);
			this.m_gbConfiguracao.ResumeLayout(false);
			this.m_gbCondicoes.ResumeLayout(false);
			this.m_gbLogin.ResumeLayout(false);
			this.m_dgPath.ResumeLayout(false);
			this.m_gbAcao.ResumeLayout(false);
			this.m_gbDados.ResumeLayout(false);
			this.m_gbDataAccess.ResumeLayout(false);
			this.m_gbOutPut.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgOutput)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void Form1_Load(object sender, System.EventArgs e)
			{
				RefreshCondicaoComparador();
			}

			private void m_btAllRowsNew_Click(object sender, System.EventArgs e)
			{
				vSetAllLinesAdded();
			}
		#endregion

		#region DataBaseAccess
			private void CreateDataBaseAccess()
			{
				m_dgOutput.DataSource = null;
				if ((m_cls_dba_conexaoBD == null) || (!m_ckPersistDB.Checked))
				{
					// JET40
					if (this.m_rbDataAccessOleDBJet.Checked)
						m_cls_dba_conexaoBD = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref m_cls_ter_tratadorErro,m_txtPathJet40.Text,m_txtUser.Text,m_txtPassword.Text);

					// SQLServer
					if (this.m_rbDataAccessSQLSERVER.Checked)
						m_cls_dba_conexaoBD = new mdlDataBaseAccess.clsDataBaseAccessSqlServer(ref m_cls_ter_tratadorErro,m_txtHost.Text,m_txtPortSqlServer.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

					// MySql
					if (this.m_rbDataAccessMySQL.Checked)
						m_cls_dba_conexaoBD = new mdlDataBaseAccess.clsDataBaseAccessMySql(ref m_cls_ter_tratadorErro,m_txtHost.Text,m_txtPortMysql.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);

					// FireBird
//					if (this.m_rbDataAccessFireBird.Checked)
//						m_cls_dba_conexaoBD = new mdlDataBaseAccess.clsDataBaseAccessFireBird(ref m_cls_ter_tratadorErro,m_txtHost.Text,m_txtPortFireBird.Text,m_txtDataBaseName.Text,m_txtUser.Text,m_txtPassword.Text);
				}
				if (m_ckPersistData.Checked != m_cls_dba_conexaoBD.DataPersist)
					m_cls_dba_conexaoBD.DataPersist = m_ckPersistData.Checked;
				if (m_ckIntegrityUpdate.Checked)
					m_cls_dba_conexaoBD.CheckIntegrityUpdate = true;
				if (m_ckFonteDadosResource.Checked)
					m_cls_dba_conexaoBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				else
					m_cls_dba_conexaoBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_cls_dba_conexaoBD.WriteXML = m_ckWriteXML.Checked;
				m_cls_dba_conexaoBD.DBHost = m_txtHost.Text;
				m_cls_dba_conexaoBD.DBUser = m_txtUser.Text;
				m_cls_dba_conexaoBD.DBPassword = m_txtPassword.Text;
				m_cls_dba_conexaoBD.DBDataBaseName = m_txtDataBaseName.Text;
				m_cls_dba_conexaoBD.ShowDialogsErrors = true;
				m_cls_dba_conexaoBD.SystemMode = mdlDataBaseAccess.Mode.Developer;
			}

			private void CreateDataBaseAccessAdmin()
			{
				CreateDataBaseAccess();
				m_cls_dba_conexaoBD.DBAdminUser = m_txtAdminUser.Text;
				m_cls_dba_conexaoBD.DBAdminPassword = m_txtAdminPassword.Text;
			}
		#endregion 
		#region Condicoes
			private void RefreshCondicaoComparador()
			{
				m_cbCondicaoComparador.Items.Clear();
				m_cbCondicaoComparador.Items.Add(COMPARADOR_IGUAL);
				m_cbCondicaoComparador.Items.Add(COMPARADOR_DIFERENTE);
				m_cbCondicaoComparador.Items.Add(COMPARADOR_MAIOR);
				m_cbCondicaoComparador.Items.Add(COMPARADOR_MENOR);
				m_cbCondicaoComparador.Items.Add(COMPARADOR_MAIOR_IGUAL);
				m_cbCondicaoComparador.Items.Add(COMPARADOR_MENOR_IGUAL);
			}

			private void m_btCondicaoClear_Click(object sender, System.EventArgs e)
			{
				m_arlCondicaoCampo = new System.Collections.ArrayList();
				m_arlCondicaoComparador = new System.Collections.ArrayList();
				m_arlCondicaoValor = new System.Collections.ArrayList();
			}

			private bool bInsereValorColecao(string strValor)
			{
				bool bRetorno = false;
				string strValorReal;

				// String 
				if ((!bRetorno) && (strValor.StartsWith("str")))
				{
					strValorReal = strValor.Substring("str".Length);
					m_arlCondicaoValor.Add(strValorReal);
					bRetorno = true;
   				}

				// Integer
				if ((!bRetorno) && (strValor.StartsWith("n")))
				{
					strValorReal = strValor.Substring("n".Length);
					try
					{
						m_arlCondicaoValor.Add(Int32.Parse(strValorReal));
					}catch{}
					bRetorno = true;
				}

				// Double
				if ((!bRetorno) && (strValor.StartsWith("d")))
				{
					strValorReal = strValor.Substring("d".Length);
					try
					{
						m_arlCondicaoValor.Add(double.Parse(strValorReal));
					}
					catch{}
					bRetorno = true;
				}

				return (bRetorno);
			}

			private void InsereComparadorColecao(string strComparador)
			{
				switch(strComparador)
				{
					case COMPARADOR_IGUAL:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						break;
					case COMPARADOR_DIFERENTE:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Diferente);
						break;
					case COMPARADOR_MAIOR:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Maior);
						break;
					case COMPARADOR_MENOR:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Menor);
						break;
					case COMPARADOR_MAIOR_IGUAL:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.MaiorOuIgual);
						break;
					case COMPARADOR_MENOR_IGUAL:
						m_arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.MenorOuIgual);
						break;
				}
			}

			private void m_btCondicaoInsert_Click(object sender, System.EventArgs e)
			{
				if ((m_txtCondicaoCampo.Text != "") && (m_txtCondicaoValor.Text != "") && ((m_cbCondicaoComparador.Text == COMPARADOR_IGUAL) || (m_cbCondicaoComparador.Text == COMPARADOR_DIFERENTE) || (m_cbCondicaoComparador.Text == COMPARADOR_MAIOR) || (m_cbCondicaoComparador.Text == COMPARADOR_MENOR) || (m_cbCondicaoComparador.Text == COMPARADOR_MAIOR_IGUAL) || (m_cbCondicaoComparador.Text == COMPARADOR_MENOR_IGUAL)))
				{
					if (bInsereValorColecao(m_txtCondicaoValor.Text))
					{
						m_arlCondicaoCampo.Add(m_txtCondicaoCampo.Text);
						InsereComparadorColecao(m_cbCondicaoComparador.Text);
						m_txtCondicaoCampo.Text = "";
						m_txtCondicaoValor.Text = "";
					}
				}
			}
		#endregion
		#region Relatorios Padrão
			private void m_btRelatoriosPadrao_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccess();
				frmFRelatoriosPadrao formFRelatoriosPadrao = new frmFRelatoriosPadrao(ref m_cls_dba_conexaoBD);
				formFRelatoriosPadrao.ShowDialog();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Servers
			private void m_btServersList_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccess();
				string[] astrServers = m_cls_dba_conexaoBD.astrServersAvailables();
				System.Data.DataTable dttbServers = new DataTable();
				dttbServers.Columns.Add("Server");
				if (astrServers != null)
				{
					foreach(string strServer in astrServers)
					{
						System.Data.DataRow dtrwServer = dttbServers.NewRow();
						dtrwServer["Server"] = strServer;
						dttbServers.Rows.Add(dtrwServer);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				m_dgOutput.DataSource = dttbServers;
			}
		#endregion

		#region Configuracao
			#region Set
				private void m_btConfiguracaoSet_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					m_cls_dba_conexaoBD.SetConfiguracao(m_txtConfiguracaoVariavel.Text,m_txtConfiguracaoValor.Text);
				}
			#endregion
			#region Get
				private void m_btConfiguracaoGetStr_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					string strRetorno = m_cls_dba_conexaoBD.GetConfiguracao(m_txtConfiguracaoVariavel.Text,m_txtConfiguracaoValorDefault.Text);
					m_txtConfiguracaoRetorno.Text = strRetorno;
				}

				private void m_btConfiguracaoGetInt_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					int nRetorno = m_cls_dba_conexaoBD.GetConfiguracao(m_txtConfiguracaoVariavel.Text,Int32.Parse(m_txtConfiguracaoValorDefault.Text));
					m_txtConfiguracaoRetorno.Text = nRetorno.ToString();
				}

				private void m_btConfiguracaoGetDataTime_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					System.DateTime dtRetorno = m_cls_dba_conexaoBD.GetConfiguracao(m_txtConfiguracaoVariavel.Text,System.DateTime.Parse(m_txtConfiguracaoValorDefault.Text));
					m_txtConfiguracaoRetorno.Text = dtRetorno.ToString();
				}
			#endregion
			#region Memory
				private void m_btConfiguracaoLoad_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					m_cls_dba_conexaoBD.vLoadConfigurationInMemory();
				}

				private void m_btConfiguracaoClear_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					m_cls_dba_conexaoBD.vClearConfigurationInMemory();
				}

				private void m_btConfiguracaoSave_Click(object sender, System.EventArgs e)
				{
					CreateDataBaseAccess();
					m_cls_dba_conexaoBD.vSaveConfigurationFromMemory();
				}
			#endregion
		#endregion
		#region Update DataBase
			private void m_btUpdateDataBase_Click(object sender, System.EventArgs e)
			{
				CreateDataBaseAccess();
				m_cls_dba_conexaoBD.ShowDialogsErrors = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.nUpdateDataBase().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void vSetAllLinesAdded()
			{
				if (m_dgOutput.DataSource != null)
				{
					System.Data.DataSet dtstDados = (System.Data.DataSet)m_dgOutput.DataSource;
					System.Data.DataSet dtstDadosClone = dtstDados.Copy();
					System.Data.DataTable dttbDadosClone = null;
					System.Data.DataRow dtrwDadoClone = null;
					foreach(System.Data.DataTable dttbDados in dtstDados.Tables)
					{
						dttbDadosClone = dtstDadosClone.Tables[dttbDados.TableName];
						dttbDadosClone.Rows.Clear();
						dttbDadosClone.AcceptChanges();
						foreach(System.Data.DataRow dtrwDado in dttbDados.Rows)
						{
							dtrwDadoClone = dttbDadosClone.NewRow();
							foreach(System.Data.DataColumn dtclDado in dttbDados.Columns)
							{
								dtrwDadoClone[dtclDado.ColumnName] = dtrwDado[dtclDado.ColumnName];
							}
							dttbDadosClone.Rows.Add(dtrwDadoClone);
						}
						m_dgOutput.DataSource = dtstDadosClone;
					}
				}
			}
		#endregion
		#region Admin
			private void m_btAdminDataBaseAvailable_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bDataBaseAvailable().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btAdminCreateDataBase_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bDataBaseCreate().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btUserAvailable_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bUserAvailable().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btUserAdd_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bUserCreate().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btAdminUserAssociated_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bUserAssociated().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			private void m_btAdminUserAssociate_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				CreateDataBaseAccessAdmin();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.bUserAssociate().ToString();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Get
			private void m_btGet_Click(object sender, System.EventArgs e)
			{
				System.Data.DataSet dtsetTemp = null;
				if (m_ckDontPutDataInDataGrid.Checked)
					dtsetTemp = (System.Data.DataSet)m_dgOutput.DataSource;

				CreateDataBaseAccess();
				System.DateTime dtCronometro = System.DateTime.Now;
				
				#region tbAgentesCargas
				if (m_rbTbAgentesCargas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbAgentesCargas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbAgentesCargasContatos
				if (m_rbTbAgentesCargasContatos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbAgentesCargasContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbArmadores
				if (m_rbTbArmadores.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbArmadores(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbArmadoresNavios
				if (m_rbTbArmadoresNavios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbArmadoresNavios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbAssinaturas
				if (m_rbTbAssinaturas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbAssinaturas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbBorderos
				if (m_rbTbBorderos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbBorderos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbBorderosSecundarios
				if (m_rbTbBorderosSecundarios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbBorderosSecundarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbCartasCredito
				if (m_rbTbCartasCredito.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbCartasCredito(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbCertificadosOrigem
				if (m_rbTbCertificadosOrigem.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbCertificadosOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbCertificadosOrigemNormas
				if (m_rbTbCertificadosOrigemNormas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbCertificadosOrigemNormas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbConfiguracoes
				if (m_rbTbConfiguracoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbConfiguracoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbContratosCambio
				if (m_rbTbContratosCambio.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbContratosCambio(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbDespachantes
				if (m_rbTbDespachantes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbDespachantes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbDespachantesContatos
				if (m_rbTbDespachantesContatos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbDespachantesContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbDSEs
				if (m_rbTbDSEs.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbDSEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbDSEsPEs
				if (m_rbTbDSEsPEs.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbDSEsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbEstadosBrasileiros
				if (m_rbTbEstadosBrasileiros.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbEstadosBrasileiros(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbErros
				if (m_rbTbErros.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbErros(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbExportadores
				if (m_rbTbExportadores.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadores(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresAgentesVendas
				if (m_rbTbExportadoresAgentesVendas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadoresAgentesVendas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresAgentesVendasBancos
				if (m_rbTbExportadoresAgentesVendasBancos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadoresAgentesVendasBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresBancos
				if (m_rbTbExportadoresBancos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadoresBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresBancosAgencias
				if (m_rbTbExportadoresBancosAgencias.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadoresBancosAgencias(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresBancosAgenciasContas
				if (m_rbTbExportadoresBancosAgenciasContas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbExportadoresBancosAgenciasContas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbExportadoresVolumes
				#endregion

				#region tbFaturasComerciais
				if (m_rbTbFaturasComerciais.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbFaturasComerciais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbFaturasCotacoes
				if (m_rbTbFaturasCotacoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbFaturasCotacoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbFaturasProformas
				if (m_rbTbFaturasProformas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbFaturasProformas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbGuiasEntrada
				if (m_rbTbGuiasEntrada.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbGuiasEntrada(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbIdiomas
				if (m_rbTbIdiomas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbIdiomas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbIdiomasTextos
				if (m_rbTbIdiomasTextos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbIdiomasTextos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbImagens
				if (m_rbTbImagens.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbImagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbImportadores
				if (m_rbTbImportadores.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbImportadores(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbImportadoresBancos
				if (m_rbTbImportadoresBancos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbImportadoresBancos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbImportadoresConsignatarios
				if (m_rbTbImportadoresConsignatarios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbImportadoresConsignatarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region ImportadoresEndEntrega
				if (m_rbTbImportadoresEndEntrega.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbImportadoresEndEntrega(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbInstrucoesEmbarque
				if (m_rbTbInstrucoesEmbarque.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbInstrucoesEmbarque(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbLogMedicaoTempo
				if (m_rbTbLogMedicaoTempo.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbLogMedicaoTempo(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbMaquinas
				if (m_rbTbMaquinas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbMaquinas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbMensagens
				if (m_rbTbMensagens.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbMensagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbModulos
				if (m_rbTbModulos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbModulos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbMoedas
				if (m_rbTbMoedas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbMoedas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbNotasFiscais
				if (m_rbTbNotasFiscais.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbNotasFiscais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbPaises
					if (m_rbTbPaises.Checked)
						this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbPaises(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbPaisesIdiomas
				if (m_rbTbPaisesIdiomas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbPaisesIdiomas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbPes
				if (m_rbTbPes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbPes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbProcessosContainers
				if (m_rbTbProcessosContainers.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProcessosContainers(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbProdutos
				if (m_rbTbProdutos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosBordero
				if (m_rbTbProdutosBordero.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosBordero(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosCategoria
				if (m_rbTbProdutosCategoria.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosCategorias(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosCertificadoOrigem
				if (m_rbTbProdutosCertificadoOrigem.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosCertificadoOrigem(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosCertificadoOrigemFormA
				if (m_rbTbProdutosCertificadoOrigemFormA.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosCertificadoOrigemFormA(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosCertificadoOrigemFormARE
				if (m_rbTbProdutosCertificadoOrigemFormARE.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosCertificadoOrigemFormARE(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosFaturaComercial
				if (m_rbTbProdutosFaturaComercial.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaComercial(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosFaturaComercialPropriedades
					if (m_rbTbProdutosFaturaComercialPropriedades.Checked)
						this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaComercialPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosFaturaCotacao
				if (m_rbTbProdutosFaturaCotacao.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaCotacao(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosFaturaCotacaoPropriedades
				if (m_rbTbProdutosFaturaCotacaoPropriedades.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaCotacaoPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosProforma
				if (m_rbTbProdutosFaturaProforma.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaProforma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosFaturaProformaPropriedades
				if (m_rbTbProdutosFaturaProformaPropriedades.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosFaturaProformaPropriedades(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosIdiomas
				if (m_rbTbProdutosIdiomas.Checked)
				{
					if (m_ckMultiTable.Checked)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos = m_cls_dba_conexaoBD.GetTbProdutos(null,null,null,null,null);
						m_cls_dba_conexaoBD.AddTbProdutosIdiomas(typDatSetTbProdutos,m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
						this.m_dgOutput.DataSource = typDatSetTbProdutos;
					}else{
						this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosIdiomas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
					}
				}
				#endregion
				#region tbProdutosNaladi
				if (m_rbTbProdutosNaladi.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosNaladi(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosNcm
				if (m_rbTbProdutosNcm.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosNcm(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosParents
					if (m_rbTbProdutosParents.Checked)
						this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosParents(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosRomaneioEmbalagens
				if (m_rbTbProdutosRomaneioEmbalagens.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosRomaneioEmbalagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosRomaneioEmbalagensProdutos
				if (m_rbTbProdutosRomaneioEmbalagensProdutos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosRomaneioEmbalagensProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosRomaneioSimplificado
				if (m_rbTbProdutosRomaneioSimplificado.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosRomaneioSimplificado(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosRomaneioVolumes
				if (m_rbTbProdutosRomaneioVolumes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosRomaneioVolumes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbProdutosRomaneioVolumesProdutos
				if (m_rbTbProdutosRomaneioVolumesProdutos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbProdutosRomaneioVolumesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbPropriedadesProdutos
				if (m_rbTbPropriedadesProdutos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbPropriedadesProdutos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbRelatorioCamposBD
				if (m_rbTbRelatorioCamposBD.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioCamposBD(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioCirculos
				if (m_rbTbRelatorioCirculos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioCirculos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioEtiquetas
				if (m_rbTbRelatorioEtiquetas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioEtiquetas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioImagens
				if (m_rbTbRelatorioImagens.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioImagens(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioLinhas
				if (m_rbTbRelatorioLinhas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioLinhas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioRetangulos
				if (m_rbTbRelatorioRetangulos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioRetangulos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorios
				if (m_rbTbRelatorios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatoriosCamposBDPreRequisitos
				if (m_rbTbRelatoriosCamposBDPreRequisitos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatoriosCamposBDPreRequisitos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatoriosCamposBDRelatorios
				if (m_rbTbRelatoriosCamposBDRelatorios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatoriosCamposBDRelatorios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatoriosTodosCamposBD
				if (m_rbTbRelatoriosTodosCamposBD.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatoriosTodosCamposBD(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRelatorioTipo
				if (m_rbTbRelatorioTipo.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRelatorioTipo(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbREs
				if (m_rbTbREs.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbREs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbReservas
				if (m_rbTbReservas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbReservas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbREsPEs
				if (m_rbTbREsPEs.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbREsPEs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbRomaneios
				if (m_rbTbRomaneios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRomaneios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbRomaneiosSecundarios
				if (m_rbTbRomaneiosSecundarios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbRomaneiosSecundarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbSaques
				if (m_rbTbSaques.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbSaques(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbSDs
				if (m_rbTbSDs.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbSDs(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbStatisticDataManipulators
				if (m_rbtbStatisticDataManipuators.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbStatisticDataManipulators(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbStatisticReports
				if (m_rbtbStatisticReports.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbStatisticReports(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbSumarios
				if (m_rbTbSumarios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbSumarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbTerminais
				if (m_rbTbTerminais.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTerminais(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbTerminaisContatos
				if (m_rbTbTerminaisContatos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTerminaisContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbTransportadoras
				if (m_rbTbTransportadoras.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTransportadoras(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbTransportadorasContatos
				if (m_rbTbTransportadorasContatos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTransportadorasContatos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbTransportadorasMotoristas
				if (m_rbTbTransportadorasMotoristas.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTransportadorasMotoristas(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbTransportadorasVeiculos
				if (m_rbTbTransportadorasVeiculos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbTransportadorasVeiculos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbUnidadesEspaco
				if (m_rbTbUnidadesEspaco.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUnidadesEspaco(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbUnidadesEspacoIdioma
				if (m_rbTbUnidadesEspacoIdioma.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUnidadesEspacoIdioma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbUnidadesMassa
				if (m_rbTbUnidadesMassa.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUnidadesMassa(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbUnidadesMassaIdioma
				if (m_rbTbUnidadesMassaIdioma.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUnidadesMassaIdioma(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbUsuarios
				if (m_rbTbUsuarios.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUsuarios(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbUsuariosConcessoes
				if (m_rbTbUsuariosConcessoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUsuariosConcessoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion 
				#region tbUsuariosConcessoesPermissoes
				if (m_rbTbUsuariosConcessoesPermissoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUsuariosConcessoesPermissoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion 
				#region tbUsuariosPermissoes
				if (m_rbTbUsuariosPermissoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUsuariosPermissoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion 
				#region tbUsuariosPermissoesConcessoes
				if (m_rbTbUsuariosPermissoesConcessoes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbUsuariosPermissoesConcessoes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion 

				#region tbVersao
				if (m_rbTbVersao.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbVersao(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbVersaoModulo
				if (m_rbTbVersaoModulo.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbVersaoModulo(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbVolumes
				if (m_rbTbVolumes.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbVolumes(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				#region tbWebServiceServicos
				if (m_rbTbWebServiceServicos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbWebServiceServicos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbWebServiceServidores
				if (m_rbTbWebServiceServidores.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbWebServiceServidores(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion
				#region tbWebServiceServidoresServicos
				if (m_rbTbWebServiceServidoresServicos.Checked)
					this.m_dgOutput.DataSource = m_cls_dba_conexaoBD.GetTbWebServiceServidoresServicos(m_arlCondicaoCampo,m_arlCondicaoComparador,m_arlCondicaoValor,null,null);
				#endregion

				this.Text = System.DateTime.Now.Subtract(dtCronometro).Milliseconds.ToString() + " Milisegundos";
				m_ckPersistData.Checked = m_cls_dba_conexaoBD.DataPersist;

				if (m_ckDontPutDataInDataGrid.Checked)
					m_dgOutput.DataSource = dtsetTemp;
			}
		#endregion 
		#region Set
			private void m_btSet_Click(object sender, System.EventArgs e)
			{
				if ((m_dgOutput.DataSource != null) && (m_ckMultiTable.Checked))
				{
					m_cls_dba_conexaoBD.SetDataSetMultiTable((System.Data.DataSet)m_dgOutput.DataSource);
					m_dgOutput.DataSource = null;
				}

				if (m_dgOutput.DataSource != null)
				{
					System.DateTime dtCronometro = System.DateTime.Now;

					#region tbAgentesCargas
					if (m_rbTbAgentesCargas.Checked)
						m_cls_dba_conexaoBD.SetTbAgentesCargas((mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas)this.m_dgOutput.DataSource);
					#endregion
					#region tbAgentesCargasContatos
					if (m_rbTbAgentesCargasContatos.Checked)
						m_cls_dba_conexaoBD.SetTbAgentesCargasContatos((mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos)this.m_dgOutput.DataSource);
					#endregion
					#region tbArmadores
					if (m_rbTbArmadores.Checked)
						m_cls_dba_conexaoBD.SetTbArmadores((mdlDataBaseAccess.Tabelas.XsdTbArmadores)this.m_dgOutput.DataSource);
					#endregion
					#region tbArmadoresNavios
					if (m_rbTbArmadoresNavios.Checked)
						m_cls_dba_conexaoBD.SetTbArmadoresNavios((mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios)this.m_dgOutput.DataSource);
					#endregion

					#region tbAssinaturas
					if (m_rbTbAssinaturas.Checked)
						m_cls_dba_conexaoBD.SetTbAssinaturas((mdlDataBaseAccess.Tabelas.XsdTbAssinaturas)this.m_dgOutput.DataSource);
					#endregion

					#region tbBorderos
					if (m_rbTbBorderos.Checked)
						m_cls_dba_conexaoBD.SetTbBorderos((mdlDataBaseAccess.Tabelas.XsdTbBorderos)this.m_dgOutput.DataSource);
					#endregion
					#region tbBorderosSecundarios
					if (m_rbTbBorderosSecundarios.Checked)
						m_cls_dba_conexaoBD.SetTbBorderosSecundarios((mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios)this.m_dgOutput.DataSource);
					#endregion

					#region tbCartasCredito
					if (m_rbTbCartasCredito.Checked)
						m_cls_dba_conexaoBD.SetTbCartasCredito((mdlDataBaseAccess.Tabelas.XsdTbCartasCredito)this.m_dgOutput.DataSource);
					#endregion

					#region tbCertificadosOrigem
					if (m_rbTbCertificadosOrigem.Checked)
						m_cls_dba_conexaoBD.SetTbCertificadosOrigem((mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem)this.m_dgOutput.DataSource);
					#endregion
					#region tbCertificadosOrigemNormas
					if (m_rbTbCertificadosOrigemNormas.Checked)
						m_cls_dba_conexaoBD.SetTbCertificadosOrigemNormas((mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas)this.m_dgOutput.DataSource);
					#endregion

					#region tbConfiguracoes
					if (m_rbTbConfiguracoes.Checked)
						m_cls_dba_conexaoBD.SetTbConfiguracoes((mdlDataBaseAccess.Tabelas.XsdTbConfiguracoes)this.m_dgOutput.DataSource);
					#endregion

					#region tbContratosCambio
					if (m_rbTbContratosCambio.Checked)
						m_cls_dba_conexaoBD.SetTbContratosCambio((mdlDataBaseAccess.Tabelas.XsdTbContratosCambio)this.m_dgOutput.DataSource);
					#endregion

					#region tbDespachantes
					if (m_rbTbDespachantes.Checked)
						m_cls_dba_conexaoBD.SetTbDespachantes((mdlDataBaseAccess.Tabelas.XsdTbDespachantes)this.m_dgOutput.DataSource);
					#endregion
					#region tbDespachantesContatos
					if (m_rbTbDespachantesContatos.Checked)
						m_cls_dba_conexaoBD.SetTbDespachantesContatos((mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos)this.m_dgOutput.DataSource);
					#endregion

					#region tbDSEs
					if (m_rbTbDSEs.Checked)
						m_cls_dba_conexaoBD.SetTbDSEs((mdlDataBaseAccess.Tabelas.XsdTbDSEs)this.m_dgOutput.DataSource);
					#endregion
					#region tbDSEs
					if (m_rbTbDSEsPEs.Checked)
						m_cls_dba_conexaoBD.SetTbDSEsPEs((mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs)this.m_dgOutput.DataSource);
					#endregion

					#region tbEstadosBrasileiros
					if (m_rbTbEstadosBrasileiros.Checked)
						m_cls_dba_conexaoBD.SetTbEstadosBrasileiros((mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros)this.m_dgOutput.DataSource);
					#endregion

					#region tbErros
					if (m_rbTbErros.Checked)
						m_cls_dba_conexaoBD.SetTbErros((mdlDataBaseAccess.Tabelas.XsdTbErros)this.m_dgOutput.DataSource);
					#endregion

					#region tbExportadores
					if (m_rbTbExportadores.Checked)
						m_cls_dba_conexaoBD.SetTbExportadores((mdlDataBaseAccess.Tabelas.XsdTbExportadores)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresAgentesVendas
					if (m_rbTbExportadoresAgentesVendas.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresAgentesVendas((mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresAgentesVendasBancos
					if (m_rbTbExportadoresAgentesVendasBancos.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresAgentesVendasBancos((mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresBancos
					if (m_rbTbExportadoresBancos.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresBancos((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresBancosAgencias
					if (m_rbTbExportadoresBancosAgencias.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresBancosAgencias((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresBancosAgenciasContas
					if (m_rbTbExportadoresBancosAgenciasContas.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresBancosAgenciasContas((mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas)this.m_dgOutput.DataSource);
					#endregion
					#region tbExportadoresVolumes
					if (m_rbTbExportadoresVolumes.Checked)
						m_cls_dba_conexaoBD.SetTbExportadoresVolumes((mdlDataBaseAccess.Tabelas.XsdTbExportadoresVolumes)this.m_dgOutput.DataSource);
					#endregion

					#region tbFaturasComerciais
					if (m_rbTbFaturasComerciais.Checked)
						m_cls_dba_conexaoBD.SetTbFaturasComerciais((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais)this.m_dgOutput.DataSource);
					#endregion
					#region tbFaturasCotacoes
					if (m_rbTbFaturasCotacoes.Checked)
						m_cls_dba_conexaoBD.SetTbFaturasCotacoes((mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes)this.m_dgOutput.DataSource);
					#endregion
					#region tbFaturasProforma
					if (m_rbTbFaturasProformas.Checked)
						m_cls_dba_conexaoBD.SetTbFaturasProformas((mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas)this.m_dgOutput.DataSource);
					#endregion

					#region tbGuiasEntrada
					if (m_rbTbGuiasEntrada.Checked)
						m_cls_dba_conexaoBD.SetTbGuiasEntrada((mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada)this.m_dgOutput.DataSource);
					#endregion

					#region tbIdiomas
					if (m_rbTbIdiomas.Checked)
						m_cls_dba_conexaoBD.SetTbIdiomas((mdlDataBaseAccess.Tabelas.XsdTbIdiomas)this.m_dgOutput.DataSource);
					#endregion
					#region tbIdiomasTextos
					if (m_rbTbIdiomasTextos.Checked)
						m_cls_dba_conexaoBD.SetTbIdiomasTextos((mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos)this.m_dgOutput.DataSource);
					#endregion

					#region tbImagens
					if (m_rbTbImagens.Checked)
						m_cls_dba_conexaoBD.SetTbImagens((mdlDataBaseAccess.Tabelas.XsdTbImagens)this.m_dgOutput.DataSource);
					#endregion

					#region tbImportadores
					if (m_rbTbImportadores.Checked)
						m_cls_dba_conexaoBD.SetTbImportadores((mdlDataBaseAccess.Tabelas.XsdTbImportadores)this.m_dgOutput.DataSource);
					#endregion
					#region tbImportadoresBancos
					if (m_rbTbImportadoresBancos.Checked)
						m_cls_dba_conexaoBD.SetTbImportadoresBancos((mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos)this.m_dgOutput.DataSource);
					#endregion
					#region tbImportadoresConsignatarios
					if (m_rbTbImportadoresConsignatarios.Checked)
						m_cls_dba_conexaoBD.SetTbImportadoresConsignatarios((mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios)this.m_dgOutput.DataSource);
					#endregion
					#region tbImportadoresEndEntrega
					if (m_rbTbImportadoresEndEntrega.Checked)
						m_cls_dba_conexaoBD.SetTbImportadoresEndEntrega((mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega)this.m_dgOutput.DataSource);
					#endregion

					#region tbInstrucoesEmbarque
					if (m_rbTbInstrucoesEmbarque.Checked)
						m_cls_dba_conexaoBD.SetTbInstrucoesEmbarque((mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque)this.m_dgOutput.DataSource);
					#endregion

					#region tbLogMedicaoTempo
					if (m_rbTbLogMedicaoTempo.Checked)
						m_cls_dba_conexaoBD.SetTbLogMedicaoTempo((mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo)this.m_dgOutput.DataSource);
					#endregion

					#region tbMaquinas
					if (m_rbTbMaquinas.Checked)
						m_cls_dba_conexaoBD.SetTbMaquinas((mdlDataBaseAccess.Tabelas.XsdTbMaquinas)this.m_dgOutput.DataSource);
					#endregion

					#region tbMensagens
					if (m_rbTbMensagens.Checked)
						m_cls_dba_conexaoBD.SetTbMensagens((mdlDataBaseAccess.Tabelas.XsdTbMensagens)this.m_dgOutput.DataSource);
					#endregion

					#region tbModulos
					if (m_rbTbModulos.Checked)
						m_cls_dba_conexaoBD.SetTbModulos((mdlDataBaseAccess.Tabelas.XsdTbModulos)this.m_dgOutput.DataSource);
					#endregion
					#region tbMoedas
					if (m_rbTbMoedas.Checked)
						m_cls_dba_conexaoBD.SetTbMoedas((mdlDataBaseAccess.Tabelas.XsdTbMoedas)this.m_dgOutput.DataSource);
					#endregion

					#region tbNotasFiscais
					if (m_rbTbNotasFiscais.Checked)
						m_cls_dba_conexaoBD.SetTbNotasFiscais((mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais)this.m_dgOutput.DataSource);
					#endregion

					#region tbPaises
					if (m_rbTbPaises.Checked)
						m_cls_dba_conexaoBD.SetTbPaises((mdlDataBaseAccess.Tabelas.XsdTbPaises)this.m_dgOutput.DataSource);
					#endregion
					#region tbPaisesIdiomas
					if (m_rbTbPaisesIdiomas.Checked)
						m_cls_dba_conexaoBD.SetTbPaisesIdiomas((mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas)this.m_dgOutput.DataSource);
					#endregion

					#region tbPes
					if (m_rbTbPes.Checked)
						m_cls_dba_conexaoBD.SetTbPes((mdlDataBaseAccess.Tabelas.XsdTbPes)this.m_dgOutput.DataSource);
					#endregion

					#region tbProcessosContainers
					if (m_rbTbProcessosContainers.Checked)
						m_cls_dba_conexaoBD.SetTbProcessosContainers((mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers)this.m_dgOutput.DataSource);
					#endregion

					#region tbProdutos
					if (m_rbTbProdutos.Checked)
						m_cls_dba_conexaoBD.SetTbProdutos((mdlDataBaseAccess.Tabelas.XsdTbProdutos)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosBordero
					if (m_rbTbProdutosBordero.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosBordero((mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosCategorias
					if (m_rbTbProdutosCategoria.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosCategorias((mdlDataBaseAccess.Tabelas.XsdTbProdutosCategorias)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosCertificadoOrigem
						if (m_rbTbProdutosCertificadoOrigem.Checked)
							m_cls_dba_conexaoBD.SetTbProdutosCertificadoOrigem((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosCertificadoOrigemFormA
					if (m_rbTbProdutosCertificadoOrigemFormA.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosCertificadoOrigemFormA((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosCertificadoOrigemFormARE
					if (m_rbTbProdutosCertificadoOrigemFormARE.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosCertificadoOrigemFormARE((mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaComercial
					if (m_rbTbProdutosFaturaComercial.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaComercial((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaComercialPropriedades
					if (m_rbTbProdutosFaturaComercialPropriedades.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaComercialPropriedades((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaCotacao
					if (m_rbTbProdutosFaturaCotacao.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaCotacao((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaCotacaoPropriedades
					if (m_rbTbProdutosFaturaCotacaoPropriedades.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaCotacaoPropriedades((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaProforma
					if (m_rbTbProdutosFaturaProforma.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaProforma((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosFaturaProformaPropriedades
					if (m_rbTbProdutosFaturaProformaPropriedades.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosFaturaProformaPropriedades((mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosIdiomas
					if (m_rbTbProdutosIdiomas.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosIdiomas((mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosNaladi
					if (m_rbTbProdutosNaladi.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosNaladi((mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosNcm
					if (m_rbTbProdutosNcm.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosNcm((mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosParents
						if (m_rbTbProdutosParents.Checked)
							m_cls_dba_conexaoBD.SetTbProdutosParents((mdlDataBaseAccess.Tabelas.XsdTbProdutosParents)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosRomaneioEmbalagens
					if (m_rbTbProdutosRomaneioEmbalagens.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosRomaneioEmbalagens((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosRomaneioEmbalagensProdutos
					if (m_rbTbProdutosRomaneioEmbalagensProdutos.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosRomaneioEmbalagensProdutos((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos)this.m_dgOutput.DataSource);
					#endregion 
					#region tbProdutosRomaneioSimplificado
					if (m_rbTbProdutosRomaneioSimplificado.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosRomaneioSimplificado((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado)this.m_dgOutput.DataSource);
					#endregion
					#region tbProdutosRomaneioVolumes
					if (m_rbTbProdutosRomaneioVolumes.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosRomaneioVolumes((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes)this.m_dgOutput.DataSource);
					#endregion 
					#region  tbProdutosRomaneioVolumesProdutos
					if (m_rbTbProdutosRomaneioVolumesProdutos.Checked)
						m_cls_dba_conexaoBD.SetTbProdutosRomaneioVolumesProdutos((mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos)this.m_dgOutput.DataSource);
					#endregion
					#region tbPropriedadesProdutos
					if (m_rbTbPropriedadesProdutos.Checked)
						m_cls_dba_conexaoBD.SetTbPropriedadesProdutos((mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos)this.m_dgOutput.DataSource);
					#endregion

					#region tbRelatorioCamposBD
					if (m_rbTbRelatorioCamposBD.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioCamposBD((mdlDataBaseAccess.Tabelas.XsdTbRelatorioCamposBD)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioCirculos
					if (m_rbTbRelatorioCirculos.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioCirculos((mdlDataBaseAccess.Tabelas.XsdTbRelatorioCirculos)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioEtiquetas
					if (m_rbTbRelatorioEtiquetas.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioEtiquetas((mdlDataBaseAccess.Tabelas.XsdTbRelatorioEtiquetas)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioImagens
					if (m_rbTbRelatorioImagens.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioImagens((mdlDataBaseAccess.Tabelas.XsdTbRelatorioImagens)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioLinhas
					if (m_rbTbRelatorioLinhas.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioLinhas((mdlDataBaseAccess.Tabelas.XsdTbRelatorioLinhas)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioRetangulos
					if (m_rbTbRelatorioRetangulos.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioRetangulos((mdlDataBaseAccess.Tabelas.XsdTbRelatorioRetangulos)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorios
					if (m_rbTbRelatorios.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorios((mdlDataBaseAccess.Tabelas.XsdTbRelatorios)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatoriosCamposBDPreRequisitos
					if (m_rbTbRelatoriosCamposBDPreRequisitos.Checked)
						m_cls_dba_conexaoBD.SetTbRelatoriosCamposBDPreRequisitos((mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDPreRequisitos)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatoriosCamposBDRelatorios
					if (m_rbTbRelatoriosCamposBDRelatorios.Checked)
						m_cls_dba_conexaoBD.SetTbRelatoriosCamposBDRelatorios((mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatoriosTodosCamposBD
					if (m_rbTbRelatoriosTodosCamposBD.Checked)
						m_cls_dba_conexaoBD.SetTbRelatoriosTodosCamposBD((mdlDataBaseAccess.Tabelas.XsdTbRelatoriosTodosCamposBD)this.m_dgOutput.DataSource);
					#endregion
					#region tbRelatorioTipo
					if (m_rbTbRelatorioTipo.Checked)
						m_cls_dba_conexaoBD.SetTbRelatorioTipo((mdlDataBaseAccess.Tabelas.XsdTbRelatorioTipo)this.m_dgOutput.DataSource);
					#endregion

					#region tbREs
					if (m_rbTbREs.Checked)
						m_cls_dba_conexaoBD.SetTbREs((mdlDataBaseAccess.Tabelas.XsdTbREs)this.m_dgOutput.DataSource);
					#endregion

					#region tbReservas
					if (m_rbTbReservas.Checked)
						m_cls_dba_conexaoBD.SetTbReservas((mdlDataBaseAccess.Tabelas.XsdTbReservas)this.m_dgOutput.DataSource);
					#endregion

					#region tbREsPEs
					if (m_rbTbREsPEs.Checked)
						m_cls_dba_conexaoBD.SetTbREsPEs((mdlDataBaseAccess.Tabelas.XsdTbREsPEs)this.m_dgOutput.DataSource);
					#endregion

					#region tbRomaneios
					if (m_rbTbRomaneios.Checked)
						m_cls_dba_conexaoBD.SetTbRomaneios((mdlDataBaseAccess.Tabelas.XsdTbRomaneios)this.m_dgOutput.DataSource);
					#endregion
					#region tbRomaneiosSecundarios
					if (m_rbTbRomaneiosSecundarios.Checked)
						m_cls_dba_conexaoBD.SetTbRomaneiosSecundarios((mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios)this.m_dgOutput.DataSource);
					#endregion

					#region tbSaques
					if (m_rbTbSaques.Checked)
						m_cls_dba_conexaoBD.SetTbSaques((mdlDataBaseAccess.Tabelas.XsdTbSaques)this.m_dgOutput.DataSource);
					#endregion

					#region tbSDs
					if (m_rbTbSDs.Checked)
						m_cls_dba_conexaoBD.SetTbSDs((mdlDataBaseAccess.Tabelas.XsdTbSDs)this.m_dgOutput.DataSource);
					#endregion

					#region tbSumarios
					if (m_rbTbSumarios.Checked)
						m_cls_dba_conexaoBD.SetTbSumarios((mdlDataBaseAccess.Tabelas.XsdTbSumarios)this.m_dgOutput.DataSource);
					#endregion

					#region tbTerminais
					if (m_rbTbTerminais.Checked)
						m_cls_dba_conexaoBD.SetTbTerminais((mdlDataBaseAccess.Tabelas.XsdTbTerminais)this.m_dgOutput.DataSource);
					#endregion
					#region tbTerminaisContatos
					if (m_rbTbTerminaisContatos.Checked)
						m_cls_dba_conexaoBD.SetTbTerminaisContatos((mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos)this.m_dgOutput.DataSource);
					#endregion

					#region tbTransportadoras
					if (m_rbTbTransportadoras.Checked)
						m_cls_dba_conexaoBD.SetTbTransportadoras((mdlDataBaseAccess.Tabelas.XsdTbTransportadoras)this.m_dgOutput.DataSource);
					#endregion
					#region tbTransportadorasContatos
					if (m_rbTbTransportadorasContatos.Checked)
						m_cls_dba_conexaoBD.SetTbTransportadorasContatos((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos)this.m_dgOutput.DataSource);
					#endregion
					#region tbTransportadorasMotoristas
					if (m_rbTbTransportadorasMotoristas.Checked)
						m_cls_dba_conexaoBD.SetTbTransportadorasMotoristas((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas)this.m_dgOutput.DataSource);
					#endregion
					#region tbTransportadorasVeiculos
					if (m_rbTbTransportadorasVeiculos.Checked)
						m_cls_dba_conexaoBD.SetTbTransportadorasVeiculos((mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos)this.m_dgOutput.DataSource);
					#endregion

					#region tbUnidadesEspaco
					#endregion
					#region tbUnidadesEspacoIdioma
					#endregion
					#region tbUnidadesMassa
					#endregion
					#region tbUnidadesMassaIdioma
					#endregion

					#region tbUsuarios 
					if (m_rbTbUsuarios.Checked)
						m_cls_dba_conexaoBD.SetTbUsuarios((mdlDataBaseAccess.Tabelas.XsdTbUsuarios)this.m_dgOutput.DataSource);
					#endregion
					#region tbUsuariosConcessoes
					if (m_rbTbUsuariosConcessoes.Checked)
						m_cls_dba_conexaoBD.SetTbUsuariosConcessoes((mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes)this.m_dgOutput.DataSource);
					#endregion 
					#region tbUsuariosConcessoesPermissoes
					if (m_rbTbUsuariosConcessoesPermissoes.Checked)
						m_cls_dba_conexaoBD.SetTbUsuariosConcessoesPermissoes((mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes)this.m_dgOutput.DataSource);
					#endregion 
					#region tbUsuariosPermissoes
					if (m_rbTbUsuariosPermissoes.Checked)
						m_cls_dba_conexaoBD.SetTbUsuariosPermissoes((mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes)this.m_dgOutput.DataSource);
					#endregion 
					#region tbUsuariosPermissoesConcessoes
					if (m_rbTbUsuariosPermissoesConcessoes.Checked)
						m_cls_dba_conexaoBD.SetTbUsuariosPermissoesConcessoes((mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes)this.m_dgOutput.DataSource);
					#endregion 

					#region tbVersao
					if (m_rbTbVersao.Checked)
						m_cls_dba_conexaoBD.SetTbVersao((mdlDataBaseAccess.Tabelas.XsdTbVersao)this.m_dgOutput.DataSource);
					#endregion
					#region tbVersaoModulo
					if (m_rbTbVersaoModulo.Checked)
						m_cls_dba_conexaoBD.SetTbVersaoModulo((mdlDataBaseAccess.Tabelas.XsdTbVersaoModulo)this.m_dgOutput.DataSource);
					#endregion

					#region tbVolumes
					if (m_rbTbVolumes.Checked)
						m_cls_dba_conexaoBD.SetTbVolumes((mdlDataBaseAccess.Tabelas.XsdTbVolumes)this.m_dgOutput.DataSource);
					#endregion

					#region tbWebServiceServicos
					if (m_rbTbWebServiceServicos.Checked)
						m_cls_dba_conexaoBD.SetTbWebServiceServicos((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServicos)this.m_dgOutput.DataSource);
					#endregion
					#region tbWebServiceServidores
					if (m_rbTbWebServiceServidores.Checked)
						m_cls_dba_conexaoBD.SetTbWebServiceServidores((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidores)this.m_dgOutput.DataSource);
					#endregion
					#region tbWebServiceServidoresServicos
					if (m_rbTbWebServiceServidoresServicos.Checked)
						m_cls_dba_conexaoBD.SetTbWebServiceServidoresServicos((mdlDataBaseAccess.Tabelas.XsdTbWebServiceServidoresServicos)this.m_dgOutput.DataSource);
					#endregion

					this.Text = System.DateTime.Now.Subtract(dtCronometro).Milliseconds.ToString() + " Milisegundos";
					m_dgOutput.DataSource = null;

				}
				m_ckPersistData.Checked = m_cls_dba_conexaoBD.DataPersist;
			}
		#endregion

		#region Temporario
			private void vPaises()
			{
				string strFile = "C:\\XmlTbPaises.xml";
				if (System.IO.File.Exists(strFile))
					System.IO.File.Delete(strFile);
				char[] charSep = new char[1];
				charSep[0] = ' ';
				mdlDataBaseAccess.Tabelas.XsdTbPaises typDdatSetIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbPaises)m_dgOutput.DataSource;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwPais in typDdatSetIdiomas.tbPaises.Rows)
				{
					string strPais = dtrwPais.nmPais;
					string[] strSplit = strPais.Split(charSep,15);
					string strPart;
					for(int i = 0; i < strSplit.Length;i++)
					{
						strPart = strSplit[i].ToLower();
						if (strPart.Length > 3)
							strPart = strPart[0].ToString().ToUpper() + strPart.Substring(1);   
						strSplit[i] = strPart;
					}
					strPais = System.String.Join(" ",strSplit);
					dtrwPais.nmPais = strPais;
				}
				m_dgOutput.DataSource = typDdatSetIdiomas;
				typDdatSetIdiomas.WriteXml(strFile);
			}
		#endregion

		private void m_btDeleteAllDataBase_Click(object sender, System.EventArgs e)
		{
			if (System.Windows.Forms.MessageBox.Show("Deseja mesmo apagar toda base ?","Siscobras",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				CreateDataBaseAccess();
				m_txtConfiguracaoRetorno.Text = m_cls_dba_conexaoBD.DeleteAllDataBase().ToString();
			}
		}
	}
}
