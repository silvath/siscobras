using System;

namespace mdlProdutosVinculacao
{
	/// <summary>
	/// Summary description for clsProdutosVinculacao.
	/// </summary>
	public abstract class clsProdutosVinculacao
	{
		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		protected const int NCM = 1;
		protected const int NALADI = 2;

		public bool m_bModificado = false;
		protected int m_nIdExportador = -1;
		protected int m_nClassificaoTarifaria = -1;
		protected int m_nIdIdioma = 1;

		protected string m_strClassificacaoFinal = "";
		protected System.Collections.ArrayList m_arlClassificacaoProdutos = null;

		protected System.Collections.ArrayList m_arlIdProdutosFatura = null;
		private System.Collections.ArrayList m_arlProdutosSemClassificacao = null;
		protected System.Collections.ArrayList m_arlIdProdutosParents = null;

		private Frames.frmFProdutosVinculacao m_formFProdutosVinculacao = null;

		private mdlClassificacao.clsNcm m_clsClassificacaoNcm = null;
		private mdlClassificacao.clsNaladi m_clsClassificacaoNaladi = null;
		private mdlProdutosGeral.clsProdutos m_clsProdutos = null;

		private System.Windows.Forms.ImageList m_ilBandeiras = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosParents m_typDatSetTbProdutosParents = null;
		#endregion

