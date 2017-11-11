using System;

namespace mdlProdutosVinculacao.Faturas
{
	/// <summary>
	/// Summary description for clsProdutosVinculacaoComercial.
	/// </summary>
	public class clsProdutosVinculacaoComercial : clsProdutosVinculacao
	{
		#region Atributos
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial = null;
		#endregion

		#region Construtores & Destrutores
		public clsProdutosVinculacaoComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string idPE, int classificaoTarifaria, int Idioma, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref  ConnectionDB, EnderecoExecutavel, Exportador, classificaoTarifaria, Idioma, ref ilBandeiras)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
		}
		public clsProdutosVinculacaoComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string idPE, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref  ConnectionDB, EnderecoExecutavel, Exportador, ref ilBandeiras)
		{
			m_strIdPE = idPE;
			carregaTypDatSet();
			carregaDadosBD();
			carregaDadosIdClassificacaoIdIdioma();
		}
		public clsProdutosVinculacaoComercial(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, string idPE, int classificaoTarifaria, int Idioma, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, ref mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais, ref mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial, ref System.Windows.Forms.ImageList ilBandeiras): base(ref tratadorErro, ref  ConnectionDB, EnderecoExecutavel, Exportador, classificaoTarifaria, Idioma, ref typDatSetTbProdutos, ref ilBandeiras)
		{
			m_strIdPE = idPE;
			m_typDatSetTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais)typDatSetTbFaturasComerciais.Copy();
			m_typDatSetTbProdutosFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial)typDatSetTbProdutosFaturaComercial.Copy();
			carregaTypDatSet();
			carregaDadosBD();
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				if (m_typDatSetTbFaturasComerciais == null || m_typDatSetTbProdutosFaturaComercial == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);
					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPE);
					arlOrdenacaoCampo.Add("idOrdem");
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);

					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
					m_typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, arlOrdenacaoCampo, arlOrdenacaoTipo);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosBDEspecificos()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwTbProdutosFaturaComercial;
				m_arlIdProdutosFatura.Clear();
				for (int nCount = 0; nCount < m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows.Count; nCount++)
				{
					dtrwTbProdutosFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows[nCount];
					m_arlIdProdutosFatura.Add(dtrwTbProdutosFaturaComercial.idProduto);
					m_arlIdProdutosParents.Add(dtrwTbProdutosFaturaComercial.IsnIdOrdemProdutoParentNull() ? 0 : dtrwTbProdutosFaturaComercial.nIdOrdemProdutoParent);
				}
				carregaDadosClassificacao();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected override void carregaDadosIdClassificacaoIdIdioma()
		{
			try
			{
				if (m_typDatSetTbFaturasComerciais != null)
				{
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
						dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						m_nIdIdioma = (!dtrwTbFaturasComerciais.IsidIdiomaNull() ? dtrwTbFaturasComerciais.idIdioma : 1);
						m_nClassificaoTarifaria = (!dtrwTbFaturasComerciais.IsidClassificacaoTarifariaMostrarNull() ? dtrwTbFaturasComerciais.idClassificacaoTarifariaMostrar : 1);
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
		protected override void carregaDadosInterfaceEspecificos(ref System.Windows.Forms.Form formProdutosVinculacao)
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
				dtrwTbFaturasComerciais = m_typDatSetTbFaturasComerciais.tbFaturasComerciais.FindByidExportadoridPE(m_nIdExportador,m_strIdPE);
				if (dtrwTbFaturasComerciais != null)
				{
					formProdutosVinculacao.Text = "Produtos da Fatura Comercial: " + (dtrwTbFaturasComerciais.IsnumeroFaturaNull() ? dtrwTbFaturasComerciais.idPE : dtrwTbFaturasComerciais.numeroFatura);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		protected override void salvaDadosBDEspecificos()
		{
			try
			{
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion

		#region RetornaValores
		protected void retornaValores(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, out mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial typDatSetTbProdutosFaturaComercial, out mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetTbFaturasComerciais)
		{
			retornaValores(out typDatSetTbProdutos);
			typDatSetTbProdutosFaturaComercial = m_typDatSetTbProdutosFaturaComercial;
			typDatSetTbFaturasComerciais = m_typDatSetTbFaturasComerciais;
		}
		#endregion
	}
}
