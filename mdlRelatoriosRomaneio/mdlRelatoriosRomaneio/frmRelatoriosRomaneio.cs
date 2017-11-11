using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosRomaneio
{
	/// <summary>
	/// Summary description for frmRelatoriosRomaneio.
	/// </summary>
	public class frmRelatoriosRomaneio : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
			private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
			private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
			private System.Windows.Forms.Button m_btConfiguracoes;
			private bool m_bMostrarVolumes = false;
			private System.Windows.Forms.Button m_btAssistente;
		private System.Windows.Forms.Button m_btShowConfiguracoes;
			private bool m_bMostrarEmbalagens = false;
		#endregion
		#region Constructor e Desctructor
		
		public frmRelatoriosRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos.RELATORIO_ROMANEIO_PRODUTOS,nIdExportador,strIdPE)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosRomaneio));
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_btShowConfiguracoes = new System.Windows.Forms.Button();
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
			this.m_btEnviarImagemEmail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btEnviarImagemEmail.Name = "m_btEnviarImagemEmail";
			this.m_ttDica.SetToolTip(this.m_btEnviarImagemEmail, "Enviar via e-mail ");
			// 
			// m_btIdioma
			// 
			this.m_btIdioma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btIdioma.Name = "m_btIdioma";
			this.m_ttDica.SetToolTip(this.m_btIdioma, "Alterar idioma ");
			// 
			// m_btSalvarImagem
			// 
			this.m_btSalvarImagem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarImagem.Name = "m_btSalvarImagem";
			this.m_ttDica.SetToolTip(this.m_btSalvarImagem, "Salvar imagem");
			// 
			// m_btModoEdicao
			// 
			this.m_btModoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btModoEdicao.Name = "m_btModoEdicao";
			this.m_ttDica.SetToolTip(this.m_btModoEdicao, "Editar formato");
			// 
			// m_btTrocarRelatorio
			// 
			this.m_btTrocarRelatorio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btTrocarRelatorio.Name = "m_btTrocarRelatorio";
			this.m_ttDica.SetToolTip(this.m_btTrocarRelatorio, "Trocar formato ");
			// 
			// m_btUltimaPagina
			// 
			this.m_btUltimaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btUltimaPagina.Name = "m_btUltimaPagina";
			this.m_ttDica.SetToolTip(this.m_btUltimaPagina, "Ultima página");
			// 
			// m_btPrimeiraPagima
			// 
			this.m_btPrimeiraPagima.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btPrimeiraPagima.Name = "m_btPrimeiraPagima";
			this.m_ttDica.SetToolTip(this.m_btPrimeiraPagima, "Primeira página");
			// 
			// m_lbPaginaAtual
			// 
			this.m_lbPaginaAtual.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_lbPaginaAtual.Name = "m_lbPaginaAtual";
			// 
			// m_btPaginaAnterior
			// 
			this.m_btPaginaAnterior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btPaginaAnterior.Name = "m_btPaginaAnterior";
			this.m_ttDica.SetToolTip(this.m_btPaginaAnterior, "Página anterior");
			// 
			// m_btProximaPagina
			// 
			this.m_btProximaPagina.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btProximaPagina.Name = "m_btProximaPagina";
			this.m_ttDica.SetToolTip(this.m_btProximaPagina, "Página posterior");
			// 
			// m_vsbVertical
			// 
			this.m_vsbVertical.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_vsbVertical.Name = "m_vsbVertical";
			// 
			// m_hsbHorizontal
			// 
			this.m_hsbHorizontal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_hsbHorizontal.Name = "m_hsbHorizontal";
			// 
			// m_btZoomMenos
			// 
			this.m_btZoomMenos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMenos.Name = "m_btZoomMenos";
			// 
			// m_btZoomMais
			// 
			this.m_btZoomMais.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMais.Name = "m_btZoomMais";
			// 
			// m_gbBarraSuperior
			// 
			this.m_gbBarraSuperior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraSuperior.Controls.Add(this.m_btShowConfiguracoes);
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Controls.Add(this.m_btConfiguracoes);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btConfiguracoes, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btShowConfiguracoes, 0);
			// 
			// m_gbBarraInferior
			// 
			this.m_gbBarraInferior.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraInferior.Name = "m_gbBarraInferior";
			// 
			// m_btImprimir
			// 
			this.m_btImprimir.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btImprimir.Name = "m_btImprimir";
			// 
			// m_gbBarraInferiorEdicao
			// 
			this.m_gbBarraInferiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraInferiorEdicao.Name = "m_gbBarraInferiorEdicao";
			// 
			// m_gbBarraSuperiorEdicao
			// 
			this.m_gbBarraSuperiorEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_gbBarraSuperiorEdicao.Name = "m_gbBarraSuperiorEdicao";
			// 
			// m_btModoVisualizacao
			// 
			this.m_btModoVisualizacao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btModoVisualizacao.Name = "m_btModoVisualizacao";
			// 
			// m_btZoomMaisEdicao
			// 
			this.m_btZoomMaisEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMaisEdicao.Name = "m_btZoomMaisEdicao";
			// 
			// m_btZoomMenosEdicao
			// 
			this.m_btZoomMenosEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btZoomMenosEdicao.Name = "m_btZoomMenosEdicao";
			// 
			// m_btSalvarEdicao
			// 
			this.m_btSalvarEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarEdicao.Name = "m_btSalvarEdicao";
			// 
			// m_btTrocarRelatorioEdicao
			// 
			this.m_btTrocarRelatorioEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btTrocarRelatorioEdicao.Name = "m_btTrocarRelatorioEdicao";
			// 
			// m_btSalvarComoEdicao
			// 
			this.m_btSalvarComoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btSalvarComoEdicao.Name = "m_btSalvarComoEdicao";
			// 
			// m_btNovoEdicao
			// 
			this.m_btNovoEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btNovoEdicao.Name = "m_btNovoEdicao";
			// 
			// m_btMargensEdicao
			// 
			this.m_btMargensEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btMargensEdicao.Name = "m_btMargensEdicao";
			// 
			// m_btExcluirEdicao
			// 
			this.m_btExcluirEdicao.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btExcluirEdicao.Name = "m_btExcluirEdicao";
			// 
			// m_btZoomNormal
			// 
			this.m_btZoomNormal.Name = "m_btZoomNormal";
			// 
			// m_btImportar
			// 
			this.m_btImportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btImportar.Name = "m_btImportar";
			// 
			// m_btExportar
			// 
			this.m_btExportar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(220)), ((System.Byte)(250)), ((System.Byte)(220)));
			this.m_btExportar.Name = "m_btExportar";
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(44, 13);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.Size = new System.Drawing.Size(120, 24);
			this.m_btConfiguracoes.TabIndex = 60;
			this.m_btConfiguracoes.Text = "Tipo";
			this.m_btConfiguracoes.Click += new System.EventHandler(this.m_btConfiguracoes_Click);
			// 
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(18, 11);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 61;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// m_btShowConfiguracoes
			// 
			this.m_btShowConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btShowConfiguracoes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btShowConfiguracoes.Location = new System.Drawing.Point(166, 13);
			this.m_btShowConfiguracoes.Name = "m_btShowConfiguracoes";
			this.m_btShowConfiguracoes.Size = new System.Drawing.Size(120, 24);
			this.m_btShowConfiguracoes.TabIndex = 62;
			this.m_btShowConfiguracoes.Text = "Configurações";
			this.m_btShowConfiguracoes.Click += new System.EventHandler(this.m_btShowConfiguracoes_Click);
			// 
			// frmRelatoriosRomaneio
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Name = "frmRelatoriosRomaneio";
			this.Load += new System.EventHandler(this.frmRelatoriosRomaneio_Load);
			this.m_gbBarraSuperior.ResumeLayout(false);

		}
		#endregion

		#region Eventos do Formulário
		private void frmRelatoriosRomaneio_Load(object sender, System.EventArgs e)
		{
			vMostraCor();
			if (bCriaRegistroCasoNecessario())
			{
				if (!ShowDialogTipoRomaneio())
				{
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();
					bMostrarRelatorio();
				}
			}else{
				if (!bCarregaIdRelatorio())
					carregaIdRelatorioDefault();
				bMostrarRelatorio();
			}
			vRefreshBotaoConfiguracoes();
		}
		private void m_btAssistente_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			mdlCriacaoDocumentos.Assistentes.clsAssistente cls_Assistente = null;
			switch(m_nTipoRelatorio)
			{
				case (int)mdlConstantes.Relatorio.Romaneio:
					cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
				case (int)mdlConstantes.Relatorio.RomaneioVolumes:
					cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioVolumes(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
				case (int)mdlConstantes.Relatorio.RomaneioSimplificado:
					cls_Assistente = new mdlCriacaoDocumentos.Assistentes.clsAssistenteRomaneioSimplificado(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					break;
			}
			if (cls_Assistente != null)
			{
				if (cls_Assistente.ShowDialog())
					bMostrarRelatorio();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
        #endregion
		#region Métodos Referentes a Criacao do Registro
		private bool bCriaRegistroCasoNecessario()
		{
			bool bRetorno = false;
			try
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioEmbalagensProdutos m_typDatSetTbProdutosRomaneioEmbalagensProdutos = null;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosRomaneioVolumesProdutos m_typDatSetTbProdutosRomaneioVolumesProdutos = null;

				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosRomaneioVolumesProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioVolumesProdutos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				m_typDatSetTbProdutosRomaneioEmbalagensProdutos = m_cls_dba_ConnectionDB.GetTbProdutosRomaneioEmbalagensProdutos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count == 0)
				{
					// Carregando um Relatorio para o Registro
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();

					int nIdAssinatura = 0;
					int nIdIdioma = 1;
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (dtrwTbFaturasComerciais != null)
						{
							if (!dtrwTbFaturasComerciais.IsidAssinaturaNull())
								nIdAssinatura = dtrwTbFaturasComerciais.idAssinatura;
							if ((!dtrwTbFaturasComerciais.IsidIdiomaNull()) && (dtrwTbFaturasComerciais.idIdioma <= 3))
								nIdIdioma = dtrwTbFaturasComerciais.idIdioma;
						}
					}
					dtrwRowTbRomaneios = m_typDatSetTbRomaneios.tbRomaneios.NewtbRomaneiosRow();
					// idExportador , idPE, idRelatorio, dataEmissao , idAssinatura
					dtrwRowTbRomaneios.idExportador = m_nIdExportador;
					dtrwRowTbRomaneios.idPE = m_strIdCodigo;
					dtrwRowTbRomaneios.idRelatorio = m_nIdRelatorio;
					dtrwRowTbRomaneios.dtDataEmissao = System.DateTime.Now.Date;
					dtrwRowTbRomaneios.nIdAssinatura = nIdAssinatura;
					dtrwRowTbRomaneios.nImpressoes = 0;
					m_nTipoRelatorio = dtrwRowTbRomaneios.nTipoOrdenacao = mdlRelatoriosCallBackAreaProdutos.clsRelatoriosCallBackAreaProdutos.RELATORIO_ROMANEIO_SIMPLIFICADO;
					m_nIdIdioma = dtrwRowTbRomaneios.nIdIdioma = nIdIdioma;
                    m_bMostrarVolumes = dtrwRowTbRomaneios.bMostrarVolumesConsecutivos = false;
					m_bMostrarEmbalagens = dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas = false;
					m_typDatSetTbRomaneios.tbRomaneios.AddtbRomaneiosRow(dtrwRowTbRomaneios);
					m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
					mdlNumero.clsNumero obj = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
					obj.salvaDiretoSemMostrarInterface();
					obj = null;
					bRetorno = true;
				}else{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0]; 
					m_nTipoRelatorio = dtrwRomaneio.nTipoOrdenacao;
					m_bMostrarVolumes = dtrwRomaneio.bMostrarVolumesConsecutivos;
					m_bMostrarEmbalagens = dtrwRomaneio.bMostrarEmbalagensConsecutivas;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return (bRetorno);
		}
		#endregion
		#region Métodos SobreEscritos
		public override bool bCarregaIdRelatorio()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow dtrwRowTbRomaneiosSecundario;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nTipoRelatorio);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;

				mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios m_typDatSetTbRomaneiosSecundarios = m_cls_dba_ConnectionDB.GetTbRomaneiosSecundarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.Rows.Count > 0)
				{
					dtrwRowTbRomaneiosSecundario = (mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow)m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.Rows[0];
					if (!dtrwRowTbRomaneiosSecundario.IsnIdRelatorioNull())
                        m_nIdRelatorio = dtrwRowTbRomaneiosSecundario.nIdRelatorio;
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow dtrwRowTbRomaneiosSecundario;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strIdPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				arlCondicaoCampo.Add("nIdTipo");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nTipoRelatorio);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios m_typDatSetTbRomaneiosSecundarios = m_cls_dba_ConnectionDB.GetTbRomaneiosSecundarios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.Rows.Count > 0)
				{
					dtrwRowTbRomaneiosSecundario = (mdlDataBaseAccess.Tabelas.XsdTbRomaneiosSecundarios.tbRomaneiosSecundariosRow)m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.Rows[0];
					dtrwRowTbRomaneiosSecundario.nIdRelatorio = m_nIdRelatorio;
				}else{
					dtrwRowTbRomaneiosSecundario = m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.NewtbRomaneiosSecundariosRow();
					dtrwRowTbRomaneiosSecundario.nIdExportador = m_nIdExportador;
					dtrwRowTbRomaneiosSecundario.strIdPE = m_strIdCodigo;
					dtrwRowTbRomaneiosSecundario.nIdTipo = m_nTipoRelatorio;
					dtrwRowTbRomaneiosSecundario.nIdRelatorio = m_nIdRelatorio;
					m_typDatSetTbRomaneiosSecundarios.tbRomaneiosSecundarios.AddtbRomaneiosSecundariosRow(dtrwRowTbRomaneiosSecundario);
				}
				m_cls_dba_ConnectionDB.SetTbRomaneiosSecundarios(m_typDatSetTbRomaneiosSecundarios);
				return true;
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
				mdlIdioma.clsIdioma formIdioma = new mdlIdioma.clsIdiomaRomaneio(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo,ref LstBandeiras);
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
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRowTbRomaneios.IsnIdIdiomaNull())
						m_nIdIdioma = dtrwRowTbRomaneios.nIdIdioma;
					else
						m_nIdIdioma = 1;
					return true;
				}
				else
				{
					m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
					{
						dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
						if (dtrwTbFaturasComerciais != null)
						{
							if ((!dtrwTbFaturasComerciais.IsidIdiomaNull()) && (dtrwTbFaturasComerciais.idIdioma <= 3))
								m_nIdIdioma = dtrwTbFaturasComerciais.idIdioma;
							else
								m_nIdIdioma = 1;
						}
					}
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
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios;
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
				m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					if (!dtrwRowTbRomaneios.IsnImpressoesNull())
						dtrwRowTbRomaneios.nImpressoes++;
					else
						dtrwRowTbRomaneios.nImpressoes = 1;
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
				private void m_btConfiguracoes_Click(object sender, System.EventArgs e)
				{
					ShowDialogTipoRomaneio();
				}

				private void m_btShowConfiguracoes_Click(object sender, System.EventArgs e)
				{
					ShowDialogConfiguracoes();
				}
			#endregion
		#endregion

		#region ShowDialogTipoRomaneio
			private bool ShowDialogTipoRomaneio()
			{

				clsRomaneioConfiguracoes cls_Conf_Romaneio = new clsRomaneioConfiguracoes(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
				if (cls_Conf_Romaneio.ShowDialogTipo())
				{
					m_nTipoRelatorio = cls_Conf_Romaneio.TipoRelatorio;
					if (!bCarregaIdRelatorio())
						carregaIdRelatorioDefault();
					this.bMostrarRelatorio();
					vRefreshBotaoConfiguracoes();
					return(true);
				}else{
					return(false);
				}
			}
		#endregion
		#region ShowDialogConfiguracoes
			private bool ShowDialogConfiguracoes()
			{
				clsRomaneioConfiguracoes cls_Conf_Romaneio = new clsRomaneioConfiguracoes(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
				if (cls_Conf_Romaneio.ShowDialog())
				{
					this.bMostrarRelatorio();
					return(true);
				}
				return(false);
			}
		#endregion

		#region Configuracoes
			private void vRefreshBotaoConfiguracoes()
			{
				clsRomaneioConfiguracoes cls_Conf_Romaneio = new clsRomaneioConfiguracoes(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
				m_btShowConfiguracoes.Enabled = cls_Conf_Romaneio.HasConfig();
			}

			private void vCarregaDadosConfiguracoes(out int nTipoOrdenacao,out bool bMostrarVolumes,out bool bMostrarEmbalagens)
			{
				nTipoOrdenacao = m_nTipoRelatorio;
				bMostrarVolumes = m_bMostrarVolumes;
				bMostrarEmbalagens = m_bMostrarEmbalagens;
			}

			private bool bSalvaDadosConfiguracoes(int nTipoOrdenacao,bool bMostrarVolumes,bool bMostrarEmbalagens)
			{

				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoTipo.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_typDatSetTbRomaneios = m_cls_dba_ConnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRowTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					m_nTipoRelatorio = dtrwRowTbRomaneios.nTipoOrdenacao = nTipoOrdenacao;
					m_bMostrarVolumes = dtrwRowTbRomaneios.bMostrarVolumesConsecutivos = bMostrarVolumes;
					m_bMostrarEmbalagens = dtrwRowTbRomaneios.bMostrarEmbalagensConsecutivas = bMostrarEmbalagens;
					if (m_typDatSetTbRomaneios.GetChanges() != null)
					{
						try
						{
							m_cls_dba_ConnectionDB.SetTbRomaneios(m_typDatSetTbRomaneios);
							bRetorno = true;
						}
						catch
						{
							bRetorno = false;
						}
					}else{
						bRetorno = true;
					}
				}
				return(bRetorno);
			}
		#endregion

	}
}
