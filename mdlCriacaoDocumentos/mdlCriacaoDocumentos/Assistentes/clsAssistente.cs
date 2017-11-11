using System;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for clsAssistente.
	/// </summary>
	public class clsAssistente
	{
		#region Static
			public static System.Drawing.Image GetImageAssistente()
			{
				return((System.Drawing.Image)(new frmFAssistente().Icon).ToBitmap());
			}
		#endregion

		#region Atributos
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnnectionDB = null;
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			protected string m_strEnderecoExecutavel = "";

			private int m_nIdExportador = 0;
			private string m_strCodigo = "";

			private bool m_bAutomatic = false;
			private bool m_bForceAllItens = false;

			private bool m_bConfirm = false;

			private System.Collections.ArrayList m_arlItens = new System.Collections.ArrayList();
		#endregion
		#region Properties
			protected int Exportador
			{
				set
				{
					m_nIdExportador = value;
				}
				get
				{
					return(m_nIdExportador);
				}
			}

			protected string Codigo
			{
				set
				{
					m_strCodigo = value;
				}
				get
				{
					return(m_strCodigo);
				}
			}

			public bool Confirm
			{
				get
				{
					return(m_bConfirm);
				}
			}

			public bool Automatic
			{
				set
				{
					m_bAutomatic = value;
				}
			}

			public bool ForceAllItens
			{
				set
				{
					m_bForceAllItens = value;
				}
			}

			public bool HasItensToFill
			{
				get
				{
					for(int i = 0; i < m_arlItens.Count; i++)
					{
						clsAssistenteItem item = (clsAssistenteItem)m_arlItens[i];
						if (!item.OnCallPreenchido())
							return(true);
					}
					return(false);
				}
			}
		#endregion
		#region Constructor
			public clsAssistente(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnnectionDB,string strEnderecoExecutavel)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_cls_dba_ConnnectionDB = cls_dba_ConnnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Itens
			protected clsAssistenteItem AdicionaItem(string strNome)
			{
				clsAssistenteItem itemInserir = new clsAssistenteItem();
				itemInserir.Nome = strNome;
				m_arlItens.Add(itemInserir);
				return(itemInserir);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				frmFAssistente formFAssistente = new frmFAssistente(ref m_arlItens,m_strEnderecoExecutavel);
				formFAssistente.Automatic = this.m_bAutomatic;
				formFAssistente.ForceAllItens = this.m_bForceAllItens;
				formFAssistente.ShowDialog();
				m_bConfirm = formFAssistente.Confirm;
				return(formFAssistente.Modificado);
			}
		#endregion

		#region Fatura Cotacao
		#region Idioma
		protected void vInsertItemFaturaCotacaoIdioma(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoIdioma);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoIdioma);
		}

		private bool bPreenchidoFaturaCotacaoIdioma()
		{
			System.Windows.Forms.ImageList ilBandeiras = null;
			mdlIdioma.clsIdioma obj = new mdlIdioma.clsIdiomaFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref ilBandeiras);
			int nIdioma;
			string strIdioma;
			obj.retornaValores(out nIdioma,out strIdioma);
			return(strIdioma != "");
		}

		private bool bShowDialogFaturaCotacaoIdioma()
		{
			System.Windows.Forms.ImageList ilBandeiras = null;
			mdlIdioma.clsIdioma obj = new mdlIdioma.clsIdiomaFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref ilBandeiras);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Moeda
		protected void vInsertItemFaturaCotacaoMoeda(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoMoeda);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoMoeda);
		}

		private bool bPreenchidoFaturaCotacaoMoeda()
		{
			mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			return(obj.HasValue);
		}

		private bool bShowDialogFaturaCotacaoMoeda()
		{
			mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Importador
		protected void vInsertItemFaturaCotacaoImportador(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoImportador);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoImportador);
		}

		private bool bPreenchidoFaturaCotacaoImportador()
		{
			System.Windows.Forms.ImageList imBandeiras = null;
			mdlImportador.clsImportador obj = new mdlImportador.clsImportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref imBandeiras);
			int nIdImportador;
			string strImportador, strEndereco, strCidade, strEstado, strPais, strTelefone, strFax, strEMail, strSite, strObs;
			obj.retornaValores(out nIdImportador, out strImportador, out strEndereco, out strCidade, out strEstado, out strPais, out strTelefone, out strFax, out strEMail, out strSite, out strObs);
			return(strImportador != "");
		}

		private bool bShowDialogFaturaCotacaoImportador()
		{
			System.Windows.Forms.ImageList imBandeiras = null;
			mdlImportador.clsImportador obj = new mdlImportador.clsImportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref imBandeiras);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Produtos
		protected void vInsertItemFaturaCotacaoProdutos(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoProdutos);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoProdutos);
		}

		private bool bPreenchidoFaturaCotacaoProdutos()
		{
			System.Windows.Forms.ImageList imBandeiras = null;
			mdlProdutosLancamento.clsLancamentoProdutos obj = new mdlProdutosLancamento.clsLancamentoProdutosFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref imBandeiras,m_nIdExportador,m_strCodigo);
			return(obj.HasProducts);
		}

		private bool bShowDialogFaturaCotacaoProdutos()
		{
			System.Windows.Forms.ImageList imBandeiras = null;
			mdlProdutosLancamento.clsLancamentoProdutos obj = new mdlProdutosLancamento.clsLancamentoProdutosFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref imBandeiras,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Pesos
		protected void vInsertItemFaturaCotacaoPesos(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoPesos);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoPesos);
		}

		private bool bPreenchidoFaturaCotacaoPesos()
		{
			mdlPesos.clsPesos obj = new mdlPesos.clsPesosFaturasCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			double dPesoLiquido,dPesoBruto;
			string strUnidadePesoLiquido,strUnidadePesoBruto;
			obj.retornaValores(out dPesoLiquido,out dPesoBruto,out strUnidadePesoLiquido,out strUnidadePesoBruto);
			return((dPesoLiquido > 0) || (dPesoBruto > 0));
		}

		private bool bShowDialogFaturaCotacaoPesos()
		{
			mdlPesos.clsPesos obj = new mdlPesos.clsPesosFaturasCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Numero da Ordem Compra
		protected void vInsertItemFaturaCotacaoNumeroOrdemCompra(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoNumeroOrdemCompra);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoNumeroOrdemCompra);
		}

		private bool bPreenchidoFaturaCotacaoNumeroOrdemCompra()
		{
			mdlNumeroOrdemCompra.clsNumeroOrdemCompra obj = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			string strNumeroOrdemCompra;
			obj.retornaValores(out strNumeroOrdemCompra);
			return(strNumeroOrdemCompra != "");
		}

		private bool bShowDialogFaturaCotacaoNumeroOrdemCompra()
		{
			mdlNumeroOrdemCompra.clsNumeroOrdemCompra obj = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Incoterms
		protected void vInsertItemFaturaCotacaoIncoterms(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoIncoterms);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoIncoterms);
		}

		private bool bPreenchidoFaturaCotacaoIncoterms()
		{
			mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			return(obj.Incoterm != "");
		}

		private bool bShowDialogFaturaCotacaoIncoterms()
		{
			mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Condicoes de Pagamento
		protected void vInsertItemFaturaCotacaoCondicoesPagamento(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoCondicoesPagamento);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoCondicoesPagamento);
		}

		private bool bPreenchidoFaturaCotacaoCondicoesPagamento()
		{
			System.Windows.Forms.ImageList ilBandeiras = null;
			mdlEsquemaPagamento.clsEsquemaPagamento obj = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strCodigo);
			string strEsquemaPagamento;
			obj.retornaValores(out strEsquemaPagamento);
			return(strEsquemaPagamento != "");
		}	

		private bool bShowDialogFaturaCotacaoCondicoesPagamento()
		{
			System.Windows.Forms.ImageList ilBandeiras = null;
			mdlEsquemaPagamento.clsEsquemaPagamento obj = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Banco do Importador
		protected void vInsertItemFaturaCotacaoBancoImportador(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoBancoImportador);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoBancoImportador);
		}

		private bool bPreenchidoFaturaCotacaoBancoImportador()
		{
			mdlBancos.clsBancoImportador obj = new mdlBancos.BancoImportador.clsBancoImportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			string strBanco;
			obj.retornaValores(out strBanco);
			return(strBanco != "");
		}

		private bool bShowDialogFaturaCotacaoBancoImportador()
		{
			mdlBancos.clsBancoImportador obj = new mdlBancos.BancoImportador.clsBancoImportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Banco do Exportador
		protected void vInsertItemFaturaCotacaoBancoExportador(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoBancoExportador);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoBancoExportador);
		}

		private bool bPreenchidoFaturaCotacaoBancoExportador()
		{
			mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			string strBanco,strAgencia,strConta;
			obj.retornaValores(out strBanco,out strAgencia,out strConta);
			return(strBanco != "");
		}

		private bool bShowDialogFaturaCotacaoBancoExportador()
		{
			mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Observacoes
		protected void vInsertItemFaturaCotacaoObservacoes(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoObservacoes);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoObservacoes);
		}

		private bool bPreenchidoFaturaCotacaoObservacoes()
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Faturas.clsObservacoesFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			return(obj.OBSERVACOES != "");
		}	

		private bool bShowDialogFaturaCotacaoObservacoes()
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Faturas.clsObservacoesFaturaCotacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Assinatura
		protected void vInsertItemFaturaCotacaoAssinatura(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoAssinatura);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoAssinatura);
		}

		private bool bPreenchidoFaturaCotacaoAssinatura()
		{
			mdlAssinatura.clsAssinatura obj = new mdlAssinatura.clsAssinaturaCotacao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
			string strAssinatura;
			obj.retornaValores(out strAssinatura);
			return(strAssinatura != "");
		}

		private bool bShowDialogFaturaCotacaoAssinatura()
		{
			mdlAssinatura.clsAssinatura obj = new mdlAssinatura.clsAssinaturaCotacao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
		#region Numero
		protected void vInsertItemFaturaCotacaoNumero(string strNome)
		{
			clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
			itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaCotacaoNumero);
			itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaCotacaoNumero);
		}

		private bool bPreenchidoFaturaCotacaoNumero()
		{
			mdlNumero.clsNumero obj = new mdlNumero.Faturas.clsNumeroCotacao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
			string strNumero;
			obj.retornaValores(out strNumero);
			return(strNumero != "");
		}

		private bool bShowDialogFaturaCotacaoNumero()
		{
			mdlNumero.clsNumero obj = new mdlNumero.Faturas.clsNumeroCotacao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
			obj.ShowDialog();
			return(obj.m_bModificado);
		}
		#endregion
			
		#endregion
		#region Fatura Comercial
			#region Idioma
				protected void vInsertItemFaturaComercialIdioma(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialIdioma);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialIdioma);
				}

				private bool bPreenchidoFaturaComercialIdioma()
				{
					System.Windows.Forms.ImageList ilBandeiras = null;
					mdlIdioma.clsIdioma obj = new mdlIdioma.clsIdiomaFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref ilBandeiras);
					int nIdioma;
					string strIdioma;
					obj.retornaValores(out nIdioma,out strIdioma);
					return(strIdioma != "");
				}

				private bool bShowDialogFaturaComercialIdioma()
				{
					System.Windows.Forms.ImageList ilBandeiras = null;
					mdlIdioma.clsIdioma obj = new mdlIdioma.clsIdiomaFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref ilBandeiras);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Moeda
				protected void vInsertItemFaturaComercialMoeda(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialMoeda);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialMoeda);
				}

				private bool bPreenchidoFaturaComercialMoeda()
				{
					mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.HasValue);
				}

				private bool bShowDialogFaturaComercialMoeda()
				{
					mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Importador
				protected void vInsertItemFaturaComercialImportador(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialImportador);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialImportador);
				}

				private bool bPreenchidoFaturaComercialImportador()
				{
					System.Windows.Forms.ImageList imBandeiras = null;
					mdlImportador.clsImportador obj = new mdlImportador.clsImportadorComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref imBandeiras);
					int nIdImportador;
					string strImportador, strEndereco, strCidade, strEstado, strPais, strTelefone, strFax, strEMail, strSite, strObs;
					obj.retornaValores(out nIdImportador, out strImportador, out strEndereco, out strCidade, out strEstado, out strPais, out strTelefone, out strFax, out strEMail, out strSite, out strObs);
					return(strImportador != "");
				}

				private bool bShowDialogFaturaComercialImportador()
				{
					System.Windows.Forms.ImageList imBandeiras = null;
					mdlImportador.clsImportador obj = new mdlImportador.clsImportadorComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref imBandeiras);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Produtos
				protected void vInsertItemFaturaComercialProdutos(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialProdutos);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialProdutos);
				}

				private bool bPreenchidoFaturaComercialProdutos()
				{
					System.Windows.Forms.ImageList imBandeiras = null;
					mdlProdutosLancamento.clsLancamentoProdutos obj = new mdlProdutosLancamento.clsLancamentoProdutosFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref imBandeiras,m_nIdExportador,m_strCodigo);
					return(obj.HasProducts);
				}

				private bool bShowDialogFaturaComercialProdutos()
				{
					System.Windows.Forms.ImageList imBandeiras = null;
					mdlProdutosLancamento.clsLancamentoProdutos obj = new mdlProdutosLancamento.clsLancamentoProdutosFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref imBandeiras,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Pesos
				protected void vInsertItemFaturaComercialPesos(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialPesos);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialPesos);
				}

				private bool bPreenchidoFaturaComercialPesos()
				{
					mdlPesos.clsPesos obj = new mdlPesos.clsPesosFaturasComercias(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					double dPesoLiquido,dPesoBruto;
					string strUnidadePesoLiquido,strUnidadePesoBruto;
					obj.retornaValores(out dPesoLiquido,out dPesoBruto,out strUnidadePesoLiquido,out strUnidadePesoBruto);
					return((dPesoLiquido > 0) || (dPesoBruto > 0));
				}

				private bool bShowDialogFaturaComercialPesos()
				{
					mdlPesos.clsPesos obj = new mdlPesos.clsPesosFaturasComercias(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Numero da Ordem Compra
				protected void vInsertItemFaturaComercialNumeroOrdemCompra(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialNumeroOrdemCompra);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialNumeroOrdemCompra);
				}

				private bool bPreenchidoFaturaComercialNumeroOrdemCompra()
				{
					mdlNumeroOrdemCompra.clsNumeroOrdemCompra obj = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					string strNumeroOrdemCompra;
					obj.retornaValores(out strNumeroOrdemCompra);
					return(strNumeroOrdemCompra != "");
				}

				private bool bShowDialogFaturaComercialNumeroOrdemCompra()
				{
					mdlNumeroOrdemCompra.clsNumeroOrdemCompra obj = new mdlNumeroOrdemCompra.clsNumeroOrdemCompraComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Incoterms
				protected void vInsertItemFaturaComercialIncoterms(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialIncoterms);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialIncoterms);
				}

				private bool bPreenchidoFaturaComercialIncoterms()
				{
					mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.Incoterm != "");
				}

				private bool bShowDialogFaturaComercialIncoterms()
				{
					mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Condicoes de Pagamento
				protected void vInsertItemFaturaComercialCondicoesPagamento(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialCondicoesPagamento);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialCondicoesPagamento);
				}

				private bool bPreenchidoFaturaComercialCondicoesPagamento()
				{
					System.Windows.Forms.ImageList ilBandeiras = null;
					mdlEsquemaPagamento.clsEsquemaPagamento obj = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strCodigo);
					string strEsquemaPagamento;
					obj.retornaValores(out strEsquemaPagamento);
					return(strEsquemaPagamento != "");
				}	

				private bool bShowDialogFaturaComercialCondicoesPagamento()
				{
					System.Windows.Forms.ImageList ilBandeiras = null;
					mdlEsquemaPagamento.clsEsquemaPagamento obj = new mdlEsquemaPagamento.clsEsquemaPagamentoFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,ref ilBandeiras,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Banco do Importador
				protected void vInsertItemFaturaComercialBancoImportador(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialBancoImportador);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialBancoImportador);
				}

				private bool bPreenchidoFaturaComercialBancoImportador()
				{
					mdlBancos.clsBancoImportador obj = new mdlBancos.BancoImportador.clsBancoImportadorComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					string strBanco;
					obj.retornaValores(out strBanco);
					return(strBanco != "");
				}

				private bool bShowDialogFaturaComercialBancoImportador()
				{
					mdlBancos.clsBancoImportador obj = new mdlBancos.BancoImportador.clsBancoImportadorComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Banco do Exportador
				protected void vInsertItemFaturaComercialBancoExportador(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialBancoExportador);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialBancoExportador);
				}

				private bool bPreenchidoFaturaComercialBancoExportador()
				{
					mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorBordero(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					string strBanco,strAgencia,strConta;
					obj.retornaValores(out strBanco,out strAgencia,out strConta);
					return(strBanco != "");
				}

				private bool bShowDialogFaturaComercialBancoExportador()
				{
					mdlBancos.clsBancoExportador obj = new mdlBancos.BancoExportador.clsBancoExportadorBordero(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Observacoes
				protected void vInsertItemFaturaComercialObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialObservacoes);
				}

				private bool bPreenchidoFaturaComercialObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Faturas.clsObservacoesFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogFaturaComercialObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Faturas.clsObservacoesFaturaComercial(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Assinatura
				protected void vInsertItemFaturaComercialAssinatura(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialAssinatura);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialAssinatura);
				}

				private bool bPreenchidoFaturaComercialAssinatura()
				{
					mdlAssinatura.clsAssinatura obj = new mdlAssinatura.clsAssinaturaComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strAssinatura;
					obj.retornaValores(out strAssinatura);
					return(strAssinatura != "");
				}

				private bool bShowDialogFaturaComercialAssinatura()
				{
					mdlAssinatura.clsAssinatura obj = new mdlAssinatura.clsAssinaturaComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Numero
				protected void vInsertItemFaturaComercialNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialNumero);
				}

				private bool bPreenchidoFaturaComercialNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Faturas.clsNumeroComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogFaturaComercialNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Faturas.clsNumeroComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion

			#region Data Embarque
				protected void vInsertItemFaturaComercialDataEmbarque(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialDataEmbarque);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialDataEmbarque);
				}

				private bool bPreenchidoFaturaComercialDataEmbarque()
				{
					mdlData.clsData obj = new mdlData.DataEmbarque.Faturas.clsDataEmbarqueComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogFaturaComercialDataEmbarque()
				{
					mdlData.clsData obj = new mdlData.DataEmbarque.Faturas.clsDataEmbarqueComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Locais
				protected void vInsertItemFaturaComercialLocais(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialLocais);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialLocais);
				}

				private bool bPreenchidoFaturaComercialLocais()
				{
					mdlLocais.clsLocais obj = new mdlLocais.clsLocaisFaturaComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strLocalColeta,strLocalDespacho,strLocalEmbarque,strLocalDestino,strLocalEntrega,strPaisDestino;
					obj.retornaValores(out strLocalColeta,out strLocalDespacho,out strLocalEmbarque,out strLocalDestino,out strLocalEntrega,out strPaisDestino);
					return((strLocalColeta != "") || (strLocalDespacho != "") || (strLocalEmbarque != "") ||(strLocalDestino != "") || (strLocalEntrega != ""));
				}	

				private bool bShowDialogFaturaComercialLocais()
				{
					mdlLocais.clsLocais obj = new mdlLocais.clsLocaisFaturaComercial(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.Incoterm = false;
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Local de Unitizacao
				protected void vInsertItemFaturaComercialLocalUnitizacao(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialLocalUnitizacao);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialLocalUnitizacao);
				}

				private bool bPreenchidoFaturaComercialLocalUnitizacao()
				{
					mdlLocais.clsLocalOva obj = new mdlLocais.clsLocalOva(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strLocal;
					obj.vRetornaValores(out strLocal);
					return(strLocal != "");
				}	

				private bool bShowDialogFaturaComercialLocalUnitizacao()
				{
					mdlLocais.clsLocalOva obj = new mdlLocais.clsLocalOva(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Nota Fiscal
				protected void vInsertItemFaturaComercialNotaFiscal(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoFaturaComercialNotaFiscal);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogFaturaComercialNotaFiscal);
				}

				private bool bPreenchidoFaturaComercialNotaFiscal()
				{
					mdlNotaFiscal.clsNotaFiscal obj = new mdlNotaFiscal.clsNotaFiscal(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
                    string strNumeros,strEmissoes,strValorTotal;
					obj.retornaValores(out strNumeros,out strEmissoes,out strValorTotal);
					return(strNumeros != "");
				}	

				private bool bShowDialogFaturaComercialNotaFiscal()
				{
					mdlNotaFiscal.clsNotaFiscal obj = new mdlNotaFiscal.clsNotaFiscal(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region Certificados Origem
			#region Mercosul
				#region Numero
				protected void vInsertItemCOMercosulNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulNumero);
				}

				private bool bPreenchidoCOMercosulNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosul(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogCOMercosulNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosul(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
				#region Data 
					protected void vInsertItemCOMercosulData(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulData);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulData);
					}

					private bool bPreenchidoCOMercosulData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosul(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
					}

					private bool bShowDialogCOMercosulData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosul(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Produtos
					protected void vInsertItemCOMercosulProdutos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulProdutos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulProdutos);
					}

					private bool bPreenchidoCOMercosulProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosul(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOMercosulProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosul(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Observacoes
					protected void vInsertItemCOMercosulObservacoes(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulObservacoes);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulObservacoes);
					}

					private bool bPreenchidoCOMercosulObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosul(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						return(obj.OBSERVACOES != "");
					}	

					private bool bShowDialogCOMercosulObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosul(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
			#endregion
			#region Mercosul Bolivia
				#region Numero
					protected void vInsertItemCOMercosulBoliviaNumero(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulBoliviaNumero);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulBoliviaNumero);
					}

					private bool bPreenchidoCOMercosulBoliviaNumero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosulBolivia(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						string strNumero;
						obj.retornaValores(out strNumero);
						return(strNumero != "");
					}

					private bool bShowDialogCOMercosulBoliviaNumero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosulBolivia(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Data 
					protected void vInsertItemCOMercosulBoliviaData(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulBoliviaData);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulBoliviaData);
					}

					private bool bPreenchidoCOMercosulBoliviaData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosulBolivia(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
					}

					private bool bShowDialogCOMercosulBoliviaData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosulBolivia(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Produtos
					protected void vInsertItemCOMercosulBoliviaProdutos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulBoliviaProdutos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulBoliviaProdutos);
					}

					private bool bPreenchidoCOMercosulBoliviaProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulBolivia(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOMercosulBoliviaProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulBolivia(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion

				#region Observacoes
					protected void vInsertItemCOMercosulBoliviaObservacoes(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulBoliviaObservacoes);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulBoliviaObservacoes);
					}

					private bool bPreenchidoCOMercosulBoliviaObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosulBolivia(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						return(obj.OBSERVACOES != "");
					}	

					private bool bShowDialogCOMercosulBoliviaObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosulBolivia(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
			#endregion
			#region Mercosul Chile
				#region Numero
					protected void vInsertItemCOMercosulChileNumero(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulChileNumero);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulChileNumero);
					}

					private bool bPreenchidoCOMercosulChileNumero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosulChile(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						string strNumero;
						obj.retornaValores(out strNumero);
						return(strNumero != "");
					}

					private bool bShowDialogCOMercosulChileNumero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOMercosulChile(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Data 
					protected void vInsertItemCOMercosulChileData(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulChileData);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulChileData);
					}

					private bool bPreenchidoCOMercosulChileData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosulChile(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
					}

					private bool bShowDialogCOMercosulChileData()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOMercosulChile(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Produtos
					protected void vInsertItemCOMercosulChileProdutos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulChileProdutos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulChileProdutos);
					}

					private bool bPreenchidoCOMercosulChileProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulChile(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOMercosulChileProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulChile(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Observacoes
					protected void vInsertItemCOMercosulChileObservacoes(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOMercosulChileObservacoes);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOMercosulChileObservacoes);
					}

					private bool bPreenchidoCOMercosulChileObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosulChile(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						return(obj.OBSERVACOES != "");
					}	

					private bool bShowDialogCOMercosulChileObservacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOMercosulChile(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
			#endregion
			#region Aladi Aptr04
				#region Numero
					protected void vInsertItemCOAladiAptr04Numero(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAptr04Numero);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAptr04Numero);
					}

					private bool bPreenchidoCOAladiAptr04Numero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOAladiAptr04(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						string strNumero;
						obj.retornaValores(out strNumero);
						return(strNumero != "");
					}

					private bool bShowDialogCOAladiAptr04Numero()
					{
						mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOAladiAptr04(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Data 
					protected void vInsertItemCOAladiAptr04Data(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAptr04Data);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAptr04Data);
					}

					private bool bPreenchidoCOAladiAptr04Data()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOAladiAptr04(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
					}

					private bool bShowDialogCOAladiAptr04Data()
					{
						mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOAladiAptr04(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Produtos
					protected void vInsertItemCOAladiAptr04Produtos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAptr04Produtos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAptr04Produtos);
					}

					private bool bPreenchidoCOAladiAptr04Produtos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemAladiAptr04(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOAladiAptr04Produtos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemAladiAptr04(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Observacoes
					protected void vInsertItemCOAladiAptr04Observacoes(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAptr04Observacoes);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAptr04Observacoes);
					}

					private bool bPreenchidoCOAladiAptr04Observacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOAladiAptr04(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						return(obj.OBSERVACOES != "");
					}	

					private bool bShowDialogCOAladiAptr04Observacoes()
					{
						mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOAladiAptr04(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
			#endregion
			#region Aladi Ace39
				#region Numero
				protected void vInsertItemCOAladiAce39Numero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAce39Numero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAce39Numero);
				}

				private bool bPreenchidoCOAladiAce39Numero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOAladiAce39(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogCOAladiAce39Numero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOAladiAce39(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
				#region Data 
				protected void vInsertItemCOAladiAce39Data(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAce39Data);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAce39Data);
				}

				private bool bPreenchidoCOAladiAce39Data()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOAladiAce39(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogCOAladiAce39Data()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOAladiAce39(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
				#region Produtos
					protected void vInsertItemCOAladiAce39Produtos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAce39Produtos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAce39Produtos);
					}

					private bool bPreenchidoCOAladiAce39Produtos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce39(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOAladiAce39Produtos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce39(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Observacoes
				protected void vInsertItemCOAladiAce39Observacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOAladiAce39Observacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOAladiAce39Observacoes);
				}

				private bool bPreenchidoCOAladiAce39Observacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOAladiAce39(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogCOAladiAce39Observacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOAladiAce39(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
			#endregion
			#region Comum
				#region Numero
				protected void vInsertItemCOComumNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOComumNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOComumNumero);
				}

				private bool bPreenchidoCOComumNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOComum(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogCOComumNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.CO.clsNumeroCOComum(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
				#region Data 
				protected void vInsertItemCOComumData(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOComumData);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOComumData);
				}

				private bool bPreenchidoCOComumData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOComum(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogCOComumData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.CO.clsDataEmissaoCOComum(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
				#region Produtos
					protected void vInsertItemCOComumProdutos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOComumProdutos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOComumProdutos);
					}

					private bool bPreenchidoCOComumProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemComum(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						return(obj.HasProducts);
					}

					private bool bShowDialogCOComumProdutos()
					{
						System.Windows.Forms.ImageList Bandeiras = mdlIdioma.clsIdioma.Bandeiras();
						mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem obj = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemComum(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo,ref Bandeiras);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Observacoes
				protected void vInsertItemCOComumObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoCOComumObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogCOComumObservacoes);
				}

				private bool bPreenchidoCOComumObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOComum(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogCOComumObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.CO.clsObservacoesCOComum(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
				#endregion
			#endregion
		#endregion
		#region Saque
			#region	Numero
				protected void vInsertItemSaqueNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoSaqueNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogSaqueNumero);
				}

				private bool bPreenchidoSaqueNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Saque.clsSaque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogSaqueNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Saque.clsSaque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region	Data
				protected void vInsertItemSaqueData(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoSaqueData);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogSaqueData);
				}

				private bool bPreenchidoSaqueData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.Saque.clsDataEmissaoSaque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogSaqueData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.Saque.clsDataEmissaoSaque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region	Observações
				protected void vInsertItemSaqueObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoSaqueObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogSaqueObservacoes);
				}

				private bool bPreenchidoSaqueObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Saque.clsObservacoesSaque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogSaqueObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Saque.clsObservacoesSaque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region Romaneio
			#region Numero
				protected void vInsertItemRomaneioNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioNumero);
				}

				private bool bPreenchidoRomaneioNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogRomaneioNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data 
				protected void vInsertItemRomaneioData(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioData);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioData);
				}

				private bool bPreenchidoRomaneioData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.Romaneio.clsDataEmissaoRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogRomaneioData()
				{
					mdlData.clsData obj = new mdlData.DataEmissao.Romaneio.clsDataEmissaoRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Produtos
				#region Produtos 
					protected void vInsertItemRomaneioProdutosProdutos(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioProdutosProdutos);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioProdutosProdutos);
					}

					private bool bPreenchidoRomaneioProdutosProdutos()
					{
						mdlProdutosRomaneio.clsProdutosRomaneio obj = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.HasProducts);
					}

					private bool bShowDialogRomaneioProdutosProdutos()
					{
						mdlProdutosRomaneio.clsProdutosRomaneio obj = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
				#region Simplificado
					protected void vInsertItemRomaneioProdutosSimplificado(string strNome)
					{
						clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
						itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioProdutosSimplificado);
						itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioProdutosSimplificado);
					}

					private bool bPreenchidoRomaneioProdutosSimplificado()
					{
						mdlProdutosRomaneio.clsProdutosRomaneioSimplificado obj = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						return(obj.HasProducts);
					}

					private bool bShowDialogRomaneioProdutosSimplificado()
					{
						mdlProdutosRomaneio.clsProdutosRomaneioSimplificado obj = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
						obj.ShowDialog();
						return(obj.m_bModificado);
					}
				#endregion
			#endregion
			#region Observacoes
				protected void vInsertItemRomaneioObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioObservacoes);
				}

				private bool bPreenchidoRomaneioObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Romaneio.clsObservacoesRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogRomaneioObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Romaneio.clsObservacoesRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Assinatura
				protected void vInsertItemRomaneioAssinatura(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoRomaneioAssinatura);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogRomaneioAssinatura);
				}

				private bool bPreenchidoRomaneioAssinatura()
				{
					mdlAssinatura.clsAssinatura obj = new mdlAssinatura.Romaneio.clsAssinaturaRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					string strAssinatura = "";
					obj.retornaValores(out strAssinatura);
					return(strAssinatura != "");
				}	

				private bool bShowDialogRomaneioAssinatura()
				{
					mdlAssinatura.clsAssinatura obj = new mdlAssinatura.Romaneio.clsAssinaturaRomaneio(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region Ordem Embarque
			#region Numero	
				protected void vInsertItemOrdemEmbarqueNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueNumero);
				}

				private bool bPreenchidoOrdemEmbarqueNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogOrdemEmbarqueNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}

			#endregion
			#region Consignatario
				protected void vInsertItemOrdemEmbarqueConsignatario(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueConsignatario);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueConsignatario);
				}

				private bool bPreenchidoOrdemEmbarqueConsignatario()
				{
					mdlConsignatario.clsConsignatario obj = new mdlConsignatario.clsConsignatario(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strConsignatario,strTemp;
					obj.retornaValores(out strConsignatario,out strTemp,out strTemp,out strTemp,out strTemp);
					return(strConsignatario != "");
				}	

				private bool bShowDialogOrdemEmbarqueConsignatario()
				{
					mdlConsignatario.clsConsignatario obj = new mdlConsignatario.clsConsignatario(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Descricao das Mercadorias
				protected void vInsertItemOrdemEmbarqueDescricaoMercadorias(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueDescricaoMercadorias);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueDescricaoMercadorias);
				}

				private bool bPreenchidoOrdemEmbarqueDescricaoMercadorias()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueDescricaoGeralMercadoria(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogOrdemEmbarqueDescricaoMercadorias()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueDescricaoGeralMercadoria(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Classificacao Tarifaria
				protected void vInsertItemOrdemEmbarqueClassificacaoTarifaria(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueClassificacaoTarifaria);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueClassificacaoTarifaria);
				}

				private bool bPreenchidoOrdemEmbarqueClassificacaoTarifaria()
				{
					mdlProdutosVinculacao.clsClassificacaoTarifaria obj = new mdlProdutosVinculacao.clsClassificacaoTarifaria(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strClassificacaoTarifaria;
					obj.retornaValores(out strClassificacaoTarifaria);
					return(strClassificacaoTarifaria != "");
				}	

				private bool bShowDialogOrdemEmbarqueClassificacaoTarifaria()
				{
					mdlProdutosVinculacao.clsClassificacaoTarifaria obj = new mdlProdutosVinculacao.clsClassificacaoTarifaria(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Despachante
				protected void vInsertItemOrdemEmbarqueDespachante(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueDespachante);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueDespachante);
				}

				private bool bPreenchidoOrdemEmbarqueDespachante()
				{
					mdlDespachante.clsDespachante obj = new mdlDespachante.clsDespachante(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strNome,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueDespachante()
				{
					mdlDespachante.clsDespachante obj = new mdlDespachante.clsDespachante(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Despachante Contato
				protected void vInsertItemOrdemEmbarqueDespachanteContato(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueDespachanteContato);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueDespachanteContato);
				}

				private bool bPreenchidoOrdemEmbarqueDespachanteContato()
				{
					mdlDespachante.clsDespachante obj = new mdlDespachante.clsDespachante(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strNome,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueDespachanteContato()
				{
					mdlDespachante.clsDespachante obj = new mdlDespachante.clsDespachante(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogContatos();
					return(obj.m_bModificado);
				}
			#endregion
			#region Agente Carga
				protected void vInsertItemOrdemEmbarqueAgenteCarga(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueAgenteCarga);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueAgenteCarga);
				}

				private bool bPreenchidoOrdemEmbarqueAgenteCarga()
				{
					mdlAgentes.clsAgenteCarga obj = new mdlAgentes.clsAgenteCarga(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strNome,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueAgenteCarga()
				{
					mdlAgentes.clsAgenteCarga obj = new mdlAgentes.clsAgenteCarga(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Agente Carga Contato
				protected void vInsertItemOrdemEmbarqueAgenteCargaContato(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueAgenteCargaContato);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueAgenteCargaContato);
				}

				private bool bPreenchidoOrdemEmbarqueAgenteCargaContato()
				{
					mdlAgentes.clsAgenteCarga obj = new mdlAgentes.clsAgenteCarga(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strNome,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueAgenteCargaContato()
				{
					mdlAgentes.clsAgenteCarga obj = new mdlAgentes.clsAgenteCarga(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogContatos();
					return(obj.m_bModificado);
				}
			#endregion
			#region Armador
				protected void vInsertItemOrdemEmbarqueArmador(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueArmador);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueArmador);
				}

				private bool bPreenchidoOrdemEmbarqueArmador()
				{
					mdlArmadores.clsArmador obj = new mdlArmadores.clsArmador(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strNome,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueArmador()
				{
					mdlArmadores.clsArmador obj = new mdlArmadores.clsArmador(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Armador Navio
				protected void vInsertItemOrdemEmbarqueArmadorNavio(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueArmadorNavio);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueArmadorNavio);
				}

				private bool bPreenchidoOrdemEmbarqueArmadorNavio()
				{
					mdlArmadores.clsArmador obj = new mdlArmadores.clsArmador(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strNome);
					return(strNome != "");
				}	

				private bool bShowDialogOrdemEmbarqueArmadorNavio()
				{
					mdlArmadores.clsArmador obj = new mdlArmadores.clsArmador(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogNavios();
					return(obj.m_bModificado);
				}
			#endregion
			#region Local Unitizacao
			#endregion
			#region Notificar
				protected void vInsertItemOrdemEmbarqueNotificar(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueNotificar);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueNotificar);
				}

				private bool bPreenchidoOrdemEmbarqueNotificar()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar1(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogOrdemEmbarqueNotificar()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar1(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Notificar 2
				protected void vInsertItemOrdemEmbarqueNotificar2(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueNotificar2);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueNotificar2);
				}

				private bool bPreenchidoOrdemEmbarqueNotificar2()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar2(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogOrdemEmbarqueNotificar2()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueNotificar2(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Chegada Prevista (ETA)
				protected void vInsertItemReservaDataChegadaPrevista(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataChegadaPrevista);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataChegadaPrevista);
				}

				private bool bPreenchidoReservaDataChegadaPrevista()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineChegadaPrevista(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataChegadaPrevista()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineChegadaPrevista(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Deadline Espelho BL (DRAFT)
				protected void vInsertItemReservaDataEspelhoBL(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataEspelhoBL);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataEspelhoBL);
				}

				private bool bPreenchidoReservaDataEspelhoBL()
				{
					mdlData.clsData obj = new mdlData.DeadLines.clsDataEspelho(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataEspelhoBL()
				{
					mdlData.clsData obj = new mdlData.DeadLines.clsDataEspelho(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Fechamento Portão (GATE)
				protected void vInsertItemReservaDataFechamentoPortao(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataFechamentoPortao);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataFechamentoPortao);
				}

				private bool bPreenchidoReservaDataFechamentoPortao()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataFechamentoPortao()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Deadline Limite Liberação RF
				protected void vInsertItemReservaDataLiberacaoRF(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataLiberacaoRF);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataLiberacaoRF);
				}

				private bool bPreenchidoReservaDataLiberacaoRF()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataLiberacaoRF()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Deadline Lista Carga
				protected void vInsertItemReservaDataListaCarga(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataListaCarga);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataListaCarga);
				}

				private bool bPreenchidoReservaDataListaCarga()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataListaCarga()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineFechamentoPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region	Retirada dos Containers Terminal
				protected void vInsertItemReservaDataRetiradaTerminal(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataRetiradaTerminal);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataRetiradaTerminal);
				}

				private bool bPreenchidoReservaDataRetiradaTerminal()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineRetiradaContainersTerminal(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataRetiradaTerminal()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDeadlineRetiradaContainersTerminal(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Data Abertura Portão 
				protected void vInsertItemReservaDataAberturaPortao(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaDataAberturaPortao);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaDataAberturaPortao);
				}

				private bool bPreenchidoReservaDataAberturaPortao()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDataAberturaPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaDataAberturaPortao()
				{
					mdlData.clsData obj = new mdlData.Reserva.clsReservaDataAberturaPortao(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Siscomex
				protected void vInsertItemOrdemEmbarqueSiscomex(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueSiscomex);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueSiscomex);
				}

				private bool bPreenchidoOrdemEmbarqueSiscomex()
				{
					mdlNumero.PEs.clsNumeroSiscomex obj = new mdlNumero.PEs.clsNumeroSiscomex(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strTemp,strRE,strSD,strDSE;
					obj.retornaValores(out strRE,out strTemp,out strSD,out strTemp,out strDSE,out strTemp);
					return((strRE != "") || (strSD != "") || (strDSE != ""));
				}	

				private bool bShowDialogOrdemEmbarqueSiscomex()
				{
					mdlNumero.PEs.clsNumeroSiscomex obj = new mdlNumero.PEs.clsNumeroSiscomex(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Observacoes
				protected void vInsertItemOrdemEmbarqueObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoOrdemEmbarqueObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogOrdemEmbarqueObservacoes);
				}

				private bool bPreenchidoOrdemEmbarqueObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsObservacoesInstrucoesEmbarque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogOrdemEmbarqueObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsObservacoesInstrucoesEmbarque(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region Reserva
			#region Numero
			protected void vInsertItemReservaNumero(string strNome)
			{
				clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
				itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaNumero);
				itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaNumero);
			}

			private bool bPreenchidoReservaNumero()
			{
				mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroReservaEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
				string strNumero;
				obj.retornaValores(out strNumero);
				return(strNumero != "");
			}

			private bool bShowDialogReservaNumero()
			{
				mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroReservaEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
				obj.ShowDialog();
				return(obj.m_bModificado);
			}
		#endregion
			#region Data 
				protected void vInsertItemReservaData(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaData);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaData);
				}

				private bool bPreenchidoReservaData()
				{
					mdlData.clsData obj = new mdlData.DataReserva.clsDataReservaInstrucoesEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.Data != mdlConstantes.clsConstantes.DATANULA);
				}

				private bool bShowDialogReservaData()
				{
					mdlData.clsData obj = new mdlData.DataReserva.clsDataReservaInstrucoesEmbarque(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Containers
				protected void vInsertItemReservaContainers(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoReservaContainers);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogReservaContainers);
				}

				private bool bPreenchidoReservaContainers()
				{
					mdlContainers.clsContainers obj = new mdlContainers.clsContainers(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.nQuantidadeContainers() > 0);
				}

				private bool bShowDialogReservaContainers()
				{
					mdlContainers.clsContainers obj = new mdlContainers.clsContainers(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region GuiaEntrada
			#region Transportadora
				protected void vInsertItemGuiaEntradaTransportadora(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoGuiaEntradaTransportadora);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogGuiaEntradaTransportadora);
				}

				private bool bPreenchidoGuiaEntradaTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strNome,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogGuiaEntradaTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Contato Transportadora
				protected void vInsertItemGuiaEntradaTransportadoraContato(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoGuiaEntradaContatoTransportadora);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogGuiaEntradaContatoTransportadora);
				}

				private bool bPreenchidoGuiaEntradaContatoTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strNome,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogGuiaEntradaContatoTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogContatos();
					return(obj.m_bModificado);
				}
			#endregion
			#region Motorista Transportadora
				protected void vInsertItemGuiaEntradaTransportadoraMotorista(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoGuiaEntradaMotoristaTransportadora);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogGuiaEntradaMotoristaTransportadora);
				}

				private bool bPreenchidoGuiaEntradaMotoristaTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strNome,out strTemp,out strTemp,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogGuiaEntradaMotoristaTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogMotoristas();
					return(obj.m_bModificado);
				}
			#endregion
			#region Motorista Transportadora
				protected void vInsertItemGuiaEntradaTransportadoraVeiculo(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoGuiaEntradaVeiculoTransportadora);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogGuiaEntradaVeiculoTransportadora);
				}

				private bool bPreenchidoGuiaEntradaVeiculoTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNome,strTemp;
					obj.vRetornaValores(out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strNome,out strTemp);
					return(strNome != "");
				}	

				private bool bShowDialogGuiaEntradaVeiculoTransportadora()
				{
					mdlTransportadoras.clsTransportadora obj = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialogVeiculos();
					return(obj.m_bModificado);
				}
			#endregion
			#region Observacoes
				protected void vInsertItemGuiaEntradaObservacoes(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoGuiaEntradaObservacoes);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogGuiaEntradaObservacoes);
				}

				private bool bPreenchidoGuiaEntradaObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.GuiaEntrada.clsGuiaEntradaObservacoes(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					return(obj.OBSERVACOES != "");
				}	

				private bool bShowDialogGuiaEntradaObservacoes()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.GuiaEntrada.clsGuiaEntradaObservacoes(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion
		#region Bordero
			#region Numero
				protected void vInsertItemBorderoNumero(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoBorderoNumero);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogBorderoNumero);
				}

				private bool bPreenchidoBorderoNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strNumero;
					obj.retornaValores(out strNumero);
					return(strNumero != "");
				}

				private bool bShowDialogBorderoNumero()
				{
					mdlNumero.clsNumero obj = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Documentos em anexo
				protected void vInsertItemBorderoDocumentosAnexo(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoBorderoDocumentosAnexo);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogBorderoDocumentosAnexo);
				}

				private bool bPreenchidoBorderoDocumentosAnexo()
				{
					mdlDocumentacao.clsDocumentacao obj = new mdlDocumentacao.clsDocumentacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					string strFaturaComercial,strConhecimentoEmbarque,strSeguro,strCertificadoOrigem,strRomaneio,strCertificadoPeso,strCertificadoAnalise,strSaque,strFitoSanitario; 
					int nQtdeDocOriginaisFC, nQtdeDocCopiasFC, nQtdeDocTotalFC,nQtdeDocOriginaisCE, nQtdeDocCopiasCE, nQtdeDocTotalCE,nQtdeDocOriginaisSG, nQtdeDocCopiasSG, nQtdeDocTotalSG,nQtdeDocOriginaisCO, nQtdeDocCopiasCO, nQtdeDocTotalCO,nQtdeDocOriginaisRM, nQtdeDocCopiasRM, nQtdeDocTotalRM,nQtdeDocOriginaisCP, nQtdeDocCopiasCP, nQtdeDocTotalCP,nQtdeDocOriginaisCA, nQtdeDocCopiasCA, nQtdeDocTotalCA,nQtdeDocOriginaisSQ, nQtdeDocCopiasSQ, nQtdeDocTotalSQ,nQtdeDocOriginaisFS, nQtdeDocCopiasFS, nQtdeDocTotalFS;
					obj.retornaValores(out strFaturaComercial, out nQtdeDocOriginaisFC, out nQtdeDocCopiasFC, out nQtdeDocTotalFC,out strConhecimentoEmbarque, out nQtdeDocOriginaisCE, out nQtdeDocCopiasCE, out nQtdeDocTotalCE,out strSeguro, out nQtdeDocOriginaisSG, out nQtdeDocCopiasSG, out nQtdeDocTotalSG,out strCertificadoOrigem, out nQtdeDocOriginaisCO, out nQtdeDocCopiasCO, out nQtdeDocTotalCO,out strRomaneio, out nQtdeDocOriginaisRM, out nQtdeDocCopiasRM, out nQtdeDocTotalRM,out strCertificadoPeso, out nQtdeDocOriginaisCP, out nQtdeDocCopiasCP, out nQtdeDocTotalCP,out strCertificadoAnalise, out nQtdeDocOriginaisCA, out nQtdeDocCopiasCA, out nQtdeDocTotalCA,out strSaque, out nQtdeDocOriginaisSQ, out nQtdeDocCopiasSQ, out nQtdeDocTotalSQ,out strFitoSanitario, out nQtdeDocOriginaisFS, out nQtdeDocCopiasFS, out nQtdeDocTotalFS);
					return((nQtdeDocTotalFC > 0) || (nQtdeDocTotalCE > 0) || (nQtdeDocTotalSG > 0) || (nQtdeDocTotalCO > 0) || (nQtdeDocTotalRM > 0) || (nQtdeDocTotalCP > 0) || (nQtdeDocTotalCA > 0) || (nQtdeDocTotalSQ > 0) || (nQtdeDocTotalFS > 0));
				}

				private bool bShowDialogBorderoDocumentosAnexo()
				{
					mdlDocumentacao.clsDocumentacao obj = new mdlDocumentacao.clsDocumentacao(ref m_cls_ter_TratadorErro,ref m_cls_dba_ConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Pagamento
				protected void vInsertItemBorderoPagamento(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoBorderoPagamento);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogBorderoPagamento);
				}

				private bool bPreenchidoBorderoPagamento()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Bordero.clsBorderoModalidadePagamento(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					string strAssinatura = "";
					obj.retornaValores(out strAssinatura);
					return(strAssinatura != "");
				}	

				private bool bShowDialogBorderoPagamento()
				{
					mdlObservacoes.clsObservacoes obj = new mdlObservacoes.Bordero.clsBorderoModalidadePagamento(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
			#region Contrato Cambio
				protected void vInsertItemBorderoContratoCambio(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoBorderoContratoCambio);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogBorderoContratoCambio);
				}

				private bool bPreenchidoBorderoContratoCambio()
				{
					mdlProdutosBordero.clsProdutosBordero obj = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					return(obj.HasProducts);
				}	

				private bool bShowDialogBorderoContratoCambio()
				{
					mdlProdutosBordero.clsProdutosBordero obj = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion	
			#region Cobrança
				protected void vInsertItemBorderoCobranca(string strNome)
				{
					clsAssistenteItem itemInserir = this.AdicionaItem(strNome);
					itemInserir.eCallPreenchido += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallPreenchido(bPreenchidoBorderoCobranca);
					itemInserir.eCallShowDialog += new mdlCriacaoDocumentos.Assistentes.clsAssistenteItem.delCallShowDialog(bShowDialogBorderoCobranca);
				}

				private bool bPreenchidoBorderoCobranca()
				{
					mdlBorderoCobranca.clsBorderoCobranca obj = new mdlBorderoCobranca.clsBorderoCobranca(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					mdlBorderoCobranca.ENTREGARDOCUMENTOS enumEntregaDocumentos;
					bool bProtestar;
					int nDiasVencimento;
					obj.retornaValores(out enumEntregaDocumentos,out bProtestar,out nDiasVencimento);
					return(bProtestar);
				}	

				private bool bShowDialogBorderoCobranca()
				{
					mdlBorderoCobranca.clsBorderoCobranca obj = new mdlBorderoCobranca.clsBorderoCobranca(ref m_cls_ter_TratadorErro, ref m_cls_dba_ConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strCodigo);
					obj.ShowDialog();
					return(obj.m_bModificado);
				}
			#endregion
		#endregion

	}
}
