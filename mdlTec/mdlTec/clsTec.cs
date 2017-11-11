using System;

namespace mdlTec
{
	/// <summary>
	/// Summary description for clsTec.
	/// </summary>
	public class clsTec
	{
		#region Static
			public static void ExecuteLink(string strLink)
			{
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo.FileName = strLink;
				proc.Start();
			}
		#endregion

		#region Constants
			private const string VERSAO = "0.9";
		#endregion
		#region Atributes
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD;
			private string m_strEnderecoExecutavel = "";

			private int m_nIdExportador = -1;

			private System.Drawing.Image m_banner = null;
			private System.Drawing.Color m_clrBackColor = System.Drawing.Color.Empty;

			private Formularios.frmFTec m_formFTec = null;
			private Formularios.frmFTecAliquotas m_formFTecAliquotas = null;
			private Formularios.frmFTecNesh m_formFTecNesh = null;

			private clsWebServiceTec m_webServiceTec = null;

			private bool m_bModificado = false;
			private clsRegistro m_registro = null;

			private bool m_bPararPesquisar = false;
		#endregion
		#region Properties
			private clsWebServiceTec WebServiceTec
			{
				get
				{
					if (m_webServiceTec != null)
						return(m_webServiceTec);
					m_webServiceTec = new clsWebServiceTec(m_cls_dba_ConnectionBD,m_strEnderecoExecutavel);
					return(m_webServiceTec);
				}
			}

			public int Exportador
			{
				set
				{
					m_nIdExportador = value;
				}
				get
				{
					return(m_nIdExportador);
				}
			}

			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			private string RegistroFilePath
			{
				get
				{
					return(m_strEnderecoExecutavel + "SiscoTec.xml");
				}
			}

			private clsRegistro Registro
			{
				get
				{
					if (m_registro != null)
						return(m_registro);
					m_registro = new clsRegistro(this.RegistroFilePath);
					m_registro.BackColor = this.BackColor;
					m_registro.Banner = this.Banner;
					return(m_registro);
				}
			}

			private System.Drawing.Image Banner
			{
				get
				{
					if (m_banner != null)
						return(m_banner);
					m_banner = mdlTec.clsBanner.GetBanner();
					return(m_banner);
				}
			}

			private System.Drawing.Color BackColor
			{
				get
				{
					if (!m_clrBackColor.IsEmpty)
						return(m_clrBackColor);
					m_clrBackColor = mdlComponentesGraficos.Painter.GetFirstColor(this.Banner);
					return(m_clrBackColor);
				}
			}

			private bool IsNcmPesquisa
			{
				get
				{
					if (m_formFTec == null)
						return(true);
					return(m_formFTec.IsNcm);
				}
			}
		#endregion
		#region Constructors 
			public clsTec(mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionBD,string strEnderecoExecutavel)
			{
				m_cls_dba_ConnectionBD = cls_dba_ConnectionBD;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
			}
		#endregion

		#region ShowDialog
			public bool ShowDialog()
			{
				if (!IsVersaoCompativel())
				{
					mdlMensagens.clsMensagens.ShowInformation("Sua versão não é compatível com a versão de nosso servidor.");
					return(false);
				}
				bool bReturn = false;
				string strCodigoCliente = null;
				// Getting Code
				if (m_cls_dba_ConnectionBD != null)
				{
					// Cliente Siscobras
					strCodigoCliente = m_cls_dba_ConnectionBD.GetConfiguracao("strIdCliente","");
					if (strCodigoCliente == "")
					{
						mdlMensagens.clsMensagens.ShowInformation("Você deve primeiro registrar o seu Siscobras.");
						return(false);
					}
					if (this.WebServiceTec.ClienteLiberado(strCodigoCliente))
					{
						bReturn = ShowDialogTec();
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Você precisa primeiro habilitar seu Siscobras.");
						return(false);
					}
				}else{
					// Usuario SiscoTec
					if (!this.Registro.PossuiRegistro())
					{
						if (!this.Registro.ShowDialogRegistro())
							return(false);
						if (!this.Registro.PossuiRegistro())
							return(false);
					}
					// Registrando Usuario
					if (!this.WebServiceTec.ClienteCadastrado(this.Registro.GetRegistroCodigo()))
					{
						if (!this.Registro.RegistraClienteServidor(this.WebServiceTec))
						{
							mdlMensagens.clsMensagens.ShowInformation("Não foi possivel realizar o seu registro neste momento. Tente mais tarde.");
							return(false);
						}

					}
					// Checando liberacao
					if (this.WebServiceTec.ClienteLiberado(this.Registro.GetRegistroCodigo()))
					{
						//Cliente Liberado
						bReturn = ShowDialogTec();
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Registro não habilitado.");
						return(false);
					}
				}
				return(bReturn);
			}
		#endregion
		#region ShowDialogTec
			public bool ShowDialogTec()
			{

				m_formFTec = new mdlTec.Formularios.frmFTec(m_strEnderecoExecutavel);
				m_formFTec.PossibilidadeCadastrarClassificacaoTarifaria = m_nIdExportador != -1;
				m_formFTec.Banner = this.Banner;
				InitializeEvents(m_formFTec);
				m_formFTec.ShowDialog();
				return(true);
			}
				
