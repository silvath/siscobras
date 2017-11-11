using System;

namespace mdlEsquemaPagamento
{
	#region Enuns

		public enum Condicao
		{
			Nenhuma = 0,
			Antecipado = 1,
			Avista = 2,
			Postecipado = 3,
			SemCoberturaCambial = 4,
			Consignacao = 5
		}

		public enum Modalidade
		{
			Nenhuma = 0,
			Transferencia = 1,
			Cobranca = 5,
			CartaCredito = 2,
			CartaoCredito = 3,
			EspecieChequeTraveller = 4
		}

		public enum UnidadeTempo
		{
			Dia = 0,
			Mes = 1
		}

		public enum DocumentoCondicao
		{
			Fatura = 0,
			Conhecimento =1,
			Aceite = 2,
			Saque = 3
		}
	#endregion
	/// <summary>
	/// Summary description for clsEsquemaPagamento.
	/// </summary>
	public abstract class clsEsquemaPagamento
	{
		#region Constants
			// ***************************************************************************************************
			// Constantes
			// ***************************************************************************************************
			public static int MAXDECIMALS = 8;

			private const string TEXTO_CONDICAO_ANTECIPADO = "Antecipado";
			private const string TEXTO_CONDICAO_AVISTA = "A Vista";
			private const string TEXTO_CONDICAO_POSTECIPADO = "Postecipado / A Prazo";
		    private const string TEXTO_CONDICAO_SEMCOBERTURACAMBIAL = "Sem Cobertura Cambial";
			private const string TEXTO_CONDICAO_CONSIGNACAO = "Consignação";
		  
		    private const string TEXTO_MODALIDADE_TRANSFERENCIA = "Transferência";
			private const string TEXTO_MODALIDADE_COBRANCA = "Cobrança";
			private const string TEXTO_MODALIDADE_CARTAOCREDITO = "Cartão de Crédito";
			private const string TEXTO_MODALIDADE_ESPECIECHEQUETRAVELLER = "Espécie, Cheque ou Traveller";
			private const string TEXTO_MODALIDADE_CARTACREDITO = "Carta de Crédito";

			
			private const int NUMERO_TEXTO_SEMCOBERTURACAMBIAL = 501;
			private const int NUMERO_TEXTO_CONSIGNACAO = 502;
		    private const int NUMERO_TEXTO_ANTECIPADO_TRANSFERENCIA = 503;
			private const int NUMERO_TEXTO_ANTECIPADO_CARTAOCREDITO = 504;
			private const int NUMERO_TEXTO_ANTECIPADO_ESPECIECHEQUETRAVELLER = 505;
			private const int NUMERO_TEXTO_AVISTA_COBRANCA = 506;
			private const int NUMERO_TEXTO_AVISTA_CARTACREDITO = 507;
			private const int NUMERO_TEXTO_AVISTA_CARTAOCREDITO = 508;
			private const int NUMERO_TEXTO_AVISTA_ESPECIECHEQUETRAVELLER = 509;
		    private const int NUMERO_TEXTO_POSTECIPADO_FATURA = 510;
			private const int NUMERO_TEXTO_POSTECIPADO_CONHECIMENTO = 511;
			private const int NUMERO_TEXTO_POSTECIPADO_ACEITE = 518;
			private const int NUMERO_TEXTO_POSTECIPADO_SAQUE = 519;
		    private const int NUMERO_TEXTO_POSTECIPADO_DIA = 512;
			private const int NUMERO_TEXTO_POSTECIPADO_MES = 513;
			private const int NUMERO_TEXTO_POSTECIPADO_COBRANCA = 514;
			private const int NUMERO_TEXTO_POSTECIPADO_CARTACREDITO = 515;
			private const int NUMERO_TEXTO_POSTECIPADO_CARTAOCREDITO = 516;
			private const int NUMERO_TEXTO_POSTECIPADO_ESPECIECHEQUETRAVELLER = 517;

			// ***************************************************************************************************
		#endregion
		#region Atributes
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			protected int m_nIdExportador;
			protected int m_nIdioma = -1;
			protected string m_strIdioma = "Indefinido";

			// Typed DataSets
			protected mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos m_typDatSetTbIdiomasTextos;

			private System.Windows.Forms.ImageList m_ilBandeiras;

			// Forms
			internal frmFEsquemaPagamento m_formFEsquemaPagamento; 

			// Cores Utilizadas 
			private System.Drawing.Color m_colSelecionado = System.Drawing.Color.Green;
			private System.Drawing.Color m_colHabilitado = System.Drawing.Color.DarkSalmon;
			private System.Drawing.Color m_colDesabilitado = System.Drawing.Color.Red;

			// Negocio 
			protected clsCalculoPorcentagens m_cls_cal_Porcentagens = null;
			protected bool m_bMostrarCondicoesPorValores = false;
		    protected string m_strEsquemaPagamento = "";
			protected int m_nIdMoeda = -1;
			protected bool m_bMostrarSimboloMoeda = false;
		    protected string m_strSimboloMoeda = "US$";
		    private double m_dValorTotal = 0;

			private bool m_bMostrarCondicaoAntecipada = true;

  			protected double m_dCondAntecipado = 0;
		    protected double m_dCondAvista = 0;
		    protected double m_dCondPostecipado = 0;
 		    protected bool m_bCondSemCoberturaCambial = false;
			protected bool m_bCondConsignacao = false;
			internal Modalidade m_enumModAntecipado = 0;
            internal Modalidade m_enumModAvista = 0; 
			internal Modalidade m_enumModPostecipado =0 ; 
			protected int m_nPostQuantTempo = 0;
			internal UnidadeTempo m_enumPostUnidadeTempo = UnidadeTempo.Dia; 
			internal DocumentoCondicao m_enumPostCondicao = DocumentoCondicao.Fatura;
			protected int m_nPostQuantParcelas = 0;
            protected int m_nPostIntervalo = 0;

 	        public bool m_bModificado = false;
			// ***************************************************************************************************
		#endregion
		#region Propriedades
			internal double ValorTotal
			{
				set
				{
					m_dValorTotal = value;
					m_cls_cal_Porcentagens = new clsCalculoPorcentagens(value);
				}
				get
				{
					return(m_dValorTotal);
				}
			}

