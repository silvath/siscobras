using System;

namespace mdlRE
{
	/// <summary>
	/// Summary description for clsRE.
	/// </summary>
	public class clsRE
	{
		#region Atributos
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			private string m_strPersonalizavel = "";

			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbREs m_typDatSetRes= null;
			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs m_typDatSetResPes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs m_typDatSetDSEsPEs = null;
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
		#region Construtores 
		public clsRE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			vCarregaDados();
		}

		public clsRE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPe = strIdPE;
			vCarregaDados();
		}
		#endregion

		#region Carregamento dos Dados
			private mdlDataBaseAccess.Tabelas.XsdTbPes GetTbPes()
			{
				if (m_strIdPe == "")
					return(null);
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
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPE = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetPE.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPE.tbPEs.Rows[0];
					if (!dtrwPE.IsmstrRENull())
						m_strPersonalizavel = dtrwPE.mstrRE;
				}
				return(typDatSetPE);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow GetRowFaturaComercial(string strIdPe)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdPe);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					return((mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0]);
				else
					return(null);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREs GetTbRes()
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

			private mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs GetTbDSEsPEs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbDSEsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}


			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs GetTbResPes()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbREsPEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private void vCarregaDados()
			{
				m_typDatSetPes = GetTbPes();
				m_typDatSetRes = GetTbRes();
				m_typDatSetResPes = GetTbResPes();
				m_typDatSetDSEsPEs = GetTbDSEsPEs();
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				if (bSalvaDadosPEs())
					if (bSalvaDadosREsPEs())
						return(bSalvaDadosRE());
				return(false);
			}

			private bool bSalvaDadosRE()
			{
				if (m_typDatSetRes.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbREs(m_typDatSetRes);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosREsPEs()
			{
				if (m_typDatSetResPes.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbREsPEs(m_typDatSetResPes);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosPEs()
			{
				if (m_typDatSetPes.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPes);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFREs formFRes = new mdlRE.Formularios.frmFREs(m_strEnderecoExecutavel);
				InitializeEvents(ref formFRes);
				formFRes.ShowDialog();
				if (formFRes.Modificado)
					return(bSalvaDados());
				return(false);
			}

			private void InitializeEvents(ref Formularios.frmFREs formFRes)
			{
				// Refresh REs
				formFRes.eCallRefreshREs += new mdlRE.Formularios.frmFREs.delCallRefreshREs(vRefreshREs);

				// RE Novo
				formFRes.eCallShowRENovo += new mdlRE.Formularios.frmFREs.delCallShowRENovo(ShowDialogRENovo);

				// RE Editar 
				formFRes.eCallShowREEditar += new mdlRE.Formularios.frmFREs.delCallShowREEditar(ShowDialogREEditar);

				// RE Exclui
				formFRes.eCallShowRERemover += new mdlRE.Formularios.frmFREs.delCallShowRERemover(formFRes_eCallShowRERemover);

				// Show Informacoes
				formFRes.eCallShowREInformacoes += new mdlRE.Formularios.frmFREs.delCallShowREInformacoes(ShowDialogInformacoes);
			}

			private bool formFRes_eCallShowRERemover(int nIdRe)
			{
				return (bREExclui(true,nIdRe));
			}
		#endregion
		#region ShowDialogReNovo
			private bool ShowDialogRENovo()
			{
				Formularios.frmFRENovo formFRENovo = new mdlRE.Formularios.frmFRENovo(m_strEnderecoExecutavel);
				InitializeEvents(ref formFRENovo);
				formFRENovo.ShowDialog();
				return(formFRENovo.Modificado);
			}

			private void InitializeEvents(ref Formularios.frmFRENovo formFRENovo)
			{
				formFRENovo.eCallSalvaDados += new mdlRE.Formularios.frmFRENovo.delCallSalvaDados(formFRENovo_eCallSalvaDados);

			}

			private bool formFRENovo_eCallSalvaDados(string strNumero,System.DateTime dtEmissao,int nAnexos)
			{
				return(bRENovo(true,strNumero,dtEmissao,nAnexos));
			}
		#endregion
		#region ShowDialogREEditar
			private bool ShowDialogREEditar(int nIdRE)
			{
				string strNumero;
				System.DateTime dtEmissao;
				int nAnexos;
				if (GetRE(nIdRE,out strNumero,out dtEmissao,out nAnexos))
				{
					Formularios.frmFRENovo formFREEditar = new mdlRE.Formularios.frmFRENovo(m_strEnderecoExecutavel,nIdRE);
					formFREEditar.eCallSalvaDadosEdicao += new mdlRE.Formularios.frmFRENovo.delCallSalvaDadosEdicao(formFREEdicao_eCallSalvaDadosEditar);
					formFREEditar.Text = "Editar RE";
					formFREEditar.Numero = strNumero;
					formFREEditar.Emissao = dtEmissao;
					formFREEditar.Anexos = nAnexos;
					formFREEditar.ShowDialog();
					return(formFREEditar.Modificado);
				}
				return(false);
			}

			private bool formFREEdicao_eCallSalvaDadosEditar(int nIdRE,string strNumero,System.DateTime dtEmissao,int nAnexos)
			{
				return(bREEditar(true,nIdRE,strNumero,dtEmissao,nAnexos));
			}

		#endregion
		#region ShowDialogInformacoes
			private bool ShowDialogInformacoes(int nIdRe)
			{
				Formularios.frmFREInformacoes formFInformacoes = new mdlRE.Formularios.frmFREInformacoes(m_strEnderecoExecutavel,nIdRe);
				InitializeEvents(ref formFInformacoes);
				formFInformacoes.ShowDialog();
				return(true);
			}
			
			private void InitializeEvents(ref Formularios.frmFREInformacoes formFInformacoes)
			{
				// Refresh PEs 
				formFInformacoes.eCallRefreshPEs += new mdlRE.Formularios.frmFREInformacoes.delCallRefreshPEs(vRefreshPEsVinculados);
			}
		#endregion
		#region ShowDialogVincular
			public bool ShowDialogVincular()
			{
				Formularios.frmFREVincular formFVincular = new mdlRE.Formularios.frmFREVincular(m_strEnderecoExecutavel);
				InitializeEvents(ref formFVincular);
				formFVincular.Personalizavel = this.Personalizavel;
				formFVincular.Editavel = (bReVinculado(m_strIdPe)) && (!bDSEVinculado(m_strIdPe));
				formFVincular.ShowDialog();
				if (formFVincular.Modificado)
				{
					if (m_typDatSetPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						dtrwPE.mstrRE = formFVincular.Personalizavel; 
						dtrwPE.SetmstrSDNull();
					}

					return(bSalvaDados());
				}
				return(formFVincular.Modificado);
			}

			private void InitializeEvents(ref Formularios.frmFREVincular formFVincular)
			{
				// Refresh REs
				formFVincular.eCallRefreshREs +=new mdlRE.Formularios.frmFREVincular.delCallRefreshREs(formFVincular_eCallRefreshREs);

				// Refresh REs Vinculados
				formFVincular.eCallRefreshREsVinculados += new mdlRE.Formularios.frmFREVincular.delCallRefreshREsVinculados(formFVincular_eCallRefreshREsVinculados);

				//ShowDialogREs
				formFVincular.eCallShowDialogREs +=new mdlRE.Formularios.frmFREVincular.delCallShowDialogREs(ShowDialog);

				// RE Vincular
				formFVincular.eCallREVincular +=new mdlRE.Formularios.frmFREVincular.delCallREVincular(formFVincular_eCallREVincular);

				// RE Desvincular
				formFVincular.eCallREDesvincular += new mdlRE.Formularios.frmFREVincular.delCallREDesvincular(formFVincular_eCallREDesvincular);

				// RE Novo
				formFVincular.eCallShowRENovo += new mdlRE.Formularios.frmFREVincular.delCallShowRENovo(ShowDialogRENovo);

				// RE Editar 
				formFVincular.eCallShowREEditar += new mdlRE.Formularios.frmFREVincular.delCallShowREEditar(ShowDialogREEditar);

				// RE Exclui
				formFVincular.eCallShowRERemover += new mdlRE.Formularios.frmFREVincular.delCallShowRERemover(formFRes_eCallShowRERemover);

				
			}

			private void formFVincular_eCallRefreshREs(ref mdlComponentesGraficos.ListView lvRes)
			{
				vRefreshREsDisponiveis(ref lvRes);
			}

			private void formFVincular_eCallRefreshREsVinculados(ref mdlComponentesGraficos.ListView lvResPEs)
			{
				vRefreshREsVinculados(ref lvResPEs);
			}

			private bool formFVincular_eCallREVincular(Formularios.frmFREVincular sender,int nIdRe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwVincular = m_typDatSetResPes.tbREsPEs.NewtbREsPEsRow();
				dtrwVincular.nIdExportador = m_nIdExportador;
				dtrwVincular.strIdPE = m_strIdPe;
				dtrwVincular.nIdRe = nIdRe;
				m_typDatSetResPes.tbREsPEs.AddtbREsPEsRow(dtrwVincular);
				vGeraPersonalizavel();
				sender.Personalizavel = this.Personalizavel;
				sender.Editavel = (bReVinculado(m_strIdPe)) && (!bDSEVinculado(m_strIdPe));
				return(true);
			}

			private bool formFVincular_eCallREDesvincular(Formularios.frmFREVincular sender,int nIdRe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwDesvincular = m_typDatSetResPes.tbREsPEs.FindBynIdExportadornIdRestrIdPE(m_nIdExportador,nIdRe,m_strIdPe);
				if ((dtrwDesvincular == null) || (dtrwDesvincular.RowState == System.Data.DataRowState.Deleted))
					return(false);
				dtrwDesvincular.Delete();
				vGeraPersonalizavel();
				sender.Personalizavel = this.Personalizavel;
				sender.Editavel = (bReVinculado(m_strIdPe)) && (!bDSEVinculado(m_strIdPe));
				return (true);
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

			private bool GetRE(int nIdRE,out string strNumero,out System.DateTime dtEmissao,out int nAnexos)
			{
				strNumero = "";
              	dtEmissao = System.DateTime.Now;
				nAnexos = 1;
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRE);
				if ((dtrwRE == null) || (dtrwRE.RowState == System.Data.DataRowState.Deleted))
					return(false);
				if (!dtrwRE.IsmstrNumeroNull())
					strNumero = dtrwRE.mstrNumero;
				if (!dtrwRE.IsdtEmissaoNull())
					dtEmissao = dtrwRE.dtEmissao;
				if (!dtrwRE.IsnAnexosNull())
					nAnexos = dtrwRE.nAnexos;
				return(true);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow GetRE(int nIdRE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRE);
				if ((dtrwRE == null) || (dtrwRE.RowState == System.Data.DataRowState.Deleted))
					return(null);
				return(dtrwRE);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow GetRE(string strNumero)
			{
				for(int i = 0; i < m_typDatSetRes.tbREs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetRes.tbREs.Rows[i];
					if ((dtrwRE.RowState != System.Data.DataRowState.Deleted) && (dtrwRE.mstrNumero == strNumero))
						return(dtrwRE);
				}
				return(null);
			}

			private void vRefreshREs(ref mdlComponentesGraficos.ListView lvRes)
			{
				lvRes.Items.Clear();
				System.Collections.SortedList sortLstRE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetRes.tbREs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetRes.tbREs.Rows[i];
					if ((dtrwRE.RowState != System.Data.DataRowState.Deleted))
						sortLstRE.Add(dtrwRE.mstrNumero,dtrwRE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = sortLstRE.Count - 1; i >=0 ;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)sortLstRE.GetByIndex(i);
					lviInserir = lvRes.Items.Add(GetName(dtrwRE));
					lviInserir.Tag = dtrwRE.nIdRe;
				}
			}

			private void vRefreshREsDisponiveis(ref mdlComponentesGraficos.ListView lvRes)
			{
				lvRes.Items.Clear();
				if (!bDSEVinculado(m_strIdPe))
				{
					System.Collections.SortedList sortLstRE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = GetRowFaturaComercial(m_strIdPe);
					if ((dtrwFaturaComercial == null) || (dtrwFaturaComercial.IsidImportadorNull()))
						return;
					int nIdImportadorPE = dtrwFaturaComercial.idImportador;


					// Ordenando
					for(int i = 0; i < m_typDatSetRes.tbREs.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)m_typDatSetRes.tbREs.Rows[i];
						if ((dtrwRE.RowState != System.Data.DataRowState.Deleted))
						{
							int nIdImportadorRE = GetREImportador(dtrwRE.nIdRe);
							if ((nIdImportadorRE == -1) || (nIdImportadorRE == nIdImportadorPE) && (!bReVinculado(dtrwRE.nIdRe,m_strIdPe)))
								sortLstRE.Add(dtrwRE.mstrNumero,dtrwRE);
						}
					}

					// Inserindo
					System.Windows.Forms.ListViewItem lviInserir;
					for(int i = 0; i < sortLstRE.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = (mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow)sortLstRE.GetByIndex(i);
						lviInserir = lvRes.Items.Add(GetName(dtrwRE));
						lviInserir.Tag = dtrwRE.nIdRe;
					}
				}
			}

			private bool bRENovo(bool bShowErrors,string strNumero,System.DateTime dtEmissao,int nAnexos)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do RE.");
					return(false);
				}
				if (strNumero.Length != 14)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do RE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = GetRE(strNumero);
				if (dtrwRE != null)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de RE já existe.");
					return(false);
				}
				int nIdRe = 1;
				while (m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRe) != null)
					nIdRe++;
				dtrwRE = m_typDatSetRes.tbREs.NewtbREsRow();
				dtrwRE.nIdRe = nIdRe;
				dtrwRE.nIdExportador = m_nIdExportador;
				dtrwRE.mstrNumero = strNumero;
				dtrwRE.dtEmissao = dtEmissao;
				dtrwRE.nAnexos = nAnexos;
				m_typDatSetRes.tbREs.AddtbREsRow(dtrwRE);
				return(true);
			}

			private bool bREEditar(bool bShowErrors,int nIdRE,string strNumero,System.DateTime dtEmissao,int nAnexos)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do RE.");
					return(false);
				}
				if (strNumero.Length != 14)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do RE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = GetRE(strNumero);
				if ((dtrwRE != null) && (dtrwRE.nIdRe != nIdRE))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de RE já existe.");
					return(false);
				}

				dtrwRE = m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRE);
				if ((dtrwRE == null) ||(dtrwRE.RowState == System.Data.DataRowState.Deleted)) 
					return(false);
				dtrwRE.mstrNumero = strNumero;
				dtrwRE.dtEmissao = dtEmissao;
				dtrwRE.nAnexos = nAnexos;
				return(true);
			}

	
			private bool bREExclui(bool bShowErrors,int nIdRe)
			{
				if (bReVinculado(nIdRe))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este RE não pode ser excluído por possuir vínculo com um PE.");
                    return(false);
				}

				if (bShowErrors)
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras","Deseja mesmo excluir este RE ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRe);
				if ((dtrwRE == null) && (dtrwRE.RowState != System.Data.DataRowState.Deleted))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de RE não existe.");
					return(false);
				}
				dtrwRE.Delete();
				return(true);
			}

			private string GetRENumero(int nIdRe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREs.tbREsRow dtrwRE = m_typDatSetRes.tbREs.FindBynIdExportadornIdRe(m_nIdExportador,nIdRe);
				if ((dtrwRE != null) && (dtrwRE.RowState != System.Data.DataRowState.Deleted) && (!dtrwRE.IsmstrNumeroNull()))
					return(dtrwRE.mstrNumero);
				else
					return("");
			}
		#endregion
		#region REsVinculados
			private int GetREImportador(int nIdRE)
			{
				int nRetorno = -1;
				for(int i = 0;i < m_typDatSetResPes.tbREsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs[i];
					if ((dtrwREPE.RowState != System.Data.DataRowState.Deleted) && (dtrwREPE.nIdRe == nIdRE))
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = GetRowFaturaComercial(dtrwREPE.strIdPE);
						if ((dtrwFaturaComercial != null) && (!dtrwFaturaComercial.IsidImportadorNull()))
							return(dtrwFaturaComercial.idImportador);
						return(-1);
					}
				}
				return(nRetorno);
			}

			private bool bReVinculado(int nIdRe)
			{
				for (int i = 0;i < m_typDatSetResPes.tbREsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs[i];
					if ((dtrwVinculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVinculo.nIdRe == nIdRe)) 
						return(true);
				}
				return(false);
			}

			private bool bReVinculado(string strIdPE)
			{
				for (int i = 0;i < m_typDatSetResPes.tbREsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs[i];
					if ((dtrwVinculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVinculo.strIdPE == strIdPE)) 
						return(true);
				}
				return(false);
			}

			private bool bReVinculado(int nIdRE,string strIdPe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwVinculo = m_typDatSetResPes.tbREsPEs.FindBynIdExportadornIdRestrIdPE(m_nIdExportador,nIdRE,strIdPe);
				return((dtrwVinculo != null) && (dtrwVinculo.RowState != System.Data.DataRowState.Deleted)); 
			}
			
			private void vRefreshREsVinculados(ref mdlComponentesGraficos.ListView lvREsVinculados)
			{
				lvREsVinculados.Items.Clear();
				System.Collections.SortedList sortLstREPE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetResPes.tbREsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs.Rows[i];
					if ((dtrwREPE.RowState != System.Data.DataRowState.Deleted) && (dtrwREPE.nIdExportador == m_nIdExportador) && (dtrwREPE.strIdPE == m_strIdPe))
						sortLstREPE.Add(GetRENumero(dtrwREPE.nIdRe),dtrwREPE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstREPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)sortLstREPE.GetByIndex(i);
					lviInserir = lvREsVinculados.Items.Add(GetName(GetRE(dtrwREPE.nIdRe)));
					lviInserir.Tag = dtrwREPE.nIdRe;
				}
			}

			private void vRefreshPEsVinculados(int nIdRe,ref mdlComponentesGraficos.ListView lvPEsVinculados)
			{
				lvPEsVinculados.Items.Clear();
				System.Collections.SortedList sortLstREPE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetResPes.tbREsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs.Rows[i];
					if ((dtrwREPE.RowState != System.Data.DataRowState.Deleted) && (dtrwREPE.nIdExportador == m_nIdExportador) && (dtrwREPE.nIdRe == nIdRe))
						sortLstREPE.Add(dtrwREPE.strIdPE,dtrwREPE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstREPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)sortLstREPE.GetByIndex(i);
					lviInserir = lvPEsVinculados.Items.Add(sortLstREPE.GetKey(i).ToString());
					lviInserir.Tag = dtrwREPE.strIdPE;
				}
			}
		#endregion
		#region DSEVinculados
			private bool bDSEVinculado(string strIdPE)
			{
				for (int i = 0;i < m_typDatSetDSEsPEs.tbDSEsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs[i];
					if ((dtrwVinculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVinculo.strIdPE == strIdPE)) 
						return(true);
				}
				return(false);
			}
		#endregion
		#region Personalizavel
			private void vGeraPersonalizavel()
			{
				System.Text.StringBuilder strbPersonalizavel = new System.Text.StringBuilder();
				System.Collections.SortedList sortLstDSEPE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetResPes.tbREsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetResPes.tbREsPEs.Rows[i];
					if ((dtrwREPE.RowState != System.Data.DataRowState.Deleted) && (dtrwREPE.nIdExportador == m_nIdExportador) && (dtrwREPE.strIdPE == m_strIdPe))
						sortLstDSEPE.Add(GetRENumero(dtrwREPE.nIdRe),dtrwREPE);
				}

				// Inserindo
				for(int i = 0; i < sortLstDSEPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwREPE = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)sortLstDSEPE.GetByIndex(i);
					if (strbPersonalizavel.ToString() != "")
						strbPersonalizavel.Append( " , ");
					strbPersonalizavel.Append(GetName(GetRE(dtrwREPE.nIdRe)));
				}
				m_strPersonalizavel = strbPersonalizavel.ToString();
				if (m_typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPE.mstrRE = m_strPersonalizavel; 
					dtrwPE.SetmstrSDNull();
				}
			}
		#endregion
	}
}

