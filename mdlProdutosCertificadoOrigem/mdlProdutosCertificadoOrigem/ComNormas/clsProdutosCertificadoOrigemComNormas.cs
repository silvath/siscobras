using System;

namespace mdlProdutosCertificadoOrigem.ComNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemComNormas.
	/// </summary>
	public abstract class clsProdutosCertificadoOrigemComNormas : clsProdutosCertificadoOrigem
	{
		#region Atributes
			protected System.Drawing.Color m_clrUsed = System.Drawing.Color.DarkBlue;

			// TypedDatSets
			protected mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas m_typDatSetTbCertificadosOrigemNormasResource = null;
			protected mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas m_typDatSetTbCertificadosOrigemNormasDataBase = null;
		#endregion
		#region Construtors and Destructors
			public clsProdutosCertificadoOrigemComNormas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, int nIdTipoCO, int nTipoClassificacao, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, nIdTipoCO, nTipoClassificacao, ref ilBandeiras)
			{
			}
		#endregion

		#region Carrega Dados	
			#region Banco Dados
				protected override void vCarregaDados()
				{
					base.vCarregaDados();

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdTipoCO");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdTipoCO);

					// Normas
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbCertificadosOrigemNormasResource = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbCertificadosOrigemNormasDataBase = m_cls_dba_ConnectionDB.GetTbCertificadosOrigemNormas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			#endregion
		#endregion
		#region Salva Dados
			#region Banco Dados
				protected override bool bSalvaDados()
				{
					bool bRetorno = false;
					if (bRetorno = base.bSalvaDados())
					{
						m_cls_dba_ConnectionDB.SetTbCertificadosOrigemNormas(m_typDatSetTbCertificadosOrigemNormasDataBase);
						bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					}
					return(bRetorno);
				}
			#endregion
		#endregion

		#region ShowDialog
			internal override void vInitializeEvents(ref Frames.frmFProdutosCertificado formFProdutosCertificado)
			{
				base.vInitializeEvents(ref formFProdutosCertificado);

				// Refresh Normas
				m_formFProdutosCertificado.eCallRefreshNormas += new Frames.frmFProdutosCertificado.delCallRefreshNormas(vRefreshNormas);

				// Norma Edita
				m_formFProdutosCertificado.eCallNormaEdita += new Frames.frmFProdutosCertificado.delCallNormaEdita(ShowDialogNorma);
			}
		#endregion
		#region ShowDialogNorma
			private bool ShowDialogNorma(int nIdNorma)
			{
				bool bRetorno = false;
				string strNormaOriginal = "";
				string strNormaDetalhes = "";
				string strNormaPersonalizada = "";

				bCarregaDadosNorma(nIdNorma,out strNormaOriginal,out strNormaDetalhes,out strNormaPersonalizada);
				Formularios.frmFNormasEditar formFNormasEditar = new mdlProdutosCertificadoOrigem.Formularios.frmFNormasEditar(m_strEnderecoExecutavel,strNormaOriginal,strNormaDetalhes,strNormaPersonalizada);
				formFNormasEditar.ShowDialog();
				if (bRetorno = formFNormasEditar.m_bModificado)
				{
					formFNormasEditar.vRetornaValores(out strNormaPersonalizada);
					// Salva Modificacao
					bSalvaDadoNorma(nIdNorma,strNormaPersonalizada);
				}
				return(bRetorno);
			}
		#endregion

		#region Refresh 
			protected void vRefreshNormas(ref mdlComponentesGraficos.ListView lvNormas)
			{
				try
				{
					System.Windows.Forms.ListViewItem lviNorma;
					lvNormas.Items.Clear();

					// Normas Ordenando | Filtrando 
					System.Collections.SortedList sortListNormas = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwNormaResource in m_typDatSetTbCertificadosOrigemNormasResource.tbCertificadosOrigemNormas.Rows)
					{
						string strDescricao = dtrwNormaResource.mstrNome;
						mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwNormaDataBase = m_typDatSetTbCertificadosOrigemNormasDataBase.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO,dtrwNormaResource.nIdNorma);
						if ((dtrwNormaDataBase != null) && (dtrwNormaDataBase.RowState != System.Data.DataRowState.Deleted) && (!dtrwNormaDataBase.IsmstrNomeNull()) && (dtrwNormaDataBase.mstrNome.Trim() != "") )
							strDescricao = dtrwNormaDataBase.mstrNome;
						if (dtrwNormaResource.IsdtInicioNull())
						{
							if (dtrwNormaResource.IsdtFimNull())
							{
								sortListNormas.Add(strDescricao,dtrwNormaResource.nIdNorma);
							}else{
								if (dtrwNormaResource.dtFim > m_dtEmissaoCertificado)
									sortListNormas.Add(strDescricao,dtrwNormaResource.nIdNorma);
							}
						}else{
							if (dtrwNormaResource.IsdtFimNull())
							{
								if (dtrwNormaResource.dtInicio < m_dtEmissaoCertificado)
									sortListNormas.Add(strDescricao,dtrwNormaResource.nIdNorma);
							}else{
								if ((dtrwNormaResource.dtInicio < m_dtEmissaoCertificado) && (dtrwNormaResource.dtFim > m_dtEmissaoCertificado))
									sortListNormas.Add(strDescricao,dtrwNormaResource.nIdNorma);
							}
						}
					}

					// Normas Inserindo 
					for(int i = 0; i < sortListNormas.Count;i++)
					{
						lviNorma = lvNormas.Items.Add(sortListNormas.GetKey(i).ToString());
						lviNorma.Tag = sortListNormas.GetByIndex(i);
						if (bNormaUtilizadaCertificado(Int32.Parse(sortListNormas.GetByIndex(i).ToString())))
							lviNorma.ForeColor = m_clrUsed;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

		#region Produtos
			protected override bool bInsereProdutos(ref System.Collections.ArrayList arlProdutos,int nIdNorma)
			{
				bool bRetorno = false;
				foreach(int nIdOrdemProduto in arlProdutos)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.NewtbProdutosCertificadoOrigemRow();
					dtrwProdutoCertificado.idExportador = m_nIdExportador;
					dtrwProdutoCertificado.idPE	= m_strIdPE;
					dtrwProdutoCertificado.idTipoCO = m_nIdTipoCO;
					dtrwProdutoCertificado.idOrdemProduto = nIdOrdemProduto;
					dtrwProdutoCertificado.idNorma = nIdNorma;
					dtrwProdutoCertificado.idOrdem = nNextOrdemProdutoCertificado();
					dtrwProdutoCertificado.mstrNorma = strRetornaNorma(nIdNorma);
					m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.AddtbProdutosCertificadoOrigemRow(dtrwProdutoCertificado);
					bRetorno = true;
				}
				bIntegridadeDados();
				return(bRetorno);
			}

			protected override bool bRemoveProdutos(ref System.Collections.ArrayList arlProdutos)
			{
				bool bRetorno = false;
				foreach(int nIdOrdemProduto in arlProdutos)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador,m_strIdPE,m_nIdTipoCO,nIdOrdemProduto);
					if ((dtrwProdutoCertificado != null) && (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted))
					{
						bRetorno = true;
						dtrwProdutoCertificado.Delete();
					}
				}
				bIntegridadeDados();
				return(bRetorno);
			}
		#endregion
		#region Produtos Associados
			protected override void vRefreshProdutosAssociados(ref mdlComponentesGraficos.TreeView tvProdutosAssociados)
			{
				tvProdutosAssociados.Nodes.Clear();
				System.Windows.Forms.TreeNode tvnNorma = null;
				System.Windows.Forms.TreeNode tvnClassificacao = null;
				System.Windows.Forms.TreeNode tvnProduto = null;

				// Produtos Certificado
				System.Collections.ArrayList arlProdutosCertificado = arlProdutosCertificadoOrigem();

				// Ordenamento
				System.Collections.SortedList sortProdutosCertificado = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				for(int i = 0; i < arlProdutosCertificado.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[i];
					if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
						if (!sortProdutosCertificado.ContainsKey(dtrwProdutoCertificado.idOrdem))
							sortProdutosCertificado.Add(dtrwProdutoCertificado.idOrdem,dtrwProdutoCertificado.idOrdem);
				}

				// Inserindo 
				string strNormaUltima = "";
				string strClassificacaoUltima = "";
				for (int i = 0; i < sortProdutosCertificado.Count; i++)
				{
					int nIdOrdem = (int)sortProdutosCertificado.GetByIndex(i);
					for(int j = 0; j < arlProdutosCertificado.Count;j++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[j];
						if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutoCertificado.idOrdem == nIdOrdem))
						{
							// Norma
							string strNorma = strRetornaNorma(dtrwProdutoCertificado.idNorma);
							if (!dtrwProdutoCertificado.IsmstrNormaNull())
								strNorma = dtrwProdutoCertificado.mstrNorma;
							if (strNorma != strNormaUltima)
							{
								tvnNorma = tvProdutosAssociados.Nodes.Add(strNorma);
								tvnNorma.Tag = dtrwProdutoCertificado.idNorma;
								strNormaUltima = strNorma;
								strClassificacaoUltima = "";
							}
							// Classificacao
							string strClassificacao = strRetornaClassificacao(dtrwProdutoCertificado.idOrdemProduto);

							// Denominacao
							string strDenominacao = "";
							if (!dtrwProdutoCertificado.IsmstrDenominacaoNull())
								strDenominacao = dtrwProdutoCertificado.mstrDenominacao;
							else
								strDenominacao = strRetornaDenominacao(dtrwProdutoCertificado.idOrdemProduto);

							if (strClassificacao != strClassificacaoUltima)
							{
								tvnClassificacao = tvnNorma.Nodes.Add(strClassificacao + " " + strDenominacao);
								tvnClassificacao.Tag = strClassificacao;
								strClassificacaoUltima = strClassificacao;
							}

							// Descricao
							string strDescricao = "";
							if (!dtrwProdutoCertificado.IsmstrDescricaoNull())
								strDescricao = dtrwProdutoCertificado.mstrDescricao;
							else
								strDescricao = strRetornaDescricaoProduto(dtrwProdutoCertificado.idOrdemProduto);
							if (tvnClassificacao == null)
							{
								tvnClassificacao = tvnNorma.Nodes.Add(strClassificacao + " " + strDenominacao);
								tvnClassificacao.Tag = strClassificacao;
							}
							tvnProduto =  tvnClassificacao.Nodes.Add(strDescricao);
							tvnProduto.Tag = dtrwProdutoCertificado.idOrdemProduto;
						}
					}
				}
			}
		#endregion
		#region Normas
			private string strRetornaNorma(int nIdNorma)
			{
				string strNormaOriginal = "";
				string strNormaDetalhes = "";
				string strNormaPersonalizada = "";
				bCarregaDadosNorma(nIdNorma,out strNormaOriginal,out strNormaDetalhes,out strNormaPersonalizada);
				if (strNormaPersonalizada.Trim() != "")
					strNormaOriginal = strNormaPersonalizada;
				return(strNormaOriginal);
			}

			private bool bNormaUtilizadaCertificado(int nIdNorma)
			{
				bool bRetorno = false;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
					if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
						if ((dtrwProdutoCertificado.idExportador == m_nIdExportador) && (dtrwProdutoCertificado.idPE == m_strIdPE) && (dtrwProdutoCertificado.idTipoCO == m_nIdTipoCO) && (dtrwProdutoCertificado.idNorma == nIdNorma))
							return(true);
				return(bRetorno);
			}
			private bool bCarregaDadosNorma(int nIdNorma,out string strNormaOriginal,out string strNormaDetalhes,out string strNormaPersonalizada)
			{
				bool bRetorno = false;

				strNormaOriginal = "";
				strNormaDetalhes = "";
				strNormaPersonalizada = "";
				
				// Norma Original 
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwNorma = m_typDatSetTbCertificadosOrigemNormasResource.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO,nIdNorma);
				if (bRetorno = (dtrwNorma != null))
				{
					strNormaOriginal = dtrwNorma.mstrNome;
					strNormaDetalhes = dtrwNorma.mstrDescricao;
				}
				// Norma Personalizada 
				dtrwNorma = m_typDatSetTbCertificadosOrigemNormasDataBase.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO,nIdNorma);
				if (dtrwNorma != null)
					strNormaPersonalizada = dtrwNorma.mstrNome;
				return(bRetorno);
			}

			private bool bSalvaDadoNorma(int nIdNorma,string strNormaPersonalizada)
			{
				bool bRetorno = false;
				// Norma Personalizada 
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigemNormas.tbCertificadosOrigemNormasRow dtrwNorma = m_typDatSetTbCertificadosOrigemNormasDataBase.tbCertificadosOrigemNormas.FindBynIdTipoCOnIdNorma(m_nIdTipoCO,nIdNorma);
				if (dtrwNorma == null)
				{
					dtrwNorma = m_typDatSetTbCertificadosOrigemNormasDataBase.tbCertificadosOrigemNormas.NewtbCertificadosOrigemNormasRow();
					dtrwNorma.nIdTipoCO = m_nIdTipoCO;
					dtrwNorma.nIdNorma = nIdNorma;
					dtrwNorma.mstrNome = strNormaPersonalizada;
					m_typDatSetTbCertificadosOrigemNormasDataBase.tbCertificadosOrigemNormas.AddtbCertificadosOrigemNormasRow(dtrwNorma);
					bRetorno = true;
				}else{ // Editar
					dtrwNorma.mstrNome = strNormaPersonalizada;
					bRetorno = true;
				}
				return(bRetorno);
			}
		#endregion

		#region Integridade
		protected override bool bIntegridadeDados()
		{
			bool bRetorno = false;
			int nNextIdOrdemCertificado = 0;

			// Produtos Certificado
			System.Collections.ArrayList arlProdutosCertificado = arlProdutosCertificadoOrigem();

			// Normas - Ordenamento
			System.Collections.SortedList sortListNormas = new System.Collections.SortedList();
			for(int i = 0; i < arlProdutosCertificado.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[i];
				if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
				{
					string strNorma = "";
					if (!dtrwProdutoCertificado.IsmstrNormaNull())
						strNorma = dtrwProdutoCertificado.mstrNorma;
					else
					    strNorma = strRetornaNorma(dtrwProdutoCertificado.idNorma);
					if (!sortListNormas.ContainsKey(strNorma))
						sortListNormas.Add(strNorma,dtrwProdutoCertificado.idNorma);
				}
			}

			// Normas - Insercao
			for(int i = 0; i < sortListNormas.Count;i++)
			{
				// Classificacao - Ordenamento
				int nIdNorma = Int32.Parse(sortListNormas.GetByIndex(i).ToString());
				System.Collections.SortedList sortListClassificacao = new System.Collections.SortedList();
				for(int j = 0; j < arlProdutosCertificado.Count;j++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[j];
					if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (!dtrwProdutoCertificado.IsidNormaNull()) && (dtrwProdutoCertificado.idNorma == nIdNorma))
					{
						string strClassificacao = strRetornaClassificacao(dtrwProdutoCertificado.idOrdemProduto);
						if (!sortListClassificacao.Contains(strClassificacao))
							sortListClassificacao.Add(strClassificacao,strClassificacao);
					}
				}
				// Classificacao - Insercao
				for(int j = 0; j < sortListClassificacao.Count;j++)
				{
					string strClassificacao = sortListClassificacao.GetByIndex(j).ToString();
					string strUnidadeUltima = "";
					for(int k = 0; k < arlProdutosCertificado.Count;k++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[k];
						string strClassificacaoProduto = strRetornaClassificacao(dtrwProdutoCertificado.idOrdemProduto);
						if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (!dtrwProdutoCertificado.IsidNormaNull()) && (dtrwProdutoCertificado.idNorma == nIdNorma) && (strClassificacao == strClassificacaoProduto))
						{
							string strUnidadeProduto = strRetornaUnidadeProduto(dtrwProdutoCertificado.idOrdemProduto);
							if (strUnidadeUltima != strUnidadeProduto)
							{
								nNextIdOrdemCertificado++;
								strUnidadeUltima = strUnidadeProduto;
							}
							dtrwProdutoCertificado.idOrdem = nNextIdOrdemCertificado;
						}
					}
				}
			}
			bRetorno = true;
			return(bRetorno);
		}
		#endregion

	}
}

