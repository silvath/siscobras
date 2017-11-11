using System;

namespace mdlSD
{
	/// <summary>
	/// Summary description for clsSD.
	/// </summary>
	public class clsSD
	{
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			private int m_nIdExportador = -1;	
			private string m_strIdPE = "";

			private bool m_bPersonalizavel = false;
			private string m_strPersonalizavel = "";

			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPEs = null;
			private mdlDataBaseAccess.Tabelas.XsdTbSDs m_typDatSetSDs= null;
			private mdlDataBaseAccess.Tabelas.XsdTbREs m_typDatSetREs= null;
			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs m_typDatSetREsPEs= null;
		#endregion
		#region Propriedades
			public string Personalizavel
			{
				get
				{
					return(m_strPersonalizavel);
				}
			}
		#endregion
		#region Constructores
			public clsSD(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				vCarregaDados();
			}

			public clsSD(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador,string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPE = strIdPE;
				vCarregaDados();
			}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbPes GetTbPEs()
			{
				if (m_strIdPE == "")
					return(null);
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPE = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetPE.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPE.tbPEs.Rows[0];
					if (!dtrwPE.IsmstrSDNull())
						m_strPersonalizavel = dtrwPE.mstrSD;
				}
				return(typDatSetPE);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREs GetTbREs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbREs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs GetTbREsPEs()
			{
				if (m_strIdPE == "")
					return(null);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbREsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbSDs GetTbSDs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbSDs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}


			private void vCarregaDados()
			{
				m_typDatSetPEs = GetTbPEs();
				m_typDatSetSDs = GetTbSDs();
				m_typDatSetREs = GetTbREs();
				m_typDatSetREsPEs = GetTbREsPEs();
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				if (bSalvaDadosPEs())
					if (bSalvaDadosSD())
						return(bSalvaDadosRE());
				return(false);
			}

