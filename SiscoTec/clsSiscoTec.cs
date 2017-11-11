using System;

namespace SiscoTec
{
	/// <summary>
	/// Summary description for clsSiscoTec.
	/// </summary>
	public class clsSiscoTec
	{
		#region Constantes
		#endregion
		#region Atributos
		private string m_strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = new mdlTratamentoErro.clsTratamentoErro();
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
		#endregion
		#region Constructors 
		public clsSiscoTec()
		{
		}
		#endregion

		#region ShowDialog
		public bool ShowDialog()
		{
			try
			{
				vInitializeProxy();
				GetDataBase();
				mdlTec.clsTec tec = new mdlTec.clsTec(m_cls_dba_ConnectionDB,m_strEnderecoExecutavel);
				tec.ShowDialog();
				return(true);
			}catch(System.Exception e){
				mdlMensagens.clsMensagens.ShowError(e.ToString());
			}
			return(false);
		}
		#endregion

		#region Proxy
			private void vInitializeProxy()
			{
				mdlInet.clsProxy cls_Proxy = new mdlInet.clsProxy(m_strEnderecoExecutavel);
				cls_Proxy.vSetProxy();
			}
		#endregion
		#region BaseDados
		private mdlDataBaseAccess.clsDataBaseAccess GetDataBase()
		{
			mdlDataBaseConfig.clsDataBaseConfig config = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
			if (!config.bDataBaseConfiguratedRight())
				return(null);
			config.ReturnDataBaseAccess(out m_cls_dba_ConnectionDB);
			if (m_cls_dba_ConnectionDB != null)
			{
				m_cls_dba_ConnectionDB.ShowDialogsErrors = false;
				m_cls_dba_ConnectionDB.SystemMode = mdlDataBaseAccess.Mode.Developer;
				InitializeEvents(m_cls_dba_ConnectionDB);
			}
			return(m_cls_dba_ConnectionDB);
		}	

		private void InitializeEvents(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB)
		{
		}
		#endregion

		#region Start
		private bool DBAtualizaStart()
		{
			System.Threading.Thread threadUpdate = new System.Threading.Thread(new System.Threading.ThreadStart(Start));
			threadUpdate.Start();
			return(true);
		}

		private void Start()
		{
			m_cls_dba_ConnectionDB.nUpdateDataBase();
		}	
		#endregion
	}
}
