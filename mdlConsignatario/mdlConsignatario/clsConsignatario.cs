using System;

namespace mdlConsignatario
{
	/// <summary>
	/// Summary description for clsConsignatario.
	/// </summary>
	public class clsConsignatario
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		private frmFConsignatario m_formFConsignatario = null;
		private frmFConsignatarioCadEdit m_formFConsignatarioCadEdit = null;
		
		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdConsignatario = -1;
		protected string m_strIdPE = "";
		protected int m_nIdPais = -1;

		protected string m_strImportador = "";
		protected string m_strImportadorConsignatario = "";
		protected string m_strEnderecoConsignatario = "";
		protected string m_strCidade = "";
		protected string m_strEstado = "";
		protected string m_strPais = "";

		private bool m_bDataAccess = true;

		public bool m_bModificado = false;

		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios m_typDatSetTbImportadoresConsignatarios;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		protected mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises;
		#endregion
		#region Properties
			internal bool DataAccess
			{
				set
				{
					m_bDataAccess = value;
				}
				get
				{
					return(m_bDataAccess);
				}
			}

			internal int IdImportador
			{
				set
				{
					m_nIdImportador = value;
				}
				get
				{
					return(m_nIdImportador);
				}
			}

			internal int IdConsignatario
			{
				set
				{
					m_nIdConsignatario = value;
					vCarregaTypedDataSetImportadores();
					vCarregaTypedDataSetImportadoresConsignatarios();
					carregaDadosBDImportadores();
					carregaDadosBDConsignatario();
				}
				get
				{
					return(m_nIdConsignatario);
				}
			}
		#endregion