			private bool bSalvaDadosSD()
			{
				if (m_typDatSetSDs.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbSDs(m_typDatSetSDs);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosRE()
			{
				if (m_typDatSetREs.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbREs(m_typDatSetREs);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosPEs()
			{
				if ((m_typDatSetPEs == null) || (m_typDatSetPEs.GetChanges() == null))
					return(true);
				m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPEs);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFSDs formFSDs = new mdlSD.Formularios.frmFSDs(m_strEnderecoExecutavel);
				InitializeEvents(ref formFSDs);
				formFSDs.ShowDialog();
				if (formFSDs.Modificado)
					return(bSalvaDados());
				return(false);
			}
			
			private void InitializeEvents(ref Formularios.frmFSDs formFSDs)
			{
				// SD Refresh
				formFSDs.eCallRefreshSDs += new mdlSD.Formularios.frmFSDs.delCallRefreshSDs(vRefreshSDs);

				// SD Novo
				formFSDs.eCallShowSDNovo +=new mdlSD.Formularios.frmFSDs.delCallShowSDNovo(ShowDialogNovo);

				// SD Editar
				formFSDs.eCallShowSDEditar += new mdlSD.Formularios.frmFSDs.delCallShowSDEditar(ShowDialogEditar);

				// SD Exclui
				formFSDs.eCallShowSDRemover += new mdlSD.Formularios.frmFSDs.delCallShowSDRemover(formFSDs_eCallShowSDRemover);

				// SD Vincular
				formFSDs.eCallShowSDVincular += new mdlSD.Formularios.frmFSDs.delCallShowSDVincular(ShowDialogVincular);
			}

			private bool formFSDs_eCallShowSDRemover(int nIdSD)
			{
				return(bSDExclui(true,nIdSD));
			}
		#endregion
		#region ShowDialogNovo
			private bool ShowDialogNovo()
			{
				Formularios.frmFSDNovo formFSDNovo = new mdlSD.Formularios.frmFSDNovo(m_strEnderecoExecutavel);
				InitializeEvents(ref formFSDNovo);
				formFSDNovo.ShowDialog();
				return(formFSDNovo.Modificado);
			}

			private void InitializeEvents(ref Formularios.frmFSDNovo formFSDNovo)
			{
				formFSDNovo.eCallSalvaDados += new mdlSD.Formularios.frmFSDNovo.delCallSalvaDados(formFSDNovo_eCallSalvaDados);
			}

			private bool formFSDNovo_eCallSalvaDados(string strNumero,System.DateTime dtEmissao)
			{
				return(bSDNovo(true,strNumero,dtEmissao));
			}
		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdSD)
			{
				string strNumero;
				System.DateTime dtEmissao;
				if (GetSD(nIdSD,out strNumero,out dtEmissao))
				{
					Formularios.frmFSDNovo formFSDEditar = new mdlSD.Formularios.frmFSDNovo(m_strEnderecoExecutavel,nIdSD);
					formFSDEditar.eCallSalvaDadosEditar += new mdlSD.Formularios.frmFSDNovo.delCallSalvaDadosEditar(formFSDEditar_eCallSalvaDadosEditar);
					formFSDEditar.Text = "Editar DDE";
					formFSDEditar.Numero = strNumero;
					formFSDEditar.Emissao = dtEmissao;
					formFSDEditar.ShowDialog();
					return(formFSDEditar.Modificado);
				}
				return(false);

			}

			private bool formFSDEditar_eCallSalvaDadosEditar(int nIdSD, string strNumero, DateTime dtEmissao)
			{
				return(bSDEditar(true,nIdSD,strNumero,dtEmissao));
			}
		#endregion
		#region ShowDialogVincular
			private bool ShowDialogVincular(int nIdSD)
			{
				Formularios.frmFSDVincular formFVincular = new Formularios.frmFSDVincular(m_strEnderecoExecutavel,nIdSD);
				InitializeEvents(ref formFVincular);
				formFVincular.ShowDialog();
				if (formFVincular.Modificado)
				{
					if ((m_typDatSetPEs != null) && (m_typDatSetPEs.tbPEs.Rows.Count > 0))
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPEs.tbPEs.Rows[0];
						dtrwPE.mstrSD = m_strPersonalizavel; 
					}
					return(true);
				}
				return(false);
			}
			
			private void InitializeEvents(ref Formularios.frmFSDVincular formFVincular)
			{
				// Refresh REs
				formFVincular.eCallRefreshREs += new mdlSD.Formularios.frmFSDVincular.delCallRefreshREs(vRefreshREDisponiveis);

				// Refresh REs Vinculados ao SD
				formFVincular.eCallRefreshREsVinculados +=new mdlSD.Formularios.frmFSDVincular.delCallRefreshREsVinculados(vRefreshREVinculadosSD);

				// RE Vincular
				formFVincular.eCallREVincular += new mdlSD.Formularios.frmFSDVincular.delCallREVincular(bVincularREaSD);

				// RE Desvincular 
				formFVincular.eCallREDesvincular += new mdlSD.Formularios.frmFSDVincular.delCallREDesvincular(bDesvincularRE);
			}
		#endregion
		#region ShowDialogVincularPE
			public bool ShowDialogVincularPE()
			{
				Formularios.frmFSDVincularPE formFVincularPE = new mdlSD.Formularios.frmFSDVincularPE(m_strEnderecoExecutavel);
				InitializeEvents(ref formFVincularPE);
				formFVincularPE.PersonalizavelAtivo = (GetPersonalizavel() != null);
				if (formFVincularPE.PersonalizavelAtivo)
					formFVincularPE.Personalizavel = m_strPersonalizavel;
				formFVincularPE.ShowDialog();
				if (formFVincularPE.Modificado)
				{
					if (m_typDatSetPEs.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPEs.tbPEs.Rows[0];
						dtrwPE.mstrSD = formFVincularPE.Personalizavel; 
					}
					return(bSalvaDados());
				}
				return(false);
			}

			private void InitializeEvents(ref Formularios.frmFSDVincularPE formFVincularPE)
			{
				// Refresh SDs
				formFVincularPE.eCallRefreshSDs += new mdlSD.Formularios.frmFSDVincularPE.delCallRefreshSDs(vRefreshSDs);

				// SD Novo
				formFVincularPE.eCallShowSDNovo += new mdlSD.Formularios.frmFSDVincularPE.delCallShowSDNovo(ShowDialogNovo);

				// SD Editar
				formFVincularPE.eCallShowSDEditar += new mdlSD.Formularios.frmFSDVincularPE.delCallShowSDEditar(ShowDialogEditar);

				// SD Excluir
				formFVincularPE.eCallShowSDRemover += new mdlSD.Formularios.frmFSDVincularPE.delCallShowSDRemover(formFSDs_eCallShowSDRemover);

				// Refresh REs
				formFVincularPE.eCallRefreshREs += new mdlSD.Formularios.frmFSDVincularPE.delCallRefreshREs(vRefreshREDisponiveis);

				// Refresh REs Vinculados
				formFVincularPE.eCallRefreshREsVinculados += new mdlSD.Formularios.frmFSDVincularPE.delCallRefreshREsVinculados(vRefreshREVinculadosSD);

				// SD Vincular
				formFVincularPE.eCallREVincular += new mdlSD.Formularios.frmFSDVincularPE.delCallREVincular(bVincularREaSD);

				// SD Desvincular
				formFVincularPE.eCallREDesvincular += new mdlSD.Formularios.frmFSDVincularPE.delCallREDesvincular(bDesvincularRE);

				// Personalizavel
				formFVincularPE.eCallPersonalizavel += new mdlSD.Formularios.frmFSDVincularPE.delCallPersonalizavel(formFVincularPE_eCallPersonalizavel);
			}
		#endregion

		#region SD
			private bool GetSD(int nIdSD,out string strNumero,out System.DateTime dtEmissao)
			{
				strNumero = "";
				dtEmissao = System.DateTime.Now;
				mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,nIdSD);
				if ((dtrwSD == null) || (dtrwSD.RowState == System.Data.DataRowState.Deleted))
					return(false);
				if (!dtrwSD.IsmstrNumeroNull())
					strNumero = dtrwSD.mstrNumero;
				if (!dtrwSD.IsdtEmissaoNull())
					dtEmissao = dtrwSD.dtEmissao;
				return(true);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow GetSD(int nIdSD)
			{
				mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,nIdSD);
				if ((dtrwSD == null) || (dtrwSD.RowState == System.Data.DataRowState.Deleted))
					return(null);
				return(dtrwSD);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow GetSD(string strNumero)
			{
				for(int i = 0; i < m_typDatSetSDs.tbSDs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = (mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow)m_typDatSetSDs.tbSDs.Rows[i];
					if ((dtrwSD.RowState != System.Data.DataRowState.Deleted) && (dtrwSD.mstrNumero == strNumero))
						return(dtrwSD);
				}
				return(null);
			}

			private void vRefreshSDs(ref mdlComponentesGraficos.ListView lvSDs)
			{
				lvSDs.Items.Clear();
				System.Collections.SortedList sortLstSD = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetSDs.tbSDs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = (mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow)m_typDatSetSDs.tbSDs.Rows[i];
					if ((dtrwSD.RowState != System.Data.DataRowState.Deleted))
						sortLstSD.Add(dtrwSD.mstrNumero,dtrwSD);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstSD.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = (mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow)sortLstSD.GetByIndex(i);
					lviInserir = lvSDs.Items.Add(dtrwSD.mstrNumero);
					lviInserir.Tag = dtrwSD.nIdSD;
				}
			}

