using System;

namespace mdlProdutosVinculacao
{
	#region Enums
		public enum Classificacao
		{
			Ncm = 1,
			Naladi = 2
		}
	#endregion
	/// <summary>
	/// Summary description for clsProdutosVincular.
	/// </summary>
	public class clsProdutosVincular
	{
		#region Constants
			private const string CAPTION_NCM = "Ncm";
			private const string CAPTION_NALADI = "Naladi";
		#endregion
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			private Formularios.frmFProdutosVincular m_formFProdutosVincular = null;
			private bool m_bMostrarProdutosVinculados = false;

			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			private Classificacao m_enumClassificacao = Classificacao.Ncm;

			// TypedDatSets
			mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetProdutos = null;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosIdiomas m_typDatSetProdutosIdiomas = null;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetProdutosFaturaComercial = null;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetProdutosNcm = null;
			mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetProdutosNaladi = null;
		#endregion
		#region Properties
			public bool ProdutosVinculados
			{
				set
				{
					m_bMostrarProdutosVinculados = value;
				}
				get
				{
					return(m_bMostrarProdutosVinculados);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsProdutosVincular(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,int nIdExportador,string strIdPe,Classificacao enumClassificacao)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro; 
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;

				m_enumClassificacao = enumClassificacao;

				vCarregaDados();
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				bool bRetorno = false;
				m_formFProdutosVincular = new Formularios.frmFProdutosVincular(m_strEnderecoExecutavel);
				vInitializeEvents(ref m_formFProdutosVincular);
				m_formFProdutosVincular.ShowDialog();
				if (bRetorno = m_formFProdutosVincular.m_bModificado)
					bRetorno = bSalvaDados();
				return(bRetorno);
			}

			private void vInitializeEvents(ref Formularios.frmFProdutosVincular m_formFProdutosVincular)
			{
				// Carrega Caption
				m_formFProdutosVincular.eCallCarregaCaption += new Formularios.frmFProdutosVincular.delCallCarregaCaption(m_formFProdutosVincular_eCallCarregaCaption);

				// Carrega Classificacao
				m_formFProdutosVincular.eCallCarregaDadosClassificacao += new Formularios.frmFProdutosVincular.delCallCarregaDadosClassificacao(bCarregaDadosClassificacao);

				// Carrega Configuracao
				m_formFProdutosVincular.eCallCarregaConfiguracao += new mdlProdutosVinculacao.Formularios.frmFProdutosVincular.delCallCarregaConfiguracao(m_formFProdutosVincular_eCallCarregaConfiguracao);

				// Salva Configuracao
				m_formFProdutosVincular.eCallSalvaConfiguracao += new mdlProdutosVinculacao.Formularios.frmFProdutosVincular.delCallSalvaConfiguracao(m_formFProdutosVincular_eCallSalvaConfiguracao);

				// Refresh Classificacao
				m_formFProdutosVincular.eCallRefreshClassificacao +=new Formularios.frmFProdutosVincular.delCallRefreshClassificacao(m_formFProdutosVincular_eCallRefreshClassificacao);

				// Refresh Produtos
				m_formFProdutosVincular.eCallRefreshProdutos += new Formularios.frmFProdutosVincular.delCallRefreshProdutos(m_formFProdutosVincular_eCallRefreshProdutos);

				// ShowDialogClassificacaoEdicao
				m_formFProdutosVincular.eCallShowDialogClassificacao += new Formularios.frmFProdutosVincular.delCallShowDialogClassificacao(ShowDialogClassificacaoEdicao);

				// Tec Siscobras
				m_formFProdutosVincular.eCallShowDialogTecSiscobras += new mdlProdutosVinculacao.Formularios.frmFProdutosVincular.delCallShowDialogTecSiscobras(ShowDialogTecSiscobras);
				
				// Associar
				m_formFProdutosVincular.eCallAssociaClassificacaoProdutos +=new Formularios.frmFProdutosVincular.delCallAssociaClassificacaoProdutos(m_formFProdutosVincular_eCallAssociaClassificacaoProdutos);

				// Salva Dados
				m_formFProdutosVincular.eCallSalvaDados += new Formularios.frmFProdutosVincular.delCallSalvaDados(bSalvaDados);

			}

			private void m_formFProdutosVincular_eCallCarregaConfiguracao(out bool bMostrarProdutosAssociados)
			{
				bMostrarProdutosAssociados = !m_bMostrarProdutosVinculados;
			}

			private void m_formFProdutosVincular_eCallSalvaConfiguracao(bool bMostrarProdutosAssociados)
			{
				m_bMostrarProdutosVinculados = !bMostrarProdutosAssociados;
			}
		#endregion
		#region ShowDialogClassificacaoEdicao
		private bool ShowDialogClassificacaoEdicao()
		{
			bool bRetorno = false;
			System.Windows.Forms.ImageList ilBandeiras = new System.Windows.Forms.ImageList();
			switch(m_enumClassificacao)
			{
				case Classificacao.Ncm:
					mdlClassificacao.clsNcm cls_Ncm = new mdlClassificacao.clsNcm(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,-1,ref m_typDatSetProdutos,ref m_typDatSetProdutosNcm,false,ref ilBandeiras);
					cls_Ncm.ShowDialog();
					bRetorno = cls_Ncm.m_bModificado;
					break;
				case Classificacao.Naladi:
					mdlClassificacao.clsNaladi cls_Naladi = new mdlClassificacao.clsNaladi(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,-1,ref m_typDatSetProdutos,ref m_typDatSetProdutosNaladi,false,ref ilBandeiras);
					cls_Naladi.ShowDialog();
					bRetorno = cls_Naladi.m_bModificado;
					break;
			}
			return(bRetorno);
		}
		#endregion
		#region ShowDialogTecSiscobras
			private bool ShowDialogTecSiscobras()
			{
				mdlTec.clsTec tec = new mdlTec.clsTec(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				tec.Exportador = m_nIdExportador;
				tec.ShowDialog();
				if (tec.Modificado)
					bCarregaDadosClassificacao();
				return(tec.Modificado);
			}
		#endregion

		#region Carregamento Dados
		private void vCarregaDados()
		{
			bCarregaDadosClassificacao();

			System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

			arlCondicaoCampo.Add("nIdExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

			// Produtos 
			arlCondicaoCampo.Clear();
			arlCondicaoCampo.Add("idExportador");
			m_typDatSetProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			// Produtos Idioma
			m_typDatSetProdutosIdiomas = m_cls_dba_ConnectionDB.GetTbProdutosIdiomas(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

			// Produtos Fatura Comercial 
			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdPe);
			m_typDatSetProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
		}

		private bool bCarregaDadosClassificacao()
		{
			bool bRetorno = false;

			System.Collections.ArrayList arlCondicaoCampo = new	System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new	System.Collections.ArrayList();

			arlCondicaoCampo.Add("nIdExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

			switch(m_enumClassificacao)
			{
				case Classificacao.Ncm:
					// Produtos Ncm 
					m_typDatSetProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					break;
				case Classificacao.Naladi:
					// Produtos Naladi 
					m_typDatSetProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
					bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
					break;
			}
			return(bRetorno);
		}
		#endregion
		#region Salvamento Dados
		private bool bSalvaDados()
		{
			return(bSalvaDadosProdutos() && bSalvaDadosProdutosFatura());
		}

		private bool bSalvaDadosProdutos()
		{
			bool bRetorno = false;
			// Produtos 
			m_cls_dba_ConnectionDB.SetTbProdutos(m_typDatSetProdutos);
			bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
			return(bRetorno);
		}

		private bool bSalvaDadosProdutosFatura()
		{
			bool bRetorno = false;
			// Produtos Fatura
			m_cls_dba_ConnectionDB.SetTbProdutosFaturaComercial(m_typDatSetProdutosFaturaComercial);
			bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
			return(bRetorno);
		}
			
		#endregion

		#region Formulario
		private void m_formFProdutosVincular_eCallCarregaCaption(out string strCaption)
		{
			switch(m_enumClassificacao)
			{
				case Classificacao.Ncm:
					strCaption = CAPTION_NCM;
					break;
				case Classificacao.Naladi:
					strCaption = CAPTION_NALADI;
					break;
				default:
					strCaption = CAPTION_NCM;
					break;
			}
		}
		#endregion

		#region Refresh
		private void m_formFProdutosVincular_eCallRefreshClassificacao(ref System.Windows.Forms.ListView lvClassificacao)
		{
			System.Windows.Forms.ListViewItem lviClassificacao = null;
			lvClassificacao.Items.Clear();
			switch(m_enumClassificacao)
			{
				case Classificacao.Ncm:
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwClassificacao in m_typDatSetProdutosNcm.tbProdutosNcm.Rows)
					{
						lviClassificacao = lvClassificacao.Items.Add(dtrwClassificacao.strNcm);
						lviClassificacao.SubItems.Add(dtrwClassificacao.mstrDenominacao);
						lviClassificacao.Tag = dtrwClassificacao.strNcm;
					}
					break;
				case Classificacao.Naladi:
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwClassificacao in m_typDatSetProdutosNaladi.tbProdutosNaladi.Rows)
					{
						lviClassificacao = lvClassificacao.Items.Add(dtrwClassificacao.strNaladi);
						lviClassificacao.SubItems.Add(dtrwClassificacao.mstrDenominacao);
						lviClassificacao.Tag = dtrwClassificacao.strNaladi;
					}
					break;
			}
		}

		private void m_formFProdutosVincular_eCallRefreshProdutos(ref System.Windows.Forms.ListView lvProdutos)
		{
			System.Windows.Forms.ListViewItem lviProduto = null;
			lvProdutos.Items.Clear();
			System.Collections.ArrayList arlProdutos = null;
			if (m_bMostrarProdutosVinculados)
				arlProdutos = arlProdutosFatura(false);
			else
				arlProdutos = arlProdutosFaturaSemVinculo(false);
			
			for(int i = 0; i < arlProdutos.Count;i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)arlProdutos[i];
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto =	m_typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
				if (dtrwProduto != null)
				{
					if (!dtrwProdutoFatura.IsmstrDescricaoNull())
						lviProduto = lvProdutos.Items.Add(dtrwProdutoFatura.mstrDescricao);
					else
						lviProduto = lvProdutos.Items.Add(dtrwProduto.mstrDescricao);
					lviProduto.Tag = dtrwProdutoFatura.idOrdem;
				}
			}
		}
		#endregion
		#region Produtos
		private bool m_formFProdutosVincular_eCallAssociaClassificacaoProdutos(string strClassificacao,string strDenominacao,ref System.Collections.ArrayList arlProdutosFatura)
		{
			bool bRetorno = false;
			for(int i = 0; i < arlProdutosFatura.Count;i++)
			{
				int nIdOrdem = Int32.Parse(arlProdutosFatura[i].ToString());
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPe,nIdOrdem);
				if (dtrwProdutoFatura != null)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
					if (dtrwProduto != null)
					{
						switch(m_enumClassificacao)
						{
							case Classificacao.Ncm:
								dtrwProduto.strNcm = strClassificacao;
								dtrwProdutoFatura.strNcm = strClassificacao;
								dtrwProdutoFatura.mstrNcmDenominacao = strDenominacao;
								break;
							case Classificacao.Naladi:
								dtrwProduto.strNaladi = strClassificacao;
								dtrwProdutoFatura.strNaladi = strClassificacao;
								dtrwProdutoFatura.mstrNaladiDenominacao = strDenominacao;
								break;
						}
						bRetorno = true;
					}
				}
			}
			return (bRetorno);
		}
		#endregion
		#region Produtos Fatura Comercial
		public bool bExisteProdutosSemVinculo()
		{
			return(arlProdutosFaturaSemVinculo(false).Count > 0);
		} 

