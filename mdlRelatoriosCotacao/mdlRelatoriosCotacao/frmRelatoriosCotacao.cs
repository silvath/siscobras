using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosCotacao
{
	/// <summary>
	/// Summary description for frmRelatoriosCotacao.
	/// </summary>
	public class frmRelatoriosCotacao : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
		private mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes m_typDatSetTbFaturasCotacoes = null;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button m_btAssistente;
		private System.Windows.Forms.Button m_btConfiguracoes;

		private System.Windows.Forms.Button m_btPe;
		#endregion
		#region Delegates
			public delegate void delCallCarregaPE(string strIdPE);
		#endregion
		#region Events 
			public event delCallCarregaPE eCallCarregaPE;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaPE(string strIdPE) 
			{
				if (eCallCarregaPE != null)
					eCallCarregaPE(strIdPE);
			}
		#endregion
		#region Constructor e Desctructor
		
		public frmRelatoriosCotacao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdCotacao) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,1,nIdExportador,strIdCotacao)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			bResizeForm();
			m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
		}
		public frmRelatoriosCotacao()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosCotacao));
			this.m_btPe = new System.Windows.Forms.Button();
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
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
			this.m_btEnviarImagemEmail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Trocar idioma ");
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar formato");
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_vsbVertical.Name = "m_vsbVertical";
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMais.Name = "m_btZoomMais";
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraSuperior.Controls.Add(this.m_btConfiguracoes);
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Controls.Add(this.m_btPe);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btPe, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btConfiguracoes, 0);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btImprimir.Name = "m_btImprimir";
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btExcluirEdicao.Name = "m_btExcluirEdicao";
			// 
			// m_btZoomNormal
			// 
			this.m_btZoomNormal.Name = "m_btZoomNormal";
			// 
			// m_btImportar
			// 
			this.m_btImportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btImportar.Name = "m_btImportar";
			// 
			// m_btExportar
			// 
			this.m_btExportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.m_btExportar.Name = "m_btExportar";
			// 
			// m_btPe
			// 
			this.m_btPe.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPe.Image = ((System.Drawing.Image)(resources.GetObject("m_btPe.Image")));
			this.m_btPe.Location = new System.Drawing.Point(44, 10);
			this.m_btPe.Name = "m_btPe";
			this.m_btPe.Size = new System.Drawing.Size(25, 24);
			this.m_btPe.TabIndex = 58;
			this.m_btPe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ttDica.SetToolTip(this.m_btPe, "Cria um PE apartir desta cotação");
			this.m_btPe.Click += new System.EventHandler(this.m_btPe_Click);
			// 
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(18, 10);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 60;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(72, 10);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.Size = new System.Drawing.Size(25, 24);
			this.m_btConfiguracoes.TabIndex = 62;
			this.m_ttDica.SetToolTip(this.m_btConfiguracoes, "Configurações");
			this.m_btConfiguracoes.Click += new System.EventHandler(this.m_btConfiguracoes_Click);
			// 
			// frmRelatoriosCotacao
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Name = "frmRelatoriosCotacao";
			this.Load += new System.EventHandler(this.frmRelatoriosCotacao_Load);
			this.m_gbBarraSuperior.ResumeLayout(false);

		}
		#endregion
		#region Eventos do Formulário
        #endregion
		#region Métodos SobreEscritos

		public override bool bCarregaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IsidRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbFaturasCotacoes.idRelatorio;
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicaoCampo, arlCondicaoTipo, arlCondicaoValor, null, null);
				if (m_typDatSetTbExportadores.tbExportadores.Rows.Count > 0)
				{
					dtrwTbExportadores =(mdlDataBaseAccess.Tabelas.XsdTbExportadores.tbExportadoresRow)m_typDatSetTbExportadores.tbExportadores.Rows[0];
					dtrwTbExportadores.idRelatorioCotacao = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbExportadores(m_typDatSetTbExportadores);
				}

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					dtrwRowTbFaturasCotacoes.idRelatorio = m_nIdRelatorio;
					m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
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
				mdlIdioma.clsIdiomaFaturaCotacao formIdioma = new mdlIdioma.clsIdiomaFaturaCotacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo,ref LstBandeiras);
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
				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IsidIdiomaNull())
						m_nIdIdioma = dtrwRowTbFaturasCotacoes.idIdioma;
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
		#endregion
		#region Métodos Referente a criacao de um PE apartir da Cotacao
			private void m_btPe_Click(object sender, System.EventArgs e)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				mdlCriacaoDocumentos.clsCriacao cls_PeCad = new mdlCriacaoDocumentos.Faturas.clsCriacaoProcesso(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador, ref m_ilBandeiras);
				cls_PeCad.CadastrarPEDiretoBaseadoCotacaoSemMostrarInterface(m_strIdCodigo);
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				cls_PeCad.cadastraDocumento();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				if (cls_PeCad.m_bModificado)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					this.Refresh();
					OnCallCarregaPE(cls_PeCad.CODIGORETORNO);
				}
				cls_PeCad = null;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region ShowDialogConfiguracoes
			private void ShowDialogConfiguracoes()
			{
				frmFConfiguracoes formFConfiguracoes = new frmFConfiguracoes(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFConfiguracoes);
				formFConfiguracoes.ShowDialog();
				if (formFConfiguracoes.Modificado)
				{
					bMostrarRelatorio();
				}
				formFConfiguracoes.Dispose();
			}

			private void vInitializeEvents(ref frmFConfiguracoes formFConfiguracoes)
			{
				// Carrega Dados
				formFConfiguracoes.eCallCarregaDados += new mdlRelatoriosCotacao.frmFConfiguracoes.delCallCarregaDados(vCarregaDadosConfiguracoes);

				// Salva Dados 
				formFConfiguracoes.eCallSalvaDados += new mdlRelatoriosCotacao.frmFConfiguracoes.delCallSalvaDados(bSalvaDadosConfiguracoes);
			}

			private void vCarregaDadosConfiguracoes(out int nTipoAgrupamento,out bool bDetalharProdutos,out bool bMostrarGrupo)
			{
				nTipoAgrupamento = 0;
				bDetalharProdutos = false;
				bMostrarGrupo = false;

				mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacoes;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idCotacao");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
				{
					dtrwRowTbFaturasCotacoes = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
					if (!dtrwRowTbFaturasCotacoes.IsidClassificacaoTarifariaMostrarNull())
						nTipoAgrupamento = dtrwRowTbFaturasCotacoes.idClassificacaoTarifariaMostrar;
					if (!dtrwRowTbFaturasCotacoes.IsbDetalharProdutosNull())
						bDetalharProdutos = dtrwRowTbFaturasCotacoes.bDetalharProdutos;
					if (!dtrwRowTbFaturasCotacoes.IsbMostrarGrupoNull())
						bMostrarGrupo = dtrwRowTbFaturasCotacoes.bMostrarGrupo;

				}
			}

			private bool bSalvaDadosConfiguracoes(int nTipoAgrupamento,bool bDetalharProdutos,bool bMostrarGrupo)
			{
				bool bRetorno = true;
				if (bRetorno)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow dtrwRowTbFaturasCotacao;
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idCotacao");
					arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdCodigo);

					m_typDatSetTbFaturasCotacoes = m_cls_dba_ConnectionDB.GetTbFaturasCotacoes(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows.Count > 0)
					{
						dtrwRowTbFaturasCotacao = (mdlDataBaseAccess.Tabelas.XsdTbFaturasCotacoes.tbFaturasCotacoesRow)m_typDatSetTbFaturasCotacoes.tbFaturasCotacoes.Rows[0];
						dtrwRowTbFaturasCotacao.idClassificacaoTarifariaMostrar = nTipoAgrupamento;
						dtrwRowTbFaturasCotacao.bDetalharProdutos = bDetalharProdutos;
						dtrwRowTbFaturasCotacao.bMostrarGrupo = bMostrarGrupo;
						try
						{
							m_cls_dba_ConnectionDB.SetTbFaturasCotacoes(m_typDatSetTbFaturasCotacoes);
						}
						catch
						{
							bRetorno = false;
						}
					}
					else
					{
						bRetorno = false;
					}
				}
				return(bRetorno);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmRelatoriosCotacao_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					bMostrarRelatorio();
				}
			#endregion
			#region Botoes
				private void m_btAssistente_Click(object sender, System.EventArgs e)
				{
					mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteFaturaCotacao(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					if (obj.ShowDialog())
						bMostrarRelatorio();
				}

				private void m_btConfiguracoes_Click(object sender, System.EventArgs e)
				{
					ShowDialogConfiguracoes();
				}
			#endregion
		#endregion
	}
}
