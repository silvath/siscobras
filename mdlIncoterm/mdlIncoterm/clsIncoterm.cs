using System;

namespace mdlIncoterm
{
	#region Enum
	public enum INCOTERMS 
	{
		EXW = 1,
		FCA = 2,
		FAS = 3,
		FOB = 4,
		CFR = 5,
		CIF = 6,
		CPT = 7,
		CIP = 8,
		DAF = 9,
		DES = 10,
		DEQ = 11,
		DDU = 12,
		DDP = 13 };
	#endregion
	/// <summary>
	/// Summary description for clsIncoterm.
	/// </summary>
	public abstract class clsIncoterm
	{
		#region Constantes
			protected int MAXDECIMALS = 8;
		#endregion
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = "";
		protected mdlLocais.clsLocais m_clsLocais = null;

		internal static bool m_bOnLoad = true;

		protected bool m_bMostrarBaloes = true;

		protected bool m_bMostrarLocais = false;

		protected int m_nIdExportador = -1;
		protected int m_nIdIncoterm = -2;
		protected int m_nIdMeioTransporte = -1;
        protected int m_nIdMoeda = -1;
		protected string m_strSimboloMoeda = "";
		protected double m_nValorTotalProdutos = 0;
		protected double m_nFreteInterno = 0;
		protected double m_nFreteInternacional = 0;
		protected double m_nSeguro = 0;
        protected string m_strOutros = "Outros";
        protected double m_nOutros = 0;
		protected double m_nValorTotal = 0;
		protected double m_dDescontoValor = 0;
		protected double m_dDescontoPorcentagem = 0;
		protected bool m_bRatearDespesas = false;
		protected bool m_bRatearDesconto = false;
		private double m_dSubTotal = 0;
		private double m_dSubTotalCDesconto = 0;
		private double m_dTotal = 0;

		protected const int m_nIdTextoOutrosCustos = 30;
		protected int m_nIdIdioma = 3;

		private int m_nIdInfoIncoterm = -1;

		protected string m_strRetorno = "";

		protected bool m_bLocaisHabilitado = true;
        
		internal const int AEREO = 1;
		internal const int MARITIMO = 2;
		internal const int RODOVIARIO = 3;
		internal const int FERROVIARIO = 4;
		internal const int CORREIO = 5;

		internal const int EXW = 1;
		internal const int FCA = 2;
		internal const int FAS = 3;
		internal const int FOB = 4;
		internal const int CFR = 5;
		internal const int CIF = 6;
		internal const int CPT = 7;
		internal const int CIP = 8;
		internal const int DAF = 9;
		internal const int DES = 10;
		internal const int DEQ = 11;
		internal const int DDU = 12;
		internal const int DDP = 13;

		public bool m_bModificado = false;

		private frmFIncoterm m_formFIncoterm = null;
		private frmFIncotermInfo m_formFIncotermInfo = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbMoedas m_typDatSetTbMoedas = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos m_typDatSetTbIdiomasTextos = null;
		#endregion
		#region Propriedades
		public string MeioTransporte
		{
			get
			{
				return(retornaMeioTransporte());
			}
		}
		
		public double SubTotal
		{
			get
			{
				return(m_nValorTotalProdutos); 
			}
		}
		
		public double Desconto
		{
			get
			{
				return(m_dDescontoValor);
			}
		}

		public bool RatearDesconto
		{
			get
			{
				return(m_bRatearDesconto);
			}
		}

		public double SubTotalCDesconto
		{
			get
			{
				return(m_dSubTotalCDesconto);
			}
		}
			
		public double FreteInterno
		{
			get
			{
				return(m_nFreteInterno);
			}
		}

		public double FreteInternacional
		{
			get
			{
				return(m_nFreteInternacional);
			}
		}
		
		public double Seguro
		{
			get
			{
				return(m_nSeguro);
			}
		}
		
		public string TextoOutros
		{
			get
			{
				return(m_strOutros);
			}
		}
		
		public double Outros
		{
			get
			{
				return(m_nOutros);
			}
		}
		
		public double Total
		{
			get
			{
				return(m_dTotal);
			}
		}

		public bool Ratear
		{
			get
			{
				return(m_bRatearDespesas);
			}
		}
		
