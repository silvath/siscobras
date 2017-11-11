using System;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for clsMoeda.
	/// </summary>
	public abstract class clsMoeda
	{
		#region Static
			#region Constants
				private const int CURRENCY_REAL = 0;
				private const int CURRENCY_COROA_NOROEGUESA = 24;
				private const int CURRENCY_COROA_SUECA = 25;
				private const int CURRENCY_DOLAR_AUSTRALIANO = 26;
				private const int CURRENCY_DOLAR_AMERICANO = 28;
				private const int CURRENCY_EURO = 29;
				private const int CURRENCY_IENE_JAPONES = 31;
				private const int CURRENCY_LIBRA_ESTERLINA = 32;
				private const int CURRENCY_DOLAR_CANADENSE = 33;
				private const int CURRENCY_FRANCO_SUICO = 34;
				
			#endregion
			#region Currency
				public static double dReturnValueFromCurrencyFormated(int nIdCurrency,string strValue)
				{
					double dReturn = 0;
					switch(nIdCurrency)
					{
						case CURRENCY_DOLAR_AMERICANO:
							strValue = strValue.Replace(",","");
							strValue = strValue.Replace(".",",");
							dReturn = double.Parse(strValue);
							break;
						default:
							strValue = strValue.Replace(".","");
							dReturn = double.Parse(strValue);
							break;
					}
					return(dReturn);
				}

				public static decimal dcReturnValueFromCurrencyFormated(int nIdCurrency,string strValue)
				{
					decimal dcReturn = 0;
					switch(nIdCurrency)
					{
						case CURRENCY_DOLAR_AMERICANO:
							strValue = strValue.Replace(",","");
							strValue = strValue.Replace(".",",");
							dcReturn = decimal.Parse(strValue);
							break;
						default:
							strValue = strValue.Replace(".","");
							dcReturn = decimal.Parse(strValue);
							break;
					}
					return(dcReturn);
				}

				public static string strReturnCurrencyFormated(int nIdCurrency,double dValue,bool bShowCurrencyString)
				{
					return(strReturnCurrencyFormated(nIdCurrency,dValue,2,bShowCurrencyString));
				}

				public static string strReturnCurrencyFormated(int nIdCurrency,decimal dcValue,bool bShowCurrencyString)
				{
					return(strReturnCurrencyFormated(nIdCurrency,dcValue,2,bShowCurrencyString));
				}

				public static string strReturnCurrencyFormatedMax(int nIdCurrency,double dValue,bool bShowCurrencyString)
				{
					string strRetorno = strReturnCurrencyFormated(nIdCurrency,dValue,20,bShowCurrencyString);
					int nPontPos = strRetorno.LastIndexOf(".");
					int nVirgPos = strRetorno.LastIndexOf(",");
					if (nPontPos > nVirgPos)
					{
						// Cut
						if (strRetorno.Substring(nPontPos + 1).Length > 8)
							strRetorno = strRetorno.Substring(0,nPontPos + 9);
						while((strRetorno.EndsWith("0")) && (strRetorno.Length > (nPontPos + 3)))
							strRetorno = strRetorno.Substring(0,strRetorno.Length - 1);
					}else{
						// Cut
						if (strRetorno.Substring(nVirgPos + 1).Length > 8)
							strRetorno = strRetorno.Substring(0,nVirgPos + 9);
						while((strRetorno.EndsWith("0")) && (strRetorno.Length > (nVirgPos + 3)))
							strRetorno = strRetorno.Substring(0,strRetorno.Length - 1);
					}
					return(strRetorno);
				}

				public static string strReturnCurrencyFormatedMax(int nIdCurrency,decimal dcValue,bool bShowCurrencyString)
				{
					string strRetorno = strReturnCurrencyFormated(nIdCurrency,dcValue,20,bShowCurrencyString);
					int nPontPos = strRetorno.LastIndexOf(".");
					int nVirgPos = strRetorno.LastIndexOf(",");
					if (nPontPos > nVirgPos)
					{
						// Cut
						if (strRetorno.Substring(nPontPos + 1).Length > 8)
							strRetorno = strRetorno.Substring(0,nPontPos + 9);
						while((strRetorno.EndsWith("0")) && (strRetorno.Length > (nPontPos + 3)))
							strRetorno = strRetorno.Substring(0,strRetorno.Length - 1);
					}
					else
					{
						// Cut
						if (strRetorno.Substring(nVirgPos + 1).Length > 8)
							strRetorno = strRetorno.Substring(0,nVirgPos + 9);
						while((strRetorno.EndsWith("0")) && (strRetorno.Length > (nVirgPos + 3)))
							strRetorno = strRetorno.Substring(0,strRetorno.Length - 1);
					}
					return(strRetorno);
				}

				private static string strReturnCurrencyFormated(int nIdCurrency,double dValue,int nDecimals,bool bShowCurrencyString)
				{
					System.Globalization.NumberFormatInfo nfiCurrency = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
					nfiCurrency.CurrencySymbol = "";
					switch(nIdCurrency)
					{
						case CURRENCY_REAL:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "R$ ";
							}else{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_COROA_NOROEGUESA:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Nkr ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_COROA_SUECA:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Skr ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_AUSTRALIANO:
							nfiCurrency = new System.Globalization.CultureInfo("en-AU", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "$A ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_AMERICANO:
							nfiCurrency = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "US$ ";
							}else{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_EURO:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "€ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_IENE_JAPONES:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "¥ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_LIBRA_ESTERLINA:
							nfiCurrency = new System.Globalization.CultureInfo("en-GB", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "£ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_CANADENSE:
							nfiCurrency = new System.Globalization.CultureInfo("en-CA", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Can.$ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_FRANCO_SUICO:
							nfiCurrency = new System.Globalization.CultureInfo("it-CH", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Sw.Fr. ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						default:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (!bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
					}
					if (nDecimals == -1)
                        nfiCurrency.CurrencyDecimalDigits = 90;
					else
						nfiCurrency.CurrencyDecimalDigits = nDecimals;
					return(dValue.ToString("C",nfiCurrency));
				}

				private static string strReturnCurrencyFormated(int nIdCurrency,decimal dcValue,int nDecimals,bool bShowCurrencyString)
				{
					System.Globalization.NumberFormatInfo nfiCurrency = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
					nfiCurrency.CurrencySymbol = "";
					switch(nIdCurrency)
					{
						case CURRENCY_REAL:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "R$ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_COROA_NOROEGUESA:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Nkr ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_COROA_SUECA:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Skr ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_AUSTRALIANO:
							nfiCurrency = new System.Globalization.CultureInfo("en-AU", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "$A ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_AMERICANO:
							nfiCurrency = new System.Globalization.CultureInfo("en-US", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "US$ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_EURO:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "€ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_IENE_JAPONES:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "¥ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_LIBRA_ESTERLINA:
							nfiCurrency = new System.Globalization.CultureInfo("en-GB", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "£ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_DOLAR_CANADENSE:
							nfiCurrency = new System.Globalization.CultureInfo("en-CA", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Can.$ ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						case CURRENCY_FRANCO_SUICO:
							nfiCurrency = new System.Globalization.CultureInfo("it-CH", false).NumberFormat;
							if (bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "Sw.Fr. ";
							}
							else
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
						default:
							nfiCurrency = new System.Globalization.CultureInfo("pt-BR", false).NumberFormat;
							if (!bShowCurrencyString)
							{
								nfiCurrency.CurrencySymbol = "";
							}
							break;
					}
					if (nDecimals == -1)
						nfiCurrency.CurrencyDecimalDigits = 90;
					else
						nfiCurrency.CurrencyDecimalDigits = nDecimals;
					return(dcValue.ToString("C",nfiCurrency));
				}

			#endregion
		#endregion

		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdMoeda = -1;
		protected string m_strDescricao = "";
		protected string m_strSimbolo = "";
		protected bool m_bMostrarSimboloMoeda = false;

		protected bool m_bValorCarregado = false;
		public bool m_bModificado = false;
		protected bool m_bHasValue= false;

		private bool m_bMostrarQuestionamentoSimboloMoeda = true;

		private frmFMoeda m_formFMoeda = null;
		// ***************************************************************************************************
		#endregion
		#region Properties
			public bool MostrarQuestionamentoSimboloMoeda
			{
				set
				{
					m_bMostrarQuestionamentoSimboloMoeda = value;
				}
			}

			public int Moeda
			{
				set
				{
					m_nIdMoeda = value;
				}
			}
			public bool HasValue
			{
				get
				{
					return(m_bHasValue);
				}
			}
		#endregion
		#region Constructor e Desctructor
		public clsMoeda(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		#endregion

		#region Formulario FormFmoeda
			public void ShowDialog()
			{
				try
				{
					m_formFMoeda = new frmFMoeda(m_strEnderecoExecutavel);
					InitializeEventsFormFMoeda();
					m_formFMoeda.ShowDialog();
					m_bModificado = m_formFMoeda.m_bModificado;
					m_formFMoeda = null;
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}

			}

			private void InitializeEventsFormFMoeda()
			{
				// Questionamento se deve mostrar Simbolo moeda
				this.m_formFMoeda.eCallMostrarQuestionamentoSimboloMoeda += new mdlMoeda.frmFMoeda.delCallMostrarQuestionamentoSimboloMoeda(bRefreshMostrarQuestionamentoSimboloMoeda);

				// Refresh Colunas 
				this.m_formFMoeda.eCallRefreshMoedas += new frmFMoeda.delCallRefreshMoedas(ref RefreshMoedas);

				// Carrega Dado BD 
				this.m_formFMoeda.eCallCarregaMoeda += new frmFMoeda.delCallCarregaMoeda(ref CarregaMoedaBD);

				// Carrega Dado Interface
				this.m_formFMoeda.eCallCarregaInterace += new frmFMoeda.delCallCarregaInterace(ref CarregaInterface);

				// Salva Dado Interface 
				this.m_formFMoeda.eCallSalvaInterface += new frmFMoeda.delCallSalvaInterface(ref SalvaInterface);

				// Salva Dado BD 
				this.m_formFMoeda.eCallSalvaMoeda += new frmFMoeda.delCallSalvaMoeda(ref SalvaMoedaBD);
	               
			}
		#endregion

		#region Refresh
			private bool bRefreshMostrarQuestionamentoSimboloMoeda()
			{
				return(m_bMostrarQuestionamentoSimboloMoeda);
			}

			private void RefreshMoedas(ref System.Windows.Forms.ListView lvMoedas)
			{
				try
				{
					System.Windows.Forms.ListViewItem itemListView;

	                lvMoedas.Items.Clear();
					System.Collections.ArrayList arlOrderField = new System.Collections.ArrayList();
					arlOrderField.Add("mstrDescricao");
					System.Collections.ArrayList arlOrderDirection = new System.Collections.ArrayList();
					arlOrderDirection.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbMoedas tbMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(null,null,null,arlOrderField,arlOrderDirection);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					for (int nCont = 0 ; nCont < tbMoedas.tbMoedas.Rows.Count;nCont++)
					{
						itemListView = lvMoedas.Items.Add(tbMoedas.tbMoedas.Rows[nCont]["mstrDescricao"].ToString());
						itemListView.Tag = tbMoedas.tbMoedas.Rows[nCont]["idMoeda"].ToString();
						itemListView.SubItems.Add(tbMoedas.tbMoedas.Rows[nCont]["simbolo"].ToString());
					}
				}catch (Exception erro){
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
		#endregion
		#region Carrega Dados
			protected abstract void CarregaMoedaBD();

			private void CarregaInterface(ref System.Windows.Forms.ListView lvMoedas,out bool bMostrarSimboloMoeda)
			{
				System.Windows.Forms.ListViewItem lviItem;
				for(int nCont = 0; nCont < lvMoedas.Items.Count;nCont++)
				{
					lviItem = lvMoedas.Items[nCont];
					if (lviItem.Tag.ToString() == m_nIdMoeda.ToString())
					{
						lviItem.Selected = true;
						break;
					}else{
						lviItem.Selected = false;
					}
				}
				bMostrarSimboloMoeda = m_bMostrarSimboloMoeda;
			}
		#endregion
		#region Salva Dados
			private void SalvaInterface(ref System.Windows.Forms.ListView lvMoedas,bool bMostrarSimboloMoeda)
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_nIdMoeda = -1;
				if (lvMoedas.SelectedItems.Count > 0)
				{
					m_nIdMoeda = Int32.Parse(lvMoedas.SelectedItems[0].Tag.ToString());
					m_strDescricao = lvMoedas.SelectedItems[0].Text;
					m_strSimbolo = lvMoedas.SelectedItems[0].SubItems[1].Text;
				}
				m_bMostrarSimboloMoeda = bMostrarSimboloMoeda;
			}

			protected abstract void SalvaMoedaBD();

		#endregion

		#region Retorno
			public void retornaValores(out int nIdMoeda,out string strDescricao, out string strSimbolo,out bool bMostrarSimboloMoeda)
			{
				if (!m_bValorCarregado)
				{
					CarregaMoedaBD();
					m_bValorCarregado = true;
				}
				if ((m_nIdMoeda != -1) && (m_strDescricao == "") && (m_strSimbolo == ""))
				{
					System.Collections.ArrayList arlCondictionsFields = new System.Collections.ArrayList();
					arlCondictionsFields.Add("idMoeda");
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					System.Collections.ArrayList arlCondictionsValues = new System.Collections.ArrayList();
					arlCondictionsValues.Add(m_nIdMoeda);
					mdlDataBaseAccess.Tabelas.XsdTbMoedas tbMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(arlCondictionsFields,arlCondicaoComparador,arlCondictionsValues,null,null);
					if (tbMoedas.tbMoedas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwMoeda = (mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow)tbMoedas.tbMoedas.Rows[0];
						m_strDescricao = dtrwMoeda.mstrDescricao;
                        m_strSimbolo = dtrwMoeda.simbolo;
					} 
					tbMoedas.Dispose();
				}
				nIdMoeda = m_nIdMoeda;
				strDescricao = m_strDescricao;
				strSimbolo = m_strSimbolo;
				bMostrarSimboloMoeda = m_bMostrarSimboloMoeda;
			}
		#endregion
	}
}