		private System.Collections.ArrayList arlProdutosFaturaSemVinculo(bool bIncluirFilhos)
		{
			System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
			foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura in m_typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
			{
				if ((!bIncluirFilhos) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) || (dtrwProdutoFatura.nIdOrdemProdutoParent != 0)))
					continue;
				bool bProdutoSemVinculo = false;
				switch(m_enumClassificacao)
				{
					case Classificacao.Ncm:
						bProdutoSemVinculo = ((dtrwProdutoFatura.IsstrNcmNull()) || (dtrwProdutoFatura.strNcm == ""));
						break;
					case Classificacao.Naladi:
						bProdutoSemVinculo = ((dtrwProdutoFatura.IsstrNaladiNull()) || (dtrwProdutoFatura.strNaladi == ""));
						break;
				}
				if (bProdutoSemVinculo)
					arlRetorno.Add(dtrwProdutoFatura);
			}
			return(arlRetorno);
		}

		private System.Collections.ArrayList arlProdutosFatura(bool bIncluirFilhos)
		{
			System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
			foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura in m_typDatSetProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
			{
				if ((!bIncluirFilhos) && ((dtrwProdutoFatura.IsnIdOrdemProdutoParentNull()) && (dtrwProdutoFatura.nIdOrdemProdutoParent != 0)))
					continue;
				arlRetorno.Add(dtrwProdutoFatura);
			}
			return(arlRetorno);
		}

		#endregion
	}
}