			private bool bSDNovo(bool bShowErrors,string strNumero,System.DateTime dtEmissao)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do DDE.");
					return(false);
				}
				if (strNumero.Length != 12)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do DDE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = GetSD(strNumero);
				if (dtrwSD != null)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DDE já existe.");
					return(false);
				}
				int nIdSD = 1;
				while (m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,nIdSD) != null)
					nIdSD++;
				dtrwSD = m_typDatSetSDs.tbSDs.NewtbSDsRow();
				dtrwSD.nIdSD = nIdSD;
				dtrwSD.nIdExportador = m_nIdExportador;
				dtrwSD.mstrNumero = strNumero;
				dtrwSD.dtEmissao = dtEmissao;
				m_typDatSetSDs.tbSDs.AddtbSDsRow(dtrwSD);
				vGeraPersonalizavel();
				return(true);
			}

			private bool bSDEditar(bool bShowErrors,int nIdSD,string strNumero,System.DateTime dtEmissao)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número da DDE.");
					return(false);
				}
				if (strNumero.Length != 12)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número da DDE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = GetSD(strNumero);
				if ((dtrwSD != null) && (dtrwSD.nIdSD != nIdSD))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DDE já existe.");
					return(false);
				}
				dtrwSD = m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,nIdSD);
				if ((dtrwSD == null) ||(dtrwSD.RowState == System.Data.DataRowState.Deleted)) 
					return(false);
				dtrwSD.mstrNumero = strNumero;
				dtrwSD.dtEmissao = dtEmissao;
				vGeraPersonalizavel();
				return(true);
			}

			private bool bSDExclui(bool bShowErrors,int nIdSD)
			{
				if (bSDVinculado(nIdSD))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Esta DDE não pode ser excluído por possuir vínculo com um RE.");
					return(false);
				}

				if (bShowErrors)
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras","Deseja mesmo excluir esta DDE ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);
				mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,nIdSD);
				if ((dtrwSD == null) && (dtrwSD.RowState != System.Data.DataRowState.Deleted))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DDE não existe.");
					return(false);
				}
				dtrwSD.Delete();
				vGeraPersonalizavel();
				return(true);
			}

			private bool bSDVinculado(int nIdSD)
			{
				for (int i = 0;i < m_typDatSetREs.tbREs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetREs.tbREs[i];
					if ((dtrwVinculo.RowState != System.Data.DataRowState.Deleted) && (!dtrwVinculo.IsnIdSDNull()) && (dtrwVinculo.nIdSD == nIdSD)) 
						return(true);
				}
				return(false);
			}
		#endregion
		#region RE
			private string GetName(mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE)
			{
				string strReturn = dtrwRE.mstrNumero;
				if ((!dtrwRE.IsnAnexosNull()) && (dtrwRE.nAnexos != 1))
					strReturn += " a " + dtrwRE.nAnexos.ToString("000");
				return(strReturn);
			}


			private void vRefreshREDisponiveis(ref mdlComponentesGraficos.ListView lvREs)
			{
				lvREs.Items.Clear();
				System.Collections.SortedList sortLstRE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetREs.tbREs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetREs.tbREs.Rows[i];
					if ((dtrwRE.RowState != System.Data.DataRowState.Deleted) && (dtrwRE.IsnIdSDNull()))
						sortLstRE.Add(dtrwRE.mstrNumero,dtrwRE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstRE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)sortLstRE.GetByIndex(i);
					lviInserir = lvREs.Items.Add(GetName(dtrwRE));
					lviInserir.Tag = dtrwRE.nIdRe;
				}
			}
			private void vRefreshREVinculadosSD(int nIdSD,ref mdlComponentesGraficos.ListView lvREsSDs)
			{
				lvREsSDs.Items.Clear();
				System.Collections.SortedList sortLstRE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetREs.tbREs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetREs.tbREs.Rows[i];
					if ((dtrwRE.RowState != System.Data.DataRowState.Deleted) && (!dtrwRE.IsnIdSDNull()) && (dtrwRE.nIdSD == nIdSD))
						sortLstRE.Add(dtrwRE.mstrNumero,dtrwRE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstRE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)sortLstRE.GetByIndex(i);
					lviInserir = lvREsSDs.Items.Add(GetName(dtrwRE));
					lviInserir.Tag = dtrwRE.nIdRe;
				}
			}

			private bool bVincularREaSD(int nIdSD,int nIdRE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRE);
				if ((dtrwRE == null) || (dtrwRE.RowState == System.Data.DataRowState.Deleted))
					return(false);
				dtrwRE.nIdSD = nIdSD;
				vGeraPersonalizavel();
				return(true);
			}

			private bool bDesvincularRE(int nIdRE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRE);
				if ((dtrwRE == null) || (dtrwRE.RowState == System.Data.DataRowState.Deleted))
					return(false);
				dtrwRE.SetnIdSDNull();
				vGeraPersonalizavel();
				return(true);
			}
		#endregion
		#region Personalizavel
			private void vGeraPersonalizavel()
			{
				m_strPersonalizavel = GetPersonalizavel();
				m_bPersonalizavel = (m_strPersonalizavel != null);
				if (!m_bPersonalizavel)
					m_strPersonalizavel = "";
			}

			private string GetPersonalizavel()
			{
				System.Text.StringBuilder strbPersonalizavel = new System.Text.StringBuilder();

				System.Collections.SortedList sortLstSD = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());

				// Ordenando
				for(int i = 0; i < m_typDatSetREsPEs.tbREsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetREsPEs.tbREsPEs.Rows[i];
					if ((dtrwREPE.RowState != System.Data.DataRowState.Deleted) && (dtrwREPE.strIdPE ==  m_strIdPE))
					{
						mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetREs.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,dtrwREPE.nIdRe);
						if ((dtrwRE != null) && (dtrwRE.RowState != System.Data.DataRowState.Deleted) && (!dtrwRE.IsnIdSDNull()))
						{
							mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = m_typDatSetSDs.tbSDs.FindBynIdExportadornIdSD(m_nIdExportador,dtrwRE.nIdSD);
							if ((dtrwSD != null) && (dtrwSD.RowState != System.Data.DataRowState.Deleted) && (!sortLstSD.Contains(dtrwSD.mstrNumero)))
								sortLstSD.Add(dtrwSD.mstrNumero,dtrwSD);
						}
					}
				}

				if (sortLstSD.Count == 0)
					return(null);

				// Inserindo
				for(int i = 0; i < sortLstSD.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow dtrwSD = (mdlDataBaseAccess.Tabelas.XsdTbSDs.tbSDsRow)sortLstSD.GetByIndex(i);
					if (strbPersonalizavel.ToString() != "")
						strbPersonalizavel.Append( " , ");
					strbPersonalizavel.Append(dtrwSD.mstrNumero);
				}
				return(strbPersonalizavel.ToString());
			}

			private void formFVincularPE_eCallPersonalizavel(out bool bPersonalizavel, out string strPersonalizavel)
			{
				bPersonalizavel = m_bPersonalizavel;
				strPersonalizavel = m_strPersonalizavel;
			}
		#endregion
	}
}
