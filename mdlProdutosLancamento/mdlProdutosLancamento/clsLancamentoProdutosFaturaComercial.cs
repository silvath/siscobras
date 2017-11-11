using System;
using System.Collections;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsLancamentoProdutosFaturaComercial.
	/// </summary>
	public class clsLancamentoProdutosFaturaComercial : clsLancamentoProdutos
	{
		#region Constantes
			private const int CLASS_TAR_NORMAL = 0; 
			private const int CLASS_TAR_NCM = 1; 
			private const int CLASS_TAR_NALADI = 2; 
		#endregion
		#region Atributos
		// ***************************************************************************************************
		// Atributos
		// ***************************************************************************************************
		private string m_strIdPE;
		private int m_nIdClassificacaoTarifariaMostrar = 0;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial;

		private clsPropriedadesProdutos m_cls_Propriedades = null;
		// ***************************************************************************************************
		#endregion 
		#region Properties
			private clsPropriedadesProdutos Propriedades
			{
				get
				{
					if (m_cls_Propriedades != null)
						return(m_cls_Propriedades);
					m_cls_Propriedades = new clsPropriedadesProdutosFaturaComercial(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					return(m_cls_Propriedades);
				}
			}
		#endregion
		#region Construtores e Destrutores
		public clsLancamentoProdutosFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel, ref System.Windows.Forms.ImageList Bandeiras,int idExportador,string idPe) : base(ref tratadorErro,ref ConnectionDB,strEnderecoExecutavel,ref Bandeiras,idExportador) 
		{
			m_strIdPE = idPe;
		}
		#endregion

		#region Carregamento dos Dados
		protected override void CarregaDadosBDEspecificos()
		{
			System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			arlCondicoesNome.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);
			arlCondicoesNome.Add("idPe");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_strIdPE);
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);

			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturaComercial = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
			if (dtrwRowTbFaturaComercial != null)
			{
				// Idioma
				if (!dtrwRowTbFaturaComercial.IsidIdiomaNull())
				{
					m_nIdioma = dtrwRowTbFaturaComercial.idIdioma;
					// Adquirindo a descricao do idioma 
					arlCondicoesNome = new System.Collections.ArrayList();
					arlCondicoesComparador = new System.Collections.ArrayList();
					arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idIdioma");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdioma);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetTbIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwRowTbIdioma = typDatSetTbIdiomas.tbIdiomas.FindByidIdioma(m_nIdioma);
					if (dtrwRowTbIdioma != null)
					{
						if (!dtrwRowTbIdioma.IsmstrIdiomaNull())
							m_strIdioma = dtrwRowTbIdioma.mstrIdioma;
					}
				}

				// Moeda 
				if (!dtrwRowTbFaturaComercial.IsidMoedaNull())
					m_nMoeda = dtrwRowTbFaturaComercial.idMoeda;

				// Detalhamento dos Produtos
				m_bDetalharProdutos = false;
				if (!dtrwRowTbFaturaComercial.IsbDetalharProdutosNull())
				{
					m_bDetalharProdutos = dtrwRowTbFaturaComercial.bDetalharProdutos;
				}

				// ClassificacaoTarifariaMostrar
				if (!dtrwRowTbFaturaComercial.IsidClassificacaoTarifariaMostrarNull())
					m_nIdClassificacaoTarifariaMostrar = dtrwRowTbFaturaComercial.idClassificacaoTarifariaMostrar;
			}
		}

		protected override void CarregaDadosBDProdutosEspecificos()
		{
			m_typDatSetTbProdutosFaturaComercial = typDatSetCarregaDadosBDProdutosEspecificos();
			m_bHasProducts = (m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count > 0);
		}

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetCarregaDadosBDProdutosEspecificos()
		{
			System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			arlCondicoesNome.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);
			arlCondicoesNome.Add("idPe");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_strIdPE);

			System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
			arlOrdenacaoCampo.Add("idOrdem");
			arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			return(m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoCampo,arlOrdenacaoTipo));
		}
		#endregion
		#region Salvamento dos Dados
				protected override bool bSalvaDadosBDColunas()
				{
					bool bRetorno = false;
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idPe");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strIdPE);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);

					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRow;
						dtrwRow = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);                    
						if (dtrwRow != null)
						{
//							// Ordem Lancamento
//							dtrwRow.nColunaOrdemLancamento = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_ORDEM_LANCAMENTO);
//							dtrwRow.nTamanhoColunaOrdemLancamento = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_ORDEM_LANCAMENTO);
//							// Codigo
//							dtrwRow.colunaCodigo = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_CÓDIGO);
//							dtrwRow.tamanhoColunaCodigo = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_CÓDIGO);
//							// Descrição
//							dtrwRow.colunaDescricao = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_DESCRICAO);
//							dtrwRow.tamanhoColunaDescricao = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_DESCRICAO);
//							// Descrição Lingua Estrangeira 
//							dtrwRow.colunaDescricaoLinguaEstrangeira = m_cls_mac_Colunas.GetPosicao(m_strIdioma);
//							dtrwRow.tamanhoColunaDescricaoLinguaEstrangeira = m_cls_mac_Colunas.GetTamanho(m_strIdioma);
//							// Unidade
//							dtrwRow.colunaUnidade = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_UNIDADE);
//							dtrwRow.tamanhoColunaUnidade = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_UNIDADE);
//							// Preço Unitário
//							dtrwRow.colunaPrecoUnitario = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_PRECO_UNITARIO);
//							dtrwRow.tamanhoColunaPrecoUnitario = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_PRECO_UNITARIO);
//							// Quantidade
//							dtrwRow.colunaQuantidade = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_QUANTIDADE);
//							dtrwRow.tamanhoColunaQuantidade = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_QUANTIDADE);
//							// Detalhar
//							dtrwRow.nColunaDetalharProdutos = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_DETALHAR);
//							dtrwRow.nTamanhoColunaDetalharProdutos = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_DETALHAR);
//							// Ncm
//							dtrwRow.nColunaNcm = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_NCM);
//							dtrwRow.nTamanhoColunaNcm = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_NCM);
//							// Naladi
//							dtrwRow.nColunaNaladi = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_NALADI);
//							dtrwRow.nTamanhoColunaNaladi = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_NALADI);
//							// Ncm Denominacao
//							dtrwRow.nColunaNcmDenominacao = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_NCM_DENOMINACAO);
//							dtrwRow.nTamanhoColunaNcmDenominacao = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_NCM_DENOMINACAO);
//							// Naladi Denominacao
//							dtrwRow.nColunaNaladiDenominacao = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_NALADI_DENOMINACAO);
//							dtrwRow.nTamanhoColunaNaladiDenominacao = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_NALADI_DENOMINACAO);
//							// Grupo
//							dtrwRow.nColunaPersonalizavel = m_cls_mac_Colunas.GetPosicao(TEXTO_COLUNA_GRUPO);
//							dtrwRow.nTamanhoColunaPersonalizavel = m_cls_mac_Colunas.GetTamanho(TEXTO_COLUNA_GRUPO);

							// Detalhamento 
							dtrwRow.bDetalharProdutos = m_bDetalharProdutos;

							// Salvando 
							m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
							bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
							if (bRetorno)
								m_typDatSetTbFaturasComerciais.AcceptChanges();
						}
						m_cls_mac_Colunas.SalvaColunasFaturaComercial(m_strIdPE);
					}
					return(bRetorno);
				}

				protected override void vIntegridadeProduto(int nIdOld,int nIdNew)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
						if ((dtrwProduto.RowState != System.Data.DataRowState.Deleted) && (dtrwProduto.idProduto == nIdOld))
							dtrwProduto.idProduto = nIdNew; 
				}
						
				protected override bool bSalvaDadosBDProdutosFatura()
				{
					bool bRetorno = false;

   					if (m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.GetChanges() != null){
						// Removendo Vinculacao do Romaneio
						mdlProdutosBordero.clsProdutosBordero cls_prod_bordero = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
						cls_prod_bordero.bRemoveTodosVinculosComContratosCambio();
						vIntegridadeProdutosFatura();
					}
					vReindexProdutosFatura();
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(m_typDatSetTbProdutosFaturaComercial);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					if (bRetorno)
						m_typDatSetTbProdutosFaturaComercial.AcceptChanges();
					if (m_nIdClassificacaoTarifariaMostrar != CLASS_TAR_NORMAL)
						vCheckClassificacaoTarifaria();
					return(bRetorno);
				}

				protected override bool bSalvaProdutosPropriedades()
				{
					return(this.Propriedades.SalvaDados());
				}

				protected void vIntegridadeProdutosFatura()
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutos = typDatSetCarregaDadosBDProdutosEspecificos();
					// Integridade
					int nIdOrdemNext = nReturnLastIdProdutoFatura(ref typDatSetProdutos) + 1;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
					{
						if ((dtrwProduto.RowState != System.Data.DataRowState.Deleted) && (!dtrwProduto.IsnIdOrdemProdutoParentNull()) && (dtrwProduto.nIdOrdemProdutoParent == 0))
							vIntegridadeProdutoFaturaModifica(ref typDatSetProdutos,dtrwProduto.idOrdem,ref nIdOrdemNext);
					}
				}

				protected void vIntegridadeProdutoFaturaModifica(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutos,int nIdOrdemOld,ref int nIdOrdemNew)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = typDatSetProdutos.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemOld);
					if (dtrwProduto != null)
					{
						dtrwProduto.idOrdem = nIdOrdemNew;
						nIdOrdemNew++;
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoChild in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
						{
							if ((dtrwProdutoChild.RowState != System.Data.DataRowState.Deleted) && (!dtrwProdutoChild.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoChild.nIdOrdemProdutoParent == nIdOrdemOld))
								vIntegridadeProdutoFaturaModifica(ref typDatSetProdutos,dtrwProduto.idOrdem,ref nIdOrdemNew);
						}
					}
				}

				private int nReturnLastIdProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutos)
				{
					int nId = 0;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in typDatSetTbProdutos.tbProdutosFaturaComercial.Rows)
					{
						if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwProduto.idOrdem > nId)
								nId = dtrwProduto.idOrdem;
						}
					}
					return(nId);
				}


				private void vReindexProdutosFatura()
				{
					for(int i = 1; i <= GetProdutosFaturaCount();i++)
						while(GetProdutoFaturaIndex(i) == -1)
							vDecreaseProdutosFaturaIndex(i + 1);
				}

				private int GetProdutosFaturaCount()
				{
					int count = 0;
					for(int i = 0; i < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial[i];
						if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
							count++;
					}
					return(count);
				}

				private int GetProdutosFaturaHigherIndex()
				{
					int higher = 1;
					for(int i = 0; i < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial[i];
						if ((dtrwProduto.RowState != System.Data.DataRowState.Deleted) && (dtrwProduto.idOrdem > higher))
							higher = dtrwProduto.idOrdem;
					}
					return(higher);
				}

				private int GetProdutoFaturaIndex(int idOrdem)
				{
					for(int i = 0; i < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial[i];
						if ((dtrwProduto.RowState != System.Data.DataRowState.Deleted) && (dtrwProduto.idOrdem == idOrdem))
							return(i);
					}
					return(-1);
				}
				
				private void vDecreaseProdutosFaturaIndex(int nStartIndex)
				{
					for(int i = nStartIndex; i <= GetProdutosFaturaHigherIndex();i++)
					{
						for(int j = 0; j < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;j++)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial[j];
							if ((dtrwProduto.RowState != System.Data.DataRowState.Deleted) && (dtrwProduto.idOrdem == i))
							{
								dtrwProduto.idOrdem--;  
								break;
							}
						}
					}
				}
		#endregion

		#region Classificacao Tarifária
			private void vCheckClassificacaoTarifaria()
			{
				switch(m_nIdClassificacaoTarifariaMostrar)
				{
					case CLASS_TAR_NCM:
						mdlProdutosVinculacao.clsProdutosVincular cls_tar_ProdutosNcm = new mdlProdutosVinculacao.clsProdutosVincular(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlProdutosVinculacao.Classificacao.Ncm);
						if (cls_tar_ProdutosNcm.bExisteProdutosSemVinculo())
						{
							if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosFaturaComercial_frmRelatoriosFaturaComercial_TrocarClassificacaoParaNCM).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								cls_tar_ProdutosNcm.ShowDialog();
								if (cls_tar_ProdutosNcm.bExisteProdutosSemVinculo())
									vClassificacaoTarifariaNenhuma();
							}else{
								vClassificacaoTarifariaNenhuma();
							}
						}
						break;
					case CLASS_TAR_NALADI:
						mdlProdutosVinculacao.clsProdutosVincular cls_tar_ProdutosNaladi = new mdlProdutosVinculacao.clsProdutosVincular(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlProdutosVinculacao.Classificacao.Naladi);
						if (cls_tar_ProdutosNaladi.bExisteProdutosSemVinculo())
						{
							if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRelatoriosFaturaComercial_frmRelatoriosFaturaComercial_TrocarClassificacaoParaNALADI).Replace("\\n","\n"),System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								cls_tar_ProdutosNaladi.ShowDialog();
								if (!cls_tar_ProdutosNaladi.bExisteProdutosSemVinculo())
									vClassificacaoTarifariaNenhuma();
							}else{
								vClassificacaoTarifariaNenhuma();
							}
						}
						break;
				}
			}

			private void vClassificacaoTarifariaNenhuma()
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					dtrwRowTbFaturasComerciais.idClassificacaoTarifariaMostrar = CLASS_TAR_NORMAL;
					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
				}
			}
		#endregion

		#region Refresh DataTable 
		protected override void RefreshDataDataTable(ref System.Data.DataTable dttbProdutos)
		{
			try
			{

				// Desativando os Eventos do DataTable
				m_bDataTableEvents = false;

				// DataRows 
				System.Data.DataRow dtrwProdutoMaster; 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura;

				// SortedList 
				mdlComponentesColecoes.clsComparerNumbersTexts cls_cmp_NumeroseTextos = new mdlComponentesColecoes.clsComparerNumbersTexts();
				System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList(cls_cmp_NumeroseTextos);

				// Correndo a lista dos Produtos da Fatura 
				for(int nCont = 0; nCont < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
					if (dtrwProdutoFatura.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == m_nDataTableProdutoLevel))
						{
							sortLstProdutos.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
						}
					}
				}

				// Limpando a Tabela 
				dttbProdutos.Rows.Clear();

				// Inserindo os Produtos
				for (int nCont = 0;nCont < sortLstProdutos.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)sortLstProdutos.GetByIndex(nCont);
					dtrwProdutoMaster = dttbProdutos.NewRow();
					// Ordem 
					dtrwProdutoMaster[TEXTO_COLUNA_IDORDEM] = dtrwProdutoFatura.idOrdem;

					// Ordem Lancamento 
					if (!dtrwProdutoFatura.IsidOrdemLancamentoNull())
						dtrwProdutoMaster[TEXTO_COLUNA_ORDEM_LANCAMENTO] = dtrwProdutoFatura.idOrdemLancamento;

					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						// IdProduto
						dtrwProdutoMaster[TEXTO_COLUNA_IDPRODUTO] = dtrwProdutoFatura.idProduto;
						// Codigo 
						if (!dtrwProdutoFatura.IsmstrCodigoProdutoNull())
							dtrwProdutoMaster[TEXTO_COLUNA_CÓDIGO] = dtrwProdutoFatura.mstrCodigoProduto;
						else
							dtrwProdutoMaster[TEXTO_COLUNA_CÓDIGO] = strRetornaCodigoProduto(dtrwProdutoFatura.idProduto);
						// Descricao
						if (!dtrwProdutoFatura.IsmstrDescricaoNull())
							dtrwProdutoMaster[TEXTO_COLUNA_DESCRICAO] = dtrwProdutoFatura.mstrDescricao;
						else
							dtrwProdutoMaster[TEXTO_COLUNA_DESCRICAO] = strRetornaDescricaoProduto(dtrwProdutoFatura.idProduto);
						// Descricao Lingua Estrangeira 
						if (!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull())
							dtrwProdutoMaster[m_strIdioma] = dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira;
						else
							dtrwProdutoMaster[m_strIdioma] = strRetornaDescricaoProdutoLinguaEstrangeira(dtrwProdutoFatura.idProduto);

						// NCM
						string strNcm;
						if (!dtrwProdutoFatura.IsstrNcmNull())
						{
							strNcm = dtrwProdutoFatura.strNcm;
							if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
								dtrwProdutoMaster[TEXTO_COLUNA_NCM_DENOMINACAO] = dtrwProdutoFatura.mstrNcmDenominacao;
						}else{
							strNcm = strRetornaNcmProduto(dtrwProdutoFatura.idProduto);
							dtrwProdutoMaster[TEXTO_COLUNA_NCM_DENOMINACAO] = strRetornaDenominacaoNcm(strNcm);
						}
						dtrwProdutoMaster[TEXTO_COLUNA_NCM] = strNcm;

						// Naladi
						string strNaladi;
						if (!dtrwProdutoFatura.IsstrNaladiNull())
						{
							strNaladi = dtrwProdutoFatura.strNaladi;
							if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
								dtrwProdutoMaster[TEXTO_COLUNA_NALADI_DENOMINACAO] = dtrwProdutoFatura.mstrNaladiDenominacao;
						}else{
							strNaladi = strRetornaNaladiProduto(dtrwProdutoFatura.idProduto);
							dtrwProdutoMaster[TEXTO_COLUNA_NALADI_DENOMINACAO] = strRetornaDenominacaoNaladi(strNaladi);
						}
						dtrwProdutoMaster[TEXTO_COLUNA_NALADI] = strNaladi;
					}

					// Preco Unitario 
					if (!dtrwProdutoFatura.IsdPrecoUnitarioNull())
						dtrwProdutoMaster[TEXTO_COLUNA_PRECO_UNITARIO] = dtrwProdutoFatura.dPrecoUnitario;

					// Quantidade 
					if (!dtrwProdutoFatura.IsdQuantidadeNull())
						dtrwProdutoMaster[TEXTO_COLUNA_QUANTIDADE] = dtrwProdutoFatura.dQuantidade;

					// Unidade 
					if (!dtrwProdutoFatura.IsstrUnidadeNull())
						dtrwProdutoMaster[TEXTO_COLUNA_UNIDADE] = dtrwProdutoFatura.strUnidade;

					// Grupo
					if (!dtrwProdutoFatura.IsmstrPersonalizavelNull())
						dtrwProdutoMaster[TEXTO_COLUNA_GRUPO] = dtrwProdutoFatura.mstrPersonalizavel;

					// Detalhar 
					dtrwProdutoMaster[TEXTO_COLUNA_DETALHAR] = dtrwProdutoFatura.bDetalharChilds;

					// Propriedades
					this.Propriedades.PreenchePropriedadesProduto(dtrwProdutoFatura.idOrdem,dtrwProdutoMaster);

					dttbProdutos.Rows.Add(dtrwProdutoMaster);
				}

				// Ativando os Eventos do DataTable
				m_bDataTableEvents = true;
			}catch (System.Exception expErro){
				object objErro = (object)expErro;
				m_cls_ter_tratadorErro.trataErro(ref objErro);
			}
		}
		#endregion
		#region Refresh SubTotal
			protected override void vRefreshSubTotal(ref System.Windows.Forms.Label lbSubTotal)
			{
				double dValor = 0;
				if (m_typDatSetTbProdutosFaturaComercial != null)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
					{
						if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
							if ((!dtrwProduto.IsdPrecoUnitarioNull()) && (!dtrwProduto.IsdQuantidadeNull()))
								dValor = System.Math.Round(dValor + (dtrwProduto.dPrecoUnitario * dtrwProduto.dQuantidade),2);  
					}
				}
				lbSubTotal.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nMoeda,dValor,true);
			}
		#endregion
		#region Manipulador de Colunas 
		protected override void CarregaColunasManipuladorColunas()
		{
			try
			{
				m_cls_mac_Colunas.CarregaColunasFaturaComercial(m_strIdPE);
				if (m_nIdioma == 1)
					m_cls_mac_Colunas.RemoveColuna(m_strIdioma);
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Hierarquia
			protected override string strRetornaTextoHierarquia(ref int nDataTableLevel,ref int nQuantidadeLevels)	
			{
				string strRetorno = "";
				if (nDataTableLevel != 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nDataTableLevel);
					if (dtrwProdutoFatura != null)
					{
						if (!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull())
							nDataTableLevel = dtrwProdutoFatura.nIdOrdemProdutoParent;
						else
							nDataTableLevel = 0;
						nQuantidadeLevels++;
						string strProdutosAnteriores = strRetornaTextoHierarquia(ref nDataTableLevel,ref nQuantidadeLevels);
						if (strProdutosAnteriores != "")
						{
							strRetorno =  strProdutosAnteriores + " " + mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_DIVISOR_HIERARQUIA + " "; 
						}
						if (!dtrwProdutoFatura.IsidProdutoNull())
							strRetorno += strRetornaDescricaoProduto(dtrwProdutoFatura.idProduto);
					}
				}
				return(strRetorno);
			}

			protected override bool LevelChangeProductsParent()
			{
				bool bRetorno = false;
				if (m_nDataTableProdutoLevel != 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,m_nDataTableProdutoLevel);
					if (dtrwProdutoFatura != null)
					{
						m_nDataTableProdutoLevel = dtrwProdutoFatura.nIdOrdemProdutoParent;
						bRetorno = true;
					}
				}
				return(bRetorno);
			} 
		#endregion

		#region Linhas
			protected override bool bTrocaLinhas(int nOrdem1,int nOrdem2)
			{
				bool bRetorno = false;
				System.Data.DataRow dtrwOrdem1 = null;
				System.Data.DataRow dtrwOrdem2 = null;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (Int32.Parse(dtrwProduto[TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString()) == nOrdem1)
							dtrwOrdem1 = dtrwProduto;
						if (Int32.Parse(dtrwProduto[TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString()) == nOrdem2)
							dtrwOrdem2 = dtrwProduto;
						if ((dtrwOrdem1 != null) && (dtrwOrdem2 != null))
							break;
					}
				}
				if ((dtrwOrdem1 != null) && (dtrwOrdem2 != null) && (dtrwOrdem1 != dtrwOrdem2))
				{
					dtrwOrdem1[TEXTO_COLUNA_IDORDEM] = -1;
					dtrwOrdem2[TEXTO_COLUNA_IDORDEM] = -2;
					vInsereNovaLinha(dtrwOrdem1,nOrdem2);
					vInsereNovaLinha(dtrwOrdem2,nOrdem1);
					dtrwOrdem1.Delete();
					dtrwOrdem2.Delete();
					vTrocaParentProdutosIntegrante(nOrdem1,nOrdem2,nOrdem2,nOrdem1);
					this.Propriedades.TrocaOrdemProduto(nOrdem1,nOrdem2);
					bRetorno = true;
				}
				return(bRetorno);
			}

			protected override void vInsereNovaLinha(System.Data.DataRow dtrwProduto,int nNovoValorColuna)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoNovo = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.NewtbProdutosFaturaComercialRow();
				foreach(System.Data.DataColumn dtclColuna in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Columns)
					dtrwProdutoNovo[dtclColuna] = dtrwProduto[dtclColuna,System.Data.DataRowVersion.Current];
				dtrwProdutoNovo[TEXTO_COLUNA_IDORDEM] = nNovoValorColuna;
				m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.AddtbProdutosFaturaComercialRow(dtrwProdutoNovo);
			}

			protected override void vTrocaParentProdutosIntegrante(int nOrdemAtual1,int nOrdemNova1,int nOrdemAtual2,int nOrdemNova2)
			{
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
				{
					if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
					{
						if (!dtrwProduto.IsnIdOrdemProdutoParentNull())
						{
							if (dtrwProduto.nIdOrdemProdutoParent == nOrdemAtual1)
							{
								dtrwProduto.nIdOrdemProdutoParent = nOrdemAtual2;
								continue;
							}else if (dtrwProduto.nIdOrdemProdutoParent == nOrdemAtual2)
							{
								dtrwProduto.nIdOrdemProdutoParent = nOrdemAtual1;
								continue;
							}
						}
					}
				}
			}

			protected override bool bLinhaInsere(int nIdOrdemInserir)
			{
				bool bRetorno = false;
				int nIdOrdem;
				int nIdOrdemLancamento; 

				System.Data.DataTable dttbTabela = (System.Data.DataTable)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial;
				System.Data.DataColumn dtclColuna = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Columns["idOrdem"];
				nIdOrdem = nRetornaUltimoNumeroTabela(ref dttbTabela,ref dtclColuna,1) + 1;
				dtclColuna = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Columns["idOrdemLancamento"];
				nIdOrdemLancamento = nRetornaUltimoNumeroTabela(ref dttbTabela,ref dtclColuna,1) + 1;

				// Inserindo Row 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.NewtbProdutosFaturaComercialRow();
				dtrwProdutoFatura.idExportador = m_nIdExportador;
				dtrwProdutoFatura.idPE = m_strIdPE;
				dtrwProdutoFatura.idOrdem = nIdOrdem;
				dtrwProdutoFatura.idOrdemLancamento = nIdOrdemLancamento;
				dtrwProdutoFatura.nIdOrdemProdutoParent = m_nDataTableProdutoLevel;
				dtrwProdutoFatura.idProduto = -1;
				dtrwProdutoFatura.bDetalharChilds = true;
				m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Add(dtrwProdutoFatura);

				// Movendo para a Posicao Correta
				int nIdOrdemCursor = nIdOrdem;
				while(nIdOrdemCursor != nIdOrdemInserir)
				{
					if (bOrdemExiste(nIdOrdemCursor - 1))
					{
						bTrocaLinhas(nIdOrdem,nIdOrdemCursor - 1);
						nIdOrdem = nIdOrdemCursor - 1;
					}
					nIdOrdemCursor--;
				}
				bRetorno = true;
				return(bRetorno);
			}	

			private bool bOrdemExiste(int nIdOrdem)
			{
				return(m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdem) != null);
			}
		#endregion

		#region RowChanged
			#region DataTable_RowInserting
		protected override  void DataTable_RowInserting(System.Data.DataRow dtrwProduto)
		{
			// IdOrdem
			object objIdOrdem = dtrwProduto[TEXTO_COLUNA_IDORDEM];
			if (objIdOrdem != null)
			{
				string strIdOrdem = objIdOrdem.ToString();
				int nIdOrdem; 
				int nIdOrdemLancamento; 
				try
				{
					nIdOrdem = Int32.Parse(strIdOrdem);
				}
				catch
				{
					System.Data.DataTable dttbTabela = (System.Data.DataTable)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial;
					System.Data.DataColumn dtclColuna = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Columns["idOrdem"];
					nIdOrdem = nRetornaUltimoNumeroTabela(ref dttbTabela,ref dtclColuna,1) + 1;

					dtclColuna = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Columns["idOrdemLancamento"];
					nIdOrdemLancamento = nRetornaProximoNumeroTabela(ref dttbTabela,ref dtclColuna,1);

					// Inserindo Row 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.NewtbProdutosFaturaComercialRow();

					dtrwProdutoFatura.idExportador = m_nIdExportador;
					dtrwProdutoFatura.idPE = m_strIdPE;
					dtrwProdutoFatura.idOrdem = nIdOrdem;
					dtrwProdutoFatura.idOrdemLancamento = nIdOrdemLancamento;
					dtrwProdutoFatura.nIdOrdemProdutoParent = m_nDataTableProdutoLevel;
					dtrwProdutoFatura.bDetalharChilds = true;

					m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Add(dtrwProdutoFatura);

					dtrwProduto[TEXTO_COLUNA_IDORDEM] = nIdOrdem;
					dtrwProduto.Table.Columns[TEXTO_COLUNA_ORDEM_LANCAMENTO].ReadOnly = false;
					dtrwProduto[TEXTO_COLUNA_ORDEM_LANCAMENTO] = nIdOrdemLancamento;
					dtrwProduto.Table.Columns[TEXTO_COLUNA_ORDEM_LANCAMENTO].ReadOnly = true;
					dtrwProduto[TEXTO_COLUNA_DETALHAR] = true;
					m_formFProdutos.OnCallRefreshSubTotal();
				}
			}
		}
		#endregion
			#region DataTable_RowUpdating
		protected override  void DataTable_RowUpdating(System.Data.DataRow dtrwProduto)
		{
			try
			{
				int nIdOrdem = -1;
				double dPrecoUnitario = 0;
				double dQuantidade = 0;
				string strUnidade = "";
				bool bDetalhar = false;

				int nIdProdutoBefore = -1;
				int nIdProduto = -1;
				int nIdProdutoAfter = -1;
				bool bExisteProdutoAfter = false;
				int nIdProdutoAfterCodigoProduto = -1;
				bool bExisteCodigoProdutoAfter = false;
				// Typed DataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = null;

				#region IdOrdem
				// IdOrdem
				try
				{
					nIdOrdem = Int32.Parse(dtrwProduto[TEXTO_COLUNA_IDORDEM,System.Data.DataRowVersion.Current].ToString());
				}
				catch
				{
					nIdOrdem = -1;
				}
				#endregion
				#region Preco Unitario
				// PrecoUnitario 
				try
				{
					dPrecoUnitario = double.Parse(dtrwProduto[TEXTO_COLUNA_PRECO_UNITARIO,System.Data.DataRowVersion.Current].ToString());
				}
				catch
				{
					dPrecoUnitario = 0;
				}
				#endregion
				#region Quantidade
				// Quantidade
				try
				{
					dQuantidade = double.Parse(dtrwProduto[TEXTO_COLUNA_QUANTIDADE,System.Data.DataRowVersion.Current].ToString());
				}
				catch
				{
					dQuantidade = 0;
				}
				#endregion
				#region Unidade
				// Unidade
				try
				{
					strUnidade = dtrwProduto[TEXTO_COLUNA_UNIDADE,System.Data.DataRowVersion.Current].ToString();
				}
				catch
				{
					strUnidade = "";
				}
				#endregion
				#region Detalhar 
				if (dtrwProduto[TEXTO_COLUNA_DETALHAR] != null)
					bDetalhar = bool.Parse(dtrwProduto[TEXTO_COLUNA_DETALHAR,System.Data.DataRowVersion.Current].ToString());
				#endregion

				if (nIdOrdem != -1)
				{
					// Procurando a DataRow do Produto modificado na tabela dos produtos da fatura 
					dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdem);
					if (dtrwProdutoFatura != null)
					{
						#region Localizando IdProdutoBefore 
						try
						{
							nIdProdutoBefore = Int32.Parse(dtrwProduto[TEXTO_COLUNA_IDPRODUTO,System.Data.DataRowVersion.Current].ToString());
						}
						catch
						{
							nIdProdutoBefore = -1;
						}
						#endregion
						#region Localizando ExisteProdutoAfter
						bExisteProdutoAfter = dtrwProduto[TEXTO_COLUNA_DESCRICAO,System.Data.DataRowVersion.Current].ToString().Trim() != "";
						#endregion
						#region Localizando IdProdutoAfter
						nIdProdutoAfter = m_formFProdutos.nRetornaIdProdutoSegundoComboBoxProdutos(dtrwProduto[TEXTO_COLUNA_DESCRICAO,System.Data.DataRowVersion.Current].ToString());
						#endregion
						#region Localizando ExisteCodigoProdutoAfter
						bExisteCodigoProdutoAfter = dtrwProduto[TEXTO_COLUNA_CÓDIGO,System.Data.DataRowVersion.Current].ToString().Trim() != "";
						#endregion
						#region Localizando IdProdutoAfterCodigoProduto
						nIdProdutoAfterCodigoProduto = m_formFProdutos.nRetornaIdProdutoSegundoComboBoxCodigosProdutos(dtrwProduto[TEXTO_COLUNA_CÓDIGO,System.Data.DataRowVersion.Current].ToString());
						#endregion
						#region Obtendo Dados 
						string strCodigo = "";
						string strDescricao = "";
						string strDescricaoLinguaEstrangeira = "";
						string strNcm = "";
						string strNaladi = "";
						string strNcmDenominacao = "";
						string strNaladiDenominacao = "";
						string strGrupo = "";
						if (dtrwProduto[TEXTO_COLUNA_CÓDIGO] != null)
							strCodigo = dtrwProduto[TEXTO_COLUNA_CÓDIGO].ToString();
						if (dtrwProduto[TEXTO_COLUNA_DESCRICAO] != null)
							strDescricao = dtrwProduto[TEXTO_COLUNA_DESCRICAO].ToString();
						if (dtrwProduto[m_strIdioma] != null) 
							strDescricaoLinguaEstrangeira = dtrwProduto[m_strIdioma].ToString();
						if (dtrwProduto[TEXTO_COLUNA_NCM] != null)
							strNcm = dtrwProduto[TEXTO_COLUNA_NCM].ToString();
						if (dtrwProduto[TEXTO_COLUNA_NALADI] != null)
							strNaladi = dtrwProduto[TEXTO_COLUNA_NALADI].ToString();
						if (dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO] != null)
							strNcmDenominacao = dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO].ToString();
						if (dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO] != null)
							strNaladiDenominacao = dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO].ToString();
						if (dtrwProduto[TEXTO_COLUNA_GRUPO] != null)
							strGrupo = dtrwProduto[TEXTO_COLUNA_GRUPO].ToString();
						#endregion

						#region Checagens Produto
						if (nIdProdutoBefore == -1)
						{
							// SEM IdProdutoBefore 
							if (nIdProdutoAfterCodigoProduto == -1)
							{
								// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto
								if (nIdProdutoAfter == -1)
								{
									// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											//Cadastrando o produto com o codigo
											nIdProduto = nCadastraProduto(strCodigo,strDescricao,strDescricaoLinguaEstrangeira);
											m_formFProdutos.RefreshCBCodigos();
											m_formFProdutos.RefreshCBProdutos();
										}
										else
										{
											// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || NAO ExisteProdutoAfter
											// OK
											dtrwProduto[TEXTO_COLUNA_CÓDIGO] = "";
										}
									}
									else
									{
										// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || NAO ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || NAO ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nCadastraProduto(strCodigo,strDescricao,strDescricaoLinguaEstrangeira);
											if (nIdProduto > 0)
											{
												strCodigo = strRetornaCodigoProduto(nIdProduto);
												dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
											}
											m_formFProdutos.RefreshCBCodigos();
											m_formFProdutos.RefreshCBProdutos();
										}
									}
								}
								else
								{
									// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfter;
											mdlProdutosLancamento.RespostaPergunta enumAnswer = mdlProdutosLancamento.RespostaPergunta.Cancelar;
											if (this.CanEditProducts)
												enumAnswer = ShowDialogPerguntaCadastrarEditarDescricao();
											else
												enumAnswer = ShowDialogPerguntaCadastrarDescricao();
 											switch(enumAnswer)
											{
												case mdlProdutosLancamento.RespostaPergunta.Cadastra:
													nIdProduto = nCadastraProduto("",strDescricao,strDescricaoLinguaEstrangeira);
													strCodigo = strRetornaCodigoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													m_formFProdutos.RefreshCBCodigos();
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Edita:
													vModificaCodigoProduto(nIdProduto,dtrwProduto[TEXTO_COLUNA_CÓDIGO].ToString());
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Cancelar:
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strRetornaCodigoProduto(nIdProduto);
													break;
											}
										}
									}
									else
									{
										// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || NAO ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || NAO ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfter;
											dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
											dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strRetornaCodigoProduto(nIdProduto);
										}
									}
								}
							}
							else
							{
								// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto
								if (nIdProdutoAfter == -1)
								{
									// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfterCodigoProduto;
											mdlProdutosLancamento.RespostaPergunta enumAnswer = mdlProdutosLancamento.RespostaPergunta.Cancelar;
											if (this.CanEditProducts)
												enumAnswer = ShowDialogPerguntaCadastrarEditarDescricao();
											else
												enumAnswer = ShowDialogPerguntaCadastrarDescricao();
											switch(enumAnswer)
											{
												case mdlProdutosLancamento.RespostaPergunta.Cadastra:
													nIdProduto = nCadastraProduto("",strDescricao,strDescricaoLinguaEstrangeira);
													strCodigo = strRetornaCodigoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													m_formFProdutos.RefreshCBCodigos();
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Edita:
													vModificaDescricaoProduto(nIdProduto,dtrwProduto[TEXTO_COLUNA_DESCRICAO].ToString());
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Cancelar:
													dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strRetornaDescricaoProduto(nIdProduto);
													break;
											}
										}
										else
										{
											// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || NAO ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfterCodigoProduto;
											dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
											strDescricao = strRetornaDescricaoProduto(nIdProduto);
											dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strDescricao;
										}
									}
								}
								else
								{
									// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// SEM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											if (nIdProdutoAfter != nIdProdutoAfterCodigoProduto)
											{
												switch(ShowDialogPerguntaEscolheCodigoOuDescricao())
												{
													case mdlProdutosLancamento.RespostaPergunta.Codigo:
														nIdProduto = nIdProdutoAfterCodigoProduto;
														dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strRetornaDescricaoProduto(nIdProduto);
														break;
													case mdlProdutosLancamento.RespostaPergunta.Descricao:
														nIdProduto = nIdProdutoAfter;
														dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strRetornaCodigoProduto(nIdProduto);
														break;
												}
											}else{
												nIdProduto = nIdProdutoAfter;
											}
										}
									}
								}
							}
						}
						else
						{
							// COM IdProdutoBefore 
							if (nIdProdutoAfterCodigoProduto == -1)
							{
								// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto
								if (nIdProdutoAfter == -1)
								{
									// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											mdlProdutosLancamento.RespostaPergunta enumAnswer = mdlProdutosLancamento.RespostaPergunta.Cadastra;
                                            if (this.CanEditProducts)
												enumAnswer = ShowDialogPerguntaCadastrarNovoProdutoOuEditarAntigo();
											switch(enumAnswer)
											{
												case mdlProdutosLancamento.RespostaPergunta.Cadastra:
													nIdProduto = nCadastraProduto(strCodigo,strDescricao,strDescricaoLinguaEstrangeira);
													dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
													strCodigo = strRetornaCodigoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													break;
												case mdlProdutosLancamento.RespostaPergunta.Edita:
													vModificaCodigoProduto(nIdProdutoBefore,strCodigo);
													vModificaDescricaoProduto(nIdProdutoBefore,strDescricao);
													m_formFProdutos.RefreshCBCodigos();
													m_formFProdutos.RefreshCBProdutos();
													break;
											}
										}
										else
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || NAO ExisteProdutoAfter
											// OK
											dtrwProduto[TEXTO_COLUNA_CÓDIGO] = "";
										}
									}
									else
									{
										// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || NAO ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || NAO ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											nIdProduto = nCadastraProduto(strCodigo,strDescricao,strDescricaoLinguaEstrangeira);
											dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
											strCodigo = strRetornaCodigoProduto(nIdProduto);
											dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
										}
										else
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || NAO ExisteCodigoProdutoAfter || NAO ExisteProdutoAfter
											// NAO REALIZA NADA
										}
									}
								}
								else
								{
									// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoBefore;
											mdlProdutosLancamento.RespostaPergunta enumAnswer = mdlProdutosLancamento.RespostaPergunta.Cancelar;
											if (this.CanEditProducts)
												enumAnswer = ShowDialogPerguntaEditarCodigo();
											switch(enumAnswer)
											{
												case mdlProdutosLancamento.RespostaPergunta.Edita:
													vModificaCodigoProduto(nIdProdutoBefore,strCodigo);
													m_formFProdutos.RefreshCBCodigos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Cancelar:
													strCodigo = strRetornaCodigoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													break;
											}
										}
									}
									else
									{
										// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || NAO ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || SEM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || NAO ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfter;
											dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
											strCodigo = strRetornaCodigoProduto(nIdProduto);
											dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;  
										}
									}
								}
							}
							else
							{
								// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto
								if (nIdProdutoAfter == -1)
								{
									// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											nIdProduto = nIdProdutoAfterCodigoProduto;
											mdlProdutosLancamento.RespostaPergunta enumAnswer = mdlProdutosLancamento.RespostaPergunta.Cancelar;
											if (this.CanEditProducts)
												enumAnswer = ShowDialogPerguntaCadastrarEditarDescricao();
											else
												enumAnswer = ShowDialogPerguntaCadastrarDescricao();
											switch(enumAnswer)
											{
												case mdlProdutosLancamento.RespostaPergunta.Cadastra:
													nIdProduto = nCadastraProduto("",strDescricao,strDescricaoLinguaEstrangeira);
													dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
													strCodigo = strRetornaCodigoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													m_formFProdutos.RefreshCBCodigos();
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Edita:
													vModificaDescricaoProduto(nIdProduto,strDescricao);
													m_formFProdutos.RefreshCBProdutos();
													break;
												case mdlProdutosLancamento.RespostaPergunta.Cancelar:
													strDescricao = strRetornaDescricaoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strDescricao;
													break;
											}
										}
										else
										{
											// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || SEM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || NAO ExisteProdutoAfter
											// OK
											nIdProduto = nIdProdutoAfterCodigoProduto;
											dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
											strDescricao = strRetornaDescricaoProduto(nIdProduto);
											dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strDescricao;  
										}
									}
								}
								else
								{
									// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter
									if (bExisteCodigoProdutoAfter)
									{
										// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter
										if (bExisteProdutoAfter)
										{
											// COM IdProdutoBefore || COM IdProdutoAfterCodigoProduto || COM IdProdutoAfter || SIM ExisteCodigoProdutoAfter || SIM ExisteProdutoAfter
											if ((nIdProdutoBefore == nIdProdutoAfter) &&  (nIdProdutoBefore == nIdProdutoAfterCodigoProduto))
											{
												nIdProduto = nIdProdutoBefore;
											}else{
												if (nIdProdutoBefore == nIdProdutoAfter)
												{
													nIdProduto = nIdProdutoAfterCodigoProduto;
													dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
													strDescricao = strRetornaDescricaoProduto(nIdProduto);
													dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strDescricao;
												}
												else
												{
													if (nIdProdutoBefore == nIdProdutoAfterCodigoProduto)
													{
														nIdProduto = nIdProdutoAfter;
														dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
														strCodigo = strRetornaCodigoProduto(nIdProduto);
														dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
													}
													else
													{
														switch(ShowDialogPerguntaEscolheCodigoOuDescricao())
														{
															case mdlProdutosLancamento.RespostaPergunta.Codigo:
																nIdProduto = nIdProdutoAfterCodigoProduto;
																dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
																strDescricao = strRetornaDescricaoProduto(nIdProduto);
																dtrwProduto[TEXTO_COLUNA_DESCRICAO] = strDescricao;
																break;
															case mdlProdutosLancamento.RespostaPergunta.Descricao:
																nIdProduto = nIdProdutoAfter;
																dtrwProduto[TEXTO_COLUNA_IDPRODUTO] = nIdProduto;
																strCodigo = strRetornaCodigoProduto(nIdProduto);
																dtrwProduto[TEXTO_COLUNA_CÓDIGO] = strCodigo;
																break;
														}

													}
												}
											}
										}
									}
								}
							}
						}	
						#endregion
						#region Checagens Classificacoes
						if (nIdProduto != -1)
						{
							if (bClassificacaoTarifariaValida(ref strNcm))
							{
								if (dtrwProduto[TEXTO_COLUNA_NCM].ToString() != strNcm)
									dtrwProduto[TEXTO_COLUNA_NCM] = strNcm;
								if ((dtrwProdutoFatura.IsstrNcmNull()) || (strNcm != dtrwProdutoFatura.strNcm))
									dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO] = strNcmDenominacao =  strRetornaDenominacaoNcm(strNcm);
								if (strNcm != strRetornaNcmProduto(nIdProduto))
									SetNcmProduto(nIdProduto,strNcm,strNcmDenominacao);
							}else{
								if (nIdProdutoBefore == -1)
								{
									dtrwProduto[TEXTO_COLUNA_NCM] = strNcm = strRetornaNcmProduto(nIdProduto);
									dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO] = strNcmDenominacao = strRetornaDenominacaoNcm(strNcm);
								}else{
									strNcm = "";
									strNcmDenominacao = "";
									dtrwProduto[TEXTO_COLUNA_NCM] = strNcm;
									dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO] = strNcmDenominacao;
								}
							}
							if (bClassificacaoTarifariaValida(ref strNaladi))
							{
								if (dtrwProduto[TEXTO_COLUNA_NALADI].ToString() != strNaladi)
									dtrwProduto[TEXTO_COLUNA_NALADI] = strNaladi;
								if ((dtrwProdutoFatura.IsstrNaladiNull()) || (strNaladi != dtrwProdutoFatura.strNaladi))
									dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO] = strNaladiDenominacao =  strRetornaDenominacaoNaladi(strNaladi);
								if (strNaladi != strRetornaNaladiProduto(nIdProduto))
									SetNaladiProduto(nIdProduto,strNaladi,strNaladiDenominacao);
							}else{
								if (nIdProdutoBefore == -1)
								{
									dtrwProduto[TEXTO_COLUNA_NALADI] = strNaladi = strRetornaNaladiProduto(nIdProduto);
									dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO] = strNaladiDenominacao = strRetornaDenominacaoNaladi(strNaladi);
								}else{
									strNaladi = "";
									strNaladiDenominacao = "";
									dtrwProduto[TEXTO_COLUNA_NALADI] = strNaladi;
									dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO] = strNaladiDenominacao;
								}
							}
						}else{
							strNcm = "";
							strNcmDenominacao = "";
							dtrwProduto[TEXTO_COLUNA_NCM] = strNcm;
							dtrwProduto[TEXTO_COLUNA_NCM_DENOMINACAO] = strNcmDenominacao;
							strNaladi = "";
							strNaladiDenominacao = "";
							dtrwProduto[TEXTO_COLUNA_NALADI] = strNaladi;
							dtrwProduto[TEXTO_COLUNA_NALADI_DENOMINACAO] = strNaladiDenominacao;
						}
						#endregion

						#region Atualizando Produto Fatura TypedDataSet
						dtrwProdutoFatura.idProduto = nIdProduto;
						if (nIdProduto != -1)
						{
							if (dtrwProduto[m_strIdioma] != null)
							{
								if (strDescricaoLinguaEstrangeira == "")
								{
									strDescricaoLinguaEstrangeira = strRetornaDescricaoProdutoLinguaEstrangeira(nIdProduto);
									dtrwProduto[m_strIdioma] = strDescricaoLinguaEstrangeira;
								}
							}
							vModificaDescricaoLinguaEstrangeiraProduto(nIdProduto,strDescricaoLinguaEstrangeira);
						}
						dtrwProdutoFatura.dPrecoUnitario = dPrecoUnitario;
						dtrwProdutoFatura.dQuantidade = dQuantidade;
						dtrwProdutoFatura.strUnidade = strUnidade;
						dtrwProdutoFatura.bDetalharChilds = bDetalhar;
						dtrwProdutoFatura.mstrCodigoProduto = strCodigo;
						dtrwProdutoFatura.mstrDescricao = strDescricao;
						dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira = strDescricaoLinguaEstrangeira;
						dtrwProdutoFatura.strNcm = strNcm;
						dtrwProdutoFatura.strNaladi = strNaladi;
						dtrwProdutoFatura.mstrNcmDenominacao = strNcmDenominacao;
						dtrwProdutoFatura.mstrNaladiDenominacao = strNaladiDenominacao;
						dtrwProdutoFatura.mstrPersonalizavel = strGrupo;

						//Propriedades
						this.Propriedades.UpdatePropriedadesProduto(nIdOrdem,dtrwProduto);
						#endregion

						m_formFProdutos.OnCallRefreshSubTotal();
					}
				}
			}catch (System.Exception expErro){
				object objErro = (object)expErro;
				m_cls_ter_tratadorErro.trataErro(ref objErro);
			}
		}
		#endregion
			#region DataTable_RowDeleting
				protected override void DataTable_RowDeleting(int nIdOrdem)
				{
					try
					{

						//Data Rows
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto;

						// Deleting Child Products
						for(int nCont = 0; nCont < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if (dtrwProduto.RowState != System.Data.DataRowState.Deleted)
							{
								if ((!dtrwProduto.IsnIdOrdemProdutoParentNull()) && (dtrwProduto.nIdOrdemProdutoParent == nIdOrdem))
								{
									DataTable_RowDeleting(dtrwProduto.idOrdem);
								}
							}
						} 

						// Deleting the Product
						dtrwProduto = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdem);
						if ((dtrwProduto != null) && (dtrwProduto.RowState != System.Data.DataRowState.Deleted))
						{
							this.Propriedades.DeletePropriedadesProduto(nIdOrdem);
							dtrwProduto.Delete();
						}
						m_formFProdutos.OnCallRefreshSubTotal();
					}catch (System.Exception eErro){
						eErro.ToString();
					}
				}
			#endregion
		#endregion

		#region Remove Produtos Nulos
			protected override void vRemoveProdutosNulos()
			{
				for(int i = (m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count - 1); i >= 0;i--) 
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[i];
					if (dtrwProdutoFatura.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwProdutoFatura[TEXTO_COLUNA_IDPRODUTO] != null)
						{
							int nIdProduto = Int32.Parse(dtrwProdutoFatura[TEXTO_COLUNA_IDPRODUTO].ToString());
							if (nIdProduto == -1)
							{
								dtrwProdutoFatura.Delete();
							}
						}
					}
				}
			}
		#endregion

	}
}
