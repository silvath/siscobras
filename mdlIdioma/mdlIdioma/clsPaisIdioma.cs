using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsPaisIdioma.
	/// </summary>
	public abstract class clsPaisIdioma
	{
		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		/// <summary>
		/// Variável que indica se o Item Selecionado do Combo Box for selecionado
		/// </summary>
		public bool m_bModificado = false;
		/// <summary>
		/// Variável que indica se o Texto do País na língua selecionada foi alterado
		/// </summary>
		protected bool m_bPaisIdiomaModificado = false;
		protected string m_strCodigo = "";
		protected string m_strPaisIdioma = "";

		protected int m_nIdioma;
		protected string m_strIdioma = "";

		protected int m_nIdPais;
		protected string m_strPais = "";
		protected int m_nIdPaisInicial;

		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;

		// Form
		private frmFPaisIdioma m_formFPaisIdioma = null;
		
		// Acesso ao Banco de Dados
		protected mdlDataBaseAccess.Tabelas.XsdTbIdiomas m_typDatSetTbIdiomas;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas m_typDatSetTbPaisesIdiomas;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises;
		
		// Cores
		private System.Drawing.Color m_clrCollumnForeColor = System.Drawing.Color.White;	 
		private System.Drawing.Color m_clrCollumnBackColor = System.Drawing.Color.Black;	 
		// ***************************************************************************************************
		#endregion

		#region Construtores & Destrutores
		public clsPaisIdioma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int nIdioma, ref System.Windows.Forms.ImageList bandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdioma = nIdioma;
				m_ilBandeiras = bandeiras;
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion		
		#region InitializeEventsFormPaisIdioma
		private void InitializeEventsFormPaisIdioma()
		{
			try 
			{
				// Carrega Dados BD
				m_formFPaisIdioma.eCallCarregaDadosBD += new frmFPaisIdioma.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFPaisIdioma.eCallCarregaDadosInterface += new frmFPaisIdioma.delCallCarregaDadosInterface(carregaDadosInterface);

				//Checagem de Integridade
				m_formFPaisIdioma.eCallChecaIntegridadeDados += new frmFPaisIdioma.delCallChecaIntegridadeDados(checaIntegridadeDados);

				// Salva Dados BD
				m_formFPaisIdioma.eCallSalvaDadosBD += new frmFPaisIdioma.delCallSalvaDadosBD(SalvaDadosBD);

				// Salva Dados Interface
				m_formFPaisIdioma.eCallSalvaDadosInterface += new frmFPaisIdioma.delCallSalvaDadosInterface(SalvaDadosInterface);

				// Altera IdPais
				m_formFPaisIdioma.eCallAlteraIdConsignatario += new frmFPaisIdioma.delCallAlteraIdConsignatario(alteraIdConsignatario);

				// Carrega Dados Interface Editar
				m_formFPaisIdioma.eCallCarregaDadosInterfaceEditar += new frmFPaisIdioma.delCallCarregaDadosInterfaceEditar(carregaDadosInterfacePaisesIdioma);
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region ShowDialog
		/// <summary>
		/// Método para mostrar o frame
		/// </summary>
		public void ShowDialog()
		{
			try
			{
				m_formFPaisIdioma = new frmFPaisIdioma(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel, ref m_ilBandeiras);
				InitializeEventsFormPaisIdioma();
				m_formFPaisIdioma.ShowDialog();
				m_bModificado = m_formFPaisIdioma.m_bModificado;
				m_formFPaisIdioma.Dispose();
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
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				carregaDadosBDEspecificos();
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				carregaDadosBDPaises();
				carregaDadosBDPaisesIdioma();
			}
			protected void carregaDadosBDPaises()
			{
				try 
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idPais");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdPais);
					m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					
					if (m_typDatSetTbPaises.tbPaises.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					
						dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)m_typDatSetTbPaises.tbPaises.Rows[0];
						if (dtrwRowTbPaises != null)
						{
							if (!dtrwRowTbPaises.IsnmPaisNull())
								m_strPais = dtrwRowTbPaises.nmPais;
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosBDPaisesIdioma()
			{
				try 
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idIdioma");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdioma);
					arlCondicoesNome.Add("idPais");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdPais);

					m_typDatSetTbPaisesIdiomas = m_cls_dba_ConnectionDB.GetTbPaisesIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if (m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas.tbPaisesIdiomasRow dtrwRowTbPaisesIdiomas;
						dtrwRowTbPaisesIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas.tbPaisesIdiomasRow)m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.Rows[0];
						if (!dtrwRowTbPaisesIdiomas.IsnmPaisNull())
                            m_strPaisIdioma = dtrwRowTbPaisesIdiomas.nmPais;
					} 
					else 
					{
						m_strPaisIdioma = m_strPais;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected abstract void carregaDadosBDEspecificos();
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ComboBox cbPaises, ref mdlComponentesGraficos.TextBox tbIdioma, ref mdlComponentesGraficos.TextBox tbPaisIdioma)
			{
				try 
				{
					this.carregaDadosInterfacePaises(ref cbPaises);
					this.carregaDadosInterfaceIdioma(ref tbIdioma);
					this.carregaDadosInterfacePaisesIdioma(ref tbPaisIdioma, ref cbPaises);
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			protected void carregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try 
				{
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					arlOrdenacaoCampo.Add("nmPais");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
					
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					for (int nCont = 0 ; nCont < m_typDatSetTbPaises.tbPaises.Rows.Count ; nCont++)
					{
						dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)m_typDatSetTbPaises.tbPaises.Rows[nCont];
						if (!dtrwRowTbPaises.IsnmPaisNull())
						{
							cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
							if (dtrwRowTbPaises.idPais == m_nIdPais)
							{
								cbPaises.SelectedIndex = nCont;
								m_strPais = dtrwRowTbPaises.nmPais;
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

			protected void carregaDadosInterfaceIdioma(ref mdlComponentesGraficos.TextBox tbIdioma)
			{
				try 
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idIdioma");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdioma);												
					
					m_typDatSetTbIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwRowTbIdiomas;
					dtrwRowTbIdiomas = m_typDatSetTbIdiomas.tbIdiomas.FindByidIdioma(m_nIdioma);
					
					if ((dtrwRowTbIdiomas != null) && (!dtrwRowTbIdiomas.IsmstrIdiomaNull()))
					{
						tbIdioma.Text = dtrwRowTbIdiomas.mstrIdioma;
						tbIdioma.Tag = dtrwRowTbIdiomas.idIdioma;
						m_strIdioma = dtrwRowTbIdiomas.mstrIdioma;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			protected void carregaDadosInterfacePaisesIdioma(ref mdlComponentesGraficos.TextBox tbPaisIdioma, ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try 
				{
					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idIdioma");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdioma);
					arlCondicoesNome.Add("idPais");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdPais);

					m_typDatSetTbPaisesIdiomas = m_cls_dba_ConnectionDB.GetTbPaisesIdiomas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if (m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas.tbPaisesIdiomasRow dtrwRowTbPaisesIdiomas;
						dtrwRowTbPaisesIdiomas = (mdlDataBaseAccess.Tabelas.XsdTbPaisesIdiomas.tbPaisesIdiomasRow)m_typDatSetTbPaisesIdiomas.tbPaisesIdiomas.Rows[0];
						if (!dtrwRowTbPaisesIdiomas.IsnmPaisNull())
						{
							tbPaisIdioma.Text = dtrwRowTbPaisesIdiomas.nmPais;
							m_strPaisIdioma = dtrwRowTbPaisesIdiomas.nmPais;
						}
					} 
					else 
					{
						tbPaisIdioma.Text = cbPaises.Text;
						m_strPaisIdioma = cbPaises.Text;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Seta Id Consignatario
			protected void alteraIdConsignatario(int nIdConsignatario)
			{
				m_nIdPais = nIdConsignatario;
			}
			#endregion
		#endregion
		#region Manipulacao de dados
		public void checaIntegridadeDados()
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
			private bool SalvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbPaisIdioma, bool bModificado)
			{
				bool bRetorno = false;
				this.m_bModificado = bModificado;
				this.m_bPaisIdiomaModificado = bModificado;
				if (this.m_bModificado) 
				{
					try 
					{
						try
						{
							m_nIdPais = Int32.Parse(cbPais.ReturnObjectSelectedItem().ToString());
						}catch{
							mdlMensagens.clsMensagens.Show(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlIdioma_clsPaisIdioma_PaisSelecionadoInvalido));
							return(false);
						}
						if (m_nIdPais == m_nIdPaisInicial)
						{
							this.m_bModificado = false;
						} 
						else if (tbPaisIdioma.Text == cbPais.SelectedItem.ToString())
						{
							this.m_bPaisIdiomaModificado = false;
						}
						m_strPaisIdioma = tbPaisIdioma.Text;
						m_strPais = cbPais.SelectedItem.ToString();
						bRetorno = true;
					} 
					catch (Exception erro) 
					{
						Object err = erro;
						m_cls_ter_tratadorErro.trataErro(ref err);
					}
				}
				return(bRetorno);
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

		#region Retorna Valores
		/// <summary>
		/// Retorna os valores dos atributos de classe após o OK do usuário
		/// </summary>
		/// <param name="nIdioma"></param>
		/// <param name="strIdioma"></param>
		/// <param name="nPais"></param>
		/// <param name="strPais"></param>
		public void retornaValores(out int nIdioma, out string strIdioma, out int nPais, out string strPais)
		{
			nIdioma = m_nIdioma;
			strIdioma = m_strIdioma;
			nPais = m_nIdPais;
			strPais = m_strPaisIdioma;
		}
		#endregion

	}
}
