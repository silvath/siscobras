using System;

namespace mdlIncoterm.Faturas
{
	/// <summary>
	/// Summary description for clsIncotermProforma.
	/// </summary>
	public class clsIncotermProforma : clsIncoterm
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		#endregion

		#region Construtores & Destrutores
		public clsIncotermProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsIncotermProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idPE, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSeTbFaturasProformas): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			m_bLocaisHabilitado = false;
			m_typDatSetTbFaturasProformas = typDatSeTbFaturasProformas;
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

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				if (m_typDatSetTbFaturasProformas == null)
                    m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwRowTbMoedas;
				mdlIncoterm.clsManipuladorValor cls_mav_Fatura = new clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
				cls_mav_Fatura.DataSourceValores = mdlIncoterm.DataSource.FaturaProforma;
				cls_mav_Fatura.Calculos = false;
				System.Collections.ArrayList arlProdutoOrdem,arlProdutoPrecoUnitario,arlProdutoQuantidade;
				cls_mav_Fatura.vRetornaValores(out arlProdutoOrdem,out arlProdutoPrecoUnitario,out arlProdutoQuantidade);
				for(int i = 0; i < arlProdutoOrdem.Count;i++)
				{
					double dPrecoUnitario = double.Parse(arlProdutoPrecoUnitario[i].ToString());
					double dQuantidade = double.Parse(arlProdutoQuantidade[i].ToString());
					m_nValorTotalProdutos = System.Math.Round(m_nValorTotalProdutos + System.Math.Round(dPrecoUnitario * dQuantidade,2),2);

				}
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					if (!dtrwRowTbFaturasProformas.IsidIdiomaNull())
						m_nIdIdioma = dtrwRowTbFaturasProformas.idIdioma;
					if (!dtrwRowTbFaturasProformas.IsidMeioTransporteNull())
						m_nIdMeioTransporte = dtrwRowTbFaturasProformas.idMeioTransporte;
					if (!dtrwRowTbFaturasProformas.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasProformas.idIncoterm;
					if (!dtrwRowTbFaturasProformas.IsfreteInternoNull())
						m_nFreteInterno = dtrwRowTbFaturasProformas.freteInterno;
					else
						m_nFreteInterno = 0;
					if (!dtrwRowTbFaturasProformas.IsfreteInternacionalNull())
						m_nFreteInternacional = dtrwRowTbFaturasProformas.freteInternacional;
					else
						m_nFreteInternacional = 0;
					if (!dtrwRowTbFaturasProformas.IsseguroNull())
						m_nSeguro = dtrwRowTbFaturasProformas.seguro;
					else
						m_nSeguro = 0;
					if (!dtrwRowTbFaturasProformas.IsoutrosNull())
						m_nOutros = dtrwRowTbFaturasProformas.outros;
					else
						m_nOutros = 0;
					if (!dtrwRowTbFaturasProformas.IsoutrosNomeNull())
					{
						m_strOutros = dtrwRowTbFaturasProformas.outrosNome;
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
					if (!dtrwRowTbFaturasProformas.IsratiarDespesasNull())
						m_bRatearDespesas = dtrwRowTbFaturasProformas.ratiarDespesas;
					if (!dtrwRowTbFaturasProformas.IsidMoedaNull())
						m_nIdMoeda = dtrwRowTbFaturasProformas.idMoeda;
					if (!dtrwRowTbFaturasProformas.IsdDescontoNull())
					{
						m_dDescontoValor = dtrwRowTbFaturasProformas.dDesconto;
						if (m_dDescontoValor > 0)
							m_dDescontoPorcentagem = System.Math.Round(System.Math.Round(m_dDescontoValor / m_nValorTotalProdutos,MAXDECIMALS) * 100,MAXDECIMALS);
					}
					else
					{
						m_dDescontoPorcentagem = 0;
						m_dDescontoValor = 0;
					}
					if (!dtrwRowTbFaturasProformas.IsbRatiarDescontoNull())
						m_bRatearDesconto = dtrwRowTbFaturasProformas.bRatiarDesconto;
					if (!dtrwRowTbFaturasProformas.IsmstrIncotermNull())
						m_strRetorno = dtrwRowTbFaturasProformas.mstrIncoterm;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					dtrwRowTbFaturasProformas.idMeioTransporte = m_nIdMeioTransporte;
					dtrwRowTbFaturasProformas.idIncoterm = m_nIdIncoterm;
					dtrwRowTbFaturasProformas.freteInterno = m_nFreteInterno;
					dtrwRowTbFaturasProformas.freteInternacional = m_nFreteInternacional;
					dtrwRowTbFaturasProformas.seguro = m_nSeguro;
					dtrwRowTbFaturasProformas.outros = m_nOutros;
					dtrwRowTbFaturasProformas.outrosNome = m_strOutros;
					dtrwRowTbFaturasProformas.ratiarDespesas = m_bRatearDespesas;
					dtrwRowTbFaturasProformas.dDesconto = m_dDescontoValor;
					dtrwRowTbFaturasProformas.bRatiarDesconto = m_bRatearDesconto;
					dtrwRowTbFaturasProformas.mstrIncoterm = m_strRetorno;
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
                    m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
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
				m_clsLocais = new mdlLocais.clsLocaisFaturaProforma(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_typDatSetTbFaturasProformas);
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
				m_typDatSetTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas)m_clsLocais.retornaTypDatSet();
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasProformas.IslocalColetaNull())
									  strLocal = dtrwRowTbFaturasProformas.localColeta;
									m_strRetorno = "EXW - " + strLocal;
						break;
						case FAS: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
									m_strRetorno = "FAS - " + strLocal;
						break;
						case FOB: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
									m_strRetorno = "FOB - " + strLocal;
						break;
						case FCA: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
									m_strRetorno = "FCA - " + strLocal;
						break;
						case CFR: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "CFR - " + strLocal;
						break;
						case CIF: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "CIF - " + strLocal;
						break;
						case CPT: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "CPT - " + strLocal;
						break;
						case CIP: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "CIP - " + strLocal;
						break;
						case DES: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "DES - " + strLocal;
						break;
						case DEQ: if (!dtrwRowTbFaturasProformas.IslocalDestinoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDestino;
									m_strRetorno = "DEQ - " + strLocal;
						break;
						case DAF: if (!dtrwRowTbFaturasProformas.IslocalDespachoNull())
									  strLocal = dtrwRowTbFaturasProformas.localDespacho;
									m_strRetorno = "DAF - " + strLocal;
						break;
						case DDU: if (!dtrwRowTbFaturasProformas.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasProformas.localEntrega;
									m_strRetorno = "DDU - " + strLocal;
						break;
						case DDP: if (!dtrwRowTbFaturasProformas.IslocalEntregaNull())
									  strLocal = dtrwRowTbFaturasProformas.localEntrega;
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
			return (Object)m_typDatSetTbFaturasProformas;
		}
		#endregion
	}
}
