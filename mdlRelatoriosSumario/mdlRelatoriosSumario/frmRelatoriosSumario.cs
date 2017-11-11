using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosSumario
{
	/// <summary>
	/// Summary description for frmRelatoriosSumario.
	/// </summary>
	public class frmRelatoriosSumario : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbSumarios m_typDatSetTbSumarios = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor e Desctructor
		
		public frmRelatoriosSumario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,21,nIdExportador,strIdPE)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			bResizeForm();
			m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_gbBarraSuperior.SuspendLayout();
			this.m_gbBarraInferior.SuspendLayout();
			this.SuspendLayout();
			// 
			// mgbBarraCima
			// 
			m_gbBarraSuperior.Visible = true;
			// 
			// relatorioBarraFerramentasInferior
			// 
			m_gbBarraInferior.Visible = true;
			// 
			// m_btEnviarImagemEmail
			// 
			this.m_btEnviarImagemEmail.Visible = true;
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.Visible = true;
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.Visible = true;
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.Visible = true;
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.Visible = true;
			// 
			// m_btImprimirRelatorioImprimir
			// 
			this.m_btImprimir.Visible = true;
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.Visible = true;
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.Visible = true;
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.Visible = true;
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.Visible = true;
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.Visible = true;
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.Visible = true;
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.Visible = true;
			// 
			// frmRelatoriosSumario
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  m_gbBarraInferior,
																		  m_gbBarraSuperior});
			this.Name = "frmRelatoriosSumario";
			this.Load += new System.EventHandler(this.frmRelatoriosSumario_Load);
			m_gbBarraSuperior.ResumeLayout(false);
			m_gbBarraInferior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulário
		private void frmRelatoriosSumario_Load(object sender, System.EventArgs e)
		{
			bCriaRegistroSumario();
			bMostrarRelatorio();
		}
        #endregion
		#region Métodos Referentes a Criação do Registro do Sumário 
		/// <summary>
		/// Cria o registro do Sumário caso necessário
		/// </summary>
		/// <returns></returns>
		private bool bCriaRegistroSumario()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count == 0)
				{
					dtrwRowTbSumarios = m_typDatSetTbSumarios.tbSumarios.NewtbSumariosRow();
					dtrwRowTbSumarios.idExportador = m_nIdExportador;
					dtrwRowTbSumarios.idPE = m_strIdCodigo;
					dtrwRowTbSumarios.idRelatorio = m_nIdRelatorio;
					dtrwRowTbSumarios.dtEmissao = System.DateTime.Now;
					dtrwRowTbSumarios.nImpressoes = 0;
					m_typDatSetTbSumarios.tbSumarios.AddtbSumariosRow(dtrwRowTbSumarios);
					m_cls_dba_ConnectionDB.SetTbSumarios(m_typDatSetTbSumarios);
					if (this.MostrarAssistente)
					{
						mdlNotaFiscal.clsNotaFiscal obj = new mdlNotaFiscal.clsNotaFiscal(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
						obj.ShowDialog();
					}
					return true;
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
		#region Métodos SobreEscritos

		public override bool bCarregaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0)
				{
					dtrwRowTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[0];
					if (!dtrwRowTbSumarios.IsidRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbSumarios.idRelatorio;
					else
						m_nIdRelatorio = -1;
					return bRelatorioExiste();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;//soh para compilar......nao existe!
		}

		protected override bool bSalvaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0)
				{
					dtrwRowTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[0];
					dtrwRowTbSumarios.idRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbSumarios(m_typDatSetTbSumarios);
					return true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;//soh para compilar......nao existe!
		}

		protected override bool bTrocarIdioma()
		{
 			return false;
		}

		public override bool bCarregaIdIdioma()
		{
			m_nIdIdioma = 1;
			return true;
		}
		protected override void vIncrementaNumeroImpressoes()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow dtrwRowTbSumarios;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbSumarios = m_cls_dba_ConnectionDB.GetTbSumarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSumarios.tbSumarios.Rows.Count > 0)
				{
					dtrwRowTbSumarios = (mdlDataBaseAccess.Tabelas.XsdTbSumarios.tbSumariosRow)m_typDatSetTbSumarios.tbSumarios.Rows[0];
					if (!dtrwRowTbSumarios.IsnImpressoesNull())
						dtrwRowTbSumarios.nImpressoes++;
					else
						dtrwRowTbSumarios.nImpressoes = 1;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion
	}
}
