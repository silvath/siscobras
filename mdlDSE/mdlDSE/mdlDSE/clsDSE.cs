using System;

namespace mdlDSE
{
	/// <summary>
	/// Summary description for clsDSE.
	/// </summary>
	public class clsDSE
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
			private mdlDataBaseAccess.Tabelas.XsdTbDSEs m_typDatSetDSEs= null;
			private mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs m_typDatSetDSEsPEs = null;
			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs m_typDatSetREsPEs = null;
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
			public clsDSE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				vCarregaDados();
			}

			public clsDSE(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
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
					if (!dtrwPE.IsmstrDSENull())
						m_strPersonalizavel = dtrwPE.mstrDSE;
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

			private mdlDataBaseAccess.Tabelas.XsdTbDSEs GetTbDSEs()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				return(m_cls_dba_ConnectionDB.GetTbDSEs(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}

			private mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs GetTbDSEsPes()
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

			private mdlDataBaseAccess.Tabelas.XsdTbREsPEs GetTbREsPEs()
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
				m_typDatSetDSEs = GetTbDSEs();
				m_typDatSetDSEsPEs = GetTbDSEsPes();
				m_typDatSetREsPEs = GetTbREsPEs();
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				if (bSalvaDadosPEs())
					if (bSalvaDadosDSEsPEs())
						return(bSalvaDadosDSE());
				return(false);
			}

			private bool bSalvaDadosDSE()
			{
				if (m_typDatSetDSEs.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbDSEs(m_typDatSetDSEs);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosDSEsPEs()
			{
				if (m_typDatSetDSEsPEs.GetChanges() == null)
					return(true);
				m_cls_dba_ConnectionDB.SetTbDSEsPEs(m_typDatSetDSEsPEs);
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
				Formularios.frmFDSEs formFDSEs = new Formularios.frmFDSEs(m_strEnderecoExecutavel);
				InitializeEvents(ref formFDSEs);
				formFDSEs.ShowDialog();
				if (formFDSEs.Modificado)
					return(bSalvaDados());
				return(false);
			}

			private void InitializeEvents(ref Formularios.frmFDSEs formFDSEs)
			{	
				// Refresh DSEs
				formFDSEs.eCallRefreshDSEs += new mdlDSE.Formularios.frmFDSEs.delCallRefreshDSEs(vRefreshDSEs);

				// DSE Novo
				formFDSEs.eCallShowDSENovo += new mdlDSE.Formularios.frmFDSEs.delCallShowDSENovo(ShowDialogNovo);

				// DSE Editar
				formFDSEs.eCallShowDSEEditar +=new mdlDSE.Formularios.frmFDSEs.delCallShowDSEEditar(ShowDialogEditar);

				// DSE Exclui
				formFDSEs.eCallShowDSERemover += new mdlDSE.Formularios.frmFDSEs.delCallShowDSERemover(formFDSEs_eCallShowDSERemover);

				// ShowInformacoes
				formFDSEs.eCallShowDSEInformacoes += new mdlDSE.Formularios.frmFDSEs.delCallShowDSEInformacoes(ShowDialogInformacoes);
                
			}

			private bool formFDSEs_eCallShowDSERemover(int nIdDSE)
			{
				return(bDSEExclui(true,nIdDSE));
			}
		#endregion
		#region ShowDialogNovo
			private bool ShowDialogNovo()
			{
				Formularios.frmFDSENovo formFDSENovo = new Formularios.frmFDSENovo(m_strEnderecoExecutavel);
				InitializeEvents(ref formFDSENovo);
				formFDSENovo.ShowDialog();
				return(formFDSENovo.Modificado);
			}

			private void InitializeEvents(ref Formularios.frmFDSENovo formFDSENovo)
			{
				//Salva Dados
				formFDSENovo.eCallSalvaDados += new mdlDSE.Formularios.frmFDSENovo.delCallSalvaDados(formFDSENovo_eCallSalvaDados);
			}

			private bool formFDSENovo_eCallSalvaDados(string strNumero,System.DateTime dtEmissao)
			{
				return(bDSENovo(true,strNumero,dtEmissao));
			}

		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdDSE)
			{
				string strNumero;
				System.DateTime dtEmissao;
				if (GetDSE(nIdDSE,out strNumero,out dtEmissao))
				{
					Formularios.frmFDSENovo formFDSEEditar = new Formularios.frmFDSENovo(m_strEnderecoExecutavel,nIdDSE);
					formFDSEEditar.eCallSalvaDadosEditar += new mdlDSE.Formularios.frmFDSENovo.delCallSalvaDadosEditar(formFDSENovo_eCallSalvaDadosEditar);
					formFDSEEditar.Text = "Editar DSE";
					formFDSEEditar.Numero = strNumero;
					formFDSEEditar.Emissao = dtEmissao;
					formFDSEEditar.ShowDialog();
					return(formFDSEEditar.Modificado);
				}
				return(false);
			}

			private bool formFDSENovo_eCallSalvaDadosEditar(int nIdDSE, string strNumero, DateTime dtEmissao)
			{
				return(bDSEEditar(true,nIdDSE, strNumero,dtEmissao));
			}
		#endregion
		#region ShowDialogInformacoes
			private bool ShowDialogInformacoes(int nIdDSE)
			{
				Formularios.frmFDSEInformacoes formFDSEInformacoes = new Formularios.frmFDSEInformacoes(m_strEnderecoExecutavel,nIdDSE);
				InitializeEvents(ref formFDSEInformacoes);
				formFDSEInformacoes.ShowDialog();
				return(true);
			}

			private void InitializeEvents(ref Formularios.frmFDSEInformacoes formFDSEInformacoes)
			{
				// Refresh PEs
				formFDSEInformacoes.eCallRefreshPEs += new mdlDSE.Formularios.frmFDSEInformacoes.delCallRefreshPEs(vRefreshPEsVinculados);
			}
		#endregion
		#region ShowDialogVincular
			public bool ShowDialogVincular()
			{
				Formularios.frmFDSEVincular formFVincular = new Formularios.frmFDSEVincular(m_strEnderecoExecutavel);
				InitializeEvents(ref formFVincular);
				formFVincular.Personalizavel = this.Personalizavel;
				formFVincular.Editavel = (bDSEVinculado(m_strIdPe)) && (!bReVinculado(m_strIdPe));
				formFVincular.ShowDialog();
				if (formFVincular.Modificado)
				{
					if (m_typDatSetPes.tbPEs.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
						dtrwPE.mstrDSE = formFVincular.Personalizavel; 
					}
					return(bSalvaDados());
				}
				return(formFVincular.Modificado);
			}

			private void InitializeEvents(ref Formularios.frmFDSEVincular formFVincular)
			{
				// Refresh DSEs
				formFVincular.eCallRefreshDSEs += new mdlDSE.Formularios.frmFDSEVincular.delCallRefreshDSEs(formFVincular_eCallRefreshREs);

				// Refresh DSEs Vinculados
				formFVincular.eCallRefreshDSEsVinculados += new mdlDSE.Formularios.frmFDSEVincular.delCallRefreshDSEsVinculados(formFVincular_eCallRefreshDSEsVinculados);

				//ShowDialogDSEs
				formFVincular.eCallShowDialogDSEs += new mdlDSE.Formularios.frmFDSEVincular.delCallShowDialogDSEs(ShowDialog);

				// DSE Vincular
				formFVincular.eCallDSEVincular += new mdlDSE.Formularios.frmFDSEVincular.delCallDSEVincular(formFVincular_eCallDSEVincular);

				// DSE Desvincular
				formFVincular.eCallDSEDesvincular += new mdlDSE.Formularios.frmFDSEVincular.delCallDSEDesvincular(formFVincular_eCallDSEDesvincular);

				// DSE Novo 
				formFVincular.eCallShowDSENovo += new mdlDSE.Formularios.frmFDSEVincular.delCallShowDSENovo(ShowDialogNovo);

				// DSE Editar
				formFVincular.eCallShowDSEEditar += new mdlDSE.Formularios.frmFDSEVincular.delCallShowDSEEditar(ShowDialogEditar);

				// DSE Excluir
				formFVincular.eCallShowDSERemover += new mdlDSE.Formularios.frmFDSEVincular.delCallShowDSERemover(formFDSEs_eCallShowDSERemover);

			
			}

			private void formFVincular_eCallRefreshREs(ref mdlComponentesGraficos.ListView lvDSEs)
			{
				vRefreshDSEsDisponiveis(ref lvDSEs);
			}

			private bool formFVincular_eCallDSEVincular(Formularios.frmFDSEVincular sender,int nIdDSE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwVincular = m_typDatSetDSEsPEs.tbDSEsPEs.NewtbDSEsPEsRow();
				dtrwVincular.nIdExportador = m_nIdExportador;
				dtrwVincular.strIdPE = m_strIdPe;
				dtrwVincular.nIdDSE = nIdDSE;
				m_typDatSetDSEsPEs.tbDSEsPEs.AddtbDSEsPEsRow(dtrwVincular);
				vGeraPersonalizavel();
				sender.Personalizavel = this.Personalizavel;
				sender.Editavel = (bDSEVinculado(m_strIdPe)) && (!bReVinculado(m_strIdPe));
				return(true);
			}

			private bool formFVincular_eCallDSEDesvincular(Formularios.frmFDSEVincular sender,int nIdDSE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDesvincular = m_typDatSetDSEsPEs.tbDSEsPEs.FindBynIdExportadornIdDSEstrIdPE(m_nIdExportador,nIdDSE,m_strIdPe);
				if ((dtrwDesvincular == null) || (dtrwDesvincular.RowState == System.Data.DataRowState.Deleted))
					return(false);
				dtrwDesvincular.Delete();
				vGeraPersonalizavel();
				sender.Personalizavel = this.Personalizavel;
				sender.Editavel = (bDSEVinculado(m_strIdPe)) && (!bReVinculado(m_strIdPe));
				return (true);
			}

			private void formFVincular_eCallRefreshDSEsVinculados(ref mdlComponentesGraficos.ListView lvDSEsPEs)
			{
				vRefreshDSEsVinculados(ref lvDSEsPEs);
			}
		#endregion

		#region DSE
			private bool GetDSE(int nIdDSE,out string strNumero,out System.DateTime dtEmissao)
			{
				strNumero = "";
				dtEmissao = System.DateTime.Now;
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE);
				if ((dtrwDSE == null) || (dtrwDSE.RowState == System.Data.DataRowState.Deleted))
					return(false);
				if (!dtrwDSE.IsmstrNumeroNull())
					strNumero = dtrwDSE.mstrNumero;
				if (!dtrwDSE.IsdtEmissaoNull())
					dtEmissao = dtrwDSE.dtEmissao;
				return(true);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow GetDSE(int nIdDSE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE);
				if ((dtrwDSE == null) || (dtrwDSE.RowState == System.Data.DataRowState.Deleted))
					return(null);
				return(dtrwDSE);
			}

			private mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow GetDSE(string strNumero)
			{
				for(int i = 0; i < m_typDatSetDSEs.tbDSEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)m_typDatSetDSEs.tbDSEs.Rows[i];
					if ((dtrwDSE.RowState != System.Data.DataRowState.Deleted) && (dtrwDSE.mstrNumero == strNumero))
						return(dtrwDSE);
				}
				return(null);
			}

			private void vRefreshDSEs(ref mdlComponentesGraficos.ListView lvDSEs)
			{
				lvDSEs.Items.Clear();
				System.Collections.SortedList sortLstDSE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetDSEs.tbDSEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)m_typDatSetDSEs.tbDSEs.Rows[i];
					if ((dtrwDSE.RowState != System.Data.DataRowState.Deleted))
						sortLstDSE.Add(dtrwDSE.mstrNumero,dtrwDSE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstDSE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)sortLstDSE.GetByIndex(i);
					lviInserir = lvDSEs.Items.Add(dtrwDSE.mstrNumero);
					lviInserir.Tag = dtrwDSE.nIdDSE;
				}
			}

			private void vRefreshDSEsDisponiveis(ref mdlComponentesGraficos.ListView lvDSEs)
			{
				lvDSEs.Items.Clear();
				if (!bReVinculado(m_strIdPe))
				{
					System.Collections.SortedList sortLstDSE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = GetRowFaturaComercial(m_strIdPe);
					if ((dtrwFaturaComercial == null) || (dtrwFaturaComercial.IsidImportadorNull()))
						return;
					int nIdImportadorPE = dtrwFaturaComercial.idImportador;

					// Ordenando
					for(int i = 0; i < m_typDatSetDSEs.tbDSEs.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)m_typDatSetDSEs.tbDSEs.Rows[i];
						if ((dtrwDSE.RowState != System.Data.DataRowState.Deleted))
						{
							int nIdImportadorDSE = GetDSEImportador(dtrwDSE.nIdDSE);
							if ((nIdImportadorDSE == -1) || (nIdImportadorDSE == nIdImportadorPE) && (!bDSEVinculado(dtrwDSE.nIdDSE,m_strIdPe)))
								sortLstDSE.Add(dtrwDSE.mstrNumero,dtrwDSE);
						}
					}

					// Inserindo
					System.Windows.Forms.ListViewItem lviInserir;
					for(int i = 0; i < sortLstDSE.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = (mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow)sortLstDSE.GetByIndex(i);
						lviInserir = lvDSEs.Items.Add(dtrwDSE.mstrNumero);
						lviInserir.Tag = dtrwDSE.nIdDSE;
					}
				}
			}

			private bool bDSENovo(bool bShowErrors,string strNumero,System.DateTime dtEmissao)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do DSE.");
					return(false);
				}
				if (strNumero.Length != 12)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número do DSE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = GetDSE(strNumero);
				if (dtrwDSE != null)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DSE já existe.");
					return(false);
				}
				int nIdDSE = 1;
				while (m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE) != null)
					nIdDSE++;
				dtrwDSE = m_typDatSetDSEs.tbDSEs.NewtbDSEsRow();
				dtrwDSE.nIdDSE = nIdDSE;
				dtrwDSE.nIdExportador = m_nIdExportador;
				dtrwDSE.mstrNumero = strNumero;
				dtrwDSE.dtEmissao = dtEmissao;
				m_typDatSetDSEs.tbDSEs.AddtbDSEsRow(dtrwDSE);
				return(true);
			}

			private bool bDSEEditar(bool bShowErrors,int nIdDSE,string strNumero,System.DateTime dtEmissao)
			{
				if (strNumero == "")
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número da DSE.");
					return(false);
				}
				if (strNumero.Length != 12)
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Você precisa digitar o número da DSE corretamente.");
					return(false);
				}
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = GetDSE(strNumero);
				if ((dtrwDSE != null) && (dtrwDSE.nIdDSE != nIdDSE))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DSE já existe.");
					return(false);
				}

				dtrwDSE = m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE);
				if ((dtrwDSE == null) ||(dtrwDSE.RowState == System.Data.DataRowState.Deleted)) 
					return(false);
				dtrwDSE.mstrNumero = strNumero;
				dtrwDSE.dtEmissao = dtEmissao;
				return(true);
			}


			private bool bDSEExclui(bool bShowErrors,int nIdDSE)
			{
				if (bDSEVinculado(nIdDSE))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este DSE não pode ser excluído por possuir vínculo com um PE.");
					return(false);
				}

				if (bShowErrors)
					if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras","Deseja mesmo excluir este DSE ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE);
				if ((dtrwDSE == null) && (dtrwDSE.RowState != System.Data.DataRowState.Deleted))
				{
					if (bShowErrors)
						mdlMensagens.clsMensagens.ShowInformation("Este número de DSE não existe.");
					return(false);
				}
				dtrwDSE.Delete();
				return(true);
			}

			private string GetDSENumero(int nIdDSE)
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEs.tbDSEsRow dtrwDSE = m_typDatSetDSEs.tbDSEs.FindBynIdExportadornIdDSE(m_nIdExportador,nIdDSE);
				if ((dtrwDSE != null) && (dtrwDSE.RowState != System.Data.DataRowState.Deleted) && (!dtrwDSE.IsmstrNumeroNull()))
					return(dtrwDSE.mstrNumero);
				else
					return("");
			}
		#endregion
		#region DSEVinculados
			private int GetDSEImportador(int nIdDSE)
			{
				int nRetorno = -1;
				for(int i = 0;i < m_typDatSetDSEsPEs.tbDSEsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs[i];
					if ((dtrwDSEPE.RowState != System.Data.DataRowState.Deleted) && (dtrwDSEPE.nIdDSE == nIdDSE))
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = GetRowFaturaComercial(dtrwDSEPE.strIdPE);
						if ((dtrwFaturaComercial != null) && (!dtrwFaturaComercial.IsidImportadorNull()))
							return(dtrwFaturaComercial.idImportador);
						return(-1);
					}
				}
				return(nRetorno);
			}

			private bool bDSEVinculado(int nIdDSE)
			{
				for (int i = 0;i < m_typDatSetDSEsPEs.tbDSEsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs[i];
					if ((dtrwVinculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVinculo.nIdDSE == nIdDSE)) 
						return(true);
				}
				return(false);
			}

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

			private bool bDSEVinculado(int nIdDSE,string strIdPe)
			{
				mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwVinculo = m_typDatSetDSEsPEs.tbDSEsPEs.FindBynIdExportadornIdDSEstrIdPE(m_nIdExportador,nIdDSE,strIdPe);
				return((dtrwVinculo != null) && (dtrwVinculo.RowState != System.Data.DataRowState.Deleted)); 
			}
				
			private void vRefreshDSEsVinculados(ref mdlComponentesGraficos.ListView lvDSEsVinculados)
			{
				lvDSEsVinculados.Items.Clear();
				System.Collections.SortedList sortLstDSEPE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetDSEsPEs.tbDSEsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs.Rows[i];
					if ((dtrwDSEPE.RowState != System.Data.DataRowState.Deleted) && (dtrwDSEPE.nIdExportador == m_nIdExportador) && (dtrwDSEPE.strIdPE == m_strIdPe))
						sortLstDSEPE.Add(GetDSENumero(dtrwDSEPE.nIdDSE),dtrwDSEPE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstDSEPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)sortLstDSEPE.GetByIndex(i);
					lviInserir = lvDSEsVinculados.Items.Add(sortLstDSEPE.GetKey(i).ToString());
					lviInserir.Tag = dtrwDSEPE.nIdDSE;
				}
			}

			private void vRefreshPEsVinculados(int nIdDSE,ref mdlComponentesGraficos.ListView lvDSEsVinculados)
			{
				lvDSEsVinculados.Items.Clear();
				System.Collections.SortedList sortLstDSEPE = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());
				// Ordenando
				for(int i = 0; i < m_typDatSetDSEsPEs.tbDSEsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs.Rows[i];
					if ((dtrwDSEPE.RowState != System.Data.DataRowState.Deleted) && (dtrwDSEPE.nIdExportador == m_nIdExportador) && (dtrwDSEPE.nIdDSE == nIdDSE))
						sortLstDSEPE.Add(dtrwDSEPE.strIdPE,dtrwDSEPE);
				}

				// Inserindo
				System.Windows.Forms.ListViewItem lviInserir;
				for(int i = 0; i < sortLstDSEPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)sortLstDSEPE.GetByIndex(i);
					lviInserir = lvDSEsVinculados.Items.Add(sortLstDSEPE.GetKey(i).ToString());
					lviInserir.Tag = dtrwDSEPE.nIdDSE;
				}
			}
		#endregion
		#region REsVinculados
			private bool bReVinculado(string strIdPE)
			{
				for (int i = 0;i < m_typDatSetREsPEs.tbREsPEs.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow dtrwVinculo = (mdlDataBaseAccess.Tabelas.XsdTbREsPEs.tbREsPEsRow)m_typDatSetREsPEs.tbREsPEs[i];
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
				for(int i = 0; i < m_typDatSetDSEsPEs.tbDSEsPEs.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)m_typDatSetDSEsPEs.tbDSEsPEs.Rows[i];
					if ((dtrwDSEPE.RowState != System.Data.DataRowState.Deleted) && (dtrwDSEPE.nIdExportador == m_nIdExportador) && (dtrwDSEPE.strIdPE == m_strIdPe))
						sortLstDSEPE.Add(GetDSENumero(dtrwDSEPE.nIdDSE),dtrwDSEPE);
				}

				// Inserindo
				for(int i = 0; i < sortLstDSEPE.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow dtrwDSEPE = (mdlDataBaseAccess.Tabelas.XsdTbDSEsPEs.tbDSEsPEsRow)sortLstDSEPE.GetByIndex(i);
					if (strbPersonalizavel.ToString() != "")
						strbPersonalizavel.Append( " , ");
					strbPersonalizavel.Append(sortLstDSEPE.GetKey(i).ToString());
				}
				m_strPersonalizavel = strbPersonalizavel.ToString();
				if (m_typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPE = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetPes.tbPEs.Rows[0];
					dtrwPE.mstrDSE = m_strPersonalizavel; 
				}
			}
		#endregion
	}
}
