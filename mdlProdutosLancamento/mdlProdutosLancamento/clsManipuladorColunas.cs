using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsManipuladorColunas.
	/// </summary>
	public class clsManipuladorColunas
	{
		#region Enums
			internal enum DataGridColumnStyle
			{
                TextColumn,
				BoolColumn
			}
		#endregion

		#region Atributos
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private int m_nIdExportador = -1;
			private int m_nIdIdioma = -1;
			// *******************
			// Atrributos
			// *******************
			private System.Collections.ArrayList m_arlColunas = null;
			private string m_strLinguaEstrangeira = "";
			// *******************

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas m_typDatSetIdiomas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas m_typDatSetExportadoresColunas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas m_typDatSetFaturasCotacoesColunas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas m_typDatSetFaturasComerciaisColunas = null;
		#endregion
		#region Propriedades
			private mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas ExportadoresColunas
			{
				get
				{
					if (m_typDatSetExportadoresColunas != null)
						return(m_typDatSetExportadoresColunas);
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetExportadoresColunas = m_cls_dba_ConnectionDB.GetTbExportadoresColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetExportadoresColunas);
				}
			} 

			public mdlDataBaseAccess.clsDataBaseAccess ConexaoBD
			{
				set
				{
					m_cls_dba_ConnectionDB = value;
				}
				get
				{
					return(m_cls_dba_ConnectionDB);
				}
			}

			public int Count
			{
				get
				{
					return(m_arlColunas.Count);
				}
			}

			public int CountSistema
			{
				get
				{
					int nCount =0;
					for(int i = 0;i < this.Count;i++)
					{
						clsColuna objColuna = this[i];
						if (objColuna.Sistema) 
							nCount++;
					}
					return(nCount);
				}
			}

			public int CountValidas
			{
				get
				{
					int nCount =0;
					for(int i = 0;i < this.Count;i++)
					{
						clsColuna objColuna = this[i];
						if ((!objColuna.Inutilizada) && (!objColuna.Sistema))
							nCount++;
					}
   					return(nCount);
				}
			}

			public int CountInvalidas
			{
				get
				{
					int nCount =0;
					for(int i = 0;i < this.Count;i++)
					{
						clsColuna objColuna = this[i];
						if ((objColuna.Inutilizada) && (!objColuna.Sistema))
							nCount++;
					}
					return(nCount);
				}
			}

			internal clsColuna this[int index]
			{
				get
				{
					if (m_arlColunas.Count > index)
						return((clsColuna)m_arlColunas[index]);
					else
						return(null);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas Idiomas
			{
				get
				{
					if (m_typDatSetIdiomas != null)
						return(m_typDatSetIdiomas);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(null,null,null,null,null);
					return(m_typDatSetIdiomas);
				}
			}
		#endregion
		#region Constructors
			public clsManipuladorColunas(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,int nIdExportador,int nIdIdioma,string strLinguaEstrangeira)
			{
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_nIdExportador = nIdExportador;
				m_nIdIdioma = nIdIdioma;

				m_arlColunas = new System.Collections.ArrayList();
				m_strLinguaEstrangeira = strLinguaEstrangeira;
				ConstroiColunasDefaults();
			}

			public clsManipuladorColunas Clone()
			{
				clsManipuladorColunas clsRetorno = new clsManipuladorColunas(this.ConexaoBD,m_nIdExportador,m_nIdIdioma,m_strLinguaEstrangeira);
				clsRetorno.m_arlColunas = this.m_arlColunas;
				return(clsRetorno);
   			}
		#endregion

		#region Construcao das Colunas
			private void ConstroiColunasDefaults()
			{
				clsColuna cls_col_Coluna;

				//IdOrdem
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_IDORDEM,-1,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,true,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// idProduto
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_IDPRODUTO,-1,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,true,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Ordem Lancamento
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_ORDEM_LANCAMENTO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,true,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// codigoProduto
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_CÓDIGO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Descricao
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Descricao Lingua Estrangeira
				cls_col_Coluna = new clsColuna(m_strLinguaEstrangeira,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Preco Unitario
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_PRECO_UNITARIO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.direita,false,false,true,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Unidade
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Quantidade
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_QUANTIDADE,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.direita,false,false,true,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Detalhar
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_DETALHAR,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.BoolColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Ncm
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_NCM,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Naladi
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_NALADI,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Ncm Denominacao
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_NCM_DENOMINACAO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Naladi Denominacao
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_NALADI_DENOMINACAO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				// Grupo
				cls_col_Coluna = new clsColuna(mdlProdutosLancamento.clsLancamentoProdutos.TEXTO_COLUNA_GRUPO,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);

				InsereColunasPropriedadesDinamicas();
			}

			private void InsereColunasPropriedadesDinamicas()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedadesProdutos = m_cls_dba_ConnectionDB.GetTbPropriedadesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				for(int i = 0;i < typDatSetPropriedadesProdutos.tbPropriedadesProdutos.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedadesProdutos.tbPropriedadesProdutos[i];
					if ((dtrwPropriedade.nIdIdioma == (int)mdlConstantes.Idioma.Portugues) || (dtrwPropriedade.nIdIdioma == m_nIdIdioma))
						InsereColunaPropriedadeDinamica(GetPropriedadeDescricaoColuna(dtrwPropriedade.nIdIdioma,dtrwPropriedade.mstrDescricao));
				}
			}

			private void InsereColunaPropriedadeDinamica(string strColuna)
			{
				clsColuna cls_col_Coluna = new clsColuna(strColuna,0,0,mdlProdutosLancamento.AlinhamentoHorizontal.esquerda,false,false,false,mdlProdutosLancamento.clsManipuladorColunas.DataGridColumnStyle.TextColumn);
				m_arlColunas.Add(cls_col_Coluna);
			}
		#endregion
		#region Remove Lacunas
			public void RemoveLacunas()
			{
				int nPosicaoSearch = 1;
				while (nPosicaoSearch != (this.CountValidas + 1))
				{
					int nPosicaoMenor = nPosicaoSearch + 5;
					int nIndexMenor = -1;
					for(int i = 0; i < this.CountValidas;i++)
					{
						clsColuna objColuna = this.GetColunaValida(i);
						if (nPosicaoSearch == objColuna.Posicao)
						{
							nPosicaoSearch++;
							nPosicaoMenor = nPosicaoSearch + 5;
							nIndexMenor = -1;
							break;
						}else{
							if ((nPosicaoSearch < objColuna.Posicao) && (objColuna.Posicao < nPosicaoMenor))
							{
								nIndexMenor = i;
								nPosicaoMenor = objColuna.Posicao;
							}
						}
					}
					if (nIndexMenor != -1)
					{
						SetPosicao(this.GetColunaValida(nIndexMenor).Nome,nPosicaoSearch);
						nPosicaoSearch++;
					}
				}
			}
		#endregion

		#region Carregamento de Colunas
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas GetFaturasCotacoesColunas(string strIdCotacao)
			{
				if (m_typDatSetFaturasCotacoesColunas != null)
					return(m_typDatSetFaturasCotacoesColunas);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCotacao);

				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlOrdenacaoCampo.Add("nIdColuna");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetFaturasCotacoesColunas = m_cls_dba_ConnectionDB.GetTbFaturasCotacoesColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				return(m_typDatSetFaturasCotacoesColunas);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas GetFaturasComerciaisColunas(string strIdPe)
			{
				if (m_typDatSetFaturasComerciaisColunas != null)
					return(m_typDatSetFaturasComerciaisColunas);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

                arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdPe);

				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlOrdenacaoCampo.Add("nIdColuna");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetFaturasComerciaisColunas = m_cls_dba_ConnectionDB.GetTbFaturasComerciaisColunas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
				return(m_typDatSetFaturasComerciaisColunas);
			}

			private void SetTodasColunasDisponiveis()
			{
				for (int i = 0;i < this.Count;i++)
					if (i == (this.Count - 1))
						this.SetPosicao(this[i].Nome,0,true);
					else
						this.SetPosicao(this[i].Nome,0,false);

			}

			private void CarregaColunasDefault()
			{
				SetTodasColunasDisponiveis();

				this.SetPosicao(clsLancamentoProdutos.TEXTO_COLUNA_CÓDIGO,1,true);
				this.SetTamanho(clsLancamentoProdutos.TEXTO_COLUNA_CÓDIGO,60);

				this.SetPosicao(clsLancamentoProdutos.TEXTO_COLUNA_QUANTIDADE,2,true);
				this.SetTamanho(clsLancamentoProdutos.TEXTO_COLUNA_QUANTIDADE,60);

				this.SetPosicao(clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO,3,true);
				this.SetTamanho(clsLancamentoProdutos.TEXTO_COLUNA_DESCRICAO,250);

				this.SetPosicao(clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE,4,true);
				this.SetTamanho(clsLancamentoProdutos.TEXTO_COLUNA_UNIDADE,50);

				this.SetPosicao(clsLancamentoProdutos.TEXTO_COLUNA_PRECO_UNITARIO,5,true);
				this.SetTamanho(clsLancamentoProdutos.TEXTO_COLUNA_PRECO_UNITARIO,60);

				this.SetPosicao(m_strLinguaEstrangeira,6,true);
				this.SetTamanho(m_strLinguaEstrangeira,150);
			}

			private void CarregaColunasExportador()
			{
				SetTodasColunasDisponiveis();
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas typDatSetColunas = this.ExportadoresColunas;
				if (typDatSetColunas.tbExportadoresColunas.Rows.Count == 0)
				{
					CarregaColunasDefault();
					SalvaColunasExportador();
				}
				else
				{
					for(int i = 0; i < typDatSetColunas.tbExportadoresColunas.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas.tbExportadoresColunasRow dtrwColuna = typDatSetColunas.tbExportadoresColunas[i];
						this.SetPosicao(dtrwColuna.strNome,dtrwColuna.nIdColuna,true);
						this.SetTamanho(dtrwColuna.strNome,dtrwColuna.nTamanho);
					}
					this.RemoveLacunas();
				}
			}

			public void CarregaColunasFaturaCotacao(string strIdCotacao)
			{
				SetTodasColunasDisponiveis();
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetColunas = this.GetFaturasCotacoesColunas(strIdCotacao);
				if (typDatSetColunas.tbFaturasCotacoesColunas.Rows.Count == 0)
				{
					CarregaColunasExportador();
					SalvaColunasFaturaCotacao(strIdCotacao);
				}
				else
				{
					for(int i = 0; i < typDatSetColunas.tbFaturasCotacoesColunas.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwColuna = typDatSetColunas.tbFaturasCotacoesColunas[i];
						this.SetPosicao(dtrwColuna.strNome,dtrwColuna.nIdColuna,true);
						this.SetTamanho(dtrwColuna.strNome,dtrwColuna.nTamanho);
					}
					this.RemoveLacunas();
				}
			}

			public void CarregaColunasFaturaComercial(string strIdPe)
			{
				SetTodasColunasDisponiveis();
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas typDatSetColunas = this.GetFaturasComerciaisColunas(strIdPe);
				if (typDatSetColunas.tbFaturasComerciaisColunas.Rows.Count == 0)
				{
					CarregaColunasExportador();
					SalvaColunasFaturaComercial(strIdPe);
				}else{
					for(int i = 0; i < typDatSetColunas.tbFaturasComerciaisColunas.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas.tbFaturasComerciaisColunasRow dtrwColuna = typDatSetColunas.tbFaturasComerciaisColunas[i];
						this.SetPosicao(dtrwColuna.strNome,dtrwColuna.nIdColuna,true);
						this.SetTamanho(dtrwColuna.strNome,dtrwColuna.nTamanho);
					}
					this.RemoveLacunas();
				}
			}
		#endregion
		#region Salvamento de Colunas
			private void SalvaColunasExportador()
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas typDatSetColunas = this.ExportadoresColunas;
				//Deleting
				for(int i = typDatSetColunas.tbExportadoresColunas.Rows.Count - 1; i >=0; i--)
					typDatSetColunas.tbExportadoresColunas[i].Delete();
				for(int i = 0; i < this.Count;i++)
				{
					clsColuna coluna = this[i];
					if (coluna.Posicao <= 0)
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresColunas.tbExportadoresColunasRow dtrwColuna = typDatSetColunas.tbExportadoresColunas.NewtbExportadoresColunasRow();
					dtrwColuna.nIdExportador = m_nIdExportador;
					dtrwColuna.nIdColuna = coluna.Posicao;
					dtrwColuna.strNome = coluna.Nome;
					dtrwColuna.nTamanho = coluna.Tamanho;
					typDatSetColunas.tbExportadoresColunas.AddtbExportadoresColunasRow(dtrwColuna);
				}
				m_cls_dba_ConnectionDB.SetTbExportadoresColunas(typDatSetColunas);
				m_typDatSetExportadoresColunas = null;
			}

			public void SalvaColunasFaturaCotacao(string strIdCotacao)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas typDatSetColunas = this.GetFaturasCotacoesColunas(strIdCotacao);
				//Deleting
				for(int i = typDatSetColunas.tbFaturasCotacoesColunas.Rows.Count - 1; i >=0; i--)
					typDatSetColunas.tbFaturasCotacoesColunas[i].Delete();
				for(int i = 0; i < this.Count;i++)
				{
					clsColuna coluna = this[i];
					if (coluna.Posicao <= 0)
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoesColunas.tbFaturasCotacoesColunasRow dtrwColuna = typDatSetColunas.tbFaturasCotacoesColunas.NewtbFaturasCotacoesColunasRow();
					dtrwColuna.nIdExportador = m_nIdExportador;
					dtrwColuna.strIdCotacao = strIdCotacao;
					dtrwColuna.nIdColuna = coluna.Posicao;
					dtrwColuna.strNome = coluna.Nome;
					dtrwColuna.nTamanho = coluna.Tamanho;
					typDatSetColunas.tbFaturasCotacoesColunas.AddtbFaturasCotacoesColunasRow(dtrwColuna);
				}
				m_cls_dba_ConnectionDB.SetTbFaturasCotacoesColunas(typDatSetColunas);
				m_typDatSetFaturasCotacoesColunas = null;
			}

			public void SalvaColunasFaturaComercial(string strIdPe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas typDatSetColunas = this.GetFaturasComerciaisColunas(strIdPe);
				//Deleting
				for(int i = typDatSetColunas.tbFaturasComerciaisColunas.Rows.Count - 1; i >=0; i--)
					typDatSetColunas.tbFaturasComerciaisColunas[i].Delete();
				for(int i = 0; i < this.Count;i++)
				{
					clsColuna coluna = this[i];
					if (coluna.Posicao <= 0)
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciaisColunas.tbFaturasComerciaisColunasRow dtrwColuna = typDatSetColunas.tbFaturasComerciaisColunas.NewtbFaturasComerciaisColunasRow();
					dtrwColuna.nIdExportador = m_nIdExportador;
					dtrwColuna.strIdPe = strIdPe;
					dtrwColuna.nIdColuna = coluna.Posicao;
					dtrwColuna.strNome = coluna.Nome;
					dtrwColuna.nTamanho = coluna.Tamanho;
					typDatSetColunas.tbFaturasComerciaisColunas.AddtbFaturasComerciaisColunasRow(dtrwColuna);
				}
				m_cls_dba_ConnectionDB.SetTbFaturasComerciaisColunas(typDatSetColunas);
				m_typDatSetFaturasComerciaisColunas = null;
			}
		#endregion

		#region Set
			public void SetPosicao(string strNomeColuna,int nPosicaoNova)
			{
				SetPosicao(strNomeColuna,nPosicaoNova,false);
			}

			public void SetPosicao(string strNomeColuna,int nPosicaoNova,bool bReajustaPosicoes)
			{
				clsColuna objColunaPosicao = null;
				int nPosicaoAnterior = 0;
				for(int i = 0; i < m_arlColunas.Count; i++)
				{
					objColunaPosicao = (clsColuna)m_arlColunas[i];
					if (objColunaPosicao.Nome == strNomeColuna)
					{
						nPosicaoAnterior = objColunaPosicao.Posicao;
						objColunaPosicao.Posicao = nPosicaoNova;
						if ((nPosicaoAnterior == 0) && (objColunaPosicao.Tamanho == 0))
							objColunaPosicao.Tamanho = 40;
						break;
					}else{
						objColunaPosicao = null;
					}
				}
				if ((bReajustaPosicoes) && (objColunaPosicao != null))
				{
					if (nPosicaoAnterior < nPosicaoNova)
					{
						if (nPosicaoAnterior == 0)
						{
							for (int i=0;i < this.Count;i++)
							{
								clsColuna objColuna = this[i];
								if ((objColuna.Inutilizada) || (objColuna.Sistema))
									continue;
								if ((objColuna.Posicao >= nPosicaoNova) && (objColuna.Nome != objColunaPosicao.Nome))
									objColuna.Posicao = objColuna.Posicao + 1;
							}
						}
						else
						{
							for (int i=0;i < this.Count;i++)
							{
								clsColuna objColuna = this[i];
								if (objColuna.Sistema) 
									continue;
								if ((nPosicaoAnterior < objColuna.Posicao) && (objColuna.Posicao <= nPosicaoNova) && (objColuna.Nome != objColunaPosicao.Nome))
									objColuna.Posicao = objColuna.Posicao - 1;
							}
						}
					}else if(nPosicaoAnterior > nPosicaoNova){
						if (nPosicaoNova == 0)
						{
							for (int i=0;i < this.Count;i++)
							{
								clsColuna objColuna = this[i];
								if ((objColuna.Inutilizada) || (objColuna.Sistema))
									continue;
								if ((objColuna.Posicao >= nPosicaoAnterior))
									objColuna.Posicao = objColuna.Posicao - 1;
							}
						}
						else
						{
							for (int i=0;i < this.Count;i++)
							{
								clsColuna objColuna = this[i];
								if (objColuna.Sistema) 
									continue;
								if ((nPosicaoAnterior > objColuna.Posicao) && (objColuna.Posicao >= nPosicaoNova) && (objColuna.Nome != objColunaPosicao.Nome))
									objColuna.Posicao = objColuna.Posicao + 1;
							}
						}
					}
 			    }
			}

			public void SetTamanho(string strNomeColuna,int nTamanhoNovo)
			{
				clsColuna cls_col_Coluna;
				for(int nCont = 0; nCont < m_arlColunas.Count; nCont++)
				{
					cls_col_Coluna = (clsColuna)m_arlColunas[nCont];
					if (cls_col_Coluna.Nome == strNomeColuna)
					{
						if ((cls_col_Coluna.Posicao > 0) && (nTamanhoNovo == 0))
							nTamanhoNovo = 40;
						cls_col_Coluna.Tamanho = nTamanhoNovo;
						break;
   					}
				}
			}
		#endregion 
		#region Get
			public string GetNome(int nPosicaoColuna)
			{
				clsColuna cls_col_Coluna = (clsColuna)m_arlColunas[nPosicaoColuna];
				return(cls_col_Coluna.Nome);
			}

			public int GetPosicao(string strNomeColuna)
			{
				int nRetorno = -1;
				clsColuna cls_col_Coluna;
				for(int nCont = 0; nCont < m_arlColunas.Count;nCont++)
				{
					cls_col_Coluna = (clsColuna)m_arlColunas[nCont];
					if (cls_col_Coluna.Nome == strNomeColuna)
					{
						nRetorno = cls_col_Coluna.Posicao;
						break;
					}
				}
				return(nRetorno);
			}

			public int GetTamanho(int nPosicaoColuna)
			{
				clsColuna cls_col_Coluna = (clsColuna)m_arlColunas[nPosicaoColuna];
				return(cls_col_Coluna.Tamanho);
			}

			public int GetTamanho(string strNomeColuna)
			{
				int nRetorno = -1;
				clsColuna cls_col_Coluna;
				for(int nCont = 0; nCont < m_arlColunas.Count;nCont++)
				{
					cls_col_Coluna = (clsColuna)m_arlColunas[nCont];
					if (cls_col_Coluna.Nome == strNomeColuna)
					{
						nRetorno = cls_col_Coluna.Tamanho;
						break;
					}
				}
				return(nRetorno);
			}

			public bool GetReadOnly(int nPosicaoColuna)
			{
				clsColuna cls_col_Coluna = (clsColuna)m_arlColunas[nPosicaoColuna];
				return(cls_col_Coluna.ReadOnly);
			}

			public bool GetReadOnly(string strNomeColuna)
			{
				bool bRetorno  = false;
				clsColuna cls_col_Coluna;
				for(int nCont = 0; nCont < m_arlColunas.Count;nCont++)
				{
					cls_col_Coluna = (clsColuna)m_arlColunas[nCont];
					if (cls_col_Coluna.Nome == strNomeColuna)
					{
                        bRetorno = cls_col_Coluna.ReadOnly;
						break;
					}
   				}
				return(bRetorno);
			}
		#endregion

		#region Remove
			internal void RemoveColuna(string Coluna)
			{
				for(int i = 0; i < this.Count;i++)
				{
					clsColuna objColuna = this[i];
					if (objColuna.Nome == Coluna)
					{
						this.SetPosicao(Coluna,0);
						break;
					}
				}
			}
		#endregion

		#region Sistema
			internal clsColuna GetColunaSistema(int index)
			{
				int nCount = -1;
				for(int i = 0;i < this.Count;i++)
				{
					clsColuna objColuna = this[i];
					if (objColuna.Sistema)
						nCount++;
					if (nCount == index)
						return(objColuna);
				}
				return(null);
			}
		#endregion
		#region Validas
			internal clsColuna GetColunaValida(int index)
			{
				int nCount = -1;
				for(int i = 0;i < this.Count;i++)
				{
					clsColuna objColuna = this[i];
					if ((!objColuna.Inutilizada) && (!objColuna.Sistema))
						nCount++;
					if (nCount == index)
						return(objColuna);
				}
				return(null);
			}

			internal clsColuna GetColunaValidaIndex(int index)
			{
				for(int i = 0;i < this.Count;i++)
				{
					clsColuna objColuna = this[i];
					if ((!objColuna.Inutilizada) && (!objColuna.Sistema) && (objColuna.Posicao == index))
						return(objColuna);
				}
				return(null);
			}
		#endregion
		#region Invalidas
			internal clsColuna GetColunaInvalida(int index)
			{
				int nCount = -1;
				for(int i = 0;i < this.Count;i++)
				{
					clsColuna objColuna = this[i];
					if ((objColuna.Inutilizada) && (!objColuna.Sistema))
						nCount++;
					if (nCount == index)
						return(objColuna);
				}
				return(null);
			}
		#endregion

		#region ColumnHeader
		internal System.Windows.Forms.ColumnHeader clhdColuna(clsColuna cls_col_Coluna)
		{
			System.Windows.Forms.ColumnHeader clhdRetorno = null;
			if (cls_col_Coluna  != null) 
			{
				clhdRetorno = new System.Windows.Forms.ColumnHeader();
				clhdRetorno.Text = cls_col_Coluna.Nome;
				clhdRetorno.Width = cls_col_Coluna.Tamanho;
				switch(cls_col_Coluna.Alinhamento)
				{
					case mdlProdutosLancamento.AlinhamentoHorizontal.esquerda:
						clhdRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
						break;
					case mdlProdutosLancamento.AlinhamentoHorizontal.direita:
						clhdRetorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
						break;
				}
			}
			return(clhdRetorno);
		}
        
        #endregion
		#region DataColumn
			internal System.Data.DataColumn dtclColuna(clsColuna cls_col_Coluna)
			{
                System.Data.DataColumn dtclRetorno = null;
				if (cls_col_Coluna != null)
				{
					dtclRetorno = new System.Data.DataColumn();
					dtclRetorno.ColumnName = cls_col_Coluna.Nome;
					dtclRetorno.ReadOnly = cls_col_Coluna.ReadOnly;

					// Column Style
					switch(cls_col_Coluna.ColumnStyle)
					{
						case clsManipuladorColunas.DataGridColumnStyle.TextColumn:
							dtclRetorno.DataType = System.Type.GetType("System.String");
							dtclRetorno.DefaultValue = "";
							break;
						case clsManipuladorColunas.DataGridColumnStyle.BoolColumn:
							dtclRetorno.DataType = System.Type.GetType("System.Boolean");
							dtclRetorno.DefaultValue = false;
							break;
					}
				}
				return(dtclRetorno);
			}
		#endregion
		#region DataGridColumnStyle
			internal System.Windows.Forms.DataGridColumnStyle dtgdcsColuna(clsColuna cls_col_Coluna)
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsRetorno = null;

				// Column Style
				if (cls_col_Coluna != null)
				{
					switch(cls_col_Coluna.ColumnStyle)
					{
						case clsManipuladorColunas.DataGridColumnStyle.TextColumn:
							dtgdcsRetorno = new System.Windows.Forms.DataGridTextBoxColumn();
						switch (cls_col_Coluna.Alinhamento)
						{
							case mdlProdutosLancamento.AlinhamentoHorizontal.esquerda:
								dtgdcsRetorno.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
								((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsRetorno).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
								break;
							case mdlProdutosLancamento.AlinhamentoHorizontal.direita:
								dtgdcsRetorno.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
								((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsRetorno).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
								if (cls_col_Coluna.IsNumeric)
								{
									//									System.Globalization.CultureInfo ciBrasil = new System.Globalization.CultureInfo("pt-BR");
									//									//((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsRetorno).FormatInfo = ciBrasil;
									//									((System.Windows.Forms.DataGridTextBoxColumn)dtgdcsRetorno).Format = "{0:#,##0.00}";
								}
								break;
						}
							break;
						case clsManipuladorColunas.DataGridColumnStyle.BoolColumn:
							dtgdcsRetorno = new System.Windows.Forms.DataGridBoolColumn();
							((System.Windows.Forms.DataGridBoolColumn)dtgdcsRetorno).AllowNull = false;
							((System.Windows.Forms.DataGridBoolColumn)dtgdcsRetorno).TrueValue = true;
							((System.Windows.Forms.DataGridBoolColumn)dtgdcsRetorno).FalseValue = false;
							break;
					}
					dtgdcsRetorno.HeaderText = cls_col_Coluna.Nome;
					dtgdcsRetorno.MappingName = cls_col_Coluna.Nome;
					dtgdcsRetorno.NullText = "";
					dtgdcsRetorno.ReadOnly = cls_col_Coluna.ReadOnly;
					dtgdcsRetorno.Width = cls_col_Coluna.Tamanho;
					if (cls_col_Coluna.Inutilizada || cls_col_Coluna.Sistema)
						dtgdcsRetorno.Width = 0;
				}
				return(dtgdcsRetorno);
			}
		#endregion

		#region Idioma
			private string GetPropriedadeDescricaoColuna(int nIdIdioma,string strPropriedade)
			{
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = this.Idiomas.tbIdiomas.FindByidIdioma(nIdIdioma);
				if (dtrwIdioma != null)
					return(dtrwIdioma.mstrIdioma +" : " + strPropriedade);
				return("");
			}
		#endregion

	}
}
