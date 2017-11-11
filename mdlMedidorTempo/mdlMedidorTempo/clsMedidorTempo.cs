using System;

namespace mdlMedidorTempo
{
	#region structMedicao
	public struct structMedicao 
	{
		public string m_strNome;
		public System.DateTime m_dtInicio;
		public object[] m_Parametros;
	}
	#endregion

	#region clsMedidorTempo
	public class clsMedidorTempo
	{
		#region Atributos
		private static System.Collections.Hashtable m_htblMedicoes;
		private static mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_connectionDB;
		private static string m_strEnderecoExecutavel;
		private static bool m_Initialized;
		#endregion

		#region Constructor
		private clsMedidorTempo()
		{
		}

		static clsMedidorTempo() 
		{
			m_htblMedicoes = new System.Collections.Hashtable();
			m_cls_dba_connectionDB = null;
			m_strEnderecoExecutavel = "";
			m_Initialized = false;
		}
		#endregion

		#region Public
		public static void Init (ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB, string strEnderecoExecutavel) 
		{
			m_cls_dba_connectionDB = cls_dba_ConnectionDB;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_Initialized = true;
		}

		public static bool IniciaMedicao (string strNome, params object[] arrParametros) 
		{
			structMedicao medicao;

			if (!m_Initialized) 
			{
				return false;
			}

			medicao = CriaNovaMedicao (strNome, arrParametros);

			try 
			{
				m_htblMedicoes.Add (strNome, medicao);
			} 
			catch (System.Exception) 
			{
				return false;
			}

			return true;
		}

		public static bool FinalizaMedicao (string strNome, params object[] arrValores) 
		{
			return FinalizaMedicao (strNome, true, arrValores);
		}

		public static bool FinalizaMedicao (string strNome, bool bFinaliza, params object[] arrValores)
		{
			structMedicao medicao;
			string strLog = "";

			if (!m_Initialized) 
			{
				return false;
			}

			try 
			{
				medicao = (structMedicao) m_htblMedicoes[strNome];
			} 
			catch (System.Exception) 
			{
				return false;
			}

			if (medicao.m_Parametros.Length != arrValores.Length) 
			{
				return false;
			}

			strLog = medicao.m_strNome;
			for (int i = 0; i < medicao.m_Parametros.Length; i++) 
			{
				strLog += "#" + medicao.m_Parametros[i].ToString() + "=" + arrValores[i].ToString();
			}

			mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo tbLog = m_cls_dba_connectionDB.GetTbLogMedicaoTempo (null, null, null, null, null);
			try 
			{
				int nIdLog = 0;
				while (tbLog.tbLogMedicaoTempo.FindBynIdLog (nIdLog) != null) 
				{
					nIdLog++;
				}

				System.TimeSpan diff = System.DateTime.Now - medicao.m_dtInicio;
				mdlDataBaseAccess.Tabelas.XsdTbLogMedicaoTempo.tbLogMedicaoTempoRow dtrwLog = tbLog.tbLogMedicaoTempo.NewtbLogMedicaoTempoRow();

				dtrwLog.nIdLog = nIdLog;
				dtrwLog.dtInicio = medicao.m_dtInicio;
				dtrwLog.nDuracao = diff.Milliseconds;
				dtrwLog.mstrDescricao = strLog;

				tbLog.tbLogMedicaoTempo.Rows.Add (dtrwLog);

				m_cls_dba_connectionDB.SetTbLogMedicaoTempo (tbLog);
			} 
			catch (System.Exception) 
			{
				return false;
			}

			if (bFinaliza) 
			{
				m_htblMedicoes.Remove (strNome);
			}

			return true;
		}
		#endregion

		#region Private
		private static structMedicao CriaNovaMedicao (string strNome, params object[] arrParametros) 
		{
			structMedicao medicao = new structMedicao();
			medicao.m_strNome = strNome;
			medicao.m_dtInicio = System.DateTime.Now;
			medicao.m_Parametros = arrParametros;

			return medicao;
		}
		#endregion
	}
	#endregion
}
