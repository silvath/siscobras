using System;

namespace mdlControladoraMensagens
{
	/// <summary>
	/// Summary description for clsSchedulerDates.
	/// </summary>
	public class clsSchedulerDates : clsScheduler
	{
		#region Atributes
			private double m_dMinutesBeforeShowChegadaTransporte = 7200d;
			private double m_dMinutesBeforeShowListaCarga = 7200d;
			private double m_dMinutesBeforeShowEspelhoBL = 7200d;
			private double m_dMinutesBeforeShowRetiradaContainerTerminal = 7200d;
			private double m_dMinutesBeforeShowAberturaPortao = 7200d;
			private double m_dMinutesBeforeShowFechamentoPortao = 7200d;
			private double m_dMinutesBeforeShowLiberacaoRF = 7200d;
			private double m_dMinutesBeforeShowOutro = 7200d;

			private string  m_strMessageBaseChegadaTransporte = "[EXPORTADOR][PE]: navio [NAVIO] previsto [DIA]/[MES]/[ANO]";
			private string  m_strMessageBaseListaCarga = "[EXPORTADOR][PE]: Entregar \"Lista de Carga\" até [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseEspelhoBL = "[EXPORTADOR][PE]: Entregar espelho do BL até [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseRetiradaContainerTerminal = "[EXPORTADOR][PE]: Retirar o container até [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseAberturaPortao = "[EXPORTADOR][PE]: Portão aberto a partir de [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseFechamentoPortao = "[EXPORTADOR][PE]: Portão fechará em [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseLiberacaoRF = "[EXPORTADOR] [PE]: Desembaraçar até [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
			private string  m_strMessageBaseOutro = "[OUTRO]: [DIA]/[MES]/[ANO] às [HORA]:[MINUTO]";
		#endregion
		#region Properties
			public string MessageBaseChegadaTransporte
			{
				set
				{
					m_strMessageBaseChegadaTransporte = value;
				}
				get
				{
					return(m_strMessageBaseChegadaTransporte);
				}
			}

			public string MessageBaseListaCarga
			{
				set
				{
					m_strMessageBaseListaCarga = value;
				}
				get
				{
					return(m_strMessageBaseListaCarga);
				}
			}

			public string MessageBaseEspelhoBL
			{
				set
				{
					m_strMessageBaseEspelhoBL = value;
				}
				get
				{
					return(m_strMessageBaseEspelhoBL);
				}
			}

			public string MessageBaseRetiradaContainer
			{
				set
				{
					m_strMessageBaseRetiradaContainerTerminal = value;
				}
				get
				{
					return(m_strMessageBaseRetiradaContainerTerminal);
				}
			}

			public string MessageBaseAberturaPortao
			{
				set
				{
					m_strMessageBaseAberturaPortao = value;
				}
				get
				{
					return(m_strMessageBaseAberturaPortao);
				}
			}

			public string MessageBaseFechamentoPortao
			{
				set
				{
					m_strMessageBaseFechamentoPortao = value;
				}
				get
				{
					return(m_strMessageBaseFechamentoPortao);
				}
			}

			public string MessageBaseLiberacaoRF
			{
				set
				{
					m_strMessageBaseLiberacaoRF = value;
				}
				get
				{
					return(m_strMessageBaseLiberacaoRF);
				}
			}

			public string MessageBaseOutro
			{
				set
				{
					m_strMessageBaseOutro = value;
				}
				get
				{
					return(m_strMessageBaseOutro);
				}
			}

			public double MinutesBeforeShowChegadaTransporte
			{
				set
				{
					m_dMinutesBeforeShowChegadaTransporte = value;
				}
				get
				{
					return(m_dMinutesBeforeShowChegadaTransporte);
				}
			}

			public double MinutesBeforeShowListaCarga
			{
				set
				{
					m_dMinutesBeforeShowListaCarga = value;
				}
				get
				{
					return(m_dMinutesBeforeShowListaCarga);
				}
			}

			public double MinutesBeforeShowEspelhoBL
			{
				set
				{
					m_dMinutesBeforeShowEspelhoBL = value;
				}
				get
				{
					return(m_dMinutesBeforeShowEspelhoBL);
				}
			}

			public double MinutesBeforeShowRetiradaContainer
			{
				set
				{
					m_dMinutesBeforeShowRetiradaContainerTerminal = value;
				}
				get
				{
					return(m_dMinutesBeforeShowRetiradaContainerTerminal);
				}
			}

			public double MinutesBeforeShowAberturaPortao
			{
				set
				{
					m_dMinutesBeforeShowAberturaPortao = value;
				}
				get
				{
					return(m_dMinutesBeforeShowAberturaPortao);
				}
			}

			public double MinutesBeforeShowFechamentoPortao
			{
				set
				{
					m_dMinutesBeforeShowFechamentoPortao = value;
				}
				get
				{
					return(m_dMinutesBeforeShowFechamentoPortao);
				}
			}

			public double MinutesBeforeShowLiberacaoRF
			{
				set
				{
					m_dMinutesBeforeShowLiberacaoRF = value;
				}
				get
				{
					return(m_dMinutesBeforeShowLiberacaoRF);
				}
			}

			public double MinutesBeforeShowOutro
			{
				set
				{
					m_dMinutesBeforeShowOutro = value;
				}
				get
				{
					return(m_dMinutesBeforeShowOutro);
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsSchedulerDates(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref string strEnderecoExecutavel) : base(ref cls_dba_ConnectionDB,ref strEnderecoExecutavel,clsControladoraMensagens.SCHEDULER_DEADLINE_NAME)
			{

			}
		#endregion

		#region Start
			public void vStart()
			{
				base.Enabled = true;
				bSyncronizeMessages();
				bLoadMessages();
			}
		#endregion
		#region Stop
			public void vStop()
			{
				base.Enabled = false;
				this.vClear();
			}
		#endregion

		#region Delete
			public override bool bMessage_Delete(int nIdMessage)
			{
				bool bReturn = base.bMessage_Delete (nIdMessage);
				bSaveMessage(nIdMessage,m_nDefaultSaveTrys);
				return(bReturn);
			}
		#endregion

		#region Syncronize
			public bool bSyncronizeMessages()
			{
				return(bSyncronizeMessages(m_nDefaultSyncronizeTrys));
			}

			private bool bSyncronizeMessages(int nTrys)
			{
				if (nTrys == 0)
					return(false);
				mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens = null;
				if (bLoadMessages(out typDatSetMensagens,false,true))
				{
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					bool bShowDialogErrors = m_cls_dba_ConnectionDB.ShowDialogsErrors;
					m_cls_dba_ConnectionDB.ShowDialogsErrors = false;
					mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(null,null,null,null,null);
					m_cls_dba_ConnectionDB.ShowDialogsErrors = bShowDialogErrors;
					string strMessage = "";
					mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage = null;
					// Inserting new Messages
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwPe in typDatSetPes.tbPEs.Rows)
					{
						// Chegada Prevista Transporte
						if (!dtrwPe.IsdtDeadlineChegadaPrevistaTransporteNull() && (dtrwPe.dtDeadlineChegadaPrevistaTransporte != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseChegadaTransporte,dtrwPe.dtDeadlineChegadaPrevistaTransporte,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_CHEGADATRANSPORTE,dtrwPe.dtDeadlineChegadaPrevistaTransporte.AddMinutes(-m_dMinutesBeforeShowChegadaTransporte),dtrwPe.dtDeadlineChegadaPrevistaTransporte,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineChegadaPrevistaTransporte)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineChegadaPrevistaTransporte;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineChegadaPrevistaTransporte.AddMinutes(-m_dMinutesBeforeShowChegadaTransporte);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Lista Carga
						if (!dtrwPe.IsdtDeadlineListaCargaNull() && (dtrwPe.dtDeadlineListaCarga != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseListaCarga,dtrwPe.dtDeadlineListaCarga,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LISTACARGA,dtrwPe.dtDeadlineListaCarga.AddMinutes(-m_dMinutesBeforeShowListaCarga),dtrwPe.dtDeadlineListaCarga,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineListaCarga)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineListaCarga;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineListaCarga.AddMinutes(-m_dMinutesBeforeShowListaCarga);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Espelho BL
						if (!dtrwPe.IsdtDeadLineEspelhoBLNull() && (dtrwPe.dtDeadLineEspelhoBL != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseEspelhoBL,dtrwPe.dtDeadLineEspelhoBL,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ESPELHOBL,dtrwPe.dtDeadLineEspelhoBL.AddMinutes(-m_dMinutesBeforeShowEspelhoBL),dtrwPe.dtDeadLineEspelhoBL,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);						
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadLineEspelhoBL)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadLineEspelhoBL;
									dtrwMessage.dtShow = dtrwPe.dtDeadLineEspelhoBL.AddMinutes(-m_dMinutesBeforeShowEspelhoBL);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Retirada Container Terminal
						if (!dtrwPe.IsdtDeadlineRetiradaContainerTerminalNull() && (dtrwPe.dtDeadlineRetiradaContainerTerminal != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseRetiradaContainerTerminal,dtrwPe.dtDeadlineRetiradaContainerTerminal,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_RETIRADACONTAINERTERMINAL,dtrwPe.dtDeadlineRetiradaContainerTerminal.AddMinutes(-m_dMinutesBeforeShowRetiradaContainerTerminal),dtrwPe.dtDeadlineRetiradaContainerTerminal,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineRetiradaContainerTerminal)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineRetiradaContainerTerminal;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineRetiradaContainerTerminal.AddMinutes(-m_dMinutesBeforeShowRetiradaContainerTerminal);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Abertura Portao
						if (!dtrwPe.IsdtAberturaPortaoNull() && (dtrwPe.dtAberturaPortao != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseAberturaPortao,dtrwPe.dtAberturaPortao,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_ABERTURAPORTAO,dtrwPe.dtAberturaPortao.AddMinutes(-m_dMinutesBeforeShowAberturaPortao),dtrwPe.dtAberturaPortao,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtAberturaPortao)
								{
									dtrwMessage.dtEvent = dtrwPe.dtAberturaPortao;
									dtrwMessage.dtShow = dtrwPe.dtAberturaPortao.AddMinutes(-m_dMinutesBeforeShowAberturaPortao);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Fechamento Portao
						if (!dtrwPe.IsdtDeadlineFechamentoPortaoNull() && (dtrwPe.dtDeadlineFechamentoPortao != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseFechamentoPortao,dtrwPe.dtDeadlineFechamentoPortao,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_FECHAMENTOPORTAO,dtrwPe.dtDeadlineFechamentoPortao.AddMinutes(-m_dMinutesBeforeShowFechamentoPortao),dtrwPe.dtDeadlineFechamentoPortao,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineFechamentoPortao)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineFechamentoPortao;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineFechamentoPortao.AddMinutes(-m_dMinutesBeforeShowFechamentoPortao);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Liberacao Receita Federal
						if (!dtrwPe.IsdtDeadlineLiberacaoRFNull() && (dtrwPe.dtDeadlineLiberacaoRF != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseLiberacaoRF,dtrwPe.dtDeadlineLiberacaoRF,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_LIBERACAORECEITAFEDERAL,dtrwPe.dtDeadlineLiberacaoRF.AddMinutes(-m_dMinutesBeforeShowLiberacaoRF),dtrwPe.dtDeadlineLiberacaoRF,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineLiberacaoRF)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineLiberacaoRF;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineLiberacaoRF.AddMinutes(-m_dMinutesBeforeShowLiberacaoRF);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}

						// Outro
						if (!dtrwPe.IsdtDeadlineOutroNull() && (dtrwPe.dtDeadlineOutro != mdlConstantes.clsConstantes.DATANULA))
						{
							strMessage = strReturnMessageMounted(m_strMessageBaseOutro,dtrwPe.dtDeadlineOutro,dtrwPe.idExportador,dtrwPe.idPE);
							if ((dtrwMessage = mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO,dtrwPe.idExportador,dtrwPe.idPE)) == null)
							{
								typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE_SUBTYPE_OUTRO,dtrwPe.dtDeadlineOutro.AddMinutes(-m_dMinutesBeforeShowOutro),dtrwPe.dtDeadlineOutro,true,false,strMessage,dtrwPe.idExportador,dtrwPe.idPE);							
							}else{
								if (dtrwMessage.dtEvent != dtrwPe.dtDeadlineOutro)
								{
									dtrwMessage.dtEvent = dtrwPe.dtDeadlineOutro;
									dtrwMessage.dtShow = dtrwPe.dtDeadlineOutro.AddMinutes(-m_dMinutesBeforeShowOutro);
									dtrwMessage.mstrMessage = strMessage;
									dtrwMessage.bDeleted = false;
								}
							}
						}
					}
					// Removing Messages
					foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessageCurrent in typDatSetMensagens.tbMensagens.Rows)
					{
						if ((dtrwMessageCurrent.RowState != System.Data.DataRowState.Deleted) && (!dtrwMessageCurrent.bDeleted) && (dtrwMessageCurrent.nIdMessageType == mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE))
							if (typDatSetPes.tbPEs.FindByidExportadoridPE(dtrwMessageCurrent.nIdExportador,dtrwMessageCurrent.strIdPe) == null)
								dtrwMessageCurrent.Delete();
					}

					m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
					if (m_cls_dba_ConnectionDB.Erro == null)
					{
						return(true);
					}else{
						return(bSyncronizeMessages(nTrys - 1));
					}
				}else{
					return(false);
				}
			}
		#endregion

		#region Load Messages
			public bool bLoadMessages()
			{
				mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens = null;
				return(bLoadMessages(out typDatSetMensagens,true,false));
			}
			private bool bLoadMessages(out mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens,bool bReloadMessages,bool bIncludeDeleted)
			{
				bool bReturn = true;
				if (bReloadMessages)
					vClear();
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdMessageType");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE);
				if (!bIncludeDeleted)
				{
					arlCondicaoCampo.Add("bDeleted");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(0);
				}
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				typDatSetMensagens = m_cls_dba_ConnectionDB.GetTbMensagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (bReloadMessages)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMensagen in typDatSetMensagens.tbMensagens.Rows)
					{
						if (!bAdd(dtrwMensagen.nIdMessage,dtrwMensagen.dtEvent,dtrwMensagen.dtShow,dtrwMensagen.mstrMessage,dtrwMensagen.bShow,dtrwMensagen.nIdMessageSubType,dtrwMensagen.nIdExportador,dtrwMensagen.strIdPe))
							bReturn = false;
					}
				}
				return(bReturn);
			}
		#endregion
		#region Save Messages
			public bool bSaveMessage(int nIdMessage)
			{
				return(bSaveMessage(nIdMessage,m_nDefaultSaveTrys));
			}

			private bool bSaveMessage(int nIdMessage,int nTrysLeft)
			{
				bool bReturn = false;
				if (nTrysLeft == 0)
					return(false);

				mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens = null;
				bLoadMessages(out typDatSetMensagens,false,false);
				clsMessage objMessage = Message_Copy(nIdMessage);

				if (objMessage.Deleted)
				{
					// DELETE
					mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage = typDatSetMensagens.tbMensagens.FindBynIdMessagenIdMessageType(nIdMessage,mdlConstantes.clsConstantes.ID_SCHEDULER_DEADLINE);
					if (dtrwMessage != null)
					{
						dtrwMessage.bDeleted = true;
						m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
						if (m_cls_dba_ConnectionDB.Erro != null)
							return(bSaveMessage(nTrysLeft - 1));
						else
							return(true);
					}else{
						return(true);
					}
				}else{
					bReturn = true;
				}
				if (bReturn == false)
					return(bSaveMessage(nTrysLeft - 1));
				else
					return(true);
			}
		#endregion
	}
}