		#region Construtores & Destrutores
		public clsProdutosVinculacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int classificaoTarifaria, int Idioma, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_nClassificaoTarifaria = classificaoTarifaria;
				m_nIdIdioma = Idioma;
				m_ilBandeiras = ilBandeiras;
				m_arlIdProdutosFatura = new System.Collections.ArrayList();
				m_arlProdutosSemClassificacao = new System.Collections.ArrayList();
				m_arlClassificacaoProdutos = new System.Collections.ArrayList();
				m_arlIdProdutosParents = new System.Collections.ArrayList();
				carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public clsProdutosVinculacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int classificaoTarifaria, int Idioma, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_nClassificaoTarifaria = classificaoTarifaria;
				m_nIdIdioma = Idioma;
				m_ilBandeiras = ilBandeiras;
				m_arlIdProdutosFatura = new System.Collections.ArrayList();
				m_arlProdutosSemClassificacao = new System.Collections.ArrayList();
				m_arlClassificacaoProdutos = new System.Collections.ArrayList();
				m_arlIdProdutosParents = new System.Collections.ArrayList();
				m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
				carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public clsProdutosVinculacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_ilBandeiras = ilBandeiras;
				m_arlIdProdutosFatura = new System.Collections.ArrayList();
				m_arlProdutosSemClassificacao = new System.Collections.ArrayList();
				m_arlClassificacaoProdutos = new System.Collections.ArrayList();
				m_arlIdProdutosParents = new System.Collections.ArrayList();
				carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region InitializeEventsFormProdutosVinculacao
		private void InitializeEventsFormProdutosVinculacao()
		{
			// Carrega Dados BD
			m_formFProdutosVinculacao.eCallCarregaDadosBD += new Frames.frmFProdutosVinculacao.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFProdutosVinculacao.eCallCarregaDadosInterface += new Frames.frmFProdutosVinculacao.delCallCarregaDadosInterface(carregaDadosInterface);

			// Refresh Interface
			m_formFProdutosVinculacao.eCallRefreshInterface += new Frames.frmFProdutosVinculacao.delCallRefreshInterface(refreshDadosInterface);

			// Seta NCM
			m_formFProdutosVinculacao.eCallSetaNcm += new Frames.frmFProdutosVinculacao.delCallSetaNcm(setaNcm);

			// Seta NALADI
			m_formFProdutosVinculacao.eCallSetaNaladi += new Frames.frmFProdutosVinculacao.delCallSetaNaladi(setaNaladi);

			// Produtos Geral
			m_formFProdutosVinculacao.eCallProdutosGeral += new Frames.frmFProdutosVinculacao.delCallProdutosGeral(showDialogProdutos);

			// Salva Dados BD
			m_formFProdutosVinculacao.eCallSalvaDadosBD += new Frames.frmFProdutosVinculacao.delCallSalvaDadosBD(SalvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFProdutosVinculacao = new Frames.frmFProdutosVinculacao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormProdutosVinculacao();
				m_formFProdutosVinculacao.ShowDialog();
				m_formFProdutosVinculacao = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlOrdenacaoCampo.Add("mstrDescricao");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				if (m_typDatSetTbProdutos == null)
					m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, /*arlOrdenacaoCampo, arlOrdenacaoTipo*/null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("nIdExportador");
				m_typDatSetTbProdutosParents = m_cls_dba_ConnectionDB.GetTbProdutosParents(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, /*arlOrdenacaoCampo, arlOrdenacaoTipo*/null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("nIdExportador");
				if (m_typDatSetTbProdutosNcm == null)
					m_typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				if (m_typDatSetTbProdutosNaladi == null)
					m_typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
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
				carregaDadosBDEspecificos();
				carregaDadosClassificacao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecificos();
		protected abstract void carregaDadosIdClassificacaoIdIdioma();
		protected void carregaDadosClassificacao()
		{
			try
			{
				System.Data.DataRow[] dtRwArrayParents = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
				{
					dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_arlIdProdutosFatura[nCount]);
					dtRwArrayParents = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoChild = " + ((int)m_arlIdProdutosFatura[nCount]).ToString());
					if ((dtrwTbProdutos != null) && (dtRwArrayParents != null) && (dtRwArrayParents.Length == 0))
					{
						switch (m_nClassificaoTarifaria)
						{
							#region NCM
							case NCM:
								if (!dtrwTbProdutos.IsstrNcmNull())
								{
									if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() != "")
									{
										if (!m_arlClassificacaoProdutos.Contains(dtrwTbProdutos.strNcm))
											m_arlClassificacaoProdutos.Add(dtrwTbProdutos.strNcm);
									}
								}
								break;
							#endregion
							#region NALADI
							case NALADI:
								if (!dtrwTbProdutos.IsstrNaladiNull())
								{
									if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() != "")
									{
										if (!m_arlClassificacaoProdutos.Contains(dtrwTbProdutos.strNaladi))
											m_arlClassificacaoProdutos.Add(dtrwTbProdutos.strNaladi);
									}
								}
								break;
							#endregion
							#region NCM & NALADI
							case 3:
								if (!dtrwTbProdutos.IsstrNcmNull())
								{
									if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() != "")
									{
										if (!m_arlClassificacaoProdutos.Contains(dtrwTbProdutos.strNcm))
											m_arlClassificacaoProdutos.Add(dtrwTbProdutos.strNcm);
									}
								}
								if (!dtrwTbProdutos.IsstrNaladiNull())
								{
									if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() != "")
									{
										if (!m_arlClassificacaoProdutos.Contains(dtrwTbProdutos.strNaladi))
											m_arlClassificacaoProdutos.Add(dtrwTbProdutos.strNaladi);
									}
								}
								break;
							#endregion
						}
					}
					dtRwArrayParents = null;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref System.Windows.Forms.Form formProdutosVinculacao, ref mdlComponentesGraficos.TreeView treeVProdutos, bool bMostrarSemClassificacao)
		{
			try
			{
				carregaDadosInterfaceEspecificos(ref formProdutosVinculacao);
				refreshDadosInterface(ref treeVProdutos, bMostrarSemClassificacao);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void refreshDadosInterface(ref mdlComponentesGraficos.TreeView treeVProdutos, bool bMostrarSemClassificacao)
		{
			try
			{
				m_arlClassificacaoProdutos.Clear();
				treeVProdutos.Nodes.Clear();
				System.Windows.Forms.TreeNode NodoProduto;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				carregaArrayListProdutosSemClassificacao(bMostrarSemClassificacao);
				if (m_arlProdutosSemClassificacao.Count > 0)
				{
					for (int nCount = 0; nCount < m_arlProdutosSemClassificacao.Count; nCount++)
					{
						dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_arlProdutosSemClassificacao[nCount]);
						if (dtrwTbProdutos != null)
						{
							NodoProduto = treeVProdutos.Nodes.Add(dtrwTbProdutos.mstrDescricao);
							NodoProduto.Tag = dtrwTbProdutos.idProduto;
							switch (m_nClassificaoTarifaria)
							{
								#region NCM
								case NCM:
									if (!dtrwTbProdutos.IsstrNcmNull())
									{
										if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() != "")
										{
											NodoProduto.Nodes.Add("NCM: " + dtrwTbProdutos.strNcm);
										}
										else
										{
											NodoProduto.Nodes.Add("NCM: Indefinida");
										}
									}
									else
									{
										NodoProduto.Nodes.Add("NCM: Indefinida");
									}
								break;
								#endregion
								#region NALADI
								case NALADI:
									if (!dtrwTbProdutos.IsstrNaladiNull())
									{
										if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() != "")
										{
											NodoProduto.Nodes.Add("NALADI: " + dtrwTbProdutos.strNaladi);
										}
										else
										{
											NodoProduto.Nodes.Add("NALADI: Indefinida");
										}
									}
									else
									{
										NodoProduto.Nodes.Add("NALADI: Indefinida");
									}
								break;
								#endregion
								#region NCM & NALADI
								case 3:
									if (!dtrwTbProdutos.IsstrNcmNull())
									{
										if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() != "")
										{
											NodoProduto.Nodes.Add("NCM: " + dtrwTbProdutos.strNcm);
										}
										else
										{
											NodoProduto.Nodes.Add("NCM: Indefinida");
										}
									}
									else
									{
										NodoProduto.Nodes.Add("NCM: Indefinida");
									}
									if (!dtrwTbProdutos.IsstrNaladiNull())
									{
										if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() != "")
										{
											NodoProduto.Nodes.Add("NALADI: " + dtrwTbProdutos.strNaladi);
											if (!m_arlClassificacaoProdutos.Contains(dtrwTbProdutos.strNaladi))
												m_arlClassificacaoProdutos.Add(dtrwTbProdutos.strNaladi);
										}
										else
										{
											NodoProduto.Nodes.Add("NALADI: Indefinida");
										}
									}
									else
									{
										NodoProduto.Nodes.Add("NALADI: Indefinida");
									}
								break;
								#endregion
							}
						}
					}
				}
				carregaDadosClassificacao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaArrayListProdutosSemClassificacao(bool bMostrarSemClassificacao)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				m_arlProdutosSemClassificacao = new System.Collections.ArrayList();
				if (bMostrarSemClassificacao)
				{
					switch (m_nClassificaoTarifaria)
					{
						#region NCM
						case NCM:
							for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
							{
								dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador, (int)m_arlIdProdutosFatura[nCount]);
								if ((dtrwTbProdutos != null) && (((int)m_arlIdProdutosParents[nCount]) == 0))
								{
									if (!dtrwTbProdutos.IsstrNcmNull())
									{
										if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() == "")
										{
											m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
										}
									}
									else
									{
										m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
									}
								}
							}
						break;
						#endregion
						#region NALADI
						case NALADI:
							for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
							{
								dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador, (int)m_arlIdProdutosFatura[nCount]);
								if ((dtrwTbProdutos != null) && (((int)m_arlIdProdutosParents[nCount]) == 0))
								{
									if (!dtrwTbProdutos.IsstrNaladiNull())
									{
										if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() == "")
										{
											m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
										}
									}
									else
									{
										m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
									}
								}
							}
						break;
						#endregion
						#region NCM & NALADI
						case 3:
							for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
							{
								dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador, (int)m_arlIdProdutosFatura[nCount]);
								if ((dtrwTbProdutos != null)  && (((int)m_arlIdProdutosParents[nCount]) == 0))
								{
									if (!dtrwTbProdutos.IsstrNcmNull())
									{
										if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() == "")
										{
											m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
										}
									}
									else if (!dtrwTbProdutos.IsstrNaladiNull())
									{
										if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() == "")
										{
											m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
										}
									}
									else if (dtrwTbProdutos.IsstrNcmNull())
									{
										m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
									}
									else
									{
										m_arlProdutosSemClassificacao.Add(m_arlIdProdutosFatura[nCount]);
									}
								}
							}
						break;
						#endregion
					}
				}
				else
				{
					for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
					{
						if (((int)m_arlIdProdutosParents[nCount]) == 0)
						{
							m_arlProdutosSemClassificacao.Add((int)m_arlIdProdutosFatura[nCount]);
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.Form formProdutosVinculacao);
		#endregion
		#endregion
		#region Salvamento de Dados
		private void SalvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				if (m_typDatSetTbProdutos != null)
					m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetTbProdutos);
				if (m_typDatSetTbProdutosNcm != null)
					m_cls_dba_ConnectionDB.SetTbProdutosNcm(m_typDatSetTbProdutosNcm);
				if (m_typDatSetTbProdutosNaladi != null)
					m_cls_dba_ConnectionDB.SetTbProdutosNaladi(m_typDatSetTbProdutosNaladi);
				salvaDadosBDEspecificos();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecificos();
		#endregion

		#region Necessita Vincular
		public bool necessitaVincular()
		{
			bool bRetorno = false;
			try
			{
				System.Data.DataRow[] dtRwArrayParents = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos;
				switch (m_nClassificaoTarifaria)
				{
					#region NCM
					case NCM:
						for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
						{
							dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_arlIdProdutosFatura[nCount]);
							dtRwArrayParents = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoChild = " + ((int)m_arlIdProdutosFatura[nCount]).ToString());
							if ((dtrwTbProdutos != null) && (dtRwArrayParents != null) && (dtRwArrayParents.Length == 0) && (((int)m_arlIdProdutosParents[nCount]) == 0))
							{
								if (!dtrwTbProdutos.IsstrNcmNull())
								{
									if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() == "")
									{
										bRetorno = true;
										break;
									}
								}
								else
								{
									bRetorno = true;
									break;
								}
							}
							dtRwArrayParents = null;
						}
					break;
					#endregion
					#region NALADI
					case NALADI:
						for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
						{
							dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_arlIdProdutosFatura[nCount]);
							dtRwArrayParents = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoChild = " + ((int)m_arlIdProdutosFatura[nCount]).ToString());
							if ((dtrwTbProdutos != null) && (dtRwArrayParents != null) && (dtRwArrayParents.Length == 0) && (((int)m_arlIdProdutosParents[nCount]) == 0))
							{
								if (!dtrwTbProdutos.IsstrNaladiNull())
								{
									if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() == "")
									{
										bRetorno = true;
										break;
									}
								}
								else
								{
									bRetorno = true;
									break;
								}
							}
							dtRwArrayParents = null;
						}
					break;
					#endregion
					#region NCM & NALADI
					case 3:
						for (int nCount = 0; nCount < m_arlIdProdutosFatura.Count; nCount++)
						{
							dtrwTbProdutos = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,(int)m_arlIdProdutosFatura[nCount]);
							dtRwArrayParents = m_typDatSetTbProdutosParents.tbProdutosParents.Select("nIdProdutoChild = " + ((int)m_arlIdProdutosFatura[nCount]).ToString());
							if ((dtrwTbProdutos != null) && (dtRwArrayParents != null) && (dtRwArrayParents.Length == 0) && (((int)m_arlIdProdutosParents[nCount]) == 0))
							{
								if (!dtrwTbProdutos.IsstrNcmNull())
								{
									if (dtrwTbProdutos.strNcm.Replace("\0","").Trim() == "")
									{
										bRetorno = true;
										break;
									}
								}
								else
								{
									bRetorno = true;
									break;
								}
								if (!dtrwTbProdutos.IsstrNaladiNull())
								{
									if (dtrwTbProdutos.strNaladi.Replace("\0","").Trim() == "")
									{
										bRetorno = true;
										break;
									}
								}
								else
								{
									bRetorno = true;
									break;
								}
							}
							dtRwArrayParents = null;
						}
					break;
					#endregion
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (bRetorno);
		}
		#endregion

		#region Produtos
		protected void showDialogProdutos()
		{
			try
			{
				m_clsProdutos = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_nIdIdioma, ref m_ilBandeiras, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosNcm, ref m_typDatSetTbProdutosNaladi, true);
				m_clsProdutos.ShowDialogProdutos();
				if (m_clsProdutos.m_bDadosSalvos)
				{
					m_clsProdutos.retornaTypDatSets(out m_typDatSetTbProdutos, out m_typDatSetTbProdutosNcm, out m_typDatSetTbProdutosNaladi);
				}
				m_clsProdutos = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Seta Classificação Tarifária
		public void setaNcm(ref System.Windows.Forms.TreeNode tnProduto)
		{
			try
			{
				m_clsClassificacaoNcm = new mdlClassificacao.clsNcm(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, (int)tnProduto.Parent.Tag, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosNcm, true, ref m_ilBandeiras);
				m_clsClassificacaoNcm.ShowDialog();
				if (m_clsClassificacaoNcm.m_bModificado)
				{
					m_clsClassificacaoNcm.retornaTypDatSetsTbs(out m_typDatSetTbProdutos, out m_typDatSetTbProdutosNcm);
				}
				m_clsClassificacaoNaladi = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public void setaNaladi(ref System.Windows.Forms.TreeNode tnProduto)
		{
			try
			{
				m_clsClassificacaoNaladi = new mdlClassificacao.clsNaladi(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, (int)tnProduto.Parent.Tag, ref m_typDatSetTbProdutos, ref m_typDatSetTbProdutosNaladi, true, ref m_ilBandeiras);
				m_clsClassificacaoNaladi.ShowDialog();
				if (m_clsClassificacaoNaladi.m_bModificado)
				{
					m_clsClassificacaoNaladi.retornaTypDatSetsTbs(out m_typDatSetTbProdutos, out m_typDatSetTbProdutosNaladi);
				}
				m_clsClassificacaoNaladi = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region RetornValores
		protected void retornaValores(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos)
		{
			typDatSetTbProdutos = m_typDatSetTbProdutos;
		}
		public void retornaValores(out string strClassificacoes)
		{
			m_strClassificacaoFinal = "";
			for (int nCount = 0; nCount < m_arlClassificacaoProdutos.Count; nCount++)
			{
				if (nCount == (m_arlClassificacaoProdutos.Count - 1))
					m_strClassificacaoFinal += m_arlClassificacaoProdutos[nCount].ToString();
				else
					m_strClassificacaoFinal += m_arlClassificacaoProdutos[nCount].ToString() + ", ";
			}
			strClassificacoes = m_strClassificacaoFinal;
		}
		#endregion
	}
}
