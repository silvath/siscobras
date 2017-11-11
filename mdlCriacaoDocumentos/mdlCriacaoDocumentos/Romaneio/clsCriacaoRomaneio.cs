using System;

namespace mdlCriacaoDocumentos.Romaneio
{
	/// <summary>
	/// Summary description for clsCriacaoRomaneio.
	/// </summary>
	public class clsCriacaoRomaneio
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dbaConnnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_terTratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		private string m_strLinkInternet = "";

		private bool m_bNumeroPreenchido = false;
		private bool m_bProdutosRomaneioPreenchido = false;

		public bool m_bModificado = false;

		private Frames.frmFAssistenteRomaneio m_formFAssistenteRomaneio = null;

		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		protected System.Windows.Forms.ImageList m_ilBandeiras = null;

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbRomaneios m_typDatSetTbRomaneios = null;
		#endregion

		#region Construtores & Destrutores
		public clsCriacaoRomaneio(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras)
		{
			m_cls_terTratadorErro = tratadorErro;
			m_cls_dbaConnnectionDB = ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_nIdExportador = nIdExportador;
			m_strIdPE = strIdPE;
			m_ilBandeiras = ilBandeiras;
			carregaTypDatSet();
			verificaCamposPreenchidos();
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaTypDatSet()
		{
			try
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_strIdPE);

				m_typDatSetTbPes = m_cls_dbaConnnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbRomaneios = m_cls_dbaConnnectionDB.GetTbRomaneios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		private void verificaCamposPreenchidos()
		{
			try
			{
				if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwTbRomaneios = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
					#region Número
					if (!dtrwTbRomaneios.IsstrNumeroNull())
						m_bNumeroPreenchido = true;
					#endregion
					#region Produtos
					mdlProdutosRomaneio.clsProdutosRomaneio objProdutosRomaneio = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
					if (objProdutosRomaneio.TOTALVOLUMES > 0)
						m_bProdutosRomaneioPreenchido = true;
					#endregion
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region InitializeEventsFormAssistenteRomaneio
		private void InitializeEventsFormAssistenteRomaneio()
		{
			// Número
			m_formFAssistenteRomaneio.eCallSelecionaNumero += new Frames.frmFAssistenteRomaneio.delCallSelecionaNumero(selecionaNumeroRomaneio);

			// Produtos Romaneio
			m_formFAssistenteRomaneio.eCallSelecionaProdutosRomaneio += new Frames.frmFAssistenteRomaneio.delCallSelecionaProdutosRomaneio(selecionaProdutosRomaneio);

			// Banner
			m_formFAssistenteRomaneio.eCallAlteraBanner += new Frames.frmFAssistenteRomaneio.delCallAlteraBanner(alteraBanner);

			// Click Banner
			m_formFAssistenteRomaneio.eCallClickBanner += new Frames.frmFAssistenteRomaneio.delCallClickBanner(clickBanner);
		}
		#endregion

		#region Modulos Assistentes
		#region Número do Romaneio
		private void selecionaNumeroRomaneio(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero)
		{
			mdlNumero.clsNumero obj = new mdlNumero.Romaneio.clsNumeroRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkNumero.Visible = true;
				pbNOKNumero.Visible = false;
				m_bNumeroPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Produtos do Romaneio
		private void selecionaProdutosRomaneio(ref System.Windows.Forms.PictureBox pbOkProdutos, ref System.Windows.Forms.PictureBox pbNOKProdutos)
		{
			if (m_typDatSetTbRomaneios.tbRomaneios.Rows.Count > 0)
			{
				mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow dtrwRomaneio = (mdlDataBaseAccess.Tabelas.XsdTbRomaneios.tbRomaneiosRow)m_typDatSetTbRomaneios.tbRomaneios.Rows[0];
				if (!dtrwRomaneio.IsnTipoOrdenacaoNull())
				{
					switch(dtrwRomaneio.nTipoOrdenacao)
					{
						case mdlConstantes.clsConstantes.RELATORIO_ROMANEIO_PRODUTOS: // Produtos
						case mdlConstantes.clsConstantes.RELATORIO_ROMANEIO_VOLUMES: // Volumes 
							mdlProdutosRomaneio.clsProdutosRomaneio obj = new mdlProdutosRomaneio.clsProdutosRomaneio(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
							obj.ShowDialog();
							if (obj.m_bModificado)
							{
								pbOkProdutos.Visible = true;
								pbNOKProdutos.Visible = false;
								m_bProdutosRomaneioPreenchido = true;
								obj = null;
							}
							break;
						case mdlConstantes.clsConstantes.RELATORIO_ROMANEIO_SIMPLIFICADO:
							mdlProdutosRomaneio.clsProdutosRomaneioSimplificado cls_prod_Romaneio = new mdlProdutosRomaneio.clsProdutosRomaneioSimplificado(ref m_cls_terTratadorErro,ref m_cls_dbaConnnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPE);
							cls_prod_Romaneio.ShowDialog();
							if (cls_prod_Romaneio.m_bModificado)
							{
								pbOkProdutos.Visible = true;
								pbNOKProdutos.Visible = false;
								m_bProdutosRomaneioPreenchido = true;
								obj = null;
							}
							break;
					}
				}
			}
		}
		#endregion
		#endregion

		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.ASSISTENTE);
				m_strLinkInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				if (m_formFAssistenteRomaneio != null)
					m_formFAssistenteRomaneio.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region ClickBanner
		protected void clickBanner()
		{
			try
			{
				if (m_strLinkInternet != "")
					System.Diagnostics.Process.Start(m_strLinkInternet);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				m_formFAssistenteRomaneio = new Frames.frmFAssistenteRomaneio(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormAssistenteRomaneio();
				m_formFAssistenteRomaneio.setaEstadoAssistente(m_bNumeroPreenchido, m_bProdutosRomaneioPreenchido);
				m_formFAssistenteRomaneio.ShowDialog();
				m_bModificado = m_formFAssistenteRomaneio.m_bModificado;
				m_formFAssistenteRomaneio = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		public void ShowDialogPrincipal()
		{
			try
			{
				m_formFAssistenteRomaneio = new Frames.frmFAssistenteRomaneio(ref m_cls_terTratadorErro, m_strEnderecoExecutavel, false, false);
				InitializeEventsFormAssistenteRomaneio();
				m_formFAssistenteRomaneio.setaEstadoAssistente(m_bNumeroPreenchido, m_bProdutosRomaneioPreenchido);
				m_formFAssistenteRomaneio.ShowDialog();
				m_bModificado = m_formFAssistenteRomaneio.m_bModificado;
				m_formFAssistenteRomaneio = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion
	}
}
