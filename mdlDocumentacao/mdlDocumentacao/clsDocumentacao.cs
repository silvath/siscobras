using System;

namespace mdlDocumentacao
{
	/// <summary>
	/// Summary description for clsDocumentacao.
	/// </summary>
	public class clsDocumentacao
	{
		#region Constantes
		private const string TEXTO_NOMES = "Documentos";
		private const string TEXTO_IDENTIFICACAO = "Identificação / Número";
		private const string TEXTO_QUANTIDADE = "Qde Total";
		private const string TEXTO_QUANTIDADEORIGINAIS = "Qde Originais";
		private const string TEXTO_QUANTIDADECOPIAS = "Qde Cópias";
		#endregion
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";

		public bool m_bModificado = false;

		private int m_nNumeroLinhas = 0;

		#region Booleanos
		private bool m_bMostrarFaturaComercial = true;
		private bool m_bMostrarConhecimentoEmbarque = true;
		private bool m_bMostrarSeguro = true;
		private bool m_bMostrarCertificadoOrigem = true;
		private bool m_bMostrarRomaneio = true;
		private bool m_bMostrarCertificadoPeso = true;
		private bool m_bMostrarCertificadoAnalise = true;
		private bool m_bMostrarSaque = true;
		private bool m_bMostrarFitoSanitario = true;
		#endregion

		// Fatura Comercial
		protected string m_strIdFaturaComercial = "";
		protected int m_nQtdeOriginaisEnviadosFC = 0;
		protected int m_nQtdeCopiasEnviadasFC = 0;
		// Conhecimento de Embarque
		protected string m_strIdConhecimentoEmbarque = "";
		protected int m_nQtdeOriginaisEnviadosCE = 0;
		protected int m_nQtdeCopiasEnviadasCE = 0;
		// Seguro
		protected string m_strIdSeguro = "";
		protected int m_nQtdeOriginaisEnviadosSG = 0;
		protected int m_nQtdeCopiasEnviadasSG = 0;
		// Certificado de Origem
		protected string m_strIdCertificadoOrigem = "";
		protected int m_nQtdeOriginaisEnviadosCO = 0;
		protected int m_nQtdeCopiasEnviadasCO = 0;
		// Romaneio
		protected string m_strIdRomaneio = "";
		protected int m_nQtdeOriginaisEnviadosRM = 0;
		protected int m_nQtdeCopiasEnviadasRM = 0;
		// Certificado de Peso
		protected string m_strIdCertificadoPeso = "";
		protected int m_nQtdeOriginaisEnviadosCP = 0;
		protected int m_nQtdeCopiasEnviadasCP = 0;
		// Certificado de Análise
		protected string m_strIdCertificadoAnalise = "";
		protected int m_nQtdeOriginaisEnviadosCA = 0;
		protected int m_nQtdeCopiasEnviadasCA = 0;
		// Saque
		protected string m_strIdSaque = "";
		protected int m_nQtdeOriginaisEnviadosSQ = 0;
		protected int m_nQtdeCopiasEnviadasSQ = 0;
		// Fito Sanitário
		protected string m_strIdFitoSanitario = "";
		protected int m_nQtdeOriginaisEnviadosFS = 0;
		protected int m_nQtdeCopiasEnviadasFS = 0;

		protected bool m_bTesteDuplicidade = false;

		private Frames.frmFQuantidades m_formFQuantidades = null;

		private System.Data.DataTable m_dtTabelaTemporaria = null;
		private System.Windows.Forms.DataGridTableStyle m_dgTbStyleTabelaTemporaria = null;

		// Tabelas Banco de Dados
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaque = null;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem m_typDatSetTbCertificadosOrigem = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA m_typDatSetTbProdutosCertificadoOrigemFormA = null;
		#endregion
		#region Properties
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA TypDatSetTbProdutosCertificadoOrigemFormA
			{
				get
				{
					if (m_typDatSetTbProdutosCertificadoOrigemFormA != null)
						return(m_typDatSetTbProdutosCertificadoOrigemFormA);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);

					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetTbProdutosCertificadoOrigemFormA = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigemFormA(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetTbProdutosCertificadoOrigemFormA);
				}
			}
			

			public bool FATURACOMERCIAL
			{
				set
				{
					m_bMostrarFaturaComercial = value;
				}
			}

			public bool CONHECIMENTOEMBARQUE
			{
				set
				{
					m_bMostrarConhecimentoEmbarque = value;
				}
			}

			public bool SEGURO
			{
				set
				{
					m_bMostrarSeguro = value;
				}
			}

			public bool CERTIFICADOORIGEM
			{
				set
				{
					m_bMostrarCertificadoOrigem = value;
				}
			}

			public bool ROMANEIO
			{
				set
				{
					m_bMostrarRomaneio = value;
				}
			}

			public bool CERTIFICADOPESO
			{
				set
				{
					m_bMostrarCertificadoPeso = value;
				}
			}

			public bool CERTIFICADOANALISE
			{
				set
				{
					m_bMostrarCertificadoAnalise = value;
				}
			}

			public bool SAQUE
			{
				set
				{
					m_bMostrarSaque = value;
				}
			}

