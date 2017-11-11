using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdioma.
	/// </summary>
	public abstract class clsIdioma
	{
		#region Static
		
			public static int nIdioma()
			{
				int nReturn = 1;
				switch(System.Globalization.CultureInfo.CurrentCulture.Name)
				{
					case "pt-BR":
						nReturn = 1;
						break;
				}
				return(nReturn);
			} 

			public static System.Globalization.CultureInfo ciIdioma(int nIdIdioma)
			{
				System.Globalization.CultureInfo ciReturn = null;
				switch(nIdIdioma)
				{
					case 1: // PORTUGUES 
						ciReturn = new System.Globalization.CultureInfo("pt-BR");
						break;
					case 2: // ESPANHOL
						ciReturn = new System.Globalization.CultureInfo("es-ES");
						break;
					case 3: // INGLES
						ciReturn = new System.Globalization.CultureInfo("en-US");
						break;
					case 4: // ALEMAO
						ciReturn = new System.Globalization.CultureInfo("de-DE");
						break;
					case 5: // FRANCES
						ciReturn = new System.Globalization.CultureInfo("fr-FR");
						break;
					case 6: // ITALIANO
						ciReturn = new System.Globalization.CultureInfo("it-IT");
						break;
					case 7: // ARABE
						ciReturn = new System.Globalization.CultureInfo("ar-SA");
						break;
					case 8: // RUSSO
						ciReturn = new System.Globalization.CultureInfo("ru-RU");
						break;
					case 9: // POLONES
						ciReturn = new System.Globalization.CultureInfo("pl-PL");
						break;
					case 10: // CHINES_TRADICIONAL
						ciReturn = new System.Globalization.CultureInfo("zh-CHT");
						break;
					case 11: // ESPERANTO
						break;
					case 12: // JAPONES
						ciReturn = new System.Globalization.CultureInfo("ja-JP");
						break;
					case 13: // TURCO
						ciReturn = new System.Globalization.CultureInfo("tr-TR");
						break;
					case 14: // HOLANDES
						ciReturn = new System.Globalization.CultureInfo("nl-NL");
						break;
					case 15: // GREGO
						ciReturn = new System.Globalization.CultureInfo("el-GR");
						break;
					case 16: // HEBRAICO
						ciReturn = new System.Globalization.CultureInfo("he-IL");
						break;
					case 17: // COREANO
						ciReturn = new System.Globalization.CultureInfo("ko-KR");
						break;
				}
				return(ciReturn);
			}

			public static System.Drawing.Image imBandeira(int nIdImagem)
			{
				nIdImagem--;
				frmFIdiomasIndisponiveis formFIdiomas = new frmFIdiomasIndisponiveis("");
				if ((nIdImagem >= 0) && (formFIdiomas.m_ilBandeiras.Images.Count > nIdImagem - 1))
					return(formFIdiomas.m_ilBandeiras.Images[nIdImagem]);
				else
					return(null);
			}

			public static System.Windows.Forms.ImageList Bandeiras()
			{
				return(new frmFIdiomas().Bandeiras);
			}
		#endregion

		#region Constants
			private const int ID_IDIOMA_PORTUGUES = 1;
			private const int ID_IDIOMA_ESPANHOL = 2;
			private const int ID_IDIOMA_INGLES = 3;
			private const int ID_IDIOMA_ALEMAO = 4;
			private const int ID_IDIOMA_FRANCES = 5;
			private const int ID_IDIOMA_ITALIANO = 6;
			private const int ID_IDIOMA_ARABE = 7;
			private const int ID_IDIOMA_RUSSO = 8;
			private const int ID_IDIOMA_POLONES = 9;
			private const int ID_IDIOMA_CHINES_TRADICIONAL = 10;
			private const int ID_IDIOMA_ESPERANTO = 11;
			private const int ID_IDIOMA_JAPONES = 12;
			private const int ID_IDIOMA_TURCO = 13;
			private const int ID_IDIOMA_HOLANDES = 14;
			private const int ID_IDIOMA_GREGO = 15;
			private const int ID_IDIOMA_HEBRAICO = 16;
			private const int ID_IDIOMA_COREANO = 17;
		#endregion
		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;
		
		private frmFIdiomas m_formFIdiomas = null;
		public bool m_bModificado = false;
		protected int m_nIdExportador = -1;
		protected string m_strCodigo = "";
		protected string m_strOutrosCustos;

		protected bool m_bIdiomaInstaladoArabe = true;
		protected bool m_bIdiomaInstaladoChinesTradicional = true;

		private int m_nIdiomaAntigo = -1;
		protected int m_nIdioma = -1;
		protected string m_strIdioma = "Indefinido";

		private mdlDataBaseAccess.Tabelas.XsdTbIdiomas m_typDatSetTbIdiomas;

		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;

		// Cores
		private System.Drawing.Color m_clrCollumnForeColor = System.Drawing.Color.White;	 
		private System.Drawing.Color m_clrCollumnBackColor = System.Drawing.Color.Black;	 

		private mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetProdutosIdiomas = null;
		// ***************************************************************************************************
		#endregion
		#region Properties
			protected int IdiomaAntigo
			{
				set
				{
					m_nIdiomaAntigo = value;
				}
				get
				{
					return(m_nIdiomaAntigo);
				}
			}

			protected mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas TypDatSetProdutosIdiomas
			{
				get
				{
					if (m_typDatSetProdutosIdiomas != null)
						return(m_typDatSetProdutosIdiomas);

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
																					 
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosIdiomas);
				}
			}
		#endregion
		#region Construtors and Destructors
		public clsIdioma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_strCodigo = Codigo;
				m_ilBandeiras = bandeiras;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public clsIdioma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int idIdioma, ref System.Windows.Forms.ImageList bandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_nIdioma = idIdioma;
				m_ilBandeiras = bandeiras;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				try
				{
					m_formFIdiomas = new frmFIdiomas(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
					vInitializeEvents(ref m_formFIdiomas);
					m_formFIdiomas.ShowDialog();
					m_bModificado = m_formFIdiomas.m_bModificado;
					m_formFIdiomas = null;
				}
				catch (Exception erro)
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
			}
				
			private void vInitializeEvents(ref frmFIdiomas formFIdiomas)
			{
				// Carrega Dados BD
				formFIdiomas.eCallCarregaDadosBD += new frmFIdiomas.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				formFIdiomas.eCallCarregaDadosInterface += new frmFIdiomas.delCallCarregaDadosInterface(carregaDadosInterface);

				//Checagem de Integridade
				formFIdiomas.eCallChecaIntegridadeDados += new frmFIdiomas.delCallChecaIntegridadeDados(checaIntegridadeDados);

				// Salva Dados BD
				formFIdiomas.eCallSalvaDadosBD += new frmFIdiomas.delCallSalvaDadosBD(SalvaDadosBD);

				// Salva Dados Interface
				formFIdiomas.eCallSalvaDadosInterface += new frmFIdiomas.delCallSalvaDadosInterface(SalvaDadosInterface);

				// Idiomas Indisponiveis Visivel
				formFIdiomas.eCallIdiomasInstaladosVisivel += new mdlIdioma.frmFIdiomas.delCallIdiomasInstaladosVisivel(bIdiomasInstaladosVisivel);

				// Idiomas Indisponiveis Show
				formFIdiomas.eCallIdiomasInstaladosShow += new mdlIdioma.frmFIdiomas.delCallIdiomasInstaladosShow(ShowDialogIdiomasIndisponiveis);
			}
		#endregion
		#region ShowDialogIdiomasIndisponiveis
			private void ShowDialogIdiomasIndisponiveis()
			{
				frmFIdiomasIndisponiveis formFIdiomasIndisponiveis = new frmFIdiomasIndisponiveis(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFIdiomasIndisponiveis);
				formFIdiomasIndisponiveis.ShowDialog();
				formFIdiomasIndisponiveis.Dispose();
			}

			private void vInitializeEvents(ref frmFIdiomasIndisponiveis formFIdiomasIndisponiveis)
			{
				// Idioma Instalado Chines Tradicional
				formFIdiomasIndisponiveis.eCallIdiomaInstaladoChinesTradicional += new mdlIdioma.frmFIdiomasIndisponiveis.delCallIdiomaInstaladoChinesTradicional(formFIdiomasIndisponiveis_eCallIdiomaInstaladoChinesTradicional);

				// ShowDialogIdiomasIndisponiveisChinesTradicional
				formFIdiomasIndisponiveis.eCallIdiomaShowChinesTradicional += new mdlIdioma.frmFIdiomasIndisponiveis.delCallIdiomaShowChinesTradicional(ShowDialogIdiomasIndisponiveisChinesTradicional);
			}

			private bool formFIdiomasIndisponiveis_eCallIdiomaInstaladoChinesTradicional()
			{
				return(m_bIdiomaInstaladoChinesTradicional);
			}
		#endregion
		#region ShowDialogIdiomasIndisponiveisChinesTradicional
			private void ShowDialogIdiomasIndisponiveisChinesTradicional()
			{
				frmFIdiomasIndisponiveisChinesTradicional formFIdiomasIndisponiveisChinesTradicional = new frmFIdiomasIndisponiveisChinesTradicional(m_strEnderecoExecutavel);
				formFIdiomasIndisponiveisChinesTradicional.ShowDialog();
				formFIdiomasIndisponiveisChinesTradicional.Dispose();
			}
		#endregion

		#region Mostra Dados
		protected void mostraDados()
		{
			try
			{
				//m_formFPesos.txtPesoLiquido.Text = m_dPesoLiquido.ToString();
			} 
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
				protected void carregaDadosBD()
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwRowTbIdiomas;					
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

					arlOrdenacaoCampo.Add("mstrIdioma");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

					m_typDatSetTbIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
					
					carregaDadosBDEspecificos();

					dtrwRowTbIdiomas = m_typDatSetTbIdiomas.tbIdiomas.FindByidIdioma(m_nIdioma);
					if ((dtrwRowTbIdiomas != null) && (!dtrwRowTbIdiomas.IsmstrIdiomaNull()))
						m_strIdioma = dtrwRowTbIdiomas.mstrIdioma;
				}
				protected abstract void carregaDadosBDEspecificos();
			#endregion
			#region Interface
			protected virtual void carregaDadosInterface(ref System.Windows.Forms.ListView lvListView, ref System.Windows.Forms.GroupBox gbFields)
			{
				try 
				{
					System.Windows.Forms.ListViewItem lviIdioma;
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwRowTbIdiomas;

					lvListView.Items.Clear();
					
					for (int nCont = 0 ; nCont < m_typDatSetTbIdiomas.tbIdiomas.Rows.Count ; nCont++)
					{
						dtrwRowTbIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow)m_typDatSetTbIdiomas.tbIdiomas.Rows[nCont];
						if (!dtrwRowTbIdiomas.IsmstrIdiomaNull())
						{
							if (bIdiomaDisponivel(dtrwRowTbIdiomas.idIdioma))
							{
								lviIdioma = lvListView.Items.Add(dtrwRowTbIdiomas.mstrIdioma);
								lviIdioma.Tag = dtrwRowTbIdiomas.idIdioma;
								lviIdioma.ImageIndex = dtrwRowTbIdiomas.idIdioma - 1;
								if ((int)lviIdioma.Tag == m_nIdioma)
								{
									lviIdioma.Selected = true;
									m_strIdioma = dtrwRowTbIdiomas.mstrIdioma;
								}
							}
						}
					}
					carregaDadosInterfaceEspecificos(ref gbFields);
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private bool bIdiomaDisponivel(int nIdIdioma)
			{
				bool bRetorno = false;
				switch(nIdIdioma)
				{
					case ID_IDIOMA_PORTUGUES:
						bRetorno = true;
						break;
					case ID_IDIOMA_ESPANHOL:
						bRetorno = true;
						break;
					case ID_IDIOMA_INGLES:
						bRetorno = true;
						break;
					case ID_IDIOMA_ALEMAO:
						bRetorno = true;
						break;
					case ID_IDIOMA_FRANCES:
						bRetorno = true;
						break;
					case ID_IDIOMA_ITALIANO:
						bRetorno = true;
						break;
					case ID_IDIOMA_ARABE:
						//bRetorno = m_bIdiomaInstaladoArabe = bIdiomaDisponivelArabe();
						bRetorno = false;
						break;
					case ID_IDIOMA_RUSSO:
						bRetorno = false;
						break;
					case ID_IDIOMA_POLONES:
						bRetorno = false;
						break;
					case ID_IDIOMA_CHINES_TRADICIONAL:
						bRetorno = m_bIdiomaInstaladoChinesTradicional = bIdiomaDisponivelChinesTradicional();
						break;
					case ID_IDIOMA_ESPERANTO:
						bRetorno = true;
						break;
					case  ID_IDIOMA_JAPONES:
						bRetorno = false;
						break;
					case ID_IDIOMA_TURCO:
						bRetorno = false;
						break;
					case ID_IDIOMA_HOLANDES:
						bRetorno = false;
						break;
					case ID_IDIOMA_GREGO:
						bRetorno = false;
						break;
					case ID_IDIOMA_HEBRAICO:
						bRetorno = false;
						break;
					case ID_IDIOMA_COREANO:
						bRetorno = false;
						break;
				}
				return(bRetorno);
			}

			private bool bIdiomaDisponivelArabe()
			{
				bool bRetorno = false;
				System.Globalization.CultureInfo[] ciIdiomas = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures);
				foreach(System.Globalization.CultureInfo ciIdioma in ciIdiomas)
				{
					if (bRetorno = (ciIdioma.Name.StartsWith("ar")))
					{
						break;
					}
				}
				return(bRetorno);
			}

			private bool bIdiomaDisponivelChinesTradicional()
			{
				bool bRetorno = false;
				System.Globalization.CultureInfo[] ciIdiomas = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures);
				foreach(System.Globalization.CultureInfo ciIdioma in ciIdiomas)
				{
					if (bRetorno = (ciIdioma.Name.StartsWith("zh-CN")))
					{
						break;
					}
				}
				return(bRetorno);
			}

			protected abstract void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.GroupBox gbFields);
			#endregion
		#endregion
		#region Manipulacao de dados
			private void checaIntegridadeDados()
			{
				try
				{
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region Salvamento de Dados
			#region Interface
			private void SalvaDadosInterface(ref System.Windows.Forms.ListView lvListView, bool bModificado)
			{
				this.m_bModificado = bModificado;
				if (this.m_bModificado) {
					try 
					{
						if (lvListView.SelectedItems.Count > 0)
						{
							m_nIdioma = (int)lvListView.SelectedItems[0].Tag;
							m_strIdioma = lvListView.SelectedItems[0].Text;
						}
					} 
					catch (Exception erro) 
					{
						Object err = erro;
						m_cls_ter_tratadorErro.trataErro(ref err);
					}
				}
			}
			#endregion
			#region Banco Dados
			private void SalvaDadosBD()
			{
				SalvaDadosBDEspecificos();
			}
			protected abstract void SalvaDadosBDEspecificos();
			#endregion
		#endregion

		#region Idiomas Instalados
			private bool bIdiomasInstaladosVisivel()
			{
				bool bRetorno = false;
				bRetorno = !m_bIdiomaInstaladoChinesTradicional;
				
				return(bRetorno);
			}
		#endregion

		#region Retorna Valores
		public void retornaValores(out int nIdioma, out string strIdioma)
		{		
			nIdioma = m_nIdioma;
			strIdioma = m_strIdioma;
		}
		#endregion
	}
}
