using System;

namespace mdlUsuarios
{
	/// <summary>
	/// Summary description for clsUsuarioConcessoesPermissoes.
	/// </summary>
	public sealed class clsUsuarioConcessoesPermissoes
	{
		#region Atributos
			private static clsUsuarioConcessoesPermissoes m_cls_instance = null;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_db_ConnectionDB = null;
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			private int m_nIdUsuario = -1;
			private PERMISSOES m_enumPermissoes;
			private CONCESSOES m_enumConcessoes;

			internal bool m_bPrecisaRecarregarDatSets = false;
			public bool m_bModificado = false;

			private Frames.frmFPermissoesUsuario m_formFPermissoesUsuario = null;

			private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuarios m_typDatSetTbUsuarios = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes m_typDatSetTbUsuariosConcessoes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes m_typDatSetTbUsuariosConcessoesPermissoes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes m_typDatSetTbUsuariosPermissoes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes m_typDatSetTbUsuariosPermissoesConcessoes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes m_typDatSetTbUsuariosPermissoesConcessoesGeral = null;
		#endregion
		#region Propriedades
			public static clsUsuarioConcessoesPermissoes Instance
			{
				get
				{
					if (m_cls_instance == null)
					{
						m_cls_instance = new clsUsuarioConcessoesPermissoes();
					}
					return m_cls_instance;
				}
			}
			public int IdUsuario
			{
				get
				{
					return m_nIdUsuario;
				}
			}
			internal int nIdUsuario
			{
				set
				{
					m_nIdUsuario = value;
					carregaTypDatSet();
				}
			}
			internal mdlDataBaseAccess.clsDataBaseAccess clsDataBaseAccess
			{
				set
				{
					m_cls_db_ConnectionDB = value;
				}
			}
			internal mdlTratamentoErro.clsTratamentoErro clsTratamentoErro
			{
				set
				{
					m_cls_ter_tratadorErro = value;
				}
			}
			internal string EnderecoExecutavel
			{
				set
				{
					m_strEnderecoExecutavel = value;
				}
			}
		#endregion

		#region Construtores & Destrutores
		private clsUsuarioConcessoesPermissoes()
		{
		}
		#endregion

		#region InitializeEventsFormPermissoes
		private void InitializeEventsFormPermissoes()
		{
			// Carrega Dados Combo Box Usuarios
			m_formFPermissoesUsuario.eCalCarregaDadosComboBoxUsuarios += new Frames.frmFPermissoesUsuario.delCalCarregaDadosComboBoxUsuarios(carregaDadosUsuariosInterface);

			// Carrega Dados Combo Box Concessoes
			m_formFPermissoesUsuario.eCallCarregaDadosComboBoxConcessoes += new Frames.frmFPermissoesUsuario.delCallCarregaDadosComboBoxConcessoes(carregaDadosConcessoesInterface);

			// Carrega Dados Combo Box Permissos
			m_formFPermissoesUsuario.eCallCarregaDadosComboBoxPermissoes += new Frames.frmFPermissoesUsuario.delCallCarregaDadosComboBoxPermissoes(carregaDadosPermissoesPossiveisInterface);

			// Salva Dados Interface
			m_formFPermissoesUsuario.eCallSalvaDadosInterface += new Frames.frmFPermissoesUsuario.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFPermissoesUsuario.eCallSalvaDadosBD += new Frames.frmFPermissoesUsuario.delCallSalvaDadosBD(salvaDadosBD);

			// Anula TypDatSet
			m_formFPermissoesUsuario.eCallAnulaTypDatSet += new Frames.frmFPermissoesUsuario.delCallAnulaTypDatSet(anulaTypDatSet);
		}
		#endregion

