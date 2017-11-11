using System;

namespace mdlRelatoriosCallBackAreaProdutos
{
	#region Enums
	internal enum ClassificacaoFaturaComercial
	{
		Nenhuma = 0,
		Ncm = 1,
		Naladi = 2,
		Grupo =3
	}

	internal enum OrdemProdutosSource
	{
		Nenhum = 0,
		FaturaCotacao = 1,
		FaturaProforma = 2,
		FaturaComercial =3
	}
	#endregion
	#region Structs
	public struct DataStruct
	{
		public string strText;
		public int nHeight;
		public int nWidth;
		public System.Drawing.Font fntText;
	}
	#endregion
	/// <summary>
	/// Summary description for clsRelatoriosCallBackAreaProdutos.
	/// </summary>
	public class clsRelatoriosCallBackAreaProdutos
	{
		#region Static
			#region Produto
				static internal int nRetornaIdProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial, int nIdOrdemProduto)
				{
					int nRetorno = -1;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
						if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
						{
							if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
								nRetorno = dtrwProdutoFaturaComercial.idProduto;
							break;
						}
					}
					return(nRetorno);
				} 

				static public string strRetornaDescricaoProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdExportador,int nIdIdioma,int nIdOrdemProduto)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
						if ((dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto) && (!dtrwProdutoFaturaComercial.IsidProdutoNull()))
						{
							if ((nIdIdioma > 1) & (!dtrwProdutoFaturaComercial.IsmstrDescricaoLinguaEstrangeiraNull()))
								return(dtrwProdutoFaturaComercial.mstrDescricaoLinguaEstrangeira);
							if (!dtrwProdutoFaturaComercial.IsmstrDescricaoNull())
								return(dtrwProdutoFaturaComercial.mstrDescricao);
							return(strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdioma,dtrwProdutoFaturaComercial.idProduto));
						}
					}
					return("");
				}

				static public string strRetornaDescricaoProdutoRomaneio(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdExportador,int nIdIdiomaFatura,int nIdIdiomaRomaneio,int nIdOrdemProduto)
				{
					if (nIdIdiomaRomaneio == nIdIdiomaFatura)
					{
						string strDescricao = strRetornaDescricaoProdutoFatura(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,nIdExportador,nIdIdiomaRomaneio,nIdOrdemProduto);
						if (strDescricao == "")
						{
							int nIdProduto = nRetornaIdProduto(ref typDatSetTbProdutosFaturaComercial,nIdOrdemProduto);
							if (nIdProduto != -1)
							{
								strDescricao = strRetornaDescricaoProdutoIdioma(ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdiomaRomaneio,nIdProduto);
								if (strDescricao == "")
									strDescricao = strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdiomaRomaneio,nIdProduto);
							}
						}
						return(strDescricao);
					}else{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
						for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
						{
							dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
							if ((dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto) && (!dtrwProdutoFaturaComercial.IsidProdutoNull()))
							{
								return(strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdiomaRomaneio,dtrwProdutoFaturaComercial.idProduto));
							}
						}
					}
					return("");
				}

				public static string strRetornaDescricaoProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,int nIdExportador, int nIdIdioma,int nIdProduto)
				{
					string strRetorno = strRetornaDescricaoProdutoIdioma(ref typDatSetTbProdutosIdiomas,nIdExportador,nIdIdioma,nIdProduto);
					if (strRetorno == "")
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(nIdExportador,nIdProduto);
						if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsmstrDescricaoNull()))
						{
							strRetorno = dtrwTbProdutos.mstrDescricao;
						}
					}
					return(strRetorno);
				}

				public static string strRetornaDescricaoProdutoIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,int nIdExportador, int nIdIdioma,int nIdProduto)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwTbProdutosIdioma = typDatSetTbProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(nIdExportador,nIdIdioma,nIdProduto);
					if (dtrwTbProdutosIdioma != null)
					{
						if (!dtrwTbProdutosIdioma.IsmstrDescricaoNull())
							strRetorno = dtrwTbProdutosIdioma.mstrDescricao;
						else if (!dtrwTbProdutosIdioma.IsstrDescricaoNull())
							strRetorno = dtrwTbProdutosIdioma.strDescricao;
					}
					return(strRetorno);
				}

				private static string strRetornaCodigoProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,int nIdExportador,int nIdProduto)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(nIdExportador,nIdProduto);
					if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsmstrCodigoProdutoNull()))
					{
						strRetorno = dtrwTbProdutos.mstrCodigoProduto;
					}
					return(strRetorno);
				}

				private static string strRetornaNcmProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,int nIdExportador, int nIdProduto)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(nIdExportador,nIdProduto);
					if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsstrNcmNull()))
					{
						strRetorno = dtrwTbProdutos.strNcm;
					}
					return(strRetorno);
				}

				private static string strRetornaNcmProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwFaturaComercial)
				{
					if (dtrwFaturaComercial == null)
						return("");
					if (!dtrwFaturaComercial.IsstrNcmNull())
						return(dtrwFaturaComercial.strNcm);
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(dtrwFaturaComercial.idExportador,dtrwFaturaComercial.idProduto);
					if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsstrNcmNull()))
						return(dtrwTbProdutos.strNcm);
					return("");
				}

				private static string strRetornaDenominacaoNcm(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm,int nIdExportador, string strNcm)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwTbProdutosNcm = typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(nIdExportador,strNcm);
					if ((dtrwTbProdutosNcm != null) && (!dtrwTbProdutosNcm.IsmstrDenominacaoNull()))
					{
						strRetorno = dtrwTbProdutosNcm.mstrDenominacao;
					}
					return(strRetorno);
				}

				private static string strRetornaDenominacaoNcm(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem)
				{
					if (dtrwFaturaComercial == null)
						return("");
					if (!dtrwProdutoCertificadoOrigem.IsmstrDenominacaoNull())
						return(dtrwProdutoCertificadoOrigem.mstrDenominacao);
					if (!dtrwFaturaComercial.IsmstrNcmDenominacaoNull())
						return(dtrwFaturaComercial.mstrNcmDenominacao);
					string strNcm = strRetornaNcmProduto(ref typDatSetTbProdutos,ref dtrwFaturaComercial);
					return(strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,dtrwFaturaComercial.idExportador,strNcm));
				}

				private static string strRetornaNaladiProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,int nIdExportador, int nIdProduto)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(nIdExportador,nIdProduto);
					if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsstrNaladiNull()))
					{
						strRetorno = dtrwTbProdutos.strNaladi;
					}
					return(strRetorno);
				}

				private static string strRetornaNaladiProduto(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwFaturaComercial)
				{
					if (dtrwFaturaComercial == null)
						return("");
					if (!dtrwFaturaComercial.IsstrNaladiNull())
						return(dtrwFaturaComercial.strNaladi);
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwTbProdutos = typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(dtrwFaturaComercial.idExportador,dtrwFaturaComercial.idProduto);
					if ((dtrwTbProdutos != null) && (!dtrwTbProdutos.IsstrNaladiNull()))
						return(dtrwTbProdutos.strNaladi);
					return("");
				}


				private static string strRetornaDenominacaoNaladi(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi,int nIdExportador, string strNaladi)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwTbProdutosNaladi = typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(nIdExportador,strNaladi);
					if ((dtrwTbProdutosNaladi != null) && (!dtrwTbProdutosNaladi.IsmstrDenominacaoNull()))
					{
						strRetorno = dtrwTbProdutosNaladi.mstrDenominacao;
					}
					return(strRetorno);
				}

				private static string strRetornaDenominacaoNaladi(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem)
				{
					if (dtrwFaturaComercial == null)
						return("");
					if (!dtrwProdutoCertificadoOrigem.IsmstrDenominacaoNull())
						return(dtrwProdutoCertificadoOrigem.mstrDenominacao);
					if (!dtrwFaturaComercial.IsmstrNaladiDenominacaoNull())
						return(dtrwFaturaComercial.mstrNaladiDenominacao);
					string strNaladi = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwFaturaComercial);
					return(strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,dtrwFaturaComercial.idExportador,strNaladi));
				}
			#endregion
			#region Produto Fatura
				static internal string strRetornaUnidadeQuantidadeProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdOrdemProduto)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
						if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
						{
							if (!dtrwProdutoFaturaComercial.IsstrUnidadeNull())
								strRetorno = dtrwProdutoFaturaComercial.strUnidade;
							break;
						}
					}
					return(strRetorno);
				}

				static internal bool bIsChild(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdOrdemProduto)
				{
					bool bRetorno = false;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
						if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
						{
							if (!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull())
								bRetorno = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0;
							break;
						}
					}
					return(bRetorno);
				}

				static internal string strRetornaOrdemLancamentoProdutoFatura(ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,int nIdOrdemProduto)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					for (int nCont = 0;nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont];
						if (dtrwProdutoFaturaComercial.idOrdem == nIdOrdemProduto)
						{
							return(dtrwProdutoFaturaComercial.idOrdemLancamento.ToString());
						}
					}
					return("");
				}
			#endregion

			#region Porcentagem
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
			#region UnidadeEspaco
				static internal string strRetornaSiglaUnidadeEspaco(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetTbUnidadesEspaco,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetTbUnidadesEspacoIdioma,int nIdUnidadeEspaco,int nIdIdioma)
				{
					string strRetorno = strRetornaSiglaUnidadeEspacoIdioma(ref typDatSetTbUnidadesEspacoIdioma,nIdUnidadeEspaco,nIdIdioma);
					if (strRetorno.Trim() == "")
					{
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow dtrwUnidadesEspaco = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco.tbUnidadesEspacoRow)typDatSetTbUnidadesEspaco.tbUnidadesEspaco.FindBynIdUnidadeEspaco(nIdUnidadeEspaco);                    
						if (dtrwUnidadesEspaco != null)
						{
							strRetorno = dtrwUnidadesEspaco.strSigla;	
						}
					}
					return(strRetorno);
				}

				static internal string strRetornaSiglaUnidadeEspacoIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetTbUnidadesEspacoIdioma,int nIdUnidadeEspaco,int nIdIdioma)
				{
					string strRetorno = "";
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma.tbUnidadesEspacoIdiomaRow dtrwUnidadeEspacoIdioma = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma.tbUnidadesEspacoIdiomaRow)typDatSetTbUnidadesEspacoIdioma.tbUnidadesEspacoIdioma.FindBynIdUnidadeEspaconIdIdioma(nIdUnidadeEspaco,nIdIdioma);                    
					if (dtrwUnidadeEspacoIdioma != null)
					{
						strRetorno = dtrwUnidadeEspacoIdioma.strSigla;	
					}
					return (strRetorno);
				}
			#endregion
			#region UnidadeMassa
			static internal string strRetornaSiglaUnidadeMassa(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
			{
				string strRetorno = strRetornaSiglaUnidadeMassaIdioma(ref typDatSetTbUnidadesMassaIdioma,nIdUnidadeMassa,nIdIdioma);
				if (strRetorno.Trim() == "")
				{
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow dtrwUnidadesMassa = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow)typDatSetTbUnidadesMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(nIdUnidadeMassa);                    
					if (dtrwUnidadesMassa != null)
					{
						strRetorno = dtrwUnidadesMassa.strSigla;	
					}
				}
				return(strRetorno);
			}

			static internal string strRetornaSiglaUnidadeMassaIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow dtrwUnidadeMassaIdioma = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow)typDatSetTbUnidadesMassaIdioma.tbUnidadesMassaIdioma.FindBynIdUnidadeMassanIdIdioma(nIdUnidadeMassa,nIdIdioma);                    
				if (dtrwUnidadeMassaIdioma != null)
				{
					strRetorno = dtrwUnidadeMassaIdioma.strSigla;	
				}
				return (strRetorno);
			}
			#endregion
		#endregion

		#region Constants 
		private const int MAXDECIMALS = 8;

		private const string TEXTO_REPETICAO = "";

		private const int CURRENCY_REAL = 0;
		private const int CURRENCY_DOLAR = 28;

		private const int RELATORIO_COTACAO = 1;
		private const int RELATORIO_FATURA_PROFORMA = 2;
		private const int RELATORIO_FATURA_COMERCIAL = 3;
		private const int RELATORIO_CO_MERCOSUL = 4;
		private const int RELATORIO_CO_MERCOSULBOLIVIA = 5;
		private const int RELATORIO_CO_MERCOSULCHILE = 6;
		private const int RELATORIO_CO_ALADIAPTR04 = 7;
		private const int RELATORIO_CO_ALADIACE39 = 8;
		private const int RELATORIO_CO_ANEXOIII = 9;
		private const int RELATORIO_CO_COMUM = 10;
		public const int RELATORIO_ROMANEIO_PRODUTOS = 11;
		private const int RELATORIO_DOC_BANC_BORDERO = 12;
		private const int RELATORIO_DOC_BANC_INSTRUCOESACC = 13;
		private const int RELATORIO_DOC_BANC_SAQUE = 14;
		private const int RELATORIO_INSTRUCAOEMBARQUE = 15;
		private const int RELATORIO_TRANSPORTE = 16;
		private const int RELATORIO_LIBERACAO = 17;
		private const int RELATORIO_DESPESAS = 18;
		private const int RELATORIO_CERTIFICADOSEGURO = 19;
		private const int RELATORIO_NOTAFISCAL = 20;
		private const int RELATORIO_SUMARIO = 21;
		private const int RELATORIO_FORM_A = 22;
		private const int RELATORIO_DOC_BANC_BORDERO_SECUNDARIO = 24;
		public const int RELATORIO_ROMANEIO_VOLUMES = 25;
		public const int RELATORIO_ROMANEIO_SIMPLIFICADO = 26;
		private const int RELATORIO_RESERVA = 27;
		private const int RELATORIO_GUIA_ENTRADA = 28;
		private const int RELATORIO_CO_ALADIACE59 = 29;
		private const int RELATORIO_CO_FORMA = 30;


		private const int RELATORIO_HEIGHT_NORMAL = 0;
		private const int RELATORIO_HEIGHT_INCREMENTO = 5;
		private const int RELATORIO_WIDTH_NORMAL = 0;
		private const int RELATORIO_WIDTH_INCREMENTO = 10;

		private const int RELATORIO_COTACAO_ESPACAMENTO_PRODUTOS = 0;
		private const int RELATORIO_COMERCIAL_ESPACAMENTO_ANTES_DENOMINACAO = 10;
		private const int RELATORIO_COMERCIAL_ESPACAMENTO_DEPOIS_DENOMINACAO = 10;

		private const int CERTIFICADO_ORIGEM_MERCOSUL = 1;
		private const int CERTIFICADO_ORIGEM_MERCOSUL_BOLIVIA = 2;
		private const int CERTIFICADO_ORIGEM_MERCOSUL_CHILE = 3;
		private const int CERTIFICADO_ORIGEM_ALADI_APTR04 = 4;
		private const int CERTIFICADO_ORIGEM_ALADI_ACE39 = 5;
		private const int CERTIFICADO_ORIGEM_ANEXOIII = 6;
		private const int CERTIFICADO_ORIGEM_COMUM = 7;
		private const int CERTIFICADO_ORIGEM_FORM_A = 8;
		private const int CERTIFICADO_ORIGEM_ALADI_ACE59 = 29;
		private const int CERTIFICADO_ORIGEM_FORMA = 30;

		private const int STATUS_CARREGA_NADA = 0;
		private const int STATUS_CARREGA_TUDO = 1;
		private const int STATUS_CARREGA_LISTA = 2;
		private const int STATUS_CARREGA_AREAPRODUTOS = 4;

		#endregion
		#region Atributes
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		private string m_strEnderecoExecutavel; 
		private int m_nIdExportador = -1;
		private string m_strIdCodigo = "";
		private int m_nHeight; 
		private int m_nWidth; 
		private int m_nIdioma;
		private int m_nIdMoeda;
		private bool m_bMostrarSimboloMoeda = false;
		private System.Windows.Forms.ImageList m_ilBandeiras = null;
		private string m_strDelimitadorUsar = " - ";
		private string m_strDelimitadorNulo = "   ";
		private string m_strDelimitadorRomaneioUsar = "   ";

		private int[] m_arrnListaIDsCamposAreaProdutos = null;
		private System.Collections.ArrayList m_arlIdOrdemProdutos = new System.Collections.ArrayList();
		private OrdemProdutosSource m_enumOrdemProdutosSource = OrdemProdutosSource.Nenhum;
		private mdlProdutosLancamento.clsPropriedadesProdutos m_clsPropriedades = null;
		#endregion 
		#region Properties
		public int Idioma
		{
			set
			{
				m_nIdioma = value;
			}	
			get
			{
				return(m_nIdioma);
			}
		}

		public System.Windows.Forms.ImageList Bandeiras
		{
			set
			{
				m_ilBandeiras = value;
			}	
			get
			{
				return(m_ilBandeiras);
			}
		}

		public int[] ListaIDsCamposAreaProdutos
		{
			set
			{
				m_arrnListaIDsCamposAreaProdutos = value;
			}
			get
			{
				return(m_arrnListaIDsCamposAreaProdutos);
			}
		}

		private System.Collections.ArrayList OrdemProdutos
		{
			set
			{
				m_arlIdOrdemProdutos = value;
			}
			get
			{
				return(m_arlIdOrdemProdutos);
			}
		}

		private OrdemProdutosSource EnumOrdemProdutosSource
		{
			set
			{
				m_enumOrdemProdutosSource = value;
			}
			get
			{
				return(m_enumOrdemProdutosSource);
			}
		} 

		private mdlProdutosLancamento.clsPropriedadesProdutos Propriedades
		{
			get
			{
				if (m_clsPropriedades != null)
					return(m_clsPropriedades);
				switch(EnumOrdemProdutosSource)
				{
					case OrdemProdutosSource.FaturaCotacao:
						m_clsPropriedades = new mdlProdutosLancamento.clsPropriedadesProdutosFaturaCotacao(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
					case OrdemProdutosSource.FaturaProforma:
						m_clsPropriedades = new mdlProdutosLancamento.clsPropriedadesProdutosFaturaProforma(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
					case OrdemProdutosSource.FaturaComercial:
						m_clsPropriedades = new mdlProdutosLancamento.clsPropriedadesProdutosFaturaComercial(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
						break;
				}
				return(m_clsPropriedades);
			}
		}
		#endregion
		#region Constructor and Destructors
		public clsRelatoriosCallBackAreaProdutos(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel; 
		}
		#endregion

		#region Métodos de Carregamento dos Dados 
		public System.Collections.ArrayList arlRetornaDadosAreaProdutos(int nIdExportador,string  strIdCodigo,int nTipoRelatorio)
		{
			System.Collections.ArrayList arlRetorno = null;
			OrdemProdutosClear();
			m_nIdExportador = nIdExportador;
			m_strIdCodigo = strIdCodigo;
			try
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				switch(nTipoRelatorio)
				{
					case RELATORIO_COTACAO: // 1
						arlRetorno = arlRetornaDadosAreaProdutosCotacao(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaCotacao;
						break;
					case RELATORIO_FATURA_PROFORMA: // 2
						arlRetorno = arlRetornaDadosAreaProdutosFaturaProforma(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaProforma;
						break;
					case RELATORIO_FATURA_COMERCIAL: // 3
						arlRetorno = arlRetornaDadosAreaProdutosFaturaComercial(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_MERCOSUL: // 4
						arlRetorno = arlRetornaDadosAreaProdutosCOMercosul(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_MERCOSULBOLIVIA: // 5
						arlRetorno = arlRetornaDadosAreaProdutosCOMercosulBolivia(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_MERCOSULCHILE: // 6
						arlRetorno = arlRetornaDadosAreaProdutosCOMercosulChile(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_ALADIAPTR04: // 7
						arlRetorno = arlRetornaDadosAreaProdutosCOAladiAptr04(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_ALADIACE39: // 8
						arlRetorno = arlRetornaDadosAreaProdutosCOAladiAce39(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_ANEXOIII: // 9
						arlRetorno = arlRetornaDadosAreaProdutosCOAnexoIII(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_COMUM: // 10
						arlRetorno = arlRetornaDadosAreaProdutosCOComum(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_ROMANEIO_PRODUTOS: // 11
						arlRetorno = arlRetornaDadosAreaProdutosRomaneio_Produtos(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_DOC_BANC_BORDERO: // 12
					case RELATORIO_DOC_BANC_BORDERO_SECUNDARIO: // 24
						arlRetorno = arlRetornaDadosAreaProdutosBordero(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_DOC_BANC_INSTRUCOESACC: // 13
						break;
					case RELATORIO_DOC_BANC_SAQUE: // 14
						break;
					case RELATORIO_INSTRUCAOEMBARQUE: // 15
						break;
					case RELATORIO_TRANSPORTE: // 16
						break;
					case RELATORIO_LIBERACAO: // 17
						break;
					case RELATORIO_DESPESAS: // 18
						break;
					case RELATORIO_CERTIFICADOSEGURO: // 19
						break;
					case RELATORIO_NOTAFISCAL: // 20
						break;
					case RELATORIO_SUMARIO: // 21
						arlRetorno = arlRetornaDadosAreaProdutosSumario(nIdExportador,strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_ROMANEIO_VOLUMES: // 25
						arlRetorno = arlRetornaDadosAreaProdutosRomaneio_Volumes(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_ROMANEIO_SIMPLIFICADO: // 26
						arlRetorno = arlRetornaDadosAreaProdutosRomaneio_Simplificado(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_ALADIACE59: // 29
						arlRetorno = arlRetornaDadosAreaProdutosCOAladiAce59(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
					case RELATORIO_CO_FORMA: // 30
						arlRetorno = arlRetornaDadosAreaProdutosCOFormA(nIdExportador, strIdCodigo);
						EnumOrdemProdutosSource = OrdemProdutosSource.FaturaComercial;
						break;
				}
			}catch (System.Exception objExp){
				object objErro = (object)objExp;
				m_cls_ter_tratadorErro.trataErro(ref objErro);
			}
			InsertDadosAreaProdutosDinamicos(ref arlRetorno);
			return(arlRetorno);
		}
		#endregion
		#region Métodos de Show Dialog 
		public System.Collections.ArrayList arlShowDialog(int nIdExportador, string strIdCodigo, int nTipoRelatorio, ref int nStatus )
		{
			System.Collections.ArrayList arlRetorno = null;
			try
			{
				switch(nTipoRelatorio)
				{
					case RELATORIO_COTACAO: // 1
						arlRetorno = arlShowDialogCotacao(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_FATURA_PROFORMA: // 2
						break;
					case RELATORIO_FATURA_COMERCIAL: // 3
						arlRetorno = arlShowDialogFaturaComercial(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_MERCOSUL: // 4
						arlRetorno = arlShowDialogCOMercosul(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_MERCOSULBOLIVIA: // 5
						arlRetorno = arlShowDialogCOMercosulBolivia(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_MERCOSULCHILE: // 6
						arlRetorno = arlShowDialogCOMercosulChile(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_ALADIAPTR04: // 7
						arlRetorno = arlShowDialogCOMercosulAladiAptr04(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_ALADIACE39: // 8
						arlRetorno = arlShowDialogCOMercosulAladiAce39(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_ANEXOIII: // 9
						arlRetorno = arlShowDialogCOAnexoIII(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_COMUM: // 10
						arlRetorno = arlShowDialogCOComum(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_ROMANEIO_PRODUTOS: // 11
					case RELATORIO_ROMANEIO_VOLUMES: // 25
						arlRetorno = arlShowDialogRomaneio(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_DOC_BANC_BORDERO: // 12
					case RELATORIO_DOC_BANC_BORDERO_SECUNDARIO: // 24
						arlRetorno = arlShowDialogBordero(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_DOC_BANC_INSTRUCOESACC: // 13
						break;
					case RELATORIO_DOC_BANC_SAQUE: // 14
						break;
					case RELATORIO_INSTRUCAOEMBARQUE: // 15
						break;
					case RELATORIO_TRANSPORTE: // 16
						break;
					case RELATORIO_LIBERACAO: // 17
						break;
					case RELATORIO_DESPESAS: // 18
						break;
					case RELATORIO_CERTIFICADOSEGURO: // 19
						break;
					case RELATORIO_NOTAFISCAL: // 20
						break;
					case RELATORIO_SUMARIO: // 21
						break;
					case RELATORIO_ROMANEIO_SIMPLIFICADO: // 26
						arlRetorno = arlShowDialogRomaneio_Simplificado(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_ALADIACE59: // 29
						arlRetorno = arlShowDialogCOMercosulAladiAce59(nIdExportador, strIdCodigo, ref nStatus);
						break;
					case RELATORIO_CO_FORMA: // 30
						arlRetorno = arlShowDialogCOFormA(nIdExportador, strIdCodigo, ref nStatus);
						break;
				}
			}catch (System.Exception expErro){
				m_cls_ter_tratadorErro.trataErro(ref expErro);
			}
			return(arlRetorno);
		} 
		#endregion
		#region Métodos de Carregamento de Paginas
			public int nRetornaTotalPaginasAreaProdutos(int nIdExportador,string  strIdCodigo,int nTipoRelatorio)
			{
				int nReturn = -1;
				switch(nTipoRelatorio)
				{
					case RELATORIO_GUIA_ENTRADA:
						nReturn = nRetornaTotalPaginasAreaProdutosGuiaEntrada(nIdExportador,strIdCodigo);
						break;
				}
				return(nReturn);
			}
		#endregion

		#region Currency
			private string strReturnCurrencyFormated(double dValue)
			{
				return(mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dValue,m_bMostrarSimboloMoeda));
			}

			private string strReturnCurrencyFormatedMax(double dValue)
			{
				return(mdlMoeda.clsMoeda.strReturnCurrencyFormatedMax(m_nIdMoeda,dValue,m_bMostrarSimboloMoeda));
			}
		#endregion

		#region OrdemProdutos
			private void OrdemProdutosClear()
			{
				this.OrdemProdutos.Clear();
				m_enumOrdemProdutosSource = OrdemProdutosSource.Nenhum;
				m_clsPropriedades = null;
			}

			private void OrdemProdutosInsere(int nIdOrdemProduto)
			{
				this.OrdemProdutos.Add(nIdOrdemProduto);
			}

			private void OrdemProdutosInsere()
			{
				this.OrdemProdutos.Add(-1);
			}
		#endregion
		#region CamposBDDinamicos
		public void InsertCamposBDDinamicos(int nIdExportador,int nIdTipoRelatorio,ref mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios typDatSetRelatoriosCamposBDRelatorios)
		{
			// Inserindo Propriedades Produtos
			InsertCamposBDDinamicosPropriedadesProdutos(nIdExportador,nIdTipoRelatorio,ref typDatSetRelatoriosCamposBDRelatorios);
		}

		private void InsertCamposBDDinamicosPropriedadesProdutos(int nIdExportador,int nIdTipoRelatorio,ref mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios typDatSetRelatoriosCamposBDRelatorios)
		{
			switch(nIdTipoRelatorio)
			{
				case (int)mdlConstantes.Relatorio.FaturaCotacao:
				case (int)mdlConstantes.Relatorio.FaturaProforma:
				case (int)mdlConstantes.Relatorio.FaturaComercial:
				case (int)mdlConstantes.Relatorio.Romaneio:
				case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
				case (int)mdlConstantes.Relatorio.RomaneioVolumes:
					break;
				default:
					return;
			}

			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("nIdExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(nIdExportador);

			arlCondicaoCampo.Add("nIdIdioma");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add((int)mdlConstantes.Idioma.Portugues);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedadesProdutos = m_cls_dba_ConnectionDB.GetTbPropriedadesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			for(int i =0; i < typDatSetPropriedadesProdutos.tbPropriedadesProdutos.Rows.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedadesProdutos.tbPropriedadesProdutos[i];

				mdlDataBaseAccess.Tabelas.XsdTbRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatoriosRow dtrwCampoBDRelatorio = typDatSetRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.NewtbRelatoriosCamposBDRelatoriosRow();

				dtrwCampoBDRelatorio.nIdTipoRelatorio = nIdTipoRelatorio;
				dtrwCampoBDRelatorio.nIdCampoBD = Int32.Parse(dtrwPropriedade.nIdPropriedade.ToString() + "97");
				dtrwCampoBDRelatorio.strNomeCampoNoRelatorio = "<Produto>" + dtrwPropriedade.mstrDescricao;
				dtrwCampoBDRelatorio.bCallbackClicavel = false;
				dtrwCampoBDRelatorio.nAlinhamento = 0;

				typDatSetRelatoriosCamposBDRelatorios.tbRelatoriosCamposBDRelatorios.AddtbRelatoriosCamposBDRelatoriosRow(dtrwCampoBDRelatorio);
			}
		}

		private bool InsertDadosAreaProdutosDinamicos(ref System.Collections.ArrayList arlRetorno)
		{
			return(InsertDadosAreaProdutosDinamicosPropriedadesProdutos(ref arlRetorno));
		}

		private bool InsertDadosAreaProdutosDinamicosPropriedadesProdutos(ref System.Collections.ArrayList arlRetorno)
		{
			if (this.ListaIDsCamposAreaProdutos == null)
				return(false);
			if (arlRetorno == null)
				return(false);
			int nTotal = -1;
			for(int i = 0; i < this.ListaIDsCamposAreaProdutos.Length;i++)
			{
				int IdCampo = this.ListaIDsCamposAreaProdutos[i];
				bool bExist = false;
				for(int j = 0; j < arlRetorno.Count;j++)
				{
					System.Collections.ArrayList arlCurrent = (System.Collections.ArrayList)arlRetorno[j];
					if (j == 0)
						nTotal = (arlCurrent.Count - 1);
					if (arlCurrent[0].ToString() == IdCampo.ToString())
					{
						bExist = true;
						break;
					}
				}
				if ((!bExist) && (nTotal > 0))
				{
					System.Collections.ArrayList arlInserir = new System.Collections.ArrayList();
					arlInserir.Add(IdCampo.ToString());
					for(int k = 0; k < nTotal;k++)
					{
						DataStruct dataStruct = new DataStruct();
						int IdOrdemProduto = - 1;
						if (OrdemProdutos.Count > k)
							IdOrdemProduto = Int32.Parse(OrdemProdutos[k].ToString());
						string strText = "";
						if (IdOrdemProduto != -1)
							strText = GetPropriedadeDinamicaProduto(IdCampo,IdOrdemProduto);
						dataStruct.strText = strText;
						arlInserir.Add(dataStruct);
					}
					arlRetorno.Add(arlInserir);
				}
			}
			return(true);
		}

		private string GetPropriedadeDinamicaProduto(int nIdCampoBDPropriedade,int nIdOrdemProduto)
		{
			string strRetorno = "";
			if (this.Propriedades != null)
				strRetorno = this.Propriedades.GetPropridadeValor(m_nIdioma,nIdCampoBDPropriedade,nIdOrdemProduto);
			return(strRetorno);
		}
		#endregion

		#region #01 Fatura Cotação
			#region #01 Fatura Cotação - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCotacao(int nIdExportador,string strIdCodigo)
			{
				System.Collections.ArrayList arlRetorno = null;
				m_nIdMoeda = CURRENCY_DOLAR;
				bool bDetalharProdutos = false;
				bool bMostrarGrupo = false;

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial enumClassificacao = mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma;
	
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFatura = typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(nIdExportador,strIdCodigo);

				if (dtrwFatura != null)
				{
					if (!dtrwFatura.IsidClassificacaoTarifariaMostrarNull())
					{
						enumClassificacao = (mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial)dtrwFatura.idClassificacaoTarifariaMostrar;
					}
					// IdMoeda
					if (!dtrwFatura.IsidMoedaNull())
					{
						m_nIdMoeda = dtrwFatura.idMoeda;
					}
					// MostrarSimboloMoeda
					if (!dtrwFatura.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwFatura.bMostrarSimboloMoeda;
					}
					// Detalhar Produtos
					if (!dtrwFatura.IsbDetalharProdutosNull())
						bDetalharProdutos = dtrwFatura.bDetalharProdutos;

					// Mostrar Grupo
					if (!dtrwFatura.IsbMostrarGrupoNull())
						bMostrarGrupo = dtrwFatura.bMostrarGrupo;
				}
                
				switch(enumClassificacao)
				{
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNenhuma(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Ncm:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNcm(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Naladi:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNaladi(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Grupo:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaCotacaoGrupo(nIdExportador,strIdCodigo,bDetalharProdutos,bMostrarGrupo);
						break;
				}
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNenhuma(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();


				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4101");
				arlColunaAtual_Quantidade.Add("4001");
				arlColunaAtual_Unidade.Add("4401");
				arlColunaAtual_PrecoUnitario.Add("4201");
				arlColunaAtual_SubTotal.Add("4301");
				arlColunaAtual_Codigo.Add("4501");
				arlColunaAtual_Ordem.Add("4601");
				arlColunaAtual_OrdemSequencial.Add("4701");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFatura;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaCotacao;

				// Inserindo os Produtos Principais
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)sortLstProdutosPrincipais.GetByIndex(nCont);
					cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
					dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
					vInsereProdutoFaturaCotacao(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private void vInsereProdutoFaturaCotacao(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFaturaCotacao,ref int nIdExportador,ref string strIdCotacao,ref System.Collections.ArrayList arlColunaAtual_Descricao,ref System.Collections.ArrayList arlColunaAtual_Quantidade,ref System.Collections.ArrayList arlColunaAtual_Unidade,ref System.Collections.ArrayList arlColunaAtual_PrecoUnitario,ref System.Collections.ArrayList arlColunaAtual_SubTotal,ref System.Collections.ArrayList arlColunaAtual_Cogido,ref System.Collections.ArrayList arlColunaAtual_Ordem,ref System.Collections.ArrayList arlColunaAtual_OrdemSequencial,bool bDetalharProdutos,string strDelimitador,bool bPossuiPrecoUnitario,double dPrecoUnitarioProduto,double dSubTotalProduto,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFaturaCotacao)
			{
				// Inserindo o Produto
				this.OrdemProdutosInsere(dtrwProdutoFaturaCotacao.idOrdem);
				// Descricao
				DataStruct structData = new DataStruct();
				if ((m_nIdioma > 1) && (!dtrwProdutoFaturaCotacao.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFaturaCotacao.mstrDescricaoLinguaEstrangeira != ""))
				{
					structData.strText = strDelimitador + dtrwProdutoFaturaCotacao.mstrDescricaoLinguaEstrangeira;
				}
				else if ((!dtrwProdutoFaturaCotacao.IsmstrDescricaoNull()) && (dtrwProdutoFaturaCotacao.mstrDescricao != ""))
				{
					structData.strText = strDelimitador + dtrwProdutoFaturaCotacao.mstrDescricao;
				}else{
					structData.strText = strDelimitador + strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFaturaCotacao.idProduto);
				}
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Descricao.Add(structData);

				// Codigo
				structData = new DataStruct();
				if ((!dtrwProdutoFaturaCotacao.IsmstrCodigoProdutoNull()) && (dtrwProdutoFaturaCotacao.mstrCodigoProduto != ""))
					structData.strText = dtrwProdutoFaturaCotacao.mstrCodigoProduto;
				else
					structData.strText = strRetornaCodigoProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaCotacao.idProduto);
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Cogido.Add(structData);

				// Ordem
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaCotacao.idOrdemLancamento.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Ordem.Add(structData);

				// OrdemSequencial
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaCotacao.idOrdem.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_OrdemSequencial.Add(structData);

				// Quantidade
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaCotacao.dQuantidade.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Quantidade.Add(structData);

				// Unidade
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaCotacao.strUnidade;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Unidade.Add(structData);

				string strPrecoUnitarioProduto = "", strSubTotalProduto = "";
				if (bPossuiPrecoUnitario)
				{
					strPrecoUnitarioProduto = dPrecoUnitarioProduto.ToString();
					strSubTotalProduto = dSubTotalProduto.ToString();
				}

				// Preco Unitario
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormatedMax(double.Parse(strPrecoUnitarioProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_PrecoUnitario.Add(structData);

				// SubTotal
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormated(double.Parse(strSubTotalProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_SubTotal.Add(structData);

				if ((bDetalharProdutos) && (!dtrwProdutoFaturaCotacao.IsbDetalharChildsNull()) && (dtrwProdutoFaturaCotacao.bDetalharChilds))
				{
					// Delimitador
					strDelimitador += m_strDelimitadorUsar;

					// Buscando os Produtos Integrantes do Produto
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFaturaCotacaoIntegrante = null; 
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList();
					int nIdOrdemProdutoParent = 0;
					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaCotacaoIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFaturaCotacao.tbProdutosFaturaCotacao.Rows[nCont]; 
						if (!dtrwProdutoFaturaCotacaoIntegrante.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFaturaCotacaoIntegrante.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaCotacaoIntegrante.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFaturaCotacaoIntegrante.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == dtrwProdutoFaturaCotacao.idOrdem)
								sortLstProdutos.Add(dtrwProdutoFaturaCotacaoIntegrante.idOrdem,dtrwProdutoFaturaCotacaoIntegrante);
						}
					}

					// Inserindo os Produtos Integrantes
					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						dtrwProdutoFaturaCotacaoIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)sortLstProdutos.GetByIndex(nCont);
						vInsereProdutoFaturaCotacao(ref typDatSetTbProdutos, ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaCotacao,ref nIdExportador,ref strIdCotacao,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Cogido,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,strDelimitador,false,0,0,ref dtrwProdutoFaturaCotacaoIntegrante);
					}
				}
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNcm(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4101");
				arlColunaAtual_Quantidade.Add("4001");
				arlColunaAtual_Unidade.Add("4401");
				arlColunaAtual_PrecoUnitario.Add("4201");
				arlColunaAtual_SubTotal.Add("4301");
				arlColunaAtual_Codigo.Add("4501");
				arlColunaAtual_Ordem.Add("4601");
				arlColunaAtual_OrdemSequencial.Add("4701");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFatura;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaCotacao;

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "" , strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsstrNcmNull())
						strClassificacao = dtrwProdutoFatura.strNcm;
					else
						strClassificacao = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
					if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
						strDenominacao = dtrwProdutoFatura.mstrNcmDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem )))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
					strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					this.OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// OrdemSequencial
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							if (!dtrwProdutoFatura.IsstrNcmNull())
								strClassificacaoProduto = dtrwProdutoFatura.strNcm;
							else
								strClassificacaoProduto = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
							if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
								strDenominacaoProduto = dtrwProdutoFatura.mstrNcmDenominacao;
							else
								strDenominacaoProduto = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacaoProduto);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
								vInsereProdutoFaturaCotacao(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
							}
						
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaCotacaoClassificacaoNaladi(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4101");
				arlColunaAtual_Quantidade.Add("4001");
				arlColunaAtual_Unidade.Add("4401");
				arlColunaAtual_PrecoUnitario.Add("4201");
				arlColunaAtual_SubTotal.Add("4301");
				arlColunaAtual_Codigo.Add("4501");
				arlColunaAtual_Ordem.Add("4601");
				arlColunaAtual_OrdemSequencial.Add("4601");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFatura;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaCotacao;

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "" ,strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsstrNaladiNull())
						strClassificacao = dtrwProdutoFatura.strNaladi;
					else
						strClassificacao = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
					if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
						strDenominacao = dtrwProdutoFatura.mstrNaladiDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem )))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
					strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					this.OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// OrdemSequencial
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							if (!dtrwProdutoFatura.IsstrNaladiNull())
								strClassificacaoProduto = dtrwProdutoFatura.strNaladi;
							else
								strClassificacaoProduto = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
							if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
								strDenominacao = dtrwProdutoFatura.mstrNaladiDenominacao;
							else
								strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacao);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
								vInsereProdutoFaturaCotacao(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
							}
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaCotacaoGrupo(int nIdExportador,string strIdCodigo,bool bDetalharProdutos,bool bMostrarGrupo)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4101");
				arlColunaAtual_Quantidade.Add("4001");
				arlColunaAtual_Unidade.Add("4401");
				arlColunaAtual_PrecoUnitario.Add("4201");
				arlColunaAtual_SubTotal.Add("4301");
				arlColunaAtual_Codigo.Add("4501");
				arlColunaAtual_Ordem.Add("4601");
				arlColunaAtual_OrdemSequencial.Add("4701");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFatura;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Grupos
				int nIdOrdemProdutoParent = -1;
				System.Collections.SortedList sortLstGrupos = new System.Collections.SortedList();
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							string strGrupo = "";
							if (!dtrwProdutoFatura.IsmstrPersonalizavelNull())
								strGrupo = dtrwProdutoFatura.mstrPersonalizavel;
							if (!sortLstGrupos.Contains(strGrupo))
								sortLstGrupos.Add(strGrupo,strGrupo);
						}
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaCotacao;

				// Produtos
				for(int i = 0; i < sortLstGrupos.Count; i++)
				{
					string strGrupo = sortLstGrupos.GetByIndex(i).ToString();
					System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)typDatSetTbProdutosFatura.tbProdutosFaturaCotacao.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == 0)
							{
								string strGrupoProduto = "";
								if (!dtrwProdutoFatura.IsmstrPersonalizavelNull())
									strGrupoProduto = dtrwProdutoFatura.mstrPersonalizavel;
								if (strGrupo == strGrupoProduto)
								{
									string strDescricaoProduto = "";
									if ((!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira != ""))
										strDescricaoProduto = dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira;
									else if ((!dtrwProdutoFatura.IsmstrDescricaoNull()) && (dtrwProdutoFatura.mstrDescricao != ""))
										strDescricaoProduto = dtrwProdutoFatura.mstrDescricao;
									else
										strDescricaoProduto = strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
									while(sortLstProdutosPrincipais.Contains(strDescricaoProduto))
										strDescricaoProduto += "X";
									sortLstProdutosPrincipais.Add(strDescricaoProduto,dtrwProdutoFatura);
								}
							}
						}
					}
					// Inserindo 
					if (sortLstProdutosPrincipais.Count > 0)
					{
						// Inserindo Grupo
						if (!bMostrarGrupo)
							strGrupo = "";
						vInsereFaturaComercialGrupo(ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,strGrupo);

						// Inserindo os Produtos Principais
						double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
						for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
						{
							dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow)sortLstProdutosPrincipais.GetByIndex(nCont);
							cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
							vInsereProdutoFaturaCotacao(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
						}
					}
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}
		#endregion
			#region #01 Fatura Cotação - ShowDialog
			private System.Collections.ArrayList arlShowDialogCotacao(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosLancamento.clsLancamentoProdutos cls_prod = new mdlProdutosLancamento.clsLancamentoProdutosFaturaCotacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_ilBandeiras,nIdExportador,strIdCodigo);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
			#endregion
		#endregion
		#region #02 Fatura Proforma
		#region #02 Fatura Proforma - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaProforma(int nIdExportador,string strIdCodigo)
			{
				System.Collections.ArrayList arlRetorno = null;
				m_nIdMoeda = CURRENCY_DOLAR;
				bool bDetalharProdutos = false;
				bool bMostrarGrupo = false;

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial enumClassificacao = mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma;

				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFatura = typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(nIdExportador,strIdCodigo);

				if (dtrwFatura != null)
				{
					if (!dtrwFatura.IsidClassificacaoTarifariaMostrarNull())
					{
						enumClassificacao = (mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial)dtrwFatura.idClassificacaoTarifariaMostrar;
					}
					// IdMoeda
					if (!dtrwFatura.IsidMoedaNull())
					{
						m_nIdMoeda = dtrwFatura.idMoeda;
					}
					// MostrarSimboloMoeda
					if (!dtrwFatura.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwFatura.bMostrarSimboloMoeda;
					}
					// Detalhar Produtos
					if (!dtrwFatura.IsbDetalharProdutosNull())
						bDetalharProdutos = dtrwFatura.bDetalharProdutos;

					// Mostrar Grupo
					if (!dtrwFatura.IsbMostrarGrupoNull())
						bMostrarGrupo = dtrwFatura.bMostrarGrupo;
				}
	        
				switch(enumClassificacao)
				{
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNenhuma(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Ncm:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNcm(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Naladi:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNaladi(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Grupo:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaProformaGrupo(nIdExportador,strIdCodigo,bDetalharProdutos,bMostrarGrupo);
						break;
				}
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNenhuma(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4102");
				arlColunaAtual_Quantidade.Add("4002");
				arlColunaAtual_Unidade.Add("4402");
				arlColunaAtual_PrecoUnitario.Add("4202");
				arlColunaAtual_SubTotal.Add("4302");
				arlColunaAtual_Codigo.Add("4502");
				arlColunaAtual_Ordem.Add("4602");
				arlColunaAtual_OrdemSequencial.Add("4702");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaProforma;

				// Inserindo os Produtos Principais
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)sortLstProdutosPrincipais.GetByIndex(nCont);
					cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
					dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
					vInsereProdutoFaturaProforma(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private void vInsereProdutoFaturaProforma(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFatura,ref int nIdExportador,ref string strIdCotacao,ref System.Collections.ArrayList arlColunaAtual_Descricao,ref System.Collections.ArrayList arlColunaAtual_Quantidade,ref System.Collections.ArrayList arlColunaAtual_Unidade,ref System.Collections.ArrayList arlColunaAtual_PrecoUnitario,ref System.Collections.ArrayList arlColunaAtual_SubTotal,ref System.Collections.ArrayList arlColunaAtual_Cogido,ref System.Collections.ArrayList arlColunaAtual_Ordem,ref System.Collections.ArrayList arlColunaAtual_OrdemSequencial,bool bDetalharProdutos,string strDelimitador,bool bPossuiPrecoUnitario,double dPrecoUnitarioProduto,double dSubTotalProduto,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura)
			{
				// Inserindo o Produto
				OrdemProdutosInsere(dtrwProdutoFatura.idOrdem);
				
				// Descricao
				DataStruct structData = new DataStruct();
				if ((m_nIdioma > 1) && (!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira != ""))
				{
					structData.strText = strDelimitador + dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira;
				}
				else if ((!dtrwProdutoFatura.IsmstrDescricaoNull()) && (dtrwProdutoFatura.mstrDescricao != ""))
				{
					structData.strText = strDelimitador + dtrwProdutoFatura.mstrDescricao;
				}
				else
				{
					structData.strText = strDelimitador + strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
				}
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Descricao.Add(structData);

				// Codigo
				structData = new DataStruct();
				if ((!dtrwProdutoFatura.IsmstrCodigoProdutoNull()) && (dtrwProdutoFatura.mstrCodigoProduto != ""))
					structData.strText = dtrwProdutoFatura.mstrCodigoProduto;
				else
					structData.strText = strRetornaCodigoProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Cogido.Add(structData);

				// Ordem
				structData = new DataStruct();
				structData.strText = dtrwProdutoFatura.idOrdemLancamento.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Ordem.Add(structData);

				// Ordem Sequencial 
				structData = new DataStruct();
				structData.strText = dtrwProdutoFatura.idOrdem.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_OrdemSequencial.Add(structData);

				// Quantidade
				structData = new DataStruct();
				structData.strText = dtrwProdutoFatura.dQuantidade.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Quantidade.Add(structData);

				// Unidade
				structData = new DataStruct();
				structData.strText = dtrwProdutoFatura.strUnidade;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Unidade.Add(structData);

				string strPrecoUnitarioProduto = "", strSubTotalProduto = "";
				if (bPossuiPrecoUnitario)
				{
					strPrecoUnitarioProduto = dPrecoUnitarioProduto.ToString();
					strSubTotalProduto = dSubTotalProduto.ToString();
				}

				// Preco Unitario
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormatedMax(double.Parse(strPrecoUnitarioProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_PrecoUnitario.Add(structData);

				// SubTotal
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormated(double.Parse(strSubTotalProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_SubTotal.Add(structData);

				if ((bDetalharProdutos) && (!dtrwProdutoFatura.IsbDetalharChildsNull()) && (dtrwProdutoFatura.bDetalharChilds))
				{
					// Delimitador
					strDelimitador += m_strDelimitadorUsar;

					// Buscando os Produtos Integrantes do Produto
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFaturaIntegrante = null; 
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList();
					int nIdOrdemProdutoParent = 0;
					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFaturaIntegrante.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaIntegrante.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFaturaIntegrante.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem)
								sortLstProdutos.Add(dtrwProdutoFaturaIntegrante.idOrdem,dtrwProdutoFaturaIntegrante);
						}
					}

					// Inserindo os Produtos Integrantes
					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						dtrwProdutoFaturaIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)sortLstProdutos.GetByIndex(nCont);
						vInsereProdutoFaturaProforma(ref typDatSetTbProdutos, ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCotacao,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Cogido,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,strDelimitador,false,0,0,ref dtrwProdutoFaturaIntegrante);
					}
				}
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNcm(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4102");
				arlColunaAtual_Quantidade.Add("4002");
				arlColunaAtual_Unidade.Add("4402");
				arlColunaAtual_PrecoUnitario.Add("4202");
				arlColunaAtual_SubTotal.Add("4302");
				arlColunaAtual_Codigo.Add("4502");
				arlColunaAtual_Ordem.Add("4602");
				arlColunaAtual_OrdemSequencial.Add("4702");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaProforma;

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "", strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsstrNcmNull())
						strClassificacao = dtrwProdutoFatura.strNcm;
					else
						strClassificacao = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
					if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
						strDenominacao = dtrwProdutoFatura.mstrNcmDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem )))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
					strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// Ordem Sequencial
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							if (!dtrwProdutoFatura.IsstrNcmNull())
								strClassificacaoProduto = dtrwProdutoFatura.strNcm;
							else
								strClassificacaoProduto = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
							if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
								strDenominacaoProduto = dtrwProdutoFatura.mstrNcmDenominacao;
							else
								strDenominacaoProduto = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacao);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
								vInsereProdutoFaturaProforma(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
							}
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaProformaClassificacaoNaladi(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4102");
				arlColunaAtual_Quantidade.Add("4002");
				arlColunaAtual_Unidade.Add("4402");
				arlColunaAtual_PrecoUnitario.Add("4202");
				arlColunaAtual_SubTotal.Add("4302");
				arlColunaAtual_Codigo.Add("4502");
				arlColunaAtual_Ordem.Add("4602");
				arlColunaAtual_OrdemSequencial.Add("4702");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaProforma;

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFatura.idOrdem,dtrwProdutoFatura);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "" , strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsstrNaladiNull())
						strClassificacao = dtrwProdutoFatura.strNaladi;
					else
						strClassificacao = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
					if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
						strDenominacao = dtrwProdutoFatura.mstrNaladiDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem )))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
					strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// Ordem Sequencial 
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							if (!dtrwProdutoFatura.IsstrNaladiNull())
								strClassificacaoProduto = dtrwProdutoFatura.strNaladi;
							else
								strClassificacaoProduto = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
							if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
								strDenominacaoProduto = dtrwProdutoFatura.mstrNaladiDenominacao;
							else
								strDenominacaoProduto = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacao);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent == 0) || (dtrwProdutoFatura.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
								vInsereProdutoFaturaProforma(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
							}
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaProformaGrupo(int nIdExportador,string strIdCodigo,bool bDetalharProdutos,bool bMostrarGrupo)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4102");
				arlColunaAtual_Quantidade.Add("4002");
				arlColunaAtual_Unidade.Add("4402");
				arlColunaAtual_PrecoUnitario.Add("4202");
				arlColunaAtual_SubTotal.Add("4302");
				arlColunaAtual_Codigo.Add("4502");
				arlColunaAtual_Ordem.Add("4602");
				arlColunaAtual_OrdemSequencial.Add("4702");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetTbProdutosFatura;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Grupos
				int nIdOrdemProdutoParent = -1;
				System.Collections.SortedList sortLstGrupos = new System.Collections.SortedList();
				for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
				{
					dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
					if (!dtrwProdutoFatura.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							string strGrupo = "";
							if (!dtrwProdutoFatura.IsmstrPersonalizavelNull())
								strGrupo = dtrwProdutoFatura.mstrPersonalizavel;
							if (!sortLstGrupos.Contains(strGrupo))
								sortLstGrupos.Add(strGrupo,strGrupo);
						}
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.DataSourceValores = mdlIncoterm.DataSource.FaturaProforma;

				// Produtos
				for(int i = 0; i < sortLstGrupos.Count; i++)
				{
					string strGrupo = sortLstGrupos.GetByIndex(i).ToString();
					System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					for(int nCont = 0; nCont < typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows.Count;nCont++)
					{
						dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)typDatSetTbProdutosFatura.tbProdutosFaturaProforma.Rows[nCont]; 
						if (!dtrwProdutoFatura.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFatura.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == 0)
							{
								string strGrupoProduto = "";
								if (!dtrwProdutoFatura.IsmstrPersonalizavelNull())
									strGrupoProduto = dtrwProdutoFatura.mstrPersonalizavel;
								if (strGrupo == strGrupoProduto)
								{
									string strDescricaoProduto = "";
									if ((!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira != ""))
										strDescricaoProduto = dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira;
									else if ((!dtrwProdutoFatura.IsmstrDescricaoNull()) && (dtrwProdutoFatura.mstrDescricao != ""))
										strDescricaoProduto = dtrwProdutoFatura.mstrDescricao;
									else
										strDescricaoProduto = strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
									while(sortLstProdutosPrincipais.Contains(strDescricaoProduto))
										strDescricaoProduto += "X";
									sortLstProdutosPrincipais.Add(strDescricaoProduto,dtrwProdutoFatura);
								}
							}
						}
					}
					// Inserindo 
					if (sortLstProdutosPrincipais.Count > 0)
					{
						// Inserindo Grupo
						if (!bMostrarGrupo)
							strGrupo = "";
						vInsereFaturaComercialGrupo(ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,strGrupo);

						// Inserindo os Produtos Principais
						double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
						for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
						{
							dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow)sortLstProdutosPrincipais.GetByIndex(nCont);
							cls_man_Valor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFatura.dQuantidade,2);
							vInsereProdutoFaturaProforma(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFatura,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFatura);
						}
					}
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}
		#endregion
		#region #02 Fatura Proforma - Show Dialog 
		#endregion
		#endregion
		#region #03 Fatura Comercial
		#region #03 Fatura Comercial - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaComercial(int nIdExportador,string strIdCodigo)
			{
				System.Collections.ArrayList arlRetorno = null;
				m_nIdMoeda = CURRENCY_DOLAR;
				bool bDetalharProdutos = false;
				bool bMostrarGrupo = false;

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial enumClassificacaoFaturaComercial = mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma;
	
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);

				if (dtrwFaturaComercial != null)
				{
					if (!dtrwFaturaComercial.IsidClassificacaoTarifariaMostrarNull())
					{
						enumClassificacaoFaturaComercial = (mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial)dtrwFaturaComercial.idClassificacaoTarifariaMostrar;
					}
					// IdMoeda
					if (!dtrwFaturaComercial.IsidMoedaNull())
					{
						m_nIdMoeda = dtrwFaturaComercial.idMoeda;
					}
					// MostrarSimboloMoeda
					if (!dtrwFaturaComercial.IsbMostrarSimboloMoedaNull())
					{
						m_bMostrarSimboloMoeda = dtrwFaturaComercial.bMostrarSimboloMoeda;
					}
					// Detalhar Produtos
					if (!dtrwFaturaComercial.IsbDetalharProdutosNull())
						bDetalharProdutos = dtrwFaturaComercial.bDetalharProdutos;

					// Mostrar Grupo
					if (!dtrwFaturaComercial.IsbMostrarGrupoNull())
						bMostrarGrupo = dtrwFaturaComercial.bMostrarGrupo;
				}
                
				switch(enumClassificacaoFaturaComercial)
				{
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Nenhuma:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNenhuma(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Ncm:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNcm(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Naladi:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNaladi(nIdExportador,strIdCodigo,bDetalharProdutos);
						break;
					case mdlRelatoriosCallBackAreaProdutos.ClassificacaoFaturaComercial.Grupo:
						arlRetorno = arlRetornaDadosAreaProdutosFaturaComercialGrupo(nIdExportador,strIdCodigo,bDetalharProdutos,bMostrarGrupo);
						break;
				}
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNenhuma(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4103");
				arlColunaAtual_Quantidade.Add("4003");
				arlColunaAtual_Unidade.Add("4403");
				arlColunaAtual_PrecoUnitario.Add("4203");
				arlColunaAtual_SubTotal.Add("4303");
				arlColunaAtual_Codigo.Add("4503");
				arlColunaAtual_Ordem.Add("4603");
				arlColunaAtual_OrdemSequencial.Add("4703");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);

				// Inserindo os Produtos Principais
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)sortLstProdutosPrincipais.GetByIndex(nCont);
					cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
					dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade,2);
					vInsereProdutoFaturaComercial(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFaturaComercial,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFaturaComercial);
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private void vInsereProdutoFaturaComercial(ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,ref int nIdExportador,ref string strIdPe,ref System.Collections.ArrayList arlColunaAtual_Descricao,ref System.Collections.ArrayList arlColunaAtual_Quantidade,ref System.Collections.ArrayList arlColunaAtual_Unidade,ref System.Collections.ArrayList arlColunaAtual_PrecoUnitario,ref System.Collections.ArrayList arlColunaAtual_SubTotal,ref System.Collections.ArrayList arlColunaAtual_Codigo,ref System.Collections.ArrayList arlColunaAtual_Ordem,ref System.Collections.ArrayList arlColunaAtual_OrdemSequencial,bool bDetalharProdutos,string strDelimitador,bool bPossuiPrecoUnitario,double dPrecoUnitarioProduto,double dSubTotalProduto,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial)
			{
				// Inserindo o Produto
				// Descricao
				OrdemProdutosInsere(dtrwProdutoFaturaComercial.idOrdem);
				DataStruct structData = new DataStruct();
				string strPrefixo = "";
				if (!bPossuiPrecoUnitario)
					strPrefixo = strDelimitador + " (" +  dtrwProdutoFaturaComercial.dQuantidade.ToString() + " " + dtrwProdutoFaturaComercial.strUnidade + ") ";  

				if ((m_nIdioma > 1) && (!dtrwProdutoFaturaComercial.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFaturaComercial.mstrDescricaoLinguaEstrangeira != ""))
				{
					structData.strText = strPrefixo + dtrwProdutoFaturaComercial.mstrDescricaoLinguaEstrangeira;
				}
				else if ((!dtrwProdutoFaturaComercial.IsmstrDescricaoNull()) && (dtrwProdutoFaturaComercial.mstrDescricao != ""))
				{
					structData.strText = strPrefixo + dtrwProdutoFaturaComercial.mstrDescricao;
				}
				else
				{
					structData.strText = strPrefixo + strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFaturaComercial.idProduto);
				}

				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Descricao.Add(structData);

				// Codigo
				structData = new DataStruct();
				if (!dtrwProdutoFaturaComercial.IsmstrCodigoProdutoNull())
					structData.strText = dtrwProdutoFaturaComercial.mstrCodigoProduto;
				else
					structData.strText = strRetornaCodigoProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaComercial.idProduto);
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Codigo.Add(structData);

				// Ordem
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaComercial.idOrdemLancamento.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Ordem.Add(structData);

				// OrdemSequencial 
				structData = new DataStruct();
				structData.strText = dtrwProdutoFaturaComercial.idOrdem.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_OrdemSequencial.Add(structData);

				// Quantidade
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = dtrwProdutoFaturaComercial.dQuantidade.ToString();
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Quantidade.Add(structData);

				// Unidade
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = dtrwProdutoFaturaComercial.strUnidade;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Unidade.Add(structData);

				string strPrecoUnitarioProduto = "", strSubTotalProduto = "";
				if (bPossuiPrecoUnitario)
				{
					strPrecoUnitarioProduto = dPrecoUnitarioProduto.ToString();
					strSubTotalProduto = dSubTotalProduto.ToString();
				}

				// Preco Unitario
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormatedMax(double.Parse(strPrecoUnitarioProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_PrecoUnitario.Add(structData);

				// SubTotal
				structData = new DataStruct();
				if (bPossuiPrecoUnitario)
					structData.strText = strReturnCurrencyFormated(double.Parse(strSubTotalProduto));
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_SubTotal.Add(structData);

				if ((bDetalharProdutos) && (!dtrwProdutoFaturaComercial.IsbDetalharChildsNull()) && (dtrwProdutoFaturaComercial.bDetalharChilds))
				{
					// Delimitador
					strDelimitador += m_strDelimitadorUsar;

					// Buscando os Produtos Integrantes do Produto
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercialIntegrante = null; 
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList();
					int nIdOrdemProdutoParent = 0;
					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercialIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
						if (!dtrwProdutoFaturaComercialIntegrante.IsidProdutoNull())
						{
							if (dtrwProdutoFaturaComercial.idOrdem == dtrwProdutoFaturaComercialIntegrante.idOrdem)
								continue;
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFaturaComercialIntegrante.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercialIntegrante.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFaturaComercialIntegrante.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == dtrwProdutoFaturaComercial.idOrdem) 
								sortLstProdutos.Add(dtrwProdutoFaturaComercialIntegrante.idOrdem,dtrwProdutoFaturaComercialIntegrante);
						}
					}

					// Inserindo os Produtos Integrantes
					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						dtrwProdutoFaturaComercialIntegrante = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)sortLstProdutos.GetByIndex(nCont);
						vInsereProdutoFaturaComercial(ref typDatSetTbProdutos, ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref nIdExportador,ref strIdPe,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,strDelimitador,false,0,0,ref dtrwProdutoFaturaComercialIntegrante);
					}
				}
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNcm(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4103");
				arlColunaAtual_Quantidade.Add("4003");
				arlColunaAtual_Unidade.Add("4403");
				arlColunaAtual_PrecoUnitario.Add("4203");
				arlColunaAtual_SubTotal.Add("4303");
				arlColunaAtual_Codigo.Add("4503");
				arlColunaAtual_Ordem.Add("4603");
				arlColunaAtual_OrdemSequencial.Add("4703");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "", strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsstrNcmNull())
						strClassificacao = dtrwProdutoFaturaComercial.strNcm;
					else
						strClassificacao = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaComercial.idProduto);
					if (!dtrwProdutoFaturaComercial.IsmstrNcmDenominacaoNull())
						strDenominacao = dtrwProdutoFaturaComercial.mstrNcmDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == dtrwProdutoFaturaComercial.idOrdem)))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
				    strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// Ordem Sequencial
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
						if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						{
							if (!dtrwProdutoFaturaComercial.IsstrNcmNull())
								strClassificacaoProduto = dtrwProdutoFaturaComercial.strNcm;
							else
								strClassificacaoProduto = strRetornaNcmProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaComercial.idProduto);
							if (!dtrwProdutoFaturaComercial.IsmstrNcmDenominacaoNull())
								strDenominacaoProduto = dtrwProdutoFaturaComercial.mstrNcmDenominacao;
							else
								strDenominacaoProduto = strRetornaDenominacaoNcm(ref typDatSetTbProdutosNcm,nIdExportador,strClassificacaoProduto);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == dtrwProdutoFaturaComercial.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade,2);
								vInsereProdutoFaturaComercial(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFaturaComercial,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFaturaComercial);
							}
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaComercialClassificacaoNaladi(int nIdExportador,string strIdCodigo,bool bDetalharProdutos)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4103");
				arlColunaAtual_Quantidade.Add("4003");
				arlColunaAtual_Unidade.Add("4403");
				arlColunaAtual_PrecoUnitario.Add("4203");
				arlColunaAtual_SubTotal.Add("4303");
				arlColunaAtual_Codigo.Add("4503");
				arlColunaAtual_Ordem.Add("4603");
				arlColunaAtual_OrdemSequencial.Add("4703");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				DataStruct structData;
				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;

				// TypedDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Calculo
                mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				// Classificacao
				System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
				string strClassificacao = "", strClassificacaoProduto = "";
				string strDenominacao = "", strDenominacaoProduto = "";
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsstrNaladiNull())
						strClassificacao = dtrwProdutoFaturaComercial.strNaladi;
					else
						strClassificacao = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaComercial.idProduto);
					if (!dtrwProdutoFaturaComercial.IsmstrNaladiDenominacaoNull())
						strDenominacao = dtrwProdutoFaturaComercial.mstrNaladiDenominacao;
					else
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacao);
					if ((strClassificacao != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == dtrwProdutoFaturaComercial.idOrdem )))
					{
						if (!sortLstClassificacao.Contains(strClassificacao + strDenominacao))
						{
							sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
						}
					}
				}

				// Varendo os Produtos da Classificacao
				for (int nContClass = 0; nContClass < sortLstClassificacao.Count;nContClass++)
				{
					string strClassificacaoDenominacao = sortLstClassificacao.GetKey(nContClass).ToString();
					strClassificacao = sortLstClassificacao.GetByIndex(nContClass).ToString();
					strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

					OrdemProdutosInsere();

					// Descricao
					structData = new DataStruct();
					structData.strText = strDenominacao;
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
					arlColunaAtual_Descricao.Add(structData);

					// Codigo
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Codigo.Add(structData);

					// Ordem
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Ordem.Add(structData);

					// OrdemSequencial
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_OrdemSequencial.Add(structData);

					// Quantidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Quantidade.Add(structData);

					// Unidade
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_Unidade.Add(structData);

					// Preco Unitario
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_PrecoUnitario.Add(structData);

					// SubTotal
					structData = new DataStruct();
					structData.strText = "";
					structData.nHeight = m_nHeight;
					structData.nWidth = m_nWidth;
					arlColunaAtual_SubTotal.Add(structData);

					double dSubTotalProduto = 0,dPrecoUnitarioProduto = 0;

					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
						if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						{
							if (!dtrwProdutoFaturaComercial.IsstrNaladiNull())
								strClassificacaoProduto = dtrwProdutoFaturaComercial.strNaladi;
							else
								strClassificacaoProduto = strRetornaNaladiProduto(ref typDatSetTbProdutos,nIdExportador,dtrwProdutoFaturaComercial.idProduto);
							if (!dtrwProdutoFaturaComercial.IsmstrNaladiDenominacaoNull())
								strDenominacaoProduto = dtrwProdutoFaturaComercial.mstrNaladiDenominacao;
							else
								strDenominacaoProduto = strRetornaDenominacaoNaladi(ref typDatSetTbProdutosNaladi,nIdExportador,strClassificacaoProduto);
							if ((strClassificacao == strClassificacaoProduto) && (strDenominacao == strDenominacaoProduto) && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == dtrwProdutoFaturaComercial.idOrdem)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade,2);
								vInsereProdutoFaturaComercial(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFaturaComercial,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFaturaComercial);
							}
						}
					}
				}
				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosFaturaComercialGrupo(int nIdExportador,string strIdCodigo,bool bDetalharProdutos,bool bMostrarGrupo)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Descricao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Unidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_PrecoUnitario = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_SubTotal = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OrdemSequencial = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Descricao.Add("4103");
				arlColunaAtual_Quantidade.Add("4003");
				arlColunaAtual_Unidade.Add("4403");
				arlColunaAtual_PrecoUnitario.Add("4203");
				arlColunaAtual_SubTotal.Add("4303");
				arlColunaAtual_Codigo.Add("4503");
				arlColunaAtual_Ordem.Add("4603");
				arlColunaAtual_OrdemSequencial.Add("4703");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;

				// TypDatSetTbProdutos
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosIdiomas
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// Grupos
				int nIdOrdemProdutoParent = -1;
				System.Collections.SortedList sortLstGrupos = new System.Collections.SortedList();
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							string strGrupo = "";
							if (!dtrwProdutoFaturaComercial.IsmstrPersonalizavelNull())
								strGrupo = dtrwProdutoFaturaComercial.mstrPersonalizavel;
							if (!sortLstGrupos.Contains(strGrupo))
								sortLstGrupos.Add(strGrupo,strGrupo);
						}
					}
				}

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);

				// Produtos
				for(int i = 0; i < sortLstGrupos.Count; i++)
				{
					string strGrupo = sortLstGrupos.GetByIndex(i).ToString();
					System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
						if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == 0)
							{
								string strGrupoProduto = "";
								if (!dtrwProdutoFaturaComercial.IsmstrPersonalizavelNull())
									strGrupoProduto = dtrwProdutoFaturaComercial.mstrPersonalizavel;
								if (strGrupo == strGrupoProduto)
								{
									string strDescricaoProduto = "";
									if ((!dtrwProdutoFaturaComercial.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFaturaComercial.mstrDescricaoLinguaEstrangeira != ""))
										strDescricaoProduto = dtrwProdutoFaturaComercial.mstrDescricaoLinguaEstrangeira;
									else if ((!dtrwProdutoFaturaComercial.IsmstrDescricaoNull()) && (dtrwProdutoFaturaComercial.mstrDescricao != ""))
										strDescricaoProduto = dtrwProdutoFaturaComercial.mstrDescricao;
									else
										strDescricaoProduto = strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,nIdExportador,m_nIdioma,dtrwProdutoFaturaComercial.idProduto);
									while(sortLstProdutosPrincipais.Contains(strDescricaoProduto))
										strDescricaoProduto += "X";
									sortLstProdutosPrincipais.Add(strDescricaoProduto,dtrwProdutoFaturaComercial);
								}
							}
						}
					}
					// Inserindo 
					if (sortLstProdutosPrincipais.Count > 0)
					{
						// Inserindo Grupo
						if (!bMostrarGrupo)
							strGrupo = "";
						vInsereFaturaComercialGrupo(ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,strGrupo);

						// Inserindo os Produtos Principais
						double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
						for(int nCont = 0; nCont < sortLstProdutosPrincipais.Count;nCont++)
						{
							dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)sortLstProdutosPrincipais.GetByIndex(nCont);
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade,2);
							vInsereProdutoFaturaComercial(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas, ref typDatSetTbProdutosFaturaComercial,ref nIdExportador,ref strIdCodigo,ref arlColunaAtual_Descricao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_Unidade,ref arlColunaAtual_PrecoUnitario,ref arlColunaAtual_SubTotal,ref arlColunaAtual_Codigo,ref arlColunaAtual_Ordem,ref arlColunaAtual_OrdemSequencial,bDetalharProdutos,m_strDelimitadorNulo,true,dPrecoUnitarioProduto,dSubTotalProduto,ref dtrwProdutoFaturaComercial);
						}
					}
				}

				arlRetorno.Add(arlColunaAtual_Descricao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_Unidade);
				arlRetorno.Add(arlColunaAtual_PrecoUnitario);
				arlRetorno.Add(arlColunaAtual_SubTotal);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_OrdemSequencial);
				return(arlRetorno);
			}

			private void vInsereFaturaComercialGrupo(ref System.Collections.ArrayList arlColunaAtual_Descricao,ref System.Collections.ArrayList arlColunaAtual_Quantidade,ref System.Collections.ArrayList arlColunaAtual_Unidade,ref System.Collections.ArrayList arlColunaAtual_PrecoUnitario,ref System.Collections.ArrayList arlColunaAtual_SubTotal,ref System.Collections.ArrayList arlColunaAtual_Codigo,ref System.Collections.ArrayList arlColunaAtual_Ordem,ref System.Collections.ArrayList arlColunaAtual_OrdemSequencial,string strGrupo)
			{
				DataStruct structData;

				OrdemProdutosInsere();

				// Descricao
				structData = new DataStruct();
				structData.strText = strGrupo;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				structData.fntText = new System.Drawing.Font("Arial",8,System.Drawing.FontStyle.Bold);
				arlColunaAtual_Descricao.Add(structData);

				// Codigo
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Codigo.Add(structData);

				// Ordem
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Ordem.Add(structData);

				// OrdemSequencial
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_OrdemSequencial.Add(structData);

				// Quantidade
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Quantidade.Add(structData);

				// Unidade
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_Unidade.Add(structData);

				// Preco Unitario
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_PrecoUnitario.Add(structData);

				// SubTotal
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlColunaAtual_SubTotal.Add(structData);
			}
		#endregion
		#region #03 Fatura Comercial - ShowDialog 
			private System.Collections.ArrayList arlShowDialogFaturaComercial(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosLancamento.clsLancamentoProdutos cls_prod = new mdlProdutosLancamento.clsLancamentoProdutosFaturaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref m_ilBandeiras,nIdExportador,strIdCodigo);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #04 Certificado de Origem Mercosul
		#region #04 Certificado de Origem Mercosul - Carregamento de Dados 
			private bool bCarregaConfiguracoesCertificadoOrigem(int nIdExportador,string strIdCodigo,int nIdCertificado,out bool bMostrarProdutos,out bool bMostrarProdutosFilhos)
			{
				bMostrarProdutos = bMostrarProdutosFilhos = false;

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				arlCondicaoCampo.Add("nIdTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdCertificado);
                
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetCertificadoOrigem.tbCertificadosOrigem.Rows.Count == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadoOrigem.tbCertificadosOrigem.Rows[0];
				if (!dtrwCertificadoOrigem.IsbMostrarProdutosNull())
					bMostrarProdutos = dtrwCertificadoOrigem.bMostrarProdutos;
				if (!dtrwCertificadoOrigem.IsbMostrarProdutosFilhosNull())
					bMostrarProdutosFilhos = dtrwCertificadoOrigem.bMostrarProdutosFilhos;
				return(true);
			}

			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOMercosul(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,1,out bMostrarProdutos,out bMostrarProdutosFilhos);

				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4004");
				arlColunaAtual_Codigo.Add("4104");
				arlColunaAtual_Denominacao.Add("4204");
				arlColunaAtual_Quantidade.Add("4304");
				arlColunaAtual_ValorFob.Add("4404");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
                arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(1);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
					}
				}
				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Produtos do Certificado

				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNcmProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNcm(ref typDatSetTbProdutos,ref typDatSetTbProdutosNcm,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							// Calculo 
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = System.Math.Round(dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade,2);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
		                            dAcumuladorSubTotal = System.Math.Round(dAcumuladorSubTotal + dSubTotalProduto,2);
		                            dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}else{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,1,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}else{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,1,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}

			private void InsereLinhaCertificadoOrigemMercosul(int nIdExportador,string strIdCodigo,int nIdTipoCO,ref System.Collections.ArrayList arlOrdem,ref System.Collections.ArrayList arlCodigo,ref System.Collections.ArrayList arlDenominacao,ref System.Collections.ArrayList arlQuantidade,ref System.Collections.ArrayList arlValorFob,string strOrdem,string strCodigo,string strDenominacao,string strQuantidade,string strValorFob,bool bMostrarProdutos,bool bMostrarProdutosFilhos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem,System.Collections.ArrayList arlProdutosFatura)
			{
				DataStruct structData;

				// Ordem
				structData = new DataStruct();
				structData.strText = strOrdem;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlOrdem.Add(structData);

				// Codigo
				structData = new DataStruct();
				structData.strText = strCodigo;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlCodigo.Add(structData);

				// Denominacao
				structData = new DataStruct();
				structData.strText = strDenominacao;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlDenominacao.Add(structData);

				// Quantidade
				structData = new DataStruct();
				structData.strText = strQuantidade;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlQuantidade.Add(structData);

				// ValorFob
				structData = new DataStruct();
				structData.strText = strValorFob;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlValorFob.Add(structData);

				if (bMostrarProdutos)
				{
					for (int i = 0; i < arlProdutosFatura.Count;i++)
					{
						int nIdOrdem = Int32.Parse(arlProdutosFatura[i].ToString());
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,nIdOrdem);
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem = typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(nIdExportador,strIdCodigo,nIdTipoCO,nIdOrdem);
						if ((dtrwProdutoFatura != null) && (dtrwProdutoCertificadoOrigem != null))
						{
							InsereProdutoCertificadoOrigem(ref arlOrdem,ref arlCodigo,ref arlDenominacao,ref arlQuantidade,ref arlValorFob,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,dtrwProdutoFatura,dtrwProdutoCertificadoOrigem,"   ");
						}
					}
				}
			}

			private void InsereProdutoCertificadoOrigem(ref System.Collections.ArrayList arlOrdem,ref System.Collections.ArrayList arlCodigo,ref System.Collections.ArrayList arlDenominacao,ref System.Collections.ArrayList arlQuantidade,ref System.Collections.ArrayList arlValorFob,bool bMostrarProdutosFilhos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial,mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura,mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem,string strDelimitador)
			{
				DataStruct structData;

				// Ordem
				structData = new DataStruct();
				arlOrdem.Add(structData);

				// Codigo
				structData = new DataStruct();
				arlCodigo.Add(structData);

				// Denominacao
				structData = new DataStruct();
				if ((dtrwProdutoCertificadoOrigem != null) && (!dtrwProdutoCertificadoOrigem.IsmstrDescricaoNull()) && (dtrwProdutoCertificadoOrigem.mstrDescricao != ""))
				{
					structData.strText = dtrwProdutoCertificadoOrigem.mstrDescricao;
				}else{
					if ((!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull()) && (dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira != ""))
						structData.strText = dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira;
					else if (!dtrwProdutoFatura.IsmstrDescricaoNull())
						structData.strText = dtrwProdutoFatura.mstrDescricao;
					else
						structData.strText = strRetornaDescricaoProduto(ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,dtrwProdutoFatura.idExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
				}
				structData.strText = strDelimitador + structData.strText;
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlDenominacao.Add(structData);

				// Quantidaden
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlQuantidade.Add(structData);

				// ValorFob
				structData = new DataStruct();
				structData.strText = "";
				structData.nHeight = m_nHeight;
				structData.nWidth = m_nWidth;
				arlValorFob.Add(structData);

				if (bMostrarProdutosFilhos)
				{
					for(int i = 0; i < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFilho = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[i];
						if ((!dtrwProdutoFilho.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFilho.nIdOrdemProdutoParent == dtrwProdutoFatura.idOrdem))
							InsereProdutoCertificadoOrigem(ref arlOrdem,ref arlCodigo,ref arlDenominacao,ref arlQuantidade,ref arlValorFob,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,dtrwProdutoFilho,null,strDelimitador + strDelimitador);
					}
				}
			}
		#endregion
		#region #04 Certificado de Origem Mercosul - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosul(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosul(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #05 Certificado de Origem Mercosul / Bolivia 
		#region #05 Certificado de Origem Mercosul / Bolivia - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOMercosulBolivia(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,2,out bMostrarProdutos,out bMostrarProdutosFilhos);

				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4005");
				arlColunaAtual_Codigo.Add("4105");
				arlColunaAtual_Denominacao.Add("4205");
				arlColunaAtual_Quantidade.Add("4305");
				arlColunaAtual_ValorFob.Add("4405");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(2);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

				// Produtos do Certificado
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutos,ref typDatSetTbProdutosNaladi,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = (dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
									dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
									dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
								else
								{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,2,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
							else
							{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,2,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}
		#endregion
		#region #05 Certificado de Origem Mercosul / Bolivia - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosulBolivia(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulBolivia(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #06 Certificado de Origem Mercosul / Chile
		#region #06 Certificado de Origem Mercosul / Chile - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOMercosulChile(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,3,out bMostrarProdutos,out bMostrarProdutosFilhos);

				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4006");
				arlColunaAtual_Codigo.Add("4106");
				arlColunaAtual_Denominacao.Add("4206");
				arlColunaAtual_Quantidade.Add("4306");
				arlColunaAtual_ValorFob.Add("4406");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(3);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Calculo
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;
 
				// Produtos do Certificado
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutos,ref typDatSetTbProdutosNaladi,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = (dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
									dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
									dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
								else
								{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,3,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
							else
							{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,3,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref  typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}
		#endregion
		#region #06 Certificado de Origem Mercosul / Chile - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosulChile(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulChile(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #07 Certificado de Origem Aladi Aptr04
		#region #07 Certificado de Origem Aladi Aptr04 - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOAladiAptr04(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,4,out bMostrarProdutos,out bMostrarProdutosFilhos);

				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4007");
				arlColunaAtual_Codigo.Add("4107");
				arlColunaAtual_Denominacao.Add("4207");
				arlColunaAtual_Quantidade.Add("4307");
				arlColunaAtual_ValorFob.Add("4407");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(4);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

				// Produtos do Certificado
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutos,ref typDatSetTbProdutosNaladi,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = (dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
									dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
									dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
								else
								{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,4,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
							else
							{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,4,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}
		#endregion
		#region #07 Certificado de Origem Aladi Aptr04 - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosulAladiAptr04(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemAladiAptr04(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #08 Certificado de Origem Aladi Ace39
		#region #08 Certificado de Origem Aladi Ace39 - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOAladiAce39(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,5,out bMostrarProdutos,out bMostrarProdutosFilhos);

				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4008");
				arlColunaAtual_Codigo.Add("4108");
				arlColunaAtual_Denominacao.Add("4208");
				arlColunaAtual_Quantidade.Add("4308");
				arlColunaAtual_ValorFob.Add("4408");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(5);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Calculo 
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

				// Produtos do Certificado
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutos,ref typDatSetTbProdutosNaladi,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
									dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
									dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
								else
								{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,5,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
							else
							{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,5,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref  typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}
		#endregion
		#region #08 Certificado de Origem Aladi Ace39 - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosulAladiAce39(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce39(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #09 Certificado de Origem Anexo III
		#region #09 Certificado de Origem Anexo III - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOAnexoIII(int nIdExportador,string strIdCodigo)
			{
				System.Collections.ArrayList arlRetorno = null;
				return(arlRetorno);
			}
		#endregion
		#region #09 Certificado de Origem Anexo III - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOAnexoIII(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemAnexoIII(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #10 Certificado de Origem Comum
		#region #10 Certificado de Origem Comum - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOComum(int nIdExportador,string strIdCodigo)
			{
				bool bMostrarProdutos,bMostrarProdutosFilhos;
				bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,7,out bMostrarProdutos,out bMostrarProdutosFilhos);


				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Ordem.Add("4010");
				arlColunaAtual_Codigo.Add("4110");
				arlColunaAtual_Denominacao.Add("4210");
				arlColunaAtual_Quantidade.Add("4310");
				arlColunaAtual_ValorFob.Add("4410");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				m_nHeight = RELATORIO_HEIGHT_NORMAL;
				m_nWidth = RELATORIO_WIDTH_NORMAL;

				// Condicoes
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				// TypedDataSets
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetTbProdutosNcm;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

				// TypedDataRows
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

				// TypDatSetTbProdutosNcm
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutos
				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				// TypDatSetTbProdutosFaturaComercial
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


				// TypedDataSetTbFaturasComerciais
				typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
				if (dtrwFatura != null)
				{
					// Moeda 
					if (!dtrwFatura.IsidMoedaNull())
						m_nIdMoeda = dtrwFatura.idMoeda;
				}

				// TypDatSetTbProdutosCertificadoOrigem
				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);
				arlCondicaoCampo.Add("idTipoCO");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(7);
				arlOrdenacaoCampo.Add("idOrdem");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
				typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				// Produtos Principais
				System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				int nIdOrdemProdutoParent = -1;
				for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
				{
					dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
					if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
					{
						nIdOrdemProdutoParent = 0;
						if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
							nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
						if (nIdOrdemProdutoParent == 0)
						{
							sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
						}
					}
				}

				double dAcumuladorSubTotal = 0;
				double dAcumuladorQuantidade = 0;
				int nlUltimoIdOrdemUtilizado = -1;
				string strUltimoCodigoUtilizado = "";
				string strUltimaDenominacaoUtilizada = "";
				string strUltimaUnidadeUtilizada = "";
				string strCodigo = "";
				string strDenominacao = ""; 

				// Calculo
				mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
				cls_man_Valor.FaturaOutput = false;
				cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;
                
				// Produtos do Certificado
				double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
				System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
				for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
				{
					dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
					if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
					{
						dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
						strCodigo = strRetornaNcmProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
						strDenominacao = strRetornaDenominacaoNcm(ref typDatSetTbProdutos,ref typDatSetTbProdutosNcm,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
						if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
						{
							cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
							dSubTotalProduto = (dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade);

							// ORDEM
							if (nlUltimoIdOrdemUtilizado != -1)
							{
								if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
								{
									dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
									dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
								else
								{
									// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
									InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,7,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Clear();
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
							else
							{
								// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
								nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
								strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
								strUltimoCodigoUtilizado = strCodigo;
								strUltimaDenominacaoUtilizada = strDenominacao;
								dAcumuladorSubTotal = dSubTotalProduto;
								dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
								arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
							}
						}
					}
				}
				if (nlUltimoIdOrdemUtilizado != -1)
					InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,7,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

				arlRetorno.Add(arlColunaAtual_Ordem);
				arlRetorno.Add(arlColunaAtual_Codigo);
				arlRetorno.Add(arlColunaAtual_Denominacao);
				arlRetorno.Add(arlColunaAtual_Quantidade);
				arlRetorno.Add(arlColunaAtual_ValorFob);
				return(arlRetorno);
			}
		#endregion
		#region #10 Certificado de Origem Comum - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOComum(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.SemNormas.clsProdutosCertificadoOrigemComum(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #11 Romaneio - Produtos
		#region #11 Romaneio - Carregamento de Dados 
			#region Romaneio - Ordenacao 
				private System.Collections.ArrayList arlRetornaDadosAreaProdutosRomaneio_Produtos(int nIdExportador,string strIdCodigo)
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

					int nIdioma = 1;
					bool bMostrarVolumesConsecutivos = false;
					bool bMostrarEmbalagensConsecutivas = false;
					bool bMostrarQuantidadeTotalVolumes = false;
					bool bReplicarInformacoesVolumes = false;
					int nQuantidadeTotalVolumes = 0;
                    
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);

					// Loading DataSets 
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetUnidadesEspaco = m_cls_dba_ConnectionDB.GetTbUnidadesEspaco(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);


					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCodigo);
					
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetVolumes = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null); 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Ordenacao
					if (typDatSetRomaneios.tbRomaneios.Rows.Count > 0)
					{
                        mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetRomaneios.tbRomaneios.Rows[0];
						// Idioma 
						if (!dtrwRomaneio.IsnIdIdiomaNull())
							nIdioma = dtrwRomaneio.nIdIdioma;

						// Mostrar Volumes Consecutivos 
						bMostrarVolumesConsecutivos = dtrwRomaneio.bMostrarVolumesConsecutivos;
						
						// Mostar Embalagens Consecutivas 
						bMostrarEmbalagensConsecutivas = dtrwRomaneio.bMostrarEmbalagensConsecutivas;

						// Replicar Informacoes Volumes
						bReplicarInformacoesVolumes = (!dtrwRomaneio.IsbReplicarInformacoesVolumesNull() && dtrwRomaneio.bReplicarInformacoesVolumes);

						// Mostrar Quantidade Total Volumes
						bMostrarQuantidadeTotalVolumes = ((!dtrwRomaneio.IsbMostrarTotalVolumesNull()) && (dtrwRomaneio.bMostrarTotalVolumes));
						nQuantidadeTotalVolumes = typDatSetVolumes.tbProdutosRomaneioVolumes.Rows.Count;
						
						// Loading DataSets
						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();
						arlCondicaoCampo.Add("idExportador");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdExportador);
						arlCondicaoCampo.Add("idIdioma");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdioma);
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();
						arlCondicaoCampo.Add("nIdIdioma");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdioma);
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetUnidadesEspacoIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesEspacoIdioma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						{
							// Montando o retorno 
							System.Collections.ArrayList arlColuna_Volume_Numero,arlColuna_Volume_TipoPopular,arlColuna_Volume_Largura,arlColuna_Volume_Altura,arlColuna_Volume_Comprimento,arlColuna_Volume_Volume,arlColuna_Volume_PesoLiquido,arlColuna_Volume_PesoBruto,arlColuna_ProdutoVolume_Descricao,arlColuna_ProdutoVolume_Quantidade,arlColuna_ProdutoVolume_PesoLiquido,arlColuna_ProdutoVolume_Codigo,arlColuna_ProdutoVolume_Ordem,arlColuna_ProdutoVolume_OrdemSequencial,arlColuna_Embalagem_Numero,arlColuna_ProdutoEmbalagem_Descricao,arlColuna_ProdutoEmbalagem_Quantidade,arlColuna_ProdutoEmbalagem_PesoLiquido,arlColuna_ProdutoEmbalagem_Codigo,arlColuna_ProdutoEmbalagem_Ordem,arlColuna_ProdutoEmbalagem_OrdemSequencial; 
							vRomaneioCreateArrayLists(out arlColuna_Volume_Numero,out arlColuna_Volume_TipoPopular,out arlColuna_Volume_Largura,out arlColuna_Volume_Altura,out arlColuna_Volume_Comprimento,out arlColuna_Volume_Volume,out arlColuna_Volume_PesoLiquido,out arlColuna_Volume_PesoBruto,out arlColuna_ProdutoVolume_Descricao,out arlColuna_ProdutoVolume_Quantidade,out arlColuna_ProdutoVolume_PesoLiquido,out arlColuna_ProdutoVolume_Codigo,out arlColuna_ProdutoVolume_Ordem,out arlColuna_ProdutoVolume_OrdemSequencial,out arlColuna_Embalagem_Numero,out arlColuna_ProdutoEmbalagem_Descricao,out arlColuna_ProdutoEmbalagem_Quantidade,out arlColuna_ProdutoEmbalagem_PesoLiquido,out arlColuna_ProdutoEmbalagem_Codigo,out arlColuna_ProdutoEmbalagem_Ordem,out arlColuna_ProdutoEmbalagem_OrdemSequencial);
							arlRetorno.Add(arlColuna_Volume_Numero);
							arlRetorno.Add(arlColuna_Volume_TipoPopular);
							arlRetorno.Add(arlColuna_Volume_Largura);
							arlRetorno.Add(arlColuna_Volume_Altura);
							arlRetorno.Add(arlColuna_Volume_Comprimento);
							arlRetorno.Add(arlColuna_Volume_Volume);
							arlRetorno.Add(arlColuna_Volume_PesoLiquido);
							arlRetorno.Add(arlColuna_Volume_PesoBruto);
							
							arlRetorno.Add(arlColuna_ProdutoVolume_Descricao);
							arlRetorno.Add(arlColuna_ProdutoVolume_Quantidade);
							arlRetorno.Add(arlColuna_ProdutoVolume_PesoLiquido);
							arlRetorno.Add(arlColuna_ProdutoVolume_Codigo);
							arlRetorno.Add(arlColuna_ProdutoVolume_Ordem);
							arlRetorno.Add(arlColuna_ProdutoVolume_OrdemSequencial);

							arlRetorno.Add(arlColuna_Embalagem_Numero);

							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Descricao);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Quantidade);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_PesoLiquido);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Codigo);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Ordem);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_OrdemSequencial);

							mdlProdutosRomaneio.Ordenacao enumOrdenacao = (mdlProdutosRomaneio.Ordenacao)dtrwRomaneio.nTipoOrdenacao;
							vRomaneioOrdenacaoProdutoInsereProdutos(ref arlColuna_Volume_Numero,ref arlColuna_Volume_TipoPopular,ref arlColuna_Volume_Largura,ref arlColuna_Volume_Altura,ref arlColuna_Volume_Comprimento,ref arlColuna_Volume_Volume,ref arlColuna_Volume_PesoLiquido,ref arlColuna_Volume_PesoBruto,ref arlColuna_ProdutoVolume_Descricao,ref arlColuna_ProdutoVolume_Quantidade,ref arlColuna_ProdutoVolume_PesoLiquido,ref arlColuna_ProdutoVolume_Codigo,ref arlColuna_ProdutoVolume_Ordem,ref arlColuna_ProdutoVolume_OrdemSequencial,ref arlColuna_Embalagem_Numero,ref arlColuna_ProdutoEmbalagem_Descricao,ref arlColuna_ProdutoEmbalagem_Quantidade,ref arlColuna_ProdutoEmbalagem_PesoLiquido,ref arlColuna_ProdutoEmbalagem_Codigo,ref arlColuna_ProdutoEmbalagem_Ordem,ref arlColuna_ProdutoEmbalagem_OrdemSequencial,ref  typDatSetProdutos,ref typDatSetProdutosIdiomas ,ref typDatSetFaturasComerciais,ref typDatSetProdutosFaturaComercial,ref  typDatSetRomaneios,ref  typDatSetVolumes,ref  typDatSetVolumesProdutos,ref  typDatSetEmbalagens,ref typDatSetEmbalagensProdutos,ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,nIdExportador,strIdCodigo,nIdioma,bMostrarVolumesConsecutivos,bMostrarEmbalagensConsecutivas,bMostrarQuantidadeTotalVolumes,bReplicarInformacoesVolumes,nQuantidadeTotalVolumes);
						}
					}
					return(arlRetorno);
				}
			#endregion
			#region Criando ArrayLists Retorno
				private void vRomaneioCreateArrayLists(out System.Collections.ArrayList arlColuna_Volume_Numero,out System.Collections.ArrayList arlColuna_Volume_TipoPopular,out System.Collections.ArrayList arlColuna_Volume_Largura,out System.Collections.ArrayList arlColuna_Volume_Altura,out System.Collections.ArrayList arlColuna_Volume_Comprimento,out System.Collections.ArrayList arlColuna_Volume_Volume,out System.Collections.ArrayList arlColuna_Volume_PesoLiquido,out System.Collections.ArrayList arlColuna_Volume_PesoBruto,out System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,out System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,out System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,out System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,out System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,out System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,out System.Collections.ArrayList arlColuna_Embalagem_Numero,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,out System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial)
				{
					arlColuna_Volume_Numero = new System.Collections.ArrayList();
					arlColuna_Volume_TipoPopular = new System.Collections.ArrayList();
					arlColuna_Volume_Largura = new System.Collections.ArrayList();
					arlColuna_Volume_Altura = new System.Collections.ArrayList();
					arlColuna_Volume_Comprimento = new System.Collections.ArrayList();
					arlColuna_Volume_Volume = new System.Collections.ArrayList();
					arlColuna_Volume_PesoLiquido = new System.Collections.ArrayList();
					arlColuna_Volume_PesoBruto = new System.Collections.ArrayList();

					arlColuna_ProdutoVolume_Descricao = new System.Collections.ArrayList();
					arlColuna_ProdutoVolume_Quantidade = new System.Collections.ArrayList();
					arlColuna_ProdutoVolume_PesoLiquido = new System.Collections.ArrayList();
					arlColuna_ProdutoVolume_Codigo = new System.Collections.ArrayList();
					arlColuna_ProdutoVolume_Ordem = new System.Collections.ArrayList();
					arlColuna_ProdutoVolume_OrdemSequencial = new System.Collections.ArrayList();

					arlColuna_Embalagem_Numero = new System.Collections.ArrayList();

					arlColuna_ProdutoEmbalagem_Descricao = new System.Collections.ArrayList();
					arlColuna_ProdutoEmbalagem_Quantidade = new System.Collections.ArrayList(); 
					arlColuna_ProdutoEmbalagem_PesoLiquido = new System.Collections.ArrayList();
					arlColuna_ProdutoEmbalagem_Codigo = new System.Collections.ArrayList();
					arlColuna_ProdutoEmbalagem_Ordem = new System.Collections.ArrayList();
					arlColuna_ProdutoEmbalagem_OrdemSequencial = new System.Collections.ArrayList();

					arlColuna_Volume_Numero.Add("4011");
					arlColuna_Volume_TipoPopular.Add("4111");
					arlColuna_Volume_Largura.Add("4211");
					arlColuna_Volume_Altura.Add("4311");
					arlColuna_Volume_Comprimento.Add("4411");
					arlColuna_Volume_Volume.Add("4511");
					arlColuna_Volume_PesoLiquido.Add("4611");
					arlColuna_Volume_PesoBruto.Add("4711");

					arlColuna_ProdutoVolume_Descricao.Add("5011");
					arlColuna_ProdutoVolume_Quantidade.Add("5111");
					arlColuna_ProdutoVolume_PesoLiquido.Add("5211");
					arlColuna_ProdutoVolume_Codigo.Add("7411");
					arlColuna_ProdutoVolume_Ordem.Add("4811");
					arlColuna_ProdutoVolume_OrdemSequencial.Add("6111");
					
					arlColuna_Embalagem_Numero.Add("6011");

					arlColuna_ProdutoEmbalagem_Descricao.Add("7011");
					arlColuna_ProdutoEmbalagem_Quantidade.Add("7111");
					arlColuna_ProdutoEmbalagem_PesoLiquido.Add("7211");
					arlColuna_ProdutoEmbalagem_Codigo.Add("7311");
					arlColuna_ProdutoEmbalagem_Ordem.Add("4911");
					arlColuna_ProdutoEmbalagem_OrdemSequencial.Add("6211");
				} 
			#endregion
			#region Romaneio - Ordenacao - Produtos
				private void vRomaneioCarregaPreferencias(out int nRomaneioPrecisaoPesoLiquidoItens,out int nRomaneioPrecisaoPesoLiquidoTotal,out int nRomaneioPrecisaoPesoBrutoItens,out int nRomaneioPrecisaoPesoBrutoTotal,out bool bRomaneioPrecisaoPesoLiquidoItensArredondar,out bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bool bRomaneioPrecisaoPesoBrutoItensArredondar,out bool bRomaneioPrecisaoPesoBrutoTotalArredondar)
				{
					nRomaneioPrecisaoPesoLiquidoItens = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS,2);
					nRomaneioPrecisaoPesoLiquidoTotal = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,2);
					nRomaneioPrecisaoPesoBrutoItens = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS,2);
					nRomaneioPrecisaoPesoBrutoTotal = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL,2);
					bRomaneioPrecisaoPesoLiquidoItensArredondar = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS_ARREDONDAR,true);
					bRomaneioPrecisaoPesoLiquidoTotalArredondar = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,true);
					bRomaneioPrecisaoPesoBrutoItensArredondar = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS_ARREDONDAR,true);
					bRomaneioPrecisaoPesoBrutoTotalArredondar = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,true);
				}

				private string strRetornaFormato(int nDecimals)
				{
					string strRetorno = "###,###,###,##0";
					if (nDecimals > 0)
						strRetorno += ".";
					for(int i = 0; i < nDecimals;i++)
						strRetorno += "0";
					return(strRetorno);
				}

				private void vRomaneioOrdenacaoProdutoInsereProdutos(ref System.Collections.ArrayList arlColuna_Volume_Numero,ref System.Collections.ArrayList arlColuna_Volume_TipoPopular,ref System.Collections.ArrayList arlColuna_Volume_Largura,ref System.Collections.ArrayList arlColuna_Volume_Altura,ref System.Collections.ArrayList arlColuna_Volume_Comprimento,ref System.Collections.ArrayList arlColuna_Volume_Volume,ref System.Collections.ArrayList arlColuna_Volume_PesoLiquido,ref System.Collections.ArrayList arlColuna_Volume_PesoBruto,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,ref System.Collections.ArrayList arlColuna_Embalagem_Numero,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial,
					ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas ,ref mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetUnidadesEspaco,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetUnidadesEspacoIdioma,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma,int nIdExportador,string strIdPe,int nIdioma,bool bMostrarVolumesConsecutivos,bool bMostrarEmbalagensConsecutivas,bool bMostrarQuantidadeTotalVolumes,bool bReplicarInformacoesVolumes,int nQuantidadeTotalVolumes)
				{
					string strUltimoVolume = "";
					string strUltimaEmbalagem = "";
					string strDescricaoProduto = "";
					string strDescricaoProdutoPesquisa = "";

					// Preferencias 
					int nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
					vRomaneioCarregaPreferencias(out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);

					//Ordenando
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					// Produtos dos Volumes
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolumes in typDatSetVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
					{
						int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolumes.nIdOrdemProduto);
						if (nIdProduto != -1)
						{
							strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoVolumes.nIdOrdemProduto);
							if (!sortLstProdutos.Contains(strDescricaoProduto))
								sortLstProdutos.Add(strDescricaoProduto,strDescricaoProduto);
						}
					}
					// Produtos da Embalagem
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagens in typDatSetEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
					{
						int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagens.nIdOrdemProduto);
						if (nIdProduto != -1)
						{
							strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoEmbalagens.nIdOrdemProduto);
							if (!sortLstProdutos.Contains(strDescricaoProduto))
								sortLstProdutos.Add(strDescricaoProduto,strDescricaoProduto);
						}
					}

					// Inserindo Produtos
					object objProduto;
					DataStruct structData;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolume;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagem;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume; 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem; 

					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						strDescricaoProduto = sortLstProdutos.GetByIndex(nCont).ToString();
						//Ordenando Volume/Embalagens
						System.Collections.SortedList sortLstVolumes = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
						// Produtos dos Volumes
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoVolumes in typDatSetVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
						{
							int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolumes.nIdOrdemProduto);
							if (nIdProduto != -1)
							{
								strDescricaoProdutoPesquisa = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoVolumes.nIdOrdemProduto);
								if (strDescricaoProduto == strDescricaoProdutoPesquisa)
								{
									if (!sortLstVolumes.Contains(dtrwProdutoVolumes.strNumeroVolume))
										sortLstVolumes.Add(dtrwProdutoVolumes.strNumeroVolume,dtrwProdutoVolumes);
								}
							}
						}
						// Produtos da Embalagem
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutoEmbalagens in typDatSetEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
						{
							int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagens.nIdOrdemProduto);
							if (nIdProduto != -1)
							{
								strDescricaoProdutoPesquisa = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoEmbalagens.nIdOrdemProduto);
								if (strDescricaoProduto == strDescricaoProdutoPesquisa)
								{
									dtrwEmbalagem = typDatSetEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(nIdExportador,strIdPe,dtrwProdutoEmbalagens.strIdEmbalagem);
									if (dtrwEmbalagem != null)
									{
										if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
										{
											dtrwVolume = typDatSetVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,dtrwEmbalagem.strNumeroVolume);
											if (dtrwVolume != null)
												if (!sortLstVolumes.Contains(dtrwProdutoEmbalagens.strIdEmbalagem))
													sortLstVolumes.Add(dtrwProdutoEmbalagens.strIdEmbalagem,dtrwProdutoEmbalagens);
										}
									}
								}
							}
						}

						// Replicar Informacoes Volumes
						System.Collections.ArrayList arlVolumesInseridos = new System.Collections.ArrayList();

						for(int i = 0; i < sortLstVolumes.Count;i++)
						{
							bool bInsereInformacoesVolume = false;
							objProduto = sortLstVolumes.GetByIndex(i);
							if (objProduto.GetType().ToString() == "mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos+tbProdutosRomaneioVolumesProdutosRow")
							{
								// Produto Volume 
								dtrwProdutoVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)objProduto;
								dtrwVolume = typDatSetVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,dtrwProdutoVolume.strNumeroVolume);

								if (dtrwVolume != null)
								{
									if (bReplicarInformacoesVolumes)
										bInsereInformacoesVolume = true;
									else
										bInsereInformacoesVolume = !arlVolumesInseridos.Contains(dtrwVolume.strNumeroVolume);

									// Volume 
									// Numero
									structData = new DataStruct();
									structData.strText = dtrwVolume.strNumeroVolume;
									if (bMostrarQuantidadeTotalVolumes)
										structData.strText = structData.strText + "/" + nQuantidadeTotalVolumes.ToString();

									arlColuna_Volume_Numero.Add(structData);
									// TipoPopular
									structData = new DataStruct();
									if (!dtrwVolume.IsstrTipoPopularNull())
									{
										if (bMostrarVolumesConsecutivos)
										{
											structData.strText = dtrwVolume.strTipoPopular;
										}
										else
										{
											if (dtrwVolume.strTipoPopular != strUltimoVolume)
											{
												structData.strText = dtrwVolume.strTipoPopular;
												strUltimoVolume = dtrwVolume.strTipoPopular;
											}
										}
									}
									else
									{
										strUltimoVolume = "";
									}
									arlColuna_Volume_TipoPopular.Add(structData);
									// Largura 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdLarguraNull()))
									{
										structData.strText = dtrwVolume.dLargura.ToString();
										if (!dtrwVolume.IsnUnidadeLarguraNull())
										{
											structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeLargura,nIdioma);
										}
									}
									arlColuna_Volume_Largura.Add(structData);
									// Altura 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdAlturaNull()))
									{
										structData.strText = dtrwVolume.dAltura.ToString();
										if (!dtrwVolume.IsnUnidadeAlturaNull())
										{
											structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeAltura,nIdioma);
										}
									}
									arlColuna_Volume_Altura.Add(structData);
									// Comprimento 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdComprimentoNull()))
									{
										structData.strText = dtrwVolume.dComprimento.ToString();
										if (!dtrwVolume.IsnUnidadeComprimentoNull())
										{
											structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeComprimento,nIdioma);
										}
									}
									arlColuna_Volume_Comprimento.Add(structData);
									// Volume 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdVolumeNull()))
									{
										structData.strText = dtrwVolume.dVolume.ToString();
										if (!dtrwVolume.IsnUnidadeVolumeNull())
										{
											structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeVolume,nIdioma) + "³";
										}
									}
									arlColuna_Volume_Volume.Add(structData);
									// Peso Liquido 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdPesoLiquidoNull()))
									{
										if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
											structData.strText = System.Math.Round(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
										else
											structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
										if (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull())
										{
											structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoLiquido,nIdioma);
										}
									}
									arlColuna_Volume_PesoLiquido.Add(structData);
									// Peso Bruto 
									structData = new DataStruct();
									if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdPesoBrutoNull()))
									{
										if (bRomaneioPrecisaoPesoBrutoItensArredondar)
											structData.strText = System.Math.Round(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
										else
											structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
										if (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull())
										{
											structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoBruto,nIdioma);
										}
									}
									arlColuna_Volume_PesoBruto.Add(structData);
									// Produto Volume
									// Descricao
									structData = new DataStruct();
									this.OrdemProdutosInsere(dtrwProdutoVolume.nIdOrdemProduto);
									int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolume.nIdOrdemProduto);
									strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoVolume.nIdOrdemProduto);
									if (bIsChild(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolume.nIdOrdemProduto))
										strDescricaoProduto = m_strDelimitadorRomaneioUsar + strDescricaoProduto;
								
									structData.strText = strDescricaoProduto;
									arlColuna_ProdutoVolume_Descricao.Add(structData);

									// Quantidade
									structData = new DataStruct();
									if (!dtrwProdutoVolume.IsdQuantidadeNull())
									{
										structData.strText = dtrwProdutoVolume.dQuantidade.ToString();
										structData.strText += " " + strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolume.nIdOrdemProduto);
									}
									arlColuna_ProdutoVolume_Quantidade.Add(structData);


									// Peso Liquido
									structData = new DataStruct();
									if (!dtrwProdutoVolume.IsdPesoLiquidoNull())
									{
										if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
											structData.strText = System.Math.Round(dtrwProdutoVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
										else
											structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProdutoVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
									}
									if (!dtrwProdutoVolume.IsnUnidadeMassaPesoLiquidoNull())
									{
										structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoVolume.nUnidadeMassaPesoLiquido,nIdioma);
									}
									arlColuna_ProdutoVolume_PesoLiquido.Add(structData);

                                    // Codigo
									structData = new DataStruct();
									structData.strText = strRetornaCodigoProduto(ref typDatSetProdutos,nIdExportador,nIdProduto);
									arlColuna_ProdutoVolume_Codigo.Add(structData);

									// Ordem
									structData = new DataStruct();
									structData.strText = strRetornaOrdemLancamentoProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoVolume.nIdOrdemProduto);
									arlColuna_ProdutoVolume_Ordem.Add(structData);

									// Ordem Sequencial 
									structData = new DataStruct();
									structData.strText = dtrwProdutoVolume.nIdOrdemProduto.ToString();
									arlColuna_ProdutoVolume_OrdemSequencial.Add(structData);

									// Embalagem
									arlColuna_Embalagem_Numero.Add(new DataStruct());
									// Produto Embalagem
									arlColuna_ProdutoEmbalagem_Descricao.Add(new DataStruct());
									arlColuna_ProdutoEmbalagem_Quantidade.Add(new DataStruct());
									arlColuna_ProdutoEmbalagem_PesoLiquido.Add(new DataStruct());
									arlColuna_ProdutoEmbalagem_Codigo.Add(new DataStruct());
									arlColuna_ProdutoEmbalagem_Ordem.Add(new DataStruct());
									arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(new DataStruct());

									if (!bReplicarInformacoesVolumes)
										arlVolumesInseridos.Add(dtrwVolume.strNumeroVolume);
								}
							}
							else
							{ 
								// Produto Embalagem 
								dtrwProdutoEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)objProduto;
								dtrwEmbalagem = typDatSetEmbalagens.tbProdutosRomaneioEmbalagens.FindByidExportadoridPEstrIdEmbalagem(nIdExportador,strIdPe,dtrwProdutoEmbalagem.strIdEmbalagem);
								if (dtrwEmbalagem != null)
								{
									// Volume 
									dtrwVolume = null;
									if (!dtrwEmbalagem.IsstrNumeroVolumeNull())
										dtrwVolume = typDatSetVolumes.tbProdutosRomaneioVolumes.FindByidExportadoridPEstrNumeroVolume(nIdExportador,strIdPe,dtrwEmbalagem.strNumeroVolume);
									if (dtrwVolume != null)
									{
										if (bReplicarInformacoesVolumes)
											bInsereInformacoesVolume = true;
										else
											bInsereInformacoesVolume = !arlVolumesInseridos.Contains(dtrwVolume.strNumeroVolume);

										// Numero
										structData = new DataStruct();
										structData.strText = dtrwVolume.strNumeroVolume;
										if (bMostrarQuantidadeTotalVolumes)
											structData.strText = structData.strText + "/" + nQuantidadeTotalVolumes.ToString();
										arlColuna_Volume_Numero.Add(structData);
										// TipoPopular
										structData = new DataStruct();
										if (!dtrwVolume.IsstrTipoPopularNull())
										{
											if (bMostrarVolumesConsecutivos)
											{
												structData.strText = dtrwVolume.strTipoPopular;
											}
											else
											{
												if (dtrwVolume.strTipoPopular != strUltimoVolume)
												{
													structData.strText = dtrwVolume.strTipoPopular;
													strUltimoVolume = dtrwVolume.strTipoPopular;
												}
												else
												{
													structData.strText = TEXTO_REPETICAO;
												}
											}
										}
										else
										{
											strUltimoVolume = "";
										}
										arlColuna_Volume_TipoPopular.Add(structData);
										// Largura 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdLarguraNull()))
										{
											structData.strText = dtrwVolume.dLargura.ToString();
											if (!dtrwVolume.IsnUnidadeLarguraNull())
											{
												structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeLargura,nIdioma);
											}
										}
										arlColuna_Volume_Largura.Add(structData);
										// Altura 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdAlturaNull()))
										{
											structData.strText = dtrwVolume.dAltura.ToString();
											if (!dtrwVolume.IsnUnidadeAlturaNull())
											{
												structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeAltura,nIdioma);
											}
										}
										arlColuna_Volume_Altura.Add(structData);
										// Comprimento 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdComprimentoNull()))
										{
											structData.strText = dtrwVolume.dComprimento.ToString();
											if (!dtrwVolume.IsnUnidadeComprimentoNull())
											{
												structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeComprimento,nIdioma);
											}
										}
										arlColuna_Volume_Comprimento.Add(structData);
										// Volume 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdVolumeNull()))
										{
											structData.strText = dtrwVolume.dVolume.ToString();
											if (!dtrwVolume.IsnUnidadeVolumeNull())
											{
												structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeVolume,nIdioma) + "³";
											}
										}
										arlColuna_Volume_Volume.Add(structData);
										// Peso Liquido 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdPesoLiquidoNull()))
										{
											if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
												structData.strText = System.Math.Round(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
											else
												structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
											if (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull())
											{
												structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoLiquido,nIdioma);
											}
										}
										arlColuna_Volume_PesoLiquido.Add(structData);
										// Peso Bruto 
										structData = new DataStruct();
										if ((bInsereInformacoesVolume) && (!dtrwVolume.IsdPesoBrutoNull()))
										{
											if (bRomaneioPrecisaoPesoBrutoItensArredondar)
												structData.strText = System.Math.Round(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
											else
												structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
											if (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull())
											{
												structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoBruto,nIdioma);
											}
										}
										arlColuna_Volume_PesoBruto.Add(structData);

										// Produto Volume
										arlColuna_ProdutoVolume_Descricao.Add(new DataStruct());
										arlColuna_ProdutoVolume_Quantidade.Add(new DataStruct());
										arlColuna_ProdutoVolume_PesoLiquido.Add(new DataStruct());
										arlColuna_ProdutoVolume_Codigo.Add(new DataStruct());
										arlColuna_ProdutoVolume_Ordem.Add(new DataStruct());
										arlColuna_ProdutoVolume_OrdemSequencial.Add(new DataStruct());

										// Embalagem
										structData = new DataStruct();
										if (bMostrarEmbalagensConsecutivas)
										{
											structData.strText = dtrwEmbalagem.strIdEmbalagem;
										}
										else
										{
											if (dtrwEmbalagem.strIdEmbalagem != strUltimaEmbalagem)
											{
												structData.strText = dtrwEmbalagem.strIdEmbalagem;
												strUltimaEmbalagem = dtrwEmbalagem.strIdEmbalagem;
											}
											else
											{
												structData.strText = TEXTO_REPETICAO;
											}
										}
										arlColuna_Embalagem_Numero.Add(structData);

										// Produto Embalagem 
										// Descricao
										structData = new DataStruct();
										OrdemProdutosInsere(dtrwProdutoEmbalagem.nIdOrdemProduto);
										int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagem.nIdOrdemProduto);
										strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoEmbalagem.nIdOrdemProduto);
										if (bIsChild(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagem.nIdOrdemProduto))
											strDescricaoProduto = m_strDelimitadorRomaneioUsar + strDescricaoProduto;

										structData.strText = strDescricaoProduto;
										arlColuna_ProdutoEmbalagem_Descricao.Add(structData);
										// Quantidade
										structData = new DataStruct();
										if (!dtrwProdutoEmbalagem.IsdQuantidadeNull())
										{
											structData.strText = dtrwProdutoEmbalagem.dQuantidade.ToString();
											structData.strText += strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagem.nIdOrdemProduto);
										}
										arlColuna_ProdutoEmbalagem_Quantidade.Add(structData);
										// Peso Liquido
										structData = new DataStruct();
										if ((!dtrwProdutoEmbalagem.IsdPesoLiquidoNull()) && (dtrwProdutoEmbalagem.dPesoLiquido != 0))
										{
											if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
												structData.strText = System.Math.Round(dtrwProdutoEmbalagem.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
											else
												structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProdutoEmbalagem.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
											if (!dtrwProdutoEmbalagem.IsnUnidadeMassaPesoLiquidoNull())
												structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoEmbalagem.nUnidadeMassaPesoLiquido,nIdioma);
										}
										arlColuna_ProdutoEmbalagem_PesoLiquido.Add(structData);

										// Codigo
										structData = new DataStruct();
										structData.strText = strRetornaCodigoProduto(ref typDatSetProdutos,nIdExportador,nIdProduto);
										arlColuna_ProdutoEmbalagem_Codigo.Add(structData);

										// Ordem
										structData = new DataStruct();
										structData.strText = strRetornaOrdemLancamentoProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoEmbalagem.nIdOrdemProduto);
										arlColuna_ProdutoEmbalagem_Ordem.Add(structData);

										// OrdemSequencial
										structData = new DataStruct();
										structData.strText = dtrwProdutoEmbalagem.nIdOrdemProduto.ToString();
										arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(structData);

										if (!bReplicarInformacoesVolumes)
											arlVolumesInseridos.Add(dtrwVolume.strNumeroVolume);

									}
								}
							}
						}
					}
				}
			#endregion
		#endregion
		#region #11 Romaneio - Show Dialog 
		private System.Collections.ArrayList arlShowDialogRomaneio(int nIdExportador, string strIdCodigo,ref int nStatus)
		{
			System.Collections.ArrayList arlRetorno = null;
			mdlProdutosRomaneio.clsProdutosRomaneio prodRomaneio = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
			prodRomaneio.ShowDialog();
			if (prodRomaneio.m_bModificado)
			{
				nStatus = STATUS_CARREGA_TUDO;
			}
			return(arlRetorno);
		}
		#endregion
		#endregion
		#region #12 Documentos Bancários - Borderô
		#region #12 Documentos Bancários - Borderô - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosBordero(int nIdExportador,string strIdCodigo)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Numero = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_DataEmissao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_DataVencimento = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Valor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Saldo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFatura = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorContrato = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Taxa = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Numero.Add("4012");
				arlColunaAtual_DataEmissao.Add("4112");
				arlColunaAtual_DataVencimento.Add("4212");
				arlColunaAtual_Valor.Add("4312");
				arlColunaAtual_Saldo.Add("4412");
				arlColunaAtual_ValorFatura.Add("4512");
				arlColunaAtual_ValorContrato.Add("4612");
				arlColunaAtual_Taxa.Add("4812");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				// TypedDatSets
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				int nBancoAtual = -1;
				// Banco Atual da Bordero
				mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetBorderos.tbBorderos.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwBordero = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)typDatSetBorderos.tbBorderos.Rows[0];
					if (!dtrwBordero.IsnIdBancoExportadorAtualNull())
						nBancoAtual = dtrwBordero.nIdBancoExportadorAtual;
				}


				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwFaturaComercial.IsidExportadorBancoNull())
					{
						int nBancoFatura = dtrwFaturaComercial.idExportadorBanco;
						if (nBancoAtual == -1)
							nBancoAtual = nBancoFatura; 
						int nMoedaFatura = 0;
						if (!dtrwFaturaComercial.IsidMoedaNull())
							nMoedaFatura = dtrwFaturaComercial.idMoeda;

						arlCondicaoCampo.Clear();
						arlCondicaoCampo.Add("nIdExportador");
						arlCondicaoCampo.Add("strIdPe");
						mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(null,null,null,null,null);

						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();

						arlCondicaoCampo.Add("nIdExportador");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdExportador);
						arlCondicaoCampo.Add("nIdExportadorBanco");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nBancoAtual);
						mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in typDatSetProdutosBordero.tbProdutosBordero.Rows)
						{
							mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio = typDatSetContratosCambio.tbContratosCambio.FindBynIdExportadornIdExportadorBanconIdContratoCambio(nIdExportador,nBancoAtual,dtrwProduto.nIdContratoCambio);
							if ((dtrwContratoCambio != null) && (dtrwProduto.nIdExportador == nIdExportador) && (dtrwProduto.strIdPe == strIdCodigo))
							{
								vBorderoInsereProdutos(ref arlColunaAtual_Numero,ref arlColunaAtual_DataEmissao,ref arlColunaAtual_DataVencimento,ref arlColunaAtual_Valor,ref arlColunaAtual_Saldo,ref arlColunaAtual_ValorFatura,ref arlColunaAtual_ValorContrato,ref arlColunaAtual_Taxa,nMoedaFatura,ref typDatSetProdutosBordero,dtrwContratoCambio,dtrwProduto);
							}
						}
					}
				}

				arlRetorno.Add(arlColunaAtual_Numero);
				arlRetorno.Add(arlColunaAtual_DataEmissao);
				arlRetorno.Add(arlColunaAtual_DataVencimento);
				arlRetorno.Add(arlColunaAtual_Valor);
				arlRetorno.Add(arlColunaAtual_Saldo);
				arlRetorno.Add(arlColunaAtual_ValorFatura);
				arlRetorno.Add(arlColunaAtual_ValorContrato);
				arlRetorno.Add(arlColunaAtual_Taxa);

				return(arlRetorno);
			}
			
			private void vBorderoInsereProdutos(ref System.Collections.ArrayList arlColunaAtual_Numero,ref System.Collections.ArrayList arlColunaAtual_DataEmissao,ref System.Collections.ArrayList arlColunaAtual_DataVencimento,ref System.Collections.ArrayList arlColunaAtual_Valor,ref System.Collections.ArrayList arlColunaAtual_Saldo,ref System.Collections.ArrayList arlColunaAtual_ValorFatura,ref System.Collections.ArrayList arlColunaAtual_ValorContrato,ref System.Collections.ArrayList arlColunaAtual_Taxa,int nMoedaFatura,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero,mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio,mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto)
			{
				DataStruct structData; 

				// Contrato Cambio - Numero
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsstrNumeroNull())
					structData.strText = dtrwContratoCambio.strNumero;
				arlColunaAtual_Numero.Add(structData);

				// Contrato Cambio - Data Emissao
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsdtEmissaoNull())
					structData.strText = dtrwContratoCambio.dtEmissao.ToString("dd/MM/yyyy");
				arlColunaAtual_DataEmissao.Add(structData);

				// Contrato Cambio - Data Vencimento
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsdtVencimentoNull())
					structData.strText = dtrwContratoCambio.dtVencimento.ToString("dd/MM/yyyy");
				arlColunaAtual_DataVencimento.Add(structData);

				// Contrato Cambio - Valor (Principal)
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dtrwContratoCambio.dValor,true);
				arlColunaAtual_Valor.Add(structData);

				// Contrato Cambio - Saldo
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dcSaldoContratoCambio(dtrwContratoCambio.nIdExportador,dtrwContratoCambio.nIdContratoCambio,(decimal)dtrwContratoCambio.dValor,ref typDatSetProdutosBordero),true);
				arlColunaAtual_Saldo.Add(structData);

				// Contrato Cambio - Taxa
				structData = new DataStruct();
				structData.strText = dtrwContratoCambio.dTaxaCambial.ToString();
				arlColunaAtual_Taxa.Add(structData);

				// Vinculacao - Valor Fatura 
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(nMoedaFatura,dtrwProduto.dValor,true);
				arlColunaAtual_ValorFatura.Add(structData);

				// Vinculacao - Valor Contrato
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,(dtrwProduto.dValor * dtrwProduto.dTaxaCambial),true);
				arlColunaAtual_ValorContrato.Add(structData);

			}

			private decimal dcSaldoContratoCambio(int nIdExportador,int nContratoCambio,decimal dcValorTotal,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero)
			{
				decimal dcRetorno = dcValorTotal;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwBordero in typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					if (dtrwBordero.RowState != System.Data.DataRowState.Deleted)
					{
						if ((dtrwBordero.nIdExportador == nIdExportador) && (dtrwBordero.nIdContratoCambio == nContratoCambio))
							dcRetorno -= ((decimal)dtrwBordero.dValor * (decimal)dtrwBordero.dTaxaCambial);
					}
				}
				return(dcRetorno);
			} 
		#endregion
		#region #12 Documentos Bancários - Borderô - ShowDialog 
			private System.Collections.ArrayList arlShowDialogBordero(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosBordero.clsProdutosBordero cls_prod = new mdlProdutosBordero.clsProdutosBordero(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
		#endregion
		#endregion
		#region #13 Documentos Bancários - Instruções de ACC
		#region #13 Documentos Bancários - Instruções de ACC - Carregamento de Dados 
		#endregion
		#region #13 Documentos Bancários - Instruções de ACC - ShowDialog 
		#endregion
		#endregion
		#region #14 Documentos Bancários - Saque
		#region #14 Documentos Bancários - Saque - Carregamento de Dados 
		#endregion
		#region #14 Documentos Bancários - Saque - ShowDialog 
		#endregion
		#endregion
		#region #15 Instrução de Embarque 
		#region #15 Instrução de Embarque - Carregamento de Dados 
		#endregion
		#region #15 Instrução de Embarque - ShowDialog 
		#endregion
		#endregion
		#region #21 Sumário
		#region #21 Sumário - Carregamento de Dados 
			private System.Collections.ArrayList arlRetornaDadosAreaProdutosSumario(int nIdExportador,string strIdCodigo)
			{
				// Colunas disponiveis
				System.Collections.ArrayList arlColunaAtual_Numero = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_DataEmissao = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_DataVencimento = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Valor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Saldo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorFatura = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_ValorContrato = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Banco = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Taxa = new System.Collections.ArrayList();

				// Preenchendo o codigo das colunas
				arlColunaAtual_Numero.Add("4021");
				arlColunaAtual_DataEmissao.Add("4121");
				arlColunaAtual_DataVencimento.Add("4221");
				arlColunaAtual_Valor.Add("4321");
				arlColunaAtual_Saldo.Add("4421");
				arlColunaAtual_ValorFatura.Add("4521");
				arlColunaAtual_ValorContrato.Add("4621");
				arlColunaAtual_Banco.Add("4721");
				arlColunaAtual_Taxa.Add("4821");

				// Retorno
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

				// TypedDatSets
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos typDatSetBancos = m_cls_dba_ConnectionDB.GetTbExportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Clear();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdCodigo);

				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwFaturaComercial.IsidExportadorBancoNull())
					{
						int nBancoFatura = dtrwFaturaComercial.idExportadorBanco;
						int nMoedaFatura = 0;
						if (!dtrwFaturaComercial.IsidMoedaNull())
							nMoedaFatura = dtrwFaturaComercial.idMoeda;

						arlCondicaoCampo.Clear();
						arlCondicaoCampo.Add("nIdExportador");
						arlCondicaoCampo.Add("strIdPe");
						mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();

						arlCondicaoCampo.Add("nIdExportador");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdExportador);
						mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in typDatSetProdutosBordero.tbProdutosBordero.Rows)
						{
							mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio = null;
							foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambioBusca in typDatSetContratosCambio.tbContratosCambio)
							{
								if (dtrwProduto.nIdContratoCambio == dtrwContratoCambioBusca.nIdContratoCambio)
								{
									dtrwContratoCambio = dtrwContratoCambioBusca;
									break;
								}
							}
							if (dtrwContratoCambio != null)
							{
								string strNomeBanco = "";
								foreach(mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwBancoBusca in typDatSetBancos.tbExportadoresBancos.Rows)
								{
									if (dtrwContratoCambio.nIdExportadorBanco == dtrwBancoBusca.nIdBanco)
									{
										strNomeBanco = dtrwBancoBusca.strNome;
										break;
									}
								}
								if (strNomeBanco != null)
								{
									vSumarioInsereProdutos(ref arlColunaAtual_Numero,ref arlColunaAtual_DataEmissao,ref arlColunaAtual_DataVencimento,ref arlColunaAtual_Valor,ref arlColunaAtual_Saldo,ref arlColunaAtual_ValorFatura,ref arlColunaAtual_ValorContrato,ref arlColunaAtual_Banco,ref arlColunaAtual_Taxa,nMoedaFatura,ref typDatSetProdutosBordero,dtrwContratoCambio,dtrwProduto,strNomeBanco);
								}
							}
						}
					}
				}

				arlRetorno.Add(arlColunaAtual_Numero);
				arlRetorno.Add(arlColunaAtual_DataEmissao);
				arlRetorno.Add(arlColunaAtual_DataVencimento);
				arlRetorno.Add(arlColunaAtual_Valor);
				arlRetorno.Add(arlColunaAtual_Saldo);
				arlRetorno.Add(arlColunaAtual_ValorFatura);
				arlRetorno.Add(arlColunaAtual_ValorContrato);
				arlRetorno.Add(arlColunaAtual_Banco);
				arlRetorno.Add(arlColunaAtual_Taxa);
				return(arlRetorno);
			}
							
			private void vSumarioInsereProdutos(ref System.Collections.ArrayList arlColunaAtual_Numero,ref System.Collections.ArrayList arlColunaAtual_DataEmissao,ref System.Collections.ArrayList arlColunaAtual_DataVencimento,ref System.Collections.ArrayList arlColunaAtual_Valor,ref System.Collections.ArrayList arlColunaAtual_Saldo,ref System.Collections.ArrayList arlColunaAtual_ValorFatura,ref System.Collections.ArrayList arlColunaAtual_ValorContrato,ref System.Collections.ArrayList arlColunaAtual_Banco,ref System.Collections.ArrayList arlColunaAtual_Taxa,int nMoedaFatura,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero,mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio,mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto,string strNomeBanco)
			{
				DataStruct structData; 

				// Contrato Cambio - Numero
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsstrNumeroNull())
					structData.strText = dtrwContratoCambio.strNumero;
				arlColunaAtual_Numero.Add(structData);

				// Contrato Cambio - Data Emissao
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsdtEmissaoNull())
					structData.strText = dtrwContratoCambio.dtEmissao.ToString("dd/MM/yyyy");
				arlColunaAtual_DataEmissao.Add(structData);

				// Contrato Cambio - Data Vencimento
				structData = new DataStruct();
				if (!dtrwContratoCambio.IsdtVencimentoNull())
					structData.strText = dtrwContratoCambio.dtVencimento.ToString("dd/MM/yyyy");
				arlColunaAtual_DataVencimento.Add(structData);

				// Contrato Cambio - Valor (Principal)
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dtrwContratoCambio.dValor,true);
				arlColunaAtual_Valor.Add(structData);

				// Contrato Cambio - Saldo
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,dcSaldoContratoCambio(dtrwContratoCambio.nIdExportador,dtrwContratoCambio.nIdContratoCambio,(decimal)dtrwContratoCambio.dValor,ref typDatSetProdutosBordero),true);
				arlColunaAtual_Saldo.Add(structData);

				// Contrato Cambio - Taxa
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(CURRENCY_REAL,dtrwContratoCambio.dTaxaCambial,true);
				arlColunaAtual_Taxa.Add(structData);
				
				// Vinculacao - Valor Fatura 
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(nMoedaFatura,dtrwProduto.dValor,true);
				arlColunaAtual_ValorFatura.Add(structData);

				// Vinculacao - Valor Contrato
				structData = new DataStruct();
				structData.strText = mdlMoeda.clsMoeda.strReturnCurrencyFormated(dtrwContratoCambio.nIdMoeda,(dtrwProduto.dValor * dtrwProduto.dTaxaCambial),true);
				arlColunaAtual_ValorContrato.Add(structData);

				// ContratoCambio - Banco
				structData = new DataStruct();
				structData.strText = strNomeBanco;
				arlColunaAtual_Banco.Add(structData);
			}
		#endregion
		#region #21 Sumário - ShowDialog 
		#endregion
		#endregion
		#region #25 Romaneio - Volumes
			#region #25 Romaneio - Carregamento de Dados 
				#region Romaneio - Ordenacao 
				private System.Collections.ArrayList arlRetornaDadosAreaProdutosRomaneio_Volumes(int nIdExportador,string strIdCodigo)
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

					int nIdioma = 1;
					bool bMostrarVolumesConsecutivos = false;
					bool bMostrarEmbalagensConsecutivas = false;
					bool bMostrarQuantidadeTotalVolumes = false;
					bool bOtimizarEspaco = false;
					int nQuantidadeTotalVolumes = 0;
		                    
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);

					// Loading DataSets 
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetUnidadesEspaco = m_cls_dba_ConnectionDB.GetTbUnidadesEspaco(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);


					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCodigo);
							
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetVolumes = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null); 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// Ordenacao
					if (typDatSetRomaneios.tbRomaneios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetRomaneios.tbRomaneios.Rows[0];
						// Idioma 
						if (!dtrwRomaneio.IsnIdIdiomaNull())
							nIdioma = dtrwRomaneio.nIdIdioma;

						// Mostrar Volumes Consecutivos 
						bMostrarVolumesConsecutivos = dtrwRomaneio.bMostrarVolumesConsecutivos;
								
						// Mostar Embalagens Consecutivas 
						bMostrarEmbalagensConsecutivas = dtrwRomaneio.bMostrarEmbalagensConsecutivas;

						// Otimizar Espaco
						bOtimizarEspaco = (dtrwRomaneio.IsbOtimizarEspacoNull() || (dtrwRomaneio.bOtimizarEspaco)); 

						// Mostrar Quantidade Total Volumes
						bMostrarQuantidadeTotalVolumes = ((!dtrwRomaneio.IsbMostrarTotalVolumesNull()) && (dtrwRomaneio.bMostrarTotalVolumes));
						nQuantidadeTotalVolumes = typDatSetVolumes.tbProdutosRomaneioVolumes.Rows.Count;
						
						// Loading DataSets
						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();
						arlCondicaoCampo.Add("idExportador");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdExportador);
						arlCondicaoCampo.Add("idIdioma");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdioma);
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						arlCondicaoCampo.Clear();
						arlCondicaoComparador.Clear();
						arlCondicaoValor.Clear();
						arlCondicaoCampo.Add("nIdIdioma");
						arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
						arlCondicaoValor.Add(nIdioma);
						m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetUnidadesEspacoIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesEspacoIdioma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
						mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

						if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
						{
							// Montando o retorno 
							System.Collections.ArrayList arlColuna_Volume_Numero,arlColuna_Volume_TipoPopular,arlColuna_Volume_Largura,arlColuna_Volume_Altura,arlColuna_Volume_Comprimento,arlColuna_Volume_Volume,arlColuna_Volume_PesoLiquido,arlColuna_Volume_PesoBruto,arlColuna_ProdutoVolume_Descricao,arlColuna_ProdutoVolume_Quantidade,arlColuna_ProdutoVolume_PesoLiquido,arlColuna_ProdutoVolume_Codigo,arlColuna_ProdutoVolume_Ordem,arlColuna_ProdutoVolume_OrdemSequencial,arlColuna_Embalagem_Numero,arlColuna_ProdutoEmbalagem_Descricao,arlColuna_ProdutoEmbalagem_Quantidade,arlColuna_ProdutoEmbalagem_PesoLiquido,arlColuna_ProdutoEmbalagem_Codigo,arlColuna_ProdutoEmbalagem_Ordem,arlColuna_ProdutoEmbalagem_OrdemSequencial; 
							vRomaneioCreateArrayLists(out arlColuna_Volume_Numero,out arlColuna_Volume_TipoPopular,out arlColuna_Volume_Largura,out arlColuna_Volume_Altura,out arlColuna_Volume_Comprimento,out arlColuna_Volume_Volume,out arlColuna_Volume_PesoLiquido,out arlColuna_Volume_PesoBruto,out arlColuna_ProdutoVolume_Descricao,out arlColuna_ProdutoVolume_Quantidade,out arlColuna_ProdutoVolume_PesoLiquido,out arlColuna_ProdutoVolume_Codigo,out arlColuna_ProdutoVolume_Ordem,out arlColuna_ProdutoVolume_OrdemSequencial,out arlColuna_Embalagem_Numero,out arlColuna_ProdutoEmbalagem_Descricao,out arlColuna_ProdutoEmbalagem_Quantidade,out arlColuna_ProdutoEmbalagem_PesoLiquido,out arlColuna_ProdutoEmbalagem_Codigo,out arlColuna_ProdutoEmbalagem_Ordem,out arlColuna_ProdutoEmbalagem_OrdemSequencial);
							arlRetorno.Add(arlColuna_Volume_Numero);
							arlRetorno.Add(arlColuna_Volume_TipoPopular);
							arlRetorno.Add(arlColuna_Volume_Largura);
							arlRetorno.Add(arlColuna_Volume_Altura);
							arlRetorno.Add(arlColuna_Volume_Comprimento);
							arlRetorno.Add(arlColuna_Volume_Volume);
							arlRetorno.Add(arlColuna_Volume_PesoLiquido);
							arlRetorno.Add(arlColuna_Volume_PesoBruto);

							arlRetorno.Add(arlColuna_ProdutoVolume_Descricao);
							arlRetorno.Add(arlColuna_ProdutoVolume_Quantidade);
							arlRetorno.Add(arlColuna_ProdutoVolume_PesoLiquido);
							arlRetorno.Add(arlColuna_ProdutoVolume_Codigo);
							arlRetorno.Add(arlColuna_ProdutoVolume_Ordem);
							arlRetorno.Add(arlColuna_ProdutoVolume_OrdemSequencial);

							arlRetorno.Add(arlColuna_Embalagem_Numero);

							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Descricao);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Quantidade);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_PesoLiquido);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Codigo);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_Ordem);
							arlRetorno.Add(arlColuna_ProdutoEmbalagem_OrdemSequencial);

							mdlProdutosRomaneio.Ordenacao enumOrdenacao = (mdlProdutosRomaneio.Ordenacao)dtrwRomaneio.nTipoOrdenacao;
							vRomaneioOrdenacaoVolumeInsereVolumes(ref arlColuna_Volume_Numero,ref arlColuna_Volume_TipoPopular,ref arlColuna_Volume_Largura,ref arlColuna_Volume_Altura,ref arlColuna_Volume_Comprimento,ref arlColuna_Volume_Volume,ref arlColuna_Volume_PesoLiquido,ref arlColuna_Volume_PesoBruto,ref arlColuna_ProdutoVolume_Descricao,ref arlColuna_ProdutoVolume_Quantidade,ref arlColuna_ProdutoVolume_PesoLiquido,ref arlColuna_ProdutoVolume_Codigo,ref arlColuna_ProdutoVolume_Ordem,ref arlColuna_ProdutoVolume_OrdemSequencial,ref arlColuna_Embalagem_Numero,ref arlColuna_ProdutoEmbalagem_Descricao,ref arlColuna_ProdutoEmbalagem_Quantidade,ref arlColuna_ProdutoEmbalagem_PesoLiquido,ref arlColuna_ProdutoEmbalagem_Codigo,ref arlColuna_ProdutoEmbalagem_Ordem,ref arlColuna_ProdutoEmbalagem_OrdemSequencial,ref  typDatSetProdutos,ref typDatSetProdutosIdiomas ,ref typDatSetFaturasComerciais,ref typDatSetProdutosFaturaComercial,ref  typDatSetRomaneios,ref  typDatSetVolumes,ref  typDatSetVolumesProdutos,ref  typDatSetEmbalagens,ref typDatSetEmbalagensProdutos,ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,nIdExportador,strIdCodigo,nIdioma,bMostrarVolumesConsecutivos,bMostrarEmbalagensConsecutivas,bMostrarQuantidadeTotalVolumes,nQuantidadeTotalVolumes);
						}
					}
					if (bOtimizarEspaco)
						bRomaneioVolumesOtimize(ref arlRetorno);
					return(arlRetorno);
				}
				#endregion
				#region Romaneio - Ordenacao - Volumes
				#region vRomaneioOrdenacaoVolumeInsereVolumes
				private void vRomaneioOrdenacaoVolumeInsereVolumes(ref System.Collections.ArrayList arlColuna_Volume_Numero,ref System.Collections.ArrayList arlColuna_Volume_TipoPopular,ref System.Collections.ArrayList arlColuna_Volume_Largura,ref System.Collections.ArrayList arlColuna_Volume_Altura,ref System.Collections.ArrayList arlColuna_Volume_Comprimento,ref System.Collections.ArrayList arlColuna_Volume_Volume,ref System.Collections.ArrayList arlColuna_Volume_PesoLiquido,ref System.Collections.ArrayList arlColuna_Volume_PesoBruto,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,ref System.Collections.ArrayList arlColuna_Embalagem_Numero,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial,
					ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas ,ref mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes typDatSetVolumes,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetUnidadesEspaco,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetUnidadesEspacoIdioma,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma,int nIdExportador,string strIdPe,int nIdioma,bool bMostrarVolumesConsecutivos,bool bMostrarEmbalagensConsecutivas,bool bMostrarQuantidadeTotalVolumes,int nQuantidadeTotalVolumes)
				{
					string strUltimoVolume = "";

					// Preferencias 
					int nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
					vRomaneioCarregaPreferencias(out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);

					// Volumes
					//Ordenando
					System.Collections.SortedList sortLstVolumes = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolumes in typDatSetVolumes.tbProdutosRomaneioVolumes.Rows)
						sortLstVolumes.Add(dtrwVolumes.strNumeroVolume,dtrwVolumes);

					// Inserindo os Volumes 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow dtrwVolume;
					DataStruct structData;
					for(int nCont = 0; nCont < sortLstVolumes.Count;nCont++)
					{
						dtrwVolume = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumes.tbProdutosRomaneioVolumesRow)sortLstVolumes.GetByIndex(nCont);

						this.OrdemProdutosInsere();

						// Numero
						structData = new DataStruct();
						structData.strText = dtrwVolume.strNumeroVolume;
						if (bMostrarQuantidadeTotalVolumes)
							structData.strText = structData.strText + "/" + nQuantidadeTotalVolumes.ToString();
						arlColuna_Volume_Numero.Add(structData);
						// TipoPopular
						structData = new DataStruct();
						if (!dtrwVolume.IsstrTipoPopularNull())
						{
							if (bMostrarVolumesConsecutivos)
								structData.strText = dtrwVolume.strTipoPopular;
							else
							{
								if (dtrwVolume.strTipoPopular != strUltimoVolume)
								{
									structData.strText = dtrwVolume.strTipoPopular;
									strUltimoVolume = dtrwVolume.strTipoPopular;
								}
							}
						}
						arlColuna_Volume_TipoPopular.Add(structData);
						// Largura 
						structData = new DataStruct();
						if (!dtrwVolume.IsdLarguraNull())
						{
							structData.strText = dtrwVolume.dLargura.ToString();
							if (!dtrwVolume.IsnUnidadeLarguraNull())
							{
								structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeLargura,nIdioma);
							}
						}
						arlColuna_Volume_Largura.Add(structData);
						// Altura 
						structData = new DataStruct();
						if (!dtrwVolume.IsdAlturaNull())
						{
							structData.strText = dtrwVolume.dAltura.ToString();
							if (!dtrwVolume.IsnUnidadeAlturaNull())
							{
								structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeAltura,nIdioma);
							}
						}
						arlColuna_Volume_Altura.Add(structData);
						// Comprimento 
						structData = new DataStruct();
						if (!dtrwVolume.IsdComprimentoNull())
						{
							structData.strText = dtrwVolume.dComprimento.ToString();
							if (!dtrwVolume.IsnUnidadeComprimentoNull())
							{
								structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeComprimento,nIdioma);
							}
						}
						arlColuna_Volume_Comprimento.Add(structData);
						// Volume 
						structData = new DataStruct();
						if (!dtrwVolume.IsdVolumeNull())
						{
							structData.strText = dtrwVolume.dVolume.ToString();
							if (!dtrwVolume.IsnUnidadeVolumeNull())
							{
								structData.strText += strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwVolume.nUnidadeVolume,nIdioma) + "³";
							}
						}
						arlColuna_Volume_Volume.Add(structData);
						// Peso Liquido 
						structData = new DataStruct();
						if (!dtrwVolume.IsdPesoLiquidoNull())
						{
							if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
								structData.strText = System.Math.Round(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
							else
								structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
							if (!dtrwVolume.IsnUnidadeMassaPesoLiquidoNull())
							{
								structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoLiquido,nIdioma);
							}
						}
						arlColuna_Volume_PesoLiquido.Add(structData);
						// Peso Bruto 
						structData = new DataStruct();
						if (!dtrwVolume.IsdPesoBrutoNull())
						{
							if (bRomaneioPrecisaoPesoBrutoItensArredondar)
								structData.strText = System.Math.Round(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
							else
								structData.strText = mdlConversao.clsTruncamento.dRound(dtrwVolume.dPesoBruto,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
							if (!dtrwVolume.IsnUnidadeMassaPesoBrutoNull())
							{
								structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwVolume.nUnidadeMassaPesoBruto,nIdioma);
							}
						}
						arlColuna_Volume_PesoBruto.Add(structData);

						// Preenchendo um DataStruc Nulo
						arlColuna_ProdutoVolume_Descricao.Add(new DataStruct());
						arlColuna_ProdutoVolume_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoVolume_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoVolume_Codigo.Add(new DataStruct());
						arlColuna_ProdutoVolume_Ordem.Add(new DataStruct());
						arlColuna_ProdutoVolume_OrdemSequencial.Add(new DataStruct());
						arlColuna_Embalagem_Numero.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Descricao.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Codigo.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Ordem.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(new DataStruct());

						// Inserindo os Produtos do Volume 
						vRomaneioOrdenacaoVolumeInsereProdutos(ref arlColuna_Volume_Numero,ref arlColuna_Volume_TipoPopular,ref arlColuna_Volume_Largura,ref arlColuna_Volume_Altura,ref arlColuna_Volume_Comprimento,ref arlColuna_Volume_Volume,ref arlColuna_Volume_PesoLiquido,ref arlColuna_Volume_PesoBruto,ref arlColuna_ProdutoVolume_Descricao,ref arlColuna_ProdutoVolume_Quantidade,ref arlColuna_ProdutoVolume_PesoLiquido,ref arlColuna_ProdutoVolume_Codigo,ref arlColuna_ProdutoVolume_Ordem,ref arlColuna_ProdutoVolume_OrdemSequencial,ref arlColuna_Embalagem_Numero,ref arlColuna_ProdutoEmbalagem_Descricao,ref arlColuna_ProdutoEmbalagem_Quantidade,ref arlColuna_ProdutoEmbalagem_PesoLiquido,ref arlColuna_ProdutoEmbalagem_Codigo,ref arlColuna_ProdutoEmbalagem_Ordem,ref arlColuna_ProdutoEmbalagem_OrdemSequencial,ref typDatSetProdutos,ref typDatSetProdutosIdiomas ,ref typDatSetProdutosFaturaComercial,ref typDatSetVolumesProdutos,ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,nIdExportador,strIdPe,nIdioma,dtrwVolume.strNumeroVolume);
						// Inerindo as Embalagens do Volume 
						vRomaneioOrdenacaoVolumeInsereEmbalagens(ref arlColuna_Volume_Numero,ref arlColuna_Volume_TipoPopular,ref arlColuna_Volume_Largura,ref arlColuna_Volume_Altura,ref arlColuna_Volume_Comprimento,ref arlColuna_Volume_Volume,ref arlColuna_Volume_PesoLiquido,ref arlColuna_Volume_PesoBruto,ref arlColuna_ProdutoVolume_Descricao,ref arlColuna_ProdutoVolume_Quantidade,ref arlColuna_ProdutoVolume_PesoLiquido,ref arlColuna_ProdutoVolume_Codigo,ref arlColuna_ProdutoVolume_Ordem,ref arlColuna_ProdutoVolume_OrdemSequencial,ref arlColuna_Embalagem_Numero,ref arlColuna_ProdutoEmbalagem_Descricao,ref arlColuna_ProdutoEmbalagem_Quantidade,ref arlColuna_ProdutoEmbalagem_PesoLiquido,ref arlColuna_ProdutoEmbalagem_Codigo,ref arlColuna_ProdutoEmbalagem_Ordem,ref arlColuna_ProdutoEmbalagem_OrdemSequencial,ref typDatSetProdutos,ref typDatSetProdutosIdiomas ,ref typDatSetProdutosFaturaComercial,ref typDatSetEmbalagens,ref typDatSetEmbalagensProdutos,ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,nIdExportador,strIdPe,nIdioma,dtrwVolume.strNumeroVolume,bMostrarEmbalagensConsecutivas);
					}
				}
				#endregion
				#region vRomaneioOrdenacaoVolumeInsereProdutos
				private void vRomaneioOrdenacaoVolumeInsereProdutos(ref System.Collections.ArrayList arlColuna_Volume_Numero,ref System.Collections.ArrayList arlColuna_Volume_TipoPopular,ref System.Collections.ArrayList arlColuna_Volume_Largura,ref System.Collections.ArrayList arlColuna_Volume_Altura,ref System.Collections.ArrayList arlColuna_Volume_Comprimento,ref System.Collections.ArrayList arlColuna_Volume_Volume,ref System.Collections.ArrayList arlColuna_Volume_PesoLiquido,ref System.Collections.ArrayList arlColuna_Volume_PesoBruto,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,ref System.Collections.ArrayList arlColuna_Embalagem_Numero,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas ,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos typDatSetVolumesProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma,int nIdExportador,string strIdPe,int nIdioma,string strNumeroVolume)
				{
					// Preferencias 
					int nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
					vRomaneioCarregaPreferencias(out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);

					// Produtos
					//Ordenando
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutos in typDatSetVolumesProdutos.tbProdutosRomaneioVolumesProdutos.Rows)
					{
						if (dtrwProdutos.strNumeroVolume == strNumeroVolume)
						{
							int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutos.nIdOrdemProduto);
							if (nIdProduto != -1)
							{
								string strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutos.nIdOrdemProduto);
								while (sortLstProdutos.Contains(strDescricaoProduto))
									strDescricaoProduto += "?";
								sortLstProdutos.Add(strDescricaoProduto,dtrwProdutos);
							}
						}
					}
					// Inserindo os Produtos
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow dtrwProdutoRomaneio;
					DataStruct structData;
					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						dtrwProdutoRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos.tbProdutosRomaneioVolumesProdutosRow)sortLstProdutos.GetByIndex(nCont);
						int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutoRomaneio.nIdOrdemProduto);
						string strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutoRomaneio.nIdOrdemProduto);
						if (bIsChild(ref typDatSetProdutosFaturaComercial,dtrwProdutoRomaneio.nIdOrdemProduto))
							strDescricaoProduto = m_strDelimitadorRomaneioUsar + strDescricaoProduto;

						// Volume 
						arlColuna_Volume_Numero.Add(new DataStruct());
						arlColuna_Volume_TipoPopular.Add(new DataStruct());
						arlColuna_Volume_Largura.Add(new DataStruct());
						arlColuna_Volume_Altura.Add(new DataStruct());
						arlColuna_Volume_Comprimento.Add(new DataStruct());
						arlColuna_Volume_Volume.Add(new DataStruct());
						arlColuna_Volume_PesoLiquido.Add(new DataStruct());
						arlColuna_Volume_PesoBruto.Add(new DataStruct());

						OrdemProdutosInsere(dtrwProdutoRomaneio.nIdOrdemProduto);

						// Produto Volume
						// Descricao
						structData = new DataStruct();
						structData.strText = strDescricaoProduto;
						arlColuna_ProdutoVolume_Descricao.Add(structData);

						// Quantidade
						structData = new DataStruct();
						if (!dtrwProdutoRomaneio.IsdQuantidadeNull())
						{
							structData.strText = dtrwProdutoRomaneio.dQuantidade.ToString();
							structData.strText += " " + strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoRomaneio.nIdOrdemProduto);
						}
						arlColuna_ProdutoVolume_Quantidade.Add(structData);

						// Peso Liquido
						structData = new DataStruct();
						if (!dtrwProdutoRomaneio.IsdPesoLiquidoNull())
						{
							if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
								structData.strText = System.Math.Round(dtrwProdutoRomaneio.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
							else
								structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProdutoRomaneio.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
						}
						if (!dtrwProdutoRomaneio.IsnUnidadeMassaPesoLiquidoNull())
						{
							structData.strText += " " + strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoRomaneio.nUnidadeMassaPesoLiquido,nIdioma);
						}
						arlColuna_ProdutoVolume_PesoLiquido.Add(structData);

						//Codigo
						structData = new DataStruct();
						structData.strText = strRetornaCodigoProduto(ref typDatSetProdutos,nIdExportador,nIdProduto);
						arlColuna_ProdutoVolume_Codigo.Add(structData);

						//Ordem
						structData = new DataStruct();
						structData.strText = strRetornaOrdemLancamentoProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProdutoRomaneio.nIdOrdemProduto);
						arlColuna_ProdutoVolume_Ordem.Add(structData);

						//Ordem Sequencial
						structData = new DataStruct();
						structData.strText = dtrwProdutoRomaneio.nIdOrdemProduto.ToString();
						arlColuna_ProdutoVolume_OrdemSequencial.Add(structData);

						// Embalagem
						arlColuna_Embalagem_Numero.Add(new DataStruct());

						// Produto Embalagem 
						arlColuna_ProdutoEmbalagem_Descricao.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Codigo.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Ordem.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(new DataStruct());
					}
				}
				#endregion
				#region vRomaneioOrdenacaoVolumeInsereEmbalagens
				private void vRomaneioOrdenacaoVolumeInsereEmbalagens(ref System.Collections.ArrayList arlColuna_Volume_Numero,ref System.Collections.ArrayList arlColuna_Volume_TipoPopular,ref System.Collections.ArrayList arlColuna_Volume_Largura,ref System.Collections.ArrayList arlColuna_Volume_Altura,ref System.Collections.ArrayList arlColuna_Volume_Comprimento,ref System.Collections.ArrayList arlColuna_Volume_Volume,ref System.Collections.ArrayList arlColuna_Volume_PesoLiquido,ref System.Collections.ArrayList arlColuna_Volume_PesoBruto,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,ref System.Collections.ArrayList arlColuna_Embalagem_Numero,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas ,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens typDatSetEmbalagens,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma,
				int nIdExportador,string strIdPe,int nIdioma,string strNumeroVolume,bool bMostrarEmbalagensConsecutivas)
				{
					string strUltimaEmbalagem = "";
					// Embalagens
					//Ordenando
					System.Collections.SortedList sortLstEmbalagens = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagens in typDatSetEmbalagens.tbProdutosRomaneioEmbalagens.Rows)
					{
						if (!dtrwEmbalagens.IsstrNumeroVolumeNull())
						{
							if (dtrwEmbalagens.strNumeroVolume == strNumeroVolume)
								sortLstEmbalagens.Add(dtrwEmbalagens.strIdEmbalagem,dtrwEmbalagens);
						}
					}
					// Inserindo as Embalagens
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow dtrwEmbalagem;
					DataStruct structData;
					for(int nCont = 0; nCont < sortLstEmbalagens.Count;nCont++)
					{
						dtrwEmbalagem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagens.tbProdutosRomaneioEmbalagensRow)sortLstEmbalagens.GetByIndex(nCont);

						// Volume 
						arlColuna_Volume_Numero.Add(new DataStruct());
						arlColuna_Volume_TipoPopular.Add(new DataStruct());
						arlColuna_Volume_Largura.Add(new DataStruct());
						arlColuna_Volume_Altura.Add(new DataStruct());
						arlColuna_Volume_Comprimento.Add(new DataStruct());
						arlColuna_Volume_Volume.Add(new DataStruct());
						arlColuna_Volume_PesoLiquido.Add(new DataStruct());
						arlColuna_Volume_PesoBruto.Add(new DataStruct());
						// Produto Volume
						this.OrdemProdutosInsere();
						arlColuna_ProdutoVolume_Descricao.Add(new DataStruct());
						arlColuna_ProdutoVolume_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoVolume_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoVolume_Codigo.Add(new DataStruct());
						arlColuna_ProdutoVolume_Ordem.Add(new DataStruct());
						arlColuna_ProdutoVolume_OrdemSequencial.Add(new DataStruct());
						// Embalagem
						structData = new DataStruct();
						if (bMostrarEmbalagensConsecutivas)
						{
							structData.strText = dtrwEmbalagem.strIdEmbalagem;
						}
						else
						{
							if (dtrwEmbalagem.strIdEmbalagem != strUltimaEmbalagem)
							{
								structData.strText = dtrwEmbalagem.strIdEmbalagem;
								strUltimaEmbalagem = dtrwEmbalagem.strIdEmbalagem;
							}
							else
							{
								structData.strText = TEXTO_REPETICAO;
							}
						}
						arlColuna_Embalagem_Numero.Add(structData);
						// Produto Embalagem
						arlColuna_ProdutoEmbalagem_Descricao.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Codigo.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_Ordem.Add(new DataStruct());
						arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(new DataStruct());

						vRomaneioOrdenacaoVolumeInsereProdutosEmbalagem(ref arlColuna_Volume_Numero,ref arlColuna_Volume_TipoPopular,ref arlColuna_Volume_Largura,ref arlColuna_Volume_Altura,ref arlColuna_Volume_Comprimento,ref arlColuna_Volume_Volume,ref arlColuna_Volume_PesoLiquido,ref arlColuna_Volume_PesoBruto,ref arlColuna_ProdutoVolume_Descricao,ref arlColuna_ProdutoVolume_Quantidade,ref arlColuna_ProdutoVolume_PesoLiquido,ref arlColuna_ProdutoVolume_Codigo,ref arlColuna_ProdutoVolume_Ordem,ref arlColuna_ProdutoVolume_OrdemSequencial,ref arlColuna_Embalagem_Numero,ref arlColuna_ProdutoEmbalagem_Descricao,ref arlColuna_ProdutoEmbalagem_Quantidade,ref arlColuna_ProdutoEmbalagem_PesoLiquido,ref arlColuna_ProdutoEmbalagem_Codigo,ref arlColuna_ProdutoEmbalagem_Ordem,ref arlColuna_ProdutoEmbalagem_OrdemSequencial,ref typDatSetProdutos,ref  typDatSetProdutosIdiomas ,ref typDatSetProdutosFaturaComercial,ref typDatSetEmbalagensProdutos,ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,nIdExportador,strIdPe,nIdioma,dtrwEmbalagem.strIdEmbalagem);
					}
				}
				#endregion
				#region vRomaneioOrdenacaoVolumeInsereProdutosEmbalagem
				private void vRomaneioOrdenacaoVolumeInsereProdutosEmbalagem(ref System.Collections.ArrayList arlColuna_Volume_Numero,ref System.Collections.ArrayList arlColuna_Volume_TipoPopular,ref System.Collections.ArrayList arlColuna_Volume_Largura,ref System.Collections.ArrayList arlColuna_Volume_Altura,ref System.Collections.ArrayList arlColuna_Volume_Comprimento,ref System.Collections.ArrayList arlColuna_Volume_Volume,ref System.Collections.ArrayList arlColuna_Volume_PesoLiquido,ref System.Collections.ArrayList arlColuna_Volume_PesoBruto,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoVolume_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoVolume_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoVolume_OrdemSequencial,ref System.Collections.ArrayList arlColuna_Embalagem_Numero,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Descricao,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Quantidade,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_PesoLiquido,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Codigo,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_Ordem,ref System.Collections.ArrayList arlColuna_ProdutoEmbalagem_OrdemSequencial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas ,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial,ref mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos typDatSetEmbalagensProdutos,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma,int nIdExportador,string strIdPe,int nIdioma,string strIdEmbalagem)
				{
					// Preferencias 
					int nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
					vRomaneioCarregaPreferencias(out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);

					// Produtos
					//Ordenando
					System.Collections.SortedList sortLstProdutos = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProdutos in typDatSetEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutos.Rows)
					{
						if (dtrwProdutos.strIdEmbalagem == strIdEmbalagem)
						{
							int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProdutos.nIdOrdemProduto);
							if (nIdProduto != -1)
							{
								string strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProdutos.nIdOrdemProduto);
								while (sortLstProdutos.Contains(strDescricaoProduto))
									strDescricaoProduto += "?";
								sortLstProdutos.Add(strDescricaoProduto,dtrwProdutos);
							}
						}
					}
					// Inserindo os Produtoss 
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow dtrwProduto;
					DataStruct structData;
					for(int nCont = 0; nCont < sortLstProdutos.Count;nCont++)
					{
						dtrwProduto = (mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos.tbProdutosRomaneioEmbalagensProdutosRow)sortLstProdutos.GetByIndex(nCont);
						int nIdProduto = nRetornaIdProduto(ref typDatSetProdutosFaturaComercial,dtrwProduto.nIdOrdemProduto);
						string strDescricaoProduto = strRetornaDescricaoProdutoFatura(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdioma,dtrwProduto.nIdOrdemProduto);
						if (bIsChild(ref typDatSetProdutosFaturaComercial,dtrwProduto.nIdOrdemProduto))
							strDescricaoProduto = m_strDelimitadorRomaneioUsar + strDescricaoProduto;

						// Volume 
						arlColuna_Volume_Numero.Add(new DataStruct());
						arlColuna_Volume_TipoPopular.Add(new DataStruct());
						arlColuna_Volume_Largura.Add(new DataStruct());
						arlColuna_Volume_Altura.Add(new DataStruct());
						arlColuna_Volume_Comprimento.Add(new DataStruct());
						arlColuna_Volume_Volume.Add(new DataStruct());
						arlColuna_Volume_PesoLiquido.Add(new DataStruct());
						arlColuna_Volume_PesoBruto.Add(new DataStruct());

						// Produto Volume
						arlColuna_ProdutoVolume_Descricao.Add(new DataStruct());
						arlColuna_ProdutoVolume_Quantidade.Add(new DataStruct());
						arlColuna_ProdutoVolume_PesoLiquido.Add(new DataStruct());
						arlColuna_ProdutoVolume_Codigo.Add(new DataStruct());
						arlColuna_ProdutoVolume_Ordem.Add(new DataStruct());
						arlColuna_ProdutoVolume_OrdemSequencial.Add(new DataStruct());

						// Embalagem
						arlColuna_Embalagem_Numero.Add(new DataStruct());

						// Produto Embalagem 
						// Descricao
						this.OrdemProdutosInsere(dtrwProduto.nIdOrdemProduto);
						structData = new DataStruct();
						structData.strText = strDescricaoProduto;
						arlColuna_ProdutoEmbalagem_Descricao.Add(structData);

						// Quantidade
						structData = new DataStruct();
						if (!dtrwProduto.IsdQuantidadeNull())
						{
							structData.strText = dtrwProduto.dQuantidade.ToString();
							structData.strText += " " + strRetornaUnidadeQuantidadeProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProduto.nIdOrdemProduto);
						}
						arlColuna_ProdutoEmbalagem_Quantidade.Add(structData);

						// Peso Liquido
						structData = new DataStruct();
						if ((!dtrwProduto.IsdPesoLiquidoNull()) && (dtrwProduto.dPesoLiquido != 0))
						{
							if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
								structData.strText = System.Math.Round(dtrwProduto.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
							else
								structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProduto.dPesoLiquido,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
							if (!dtrwProduto.IsnUnidadeMassaPesoLiquidoNull())
								structData.strText += strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProduto.nUnidadeMassaPesoLiquido,nIdioma);
						}
						arlColuna_ProdutoEmbalagem_PesoLiquido.Add(structData);

						//Codigo
						structData = new DataStruct();
						structData.strText = strRetornaCodigoProduto(ref typDatSetProdutos,nIdExportador,nIdProduto);
						arlColuna_ProdutoEmbalagem_Codigo.Add(structData);

						//Ordem
						structData = new DataStruct();
						structData.strText = strRetornaOrdemLancamentoProdutoFatura(ref typDatSetProdutosFaturaComercial,dtrwProduto.nIdOrdemProduto);
						arlColuna_ProdutoEmbalagem_Ordem.Add(structData);

						//OrdemSequencial
						structData = new DataStruct();
						structData.strText = dtrwProduto.nIdOrdemProduto.ToString();
						arlColuna_ProdutoEmbalagem_OrdemSequencial.Add(structData);

					}
				}
				#endregion
				#endregion
				#region Otimizar Espaco
					private enum RomaneioVolumeRegistroTipo
					{
						Indefinido = 0,
						Volume = 1,
						Embalagem = 2,
						ProdutoEmbalagem = 3,
						ProdutoVolume = 4 
					}

					private bool bRomaneioVolumesOtimize(ref System.Collections.ArrayList arlData)
					{
						if (arlData.Count == 0)
							return(false);
						System.Collections.ArrayList arlVolume = null;
						System.Collections.ArrayList arlEmbalagem = null;
						System.Collections.ArrayList arlProdutoEmbalagem = null;
						System.Collections.ArrayList arlProdutoVolume = null;
						for(int i = 0; i < arlData.Count;i++)
						{
							System.Collections.ArrayList arlCurrent = (System.Collections.ArrayList)arlData[i];
							switch (arlCurrent[0].ToString())
							{
								case "4011":
									arlVolume = arlCurrent;
								  break;
								case "5011":
									arlProdutoVolume = arlCurrent;
									break;
								case "6011":
									arlEmbalagem = arlCurrent;
									break;
								case "7011":
									arlProdutoEmbalagem = arlCurrent;
									break;
							}
						}

						RomaneioVolumeRegistroTipo LastRegistry = RomaneioVolumeRegistroTipo.Indefinido; 
						for(int i = ((System.Collections.ArrayList)arlData[0]).Count - 1; i > 0;i--)
						{
							// Procurando o tipo do Registro atual
							RomaneioVolumeRegistroTipo CurrentRegistry = RomaneioVolumeRegistroTipo.Indefinido; 
							if ((arlVolume != null) && (((DataStruct)arlVolume[i]).strText != null) && (((DataStruct)arlVolume[i]).strText != ""))
								CurrentRegistry = RomaneioVolumeRegistroTipo.Volume;
							if ((arlEmbalagem != null) && (((DataStruct)arlEmbalagem[i]).strText != null) && (((DataStruct)arlEmbalagem[i]).strText != ""))
								CurrentRegistry = RomaneioVolumeRegistroTipo.Embalagem;
							if ((arlProdutoEmbalagem != null) && (((DataStruct)arlProdutoEmbalagem[i]).strText != null) && (((DataStruct)arlProdutoEmbalagem[i]).strText != ""))
								CurrentRegistry = RomaneioVolumeRegistroTipo.ProdutoEmbalagem;
							if ((arlProdutoVolume != null) && (((DataStruct)arlProdutoVolume[i]).strText != null) && (((DataStruct)arlProdutoVolume[i]).strText != ""))
								CurrentRegistry = RomaneioVolumeRegistroTipo.ProdutoVolume;
							if (((CurrentRegistry == RomaneioVolumeRegistroTipo.Volume) && (LastRegistry == RomaneioVolumeRegistroTipo.Embalagem)) || ((CurrentRegistry == RomaneioVolumeRegistroTipo.Embalagem) && (LastRegistry == RomaneioVolumeRegistroTipo.ProdutoEmbalagem)) || ((CurrentRegistry == RomaneioVolumeRegistroTipo.Volume) && (LastRegistry == RomaneioVolumeRegistroTipo.ProdutoVolume)))
							{
								for(int j = 0; j < arlData.Count;j++)
								{
									DataStruct DataCurrent = ((DataStruct)((System.Collections.ArrayList)arlData[j])[i]);
									DataStruct DataLast = ((DataStruct)((System.Collections.ArrayList)arlData[j])[i + 1]);
									if ((DataCurrent.strText == null) || (DataCurrent.strText == ""))
										((System.Collections.ArrayList)arlData[j])[i] = DataLast;
									((System.Collections.ArrayList)arlData[j]).RemoveAt(i+1);
								}
							}
							LastRegistry = CurrentRegistry;
						}
						return(true);
					}
				#endregion
			#endregion
		#endregion
		#region #26 Romaneio - Simplificado
			#region #26 Romaneio - Simplificado - Carregamento de Dados
				private System.Collections.ArrayList arlRetornaDadosAreaProdutosRomaneio_Simplificado(int nIdExportador,string strIdCodigo)
				{
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

					System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

					// Preferencias 
					int nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar;
					vRomaneioCarregaPreferencias(out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar);

					// Carregando os TypedDatSets 

					// Loading DataSets 
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspaco typDatSetUnidadesEspaco = m_cls_dba_ConnectionDB.GetTbUnidadesEspaco(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesEspacoIdioma typDatSetUnidadesEspacoIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesEspacoIdioma(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(null,null,null,null,null);


					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCodigo);
					arlOrdenacaoCampo.Add("nIdOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios typDatSetRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado typDatSetProdutosRomaneioSimplificado = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioSimplificado(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

					// Inicializando os ArrayLists 
					System.Collections.ArrayList arlColuna_Produto_Descricao = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Produto_Quantidade = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_Quantidade = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_PesoLiquidoUnitario = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_PesoLiquidoTotal = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_PesoBrutoUnitario = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_PesoBrutoTotal = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_Altura = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_Largura = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_Comprimento = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_VolumeCubico = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_CubagemTotal = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_TipoPopular = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Volume_QuantidadeProduto = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_Produto_Codigo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_ProdutoFatura_Ordem = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColuna_ProdutoFatura_OrdemSequencial = new System.Collections.ArrayList();

					arlColuna_Produto_Descricao.Add("4026");
					arlColuna_Produto_Quantidade.Add("4126");
					arlColuna_Volume_Quantidade.Add("4226");
					arlColuna_Volume_PesoLiquidoUnitario.Add("4326");
					arlColuna_Volume_PesoLiquidoTotal.Add("4426");
					arlColuna_Volume_PesoBrutoUnitario.Add("4526");
					arlColuna_Volume_PesoBrutoTotal.Add("4626");
					arlColuna_Volume_Altura.Add("4726");
					arlColuna_Volume_Largura.Add("4826");
					arlColuna_Volume_Comprimento.Add("4926");
					arlColuna_Volume_VolumeCubico.Add("5026");
					arlColuna_Volume_CubagemTotal.Add("5326");
					arlColuna_Volume_TipoPopular.Add("5126");
					arlColuna_Volume_QuantidadeProduto.Add("5226");
					arlColuna_Produto_Codigo.Add("5426");
					arlColuna_ProdutoFatura_Ordem.Add("5526");
					arlColuna_ProdutoFatura_OrdemSequencial.Add("5626");

					int nIdIdiomaFatura = 1;
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais[0];
						if (!dtrwFaturaComercial.IsidIdiomaNull())
							nIdIdiomaFatura = dtrwFaturaComercial.idIdioma;
					}

					int nIdIdiomaRomaneio = 1;
					if (typDatSetRomaneios.tbRomaneios.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)typDatSetRomaneios.tbRomaneios[0];
						if (!dtrwRomaneio.IsnIdIdiomaNull())
							nIdIdiomaRomaneio = dtrwRomaneio.nIdIdioma;
					}


					DataStruct structData;
					// Percorrendo os produtos do romaneio
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificadoRow dtrwProdutoRomaneio in typDatSetProdutosRomaneioSimplificado.tbProdutosRomaneioSimplificado.Rows)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoRomaneio.nIdOrdemProduto);
						if (dtrwProdutoFatura != null)
						{
							string strDescricaoProduto = clsRelatoriosCallBackAreaProdutos.strRetornaDescricaoProdutoRomaneio(ref typDatSetProdutos,ref typDatSetProdutosIdiomas,ref typDatSetProdutosFaturaComercial,nIdExportador,nIdIdiomaFatura,nIdIdiomaRomaneio,dtrwProdutoRomaneio.nIdOrdemProduto);

							this.OrdemProdutosInsere(dtrwProdutoRomaneio.nIdOrdemProduto);

							// <Produto>Descricao 
							structData = new DataStruct();
							structData.strText = strDescricaoProduto;
							arlColuna_Produto_Descricao.Add(structData);

							// <Produto>Codigo
							structData = new DataStruct();
							structData.strText = clsRelatoriosCallBackAreaProdutos.strRetornaCodigoProduto(ref typDatSetProdutos,nIdExportador,dtrwProdutoFatura.idProduto);
							arlColuna_Produto_Codigo.Add(structData);

							// <ProdutoFatura>Ordem
							structData = new DataStruct();
							structData.strText = dtrwProdutoFatura.idOrdemLancamento.ToString();
							arlColuna_ProdutoFatura_Ordem.Add(structData);

							// <ProdutoFatura>OrdemSequencial
							structData = new DataStruct();
							structData.strText = dtrwProdutoFatura.idOrdem.ToString();
							arlColuna_ProdutoFatura_OrdemSequencial.Add(structData);

							// <Produto>Quantidade
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dQuantidadeProduto != 0)
							{
								structData.strText = dtrwProdutoRomaneio.dQuantidadeProduto.ToString();
								if (!dtrwProdutoFatura.IsstrUnidadeNull())
									structData.strText += " " + dtrwProdutoFatura.strUnidade;
							}
							arlColuna_Produto_Quantidade.Add(structData);

							// <Volume>Quantidade
							double dVolumeQuantidade = 0;
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dQuantidadeVolumes != 0)
							{
								structData.strText = dtrwProdutoRomaneio.dQuantidadeVolumes.ToString();
								dVolumeQuantidade = dtrwProdutoRomaneio.dQuantidadeVolumes;
							}
							arlColuna_Volume_Quantidade.Add(structData);

							// <Volume>PesoLiquidoUnitario
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dPesoLiquidoUnitario != 0)
							{
								if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
									structData.strText = System.Math.Round(dtrwProdutoRomaneio.dPesoLiquidoUnitario,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
								else
									structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProdutoRomaneio.dPesoLiquidoUnitario,nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
								structData.strText += " " + strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoRomaneio.nUnidadeMassaPesoLiquido,m_nIdioma);
							}
							arlColuna_Volume_PesoLiquidoUnitario.Add(structData);

							// <Volume>PesoLiquidoTotal
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dPesoLiquidoUnitario != 0)
							{
								if (bRomaneioPrecisaoPesoLiquidoItensArredondar)
									structData.strText = System.Math.Round(mdlConversao.clsTruncamento.dTrunca(dtrwProdutoRomaneio.dPesoLiquidoUnitario * dtrwProdutoRomaneio.dQuantidadeProduto,0.0001f),nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
								else
									structData.strText = mdlConversao.clsTruncamento.dRound(mdlConversao.clsTruncamento.dTrunca(dtrwProdutoRomaneio.dPesoLiquidoUnitario * dtrwProdutoRomaneio.dQuantidadeProduto,0.0001f),nRomaneioPrecisaoPesoLiquidoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoLiquidoItens));
								structData.strText += " " + strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoRomaneio.nUnidadeMassaPesoLiquido,m_nIdioma);
							}
							arlColuna_Volume_PesoLiquidoTotal.Add(structData);

							// <Volume>PesoBrutoUnitario
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dPesoBrutoUnitario != 0)
							{
								if (bRomaneioPrecisaoPesoBrutoItensArredondar)
									structData.strText = System.Math.Round(dtrwProdutoRomaneio.dPesoBrutoUnitario,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
								else
									structData.strText = mdlConversao.clsTruncamento.dRound(dtrwProdutoRomaneio.dPesoBrutoUnitario,nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
								structData.strText += " " + strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoRomaneio.nUnidadeMassaPesoBruto,m_nIdioma);
							}
							arlColuna_Volume_PesoBrutoUnitario.Add(structData);

							// <Volume>PesoBrutoTotal
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dPesoBrutoUnitario != 0)
							{
								if (bRomaneioPrecisaoPesoBrutoItensArredondar)
									structData.strText = System.Math.Round(mdlConversao.clsTruncamento.dTrunca(dtrwProdutoRomaneio.dPesoBrutoUnitario * dtrwProdutoRomaneio.dQuantidadeVolumes,0.0001f),nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
								else
									structData.strText = mdlConversao.clsTruncamento.dRound(mdlConversao.clsTruncamento.dTrunca(dtrwProdutoRomaneio.dPesoBrutoUnitario * dtrwProdutoRomaneio.dQuantidadeVolumes,0.0001f),nRomaneioPrecisaoPesoBrutoItens).ToString(strRetornaFormato(nRomaneioPrecisaoPesoBrutoItens));
								structData.strText += " " + strRetornaSiglaUnidadeMassa(ref typDatSetUnidadesMassa,ref typDatSetUnidadesMassaIdioma,dtrwProdutoRomaneio.nUnidadeMassaPesoBruto,m_nIdioma);
							}
							arlColuna_Volume_PesoBrutoTotal.Add(structData);

							// <Volume>Altura
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dAltura != 0)
							{
								structData.strText = dtrwProdutoRomaneio.dAltura.ToString();
								structData.strText += " " + strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwProdutoRomaneio.nUnidadeAltura,m_nIdioma);
							}
							arlColuna_Volume_Altura.Add(structData);

							// <Volume>Largura
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dLargura != 0)
							{
								structData.strText = dtrwProdutoRomaneio.dLargura.ToString();
								structData.strText += " " + strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwProdutoRomaneio.nUnidadeLargura,m_nIdioma);
							}
							arlColuna_Volume_Largura.Add(structData);

							// <Volume>Comprimento
							structData = new DataStruct();
							if (dtrwProdutoRomaneio.dComprimento != 0)
							{
								structData.strText = dtrwProdutoRomaneio.dComprimento.ToString();
								structData.strText += " " + strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwProdutoRomaneio.nUnidadeComprimento,m_nIdioma);
							}
							arlColuna_Volume_Comprimento.Add(structData);

							// <Volume>Volume Cubico
							structData = new DataStruct();
							double dVolumeCubagem = 0;
							string strVolumeCubagem = "";
							if (dtrwProdutoRomaneio.dVolume != 0)
							{
								structData.strText = System.Math.Round(dtrwProdutoRomaneio.dVolume,4).ToString();
								dVolumeCubagem = dtrwProdutoRomaneio.dVolume;
								structData.strText += " " + (strVolumeCubagem = strRetornaSiglaUnidadeEspaco(ref typDatSetUnidadesEspaco,ref typDatSetUnidadesEspacoIdioma,dtrwProdutoRomaneio.nUnidadeVolume,m_nIdioma) + "³");
							}
							arlColuna_Volume_VolumeCubico.Add(structData);

							// <Volume>Cubagem Total
							structData = new DataStruct();
							if ((dVolumeQuantidade != 0) && (dVolumeCubagem != 0))
							{
								structData.strText = System.Math.Round(dVolumeQuantidade * dVolumeCubagem,3).ToString();
								structData.strText += " " + strVolumeCubagem;
							}
							arlColuna_Volume_CubagemTotal.Add(structData);

							// <Volume>TipoPopular
							structData = new DataStruct();
							if (!dtrwProdutoRomaneio.IsstrTipoPopularNull())
							{
								structData.strText = dtrwProdutoRomaneio.strTipoPopular;
							}else{
								structData.strText = "";
							}
							arlColuna_Volume_TipoPopular.Add(structData);
							// <Volume>QuantidadeProduto
							structData = new DataStruct();
							if ((!dtrwProdutoRomaneio.IsdQuantidadeProdutoNull()) && (!dtrwProdutoRomaneio.IsdQuantidadeVolumesNull()))
							{
								structData.strText = System.Math.Round((dtrwProdutoRomaneio.dQuantidadeProduto / dtrwProdutoRomaneio.dQuantidadeVolumes),2).ToString();
								if (!dtrwProdutoFatura.IsstrUnidadeNull())
									structData.strText += " " + dtrwProdutoFatura.strUnidade;
							}
							else
							{
 								structData.strText = "";
							}
							arlColuna_Volume_QuantidadeProduto.Add(structData);
						}
					}

					// Montando o Retorno
					arlRetorno.Add(arlColuna_Produto_Descricao);
					arlRetorno.Add(arlColuna_Produto_Quantidade);
					arlRetorno.Add(arlColuna_Volume_Quantidade);
					arlRetorno.Add(arlColuna_Volume_PesoLiquidoUnitario);
					arlRetorno.Add(arlColuna_Volume_PesoLiquidoTotal);
					arlRetorno.Add(arlColuna_Volume_PesoBrutoUnitario);
					arlRetorno.Add(arlColuna_Volume_PesoBrutoTotal);
					arlRetorno.Add(arlColuna_Volume_Altura);
					arlRetorno.Add(arlColuna_Volume_Largura);
					arlRetorno.Add(arlColuna_Volume_Comprimento);
					arlRetorno.Add(arlColuna_Volume_VolumeCubico);
					arlRetorno.Add(arlColuna_Volume_CubagemTotal);
					arlRetorno.Add(arlColuna_Volume_TipoPopular);
					arlRetorno.Add(arlColuna_Volume_QuantidadeProduto);
					arlRetorno.Add(arlColuna_Produto_Codigo);
					arlRetorno.Add(arlColuna_ProdutoFatura_Ordem);
					arlRetorno.Add(arlColuna_ProdutoFatura_OrdemSequencial);
					return(arlRetorno);
				}
			#endregion
			#region #26 Romaneio-Simplificado - Show Dialog
				private System.Collections.ArrayList arlShowDialogRomaneio_Simplificado(int nIdExportador, string strIdCodigo,ref int nStatus)
				{
					System.Collections.ArrayList arlRetorno = null;
					mdlProdutosRomaneio.clsProdutosRomaneioSimplificado prodRomaneio = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
					prodRomaneio.ShowDialog();
					if (prodRomaneio.m_bModificado)
					{
						nStatus = STATUS_CARREGA_TUDO;
					}
					return(arlRetorno);
				}
			#endregion
		#endregion
		#region #27 Reserva 
		#endregion
		#region #28 Guia de Entrada
			#region 28 Guia de Entrada - Total Paginas
				private int nRetornaTotalPaginasAreaProdutosGuiaEntrada(int nIdExportador,string  strIdCodigo)
				{
					mdlContainers.clsContainers cls_containers = new mdlContainers.clsContainers(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
					return(cls_containers.nQuantidadeContainers());
				}
			#endregion
		#endregion
		#region #29 Certificado de Origem Aladi Ace59
			#region #29 Certificado de Origem Aladi Ace59 - Carregamento de Dados 
				private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOAladiAce59(int nIdExportador,string strIdCodigo)
				{
					bool bMostrarProdutos,bMostrarProdutosFilhos;
					bCarregaConfiguracoesCertificadoOrigem(nIdExportador,strIdCodigo,2,out bMostrarProdutos,out bMostrarProdutosFilhos);

					// Colunas disponiveis
					System.Collections.ArrayList arlColunaAtual_Ordem = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColunaAtual_Codigo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColunaAtual_Denominacao = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColunaAtual_Quantidade = new System.Collections.ArrayList();
					System.Collections.ArrayList arlColunaAtual_ValorFob = new System.Collections.ArrayList();

					// Preenchendo o codigo das colunas
					arlColunaAtual_Ordem.Add("4029");
					arlColunaAtual_Codigo.Add("4129");
					arlColunaAtual_Denominacao.Add("4229");
					arlColunaAtual_Quantidade.Add("4329");
					arlColunaAtual_ValorFob.Add("4429");

					// Retorno
					System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();

					m_nHeight = RELATORIO_HEIGHT_NORMAL;
					m_nWidth = RELATORIO_WIDTH_NORMAL;

					// Condicoes
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

					// TypedDataSets
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetTbProdutosIdiomas;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetTbProdutosNaladi;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem typDatSetTbProdutosCertificadoOrigem;

					// TypedDataRows
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = null;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificadoOrigem;

					// TypDatSetTbProdutosNaladi
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// TypDatSetTbProdutos
					arlCondicaoCampo.Clear();
					arlCondicaoCampo.Add("idExportador");
					typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					typDatSetTbProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

					// TypDatSetTbProdutosFaturaComercial
					arlCondicaoCampo.Add("idPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCodigo);
					arlOrdenacaoCampo.Add("idOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
					typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);


					// TypedDataSetTbFaturasComerciais
					typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					dtrwFatura = typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(nIdExportador,strIdCodigo);
					if (dtrwFatura != null)
					{
						// Moeda 
						if (!dtrwFatura.IsidMoedaNull())
							m_nIdMoeda = dtrwFatura.idMoeda;
					}

					// TypDatSetTbProdutosCertificadoOrigem
					arlCondicaoCampo.Clear();
					arlCondicaoComparador.Clear();
					arlCondicaoValor.Clear();
					arlOrdenacaoCampo.Clear();
					arlOrdenacaoTipo.Clear();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(strIdCodigo);
					arlCondicaoCampo.Add("idTipoCO");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(29);
					arlOrdenacaoCampo.Add("idOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente); 
					typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

					// Produtos Principais
					System.Collections.SortedList sortLstProdutosPrincipais = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					int nIdOrdemProdutoParent = -1;
					for(int nCont = 0; nCont < typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count;nCont++)
					{
						dtrwProdutoFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCont]; 
						if (!dtrwProdutoFaturaComercial.IsidProdutoNull())
						{
							nIdOrdemProdutoParent = 0;
							if ((!dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent != 0))
								nIdOrdemProdutoParent = dtrwProdutoFaturaComercial.nIdOrdemProdutoParent;
							if (nIdOrdemProdutoParent == 0)
							{
								sortLstProdutosPrincipais.Add(dtrwProdutoFaturaComercial.idOrdem,dtrwProdutoFaturaComercial);
							}
						}
					}

					double dAcumuladorSubTotal = 0;
					double dAcumuladorQuantidade = 0;
					int nlUltimoIdOrdemUtilizado = -1;
					string strUltimoCodigoUtilizado = "";
					string strUltimaDenominacaoUtilizada = "";
					string strUltimaUnidadeUtilizada = "";
					string strCodigo = "";
					string strDenominacao = ""; 

					// Calculo 
					mdlIncoterm.clsManipuladorValor cls_man_Valor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,nIdExportador,strIdCodigo);
					cls_man_Valor.FaturaOutput = false;
					cls_man_Valor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

					// Produtos do Certificado
					double dPrecoUnitarioProduto = 0, dSubTotalProduto = 0;
					System.Collections.ArrayList arlProdutosFatura = new System.Collections.ArrayList();
					for(int nCont = 0; nCont < typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows.Count;nCont++)
					{
						dtrwProdutoCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow)typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows[nCont]; 
						if (!dtrwProdutoCertificadoOrigem.IsidOrdemNull())
						{
							dtrwProdutoFaturaComercial = typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(nIdExportador,strIdCodigo,dtrwProdutoCertificadoOrigem.idOrdemProduto);
							strCodigo = strRetornaNaladiProduto(ref typDatSetTbProdutos,ref dtrwProdutoFaturaComercial);
							strDenominacao = strRetornaDenominacaoNaladi(ref typDatSetTbProdutos,ref typDatSetTbProdutosNaladi,ref dtrwProdutoFaturaComercial,ref dtrwProdutoCertificadoOrigem);
							if ((dtrwProdutoFaturaComercial != null) && (strCodigo != "") && (strDenominacao != "") && ((dtrwProdutoFaturaComercial.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFaturaComercial.nIdOrdemProdutoParent == 0)))
							{
								cls_man_Valor.vRetornaValores(dtrwProdutoFaturaComercial.idOrdem,out dPrecoUnitarioProduto);
								dSubTotalProduto = (dPrecoUnitarioProduto * dtrwProdutoFaturaComercial.dQuantidade);

								// ORDEM
								if (nlUltimoIdOrdemUtilizado != -1)
								{
									if (nlUltimoIdOrdemUtilizado == dtrwProdutoCertificadoOrigem.idOrdem)
									{
										dAcumuladorSubTotal = dAcumuladorSubTotal + dSubTotalProduto;
										dAcumuladorQuantidade = dAcumuladorQuantidade + dtrwProdutoFaturaComercial.dQuantidade;
										arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
									}
									else
									{
										// O idOrdem atual eh diferente dos anteriores, inserir os anteriores e armazenar os dados atuais
										InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,2,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);
										nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
										strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
										strUltimoCodigoUtilizado = strCodigo;
										strUltimaDenominacaoUtilizada = strDenominacao;
										dAcumuladorSubTotal = dSubTotalProduto;
										dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
										arlProdutosFatura.Clear();
										arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
									}
								}
								else
								{
									// Este eh o primeiro idOrdem ou foi acabado de inserir um outro idOrdem 
									nlUltimoIdOrdemUtilizado = dtrwProdutoCertificadoOrigem.idOrdem;
									strUltimaUnidadeUtilizada = dtrwProdutoFaturaComercial.strUnidade;
									strUltimoCodigoUtilizado = strCodigo;
									strUltimaDenominacaoUtilizada = strDenominacao;
									dAcumuladorSubTotal = dSubTotalProduto;
									dAcumuladorQuantidade = dtrwProdutoFaturaComercial.dQuantidade;
									arlProdutosFatura.Add(dtrwProdutoFaturaComercial.idOrdem);
								}
							}
						}
					}
					if (nlUltimoIdOrdemUtilizado != -1)
						InsereLinhaCertificadoOrigemMercosul(nIdExportador,strIdCodigo,29,ref arlColunaAtual_Ordem,ref arlColunaAtual_Codigo,ref arlColunaAtual_Denominacao,ref arlColunaAtual_Quantidade,ref arlColunaAtual_ValorFob,nlUltimoIdOrdemUtilizado.ToString(),strUltimoCodigoUtilizado,strUltimaDenominacaoUtilizada,(dAcumuladorQuantidade.ToString() + " " + strUltimaUnidadeUtilizada),mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,dAcumuladorSubTotal,false),bMostrarProdutos,bMostrarProdutosFilhos,ref typDatSetTbProdutos,ref typDatSetTbProdutosIdiomas,ref typDatSetTbProdutosFaturaComercial,ref typDatSetTbProdutosCertificadoOrigem,arlProdutosFatura);

					arlRetorno.Add(arlColunaAtual_Ordem);
					arlRetorno.Add(arlColunaAtual_Codigo);
					arlRetorno.Add(arlColunaAtual_Denominacao);
					arlRetorno.Add(arlColunaAtual_Quantidade);
					arlRetorno.Add(arlColunaAtual_ValorFob);
					return(arlRetorno);
				}
			#endregion
			#region #29 Certificado de Origem Aladi Ace59 - ShowDialog 
			private System.Collections.ArrayList arlShowDialogCOMercosulAladiAce59(int nIdExportador, string strIdCodigo,ref int nStatus)
			{
				System.Collections.ArrayList arlRetorno = null;
				mdlProdutosCertificadoOrigem.clsProdutosCertificadoOrigem cls_prod = new mdlProdutosCertificadoOrigem.ComNormas.clsProdutosCertificadoOrigemMercosulAce59(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo,ref m_ilBandeiras);
				cls_prod.ShowDialog();
				if (cls_prod.m_bModificado)
				{
					nStatus = STATUS_CARREGA_TUDO;
				}
				return(arlRetorno);
			}
			#endregion
		#endregion
		#region #30 Certificado de Origem Form A
			#region #30 Certificado de Origem Form A - Carregamento de Dados	
				private System.Collections.ArrayList arlRetornaDadosAreaProdutosCOFormA(int nIdExportador,string strIdCodigo)
				{
					mdlProdutosCertificadoOrigem.clsProdutosFormA cls_prod = new mdlProdutosCertificadoOrigem.clsProdutosFormA(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
					return(cls_prod.GetAreaProdutosCertificadoOrigemFormA());
				}
			#endregion
			#region #30 Certificado de Origem Form A - ShowDialog	
				private System.Collections.ArrayList arlShowDialogCOFormA(int nIdExportador, string strIdCodigo,ref int nStatus)
				{
					System.Collections.ArrayList arlRetorno = null;
					mdlProdutosCertificadoOrigem.clsProdutosFormA cls_prod = new mdlProdutosCertificadoOrigem.clsProdutosFormA(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdCodigo);
					if (cls_prod.ShowDialog())
						nStatus = STATUS_CARREGA_TUDO;
					return(arlRetorno);
				}
			#endregion
		#endregion

	}
}
