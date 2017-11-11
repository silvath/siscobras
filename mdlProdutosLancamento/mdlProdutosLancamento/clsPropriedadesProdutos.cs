using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedadesProdutos.
	/// </summary>
	public abstract class clsPropriedadesProdutos
	{
		#region Constants
		#endregion
		#region Atributes
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel; 

			protected int m_nIdExportador;
			
			private clsPropriedadeCollection m_propriedadesFatura = null;

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas m_typDatSetIdiomas = null;	
			private mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos m_propriedadesProdutos;
		#endregion
		#region Properties
			protected mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos PropriedadesProdutos
			{
				get
				{
					if (m_propriedadesProdutos != null)
						return(m_propriedadesProdutos);
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					m_propriedadesProdutos = m_cls_dba_ConnectionDB.GetTbPropriedadesProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_propriedadesProdutos);
				}
			}

			protected clsPropriedadeCollection PropriedadesFatura
			{
				get
				{
					if (m_propriedadesFatura == null)
					{
						m_propriedadesFatura = new clsPropriedadeCollection();
						this.CarregaDados();
					}
					return(m_propriedadesFatura);
				}
			}

			private mdlDataBaseAccess.Tabelas.XsdTbIdiomas Idiomas
			{
				get
				{
					if (m_typDatSetIdiomas != null)
						return(m_typDatSetIdiomas);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetIdiomas = m_cls_dba_ConnectionDB.GetTbIdiomas(null,null,null,null,null);
					return(m_typDatSetIdiomas);
				}
			}
		#endregion
		#region Constructors and Destructors
		public clsPropriedadesProdutos(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador)
		{
			m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel; 
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region Carregamento Dados
			protected abstract bool CarregaDados(); 
		#endregion
		#region Salvamento Dados
			internal abstract bool SalvaDados(); 
		#endregion

		#region Preenchendo Propriedades
			public bool PreenchePropriedadesProduto(int nIdOrdemProduto,System.Data.DataRow dtrwProduto)
			{
				for(int i = 0; i < dtrwProduto.Table.Columns.Count;i++)
				{
					System.Data.DataColumn dtclColuna = dtrwProduto.Table.Columns[i];
					int nIdIdioma,nIdPropriedade;
					GetPropriedadeIdioma(dtclColuna.ColumnName,out nIdIdioma,out nIdPropriedade);
					if ((nIdIdioma == -1) || (nIdPropriedade == -1))
						continue;
					clsPropriedade prop = this.PropriedadesFatura.GetPropriedade(nIdIdioma,nIdPropriedade,nIdOrdemProduto);
					if (prop == null)
						continue;
					dtrwProduto[dtclColuna] = prop.Descricao;
				}
				return(true);
			}

			public bool UpdatePropriedadesProduto(int nIdOrdemProduto,System.Data.DataRow dtrwProduto)
			{
				for(int i = 0; i < dtrwProduto.Table.Columns.Count;i++)
				{
					System.Data.DataColumn dtclColuna = dtrwProduto.Table.Columns[i];
					int nIdIdioma,nIdPropriedade;
					GetPropriedadeIdioma(dtclColuna.ColumnName,out nIdIdioma,out nIdPropriedade);
					if ((nIdIdioma == -1) || (nIdPropriedade == -1))
						continue;
					string strPropriedade = "";
					object obj = dtrwProduto[i];
					if (obj != null)
						strPropriedade = obj.ToString();
					clsPropriedade prop = this.PropriedadesFatura.GetPropriedade(nIdIdioma,nIdPropriedade,nIdOrdemProduto);
					if (prop == null)
					{
						if (strPropriedade != "")
						{
							this.PropriedadesFatura.Add(nIdIdioma,nIdPropriedade,nIdOrdemProduto,strPropriedade);
						}
					}else{
						if (strPropriedade != "")
						{
							prop.Descricao = strPropriedade;
						}else{
							this.PropriedadesFatura.Delete(nIdIdioma,nIdPropriedade,nIdOrdemProduto);
						}
					}
				}
				return(true);
			}
		#endregion

		#region Delete
			public bool DeletePropriedadesProduto(int nIdOrdem)
			{
				for(int i = (this.PropriedadesFatura.Count - 1); i >= 0;i--)
				{
					clsPropriedade obj = this.PropriedadesFatura[i];
					if (obj.IdOrdemProduto == nIdOrdem)
						this.PropriedadesFatura.Remove(i);
				}
				return(true);
			}	
		#endregion

		#region Propriedade
			private void GetPropriedadeIdioma(string strDescricao,out int nIdIdioma, out int nIdPropriedade)
			{
				nIdIdioma = nIdPropriedade = -1;
				//Idioma
                mdlDataBaseAccess.Tabelas.XsdTbIdiomas typDatSetIdiomas = this.Idiomas;
				for(int i = 0; i < typDatSetIdiomas.tbIdiomas.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = typDatSetIdiomas.tbIdiomas[i];
					if (strDescricao.StartsWith(dtrwIdioma.mstrIdioma))
					{
						nIdIdioma = dtrwIdioma.idIdioma;
						break;
					}
				}
				// Propriedade
				if (nIdIdioma != -1)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos typDatSetPropriedadesProdutos = this.PropriedadesProdutos;
					for(int i = 0; i < typDatSetPropriedadesProdutos.tbPropriedadesProdutos.Count;i++)
					{
						mdlDataBaseAccess.Tabelas.XsdTbPropriedadesProdutos.tbPropriedadesProdutosRow dtrwPropriedade = typDatSetPropriedadesProdutos.tbPropriedadesProdutos[i];
						if (strDescricao.EndsWith(dtrwPropriedade.mstrDescricao))
						{
							nIdPropriedade = dtrwPropriedade.nIdPropriedade;
							break;
						}
					}
				}
			}

			public string GetPropridadeValor(int nIdIdioma,int nIdCampoPropriedade,int nIdOrdemProduto)
			{
				int nIdPropriedade = -1;
				string strIdCampoPropriedade = nIdCampoPropriedade.ToString();
				if ((strIdCampoPropriedade.Length < 3) || (!strIdCampoPropriedade.EndsWith("97")))
					return("");
				nIdPropriedade = Int32.Parse(strIdCampoPropriedade.Substring(0,strIdCampoPropriedade.Length - 2));
				clsPropriedade prop = this.PropriedadesFatura.GetPropriedade(nIdIdioma,nIdPropriedade,nIdOrdemProduto);
				if (prop == null)
					return("");
				return(prop.Descricao);
			}
		#endregion

		#region Idioma
			private string GetPropriedadeDescricaoColuna(int nIdIdioma,string strPropriedade)
			{
				mdlDataBaseAccess.Tabelas.XsdTbIdiomas.tbIdiomasRow dtrwIdioma = this.Idiomas.tbIdiomas.FindByidIdioma(nIdIdioma);
				if (dtrwIdioma != null)
					return(dtrwIdioma.mstrIdioma +" : " + strPropriedade);
				return("");
			}
		#endregion

		#region Ordem
			public bool TrocaOrdemProduto(int nIdOrdem1,int nIdOrdem2)
			{
				for(int i = 0;i < this.PropriedadesFatura.Count;i++)
				{
					clsPropriedade objProp = this.PropriedadesFatura[i];
					if (objProp.IdOrdemProduto == nIdOrdem1)
					{
						objProp.IdOrdemProduto = nIdOrdem2;
					}else if (objProp.IdOrdemProduto == nIdOrdem2){
						objProp.IdOrdemProduto = nIdOrdem1;
					}
				}
				return(true);
			}
		#endregion
	}
}
