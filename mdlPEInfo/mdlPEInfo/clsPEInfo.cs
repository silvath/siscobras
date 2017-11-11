using System;

namespace mdlPEInfo
{
	/// <summary>
	/// Summary description for clsPEInfo.
	/// </summary>
	public class clsPEInfo
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = "";

		protected bool m_bMostrarBaloes = true;
		protected bool m_bMostrarDialogImpressao = true;
        
		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		protected bool m_bModificado = false;

		protected System.Windows.Forms.Form m_formParent;

		private frmFPEInfo m_formFPEInfo = null;

		private bool m_bExisteFaturaProforma = false;
		private bool m_bExisteFaturaComercial = false;
		private bool m_bExisteCertificadoOrigemMercosul = false;
		private bool m_bExisteCertificadoOrigemMercosulBolivia = false;
		private bool m_bExisteCertificadoOrigemMercosulChile = false;
		private bool m_bExisteCertificadoOrigemAladiAce39 = false;
		private bool m_bExisteCertificadoOrigemAladiAptr04 = false;
		private bool m_bExisteCertificadoOrigemAnexoIII = false;
		private bool m_bExisteCertificadoOrigemComum = false;
		private bool m_bExisteRomaneioProdutos = false;
		private bool m_bExisteRomaneioVolumes = false;
		private bool m_bExisteRomaneioSimplificado = false;
		private bool m_bExisteSaque = false;
		private bool m_bExisteReserva = false;
		private bool m_bExisteOrdemEmbarque = false;
		private bool m_bExisteGuiaEntrada = false;
		private bool m_bExisteBordero = false;
		private bool m_bExisteBorderoSecundario = false;
		private bool m_bExisteSumario = false;
		private bool m_bExistePersonalizado = false;
		private int m_nBorderosSecundarios = 0;
		#endregion
		#region Propriedades
			public bool FaturaProforma
			{
				get
				{
					return(m_bExisteFaturaProforma);
				}
			}

			public bool FaturaComercial
			{
				get
				{
					return(m_bExisteFaturaComercial);
				}
			}

			public bool CertificadoOrigem
			{
				get
				{
					return(this.CertificadoOrigemMercosul || this.CertificadoOrigemMercosulBolivia || this.CertificadoOrigemMercosulChile || this.CertificadoOrigemAladiAptr04 || this.CertificadoOrigemAladiAce39 || this.m_bExisteCertificadoOrigemAnexoIII || this.CertificadoOrigemComum);
				}
			} 

			public bool CertificadoOrigemMercosul			
			{
				get
				{
					return(m_bExisteCertificadoOrigemMercosul);
				}
			} 

			public bool CertificadoOrigemMercosulBolivia			
			{
				get
				{
					return(m_bExisteCertificadoOrigemMercosulBolivia);
				}
			} 

			public bool CertificadoOrigemMercosulChile			
			{
				get
				{
					return(m_bExisteCertificadoOrigemMercosulChile);
				}
			} 

			public bool CertificadoOrigemAladiAce39			
			{
				get
				{
					return(m_bExisteCertificadoOrigemAladiAce39);
				}
			} 

			public bool CertificadoOrigemAladiAptr04			
			{
				get
				{
					return(m_bExisteCertificadoOrigemAladiAptr04);
				}
			} 

			public bool CertificadoOrigemAnexoIII			
			{
				get
				{
					return(m_bExisteCertificadoOrigemAnexoIII);
				}
			} 

			public bool CertificadoOrigemComum			
			{
				get
				{
					return(m_bExisteCertificadoOrigemComum);
				}
			} 

			public bool Romaneio
			{
				get
				{
					return(this.RomaneioProdutos || this.RomaneioVolumes || this.RomaneioSimplificado);
				}
			}

			public bool RomaneioProdutos			
			{
				get
				{
					return(m_bExisteRomaneioProdutos);
				}
			} 

			public bool RomaneioVolumes			
			{
				get
				{
					return(m_bExisteRomaneioVolumes);
				}
			} 

