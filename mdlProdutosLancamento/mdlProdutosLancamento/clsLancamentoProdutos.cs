using System;
using System.Collections;

namespace mdlProdutosLancamento
{
	#region Enums
		internal enum AlinhamentoHorizontal
		{
			esquerda = 1,
			direita = 2
		}

		internal enum SentidoDeslocamento
		{
			Horizontal = 1,
			Vertical = 2
		}

		internal enum RespostaPergunta
		{
			Nenhuma = 0,
			Cadastra = 1,
			Edita = 2,
			Seleciona = 3,
			Codigo = 4,
			Descricao = 5,
			Cancelar = 6
		}
	#endregion
	/// <summary>
	/// Classe Abstrata Responsável pelo Lancamento dos Produtos 
	/// </summary>
	public abstract class clsLancamentoProdutos
	{	
		#region Constantes
			// ***************************************************************************************************
			// Constantes
			// ***************************************************************************************************
			internal const string TEXTO_DIVISOR_HIERARQUIA = "=>";
			internal const string TEXTO_MASTER = "Master";
			internal const string TEXTO_COLUNA_IDORDEM = "idOrdem";
			internal const string TEXTO_COLUNA_IDORDEMPARENT = "idOrdemParent";
			internal const string TEXTO_COLUNA_IDPRODUTO = "idProduto";
			internal const string TEXTO_COLUNA_ORDEM_LANCAMENTO = "Ordem";
			internal const int TAMANHO_COLUNA_ORDEM_LANCAMENTO = 40;
			internal const string TEXTO_COLUNA_CÓDIGO = "Código do Produto";
			internal const string TEXTO_COLUNA_DESCRICAO = "Descrição do Produto (Português)";
			internal const string TEXTO_COLUNA_UNIDADE = "Unidade";
			internal const string TEXTO_COLUNA_PRECO_UNITARIO = "Preço Unitário";
			internal const string TEXTO_COLUNA_QUANTIDADE = "Quantidade";
			internal const string TEXTO_COLUNA_DETALHAR = "Detalhar";
			internal const string TEXTO_COLUNA_NCM = "NCM";
			internal const string TEXTO_COLUNA_NALADI = "NALADI";
			internal const string TEXTO_COLUNA_NCM_DENOMINACAO = "Denominação da NCM";
			internal const string TEXTO_COLUNA_NALADI_DENOMINACAO = "Denominação da NALADI";
			internal const string TEXTO_COLUNA_GRUPO = "Grupo";

			internal const int ERRO_CODIGO_JA_EXISTENTE = -1;
			internal const int ERRO_DESCRICAO_JA_EXISTENTE = -2;

			internal const int MAXDECIMALS = 8;
			// ***************************************************************************************************
		#endregion
		#region Atributos
			// ***************************************************************************************************
			// Atributos
			// ***************************************************************************************************
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			protected int m_nIdExportador;
			protected int m_nIdioma;
			protected string m_strIdioma = "Idioma";
			protected int m_nMoeda = 28;

			// Typed DataSets
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos;
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetTbProdutosIdiomas;
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm;
			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi;

			protected bool m_bDetalharProdutos = true;
			protected bool m_bDataTableEvents = true;

			// Level Atual 
			protected int m_nDataTableProdutoLevel = 0;

		    // Colunas
		    protected clsManipuladorColunas m_cls_mac_Colunas = null;

			// Bandeiras
			protected System.Windows.Forms.ImageList m_ilBandeiras;

			// Forms
			internal frmFProdutos m_formFProdutos; 
			
			// Cores
			private System.Drawing.Color m_clrCollumnForeColor = System.Drawing.Color.White;	 
			private System.Drawing.Color m_clrCollumnBackColor = System.Drawing.Color.Black;	 

			// Ultima linha modificada 
			private System.Data.DataRow m_dtrwProdutoUpdated = null;

			protected bool m_bDataLoaded = false;
			protected bool m_bHasProducts = false;

			protected bool m_bCanEditProducts = false;

			// Row Inserting 
			//private bool m_bNullRowInserting = false;

			public bool m_bModificado = false;
			// ***************************************************************************************************
		#endregion 
		#region Properties
			public bool HasProducts
			{
				get
				{
					if (!m_bDataLoaded)
						CarregaDadosBD();
					return(m_bHasProducts);
				}
			}

			public bool CanEditProducts
			{
				get
				{
					return(m_bCanEditProducts);
				}
			}
		#endregion
		#region Construtores e Destrutores
			public clsLancamentoProdutos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, ref System.Windows.Forms.ImageList Bandeiras,int Exportador)
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
					m_formFProdutos = new frmFProdutos(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_bDetalharProdutos);
					InitializeEventsFormProdutos();
					m_formFProdutos.ShowDialog();
					m_bModificado = m_formFProdutos.m_bModificado;
					m_formFProdutos.Dispose();
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			private void InitializeEventsFormProdutos()
			{
				// Carrega os Produtos na Combo Box
                m_formFProdutos.eCallCarregaDadosComboBoxProdutos += new frmFProdutos.delCallCarregaDadosComboBoxProdutos(CarregaDadosComboBoxProdutos);

				// Carrega os Codigos dos Produtos na Combo Box 
				m_formFProdutos.eCallCarregaDadosComboBoxCodigos += new frmFProdutos.delCallCarregaDadosComboBoxCodigos(CarregaDadosComboBoxCodigos);

				// Carrega os Produtos na Lingua Estrangeira na Combo Box
				m_formFProdutos.eCallCarregaDadosComboBoxProdutosLinguaEstrangeira += new frmFProdutos.delCallCarregaDadosComboBoxProdutosLinguaEstrangeira(CarregaDadosComboBoxProdutosLinguaEstrangeira);

				// Carrega os Dados do Banco de Dados 
				m_formFProdutos.eCallCarregaDadosBD += new frmFProdutos.delCallCarregaDadosBD(CarregaDadosBD);

				// Carrega os Dados na Interface
				m_formFProdutos.eCallCarregaDadosInterface += new frmFProdutos.delCallCarregaDadosInterface(CarregaDadosInterface);

				// Level Change Filhos
				m_formFProdutos.eCallProdutosFilhos += new frmFProdutos.delCallProdutosFilhos(LevelChangeProductChilds);

				// Level Change Pai
				m_formFProdutos.eCallProdutoPai += new frmFProdutos.delCallProdutoPai(LevelChangeProductsParent);

				// Refresh Colunas na Interface 
				m_formFProdutos.eCallRefreshColunas += new frmFProdutos.delCallRefreshColunas(ConstroiTableStyles);

				// Refresh Produtos na Interface 
				m_formFProdutos.eCallRefreshProdutos += new frmFProdutos.delCallRefreshProdutos(RefreshDataDataTable);

				// Refresh SubTotal
				m_formFProdutos.eCallRefreshSubTotal += new frmFProdutos.delCallRefreshSubTotal(vRefreshSubTotal);	

				// Refresh Hierarquia do Produto
				m_formFProdutos.eCallRefreshHierarquia += new frmFProdutos.delCallRefreshHierarquia(RetornaHierarquia);

				// Trocas Linhas
				m_formFProdutos.eCallTrocaLinhas += new mdlProdutosLancamento.frmFProdutos.delCallTrocaLinhas(bTrocaLinhas);

				// Insere Linha
				m_formFProdutos.eCallLinhaInsere += new mdlProdutosLancamento.frmFProdutos.delCallLinhaInsere(bLinhaInsere);

				// Salva Dados Colunas
				m_formFProdutos.eCallSalvaTamanhoColunas += new mdlProdutosLancamento.frmFProdutos.delCallSalvaTamanhoColunas(vReadjustColumnsSize);

				// Salva os Dados no Banco de Dados 
				m_formFProdutos.eCallSalvaDadosBD += new frmFProdutos.delCallSalvaDadosBD(bSalvaDadosBD);

				// Show Dialog Colunas
				m_formFProdutos.eCallShowDialogColunas += new frmFProdutos.delCallShowDialogColunas(ShowDialogColunas);

				// Show Dialog Erro
				m_formFProdutos.eCallShowDialogError +=  new mdlProdutosLancamento.frmFProdutos.delCallShowDialogError(ShowDialogErro);
			}

