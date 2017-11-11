using System;
using mdlRelatoriosCallBackAreaProdutos;

namespace mdlProdutosCertificadoOrigem
{
	/// <summary>
	/// Summary description for clsProdutosFormA.
	/// </summary>
	public class clsProdutosFormA
	{
		#region Constants
			internal const string TEXTO_MASTER = "Master";
			internal const string TEXT_COLUMN_IDORDEM = "nIdOrdem";
			internal const string TEXT_COLUMN_ITEMNUMBER = "mstrNumeroOrdem";
			internal const string TEXT_COLUMN_MARKSANDNUMBEROFPACKAGES = "mstrMarca";
			internal const string TEXT_COLUMN_DESCRIPTION = "mstrDescricao";
			internal const string TEXT_COLUMN_ORIGINCRITERION = "mstrCriterioOrigem";
			internal const string TEXT_COLUMN_QUANTITY = "mstrQuantidade";
			internal const string TEXT_COLUMN_NUMBERDATEINVOICE = "mstrFaturaNumeroData";

			internal const int PAIS_ESTADOSUNIDOS = 249;
			internal const int PAIS_CANADA = 149;
			internal const int PAIS_JAPAO = 399;
			internal const int PAIS_NORUEGA = 538;
			internal const int PAIS_SUICA = 767;
			internal const int PAIS_BULGARIA = 111;	
			internal const int PAIS_ESLOVAQUIA = 247;
			internal const int PAIS_HUNGRIA = 355;
			internal const int PAIS_POLONIA = 603;
			internal const int PAIS_REPUBLICATCHECA = 791;
			internal const int PAIS_RUSSIA = 676;
			internal const int PAIS_AUSTRALIA = 69;
			internal const int PAIS_NOVAZELANDIA = 548;

			internal const int PAIS_ALEMANHA = 23;
			internal const int PAIS_AUSTRIA = 72;
			internal const int PAIS_BELGICA = 87;
			internal const int PAIS_DINAMARCA = 232;			
			internal const int PAIS_ESPANHA = 245;
			internal const int PAIS_FINLANDIA = 271;
			internal const int PAIS_FRANCA = 275;
			internal const int PAIS_GRECIA = 301;
			internal const int PAIS_IRLANMDA = 375;
			internal const int PAIS_ITALIA = 386;
			internal const int PAIS_LUXEMBURGO = 445;
			internal const int PAIS_PAISESBAIXOS = 573;
			internal const int PAIS_PORTUGAL = 607;
			internal const int PAIS_REINOUNIDO = 628;
			internal const int PAIS_SUECIA = 764;
		#endregion
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;
			protected int m_nIdExportador = -1;
			protected string m_strIdPE = "";
			private mdlConstantes.Idioma m_enumIdioma = mdlConstantes.Idioma.Portugues;
	
			private Formularios.frmFProdutosFormA m_formFProdutos = null;
			

			private mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typedDataSetProdutos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typedDataSetProdutosIdiomas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow m_dtrwFaturaComercial = null;
			private mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow m_dtrwImportador = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typedDataSetProdutosFaturaComercial = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA m_typedDataSetProdutosCertificadoFormA = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormARE m_typedDataSetProdutosCertificadoFormARE = null;

			internal string m_strColumnItemNumber = null;
			internal string m_strColumnMarkNumberOfPackages = null;
			internal string m_strColumnDescription = null;
			internal string m_strColumnOriginCriterion = null;
			internal string m_strColumnQuantity = null;
			internal string m_strColumnNumberDateInvoice = null;


			private string m_strMarks = null;
			private string m_strInvoiceNumber = null;
			private System.DateTime m_dtInvoice = System.DateTime.MinValue;

			private bool m_bDataTableEvents = false;

		#endregion
		#region Properties
			public mdlConstantes.Idioma Idioma
			{
				get
				{
					return(m_enumIdioma);
				}
				set
				{
					m_enumIdioma = value;
				}
			}

			public string ColumnItemNumber
			{
				get
				{
					if (m_strColumnItemNumber == null)
						m_strColumnItemNumber = this.GetColumnStyleName(TEXT_COLUMN_ITEMNUMBER);
					return(m_strColumnItemNumber);

				}
			}

			public string ColumnMarkNumberOfPackages
			{
				get
				{
					if (m_strColumnMarkNumberOfPackages == null)
						m_strColumnMarkNumberOfPackages = this.GetColumnStyleName(TEXT_COLUMN_MARKSANDNUMBEROFPACKAGES);
					return(m_strColumnMarkNumberOfPackages);

				}
			}

