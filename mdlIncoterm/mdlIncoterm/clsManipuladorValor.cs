using System;

namespace mdlIncoterm
{
	#region Enums
		public enum DataSource
		{
			FaturaComercial = 1,
			FaturaCotacao = 2,
			FaturaProforma = 3
		}
	#endregion

	internal class clsProdutoData
	{
		#region Atributes
			private int m_nIdOrdem = -1;
			private double m_dQuantidade = 0;
			private double m_dPrecoUnitario = 0;
		#endregion
		#region Properties
			public int IdOrdem
			{
				get
				{
					return(m_nIdOrdem);
				}
			}

			public double PrecoUnitario
			{
				get
				{
					return(m_dPrecoUnitario);
				}
				set
				{
					m_dPrecoUnitario = value;
				}
			}

			public double Quantidade
			{
				get
				{
					return(m_dQuantidade);
				}
			}
		#endregion
		#region Constructors
			public clsProdutoData(int nIdOrdem,double dQuantidade,double dPrecoUnitario)
			{
				m_nIdOrdem = nIdOrdem;
				m_dQuantidade = dQuantidade;
				m_dPrecoUnitario = dPrecoUnitario;
			} 
		#endregion
		
		#region Clone
			public clsProdutoData Clone()
			{
				return(new clsProdutoData(m_nIdOrdem,m_dQuantidade,m_dPrecoUnitario));
			}
		#endregion
	}

	/// <summary>
	/// Summary description for clsManipuladorValor.
	/// </summary>
	public class clsManipuladorValor
	{
		#region Constants
		private const int MAXDECIMALS = 8;
		#endregion
		#region Atributes
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		private int m_nIdExportador = -1;
		private string m_strPe = "";

		private bool m_bDataLoaded = false;
		private bool m_bFaturaOutput = true;

		private DataSource m_enumDataSource = DataSource.FaturaComercial;

		// Values
		private double m_dFreteInterno = 0;
		private double m_dFreteInternacional = 0;
		private double m_dSeguro = 0;
		private double m_dOutros = 0;
		private double m_dDesconto = 0;
		private double m_dTotalFatura = 0;


		// Condicoes Pagamento
		private double m_dValorAntecipado = 0;

		// Moeda
		private int m_nIdMoeda = 0;

		// Calculos 
		private bool m_bCalculos = true;

		// Rateios
		private bool m_bRatiar = false;
		private bool m_bRatiarDesconto = false;

		private mdlConstantes.Incoterm m_enumIncotermFatura = mdlConstantes.Incoterm.EXW;
		private mdlConstantes.Incoterm m_enumIncotermRetorno = mdlConstantes.Incoterm.EXW;

		// Produtos
		System.Collections.SortedList m_sortLstProdutosFatura = null;
		System.Collections.SortedList m_sortLstProdutosEXW = null;
		System.Collections.SortedList m_sortLstProdutosRetorno = null;
						
		// Typed Data Sets
		mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetFaturasCotacoes = null;
		mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao m_typDatSetProdutosFaturaCotacao = null;

		mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetFaturasProformas = null;
		mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma m_typDatSetProdutosFaturaProforma = null;

		mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetFaturasComerciais = null;
		mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetProdutosFaturaComercial = null;
		#endregion
		#region Properties
		public mdlConstantes.Incoterm IncotermRetorno
		{
			get
			{
				return(m_enumIncotermRetorno);
			}
			set
			{
				m_sortLstProdutosRetorno = null;
				m_enumIncotermRetorno = value;
			}
		}

		public bool FaturaOutput
		{
			get
			{
				return(m_bFaturaOutput);
			}
			set
			{
				m_bFaturaOutput = value;
			}
		}

		public DataSource DataSourceValores
		{
			get
			{
				return(m_enumDataSource);
			}
			set
			{
				m_enumDataSource = value;
			}
		}

		public bool Calculos
		{
			get
			{
				return(m_bCalculos);
			}
			set
			{
				m_bCalculos = value;
			}
		}
		#endregion
		#region Constructors and Destructors
		public clsManipuladorValor(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,int nIdExportador,string strPe)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;

			m_nIdExportador = nIdExportador;
			m_strPe = strPe;
		}
		#endregion

