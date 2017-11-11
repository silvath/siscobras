using System;

namespace mdlEnderecoEntrega
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public abstract class clsEnderecoEntregaImportador
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		private frmFEnderecoEntregaImportador m_formFEnderecoEntregaImportador = null;
		private frmFEnderecoEntregaImportadorCadEdit m_formFEnderecoEntregaImportadorCadEdit = null;
		
		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdEnderecoEntrega = -1;
		protected int m_nIdPais = -1;

		protected string m_strEnderecoEntrega = "";
		protected string m_strCidadeEntrega = "";
		protected string m_strEstadoEntrega = "";
		protected string m_strPaisEntrega = "";
		protected string m_strImportador = "";

		public bool m_bModificado = false;

		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega m_typDatSetTbImportadoresEndEntrega;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises;
		#endregion

		#region Construtores & Destrutores
		public clsEnderecoEntregaImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
            m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion
		#region InitializeEventsFormEndEntregaImportador
		private void InitializeEventsFormEndEntregaImportador()
		{
			try 
			{
				// Carrega Dados BD
				m_formFEnderecoEntregaImportador.eCallCarregaDadosBD += new frmFEnderecoEntregaImportador.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFEnderecoEntregaImportador.eCallCarregaDadosInterface += new frmFEnderecoEntregaImportador.delCallCarregaDadosInterface(carregaDadosInterface);

				// Carrega Dados Endereco Interface
				m_formFEnderecoEntregaImportador.eCallCarregaDadosEnderecoInterface += new frmFEnderecoEntregaImportador.delCallCarregaDadosEnderecoInterface(carregaDadosEnderecoInterface);

				// Carrega Dados BD Endereços
				m_formFEnderecoEntregaImportador.eCallCarregaDadosBDEnderecos += new frmFEnderecoEntregaImportador.delCallCarregaDadosBDEnderecos(carregaDadosBDEndereco);

				// Carrega Dados BD Endereços Selecionado
				m_formFEnderecoEntregaImportador.eCallCarregaDadosEnderecosSelecionado += new frmFEnderecoEntregaImportador.delCallCarregaDadosEnderecosSelecionado(carregaDadosEndereco);

				// Salva Dados Interface
				m_formFEnderecoEntregaImportador.eCallSalvaDadosInterface += new frmFEnderecoEntregaImportador.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				m_formFEnderecoEntregaImportador.eCallSalvaDadosBD += new frmFEnderecoEntregaImportador.delCallSalvaDadosBD(salvaDadosBD);

				// Editar Endereço
				m_formFEnderecoEntregaImportador.eCallEditaEndereco += new frmFEnderecoEntregaImportador.delCallEditaEndereco(editaEndereco);

				// Cadastra Importador
				m_formFEnderecoEntregaImportador.eCallCadastraEndereco += new frmFEnderecoEntregaImportador.delCallCadastraEndereco(cadastraEndereco);

				// Remove Endereço
				m_formFEnderecoEntregaImportador.eCallRemoveEndereco += new frmFEnderecoEntregaImportador.delCallRemoveEndereco(removeEndereco);
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
		/// Método para mostrar o frame que lista os endereços de entrega
		/// </summary>
		public void ShowDialog()
		{
			try
			{
				m_formFEnderecoEntregaImportador = new frmFEnderecoEntregaImportador(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				InitializeEventsFormEndEntregaImportador();
				m_formFEnderecoEntregaImportador.ShowDialog();
				//m_bModificado = m_formFEnderecoEntregaImportador.m_bModificado;
				m_formFEnderecoEntregaImportador = null;
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region InitializeEventsFormEnderecoEntregaImportadorCadEdit
		private void InitializeEventsFormEndEntregaImportadorCadEdit()
		{
			// Carrega BD
			m_formFEnderecoEntregaImportadorCadEdit.eCallCarregaDadosBD += new frmFEnderecoEntregaImportadorCadEdit.delCallCarregaDadosBD(carregaBDEndEntrega);

			// Carrega Dados Interface
			m_formFEnderecoEntregaImportadorCadEdit.eCallCarregaDadosInterface += new frmFEnderecoEntregaImportadorCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceEndereco);

			// Carrega Dados Interface Paises
			m_formFEnderecoEntregaImportadorCadEdit.eCallCarregaDadosInterfacePaises += new frmFEnderecoEntregaImportadorCadEdit.delCallCarregaDadosInterfacePaises(carregaDadosInterfacePaises);

			// Salva Dados Interface
			m_formFEnderecoEntregaImportadorCadEdit.eCallSalvaDadosInterface += new frmFEnderecoEntregaImportadorCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceEndereco);

			// Salva Dados BD
			m_formFEnderecoEntregaImportadorCadEdit.eCallSalvaDadosBD += new frmFEnderecoEntregaImportadorCadEdit.delCallSalvaDadosBD(salvaDadosBDEndereco);
		}
		#endregion

		#region Show Dialog Cadastro e Edição de Endereços de Entrega
		public void ShowDialogCadEdit()
		{
			try
			{
				m_formFEnderecoEntregaImportadorCadEdit = new frmFEnderecoEntregaImportadorCadEdit(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref m_formFEnderecoEntregaImportador);
				InitializeEventsFormEndEntregaImportadorCadEdit();
				m_formFEnderecoEntregaImportadorCadEdit.ShowDialog();
				m_bModificado = m_formFEnderecoEntregaImportadorCadEdit.m_bModificado;
				m_formFEnderecoEntregaImportadorCadEdit.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Edita Endereço
		protected void editaEndereco()
		{
			try
			{
				m_formFEnderecoEntregaImportadorCadEdit = new frmFEnderecoEntregaImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFEnderecoEntregaImportador);
				InitializeEventsFormEndEntregaImportadorCadEdit();
				m_formFEnderecoEntregaImportadorCadEdit.setTextoGroupBox("Edição");
				m_formFEnderecoEntregaImportadorCadEdit.ShowDialog();
				m_formFEnderecoEntregaImportadorCadEdit = null;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Endereço
		protected void cadastraEndereco()
		{
			try
			{
				m_formFEnderecoEntregaImportadorCadEdit = new frmFEnderecoEntregaImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFEnderecoEntregaImportador,true);
				InitializeEventsFormEndEntregaImportadorCadEdit();
				m_formFEnderecoEntregaImportadorCadEdit.setTextoGroupBox("Cadastro");
				m_formFEnderecoEntregaImportadorCadEdit.ShowDialog();
				m_formFEnderecoEntregaImportadorCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Endereco
		protected void removeEndereco(ref mdlComponentesGraficos.ListView lvEnderecos)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
			int nIdEndEntrega = 0;
			if (lvEnderecos.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Endereços",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEnderecoEntrega_clsEnderecoEntregaImportador_ApagarEnderecos).Replace("TAG",lvEnderecos.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvEnderecos.SelectedItems.Count.ToString() + " endereço(s)?","Endereços",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvEnderecos.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdEndEntrega = Int32.Parse(lvEnderecos.SelectedItems[0].Tag.ToString());
					dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,nIdEndEntrega);
					dtrwRowTbImportadoresEndEntrega.Delete();
					lvEnderecos.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strCidadeEntrega = "";
					m_strEnderecoEntrega = "";
					m_strEstadoEntrega = "";
					m_nIdPais = -1;
					m_strPaisEntrega = "";					
				}
			}
		}
		#endregion

		#region Carregamento de Dados
			#region Ordenando
			private System.Collections.SortedList retornaEnderecosOrdenados()
			{
				System.Collections.SortedList srlEnderecos = new System.Collections.SortedList();
				try
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega in m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.Rows)
					{
						if (dtrwRowTbImportadoresEndEntrega.RowState != System.Data.DataRowState.Deleted)
							if (!srlEnderecos.ContainsKey(dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli + dtrwRowTbImportadoresEndEntrega.idEndEntrega.ToString()))
								srlEnderecos.Add(dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli + dtrwRowTbImportadoresEndEntrega.idEndEntrega.ToString(), dtrwRowTbImportadoresEndEntrega);
					}
				}
				catch (Exception err)
				{
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
				return srlEnderecos;
			}
			#endregion
			#region Banco de Dados
			protected virtual void carregaTypDatSet()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				arlOrdenacaoCampo.Add("nmPais");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbImportadoresEndEntrega = m_cls_dba_ConnectionDB.GetTbImportadoresEndEntrega(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			}
			protected void carregaDadosBD()
			{
				try 
				{
					carregaBDEspecificos();
					carregaBDImportadores();
					//carregaBDEndEntrega();
					carregaDadosBDEndereco();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			private void carregaBDImportadores()
			{
				if (m_typDatSetTbImportadores != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowImportadores;
					dtrwRowImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
					if (dtrwRowImportadores != null)
                        m_strImportador = dtrwRowImportadores.nmCli;
				}
			}
			private void carregaBDEndEntrega()
			{
				if (m_nIdEnderecoEntrega != -1)
				{
					if (m_typDatSetTbImportadoresEndEntrega != null)
					{
						mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
						dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,m_nIdEnderecoEntrega);
						if (dtrwRowTbImportadoresEndEntrega != null)
                            m_strEnderecoEntrega = dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli;
					}
				}
			}
			protected abstract void carregaBDEspecificos();
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvEnderecos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Label lNomeImportador)
			{
				try
				{
					System.Collections.SortedList srlEnderecos = retornaEnderecosOrdenados();
					// List View Item
					System.Windows.Forms.ListViewItem lvItemEndereco;
					// Limpa os Items da List View
					lvEnderecos.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < srlEnderecos.Count ; nCont++)
					{
						dtrwRowTbImportadoresEndEntrega = (mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow)srlEnderecos.GetByIndex(nCont);
						if (dtrwRowTbImportadoresEndEntrega.RowState != System.Data.DataRowState.Deleted)
						{
							lvItemEndereco = lvEnderecos.Items.Add(dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli);
							lvItemEndereco.Tag = dtrwRowTbImportadoresEndEntrega.idEndEntrega;
							if ((int)lvItemEndereco.Tag == m_nIdEnderecoEntrega)
							{
								lvItemEndereco.Selected = true;
							}
						}
					}
					if (lvEnderecos.Items.Count == 0)
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
			protected void carregaDadosEnderecoInterface(ref mdlComponentesGraficos.ListView lvDadosEndereco)
			{
				try
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemDadosEndereco;
					// Limpa os Items da List View
					lvDadosEndereco.Items.Clear();

					#region Adicionando Items à ListView
					#region Endereço
//					lvItemDadosEndereco = lvDadosEndereco.Items.Add("Endereço: ");
//					lvItemDadosEndereco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosEndereco.UseItemStyleForSubItems = false;
//					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = lvDadosEndereco.Items.Add(m_strEnderecoEntrega);
					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = null;
					#endregion
					#region Cidade
//					lvItemDadosEndereco = lvDadosEndereco.Items.Add("Cidade: ");
//					lvItemDadosEndereco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosEndereco.UseItemStyleForSubItems = false;
//					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = lvDadosEndereco.Items.Add(m_strCidadeEntrega);
					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = null;
					#endregion
					#region Estado
//					lvItemDadosEndereco = lvDadosEndereco.Items.Add("Estado: ");
//					lvItemDadosEndereco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosEndereco.UseItemStyleForSubItems = false;
//					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = lvDadosEndereco.Items.Add(m_strEstadoEntrega);
					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = null;
					#endregion
					#region País
//					lvItemDadosEndereco = lvDadosEndereco.Items.Add("País: ");
//					lvItemDadosEndereco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosEndereco.UseItemStyleForSubItems = false;
//					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = lvDadosEndereco.Items.Add(m_strPaisEntrega);
					lvItemDadosEndereco.Font = new System.Drawing.Font(lvItemDadosEndereco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosEndereco = null;
					#endregion
					#endregion
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected abstract void carregaDadosInterfaceEspecifico();
			#endregion
		#endregion
		#region Salvamento de Dados
			#region Interface
			protected void salvaDadosInterface(ref mdlComponentesGraficos.ListView lvEnderecos)
			{
				if (lvEnderecos.Items.Count == 0 || lvEnderecos.SelectedItems.Count == 0)
				{
					m_nIdEnderecoEntrega = -1;
				} 
				else if (lvEnderecos.Items.Count > 0 && lvEnderecos.SelectedItems.Count == 1)
				{
					m_nIdEnderecoEntrega = Int32.Parse(lvEnderecos.SelectedItems[0].Tag.ToString());
				} 
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Endereço de Entrega",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlEnderecoEntrega_clsEnderecoEntregaImportador_MaisDeUmEnderecoSelecionado));
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de um endereço!\nO endereço selecionado será: " + lvEnderecos.SelectedItems[0].Text,"Endereço de Entrega");
					m_nIdEnderecoEntrega = Int32.Parse(lvEnderecos.SelectedItems[0].Tag.ToString());
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				if (m_typDatSetTbImportadoresEndEntrega != null)
					m_cls_dba_ConnectionDB.SetTbImportadoresEndEntrega(m_typDatSetTbImportadoresEndEntrega);
				if (m_typDatSetTbImportadores != null)
					m_cls_dba_ConnectionDB.SetTbImportadores(m_typDatSetTbImportadores);
			}
			protected abstract void salvaDadosBDEspecifico();
			#endregion
		#endregion

		#region Carregamento de Dados Endereço
			#region Banco de Dados
			protected void carregaDadosBDEndereco()
			{
				#region Pesquisa
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
				dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,m_nIdEnderecoEntrega);
				if (dtrwRowTbImportadoresEndEntrega != null )
				{
					m_strEnderecoEntrega = dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli;

					m_nIdPais = dtrwRowTbImportadoresEndEntrega.idPaisEntrCli;
									
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;

					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if (dtrwRowTbPaises != null)
						m_strPaisEntrega = dtrwRowTbPaises.nmPais;
				#endregion

				#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresEndEntrega.IsmstrCidadeEntrCliNull())
					{
						m_strCidadeEntrega = dtrwRowTbImportadoresEndEntrega.mstrCidadeEntrCli;
					}
					if (!dtrwRowTbImportadoresEndEntrega.IsmstrEstadoEntrCliNull())
					{
						m_strEstadoEntrega = dtrwRowTbImportadoresEndEntrega.mstrEstadoEntrCli;
					}
				}
				else
				{
					m_strEnderecoEntrega = "";
					m_strCidadeEntrega = "";
					m_strPaisEntrega = "";
					m_strEstadoEntrega = "";
					m_nIdPais = -1;
				}
					#endregion
			}
			protected void carregaDadosEndereco(ref mdlComponentesGraficos.ListView lvListaDeEnderecos)
			{
				#region Pesquisa
				if (lvListaDeEnderecos.SelectedItems.Count > 0)
					m_nIdEnderecoEntrega = Int32.Parse(lvListaDeEnderecos.SelectedItems[0].Tag.ToString());
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
				dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,m_nIdEnderecoEntrega);
				if (dtrwRowTbImportadoresEndEntrega != null )
				{
					m_strEnderecoEntrega = dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli;

					m_nIdPais = dtrwRowTbImportadoresEndEntrega.idPaisEntrCli;
								
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;

					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if (dtrwRowTbPaises != null)
						m_strPaisEntrega = dtrwRowTbPaises.nmPais;
					#endregion

					#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresEndEntrega.IsmstrCidadeEntrCliNull())
					{
						m_strCidadeEntrega = dtrwRowTbImportadoresEndEntrega.mstrCidadeEntrCli;
					}
					if (!dtrwRowTbImportadoresEndEntrega.IsmstrEstadoEntrCliNull())
					{
						m_strEstadoEntrega = dtrwRowTbImportadoresEndEntrega.mstrEstadoEntrCli;
					}
				}
				else
				{
					m_strEnderecoEntrega = "";
					m_strCidadeEntrega = "";
					m_strPaisEntrega = "";
					m_strEstadoEntrega = "";
					m_nIdPais = -1;
				}
				#endregion
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceEndereco(ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try
				{
					System.Collections.SortedList srlPaises = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					ctbEndereco.Text = m_strEnderecoEntrega;
					ctbCidade.Text = m_strCidadeEntrega;
					ctbEstado.Text = m_strEstadoEntrega;
					if (srlPaises != null)
					{
						for (int nCont = 0 ; nCont < srlPaises.Count ; nCont++)
						{
							dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCont);
							cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
							if (dtrwRowTbPaises.idPais == m_nIdPais)
							{
								cbPaises.SelectedIndex = nCont;
								m_strPaisEntrega = dtrwRowTbPaises.nmPais;
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
		#region Salvamento de Dados Endereço
			#region Interface
			protected void salvaDadosInterfaceEndereco(ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises)
			{
				try
				{
					m_strEnderecoEntrega = ctbEndereco.Text;
					m_strCidadeEntrega = ctbCidade.Text;
					m_strEstadoEntrega = ctbEstado.Text;
					m_nIdPais = Int32.Parse(cbPaises.ReturnObjectSelectedItem().ToString());
					m_strPaisEntrega = cbPaises.SelectedItem.ToString();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDEndereco(bool cadastraNovo)
			{
				try
				{
					#region Pesquisa ou Criação do Registro
					bool bNaoPossuiEndCadastrado = false;
					int nIdImportadorEndEntrega = 1;
					// Cria a variável para conter o registro corrente
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
					if (cadastraNovo == false) 
					{
						dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,m_nIdEnderecoEntrega);
						if (dtrwRowTbImportadoresEndEntrega == null)
						{
							bNaoPossuiEndCadastrado = true;
							dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.NewtbImportadoresEndEntregaRow();
						}
						nIdImportadorEndEntrega = m_nIdEnderecoEntrega;
					} 
					else
					{
						while (m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,nIdImportadorEndEntrega) != null)
							nIdImportadorEndEntrega++;
						dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.NewtbImportadoresEndEntregaRow();
					}
					#endregion

					#region Salvando os Dados TbImportadoresEndEntrega
					dtrwRowTbImportadoresEndEntrega.idEndEntrega = nIdImportadorEndEntrega;
					dtrwRowTbImportadoresEndEntrega.idExportador = m_nIdExportador;
					dtrwRowTbImportadoresEndEntrega.idImportador = m_nIdImportador;
					dtrwRowTbImportadoresEndEntrega.mstrEndEntrCli = m_strEnderecoEntrega;
					dtrwRowTbImportadoresEndEntrega.mstrCidadeEntrCli = m_strCidadeEntrega;
					dtrwRowTbImportadoresEndEntrega.idPaisEntrCli = m_nIdPais;
					dtrwRowTbImportadoresEndEntrega.mstrEstadoEntrCli = m_strEstadoEntrega;
					#endregion

					if (cadastraNovo == true || bNaoPossuiEndCadastrado == true)
						m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.AddtbImportadoresEndEntregaRow(dtrwRowTbImportadoresEndEntrega);
					//m_cls_dba_ConnectionDB.SetTbImportadoresEndEntrega(m_typDatSetTbImportadoresEndEntrega);
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
		public void retornaValores(out string strEndereco)
		{
			strEndereco = m_strEnderecoEntrega;
		}
		public void retornaValores(out string strEndereco, out string strCidade, out string strEstado, out string strPais)
		{
			strEndereco = m_strEnderecoEntrega;
			strCidade = m_strCidadeEntrega;
			strEstado = m_strEstadoEntrega;
			strPais = m_strPaisEntrega;
		}
		public void retornaValores(out string strEndereco, out string strCidade, out string strEstado, out string strPais, out int nIdPais, out int nIdEndEntrega)
		{
			strEndereco = m_strEnderecoEntrega;
			strCidade = m_strCidadeEntrega;
			strEstado = m_strEstadoEntrega;
			strPais = m_strPaisEntrega;
			nIdPais = m_nIdPais;
			nIdEndEntrega = m_nIdEnderecoEntrega;
		}
		#endregion
	}
}
