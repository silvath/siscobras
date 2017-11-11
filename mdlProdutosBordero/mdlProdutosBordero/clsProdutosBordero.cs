using System;

namespace mdlProdutosBordero
{
	/// <summary>
	/// Summary description for clsProdutosBordero.
	/// </summary>
	public class clsProdutosBordero
	{
		#region Constants 
			private const int MAXDECIMALS = 8;
		#endregion
		#region Atributes 
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;

			// Formularios
			private frmFProdutosBordero m_formFProdutosBordero = null;

			// TypedDatSets 
			private mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos m_typDatSetBancos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbContratosCambio m_typDatSetContratosCambio = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero m_typDatSetProdutosBordero = null;

			private mdlDataBaseAccess.Tabelas.XsdTbMoedas m_typDatSetMoedas = null;

			// Fatura 
			private decimal m_dcValorFatura = 0;
			private int m_nMoeda = -1;
			public bool m_bModificado = false;
		#endregion
		#region Properties
			public bool HasProducts
			{
				get
				{
					if (m_typDatSetProdutosBordero == null)
						return(false);
					return(m_typDatSetProdutosBordero.tbProdutosBordero.Rows.Count > 0);
				}
			}
		#endregion
		#region Constructors and Destructors 
		public clsProdutosBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB , string strEnderecoExecutavel,int idExportador, string idPe)
		{
			m_cls_ter_tratadorErro = tratadorErro; 
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel; 

			m_strIdPe = idPe;
			m_nIdExportador = idExportador;

			vCarregaDados();
		}
		#endregion

		#region Carregamento Dados
			#region Banco Dados
				private void vCarregaDados()
				{
					m_cls_dba_ConnectionDB.DataPersist = false;

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

					// Contratos Cambio
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Produtos Bordero
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Moedas
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(null,null,null,null,null);

					vCarregaDadosFaturaComercial();
				}
				
