using System;

namespace mdlPEInfo
{
	/// <summary>
	/// Summary description for clsPDF.
	/// </summary>
	public class clsPDF
	{
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			protected string m_strEnderecoExecutavel = "";

			internal frmFPDF m_formFPDF = null;
			protected frmFExportacaoDocumento m_formFExportacaoDocumento = null;

			protected System.Threading.Thread m_threCriacaoDocumento = null;
			protected System.Windows.Forms.TreeView m_tvDocumentos = null;
			protected int m_nDocumentosTotal = 0;
			protected int m_nDocumentoAtual = 0;

			protected string m_strArquivoDocumento;

			private mdlPEInfo.clsPEInfo m_cls_Pe = null;

			private int m_nIdExportador = -1;
			private string m_strIdPE = "";
		#endregion
		#region Constructor
			public clsPDF(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				m_cls_Pe = new clsPEInfo(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				m_formFPDF = new frmFPDF(controlPaletaDeCores.retornaCorAtual());
				vInitializeEvents(ref m_formFPDF);
				m_formFPDF.ShowDialog();
			}

			private void vInitializeEvents(ref frmFPDF formFPDF)
			{
				//Carrega os Documentos disponíveis
				formFPDF.eCallCarregaDocumentos += new frmFPDF.delCallCarregaDocumentos(vRefreshDocumentos);

				//Carrega o index da imagem do Relatorio
				formFPDF.eCallCarregaIndexImagemRelatorio += new mdlPEInfo.frmFPDF.delCallCarregaIndexImagemRelatorio(nRetornaIndexImagemRelatorio);

				// Salvar PDF
				formFPDF.eCallSalvarPDF += new mdlPEInfo.frmFPDF.delCallSalvarPDF(bGerarPDF);
			}
		#endregion
		#region ShowExportacaoDocumento
			private void vShowExportacaoDocumento()
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				m_formFExportacaoDocumento = new frmFExportacaoDocumento(controlPaletaDeCores.retornaCorAtual());
				vInitializeEvents(ref m_formFExportacaoDocumento);
				m_formFExportacaoDocumento.Show();
			}

			private void vInitializeEvents(ref frmFExportacaoDocumento formFExportacaoDocumento)
			{
				formFExportacaoDocumento.eCallCancelar += new mdlPEInfo.frmFExportacaoDocumento.delCallCancelar(vCancelarThreadCriacaoDocumento);
			}

			private void vCancelarThreadCriacaoDocumento()
			{
				try
				{
					if (m_threCriacaoDocumento != null)
					{
						if (m_threCriacaoDocumento.IsAlive)
							m_threCriacaoDocumento.Abort();
					}
				}catch{
				}
			}

			private void vExportacaoDocumento(int nPorcentagem)
			{
				if (m_formFExportacaoDocumento != null)
					m_formFExportacaoDocumento.Porcentagem = nPorcentagem;
			}

			private void vExportacaoDocumento(string strDocumento)
			{
				if (m_formFExportacaoDocumento != null)
					m_formFExportacaoDocumento.Documento = strDocumento;
			}

			private void vIncrementaMostraPorcentagemDocumentos()
			{
				m_nDocumentoAtual++;
				vExportacaoDocumento((int)(((float)m_nDocumentoAtual / (float)m_nDocumentosTotal) * 100));
			}
		#endregion

		#region Documentos
			private int nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio enumRelatorio)
			{
				return(nRetornaIndexImagemRelatorio((int)enumRelatorio));

			}

			private int nRetornaIndexImagemRelatorio(int nIdRelatorio)
			{
				int nIdRetorno = 0;
				switch(nIdRelatorio)
				{
					case 0: // PE
						nIdRetorno = 6;
						break;
					case (int)mdlConstantes.Relatorio.FaturaProforma:
						nIdRetorno = 3;
						break;
					case (int)mdlConstantes.Relatorio.FaturaComercial:
						nIdRetorno = 2;
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemComum:
						nIdRetorno = 1;
						break;
					case (int)mdlConstantes.Relatorio.Romaneio:
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
					case (int)mdlConstantes.Relatorio.RomaneioVolumes:
						nIdRetorno = 7;
						break;

					case (int)mdlConstantes.Relatorio.Saque:
						nIdRetorno = 8;
						break;
					case (int)mdlConstantes.Relatorio.Reserva:
						nIdRetorno = 11;
						break;
					case (int)mdlConstantes.Relatorio.InstrucaoEmbarque:
						nIdRetorno = 4;
						break;
					case (int)mdlConstantes.Relatorio.GuiaEntrada:
						nIdRetorno = 12;
						break;
					case (int)mdlConstantes.Relatorio.Bordero:
					case (int)mdlConstantes.Relatorio.BorderoSecundario:
						nIdRetorno = 0;
						break;

					case (int)mdlConstantes.Relatorio.Sumario:
						nIdRetorno = 9;
						break;

					case (int)mdlConstantes.Relatorio.RelatorioIndefinido:
						nIdRetorno = 5;
						break;
				}
				return(nIdRetorno);
			}

