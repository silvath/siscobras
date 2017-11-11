using System;

namespace mdlEmailInterface
{
	/// <summary>
	/// Summary description for clsEmailInterface.
	/// </summary>
	public class clsEmailInterface
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
		protected string m_strEnderecoExecutavel;

		private Microsoft.Win32.RegistryKey m_rgKyRegistrosCurrentUser = null;

		private bool m_bThreadRunning = false;

		private bool m_bRemoveAtachmentsAfterSend = false;
		private bool m_bMostrarBaloes = true;

		protected int m_nIdUsuario = -1;

		private bool m_bConfiguracaoInicial = false;
		private bool m_bVerificarConfiguracao = true;

		private bool m_bAtivado = true;

		private bool m_bAutenticacao = false;

		private mdlEmail.AUTENTICACAO m_enumTipoAutenticacao = mdlEmail.AUTENTICACAO.Automatica;

		/// <summary>
		/// Setar remetente do E-mail
		/// </summary>
		public string Remetente
		{
			get
			{
				return m_strCampoDe;
			}
			set
			{
				m_strCampoDe = value;
			}
		}
		/// <summary>
		/// Setar Destinatários do E-mail
		/// </summary>
		public System.Collections.ArrayList Destinatarios
		{
			get
			{
				return m_arlCampoPara;
			}
			set
			{
				m_arlCampoPara = value;
			}
		}
		/// <summary>
		/// Setar Arquivo a serem anexados
		/// </summary>
		public System.Collections.ArrayList Arquivos
		{
			get
			{
				return m_arlArquivosAnexados;
			}
			set
			{
				m_arlArquivosAnexados = value;
			}
		}
		/// <summary>
		/// Setar Assunto do E-mail
		/// </summary>
		public string Assunto
		{
			get
			{
				return m_strCampoAssunto;
			}
			set
			{
				m_strCampoAssunto = value;
			}
		}
		/// <summary>
		/// Setar texto da mensagem
		/// </summary>
		public string Mensagem
		{
			get
			{
				return m_strMensagem;
			}
			set
			{
				m_strMensagem = value;
			}
		}
		/// <summary>
		/// Setar Id Usuario
		/// </summary>
		public int Usuario
		{
			get
			{
				return m_nIdUsuario;
			}
			set
			{
				m_nIdUsuario = value;
				carregaTypDatSet();
				carregaDadosBD();
				m_bConfiguracaoInicial = !verificaConfiguracao();
				if (m_bConfiguracaoInicial)
					carregaDadosDoRegistro();
			}
		}
		/// <summary>
		/// Setar apagar arquivos anexados após envio
		/// </summary>
		public bool RemoveAtachmentsAfterSend
		{
			get
			{
				return m_bRemoveAtachmentsAfterSend;
			}
			set
			{
				m_bRemoveAtachmentsAfterSend = value;
			}
		}
		private string m_strCampoDe = "";
		private System.Collections.ArrayList m_arlCampoPara = null;
		private System.Collections.ArrayList m_arlArquivosAnexados = null;
		private System.Collections.ArrayList m_arlArquivosUsuario = null;
		private string m_strCampoAssunto = "";
		private string m_strMensagem = "";
		private string m_strRetorno = "";

		/// <summary>
		/// Configuração do e-mail
		/// </summary>
 		private string m_strSMTP = "";
		private string m_strUsuario = "";
		private string m_strSenha = "";

		private mdlEmail.clsEmailSocket m_clsEmailSocket = null;

		private System.Threading.Thread m_thrEnviaEmail = null;

		public bool m_bModificado = false;

		private mdlDataBaseAccess.Tabelas.XsdTbUsuarios m_typDatSetTbUsuarios = null;

		private frmFEmailInterface m_formFEmailInterface = null;
		private frmFEnviandoEmail m_formFEnviandoEmail = null;
		private frmFEmailConfiguracao m_formFEmailConfiguracao = null;
		#endregion