		#region Carregamento Dados
		private bool bCarregaDados()
		{
			bool bRetorno = false;
			m_cls_dba_ConnectionDB.DataPersist = false;
			switch(m_enumDataSource)
			{
				case DataSource.FaturaCotacao:
					if (bCarregaDadosFaturaCotacao())
						bRetorno = bCarregaDadosProdutosFaturaCotacao();
					break;
				case DataSource.FaturaProforma:
					if (bCarregaDadosFaturaProforma())
						bRetorno = bCarregaDadosProdutosFaturaProforma();
					break;
				case DataSource.FaturaComercial:
					if (bCarregaDadosFaturaComercial())
						bRetorno = bCarregaDadosProdutosFaturaComercial();
					break;
			}
			return(bRetorno);
		}
		#region Fatura Cotacao
		private bool bCarregaDadosFaturaCotacao()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idCotacao");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (m_typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFatura = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetFaturasCotacoes.tbFaturasCotacoes.Rows[0];

				// Incoterm
				if (!dtrwFatura.IsidIncotermNull())
					m_enumIncotermFatura =(mdlConstantes.Incoterm)dtrwFatura.idIncoterm;
				// Frete Interno
				if (!dtrwFatura.IsfreteInternoNull())
					m_dFreteInterno = dtrwFatura.freteInterno;
				// Frete Internacional 
				if (!dtrwFatura.IsfreteInternacionalNull())
					m_dFreteInternacional = dtrwFatura.freteInternacional;
				// Seguro
				if (!dtrwFatura.IsseguroNull())
					m_dSeguro = dtrwFatura.seguro;
				// Outros
				if (!dtrwFatura.IsoutrosNull())
					m_dOutros = dtrwFatura.outros;
				// Desconto
				if (!dtrwFatura.IsdDescontoNull())
					m_dDesconto = dtrwFatura.dDesconto;
				// Ratiar
				if (!dtrwFatura.IsratiarDespesasNull())
					m_bRatiar = dtrwFatura.ratiarDespesas;
				// Ratiar Desconto
				if (!dtrwFatura.IsbRatiarDescontoNull())
					m_bRatiarDesconto = dtrwFatura.bRatiarDesconto;
			}
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}

		private bool bCarregaDadosProdutosFaturaCotacao()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idCotacao");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetProdutosFaturaCotacao = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}
		#endregion
		#region Fatura Proforma
		private bool bCarregaDadosFaturaProforma()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idPe");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (m_typDatSetFaturasProformas.tbFaturasProformas.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFatura = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetFaturasProformas.tbFaturasProformas.Rows[0];

				// Incoterm
				if (!dtrwFatura.IsidIncotermNull())
					m_enumIncotermFatura =(mdlConstantes.Incoterm)dtrwFatura.idIncoterm;
				// Frete Interno
				if (!dtrwFatura.IsfreteInternoNull())
					m_dFreteInterno = dtrwFatura.freteInterno;
				// Frete Internacional 
				if (!dtrwFatura.IsfreteInternacionalNull())
					m_dFreteInternacional = dtrwFatura.freteInternacional;
				// Seguro
				if (!dtrwFatura.IsseguroNull())
					m_dSeguro = dtrwFatura.seguro;
				// Outros
				if (!dtrwFatura.IsoutrosNull())
					m_dOutros = dtrwFatura.outros;
				// Desconto
				if (!dtrwFatura.IsdDescontoNull())
					m_dDesconto = dtrwFatura.dDesconto;
				// Ratiar
				if (!dtrwFatura.IsratiarDespesasNull())
					m_bRatiar = dtrwFatura.ratiarDespesas;
				// Ratiar Desconto
				if (!dtrwFatura.IsbRatiarDescontoNull())
					m_bRatiarDesconto = dtrwFatura.bRatiarDesconto;
			}
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}

		private bool bCarregaDadosProdutosFaturaProforma()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idPe");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetProdutosFaturaProforma = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}
		#endregion
		#region Fatura Comercial
		private bool bCarregaDadosFaturaComercial()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			if (m_typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];

				// Incoterm
				if (!dtrwFaturaComercial.IsidIncotermNull())
					m_enumIncotermFatura =(mdlConstantes.Incoterm)dtrwFaturaComercial.idIncoterm;
				// Frete Interno
				if (!dtrwFaturaComercial.IsfreteInternoNull())
					m_dFreteInterno = dtrwFaturaComercial.freteInterno;
				// Frete Internacional 
				if (!dtrwFaturaComercial.IsfreteInternacionalNull())
					m_dFreteInternacional = dtrwFaturaComercial.freteInternacional;
				// Seguro
				if (!dtrwFaturaComercial.IsseguroNull())
					m_dSeguro = dtrwFaturaComercial.seguro;
				// Outros
				if (!dtrwFaturaComercial.IsoutrosNull())
					m_dOutros = dtrwFaturaComercial.outros;
				// Desconto
				if (!dtrwFaturaComercial.IsdDescontoNull())
					m_dDesconto = dtrwFaturaComercial.dDesconto;
				// Ratiar
				if (!dtrwFaturaComercial.IsratiarDespesasNull())
					m_bRatiar = dtrwFaturaComercial.ratiarDespesas;
				// Ratiar Desconto
				if (!dtrwFaturaComercial.IsbRatiarDescontoNull())
					m_bRatiarDesconto = dtrwFaturaComercial.bRatiarDesconto;

				// Valor Antecipado
				if (!dtrwFaturaComercial.IscondAntecipadoNull())
					m_dValorAntecipado = dtrwFaturaComercial.condAntecipado;
				// Moeda 
				if (!dtrwFaturaComercial.IsidMoedaNull())
					m_nIdMoeda = dtrwFaturaComercial.idMoeda;
			}
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}

		private bool bCarregaDadosProdutosFaturaComercial()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);
			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strPe);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro ==  null);
		}
		#endregion
		#endregion

		#region Produtos Fatura
		private bool bCalculaProdutosFatura()
		{
			bool bRetorno = false;
			double dSubTotal = 0,dValorTotalProdutosRestante = 0,dValorTotalProdutos = 0;

			m_sortLstProdutosFatura = new System.Collections.SortedList();
			// Inserindo os Produtos da Fatura com o preco unitario lancado
			switch (m_enumDataSource)
			{
				case DataSource.FaturaCotacao:
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFaturaCotacao in m_typDatSetProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows)
					{
						if ((dtrwProdutoFaturaCotacao.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaCotacao.nIdOrdemProdutoParent != 0))
							continue;
						clsProdutoData clsDataProduto = new clsProdutoData(dtrwProdutoFaturaCotacao.idOrdem,dtrwProdutoFaturaCotacao.dQuantidade,dtrwProdutoFaturaCotacao.dPrecoUnitario);
						dSubTotal = System.Math.Round(dSubTotal + System.Math.Round(dtrwProdutoFaturaCotacao.dPrecoUnitario * dtrwProdutoFaturaCotacao.dQuantidade,2),2);
						m_sortLstProdutosFatura.Add(dtrwProdutoFaturaCotacao.idOrdem,clsDataProduto);
					}
					break;
				case DataSource.FaturaProforma:
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFaturaProforma in m_typDatSetProdutosFaturaProforma.tbProdutosFaturaProforma.Rows)
					{
						if ((dtrwProdutoFaturaProforma.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaProforma.nIdOrdemProdutoParent != 0))
							continue;
						clsProdutoData clsDataProduto = new clsProdutoData(dtrwProdutoFaturaProforma.idOrdem,dtrwProdutoFaturaProforma.dQuantidade,dtrwProdutoFaturaProforma.dPrecoUnitario);
						dSubTotal = System.Math.Round(dSubTotal + System.Math.Round(dtrwProdutoFaturaProforma.dPrecoUnitario * dtrwProdutoFaturaProforma.dQuantidade,2),2);
						m_sortLstProdutosFatura.Add(dtrwProdutoFaturaProforma.idOrdem,clsDataProduto);
					}
					break;
				case DataSource.FaturaComercial:
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial in m_typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
					{
						if ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							continue;
						clsProdutoData clsDataProduto = new clsProdutoData(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial.dQuantidade,dtrwProdutoFaturaComercial.dPrecoUnitario);
						decimal dcSubTotalCurrent = (decimal)System.Math.Round(dtrwProdutoFaturaComercial.dPrecoUnitario * dtrwProdutoFaturaComercial.dQuantidade,2);
						dSubTotal = dSubTotal + System.Math.Round(dtrwProdutoFaturaComercial.dPrecoUnitario * dtrwProdutoFaturaComercial.dQuantidade,2);
						m_sortLstProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem,clsDataProduto);
					}
					break;
			}

			// Total Despesas 
			double dValorTotalDespesas = m_dFreteInterno + m_dFreteInternacional + m_dSeguro + m_dOutros;

			// Rateio
			if (m_bCalculos)
			{
				if (m_bRatiar)
				{
					dValorTotalProdutos = dSubTotal;
					if (m_bRatiarDesconto)
						dValorTotalProdutosRestante = dSubTotal + m_dDesconto;
					else
						dValorTotalProdutosRestante = dSubTotal - m_dDesconto;
					dValorTotalProdutosRestante = dValorTotalProdutosRestante - dValorTotalDespesas;
					if (dValorTotalProdutosRestante < 0)
						dValorTotalProdutosRestante = 0;
					dValorTotalProdutos = dValorTotalProdutosRestante;
					m_dTotalFatura = dValorTotalProdutos + dValorTotalDespesas - m_dDesconto;
				}
				else
				{
					dValorTotalProdutos = dSubTotal;
					if (m_bRatiarDesconto)
						dValorTotalProdutosRestante = dSubTotal - m_dDesconto; 
					else
						dValorTotalProdutosRestante = dSubTotal; 
					m_dTotalFatura = dValorTotalProdutos + dValorTotalDespesas - m_dDesconto;
					dValorTotalProdutos = dValorTotalProdutosRestante;
				}
			}
			else
			{
				dValorTotalProdutos = dSubTotal;
				dValorTotalProdutosRestante = dSubTotal;
				m_dTotalFatura = dValorTotalProdutos;
			}

			// Inserindo os Produtos Principais
			double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
			for(int nCont = 0; nCont < m_sortLstProdutosFatura.Count;nCont++)
			{
				clsProdutoData cls_ProdutoData = (clsProdutoData)m_sortLstProdutosFatura.GetByIndex(nCont);
				if (m_bRatiar || m_bRatiarDesconto) // Com Rateio
				{
					CalculaPrecoUnitario(cls_ProdutoData.PrecoUnitario,out dPrecoUnitarioProduto,cls_ProdutoData.Quantidade,dSubTotal,dValorTotalProdutos,ref dValorTotalProdutosRestante,nCont == (m_sortLstProdutosFatura.Count - 1));
					dSubTotalProduto = (dPrecoUnitarioProduto * cls_ProdutoData.Quantidade);
					cls_ProdutoData.PrecoUnitario = dPrecoUnitarioProduto;
				}
				else
				{	// Sem Rateio
					dPrecoUnitarioProduto = cls_ProdutoData.PrecoUnitario;
					dSubTotalProduto = (dPrecoUnitarioProduto * cls_ProdutoData.Quantidade);
				}
			}
			bRetorno = true;
			return(bRetorno);
		}
		#endregion
		#region Produtos EXW
		private bool bCalculaProdutosExw()
		{
			bool bRetorno = false;
			double dSubTotal = 0;

			m_sortLstProdutosEXW = new System.Collections.SortedList();

			// Copiando os Produtos da Fatura Comercial
			for(int i = 0; i < m_sortLstProdutosFatura.Count;i++)
			{
				clsProdutoData cls_DataProduto = (clsProdutoData)m_sortLstProdutosFatura.GetByIndex(i);
				dSubTotal = System.Math.Round(dSubTotal + System.Math.Round(cls_DataProduto.PrecoUnitario * cls_DataProduto.Quantidade,2),2);
				m_sortLstProdutosEXW.Add(cls_DataProduto.IdOrdem,cls_DataProduto.Clone());
			} 
			return(bRetorno);
		}
		#endregion
		#region Produtos Retorno 
		private bool bCalculaProdutosRetorno()
		{
			bool bRetorno = false;
			double dSubTotal = 0,dValorTotalProdutosRestante = 0,dValorTotalProdutos = 0;

			m_sortLstProdutosRetorno = new System.Collections.SortedList();

			// Copiando os Produtos do EXW
			for(int i = 0; i < m_sortLstProdutosEXW.Count;i++)
			{
				clsProdutoData cls_DataProduto = (clsProdutoData)m_sortLstProdutosEXW.GetByIndex(i);
				dSubTotal = System.Math.Round(dSubTotal + System.Math.Round(cls_DataProduto.PrecoUnitario * cls_DataProduto.Quantidade,2),2);
				m_sortLstProdutosRetorno.Add(cls_DataProduto.IdOrdem,cls_DataProduto.Clone());
			}

			// Calculando o Valor Total
			switch(m_enumIncotermRetorno)
			{
				case mdlConstantes.Incoterm.EXW:
					dValorTotalProdutos = dSubTotal;
					break;
				case mdlConstantes.Incoterm.FCA:
				case mdlConstantes.Incoterm.FAS:
				case mdlConstantes.Incoterm.FOB:
					dValorTotalProdutos = dSubTotal + m_dFreteInterno + m_dOutros;
					break;
				case mdlConstantes.Incoterm.CFR:
				case mdlConstantes.Incoterm.CPT:
					dValorTotalProdutos = dSubTotal + m_dFreteInterno + m_dFreteInternacional;
					break;
				case mdlConstantes.Incoterm.CIF:
				case mdlConstantes.Incoterm.CIP:
					dValorTotalProdutos = dSubTotal + m_dFreteInterno + m_dFreteInternacional + m_dSeguro;
					break;
				case mdlConstantes.Incoterm.DAF:
				case mdlConstantes.Incoterm.DDP:
				case mdlConstantes.Incoterm.DDU:
				case mdlConstantes.Incoterm.DEQ:
				case mdlConstantes.Incoterm.DES:
					dValorTotalProdutos = dSubTotal + m_dFreteInterno + m_dFreteInternacional + m_dSeguro + m_dOutros;
					break;
			}
			if (!m_bRatiarDesconto)
				dValorTotalProdutos = dValorTotalProdutos - m_dDesconto;
			dValorTotalProdutosRestante = dValorTotalProdutos;

			// Inserindo os Produtos Principais
			double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
			for(int nCont = 0; nCont < m_sortLstProdutosRetorno.Count;nCont++)
			{
				clsProdutoData cls_ProdutoData = (clsProdutoData)m_sortLstProdutosRetorno.GetByIndex(nCont);
				CalculaPrecoUnitario(cls_ProdutoData.PrecoUnitario,out dPrecoUnitarioProduto,cls_ProdutoData.Quantidade,dSubTotal,dValorTotalProdutos,ref dValorTotalProdutosRestante,nCont == (m_sortLstProdutosFatura.Count - 1));
				dSubTotalProduto = (dPrecoUnitarioProduto * cls_ProdutoData.Quantidade);
				cls_ProdutoData.PrecoUnitario = dPrecoUnitarioProduto;
			}
				
			return(bRetorno);
		}
		#endregion
		#region Saque
			public double dCarregaValorSaque()
			{
				double dReturn = 0;

				// Loading data
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strPe);
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo ,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetSaques.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaques.tbSaques.Rows[0];
					if ((dtrwSaque.IsdValorNull()) || (dtrwSaque.dValor == 0))
					{
						dReturn = dValorFaturaSemAntecipado();
						dtrwSaque.dValor = dReturn;
						m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaques);
					}else{
						dReturn = dtrwSaque.dValor;
					}
				}
				return(dReturn);
			}

			public bool bSalvaValorSaque(double dValor)
			{
				bool bReturn = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strPe);
				mdlDataBaseAccess.Tabelas.XsdTbSaques typDatSetSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo ,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetSaques.tbSaques.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwSaque = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)typDatSetSaques.tbSaques.Rows[0];
					dtrwSaque.dValor = dValor;
					m_cls_dba_ConnectionDB.SetTbSaques(typDatSetSaques);
					bReturn = (m_cls_dba_ConnectionDB.Erro == null);
				}
				return(bReturn);
			}
		#endregion

		#region Calculo
		private static void CalculaPrecoUnitario(double dPrecoUnitarioInicial,out double dPrecoUnitarioFinal,double dQuantidade, double dValorTotalInicial, double dValorTotalFinal, ref double dSaldoRestante, bool bUltimoProduto)
		{
			double dSubTotalProduto = 0;
			double dPorcentRestante = dSaldoRestante  / dValorTotalFinal;
			double dPorcent = (dPrecoUnitarioInicial * dQuantidade) / dValorTotalInicial;

			if (bUltimoProduto)
				dPorcent = dPorcentRestante;
			else
				dPorcentRestante = dPorcentRestante - dPorcent;

			dPrecoUnitarioFinal = (dValorTotalFinal * dPorcent) / dQuantidade;

			// Trunca o Preco Unitario para no maximo 8 casas apos virgula
			dPrecoUnitarioFinal = dRetornaNumeroFormatado(dPrecoUnitarioFinal,8);

			dSubTotalProduto = dPrecoUnitarioFinal * dQuantidade;

			dSubTotalProduto = dRetornaNumeroFormatado(dSubTotalProduto,2);

			if (bUltimoProduto)
				dSubTotalProduto = dSaldoRestante;

			dPrecoUnitarioFinal = dSubTotalProduto / dQuantidade;

			// Diminuindo o Saldo Restante
			dSaldoRestante = dSaldoRestante - dSubTotalProduto;
		}

		private static double dRetornaNumeroFormatado(double dNumero,int nNumeroCasas)
		{
			double dRetorno = dNumero;
			string strNumero = dRetorno.ToString();                     
			int nPosVirgula = strNumero.IndexOf(",");
			if (nPosVirgula >= 0)
			{
				if ((nPosVirgula+ nNumeroCasas + 1) < strNumero.Length)
					strNumero = strNumero.Substring(0,nPosVirgula+ nNumeroCasas + 1);
				dRetorno = Double.Parse(strNumero);
			}
			return (dRetorno);
		}
		#endregion

		#region Retorno 

		public void vRetornaValores(int nIdOrdemProduto,out double dPrecoUnitario)
		{
			dPrecoUnitario = 0;

			if (!m_bDataLoaded)
				bCarregaDados();

			// Calc Fatura
			if (m_sortLstProdutosFatura == null)
				bCalculaProdutosFatura();
			if (m_bFaturaOutput)
			{
				// Fatura
				if (m_sortLstProdutosFatura.ContainsKey(nIdOrdemProduto))
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosFatura[nIdOrdemProduto];
					dPrecoUnitario = cls_DataProduct.PrecoUnitario;
				}
			}
			else
			{
				// Calc EXW
				if (m_sortLstProdutosEXW == null)
					bCalculaProdutosExw();
				// Calc Retorno
				if (m_sortLstProdutosRetorno == null)
					bCalculaProdutosRetorno();
				// Retorno
				if (m_sortLstProdutosRetorno.ContainsKey(nIdOrdemProduto))
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosRetorno[nIdOrdemProduto];
					dPrecoUnitario = cls_DataProduct.PrecoUnitario;
				}
			}
		}

		public void vRetornaValores(int nIdOrdemProduto,out double dPrecoUnitario,out double dQuantidade)
		{
			dPrecoUnitario = 0;
			dQuantidade = 0;

			if (!m_bDataLoaded)
				bCarregaDados();

			// Calc Fatura
			if (m_sortLstProdutosFatura == null)
				bCalculaProdutosFatura();
			if (m_bFaturaOutput)
			{
				// Fatura
				if (m_sortLstProdutosFatura.ContainsKey(nIdOrdemProduto))
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosFatura[nIdOrdemProduto];
					dPrecoUnitario = cls_DataProduct.PrecoUnitario;
					dQuantidade = cls_DataProduct.Quantidade;
				}
			}
			else
			{
				// Calc EXW
				if (m_sortLstProdutosEXW == null)
					bCalculaProdutosExw();
				// Calc Retorno
				if (m_sortLstProdutosRetorno == null)
					bCalculaProdutosRetorno();
				// Retorno
				if (m_sortLstProdutosRetorno.ContainsKey(nIdOrdemProduto))
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosRetorno[nIdOrdemProduto];
					dPrecoUnitario = cls_DataProduct.PrecoUnitario;
					dQuantidade = cls_DataProduct.Quantidade;
				}
			}
		}


		public void vRetornaValores(out System.Collections.ArrayList arlProdutoOrdem,out System.Collections.ArrayList arlProdutosPrecoUnitario)
		{
			if (!m_bDataLoaded)
				bCarregaDados();
			arlProdutoOrdem = new System.Collections.ArrayList();
			arlProdutosPrecoUnitario = new System.Collections.ArrayList();

			// Calc Fatura
			if (m_sortLstProdutosFatura == null)
				bCalculaProdutosFatura();
			if (m_bFaturaOutput)
			{
				// Fatura
				for(int i = 0; i < m_sortLstProdutosFatura.Count;i++)
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosFatura.GetByIndex(i);
					arlProdutoOrdem.Add(cls_DataProduct.IdOrdem);
					arlProdutosPrecoUnitario.Add(cls_DataProduct.PrecoUnitario);
				}
			}
			else
			{
				// Calc EXW
				if (m_sortLstProdutosEXW == null)
					bCalculaProdutosExw();
				// Calc Retorno
				if (m_sortLstProdutosRetorno == null)
					bCalculaProdutosRetorno();
				// Retorno
				for(int i = 0; i < m_sortLstProdutosRetorno.Count;i++)
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosRetorno.GetByIndex(i);
					arlProdutoOrdem.Add(cls_DataProduct.IdOrdem);
					arlProdutosPrecoUnitario.Add(cls_DataProduct.PrecoUnitario);
				}
			}
		}

		public void vRetornaValores(out System.Collections.ArrayList arlProdutoOrdem,out System.Collections.ArrayList arlProdutosPrecoUnitario,out System.Collections.ArrayList arlProdutosQuantidade)
		{
			if (!m_bDataLoaded)
				bCarregaDados();
			arlProdutoOrdem = new System.Collections.ArrayList();
			arlProdutosPrecoUnitario = new System.Collections.ArrayList();
			arlProdutosQuantidade = new System.Collections.ArrayList();

			// Calc Fatura
			if (m_sortLstProdutosFatura == null)
				bCalculaProdutosFatura();
			if (m_bFaturaOutput)
			{
				// Fatura
				for(int i = 0; i < m_sortLstProdutosFatura.Count;i++)
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosFatura.GetByIndex(i);
					arlProdutoOrdem.Add(cls_DataProduct.IdOrdem);
					arlProdutosPrecoUnitario.Add(cls_DataProduct.PrecoUnitario);
					arlProdutosQuantidade.Add(cls_DataProduct.Quantidade);
				}
			}
			else
			{
				// Calc EXW
				if (m_sortLstProdutosEXW == null)
					bCalculaProdutosExw();
				// Calc Retorno
				if (m_sortLstProdutosRetorno == null)
					bCalculaProdutosRetorno();
				// Retorno
				for(int i = 0; i < m_sortLstProdutosRetorno.Count;i++)
				{
					clsProdutoData cls_DataProduct = (clsProdutoData)m_sortLstProdutosRetorno.GetByIndex(i);
					arlProdutoOrdem.Add(cls_DataProduct.IdOrdem);
					arlProdutosPrecoUnitario.Add(cls_DataProduct.PrecoUnitario);
					arlProdutosQuantidade.Add(cls_DataProduct.Quantidade);
				}
			}
		}

		public void vRetornaValores(out double dValorFatura)
		{
			if (!m_bDataLoaded)
				bCarregaDados();
			// Calc Fatura
			if (m_sortLstProdutosFatura == null)
				bCalculaProdutosFatura();
			// Fatura
			dValorFatura = m_dTotalFatura;
		}

		public void vRetornaValores(out string strValorFatura)
		{
			double dValor = 0;
			vRetornaValores(out dValor);
			strValorFatura = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dValor,true);
		}

		private double dValorFaturaSemAntecipado()
		{
			double dReturn = 0;
			vRetornaValores(out dReturn);
			if (m_dValorAntecipado != 0)
				dReturn = ((1 - (m_dValorAntecipado / 100)) * dReturn);
			return(dReturn);
		}	

		public double dValorFaturaSomenteAntecipado()
		{
			double dReturn = 0;
			if (!m_bDataLoaded)
				bCarregaDados();
			if (m_dValorAntecipado != 0)
			{
				vRetornaValores(out dReturn);
				dReturn = ((m_dValorAntecipado / 100) * dReturn);
			}
			return(dReturn);
		}	
		#endregion
	}
}
