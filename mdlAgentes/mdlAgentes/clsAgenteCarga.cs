using System;

namespace mdlAgentes
{
	/// <summary>
	/// Summary description for clsAgenteCarga.
	/// </summary>
	public class clsAgenteCarga
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
			private mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas m_typDatSetAgentesCargas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos m_typDatSetAgentesCargasContatos = null;
		
		#endregion
		#region Constructors and Destructors
			public clsAgenteCarga(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = "";
				vCarregaDados();
			}

			public clsAgenteCarga(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
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
				vCarregaDadosAgentesCargas();
				vCarregaDadosAgentesCargasContatos();
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

			private void vCarregaDadosAgentesCargas()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetAgentesCargas = m_cls_dba_ConnectionDB.GetTbAgentesCargas(null,null,null,null,null);
			}
			
			private void vCarregaDadosAgentesCargasContatos()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetAgentesCargasContatos = m_cls_dba_ConnectionDB.GetTbAgentesCargasContatos(null,null,null,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosPe())
					if (bSalvaDadosAgentesCargaContatos())
						m_bModificado = bRetorno = bSalvaDadosAgentesCarga();
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

			private bool bSalvaDadosAgentesCarga()
			{
				m_cls_dba_ConnectionDB.SetTbAgentesCargas(m_typDatSetAgentesCargas);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosAgentesCargaContatos()
			{
				m_cls_dba_ConnectionDB.SetTbAgentesCargasContatos(m_typDatSetAgentesCargasContatos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				Formularios.frmFAgentesCarga formFAgentesCarga = new mdlAgentes.Formularios.frmFAgentesCarga(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFAgentesCarga);
				formFAgentesCarga.ShowDialog();
			}
			
			private void vInitializeEvents(ref Formularios.frmFAgentesCarga formFAgentesCarga)
			{
				// Agentes Carga Refresh 
				formFAgentesCarga.eCallAgentesCargaRefresh += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaRefresh(vAgentesCargaRefresh);

				// Carrega Agente Carga Selecionado 
				formFAgentesCarga.eCallAgentesCargaCarregaSelecionado += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaCarregaSelecionado(vCarregaDadosAgenteCargaSelecionado);

				// Salva Agente Carga Selecionado 
				formFAgentesCarga.eCallAgentesCargaSalvaSelecionado += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaSalvaSelecionado(vSalvaDadosAgenteCargaSelecionado);

				// Agente Carga Novo 
				formFAgentesCarga.eCallAgentesCargaNovo += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaNovo(ShowDialogAgenteCargaNovo);

				// Agente Carga Editar 
				formFAgentesCarga.eCallAgentesCargaEditar += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaEditar(ShowDialogAgenteCargaEditar);

				// Agente Carga Excluir
				formFAgentesCarga.eCallAgentesCargaExcluir += new mdlAgentes.Formularios.frmFAgentesCarga.delCallAgentesCargaExcluir(bAgentesCargasExclui);

				// ShowDialog Contatos
				formFAgentesCarga.eCallShowDialogContatos += new mdlAgentes.Formularios.frmFAgentesCarga.delCallShowDialogContatos(ShowDialogContatos);

				// Salva Dados
				formFAgentesCarga.eCallSalvaDados += new mdlAgentes.Formularios.frmFAgentesCarga.delCallSalvaDados(bSalvaDados);
			}
		#endregion
		#region ShowDialogNovo
			public bool ShowDialogAgenteCargaNovo()
			{
				Formularios.frmFAgentesCargaEdicao formFAgenteCargaNovo = new mdlAgentes.Formularios.frmFAgentesCargaEdicao(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFAgenteCargaNovo);
				formFAgenteCargaNovo.ShowDialog();
				return(formFAgenteCargaNovo.m_bModificado);
			}
			
			private void vInitializeEvents(ref Formularios.frmFAgentesCargaEdicao formFAgenteCargaNovo)
			{
				// Carrega dados dos Estados Brasileiros
				formFAgenteCargaNovo.eCallCarregaDadosEstadosBrasileiros += new mdlAgentes.Formularios.frmFAgentesCargaEdicao.delCallCarregaDadosEstadosBrasileiros(vRefreshEstadosBrasileiros);

				// Carrega dados do Agente de Carga
				formFAgenteCargaNovo.eCallCarregaDados += new mdlAgentes.Formularios.frmFAgentesCargaEdicao.delCallCarregaDados(vCarregaDadosAgenteCarga);

				// Salva dados do Agente de Carga
				formFAgenteCargaNovo.eCallSalvaDados += new mdlAgentes.Formularios.frmFAgentesCargaEdicao.delCallSalvaDados(bSalvaDadosAgenteCarga);
			}
		#endregion
		#region ShowDialogEditar
			public bool ShowDialogAgenteCargaEditar(int nIdAgenteCarga)
			{
				Formularios.frmFAgentesCargaEdicao formFAgenteCargaNovo = new mdlAgentes.Formularios.frmFAgentesCargaEdicao(m_strEnderecoExecutavel,nIdAgenteCarga);
				vInitializeEvents(ref formFAgenteCargaNovo);
				formFAgenteCargaNovo.ShowDialog();
				return(formFAgenteCargaNovo.m_bModificado);
			}
		#endregion
		#region ShowDialogContatos
			public void ShowDialogContatos()
			{
				int nIdAgenteCarga;
				vCarregaDadosAgenteCargaSelecionado(out nIdAgenteCarga);
				if (nIdAgenteCarga == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogContatos(nIdAgenteCarga))
						bSalvaDados();
				}
			}

			private bool ShowDialogContatos(int nIdAgenteCarga)
			{
				Formularios.frmFAgentesCargaContatos formFAgentesCargaContatos = new mdlAgentes.Formularios.frmFAgentesCargaContatos(m_strEnderecoExecutavel,nIdAgenteCarga);
				vInitalizeEvents(ref formFAgentesCargaContatos);
				formFAgentesCargaContatos.ShowDialog();
				return(formFAgentesCargaContatos.m_bModificado);
			}

			private void vInitalizeEvents(ref Formularios.frmFAgentesCargaContatos formFAgentesCargaContatos)
			{
				// Contatos Refresh
				formFAgentesCargaContatos.eCallContatosRefresh += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatosRefresh(vContatosRefresh);

				// Carrega Contato Selecionado 
				formFAgentesCargaContatos.eCallContatosCarregaSelecionado += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatosCarregaSelecionado(vCarregaDadosAgenteCargaContatoSelecionado);

				// Salva Contato Selecionado
				formFAgentesCargaContatos.eCallContatosSalvaSelecionado += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatosSalvaSelecionado(vSalvaDadosAgenteCargaContatoSelecionado);

				// Contato Novo
				formFAgentesCargaContatos.eCallContatoNovo += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatoNovo(ShowDialogAgenteCargaContatoNovo);

				// Contato Editar
				formFAgentesCargaContatos.eCallContatoEditar += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatoEditar(ShowDialogAgenteCargaContatoEditar);

				// Contato Exclui
				formFAgentesCargaContatos.eCallContatosExcluir += new mdlAgentes.Formularios.frmFAgentesCargaContatos.delCallContatosExcluir(bAgentesCargasContatoExclui);
			}
		#endregion
		#region ShowDailogContatoNovo
			private bool ShowDialogAgenteCargaContatoNovo(int nIdAgenteCarga)
			{
				Formularios.frmFAgentesCargasContatosEdicao formFContatoEdicao = new mdlAgentes.Formularios.frmFAgentesCargasContatosEdicao(m_strEnderecoExecutavel,nIdAgenteCarga);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFAgentesCargasContatosEdicao formFContatoEdicao)
			{
				// Carrega Dados Contato
				formFContatoEdicao.eCallCarregaDados += new mdlAgentes.Formularios.frmFAgentesCargasContatosEdicao.delCallCarregaDados(vCarregaDadosAgenteCargaContato);

				// Salva Dados Contato
				formFContatoEdicao.eCallSalvaDados += new mdlAgentes.Formularios.frmFAgentesCargasContatosEdicao.delCallSalvaDados(bSalvaDadosAgenteCargaContato);
			}
		#endregion
		#region ShowDailogContatoEditar
			private bool ShowDialogAgenteCargaContatoEditar(int nIdAgenteCarga,int nIdContato)
			{
				Formularios.frmFAgentesCargasContatosEdicao formFContatoEdicao = new mdlAgentes.Formularios.frmFAgentesCargasContatosEdicao(m_strEnderecoExecutavel,nIdAgenteCarga,nIdContato);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}
		#endregion

		#region Selecao Agentes Carga
			private void vCarregaDadosAgenteCargaSelecionado(out int nIdAgenteCarga)
			{
				nIdAgenteCarga = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdAgenteCargaNull())
						nIdAgenteCarga = dtrwPe.nIdAgenteCarga;
				}
			}

			private void vSalvaDadosAgenteCargaSelecionado(int nIdAgenteCarga)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdAgenteCarga = nIdAgenteCarga;
				}
			}
		#endregion
		#region Agentes Carga
			private void vAgentesCargaRefresh(ref System.Windows.Forms.ListView lvAgentesCarga)
			{
				lvAgentesCarga.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListAgentesCarga = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwAgenteCarga in m_typDatSetAgentesCargas.tbAgentesCargas.Rows)
					if ((dtrwAgenteCarga.RowState != System.Data.DataRowState.Deleted) && (!dtrwAgenteCarga.IsstrNomeNull()))
						if (!sortListAgentesCarga.ContainsKey(dtrwAgenteCarga.strNome))
							sortListAgentesCarga.Add(dtrwAgenteCarga.strNome,dtrwAgenteCarga);

				// Insert
				for(int i = 0; i < sortListAgentesCarga.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwAgentesCargaInserir = (mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow)sortListAgentesCarga.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviAgente = lvAgentesCarga.Items.Add(dtrwAgentesCargaInserir.strNome);
					lviAgente.Tag = dtrwAgentesCargaInserir.nIdAgenteCarga;
					if ((m_nIdSelect != -1) && (dtrwAgentesCargaInserir.nIdAgenteCarga == m_nIdSelect))
					{
						lviAgente.Selected = true;
						m_nIdSelect = -1;
					}
				}
			}

			private void vCarregaDadosAgenteCarga(int nIdAgenteCarga,out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out int nIdEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strTelefone = strFax = strEmail = strSite = "";
				nIdEstado = -1;

				mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwAgenteCarga = m_typDatSetAgentesCargas.tbAgentesCargas.FindBynIdAgenteCarga(nIdAgenteCarga);
				if ((dtrwAgenteCarga != null) && (dtrwAgenteCarga.RowState != System.Data.DataRowState.Deleted))
				{
                    //strNome 
					if (!dtrwAgenteCarga.IsstrNomeNull())
						strNome = dtrwAgenteCarga.strNome;
					//strEndereco 
					if (!dtrwAgenteCarga.IsmstrEnderecoNull())
						strEndereco = dtrwAgenteCarga.mstrEndereco;
					//strCEP 
					if (!dtrwAgenteCarga.IsstrCEPNull())
						strCEP = dtrwAgenteCarga.strCEP;
					//strBairro 
					if (!dtrwAgenteCarga.IsstrBairroNull())
						strBairro = dtrwAgenteCarga.strBairro;
					//strCidade 
					if (!dtrwAgenteCarga.IsmstrCidadeNull())
						strCidade = dtrwAgenteCarga.mstrCidade;
					//nIdEstado
					if (!dtrwAgenteCarga.IsnIdEstadoNull())
						nIdEstado = dtrwAgenteCarga.nIdEstado;
					//strTelefone
					if (!dtrwAgenteCarga.IsstrTelefoneNull())
						strTelefone = dtrwAgenteCarga.strTelefone;
					//strFax 
					if (!dtrwAgenteCarga.IsstrFaxNull())
						strFax = dtrwAgenteCarga.strFax;
					//strEmail 
					if (!dtrwAgenteCarga.IsstrEmailNull())
						strEmail = dtrwAgenteCarga.strEmail;
					//strSite 
					if (!dtrwAgenteCarga.IsstrSiteNull())
						strSite = dtrwAgenteCarga.strSite;
				}
			}

			private bool bSalvaDadosAgenteCarga(int nIdAgenteCarga,string strNome,string strEndereco,string strCEP,string strBairro,string strCidade,int nIdEstado,string strTelefone,string strFax,string strEmail,string strSite)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do agente de carga.");
					return(false);
				}

				if (nIdEstado == -2)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher corretamente o campo Estado.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwAgenteCarga = m_typDatSetAgentesCargas.tbAgentesCargas.FindBynIdAgenteCarga(nIdAgenteCarga);
				if (bAdd = (dtrwAgenteCarga == null))
				{
					dtrwAgenteCarga = m_typDatSetAgentesCargas.tbAgentesCargas.NewtbAgentesCargasRow();
					dtrwAgenteCarga.nIdAgenteCarga = nNextIdAgenteCarga();
				}
				dtrwAgenteCarga.strNome = strNome;
				dtrwAgenteCarga.mstrEndereco = strEndereco;
				dtrwAgenteCarga.strCEP = strCEP;
				dtrwAgenteCarga.strBairro = strBairro;
				dtrwAgenteCarga.mstrCidade = strCidade;
				dtrwAgenteCarga.nIdEstado = nIdEstado;
				dtrwAgenteCarga.strTelefone = strTelefone;
				dtrwAgenteCarga.strFax = strFax;
				dtrwAgenteCarga.strEmail = strEmail;
				dtrwAgenteCarga.strSite = strSite;

				m_nIdSelect = dtrwAgenteCarga.nIdAgenteCarga;

				if (bAdd)
					m_typDatSetAgentesCargas.tbAgentesCargas.AddtbAgentesCargasRow(dtrwAgenteCarga);
				return(true);
			}
			
			private int nNextIdAgenteCarga()
			{
				int nRetorno = 1;
				while(m_typDatSetAgentesCargas.tbAgentesCargas.FindBynIdAgenteCarga(nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bAgentesCargasExclui(ref System.Collections.ArrayList arlAgentesCargas,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) agente(s) de cargas ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Agentes
				for(int i = m_typDatSetAgentesCargas.tbAgentesCargas.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow dtrwAgenteCarga = (mdlDataBaseAccess.Tabelas.XsdTbAgentesCargas.tbAgentesCargasRow)m_typDatSetAgentesCargas.tbAgentesCargas.Rows[i];
					if (dtrwAgenteCarga.RowState != System.Data.DataRowState.Deleted)
						if (arlAgentesCargas.Contains(dtrwAgenteCarga.nIdAgenteCarga))
							dtrwAgenteCarga.Delete();
				}

				// Contatos
				for(int i = m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow)m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.Rows[i];
					if (dtrwContato.RowState != System.Data.DataRowState.Deleted)
						if (arlAgentesCargas.Contains(dtrwContato.nIdAgenteCarga))
							dtrwContato.Delete();
				}
				return(true);
			}
		#endregion
		#region Selecao Contatos
			private void vCarregaDadosAgenteCargaContatoSelecionado(out int nIdContato)
			{
				nIdContato = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdAgenteCargaContatoNull())
						nIdContato = dtrwPe.nIdAgenteCargaContato;
				}
			}

			private void vSalvaDadosAgenteCargaContatoSelecionado(int nIdContato)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdAgenteCargaContato = nIdContato;
				}
			}
		#endregion
		#region Contatos
			private void vContatosRefresh(int nIdAgenteCarga,ref System.Windows.Forms.ListView lvContatos)
			{
				lvContatos.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListContatos = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContato in m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.Rows)
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdAgenteCarga == nIdAgenteCarga) && (!dtrwContato.IsstrNomeNull()))
						if (!sortListContatos.ContainsKey(dtrwContato.strNome))
							sortListContatos.Add(dtrwContato.strNome,dtrwContato);

				// Insert
				for(int i = 0; i < sortListContatos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContatoInserir = (mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow)sortListContatos.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvContatos.Items.Add(dtrwContatoInserir.strNome);
					lviInsert.Tag = dtrwContatoInserir.nIdContato;
					if ((m_nIdSelectContato != -1) && (dtrwContatoInserir.nIdContato == m_nIdSelectContato))
					{
						lviInsert.Selected = true;
						m_nIdSelectContato = -1;
					}
				}
			}

			private void vCarregaDadosAgenteCargaContato(int nIdAgenteCarga,int nIdContato,out string strNome,out string strTelefone,out string strFax,out string strEmail)
			{
				strNome = strTelefone = strFax = strEmail = "";

				mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContato = m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.FindBynIdAgenteCarganIdContato(nIdAgenteCarga,nIdContato);
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

			private bool bSalvaDadosAgenteCargaContato(int nIdAgenteCarga,int nIdContato,string strNome,string strTelefone,string strFax,string strEmail)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do contato.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContato = m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.FindBynIdAgenteCarganIdContato(nIdAgenteCarga,nIdContato);
				if (bAdd = (dtrwContato == null))
				{
					dtrwContato = m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.NewtbAgentesCargasContatosRow();
					dtrwContato.nIdAgenteCarga = nIdAgenteCarga;
					dtrwContato.nIdContato = nNextIdAgenteCargaContato(nIdAgenteCarga);
				}
				dtrwContato.strNome = strNome;
				dtrwContato.strTelefone = strTelefone;
				dtrwContato.strFax = strFax;
				dtrwContato.strEmail = strEmail;

				m_nIdSelectContato = dtrwContato.nIdContato;

				if (bAdd)
					m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.AddtbAgentesCargasContatosRow(dtrwContato);
				return(true);
			}
				
			private int nNextIdAgenteCargaContato(int nIdAgenteCarga)
			{
				int nRetorno = 1;
				while(m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.FindBynIdAgenteCarganIdContato(nIdAgenteCarga,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bAgentesCargasContatoExclui(int nIdAgenteCarga,ref System.Collections.ArrayList arlContatos,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) contato(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Contatos
				for(int i = m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbAgentesCargasContatos.tbAgentesCargasContatosRow)m_typDatSetAgentesCargasContatos.tbAgentesCargasContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdAgenteCarga == nIdAgenteCarga))
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
			public void vRetornaValores(out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out string strEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite,out string strContatoNome,out string strContatoTelefone,out string strContatoFax,out string strContatoEmail)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strEstado = strTelefone = strFax = strEmail = strSite = strContatoNome = strContatoTelefone = strContatoFax = strContatoEmail = "";
				int nIdAgenteCarga;
				vCarregaDadosAgenteCargaSelecionado(out nIdAgenteCarga);
				if (nIdAgenteCarga != -1)
				{
					int nIdEstado;
					vCarregaDadosAgenteCarga(nIdAgenteCarga,out strNome,out strEndereco,out strCEP,out strBairro,out strCidade,out nIdEstado,out strTelefone,out strFax,out strEmail,out strSite);
					strEstado = strRetornaSiglaEstadoBrasileiro(nIdEstado);
					int nIdContato;
					vCarregaDadosAgenteCargaContatoSelecionado(out nIdContato);
					if (nIdContato != -1)
						vCarregaDadosAgenteCargaContato(nIdAgenteCarga,nIdContato,out strContatoNome,out strContatoTelefone,out strContatoFax,out strContatoEmail);
				}
			}
		#endregion
	}
}
