using System;

namespace mdlIncoterm.Faturas
{
	/// <summary>
	/// Summary description for clsIncotermCotacao.
	/// </summary>
	public class clsIncotermCotacao : clsIncoterm
	{
		#region Atributos
		private string m_strIdCotacao = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		#endregion

		#region Construtores & Destrutores
		public clsIncotermCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idCotacao): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdCotacao = idCotacao;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsIncotermCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idCotacao, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetTbFaturasCotacoes): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdCotacao = idCotacao;
			m_bLocaisHabilitado = false;
			m_typDatSetTbFaturasCotacoes = typDatSetTbFaturasCotacoes;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Retorna Instância clsLocais
		protected override void retornaInstanciaMdlLocais()
		{
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		protected new void carregaTypDatSet()
		{
			try 
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCotacao);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				if (m_typDatSetTbFaturasCotacoes == null)
                    m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				base.carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwRowTbMoedas;
				mdlIncoterm.clsManipuladorValor cls_mav_Fatura = new clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdCotacao);
				System.Collections.ArrayList arlProdutoOrdem,arlProdutoPrecoUnitario,arlProdutoQuantidade;
				cls_mav_Fatura.DataSourceValores = mdlIncoterm.DataSource.FaturaCotacao;
				cls_mav_Fatura.Calculos = false;
				cls_mav_Fatura.vRetornaValores(out arlProdutoOrdem,out arlProdutoPrecoUnitario,out arlProdutoQuantidade);
				for(int i = 0; i < arlProdutoOrdem.Count;i++)
				{
					double dPrecoUnitario = double.Parse(arlProdutoPrecoUnitario[i].ToString());
					double dQuantidade = double.Parse(arlProdutoQuantidade[i].ToString());
					m_nValorTotalProdutos = System.Math.Round(m_nValorTotalProdutos + System.Math.Round(dPrecoUnitario * dQuantidade,2),2);

				}
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IsidIdiomaNull())
						m_nIdIdioma = dtrwRowTbFaturasCotacoes.idIdioma;
					if (!dtrwRowTbFaturasCotacoes.IsidMeioTransporteNull())
						m_nIdMeioTransporte = dtrwRowTbFaturasCotacoes.idMeioTransporte;
					if (!dtrwRowTbFaturasCotacoes.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasCotacoes.idIncoterm;
					if (!dtrwRowTbFaturasCotacoes.IsfreteInternoNull())
						m_nFreteInterno = dtrwRowTbFaturasCotacoes.freteInterno;
					else
						m_nFreteInterno = 0;
					if (!dtrwRowTbFaturasCotacoes.IsfreteInternacionalNull())
						m_nFreteInternacional = dtrwRowTbFaturasCotacoes.freteInternacional;
					else
						m_nFreteInternacional = 0;
					if (!dtrwRowTbFaturasCotacoes.IsseguroNull())
						m_nSeguro = dtrwRowTbFaturasCotacoes.seguro;
					else
						m_nSeguro = 0;
					if (!dtrwRowTbFaturasCotacoes.IsoutrosNull())
						m_nOutros = dtrwRowTbFaturasCotacoes.outros;
					else
						m_nOutros = 0;
					if (!dtrwRowTbFaturasCotacoes.IsoutrosNomeNull())
					{
						m_strOutros = dtrwRowTbFaturasCotacoes.outrosNome;
					}
					else
					{
						if (m_typDatSetTbIdiomasTextos.tbIdiomasTextos.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbIdiomasTextos.tbIdiomasTextosRow dtrwTbIdiomasTextos = m_typDatSetTbIdiomasTextos.tbIdiomasTextos.FindByidTextoidIdioma(m_nIdTextoOutrosCustos, m_nIdIdioma);
							if ((dtrwTbIdiomasTextos != null) && (!dtrwTbIdiomasTextos.IsmstrTextoNull()))
								m_strOutros = dtrwTbIdiomasTextos.mstrTexto;
						}
					}
					if (!dtrwRowTbFaturasCotacoes.IsratiarDespesasNull())
						m_bRatearDespesas = dtrwRowTbFaturasCotacoes.ratiarDespesas;
					if (!dtrwRowTbFaturasCotacoes.IsidMoedaNull())
						m_nIdMoeda = dtrwRowTbFaturasCotacoes.idMoeda;
					if (!dtrwRowTbFaturasCotacoes.IsdDescontoNull())
					{
						m_dDescontoValor = dtrwRowTbFaturasCotacoes.dDesconto;
						if (m_dDescontoValor > 0)
							m_dDescontoPorcentagem = System.Math.Round(System.Math.Round(m_dDescontoValor / m_nValorTotalProdutos,MAXDECIMALS) * 100,MAXDECIMALS);
					}
					else
					{
						m_dDescontoPorcentagem = 0;
						m_dDescontoValor = 0;
					}
					if (!dtrwRowTbFaturasCotacoes.IsbRatiarDescontoNull())
						m_bRatearDesconto = dtrwRowTbFaturasCotacoes.bRatiarDesconto;
					if (!dtrwRowTbFaturasCotacoes.IsmstrIncotermNull())
						m_strRetorno = dtrwRowTbFaturasCotacoes.mstrIncoterm;
					else
						retornaIncoterm();
				}
				if (m_typDatSetTbMoedas.tbMoedas.Rows.Count > 0)
				{
					dtrwRowTbMoedas = m_typDatSetTbMoedas.tbMoedas.FindByidMoeda(m_nIdMoeda);
					if (dtrwRowTbMoedas != null)
						m_strSimboloMoeda = dtrwRowTbMoedas.simbolo;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected override void salvaDadosInterfaceEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwRowTbFaturasCotacoes.idMeioTransporte = m_nIdMeioTransporte;
					dtrwRowTbFaturasCotacoes.idIncoterm = m_nIdIncoterm;
					dtrwRowTbFaturasCotacoes.freteInterno = m_nFreteInterno;
					dtrwRowTbFaturasCotacoes.freteInternacional = m_nFreteInternacional;
					dtrwRowTbFaturasCotacoes.seguro = m_nSeguro;
					dtrwRowTbFaturasCotacoes.outros = m_nOutros;
					dtrwRowTbFaturasCotacoes.outrosNome = m_strOutros;
					dtrwRowTbFaturasCotacoes.ratiarDespesas = m_bRatearDespesas;
					dtrwRowTbFaturasCotacoes.dDesconto = m_dDescontoValor;
					dtrwRowTbFaturasCotacoes.bRatiarDesconto = m_bRatearDesconto;
					dtrwRowTbFaturasCotacoes.mstrIncoterm = m_strRetorno;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected override void salvaDadosBDEspecifico()
		{
			try
			{
				if (m_bLocaisHabilitado)
                    m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Cria Locais Especifico
		protected override void criaLocaisEspecifico()
		{
			try
			{
				m_clsLocais = new mdlLocais.clsLocaisFaturaCotacao(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao, ref m_typDatSetTbFaturasCotacoes);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Atualiza TypDatSet
		protected override void atualizaTypDatSetEspecifico()
		{
			try
			{
				m_typDatSetTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes)m_clsLocais.retornaTypDatSet();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		protected override void retornaIncoterm()
		{
			try
			{
				string strLocal = "";
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasCotacoes.IslocalColetaNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localColeta;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "EXW - " + strLocal;
						break;
						case FAS: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "FAS - " + strLocal;
						break;
						case FOB: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "FOB - " + strLocal;
						break;
						case FCA: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "FCA - " + strLocal;
						break;
						case CFR: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "CFR - " + strLocal;
						break;
						case CIF: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "CIF - " + strLocal;
						break;
						case CPT: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "CPT - " + strLocal;
						break;
						case CIP: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "CIP - " + strLocal;
						break;
						case DES: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "DES - " + strLocal;
						break;
						case DEQ: if (!dtrwRowTbFaturasCotacoes.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDestino;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "DEQ - " + strLocal;
						break;
						case DAF: if (!dtrwRowTbFaturasCotacoes.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localDespacho;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "DAF - " + strLocal;
						break;
						case DDU: if (!dtrwRowTbFaturasCotacoes.IslocalEntregaNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localEntrega;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "DDU - " + strLocal;
						break;
						case DDP: if (!dtrwRowTbFaturasCotacoes.IslocalEntregaNull())
								  {
									  strLocal = dtrwRowTbFaturasCotacoes.localEntrega;
									  if (strLocal.Trim() != "")
										  m_bMostrarLocais = false;
									  else
										  m_bMostrarLocais = true;
								  }
								  else
								  {
									  m_bMostrarLocais = true;
								  }
									m_strRetorno = "DDP - " + strLocal;
						break;
					}
					#endregion
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public override Object retornaTypDatSetEspecifico()
		{
			return (Object)m_typDatSetTbFaturasCotacoes;
		}
		#endregion
	}
}