			public string ColumnDescription
			{
				get
				{
					if (m_strColumnDescription == null)
						m_strColumnDescription = this.GetColumnStyleName(TEXT_COLUMN_DESCRIPTION);
					return(m_strColumnDescription);

				}
			}

			public string ColumnOriginCriterion
			{
				get
				{
					if (m_strColumnOriginCriterion == null)
						m_strColumnOriginCriterion = this.GetColumnStyleName(TEXT_COLUMN_ORIGINCRITERION);
					return(m_strColumnOriginCriterion);

				}
			}

			public string ColumnQuantity
			{
				get
				{
					if (m_strColumnQuantity == null)
						m_strColumnQuantity = this.GetColumnStyleName(TEXT_COLUMN_QUANTITY);
					return(m_strColumnQuantity);

				}
			}

			public string ColumnNumberDateInvoice
			{
				get
				{
					if (m_strColumnNumberDateInvoice == null)
						m_strColumnNumberDateInvoice = this.GetColumnStyleName(TEXT_COLUMN_NUMBERDATEINVOICE);
					return(m_strColumnNumberDateInvoice);

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

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas TypedDataSetProdutosIdiomas
			{
				get
				{
					if (m_typedDataSetProdutosIdiomas != null)
						return(m_typedDataSetProdutosIdiomas);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idIdioma");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add((int)this.Idioma);
					m_typedDataSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typedDataSetProdutosIdiomas);
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

			private mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow Importador
			{
				get
				{
					if (m_dtrwImportador != null)
						return(m_dtrwImportador);
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = this.FaturaComercial;
					if (dtrwFaturaComercial == null)
						return(null);
					if (dtrwFaturaComercial.IsidImportadorNull())
						return(null);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idImportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(dtrwFaturaComercial.idImportador);
					mdlDataBaseAccess.Tabelas.XsdTbImportadores typDatSetImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if (typDatSetImportadores.tbImportadores.Count == 0)
						return(null);
					m_dtrwImportador = typDatSetImportadores.tbImportadores[0];
					return(m_dtrwImportador);
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
		public clsProdutosFormA(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE)
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				if (typDatSetProdutosFormA.GetChanges() != null){
					m_cls_dba_ConnectionDB.SetTbProdutosCertificadoOrigemFormA(typDatSetProdutosFormA);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(false);
				}
				return(true);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				m_formFProdutos = new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA(m_strEnderecoExecutavel);
				InitializeEvents(m_formFProdutos);
				m_formFProdutos.ShowDialog();
				if (m_formFProdutos.Confirmed)
					return(SalvaDados());
				return(false);
			}

			private void InitializeEvents(Formularios.frmFProdutosFormA formFProdutos)
			{
				//Configure Interface
				formFProdutos.eCallConfigureInterface += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallConfigureInterface(ConfigureInterface);

				//Refresh Produtos Fatura
				formFProdutos.eCallRefreshProdutosFatura += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallRefreshProdutosFatura(RefreshProdutosFatura);

				//Refresh Produtos Certificado
				formFProdutos.eCallRefreshProdutosCertificado += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallRefreshProdutosCertificado(RefreshProdutosCertificado);

				//Propriedades Produto
				formFProdutos.eCallPropriedadesProduto += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallPropriedadesProduto(ShowDialogPropriedadesProduto);

				// ShowDialogInserir
				formFProdutos.eCallShowDialogInserir += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallShowDialogInserir(ShowDialogInserirCheck);

				// ShowDialogRemover
				formFProdutos.eCallShowDialogRemover += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallShowDialogRemover(ShowDialogRemover);

				// Inverter Linhas
				formFProdutos.eCallInverterLinhas += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormA.delCallInverterLinhas(ProdutosCertificadoOrigemInverterLinhas);
			}
		#endregion
		#region ShowDialogInserir
			public bool ShowDialogInserirCheck(int nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial = this.TypedDataSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProduto);
				if (dtrwProdutoFaturaComercial == null)
					return(false);
				int nIdProduto = dtrwProdutoFaturaComercial.idProduto;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.TypedDataSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto == null)
					return(false);
				if (dtrwProduto.IsbPossuiMaterialImportadoNull())
				{
					if (ShowDialogProdutoPropriedades(nIdProduto))
						return(InserirProdutoCertificado(nIdOrdemProduto));
					return(false);
				}else{
					return(InserirProdutoCertificado(nIdOrdemProduto));
				}
			}

			public bool ShowDialogInserir(int nIdOrdemProduto)
			{
				Formularios.frmFProdutosFormAInserir form = new mdlProdutosCertificadoOrigem.Formularios.frmFProdutosFormAInserir(m_strEnderecoExecutavel);
				InitializeEvents(form);
				form.IdOrdemProduto = nIdOrdemProduto;

				form.ShowDialog();
				return(form.Confirmed);
			}

			private void InitializeEvents(Formularios.frmFProdutosFormAInserir form)
			{

			}
		#endregion
		#region ShowDialogRemover
			private bool ShowDialogRemover(int nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				for(int i = 0; i < typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow row = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA[i];
					if (row.RowState != System.Data.DataRowState.Deleted)
					{
						if (row.nIdOrdem == nIdOrdemProduto)
						{
							row.Delete();
							return(true);
						}
					}
				}
				return(false);
			}
		#endregion
		#region ShowDialogProdutoPropriedades
			private bool ShowDialogPropriedadesProduto(int nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial = this.TypedDataSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProduto);
				if (dtrwProdutoFaturaComercial == null)
					return(false);
				int nIdProduto = dtrwProdutoFaturaComercial.idProduto;
				return(ShowDialogProdutoPropriedades(nIdProduto));
			}

			private bool ShowDialogProdutoPropriedades(int nIdProduto)
			{
				mdlProdutosCertificadoOrigem.Formularios.frmFProdutoPropriedades form = new mdlProdutosCertificadoOrigem.Formularios.frmFProdutoPropriedades(m_strEnderecoExecutavel,nIdProduto);
				InitializeEvents(form);
				form.ShowDialog();
				return(form.Confirmed);
			}
			
			private void InitializeEvents(mdlProdutosCertificadoOrigem.Formularios.frmFProdutoPropriedades form)
			{
				// Carrega Dados
				form.eCallCarregaDados += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutoPropriedades.delCallCarregaDados(CarregaDadosProduto);

				// Salva Dados
				form.eCallSalvaDados += new mdlProdutosCertificadoOrigem.Formularios.frmFProdutoPropriedades.delCallSalvaDados(SalvaDadosProduto);
			}
		#endregion

		#region Refresh
			private void RefreshProdutosFatura(ref System.Windows.Forms.ListView lvProdutosFatura)
			{
				lvProdutosFatura.Items.Clear();
				// Produtos da Fatura Comercial 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFatura = this.TypedDataSetProdutosFaturaComercial;
				System.Windows.Forms.ListViewItem lviProdutoFatura = null;
				for(int i = 0; i < typDatSetProdutosFatura.tbProdutosFaturaComercial.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFatura.tbProdutosFaturaComercial[i];
					if (!ProdutoJaInseridoCertificado(dtrwProdutoFatura.idOrdem))
					{
						string strOrdem = dtrwProdutoFatura.idOrdemLancamento.ToString();
						string strCodigo = (!dtrwProdutoFatura.IsmstrCodigoProdutoNull()) ? dtrwProdutoFatura.mstrCodigoProduto : "";
						string strDescricao = "";
						if (this.Idioma == mdlConstantes.Idioma.Portugues)
						{
							strDescricao = (!dtrwProdutoFatura.IsmstrDescricaoNull()) ? dtrwProdutoFatura.mstrDescricao : "";
							if (strDescricao == "")
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.TypedDataSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
								if (dtrwProduto != null)
								{
									strDescricao = (!dtrwProduto.IsmstrDescricaoNull()) ? dtrwProduto.mstrDescricao : "";
								}
							}
						}else{
							strDescricao = (!dtrwProdutoFatura.IsmstrDescricaoLinguaEstrangeiraNull()) ?  dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira : "";
							mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = this.TypedDataSetProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,(int)this.Idioma,dtrwProdutoFatura.idProduto);
							if (dtrwProdutoIdioma != null)
							{
								if (!dtrwProdutoIdioma.IsmstrDescricaoNull())
									strDescricao = dtrwProdutoIdioma.mstrDescricao;
								else if (!dtrwProdutoIdioma.IsstrDescricaoNull())
									strDescricao = dtrwProdutoIdioma.strDescricao;
							}
						}
						lviProdutoFatura = lvProdutosFatura.Items.Add(strOrdem);
						lviProdutoFatura.SubItems.Add(strCodigo);
						lviProdutoFatura.SubItems.Add(strDescricao);
						lviProdutoFatura.Tag = dtrwProdutoFatura.idOrdem;

					}
				}
			}