		#region ShowDialogPermissoes
		public void ShowDialogPermissoes()
		{
			try
			{
				m_formFPermissoesUsuario = new Frames.frmFPermissoesUsuario(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormPermissoes();
				m_formFPermissoesUsuario.ShowDialog();
				m_formFPermissoesUsuario = null;
			}
			catch
			{
			}
		}
		#endregion

		#region Metodos de pesquisa
		public int[] arrNPesquisaConcessoes(PERMISSOES enumPermissoes, CONCESSOES enumConcessoes)
		{
			int[] arrayIntRetorno = new int[0];
			try
			{
				System.Data.DataRow[] dtRwRegistrosSelect;
				System.Collections.ArrayList arlValoresEspecificos = new System.Collections.ArrayList();
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow dtrwTbUsuariosPermissoesConcessoes;
				if (m_typDatSetTbUsuariosPermissoesConcessoes == null)
				{
					carregaTypDatSet();
				}
				if (enumConcessoes != m_enumConcessoes)
				{
					m_enumConcessoes = enumConcessoes;
				}
				if (enumPermissoes != m_enumPermissoes)
				{
					m_enumPermissoes = enumPermissoes;
				}
				dtRwRegistrosSelect = m_typDatSetTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoes.Select("nIdConcessao = " + ((int)m_enumConcessoes).ToString());
				for (int nCount = 0; nCount < dtRwRegistrosSelect.Length; nCount++)
				{
					dtrwTbUsuariosPermissoesConcessoes = (mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow)dtRwRegistrosSelect[nCount];
					if (dtrwTbUsuariosPermissoesConcessoes.nIdPermissao == (int)m_enumPermissoes)
						arlValoresEspecificos.Add(dtrwTbUsuariosPermissoesConcessoes.nIdEspecifico);
				}
				arrayIntRetorno = new int[arlValoresEspecificos.Count];
				for (int nCount = 0; nCount < arlValoresEspecificos.Count; nCount++)
					arrayIntRetorno[nCount] = (int)arlValoresEspecificos[nCount];
			}
			catch
			{
			}
			return arrayIntRetorno;
		}
		public string[] arrStrPesquisaConcessoes(PERMISSOES enumPermissoes, CONCESSOES enumConcessoes)
		{
			string[] arrayIntRetorno = new string[0];
			try
			{
				System.Data.DataRow[] dtRwRegistrosSelect;
				System.Collections.ArrayList arlValoresEspecificos = new System.Collections.ArrayList();
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow dtrwTbUsuariosPermissoesConcessoes;
				if (m_typDatSetTbUsuariosPermissoesConcessoes == null)
				{
					carregaTypDatSet();
				}
				if (enumConcessoes != m_enumConcessoes)
				{
					m_enumConcessoes = enumConcessoes;
				}
				if (enumPermissoes != m_enumPermissoes)
				{
					m_enumPermissoes = enumPermissoes;
				}
				dtRwRegistrosSelect = m_typDatSetTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoes.Select("nIdConcessao = " + ((int)m_enumConcessoes).ToString());
				for (int nCount = 0; nCount < dtRwRegistrosSelect.Length; nCount++)
				{
					dtrwTbUsuariosPermissoesConcessoes = (mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow)dtRwRegistrosSelect[nCount];
					if (dtrwTbUsuariosPermissoesConcessoes.nIdPermissao == (int)m_enumPermissoes)
						arlValoresEspecificos.Add(dtrwTbUsuariosPermissoesConcessoes.strEspecifico);
				}
				arrayIntRetorno = new string[arlValoresEspecificos.Count];
				for (int nCount = 0; nCount < arlValoresEspecificos.Count; nCount++)
					arrayIntRetorno[nCount] = arlValoresEspecificos[nCount].ToString();
			}
			catch
			{
			}
			return arrayIntRetorno;
		}
		public bool bPesquisaConcessoes(PERMISSOES enumPermissoes, CONCESSOES enumConcessoes, int nIdEspecifico)
		{
			bool bRetorno = false;
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow dtrwTbUsuariosPermissoesConcessoes;
				if (m_typDatSetTbUsuariosPermissoesConcessoes == null)
				{
					carregaTypDatSet();
				}
				if (enumConcessoes != m_enumConcessoes)
				{
					m_enumConcessoes = enumConcessoes;
				}
				if (enumPermissoes != m_enumPermissoes)
				{
					m_enumPermissoes = enumPermissoes;
				}
				dtrwTbUsuariosPermissoesConcessoes = m_typDatSetTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoes.FindBynIdUsuarionIdPermissaonIdConcessaonIdEspecifico(m_nIdUsuario,(int)m_enumPermissoes,(int)m_enumConcessoes,nIdEspecifico);
				if (dtrwTbUsuariosPermissoesConcessoes != null)
					bRetorno = true;
			}
			catch
			{
			}
			return bRetorno;
		}
		public bool bPesquisaConcessoes(PERMISSOES enumPermissoes, CONCESSOES enumConcessoes, int nIdEspecifico, string strEspecifico)
		{
			bool bRetorno = false;
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow dtrwTbUsuariosPermissoesConcessoes;
				if (m_typDatSetTbUsuariosPermissoesConcessoes == null)
				{
					carregaTypDatSet();
				}
				if (enumConcessoes != m_enumConcessoes)
				{
					m_enumConcessoes = enumConcessoes;
				}
				if (enumPermissoes != m_enumPermissoes)
				{
					m_enumPermissoes = enumPermissoes;
				}
				dtrwTbUsuariosPermissoesConcessoes = m_typDatSetTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoes.FindBynIdUsuarionIdPermissaonIdConcessaonIdEspecifico(m_nIdUsuario,(int)m_enumPermissoes,(int)m_enumConcessoes,nIdEspecifico);
				if ((dtrwTbUsuariosPermissoesConcessoes != null) && (dtrwTbUsuariosPermissoesConcessoes.strEspecifico == strEspecifico))
					bRetorno = true;
			}
			catch
			{
			}
			return bRetorno;
		}
		#endregion

