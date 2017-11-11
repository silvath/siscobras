using System;

namespace mdlCriacaoDocumentos.InstrucoesEmbarque
{
	/// <summary>
	/// Summary description for clsCriacaoInstrucoesEmbarque.
	/// </summary>
	public class clsCriacaoInstrucoesEmbarque
	{
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dbaConnnectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_terTratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		private string m_strLinkInternet = "";

		public bool m_bModificado = false;

		private bool m_bNumeroPreenchido = false;
		private bool m_bAgentePreenchido = false;
		private bool m_bNumeroReservaPreenchido = false;
		private bool m_bDataReservaPreenchido = false;
		private bool m_bConsignatarioPreenchido = false;
		private bool m_bDescricaoMercadoriasPreenchido = false;
		private bool m_bClassificacaoTarifariaPreenchido = false;
		private bool m_bVeiculoPreenchido = false;
		private bool m_bDespachantePreenchido = false;
		private bool m_bSiscomexPreenchido = false;
		private bool m_bObservacoesPreenchido = false;

		private Frames.frmFAssistenteInstrucoesEmbarque m_formFAssistenteInstrucoesEmbarque = null;
		
		private int m_nIdExportador = -1;
		private string m_strIdPE = "";

		private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetTbPes = null;
		private mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais m_typDatSetTbFaturasComerciais = null;
		private mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque m_typDatSetTbInstrucoesEmbarque = null;

		protected System.Windows.Forms.ImageList m_ilBandeiras = null;
		#endregion

