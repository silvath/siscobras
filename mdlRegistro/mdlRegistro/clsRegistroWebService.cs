using System;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for clsRegistroWebService.
	/// </summary>
	public class clsRegistroWebService
	{
		#region Constantes
			private const string WEBSERVICE_REGISTRO = "SiscoRegistro";
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private mdlSysWebServicesProxy.clsSysWebServicesProxy m_cls_wbsv_Proxy = null;
			private System.Collections.ArrayList m_arlWebServices = null;
		#endregion
		#region Constructors and Destructors
			public clsRegistroWebService(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
				m_cls_wbsv_Proxy = new mdlSysWebServicesProxy.clsSysWebServicesProxy(ref cls_dba_ConnectionDB,strEnderecoExecutavel,false);
			}
		#endregion

		#region Refresh Web Services
			private void vRefreshWebServices()
			{
				try
				{
					if (m_arlWebServices == null)
					{
						m_cls_wbsv_Proxy.UpdateWSList();
						if (!m_cls_wbsv_Proxy.GetURLListFromService(WEBSERVICE_REGISTRO,out m_arlWebServices))
							m_arlWebServices = null;
					}
				}catch{
				}
				//TODO: Problemas estao ocorrendo na conexao com o sistema distribuido de WebServices. Empresas com Proxy com autenticacao e firewall
				if (m_arlWebServices == null)
				{
					m_arlWebServices = new System.Collections.ArrayList();
					m_arlWebServices.Add("http://www.siscobras.com.br/wbsvSiscoRegistro.asmx");
				}
			}
		#endregion
		#region Enviando o cadastro dos Dados para o WebService 
			public int nCadastraPessoaJuridica(int nIdTipo,string strCodigo,string strRazaoSocial,string strNomeFantasia,string strEmail,string strSite,int nSetorAtividadeOuServicos,string strSetorAtividadeOuServicos,int nQuantidadeExportacoesAnuaisOuClientesExportadores, int nQuantidadeFuncionarios,System.DateTime dtPrimeiraExportacao,bool bRealizaImportacao,int nMeioRealizacaoPEs, string strMeioRealizacaoPEs,int nComoTomouConhecimentoSiscobras,string strComoTomouConhecimentoSiscobras,string strFuncionarioNome,int nFuncionarioIdCargos,bool bFuncionarioSexoMasculino,System.DateTime dtFuncionarioNascimento,bool bFuncionarioDecisor,System.DateTime dtFuncionarioIngressoEmpresa,string strFuncionarioRamal,string strFuncionarioEmail,int nFuncionarioIdDepartamento,int nFuncionarioIdAdeptoTecnologia,string strLocalizacaoCNPJ,string strLocalizacaoEndereco,string strLocalizacaoComplemento,string strLocalizacaoBairro,string strLocalizacaoCEP,string strLocalizacaoCidade,int nLocalizacaoIdEstado,string strLocalizacaoEmail,string strLocalizacaoSite,int nLocalizacaoIdRamoAtividade,int nLocalizacaoQuantidadeFuncionarios,int nLocalizacaoIdVolumeExportacao,int nLocalizacaoFrequenciaProcessos,bool bLocalizacaoFinanceiro,string strLocalizacaoFaxNumero,string strLocalizacaoTelefoneNumero)
			{
				int nRetorno = clsRegistro.ERRO_CADASTROCLIENTE_ERRO_ATUALIZACAO_WEBSERVICES;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nCadastraPessoaJuridica(nIdTipo,strCodigo,strRazaoSocial,strNomeFantasia,strEmail,strSite,nSetorAtividadeOuServicos,strSetorAtividadeOuServicos,nQuantidadeExportacoesAnuaisOuClientesExportadores,nQuantidadeFuncionarios,dtPrimeiraExportacao,bRealizaImportacao,nMeioRealizacaoPEs,strMeioRealizacaoPEs,nComoTomouConhecimentoSiscobras,strComoTomouConhecimentoSiscobras,strFuncionarioNome,nFuncionarioIdCargos,bFuncionarioSexoMasculino,dtFuncionarioNascimento,bFuncionarioDecisor,dtFuncionarioIngressoEmpresa,strFuncionarioRamal,strFuncionarioEmail,nFuncionarioIdDepartamento,nFuncionarioIdAdeptoTecnologia,strLocalizacaoCNPJ,strLocalizacaoEndereco,strLocalizacaoComplemento,strLocalizacaoBairro,strLocalizacaoCEP,strLocalizacaoCidade,nLocalizacaoIdEstado,strLocalizacaoEmail,strLocalizacaoSite,nLocalizacaoIdRamoAtividade,nLocalizacaoQuantidadeFuncionarios,nLocalizacaoIdVolumeExportacao,nLocalizacaoFrequenciaProcessos,bLocalizacaoFinanceiro,strLocalizacaoFaxNumero,strLocalizacaoTelefoneNumero);
						} 
					}
				}catch{
					nRetorno = clsRegistro.ERRO_CADASTROCLIENTE_PROBLEMAS_OCORRERAM_ACESSO_SERVIDOR;
				}
				return(nRetorno);
			}

			public int nCadastraPessoaFisica(int nIdTipo,string strCodigo,string strNome,string strCPF,bool bSexoMasculino, System.DateTime dtNascimento,string strLogradouro,string strComplemento,string strBairro,string strCidade,int nIdEstado ,string strCEP, string strTelefone,string strFax ,string strEmail,string strSite, int nSetorAtividadeOuServicos,string strSetorAtividadeOuServicos,int nQuantidadeExportacoesAnuaisOuClientesExportadores,System.DateTime dtPrimeiraExportacao, bool bRealizaImportacao,string strInstituicaoEnsino,string strCurso,string strFase,int nMeioRealizacaoPEs,string strMeioRealizacaoPEs,int nComoTomouConhecimentoSiscobras,string strComoTomouConhecimentoSiscobras)
			{
				int nRetorno = clsRegistro.ERRO_CADASTROCLIENTE_ERRO_ATUALIZACAO_WEBSERVICES;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							m_cls_wbsvreg_Registro.Timeout = 600000;
							nRetorno = m_cls_wbsvreg_Registro.nCadastraPessoaFisica(nIdTipo,strCodigo,strNome,strCPF,bSexoMasculino, dtNascimento,strLogradouro,strComplemento,strBairro,strCidade,nIdEstado ,strCEP, strTelefone,strFax ,strEmail,strSite, nSetorAtividadeOuServicos,strSetorAtividadeOuServicos,nQuantidadeExportacoesAnuaisOuClientesExportadores,dtPrimeiraExportacao, bRealizaImportacao,strInstituicaoEnsino,strCurso,strFase,nMeioRealizacaoPEs,strMeioRealizacaoPEs,nComoTomouConhecimentoSiscobras,strComoTomouConhecimentoSiscobras);
						} 
					}
				}catch{
					nRetorno = clsRegistro.ERRO_CADASTROCLIENTE_PROBLEMAS_OCORRERAM_ACESSO_SERVIDOR;
				}
				return(nRetorno);
			}
		#endregion
		#region Cliente Requisicao 
			public int nRequisicaoDadosVencimentoCliente(string strCodigoCliente,out System.DateTime dtHoje,out System.DateTime dtAtualizacao,out System.DateTime dtVencimento)
			{
				int nRetorno = -1;
				dtHoje = new System.DateTime(1800,1,1);
				dtAtualizacao = new System.DateTime(1800,1,1);
				dtVencimento = new System.DateTime(1800,1,1);
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nRequisicaoDadosVencimentoCliente(strCodigoCliente,out dtHoje,out dtAtualizacao,out dtVencimento);
						} 
					}
				}catch{
					nRetorno = -1;
				}
				return(nRetorno);
			}
		#endregion
		#region Cliente TipoVersao Requisicao 
			public int nRequisicaoTipoVersao(int nIdCliente)
			{
				int nRetorno = 0;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nRequisicaoTipoVersao(nIdCliente);
						} 
					}
				}catch{
					nRetorno = 0;
				}
				return(nRetorno);
			}
		#endregion
		#region Cliente Maquina Requisicao
			public int nRequisicaoDadosVencimentoClienteMaquina(int nIdCliente,string strNomeMaquina,out System.DateTime dtHoje,out System.DateTime dtAtualizacao,out System.DateTime dtVencimento)
			{
				int nRetorno = -1;
				dtHoje = new System.DateTime(1800,1,1);
				dtAtualizacao = new System.DateTime(1800,1,1);
				dtVencimento = new System.DateTime(1800,1,1);
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nRequisicaoDadosVencimentoClienteMaquina(nIdCliente,strNomeMaquina,out dtHoje,out dtAtualizacao,out dtVencimento);
						} 
					}
				}catch{
					nRetorno = -1;
				}
				return(nRetorno);
			}
		#endregion

		#region Sincronizacao
			public int nSincronizacaoQuantidade(int nIdCliente)
			{
				int nRetorno = 0;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nSincronismoQuantidadeHoje(nIdCliente);
						} 
					}
				}catch{
					nRetorno = 0;
				}
				return(nRetorno);
			}

			public int nSincronizacaoQuantidade(int nIdCliente,string strSincronizacao)
			{
				int nRetorno = 0;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							nRetorno = m_cls_wbsvreg_Registro.nSincronismoQuantidade(nIdCliente,strSincronizacao);
						} 
					}
				}catch{
					nRetorno = 0;
				}
				return(nRetorno);
			}

			public bool bSincronizacaoAdiciona(int nIdCliente,string strSincronizacao)
			{
				bool bRetorno = false;
				vRefreshWebServices();
				try
				{
					Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro m_cls_wbsvreg_Registro = new mdlRegistro.Siscobras.WebServices.wbsvSiscoRegistro.wbsvSiscoRegistro();
					if (m_arlWebServices != null)
					{
						if (m_arlWebServices.Count > 0)
						{
							m_cls_wbsvreg_Registro.Url = m_arlWebServices[0].ToString();
							bRetorno = m_cls_wbsvreg_Registro.bSincronismoAdiciona(nIdCliente,strSincronizacao);
						} 
					}
				}catch{
					bRetorno = false; 
				}
				return(bRetorno);
			}
		#endregion
	}
}
