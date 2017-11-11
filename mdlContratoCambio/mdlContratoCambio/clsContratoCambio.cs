using System;

namespace mdlContratoCambio
{
	#region Enums
		public enum TipoContratacao
		{
			Indefinido = 0,
			ACC = 1,
			ACE = 2,
			Normal = 3,
		}
		
		public enum TipoContrato
		{
			Indefinido = 0,
			Exportacao = 1,
			AlteracaoDeContratoDeCambioExportacao = 7,
			Cancelamento = 9
		}
	#endregion
	/// <summary>
	/// Summary description for clsContratoCambio.
	/// </summary>
	public class clsContratoCambio
	{
		#region Constants
		#endregion
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador;

			// Formularios
			private frmFContratoCambio m_formFContratoCambio = null;

			// Configuracoes
			private bool m_bMostrarContratosComSaldo = true;
			private bool m_bMostrarContratosSemSaldo = true;
			private bool m_bMostrarAcc = true;
			private bool m_bMostrarAce = true;

			// TypedDatSets
			private mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos m_typDatSetBancos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbContratosCambio m_typDatSetContratosCambio = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero m_typDatSetProdutosBordero = null;

			public bool m_bModificado = false;

			//--------------------------------------------------------------
			// Insercao Novos Contratos
			private int m_nMoeda = 28;
			private string m_strSimboloMoeda = "US$";
			//--------------------------------------------------------------
			
		#endregion
		#region Constructor
			public clsContratoCambio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel; 

				m_nIdExportador = idExportador;

				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			#region Banco Dados
				private void vCarregaDados()
				{
					m_cls_dba_ConnectionDB.DataPersist = false;
					vCarregaDadosBancos();
					vCarregaDadosContratosCambio();
					vCarregaDadosProdutosBordero();
				}

				private void vCarregaDadosBancos()
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

					// Bancos
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlOrdenacaoCampo.Add("strNome");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetBancos = m_cls_dba_ConnectionDB.GetTbExportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				}

