using System;

namespace mdlEmail
{
	#region Enums
	public enum AUTENTICACAO
	{
		Nenhuma = -1,
		Automatica = 0,
		DIGEST_MD5 = 1,
		CRAM_MD5 = 2,
		LOGIN = 3
	}
	#endregion
	/// <summary>
	/// Summary description for clsEmailSocket.
	/// </summary>
	public class clsEmailSocket
	{
		#region Atributos
			private AUTENTICACAO m_enumAutenticacao = AUTENTICACAO.Automatica;
			private string m_strAuthLoginUser = "";
			private string m_strAuthLoginPassword = "";
        
			private string m_strSMTP = "";
			private int m_nPortSmpt = 25;
			private int m_nTimeOut = 30;

			private bool m_bOverTLS = false;

			private string m_strMaquinaRemetente = "";
			private string m_strRemetente = "";
			private System.Collections.ArrayList m_arlDestinatarios;
			private string m_strAssunto = "";
			private string m_strMensagem = "";
			private string m_strMensagemHtml = "";
			private System.Collections.ArrayList m_arlArquivosAtachados;

			private System.Net.Sockets.TcpClient m_tcpClient = null;
			private System.Net.Sockets.NetworkStream m_netStream = null;
		#endregion
		#region Properties
			public AUTENTICACAO AutenticacaoTipo
			{
				set
				{
					m_enumAutenticacao = value;
				}
				get
				{
					return(m_enumAutenticacao);
				}
			}

			public string UsuarioAutenticacao
			{
				set
				{
					m_strAuthLoginUser = value;
				}
				get
				{
					return(m_strAuthLoginUser);
				}
			}

			public string SenhaAutenticacao
			{
				set
				{
					m_strAuthLoginPassword = value;
				}
				get
				{
					return(m_strAuthLoginPassword);
				}
			}

			/// <summary>
			/// Informa o servidor de SMTP a ser utilizado.
			/// </summary>
			public string SMTP
			{
				set
				{
					m_strSMTP = value;
				}
				get
				{
					return(m_strSMTP);
				}
			}

			/// <summary>
			/// Informa qual porta (TCP) deve-se conectar ao servidor de SMTP
			/// </summary>
			public int Porta
			{
				set
				{
					m_nPortSmpt = value;
				}
				get
				{
					return(m_nPortSmpt);
				}
			}

			/// <summary>
			/// Qual o tempo maximo de espera da conexão (TIMEOUT)
			/// </summary>
			public int TIMEOUT
			{
				set
				{
					m_nTimeOut = value;
				}
				get
				{
					return(m_nTimeOut);
				}
			}
			public string Remetente
			{
				set
				{
					m_strMaquinaRemetente = value.Replace("@",".").Trim();
					m_strRemetente = value;
				}
				get
				{
					return(m_strRemetente);
				}
			}

			public System.Collections.ArrayList Destinatarios
			{
				set
				{
					if (value != null)
						m_arlDestinatarios = value;
				}
				get
				{
					return(m_arlDestinatarios);
				}
			}

			public string Assunto
			{
				set
				{
					m_strAssunto = value;
				}
				get
				{
					return(m_strAssunto);
				}
			}

			public string Mensagem
			{
				set
				{
					m_strMensagem = value;
				}
				get
				{
					return(m_strMensagem);
				}
			}

			public string MensagemHTML
			{
				set
				{
					m_strMensagemHtml = value;
				}
				get
				{
					return(m_strMensagemHtml);
				}
			}
			public System.Collections.ArrayList ArquivosAtachados
			{
				set
				{
					if (value != null)
						m_arlArquivosAtachados = value;
				}
				get
				{
					return(m_arlArquivosAtachados);
				}
			}
		#endregion
		#region Construtors and Destrutors
		public clsEmailSocket()
		{
			
		}
		#endregion