			public bool FITOSANITARIO
			{
				set
				{
					m_bMostrarFitoSanitario = value;
				}
			}
		#endregion
		#region Construtores & Destrutores
		public clsDocumentacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string enderecoExecutavel, int idExportador, string strIdCodigo)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdCodigo;
			carregaTypDatSet();
			carregaDadosTabelas();
		}
		#endregion

		#region Carregamento dos Dados
		private void carregaTypDatSet()
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

				m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbSaque = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbCertificadosOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosDataTable()
		{
			try
			{
				if ((m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					System.Data.DataRow dtrwValores;
					for(int nCont = 0 ; nCont < 9;nCont++)
					{
						dtrwValores = m_dtTabelaTemporaria.NewRow();
						switch (nCont)
						{
							case 0: if ((m_bMostrarFaturaComercial) && (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0))
									{
										mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
										dtrwValores[TEXTO_NOMES] = "Fatura Comercial";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbFaturasComerciais.IsnumeroFaturaNull() ? dtrwTbFaturasComerciais.numeroFatura : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopiaFaturaComercialNull() ? dtrwTbBorderos.nQtdeDocCopiaFaturaComercial : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalFaturaComercialNull() ? dtrwTbBorderos.nQtdeDocOriginalFaturaComercial : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
									else
									{
										m_bMostrarFaturaComercial = false;
									}
								break;
							case 1: if ((m_bMostrarRomaneio) && (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0))
									{
										mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
										dtrwValores[TEXTO_NOMES] = "Romaneio";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbRomaneios.IsstrNumeroNull() ? dtrwTbRomaneios.strNumero : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialRomaneioNull() ? dtrwTbBorderos.nQtdeDocCopialRomaneio : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalRomaneioNull() ? dtrwTbBorderos.nQtdeDocOriginalRomaneio : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
									else
									{
										m_bMostrarRomaneio = false;
									}
								break;
							case 2: if ((m_bMostrarSaque) && (m_typDatSetTbSaque.tbSaques.Rows.Count > 0))
									{
										mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaque.tbSaques.Rows[0];
										dtrwValores[TEXTO_NOMES] = "Saque";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbSaques.IsstrNumeroSaqueNull() ? dtrwTbSaques.strNumeroSaque : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialSaqueNull() ? dtrwTbBorderos.nQtdeDocCopialSaque : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalSaqueNull() ? dtrwTbBorderos.nQtdeDocOriginalSaque : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
									else
									{
										m_bMostrarSaque = false;
									}
								break;
							case 3: if ((m_bMostrarCertificadoOrigem) && (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count > 0) && ((m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count > 0) || (this.TypDatSetTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormA.Rows.Count > 0)))
									{
										m_bMostrarCertificadoOrigem = false;
										dtrwValores[TEXTO_NOMES] = "Certificado de Origem";
										dtrwValores[TEXTO_IDENTIFICACAO] = "";
										mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
										for (int nCount = 0; nCount < m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count; nCount++)
										{
											dtrwTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[nCount];
											for (int i = 0; i < m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Count; i++)
											{
												mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem[i];
												if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutoCertificado.idTipoCO == dtrwTbCertificadosOrigem.nIdTipoCO))
												{
													dtrwValores[TEXTO_IDENTIFICACAO] += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
													if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull()))
														dtrwValores[TEXTO_IDENTIFICACAO] += ", ";
													m_bMostrarCertificadoOrigem = true;
													break;
												}
											}
											if (dtrwTbCertificadosOrigem.nIdTipoCO == 30)
											{
												dtrwValores[TEXTO_IDENTIFICACAO] += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
												if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull()))
													dtrwValores[TEXTO_IDENTIFICACAO] += ", ";
												m_bMostrarCertificadoOrigem = true;
											}
										}
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoOrigemNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoOrigem : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoOrigemNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoOrigem : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										if (m_bMostrarCertificadoOrigem)
										{
											m_dtTabelaTemporaria.Rows.Add(dtrwValores);
											m_nNumeroLinhas++;
										}
									}
									else
									{
										m_bMostrarCertificadoOrigem = false;
									}
								break;
							case 4: if (m_bMostrarConhecimentoEmbarque)
									{
										dtrwValores[TEXTO_NOMES] = "Conhecimento de Embarque";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbPes.IsstrIdConhecimentoEmbarqueNull() ? dtrwTbPes.strIdConhecimentoEmbarque : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialConhecimentoEmbarqueNull() ? dtrwTbBorderos.nQtdeDocCopialConhecimentoEmbarque : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalConhecimentoEmbarqueNull() ? dtrwTbBorderos.nQtdeDocOriginalConhecimentoEmbarque : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
								break;
							case 5: if (m_bMostrarSeguro)
									{
										dtrwValores[TEXTO_NOMES] = "Seguro";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbPes.IsstrIdSeguroNull() ? dtrwTbPes.strIdSeguro : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialSeguroNull() ? dtrwTbBorderos.nQtdeDocCopialSeguro : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalSeguroNull() ? dtrwTbBorderos.nQtdeDocOriginalSeguro : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
								break;
							case 6: if (m_bMostrarFitoSanitario)
									{
										dtrwValores[TEXTO_NOMES] = "Fito Sanitário";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbPes.IsstrIdFitossanitarioNull() ? dtrwTbPes.strIdFitossanitario : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialFitoSanitarioNull() ? dtrwTbBorderos.nQtdeDocCopialFitoSanitario : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalFitoSanitarioNull() ? dtrwTbBorderos.nQtdeDocOriginalFitoSanitario : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
								break;
							case 7: if (m_bMostrarCertificadoPeso)
									{
										dtrwValores[TEXTO_NOMES] = "Certificado de Peso";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbPes.IsstrIdCertificadoPesoNull() ? dtrwTbPes.strIdCertificadoPeso : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoPesoNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoPeso : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoPesoNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoPeso : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
								break;
							case 8: if (m_bMostrarCertificadoAnalise)
									{
										dtrwValores[TEXTO_NOMES] = "Certificado de Análise";
										dtrwValores[TEXTO_IDENTIFICACAO] = (!dtrwTbPes.IsstrIdCertificadoAnaliseNull() ? dtrwTbPes.strIdCertificadoAnalise : "");
										dtrwValores[TEXTO_QUANTIDADECOPIAS] = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoAnaliseNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoAnalise : 0);
										dtrwValores[TEXTO_QUANTIDADEORIGINAIS] = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoAnaliseNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoAnalise : 0);
										//dtrwValores[TEXTO_QUANTIDADE] = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS] + (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										m_dtTabelaTemporaria.Rows.Add(dtrwValores);
										m_nNumeroLinhas++;
									}
								break;
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
		private void carregaDadosTabelas()
		{
			try
			{
				if ((m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					for(int nCont = 0 ; nCont < 9;nCont++)
					{
						// Fatura Comercial
						if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
							m_strIdFaturaComercial = (!dtrwTbFaturasComerciais.IsnumeroFaturaNull() ? dtrwTbFaturasComerciais.numeroFatura : "");
							m_nQtdeCopiasEnviadasFC = (!dtrwTbBorderos.IsnQtdeDocCopiaFaturaComercialNull() ? dtrwTbBorderos.nQtdeDocCopiaFaturaComercial : 0);
							m_nQtdeOriginaisEnviadosFC = (!dtrwTbBorderos.IsnQtdeDocOriginalFaturaComercialNull() ? dtrwTbBorderos.nQtdeDocOriginalFaturaComercial : 0);
						}
						// Conhecimento Embarque
						m_strIdConhecimentoEmbarque = (!dtrwTbPes.IsstrIdConhecimentoEmbarqueNull() ? dtrwTbPes.strIdConhecimentoEmbarque : "");
						m_nQtdeCopiasEnviadasCE = (!dtrwTbBorderos.IsnQtdeDocCopialConhecimentoEmbarqueNull() ? dtrwTbBorderos.nQtdeDocCopialConhecimentoEmbarque : 0);
						m_nQtdeOriginaisEnviadosCE = (!dtrwTbBorderos.IsnQtdeDocOriginalConhecimentoEmbarqueNull() ? dtrwTbBorderos.nQtdeDocOriginalConhecimentoEmbarque : 0);
						// Seguro
						m_strIdSeguro = (!dtrwTbPes.IsstrIdSeguroNull() ? dtrwTbPes.strIdSeguro : "");
						m_nQtdeCopiasEnviadasSG = (!dtrwTbBorderos.IsnQtdeDocCopialSeguroNull() ? dtrwTbBorderos.nQtdeDocCopialSeguro : 0);
						m_nQtdeOriginaisEnviadosSG = (!dtrwTbBorderos.IsnQtdeDocOriginalSeguroNull() ? dtrwTbBorderos.nQtdeDocOriginalSeguro : 0);
						//Certificado de Origem
						m_strIdCertificadoOrigem = "";
						mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
						for (int nCount = 0; nCount < m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count; nCount++)
						{
							dtrwTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[nCount];
							for(int i = 0; i <  m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;i++)
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem[i];
								if ((dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutoCertificado.idTipoCO == dtrwTbCertificadosOrigem.nIdTipoCO))
								{
									m_strIdCertificadoOrigem += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
									if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (m_strIdCertificadoOrigem.Trim() != ""))
										m_strIdCertificadoOrigem += ", ";
									break;
								}
							}
							if (dtrwTbCertificadosOrigem.nIdTipoCO == 30)
							{
								m_strIdCertificadoOrigem += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
								if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull()))
									m_strIdCertificadoOrigem += ", ";
							}
						}
						m_nQtdeCopiasEnviadasCO = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoOrigemNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoOrigem : 0);;
						m_nQtdeOriginaisEnviadosCO = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoOrigemNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoOrigem : 0);
						// Romaneio
						if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
							m_strIdRomaneio = (!dtrwTbRomaneios.IsstrNumeroNull() ? dtrwTbRomaneios.strNumero : "");
							m_nQtdeCopiasEnviadasRM = (!dtrwTbBorderos.IsnQtdeDocCopialRomaneioNull() ? dtrwTbBorderos.nQtdeDocCopialRomaneio : 0);
							m_nQtdeOriginaisEnviadosRM = (!dtrwTbBorderos.IsnQtdeDocOriginalRomaneioNull() ? dtrwTbBorderos.nQtdeDocOriginalRomaneio : 0);
						}
						// Certificado de Peso
						m_strIdCertificadoPeso = (!dtrwTbPes.IsstrIdCertificadoPesoNull() ? dtrwTbPes.strIdCertificadoPeso : "");
						m_nQtdeCopiasEnviadasCP = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoPesoNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoPeso : 0);
						m_nQtdeOriginaisEnviadosCP = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoPesoNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoPeso : 0);
						// Certificado de Análise
						m_strIdCertificadoAnalise = (!dtrwTbPes.IsstrIdCertificadoAnaliseNull() ? dtrwTbPes.strIdCertificadoAnalise : "");
						m_nQtdeCopiasEnviadasCA = (!dtrwTbBorderos.IsnQtdeDocCopialCertificadoAnaliseNull() ? dtrwTbBorderos.nQtdeDocCopialCertificadoAnalise : 0);
						m_nQtdeOriginaisEnviadosCA = (!dtrwTbBorderos.IsnQtdeDocOriginalCertificadoAnaliseNull() ? dtrwTbBorderos.nQtdeDocOriginalCertificadoAnalise : 0);
						// Saque
						if (m_typDatSetTbSaque.tbSaques.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaque.tbSaques.Rows[0];
							m_strIdSaque = (!dtrwTbSaques.IsstrNumeroSaqueNull() ? dtrwTbSaques.strNumeroSaque : "");
							m_nQtdeCopiasEnviadasSQ = (!dtrwTbBorderos.IsnQtdeDocCopialSaqueNull() ? dtrwTbBorderos.nQtdeDocCopialSaque : 0);
							m_nQtdeOriginaisEnviadosSQ = (!dtrwTbBorderos.IsnQtdeDocOriginalSaqueNull() ? dtrwTbBorderos.nQtdeDocOriginalSaque : 0);
						}
						// Fito Sanitário
						m_strIdFitoSanitario = (!dtrwTbPes.IsstrIdFitossanitarioNull() ? dtrwTbPes.strIdFitossanitario : "");
						m_nQtdeCopiasEnviadasFS = (!dtrwTbBorderos.IsnQtdeDocCopialFitoSanitarioNull() ? dtrwTbBorderos.nQtdeDocCopialFitoSanitario : 0);
						m_nQtdeOriginaisEnviadosFS = (!dtrwTbBorderos.IsnQtdeDocOriginalFitoSanitarioNull() ? dtrwTbBorderos.nQtdeDocOriginalFitoSanitario : 0);
					}
				}
				else
				{
					//Aqui vai o CO
					m_strIdCertificadoOrigem = "";
					mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwTbCertificadosOrigem = null;
					for (int nCount = 0; nCount < m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count; nCount++)
					{
						dtrwTbCertificadosOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows[nCount];
						if (m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador, m_strIdPE, dtrwTbCertificadosOrigem.nIdTipoCO, 1) != null)
						{
							m_strIdCertificadoOrigem += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
							if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (m_strIdCertificadoOrigem.Trim() != ""))
								m_strIdCertificadoOrigem += ", ";
						}
						if (dtrwTbCertificadosOrigem.nIdTipoCO == 30)
						{
							m_strIdCertificadoOrigem += (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull() ? dtrwTbCertificadosOrigem.strNumeroCertificadoOrigem : "");
							if ((nCount < (m_typDatSetTbCertificadosOrigem.tbCertificadosOrigem.Rows.Count - 1)) && (!dtrwTbCertificadosOrigem.IsstrNumeroCertificadoOrigemNull()))
								m_strIdCertificadoOrigem += ", ";
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
		#region Salvamento dos Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				this.m_bModificado = bModificado;
				if ((m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					System.Data.DataRow dtrwValores = null;
					int nIndice = 0;
					for(int nCont = 0 ; nCont < 9;nCont++)
					{
						if (nIndice < m_dtTabelaTemporaria.Rows.Count)
							dtrwValores = m_dtTabelaTemporaria.Rows[nIndice];
						switch (nCont)
						{
							case 0: if ((m_bMostrarFaturaComercial) && (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0) && (dtrwValores != null))
									{
										mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
										dtrwTbBorderos.nQtdeDocCopiaFaturaComercial = m_nQtdeCopiasEnviadasFC = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalFaturaComercial = m_nQtdeOriginaisEnviadosFC = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 1: if ((m_bMostrarRomaneio) && (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0) && (dtrwValores != null))
									{
										mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
										dtrwTbBorderos.nQtdeDocCopialRomaneio = m_nQtdeCopiasEnviadasRM = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalRomaneio = m_nQtdeOriginaisEnviadosRM = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 2: if ((m_bMostrarSaque) && (m_typDatSetTbSaque.tbSaques.Rows.Count > 0) && (dtrwValores != null))
									{
										mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaque.tbSaques.Rows[0];
										dtrwTbBorderos.nQtdeDocCopialSaque = m_nQtdeCopiasEnviadasSQ = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalSaque = m_nQtdeOriginaisEnviadosSQ = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 3: if ((m_bMostrarCertificadoOrigem) && (dtrwValores != null))
									{
										dtrwTbBorderos.nQtdeDocCopialCertificadoOrigem = m_nQtdeCopiasEnviadasCO = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalCertificadoOrigem = m_nQtdeOriginaisEnviadosCO = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 4: if ((m_bMostrarConhecimentoEmbarque) && (dtrwValores != null))
									{
										dtrwTbPes.strIdConhecimentoEmbarque = m_strIdConhecimentoEmbarque = (string)dtrwValores[TEXTO_IDENTIFICACAO];
										dtrwTbBorderos.nQtdeDocCopialConhecimentoEmbarque = m_nQtdeCopiasEnviadasCE = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalConhecimentoEmbarque = m_nQtdeOriginaisEnviadosCE = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 5: if ((m_bMostrarSeguro) && (dtrwValores != null))
									{
										dtrwTbPes.strIdSeguro = m_strIdSeguro = (string)dtrwValores[TEXTO_IDENTIFICACAO];
										dtrwTbBorderos.nQtdeDocCopialSeguro = m_nQtdeCopiasEnviadasSG = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalSeguro = m_nQtdeOriginaisEnviadosSG = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 6: if ((m_bMostrarFitoSanitario) && (dtrwValores != null))
									{
										dtrwTbPes.strIdFitossanitario = m_strIdFitoSanitario = (string)dtrwValores[TEXTO_IDENTIFICACAO];
										dtrwTbBorderos.nQtdeDocCopialFitoSanitario = m_nQtdeCopiasEnviadasFS = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalFitoSanitario = m_nQtdeOriginaisEnviadosFS = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 7: if ((m_bMostrarCertificadoPeso) && (dtrwValores != null))
									{
										dtrwTbPes.strIdCertificadoPeso = m_strIdCertificadoPeso = (string)dtrwValores[TEXTO_IDENTIFICACAO];
										dtrwTbBorderos.nQtdeDocCopialCertificadoPeso = m_nQtdeCopiasEnviadasCP = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalCertificadoPeso = m_nQtdeOriginaisEnviadosCP = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
							case 8: if ((m_bMostrarCertificadoAnalise) && (dtrwValores != null))
									{
										dtrwTbPes.strIdCertificadoAnalise  = m_strIdCertificadoAnalise = (string)dtrwValores[TEXTO_IDENTIFICACAO];
										dtrwTbBorderos.nQtdeDocCopialCertificadoAnalise = m_nQtdeCopiasEnviadasCA = (int)dtrwValores[TEXTO_QUANTIDADECOPIAS];
										dtrwTbBorderos.nQtdeDocOriginalCertificadoAnalise = m_nQtdeOriginaisEnviadosCA = (int)dtrwValores[TEXTO_QUANTIDADEORIGINAIS];
										nIndice++;
									}
								break;
						}
						dtrwValores = null;
					}
					salvaDadosTypDatSet();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosTypDatSet()
		{
			try
			{
				if (m_typDatSetTbBorderos != null)
					m_cls_dba_ConnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
				if (m_typDatSetTbCertificadosOrigem != null)
					m_cls_dba_ConnectionDB.SetTbCertificadosOrigem(m_typDatSetTbCertificadosOrigem);
				if (m_typDatSetTbFaturasComerciais != null)
					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
				if (m_typDatSetTbPes != null)
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
				if (m_typDatSetTbRomaneios != null)
					m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
				if (m_typDatSetTbSaque != null)
					m_cls_dba_ConnectionDB.SetTbSaques(m_typDatSetTbSaque);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Evento Enter DataGrid
		private void eventoEnterDataGrid(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			try
			{
				if (dtGdValores.CurrentCell.ColumnNumber == 1)
				{
					switch (dtGdValores.CurrentCell.RowNumber)
					{
						default: 
							#region Fatura Comercial
							if ((m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 0))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
								#endregion
							#region Certificado Origem
							else if ((m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 0))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
								#endregion
							#region Saque
							else if ((m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 2))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 0))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
								#endregion
							#region Romaneio
							else if ((m_bMostrarRomaneio) && (m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 3))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (!m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 2))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 2))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (!m_bMostrarSaque) && (m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 2))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (!m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 1))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							else if ((m_bMostrarRomaneio) && (!m_bMostrarSaque) && (!m_bMostrarCertificadoOrigem) && (!m_bMostrarFaturaComercial) && (dtGdValores.CurrentCell.RowNumber == 0))
							{
								dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
							}
							#endregion
							break;
					}
				}
				else if (dtGdValores.CurrentCell.ColumnNumber == 4)
				{
					dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber + 1, 1);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento Leave DataGrid
		private void eventoLeaveDataGrid(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			eventoEnterDataGrid(sender, e, ref dtGdValores);
			try
			{
//				if ((dtGdValores.CurrentCell.ColumnNumber == 2) || (dtGdValores.CurrentCell.ColumnNumber == 3))
//				{
//					System.Data.DataRow dtRow = m_dtTabelaTemporaria.Rows[dtGdValores.CurrentCell.RowNumber];
//					dtRow[TEXTO_QUANTIDADE] = ((int)dtRow[TEXTO_QUANTIDADECOPIAS,System.Data.DataRowVersion.Current] + (int)dtRow[TEXTO_QUANTIDADEORIGINAIS,System.Data.DataRowVersion.Current]);
//				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento TextChanged DataGrid
		private void eventoTextChangedDataGrid(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			try
			{
//				if (m_bTesteDuplicidade)
//				{
//					if ((dtGdValores.CurrentCell.ColumnNumber == 2) || (dtGdValores.CurrentCell.ColumnNumber == 3))
//					{
//						System.Data.DataRow dtRow = m_dtTabelaTemporaria.Rows[dtGdValores.CurrentCell.RowNumber];
//						dtRow[TEXTO_QUANTIDADE] = ((int)dtRow[TEXTO_QUANTIDADECOPIAS,System.Data.DataRowVersion.Current] + (int)dtRow[TEXTO_QUANTIDADEORIGINAIS,System.Data.DataRowVersion.Current]);
//					}
//					m_bTesteDuplicidade = false;
//				}
//				else
//				{
//					m_bTesteDuplicidade = true;
//				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento Key Down DataGrid
		private void eventoKeyDownDataGrid(object sender, System.Windows.Forms.KeyEventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			try
			{
//				if ((dtGdValores.CurrentCell.ColumnNumber == 2) || (dtGdValores.CurrentCell.ColumnNumber == 3))
//				{
//					System.Data.DataRow dtRow = m_dtTabelaTemporaria.Rows[dtGdValores.CurrentCell.RowNumber];
//					dtRow[TEXTO_QUANTIDADE] = ((int)dtRow[TEXTO_QUANTIDADECOPIAS,System.Data.DataRowVersion.Current] + (int)dtRow[TEXTO_QUANTIDADEORIGINAIS,System.Data.DataRowVersion.Current]);
//				}
				if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || (e.KeyCode == System.Windows.Forms.Keys.Tab))
				{
					dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento Key Press DataGrid
		private void eventoKeyPressDataGrid(object sender, System.Windows.Forms.KeyPressEventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores)
		{
			try
			{
				//dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento Key Up DataGrid
		private void eventoKeyUpDataGrid(object sender, System.Windows.Forms.KeyEventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			try
			{
				if ((e.KeyCode == System.Windows.Forms.Keys.Enter) || (e.KeyCode == System.Windows.Forms.Keys.Tab))
				{
					dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(dtGdValores.CurrentCell.RowNumber, dtGdValores.CurrentCell.ColumnNumber + 1);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Evento Current Cell Changed DataGrid
		private void eventoCurrentCellChangedDataGrid(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGdValores)
		{
			eventoEnterDataGrid(sender, e, ref dtGdValores);
			try
			{
//				for (int nCount = 0; nCount < m_dtTabelaTemporaria.Rows.Count; nCount++)
//				{
//					System.Data.DataRow dtRow = m_dtTabelaTemporaria.Rows[nCount/*dtGdValores.CurrentCell.RowNumber*/];
//					dtRow[TEXTO_QUANTIDADE] = ((int)dtRow[TEXTO_QUANTIDADECOPIAS/*,System.Data.DataRowVersion.Default*/] + (int)dtRow[TEXTO_QUANTIDADEORIGINAIS/*,System.Data.DataRowVersion.Default*/]);
//				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			if (m_dtTabelaTemporaria.Rows.Count > m_nNumeroLinhas)
			{
				dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(m_nNumeroLinhas - 1,dtGdValores.CurrentCell.ColumnNumber);
				for (int nCount = m_dtTabelaTemporaria.Rows.Count - 1; nCount >= m_nNumeroLinhas; nCount--)
				{
					m_dtTabelaTemporaria.Rows.RemoveAt(nCount);
				}
			}
			else if (m_dtTabelaTemporaria.Rows.Count <= dtGdValores.CurrentCell.RowNumber)
			{
				dtGdValores.CurrentCell = new System.Windows.Forms.DataGridCell(m_nNumeroLinhas - 1,dtGdValores.CurrentCell.ColumnNumber);
			}
		}
		#endregion

		#region Criar Data Grid
		#region Criar DataTable
		private void criaDataTable()
		{
			try
			{
				System.Data.DataColumn dtClColunas;
				m_dtTabelaTemporaria = new System.Data.DataTable("Master");
				//Coluna Nomes
				dtClColunas = new System.Data.DataColumn(TEXTO_NOMES, System.Type.GetType("System.String"));
				dtClColunas.DefaultValue = "";
				dtClColunas.DataType = System.Type.GetType("System.String");
				dtClColunas.ReadOnly = true;
				m_dtTabelaTemporaria.Columns.Add(dtClColunas);
				//Coluna Identificação
				dtClColunas = new System.Data.DataColumn(TEXTO_IDENTIFICACAO, System.Type.GetType("System.String"));
				dtClColunas.DefaultValue = "";
				dtClColunas.ReadOnly = false;
				m_dtTabelaTemporaria.Columns.Add(dtClColunas);
				//Coluna Quantidade Originais Enviados
				dtClColunas = new System.Data.DataColumn(TEXTO_QUANTIDADEORIGINAIS, System.Type.GetType("System.Int32"));
				dtClColunas.DefaultValue = 0;
				dtClColunas.ReadOnly = false;
				m_dtTabelaTemporaria.Columns.Add(dtClColunas);
				//Coluna Quantidade Cópias Enviadas
				dtClColunas = new System.Data.DataColumn(TEXTO_QUANTIDADECOPIAS, System.Type.GetType("System.Int32"));
				dtClColunas.DefaultValue = 0;
				dtClColunas.ReadOnly = false;
				m_dtTabelaTemporaria.Columns.Add(dtClColunas);
//				//Coluna Quantidade
//				dtClColunas = new System.Data.DataColumn(TEXTO_QUANTIDADE, System.Type.GetType("System.Int32"));
//				dtClColunas.DefaultValue = 0;
//				dtClColunas.ReadOnly = false;
//				m_dtTabelaTemporaria.Columns.Add(dtClColunas);
				carregaDadosDataTable();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Criar Data Style
		private void criaDataStyle()
		{
			try
			{
				m_dgTbStyleTabelaTemporaria = new System.Windows.Forms.DataGridTableStyle();
				m_dgTbStyleTabelaTemporaria.MappingName = "Master";
				m_dgTbStyleTabelaTemporaria.RowHeadersVisible = false;
				m_dgTbStyleTabelaTemporaria.AllowSorting = false; // TESTE
				System.Windows.Forms.DataGridColumnStyle dtgdcolstlColuna;
				//System.Windows.Forms.DataGridColumnStyle dtgdstlColuna
				// Coluna Identificação
				dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcolstlColuna.HeaderText = TEXTO_NOMES;
				dtgdcolstlColuna.MappingName = TEXTO_NOMES;
				dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
				dtgdcolstlColuna.ReadOnly = true;
				dtgdcolstlColuna.Width = 150;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Enter += new System.EventHandler(m_formFQuantidades.m_dgValores_Enter);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyUp);
				m_dgTbStyleTabelaTemporaria.GridColumnStyles.Add(dtgdcolstlColuna);
				// Coluna Identificação
				dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcolstlColuna.HeaderText = TEXTO_IDENTIFICACAO;
				dtgdcolstlColuna.MappingName = TEXTO_IDENTIFICACAO;
				dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
				dtgdcolstlColuna.ReadOnly = false;
				dtgdcolstlColuna.Width = 273;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Enter += new System.EventHandler(m_formFQuantidades.m_dgValores_Enter);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyUp);
				m_dgTbStyleTabelaTemporaria.GridColumnStyles.Add(dtgdcolstlColuna);
                // Coluna Quantidade Originais
				dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcolstlColuna.HeaderText = TEXTO_QUANTIDADEORIGINAIS;
				dtgdcolstlColuna.MappingName = TEXTO_QUANTIDADEORIGINAIS;
				dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				dtgdcolstlColuna.ReadOnly = false;
				dtgdcolstlColuna.Width = 110;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Enter += new System.EventHandler(m_formFQuantidades.m_dgValores_Enter);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Leave += new System.EventHandler(m_formFQuantidades.m_dgValores_Leave);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextChanged += new System.EventHandler(m_formFQuantidades.m_dgValores_TextChanged);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyDown);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyUp);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.LostFocus += new System.EventHandler(m_formFQuantidades.m_dgValores_TextChanged);
				m_dgTbStyleTabelaTemporaria.GridColumnStyles.Add(dtgdcolstlColuna);
				// Coluna Quantidade Cópias
				dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcolstlColuna.HeaderText = TEXTO_QUANTIDADECOPIAS;
				dtgdcolstlColuna.MappingName = TEXTO_QUANTIDADECOPIAS;
				dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				dtgdcolstlColuna.ReadOnly = false;
				dtgdcolstlColuna.Width = 125;
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Enter += new System.EventHandler(m_formFQuantidades.m_dgValores_Enter);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Leave += new System.EventHandler(m_formFQuantidades.m_dgValores_Leave);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextChanged += new System.EventHandler(m_formFQuantidades.m_dgValores_TextChanged);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyDown);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyUp);
				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.LostFocus += new System.EventHandler(m_formFQuantidades.m_dgValores_TextChanged);
				m_dgTbStyleTabelaTemporaria.GridColumnStyles.Add(dtgdcolstlColuna);
//				// Coluna Quantidade
//				dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
//				dtgdcolstlColuna.HeaderText = TEXTO_QUANTIDADE;
//				dtgdcolstlColuna.MappingName = TEXTO_QUANTIDADE;
//				dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
//				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
//				dtgdcolstlColuna.ReadOnly = true;
//				dtgdcolstlColuna.Width = 80;
//				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.Enter += new System.EventHandler(m_formFQuantidades.m_dgValores_Enter);
//				((System.Windows.Forms.DataGridTextBoxColumn)dtgdcolstlColuna).TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(m_formFQuantidades.m_dgValores_KeyUp);
//				m_dgTbStyleTabelaTemporaria.GridColumnStyles.Add(dtgdcolstlColuna);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion
		#region Carregar Formato e Dados
		private void carregaColunasDataGrid(ref mdlComponentesGraficos.DataGrid dgValores)
		{
			try
			{
				dgValores.TableStyles.Clear();
				dgValores.DataSource = m_dtTabelaTemporaria;
				dgValores.TableStyles.Add(m_dgTbStyleTabelaTemporaria);
				dgValores.RowHeadersVisible = false;
				dgValores.AllowNavigation = false;
				dgValores.AllowSorting = false;
				dgValores.ColumnHeadersVisible = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region InitialiazeEventsFormDocumentacao
		private void InitialiazeEventsFormDocumentacao()
		{
		}
		#endregion
		#region ShowDialog
			public void ShowDialog()
			{
				m_formFQuantidades = new Frames.frmFQuantidades(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				criaDataStyle();
				criaDataTable();
				vInitializeEvents(ref m_formFQuantidades);
				m_formFQuantidades.ShowDialog();
				m_formFQuantidades = null;
			}
			
			private void vInitializeEvents(ref Frames.frmFQuantidades formFQuantidades)
			{
				// Carrega Formato Data Grid
				m_formFQuantidades.eCallCarregaDadosTabela += new Frames.frmFQuantidades.delCallCarregaDadosTabela(carregaColunasDataGrid);

				// Enter Event
				m_formFQuantidades.eCallDataGridEnterEvent += new Frames.frmFQuantidades.delCallDataGridEnterEvent(eventoEnterDataGrid);

				// Leave Event
				m_formFQuantidades.eCallDataGridLeaveEvent += new Frames.frmFQuantidades.delCallDataGridLeaveEvent(eventoLeaveDataGrid);

				// Text Changed Event
				m_formFQuantidades.eCallDataGridTextChangedEvent += new Frames.frmFQuantidades.delCallDataGridTextChangedEvent(eventoTextChangedDataGrid);

				// Key Down Event
				m_formFQuantidades.eCallDataGridKeyDownEvent += new Frames.frmFQuantidades.delCallDataGridKeyDownEvent(eventoKeyDownDataGrid);

				// Key Up Event
				m_formFQuantidades.eCallDataGridKeyUpEvent += new Frames.frmFQuantidades.delCallDataGridKeyUpEvent(eventoKeyUpDataGrid);
			
				// Current Cell Changed Event
				m_formFQuantidades.eCallDataGridCurrentCellChangedEvent += new Frames.frmFQuantidades.delCallDataGridCurrentCellChangedEvent(eventoCurrentCellChangedDataGrid);

				// Salva Dados BD
				m_formFQuantidades.eCallSalvaDadosBD += new Frames.frmFQuantidades.delCallSalvaDadosBD(salvaDadosBD);
			}
		#endregion

		#region Retorna Valores
		public void retornaValores(/*Fatura Comercial*/out string strFaturaComercial, out int nQtdeDocOriginaisFC, out int nQtdeDocCopiasFC, out int nQtdeDocTotalFC,
			/*Conhecimento Embarque*/out string strConhecimentoEmbarque, out int nQtdeDocOriginaisCE, out int nQtdeDocCopiasCE, out int nQtdeDocTotalCE,
			/*Seguro*/out string strSeguro, out int nQtdeDocOriginaisSG, out int nQtdeDocCopiasSG, out int nQtdeDocTotalSG,
			/*Certificado de Origem*/out string strCertificadoOrigem, out int nQtdeDocOriginaisCO, out int nQtdeDocCopiasCO, out int nQtdeDocTotalCO,
			/*Romaneio*/out string strRomaneio, out int nQtdeDocOriginaisRM, out int nQtdeDocCopiasRM, out int nQtdeDocTotalRM,
			/*Certificado de Peso*/out string strCertificadoPeso, out int nQtdeDocOriginaisCP, out int nQtdeDocCopiasCP, out int nQtdeDocTotalCP,
			/*Certificado de Análise*/out string strCertificadoAnalise, out int nQtdeDocOriginaisCA, out int nQtdeDocCopiasCA, out int nQtdeDocTotalCA,
			/*Saque*/out string strSaque, out int nQtdeDocOriginaisSQ, out int nQtdeDocCopiasSQ, out int nQtdeDocTotalSQ,
			/*Fito Sanitário*/out string strFitoSanitario, out int nQtdeDocOriginaisFS, out int nQtdeDocCopiasFS, out int nQtdeDocTotalFS)
		{
			// Fatura Comercial
			strFaturaComercial = m_strIdFaturaComercial;
			nQtdeDocCopiasFC = m_nQtdeCopiasEnviadasFC;
			nQtdeDocOriginaisFC = m_nQtdeOriginaisEnviadosFC;
			nQtdeDocTotalFC = m_nQtdeCopiasEnviadasFC + m_nQtdeOriginaisEnviadosFC;
			// Conhecimento Embarque
			strConhecimentoEmbarque = m_strIdConhecimentoEmbarque;
			nQtdeDocCopiasCE = m_nQtdeCopiasEnviadasCE;
			nQtdeDocOriginaisCE = m_nQtdeOriginaisEnviadosCE;
			nQtdeDocTotalCE = m_nQtdeCopiasEnviadasCE + m_nQtdeOriginaisEnviadosCE;
			// Seguro
			strSeguro = m_strIdSeguro;
			nQtdeDocCopiasSG = m_nQtdeCopiasEnviadasSG;
			nQtdeDocOriginaisSG = m_nQtdeOriginaisEnviadosSG;
			nQtdeDocTotalSG = m_nQtdeCopiasEnviadasSG + m_nQtdeOriginaisEnviadosSG;
			// Certificado de Origem
			strCertificadoOrigem = m_strIdCertificadoOrigem;
			nQtdeDocCopiasCO = m_nQtdeCopiasEnviadasCO;
			nQtdeDocOriginaisCO = m_nQtdeOriginaisEnviadosCO;
			nQtdeDocTotalCO = m_nQtdeCopiasEnviadasCO + m_nQtdeOriginaisEnviadosCO;
			// Romaneio
			strRomaneio = m_strIdRomaneio;
			nQtdeDocCopiasRM = m_nQtdeCopiasEnviadasRM;
			nQtdeDocOriginaisRM = m_nQtdeOriginaisEnviadosRM;
			nQtdeDocTotalRM = m_nQtdeCopiasEnviadasRM + m_nQtdeOriginaisEnviadosRM;
			// Certificado de Peso
			strCertificadoPeso = m_strIdCertificadoPeso;
			nQtdeDocCopiasCP = m_nQtdeCopiasEnviadasCP;
			nQtdeDocOriginaisCP = m_nQtdeOriginaisEnviadosCP;
			nQtdeDocTotalCP = m_nQtdeCopiasEnviadasCP + m_nQtdeOriginaisEnviadosCP;
			// Certificado de Análise
			strCertificadoAnalise = m_strIdCertificadoAnalise;
			nQtdeDocCopiasCA = m_nQtdeCopiasEnviadasCA;
			nQtdeDocOriginaisCA = m_nQtdeOriginaisEnviadosCA;
			nQtdeDocTotalCA = m_nQtdeCopiasEnviadasCA + m_nQtdeOriginaisEnviadosCA;
			// Saque
			strSaque = m_strIdSaque;
			nQtdeDocCopiasSQ = m_nQtdeCopiasEnviadasSQ;
			nQtdeDocOriginaisSQ = m_nQtdeOriginaisEnviadosSQ;
			nQtdeDocTotalSQ = m_nQtdeCopiasEnviadasSQ + m_nQtdeOriginaisEnviadosSQ;
			// Fito Sanitário
			strFitoSanitario = m_strIdFitoSanitario;
			nQtdeDocCopiasFS = m_nQtdeCopiasEnviadasFS;
			nQtdeDocOriginaisFS = m_nQtdeOriginaisEnviadosFS;
			nQtdeDocTotalFS = m_nQtdeCopiasEnviadasFS + m_nQtdeOriginaisEnviadosFS;
		}
		public void retornaValores(/*Fatura Comercial*/out string strFaturaComercial, out string strQtdeDocOriginaisFC, out string strQtdeDocCopiasFC, out string strQtdeDocTotalFC,
			/*Conhecimento Embarque*/out string strConhecimentoEmbarque, out string strQtdeDocOriginaisCE, out string strQtdeDocCopiasCE, out string strQtdeDocTotalCE,
			/*Seguro*/out string strSeguro, out string strQtdeDocOriginaisSG, out string strQtdeDocCopiasSG, out string strQtdeDocTotalSG,
			/*Certificado de Origem*/out string strCertificadoOrigem, out string strQtdeDocOriginaisCO, out string strQtdeDocCopiasCO, out string strQtdeDocTotalCO,
			/*Romaneio*/out string strRomaneio, out string strQtdeDocOriginaisRM, out string strQtdeDocCopiasRM, out string strQtdeDocTotalRM,
			/*Certificado de Peso*/out string strCertificadoPeso, out string strQtdeDocOriginaisCP, out string strQtdeDocCopiasCP, out string strQtdeDocTotalCP,
			/*Certificado de Análise*/out string strCertificadoAnalise, out string strQtdeDocOriginaisCA, out string strQtdeDocCopiasCA, out string strQtdeDocTotalCA,
			/*Saque*/out string strSaque, out string strQtdeDocOriginaisSQ, out string strQtdeDocCopiasSQ, out string strQtdeDocTotalSQ,
			/*Fito Sanitário*/out string strFitoSanitario, out string strQtdeDocOriginaisFS, out string strQtdeDocCopiasFS, out string strQtdeDocTotalFS)
		{
			#region Fatura Comercial
			if (m_strIdFaturaComercial.Trim() != "")
			{
				strFaturaComercial = m_strIdFaturaComercial;
				strQtdeDocCopiasFC = (m_nQtdeCopiasEnviadasFC > 0 ? m_nQtdeCopiasEnviadasFC.ToString() : "");
				strQtdeDocOriginaisFC = (m_nQtdeOriginaisEnviadosFC > 0 ? m_nQtdeOriginaisEnviadosFC.ToString() : "");
				strQtdeDocTotalFC = ((m_nQtdeCopiasEnviadasFC + m_nQtdeOriginaisEnviadosFC) > 0 ? (m_nQtdeCopiasEnviadasFC + m_nQtdeOriginaisEnviadosFC).ToString() : "");
			}
			else
			{
				strFaturaComercial = "";
				strQtdeDocCopiasFC = "";
				strQtdeDocOriginaisFC = "";
				strQtdeDocTotalFC = "";
			}
			#endregion
			#region Conhecimento Embarque
			if (m_strIdConhecimentoEmbarque.Trim() != "")
			{
				strConhecimentoEmbarque = m_strIdConhecimentoEmbarque;
				strQtdeDocCopiasCE = (m_nQtdeCopiasEnviadasCE > 0 ? m_nQtdeCopiasEnviadasCE.ToString() : "");
				strQtdeDocOriginaisCE = (m_nQtdeOriginaisEnviadosCE > 0 ? m_nQtdeOriginaisEnviadosCE.ToString() : "");
				strQtdeDocTotalCE = ((m_nQtdeCopiasEnviadasCE + m_nQtdeOriginaisEnviadosCE) > 0 ? (m_nQtdeCopiasEnviadasCE + m_nQtdeOriginaisEnviadosCE).ToString() : "");
			}
			else
			{
				strConhecimentoEmbarque = "";
				strQtdeDocCopiasCE = "";
				strQtdeDocOriginaisCE = "";
				strQtdeDocTotalCE = "";
			}
			#endregion
			#region Seguro
			if (m_strIdSeguro.Trim() != "")
			{
				strSeguro = m_strIdSeguro;
				strQtdeDocCopiasSG = (m_nQtdeCopiasEnviadasSG > 0 ? m_nQtdeCopiasEnviadasSG.ToString() : "");
				strQtdeDocOriginaisSG = (m_nQtdeOriginaisEnviadosSG > 0 ? m_nQtdeOriginaisEnviadosSG.ToString() : "");
				strQtdeDocTotalSG = ((m_nQtdeCopiasEnviadasSG + m_nQtdeOriginaisEnviadosSG) > 0 ? (m_nQtdeCopiasEnviadasSG + m_nQtdeOriginaisEnviadosSG).ToString() : "");
			}
			else
			{
				strSeguro = "";
				strQtdeDocCopiasSG = "";
				strQtdeDocOriginaisSG = "";
				strQtdeDocTotalSG = "";
			}
			#endregion
			#region Certificado de Origem
			if (m_strIdCertificadoOrigem.Trim() != "")
			{
				strCertificadoOrigem = m_strIdCertificadoOrigem;
				strQtdeDocCopiasCO = (m_nQtdeCopiasEnviadasCO > 0 ? m_nQtdeCopiasEnviadasCO.ToString() : "");
				strQtdeDocOriginaisCO = (m_nQtdeOriginaisEnviadosCO > 0 ? m_nQtdeOriginaisEnviadosCO.ToString() : "");
				strQtdeDocTotalCO = ((m_nQtdeCopiasEnviadasCO + m_nQtdeOriginaisEnviadosCO) > 0 ? (m_nQtdeCopiasEnviadasCO + m_nQtdeOriginaisEnviadosCO).ToString() : "");
			}
			else
			{
				strCertificadoOrigem = "";
				strQtdeDocCopiasCO = "";
				strQtdeDocOriginaisCO = "";
				strQtdeDocTotalCO = "";
			}
			#endregion
			#region Romaneio
			if (m_strIdRomaneio.Trim() != "")
			{
				strRomaneio = m_strIdRomaneio;
				strQtdeDocCopiasRM = (m_nQtdeCopiasEnviadasRM > 0 ? m_nQtdeCopiasEnviadasRM.ToString() : "");
				strQtdeDocOriginaisRM = (m_nQtdeOriginaisEnviadosRM > 0 ? m_nQtdeOriginaisEnviadosRM.ToString() : "");
				strQtdeDocTotalRM = ((m_nQtdeCopiasEnviadasRM + m_nQtdeOriginaisEnviadosRM) > 0 ? (m_nQtdeCopiasEnviadasRM + m_nQtdeOriginaisEnviadosRM).ToString() : "");
			}
			else
			{
				strRomaneio = "";
				strQtdeDocCopiasRM = "";
				strQtdeDocOriginaisRM = "";
				strQtdeDocTotalRM = "";
			}
			#endregion
			#region Certificado de Peso
			if (m_strIdCertificadoPeso.Trim() != "")
			{
				strCertificadoPeso = m_strIdCertificadoPeso;
				strQtdeDocCopiasCP = (m_nQtdeCopiasEnviadasCP > 0 ? m_nQtdeCopiasEnviadasCP.ToString() : "");
				strQtdeDocOriginaisCP = (m_nQtdeOriginaisEnviadosCP > 0 ? m_nQtdeOriginaisEnviadosCP.ToString() : "");
				strQtdeDocTotalCP = ((m_nQtdeCopiasEnviadasCP + m_nQtdeOriginaisEnviadosCP) > 0 ? (m_nQtdeCopiasEnviadasCP + m_nQtdeOriginaisEnviadosCP).ToString() : "");
			}
			else
			{
				strCertificadoPeso = "";
				strQtdeDocCopiasCP = "";
				strQtdeDocOriginaisCP = "";
				strQtdeDocTotalCP = "";
			}
			#endregion
			#region Certificado de Análise
			if (m_strIdCertificadoAnalise.Trim() != "")
			{
				strCertificadoAnalise = m_strIdCertificadoAnalise;
				strQtdeDocCopiasCA = (m_nQtdeCopiasEnviadasCA > 0 ? m_nQtdeCopiasEnviadasCA.ToString() : "");
				strQtdeDocOriginaisCA = (m_nQtdeOriginaisEnviadosCA > 0 ? m_nQtdeOriginaisEnviadosCA.ToString() : "");
				strQtdeDocTotalCA = ((m_nQtdeCopiasEnviadasCA + m_nQtdeOriginaisEnviadosCA) > 0 ? (m_nQtdeCopiasEnviadasCA + m_nQtdeOriginaisEnviadosCA).ToString() : "");
			}
			else
			{
				strCertificadoAnalise = "";
				strQtdeDocCopiasCA = "";
				strQtdeDocOriginaisCA = "";
				strQtdeDocTotalCA = "";
			}
			#endregion
			#region Saque
			if (m_strIdSaque.Trim() != "")
			{
				strSaque = m_strIdSaque;
				strQtdeDocCopiasSQ = (m_nQtdeCopiasEnviadasSQ > 0 ? m_nQtdeCopiasEnviadasSQ.ToString() : "");
				strQtdeDocOriginaisSQ = (m_nQtdeOriginaisEnviadosSQ > 0 ? m_nQtdeOriginaisEnviadosSQ.ToString() : "");
				strQtdeDocTotalSQ = ((m_nQtdeCopiasEnviadasSQ + m_nQtdeOriginaisEnviadosSQ) > 0 ? (m_nQtdeCopiasEnviadasSQ + m_nQtdeOriginaisEnviadosSQ).ToString() : "");
			}
			else
			{
				strSaque = "";
				strQtdeDocCopiasSQ = "";
				strQtdeDocOriginaisSQ = "";
				strQtdeDocTotalSQ = "";
			}
			#endregion
			#region Fito Sanitário
			if (m_strIdFitoSanitario.Trim() != "")
			{
				strFitoSanitario = m_strIdFitoSanitario;
				strQtdeDocCopiasFS = (m_nQtdeCopiasEnviadasFS > 0 ? m_nQtdeCopiasEnviadasFS.ToString() : "");
				strQtdeDocOriginaisFS = (m_nQtdeOriginaisEnviadosFS > 0 ? m_nQtdeOriginaisEnviadosFS.ToString() : "");
				strQtdeDocTotalFS = ((m_nQtdeCopiasEnviadasFS + m_nQtdeOriginaisEnviadosFS) > 0 ? (m_nQtdeCopiasEnviadasFS + m_nQtdeOriginaisEnviadosFS).ToString() : "");
			}
			else
			{
				strFitoSanitario = "";
				strQtdeDocCopiasFS = "";
				strQtdeDocOriginaisFS = "";
				strQtdeDocTotalFS = "";
			}
			#endregion
		}
		#endregion
	}
}
