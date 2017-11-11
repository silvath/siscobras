using System;

namespace mdlWebServiceEnviaDados
{
	/// <summary>
	/// Summary description for clsWebServiceEnviaDadosErros.
	/// </summary>
	public class clsWebServiceEnviaDadosErros
	{
		#region Constants
			private const string SERVICE_TRATADOR_ERROS = "SiscoTratamentoErros";
			private const string INDEFINIDO = "Indefinido";
		#endregion
		#region Atributes
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel;
		#endregion
		#region Constructors and Destructors
			public clsWebServiceEnviaDadosErros(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel)
			{
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Envio Erros
			public bool bEnviaDados()
			{
				bool bReTry = false;
				int nErrorsDB = 0,nErrosSent = 0;
				System.Collections.ArrayList arlURLs;
				mdlSysWebServicesProxy.clsSysWebServicesProxy cls_Proxy = new mdlSysWebServicesProxy.clsSysWebServicesProxy(ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,true);
				if (cls_Proxy.GetURLListFromService(SERVICE_TRATADOR_ERROS,out arlURLs))
				{
					mdlDataBaseAccess.Tabelas.XsdTbErros typDatSetErros = m_cls_dba_ConnectionDB.GetTbErros(null,null,null,null,null);
					nErrorsDB = typDatSetErros.tbErros.Rows.Count;
					if (typDatSetErros.tbErros.Rows.Count > 0)
					{
						mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow dtrwErro = null;
						wbsvSiscoTratamentoErros.wbsvSiscoTratamentoErros wbsvTratadorErro;

						// Error Data 
						string strCodigoCliente = "";
						System.DateTime dtOcorrencia = System.DateTime.Now;
						string strNomeMaquina = "";
						int nIdUsuario = -1;
						string strUsuario = "";
						string strVersaoServidor = "";
						string strVersaoCliente = "";
						string strExceptionSource = "";
						string strExceptionMessage = "";
						string strExceptionStackTrace = "";
						string strExceptionTargetSite = "";
						string strExceptionHelpLink = "";
						string strExceptionString = "";

						// Getting the Client Code
						strCodigoCliente = m_cls_dba_ConnectionDB.GetConfiguracao("STRIDCLIENTE",INDEFINIDO);

						foreach(string strUrl in arlURLs)
						{
							wbsvTratadorErro = new mdlWebServiceEnviaDados.wbsvSiscoTratamentoErros.wbsvSiscoTratamentoErros();
							wbsvTratadorErro.Url = strUrl;

							for(int nCont = 0; nCont < typDatSetErros.tbErros.Rows.Count;nCont++)
							{
								dtrwErro = (mdlDataBaseAccess.Tabelas.XsdTbErros.tbErrosRow)typDatSetErros.tbErros.Rows[nCont];
								if (dtrwErro.RowState != System.Data.DataRowState.Deleted)
								{
									// Get the Error Data 
									if (!dtrwErro.IsmstrCodigoClienteNull())
										strCodigoCliente = strCodigoCliente;
									else
										strCodigoCliente = INDEFINIDO;
									if (!dtrwErro.IsdtOcorrenciaNull())
										dtOcorrencia = dtrwErro.dtOcorrencia;
									else
										dtOcorrencia = System.DateTime.Now;
									if (!dtrwErro.IsmstrNomeMaquinaNull())
	                                    strNomeMaquina = dtrwErro.mstrNomeMaquina;
									else
										strNomeMaquina = INDEFINIDO;
									if (!dtrwErro.IsnIdUsuarioNull())
										nIdUsuario = dtrwErro.nIdUsuario;
									else
										nIdUsuario = -1;
									if (!dtrwErro.IsmstrUsuarioNull())
										strUsuario = dtrwErro.mstrUsuario;
									else
										strUsuario = INDEFINIDO;
									if (!dtrwErro.IsstrVersaoServidorNull())
										strVersaoServidor = dtrwErro.strVersaoServidor;
									else
										strVersaoServidor = "";
									if (!dtrwErro.IsstrVersaoClienteNull())
										strVersaoCliente = dtrwErro.strVersaoCliente;
									else
										strVersaoCliente = "";
									if (!dtrwErro.IsmstrExceptionSourceNull())
										strExceptionSource = dtrwErro.mstrExceptionSource;
									else
										strExceptionSource = INDEFINIDO;
									if (!dtrwErro.IsmstrExceptionMessageNull())
										strExceptionMessage = dtrwErro.mstrExceptionMessage;
									else
										strExceptionMessage = INDEFINIDO;
									if (!dtrwErro.IsmstrExceptionStackTraceNull())
										strExceptionStackTrace = dtrwErro.mstrExceptionStackTrace;
									else
										strExceptionStackTrace = INDEFINIDO;
									if (!dtrwErro.IsmstrExceptionTargetSiteNull())
										strExceptionTargetSite = dtrwErro.mstrExceptionTargetSite;
									else
										strExceptionTargetSite = INDEFINIDO;
									if (!dtrwErro.IsmstrExceptionTargetSiteNull())
										strExceptionHelpLink = dtrwErro.mstrExceptionHelpLink;
									else
										strExceptionHelpLink = INDEFINIDO;
									if (!dtrwErro.IsmstrExceptionStringNull())
										strExceptionString = dtrwErro.mstrExceptionString;
									else
										strExceptionString = INDEFINIDO;
									try
									{
										if (wbsvTratadorErro.bInsereErro(strCodigoCliente,dtOcorrencia,strNomeMaquina,nIdUsuario,strUsuario,strVersaoServidor,strVersaoCliente,strExceptionSource,strExceptionMessage,strExceptionStackTrace,strExceptionTargetSite,strExceptionHelpLink,strExceptionString))
										{
											// Succesfull send 
											dtrwErro.Delete();
											nErrosSent++;
										}
										else
										{
											// Error On Send
											bReTry = true;
										}
									}catch{
										bReTry = true;
									}
								}
							}
							if (!bReTry)
							{
								break;
							}
						}
						m_cls_dba_ConnectionDB.SetTbErros(typDatSetErros);
					}
				}
				return(nErrorsDB == nErrosSent);
			}
		#endregion
	}
}
