using System;

namespace mdlObservacoes
{
	/// <summary>
	/// Summary description for clsObservacoes.
	/// </summary>
	public abstract class clsObservacoes
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		protected int m_nIdExportador = -1;
		protected string m_strCaption = "";
		protected string m_strDefault = null;
		protected string m_strObservacoes = "";

		protected bool m_bMostrarLabel = true;
		private bool m_bEnableShowDialog = true;
		private string m_strMessageEnableShowDialog = "";

		protected bool m_bMultiline = true;
		protected string m_strTextForm = "Informações Complementares";

		public bool m_bModificado = false;
		protected bool m_bFormPadrao = false;

		private frmFObservacoes m_formFObservacoes = null;
		#endregion
		#region Properties
			public string OBSERVACOES
			{
				set
				{
					m_strObservacoes = value;
				}
				get
				{
					return m_strObservacoes;
				}
			}

			protected string Default
			{
				set
				{
					m_strDefault = value;
				}
				get
				{
					if (m_strDefault == null)
						vCarregaDadosDefault();
					return(m_strDefault);
				}
			}

			public bool Multiline
			{
				set
				{
					m_bMultiline = value;
				}
				get
				{
					return(m_bMultiline);
				}
			}
			
			protected string TextForm
			{
				set
				{
					m_strTextForm = value;
				}
				get
				{
					return(m_strTextForm);
				}
			}

			protected bool EnableShowDialog
			{
				set
				{
					m_bEnableShowDialog = value;
				}
				get
				{
					return(m_bEnableShowDialog);
				}
			}

			protected string MessageEnableShowDialog
			{
				set
				{
					m_strMessageEnableShowDialog = value;
				}
				get
				{
					return(m_strMessageEnableShowDialog);
				}
			}
		#endregion
		#region Construtors and Destrutors
			public clsObservacoes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionBD = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_nIdExportador = nIdExportador;
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{ 
				try
				{
					if (this.EnableShowDialog)
					{
						if (!m_bFormPadrao)
						{
							m_formFObservacoes = new frmFObservacoes(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bMostrarLabel);
							InitializeEventsFormObservacoes();
							m_formFObservacoes.Text = this.TextForm;
							m_formFObservacoes.Multiline = this.Multiline;
							m_formFObservacoes.ShowDialog();
							m_formFObservacoes.Dispose();
						}
						else
						{
							ShowDialogPadrao();
						}
					}else{
						mdlMensagens.clsMensagens.ShowInformation(this.MessageEnableShowDialog);
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}

			private void InitializeEventsFormObservacoes()
			{
				// Carrega Dados BD
				m_formFObservacoes.eCallCarregaDadosBD += new frmFObservacoes.delCallCarregaDadosBD(carregaDadosBD);

				// Carrega Dados Interface
				m_formFObservacoes.eCallCarregaDadosInterface += new frmFObservacoes.delCallCarregaDadosInterface(carregaDadosInterface);

				// Salva Dados Interface
				m_formFObservacoes.eCallSalvaDadosInterface += new frmFObservacoes.delCallSalvaDadosInterface(salvaDadosInterface);

				// Salva Dados BD
				m_formFObservacoes.eCallSalvaDadosBD += new frmFObservacoes.delCallSalvaDadosBD(salvaDadosBD);
			}
		#endregion
		#region ShowDialogPadrao
			private void ShowDialogPadrao()
			{
				frmFObservacoesPadrao formFObservacoesPadrao = new frmFObservacoesPadrao(m_strEnderecoExecutavel);
				formFObservacoesPadrao.Text = this.m_strCaption;
				formFObservacoesPadrao.Personalizada = m_strObservacoes;
				formFObservacoesPadrao.Default = this.Default;
				formFObservacoesPadrao.ShowDialog();
				if (m_bModificado = formFObservacoesPadrao.Modificado)
				{
					m_strObservacoes = formFObservacoesPadrao.Personalizada;
					salvaDadosBD(m_bModificado);
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

			protected virtual void vCarregaDadosDefault()
			{
				m_strDefault = "";
			}
		#endregion
		#region Interface

		protected void carregaDadosInterface(ref System.Windows.Forms.TextBox tbObservacoes, ref System.Windows.Forms.GroupBox gbFields)
		{
			tbObservacoes.Text = m_strObservacoes;
			gbFields.Text = m_strCaption;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterface(ref System.Windows.Forms.TextBox tbObservacoes)
		{
			try
			{
				m_strObservacoes = tbObservacoes.Text;
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

		#region SalvaDiretoSemInterface
		public void SalvaDiretoSemInterface()
		{
			try
			{
				salvaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Retorna Valores
		public void retornaValores(out string Observacoes)
		{
			Observacoes = m_strObservacoes;
		}
		#endregion
	}
}
