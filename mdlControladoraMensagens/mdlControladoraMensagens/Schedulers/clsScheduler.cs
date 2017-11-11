using System;

namespace mdlControladoraMensagens
{
	/// <summary>
	/// Summary description for clsScheduler.
	/// </summary>
	public class clsScheduler
	{
		#region Atributes
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			protected string m_strEnderecoExecutavel = "";
			private System.Collections.ArrayList m_arlMessages = new System.Collections.ArrayList();
			private int m_nIdLastMessageAdded = -1;
			protected int m_nIdLastMessageUpdated = -1;
			private bool m_bEnabled = false;
			private bool m_bPaused = false;
			protected int m_nDefaultSaveTrys = 3;
			protected int m_nDefaultSyncronizeTrys = 3;
			private string m_strName;
		#endregion
		#region Properties
			public bool Enabled
			{
				get
				{
					return(m_bEnabled);
				}
				set
				{
					m_bEnabled = value;
				}
			}

			public bool Paused
			{
				get
				{
					return(m_bPaused);
				}
				set
				{
					m_bPaused = value;
				}
			}

			public string Name
			{
				get
				{
					return(m_strName);
				}
			}

			public int LastMessageAdded
			{
				get
				{
					return(m_nIdLastMessageAdded);
				}
			}

			public int LastMessageUpdated
			{
				get
				{
					return(m_nIdLastMessageUpdated);
				}
			}

		#endregion
		#region Constructors and Destructors
			protected clsScheduler(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref string strEnderecoExecutavel,string strName)
			{
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_strName = strName;
			}
		#endregion

		#region Clear
			protected void vClear()
			{
				if (m_bEnabled)
					m_arlMessages.Clear();
			}
		#endregion
		#region Contains
			protected bool bContains(clsMessage objMessage)
			{
				if (m_bEnabled)
				{
					for(int i = 0; i < m_arlMessages.Count;i++)
					{
						clsMessage curMessage = (clsMessage)m_arlMessages[i];
						if ((objMessage.DateEvent == curMessage.DateEvent) && (objMessage.Message == curMessage.Message)) 
							return(true);
					}
				}
				return(false);
			}
		#endregion
		#region Add
			protected int nNextId()
			{
				int nReturn = 1;
				bool bExist = true;
				while (bExist)
				{
					bExist = false;
					for(int i = 0; i < m_arlMessages.Count;i++)
					{
						if (((clsMessage)m_arlMessages[i]).Id == nReturn)
						{
							bExist = true;
							nReturn++;
							break;
						}
					}
				}
				return(nReturn);
			}

			protected int nNextId(ref mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens)
			{
				int nReturn = 1;
				bool bExist = true;
				while (bExist)
				{
					bExist = false;
					foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMensagem in typDatSetMensagens.tbMensagens.Rows)
					{
						if (bExist = (dtrwMensagem.nIdMessage == nReturn))
						{
							nReturn++;
							break;
						}
					}
				}
				return(nReturn);
			}

			protected bool bReIdMessage(ref int nIdMessage)
			{
				int nReturn = 1;
				bool bExist = true;
				clsMessage objMessage = null;
				while (bExist)
				{
					bExist = false;
					for(int i = 0; i < m_arlMessages.Count;i++)
					{
						if ((objMessage == null) && (((clsMessage)m_arlMessages[i]).Id == nIdMessage))
							objMessage = (clsMessage)m_arlMessages[i];
						if (((clsMessage)m_arlMessages[i]).Id == nReturn)
						{
							bExist = true;
							nReturn++;
							break;
						}
					}
				}
				if (objMessage != null)
				{
					nIdMessage = objMessage.Id = nReturn;
					return(true);
				}else{
					return(false);
				}
			}

			public bool bAdd(int nIdMessage,System.DateTime dtEvent,System.DateTime dtShow,string strMessage,bool bShow,int nIdSubType,int nIdExportador,string strIdPe)
			{
				if ((m_bEnabled) && (mesReturn(nIdMessage)) == null)
				{
					clsScheduler objScheduler = this;
					clsMessage objMessage = new clsMessage(ref objScheduler,dtEvent,dtShow,strMessage);
					m_arlMessages.Add(objMessage);
					objMessage.Id = nIdMessage;
					objMessage.SubType = nIdSubType;
					objMessage.Exportador = nIdExportador;
					objMessage.PE = strIdPe;
					return(true);
				}
				return(false);
			}

