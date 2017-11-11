using System;

namespace mdlNotaFiscal
{
	/// <summary>
	/// Summary description for clsNotaFiscal.
	/// </summary>
	public class clsNotaFiscal
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		protected string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		protected bool m_bMostrarBaloes = true;

		protected int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private string m_strNotasFiscais = "";
		private string m_strDatasNotasFiscais = "";
		private double m_dValorNotasFiscais = 0;
		private bool m_bCadastroNova = false;

		private int m_nIdNotaFiscal = -1;
		private string m_strNumeroNota = "";
		private System.DateTime m_dtEmissaoNota = System.DateTime.Now;
		private double m_dConversaoNota = 0;
		private double m_dValorNota = 0;

		private Frames.frmFNotasFiscais m_formFNotasFiscais = null;
		private Frames.frmFNotasFiscaisCadEdit m_formFNotasFiscaisCadEdit = null;

		private mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais m_typDatSetTbNotasFiscais = null, m_typDatSetTbNotasFiscaisTODAS = null;
		#endregion

		#region Construtores & Destrutores
		public clsNotaFiscal(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador, string idPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = idPE;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region InitializeEventsFormNotasFiscais
		private void InitializeEventsFormNotasFiscais()
		{
			// Carrega Dados Interface
			m_formFNotasFiscais.eCallCarregaDadosInterface += new Frames.frmFNotasFiscais.delCallCarregaDadosInterface(carregaDadosInterfaceListView);

			// Cadastra Notas
			m_formFNotasFiscais.eCallCadastraNota += new Frames.frmFNotasFiscais.delCallCadastraNota(cadastraNota);

			// Edita Notas
			m_formFNotasFiscais.eCallEditaNota += new Frames.frmFNotasFiscais.delCallEditaNota(editaNota);

			// Remove Notas
			m_formFNotasFiscais.eCallRemoveNota += new Frames.frmFNotasFiscais.delCallRemoveNota(removeNotaSelecionada);

			// Salva Dados
			m_formFNotasFiscais.eCallSalvaDadosBD += new Frames.frmFNotasFiscais.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFNotasFiscais = new mdlNotaFiscal.Frames.frmFNotasFiscais(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMostrarBaloes);
				InitializeEventsFormNotasFiscais();
				m_formFNotasFiscais.ShowDialog();
				m_formFNotasFiscais = null;
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
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
						
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbNotasFiscaisTODAS = m_cls_dba_ConnectionBD.GetTbNotasFiscais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				arlOrdenacaoCampo.Add("strNumero");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbNotasFiscais = m_cls_dba_ConnectionBD.GetTbNotasFiscais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				m_dValorNotasFiscais = 0;
				m_strNotasFiscais = "";
				m_strDatasNotasFiscais = "";
				mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais = null;
				for (int nCount = 0; nCount < m_typDatSetTbNotasFiscais.tbNotasFiscais.Rows.Count; nCount++)
				{
					dtrwTbNotasFiscais = (mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow)m_typDatSetTbNotasFiscais.tbNotasFiscais.Rows[nCount];
					m_dValorNotasFiscais += (dtrwTbNotasFiscais.IsdValorNull() ? 0 : dtrwTbNotasFiscais.dValor);
					m_strDatasNotasFiscais += (dtrwTbNotasFiscais.IsdtEmissaoNull() ? "?, " : dtrwTbNotasFiscais.dtEmissao.ToString("dd/MM/yyyy") + ", ");
					m_strNotasFiscais += (dtrwTbNotasFiscais.IsstrNumeroNull() ? "?, " : dtrwTbNotasFiscais.strNumero + ", ");
				}
				if (m_strDatasNotasFiscais.Length > 2)
					m_strDatasNotasFiscais = m_strDatasNotasFiscais.Remove(m_strDatasNotasFiscais.Length - 2, 2);
				if (m_strNotasFiscais.Length > 2)
					m_strNotasFiscais = m_strNotasFiscais.Remove(m_strNotasFiscais.Length - 2, 2);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		private void carregaDadosInterfaceListView(ref mdlComponentesGraficos.ListView lvNotas, ref mdlComponentesGraficos.Button btEditar, ref mdlComponentesGraficos.Button btExclui, ref mdlComponentesGraficos.Button btNovo, ref System.Windows.Forms.Label lMoedaNotas)
		{
			try
			{
				lvNotas.Items.Clear();
				m_dValorNotasFiscais = 0;
				m_strDatasNotasFiscais = "";
				m_strNotasFiscais = "";
				System.Windows.Forms.ListViewItem lvItemNota = null;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais in m_typDatSetTbNotasFiscais.tbNotasFiscais.Rows)
				{
					if (dtrwTbNotasFiscais.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemNota = lvNotas.Items.Add((dtrwTbNotasFiscais.IsstrNumeroNull() ? "?" : dtrwTbNotasFiscais.strNumero));
						lvItemNota.Tag = dtrwTbNotasFiscais.nNotaFiscal;
						lvItemNota.SubItems.Add((dtrwTbNotasFiscais.IsdtEmissaoNull() ? "?" : dtrwTbNotasFiscais.dtEmissao.ToString("dd/MM/yyyy")));
						//lvItemNota.SubItems.Add((dtrwTbNotasFiscais.IsdTaxaConversaoNull() ? "0,00" : dtrwTbNotasFiscais.dTaxaConversao.ToString("F")));
						lvItemNota.SubItems.Add("R$ " + (dtrwTbNotasFiscais.IsdValorNull() ? "0,00" : mdlMoeda.clsMoeda.strReturnCurrencyFormated(-1,dtrwTbNotasFiscais.dValor, false)));
						m_dValorNotasFiscais += (dtrwTbNotasFiscais.IsdValorNull() ? 0 : dtrwTbNotasFiscais.dValor);
						m_strDatasNotasFiscais += (dtrwTbNotasFiscais.IsdtEmissaoNull() ? "?, " : dtrwTbNotasFiscais.dtEmissao.ToString("dd/MM/yyyy") + ", ");
						m_strNotasFiscais += (dtrwTbNotasFiscais.IsstrNumeroNull() ? "?, " : dtrwTbNotasFiscais.strNumero + ", ");
					}
				}
				if (m_strDatasNotasFiscais.Length > 2)
					m_strDatasNotasFiscais = m_strDatasNotasFiscais.Remove(m_strDatasNotasFiscais.Length - 2, 2);
				if (m_strNotasFiscais.Length > 2)
					m_strNotasFiscais = m_strNotasFiscais.Remove(m_strNotasFiscais.Length - 2, 2);
				if (lvNotas.Items.Count > 0)
				{
					btEditar.Enabled = true;
					btExclui.Enabled = true;
				}
				else
				{
					btEditar.Enabled = false;
					btExclui.Enabled = false;
					m_formFNotasFiscais.fechaBalao();
					m_formFNotasFiscais.mostraBalao(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlNotaFiscal_frmFNotaFiscal_CriarNovaNota.ToString()), (System.Windows.Forms.Control)btNovo);
				}
				lMoedaNotas.Text = "R$ " + mdlMoeda.clsMoeda.strReturnCurrencyFormated(-1,m_dValorNotasFiscais, false);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Remove Nota
		private void removeNotaSelecionada(ref mdlComponentesGraficos.ListView lvNotas)
		{
			try
			{
				if (lvNotas.SelectedItems.Count > 0)
				{
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_clsNotaFiscal_ApagarNotas).Replace("TAG",lvNotas.SelectedItems.Count.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais = null;
						foreach(System.Windows.Forms.ListViewItem lvItemNota in lvNotas.SelectedItems)
						{
							dtrwTbNotasFiscais = m_typDatSetTbNotasFiscais.tbNotasFiscais.FindBynIdExportadorstrIdPenNotaFiscal((short)m_nIdExportador, m_strIdPE, (int)lvItemNota.Tag);
							dtrwTbNotasFiscais.Delete();
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
		#endregion
		#region CadastraEditaNota
		private void carregaDadosBDNotaSelecionada()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais = null;
				dtrwTbNotasFiscais = m_typDatSetTbNotasFiscais.tbNotasFiscais.FindBynIdExportadorstrIdPenNotaFiscal((short)m_nIdExportador, m_strIdPE, m_nIdNotaFiscal);
				if ((dtrwTbNotasFiscais != null) && (!m_bCadastroNova))
				{
					m_strNumeroNota = (dtrwTbNotasFiscais.IsstrNumeroNull() ? "" : dtrwTbNotasFiscais.strNumero);
					m_dtEmissaoNota = (dtrwTbNotasFiscais.IsdtEmissaoNull() ? System.DateTime.Now : dtrwTbNotasFiscais.dtEmissao);
					m_dValorNota = (dtrwTbNotasFiscais.IsdValorNull() ? 0 : dtrwTbNotasFiscais.dValor);
				}
				else
				{
					m_strNumeroNota = "";
					m_dtEmissaoNota = System.DateTime.Now;
					m_dValorNota = 0;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#region Cadastro
		private void calculaNovoIdNota()
		{
			try
			{
				int nIdNota = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais in m_typDatSetTbNotasFiscais.tbNotasFiscais.Rows)
				{
					if (nIdNota < dtrwTbNotasFiscais.nNotaFiscal)
					{
						nIdNota = dtrwTbNotasFiscais.nNotaFiscal;
					}
				}
				m_nIdNotaFiscal = ++nIdNota;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#region InitializeEventsFormNotasCadastro
		private void InitializeEventsFormNotasCadastro()
		{
			// Carrega Dados Interface
			m_formFNotasFiscaisCadEdit.eCallCarregaDadosInterface += new Frames.frmFNotasFiscaisCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceCadEdit);

			// Salva Dados Interface
			m_formFNotasFiscaisCadEdit.eCallSalvaDadosInterface += new Frames.frmFNotasFiscaisCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceCadastro);
		}
		#endregion
		private void cadastraNota(ref mdlComponentesGraficos.ListView lvNotas)
		{
			try
			{
				m_bCadastroNova = true;
				calculaNovoIdNota();
				carregaDadosBDNotaSelecionada();
				m_formFNotasFiscaisCadEdit = new Frames.frmFNotasFiscaisCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormNotasCadastro();
				m_formFNotasFiscaisCadEdit.setTextoGroupBox("Cadastro");
				m_formFNotasFiscaisCadEdit.setCorCadastro();
				m_formFNotasFiscaisCadEdit.ShowDialog();
				m_formFNotasFiscaisCadEdit = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool salvaDadosInterfaceCadastro(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbValor)
		{
			try
			{
				m_strNumeroNota = tbNumero.Text;
				m_dtEmissaoNota = dtpkEmissao.Value;
				m_dValorNota = Double.Parse(tbValor.Text);
				return (salvaDadosBDCadastro());
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		private bool salvaDadosBDCadastro()
		{
			try
			{
				System.Data.DataRow[] dtRowNotas = m_typDatSetTbNotasFiscaisTODAS.tbNotasFiscais.Select("strNumero = '" + m_strNumeroNota + "'");
				System.Data.DataRow[] dtRowNotasAtuais = m_typDatSetTbNotasFiscais.tbNotasFiscais.Select("strNumero = '" + m_strNumeroNota + "'");
				if (((dtRowNotas != null) && (dtRowNotas.Length > 0)) || ((dtRowNotasAtuais != null) && (dtRowNotasAtuais.Length > 0)))
				{
					mdlMensagens.clsMensagens.ShowError(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_clsNotaFiscal_NotaExistente));
					return false;
				}
				else
				{
					mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais = null;
					dtrwTbNotasFiscais = m_typDatSetTbNotasFiscais.tbNotasFiscais.NewtbNotasFiscaisRow();
					dtrwTbNotasFiscais.nIdExportador = (short)m_nIdExportador;
					dtrwTbNotasFiscais.strIdPe = m_strIdPE;
					dtrwTbNotasFiscais.nNotaFiscal = m_nIdNotaFiscal;
					dtrwTbNotasFiscais.strNumero = m_strNumeroNota;
					dtrwTbNotasFiscais.dValor = m_dValorNota;
					dtrwTbNotasFiscais.dtEmissao = m_dtEmissaoNota;
					m_typDatSetTbNotasFiscais.tbNotasFiscais.AddtbNotasFiscaisRow(dtrwTbNotasFiscais);
				}
				return true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		#endregion
		#region Edição
		#region InitializeEventsFormNotasCadEdit
		private void InitializeEventsFormNotasEdicao()
		{
			// Carrega Dados Interface
			m_formFNotasFiscaisCadEdit.eCallCarregaDadosInterface += new Frames.frmFNotasFiscaisCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceCadEdit);

			// Salva Dados Interface
			m_formFNotasFiscaisCadEdit.eCallSalvaDadosInterface += new Frames.frmFNotasFiscaisCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceEdicao);
		}
		#endregion
		private void editaNota(ref mdlComponentesGraficos.ListView lvNotas)
		{
			try
			{
				m_bCadastroNova = false;
				m_nIdNotaFiscal = (int)lvNotas.SelectedItems[0].Tag;
				carregaDadosBDNotaSelecionada();
				m_formFNotasFiscaisCadEdit = new Frames.frmFNotasFiscaisCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormNotasEdicao();
				m_formFNotasFiscaisCadEdit.setTextoGroupBox("Edição");
				m_formFNotasFiscaisCadEdit.ShowDialog();
				m_formFNotasFiscaisCadEdit = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosInterfaceCadEdit(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbValor, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				tbNumero.Text = m_strNumeroNota;
				dtpkEmissao.Value = m_dtEmissaoNota;
				tbValor.Text = m_dValorNota.ToString("F");
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool salvaDadosInterfaceEdicao(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbValor)
		{
			try
			{
				m_strNumeroNota = tbNumero.Text;
				m_dtEmissaoNota = dtpkEmissao.Value;
				m_dValorNota = Double.Parse(tbValor.Text);
				return (salvaDadosBDEdicao());
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		private bool salvaDadosBDEdicao()
		{
			try
			{
				bool bAtual = false;
				System.Data.DataRow[] dtRowNotas = m_typDatSetTbNotasFiscaisTODAS.tbNotasFiscais.Select("strNumero = '" + m_strNumeroNota + "'");
				System.Data.DataRow[] dtRowNotasAtuais = m_typDatSetTbNotasFiscais.tbNotasFiscais.Select("strNumero = '" + m_strNumeroNota + "'");
				if ((dtRowNotasAtuais != null) && (dtRowNotasAtuais.Length > 0))
				{
					if (((mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow)dtRowNotasAtuais[0]).nNotaFiscal == m_nIdNotaFiscal)
					{
						bAtual = true;
					}
				}
				if ((((dtRowNotas != null) && (dtRowNotas.Length > 0)) || ((dtRowNotasAtuais != null) && (dtRowNotasAtuais.Length > 0))) && (bAtual == false))
				{
					mdlMensagens.clsMensagens.ShowError(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlNotaFiscal_clsNotaFiscal_NotaExistente));
					return false;
				}
				else
				{
					mdlDataBaseAccess.Tabelas.XsdTbNotasFiscais.tbNotasFiscaisRow dtrwTbNotasFiscais = null;
					dtrwTbNotasFiscais = m_typDatSetTbNotasFiscais.tbNotasFiscais.FindBynIdExportadorstrIdPenNotaFiscal((short)m_nIdExportador, m_strIdPE, m_nIdNotaFiscal);
					if (dtrwTbNotasFiscais != null)
					{
						dtrwTbNotasFiscais.strNumero = m_strNumeroNota;
						dtrwTbNotasFiscais.dValor = m_dValorNota;
						dtrwTbNotasFiscais.dtEmissao = m_dtEmissaoNota;
					}
					return true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				m_cls_dba_ConnectionBD.SetTbNotasFiscais(m_typDatSetTbNotasFiscais);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strNumeros, out string strEmissoes, out string strValorTotal)
		{
			strNumeros = m_strNotasFiscais;
			strEmissoes = m_strDatasNotasFiscais;
			strValorTotal = ((m_strNotasFiscais.Trim() != "" && m_strDatasNotasFiscais.Trim() != "") ? "R$ " + mdlMoeda.clsMoeda.strReturnCurrencyFormated(-1, m_dValorNotasFiscais, false) : "");
		}
		#endregion
	}
}
