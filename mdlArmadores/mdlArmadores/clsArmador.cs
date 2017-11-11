using System;

namespace mdlArmadores
{
	/// <summary>
	/// Summary description for clsArmador.
	/// </summary>
	public class clsArmador
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			private int m_nIdSelect = -1;
			private int m_nIdSelectNavio = -1;

			// Typed DataSets
			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbArmadores m_typDatSetArmadores = null;
			private mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios m_typDatSetArmadoresNavios = null;
			private mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios m_typDatSetArmadoresNaviosCopy = null;
		#endregion
		#region Constructors and Destructors
			public clsArmador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = "";
				vCarregaDados();
			}

			public clsArmador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
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
				vCarregaDadosArmadores();
				vCarregaDadosArmadoresNavios();
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

			private void vCarregaDadosArmadores()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetArmadores = m_cls_dba_ConnectionDB.GetTbArmadores(null,null,null,null,null);
			}
				
			private void vCarregaDadosArmadoresNavios()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetArmadoresNavios = m_cls_dba_ConnectionDB.GetTbArmadoresNavios(null,null,null,null,null);
			}
		#endregion
		#region Salvamento de Dados 
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosPe())
					if (bSalvaDadosArmadoresNavios())
						m_bModificado = bRetorno = bSalvaDadosArmadores();
				return(bRetorno);
			}

			private bool bSalvaDadosPe()
			{
				if (m_strIdPe != "")
				{
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPes);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}else{
					return(true);
				}
			}

			private bool bSalvaDadosArmadores()
			{
				m_cls_dba_ConnectionDB.SetTbArmadores(m_typDatSetArmadores);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosArmadoresNavios()
			{
				m_cls_dba_ConnectionDB.SetTbArmadoresNavios(m_typDatSetArmadoresNavios);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public  void ShowDialog()
			{
				Formularios.frmFArmadores formFArmadores = new mdlArmadores.Formularios.frmFArmadores(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFArmadores);
				formFArmadores.ShowDialog();
			}
			
			private void vInitializeEvents(ref Formularios.frmFArmadores formFArmadores)
			{
				// Armadores Refresh
				formFArmadores.eCallArmadoresRefresh +=new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresRefresh(vArmadoresRefresh);

				// Carrega Armador Selecionado 
				formFArmadores.eCallArmadoresCarregaSelecionado += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresCarregaSelecionado(vCarregaDadosArmadorSelecionado);
						
				// Salva Armador Selecionado
				formFArmadores.eCallArmadoresSalvaSelecionado += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresSalvaSelecionado(vSalvaDadosArmadorSelecionado);

				// Armador Novo 
				formFArmadores.eCallArmadoresNovo += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresNovo(ShowDialogNovo);

				// Armador Editar
				formFArmadores.eCallArmadoresEditar += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresEditar(ShowDialogEditar);

				// Armador Excluir
				formFArmadores.eCallArmadoresExcluir += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresExcluir(bArmadoresExclui);

				// Armador Navios
				formFArmadores.eCallArmadoresNavios += new mdlArmadores.Formularios.frmFArmadores.delCallArmadoresNavios(ShowDialogNavios);

				// Salva Dados
				formFArmadores.eCallSalvaDados += new mdlArmadores.Formularios.frmFArmadores.delCallSalvaDados(bSalvaDados);
			}
		#endregion
		#region ShowDialogNovo
			private bool ShowDialogNovo()
			{
				Formularios.frmFArmadoresEdicao formFArmadorEdicao = new mdlArmadores.Formularios.frmFArmadoresEdicao(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFArmadorEdicao);
				formFArmadorEdicao.ShowDialog();
				return(formFArmadorEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFArmadoresEdicao formFArmadorEdicao)
			{
				// Carrega Dados Armador
				formFArmadorEdicao.eCallCarregaDados += new mdlArmadores.Formularios.frmFArmadoresEdicao.delCallCarregaDados(vCarregaDadosArmador);

				// Salva Dados Armador
				formFArmadorEdicao.eCallSalvaDados += new mdlArmadores.Formularios.frmFArmadoresEdicao.delCallSalvaDados(bSalvaDadosArmador);

			}
		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdArmador)
			{
				Formularios.frmFArmadoresEdicao formFArmadorEdicao = new mdlArmadores.Formularios.frmFArmadoresEdicao(m_strEnderecoExecutavel,nIdArmador);
				vInitializeEvents(ref formFArmadorEdicao);
				formFArmadorEdicao.ShowDialog();
				return(formFArmadorEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogNavios
			public void ShowDialogNavios()
			{
				int nIdArmador;
				vCarregaDadosArmadorSelecionado(out nIdArmador);
				if (nIdArmador == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogNavios(nIdArmador))
						bSalvaDados();
				}
			}

			private bool ShowDialogNavios(int nIdArmador)
			{
				m_typDatSetArmadoresNaviosCopy = (mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios)m_typDatSetArmadoresNavios.Copy();
				Formularios.frmFNavios formFNavios = new mdlArmadores.Formularios.frmFNavios(m_strEnderecoExecutavel,nIdArmador);
				vInitializeEvents(ref formFNavios);
				formFNavios.ShowDialog();
				if (!formFNavios.m_bModificado)
					m_typDatSetArmadoresNavios = m_typDatSetArmadoresNaviosCopy;
				return(formFNavios.m_bModificado);
			}
			
			private void vInitializeEvents(ref Formularios.frmFNavios formFNavios)
			{
				// Navios Refresh
				formFNavios.eCallNaviosRefresh += new mdlArmadores.Formularios.frmFNavios.delCallNaviosRefresh(vNaviosRefresh);

				// Carrega Navio Selecionado
				formFNavios.eCallNavioCarregaSelecionado += new mdlArmadores.Formularios.frmFNavios.delCallNavioCarregaSelecionado(vCarregaDadosNavioSelecionado);

				// Salva Navio Selecionado
				formFNavios.eCallNavioSalvaSelecionado += new mdlArmadores.Formularios.frmFNavios.delCallNavioSalvaSelecionado(vSalvaDadosNavioSelecionado);

				// Navio Novo 
				formFNavios.eCallNavioNovo += new mdlArmadores.Formularios.frmFNavios.delCallNavioNovo(ShowDialogNavioNovo);

				// Navio Editar
				formFNavios.eCallNavioEditar += new mdlArmadores.Formularios.frmFNavios.delCallNavioEditar(ShowDialogNavioEditar);

				// Navio Excluir
				formFNavios.eCallNavioExcluir += new mdlArmadores.Formularios.frmFNavios.delCallNavioExcluir(bNaviosExcluir);

				// Salva Dados
				formFNavios.eCallSalvaDados += new mdlArmadores.Formularios.frmFNavios.delCallSalvaDados(bSalvaDadosNavio);
			}

			private bool bSalvaDadosNavio(int nIdArmador,int nIdNavio)
			{
				return(true);
			}
		#endregion
		#region ShowDialogNavioNovo
			private bool ShowDialogNavioNovo(int nIdArmador)
			{
				Formularios.frmFNaviosEdicao formFNaviosEdicao = new mdlArmadores.Formularios.frmFNaviosEdicao(m_strEnderecoExecutavel,nIdArmador);
				vInitializeEvents(ref formFNaviosEdicao);
				formFNaviosEdicao.ShowDialog();
				return(formFNaviosEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFNaviosEdicao formFNaviosEdicao)
			{
				// Carrega Dados
				formFNaviosEdicao.eCallCarregaDados += new mdlArmadores.Formularios.frmFNaviosEdicao.delCallCarregaDados(vCarregaDadosNavio);

				// Salva Dados
				formFNaviosEdicao.eCallSalvaDados += new mdlArmadores.Formularios.frmFNaviosEdicao.delCallSalvaDados(bSalvaDadosNavio);
			}
		#endregion
		#region ShowDialogNavioEditar
			private bool ShowDialogNavioEditar(int nIdArmador,int nIdNavio)
			{
				Formularios.frmFNaviosEdicao formFNaviosEdicao = new mdlArmadores.Formularios.frmFNaviosEdicao(m_strEnderecoExecutavel,nIdArmador,nIdNavio);
				vInitializeEvents(ref formFNaviosEdicao);
				formFNaviosEdicao.ShowDialog();
				return(formFNaviosEdicao.m_bModificado);
			}
		#endregion

		#region Selecao Armadores
			private void vCarregaDadosArmadorSelecionado(out int nIdArmador)
			{
				nIdArmador = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdArmadorNull())
						nIdArmador = dtrwPe.nIdArmador;
				}
			}

			private void vSalvaDadosArmadorSelecionado(int nIdArmador)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdArmador = nIdArmador;
				}
			}
		#endregion
		#region Armadores
			private void vArmadoresRefresh(ref System.Windows.Forms.ListView lvArmadores)
			{
				lvArmadores.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListArmadores = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwArmador in m_typDatSetArmadores.tbArmadores.Rows)
					if ((dtrwArmador.RowState != System.Data.DataRowState.Deleted) && (!dtrwArmador.IsstrNomeNull()))
						if (!sortListArmadores.ContainsKey(dtrwArmador.strNome))
							sortListArmadores.Add(dtrwArmador.strNome,dtrwArmador);

				// Insert
				for(int i = 0; i < sortListArmadores.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwArmadorInserir = (mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow)sortListArmadores.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvArmadores.Items.Add(dtrwArmadorInserir.strNome);
					lviInsert.Tag = dtrwArmadorInserir.nIdArmador;
					if ((m_nIdSelect != -1) && (dtrwArmadorInserir.nIdArmador == m_nIdSelect))
					{
						lviInsert.Selected = true;
						m_nIdSelect = -1;
					}
				}

			}

			private void vCarregaDadosArmador(int nIdArmador,out string strNome)
			{
				strNome = "";

				mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwArmador = m_typDatSetArmadores.tbArmadores.FindBynIdArmador(nIdArmador);
				if ((dtrwArmador != null) && (dtrwArmador.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwArmador.IsstrNomeNull())
						strNome = dtrwArmador.strNome;
				}
			}

			private bool bSalvaDadosArmador(int nIdArmador,string strNome)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do armador.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwArmador = m_typDatSetArmadores.tbArmadores.FindBynIdArmador(nIdArmador);
				if (bAdd = (dtrwArmador == null))
				{
					dtrwArmador = m_typDatSetArmadores.tbArmadores.NewtbArmadoresRow();
					dtrwArmador.nIdArmador = nNextIdArmador();
				}
				dtrwArmador.strNome = strNome;

				m_nIdSelect = dtrwArmador.nIdArmador;
				if (bAdd)
					m_typDatSetArmadores.tbArmadores.AddtbArmadoresRow(dtrwArmador);
				return(true);
			}
				
			private int nNextIdArmador()
			{
				int nRetorno = 1;
				while(m_typDatSetArmadores.tbArmadores.FindBynIdArmador(nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bArmadoresExclui(ref System.Collections.ArrayList arlArmadores,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) armador(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Armadores
				for(int i = m_typDatSetArmadores.tbArmadores.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow dtrwArmador = (mdlDataBaseAccess.Tabelas.XsdTbArmadores.tbArmadoresRow)m_typDatSetArmadores.tbArmadores.Rows[i];
					if (dtrwArmador.RowState != System.Data.DataRowState.Deleted)
						if (arlArmadores.Contains(dtrwArmador.nIdArmador))
							dtrwArmador.Delete();
				}

				// Navios
				for(int i = m_typDatSetArmadoresNavios.tbArmadoresNavios.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavio = (mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow)m_typDatSetArmadoresNavios.tbArmadoresNavios.Rows[i];
					if (dtrwNavio.RowState != System.Data.DataRowState.Deleted)
						if (arlArmadores.Contains(dtrwNavio.nIdArmador))
							dtrwNavio.Delete();
				}

				return(true);
			}
		#endregion
		#region Selecao Navio
			private void vCarregaDadosNavioSelecionado(out int nIdNavio)
			{
				nIdNavio = -1;
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdNavioNull())
						nIdNavio = dtrwPe.nIdNavio;
				}
			}

			private void vSalvaDadosNavioSelecionado(int nIdNavio)
			{
				if ((m_typDatSetPes != null) && (m_typDatSetPes.tbPEs.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPe.nIdNavio = nIdNavio;
				}
			}
		#endregion
		#region Navios
			private void vNaviosRefresh(int nIdArmador,ref System.Windows.Forms.ListView lvNavios)
			{
				lvNavios.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListNavios = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavio in m_typDatSetArmadoresNavios.tbArmadoresNavios.Rows)
					if ((dtrwNavio.RowState != System.Data.DataRowState.Deleted) && (dtrwNavio.nIdArmador == nIdArmador) && (!dtrwNavio.IsstrNomeNull()))
						if (!sortListNavios.ContainsKey(dtrwNavio.strNome))
							sortListNavios.Add(dtrwNavio.strNome,dtrwNavio);

				// Insert
				for(int i = 0; i < sortListNavios.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavioInserir = (mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow)sortListNavios.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvNavios.Items.Add(dtrwNavioInserir.strNome);
					lviInsert.Tag = dtrwNavioInserir.nIdNavio;
					if ((m_nIdSelectNavio != -1) && (dtrwNavioInserir.nIdNavio == m_nIdSelectNavio))
					{
						lviInsert.Selected = true;
						m_nIdSelectNavio = -1;
					}
				}

			}

			private void vCarregaDadosNavio(int nIdArmador,int nIdNavio,out string strNome)
			{
				strNome = "";

				mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavio = m_typDatSetArmadoresNavios.tbArmadoresNavios.FindBynIdArmadornIdNavio(nIdArmador,nIdNavio);
				if ((dtrwNavio != null) && (dtrwNavio.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwNavio.IsstrNomeNull())
						strNome = dtrwNavio.strNome;
				}
			}

			private bool bSalvaDadosNavio(int nIdArmador,int nIdNavio,string strNome)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do navio.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavio = m_typDatSetArmadoresNavios.tbArmadoresNavios.FindBynIdArmadornIdNavio(nIdArmador,nIdNavio);
				if (bAdd = (dtrwNavio == null))
				{
					dtrwNavio = m_typDatSetArmadoresNavios.tbArmadoresNavios.NewtbArmadoresNaviosRow();
					dtrwNavio.nIdArmador = nIdArmador;
					dtrwNavio.nIdNavio = nNextIdNavio(nIdArmador);
				}
				dtrwNavio.strNome = strNome;

				m_nIdSelectNavio = dtrwNavio.nIdNavio;
				if (bAdd)
					m_typDatSetArmadoresNavios.tbArmadoresNavios.AddtbArmadoresNaviosRow(dtrwNavio);
				return(true);
			}
					
			private int nNextIdNavio(int nIdArmador)
			{
				int nRetorno = 1;
				while(m_typDatSetArmadoresNavios.tbArmadoresNavios.FindBynIdArmadornIdNavio(nIdArmador,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bNaviosExcluir(int nIdArmador,ref System.Collections.ArrayList arlNavios,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) navio(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);
				// Navios
				for(int i = m_typDatSetArmadoresNavios.tbArmadoresNavios.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow dtrwNavio = (mdlDataBaseAccess.Tabelas.XsdTbArmadoresNavios.tbArmadoresNaviosRow)m_typDatSetArmadoresNavios.tbArmadoresNavios.Rows[i];
					if (dtrwNavio.RowState != System.Data.DataRowState.Deleted)
						if (dtrwNavio.nIdArmador == nIdArmador)
							if (arlNavios.Contains(dtrwNavio.nIdNavio))
								dtrwNavio.Delete();
				}
				return(true);
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strArmador,out string strNavio)
			{
				strArmador = strNavio = "";
				int nIdArmador;
				vCarregaDadosArmadorSelecionado(out nIdArmador);
				if (nIdArmador != -1)
				{
					vCarregaDadosArmador(nIdArmador,out strArmador);
					int nIdNavio;
					vCarregaDadosNavioSelecionado(out nIdNavio);
					if (nIdNavio != -1)
					{
						vCarregaDadosNavio(nIdArmador,nIdNavio,out strNavio);
					}
				}
			}
		#endregion
	}
}