		#region Construtores & Destrutores
		public clsConsignatario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region InitializeEventsFormConsignatario
		private void InitializeEventsFormConsignatario()
		{
			try 
			{
				// Carrega Dados BD
				m_formFConsignatario.eCallCarregaDadosBD += new frmFConsignatario.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFConsignatario.eCallCarregaDadosInterface += new frmFConsignatario.delCallCarregaDadosInterface(carregaDadosInterface);

				// Carrega Dados Consignatario Interface
				m_formFConsignatario.eCallCarregaDadosConsignatarioInterface += new frmFConsignatario.delCallCarregaDadosConsignatarioInterface(carregaDadosConsignatarioInterface);

				// Carrega Dados BD Consignatário
				m_formFConsignatario.eCallCarregaDadosBDConsignatarios += new frmFConsignatario.delCallCarregaDadosBDConsignatarios(carregaDadosBDConsignatario);

				// Carrega Dados BD Consignatários Selecionado
				m_formFConsignatario.eCallCarregaDadosConsignatarioSelecionado += new frmFConsignatario.delCallCarregaDadosConsignatarioSelecionado(carregaDadosImportadorConsignatario);

				// Anular Seleção
				m_formFConsignatario.eCallAnulaSelecao += new frmFConsignatario.delCallAnulaSelecao(anularSelecao);

				// Salva Dados Interface
				m_formFConsignatario.eCallSalvaDadosInterface += new frmFConsignatario.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				m_formFConsignatario.eCallSalvaDadosBD += new frmFConsignatario.delCallSalvaDadosBD(salvaDadosBD);

				// Editar Consignatário
				m_formFConsignatario.eCallEditaConsignatario += new frmFConsignatario.delCallEditaConsignatario(editaConsignatario);

				// Cadastra Consignatário
				m_formFConsignatario.eCallCadastraConsignatario += new frmFConsignatario.delCallCadastraConsignatario(cadastraConsignatario);

				// Remove Consignatário
				m_formFConsignatario.eCallRemoveConsignatario += new frmFConsignatario.delCallRemoveConsignatario(removeConsignatario);
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
		/// Método para mostrar o frame que lista os consignatários
		/// </summary>
		public void ShowDialog()
		{
			try
			{
				m_formFConsignatario = new frmFConsignatario(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				InitializeEventsFormConsignatario();
				m_formFConsignatario.ShowDialog();
				m_bModificado = m_formFConsignatario.m_bModificado;
				m_formFConsignatario.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region InitializeEventsFormConsignatarioCadEdit
		private void InitializeEventsFormConsignatarioCadEdit()
		{
			// Carrega BD
			m_formFConsignatarioCadEdit.eCallCarregaDadosBD += new frmFConsignatarioCadEdit.delCallCarregaDadosBD(carregaDadosBDImportadorConsignatario);

			// Carrega Dados Interface
			m_formFConsignatarioCadEdit.eCallCarregaDadosInterface += new frmFConsignatarioCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceImportadorConsignatario);

			// Carrega Dados Interface Paises
			m_formFConsignatarioCadEdit.eCallCarregaDadosInterfacePaises += new frmFConsignatarioCadEdit.delCallCarregaDadosInterfacePaises(carregaDadosInterfacePaises);

			// Salva Dados Interface
			m_formFConsignatarioCadEdit.eCallSalvaDadosInterface += new frmFConsignatarioCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceImportadorConsignatario);

			// Salva Dados BD
			m_formFConsignatarioCadEdit.eCallSalvaDadosBD += new frmFConsignatarioCadEdit.delCallSalvaDadosBD(salvaDadosBDImportadorConsignatario);
		}
		#endregion

		#region Show Dialog Cadastro e Edição de Consignatários
		public void ShowDialogCadEdit()
		{
			try
			{
				m_formFConsignatarioCadEdit = new frmFConsignatarioCadEdit(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref m_formFConsignatario);
				InitializeEventsFormConsignatarioCadEdit();
				m_formFConsignatarioCadEdit.ShowDialog();
				m_bModificado = m_formFConsignatarioCadEdit.m_bModificado;
				m_formFConsignatarioCadEdit.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Edita Consignatário
		protected void editaConsignatario()
		{
			try
			{
				m_formFConsignatarioCadEdit = new frmFConsignatarioCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFConsignatario);
				InitializeEventsFormConsignatarioCadEdit();
				m_formFConsignatarioCadEdit.setTextoGroupBox("Edição");
				m_formFConsignatarioCadEdit.ShowDialog();
				m_formFConsignatarioCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Consignatário
		protected void cadastraConsignatario()
		{
			try
			{
				m_formFConsignatarioCadEdit = new frmFConsignatarioCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFConsignatario,true);
				InitializeEventsFormConsignatarioCadEdit();
				m_formFConsignatarioCadEdit.setTextoGroupBox("Cadastro");
				m_formFConsignatarioCadEdit.ShowDialog();
				m_formFConsignatarioCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Consignatário
		protected void removeConsignatario(ref mdlComponentesGraficos.ListView lvConsignatarios)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario;
			int nIdConsignatario = 0;
			if (lvConsignatarios.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Consignatários",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlConsignatario_clsConsignatario_ApagarConsignatario).Replace("\\n","\n").Replace("TAG",lvConsignatarios.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvConsignatarios.SelectedItems.Count.ToString() + " consignatario(s)?","Consignatários",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvConsignatarios.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdConsignatario = Int32.Parse(lvConsignatarios.SelectedItems[0].Tag.ToString());
					dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,nIdConsignatario);
					dtrwRowTbImportadoresConsignatario.Delete();
					lvConsignatarios.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strImportadorConsignatario = "";
					m_strCidade = "";
					m_strEnderecoConsignatario = "";
					m_strEstado = "";
					m_nIdPais = -1;
					m_strPais = "";					
				}
			}
		}
		#endregion
		#region Anular Seleção
		private void anularSelecao(ref mdlComponentesGraficos.ListView lvConsignatarios)
		{
			try
			{
				System.Collections.ArrayList arlItemsSelecionados = new System.Collections.ArrayList();
				foreach(System.Windows.Forms.ListViewItem lvItemConsignatario in lvConsignatarios.SelectedItems)
				{
					arlItemsSelecionados.Add(lvItemConsignatario);
				}
				foreach(System.Windows.Forms.ListViewItem lvItemConsignatario in arlItemsSelecionados)
				{
					lvItemConsignatario.Selected = false;
				}
				m_nIdConsignatario = -1;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados
			#region Ordenando
			private System.Collections.SortedList retornaConsignatariosOrdenado()
			{
				System.Collections.SortedList srlConsignatarios = new System.Collections.SortedList();
				try
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario in m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.Rows)
					{
						if ((dtrwRowTbImportadoresConsignatario.RowState != System.Data.DataRowState.Deleted) && (!srlConsignatarios.Contains(dtrwRowTbImportadoresConsignatario.strNome)))
							srlConsignatarios.Add(dtrwRowTbImportadoresConsignatario.strNome, dtrwRowTbImportadoresConsignatario);
					}
				}
				catch (Exception err)
				{
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
				return srlConsignatarios;
			}
			#endregion
			#region Banco de Dados
			protected virtual void carregaTypDatSet()
			{
				try
				{
					#region Variáveis
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais;
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes;

					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					#endregion

					#region Faturas Comerciais & PEs
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);

					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					if ((m_typDatSetTbFaturasComerciais != null) && (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0))
					{
						dtrwRowTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
							m_nIdImportador = dtrwRowTbFaturasComerciais.idImportador;
						else
							m_nIdImportador = -1;

						if ((m_typDatSetTbPes != null) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
						{
							dtrwRowTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
							if (!dtrwRowTbPes.IsnIdConsignatarioNull())
								m_nIdConsignatario = dtrwRowTbPes.nIdConsignatario;
						}
						#endregion
						if (this.DataAccess)
						{
							vCarregaTypedDataSetImportadores();
							vCarregaTypedDataSetImportadoresConsignatarios();
						}
					}
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,null,null);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void vCarregaTypedDataSetImportadores()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}

			private void vCarregaTypedDataSetImportadoresConsignatarios()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("nIdImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbImportadoresConsignatarios = m_cls_dba_ConnectionDB.GetTbImportadoresConsignatarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}

			protected void carregaDadosBD()
			{
				try 
				{
					carregaDadosBDPEs();
					carregaDadosBDImportadores();
					carregaDadosBDConsignatario();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void carregaDadosBDImportadores()
			{
				if ((m_typDatSetTbImportadores != null) && (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowImportadores;
					dtrwRowImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if ((dtrwRowImportadores != null) && (!dtrwRowImportadores.IsnmCliNull()))
						m_strImportador = dtrwRowImportadores.nmCli;
				}
			}
			private void carregaDadosBDPEs()
			{
				if ((m_typDatSetTbPes != null) && (m_typDatSetTbPes.tbPEs.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = null;
					dtrwTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					if ((dtrwTbPes != null) && (!dtrwTbPes.IsnIdConsignatarioNull()))
						m_nIdConsignatario = dtrwTbPes.nIdConsignatario;
				}
			}
			private void carregaDadosBDConsignatario()
			{
				if (m_typDatSetTbImportadoresConsignatarios != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowImportadoresConsignatarios;
					dtrwRowImportadoresConsignatarios = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,m_nIdConsignatario);
					if (dtrwRowImportadoresConsignatarios != null)
					{
						if (!dtrwRowImportadoresConsignatarios.IsstrNomeNull())
							m_strImportadorConsignatario = dtrwRowImportadoresConsignatarios.strNome;
						else
							m_strImportadorConsignatario = "";
						if (!dtrwRowImportadoresConsignatarios.IsmstrEnderecoNull())
							m_strEnderecoConsignatario = dtrwRowImportadoresConsignatarios.mstrEndereco;
						else
							m_strEnderecoConsignatario = "";
						if (!dtrwRowImportadoresConsignatarios.IsstrCidadeNull())
							m_strCidade = dtrwRowImportadoresConsignatarios.strCidade;
						else
							m_strCidade = "";
						if (!dtrwRowImportadoresConsignatarios.IsstrEstadoNull())
							m_strEstado = dtrwRowImportadoresConsignatarios.strEstado;
						else
							m_strEstado = "";
						if (!dtrwRowImportadoresConsignatarios.IsnIdPaisNull())
						{
							mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(dtrwRowImportadoresConsignatarios.nIdPais);
							if ((dtrwTbPaises != null) && (!dtrwTbPaises.IsnmPaisNull()))
								m_strPais =  dtrwTbPaises.nmPais;
						}
					}
				}			
			}
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvConsignatarios, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Label lNomeImportador)
			{
				try
				{
					System.Collections.SortedList srlConsignatarios = retornaConsignatariosOrdenado();
					// List View Item
					System.Windows.Forms.ListViewItem lvItemConsignatario;
					// Limpa os Items da List View
					lvConsignatarios.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < srlConsignatarios.Count ; nCont++)
					{
						dtrwRowTbImportadoresConsignatario = (mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow)srlConsignatarios.GetByIndex(nCont);
						if (dtrwRowTbImportadoresConsignatario.RowState != System.Data.DataRowState.Deleted)
						{
							lvItemConsignatario = lvConsignatarios.Items.Add(dtrwRowTbImportadoresConsignatario.strNome);
							lvItemConsignatario.Tag = dtrwRowTbImportadoresConsignatario.nIdConsignatario;
							if ((int)lvItemConsignatario.Tag == m_nIdConsignatario)
							{
								lvItemConsignatario.Selected = true;
							}
						}
					}
					if (lvConsignatarios.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
					} 
					else
					{
						btEditar.Enabled = true;
						btExcluir.Enabled = true;
					}
					lNomeImportador.Text = m_strImportador;
				}
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosConsignatarioInterface(ref mdlComponentesGraficos.ListView lvDadosConsignatario)
			{
				try
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemDadosConsignatario;
					// Limpa os Items da List View
					lvDadosConsignatario.Items.Clear();

					#region Adicionando Items à ListView
					#region Nome
//					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add("Nome: ");
//					lvItemDadosConsignatario.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosConsignatario.UseItemStyleForSubItems = false;
//					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add(m_strImportadorConsignatario);
					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = null;
					#endregion
					#region Endereço
//					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add("Endereço: ");
//					lvItemDadosConsignatario.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosConsignatario.UseItemStyleForSubItems = false;
//					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add(m_strEnderecoConsignatario);
					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = null;
					#endregion
					#region Cidade
//					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add("Cidade: ");
//					lvItemDadosConsignatario.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosConsignatario.UseItemStyleForSubItems = false;
//					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add(m_strCidade);
					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = null;
					#endregion
					#region Estado
//					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add("Estado: ");
//					lvItemDadosConsignatario.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosConsignatario.UseItemStyleForSubItems = false;
//					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add(m_strEstado);
					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = null;
					#endregion
					#region País
//					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add("Pais: ");
//					lvItemDadosConsignatario.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosConsignatario.UseItemStyleForSubItems = false;
//					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = lvDadosConsignatario.Items.Add(m_strPais);
					lvItemDadosConsignatario.Font = new System.Drawing.Font(lvItemDadosConsignatario.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosConsignatario = null;
					#endregion
					#endregion
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion
		#region Salvamento de Dados
			#region Interface
			protected void salvaDadosInterface(ref mdlComponentesGraficos.ListView lvConsignatarios)
			{
				if (lvConsignatarios.Items.Count == 0 || lvConsignatarios.SelectedItems.Count == 0)
				{
					m_nIdConsignatario = -1;
				} 
				else if (lvConsignatarios.Items.Count > 0 && lvConsignatarios.SelectedItems.Count == 1)
				{
					m_nIdConsignatario = Int32.Parse(lvConsignatarios.SelectedItems[0].Tag.ToString());
				} 
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Consignatários",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlConsignatario_clsConsignatario_MaisDeUmConsignatarioSelecionado).Replace("\\n","\n").Replace("TAG",lvConsignatarios.SelectedItems[0].Text));
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de um consignatario!\nO consignatario selecionado será: " + lvConsignatarios.SelectedItems[0].Text,"Consignatários");
					m_nIdConsignatario = Int32.Parse(lvConsignatarios.SelectedItems[0].Tag.ToString());
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				if (this.DataAccess)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
					dtrwRowTbPes.nIdConsignatario = m_nIdConsignatario;
				}
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
				dtrwRowTbImportadores.idConsignatario = m_nIdConsignatario;
				if (m_typDatSetTbImportadoresConsignatarios != null)
					m_cls_dba_ConnectionDB.SetTbImportadoresConsignatarios(m_typDatSetTbImportadoresConsignatarios);
				if ((this.DataAccess) && (m_typDatSetTbPes != null))
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
			}
			#endregion
		#endregion

		#region Carregamento de Dados Consignatario
			#region Banco de Dados
			protected void carregaDadosBDImportadorConsignatario()
			{
				#region Pesquisa
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario;
				dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,m_nIdConsignatario);
				if (dtrwRowTbImportadoresConsignatario != null )
				{
					if (!dtrwRowTbImportadoresConsignatario.IsstrNomeNull())
						m_strImportadorConsignatario = dtrwRowTbImportadoresConsignatario.strNome;
					else
						m_strImportadorConsignatario = "";

					if (!dtrwRowTbImportadoresConsignatario.IsmstrEnderecoNull())
						m_strEnderecoConsignatario = dtrwRowTbImportadoresConsignatario.mstrEndereco;
					else
						m_strEnderecoConsignatario = "";

					if (!dtrwRowTbImportadoresConsignatario.IsnIdPaisNull())
						m_nIdPais = dtrwRowTbImportadoresConsignatario.nIdPais;
					else
						m_nIdPais = -1;
										
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;

					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if ((dtrwRowTbPaises != null) && (!dtrwRowTbPaises.IsnmPaisNull()))
						m_strPais = dtrwRowTbPaises.nmPais;
				#endregion

					#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresConsignatario.IsstrCidadeNull())
					{
						m_strCidade = dtrwRowTbImportadoresConsignatario.strCidade;
					}
					if (!dtrwRowTbImportadoresConsignatario.IsstrEstadoNull())
					{
						m_strEstado = dtrwRowTbImportadoresConsignatario.strEstado;
					}
				}
				else
				{
					m_strImportadorConsignatario = "";
					m_strEnderecoConsignatario = "";
					m_strCidade = "";
					m_strPais = "";
					m_strEstado = "";
					m_nIdPais = -1;
				}
					#endregion
			}
			protected void carregaDadosImportadorConsignatario(ref mdlComponentesGraficos.ListView lvConsignatarios)
			{
				#region Pesquisa
				if (lvConsignatarios.SelectedItems.Count > 0)
					m_nIdConsignatario = Int32.Parse(lvConsignatarios.SelectedItems[0].Tag.ToString());
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario;
				dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,m_nIdConsignatario);
				if (dtrwRowTbImportadoresConsignatario != null )
				{
					if (!dtrwRowTbImportadoresConsignatario.IsstrNomeNull())
						m_strImportadorConsignatario = dtrwRowTbImportadoresConsignatario.strNome;
					else
						m_strImportadorConsignatario = "";

					if (!dtrwRowTbImportadoresConsignatario.IsmstrEnderecoNull())
						m_strEnderecoConsignatario = dtrwRowTbImportadoresConsignatario.mstrEndereco;
					else
						m_strEnderecoConsignatario = "";

					if (!dtrwRowTbImportadoresConsignatario.IsnIdPaisNull())
						m_nIdPais = dtrwRowTbImportadoresConsignatario.nIdPais;
					else
						m_nIdPais = -1;
									
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;

					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if ((dtrwRowTbPaises != null) && (!dtrwRowTbPaises.IsnmPaisNull()))
						m_strPais = dtrwRowTbPaises.nmPais;
				#endregion

					#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresConsignatario.IsstrCidadeNull())
					{
						m_strCidade = dtrwRowTbImportadoresConsignatario.strCidade;
					}
					if (!dtrwRowTbImportadoresConsignatario.IsstrEstadoNull())
					{
						m_strEstado = dtrwRowTbImportadoresConsignatario.strEstado;
					}
				}
				else
				{
					m_strImportadorConsignatario = "";
					m_strEnderecoConsignatario = "";
					m_strCidade = "";
					m_strPais = "";
					m_strEstado = "";
					m_nIdPais = -1;
				}
					#endregion
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceImportadorConsignatario(ref mdlComponentesGraficos.TextBox ctbNome, ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try
				{
					System.Collections.SortedList srlPaises = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					ctbNome.Text = m_strImportadorConsignatario;
					ctbEndereco.Text = m_strEnderecoConsignatario;
					ctbCidade.Text = m_strCidade;
					ctbEstado.Text = m_strEstado;
					if (srlPaises != null)
					{
						for (int nCont = 0 ; nCont < srlPaises.Count ; nCont++)
						{
							dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCont);
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
			protected void carregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try 
				{
					System.Collections.SortedList srlPaises = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					if (srlPaises != null)
					{
						for (int nCont = 0 ; nCont < srlPaises.Count ; nCont++)
						{
							dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCont);
							cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
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
		#region Salvamento de Dados Consignatário
			#region Interface
			protected void salvaDadosInterfaceImportadorConsignatario(ref mdlComponentesGraficos.TextBox ctbNome, ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try
				{
					m_strImportadorConsignatario = ctbNome.Text;
					m_strEnderecoConsignatario = ctbEndereco.Text;
					m_strCidade = ctbCidade.Text;
					m_strEstado = ctbEstado.Text;
					m_nIdPais = Int32.Parse(cbPaises.ReturnObjectSelectedItem().ToString());
					m_strPais = cbPaises.SelectedItem.ToString();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDImportadorConsignatario(bool cadastraNovo)
			{
				try
				{
					#region Pesquisa ou Criação do Registro
					bool bNaoPossuiImpCadastrado = false;
					int nIdImportadorConsignatario = 1;
					// Cria a variável para conter o registro corrente
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresConsignatarios.tbImportadoresConsignatariosRow dtrwRowTbImportadoresConsignatario;
					if (cadastraNovo == false) 
					{
						dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,m_nIdConsignatario);
						if (dtrwRowTbImportadoresConsignatario == null)
						{
							bNaoPossuiImpCadastrado = true;
							dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.NewtbImportadoresConsignatariosRow();
						}
						nIdImportadorConsignatario = m_nIdConsignatario;
					} 
					else
					{
						while (m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.FindBynIdExportadornIdImportadornIdConsignatario(m_nIdExportador,m_nIdImportador,nIdImportadorConsignatario) != null)
							nIdImportadorConsignatario++;
						dtrwRowTbImportadoresConsignatario = m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.NewtbImportadoresConsignatariosRow();
					}
					#endregion

					#region Salvando os Dados TbImportadoresEndEntrega
					dtrwRowTbImportadoresConsignatario.strNome = m_strImportadorConsignatario;
					dtrwRowTbImportadoresConsignatario.nIdConsignatario = nIdImportadorConsignatario;
					dtrwRowTbImportadoresConsignatario.nIdExportador = m_nIdExportador;
					dtrwRowTbImportadoresConsignatario.nIdImportador = m_nIdImportador;
					dtrwRowTbImportadoresConsignatario.mstrEndereco = m_strEnderecoConsignatario;
					dtrwRowTbImportadoresConsignatario.strCidade = m_strCidade;
					dtrwRowTbImportadoresConsignatario.nIdPais = m_nIdPais;
					dtrwRowTbImportadoresConsignatario.strEstado = m_strEstado;
					#endregion

					if (cadastraNovo == true || bNaoPossuiImpCadastrado == true)
						m_typDatSetTbImportadoresConsignatarios.tbImportadoresConsignatarios.AddtbImportadoresConsignatariosRow(dtrwRowTbImportadoresConsignatario);
					m_cls_dba_ConnectionDB.SetTbImportadoresConsignatarios(m_typDatSetTbImportadoresConsignatarios);
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
		public void retornaValores(out string strConsignatario, out string strEnderecoConsignatario, out string strCidade, out string strEstado, out string strPais)
		{
			strConsignatario = m_strImportadorConsignatario;			
			strEnderecoConsignatario = m_strEnderecoConsignatario;
			strCidade = m_strCidade;
			strEstado = m_strEstado;
			strPais = m_strPais;
		}
		public void retornaValores(out int nIdConsignatario, out string strConsignatario, out string strEnderecoConsignatario, out string strCidade, out string strEstado, out string strPais)
		{
			nIdConsignatario = m_nIdConsignatario;
			strConsignatario = m_strImportadorConsignatario;			
			strEnderecoConsignatario = m_strEnderecoConsignatario;
			strCidade = m_strCidade;
			strEstado = m_strEstado;
			strPais = m_strPais;
		}
		#endregion
	}
}
