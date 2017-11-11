using System;

namespace mdlContas
{
	/// <summary>
	/// Summary description for clsContas.
	/// </summary>
	public class clsContas
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = "";
		protected string m_strDirImagens = "";
		protected string m_strLinkBannerInternet = "";

		private const string PF1 = "12";
		private const string PF2 = "22";

		private string m_strIdCliente = "00";
		private bool m_bExportadorPJ = true;

		private bool m_bMostrarBaloes = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		private System.Windows.Forms.Form frmMdiParent = null;

		private int m_nIdExportador = -1;
		
		private string m_strExportador = "";
		private string m_strNomeFantasia = "";
		private string m_strCNPJ = "";
		private string m_strLogradouro = "";
		private string m_strBairro = "";
		private string m_strCidade = "";
		private int m_nIdEstado = -1;
		private string m_strCEP = "";
		private string m_strTelefone1 = "";
		private string m_strTelefone2 = "";
		private string m_strFax = "";
		private string m_strCelular = "";
		private string m_strEMail = "";
		private string m_strSite = "";
		private string m_strEstado = "";

		private const string m_strFormatoFaturaComercial = "PPP.MMDD.NNN";

		protected bool m_bModificado = false;

		protected string[] m_strarrFiles = null;

		private frmFContas m_formFContas = null;
		private frmFContasCadEdit m_formFContasCadEdit = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros m_typDatSetTbEstadosBrasileiros;
		#endregion

