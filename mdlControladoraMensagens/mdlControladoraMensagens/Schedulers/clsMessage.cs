using System;

namespace mdlControladoraMensagens
{
	/// <summary>
	/// Summary description for clsMessage.
	/// </summary>
	public class clsMessage
	{
		#region Atributes
			private clsScheduler m_cls_sch_Control = null;
			private int m_nIdMessage = -1;
			private string m_strMessage = "";
			private System.DateTime m_dtShow;
			private System.DateTime m_dtEvent;
			private System.Collections.ArrayList m_arlShowedDates = null;
			private bool m_bShow = true;
			private bool m_bInserted = false;
			private bool m_bUpdated = false;
			private bool m_bDeleted = false;

			private int m_nIdSubType = -1;
			private int m_nIdExportador = -1;
			private string m_strIdPe = "";
			private string m_strContratoCambio = "";
		#endregion
		#region Properties
			public int Id
			{
				set
				{
					m_nIdMessage = value;
				}
				get
				{
					return(m_nIdMessage);
				}
			}
			public System.DateTime DateShow
			{
				set
				{
					if (m_dtShow != value)
					{
						m_dtShow = value;
						m_bUpdated = true; 
					}
				}
				get
				{
					return(m_dtShow);
				}
			}

			public System.DateTime DateEvent
			{
				set
				{
					if (m_dtEvent != value)
					{
						m_dtEvent = value;
						m_bUpdated = true; 
					}
				}
				get
				{
					return(m_dtEvent);
				}
			}
				
			public string Message
			{
				set
				{
					if (m_strMessage != value)
					{
						m_strMessage = value;
						m_bUpdated = true; 
					}
				}
				get
				{
					return(m_strMessage);
				}
			}

			public bool Show
			{
				get
				{
					return(m_bShow);
				}
				set
				{
					m_bShow = value;
				}
			}

			public bool Inserted
			{
				get
				{
					return(m_bInserted);
				}
				set
				{
					m_bInserted = value;
				}
			}

			public bool Updated
			{
				get
				{
					return(m_bUpdated);
				}
				set
				{
					m_bUpdated = value;
				}
			}

			public bool Deleted
			{
				get
				{
					return(m_bDeleted);
				}
				set
				{
					m_bDeleted = value;
				}
			}

			public clsScheduler Scheduler
			{
				get
				{
					return(m_cls_sch_Control);
				}
			}

			public int SubType
			{
				get
				{
					return(m_nIdSubType);
				}
				set
				{
					m_nIdSubType = value;
				}
			}

			public int Exportador
			{
				get
				{
					return(m_nIdExportador);
				}
				set
				{
					m_nIdExportador = value;
				}
			}

			public string PE
			{
				get
				{
					return(m_strIdPe);
				}
				set
				{
					m_strIdPe = value;
				}
			}

			public string ContratoCambio
			{
				get
				{
					return(m_strContratoCambio);
				}
				set
				{
					m_strContratoCambio = value;
				}
			}
		#endregion
		#region Constructors and Destructors
			public clsMessage(ref clsScheduler objScheduler,System.DateTime dtEvent,System.DateTime dtShow,string strMessage)
			{
				m_cls_sch_Control = objScheduler;
				m_dtEvent = dtEvent;
				m_dtShow = dtShow;
				m_strMessage = strMessage;
			}

			public clsMessage(ref clsScheduler cls_sch_Control,int nIdMessage,string strMessage,System.DateTime dtShow,System.DateTime dtEvent,System.Collections.ArrayList arlShowedDates,bool bShow,bool bInserted,bool bUpdated,bool bDeleted,int nIdSubType,int nIdExportador,string strIdPe,string strContratoCambio)
			{
				m_cls_sch_Control = cls_sch_Control; 
				m_nIdMessage = nIdMessage;
				m_strMessage = strMessage;
				m_dtShow = dtShow;
				m_dtEvent = dtEvent;
				m_arlShowedDates = arlShowedDates;
				m_bShow = bShow;
				m_bInserted = bInserted;
				m_bUpdated = bUpdated;
				m_bDeleted = bDeleted;

				m_nIdSubType = nIdSubType;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
				m_strContratoCambio = strContratoCambio;
			}

			public clsMessage Copy()
			{
				return(new clsMessage(ref m_cls_sch_Control,m_nIdMessage,m_strMessage,m_dtShow,m_dtEvent,m_arlShowedDates,m_bShow,m_bInserted,m_bUpdated,m_bDeleted,m_nIdSubType,m_nIdExportador,m_strIdPe,m_strContratoCambio));
			}
		#endregion

		#region ShowedDates
			public bool bShowedDateAdd(System.DateTime dtDate)
			{
				if (m_arlShowedDates == null)
					m_arlShowedDates = new System.Collections.ArrayList();
				return(m_arlShowedDates.Add(dtDate) != -1);
			}
			
			public bool bLastShow(out System.DateTime dtLastShow)
			{
				dtLastShow = new DateTime(1,1,1);
				if ((m_arlShowedDates != null) && (m_arlShowedDates.Count > 0))
				{
					dtLastShow = ((System.DateTime)m_arlShowedDates[m_arlShowedDates.Count - 1]);
					return(true);
				}
				return(false);
			}
		#endregion
		#region RemarkShow
			public void vRemarkNextShow(double dMinutesToAdd)
			{
				m_dtShow = System.DateTime.Now.AddMinutes(dMinutesToAdd);
			}
		#endregion
	}
}
