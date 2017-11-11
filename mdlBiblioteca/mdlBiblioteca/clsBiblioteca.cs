using System;

namespace mdlBiblioteca
{
	#region Enums
		internal enum View
		{
			Notloaded = 1,
			Details = 2,
			LargeIcons = 3,
			SmallIcons = 4,
			List = 5
		}
	#endregion
	/// <summary>
	/// Summary description for clsBiblioteca.
	/// </summary>
	public class clsBiblioteca
	{
		#region Delegate
		public delegate void delCallPESelecionado(string strIdPE);
		public delegate void delCallPeCriado(string strIdPE);
		#endregion
		#region Events
		public event delCallPESelecionado eCallPESelecionado;
		public event delCallPeCriado eCallPeCriado;
		#endregion
		#region Events Methods
		protected virtual void OnCallPESelecionado()
		{
			if (eCallPESelecionado != null)
			{
				if (m_mgblBalaoToolTip != null)
				{
					m_mgblBalaoToolTip.Close();
					m_mgblBalaoToolTip.Hide();
				}
				m_mgblBalaoToolTip = null;
				eCallPESelecionado(m_strIdPE);
			}
		}

		protected virtual void OnCallPeCriado()
		{
			if (eCallPeCriado != null)
			{
				if (m_mgblBalaoToolTip != null)
				{
					m_mgblBalaoToolTip.Close();
					m_mgblBalaoToolTip.Hide();
				}
				m_mgblBalaoToolTip = null;
				eCallPeCriado(m_strIdPE);
			}
		}
		#endregion

		#region Atributes
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = "";
		protected string m_strDirImagens = "";
		protected string m_strLinkBannerInternet = "";
		private bool m_bMostrarBaloes = true;
		private int m_nIdUsuario = -1;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		private View m_enumView = View.Notloaded;

		protected System.Windows.Forms.Form m_formParent;

		protected int m_nIndiceImagem = 0;

		private int m_nIdExportador = -1;
		private string m_strIdPE = "";
		private string m_strIdPENovo = "";
			
		public bool m_bModificado = false;
		private bool m_bEdicaoModificado = false; 

		protected string[] m_strarrFiles = null;

		private frmFBiblioteca m_formFBiblioteca = null;
		private frmFNumeroPE m_formFNumeroPE = null;
		private mdlCriacaoDocumentos.clsCriacao m_clsCriacaoDocumentos = null;

