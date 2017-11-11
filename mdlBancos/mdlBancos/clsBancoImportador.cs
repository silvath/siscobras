using System;

namespace mdlBancos
{
	/// <summary>
	/// Summary description for clsBancoImportador.
	/// </summary>
	public abstract class clsBancoImportador
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		private bool m_bMostrarBaloes = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected int m_nIdBanco = -1;
		protected int m_nIdPais = -1;
		protected string m_strImportador = "";
		protected string m_strBanco = "";
		protected string m_strEndereco = "";
		protected string m_strComplemento = "";
		protected string m_strCidade = "";
		protected string m_strEstado = "";
		protected string m_strPais = "";
		protected string m_strObs = "";

		public bool m_bModificado = false;

		protected bool m_bDocumento = false;

		private frmFBancoImportador m_formFBancoImportador = null;
		private frmFBancoImportadorCadEdit m_formFBancoImportadorCadEdit = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos m_typDatSetTbImportadoresBancos;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises;
		#endregion

		#region Construtores & Destrutores
		public clsBancoImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region InitializeEventsFormBancoImportador
		private void InitializeEventsFormBancoImportador()
		{
			try 
			{
				// Carrega Dados BD
				m_formFBancoImportador.eCallCarregaDadosBD += new frmFBancoImportador.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFBancoImportador.eCallCarregaDadosInterface += new frmFBancoImportador.delCallCarregaDadosInterface(carregaDadosInterface);

				// Carrega Dados Banco Interface
				m_formFBancoImportador.eCallCarregaDadosBancoInterface += new frmFBancoImportador.delCallCarregaDadosBancoInterface(carregaDadosBancoInterface);

				// Carrega Dados BD Banco
				m_formFBancoImportador.eCallCarregaDadosBDBancos += new frmFBancoImportador.delCallCarregaDadosBDBancos(carregaDadosBD);

				// Carrega Dados BD Bancos Selecionado
				m_formFBancoImportador.eCallCarregaDadosBancoSelecionado += new frmFBancoImportador.delCallCarregaDadosBancoSelecionado(carregaDadosBanco);

				// Anula Seleção
				m_formFBancoImportador.eCallAnulaSelecao += new frmFBancoImportador.delCallAnulaSelecao(anulaSelecao);

				// Habilitar Botão Anular Selecao
				m_formFBancoImportador.eCallHabilitaBotaoAnularSelecao += new frmFBancoImportador.delCallHabilitaBotaoAnularSelecao(habilitaBotoesDocumentos);

				// Salva Dados Interface
				m_formFBancoImportador.eCallSalvaDadosInterface += new frmFBancoImportador.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				m_formFBancoImportador.eCallSalvaDadosBD += new frmFBancoImportador.delCallSalvaDadosBD(salvaDadosBD);

				// Editar Banco
				m_formFBancoImportador.eCallEditaBanco += new frmFBancoImportador.delCallEditaBanco(editaBanco);

				// Cadastra Banco
				m_formFBancoImportador.eCallCadastraBanco += new frmFBancoImportador.delCallCadastraBanco(cadastraBanco);

				// Remove Banco
				m_formFBancoImportador.eCallRemoveBanco += new frmFBancoImportador.delCallRemoveBanco(removeBanco);
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
					m_formFBancoImportador = new frmFBancoImportador(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormBancoImportador();
					m_formFBancoImportador.ShowDialog();
					m_bModificado = m_formFBancoImportador.m_bModificado;
					m_formFBancoImportador.Dispose();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void InitializeEventsFormBancoImportadorCadEdit()
			{
				// Carrega BD
				m_formFBancoImportadorCadEdit.eCallCarregaDadosBD += new frmFBancoImportadorCadEdit.delCallCarregaDadosBD(carregaDadosBDBanco);

				// Carrega Dados Interface
				m_formFBancoImportadorCadEdit.eCallCarregaDadosInterface += new frmFBancoImportadorCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceBanco);

				// Carrega Dados Interface Paises
				m_formFBancoImportadorCadEdit.eCallCarregaDadosInterfacePaises += new frmFBancoImportadorCadEdit.delCallCarregaDadosInterfacePaises(carregaDadosInterfacePaises);

				// Salva Dados Interface
				m_formFBancoImportadorCadEdit.eCallSalvaDadosInterface += new frmFBancoImportadorCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceBanco);

				// Salva Dados BD
				m_formFBancoImportadorCadEdit.eCallSalvaDadosBD += new frmFBancoImportadorCadEdit.delCallSalvaDadosBD(salvaDadosBDBanco);
			}
		#endregion

		#region Show Dialog Cadastro e Edição do Banco do Importador
		public void ShowDialogCadEdit()
		{
			try
			{
				m_formFBancoImportadorCadEdit = new frmFBancoImportadorCadEdit(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel,ref m_formFBancoImportador);
				InitializeEventsFormBancoImportadorCadEdit();
				m_formFBancoImportadorCadEdit.ShowDialog();
				m_bModificado = m_formFBancoImportadorCadEdit.m_bModificado;
				m_formFBancoImportadorCadEdit.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Edita Banco
		protected void editaBanco()
		{
			try
			{
				m_formFBancoImportadorCadEdit = new frmFBancoImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFBancoImportador);
				InitializeEventsFormBancoImportadorCadEdit();
				m_formFBancoImportadorCadEdit.setTextoGroupBox("Edição");
				m_formFBancoImportadorCadEdit.ShowDialog();
				m_formFBancoImportadorCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Banco
		protected void cadastraBanco()
		{
			try
			{
				m_formFBancoImportadorCadEdit = new frmFBancoImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFBancoImportador,true);
				InitializeEventsFormBancoImportadorCadEdit();
				m_formFBancoImportadorCadEdit.setTextoGroupBox("Cadastro");
				m_formFBancoImportadorCadEdit.ShowDialog();
				m_formFBancoImportadorCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Banco
		protected void removeBanco(ref mdlComponentesGraficos.ListView lvBancos)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow dtrwRowTbImportadoresBancos;
			int nIdBanco = 0;
			if (lvBancos.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Bancos",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoImportador_ApagarBancos).Replace("TAG",lvBancos.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvBancos.SelectedItems.Count.ToString() + " banco(s)?","Bancos",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvBancos.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
					dtrwRowTbImportadoresBancos = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.FindBynIdExportadornIdImportadornIdBanco(m_nIdExportador,m_nIdImportador,nIdBanco);
					dtrwRowTbImportadoresBancos.Delete();
					lvBancos.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strBanco = "";
					m_strEndereco = "";
					m_strComplemento = "";
					m_strCidade = "";					
					m_strEstado = "";
					m_nIdPais = -1;
					m_strPais = "";					
					m_strObs = "";

				}
			}
		}
		#endregion

		#region Carregamento de Dados
			#region Banco de Dados
			protected virtual void carregaTypDatSet()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("nIdImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				m_typDatSetTbImportadoresBancos = m_cls_dba_ConnectionDB.GetTbImportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlOrdenacaoCampo.Add("nmPais");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			protected void carregaDadosBD()
			{
				try 
				{
					carregaBDEspecificos();
					carregaBDImportadores();
					carregaDadosBDBanco();
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
			protected abstract void carregaBDEspecificos();
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo, ref System.Windows.Forms.Label lNomeImportador)
			{
				try
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemBanco;
					// Limpa os Items da List View
					lvBancos.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow dtrwRowTbImportadoresBancos;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < m_typDatSetTbImportadoresBancos.tbImportadoresBancos.Rows.Count ; nCont++)
					{
						dtrwRowTbImportadoresBancos = (mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow)m_typDatSetTbImportadoresBancos.tbImportadoresBancos.Rows[nCont];
						if (dtrwRowTbImportadoresBancos.RowState != System.Data.DataRowState.Deleted)
						{
							lvItemBanco = lvBancos.Items.Add(dtrwRowTbImportadoresBancos.strNome);
							lvItemBanco.Tag = dtrwRowTbImportadoresBancos.nIdBanco;
							if ((int)lvItemBanco.Tag == m_nIdBanco)
							{
								lvItemBanco.Selected = true;
							}
						}
					}
					if (lvBancos.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
						if (m_bMostrarBaloes)
						{
							m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
							m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlBancos_clsBancoImportador_NovoBancoImportador.ToString());
							m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
							m_mgblBalaoToolTip.CloseOnMouseClick = true;
							m_mgblBalaoToolTip.CloseOnDeactivate = true;
							m_mgblBalaoToolTip.CloseOnKeyPress = true;
							m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)btNovo);
						}
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
			protected void carregaDadosBancoInterface(ref mdlComponentesGraficos.ListView lvDadosBanco)
			{
				try
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemDadosBanco;
					// Limpa os Items da List View
					lvDadosBanco.Items.Clear();
					string ObsSemNovaLinha = m_strObs.Replace(System.Environment.NewLine," ");

					#region Adicionando Items à ListView
					#region Banco
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Banco: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strBanco);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region Endereço
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Endereco: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strEndereco);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region Complemento
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Compl.: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strComplemento);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region Cidade
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Cidade: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strCidade);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region Estado
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Estado: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strEstado);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region País
//					lvItemDadosBanco = lvDadosBanco.Items.Add("País: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(m_strPais);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
					#endregion
					#region Observações
