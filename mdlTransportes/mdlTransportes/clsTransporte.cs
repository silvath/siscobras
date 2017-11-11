using System;

namespace mdlTransportes
{
	/// <summary>
	/// Summary description for clsTransporte.
	/// </summary>
	public abstract class clsTransporte
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador = -1;
		protected string m_strNavio = "";

		protected string m_strGroupBoxTitulo = "Navio/Placa Caminhão/outros";

		public bool m_bModificado = false;

        private frmFTransporte m_formFTransporte = null;
		#endregion

		#region Construtores & Destrutores
		public clsTransporte(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region InitializeEventsFormTransporte
		private void InitializeEventsFormTransporte()
		{
			// Carrega Dados BD
			m_formFTransporte.eCallCarregaDadosBD += new frmFTransporte.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFTransporte.eCallCarregaDadosInterface += new frmFTransporte.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFTransporte.eCallSalvaDadosInterface += new frmFTransporte.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFTransporte.eCallSalvaDadosBD += new frmFTransporte.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFTransporte = new frmFTransporte(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormTransporte();
				m_formFTransporte.ShowDialog();
				m_formFTransporte.Dispose();
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
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNavio, ref System.Windows.Forms.GroupBox gbFields)
		{
			ctbNavio.Text = m_strNavio;
			gbFields.Text = m_strGroupBoxTitulo;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbNavio)
		{
			try
			{
				m_strNavio = ctbNavio.Text;
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
		public void retornaValores(out string Navio)
		{
			Navio = m_strNavio;
		}
		#endregion
	}
}
