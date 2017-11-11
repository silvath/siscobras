using System;

namespace mdlProdutosCertificadoOrigem
{
	#region Enums
		public enum Classificacao
		{
			Ncm = 1,
			Naladi = 2
		}
	#endregion
	/// <summary>
	/// Summary description for clsProdutosCertificadoOrigem.
	/// </summary>
	public abstract class clsProdutosCertificadoOrigem
	{
		#region Constants
		protected const int MERCOSUL = 1;
		protected const int MERCOSULBOLIVIA = 2;
		protected const int MERCOSULCHILE = 3;
		protected const int ALADIAPTR04 = 4;
		protected const int ALADIACE39 = 5;
		protected const int ANEXO3 = 6;
		protected const int COMUM = 7;
		protected const int FORMA = 8;
		protected const int ALADIACE59 = 29;

		protected const int NCM = 1;
		protected const int NALADI = 2;
		protected const int NCMENALADI = 3;
		#endregion
		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		protected bool m_bMostrarBaloes = true;

		protected Classificacao m_enumClassificacao = Classificacao.Ncm;
		public bool m_bModificado = false;
		protected int m_nIdExportador = -1;
		protected string m_strIdPE = "";
		protected int m_nIdTipoCO = -1;
		protected int m_nTipoClassificacao = -1;

		protected int m_nIdProduto = -1;

		protected System.DateTime m_dtEmissaoCertificado = System.DateTime.Now;

		internal Frames.frmFProdutosCertificado m_formFProdutosCertificado = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null, m_typDatSetTbProdutosTemp = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm m_typDatSetTbProdutosNcm = null, m_typDatSetTbProdutosNcmTemp = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi m_typDatSetTbProdutosNaladi = null, m_typDatSetTbProdutosNaladiTemp = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial m_typDatSetTbProdutosFaturaComercial = null;
		protected mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem m_typDatSetTbProdutosCertificadoOrigem = null;
		private System.Windows.Forms.ImageList m_ilBandeiras = null;
		#endregion
		#region Properties
			public bool HasProducts
			{
				get
				{
					if (m_typDatSetTbProdutosCertificadoOrigem == null)
						return(false);
					return(arlProdutosCertificadoOrigem().Count > 0);
				}
			}
		#endregion
		#region Construtores & Destrutores
		public clsProdutosCertificadoOrigem(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,string strIdPE, int nIdTipoCO, int nTipoClassificacao, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
			m_nIdTipoCO = nIdTipoCO;
			m_nTipoClassificacao = nTipoClassificacao;
			m_ilBandeiras = ilBandeiras;
			vCarregaDados();

			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region Carrega Dados
		#region Banco de Dados
		protected virtual void vCarregaDados()
		{
			try
			{
				// Certificado Origem
				bCarregaDadosCertificado();

				// Produtos Geral 
				bCarregaDadosProdutos();

				// Classificacao
				bCarregaDadosClassificacao();

				// Produtos da Fatura
				bCarregaDadosProdutosFatura();

				// Produtos do Certificado Origem
				bCarregaDadosProdutosCertificadoOrigem();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		private bool bCarregaDadosCertificado()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdPE);

			arlCondicaoCampo.Add("nIdTipoCO");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdTipoCO);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem typDatSetCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbCertificadosOrigem(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor,null,null);
			if (typDatSetCertificadoOrigem.tbCertificadosOrigem.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow dtrwCertificadoOrigem = (mdlDataBaseAccess.Tabelas.XsdTbCertificadosOrigem.tbCertificadosOrigemRow)typDatSetCertificadoOrigem.tbCertificadosOrigem.Rows[0];
				if (!dtrwCertificadoOrigem.IsdtDataCONull())
					m_dtEmissaoCertificado = dtrwCertificadoOrigem.dtDataCO;
			}
			return(m_cls_dba_ConnectionDB.Erro == null);
		}

