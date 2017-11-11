using System;
using System.Collections;
//using System.Windows.Forms;

namespace mdlIncoterm
{
	/// <summary>
	/// Summary description for frmFIncoterm.
	/// </summary>
	internal class frmFIncoterm : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
		private bool m_bMostrarBaloes = true;

		private bool m_bOnLoad = true;

		private int m_nIdInfoIncoterm = -1;

		private bool m_bAtivado = false;
		private bool m_bDescontoAlterado = false;

		private System.Windows.Forms.Button m_btLocais;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button btTrocarCor;
		private mdlComponentesGraficos.TextBox m_tbLocais;
		private System.Windows.Forms.Button m_btIDDP;
		private System.Windows.Forms.Button m_btIDDU;
		private System.Windows.Forms.Button m_btIDEQ;
		private System.Windows.Forms.Button m_btIDES;
		private System.Windows.Forms.Button m_btIDAF;
		private System.Windows.Forms.Button m_btICIP;
		private System.Windows.Forms.Button m_btICPT;
		private System.Windows.Forms.Button m_btICIF;
		private System.Windows.Forms.Button m_btICFR;
		private System.Windows.Forms.Button m_btIFOB;
		private System.Windows.Forms.Button m_btIFCA;
		private System.Windows.Forms.Button m_btIFAS;
		private System.Windows.Forms.Button m_btIEXW;
		private System.Windows.Forms.RadioButton m_btCIP;
		private System.Windows.Forms.RadioButton m_btEXW;
		private System.Windows.Forms.RadioButton m_btFOB;
		private System.Windows.Forms.RadioButton m_btFAS;
		private System.Windows.Forms.RadioButton m_btDDP;
		private System.Windows.Forms.RadioButton m_btDDU;
		private System.Windows.Forms.RadioButton m_btDEQ;
		private System.Windows.Forms.RadioButton m_btDES;
		private System.Windows.Forms.RadioButton m_btDAF;
		private System.Windows.Forms.RadioButton m_btFCA;
		private System.Windows.Forms.RadioButton m_btCPT;
		private System.Windows.Forms.RadioButton m_btCIF;
		private System.Windows.Forms.RadioButton m_btCFR;
		private System.Windows.Forms.RadioButton m_rbCorreio;
		private System.Windows.Forms.RadioButton m_rbFerroviario;
		private System.Windows.Forms.RadioButton m_rbRodoviario;
		private System.Windows.Forms.RadioButton m_rbAereo;
		private System.Windows.Forms.RadioButton m_rbMaritimo;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbLocais;
		private System.Windows.Forms.Label m_lLocais;
		private System.Windows.Forms.GroupBox m_gbInformacoes;
		private System.Windows.Forms.GroupBox m_gbIncoterms;
		private System.Windows.Forms.GroupBox m_gbModalidades;
		private System.Windows.Forms.Label m_lSubTotal;
		private System.Windows.Forms.ToolTip m_ttIncoterm;
		private System.Windows.Forms.Label m_lValorTotalProdutos;
		private mdlComponentesGraficos.TextBox m_tbDesconto;
		private System.Windows.Forms.Label m_lDesconto;
		private System.Windows.Forms.Label m_lOu;
		private mdlComponentesGraficos.TextBox m_tbDescontoPorcentagem;
		private System.Windows.Forms.CheckBox m_ckbxRatearDesconto;
		private System.Windows.Forms.Label m_lValorTotalCDesconto;
		private System.Windows.Forms.Label m_lTotalCDesconto;
		private System.Windows.Forms.Label m_lbSimboloPorcentagem;
		private System.Windows.Forms.Label m_lDescontoMoeda;
		private System.Windows.Forms.GroupBox m_gbBarra;
		private System.Windows.Forms.CheckBox m_ckbxRatearDespesas;
		private mdlComponentesGraficos.TextBox m_tbOutros;
		private mdlComponentesGraficos.TextBox m_tbSeguro;
		private mdlComponentesGraficos.TextBox m_tbFreteInternacional;
		private mdlComponentesGraficos.TextBox m_tbFreteInterno;
		private System.Windows.Forms.Label m_lValorTotal;
		private System.Windows.Forms.Label m_lTotalFinal;
		private mdlComponentesGraficos.TextBox m_tbTextoOutros;
		private System.Windows.Forms.Label m_lSeguro;
		private System.Windows.Forms.Label m_lFreteInternacional;
		private System.Windows.Forms.Label m_lFreteInterno;
		private System.Windows.Forms.GroupBox m_gbDespesas;
		private System.Windows.Forms.Button m_btTrocarCorDesconto;
		private System.Windows.Forms.Button m_btTrocarCorDespesa;
		private System.ComponentModel.IContainer components;
		#endregion		

