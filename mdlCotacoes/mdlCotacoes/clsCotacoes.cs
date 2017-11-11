using System;

namespace mdlCotacoes
{
	/// <summary>
	/// Summary description for clsCotações.
	/// </summary>
	public class clsCotacoes
	{
		#region Delegate
			public delegate void delCallCotacoesSelecionada(string strIdCotacao);
		#endregion
		#region Events
			public event delCallCotacoesSelecionada eCallCotacoesSelecionada;
		#endregion
		#region Events Methods
			protected virtual void OnCallCotacoesSelecionada()
			{
				if (eCallCotacoesSelecionada != null)
				{
					if (m_mgblBalaoToolTip != null)
						m_mgblBalaoToolTip.Close();
					m_mgblBalaoToolTip = null;
					eCallCotacoesSelecionada(m_strIdCotacao);
				}
			}
		#endregion

		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected string m_strEnderecoExecutavel = "";

		private bool m_bMostrarBaloes = true;

		internal clsListViewItemComparer m_clsSorter = null, m_clsDescendingSorter = null;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		private int m_nIdExportador = -1;
		private string m_strIdCotacao = "";

		protected bool m_bModificado = false;

		private mdlNumero.clsNumero m_clsNumero = null;
		private mdlCriacaoDocumentos.clsCriacao m_clsCriacaoCotacao = null;
		private frmFCotacoes m_formFCotacoes = null;
		private System.Windows.Forms.Form m_formFMdiParent = null;

