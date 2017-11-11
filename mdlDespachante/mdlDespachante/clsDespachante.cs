using System;

namespace mdlDespachante
{
	/// <summary>
	/// Summary description for clsDespachante.
	/// </summary>
	public class clsDespachante
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private int m_nIdExportador = -1;
		private string m_strIdPe = "";

		private bool m_bContatosDespachantes = false;

		// Typed DataSets
		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbDespachantes m_typdatSetDespachantes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos m_typDatSetDespachantesContatos = null;

		// Typed DataSets Copy
		private mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos m_typDatSetDespachantesContatosCopy = null;
		#endregion
		#region Propriedades
			
		#endregion
		#region Constructors and Destructors
			public clsDespachante(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = "";
				vCarregaDados();
			}

			public clsDespachante(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPE;
				vCarregaDados();
			}
		#endregion

		#region Carregamento Dos Dados
			private void vCarregaDados()
			{
				vCarregaDadosPe();
				vCarregaDadosDespachantes();
				vCarregaDadosDespachantesContatos();
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

			private void vCarregaDadosDespachantes()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typdatSetDespachantes = m_cls_dba_ConnectionDB.GetTbDespachantes(null,null,null,null,null);
			}

			private void vCarregaDadosDespachantesContatos()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetDespachantesContatos = m_cls_dba_ConnectionDB.GetTbDespachantesContatos(null,null,null,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosPe())
					if (bSalvaDadosDespachantesContatos())
						m_bModificado = bRetorno = bSalvaDadosDespachantes();
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

