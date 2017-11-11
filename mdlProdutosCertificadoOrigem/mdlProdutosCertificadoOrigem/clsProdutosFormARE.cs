using System;

namespace mdlProdutosCertificadoOrigem
{
	/// <summary>
	/// Summary description for clsProdutosFormARE.
	/// </summary>
	public class clsProdutosFormARE
	{
		#region Constants
			internal const string TEXTO_MASTER = "Master";
			internal const string TEXT_COLUMN_IDORDEM = "nIdOrdem";
			internal const string TEXT_COLUMN_RENUMERO = "RE Número";
			internal const string TEXT_COLUMN_REDATA = "RE Data";
			internal const string TEXT_COLUMN_NBMSH = "NBM/SH";
			internal const string TEXT_COLUMN_VALORFOB = "Valor FOB";
			internal const string TEXT_COLUMN_PESOLIQUIDO = "Peso Líquido";

			internal const int UNIDADE_PESOLIQUIDO = 3;
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			private string m_strEnderecoExecutavel;
			private int m_nIdExportador = -1;
			private string m_strIdPE = "";

			private int m_nIdCurrency = -1;
	
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow m_dtrwFaturaComercial = null;

			private mdlDataBaseAccess.Tabelas.XsdTbREs m_typDatSetREs = null;
			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs m_typDatSetREsPEs = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typedDataSetProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typedDataSetProdutosFaturaComercial = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA m_typedDataSetProdutosCertificadoFormA = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE m_typedDataSetProdutosCertificadoFormARE = null;

