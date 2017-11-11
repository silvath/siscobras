using System;

namespace mdlAgentes
{
	/// <summary>
	/// Summary description for clsAgentes.
	/// </summary>
	public class clsAgentes
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		private bool m_bCadastroAgenteModificado = false;
		private bool m_bCadastroContatoModificado = false;

		private bool m_bCadastroNovoAgente = false;
		private bool m_bCadastroNovoContato = false;

		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected int m_nIdAgente = -1;
		protected int m_nIdContato = -1;

		protected string m_strAgente = "";
		protected string m_strSite = "";
		protected string m_strNomeContato = "";
		protected string m_strEmail = "";
		protected string m_strTelefone = "";
		protected string m_strFax = "";
		protected string m_strNomeContatoCONTATO = "";
		protected string m_strEmailCONTATO = "";
		protected string m_strTelefoneCONTATO = "";
		protected string m_strFaxCONTATO = "";

		private Frames.frmFListaAgentes m_formFListaAgentes = null;
		private Frames.frmFListaContatos m_formFListaContatos = null;
		private Frames.frmFCadastroAgentes m_formFCadastroAgentes = null;
		private Frames.frmFCadastroContatos m_formFCadastroContatos = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes m_typDatSetTbExportadoresAgentes = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos m_typDatSetTbExportadoresAgentesContatos = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos m_typDatSetTbExportadoresAgentesContatosTemporario = null;
		#endregion

