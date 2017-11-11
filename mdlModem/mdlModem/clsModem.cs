using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mdlModem
{
	/// <summary>
	/// Classe que faz a comunicação em alto nível com o dispositivo MODEM.
	/// </summary>
	public class clsModem
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratamentoErro = null;
		private string m_strEnderecoExecutavel = "";

		private clsSerialStream m_clsSerialStream = null;
		private StreamWriter m_SysIOStreamWriter = null;
		private StreamReader m_SysIOStreamReader = null;
		private Thread m_ThreadLeitorResposta = null;
		private Thread m_ThreadDiscaNumero = null;
		private string m_strResposta = "";
		private string m_strNumeroDiscado = "";
		private bool m_bDiscagem = false;
		private string m_strNumeroChamador = "";
		private string m_strNomeChamador = "";
		private bool m_bModemInicializado = false;
		private string m_strPortaCOMModem = "COM";
		private int m_nPortaCOMModem = 1;
		private System.DateTime m_dtInicioLigacao;
		private System.DateTime m_dtFimLigacao;
		private System.Threading.WaitHandle m_WaitHandleAssincrono = null;
		public string RESPOSTA
		{
			get
			{
				string temp = m_strResposta.Clone().ToString();
				m_strResposta = "";
				return temp;
			}
		}
		public System.DateTime INICIOLIGACAO
		{
			get
			{
				return m_dtInicioLigacao;
			}
			set
			{
				m_dtInicioLigacao = value;
			}
		}
		#endregion

		#region Construtores & Destrutores
		public clsModem(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			m_cls_ter_tratamentoErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			pesquisaModemPortasComm();
			criaComunicacao();
		}
		public void Dispose()
		{
			m_SysIOStreamReader.Close();
			m_SysIOStreamWriter.Close();
			if (m_ThreadLeitorResposta != null)
                if (m_ThreadLeitorResposta.IsAlive)
					m_ThreadLeitorResposta.Abort();
		}
		#endregion

		#region Delegate
		public delegate void delCallIdenticadaChamada(string strNumeroChamador, string strNomeChamador);
		#endregion
		#region Events
		public event delCallIdenticadaChamada eCallIdenticadaChamada;
		#endregion
		#region Events Methods
		protected void OnCallIdenticadaChamada()
		{
			if (eCallIdenticadaChamada != null)
				eCallIdenticadaChamada(m_strNumeroChamador, m_strNomeChamador);
		}
		#endregion

		#region Seta Handle
		private void setaHandle(ref System.Threading.WaitHandle waitHandleAssincrono)
		{
			m_WaitHandleAssincrono = waitHandleAssincrono;
		}
		#endregion

		#region Métodos para envio de mensagens ao modem
		private void enviaMensagem(string strMensagem)
		{
			try
			{
				// Comando de saída?!??!??!
				if (strMensagem.Trim().ToLower() == "exit") 
				{
					m_ThreadLeitorResposta.Abort();
					MessageBox.Show("Cancelando execução........");
					Application.Exit();
				}

				// Envia comando ao modem
				m_SysIOStreamWriter.WriteLine(strMensagem);
				m_SysIOStreamWriter.Flush();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
		}

		private void criaComunicacao()
		{
			try
			{
				if (m_clsSerialStream == null)
				{
					m_clsSerialStream = new clsSerialStream();
					m_clsSerialStream.eCallSetaWaitHandle += new clsSerialStream.delCallSetaWaitHandle(setaHandle);
					m_clsSerialStream.Open(m_strPortaCOMModem + m_nPortaCOMModem.ToString());
				}
				
				// Configura porta
				m_clsSerialStream.SetPortSettings(9600);

				// Seta timeout, leitura termina após 20ms de silêncio após uma resposta
				m_clsSerialStream.SetTimeouts(20, 0, 0, 0, 0);

				if (m_SysIOStreamWriter == null)
				{
					// Cria o StreamWriter para enviar os comandos
					m_SysIOStreamWriter = new StreamWriter(m_clsSerialStream, System.Text.Encoding.ASCII);
				}

				if (m_SysIOStreamReader == null)
					m_SysIOStreamReader = new StreamReader(m_clsSerialStream, System.Text.Encoding.ASCII);
				// Cria a Thread para ler as respostas
//				m_ThreadLeitorResposta = new Thread(new ThreadStart(ThreadLeResposta));
//				m_ThreadLeitorResposta.Name = "Thread de Leitura";
//				m_ThreadLeitorResposta.Start();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
		}

		#endregion

		#region Inicializando Modem
		private bool inicializaModem()
		{
//			if (m_WaitHandleAssincrono != null)
//			{
				try
				{
					enviaMensagem("AT" + System.Environment.NewLine);
					lock(m_strResposta)
					{
						while (m_strResposta.Trim() == "")
                            m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() != "OK")
							return false;
						m_strResposta = "";
					}
					System.Threading.Monitor.Exit(m_strResposta);
					enviaMensagem("ATH" + System.Environment.NewLine);
					lock(m_strResposta)
					{
						while (m_strResposta.Trim() == "")
							m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() != "OK")
							return false;
						m_strResposta = "";
					}
					System.Threading.Monitor.Exit(m_strResposta);
					enviaMensagem("ATE0" + System.Environment.NewLine);
					lock(m_strResposta)
					{
						while (m_strResposta.Trim() == "")
							m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() != "OK")
							return false;
						m_strResposta = "";
					}
					System.Threading.Monitor.Exit(m_strResposta);
//					enviaMensagem("ATI4" + System.Environment.NewLine);
//					lock(m_strResposta)
//					{
//						while (m_strResposta.Trim() != "OK")
//						{
//							m_strResposta = m_SysIOStreamReader.ReadLine();
//							MessageBox.Show("Item: " + m_strResposta);
//						}
//						m_strResposta = "";
//					}
//					System.Threading.Monitor.Exit(m_strResposta);
					enviaMensagem("ATZ" + System.Environment.NewLine);
					lock(m_strResposta)
					{
						while (m_strResposta.Trim() == "")
							m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() != "OK")
							return false;
						m_strResposta = "";
					}
					System.Threading.Monitor.Exit(m_strResposta);
					enviaMensagem("AT&F &C1 &D2 E0 X3" + System.Environment.NewLine);
					lock(m_strResposta)
					{
						while (m_strResposta.Trim() == "")
							m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() != "OK")
							return false;
						m_strResposta = "";
					}
					System.Threading.Monitor.Exit(m_strResposta);