		#endregion
		#region ShowDialogColunas
			private void ShowDialogColunas(ref mdlComponentesGraficos.DataGrid dgProdutos)
			{
				try
				{
					frmFColunas formFColunas = new frmFColunas(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,m_formFProdutos.BackColor,m_nIdioma,m_strIdioma,ref m_cls_mac_Colunas);
					formFColunas.ShowDialog();
					if (formFColunas.m_bModificado)
					{
						clsManipuladorColunas cls_mac_Colunas;
						formFColunas.retornaValores(out cls_mac_Colunas);
						this.ConstroiTableStyles(ref dgProdutos);
					}
					formFColunas = null;
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}

			#region Columns
				private void CopyDataFromColumnToColumn(ref System.Data.DataTable dtProdutos,int nColumnFrom, int nColumnTo)
				{
					bool bReadOnlyTableStyle = m_formFProdutos.m_dgProdutos.TableStyles[0].GridColumnStyles[nColumnTo].ReadOnly;
					bool bReadOnlyColumn = dtProdutos.Columns[nColumnTo].ReadOnly;
					m_formFProdutos.m_dgProdutos.TableStyles[0].GridColumnStyles[nColumnTo].ReadOnly = false;
					dtProdutos.Columns[nColumnTo].ReadOnly = false;
					System.Data.DataRow dtRow;
					for (int nCont = 0; nCont < dtProdutos.Rows.Count; nCont++)
					{
						dtRow = dtProdutos.Rows[nCont];
						dtRow[nColumnTo] = dtRow[nColumnFrom];
					}
					dtProdutos.Columns[nColumnTo].ReadOnly = bReadOnlyColumn;
					m_formFProdutos.m_dgProdutos.TableStyles[0].GridColumnStyles[nColumnTo].ReadOnly = bReadOnlyTableStyle;
				}
				private void AdjustColumnsIntTheForm(ref System.Collections.ArrayList arlColunas)
				{
//					try
//					{
//						System.Data.DataTable dtProdutos = (System.Data.DataTable)m_formFProdutos.m_dgProdutos.DataSource; 
//						System.Windows.Forms.DataGridTableStyle dgtbstlProdutos = m_formFProdutos.m_dgProdutos.TableStyles[0];
//						m_formFProdutos.m_bAtivadoModificacaoLinha = false;
//
//						int nContColumnsInvisibleNew = 0;
//						int nContNextColumnToInsert = 0;
//						bool bColumnToInsertFounded = false; 
//						int nContColumnsBefore = dtProdutos.Columns.Count;
//						int nColumnIndexOld = -1;
//						int nColumnIndexOldInDataTable = -1;
//						int nColumnIndexNew = -1;
//						
//						#region Inserting the new columns at the end of Datatable
//							#region Inserting Invisible Columns 
//								for(int nCont = 0; nCont < arlColunas.Count; nCont++)
//								{
//									nColumnIndexNew = nCont;
//									itemColumnNew = (clsColuna)arlColunas[nCont];
//									if (itemColumnNew.Posicao == -1)
//									{
//										nColumnIndexOld = -1;
//										// Searching for the old index of the column
//										for(int nCont2 = 0; nCont2 < m_arlColunas.Count;nCont2++)
//										{
//											itemColumnOld = (clsColuna)arlColunas[nCont2];
//											if (itemColumnNew.Nome == itemColumnOld.Nome)
//											{
//												nColumnIndexOld = nCont2;
//												break;
//											}
//										}
//										if (nColumnIndexOld != -1)
//										{
//											// Renaming the old column
//											nColumnIndexOldInDataTable = -1;
//											for (int nCont2 = 0;nCont2 < dtProdutos.Columns.Count;nCont2++)
//											{
//												if (dtProdutos.Columns[nCont2].ColumnName == itemColumnNew.Nome)
//												{
//													nColumnIndexOldInDataTable = nCont2;
//													break;
//												}
//   											}
//											if (nColumnIndexOldInDataTable != -1)
//											{
//												dtProdutos.Columns[nColumnIndexOldInDataTable].ColumnName = itemColumnNew.Nome + "2";
//												dgtbstlProdutos.GridColumnStyles[nColumnIndexOldInDataTable].HeaderText = itemColumnNew.Nome + "2";
//												dgtbstlProdutos.GridColumnStyles[nColumnIndexOldInDataTable].MappingName = itemColumnNew.Nome + "2";
//											}
//
//											// Inserting the column
//											System.Data.DataColumn dtclColuna;
//											System.Windows.Forms.DataGridColumnStyle dtgdcolstlColuna;
//											itemColumnNew.Tamanho = 0;
//											GenerateColumn(ref itemColumnNew,nContColumnsInvisibleNew,out dtclColuna,out dtgdcolstlColuna);
//											dtProdutos.Columns.Add(dtclColuna);
//											dgtbstlProdutos.GridColumnStyles.Add(dtgdcolstlColuna); 
//											// Copying the data 
//											if (nColumnIndexOldInDataTable != -1)
//												CopyDataFromColumnToColumn(ref dtProdutos,nColumnIndexOldInDataTable,(nContColumnsBefore + nContColumnsInvisibleNew));
//											nContColumnsInvisibleNew++;
//										}
//									}
//								} 
//							#endregion
//							#region Inserting the Rest of Columns      
//								nContNextColumnToInsert = 0;
//								bColumnToInsertFounded = true;
//								while(bColumnToInsertFounded)
//								{
//									bColumnToInsertFounded = false;
//									for(int nCont = 0; nCont < arlColunas.Count; nCont++)
//									{
//										nColumnIndexNew = nCont;
//										itemColumnNew = (clsColuna)arlColunas[nCont];
//										if (itemColumnNew.Posicao == nContNextColumnToInsert)
//										{
//											nColumnIndexOld = -1;
//											// Searching for the old index of the column
//											for(int nCont2 = 0; nCont2 < m_arlColunas.Count;nCont2++)
//											{
//												itemColumnOld = (clsColuna)arlColunas[nCont2];
//												if (itemColumnNew.Nome == itemColumnOld.Nome)
//												{
//													nColumnIndexOld = nCont2;
//													break;
//												}
//											}
//											if (nColumnIndexOld != -1)
//											{
//												// Renaming the old column
//												nColumnIndexOldInDataTable = -1;
//												for (int nCont2 = 0;nCont2 < dtProdutos.Columns.Count;nCont2++)
//												{
//													if (dtProdutos.Columns[nCont2].ColumnName == itemColumnNew.Nome)
//													{
//														nColumnIndexOldInDataTable = nCont2;
//														break;
//													}
//												}
//												if (nColumnIndexOldInDataTable != -1)
//												{
//													dtProdutos.Columns[nColumnIndexOldInDataTable].ColumnName = itemColumnNew.Nome + "2";
//													dgtbstlProdutos.GridColumnStyles[nColumnIndexOldInDataTable].HeaderText = itemColumnNew.Nome + "2";
//													dgtbstlProdutos.GridColumnStyles[nColumnIndexOldInDataTable].MappingName = itemColumnNew.Nome + "2";
//												}
//
//												// Inserting the column
//												System.Data.DataColumn dtclColuna;
//												System.Windows.Forms.DataGridColumnStyle dtgdcolstlColuna;
//												GenerateColumn(ref itemColumnNew,nContColumnsInvisibleNew + nContNextColumnToInsert,out dtclColuna,out dtgdcolstlColuna);
//												dtProdutos.Columns.Add(dtclColuna);
//												dgtbstlProdutos.GridColumnStyles.Add(dtgdcolstlColuna); 
//												// Copying the data 
//												if (nColumnIndexOldInDataTable != -1)
//													CopyDataFromColumnToColumn(ref dtProdutos,nColumnIndexOldInDataTable,(nContColumnsBefore + nContColumnsInvisibleNew + nContNextColumnToInsert));
//											}
//											bColumnToInsertFounded = true;
//											nContNextColumnToInsert++;
//											break;
//										}
//									}
//								}
//							#endregion
//						#endregion
//						#region Deleting old columns
//							for(int nCont = 0;nCont < nContColumnsBefore; nCont++)
//							{
//								dtProdutos.Columns.RemoveAt(0);
//								dgtbstlProdutos.GridColumnStyles.RemoveAt(0);
//							}
//						#endregion
//						#region Adjusting the new Array List
//							m_arlColunas = arlColunas;
//						#endregion
//
//						m_formFProdutos.m_bAtivadoModificacaoLinha = true;
//					}catch (Exception erro){
//						Object err = (Object)erro;
//						m_cls_ter_tratadorErro.trataErro(ref err);
//					}
				}

			#endregion
		#endregion
		#region ShowDialogPerguntas

			internal mdlProdutosLancamento.RespostaPergunta ShowDialogPerguntaEscolheCodigoOuDescricao()
			{
				mdlProdutosLancamento.RespostaPergunta enumRetorno = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
				System.Collections.ArrayList arlBotoes = new System.Collections.ArrayList();
				System.Collections.ArrayList arlBotoesTexts = new System.Collections.ArrayList();

				// Setando os Botoes 
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Codigo);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Descricao);
				arlBotoesTexts.Add("Código");
				arlBotoesTexts.Add("Descrição");
				frmFPergunta formFPergunta = new frmFPergunta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,"O código não corresponde a descrição. Qual você dejesa manter ?",ref arlBotoes,ref arlBotoesTexts);
				formFPergunta.ShowDialog();
				enumRetorno = formFPergunta.m_enumResposta;
				return(enumRetorno);
			}

			internal mdlProdutosLancamento.RespostaPergunta ShowDialogPerguntaEditarCodigo()
			{
				mdlProdutosLancamento.RespostaPergunta enumRetorno = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
				System.Collections.ArrayList arlBotoes = new System.Collections.ArrayList();
				System.Collections.ArrayList arlBotoesTexts = new System.Collections.ArrayList();

				// Setando os Botoes 
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Edita);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cancelar);
				arlBotoesTexts.Add("Substituir");
				arlBotoesTexts.Add("Cancelar");
				frmFPergunta formFPergunta = new frmFPergunta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,"O código não existe. O que deseja fazer ?",ref arlBotoes,ref arlBotoesTexts);
				formFPergunta.ShowDialog();
				enumRetorno = formFPergunta.m_enumResposta;
				return(enumRetorno);
			}

			internal mdlProdutosLancamento.RespostaPergunta ShowDialogPerguntaCadastrarEditarDescricao()
			{
				mdlProdutosLancamento.RespostaPergunta enumRetorno = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
				System.Collections.ArrayList arlBotoes = new System.Collections.ArrayList();
				System.Collections.ArrayList arlBotoesTexts = new System.Collections.ArrayList();

				// Setando os Botoes 
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cadastra);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Edita);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cancelar);
				arlBotoesTexts.Add("Cadastrar");
				arlBotoesTexts.Add("Substituir");
				arlBotoesTexts.Add("Cancelar");
				frmFPergunta formFPergunta = new frmFPergunta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,"A descrição não existe. O que deseja fazer ?",ref arlBotoes,ref arlBotoesTexts);
				formFPergunta.ShowDialog();
				enumRetorno = formFPergunta.m_enumResposta;
				return(enumRetorno);
			}

			internal mdlProdutosLancamento.RespostaPergunta ShowDialogPerguntaCadastrarDescricao()
			{
				mdlProdutosLancamento.RespostaPergunta enumRetorno = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
				System.Collections.ArrayList arlBotoes = new System.Collections.ArrayList();
				System.Collections.ArrayList arlBotoesTexts = new System.Collections.ArrayList();

				// Setando os Botoes 
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cadastra);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cancelar);
				arlBotoesTexts.Add("Cadastrar");
				arlBotoesTexts.Add("Cancelar");
				frmFPergunta formFPergunta = new frmFPergunta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,"A descrição não existe. O que deseja fazer ?",ref arlBotoes,ref arlBotoesTexts);
				formFPergunta.ShowDialog();
				enumRetorno = formFPergunta.m_enumResposta;
				return(enumRetorno);
			}

			internal mdlProdutosLancamento.RespostaPergunta ShowDialogPerguntaCadastrarNovoProdutoOuEditarAntigo()
			{
				mdlProdutosLancamento.RespostaPergunta enumRetorno = mdlProdutosLancamento.RespostaPergunta.Nenhuma;
				System.Collections.ArrayList arlBotoes = new System.Collections.ArrayList();
				System.Collections.ArrayList arlBotoesTexts = new System.Collections.ArrayList();

				// Setando os Botoes 
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Cadastra);
				arlBotoes.Add(mdlProdutosLancamento.RespostaPergunta.Edita);
				arlBotoesTexts.Add("Cadastrar");
				arlBotoesTexts.Add("Editar");
				frmFPergunta formFPergunta = new frmFPergunta(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,"A descrição e o código não existem. O que deseja fazer ?",ref arlBotoes,ref arlBotoesTexts);
				formFPergunta.ShowDialog();
				enumRetorno = formFPergunta.m_enumResposta;
				return(enumRetorno);
			}
			
		#endregion
		#region ShowDialogErro
			private void ShowDialogErro()
			{
				frmFErrorOnSave formFErro = new frmFErrorOnSave(m_strEnderecoExecutavel);
				formFErro.ShowDialog();
				formFErro = null;
  			}
		#endregion

		#region Carregamento dos Dados
			#region Banco Dados
				private void CarregaDadosBD()
				{
					try
					{
						m_bDataLoaded = true;
						m_cls_dba_ConnectionDB.DataPersist = false;
						LoadConfigurations();
						CarregaDadosBDEspecificos();
						m_typDatSetTbProdutos = typDatSetCarregaDadosBDProdutos();
						m_typDatSetTbProdutosIdiomas = typDatSetCarregaDadosBDProdutosLinguaEstrangeira();
						m_typDatSetTbProdutosNcm = typDatSetCarregaDadosBDProdutosNcm();
						m_typDatSetTbProdutosNaladi = typDatSetCarregaDadosBDProdutosNaladi();
						CarregaDadosBDProdutosEspecificos();
					}catch (System.Exception expErro){
						m_cls_ter_tratadorErro.trataErro(ref expErro);
					}
				}

				protected void LoadConfigurations()
				{
					mdlManipuladorArquivo.clsManipuladorArquivoIni clsArquivoSiscoIni = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
					m_bCanEditProducts = clsArquivoSiscoIni.retornaValor(mdlConstantes.clsConstantes.DEFAULT_SESSION_SISCOBRAS,"CanEditProducts",true);
				}

		        protected abstract void CarregaDadosBDEspecificos();
        
				private mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetCarregaDadosBDProdutos()
				{
                    System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					return(m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null));
				}

				private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetCarregaDadosBDProdutosLinguaEstrangeira()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					return(m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null));
				}
	
				private mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetCarregaDadosBDProdutosNcm()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("nIdExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					return(m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null));
				}

				private mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetCarregaDadosBDProdutosNaladi()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("nIdExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					return(m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null));
				}

				protected abstract void CarregaDadosBDProdutosEspecificos();

			#endregion
			#region Interface
				private void CarregaDadosInterface(ref mdlComponentesGraficos.DataGrid dgProdutos,out bool bDetalharProdutos)
				{
					ConstroiManipuladorColunas();
					CarregaColunasManipuladorColunas();
					System.Data.DataTable dttbMaster = dttbConstroiDataTableMaster();
					CarregaColunasDataTable(ref dttbMaster);
					ConstroiTableStyles(ref dgProdutos);
					RefreshDataDataTable(ref dttbMaster);
					InitializeEventsDataTableMaster(ref dttbMaster);
					dgProdutos.DataSource = dttbMaster;
					bDetalharProdutos = m_bDetalharProdutos;
				}

				private void CarregaDadosComboBoxProdutos(ref mdlComponentesGraficos.ComboBox cbProdutos)
				{
					cbProdutos.Clear();
					System.Data.DataRow[] dtrwProdutos = m_typDatSetTbProdutos.tbProdutos.Select("","mstrDescricao");
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwRowTbProdutos;
					for (int i = 0 ; i < dtrwProdutos.Length; i++)
					{
						dtrwRowTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)dtrwProdutos[i];
                        cbProdutos.AddItem(dtrwRowTbProdutos.mstrDescricao,dtrwRowTbProdutos.idProduto);
					}
				}

				private void CarregaDadosComboBoxCodigos(ref mdlComponentesGraficos.ComboBox cbCodigos)
				{
					cbCodigos.Clear();
					System.Data.DataRow[] dtrwProdutos = m_typDatSetTbProdutos.tbProdutos.Select("","mstrCodigoProduto");
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwRowTbProdutos;
					for (int i = 0 ; i < dtrwProdutos.Length ; i++)
					{
						dtrwRowTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)dtrwProdutos[i];
						cbCodigos.AddItem(dtrwRowTbProdutos.mstrCodigoProduto,dtrwRowTbProdutos.idProduto);
					}
				}

				private void CarregaDadosComboBoxProdutosLinguaEstrangeira(ref mdlComponentesGraficos.ComboBox cbProdutosLinguaEstrangeira)
				{
					cbProdutosLinguaEstrangeira.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwRowTbProdutosIdiomas;
					for (int nCont = 0 ; nCont < m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.Rows.Count ; nCont++)
					{
						dtrwRowTbProdutosIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow)m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.Rows[nCont];
						string strLinguaEstrangeira = (!dtrwRowTbProdutosIdiomas.IsmstrDescricaoNull()) ? dtrwRowTbProdutosIdiomas.mstrDescricao : ""; 
						if ((strLinguaEstrangeira == "") && (dtrwRowTbProdutosIdiomas.IsmstrDescricaoNull()) && (!dtrwRowTbProdutosIdiomas.IsstrDescricaoNull()))
							strLinguaEstrangeira = dtrwRowTbProdutosIdiomas.strDescricao;
						cbProdutosLinguaEstrangeira.AddItem(strLinguaEstrangeira,dtrwRowTbProdutosIdiomas.idProduto);
					}
				}
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Interface
				private void SalvaDadosInterface(bool bDetalharProdutos)
				{
					m_bDetalharProdutos = bDetalharProdutos;
				}
			#endregion
			#region Banco Dados 
				private bool bSalvaDadosBD()
				{
					bool bRetorno = false;
					vRemoveProdutosNulos();

					bool bShowErrors = m_cls_dba_ConnectionDB.ShowDialogsErrors;
                    m_cls_dba_ConnectionDB.ShowDialogsErrors = false;
					if (bSalvaDadosBDProdutos())
						if (bSalvaDadosBDProdutosLinguaEstrangeira())
							if (bSalvaDadosBDProdutosNcm())
								if (bSalvaDadosBDProdutosNaladi())
									if (bSalvaDadosBDColunas())
										if (bSalvaDadosBDColunasExportador())
											if (bSalvaProdutosPropriedades())
												bRetorno = bSalvaDadosBDProdutosFatura();
					m_cls_dba_ConnectionDB.ShowDialogsErrors = bShowErrors;
					return(bRetorno);
				}
				protected abstract bool bSalvaDadosBDColunas();

				protected abstract bool bSalvaProdutosPropriedades();

				private bool bSalvaDadosBDColunasExportador()
				{
					bool bRetorno = false;
					System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					mdlDataBaseAccess.Tabelas.XsdTbExportadores typDatSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetExportadores.tbExportadores.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRow = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)typDatSetExportadores.tbExportadores.Rows[0];
						
						// Ordem Lancamento
						dtrwRow.nColunaOrdemLancamento = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_ORDEM_LANCAMENTO);
						dtrwRow.nTamanhoColunaOrdemLancamento = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_ORDEM_LANCAMENTO);
						// Codigo
						dtrwRow.colunaCodigo = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_CÓDIGO);
						dtrwRow.tamanhoColunaCodigo = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_CÓDIGO);
						// Descrição
						dtrwRow.colunaDescricao = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_DESCRICAO);
						dtrwRow.tamanhoColunaDescricao = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_DESCRICAO);
						// Descrição Lingua Estrangeira 
						dtrwRow.colunaDescricaoLinguaEstrangeira = m_cls_mac_Colunas.GetPosicao(m_strIdioma);
						dtrwRow.tamanhoColunaDescricaoLinguaEstrangeira = m_cls_mac_Colunas.GetTamanho(m_strIdioma);
						// Unidade
						dtrwRow.colunaUnidade = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_UNIDADE);
						dtrwRow.tamanhoColunaUnidade = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_UNIDADE);
						// Preço Unitário
						dtrwRow.colunaPrecoUnitario = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_PRECO_UNITARIO);
						dtrwRow.tamanhoColunaPrecoUnitario = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_PRECO_UNITARIO);
						// Quantidade
						dtrwRow.colunaQuantidade = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_QUANTIDADE);
						dtrwRow.tamanhoColunaQuantidade = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_QUANTIDADE);
						// Detalhar
						dtrwRow.nColunaDetalharProdutos = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_DETALHAR);
						dtrwRow.nTamanhoColunaDetalharProdutos = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_DETALHAR);

						m_cls_dba_ConnectionDB.SetTbExportadores(typDatSetExportadores);
						bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					}
					return(bRetorno);
				}

				protected bool bSalvaDadosBDProdutos()
				{
					bool bRetorno = false;
					vIntegridade();
					m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetTbProdutos);
					bRetorno = m_cls_dba_ConnectionDB.Erro == null;
					if (bRetorno)
						m_typDatSetTbProdutos.AcceptChanges();
					return(bRetorno);
				}

				private void vIntegridade()
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = typDatSetCarregaDadosBDProdutos();
					// Integridade
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto in m_typDatSetTbProdutos.tbProdutos.Rows)
					{
						if (dtrwProduto.RowState == System.Data.DataRowState.Added)
						{
							if (typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProduto.idProduto) != null)
							{
								int nIdOld = dtrwProduto.idProduto;
								int nIdNew = nReturnNextIdProduto(ref typDatSetProdutos);
								dtrwProduto.idProduto = nIdNew;
								// Produto Idioma 
								mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,nIdOld);
								if ((dtrwProdutoIdioma != null) && (dtrwProdutoIdioma.RowState != System.Data.DataRowState.Deleted))
									dtrwProdutoIdioma.idProduto = nIdNew;
								// Produto Fatura 
								vIntegridadeProduto(nIdOld,nIdNew);
							}
						}
					}
				}

				protected abstract void vIntegridadeProduto(int nIdOld,int nIdNew);
			
				private int nReturnNextIdProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos)
				{
					int nId = 1;
					bool bIdExists = true;
					while(bIdExists)
					{
						bIdExists = false;
						if (typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nId) == null)
						{
							if (m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nId) == null)
							{
								break;
							}else{
								nId++;
								bIdExists = true;
							}
						}else{
							nId++;
							bIdExists = true;
						} 
					} 
					return(nId);
				}
				
				protected bool bSalvaDadosBDProdutosLinguaEstrangeira()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbProdutosIdiomas(m_typDatSetTbProdutosIdiomas);
					bRetorno = m_cls_dba_ConnectionDB.Erro == null;
					if (bRetorno)
						m_typDatSetTbProdutosIdiomas.AcceptChanges();
					return(bRetorno);
				} 

				private bool bSalvaDadosBDProdutosNcm()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbProdutosNcm(m_typDatSetTbProdutosNcm);
					bRetorno = m_cls_dba_ConnectionDB.Erro == null;
					if (bRetorno)
						m_typDatSetTbProdutosNcm.AcceptChanges();
					return(bRetorno);
				} 

				private bool bSalvaDadosBDProdutosNaladi()
				{
					bool bRetorno = false;
					m_cls_dba_ConnectionDB.SetTbProdutosNaladi(m_typDatSetTbProdutosNaladi);
					bRetorno = m_cls_dba_ConnectionDB.Erro == null;
					if (bRetorno)
						m_typDatSetTbProdutosNaladi.AcceptChanges();
					return(bRetorno);
				} 

				protected abstract bool bSalvaDadosBDProdutosFatura();
			#endregion
		#endregion

		#region DataTable Master 
			protected System.Data.DataTable dttbConstroiDataTableMaster()
			{
				System.Data.DataTable dttbMaster = new System.Data.DataTable(TEXTO_MASTER);
				InitializeEventsDataTableMaster(ref dttbMaster);
				CarregaColunasDataTable(ref dttbMaster);
				return(dttbMaster);
			}

			private void InitializeEventsDataTableMaster(ref System.Data.DataTable dttbProdutos)
			{
				// Inserindo ou Modificando uma Linha
				dttbProdutos.RowChanged += new System.Data.DataRowChangeEventHandler(this.DataTable_RowChanged);

				// Apagando uma Linha
				dttbProdutos.RowDeleting += new System.Data.DataRowChangeEventHandler(this.DataTable_RowDeleting);
			}
		#endregion
		#region TableStyles Master
			private void ConstroiTableStyles(ref mdlComponentesGraficos.DataGrid dgProdutos)
			{
                // Limpando os anteriores 
				dgProdutos.TableStyles.Clear();

				// Criando o Table Style
				System.Windows.Forms.DataGridTableStyle dtgdtbstMaster = new System.Windows.Forms.DataGridTableStyle(false);

				// Configurando 
				dtgdtbstMaster.MappingName = TEXTO_MASTER;
				dtgdtbstMaster.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid;
				dtgdtbstMaster.GridLineColor = System.Drawing.Color.Gray;
				dtgdtbstMaster.AlternatingBackColor = dgProdutos.BackColor;
				dtgdtbstMaster.BackColor = System.Drawing.Color.White;
				dtgdtbstMaster.HeaderBackColor = dgProdutos.BackColor;
				dtgdtbstMaster.AllowSorting = false;

				// Configurando os GridColumnStyles
				dtgdtbstMaster.GridColumnStyles.Clear();
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna;

				// Produtos Integrantes
				int nAdder = 0;
				int nPosicaoColunaPrecoUnitario = 0;
				int nPosicaoColunaDetalhar = 0;
				if (m_nDataTableProdutoLevel != 0)
				{
					nPosicaoColunaPrecoUnitario = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_PRECO_UNITARIO);
					nPosicaoColunaDetalhar = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_DETALHAR);
					if (nPosicaoColunaPrecoUnitario != 0)
					{
						m_cls_mac_Colunas.RemoveColuna(TEXTO_COLUNA_PRECO_UNITARIO);
						nAdder++;
					}
					if (nPosicaoColunaDetalhar != 0)
					{
						m_cls_mac_Colunas.RemoveColuna(TEXTO_COLUNA_DETALHAR);
						nAdder++;
					}
				}
				// Colunas Sistema
				for(int i = 0; i < m_cls_mac_Colunas.CountSistema;i++)
				{
					clsColuna objColuna = m_cls_mac_Colunas.GetColunaSistema(i);
					if (objColuna != null)
					{
						dtgdcsColuna = m_cls_mac_Colunas.dtgdcsColuna(objColuna);
						if (dtgdcsColuna != null)
						{
							DataGridColumnStyleConfigure(ref dtgdcsColuna);
							dtgdtbstMaster.GridColumnStyles.Add(dtgdcsColuna);
						}
					}
				} 
				// Colunas Invalidas
				for(int i = 0; i < m_cls_mac_Colunas.CountInvalidas;i++)
				{
					clsColuna objColuna = m_cls_mac_Colunas.GetColunaInvalida(i);
					if (objColuna != null)
					{
						dtgdcsColuna = m_cls_mac_Colunas.dtgdcsColuna(objColuna);
						if (dtgdcsColuna != null)
						{
							DataGridColumnStyleConfigure(ref dtgdcsColuna);
							dtgdtbstMaster.GridColumnStyles.Add(dtgdcsColuna);
						}
					}
				} 
				// Colunas Validas
				for(int i = 0; i < m_cls_mac_Colunas.CountValidas + nAdder;i++)
				{
					clsColuna objColuna = m_cls_mac_Colunas.GetColunaValidaIndex(i + 1);
					if (objColuna != null)
					{
						dtgdcsColuna = m_cls_mac_Colunas.dtgdcsColuna(objColuna);
						if (dtgdcsColuna != null)
						{
							DataGridColumnStyleConfigure(ref dtgdcsColuna);
							dtgdtbstMaster.GridColumnStyles.Add(dtgdcsColuna);
						}
					}
				} 
				if (m_nDataTableProdutoLevel != 0)
				{
					if (nPosicaoColunaPrecoUnitario != 0)
						m_cls_mac_Colunas.SetPosicao(TEXTO_COLUNA_PRECO_UNITARIO,nPosicaoColunaPrecoUnitario);
					if (nPosicaoColunaDetalhar != 0)
						m_cls_mac_Colunas.SetPosicao(TEXTO_COLUNA_DETALHAR,nPosicaoColunaDetalhar);
				}
				dgProdutos.TableStyles.Add(dtgdtbstMaster);

			}

			private void DataGridColumnStyleConfigure(ref System.Windows.Forms.DataGridColumnStyle dtgdcsColuna)
			{
				if (dtgdcsColuna.HeaderText != mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DETALHAR)
				{
					((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(m_formFProdutos.DataGridTextBoxColumn_KeyDown);
					((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFProdutos.DataGridTextBoxColumn_KeyUp);
					((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Click += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Click);
				}
				switch(dtgdcsColuna.HeaderText)
				{
					case TEXTO_COLUNA_DESCRICAO:
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumnDescricao_Enter);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(m_formFProdutos.DataGridTextBoxColumnDescricao_KeyPress);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						break;
					case TEXTO_COLUNA_PRECO_UNITARIO:
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Enter);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(m_formFProdutos.DataGridTextBoxColumnNumerico_KeyPress);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						break;
					case TEXTO_COLUNA_QUANTIDADE:
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Enter);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(m_formFProdutos.DataGridTextBoxColumnNumerico_KeyPress);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						break;
					case TEXTO_COLUNA_UNIDADE:
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Name = TEXTO_COLUNA_UNIDADE;
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Enter);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.TextChanged += new System.EventHandler(m_formFProdutos.DataGridTextBoxColumn_TextChanged);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						break;
					case TEXTO_COLUNA_GRUPO:
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Name = TEXTO_COLUNA_GRUPO;
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Enter);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.TextChanged += new System.EventHandler(m_formFProdutos.DataGridTextBoxColumn_TextChanged);
						((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						break;
					default:
						if (dtgdcsColuna.HeaderText != mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DETALHAR)
						{
							((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Enter += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Enter);
							((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsColuna).TextBox.Leave += new EventHandler(m_formFProdutos.DataGridTextBoxColumn_Leave);
						}
						break;
				}
			}
		#endregion
		#region Manipulador de Colunas
		protected void ConstroiManipuladorColunas()
		{
			// Construindo o manipulador
			m_cls_mac_Colunas = new clsManipuladorColunas(m_cls_dba_ConnectionDB,m_nIdExportador,m_nIdioma,m_strIdioma);
		}
	
		protected abstract void CarregaColunasManipuladorColunas();

		protected void CarregaColunasDataTable(ref System.Data.DataTable dttbMaster)
		{
			// Limpando as colunas existentes 
			dttbMaster.Columns.Clear();

			// Colunas Sistema
			for (int i = 0; i < m_cls_mac_Colunas.CountSistema; i++)
			{
				clsColuna objColuna = m_cls_mac_Colunas.GetColunaSistema(i);
				if (objColuna != null)
					dttbMaster.Columns.Add(m_cls_mac_Colunas.dtclColuna(objColuna));
			}
			// Colunas Invalidas
			for (int i = 0; i < m_cls_mac_Colunas.CountInvalidas; i++)
			{
				clsColuna objColuna = m_cls_mac_Colunas.GetColunaInvalida(i);
				if (objColuna != null)
					dttbMaster.Columns.Add(m_cls_mac_Colunas.dtclColuna(objColuna));
			}
			// Colunas Validas
			for (int i = 0; i < m_cls_mac_Colunas.CountValidas; i++)
			{
				clsColuna objColuna = m_cls_mac_Colunas.GetColunaValidaIndex(i + 1);
				if (objColuna != null)
					dttbMaster.Columns.Add(m_cls_mac_Colunas.dtclColuna(objColuna));
			}
		}

		private void vReadjustColumnsSize(ref mdlComponentesGraficos.DataGrid dgProdutos)
		{
			System.Windows.Forms.DataGridTableStyle dtgdtbstDados = dgProdutos.TableStyles[0];
			foreach(System.Windows.Forms.DataGridColumnStyle dtgtclstDados in dtgdtbstDados.GridColumnStyles)
			{
				m_cls_mac_Colunas.SetTamanho(dtgtclstDados.HeaderText,dtgtclstDados.Width);
			}
		}	

		#endregion
		#region Refresh DataTable
			protected abstract void RefreshDataDataTable(ref System.Data.DataTable dttbProdutos);
		#endregion
		#region Refresh SubTotal
			protected abstract void vRefreshSubTotal(ref System.Windows.Forms.Label lbSubTotal);
		#endregion

		#region Linhas
			protected abstract bool bTrocaLinhas(int nOrdem1,int nOrdem2);
			protected abstract void vInsereNovaLinha(System.Data.DataRow dtrwProduto,int nNovoValorColuna);
			protected abstract void vTrocaParentProdutosIntegrante(int nOrdemAtual1,int nOrdemNova1,int nOrdemAtual2,int nOrdemNova2);
			protected abstract bool bLinhaInsere(int nIdOrdem);
		#endregion

		#region Produtos
			protected string strRetornaCodigoProduto(int nIdProduto)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if ((dtrwProduto != null) && (!dtrwProduto.IsmstrCodigoProdutoNull()))
				{
					strRetorno = dtrwProduto.mstrCodigoProduto;
				}
				return(strRetorno); 
			}

			protected string strRetornaDescricaoProduto(int nIdProduto)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if ((dtrwProduto != null) && (!dtrwProduto.IsmstrDescricaoNull()))
				{
					strRetorno = dtrwProduto.mstrDescricao;
				}
				return(strRetorno); 
			}

			protected void vModificaDescricaoProduto(int nIdProduto,string strDescricaoNova)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto != null)
				{
					dtrwProduto.mstrDescricao = strDescricaoNova;
				}
			}

			protected void vModificaDescricaoLinguaEstrangeiraProduto(int nIdProduto,string strDescricaoLinguaEstrangeiraNova)
			{
				strDescricaoLinguaEstrangeiraNova = strDescricaoLinguaEstrangeiraNova.Trim();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,nIdProduto);
				if (dtrwProdutoIdioma != null)
				{
					if (strDescricaoLinguaEstrangeiraNova != "")
					{
						dtrwProdutoIdioma.mstrDescricao = strDescricaoLinguaEstrangeiraNova;
					}else{
						dtrwProdutoIdioma.Delete();
					}
				}else{
					if (strDescricaoLinguaEstrangeiraNova != "")
					{
						dtrwProdutoIdioma = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.NewtbProdutosIdiomasRow();
						dtrwProdutoIdioma.idExportador = m_nIdExportador;
						dtrwProdutoIdioma.idIdioma = m_nIdioma;
						dtrwProdutoIdioma.idProduto = nIdProduto;
						dtrwProdutoIdioma.mstrDescricao = strDescricaoLinguaEstrangeiraNova;
						m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.Rows.Add(dtrwProdutoIdioma);
					}
				}
			}

			protected void vModificaCodigoProduto(int nIdProduto,string strCodigoNovo)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto != null)
				{
					dtrwProduto.mstrCodigoProduto = strCodigoNovo;
				}
			}

			protected string strRetornaDescricaoProdutoLinguaEstrangeira(int nIdProduto)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = m_typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,nIdProduto);
				if (dtrwProdutoIdioma != null)
				{
					if 	(!dtrwProdutoIdioma.IsmstrDescricaoNull())
					{
						strRetorno = dtrwProdutoIdioma.mstrDescricao;
					}else if (!dtrwProdutoIdioma.IsstrDescricaoNull()){
						strRetorno = dtrwProdutoIdioma.strDescricao;
					}
					
				}
				return(strRetorno); 
			}
			
			protected int nCadastraProduto(string strCodigoProduto,string strDescricao,string strDescricaoLinguaEstrangeira)
			{
				int nRetorno = 1;
				// Verificando o Codigo e a Descricao
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = null;
				if (strCodigoProduto != "")
				{
					for (int nCont = 0; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count;nCont++)
					{
						dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
						if ((!dtrwProduto.IsmstrCodigoProdutoNull()) && (dtrwProduto.mstrCodigoProduto == strCodigoProduto))
						{
							return(ERRO_CODIGO_JA_EXISTENTE);
						}
						if ((!dtrwProduto.IsmstrDescricaoNull()) && (dtrwProduto.mstrDescricao == strDescricao))
						{
							return(ERRO_CODIGO_JA_EXISTENTE);
						}
					}
				}

				// Procurando um codigo para o produto caso ele nao tenha 
				if (strCodigoProduto == "")
				{
					int nCodigoProduto = 1;
					bool bCodigoExistente = true;
					while (bCodigoExistente)
					{
						bCodigoExistente = false;
						for (int nCont = 0; nCont < m_typDatSetTbProdutos.tbProdutos.Rows.Count;nCont++)
						{
							dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow)m_typDatSetTbProdutos.tbProdutos.Rows[nCont];
							if ((!dtrwProduto.IsmstrCodigoProdutoNull()) && (dtrwProduto.mstrCodigoProduto == nCodigoProduto.ToString()))
							{
								nCodigoProduto++;
								bCodigoExistente = true;
								break;
							}
						}
					}
					strCodigoProduto = nCodigoProduto.ToString();
				}

				// Inserindo o Produto
				if (nRetorno == 1)
				{
					while(m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nRetorno) != null)
					{
						nRetorno++;
					}
					dtrwProduto = m_typDatSetTbProdutos.tbProdutos.NewtbProdutosRow();

					dtrwProduto.idExportador = m_nIdExportador;
					dtrwProduto.idProduto = nRetorno;
					dtrwProduto.mstrCodigoProduto = strCodigoProduto;
					dtrwProduto.mstrDescricao = strDescricao;
					dtrwProduto.idCategoria = -1;

					m_typDatSetTbProdutos.tbProdutos.Rows.Add(dtrwProduto);
				}
				return(nRetorno);
			}
		#endregion
		#region Classificacao Tarifaria
			private bool bApenasNumeros(string strNumeros)
			{
				for(int i = 0; i < strNumeros.Length;i++)
				{
					if ((48 > strNumeros[i]) || (57 < strNumeros[i]))
						return(false);
				}
				return(true);
			}

			protected bool bClassificacaoTarifariaValida(ref string strClassificacao)
			{
				strClassificacao = strClassificacao.Trim();
				if (strClassificacao.Length == 8)
					strClassificacao = strClassificacao.Substring(0,4) + "." + strClassificacao.Substring(4,2) + "." + strClassificacao.Substring(6,2);
				if (strClassificacao.Length == 10)
					if ((bApenasNumeros(strClassificacao.Substring(0,4)) && (bApenasNumeros(strClassificacao.Substring(5,2))) && (bApenasNumeros(strClassificacao.Substring(8,2))) && (strClassificacao.Substring(4,1) == ".") && (strClassificacao.Substring(7,1) == ".")))
						return(true);
				return(false);
			}
		#endregion
		#region NCM
			protected string strRetornaNcmProduto(int nIdProduto)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if ((dtrwProduto != null) && (!dtrwProduto.IsstrNcmNull()))
					if (m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,dtrwProduto.strNcm) != null)
						strRetorno = dtrwProduto.strNcm;
				return(strRetorno); 
			}

			protected void SetNcmProduto(int nIdProduto,string strNcm,string strDenominacao)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto != null)
				{
					dtrwProduto.strNcm = strNcm;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwProdutoNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,strNcm);
					if (dtrwProdutoNcm == null)
					{
						dtrwProdutoNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.NewtbProdutosNcmRow();
						dtrwProdutoNcm.nIdExportador = m_nIdExportador;
						dtrwProdutoNcm.strNcm = strNcm;
						dtrwProdutoNcm.mstrDenominacao = strDenominacao;
						m_typDatSetTbProdutosNcm.tbProdutosNcm.AddtbProdutosNcmRow(dtrwProdutoNcm);

					}else{
						dtrwProdutoNcm.mstrDenominacao = strDenominacao;
					}
				}
			}

			protected string strRetornaDenominacaoNcm(string strNcm)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwProdutoNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,strNcm);
				if ((dtrwProdutoNcm != null) && (!dtrwProdutoNcm.IsmstrDenominacaoNull()))
					strRetorno = dtrwProdutoNcm.mstrDenominacao;
				return(strRetorno); 
			}
		#endregion
		#region Naladi
			protected string strRetornaNaladiProduto(int nIdProduto)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if ((dtrwProduto != null) && (!dtrwProduto.IsstrNaladiNull()))
					if (m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,dtrwProduto.strNaladi) != null)
						strRetorno = dtrwProduto.strNaladi;
				return(strRetorno); 
			}

			protected void SetNaladiProduto(int nIdProduto,string strNaladi,string strDenominacao)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto != null)
				{
					dtrwProduto.strNaladi = strNaladi;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwProdutoNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,strNaladi);
					if (dtrwProdutoNaladi == null)
					{
						dtrwProdutoNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.NewtbProdutosNaladiRow();
						dtrwProdutoNaladi.nIdExportador = m_nIdExportador;
						dtrwProdutoNaladi.strNaladi = strNaladi;
						dtrwProdutoNaladi.mstrDenominacao = strDenominacao;
						m_typDatSetTbProdutosNaladi.tbProdutosNaladi.AddtbProdutosNaladiRow(dtrwProdutoNaladi);
					}else{
						dtrwProdutoNaladi.mstrDenominacao = strDenominacao;
					}
				}
			}

			protected string strRetornaDenominacaoNaladi(string strNaladi)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwProdutoNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,strNaladi);
				if ((dtrwProdutoNaladi != null) && (!dtrwProdutoNaladi.IsmstrDenominacaoNull()))
					strRetorno = dtrwProdutoNaladi.mstrDenominacao;
				return(strRetorno); 
			}
		#endregion

		#region Hierarquia
			private void RetornaHierarquia(out int nLevel,out string strHierarquia)
			{
				int nDataTableProdutoLevel = m_nDataTableProdutoLevel;
				int nQuantidadeLevels = 0;
				strHierarquia = strRetornaTextoHierarquia(ref nDataTableProdutoLevel,ref nQuantidadeLevels);
				nLevel = nQuantidadeLevels;
			}

			protected abstract string strRetornaTextoHierarquia(ref int nDataTableProdutoLevel,ref int nQuantidadeLevels);	

			private bool LevelChangeProductChilds(int nIdOrdem)
			{
				bool bRetorno = true;
				m_nDataTableProdutoLevel = nIdOrdem;
				return(bRetorno);
			} 

			protected abstract bool LevelChangeProductsParent();

		#endregion
		#region RowChanged 
			#region DataTable_RowChanged
				public void DataTable_RowChanged(object Sender,System.Data.DataRowChangeEventArgs e)
				{
					try
					{
						if (m_bDataTableEvents)
						{
							switch (e.Action)
							{
								case System.Data.DataRowAction.Add: // Add a Line
									DataTable_RowInserting(e);
									break;
									
								case System.Data.DataRowAction.Change: // Update a Line
									DataTable_RowUpdating(e);
									break;
							}
						}
					}
					catch (Exception erro)
					{
						Object err = (Object)erro;
						m_cls_ter_tratadorErro.trataErro(ref err);
					}
				}
			#endregion

			#region DataTable_RowInserting
				private void DataTable_RowInserting(System.Data.DataRowChangeEventArgs e)
				{
					if (m_bDataTableEvents)
					{
						DataTable_RowInserting(e.Row);
					}
				}

				protected abstract void DataTable_RowInserting(System.Data.DataRow dtrwProduto);
			#endregion
			#region DataTable_RowUpdating
				private void DataTable_RowUpdating(System.Data.DataRowChangeEventArgs e)
				{
					if (m_bDataTableEvents)
					{
						m_bDataTableEvents = false;
						if (m_dtrwProdutoUpdated != e.Row)
						{
							DataTable_RowUpdating(e.Row);
							m_dtrwProdutoUpdated = e.Row;
						}else{
							m_dtrwProdutoUpdated = null;
						}
						m_bDataTableEvents = true;
					}
				}

				protected abstract void DataTable_RowUpdating(System.Data.DataRow dtrowProduto);
		#endregion
			#region DataTable_RowDeleting
			protected void DataTable_RowDeleting(object Sender,System.Data.DataRowChangeEventArgs e)
			{
				if (m_bDataTableEvents)
				{
					int nIdOrdem = -1;
					try
					{
						nIdOrdem = Int32.Parse(e.Row[mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM].ToString());
					}
					catch (Exception erro)
					{
						Object err = (Object)erro;
						m_cls_ter_tratadorErro.trataErro(ref err);
					}
					if (nIdOrdem != -1)
					{
						DataTable_RowDeleting(nIdOrdem);
					}
				}
			}
				
			protected abstract void DataTable_RowDeleting(int nIdOrdem);

			#endregion
		#endregion

		#region DataTable Funcoes
			protected int nRetornaProximoNumeroTabela(ref System.Data.DataTable dttbTabela,ref System.Data.DataColumn dtclColuna,int nIndex)
			{
				int nRetorno = nIndex;
				System.Data.DataRow dtrwRow = null;
				bool bIndexExiste = true;
				while(bIndexExiste)
				{
					bIndexExiste = false;
					for (int nCont = 0; nCont < dttbTabela.Rows.Count; nCont++)
					{
						dtrwRow = dttbTabela.Rows[nCont];
						if (dtrwRow.RowState != System.Data.DataRowState.Deleted)
						{
							if (Int32.Parse(dtrwRow[dtclColuna].ToString()) == nRetorno)
							{
								bIndexExiste = true;
								nRetorno++;
								break;
							}
						}
					}
				} 
				return(nRetorno);
			}

			protected int nRetornaUltimoNumeroTabela(ref System.Data.DataTable dttbTabela,ref System.Data.DataColumn dtclColuna,int nIndex)
			{
				int nRetorno = nIndex;
				System.Data.DataRow dtrwRow = null;
				for (int nCont = 0; nCont < dttbTabela.Rows.Count; nCont++)
				{
					dtrwRow = dttbTabela.Rows[nCont];
					if (dtrwRow.RowState != System.Data.DataRowState.Deleted)
						if (Int32.Parse(dtrwRow[dtclColuna].ToString()) > nRetorno)
							nRetorno = Int32.Parse(dtrwRow[dtclColuna].ToString());
				} 
				return(nRetorno);
			}
		#endregion

		#region Remove Produtos Nulos
			protected abstract void vRemoveProdutosNulos();
		#endregion
	}
}