			private void InitializeEvents(Formularios.frmFTec formFTec)
			{
				formFTec.eCallCarregaDados += new mdlTec.Formularios.frmFTec.delCallCarregaDados(CarregarDadosTec);

				formFTec.eCallPesquisar += new mdlTec.Formularios.frmFTec.delCallPesquisar(Pesquisar);

				formFTec.eCallPesquisarParar += new mdlTec.Formularios.frmFTec.delCallPesquisarParar(PesquisarParar);

				formFTec.eCallInsere += new mdlTec.Formularios.frmFTec.delCallInsere(Inserir);

				formFTec.eCallDetalhar += new mdlTec.Formularios.frmFTec.delCallDetalhar(SubNiveis);

				formFTec.eCallNesh += new mdlTec.Formularios.frmFTec.delCallNesh(ShowDialogNesh);

				formFTec.eCallAliquotas += new mdlTec.Formularios.frmFTec.delCallAliquotas(ShowDialogAliquotas);

				formFTec.eCallCadastrar += new mdlTec.Formularios.frmFTec.delCallCadastrar(ShowDialogCadastrarClassificacaoTarifaria);

				formFTec.eCallShowDialogDatasAtualizacoes += new mdlTec.Formularios.frmFTec.delCallShowDialogDatasAtualizacoes(ShowDialogDatasAtualizacoes);

				formFTec.eCallShowDialogInformacoes += new mdlTec.Formularios.frmFTec.delCallShowDialogInformacoes(ShowDialogInformacoes);

				formFTec.eCallShowDialogPesquisaInformacoes += new mdlTec.Formularios.frmFTec.delCallShowDialogPesquisaInformacoes(ShowDialogPesquisaInformacoes);
			}

			private void TecPesquisaLimpa()
			{
				if (m_formFTec != null)
					m_formFTec.Pesquisa.Items.Clear();
			}

			private void TecPesquisaInsere(string strCodigo,string strTexto)
			{
				if (m_formFTec != null)
				{
					System.Windows.Forms.ListViewItem lviPesquisa = m_formFTec.Pesquisa.Items.Add(strCodigo);
					lviPesquisa.SubItems.Add(strTexto);
					lviPesquisa.Tag = strCodigo;
					System.Windows.Forms.Application.DoEvents();
				}
			}
		#endregion
		#region ShowDialogAliquotas
			private bool ShowDialogAliquotas(string strCodigo,string strDescricao)
			{
				m_formFTecAliquotas = new mdlTec.Formularios.frmFTecAliquotas(m_strEnderecoExecutavel,strCodigo,strDescricao);
				m_formFTecAliquotas.Cor = this.BackColor;
				InitializeEvents(m_formFTecAliquotas);
				m_formFTecAliquotas.ShowDialog();
				return(true);
			}

			private void InitializeEvents(Formularios.frmFTecAliquotas formFAliquotas)
			{
				//Carrega Dados
				formFAliquotas.eCallCarregaDados += new mdlTec.Formularios.frmFTecAliquotas.delCallCarregaDados(CarregaAliquotas);
			}
		#endregion
		#region ShowDialogNesh
			private bool ShowDialogNesh(string strCodigo,string strDescricao)
			{
				m_formFTecNesh = new mdlTec.Formularios.frmFTecNesh(m_strEnderecoExecutavel,strCodigo,strDescricao);
				m_formFTecNesh.Cor = this.BackColor;
				InitializeEvents(m_formFTecNesh);
				m_formFTecNesh.ShowDialog();
				return(true);
			}

