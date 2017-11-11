using System;

namespace mdlRE
{
	/// <summary>
	/// Summary description for clsREEspelho.
	/// </summary>
	public class clsREEspelho
	{
		#region Enum
			internal enum TypeREEspelhoNew
			{
				Cancelar,
				BaseadoPE,
				Branco,
				BaseadoRELocal,
				BaseadoRESiscomex
			}

			internal enum StateREEspelho
			{
				Incompleto,
				Efetivado,
				Averbado
			}
		#endregion

		#region Atributes
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			protected string m_strEnderecoExecutavel;

			private int m_nIdExportador = -1;

			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos m_typDatSetTbREsEspelhos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos m_typDatSetTbREsEspelhosAnexos = null;
		#endregion
		#region Properties
			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos TypDatSetTbREsEspelhos
			{
				get
				{
					if (m_typDatSetTbREsEspelhos == null)
						m_typDatSetTbREsEspelhos = this.LoadTbREsEspelhos();
					return(m_typDatSetTbREsEspelhos);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos TypDatSetTbREsEspelhosAnexos
			{
				get
				{
					if (m_typDatSetTbREsEspelhosAnexos == null)
						m_typDatSetTbREsEspelhosAnexos = this.LoadTbREsEspelhosAnexos();
					return(m_typDatSetTbREsEspelhosAnexos);
				}
			}
		#endregion
		#region Constructors
			public clsREEspelho(mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador)
			{
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
			}

			public clsREEspelho(string strDataBasePath, string strEnderecoExecutavel)
			{
				mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro = new mdlTratamentoErro.clsTratamentoErro();
				m_cls_dba_ConnectionDB = new mdlDataBaseAccess.clsDataBaseAccessOleDbJet40(ref cls_ter_tratadorErro,"","","");
				cls_ter_tratadorErro.ConnectionDB = m_cls_dba_ConnectionDB;
				cls_ter_tratadorErro.EnderecoExecutavel = strEnderecoExecutavel;
				m_cls_dba_ConnectionDB.DirectoryFiles = strDataBasePath;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Directory;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Load Data
			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos LoadTbREsEspelhos()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				return(m_cls_dba_ConnectionDB.GetTbREsEspelhos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}	

			private mdlDataBaseAccess.Tabelas.XsdTbREsEspelhosAnexos LoadTbREsEspelhosAnexos()
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				return(m_cls_dba_ConnectionDB.GetTbREsEspelhosAnexos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null));
			}	

			private void CarregaDadosEspelhoRE(int nIdREEspelho, out string strRENumero, out string strREDataRegistro, out string strRESituacao, out string strREREspRegistro, out string strREOperador, out string strREDataHora, out string strExportadorCPF, out string strExportadorNome, out string strEOCodigo1, out string strEOCodigo2, out string strEOCodigo3, out string strEOCodigo4, out string strEOCodigo5, out string strEOCodigo6, out string strEONumRV, out string strEONumAtoConc, out string strEONumRC, out string strEODataLimiteOperacao, out string strEOGEDERE, out string strEOMargemNaoSacada, out string strEODIRIVinc, out string strEONumProcesso, out string strEOSGPVinc, out string strUnidadeRFDespacho, out string strUnidadeRFEmbarque, out string strImportadorNome, out string strImportadorEndereco, out string strImportadorPais)
			{
				strRENumero = "";
				strREDataRegistro = "";
				strRESituacao = "";
				strREREspRegistro = "";
				strREOperador = "";
				strREDataHora = "";
				strExportadorCPF = "";
				strExportadorNome = "";
				strEOCodigo1 = "";
				strEOCodigo2 = "";
				strEOCodigo3 = "";
				strEOCodigo4 = "";
				strEOCodigo5 = "";
				strEOCodigo6 = "";
				strEONumRV = "";
				strEONumAtoConc = "";
				strEONumRC = "";
				strEODataLimiteOperacao = "";
				strEOGEDERE = "";
				strEOMargemNaoSacada = "";
				strEODIRIVinc = "";
				strEONumProcesso = "";
				strEOSGPVinc = "";
				strUnidadeRFDespacho = "";
				strUnidadeRFEmbarque = "";
				strImportadorNome = "";
				strImportadorEndereco = "";
				strImportadorPais = "";

			}
		#endregion
		#region Save Data
			private bool SaveData()
			{
				if (SaveTbREsEspelhos())
					if (SaveTbREsEspelhosAnexos())
						return(true);
				return(false);
			}
			private bool SaveTbREsEspelhos()
			{
				m_cls_dba_ConnectionDB.SetTbREsEspelhos(this.TypDatSetTbREsEspelhos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool SaveTbREsEspelhosAnexos()
			{
				m_cls_dba_ConnectionDB.SetTbREsEspelhosAnexos(this.TypDatSetTbREsEspelhosAnexos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				Formularios.frmFREEspelho formFEspelho = new mdlRE.Formularios.frmFREEspelho();
				formFEspelho.eCallREsEspelhosRefresh += new mdlRE.Formularios.frmFREEspelho.delCallREsEspelhosRefresh(RefreshREsEspelhos);
				formFEspelho.eCallREsEspelhosNew += new mdlRE.Formularios.frmFREEspelho.delCallREsEspelhosNew(ShowDialogNew);
				formFEspelho.eCallREsEspelhosEdit += new mdlRE.Formularios.frmFREEspelho.delCallREsEspelhosEdit(EditREEspelho);
				formFEspelho.eCallREsEspelhosDelete += new mdlRE.Formularios.frmFREEspelho.delCallREsEspelhosDelete(DeleteREEspelho);
				formFEspelho.ShowDialog();
				if (formFEspelho.Confirmed)
				{
					SaveData();
					return(true);
				}
				return(false);
			}
		#endregion
		#region ShowDialogNew
			public int ShowDialogNew()
			{
				int nReturn = 0;
				Formularios.frmFREEspelhoNew formFEspelhoNew = new mdlRE.Formularios.frmFREEspelhoNew();
				formFEspelhoNew.TypeBaseadoPE = m_cls_dba_ConnectionDB.FonteDosDados == mdlDataBaseAccess.FonteDados.DataBase;
				formFEspelhoNew.ShowDialog();
				switch(formFEspelhoNew.TypeREEspelho)
				{
					case TypeREEspelhoNew.Cancelar:
						nReturn = 0;
						break;
					case TypeREEspelhoNew.Branco:
						nReturn = CreateNewREEspelhoBranco();
						break;
				}
				return(nReturn);
			}
		#endregion
		#region ShowDialogREEspelho
			private bool ShowDialogREEspelho(int nIdREEspelho)
			{
				return(EditREEspelho(nIdREEspelho));
			}
		#endregion

		#region Refresh
			private void RefreshREsEspelhos(System.Windows.Forms.ListView lvResEspelhos, int index)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos typDatSetREsEspelhos = this.TypDatSetTbREsEspelhos;
				lvResEspelhos.Items.Clear();
				for(int i = 0; i< typDatSetREsEspelhos.tbREsEspelhos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos.tbREsEspelhosRow dtrwREEspelho = typDatSetREsEspelhos.tbREsEspelhos[i];
					if (dtrwREEspelho.RowState == System.Data.DataRowState.Deleted)
						continue;
					System.Windows.Forms.ListViewItem lviItem = lvResEspelhos.Items.Add(dtrwREEspelho.nIdReEspelho.ToString("00000"));
					lviItem.Tag = dtrwREEspelho.nIdReEspelho;
					//Inserting Data
					lviItem.SubItems.Add("Estado");
					lviItem.SubItems.Add("Numero");
					lviItem.SubItems.Add("PE");
					lviItem.SubItems.Add(dtrwREEspelho.dtCriacao.ToString("dd/MM/yyyy"));

					if (dtrwREEspelho.nIdReEspelho == index)
					{
						lviItem.Selected = true;
						lvResEspelhos.EnsureVisible(lviItem.Index);
					}
				}
			}
		#endregion

		#region New
			private int GetNewId(mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos typDatSetTbREsEspelhos)
			{
				int index = 1;
				bool Exists = true;
				while(Exists)
				{
					Exists = false;
					for(int i = 0; i < typDatSetTbREsEspelhos.tbREsEspelhos.Rows.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos.tbREsEspelhosRow dtrwREEspelho = typDatSetTbREsEspelhos.tbREsEspelhos[i];
						if (dtrwREEspelho.RowState == System.Data.DataRowState.Deleted)
							continue;
						if (Exists = dtrwREEspelho.nIdReEspelho == index)
						{
							index++;
							break;
						}
					}																						   
				}
				return(index);
			}

			private int CreateNewREEspelhoBranco()
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos.tbREsEspelhosRow dtrwREEspelho = this.TypDatSetTbREsEspelhos.tbREsEspelhos.NewtbREsEspelhosRow();
				dtrwREEspelho.nIdExportador = m_nIdExportador;
				dtrwREEspelho.nIdReEspelho = GetNewId(this.TypDatSetTbREsEspelhos);
				dtrwREEspelho.dtCriacao = System.DateTime.Now;
				this.TypDatSetTbREsEspelhos.tbREsEspelhos.AddtbREsEspelhosRow(dtrwREEspelho);
				if (SaveTbREsEspelhos())
				{
					m_typDatSetTbREsEspelhos = null;
					return(dtrwREEspelho.nIdReEspelho);
				}
				return(-1);
			}

			private int CreateNewREEspelhoBaseadoPE()
			{
				return(-1);
			}
		#endregion
		#region Edit
			private bool EditREEspelho(int nIdREEspelho)
			{
				Formularios.frmFREEspelhoView formFREEspelhoView = new mdlRE.Formularios.frmFREEspelhoView(nIdREEspelho);
				formFREEspelhoView.eCallCarregaDadosEspelhoRE += new mdlRE.Formularios.frmFREEspelhoView.delCallCarregaDadosEspelhoRE(CarregaDadosEspelhoRE);

				formFREEspelhoView.ShowDialog();
				if (formFREEspelhoView.Confirmed)
				{
					return(SaveData());
				}else{
					m_typDatSetTbREsEspelhos = null;
					m_typDatSetTbREsEspelhosAnexos = null;
					return(false);
				}				
			}	
		#endregion
		#region Delete
			private bool DeleteREEspelho(int nIdREEspelho)
			{
				return(DeleteREEspelho(nIdREEspelho,true));
			}

			private bool DeleteREEspelho(int nIdREEspelho,bool ShowMessage)
			{
				mdlDataBaseAccess.Tabelas.XsdTbREsEspelhos.tbREsEspelhosRow dtrwREEspelho = this.TypDatSetTbREsEspelhos.tbREsEspelhos.FindBynIdExportadornIdReEspelho(m_nIdExportador,nIdREEspelho);
				if ((dtrwREEspelho == null) || (dtrwREEspelho.RowState == System.Data.DataRowState.Deleted))
					return(false);
				dtrwREEspelho.Delete();
				if (SaveTbREsEspelhos())
				{
					m_typDatSetTbREsEspelhos = null;
					return(true);
				}
				return(false);
			}
		#endregion
	}
}
