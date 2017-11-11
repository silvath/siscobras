using System;

namespace mdlBancos
{
	/// <summary>
	/// Summary description for clsBancoExportador.
	/// </summary>
	public abstract class clsBancoExportador
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;
		
		private bool m_bMostrarBaloes = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;

		public int IDBANCO
		{
			get
			{
				return m_nIdBanco;
			}
		}
		protected int m_nIdExportador = -1;
		protected int m_nIdBanco = -1;
		protected int m_nIdEstado = -1;
		protected string m_strIdAgencia = "";
		protected string m_strNovoIdAgencia = "";
		protected string m_strIdConta = "";
		protected string m_strNovoIdConta = "";
		protected string m_strBanco = "";
		protected string m_strEndereco = "";
		protected string m_strBairro = "";
		protected string m_strCidade = "";
		protected string m_strEstado = "";
		protected string m_strEstadoSigla = "";
		protected string m_strCEP = "";
		protected string m_strInstrucoesPagamento = "";
		protected string m_strObs = "";
		protected string m_strTelefone = "";
		protected string m_strFax = "";

		public bool m_bModificado = false;
		private int m_nRowsBancos = -1;
		private int m_nRowsAgencias = -1;

		protected bool m_bDocumento = false;

		private const short BANCO = 1;
		private const short AGENCIA = 2;
		private const short CONTA = 3;

		private frmFBancoExportador m_formFBancoExportador = null;
		private frmFBancoExportadorCadEdit m_formFBancoExportadorCadEdit = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos m_typDatSetTbExportadoresBancos;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias m_typDatSetTbExportadoresBancosAgencias;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas m_typDatSetTbExportadoresBancosAgenciasContas;
		protected mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros m_typDatSetTbEstadosBrasileiros;
		#endregion

