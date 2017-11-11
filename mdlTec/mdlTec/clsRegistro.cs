using System;

namespace mdlTec
{
	/// <summary>
	/// Summary description for clsRegistro.
	/// </summary>
	internal class clsRegistro
	{
		#region Constants
			private const string SESSAOREGISTRO = "Registro";
		#endregion
		#region Atributes
			private string m_strFilePath = "";
			private System.Drawing.Color m_clrBackColor = System.Drawing.Color.Empty;
			private System.Drawing.Image m_banner = null;
			private mdlManipuladorArquivo.clsManipuladorArquivoIni m_ArquivoConfiguracao = null;
		#endregion
		#region Properties
			private mdlManipuladorArquivo.clsManipuladorArquivoIni ArquivoConfiguracao
			{
				get
				{
					if (m_ArquivoConfiguracao != null)
						return(m_ArquivoConfiguracao);
					m_ArquivoConfiguracao = new mdlManipuladorArquivo.clsManipuladorArquivoIni(this.m_strFilePath);
					return(m_ArquivoConfiguracao);
				}
			}

			public System.Drawing.Color BackColor
			{
				set
				{
					m_clrBackColor = value;
				}
				get
				{
					return(m_clrBackColor);
				}
			}

			public System.Drawing.Image Banner
			{
				set
				{
					m_banner = value;
				}
				get
				{
					return(m_banner);
				}
			}
		#endregion
		#region Constructors
			public clsRegistro(string strFilePath)
			{
				m_strFilePath = strFilePath;
			}
		#endregion

		#region Codigo
			public string GetRegistroCodigo()
			{
				bool bPessoaFisica,bPessoaJuridica;
				string strCPF,strCNPJ,strEmpresa,strSite,strNome,strEmail,strTelefone;
				CarregaDados(out bPessoaFisica,out bPessoaJuridica,out strCPF,out strCNPJ,out strEmpresa,out strSite,out strNome,out strEmail,out strTelefone);
				if (bPessoaFisica)
					return(30 + strCPF.Replace(".","").Replace("-",""));
				if (bPessoaJuridica)
					return(40 + strCNPJ.Replace(".","").Replace("/","").Replace("-",""));
				return("");
			}
		#endregion
		#region PossuiRegistro
			public bool PossuiRegistro()
			{
				bool bPessoaFisica,bPessoaJuridica;
				string strCPF,strCNPJ,strEmpresa,strSite,strNome,strEmail,strTelefone;
				CarregaDados(out bPessoaFisica,out bPessoaJuridica,out strCPF,out strCNPJ,out strEmpresa,out strSite,out strNome,out strEmail,out strTelefone);
				if ((!bPessoaFisica) && (!bPessoaJuridica))
					return(false);
				if ((bPessoaFisica) && (IsCPFValido(strCPF)) && (strNome != "") && (strEmail != ""))
					return(true);
				if ((bPessoaJuridica) && (IsCNPJValido(strCNPJ)) && (strEmpresa != "") && (strSite != "") && (strNome != "") && (strEmail != ""))
					return(true);
				return(false);
			}

			private bool IsCPFValido(string strCPF)
			{
				return(mdlValidacao.clsCPF.bCheckCPF(strCPF));
			}


			private bool IsCNPJValido(string strCNPJ)
			{
				return(mdlValidacao.clsCNPJ.bCheckCNPJ(strCNPJ));
			}
		#endregion
		#region ShowDialogRegistro
			public bool ShowDialogRegistro()
			{
				Formularios.frmFRegistro formFRegistro = new mdlTec.Formularios.frmFRegistro(this.Banner,this.BackColor);
				InitializeEvents(formFRegistro);
				formFRegistro.ShowDialog();
				return(formFRegistro.RegistroRealizado);
			}

			private void InitializeEvents(Formularios.frmFRegistro formFRegistro)
			{
				formFRegistro.eCallCarregaDados += new mdlTec.Formularios.frmFRegistro.delCallCarregaDados(CarregaDados);

				formFRegistro.eCallSalvaDados += new mdlTec.Formularios.frmFRegistro.delCallSalvaDados(SalvaDados);

			}
		#endregion
		#region RegistraServidor
			public bool RegistraClienteServidor(clsWebServiceTec webServiceTec)
			{
				if (!PossuiRegistro())
					return(false);
				bool bPessoaFisica,bPessoaJuridica;
				string strCPF,strCNPJ,strEmpresa,strSite,strNome,strEmail,strTelefone;
				CarregaDados(out bPessoaFisica,out bPessoaJuridica,out strCPF,out strCNPJ,out strEmpresa,out strSite,out strNome,out strEmail,out strTelefone);
				if (bPessoaFisica)
				{
					return(webServiceTec.ClienteCadastraPessoaFisica(strCPF,strNome,strEmail) != "");
				}else if (bPessoaJuridica){
					return(webServiceTec.ClienteCadastraPessoaJuridica(strCNPJ,strEmpresa,strSite,strNome,strEmail,strTelefone) != "");
				}
				return(false);
			}
		#endregion

		#region CarregaDados
			private void CarregaDados(out bool bPessoaFisica, out bool bPessoaJuridica, out string strCPF, out string strCNPJ, out string strEmpresa, out string strSite, out string strNome, out string strEmail, out string strTelefone)
			{
				bPessoaFisica = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"PessoaFisica",false);
				bPessoaJuridica = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"PessoaJuridica",false);
				strCPF = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"CPF","");
				strCNPJ = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"CNPJ","");
				strEmpresa = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"Empresa","");
				strSite = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"Site","");
				strNome = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"Nome","");
				strEmail = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"Email","");
				strTelefone = this.ArquivoConfiguracao.retornaValor(SESSAOREGISTRO,"Telefone","");
			}
		#endregion
		#region SalvaDados
			private bool SalvaDados(bool bPessoaFisica, bool bPessoaJuridica, string strCPF, string strCNPJ, string strEmpresa, string strSite, string strNome, string strEmail, string strTelefone)
			{
				if ((!bPessoaFisica) && (!bPessoaJuridica))
				{
					mdlMensagens.clsMensagens.ShowInformation("Escolha uma categoria: Pessoa Física ou Pessoa Jurídica");
					return(false);
				}
				if ((bPessoaFisica) && (!IsCPFValido(strCPF)))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar corretamente o seu CPF.");
					return(false);
				}
				if ((bPessoaJuridica) && (!IsCNPJValido(strCNPJ)))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar corretamente o CNPJ de sua empresa.");
					return(false);
				}

				if ((bPessoaJuridica) && (strEmpresa == ""))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar o nome de sua empresa.");
					return(false);
				}

				if ((bPessoaJuridica) && (strSite == ""))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar o site de sua empresa.");
					return(false);
				}

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar o seu nome.");
					return(false);
				}

				if (strEmail == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve informar o seu email.");
					return(false);
				}

				if (!this.ArquivoConfiguracao.bArquivoExiste())
					if (!this.ArquivoConfiguracao.bCriaArquivo())
						return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"PessoaFisica",bPessoaFisica.ToString()))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"PessoaJuridica",bPessoaJuridica.ToString()))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"CPF",strCPF))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"CNPJ",strCNPJ))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"Empresa",strEmpresa))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"Site",strSite))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"Nome",strNome))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"Email",strEmail))
					return(false);
				if (!this.ArquivoConfiguracao.colocaValor(SESSAOREGISTRO,"Telefone",strTelefone))
					return(false);
				return(true);
			}
		#endregion
	}
}