			private bool m_bDataTableEvents = false;
		#endregion
		#region Properties
			private int Currency
			{
				get
				{
					if (m_nIdCurrency != -1)
						return(m_nIdCurrency);
					mdlMoeda.clsMoeda objMoeda = new mdlMoeda.clsMoedaComercial(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
					string strDescricao,strSimbolo;
					bool bMostrarSimbolo;
					objMoeda.retornaValores(out m_nIdCurrency,out strDescricao,out strSimbolo,out bMostrarSimbolo);
					return(m_nIdCurrency);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREs TypDatSetREs
			{
				get
				{
					if (m_typDatSetREs != null)
						return(m_typDatSetREs);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					m_typDatSetREs = m_cls_dba_ConnectionDB.GetTbREs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(null);
					return(m_typDatSetREs);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs TypDatSetREsPEs
			{
				get
				{
					if (m_typDatSetREsPEs != null)
						return(m_typDatSetREsPEs);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					m_typDatSetREsPEs = m_cls_dba_ConnectionDB.GetTbREsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(null);
					return(m_typDatSetREsPEs);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow FaturaComercial
			{
				get
				{
					if (m_dtrwFaturaComercial != null)
						return(m_dtrwFaturaComercial);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetFaturasComerciais.tbFaturasComerciais.Count == 0)
						return(null);
					m_dtrwFaturaComercial = typDatSetFaturasComerciais.tbFaturasComerciais[0];
					return(m_dtrwFaturaComercial);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutos TypedDataSetProdutos
			{
				get
				{
					if (m_typedDataSetProdutos != null)
						return(m_typedDataSetProdutos);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					m_typedDataSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typedDataSetProdutos);
				}
			}


			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial TypedDataSetProdutosFaturaComercial
			{
				get
				{
					if (m_typedDataSetProdutosFaturaComercial != null)
						return(m_typedDataSetProdutosFaturaComercial);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					m_typedDataSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typedDataSetProdutosFaturaComercial);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA TypedDataSetProdutosCertificadoFormA
			{
				get
				{
					if (m_typedDataSetProdutosCertificadoFormA != null)
						return(m_typedDataSetProdutosCertificadoFormA);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					arlCondicaoCampo.Add("nIdIdioma");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add((int)mdlConstantes.Idioma.Ingles);
					m_typedDataSetProdutosCertificadoFormA = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigemFormA(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typedDataSetProdutosCertificadoFormA);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE TypedDataSetProdutosCertificadoFormARE
			{
				get
				{
					if (m_typedDataSetProdutosCertificadoFormARE != null)
						return(m_typedDataSetProdutosCertificadoFormARE);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("strIdPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					m_typedDataSetProdutosCertificadoFormARE = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigemFormARE(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typedDataSetProdutosCertificadoFormARE);
				}
			}
		#endregion
		#region Constructors
			public clsProdutosFormARE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
			}
		#endregion

		#region SalvaDados
			private bool SalvaDados()
			{
				// Produtos Certificado Origem Form A
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosFormARE = this.TypedDataSetProdutosCertificadoFormARE;
				if (typDatSetProdutosFormARE.GetChanges() != null)
				{
					m_cls_dba_ConnectionDB.SetTbProdutosCertificadoOrigemFormARE(typDatSetProdutosFormARE);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				return(true);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFProdutosFormARE form = new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE(m_strEnderecoExecutavel);
				InitializeEvents(ref form);
				form.ShowDialog();
				if (form.Confirmed)
					return(SalvaDados());
				return(false);
			}

			private void InitializeEvents(ref Formularios.frmFProdutosFormARE form)
			{
				//ShowDialogREs
				form.eCallShowRE += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallShowRE(ShowDialogREs);

				//Refresh RE's
				form.eCallRefreshRE += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallRefreshRE(RefreshREs);

				//Refresh Produtos Nao Vinculados
				form.eCallRefreshProdutosNaoVinculados += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallRefreshProdutosNaoVinculados(RefreshProdutosNaoVinculados);

				//Refresh Produtos Vinculados
				form.eCallRefreshProdutosVinculados += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallRefreshProdutosVinculados(RefreshProdutosVinculados);

				// Configure
				form.eCallFormAREConfigure +=new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallFormAREConfigure(ConfigureFormARE);

				//Refresh FormARE
				form.eCallRefreshFormARE += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallRefreshFormARE(RefreshFormARE);

				// ProdutoVincula
				form.eCallProdutoVincula += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallProdutoVincula(ProdutoFaturaVinculaRE);

				// ProdutoDesvincula
				form.eCallProdutoDesvincula += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallProdutoDesvincula(ProdutoFaturaDesvinculaRE);

				// PossuiProdutosSemClassificacaoTarifaria
				form.eCallPossuiProdutosSemClassificacaoTarifaria += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallPossuiProdutosSemClassificacaoTarifaria(bPossuiProdutosSemClassificacaoTarifaria);

				// ShowClassificacaoTarifaria
				form.eCallShowClassificacaoTarifaria += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallShowClassificacaoTarifaria(ShowDialogClassificaoTarifaria);

				// CarregaTamanhoColunas
				form.eCallCarregaTamanhoColunas += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallCarregaTamanhoColunas(CarregaTamanhoColunas);

				// SalvaTamanhoColunas
				form.eCallSalvaTamanhoColunas += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormARE.delCallSalvaTamanhoColunas(SalvaTamanhoColunas);
			}

			private bool CarregaTamanhoColunas(out int nTamanhoColunaRENumero, out int nTamanhoColunaREData, out int nTamanhoColunaNCM, out int nTamanhoColunaValorFOB, out int nTamanhoColunaPesoLiquido)
			{
				nTamanhoColunaRENumero = m_cls_dba_ConnectionDB.GetConfiguracao("FORMARETamanhoColunaRENumero",30);
				nTamanhoColunaREData = m_cls_dba_ConnectionDB.GetConfiguracao("FORMARETamanhoColunaREData",25);
				nTamanhoColunaNCM = m_cls_dba_ConnectionDB.GetConfiguracao("FORMARETamanhoColunaNCM",30);
				nTamanhoColunaValorFOB = m_cls_dba_ConnectionDB.GetConfiguracao("FORMARETamanhoColunaValorFOB",22);
				nTamanhoColunaPesoLiquido = m_cls_dba_ConnectionDB.GetConfiguracao("FORMARETamanhoColunaPesoLiquido",25);
				return(true);
			}

			private bool SalvaTamanhoColunas(int nTamanhoColunaRENumero, int nTamanhoColunaREData, int nTamanhoColunaNCM, int nTamanhoColunaValorFOB, int nTamanhoColunaPesoLiquido)
			{
				m_cls_dba_ConnectionDB.SetConfiguracao("FORMARETamanhoColunaRENumero",nTamanhoColunaRENumero.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("FORMARETamanhoColunaREData",nTamanhoColunaREData.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("FORMARETamanhoColunaNCM",nTamanhoColunaNCM.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("FORMARETamanhoColunaValorFOB",nTamanhoColunaValorFOB.ToString());
				m_cls_dba_ConnectionDB.SetConfiguracao("FORMARETamanhoColunaPesoLiquido",nTamanhoColunaPesoLiquido.ToString());
				return(true);
			}
		#endregion
		#region ShowDialogREs
			private bool ShowDialogREs()
			{
				mdlRE.clsRE formRE = new mdlRE.clsRE(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
				if (!formRE.ShowDialogVincular())
					return(false);
				m_typDatSetREs = null;
				m_typDatSetREsPEs = null;
				return(true);
			}
		#endregion
		#region ShowDialogClassificacaoTarifaria
			private bool ShowDialogClassificaoTarifaria()
			{
				bool bRetorno = false;
				mdlProdutosVinculacao.clsProdutosVincular cls_pv_Produtos = new mdlProdutosVinculacao.clsProdutosVincular(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,mdlProdutosVinculacao.Classificacao.Ncm);
				cls_pv_Produtos.ProdutosVinculados = !cls_pv_Produtos.bExisteProdutosSemVinculo();
				if (bRetorno = cls_pv_Produtos.ShowDialog())
				{
					m_typedDataSetProdutosFaturaComercial = null;
				}
				return(bRetorno);
			}
		#endregion

		#region Refresh
			private void RefreshREs(ref System.Windows.Forms.ListView lvREs)
			{
				lvREs.Items.Clear();
				System.Windows.Forms.ListViewItem lviRE = null;
				mdlDataBaseAccess.Tabelas.XsdTbREsPEs typDatSetREsPEs = this.TypDatSetREsPEs;
				mdlDataBaseAccess.Tabelas.XsdTbREs typDatSetREs = this.TypDatSetREs;
				for(int i = 0; i < TypDatSetREsPEs.tbREsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = TypDatSetREsPEs.tbREsPEs[i];
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,dtrwREPE.nIdRe);
					if (dtrwRE != null)
					{
						lviRE = lvREs.Items.Add(dtrwRE.mstrNumero);
						lviRE.Tag = dtrwRE.nIdRe;
					}
				}
			}

			private void RefreshProdutosNaoVinculados(ref System.Windows.Forms.ListView lvProdutosNaoVinculados)
			{
				lvProdutosNaoVinculados.Items.Clear();
				System.Windows.Forms.ListViewItem lviProduto = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				System.Data.DataRow[] rows = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Select("","strNcm");
				for(int i = 0;i < rows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)rows[i];
					if (((!dtrwProdutoFatura.IsstrNcmNull())) && ((dtrwProdutoFatura.IsnIdReNull()) || (dtrwProdutoFatura.nIdRe == -1)))
					{
						string strDescricao = (!dtrwProdutoFatura.IsmstrDescricaoNull()) ? dtrwProdutoFatura.mstrDescricao : "";
						if (strDescricao == "")
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.TypedDataSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
							if ((dtrwProduto != null) && (!dtrwProduto.IsmstrDescricaoNull()))
								strDescricao = dtrwProduto.mstrDescricao;
						}
						lviProduto = lvProdutosNaoVinculados.Items.Add(dtrwProdutoFatura.strNcm);
						lviProduto.SubItems.Add(strDescricao);
						lviProduto.Tag = dtrwProdutoFatura.idOrdem;
					}
				}
			}

			private void RefreshProdutosVinculados(int nIdRe, ref System.Windows.Forms.ListView lvProdutosVinculados)
			{
				lvProdutosVinculados.Items.Clear();
				System.Windows.Forms.ListViewItem lviProduto = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				System.Data.DataRow[] rows = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Select("","strNcm");
				for(int i = 0;i < rows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)rows[i];
					if ((!dtrwProdutoFatura.IsstrNcmNull()) && (!dtrwProdutoFatura.IsnIdReNull()) && (dtrwProdutoFatura.nIdRe == nIdRe))
					{
						string strDescricao = (!dtrwProdutoFatura.IsmstrDescricaoNull()) ? dtrwProdutoFatura.mstrDescricao : "";
						if (strDescricao == "")
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.TypedDataSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
							if ((dtrwProduto != null) && (!dtrwProduto.IsmstrDescricaoNull()))
								strDescricao = dtrwProduto.mstrDescricao;
						}
						lviProduto = lvProdutosVinculados.Items.Add(dtrwProdutoFatura.strNcm);
						lviProduto.SubItems.Add(strDescricao);
						lviProduto.Tag = dtrwProdutoFatura.idOrdem;
					}
				}
			}

			private void RefreshFormARE(ref mdlComponentesGraficos.DataGrid dgFormARE)
			{
				m_bDataTableEvents = false;

				System.Data.DataTable dataTable = this.GetDataTableMaster();

				// Fill Data 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosCertificadoRE = this.TypedDataSetProdutosCertificadoFormARE;
				System.Data.DataRow[] dataRows = typDatSetProdutosCertificadoRE.tbProdutosCertificadoOrigemFormARE.Select("","nIdOrdem",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.Unchanged | System.Data.DataViewRowState.ModifiedCurrent);
				for(int i = 0; i < dataRows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow)dataRows[i];
					System.Data.DataRow dtrwProduto = dataTable.NewRow();

					dtrwProduto[TEXT_COLUMN_IDORDEM] = dtrwProdutoCertificado.nIdOrdem;
					dtrwProduto[TEXT_COLUMN_RENUMERO] = dtrwProdutoCertificado.mstrNumeroRE;
					dtrwProduto[TEXT_COLUMN_REDATA] = dtrwProdutoCertificado.mstrREData;
					dtrwProduto[TEXT_COLUMN_NBMSH] = dtrwProdutoCertificado.mstrClassiTarifaria;
					dtrwProduto[TEXT_COLUMN_VALORFOB] = dtrwProdutoCertificado.mstrValorFOB;
					dtrwProduto[TEXT_COLUMN_PESOLIQUIDO] = dtrwProdutoCertificado.mstrPesoLiquido;
                    
					dataTable.Rows.Add(dtrwProduto);
				}
				dgFormARE.DataSource = dataTable;

				m_bDataTableEvents = true;
			}
		#endregion

		#region Produtos Fatura
			private bool ProdutoFaturaVinculaRE(int nIdRe, int[] nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				for(int i = 0; i < nIdOrdemProduto.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProduto[i]);
					if (dtrwProduto == null)
						return(false);
					dtrwProduto.nIdRe = nIdRe;
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(typDatSetProdutosFaturaComercial);
				if (m_cls_dba_ConnectionDB.Erro != null)
					return(false);
				m_typedDataSetProdutosFaturaComercial = null;
				return(BuildProdutosFormARE());
			}

			private bool ProdutoFaturaDesvinculaRE(int[] nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				for(int i = 0; i < nIdOrdemProduto.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProduto = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProduto[i]);
					if (dtrwProduto == null)
						return(false);
					dtrwProduto.nIdRe = -1;
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(typDatSetProdutosFaturaComercial);
				if (m_cls_dba_ConnectionDB.Erro != null)
					return(false);
				m_typedDataSetProdutosFaturaComercial = null;
				return(BuildProdutosFormARE());
			}
		#endregion
		#region Produtos Certificado
			private bool BuildProdutosFormARE()
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosFormARE = this.TypedDataSetProdutosCertificadoFormARE;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbREs typDatSetREs = this.TypDatSetREs;

				//Incoterm
				mdlIncoterm.clsManipuladorValor ctrlValor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,m_strIdPE);
				ctrlValor.IncotermRetorno = mdlConstantes.Incoterm.FOB;

				//Deleting 
				for(int i = typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE.Rows.Count - 1;i >= 0;i--)
					typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE[i].Delete();

				//Searching for REs
				System.Collections.SortedList sortLstREs = new System.Collections.SortedList();
				for(int i = 0; i < typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoFormA = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA[i];
					if (dtrwProdutoFormA.IsnIdOrdemProdutoFaturaNull())
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,dtrwProdutoFormA.nIdOrdemProdutoFatura);
					if (dtrwProdutoFatura == null)
						continue;
					if ((dtrwProdutoFatura.IsnIdReNull()) || (dtrwProdutoFatura.nIdRe == -1))
						continue;
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,dtrwProdutoFatura.nIdRe);
					if (dtrwRE == null)
						continue;
                    if (sortLstREs.ContainsKey(dtrwRE.mstrNumero))
						continue;
					sortLstREs.Add(dtrwRE.mstrNumero,dtrwRE);
				}
				// Inserting RE's
				for(int i = 0; i < sortLstREs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)sortLstREs.GetByIndex(i);
					//Searching for Ncm's
					System.Collections.SortedList sortLstNcm = new System.Collections.SortedList();
					for(int j = 0; j < typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.Rows.Count;j++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoFormA = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA[j];
						if (dtrwProdutoFormA.IsnIdOrdemProdutoFaturaNull())
							continue;
						mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,dtrwProdutoFormA.nIdOrdemProdutoFatura);
						if (dtrwProdutoFatura == null)
							continue;
						if (dtrwProdutoFatura.IsnIdReNull() || (dtrwProdutoFatura.nIdRe != dtrwRE.nIdRe))
							continue;
						if ((dtrwProdutoFatura.IsstrNcmNull()) || (dtrwProdutoFatura.strNcm == ""))
							continue;
						if (sortLstNcm.ContainsKey(dtrwProdutoFatura.strNcm))
							continue;
						sortLstNcm.Add(dtrwProdutoFatura.strNcm,dtrwProdutoFatura.strNcm);
					}
					// Inserting Ncm's
					for(int j = 0; j < sortLstNcm.Count;j++)
					{
						string strNcm = (string)sortLstNcm.GetByIndex(j);
						decimal dcValorFOB = 0;
						decimal dcPesoLiquido = 0;
						for(int k = 0; k < typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.Rows.Count;k++)
						{
							mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoFormA = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA[k];
							if (dtrwProdutoFormA.IsnIdOrdemProdutoFaturaNull())
								continue;
							mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,dtrwProdutoFormA.nIdOrdemProdutoFatura);
							if (dtrwProdutoFatura == null)
								continue;
							if (dtrwProdutoFatura.IsnIdReNull() || (dtrwProdutoFatura.nIdRe != dtrwRE.nIdRe))
								continue;
							if ((dtrwProdutoFatura.IsstrNcmNull()) || (dtrwProdutoFatura.strNcm != strNcm))
								continue;
							double dPrecoUnitario,dQuantidade;
							ctrlValor.vRetornaValores(dtrwProdutoFatura.idOrdem,out dPrecoUnitario,out dQuantidade);
							dcValorFOB = dcValorFOB + System.Math.Round((decimal)dPrecoUnitario * (decimal)dQuantidade,2);
							if ((dtrwProdutoFatura.IsnUnidadeMassaPesoLiquidoNull()) || (dtrwProdutoFatura.IsdPesoLiquidoNull()))
								continue;
                            dcPesoLiquido = dcPesoLiquido + (decimal)(dtrwProdutoFatura.dPesoLiquido * mdlPesos.clsPesos.dRetornaFatorConversaoEntreUnidadesMassa(dtrwProdutoFatura.nUnidadeMassaPesoLiquido,UNIDADE_PESOLIQUIDO));

						}
						// Inserting Registry
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow dtrwProdutoFormARE = typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE.NewtbProdutosCertificadoOrigemFormARERow();
						dtrwProdutoFormARE.nIdExportador = m_nIdExportador;
						dtrwProdutoFormARE.strIdPE = m_strIdPE;
					    dtrwProdutoFormARE.nIdOrdem = GetNextId(typDatSetProdutosFormARE);
						dtrwProdutoFormARE.mstrNumeroRE = dtrwRE.mstrNumero;
						dtrwProdutoFormARE.mstrREData = dtrwRE.dtEmissao.ToString("dd/MMM/yyyy");
						dtrwProdutoFormARE.mstrClassiTarifaria = strNcm;
					    dtrwProdutoFormARE.mstrValorFOB = mdlMoeda.clsMoeda.strReturnCurrencyFormated(this.Currency,dcValorFOB,true);
					    dtrwProdutoFormARE.mstrPesoLiquido = dcPesoLiquido.ToString() + " Kg";
						typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE.AddtbProdutosCertificadoOrigemFormARERow(dtrwProdutoFormARE);

					}
				}
				return(true);
			}

			private int GetNextId(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosFormARE)
			{
				int nId = 1;
				bool bExist = true;
				while(bExist)
				{
					bExist = false;
					for(int i = 0; i < typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow dtrwProduto = typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE[i];
						int nIdCurrent = -1;
						if (dtrwProduto.RowState == System.Data.DataRowState.Deleted)
							nIdCurrent = Int32.Parse(dtrwProduto["nIdOrdem",System.Data.DataRowVersion.Original].ToString());
						else
							nIdCurrent = dtrwProduto.nIdOrdem;

						if (nIdCurrent == nId)
						{
							bExist = true;
							nId++;
							break;
						}
					}
				}
				return(nId);
			}
		#endregion
		#region Classificacao Tarifaria
			private bool bPossuiProdutosSemClassificacaoTarifaria()
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				System.Data.DataRow[] rows = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Select("","strNcm");
				for(int i = 0;i < rows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)rows[i];
					if (dtrwProdutoFatura.IsstrNcmNull()) 
						return(true);
				}
				return(false);
			}
		#endregion

