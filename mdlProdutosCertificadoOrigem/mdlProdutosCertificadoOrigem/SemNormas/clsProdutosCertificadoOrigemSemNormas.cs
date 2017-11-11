using System;

namespace mdlProdutosCertificadoOrigem.SemNormas
{
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigemSemNormas.
	/// </summary>
	public abstract class clsProdutosCertificadoOrigemSemNormas : clsProdutosCertificadoOrigem
	{
		#region Construtors and Destructors
			public clsProdutosCertificadoOrigemSemNormas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, int nIdTipoCO, int nTipoClassificacao, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref ConnectionDB, EnderecoExecutavel, nIdExportador, strIdPE, nIdTipoCO, nTipoClassificacao, ref ilBandeiras)
			{
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
					dtrwProdutoCertificado.mstrNorma = "";
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
				System.Windows.Forms.TreeNode tvnClassificacao;
				System.Windows.Forms.TreeNode tvnProduto;

				// Produtos Certificado
				System.Collections.ArrayList arlProdutosCertificado = arlProdutosCertificadoOrigem();

				// Classificacao - Ordenamento
				System.Collections.SortedList sortListClassificacao = new System.Collections.SortedList();
				for(int j = 0; j < arlProdutosCertificado.Count;j++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[j];
					if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
					{
						// Classificacao
						string strClassificacao = strRetornaClassificacao(dtrwProdutoCertificado.idOrdemProduto);

						// Denominacao
						string strDenominacao = "";
						if (!dtrwProdutoCertificado.IsmstrDenominacaoNull())
							strDenominacao = dtrwProdutoCertificado.mstrDenominacao;
						else
							strDenominacao = strRetornaDenominacao(dtrwProdutoCertificado.idOrdemProduto);
						if (!sortListClassificacao.ContainsKey(strClassificacao + strDenominacao))
							sortListClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
					}
				}

				// Classificacao - Insercao 
				for(int j = 0; j < sortListClassificacao.Count;j++)
				{
					string strClassificacaoDenominacao = sortListClassificacao.GetKey(j).ToString();
					string strClassificacao = sortListClassificacao.GetByIndex(j).ToString();
					string strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);
					tvnClassificacao = tvProdutosAssociados.Nodes.Add(strClassificacao + " : " + strDenominacao);
					tvnClassificacao.Tag = strClassificacao;

					// Produtos - Ordenamento
					System.Collections.SortedList sortListProdutos = new System.Collections.SortedList();
					for(int k = 0; k < arlProdutosCertificado.Count;k++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[k];
						if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
						{
							string strClassificacaoProduto = strRetornaClassificacao(dtrwProdutoCertificado.idOrdemProduto);
							if (strClassificacaoProduto == strClassificacao)
							{
								string strDescricao = "";
								if (!dtrwProdutoCertificado.IsmstrDescricaoNull())
									strDescricao = dtrwProdutoCertificado.mstrDescricao;
								else
									strDescricao = strRetornaDescricaoProduto(dtrwProdutoCertificado.idOrdemProduto);
								if (strDescricao != "")
									if (!sortListProdutos.ContainsKey(strDescricao))
										sortListProdutos.Add(strDescricao,dtrwProdutoCertificado.idOrdemProduto);
							}
						}
					}

					// Produtos - Insercao
					for(int k = 0; k < sortListProdutos.Count;k++)
					{
						string strDescricaoProduto = sortListProdutos.GetKey(k).ToString();
						tvnProduto = tvnClassificacao.Nodes.Add(strDescricaoProduto);
						tvnProduto.Tag = sortListProdutos.GetByIndex(k).ToString();
					}
				}
			}
		#endregion

		#region Integridade
			protected override bool bIntegridadeDados()
			{
				bool bRetorno = false;
				int nNextIdOrdemCertificado = 0;

				// Produtos Certificado
				System.Collections.ArrayList arlProdutosCertificado = arlProdutosCertificadoOrigem();

				System.Collections.SortedList sortListClassificacao = new System.Collections.SortedList();
				for(int j = 0; j < arlProdutosCertificado.Count;j++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)arlProdutosCertificado[j];
					if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
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
						if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (strClassificacao == strClassificacaoProduto))
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
				bRetorno = true;
				return(bRetorno);
			}
		#endregion
	}
}
