using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedadesProdutosFaturaProforma.
	/// </summary>
	public class clsPropriedadesProdutosFaturaProforma : clsPropriedadesProdutos
	{
		#region Atributes
		private string m_strIdPe = "";

		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades m_typDatSetProdutosPropriedades = null;
		#endregion
		#region Properties
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades TypDatSetProdutosPropriedades
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
				m_typDatSetProdutosPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProformaPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(m_typDatSetProdutosPropriedades);
			}
		}	
		#endregion
		#region Constructors
		public clsPropriedadesProdutosFaturaProforma(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe) : base (cls_dba_ConnectionDB,strEnderecoExecutavel,nIdExportador)
		{
			m_strIdPe = strIdPe;
		}
		#endregion 

		#region Carregamento Dados
			protected override bool CarregaDados()
			{
				this.PropriedadesFatura.Clear();
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
				for(int i = 0 ;i < typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.Rows.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaProformaPropriedades[i];
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
				//Deleting 
				for(int i = (typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.Count - 1);i >=0;i--)
					typDatSetPropriedades.tbProdutosFaturaProformaPropriedades[i].Delete();
				// Inserting
				for(int i = 0; i < this.PropriedadesFatura.Count;i++)
				{
					clsPropriedade prop = this.PropriedadesFatura[i];
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProformaPropriedades.tbProdutosFaturaProformaPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.NewtbProdutosFaturaProformaPropriedadesRow();

					dtrwPropriedade.nIdExportador = m_nIdExportador;
					dtrwPropriedade.strIdPe = m_strIdPe;
					dtrwPropriedade.nIdPropriedade = prop.IdPropriedade;
					dtrwPropriedade.nIdIdioma = prop.IdIdioma;
					dtrwPropriedade.nIdOrdem = prop.IdOrdemProduto;
					dtrwPropriedade.mstrDescricao = prop.Descricao;

					typDatSetPropriedades.tbProdutosFaturaProformaPropriedades.AddtbProdutosFaturaProformaPropriedadesRow(dtrwPropriedade);
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaProformaPropriedades(typDatSetPropriedades);
				m_typDatSetProdutosPropriedades = null;
				return(true);
			}
		#endregion

	}
}
