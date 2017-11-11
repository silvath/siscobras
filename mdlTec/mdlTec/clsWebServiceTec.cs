using System;

namespace mdlTec
{
	/// <summary>
	/// Summary description for clsWebServiceTec.
	/// </summary>
	public class clsWebServiceTec
	{
		#region Constants
			private const string SERVICE_TEC = "SiscoTec";
		#endregion
		#region Atributes
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			private string m_strEnderecoExecutavel = "";

			private wbsvSiscoTec.wbsvSiscoTec m_wbsvSiscoTec = null;

			private string m_strCodigoCliente = null;
			private bool m_bClienteLiberado = false;

			private mdlManipuladorArquivo.clsManipuladorArquivoIni m_ArquivoConfiguracao = null;
		#endregion
		#region Properties
			private mdlManipuladorArquivo.clsManipuladorArquivoIni ArquivoConfiguracao
			{
				get
				{
					if (m_ArquivoConfiguracao != null)
						return(m_ArquivoConfiguracao);
					m_ArquivoConfiguracao = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "SiscoTec.xml");
					return(m_ArquivoConfiguracao);
				}
			}

			private wbsvSiscoTec.wbsvSiscoTec WebServiceTec
			{
				get
				{
					if (m_wbsvSiscoTec != null)
						return(m_wbsvSiscoTec);
					m_wbsvSiscoTec = new mdlTec.wbsvSiscoTec.wbsvSiscoTec();
					m_wbsvSiscoTec.Timeout = -1;
					if (m_cls_dba_ConnectionBD != null)
					{
						System.Collections.ArrayList arlURLs;
						mdlSysWebServicesProxy.clsSysWebServicesProxy cls_Proxy = new mdlSysWebServicesProxy.clsSysWebServicesProxy(ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel,true);
						if (cls_Proxy.GetURLListFromService(SERVICE_TEC,out arlURLs))
							if (arlURLs.Count > 0)
								m_wbsvSiscoTec.Url = arlURLs[0].ToString();
						if ((this.ArquivoConfiguracao != null) && (this.ArquivoConfiguracao.bArquivoValido()))
						{
							string strWebService = this.ArquivoConfiguracao.retornaValor("WebService","WebServiceURL","");
							if (strWebService != "")
								m_wbsvSiscoTec.Url = strWebService;
						}
					}
					else
					{
						if ((this.ArquivoConfiguracao != null) && (this.ArquivoConfiguracao.bArquivoValido()))
							m_wbsvSiscoTec.Url = this.ArquivoConfiguracao.retornaValor("WebService","WebServiceURL","http://www.siscobras.com.br/wbsvSiscoTec.asmx");
						else
							m_wbsvSiscoTec.Url = "http://www.siscobras.com.br/wbsvSiscoTec.asmx";

					}
					return(m_wbsvSiscoTec);
				}
			}	