		private System.Windows.Forms.ImageList m_ilBandeiras = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		#endregion
		#region Construtors and Destrutors
			public clsCotacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string strEnderecoExecutavel,ref System.Windows.Forms.Form formParent,int nIdExportador, ref System.Windows.Forms.ImageList ilBandeiras)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_formFMdiParent = formParent;
				m_nIdExportador = nIdExportador;
				m_ilBandeiras = ilBandeiras;
				m_clsSorter = new clsListViewItemComparer();
				m_clsDescendingSorter = new clsListViewItemComparerDescending();
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
					m_formFCotacoes = new frmFCotacoes(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					m_formFCotacoes.MdiParent = m_formFMdiParent;
					vInitializeEvents(ref m_formFCotacoes);
					m_formFCotacoes.Show();
					m_formFCotacoes.BringToFront();
				}
				catch (Exception err)
				{
					Object erro = err;
				}
			}

			private void vInitializeEvents(ref frmFCotacoes formFCotacoes)
			{
				// Carrega Dados BD
				formFCotacoes.eCallCarregaDadosBD += new frmFCotacoes.delCallCarregaDadosBD(carregaTypDatSet);

				// Carrega Dados Interface
				formFCotacoes.eCallCarregaDadosInterface += new frmFCotacoes.delCallCarregaDadosInterface(carregaDadosInterface);

				// Ordenando
				formFCotacoes.eCallOrdenaItens += new frmFCotacoes.delCallOrdenaItens(ordenaListViewItens);

				// Carrega Dados BD Cotacoes
				formFCotacoes.eCallCarregaDadosBDCotacoes += new frmFCotacoes.delCallCarregaDadosBDCotacoes(carregaDadosBDCotacoes);

				// Salva Dados BD
				formFCotacoes.eCallSalvaDadosBD += new frmFCotacoes.delCallSalvaDadosBD(salvaDadosBD);

				// Cadastra Cotação
				formFCotacoes.eCallCadastraCotacao += new frmFCotacoes.delCallCadastraCotacao(cadastraCotacao);

				// Edita Cotação
				formFCotacoes.eCallEditaCotacao += new frmFCotacoes.delCallEditaCotacao(editaCotacao);

				// Remove Cotação
				formFCotacoes.eCallRemoveCotacao += new frmFCotacoes.delCallRemoveCotacao(removeCotacao);

				// Duplo Clique
				formFCotacoes.eCallDuploClique += new frmFCotacoes.delCallDuploClique(duploClique);
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
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);
			arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
			arlOrdenacaoValor.Add("idCotacao");
			// Executa a pesquisa
			m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);
			m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
		}
		#endregion

		#region Cadastra Cotacao
		protected void cadastraCotacao()
		{
			try
			{
				m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFCotacoes.Refresh();
				if (m_typDatSetTbFaturasCotacoes != null)
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
				m_clsCriacaoCotacao = new mdlCriacaoDocumentos.Faturas.clsCriacaoCotacao(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, ref m_ilBandeiras);
				m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFCotacoes.Refresh();
				m_clsCriacaoCotacao.cadastraDocumento();
				m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFCotacoes.Refresh();
				if (m_clsCriacaoCotacao.m_bModificado)
				{
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					m_strIdCotacao = m_clsCriacaoCotacao.CODIGORETORNO;
					m_clsCriacaoCotacao = null;
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					OnCallCotacoesSelecionada();
				}
				else
				{
					m_clsCriacaoCotacao = null;
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					carregaTypDatSet();
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
				}
				m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFCotacoes.Refresh();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Edita Cotacao
		protected void editaCotacao()
		{
			try
			{
				m_clsNumero = new mdlNumero.Faturas.clsNumeroFaturaCotacao(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCotacao);
				m_clsNumero.ShowDialog();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Cotacao
		protected bool removeCotacao(ref mdlComponentesGraficos.ListView lvCotacoes)
		{
			m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_formFCotacoes.Refresh();
			mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
			string strIdCotacao = "";
			if (lvCotacoes.SelectedItems.Count > 0)
			{
				m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_formFCotacoes.Refresh();
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Biblioteca de Cotações",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlCotacoes_clsCotacao_ApagarCotacoes).Replace("TAG",lvCotacoes.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvCotacoes.SelectedItems.Count.ToString() + " Cotação(ões)?","Biblioteca de Cotações",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvCotacoes.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					strIdCotacao = (string)lvCotacoes.SelectedItems[0].Tag;
					dtrwRowTbFaturasCotacoes = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,strIdCotacao);
					dtrwRowTbFaturasCotacoes.Delete();
					lvCotacoes.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.No)
					return false;
				else
				{
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					salvaDadosBD(true);
					m_formFCotacoes.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					m_formFCotacoes.Refresh();
					carregaTypDatSet();
				}
			}
			return true;
		}
		#endregion
		#region Duplo Clique
		protected void duploClique()
		{
			try
			{
				OnCallCotacoesSelecionada();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Ordenando
		private void ordenaListViewItens(ref mdlComponentesGraficos.ListView lvCotacoes)
		{
			try
			{
				switch(lvCotacoes.View)
				{
					case(System.Windows.Forms.View.Details):
						m_clsSorter.COLUNA = m_formFCotacoes.m_nIdColunaSelecionada;
						m_clsDescendingSorter.COLUNA = m_formFCotacoes.m_nIdColunaSelecionada;
						break;
					default:
						m_clsSorter.COLUNA = 0;
						m_clsDescendingSorter.COLUNA = 0;
						break;
				}
				if (lvCotacoes.Sorting == System.Windows.Forms.SortOrder.Descending)
					lvCotacoes.ListViewItemSorter = m_clsDescendingSorter;
				else
					lvCotacoes.ListViewItemSorter = m_clsSorter;
				lvCotacoes.Sort();
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Close
		public void Close()
		{
			try
			{
				if (m_formFCotacoes != null)
					m_formFCotacoes.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados
		#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvCotacoes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo)
			{
				try 
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemCotacoes;
					// Limpa os Items da List View
					lvCotacoes.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes = null;
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count ; nCont++)
					{
						dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[nCont];
						if (dtrwRowTbFaturasCotacoes != null && dtrwRowTbFaturasCotacoes.RowState != System.Data.DataRowState.Deleted)
						{
							if (!dtrwRowTbFaturasCotacoes.IsidImportadorNull())
								dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,dtrwRowTbFaturasCotacoes.idImportador);
							lvItemCotacoes = lvCotacoes.Items.Add(dtrwRowTbFaturasCotacoes.IsmstrNumeroNull() ? dtrwRowTbFaturasCotacoes.idCotacao : dtrwRowTbFaturasCotacoes.mstrNumero);
							lvItemCotacoes.Tag = dtrwRowTbFaturasCotacoes.idCotacao;
							lvItemCotacoes.ImageIndex = 0;
							if (!dtrwRowTbFaturasCotacoes.IsidImportadorNull())
							{
								if (dtrwRowTbImportadores != null && !dtrwRowTbImportadores.IsnmCliNull())
									lvItemCotacoes.SubItems.Add(dtrwRowTbImportadores.nmCli);
								else
									lvItemCotacoes.SubItems.Add("");
							}
						}
					}
					if (lvCotacoes.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
						if (m_bMostrarBaloes)
						{
							m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
							m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlCotacoes_clsCotacoes_CriarNovaCotacao.ToString()).Replace("TAG",System.Environment.NewLine);
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
			protected void carregaDadosBDCotacoes(ref mdlComponentesGraficos.ListView lvCotacoes)
			{
				try
				{
					if (lvCotacoes.SelectedItems.Count > 0)
                        m_strIdCotacao = (string)lvCotacoes.SelectedItems[0].Tag;
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
				if (m_typDatSetTbFaturasCotacoes != null)
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
			}
			#endregion
		#endregion

		#region Retorno de Valores
		public void retornaValores(out string strCotacao)
		{
			strCotacao = m_strIdCotacao;
		}
		#endregion
	}
	#region Implements the manual sorting of items by columns.
	internal class clsListViewItemComparer : System.Collections.IComparer 
	{
		internal int COLUNA
		{
			set
			{
				col = value;
			}
		}
		protected int col;
		public clsListViewItemComparer() 
		{
			col=0;
		}
		public clsListViewItemComparer(int column) 
		{
			col=column;
		}
		public virtual int Compare(object x, object y) 
		{
			return String.Compare(((System.Windows.Forms.ListViewItem)x).SubItems[col].Text, ((System.Windows.Forms.ListViewItem)y).SubItems[col].Text);
		}
	}
	// Ordenação Descendente
	internal class clsListViewItemComparerDescending : clsListViewItemComparer 
	{
		public override int Compare(object x, object y) 
		{
			return String.Compare(((System.Windows.Forms.ListViewItem)y).SubItems[col].Text, ((System.Windows.Forms.ListViewItem)x).SubItems[col].Text);
		}
	}
	#endregion
}
