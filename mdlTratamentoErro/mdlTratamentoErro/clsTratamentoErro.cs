using System;

namespace mdlTratamentoErro
{
	/// <summary>
	/// Summary description for clsTratamentoErro.
	/// </summary>
	public class clsTratamentoErro
	{
		#region Constants
			private const string NOME_ARQUIVO_CONFIGURACAO = "Sisco.ini";
		#endregion
		#region Atributos
			// *******************
			// Atributos 
			// *******************
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow m_dtrwErro = null;
			private string m_strEnderecoExecutavel = "";
			private bool m_bClose = false;
			private bool m_bReabrirSiscobras = false; 
			// *******************
		#endregion
		#region Properties
			public mdlDataBaseAccess.clsDataBaseAccess ConnectionDB
			{
				set
				{
					m_cls_dba_ConnectionDB = value;
				}
			}

			public string EnderecoExecutavel
			{
				set
				{
					m_strEnderecoExecutavel = value;
				}
			}
		#endregion
		#region Constructor
		public clsTratamentoErro()
		{
		}
		#endregion

		#region ShowDialogReportandoProblema
			private void ShowDialogReportandoProblema()
			{
				mdlTratamentoErro.Formularios.frmFReportandoProblema formFReportandoProblema = new mdlTratamentoErro.Formularios.frmFReportandoProblema();
				InitializeFormReportandoProblema(ref formFReportandoProblema);
				formFReportandoProblema.ShowDialog();
			}

			private void InitializeFormReportandoProblema(ref mdlTratamentoErro.Formularios.frmFReportandoProblema formFReportandoProblema)
			{
				// Reabrir Siscobras
				formFReportandoProblema.eCallReabrirSiscobras += new Formularios.frmFReportandoProblema.delCallReabrirSiscobras(ReabrirSiscobras);

				// ShowDialogInformacoesProblema
				formFReportandoProblema.eCallShowDialogInformacoesProblema += new Formularios.frmFReportandoProblema.delCallShowDialogInformacoesProblema(ShowDialogInformacoesProblema);
			}
		#endregion
		#region ShowDialogInformacoesProblema
			private void ShowDialogInformacoesProblema()
			{
				mdlTratamentoErro.Formularios.frmFInformacoesProblema formFInformacoesProblema = new mdlTratamentoErro.Formularios.frmFInformacoesProblema();
				InitializeFormInformacoesProblema(ref formFInformacoesProblema);
				formFInformacoesProblema.ShowDialog();
			}

			private void InitializeFormInformacoesProblema(ref mdlTratamentoErro.Formularios.frmFInformacoesProblema formFInformacoesProblema)
			{
				// Retornando o Erro
				formFInformacoesProblema.eCallCarregaInformacoes += new Formularios.frmFInformacoesProblema.delCallCarregaInformacoes(dtrwRetornaErro);
			}
		#endregion

		#region Reabrir Siscobras
			private void ReabrirSiscobras(bool bClose,bool bReabrirSiscobras)
			{
				m_bClose = bClose;
				m_bReabrirSiscobras = bReabrirSiscobras;
			}
		#endregion
		#region Retornando o Erro
			private mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow dtrwRetornaErro()
			{
				return(m_dtrwErro);
			}
		#endregion

		#region Tratamento do Erro 
			public void trataErro(ref System.Exception expErro)
			{
				object objErro = (object)expErro;
				trataErro(ref objErro);
			}

			public void trataErro(ref Object objErro)
			{
				System.Exception exErro = (System.Exception)objErro;
				if (m_cls_dba_ConnectionDB == null)
				{
					// PROGRAMADORES
					string strException = "";
					strException = "ATENÇÃO!!! Resolva o problema encontrado ou relate o problema em Leiame.xml no modulo problemático.";
					strException += System.Environment.NewLine;
					strException += System.Environment.NewLine;
					strException += exErro.ToString() + System.Environment.NewLine;
					System.Windows.Forms.MessageBox.Show(strException,"Siscobras - Problemas na Código");
				}else{
					// USUARIOS
					mdlManipuladorArquivo.clsManipuladorArquivoIni m_cls_man_Arquivo = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + NOME_ARQUIVO_CONFIGURACAO);

					// Erro
					System.DateTime dtOcorrencia = System.DateTime.Now;
					string strExceptionSource = exErro.Source;
					string strExceptionMessage = exErro.Message;
					string strExceptionStackTrace = exErro.StackTrace;
					string strExceptionTargetSite = exErro.TargetSite.ToString();
					string strExceptionHelpLink = "";
					if (exErro.HelpLink != null)
					{
						strExceptionHelpLink = exErro.HelpLink;
					}
					string strExceptionString = exErro.ToString();

					// Identificacao Cliente
                    string strCodigoCliente = m_cls_dba_ConnectionDB.GetConfiguracao("CodigoCliente","");
				    string strNomeMaquina = System.Environment.MachineName;
					int nIdUsuario = -1;
					string strUsuario = "";
		            string strVersaoServidor = m_cls_dba_ConnectionDB.GetConfiguracao("VersaoServidor","");
					string strVersaoCliente = m_cls_man_Arquivo.retornaValor("Siscobras","VersaoCliente","");
					// Inserindo no banco de dados 
					mdlDataBaseAccess.Tabelas.XsdTbErros typDatSetTbErros = m_cls_dba_ConnectionDB.GetTbErros(null,null,null,null,null);
					m_dtrwErro = typDatSetTbErros.tbErros.NewtbErrosRow();

					m_dtrwErro.nIdErro = 1;
					while (typDatSetTbErros.tbErros.FindBynIdErro(m_dtrwErro.nIdErro) != null)
					{
						m_dtrwErro.nIdErro = m_dtrwErro.nIdErro + 1;
					}
					m_dtrwErro.dtOcorrencia = dtOcorrencia;
					m_dtrwErro.mstrExceptionSource = strExceptionSource;
					m_dtrwErro.mstrExceptionMessage = strExceptionMessage;
					m_dtrwErro.mstrExceptionStackTrace = strExceptionStackTrace;
					m_dtrwErro.mstrExceptionTargetSite = strExceptionTargetSite;
					m_dtrwErro.mstrExceptionHelpLink = strExceptionHelpLink;
					m_dtrwErro.mstrExceptionString = strExceptionString;

					m_dtrwErro.mstrCodigoCliente = strCodigoCliente;
					m_dtrwErro.mstrNomeMaquina = strNomeMaquina;
					m_dtrwErro.nIdUsuario = nIdUsuario;
					m_dtrwErro.mstrUsuario = strUsuario;
					m_dtrwErro.strVersaoServidor = strVersaoServidor;
					m_dtrwErro.strVersaoCliente = strVersaoCliente;

					typDatSetTbErros.tbErros.Rows.Add(m_dtrwErro);
					try
					{
						m_cls_dba_ConnectionDB.SetTbErros(typDatSetTbErros);
					}catch (System.Exception expErro){
						// BD COM PROBLEMAS
						this.ConnectionDB = null;
						object objErroDB = (object)expErro;
						this.trataErro(ref objErroDB);
					}
					ShowDialogReportandoProblema();
					if (m_bClose && m_bReabrirSiscobras)
					{
						if (System.IO.File.Exists(m_strEnderecoExecutavel + "Siscobras.exe"))
							System.Diagnostics.Process.Start(m_strEnderecoExecutavel + "Siscobras.exe");
					}
					if (m_bClose)
						System.Environment.Exit(0);
				}
			}
		#endregion
	}
}