//					enviaMensagem("ATDW" + System.Environment.NewLine);
//					lock(m_strResposta)
//					{
//						System.Threading.Thread.Sleep(600);
//						while (m_strResposta.Trim() == "")
//							m_strResposta = m_SysIOStreamReader.ReadLine();
//						if (m_strResposta.Trim().ToUpper() != "OK")
//							return false;
//						m_strResposta = "";
//					}
//					System.Threading.Monitor.Exit(m_strResposta);
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratamentoErro.trataErro(ref erro);
				}
//			}
			return true;
		}
		#endregion

		#region Ligação
		public bool bRealizaLigacao(string strNumero)
		{
			bool bRetorno = false;
			if (m_bModemInicializado == false)
				m_bModemInicializado = inicializaModem();
			try
			{
				m_strNumeroDiscado = strNumero;
				m_ThreadDiscaNumero = new Thread(new ThreadStart(ThreadLigacao));
				m_ThreadDiscaNumero.Start();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
			return bRetorno;
		}
		private void ThreadLigacao()
		{
			m_bDiscagem = false;
			try
			{
				if (m_bModemInicializado)
				{
					enviaMensagem("ATDW" + m_strNumeroDiscado + System.Environment.NewLine);
					while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
					{
						m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() == "NO ANSWER")
							break;
					}
					if (m_strResposta == "OK")
					{
						m_dtInicioLigacao = System.DateTime.Now;
						m_bDiscagem = true;
					}
				}
			}
			catch (Exception err)
			{
				m_bDiscagem = false;
			}
		}
		public bool bAtendeLigacao()
		{
			bool bRespostaOK = false;
			if (m_bModemInicializado == false)
				m_bModemInicializado = inicializaModem();
			try
			{
				if (m_bModemInicializado)
				{
					enviaMensagem("ATH0" + System.Environment.NewLine);
					while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
					{
						m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() == "NO ANSWER")
							break;
					}
					if (m_strResposta == "OK")
					{
						m_dtInicioLigacao = System.DateTime.Now;
						bRespostaOK = true;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
			return bRespostaOK;
		}
		public bool bFimLigacao()
		{
			bool bRespostaOK = false;
			try
			{
				if (m_bModemInicializado)
				{
					enviaMensagem("+++" + System.Environment.NewLine);
					System.Threading.Thread.Sleep(2000);
					lock (m_strResposta)
					{
						while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
						{
							m_strResposta = m_SysIOStreamReader.ReadLine();
							if (m_strResposta.Trim().ToUpper() == "NO CARRIER")
								return false;
						}
					}
					System.Threading.Monitor.Exit(m_strResposta);
					enviaMensagem("ATH1" + System.Environment.NewLine);
					lock (m_strResposta)
					{
						while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
						{
							m_strResposta = m_SysIOStreamReader.ReadLine();
							if (m_strResposta.Trim().ToUpper() == "NO ANSWER")
								return false;
						}
					}
					System.Threading.Monitor.Exit(m_strResposta);
					if (m_strResposta == "OK")
					{
						m_dtFimLigacao = System.DateTime.Now;
						bRespostaOK = true;
						m_bModemInicializado = false;
						m_SysIOStreamWriter.Close();
						m_SysIOStreamReader.Close();
						m_clsSerialStream.Close();
						m_SysIOStreamWriter = null;
						m_SysIOStreamReader = null;
						m_clsSerialStream = null;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
			return bRespostaOK;
		}
		public bool bCancelaLigação()
		{
			bool bRetorno = false;
			try
			{
				if (m_bModemInicializado)
				{
					if ((m_ThreadDiscaNumero != null) && (m_ThreadDiscaNumero.IsAlive))
					{
						m_ThreadDiscaNumero.Abort();
						bRetorno = true;
					}
					else
					{
						enviaMensagem("+++" + System.Environment.NewLine);
						System.Threading.Thread.Sleep(2000);
						while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
						{
							m_strResposta = m_SysIOStreamReader.ReadLine();
							if (m_strResposta.Trim().ToUpper() == "NO CARRIER")
								break;
						}
						if (m_strResposta == "OK")
						{
							enviaMensagem("ATH1" + System.Environment.NewLine);
							while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
							{
								m_strResposta = m_SysIOStreamReader.ReadLine();
								if (m_strResposta.Trim().ToUpper() == "NO ANSWER")
									break;
							}
							if (m_strResposta == "OK")
							{
								bRetorno = true;
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
			return bRetorno;
		}
		#endregion

		#region Bina
		public bool bIdentificadorChamada()
		{
			bool bRetorno = false;
			if (m_bModemInicializado == false)
				m_bModemInicializado = inicializaModem();
			try
			{
				if (m_bModemInicializado)
				{
					enviaMensagem("AT#CID=1" + System.Environment.NewLine);
					while (m_strResposta.Trim() != "OK" && m_strResposta.Trim() != "ERROR")
					{
						m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta.Trim().ToUpper() == "NO ANSWER")
							break;
					}
					if (m_strResposta == "OK")
					{
						m_dtInicioLigacao = System.DateTime.Now;
						bRetorno = true;
					}
					m_ThreadLeitorResposta = new Thread(new ThreadStart(ThreadLeResposta));
					m_ThreadLeitorResposta.Start();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
			return bRetorno;
		}
		#endregion

		#region Pesquisa Portas COMM por Modem
		private void pesquisaModemPortasComm()
		{
			try
			{
				bool bResultado = true;
				m_clsSerialStream = new clsSerialStream();
				m_clsSerialStream.eCallSetaWaitHandle += new clsSerialStream.delCallSetaWaitHandle(setaHandle);
				m_clsSerialStream.Open(m_strPortaCOMModem + m_nPortaCOMModem.ToString());
				
				// Configura porta
				m_clsSerialStream.SetPortSettings(9600);

				// Seta timeout, leitura termina após 20ms de silêncio após uma resposta
				m_clsSerialStream.SetTimeouts(0, 0, 20, 0, 20);

				// Cria o StreamWriter para enviar os comandos
				m_SysIOStreamWriter = new StreamWriter(m_clsSerialStream, System.Text.Encoding.ASCII);

				m_SysIOStreamReader = new StreamReader(m_clsSerialStream, System.Text.Encoding.ASCII);

				enviaMensagem("AT" + System.Environment.NewLine);
				lock(m_strResposta)
				{
					while ((m_strResposta != null) && (m_strResposta.Trim() == ""))
						m_strResposta = m_SysIOStreamReader.ReadLine();
					if ((m_strResposta == null) || (m_strResposta.Trim().ToUpper() != "OK"))
					{
						m_nPortaCOMModem++;
						bResultado = false;
					}
					m_strResposta = "";
				}
				System.Threading.Monitor.Exit(m_strResposta);
				if ((bResultado == false) && (m_nPortaCOMModem < 5))
					pesquisaModemPortasComm();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratamentoErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Thread
		private void ThreadLeResposta() 
		{
			m_SysIOStreamReader = new StreamReader(m_clsSerialStream, System.Text.Encoding.ASCII);
			System.Console.WriteLine("tá iniciando a Thread - " + this.ToString());
			try 
			{
				for (;;) 
				{
					lock(m_strResposta)
					{
						System.Console.WriteLine("Entrou no lock!!!!");
						// Ler resposta do modem
						m_strResposta = m_SysIOStreamReader.ReadLine();
						if (m_strResposta != null)
							System.Console.WriteLine(m_strResposta + " Essa é a resposta!!!!! - " + this.ToString());
						//System.Threading.Monitor.PulseAll(m_strResposta);
						if ((m_strResposta != null) && (m_strResposta.Trim() != ""))
						{
							m_strNumeroChamador = m_strResposta.Clone().ToString();
							m_strNomeChamador = m_strResposta.Clone().ToString();
							OnCallIdenticadaChamada();
						}
					}
					System.Threading.Monitor.Exit(m_strResposta);
					System.Threading.Thread.Sleep(10);
//						if (m_strResposta != null)
//							System.Console.WriteLine("Resposta do modem: " + m_strResposta);
//						else
//							System.Console.WriteLine("Resposta do modem: NULL");
				}
			}
			catch (ThreadAbortException) 
			{
			}
		}
		#endregion
	}
}