		private bool bCarregaDadosProdutos()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro == null);
		}
		
		private bool bCarregaDadosProdutosFatura()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdPE);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbProdutosFaturaComercial = m_cls_dba_ConnectionDB.GetTbProdutosFaturaComercial(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
			return(m_cls_dba_ConnectionDB.Erro == null);
		}

		private bool bCarregaDadosProdutosCertificadoOrigem()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

			arlCondicaoCampo.Add("idExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			arlCondicaoCampo.Add("idPE");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_strIdPE);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbProdutosCertificadoOrigem = m_cls_dba_ConnectionDB.GetTbProdutosCertificadoOrigem(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro == null);
		}

		private bool bCarregaDadosClassificacao()
		{
			System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
			arlCondicaoCampo.Add("nIdExportador");
			arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicaoValor.Add(m_nIdExportador);

			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbProdutosNcm = m_cls_dba_ConnectionDB.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			m_typDatSetTbProdutosNaladi = m_cls_dba_ConnectionDB.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			return(m_cls_dba_ConnectionDB.Erro == null);
		}

		#endregion
		#endregion
		#region Salva Dados
		protected virtual bool bSalvaDados()
		{
			bool bRetorno = false;

			// Integridade dos Dados
			bIntegridadeDados();

			// Produtos Certificado Origem
			m_cls_dba_ConnectionDB.SetTbProdutosCertificadoOrigem(m_typDatSetTbProdutosCertificadoOrigem);
			bRetorno = (m_cls_dba_ConnectionDB.Erro == null);
			return(bRetorno);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFProdutosCertificado = new Frames.frmFProdutosCertificado(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMostrarBaloes);
				vInitializeEvents(ref m_formFProdutosCertificado);
				m_formFProdutosCertificado.ShowDialog();
				m_bModificado = m_formFProdutosCertificado.m_bModificado;
				m_formFProdutosCertificado = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
				
		internal virtual void vInitializeEvents(ref Frames.frmFProdutosCertificado formFProdutosCertificado)
		{
			// Refresh Produtos
			m_formFProdutosCertificado.eCallRefreshProdutos += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallRefreshProdutos(vRefreshProdutos);

			// Refresh Produtos Associados
			m_formFProdutosCertificado.eCallRefreshProdutosAssociados += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallRefreshProdutosAssociados(vRefreshProdutosAssociados);

			// Possui Produtos Sem Classificacao
			m_formFProdutosCertificado.eCallPossuiProdutosSemClassificacao += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallPossuiProdutosSemClassificacao(bPossuiProdutosSemClassificacao);

			// Show Dialog Produtos Vincular
			m_formFProdutosCertificado.eCallShowDialogProdutosVincular += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallShowDialogProdutosVincular(ShowDialogProdutosVincular);

			// Carrega Dados Produtos
			m_formFProdutosCertificado.eCallCarregaDadosProdutos += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallCarregaDadosProdutos(bCarregaDadosProdutos);

			// Carrega Dados Classificacao
			m_formFProdutosCertificado.eCallCarregaDadosClassificacao += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallCarregaDadosClassificacao(bCarregaDadosClassificacao);

			// Produto Insere
			m_formFProdutosCertificado.eCallInsereProdutos += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallInsereProdutos(bInsereProdutos);

			// Produto Remove
			m_formFProdutosCertificado.eCallRemoveProdutos += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallRemoveProdutos(bRemoveProdutos);
                
			// Salva Dados BD
			m_formFProdutosCertificado.eCallSalvaDadosBD += new Frames.frmFProdutosCertificado.delCallSalvaDadosBD(bSalvaDados);

			// ShowDialogPersonalizarClassificacao
			m_formFProdutosCertificado.eCallShowDialogPersonalizarClassificacao += new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallShowDialogPersonalizarClassificacao(ShowDialogPersonalizarClassificacao);

			m_formFProdutosCertificado.eCallShowDialogPersonalizarProduto +=new mdlProdutosCertificadoOrigem.Frames.frmFProdutosCertificado.delCallShowDialogPersonalizarProduto(ShowDialogPersonalizarProduto);
		}
		#endregion
		#region ShowDialogProdutosVincular
			private bool ShowDialogProdutosVincular()
			{
				bool bRetorno = false;
				mdlProdutosVinculacao.clsProdutosVincular cls_pv_Produtos = new mdlProdutosVinculacao.clsProdutosVincular(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,(mdlProdutosVinculacao.Classificacao)m_enumClassificacao);
				cls_pv_Produtos.ProdutosVinculados = !cls_pv_Produtos.bExisteProdutosSemVinculo();
				if (bRetorno = cls_pv_Produtos.ShowDialog())
				{
					bCarregaDadosProdutos();
					bCarregaDadosProdutosFatura();
				}
				return(bRetorno);
			}
		#endregion
		#region ShowDialogPersonalizar
			private bool ShowDialogPersonalizar(string strCaption,string strDefault,ref string strPersonalizavel)
			{
				Formularios.frmFPersonalizar formFPersonalizar = new mdlProdutosCertificadoOrigem.Formularios.frmFPersonalizar(m_strEnderecoExecutavel);
				formFPersonalizar.Default = strDefault;
				formFPersonalizar.Personalizada = strPersonalizavel;
				formFPersonalizar.Text = strCaption;
				formFPersonalizar.ShowDialog();
				if (formFPersonalizar.Modificado)
					strPersonalizavel = formFPersonalizar.Personalizada;
				return(formFPersonalizar.Modificado);
			}
		#endregion
		#region ShowDialogPersonalizarClassificacao
			private bool ShowDialogPersonalizarClassificacao(System.Collections.ArrayList arlProdutos)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador,m_strIdPE,m_nIdTipoCO,Int32.Parse(arlProdutos[0].ToString()));
				if (dtrwProdutoCertificado == null)
					return(false);
				string strDenominacao = strRetornaDenominacao(Int32.Parse(arlProdutos[0].ToString()));
				string strDenominacaoCertificado = "";
				if (!dtrwProdutoCertificado.IsmstrDenominacaoNull())
					strDenominacaoCertificado = dtrwProdutoCertificado.mstrDenominacao;
				if (ShowDialogPersonalizar("Personalizar Denominação",strDenominacao,ref strDenominacaoCertificado))
				{
					for(int i = 0; i < arlProdutos.Count;i++)
					{
						dtrwProdutoCertificado = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador,m_strIdPE,m_nIdTipoCO,Int32.Parse(arlProdutos[i].ToString()));
						if (strDenominacaoCertificado.Trim() == "")
							dtrwProdutoCertificado.SetmstrDenominacaoNull();
						else
							dtrwProdutoCertificado.mstrDenominacao = strDenominacaoCertificado;
					}
					return(true);
				}
				return(false);
			}
		#endregion
		#region ShowDialogPersonalizarProduto
			private bool ShowDialogPersonalizarProduto(int nIdProdutoCertificadoOrigem)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado = m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.FindByidExportadoridPEidTipoCOidOrdemProduto(m_nIdExportador,m_strIdPE,m_nIdTipoCO,nIdProdutoCertificadoOrigem);
				if (dtrwProdutoCertificado == null)
					return(false);
				string strDescricaoProdutoFatura = strRetornaDescricaoProduto(nIdProdutoCertificadoOrigem);
				string strDescricaoProdutoCertificado = "";
				if (!dtrwProdutoCertificado.IsmstrDescricaoNull())
					strDescricaoProdutoCertificado = dtrwProdutoCertificado.mstrDescricao;
				if (ShowDialogPersonalizar("Personalizar Descrição",strDescricaoProdutoFatura,ref strDescricaoProdutoCertificado))
				{
					if (strDescricaoProdutoCertificado.Trim() == "")
						dtrwProdutoCertificado.SetmstrDescricaoNull();
					else
						dtrwProdutoCertificado.mstrDescricao = strDescricaoProdutoCertificado;
					return(true);
				}
				return(false);
			}
		#endregion

		#region Refresh
		private void vRefreshProdutos(ref mdlComponentesGraficos.TreeView tvProdutos)
		{
			tvProdutos.Nodes.Clear();
			System.Collections.ArrayList arlProdutosNaoAssociados = arlProdutosFaturaNaoAssociadosCertificados();

			// Classificacao Ordenando 
			string strClassificacao = "";
			string strDenominacao = "";
			System.Collections.SortedList sortLstClassificacao = new System.Collections.SortedList();
			for(int i = 0; i < arlProdutosNaoAssociados.Count; i++)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)arlProdutosNaoAssociados[i];
				mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
				if ((dtrwProdutoFatura != null) && (dtrwProdutoFatura.IsnIdOrdemProdutoParentNull() || dtrwProdutoFatura.nIdOrdemProdutoParent == 0) && (dtrwProduto != null)) 
				{
					switch(m_enumClassificacao)
					{
						case Classificacao.Ncm:
							if (!dtrwProdutoFatura.IsstrNcmNull())
								strClassificacao = dtrwProdutoFatura.strNcm;
							else if (!dtrwProduto.IsstrNcmNull())
								strClassificacao = dtrwProduto.strNcm;
							else
								strClassificacao = "";
							if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
							{
								strDenominacao = dtrwProdutoFatura.mstrNcmDenominacao;
							}else{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,strClassificacao);
								if (dtrwNcm != null)
									strDenominacao = dtrwNcm.mstrDenominacao;
								else
									strDenominacao = "";
							}
							if (strClassificacao != "")
								if (!sortLstClassificacao.ContainsKey(strClassificacao + strDenominacao))
									sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
							break;
						case Classificacao.Naladi:
							if (!dtrwProdutoFatura.IsstrNaladiNull())
								strClassificacao = dtrwProdutoFatura.strNaladi;
							else if (!dtrwProduto.IsstrNaladiNull())
								strClassificacao = dtrwProduto.strNaladi;
							else
								strClassificacao = "";
							if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
							{
								strDenominacao = dtrwProdutoFatura.mstrNaladiDenominacao;
							}
							else
							{
								mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,strClassificacao);
								if (dtrwNaladi != null)
									strDenominacao = dtrwNaladi.mstrDenominacao;
								else
									strDenominacao = "";
							}
							if (strClassificacao != "")
								if (!sortLstClassificacao.ContainsKey(strClassificacao + strDenominacao))
									sortLstClassificacao.Add(strClassificacao + strDenominacao,strClassificacao);
							break;
					}
				}
			}

			// Classificacao Inserindo
			string strClassificacaoProduto,strDenominacaoProduto;
			for (int i = 0; i < sortLstClassificacao.Count; i++)
			{
				string strClassificacaoDenominacao = sortLstClassificacao.GetKey(i).ToString();
				strClassificacao = sortLstClassificacao.GetByIndex(i).ToString();
				strDenominacao = strClassificacaoDenominacao.Substring(strClassificacao.Length);

				System.Windows.Forms.TreeNode tvnClassificacao = tvProdutos.Nodes.Add(strClassificacao + " " + strDenominacao);
				System.Windows.Forms.TreeNode tvnProduto = null;
				tvnClassificacao.Tag = strClassificacao;

				// Produtos Inserindo 
				for(int j = 0; j < arlProdutosNaoAssociados.Count; j++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = (mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow)arlProdutosNaoAssociados[j];
					mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
					if (dtrwProduto != null)
					{
						switch(m_enumClassificacao)
						{
							case Classificacao.Ncm:
								if (!dtrwProdutoFatura.IsstrNcmNull())
									strClassificacaoProduto = dtrwProdutoFatura.strNcm;
								else if (!dtrwProduto.IsstrNcmNull())
									strClassificacaoProduto = dtrwProduto.strNcm;
								else
									strClassificacaoProduto = "";
								if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
								{
									strDenominacaoProduto = dtrwProdutoFatura.mstrNcmDenominacao;
								}
								else
								{
									mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwNcm = m_typDatSetTbProdutosNcm.tbProdutosNcm.FindBynIdExportadorstrNcm(m_nIdExportador,strClassificacaoProduto);
									if (dtrwNcm != null)
										strDenominacaoProduto = dtrwNcm.mstrDenominacao;
									else
										strDenominacaoProduto = "";
								}
								if (strClassificacaoDenominacao == strClassificacaoProduto + strDenominacaoProduto)
								{
									tvnProduto = tvnClassificacao.Nodes.Add(dtrwProduto.mstrDescricao);
									tvnProduto.Tag = dtrwProdutoFatura.idOrdem;
								}
								break;
							case Classificacao.Naladi:
								if (!dtrwProdutoFatura.IsstrNaladiNull())
									strClassificacaoProduto = dtrwProdutoFatura.strNaladi;
								else if (!dtrwProduto.IsstrNaladiNull())
									strClassificacaoProduto = dtrwProduto.strNaladi;
								else
									strClassificacaoProduto = "";
								if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
								{
									strDenominacaoProduto = dtrwProdutoFatura.mstrNaladiDenominacao;
								}
								else
								{
									mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwNaladi = m_typDatSetTbProdutosNaladi.tbProdutosNaladi.FindBynIdExportadorstrNaladi(m_nIdExportador,strClassificacao);
									if (dtrwNaladi != null)
										strDenominacaoProduto = dtrwNaladi.mstrDenominacao;
									else
										strDenominacaoProduto = "";
								}
								if (strClassificacaoDenominacao == strClassificacaoProduto + strDenominacaoProduto)
								{
									tvnProduto = tvnClassificacao.Nodes.Add(dtrwProduto.mstrDescricao);
									tvnProduto.Tag = dtrwProdutoFatura.idOrdem;
								}
								break;
						}
					}
				}
			}
		}

			protected abstract void vRefreshProdutosAssociados(ref mdlComponentesGraficos.TreeView tvProdutosAssociados);

		#endregion

		#region Produtos
			protected abstract bool bInsereProdutos(ref System.Collections.ArrayList arlProdutos,int nIdNorma);
			protected abstract bool bRemoveProdutos(ref System.Collections.ArrayList arlProdutos);

			protected string strRetornaDescricaoProduto(int nIdOrdemProdutoFaturaComercial)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProdutoFaturaComercial);
				if (dtrwProdutoFatura != null)
				{
					if (!dtrwProdutoFatura.IsmstrDescricaoNull())
					{
						strRetorno = dtrwProdutoFatura.mstrDescricao;
					}
					else
					{
						mdlDataBaseAccess.Tabelas.XsdTbProdutos.tbProdutosRow dtrwProduto = m_typDatSetTbProdutos.tbProdutos.FindByidExportadoridProduto(m_nIdExportador,dtrwProdutoFatura.idProduto);
						if ((dtrwProduto != null) && (!dtrwProduto.IsmstrDescricaoNull()))
							strRetorno = dtrwProduto.mstrDescricao;
					}
				}
				return(strRetorno);
			}
		#endregion
		#region Produtos Fatura Comercial
			protected string strRetornaUnidadeProduto(int nIdOrdemProdutoFaturaComercial)
			{
				string strRetorno = "";
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProdutoFaturaComercial);
				if (dtrwProdutoFatura != null)
					if (dtrwProdutoFatura.RowState != System.Data.DataRowState.Deleted)
						if (!dtrwProdutoFatura.IsstrUnidadeNull())
							strRetorno = dtrwProdutoFatura.strUnidade;
				return(strRetorno);
			}
		#endregion
		#region Produtos Certificado Origem
			private System.Collections.ArrayList arlProdutosFaturaNaoAssociadosCertificados()
			{
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura in m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.Rows)
				{
					if ((dtrwProdutoFatura.RowState != System.Data.DataRowState.Deleted) && (dtrwProdutoFatura.IsnIdOrdemProdutoParentNull() || dtrwProdutoFatura.nIdOrdemProdutoParent == 0))
					{
						bool bInserido = false;
						foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
						{
							if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
							{
								if (dtrwProdutoFatura.idOrdem == dtrwProdutoCertificado.idOrdemProduto)
								{
									bInserido = true;
									continue;
								} 
							}
						}
						if (!bInserido)
							arlRetorno.Add(dtrwProdutoFatura);
					}
				}
				return(arlRetorno);
			}

			protected System.Collections.ArrayList arlProdutosCertificadoOrigem()
			{
				System.Collections.ArrayList arlRetorno = new System.Collections.ArrayList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
					if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
						if (dtrwProdutoCertificado.idTipoCO == m_nIdTipoCO)
							arlRetorno.Add(dtrwProdutoCertificado);
				return(arlRetorno);
			}

			protected int nNextOrdemProdutoCertificado()
			{
				int nRetorno = 1;
				bool bExist = true;
				while (bExist)
				{
					bExist = false;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigemRow dtrwProdutoCertificado in m_typDatSetTbProdutosCertificadoOrigem.tbProdutosCertificadoOrigem.Rows)
					{
						if (dtrwProdutoCertificado.RowState != System.Data.DataRowState.Deleted)
						{
							if ((dtrwProdutoCertificado.idExportador == m_nIdExportador) && (dtrwProdutoCertificado.idPE == m_strIdPE) && (dtrwProdutoCertificado.idTipoCO == m_nIdTipoCO) && (dtrwProdutoCertificado.idOrdem == nRetorno))
							{
								bExist = true;
								nRetorno++;
								continue;
							}
						}
					}
				}
				return(nRetorno);
			}
		#endregion
		#region Classificacao
			private bool bPossuiProdutosSemClassificacao()
			{
				mdlProdutosVinculacao.clsProdutosVincular cls_vinc_Produtos = new mdlProdutosVinculacao.clsProdutosVincular(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE,(mdlProdutosVinculacao.Classificacao)m_enumClassificacao);
				return(cls_vinc_Produtos.bExisteProdutosSemVinculo());
			}

			protected string strRetornaClassificacao(int nIdOrdemProdutoFaturaComercial)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProdutoFaturaComercial);
				if (dtrwProdutoFatura == null)
					return("");
				if (dtrwProdutoFatura != null)
				{
					switch(m_enumClassificacao)
					{
						case Classificacao.Ncm:
							if (!dtrwProdutoFatura.IsstrNcmNull())
								return(dtrwProdutoFatura.strNcm);
							break;
						case Classificacao.Naladi:
							if (!dtrwProdutoFatura.IsstrNaladiNull())
								return(dtrwProdutoFatura.strNaladi);
							break;
					}
				}
				return("");
			}

			protected string strRetornaDenominacao(int nIdOrdemProdutoFaturaComercial)
			{
				mdlDataBaseAccess.Tabelas.XsdTbProdutosFaturaComercial.tbProdutosFaturaComercialRow dtrwProdutoFatura = m_typDatSetTbProdutosFaturaComercial.tbProdutosFaturaComercial.FindByidExportadoridPEidOrdem(m_nIdExportador,m_strIdPE,nIdOrdemProdutoFaturaComercial);
				if (dtrwProdutoFatura == null)
					return("");
				if (dtrwProdutoFatura != null)
				{
					switch(m_enumClassificacao)
					{
						case Classificacao.Ncm:
							if (!dtrwProdutoFatura.IsmstrNcmDenominacaoNull())
								return(dtrwProdutoFatura.mstrNcmDenominacao);
							break;
						case Classificacao.Naladi:
							if (!dtrwProdutoFatura.IsmstrNaladiDenominacaoNull())
								return(dtrwProdutoFatura.mstrNaladiDenominacao);
							break;
					}
				}
				return("");
			}
		#endregion

		#region Integridade
			protected abstract bool bIntegridadeDados();
		#endregion
	}
}