//					lvItemDadosBanco = lvDadosBanco.Items.Add("Obs.: ");
//					lvItemDadosBanco.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosBanco.UseItemStyleForSubItems = false;
//					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = lvDadosBanco.Items.Add(ObsSemNovaLinha);
					lvItemDadosBanco.Font = new System.Drawing.Font(lvItemDadosBanco.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosBanco = null;
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
			protected void habilitaBotoesDocumentos(ref System.Windows.Forms.Button btAnular)
			{
				btAnular.Visible = m_bDocumento;
			}
			#endregion
		#endregion
		#region Salvamento de Dados
			#region Interface
			protected void salvaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos)
			{
				if (lvBancos.Items.Count == 0 || lvBancos.SelectedItems.Count == 0)
				{
					m_nIdBanco = -1;
					m_strBanco = "";
				} 
				else if (lvBancos.Items.Count > 0 && lvBancos.SelectedItems.Count == 1)
				{
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
				} 
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Bancos do Importador",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoImportador_MaisDeUmBancoSelecionado).Replace("TAG",lvBancos.SelectedItems[0].Text), System.Windows.Forms.MessageBoxButtons.YesNo);
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de um banco!\nO banco selecionado será: " + lvBancos.SelectedItems[0].Text,"Bancos do Importador");
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				if (m_typDatSetTbImportadoresBancos != null)
					m_cls_dba_ConnectionDB.SetTbImportadoresBancos(m_typDatSetTbImportadoresBancos);
				if (m_typDatSetTbImportadores != null)
					m_cls_dba_ConnectionDB.SetTbImportadores(m_typDatSetTbImportadores);
			}
			protected abstract void salvaDadosBDEspecifico();
			#endregion
		#endregion

		#region Carregamento de Dados Bancos
			#region Banco de Dados
			protected void carregaDadosBDBanco()
			{
				#region Pesquisa
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow dtrwRowTbImportadoresBancos;
				dtrwRowTbImportadoresBancos = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.FindBynIdExportadornIdImportadornIdBanco(m_nIdExportador,m_nIdImportador,m_nIdBanco);
				if (dtrwRowTbImportadoresBancos != null )
				{
					m_strBanco = dtrwRowTbImportadoresBancos.strNome;
	
					m_nIdPais = dtrwRowTbImportadoresBancos.nIdPais;
										
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
	
					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if (dtrwRowTbPaises != null)
						m_strPais = dtrwRowTbPaises.nmPais;
				#endregion

				#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresBancos.IsmstrEnderecoNull())
						m_strEndereco = dtrwRowTbImportadoresBancos.mstrEndereco;
					if (!dtrwRowTbImportadoresBancos.IsmstrComplementoEnderecoNull())
						m_strComplemento = dtrwRowTbImportadoresBancos.mstrComplementoEndereco;
					if (!dtrwRowTbImportadoresBancos.IsmstrCidadeNull())
						m_strCidade = dtrwRowTbImportadoresBancos.mstrCidade;
					if (!dtrwRowTbImportadoresBancos.IsmstrEstadoNull())
						m_strEstado = dtrwRowTbImportadoresBancos.mstrEstado;
					if (!dtrwRowTbImportadoresBancos.IsmstrObservacoesNull())
						m_strObs = dtrwRowTbImportadoresBancos.mstrObservacoes;
				}
				else
				{
					m_strBanco = "";
					m_strEndereco = "";
					m_strComplemento = "";
					m_strCidade = "";
					m_strEstado = "";
					m_strPais = "";
					m_nIdPais = -1;
					m_strObs = "";
				}
				#endregion
			}
			protected void carregaDadosBanco(ref mdlComponentesGraficos.ListView lvBancos)
			{
				#region Pesquisa
				if (lvBancos.SelectedItems.Count > 0)
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
				else
					m_nIdBanco = -1;
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow dtrwRowTbImportadoresBanco;
				dtrwRowTbImportadoresBanco = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.FindBynIdExportadornIdImportadornIdBanco(m_nIdExportador,m_nIdImportador,m_nIdBanco);
				if (dtrwRowTbImportadoresBanco != null )
				{
					m_strBanco = dtrwRowTbImportadoresBanco.strNome;
	
					m_nIdPais = dtrwRowTbImportadoresBanco.nIdPais;
									
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
	
					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if (dtrwRowTbPaises != null)
						m_strPais = dtrwRowTbPaises.nmPais;
				#endregion

				#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadoresBanco.IsmstrEnderecoNull())
						m_strEndereco = dtrwRowTbImportadoresBanco.mstrEndereco;
					if (!dtrwRowTbImportadoresBanco.IsmstrComplementoEnderecoNull())
						m_strComplemento = dtrwRowTbImportadoresBanco.mstrComplementoEndereco;
					if (!dtrwRowTbImportadoresBanco.IsmstrCidadeNull())
						m_strCidade = dtrwRowTbImportadoresBanco.mstrCidade;
					if (!dtrwRowTbImportadoresBanco.IsmstrEstadoNull())
						m_strEstado = dtrwRowTbImportadoresBanco.mstrEstado;
					if (!dtrwRowTbImportadoresBanco.IsmstrObservacoesNull())
						m_strObs = dtrwRowTbImportadoresBanco.mstrObservacoes;
				}
				else
				{
					m_strBanco = "";
					m_strEndereco = "";
					m_strComplemento = "";
					m_strCidade = "";
					m_strEstado = "";
					m_strPais = "";
					m_nIdPais = -1;
					m_strObs = "";
				}
				#endregion
			}
			protected void anulaSelecao(ref mdlComponentesGraficos.ListView lvBancos)
			{
				try
				{
					System.Collections.ArrayList arlItemsSelecionados = new System.Collections.ArrayList();
					foreach(System.Windows.Forms.ListViewItem lvItemBanco in lvBancos.SelectedItems)
					{
						arlItemsSelecionados.Add(lvItemBanco);
					}
					foreach(System.Windows.Forms.ListViewItem lvItemBanco in arlItemsSelecionados)
					{
						lvItemBanco.Selected = false;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceBanco(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbComplemento,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref System.Windows.Forms.TextBox ctbObs)
			{
				try
				{
					System.Collections.SortedList srlPaises = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					ctbNome.Text = m_strBanco;
					ctbEndereco.Text = m_strEndereco;
					ctbComplemento.Text = m_strComplemento;
					ctbCidade.Text = m_strCidade;
					ctbEstado.Text = m_strEstado;
					if (srlPaises != null)
					{
						for (int nCount = 0 ; nCount < srlPaises.Count ; nCount++)
						{
							dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCount);
							cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
							if (dtrwRowTbPaises.idPais == m_nIdPais)
							{
								cbPaises.SelectedIndex = nCount;
								m_strPais = dtrwRowTbPaises.nmPais;
							}
						}
					}
					ctbObs.Text = m_strObs;
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
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
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
		#region Salvamento de Dados Bancos
			#region Interface
			protected void salvaDadosInterfaceBanco(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbComplemento,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref System.Windows.Forms.TextBox ctbObs)
			{
				try
				{
					m_strBanco = ctbNome.Text;
					m_strEndereco = ctbEndereco.Text;
					m_strComplemento = ctbComplemento.Text;
					m_strCidade = ctbCidade.Text;
					m_strEstado = ctbEstado.Text;
					m_nIdPais = Int32.Parse(cbPaises.ReturnObjectSelectedItem().ToString());
					m_strPais = cbPaises.SelectedItem.ToString();
					m_strObs = ctbObs.Text;
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDBanco(bool cadastraNovo)
			{
				try
				{
					#region Pesquisa ou Criação do Registro
					bool bNaoPossuiBancoCadastrado = false;
					int nIdImportadorBanco = 1;
					// Cria a variável para conter o registro corrente
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresBancos.tbImportadoresBancosRow dtrwRowTbImportadoresBanco;
					if (cadastraNovo == false) 
					{
						dtrwRowTbImportadoresBanco = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.FindBynIdExportadornIdImportadornIdBanco(m_nIdExportador,m_nIdImportador,m_nIdBanco);
						if (dtrwRowTbImportadoresBanco == null)
						{
							bNaoPossuiBancoCadastrado = true;
							dtrwRowTbImportadoresBanco = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.NewtbImportadoresBancosRow();
						}
						nIdImportadorBanco = m_nIdBanco;
					} 
					else
					{
						while (m_typDatSetTbImportadoresBancos.tbImportadoresBancos.FindBynIdExportadornIdImportadornIdBanco(m_nIdExportador,m_nIdImportador,nIdImportadorBanco) != null)
							nIdImportadorBanco++;
						dtrwRowTbImportadoresBanco = m_typDatSetTbImportadoresBancos.tbImportadoresBancos.NewtbImportadoresBancosRow();
					}
					#endregion

					#region Salvando os Dados TbImportadoresEndEntrega
					dtrwRowTbImportadoresBanco.nIdExportador = m_nIdExportador;
					dtrwRowTbImportadoresBanco.nIdImportador = m_nIdImportador;
					dtrwRowTbImportadoresBanco.nIdBanco = nIdImportadorBanco;
					dtrwRowTbImportadoresBanco.strNome = m_strBanco;
					dtrwRowTbImportadoresBanco.mstrEndereco = m_strEndereco;
					dtrwRowTbImportadoresBanco.mstrComplementoEndereco = m_strComplemento;
					dtrwRowTbImportadoresBanco.mstrCidade = m_strCidade;
					dtrwRowTbImportadoresBanco.mstrEstado = m_strEstado;
					dtrwRowTbImportadoresBanco.mstrObservacoes = m_strObs;
					dtrwRowTbImportadoresBanco.nIdPais = m_nIdPais;
					#endregion

					m_nIdBanco = nIdImportadorBanco;
					if (cadastraNovo == true || bNaoPossuiBancoCadastrado == true)
						m_typDatSetTbImportadoresBancos.tbImportadoresBancos.AddtbImportadoresBancosRow(dtrwRowTbImportadoresBanco);
					m_cls_dba_ConnectionDB.SetTbImportadoresBancos(m_typDatSetTbImportadoresBancos);
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
		public void retornaValores(out string strBanco)
		{
			strBanco = m_strBanco;
		}
		public void retornaValores(out string strBanco, out string strEndereco, out string mstrCidade, out string strEstado, out string strPais, out string strSwift)
		{
			strBanco = m_strBanco;
			strEndereco = m_strEndereco;
			mstrCidade = m_strCidade;
			strEstado = m_strEstado;
			strPais = m_strPais;
			strSwift = m_strObs;
		}
		#endregion
	}
}