			private void RefreshProdutosCertificado(ref mdlComponentesGraficos.DataGrid dgProdutosCertificado)
			{
				m_bDataTableEvents = false;

				System.Data.DataTable dataTable = this.GetDataTableMaster();

				// Fill Data 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosCertificado = this.TypedDataSetProdutosCertificadoFormA;
				System.Data.DataRow[] dataRows = typDatSetProdutosCertificado.tbProdutosCertificadoOrigemFormA.Select("","nIdOrdem",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.Unchanged | System.Data.DataViewRowState.ModifiedCurrent);
				for(int i = 0; i < dataRows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow)dataRows[i];
					System.Data.DataRow dtrwProduto = dataTable.NewRow();

					dtrwProduto[TEXT_COLUMN_IDORDEM] = dtrwProdutoCertificado.nIdOrdem;
					dtrwProduto[this.ColumnItemNumber] = dtrwProdutoCertificado.mstrNumeroOrdem;
					dtrwProduto[this.ColumnMarkNumberOfPackages] = dtrwProdutoCertificado.mstrMarca;
					dtrwProduto[this.ColumnDescription] = dtrwProdutoCertificado.mstrDescricao;
					dtrwProduto[this.ColumnOriginCriterion] = dtrwProdutoCertificado.mstrCriterioOrigem;
					dtrwProduto[this.ColumnQuantity] = dtrwProdutoCertificado.mstrQuantidade;
					dtrwProduto[this.ColumnNumberDateInvoice] = dtrwProdutoCertificado.mstrFaturaNumeroData;
                    
					dataTable.Rows.Add(dtrwProduto);
				}
				dgProdutosCertificado.DataSource = dataTable;