			private void InitializeEvents(Formularios.frmFTecNesh formFNesh)
			{
				// Carrega Dados
				formFNesh.eCallCarregaDados += new mdlTec.Formularios.frmFTecNesh.delCallCarregaDados(CarregaNesh);
			}
		#endregion
		#region ShowDialogDatasAtualizacoes
			private void ShowDialogDatasAtualizacoes()
			{
				Formularios.frmFTecDatasAtualizacoes formFDataAtualizacoes = new mdlTec.Formularios.frmFTecDatasAtualizacoes();
				formFDataAtualizacoes.DataAtualizacaoTecSiscobras = GetDataAtualizacaoTecSiscobras();
				formFDataAtualizacoes.DataAtualizacaoNcm = GetDataAtualizacaoNcm();
				formFDataAtualizacoes.DataAtualizacaoNaladi = GetDataAtualizacaoNaladi();
				formFDataAtualizacoes.DataAtualizacaoNesh = GetDataAtualizacaoNesh();
				formFDataAtualizacoes.DataAtualizacaoAliquotas = GetDataAtualizacaoAliquotas();
				formFDataAtualizacoes.Cor = this.BackColor;
				formFDataAtualizacoes.ShowDialog();
			}
		#endregion
		#region ShowDialogInformacoes
			private void ShowDialogInformacoes(string strDescricao)
			{
				Formularios.frmFTecInformacoes formFInformacoes = new mdlTec.Formularios.frmFTecInformacoes();
				formFInformacoes.Informacoes = strDescricao;
				formFInformacoes.Cor = this.BackColor;
				formFInformacoes.ShowDialog();
			}
		#endregion
		#region ShowDialogPesquisaInfomacoes
			private void ShowDialogPesquisaInformacoes()
			{
				Formularios.frmFPesquisaInformacoes formF = new mdlTec.Formularios.frmFPesquisaInformacoes();
				formF.Cor = this.BackColor;
				formF.ShowDialog();
			}
		#endregion


		#region Pequisa
			private bool Pesquisar(string strPesquisar)
			{
				TecPesquisaLimpa();
				m_bPararPesquisar = false;
				string[] astrCodigos = null;
				if (this.IsNcmPesquisa)
					astrCodigos = this.WebServiceTec.GetPesquisaNcm(strPesquisar);
				else
					astrCodigos = this.WebServiceTec.GetPesquisaNaladi(strPesquisar);
				if (astrCodigos == null)
					return(false);
				for(int i = 0; i < astrCodigos.Length;i++)
				{
					if (m_bPararPesquisar)
						return(true);
					string strDescricao = null;
					if (this.IsNcmPesquisa)
						strDescricao = this.WebServiceTec.GetNcmDescricao(astrCodigos[i]);
					else
						strDescricao = this.WebServiceTec.GetNaladiDescricao(astrCodigos[i]);
					if (strDescricao != null)
					TecPesquisaInsere(astrCodigos[i],strDescricao);
				}
				return(true);
			}