		#region Construtores & Destrutores
		public clsBancoExportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region InitializeEventsFormBancoExportador
		private void InitializeEventsFormBancoExportador()
		{
			try 
			{
				// Habilitar Botão Anular Seleção
				m_formFBancoExportador.eCallHabilitaBotaoAnularSelecao += new frmFBancoExportador.delCallHabilitaBotaoAnularSelecao(habilitaBotaoAnularSelecao);

				// Carrega Dados BD
				m_formFBancoExportador.eCallCarregaDadosBD += new frmFBancoExportador.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFBancoExportador.eCallCarregaDadosInterface += new frmFBancoExportador.delCallCarregaDadosInterface(carregaDadosInterface);

				// Carrega Dados Interface Agência
				m_formFBancoExportador.eCallCarregaDadosInterfaceAgencia += new frmFBancoExportador.delCallCarregaDadosInterfaceAgencia(carregaDadosInterfaceAgencia);

				// Carrega Dados Interface Conta
				m_formFBancoExportador.eCallCarregaDadosInterfaceConta += new frmFBancoExportador.delCallCarregaDadosInterfaceConta(carregaDadosInterfaceContas);

				// Carrega Dados Interface Informacoes
				m_formFBancoExportador.eCallCarregaDadosInterfaceInformacoes += new frmFBancoExportador.delCallCarregaDadosInterfaceInformacoes(carregaDadosInterfaceInformacoes);

				// Carrega Dados BD Banco
				m_formFBancoExportador.eCallCarregaDadosBDBancos += new frmFBancoExportador.delCallCarregaDadosBDBancos(carregaDadosBDBanco);

				// Carrega Dados BD Bancos Selecionado
				m_formFBancoExportador.eCallCarregaDadosBancoSelecionado += new frmFBancoExportador.delCallCarregaDadosBancoSelecionado(carregaDadosBanco);

				// Anular Seleção
				m_formFBancoExportador.eCallAnularSelecao += new frmFBancoExportador.delCallAnularSelecao(anularSelecao);

				// Carrega Dados BD Agência
				m_formFBancoExportador.eCallCarregaDadosBDAgencias += new frmFBancoExportador.delCallCarregaDadosBDAgencias(carregaDadosBDAgencias);

				// Carrega Dados BD Agência Selecionada
				m_formFBancoExportador.eCallCarregaDadosAgenciaSelecionada += new frmFBancoExportador.delCallCarregaDadosAgenciaSelecionada(carregaDadosAgencia);

				// Carrega Dados BD Conta
				m_formFBancoExportador.eCallCarregaDadosBDContas += new frmFBancoExportador.delCallCarregaDadosBDContas(carregaDadosBDContas);

				// Carrega Dados BD Conta Selecionada
				m_formFBancoExportador.eCallCarregaDadosContaSelecionada += new frmFBancoExportador.delCallCarregaDadosContaSelecionada(carredaDadosContas);

				// Salva Dados Interface
				m_formFBancoExportador.eCallSalvaDadosInterface += new frmFBancoExportador.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				m_formFBancoExportador.eCallSalvaDadosBD += new frmFBancoExportador.delCallSalvaDadosBD(salvaDadosBD);

				// Editar Banco
				m_formFBancoExportador.eCallEditaBanco += new frmFBancoExportador.delCallEditaBanco(editaBanco);

				// Cadastra Banco
				m_formFBancoExportador.eCallCadastraBanco += new frmFBancoExportador.delCallCadastraBanco(cadastraBanco);

				// Remove Banco
				m_formFBancoExportador.eCallRemoveBanco += new frmFBancoExportador.delCallRemoveBanco(removeBanco);

				// Remove Agência
				m_formFBancoExportador.eCallRemoveAgencia += new frmFBancoExportador.delCallRemoveAgencia(removeAgencia);

				// Remove Conta
				m_formFBancoExportador.eCallRemoveConta += new frmFBancoExportador.delCallRemoveConta(removeConta);
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
				m_formFBancoExportador = new frmFBancoExportador(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormBancoExportador();
				m_formFBancoExportador.ShowDialog();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region InitializeEventsFormBancoExportadorCadEdit
		private void InitializeEventsFormBancoExportadorCadEdit()
		{
			// Carrega BD
			m_formFBancoExportadorCadEdit.eCallCarregaDadosBD += new frmFBancoExportadorCadEdit.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFBancoExportadorCadEdit.eCallCarregaDadosInterface += new frmFBancoExportadorCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceEdicao);

			// Carrega Dados Interface Cadastro
			m_formFBancoExportadorCadEdit.eCallCarregaDadosInterfaceCadastro += new frmFBancoExportadorCadEdit.delCallCarregaDadosInterfaceCadastro(carregaDadosInterfaceCadastro);

			// Carrega Dados Interface ComboBox Agencia
			m_formFBancoExportadorCadEdit.eCallCarregaDadosInterfaceComboBoxAgencias += new frmFBancoExportadorCadEdit.delCallCarregaDadosInterfaceComboBoxAgencias(carregaDadosInterfaceComboBoxAgencia);

			// Carrega Dados Interface ComboBox Conta
			m_formFBancoExportadorCadEdit.eCallCarregaDadosInterfaceComboBoxContas += new frmFBancoExportadorCadEdit.delCallCarregaDadosInterfaceComboBoxContas(carregaDadosInterfaceComboBoxContas);

			// Salva Dados Interface
			m_formFBancoExportadorCadEdit.eCallSalvaDadosInterface += new frmFBancoExportadorCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceCadEditEdicao);

			// Salva Dados Interface Cadastro
			m_formFBancoExportadorCadEdit.eCallSalvaDadosInterfaceCadastro += new frmFBancoExportadorCadEdit.delCallSalvaDadosInterfaceCadastro(salvaDadosInterfaceCadEditNovo);

			// Salva Dados BD Cadastro
			m_formFBancoExportadorCadEdit.eCallSalvaDadosBDCadastro += new frmFBancoExportadorCadEdit.delCallSalvaDadosBDCadastro(salvaDadosBDCadastro);
		}
		#endregion

		#region Remove Banco
		protected void removeBanco(ref mdlComponentesGraficos.ListView lvBancos)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;
			int nIdBanco = 0;
			if (lvBancos.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Bancos",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_ApagarBancos).Replace("TAG",lvBancos.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvBancos.SelectedItems.Count.ToString() + " banco(s)?","Bancos",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvBancos.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
					dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,nIdBanco);
                    dtrwRowTbExportadoresBancos.Delete();
					for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows.Count; nCount++)
					{
						dtrwRowTbExportadoresBancosAgencias = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow)m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows[nCount];
						if (dtrwRowTbExportadoresBancosAgencias.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwRowTbExportadoresBancosAgencias.nIdBanco == m_nIdBanco)
							{
								m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows.Remove(dtrwRowTbExportadoresBancosAgencias);
							}
						}
					}
					for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Count; nCount++)
					{
						dtrwRowTbExportadoresBancosAgenciasContas = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow)m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows[nCount];
						if (dtrwRowTbExportadoresBancosAgenciasContas.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco == m_nIdBanco)
								m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Remove(dtrwRowTbExportadoresBancosAgenciasContas);
						}
					}
					lvBancos.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strBanco = "";
					m_strEndereco = "";
					m_strInstrucoesPagamento = "";
					m_strCidade = "";					
					m_strEstado = "";
					m_strObs = "";
					m_strIdAgencia = "";
					m_strIdConta = "";
				}
			}
		}
		#endregion
		#region Remove Agencia
		protected void removeAgencia(ref mdlComponentesGraficos.ListView lvAgencias)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;
			string strIdAgencia = "";
			if (lvAgencias.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Bancos",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_ApagarAgencias).Replace("TAG",lvAgencias.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvAgencias.SelectedItems.Count.ToString() + " agência(s)?","Bancos",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvAgencias.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					strIdAgencia = lvAgencias.SelectedItems[0].Text;
					dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,strIdAgencia);
					dtrwRowTbExportadoresBancosAgencias.Delete();
					for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Count; nCount++)
					{
						dtrwRowTbExportadoresBancosAgenciasContas = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow)m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows[nCount];
						if (dtrwRowTbExportadoresBancosAgenciasContas.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco == m_nIdBanco && dtrwRowTbExportadoresBancosAgenciasContas.strAgencia == strIdAgencia)
							{
								m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Remove(dtrwRowTbExportadoresBancosAgenciasContas);
							}
						}
					}
					lvAgencias.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strEndereco = "";
					m_strInstrucoesPagamento = "";
					m_strCidade = "";					
					m_strEstado = "";
					m_strObs = "";
					m_strIdAgencia = "";
					m_strIdConta = "";
				}
			}
		}
		#endregion
		#region Remove Conta
		protected void removeConta(ref mdlComponentesGraficos.ListView lvContas)
		{
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;
			string strIdConta = "";
			if (lvContas.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Bancos",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_ApagarContas).Replace("TAG",lvContas.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvContas.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					strIdConta = lvContas.SelectedItems[0].Text;
					dtrwRowTbExportadoresBancosAgenciasContas = m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.FindBynIdExportadornIdBancostrAgenciastrConta(m_nIdExportador,m_nIdBanco,m_strIdAgencia,strIdConta);
					if (dtrwRowTbExportadoresBancosAgenciasContas.RowState != System.Data.DataRowState.Deleted)
						dtrwRowTbExportadoresBancosAgenciasContas.Delete();
					lvContas.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					m_strIdConta = "";
				}
			}
		}
		#endregion

		#region Edita Banco
		protected void editaBanco()
		{
			try
			{
				m_formFBancoExportadorCadEdit = new frmFBancoExportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFBancoExportador);
				InitializeEventsFormBancoExportadorCadEdit();
				m_formFBancoExportadorCadEdit.setTextoGroupBox("Edição");
				m_formFBancoExportadorCadEdit.ShowDialog();
				m_formFBancoExportadorCadEdit.Dispose();
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
				m_formFBancoExportadorCadEdit = new frmFBancoExportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel,ref m_formFBancoExportador,true);
				InitializeEventsFormBancoExportadorCadEdit();
				m_formFBancoExportadorCadEdit.setTextoGroupBox("Cadastro");
				m_formFBancoExportadorCadEdit.ShowDialog();
				m_formFBancoExportadorCadEdit.Dispose();
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
			protected void carregaTypDatSet()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbExportadoresBancos = m_cls_dba_ConnectionBD.GetTbExportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbExportadoresBancosAgencias = m_cls_dba_ConnectionBD.GetTbExportadoresBancosAgencias(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbExportadoresBancosAgenciasContas = m_cls_dba_ConnectionBD.GetTbExportadoresBancosAgenciasContas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlOrdenacaoCampo.Add("strNome");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbEstadosBrasileiros = m_cls_dba_ConnectionBD.GetTbEstadosBrasileiros(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			}
			protected void carregaDadosBD()
			{
				try 
				{
					carregaBDEspecificos();
					carregaBDExportadorDadosDaConta();
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaBDExportadorDadosDaConta()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
					
					dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco);
					dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,m_strIdAgencia);
								
					if (dtrwRowTbExportadoresBancos != null)
					{
						m_strBanco = (dtrwRowTbExportadoresBancos.IsstrNomeNull() ? "" : dtrwRowTbExportadoresBancos.strNome);
						if (dtrwRowTbExportadoresBancosAgencias != null)
						{
							m_strEndereco = (dtrwRowTbExportadoresBancosAgencias.IsstrEnderecoNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strEndereco);
							m_strBairro = (dtrwRowTbExportadoresBancosAgencias.IsstrBairroNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strBairro);
							m_strCidade = (dtrwRowTbExportadoresBancosAgencias.IsstrCidadeNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strCidade);
							m_strTelefone = (dtrwRowTbExportadoresBancosAgencias.IsstrTelefoneNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strTelefone);
							m_strFax = (dtrwRowTbExportadoresBancosAgencias.IsstrFaxNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strFax);
							mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros. tbEstadosBrasileirosRow dtrwTbEstadosBrasileiros = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado((dtrwRowTbExportadoresBancosAgencias.IsnIdEstadoNull() ? -1 : dtrwRowTbExportadoresBancosAgencias.nIdEstado));
							if (dtrwTbEstadosBrasileiros != null)
							{
								m_strEstado = (dtrwTbEstadosBrasileiros.IsstrNomeNull() ? "" : dtrwTbEstadosBrasileiros.strNome);
								m_strEstadoSigla = (dtrwTbEstadosBrasileiros.IsstrSiglaNull() ? "" : dtrwTbEstadosBrasileiros.strSigla);
							}
							else
							{
								m_strEstado = "";
								m_strEstadoSigla = "";
							}
							m_strCEP = (dtrwRowTbExportadoresBancosAgencias.IsstrCepNull() ? "" : dtrwRowTbExportadoresBancosAgencias.strCep);
							m_strObs = (dtrwRowTbExportadoresBancosAgencias.IsmstrObservacoesNull() ? "" : dtrwRowTbExportadoresBancosAgencias.mstrObservacoes);
							m_strInstrucoesPagamento = (dtrwRowTbExportadoresBancosAgencias.IsmstrSwiftNull() ? "" : dtrwRowTbExportadoresBancosAgencias.mstrSwift);
						}
					}
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected abstract void carregaBDEspecificos();
			protected void anularSelecao(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas)
			{
				try
				{
					System.Collections.ArrayList arlSelecionados = new System.Collections.ArrayList();
					foreach (System.Windows.Forms.ListViewItem lvItemBanco in lvBancos.SelectedItems)
					{
						arlSelecionados.Add(lvItemBanco);
					}
					foreach(System.Windows.Forms.ListViewItem lvItemAgencia in lvAgencias.SelectedItems)
					{
						arlSelecionados.Add(lvItemAgencia);
					}
					foreach(System.Windows.Forms.ListViewItem lvItemConta in lvContas.SelectedItems)
					{
						arlSelecionados.Add(lvItemConta);
					}
					foreach(System.Windows.Forms.ListViewItem lvItemTodos in arlSelecionados)
					{
						lvItemTodos.Selected = false;
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
			protected void habilitaBotaoAnularSelecao(ref System.Windows.Forms.Button btAnular)
			{
				btAnular.Visible = m_bDocumento;
			}
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas, ref System.Windows.Forms.RichTextBox rtbInformacoes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo)
			{
				try
				{
					#region Carrega Bancos
					carregaDadosInterfaceBancos(ref lvBancos);
					#endregion					
					#region Verifica se há só um Banco!
					if ((m_nRowsBancos == 1 || lvBancos.SelectedItems.Count == 1) && lvBancos.SelectedItems.Count != 0)
					{
						carregaDadosInterfaceAgencia(ref lvAgencias);
					#endregion
					#region Verifica se há só uma Agência!
						carregaDadosInterfaceContas(ref lvAgencias, ref lvContas);	
					}
					else if (lvBancos.SelectedItems.Count == 0)
					{
						lvAgencias.Items.Clear();
						lvContas.Items.Clear();
					}
					#endregion
					#region Habilita/Desabilita Botões Editar e Excluir
					if (lvBancos.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
						if (m_bMostrarBaloes)
						{
							m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
							m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlBancos_clsBancoExportador_NovoBancoExportador.ToString());
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
					#endregion
					carregaDadosInterfaceInformacoes(ref rtbInformacoes);
				}
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosInterfaceInformacoes(ref System.Windows.Forms.RichTextBox rtbInformacoes)
			{
				string strText = "";
				rtbInformacoes.Clear();
				rtbInformacoes.SelectionColor = System.Drawing.Color.Black;
				strText = strText + m_strBanco + System.Environment.NewLine;
				strText = strText + m_strIdAgencia + System.Environment.NewLine;
				strText = strText + m_strIdConta + System.Environment.NewLine;
				strText = strText + m_strInstrucoesPagamento + System.Environment.NewLine;
				rtbInformacoes.Text = strText;
			}
			protected void carregaDadosInterfaceEdicao(ref mdlComponentesGraficos.TextBox tbBanco,ref mdlComponentesGraficos.TextBox tbAgencia,ref mdlComponentesGraficos.TextBox tbConta,ref mdlComponentesGraficos.TextBox tbEndereco,ref mdlComponentesGraficos.TextBox tbBairro,ref mdlComponentesGraficos.TextBox tbCidade,ref mdlComponentesGraficos.ComboBox cbEstado,ref mdlComponentesGraficos.TextBox tbCEP,ref System.Windows.Forms.TextBox tbInstrucoes,ref System.Windows.Forms.TextBox tbObs,ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
			{
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwRowTbEstadosBrasileiros;
								
				tbBanco.Text = m_strBanco;
				tbAgencia.Text = m_strIdAgencia;
                tbConta.Text = m_strIdConta;
                tbEndereco.Text = m_strEndereco;
				tbBairro.Text = m_strBairro;
				tbCidade.Text = m_strCidade;
				tbTelefone.Text = m_strTelefone;
				tbFax.Text = m_strFax;
				for (int nCount = 0; nCount < m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows.Count; nCount++)
				{
					dtrwRowTbEstadosBrasileiros = (mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow)m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows[nCount];
					cbEstado.AddItem(dtrwRowTbEstadosBrasileiros.strSigla,dtrwRowTbEstadosBrasileiros.nIdEstado);
					if (dtrwRowTbEstadosBrasileiros.nIdEstado == m_nIdEstado)
					{
						cbEstado.SelectedIndex = nCount;
						m_strEstado = dtrwRowTbEstadosBrasileiros.strNome;
						m_strEstadoSigla = dtrwRowTbEstadosBrasileiros.strSigla;
					}
				}
				tbCEP.Text = m_strCEP;
				tbInstrucoes.Text = m_strInstrucoesPagamento;
				tbObs.Text = m_strObs;
			}
			protected void carregaDadosInterfaceCadastro(ref mdlComponentesGraficos.ComboBox cbBancos,ref mdlComponentesGraficos.ComboBox cbEstados)
			{
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwRowTbEstadosBrasileiros;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
							
				for (int nCount = 0; nCount < m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows.Count; nCount++)
				{
					dtrwRowTbEstadosBrasileiros = (mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow)m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.Rows[nCount];
					cbEstados.AddItem(dtrwRowTbEstadosBrasileiros.strSigla,dtrwRowTbEstadosBrasileiros.nIdEstado);
				}
				for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancos.tbExportadoresBancos.Rows.Count; nCount++)
				{
					dtrwRowTbExportadoresBancos = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow)m_typDatSetTbExportadoresBancos.tbExportadoresBancos.Rows[nCount];
					if (dtrwRowTbExportadoresBancos.RowState != System.Data.DataRowState.Deleted)
						cbBancos.AddItem(dtrwRowTbExportadoresBancos.strNome,dtrwRowTbExportadoresBancos.nIdBanco);
				}
			}
			#endregion
		#endregion
		#region Salvamento dos Dados
			#region Interface
			protected void salvaDadosInterface(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas)
			{
				#region Bancos
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
					mdlMensagens.clsMensagens.ShowInformation("Bancos do Exportador", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_MaisDeUmBancoSelecionado).Replace("\\n","\n").Replace("TAG",lvBancos.SelectedItems[0].Text));
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de um banco!\nO banco selecionado será: " + lvBancos.SelectedItems[0].Text,"Bancos do Exportador");
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
				}
				#endregion
				#region Agencias
				if (lvAgencias.Items.Count == 0 || lvAgencias.SelectedItems.Count == 0)
				{
					m_strIdAgencia = "";
					m_strInstrucoesPagamento = "";
				} 
				else if (lvAgencias.Items.Count > 0 && lvAgencias.SelectedItems.Count == 1)
				{
					m_strIdAgencia = lvAgencias.SelectedItems[0].Text;
				} 
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Bancos do Exportador", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_MaisDeUmaAgenciaSelecionada).Replace("\\n","\n").Replace("TAG",lvAgencias.SelectedItems[0].Text));
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de uma agência!\nA agência selecionada será: " + lvAgencias.SelectedItems[0].Text,"Bancos do Exportador");
					m_strIdAgencia = lvBancos.SelectedItems[0].Text;
				}
				#endregion
				#region Contas
				if (lvContas.Items.Count == 0 || lvContas.SelectedItems.Count == 0)
				{
					m_strIdConta = "";
				} 
				else if (lvContas.Items.Count > 0 && lvContas.SelectedItems.Count == 1)
				{
					m_strIdConta = lvContas.SelectedItems[0].Text;
				} 
				else
				{
					mdlMensagens.clsMensagens.ShowInformation("Bancos do Exportador", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_clsBancoExportador_MaisDeUmaContaSelecionada).Replace("\\n","\n").Replace("TAG",lvContas.SelectedItems[0].Text));
					//System.Windows.Forms.MessageBox.Show("Você selecionou mais de uma conta!\nA Conta selecionado será: " + lvContas.SelectedItems[0].Text,"Bancos do Exportador");
					m_strIdConta = lvContas.SelectedItems[0].Text;
				}
				#endregion
			}
			protected void salvaDadosInterfaceCadEditNovo(ref mdlComponentesGraficos.ComboBox cbBancos, ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.ComboBox cbContas, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoes, ref System.Windows.Forms.TextBox tbObs,ref mdlComponentesGraficos.TextBox tbTelefone,ref mdlComponentesGraficos.TextBox tbFax)
			{
				salvaDadosInterfaceBancosNovo(ref cbBancos);
				salvaDadosInterfaceAgenciasNova(ref cbAgencias,ref cbEstado,ref tbEndereco,ref tbBairro,ref tbCidade, ref tbCEP, ref tbInstrucoes,ref tbObs, ref tbTelefone, ref tbFax);
				salvaDadosInterfaceContaNova(ref cbContas);
			}
			protected void salvaDadosInterfaceCadEditEdicao(ref mdlComponentesGraficos.TextBox tbBanco, ref mdlComponentesGraficos.TextBox tbAgencia, ref mdlComponentesGraficos.TextBox tbConta, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoes, ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox tbTelefone,ref mdlComponentesGraficos.TextBox tbFax)
			{
				salvaDadosInterfaceBancoEdicao(ref tbBanco);
				salvaDadosInterfaceAgenciaEdicao(ref tbAgencia,ref tbEndereco, ref tbBairro, ref tbCidade, ref cbEstado, ref tbCEP, ref tbInstrucoes, ref tbObs, ref tbTelefone, ref tbFax);
				salvaDadosInterfaceContaEdicao(ref tbConta);
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				if (m_typDatSetTbExportadoresBancos != null)
					m_cls_dba_ConnectionBD.SetTbExportadoresBancos(m_typDatSetTbExportadoresBancos);
				if (m_typDatSetTbExportadoresBancosAgencias != null)
					m_cls_dba_ConnectionBD.SetTbExportadoresBancosAgencias(m_typDatSetTbExportadoresBancosAgencias);
				if (m_typDatSetTbExportadoresBancosAgenciasContas != null)
					m_cls_dba_ConnectionBD.SetTbExportadoresBancosAgenciasContas(m_typDatSetTbExportadoresBancosAgenciasContas);
			}
			protected abstract void salvaDadosBDEspecifico();
			#endregion
		#endregion

		#region Carregamento de Dados Bancos
			#region Banco de Dados
			protected void carregaDadosBDBanco()
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
				dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco);
				if (dtrwRowTbExportadoresBancos != null )
					m_strBanco = dtrwRowTbExportadoresBancos.strNome;
				carregaDadosBDAgencias();
			}
			protected void carregaDadosBanco(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas)
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;

				if (lvBancos.SelectedItems.Count > 0)
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
				else
					m_nIdBanco = -1;

				dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco);
				
				if (dtrwRowTbExportadoresBancos != null )
				{
					m_strBanco = dtrwRowTbExportadoresBancos.strNome;
					if (!dtrwRowTbExportadoresBancos.IsstrUltimaAgenciaNull())
                        m_strIdAgencia = dtrwRowTbExportadoresBancos.strUltimaAgencia;
				}

				m_strIdConta = "";
				m_strIdAgencia = "";
				m_strBairro = "";
				m_strCEP = "";
				m_strCidade = "";
				m_strEndereco = "";
				m_strEstado = "";
				m_strEstadoSigla = "";
				m_strInstrucoesPagamento = "";
				m_strObs = "";

				lvAgencias.Items.Clear();
				lvContas.Items.Clear();

				//carregaDadosAgencia(ref lvBancos, ref lvAgencias,ref lvContas);
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceBancos(ref mdlComponentesGraficos.ListView lvBancos)
			{
				#region Variáveis
				// List View Item
				System.Windows.Forms.ListViewItem lvItemBanco;

				// Limpa os Items da List View
				lvBancos.Items.Clear();

				// DataRows
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
				#endregion

				#region Preenche os itens da List View
				m_nRowsBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.Rows.Count;
				for (int nCont = 0 ; nCont < m_nRowsBancos ; nCont++)
				{
					dtrwRowTbExportadoresBancos = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow)m_typDatSetTbExportadoresBancos.tbExportadoresBancos.Rows[nCont];
					if (dtrwRowTbExportadoresBancos.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemBanco = lvBancos.Items.Add(dtrwRowTbExportadoresBancos.strNome);
						lvItemBanco.Tag = dtrwRowTbExportadoresBancos.nIdBanco;
						if ((int)lvItemBanco.Tag == m_nIdBanco/* || m_typDatSetTbExportadoresBancos.tbExportadoresBancos.Rows.Count == 1*/)
						{
							lvItemBanco.Selected = true;
							m_nIdBanco = (int)lvItemBanco.Tag;
							m_strBanco = dtrwRowTbExportadoresBancos.strNome;
						}
					}
				}
				#endregion
			}
			#endregion
		#endregion
		#region Salvamento de Dados Bancos
			#region Interface
			protected void salvaDadosInterfaceBancosNovo(ref mdlComponentesGraficos.ComboBox cbBancos)
			{
				Object retornoComboBox = cbBancos.ReturnObjectSelectedItem();

				if (retornoComboBox != null)
					m_nIdBanco = Int32.Parse(retornoComboBox.ToString());
				else
					m_nIdBanco = -1;
				m_strBanco = cbBancos.Text;
			}
			protected void salvaDadosInterfaceBancoEdicao(ref mdlComponentesGraficos.TextBox tbBanco)
			{
				m_strBanco = tbBanco.Text;
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDCadastro(bool bcadastraNovo)
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwRowTbExportadoresBancos;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;

				int nIdBanco = 0;
				bool bBancoNovo = false;
				bool bAgenciaNova = false;
				bool bContaNova = false;
				if (bcadastraNovo == false)
				{
					nIdBanco = m_nIdBanco;
					dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco);
					dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,m_strIdAgencia);
					dtrwRowTbExportadoresBancosAgenciasContas = m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.FindBynIdExportadornIdBancostrAgenciastrConta(m_nIdExportador,m_nIdBanco,m_strIdAgencia,m_strIdConta);
					m_strIdAgencia = m_strNovoIdAgencia;
					m_strIdConta = m_strNovoIdConta;
				} 
				else
				{
					#region Bancos
					if (m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco) == null)
					{
						bBancoNovo = true;
						while (m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,nIdBanco) != null)
							nIdBanco++;

						m_nIdBanco = nIdBanco;

						dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.NewtbExportadoresBancosRow();
						dtrwRowTbExportadoresBancos.nIdBanco = m_nIdBanco;
						dtrwRowTbExportadoresBancos.nIdExportador = m_nIdExportador;
					} 
					else
					{
						dtrwRowTbExportadoresBancos = m_typDatSetTbExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,m_nIdBanco);
					}
					#endregion
					#region Agencias
					if (m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,m_strIdAgencia) == null)
					{
						bAgenciaNova = true;
						dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.NewtbExportadoresBancosAgenciasRow();
						dtrwRowTbExportadoresBancosAgencias.nIdBanco = m_nIdBanco;
						dtrwRowTbExportadoresBancosAgencias.nIdExportador = m_nIdExportador;
					} 
					else
					{
						dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,m_strIdAgencia);
					}
					#endregion
					#region Contas
					if (m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.FindBynIdExportadornIdBancostrAgenciastrConta(m_nIdExportador,m_nIdBanco,m_strIdAgencia,m_strIdConta) == null)
					{
						bContaNova = true;
						dtrwRowTbExportadoresBancosAgenciasContas = m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.NewtbExportadoresBancosAgenciasContasRow();
						dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco = m_nIdBanco;
						dtrwRowTbExportadoresBancosAgenciasContas.nIdExportador = m_nIdExportador;
					}
					else
					{
						dtrwRowTbExportadoresBancosAgenciasContas = m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.NewtbExportadoresBancosAgenciasContasRow();
					}
					#endregion
				}
				#region Salvando os dados do Banco
				dtrwRowTbExportadoresBancos.strNome = m_strBanco;
				if (bBancoNovo == true)
					m_typDatSetTbExportadoresBancos.tbExportadoresBancos.AddtbExportadoresBancosRow(dtrwRowTbExportadoresBancos);
				m_cls_dba_ConnectionBD.SetTbExportadoresBancos(m_typDatSetTbExportadoresBancos);
				#endregion
				#region Salvando os dados da agência
				dtrwRowTbExportadoresBancosAgencias.strAgencia = m_strIdAgencia;
				dtrwRowTbExportadoresBancosAgencias.strEndereco = m_strEndereco;
				dtrwRowTbExportadoresBancosAgencias.strBairro = m_strBairro;
				dtrwRowTbExportadoresBancosAgencias.strCidade = m_strCidade;
				dtrwRowTbExportadoresBancosAgencias.strTelefone = m_strTelefone;
				dtrwRowTbExportadoresBancosAgencias.strFax = m_strFax;
				dtrwRowTbExportadoresBancosAgencias.nIdEstado = m_nIdEstado;
				dtrwRowTbExportadoresBancosAgencias.strCep = m_strCEP;
				dtrwRowTbExportadoresBancosAgencias.mstrSwift = m_strInstrucoesPagamento;
				dtrwRowTbExportadoresBancosAgencias.mstrObservacoes = m_strObs;
				if (bAgenciaNova == true)
					m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.AddtbExportadoresBancosAgenciasRow(dtrwRowTbExportadoresBancosAgencias);
				m_cls_dba_ConnectionBD.SetTbExportadoresBancosAgencias(m_typDatSetTbExportadoresBancosAgencias);
				#endregion
				#region Salvando os dados da conta
				dtrwRowTbExportadoresBancosAgenciasContas.strConta = m_strIdConta;
				dtrwRowTbExportadoresBancosAgenciasContas.strAgencia = m_strIdAgencia;
				if (bContaNova == true)
					m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.AddtbExportadoresBancosAgenciasContasRow(dtrwRowTbExportadoresBancosAgenciasContas);
				m_cls_dba_ConnectionBD.SetTbExportadoresBancosAgenciasContas(m_typDatSetTbExportadoresBancosAgenciasContas);
				#endregion
			}
			#endregion
		#endregion

		#region Carregamento de Dados Agencias
			#region Banco de Dados
			protected void carregaDadosBDAgencias()
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgenciasRow;
				dtrwRowTbExportadoresBancosAgenciasRow = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,m_strIdAgencia);
				if (dtrwRowTbExportadoresBancosAgenciasRow != null)
				{
					m_strEndereco = dtrwRowTbExportadoresBancosAgenciasRow.strEndereco;
					m_strBairro = dtrwRowTbExportadoresBancosAgenciasRow.strBairro;
					m_strCidade = dtrwRowTbExportadoresBancosAgenciasRow.strCidade;
					m_strTelefone = dtrwRowTbExportadoresBancosAgenciasRow.strTelefone;
					m_strFax = dtrwRowTbExportadoresBancosAgenciasRow.strFax;
					m_nIdEstado = dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado;
					m_strEstado = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(m_nIdEstado).strNome;
					m_strEstadoSigla = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(m_nIdEstado).strSigla;
					m_strCEP = dtrwRowTbExportadoresBancosAgenciasRow.strCep;
					m_strObs = dtrwRowTbExportadoresBancosAgenciasRow.mstrObservacoes;
					m_strInstrucoesPagamento = dtrwRowTbExportadoresBancosAgenciasRow.mstrSwift;
				}
				//carregaDadosBDContas();
			}
			protected void carregaDadosAgencia(ref mdlComponentesGraficos.ListView lvBancos, ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas)
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgenciasRow;
				string strAgencia = "";

				if ((lvBancos.SelectedItems.Count > 0) && (lvAgencias.SelectedItems.Count > 0))
				{
					m_nIdBanco = Int32.Parse(lvBancos.SelectedItems[0].Tag.ToString());
					strAgencia = lvAgencias.SelectedItems[0].Text;
				}
				else
				{
					m_nIdBanco = -1;
					strAgencia = "";
					m_strInstrucoesPagamento = "";
					m_strEndereco = "";
					m_strBairro = "";
					m_strCidade = "";
					m_strTelefone = "";
					m_strFax = "";
					m_strEstado = "";
					m_strEstadoSigla = "";
					m_nIdEstado = -1;
					m_strCEP = "";
					m_strObs = "";
				}
				
				dtrwRowTbExportadoresBancosAgenciasRow = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,m_nIdBanco,strAgencia);

				if (dtrwRowTbExportadoresBancosAgenciasRow != null)
				{
					m_strIdAgencia = dtrwRowTbExportadoresBancosAgenciasRow.strAgencia;
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrEnderecoNull())
						m_strEndereco = dtrwRowTbExportadoresBancosAgenciasRow.strEndereco;
					else
						m_strEndereco = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrBairroNull())
						m_strBairro = dtrwRowTbExportadoresBancosAgenciasRow.strBairro;
					else
						m_strBairro = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrCidadeNull())
						m_strCidade = dtrwRowTbExportadoresBancosAgenciasRow.strCidade;
					else
						m_strCidade = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrTelefoneNull())
						m_strTelefone = dtrwRowTbExportadoresBancosAgenciasRow.strTelefone;
					else
						m_strTelefone = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrFaxNull())
						m_strFax = dtrwRowTbExportadoresBancosAgenciasRow.strFax;
					else
						m_strFax = "";
					if (dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado >= 0 && dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado <= 26)
					{
						m_strEstado = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado).strNome;
						m_strEstadoSigla = m_typDatSetTbEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado).strSigla;
						m_nIdEstado = dtrwRowTbExportadoresBancosAgenciasRow.nIdEstado;
					}
					else
					{
						m_strEstado = "";
						m_strEstadoSigla = "";
						m_nIdEstado = -1;
					}
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsstrCepNull())
						m_strCEP = dtrwRowTbExportadoresBancosAgenciasRow.strCep;
					else
						m_strCEP = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsmstrObservacoesNull())
						m_strObs = dtrwRowTbExportadoresBancosAgenciasRow.mstrObservacoes;
					else
						m_strObs = "";
					if (!dtrwRowTbExportadoresBancosAgenciasRow.IsmstrSwiftNull())
						m_strInstrucoesPagamento = dtrwRowTbExportadoresBancosAgenciasRow.mstrSwift;
					else
						m_strInstrucoesPagamento = "";
				}
				m_strIdConta = "";
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceAgencia(ref mdlComponentesGraficos.ListView lvAgencias)
			{
				#region Variáveis
				string strEnderecoTemp = "";
				string strBairroTemp = "";
				string mstrCidadeTemp = "";
				string strTelefoneTemp = "";
				string strFaxTemp = "";
				int nIdEstado = -1;
				string strCEPTemp = "";
				string strIntrucoesTemp = "";
				string strObsTemp = "";
				// List View Item
				System.Windows.Forms.ListViewItem lvItemAgencia;

				// Limpa os Items da List View
				lvAgencias.Items.Clear();

				// DataRows
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;

				m_nRowsAgencias = 0;
				#endregion
				
				#region Adiciona Items a ListView
				for (int nCont = 0 ; nCont < m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows.Count ; nCont++)
				{
					dtrwRowTbExportadoresBancosAgencias = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow)m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows[nCont];
					if (dtrwRowTbExportadoresBancosAgencias.RowState != System.Data.DataRowState.Deleted)
					{
						if (dtrwRowTbExportadoresBancosAgencias.nIdBanco == m_nIdBanco)
						{
							m_nRowsAgencias++;
							lvItemAgencia = lvAgencias.Items.Add(dtrwRowTbExportadoresBancosAgencias.strAgencia);
							lvItemAgencia.Tag = dtrwRowTbExportadoresBancosAgencias.nIdBanco;
							if (lvItemAgencia.Text == m_strIdAgencia/* || m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows.Count == 1*/)
							{
								lvItemAgencia.Selected = true;
							}
							strEnderecoTemp = dtrwRowTbExportadoresBancosAgencias.strEndereco;
							strBairroTemp = dtrwRowTbExportadoresBancosAgencias.strBairro;
							mstrCidadeTemp = dtrwRowTbExportadoresBancosAgencias.strCidade;
							strCEPTemp = dtrwRowTbExportadoresBancosAgencias.strCep;
							strObsTemp = dtrwRowTbExportadoresBancosAgencias.mstrObservacoes;
							strIntrucoesTemp = dtrwRowTbExportadoresBancosAgencias.mstrSwift;
							nIdEstado = dtrwRowTbExportadoresBancosAgencias.nIdEstado;
							strTelefoneTemp = dtrwRowTbExportadoresBancosAgencias.strTelefone;
							strFaxTemp = dtrwRowTbExportadoresBancosAgencias.strFax;
						}
					}
				}
				if (lvAgencias.Items.Count == 1)
				{
					lvAgencias.Items[0].Selected = true;
					m_strIdAgencia = lvAgencias.Items[0].Text;
					m_strInstrucoesPagamento = strIntrucoesTemp;
				}
				m_strEndereco = strEnderecoTemp;
				m_strBairro = strBairroTemp;
				m_strCidade = mstrCidadeTemp;
				m_strCEP = strCEPTemp;
				m_strObs = strObsTemp;
				m_nIdEstado = nIdEstado;
				m_strTelefone = strTelefoneTemp;
				m_strFax = strFaxTemp;
				#endregion
			}
			protected void carregaDadosInterfaceComboBoxAgencia(ref mdlComponentesGraficos.ComboBox cbBancos, ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoesPagamento, ref System.Windows.Forms.TextBox tbObs)
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
				int nIdBanco = -1;
				Object retornoComboBox = null;
				cbAgencias.Clear();
				retornoComboBox = cbBancos.ReturnObjectSelectedItem();

				if (retornoComboBox != null)
                    nIdBanco = Int32.Parse(retornoComboBox.ToString());
				for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows.Count; nCount++)
				{
					dtrwRowTbExportadoresBancosAgencias = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow)m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.Rows[nCount];
					if (dtrwRowTbExportadoresBancosAgencias.nIdBanco == nIdBanco)
					{
						cbAgencias.AddItem(dtrwRowTbExportadoresBancosAgencias.strAgencia,dtrwRowTbExportadoresBancosAgencias.nIdBanco);
					}
				}
				#region Adiciona dados da Agência
				tbEndereco.Text = "";
				tbBairro.Text = "";
				tbCidade.Text = "";
				tbTelefone.Text = "";
				tbFax.Text = "";
				tbCEP.Text = "";
				tbInstrucoesPagamento.Text = "";
				tbObs.Text = "";
				cbEstado.SelectItem(-1);
				#endregion
			}
			#endregion
		#endregion
		#region Salvamento de Dados Agencias
		protected void salvaDadosInterfaceAgenciasNova(ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.ComboBox cbEstados, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoesPagamento, ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try 
			{
				m_strIdAgencia = cbAgencias.Text;
				m_nIdEstado = (cbEstados.ReturnObjectSelectedItem() != null ? (Int32.Parse(cbEstados.ReturnObjectSelectedItem().ToString())) : -1);
				m_strEndereco = tbEndereco.Text;
				m_strBairro = tbBairro.Text;
				m_strCidade = tbCidade.Text;
				m_strTelefone = tbTelefone.Text;
				m_strFax = tbFax.Text;
				m_strCEP = tbCEP.Text;
				m_strInstrucoesPagamento = tbInstrucoesPagamento.Text;
				m_strObs = tbObs.Text;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void salvaDadosInterfaceAgenciaEdicao(ref mdlComponentesGraficos.TextBox tbAgencia, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoes, ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try 
			{
				m_strNovoIdAgencia = tbAgencia.Text;
				m_nIdEstado = (cbEstado.ReturnObjectSelectedItem() != null ? (Int32.Parse(cbEstado.ReturnObjectSelectedItem().ToString())) : -1);
				m_strEndereco = tbEndereco.Text;
				m_strBairro = tbBairro.Text;
				m_strCidade = tbCidade.Text;
				m_strTelefone = tbTelefone.Text;
				m_strFax = tbFax.Text;
				m_strCEP = tbCEP.Text;
				m_strInstrucoesPagamento = tbInstrucoes.Text;
				m_strObs = tbObs.Text;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados Contas
			#region Banco de Dados
			protected void carregaDadosBDContas()
			{
			}
			protected void carredaDadosContas(ref mdlComponentesGraficos.ListView lvContas)
			{
				if (lvContas.SelectedItems.Count > 0)
					m_strIdConta = lvContas.SelectedItems[0].Text;
				else
					m_strIdConta = "";
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceContas(ref mdlComponentesGraficos.ListView lvAgencias, ref mdlComponentesGraficos.ListView lvContas)
			{
				#region Variáveis
				// List View Item
				System.Windows.Forms.ListViewItem lvItemConta;
					
				// Limpa os Items da List View
				lvContas.Items.Clear();

				// DataRows
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;
				#endregion

				#region Preenche Items da List View
				if (m_nRowsAgencias == 1 || lvAgencias.SelectedItems.Count == 1)
				{
					for (int nCont = 0 ; nCont < m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Count ; nCont++)
					{
						dtrwRowTbExportadoresBancosAgenciasContas = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow)m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows[nCont];
						if (dtrwRowTbExportadoresBancosAgenciasContas.RowState != System.Data.DataRowState.Deleted)
						{
							if (dtrwRowTbExportadoresBancosAgenciasContas.strAgencia == m_strIdAgencia && dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco == m_nIdBanco)
							{
								lvItemConta = lvContas.Items.Add(dtrwRowTbExportadoresBancosAgenciasContas.strConta);
								lvItemConta.Tag = dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco;
								if (lvItemConta.Text == m_strIdConta/* || m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Count == 1*/)
								{
									lvItemConta.Selected = true;
								}
							}
						}
					}
					if (lvContas.Items.Count == 1)
					{
						lvContas.Items[0].Selected = true;
						m_strIdConta = lvContas.Items[0].Text;
					}
				}
				#endregion
			}
			protected void carregaDadosInterfaceComboBoxContas(ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.ComboBox cbContas, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbCEP, ref System.Windows.Forms.TextBox tbInstrucoesPagamento, ref System.Windows.Forms.TextBox tbObs)
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow dtrwRowTbExportadoresBancosAgenciasContas;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgencias.tbExportadoresBancosAgenciasRow dtrwRowTbExportadoresBancosAgencias;
				int nIdBanco = -1;
				int nIdEstado = -1;
				string strAgencia = "";
				Object retornoComboBox = null;
				cbContas.Clear();
				retornoComboBox = cbAgencias.ReturnObjectSelectedItem();
				
				if (retornoComboBox != null)
				{
					nIdBanco = Int32.Parse(retornoComboBox.ToString());
					strAgencia = cbAgencias.Text;
					dtrwRowTbExportadoresBancosAgencias = m_typDatSetTbExportadoresBancosAgencias.tbExportadoresBancosAgencias.FindBynIdExportadornIdBancostrAgencia(m_nIdExportador,nIdBanco,strAgencia);

					for (int nCount = 0; nCount < m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows.Count; nCount++)
					{
						dtrwRowTbExportadoresBancosAgenciasContas = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContasRow)m_typDatSetTbExportadoresBancosAgenciasContas.tbExportadoresBancosAgenciasContas.Rows[nCount];
						if (dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco == nIdBanco && dtrwRowTbExportadoresBancosAgenciasContas.strAgencia == strAgencia)
						{
							cbContas.AddItem(dtrwRowTbExportadoresBancosAgenciasContas.strConta,dtrwRowTbExportadoresBancosAgenciasContas.nIdBanco);
						}
					}
					#region Adiciona dados da Agência
					tbEndereco.Text = dtrwRowTbExportadoresBancosAgencias.strEndereco;
					tbBairro.Text = dtrwRowTbExportadoresBancosAgencias.strBairro;
					tbCidade.Text = dtrwRowTbExportadoresBancosAgencias.strCidade;
					tbTelefone.Text = dtrwRowTbExportadoresBancosAgencias.strTelefone;
					tbFax.Text = dtrwRowTbExportadoresBancosAgencias.strFax;
					tbCEP.Text = dtrwRowTbExportadoresBancosAgencias.strCep;
					tbInstrucoesPagamento.Text = dtrwRowTbExportadoresBancosAgencias.mstrSwift;
					tbObs.Text = dtrwRowTbExportadoresBancosAgencias.mstrObservacoes;
					nIdEstado = dtrwRowTbExportadoresBancosAgencias.nIdEstado;
					cbEstado.SelectItem(nIdEstado);
					#endregion
				}
			}
			#endregion
		#endregion
		#region Salvamento de Dados Contas
		protected void salvaDadosInterfaceContaNova(ref mdlComponentesGraficos.ComboBox cbConta)
		{
			m_strIdConta = cbConta.Text;
		}
		protected void salvaDadosInterfaceContaEdicao(ref mdlComponentesGraficos.TextBox tbConta)
		{
			m_strNovoIdConta = tbConta.Text;
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strBanco, out string strIdAgencia, out string strIdConta)
		{
			strBanco = m_strBanco;
			strIdAgencia = m_strIdAgencia;
			strIdConta = m_strIdConta;
		}
		public void retornaValores(out string strBanco, out string strIdAgencia, out string strIdConta, out string strEndereco, out string mstrCidade, out string strEstado, out string strEstadoSigla, out string strTelefone, out string strFax)
		{
			strBanco = m_strBanco;
			strIdAgencia = m_strIdAgencia;
			strIdConta = m_strIdConta;
			strEndereco = m_strEndereco;
			mstrCidade = m_strCidade;
			strEstado = m_strEstado;
			strEstadoSigla = m_strEstadoSigla;
			strTelefone = m_strTelefone;
			strFax = m_strFax;
		}
		#endregion
	}
}