			private void vRefreshDocumentos(ref System.Windows.Forms.TreeView tvDocumentos)
			{
				tvDocumentos.Nodes.Clear();
				System.Windows.Forms.TreeNode tvnParent,tvnParentChild,tvnCurrent;

				// Processo de Exportação
				tvnParent = tvDocumentos.Nodes.Add("PE");
				tvnParent.ImageIndex = nRetornaIndexImagemRelatorio(0);
				tvnParent.Tag = 0;

				// Fatura Proforma 
				if (m_cls_Pe.FaturaProforma)
				{
					tvnCurrent = tvnParent.Nodes.Add("Fatura Proforma");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.FaturaProforma);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.FaturaProforma; 
				}

				// Fatura Comercial
				if (m_cls_Pe.FaturaComercial)
				{
					tvnCurrent = tvnParent.Nodes.Add("Fatura Comercial");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.FaturaComercial);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.FaturaComercial; 
				}

				// Certificado de Origem
				if (m_cls_Pe.CertificadoOrigem)
				{
					tvnParentChild = tvnParent.Nodes.Add("Certificado de Origem");
					tvnParentChild.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.CertificadoOrigemMercosul);
					tvnParentChild.Tag = (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul; 
				}

				// Romaneio
				if (m_cls_Pe.Romaneio)
				{
					tvnCurrent = tvnParent.Nodes.Add("Romaneio");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.Romaneio);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.Romaneio; 
				}

				// Saque
				if (m_cls_Pe.Saque)
				{
					tvnCurrent = tvnParent.Nodes.Add("Saque");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.Saque);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.Saque; 
				}

				// Reserva
				if (m_cls_Pe.Reserva)
				{
					tvnCurrent = tvnParent.Nodes.Add("Reserva");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.Reserva);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.Reserva; 
				}

				// Ordem de Embarque
				if (m_cls_Pe.OrdemEmbarque)
				{
					tvnCurrent = tvnParent.Nodes.Add("Instruções de Embarque");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.InstrucaoEmbarque);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.InstrucaoEmbarque; 
				}

				// Guia de Entrada
				if (m_cls_Pe.GuiaEntrada)
				{
					tvnCurrent = tvnParent.Nodes.Add("Guia de Entrada");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.GuiaEntrada);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.GuiaEntrada; 
				}

				// Borderô
				if (m_cls_Pe.Bordero)
				{
					tvnCurrent = tvnParent.Nodes.Add("Borderô");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.Bordero);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.Bordero; 
				}

				// Sumario
				if (m_cls_Pe.Sumario)
				{
					tvnCurrent = tvnParent.Nodes.Add("Sumário");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.Sumario);
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.Sumario; 
				}

				// Personalizado
				if (m_cls_Pe.Personalizado)
				{
					tvnCurrent = tvnParent.Nodes.Add("Personalizado");
					tvnCurrent.ImageIndex = nRetornaIndexImagemRelatorio(mdlConstantes.Relatorio.RelatorioIndefinido);;
					tvnCurrent.Tag = (int)mdlConstantes.Relatorio.RelatorioIndefinido; 
				}
				tvnParent.Expand();
			}
		#endregion
		#region PDF
			private bool bGerarPDF(ref System.Windows.Forms.TreeView tvPDF)
			{
				bool bRetorno = false;
				// Nome do PDF
				System.Windows.Forms.SaveFileDialog dlgSalvar = new System.Windows.Forms.SaveFileDialog();
				dlgSalvar.Filter = "Arquivo PDF (*.pdf)|*.pdf";
				if (dlgSalvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					vShowExportacaoDocumento();
					m_strArquivoDocumento = dlgSalvar.FileName;
					m_tvDocumentos = tvPDF;
					m_threCriacaoDocumento = new System.Threading.Thread(new System.Threading.ThreadStart(vGerarPDF));
					m_threCriacaoDocumento.Start();
				}
				return(bRetorno);
			}

			private void vGerarPDF()
			{
				if (bGerarPDF(ref m_tvDocumentos,m_strArquivoDocumento))
				{
					m_formFExportacaoDocumento.Close();
					m_formFPDF.Close();
				}
			}

			private int nRetornaQuantidadeNodos(System.Windows.Forms.TreeNode tvnNodo)
			{
				int nCount = 0;
				foreach(System.Windows.Forms.TreeNode tvnCorrente in tvnNodo.Nodes)
				{
					nCount++;
					nCount = nCount + nRetornaQuantidadeNodos(tvnCorrente);
				} 
				return(nCount);
			}


			private bool bGerarPDF(ref System.Windows.Forms.TreeView tvPDF,string strEnderecoArquivo)
			{
				mdlPDF.clsPDF objPDF = new mdlPDF.clsPDF();
				m_nDocumentoAtual = 0;
				m_nDocumentosTotal = tvPDF.Nodes.Count;
				foreach(System.Windows.Forms.TreeNode tvnCorrente in tvPDF.Nodes)
					m_nDocumentosTotal = m_nDocumentosTotal + nRetornaQuantidadeNodos(tvnCorrente);
				foreach(System.Windows.Forms.TreeNode tvnCurrent in tvPDF.Nodes)
					vInsereNodo(ref objPDF,tvnCurrent,0);
				return(objPDF.bSalvar(strEnderecoArquivo));
			}

			private void vInsereNodo(ref mdlPDF.clsPDF objPDF,System.Windows.Forms.TreeNode tvnNodoInserir,int nIdMarcadorPai)
			{
				// Inserindo o Nodo atual
				int nMarcadorAtual = nIdMarcadorPai;
				switch(Int32.Parse(tvnNodoInserir.Tag.ToString()))
				{
					case 0: // PE
						nMarcadorAtual = nInserePE(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.FaturaProforma:
						vInsereFaturaProforma(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.FaturaComercial:
						vInsereFaturaComercial(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAce39:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemAnexoIII:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemComum:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosul:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulBO:
					case (int)mdlConstantes.Relatorio.CertificadoOrigemMercosulCH:
						vInsereCertificadoOrigemMercosul(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemMercosulBolivia(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemMercosulChile(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemAladiAptr04(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemAladiAce39(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemAnexoIII(ref objPDF,nIdMarcadorPai);
						vInsereCertificadoOrigemComum(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.Romaneio:
					case (int)mdlConstantes.Relatorio.RomaneioVolumes:
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
						vInsereRomaneioProdutos(ref objPDF,nIdMarcadorPai);
						vInsereRomaneioVolumes(ref objPDF,nIdMarcadorPai);
						vInsereRomaneioSimplificado(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.Saque:
						vInsereSaque(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.Reserva:
						vInsereReserva(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.InstrucaoEmbarque:
						vInsereOrdemEmbarque(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.GuiaEntrada:
						vInsereGuiaEntrada(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.Bordero:
					case (int)mdlConstantes.Relatorio.BorderoSecundario:
						vInsereBordero(ref objPDF,nIdMarcadorPai);
						vInsereBorderoSecundario(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.Sumario:
						vInsereSumario(ref objPDF,nIdMarcadorPai);
						break;
					case (int)mdlConstantes.Relatorio.RelatorioIndefinido:
						vInserePersonalizado(ref objPDF,nIdMarcadorPai);
						break;
				}
				vIncrementaMostraPorcentagemDocumentos();
				// Nodos Filhos
				foreach(System.Windows.Forms.TreeNode tvnCurrent in tvnNodoInserir.Nodes)
					vInsereNodo(ref objPDF,tvnCurrent,nMarcadorAtual);
			}

			private int nInserePE(ref mdlPDF.clsPDF objPDF,int nIdMarcadorPai)
			{
				vExportacaoDocumento("PE");
				objPDF.bAdicionaPagina(new System.Drawing.Size(819,1158));
				objPDF.bAdicionaTexto("PE " + m_strIdPE,new System.Drawing.Font("Arial",36),System.Drawing.Color.Black,250,450);
				vIncrementaMostraPorcentagemDocumentos();
				return(objPDF.nAdicionaMarcador("PE " + m_strIdPE,nIdMarcadorPai));
			}

			private void vInsereDocumento(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai,ref mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorioImpressao,string strMarcador)
			{
				vExportacaoDocumento(strMarcador);
				mdlRelatoriosBase.frmRelatoriosBase formBaseRelatorio = objRelatorioImpressao.RelatorioBase();
				if (formBaseRelatorio != null)
				{
					ReportCanvasPackage.ReportCanvas objManipuladorGrafico = formBaseRelatorio.ManipuladorGrafico;
					formBaseRelatorio.bMostrarRelatorio();
					int nIdMarcador = nIdMarcadorPai;
					for(int i = 0; i < formBaseRelatorio.TotalPaginas;i++)
					{
						cls_PDFRelatorio.bAdicionaPagina(objManipuladorGrafico.PageSize);
						objManipuladorGrafico.bReturnPage(i,ref cls_PDFRelatorio);
						if (i == 0)
							nIdMarcador = cls_PDFRelatorio.nAdicionaMarcador(strMarcador,nIdMarcadorPai);
						else
							cls_PDFRelatorio.nAdicionaMarcador("Página " + (i + 1).ToString(),nIdMarcador);
					}
				}
			}

			private void vInsereFaturaProforma(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.FaturaProforma)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.FaturaProforma);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Fatura Proforma");
				}
			}

			private void vInsereFaturaComercial(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.FaturaComercial)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.FaturaComercial);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Fatura Comercial");
				}
			}

			private void vInsereCertificadoOrigemMercosul(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemMercosul)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemMercosul);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Mercosul");
				}
			}

			private void vInsereCertificadoOrigemMercosulBolivia(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemMercosulBolivia)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemMercosulBO);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Mercosul Bolivia");
				}
			}

			private void vInsereCertificadoOrigemMercosulChile(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemMercosulChile)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemMercosulCH);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Mercosul Chile");
				}
			}

			private void vInsereCertificadoOrigemAladiAptr04(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemAladiAptr04)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemAladiAptr04);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Aptr 04");
				}
			}

			private void vInsereCertificadoOrigemAladiAce39(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemAladiAce39)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemAladiAce39);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Ace 39");
				}
			}

			private void vInsereCertificadoOrigemAnexoIII(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemAnexoIII)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemAnexoIII);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Anexo III");
				}
			}

			private void vInsereCertificadoOrigemComum(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.CertificadoOrigemComum)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.CertificadoOrigemComum);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Certificado de Origem Comum");
				}
			}

			private void vInsereRomaneioProdutos(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.RomaneioProdutos)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.Romaneio);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Romaneio");
				}
			}

			private void vInsereRomaneioVolumes(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.RomaneioVolumes)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.RomaneioVolumes);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Romaneio");
				}
			}

			private void vInsereRomaneioSimplificado(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.RomaneioSimplificado)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.RomaneioSimplificado);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Romaneio");
				}
			}

			private void vInsereSaque(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.Saque)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.Saque);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Saque");
				}
			}

			private void vInsereReserva(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.Reserva)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.Reserva);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Reserva");
				}
			}

			private void vInsereOrdemEmbarque(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.OrdemEmbarque)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.InstrucaoEmbarque);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Ordem de Embarque");
				}
			}

			private void vInsereGuiaEntrada(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.GuiaEntrada)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.GuiaEntrada);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Guia de Entrada");
				}
			}

			private void vInsereBordero(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.Bordero)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.Bordero);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Borderô");
				}
			}

			private void vInsereBorderoSecundario(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.BorderoSecundario)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.BorderoSecundario);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Segundo Borderô");
				}
			}

			private void vInsereSumario(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.Sumario)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.Sumario);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Sumário");
				}
			}

			private void vInserePersonalizado(ref mdlPDF.clsPDF cls_PDFRelatorio,int nIdMarcadorPai)
			{
				if (m_cls_Pe.Personalizado)
				{
					mdlRelatoriosImpressao.clsRelatoriosImpressao objRelatorio = new mdlRelatoriosImpressao.clsRelatoriosImpressao(ref m_cls_dba_ConnectionDB,ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlConstantes.Relatorio.RelatorioIndefinido);
					vInsereDocumento(ref cls_PDFRelatorio,nIdMarcadorPai,ref objRelatorio,"Personalizado");
				}
			}
		#endregion
	}
}