			private bool PesquisarParar()
			{
				m_bPararPesquisar = true;
				return(true);
			}
		#endregion
		#region Tec
			private bool Inserir(string strCodigo,string strDescricao)
			{
				System.Windows.Forms.TreeView tvTec = m_formFTec.Tec;
				string strCapitulo = "";
				string strPosicao = "";
				string strClassificacao = "";
				string strCapituloDescricao = "";
				string strPosicaoDescricao = "";
				string strClassificacaoDescricao = "";
				if (IsClassificacaoTarifaria(strCodigo))
				{
					strClassificacao = strCodigo;
					strClassificacaoDescricao = strDescricao;
					strPosicao = GetPosicao(strClassificacao);
					strCapitulo = GetCapitulo(strPosicao);
				}else if (IsPosicao(strCodigo)){
					strPosicao = GetPosicao(strCodigo);
					strPosicaoDescricao = strDescricao;
					strCapitulo = GetCapitulo(strPosicao);
				}else if (IsCapitulo(strCodigo)){
					strCapitulo = strCodigo;
					strCapituloDescricao = strDescricao;
				}
				//Capitulo
				System.Windows.Forms.TreeNode tvnCapitulo = null;
				for(int i = 0;i < tvTec.Nodes.Count;i++)
				{
					if (tvTec.Nodes[i].Tag.ToString() == strCapitulo)
					{
						tvnCapitulo = tvTec.Nodes[i];
						if (strCapituloDescricao == "")
							strCapituloDescricao = tvnCapitulo.Text.Substring(5);
						break;
					}
				}
				if (tvnCapitulo == null)
				{
					if (strCapituloDescricao == "")
					{
						if (this.IsNcmPesquisa)
							strCapituloDescricao = this.WebServiceTec.GetNcmDescricao(strCapitulo);
						else
							strCapituloDescricao = this.WebServiceTec.GetNaladiDescricao(strCapitulo);
					}
					tvnCapitulo = tvTec.Nodes.Add(strCapitulo + " : " + strCapituloDescricao); 
					tvnCapitulo.Tag = strCapitulo;
				}
				tvnCapitulo.Expand();
				tvTec.SelectedNode = tvnCapitulo;

				// Posicao
				System.Windows.Forms.TreeNode tvnPosicao = null;
				if (strPosicao != "")
				{
					for(int i = 0;i < tvnCapitulo.Nodes.Count;i++)
					{
						if (tvnCapitulo.Nodes[i].Tag.ToString() == strPosicao)
						{
							tvnPosicao = tvnCapitulo.Nodes[i];
							if (strPosicaoDescricao == "")
								strPosicaoDescricao = tvnPosicao.Text.Substring(5);
							break;
						}
					}
					if (tvnPosicao == null)
					{
						if (strPosicaoDescricao == "")
						{
							if (IsNcmPesquisa)
								strPosicaoDescricao = this.WebServiceTec.GetNcmDescricao(strPosicao);
							else
								strPosicaoDescricao = this.WebServiceTec.GetNaladiDescricao(strPosicao);
						}
						tvnPosicao = tvnCapitulo.Nodes.Add(strPosicao + " : " + strPosicaoDescricao); 
						tvnPosicao.Tag = strPosicao;
					}
					tvnPosicao.Expand();
					tvTec.SelectedNode = tvnPosicao;
				}
				// Classificacao
				System.Windows.Forms.TreeNode tvnClassificacao = null;
				if (strClassificacao != "")
				{
					for(int i = 0;i < tvnPosicao.Nodes.Count;i++)
					{
						if (tvnPosicao.Nodes[i].Tag.ToString() == strClassificacao)
						{
							tvnClassificacao = tvnPosicao.Nodes[i];
							if (strClassificacaoDescricao == "")
								strClassificacaoDescricao = tvnPosicao.Text.Substring(5);
							break;
						}
					}
					if (tvnClassificacao == null)
					{
						if (strClassificacaoDescricao == "")
						{
							if (this.IsNcmPesquisa)
								strClassificacaoDescricao = this.WebServiceTec.GetNcmDescricao(strClassificacao);
							else
								strClassificacaoDescricao = this.WebServiceTec.GetNaladiDescricao(strClassificacao);
						}
						tvnClassificacao = tvnPosicao.Nodes.Add(strClassificacao + " : " + strClassificacaoDescricao); 
						tvnClassificacao.Tag = strClassificacao;
					}
					tvnClassificacao.Expand();
					tvTec.SelectedNode = tvnClassificacao;
				}
				return(true);
			}

