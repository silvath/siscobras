using System;

namespace mdlInstrucoesPagamento
{
	/// <summary>
	/// Summary description for clsInstrucoesPagamento.
	/// </summary>
	public abstract class clsInstrucoesPagamento
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador = -1;
		protected string m_strInstrucoesPagamento = "";

		protected string m_strGroupBoxTitulo = "";

		public bool m_bModificado = false;

		private frmFInstrucoesPagamento m_formFInstrucoesPagamento = null;
		#endregion

		#region Construtores & Destrutores
		public clsInstrucoesPagamento(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region InitializeEventsFormInstrucoesPagamento
		private void InitializeEventsFormInstrucoesPagamento()
		{
			// Carrega Dados BD
			m_formFInstrucoesPagamento.eCallCarregaDadosBD += new frmFInstrucoesPagamento.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFInstrucoesPagamento.eCallCarregaDadosInterface += new frmFInstrucoesPagamento.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFInstrucoesPagamento.eCallSalvaDadosInterface += new frmFInstrucoesPagamento.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFInstrucoesPagamento.eCallSalvaDadosBD += new frmFInstrucoesPagamento.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFInstrucoesPagamento = new frmFInstrucoesPagamento(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormInstrucoesPagamento();
				m_formFInstrucoesPagamento.ShowDialog();
				m_formFInstrucoesPagamento.Dispose();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		protected void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected abstract void carregaDadosBDEspecifico();
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref System.Windows.Forms.TextBox tbInstrucoesPagamento, ref System.Windows.Forms.GroupBox gbFields)
		{
			tbInstrucoesPagamento.Text = m_strInstrucoesPagamento;
			gbFields.Text = m_strGroupBoxTitulo;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterface(ref System.Windows.Forms.TextBox tbInstrucoesPagamento)
		{
			try
			{
				m_strInstrucoesPagamento = tbInstrucoesPagamento.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
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
		public void retornaValores(out string strInstrucoesPagamento)
		{
			strInstrucoesPagamento = m_strInstrucoesPagamento;
		}
		#endregion
	}
}