			public bool MostrarPorValores
			{
				set
				{
					m_bMostrarCondicoesPorValores = value;
				}
			}

			public bool MostrarCondicaoAntecipada
			{
				set
				{
					m_bMostrarCondicaoAntecipada = value;
				}
			}
 
			public double CondicaoAntecipado
			{
				get
				{
					return(m_dCondAntecipado);
				}

			}

			public double CondicaoAvista
			{
				get
				{
					return(m_dCondAvista);

				}
			}

			public double CondicaoPostecipado
			{
				get
				{
					return(m_dCondPostecipado);
				}
			}

			public bool CondicaoSemCoberturaCambial
			{
				get
				{
					return(m_bCondSemCoberturaCambial);
				}
			}

			public bool CondicaoConsignacao
			{
				get
				{
					return(m_bCondConsignacao);
				}
			}

			public Modalidade ModalidadeAntecipado
			{
				get
				{
					return(m_enumModAntecipado);
				}
			}

			public Modalidade ModalidadeAvista
			{
				get
				{
					return(m_enumModAvista);
				}
			}

			public Modalidade ModalidadePostecipado
			{
				get
				{
					return(m_enumModPostecipado);
				}
			}

			public int PostecipadoQuantTempo
			{
				get
				{
					return(m_nPostQuantTempo);
				}
			}

			public UnidadeTempo PostecipadoUnidadeTempo
			{
				get
				{
					return(m_enumPostUnidadeTempo);
				}
			}

			public DocumentoCondicao PostecipadoCondicao
			{
				get
				{
					return(m_enumPostCondicao);
				}
			}

			public int PostecipadoQuantidadeParcelas
			{
				get
				{
					return(m_nPostQuantParcelas);
				}
			}

			public int PostecipadoIntervalo
			{
				get
				{
					return(m_nPostIntervalo);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsEsquemaPagamento(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, ref System.Windows.Forms.ImageList Bandeiras,int Exportador)
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;

				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_ilBandeiras = Bandeiras;
				m_nIdExportador = Exportador;
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				try
				{
					m_formFEsquemaPagamento = new frmFEsquemaPagamento(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
					InitializeEventsFormEsquemaPagamento();
					m_formFEsquemaPagamento.ShowDialog();
					if (m_formFEsquemaPagamento.m_bModificado)
					{
						this.m_bModificado = m_formFEsquemaPagamento.m_bModificado;
					} 			
					m_formFEsquemaPagamento.Dispose();
					m_formFEsquemaPagamento = null;
				}catch (System.Exception objExp){
					object objErro = (object)objExp;
					m_cls_ter_tratadorErro.trataErro(ref objErro);
				}
			}

			private void InitializeEventsFormEsquemaPagamento()
			{
				#region IO
					// Carrega os Dados na Interface
					m_formFEsquemaPagamento.eCallCarregaDadosInterface += new frmFEsquemaPagamento.delCallCarregaDadosInterface(this.CarregaDadosInterface);

				   // Salva dos dados no BD
					m_formFEsquemaPagamento.eCallSalvaDados += new frmFEsquemaPagamento.delCallSalvaDados(this.SalvaDados);

				#endregion
				#region TreeView
					// Refresh as Cores da TreeView
				    m_formFEsquemaPagamento.eCallRefreshCoresTreeView += new frmFEsquemaPagamento.delCallRefreshCoresTreeView(this.RefreshCoresTreeViewCondicoesPagamento);

					// Nodo Checado
					m_formFEsquemaPagamento.eCallTreeViewNodoChecado += new frmFEsquemaPagamento.delCallTreeViewNodoChecado(TreeViewNodoChecado);
			   
					// Nodo Clicado
					m_formFEsquemaPagamento.eCallTreeViewNodoClicado += new frmFEsquemaPagamento.delCallTreeViewNodoClicado(TreeViewNodoClicado);
				#endregion
				#region Configuracoes
					// Mostra por Valor 
					m_formFEsquemaPagamento.eCallChangeCondictionsView += new frmFEsquemaPagamento.delCallChangeCondictionsView(this.CheckBoxVisualizaPorValor);
				#endregion 
			}
		#endregion
		#region ShowDialog Valor
			private double ShowDialogValor()
			{
				double dRetorno = 0;
				double dSaldoAtual = dRetornaSaldoRestante();
				frmFValor formValor = new frmFValor(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_dValorTotal, dSaldoAtual,dSaldoAtual,m_strSimboloMoeda);
				formValor.ShowDialog();
				if (formValor.m_bModificado)
				{
					formValor.retornaValores(out dRetorno);
				}
				formValor = null;
				return(dRetorno);
			}
		#endregion
		#region ShowDialog Valor Postecipado
			private double ShowDialogValorPostecipado()
			{
				double dRetorno = 0;
				double dSaldoAtual = dRetornaSaldoRestante();
				if (m_dCondPostecipado == 0)
				{
					// Setando os opcoes default do postecipado
					m_nPostQuantTempo = 30;
					m_enumPostUnidadeTempo = UnidadeTempo.Dia;
					m_enumPostCondicao = DocumentoCondicao.Conhecimento;
					m_nPostQuantParcelas = 1;
					m_nPostIntervalo = 0;
				}
				frmFValorPostecipado formValorPostecipado = new frmFValorPostecipado(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_dValorTotal, dSaldoAtual,dSaldoAtual,m_strSimboloMoeda,m_nPostQuantTempo,m_enumPostUnidadeTempo,m_enumPostCondicao,m_nPostQuantParcelas,m_nPostIntervalo);
				formValorPostecipado.ShowDialog();
				if (formValorPostecipado.m_bModificado)
				{
					int nQuantTempo;
					UnidadeTempo enumUnidadeTempo;
					DocumentoCondicao enumCondicao;
					int nQuantParcelas;
					int nIntervalo;
					formValorPostecipado.retornaValores(out dRetorno,out nQuantTempo,out enumUnidadeTempo,out enumCondicao, out nQuantParcelas,out nIntervalo);
					if (dRetorno > 0)
					{
						m_nPostQuantTempo = nQuantTempo;
						m_enumPostUnidadeTempo = enumUnidadeTempo;
						m_enumPostCondicao = enumCondicao;
						m_nPostQuantParcelas = nQuantParcelas;
						m_nPostIntervalo = nIntervalo;
					}
				}
				formValorPostecipado = null;
				return(dRetorno);
			}
		#endregion

		#region Carregamento do Dados 
			#region Banco Dados 
				protected void CarregaDados()
				{
					CarregaDadosIdiomasEtiquetas();
					CarregaDadosEsquemaPagamento();
					CarregaDadosNomeIdioma();
					vCarregaDadosMoeda();
					vCarregaPorcentagens();
				}

				protected void CarregaDadosIdiomasEtiquetas()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbIdiomasTextos = m_cls_dba_ConnectionDB.GetTbIdiomasTextos(null,null,null,null,null);
				}

				protected abstract void CarregaDadosEsquemaPagamento();

				private void CarregaDadosNomeIdioma()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetTbIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = (mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow)typDatSetTbIdiomas.tbIdiomas.FindByidIdioma(m_nIdioma);
					if (dtrwIdioma != null)
						m_strIdioma = dtrwIdioma.mstrIdioma;
					dtrwIdioma = null;
					typDatSetTbIdiomas = null;
				}

