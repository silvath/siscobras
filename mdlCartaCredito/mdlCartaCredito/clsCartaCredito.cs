using System;

namespace mdlCartaCredito
{
	/// <summary>
	/// Summary description for clsCartaCredito.
	/// </summary>
	public abstract class clsCartaCredito
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		
		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;
		protected string m_strNomeImportador = "";

		protected int m_nIdCartaCredito = -1;
		protected string m_strNumeroCartaCredito = "";
		protected System.DateTime m_dtDataEmissao = System.DateTime.Now;
		protected string m_strEmissorCartaCredito = "";
		protected bool m_bEmendas = false;
		protected bool m_bDiscrepancias = false;
		protected bool m_bSaldo = false;
		protected double m_dValor = 0;
		protected int m_nIdMoeda = -1;
		public int MOEDA
		{
			get
			{
				return m_nIdMoeda;
			}
		}
		protected string m_strSimboloMoeda = "";

		private Frames.frmFCartaCredito m_formFCartaCredito = null;
		private Frames.frmFCartaCreditoCadEdit m_formFCartaCreditoCadEdit = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbMoedas m_typDatSetTbMoedas = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbCartasCredito m_typDatSetTbCartasCredito = null;
		#endregion
		
		#region Construtores & Destrutores
		public clsCartaCredito(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, int idImportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdImportador = idImportador;
		}
		#endregion