		#region Construtores & Destrutores
		public clsEmailInterface(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_arlCampoPara = new System.Collections.ArrayList();
			m_arlArquivosAnexados = new System.Collections.ArrayList();
			m_arlArquivosUsuario = new System.Collections.ArrayList();
			carregaTypDatSet();
			carregaDadosBD();
			m_bConfiguracaoInicial = m_bVerificarConfiguracao = !verificaConfiguracao();
			if (m_bConfiguracaoInicial)
				carregaDadosDoRegistro();
			mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
		}
		#endregion

		#region InitializeEventsFormEmailInterface
		private void InitializeEventsFormEmailInterface()
		{
			// Carrega Dados BD
			m_formFEmailInterface.eCallCarregaDadosBD += new frmFEmailInterface.delCallCarregaDadosBD(carregaDadosBD);

			// Carrega Dados Interface
			m_formFEmailInterface.eCallCarregaDadosInterface += new frmFEmailInterface.delCallCarregaDadosInterface(carregaDadosInterface);

			// Salva Dados Interface
			m_formFEmailInterface.eCallSalvaDadosInterface += new frmFEmailInterface.delCallSalvaDadosInterface(salvaDadosInterface);

			// Salva Dados BD
			m_formFEmailInterface.eCallSalvaDadosBD += new frmFEmailInterface.delCallSalvaDadosBD(salvaDadosBD);

			// Seta Dados Enviar E-mail
			m_formFEmailInterface.eCallSetaDadosEnviarEmail += new frmFEmailInterface.delCallSetaDadosEnviarEmail(setaDadosEnviarEmail);

			// Anexo arquivo(s)
			m_formFEmailInterface.eCallInsereNovoArquivo += new frmFEmailInterface.delCallInsereNovoArquivo(insereNovoArquivoAnexo);

			// Remove Arquivo(s)
			m_formFEmailInterface.eCallExcluiArquivosInseridos += new frmFEmailInterface.delCallExcluiArquivosInseridos(excluiArquivos);

			// Configura Sisco-Mail
			m_formFEmailInterface.eCallConfiguraEmail += new frmFEmailInterface.delCallConfiguraEmail(ShowDialogConfiguracao);

			// Habilita botão
			m_formFEmailInterface.eCallHabilitaBotao += new frmFEmailInterface.delCallHabilitaBotao(habilitaBotao);
		}
		#endregion

		#region InitializeEventsFormEnviandoEmail
		private void InitializeEventsFormEnviandoEmail()
		{
			// Mata Thread
			m_formFEnviandoEmail.eCallAbortaExecucaoThread += new frmFEnviandoEmail.delCallAbortaExecucaoThread(mataThread);
		}
		#endregion

		#region InitializeEventsFormEmailConfiguracao
		private void InitializeEventsFormEmailConfiguracao()
		{
			// Carrega Dados Interface
			m_formFEmailConfiguracao.eCallCarregaDadosInterface += new frmFEmailConfiguracao.delCallCarregaDadosInterface(carregaDadosInterfaceConfiguracao);

			// Altera Dados Interface
			m_formFEmailConfiguracao.eCallAlteraDadosInterface += new frmFEmailConfiguracao.delCallAlteraDadosInterface(AlteraDadosInterfaceConfiguracao);

			// Salva Dados Interface
			m_formFEmailConfiguracao.eCallSalvaDadosInterface += new frmFEmailConfiguracao.delCallSalvaDadosInterface(salvaDadosInterfaceConfiguracao);
		}
		#endregion