			private bool bSalvaDadosDespachantes()
			{
				m_cls_dba_ConnectionDB.SetTbDespachantes(m_typdatSetDespachantes);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosDespachantesContatos()
			{
				m_cls_dba_ConnectionDB.SetTbDespachantesContatos(m_typDatSetDespachantesContatos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			Formularios.frmFDespachantes formFDespachantes = new mdlDespachante.Formularios.frmFDespachantes(m_strEnderecoExecutavel);
			vInitializeEvents(ref formFDespachantes);
			formFDespachantes.ShowDialog();
		}

		private void vInitializeEvents(ref Formularios.frmFDespachantes formFDespachantes)
		{
			// Despachantes Refresh
			formFDespachantes.eCallDespachantesRefresh += new mdlDespachante.Formularios.frmFDespachantes.delCallDespachantesRefresh(vDespachantesRefresh);

			// Despachante Carrega Selecionada
			formFDespachantes.eCallDespachanteCarregaSelecionada += new mdlDespachante.Formularios.frmFDespachantes.delCallDespachanteCarregaSelecionada(vCarregaDadosDespachanteSelecionado);

			// Despachante Salva Selecionada
			formFDespachantes.eCallDespachanteSalvaSelecionada += new mdlDespachante.Formularios.frmFDespachantes.delCallDespachanteSalvaSelecionada(vSalvaDadosDespachanteSelecionado);

			// Despachante Nova
			formFDespachantes.eCallDespachantesNovo += new mdlDespachante.Formularios.frmFDespachantes.delCallDespachantesNovo(ShowDialogNovo);

			// Despachante Editar
			formFDespachantes.eCallDespachantesEditar += new mdlDespachante.Formularios.frmFDespachantes.delCallDespachantesEditar(ShowDialogEditar);

			// Despachantes Excluir 
			formFDespachantes.eCallDespachantesExcluir +=new mdlDespachante.Formularios.frmFDespachantes.delCallDespachantesExcluir(bDespachantesExclui);

			// ShowDialog Contatos
			formFDespachantes.eCallShowDialogContatos += new mdlDespachante.Formularios.frmFDespachantes.delCallShowDialogContatos(ShowDialogContatos);
				
			// Salva Dados
			formFDespachantes.eCallSalvaDados += new mdlDespachante.Formularios.frmFDespachantes.delCallSalvaDados(bSalvaDados);

		}
		#endregion
		#region ShowDialogNovo
		private bool ShowDialogNovo()
		{
			Formularios.frmFDespachantesEdicao formFDespachantesEdicao = new Formularios.frmFDespachantesEdicao(m_strEnderecoExecutavel);
			vInitializeEvents(ref formFDespachantesEdicao);
			formFDespachantesEdicao.ShowDialog();
			return(formFDespachantesEdicao.m_bModificado);
		}

		private void vInitializeEvents(ref Formularios.frmFDespachantesEdicao formFDespachantesEdicao)
		{
			// Refresh Estados Brasileiros
			formFDespachantesEdicao.eCallCarregaDadosEstadosBrasileiros += new mdlDespachante.Formularios.frmFDespachantesEdicao.delCallCarregaDadosEstadosBrasileiros(vRefreshEstadosBrasileiros);

			// Carrega dados
			formFDespachantesEdicao.eCallCarregaDados += new mdlDespachante.Formularios.frmFDespachantesEdicao.delCallCarregaDados(vCarregaDadosDespachante);

			// Salva dados
			formFDespachantesEdicao.eCallSalvaDados += new mdlDespachante.Formularios.frmFDespachantesEdicao.delCallSalvaDados(bSalvaDadosDespachante);
		}
		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdDespachante)
			{
				Formularios.frmFDespachantesEdicao formFDespachanteEdicao = new Formularios.frmFDespachantesEdicao(m_strEnderecoExecutavel,nIdDespachante);
				vInitializeEvents(ref formFDespachanteEdicao);
				formFDespachanteEdicao.ShowDialog();
				return(formFDespachanteEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogContatos
		public void ShowDialogContatos()
		{
			int nIdDespachante;
			vCarregaDadosDespachanteSelecionado(out nIdDespachante);
			if (nIdDespachante == -1)
			{
				ShowDialog();
			}else{
				if(ShowDialogContatos(nIdDespachante))
					bSalvaDados();
			}
		}

		public void ShowDialogContatosDespachantes()
		{
			m_bContatosDespachantes = true;
			int nIdDespachante;
			vCarregaDadosDespachanteSelecionado(out nIdDespachante);
			if (nIdDespachante == -1)
			{
				ShowDialog();
			}
			else
			{
				if(ShowDialogContatos(nIdDespachante))
					bSalvaDados();
			}
		}

		private bool ShowDialogContatos(int nIdDespachante)
		{
			m_typDatSetDespachantesContatosCopy = (mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos)m_typDatSetDespachantesContatos.Copy();
			Formularios.frmFContatos formFContatos = new mdlDespachante.Formularios.frmFContatos(m_strEnderecoExecutavel,nIdDespachante);
			vInitializeEvents(ref formFContatos);
			formFContatos.ShowDialog();
			if (!formFContatos.m_bModificado)
				m_typDatSetDespachantesContatos = m_typDatSetDespachantesContatosCopy;
			return(formFContatos.m_bModificado);
		}

		private void vInitializeEvents(ref Formularios.frmFContatos formFContatos)
		{
			// Contatos Refresh
			formFContatos.eCallContatosRefresh += new mdlDespachante.Formularios.frmFContatos.delCallContatosRefresh(vContatosRefresh);

			// Contatos Carrega Selecionado
			formFContatos.eCallContatosCarregaSelecionado += new mdlDespachante.Formularios.frmFContatos.delCallContatosCarregaSelecionado(vCarregaDadosDespachanteContatoSelecionado);

			// Contatos Salva Selecionado
			formFContatos.eCallContatosSalvaSelecionado += new mdlDespachante.Formularios.frmFContatos.delCallContatosSalvaSelecionado(vSalvaDadosDespachanteContatoSelecionado);

			// Contato Novo
			formFContatos.eCallContatoNovo += new mdlDespachante.Formularios.frmFContatos.delCallContatoNovo(ShowDialogContatoNovo);

			// Contato Editar
			formFContatos.eCallContatoEditar += new mdlDespachante.Formularios.frmFContatos.delCallContatoEditar(ShowDialogContatoEditar);

			// Contato Exclui
			formFContatos.eCallContatosExcluir += new mdlDespachante.Formularios.frmFContatos.delCallContatosExcluir(bDespachanteContatoExclui);
		}
		#endregion
		#region ShowDialogContatosNovo
		private bool ShowDialogContatoNovo(int nIdTransportadora)
		{
			Formularios.frmFContatosEdicao formFContatoEdicao = new Formularios.frmFContatosEdicao(m_strEnderecoExecutavel,nIdTransportadora);
			vInitializeEvents(ref formFContatoEdicao);
			formFContatoEdicao.ShowDialog();
			return(formFContatoEdicao.m_bModificado);
		}
			
		private void vInitializeEvents(ref Formularios.frmFContatosEdicao formFContatoEdicao)
		{
			// Carrega Dados
			formFContatoEdicao.eCallCarregaDados += new mdlDespachante.Formularios.frmFContatosEdicao.delCallCarregaDados(vCarregaDadosDespachanteContato);

			// Salva Dados
			formFContatoEdicao.eCallSalvaDados += new mdlDespachante.Formularios.frmFContatosEdicao.delCallSalvaDados(bSalvaDadosDespachanteContato);
		}
		#endregion
		#region ShowDialogContatosEditar
		private bool ShowDialogContatoEditar(int nIdTransportadora,int nIdContato)
		{
			Formularios.frmFContatosEdicao formFContatoEdicao = new mdlDespachante.Formularios.frmFContatosEdicao(m_strEnderecoExecutavel,nIdTransportadora,nIdContato);
			vInitializeEvents(ref formFContatoEdicao);
			formFContatoEdicao.ShowDialog();
			return(formFContatoEdicao.m_bModificado);
		}
		#endregion

		#region Selecao Despachantes
			private void vCarregaDadosDespachanteSelecionado(out int nIdDespachante)
			{
				nIdDespachante = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdDespachanteNull())
						nIdDespachante = dtrwPe.nIdDespachante;
				}
			}

			private void vSalvaDadosDespachanteSelecionado(int nIdDespachante)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdDespachante = nIdDespachante;
				}
			}
		#endregion
		#region Despachantes
			private void vDespachantesRefresh(ref System.Windows.Forms.ListView lvDespachantes)
			{
				lvDespachantes.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListDespachantes = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow dtrwDespachante in m_typdatSetDespachantes.tbDespachantes.Rows)
					if ((dtrwDespachante.RowState != System.Data.DataRowState.Deleted) && (!dtrwDespachante.IsstrNomeNull()))
						if (!sortListDespachantes.ContainsKey(dtrwDespachante.strNome))
							sortListDespachantes.Add(dtrwDespachante.strNome,dtrwDespachante);

				// Insert
				for(int i = 0; i < sortListDespachantes.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow dtrwDespachanteInserir = (mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow)sortListDespachantes.GetByIndex(i);
					lvDespachantes.Items.Add(dtrwDespachanteInserir.strNome).Tag = dtrwDespachanteInserir.nIdDespachante;
				}
			}

			private void vCarregaDadosDespachante(int nIdDespachante,out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out int nIdEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strTelefone = strFax = strEmail = strSite = "";
				nIdEstado = -1;

				mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow dtrwDespachante = m_typdatSetDespachantes.tbDespachantes.FindBynIdDespachante(nIdDespachante);
				if ((dtrwDespachante != null) && (dtrwDespachante.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwDespachante.IsstrNomeNull())
						strNome = dtrwDespachante.strNome;
					//strEndereco 
					if (!dtrwDespachante.IsmstrEnderecoNull())
						strEndereco = dtrwDespachante.mstrEndereco;
					//strCEP 
					if (!dtrwDespachante.IsstrCEPNull())
						strCEP = dtrwDespachante.strCEP;
					//strBairro 
					if (!dtrwDespachante.IsstrBairroNull())
						strBairro = dtrwDespachante.strBairro;
					//strCidade 
					if (!dtrwDespachante.IsmstrCidadeNull())
						strCidade = dtrwDespachante.mstrCidade;
					//nIdEstado
					if (!dtrwDespachante.IsnIdEstadoNull())
						nIdEstado = dtrwDespachante.nIdEstado;
					//strTelefone
					if (!dtrwDespachante.IsstrTelefoneNull())
						strTelefone = dtrwDespachante.strTelefone;
					//strFax 
					if (!dtrwDespachante.IsstrFaxNull())
						strFax = dtrwDespachante.strFax;
					//strEmail 
					if (!dtrwDespachante.IsstrEmailNull())
						strEmail = dtrwDespachante.strEmail;
					//strSite 
					if (!dtrwDespachante.IsstrSiteNull())
						strSite = dtrwDespachante.strSite;
				}
			}

			private bool bSalvaDadosDespachante(int nIdDespachante,string strNome,string strEndereco,string strCEP,string strBairro,string strCidade,int nIdEstado,string strTelefone,string strFax,string strEmail,string strSite)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher a razão social da comissário despachante.");
					return(false);
				}

				if (nIdEstado == -2)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher corretamente o campo Estado.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow dtrwDespachante = m_typdatSetDespachantes.tbDespachantes.FindBynIdDespachante(nIdDespachante);
				if (bAdd = (dtrwDespachante == null))
				{
					dtrwDespachante = m_typdatSetDespachantes.tbDespachantes.NewtbDespachantesRow();
					dtrwDespachante.nIdDespachante = nNextIdDespachante();
				}
				dtrwDespachante.strNome = strNome;
				dtrwDespachante.mstrEndereco = strEndereco;
				dtrwDespachante.strCEP = strCEP;
				dtrwDespachante.strBairro = strBairro;
				dtrwDespachante.mstrCidade = strCidade;
				dtrwDespachante.nIdEstado = (short)nIdEstado;
				dtrwDespachante.strTelefone = strTelefone;
				dtrwDespachante.strFax = strFax;
				dtrwDespachante.strEmail = strEmail;
				dtrwDespachante.strSite = strSite;

				if (bAdd)
					m_typdatSetDespachantes.tbDespachantes.AddtbDespachantesRow(dtrwDespachante);
				return(true);
			}
					
			private int nNextIdDespachante()
			{
				int nRetorno = 1;
				while(m_typdatSetDespachantes.tbDespachantes.FindBynIdDespachante(nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bDespachantesExclui(ref System.Collections.ArrayList arlDespachantes,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) despachante(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Despachantes
				for(int i = m_typdatSetDespachantes.tbDespachantes.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow dtrwDespachante = (mdlDataBaseAccess.Tabelas.XsdTbDespachantes.tbDespachantesRow)m_typdatSetDespachantes.tbDespachantes.Rows[i];
					if (dtrwDespachante.RowState != System.Data.DataRowState.Deleted)
						if (arlDespachantes.Contains(dtrwDespachante.nIdDespachante))
							dtrwDespachante.Delete();
				}

				// Contatos
				for(int i = m_typDatSetDespachantesContatos.tbDespachantesContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow)m_typDatSetDespachantesContatos.tbDespachantesContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (arlDespachantes.Contains(dtrwContato.nIdDespachante)))
						dtrwContato.Delete();
				}

				return(true);
			}
		#endregion
		#region Selecao Contatos
			private void vCarregaDadosDespachanteContatoSelecionado(out int nIdContato)
			{
				if (!m_bContatosDespachantes)
				{
					nIdContato = -1;
					if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						if (!dtrwPe.IsnIdDespachanteContatoNull())
							nIdContato = dtrwPe.nIdDespachanteContato;
					}
				}else{
					vCarregaDadosDespachanteContatoDespachanteSelecionado(out nIdContato);
				}
			}

			private void vSalvaDadosDespachanteContatoSelecionado(int nIdContato)
			{
				if (!m_bContatosDespachantes)
				{
					if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						dtrwPe.nIdDespachanteContato = nIdContato;
					}
				}else{
					vSalvaDadosDespachanteContatoDespachanteSelecionado(nIdContato);
				}
			}
		#endregion
		#region Selecao Contatos Despachante
			private void vCarregaDadosDespachanteContatoDespachanteSelecionado(out int nIdContato)
			{
				nIdContato = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdDespachanteContatoDespachanteNull())
						nIdContato = dtrwPe.nIdDespachanteContatoDespachante;
				}
			}

			private void vSalvaDadosDespachanteContatoDespachanteSelecionado(int nIdContato)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdDespachanteContatoDespachante = nIdContato;
				}
			}
		#endregion
		#region Contatos
			private void vContatosRefresh(int nIdDespachante,ref System.Windows.Forms.ListView lvContatos)
			{
				lvContatos.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListContatos = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContato in m_typDatSetDespachantesContatos.tbDespachantesContatos.Rows)
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdDespachante == nIdDespachante) && (!dtrwContato.IsstrNomeNull()))
						if (!sortListContatos.ContainsKey(dtrwContato.strNome))
							sortListContatos.Add(dtrwContato.strNome,dtrwContato);

				// Insert
				for(int i = 0; i < sortListContatos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContatoInserir = (mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow)sortListContatos.GetByIndex(i);
					lvContatos.Items.Add(dtrwContatoInserir.strNome).Tag = dtrwContatoInserir.nIdContato;
				}
			}

			private void vCarregaDadosDespachanteContato(int nIdDespachante,int nIdContato,out string strNome,out string strTelefone,out string strFax,out string strEmail,out string strRDA)
			{
				strNome = strTelefone = strFax = strEmail = strRDA = "";

				mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContato = m_typDatSetDespachantesContatos.tbDespachantesContatos.FindBynIdDespachantenIdContato(nIdDespachante,nIdContato);
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
					//strRDA
					if (!dtrwContato.IsmstrRDANull())
						strRDA = dtrwContato.mstrRDA;
				}
			}

			private bool bSalvaDadosDespachanteContato(int nIdDespachante,int nIdContato,string strNome,string strTelefone,string strFax,string strEmail,string strRDA)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do contato.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContato = m_typDatSetDespachantesContatos.tbDespachantesContatos.FindBynIdDespachantenIdContato(nIdDespachante,nIdContato);
				if (bAdd = (dtrwContato == null))
				{
					dtrwContato = m_typDatSetDespachantesContatos.tbDespachantesContatos.NewtbDespachantesContatosRow();
					dtrwContato.nIdDespachante = nIdDespachante;
					dtrwContato.nIdContato = nNextIdDespachanteContato(nIdDespachante);
				}
				dtrwContato.strNome = strNome;
				dtrwContato.strTelefone = strTelefone;
				dtrwContato.strFax = strFax;
				dtrwContato.strEmail = strEmail;
				dtrwContato.mstrRDA = strRDA;

				if (bAdd)
					m_typDatSetDespachantesContatos.tbDespachantesContatos.AddtbDespachantesContatosRow(dtrwContato);
				return(true);
			}
						
			private int nNextIdDespachanteContato(int nIdDespachante)
			{
				int nRetorno = 1;
				while(m_typDatSetDespachantesContatos.tbDespachantesContatos.FindBynIdDespachantenIdContato(nIdDespachante,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bDespachanteContatoExclui(int nIdDespachante,ref System.Collections.ArrayList arlContatos,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) contato(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Contatos
				for(int i = m_typDatSetDespachantesContatos.tbDespachantesContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbDespachantesContatos.tbDespachantesContatosRow)m_typDatSetDespachantesContatos.tbDespachantesContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdDespachante == nIdDespachante))
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
				string strContatoRDA;
				strNome = strEndereco = strCEP = strBairro = strCidade = strEstado = strTelefone = strFax = strEmail = strSite = strContatoNome = strContatoTelefone = strContatoFax = strContatoEmail = strContatoRDA = "";
				int nIdDespachante;
				vCarregaDadosDespachanteSelecionado(out nIdDespachante);
				if (nIdDespachante != -1)
				{
					int nIdEstado;
					vCarregaDadosDespachante(nIdDespachante,out strNome,out strEndereco,out strCEP,out strBairro,out strCidade,out nIdEstado,out strTelefone,out strFax,out strEmail,out strSite);
					strEstado = strRetornaSiglaEstadoBrasileiro(nIdEstado);
					// Contato
					int nIdContato;
					vCarregaDadosDespachanteContatoSelecionado(out nIdContato);
					if (nIdContato != -1)
						vCarregaDadosDespachanteContato(nIdDespachante,nIdContato,out strContatoNome,out strContatoTelefone,out strContatoFax,out strContatoEmail,out strContatoRDA);
				}
			}

			public void vRetornaValores(out string strDespachanteNome,out string strDespachanteTelefone,out string strDespachanteFax,out string strDespachanteEmail,out string strDespachanteRDA)
			{
				strDespachanteNome = strDespachanteTelefone = strDespachanteFax = strDespachanteEmail = strDespachanteRDA = "";
				int nIdDespachante;
				vCarregaDadosDespachanteSelecionado(out nIdDespachante);
				if (nIdDespachante != -1)
				{
					// Despachante
					int nIdContato;
					vCarregaDadosDespachanteContatoDespachanteSelecionado(out nIdContato);
					if (nIdContato != -1)
						vCarregaDadosDespachanteContato(nIdDespachante,nIdContato,out strDespachanteNome,out strDespachanteTelefone,out strDespachanteFax,out strDespachanteEmail,out strDespachanteRDA);
				}
			}
		#endregion

	}
}
