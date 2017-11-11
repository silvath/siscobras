using System;

namespace mdlAgentes
{
	/// <summary>
	/// Summary description for clsAgentesVenda.
	/// </summary>
	public class clsAgentesVenda
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		public enum FORMAPAGAMENTOCOMISSAO { REMETER = 1, GRAFICA = 2, FATURA = 3 };

		public bool m_bModificado = false;
		private bool m_bCadastroAgenteModificado = false;
		private bool m_bCadastroBancoModificado = false;

		private bool m_bCadastroNovoAgente = false;
		private bool m_bCadastroNovoBanco = false;

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected int m_nIdAgente = -1;
		protected int m_nIdBanco = -1;
		protected int m_nIdPaisAgente = -1;
		protected int m_nIPaisBanco = -1;

		protected decimal m_dcValorSubTotalCDesconto = 0;
		protected decimal m_dcValorComissao = 0;
		protected decimal m_dcValorComissaoPorcentagem = 0;
		protected FORMAPAGAMENTOCOMISSAO m_enumForma = FORMAPAGAMENTOCOMISSAO.REMETER;
		protected string m_strMoeda = "";
		protected int m_nIdMoeda = 28;

		protected string m_strAgente = "";
		protected string m_strSite = "";
		protected string m_strEmail = "";
		protected string m_strEndereco = "";
		protected string m_strCidade = "";
		protected string m_strPais = "";
		protected string m_strNomeBANCO = "";
		protected string m_strEnderecoBANCO = "";
		protected string m_strCidadeBANCO = "";
		protected string m_strPaisBANCO = "";
		protected string m_strInstPagBANCO = "";