			public bool bAdd(int nIdMessage,System.DateTime dtEvent,System.DateTime dtShow,string strMessage,bool bShow)
			{
				if ((m_bEnabled) && (mesReturn(nIdMessage)) == null)
				{
					clsScheduler objScheduler = this;
					clsMessage objMessage = new clsMessage(ref objScheduler,dtEvent,dtShow,strMessage);
					m_arlMessages.Add(objMessage);
					objMessage.Id = nIdMessage;
					return(true);
				}
				return(false);
			}

			protected bool bAdd(bool bNew,System.DateTime dtEvent,string strMessage,int nSecondsBeforeShow)
			{
				bool bReturn = false;
				if (m_bEnabled)
				{
					clsScheduler objScheduler = this;
					clsMessage objMessage = new clsMessage(ref objScheduler,dtEvent,dtEvent.AddSeconds(-nSecondsBeforeShow),strMessage);
					m_arlMessages.Add(objMessage);
					objMessage.Id = nNextId();
					objMessage.Inserted = bNew;
					m_nIdLastMessageAdded = objMessage.Id;
					bReturn = true;
				}
				return(bReturn);
			}

			protected bool bAdd(bool bNew,System.DateTime dtEvent,bool bShow,System.DateTime dtShow,string strMessage)
			{
				bool bReturn = false;
				if (m_bEnabled)
				{
					clsScheduler objScheduler = this;
					clsMessage objMessage = new clsMessage(ref objScheduler,dtEvent,dtShow,strMessage);
					objMessage.Show = bShow;
					m_arlMessages.Add(objMessage);
					objMessage.Id = nNextId();
					objMessage.Inserted = bNew;
					m_nIdLastMessageAdded = objMessage.Id;
					bReturn = true;
				}
				return(bReturn);
			}
		#endregion
		#region Delete
			public virtual bool bMessage_Delete(int nIdMessage)
			{
				bool bReturn = false;
				if (m_bEnabled)
				{
					clsMessage objMessage = mesReturn(nIdMessage);
					if (bReturn = (objMessage != null))
						objMessage.Deleted = true;
				}
				return(bReturn);
			}

			public virtual bool bMessage_Remove(int nIdMessage)
			{
				bool bReturn = false;
				if (m_bEnabled)
				{
					for(int i = 0; i < m_arlMessages.Count;i++)
					{
						clsMessage objMessage = (clsMessage)m_arlMessages[i];
						if (bReturn = (objMessage.Id == nIdMessage))
						{
							m_arlMessages.RemoveAt(i);
							break;
						}
					}
				}
				return(bReturn);
			}
		#endregion

		#region Messages
			protected clsMessage mesReturn(int nIdMessage)
			{
				for(int i = 0; i < m_arlMessages.Count;i++)
					if (((clsMessage)m_arlMessages[i]).Id == nIdMessage)
						return((clsMessage)m_arlMessages[i]);
				return(null);
			}

			protected clsMessage mesReturn(int nIdSubType,int nIdExportador,string idPe)
			{
				for(int i = 0; i < m_arlMessages.Count;i++)
				{
					clsMessage objMessage = (clsMessage)m_arlMessages[i];
					if ((objMessage.SubType == nIdSubType) && (objMessage.Exportador == nIdExportador) && (objMessage.PE == idPe))
						return(objMessage); 
				}
				return(null);
			}

			protected clsMessage mesReturn(int nIdSubType,string strContratoCambio)
			{
				for(int i = 0; i < m_arlMessages.Count;i++)
				{
					clsMessage objMessage = (clsMessage)m_arlMessages[i];
					if ((objMessage.SubType == nIdSubType) && (objMessage.ContratoCambio == strContratoCambio))
						return(objMessage); 
				}
				return(null);
			}

