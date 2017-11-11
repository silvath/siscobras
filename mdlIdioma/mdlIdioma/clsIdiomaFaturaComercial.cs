using System;

namespace mdlIdioma
{
	/// <summary>
	/// Summary description for clsIdiomaFaturaComercial.
	/// </summary>
	public class clsIdiomaFaturaComercial: clsIdioma
	{
		#region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais;
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetProdutosFatura = null;
		#endregion
		#region Propriedades
			private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial TypDatSetProdutosFatura
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
					m_typDatSetProdutosFatura = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					return(m_typDatSetProdutosFatura);
				}
			}
		#endregion
		#region Construtores e Destrutores
		public clsIdiomaFaturaComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string Codigo, ref System.Windows.Forms.ImageList bandeiras): base(ref tratadorErro, ref ConnectionDB,EnderecoExecutavel,Exportador,Codigo, ref bandeiras)
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
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicoesNome,arlCondicoesComparador,arlCondicoesValor,null,null);
					if ( m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturas;
						for (int nCount = 0; nCount < m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count; nCount++)
						{
							dtrwFaturas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[nCount];
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
					gbFields.Text = "Fatura Comercial";
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
						if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
						{
							mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturas = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strCodigo);
							if (dtrwFaturas != null)
							{
								dtrwFaturas.idIdioma = m_nIdioma;
								m_cls_dba_ConnectionDB.SetTbFaturasComerciais(m_typDatSetTbFaturasComerciais);
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
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetProdutosFatura = this.TypDatSetProdutosFatura;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas typDatSetProdutosIdiomas = this.TypDatSetProdutosIdiomas;
				for(int i = 0; i < typDatSetProdutosFatura.tbProdutosFaturaComercial.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = typDatSetProdutosFatura.tbProdutosFaturaComercial[i];
					string strDescricaoIdioma = "";
					mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas.tbProdutosIdiomasRow dtrwProdutoIdioma = typDatSetProdutosIdiomas.tbProdutosIdiomas.FindByidExportadoridIdiomaidProduto(m_nIdExportador,m_nIdioma,dtrwProdutoFatura.idProduto);
					if ((dtrwProdutoIdioma != null) && (!dtrwProdutoIdioma.IsstrDescricaoNull()))
						strDescricaoIdioma = dtrwProdutoIdioma.strDescricao;
					dtrwProdutoFatura.mstrDescricaoLinguaEstrangeira = strDescricaoIdioma;
				}
				m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(typDatSetProdutosFatura);
				return(true);
			}
		#endregion
	}
}
