using System;

namespace mdlBackup
{
	/// <summary>
	/// Summary description for clsBackupRestore.
	/// </summary>
	public class clsBackupRestore
	{
		#region Atributes
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		private bool m_bRestored = false;
		#endregion
		#region Properties
			public bool Restored
			{
				get
				{
					return(m_bRestored);
				}
			}
		#endregion
		#region Constructors
		public clsBackupRestore(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConectionDB, string strEnderecoExecutavel)
		{
			m_cls_dba_ConectionDB = cls_dba_ConectionDB;
			m_cls_ter_tratadorErro = cls_ter_tratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				frmFBackupRestore formFRestore = new frmFBackupRestore();
				formFRestore.eRestoreBackup += new mdlBackup.frmFBackupRestore.delRestoreBackup(formFRestore_eRestoreBackup);
				formFRestore.ShowDialog();
				return(m_bRestored);
			}
		#endregion

		#region Restore
		private bool formFRestore_eRestoreBackup(string strPath)
		{
			//Checking if the file exists
			if (!System.IO.File.Exists(strPath))
			{
				mdlMensagens.clsMensagens.ShowInformation("Você deve escolher um caminho válido para o arquivo a ser restaurado.");
				return(false);
			}
			string strPathOnly = strPath.Substring(0,strPath.LastIndexOf("\\") + 1);
			string strFileName = strPath.Substring(strPath.LastIndexOf("\\") + 1);

			//Restoring the Backup
			clsBackup objBackup = new clsBackup(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConectionDB,m_strEnderecoExecutavel,strPathOnly,strFileName);
			if (objBackup.bRestauraBackup())
			{
				mdlMensagens.clsMensagens.ShowInformation("Restauração realizada com Sucesso.");
				return(true);
			}else{
				mdlMensagens.clsMensagens.ShowInformation("Ocorreram problemas ao realizar a restauração.");
				return(false);
			}
		}
		#endregion
	}
}
