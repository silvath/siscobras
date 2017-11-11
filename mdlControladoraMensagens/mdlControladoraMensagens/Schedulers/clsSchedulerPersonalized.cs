using System;

namespace mdlControladoraMensagens
{
	/// <summary>
	/// Summary description for clsSchedulerPersonalized.
	/// </summary>
	public class clsSchedulerPersonalized : clsScheduler
	{
		#region Atributes
		#endregion
		#region Constructors and Destructors
			public clsSchedulerPersonalized(ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,ref string strEnderecoExecutavel) : base (ref cls_dba_ConnectionDB,ref strEnderecoExecutavel,clsControladoraMensagens.SCHEDULER_PERSONALIZED_NAME)
			{
			}
		#endregion

		#region Start
			public void vStart()
			{
				base.Enabled = true;
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

		#region Add
			public bool bAdd(bool bNew,System.DateTime dtEvent,System.DateTime dtShow,string strMessage,bool bShow)
			{
				return(this.bAdd(bNew,dtEvent,bShow,dtShow,strMessage));
			}
		#endregion
		#region Update
			public bool bUpdate(int nIdMessage,System.DateTime dtEvent,System.DateTime dtShow,string strMessage,bool bShow)
			{
				bool bReturn = false;
				clsMessage objMessage = null;
				if (bReturn = ((objMessage = mesReturn(nIdMessage)) != null))
				{
					objMessage.DateEvent = dtEvent;
					objMessage.DateShow = dtShow;
					objMessage.Message = strMessage;
					objMessage.Show = bShow;
					m_nIdLastMessageUpdated = nIdMessage;
				}
				return (bReturn);
			}
		#endregion
		#region Delete
			public override bool bMessage_Delete(int nIdMessage)
			{
				bool bReturn = base.bMessage_Delete (nIdMessage);
				bReturn = bSaveMessage(nIdMessage,m_nDefaultSaveTrys);
				return(bReturn);
			}
		#endregion

		#region Load Messages
			private bool bLoadMessages()
			{
				mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens = null;
				return(bLoadMessages(out typDatSetMensagens,true));
			}
			private bool bLoadMessages(out mdlDataBaseAccess.Tabelas.XsdTbMensagens typDatSetMensagens,bool bReloadMessages)
			{
				if (bReloadMessages)
					vClear();
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
				arlCondicaoCampo.Add("nIdMessageType");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED);
				typDatSetMensagens = m_cls_dba_ConnectionDB.GetTbMensagens(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				if (bReloadMessages)
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMensagen in typDatSetMensagens.tbMensagens.Rows)
						bAdd(dtrwMensagen.nIdMessage,dtrwMensagen.dtEvent,dtrwMensagen.dtShow,dtrwMensagen.mstrMessage,dtrwMensagen.bShow);
				}
				return(true);
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
				bLoadMessages(out typDatSetMensagens,false);
				clsMessage objMessage = Message_Copy(nIdMessage);
				if (objMessage == null)
					return(true);
				if (objMessage.Deleted)
				{
					// DELETE
					mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage = typDatSetMensagens.tbMensagens.FindBynIdMessagenIdMessageType(nIdMessage,mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED);
					if (dtrwMessage != null)
					{
						dtrwMessage.Delete();
						m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
						if (m_cls_dba_ConnectionDB.Erro != null)
							vMessageNotDeleted(nIdMessage);
						else
							bMessage_Remove(nIdMessage);
						return(m_cls_dba_ConnectionDB.Erro == null);
					}else{
						return(true);
					}
				}
				else if (objMessage.Updated)
				{
					// Updated
					// Hack: Make it
				}
				else if (objMessage.Inserted)
				{
					// INSERT
					mdlDataBaseAccess.Tabelas.XsdTbMensagens.tbMensagensRow dtrwMessage = typDatSetMensagens.tbMensagens.FindBynIdMessagenIdMessageType(nIdMessage,mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED);
					if (dtrwMessage == null)
					{
						dtrwMessage = typDatSetMensagens.tbMensagens.NewtbMensagensRow();
						dtrwMessage.nIdMessage = nIdMessage;
						dtrwMessage.nIdMessageType = mdlConstantes.clsConstantes.ID_SCHEDULER_PERSONALIZED;
						dtrwMessage.nIdMessageSubType = 1;
						dtrwMessage.dtEvent = objMessage.DateEvent;
						dtrwMessage.dtShow = objMessage.DateShow;
						dtrwMessage.bShow = objMessage.Show;
						dtrwMessage.mstrMessage = objMessage.Message;
						typDatSetMensagens.tbMensagens.AddtbMensagensRow(dtrwMessage);
						m_cls_dba_ConnectionDB.SetTbMensagens(typDatSetMensagens);
						if (m_cls_dba_ConnectionDB.Erro == null)
						{
							vMessageNotInserted(nIdMessage);
							return(true);
						}else{
							bReIdMessage(ref nIdMessage);
							return(bSaveMessage(nIdMessage,nTrysLeft - 1));
						}
					}else{
						bReIdMessage(ref nIdMessage);
						return(bSaveMessage(nIdMessage,nTrysLeft - 1));
					}
				}else{
					bReturn = true;
				}
			    if (bReturn == false)
					return(bSaveMessage(nIdMessage,nTrysLeft - 1));
				else
					return(true);
			}
		#endregion
	}
}
