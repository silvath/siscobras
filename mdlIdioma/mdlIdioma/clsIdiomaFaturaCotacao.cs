using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaFaturaCotacao.
	/// </summary>
	public class clsIdiomaFaturaCotacao: clsIdioma
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao m_typDatSetProdutosFatura = null;
		#endregion
		#region Propriedades
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao TypDatSetProdutosFatura
		{
			get
			{
				if (m_typDatSetProdutosFatura != null)
					return(m_typDatSetProdutosFatura);

				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strCodigo);
																					 
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaCotacao(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(m_typDatSetProdutosFatura);
			}
		}
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaFaturaCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,Codigo, ref bandeiras)
		{
			try 
			{
				this.carregaDadosBD();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento de Dados
			protected override void carregaDadosBDEspecificos()
			{
				try 
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

					System.Collections.ArrayList arlCondicoesNome = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
					arlCondicoesNome.Add("idExportador");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_nIdExportador);
					arlCondicoesNome.Add("idCotacao");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strCodigo);
					m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturas;
						for (int nCount = 0; nCount < m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count; nCount++)
						{
							dtrwFaturas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[nCount];
							if (!dtrwFaturas.IsidIdiomaNull())
							{
								m_nIdioma = dtrwFaturas.idIdioma;
								this.IdiomaAntigo = m_nIdioma;
							}
						}
					}
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.GroupBox gbFields)
			{
				try
				{
					gbFields.Text = "Fatura Cotação";
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion
		#region Salvamento de Dados
			protected override void SalvaDadosBDEspecificos()
			{
				try 
				{
					if (m_bModificado)
					{
						if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwFaturas = m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.FindByidExportadoridCotacao(m_nIdExportador,m_strCodigo);
							if (dtrwFaturas != null)
							{
								dtrwFaturas.idIdioma = m_nIdioma;
								m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
								UpdateProdutosFatura();
							}
						}
					}
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

		#region Produtos
		private bool UpdateProdutosFatura()
		{
			if (m_nIdioma == this.IdiomaAntigo)
				return(true);
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao typDatSetProdutosFatura = this.TypDatSetProdutosFatura;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = this.TypDatSetProdutosIdiomas;
			for(int i = 0; i < typDatSetProdutosFatura.tbProdutosFaturaCotacao.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaCotacao.tbProdutosFaturaCotacaoRow dtrwProdutoFatura = typDatSetProdutosFatura.tbProdutosFaturaCotacao[i];
				string strDescricaoIdioma = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = typDatSetProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
				if ((dtrwProdutoIdioma != null) && (!dtrwProdutoIdioma.IsstrDescricaoNull()))
					strDescricaoIdioma = dtrwProdutoIdioma.strDescricao;
				dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira = strDescricaoIdioma;
			}
			m_cls_dba_ConnectionDB.SetTbProdutosFaturaCotacao(typDatSetProdutosFatura);
			return(true);
		}
		#endregion
	}
}