		#region ShowDialog
		public void ShowDialog()
		{
			try
			{
				if (m_bConfiguracaoInicial)
					ShowDialogConfiguracao();
				m_formFEmailInterface = new frmFEmailInterface(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, !m_bConfiguracaoInicial, m_bVerificarConfiguracao, m_bMostrarBaloes);
				InitializeEventsFormEmailInterface();
				setaCamposEMail();
				m_formFEmailInterface.ShowDialog();
				m_formFEmailInterface = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				return;
			}
		}
		private void setaCamposEMail()
		{
			try
			{
				if (this.Assunto != "")
                    m_formFEmailInterface.Assunto = this.Assunto;
				if (this.Mensagem != "")
					m_formFEmailInterface.Mensagem = this.Mensagem;
				if (this.Destinatarios != null)
					if (this.Destinatarios.Count > 0)
                        m_formFEmailInterface.Destinatarios = this.Destinatarios;
				if (this.Remetente != "")
					m_formFEmailInterface.Remetente = this.Remetente;
				if (this.Arquivos != null)
					if (this.Arquivos.Count > 0)
                        m_formFEmailInterface.Arquivos = this.Arquivos;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Show Dialog Configuração
		private void ShowDialogConfiguracao()
		{
			try
			{
				if (m_formFEmailInterface == null)
                    m_formFEmailConfiguracao = new frmFEmailConfiguracao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_bConfiguracaoInicial);
				else
					m_formFEmailConfiguracao = new frmFEmailConfiguracao(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_formFEmailInterface, m_bConfiguracaoInicial);
				InitializeEventsFormEmailConfiguracao();
				m_formFEmailConfiguracao.ShowDialog();
				m_formFEmailConfiguracao = null;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Novo Arquivo
		private void insereNovoArquivoAnexo(ref mdlComponentesGraficos.ListView lvAnexos, ref System.Windows.Forms.OpenFileDialog opfdlgArquivos)
		{
			try
			{
				if (opfdlgArquivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					for (int nCount = 0; nCount < opfdlgArquivos.FileNames.Length; nCount++)
					{
						lvAnexos.Items.Add(opfdlgArquivos.FileNames[nCount]);
						m_arlArquivosUsuario.Add(opfdlgArquivos.FileNames[nCount]);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Exclui Arquivo
		private void excluiArquivos(ref mdlComponentesGraficos.ListView lvArquivos)
		{
			try
			{
				int nIndex = -1;
				while(lvArquivos.SelectedItems.Count > 0)
				{
					m_arlArquivosUsuario.Remove(lvArquivos.SelectedItems[0].Text);
					nIndex = lvArquivos.SelectedIndices[0];
					lvArquivos.Items[nIndex].Remove();
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region SetaDadosEmail
		private bool setaDadosEnviarEmail(ref mdlComponentesGraficos.TextBox tbCampoPara, ref mdlComponentesGraficos.ListView lvArquivos, ref mdlComponentesGraficos.TextBox tbCampoAssunto, ref System.Windows.Forms.TextBox tbCampoMensagem)
		{
			try
			{
				m_arlArquivosAnexados.Clear();
				m_arlCampoPara.Clear();
				string strTeste = "";
				if (!pegaEnderecosEmail(ref tbCampoPara))
					return false;
				setaDadosEmail(ref lvArquivos, ref tbCampoAssunto, ref tbCampoMensagem);
				strTeste = strEnviaEmail();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		private void setaDadosEmail(ref mdlComponentesGraficos.ListView lvArquivos, ref mdlComponentesGraficos.TextBox tbCampoAssunto, ref System.Windows.Forms.TextBox tbCampoMensagem)
		{
			try
			{
				for (int nCount = 0; nCount < lvArquivos.Items.Count; nCount++)
					m_arlArquivosAnexados.Add(lvArquivos.Items[nCount].Text);
				m_strCampoAssunto = tbCampoAssunto.Text;
				m_strMensagem = tbCampoMensagem.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool pegaEnderecosEmail(ref mdlComponentesGraficos.TextBox tbCampoPara)
		{
			try
			{
				string strEmailTemp = "";
				int nIndexArroba = 0, nIndexSubstring = 0, nIndexInicial = 0;
				while (nIndexArroba != -1 && nIndexSubstring != -1)
				{
					nIndexArroba = tbCampoPara.Text.IndexOf("@",nIndexSubstring);
					if (nIndexArroba == -1)
						return false;
					nIndexSubstring = tbCampoPara.Text.IndexOf(";",nIndexSubstring);
					if (nIndexSubstring != -1)
                        strEmailTemp = tbCampoPara.Text.Substring(nIndexInicial,nIndexSubstring);
					else
						strEmailTemp = tbCampoPara.Text.Substring(nIndexInicial);
					m_arlCampoPara.Add(strEmailTemp.Trim());
					if (nIndexSubstring != -1)
                        nIndexInicial = ++nIndexSubstring;
				}
				return true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		#endregion

		#region Envia E-Mail
		private string strEnviaEmail()
		{
			try
			{
				m_clsEmailSocket = new mdlEmail.clsEmailSocket();
				m_clsEmailSocket.ArquivosAtachados = m_arlArquivosAnexados;
				m_clsEmailSocket.Assunto = m_strCampoAssunto;
				m_clsEmailSocket.Destinatarios = m_arlCampoPara;
				m_clsEmailSocket.Mensagem = m_strMensagem;
				m_clsEmailSocket.Remetente = m_strCampoDe;
				m_clsEmailSocket.SMTP = m_strSMTP;
				if (m_enumTipoAutenticacao != mdlEmail.AUTENTICACAO.Nenhuma)
				{
					m_clsEmailSocket.AutenticacaoTipo = m_enumTipoAutenticacao;
					m_clsEmailSocket.UsuarioAutenticacao = m_strUsuario;
					m_clsEmailSocket.SenhaAutenticacao = m_strSenha;
				}
				m_thrEnviaEmail = new System.Threading.Thread(new System.Threading.ThreadStart(enviaEmail));
				m_formFEnviandoEmail = new frmFEnviandoEmail(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
				InitializeEventsFormEnviandoEmail();
				m_formFEnviandoEmail.Show();
				m_thrEnviaEmail.Priority = System.Threading.ThreadPriority.Highest;
				m_thrEnviaEmail.Start();
				m_bThreadRunning = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return m_strRetorno;
		}
		private void enviaEmail()
		{
			try
			{
				m_strRetorno = m_clsEmailSocket.strEnviaEmail();
				if (m_strRetorno.Trim() != "OK")
				{
					if (m_strRetorno.IndexOf("utentica") != -1 && m_bAutenticacao == false)
					{
						//m_clsEmailSocket.AutenticacaoTipo = !m_bAutenticacao;
						m_clsEmailSocket.AutenticacaoTipo = mdlEmail.AUTENTICACAO.Automatica;
						m_clsEmailSocket.UsuarioAutenticacao = m_strUsuario;
						m_clsEmailSocket.SenhaAutenticacao = m_strSenha;
						m_strRetorno = m_clsEmailSocket.strEnviaEmail();
						if (m_strRetorno.Trim() != "OK")
						{
							m_formFEnviandoEmail.m_gbFields.Text = "Erro no envio do e-mail";
							m_formFEnviandoEmail.m_lMensagem.Text = "Erro: " + m_strRetorno;
						}
					}
					else
					{
						m_formFEnviandoEmail.m_gbFields.Text = "Erro no envio do e-mail";
						m_formFEnviandoEmail.m_lMensagem.Text = "Erro: " + m_strRetorno;
					}
				}
				else
				{
					m_formFEnviandoEmail.Close();
				}
				m_bThreadRunning = false;
				if ((m_strRetorno.Trim() == "OK") && (m_bRemoveAtachmentsAfterSend))
				{
					foreach(string strArquivo in m_arlArquivosAnexados)
					{
						if ((System.IO.File.Exists(strArquivo)) && (!m_arlArquivosUsuario.Contains(strArquivo)))
							System.IO.File.Delete(strArquivo);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool mataThread()
		{
			try
			{
				if (m_bThreadRunning)
				{
					m_thrEnviaEmail.Suspend();
					m_bThreadRunning = false;
					m_formFEnviandoEmail.m_gbFields.Text = "Cancelado";
					m_formFEnviandoEmail.m_lMensagem.Text = "Envio de E-Mail cancelado.";
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		#endregion

		#region Configuracao
		#region Registro do Windows
		private void carregaDadosDoRegistro()
		{
			try
			{
				System.Text.ASCIIEncoding decoderASCII = new System.Text.ASCIIEncoding();
				bool bExiste = false, bPadraoOutlook = false;
				string strChave = "";
				m_rgKyRegistrosCurrentUser = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Account Manager\\Accounts\\00000001");
				if (m_rgKyRegistrosCurrentUser == null)
				{
					m_rgKyRegistrosCurrentUser = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Outlook\\OMI Account Manager\\Accounts\\00000001");
					if (m_rgKyRegistrosCurrentUser == null)
					{
						m_rgKyRegistrosCurrentUser = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows Messaging Subsystem\\Profiles\\Outlook");
						if (m_rgKyRegistrosCurrentUser == null)
						{
							return;
						}
						else
						{
							Microsoft.Win32.RegistryKey rgKeyTemp;
							string[] strSubKeys = m_rgKyRegistrosCurrentUser.GetSubKeyNames();
							foreach(string strSubKey in strSubKeys)
							{
								rgKeyTemp = m_rgKyRegistrosCurrentUser.OpenSubKey(strSubKey);
								rgKeyTemp = rgKeyTemp.OpenSubKey("00000004");
								if (rgKeyTemp != null)
								{
									m_rgKyRegistrosCurrentUser = rgKeyTemp;
									bExiste = true;
									bPadraoOutlook = true;
									break;
								}
							}
							if (!bExiste)
							{
								return;
							}
						}
					}
				}
				if (m_rgKyRegistrosCurrentUser != null)
				{
					m_enumTipoAutenticacao = mdlEmail.AUTENTICACAO.Nenhuma;
					try
					{
						if (bPadraoOutlook)
						{
							strChave = "";
							byte[] byArray = (byte[])m_rgKyRegistrosCurrentUser.GetValue("SMTP Server");
							strChave = decoderASCII.GetString(byArray, 0, byArray.Length).Replace("\0","");  
						}
						else
							strChave = m_rgKyRegistrosCurrentUser.GetValue("SMTP Server").ToString();
						m_bConfiguracaoInicial = false;
					}
					catch
					{
						strChave = "";
					}
					m_strSMTP = strChave;
					try
					{
						if (bPadraoOutlook)
						{
							strChave = "";
							byte[] byArray = (byte[])m_rgKyRegistrosCurrentUser.GetValue("POP3 User");
							strChave = decoderASCII.GetString(byArray, 0, byArray.Length).Replace("\0","");  
						}
						else
							strChave = m_rgKyRegistrosCurrentUser.GetValue("POP3 User Name").ToString();
					}
					catch
					{
						strChave = "";
					}
					m_strUsuario = strChave;
					try
					{
						if (bPadraoOutlook)
						{
							strChave = "";
							byte[] byArray = (byte[])m_rgKyRegistrosCurrentUser.GetValue("Email");
							strChave = decoderASCII.GetString(byArray, 0, byArray.Length).Replace("\0","");  
						}
						else
							strChave = m_rgKyRegistrosCurrentUser.GetValue("SMTP Email Address").ToString();
					}
					catch
					{
						strChave = "";
					}
					m_strCampoDe = strChave;
					try
					{
						byte[] byTemp;
						if (bPadraoOutlook)
							byTemp = (byte[])m_rgKyRegistrosCurrentUser.GetValue("POP3 Password");
						else
							byTemp = (byte[])m_rgKyRegistrosCurrentUser.GetValue("SMTP Password2");
						strChave = decoderASCII.GetString(byTemp, 0, byTemp.Length).Replace("\0","");
						m_rgKyRegistrosCurrentUser.Close();
					}
					catch
					{
						strChave = "";
					}
				}
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Verifica
		private bool verificaConfiguracao()
		{
			try
			{
				if (m_strSMTP.Trim() == "")
				{
					return false;
				}
				if (m_strUsuario.Trim() == "")
				{
					return false;
				}
				if (m_strSenha.Trim() == "")
				{
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
		}
		#endregion
		#region Habilita Botão
		private void habilitaBotao(ref System.Windows.Forms.Button btOk)
		{
			try
			{
				btOk.Enabled = !m_bConfiguracaoInicial;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Carregamento de Dados
		#region Interface
		protected void carregaDadosInterfaceConfiguracao(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				try
				{
					cbAuth.Items.Clear();
					cbAuth.AddItem(mdlEmail.AUTENTICACAO.Nenhuma.ToString(), mdlEmail.AUTENTICACAO.Nenhuma);
					cbAuth.AddItem(mdlEmail.AUTENTICACAO.Automatica.ToString(), mdlEmail.AUTENTICACAO.Automatica);
					cbAuth.AddItem(mdlEmail.AUTENTICACAO.LOGIN.ToString(), mdlEmail.AUTENTICACAO.LOGIN);
					cbAuth.AddItem(mdlEmail.AUTENTICACAO.CRAM_MD5.ToString(), mdlEmail.AUTENTICACAO.CRAM_MD5);
					cbAuth.AddItem(mdlEmail.AUTENTICACAO.DIGEST_MD5.ToString(), mdlEmail.AUTENTICACAO.DIGEST_MD5);
					switch (m_enumTipoAutenticacao)
					{
						case mdlEmail.AUTENTICACAO.Nenhuma:
							cbAuth.SelectedIndex = 0;
							break;
						case mdlEmail.AUTENTICACAO.Automatica:
							cbAuth.SelectedIndex = 1;
							break;
						case mdlEmail.AUTENTICACAO.LOGIN:
							cbAuth.SelectedIndex = 2;
							break;
						case mdlEmail.AUTENTICACAO.CRAM_MD5:
							cbAuth.SelectedIndex = 3;
							break;
						case mdlEmail.AUTENTICACAO.DIGEST_MD5:
							cbAuth.SelectedIndex = 4;
							break;
						default:
							cbAuth.SelectedIndex = 0;
							break;
					}
					if (((mdlEmail.AUTENTICACAO)cbAuth.ReturnObjectSelectedItem()) != mdlEmail.AUTENTICACAO.Nenhuma)
					{
						tbSMTP.Text = m_strSMTP;
						tbUsuario.Text = m_strUsuario;
						tbSenha.Text = m_strSenha;
						m_bAutenticacao = true;
					}
					else
					{
						tbSMTP.Text = m_strSMTP;
						tbUsuario.Text = m_strUsuario;
						tbSenha.Text = m_strSenha;
						tbUsuario.Enabled = false;
						tbSenha.Enabled = false;
						m_bAutenticacao = false;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		protected void AlteraDadosInterfaceConfiguracao(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				try
				{
					if (((mdlEmail.AUTENTICACAO)cbAuth.ReturnObjectSelectedItem()) != mdlEmail.AUTENTICACAO.Nenhuma)
					{
						//tbSMTP.Text = m_strSMTP;
						tbUsuario.Enabled = true;
						//tbUsuario.Text = m_strUsuario;
						tbSenha.Enabled = true;
						//tbSenha.Text = m_strSenha;
						m_bAutenticacao = true;
					}
					else
					{
						//tbSMTP.Text = m_strSMTP;
						tbUsuario.Enabled = false;
						//tbUsuario.Text = m_strUsuario;
						tbSenha.Enabled = false;
						//tbSenha.Text = m_strSenha;
						m_bAutenticacao = false;
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		#endregion
		#endregion
		#region Salvamento de Dados
		protected void salvaDadosInterfaceConfiguracao(ref mdlComponentesGraficos.TextBox tbSMTP, ref mdlComponentesGraficos.TextBox tbUsuario, ref mdlComponentesGraficos.TextBox tbSenha, ref mdlComponentesGraficos.ComboBox cbAuth)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				try
				{
					m_strSMTP = tbSMTP.Text.Clone().ToString();
					m_strUsuario = tbUsuario.Text;
					m_strSenha = tbSenha.Text;
					m_enumTipoAutenticacao = (mdlEmail.AUTENTICACAO)cbAuth.ReturnObjectSelectedItem();
					m_bConfiguracaoInicial = false;
					m_bVerificarConfiguracao = false;
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		#endregion
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		protected void carregaTypDatSet()
		{
			try 
			{
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();
			
				arlCondicaoCampo.Add("nIdUsuario");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdUsuario);

				m_typDatSetTbUsuarios = m_cls_dba_ConnectionBD.GetTbUsuarios(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		protected void carregaDadosBD()
		{
			try
			{
				carregaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void carregaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwRowTbUsuarios;
				if (m_typDatSetTbUsuarios.tbUsuarios.Rows.Count > 0)
				{
					dtrwRowTbUsuarios = (mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow)m_typDatSetTbUsuarios.tbUsuarios.Rows[0];
					if (!dtrwRowTbUsuarios.IsstrEmailNull())
						m_strCampoDe = dtrwRowTbUsuarios.strEmail;
					if (!dtrwRowTbUsuarios.IsstrUserNull())
						m_strUsuario = dtrwRowTbUsuarios.strUser;
					if (!dtrwRowTbUsuarios.IsstrSMTPNull())
						m_strSMTP = dtrwRowTbUsuarios.strSMTP;
					if (!dtrwRowTbUsuarios.IsstrPasswordNull())
						m_strSenha = mdlCriptografia.clsCriptografia.strDecifraString(dtrwRowTbUsuarios.strPassword);
					if (!dtrwRowTbUsuarios.IsnSMTPAutenticacaoNull())
						m_enumTipoAutenticacao = (mdlEmail.AUTENTICACAO)dtrwRowTbUsuarios.nSMTPAutenticacao;
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface
		protected void carregaDadosInterface(ref mdlComponentesGraficos.TextBox tbCampoDe)
		{
			tbCampoDe.Text = m_strCampoDe;
		}
		#endregion
		#endregion
		#region Salvamento dos Dados
		#region Interface
		protected void salvaDadosInterface(ref mdlComponentesGraficos.TextBox tbCampoDe)
		{
			try
			{
				m_strCampoDe = tbCampoDe.Text;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco de Dados
		protected void salvaDadosBD(bool bModificado)
		{
			try
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBDEspecifico()
		{
			try
			{
				mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow dtrwRowTbUsuarios;
				if (m_typDatSetTbUsuarios.tbUsuarios.Rows.Count > 0)
				{
					dtrwRowTbUsuarios = (mdlDataBaseAccess.Tabelas.XsdTbUsuarios.tbUsuariosRow)m_typDatSetTbUsuarios.tbUsuarios.Rows[0];
					if (dtrwRowTbUsuarios != null)
					{
						dtrwRowTbUsuarios.strEmail = m_strCampoDe;
						dtrwRowTbUsuarios.strSMTP = m_strSMTP;
						dtrwRowTbUsuarios.strUser = m_strUsuario;
						dtrwRowTbUsuarios.strPassword = mdlCriptografia.clsCriptografia.strCifraString(m_strSenha);
						dtrwRowTbUsuarios.nSMTPAutenticacao = (int)m_enumTipoAutenticacao;
					}
				}
				else
				{
					dtrwRowTbUsuarios = m_typDatSetTbUsuarios.tbUsuarios.NewtbUsuariosRow();
					dtrwRowTbUsuarios.nIdUsuario = m_nIdUsuario;
					if (m_nIdUsuario == -1)
					{
						dtrwRowTbUsuarios.strNome = "Siscobras";
						dtrwRowTbUsuarios.strSenha = "ORACULO";
					}
					dtrwRowTbUsuarios.strEmail = m_strCampoDe;
					dtrwRowTbUsuarios.strSMTP = m_strSMTP;
					dtrwRowTbUsuarios.strUser = m_strUsuario;
					dtrwRowTbUsuarios.strPassword = mdlCriptografia.clsCriptografia.strCifraString(m_strSenha);
					dtrwRowTbUsuarios.nSMTPAutenticacao = (int)m_enumTipoAutenticacao;
					m_typDatSetTbUsuarios.tbUsuarios.AddtbUsuariosRow(dtrwRowTbUsuarios);
				}
				m_cls_dba_ConnectionBD.SetTbUsuarios(m_typDatSetTbUsuarios);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion

		#region Retorna Valores
		public void retornaValores(out string strRetorno)
		{
			strRetorno = m_strRetorno;
		}
		#endregion
	}
}
