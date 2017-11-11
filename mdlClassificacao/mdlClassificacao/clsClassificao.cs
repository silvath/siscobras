using System;

namespace mdlClassificacao
{
	/// <summary>
	/// Summary description for clsClassificao.
	/// </summary>
	public abstract class clsClassificao
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bNaoGravarTabelas = false;
		protected int m_nIdExportador = -1;
		protected int m_nIdProduto = -1;
		protected string m_strNrmClassificacao = "";
		protected string m_strDenominacao = "";

		private Frames.frmFClassificacao m_formFClassificacao = null;

		protected mdlProdutosGeral.clsProdutos m_clsProdutosGeral = null;

		protected mdlDataBaseAccess.Tabelas.XsdTbProdutos m_typDatSetTbProdutos = null;

		protected System.Windows.Forms.ImageList m_ilBandeiras = null;
		#endregion

		#region Construtores & Destrutores
		public clsClassificao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_nIdProduto = Produto;
				m_ilBandeiras = ilBandeiras;
				carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public clsClassificao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel, int Exportador, int Produto, ref mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos, bool bNaoGravarTabelas, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			try 
			{
				m_cls_ter_tratadorErro = tratadorErro; 
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel; 
				m_nIdExportador = Exportador;
				m_nIdProduto = Produto;
				m_ilBandeiras = ilBandeiras;
				m_typDatSetTbProdutos = (mdlDataBaseAccess.Tabelas.XsdTbProdutos)typDatSetTbProdutos.Copy();
				m_bNaoGravarTabelas = bNaoGravarTabelas;
				carregaTypDatSet();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region InitializeEventsFormClassificacao
		private void InitializeEventsFormClassificacao()
		{
			// Carrega Dados BD
			//m_formFClassificacao.eCallCarregaDadosBD += new Frames.frmFClassificacao.delCallCarregaDadosBD(carre

			// Carrega Dados BD Classificacao
			m_formFClassificacao.eCallCarregaDadosBDClassificacao += new Frames.frmFClassificacao.delCallCarregaDadosBDClassificacao(carregaDadosBDClassificacao);

			// Carrega Dados Interface
			m_formFClassificacao.eCallCarregaDadosInterface += new Frames.frmFClassificacao.delCallCarregaDadosInterface(carregaDadosInterface);

			// Carrega Dados Interface Classificacao
			m_formFClassificacao.eCallCarregaDadosClassificacaoInterface += new Frames.frmFClassificacao.delCallCarregaDadosClassificacaoInterface(carregaDadosClassificacaoInterface);

			// Salva Dados BD
			m_formFClassificacao.eCallSalvaDadosBD += new Frames.frmFClassificacao.delCallSalvaDadosBD(salvaDadosBD);

			// Cadastra Classificacao
			m_formFClassificacao.eCallCadastraClassificacao += new Frames.frmFClassificacao.delCallCadastraClassificacao(cadastraClassificacao);

			// Edita Classificacao
			m_formFClassificacao.eCallEditaClassificacao += new Frames.frmFClassificacao.delCallEditaClassificacao(editaClassificacao);

			// Exclui Classificacao
			m_formFClassificacao.eCallRemoveClassificacao += new Frames.frmFClassificacao.delCallRemoveClassificacao(removeClassificacao);
		}
		#endregion

		#region Show Dialog
		public void ShowDialog()
		{
			try
			{
				m_formFClassificacao = new Frames.frmFClassificacao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormClassificacao();
				m_formFClassificacao.ShowDialog();
				m_formFClassificacao = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Cadastra Classificacao
		protected abstract void cadastraClassificacao();
		#endregion
		#region Edita Classificacao
		protected abstract void editaClassificacao();
		#endregion
		#region Remove Classificacao
		protected void removeClassificacao(ref mdlComponentesGraficos.ListView lvClassificacao)
		{
			try
			{
				removeClassificacaoEspecifico(ref lvClassificacao);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void removeClassificacaoEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao);
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				if (m_typDatSetTbProdutos == null)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				
					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idProduto");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdProduto);
				
					m_typDatSetTbProdutos = m_cls_dba_ConnectionDB.GetTbProdutos(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecificos();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecificos();
		protected void carregaDadosBDClassificacao(ref mdlComponentesGraficos.ListView lvClassificacao)
		{
			carregaDadosBDClassificacaoEspecifico(ref lvClassificacao);
		}
		protected abstract void carregaDadosBDClassificacaoEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao);
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvClassificacao, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Form formClassificacao)
		{
			try 
			{
				carregaDadosInterfaceEspecifico(ref lvClassificacao, ref formClassificacao);
				if (lvClassificacao.Items.Count == 0)
				{
					btEditar.Enabled = false;
					btExcluir.Enabled = false;
				} 
				else
				{
					btEditar.Enabled = true;
					btExcluir.Enabled = true;
				}
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosInterfaceEspecifico(ref mdlComponentesGraficos.ListView lvClassificacao, ref System.Windows.Forms.Form formClassificacao);
		protected void carregaDadosClassificacaoInterface(ref System.Windows.Forms.RichTextBox rtbDadosClassificacao)
		{
			try
			{
				carregaDadosClassificacaoInterfaceEspecifico(ref rtbDadosClassificacao);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}				
		}
		protected abstract void carregaDadosClassificacaoInterfaceEspecifico(ref System.Windows.Forms.RichTextBox rtbDadosClassificacao);
		#endregion
		#endregion
		#region Salvamento de Dados
		#region Interface
		protected abstract void salvaDadosInterfaceCadastroClassificacao();
		protected abstract void salvaDadosInterfaceEdicaoClassificacao(string strClassificacao, string strDenominacao);
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void salvaDadosBDEspecifico();
		#endregion
		#endregion

		#region Retorna Valores
		public abstract void retornaValores(out string strClassificacao);
		protected void retornaTypDatSetTbProdutos(out mdlDataBaseAccess.Tabelas.XsdTbProdutos typDatSetTbProdutos)
		{
			typDatSetTbProdutos = m_typDatSetTbProdutos;
		}
		#endregion
	}
}
