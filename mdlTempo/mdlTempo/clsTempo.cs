using System;

namespace mdlTempo
{
	/// <summary>
	/// Summary description for clsTempo.
	/// </summary>
	public abstract class clsTempo
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador = -1;
		protected int m_nTempo = -1;

		protected bool m_bVazio = false;

		protected string m_strGroupBoxTitulo = "";

		public bool m_bModificado = false;

		private frmFTempo m_formFTempo = null;
		#endregion

		#region Construtores & Destrutores
		public clsTempo(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdExportador = nIdExportador;
		}
		#endregion

		#region InitializeEventsFormTempo
		private void InitializeEventsFormTempo()
		{
			// Carrega Dados BD
			m_formFTempo.eCallCarregaDadosBD += new frmFTempo.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFTempo.eCallCarregaDadosInterface += new frmFTempo.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFTempo.eCallSalvaDadosInterface += new frmFTempo.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFTempo.eCallSalvaDadosBD += new frmFTempo.delCallSalvaDadosBD(salvaDadosBD);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFTempo = new frmFTempo(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormTempo();
				m_formFTempo.ShowDialog();
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
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbTempo, ref System.Windows.Forms.GroupBox gbFields)
		{
			if (!m_bVazio)
				tbTempo.Text = m_nTempo.ToString();
			else
				tbTempo.Text = "";
			gbFields.Text = m_strGroupBoxTitulo;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected bool salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbTempo)
		{
			try
			{
				if (tbTempo.Text.IndexOf(",") != -1 || tbTempo.Text.IndexOf(".") != -1)
				{
					mdlMensagens.clsMensagens.ShowInformation(m_formFTempo.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlTempo_clsTempo_TempoInvalido));
					//System.Windows.Forms.MessageBox.Show("Digite um número inteiro.",m_formFTempo.Text);
					return false;
				}
				else if (tbTempo.Text.Trim() == "")
				{
					m_nTempo = -1;
					return true;
				}
				else
				{
					m_nTempo = Int32.Parse(tbTempo.Text);
					if (m_nTempo >= 0)
						return true;
					mdlMensagens.clsMensagens.ShowInformation(m_formFTempo.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlTempo_clsTempo_TempoInvalidoMenorQueZero).Replace("\\n","\n"));
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
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
		public void retornaValores(out int nTempo)
		{
			if (m_bVazio)
				nTempo = -1;
			else
				nTempo = m_nTempo;
		}
		#endregion
	}
}