		#region InitializeEventsFormCartaCredito
		private void InitializeEventsFormCartaCredito()
		{
			// Carrega Dados Interface
			m_formFCartaCredito.eCallCarregaDadosInterface += new Frames.frmFCartaCredito.delCallCarregaDadosInterface(carregaDadosInterfaceListagem);

			// Carrega Dado Interface Detalhes
			m_formFCartaCredito.eCallCarregaDadosInterfaceDetalhe += new Frames.frmFCartaCredito.delCallCarregaDadosInterfaceDetalhe(carregaDadosInterfaceDetalhes);

			// Salva Dados Interface
			m_formFCartaCredito.eCallSalvaDadosInterface += new Frames.frmFCartaCredito.delCallSalvaDadosInterface(salvaDadosInterfaceListagem);

			// Salva Dados BD
			m_formFCartaCredito.eCallSalvaDadosBD += new Frames.frmFCartaCredito.delCallSalvaDadosBD(salvaDadosBD);

			// Nova
			m_formFCartaCredito.eCallNovaCarta += new Frames.frmFCartaCredito.delCallNovaCarta(novaCarta);
			// Editar
			m_formFCartaCredito.eCallEditarCarta += new Frames.frmFCartaCredito.delCallEditarCarta(editarCartas);

			// Excluir
			m_formFCartaCredito.eCallExcluirCartas += new Frames.frmFCartaCredito.delCallExcluirCartas(excluirCartas);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFCartaCredito = new Frames.frmFCartaCredito(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormCartaCredito();
				m_formFCartaCredito.ShowDialog();
				m_formFCartaCredito = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Nova
		#region InitializeEventsFormNovaCarta
		private void InitializeEventsFormNovaCarta()
		{
			// Carrega Dados Interface
			m_formFCartaCreditoCadEdit.eCallCarregaDadosInterface += new Frames.frmFCartaCreditoCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceNova);

			// Salva Dados Interface
			m_formFCartaCreditoCadEdit.eCallSalvaDadosInterface += new Frames.frmFCartaCreditoCadEdit.delCallSalvaDadosInterface(SalvaDadosInterfaceNova);

			// Alterar Moeda
			m_formFCartaCreditoCadEdit.eCallAlterarMoeda += new Frames.frmFCartaCreditoCadEdit.delCallAlterarMoeda(alterarMoeda);
		}
		#endregion
		#region ShowDialog
		private void novaCarta()
		{
			try
			{
				m_formFCartaCreditoCadEdit = new Frames.frmFCartaCreditoCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormNovaCarta();
				m_formFCartaCreditoCadEdit.setTextoGroupBox("Cadastro");
				m_formFCartaCreditoCadEdit.ShowDialog();
				m_formFCartaCreditoCadEdit = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento dos Dados
		private void carregaDadosInterfaceNova(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias, ref string strMoeda)
		{
			try
			{
				tbNumero.Text = "";
				dtpkEmissao.Value = System.DateTime.Now;
				tbSaldo.Text = "0";
				ckbxEmendas.Checked = false;
				ckbxDiscrepancias.Checked = false;
				strMoeda = m_strSimboloMoeda;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Salvamento dos Dados
		private void SalvaDadosInterfaceNova(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias)
		{
			try
			{
				m_strNumeroCartaCredito = tbNumero.Text;
				m_dtDataEmissao = dtpkEmissao.Value;
				if (tbSaldo.Text.Trim() != "")
					m_dValor = Double.Parse(tbSaldo.Text);
				else
					m_dValor = 0;
				m_bEmendas = ckbxEmendas.Checked;
				m_bDiscrepancias = ckbxDiscrepancias.Checked;
				salvaDadosBDNova();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDNova()
		{
			try
			{
				calculaNovoIdCarta();
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito = m_typDatSetTbCartasCredito.tbCartasCredito.NewtbCartasCreditoRow();
				if (dtrwTbCartasCredito != null)
				{
					dtrwTbCartasCredito.nIdImportador = m_nIdImportador;
					dtrwTbCartasCredito.nIdExportador = m_nIdExportador;
					dtrwTbCartasCredito.nIdCartaCredito = m_nIdCartaCredito;
					dtrwTbCartasCredito.strrNumero = m_strNumeroCartaCredito;
					dtrwTbCartasCredito.dtEmissao = m_dtDataEmissao;
					dtrwTbCartasCredito.dValor = m_dValor;
					dtrwTbCartasCredito.bEmendas = m_bEmendas;
					dtrwTbCartasCredito.bDiscrepancias = m_bDiscrepancias;
					dtrwTbCartasCredito.nIdMoeda = (short)m_nIdMoeda;
					m_typDatSetTbCartasCredito.tbCartasCredito.AddtbCartasCreditoRow(dtrwTbCartasCredito);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void calculaNovoIdCarta()
		{
			try
			{
				int nIdCarta = 0;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito in m_typDatSetTbCartasCredito.tbCartasCredito.Rows)
				{
					if (dtrwTbCartasCredito.nIdCartaCredito > nIdCarta)
						nIdCarta = dtrwTbCartasCredito.nIdCartaCredito;
				}
				m_nIdCartaCredito = ++nIdCarta;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Edição
		#region InitializeEventsFormEditarCartas
		private void InitializeEventsFormEditarCartas()
		{
			// Carrega Dados Interface
			m_formFCartaCreditoCadEdit.eCallCarregaDadosInterface += new Frames.frmFCartaCreditoCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceEdicao);

			// Salva Dados Interface
			m_formFCartaCreditoCadEdit.eCallSalvaDadosInterface += new Frames.frmFCartaCreditoCadEdit.delCallSalvaDadosInterface(SalvaDadosInterfaceEdicao);

			// Alterar Moeda
			m_formFCartaCreditoCadEdit.eCallAlterarMoeda += new Frames.frmFCartaCreditoCadEdit.delCallAlterarMoeda(alterarMoeda);
		}
		#endregion
		#region ShowDialog
		private void editarCartas(ref mdlComponentesGraficos.ListView lvCartas)
		{
			try
			{
				if (lvCartas.SelectedItems.Count > 0)
				{
					salvaDadosInterfaceListagem(ref lvCartas);
					carregaDadosCartaCredito();
					m_formFCartaCreditoCadEdit = new Frames.frmFCartaCreditoCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormEditarCartas();
					m_formFCartaCreditoCadEdit.setTextoGroupBox("Edição");
					m_formFCartaCreditoCadEdit.ShowDialog();
					m_formFCartaCreditoCadEdit = null;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento dos Dados
		private void carregaDadosInterfaceEdicao(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias, ref string strMoeda)
		{
			try
			{
				tbNumero.Text = m_strNumeroCartaCredito;
				dtpkEmissao.Value = m_dtDataEmissao;
				tbSaldo.Text = m_dValor.ToString("F");
				ckbxEmendas.Checked = m_bEmendas;
				ckbxDiscrepancias.Checked = m_bDiscrepancias;
				strMoeda = m_strSimboloMoeda;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Salvamento dos Dados
		private void SalvaDadosInterfaceEdicao(ref mdlComponentesGraficos.TextBox tbNumero, ref System.Windows.Forms.DateTimePicker dtpkEmissao, ref mdlComponentesGraficos.TextBox tbSaldo, ref System.Windows.Forms.CheckBox ckbxEmendas, ref System.Windows.Forms.CheckBox ckbxDiscrepancias)
		{
			try
			{
				m_strNumeroCartaCredito = tbNumero.Text;
				m_dtDataEmissao = dtpkEmissao.Value;
				if ((tbSaldo.Text.Trim() != "") && (tbSaldo.Text.Trim() != ","))
					m_dValor = Double.Parse(tbSaldo.Text);
				else
					m_dValor = 0;
				m_bEmendas = ckbxEmendas.Checked;
				m_bDiscrepancias = ckbxDiscrepancias.Checked;
				salvaDadosBDEdicao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDEdicao()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito = m_typDatSetTbCartasCredito.tbCartasCredito.FindBynIdCartaCreditonIdExportadornIdImportador(m_nIdCartaCredito, m_nIdExportador, m_nIdImportador);
				if (dtrwTbCartasCredito != null)
				{
					dtrwTbCartasCredito.strrNumero = m_strNumeroCartaCredito;
					dtrwTbCartasCredito.dtEmissao = m_dtDataEmissao;
					dtrwTbCartasCredito.dValor = m_dValor;
					dtrwTbCartasCredito.bEmendas = m_bEmendas;
					dtrwTbCartasCredito.bDiscrepancias = m_bDiscrepancias;
					dtrwTbCartasCredito.nIdMoeda = (short)m_nIdMoeda;
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
		#region Excluir
		private void excluirCartas(ref mdlComponentesGraficos.ListView lvCartas)
		{
			try
			{
				foreach(System.Windows.Forms.ListViewItem lvItemCartas in lvCartas.SelectedItems)
				{
					m_typDatSetTbCartasCredito.tbCartasCredito.FindBynIdCartaCreditonIdExportadornIdImportador((int)lvItemCartas.Tag, m_nIdExportador,m_nIdImportador).Delete();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
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

				arlCondicaoCampo.Add("nIdImportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdImportador);

				arlOrdenacaoCampo.Add("dtEmissao");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Decrestente);

				m_typDatSetTbCartasCredito = m_cls_dba_ConnectionDB.GetTbCartasCredito(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);

				arlOrdenacaoCampo.Clear();
				arlOrdenacaoTipo.Clear();
				arlOrdenacaoCampo.Add("mstrDescricao");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbMoedas = m_cls_dba_ConnectionDB.GetTbMoedas(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaNomeImportador()
		{
			try
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
				if ((m_typDatSetTbImportadores != null) && (m_typDatSetTbImportadores.tbImportadores.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)m_typDatSetTbImportadores.tbImportadores.Rows[0];
					if (!dtrwTbImportadores.IsnmCliNull())
						m_strNomeImportador = dtrwTbImportadores.nmCli;
					else
						m_strNomeImportador = "";
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosCartaCredito()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito = m_typDatSetTbCartasCredito.tbCartasCredito.FindBynIdCartaCreditonIdExportadornIdImportador(m_nIdCartaCredito, m_nIdExportador, m_nIdImportador);
				if (dtrwTbCartasCredito != null)
				{
					m_strNumeroCartaCredito = (dtrwTbCartasCredito.IsstrrNumeroNull() ? "" : dtrwTbCartasCredito.strrNumero);
					m_dtDataEmissao = (dtrwTbCartasCredito.IsdtEmissaoNull() ? System.DateTime.Now : dtrwTbCartasCredito.dtEmissao);
					m_dValor = (dtrwTbCartasCredito.IsdValorNull() ? 0 : dtrwTbCartasCredito.dValor);
					m_bEmendas = (dtrwTbCartasCredito.IsbEmendasNull() ? false : dtrwTbCartasCredito.bEmendas);
					m_bDiscrepancias = (dtrwTbCartasCredito.IsbDiscrepanciasNull() ? false : dtrwTbCartasCredito.bDiscrepancias);
					m_nIdMoeda = (dtrwTbCartasCredito.IsnIdMoedaNull() ? 28 : (int)dtrwTbCartasCredito.nIdMoeda);
				}
				else
				{
					m_strNumeroCartaCredito = "";
					m_dtDataEmissao = System.DateTime.Now;
					m_dValor = 0;
					m_bEmendas = false;
					m_bDiscrepancias = false;
					m_nIdMoeda = 28;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosMoeda()
		{
			try
			{
				if (m_nIdMoeda != -1)
				{
					mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwTbMoedas = null;
					if (m_typDatSetTbMoedas.tbMoedas.Rows.Count > 0)
					{
						dtrwTbMoedas = m_typDatSetTbMoedas.tbMoedas.FindByidMoeda(m_nIdMoeda);
						if (dtrwTbMoedas != null)
						{
							m_strSimboloMoeda = (dtrwTbMoedas.IssimboloNull() ? "" : dtrwTbMoedas.simbolo);
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
		#region Interface
		protected void carregaDadosInterfaceDetalhes(ref mdlComponentesGraficos.ListView lvCartas, ref mdlComponentesGraficos.ListView lvDetalhes)
		{
			try
			{
				if (lvCartas.SelectedItems.Count > 0)
					m_nIdCartaCredito = (int)lvCartas.SelectedItems[0].Tag;
				mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito = m_typDatSetTbCartasCredito.tbCartasCredito.FindBynIdCartaCreditonIdExportadornIdImportador(m_nIdCartaCredito, m_nIdExportador, m_nIdImportador);
				if (dtrwTbCartasCredito != null)
				{
					m_bEmendas = (dtrwTbCartasCredito.IsbEmendasNull() ? false : dtrwTbCartasCredito.bEmendas);
					m_bDiscrepancias = (dtrwTbCartasCredito.IsbDiscrepanciasNull() ? false : dtrwTbCartasCredito.bDiscrepancias);
					m_dValor = (dtrwTbCartasCredito.IsdValorNull() ? 0 : dtrwTbCartasCredito.dValor);
					m_dtDataEmissao = (dtrwTbCartasCredito.IsdtEmissaoNull() ? System.DateTime.Now : dtrwTbCartasCredito.dtEmissao);
					m_strNumeroCartaCredito = (dtrwTbCartasCredito.IsstrrNumeroNull() ? "" : dtrwTbCartasCredito.strrNumero);
					m_nIdMoeda = (dtrwTbCartasCredito.IsnIdMoedaNull() ? 28 : (int)dtrwTbCartasCredito.nIdMoeda);
					mdlDataBaseAccess.Tabelas.XsdTbMoedas.tbMoedasRow dtrwTbMoedas = m_typDatSetTbMoedas.tbMoedas.FindByidMoeda(m_nIdMoeda);
					if (dtrwTbMoedas != null)
						m_strSimboloMoeda = dtrwTbMoedas.simbolo;

					// List View Item
					System.Windows.Forms.ListViewItem lvItemDadosCarta;

					#region Adicionando Items à ListView
					lvDetalhes.Items.Clear();
					#region Número
					lvItemDadosCarta = lvDetalhes.Items.Add("Número: ");
					lvItemDadosCarta.ForeColor = System.Drawing.Color.Red;
					lvItemDadosCarta.UseItemStyleForSubItems = false;
					lvItemDadosCarta.Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta.SubItems.Add(m_strNumeroCartaCredito);
					lvItemDadosCarta.SubItems[1].Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta = null;
					#endregion
					#region Data Emissão
					lvItemDadosCarta = lvDetalhes.Items.Add("Emissão: ");
					lvItemDadosCarta.ForeColor = System.Drawing.Color.Red;
					lvItemDadosCarta.UseItemStyleForSubItems = false;
					lvItemDadosCarta.Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta.SubItems.Add(m_dtDataEmissao.ToString("dd/MM/yyyy"));
					lvItemDadosCarta.SubItems[1].Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta = null;
					#endregion
					#region Valor
					lvItemDadosCarta = lvDetalhes.Items.Add("Valor: ");
					lvItemDadosCarta.ForeColor = System.Drawing.Color.Red;
					lvItemDadosCarta.UseItemStyleForSubItems = false;
					lvItemDadosCarta.Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					//if (m_nIdMoeda != -1)
					//	lvItemDadosCarta.SubItems.Add(mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda,m_dValor, true));
					//else
						lvItemDadosCarta.SubItems.Add(m_dValor.ToString("F"));
					lvItemDadosCarta.SubItems[1].Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta = null;
					#endregion
					#region Emendas
					lvItemDadosCarta = lvDetalhes.Items.Add("Emendas: ");
					lvItemDadosCarta.ForeColor = System.Drawing.Color.Red;
					lvItemDadosCarta.UseItemStyleForSubItems = false;
					lvItemDadosCarta.Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta.SubItems.Add((m_bEmendas ? "Sim" : "Não"));
					lvItemDadosCarta.SubItems[1].Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta = null;
					#endregion
					#region Discrepâncias
					lvItemDadosCarta = lvDetalhes.Items.Add("Discrepâncias: ");
					lvItemDadosCarta.ForeColor = System.Drawing.Color.Red;
					lvItemDadosCarta.UseItemStyleForSubItems = false;
					lvItemDadosCarta.Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta.SubItems.Add((m_bDiscrepancias ? "Sim" : "Não"));
					lvItemDadosCarta.SubItems[1].Font = new System.Drawing.Font(lvItemDadosCarta.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosCarta = null;
					#endregion
					#endregion
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosInterfaceListagem(ref mdlComponentesGraficos.ListView lvCartas, ref System.Windows.Forms.Label lImportador, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.GroupBox gbFields)
		{
			try
			{
				System.Windows.Forms.ListViewItem lvItemCarta = null;
				lImportador.Text = m_strNomeImportador;
				lvCartas.Items.Clear();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbCartasCredito.tbCartasCreditoRow dtrwTbCartasCredito in m_typDatSetTbCartasCredito.tbCartasCredito.Rows)
				{
					if (dtrwTbCartasCredito.RowState != System.Data.DataRowState.Deleted)
					{
						lvItemCarta = lvCartas.Items.Add((dtrwTbCartasCredito.IsstrrNumeroNull() ? "" :dtrwTbCartasCredito.strrNumero));
						lvItemCarta.Tag = dtrwTbCartasCredito.nIdCartaCredito;
						if (dtrwTbCartasCredito.nIdCartaCredito == m_nIdCartaCredito)
							lvItemCarta.Selected = true;
					}
				}
				if (lvCartas.Items.Count > 0)
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
				}
				else
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
				}
				carregaDadosInterfaceGroupBox(ref gbFields);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosInterfaceGroupBox(ref System.Windows.Forms.GroupBox gbFields);
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterfaceListagem(ref mdlComponentesGraficos.ListView lvCartas)
		{
			try
			{
				if (lvCartas.SelectedItems.Count > 0)
					m_nIdCartaCredito = (int)lvCartas.SelectedItems[0].Tag;
				else
					m_nIdCartaCredito = -1;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				m_cls_dba_ConnectionDB.SetTbCartasCredito(m_typDatSetTbCartasCredito);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		#endregion
		#endregion

		#region Alterar Moeda
		private void alterarMoeda(ref string strMoeda)
		{
			try
			{
				mdlMoeda.clsMoeda obj = new mdlMoeda.clsMoedaGeral(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel);
				obj.MostrarQuestionamentoSimboloMoeda = false;
				obj.Moeda = m_nIdMoeda;
				obj.ShowDialog();
				if (obj.m_bModificado)
				{
					bool bNull;
					string strNull;
					obj.retornaValores(out m_nIdMoeda, out strNull, out m_strSimboloMoeda, out bNull);
					obj = null;
					strMoeda = m_strSimboloMoeda;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strNumero, out System.DateTime dtEmissao, out double dValor, out bool bEmendas, out bool bDiscrepancias)
		{
			strNumero = m_strNumeroCartaCredito;
			dtEmissao = m_dtDataEmissao;
			dValor = m_dValor;
			bEmendas = m_bEmendas;
			bDiscrepancias = m_bDiscrepancias;
		}
		public void retornaValores(out string strNumero, out string strDataEmissao, out string strValor, out string strEmendas, out string strDiscrepancias)
		{
			if (m_nIdCartaCredito != -1)
			{
				strNumero = m_strNumeroCartaCredito;
				strDataEmissao = m_dtDataEmissao.ToString("dd/MM/yyyy");
				strValor = mdlMoeda.clsMoeda.strReturnCurrencyFormated(m_nIdMoeda, m_dValor, true);
				strEmendas = (m_bEmendas ? "Sim" : "Não");
				strDiscrepancias = (m_bDiscrepancias ? "Sim" : "Não");
			}
			else
			{
				strNumero = "";
				strDataEmissao = "";
				strValor = "";
				strEmendas = "";
				strDiscrepancias = "";
			}
		}
		#endregion
	}
}
