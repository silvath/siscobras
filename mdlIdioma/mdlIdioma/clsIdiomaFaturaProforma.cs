using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaFaturaProforma.
	/// </summary>
	public class clsIdiomaFaturaProforma : clsIdioma
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma m_typDatSetProdutosFatura = null;
		#endregion
		#region Propriedades
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma TypDatSetProdutosFatura
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

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strCodigo);
																					 
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaProforma(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				return(m_typDatSetProdutosFatura);
			}
		}
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaFaturaProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,Codigo, ref bandeiras)
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
			#region Banco de Dados
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
					arlCondicoesNome.Add("idPE");
					arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicoesValor.Add(m_strCodigo);
					m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFaturas;
						for (int nCount = 0; nCount < m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count; nCount++)
						{
							dtrwFaturas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[nCount];
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
			#endregion
			#region Interface
			protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.GroupBox gbFields)
			{
				try
				{
					gbFields.Text = "Fatura Proforma";
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion
		#region Salvamento de Dados
			protected override void SalvaDadosBDEspecificos()
			{
				try 
				{
					if (m_bModificado)
					{
						if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwFaturas = m_typDatSetTbFaturasProformas.tbFaturasProformas.FindByidExportadoridPE(m_nIdExportador,m_strCodigo);
							if (dtrwFaturas != null)
							{
								dtrwFaturas.idIdioma = m_nIdioma;
								m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
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
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma typDatSetProdutosFatura = this.TypDatSetProdutosFatura;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = this.TypDatSetProdutosIdiomas;
			for(int i = 0; i < typDatSetProdutosFatura.tbProdutosFaturaProforma.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaProforma.tbProdutosFaturaProformaRow dtrwProdutoFatura = typDatSetProdutosFatura.tbProdutosFaturaProforma[i];
				string strDescricaoIdioma = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = typDatSetProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
				if ((dtrwProdutoIdioma != null) && (!dtrwProdutoIdioma.IsstrDescricaoNull()))
					strDescricaoIdioma = dtrwProdutoIdioma.strDescricao;
				dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira = strDescricaoIdioma;
			}
			m_cls_dba_ConnectionDB.SetTbProdutosFaturaProforma(typDatSetProdutosFatura);
			return(true);
		}
		#endregion

	}
}
