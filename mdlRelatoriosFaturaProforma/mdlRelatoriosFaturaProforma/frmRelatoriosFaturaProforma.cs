using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosFaturaProforma
{
	/// <summary>
	/// Summary description for frmRelatoriosFaturaProforma.
	/// </summary>
	public class frmRelatoriosFaturaProforma : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas m_typDatSetTbFaturasProformas = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Construtor e Destrutor
		
		public frmRelatoriosFaturaProforma(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,2,nIdExportador,strIdPE)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			bResizeForm();
			m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
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
			// frmRelatoriosCotacao
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  m_gbBarraInferior,
																		  m_gbBarraSuperior});
			this.Name = "frmRelatoriosFaturaProforma";
			this.Load += new System.EventHandler(this.frmRelatoriosFaturaProforma_Load);
			m_gbBarraSuperior.ResumeLayout(false);
			m_gbBarraInferior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulário
		private void frmRelatoriosFaturaProforma_Load(object sender, System.EventArgs e)
		{
			bMostrarRelatorio();
		}
        #endregion
		#region Métodos SobreEscritos

		public override bool bCarregaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
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
				m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					if (!dtrwRowTbFaturasProformas.IsidRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbFaturasProformas.idRelatorio;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
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
				m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					dtrwRowTbFaturasProformas.idRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbFaturasProformas(m_typDatSetTbFaturasProformas);
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
			try
			{
				System.Windows.Forms.ImageList LstBandeiras = ListaBandeiras;
				string strIdioma;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlIdioma.clsIdioma formIdioma = new mdlIdioma.clsIdiomaFaturaProforma(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo,ref LstBandeiras);
				formIdioma.ShowDialog();
				if (formIdioma.m_bModificado)
				{
					formIdioma.retornaValores(out m_nIdIdioma, out strIdioma);
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

		public override bool bCarregaIdIdioma()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
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
				m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					if (!dtrwRowTbFaturasProformas.IsidIdiomaNull())
						m_nIdIdioma = dtrwRowTbFaturasProformas.idIdioma;
					else
						m_nIdIdioma = 1;
					return true;
				}
				else
				{
					m_nIdIdioma = 1;
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
		protected override void vIncrementaNumeroImpressoes()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow dtrwRowTbFaturasProformas;
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
				m_typDatSetTbFaturasProformas = m_cls_dba_ConnectionDB.GetTbFaturasProformas(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows.Count > 0)
				{
					dtrwRowTbFaturasProformas = (mdlDataBaseAccess.Tabelas.XsdTbFaturasProformas.tbFaturasProformasRow)m_typDatSetTbFaturasProformas.tbFaturasProformas.Rows[0];
					if (!dtrwRowTbFaturasProformas.IsnImpressoesNull())
						dtrwRowTbFaturasProformas.nImpressoes++;
					else
						dtrwRowTbFaturasProformas.nImpressoes = -1;
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
