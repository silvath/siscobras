using System;

namespace mdlBackup
{
	/// <summary>
	/// Summary description for clsBackup.
	/// </summary>
	public class clsBackup
	{
		#region Constantes
		private const string DATABACKUP = "dtDataBackup";
		private const string VERSAOBACKUPTEXTO = "strVersaoBackup";
		private const string VERSAOSISCOBRASTEXTO = "strVersaoSiscobras";
		private const string TBVERSAOBACKUPTEXTO = "tbVersaoBackup";
		private const string ARQUIVOXML = "Backup.xml";
		private const string STRCAMPOENDERECOBACKUP = "STRCAMPOENDERECOBACKUP";
		private const string STRCAMPOQUANTIDADEBACKUP = "STRCAMPOQUANTIDADEBACKUP";
		#endregion
		#region Atributos
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConectionDB = null;
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		protected string m_strEnderecoExecutavel = "";

		protected string m_strEnderecoBackup = "";
		protected string m_strArquivoBackup = "";
		protected string m_strDiretorioTemporario = "C:\\Temp\\";
		protected System.Random m_rdRandomico = new System.Random();
		protected System.DateTime m_dtDataBackup = System.DateTime.Now;
		protected string m_strVersaoSiscobras = "";
		protected string m_strVersaoBackup = "";

		private bool m_bIncluirModulos = true;
		#endregion
		#region Properties
			public bool IncluirModulos
			{
				set
				{
					m_bIncluirModulos = value;
				}
				get
				{
					return(m_bIncluirModulos);
				}
			}
		#endregion

		#region Construtores & Destrutores
			public clsBackup(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConectionDB, string strEnderecoExecutavel, string strEnderecoBackup, string strArquivoBackup)
			{
				m_cls_dba_ConectionDB = cls_dba_ConectionDB;
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_strEnderecoBackup = strEnderecoBackup;
				m_strArquivoBackup = strArquivoBackup;
				m_strDiretorioTemporario += m_rdRandomico.Next(0,50000).ToString();
				verificaNomeBackup();
			}
			public clsBackup(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConectionDB, string strEnderecoExecutavel, string strEnderecoBackup)
			{
				m_cls_dba_ConectionDB = cls_dba_ConectionDB;
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_strEnderecoBackup = strEnderecoBackup;
			}
			public clsBackup(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConectionDB, string strEnderecoExecutavel)
			{
				m_cls_dba_ConectionDB = cls_dba_ConectionDB;
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				carregaDadosEnderecoBackupENomeBackup();
			}
		#endregion

