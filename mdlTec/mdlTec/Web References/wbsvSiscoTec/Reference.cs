﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.510
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.510.
// 
namespace mdlTec.wbsvSiscoTec {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="wbsvSiscoTecSoap", Namespace="http://tempuri.org/")]
    public class wbsvSiscoTec : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public wbsvSiscoTec() {
            string urlSetting = System.Configuration.ConfigurationSettings.AppSettings["mdlTec.wbsvSiscoTec.wbsvSiscoTec"];
            if ((urlSetting != null)) {
                this.Url = string.Concat(urlSetting, "");
            }
            else {
                this.Url = "http://10.1.1.51/wbsvSiscoTec/wbsvSiscoTec.asmx";
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClienteCadastrado", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ClienteCadastrado(string strCodigoCliente) {
            object[] results = this.Invoke("ClienteCadastrado", new object[] {
                        strCodigoCliente});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClienteCadastrado(string strCodigoCliente, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClienteCadastrado", new object[] {
                        strCodigoCliente}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndClienteCadastrado(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClienteCadastraPessoaFisica", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ClienteCadastraPessoaFisica(string strCPF, string strNome, string strEmail) {
            object[] results = this.Invoke("ClienteCadastraPessoaFisica", new object[] {
                        strCPF,
                        strNome,
                        strEmail});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClienteCadastraPessoaFisica(string strCPF, string strNome, string strEmail, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClienteCadastraPessoaFisica", new object[] {
                        strCPF,
                        strNome,
                        strEmail}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndClienteCadastraPessoaFisica(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClienteCadastraPessoaJuridica", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ClienteCadastraPessoaJuridica(string strCNPJ, string strRazaoSocial, string strSite, string strNome, string strEmail, string strTelefone) {
            object[] results = this.Invoke("ClienteCadastraPessoaJuridica", new object[] {
                        strCNPJ,
                        strRazaoSocial,
                        strSite,
                        strNome,
                        strEmail,
                        strTelefone});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClienteCadastraPessoaJuridica(string strCNPJ, string strRazaoSocial, string strSite, string strNome, string strEmail, string strTelefone, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClienteCadastraPessoaJuridica", new object[] {
                        strCNPJ,
                        strRazaoSocial,
                        strSite,
                        strNome,
                        strEmail,
                        strTelefone}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndClienteCadastraPessoaJuridica(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClienteLiberado", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ClienteLiberado(string strCodigoCliente) {
            object[] results = this.Invoke("ClienteLiberado", new object[] {
                        strCodigoCliente});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClienteLiberado(string strCodigoCliente, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClienteLiberado", new object[] {
                        strCodigoCliente}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndClienteLiberado(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetVersao", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetVersao() {
            object[] results = this.Invoke("GetVersao", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetVersao(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetVersao", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetVersao(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataAtualizacao", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetDataAtualizacao() {
            object[] results = this.Invoke("GetDataAtualizacao", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataAtualizacao(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataAtualizacao", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGetDataAtualizacao(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataAtualizacaoNCM", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetDataAtualizacaoNCM() {
            object[] results = this.Invoke("GetDataAtualizacaoNCM", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataAtualizacaoNCM(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataAtualizacaoNCM", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGetDataAtualizacaoNCM(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataAtualizacaoNaladi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetDataAtualizacaoNaladi() {
            object[] results = this.Invoke("GetDataAtualizacaoNaladi", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataAtualizacaoNaladi(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataAtualizacaoNaladi", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGetDataAtualizacaoNaladi(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataAtualizacaoNesh", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetDataAtualizacaoNesh() {
            object[] results = this.Invoke("GetDataAtualizacaoNesh", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataAtualizacaoNesh(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataAtualizacaoNesh", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGetDataAtualizacaoNesh(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataAtualizacaoAliquotas", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetDataAtualizacaoAliquotas() {
            object[] results = this.Invoke("GetDataAtualizacaoAliquotas", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDataAtualizacaoAliquotas(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDataAtualizacaoAliquotas", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGetDataAtualizacaoAliquotas(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPesquisaNcm", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetPesquisaNcm(string strTexto) {
            object[] results = this.Invoke("GetPesquisaNcm", new object[] {
                        strTexto});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPesquisaNcm(string strTexto, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPesquisaNcm", new object[] {
                        strTexto}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetPesquisaNcm(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmDescricao", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetNcmDescricao(string strCodigo) {
            object[] results = this.Invoke("GetNcmDescricao", new object[] {
                        strCodigo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmDescricao(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmDescricao", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetNcmDescricao(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmSubNiveis", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetNcmSubNiveis(string strCodigo) {
            object[] results = this.Invoke("GetNcmSubNiveis", new object[] {
                        strCodigo});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmSubNiveis(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmSubNiveis", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetNcmSubNiveis(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmNesh", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetNcmNesh(string strCodigo) {
            object[] results = this.Invoke("GetNcmNesh", new object[] {
                        strCodigo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmNesh(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmNesh", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetNcmNesh(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPesquisaNaladi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetPesquisaNaladi(string strTexto) {
            object[] results = this.Invoke("GetPesquisaNaladi", new object[] {
                        strTexto});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPesquisaNaladi(string strTexto, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPesquisaNaladi", new object[] {
                        strTexto}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetPesquisaNaladi(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNaladiDescricao", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetNaladiDescricao(string strCodigo) {
            object[] results = this.Invoke("GetNaladiDescricao", new object[] {
                        strCodigo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNaladiDescricao(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNaladiDescricao", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetNaladiDescricao(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNaladiSubNiveis", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetNaladiSubNiveis(string strCodigo) {
            object[] results = this.Invoke("GetNaladiSubNiveis", new object[] {
                        strCodigo});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNaladiSubNiveis(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNaladiSubNiveis", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetNaladiSubNiveis(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmAliquotaIPI", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetNcmAliquotaIPI(string strCodigo, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.Invoke("GetNcmAliquotaIPI", new object[] {
                        strCodigo});
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmAliquotaIPI(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmAliquotaIPI", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndGetNcmAliquotaIPI(System.IAsyncResult asyncResult, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.EndInvoke(asyncResult);
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmAliquotaImpostoImportacao", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetNcmAliquotaImpostoImportacao(string strCodigo, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.Invoke("GetNcmAliquotaImpostoImportacao", new object[] {
                        strCodigo});
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmAliquotaImpostoImportacao(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmAliquotaImpostoImportacao", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndGetNcmAliquotaImpostoImportacao(System.IAsyncResult asyncResult, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.EndInvoke(asyncResult);
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNcmAliquotaImpostoImportacaoMercosul", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetNcmAliquotaImpostoImportacaoMercosul(string strCodigo, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.Invoke("GetNcmAliquotaImpostoImportacaoMercosul", new object[] {
                        strCodigo});
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetNcmAliquotaImpostoImportacaoMercosul(string strCodigo, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetNcmAliquotaImpostoImportacaoMercosul", new object[] {
                        strCodigo}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndGetNcmAliquotaImpostoImportacaoMercosul(System.IAsyncResult asyncResult, out string strValor, out System.DateTime dtInicio, out System.DateTime dtFim) {
            object[] results = this.EndInvoke(asyncResult);
            strValor = ((string)(results[1]));
            dtInicio = ((System.DateTime)(results[2]));
            dtFim = ((System.DateTime)(results[3]));
            return ((bool)(results[0]));
        }
    }
}