				private void vCarregaDadosContratosCambio()
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					// Contratos Cambio
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}

				private void vCarregaDadosProdutosBordero()
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					// Produtos Bordero
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			#endregion
			#region Interface
				private void vCarregaSimboloMoeda(out string strSimboloMoeda)
				{
					strSimboloMoeda = m_strSimboloMoeda;
				}

				private void vCarregaDadosContratoInformacoes(int nContratoCambio,out string strNumero,out string strContratacao,out string strValor,out string strSaldo,out bool bCancelarSaldo)
				{
					strNumero = strNumeroContrato(nContratoCambio);
					strContratacao = strContratacaoContrato(nContratoCambio);
					double dValor = dValorTotalContratoCambio(nContratoCambio);
					int nMoeda = nMoedaContrato(nContratoCambio);
					strValor = mdlMoeda.clsMoeda.strReturnCurrencyFormated(nMoeda,dValor,true);
					strSaldo = mdlMoeda.clsMoeda.strReturnCurrencyFormated(nMoeda,dSaldoContratoCambio(nContratoCambio,dValor),true);
					bCancelarSaldo = (dSaldoCanceladoContratoCambio(nContratoCambio) > 0);
				}
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Interface
				private bool bSalvaDadosInterface(TipoContratacao enumTipoContratacao,int nIdBanco,string strNumero,System.DateTime dtEmissao,System.DateTime dtVencimento,double dValor,double dTaxaCambial)
				{
					bool bRetorno = false;

					// Verificando se o contrato ja existe 
					if (strNumero != "")
					{
						foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
						{
							if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
							{
								if (dtrwContratoCambio.strNumero == strNumero)
								{
									mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_NumeroContratoCambioJaExiste));
									return(false);
								}
							}
						}
					}
					// Caso seja ACC verificando se ele inseriu o nome do mesmo
					if (enumTipoContratacao == TipoContratacao.ACC)
					{
						if (strNumero == "")
						{
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_VoceNaoPodeCriarUmCCSemNumero));
							return(false);
						}
					}

					// Verificando a formatação do Número do Contrato
					if (strNumero != "")
					{
						if (strNumero.Length != 9){
							mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_NumeroContratoCambioSemFormatacao));
							return(false);
						}
					}

					// Verificando se o Id do Banco existe
					if (nIdBanco == -1)
					{
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_ColoqueUmBancoValido));
						return(false);
					}

					// Valor do Contrato de cambio maior que Zero
					if (dValor == 0)
					{
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_SeuContratoCambioDeveTerUmValorMaioqQueZero));
						return(false);
					}

					// Inserindo Contrato de Cambio
					mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambioInserir = m_typDatSetContratosCambio.tbContratosCambio.NewtbContratosCambioRow();

					dtrwContratoCambioInserir.nIdExportador = m_nIdExportador;
					dtrwContratoCambioInserir.nIdExportadorBanco = nIdBanco;
					dtrwContratoCambioInserir.nIdContratoCambio = nNextContratoCambio();
					dtrwContratoCambioInserir.nTipoContrato = (int)TipoContrato.Exportacao;
					dtrwContratoCambioInserir.nTipoContratacao = (int)enumTipoContratacao;
					dtrwContratoCambioInserir.strNumero = strNumero;
					dtrwContratoCambioInserir.dtEmissao = dtEmissao;
					dtrwContratoCambioInserir.dtVencimento = dtVencimento;
					dtrwContratoCambioInserir.dTaxaCambial = dTaxaCambial;
					dtrwContratoCambioInserir.nIdMoeda = m_nMoeda;
					dtrwContratoCambioInserir.dValor = dValor;

					m_typDatSetContratosCambio.tbContratosCambio.AddtbContratosCambioRow(dtrwContratoCambioInserir);

					bRetorno = true;
					return(bRetorno);
				}
			#endregion
			#region Banco Dados
				private bool bSalvaDados()
				{
					bool bRetorno = false;
					bRetorno = bSalvaDadosContratosCambio();
					bSalvaDadosProdutosBordero();
					return(bRetorno);
				}

				private bool bSalvaDadosContratosCambio()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbContratosCambio(m_typDatSetContratosCambio);
					if (bRetorno = (m_cls_dba_ConnectionDB.Erro == null))
						vSiscoMensagemUpdate();
					return(bRetorno);
				}

				private bool bSalvaDadosProdutosBordero()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbProdutosBordero(m_typDatSetProdutosBordero);
					bRetorno = true;
					return(bRetorno);
				}
			#endregion
		#endregion
		#region SiscoMensagem
			private void vSiscoMensagemUpdate()
			{
				mdlControladoraWindowsServices.clsManagerWSSiscoMensagem objSiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
				objSiscoMensagem.vUpdate();
			}
		#endregion

		#region Next
			private int nNextContratoCambio()
			{
				int nRetorno = 1;
				bool bExiste = true;
				while (bExiste)
				{
					bExiste = false;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
					{
						if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwContratoCambio.nIdContratoCambio == nRetorno)
							{
								bExiste = true;
								break;
							}
						}
					}
					if(bExiste)
						nRetorno++;
				}
				return(nRetorno);
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				m_formFContratoCambio = new frmFContratoCambio(m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFContratoCambio);
				m_formFContratoCambio.ShowDialog();
				m_bModificado = m_formFContratoCambio.m_bModificado;
				m_formFContratoCambio = null;
			}

			private void vInitializeEvents(ref frmFContratoCambio formFContratoCambio)
			{
				// Refresh Contratos Cambio
				m_formFContratoCambio.eCallRefreshContratosCambio += new mdlContratoCambio.frmFContratoCambio.delCallRefreshContratosCambio(vRefreshContratosCambio);

				// ShowDialogConfiguracoes
				m_formFContratoCambio.eCallShowConfiguracoes += new mdlContratoCambio.frmFContratoCambio.delCallShowConfiguracoes(ShowDialogConfiguracoes);

				// ShowDialogContratoNovo
				m_formFContratoCambio.eCallShowContratoNovo += new mdlContratoCambio.frmFContratoCambio.delCallShowContratoNovo(ShowDialogContratoNovo);

				// Remover Contrato Cambio
				m_formFContratoCambio.eCallShowContratoRemover += new mdlContratoCambio.frmFContratoCambio.delCallShowContratoRemover(bRemoverContratoCambio);

				// ShowDialogContratoInformacoes
				m_formFContratoCambio.eCallShowContratoInformacoes += new mdlContratoCambio.frmFContratoCambio.delCallShowContratoInformacoes(ShowDialogContratoInformacoes);

				// Salva Dados
				m_formFContratoCambio.eCallSalvaDados += new mdlContratoCambio.frmFContratoCambio.delCallSalvaDados(bSalvaDados);

			}
		#endregion
		#region ShowDialogConfiguracoes
			private void ShowDialogConfiguracoes()
			{
				frmFConfiguracoes formFConfiguracoes = new frmFConfiguracoes(m_strEnderecoExecutavel,m_bMostrarContratosComSaldo,m_bMostrarContratosSemSaldo,m_bMostrarAcc,m_bMostrarAce);
				formFConfiguracoes.ShowDialog();
				if (formFConfiguracoes.m_bModificado)
				{
					formFConfiguracoes.vRetornaValores(out m_bMostrarContratosComSaldo,out m_bMostrarContratosSemSaldo,out m_bMostrarAcc,out m_bMostrarAce);
					m_formFContratoCambio.OnCallRefreshContratosCambio();
				}
				formFConfiguracoes = null;
			}
		#endregion
		#region ShowDialogContratoNovo
			private void ShowDialogContratoNovo()
			{
				frmFContratoCambioNovo formFContratoCambioNovo = new frmFContratoCambioNovo(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFContratoCambioNovo);
				formFContratoCambioNovo.ShowDialog();
				if (formFContratoCambioNovo.m_bModificado)
					m_formFContratoCambio.OnCallRefreshContratosCambio();
				formFContratoCambioNovo = null;
			}

			private void vInitializeEvents(ref frmFContratoCambioNovo formFContratoCambioNovo)
			{
				// Carrega Bancos
				formFContratoCambioNovo.eCallCarregaBancos += new mdlContratoCambio.frmFContratoCambioNovo.delCallCarregaBancos(vRefreshBancos);

				// Carrega Simbolo Moeda
				formFContratoCambioNovo.eCallCarregaSimboloMoeda += new mdlContratoCambio.frmFContratoCambioNovo.delCallCarregaSimboloMoeda(vCarregaSimboloMoeda);

				// Show Dialog Bancos 
				formFContratoCambioNovo.eCallShowDialogBancos += new mdlContratoCambio.frmFContratoCambioNovo.delCallShowDialogBancos(ShowDialogBancos);

				// Show Dialog Moedas
				formFContratoCambioNovo.eCallShowDialogMoeda += new mdlContratoCambio.frmFContratoCambioNovo.delCallShowDialogMoeda(ShowDialogMoedas);

				// Salva Dados
				formFContratoCambioNovo.eCallSalvaDados += new mdlContratoCambio.frmFContratoCambioNovo.delCallSalvaDados(bSalvaDadosInterface);
			}
		#endregion
		#region ShowDialogContratoInformacoes
			private bool ShowDialogContratoInformacoes(int nContratoCambio)
			{
				bool bRetorno = false;
				frmFContratoCambioInformacoes formFContratoCambioInformacoes = new frmFContratoCambioInformacoes(m_strEnderecoExecutavel,nContratoCambio);
				vInitilizeEvents(ref formFContratoCambioInformacoes);
				// Status Save
				mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetContratosCambio = (mdlDataBaseAccess.Tabelas.XsdTbContratosCambio)m_typDatSetContratosCambio.Copy();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero = (mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero)m_typDatSetProdutosBordero.Copy();
				formFContratoCambioInformacoes.ShowDialog();
				if (bRetorno = formFContratoCambioInformacoes.m_bModificado)
				{
					m_formFContratoCambio.OnCallRefreshContratosCambio();
				}else{
					// Status Load
					m_typDatSetContratosCambio = typDatSetContratosCambio;
					m_typDatSetProdutosBordero = typDatSetProdutosBordero;
				}
				return(bRetorno);
			}
			
			private void vInitilizeEvents(ref frmFContratoCambioInformacoes formFContratoCambioInformacoes)
			{
				// Carrega Dados
				formFContratoCambioInformacoes.eCallCarregaDados += new mdlContratoCambio.frmFContratoCambioInformacoes.delCallCarregaDados(vCarregaDadosContratoInformacoes);

				// Refresh Vinculos
				formFContratoCambioInformacoes.eCallRefreshVinculos += new mdlContratoCambio.frmFContratoCambioInformacoes.delCallRefreshVinculos(vRefreshVinculos);

				// Cancelar Saldo
				formFContratoCambioInformacoes.eCallCancelarSaldo += new mdlContratoCambio.frmFContratoCambioInformacoes.delCallCancelarSaldo(bContratoCancelarSaldo);

				// Vinculo Liquidar
				formFContratoCambioInformacoes.eCallVinculacaoLiquidar += new mdlContratoCambio.frmFContratoCambioInformacoes.delCallVinculacaoLiquidar(bVinculoLiquidar);
                
				// Vinculo Excluir
				formFContratoCambioInformacoes.eCallVinculacaoExcluir += new mdlContratoCambio.frmFContratoCambioInformacoes.delCallVinculacaoExcluir(bVinculoExcluir);

			}
		#endregion
		#region ShowDialogBancos
			private bool ShowDialogBancos()
			{
				bool bRetorno = false;
				mdlBancos.clsBancoExportador cls_banco = new mdlBancos.BancoExportador.clsBancoExportadorGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
				cls_banco.ShowDialog();
				if (bRetorno = cls_banco.m_bModificado)
				{
					vCarregaDadosBancos();
				}
				return(bRetorno);
			}
		#endregion
		#region ShowDialogMoedas
			private bool ShowDialogMoedas()
			{
				bool bRetorno = false;
				mdlMoeda.clsMoeda cls_Moedas = new mdlMoeda.clsMoedaGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				cls_Moedas.MostrarQuestionamentoSimboloMoeda = false;
				if (m_nMoeda != -1)
					cls_Moedas.Moeda = m_nMoeda;
				cls_Moedas.ShowDialog();
				if (bRetorno = cls_Moedas.m_bModificado)
				{
					string strDescricao;
					bool bTemp;
					cls_Moedas.retornaValores(out m_nMoeda,out strDescricao,out m_strSimboloMoeda,out bTemp);
				}
				cls_Moedas = null;
				return(bRetorno);
			}
		#endregion

		#region ContratoCambio
			public int[] arrnContratosCambio()
			{
				int[] nReturn;
				System.Collections.ArrayList arlReturn = new System.Collections.ArrayList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
						arlReturn.Add(dtrwContratoCambio.nIdContratoCambio);
				nReturn = new int[arlReturn.Count];
				for(int i = 0;i < arlReturn.Count;i++)
					nReturn[i] = Int32.Parse(arlReturn[i].ToString());
				return(nReturn);
			}

			public string strNumeroContrato(int nContratoCambio)
			{
				string strRetorno = "";
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							strRetorno = dtrwContratoCambio.strNumero;
							break;
						}
					}
				}
				return(strRetorno);
			}

			public string strContratacaoContrato(int nContratoCambio)
			{
				string strRetorno = "";
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							strRetorno = ((TipoContratacao)dtrwContratoCambio.nTipoContratacao).ToString();
							break;
						}
					}
				}
				return(strRetorno);
			}

			private int nMoedaContrato(int nContratoCambio)
			{
				int nRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							nRetorno = dtrwContratoCambio.nIdMoeda;
							break;
						}
					}
				}
				return(nRetorno);
			}

			private double dValorTotalContratoCambio(int nContratoCambio)
			{
				double dRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							dRetorno = dtrwContratoCambio.dValor;
							break;
						}
					}
				}
				return(dRetorno);
			}

			private double dSaldoCanceladoContratoCambio(int nContratoCambio)
			{
				double dRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							if (!dtrwContratoCambio.IsdSaldoCanceladoNull())
								dRetorno = dtrwContratoCambio.dSaldoCancelado;
							break;
						}
					}
				}
				return(dRetorno);
			}

			public double dSaldoContratoCambio(int nContratoCambio)
			{
				return(dSaldoContratoCambio(nContratoCambio,dValorTotalContratoCambio(nContratoCambio)));
			}

			private double dSaldoContratoCambio(int nContratoCambio,double dValorTotal)
			{
				double dRetorno = dValorTotal;
				if (dSaldoCanceladoContratoCambio(nContratoCambio) == 0)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwBordero in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
					{
						if (dtrwBordero.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwBordero.nIdContratoCambio == nContratoCambio)
							{
								dRetorno -= (dtrwBordero.dValor * dtrwBordero.dTaxaCambial);
								dRetorno = mdlConversao.clsTruncamento.dTrunca(dRetorno,0.001d);
							}
						}
					}
				}else{
					dRetorno = 0;
				}
				return(dRetorno);
			} 

			private bool bRemoverContratoCambio(int nContratoCambio)
			{
				bool bRetorno = false;
				double dValorTotal = dValorTotalContratoCambio(nContratoCambio);
				double dSaldo = dSaldoContratoCambio(nContratoCambio,dValorTotal);
				if (dValorTotal == dSaldo)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
					{
						if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
							{
								dtrwContratoCambio.Delete();
								bRetorno = true;
								break;
							}
						}
					}
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContratoCambio_clsContratoCambio_VoceNaoPodeExcluirUmContratoComVinculos));
				}
				return(bRetorno);
			}

			private bool bContratoCancelarSaldo(int nContratoCambio,bool bCancelarSaldo)
			{
				bool bRetorno = false;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							if (bCancelarSaldo)
							{
								dtrwContratoCambio.dSaldoCancelado = 1;
							}else{
								dtrwContratoCambio.dSaldoCancelado = 0;
							}
							bRetorno = true;
							break;
						}
					}
				}
				return(bRetorno);
			}
			
		#endregion
		#region ProdutosBordero
			private bool bVinculoLiquidar(int nContratoCambio,string strIdPe)
			{
				bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto = m_typDatSetProdutosBordero.tbProdutosBordero.FindBynIdExportadorstrIdPenIdContratoCambio(m_nIdExportador,strIdPe,nContratoCambio);
				if ((dtrwProduto != null) && (dtrwProduto.RowState != System.Data.DataRowState.Deleted))
				{
					dtrwProduto.bLiquidado = !dtrwProduto.bLiquidado;
					bRetorno = true;
				}
				return(bRetorno);
			}

			private bool bVinculoExcluir(int nContratoCambio,string strIdPe)
			{
				bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto = m_typDatSetProdutosBordero.tbProdutosBordero.FindBynIdExportadorstrIdPenIdContratoCambio(m_nIdExportador,strIdPe,nContratoCambio);
				if ((dtrwProduto != null) && (dtrwProduto.RowState != System.Data.DataRowState.Deleted))
				{
					if (!dtrwProduto.bLiquidado)
					{
						dtrwProduto.Delete();
						bRetorno = true;
					}
				}
				return(bRetorno);
			}
		#endregion
		#region Banco
			private string strBanco(int nIdBanco)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwBanco = m_typDatSetBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,nIdBanco);
				if (dtrwBanco != null)
					strRetorno = dtrwBanco.strNome;
				return(strRetorno);
			}
		#endregion

		#region Refresh
			private void vRefreshContratosCambio(ref mdlComponentesGraficos.ListView lvContratosCambio)
			{
				System.Windows.Forms.ListViewItem lviContrato;
				lvContratosCambio.Items.Clear();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwContratoCambio.nTipoContratacao == (int)TipoContratacao.ACC) && (!m_bMostrarAcc))
							continue;
						if ((dtrwContratoCambio.nTipoContratacao == (int)TipoContratacao.ACE) && (!m_bMostrarAce))
							continue;
						double dValorTotal = dValorTotalContratoCambio(dtrwContratoCambio.nIdContratoCambio);
						double dSaldo = dSaldoContratoCambio(dtrwContratoCambio.nIdContratoCambio,dValorTotal);
						dSaldo = System.Math.Round(dSaldo,5);
						if ((dSaldo == 0) && (!m_bMostrarContratosSemSaldo))
							continue;
						if ((dSaldo > 0) && (!m_bMostrarContratosComSaldo))
							continue;

						lviContrato = lvContratosCambio.Items.Add(dtrwContratoCambio.strNumero);
						lviContrato.Tag = dtrwContratoCambio.nIdContratoCambio;
						lviContrato.SubItems.Add(strBanco(dtrwContratoCambio.nIdExportadorBanco));
						lviContrato.SubItems.Add(((TipoContratacao)dtrwContratoCambio.nTipoContratacao).ToString());
						lviContrato.SubItems.Add(dtrwContratoCambio.dtEmissao.ToString("dd/MM/yyyy"));
						lviContrato.SubItems.Add(dtrwContratoCambio.dtVencimento.ToString("dd/MM/yyyy"));
						lviContrato.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dValorTotal,true));
						lviContrato.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dSaldo,true));
						if (dSaldo > 0)
							lviContrato.ForeColor = System.Drawing.Color.DarkRed;
						else
							lviContrato.ForeColor = System.Drawing.Color.DarkGreen;
						lviContrato = null;
					}
				}
			}

			private void vRefreshBancos(ref mdlComponentesGraficos.ComboBox cbBancos)
			{
				cbBancos.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwBanco;
				for(int nCont = 0;nCont < m_typDatSetBancos.tbExportadoresBancos.Rows.Count; nCont++)
				{
					dtrwBanco = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow)m_typDatSetBancos.tbExportadoresBancos.Rows[nCont];
					cbBancos.AddItem(dtrwBanco.strNome,dtrwBanco.nIdBanco);
				} 
				if (cbBancos.Items.Count > 0)
					cbBancos.Text = cbBancos.Items[0].ToString();
			}

			private void vRefreshVinculos(int nContratoCambio,ref mdlComponentesGraficos.ListView lvVinculos)
			{
				System.Windows.Forms.ListViewItem lviProduto = null;
				lvVinculos.Items.Clear();
				int nMoeda = nMoedaContrato(nContratoCambio);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProduto.nIdContratoCambio == nContratoCambio)
						{
							lviProduto = lvVinculos.Items.Add(dtrwProduto.strIdPe);
							lviProduto.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(nMoeda,dtrwProduto.dValor,true));
							lviProduto.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwProduto.nIdMoeda,(dtrwProduto.dValor * dtrwProduto.dTaxaCambial),true));
							if (dtrwProduto.bLiquidado)
								lviProduto.SubItems.Add("Sim");
							else
								lviProduto.SubItems.Add("Não");
						}
					}
				}
			}
		#endregion
	}
}
