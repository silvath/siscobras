using System;

namespace mdlNumeroOrdemCompra
{
	/// <summary>
	/// Summary description for clsNumeroOrdemCompra.
	/// </summary>
	public abstract class clsNumeroOrdemCompra
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador = -1;
		protected string m_strNumeroOrdemCompra = "";

		public bool m_bModificado = false;

		private frmFNumeroOrdemCompra m_formFNumeroOrdemCompra = null;
		#endregion

		#region Construtores & Destrutores
		public clsNumeroOrdemCompra(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region InitializeEventsFormNumeroOrdemCompra
		private void InitializeEventsFormNumeroOrdemCompra()
		{
			// Carrega Dados BD
			m_formFNumeroOrdemCompra.eCallCarregaDadosBD += new frmFNumeroOrdemCompra.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFNumeroOrdemCompra.eCallCarregaDadosInterface += new frmFNumeroOrdemCompra.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFNumeroOrdemCompra.eCallSalvaDadosInterface += new frmFNumeroOrdemCompra.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFNumeroOrdemCompra.eCallSalvaDadosBD += new frmFNumeroOrdemCompra.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFNumeroOrdemCompra = new frmFNumeroOrdemCompra(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormNumeroOrdemCompra();
				m_formFNumeroOrdemCompra.ShowDialog();
				m_formFNumeroOrdemCompra.Dispose();
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
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNumeroOrdemCompra)
		{
			ctbNumeroOrdemCompra.Text = m_strNumeroOrdemCompra;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNumeroOrdemCompra)
		{
			try
			{
				m_strNumeroOrdemCompra = ctbNumeroOrdemCompra.Text;
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
		public void retornaValores(out string NumeroOrdemCompra)
		{
			NumeroOrdemCompra = m_strNumeroOrdemCompra;
		}
		#endregion
	}
}
