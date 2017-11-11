using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedadesProdutosFaturaComercial.
	/// </summary>
	public class clsPropriedadesProdutosFaturaComercial : clsPropriedadesProdutos
	{
		#region Atributes
			private string m_strIdPe = "";

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades m_typDatSetProdutosPropriedades = null;
		#endregion
		#region Properties
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades TypDatSetProdutosPropriedades
			{
				get
				{
					if (m_typDatSetProdutosPropriedades != null)
						return(m_typDatSetProdutosPropriedades);
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProdutosPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercialPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosPropriedades);
				}
			}	
		#endregion
		#region Constructors
			public clsPropriedadesProdutosFaturaComercial(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe) : base (cls_dba_ConnectionDB,strEnderecoExecutavel,nIdExportador)
			{
				m_strIdPe = strIdPe;
			}
		#endregion 

		#region Carregamento Dados
			protected override bool CarregaDados()
			{
				this.PropriedadesFatura.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
				for(int i = 0 ;i < typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaComercialPropriedades[i];
					if (dtrwPropriedade.RowState != System.Data.DataRowState.Deleted)
						this.PropriedadesFatura.Add(dtrwPropriedade.nIdIdioma,dtrwPropriedade.nIdPropriedade,dtrwPropriedade.nIdOrdem,dtrwPropriedade.mstrDescricao);
				}
				return(true);
			} 
		#endregion
		#region Salvamento Dados
			internal override bool SalvaDados()
			{
				m_typDatSetProdutosPropriedades = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
				//Deleting 
				for(int i = (typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.Count - 1);i >=0;i--)
					typDatSetPropriedades.tbProdutosFaturaComercialPropriedades[i].Delete();
				// Inserting
				for(int i = 0; i < this.PropriedadesFatura.Count;i++)
				{
					clsPropriedade prop = this.PropriedadesFatura[i];
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercialPropriedades.tbProdutosFaturaComercialPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.NewtbProdutosFaturaComercialPropriedadesRow();

					dtrwPropriedade.nIdExportador = m_nIdExportador;
					dtrwPropriedade.strIdPe = m_strIdPe;
					dtrwPropriedade.nIdPropriedade = prop.IdPropriedade;
					dtrwPropriedade.nIdIdioma = prop.IdIdioma;
					dtrwPropriedade.nIdOrdem = prop.IdOrdemProduto;
					dtrwPropriedade.mstrDescricao = prop.Descricao;

					typDatSetPropriedades.tbProdutosFaturaComercialPropriedades.AddtbProdutosFaturaComercialPropriedadesRow(dtrwPropriedade);
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercialPropriedades(typDatSetPropriedades);
				m_typDatSetProdutosPropriedades = null;
				return(true);
			}
		#endregion
	}
}
