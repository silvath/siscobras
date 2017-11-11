using System;

namespace mdlControladoraMensagens
{
	/// <summary>
	/// Summary description for clsSchedulerContratosCambio.
	/// </summary>
	public class clsSchedulerContratosCambio : clsScheduler
	{
		#region Atributes
			private double m_dMinutesBeforeShowACCVencimento = 10080d;
			private double m_dMinutesBeforeShowACEVencimento = 10080d;
			private double m_dMinutesBeforeShowComumVencimento = 10080d;

			private string  m_strMessageBaseACCVencimento = "ACC [CONTRATOCAMBIO] vencerá em [DIA]/[MES]/[ANO]";
			private string  m_strMessageBaseACEVencimento = "ACE [CONTRATOCAMBIO] vencerá em [DIA]/[MES]/[ANO]";
			private string  m_strMessageBaseComumVencimento = "Contrato de Câmbio sem adiantamento [CONTRATOCAMBIO]: Vencendo a data de validação no dia [DIA]/[MES]/[ANO]";
		#endregion
		#region Properties	
			public string MessageBaseACCVencimento
			{
				set
				{
					m_strMessageBaseACCVencimento = value;
				}
				get
				{
					return(m_strMessageBaseACCVencimento);
				}
			}

			public string MessageBaseACEVencimento
			{
				set
				{
					m_strMessageBaseACEVencimento = value;
				}
				get
				{
					return(m_strMessageBaseACEVencimento);
				}
			}

			public string MessageBaseComumVencimento
			{
				set
				{
					m_strMessageBaseComumVencimento = value;
				}
				get
				{
					return(m_strMessageBaseComumVencimento);
				}
			}

			public double MinutesBeforeACCVencimento
			{
				set
				{
					m_dMinutesBeforeShowACCVencimento = value;
				}
				get
				{
					return(m_dMinutesBeforeShowACCVencimento);
				}
			}

			public double MinutesBeforeACEVencimento
			{
				set
				{
					m_dMinutesBeforeShowACEVencimento = value;
				}
				get
				{
					return(m_dMinutesBeforeShowACEVencimento);
				}
			}