			public string WebServiceURL
			{
				set
				{
					this.WebServiceTec.Url = value;
				}
			}
		#endregion
		#region Constructors
			public clsWebServiceTec(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionBD,string strEnderecoExecutavel)
			{
				m_cls_dba_ConnectionBD = cls_dba_ConnectionBD;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region Clientes
		public bool ClienteCadastrado(string strCodigoCliente)
		{
			try
			{
				return(this.WebServiceTec.ClienteCadastrado(strCodigoCliente));
			}
			catch
			{
				return(false);
			}
		}

		public string ClienteCadastraPessoaFisica(string strCPF,string strNome,string strEmail)
		{
			try
			{
				return(this.WebServiceTec.ClienteCadastraPessoaFisica(strCPF,strNome,strEmail));
			}
			catch
			{
				return(null);
			}
		}

		public string ClienteCadastraPessoaJuridica(string strCNPJ,string strRazaoSocial,string strSite,string strNome,string strEmail,string strTelefone)
		{
			try
			{
				return(this.WebServiceTec.ClienteCadastraPessoaJuridica(strCNPJ,strRazaoSocial,strSite,strNome,strEmail,strTelefone));
			}
			catch
			{
				return(null);
			}
		}


		public bool ClienteLiberado(string strCodigoCliente)
		{
			try
			{
				if (m_strCodigoCliente != null)
					return(m_bClienteLiberado);
				m_bClienteLiberado = this.WebServiceTec.ClienteLiberado(strCodigoCliente);
				m_strCodigoCliente = strCodigoCliente;
				return(m_bClienteLiberado);
			}
			catch
			{
				return(false);
			}
		}
		#endregion
		#region Configuracoes
			public string GetVersao()
			{
				try
				{
					return(this.WebServiceTec.GetVersao());
				}
				catch
				{
					return("0.9");
				}
			}

			public System.DateTime GetDataAtualizacao()
			{
				try
				{
					return(this.WebServiceTec.GetDataAtualizacao());
				}catch{
					return(System.DateTime.MinValue);
				}
			}

			public System.DateTime GetDataAtualizacaoNCM()
			{
				try
				{
					return(this.WebServiceTec.GetDataAtualizacaoNCM());
				}
				catch
				{
					return(System.DateTime.MinValue);
				}
			}

			public System.DateTime GetDataAtualizacaoNaladi()
			{
				try
				{
					return(this.WebServiceTec.GetDataAtualizacaoNaladi());
				}
				catch
				{
					return(System.DateTime.MinValue);
				}
			}

			public System.DateTime GetDataAtualizacaoNesh()
			{
				try
				{
					return(this.WebServiceTec.GetDataAtualizacaoNesh());
				}
				catch
				{
					return(System.DateTime.MinValue);
				}
			}

			public System.DateTime GetDataAtualizacaoAliquotas()
			{
				try
				{
					return(this.WebServiceTec.GetDataAtualizacaoAliquotas());
				}
				catch
				{
					return(System.DateTime.MinValue);
				}
			}
		#endregion
		#region Ncm
			public string[] GetPesquisaNcm(string strTexto)
			{
				try
				{
					return(this.WebServiceTec.GetPesquisaNcm(strTexto));
				}catch{
					return(null);
				}
			}

			public string GetNcmDescricao(string strCodigo)
			{
				try
				{
					return(this.WebServiceTec.GetNcmDescricao(strCodigo));
				}catch{
					return(null);
				}
			}

			public string[] GetNcmSubNiveis(string strCodigo)
			{
				try
				{
					return(this.WebServiceTec.GetNcmSubNiveis(strCodigo));
				}catch{
					return(null);
				}
			}
		#endregion
		#region Nesh
			public string GetNcmNesh(string strCodigo)
			{
				try
				{
					return(this.WebServiceTec.GetNcmNesh(strCodigo));
				}catch{
					return(null);
				}
			}
		#endregion
		#region Naladi
			public string[] GetPesquisaNaladi(string strTexto)
			{
				try
				{
					return(this.WebServiceTec.GetPesquisaNaladi(strTexto));
				}catch{
					return(null);
				}
			}

			public string GetNaladiDescricao(string strCodigo)
			{
				try
				{
					return(this.WebServiceTec.GetNaladiDescricao(strCodigo));
				}catch{
					return(null);
				}
			}

			public string[] GetNaladiSubNiveis(string strCodigo)
			{
				try
				{
					return(this.WebServiceTec.GetNaladiSubNiveis(strCodigo));
				}
				catch
				{
					return(null);
				}
			}
		#endregion
		#region Aliquotas
			public bool GetNcmAliquotaIPI(string strCodigo,out string strValor,out System.DateTime dtInicio,out System.DateTime dtFim)
			{
				try
				{
					return(this.WebServiceTec.GetNcmAliquotaIPI(strCodigo,out strValor,out dtInicio,out dtFim));
				}catch{
					strValor = "";
					dtInicio = System.DateTime.MinValue;
					dtFim = System.DateTime.MinValue;
					return(false);
				}
			}

			public bool GetNcmAliquotaImpostoImportacao(string strCodigo,out string strValor,out System.DateTime dtInicio,out System.DateTime dtFim)
			{
				try
				{
					return(this.WebServiceTec.GetNcmAliquotaImpostoImportacao(strCodigo,out strValor,out dtInicio,out dtFim));
				}catch{
					strValor = "";
					dtInicio = System.DateTime.MinValue;
					dtFim = System.DateTime.MinValue;
					return(false);
				}
			}

			public bool GetNcmAliquotaImpostoImportacaoMercosul(string strCodigo,out string strValor,out System.DateTime dtInicio,out System.DateTime dtFim)
			{
				try{
					return(this.WebServiceTec.GetNcmAliquotaImpostoImportacaoMercosul(strCodigo,out strValor,out dtInicio,out dtFim));
				}catch{
					strValor = "";
					dtInicio = System.DateTime.MinValue;
					dtFim = System.DateTime.MinValue;
					return(false);
				}
			}
		#endregion
	}
}
