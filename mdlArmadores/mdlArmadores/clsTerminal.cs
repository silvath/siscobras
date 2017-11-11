using System;

namespace mdlArmadores
{
	/// <summary>
	/// Summary description for clsTerminal.
	/// </summary>
	public class clsTerminal
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;
			
			public bool m_bModificado = false;

			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			private int m_nIdSelect = -1;
			private int m_nIdSelectContato = -1;

			// Typed DataSets
			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTerminais m_typDatSetTerminais = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos m_typDatSetTerminaisContatos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos m_typDatSetTerminaisContatosCopy = null;
		#endregion
		#region Constructors and Destructors
			public clsTerminal(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = "";
				vCarregaDados();
			}

			public clsTerminal(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPE;
				vCarregaDados();
			}
		#endregion

		#region Carregamento de Dados
			private void vCarregaDados()
			{
				vCarregaDadosPe();
				vCarregaDadosTerminais();
				vCarregaDadosTerminaisContatos();
			}

			private void vCarregaDadosPe()
			{
				if (m_strIdPe != "")
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			}

			private void vCarregaDadosTerminais()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTerminais = m_cls_dba_ConnectionDB.GetTbTerminais(null,null,null,null,null);
			}

			private void vCarregaDadosTerminaisContatos()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTerminaisContatos = m_cls_dba_ConnectionDB.GetTbTerminaisContatos(null,null,null,null,null);
			}

		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosPe())
					if (bSalvaDadosTerminaisContatos())
						m_bModificado = bRetorno = bSalvaDadosTerminais();
				return(bRetorno);
			}

			private bool bSalvaDadosPe()
			{
				if (m_strIdPe != "")
				{
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPes);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				else
				{
					return(true);
				}
			}

			private bool bSalvaDadosTerminais()
			{
				m_cls_dba_ConnectionDB.SetTbTerminais(m_typDatSetTerminais);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosTerminaisContatos()
			{
				m_cls_dba_ConnectionDB.SetTbTerminaisContatos(m_typDatSetTerminaisContatos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public  void ShowDialog()
			{
				Formularios.frmFTerminais formFTerminais = new mdlArmadores.Formularios.frmFTerminais(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFTerminais);
				formFTerminais.ShowDialog();
			}
			
			private void vInitializeEvents(ref Formularios.frmFTerminais formFTerminais)
			{
				// Terminais Refresh
				formFTerminais.eCallTerminaisRefresh += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisRefresh(vTerminaisRefresh);

				// Carrega Terminal Selecionado
				formFTerminais.eCallTerminaisCarregaSelecionado += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisCarregaSelecionado(vCarregaDadosTerminalSelecionado);

				// Salva Terminal Selecionado
				formFTerminais.eCallTerminaisSalvaSelecionado += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisSalvaSelecionado(vSalvaDadosTerminalSelecionado);

				// Terminais Nova
				formFTerminais.eCallTerminaisNovo += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisNovo(ShowDialogNovo);

				// Terminais Editar
				formFTerminais.eCallTerminaisEditar += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisEditar(ShowDialogEditar);

				// Terminais Excluir 
				formFTerminais.eCallTerminaisExcluir += new mdlArmadores.Formularios.frmFTerminais.delCallTerminaisExcluir(bTerminaisExclui);

				// ShowDialog Contatos
				formFTerminais.eCallShowDialogContatos += new mdlArmadores.Formularios.frmFTerminais.delCallShowDialogContatos(ShowDialogContatos);

				// Salva Dados
				formFTerminais.eCallSalvaDados +=	new mdlArmadores.Formularios.frmFTerminais.delCallSalvaDados(bSalvaDados);

			}
		#endregion
		#region ShowDialogNovo
			private bool ShowDialogNovo()
			{
				Formularios.frmFTerminaisEdicao formFTerminalEdicao = new Formularios.frmFTerminaisEdicao(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFTerminalEdicao);
				formFTerminalEdicao.ShowDialog();
				return(formFTerminalEdicao.m_bModificado);
			}
				
			private void vInitializeEvents(ref Formularios.frmFTerminaisEdicao formFTerminalEdicao)
			{
				// Refresh Estados Brasileiros
				formFTerminalEdicao.eCallCarregaDadosEstadosBrasileiros += new mdlArmadores.Formularios.frmFTerminaisEdicao.delCallCarregaDadosEstadosBrasileiros(vRefreshEstadosBrasileiros);

				// Carrega dados
				formFTerminalEdicao.eCallCarregaDados += new mdlArmadores.Formularios.frmFTerminaisEdicao.delCallCarregaDados(vCarregaDadosTerminal);

				// Salva dados
				formFTerminalEdicao.eCallSalvaDados += new mdlArmadores.Formularios.frmFTerminaisEdicao.delCallSalvaDados(bSalvaDadosTerminal);
			}
		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdTerminal)
			{
				Formularios.frmFTerminaisEdicao formFTerminalEdicao = new Formularios.frmFTerminaisEdicao(m_strEnderecoExecutavel,nIdTerminal);
				vInitializeEvents(ref formFTerminalEdicao);
				formFTerminalEdicao.ShowDialog();
				return(formFTerminalEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogContatos
			public void ShowDialogContatos()
			{
				int nIdTerminal;
				vCarregaDadosTerminalSelecionado(out nIdTerminal);
				if (nIdTerminal == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogContatos(nIdTerminal))
						bSalvaDados();
				}
			}

			private bool ShowDialogContatos(int nIdTerminal)
			{
				m_typDatSetTerminaisContatosCopy = (mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos)m_typDatSetTerminaisContatos.Copy();
				Formularios.frmFContatos formFContatos = new mdlArmadores.Formularios.frmFContatos(m_strEnderecoExecutavel,nIdTerminal);
				vInitializeEvents(ref formFContatos);
				formFContatos.ShowDialog();
				if (!formFContatos.m_bModificado)
					m_typDatSetTerminaisContatos= m_typDatSetTerminaisContatosCopy;
				return(formFContatos.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFContatos formFContatos)
			{
				// Contatos Refresh
				formFContatos.eCallContatosRefresh += new mdlArmadores.Formularios.frmFContatos.delCallContatosRefresh(vContatosRefresh);

				// Carrega Contato Selecionado
				formFContatos.eCallContatosCarregaSelecionado += new mdlArmadores.Formularios.frmFContatos.delCallContatosCarregaSelecionado(vCarregaDadosTerminalContatoSelecionado);

				// Salva Contato Selecionado
				formFContatos.eCallContatosSalvaSelecionado += new mdlArmadores.Formularios.frmFContatos.delCallContatosSalvaSelecionado(vSalvaDadosTerminalContatoSelecionado);

				// Contato Novo
				formFContatos.eCallContatoNovo += new mdlArmadores.Formularios.frmFContatos.delCallContatoNovo(ShowDialogContatoNovo);

				// Contato Editar
				formFContatos.eCallContatoEditar += new mdlArmadores.Formularios.frmFContatos.delCallContatoEditar(ShowDialogContatoEditar);

				// Contato Exclui
				formFContatos.eCallContatosExcluir += new mdlArmadores.Formularios.frmFContatos.delCallContatosExcluir(bTerminalContatoExclui);
			}
		#endregion
		#region ShowDialogContatosNovo
			private bool ShowDialogContatoNovo(int nIdTerminal)
			{
				Formularios.frmFContatosEditar formFContatoEdicao = new mdlArmadores.Formularios.frmFContatosEditar(m_strEnderecoExecutavel,nIdTerminal);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}
					
			private void vInitializeEvents(ref Formularios.frmFContatosEditar formFContatoEdicao)
			{
				// Carrega Dados
				formFContatoEdicao.eCallCarregaDados += new mdlArmadores.Formularios.frmFContatosEditar.delCallCarregaDados(vCarregaDadosTerminalContato);

				// Salva Dados
				formFContatoEdicao.eCallSalvaDados += new mdlArmadores.Formularios.frmFContatosEditar.delCallSalvaDados(bSalvaDadosTerminalContato);
			}
		#endregion
		#region ShowDialogContatosEditar
			private bool ShowDialogContatoEditar(int nIdTerminal,int nIdContato)
			{
				Formularios.frmFContatosEditar formFContatoEdicao = new mdlArmadores.Formularios.frmFContatosEditar(m_strEnderecoExecutavel,nIdTerminal,nIdContato);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}
		#endregion

		#region Selecao Terminais
			private void vCarregaDadosTerminalSelecionado(out int nIdTerminal)
			{
				nIdTerminal = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdTerminalNull())
						nIdTerminal = dtrwPe.nIdTerminal;
				}
			}

			private void vSalvaDadosTerminalSelecionado(int nIdTerminal)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdTerminal = nIdTerminal;
				}
			}
		#endregion
		#region Terminais
			private void vTerminaisRefresh(ref System.Windows.Forms.ListView lvTerminais)
			{
				lvTerminais.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListTerminais = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwTerminal in m_typDatSetTerminais.tbTerminais.Rows)
					if ((dtrwTerminal.RowState != System.Data.DataRowState.Deleted) && (!dtrwTerminal.IsstrNomeNull()))
						if (!sortListTerminais.ContainsKey(dtrwTerminal.strNome))
							sortListTerminais.Add(dtrwTerminal.strNome,dtrwTerminal);

				// Insert
				for(int i = 0; i < sortListTerminais.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwTerminalInserir = (mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow)sortListTerminais.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvTerminais.Items.Add(dtrwTerminalInserir.strNome);
					lviInsert.Tag = dtrwTerminalInserir.nIdTerminal;
					if ((m_nIdSelect != -1) && (dtrwTerminalInserir.nIdTerminal == m_nIdSelect))
					{
						lviInsert.Selected = true;
						m_nIdSelect = -1;
					}
				}
			}

			private void vCarregaDadosTerminal(int nIdTerminal,out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out int nIdEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strTelefone = strFax = strEmail = strSite = "";
				nIdEstado = -1;

				mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwTerminal = m_typDatSetTerminais.tbTerminais.FindBynIdTerminal(nIdTerminal);
				if ((dtrwTerminal != null) && (dtrwTerminal.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwTerminal.IsstrNomeNull())
						strNome = dtrwTerminal.strNome;
					//strEndereco 
					if (!dtrwTerminal.IsmstrEnderecoNull())
						strEndereco = dtrwTerminal.mstrEndereco;
					//strCEP 
					if (!dtrwTerminal.IsstrCEPNull())
						strCEP = dtrwTerminal.strCEP;
					//strBairro 
					if (!dtrwTerminal.IsstrBairroNull())
						strBairro = dtrwTerminal.strBairro;
					//strCidade 
					if (!dtrwTerminal.IsmstrCidadeNull())
						strCidade = dtrwTerminal.mstrCidade;
					//nIdEstado
					if (!dtrwTerminal.IsnIdEstadoNull())
						nIdEstado = dtrwTerminal.nIdEstado;
					//strTelefone
					if (!dtrwTerminal.IsstrTelefoneNull())
						strTelefone = dtrwTerminal.strTelefone;
					//strFax 
					if (!dtrwTerminal.IsstrFaxNull())
						strFax = dtrwTerminal.strFax;
					//strEmail 
					if (!dtrwTerminal.IsstrEmailNull())
						strEmail = dtrwTerminal.strEmail;
					//strSite 
					if (!dtrwTerminal.IsstrSiteNull())
						strSite = dtrwTerminal.strSite;
				}
			}

			private bool bSalvaDadosTerminal(int nIdTerminal,string strNome,string strEndereco,string strCEP,string strBairro,string strCidade,int nIdEstado,string strTelefone,string strFax,string strEmail,string strSite)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do terminal.");
					return(false);
				}

				if (nIdEstado == -2)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher corretamente o campo Estado.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwTerminal = m_typDatSetTerminais.tbTerminais.FindBynIdTerminal(nIdTerminal);
				if (bAdd = (dtrwTerminal == null))
				{
					dtrwTerminal = m_typDatSetTerminais.tbTerminais.NewtbTerminaisRow();
					dtrwTerminal.nIdTerminal = nNextIdTerminal();
				}
				dtrwTerminal.strNome = strNome;
				dtrwTerminal.mstrEndereco = strEndereco;
				dtrwTerminal.strCEP = strCEP;
				dtrwTerminal.strBairro = strBairro;
				dtrwTerminal.mstrCidade = strCidade;
				dtrwTerminal.nIdEstado = nIdEstado;
				dtrwTerminal.strTelefone = strTelefone;
				dtrwTerminal.strFax = strFax;
				dtrwTerminal.strEmail = strEmail;
				dtrwTerminal.strSite = strSite;

				m_nIdSelect = dtrwTerminal.nIdTerminal;

				if (bAdd)
					m_typDatSetTerminais.tbTerminais.AddtbTerminaisRow(dtrwTerminal);
				return(true);
			}
					
			private int nNextIdTerminal()
			{
				int nRetorno = 1;
				while(m_typDatSetTerminais.tbTerminais.FindBynIdTerminal(nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTerminaisExclui(ref System.Collections.ArrayList arlTerminais,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) terminais(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Terminais
				for(int i = m_typDatSetTerminais.tbTerminais.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow dtrwTerminal = (mdlDataBaseAccess.Tabelas.XsdTbTerminais.tbTerminaisRow)m_typDatSetTerminais.tbTerminais.Rows[i];
					if (dtrwTerminal.RowState != System.Data.DataRowState.Deleted)
						if (arlTerminais.Contains(dtrwTerminal.nIdTerminal))
							dtrwTerminal.Delete();
				}

				// TODO: Apagar Contatos
				return(true);
			}
		#endregion
		#region Selecao Contatos
			private void vCarregaDadosTerminalContatoSelecionado(out int nIdContato)
			{
				nIdContato = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdTerminalContatoNull())
						nIdContato = dtrwPe.nIdTerminalContato;
				}
			}

			private void vSalvaDadosTerminalContatoSelecionado(int nIdContato)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdTerminalContato = nIdContato;
				}
			}
		#endregion
		#region Contatos
			private void vContatosRefresh(int nIdTerminal,ref System.Windows.Forms.ListView lvContatos)
			{
				lvContatos.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListContatos = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow dtrwContato in m_typDatSetTerminaisContatos.tbTerminaisContatos.Rows)
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdTerminal == nIdTerminal) && (!dtrwContato.IsstrNomeNull()))
						if (!sortListContatos.ContainsKey(dtrwContato.strNome))
							sortListContatos.Add(dtrwContato.strNome,dtrwContato);

				// Insert
				for(int i = 0; i < sortListContatos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow dtrwContatoInserir = (mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow)sortListContatos.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvContatos.Items.Add(dtrwContatoInserir.strNome);
					lviInsert.Tag = dtrwContatoInserir.nIdContato;
					if ((m_nIdSelectContato != -1) && (dtrwContatoInserir.nIdContato == m_nIdSelectContato))
					{
						lviInsert.Selected = true;
						m_nIdSelectContato = -1;
					}
				}
			}

			private void vCarregaDadosTerminalContato(int nIdTerminal,int nIdContato,out string strNome,out string strTelefone,out string strFax,out string strEmail)
			{
				strNome = strTelefone = strFax = strEmail = "";

				mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow dtrwContato = m_typDatSetTerminaisContatos.tbTerminaisContatos.FindBynIdTerminalnIdContato(nIdTerminal,nIdContato);
				if ((dtrwContato != null) && (dtrwContato.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwContato.IsstrNomeNull())
						strNome = dtrwContato.strNome;
					//strTelefone
					if (!dtrwContato.IsstrTelefoneNull())
						strTelefone = dtrwContato.strTelefone;
					//strFax 
					if (!dtrwContato.IsstrFaxNull())
						strFax = dtrwContato.strFax;
					//strEmail 
					if (!dtrwContato.IsstrEmailNull())
						strEmail = dtrwContato.strEmail;
				}
			}

			private bool bSalvaDadosTerminalContato(int nIdTerminal,int nIdContato,string strNome,string strTelefone,string strFax,string strEmail)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do contato.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow dtrwContato = m_typDatSetTerminaisContatos.tbTerminaisContatos.FindBynIdTerminalnIdContato(nIdTerminal,nIdContato);
				if (bAdd = (dtrwContato == null))
				{
					dtrwContato = m_typDatSetTerminaisContatos.tbTerminaisContatos.NewtbTerminaisContatosRow();
					dtrwContato.nIdTerminal = nIdTerminal;
					dtrwContato.nIdContato = nNextIdTerminalContato(nIdTerminal);
				}
				dtrwContato.strNome = strNome;
				dtrwContato.strTelefone = strTelefone;
				dtrwContato.strFax = strFax;
				dtrwContato.strEmail = strEmail;

				m_nIdSelectContato = dtrwContato.nIdContato;

				if (bAdd)
					m_typDatSetTerminaisContatos.tbTerminaisContatos.AddtbTerminaisContatosRow(dtrwContato);
				return(true);
			}
						
			private int nNextIdTerminalContato(int nIdTerminal)
			{
				int nRetorno = 1;
				while(m_typDatSetTerminaisContatos.tbTerminaisContatos.FindBynIdTerminalnIdContato(nIdTerminal,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTerminalContatoExclui(int nIdTerminal,ref System.Collections.ArrayList arlContatos,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) contato(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Contatos
				for(int i = m_typDatSetTerminaisContatos.tbTerminaisContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbTerminaisContatos.tbTerminaisContatosRow)m_typDatSetTerminaisContatos.tbTerminaisContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdTerminal == nIdTerminal))
						if (arlContatos.Contains(dtrwContato.nIdContato))
							dtrwContato.Delete();
				}
				return(true);
			}
		#endregion
		#region Estados Brasileiros
			private void vRefreshEstadosBrasileiros(ref mdlComponentesGraficos.ComboBox cbEstadosBrasileiros)
			{
				cbEstadosBrasileiros.Clear();
		                
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros typDatSetEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,null,null);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwEstadoBrasileiro in typDatSetEstadosBrasileiros.tbEstadosBrasileiros.Rows)
					cbEstadosBrasileiros.AddItem(dtrwEstadoBrasileiro.strNome,dtrwEstadoBrasileiro.nIdEstado);
			}

			private string strRetornaSiglaEstadoBrasileiro(int nIdEstado)
			{
				string strReturn = "";
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros typDatSetEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwEstado = typDatSetEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(nIdEstado);
				if (dtrwEstado != null)
					strReturn = dtrwEstado.strSigla;
				return(strReturn);
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strTerminalNome,out string strTerminalEndereco,out string strTerminalCEP,out string strTerminalBairro,out string strTerminalCidade,out string strTerminalEstado,out string strTerminalTelefone,out string strTerminalFax,out string strTerminalEmail,out string strTerminalSite,out string strContatoNome,out string strContatoTelefone,out string strContatoFax,out string strContatoEmail)
			{
				strTerminalNome = strTerminalEndereco = strTerminalCEP = strTerminalBairro = strTerminalCidade = strTerminalEstado = strTerminalTelefone = strTerminalFax = strTerminalEmail = strTerminalSite = strContatoNome = strContatoTelefone = strContatoFax = strContatoEmail = "";
				int nIdTerminal;
				vCarregaDadosTerminalSelecionado(out nIdTerminal);
				if (nIdTerminal != -1)
				{
					int nIdEstado;
					vCarregaDadosTerminal(nIdTerminal,out strTerminalNome,out strTerminalEndereco,out strTerminalCEP,out strTerminalBairro,out strTerminalCidade,out nIdEstado,out strTerminalTelefone,out strTerminalFax,out strTerminalEmail,out strTerminalSite);
					strTerminalEstado = strRetornaSiglaEstadoBrasileiro(nIdEstado);
					int nIdContato;
					vCarregaDadosTerminalContatoSelecionado(out nIdContato);
					if (nIdContato != -1)
						vCarregaDadosTerminalContato(nIdTerminal,nIdContato,out strContatoNome,out strContatoTelefone,out strContatoFax,out strContatoEmail);
				}
			}
		#endregion
	}
}
