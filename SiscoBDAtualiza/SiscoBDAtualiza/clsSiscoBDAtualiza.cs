using System;

namespace SiscoBDAtualiza
{
	/// <summary>
	/// Summary description for clsSiscoBDAtualiza.
	/// </summary>
	public class clsSiscoBDAtualiza
	{
		#region Constantes
		#endregion
		#region Atributos
			private string m_strEnderecoExecutavel = System.Environment.CurrentDirectory + "\\";
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = new mdlTratamentoErro.clsTratamentoErro();
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private frmFSiscoBDAtualiza m_formFSiscoDBAtualiza = null;
		#endregion
		#region Constructors 
			public clsSiscoBDAtualiza()
			{
			}
		#endregion

		#region ShowDialog
		public bool ShowDialog()
		{
			if (GetDataBase() != null)
			{
				m_formFSiscoDBAtualiza = new frmFSiscoBDAtualiza();
				InitializeEvents(m_formFSiscoDBAtualiza);
				m_formFSiscoDBAtualiza.ShowDialog();
				return(true);
			}
			return(false);
		}

		private void InitializeEvents(frmFSiscoBDAtualiza formFSiscoDBAtualiza)
		{
			formFSiscoDBAtualiza.eCallStart += new SiscoBDAtualiza.frmFSiscoBDAtualiza.delCallStart(DBAtualizaStart);

		}
		#endregion

		#region BaseDados
			private mdlDataBaseAccess.clsDataBaseAccess GetDataBase()
			{
				mdlDataBaseConfig.clsDataBaseConfig config = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_strEnderecoExecutavel);
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
				//Clear
				cls_dba_ConnectionDB.eCallDBUpdateInfoClear += new mdlDataBaseAccess.clsDataBaseAccess.delCallDBUpdateInfoClear(DBUpdateInformacoesClear);

				//Insert
				cls_dba_ConnectionDB.eCallDBUpdateInfoInsert += new mdlDataBaseAccess.clsDataBaseAccess.delCallDBUpdateInfoInsert(DBUpdateInformacoesInsert);
			}
		#endregion

		#region Informacoes
			private void DBUpdateInformacoesClear()
			{
				if (m_formFSiscoDBAtualiza != null)
					m_formFSiscoDBAtualiza.Informacoes.Clear();
			}

			private void DBUpdateInformacoesInsert(string text)
			{
				if (m_formFSiscoDBAtualiza != null)
					m_formFSiscoDBAtualiza.Informacoes.AppendText(text + System.Environment.NewLine);
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