		private Frames.frmFListaAgentes m_formFListaAgentes = null;
		private Frames.frmFListaContatos m_formFListaContatos = null;
		private Frames.frmFCadastroAgentesVendas m_formFCadastroAgentesVendas = null;
		private Frames.frmFCadastroAgentesVendasBancos m_formFCadastroAgentesVendasBancos = null;
		private Frames.frmFAgenteVendaComissao m_formFAgenteVendaComissao = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPEs = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas m_typDatSetTbExportadoresAgentesVendas = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos m_typDatSetTbExportadoresAgentesVendasBancos = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos m_typDatSetTbExportadoresAgentesVendasBancosTemporario = null;
		#endregion
		#region Construtores e Destrutores
		public clsAgentesVenda(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBDBorderos();
			carregaDadosComissao();
		}
		public clsAgentesVenda(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE, int nIdAgente)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdAgente = nIdAgente;
			m_nIdBanco = 0;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsAgentesVenda(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE, int nIdAgente, int nIdBanco)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdAgente = nIdAgente;
			m_nIdBanco = nIdBanco;
			carregaTypDatSet();
			carregaDadosBDCompleto();
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("strNome");

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbExportadoresAgentesVendas = m_cls_dba_ConnectionDB.GetTbExportadoresAgentesVendas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_typDatSetTbExportadoresAgentesVendasBancos = m_cls_dba_ConnectionDB.GetTbExportadoresAgentesVendasBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoValor,arlOrdenacaoTipo);

				arlOrdenacaoTipo.Clear();
				arlOrdenacaoValor.Clear();
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("nmPais");

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbPEs = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlIncoterm.clsIncoterm obj = new mdlIncoterm.Faturas.clsIncotermComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
				string strNull;
				double dNull;
				bool bNull;
				double dValorSubTotalCDesconto = 0;
				obj.retornaValores(out strNull, out dNull, out dNull, out bNull, out dValorSubTotalCDesconto, out dNull, out dNull, out dNull, out strNull, out dNull, out dNull, out bNull, out strNull);
				m_dcValorSubTotalCDesconto = (decimal)dValorSubTotalCDesconto;
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		private void carregaDadosBD()
		{
			try
			{
				if (m_typDatSetTbExportadoresAgentesVendas != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentesVendas != null)
					{
						if (!dtrwTbExportadoresAgentesVendas.IsstrNomeNull())
							m_strAgente = dtrwTbExportadoresAgentesVendas.strNome;
						else
							m_strAgente = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrEmailNull())
							m_strEmail = dtrwTbExportadoresAgentesVendas.strEmail;
						else
							m_strEmail = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrSiteNull())
							m_strSite = dtrwTbExportadoresAgentesVendas.strSite;
						else
							m_strSite = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrEnderecoNull())
							m_strEndereco = dtrwTbExportadoresAgentesVendas.strEndereco;
						else
							m_strEndereco = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrCidadeNull())
							m_strCidade = dtrwTbExportadoresAgentesVendas.strCidade;
						else
							m_strCidade = "";
						if (!dtrwTbExportadoresAgentesVendas.IsnIdPaisNull())
							m_nIdPaisAgente = dtrwTbExportadoresAgentesVendas.nIdPais;
						else
							m_nIdPaisAgente = -1;
						if (m_nIdPaisAgente != -1)
						{
							m_strPais = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPaisAgente).nmPais;
						}
						if (m_typDatSetTbExportadoresAgentesVendasBancos != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, 0);
							if (dtrwTbExportadoresAgentesVendasBancos != null)
							{
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
									m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
								else
									m_strNomeBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
									m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
								else
									m_strEnderecoBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
									m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
								else
									m_strCidadeBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
									m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
								else
									m_nIPaisBanco = -1;
								if (m_nIPaisBanco != -1)
								{
									m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
								}
							}
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
		private void carregaDadosBDCompleto()
		{
			try
			{
				if (m_typDatSetTbExportadoresAgentesVendas != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentesVendas != null)
					{
						if (!dtrwTbExportadoresAgentesVendas.IsstrNomeNull())
							m_strAgente = dtrwTbExportadoresAgentesVendas.strNome;
						else
							m_strAgente = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrEmailNull())
							m_strEmail = dtrwTbExportadoresAgentesVendas.strEmail;
						else
							m_strEmail = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrSiteNull())
							m_strSite = dtrwTbExportadoresAgentesVendas.strSite;
						else
							m_strSite = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrEnderecoNull())
							m_strEndereco = dtrwTbExportadoresAgentesVendas.strEndereco;
						else
							m_strEndereco = "";
						if (!dtrwTbExportadoresAgentesVendas.IsstrCidadeNull())
							m_strCidade = dtrwTbExportadoresAgentesVendas.strCidade;
						else
							m_strCidade = "";
						if (!dtrwTbExportadoresAgentesVendas.IsnIdPaisNull())
							m_nIdPaisAgente = dtrwTbExportadoresAgentesVendas.nIdPais;
						else
							m_nIdPaisAgente = -1;
						if (m_nIdPaisAgente != -1)
						{
							m_strPais = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPaisAgente).nmPais;
						}
						if (m_typDatSetTbExportadoresAgentesVendasBancos != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, m_nIdBanco);
							if (dtrwTbExportadoresAgentesVendasBancos != null)
							{
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
									m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
								else
									m_strNomeBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
									m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
								else
									m_strEnderecoBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
									m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
								else
									m_strCidadeBANCO = "";
								if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
									m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
								else
									m_nIPaisBanco = -1;
								if (m_nIPaisBanco != -1)
								{
									m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
								}
							}
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
		private void carregaDadosBDBorderos()
		{
			try
			{
				if ((m_typDatSetTbPEs != null) && (m_typDatSetTbPEs.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
					if (dtrwTbPes != null)
					{
						if (!dtrwTbPes.IsnIdAgenteVendaNull())
							m_nIdAgente = dtrwTbPes.nIdAgenteVenda;
						else
							m_nIdAgente = -1;
						if (!dtrwTbPes.IsnIdAgenteVendaBancoNull())
							m_nIdBanco = dtrwTbPes.nIdAgenteVendaBanco;
						else
							m_nIdBanco = -1;
						if (m_typDatSetTbExportadoresAgentesVendas != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
							if (dtrwTbExportadoresAgentesVendas != null)
							{
								if (!dtrwTbExportadoresAgentesVendas.IsstrNomeNull())
									m_strAgente = dtrwTbExportadoresAgentesVendas.strNome;
								else
									m_strAgente = "";
								if (!dtrwTbExportadoresAgentesVendas.IsstrEmailNull())
									m_strEmail = dtrwTbExportadoresAgentesVendas.strEmail;
								else
									m_strEmail = "";
								if (!dtrwTbExportadoresAgentesVendas.IsstrSiteNull())
									m_strSite = dtrwTbExportadoresAgentesVendas.strSite;
								else
									m_strSite = "";
								if (!dtrwTbExportadoresAgentesVendas.IsstrEnderecoNull())
									m_strEndereco = dtrwTbExportadoresAgentesVendas.strEndereco;
								else
									m_strEndereco = "";
								if (!dtrwTbExportadoresAgentesVendas.IsstrCidadeNull())
									m_strCidade = dtrwTbExportadoresAgentesVendas.strCidade;
								else
									m_strCidade = "";
								if (!dtrwTbExportadoresAgentesVendas.IsnIdPaisNull())
									m_nIdPaisAgente = dtrwTbExportadoresAgentesVendas.nIdPais;
								else
									m_nIdPaisAgente = -1;
								if ((m_nIdPaisAgente != -1) && (m_typDatSetTbPaises != null) && ((m_typDatSetTbPaises.tbPaises.Rows.Count > 0)))
								{
									m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
									m_strPais = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPaisAgente).nmPais;
									m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
								}
								if (m_typDatSetTbExportadoresAgentesVendasBancos != null)
								{
									mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, m_nIdBanco);
									if (dtrwTbExportadoresAgentesVendasBancos != null)
									{
										if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
											m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
										else
											m_strNomeBANCO = "";
										if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
											m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
										else
											m_strEnderecoBANCO = "";
										if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
											m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
										else
											m_strCidadeBANCO = "";
										if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
											m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
										else
											m_nIPaisBanco = -1;
										if (m_nIPaisBanco != -1)
										{
											m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
										}
										if (!dtrwTbExportadoresAgentesVendasBancos.IsmstrInstrucaoPagamentoNull())
											m_strInstPagBANCO = dtrwTbExportadoresAgentesVendasBancos.mstrInstrucaoPagamento;
										else
											m_strInstPagBANCO = "";
									}
								}
							}
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
		#endregion
		#endregion
		#region Salvamento dos Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				if (m_bModificado)
				{
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentesVendas(m_typDatSetTbExportadoresAgentesVendas);
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentesVendasBancos(m_typDatSetTbExportadoresAgentesVendasBancos);
					salvaDadosBDEspecificos(true);
				}
				else if (m_bCadastroBancoModificado)
				{
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentesVendasBancos(m_typDatSetTbExportadoresAgentesVendasBancos);
					salvaDadosBDEspecificos(false);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDEspecificos(bool bSalvaAgente)
		{
			try
			{
				if ((m_typDatSetTbPEs != null) && (m_typDatSetTbPEs.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
					if (dtrwTbPes != null)
					{
						if (bSalvaAgente)
							dtrwTbPes.nIdAgenteVenda = m_nIdAgente;
						dtrwTbPes.nIdAgenteVendaBanco = m_nIdBanco;
						m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPEs);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Listagem Agentes
		#region InitializeEventsFormListaAgentes
		private void InitializeEventsFormListaAgentes()
		{
			// Carrega Dados Interface
			m_formFListaAgentes.eCallCarregaDadosInterface += new Frames.frmFListaAgentes.delCallCarregaDadosInterface(carregaDadosInterfaceListaAgentes);

			// Salva Dados Interface
			m_formFListaAgentes.eCallSalvaDadosInterface += new Frames.frmFListaAgentes.delCallSalvaDadosInterface(salvaDadosInterfaceListagemAgentes);

			// Salva Dados BD
			m_formFListaAgentes.eCallSalvaDadosBD += new Frames.frmFListaAgentes.delCallSalvaDadosBD(salvaDadosBD);

			// Edita Agente
			m_formFListaAgentes.eCallEditaAgente += new Frames.frmFListaAgentes.delCallEditaAgente(editaAgente);

			// Cadastra Agente
			m_formFListaAgentes.eCallCadastraAgente += new Frames.frmFListaAgentes.delCallCadastraAgente(cadastraAgente);

			// Exclui Agente
			m_formFListaAgentes.eCallExcluiAgente += new Frames.frmFListaAgentes.delCallExcluiAgente(excluiAgente);

			// Lista Contatos
			m_formFListaAgentes.eCallListaContatos += new Frames.frmFListaAgentes.delCallListaContatos(listaBancos);
		}
		#endregion
		#region Show Dialog Listagem Agentes
		public void ShowDialog()
		{
			try
			{
				m_formFListaAgentes = new Frames.frmFListaAgentes(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormListaAgentes();
				m_formFListaAgentes.ShowDialog();
				m_formFListaAgentes = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceListaAgentes(ref mdlComponentesGraficos.ListView lvAgentes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btContatos, out string strCaption)
		{
			strCaption = "Agentes de Vendas";
			btContatos.ImageIndex = 1;
			try
			{
				if (m_typDatSetTbExportadoresAgentesVendas != null)
				{
					lvAgentes.Items.Clear();
					System.Windows.Forms.ListViewItem lvItemAgente;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas in m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.Rows)
					{
						if ((dtrwTbExportadoresAgentesVendas.RowState != System.Data.DataRowState.Deleted) && (!dtrwTbExportadoresAgentesVendas.IsstrNomeNull()))
						{
							lvItemAgente = lvAgentes.Items.Add(dtrwTbExportadoresAgentesVendas.strNome);
							lvItemAgente.Tag = dtrwTbExportadoresAgentesVendas.nIdAgente;
							if (m_nIdAgente == (int)lvItemAgente.Tag)
							{
								lvItemAgente.Selected = true;
								if (!dtrwTbExportadoresAgentesVendas.IsstrSiteNull())
									m_strSite = dtrwTbExportadoresAgentesVendas.strSite;
								else
									m_strSite = "";
								dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, 0);
								if (dtrwTbExportadoresAgentesVendasBancos != null)
								{
									if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
										m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
									else
										m_strNomeBANCO = "";
									if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
										m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
									else
										m_strEnderecoBANCO = "";
									if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
										m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
									else
										m_strCidadeBANCO = "";
									if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
										m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
									else
										m_nIPaisBanco = -1;
									if (m_nIPaisBanco != -1)
										m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
								}
								else
								{
									m_strNomeBANCO = "";
									m_strEnderecoBANCO = "";
									m_strCidadeBANCO = "";
									m_nIPaisBanco = -1;
									m_strPaisBANCO = "";
								}
							}
						}
					}
				}
				if (lvAgentes.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
					btContatos.Enabled = false;
				}
				else
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
					btContatos.Enabled = true;
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
		private void salvaDadosInterfaceListagemAgentes(ref mdlComponentesGraficos.ListView lvAgentes)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrTbExportadoresAgentesVendas;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos;
				if (lvAgentes.SelectedItems.Count > 0)
				{
					m_nIdAgente = (int)lvAgentes.SelectedItems[0].Tag;
					m_strAgente = lvAgentes.SelectedItems[0].Text;
					dtrTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (!dtrTbExportadoresAgentesVendas.IsstrSiteNull())
						m_strSite = dtrTbExportadoresAgentesVendas.strSite;
					else
						m_strSite = "";
					if (!dtrTbExportadoresAgentesVendas.IsstrEmailNull())
						m_strEmail = dtrTbExportadoresAgentesVendas.strEmail;
					else
						m_strEmail = "";
					if (!dtrTbExportadoresAgentesVendas.IsstrEnderecoNull())
						m_strEndereco = dtrTbExportadoresAgentesVendas.strEndereco;
					else
						m_strEndereco = "";
					if (!dtrTbExportadoresAgentesVendas.IsstrCidadeNull())
						m_strCidade = dtrTbExportadoresAgentesVendas.strCidade;
					else
						m_strCidade = "";
					if (!dtrTbExportadoresAgentesVendas.IsnIdPaisNull())
						m_nIdPaisAgente = dtrTbExportadoresAgentesVendas.nIdPais;
					else
						m_nIdPaisAgente = -1;
					if (m_nIdPaisAgente != -1)
						m_strPais = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPaisAgente).nmPais;
					else
						m_strPais = "";
					if (m_nIdBanco == -1)
						m_nIdBanco = 1;
					dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, m_nIdBanco);
					if (dtrwTbExportadoresAgentesVendasBancos != null)
					{
						if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
							m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
						else
							m_strNomeBANCO = "";
						if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
							m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
						else
							m_strEnderecoBANCO = "";
						if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
							m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
						else
							m_strCidadeBANCO = "";
						if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
							m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
						else
							m_nIPaisBanco = -1;
						if (m_nIPaisBanco != -1)
							m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
						else
							m_strPaisBANCO = "";
					}
					else
					{
						m_nIdBanco = 1;
						dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, m_nIdBanco);
						if (dtrwTbExportadoresAgentesVendasBancos != null)
						{
							if (!dtrwTbExportadoresAgentesVendasBancos.IsstrNomeNull())
								m_strNomeBANCO = dtrwTbExportadoresAgentesVendasBancos.strNome;
							else
								m_strNomeBANCO = "";
							if (!dtrwTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
								m_strEnderecoBANCO = dtrwTbExportadoresAgentesVendasBancos.strEndereco;
							else
								m_strEnderecoBANCO = "";
							if (!dtrwTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
								m_strCidadeBANCO = dtrwTbExportadoresAgentesVendasBancos.strCidade;
							else
								m_strCidadeBANCO = "";
							if (!dtrwTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
								m_nIPaisBanco = dtrwTbExportadoresAgentesVendasBancos.nIdPais;
							else
								m_nIPaisBanco = -1;
							if (m_nIPaisBanco != -1)
								m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
							else
								m_strPaisBANCO = "";
						}
						else
						{
							m_strNomeBANCO = "";
							m_strEnderecoBANCO = "";
							m_strCidadeBANCO = "";
							m_nIPaisBanco = -1;
							m_strPaisBANCO = "";
						}
					}
				}
				else
				{
					m_nIdAgente = -1;
					m_strAgente = "";
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
		#region Edita Agente
		private void editaAgente()
		{
			try
			{
				ShowDialogCadastroAgentes(false);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Agente
		private void cadastraAgente()
		{
			try
			{
				ShowDialogCadastroAgentes(true);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Exclui Agente
		private void excluiAgente(ref mdlComponentesGraficos.ListView lvAgentes)
		{
			try
			{
				if (System.Windows.Forms.MessageBox.Show("Deseja excluir este(s) " + lvAgentes.SelectedItems.Count + " agente(s) de vendas?", "Siscobras.NET", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					m_bCadastroAgenteModificado = true;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas;
					foreach(System.Windows.Forms.ListViewItem lvItemAgente in lvAgentes.SelectedItems)
					{
						dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador,(int)lvItemAgente.Tag);
						if (dtrwTbExportadoresAgentesVendas != null)
							dtrwTbExportadoresAgentesVendas.Delete();
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Listagem de Bancos
		private void listaBancos()
		{
			ShowDialogListagemBancos();
		}
		#endregion
		#endregion

		#region Cadastro Agentes
		#region Show Dialog Cadastro Agentes
		private void ShowDialogCadastroAgentes(bool bCadastroNovo)
		{
			try
			{
				m_bCadastroNovoAgente = bCadastroNovo;
				m_formFCadastroAgentesVendas = new Frames.frmFCadastroAgentesVendas(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, bCadastroNovo);
				InitializeEventsFormCadastroAgentes();
				if (bCadastroNovo)
					m_formFCadastroAgentesVendas.setTextoGroupBox("Cadastro");
				else
					m_formFCadastroAgentesVendas.setTextoGroupBox("Edição");
				m_formFCadastroAgentesVendas.ShowDialog();
				m_formFCadastroAgentesVendas = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region InitializeEventsFormCadastroAgentes
		private void InitializeEventsFormCadastroAgentes()
		{
			// Carrega dados Interface
			m_formFCadastroAgentesVendas.eCallCarregaDadosInterface += new Frames.frmFCadastroAgentesVendas.delCallCarregaDadosInterface(carregaDadosInterfaceCadastroAgentes);

			// Salva Dados Interface
			m_formFCadastroAgentesVendas.eCallSalvaDadosInterface += new Frames.frmFCadastroAgentesVendas.delCallSalvaDadosInterface(salvaDadosInterfaceCadastroAgencias);

			// Salva Dados BD
			m_formFCadastroAgentesVendas.eCallSalvaDadosBD += new Frames.frmFCadastroAgentesVendas.delCallSalvaDadosBD(salvaDadosBDCadastroAgencias);
		}
		#endregion
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceCadastroAgentes(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPaises, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbSite)
		{
			try
			{
				if (m_bCadastroNovoAgente == false)
				{
					tbNome.Text = m_strAgente;
					tbEndereco.Text = m_strEndereco;
					tbCidade.Text = m_strCidade;
					tbEmail.Text = m_strEmail;
					tbSite.Text = m_strSite;
				}
				else
				{
					tbNome.Text = "";
					tbEndereco.Text = "";
					tbCidade.Text = "";
					tbEmail.Text = "";
					tbSite.Text = "";
				}
				carregaDadosCBPaises(ref cbPaises);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosCBPaises(ref mdlComponentesGraficos.ComboBox cbPaises)
		{
			try
			{
				System.Collections.SortedList srlPaises = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
				{
					srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
				}
				cbPaises.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwTbPaises;
				for(int nCount = 0; nCount < srlPaises.Count; nCount++)
				{
					dtrwTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCount);
					cbPaises.AddItem(dtrwTbPaises.nmPais, dtrwTbPaises.idPais);
					if ((dtrwTbPaises.idPais == m_nIdPaisAgente) && !m_bCadastroNovoAgente)
						cbPaises.SelectItem(dtrwTbPaises.idPais);
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
		private void salvaDadosInterfaceCadastroAgencias(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPaises, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbSite)
		{
			try
			{
				m_strAgente = tbNome.Text;
				m_strEndereco = tbEndereco.Text;
				m_strCidade = tbCidade.Text;
				m_strEmail = tbEmail.Text;
				m_strSite = tbSite.Text;
				salvaDadosCBPaises(ref cbPaises);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosCBPaises(ref mdlComponentesGraficos.ComboBox cbPaises)
		{
			try
			{
				object obj = cbPaises.ReturnObjectSelectedItem();
				if (obj != null)
				{
					m_nIdPaisAgente = (int)obj;
					m_strPais = cbPaises.ReturnItem(m_nIdPaisAgente);
				}else{
					m_nIdPaisAgente = -1;
					m_strPais = "";
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
		private void salvaDadosBDCadastroAgencias(bool bModificado)
		{
			try
			{
				m_bCadastroAgenteModificado = bModificado;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendas.tbExportadoresAgentesVendasRow dtrwTbExportadoresAgentesVendas;
				if (m_bCadastroNovoAgente)
				{
					calculaNovoIdAgente();
					dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.NewtbExportadoresAgentesVendasRow();
					dtrwTbExportadoresAgentesVendas.nIdExportador = m_nIdExportador;
					dtrwTbExportadoresAgentesVendas.nIdAgente = m_nIdAgente;
					dtrwTbExportadoresAgentesVendas.strNome = m_strAgente;
					dtrwTbExportadoresAgentesVendas.strSite = m_strSite;
					dtrwTbExportadoresAgentesVendas.strEndereco = m_strEndereco;
					dtrwTbExportadoresAgentesVendas.strCidade = m_strCidade;
					dtrwTbExportadoresAgentesVendas.strEmail = m_strEmail;
					dtrwTbExportadoresAgentesVendas.nIdPais = m_nIdPaisAgente;

					m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.AddtbExportadoresAgentesVendasRow(dtrwTbExportadoresAgentesVendas);
				}
				else
				{
					dtrwTbExportadoresAgentesVendas = m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentesVendas != null)
					{
						dtrwTbExportadoresAgentesVendas.strNome = m_strAgente;
						dtrwTbExportadoresAgentesVendas.strSite = m_strSite;
						dtrwTbExportadoresAgentesVendas.strEndereco = m_strEndereco;
						dtrwTbExportadoresAgentesVendas.strCidade = m_strCidade;
						dtrwTbExportadoresAgentesVendas.nIdPais = m_nIdPaisAgente;
						dtrwTbExportadoresAgentesVendas.strEmail = m_strEmail;
					}
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
		#region Calcula Novo IdAgente
		private void calculaNovoIdAgente()
		{
			try
			{
				int nIdAgenteTemporario = 1;

				while(m_typDatSetTbExportadoresAgentesVendas.tbExportadoresAgentesVendas.FindBynIdExportadornIdAgente(m_nIdExportador,nIdAgenteTemporario) != null)
					nIdAgenteTemporario++;

				m_nIdAgente = nIdAgenteTemporario;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Listagem Bancos
		#region Show Dialog Listagem Bancos
			/// <summary>
			/// ShowDialogListagemBancos
			/// </summary>
			public void ShowDialogListagemBancos()
			{
				if (m_nIdAgente != -1)
				{
					m_typDatSetTbExportadoresAgentesVendasBancosTemporario = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos)m_typDatSetTbExportadoresAgentesVendasBancos.Copy();
					m_formFListaContatos = new Frames.frmFListaContatos(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					vInitializeEvents(ref m_formFListaContatos);
					m_formFListaContatos.ShowDialog();
					if (m_formFListaContatos.m_bModificado)
					{
						if (m_formFListaAgentes == null)
						{
							salvaDadosBD(false);
							m_bModificado = true;
						}
					}
					m_formFListaContatos = null;
				}else{
					mdlMensagens.clsMensagens.ShowInformation(mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION,"Para escolher o banco do agente de venda você deve primeiro escolher o agente de venda.");
				}
			}

			private void vInitializeEvents(ref Frames.frmFListaContatos formFListaContatos)
			{
				// Carrega Dados BD Bancos
				formFListaContatos.eCallCarregaDadosBDContatos += new Frames.frmFListaContatos.delCallCarregaDadosBDContatos(carregaDadosBDBancos);

				// Carrega Dados Interface
				formFListaContatos.eCallCarregaDadosInterfaceCompleta += new Frames.frmFListaContatos.delCallCarregaDadosInterfaceCompleta(carregaDadosInterfaceListagem);

				// Carrega Dados Contato Interface
				formFListaContatos.eCallCarregaDadosContatoInterface += new Frames.frmFListaContatos.delCallCarregaDadosContatoInterface(carregaDadosBancoInterface);

				// Cancela Salvamento
				formFListaContatos.eCallCancelaSalvamento += new Frames.frmFListaContatos.delCallCancelaSalvamento(cancelaSalvamentoListagemBancos);

				// Salva Dados Lista Bancos
				formFListaContatos.eCallSalvaDadosBD += new Frames.frmFListaContatos.delCallSalvaDadosBD(salvaDadosListagemBancos);

				// Edita Banco
				formFListaContatos.eCallEditaContato += new Frames.frmFListaContatos.delCallEditaContato(editaBanco);

				// Cadastra Banco
				formFListaContatos.eCallCadastraContato += new Frames.frmFListaContatos.delCallCadastraContato(cadastraBanco);

				// Exclui Bancos
				formFListaContatos.eCallExcluiContatos += new Frames.frmFListaContatos.delCallExcluiContatos(excluirBancos);

				// Modifica Visibilidade
				formFListaContatos.eCallModificaVisibilidade += new Frames.frmFListaContatos.delCallModificaVisibilidade(modificaVisibilidade);
			}
		#endregion
		#region Modifica Visibilidade
		private void modificaVisibilidade(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvDados)
		{
			try
			{
				int nPontoVerticalFinal = lvDados.Location.Y + lvDados.Bounds.Height;
				lvDados.Visible = false;
				lvBancos.SetBounds(lvBancos.Location.X, lvBancos.Location.Y, lvBancos.Width, (nPontoVerticalFinal - lvBancos.Location.Y));
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Edita Banco
		private void editaBanco()
		{
			ShowDialogCadastroBancos(false);
		}
		#endregion
		#region Cadastra Banco
		private void cadastraBanco()
		{
			calculaNovoIdBanco();
			ShowDialogCadastroBancos(true);
		}
		#endregion
		#region Excluir Banco
		private void excluirBancos(ref mdlComponentesGraficos.ListView lvBancos)
		{
			try
			{
				if (lvBancos.SelectedItems.Count > 0)
				{
					if ((System.Windows.Forms.MessageBox.Show("Deseja realmente apagar este(s) " + lvBancos.SelectedItems.Count.ToString() + " banco(s)?", "Agentes de Vendas", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos;
						foreach(System.Windows.Forms.ListViewItem lvItemBanco in lvBancos.SelectedItems)
						{
							dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente,(int)lvItemBanco.Tag);
							dtrwTbExportadoresAgentesVendasBancos.Delete();
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
		#endregion
		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaDadosBDBancos(ref mdlComponentesGraficos.ListView lvBancos)
		{
			#region Pesquisa
			if (lvBancos.SelectedItems.Count > 0)
				m_nIdBanco = (int)lvBancos.SelectedItems[0].Tag;
			// Cria a variável para conter o registro corrente
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwRowTbExportadoresAgentesVendasBancos = null;
			if (m_nIdAgente != -1 && m_nIdBanco != -1)
				dtrwRowTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador,m_nIdAgente, m_nIdBanco);
			if (dtrwRowTbExportadoresAgentesVendasBancos != null )
			{
			#endregion

				#region Salvando os items nos atributos de classe
				if (!dtrwRowTbExportadoresAgentesVendasBancos.IsstrNomeNull())
					m_strNomeBANCO = dtrwRowTbExportadoresAgentesVendasBancos.strNome;
				else
					m_strNomeBANCO = "";
				if (!dtrwRowTbExportadoresAgentesVendasBancos.IsstrEnderecoNull())
					m_strEnderecoBANCO = dtrwRowTbExportadoresAgentesVendasBancos.strEndereco;
				else
					m_strEnderecoBANCO = "";
				if (!dtrwRowTbExportadoresAgentesVendasBancos.IsstrCidadeNull())
					m_strCidadeBANCO = dtrwRowTbExportadoresAgentesVendasBancos.strCidade;
				else
					m_strCidadeBANCO = "";
				if (!dtrwRowTbExportadoresAgentesVendasBancos.IsnIdPaisNull())
					m_nIPaisBanco = dtrwRowTbExportadoresAgentesVendasBancos.nIdPais;
				else
					m_nIPaisBanco = -1;
				if (m_nIPaisBanco != -1)
					m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
				if (!dtrwRowTbExportadoresAgentesVendasBancos.IsmstrInstrucaoPagamentoNull())
					m_strInstPagBANCO = dtrwRowTbExportadoresAgentesVendasBancos.mstrInstrucaoPagamento;
				else
					m_strInstPagBANCO = "";
			}
			else
			{
				m_strNomeBANCO = "";
				m_strEnderecoBANCO = "";
				m_strCidadeBANCO = "";
				m_strPaisBANCO = "";
				m_nIPaisBanco = -1;
			}
//			m_strEmailCONTATO = m_strEmail;
//			m_strTelefoneCONTATO = m_strTelefone;
//			m_strFaxCONTATO = m_strFax;
//			m_strNomeContatoCONTATO = m_strNomeContato;
				#endregion
		}
		#endregion
		#region Interface
		private void carregaDadosInterfaceListagem(ref mdlComponentesGraficos.ListView lvBancos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.GroupBox gbFields, out string strCaption)
		{
			strCaption = "Lista de Bancos";
			gbFields.Text = "Bancos do Agente de Vendas";
			try
			{
				// List View Item
				System.Windows.Forms.ListViewItem lvItemBanco;
				// Limpa os Items da List View
				lvBancos.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwRowTbExportadoresAgentesVendasBancos;
				// Preenche os itens da List View
				for (int nCont = 0 ; nCont < m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.Rows.Count ; nCont++)
				{
					dtrwRowTbExportadoresAgentesVendasBancos = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow)m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.Rows[nCont];
					if ((dtrwRowTbExportadoresAgentesVendasBancos.RowState != System.Data.DataRowState.Deleted) && (!dtrwRowTbExportadoresAgentesVendasBancos.IsstrNomeNull()))
					{
						if (dtrwRowTbExportadoresAgentesVendasBancos.nIdAgente == m_nIdAgente)
						{
							lvItemBanco = lvBancos.Items.Add(dtrwRowTbExportadoresAgentesVendasBancos.strNome);
							lvItemBanco.Tag = dtrwRowTbExportadoresAgentesVendasBancos.nIdBanco;
							if ((int)lvItemBanco.Tag == m_nIdBanco)
							{
								lvItemBanco.Selected = true;
							}
						}
					}
				}
				if (lvBancos.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
				} 
				else
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosBancoInterface(ref mdlComponentesGraficos.ListView lvDadosBanco)
		{
			try
			{
				lvDadosBanco.Items.Clear();
				lvDadosBanco.Visible = false;
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
		private void salvaDadosListagemBancos(bool bModificado)
		{
			try
			{
				m_bCadastroBancoModificado = bModificado;
				m_typDatSetTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario;
			}
			catch
			{
			}
		}
		private void cancelaSalvamentoListagemBancos(bool bModificado)
		{
			//this.m_bModificadoLocalizacao = bModificado;
		}
		#endregion
		#endregion

		#region Cadastro Bancos
		#region Show Dialog Cadastro Bancos
			private void ShowDialogCadastroBancos(bool bCadastroNovo)
			{
				try
				{
					m_bCadastroNovoBanco = bCadastroNovo;
					m_formFCadastroAgentesVendasBancos = new Frames.frmFCadastroAgentesVendasBancos(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, bCadastroNovo);
					vInitializeEvents(ref m_formFCadastroAgentesVendasBancos);
					if (bCadastroNovo)
						m_formFCadastroAgentesVendasBancos.setTextoGroupBox("Cadastro");
					else
						m_formFCadastroAgentesVendasBancos.setTextoGroupBox("Edição");
					m_formFCadastroAgentesVendasBancos.ShowDialog();
					m_formFCadastroAgentesVendasBancos = null;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			
			private void vInitializeEvents(ref Frames.frmFCadastroAgentesVendasBancos formFCadastroAgentesVendasBancos)
			{
				// Carrega dados Interface
				m_formFCadastroAgentesVendasBancos.eCallCarregaDadosInterface += new Frames.frmFCadastroAgentesVendasBancos.delCallCarregaDadosInterface(carregaDadosInterfaceCadastroBancos);

				// Salva Dados Interface
				m_formFCadastroAgentesVendasBancos.eCallSalvaDadosInterface += new Frames.frmFCadastroAgentesVendasBancos.delCallSalvaDadosInterface(salvaDadosInterfaceCadastroBancos);

				// Salva Dados BD
				m_formFCadastroAgentesVendasBancos.eCallSalvaDadosBD += new Frames.frmFCadastroAgentesVendasBancos.delCallSalvaDadosBD(salvaDadosBDCadastroBancos);
			}
		#endregion

		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceCadastroBancos(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbInstrPagam)
		{
			try
			{
				if (m_bCadastroNovoBanco == false)
				{
					tbNome.Text = m_strNomeBANCO;
					tbEndereco.Text = m_strEnderecoBANCO;
					tbCidade.Text = m_strCidadeBANCO;
					tbInstrPagam.Text = m_strInstPagBANCO;
				}
				else
				{
					tbNome.Text = "";
					tbEndereco.Text = "";
					tbCidade.Text = "";
					tbInstrPagam.Text = "";
				}
				carregaDadosCBPaisesBancos(ref cbPais);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosCBPaisesBancos(ref mdlComponentesGraficos.ComboBox cbPaises)
		{
			try
			{
				System.Collections.SortedList sortListPaises = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
				{
					sortListPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
				}
				cbPaises.Items.Clear();
				for(int i = 0; i < sortListPaises.Count; i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwPais = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)sortListPaises.GetByIndex(i);
					cbPaises.AddItem(dtrwPais.nmPais, dtrwPais.idPais);
					if ((dtrwPais.idPais == m_nIPaisBanco) && !m_bCadastroNovoBanco)
						cbPaises.SelectItem(dtrwPais.idPais);
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
		private void salvaDadosInterfaceCadastroBancos(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbInstrPagam)
		{
			try
			{
				m_strNomeBANCO = tbNome.Text;
				m_strEnderecoBANCO = tbEndereco.Text;
				m_strCidadeBANCO = tbCidade.Text;
				m_nIPaisBanco = (int)cbPais.ReturnObjectSelectedItem();
				m_strPaisBANCO = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIPaisBanco).nmPais;
				m_strInstPagBANCO = tbInstrPagam.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBDCadastroBancos(bool bModificado)
		{
			try
			{
				m_bCadastroBancoModificado = bModificado;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesVendasBancos.tbExportadoresAgentesVendasBancosRow dtrwTbExportadoresAgentesVendasBancos;
				if (m_bCadastroNovoBanco)
				{
					calculaNovoIdBanco();

					dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.NewtbExportadoresAgentesVendasBancosRow();
					dtrwTbExportadoresAgentesVendasBancos.nIdExportador = m_nIdExportador;
					dtrwTbExportadoresAgentesVendasBancos.nIdAgente = m_nIdAgente;
					dtrwTbExportadoresAgentesVendasBancos.nIdBanco = m_nIdBanco;
					dtrwTbExportadoresAgentesVendasBancos.strNome = m_strNomeBANCO;
					dtrwTbExportadoresAgentesVendasBancos.strEndereco = m_strEnderecoBANCO;
					dtrwTbExportadoresAgentesVendasBancos.strCidade = m_strCidadeBANCO;
					dtrwTbExportadoresAgentesVendasBancos.nIdPais = m_nIPaisBanco;
					dtrwTbExportadoresAgentesVendasBancos.mstrInstrucaoPagamento = m_strInstPagBANCO;

					m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.AddtbExportadoresAgentesVendasBancosRow(dtrwTbExportadoresAgentesVendasBancos);
				}
				else
				{
					dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador, m_nIdAgente, m_nIdBanco);
					if (dtrwTbExportadoresAgentesVendasBancos != null)
					{
						dtrwTbExportadoresAgentesVendasBancos.strNome = m_strNomeBANCO;
						dtrwTbExportadoresAgentesVendasBancos.strEndereco = m_strEnderecoBANCO;
						dtrwTbExportadoresAgentesVendasBancos.strCidade = m_strCidadeBANCO;
						dtrwTbExportadoresAgentesVendasBancos.nIdPais = m_nIPaisBanco;
						dtrwTbExportadoresAgentesVendasBancos.mstrInstrucaoPagamento = m_strInstPagBANCO;
					}
					else
					{
						calculaNovoIdBanco();
						dtrwTbExportadoresAgentesVendasBancos = m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.NewtbExportadoresAgentesVendasBancosRow();
						dtrwTbExportadoresAgentesVendasBancos.nIdExportador = m_nIdExportador;
						dtrwTbExportadoresAgentesVendasBancos.nIdAgente = m_nIdAgente;
						dtrwTbExportadoresAgentesVendasBancos.nIdBanco = m_nIdBanco;
						dtrwTbExportadoresAgentesVendasBancos.strNome = m_strNomeBANCO;
						dtrwTbExportadoresAgentesVendasBancos.strEndereco = m_strEnderecoBANCO;
						dtrwTbExportadoresAgentesVendasBancos.strCidade = m_strCidadeBANCO;
						dtrwTbExportadoresAgentesVendasBancos.nIdPais = m_nIPaisBanco;
						dtrwTbExportadoresAgentesVendasBancos.mstrInstrucaoPagamento = m_strInstPagBANCO;

						m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.AddtbExportadoresAgentesVendasBancosRow(dtrwTbExportadoresAgentesVendasBancos);
					}
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
		#region Calcula Novo IdBanco
		private void calculaNovoIdBanco()
		{
			try
			{
				int nIdBancoTemporario = 1;

				while(m_typDatSetTbExportadoresAgentesVendasBancosTemporario.tbExportadoresAgentesVendasBancos.FindBynIdExportadornIdAgentenIdBanco(m_nIdExportador,m_nIdAgente, nIdBancoTemporario) != null)
					nIdBancoTemporario++;

				m_nIdBanco = nIdBancoTemporario;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Comissão de Vendas
		#region Show Dialog
		private void InitializeEventsFormComissao()
		{
			// Carrega Dados Interface
			m_formFAgenteVendaComissao.eCallCarregaDadosInterface += new Frames.frmFAgenteVendaComissao.delCallCarregaDadosInterface(carregaDadosInterfaceComissao);

			// Altera Porcentagem
			m_formFAgenteVendaComissao.eCallAlteraComissaoPorcentagem += new Frames.frmFAgenteVendaComissao.delCallAlteraComissaoPorcentagem(alteraPorcentagem);

			// Altera Valor Comissão
			m_formFAgenteVendaComissao.eCallAlteraComissaoValor += new Frames.frmFAgenteVendaComissao.delCallAlteraComissaoValor(alteraComissao);

			// Salva Dados Interface
			m_formFAgenteVendaComissao.eCallSalvaDadosInterface += new Frames.frmFAgenteVendaComissao.delCallSalvaDadosInterface(salvaDadosInterfaceComissao);
		}
		public void ShowDialogComissao()
		{
			try
			{
				m_formFAgenteVendaComissao = new Frames.frmFAgenteVendaComissao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormComissao();
				m_formFAgenteVendaComissao.ShowDialog();
				m_formFAgenteVendaComissao = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento dos Dados
		private void carregaDadosComissao()
		{
			try
			{
				string strNull = "";
				bool bTeste = false;
				if ((m_typDatSetTbPEs != null) && (m_typDatSetTbPEs.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
					// Comissao do Agente
					m_dcValorComissao = (dtrwTbPEs.IsdAgenteVendaValorComissaoNull() ? 0 : (decimal)dtrwTbPEs.dAgenteVendaValorComissao);
					m_dcValorComissaoPorcentagem = (dtrwTbPEs.IsdAgenteVendaValorComissaoPorcentagemNull() ? 0 : (decimal)dtrwTbPEs.dAgenteVendaValorComissaoPorcentagem);
                    if ((m_dcValorComissaoPorcentagem != 0) && (m_dcValorComissao == 0))
						m_dcValorComissao = ((decimal)m_dcValorSubTotalCDesconto * m_dcValorComissaoPorcentagem);  
					m_enumForma = (dtrwTbPEs.IsnAgenteVendaFormaPagamentoNull() ? FORMAPAGAMENTOCOMISSAO.REMETER : (FORMAPAGAMENTOCOMISSAO)dtrwTbPEs.nAgenteVendaFormaPagamento);
					mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
					obj.retornaValores(out m_nIdMoeda, out strNull, out m_strMoeda, out bTeste);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosInterfaceComissao(ref bool bPorcentagem,ref mdlComponentesGraficos.TextBox tbPorcentagem, ref System.Windows.Forms.Label lMoeda, ref mdlComponentesGraficos.TextBox tbComissao, ref System.Windows.Forms.RadioButton rbRemeter, ref System.Windows.Forms.RadioButton rbGrafica, ref System.Windows.Forms.RadioButton rbFatura, ref System.Windows.Forms.Label lValorSubTotal)
		{
			try
			{
				bPorcentagem = (m_dcValorComissaoPorcentagem != 0);
				decimal dcPorcentagem = (decimal)((m_dcValorComissao / (m_dcValorSubTotalCDesconto != 0 ? m_dcValorSubTotalCDesconto : 1)) * 100);
				tbPorcentagem.Text = dcPorcentagem.ToString("F");
				tbComissao.Text = m_dcValorComissao.ToString("F");
				lMoeda.Text = m_strMoeda;
				lValorSubTotal.Text = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_dcValorSubTotalCDesconto, true);
				switch(m_enumForma)
				{
					case FORMAPAGAMENTOCOMISSAO.REMETER : rbRemeter.Checked = true;
						break;
					case FORMAPAGAMENTOCOMISSAO.GRAFICA : rbGrafica.Checked = true;
						break;
					case FORMAPAGAMENTOCOMISSAO.FATURA : rbFatura.Checked = true;
						break;
					default: rbRemeter.Checked = true;
						break;
				}

			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Altera Valores
		private void alteraPorcentagem(ref mdlComponentesGraficos.TextBox tbPorcentagem, ref mdlComponentesGraficos.TextBox tbComissao)
		{
			try
			{
				decimal dcPorcentagem = (decimal)((Double.Parse(tbPorcentagem.Text)) / 100);
				m_dcValorComissao = (decimal)(dcPorcentagem * m_dcValorSubTotalCDesconto);
				tbPorcentagem.Text = ((double)(dcPorcentagem * 100)).ToString("F");
				tbComissao.Text = m_dcValorComissao.ToString("F");
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void alteraComissao(ref mdlComponentesGraficos.TextBox tbComissao, ref mdlComponentesGraficos.TextBox tbPorcentagem)
		{
			try
			{
				m_dcValorComissao = decimal.Parse(tbComissao.Text);
				double dPorcentagem = (double)((m_dcValorComissao / m_dcValorSubTotalCDesconto) * 100);
				tbPorcentagem.Text = dPorcentagem.ToString("F");
				tbComissao.Text = m_dcValorComissao.ToString("F");
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Salvamento dos Dados
		private void salvaDadosInterfaceComissao(ref bool bPorcentagem,ref mdlComponentesGraficos.TextBox tbPorcentagem, ref mdlComponentesGraficos.TextBox tbComissao, ref System.Windows.Forms.RadioButton rbRemeter, ref System.Windows.Forms.RadioButton rbGrafica, ref System.Windows.Forms.RadioButton rbFatura)
		{
			try
			{
				if (!bPorcentagem)
				{
					m_dcValorComissao = decimal.Parse(tbComissao.Text);
					m_dcValorComissaoPorcentagem = 0;
				}else{
					m_dcValorComissao = 0;
					m_dcValorComissaoPorcentagem = ((decimal.Parse(tbPorcentagem.Text)) / 100);
				}
				if (rbFatura.Checked)
				{
					m_enumForma = FORMAPAGAMENTOCOMISSAO.FATURA;
				}
				else if (rbGrafica.Checked)
				{
					m_enumForma = FORMAPAGAMENTOCOMISSAO.GRAFICA;
				}
				else
				{
					m_enumForma = FORMAPAGAMENTOCOMISSAO.REMETER;
				}
				salvaDadosBDComissao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDComissao()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPEs.tbPEs.Rows[0];
				dtrwTbPEs.dAgenteVendaValorComissao = (double)m_dcValorComissao;
				dtrwTbPEs.dAgenteVendaValorComissaoPorcentagem = (double)m_dcValorComissaoPorcentagem;
				dtrwTbPEs.nAgenteVendaFormaPagamento = (int)m_enumForma;
				m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPEs);
				this.m_bModificado = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Retorna Valores
		public void retornaValoresAgente(out string strNomeAgente, out string strEnderecoAgente, out string strCidadeAgente, out string strPaisAgente, out string strEmailAgente, out string strSiteContato)
		{
			strNomeAgente = m_strAgente;
			strEnderecoAgente = m_strEndereco;
			strCidadeAgente = m_strCidade;
			strPaisAgente = m_strPais;
			strEmailAgente = m_strEmail;
			strSiteContato = m_strSite;
		}
		public void retornaValoresBancoAgenteVenda(out string strNomeBanco, out string strEnderecoBanco, out string strCidadeBanco, out string strPaisBanco, out string strInstrucoesPagamento)
		{
			strNomeBanco = m_strNomeBANCO;
			strEnderecoBanco = m_strEnderecoBANCO;
			strCidadeBanco = m_strCidadeBANCO;
			strPaisBanco = m_strPaisBANCO;
			strInstrucoesPagamento = m_strInstPagBANCO;
		}
		public void retornaValoresComissao(out double dValorComissao, out string strSimboloMoeda, out string strFormaPagamentoComissao)
		{
			dValorComissao = (double)m_dcValorComissao;
			strSimboloMoeda = m_strMoeda;
			switch(m_enumForma)
			{
				case FORMAPAGAMENTOCOMISSAO.FATURA: strFormaPagamentoComissao = "F";
					break;
				case FORMAPAGAMENTOCOMISSAO.GRAFICA: strFormaPagamentoComissao = "G";
					break;
				case FORMAPAGAMENTOCOMISSAO.REMETER: strFormaPagamentoComissao = "R";
					break;
				default: strFormaPagamentoComissao = "R";
					break;
			}
		}
		#endregion
	}
}