			protected mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow mesReturn(ref mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMessages,int nIdSubType,int nIdExportador,string idPe)
			{
				foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage in typDatSetMessages.tbMensagens.Rows)
					if ((dtrwMessage.RowState != System.Data.DataRowState.Deleted) && (dtrwMessage.nIdMessageSubType == nIdSubType) && (dtrwMessage.nIdExportador == nIdExportador) && (dtrwMessage.strIdPe == idPe))
						return(dtrwMessage);
				return(null);
			}

			protected mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow mesReturn(ref mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMessages,int nIdSubType,string strNumeroContratoCambio)
			{
				foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage in typDatSetMessages.tbMensagens.Rows)
					if ((dtrwMessage.RowState != System.Data.DataRowState.Deleted) && (dtrwMessage.nIdMessageSubType == nIdSubType) && (dtrwMessage.strIdPe == strNumeroContratoCambio))
						return(dtrwMessage);
				return(null);
			}

			public clsMessage[] msgHasMessagesToShow()
			{
				return(msgHasMessagesToShow(System.DateTime.Now));
			}

			public clsMessage[] msgHasMessagesToShow(System.DateTime dtDate)
			{
				clsMessage[] msgsReturn = null;

				if ((m_bEnabled) && (!m_bPaused))
				{
					// Ordering
					System.Collections.SortedList sorListMessages = new System.Collections.SortedList();
					for(int i = 0;i < m_arlMessages.Count;i++)
					{
						clsMessage currMessage = (clsMessage)m_arlMessages[i];
						if ((currMessage.Show) && (!currMessage.Deleted))
						{
							double dSeconds = (currMessage.DateShow.Subtract(dtDate)).TotalSeconds;
							if ((dSeconds > 0) && (currMessage.Show))
								continue;
							string strDate = currMessage.DateShow.ToString("ddMMyyyyHHmmss");
							while (sorListMessages.ContainsKey(strDate))
								strDate += "x";
							sorListMessages.Add(strDate,currMessage);
						}
					}
					// Inserting
					msgsReturn = new clsMessage[sorListMessages.Count];
					for(int i = 0; i < sorListMessages.Count;i++)
						msgsReturn[i] = (clsMessage)sorListMessages.GetByIndex(i);
				}
				return(msgsReturn);
			}

			public clsMessage msgHasNextMessageToShow()
			{
				return(msgHasNextMessageToShow(System.DateTime.Now));
			} 

			public clsMessage msgHasNextMessageToShow(System.DateTime dtDate)
			{
				clsMessage[] msgsReturn = msgHasMessagesToShow(dtDate);
				clsMessage msgReturn = null;
				if ((msgsReturn != null) && (msgsReturn.Length > 0))
					msgReturn = msgsReturn[0];  
				return(msgReturn);
			} 

			public void vMessageDateShowedAdd(int nIdMessage,System.DateTime dtDate)
			{
				if (m_bEnabled)
				{
					clsMessage objMessage = mesReturn(nIdMessage);
					if (objMessage != null)
						objMessage.bShowedDateAdd(dtDate);
				}
			}

			public void vMessageRemarkNextShow(int nIdMessage,double dMinutesToAdd)
			{
				if (m_bEnabled)
				{
					clsMessage objMessage = mesReturn(nIdMessage);
					if (objMessage != null)
						objMessage.vRemarkNextShow(dMinutesToAdd);
				}
			}

			public void vDontShowAgainMessage(int nIdMessage)
			{
				if (m_bEnabled)
				{
					clsMessage objMessage = mesReturn(nIdMessage);
					if (objMessage != null)
						objMessage.Show = false;
				}
			}

			public int nMessages_Count()
			{
				if (m_bEnabled)
					return(m_arlMessages.Count);
				else
					return(-1);
			}

			public clsMessage Message_Copy(int nIdMessage)
			{
				if (m_bEnabled)
				{
					clsMessage objMessage = mesReturn(nIdMessage);
					if (objMessage != null)
						return(objMessage.Copy());
					else
						return(null);
				}else{
					return(null);
				}
			}

			public clsMessage Message_CopyByIndex(int nIndex)
			{
				if (m_bEnabled)
				{
					if ((m_arlMessages.Count > nIndex) && (nIndex >= 0))
						return(((clsMessage)m_arlMessages[nIndex]));
					else
						return(null);
				}
				else
				{
					return(null);
				}
			}
		#endregion
		#region MessagesState
			public void vMessageNotInserted(int nIdMessage)
			{
				clsMessage objMessage = mesReturn(nIdMessage);
				if (objMessage != null)
					objMessage.Inserted = false;
			}

			public void vMessageNotUpdated(int nIdMessage)
			{
				clsMessage objMessage = mesReturn(nIdMessage);
				if (objMessage != null)
					objMessage.Updated = false;
			}

			public void vMessageNotDeleted(int nIdMessage)
			{
				clsMessage objMessage = mesReturn(nIdMessage);
				if (objMessage != null)
					objMessage.Deleted = false;
			}
		#endregion
		#region MessageBase
			protected string strReturnMessageMounted(string strMessageBase,System.DateTime dtDeadline,int nIdExportador,string strIdPe)
			{
				return(strReturnMessageMounted(strMessageBase,dtDeadline,nIdExportador,strIdPe,""));
			}

			protected string strReturnMessageMounted(string strMessageBase,System.DateTime dtDeadline,string strNumeroContratoCambio,int nIdExportador)
			{
				return(strReturnMessageMounted(strMessageBase,dtDeadline,nIdExportador,"",strNumeroContratoCambio));
			}

			protected string strReturnMessageMounted(string strMessageBase,System.DateTime dtDeadline,int nIdExportador,string strIdPe,string strNumeroContratoCambio)
			{
				string strReturn = strMessageBase;
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_DIA,dtDeadline.ToString("dd"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_MES,dtDeadline.ToString("MM"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_ANO,dtDeadline.ToString("yyyy"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_HORA,dtDeadline.ToString("HH"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_MINUTO,dtDeadline.ToString("mm"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_DATA_SEGUNDO,dtDeadline.ToString("ss"));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_EXPORTADOR_NOME,strReturnMessageMountedExportador(nIdExportador));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_PROCESSO_NUMERO,strIdPe);
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_PROCESSO_NAVIO,strReturnMessageMountedNavio(nIdExportador,strIdPe));
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_CONTRATOCAMBIO_NUMERO,strNumeroContratoCambio);
				strReturn = strReturn.Replace(clsControladoraMensagens.TAG_OUTRO_DEADLINE,strReturnMessageMountedDeadlineOutro(nIdExportador,strIdPe));
				return(strReturn);
			}
			
			private string strReturnMessageMountedExportador(int nIdExportador)
			{
				if (!mdlPreferencias.clsConfigurations.bRegistroPrestadorServico(ref m_cls_dba_ConnectionDB))
					return("");
				int nTemp;
				string strTemp,strReturn;
				mdlTratamentoErro.clsTratamentoErro cls_ter_Current = new mdlTratamentoErro.clsTratamentoErro();
				System.Windows.Forms.Form objForm = null;
				mdlContas.clsContas obj = new mdlContas.clsContas(ref cls_ter_Current,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref objForm,nIdExportador);
				obj.retornaValores(out strTemp,out strReturn,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out nTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp,out strTemp);
				if (strReturn != "")
					strReturn += " / ";
				return(strReturn);
			}

			private string strReturnMessageMountedNavio(int nIdExportador,string strIdPe)
			{
				mdlTratamentoErro.clsTratamentoErro cls_ter_Current = new mdlTratamentoErro.clsTratamentoErro();
				mdlArmadores.clsArmador cls_ar_current = new mdlArmadores.clsArmador(ref cls_ter_Current,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,nIdExportador,strIdPe);
				string strTemp,strReturn;
				cls_ar_current.vRetornaValores(out strTemp,out strReturn);
				return(strReturn);
			}

			private string strReturnMessageMountedDeadlineOutro(int nIdExportador,string strIdPe)
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("idExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(nIdExportador);
				arlCondicaoCampo.Add("idPE");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strIdPe);

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbPes typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (typDatSetPes.tbPEs.Rows.Count > 0)
				{
					mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow dtrwProcesso = (mdlDataBaseAccess.Tabelas.XsdTbPes.tbPEsRow)typDatSetPes.tbPEs.Rows[0];
					if (!dtrwProcesso.IsstrDeadlineOutroNull())
						return(dtrwProcesso.strDeadlineOutro);
					else
						return("");
				}else{
					return("");
				}
			}
		#endregion
	}
}
