using System;

namespace mdlRelatoriosIndefinido
{
	/// <summary>
	/// Summary description for frmFRelatoriosIndefinido.
	/// </summary>
	public class frmFRelatoriosIndefinido : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributes
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public frmFRelatoriosIndefinido(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,23,nIdExportador,strIdPE)
			{
				InitializeComponent();
				bResizeForm();
				m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
			}

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
			this.Name = "frmFRelatoriosIndefinido";
			this.Load += new System.EventHandler(this.frmFRelatoriosIndefinido_Load);
			m_gbBarraSuperior.ResumeLayout(false);
			m_gbBarraInferior.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos do Formulário
		private void frmFRelatoriosIndefinido_Load(object sender, System.EventArgs e)
		{
			bMostrarRelatorio();
		}
        #endregion

		#region Métodos SobreEscritos

		public override bool bCarregaIdRelatorio()
		{
			try
			{
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
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetTbPe = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetTbPe.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetTbPe.tbPEs.Rows[0];
					if (!dtrwPe.IsnIdRelatorioIndefinidoNull())
                        m_nIdRelatorio = dtrwPe.nIdRelatorioIndefinido;
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
			return false;
		}

		protected override bool bSalvaIdRelatorio()
		{
			try
			{
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
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetTbPe = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (typDatSetTbPe.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetTbPe.tbPEs.Rows[0];
					dtrwPe.nIdRelatorioIndefinido = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbPes(typDatSetTbPe);
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}

		protected override bool bTrocarIdioma()
		{
			try
			{
				System.Windows.Forms.ImageList LstBandeiras = ListaBandeiras;
				string strIdioma;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlIdioma.clsIdioma formIdioma = new mdlIdioma.clsIdiomaGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_nIdIdioma,ref LstBandeiras,"Idioma");
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
			m_nIdIdioma = 1;
			return(true);
		}
		#endregion
	}
}