		private System.Windows.Forms.ImageList m_ilBandeiras = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
		#endregion
		#region Constructors and Destructors
		public clsBiblioteca(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,ref System.Windows.Forms.Form formParent,int nIdExportador, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_formParent = formParent;
			m_nIdExportador = nIdExportador;
			m_ilBandeiras = ilBandeiras;
			m_strDirImagens = "Imagens\\";
			m_nIdUsuario = mdlUsuarios.clsUsuario.New(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel).IdUsuario;
			carregaTypDatSet();
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region Show
		public void Show()
		{
			try
			{
				m_formFBiblioteca = new frmFBiblioteca(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormBiblioteca();
				m_formFBiblioteca.MdiParent = m_formParent;
				m_formFBiblioteca.Show();
				m_formFBiblioteca.BringToFront();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private void InitializeEventsFormBiblioteca()
		{
			//Altera Banner
			m_formFBiblioteca.eCallAlteraBanner += new frmFBiblioteca.delCallAlteraBanner(alteraBanner);

			// Carrega Dados Interface
			m_formFBiblioteca.eCallCarregaDadosInterface += new frmFBiblioteca.delCallCarregaDadosInterface(carregaDadosInterface);

			// Refresh Dados Interface Edicao
			m_formFBiblioteca.eCallRefreshDadosInterfaceEdicao += new frmFBiblioteca.delCallRefreshDadosInterfaceEdicao(refreshDadosInterfaceEdicao);

			// Carrega Dados BD PEs
			m_formFBiblioteca.eCallCarregaDadosBDPEs += new frmFBiblioteca.delCallCarregaDadosBDPEs(carregaDadosBDPEs);

			// Salva Dados Interface View 
			m_formFBiblioteca.eCallSalvaDadosInterfaceView += new mdlBiblioteca.frmFBiblioteca.delCallSalvaDadosInterfaceView(vSalvaDadosInterfaceView);

			// Salva Dados BD
			m_formFBiblioteca.eCallSalvaDadosBD += new frmFBiblioteca.delCallSalvaDadosBD(salvaDadosBD);

			// Cadastra Conta
			m_formFBiblioteca.eCallCadastraPE += new frmFBiblioteca.delCallCadastraPE(cadastraPE);

			// Edita Conta
			m_formFBiblioteca.eCallShowEditaProcessoExportacao += new frmFBiblioteca.delCallShowEditaProcessoExportacao(ShowEditaProcessoExportacao);

			// Remove Conta
			m_formFBiblioteca.eCallRemovePE += new frmFBiblioteca.delCallRemovePE(removePE);

			// Seta Concluído
			m_formFBiblioteca.eCallSetaConcluido += new frmFBiblioteca.delCallSetaConcluido(setaPEConcluido);

			// Duplo Clique
			m_formFBiblioteca.eCallDuploClique += new frmFBiblioteca.delCallDuploClique(duploClique);

			// Click Banner
			m_formFBiblioteca.eCallClickBanner += new frmFBiblioteca.delCallClickBanner(clickBanner);
		}

		public void Close()
		{
			if (m_formFBiblioteca != null)
				m_formFBiblioteca.Close();
		}

		#endregion
		#region ShowDialog Cadastra PE
		protected void cadastraPE()
		{
			try
			{
				m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFBiblioteca.Refresh();
				if (m_typDatSetTbPes != null)
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
				if (m_typDatSetTbFaturasComerciais != null)
					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
				m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFBiblioteca.Refresh();
				m_clsCriacaoDocumentos = new mdlCriacaoDocumentos.Faturas.clsCriacaoProcesso(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, ref m_ilBandeiras);
				m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFBiblioteca.Refresh();
				m_clsCriacaoDocumentos.cadastraDocumento();
				if (m_clsCriacaoDocumentos.m_bModificado)
				{
					m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFBiblioteca.Refresh();
					m_typDatSetTbPes = null;
					m_typDatSetTbImportadores = null;
					m_typDatSetTbFaturasComerciais = null;
					salvaDadosBD(true);
					m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFBiblioteca.Refresh();
					carregaTypDatSet();
					m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFBiblioteca.Refresh();
					m_formFBiblioteca.PE = m_clsCriacaoDocumentos.CODIGORETORNO;
					m_strIdPENovo = m_clsCriacaoDocumentos.CODIGORETORNO;
					m_strIdPE = m_clsCriacaoDocumentos.CODIGORETORNO;
					OnCallPeCriado();
				}
				m_clsCriacaoDocumentos = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ShowEditaProcessoExportacao
		protected bool ShowEditaProcessoExportacao(string strIdPe)
		{
			bool bRetorno = false;
			m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_formFBiblioteca.Refresh();
			m_formFNumeroPE = new frmFNumeroPE(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,strIdPe);
			InitializeEventsFormNumeroPE();
			m_formFNumeroPE.ShowDialog();
			if (bRetorno = m_formFNumeroPE.m_bModificado)
			{
				salvaDadosBD(true);
				carregaTypDatSet();
			}
			return(bRetorno);
		}

		private void InitializeEventsFormNumeroPE()
		{
			// Salva Dados BD
			m_formFNumeroPE.eCallSalvaDadosBD += new frmFNumeroPE.delCallSalvaDadosBD(bSalvaDadosEdicaoPE);
		}
		#endregion

		#region Remove PE
		protected bool removePE(ref mdlComponentesGraficos.ListView lvPEs)
		{
			try
			{
				m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFBiblioteca.Refresh();
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes;
				string strIdPE = "";
				m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFBiblioteca.Refresh();
				if (lvPEs.SelectedItems.Count > 0)
				{
					m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFBiblioteca.Refresh();
					System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Biblioteca de PEs",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBiblioteca_clsBiblioteca_ApagarPEs).Replace("TAG",lvPEs.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
					//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvPEs.SelectedItems.Count.ToString() + " PE(s)?","Biblioteca de PEs",System.Windows.Forms.MessageBoxButtons.YesNo);
					while (lvPEs.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						strIdPE = lvPEs.SelectedItems[0].Text;
						dtrwRowTbPes = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,strIdPE);
						dtrwRowTbPes.Delete();
						lvPEs.SelectedItems[0].Selected = false;
						m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFBiblioteca.Refresh();
					}
					m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFBiblioteca.Refresh();
					if (drApaga == System.Windows.Forms.DialogResult.No)
						return false;
					else
					{
						m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFBiblioteca.Refresh();
						salvaDadosBD(true);
						m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFBiblioteca.Refresh();
						carregaTypDatSet();
						m_formFBiblioteca.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFBiblioteca.Refresh();
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		#endregion
		#region Duplo Clique
		protected void duploClique()
		{
			try
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				obj.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOIDEXPORTADOR, m_nIdExportador.ToString());
				obj.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPONUMEROPE, m_strIdPE);
				OnCallPESelecionado();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region setaPEConcluido
		protected void setaPEConcluido(ref mdlComponentesGraficos.ListView lvPEs, bool bConcluido)
		{
			try
			{
				System.DateTime dtConclusao = System.DateTime.Now;
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = null;
				foreach(System.Windows.Forms.ListViewItem lvItemPE in lvPEs.SelectedItems)
				{
					dtrwTbPEs = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador, lvItemPE.Text);
					if (dtrwTbPEs != null)
					{
						dtrwTbPEs.bConcluido = bConcluido;
						if (bConcluido)
							dtrwTbPEs.dtDataConclusao = dtConclusao;
						else
							dtrwTbPEs.SetdtDataConclusaoNull();
					}
				}
				salvaDadosBD(true);
				carregaTypDatSet();
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		
		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.FORMFIXO);
				m_strLinkBannerInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				m_formFBiblioteca.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ClickBanner
		private void clickBanner()
		{
			try
			{
				if (m_strLinkBannerInternet != "")
					System.Diagnostics.Process.Start(m_strLinkBannerInternet);
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
		private System.Collections.SortedList retornaPEsOrdenados()
		{
			System.Collections.SortedList srlPEs = new System.Collections.SortedList();
			try
			{
				foreach(mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes in m_typDatSetTbPes.tbPEs.Rows)
					srlPEs.Add(dtrwRowTbPes.idPE, dtrwRowTbPes);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
			return srlPEs;
		}
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvPEs, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo,out int nIdView)
		{
			nIdView = 0;
			try 
			{
				vCarregaBibliotecaView(ref nIdView);

				System.Collections.SortedList srlPEs = retornaPEsOrdenados();
				// List View Item
				System.Windows.Forms.ListViewItem lvItemPE;
				// Limpa os Items da List View
				lvPEs.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwRowTbPes = null;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwRowTbFaturasComerciais = null;
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
				// Preenche os itens da List View
				for (int nCont = 0 ; nCont < srlPEs.Count ; nCont++)
				{
					dtrwRowTbPes = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)srlPEs.GetByIndex(nCont);
					if (dtrwRowTbPes.RowState != System.Data.DataRowState.Deleted)
					{
						dtrwRowTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,dtrwRowTbPes.idPE);
						if (dtrwRowTbFaturasComerciais != null)
						{
							if (!dtrwRowTbFaturasComerciais.IsidImportadorNull())
								dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,dtrwRowTbFaturasComerciais.idImportador);
						}
						//PE
						lvItemPE = lvPEs.Items.Add(dtrwRowTbPes.idPE);
						if (dtrwRowTbPes.idPE == m_strIdPE)
						{
							lvItemPE.Selected = true;
						}
						if (!dtrwRowTbPes.IsbConcluidoNull())
							lvItemPE.Tag = dtrwRowTbPes.bConcluido;
						else
							lvItemPE.Tag = false;
						// Data Criacao
						if (!dtrwRowTbPes.IsdtDataCriacaoNull())
							lvItemPE.SubItems.Add(dtrwRowTbPes.dtDataCriacao.ToString("dd/MM/yyyy"));
						else
							lvItemPE.SubItems.Add(System.DateTime.Now.ToString("dd/MM/yyyy"));
						// Data Conclusao
						if ((!dtrwRowTbPes.IsbConcluidoNull()) && (dtrwRowTbPes.bConcluido == true))
						{
							lvItemPE.ImageIndex = 0;
							lvItemPE.SubItems.Add((dtrwRowTbPes.IsdtDataConclusaoNull() ? "" : dtrwRowTbPes.dtDataConclusao.ToString("dd/MM/yyyy")));
						}
						else
						{
							lvItemPE.ImageIndex = 1;
							lvItemPE.SubItems.Add("");
						}
						// Importador
						if (dtrwRowTbImportadores != null && !dtrwRowTbImportadores.IsnmCliNull())
							lvItemPE.SubItems.Add(dtrwRowTbImportadores.nmCli);
						else
							lvItemPE.SubItems.Add("");
						// Numero Fatura
						if (dtrwRowTbFaturasComerciais != null && !dtrwRowTbFaturasComerciais.IsnumeroFaturaNull())
							lvItemPE.SubItems.Add(dtrwRowTbFaturasComerciais.numeroFatura);
						else
							lvItemPE.SubItems.Add("");
						// Valor Fatura
						string strValorFatura = "";
						mdlIncoterm.clsManipuladorValor objValor = new mdlIncoterm.clsManipuladorValor(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_nIdExportador,dtrwRowTbPes.idPE);
                        objValor.vRetornaValores(out strValorFatura);
						lvItemPE.SubItems.Add(strValorFatura);
					}
				}
				if (lvPEs.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
					if (m_bMostrarBaloes)
					{
						m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
						m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
						m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlBiblioteca_clsBiblioteca_CriarNovoPE.ToString()).Replace("TAG",System.Environment.NewLine);
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
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBDPEs(ref mdlComponentesGraficos.ListView lvPEs, int nIndiceIcone)
		{
			try
			{
				m_strIdPE = lvPEs.SelectedItems[0].Text;
				m_nIndiceImagem = nIndiceIcone;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void refreshDadosInterfaceEdicao(ref mdlComponentesGraficos.ListView lvPEs)
		{
			try
			{
				if (lvPEs.SelectedItems.Count > 0)
				{
					System.Windows.Forms.ListViewItem lvItemPE = lvPEs.SelectedItems[0];
					if (m_bEdicaoModificado)
						if (lvItemPE.Text == m_strIdPE)
							lvItemPE.Text = m_strIdPENovo;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		protected void carregaTypDatSet()
		{
			// Cria os Arrays para pesquisa no Banco de Dados
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);
			arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
			arlOrdenacaoValor.Add("idPE");
			// Executa a pesquisa
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
			m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
			m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
		}

		#endregion
		#endregion
		#region Salvamento de Dados
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			m_bModificado = bModificado;
			if (m_typDatSetTbPes != null)
			{
				m_cls_dba_ConnectionDB.CheckIntegrityUpdate = true;
				m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
				m_cls_dba_ConnectionDB.CheckIntegrityUpdate = false;
			}
			//				if (m_typDatSetTbFaturasComerciais != null)
			//					m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
		}
		#endregion
		#endregion

		#region Carregamento de Dados Numero PE

		private void carregaIconePE(out int nIndice)
		{
			nIndice = m_nIndiceImagem;
		}
		#endregion
		#region Salvamento de Dados Numero PE
		private void salvaDadosInterfacePE(ref mdlComponentesGraficos.TextBox tbNumero)
		{
			try
			{
				m_strIdPENovo = tbNumero.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool bSalvaDadosEdicaoPE(string strIdPeAntigo,string strIdPeNovo)
		{
			bool bRetorno = false;

			// Nao modificado
			if (strIdPeAntigo == strIdPeNovo)
				return(true);

			foreach(mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe in m_typDatSetTbPes.tbPEs.Rows)
			{
				if ((dtrwPe.RowState != System.Data.DataRowState.Deleted) && (dtrwPe.idPE == strIdPeNovo))
				{
					mdlMensagens.clsMensagens.ShowError(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBiblioteca_frmFNumeroPE_NumeroPEInvalido) + " que ainda não esteja sendo utilizado.");
					return(false);
				}
			}

			mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPes = null;
			mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = null;
			dtrwTbPes = m_typDatSetTbPes.tbPEs.FindByidExportadoridPE(m_nIdExportador,strIdPeAntigo);
			dtrwTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,strIdPeAntigo);
			if (dtrwTbPes != null)
				dtrwTbPes.idPE = strIdPeNovo;
			if (dtrwTbFaturasComerciais != null)
				dtrwTbFaturasComerciais.idPE = strIdPeNovo;
			m_cls_dba_ConnectionDB.CheckIntegrityUpdate = true;
			m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetTbPes);
			m_cls_dba_ConnectionDB.CheckIntegrityUpdate = false;
			bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
			return(bRetorno);
		}
		#endregion

		#region View
			private void vCarregaBibliotecaView(ref int nIdView)
			{
				if (m_enumView == View.Notloaded)
				{
					mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_Arq = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
					string strView = cls_ini_Arq.retornaValor(mdlConstantes.clsConstantes.DEFAULT_SESSION_SISCOBRAS,mdlConstantes.clsConstantes.DEFAULT_VARIABLE_BIBLIOTECA_VIEW,View.List.ToString());
					try
					{
						if (strView == "")
							m_enumView = View.List;
						else
							m_enumView = (View)Enum.Parse(View.Notloaded.GetType(),strView,true);
					}catch{
						m_enumView = View.List;
					}
				}
				switch(m_enumView)
				{
					case View.Details:
						nIdView = 1;
						break;
					case View.List:
						nIdView = 3;
						break;
					case View.LargeIcons:
						nIdView = 0;
						break;
					case View.SmallIcons:
						nIdView = 2;
						break;
				}
			}

			private void vSalvaDadosInterfaceView(int nIdView)
			{
				string strView = View.List.ToString();
				switch(nIdView)
				{
					case 1:
					    strView = View.Details.ToString();
						break;
					case 3:
						strView = View.List.ToString();
						break;
					case 0:
						strView = View.LargeIcons.ToString();
						break;
					case 2:
						strView = View.SmallIcons.ToString();
						break;
				}
				mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_Arq = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
				cls_ini_Arq.colocaValor(mdlConstantes.clsConstantes.DEFAULT_SESSION_SISCOBRAS,mdlConstantes.clsConstantes.DEFAULT_VARIABLE_BIBLIOTECA_VIEW,strView);
			}
		#endregion

		#region Retorno de Valores
		public void retornaValores(out string strPE)
		{
			strPE = m_strIdPE;
		}
		#endregion
	}
}