		#region Carregamento de Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdUsuario");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdUsuario);

				m_typDatSetTbUsuariosPermissoesConcessoes = m_cls_db_ConnectionDB.GetTbUsuariosPermissoesConcessoes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch
			{
			}
		}
		private void carregaTypDatSetPermissoesConcessoesGeral()
		{
			try
			{
				m_typDatSetTbUsuariosPermissoesConcessoesGeral = m_cls_db_ConnectionDB.GetTbUsuariosPermissoesConcessoes(null,null,null,null,null);
			}
			catch
			{
			}
		}
		private void carregaTypDatSetUsuarios()
		{
			try
			{
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlOrdenacaoCampo.Add("strNome");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbUsuarios = m_cls_db_ConnectionDB.GetTbUsuarios(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTypDatSetPermissoes()
		{
			try
			{
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlOrdenacaoCampo.Add("strConcessao");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbUsuariosConcessoes = m_cls_db_ConnectionDB.GetTbUsuariosConcessoes(null,null,null,arlOrdenacaoCampo,arlOrdenacaoTipo);
				m_typDatSetTbUsuariosConcessoesPermissoes = m_cls_db_ConnectionDB.GetTbUsuariosConcessoesPermissoes(null,null,null,null,null);
				m_typDatSetTbUsuariosPermissoes = m_cls_db_ConnectionDB.GetTbUsuariosPermissoes(null,null,null,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaTypDatSetExportadores()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.MaiorOuIgual);
				arlCondicaoValor.Add(0);
				arlOrdenacaoCampo.Add("marca");
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

				m_typDatSetTbExportadores = m_cls_db_ConnectionDB.GetTbExportadores(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoCampo,arlOrdenacaoTipo);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		private void carregaDadosUsuariosInterface(ref mdlComponentesGraficos.ComboBox cbUsuarios)
		{
			if (m_typDatSetTbUsuarios == null || m_bPrecisaRecarregarDatSets)
				carregaTypDatSetUsuarios();
			try
			{
				cbUsuarios.Items.Clear();
				cbUsuarios.SelectedItem = "";
				cbUsuarios.SelectedText = "";
				cbUsuarios.Text = "";
				mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwTbUsuarios;
				for (int nCount = 0; nCount < m_typDatSetTbUsuarios.tbUsuarios.Rows.Count; nCount++)
				{
					dtrwTbUsuarios = (mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow)m_typDatSetTbUsuarios.tbUsuarios.Rows[nCount];
					cbUsuarios.AddItem(dtrwTbUsuarios.strNome.ToUpper(), dtrwTbUsuarios.nIdUsuario);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			m_bPrecisaRecarregarDatSets = false;
		}
		private void carregaDadosConcessoesInterface(ref mdlComponentesGraficos.ComboBox cbConcessoes)
		{
			if (m_typDatSetTbUsuariosConcessoes == null)
				carregaTypDatSetPermissoes();
			try
			{
				cbConcessoes.Items.Clear();
				cbConcessoes.SelectedItem = "";
				cbConcessoes.SelectedText = "";
				cbConcessoes.Text = "";
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes.tbUsuariosConcessoesRow dtrwTbUsuariosConcessoes;
				for (int nCount = 0; nCount < m_typDatSetTbUsuariosConcessoes.tbUsuariosConcessoes.Rows.Count; nCount++)
				{
					dtrwTbUsuariosConcessoes = (mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoes.tbUsuariosConcessoesRow)m_typDatSetTbUsuariosConcessoes.tbUsuariosConcessoes.Rows[nCount];
					cbConcessoes.AddItem(dtrwTbUsuariosConcessoes.strConcessao.ToUpper(), dtrwTbUsuariosConcessoes.nIdConcessao);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			m_bPrecisaRecarregarDatSets = false;
		}
		private void carregaDadosPermissoesPossiveisInterface(ref mdlComponentesGraficos.ComboBox cbConcessoes, ref mdlComponentesGraficos.ComboBox cbPermissoesPossiveis, ref mdlComponentesGraficos.ComboBox cbItems)
		{
			if ((m_typDatSetTbUsuariosConcessoesPermissoes == null) || (m_typDatSetTbUsuariosConcessoes == null) || (m_typDatSetTbUsuarios == null) || m_bPrecisaRecarregarDatSets)
				carregaTypDatSetPermissoes();
			try
			{
				cbPermissoesPossiveis.Items.Clear();
				cbPermissoesPossiveis.SelectedItem = "";
				cbPermissoesPossiveis.SelectedText = "";
				cbPermissoesPossiveis.Text = "";
				if (cbConcessoes.SelectedItem != null)
				{
                    int nIdConcessao = (int)cbConcessoes.ReturnObjectSelectedItem();
					System.Data.DataRow[] dtRowConcessoesPermissoes = m_typDatSetTbUsuariosConcessoesPermissoes.tbUsuariosConcessoesPermissoes.Select("nIdConcessao = " + nIdConcessao.ToString());
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes.tbUsuariosConcessoesPermissoesRow dtrwTbUsuariosConcessoesPermissoes;
					mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoes.tbUsuariosPermissoesRow dtrwTbUsuariosPermissoes;
					for (int nCount = 0; nCount < dtRowConcessoesPermissoes.Length; nCount++)
					{
						dtrwTbUsuariosConcessoesPermissoes = (mdlDataBaseAccess.Tabelas.XsdTbUsuariosConcessoesPermissoes.tbUsuariosConcessoesPermissoesRow)dtRowConcessoesPermissoes[nCount];
						dtrwTbUsuariosPermissoes = m_typDatSetTbUsuariosPermissoes.tbUsuariosPermissoes.FindBynIdPermissao(dtrwTbUsuariosConcessoesPermissoes.nIdPermissao);
						cbPermissoesPossiveis.AddItem(dtrwTbUsuariosPermissoes.strNome.ToUpper(),dtrwTbUsuariosPermissoes.nIdPermissao);
					}
					carregaDadosItemsEspecificosInterface(ref cbItems, nIdConcessao);
				}
				m_bPrecisaRecarregarDatSets = false;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosItemsEspecificosInterface(ref mdlComponentesGraficos.ComboBox cbItemsEspecificos, int nIdConcessao)
		{
			try
			{
				switch (nIdConcessao)
				{
					case 1:
						cbItemsEspecificos.Items.Clear();
						cbItemsEspecificos.SelectedItem = "";
						cbItemsEspecificos.SelectedText = "";
						cbItemsEspecificos.Text = "";
						mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwTbUsuarios;
						for (int nCount = 0; nCount < m_typDatSetTbUsuarios.tbUsuarios.Rows.Count; nCount++)
						{
							dtrwTbUsuarios = (mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow)m_typDatSetTbUsuarios.tbUsuarios.Rows[nCount];
							cbItemsEspecificos.AddItem(dtrwTbUsuarios.strNome.ToUpper(), dtrwTbUsuarios.nIdUsuario);
						}
						break;
					case 2:
						if (m_typDatSetTbExportadores == null)
							carregaTypDatSetExportadores();
						cbItemsEspecificos.Items.Clear();
						cbItemsEspecificos.SelectedItem = "";
						cbItemsEspecificos.SelectedText = "";
						cbItemsEspecificos.Text = "";
						mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
						for (int nCount = 0; nCount < m_typDatSetTbExportadores.tbExportadores.Rows.Count; nCount++)
						{
							dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[nCount];
							cbItemsEspecificos.AddItem(dtrwTbExportadores.marca.ToUpper(), dtrwTbExportadores.idExportador);
						}
						break;
					default:
						cbItemsEspecificos.Items.Clear();
						cbItemsEspecificos.SelectedItem = "";
						cbItemsEspecificos.SelectedText = "";
						cbItemsEspecificos.Text = "";
						break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			m_bPrecisaRecarregarDatSets = false;
		}
		#endregion
		#endregion
		#region Salvamento de Dados
		private void salvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbConcessoes, ref mdlComponentesGraficos.ComboBox cbUsuarios, ref mdlComponentesGraficos.ComboBox cbPermissoes, ref mdlComponentesGraficos.ComboBox cbItemsEspecificos)
		{
			try
			{
				int nIdConcessao = -1, nIdUsuario = -1, nIdPermissao = -1, nIdItemEspecifico = -1;
				string strIdEspecifico = "";
				nIdConcessao = (int)cbConcessoes.ReturnObjectSelectedItem();
				nIdUsuario = (int)cbUsuarios.ReturnObjectSelectedItem();
				nIdPermissao = (int)cbPermissoes.ReturnObjectSelectedItem();
				switch (nIdConcessao)
				{
					case 1:
						nIdItemEspecifico = (int)cbItemsEspecificos.ReturnObjectSelectedItem();
						strIdEspecifico = cbItemsEspecificos.SelectedText;
						break;
					case 2:
						nIdItemEspecifico = (int)cbItemsEspecificos.ReturnObjectSelectedItem();
						strIdEspecifico = cbItemsEspecificos.SelectedText;
						break;
					case 3:
						nIdItemEspecifico = -1;
						strIdEspecifico = (string)cbItemsEspecificos.ReturnObjectSelectedItem();
						break;
					default:
						nIdItemEspecifico = -1;
						strIdEspecifico = "";
						break;
				}
				salvaDadosTypDatSet(nIdConcessao, nIdUsuario, nIdPermissao, nIdItemEspecifico, strIdEspecifico);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosTypDatSet(int nIdConcessao, int nIdUsuario, int nIdPermissao, int nIdItemEspecifico, string strItemEspecifico)
		{
			if (m_typDatSetTbUsuariosPermissoesConcessoesGeral == null || m_bPrecisaRecarregarDatSets)
				carregaTypDatSetPermissoesConcessoesGeral();
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuariosPermissoesConcessoes.tbUsuariosPermissoesConcessoesRow dtrwTbUsuariosPermissoesConcessoes = null;
				dtrwTbUsuariosPermissoesConcessoes = m_typDatSetTbUsuariosPermissoesConcessoesGeral.tbUsuariosPermissoesConcessoes.FindBynIdUsuarionIdPermissaonIdConcessaonIdEspecifico(nIdUsuario,nIdPermissao,nIdConcessao,nIdItemEspecifico);
				if (dtrwTbUsuariosPermissoesConcessoes == null)
				{
					dtrwTbUsuariosPermissoesConcessoes = m_typDatSetTbUsuariosPermissoesConcessoesGeral.tbUsuariosPermissoesConcessoes.NewtbUsuariosPermissoesConcessoesRow();
					dtrwTbUsuariosPermissoesConcessoes.nIdUsuario = nIdUsuario;
					dtrwTbUsuariosPermissoesConcessoes.nIdPermissao = nIdPermissao;
					dtrwTbUsuariosPermissoesConcessoes.nIdConcessao = nIdConcessao;
					dtrwTbUsuariosPermissoesConcessoes.nIdEspecifico = nIdItemEspecifico;
					dtrwTbUsuariosPermissoesConcessoes.strEspecifico = strItemEspecifico;
					m_typDatSetTbUsuariosPermissoesConcessoesGeral.tbUsuariosPermissoesConcessoes.AddtbUsuariosPermissoesConcessoesRow(dtrwTbUsuariosPermissoesConcessoes);
				}
				else
				{
					if (dtrwTbUsuariosPermissoesConcessoes.nIdUsuario != nIdUsuario)
                        dtrwTbUsuariosPermissoesConcessoes.nIdUsuario = nIdUsuario;
					if (dtrwTbUsuariosPermissoesConcessoes.nIdPermissao != nIdPermissao)
						dtrwTbUsuariosPermissoesConcessoes.nIdPermissao = nIdPermissao;
					if (dtrwTbUsuariosPermissoesConcessoes.nIdConcessao != nIdConcessao)
						dtrwTbUsuariosPermissoesConcessoes.nIdConcessao = nIdConcessao;
					if (dtrwTbUsuariosPermissoesConcessoes.nIdEspecifico != nIdItemEspecifico)
						dtrwTbUsuariosPermissoesConcessoes.nIdEspecifico = nIdItemEspecifico;
					if (dtrwTbUsuariosPermissoesConcessoes.strEspecifico != strItemEspecifico)
						dtrwTbUsuariosPermissoesConcessoes.strEspecifico = strItemEspecifico;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				if (m_typDatSetTbUsuariosPermissoesConcessoesGeral != null)
					m_cls_db_ConnectionDB.SetTbUsuariosPermissoesConcessoes(m_typDatSetTbUsuariosPermissoesConcessoesGeral);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Limpa TypDatSet
		private void anulaTypDatSet()
		{
			try
			{
				m_typDatSetTbExportadores = null;
				m_typDatSetTbUsuarios = null;
				m_typDatSetTbUsuariosConcessoes = null;
				m_typDatSetTbUsuariosConcessoesPermissoes = null;
				m_typDatSetTbUsuariosPermissoes = null;
				m_typDatSetTbUsuariosPermissoesConcessoesGeral = null;
				carregaTypDatSet();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