		#region TableStyles
			private void ConfigureFormARE(ref mdlComponentesGraficos.DataGrid dgFormARE)
			{
				BuildTableStyles(ref dgFormARE);
			}

			private void BuildTableStyles(ref mdlComponentesGraficos.DataGrid dgProdutos)
			{
				// Limpando os anteriores 
				dgProdutos.TableStyles.Clear();

				// Criando o Table Style
				System.Windows.Forms.DataGridTableStyle dtgdtbstMaster = new System.Windows.Forms.DataGridTableStyle(false);

				// Configurando 
				dtgdtbstMaster.MappingName = TEXTO_MASTER;
				dtgdtbstMaster.GridLineStyle = System.Windows.Forms.DataGridLineStyle.Solid;
				dtgdtbstMaster.GridLineColor = System.Drawing.Color.Gray;
				dtgdtbstMaster.AlternatingBackColor = dgProdutos.BackColor;
				dtgdtbstMaster.BackColor = System.Drawing.Color.White;
				dtgdtbstMaster.HeaderBackColor = dgProdutos.BackColor;
				dtgdtbstMaster.AllowSorting = false;

				// Configurando os GridColumnStyles
				dtgdtbstMaster.GridColumnStyles.Clear();

				dtgdtbstMaster.GridColumnStyles.Add(GetColumnIdOrdem());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnRENumero());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnREData());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnNBMSH());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnValorFOB());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnPesoLiquido());
				dgProdutos.TableStyles.Add(dtgdtbstMaster);
			}
		#endregion
		#region DataGridColumnStyles
			private System.Windows.Forms.DataGridColumnStyle GetColumnIdOrdem()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_IDORDEM;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_IDORDEM;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = true;
				dtgdcsColuna.Width = 0;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnRENumero()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_RENUMERO;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_RENUMERO;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 100;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnREData()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_REDATA;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_REDATA;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 100;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnNBMSH()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_NBMSH;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_NBMSH;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 100;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnValorFOB()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_VALORFOB;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_VALORFOB;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 120;
				dtgdcsColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnPesoLiquido()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = TEXT_COLUMN_PESOLIQUIDO;
				dtgdcsColuna.HeaderText = TEXT_COLUMN_PESOLIQUIDO;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 160;
				dtgdcsColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
				return(dtgdcsColuna);
			}
		#endregion
		#region DataTable
			private System.Data.DataTable GetDataTableMaster()
			{
				System.Data.DataTable dtTable = new System.Data.DataTable(TEXTO_MASTER);

				// Changed 
				dtTable.RowChanged += new System.Data.DataRowChangeEventHandler(dtTableMaster_RowChanged);
				// Deleting 
				dtTable.RowDeleting += new System.Data.DataRowChangeEventHandler(dtTableMaster_RowDeleting);

				dtTable.Columns.Add(this.GetDataColumnIdOrdem());
				dtTable.Columns.Add(this.GetDataColumnRENumero());
				dtTable.Columns.Add(this.GetDataColumnREData());
				dtTable.Columns.Add(this.GetDataColumnNBMSH());
				dtTable.Columns.Add(this.GetDataColumnValorFOB());
				dtTable.Columns.Add(this.GetDataColumnPesoLiquido());

				return(dtTable);
			}

			// Row Changed
			private void dtTableMaster_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
			{
				if (m_bDataTableEvents)
				{
					switch (e.Action)
					{
						case System.Data.DataRowAction.Add: // Add a Line
							//Can't insert new products
							break;
										
						case System.Data.DataRowAction.Change: // Update a Line
							DataTable_RowUpdating(e.Row);
							break;
					}
				}
			}

			// Row Updating
			private void DataTable_RowUpdating(System.Data.DataRow dtrwProduto)
			{
				int nIdOrdem = Int32.Parse(dtrwProduto[TEXT_COLUMN_IDORDEM].ToString());
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosFormARE = this.TypedDataSetProdutosCertificadoFormARE;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow dtrwProdutoMaster = typDatSetProdutosFormARE.tbProdutosCertificadoOrigemFormARE.FindBynIdExportadorstrIdPEnIdOrdem(m_nIdExportador,m_strIdPE,nIdOrdem);
				if (dtrwProdutoMaster != null)
				{
					dtrwProdutoMaster.mstrNumeroRE = dtrwProduto[TEXT_COLUMN_RENUMERO].ToString();
					dtrwProdutoMaster.mstrREData = dtrwProduto[TEXT_COLUMN_REDATA].ToString();
					dtrwProdutoMaster.mstrClassiTarifaria = dtrwProduto[TEXT_COLUMN_NBMSH].ToString();
					dtrwProdutoMaster.mstrValorFOB = dtrwProduto[TEXT_COLUMN_VALORFOB].ToString();
					dtrwProdutoMaster.mstrPesoLiquido = dtrwProduto[TEXT_COLUMN_PESOLIQUIDO].ToString();
				}
			}

			// Row Deleting
			private void dtTableMaster_RowDeleting(object sender, System.Data.DataRowChangeEventArgs e)
			{
				//TODO:Work over here
//				int nIdOrdem = Int32.Parse(e.Row[TEXT_COLUMN_IDORDEM].ToString());
//				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
//				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoMaster = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.FindBynIdExportadorstrIdPEnIdIdiomanIdOrdem(m_nIdExportador,m_strIdPE,(int)mdlConstantes.Idioma.Ingles,nIdOrdem);
//				if (dtrwProdutoMaster != null)
//					dtrwProdutoMaster.Delete();
//				m_formFProdutos.OnCallRefreshProdutosFatura();
			}
		#endregion
		#region DataColumns
			private System.Data.DataColumn GetDataColumnIdOrdem()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_IDORDEM);
				dtclRetorno.ReadOnly = true;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnRENumero()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_RENUMERO);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnREData()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_REDATA);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnNBMSH()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_NBMSH);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnValorFOB()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_VALORFOB);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnPesoLiquido()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(TEXT_COLUMN_PESOLIQUIDO);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}
		#endregion

		#region Retorno
			public string GetFormARE(int nPagina)
			{
				int nTamanhoColunaRENumero,nTamanhoColunaREData,nTamanhoColunaNCM,nTamanhoColunaValorFOB,nTamanhoColunaPesoLiquido;
				CarregaTamanhoColunas(out nTamanhoColunaRENumero, out nTamanhoColunaREData, out nTamanhoColunaNCM, out nTamanhoColunaValorFOB, out nTamanhoColunaPesoLiquido);
				System.Text.StringBuilder strbRetorno = new System.Text.StringBuilder();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE typDatSetProdutosCertificadoRE = this.TypedDataSetProdutosCertificadoFormARE;
				System.Data.DataRow[] dataRows = typDatSetProdutosCertificadoRE.tbProdutosCertificadoOrigemFormARE.Select("","nIdOrdem",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.Unchanged | System.Data.DataViewRowState.ModifiedCurrent);
				int nIndex = (nPagina * 4);
				int nMax = nIndex + 4;
				if (nMax > dataRows.Length)
					nMax = dataRows.Length;
				for(int i = nIndex; i < nMax;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE.tbProdutosCertificadoOrigemFormARERow)dataRows[i];
					StringBuilderInsert(strbRetorno,dtrwProdutoCertificado.mstrNumeroRE,nTamanhoColunaRENumero);
					StringBuilderInsert(strbRetorno,dtrwProdutoCertificado.mstrREData,nTamanhoColunaREData);
					StringBuilderInsert(strbRetorno,dtrwProdutoCertificado.mstrClassiTarifaria,nTamanhoColunaNCM);
					StringBuilderInsert(strbRetorno,dtrwProdutoCertificado.mstrValorFOB,nTamanhoColunaValorFOB);
					StringBuilderInsert(strbRetorno,dtrwProdutoCertificado.mstrPesoLiquido,nTamanhoColunaPesoLiquido);
					strbRetorno.Append(System.Environment.NewLine);
					strbRetorno.Append(System.Environment.NewLine);
				}
				return(strbRetorno.ToString());
			}

			private void StringBuilderInsert(System.Text.StringBuilder strbRetorno,string strTexto,int nSize)
			{
				if (strTexto.Length < nSize)
				{
					strbRetorno.Append(strTexto);
					for(int i = nSize - strTexto.Length ; i > 0;i--)
						strbRetorno.Append(" ");
				}else{
					strbRetorno.Append(strTexto.Substring(0,nSize));
				}
			}
		#endregion
	}
}