		#region Construtores & Destrutores
		public clsContas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel, ref System.Windows.Forms.Form frmParent, int nIdExportador)
		{
			//
			// TODO: Add constructor logic here
			//
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			frmMdiParent = frmParent;
			m_nIdExportador = nIdExportador;
			m_strDirImagens = "Imagens\\";
			m_strIdCliente = m_cls_dba_ConnectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOIDCLIENTE,"00");
			if ((m_strIdCliente != "") && (m_strIdCliente.Length > 2))
				m_strIdCliente = m_strIdCliente.Substring(0,2);
			else
				m_strIdCliente = "00";
			m_bExportadorPJ = ((m_strIdCliente == PF1 || m_strIdCliente == PF2) ? false : true);
			carregaTypDatSet();
			carregaDadosBDCadEdit();
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region Delegate
		public delegate void delCallContaSelecionada(int nIdExportador, string strNomeFantasia);
		#endregion
		#region Events
		public event delCallContaSelecionada eCallContaSelecionada;
		#endregion
		#region Events Methods
		protected virtual void OnCallContaSelecionada()
		{
			if (eCallContaSelecionada != null)
				eCallContaSelecionada(m_nIdExportador,m_strNomeFantasia);
		}
		#endregion

		#region Inicializa as variáveis m_typDatSet
		protected void carregaTypDatSet()
		{
			// Cria os Arrays para pesquisa no Banco de Dados
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Diferente);
			arlCondicoesValor.Add(-1);
			arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
			arlOrdenacaoValor.Add("marca");
			// Executa a pesquisa
			m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);

			arlOrdenacaoValor.Clear();
			arlOrdenacaoValor.Add("strSigla");

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
			m_typDatSetTbEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
		}
		#endregion

		#region InitializeEventsFormContas
		private void InitializeEventsFormContas()
		{
			//Altera Banner
			m_formFContas.eCallAlteraBanner += new frmFContas.delCallAlteraBanner(alteraBanner);

			// Click Banner
			m_formFContas.eCallClickBanner += new frmFContas.delCallClickBanner(clickBanner);

			// Carrega Dados Interface
			m_formFContas.eCallCarregaDadosInterface += new frmFContas.delCallCarregaDadosInterface(carregaDadosInterface);

			// Carrega Dados BD Contas
			m_formFContas.eCallCarregaDadosBDContas += new frmFContas.delCallCarregaDadosBDContas(carregaDadosBDContas);

			// Salva Dados BD
			m_formFContas.eCallSalvaDadosBD += new frmFContas.delCallSalvaDadosBD(salvaDadosBD);

			// Cadastra Conta
			m_formFContas.eCallCadastraConta += new frmFContas.delCallCadastraConta(cadastraConta);

			// Edita Conta
			m_formFContas.eCallEditaConta += new frmFContas.delCallEditaConta(editaConta);

			// Remove Conta
			m_formFContas.eCallRemoveConta += new frmFContas.delCallRemoveConta(removeConta);

			// Duplo Clique
			m_formFContas.eCallDuploClique += new frmFContas.delCallDuploClique(duploClique);
		}
		#endregion

		#region InitializeEventsFormContasCadEdit
		private void InitializeEventsFormContasEdit()
		{
			// Carreda Dados BD
			m_formFContasCadEdit.eCallCarregaDadosBD += new frmFContasCadEdit.delCallCarregaDadosBD(carregaDadosBDCadEdit);

			// Carrega Dados Interface
			m_formFContasCadEdit.eCallCarregaDadosInterface += new frmFContasCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceCadEdit);

			// Carrega Dados Interface Estados
			m_formFContasCadEdit.eCallCarregaDadosInterfaceEstados += new frmFContasCadEdit.delCallCarregaDadosInterfaceEstados(carregaDadosInterfaceEstados);

			// Salva Dados Interface
			m_formFContasCadEdit.eCallSalvaDadosInterface += new frmFContasCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceExportador);

			// Salva Dados BD
			m_formFContasCadEdit.eCallSalvaDadosBD += new frmFContasCadEdit.delCallSalvaDadosBD(salvaDadosBDExportador);

			// Sugere Nome Fantasia
			m_formFContasCadEdit.eCallSugereNomeFantasia += new frmFContasCadEdit.delCallSugereNomeFantasia(sugereNomeFantasia);
		}
		#endregion

		#region Show
		public void Show()
		{
			try
			{
				m_formFContas = new frmFContas(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormContas();
				m_formFContas.MdiParent = frmMdiParent;
				m_formFContas.Show();
				m_formFContas.BringToFront();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Close
		public void Close()
		{
			try
			{
				if (m_formFContas != null)
					m_formFContas.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Cadastra Conta
		protected void cadastraConta()
		{
			try
			{
				m_formFContasCadEdit = new frmFContasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_formFContas, true);
				InitializeEventsFormContasEdit();
				m_formFContasCadEdit.setTextoGroupBox("Cadastro");
				m_formFContasCadEdit.ShowDialog();
				m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFContas.Refresh();
				if (m_formFContasCadEdit.m_bModificado)
				{
					m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFContas.Refresh();
					salvaDadosBD(true);
					m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFContas.Refresh();
//					carregaTypDatSet();
//					carregaDadosBDCadEdit();
					if (m_mgblBalaoToolTip != null)
						m_mgblBalaoToolTip.Close();
					m_mgblBalaoToolTip = null;
					OnCallContaSelecionada();
				}
				m_formFContasCadEdit = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Edita Conta
		public void editaConta()
		{
			try
			{
				m_formFContasCadEdit = new frmFContasCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_formFContas);
				InitializeEventsFormContasEdit();
				m_formFContasCadEdit.setTextoGroupBox("Edição");
				m_formFContasCadEdit.ShowDialog();
				if (m_formFContasCadEdit.m_bModificado)
				{
					salvaDadosBD(true);
					carregaTypDatSet();
					carregaDadosBDCadEdit();
				}
				m_formFContasCadEdit = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Conta
		protected void removeConta(ref mdlComponentesGraficos.ListView lvContas)
		{
			try
			{
				m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFContas.Refresh();
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				int nIdExportador = -1;
				if (lvContas.SelectedItems.Count > 0)
				{
					m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFContas.Refresh();
					System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Importadores", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_clsContas_ApagarExportador).Replace("TAG",lvContas.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
					//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvContas.SelectedItems.Count.ToString() + " exportadore(s)?","Importadores",System.Windows.Forms.MessageBoxButtons.YesNo);
					while (lvContas.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFContas.Refresh();
						nIdExportador = Int32.Parse(lvContas.SelectedItems[0].Tag.ToString());
						dtrwRowTbExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(nIdExportador);
						dtrwRowTbExportadores.Delete();
						lvContas.SelectedItems[0].Selected = false;
						m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFContas.Refresh();
					}
					if (drApaga == System.Windows.Forms.DialogResult.Yes)
					{
						m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFContas.Refresh();
						salvaDadosBD(true);
						m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFContas.Refresh();
						carregaTypDatSet();
						carregaDadosBDCadEdit();
						m_formFContas.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						m_formFContas.Refresh();
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
		#region DuploClique
		protected void duploClique()
		{
			try
			{
				if (m_mgblBalaoToolTip != null)
					m_mgblBalaoToolTip.Close();
				m_mgblBalaoToolTip = null;
				OnCallContaSelecionada();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
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
				m_formFContas.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
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
			private System.Collections.SortedList retornaContasOrdenadas()
			{
				System.Collections.SortedList srlContas = new System.Collections.SortedList();
				try
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores in m_typDatSetTbExportadores.tbExportadores.Rows)
					{
						if (dtrwTbExportadores.RowState != System.Data.DataRowState.Deleted)
							if (!srlContas.ContainsKey(dtrwTbExportadores.marca + dtrwTbExportadores.idExportador.ToString()))
								srlContas.Add(dtrwTbExportadores.marca + dtrwTbExportadores.idExportador.ToString(), dtrwTbExportadores);
					}
				}
				catch (Exception err)
				{
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
				return srlContas;
			}
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvContas, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo)
			{
				try 
				{
					System.Collections.SortedList srlContas = retornaContasOrdenadas();
					// List View Item
					System.Windows.Forms.ListViewItem lvItemConta;
					// Limpa os Items da List View
					lvContas.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < srlContas.Count ; nCont++)
					{
						dtrwRowTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)srlContas.GetByIndex(nCont);
						if (dtrwRowTbExportadores.RowState != System.Data.DataRowState.Deleted)
						{
							lvItemConta = lvContas.Items.Add(dtrwRowTbExportadores.marca);
							lvItemConta.Tag = dtrwRowTbExportadores.idExportador;
							lvItemConta.ImageIndex = 0;
							if ((int)lvItemConta.Tag == m_nIdExportador)
							{
								lvItemConta.Selected = true;
							}
						}
					}
					if (lvContas.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
						btNovo.Enabled = true;
						if (m_bMostrarBaloes)
						{
							m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
							m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlContas_clsContas_CriarNovaConta.ToString());
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
						btNovo.Enabled = !m_bExportadorPJ;
					}
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosBDContas(ref mdlComponentesGraficos.ListView lvContas)
			{
				try
				{
					m_nIdExportador = Int32.Parse(lvContas.SelectedItems[0].Tag.ToString());
					m_strNomeFantasia = lvContas.SelectedItems[0].Text;
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
			#endregion
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				if (m_typDatSetTbExportadores != null)
					m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
			}
			#endregion
		#endregion

		#region Carregamento de Dados Exportador
		#region Banco de Dados
		protected void carregaDadosBDCadEdit()
		{
			try
			{
				#region Pesquisa
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
				dtrwRowTbExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(m_nIdExportador);
				#endregion

				#region Salvando os items nos atributos de classe
				if (dtrwRowTbExportadores != null)
				{
					if (!dtrwRowTbExportadores.IsnmEmpNull())
						m_strExportador = dtrwRowTbExportadores.nmEmp;
					if (!dtrwRowTbExportadores.IsidEstadoEmpNull())
					{
						m_nIdEstado = dtrwRowTbExportadores.idEstadoEmp;
						mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwTbEstadosBrasileiros = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(m_nIdEstado);
						if (dtrwTbEstadosBrasileiros != null)
							m_strEstado = dtrwTbEstadosBrasileiros.strSigla;
					}
					if (!dtrwRowTbExportadores.IsmarcaNull())
						m_strNomeFantasia = dtrwRowTbExportadores.marca;
					if (!dtrwRowTbExportadores.IsmstrCnpjNull())
						m_strCNPJ = dtrwRowTbExportadores.mstrCnpj;
					if (!dtrwRowTbExportadores.IsmstrEndEmpNull())
						m_strLogradouro = dtrwRowTbExportadores.mstrEndEmp;
					if (!dtrwRowTbExportadores.IsmstrBairroEmpNull())
						m_strBairro = dtrwRowTbExportadores.mstrBairroEmp;
					if (!dtrwRowTbExportadores.IsmstrCidadeEmpNull())
						m_strCidade = dtrwRowTbExportadores.mstrCidadeEmp;
					if (!dtrwRowTbExportadores.IsmstrCepEmpNull())
						m_strCEP = dtrwRowTbExportadores.mstrCepEmp;
					if (!dtrwRowTbExportadores.IsmstrTelEmpNull())
						m_strTelefone1 = dtrwRowTbExportadores.mstrTelEmp;
					if (!dtrwRowTbExportadores.IsmstrTel2EmpNull())
						m_strTelefone2 = dtrwRowTbExportadores.mstrTel2Emp;
					if (!dtrwRowTbExportadores.IsmstrFaxEmpNull())
						m_strFax = dtrwRowTbExportadores.mstrFaxEmp;
					if (!dtrwRowTbExportadores.IsmstrCelEmpNull())
						m_strCelular = dtrwRowTbExportadores.mstrCelEmp;
					if (!dtrwRowTbExportadores.IsmstrEmailEmpNull())
						m_strEMail = dtrwRowTbExportadores.mstrEmailEmp;
					if (!dtrwRowTbExportadores.IsmstrSiteEmpNull())
						m_strSite = dtrwRowTbExportadores.mstrSiteEmp;
				}
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected void carregaDadosInterfaceCadEdit(ref mdlComponentesGraficos.TextBox tbExportador, ref mdlComponentesGraficos.TextBox tbNomeFantasia, ref mdlComponentesGraficos.TextBox tbCNPJ, ref mdlComponentesGraficos.TextBox tbLogradouro, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCep, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbTel1, ref mdlComponentesGraficos.TextBox tbTel2, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.TextBox tbCelular, ref mdlComponentesGraficos.TextBox tbEMail, ref mdlComponentesGraficos.TextBox tbSite)
		{
			try
			{
				#region Pesquisa
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("strSigla");

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
							
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwRowTbEstadosBrasileiros;
				#endregion

				#region Adicionando Items ao Formulário
				tbExportador.Text = m_strExportador;
				tbNomeFantasia.Text = m_strNomeFantasia;
				tbCNPJ.Text = m_strCNPJ;
				tbLogradouro.Text = m_strLogradouro;
				tbBairro.Text = m_strBairro;
				tbCep.Text = m_strCEP;
				tbCidade.Text = m_strCidade;
				if (m_typDatSetTbEstadosBrasileiros != null)
				{
					for (int nCont = 0 ; nCont < m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows.Count ; nCont++)
					{
						dtrwRowTbEstadosBrasileiros = (mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow)m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows[nCont];
						cbEstado.AddItem(dtrwRowTbEstadosBrasileiros.strSigla, dtrwRowTbEstadosBrasileiros.nIdEstado);
						if (dtrwRowTbEstadosBrasileiros.nIdEstado == m_nIdEstado)
						{
							cbEstado.SelectedIndex = nCont;
							m_strEstado = dtrwRowTbEstadosBrasileiros.strNome;
						}
					}
				}
				tbTel1.Text = m_strTelefone1;
				tbTel2.Text = m_strTelefone2;
				tbFax.Text = m_strFax;
				tbCelular.Text = m_strCelular;
				tbEMail.Text = m_strEMail;
				tbSite.Text = m_strSite;
				#endregion
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosInterfaceEstados(ref mdlComponentesGraficos.ComboBox cbEstado)
		{                
			#region Adiciona a ComboBox
			mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwRowTbEstadosBrasileiros;
			if (m_typDatSetTbEstadosBrasileiros != null)
			{
				for (int nCont = 0 ; nCont < m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows.Count ; nCont++)
				{
					dtrwRowTbEstadosBrasileiros = (mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow)m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows[nCont];
					cbEstado.AddItem(dtrwRowTbEstadosBrasileiros.strSigla, dtrwRowTbEstadosBrasileiros.nIdEstado);
				}
			}
			#endregion
		}
			#endregion
		#endregion
		#region Salvamento de Dados Exportador
			#region Interface
			protected void salvaDadosInterfaceExportador(ref mdlComponentesGraficos.TextBox tbExportador, ref mdlComponentesGraficos.TextBox tbNomeFantasia, ref mdlComponentesGraficos.TextBox tbCNPJ, ref mdlComponentesGraficos.TextBox tbLogradouro, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCep, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbTel1, ref mdlComponentesGraficos.TextBox tbTel2, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.TextBox tbCelular, ref mdlComponentesGraficos.TextBox tbEMail, ref mdlComponentesGraficos.TextBox tbSite)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwRowEstados;

					m_strExportador = tbExportador.Text;
					m_strNomeFantasia = tbNomeFantasia.Text;
					m_strCNPJ = tbCNPJ.Text;
					m_strLogradouro = tbLogradouro.Text;
					m_strBairro = tbBairro.Text;
					m_strCEP = tbCep.Text;
					m_strCidade = tbCidade.Text;

					m_nIdEstado = Int32.Parse(cbEstado.ReturnObjectSelectedItem().ToString());
					dtrwRowEstados = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(m_nIdEstado);
					m_strEstado = dtrwRowEstados.strNome;

					m_strTelefone1 = tbTel1.Text;
					m_strTelefone2 = tbTel2.Text;
					m_strFax = tbFax.Text;
					m_strCelular = tbCelular.Text;
					m_strEMail = tbEMail.Text;
					m_strSite = tbSite.Text;
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDExportador(bool cadastraNovo)
			{
				try
				{
					#region Pesquisa ou Criação do Registro
					int nIdExportador = 1;
					// Cria a variável para conter o registro corrente
					mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwRowTbExportadores;
					if (cadastraNovo == false) 
					{
						// Executa a pesquisa
						dtrwRowTbExportadores = m_typDatSetTbExportadores.tbExportadores.FindByidExportador(m_nIdExportador);
					} 
					else
					{
						while (m_typDatSetTbExportadores.tbExportadores.FindByidExportador(nIdExportador) != null)
							nIdExportador++;

						dtrwRowTbExportadores = m_typDatSetTbExportadores.tbExportadores.NewtbExportadoresRow();
						dtrwRowTbExportadores.idExportador = nIdExportador;
						m_nIdExportador = nIdExportador;

					}
					#endregion

					#region Salvando os Dados TbExportadores
					dtrwRowTbExportadores.nmEmp = m_strExportador;
					dtrwRowTbExportadores.marca = m_strNomeFantasia;
					dtrwRowTbExportadores.mstrCnpj = m_strCNPJ;
					dtrwRowTbExportadores.mstrEndEmp = m_strLogradouro;
					dtrwRowTbExportadores.mstrBairroEmp = m_strBairro;
					dtrwRowTbExportadores.mstrCepEmp = m_strCEP;
					dtrwRowTbExportadores.mstrCidadeEmp = m_strCidade;
					dtrwRowTbExportadores.idEstadoEmp = m_nIdEstado;
					dtrwRowTbExportadores.mstrTelEmp = m_strTelefone1;
					dtrwRowTbExportadores.mstrTel2Emp = m_strTelefone2;
					dtrwRowTbExportadores.mstrFaxEmp = m_strFax;
					dtrwRowTbExportadores.mstrCelEmp = m_strCelular;
					dtrwRowTbExportadores.mstrEmailEmp = m_strEMail;
					dtrwRowTbExportadores.mstrSiteEmp = m_strSite;

					if (cadastraNovo)
					{
						dtrwRowTbExportadores.idRelatorioBordero = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemAladiAce39 = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemAladiAptr04 = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemAnexoIII = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemComum = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemMercosul = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemMercosulBolivia = 0;
						dtrwRowTbExportadores.idRelatorioCertificadoOrigemMercosulChile = 0;
						dtrwRowTbExportadores.idRelatorioCotacao = 0;
						dtrwRowTbExportadores.idRelatorioDocBancInstrucaoDeRemessa = 0;
						dtrwRowTbExportadores.idRelatorioFaturaComercial = 0;
						dtrwRowTbExportadores.idRelatorioFaturaProforma = 0;
						dtrwRowTbExportadores.idRelatorioFaturaProforma = 0;
						dtrwRowTbExportadores.idRelatorioInstrucaoEmbarque = 0;
						dtrwRowTbExportadores.idRelatorioRomaneio = 0;
						dtrwRowTbExportadores.idRelatorioSaque = 0;
						dtrwRowTbExportadores.formatoNumero = m_strFormatoFaturaComercial;

						// Opcoes Padrao dos novos Exportadores
						dtrwRowTbExportadores.colunaCodigo = 1;
						dtrwRowTbExportadores.tamanhoColunaCodigo = 60;
						dtrwRowTbExportadores.colunaQuantidade = 2;
						dtrwRowTbExportadores.tamanhoColunaQuantidade = 60;
						dtrwRowTbExportadores.colunaDescricao = 3;
						dtrwRowTbExportadores.tamanhoColunaDescricao = 250;
						dtrwRowTbExportadores.colunaUnidade = 4;
						dtrwRowTbExportadores.tamanhoColunaUnidade = 50;
						dtrwRowTbExportadores.colunaPrecoUnitario = 5;
						dtrwRowTbExportadores.tamanhoColunaPrecoUnitario = 60;
						dtrwRowTbExportadores.colunaDescricaoLinguaEstrangeira = 6;
						dtrwRowTbExportadores.tamanhoColunaDescricaoLinguaEstrangeira = 150;

						dtrwRowTbExportadores.nColunaDetalharProdutos = 0;
						dtrwRowTbExportadores.nTamanhoColunaDetalharProdutos = 0;
						dtrwRowTbExportadores.nColunaOrdemLancamento = 0;
						dtrwRowTbExportadores.nTamanhoColunaOrdemLancamento = 0;

						dtrwRowTbExportadores.bProdutosVisualizarNcm = true;
						dtrwRowTbExportadores.bProdutosVisualizarNaladi = true;
					}

					#endregion
						
					if (cadastraNovo == true)
					{
						m_typDatSetTbExportadores.tbExportadores.AddtbExportadoresRow(dtrwRowTbExportadores);
					} 
					m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion

		#region Sugere Nome Fantasia
		private void sugereNomeFantasia(ref mdlComponentesGraficos.TextBox tbRazaoSocial, ref mdlComponentesGraficos.TextBox tbNomeFantasia)
		{
			try
			{
				if (tbRazaoSocial.Text.Trim() != "")
				{
					if (tbRazaoSocial.Text.IndexOf(" ") != -1)
						tbNomeFantasia.Text = tbRazaoSocial.Text.Substring(0,tbRazaoSocial.Text.IndexOf(" ")).ToUpper();
					else
						tbNomeFantasia.Text = tbRazaoSocial.Text.ToUpper();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorno de Valores
		public void retornaValores(out string strExportador, out string strNomeFantasia, out string strCNPJ, out string strLogradouro, out string strBairro, out string strCEP, out string strCidade, out int nIdEstado, out string strEstado, out string strTelefone1, out string strTelefone2, out string strFax, out string strCelular, out string strEMail, out string strSite)
		{
			strExportador = m_strExportador;

			strNomeFantasia = m_strNomeFantasia;
			strCNPJ = m_strCNPJ;
			strLogradouro = m_strLogradouro;
			strBairro = m_strBairro;
			strCEP = m_strCEP;
			strCidade = m_strCidade;

			nIdEstado = m_nIdEstado;
			strEstado = m_strEstado;

			strTelefone1 = m_strTelefone1;
			strTelefone2 = m_strTelefone2;
			strFax = m_strFax;
			strCelular = m_strCelular;
			strEMail = m_strEMail;
			strSite = m_strSite;
		}
		#endregion
	}
}