			public double MinutesBeforeComumVencimento
			{
				set
				{
					m_dMinutesBeforeShowComumVencimento = value;
				}
				get
				{
					return(m_dMinutesBeforeShowComumVencimento);
				}
			}
		#endregion	
		#region Constructors and Destructors
		public clsSchedulerContratosCambio(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref string strEnderecoExecutavel) : base (ref cls_dba_ConnectionDB,ref strEnderecoExecutavel,clsControladoraMensagens.SCHEDULER_CONTRATOCAMBIO_NAME)
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
				mdlDataBaseAccess.Tabelas.XsdTbContratosCambio typDatSetContratosCambio = m_cls_dba_ConnectionDB.GetTbContratosCambio(null,null,null,null,null);
				m_cls_dba_ConnectionDB.ShowDialogsErrors = bShowDialogErrors;
				string strMessage = "";
				double dMinutes = 0;
				mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro = new mdlTratamentoErro.clsTratamentoErro();
				cls_ter_TratadorErro.ConnectionDB = m_cls_dba_ConnectionDB;
				// Inserting new Messages
				foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambio in typDatSetContratosCambio.tbContratosCambio.Rows)
				{
					if (!dtrwContratoCambio.IsnTipoContratacaoNull())
					{
						switch(dtrwContratoCambio.nTipoContratacao)
						{
							case mdlConstantes.clsConstantes.ID_CONTRATOCAMBIO_ACC:
								// ACC Data Vencimento
								if (!dtrwContratoCambio.IsdtVencimentoNull() && (dtrwContratoCambio.dtVencimento != mdlConstantes.clsConstantes.DATANULA))
								{
									dMinutes = System.DateTime.Now.Subtract(dtrwContratoCambio.dtVencimento).TotalMinutes;
									if (dMinutes <= m_dMinutesBeforeShowACCVencimento)
									{
										if ((mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC,dtrwContratoCambio.strNumero)) == null)
										{
											if (bContratoCambioPossuiSaldo(dtrwContratoCambio.nIdExportador,dtrwContratoCambio.nIdContratoCambio))
											{
												strMessage = strReturnMessageMounted(m_strMessageBaseACCVencimento,dtrwContratoCambio.dtVencimento,dtrwContratoCambio.strNumero,dtrwContratoCambio.nIdExportador);
												typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO,mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC,dtrwContratoCambio.dtVencimento.AddMinutes(-m_dMinutesBeforeShowACCVencimento),dtrwContratoCambio.dtVencimento,true,false,strMessage,dtrwContratoCambio.nIdExportador,dtrwContratoCambio.strNumero);
											}
										}
									}
								}
								break;
							case mdlConstantes.clsConstantes.ID_CONTRATOCAMBIO_ACE:
								// ACE Data Vencimento
								if (!dtrwContratoCambio.IsdtVencimentoNull() && (dtrwContratoCambio.dtVencimento != mdlConstantes.clsConstantes.DATANULA))
								{
									dMinutes = System.DateTime.Now.Subtract(dtrwContratoCambio.dtVencimento).TotalMinutes;
									if (dMinutes <= m_dMinutesBeforeShowACEVencimento)
									{
										if ((mesReturn(ref typDatSetMensagens,mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC,dtrwContratoCambio.strNumero)) == null)
										{
											if (bContratoCambioPossuiSaldo(dtrwContratoCambio.nIdExportador,dtrwContratoCambio.nIdContratoCambio))
											{
												strMessage = strReturnMessageMounted(m_strMessageBaseACEVencimento,dtrwContratoCambio.dtVencimento,dtrwContratoCambio.strNumero,dtrwContratoCambio.nIdExportador);
												typDatSetMensagens.tbMensagens.AddtbMensagensRow(nNextId(ref typDatSetMensagens),mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO,mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO_SUBTYPE_ACC,dtrwContratoCambio.dtVencimento.AddMinutes(-m_dMinutesBeforeShowACCVencimento),dtrwContratoCambio.dtVencimento,true,false,strMessage,dtrwContratoCambio.nIdExportador,dtrwContratoCambio.strNumero);
											}
										}
									}
								}
								break;
						}
					}
				}
				// Removing Messages
				foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessageCurrent in typDatSetMensagens.tbMensagens.Rows)
				{
					if ((dtrwMessageCurrent.RowState != System.Data.DataRowState.Deleted) && (!dtrwMessageCurrent.bDeleted) && (dtrwMessageCurrent.nIdMessageType == mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO))
					{
						bool bExiste = false;
						foreach(mdlDataBaseAccess.Tabelas.XsdTbContratosCambio.tbContratosCambioRow dtrwContratoCambioCurrent in typDatSetContratosCambio.tbContratosCambio.Rows)
						{
							if ((dtrwContratoCambioCurrent.RowState != System.Data.DataRowState.Deleted) && (!dtrwContratoCambioCurrent.IsstrNumeroNull()) && (dtrwContratoCambioCurrent.strNumero == dtrwMessageCurrent.strIdPe))
							{
								bExiste = true;
								break;
							}
						}
						if (!bExiste)
							dtrwMessageCurrent.Delete();
					}
				}

				m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
				if (m_cls_dba_ConnectionDB.Erro == null)
				{
					return(true);
				}
				else
				{
					return(bSyncronizeMessages(nTrys - 1));
				}
			}
			else
			{
				return(false);
			}
		}

		private bool bContratoCambioPossuiSaldo(int nIdExportador,int nIdContratoCambio)
		{
			mdlTratamentoErro.clsTratamentoErro cls_ter_Current = new mdlTratamentoErro.clsTratamentoErro();
			mdlContratoCambio.clsContratoCambio cls_cc_Current = new mdlContratoCambio.clsContratoCambio(ref cls_ter_Current,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador);
			return(cls_cc_Current.dSaldoContratoCambio(nIdContratoCambio) > 0);
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
			arlCondicaoValor.Add(mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO);
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
				mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage = typDatSetMensagens.tbMensagens.FindBynIdMessagenIdMessageType(nIdMessage,mdlConstantes.clsConstantes.ID_SCHEDULER_CONTRATOCAMBIO);
				if (dtrwMessage != null)
				{
					dtrwMessage.bDeleted = true;
					m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
					if (m_cls_dba_ConnectionDB.Erro != null)
						return(bSaveMessage(nTrysLeft - 1));
					else
						return(true);
				}
				else
				{
					return(true);
				}
			}
			else
			{
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