			public bool RomaneioSimplificado			
			{
				get
				{
					return(m_bExisteRomaneioSimplificado);
				}
			} 

			public bool Saque
			{
				get
				{
					return(m_bExisteFaturaComercial);
				}
			} 

			public bool Reserva			
			{
				get
				{
					return(m_bExisteReserva);
				}
			} 

			public bool OrdemEmbarque			
			{
				get
				{
					return(m_bExisteOrdemEmbarque);
				}
			} 

			public bool GuiaEntrada			
			{
				get
				{
					return(m_bExisteGuiaEntrada);
				}
			} 

			public bool Bordero			
			{
				get
				{
					return(m_bExisteBordero);
				}
			} 

			public bool BorderoSecundario			
			{
				get
				{
					return(m_bExisteBorderoSecundario);
				}
			} 

			public bool Sumario			
			{
				get
				{
					return(m_bExisteSumario);
				}
			} 

			public bool Personalizado
			{
				get
				{
					return(m_bExistePersonalizado);
				}
			} 
		#endregion
		#region Construtors and Destrutors
			public clsPEInfo(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				vCarregaDados();
			}

			public clsPEInfo(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,ref System.Windows.Forms.Form formParent,int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_formParent = formParent;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			private void vCarregaDados()
			{
				try
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoCampo2 = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoCampo2.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoCampo2.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					// Fatura Proforma
					mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteFaturaProforma = (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0);

					// Fatura Comercial
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteFaturaComercial = (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0);

					// Certificados Origem
					m_bExisteCertificadoOrigemMercosul = m_bExisteCertificadoOrigemMercosulBolivia = m_bExisteCertificadoOrigemMercosulChile = m_bExisteCertificadoOrigemAladiAce39 = m_bExisteCertificadoOrigemAladiAptr04 = m_bExisteCertificadoOrigemAnexoIII = m_bExisteCertificadoOrigemComum = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = 0; i < m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count; i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwAtual = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[i];
						switch(dtrwAtual.idTipoCO)
						{
							case (int)mdlConstantes.CertificadoOrigem.Mercosul:
								m_bExisteCertificadoOrigemMercosul = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.MercosulBolivia:
								m_bExisteCertificadoOrigemMercosulBolivia = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.MercosulChile:
								m_bExisteCertificadoOrigemMercosulChile = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.AladiAce39:
								m_bExisteCertificadoOrigemAladiAce39 = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.AladiAptr04:
								m_bExisteCertificadoOrigemAladiAptr04 = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.AnexoIII:
								m_bExisteCertificadoOrigemAnexoIII = true;
								break;
							case (int)mdlConstantes.CertificadoOrigem.Comum:
								m_bExisteCertificadoOrigemComum = true;
								break;
						}
					}

					//Romaneio
					m_bExisteRomaneioProdutos = m_bExisteRomaneioVolumes = m_bExisteRomaneioSimplificado = false;
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					for(int i = 0; i < m_typDatSetTbRomaneios.tbRomaneios.Rows.Count; i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwAtual = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[i];
						switch(dtrwAtual.nTipoOrdenacao)
						{
							case (int)mdlConstantes.Relatorio.Romaneio:
								m_bExisteRomaneioProdutos = true;
								break;
							case (int)mdlConstantes.Relatorio.RomaneioVolumes:
								m_bExisteRomaneioVolumes = true;
								break;
							case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
								m_bExisteRomaneioSimplificado = true;
								break;
						}
					}

					// Saque
					mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteSaque = (m_typDatSetTbSaques.tbSaques.Rows.Count > 0);

					// Reserva
					mdlDataBaseAccess.Tabelas.XsdTbReservas m_typDatSetTbReservas = m_cls_dba_ConnectionDB.GetTbReservas(arlCondicaoCampo2,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteReserva = (m_typDatSetTbReservas.tbReservas.Rows.Count > 0);

					// Ordem Embarque 
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteOrdemEmbarque = (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0);

					// GuiaEntrada
					mdlDataBaseAccess.Tabelas.XsdTbGuiasEntrada m_typDatSetTbGuiasEntrada = m_cls_dba_ConnectionDB.GetTbGuiasEntrada(arlCondicaoCampo2,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (m_bExisteGuiaEntrada = (m_typDatSetTbGuiasEntrada.tbGuiasEntrada.Rows.Count > 0))
					{
						mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers m_typDatSetTbProcessosContainers = m_cls_dba_ConnectionDB.GetTbProcessosContainers(arlCondicaoCampo2,arlCondicaoComparador,arlCondicaoValor,null,null);
						m_bExisteGuiaEntrada = (m_typDatSetTbProcessosContainers.tbProcessosContainers.Rows.Count > 0);
					}

					// Bordero
					mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteBordero = (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0);

					// Bordero Secundario
					mdlDataBaseAccess.Tabelas.XsdTbBorderosSecundarios m_typDatSetTbBorderosSecundarios = m_cls_dba_ConnectionDB.GetTbBorderosSecundarios(arlCondicaoCampo2,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (m_bExisteBorderoSecundario = (m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count > 0))
						m_nBorderosSecundarios = m_typDatSetTbBorderosSecundarios.tbBorderosSecundarios.Rows.Count; 

					// Sumario
					mdlDataBaseAccess.Tabelas.XsdTbSumarios m_typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_bExisteSumario = (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0);

					// Personalizado
					m_bExistePersonalizado = false;
					mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwProcesso = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
						m_bExistePersonalizado = ((!dtrwProcesso.IsnIdRelatorioIndefinidoNull()) && (dtrwProcesso.nIdRelatorioIndefinido != -1));
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

		#region Show
			public void Show()
			{
				try
				{
					m_formFPEInfo = new frmFPEInfo(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMostrarBaloes);
					vInitializeEvents(ref m_formFPEInfo);
					m_formFPEInfo.MdiParent = m_formParent;
					m_formFPEInfo.Show();
					m_formFPEInfo.setHabilitacaoBotoes(this.FaturaProforma,this.CertificadoOrigem,this.Reserva,this.OrdemEmbarque,this.GuiaEntrada,this.Romaneio, this.Saque,this.Bordero);
					m_formFPEInfo.BringToFront();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void vInitializeEvents(ref frmFPEInfo formFPEInfo)
			{
				// Imprimssao Sumario
				formFPEInfo.eCallImprimeSumario += new mdlPEInfo.frmFPEInfo.delCallImprimeSumario(vImprimeSumario);

				// Impressão Fatura Proforma
				formFPEInfo.eCallImprimeFaturaProforma += new frmFPEInfo.delCallImprimeFaturaProforma(imprimeFaturaProforma);

				// Impressão Fatura Comercial
				formFPEInfo.eCallImprimeFaturaComercial += new frmFPEInfo.delCallImprimeFaturaComercial(imprimeFaturaComercial);
	
				// Impressão Certificados Origem
				formFPEInfo.eCallImprimeCertificadosOrigem += new mdlPEInfo.frmFPEInfo.delCallImprimeCertificadosOrigem(vImprimeCertificadosOrigem);
				
				// Impressão Reserva
				formFPEInfo.eCallImprimeReserva += new mdlPEInfo.frmFPEInfo.delCallImprimeReserva(vImprimeReserva);

				// Impressão Instruções Embarque
				formFPEInfo.eCallImprimeInstrucoesEmbarque += new frmFPEInfo.delCallImprimeInstrucoesEmbarque(imprimeInstrucoesEmbarque);

				// Impressão Guia Entrada
				formFPEInfo.eCallImprimeGuiaEntrada += new mdlPEInfo.frmFPEInfo.delCallImprimeGuiaEntrada(vImprimeGuiaEntrada);

				// Impressão Romaneio
				formFPEInfo.eCallImprimeRomaneio += new frmFPEInfo.delCallImprimeRomaneio(imprimeRomaneio);

				// Impressão Saque
				formFPEInfo.eCallImprimeSaque += new frmFPEInfo.delCallImprimeSaque(imprimeSaque);

				// Impressão Borderô
				formFPEInfo.eCallImprimeBordero += new frmFPEInfo.delCallImprimeBordero(imprimeBordero);

				// Impressão Todos
				formFPEInfo.eCallImprimeTodos += new frmFPEInfo.delCallImprimeTodos(imprimeTodosDocumentos);
			}

			public void Close()
			{
				try
				{
					if (m_formFPEInfo != null)
						m_formFPEInfo.Close();
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

		#region Impressão
		#region Sumario
			private void vImprimeSumario()
			{
				try
				{
					if (m_bExisteSumario)
					{
						mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.Sumario);
						obj.bImprime(m_bMostrarDialogImpressao);
					}
					else
					{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_FPNaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
					}
				}
				catch (Exception err)
				{
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion

		#region Fatura Proforma
		private void imprimeFaturaProforma()
		{
			try
			{
				if (this.FaturaProforma)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.FaturaProforma);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_FPNaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Fatura Comercial
		private void imprimeFaturaComercial()
		{
			try
			{
				if (this.FaturaComercial)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.FaturaComercial);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Certificados de Origem
			private void vImprimeCertificadosOrigem()
			{
				if (this.CertificadoOrigem)
				{
					vImprimeCertificadosOrigemMercosul();
					vImprimeCertificadosOrigemMercosulBolivia();
					vImprimeCertificadosOrigemMercosulChile();
					vImprimeCertificadosOrigemAladiAptr04();
					vImprimeCertificadosOrigemAladiAce39();
					vImprimeCertificadosOrigemComum();
					vImprimeCertificadoOrigemAnexoIII();
				}
			}

			private void vImprimeCertificadosOrigemMercosul()
			{
				if (this.CertificadoOrigemMercosul)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemMercosul);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadosOrigemMercosulBolivia()
			{
				if (this.CertificadoOrigemMercosulBolivia)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemMercosulBO);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadosOrigemMercosulChile()
			{
				if (this.CertificadoOrigemMercosulChile)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemMercosulCH);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadosOrigemAladiAptr04()
			{
				if (this.CertificadoOrigemAladiAptr04)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadosOrigemAladiAce39()
			{
				if (this.CertificadoOrigemAladiAce39)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemAladiAce39);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadosOrigemComum()
			{
				if (this.CertificadoOrigemComum)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemComum);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

			private void vImprimeCertificadoOrigemAnexoIII()
			{
				if (this.CertificadoOrigemAnexoIII)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.CertificadoOrigemAnexoIII);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}

		#endregion
		#region Reserva
			private void vImprimeReserva()
			{
				if (this.Reserva)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.Reserva);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}
		#endregion
		#region GuiaEntrada
			private void vImprimeGuiaEntrada()
			{
				if (this.GuiaEntrada)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.GuiaEntrada);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
			}
		#endregion
		#region Instrucoes Embarque
		private void imprimeInstrucoesEmbarque()
		{
			try
			{
				if (this.OrdemEmbarque)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.InstrucaoEmbarque);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_OENaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Romaneio
		private void imprimeRomaneio()
		{
			try
			{
				if (this.Romaneio)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.Romaneio);
					obj.bImprime(m_bMostrarDialogImpressao);
					vCarregaDados();
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_RMNaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Saque
		private void imprimeSaque()
		{
			try
			{
				if (this.Saque)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.Saque);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_SQNaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Borderô
		private void imprimeBordero()
		{
			try
			{
				if (m_bExisteBordero)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao obj = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB, ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, mdlConstantes.Relatorio.Bordero);
					obj.bImprime(m_bMostrarDialogImpressao);
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPEInfo_clsPEInfo_BDNaoExiste.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Todos
		private void imprimeTodosDocumentos()
		{
			try
			{
				imprimeFaturaProforma();
				m_bMostrarDialogImpressao = false;
				imprimeFaturaComercial();
				vImprimeCertificadosOrigem();
				vImprimeReserva();
				imprimeInstrucoesEmbarque();
				vImprimeGuiaEntrada();
				imprimeRomaneio();
				imprimeSaque();
				imprimeBordero();
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
	}
}