			private bool SubNiveis(System.Windows.Forms.TreeView tvTec,string strCodigo)
			{
				string[] astrSubNiveis = null;
				if (IsNcmPesquisa)
					astrSubNiveis = this.WebServiceTec.GetNcmSubNiveis(strCodigo);
				else
					astrSubNiveis = this.WebServiceTec.GetNaladiSubNiveis(strCodigo);
				if (astrSubNiveis == null)
					return(false);
				if ((strCodigo == null) || (strCodigo == ""))
				{
					for (int i = 0; i < astrSubNiveis.Length;i++)
					{
						System.Windows.Forms.TreeNode tvnNode = null;
						for(int j = 0; j < tvTec.Nodes.Count;j++)
						{
							if (tvTec.Nodes[j].Tag.ToString() == astrSubNiveis[i])
							{
								tvnNode = tvTec.Nodes[j];
								break;
							}
						}
						if (tvnNode == null)
						{
							if (IsNcmPesquisa)
								tvnNode = tvTec.Nodes.Add(astrSubNiveis[i] + " : " + this.WebServiceTec.GetNcmDescricao(astrSubNiveis[i])); 
							else
								tvnNode = tvTec.Nodes.Add(astrSubNiveis[i] + " : " + this.WebServiceTec.GetNaladiDescricao(astrSubNiveis[i])); 
							tvnNode.Tag = astrSubNiveis[i];
							tvnNode.Expand();
							tvTec.SelectedNode = tvnNode;
							System.Windows.Forms.Application.DoEvents();
						}
					}
				}else{
					System.Windows.Forms.TreeNode tvnNode = null;
					for(int i = 0; i < tvTec.Nodes.Count;i++)
					{
						if (tvTec.Nodes[i].Tag.ToString() == strCodigo)
						{
							tvnNode = tvTec.Nodes[i];
							break;
						}
						for(int j = 0; j < tvTec.Nodes[i].Nodes.Count;j++)
						{
							if (tvTec.Nodes[i].Nodes[j].Tag.ToString() == strCodigo)
							{
								tvnNode = tvTec.Nodes[i].Nodes[j];
								break;
							}
						}
						if (tvnNode != null)
							break;
					}
					if (tvnNode != null)
					{
						for (int i = 0; i < astrSubNiveis.Length;i++)
						{
							System.Windows.Forms.TreeNode tvnNodeCurrent = null;
							for(int j = 0; j < tvnNode.Nodes.Count;j++)
							{
								if (tvnNode.Nodes[j].Tag.ToString() == astrSubNiveis[i])
								{
									tvnNodeCurrent = tvnNode.Nodes[j];
									break;
								}
							}
							if (tvnNodeCurrent == null)
							{
								if (IsNcmPesquisa)
									tvnNodeCurrent = tvnNode.Nodes.Add(astrSubNiveis[i] + " : " + this.WebServiceTec.GetNcmDescricao(astrSubNiveis[i])); 
								else
									tvnNodeCurrent = tvnNode.Nodes.Add(astrSubNiveis[i] + " : " + this.WebServiceTec.GetNaladiDescricao(astrSubNiveis[i])); 
								tvnNodeCurrent.Tag = astrSubNiveis[i];
								System.Windows.Forms.Application.DoEvents();
								if (!tvnNode.IsExpanded)
									tvnNode.Expand();
							}
						}
					}
   				}
				return(true);
			}
		#endregion

		#region Versao
			private bool IsVersaoCompativel()
			{
				return(VERSAO == this.WebServiceTec.GetVersao());
			}
		#endregion
		#region Configuracoes
			private bool CarregarDadosTec(out DateTime dtDataAtualizacao)
			{
				dtDataAtualizacao = GetDataAtualizacaoTecSiscobras();
				return(true);
			}

			private System.DateTime GetDataAtualizacaoTecSiscobras()
			{
				return(this.WebServiceTec.GetDataAtualizacao());
			}

			private System.DateTime GetDataAtualizacaoNcm()
			{
				return(this.WebServiceTec.GetDataAtualizacaoNCM());
			}

			private System.DateTime GetDataAtualizacaoNaladi()
			{
				return(this.WebServiceTec.GetDataAtualizacaoNaladi());
			}

			private System.DateTime GetDataAtualizacaoNesh()
			{
				return(this.WebServiceTec.GetDataAtualizacaoNesh());
			}

			private System.DateTime GetDataAtualizacaoAliquotas()
			{
				return(this.WebServiceTec.GetDataAtualizacaoAliquotas());
			}
		#endregion
		#region Capitulo
			private bool IsCapitulo(string strCodigo)
			{
				return(strCodigo.Length == 2); 
			}

			private string GetCapitulo(string strPosicao)
			{
				return(strPosicao.Substring(0,2)); 
			}
		#endregion
		#region Posicao
			private bool IsPosicao(string strCodigo)
			{
				return(strCodigo.Length == 4); 
			}

			private string GetPosicao(string strNcm)
			{
				return(strNcm.Substring(0,4));
			}
		#endregion
		#region ClassificacaoTarifaria
			private bool IsClassificacaoTarifaria(string strCodigo)
			{
				return(strCodigo.Length == 8); 
			}
		#endregion
		#region Aliquotas
			private bool CarregaAliquotas(string strCodigo, out string strValorIPI, out DateTime dtInicioIPI, out DateTime dtFinalIPI, out string strValorII, out DateTime dtInicioII, out DateTime dtFinalII, out string strValorIIM, out DateTime dtInicioIIM, out DateTime dtFinalIIM)
			{
				this.WebServiceTec.GetNcmAliquotaIPI(strCodigo,out strValorIPI,out dtInicioIPI,out dtFinalIPI);
				this.WebServiceTec.GetNcmAliquotaImpostoImportacao(strCodigo,out strValorII,out dtInicioII,out dtFinalII);
				this.WebServiceTec.GetNcmAliquotaImpostoImportacao(strCodigo,out strValorIIM,out dtInicioIIM,out dtFinalIIM);
				return(true);
			}
		#endregion
		#region Nesh
			private bool CarregaNesh(string strCodigo, out string strNesh)
			{
				strNesh = this.WebServiceTec.GetNcmNesh(strCodigo);
				return(true);
			}
		#endregion

