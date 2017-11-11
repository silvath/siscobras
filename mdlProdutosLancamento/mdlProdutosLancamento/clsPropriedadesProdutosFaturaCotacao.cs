using System;

namespace mdlProdutosLancamento
{
	/// <summary>
	/// Summary description for clsPropriedadesProdutosFaturaCotacao.
	/// </summary>
	public class clsPropriedadesProdutosFaturaCotacao : clsPropriedadesProdutos
	{
		#region Atributes
			private string m_strIdCotacao = "";

			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades m_typDatSetProdutosPropriedades = null;
		#endregion
		#region Properties
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades TypDatSetProdutosPropriedades
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

				arlCondicaoCampo.Add("strIdCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCotacao);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetProdutosPropriedades = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacaoPropriedades(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(m_typDatSetProdutosPropriedades);
			}
		}	
		#endregion
		#region Constructors
			public clsPropriedadesProdutosFaturaCotacao(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdCotacao) : base (cls_dba_ConnectionDB,strEnderecoExecutavel,nIdExportador)
			{
				m_strIdCotacao = strIdCotacao;
			}
		#endregion

		#region Carregamento Dados
		protected override bool CarregaDados()
		{
			this.PropriedadesFatura.Clear();
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
			for(int i = 0 ;i < typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades.Rows.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades[i];
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
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades typDatSetPropriedades = this.TypDatSetProdutosPropriedades;
			//Deleting 
			for(int i = (typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades.Count - 1);i >=0;i--)
				typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades[i].Delete();
			// Inserting
			for(int i = 0; i < this.PropriedadesFatura.Count;i++)
			{
				clsPropriedade prop = this.PropriedadesFatura[i];
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacaoPropriedades.tbProdutosFaturaCotacaoPropriedadesRow dtrwPropriedade = typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades.NewtbProdutosFaturaCotacaoPropriedadesRow();

				dtrwPropriedade.nIdExportador = m_nIdExportador;
				dtrwPropriedade.strIdCotacao = m_strIdCotacao;
				dtrwPropriedade.nIdPropriedade = prop.IdPropriedade;
				dtrwPropriedade.nIdIdioma = prop.IdIdioma;
				dtrwPropriedade.nIdOrdem = prop.IdOrdemProduto;
				dtrwPropriedade.mstrDescricao = prop.Descricao;

				typDatSetPropriedades.tbProdutosFaturaCotacaoPropriedades.AddtbProdutosFaturaCotacaoPropriedadesRow(dtrwPropriedade);
			}
			m_cls_dba_ConnectionDB.SetTbProdutosFaturaCotacaoPropriedades(typDatSetPropriedades);
			m_typDatSetProdutosPropriedades = null;

			return(true);
		}
		#endregion
	}
}
