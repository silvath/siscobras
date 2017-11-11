using System;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for clsPesos.
	/// </summary>
	public abstract class clsPesos
	{
		#region	Static
			#region UnidadeMassa
				static public int nRetornaProximaUnidadeMassa(int nUnidadeMassaAtual)
				{
					int nRetorno = 0;
					switch(nUnidadeMassaAtual)
					{
						case 2: // Grama
							nRetorno = 3;
							break;
						case 3: // KiloGrama
							nRetorno = 4;
							break;
						case 4: // Tonelada
							nRetorno = 5;
							break;
						case 5: // Libra
							nRetorno = 2;
							break;
						default:
							nRetorno = 3;
							break;
					}
					return (nRetorno);
				}

				static public string strSiglaCubicaUnidadeMassa(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa)
				{
					string strSigla = strSiglaUnidadeMassa(ref typDatSetTbUnidadesMassa,ref typDatSetTbUnidadesMassaIdioma,nIdUnidadeMassa);
					if (strSigla != "")
						return(strSigla + "³");
					else
						return("");
				}
				
				static public string strSiglaUnidadeMassa(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa)
				{
					return(strSiglaUnidadeMassa(ref typDatSetTbUnidadesMassa,ref typDatSetTbUnidadesMassaIdioma,nIdUnidadeMassa,(int)mdlConstantes.Idioma.Portugues));
				}

				static public string strSiglaUnidadeMassa(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa typDatSetTbUnidadesMassa,ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
				{
					string strRetorno = strSiglaUnidadeMassaIdioma(ref typDatSetTbUnidadesMassaIdioma,nIdUnidadeMassa,nIdIdioma);
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

				static public string strSiglaUnidadeMassaIdioma(ref mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma typDatSetTbUnidadesMassaIdioma,int nIdUnidadeMassa,int nIdIdioma)
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
			#region Conversao
				static public double dRetornaFatorConversaoEntreUnidadesMassa(int nUnidadeInicial,int nUnidadeFinal)
				{
					double dRetorno = 1;
					// Convertendo Unidade Inicial para Kilo
					switch(nUnidadeInicial)
					{
						case 1: // Miligrama
							dRetorno = 0.000001;
							break;
						case 2: // Grama 
							dRetorno = 0.001;
							break;
						case 3: // KiloGrama
							dRetorno = 1;
							break;
						case 4: // Tonelada 
							dRetorno = 1000;
							break;
						case 5: // Libra
							dRetorno = 0.453;
							break;
					}

					// Convertendo Kilo para Unidade Final
					switch(nUnidadeFinal)
					{
						case 1: // Miligrama
							dRetorno = dRetorno * 1000000;
							break;
						case 2: // Grama 
							dRetorno = dRetorno * 1000;
							break;
						case 3: // KiloGrama
							dRetorno = dRetorno * 1;
							break;
						case 4: // Tonelada 
							dRetorno = dRetorno * 0.001;
							break;
						case 5: // Libra
							dRetorno = dRetorno * 2.207;
							break;
					}
					return(dRetorno);
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
		
		private frmFPesos m_formFPesos = null;
		public bool m_bModificado = false;
		protected int m_nIdExportador = -1;

		protected double m_dPesoLiquido = 0;
		protected double m_dPesoBruto = 0;
		protected int m_nUnidadeBruto = -1;
		protected int m_nUnidadeLiquido = -1;
		protected string m_strUnidadeBruto = "Kg";
		protected string m_strUnidadeLiquido = "Kg";

		protected int m_nIdioma;
		protected string m_strIdioma = "Indefinido";

		protected string m_strLabelFrame = "";

		// Tabelas
		protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa m_typDatSetTbUnidadesMassa = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma m_typDatSetTbUnidadesMassaIdioma = null;
		
		// ***************************************************************************************************
		#endregion
		#region Properties
			public double PesoLiquido
			{
				get
				{
					return(m_dPesoLiquido);
				}
			}

			public double PesoBruto
			{
				get
				{
					return(m_dPesoBruto);
				}
			}

			public int UnidadePesoLiquido
			{
				get
				{
					return(m_nUnidadeLiquido);
				}
			}

			public int UnidadePesoBruto
			{
				get
				{
					return(m_nUnidadeBruto);
				}
			}
		#endregion
		#region Construtors and Destructor
		public clsPesos(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
				protected void carregaDadosBD()
				{
					carregaDadosBDEspecificos();
					carregaDadosUnidadeMassa();
				}
				protected abstract void carregaDadosBDEspecificos();
				protected void carregaTypDatSet()
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlCondicoesNome.Add("nIdIdioma");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdioma);
					arlOrdenacaoCampo.Add("strSigla");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbUnidadesMassa = m_cls_dba_ConnectionDB.GetTbUnidadesMassa(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
					m_typDatSetTbUnidadesMassaIdioma = m_cls_dba_ConnectionDB.GetTbUnidadesMassaIdioma(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				}
				protected void carregaDadosUnidadeMassa()
				{
					if ((m_typDatSetTbUnidadesMassa == null) || (m_typDatSetTbUnidadesMassaIdioma == null))
						carregaTypDatSet();
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow dtrwRowTbUnidadesMassa;
					mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow dtrwRowTbUnidadesMassaIdioma;

					dtrwRowTbUnidadesMassaIdioma = m_typDatSetTbUnidadesMassaIdioma.tbUnidadesMassaIdioma.FindBynIdUnidadeMassanIdIdioma(m_nUnidadeBruto,m_nIdioma);
					dtrwRowTbUnidadesMassa = m_typDatSetTbUnidadesMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(m_nUnidadeBruto);
					if (dtrwRowTbUnidadesMassaIdioma != null)
					{
						m_strUnidadeBruto = dtrwRowTbUnidadesMassaIdioma.strSigla;
						dtrwRowTbUnidadesMassaIdioma = m_typDatSetTbUnidadesMassaIdioma.tbUnidadesMassaIdioma.FindBynIdUnidadeMassanIdIdioma(m_nUnidadeLiquido,m_nIdioma);
						m_strUnidadeLiquido = dtrwRowTbUnidadesMassaIdioma.strSigla;
					} 
					else if (dtrwRowTbUnidadesMassa != null)
					{
						m_strUnidadeBruto = dtrwRowTbUnidadesMassa.strSigla;
						dtrwRowTbUnidadesMassa = m_typDatSetTbUnidadesMassa.tbUnidadesMassa.FindBynIdUnidadeMassa(m_nUnidadeLiquido);
						m_strUnidadeLiquido = dtrwRowTbUnidadesMassa.strSigla;
					}
				}
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox txtPesoBruto,ref mdlComponentesGraficos.TextBox txtPesoLiquido,ref mdlComponentesGraficos.ComboBox cbUnidadeMassaLiquida,ref mdlComponentesGraficos.ComboBox cbUnidadeMassaBruta, ref System.Windows.Forms.GroupBox gbFields)
			{
				try 
				{
					txtPesoBruto.Text = m_dPesoBruto.ToString();
					txtPesoLiquido.Text = m_dPesoLiquido.ToString();;
					carregaDadosUnidadeMassaInterface(ref cbUnidadeMassaLiquida, ref cbUnidadeMassaBruta);
					gbFields.Text = m_strLabelFrame;
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosUnidadeMassaInterface(ref mdlComponentesGraficos.ComboBox cbUnidadeMassaLiquida, ref mdlComponentesGraficos.ComboBox cbUnidadeMassaBruta)
			{
				mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow dtrwRowTbUnidadesMassa;
				mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassaIdioma.tbUnidadesMassaIdiomaRow dtrwRowTbUnidadesMassaIdioma;

				for (int nCount = 0; nCount < m_typDatSetTbUnidadesMassa.tbUnidadesMassa.Rows.Count; nCount++)
				{
					dtrwRowTbUnidadesMassa = (mdlDataBaseAccess.Tabelas.XsdTbUnidadesMassa.tbUnidadesMassaRow)m_typDatSetTbUnidadesMassa.tbUnidadesMassa.Rows[nCount];
					dtrwRowTbUnidadesMassaIdioma = m_typDatSetTbUnidadesMassaIdioma.tbUnidadesMassaIdioma.FindBynIdUnidadeMassanIdIdioma(dtrwRowTbUnidadesMassa.nIdUnidadeMassa,m_nIdioma);
					if (dtrwRowTbUnidadesMassaIdioma != null)
					{
						cbUnidadeMassaBruta.AddItem(dtrwRowTbUnidadesMassaIdioma.strSigla,dtrwRowTbUnidadesMassaIdioma.nIdUnidadeMassa);
						cbUnidadeMassaLiquida.AddItem(dtrwRowTbUnidadesMassaIdioma.strSigla,dtrwRowTbUnidadesMassaIdioma.nIdUnidadeMassa);
					} 
					else if (dtrwRowTbUnidadesMassa != null)
					{
						cbUnidadeMassaBruta.AddItem(dtrwRowTbUnidadesMassa.strSigla,dtrwRowTbUnidadesMassa.nIdUnidadeMassa);
						cbUnidadeMassaLiquida.AddItem(dtrwRowTbUnidadesMassa.strSigla,dtrwRowTbUnidadesMassa.nIdUnidadeMassa);
					}
				}
				cbUnidadeMassaBruta.SelectItem(m_nUnidadeBruto);
				cbUnidadeMassaLiquida.SelectItem(m_nUnidadeLiquido);
			}
		#endregion
		#endregion
		#region Manipulacao de dados
			protected void checaIntegridadeDados(ref mdlComponentesGraficos.TextBox txtPesoBruto, ref mdlComponentesGraficos.TextBox txtPesoLiquido)
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
			private void SalvaDadosInterface(ref mdlComponentesGraficos.TextBox txtPesoBruto, ref mdlComponentesGraficos.TextBox txtPesoLiquido, ref mdlComponentesGraficos.ComboBox cbUnidadeMassaLiquida, ref mdlComponentesGraficos.ComboBox cbUnidadeMassaBruta, bool m_bModificado)
			{
				try 
				{
					this.m_bModificado = m_bModificado;
					try
					{
						m_dPesoBruto = Double.Parse(txtPesoBruto.Text);
					}catch{
						m_dPesoBruto = 0;
					}
					try
					{
						m_dPesoLiquido = Double.Parse(txtPesoLiquido.Text);
					}catch{
						m_dPesoLiquido = 0;
					}
					m_nUnidadeLiquido = Int32.Parse(cbUnidadeMassaLiquida.ReturnObjectSelectedItem().ToString());
					m_nUnidadeBruto = Int32.Parse(cbUnidadeMassaBruta.ReturnObjectSelectedItem().ToString());
					m_strUnidadeBruto = cbUnidadeMassaBruta.Text;
					m_strUnidadeLiquido = cbUnidadeMassaLiquida.Text;
				} 
				catch (Exception erro) 
				{
					Object err = (Object)erro;
					m_cls_ter_tratadorErro.trataErro(ref err);
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

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFPesos = new frmFPesos(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				InitializeEventsFormPesos();
				m_formFPesos.ShowDialog();
				m_bModificado = m_formFPesos.m_bModificado;
				m_formFPesos.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region InitializeEventsFormPesos
		private void InitializeEventsFormPesos()
		{
			try 
			{
				// Carrega Dados BD
				m_formFPesos.eCallCarregaDadosBD += new frmFPesos.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFPesos.eCallCarregaDadosInterface += new frmFPesos.delCallCarregaDadosInterface(carregaDadosInterface);

				//Checagem de Integridade
				m_formFPesos.eCallChecaIntegridadeDados += new frmFPesos.delCallChecaIntegridadeDados(checaIntegridadeDados);

				// Salva Dados BD
				m_formFPesos.eCallSalvaDadosBD += new frmFPesos.delCallSalvaDadosBD(SalvaDadosBD);

				// Salva Dados Interface
				m_formFPesos.eCallSalvaDadosInterface += new frmFPesos.delCallSalvaDadosInterface(SalvaDadosInterface);
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
			public void retornaValores(out Double dPesoLiquido, out Double dPesoBruto, out string strUnidadePesoLiquido, out string strUnidadePesoBruto)
			{
				dPesoLiquido = m_dPesoLiquido;
				dPesoBruto = m_dPesoBruto;
				strUnidadePesoBruto = m_strUnidadeBruto;
				strUnidadePesoLiquido = m_strUnidadeLiquido;
			}
		#endregion
	}
}