		#region Carrega Dados Endereço Backup E Gera Nome Backup
		private void carregaDadosEnderecoBackupENomeBackup()
		{
			try
			{
				m_strArquivoBackup = "Becape-" + System.DateTime.Now.ToString("dd_MM_yyyy") + ".bkp";
				m_strEnderecoBackup = m_cls_dba_ConectionDB.GetConfiguracao(STRCAMPOENDERECOBACKUP,m_strEnderecoExecutavel);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region CriaBackupSeNecessario
		public void criaBackupSeNecessario()
		{
			bool bShowErrors = m_cls_dba_ConectionDB.ShowDialogsErrors;
			try
			{
				int nIdFrequenciaBackup = 0;
				m_cls_dba_ConectionDB.ShowDialogsErrors = false;
				bool bPerguntarBackup = m_cls_dba_ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOPERGUNTARBACKUP, false);
				bool bCriarBackup = !bPerguntarBackup;
				System.DateTime dtBackupFuturo = m_cls_dba_ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAPROXIMOBACKUP, System.DateTime.Now);
				System.DateTime dtBackupUltimo = m_cls_dba_ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAULTIMOBACKUP, System.DateTime.Now);
				dtBackupUltimo = new DateTime(dtBackupUltimo.Year,dtBackupUltimo.Month,dtBackupUltimo.Day);
				System.DateTime dtNow = new DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);
				nIdFrequenciaBackup = m_cls_dba_ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOFREQUENCIABACKUP, 0);
				if (nIdFrequenciaBackup != 0)
				{
					if ((dtBackupFuturo <= dtNow) || (dtBackupUltimo == dtNow) || ((mdlPreferencias.FREQUENCIABACKUP)nIdFrequenciaBackup == mdlPreferencias.FREQUENCIABACKUP.DIARIAMENTE))
					{
						if (bPerguntarBackup)
						{
							if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBackup_clsBackup_PerguntarBackup.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								bCriarBackup = true;
							else
								bCriarBackup = false;
						}
						if (bCriarBackup)
						{
							if (bCriaBackup())
							{
								switch((mdlPreferencias.FREQUENCIABACKUP)nIdFrequenciaBackup)
								{
									case mdlPreferencias.FREQUENCIABACKUP.DIARIAMENTE:
										dtBackupFuturo = dtNow.AddDays(1);
										m_cls_dba_ConectionDB.SetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAPROXIMOBACKUP, dtBackupFuturo.ToString());
										break;
									case mdlPreferencias.FREQUENCIABACKUP.SEMANALMENTE:
										dtBackupFuturo = dtNow.AddDays(7);
										m_cls_dba_ConectionDB.SetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAPROXIMOBACKUP, dtBackupFuturo.ToString());
										break;
									case mdlPreferencias.FREQUENCIABACKUP.MENSALMENTE:
										dtBackupFuturo = dtNow.AddMonths(1);
										m_cls_dba_ConectionDB.SetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAPROXIMOBACKUP, dtBackupFuturo.ToString());
										break;
								}
								m_cls_dba_ConectionDB.SetConfiguracao(mdlConstantes.clsConstantes.CAMPODATAULTIMOBACKUP, dtNow.ToString());
								if (bPerguntarBackup)
								{
									mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPreferencias_usrCtrlBackup_BackupTerminou.ToString()), System.Windows.Forms.MessageBoxButtons.OK);
								}
							}
						}
					}
				}
				verificarQtdeBackup(ref m_cls_dba_ConectionDB,m_strEnderecoExecutavel);
			}
			catch 
			{
			}finally{
				m_cls_dba_ConectionDB.ShowDialogsErrors = bShowErrors;
			}
		}
		#endregion

		#region Verifica Nome Backup
		private void verificaNomeBackup()
		{
			try
			{
				if (m_strArquivoBackup.IndexOf(".") != -1)
				{
					if (m_strArquivoBackup.LastIndexOf(".") + 2 <= m_strArquivoBackup.Length)
					{
						m_strArquivoBackup = m_strArquivoBackup.Substring(0,m_strArquivoBackup.LastIndexOf(".") + 1) + "bkp";
					}
				}
				else
				{
					m_strArquivoBackup += ".bkp";
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Verificar QtdBackup
		public static void verificarQtdeBackup(ref mdlDataBaseAccess.clsDataBaseAccess ConectionDB, string strEnderecoExecutavel)
		{
			try
			{
				int nQtdeBackups = 5, nIdFrequenciaBackup = 0;
				string strEnderecoBackup = "";
				string[] strFiles;
				System.DateTime dtDataCriacao = System.DateTime.Now;
				System.Collections.SortedList srlArquivosOrdenados = new System.Collections.SortedList();
				strEnderecoBackup = ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOENDERECOBACKUP,strEnderecoExecutavel);
				nQtdeBackups = ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOQUANTIDADEBACKUP,nQtdeBackups);
				nIdFrequenciaBackup = ConectionDB.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOFREQUENCIABACKUP, 0);
				if ((nIdFrequenciaBackup != 0) && (nQtdeBackups > 0))
				{
					if (System.IO.Directory.Exists(strEnderecoBackup))
					{
						strFiles = System.IO.Directory.GetFiles(strEnderecoBackup, "*.bkp");
						if (nQtdeBackups < strFiles.Length)
						{
							foreach(string strFile in strFiles)
							{
								dtDataCriacao = System.IO.File.GetCreationTime(strFile);
								srlArquivosOrdenados.Add(dtDataCriacao, strFile);
							}
							for(int nCount = 0; nCount < (srlArquivosOrdenados.Count - nQtdeBackups); nCount++)
							{
								System.IO.File.Delete(srlArquivosOrdenados.GetByIndex(nCount).ToString());
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				//throw err;
			}
		}
		#endregion

		#region Cria Backup
		public bool bCriaBackup()
		{
			try
			{
				m_cls_dba_ConectionDB.Log = true;
				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				System.Collections.ArrayList arlListaArquivo = new System.Collections.ArrayList();
				System.Data.DataSet dtsetTemp = new System.Data.DataSet("Backup");
				invocarMetodosDataAccessGet(ref dtsetTemp);
				System.Data.DataTable dtTbTemp = new System.Data.DataTable(TBVERSAOBACKUPTEXTO);
				dtTbTemp.Columns.Add(DATABACKUP,System.Type.GetType("System.DateTime"));
				dtTbTemp.Columns.Add(VERSAOBACKUPTEXTO,System.Type.GetType("System.String"));
				dtTbTemp.Columns.Add(VERSAOSISCOBRASTEXTO,System.Type.GetType("System.String"));
				System.Data.DataRow dtRow = dtTbTemp.NewRow();
				dtRow[DATABACKUP] = m_dtDataBackup;
				dtRow[VERSAOBACKUPTEXTO] = m_rdRandomico.Next().ToString();
				dtRow[VERSAOSISCOBRASTEXTO] = m_rdRandomico.Next().ToString();
				dtsetTemp.Tables.Add(dtTbTemp);
				if (!System.IO.Directory.Exists(m_strDiretorioTemporario))
				{
					System.IO.Directory.CreateDirectory(m_strDiretorioTemporario);
				}
				dtsetTemp.WriteXml(m_strDiretorioTemporario + "\\" + ARQUIVOXML, System.Data.XmlWriteMode.WriteSchema);
				arlListaArquivo.Add(m_strDiretorioTemporario + "\\" + ARQUIVOXML);
				mdlCompactacao.clsCompactacao obj = new mdlCompactacao.clsCompactacao(ref m_cls_ter_tratadorErro);
				if (!System.IO.Directory.Exists(m_strEnderecoBackup))
				{
					System.IO.Directory.CreateDirectory(m_strEnderecoBackup);
				}
				if (System.IO.File.Exists(m_strEnderecoBackup + "\\" + m_strArquivoBackup))
					System.IO.File.Delete(m_strEnderecoBackup + "\\" + m_strArquivoBackup);
				obj.compacta(ref arlListaArquivo, m_strEnderecoBackup + "\\" + m_strArquivoBackup, mdlCompactacao.NIVELCOMPACTACAO.MAXIMO);
				try
				{
					System.IO.File.Delete(m_strDiretorioTemporario + "\\" + ARQUIVOXML);
					System.IO.Directory.Delete(m_strDiretorioTemporario, true);
				}
				catch
				{
				}
			}
			catch 
			{
				return(false);
			}
			return (true);
		}
		#endregion
		#region Restaura Backup
		public bool bRestauraBackup()
		{
			try
			{
				#region Variáveis e Inicialização
				m_cls_dba_ConectionDB.SystemMode = mdlDataBaseAccess.Mode.Developer;
				m_cls_dba_ConectionDB.Log = true;
				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				apagaTodosRegistrosBD();
				System.Collections.ArrayList arlListaArquivo = new System.Collections.ArrayList();
				#endregion
				#region Tabela Backup - Inexistente no BD do Siscobras
				System.Data.DataSet dtsetTemp = new System.Data.DataSet("Backup");
				System.Data.DataTable dtTbTemp = new System.Data.DataTable(TBVERSAOBACKUPTEXTO);
				dtTbTemp.Columns.Add(DATABACKUP,System.Type.GetType("System.DateTime"));
				dtTbTemp.Columns.Add(VERSAOBACKUPTEXTO,System.Type.GetType("System.String"));
				dtTbTemp.Columns.Add(VERSAOSISCOBRASTEXTO,System.Type.GetType("System.String"));
				#endregion
				#region Diretório Backup
				if ((System.IO.Directory.Exists(m_strEnderecoBackup)) && (System.IO.File.Exists(m_strEnderecoBackup + "\\" + m_strArquivoBackup)))
				{
					#region Descompactando e Deletando Diretórios e Arquivos Criados
					mdlCompactacao.clsCompactacao obj = new mdlCompactacao.clsCompactacao(ref m_cls_ter_tratadorErro);
					string[] strTempListaArquivos = obj.retornaListaDeArquivos(m_strEnderecoBackup + "\\" + m_strArquivoBackup);
					string strDirTemp = "";
					try
					{
						strDirTemp = strTempListaArquivos[0].Substring(0,strTempListaArquivos[0].LastIndexOf("\\"));
					}
					catch
					{
						try
						{
							strDirTemp = strTempListaArquivos[0].Substring(0,strTempListaArquivos[0].LastIndexOf("/"));
						}
						catch
						{
							strDirTemp = strTempListaArquivos[0];
						}
					}
					if (!System.IO.Directory.Exists(strDirTemp))
					{
						System.IO.Directory.CreateDirectory(strDirTemp);
					}
					obj.descompacta(m_strEnderecoBackup + "\\" + m_strArquivoBackup);
					dtsetTemp.ReadXml(strTempListaArquivos[0], System.Data.XmlReadMode.ReadSchema);
					if (System.IO.File.Exists(strTempListaArquivos[0]))
					{
						System.IO.File.Delete(strTempListaArquivos[0]);
					}
					if (System.IO.Directory.Exists(strDirTemp))
					{
						System.IO.Directory.Delete(strDirTemp);
					}
					#endregion
					#region Tabela Backup - Inexistente no BD do Siscobras
					if (dtsetTemp.Tables.Contains(TBVERSAOBACKUPTEXTO))
					{
						dtTbTemp = dtsetTemp.Tables[TBVERSAOBACKUPTEXTO];
						dtsetTemp.Tables.Remove(TBVERSAOBACKUPTEXTO);
					}
					#endregion
					return(bUpdateDataAccess(ref dtsetTemp));
				}
				#endregion
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
			return true;
		}
		private void apagaTodosRegistrosBD()
		{
			m_cls_dba_ConectionDB.DeleteAllDataBase();
		}
		#endregion

		#region Pegar Lista de Métodos Data Access
		private void invocarMetodosDataAccessGet(ref System.Data.DataSet dtSet)
		{
			try
			{
				m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				Object[] ObjParametros = { null, null, null, null, null };
				Object retorno = null;
				System.Data.DataTable tabelaTemp = null;
				System.Type typDB = (typeof(mdlDataBaseAccess.clsDataBaseAccess));
				System.Reflection.MethodInfo[] mtInfoTempArray = typDB.GetMethods();
				foreach(System.Reflection.MethodInfo mtInfo in mtInfoTempArray)
				{
					if ((!m_bIncluirModulos) && (mtInfo.Name == "GetTbModulos"))
						continue;
					if (mtInfo.Name.StartsWith("GetTb"))
					{
						m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
						retorno = mtInfo.Invoke(m_cls_dba_ConectionDB, ObjParametros);
						tabelaTemp = ((System.Data.DataSet)retorno).Tables[0];
						((System.Data.DataSet)retorno).Tables.RemoveAt(0);
						dtSet.Tables.Add(tabelaTemp);
					}
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		private bool bUpdateDataAccess(ref System.Data.DataSet dtSet)
		{
			m_cls_dba_ConectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_cls_dba_ConectionDB.SetDataSetMultiTableStructIn(dtSet);
			return(m_cls_dba_ConectionDB.Erro == null);
		}
		#endregion
	}
}