		#region ClassificacaoTarifaria
			private bool ShowDialogCadastrarClassificacaoTarifaria(string strCodigo, string strPosicao, string strClassificacaoTarifaria)
			{
				Formularios.frmFTecCadastrarClassificacaoTarifaria formClassificacao = new mdlTec.Formularios.frmFTecCadastrarClassificacaoTarifaria(m_strEnderecoExecutavel,strCodigo,strPosicao + ". " + strClassificacaoTarifaria);
				formClassificacao.Cor = this.BackColor;
				formClassificacao.ShowDialog();
				if (!formClassificacao.Confirmado)
					return(false);
				if (CadastrarClassificacaoTarifaria(formClassificacao.Codigo,formClassificacao.Denominacao))
				{
					m_bModificado = true;
					return(true);
				}
				return(false);
			}

			private bool CadastrarClassificacaoTarifaria(string strCodigo,string strDenominacao)
			{
				if (this.IsNcmPesquisa)
					return(CadastrarClassificacaoTarifariaNcm(strCodigo,strDenominacao));
				else
					return(CadastrarClassificacaoTarifariaNaladi(strCodigo,strDenominacao));
			}

			private bool CadastrarClassificacaoTarifariaNcm(string strCodigo,string strDenominacao)
			{
				if (m_cls_dba_ConnectionBD == null)
					return(false);
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strNcm");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strCodigo);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm typDatSetNcm = m_cls_dba_ConnectionBD.GetTbProdutosNcm(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNcm.tbProdutosNcmRow dtrwNcm = null;
				if (typDatSetNcm.tbProdutosNcm.Count == 0)
				{
					dtrwNcm = typDatSetNcm.tbProdutosNcm.NewtbProdutosNcmRow();
					dtrwNcm.nIdExportador = m_nIdExportador;
					dtrwNcm.strNcm = strCodigo;
					dtrwNcm.mstrDenominacao = strDenominacao;
					typDatSetNcm.tbProdutosNcm.AddtbProdutosNcmRow(dtrwNcm);
				}else{
					dtrwNcm = typDatSetNcm.tbProdutosNcm[0];
					dtrwNcm.mstrDenominacao = strDenominacao;
				}
				m_cls_dba_ConnectionBD.SetTbProdutosNcm(typDatSetNcm);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}

			private bool CadastrarClassificacaoTarifariaNaladi(string strCodigo,string strDenominacao)
			{
				if (m_cls_dba_ConnectionBD == null)
					return(false);
				System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
				System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

				arlCondicaoCampo.Add("nIdExportador");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(m_nIdExportador);

				arlCondicaoCampo.Add("strNaladi");
				arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
				arlCondicaoValor.Add(strCodigo);

				m_cls_dba_ConnectionBD.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi typDatSetNaladi = m_cls_dba_ConnectionBD.GetTbProdutosNaladi(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbProdutosNaladi.tbProdutosNaladiRow dtrwNaladi = null;
				if (typDatSetNaladi.tbProdutosNaladi.Count == 0)
				{
					dtrwNaladi = typDatSetNaladi.tbProdutosNaladi.NewtbProdutosNaladiRow();
					dtrwNaladi.nIdExportador = m_nIdExportador;
					dtrwNaladi.strNaladi = strCodigo;
					dtrwNaladi.mstrDenominacao = strDenominacao;
					typDatSetNaladi.tbProdutosNaladi.AddtbProdutosNaladiRow(dtrwNaladi);
				}
				else
				{
					dtrwNaladi = typDatSetNaladi.tbProdutosNaladi[0];
					dtrwNaladi.mstrDenominacao = strDenominacao;
				}
				m_cls_dba_ConnectionBD.SetTbProdutosNaladi(typDatSetNaladi);
				return(m_cls_dba_ConnectionBD.Erro == null);
			}
		#endregion
	}
}