				private void vCarregaDadosMoeda()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbMoedas typDatSetTbMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwMoeda = (mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow)typDatSetTbMoedas.tbMoedas.FindByidMoeda(m_nIdMoeda);
					if (dtrwMoeda != null)
						m_strSimboloMoeda = dtrwMoeda.simbolo;
					dtrwMoeda = null;
					typDatSetTbMoedas = null;
				}

				private void vCarregaPorcentagens()
				{
					m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_ANTECIPADO);
					m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_ANTECIPADO,m_dCondAntecipado * m_dValorTotal * 0.01);
					m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
					m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,m_dCondAvista * m_dValorTotal * 0.01);
					m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
					m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,m_dCondPostecipado * m_dValorTotal * 0.01);
				}
			#endregion
			#region Interface
				private void CarregaDadosInterface()
				{
					CarregaDadosInterfaceTreeView();
					CarregaDadosInterfaceIdioma();
					CarregaDadosInterfaceValorTotal();
					CarregaDadosInterfaceSaldo();
					CarregaDadosInterfaceEsquemaPagamento();
				}
				private void CarregaDadosInterfaceTreeView()
				{
					System.Windows.Forms.TreeNode tvnCondicao;
					System.Windows.Forms.TreeNode tvnModalidade;

					m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Clear();
					#region Antecipado 
					tvnCondicao = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Add(TEXTO_CONDICAO_ANTECIPADO);
					tvnCondicao.Tag = Condicao.Antecipado.ToString();
					tvnCondicao.Checked = (m_dCondAntecipado > 0);
					// Transferencia 
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_TRANSFERENCIA);
					tvnModalidade.Tag = Condicao.Antecipado.ToString() + Modalidade.Transferencia.ToString();
					if (m_enumModAntecipado == Modalidade.Transferencia)
						tvnModalidade.Checked = true;
					// Cartao de Credito
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_CARTAOCREDITO);
					tvnModalidade.Tag = Condicao.Antecipado.ToString() + Modalidade.CartaoCredito.ToString();
					if (m_enumModAntecipado == Modalidade.CartaoCredito)
						tvnModalidade.Checked = true;
					// Especie, Cheque e Traveller 
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_ESPECIECHEQUETRAVELLER);
					tvnModalidade.Tag = Condicao.Antecipado.ToString() + Modalidade.EspecieChequeTraveller.ToString();
					if (m_enumModAntecipado == Modalidade.EspecieChequeTraveller)
						tvnModalidade.Checked = true;
					#endregion
					#region A Vista 
					tvnCondicao = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Add(TEXTO_CONDICAO_AVISTA);
					tvnCondicao.Tag = Condicao.Avista.ToString();
					tvnCondicao.Checked = m_dCondAvista > 0;
					// Cobrança
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_COBRANCA);
					tvnModalidade.Tag = Condicao.Avista.ToString() + Modalidade.Cobranca.ToString();
					if (m_enumModAvista == Modalidade.Cobranca)
						tvnModalidade.Checked = true;
					// Carta de Crédito
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_CARTACREDITO);
					tvnModalidade.Tag = Condicao.Avista.ToString() + Modalidade.CartaCredito.ToString();
					if (m_enumModAvista == Modalidade.CartaCredito)
						tvnModalidade.Checked = true;
					// Cartao de Credito
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_CARTAOCREDITO);
					tvnModalidade.Tag = Condicao.Avista.ToString() + Modalidade.CartaoCredito.ToString();
					if (m_enumModAvista == Modalidade.CartaoCredito)
						tvnModalidade.Checked = true;
					// Especie, Cheque e Traveller 
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_ESPECIECHEQUETRAVELLER);
					tvnModalidade.Tag = Condicao.Avista.ToString() + Modalidade.EspecieChequeTraveller.ToString();
					if (m_enumModAvista == Modalidade.EspecieChequeTraveller)
						tvnModalidade.Checked = true;
					#endregion
					#region Postecipado
					tvnCondicao = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Add(TEXTO_CONDICAO_POSTECIPADO);
					tvnCondicao.Tag = Condicao.Postecipado.ToString();
					tvnCondicao.Checked = (m_dCondPostecipado > 0);
					// Cobrança
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_COBRANCA);
					tvnModalidade.Tag = Condicao.Postecipado.ToString() + Modalidade.Cobranca.ToString();
					if (m_enumModPostecipado == Modalidade.Cobranca)
						tvnModalidade.Checked = true;
					// Carta de Crédito
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_CARTACREDITO);
					tvnModalidade.Tag = Condicao.Postecipado.ToString() + Modalidade.CartaCredito.ToString();
					if (m_enumModPostecipado == Modalidade.CartaCredito)
						tvnModalidade.Checked = true;
					// Cartao de Credito
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_CARTAOCREDITO);
					tvnModalidade.Tag = Condicao.Postecipado.ToString() + Modalidade.CartaoCredito.ToString();
					if (m_enumModPostecipado == Modalidade.CartaoCredito)
						tvnModalidade.Checked = true;
					// Especie, Cheque e Traveller 
					tvnModalidade = tvnCondicao.Nodes.Add(TEXTO_MODALIDADE_ESPECIECHEQUETRAVELLER);
					tvnModalidade.Tag = Condicao.Postecipado.ToString() + Modalidade.EspecieChequeTraveller.ToString();
					if (m_enumModPostecipado == Modalidade.EspecieChequeTraveller)
						tvnModalidade.Checked = true;
					#endregion
					#region Sem Cobertura Cambial
					tvnCondicao = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Add(TEXTO_CONDICAO_SEMCOBERTURACAMBIAL);
					tvnCondicao.Tag = Condicao.SemCoberturaCambial.ToString();
					if (m_bCondSemCoberturaCambial)
						tvnCondicao.Checked = true;
					#endregion
					#region Consignacao
					tvnCondicao = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes.Add(TEXTO_CONDICAO_CONSIGNACAO);
					tvnCondicao.Tag = Condicao.Consignacao.ToString();
					if (m_bCondConsignacao)
						tvnCondicao.Checked = true;
					#endregion

				}

				private void CarregaDadosInterfaceIdioma()
				{
					try
					{
						m_formFEsquemaPagamento.m_lbIdioma.Text = m_strIdioma;
						if (m_ilBandeiras != null)
							m_formFEsquemaPagamento.m_picIdioma.Image = m_ilBandeiras.Images[m_nIdioma - 1];
					}catch{

					}
				}

				private void CarregaDadosInterfaceValorTotal()
				{
					m_formFEsquemaPagamento.m_lbValorTotalNumero.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,m_dValorTotal,m_bMostrarSimboloMoeda);
				}
			
				private void CarregaDadosInterfaceSaldo()
				{
					double dSaldo = m_cls_cal_Porcentagens.Saldo;
					if (m_bCondConsignacao || m_bCondSemCoberturaCambial)
						dSaldo = 0;
					m_formFEsquemaPagamento.m_lbSaldoNumero.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dSaldo,m_bMostrarSimboloMoeda);
				}

				private void CarregaDadosInterfaceEsquemaPagamento()
				{
					if (m_strEsquemaPagamento.Trim() == "")
					{
						m_formFEsquemaPagamento.m_txtEsquemaPagamento.Text = m_strEsquemaPagamento;
						m_formFEsquemaPagamento.m_txtEsquemaPagamento.Enabled = false;
					}else{
						m_formFEsquemaPagamento.m_txtEsquemaPagamento.Text = m_strEsquemaPagamento;
						m_formFEsquemaPagamento.m_txtEsquemaPagamento.Enabled = true;
					}
				}
			#endregion
		#endregion
		#region Manipulacao Dados
		#endregion
		#region Salvamento do Dados 
			#region Interface

			#endregion
			#region Banco Dados 
				protected abstract void SalvaDados(string strEsquemaPagamento);
			#endregion
		#endregion

		#region Saldo
			private double dRetornaSaldoRestante()
			{
				double dPorcentagem = m_dCondAntecipado + m_dCondAvista + m_dCondPostecipado;
				if (dPorcentagem < 0)
				{
					dPorcentagem = 0;
				}
				if (dPorcentagem > 100)
				{
					dPorcentagem = 100;
				}
				double dRetorno = System.Math.Round(m_dValorTotal * dPorcentagem,MAXDECIMALS);
				dRetorno = System.Math.Round(dRetorno / 100,MAXDECIMALS);
				dRetorno = System.Math.Round(m_dValorTotal - dRetorno,MAXDECIMALS);
				return (dRetorno);
			}
		#endregion
		#region TreeView
			#region Cores
				private void RefreshCoresTreeViewCondicoesPagamento()
				{
					double dSaldo = dRetornaSaldoRestante();
					System.Windows.Forms.TreeNode tvnNodo = m_formFEsquemaPagamento.m_tvCondicoesPagamento.Nodes[0];
					System.Drawing.Color colUsar;
			
					// Antecipado 
					if ((!m_bCondConsignacao) && (!m_bCondSemCoberturaCambial) && ((dSaldo > 0) || (m_dCondAntecipado > 0)))
					{
						if (m_dCondAntecipado > 0)
						{
							tvnNodo.ForeColor = m_colSelecionado;
							colUsar = m_colDesabilitado;
						}else{
							tvnNodo.ForeColor = m_colHabilitado;
							colUsar = m_colHabilitado;
						}
					}else{
						tvnNodo.ForeColor = m_colDesabilitado;
						colUsar = m_colDesabilitado;
					}
					for(int nCont = 0 ; nCont < tvnNodo.Nodes.Count;nCont++)
						tvnNodo.Nodes[nCont].ForeColor = colUsar;
					if (tvnNodo.ForeColor.Equals(m_colSelecionado))
						if (m_enumModAntecipado != Modalidade.Nenhuma)
						{
							if ((m_enumModAntecipado != Modalidade.EspecieChequeTraveller) && (m_enumModAntecipado != Modalidade.CartaoCredito))
							{
								tvnNodo.Nodes[(((int)m_enumModAntecipado - 1))].ForeColor = tvnNodo.ForeColor;
							}
							else
							{
								tvnNodo.Nodes[(((int)m_enumModAntecipado - 2))].ForeColor = tvnNodo.ForeColor;
							}
						}

					// Avista 
					tvnNodo = tvnNodo.NextNode;
					if ((!m_bCondConsignacao) && (!m_bCondSemCoberturaCambial) && ((dSaldo > 0) || (m_dCondAvista > 0)))
					{
						if (m_dCondAvista > 0)
						{
							tvnNodo.ForeColor = m_colSelecionado;
							colUsar = m_colDesabilitado;
						}else{
							tvnNodo.ForeColor = m_colHabilitado;
							colUsar = m_colHabilitado;
						}
					}else{
						tvnNodo.ForeColor = m_colDesabilitado;
						colUsar = m_colDesabilitado;
					}
					for(int nCont = 0 ; nCont < tvnNodo.Nodes.Count;nCont++)
						tvnNodo.Nodes[nCont].ForeColor = colUsar;
					if (tvnNodo.ForeColor.Equals(m_colSelecionado))
					{
						if (m_enumModAvista != Modalidade.Nenhuma)
						{
							switch(m_enumModAvista)
							{
								case Modalidade.Cobranca:
									tvnNodo.Nodes[0].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.CartaCredito:
									tvnNodo.Nodes[1].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.CartaoCredito:
									tvnNodo.Nodes[2].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.EspecieChequeTraveller:
									tvnNodo.Nodes[3].ForeColor = tvnNodo.ForeColor;
									break;
							} 
						}
					}

					// Postecipado
					tvnNodo = tvnNodo.NextNode;
					if ((!m_bCondConsignacao) && (!m_bCondSemCoberturaCambial) && ((dSaldo > 0) || (m_dCondPostecipado > 0)))
					{
						if (m_dCondPostecipado > 0)
						{
							tvnNodo.ForeColor = m_colSelecionado;
							colUsar = m_colDesabilitado;
						}else{
							tvnNodo.ForeColor = m_colHabilitado;
							colUsar = m_colHabilitado;
						}
					}else{
						tvnNodo.ForeColor = m_colDesabilitado;
						colUsar = m_colDesabilitado;
					}
					for(int nCont = 0 ; nCont < tvnNodo.Nodes.Count;nCont++)
						tvnNodo.Nodes[nCont].ForeColor = colUsar;
					if (tvnNodo.ForeColor.Equals(m_colSelecionado))
					{
						if (m_enumModPostecipado != Modalidade.Nenhuma)
						{
							switch(m_enumModPostecipado)
							{
								case Modalidade.Cobranca:
									tvnNodo.Nodes[0].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.CartaCredito:
									tvnNodo.Nodes[1].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.CartaoCredito:
									tvnNodo.Nodes[2].ForeColor = tvnNodo.ForeColor;
									break;
								case Modalidade.EspecieChequeTraveller:
									tvnNodo.Nodes[3].ForeColor = tvnNodo.ForeColor;
									break;
							} 
						}
					}
					// Sem Cobertura Cambial 
					tvnNodo = tvnNodo.NextNode;
					if ((!m_bCondConsignacao) && (m_dCondAntecipado == 0) && (m_dCondAvista == 0) && (m_dCondPostecipado == 0))
					{
						if (m_bCondSemCoberturaCambial)
							tvnNodo.ForeColor = m_colSelecionado;
						else
							tvnNodo.ForeColor = m_colHabilitado;
					}
					else
					{
						tvnNodo.ForeColor = m_colDesabilitado;
					}

					// Consignacao
					tvnNodo = tvnNodo.NextNode;
					if ((!m_bCondSemCoberturaCambial) && (m_dCondAntecipado == 0) && (m_dCondAvista == 0) && (m_dCondPostecipado == 0))
					{
						if (m_bCondConsignacao)
							tvnNodo.ForeColor = m_colSelecionado;
						else
							tvnNodo.ForeColor = m_colHabilitado;
					}
					else
					{
						tvnNodo.ForeColor = m_colDesabilitado;
					}
				}
			#endregion
			#region Nodo
				private void TreeViewNodoClicado(System.Windows.Forms.TreeNode tvnNodo)
				{
		            // Verificando se ele não esta marcando um nodo que nao pode ser escolhido
					if ((!tvnNodo.ForeColor.Equals(m_colDesabilitado)) && (!tvnNodo.ForeColor.Equals(m_colSelecionado)))
					{
						// Verifica se o nodo esta selecinado ou nao
						if (tvnNodo.Checked)
						{
							// Selecinado
							TreeViewSelecinaNodo(tvnNodo);
							CarregaDadosInterfaceValorTotal();
							CarregaDadosInterfaceSaldo();
							m_strEsquemaPagamento = strRetornaEsquemaPagamento();
							CarregaDadosInterfaceEsquemaPagamento();
							RefreshCoresTreeViewCondicoesPagamento();
						}else{
							// Desselecionado 
							TreeViewDesselecionaNodo(tvnNodo);
							CarregaDadosInterfaceValorTotal();
							CarregaDadosInterfaceSaldo();
							m_strEsquemaPagamento = strRetornaEsquemaPagamento();
							CarregaDadosInterfaceEsquemaPagamento();
							RefreshCoresTreeViewCondicoesPagamento();
						}
					}
				}

				private void TreeViewNodoChecado(System.Windows.Forms.TreeNode tvnNodo)
				{
					// Verificando se ele não esta marcando um nodo que nao pode ser escolhido
					if (tvnNodo.ForeColor.Equals(m_colDesabilitado))
					{
						tvnNodo.Checked = false;
						if (m_dValorTotal > 0)
						{
							mdlMensagens.clsMensagens.ShowInformation("Esquema de Pagamento", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEsquemaPagamento_clsEsquemaPagamento_CombinacaoInvalida));
							//System.Windows.Forms.MessageBox.Show("De acordo com as combinações atuais você não pode selecionar esta modalidade.","Siscobras",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
						}else{
							mdlMensagens.clsMensagens.ShowInformation("Esquema de Pagamento", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEsquemaPagamento_clsEsquemaPagamento_NaoHaProdutos));
							//System.Windows.Forms.MessageBox.Show("Antes de definir as condições de pagamento é necessário lançar ao menos uma linha de produtos ao documento.","Siscobras",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
   						}
					}else{
						// Verifica se o nodo esta selecinado ou nao
						if (tvnNodo.Checked)
						{
							// Selecinado
							TreeViewSelecinaNodo(tvnNodo);
							CarregaDadosInterfaceValorTotal();
							CarregaDadosInterfaceSaldo();
							m_strEsquemaPagamento = strRetornaEsquemaPagamento();
							CarregaDadosInterfaceEsquemaPagamento();
							RefreshCoresTreeViewCondicoesPagamento();
						}
						else
						{
							// Desselecionado 
							TreeViewDesselecionaNodo(tvnNodo);
							CarregaDadosInterfaceValorTotal();
							CarregaDadosInterfaceSaldo();
							m_strEsquemaPagamento = strRetornaEsquemaPagamento();
							CarregaDadosInterfaceEsquemaPagamento();
							RefreshCoresTreeViewCondicoesPagamento();
						}
					}
				}

				private void TreeViewSelecinaNodo(System.Windows.Forms.TreeNode tvnNodo)
				{
					#region Antecipado 
						// Antecipado 
						if (tvnNodo.Tag.ToString() == Condicao.Antecipado.ToString())
						{
							tvnNodo.Checked = false;
							if (!tvnNodo.IsExpanded)
								tvnNodo.Expand();   
						}
						// Antecipado - Transferencia  
						if (tvnNodo.Tag.ToString() == Condicao.Antecipado.ToString() + Modalidade.Transferencia.ToString())
						{
							if (bInsereAntecipadoPorTransferencia())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

					    // Antecipado - Cartao Credito 
						if (tvnNodo.Tag.ToString() == Condicao.Antecipado.ToString() + Modalidade.CartaoCredito.ToString())
						{
							if (bInsereAntecipadoPorCartaoCredito())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Antecipado - Especie Cheque ou Traveller
						if (tvnNodo.Tag.ToString() == Condicao.Antecipado.ToString() + Modalidade.EspecieChequeTraveller.ToString())
						{
							if (bInsereAntecipadoPorEspecieChequeTraveller())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

   					#endregion
					#region A Vista 
						// AVista
						if (tvnNodo.Tag.ToString() == Condicao.Avista.ToString())
						{
							tvnNodo.Checked = false;
							if (!tvnNodo.IsExpanded)
								tvnNodo.Expand();   
						}
						// Avista  - Cobrança
						if (tvnNodo.Tag.ToString() == Condicao.Avista.ToString() + Modalidade.Cobranca.ToString())
						{
							if (bInsereAVistaPorCobranca())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Avista  - Carta Credito
						if (tvnNodo.Tag.ToString() == Condicao.Avista.ToString() + Modalidade.CartaCredito.ToString())
						{
							if (bInsereAVistaPorCartaCredito())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Avista  - Cartao Credito
						if (tvnNodo.Tag.ToString() == Condicao.Avista.ToString() + Modalidade.CartaoCredito.ToString())
						{
							if (bInsereAVistaPorCartaoCredito())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Avista  - Especie Cheque ou Traveller
						if (tvnNodo.Tag.ToString() == Condicao.Avista.ToString() + Modalidade.EspecieChequeTraveller.ToString())
						{
							if (bInsereAVistaPorEspecieChequeTraveller())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}
					#endregion
					#region Postecipado
						// Postecipado
						if (tvnNodo.Tag.ToString() == Condicao.Postecipado.ToString())
						{
							tvnNodo.Checked = false;
							if (!tvnNodo.IsExpanded)
								tvnNodo.Expand();   
						}
						// Postecipado - Cobrança
						if (tvnNodo.Tag.ToString() == Condicao.Postecipado.ToString() + Modalidade.Cobranca.ToString())
						{
							if (bInserePostecipadoPorCobranca())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Postecipado  - Carta Credito
						if (tvnNodo.Tag.ToString() == Condicao.Postecipado.ToString() + Modalidade.CartaCredito.ToString())
						{
							if (bInserePostecipadoPorCartaCredito())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Postecipado  - Cartao Credito
						if (tvnNodo.Tag.ToString() == Condicao.Postecipado.ToString() + Modalidade.CartaoCredito.ToString())
						{
							if (bInserePostecipadoPorCartaoCredito())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}

						// Postecipado - Especie Cheque ou Traveller
						if (tvnNodo.Tag.ToString() == Condicao.Postecipado.ToString() + Modalidade.EspecieChequeTraveller.ToString())
						{
							if (bInserePostecipadoPorEspecieChequeTraveller())
							{
								tvnNodo.Parent.Checked = true;
								tvnNodo.Checked = true;
								RefreshCoresTreeViewCondicoesPagamento();
							}else{
								tvnNodo.Checked = false;
							}
						}
					#endregion
					#region Sem Cobertura Cambial
						if (tvnNodo.Tag.ToString() == Condicao.SemCoberturaCambial.ToString())
						{
							tvnNodo.Checked = true;
							m_bCondSemCoberturaCambial = true;
						}
					#endregion
					#region Consignacao
						if (tvnNodo.Tag.ToString() == Condicao.Consignacao.ToString())
						{
							tvnNodo.Checked = true;
							m_bCondConsignacao = true;
						}
					#endregion
				}

				private void TreeViewDesselecionaNodo(System.Windows.Forms.TreeNode tvnNodo)
				{
					// Antecipado 
					if ((tvnNodo.Tag.ToString().StartsWith(Condicao.Antecipado.ToString())))
					{
                        m_dCondAntecipado = 0;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_ANTECIPADO);
						m_enumModAntecipado = Modalidade.Nenhuma;
					}
					// Avista 
					if ((tvnNodo.Tag.ToString().StartsWith(Condicao.Avista.ToString())))
					{
						m_dCondAvista = 0;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
						m_enumModAvista = Modalidade.Nenhuma;
					}
					// Postecipado 
					if ((tvnNodo.Tag.ToString().StartsWith(Condicao.Postecipado.ToString())))
					{
						m_dCondPostecipado = 0;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
						m_enumModPostecipado = Modalidade.Nenhuma;
					}

					// Sem Cobertura Cambial
					if ((tvnNodo.Tag.ToString().StartsWith(Condicao.SemCoberturaCambial.ToString())))
					{
						m_bCondSemCoberturaCambial = false;
					}

					// Consignacao
					if ((tvnNodo.Tag.ToString().StartsWith(Condicao.Consignacao.ToString())))
					{
						m_bCondConsignacao = false;
					}
					
					tvnNodo.Checked = false;
					if (tvnNodo.Parent != null)
					{
						tvnNodo.Parent.Checked = false;
					}
					for (int nCont = 0 ; nCont < tvnNodo.Nodes.Count;nCont++)
						tvnNodo.Nodes[nCont].Checked = false;

					RefreshCoresTreeViewCondicoesPagamento();
				}
			#endregion
		#endregion
		#region CheckBox
			private void CheckBoxVisualizaPorValor(bool bMostrarPorValor)
			{
				m_bMostrarCondicoesPorValores = bMostrarPorValor; 
				m_strEsquemaPagamento = strRetornaEsquemaPagamento();
				CarregaDadosInterfaceEsquemaPagamento();
			}
		#endregion
		#region EsquemaPagamento
			#region Geral
				private string strRetornaEsquemaPagamento()
				{
					string strRetorno = "";

					// Antecipado 
					if((m_dCondAntecipado > 0) && (m_bMostrarCondicaoAntecipada))
					{
						if (strRetorno != "")
						strRetorno += " , ";
						strRetorno += strRetornaEsquemaPagamentoAntecipado();
					} 

					// Avista 
					if(m_dCondAvista > 0)
					{
						if (strRetorno != "")
							strRetorno += " , ";
						strRetorno += strRetornaEsquemaPagamentoAvista();
					} 

					// Postecipado 
					if(m_dCondPostecipado > 0)
					{
						if (strRetorno != "")
							strRetorno += " , ";
						strRetorno += strRetornaEsquemaPagamentoPostecipado();
					} 

					// Sem Cobertura Cambial 
					if (m_bCondSemCoberturaCambial)
						strRetorno = strRetornaEsquemaPagamentoSemCoberturaCambial();

					// Consginacao 
					if (m_bCondConsignacao)
						strRetorno = strRetornaEsquemaPagamentoConsignacao();

					return (strRetorno);
				}
			#endregion
			#region Antecipado 
				private string strRetornaEsquemaPagamentoAntecipado()
				{
					string strRetorno = "";
					int nIdTexto = 0;
					switch(m_enumModAntecipado)
					{
						case Modalidade.Transferencia:
							nIdTexto = NUMERO_TEXTO_ANTECIPADO_TRANSFERENCIA;
							break;
						case Modalidade.CartaoCredito:
							nIdTexto = NUMERO_TEXTO_ANTECIPADO_CARTAOCREDITO;
							break;
						case Modalidade.EspecieChequeTraveller:
							nIdTexto = NUMERO_TEXTO_ANTECIPADO_ESPECIECHEQUETRAVELLER;
							break;
					}
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(nIdTexto,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strRetorno = dtrwTexto.mstrTexto;
						if (m_dCondAntecipado != 100)
						{
							if (m_bMostrarCondicoesPorValores)
								strRetorno = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,m_cls_cal_Porcentagens.dValor(TEXTO_CONDICAO_ANTECIPADO),true) + " " + strRetorno;
							else
								strRetorno = m_cls_cal_Porcentagens.dPorcentagem(TEXTO_CONDICAO_ANTECIPADO) + "% " + strRetorno;
						}
					}
					return(strRetorno); 
				}
			#endregion
			#region Avista 
				private string strRetornaEsquemaPagamentoAvista()
				{
					string strRetorno = "";
					int nIdTexto = 0;
					switch(m_enumModAvista)
					{
						case Modalidade.Cobranca:
							nIdTexto = NUMERO_TEXTO_AVISTA_COBRANCA;
							break;
						case Modalidade.CartaCredito:
							nIdTexto = NUMERO_TEXTO_AVISTA_CARTACREDITO;
							break;
						case Modalidade.CartaoCredito:
							nIdTexto = NUMERO_TEXTO_AVISTA_CARTAOCREDITO;
							break;
						case Modalidade.EspecieChequeTraveller:
							nIdTexto = NUMERO_TEXTO_AVISTA_ESPECIECHEQUETRAVELLER;
							break;
					}
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(nIdTexto,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strRetorno = dtrwTexto.mstrTexto;
						if (m_dCondAvista != 100)
						{
							if (m_bMostrarCondicoesPorValores)
								strRetorno = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,m_cls_cal_Porcentagens.dValor(TEXTO_CONDICAO_AVISTA),true) + " " + strRetorno;
							else
								strRetorno = m_cls_cal_Porcentagens.dPorcentagem(TEXTO_CONDICAO_AVISTA) + "% " + strRetorno;
						}
					}
					return(strRetorno); 
				}
			#endregion
			#region Postecipado
				private string strRetornaEsquemaPagamentoPostecipado()
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTexto;
					string strRetorno = "";
					string strCondicao = "";
					string strUnidadeTempo = "";
					int nIdTexto = -1;
					int nTempo = -1;
					string strModeloParcela  = "";
					string strParcelaAtual = "";

		            // Selecionando a Condição  "Fatura/Conhecimento/Saque/Aceite" 
					switch(m_enumPostCondicao)
					{
						case DocumentoCondicao.Fatura:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_FATURA;
							break;
						case DocumentoCondicao.Conhecimento:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_CONHECIMENTO;
							break;
						case DocumentoCondicao.Saque:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_SAQUE;
							break;
						case DocumentoCondicao.Aceite:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_ACEITE;
							break;
					} 
					dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(nIdTexto,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strCondicao = dtrwTexto.mstrTexto;
					}
					
		            // Selecionando a unidade de Tempo "DIA/MES"
					switch(m_enumPostUnidadeTempo)
					{
						case UnidadeTempo.Dia:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_DIA;
							break;
						case UnidadeTempo.Mes:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_MES;
							break;
						default:
							nIdTexto = -1;
							break;
					}
					dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(nIdTexto,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strUnidadeTempo = dtrwTexto.mstrTexto;
					}

					// Adquirindo o Modelo da Modalidade 
					switch(m_enumModPostecipado)
					{
						case Modalidade.Cobranca:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_COBRANCA;
							break;
						case Modalidade.CartaCredito:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_CARTACREDITO;
							break;
						case Modalidade.CartaoCredito:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_CARTAOCREDITO;
							break;
						case Modalidade.EspecieChequeTraveller:
							nIdTexto = NUMERO_TEXTO_POSTECIPADO_ESPECIECHEQUETRAVELLER;
							break;
						default:
							nIdTexto = -1;
							break;
					}
					dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(nIdTexto,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strModeloParcela = dtrwTexto.mstrTexto;
					}

					// Substituindo valores sempre iguais no modelo de parcela
					strModeloParcela = strModeloParcela.Replace("#Condicao#", strCondicao);
					strModeloParcela = strModeloParcela.Replace("#UnidadeTempo#", strUnidadeTempo);

					// Varendo as Parcelas 
					nTempo = m_nPostQuantTempo;

					clsCalculoPorcentagens cls_calc_Porcentagens = new clsCalculoPorcentagens(this.ValorTotal);
					cls_calc_Porcentagens.bAdiciona(TEXTO_CONDICAO_ANTECIPADO,m_dCondAntecipado);
					cls_calc_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,m_dCondAvista);
					cls_calc_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,m_cls_cal_Porcentagens.dValor(TEXTO_CONDICAO_POSTECIPADO),m_nPostQuantParcelas);
					for (int i = 0 ; i < m_nPostQuantParcelas;i++)
					{
						strParcelaAtual = strModeloParcela;
						strParcelaAtual = strParcelaAtual.Replace("#Tempo#",nTempo.ToString());
						// Colocando o Valor ou a Porcentagem
						if (m_bMostrarCondicoesPorValores)
						{
							strParcelaAtual = strParcelaAtual.Replace("#Valor#",mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,cls_calc_Porcentagens.dValor(TEXTO_CONDICAO_POSTECIPADO + i.ToString()),true));
						}
						else
						{
							strParcelaAtual = strParcelaAtual.Replace("#Valor#",cls_calc_Porcentagens.dPorcentagem(TEXTO_CONDICAO_POSTECIPADO + i.ToString()) + "%");
						}
						if (strRetorno == "")
							strRetorno = strParcelaAtual;
						else
							strRetorno += " , " + strParcelaAtual;
						nTempo = nTempo + m_nPostIntervalo;
					}
					return(strRetorno); 
				}
			#endregion
			#region Sem Cobertura Cambial 
				private string strRetornaEsquemaPagamentoSemCoberturaCambial()
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(NUMERO_TEXTO_SEMCOBERTURACAMBIAL,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strRetorno = dtrwTexto.mstrTexto;
					}
					return (strRetorno);
				}
			#endregion
			#region Consignacao
				private string strRetornaEsquemaPagamentoConsignacao()
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTexto = (mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow)m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(NUMERO_TEXTO_CONSIGNACAO,m_nIdioma);
					if (dtrwTexto != null)
					{
						if (!dtrwTexto.IsmstrTextoNull())
							strRetorno = dtrwTexto.mstrTexto;
					}
					return (strRetorno);
				}
			#endregion
		#endregion
		#region Inserindo Novas Condicoes Pagamento
			#region Antecipado
				private bool bInsereAntecipadoPorTransferencia()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAntecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_ANTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_ANTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModAntecipado = Modalidade.Transferencia;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInsereAntecipadoPorCartaoCredito()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAntecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_ANTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_ANTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModAntecipado = Modalidade.CartaoCredito;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInsereAntecipadoPorEspecieChequeTraveller()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAntecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_ANTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_ANTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModAntecipado = Modalidade.EspecieChequeTraveller;
						bRetorno = true;
					}
					return (bRetorno);
				}
			#endregion
			#region Avista
				private bool bInsereAVistaPorCobranca()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAvista = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,dValor * m_dValorTotal * 0.01);
						m_enumModAvista = Modalidade.Cobranca;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInsereAVistaPorCartaCredito()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAvista = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,dValor * m_dValorTotal * 0.01);
						m_enumModAvista = Modalidade.CartaCredito;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInsereAVistaPorCartaoCredito()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAvista = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,dValor * m_dValorTotal * 0.01);
						m_enumModAvista = Modalidade.CartaoCredito;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInsereAVistaPorEspecieChequeTraveller()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValor();
					if (dValor > 0)
					{
						m_dCondAvista = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_AVISTA);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_AVISTA,dValor * m_dValorTotal * 0.01);
						m_enumModAvista = Modalidade.EspecieChequeTraveller;
						bRetorno = true;
					}
					return (bRetorno);
				}
			#endregion
			#region Postecipado
				private bool bInserePostecipadoPorCobranca()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValorPostecipado();
					if (dValor > 0)
					{
						m_dCondPostecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModPostecipado = Modalidade.Cobranca;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInserePostecipadoPorCartaCredito()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValorPostecipado();
					if (dValor > 0)
					{
						m_dCondPostecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModPostecipado = Modalidade.CartaCredito;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInserePostecipadoPorCartaoCredito()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValorPostecipado();
					if (dValor > 0)
					{
						m_dCondPostecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModPostecipado = Modalidade.CartaoCredito;
						bRetorno = true;
					}
					return (bRetorno);
				}

				private bool bInserePostecipadoPorEspecieChequeTraveller()
				{
					bool bRetorno = false;
					double dValor = 0;
					dValor = ShowDialogValorPostecipado();
					if (dValor > 0)
					{
						m_dCondPostecipado = dValor;
						m_cls_cal_Porcentagens.bRemove(TEXTO_CONDICAO_POSTECIPADO);
						m_cls_cal_Porcentagens.bAdiciona(TEXTO_CONDICAO_POSTECIPADO,dValor * m_dValorTotal * 0.01);
						m_enumModPostecipado = Modalidade.EspecieChequeTraveller;
						bRetorno = true;
					}
					return (bRetorno);
				}
			#endregion
		#endregion
		#region Retorno
			public void retornaValores(out string strEsquemaPagamento)
			{
                strEsquemaPagamento = m_strEsquemaPagamento;
			}

			public void vRetornaValores(int nIdIdioma,out string strEsquemaPagamento)
			{
				int nIdIdiomaOld = m_nIdioma;
				m_nIdioma = nIdIdioma;
				strEsquemaPagamento = strRetornaEsquemaPagamento();
				m_nIdioma = nIdIdiomaOld;
			}

			public void retornaValores(out double dCondAntecipado,out double dCondAvista,out double dCondPostecipado,out bool bCondSemCoberturaCambial,out bool bCondConsignacao,out Modalidade enumModAntecipado,out Modalidade enumModAvista,out Modalidade enumModPostecipado,out int nPostQuantTempo,out UnidadeTempo enumPostUnidadeTempo,out DocumentoCondicao enumPostCondicao,out int nPostQuantParcelas,out int nPostIntervalo)
			{
				dCondAntecipado = m_dCondAntecipado; 
				dCondAvista = m_dCondAvista;
				dCondPostecipado = m_dCondPostecipado;
				bCondSemCoberturaCambial = m_bCondSemCoberturaCambial;
				bCondConsignacao = m_bCondConsignacao;
				enumModAntecipado = m_enumModAntecipado;
				enumModAvista = m_enumModAvista; 
				enumModPostecipado = m_enumModPostecipado; 
				nPostQuantTempo = m_nPostQuantTempo;
				enumPostUnidadeTempo = m_enumPostUnidadeTempo; 
				enumPostCondicao = m_enumPostCondicao;
				nPostQuantParcelas = m_nPostQuantParcelas;
				nPostIntervalo = m_nPostIntervalo;
			}
		#endregion
	}
}