		#region Conexão
		private string strAdquireResposta()
		{
			double start, tmr;
			start = System.DateTime.Now.TimeOfDay.TotalSeconds;

			byte[] buffer = new byte[m_tcpClient.ReceiveBufferSize];

			while (!m_netStream.DataAvailable)
			{
				tmr = System.DateTime.Now.TimeOfDay.TotalSeconds - start;
				if (tmr > m_nTimeOut)
					return ("CErro: TIMEOUT");
			}
			if (m_netStream.DataAvailable)
			{
				m_netStream.Read(buffer, 0, m_tcpClient.ReceiveBufferSize);
				return (System.Text.Encoding.ASCII.GetString(buffer));
			}
			return ("CErro: TIMEOUT");
		}
		private void vSendCommand(string strMensagem)
		{
			byte[] arrByte = new byte[strMensagem.Length];
			Exception err = new Exception("Erro na conversão");
			if (!bExtendedASCIIEncode(strMensagem, ref arrByte))
				throw err;
			m_netStream.Write(arrByte,0,arrByte.Length);
		}
		private bool bExtendedASCIIEncode(string strMensagem, ref byte[] arrByte)
		{
			char chrTeste;
			for (int nCount = 0; nCount < strMensagem.Length; nCount++)
			{
				chrTeste = strMensagem.Substring(nCount,1)[0];
				arrByte[nCount] = (byte)chrTeste;
			}
			return true;
		}
		#endregion
		#region Enviar Email
		public string  strEnviaEmail()
		{
			string strRetorno = "OK";
			// SM`TP
			if (m_strSMTP == "")
			{
				strRetorno = "CErro: SMTP não inserido";
			}else{
				// REMETENTE
				if (m_strRemetente == "")
				{
					strRetorno = "CErro: Remetente não inserido";
				}else{
					// DESTINATARIOS
					if ((m_arlDestinatarios == null) || (m_arlDestinatarios.Count == 0))
					{
						strRetorno = "CErro: Destinatarios não inseridos";
					}else{
						// ASSUNTO
						if (m_strAssunto == "")
						{
							strRetorno = "CErro: Assunto não inserido";
						}else{
							// MENSAGEM
							if (m_strMensagem == "")
							{
								strRetorno = "CErro: Mensagem não inserida";
							}else{
								strRetorno = strEnviaEmailSocket();
							}
						}
					}
				}
			}
			return (strRetorno);
		}