				m_bDataTableEvents = true;
			}
		#endregion

		#region Produtos
			private void CarregaDadosProduto(int nIdProduto, out string strDescricao, out bool bPossuiMaterialImportado,out double dPorcentagemValorNacional)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = this.TypedDataSetProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto != null)
				{
					strDescricao = dtrwProduto.mstrDescricao;
					bPossuiMaterialImportado = !dtrwProduto.IsbPossuiMaterialImportadoNull() ? dtrwProduto.bPossuiMaterialImportado : false;
					dPorcentagemValorNacional = !dtrwProduto.IsdPorcentagemValorNacionalNull() ? dtrwProduto.dPorcentagemValorNacional : 0;
				}else{
					strDescricao = "";
					bPossuiMaterialImportado = false;
					dPorcentagemValorNacional = 0;
				}
			}

			private bool SalvaDadosProduto(int nIdProduto, bool bPossuiMaterialImportado,double dPorcentagemValorNacional)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetProdutos = this.TypedDataSetProdutos;
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto == null)
					return(false);
				dtrwProduto.bPossuiMaterialImportado = bPossuiMaterialImportado;
				dtrwProduto.dPorcentagemValorNacional = dPorcentagemValorNacional;
				m_cls_dba_ConnectionDB.SetTbProdutos(typDatSetProdutos);
				if (m_cls_dba_ConnectionDB.Erro != null)
					return(false);
				m_typedDataSetProdutos = null;
				return(true);
			}

			private string GetNcm(int nIdProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = this.TypedDataSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,nIdProduto);
				if (dtrwProduto.IsstrNcmNull())
					return("");
				return(dtrwProduto.strNcm);
			}
		#endregion
		#region Produtos Certificado
			private bool ProdutoJaInseridoCertificado(int nIdOrdemProdutoFatura)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				for(int i = 0; i < typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow row = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA[i];
					if (row.RowState != System.Data.DataRowState.Deleted)
						if (row.nIdOrdemProdutoFatura == nIdOrdemProdutoFatura)
							return(true);
				}
				return(false);
			}

			private bool InserirProdutoCertificado(int nIdOrdemProduto)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosCertificado = this.TypedDataSetProdutosCertificadoFormA;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoCertificado = typDatSetProdutosCertificado.tbProdutosCertificadoOrigemFormA.NewtbProdutosCertificadoOrigemFormARow();

				dtrwProdutoCertificado.nIdExportador = m_nIdExportador;
				dtrwProdutoCertificado.strIdPE = m_strIdPE;
				dtrwProdutoCertificado.nIdIdioma = (int)mdlConstantes.Idioma.Ingles;
				int nItemNumber = dtrwProdutoCertificado.nIdOrdem = GetNextItemNumber();

				dtrwProdutoCertificado.nIdOrdemProdutoFatura = nIdOrdemProduto;
				dtrwProdutoCertificado.dQuantidade = 0;
				dtrwProdutoCertificado.mstrNumeroOrdem = nItemNumber.ToString("000");
				dtrwProdutoCertificado.mstrMarca = this.GetMarks();
				int nIdProduto;
				string strDescricao,strQuantidade = null;
				this.GetDadosProduto(nIdOrdemProduto,out nIdProduto,out strDescricao,out strQuantidade);
				dtrwProdutoCertificado.mstrDescricao = strDescricao; 
				dtrwProdutoCertificado.mstrCriterioOrigem = GetOriginCriterion(nIdProduto); 
				dtrwProdutoCertificado.mstrQuantidade = strQuantidade; 
				dtrwProdutoCertificado.mstrFaturaNumeroData = GetInvoiceNumber() + " " + GetInvoiceDateTime().ToString("MMM/dd/yyyy");

				typDatSetProdutosCertificado.tbProdutosCertificadoOrigemFormA.AddtbProdutosCertificadoOrigemFormARow(dtrwProdutoCertificado);

    			return(true);
			}
			
			private int GetNextItemNumber()
			{
				int nReturn = 1;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutos = this.TypedDataSetProdutosCertificadoFormA;
				bool bExists = true;
				while(bExists)
				{
					bExists = false;
					for(int i = 0; i < typDatSetProdutos.tbProdutosCertificadoOrigemFormA.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProduto = typDatSetProdutos.tbProdutosCertificadoOrigemFormA[i];
						if (dtrwProduto.RowState == System.Data.DataRowState.Deleted)
							continue;
						if (dtrwProduto.nIdOrdem == nReturn)
						{
							bExists = true;
							nReturn++;
							break;
						}
					}
				}
				return(nReturn);
			}

			private string GetMarks()
			{
				if (m_strMarks != null)
					return(m_strMarks);
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
                mdlDataBaseAccess.Tabelas.XsdTbExportadores typDataSetExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDataSetExportadores.tbExportadores.Count == 0)
					return("");
				m_strMarks = typDataSetExportadores.tbExportadores[0].marca;
				return(m_strMarks);
			}

			private bool GetDadosProduto(int nIdOrdemProduto,out int nIdProduto,out string strDescricao,out string strQuantidade)
			{
				strDescricao = strQuantidade = "";
				nIdProduto = -1;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFaturaComercial = this.TypedDataSetProdutosFaturaComercial;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFaturaComercial = typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProduto);
				if (dtrwProdutoFaturaComercial == null)
					return(false);
				nIdProduto = dtrwProdutoFaturaComercial.idProduto;
				if (!dtrwProdutoFaturaComercial.IsmstrDescricaoNull())
					strDescricao = dtrwProdutoFaturaComercial.mstrDescricao;
				//strDescricao = GetDescricaoProdutoIngles(nIdProduto);
				strQuantidade = dtrwProdutoFaturaComercial.dQuantidade.ToString() + " " + dtrwProdutoFaturaComercial.strUnidade;
				return(true);
			}

			private string GetDescricaoProdutoIngles(int nIdProduto)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idIdioma");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add((int)mdlConstantes.Idioma.Ingles);
				arlCondicaoCampo.Add("idProduto");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdProduto);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDataSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDataSetProdutosIdiomas.tbProdutosIdiomas.Rows.Count == 0)
					return("");
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwIdioma = typDataSetProdutosIdiomas.tbProdutosIdiomas[0];
				if (!dtrwIdioma.IsstrDescricaoNull())
					return(dtrwIdioma.strDescricao);
				if (!dtrwIdioma.IsmstrDescricaoNull())
					return(dtrwIdioma.mstrDescricao);
				return("");
			}

			private string GetOriginCriterion(int nIdProduto)
			{
				string strReturn = "";
				bool bPossuiMaterialImportado = false;
				string strDescricao;
				double dPorcentagemValorNacional = 0;
				CarregaDadosProduto(nIdProduto,out strDescricao,out bPossuiMaterialImportado,out dPorcentagemValorNacional);
				int nIdPais = GetIdPaisImportadorFatura();
				if (!bPossuiMaterialImportado)
				{
					strReturn = "P";
				}else{
					switch(nIdPais)
					{
						case PAIS_ESTADOSUNIDOS:
							strReturn = "\"Y\" " + dPorcentagemValorNacional.ToString() + "%";
							break;
						case PAIS_CANADA:
							strReturn = "G";
							break;
						case PAIS_JAPAO: 
						case PAIS_NORUEGA:
						case PAIS_SUICA:
						case PAIS_ALEMANHA:
						case PAIS_AUSTRIA:
						case PAIS_BELGICA:
						case PAIS_DINAMARCA:
						case PAIS_ESPANHA:
						case PAIS_FINLANDIA:
						case PAIS_FRANCA:
						case PAIS_GRECIA:
						case PAIS_IRLANMDA:
						case PAIS_ITALIA:
						case PAIS_LUXEMBURGO:
						case PAIS_PAISESBAIXOS:
						case PAIS_PORTUGAL:
						case PAIS_REINOUNIDO:
						case PAIS_SUECIA:
							string strNcm = GetNcm(nIdProduto);
							if (strNcm.Length > 4)
								strReturn = "\"W\"" + strNcm.Substring(0,4);
							break;
						case PAIS_BULGARIA:	
						case PAIS_ESLOVAQUIA: 
						case PAIS_HUNGRIA:
						case PAIS_POLONIA:
						case PAIS_REPUBLICATCHECA: 
						case PAIS_RUSSIA: 
							strReturn = "\"Y\" " + (100 - dPorcentagemValorNacional).ToString() + "%";
							break;
						case PAIS_AUSTRALIA: 
						case PAIS_NOVAZELANDIA:
							strReturn = "";
							break;
					}
				}
				
				return(strReturn);
			}

			private int GetIdPaisImportadorFatura()
			{
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwImportador = this.Importador;
				if ((dtrwImportador == null) || (dtrwImportador.IsidPaisCliNull()))
					return(-1);
				return(dtrwImportador.idPaisCli);
			}

			private string GetInvoiceNumber()
			{
				if (m_strInvoiceNumber != null)
					return(m_strInvoiceNumber);
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDataSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDataSetFaturasComerciais.tbFaturasComerciais.Count == 0)
					return("");
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFatura = typDataSetFaturasComerciais.tbFaturasComerciais[0];
				m_strInvoiceNumber = !dtrwFatura.IsnumeroFaturaNull() ? dtrwFatura.numeroFatura : "";
				m_dtInvoice = dtrwFatura.dataEmissao;
				return(m_strInvoiceNumber);
			}

			private System.DateTime GetInvoiceDateTime()
			{
				return(m_dtInvoice);
			}

			private bool ProdutosCertificadoOrigemInverterLinhas(int nIdOrdemProduto1, int nIdOrdemProduto2)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProduto1 = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.FindBynIdExportadorstrIdPEnIdIdiomanIdOrdem(m_nIdExportador,m_strIdPE,(int)mdlConstantes.Idioma.Ingles,nIdOrdemProduto1);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProduto2 = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.FindBynIdExportadorstrIdPEnIdIdiomanIdOrdem(m_nIdExportador,m_strIdPE,(int)mdlConstantes.Idioma.Ingles,nIdOrdemProduto2);
				if ((dtrwProduto1 == null) || (dtrwProduto2 == null))
					return(false);

				//Storing
				int nIdOrdemProdutoFatura = dtrwProduto1.nIdOrdemProdutoFatura;
				double dQuantidade = dtrwProduto1.dQuantidade ;
				string mstrMarca = dtrwProduto1.mstrMarca;
				string mstrDescricao = dtrwProduto1.mstrDescricao; 
				string mstrCriterioOrigem = dtrwProduto1.mstrCriterioOrigem; 
				string mstrQuantidade = dtrwProduto1.mstrQuantidade; 
				string mstrFaturaNumeroData = dtrwProduto1.mstrFaturaNumeroData;

				dtrwProduto1.nIdOrdemProdutoFatura = dtrwProduto2.nIdOrdemProdutoFatura;
				dtrwProduto1.dQuantidade = dtrwProduto2.dQuantidade;
				dtrwProduto1.mstrMarca = dtrwProduto2.mstrMarca;
				dtrwProduto1.mstrDescricao = dtrwProduto2.mstrDescricao; 
				dtrwProduto1.mstrCriterioOrigem = dtrwProduto2.mstrCriterioOrigem; 
				dtrwProduto1.mstrQuantidade = dtrwProduto2.mstrQuantidade; 
				dtrwProduto1.mstrFaturaNumeroData = dtrwProduto2.mstrFaturaNumeroData;

				dtrwProduto2.nIdOrdemProdutoFatura = nIdOrdemProdutoFatura;
				dtrwProduto2.dQuantidade = dQuantidade;
				dtrwProduto2.mstrMarca = mstrMarca;
				dtrwProduto2.mstrDescricao = mstrDescricao;  
				dtrwProduto2.mstrCriterioOrigem = mstrCriterioOrigem;  
				dtrwProduto2.mstrQuantidade = mstrQuantidade; 
				dtrwProduto2.mstrFaturaNumeroData = mstrFaturaNumeroData;

				return(true);
			}
		#endregion

		#region TableStyles
			private void ConfigureInterface(ref mdlComponentesGraficos.DataGrid dgProdutos)
			{
				BuildTableStyles(ref dgProdutos);
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
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnNumeroOrdem());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnMarca());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnDescricao());
			    dtgdtbstMaster.GridColumnStyles.Add(GetColumnCriterioOrigem());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnQuantidade());
				dtgdtbstMaster.GridColumnStyles.Add(GetColumnFaturaComercial());
				dgProdutos.TableStyles.Add(dtgdtbstMaster);
			}
		#endregion
		#region DataGridColumnStyles
			private string GetColumnStyleName(string strMappingName)
			{
				string strReturn = "";
				switch(this.Idioma)
				{
					case mdlConstantes.Idioma.Portugues:
						strReturn = GetColumnStyleNamePortuguese(strMappingName);
						break;
					case mdlConstantes.Idioma.Ingles:
						strReturn = GetColumnStyleNameEnglish(strMappingName);
						break;
				}
				return(strReturn);
			}

			private string GetColumnStyleNamePortuguese(string strMappingName)
			{
				string strReturn = "";
				switch(strMappingName)
				{
					case TEXT_COLUMN_ITEMNUMBER:
						strReturn = "N° da Ordem";
						break;
					case TEXT_COLUMN_MARKSANDNUMBEROFPACKAGES:
						strReturn = "Marca";
						break;
					case TEXT_COLUMN_DESCRIPTION:
						strReturn = "Descrição Produto";
						break;
					case TEXT_COLUMN_ORIGINCRITERION:
						strReturn = "Critério de Origem";
						break;
					case TEXT_COLUMN_QUANTITY:
						strReturn = "Quantidade";
						break;
					case TEXT_COLUMN_NUMBERDATEINVOICE:
						strReturn = "Fatura";
						break;
				}
				return(strReturn);
			}

			private string GetColumnStyleNameEnglish(string strMappingName)
			{
				string strReturn = "";
				switch(strMappingName)
				{
					case TEXT_COLUMN_ITEMNUMBER:
						strReturn = "Item";
						break;
					case TEXT_COLUMN_MARKSANDNUMBEROFPACKAGES:
						strReturn = "Mark";
						break;
					case TEXT_COLUMN_DESCRIPTION:
						strReturn = "Description of Goods";
						break;
					case TEXT_COLUMN_ORIGINCRITERION:
						strReturn = "Origin";
						break;
					case TEXT_COLUMN_QUANTITY:
						strReturn = "Quantity";
						break;
					case TEXT_COLUMN_NUMBERDATEINVOICE:
						strReturn = "Invoice";
						break;
				}
				return(strReturn);
			}

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

			private System.Windows.Forms.DataGridColumnStyle GetColumnNumeroOrdem()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnItemNumber;
				dtgdcsColuna.HeaderText = this.ColumnItemNumber;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 30;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnMarca()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnMarkNumberOfPackages;
				dtgdcsColuna.HeaderText = this.ColumnMarkNumberOfPackages;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 100;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnDescricao()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnDescription;
				dtgdcsColuna.HeaderText = this.ColumnDescription;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 200;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnCriterioOrigem()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnOriginCriterion;
				dtgdcsColuna.HeaderText = this.ColumnOriginCriterion;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 30;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnQuantidade()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnQuantity;
				dtgdcsColuna.HeaderText = this.ColumnQuantity;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 40;
				return(dtgdcsColuna);
			}

			private System.Windows.Forms.DataGridColumnStyle GetColumnFaturaComercial()
			{
				System.Windows.Forms.DataGridColumnStyle dtgdcsColuna = new System.Windows.Forms.DataGridTextBoxColumn();
				dtgdcsColuna.MappingName = this.ColumnNumberDateInvoice;
				dtgdcsColuna.HeaderText = this.ColumnNumberDateInvoice;
				dtgdcsColuna.NullText = "";
				dtgdcsColuna.ReadOnly = false;
				dtgdcsColuna.Width = 80;
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
					dtTable.Columns.Add(this.GetDataColumnNumeroOrdem());
					dtTable.Columns.Add(this.GetDataColumnMarca());
					dtTable.Columns.Add(this.GetDataColumnDescricao());
					dtTable.Columns.Add(this.GetDataColumnCriterioOrigem());
					dtTable.Columns.Add(this.GetDataColumnQuantidade());
					dtTable.Columns.Add(this.GetDataColumnFaturaComercial());
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
                            m_formFProdutos.OnCallRefreshProdutosCertificado();
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoMaster = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.FindBynIdExportadorstrIdPEnIdIdiomanIdOrdem(m_nIdExportador,m_strIdPE,(int)mdlConstantes.Idioma.Ingles,nIdOrdem);
				if (dtrwProdutoMaster != null)
				{
					dtrwProdutoMaster.mstrNumeroOrdem = dtrwProduto[this.ColumnItemNumber].ToString();
					dtrwProdutoMaster.mstrMarca = dtrwProduto[this.ColumnMarkNumberOfPackages].ToString();
					dtrwProdutoMaster.mstrDescricao = dtrwProduto[this.ColumnDescription].ToString();  
					dtrwProdutoMaster.mstrCriterioOrigem = dtrwProduto[this.ColumnOriginCriterion].ToString();  
					dtrwProdutoMaster.mstrQuantidade = dtrwProduto[this.ColumnQuantity].ToString(); 
					dtrwProdutoMaster.mstrFaturaNumeroData = dtrwProduto[this.ColumnNumberDateInvoice].ToString();
				}
			}

			// Row Deleting
			private void dtTableMaster_RowDeleting(object sender, System.Data.DataRowChangeEventArgs e)
			{
				int nIdOrdem = Int32.Parse(e.Row[TEXT_COLUMN_IDORDEM].ToString());
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosFormA = this.TypedDataSetProdutosCertificadoFormA;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoMaster = typDatSetProdutosFormA.tbProdutosCertificadoOrigemFormA.FindBynIdExportadorstrIdPEnIdIdiomanIdOrdem(m_nIdExportador,m_strIdPE,(int)mdlConstantes.Idioma.Ingles,nIdOrdem);
				if (dtrwProdutoMaster != null)
					dtrwProdutoMaster.Delete();
				m_formFProdutos.OnCallRefreshProdutosFatura();
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

			private System.Data.DataColumn GetDataColumnNumeroOrdem()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn(this.ColumnItemNumber);
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnMarca()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn();
				dtclRetorno.ColumnName = this.ColumnMarkNumberOfPackages;
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnDescricao()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn();
				dtclRetorno.ColumnName = this.ColumnDescription;
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnCriterioOrigem()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn();
				dtclRetorno.ColumnName = this.ColumnOriginCriterion;
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnQuantidade()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn();
				dtclRetorno.ColumnName = this.ColumnQuantity;
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}

			private System.Data.DataColumn GetDataColumnFaturaComercial()
			{
				System.Data.DataColumn dtclRetorno = new System.Data.DataColumn();
				dtclRetorno.ColumnName = this.ColumnNumberDateInvoice;
				dtclRetorno.ReadOnly = false;
				dtclRetorno.DataType = System.Type.GetType("System.String");
				dtclRetorno.DefaultValue = "";
				return(dtclRetorno);
			}
		#endregion

		#region Retorno
			public System.Collections.ArrayList GetAreaProdutosCertificadoOrigemFormA()
			{
				System.Collections.ArrayList arlReturn = new System.Collections.ArrayList();

				System.Collections.ArrayList arlColunaAtual_ItemNumber = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Marks = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Description = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_OriginCriterion = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_Quantity = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColunaAtual_NumberDateInvoices = new System.Collections.ArrayList();

				arlColunaAtual_ItemNumber.Add("4030");
				arlColunaAtual_Marks.Add("4130");
				arlColunaAtual_Description.Add("4230");
				arlColunaAtual_OriginCriterion.Add("4330");
				arlColunaAtual_Quantity.Add("4430");
				arlColunaAtual_NumberDateInvoices.Add("4530");

				// Fill Data 
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA typDatSetProdutosCertificado = this.TypedDataSetProdutosCertificadoFormA;
				System.Data.DataRow[] dataRows = typDatSetProdutosCertificado.tbProdutosCertificadoOrigemFormA.Select("","nIdOrdem",System.Data.DataViewRowState.Added | System.Data.DataViewRowState.Unchanged | System.Data.DataViewRowState.ModifiedCurrent);
				DataStruct structData;
				for(int i = 0; i < dataRows.Length;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow dtrwProdutoCertificado = (mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigemFormA.tbProdutosCertificadoOrigemFormARow)dataRows[i];

					// ItemNumber
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrNumeroOrdem;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_ItemNumber.Add(structData);

					// Marca
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrMarca;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_Marks.Add(structData);

					// Description
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrDescricao;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_Description.Add(structData);

					// OrigimCriterion
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrCriterioOrigem;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_OriginCriterion.Add(structData);

					// Quantity
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrQuantidade;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_Quantity.Add(structData);

					// Invoice
					structData = new DataStruct();
					structData.strText = dtrwProdutoCertificado.mstrFaturaNumeroData;
					structData.nHeight = 0;
					structData.nWidth = 0;
					arlColunaAtual_NumberDateInvoices.Add(structData);
				}

				arlReturn.Add(arlColunaAtual_ItemNumber);
				arlReturn.Add(arlColunaAtual_Marks);
				arlReturn.Add(arlColunaAtual_Description);
				arlReturn.Add(arlColunaAtual_OriginCriterion);
				arlReturn.Add(arlColunaAtual_Quantity);
				arlReturn.Add(arlColunaAtual_NumberDateInvoices);

				return(arlReturn);
			}
		#endregion
	}
}
