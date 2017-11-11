using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosSaque
{
	/// <summary>
	/// Summary description for frmRelatoriosSaque.
	/// </summary>
	public class frmRelatoriosSaque : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbSaques m_typDatSetTbSaques = null;
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		private System.Windows.Forms.Button m_btAssistente;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor e Desctructor
		
		public frmRelatoriosSaque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,14,nIdExportador,strIdPE)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			bResizeForm();
			m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
			m_btIdioma.Visible = true;
			m_btAssistente.Image = mdlCriacaoDocumentos.Assistentes.clsAssistente.GetImageAssistente();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosSaque));
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_gbBarraSuperior.SuspendLayout();
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			// 
			// m_rcRelatorio
			// 
			this.m_rcRelatorio.Name = "m_rcRelatorio";
			// 
			// m_btEnviarImagemEmail
			// 
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Alterar idioma ");
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar ");
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.Name = "m_vsbVertical";
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			this.m_btZoomMenos.Visible = true;
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.Name = "m_btZoomMais";
			this.m_btZoomMais.Visible = true;
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.Name = "m_btImprimir";
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.Name = "m_btExcluirEdicao";
			// 
			// m_btZoomNormal
			// 
			this.m_btZoomNormal.Name = "m_btZoomNormal";
			// 
			// m_btImportar
			// 
			this.m_btImportar.Name = "m_btImportar";
			// 
			// m_btExportar
			// 
			this.m_btExportar.Name = "m_btExportar";
			// 
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(8, 11);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 60;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// frmRelatoriosSaque
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Name = "frmRelatoriosSaque";
			this.Load += new System.EventHandler(this.frmRelatoriosSaque_Load);
			this.m_gbBarraSuperior.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulário
		private void frmRelatoriosSaque_Load(object sender, System.EventArgs e)
		{
			if (bCriaRegistroSaque())
				System.Threading.Thread.Sleep(2000);
			bMostrarRelatorio();
		}
        #endregion
		#region Métodos Referentes a Criação do Registro do Saque 
		/// <summary>
		/// Cria o registro do Saque caso necessário
		/// </summary>
		/// <returns></returns>
		private bool bCriaRegistroSaque()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
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
				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSaques.tbSaques.Rows.Count == 0)
				{
					dtrwRowTbSaques = m_typDatSetTbSaques.tbSaques.NewtbSaquesRow();
					dtrwRowTbSaques.idExportador = m_nIdExportador;
					dtrwRowTbSaques.idPE = m_strIdCodigo;
					dtrwRowTbSaques.nIdRelatorio = 0;
					dtrwRowTbSaques.dtDataEmissao = System.DateTime.Now.Date;
					dtrwRowTbSaques.nIdIdioma = 3;
					base.Idioma = 3;
					dtrwRowTbSaques.nImpressoes = 0;
					m_typDatSetTbSaques.tbSaques.AddtbSaquesRow(dtrwRowTbSaques);
					m_cls_dba_ConnectionDB.SetTbSaques(m_typDatSetTbSaques);
					mdlNumero.clsNumero obj = new mdlNumero.Saque.clsSaque(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
					obj.salvaDiretoSemMostrarInterface();
					obj = null;
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
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
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
				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					if (!dtrwRowTbSaques.IsnIdRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbSaques.nIdRelatorio;
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
				mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow dtrwTbExportadores;
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo, arlCondicaoTipo, arlCondicaoValor, null, null);
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwTbExportadores = (mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwTbExportadores.idRelatorioSaque = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
				}

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					dtrwRowTbSaques.nIdRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbSaques(m_typDatSetTbSaques);
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

		protected override bool bTrocarIdioma()
		{
			try
			{
				System.Windows.Forms.ImageList LstBandeiras = ListaBandeiras;
				string strIdioma;
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlIdioma.clsIdioma formIdioma = new mdlIdioma.clsIdiomaSaque(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo,ref LstBandeiras);
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
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					if (!dtrwRowTbSaques.IsnIdIdiomaNull())
                        m_nIdIdioma = dtrwRowTbSaques.nIdIdioma;
					else
						m_nIdIdioma = 3;
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
		protected override void vIncrementaNumeroImpressoes()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow dtrwRowTbSaques;
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
				m_typDatSetTbSaques = m_cls_dba_ConnectionDB.GetTbSaques(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbSaques.tbSaques.Rows.Count > 0)
				{
					dtrwRowTbSaques = (mdlDataBaseAccess.Tabelas.XsdTbSaques.tbSaquesRow)m_typDatSetTbSaques.tbSaques.Rows[0];
					if (!dtrwRowTbSaques.IsnImpressoesNull())
						dtrwRowTbSaques.nImpressoes++;
					else
						dtrwRowTbSaques.nImpressoes = 1;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}

		#endregion

		#region Eventos
			#region Botoes
				private void m_btAssistente_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlCriacaoDocumentos.Assistentes.clsAssistente cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteSaque(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					if(cls_Assistente.ShowDialog())
						bMostrarRelatorio();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
		#endregion
	}
}