		public string Incoterm
		{
			get
			{
				return(m_strRetorno);
			}
		}
		#endregion
		#region Construtores & Destrutores
		public clsIncoterm(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador)
		{
			//
			// TODO: Add constructor logic here
			//
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region InitialiazeEventsFormIncoterm
		private void InitialiazeEventsFormIncoterm()
		{
			// Carrega Dados BD
			m_formFIncoterm.eCallCarregaDadosBD += new frmFIncoterm.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFIncoterm.eCallCarregaDadosInterface += new frmFIncoterm.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFIncoterm.eCallSalvaDadosInterface += new frmFIncoterm.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados Interface TextBoxes
			m_formFIncoterm.eCallSalvaDadosInterfaceTextBoxes += new frmFIncoterm.delCallSalvaDadosInterfaceTextBoxes(salvaDadosTextBoxes);

			// Salva Dados Interface Local Incoterm
			m_formFIncoterm.eCallSalvaDadosInterfaceLocalIncoterm += new frmFIncoterm.delCallSalvaDadosInterfaceLocalIncoterm(salvaDadosLocalIncoterm);

			// Salva Dados BD
			m_formFIncoterm.eCallSalvaDadosBD += new frmFIncoterm.delCallSalvaDadosBD(salvaDadosBD);

			// Seleciona Incoterm
			m_formFIncoterm.eCallSelecionaIncoterm += new frmFIncoterm.delCallSelecionaIncoterm(selecionaIncoterms);

			// Incoterms
			m_formFIncoterm.eCallHabilitaIncoterms += new frmFIncoterm.delCallHabilitaIncoterms(habilitaIncoterms);

			// Meios de Transporte
			m_formFIncoterm.eCallSelecionaMeioTransporte += new frmFIncoterm.delCallSelecionaMeioTransporte(selecionaMeioTransporte);

			// Incoterm Info
			m_formFIncoterm.eCallIncotermInfo += new frmFIncoterm.delCallIncotermInfo(cliqueInformacoes);

			// Clique Locais
			m_formFIncoterm.eCallEditaLocais += new frmFIncoterm.delCallEditaLocais(cliqueLocais);

			// Desconto Valor
			m_formFIncoterm.eCallAlteraDescontoValor += new frmFIncoterm.delCallAlteraDescontoValor(salvaDadosDescontoValor);

			// Desconto Porcentagem
			m_formFIncoterm.eCallAlteraDescontoPorcentagem += new frmFIncoterm.delCallAlteraDescontoPorcentagem(salvaDadosDescontoPorcentagem);
		}
		#endregion

		#region Show Dialog
		public void ShowDialog()
		{
			try
			{
				m_bOnLoad = true;
				m_formFIncoterm = new frmFIncoterm(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMostrarBaloes);
				InitialiazeEventsFormIncoterm();
				m_formFIncoterm.ShowDialog();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Show Locais Dialog
		protected void ShowLocaisDialog()
		{
			try
			{
				m_clsLocais.ShowDialog();
				atualizaTypDatSetEspecifico();
				retornaIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void retornaInstanciaMdlLocais();
		#endregion

		#region InitialiazeEventsFormIncotermInfo
		private void InitialiazeEventsFormIncotermInfo()
		{
			// Carrega Dados Interface
			m_formFIncotermInfo.eCallCarregaDadosInterface += new frmFIncotermInfo.delCallCarregaDadosInterface(carregaDadosInterfaceIncotermInfo);
		}
		#endregion

		#region Show Dialog Incoterm Info
		private void ShowDialogIncotermInfo()
		{
			try
			{
				m_formFIncotermInfo = new frmFIncotermInfo(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_formFIncoterm);
				InitialiazeEventsFormIncotermInfo();
				m_formFIncotermInfo.ShowDialog();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Habilita / Desabilita Incoterms
		#region RBMeioTransporte
		private void selecionaMeioTransporte(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO)
		{
			try
			{
				if (rbAEREO.Checked)
					m_nIdMeioTransporte = AEREO;
				else if (rbMARITIMO.Checked)
					m_nIdMeioTransporte = MARITIMO;
				else if (rbRODOVIARIO.Checked)
					m_nIdMeioTransporte = RODOVIARIO;
				else if (rbFERROVIARIO.Checked)
					m_nIdMeioTransporte = FERROVIARIO;
				else if (rbCORREIO.Checked)
					m_nIdMeioTransporte = CORREIO;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Habilita Incoterms
		private void habilitaIncoterms(ref System.Windows.Forms.RadioButton btCIP, ref System.Windows.Forms.RadioButton btEXW, ref System.Windows.Forms.RadioButton btFOB, ref System.Windows.Forms.RadioButton btFAS, ref System.Windows.Forms.RadioButton btDDP, ref System.Windows.Forms.RadioButton btDDU, ref System.Windows.Forms.RadioButton btDEQ, ref System.Windows.Forms.RadioButton btDES, ref System.Windows.Forms.RadioButton btDAF, ref System.Windows.Forms.RadioButton btFCA, ref System.Windows.Forms.RadioButton btCPT, ref System.Windows.Forms.RadioButton btCIF, ref System.Windows.Forms.RadioButton btCFR)
		{
			try
			{
				btEXW.Checked = false;
				btFCA.Checked = false;
				btFAS.Checked = false;
				btFOB.Checked = false;
				btCFR.Checked = false;
				btCIF.Checked = false;
				btCPT.Checked = false;
				btCIP.Checked = false;
				btDAF.Checked = false;
				btDES.Checked = false;
				btDEQ.Checked = false;
				btDDU.Checked = false;
				btDDP.Checked = false;
				switch(m_nIdMeioTransporte)
				{
					case AEREO:
						btEXW.Enabled = true;
						btFCA.Enabled = true;
						btFAS.Enabled = false;
						btFOB.Enabled = false;
						btCFR.Enabled = false;
						btCIF.Enabled = false;
						btCPT.Enabled = true;
						btCIP.Enabled = true;
						btDAF.Enabled = false;
						btDES.Enabled = false;
						btDEQ.Enabled = false;
						btDDU.Enabled = true;
						btDDP.Enabled = true;

						btEXW.BackColor = System.Drawing.Color.Yellow;
						btFCA.BackColor = System.Drawing.Color.Yellow;
						btFAS.BackColor = System.Drawing.Color.Red;
						btFOB.BackColor = System.Drawing.Color.Red;
						btCFR.BackColor = System.Drawing.Color.Red;
						btCIF.BackColor = System.Drawing.Color.Red;
						btCPT.BackColor = System.Drawing.Color.Yellow;
						btCIP.BackColor = System.Drawing.Color.Yellow;
						btDAF.BackColor = System.Drawing.Color.Red;
						btDES.BackColor = System.Drawing.Color.Red;
						btDEQ.BackColor = System.Drawing.Color.Red;
						btDDU.BackColor = System.Drawing.Color.Yellow;
						btDDP.BackColor = System.Drawing.Color.Yellow;
					break;

					case MARITIMO:
						btEXW.Enabled = true;
						btFCA.Enabled = false;
						btFAS.Enabled = true;
						btFOB.Enabled = true;
						btCFR.Enabled = true;
						btCIF.Enabled = true;
						btCPT.Enabled = false;
						btCIP.Enabled = false;
						btDAF.Enabled = false;
						btDES.Enabled = true;
						btDEQ.Enabled = true;
						btDDU.Enabled = true;
						btDDP.Enabled = true;

						btEXW.BackColor = System.Drawing.Color.Yellow;
						btFCA.BackColor = System.Drawing.Color.Red;
						btFAS.BackColor = System.Drawing.Color.Yellow;
						btFOB.BackColor = System.Drawing.Color.Yellow;
						btCFR.BackColor = System.Drawing.Color.Yellow;
						btCIF.BackColor = System.Drawing.Color.Yellow;
						btCPT.BackColor = System.Drawing.Color.Red;
						btCIP.BackColor = System.Drawing.Color.Red;
						btDAF.BackColor = System.Drawing.Color.Red;
						btDES.BackColor = System.Drawing.Color.Yellow;
						btDEQ.BackColor = System.Drawing.Color.Yellow;
						btDDU.BackColor = System.Drawing.Color.Yellow;
						btDDP.BackColor = System.Drawing.Color.Yellow;
					break;

					case RODOVIARIO:
					case FERROVIARIO:
					case CORREIO:
						btEXW.Enabled = true;
						btFCA.Enabled = true;
						btFAS.Enabled = false;
						btFOB.Enabled = false;
						btCFR.Enabled = false;
						btCIF.Enabled = false;
						btCPT.Enabled = true;
						btCIP.Enabled = true;
						btDAF.Enabled = true;
						btDES.Enabled = false;
						btDEQ.Enabled = false;
						btDDU.Enabled = true;
						btDDP.Enabled = true;

						btEXW.BackColor = System.Drawing.Color.Yellow;
						btFCA.BackColor = System.Drawing.Color.Yellow;
						btFAS.BackColor = System.Drawing.Color.Red;
						btFOB.BackColor = System.Drawing.Color.Red;
						btCFR.BackColor = System.Drawing.Color.Red;
						btCIF.BackColor = System.Drawing.Color.Red;
						btCPT.BackColor = System.Drawing.Color.Yellow;
						btCIP.BackColor = System.Drawing.Color.Yellow;
						btDAF.BackColor = System.Drawing.Color.Yellow;
						btDES.BackColor = System.Drawing.Color.Red;
						btDEQ.BackColor = System.Drawing.Color.Red;
						btDDU.BackColor = System.Drawing.Color.Yellow;
						btDDP.BackColor = System.Drawing.Color.Yellow;
					break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Seleciona Incoterms
		private void verificaSelecionado(ref System.Windows.Forms.RadioButton btCIP, ref System.Windows.Forms.RadioButton btEXW, ref System.Windows.Forms.RadioButton btFOB, ref System.Windows.Forms.RadioButton btFAS, ref System.Windows.Forms.RadioButton btDDP, ref System.Windows.Forms.RadioButton btDDU, ref System.Windows.Forms.RadioButton btDEQ, ref System.Windows.Forms.RadioButton btDES, ref System.Windows.Forms.RadioButton btDAF, ref System.Windows.Forms.RadioButton btFCA, ref System.Windows.Forms.RadioButton btCPT, ref System.Windows.Forms.RadioButton btCIF, ref System.Windows.Forms.RadioButton btCFR)
		{
			if (btCIP.Checked)
				m_nIdIncoterm = CIP;
			else if (btEXW.Checked)
				m_nIdIncoterm = EXW;
			else if (btFOB.Checked)
				m_nIdIncoterm = FOB;
			else if (btFAS.Checked)
				m_nIdIncoterm = FAS;
			else if (btDDP.Checked)
				m_nIdIncoterm = DDP;
			else if (btDDU.Checked)
				m_nIdIncoterm = DDU;
			else if (btDEQ.Checked)
				m_nIdIncoterm = DEQ;
			else if (btDES.Checked)
				m_nIdIncoterm = DES;
			else if (btDAF.Checked)
				m_nIdIncoterm = DAF;
			else if (btFCA.Checked)
				m_nIdIncoterm = FCA;
			else if (btCPT.Checked)
				m_nIdIncoterm = CPT;
			else if (btCIF.Checked)
				m_nIdIncoterm = CIF;
			else if (btCFR.Checked)
				m_nIdIncoterm = CFR;
		}
		private void selecionaIncoterms(ref System.Windows.Forms.RadioButton btCIP, ref System.Windows.Forms.RadioButton btEXW, ref System.Windows.Forms.RadioButton btFOB, ref System.Windows.Forms.RadioButton btFAS, ref System.Windows.Forms.RadioButton btDDP, ref System.Windows.Forms.RadioButton btDDU, ref System.Windows.Forms.RadioButton btDEQ, ref System.Windows.Forms.RadioButton btDES, ref System.Windows.Forms.RadioButton btDAF, ref System.Windows.Forms.RadioButton btFCA, ref System.Windows.Forms.RadioButton btCPT, ref System.Windows.Forms.RadioButton btCIF, ref System.Windows.Forms.RadioButton btCFR, ref System.Windows.Forms.Label lFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref System.Windows.Forms.Label lFreteInternacional, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref System.Windows.Forms.Label lSeguro, ref mdlComponentesGraficos.TextBox tbSeguro/*, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros*/)
		{
			try
			{
				verificaSelecionado(ref btCIP, ref btEXW, ref btFOB, ref btFAS, ref btDDP, ref btDDU, ref btDEQ, ref btDES, ref btDAF, ref btFCA, ref btCPT, ref btCIF, ref btCFR);
				habilitaIncoterms(ref btCIP, ref btEXW, ref btFOB, ref btFAS, ref btDDP, ref btDDU, ref btDEQ, ref btDES, ref btDAF, ref btFCA, ref btCPT, ref btCIF, ref btCFR);
				switch(m_nIdIncoterm)
				{
					case EXW:
						btEXW.BackColor = System.Drawing.Color.Green;
						btEXW.Checked = true;
						lFreteInterno.Visible = false;
						tbFreteInterno.Visible = false;
						lFreteInternacional.Visible = false;
						tbFreteInternacional.Visible = false;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case FCA:
						btFCA.BackColor = System.Drawing.Color.Green;
						btFCA.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = false;
						tbFreteInternacional.Visible = false;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case FAS:
						btFAS.BackColor = System.Drawing.Color.Green;
						btFAS.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = false;
						tbFreteInternacional.Visible = false;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case FOB:
						btFOB.BackColor = System.Drawing.Color.Green;
						btFOB.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = false;
						tbFreteInternacional.Visible = false;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case CFR:
						btCFR.BackColor = System.Drawing.Color.Green;
						btCFR.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case CIF:
						btCIF.BackColor = System.Drawing.Color.Green;
						btCIF.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case CPT:
						btCPT.BackColor = System.Drawing.Color.Green;
						btCPT.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = false;
						tbSeguro.Visible = false;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case CIP:
						btCIP.BackColor = System.Drawing.Color.Green;
						btCIP.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = false;
						//tbTextoOutros.Visible = false;
						break;
					case DAF:
						btDAF.BackColor = System.Drawing.Color.Green;
						btDAF.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = true;
						//tbTextoOutros.Visible = true;
						break;
					case DES:
						btDES.BackColor = System.Drawing.Color.Green;
						btDES.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = true;
						//tbTextoOutros.Visible = true;
						break;
					case DEQ:
						btDEQ.BackColor = System.Drawing.Color.Green;
						btDEQ.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = true;
						//tbTextoOutros.Visible = true;
						break;
					case DDU:
						btDDU.BackColor = System.Drawing.Color.Green;
						btDDU.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = true;
						//tbTextoOutros.Visible = true;
						break;
					case DDP:
						btDDP.BackColor = System.Drawing.Color.Green;
						btDDP.Checked = true;
						lFreteInterno.Visible = true;
						tbFreteInterno.Visible = true;
						lFreteInternacional.Visible = true;
						tbFreteInternacional.Visible = true;
						lSeguro.Visible = true;
						tbSeguro.Visible = true;
						//tbOutros.Visible = true;
						//tbTextoOutros.Visible = true;
						break;
				}
				if (!m_bOnLoad)
					retornaIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
			
				arlOrdenacaoCampo.Add("idMoeda");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				arlCondicaoCampo.Add("idTexto");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdTextoOutrosCustos);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbIdiomasTextos = m_cls_dba_ConnectionDB.GetTbIdiomasTextos(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecifico();
				calculaSutTotalETotal();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecifico();
		private void calculaSutTotalETotal()
		{
			double dTotal = 0, dDespesas = 0;
			dDespesas += m_nFreteInterno;
			dDespesas += m_nFreteInternacional;
			dDespesas += m_nSeguro;
			dDespesas += m_nOutros;
			if (m_bRatearDespesas)
			{
				dTotal = m_nValorTotalProdutos;
				m_dSubTotal = m_nValorTotalProdutos - dDespesas;
			}
			else
			{
				dTotal = m_nValorTotalProdutos + dDespesas;
				m_dSubTotal = m_nValorTotalProdutos;
			}
			m_dTotal = dTotal - m_dDescontoValor;
			m_dSubTotalCDesconto = m_dSubTotal - m_dDescontoValor;
		}
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref System.Windows.Forms.Label lDesconto, ref System.Windows.Forms.Label lDescontoMoeda, ref mdlComponentesGraficos.TextBox tbDesconto, ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem, ref System.Windows.Forms.CheckBox ckbxRatearDesconto, ref System.Windows.Forms.CheckBox ckbxRatearDespesas, ref System.Windows.Forms.Label lTotal, ref System.Windows.Forms.Label lTotalProdutos, ref System.Windows.Forms.Label lTotalProdutosCDesconto, ref mdlComponentesGraficos.TextBox tbLocais, ref System.Windows.Forms.Button btLocais, bool bOnLoad)
		{
			double dDespesas = 0;
			try
			{
				carregaDadosInterfaceMeioTransporte(ref rbAEREO, ref rbMARITIMO, ref rbRODOVIARIO, ref rbFERROVIARIO, ref rbCORREIO);
				if (bOnLoad == false)
				{
					m_bRatearDespesas = ckbxRatearDespesas.Checked;
					m_bRatearDesconto = ckbxRatearDesconto.Checked;
				}
				else
				{
					ckbxRatearDespesas.Checked = m_bRatearDespesas;
					ckbxRatearDesconto.Checked = m_bRatearDesconto;
				}
				#region Preenchendo TextBoxes
				tbFreteInterno.Text = m_nFreteInterno.ToString("F");
				tbFreteInternacional.Text = m_nFreteInternacional.ToString("F");
				tbSeguro.Text = m_nSeguro.ToString("F");
				tbOutros.Text = m_nOutros.ToString("F");
				if (m_strOutros.Trim() != "")
					tbTextoOutros.Text = m_strOutros;
				else
					tbTextoOutros.Text = m_strOutros = "Outros";
				tbDesconto.Text = m_dDescontoValor.ToString("F");
				tbDescontoPorcentagem.Text = m_dDescontoPorcentagem.ToString("F");
				#endregion
				#region Calculando Despesas
				if (tbFreteInterno.Visible)
					if (tbFreteInterno.Text.Trim() != "")
						dDespesas += Double.Parse(tbFreteInterno.Text);
				if (tbFreteInternacional.Visible)
					if (tbFreteInternacional.Text.Trim() != "")
						dDespesas += Double.Parse(tbFreteInternacional.Text);
				if (tbSeguro.Visible)
					if (tbSeguro.Text.Trim() != "")
						dDespesas += Double.Parse(tbSeguro.Text);
				if (tbOutros.Visible)
					if (tbOutros.Text.Trim() != "")
						dDespesas += Double.Parse(tbOutros.Text);
				#endregion
				#region Mostrando Cálculo
				double dTotal = 0;
				m_dSubTotalCDesconto = m_nValorTotalProdutos - m_dDescontoValor;
				if (m_bRatearDespesas == false)
				{
					dTotal = m_dSubTotalCDesconto + dDespesas;
					if (m_bRatearDesconto)
					{
						lTotalProdutos.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, (m_nValorTotalProdutos - m_dDescontoValor), true);
						//lTotalProdutos.Text = m_strSimboloMoeda + " " + (m_nValorTotalProdutos - m_dDescontoValor).ToString("F");
						m_dSubTotal = m_nValorTotalProdutos - m_dDescontoValor;
					}
					else
					{
						lTotalProdutos.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_nValorTotalProdutos, true);
						//lTotalProdutos.Text = m_strSimboloMoeda + " " + m_nValorTotalProdutos.ToString("F");
						m_dSubTotal = m_nValorTotalProdutos;
					}
					m_dTotal = dTotal;
					lTotal.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_dTotal, true);
					//lTotal.Text = m_strSimboloMoeda + " " + m_dTotal.ToString("F");
				}
				else if (m_bRatearDespesas)
				{
					m_dSubTotalCDesconto -= dDespesas;
					if (m_bRatearDesconto)
					{
						lTotalProdutos.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, (m_nValorTotalProdutos - dDespesas - m_dDescontoValor), true);
						//lTotalProdutos.Text = m_strSimboloMoeda + " " + (m_nValorTotalProdutos - dDespesas - m_dDescontoValor).ToString("F");
						m_dSubTotal = m_nValorTotalProdutos - dDespesas - m_dDescontoValor;
					}
					else
					{
						lTotalProdutos.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, (m_nValorTotalProdutos - dDespesas), true);
						//lTotalProdutos.Text = m_strSimboloMoeda + " " + (m_nValorTotalProdutos - dDespesas).ToString("F");
						m_dSubTotal = m_nValorTotalProdutos - dDespesas;
					}
					m_dTotal = m_dSubTotalCDesconto + dDespesas;
					//lTotal.Text = m_strSimboloMoeda + " " + m_dTotal.ToString("F");
					lTotal.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_dTotal, true);
				}
				//lTotalProdutosCDesconto.Text = m_strSimboloMoeda + " " + m_dSubTotalCDesconto.ToString("F");
				lTotalProdutosCDesconto.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_dSubTotalCDesconto, true);
				#endregion
				tbLocais.Text = m_strRetorno;
				btLocais.Enabled = m_bLocaisHabilitado;
				tbLocais.Enabled = m_bLocaisHabilitado; // Testando em 27/10/2003 às 16:00
				lDesconto.Text = "Desconto:  "/* + m_strSimboloMoeda*/;
				lDescontoMoeda.Text = m_strSimboloMoeda;

			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosInterfaceMeioTransporte(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO)
		{
			try
			{
				switch (m_nIdMeioTransporte)
				{
					case AEREO:			rbAEREO.Checked = true;
										break;
					case MARITIMO:		rbMARITIMO.Checked = true;
										break;
					case RODOVIARIO:	rbRODOVIARIO.Checked = true;
										break;
					case FERROVIARIO:	rbFERROVIARIO.Checked = true;
										break;
					case CORREIO:		rbCORREIO.Checked = true;
										break;
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
		#region Salvamento de Dados
		#region Interface
		protected void salvaDadosInterface(ref System.Windows.Forms.RadioButton rbAEREO, ref System.Windows.Forms.RadioButton rbMARITIMO, ref System.Windows.Forms.RadioButton rbRODOVIARIO, ref System.Windows.Forms.RadioButton rbFERROVIARIO, ref System.Windows.Forms.RadioButton rbCORREIO, ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref System.Windows.Forms.CheckBox ckbxRatearDesconto, ref System.Windows.Forms.CheckBox ckbxRatearDespesas, ref System.Windows.Forms.Label lTotal, ref System.Windows.Forms.Label lTotalProdutos, ref mdlComponentesGraficos.TextBox tbIncoterm)
		{
			try
			{
				if (rbAEREO.Checked)
					m_nIdMeioTransporte = AEREO;
				else if (rbMARITIMO.Checked)
					m_nIdMeioTransporte = MARITIMO;
				else if (rbRODOVIARIO.Checked)
					m_nIdMeioTransporte = RODOVIARIO;
				else if (rbFERROVIARIO.Checked)
					m_nIdMeioTransporte = FERROVIARIO;
				else if (rbCORREIO.Checked)
					m_nIdMeioTransporte = CORREIO;
				salvaDadosTextBoxes(ref tbFreteInterno, ref tbFreteInternacional, ref tbSeguro, ref tbOutros, ref tbTextoOutros, ref tbIncoterm);
				salvaDadosInterfaceEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void salvaDadosTextBoxes(ref mdlComponentesGraficos.TextBox tbFreteInterno, ref mdlComponentesGraficos.TextBox tbFreteInternacional, ref mdlComponentesGraficos.TextBox tbSeguro, ref mdlComponentesGraficos.TextBox tbOutros, ref mdlComponentesGraficos.TextBox tbTextoOutros, ref mdlComponentesGraficos.TextBox tbIncoterm)
		{
			try
			{
				try
				{
					if (tbFreteInterno.Visible == true)
						m_nFreteInterno = Double.Parse(tbFreteInterno.Text);
					else
						m_nFreteInterno = 0;
				}
				catch
				{
					m_nFreteInterno = 0;
				}
				try
				{
					if (tbFreteInternacional.Visible == true)
						m_nFreteInternacional = Double.Parse(tbFreteInternacional.Text);
					else
						m_nFreteInternacional = 0;
				}
				catch
				{
					m_nFreteInternacional = 0;
				}
				try
				{
					if (tbSeguro.Visible == true)
						m_nSeguro = Double.Parse(tbSeguro.Text);
					else
						m_nSeguro = 0;
				}
				catch
				{
					m_nSeguro = 0;
				}
				try
				{
					if (tbOutros.Visible == true)
						m_nOutros = Double.Parse(tbOutros.Text);
					else
						m_nOutros = 0;
				}
				catch
				{
					m_nOutros = 0;
				}
				try
				{
					if (tbTextoOutros.Visible == true)
						m_strOutros = tbTextoOutros.Text;
					else
						m_strOutros = "";
				}
				catch
				{
					m_strOutros = "";
				}
				if (tbIncoterm.Text.Trim() != "")
					m_strRetorno = tbIncoterm.Text;
				else
					retornaIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void salvaDadosDescontoValor(ref mdlComponentesGraficos.TextBox tbDesconto, ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem)
		{
			try
			{
				if (tbDesconto.Text.Trim() != "")
				{
					try
					{
						m_dDescontoValor = Double.Parse(tbDesconto.Text);
					}
					catch
					{
						m_dDescontoValor = 0;
					}
					tbDesconto.Text = m_dDescontoValor.ToString("F");
					m_dDescontoPorcentagem = ((m_dDescontoValor / m_dSubTotal) * 100);
					tbDescontoPorcentagem.Text = m_dDescontoPorcentagem.ToString("F");
				}
				else
				{
					m_dDescontoValor = 0;
					m_dDescontoPorcentagem = 0;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void salvaDadosDescontoPorcentagem(ref mdlComponentesGraficos.TextBox tbDescontoPorcentagem, ref mdlComponentesGraficos.TextBox tbDesconto)
		{
			try
			{
				if (tbDescontoPorcentagem.Text.Trim() != "")
				{
					try
					{
						m_dDescontoPorcentagem = Double.Parse(tbDescontoPorcentagem.Text);
					}
					catch
					{
						m_dDescontoPorcentagem = 0;
					}
					tbDescontoPorcentagem.Text = m_dDescontoPorcentagem.ToString("F");
					m_dDescontoValor = ((m_dDescontoPorcentagem / 100) * m_dSubTotal);
					m_dDescontoValor = double.Parse(m_dDescontoValor.ToString("F"));
					tbDesconto.Text = m_dDescontoValor.ToString("F");
				}
				else
				{
					m_dDescontoValor = 0;
					m_dDescontoPorcentagem = 0;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void salvaDadosLocalIncoterm(ref mdlComponentesGraficos.TextBox tbIncoterm)
		{
			try
			{
				m_strRetorno = tbIncoterm.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosInterfaceEspecifico();
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			try
			{
//				if ((m_bMostrarLocais) && (m_strRetorno.IndexOf("-") == (m_strRetorno.Length - 2)))
//				{
//					criaLocaisEspecifico();
//					ShowLocaisDialog();
//					retornaIncoterm();
//				}
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		#endregion
		#endregion

		#region Click Incoterm Info
		private void cliqueInformacoes(int idIncoterm)
		{
			try
			{
				m_nIdInfoIncoterm = idIncoterm;
				ShowDialogIncotermInfo();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Click Locais
		private void cliqueLocais()
		{
			try
			{
				criaLocaisEspecifico();
				ShowLocaisDialog();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void criaLocaisEspecifico();
		#endregion

		#region atualizaTypDatSet
		protected abstract void atualizaTypDatSetEspecifico();
		#endregion

		#region Carrega Dados Interface Incoterm Info
		private void carregaDadosInterfaceIncotermInfo(ref System.Windows.Forms.RichTextBox rtbIncotermInfo, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				string strIncoterm = "", strDescricao = "", strObrigacoes = "", strModalidade = "", strObservacoes = "", strGroupBoxTitle = "";;
				#region SWITCH
				switch (m_nIdInfoIncoterm)
				{
					case EXW:	strIncoterm = "Ex Works:";
								strDescricao = "No Depósito";
								strObrigacoes = "Disponibilizar a mercadoria no depósito do exportador.";
								strModalidade = "Todas";
								strGroupBoxTitle = "EXW";
                    break;
					case FAS:	strIncoterm = "Free Alongside Ship:";
								strDescricao = "Livre no Costado do Navio.";
								strObrigacoes = "Entregar a mercadoria não desembaraçada no porto de origem.";
								strModalidade = "Marítimo";
								strObservacoes = "Raramente usado";
								strGroupBoxTitle = "FAS";
					break;
					case FOB:	strIncoterm = "Free on Board:";
								strDescricao = "Livre a Bordo, no porto de embarque.";
								strObrigacoes = "Entregar a mercadoria desembaraçada, a bordo do navio, no porto de origem.";
								strModalidade = "Marítimo";
								strGroupBoxTitle = "FOB";
					break;
					case FCA:	strIncoterm = "Free Carrier:";
								strDescricao = "Sem transportador/frete.";
								strObrigacoes = "Entregar a mercadoria em lugar designado, ainda no país exportador.";
								strModalidade = "Qualquer modalidade: multimodal.";
								strObservacoes = "Muito comum no transporte aéreo.";
								strGroupBoxTitle = "FCA";
					break;
					case CFR:	strIncoterm = "Cost and Freight:";
								strDescricao = "Custo e Frete.";
								strObrigacoes = "Entregar a mercadoria no porto de destino.";
								strModalidade = "Marítimo";
								strGroupBoxTitle = "CFR";
					break;
					case CIF:	strIncoterm = "Cost, Insurance and Freight:";
								strDescricao = "Custo, Seguro e Frete.";
								strObrigacoes = "Entregar a mercadoria segurada no porto de destino.";
								strModalidade = "Marítimo";
								strGroupBoxTitle = "CIF";
					break;
					case CPT:	strIncoterm = "Carriage Paid To:";
								strDescricao = "Transporte pago Até o local de destino.";
								strObrigacoes = "Entregar a mercadoria no local de destino.";
								strModalidade = "Qualquer modalidade: multimodal.";
								strObservacoes = "Mais comum no transporte aéreo ou rodoviário.";
								strGroupBoxTitle = "CPT";
					break;
					case CIP:	strIncoterm = "Carriage and insurance Paid To:";
								strDescricao = "Transporte e Seguro pago Até o local de destino.";
								strObrigacoes = "Entregar a mercadoria segurada no local de destino.";
								strModalidade = "Qualquer modalidade: multimodal.";
								strGroupBoxTitle = "CIP";
					break;
					case DES:	strIncoterm = "Delivered Ex-Ship:";
								strDescricao = "Entregue a Bordo do Navio.";
								strObrigacoes = "Entregar a mercadoria à bordo do navio, no porto de destino.";
								strModalidade = "Marítimo";
								strObservacoes = "Semelhante ao CIF. Raramente usado.";
								strGroupBoxTitle = "DES";
					break;
					case DEQ:	strIncoterm = "Delivered Ex-Quay:";
								strDescricao = "Entregue a partir do Cais.";
								strObrigacoes = "Entregar a mercadoria no porto de destino, segurada e desembaraçada para a importação.";
								strModalidade = "Marítimo";
								strObservacoes = "Raramente usado";
								strGroupBoxTitle = "DEQ";
					break;
					case DAF:	strIncoterm = "Delivered at Frontier:";
								strDescricao = "Entregue na Fronteira.";
								strObrigacoes = "Entregar a mercadoria em ponto de fronteira.";
								strModalidade = "Terrestre";
								strGroupBoxTitle = "DAF";
					break;
					case DDU:	strIncoterm = "Delivered Duty Unpaid:";
								strDescricao = "Entregue, Direitos Não Pagos.";
								strObrigacoes = "Entregar a mercadoria no local de destino, pagar todos os custos, exceto direitos aduaneiros.";
								strModalidade = "Todas";
								strGroupBoxTitle = "DDU";
					break;
					case DDP:	strIncoterm = "Delivered Duty paid:";
								strDescricao = "Entregue, Direitos Pagos.";
								strObrigacoes = "Absolutamente todas";
								strModalidade = "Todas";
								strGroupBoxTitle = "DDP";
					break;
				}
				#endregion
				#region Cria Variáveis ListViewItem
				// Limpa os Items da List View
				rtbIncotermInfo.Clear();
				#endregion
				#region Adiciona Texto Informações
				rtbIncotermInfo.Font = new System.Drawing.Font(rtbIncotermInfo.Font, System.Drawing.FontStyle.Bold);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Red;
				rtbIncotermInfo.AppendText(strIncoterm);
				rtbIncotermInfo.AppendText(System.Environment.NewLine);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Black;
				rtbIncotermInfo.AppendText(strDescricao);
				rtbIncotermInfo.AppendText(System.Environment.NewLine);
				rtbIncotermInfo.Font = new System.Drawing.Font(rtbIncotermInfo.Font, System.Drawing.FontStyle.Bold);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Red;
				rtbIncotermInfo.AppendText("Obrigações:");
				rtbIncotermInfo.AppendText(System.Environment.NewLine);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Black;
				rtbIncotermInfo.AppendText(strObrigacoes);
				rtbIncotermInfo.AppendText(System.Environment.NewLine);
				rtbIncotermInfo.Font = new System.Drawing.Font(rtbIncotermInfo.Font, System.Drawing.FontStyle.Bold);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Red;
				rtbIncotermInfo.AppendText("Modalidade:");
				rtbIncotermInfo.AppendText(System.Environment.NewLine);
				rtbIncotermInfo.SelectionColor = System.Drawing.Color.Black;
				rtbIncotermInfo.AppendText(strModalidade);
				if (strObservacoes.Trim() != "")
				{
					rtbIncotermInfo.AppendText(System.Environment.NewLine);
					rtbIncotermInfo.Font = new System.Drawing.Font(rtbIncotermInfo.Font, System.Drawing.FontStyle.Bold);
					rtbIncotermInfo.SelectionColor = System.Drawing.Color.Red;
					rtbIncotermInfo.AppendText("Observações:");
					rtbIncotermInfo.AppendText(System.Environment.NewLine);
					rtbIncotermInfo.SelectionColor = System.Drawing.Color.Black;
					rtbIncotermInfo.AppendText(strObservacoes);
				}
				#endregion
				gbFields.Text = strGroupBoxTitle;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retona Valores
		public void retornaValores(out string strMeioTransporte, out double dSubTotal, out double dDesconto, out bool bRatearDesconto, out double dSubTotalCDesconto, out double dFreteInterno, out double dFreteInternacional, out double dSeguro, out string strTextoOutros, out double dOutros, out double dTotal, out bool bRatear, out string strIncoterm)
		{
			try
			{
				if (m_strRetorno.Trim() == "")
					retornaIncoterm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			strIncoterm = m_strRetorno;
			strMeioTransporte = retornaMeioTransporte();
			dFreteInterno = m_nFreteInterno;
			dFreteInternacional = m_nFreteInternacional;
			dSeguro = m_nSeguro;
			dOutros = m_nOutros;
			strTextoOutros = m_strOutros;
			bRatear = m_bRatearDespesas;
			dSubTotal = m_nValorTotalProdutos; 
			dDesconto = m_dDescontoValor;
			bRatearDesconto = m_bRatearDesconto;
			dSubTotalCDesconto = m_dSubTotalCDesconto;
			dTotal = m_dTotal;
		}
		protected abstract void retornaIncoterm();
		public void retornaIdIncoterm(out int idIncoterm)
		{
			idIncoterm = m_nIdIncoterm;
		}
		public abstract Object retornaTypDatSetEspecifico();
		private string retornaMeioTransporte()
		{
			if (m_nIdMeioTransporte == AEREO)
                return "Aereo";
			else if (m_nIdMeioTransporte == MARITIMO)
				return "Marítimo";
			else if (m_nIdMeioTransporte == RODOVIARIO)
				return "Rodoviário";
			else if (m_nIdMeioTransporte == FERROVIARIO)
				return "Ferroviário";
			else if (m_nIdMeioTransporte == CORREIO)
				return "Correio";

			return "";
		}
//		/// <summary>
//		/// Método temporário para poder rodar o Siscobras Principal
//		/// </summary>
//		/// <param name="strMeioTransporte"></param>
//		/// <param name="dSubTotal"></param>
//		/// <param name="dDesconto"></param>
//		/// <param name="bRatearDesconto"></param>
//		/// <param name="dSubTotalCDesconto"></param>
//		/// <param name="dFreteInterno"></param>
//		/// <param name="dFreteInternacional"></param>
//		/// <param name="dSeguro"></param>
//		/// <param name="strTextoOutros"></param>
//		/// <param name="dOutros"></param>
//		/// <param name="dTotal"></param>
//		/// <param name="bRatear"></param>
//		/// <param name="strIncoterm"></param>
//		public void retornaValores(out string strMeioTransporte, out double dSubTotal, out double dFreteInterno, out double dFreteInternacional, out double dSeguro, out string strTextoOutros, out double dOutros, out double dTotal, out bool bRatear, out string strIncoterm)
//		{
//			try
//			{
//				retornaIncoterm();
//			}
//			catch (Exception err)
//			{
//				Object erro = err;
//				m_cls_ter_tratadorErro.trataErro(ref erro);
//			}
//			strIncoterm = m_strRetorno;
//			strMeioTransporte = retornaMeioTransporte();
//			dFreteInterno = m_nFreteInterno;
//			dFreteInternacional = m_nFreteInternacional;
//			dSeguro = m_nSeguro;
//			dOutros = m_nOutros;
//			strTextoOutros = m_strOutros;
//			bRatear = m_bRatearDespesas;
//			dSubTotal = m_dSubTotal;
//			dTotal = m_dTotal;
//		}
		#endregion
	}
}