		#region Construtores & Destrutores
		public clsAgentes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_strIdPE = strIdPE;
			carregaTypDatSet();
			carregaDadosBDInstrucoesEmbarque();
		}
		public clsAgentes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE, int nIdAgente)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdAgente = nIdAgente;
			m_nIdContato = 0;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsAgentes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string EnderecoExecutavel, int idExportador, string strIdPE, int nIdAgente, int nIdContato)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = idExportador;
			m_nIdAgente = nIdAgente;
			m_nIdContato = nIdContato;
			carregaTypDatSet();
			carregaDadosBDCompleto();
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("strNome");

				m_typDatSetTbExportadoresAgentes = m_cls_dba_ConnectionDB.GetTbExportadoresAgentes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoValor,arlOrdenacaoTipo);
				m_typDatSetTbExportadoresAgentesContatos = m_cls_dba_ConnectionDB.GetTbExportadoresAgentesContatos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,arlOrdenacaoValor,arlOrdenacaoTipo);

				arlCondicaoCampo.Clear();
				arlCondicaoComparador.Clear();
				arlCondicaoValor.Clear();
				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbInstrucoesEmbarque = m_cls_dba_ConnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		private void carregaDadosBD()
		{
			try
			{
				if (m_typDatSetTbExportadoresAgentes != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentes != null)
					{
						if (!dtrwTbExportadoresAgentes.IsstrNomeNull())
							m_strAgente = dtrwTbExportadoresAgentes.strNome;
						else
							m_strAgente = "";
						if (!dtrwTbExportadoresAgentes.IsstrSiteNull())
							m_strSite = dtrwTbExportadoresAgentes.strSite;
						else
							m_strSite = "";
						if (m_typDatSetTbExportadoresAgentesContatos != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, 0);
							if (dtrwTbExportadoresAgentesContatos != null)
							{
								if (!dtrwTbExportadoresAgentesContatos.IsstrNomeNull())
									m_strNomeContato = dtrwTbExportadoresAgentesContatos.strNome;
								else
									m_strNomeContato = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrTelefoneNull())
									m_strTelefone = dtrwTbExportadoresAgentesContatos.strTelefone;
								else
									m_strTelefone = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrFaxNull())
									m_strFax = dtrwTbExportadoresAgentesContatos.strFax;
								else
									m_strFax = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrEmailNull())
									m_strEmail = dtrwTbExportadoresAgentesContatos.strEmail;
								else
									m_strEmail = "";
							}
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
		private void carregaDadosBDCompleto()
		{
			try
			{
				if (m_typDatSetTbExportadoresAgentes != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentes != null)
					{
						if (!dtrwTbExportadoresAgentes.IsstrNomeNull())
							m_strAgente = dtrwTbExportadoresAgentes.strNome;
						else
							m_strAgente = "";
						if (!dtrwTbExportadoresAgentes.IsstrSiteNull())
							m_strSite = dtrwTbExportadoresAgentes.strSite;
						else
							m_strSite = "";
						if (m_typDatSetTbExportadoresAgentesContatos != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, m_nIdContato);
							if (dtrwTbExportadoresAgentesContatos != null)
							{
								if (!dtrwTbExportadoresAgentesContatos.IsstrNomeNull())
									m_strNomeContatoCONTATO = dtrwTbExportadoresAgentesContatos.strNome;
								else
									m_strNomeContatoCONTATO = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrTelefoneNull())
									m_strTelefoneCONTATO = dtrwTbExportadoresAgentesContatos.strTelefone;
								else
									m_strTelefoneCONTATO = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrFaxNull())
									m_strFaxCONTATO = dtrwTbExportadoresAgentesContatos.strFax;
								else
									m_strFaxCONTATO = "";
								if (!dtrwTbExportadoresAgentesContatos.IsstrEmailNull())
									m_strEmailCONTATO = dtrwTbExportadoresAgentesContatos.strEmail;
								else
									m_strEmailCONTATO = "";
							}
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
		private void carregaDadosBDInstrucoesEmbarque()
		{
			try
			{
				if ((m_typDatSetTbInstrucoesEmbarque != null) && (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if (dtrwTbInstrucoesEmbarque != null)
					{
						if (!dtrwTbInstrucoesEmbarque.IsnIdAgenteNull())
                            m_nIdAgente = dtrwTbInstrucoesEmbarque.nIdAgente;
						else
							m_nIdAgente = -1;
						if (!dtrwTbInstrucoesEmbarque.IsnIdContatoNull())
							m_nIdContato = dtrwTbInstrucoesEmbarque.nIdContato;
						else
							m_nIdContato = -1;
						if (m_typDatSetTbExportadoresAgentes != null)
						{
							mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
							if (dtrwTbExportadoresAgentes != null)
							{
								if (!dtrwTbExportadoresAgentes.IsstrNomeNull())
									m_strAgente = dtrwTbExportadoresAgentes.strNome;
								else
									m_strAgente = "";
								if (!dtrwTbExportadoresAgentes.IsstrSiteNull())
									m_strSite = dtrwTbExportadoresAgentes.strSite;
								else
									m_strSite = "";
								if (m_typDatSetTbExportadoresAgentesContatos != null)
								{
									mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, m_nIdContato);
									if (dtrwTbExportadoresAgentesContatos != null)
									{
										if (!dtrwTbExportadoresAgentesContatos.IsstrNomeNull())
											m_strNomeContatoCONTATO = dtrwTbExportadoresAgentesContatos.strNome;
										else
											m_strNomeContatoCONTATO = "";
										if (!dtrwTbExportadoresAgentesContatos.IsstrTelefoneNull())
											m_strTelefoneCONTATO = dtrwTbExportadoresAgentesContatos.strTelefone;
										else
											m_strTelefoneCONTATO = "";
										if (!dtrwTbExportadoresAgentesContatos.IsstrFaxNull())
											m_strFaxCONTATO = dtrwTbExportadoresAgentesContatos.strFax;
										else
											m_strFaxCONTATO = "";
										if (!dtrwTbExportadoresAgentesContatos.IsstrEmailNull())
											m_strEmailCONTATO = dtrwTbExportadoresAgentesContatos.strEmail;
										else
											m_strEmailCONTATO = "";
									}
								}
							}
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
		#endregion
		#region Salvamento dos Dados
		private void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				if (m_bModificado)
				{
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentes(m_typDatSetTbExportadoresAgentes);
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentesContatos(m_typDatSetTbExportadoresAgentesContatos);
					salvaDadosBDEspecificos(true);
				}
				else if (m_bCadastroContatoModificado)
				{
					m_cls_dba_ConnectionDB.SetTbExportadoresAgentesContatos(m_typDatSetTbExportadoresAgentesContatos);
					salvaDadosBDEspecificos(false);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDEspecificos(bool bSalvaAgente)
		{
			try
			{
				if ((m_typDatSetTbInstrucoesEmbarque != null) && (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0))
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					if (dtrwTbInstrucoesEmbarque != null)
					{
						if (bSalvaAgente)
							dtrwTbInstrucoesEmbarque.nIdAgente = m_nIdAgente;
                        dtrwTbInstrucoesEmbarque.nIdContato = m_nIdContato;
						m_cls_dba_ConnectionDB.SetTbInstrucoesEmbarque(m_typDatSetTbInstrucoesEmbarque);
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

		#region Listagem Agentes
		#region InitializeEventsFormListaAgentes
		private void InitializeEventsFormListaAgentes()
		{
			// Carrega Dados Interface
			m_formFListaAgentes.eCallCarregaDadosInterface += new Frames.frmFListaAgentes.delCallCarregaDadosInterface(carregaDadosInterfaceListaAgentes);

			// Salva Dados Interface
			m_formFListaAgentes.eCallSalvaDadosInterface += new Frames.frmFListaAgentes.delCallSalvaDadosInterface(salvaDadosInterfaceListagemAgentes);

			// Salva Dados BD
			m_formFListaAgentes.eCallSalvaDadosBD += new Frames.frmFListaAgentes.delCallSalvaDadosBD(salvaDadosBD);

			// Edita Agente
			m_formFListaAgentes.eCallEditaAgente += new Frames.frmFListaAgentes.delCallEditaAgente(editaAgente);

			// Cadastra Agente
			m_formFListaAgentes.eCallCadastraAgente += new Frames.frmFListaAgentes.delCallCadastraAgente(cadastraAgente);

			// Exclui Agente
			m_formFListaAgentes.eCallExcluiAgente += new Frames.frmFListaAgentes.delCallExcluiAgente(excluiAgente);

			// Lista Contatos
			m_formFListaAgentes.eCallListaContatos += new Frames.frmFListaAgentes.delCallListaContatos(listaContatos);
		}
		#endregion
		#region Show Dialog Listagem Agentes
		public void ShowDialog()
		{
			try
			{
				m_formFListaAgentes = new Frames.frmFListaAgentes(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormListaAgentes();
				m_formFListaAgentes.ShowDialog();
				m_formFListaAgentes = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceListaAgentes(ref mdlComponentesGraficos.ListView lvAgentes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btContatos, out string strCaption)
		{
			strCaption = "";
			btContatos.ImageIndex = 0;
			try
			{
				if (m_typDatSetTbExportadoresAgentes != null)
				{
					lvAgentes.Items.Clear();
					System.Windows.Forms.ListViewItem lvItemAgente;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes in m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.Rows)
					{
						if ((dtrwTbExportadoresAgentes.RowState != System.Data.DataRowState.Deleted) && (!dtrwTbExportadoresAgentes.IsstrNomeNull()))
						{
							lvItemAgente = lvAgentes.Items.Add(dtrwTbExportadoresAgentes.strNome);
							lvItemAgente.Tag = dtrwTbExportadoresAgentes.nIdAgente;
							if (m_nIdAgente == (int)lvItemAgente.Tag)
							{
								lvItemAgente.Selected = true;
								if (!dtrwTbExportadoresAgentes.IsstrSiteNull())
									m_strSite = dtrwTbExportadoresAgentes.strSite;
//								if (m_nIdContato == -1)
//									m_nIdContato = 0;
								dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, 0/*m_nIdContato*/);
								if (dtrwTbExportadoresAgentesContatos != null)
								{
									if (!dtrwTbExportadoresAgentesContatos.IsstrNomeNull())
										m_strNomeContato = dtrwTbExportadoresAgentesContatos.strNome;
									else
										m_strNomeContato = "";
									if (!dtrwTbExportadoresAgentesContatos.IsstrEmailNull())
										m_strEmail = dtrwTbExportadoresAgentesContatos.strEmail;
									else
										m_strEmail = "";
									if (!dtrwTbExportadoresAgentesContatos.IsstrTelefoneNull())
										m_strTelefone = dtrwTbExportadoresAgentesContatos.strTelefone;
									else
										m_strTelefone = "";
									if (!dtrwTbExportadoresAgentesContatos.IsstrFaxNull())
										m_strFax = dtrwTbExportadoresAgentesContatos.strFax;
									else
										m_strFax = "";
								}
								else
								{
									m_strNomeContato = "";
									m_strEmail = "";
									m_strTelefone = "";
									m_strFax = "";
								}
							}
						}
					}
				}
				if (lvAgentes.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
					btContatos.Enabled = false;
				}
				else
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
					btContatos.Enabled = true;
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
		#region Salvamento dos Dados
		#region Interface
		private void salvaDadosInterfaceListagemAgentes(ref mdlComponentesGraficos.ListView lvAgentes)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrTbExportadoresAgentes;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos;
				if (lvAgentes.SelectedItems.Count > 0)
				{
					m_nIdAgente = (int)lvAgentes.SelectedItems[0].Tag;
					m_strAgente = lvAgentes.SelectedItems[0].Text;
					dtrTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (!dtrTbExportadoresAgentes.IsstrSiteNull())
						m_strSite = dtrTbExportadoresAgentes.strSite;
					else
						m_strSite = "";
					if (m_nIdContato == -1)
						m_nIdContato = 0;
					dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, m_nIdContato);
					if (dtrwTbExportadoresAgentesContatos != null)
					{
						if (!dtrwTbExportadoresAgentesContatos.IsstrNomeNull())
							m_strNomeContato = dtrwTbExportadoresAgentesContatos.strNome;
						else
							m_strNomeContato = "";
						if (!dtrwTbExportadoresAgentesContatos.IsstrEmailNull())
							m_strEmail = dtrwTbExportadoresAgentesContatos.strEmail;
						else
							m_strEmail = "";
						if (!dtrwTbExportadoresAgentesContatos.IsstrTelefoneNull())
							m_strTelefone = dtrwTbExportadoresAgentesContatos.strTelefone;
						else
							m_strTelefone = "";
						if (!dtrwTbExportadoresAgentesContatos.IsstrFaxNull())
							m_strFax = dtrwTbExportadoresAgentesContatos.strFax;
						else
							m_strFax = "";
					}
					else
					{
						m_strNomeContato = "";
						m_strEmail = "";
						m_strTelefone = "";
						m_strFax = "";
					}
				}
				else
				{
					m_nIdAgente = -1;
					m_strAgente = "";
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
		#region Edita Agente
		private void editaAgente()
		{
			try
			{
				ShowDialogCadastroAgentes(false);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastra Agente
		private void cadastraAgente()
		{
			try
			{
				ShowDialogCadastroAgentes(true);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Exclui Agente
		private void excluiAgente(ref mdlComponentesGraficos.ListView lvAgentes)
		{
			try
			{
				if (System.Windows.Forms.MessageBox.Show("Deseja excluir este(s) " + lvAgentes.SelectedItems.Count + " agente(s)?", "Siscobras.NET", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					m_bCadastroAgenteModificado = true;
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes;
					foreach(System.Windows.Forms.ListViewItem lvItemAgente in lvAgentes.SelectedItems)
					{
						dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador,(int)lvItemAgente.Tag);
						if (dtrwTbExportadoresAgentes != null)
							dtrwTbExportadoresAgentes.Delete();
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
		#region Listagem de Contatos
		private void listaContatos()
		{
			ShowDialogListagemContatos();
		}
		#endregion
		#endregion

		#region Cadastro Agentes
		#region Show Dialog Cadastro Agentes
		private void ShowDialogCadastroAgentes(bool bCadastroNovo)
		{
			try
			{
				m_bCadastroNovoAgente = bCadastroNovo;
				m_formFCadastroAgentes = new Frames.frmFCadastroAgentes(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, bCadastroNovo);
				InitializeEventsFormCadastroAgentes();
				if (bCadastroNovo)
					m_formFCadastroAgentes.setTextoGroupBox("Cadastro");
				else
					m_formFCadastroAgentes.setTextoGroupBox("Edição");
				m_formFCadastroAgentes.ShowDialog();
				m_formFCadastroAgentes = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region InitializeEventsFormCadastroAgentes
		private void InitializeEventsFormCadastroAgentes()
		{
			// Carrega dados Interface
			m_formFCadastroAgentes.eCallCarregaDadosInterface += new Frames.frmFCadastroAgentes.delCallCarregaDadosInterface(carregaDadosInterfaceCadastroAgentes);

			// Salva Dados Interface
			m_formFCadastroAgentes.eCallSalvaDadosInterface += new Frames.frmFCadastroAgentes.delCallSalvaDadosInterface(salvaDadosInterfaceCadastroAgencias);

			// Salva Dados BD
			m_formFCadastroAgentes.eCallSalvaDadosBD += new Frames.frmFCadastroAgentes.delCallSalvaDadosBD(salvaDadosBDCadastroAgencias);
		}
		#endregion
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceCadastroAgentes(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbSite, ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try
			{
				if (m_bCadastroNovoAgente == false)
				{
					tbNome.Text = m_strAgente;
					tbSite.Text = m_strSite;
					tbContato.Text = m_strNomeContato;
					tbEmail.Text = m_strEmail;
					tbTelefone.Text = m_strTelefone;
					tbFax.Text = m_strFax;
				}
				else
				{
					tbNome.Text = "";
					tbSite.Text = "";
					tbContato.Text = "";
					tbEmail.Text = "";
					tbTelefone.Text = "";
					tbFax.Text = "";
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
		#region Salvamento dos Dados
		#region Interface
		private void salvaDadosInterfaceCadastroAgencias(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbSite, ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try
			{
				m_strAgente = tbNome.Text;
				m_strSite = tbSite.Text;
				m_strNomeContato = tbContato.Text;
				m_strEmail = tbEmail.Text;
				m_strTelefone = tbTelefone.Text;
				m_strFax = tbFax.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBDCadastroAgencias(bool bModificado)
		{
			try
			{
				m_bCadastroAgenteModificado = bModificado;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentes.tbExportadoresAgentesRow dtrwTbExportadoresAgentes;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos;
				if (m_bCadastroNovoAgente)
				{
					calculaNovoIdAgente();
					dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.NewtbExportadoresAgentesRow();
					dtrwTbExportadoresAgentes.nIdExportador = m_nIdExportador;
					dtrwTbExportadoresAgentes.nIdAgente = m_nIdAgente;
					dtrwTbExportadoresAgentes.strNome = m_strAgente;
					dtrwTbExportadoresAgentes.strSite = m_strSite;

					m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.AddtbExportadoresAgentesRow(dtrwTbExportadoresAgentes);

					dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.NewtbExportadoresAgentesContatosRow();
					dtrwTbExportadoresAgentesContatos.nIdExportador = m_nIdExportador;
					dtrwTbExportadoresAgentesContatos.nIdAgente = m_nIdAgente;
					dtrwTbExportadoresAgentesContatos.nIdContato = 0;
					dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
					dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
					dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
					dtrwTbExportadoresAgentesContatos.strFax = m_strFax;

					m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.AddtbExportadoresAgentesContatosRow(dtrwTbExportadoresAgentesContatos);
				}
				else
				{
					dtrwTbExportadoresAgentes = m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador, m_nIdAgente);
					if (dtrwTbExportadoresAgentes != null)
					{
						dtrwTbExportadoresAgentes.strNome = m_strAgente;
						dtrwTbExportadoresAgentes.strSite = m_strSite;
					}
					dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, 0);
					if (dtrwTbExportadoresAgentesContatos != null)
					{
						dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
						dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
						dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
						dtrwTbExportadoresAgentesContatos.strFax = m_strFax;
					}
					else
					{
						dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.NewtbExportadoresAgentesContatosRow();
						dtrwTbExportadoresAgentesContatos.nIdExportador = m_nIdExportador;
						dtrwTbExportadoresAgentesContatos.nIdAgente = m_nIdAgente;
						dtrwTbExportadoresAgentesContatos.nIdContato = 0;
						dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
						dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
						dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
						dtrwTbExportadoresAgentesContatos.strFax = m_strFax;

						m_typDatSetTbExportadoresAgentesContatos.tbExportadoresAgentesContatos.AddtbExportadoresAgentesContatosRow(dtrwTbExportadoresAgentesContatos);
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
		#region Calcula Novo IdAgente
		private void calculaNovoIdAgente()
		{
			try
			{
				int nIdAgenteTemporario = 1;

				while(m_typDatSetTbExportadoresAgentes.tbExportadoresAgentes.FindBynIdExportadornIdAgente(m_nIdExportador,nIdAgenteTemporario) != null)
					nIdAgenteTemporario++;

				m_nIdAgente = nIdAgenteTemporario;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Listagem Contatos
		#region InitialiazeEventsFormLocalizacaoClientes
		private void InitialiazeEventsFormListaContatos()
		{
			// Carrega Dados BD Contatos
			m_formFListaContatos.eCallCarregaDadosBDContatos += new Frames.frmFListaContatos.delCallCarregaDadosBDContatos(carregaDadosBDContatos);

			// Carrega Dados Interface
			m_formFListaContatos.eCallCarregaDadosInterface += new Frames.frmFListaContatos.delCallCarregaDadosInterface(carregaDadosInterfaceListagem);

			// Carrega Dados Contato Interface
			m_formFListaContatos.eCallCarregaDadosContatoInterface += new Frames.frmFListaContatos.delCallCarregaDadosContatoInterface(carregaDadosContatoInterface);

			// Cancela Salvamento
			m_formFListaContatos.eCallCancelaSalvamento += new Frames.frmFListaContatos.delCallCancelaSalvamento(cancelaSalvamentoListagemContatos);

			// Salva Dados Lista Contato
			m_formFListaContatos.eCallSalvaDadosBD += new Frames.frmFListaContatos.delCallSalvaDadosBD(salvaDadosListagemContatos);

			// Edita Contato
			m_formFListaContatos.eCallEditaContato += new Frames.frmFListaContatos.delCallEditaContato(editaContato);

			// Cadastra Contato
			m_formFListaContatos.eCallCadastraContato += new Frames.frmFListaContatos.delCallCadastraContato(cadastraContato);

			// Exclui Contatos
			m_formFListaContatos.eCallExcluiContatos += new Frames.frmFListaContatos.delCallExcluiContatos(excluirContatos);
		}
		#endregion
		#region Show Dialog Listagem Contatos
		public void ShowDialogListagemContatos()
		{
			try
			{
				m_typDatSetTbExportadoresAgentesContatosTemporario = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos)m_typDatSetTbExportadoresAgentesContatos.Copy();
				m_formFListaContatos = new Frames.frmFListaContatos(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitialiazeEventsFormListaContatos();
				m_formFListaContatos.ShowDialog();
				if (m_formFListaContatos.m_bModificado)
				{
					if (m_formFListaAgentes == null)
					{
						salvaDadosBD(false);
						m_bModificado = true;
					}
				}
				m_formFListaContatos = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Edita Contato
		private void editaContato()
		{
			ShowDialogCadastroContatos(false);
		}
		#endregion
		#region Cadastra Contato
		private void cadastraContato()
		{
			calculaNovoIdContato();
			ShowDialogCadastroContatos(true);
		}
		#endregion
		#region Excluir Contatos
		private void excluirContatos(ref mdlComponentesGraficos.ListView lvContatos)
		{
			try
			{
				if (lvContatos.SelectedItems.Count > 0)
				{
					if ((System.Windows.Forms.MessageBox.Show("Deseja realmente apagar este(s) " + lvContatos.SelectedItems.Count.ToString() + " contato(s)?", "Agentes", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
					{
						mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos;
						foreach(System.Windows.Forms.ListViewItem lvItemContato in lvContatos.SelectedItems)
						{
							dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente,(int)lvItemContato.Tag);
							dtrwTbExportadoresAgentesContatos.Delete();
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
		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaDadosBDContatos(ref mdlComponentesGraficos.ListView lvContatos)
		{
			#region Pesquisa
			if (lvContatos.SelectedItems.Count > 0)
				m_nIdContato = (int)lvContatos.SelectedItems[0].Tag;
			// Cria a variável para conter o registro corrente
			mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwRowTbExportadoresAgentesContatos = null;
			if (m_nIdAgente != -1 && m_nIdContato != -1)
				dtrwRowTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador,m_nIdAgente, m_nIdContato);
			if (dtrwRowTbExportadoresAgentesContatos != null )
			{
				#endregion

				#region Salvando os items nos atributos de classe
				if (!dtrwRowTbExportadoresAgentesContatos.IsstrNomeNull())
					m_strNomeContato = dtrwRowTbExportadoresAgentesContatos.strNome;
				else
					m_strNomeContato = "";
				if (!dtrwRowTbExportadoresAgentesContatos.IsstrTelefoneNull())
					m_strTelefone = dtrwRowTbExportadoresAgentesContatos.strTelefone;
				else
					m_strTelefone = "";
				if (!dtrwRowTbExportadoresAgentesContatos.IsstrFaxNull())
					m_strFax = dtrwRowTbExportadoresAgentesContatos.strFax;
				else
					m_strFax = "";
				if (!dtrwRowTbExportadoresAgentesContatos.IsstrEmailNull())
					m_strEmail = dtrwRowTbExportadoresAgentesContatos.strEmail;
				else
					m_strEmail = "";
			}
			else
			{
				m_strEmail = "";
				m_strTelefone = "";
				m_strFax = "";
				m_strNomeContato = "";
			}

			m_strEmailCONTATO = m_strEmail;
			m_strTelefoneCONTATO = m_strTelefone;
			m_strFaxCONTATO = m_strFax;
			m_strNomeContatoCONTATO = m_strNomeContato;
			#endregion
		}
		#endregion
		#region Interface
		private void carregaDadosInterfaceListagem(ref mdlComponentesGraficos.ListView lvContatos, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir)
		{
			try
			{
				// List View Item
				System.Windows.Forms.ListViewItem lvItemContato;
				// Limpa os Items da List View
				lvContatos.Items.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwRowTbExportadoresAgentesContatos;
				// Preenche os itens da List View
				for (int nCont = 0 ; nCont < m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.Rows.Count ; nCont++)
				{
					dtrwRowTbExportadoresAgentesContatos = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow)m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.Rows[nCont];
					if ((dtrwRowTbExportadoresAgentesContatos.RowState != System.Data.DataRowState.Deleted) && (!dtrwRowTbExportadoresAgentesContatos.IsstrNomeNull()))
					{
						if (dtrwRowTbExportadoresAgentesContatos.nIdAgente == m_nIdAgente)
						{
							lvItemContato = lvContatos.Items.Add(dtrwRowTbExportadoresAgentesContatos.strNome);
							lvItemContato.Tag = dtrwRowTbExportadoresAgentesContatos.nIdContato;
							if ((int)lvItemContato.Tag == m_nIdContato)
							{
								lvItemContato.Selected = true;
							}
						}
					}
				}
				if (lvContatos.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
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
		private void carregaDadosContatoInterface(ref mdlComponentesGraficos.ListView lvDadosContato)
		{
			try
			{
				// List View Item
				System.Windows.Forms.ListViewItem lvItemDadosContato;
				// Limpa os Items da List View
				lvDadosContato.Items.Clear();

				#region Adicionando Items à ListView
				#region Nome Contato
				lvItemDadosContato = lvDadosContato.Items.Add("Nome: ");
				lvItemDadosContato.ForeColor = System.Drawing.Color.Red;
				lvItemDadosContato.UseItemStyleForSubItems = false;
				lvItemDadosContato.Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato.SubItems.Add(m_strNomeContato);
				lvItemDadosContato.SubItems[1].Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato = null;
				#endregion				
				#region Telefone
				lvItemDadosContato = lvDadosContato.Items.Add("Tel.: ");
				lvItemDadosContato.ForeColor = System.Drawing.Color.Red;
				lvItemDadosContato.UseItemStyleForSubItems = false;
				lvItemDadosContato.Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato.SubItems.Add(m_strTelefone);
				lvItemDadosContato.SubItems[1].Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato = null;
				#endregion
				#region Fax
				lvItemDadosContato = lvDadosContato.Items.Add("Fax: ");
				lvItemDadosContato.ForeColor = System.Drawing.Color.Red;
				lvItemDadosContato.UseItemStyleForSubItems = false;
				lvItemDadosContato.Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato.SubItems.Add(m_strFax);
				lvItemDadosContato.SubItems[1].Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato = null;
				#endregion
				#region Bairro
				lvItemDadosContato = lvDadosContato.Items.Add("E-Mail: ");
				lvItemDadosContato.ForeColor = System.Drawing.Color.Red;
				lvItemDadosContato.UseItemStyleForSubItems = false;
				lvItemDadosContato.Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato.SubItems.Add(m_strEmail);
				lvItemDadosContato.SubItems[1].Font = new System.Drawing.Font(lvItemDadosContato.Font, System.Drawing.FontStyle.Regular);
				lvItemDadosContato = null;
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
		#region Salvamento dos Dados
		private void salvaDadosListagemContatos(bool bModificado)
		{
			try
			{
				m_bCadastroContatoModificado = bModificado;
				m_typDatSetTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario;
			}
			catch
			{
			}
		}
		private void cancelaSalvamentoListagemContatos(bool bModificado)
		{
			//this.m_bModificadoLocalizacao = bModificado;
		}
		#endregion
		#endregion

		#region Cadastro Contatos Agentes
		#region Show Dialog Cadastro Contatos
		private void ShowDialogCadastroContatos(bool bCadastroNovo)
		{
			try
			{
				m_bCadastroNovoContato = bCadastroNovo;
				m_formFCadastroContatos = new Frames.frmFCadastroContatos(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, bCadastroNovo);
				InitializeEventsFormCadastroContatos();
				if (bCadastroNovo)
					m_formFCadastroContatos.setTextoGroupBox("Cadastro");
				else
					m_formFCadastroContatos.setTextoGroupBox("Edição");
				m_formFCadastroContatos.ShowDialog();
				m_formFCadastroContatos = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region InitializeEventsFormCadastroContatos
		private void InitializeEventsFormCadastroContatos()
		{
			// Carrega dados Interface
			m_formFCadastroContatos.eCallCarregaDadosInterface += new Frames.frmFCadastroContatos.delCallCarregaDadosInterface(carregaDadosInterfaceCadastroContatos);

			// Salva Dados Interface
			m_formFCadastroContatos.eCallSalvaDadosInterface += new Frames.frmFCadastroContatos.delCallSalvaDadosInterface(salvaDadosInterfaceCadastroContatos);

			// Salva Dados BD
			m_formFCadastroContatos.eCallSalvaDadosBD += new Frames.frmFCadastroContatos.delCallSalvaDadosBD(salvaDadosBDCadastroContatos);
		}
		#endregion
		#region Carregamento dos Dados
		#region Interface
		private void carregaDadosInterfaceCadastroContatos(ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try
			{
				if (m_bCadastroNovoContato == false)
				{
					tbContato.Text = m_strNomeContato;
					tbEmail.Text = m_strEmail;
					tbTelefone.Text = m_strTelefone;
					tbFax.Text = m_strFax;
				}
				else
				{
					tbContato.Text = "";
					tbEmail.Text = "";
					tbTelefone.Text = "";
					tbFax.Text = "";
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
		#region Salvamento dos Dados
		#region Interface
		private void salvaDadosInterfaceCadastroContatos(ref mdlComponentesGraficos.TextBox tbContato, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbTelefone, ref mdlComponentesGraficos.TextBox tbFax)
		{
			try
			{
				m_strNomeContato = tbContato.Text;
				m_strEmail = tbEmail.Text;
				m_strTelefone = tbTelefone.Text;
				m_strFax = tbFax.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBDCadastroContatos(bool bModificado)
		{
			try
			{
				m_bCadastroContatoModificado = bModificado;
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresAgentesContatos.tbExportadoresAgentesContatosRow dtrwTbExportadoresAgentesContatos;
				if (m_bCadastroNovoContato)
				{
					calculaNovoIdContato();

					dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.NewtbExportadoresAgentesContatosRow();
					dtrwTbExportadoresAgentesContatos.nIdExportador = m_nIdExportador;
					dtrwTbExportadoresAgentesContatos.nIdAgente = m_nIdAgente;
					dtrwTbExportadoresAgentesContatos.nIdContato = m_nIdContato;
					dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
					dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
					dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
					dtrwTbExportadoresAgentesContatos.strFax = m_strFax;

					m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.AddtbExportadoresAgentesContatosRow(dtrwTbExportadoresAgentesContatos);
				}
				else
				{
					dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador, m_nIdAgente, m_nIdContato);
					if (dtrwTbExportadoresAgentesContatos != null)
					{
						dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
						dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
						dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
						dtrwTbExportadoresAgentesContatos.strFax = m_strFax;
					}
					else
					{
						calculaNovoIdContato();
						dtrwTbExportadoresAgentesContatos = m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.NewtbExportadoresAgentesContatosRow();
						dtrwTbExportadoresAgentesContatos.nIdExportador = m_nIdExportador;
						dtrwTbExportadoresAgentesContatos.nIdAgente = m_nIdAgente;
						dtrwTbExportadoresAgentesContatos.nIdContato = m_nIdContato;
						dtrwTbExportadoresAgentesContatos.strNome = m_strNomeContato;
						dtrwTbExportadoresAgentesContatos.strEmail = m_strEmail;
						dtrwTbExportadoresAgentesContatos.strTelefone = m_strTelefone;
						dtrwTbExportadoresAgentesContatos.strFax = m_strFax;

						m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.AddtbExportadoresAgentesContatosRow(dtrwTbExportadoresAgentesContatos);
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
		#region Calcula Novo IdContato
		private void calculaNovoIdContato()
		{
			try
			{
				int nIdContatoTemporario = 1;

				while(m_typDatSetTbExportadoresAgentesContatosTemporario.tbExportadoresAgentesContatos.FindBynIdExportadornIdAgentenIdContato(m_nIdExportador,m_nIdAgente, nIdContatoTemporario) != null)
					nIdContatoTemporario++;

				m_nIdContato = nIdContatoTemporario;
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
		public void retornaValoresAgente(out string strNomeAgente, out string strSiteContato)
		{
			strNomeAgente = m_strAgente;
			strSiteContato = m_strSite;
		}
		public void retornaValoresAgente(out string strNomeAgente, out string strNomeContato, out string strTelefoneContato, out string strFaxContato, out string strEmailContato, out string strSiteContato)
		{
			strNomeAgente = m_strAgente;
			strSiteContato = m_strSite;
			if (m_bCadastroContatoModificado)
			{
				strNomeContato = m_strNomeContatoCONTATO;
				strTelefoneContato = m_strTelefoneCONTATO;
				strFaxContato = m_strFaxCONTATO;
				strEmailContato = m_strEmailCONTATO;
			}
			else
			{
				strTelefoneContato = m_strTelefone;
				strFaxContato = m_strFax;
				strEmailContato = m_strEmail;
				strNomeContato = m_strNomeContato;
			}
		}
		public void retornaValoresContato(out string strNomeContato, out string strTelefoneContato, out string strFaxContato, out string strEmailContato)
		{
			if (m_bCadastroContatoModificado)
			{
				strNomeContato = m_strNomeContatoCONTATO;
				strTelefoneContato = m_strTelefoneCONTATO;
				strFaxContato = m_strFaxCONTATO;
				strEmailContato = m_strEmailCONTATO;
			}
			else
			{
				strNomeContato = m_strNomeContato;
				strTelefoneContato = m_strTelefone;
				strFaxContato = m_strFax;
				strEmailContato = m_strEmail;
			}
		}
		public void retornaValoresAgente(out int nIdAgente, out string strNomeAgente, out int nIdContato, out string strNomeContato, out string strTelefoneContato, out string strFaxContato, out string strEmailContato, out string strSiteContato)
		{
			nIdAgente = m_nIdAgente;
			strNomeAgente = m_strAgente;
			strSiteContato = m_strSite;
			//if (m_bCadastroContatoModificado)
			//{
				nIdContato = m_nIdContato;
				strNomeContato = m_strNomeContatoCONTATO;
				strTelefoneContato = m_strTelefoneCONTATO;
				strFaxContato = m_strFaxCONTATO;
				strEmailContato = m_strEmailCONTATO;
			//}
			//else
			//{
			//	nIdContato = 0;
			//	strNomeContato = m_strNomeContato;
			//	strTelefoneContato = m_strTelefone;
			//	strFaxContato = m_strFax;
			//	strEmailContato = m_strEmail;
			//}
		}
		#endregion
	}
}