				private void vCarregaDadosFaturaComercial()
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];

						// Moeda 
						if (!dtrwFaturaComercial.IsidMoedaNull())
							m_nMoeda = dtrwFaturaComercial.idMoeda;
					
						// Produtos Fatura 
						mdlIncoterm.clsManipuladorValor obj = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPe);
						double dValorFatura; 
						obj.vRetornaValores(out dValorFatura);
						m_dcValorFatura = (decimal)dValorFatura;

						// Removendo a Comissao por Conta Grafica 
						mdlAgentes.clsAgenteVendaComissao agenteVenda = new mdlAgentes.clsAgenteVendaComissao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
						m_dcValorFatura = m_dcValorFatura - agenteVenda.GetComissaoContaGrafica(m_nIdExportador,m_strIdPe);
					}
				}
			#endregion
			#region Interface
				private void vCarregaValores(out string strValorFatura,out string strValorVinculado,out string strSaldo)
				{
					strValorFatura = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoeda,m_dcValorFatura,true);
					decimal dcValorFaturaVinculado = dcValorVinculado();
					strValorVinculado = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoeda,dcValorFaturaVinculado,true);
					strSaldo = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoeda,m_dcValorFatura - dcValorFaturaVinculado,true);
				}
			#endregion
		#endregion
		#region Salvamento Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				try
				{
					m_cls_dba_ConnectionDB.SetTbProdutosBordero(m_typDatSetProdutosBordero);
					bRetorno = true;
				}catch{
					bRetorno = false;
				}
				return(bRetorno);
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				m_formFProdutosBordero = new frmFProdutosBordero(m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFProdutosBordero);
				m_formFProdutosBordero.ShowDialog();
				m_bModificado = m_formFProdutosBordero.m_bModificado;
				m_formFProdutosBordero = null;
			}

			private void vInitializeEvents(ref frmFProdutosBordero formFProdutosBordero)
			{
				// Carrega Valores
				formFProdutosBordero.eCallCarregaValores += new mdlProdutosBordero.frmFProdutosBordero.delCallCarregaValores(vCarregaValores);

				// Refresh Contratos Cambio
				formFProdutosBordero.eCallRefreshContratosCambio += new mdlProdutosBordero.frmFProdutosBordero.delCallRefreshContratosCambio(vRefeshContratosCambio);

				// Refresh Produtos Bordero
				formFProdutosBordero.eCallRefreshProdutosBordero += new mdlProdutosBordero.frmFProdutosBordero.delCallRefreshProdutosBordero(vRefreshProdutosBordero);

				// Show Dialog Contrato Cambio 
				formFProdutosBordero.eCallShowContratosCambio += new mdlProdutosBordero.frmFProdutosBordero.delCallShowContratosCambio(ShowDialogContratosCambio);

				// Produtos Adiciona 
				formFProdutosBordero.eCallProdutoAdiciona += new mdlProdutosBordero.frmFProdutosBordero.delCallProdutoAdiciona(ShowDialogProdutosBorderoAssociados);

				// Produtos Remove 
				formFProdutosBordero.eCallProdutoRemove += new mdlProdutosBordero.frmFProdutosBordero.delCallProdutoRemove(bRemoveVinculoContratoCambioBordero);

				// Salva Dados
				formFProdutosBordero.eCallSalvaDados += new mdlProdutosBordero.frmFProdutosBordero.delCallSalvaDados(bSalvaDados);

			}
		#endregion
		#region ShowDialogContratosCambio
			private bool ShowDialogContratosCambio()
			{
				bool bRetorno = false;
				bSalvaDados();
				mdlContratoCambio.clsContratoCambio cls_ContratoCambio = new mdlContratoCambio.clsContratoCambio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
				cls_ContratoCambio.ShowDialog();
				if (bRetorno = cls_ContratoCambio.m_bModificado)
				{
					vCarregaDados();
					m_formFProdutosBordero.OnCallRefreshContratosCambio();
					m_formFProdutosBordero.OnCallRefreshProdutosBordero();
				}
				return(bRetorno);
			}
		#endregion
		#region ShowDialogProdutosBorderoAssociados
			private bool ShowDialogProdutosBorderoAssociados(int nIdContratoCambio)
			{
				bool bRetorno = false;
				int nIdMoedaContrato = nMoeda(nIdContratoCambio);
				string strSimboloMoedaContrato = strSimboloMoeda(nIdMoedaContrato);
				string strSimboloMoedaFatura = strSimboloMoeda(m_nMoeda);
				if (nIdMoedaContrato == m_nMoeda)
				{
					decimal dcValorMax = m_dcValorFatura - dcValorVinculado();
					decimal dcSaldoContrato = dcSaldoContratoCambio(nIdContratoCambio);
					if (dcSaldoContrato < dcValorMax)
						dcValorMax = dcSaldoContrato;
					frmFProdutosBorderoAssociar formFProdutosBorderoAssociar = new frmFProdutosBorderoAssociar(m_strEnderecoExecutavel,nIdContratoCambio,nIdMoedaContrato,strSimboloMoedaContrato,dcValorMax);
					formFProdutosBorderoAssociar.ShowDialog();
					if (formFProdutosBorderoAssociar.m_bModificado)
					{
						decimal dcValor;
						formFProdutosBorderoAssociar.vRetornaValores(out dcValor);
						bRetorno = bInsereVinculoContratoCambioBordero(nIdContratoCambio,dcValor,nIdMoedaContrato,1);
					}
				}else{
					decimal dcValorMax = m_dcValorFatura - dcValorVinculado();
					decimal dcSaldoContrato = dcSaldoContratoCambio(nIdContratoCambio);
					frmFProdutosBorderoAssociarTaxaCambio formFProdutosBorderoAssociar = new frmFProdutosBorderoAssociarTaxaCambio(m_strEnderecoExecutavel,nIdContratoCambio,m_nMoeda,strSimboloMoedaFatura,nIdMoedaContrato,strSimboloMoedaContrato,dcValorMax,dcSaldoContrato);
					formFProdutosBorderoAssociar.ShowDialog();
					if (formFProdutosBorderoAssociar.m_bModificado)
					{
						decimal dcValor,dcTaxaCambial;
						formFProdutosBorderoAssociar.vRetornaValores(out dcValor,out dcTaxaCambial);
						bRetorno = bInsereVinculoContratoCambioBordero(nIdContratoCambio,dcValor,nIdMoedaContrato,dcTaxaCambial);
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
		#region Moeda
			private string strSimboloMoeda(int nIdMoeda)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwMoeda = m_typDatSetMoedas.tbMoedas.FindByidMoeda(nIdMoeda);
				if (dtrwMoeda != null)
				{
					strRetorno = dtrwMoeda.simbolo;

				}
				return(strRetorno);
			}
		#endregion
		#region ContratoCambio
			private decimal dcValorTotalContratoCambio(int nContratoCambio)
			{
				decimal dcRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							dcRetorno = (decimal)dtrwContratoCambio.dValor;
							break;
						}
					}
				}
				return(dcRetorno);
			}

			private decimal dcSaldoCanceladoContratoCambio(int nContratoCambio)
			{
				decimal dcRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (dtrwContratoCambio.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwContratoCambio.nIdContratoCambio == nContratoCambio)
						{
							if (!dtrwContratoCambio.IsdSaldoCanceladoNull())
								dcRetorno = (decimal)dtrwContratoCambio.dSaldoCancelado;
							break;
						}
					}
				}
				return(dcRetorno);
			}

			private decimal dcSaldoContratoCambio(int nContratoCambio)
			{
				return(dcSaldoContratoCambio(nContratoCambio,dcValorTotalContratoCambio(nContratoCambio)));
			}

			private decimal dcSaldoContratoCambio(int nContratoCambio,decimal dValorTotal)
			{
				decimal dcRetorno = dValorTotal;
				if (dcSaldoCanceladoContratoCambio(nContratoCambio) == 0)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwBordero in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
					{
						if (dtrwBordero.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwBordero.nIdContratoCambio == nContratoCambio)
							{
								dcRetorno = dcRetorno - ((decimal)dtrwBordero.dValor * (decimal)dtrwBordero.dTaxaCambial);
							}
						}
					}
				}else{
					dcRetorno = 0;
				}
				return(dcRetorno);
			}

			private int nMoeda(int nContratoCambio)
			{
				int nRetorno = -1;
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

			private string strNumeroContratoCambio(int nContratoCambio)
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
 		#endregion
		#region Bordero
			private decimal dcValorVinculado()
			{
                decimal dcRetorno = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
						if (dtrwProduto.strIdPe == m_strIdPe)
							dcRetorno = dcRetorno + (decimal)dtrwProduto.dValor;
				}
				return(dcRetorno);
			}

			private bool bInsereVinculoContratoCambioBordero(int nContratoCambio,decimal dcValor,int nMoeda,decimal dcTaxaCambial)
			{
				bool bRetorno = false;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProdutos = m_typDatSetProdutosBordero.tbProdutosBordero.NewtbProdutosBorderoRow();
				dtrwProdutos.nIdExportador = m_nIdExportador;
				dtrwProdutos.strIdPe = m_strIdPe;
				dtrwProdutos.nIdContratoCambio = nContratoCambio;
				dtrwProdutos.dValor = (double)dcValor;
				dtrwProdutos.nIdMoeda = nMoeda;
				dtrwProdutos.dTaxaCambial = (double)dcTaxaCambial;
				dtrwProdutos.bLiquidado = false;
				dtrwProdutos.nDocumento = 0;
				try
				{
					m_typDatSetProdutosBordero.tbProdutosBordero.AddtbProdutosBorderoRow(dtrwProdutos);
					bRetorno = true;
				}catch{
					bRetorno = false;
				}
				return(bRetorno);
			}

			private bool bVinculoComContratoCambioJaRealizado(int nContratoCambio)
			{
				bool bRetorno = false;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwProduto.nIdContratoCambio == nContratoCambio) && (dtrwProduto.strIdPe == m_strIdPe))
						{
							bRetorno = true;
							break;
						}
					}
				}
				return(bRetorno);
			}
			
			private bool bRemoveVinculoContratoCambioBordero(int nContratoCambio)
			{
				bool bRetorno = false;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwProduto.nIdContratoCambio == nContratoCambio) && (dtrwProduto.nIdExportador == m_nIdExportador) && (dtrwProduto.strIdPe == m_strIdPe))
						{
							bRetorno = true;
							dtrwProduto.Delete();
							break;
						}
					}
				}
				return(bRetorno);
			}

			public bool bRemoveTodosVinculosComContratosCambio()
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPe);

				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetProdutosBordero.tbProdutosBordero.Rows.Count > 0)
				{
					bRetorno = true;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProdutoBordero in  typDatSetProdutosBordero.tbProdutosBordero.Rows)
						dtrwProdutoBordero.Delete();
					m_cls_dba_ConnectionDB.SetTbProdutosBordero(typDatSetProdutosBordero);
				} 
				return(bRetorno);
			}
		#endregion

		#region Refresh
			private void vRefeshContratosCambio(ref mdlComponentesGraficos.ListView lvContratosCambio)
			{
				System.Windows.Forms.ListViewItem lviContrato;
				lvContratosCambio.Items.Clear();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in m_typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					decimal dcValorTotal = dcValorTotalContratoCambio(dtrwContratoCambio.nIdContratoCambio);
					decimal dcSaldo = dcSaldoContratoCambio(dtrwContratoCambio.nIdContratoCambio,dcValorTotal);
					// Removendo os que nao possuem saldo
					if ((dcSaldo == 0))
						continue;
					// Removendo os contratos que ja foram vinculados
					if (bVinculoComContratoCambioJaRealizado(dtrwContratoCambio.nIdContratoCambio))
						continue;
					lviContrato = lvContratosCambio.Items.Add(dtrwContratoCambio.strNumero);
					lviContrato.Tag = dtrwContratoCambio.nIdContratoCambio;
					lviContrato.SubItems.Add(strBanco(dtrwContratoCambio.nIdExportadorBanco));
					lviContrato.SubItems.Add(((mdlContratoCambio.TipoContratacao)dtrwContratoCambio.nTipoContratacao).ToString());
					lviContrato.SubItems.Add(dtrwContratoCambio.dtEmissao.ToString("dd/MM/yyyy"));
					lviContrato.SubItems.Add(dtrwContratoCambio.dtVencimento.ToString("dd/MM/yyyy"));
					lviContrato.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dcValorTotal,true));
					lviContrato.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dcSaldo,true));
					lviContrato = null;
				}
			}

			private void vRefreshProdutosBordero(ref mdlComponentesGraficos.ListView lvProdutos)
			{
				System.Windows.Forms.ListViewItem lviProduto;
				lvProdutos.Items.Clear();

				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in m_typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProduto.strIdPe == m_strIdPe)
						{
							int nIdMoedaContrato = nMoeda(dtrwProduto.nIdContratoCambio);
							lviProduto = lvProdutos.Items.Add(strNumeroContratoCambio(dtrwProduto.nIdContratoCambio));
							lviProduto.Tag = dtrwProduto.nIdContratoCambio;
							lviProduto.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoeda,dtrwProduto.dValor,true));
							lviProduto.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwProduto.nIdMoeda,(dtrwProduto.dValor * dtrwProduto.dTaxaCambial),true));
						}
					}
				}
			}
		#endregion
	}
}