		#region Construtores & Destrutores
		public clsCriacaoInstrucoesEmbarque(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE, ref System.Windows.Forms.ImageList ilBandeiras)
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
				m_typDatSetTbFaturasComerciais = m_cls_dbaConnnectionDB.GetTbFaturasComerciais(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				m_typDatSetTbInstrucoesEmbarque = m_cls_dbaConnnectionDB.GetTbInstrucoesEmbarque(arlCondicaoCampo, arlCondicaoComparador, arlCondicaoValor, null, null);
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
				if (m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow dtrwTbInstrucoesEmbarque = (mdlDataBaseAccess.Tabelas.XsdTbInstrucoesEmbarque.tbInstrucoesEmbarqueRow)m_typDatSetTbInstrucoesEmbarque.tbInstrucoesEmbarque.Rows[0];
					#region Número
					if (!dtrwTbInstrucoesEmbarque.IsstrNumeroNull())
						m_bNumeroPreenchido = true;
					#endregion
					#region Esquema Pagamento
					if (!dtrwTbInstrucoesEmbarque.IsnIdAgenteNull())
						m_bAgentePreenchido = true;
					#endregion
					#region Número
					if (!dtrwTbInstrucoesEmbarque.IsstrNumeroReservaNull())
						m_bNumeroReservaPreenchido = true;
					#endregion
					#region Data de Reserva
					if (!dtrwTbInstrucoesEmbarque.IsdtReservaNull())
						m_bDataReservaPreenchido = true;
					#endregion
					#region Descrição Geral Mercadorias
					if (!dtrwTbInstrucoesEmbarque.IsmstrDescricaoGeralMercadoriasNull())
						m_bDescricaoMercadoriasPreenchido = true;
					#endregion
					#region Código Tarifário
					if (!dtrwTbInstrucoesEmbarque.IsmstrCodigoTarifarioNull())
						m_bClassificacaoTarifariaPreenchido = true;
					#endregion
					#region Despachante
					if (!dtrwTbInstrucoesEmbarque.IsnIdDespachanteNull())
						m_bDespachantePreenchido = true;
					#endregion
					#region Observacoes
					if (!dtrwTbInstrucoesEmbarque.IsmstrObservacaoNull())
						m_bObservacoesPreenchido = true;
					#endregion
				}
				if (m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow dtrwTbFaturasComerciais = (mdlDataBaseAccess.Tabelas.XsdTbFaturasComerciais.tbFaturasComerciaisRow)m_typDatSetTbFaturasComerciais.tbFaturasComerciais.Rows[0];
					#region Veículo
					if (!dtrwTbFaturasComerciais.IsnavioNull())
						m_bVeiculoPreenchido = true;
					#endregion
				}
				if (m_typDatSetTbPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwTbPEs = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)m_typDatSetTbPes.tbPEs.Rows[0];
					#region Consignatário
					if (!dtrwTbPEs.IsnIdConsignatarioNull())
						m_bConsignatarioPreenchido = true;
					#endregion
					#region Siscomex
					if (!dtrwTbPEs.IsmstrRENull())
					{
						m_bSiscomexPreenchido = true;
					}
					else if (!dtrwTbPEs.IsmstrSDNull())
					{
						m_bSiscomexPreenchido = true;
					}
					else if (!dtrwTbPEs.IsmstrDSENull())
					{
						m_bSiscomexPreenchido = true;
					}
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

		#region InitializeEventsFormInstrucoesEmbarque
		private void InitializeEventsFormInstrucoesEmbarque()
		{
			// Número
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaNumero += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaNumero(selecionaNumeroInstrucaoEmbarque);

			// Agente
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaAgente += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaAgente(selecionaAgenteInstrucaoEmbarque);

			// Número Reserva
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaNumeroReserva += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaNumeroReserva(selecionaNumeroReservaInstrucaoEmbarque);

			// Data Reserva
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaDataReserva += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaDataReserva(selecionaDataReservaInstrucaoEmbarque);

			// Consignatário
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaConsignatario += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaConsignatario(selecionaConsignatarioInstrucaoEmbarque);

			// Descrição Mercadorias
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaDescricaoMercadorias += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaDescricaoMercadorias(selecionaDescricaoMercadoriasInstrucaoEmbarque);

			// Classificação Tarifária
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaClassificacaoTarifaria += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaClassificacaoTarifaria(selecionaClassificacaoTarifariaInstrucaoEmbarque);

			// Veículo
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaVeiculo += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaVeiculo(selecionaVeiculoInstrucaoEmbarque);

			// Despachante
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaDespachante += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaDespachante(selecionaDespachanteInstrucaoEmbarque);

			// Siscomex
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaSiscomex += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaSiscomex(selecionaSiscomexInstrucaoEmbarque);

			// Observações
			m_formFAssistenteInstrucoesEmbarque.eCallSelecionaObservacoes += new Frames.frmFAssistenteInstrucoesEmbarque.delCallSelecionaObservacoes(selecionaObservacoesInstrucaoEmbarque);

			// Banner
			m_formFAssistenteInstrucoesEmbarque.eCallAlteraBanner += new Frames.frmFAssistenteInstrucoesEmbarque.delCallAlteraBanner(alteraBanner);
		}
		#endregion

		#region Show Dialog
		public void ShowDialog()
		{
			try
			{
				m_formFAssistenteInstrucoesEmbarque = new Frames.frmFAssistenteInstrucoesEmbarque(ref m_cls_terTratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormInstrucoesEmbarque();
				m_formFAssistenteInstrucoesEmbarque.setaEstadoAssistente(m_bNumeroPreenchido, m_bAgentePreenchido, m_bNumeroReservaPreenchido, m_bDataReservaPreenchido, m_bConsignatarioPreenchido, m_bDescricaoMercadoriasPreenchido, m_bClassificacaoTarifariaPreenchido, m_bVeiculoPreenchido, m_bDespachantePreenchido, m_bSiscomexPreenchido, m_bObservacoesPreenchido);
				m_formFAssistenteInstrucoesEmbarque.ShowDialog();
				m_bModificado = m_formFAssistenteInstrucoesEmbarque.m_bModificado;
				m_formFAssistenteInstrucoesEmbarque = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Show Dialog Assistente Principal
		public void ShowDialogPrincipal()
		{
			try
			{
				m_formFAssistenteInstrucoesEmbarque = new Frames.frmFAssistenteInstrucoesEmbarque(ref m_cls_terTratadorErro, m_strEnderecoExecutavel, false, false);
				InitializeEventsFormInstrucoesEmbarque();
				m_formFAssistenteInstrucoesEmbarque.setaEstadoAssistente(m_bNumeroPreenchido, m_bAgentePreenchido, m_bNumeroReservaPreenchido, m_bDataReservaPreenchido, m_bConsignatarioPreenchido, m_bDescricaoMercadoriasPreenchido, m_bClassificacaoTarifariaPreenchido, m_bVeiculoPreenchido, m_bDespachantePreenchido, m_bSiscomexPreenchido, m_bObservacoesPreenchido);
				m_formFAssistenteInstrucoesEmbarque.ShowDialog();
				m_bModificado = m_formFAssistenteInstrucoesEmbarque.m_bModificado;
				m_formFAssistenteInstrucoesEmbarque = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_terTratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.ASSISTENTE);
				m_strLinkInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				if (m_formFAssistenteInstrucoesEmbarque != null)
					m_formFAssistenteInstrucoesEmbarque.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
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

		#region Módulo Assistentes
		#region Número da Instrução de Embarque
		private void selecionaNumeroInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero)
		{
			mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
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
		#region Agente da Instrução de Embarque
		private void selecionaAgenteInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkAgente, ref System.Windows.Forms.PictureBox pbNOKAgente)
		{
//			mdlAgentes.clsAgentes obj = new mdlAgentes.clsAgentes(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
//			obj.ShowDialog();
//			if (obj.m_bModificado)
//			{
//				pbOkAgente.Visible = true;
//				pbNOKAgente.Visible = false;
//				m_bAgentePreenchido = true;
//				obj = null;
//			}
//			else
//			{
//				return;
//			}
		}
		#endregion
		#region Número da Reserva da Instrução de Embarque
		private void selecionaNumeroReservaInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkNumero, ref System.Windows.Forms.PictureBox pbNOKNumero)
		{
			mdlNumero.clsNumero obj = new mdlNumero.InstrucoesEmbarque.clsNumeroReservaEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkNumero.Visible = true;
				pbNOKNumero.Visible = false;
				m_bNumeroReservaPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Data da Reserva da Instrução de Embarque
		private void selecionaDataReservaInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkData, ref System.Windows.Forms.PictureBox pbNOKData)
		{
			mdlData.clsData obj = new mdlData.DataReserva.clsDataReservaInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkData.Visible = true;
				pbNOKData.Visible = false;
				m_bDataReservaPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Consignatario da Instrução de Embarque
		private void selecionaConsignatarioInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkConsignatario, ref System.Windows.Forms.PictureBox pbNOKConsignatario)
		{
			mdlConsignatario.clsConsignatario obj = new mdlConsignatario.clsConsignatario(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkConsignatario.Visible = true;
				pbNOKConsignatario.Visible = false;
				m_bConsignatarioPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Descrição Mercadorias da Instrução de Embarque
		private void selecionaDescricaoMercadoriasInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkDescricao, ref System.Windows.Forms.PictureBox pbNOKDescricao)
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsInstrucoesEmbarqueDescricaoGeralMercadoria(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkDescricao.Visible = true;
				pbNOKDescricao.Visible = false;
				m_bDescricaoMercadoriasPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Classificação Tarifária da Instrução de Embarque
		private void selecionaClassificacaoTarifariaInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkClassificacao, ref System.Windows.Forms.PictureBox pbNOKClassificacao)
		{
			mdlProdutosVinculacao.clsClassificacaoTarifaria obj = new mdlProdutosVinculacao.clsClassificacaoTarifaria(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkClassificacao.Visible = true;
				pbNOKClassificacao.Visible = false;
				m_bClassificacaoTarifariaPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Veículo da Instrução de Embarque
		private void selecionaVeiculoInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkVeiculo, ref System.Windows.Forms.PictureBox pbNOKVeiculo)
		{
			pbOkVeiculo.Visible = true;
			pbNOKVeiculo.Visible = false;
			m_bVeiculoPreenchido = true;
		}
		#endregion
		#region Despachante da Instrução de Embarque
		private void selecionaDespachanteInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkDespachante, ref System.Windows.Forms.PictureBox pbNOKDespachante)
		{
//			mdlDespachante.clsDespachante obj = new mdlDespachante.InstrucoesEmbarque.clsDespachanteInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
//			obj.ShowDialog();
//			if (obj.m_bModificado)
//			{
//				pbOkDespachante.Visible = true;
//				pbNOKDespachante.Visible = false;
//				m_bDespachantePreenchido = true;
//				obj = null;
//			}
//			else
//			{
//				return;
//			}
		}
		#endregion
		#region Siscomex da Instrução de Embarque
		private void selecionaSiscomexInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkSiscomex, ref System.Windows.Forms.PictureBox pbNOKSiscomex)
		{
			mdlNumero.PEs.clsNumeroSiscomex obj = new mdlNumero.PEs.clsNumeroSiscomex(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkSiscomex.Visible = true;
				pbNOKSiscomex.Visible = false;
				m_bSiscomexPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#region Observações da Instrução de Embarque
		private void selecionaObservacoesInstrucaoEmbarque(ref System.Windows.Forms.PictureBox pbOkObservacoes, ref System.Windows.Forms.PictureBox pbNOKObservacoes)
		{
			mdlObservacoes.clsObservacoes obj = new mdlObservacoes.InstrucoesEmbarque.clsObservacoesInstrucoesEmbarque(ref m_cls_terTratadorErro, ref m_cls_dbaConnnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_strIdPE);
			obj.ShowDialog();
			if (obj.m_bModificado)
			{
				pbOkObservacoes.Visible = true;
				pbNOKObservacoes.Visible = false;
				m_bObservacoesPreenchido = true;
				obj = null;
			}
			else
			{
				return;
			}
		}
		#endregion
		#endregion
	}
}
