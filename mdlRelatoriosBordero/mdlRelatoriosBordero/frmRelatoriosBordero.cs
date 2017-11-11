using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosBordero
{
	/// <summary>
	/// Summary description for frmRelatoriosBordero.
	/// </summary>
	public class frmRelatoriosBordero : mdlRelatoriosBase.frmRelatoriosBase
	{
        #region Atributos
		private string m_strCompromisso = "";
		private int m_nIdBancoExportadorFaturaComercial = -1;
		private bool m_bSecundario = false;
		private mdlCriacaoDocumentos.Bordero.clsCriacaoBordero m_formFAssistente = null;
		private mdlDataBaseAccess.Tabelas.XsdTbBorderos m_typDatSetTbBorderos = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private System.Windows.Forms.Button m_btAssistente;
		private System.Windows.Forms.Button m_btBancoAtual;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Desctructor
			public frmRelatoriosBordero(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess conexaoBD, ref System.Windows.Forms.Form mdiParent,string strEnderecoExecutavel,int nIdExportador,string strIdPE) : base(ref tratadorErro,ref conexaoBD, ref mdiParent,strEnderecoExecutavel,12,nIdExportador,strIdPE)
			{
				InitializeComponent();
				bResizeForm();
				m_strSessaoArquivoConfiguracao = "SiscobrasCorSecundaria";
				m_btIdioma.Visible = false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRelatoriosBordero));
			this.m_btAssistente = new System.Windows.Forms.Button();
			this.m_btBancoAtual = new System.Windows.Forms.Button();
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
			this.m_gbBarraSuperior.Controls.Add(this.m_btBancoAtual);
			this.m_gbBarraSuperior.Controls.Add(this.m_btAssistente);
			this.m_gbBarraSuperior.Name = "m_gbBarraSuperior";
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btAssistente, 0);
			this.m_gbBarraSuperior.Controls.SetChildIndex(this.m_btBancoAtual, 0);
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
			this.m_ttDica.SetToolTip(this.m_btModoVisualizacao, "Volta a Visualizacao");
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
			this.m_ttDica.SetToolTip(this.m_btExcluirEdicao, "Exlui o relatório atual");
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
			// m_btAssistente
			// 
			this.m_btAssistente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAssistente.Image = ((System.Drawing.Image)(resources.GetObject("m_btAssistente.Image")));
			this.m_btAssistente.Location = new System.Drawing.Point(18, 10);
			this.m_btAssistente.Name = "m_btAssistente";
			this.m_btAssistente.Size = new System.Drawing.Size(24, 24);
			this.m_btAssistente.TabIndex = 58;
			this.m_ttDica.SetToolTip(this.m_btAssistente, "Assistente");
			this.m_btAssistente.Click += new System.EventHandler(this.m_btAssistente_Click);
			// 
			// m_btBancoAtual
			// 
			this.m_btBancoAtual.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBancoAtual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btBancoAtual.Location = new System.Drawing.Point(46, 11);
			this.m_btBancoAtual.Name = "m_btBancoAtual";
			this.m_btBancoAtual.Size = new System.Drawing.Size(302, 24);
			this.m_btBancoAtual.TabIndex = 59;
			this.m_btBancoAtual.Click += new System.EventHandler(this.m_btBancoAtual_Click);
			// 
			// frmRelatoriosBordero
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(200)), ((System.Byte)(235)), ((System.Byte)(202)));
			this.ClientSize = new System.Drawing.Size(798, 598);
			this.Name = "frmRelatoriosBordero";
			this.Load += new System.EventHandler(this.frmRelatoriosBordero_Load);
			this.m_gbBarraSuperior.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dados
			private void vCarregaIdBancoExportadorFaturaComercial()
			{
				m_nIdBancoExportadorFaturaComercial = -1;

				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("idPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais typDatSetFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwFaturaComercial = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)typDatSetFaturasComerciais.tbFaturasComerciais.Rows[0];
					if (!dtrwFaturaComercial.IsidExportadorBancoNull())
						m_nIdBancoExportadorFaturaComercial = dtrwFaturaComercial.idExportadorBanco;

				}
			}
		#endregion
		#region Salvamento dados
		#endregion

		#region ShowDialogBancoAtual
			private void ShowDialogBancoAtual()
			{
				frmFBancoAtual formFBancoAtual = new frmFBancoAtual(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFBancoAtual);
				formFBancoAtual.ShowDialog();
				if (formFBancoAtual.m_bModificado)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					vRefreshBancoAtual();
					if (m_bSecundario)
						m_nTipoRelatorio = 24;
					else
						m_nTipoRelatorio = 12;
					bMostrarRelatorio();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				formFBancoAtual = null;
			}
				
			private void vInitializeEvents(ref frmFBancoAtual formFBancoAtual)
			{
				// Refresh Bancos
				formFBancoAtual.eCallRefreshBancos += new mdlRelatoriosBordero.frmFBancoAtual.delCallRefreshBancos(vRefreshBancos);

				// Carrega Dados
				formFBancoAtual.eCallCarregaDados += new mdlRelatoriosBordero.frmFBancoAtual.delCallCarregaDados(vCarregaIdBancoAtual);

				// Salva Dados
				formFBancoAtual.eCallSalvaDados += new mdlRelatoriosBordero.frmFBancoAtual.delCallSalvaDados(bSalvaIdBancoAtual);
			}
		#endregion 

		#region Eventos
			#region Formulario
				private void frmRelatoriosBordero_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					vCarregaIdBancoExportadorFaturaComercial();
					if (!bCriaRegistroCasoNecessario())
						vModificaRegistroCasoNecessario();
					vRefreshBancoAtual();
					if (m_bSecundario)
						m_nTipoRelatorio = 24;
					else
						m_nTipoRelatorio = 12;
					bMostrarRelatorio();
				}
			#endregion
			#region Botoes
				private void m_btBancoAtual_Click(object sender, System.EventArgs e)
				{
					ShowDialogBancoAtual();
				}

				private void m_btAssistente_Click(object sender, System.EventArgs e)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlCriacaoDocumentos.Assistentes.clsAssistente obj = new mdlCriacaoDocumentos.Assistentes.clsAssistenteBordero(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdCodigo);
					if (obj.ShowDialog())
					{
						vCarregaIdBancoExportadorFaturaComercial();
						vModificaRegistroCasoNecessario();
						vRefreshBancoAtual();
						if (m_bSecundario)
							m_nTipoRelatorio = 24;
						else
							m_nTipoRelatorio = 12;
						bMostrarRelatorio();
					}
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
		#endregion
		#region SobreEscritos
			public override bool bCarregaIdRelatorio()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
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
					m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
					{
						dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
						if (!dtrwRowTbBorderos.IsidRelatorioNull())
							m_nIdRelatorio = dtrwRowTbBorderos.idRelatorio;
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
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
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
					m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
					{
						dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
						dtrwRowTbBorderos.idRelatorio = m_nIdRelatorio;
						m_cls_dba_ConnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
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
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
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
					m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
					{
						dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
						if (!dtrwRowTbBorderos.IsnImpressoesNull())
							dtrwRowTbBorderos.nImpressoes++;
						else
							dtrwRowTbBorderos.nImpressoes = 1;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
		#endregion

		#region Registro
			private bool bCriaRegistroCasoNecessario()
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos;
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

					m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
					if (m_typDatSetTbBorderos.tbBorderos.Rows.Count == 0)
					{
						// Carregando um Relatorio para o Registro
						if (!bCarregaIdRelatorio())
							carregaIdRelatorioDefault();

						int nIdAssinatura = 0;
						string strEsquemaPagamento = "";
						int nIdBancoExportador = -1;
						m_typDatSetTbFaturasComerciais = m_cls_dba_ConnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
						if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
						{
							dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
							if (dtrwTbFaturasComerciais != null)
							{
								if (!dtrwTbFaturasComerciais.IsidAssinaturaNull())
									nIdAssinatura = dtrwTbFaturasComerciais.idAssinatura;
								if (!dtrwTbFaturasComerciais.IsmstrEsquemaPagamentoNull())
									strEsquemaPagamento = dtrwTbFaturasComerciais.mstrEsquemaPagamento;
								if (!dtrwTbFaturasComerciais.IsidExportadorBancoNull())
									nIdBancoExportador = dtrwTbFaturasComerciais.idExportadorBanco;
							}
						}
						dtrwRowTbBorderos = m_typDatSetTbBorderos.tbBorderos.NewtbBorderosRow();
						// idExportador , idPE, idRelatorio, dataEmissao , idAssinatura
						dtrwRowTbBorderos.idExportador = m_nIdExportador;
						dtrwRowTbBorderos.idPE = m_strIdCodigo;
						dtrwRowTbBorderos.idRelatorio = m_nIdRelatorio;
						dtrwRowTbBorderos.dtDataEmissao = System.DateTime.Now.Date;
						dtrwRowTbBorderos.mstrEsquemaPagamento = strEsquemaPagamento;
						dtrwRowTbBorderos.mstrCompromisso = m_strCompromisso;
						dtrwRowTbBorderos.nIdBancoExportadorAtual = nIdBancoExportador;
						dtrwRowTbBorderos.nImpressoes = 0;
						dtrwRowTbBorderos.nIdAssinatura = nIdAssinatura;
						dtrwRowTbBorderos.nEntregaDocumentos = (int)mdlBorderoCobranca.ENTREGARDOCUMENTOS.ACEITE;
						dtrwRowTbBorderos.bCobrancaProtestar = true;
						dtrwRowTbBorderos.nCobrancaDiasVencimento = 15;
						m_typDatSetTbBorderos.tbBorderos.AddtbBorderosRow(dtrwRowTbBorderos);
						m_cls_dba_ConnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
						mdlNumero.clsNumero NumObj = new mdlNumero.Bordero.clsNumeroBordero(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo);
						NumObj.salvaDiretoSemMostrarInterface();
						NumObj = null;
						if (this.MostrarAssistente)
						{
							m_formFAssistente = new mdlCriacaoDocumentos.Bordero.clsCriacaoBordero(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdCodigo, ref m_ilBandeiras);
							m_formFAssistente.ShowDialog();
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

			private void vModificaRegistroCasoNecessario()
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
				m_typDatSetTbBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoTipo,arlCondicaoValor,null,null);
				if (m_typDatSetTbBorderos.tbBorderos.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwRowTbBorderos = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)m_typDatSetTbBorderos.tbBorderos.Rows[0];
					dtrwRowTbBorderos.nIdBancoExportadorAtual = m_nIdBancoExportadorFaturaComercial;
					m_cls_dba_ConnectionDB.SetTbBorderos(m_typDatSetTbBorderos);
				}
			}
		#endregion
		#region Banco
			private void vRefreshBancos(ref mdlComponentesGraficos.ListView lvBancos)
			{
				lvBancos.Items.Clear();

				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				// Carregando os Dados
				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos typDatSetExportadoresBancos = m_cls_dba_ConnectionDB.GetTbExportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
                mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				arlCondicaoCampo.Add("strIdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero typDatSetProdutosBordero = m_cls_dba_ConnectionDB.GetTbProdutosBordero(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);

				System.Collections.ArrayList arlBancos = new System.Collections.ArrayList();
				arlBancos.Add(m_nIdBancoExportadorFaturaComercial);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbProdutosBordero.tbProdutosBorderoRow dtrwProduto in typDatSetProdutosBordero.tbProdutosBordero.Rows)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in typDatSetContratosCambio.tbContratosCambio.Rows)
					{
						if (dtrwContratoCambio.nIdContratoCambio == dtrwProduto.nIdContratoCambio)
						{
							if (!arlBancos.Contains(dtrwContratoCambio.nIdExportadorBanco))
								arlBancos.Add(dtrwContratoCambio.nIdExportadorBanco);
                            break;
						}
					}
 				}
				System.Windows.Forms.ListViewItem lviBanco;
				// Inserindo Bancos dos Contratos de Cambio 
				for (int i = 0; i < arlBancos.Count; i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwBanco = typDatSetExportadoresBancos.tbExportadoresBancos.FindBynIdExportadornIdBanco(m_nIdExportador,Int32.Parse(arlBancos[i].ToString()));
					if (dtrwBanco != null)
					{
						lviBanco = lvBancos.Items.Add(dtrwBanco.strNome);
						lviBanco.Tag = dtrwBanco.nIdBanco;
						if (dtrwBanco.nIdBanco == m_nIdBancoExportadorFaturaComercial)
							lviBanco.ForeColor = System.Drawing.Color.Red;
					}
				}
			}

			private void vRefreshBancoAtual()
			{
				int nIdBanco;
				string strNomeBanco;
				vCarregaIdBancoAtual(out nIdBanco);
				vCarregaNomeBanco(nIdBanco,out strNomeBanco);
				if (strNomeBanco == "")
					nIdBanco = m_nIdBancoExportadorFaturaComercial;
				m_btBancoAtual.Text = strNomeBanco;
				if (m_nIdBancoExportadorFaturaComercial != nIdBanco)
					m_bSecundario = true;
				else
					m_bSecundario = false;
			}

			private void vCarregaNomeBanco(int nIdBanco,out string strNomeBanco)
			{
				strNomeBanco = "";

				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("nIdBanco");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdBanco);
				mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos typDatSetExportadoresBancos = m_cls_dba_ConnectionDB.GetTbExportadoresBancos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetExportadoresBancos.tbExportadoresBancos.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow dtrwBanco = (mdlDataBaseAccess.Tabelas.XsdTbExportadoresBancos.tbExportadoresBancosRow)typDatSetExportadoresBancos.tbExportadoresBancos.Rows[0];
					if (!dtrwBanco.IsstrNomeNull())
						strNomeBanco = dtrwBanco.strNome;
				}
			}

			private void vCarregaIdBancoAtual(out int nIdBancoAtual)
			{
				nIdBancoAtual = -1;
				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				arlCondicaoCampo.Add("IdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("IdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);
				mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetBorderos.tbBorderos.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwBordero = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)typDatSetBorderos.tbBorderos[0];
					if (!dtrwBordero.IsnIdBancoExportadorAtualNull())
					{
						nIdBancoAtual = dtrwBordero.nIdBancoExportadorAtual;
					}
				}
			}

			private bool bSalvaIdBancoAtual(int nIdBancoAtual)
			{
				bool bRetorno = false;
				System.Collections.ArrayList arlCondicaoCampo = new ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new ArrayList();

				arlCondicaoCampo.Add("IdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);
				arlCondicaoCampo.Add("IdPe");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdCodigo);
				mdlDataBaseAccess.Tabelas.XsdTbBorderos typDatSetBorderos = m_cls_dba_ConnectionDB.GetTbBorderos(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetBorderos.tbBorderos.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow dtrwBordero = (mdlDataBaseAccess.Tabelas.XsdTbBorderos.tbBorderosRow)typDatSetBorderos.tbBorderos[0];
					dtrwBordero.nIdBancoExportadorAtual = nIdBancoAtual;
					if (nIdBancoAtual != m_nIdBancoExportadorFaturaComercial)
						m_bSecundario = true;
					else
						m_bSecundario = false;
					try
					{
						m_cls_dba_ConnectionDB.SetTbBorderos(typDatSetBorderos);
						bRetorno = true;
					}catch{
						bRetorno = false; 
					}
				}
				return(bRetorno);
			}
		#endregion
	}
}