		#region Construtores & Destrutores
		public frmFIncoterm(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFIncoterm(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bMostrarBaloes)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bMostrarBaloes = bMostrarBaloes;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDIncoterms();
		public delegate void delCallCarregaDadosInterface(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref System.Windows.Forms.Label lDesconto, ref System.Windows.Forms.Label lDescontoMoeda, ref mdlComponentesGraficos.TextBox tbDesconto, ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem, ref System.Windows.Forms.CheckBox ckbxRatearDesconto, ref System.Windows.Forms.CheckBox ckbxRatearDespesas, ref System.Windows.Forms.Label lTotal, ref System.Windows.Forms.Label lTotalProdutos, ref System.Windows.Forms.Label lTotalProdutosCDesconto, ref mdlComponentesGraficos.TextBox tbLocais, ref System.Windows.Forms.Button btLocais, bool bOnLoad);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref System.Windows.Forms.CheckBox ckbxRatearDesconto, ref System.Windows.Forms.CheckBox ckbxRatearDespesas, ref System.Windows.Forms.Label lTotal, ref System.Windows.Forms.Label lTotalProdutos, ref mdlComponentesGraficos.TextBox tbIncoterm);
		public delegate void delCallSalvaDadosInterfaceTextBoxes(ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref mdlComponentesGraficos.TextBox tbIncoterm);
		public delegate void delCallSalvaDadosInterfaceLocalIncoterm(ref mdlComponentesGraficos.TextBox tbIncoterm);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Incoterms
		public delegate void delCallSelecionaIncoterm(ref System.Windows.Forms.RadioButton btCIP, ref System.Windows.Forms.RadioButton btEXW, ref System.Windows.Forms.RadioButton btFOB, ref System.Windows.Forms.RadioButton btFAS, ref System.Windows.Forms.RadioButton btDDP, ref System.Windows.Forms.RadioButton btDDU, ref System.Windows.Forms.RadioButton btDEQ, ref System.Windows.Forms.RadioButton btDES, ref System.Windows.Forms.RadioButton btDAF, ref System.Windows.Forms.RadioButton btFCA, ref System.Windows.Forms.RadioButton btCPT, ref System.Windows.Forms.RadioButton btCIF, ref System.Windows.Forms.RadioButton btCFR, ref System.Windows.Forms.Label lFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref System.Windows.Forms.Label lFreteInternacional, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref System.Windows.Forms.Label lSeguro, ref mdlComponentesGraficos.TextBox tbSeguro/*, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros*/);
		public delegate void delCallHabilitaIncoterms(ref System.Windows.Forms.RadioButton btCIP, ref System.Windows.Forms.RadioButton btEXW, ref System.Windows.Forms.RadioButton btFOB, ref System.Windows.Forms.RadioButton btFAS, ref System.Windows.Forms.RadioButton btDDP, ref System.Windows.Forms.RadioButton btDDU, ref System.Windows.Forms.RadioButton btDEQ, ref System.Windows.Forms.RadioButton btDES, ref System.Windows.Forms.RadioButton btDAF, ref System.Windows.Forms.RadioButton btFCA, ref System.Windows.Forms.RadioButton btCPT, ref System.Windows.Forms.RadioButton btCIF, ref System.Windows.Forms.RadioButton btCFR);
		public delegate void delCallSelecionaMeioTransporte(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO);
		public delegate void delCallIncotermInfo(int nIdIncoterm);
		// Locais
		public delegate void delCallEditaLocais();
		// Desconto
		public delegate void delCallAlteraDescontoValor(ref mdlComponentesGraficos.TextBox tbDesconto, ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem);
		public delegate void delCallAlteraDescontoPorcentagem(ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem, ref mdlComponentesGraficos.TextBox tbDesconto);
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDIncoterms eCallCarregaDadosBDIncoterms;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosInterfaceTextBoxes eCallSalvaDadosInterfaceTextBoxes;
		public event delCallSalvaDadosInterfaceLocalIncoterm eCallSalvaDadosInterfaceLocalIncoterm;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Incoterms
		public event delCallSelecionaIncoterm eCallSelecionaIncoterm;
		public event delCallHabilitaIncoterms eCallHabilitaIncoterms;
		public event delCallSelecionaMeioTransporte eCallSelecionaMeioTransporte;
		public event delCallIncotermInfo eCallIncotermInfo;
		// Locais
		public event delCallEditaLocais eCallEditaLocais;
		// Descontos
		public event delCallAlteraDescontoValor eCallAlteraDescontoValor;
		public event delCallAlteraDescontoPorcentagem eCallAlteraDescontoPorcentagem;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDIncoterms()
		{
			if (eCallCarregaDadosBDIncoterms != null)
				eCallCarregaDadosBDIncoterms();
		} 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_rbAereo, ref m_rbMaritimo, ref m_rbRodoviario, ref m_rbFerroviario, ref m_rbCorreio, ref m_tbFreteInterno, ref m_tbFreteInternacional, ref m_tbSeguro, ref m_tbOutros, ref m_tbTextoOutros, ref m_lDesconto, ref m_lDescontoMoeda, ref m_tbDesconto, ref m_tbDescontoPorcentagem, ref m_ckbxRatearDesconto, ref m_ckbxRatearDespesas, ref m_lValorTotal, ref m_lValorTotalProdutos, ref m_lValorTotalCDesconto, ref m_tbLocais, ref m_btLocais, m_bOnLoad);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_rbAereo, ref m_rbMaritimo, ref m_rbRodoviario, ref m_rbFerroviario, ref m_rbCorreio, ref m_tbFreteInterno, ref m_tbFreteInternacional, ref m_tbSeguro, ref m_tbOutros, ref m_tbTextoOutros, ref m_ckbxRatearDesconto, ref m_ckbxRatearDespesas, ref m_lValorTotal, ref m_lValorTotalProdutos, ref m_tbLocais);
		} 

		protected virtual void OnCallSalvaDadosInterfaceTextBoxes()
		{
			if (eCallSalvaDadosInterfaceTextBoxes != null)
				eCallSalvaDadosInterfaceTextBoxes(ref m_tbFreteInterno, ref m_tbFreteInternacional, ref m_tbSeguro, ref m_tbOutros, ref m_tbTextoOutros, ref m_tbLocais);
		}
		protected virtual void OnCallSalvaDadosInterfaceLocalIncoterm()
		{
			if (eCallSalvaDadosInterfaceLocalIncoterm != null)
				eCallSalvaDadosInterfaceLocalIncoterm(ref m_tbLocais);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallSelecionaIncoterm()
		{
			if (eCallSelecionaIncoterm != null)
				eCallSelecionaIncoterm(ref m_btCIP, ref m_btEXW, ref m_btFOB, ref m_btFAS, ref m_btDDP, ref m_btDDU, ref m_btDEQ, ref m_btDES, ref m_btDAF, ref m_btFCA, ref m_btCPT, ref m_btCIF, ref m_btCFR,ref m_lFreteInterno, ref m_tbFreteInterno, ref m_lFreteInternacional, ref m_tbFreteInternacional, ref m_lSeguro, ref m_tbSeguro/*, ref m_tbOutros, ref m_tbTextoOutros*/);
		}
		protected virtual void OnCallHabilitaIncoterms()
		{
			if (eCallHabilitaIncoterms != null)
				eCallHabilitaIncoterms(ref m_btCIP, ref m_btEXW, ref m_btFOB, ref m_btFAS, ref m_btDDP, ref m_btDDU, ref m_btDEQ, ref m_btDES, ref m_btDAF, ref m_btFCA, ref m_btCPT, ref m_btCIF, ref m_btCFR);
		}
		protected virtual void OnCallSelecionaMeioTransporte()
		{
			if (eCallSelecionaMeioTransporte != null)
			{
				eCallSelecionaMeioTransporte(ref m_rbAereo, ref m_rbMaritimo, ref m_rbRodoviario, ref m_rbFerroviario, ref m_rbCorreio);
				OnCallHabilitaIncoterms();
			}
		}
		protected virtual void OnCallIncotermInfo()
		{
			if (eCallIncotermInfo != null)
				eCallIncotermInfo(m_nIdInfoIncoterm);
		}

		protected virtual void OnCallEditaLocais()
		{
			if (eCallEditaLocais != null)
				eCallEditaLocais();
		}
		protected virtual void OnCallAlteraDescontoValor()
		{
			if (eCallAlteraDescontoValor != null)
				eCallAlteraDescontoValor(ref m_tbDesconto, ref m_tbDescontoPorcentagem);
		}
		protected virtual void OnCallAlteraDescontoPorcentagem()
		{
			if (eCallAlteraDescontoPorcentagem != null)
				eCallAlteraDescontoPorcentagem(ref m_tbDescontoPorcentagem, ref m_tbDesconto);
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFIncoterm));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_gbDespesas = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCorDespesa = new System.Windows.Forms.Button();
			this.m_gbBarra = new System.Windows.Forms.GroupBox();
			this.m_ckbxRatearDespesas = new System.Windows.Forms.CheckBox();
			this.m_tbOutros = new mdlComponentesGraficos.TextBox();
			this.m_tbSeguro = new mdlComponentesGraficos.TextBox();
			this.m_tbFreteInternacional = new mdlComponentesGraficos.TextBox();
			this.m_tbFreteInterno = new mdlComponentesGraficos.TextBox();
			this.m_lValorTotal = new System.Windows.Forms.Label();
			this.m_lTotalFinal = new System.Windows.Forms.Label();
			this.m_tbTextoOutros = new mdlComponentesGraficos.TextBox();
			this.m_lSeguro = new System.Windows.Forms.Label();
			this.m_lFreteInternacional = new System.Windows.Forms.Label();
			this.m_lFreteInterno = new System.Windows.Forms.Label();
			this.m_gbModalidades = new System.Windows.Forms.GroupBox();
			this.m_rbCorreio = new System.Windows.Forms.RadioButton();
			this.m_rbFerroviario = new System.Windows.Forms.RadioButton();
			this.m_rbRodoviario = new System.Windows.Forms.RadioButton();
			this.m_rbAereo = new System.Windows.Forms.RadioButton();
			this.m_rbMaritimo = new System.Windows.Forms.RadioButton();
			this.m_gbIncoterms = new System.Windows.Forms.GroupBox();
			this.m_btIDDP = new System.Windows.Forms.Button();
			this.m_btIDDU = new System.Windows.Forms.Button();
			this.m_btIDEQ = new System.Windows.Forms.Button();
			this.m_btIDES = new System.Windows.Forms.Button();
			this.m_btIDAF = new System.Windows.Forms.Button();
			this.m_btICIP = new System.Windows.Forms.Button();
			this.m_btICPT = new System.Windows.Forms.Button();
			this.m_btICIF = new System.Windows.Forms.Button();
			this.m_btICFR = new System.Windows.Forms.Button();
			this.m_btIFOB = new System.Windows.Forms.Button();
			this.m_btIFCA = new System.Windows.Forms.Button();
			this.m_btIFAS = new System.Windows.Forms.Button();
			this.m_btIEXW = new System.Windows.Forms.Button();
			this.m_btCIP = new System.Windows.Forms.RadioButton();
			this.m_btEXW = new System.Windows.Forms.RadioButton();
			this.m_btFOB = new System.Windows.Forms.RadioButton();
			this.m_btFAS = new System.Windows.Forms.RadioButton();
			this.m_btDDP = new System.Windows.Forms.RadioButton();
			this.m_btDDU = new System.Windows.Forms.RadioButton();
			this.m_btDEQ = new System.Windows.Forms.RadioButton();
			this.m_btDES = new System.Windows.Forms.RadioButton();
			this.m_btDAF = new System.Windows.Forms.RadioButton();
			this.m_btFCA = new System.Windows.Forms.RadioButton();
			this.m_btCPT = new System.Windows.Forms.RadioButton();
			this.m_btCIF = new System.Windows.Forms.RadioButton();
			this.m_btCFR = new System.Windows.Forms.RadioButton();
			this.m_gbInformacoes = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCorDesconto = new System.Windows.Forms.Button();
			this.m_lDescontoMoeda = new System.Windows.Forms.Label();
			this.m_lbSimboloPorcentagem = new System.Windows.Forms.Label();
			this.m_lValorTotalCDesconto = new System.Windows.Forms.Label();
			this.m_lTotalCDesconto = new System.Windows.Forms.Label();
			this.m_ckbxRatearDesconto = new System.Windows.Forms.CheckBox();
			this.m_tbDescontoPorcentagem = new mdlComponentesGraficos.TextBox();
			this.m_lOu = new System.Windows.Forms.Label();
			this.m_lDesconto = new System.Windows.Forms.Label();
			this.m_tbDesconto = new mdlComponentesGraficos.TextBox();
			this.m_lValorTotalProdutos = new System.Windows.Forms.Label();
			this.m_lSubTotal = new System.Windows.Forms.Label();
			this.m_gbLocais = new System.Windows.Forms.GroupBox();
			this.m_tbLocais = new mdlComponentesGraficos.TextBox();
			this.m_lLocais = new System.Windows.Forms.Label();
			this.m_btLocais = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.btTrocarCor = new System.Windows.Forms.Button();
			this.m_ttIncoterm = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbDespesas.SuspendLayout();
			this.m_gbModalidades.SuspendLayout();
			this.m_gbIncoterms.SuspendLayout();
			this.m_gbInformacoes.SuspendLayout();
			this.m_gbLocais.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_gbDespesas);
			this.m_gbFrame.Controls.Add(this.m_gbModalidades);
			this.m_gbFrame.Controls.Add(this.m_gbIncoterms);
			this.m_gbFrame.Controls.Add(this.m_gbInformacoes);
			this.m_gbFrame.Controls.Add(this.m_gbLocais);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.btTrocarCor);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(362, 485);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_gbDespesas
			// 
			this.m_gbDespesas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDespesas.Controls.Add(this.m_btTrocarCorDespesa);
			this.m_gbDespesas.Controls.Add(this.m_gbBarra);
			this.m_gbDespesas.Controls.Add(this.m_ckbxRatearDespesas);
			this.m_gbDespesas.Controls.Add(this.m_tbOutros);
			this.m_gbDespesas.Controls.Add(this.m_tbSeguro);
			this.m_gbDespesas.Controls.Add(this.m_tbFreteInternacional);
			this.m_gbDespesas.Controls.Add(this.m_tbFreteInterno);
			this.m_gbDespesas.Controls.Add(this.m_lValorTotal);
			this.m_gbDespesas.Controls.Add(this.m_lTotalFinal);
			this.m_gbDespesas.Controls.Add(this.m_tbTextoOutros);
			this.m_gbDespesas.Controls.Add(this.m_lSeguro);
			this.m_gbDespesas.Controls.Add(this.m_lFreteInternacional);
			this.m_gbDespesas.Controls.Add(this.m_lFreteInterno);
			this.m_gbDespesas.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDespesas.Location = new System.Drawing.Point(8, 241);
			this.m_gbDespesas.Name = "m_gbDespesas";
			this.m_gbDespesas.Size = new System.Drawing.Size(346, 161);
			this.m_gbDespesas.TabIndex = 32;
			this.m_gbDespesas.TabStop = false;
			this.m_gbDespesas.Text = "Despesas do Incoterm";
			// 
			// m_btTrocarCorDespesa
			// 
			this.m_btTrocarCorDespesa.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCorDespesa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCorDespesa.Location = new System.Drawing.Point(4, 11);
			this.m_btTrocarCorDespesa.Name = "m_btTrocarCorDespesa";
			this.m_btTrocarCorDespesa.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCorDespesa.TabIndex = 47;
			this.m_ttIncoterm.SetToolTip(this.m_btTrocarCorDespesa, "Cor");
			this.m_btTrocarCorDespesa.Click += new System.EventHandler(this.m_btTrocarCorDespesa_Click);
			// 
			// m_gbBarra
			// 
			this.m_gbBarra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbBarra.BackColor = System.Drawing.Color.Transparent;
			this.m_gbBarra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_gbBarra.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBarra.ForeColor = System.Drawing.Color.Black;
			this.m_gbBarra.Location = new System.Drawing.Point(185, 133);
			this.m_gbBarra.Name = "m_gbBarra";
			this.m_gbBarra.Size = new System.Drawing.Size(128, 4);
			this.m_gbBarra.TabIndex = 46;
			this.m_gbBarra.TabStop = false;
			// 
			// m_ckbxRatearDespesas
			// 
			this.m_ckbxRatearDespesas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckbxRatearDespesas.BackColor = System.Drawing.Color.Transparent;
			this.m_ckbxRatearDespesas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxRatearDespesas.ForeColor = System.Drawing.Color.Black;
			this.m_ckbxRatearDespesas.Location = new System.Drawing.Point(33, 116);
			this.m_ckbxRatearDespesas.Name = "m_ckbxRatearDespesas";
			this.m_ckbxRatearDespesas.Size = new System.Drawing.Size(295, 16);
			this.m_ckbxRatearDespesas.TabIndex = 45;
			this.m_ckbxRatearDespesas.Text = "Ratear as despesas entre os valores dos produtos";
			this.m_ttIncoterm.SetToolTip(this.m_ckbxRatearDespesas, "Quando você rateia as despesas, elas não estarão explícitas na fatura");
			this.m_ckbxRatearDespesas.CheckedChanged += new System.EventHandler(this.m_ckbxRatearDespesas_CheckedChanged);
			// 
			// m_tbOutros
			// 
			this.m_tbOutros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbOutros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbOutros.Location = new System.Drawing.Point(185, 90);
			this.m_tbOutros.Name = "m_tbOutros";
			this.m_tbOutros.OnlyNumbers = true;
			this.m_tbOutros.Size = new System.Drawing.Size(124, 20);
			this.m_tbOutros.TabIndex = 44;
			this.m_tbOutros.Text = "";
			this.m_tbOutros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_tbOutros.Leave += new System.EventHandler(this.m_tbOutros_Leave);
			// 
			// m_tbSeguro
			// 
			this.m_tbSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSeguro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSeguro.Location = new System.Drawing.Point(185, 66);
			this.m_tbSeguro.Name = "m_tbSeguro";
			this.m_tbSeguro.OnlyNumbers = true;
			this.m_tbSeguro.Size = new System.Drawing.Size(124, 20);
			this.m_tbSeguro.TabIndex = 42;
			this.m_tbSeguro.Text = "";
			this.m_tbSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_tbSeguro.Leave += new System.EventHandler(this.m_tbSeguro_Leave);
			// 
			// m_tbFreteInternacional
			// 
			this.m_tbFreteInternacional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbFreteInternacional.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFreteInternacional.Location = new System.Drawing.Point(185, 42);
			this.m_tbFreteInternacional.Name = "m_tbFreteInternacional";
			this.m_tbFreteInternacional.OnlyNumbers = true;
			this.m_tbFreteInternacional.Size = new System.Drawing.Size(124, 20);
			this.m_tbFreteInternacional.TabIndex = 41;
			this.m_tbFreteInternacional.Text = "";
			this.m_tbFreteInternacional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_tbFreteInternacional.Leave += new System.EventHandler(this.m_tbFreteInternacional_Leave);
			// 
			// m_tbFreteInterno
			// 
			this.m_tbFreteInterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbFreteInterno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFreteInterno.Location = new System.Drawing.Point(185, 18);
			this.m_tbFreteInterno.Name = "m_tbFreteInterno";
			this.m_tbFreteInterno.OnlyNumbers = true;
			this.m_tbFreteInterno.Size = new System.Drawing.Size(124, 20);
			this.m_tbFreteInterno.TabIndex = 40;
			this.m_tbFreteInterno.Text = "";
			this.m_tbFreteInterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_tbFreteInterno.Leave += new System.EventHandler(this.m_tbFreteInterno_Leave);
			// 
			// m_lValorTotal
			// 
			this.m_lValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lValorTotal.BackColor = System.Drawing.Color.Transparent;
			this.m_lValorTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValorTotal.ForeColor = System.Drawing.Color.Black;
			this.m_lValorTotal.Location = new System.Drawing.Point(185, 140);
			this.m_lValorTotal.Name = "m_lValorTotal";
			this.m_lValorTotal.Size = new System.Drawing.Size(124, 16);
			this.m_lValorTotal.TabIndex = 36;
			this.m_lValorTotal.Text = "Total dos Produtos";
			this.m_lValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lTotalFinal
			// 
			this.m_lTotalFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lTotalFinal.BackColor = System.Drawing.Color.Transparent;
			this.m_lTotalFinal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTotalFinal.ForeColor = System.Drawing.Color.Black;
			this.m_lTotalFinal.Location = new System.Drawing.Point(33, 140);
			this.m_lTotalFinal.Name = "m_lTotalFinal";
			this.m_lTotalFinal.Size = new System.Drawing.Size(78, 16);
			this.m_lTotalFinal.TabIndex = 35;
			this.m_lTotalFinal.Text = "Valor Total:";
			// 
			// m_tbTextoOutros
			// 
			this.m_tbTextoOutros.AcceptsReturn = true;
			this.m_tbTextoOutros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbTextoOutros.AutoSize = false;
			this.m_tbTextoOutros.BackColor = System.Drawing.SystemColors.Window;
			this.m_tbTextoOutros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tbTextoOutros.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.m_tbTextoOutros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTextoOutros.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_tbTextoOutros.Location = new System.Drawing.Point(33, 92);
			this.m_tbTextoOutros.MaxLength = 50;
			this.m_tbTextoOutros.Name = "m_tbTextoOutros";
			this.m_tbTextoOutros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_tbTextoOutros.Size = new System.Drawing.Size(136, 16);
			this.m_tbTextoOutros.TabIndex = 43;
			this.m_tbTextoOutros.Text = "Outros";
			this.m_tbTextoOutros.Leave += new System.EventHandler(this.m_tbTextoOutros_Leave);
			// 
			// m_lSeguro
			// 
			this.m_lSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSeguro.BackColor = System.Drawing.Color.Transparent;
			this.m_lSeguro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSeguro.ForeColor = System.Drawing.Color.Black;
			this.m_lSeguro.Location = new System.Drawing.Point(33, 68);
			this.m_lSeguro.Name = "m_lSeguro";
			this.m_lSeguro.Size = new System.Drawing.Size(60, 16);
			this.m_lSeguro.TabIndex = 37;
			this.m_lSeguro.Text = "Seguro:";
			// 
			// m_lFreteInternacional
			// 
			this.m_lFreteInternacional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFreteInternacional.BackColor = System.Drawing.Color.Transparent;
			this.m_lFreteInternacional.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFreteInternacional.ForeColor = System.Drawing.Color.Black;
			this.m_lFreteInternacional.Location = new System.Drawing.Point(33, 46);
			this.m_lFreteInternacional.Name = "m_lFreteInternacional";
			this.m_lFreteInternacional.Size = new System.Drawing.Size(128, 16);
			this.m_lFreteInternacional.TabIndex = 39;
			this.m_lFreteInternacional.Text = "Frete Internacional:";
			// 
			// m_lFreteInterno
			// 
			this.m_lFreteInterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFreteInterno.BackColor = System.Drawing.Color.Transparent;
			this.m_lFreteInterno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFreteInterno.ForeColor = System.Drawing.Color.Black;
			this.m_lFreteInterno.Location = new System.Drawing.Point(33, 22);
			this.m_lFreteInterno.Name = "m_lFreteInterno";
			this.m_lFreteInterno.Size = new System.Drawing.Size(88, 16);
			this.m_lFreteInterno.TabIndex = 38;
			this.m_lFreteInterno.Text = "Frete Interno:";
			// 
			// m_gbModalidades
			// 
			this.m_gbModalidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbModalidades.BackColor = System.Drawing.Color.Transparent;
			this.m_gbModalidades.Controls.Add(this.m_rbCorreio);
			this.m_gbModalidades.Controls.Add(this.m_rbFerroviario);
			this.m_gbModalidades.Controls.Add(this.m_rbRodoviario);
			this.m_gbModalidades.Controls.Add(this.m_rbAereo);
			this.m_gbModalidades.Controls.Add(this.m_rbMaritimo);
			this.m_gbModalidades.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbModalidades.ForeColor = System.Drawing.Color.Black;
			this.m_gbModalidades.Location = new System.Drawing.Point(8, 6);
			this.m_gbModalidades.Name = "m_gbModalidades";
			this.m_gbModalidades.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_gbModalidades.Size = new System.Drawing.Size(120, 124);
			this.m_gbModalidades.TabIndex = 0;
			this.m_gbModalidades.TabStop = false;
			this.m_gbModalidades.Text = "Modalidade";
			// 
			// m_rbCorreio
			// 
			this.m_rbCorreio.BackColor = System.Drawing.Color.Transparent;
			this.m_rbCorreio.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_rbCorreio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbCorreio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_rbCorreio.Location = new System.Drawing.Point(8, 94);
			this.m_rbCorreio.Name = "m_rbCorreio";
			this.m_rbCorreio.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_rbCorreio.Size = new System.Drawing.Size(110, 16);
			this.m_rbCorreio.TabIndex = 5;
			this.m_rbCorreio.Text = "Correio / Courrier";
			this.m_ttIncoterm.SetToolTip(this.m_rbCorreio, "Selecione a modalidade");
			this.m_rbCorreio.CheckedChanged += new System.EventHandler(this.m_rbCorreio_CheckedChanged);
			// 
			// m_rbFerroviario
			// 
			this.m_rbFerroviario.BackColor = System.Drawing.Color.Transparent;
			this.m_rbFerroviario.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_rbFerroviario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbFerroviario.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_rbFerroviario.Location = new System.Drawing.Point(8, 77);
			this.m_rbFerroviario.Name = "m_rbFerroviario";
			this.m_rbFerroviario.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_rbFerroviario.Size = new System.Drawing.Size(81, 16);
			this.m_rbFerroviario.TabIndex = 4;
			this.m_rbFerroviario.Text = "Ferroviário";
			this.m_ttIncoterm.SetToolTip(this.m_rbFerroviario, "Selecione a modalidade");
			this.m_rbFerroviario.CheckedChanged += new System.EventHandler(this.m_rbFerroviario_CheckedChanged);
			// 
			// m_rbRodoviario
			// 
			this.m_rbRodoviario.BackColor = System.Drawing.Color.Transparent;
			this.m_rbRodoviario.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_rbRodoviario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbRodoviario.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_rbRodoviario.Location = new System.Drawing.Point(8, 60);
			this.m_rbRodoviario.Name = "m_rbRodoviario";
			this.m_rbRodoviario.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_rbRodoviario.Size = new System.Drawing.Size(81, 16);
			this.m_rbRodoviario.TabIndex = 3;
			this.m_rbRodoviario.Text = "Rodoviário";
			this.m_ttIncoterm.SetToolTip(this.m_rbRodoviario, "Selecione a modalidade");
			this.m_rbRodoviario.CheckedChanged += new System.EventHandler(this.m_rbRodoviario_CheckedChanged);
			// 
			// m_rbAereo
			// 
			this.m_rbAereo.BackColor = System.Drawing.Color.Transparent;
			this.m_rbAereo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_rbAereo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbAereo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_rbAereo.Location = new System.Drawing.Point(8, 41);
			this.m_rbAereo.Name = "m_rbAereo";
			this.m_rbAereo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_rbAereo.Size = new System.Drawing.Size(81, 18);
			this.m_rbAereo.TabIndex = 2;
			this.m_rbAereo.Text = "Aéreo";
			this.m_ttIncoterm.SetToolTip(this.m_rbAereo, "Selecione a modalidade");
			this.m_rbAereo.CheckedChanged += new System.EventHandler(this.m_rbAereo_CheckedChanged);
			// 
			// m_rbMaritimo
			// 
			this.m_rbMaritimo.BackColor = System.Drawing.Color.Transparent;
			this.m_rbMaritimo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_rbMaritimo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbMaritimo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_rbMaritimo.Location = new System.Drawing.Point(8, 26);
			this.m_rbMaritimo.Name = "m_rbMaritimo";
			this.m_rbMaritimo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_rbMaritimo.Size = new System.Drawing.Size(81, 14);
			this.m_rbMaritimo.TabIndex = 1;
			this.m_rbMaritimo.Text = "Marítimo";
			this.m_ttIncoterm.SetToolTip(this.m_rbMaritimo, "Selecione a modalidade");
			this.m_rbMaritimo.CheckedChanged += new System.EventHandler(this.m_rbMaritimo_CheckedChanged);
			// 
			// m_gbIncoterms
			// 
			this.m_gbIncoterms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbIncoterms.BackColor = System.Drawing.Color.Transparent;
			this.m_gbIncoterms.Controls.Add(this.m_btIDDP);
			this.m_gbIncoterms.Controls.Add(this.m_btIDDU);
			this.m_gbIncoterms.Controls.Add(this.m_btIDEQ);
			this.m_gbIncoterms.Controls.Add(this.m_btIDES);
			this.m_gbIncoterms.Controls.Add(this.m_btIDAF);
			this.m_gbIncoterms.Controls.Add(this.m_btICIP);
			this.m_gbIncoterms.Controls.Add(this.m_btICPT);
			this.m_gbIncoterms.Controls.Add(this.m_btICIF);
			this.m_gbIncoterms.Controls.Add(this.m_btICFR);
			this.m_gbIncoterms.Controls.Add(this.m_btIFOB);
			this.m_gbIncoterms.Controls.Add(this.m_btIFCA);
			this.m_gbIncoterms.Controls.Add(this.m_btIFAS);
			this.m_gbIncoterms.Controls.Add(this.m_btIEXW);
			this.m_gbIncoterms.Controls.Add(this.m_btCIP);
			this.m_gbIncoterms.Controls.Add(this.m_btEXW);
			this.m_gbIncoterms.Controls.Add(this.m_btFOB);
			this.m_gbIncoterms.Controls.Add(this.m_btFAS);
			this.m_gbIncoterms.Controls.Add(this.m_btDDP);
			this.m_gbIncoterms.Controls.Add(this.m_btDDU);
			this.m_gbIncoterms.Controls.Add(this.m_btDEQ);
			this.m_gbIncoterms.Controls.Add(this.m_btDES);
			this.m_gbIncoterms.Controls.Add(this.m_btDAF);
			this.m_gbIncoterms.Controls.Add(this.m_btFCA);
			this.m_gbIncoterms.Controls.Add(this.m_btCPT);
			this.m_gbIncoterms.Controls.Add(this.m_btCIF);
			this.m_gbIncoterms.Controls.Add(this.m_btCFR);
			this.m_gbIncoterms.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIncoterms.ForeColor = System.Drawing.Color.Black;
			this.m_gbIncoterms.Location = new System.Drawing.Point(134, 6);
			this.m_gbIncoterms.Name = "m_gbIncoterms";
			this.m_gbIncoterms.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_gbIncoterms.Size = new System.Drawing.Size(219, 124);
			this.m_gbIncoterms.TabIndex = 0;
			this.m_gbIncoterms.TabStop = false;
			this.m_gbIncoterms.Text = "Incoterms";
			// 
			// m_btIDDP
			// 
			this.m_btIDDP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIDDP.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIDDP.Location = new System.Drawing.Point(202, 108);
			this.m_btIDDP.Name = "m_btIDDP";
			this.m_btIDDP.Size = new System.Drawing.Size(5, 5);
			this.m_btIDDP.TabIndex = 43;
			this.m_ttIncoterm.SetToolTip(this.m_btIDDP, "Informações");
			this.m_btIDDP.Click += new System.EventHandler(this.m_btIDDP_Click);
			// 
			// m_btIDDU
			// 
			this.m_btIDDU.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIDDU.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIDDU.Location = new System.Drawing.Point(162, 108);
			this.m_btIDDU.Name = "m_btIDDU";
			this.m_btIDDU.Size = new System.Drawing.Size(5, 5);
			this.m_btIDDU.TabIndex = 42;
			this.m_ttIncoterm.SetToolTip(this.m_btIDDU, "Informações");
			this.m_btIDDU.Click += new System.EventHandler(this.m_btIDDU_Click);
			// 
			// m_btIDEQ
			// 
			this.m_btIDEQ.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIDEQ.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIDEQ.Location = new System.Drawing.Point(122, 108);
			this.m_btIDEQ.Name = "m_btIDEQ";
			this.m_btIDEQ.Size = new System.Drawing.Size(5, 5);
			this.m_btIDEQ.TabIndex = 41;
			this.m_ttIncoterm.SetToolTip(this.m_btIDEQ, "Informações");
			this.m_btIDEQ.Click += new System.EventHandler(this.m_btIDEQ_Click);
			// 
			// m_btIDES
			// 
			this.m_btIDES.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIDES.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIDES.Location = new System.Drawing.Point(82, 108);
			this.m_btIDES.Name = "m_btIDES";
			this.m_btIDES.Size = new System.Drawing.Size(5, 5);
			this.m_btIDES.TabIndex = 40;
			this.m_ttIncoterm.SetToolTip(this.m_btIDES, "Informações");
			this.m_btIDES.Click += new System.EventHandler(this.m_btIDES_Click);
			// 
			// m_btIDAF
			// 
			this.m_btIDAF.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIDAF.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIDAF.Location = new System.Drawing.Point(42, 108);
			this.m_btIDAF.Name = "m_btIDAF";
			this.m_btIDAF.Size = new System.Drawing.Size(5, 5);
			this.m_btIDAF.TabIndex = 39;
			this.m_ttIncoterm.SetToolTip(this.m_btIDAF, "Informações");
			this.m_btIDAF.Click += new System.EventHandler(this.m_btIDAF_Click);
			// 
			// m_btICIP
			// 
			this.m_btICIP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btICIP.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btICIP.Location = new System.Drawing.Point(186, 84);
			this.m_btICIP.Name = "m_btICIP";
			this.m_btICIP.Size = new System.Drawing.Size(5, 5);
			this.m_btICIP.TabIndex = 38;
			this.m_ttIncoterm.SetToolTip(this.m_btICIP, "Informações");
			this.m_btICIP.Click += new System.EventHandler(this.m_btICIP_Click);
			// 
			// m_btICPT
			// 
			this.m_btICPT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btICPT.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btICPT.Location = new System.Drawing.Point(146, 84);
			this.m_btICPT.Name = "m_btICPT";
			this.m_btICPT.Size = new System.Drawing.Size(5, 5);
			this.m_btICPT.TabIndex = 37;
			this.m_ttIncoterm.SetToolTip(this.m_btICPT, "Informações");
			this.m_btICPT.Click += new System.EventHandler(this.m_btICPT_Click);
			// 
			// m_btICIF
			// 
			this.m_btICIF.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btICIF.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btICIF.Location = new System.Drawing.Point(106, 84);
			this.m_btICIF.Name = "m_btICIF";
			this.m_btICIF.Size = new System.Drawing.Size(5, 5);
			this.m_btICIF.TabIndex = 36;
			this.m_ttIncoterm.SetToolTip(this.m_btICIF, "Informações");
			this.m_btICIF.Click += new System.EventHandler(this.m_btICIF_Click);
			// 
			// m_btICFR
			// 
			this.m_btICFR.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btICFR.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btICFR.Location = new System.Drawing.Point(66, 84);
			this.m_btICFR.Name = "m_btICFR";
			this.m_btICFR.Size = new System.Drawing.Size(5, 5);
			this.m_btICFR.TabIndex = 35;
			this.m_ttIncoterm.SetToolTip(this.m_btICFR, "Informações");
			this.m_btICFR.Click += new System.EventHandler(this.m_btICFR_Click);
			// 
			// m_btIFOB
			// 
			this.m_btIFOB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIFOB.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIFOB.Location = new System.Drawing.Point(170, 60);
			this.m_btIFOB.Name = "m_btIFOB";
			this.m_btIFOB.Size = new System.Drawing.Size(5, 5);
			this.m_btIFOB.TabIndex = 34;
			this.m_ttIncoterm.SetToolTip(this.m_btIFOB, "Informações");
			this.m_btIFOB.Click += new System.EventHandler(this.m_btIFOB_Click);
			// 
			// m_btIFCA
			// 
			this.m_btIFCA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIFCA.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIFCA.Location = new System.Drawing.Point(90, 60);
			this.m_btIFCA.Name = "m_btIFCA";
			this.m_btIFCA.Size = new System.Drawing.Size(5, 5);
			this.m_btIFCA.TabIndex = 32;
			this.m_ttIncoterm.SetToolTip(this.m_btIFCA, "Informações");
			this.m_btIFCA.Click += new System.EventHandler(this.m_btIFCA_Click);
			// 
			// m_btIFAS
			// 
			this.m_btIFAS.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIFAS.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIFAS.Location = new System.Drawing.Point(130, 60);
			this.m_btIFAS.Name = "m_btIFAS";
			this.m_btIFAS.Size = new System.Drawing.Size(5, 5);
			this.m_btIFAS.TabIndex = 33;
			this.m_ttIncoterm.SetToolTip(this.m_btIFAS, "Informações");
			this.m_btIFAS.Click += new System.EventHandler(this.m_btIFAS_Click);
			// 
			// m_btIEXW
			// 
			this.m_btIEXW.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btIEXW.Cursor = System.Windows.Forms.Cursors.Help;
			this.m_btIEXW.Location = new System.Drawing.Point(130, 36);
			this.m_btIEXW.Name = "m_btIEXW";
			this.m_btIEXW.Size = new System.Drawing.Size(5, 5);
			this.m_btIEXW.TabIndex = 31;
			this.m_ttIncoterm.SetToolTip(this.m_btIEXW, "Informações");
			this.m_btIEXW.Click += new System.EventHandler(this.m_btIEXW_Click);
			// 
			// m_btCIP
			// 
			this.m_btCIP.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btCIP.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCIP.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCIP.Enabled = false;
			this.m_btCIP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCIP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCIP.Location = new System.Drawing.Point(153, 68);
			this.m_btCIP.Name = "m_btCIP";
			this.m_btCIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCIP.Size = new System.Drawing.Size(41, 24);
			this.m_btCIP.TabIndex = 13;
			this.m_btCIP.TabStop = true;
			this.m_btCIP.Text = "CIP";
			this.m_btCIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btCIP, "Selecione o incoterm");
			this.m_btCIP.CheckedChanged += new System.EventHandler(this.m_btCIP_CheckedChanged);
			// 
			// m_btEXW
			// 
			this.m_btEXW.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btEXW.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEXW.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEXW.Enabled = false;
			this.m_btEXW.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEXW.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEXW.Location = new System.Drawing.Point(97, 20);
			this.m_btEXW.Name = "m_btEXW";
			this.m_btEXW.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEXW.Size = new System.Drawing.Size(41, 24);
			this.m_btEXW.TabIndex = 6;
			this.m_btEXW.TabStop = true;
			this.m_btEXW.Text = "EXW";
			this.m_btEXW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btEXW, "Selecione o incoterm");
			this.m_btEXW.CheckedChanged += new System.EventHandler(this.m_btEXW_CheckedChanged);
			// 
			// m_btFOB
			// 
			this.m_btFOB.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btFOB.BackColor = System.Drawing.SystemColors.Control;
			this.m_btFOB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFOB.Enabled = false;
			this.m_btFOB.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btFOB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFOB.Location = new System.Drawing.Point(137, 44);
			this.m_btFOB.Name = "m_btFOB";
			this.m_btFOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFOB.Size = new System.Drawing.Size(41, 24);
			this.m_btFOB.TabIndex = 9;
			this.m_btFOB.TabStop = true;
			this.m_btFOB.Text = "FOB";
			this.m_btFOB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btFOB, "Selecione o incoterm");
			this.m_btFOB.CheckedChanged += new System.EventHandler(this.m_btFOB_CheckedChanged);
			// 
			// m_btFAS
			// 
			this.m_btFAS.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btFAS.BackColor = System.Drawing.SystemColors.Control;
			this.m_btFAS.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFAS.Enabled = false;
			this.m_btFAS.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btFAS.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFAS.Location = new System.Drawing.Point(97, 44);
			this.m_btFAS.Name = "m_btFAS";
			this.m_btFAS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFAS.Size = new System.Drawing.Size(41, 24);
			this.m_btFAS.TabIndex = 8;
			this.m_btFAS.TabStop = true;
			this.m_btFAS.Text = "FAS";
			this.m_btFAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btFAS, "Selecione o incoterm");
			this.m_btFAS.CheckedChanged += new System.EventHandler(this.m_btFAS_CheckedChanged);
			// 
			// m_btDDP
			// 
			this.m_btDDP.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btDDP.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDDP.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDDP.Enabled = false;
			this.m_btDDP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDDP.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDDP.Location = new System.Drawing.Point(169, 92);
			this.m_btDDP.Name = "m_btDDP";
			this.m_btDDP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDDP.Size = new System.Drawing.Size(41, 24);
			this.m_btDDP.TabIndex = 18;
			this.m_btDDP.TabStop = true;
			this.m_btDDP.Text = "DDP";
			this.m_btDDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btDDP, "Selecione o incoterm");
			this.m_btDDP.CheckedChanged += new System.EventHandler(this.m_btDDP_CheckedChanged);
			// 
			// m_btDDU
			// 
			this.m_btDDU.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btDDU.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDDU.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDDU.Enabled = false;
			this.m_btDDU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDDU.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDDU.Location = new System.Drawing.Point(129, 92);
			this.m_btDDU.Name = "m_btDDU";
			this.m_btDDU.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDDU.Size = new System.Drawing.Size(41, 24);
			this.m_btDDU.TabIndex = 17;
			this.m_btDDU.TabStop = true;
			this.m_btDDU.Text = "DDU";
			this.m_btDDU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btDDU, "Selecione o incoterm");
			this.m_btDDU.CheckedChanged += new System.EventHandler(this.m_btDDU_CheckedChanged);
			// 
			// m_btDEQ
			// 
			this.m_btDEQ.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btDEQ.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDEQ.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDEQ.Enabled = false;
			this.m_btDEQ.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDEQ.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDEQ.Location = new System.Drawing.Point(89, 92);
			this.m_btDEQ.Name = "m_btDEQ";
			this.m_btDEQ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDEQ.Size = new System.Drawing.Size(41, 24);
			this.m_btDEQ.TabIndex = 16;
			this.m_btDEQ.TabStop = true;
			this.m_btDEQ.Text = "DEQ";
			this.m_btDEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btDEQ, "Selecione o incoterm");
			this.m_btDEQ.CheckedChanged += new System.EventHandler(this.m_btDEQ_CheckedChanged);
			// 
			// m_btDES
			// 
			this.m_btDES.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btDES.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDES.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDES.Enabled = false;
			this.m_btDES.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDES.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDES.Location = new System.Drawing.Point(49, 92);
			this.m_btDES.Name = "m_btDES";
			this.m_btDES.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDES.Size = new System.Drawing.Size(41, 24);
			this.m_btDES.TabIndex = 15;
			this.m_btDES.TabStop = true;
			this.m_btDES.Text = "DES";
			this.m_btDES.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btDES, "Selecione o incoterm");
			this.m_btDES.CheckedChanged += new System.EventHandler(this.m_btDES_CheckedChanged);
			// 
			// m_btDAF
			// 
			this.m_btDAF.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btDAF.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDAF.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDAF.Enabled = false;
			this.m_btDAF.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDAF.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDAF.Location = new System.Drawing.Point(9, 92);
			this.m_btDAF.Name = "m_btDAF";
			this.m_btDAF.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDAF.Size = new System.Drawing.Size(41, 24);
			this.m_btDAF.TabIndex = 14;
			this.m_btDAF.TabStop = true;
			this.m_btDAF.Text = "DAF";
			this.m_btDAF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btDAF, "Selecione o incoterm");
			this.m_btDAF.CheckedChanged += new System.EventHandler(this.m_btDAF_CheckedChanged);
			// 
			// m_btFCA
			// 
			this.m_btFCA.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btFCA.BackColor = System.Drawing.SystemColors.Control;
			this.m_btFCA.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFCA.Enabled = false;
			this.m_btFCA.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btFCA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFCA.Location = new System.Drawing.Point(57, 44);
			this.m_btFCA.Name = "m_btFCA";
			this.m_btFCA.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFCA.Size = new System.Drawing.Size(41, 24);
			this.m_btFCA.TabIndex = 7;
			this.m_btFCA.TabStop = true;
			this.m_btFCA.Text = "FCA";
			this.m_btFCA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btFCA, "Selecione o incoterm");
			this.m_btFCA.CheckedChanged += new System.EventHandler(this.m_btFCA_CheckedChanged);
			// 
			// m_btCPT
			// 
			this.m_btCPT.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btCPT.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCPT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCPT.Enabled = false;
			this.m_btCPT.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCPT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCPT.Location = new System.Drawing.Point(113, 68);
			this.m_btCPT.Name = "m_btCPT";
			this.m_btCPT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCPT.Size = new System.Drawing.Size(41, 24);
			this.m_btCPT.TabIndex = 12;
			this.m_btCPT.TabStop = true;
			this.m_btCPT.Text = "CPT";
			this.m_btCPT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btCPT, "Selecione o incoterm");
			this.m_btCPT.CheckedChanged += new System.EventHandler(this.m_btCPT_CheckedChanged);
			// 
			// m_btCIF
			// 
			this.m_btCIF.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btCIF.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCIF.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCIF.Enabled = false;
			this.m_btCIF.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCIF.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCIF.Location = new System.Drawing.Point(73, 68);
			this.m_btCIF.Name = "m_btCIF";
			this.m_btCIF.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCIF.Size = new System.Drawing.Size(41, 24);
			this.m_btCIF.TabIndex = 11;
			this.m_btCIF.TabStop = true;
			this.m_btCIF.Text = "CIF";
			this.m_btCIF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btCIF, "Selecione o incoterm");
			this.m_btCIF.CheckedChanged += new System.EventHandler(this.m_btCIF_CheckedChanged);
			// 
			// m_btCFR
			// 
			this.m_btCFR.Appearance = System.Windows.Forms.Appearance.Button;
			this.m_btCFR.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCFR.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCFR.Enabled = false;
			this.m_btCFR.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCFR.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCFR.Location = new System.Drawing.Point(33, 68);
			this.m_btCFR.Name = "m_btCFR";
			this.m_btCFR.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCFR.Size = new System.Drawing.Size(41, 24);
			this.m_btCFR.TabIndex = 10;
			this.m_btCFR.TabStop = true;
			this.m_btCFR.Text = "CFR";
			this.m_btCFR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_ttIncoterm.SetToolTip(this.m_btCFR, "Selecione o incoterm");
			this.m_btCFR.CheckedChanged += new System.EventHandler(this.m_btCFR_CheckedChanged);
			// 
			// m_gbInformacoes
			// 
			this.m_gbInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbInformacoes.BackColor = System.Drawing.Color.Transparent;
			this.m_gbInformacoes.Controls.Add(this.m_btTrocarCorDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_lDescontoMoeda);
			this.m_gbInformacoes.Controls.Add(this.m_lbSimboloPorcentagem);
			this.m_gbInformacoes.Controls.Add(this.m_lValorTotalCDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_lTotalCDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_ckbxRatearDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_tbDescontoPorcentagem);
			this.m_gbInformacoes.Controls.Add(this.m_lOu);
			this.m_gbInformacoes.Controls.Add(this.m_lDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_tbDesconto);
			this.m_gbInformacoes.Controls.Add(this.m_lValorTotalProdutos);
			this.m_gbInformacoes.Controls.Add(this.m_lSubTotal);
			this.m_gbInformacoes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbInformacoes.ForeColor = System.Drawing.Color.Black;
			this.m_gbInformacoes.Location = new System.Drawing.Point(8, 130);
			this.m_gbInformacoes.Name = "m_gbInformacoes";
			this.m_gbInformacoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_gbInformacoes.Size = new System.Drawing.Size(346, 111);
			this.m_gbInformacoes.TabIndex = 0;
			this.m_gbInformacoes.TabStop = false;
			this.m_gbInformacoes.Text = "Desconto";
			// 
			// m_btTrocarCorDesconto
			// 
			this.m_btTrocarCorDesconto.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCorDesconto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCorDesconto.Location = new System.Drawing.Point(4, 11);
			this.m_btTrocarCorDesconto.Name = "m_btTrocarCorDesconto";
			this.m_btTrocarCorDesconto.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCorDesconto.TabIndex = 36;
			this.m_ttIncoterm.SetToolTip(this.m_btTrocarCorDesconto, "Cor");
			this.m_btTrocarCorDesconto.Click += new System.EventHandler(this.m_btTrocarCorDesconto_Click);
			// 
			// m_lDescontoMoeda
			// 
			this.m_lDescontoMoeda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDescontoMoeda.Location = new System.Drawing.Point(204, 41);
			this.m_lDescontoMoeda.Name = "m_lDescontoMoeda";
			this.m_lDescontoMoeda.Size = new System.Drawing.Size(37, 16);
			this.m_lDescontoMoeda.TabIndex = 35;
			// 
			// m_lbSimboloPorcentagem
			// 
			this.m_lbSimboloPorcentagem.Font = new System.Drawing.Font("Arial", 8.25F);
			this.m_lbSimboloPorcentagem.Location = new System.Drawing.Point(150, 41);
			this.m_lbSimboloPorcentagem.Name = "m_lbSimboloPorcentagem";
			this.m_lbSimboloPorcentagem.Size = new System.Drawing.Size(16, 16);
			this.m_lbSimboloPorcentagem.TabIndex = 33;
			this.m_lbSimboloPorcentagem.Text = "%";
			// 
			// m_lValorTotalCDesconto
			// 
			this.m_lValorTotalCDesconto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValorTotalCDesconto.Location = new System.Drawing.Point(184, 89);
			this.m_lValorTotalCDesconto.Name = "m_lValorTotalCDesconto";
			this.m_lValorTotalCDesconto.Size = new System.Drawing.Size(124, 16);
			this.m_lValorTotalCDesconto.TabIndex = 32;
			this.m_lValorTotalCDesconto.Text = "Produtos C/ Desconto";
			this.m_lValorTotalCDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lTotalCDesconto
			// 
			this.m_lTotalCDesconto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTotalCDesconto.Location = new System.Drawing.Point(32, 89);
			this.m_lTotalCDesconto.Name = "m_lTotalCDesconto";
			this.m_lTotalCDesconto.Size = new System.Drawing.Size(152, 16);
			this.m_lTotalCDesconto.TabIndex = 31;
			this.m_lTotalCDesconto.Text = "Valor Subtotal C/ Desconto:";
			// 
			// m_ckbxRatearDesconto
			// 
			this.m_ckbxRatearDesconto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckbxRatearDesconto.Location = new System.Drawing.Point(32, 65);
			this.m_ckbxRatearDesconto.Name = "m_ckbxRatearDesconto";
			this.m_ckbxRatearDesconto.Size = new System.Drawing.Size(288, 16);
			this.m_ckbxRatearDesconto.TabIndex = 21;
			this.m_ckbxRatearDesconto.Text = "Ratear o desconto entre os valores dos produtos";
			this.m_ttIncoterm.SetToolTip(this.m_ckbxRatearDesconto, "Quando você rateia o desconto, ele não estará explícito na fatura");
			this.m_ckbxRatearDesconto.CheckedChanged += new System.EventHandler(this.m_ckbxRatearDesconto_CheckedChanged);
			// 
			// m_tbDescontoPorcentagem
			// 
			this.m_tbDescontoPorcentagem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDescontoPorcentagem.Location = new System.Drawing.Point(111, 38);
			this.m_tbDescontoPorcentagem.Name = "m_tbDescontoPorcentagem";
			this.m_tbDescontoPorcentagem.OnlyNumbers = true;
			this.m_tbDescontoPorcentagem.Size = new System.Drawing.Size(40, 20);
			this.m_tbDescontoPorcentagem.TabIndex = 19;
			this.m_tbDescontoPorcentagem.Text = "0";
			this.m_tbDescontoPorcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_ttIncoterm.SetToolTip(this.m_tbDescontoPorcentagem, "Desconto em porcentagem sobre o SubTotal dos Produtos");
			this.m_tbDescontoPorcentagem.Leave += new System.EventHandler(this.m_tbDescontoPorcentagem_Leave);
			this.m_tbDescontoPorcentagem.TextChanged += new System.EventHandler(this.m_tbDescontoPorcentagem_TextChanged);
			// 
			// m_lOu
			// 
			this.m_lOu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lOu.Location = new System.Drawing.Point(167, 41);
			this.m_lOu.Name = "m_lOu";
			this.m_lOu.Size = new System.Drawing.Size(17, 16);
			this.m_lOu.TabIndex = 27;
			this.m_lOu.Text = "ou";
			// 
			// m_lDesconto
			// 
			this.m_lDesconto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDesconto.Location = new System.Drawing.Point(32, 41);
			this.m_lDesconto.Name = "m_lDesconto";
			this.m_lDesconto.Size = new System.Drawing.Size(55, 16);
			this.m_lDesconto.TabIndex = 25;
			this.m_lDesconto.Text = "Desconto:";
			// 
			// m_tbDesconto
			// 
			this.m_tbDesconto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDesconto.ForeColor = System.Drawing.Color.Red;
			this.m_tbDesconto.Location = new System.Drawing.Point(243, 38);
			this.m_tbDesconto.Name = "m_tbDesconto";
			this.m_tbDesconto.OnlyNumbers = true;
			this.m_tbDesconto.Size = new System.Drawing.Size(64, 20);
			this.m_tbDesconto.TabIndex = 20;
			this.m_tbDesconto.Text = "0";
			this.m_tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_ttIncoterm.SetToolTip(this.m_tbDesconto, "Desconto em valor sobre o SubTotal dos Produtos");
			this.m_tbDesconto.Leave += new System.EventHandler(this.m_tbDesconto_Leave);
			this.m_tbDesconto.TextChanged += new System.EventHandler(this.m_tbDesconto_TextChanged);
			// 
			// m_lValorTotalProdutos
			// 
			this.m_lValorTotalProdutos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lValorTotalProdutos.Location = new System.Drawing.Point(184, 19);
			this.m_lValorTotalProdutos.Name = "m_lValorTotalProdutos";
			this.m_lValorTotalProdutos.Size = new System.Drawing.Size(124, 16);
			this.m_lValorTotalProdutos.TabIndex = 0;
			this.m_lValorTotalProdutos.Text = "Total dos Produtos";
			this.m_lValorTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_lSubTotal
			// 
			this.m_lSubTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSubTotal.Location = new System.Drawing.Point(32, 19);
			this.m_lSubTotal.Name = "m_lSubTotal";
			this.m_lSubTotal.Size = new System.Drawing.Size(152, 16);
			this.m_lSubTotal.TabIndex = 0;
			this.m_lSubTotal.Text = "Valor Subtotal Produtos:";
			// 
			// m_gbLocais
			// 
			this.m_gbLocais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbLocais.Controls.Add(this.m_tbLocais);
			this.m_gbLocais.Controls.Add(this.m_lLocais);
			this.m_gbLocais.Controls.Add(this.m_btLocais);
			this.m_gbLocais.Location = new System.Drawing.Point(8, 403);
			this.m_gbLocais.Name = "m_gbLocais";
			this.m_gbLocais.Size = new System.Drawing.Size(346, 48);
			this.m_gbLocais.TabIndex = 0;
			this.m_gbLocais.TabStop = false;
			// 
			// m_tbLocais
			// 
			this.m_tbLocais.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbLocais.Location = new System.Drawing.Point(115, 17);
			this.m_tbLocais.Name = "m_tbLocais";
			this.m_tbLocais.Size = new System.Drawing.Size(185, 20);
			this.m_tbLocais.TabIndex = 28;
			this.m_tbLocais.Text = "";
			this.m_ttIncoterm.SetToolTip(this.m_tbLocais, "Editar texto");
			this.m_tbLocais.Leave += new System.EventHandler(this.m_tbLocais_Leave);
			// 
			// m_lLocais
			// 
			this.m_lLocais.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lLocais.Location = new System.Drawing.Point(12, 20);
			this.m_lLocais.Name = "m_lLocais";
			this.m_lLocais.Size = new System.Drawing.Size(97, 13);
			this.m_lLocais.TabIndex = 0;
			this.m_lLocais.Text = "Local do Incoterm:";
			// 
			// m_btLocais
			// 
			this.m_btLocais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btLocais.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btLocais.Image = ((System.Drawing.Image)(resources.GetObject("m_btLocais.Image")));
			this.m_btLocais.Location = new System.Drawing.Point(308, 14);
			this.m_btLocais.Name = "m_btLocais";
			this.m_btLocais.Size = new System.Drawing.Size(24, 24);
			this.m_btLocais.TabIndex = 29;
			this.m_ttIncoterm.SetToolTip(this.m_btLocais, "Editar Local");
			this.m_btLocais.Click += new System.EventHandler(this.m_btLocais_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(130, 455);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 30;
			this.m_ttIncoterm.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(196, 455);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 31;
			this.m_ttIncoterm.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// btTrocarCor
			// 
			this.btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.btTrocarCor.Name = "btTrocarCor";
			this.btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.btTrocarCor.TabIndex = 30;
			this.m_ttIncoterm.SetToolTip(this.btTrocarCor, "Cor");
			this.btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_ttIncoterm
			// 
			this.m_ttIncoterm.AutomaticDelay = 100;
			this.m_ttIncoterm.AutoPopDelay = 5000;
			this.m_ttIncoterm.InitialDelay = 100;
			this.m_ttIncoterm.ReshowDelay = 20;
			// 
			// frmFIncoterm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 487);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFIncoterm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Incoterm";
			this.Load += new System.EventHandler(this.frmFIncoterm_Load);
			this.Activated += new System.EventHandler(this.frmFIncoterm_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbDespesas.ResumeLayout(false);
			this.m_gbModalidades.ResumeLayout(false);
			this.m_gbIncoterms.ResumeLayout(false);
			this.m_gbInformacoes.ResumeLayout(false);
			this.m_gbLocais.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		public void trocaCorDesconto()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		public void trocaCorDespesa()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Mostrar Cor
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				System.Drawing.Color clDesconto = System.Drawing.Color.LightBlue, clDespesas = System.Drawing.Color.White;
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				clDesconto = System.Drawing.Color.FromArgb((int)this.BackColor.R * 9 / 11, (int)this.BackColor.G, (int)this.BackColor.B * 9 / 11);
				clDespesas = System.Drawing.Color.FromArgb((int)this.BackColor.R * 7 / 11, (int)this.BackColor.G * 23 / 24, (int)this.BackColor.B * 7 / 11);
//				controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorIncotermDespesas", clDespesas);
//				clDespesas = controlPaletaDeCores.retornaCorAtual();
//				controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorIncotermDesconto", clDesconto);
//				clDesconto = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].Name != "m_gbInformacoes") && (this.Controls[cont].Controls[cont2].Name != "m_gbDespesas"))
						{
							if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
							{
								this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
							}
							for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
							{
								if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ListView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ComboBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox"))
								{
									this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
								}
							}
						}
						else if (this.Controls[cont].Controls[cont2].Name == "m_gbInformacoes")
						{
							if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
							{
								this.Controls[cont].Controls[cont2].BackColor = clDesconto;
							}
							for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
							{
								if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ListView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ComboBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox"))
								{
									this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = clDesconto;
								}
							}
						}
						else if (this.Controls[cont].Controls[cont2].Name == "m_gbDespesas")
						{
							if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
							{
								this.Controls[cont].Controls[cont2].BackColor = clDespesas;
							}
							for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
							{
								if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ListView") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.ComboBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox"))
								{
									this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = clDespesas;
								}
							}
						}
					}
				}
				OnCallSelecionaIncoterm();
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion

		#region Verifica Incoterm Selecionado
		private bool incotermSelecionado()
		{
			if (m_btCFR.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btCIF.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btCIP.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btCPT.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btDAF.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btDDP.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btDDU.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btDEQ.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btDES.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btEXW.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btFAS.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btFCA.BackColor == System.Drawing.Color.Green)
				return true;
			else if (m_btFOB.BackColor == System.Drawing.Color.Green)
				return true;
			
			return false;
		}
		#endregion

		#region Esconde Editores
		private void escondeEditores()
		{
			try
			{
				m_lFreteInterno.Visible = false;
				m_tbFreteInterno.Visible = false;
				m_lFreteInternacional.Visible = false;
				m_tbFreteInternacional.Visible = false;
				m_lSeguro.Visible = false;
				m_tbSeguro.Visible = false;
				//m_tbOutros.Visible = false;
				//m_tbTextoOutros.Visible = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Métodos Show Balão
		public void fechaBalao()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
			}
			catch
			{
			}
		}
		public void mostraBalao(string strMensagem, System.Windows.Forms.Control ctrlBalao)
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				if (m_bMostrarBaloes)
				{
					m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
					m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
					m_mgblBalaoToolTip.Content = strMensagem;
					m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
					m_mgblBalaoToolTip.CloseOnMouseClick = true;
					m_mgblBalaoToolTip.CloseOnDeactivate = false;
					m_mgblBalaoToolTip.CloseOnKeyPress = false;
					m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)ctrlBalao);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btTrocarCorDesconto_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCorDesconto();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btTrocarCorDespesa_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCorDespesa();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFIncoterm_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
				OnCallSelecionaIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (incotermSelecionado())
				{
					this.m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
				}
				else 
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlIncoterm_frmFIncoterm_IncotermNaoSelecionado));
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RBMaritimo
		private void m_rbMaritimo_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					escondeEditores();
					OnCallSelecionaMeioTransporte();
					fechaBalao();
					if (m_rbAereo.Checked || m_rbCorreio.Checked || m_rbFerroviario.Checked || m_rbMaritimo.Checked || m_rbRodoviario.Checked)
						if (!m_btCFR.Checked && !m_btCIF.Checked && !m_btCIP.Checked && !m_btCPT.Checked && !m_btDAF.Checked && !m_btDDP.Checked && !m_btDDU.Checked && !m_btDEQ.Checked && !m_btDES.Checked && !m_btEXW.Checked && !m_btFAS.Checked && !m_btFCA.Checked && !m_btFOB.Checked)
							mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm.ToString()), (System.Windows.Forms.Control)m_gbIncoterms);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RBAereo
		private void m_rbAereo_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					escondeEditores();
					OnCallSelecionaMeioTransporte();
					fechaBalao();
					if (m_rbAereo.Checked || m_rbCorreio.Checked || m_rbFerroviario.Checked || m_rbMaritimo.Checked || m_rbRodoviario.Checked)
						if (!m_btCFR.Checked && !m_btCIF.Checked && !m_btCIP.Checked && !m_btCPT.Checked && !m_btDAF.Checked && !m_btDDP.Checked && !m_btDDU.Checked && !m_btDEQ.Checked && !m_btDES.Checked && !m_btEXW.Checked && !m_btFAS.Checked && !m_btFCA.Checked && !m_btFOB.Checked)
							mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm.ToString()), (System.Windows.Forms.Control)m_gbIncoterms);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RBRodoviario
		private void m_rbRodoviario_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					escondeEditores();
					OnCallSelecionaMeioTransporte();
					fechaBalao();
					if (m_rbAereo.Checked || m_rbCorreio.Checked || m_rbFerroviario.Checked || m_rbMaritimo.Checked || m_rbRodoviario.Checked)
						if (!m_btCFR.Checked && !m_btCIF.Checked && !m_btCIP.Checked && !m_btCPT.Checked && !m_btDAF.Checked && !m_btDDP.Checked && !m_btDDU.Checked && !m_btDEQ.Checked && !m_btDES.Checked && !m_btEXW.Checked && !m_btFAS.Checked && !m_btFCA.Checked && !m_btFOB.Checked)
							mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm.ToString()), (System.Windows.Forms.Control)m_gbIncoterms);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RBFerroviario
		private void m_rbFerroviario_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					escondeEditores();
					OnCallSelecionaMeioTransporte();
					fechaBalao();
					if (m_rbAereo.Checked || m_rbCorreio.Checked || m_rbFerroviario.Checked || m_rbMaritimo.Checked || m_rbRodoviario.Checked)
						if (!m_btCFR.Checked && !m_btCIF.Checked && !m_btCIP.Checked && !m_btCPT.Checked && !m_btDAF.Checked && !m_btDDP.Checked && !m_btDDU.Checked && !m_btDEQ.Checked && !m_btDES.Checked && !m_btEXW.Checked && !m_btFAS.Checked && !m_btFCA.Checked && !m_btFOB.Checked)
							mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm.ToString()), (System.Windows.Forms.Control)m_gbIncoterms);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region RBCorreio
		private void m_rbCorreio_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					escondeEditores();
					OnCallSelecionaMeioTransporte();
					fechaBalao();
					if (m_rbAereo.Checked || m_rbCorreio.Checked || m_rbFerroviario.Checked || m_rbMaritimo.Checked || m_rbRodoviario.Checked)
						if (!m_btCFR.Checked && !m_btCIF.Checked && !m_btCIP.Checked && !m_btCPT.Checked && !m_btDAF.Checked && !m_btDDP.Checked && !m_btDDU.Checked && !m_btDEQ.Checked && !m_btDES.Checked && !m_btEXW.Checked && !m_btFAS.Checked && !m_btFCA.Checked && !m_btFOB.Checked)
							mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarIncoterm.ToString()), (System.Windows.Forms.Control)m_gbIncoterms);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Incoterms RB
		private void m_btEXW_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btEXW.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btFCA_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btFCA.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btFAS_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btFAS.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btFOB_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btFOB.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btCFR_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btCFR.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btCIF_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btCIF.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btCPT_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btCPT.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btCIP_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btCIP.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btDAF_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btDAF.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btDES_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btDES.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btDEQ_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btDEQ.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btDDU_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btDDU.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btDDP_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					if (!m_bAtivado)
					{
						m_bAtivado = true;
						if (m_btDDP.Checked)
						{
							OnCallSelecionaIncoterm();
							OnCallCarregaDadosInterface();
							fechaBalao();
						}
						m_bAtivado = false;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Leave Text Boxes
		private void m_tbFreteInterno_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					OnCallSalvaDadosInterfaceTextBoxes();
					OnCallCarregaDadosInterface();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_tbFreteInternacional_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					OnCallSalvaDadosInterfaceTextBoxes();
					OnCallCarregaDadosInterface();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_tbSeguro_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					OnCallSalvaDadosInterfaceTextBoxes();
					OnCallCarregaDadosInterface();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_tbTextoOutros_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					OnCallSalvaDadosInterfaceTextBoxes();
					OnCallCarregaDadosInterface();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_tbOutros_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
				{
					OnCallSalvaDadosInterfaceTextBoxes();
					OnCallCarregaDadosInterface();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion		
		#region Locais
		private void m_btLocais_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallSalvaDadosInterface();
				OnCallEditaLocais();
				OnCallCarregaDadosInterface();
				this.mostraCor();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region IncotermInfo
		private void m_btIDDP_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.DDP;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btIDDU_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.DDU;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btIDEQ_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.DEQ;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btIDES_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.DES;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btIDAF_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.DAF;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btICIP_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.CIP;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btICPT_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.CPT;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btICIF_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.CIF;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btICFR_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.CFR;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btIFOB_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.FOB;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btIFAS_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.FAS;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btIFCA_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.FCA;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void m_btIEXW_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_nIdInfoIncoterm = clsIncoterm.EXW;
				OnCallIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Frame Activated
		private void frmFIncoterm_Activated(object sender, System.EventArgs e)
		{
			m_btOk.Focus();
			if (m_bOnLoad)
			{
				m_bOnLoad = false;
				fechaBalao();
				if (!m_rbAereo.Checked && !m_rbCorreio.Checked && !m_rbFerroviario.Checked && !m_rbMaritimo.Checked && !m_rbRodoviario.Checked)
					mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlIncoterm_frmFIncoterm_SelecionarModalidade.ToString()), (System.Windows.Forms.Control)m_gbModalidades);
				clsIncoterm.m_bOnLoad = false;
			}
		}
		#endregion
		#region Desconto Valor Leave
		private void m_tbDesconto_Leave(object sender, System.EventArgs e)
		{
			if (!m_bAtivado && m_bDescontoAlterado)
			{
				m_bAtivado = true;
				try
				{
					OnCallAlteraDescontoValor();
					OnCallCarregaDadosInterface();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = false;
				m_bDescontoAlterado = false;
			}
		}
		#endregion
		#region Desconto Porcentagem Leave
		private void m_tbDescontoPorcentagem_Leave(object sender, System.EventArgs e)
		{
			if (!m_bAtivado && m_bDescontoAlterado)
			{
				m_bAtivado = true;
				try
				{
					OnCallAlteraDescontoPorcentagem();
					OnCallCarregaDadosInterface();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = false;
				m_bDescontoAlterado = false;
			}
		}
		#endregion
		#region Desconto Valor Text Changed
		private void m_tbDesconto_TextChanged(object sender, System.EventArgs e)
		{
			if (!m_bAtivado)
			{
				m_bDescontoAlterado = true;
			}
		}
		#endregion
		#region Desconto Porcentagem Text Changed
		private void m_tbDescontoPorcentagem_TextChanged(object sender, System.EventArgs e)
		{
			if (!m_bAtivado)
			{
				m_bDescontoAlterado = true;
			}
		}
		#endregion
		#region Ratear Desconto
		private void m_ckbxRatearDesconto_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
					OnCallCarregaDadosInterface();
				if (m_ckbxRatearDesconto.Checked)
				{
					m_lDesconto.Enabled = false;
					m_tbDescontoPorcentagem.Enabled = false;
					m_lbSimboloPorcentagem.Enabled = false;
					m_lOu.Enabled = false;
					m_tbDesconto.Enabled = false;
				}else{
					m_lDesconto.Enabled = true;
					m_tbDescontoPorcentagem.Enabled = true;
					m_lbSimboloPorcentagem.Enabled = true;
					m_lOu.Enabled = true;
					m_tbDesconto.Enabled = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ratear Despesas
		private void m_ckbxRatearDespesas_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bOnLoad == false)
					OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Locais Leave
		private void m_tbLocais_Leave(object sender, System.EventArgs e)
		{
			if (!m_bAtivado)
			{
				m_bAtivado = true;
				try
				{
					OnCallSalvaDadosInterfaceLocalIncoterm();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = false;
			}
		}
		#endregion
		#endregion
	}
}
