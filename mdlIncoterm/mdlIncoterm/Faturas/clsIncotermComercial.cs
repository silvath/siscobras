using System;

namespace mdlIncoterm.Faturas
{
	/// <summary>
	/// Summary description for clsIncotermComercial.
	/// </summary>
	public class clsIncotermComercial : clsIncoterm
	{
		#region Atributos
		private string m_strIdPE = "";

 		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		#endregion
		#region Construtores & Destrutores
		public clsIncotermComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idPE): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsIncotermComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,int nIdExportador, string idPE, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais): base(ref tratadorErro, ref ConnectionDB, strEnderecoExecutavel, nIdExportador)
		{
			m_strIdPE = idPE;
			m_bLocaisHabilitado = false;
			m_typDatSetTbFaturasComerciais = typDatSetTbFaturasComerciais;
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
				if (m_typDatSetTbFaturasComerciais == null)
                    m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwRowTbMoedas;
				mdlIncoterm.clsManipuladorValor cls_mav_Fatura = new clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
				System.Collections.ArrayList arlProdutoOrdem,arlProdutoPrecoUnitario,arlProdutoQuantidade;
				cls_mav_Fatura.Calculos = false;
				cls_mav_Fatura.vRetornaValores(out arlProdutoOrdem,out arlProdutoPrecoUnitario,out arlProdutoQuantidade);
				for(int i = 0; i < arlProdutoOrdem.Count;i++)
				{
					double dPrecoUnitario = double.Parse(arlProdutoPrecoUnitario[i].ToString());
					double dQuantidade = double.Parse(arlProdutoQuantidade[i].ToString());
					m_nValorTotalProdutos = System.Math.Round(m_nValorTotalProdutos + System.Math.Round(dPrecoUnitario * dQuantidade,2),2);

				}
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwRowTbFaturasComerciais.IsidIdiomaNull())
						m_nIdIdioma = dtrwRowTbFaturasComerciais.idIdioma;
					if (!dtrwRowTbFaturasComerciais.IsidMeioTransporteNull())
						m_nIdMeioTransporte = dtrwRowTbFaturasComerciais.idMeioTransporte;
					if (!dtrwRowTbFaturasComerciais.IsidIncotermNull())
						m_nIdIncoterm = dtrwRowTbFaturasComerciais.idIncoterm;
					if (!dtrwRowTbFaturasComerciais.IsfreteInternoNull())
						m_nFreteInterno = dtrwRowTbFaturasComerciais.freteInterno;
					else
						m_nFreteInterno = 0;
					if (!dtrwRowTbFaturasComerciais.IsfreteInternacionalNull())
						m_nFreteInternacional = dtrwRowTbFaturasComerciais.freteInternacional;
					else
						m_nFreteInternacional = 0;
					if (!dtrwRowTbFaturasComerciais.IsseguroNull())
						m_nSeguro = dtrwRowTbFaturasComerciais.seguro;
					else
						m_nSeguro = 0;
					if (!dtrwRowTbFaturasComerciais.IsoutrosNull())
						m_nOutros = dtrwRowTbFaturasComerciais.outros;
					else
						m_nOutros = 0;
					if (!dtrwRowTbFaturasComerciais.IsoutrosNomeNull())
					{
						m_strOutros = dtrwRowTbFaturasComerciais.outrosNome;
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
					if (!dtrwRowTbFaturasComerciais.IsratiarDespesasNull())
						m_bRatearDespesas = dtrwRowTbFaturasComerciais.ratiarDespesas;
					if (!dtrwRowTbFaturasComerciais.IsidMoedaNull())
						m_nIdMoeda = dtrwRowTbFaturasComerciais.idMoeda;
					if (!dtrwRowTbFaturasComerciais.IsdDescontoNull())
					{
						m_dDescontoValor = dtrwRowTbFaturasComerciais.dDesconto;
						if (m_dDescontoValor > 0)
							m_dDescontoPorcentagem = System.Math.Round(System.Math.Round(m_dDescontoValor / m_nValorTotalProdutos,MAXDECIMALS) * 100,8);
					}
					else
					{
						m_dDescontoPorcentagem = 0;
						m_dDescontoValor = 0;
					}
					if (!dtrwRowTbFaturasComerciais.IsbRatiarDescontoNull())
						m_bRatearDesconto = dtrwRowTbFaturasComerciais.bRatiarDesconto;
					if (!dtrwRowTbFaturasComerciais.IsmstrIncotermNull())
						m_strRetorno = dtrwRowTbFaturasComerciais.mstrIncoterm;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					dtrwRowTbFaturasComerciais.idMeioTransporte = m_nIdMeioTransporte;
					dtrwRowTbFaturasComerciais.idIncoterm = m_nIdIncoterm;
					dtrwRowTbFaturasComerciais.freteInterno = m_nFreteInterno;
					dtrwRowTbFaturasComerciais.freteInternacional = m_nFreteInternacional;
					dtrwRowTbFaturasComerciais.seguro = m_nSeguro;
					dtrwRowTbFaturasComerciais.outros = m_nOutros;
					dtrwRowTbFaturasComerciais.outrosNome = m_strOutros;
					dtrwRowTbFaturasComerciais.ratiarDespesas = m_bRatearDespesas;
					dtrwRowTbFaturasComerciais.dDesconto = m_dDescontoValor;
					dtrwRowTbFaturasComerciais.bRatiarDesconto = m_bRatearDesconto;
					dtrwRowTbFaturasComerciais.mstrIncoterm = m_strRetorno;
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
				{
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.GetChanges() != null)
					{
						mdlProdutosBordero.clsProdutosBordero cls_prod_bordero = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
						cls_prod_bordero.bRemoveTodosVinculosComContratosCambio();
					}
					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
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

		#region Cria Locais Especifico
		protected override void criaLocaisEspecifico()
		{
			try
			{
				m_clsLocais = new mdlLocais.clsLocaisFaturaComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE, ref m_typDatSetTbFaturasComerciais);
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
				m_typDatSetTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais)m_clsLocais.retornaTypDatSet();
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					#region Switch
					dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					switch (m_nIdIncoterm)
					{
						case EXW: if (!dtrwRowTbFaturasComerciais.IslocalColetaNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localColeta;
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
						case FAS: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
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
						case FOB: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
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
						case FCA: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
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
						case CFR: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case CIF: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case CPT: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case CIP: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case DES: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case DEQ: if (!dtrwRowTbFaturasComerciais.IslocalDestinoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDestino;
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
						case DAF: if (!dtrwRowTbFaturasComerciais.IslocalDespachoNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localDespacho;
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
						case DDU: if (!dtrwRowTbFaturasComerciais.IslocalEntregaNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localEntrega;
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
						case DDP: if (!dtrwRowTbFaturasComerciais.IslocalEntregaNull())
								  {
									  strLocal = dtrwRowTbFaturasComerciais.localEntrega;
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
			return (Object)m_typDatSetTbFaturasComerciais;
		}
		#endregion
	}
}
