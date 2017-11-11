using System;

namespace mdlJanelaEntrada
{
	/// <summary>
	/// Summary description for clsJanelaEntrada.
	/// </summary>
	public class clsJanelaEntrada
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		private bool m_bMostrarJanela = true;

		private Frames.frmFJanelaDicas m_formFJanelaDicas = null;
		#endregion

		#region Construtores & Destrutores
		public clsJanelaEntrada(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarJanela = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_DICAINICIAL_SESSAO, mdlConstantes.clsConstantes.SHOW_DICAINICIAL_VARIAVEL, true);
		}
		#endregion

		#region InitializeEventsFormJanelaEntrada
		private void InitializeEventsFormJanelaEntrada()
		{
			// Salva Dados Interface
			m_formFJanelaDicas.eCallSalvaDadosInterface += new Frames.frmFJanelaDicas.delCallSalvaDadosInterface(salvaDadosInterface);
		}
		#endregion

		#region Show
		public void Show()
		{
			try
			{
				if (m_bMostrarJanela)
				{
					m_formFJanelaDicas = new Frames.frmFJanelaDicas(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					InitializeEventsFormJanelaEntrada();
					m_formFJanelaDicas.Show();
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Salvamento dos Dados
		private void salvaDadosInterface(ref System.Windows.Forms.CheckBox ckbxNaoMostrar)
		{
			try
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				obj.colocaValor(mdlConstantes.clsConstantes.SHOW_DICAINICIAL_SESSAO, mdlConstantes.clsConstantes.SHOW_DICAINICIAL_VARIAVEL, (!(ckbxNaoMostrar.Checked)).ToString());
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
	}
}
