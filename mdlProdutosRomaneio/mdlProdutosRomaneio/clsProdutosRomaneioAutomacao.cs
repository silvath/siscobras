using System;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for clsProdutosRomaneioAutomacao.
	/// </summary>
	public class clsProdutosRomaneioAutomacao
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			private int m_nIdExportador;
			private string m_strIdPe;

			private Formularios.frmFAutomacao m_frmFAutomacao = null;

			private int m_nTipoOrdenacao = -1;

			private mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow m_dtrwRomaneio = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetProdutosFaturaComercial = null;

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado m_typDatSetProdutosRomaneioSimplificado = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetProdutosRomaneioEmbalagensProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos m_typDatSetProdutosRomaneioVolumesProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens m_typDatSetProdutosRomaneioEmbalagens = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes m_typDatSetProdutosRomaneioVolumes = null;
		#endregion
		#region Properties
			private mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow Romaneio
			{
				get
				{
					if (m_dtrwRomaneio != null)
						return(m_dtrwRomaneio);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("IdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetRomaneios.tbRomaneios.Rows.Count > 0)
						m_dtrwRomaneio = typDatSetRomaneios.tbRomaneios[0];
					return(m_dtrwRomaneio);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutos Produtos
			{
				get
				{
					if (m_typDatSetProdutos != null)
						return(m_typDatSetProdutos);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutos);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial ProdutosFaturaComercial
			{
				get
				{
					if (m_typDatSetProdutosFaturaComercial != null)
						return(m_typDatSetProdutosFaturaComercial);

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
					m_typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosFaturaComercial);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado ProdutosRomaneioSimplificado
			{
				get
				{
					if (m_typDatSetProdutosRomaneioSimplificado != null)
						return(m_typDatSetProdutosRomaneioSimplificado);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosRomaneioSimplificado = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioSimplificado(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosRomaneioSimplificado);

				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos ProdutosRomaneioEmbalagensProdutos
			{
				get
				{
					if (m_typDatSetProdutosRomaneioEmbalagensProdutos != null)
						return(m_typDatSetProdutosRomaneioEmbalagensProdutos);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosRomaneioEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					return(m_typDatSetProdutosRomaneioEmbalagensProdutos);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos ProdutosRomaneioVolumesProdutos
			{
				get
				{
					if (m_typDatSetProdutosRomaneioVolumesProdutos != null)
						return(m_typDatSetProdutosRomaneioVolumesProdutos);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosRomaneioVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					return(m_typDatSetProdutosRomaneioVolumesProdutos);
				}
			} 

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens ProdutosRomaneioEmbalagens
			{
				get
				{
					if (m_typDatSetProdutosRomaneioEmbalagens != null)
						return(m_typDatSetProdutosRomaneioEmbalagens);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosRomaneioEmbalagens = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					return(m_typDatSetProdutosRomaneioEmbalagens);
				}
			} 
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes ProdutosRomaneioVolumes
			{
				get
				{
					if (m_typDatSetProdutosRomaneioVolumes != null)
						return(m_typDatSetProdutosRomaneioVolumes);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosRomaneioVolumes = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosRomaneioVolumes);
				}
			} 

			private int TipoOrdenacao
			{
				get
				{
					if (m_nTipoOrdenacao != -1)
						return(m_nTipoOrdenacao);
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = this.Romaneio;
					if (dtrwRomaneio == null)
						return(m_nTipoOrdenacao);
					if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						m_nTipoOrdenacao = dtrwRomaneio.nTipoOrdenacao;
					return(m_nTipoOrdenacao);
				}
			}
		#endregion
		#region Constructors
			public clsProdutosRomaneioAutomacao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro , ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB , string strEnderecoExecutavel,int nIdExportador, string strIdPe)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB; 
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
			}
		#endregion
			
		#region ShowDialog
			public bool ShowDialog()
			{
				m_frmFAutomacao = new mdlProdutosRomaneio.Formularios.frmFAutomacao(m_strEnderecoExecutavel);
				InitializeEvents(ref m_frmFAutomacao);
				m_frmFAutomacao.ShowDialog();
				if (m_frmFAutomacao.Confirmed)
					return(SalvaDados());
				return(false);
			}

			private void InitializeEvents(ref mdlProdutosRomaneio.Formularios.frmFAutomacao form)
			{
				// Refresh Produtos Fatura
				form.eCallRefreshProdutosFatura += new mdlProdutosRomaneio.Formularios.frmFAutomacao.delCallRefreshProdutosFatura(RefreshProdutosFatura);

				// Refresh Produtos Romaneio
				form.eCallRefreshProdutosRomaneio += new mdlProdutosRomaneio.Formularios.frmFAutomacao.delCallRefreshProdutosRomaneio(RefreshProdutosRomaneio);

				// Insere Produtos
				form.eCallInsereProdutos += new mdlProdutosRomaneio.Formularios.frmFAutomacao.delCallInsereProdutos(InsereProdutosRomaneio);

				// Remove Produtos
				form.eCallRemoverProdutos += new mdlProdutosRomaneio.Formularios.frmFAutomacao.delCallRemoverProdutos(RemoverProdutosRomaneio);

				// ShowDialog Produtos
				form.eCallShowDialogProdutos += new mdlProdutosRomaneio.Formularios.frmFAutomacao.delCallShowDialogProdutos(ShowDialogProdutos);

			}
		#endregion
		#region ShowDialogProdutos
			private bool ShowDialogProdutos()
			{
				System.Windows.Forms.ImageList ilBandeiras = mdlConstantes.clsConstantes.ListaBandeiras;
				mdlProdutosGeral.clsProdutos clsProdutos = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,(int)mdlConstantes.Idioma.Portugues,ref ilBandeiras);
				clsProdutos.Codigo = m_strIdPe;
				clsProdutos.DataSourceCodigo = mdlProdutosGeral.DataSource.FaturaComercial;
				clsProdutos.ApenasProdutosCodigo = true;
				clsProdutos.ShowDialogProdutos();
				if (clsProdutos.Confirmed)
				{
					CarregaDados();
					return(true);
				} 
				return(false);
			}
		#endregion

		#region CarregaDados
			private void CarregaDados()
			{
				m_dtrwRomaneio = null;
				m_typDatSetProdutos = null;
				m_typDatSetProdutosFaturaComercial = null;

				m_typDatSetProdutosRomaneioSimplificado = null;
				m_typDatSetProdutosRomaneioEmbalagensProdutos = null;
				m_typDatSetProdutosRomaneioVolumesProdutos = null;
				m_typDatSetProdutosRomaneioEmbalagens = null;
				m_typDatSetProdutosRomaneioVolumes = null;
			}
		#endregion
		#region SalvaDados
			private bool SalvaDados()
			{
				bool bRetorno = false;
				switch(this.TipoOrdenacao)
				{
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado: // Simplificado
						bRetorno = SalvaDadosRomaneioSimplificado();
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes: // Volumes
					case (int)mdlConstantes.Relatorio.Romaneio: // Produtos
						bRetorno = SalvaDadosRomaneioDetalhado();
						break;
				}
				return(bRetorno);
			}

			private bool SalvaDadosRomaneioSimplificado()
			{
				if (m_typDatSetProdutosRomaneioSimplificado != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioSimplificado(m_typDatSetProdutosRomaneioSimplificado);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				return(true);
			}

			private bool SalvaDadosRomaneioDetalhado()
			{
				if (m_typDatSetProdutosRomaneioEmbalagensProdutos != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagensProdutos(m_typDatSetProdutosRomaneioEmbalagensProdutos);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				if (m_typDatSetProdutosRomaneioVolumesProdutos != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumesProdutos(m_typDatSetProdutosRomaneioVolumesProdutos);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				if (m_typDatSetProdutosRomaneioEmbalagens != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioEmbalagens(m_typDatSetProdutosRomaneioEmbalagens);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				if (m_typDatSetProdutosRomaneioVolumes != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosRomaneioVolumes(m_typDatSetProdutosRomaneioVolumes);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				return(true);
			}
		#endregion

		#region Produtos
			private bool IsProdutoInformacoesAutomacao(int nIdProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.Produtos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto == null)
					return(false);
				//TODO: Work over here
				if ((dtrwProduto.IsdQuantidadeVolumeNull()) || (dtrwProduto.dQuantidadeVolume == 0))
					return(false);
				return(true);
			}
		#endregion
		#region Romaneio
			private decimal GetQuantidadeRestanteProdutoFatura(int nIdOrdemProduto)
			{
				return(GetQuantidadeRestanteProdutoFatura(this.ProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProduto)));
			}
			
			private decimal GetQuantidadeRestanteProdutoFatura(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura)
			{
				if (dtrwProdutoFatura == null)
					return(0m);
				return(((decimal)dtrwProdutoFatura.dQuantidade) - GetQuantidadeProdutoContidaRomaneio(dtrwProdutoFatura.idOrdem));
			}

			private decimal GetQuantidadeProdutoContidaRomaneio(int nIdOrdemProduto)
			{
				decimal dcQuantidade = 0;
				switch(this.TipoOrdenacao)
				{
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado: // Simplificado
						dcQuantidade = GetQuantidadeProdutoContidoRomaneioSimplificado(nIdOrdemProduto);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes: // Volumes
					case (int)mdlConstantes.Relatorio.Romaneio: // Produtos
						dcQuantidade = GetQuantidadeProdutoContidoRomaneioDetalhado(nIdOrdemProduto);
						break;
				}
				return(dcQuantidade);
			}

			private decimal GetQuantidadeProdutoContidoRomaneioSimplificado(int nIdOrdemProduto)
			{
				decimal dcQuantidade = 0;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = this.ProdutosRomaneioSimplificado;
				for(int i = 0; i < typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneioSimplificado = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado[i];
					if (dtrwProdutoRomaneioSimplificado.RowState == System.Data.DataRowState.Deleted)
						continue;
					if (dtrwProdutoRomaneioSimplificado.nIdOrdemProduto == nIdOrdemProduto)
						dcQuantidade = dcQuantidade + (decimal)dtrwProdutoRomaneioSimplificado.dQuantidadeProduto;
				}
				return(dcQuantidade);
			}

			private decimal GetQuantidadeProdutoContidoRomaneioDetalhado(int nIdOrdemProduto)
			{
				decimal dcQuantidade = 0;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetProdutosRomaneioEmbalagensProdutos = this.ProdutosRomaneioEmbalagensProdutos;
				for(int i = 0; i < typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem = typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos[i];
					if (dtrwProdutoEmbalagem.RowState == System.Data.DataRowState.Deleted)
						continue;
					if (dtrwProdutoEmbalagem.nIdOrdemProduto == nIdOrdemProduto)
						dcQuantidade = dcQuantidade + (decimal)dtrwProdutoEmbalagem.dQuantidade;
				}

				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetProdutosRomaneioVolumesProdutos = this.ProdutosRomaneioVolumesProdutos;
				for(int i = 0; i < typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume = typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos[i];
					if (dtrwProdutoVolume.RowState == System.Data.DataRowState.Deleted)
						continue;
					if (dtrwProdutoVolume.nIdOrdemProduto == nIdOrdemProduto)
						dcQuantidade = dcQuantidade + (decimal)dtrwProdutoVolume.dQuantidade;
				}
				return(dcQuantidade);
			}

			private bool InsereProdutosRomaneio(int[] nIdOrdemProdutos)
			{
				bool bReturn = false;
				switch(this.TipoOrdenacao)
				{
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado: // Simplificado
						bReturn = InsereProdutosRomaneioSimplificado(nIdOrdemProdutos);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes: // Volumes
					case (int)mdlConstantes.Relatorio.Romaneio: // Produtos
						bReturn = InsereProdutosRomaneioDetalhado(nIdOrdemProdutos);
						break;
				}
				return(bReturn);
			}

			private bool InsereProdutosRomaneioSimplificado(int[] nIdOrdemProdutos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.ProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = this.Produtos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = this.ProdutosRomaneioSimplificado;
				for(int i = 0; i < nIdOrdemProdutos.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProdutos[i]);
					if (dtrwProdutoFatura == null)
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
					if (dtrwProduto == null)
						continue;
					if (!IsProdutoInformacoesAutomacao(dtrwProdutoFatura.idProduto))
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneioSimplificado = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.NewtbProdutosRomaneioSimplificadoRow();

					dtrwProdutoRomaneioSimplificado.IdExportador = m_nIdExportador;
					dtrwProdutoRomaneioSimplificado.idPE = m_strIdPe;
					dtrwProdutoRomaneioSimplificado.nIdOrdem = GetNextIdOrdemRomaneioSimplificado();

					dtrwProdutoRomaneioSimplificado.nIdOrdemProduto = nIdOrdemProdutos[i];
					dtrwProdutoRomaneioSimplificado.dQuantidadeProduto = dtrwProdutoFatura.dQuantidade;
					dtrwProdutoRomaneioSimplificado.dQuantidadeVolumes = (double)GetQuantidadeVolumes((decimal)dtrwProdutoFatura.dQuantidade,(decimal)dtrwProduto.dQuantidadeVolume);
					dtrwProdutoRomaneioSimplificado.dPesoLiquidoUnitario = !dtrwProduto.IsdPesoLiquidoNull() ? dtrwProduto.dPesoLiquido:0;
					dtrwProdutoRomaneioSimplificado.dPesoBrutoUnitario = !dtrwProduto.IsdPesoBrutoNull() ? dtrwProduto.dPesoBruto:0;
					dtrwProdutoRomaneioSimplificado.nUnidadeMassaPesoLiquido = !dtrwProduto.IsnUnidadeMassaPesoLiquidoNull() ? dtrwProduto.nUnidadeMassaPesoLiquido : 0;
					dtrwProdutoRomaneioSimplificado.nUnidadeMassaPesoBruto = !dtrwProduto.IsnUnidadeMassaPesoBrutoNull() ? dtrwProduto.nUnidadeMassaPesoBruto : 0;
					dtrwProdutoRomaneioSimplificado.nlTipoVolume = !dtrwProduto.IsnlTipoVolumeNull() ? dtrwProduto.nlTipoVolume : 0;
					dtrwProdutoRomaneioSimplificado.strTipoPopular = !dtrwProduto.IsstrTipoPopularNull() ? dtrwProduto.strTipoPopular : "";
					dtrwProdutoRomaneioSimplificado.dLargura = !dtrwProduto.IsdVolumeLarguraNull() ? dtrwProduto.dVolumeLargura : 0;
					dtrwProdutoRomaneioSimplificado.dAltura = !dtrwProduto.IsdVolumeAlturaNull() ? dtrwProduto.dVolumeAltura : 0;
					dtrwProdutoRomaneioSimplificado.dComprimento = !dtrwProduto.IsdVolumeComprimentoNull() ? dtrwProduto.dVolumeComprimento : 0;
					dtrwProdutoRomaneioSimplificado.nUnidadeLargura = !dtrwProduto.IsnVolumeUnidadeLarguraNull() ? dtrwProduto.nVolumeUnidadeLargura : 0;
					dtrwProdutoRomaneioSimplificado.nUnidadeAltura = !dtrwProduto.IsnVolumeUnidadeAlturaNull() ? dtrwProduto.nVolumeUnidadeAltura : 0;
					dtrwProdutoRomaneioSimplificado.nUnidadeComprimento = !dtrwProduto.IsnVolumeUnidadeComprimentoNull() ? dtrwProduto.nVolumeUnidadeComprimento : 0;
					decimal dVolume;
					int nUnidadeVolume;
					GetVolume(out dVolume,out nUnidadeVolume,(decimal)dtrwProdutoRomaneioSimplificado.dLargura,dtrwProdutoRomaneioSimplificado.nUnidadeLargura,(decimal)dtrwProdutoRomaneioSimplificado.dAltura,dtrwProdutoRomaneioSimplificado.nUnidadeAltura,(decimal)dtrwProdutoRomaneioSimplificado.dComprimento,dtrwProdutoRomaneioSimplificado.nUnidadeComprimento);
					dtrwProdutoRomaneioSimplificado.dVolume = (double)dVolume;
					dtrwProdutoRomaneioSimplificado.nUnidadeVolume = nUnidadeVolume;

					typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.AddtbProdutosRomaneioSimplificadoRow(dtrwProdutoRomaneioSimplificado);
				}
				return(true);
			}

			private decimal GetQuantidadeVolumes(decimal dQuantidadeProduto,decimal dQuantidadeProdutoVolume)
			{
				decimal dQuantidadeVolume = (dQuantidadeProduto /dQuantidadeProdutoVolume);
				decimal dQuantidadeVolumeExata = System.Math.Round(dQuantidadeVolume,0);
				if (dQuantidadeVolumeExata < dQuantidadeVolume)
					dQuantidadeVolumeExata++;
				return(dQuantidadeVolumeExata);
			}
			
			private void GetVolume(out decimal dVolume,out int nUnidadeVolume,decimal dLargura,int nUnidadeLargura,decimal dAltura,int nUnidadeAltura,decimal dComprimento,int nUnidadeComprimento)
			{
				dVolume = 0;
				nUnidadeVolume = 0;
				if ((nUnidadeLargura == nUnidadeAltura) && (nUnidadeLargura == nUnidadeComprimento))
				{
					dVolume = dLargura * dAltura * dComprimento;
					nUnidadeVolume = nUnidadeLargura; 
				}else{
					dAltura = dAltura * (clsProdutosRomaneio.dcRetornaFatorConversaoEntreUnidadesEspaco(nUnidadeAltura,nUnidadeLargura));
					dComprimento = dComprimento * (clsProdutosRomaneio.dcRetornaFatorConversaoEntreUnidadesEspaco(nUnidadeComprimento,nUnidadeLargura));
					dVolume = dLargura * dAltura * dComprimento;
					nUnidadeVolume = nUnidadeLargura; 
				}
			} 

			private bool InsereProdutosRomaneioDetalhado(int[] nIdOrdemProdutos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.ProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = this.Produtos;

				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetProdutosRomaneioVolumes = this.ProdutosRomaneioVolumes;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetProdutosRomaneioVolumesProdutos = this.ProdutosRomaneioVolumesProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetProdutosRomaneioEmbalagens = this.ProdutosRomaneioEmbalagens;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetProdutosRomaneioEmbalagensProdutos = this.ProdutosRomaneioEmbalagensProdutos;

				for(int i = 0; i < nIdOrdemProdutos.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdemProdutos[i]);
					if (dtrwProdutoFatura == null)
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
					if (dtrwProduto == null)
						continue;
					if (!IsProdutoInformacoesAutomacao(dtrwProdutoFatura.idProduto))
						continue;

					decimal dcQuantidadeVolume = !dtrwProduto.IsdQuantidadeVolumeNull() ? (decimal)dtrwProduto.dQuantidadeVolume : 0m;
					decimal dcQuantidadeEmbalagem = !dtrwProduto.IsdQuantidadeEmbalagemNull() ? (decimal)dtrwProduto.dQuantidadeEmbalagem : 0m;
					int nQuantidadeEmbalagensVolume = !dtrwProduto.IsdQuantidadeEmbalagensVolumeNull() ? (int)dtrwProduto.dQuantidadeEmbalagensVolume : 0;
                    decimal dcQuantidadeProduto = this.GetQuantidadeRestanteProdutoFatura(nIdOrdemProdutos[i]);

					decimal dcPesoLiquidoUnitario = !dtrwProduto.IsdPesoLiquidoNull() ? (decimal)dtrwProduto.dPesoLiquido : 0;
					decimal dcPesoBrutoUnitario = !dtrwProduto.IsdPesoBrutoNull() ? (decimal)dtrwProduto.dPesoBruto : 0;

					while (dcQuantidadeProduto > 0)
					{
						decimal dcQuantidadeProdutoInserido = 0;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume = typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.NewtbProdutosRomaneioVolumesRow();

						dtrwVolume.idExportador = m_nIdExportador;
						dtrwVolume.idPE = m_strIdPe;
						dtrwVolume.strNumeroVolume = GetNextStrNumeroVolume(typDatSetProdutosRomaneioVolumes);

						dtrwVolume.nlTipoVolume = !dtrwProduto.IsnlTipoVolumeNull() ? dtrwProduto.nlTipoVolume : 0;
						dtrwVolume.strTipoPopular = !dtrwProduto.IsstrTipoPopularNull() ? dtrwProduto.strTipoPopular : "";
						dtrwVolume.dLargura = !dtrwProduto.IsdVolumeLarguraNull() ? dtrwProduto.dVolumeLargura : 0;
						dtrwVolume.dAltura = !dtrwProduto.IsdVolumeAlturaNull() ? dtrwProduto.dVolumeAltura : 0;
						dtrwVolume.dComprimento = !dtrwProduto.IsdVolumeComprimentoNull() ? dtrwProduto.dVolumeComprimento : 0;
						dtrwVolume.nUnidadeLargura = !dtrwProduto.IsnVolumeUnidadeLarguraNull() ? dtrwProduto.nVolumeUnidadeLargura : (int)mdlConstantes.UnidadeMedida.Metro;
						dtrwVolume.nUnidadeAltura = !dtrwProduto.IsnVolumeUnidadeAlturaNull() ? dtrwProduto.nVolumeUnidadeAltura : (int)mdlConstantes.UnidadeMedida.Metro;
						dtrwVolume.nUnidadeComprimento = !dtrwProduto.IsnVolumeUnidadeComprimentoNull() ? dtrwProduto.nVolumeUnidadeComprimento : (int)mdlConstantes.UnidadeMedida.Metro;
						dtrwVolume.nUnidadeMassaPesoLiquido = !dtrwProduto.IsnUnidadeMassaPesoLiquidoNull() ? dtrwProduto.nUnidadeMassaPesoLiquido : (int)mdlConstantes.UnidadeMassa.Kilograma;
						dtrwVolume.nUnidadeMassaPesoBruto = !dtrwProduto.IsnUnidadeMassaPesoBrutoNull() ? dtrwProduto.nUnidadeMassaPesoBruto : (int)mdlConstantes.UnidadeMassa.Kilograma;
						decimal dcVolume = 0;
						int nUnidadeVolume = 0;
						GetVolume(out dcVolume,out nUnidadeVolume,(decimal)dtrwVolume.dLargura,dtrwVolume.nUnidadeLargura,(decimal)dtrwVolume.dAltura,dtrwVolume.nUnidadeAltura,(decimal)dtrwVolume.dComprimento,dtrwVolume.nUnidadeComprimento);
						dtrwVolume.dVolume = (double)dcVolume;
						dtrwVolume.nUnidadeVolume = nUnidadeVolume;

						// Volumes Produtos
						if (dcQuantidadeVolume > 0)
						{
							decimal dcQuantidadeInseridaVolume = 0;
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume = typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.NewtbProdutosRomaneioVolumesProdutosRow();
							dtrwProdutoVolume.idExportador = m_nIdExportador;
							dtrwProdutoVolume.idPE = m_strIdPe;
							dtrwProdutoVolume.strNumeroVolume = dtrwVolume.strNumeroVolume;
                            dtrwProdutoVolume.nIdOrdemProduto = nIdOrdemProdutos[i];
							if (dcQuantidadeProduto > dcQuantidadeVolume)
							{
								dcQuantidadeInseridaVolume = dcQuantidadeVolume;
								dcQuantidadeProduto = dcQuantidadeProduto - dcQuantidadeVolume;
								dcQuantidadeProdutoInserido = dcQuantidadeProdutoInserido + dcQuantidadeInseridaVolume;
							}else{
								dcQuantidadeInseridaVolume = dcQuantidadeProduto;
								dcQuantidadeProduto = 0;
								dcQuantidadeProdutoInserido = dcQuantidadeProdutoInserido + dcQuantidadeInseridaVolume;
							}
							dtrwProdutoVolume.dQuantidade = (double)dcQuantidadeInseridaVolume;
							dtrwProdutoVolume.dPesoLiquido = (double)dcPesoLiquidoUnitario;
							dtrwProdutoVolume.nUnidadeMassaPesoLiquido = dtrwVolume.nUnidadeMassaPesoLiquido;
							typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.AddtbProdutosRomaneioVolumesProdutosRow(dtrwProdutoVolume);
						}

						// Volumes Embalagens
						for(int j = 0; j < nQuantidadeEmbalagensVolume;j++)
						{
							if (dcQuantidadeProduto <= 0)
								break;
							decimal dcQuantidadeInseridaEmbalagem = 0;

							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem = typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.NewtbProdutosRomaneioEmbalagensRow();
							dtrwEmbalagem.idExportador = m_nIdExportador;
							dtrwEmbalagem.idPE = m_strIdPe;
							dtrwEmbalagem.strIdEmbalagem = GetNextStrIdEmbalagem(typDatSetProdutosRomaneioEmbalagens);
							dtrwEmbalagem.strNumeroVolume = dtrwVolume.strNumeroVolume; 

							// Volumes Embalagens Produtos
							if (dcQuantidadeEmbalagem > 0)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwEmbalagemProduto = typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.NewtbProdutosRomaneioEmbalagensProdutosRow();
								dtrwEmbalagemProduto.idExportador = m_nIdExportador;
								dtrwEmbalagemProduto.idPE = m_strIdPe;
								dtrwEmbalagemProduto.strIdEmbalagem = dtrwEmbalagem.strIdEmbalagem;
								dtrwEmbalagemProduto.nIdOrdemProduto = nIdOrdemProdutos[i];
								if (dcQuantidadeProduto > dcQuantidadeEmbalagem)
								{
									dcQuantidadeInseridaEmbalagem = dcQuantidadeEmbalagem;
									dcQuantidadeProduto = dcQuantidadeProduto - dcQuantidadeEmbalagem;
									dcQuantidadeProdutoInserido = dcQuantidadeProdutoInserido + dcQuantidadeInseridaEmbalagem;
								}else{
									dcQuantidadeInseridaEmbalagem = dcQuantidadeProduto;
									dcQuantidadeProduto = 0;
									dcQuantidadeProdutoInserido = dcQuantidadeProdutoInserido + dcQuantidadeInseridaEmbalagem;
								}
								dtrwEmbalagemProduto.dQuantidade = (double)dcQuantidadeInseridaEmbalagem;
								dtrwEmbalagemProduto.dPesoLiquido = (double)dcPesoLiquidoUnitario;
								dtrwEmbalagemProduto.nUnidadeMassaPesoLiquido = dtrwVolume.nUnidadeMassaPesoLiquido;

								typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.AddtbProdutosRomaneioEmbalagensProdutosRow(dtrwEmbalagemProduto);
							}

							if (dcQuantidadeInseridaEmbalagem > 0)
							{
								typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.AddtbProdutosRomaneioEmbalagensRow(dtrwEmbalagem);
							}
						}

						if (dcQuantidadeProdutoInserido > 0)
						{
							dtrwVolume.dPesoLiquido = (double)(dcQuantidadeProdutoInserido * dcPesoLiquidoUnitario);
							dtrwVolume.dPesoBruto = (double)(dcQuantidadeProdutoInserido * dcPesoBrutoUnitario);
							typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.AddtbProdutosRomaneioVolumesRow(dtrwVolume);
						}
					}
				}
				return(true);
			}

			private string GetNextStrNumeroVolume(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetProdutosRomaneioVolumes)
			{
				int nIndex = 1;
				bool bExists = true;
				while(bExists)
				{
					bExists = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume = typDatSetProdutosRomaneioVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(m_nIdExportador,m_strIdPe,nIndex.ToString());
					if (bExists = ((dtrwVolume != null) && (dtrwVolume.RowState != System.Data.DataRowState.Deleted)))
						nIndex++;
				}
				return(nIndex.ToString());
			}

			private string GetNextStrIdEmbalagem(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetProdutosRomaneioEmbalagens)
			{
				int nIndex = 1;
				bool bExists = true;
				while(bExists)
				{
					bExists = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem = typDatSetProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(m_nIdExportador,m_strIdPe,nIndex.ToString());
					if (bExists = ((dtrwEmbalagem != null) && (dtrwEmbalagem.RowState != System.Data.DataRowState.Deleted)))
						nIndex++;
				}
				return(nIndex.ToString());
			}


			private bool RemoverProdutosRomaneio(int[] nIdOrdemProdutos)
			{
				bool bReturn = false;
				switch(this.TipoOrdenacao)
				{
					case (int)mdlConstantes.Relatorio.RomaneioSimplificado: // Simplificado
						bReturn = RemoverProdutosRomaneioSimplificado(nIdOrdemProdutos);
						break;
					case (int)mdlConstantes.Relatorio.RomaneioVolumes: // Volumes
					case (int)mdlConstantes.Relatorio.Romaneio: // Produtos
						bReturn = RemoverProdutosRomaneioDetalhado(nIdOrdemProdutos);
						break;
				}
				return(bReturn);
			}

			private bool RemoverProdutosRomaneioSimplificado(int[] nIdOrdemProdutos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = this.ProdutosRomaneioSimplificado;
				for(int i = (typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows.Count - 1); i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneioSimplificado = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado[i];
					if (dtrwProdutoRomaneioSimplificado.RowState == System.Data.DataRowState.Deleted)
						continue;
					for(int j = 0; j < nIdOrdemProdutos.Length;j++)
					{
						if (dtrwProdutoRomaneioSimplificado.nIdOrdemProduto == nIdOrdemProdutos[j])
						{
							dtrwProdutoRomaneioSimplificado.Delete();
							break;
						}
					}
				}
				return(true);
			}

			private bool RemoverProdutosRomaneioDetalhado(int[] nIdOrdemProdutos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetProdutosRomaneioEmbalagensProdutos = this.ProdutosRomaneioEmbalagensProdutos;
				for(int i = 0; i < typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem = typDatSetProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos[i];
					if (dtrwProdutoEmbalagem.RowState == System.Data.DataRowState.Deleted)
						continue;
					for(int j = 0; j < nIdOrdemProdutos.Length;j++)
					{
						if (dtrwProdutoEmbalagem.nIdOrdemProduto == nIdOrdemProdutos[j])
						{
							dtrwProdutoEmbalagem.Delete();
							break;
						}
					}
				}
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetProdutosRomaneioVolumesProdutos = this.ProdutosRomaneioVolumesProdutos;
				for(int i = 0; i < typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume = typDatSetProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutos[i];
					if (dtrwProdutoVolume.RowState == System.Data.DataRowState.Deleted)
						continue;
					for(int j = 0; j < nIdOrdemProdutos.Length;j++)
					{
						if (dtrwProdutoVolume.nIdOrdemProduto == nIdOrdemProdutos[j])
						{
							dtrwProdutoVolume.Delete();
							break;
						}
					}
				}
				RemoveEmbalagensIntermediariasVazias();
				RemoveVolumesVazios();
				return(true);
			}
		#endregion
		#region Volumes
			private bool RemoveVolumesVazios()
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetVolumes = this.ProdutosRomaneioVolumes;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos = this.ProdutosRomaneioVolumesProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens = this.ProdutosRomaneioEmbalagens;
				for(int i = 0; i < typDatSetVolumes.tbProdutosRomaneioVolumes.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume = typDatSetVolumes.tbProdutosRomaneioVolumes[i];
					if (dtrwVolume.RowState == System.Data.DataRowState.Deleted)
						continue;
					bool bPossuiConteudo = false;
					for(int j = 0; j < typDatSetVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows.Count;j++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwVolumeProduto = typDatSetVolumesProdutos.tbProdutosRomaneioVolumesProdutos[j];
						if (dtrwVolumeProduto.RowState == System.Data.DataRowState.Deleted)
							continue;
						if (bPossuiConteudo = (dtrwVolume.strNumeroVolume == dtrwVolumeProduto.strNumeroVolume))
							break;
					}
					if (!bPossuiConteudo)
					{
						for(int j = 0; j < typDatSetEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;j++)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem = typDatSetEmbalagens.tbProdutosRomaneioEmbalagens[j];
							if (dtrwEmbalagem.RowState == System.Data.DataRowState.Deleted)
								continue;
							if (bPossuiConteudo = ((!dtrwEmbalagem.IsstrNumeroVolumeNull()) && (dtrwVolume.strNumeroVolume == dtrwEmbalagem.strNumeroVolume)))
								break;
						}
					}
					if (!bPossuiConteudo)
						dtrwVolume.Delete();
   				}
				return(true);
			}

			private bool RemoveEmbalagensIntermediariasVazias()
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens = this.ProdutosRomaneioEmbalagens;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos = this.ProdutosRomaneioEmbalagensProdutos;
				for(int i = 0; i < typDatSetEmbalagens.tbProdutosRomaneioEmbalagens.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem = typDatSetEmbalagens.tbProdutosRomaneioEmbalagens[i];
					if (dtrwEmbalagem.RowState == System.Data.DataRowState.Deleted)
						continue;
					bool bPossuiProduto = false;
					for(int j = 0; j < typDatSetEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows.Count;j++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwEmbalagemProduto = typDatSetEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos[j];
						if (dtrwEmbalagemProduto.RowState == System.Data.DataRowState.Deleted)
							continue;
						if (bPossuiProduto = (dtrwEmbalagem.strIdEmbalagem == dtrwEmbalagemProduto.strIdEmbalagem))
							break;
					}
					if (!bPossuiProduto)
						dtrwEmbalagem.Delete();
				}
				return(true);
			}
		#endregion
		#region Simplificado
			private int GetNextIdOrdemRomaneioSimplificado()
			{
				int index = 1;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = this.ProdutosRomaneioSimplificado;
				bool bExists = true;
				while(bExists)
				{
					bExists = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio = typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.FindByIdExportadoridPEnIdOrdem(m_nIdExportador,m_strIdPe,index);
					if (bExists = (dtrwProdutoRomaneio != null))
						index++;
				} 
				return(index);
			}
		#endregion

		#region Refresh
			private bool RefreshProdutosFatura(ref System.Windows.Forms.ListView lvProdutosFatura)
			{
				lvProdutosFatura.Items.Clear();
				System.Data.DataRow[] dtrwProdutosFatura = this.ProdutosFaturaComercial.tbProdutosFaturaComercial.Select("","idOrdem");
				if (dtrwProdutosFatura == null)
					return(false);
				System.Windows.Forms.ListViewItem lviProduto = null;
				for(int i = 0; i < dtrwProdutosFatura.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)dtrwProdutosFatura[i];
					decimal dQuantidade = 0;
					int nIdProduto = -1;
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						nIdProduto = dtrwProdutoFaturaComercial.idProduto;
					else
						continue;
					dQuantidade = GetQuantidadeRestanteProdutoFatura(dtrwProdutoFaturaComercial.idOrdem);
					if (dQuantidade > 0)
					{
						lviProduto = lvProdutosFatura.Items.Add(dQuantidade.ToString());
						lviProduto.SubItems.Add(dtrwProdutoFaturaComercial.strUnidade);
						if (!dtrwProdutoFaturaComercial.IsmstrDescricaoNull())
						{
							lviProduto.SubItems.Add(dtrwProdutoFaturaComercial.mstrDescricao);
						}else{
							string strDesricao = dtrwProdutoFaturaComercial.IsmstrDescricaoNull() ? "" : dtrwProdutoFaturaComercial.mstrDescricao;
							if (strDesricao == "")
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.Produtos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFaturaComercial.idProduto);
								if ((dtrwProduto != null) && (!dtrwProduto.IsmstrDescricaoNull()))
									strDesricao = dtrwProduto.mstrDescricao;
							}
							lviProduto.SubItems.Add(strDesricao);
						}
						lviProduto.Tag = dtrwProdutoFaturaComercial.idOrdem;
						if (IsProdutoInformacoesAutomacao(nIdProduto))
							lviProduto.ForeColor = System.Drawing.Color.Green;
						else
							lviProduto.ForeColor = System.Drawing.Color.Red;
					}
				}
				return(true);
			}

		

			private bool RefreshProdutosRomaneio(ref System.Windows.Forms.ListView lvProdutosRomaneio)
			{
				lvProdutosRomaneio.Items.Clear();
				System.Data.DataRow[] dtrwProdutosFatura = this.ProdutosFaturaComercial.tbProdutosFaturaComercial.Select("","idOrdem");
				if (dtrwProdutosFatura == null)
					return(false);
				System.Windows.Forms.ListViewItem lviProduto = null;
				for(int i = 0; i < dtrwProdutosFatura.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)dtrwProdutosFatura[i];
					decimal dQuantidade = 0;
					int nIdProduto = -1;
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						nIdProduto = dtrwProdutoFaturaComercial.idProduto;
					else
						continue;
					dQuantidade = GetQuantidadeProdutoContidaRomaneio(dtrwProdutoFaturaComercial.idOrdem);
					if (dQuantidade > 0)
					{
						lviProduto = lvProdutosRomaneio.Items.Add(dQuantidade.ToString());
						lviProduto.SubItems.Add(dtrwProdutoFaturaComercial.strUnidade);
						lviProduto.SubItems.Add(dtrwProdutoFaturaComercial.mstrDescricao);
						lviProduto.Tag = dtrwProdutoFaturaComercial.idOrdem;
						lviProduto.ForeColor = System.Drawing.Color.Green;
					}
				}
				return(true);
			}
		#endregion
	}
}