		private string strEnviaEmailSocket()
		{
			m_bOverTLS = false;

			string strRetorno = "OK"; 
			strRetorno = strConectaServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			strRetorno = strEnviaHeloServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			strRetorno = strAutenticaMaquinaServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			strRetorno = strEnviaRemetenteServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			strRetorno = strEnviaDestinatariosServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			strRetorno = strEnviaDadosServidorSMTP();
			if (strRetorno != "OK")
				return (strRetorno);
			vEncerraConexaoServidorSMTP();
			return (strRetorno);
		}
		#endregion
		#region Métodos Relacionados ao Envio do Email
			#region Connection Starts
			private string strConectaServidorSMTP()
			{
				string strRetorno = "OK",strMensagem;
				m_tcpClient = new System.Net.Sockets.TcpClient();
				try
				{
					// Connecta ao servidor SMPT 
					m_tcpClient.Connect(m_strSMTP, m_nPortSmpt);
				}
				catch
				{
					return("CErro: Servidor SMTP inválido ou Porta SMTP errada.");
				}

				// Conseguiu conexão, seta netStream, canal de comunicação
				m_netStream = m_tcpClient.GetStream();
				if (m_netStream == null)
				{
					return ("CErro: Não foi possível adquirir o canal de comunicação.");
				}
            
				// RESPOSTA
				strMensagem = strAdquireResposta();
				if (strMensagem.Substring(0,3) != "220")
				{
					if (m_tcpClient != null)
					{
						m_tcpClient.Close();
						m_tcpClient = null;
						return "SErro: Problema ao receber informacoes do servidor.";
					}
				}
				return(strRetorno);
			}
			#endregion
			#region HELO
				private string strEnviaHeloServidorSMTP()
				{
					m_bOverTLS = false;
					string strRetorno = "OK",strMensagem = "";
					vSendCommand("EHLO " + m_strMaquinaRemetente + System.Environment.NewLine);
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) == "250")
					{
						if (strMensagem.IndexOf("STARTTLS") > 0)
						{
							// CRYPTOGRAFIA DESSABILITADA
//							vSendCommand("STARTTLS" + System.Environment.NewLine);
//							strMensagem = strAdquireResposta();
//							if (strMensagem.Substring(0,3) == "220")
//							{
//								m_bOverTLS = true;
//							}
						}
					}
					else
					{
						vSendCommand("HELO " + m_strMaquinaRemetente + System.Environment.NewLine);
						strMensagem = strAdquireResposta();
						if (strMensagem.Substring(0,3) != "250")
						{
							if (m_tcpClient != null)
							{
								m_tcpClient.Close();
								m_tcpClient = null;
								return ("SErro: Problema ao enviar HELO ao servidor.");
							}
						}
					}
					return(strRetorno);
				}
			#endregion
			#region Autentificacao
				private string strAutenticaMaquinaServidorSMTP()
				{
					string strRetorno = "OK";
					if (m_enumAutenticacao != AUTENTICACAO.Nenhuma)
					{
						// COM AUTENTICACAO
						switch(m_enumAutenticacao)
						{
							case AUTENTICACAO.Automatica: // Tentando identificar o tipo de autenticacao
								strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoDIGEST_MD5();
								if (strRetorno != "OK")
								{
									strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoCRAM_MD5();
									if (strRetorno != "OK")
									{
										strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoLOGIN();
										if (strRetorno != "OK")
										{
											m_tcpClient.Close();
											m_tcpClient = null;
											return("SErro: Problemas ao tentar identificar o tipo de autenticação do servidor SMTP.");
										}
									}
								}
								break;
							case AUTENTICACAO.DIGEST_MD5:
								strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoDIGEST_MD5();
								if (strRetorno != "OK")
								{
									m_tcpClient.Close();
									m_tcpClient = null;
									return(strRetorno);
								}
								break;
							case AUTENTICACAO.CRAM_MD5:
								strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoCRAM_MD5();
								if (strRetorno != "OK")
								{
									m_tcpClient.Close();
									m_tcpClient = null;
									return(strRetorno);
								}
								break;
							case AUTENTICACAO.LOGIN:
								strRetorno = strAutenticaMaquinaServidorSMTPEnviaAutenticacaoLOGIN();
								if (strRetorno != "OK")
								{
									m_tcpClient.Close();
									m_tcpClient = null;
									return(strRetorno);
								}
								break;
						} 
					}
					return(strRetorno);
				}

				private string strAutenticaMaquinaServidorSMTPEnviaAutenticacaoCRAM_MD5()
				{
					string strRetorno = "OK",strMensagem = "";
					vSendCommand("AUTH CRAM-MD5" + System.Environment.NewLine);
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "334")
					{
						if (m_tcpClient != null)
						{
							return ("SErro: Problema ao enviar AUTH CRAM-MD5 ao servidor.");
						}
					}else{
						string strAuth = strMensagem.Substring(4);
						strAuth = strAuth.Substring(0,strAuth.IndexOf("\r"));
						strAuth = strBase64ToString(strAuth);
						strAuth = strComputeHashMD5(strAuth + m_strAuthLoginPassword);
						strAuth = strStringToBase64(strAuth);						
						strAuth = m_strAuthLoginUser + " " + strAuth;
                        strAuth = strStringToBase64(strAuth);						
						vSendCommand(strAuth + System.Environment.NewLine);
						strMensagem = strAdquireResposta();
						if (strMensagem.Substring(0,3) != "334")
						{
							if (m_tcpClient != null)
							{
								return ("SErro: Problema ao enviar AUTH CRAM-MD5 ao servidor.");
							}
						}
					}
					return(strRetorno);
				}

				private string strAutenticaMaquinaServidorSMTPEnviaAutenticacaoDIGEST_MD5()
				{
					string strRetorno = "OK",strMensagem = "";
					// ENVIO
					vSendCommand("AUTH DIGEST-MD5" + System.Environment.NewLine);

					// RESPOSTA
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "334")
					{
						if (m_tcpClient != null)
						{
							return ("SErro: Problema ao enviar AUTH DIGEST-MD5 ao servidor.");
						}
					}
					return(strRetorno);
				}

				/// <summary>
				/// Fazendo a autenticao por LOGIN
				/// </summary>
				/// <returns></returns>
				private string strAutenticaMaquinaServidorSMTPEnviaAutenticacaoLOGIN()
				{
					string strRetorno = "OK",strMensagem = "";
					// ENVIO
					vSendCommand("AUTH LOGIN" + System.Environment.NewLine);
					// RESPOSTA
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "334")
					{
						return ("SErro: Problema ao enviar AUTH LOGIN ao servidor.");
					}else{
						// Enviando o LOGIN do usuário
						if (m_strAuthLoginUser != "")
						{
							string strAuthLoginUserBase64 = strStringToBase64(m_strAuthLoginUser);
							// ENVIO
							vSendCommand(strAuthLoginUserBase64 + System.Environment.NewLine);
							// RESPOSTA 
							strMensagem = strAdquireResposta();
							if (strMensagem.Substring(0,3) != "334")
							{
								return ("SErro: Problema ao enviar USER ao servidor.");
							}else{
								if (m_strAuthLoginPassword != "")
								{
									string strAuthLoginPasswordBase64 = strStringToBase64(m_strAuthLoginPassword);
									// ENVIO
									vSendCommand(strAuthLoginPasswordBase64 + System.Environment.NewLine);
									// RESPOSTA 
									strMensagem = strAdquireResposta();
									if (strMensagem.Substring(0,3) != "235") // Authentication OK
										return ("SErro: Problema ao enviar PASSWORD ao servidor.");
								}
							}
						}
					}
					return(strRetorno);
				}
			#endregion
			#region Remetente
				private string strEnviaRemetenteServidorSMTP()
				{
					string strRetorno = "OK",strMensagem = "";
					if (m_enumAutenticacao == AUTENTICACAO.Nenhuma)
					{   // Sem Autenticacao
						// ENVIO
						vSendCommand("MAIL FROM:<" + m_strRemetente + ">" + System.Environment.NewLine);
					}
					else
					{ // Com Autenticacao
						vSendCommand("MAIL FROM:<" + m_strRemetente + ">" + " AUTH=" + m_strRemetente + System.Environment.NewLine);
					}

					// RESPOSTA
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "250")
					{
						if (m_tcpClient != null)
						{
							m_tcpClient.Close();
							m_tcpClient = null;
							return ("SErro: Problema ao enviar MAIL FROM ao servidor.");
						}
					}
					return(strRetorno);
				}
			#endregion
			#region Destinatarios
				private string strEnviaDestinatariosServidorSMTP()
				{
					string strRetorno = "OK", strMensagem = "";

					for (int nCont = 0; nCont < m_arlDestinatarios.Count; nCont++)
					{
						// ENVIO
						vSendCommand("RCPT TO:<" + m_arlDestinatarios[nCont].ToString() + ">" + System.Environment.NewLine);
						// RESPOSTA
						strMensagem = strAdquireResposta();
						if (strMensagem.Substring(0,3) != "250")
						{
							if (m_tcpClient != null)
							{
								m_tcpClient.Close();
								m_tcpClient = null;
								return ("SErro: Problema ao inserir o destinatario [ " + m_arlDestinatarios[nCont].ToString() + "].");
							}
						}
					}
					return(strRetorno);
				}
			#endregion
			#region Dados 
				private string strEnviaDadosServidorSMTP()
				{
					string strRetorno = "OK", strMensagem = "";
					// ENVIO
					vSendCommand("DATA" + System.Environment.NewLine);

					// RESPOSTA
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "354")
					{
						if (m_tcpClient != null)
						{
							m_tcpClient.Close();
							m_tcpClient = null;
							return ("SErro: Problema ao enviar DATA.");
						}
					}

					// ENVIO
					strMensagem = "Date: ";
					strMensagem += System.DateTime.Now.ToString("ddd, d. MMM yyyy ");
					strMensagem += System.DateTime.Now.ToLongTimeString();
					vSendCommand(strMensagem + System.Environment.NewLine);

					vSendCommand("From: " + m_strRemetente + System.Environment.NewLine);
					vSendCommand("To:");
					for (int nCont = 0; nCont < m_arlDestinatarios.Count; nCont++)
					{
						if (nCont < m_arlDestinatarios.Count - 1)
						{
							vSendCommand(" " + m_arlDestinatarios[nCont].ToString() + ";");
						}
						else
						{
							vSendCommand(" " + m_arlDestinatarios[nCont].ToString() + System.Environment.NewLine);
						}
					}
					vSendCommand("Subject: " + m_strAssunto + System.Environment.NewLine);
					vSendCommand(strCorpoMensagem() + System.Environment.NewLine);
					vSendCommand("." + System.Environment.NewLine);

					// RESPOSTA
					strMensagem = strAdquireResposta();
					if (strMensagem.Substring(0,3) != "250")
					{
						if (m_tcpClient != null)
						{
							m_tcpClient.Close();
							m_tcpClient = null;
							return ("SErro: Problema ao enviar dados.");
						}
					}
					return(strRetorno);
				}
			#endregion
			#region Connection End
				private void vEncerraConexaoServidorSMTP()
				{
					// Encerra Conexão
					vSendCommand("QUIT" + System.Environment.NewLine);
					if (m_tcpClient != null)
					{
						m_tcpClient.Close();
						m_tcpClient = null;
					}
				}
			#endregion
		#endregion
		#region Corpo da Mensagem
		private string strCorpoMensagem()
		{
			string strCorpoDaMensagem = "MIME-Version: 1.0";
			if (m_strMensagemHtml.Trim() != "")
			{
				strCorpoDaMensagem += System.Environment.NewLine + "Content-type: multipart/alternative; boundary=Separator";
			}else{
				strCorpoDaMensagem += System.Environment.NewLine + "Content-type: multipart/mixed; boundary=Separator";
			}
		
			strCorpoDaMensagem += System.Environment.NewLine + "";
			strCorpoDaMensagem += System.Environment.NewLine + "X-Sistema: Siscobras Tecnologia em Comercio Exterior";
			strCorpoDaMensagem += System.Environment.NewLine + "X-Analista: Thiago Henrique da Silva";

			strCorpoDaMensagem += System.Environment.NewLine + "--Separator";
			strCorpoDaMensagem += System.Environment.NewLine + "Content-Type: text/plain; charset= \"us-ascii\"";
			strCorpoDaMensagem += System.Environment.NewLine;
			strCorpoDaMensagem += System.Environment.NewLine + m_strMensagem;
			strCorpoDaMensagem += System.Environment.NewLine + "";

			// Mensagem HTML
			if (m_strMensagemHtml.Trim() != "")
			{
				strCorpoDaMensagem += System.Environment.NewLine + "--Separator";
				strCorpoDaMensagem += System.Environment.NewLine + "Content-Type: text/html; charset = \"iso-8859-1\"";

				strCorpoDaMensagem += System.Environment.NewLine + "";
				strCorpoDaMensagem += System.Environment.NewLine + m_strMensagemHtml;
				strCorpoDaMensagem += System.Environment.NewLine + "";
			}

			// Arquivos Atachados
			if (m_arlArquivosAtachados != null)
			{
				for (int nCount = 0; nCount < m_arlArquivosAtachados.Count; nCount++)
					strCorpoDaMensagem += System.Environment.NewLine + strRetornaDadosArquivoAtachado(m_arlArquivosAtachados[nCount].ToString());
			}
			strCorpoDaMensagem += System.Environment.NewLine + "--Separator--";
			return strCorpoDaMensagem;
		}
		#endregion
		#region Arquivos Atachados
		private string strRetornaDadosArquivoAtachado(string strPathArquivoAtachado)
		{
			string strRetorno = "", strNomeArquivo = "", strArquivoBase64 = "";
			strNomeArquivo = strRetornaNomeArquivoAtachado(strPathArquivoAtachado);
			strArquivoBase64 = strRetornaDadosArquivoEmBase64(strPathArquivoAtachado);

			if (strArquivoBase64 != "")
			{

				strRetorno += System.Environment.NewLine;
				strRetorno += System.Environment.NewLine + "--Separator";
				strRetorno += System.Environment.NewLine + "Content-Type:X-Siscobras/X-Arquivo;";
				strRetorno += System.Environment.NewLine + "\tname=\"" + strNomeArquivo + "\"";
				strRetorno += System.Environment.NewLine + "Content-Transfer-Encoding: base64";
				strRetorno += System.Environment.NewLine + "Content-Disposition: attachment;";
				strRetorno += System.Environment.NewLine + "\tfilename=\"" + strNomeArquivo + "\"";
				strRetorno += System.Environment.NewLine;

				while (strArquivoBase64.Length > 0)
				{
					if (strArquivoBase64.Length > 76)
					{
						strRetorno += System.Environment.NewLine + strArquivoBase64.Substring(0,76);
						strArquivoBase64 = strArquivoBase64.Substring(76);
					}
					else
					{
						strRetorno += System.Environment.NewLine + strArquivoBase64;
						strArquivoBase64 = "";
					}
				}
				strRetorno += System.Environment.NewLine;
				strRetorno += System.Environment.NewLine;
			}
			return (strRetorno);
		}
		private string strRetornaNomeArquivoAtachado(string strPathNomeArquivo)
		{
			string strTemp = "";
			int lgPosicaoBarra = 0;
			strTemp = strPathNomeArquivo;
			lgPosicaoBarra = strTemp.IndexOf("\\",lgPosicaoBarra);
			while (lgPosicaoBarra != -1 && strTemp.Length > lgPosicaoBarra)
			{
				strTemp = strTemp.Substring(lgPosicaoBarra + 1);
				lgPosicaoBarra = strTemp.IndexOf("\\",lgPosicaoBarra);
			}
			return strTemp;
		}
		private string strRetornaDadosArquivoEmBase64(string strPathArquivo)
		{
			byte[] bytDados;
			long arrLenght = 0, bytesLidos = 0;
			System.IO.FileStream filStrArquivo = null;
			if (System.IO.File.Exists(strPathArquivo))
			{
				filStrArquivo = new System.IO.FileStream(strPathArquivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				bytDados = new byte[filStrArquivo.Length];
				bytesLidos = filStrArquivo.Read(bytDados, 0, (int)filStrArquivo.Length);
				filStrArquivo.Close();
				// Convertendo
				arrLenght = 4 * bytDados.Length;
				arrLenght /= 3;
				if ((arrLenght % 4) != 0)
					arrLenght += 4 - arrLenght % 4;

				char[] base64CharArray = new char[arrLenght];
				System.Convert.ToBase64CharArray(bytDados, 0, bytDados.Length, base64CharArray, 0);
				return (new String(base64CharArray));
			}else{
				return("CErro: Arquivo [" + strPathArquivo + "] inexistente.");
			}
		}
		#endregion

		#region Conversoes
			private string strStringToBase64(string strString)
			{
				long arrLenght = 0;
				byte[] bytDados = new byte[strString.Length];
				for(int nCont = 0; nCont < strString.Length;nCont++)
				{
					bytDados[nCont] = (byte)strString[nCont];
				}
				// Convertendo
				arrLenght = 4 * bytDados.Length;
				arrLenght /= 3;
				if ((arrLenght % 4) != 0)
					arrLenght += 4 - arrLenght % 4;
				char[] base64CharArray = new char[arrLenght];
				System.Convert.ToBase64CharArray(bytDados, 0, bytDados.Length, base64CharArray, 0);
				return (new String(base64CharArray));
			}

			private string strBase64ToString(string strStringBase64)
			{
				try
				{
					if (strStringBase64 != "")
					{
						Byte[] byDados;
						byDados = System.Convert.FromBase64CharArray(strStringBase64.ToCharArray(), 0, strStringBase64.Length);
						char[] chrDados = new char[byDados.Length];
						for(int nCont = 0; nCont < byDados.Length;nCont++)
						{
							chrDados[nCont] = (char)byDados[nCont];
						} 
						return(new System.String(chrDados));
					}
					else
					{
						return("");
					}
				}
				catch
				{
					return("");
				}
			}

			public string strComputeHashMD5(string strText)
			{
				byte[] byDados = new byte[strText.Length];
				for(int nCont = 0; nCont < strText.Length;nCont++)
				{
					byDados[nCont] = (byte)strText[nCont];
				}
				System.Security.Cryptography.MD5CryptoServiceProvider clsHash = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byDados = clsHash.ComputeHash(byDados);
				char[] charArray = new char[byDados.Length];
				for(int nCont = 0; nCont < byDados.Length;nCont++)
				{
					charArray[nCont] = (char)byDados[nCont];
				}
				return (new String(charArray));
			}
		#endregion

	}
}
