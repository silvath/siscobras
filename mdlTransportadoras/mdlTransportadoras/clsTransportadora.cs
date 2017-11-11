using System;

namespace mdlTransportadoras
{
	/// <summary>
	/// Summary description for clsTransportadora.
	/// </summary>
	public class clsTransportadora
	{
		#region Atributes
			protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
			protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
			protected string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			private int m_nIdExportador = -1;
			private string m_strIdPe = "";
			private int m_nIdContainer = -1;

			private int m_nIdSelect = -1;
			private int m_nIdSelectContato = -1;
			private int m_nIdSelectMotorista = -1;
			private int m_nIdSelectVeiculo = -1;

			// Typed DataSets
			private mdlDataBaseAccess.Tabelas.XsdTbPes m_typDatSetPes = null;
			private mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers m_typDatSetProcessosContainers = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadoras m_typdatSetTransportadoras = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos m_typDatSetTransportadorasContatos = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas m_typDatSetTransportadorasMotoristas = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos m_typdatSetTransportadorasVeiculos = null;

			// Typed DataSets Copy
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos m_typDatSetTransportadorasContatosCopy = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas m_typDatSetTransportadorasMotoristasCopy = null;
			private mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos m_typdatSetTransportadorasVeiculosCopy = null;
		#endregion
		#region Constructors and Destructors
			public clsTransportadora(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPE;
				vCarregaDados();
			}

			public clsTransportadora(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB, string strEnderecoExecutavel, int nIdExportador, string strIdPE,int nIdContainer)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPE;
				m_nIdContainer = nIdContainer;
				vCarregaDados();
			}
		#endregion

		#region Carregamento de Dados
			private void vCarregaDados()
			{
				vCarregaDadosPe();
				vCarregaDadosContainers();
				vCarregaDadosTransportadoras();
				vCarregaDadosTransportadorasContatos();
				vCarregaDadosTransportadorasMotoristas();
				vCarregaDadosTransportadorasVeiculos();
			}

			private void vCarregaDadosPe()
			{
				if (m_strIdPe != "")
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("idExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("idPE");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetPes = m_cls_dba_ConnectionDB.GetTbPes(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			}

			private void vCarregaDadosContainers()
			{
				if (m_nIdContainer != -1)
				{
					System.Collections.ArrayList arlCondicaoCampo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoComparador = new System.Collections.ArrayList();
					System.Collections.ArrayList arlCondicaoValor = new System.Collections.ArrayList();

					arlCondicaoCampo.Add("nIdExportador");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdExportador);

					arlCondicaoCampo.Add("strIdPe");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_strIdPe);

					arlCondicaoCampo.Add("nIdContainer");
					arlCondicaoComparador.Add(mdlDataBaseAccess.Comparador.Igual);
					arlCondicaoValor.Add(m_nIdContainer);

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
					m_typDatSetProcessosContainers = m_cls_dba_ConnectionDB.GetTbProcessosContainers(arlCondicaoCampo,arlCondicaoComparador,arlCondicaoValor,null,null);
				}
			}

			private void vCarregaDadosTransportadoras()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typdatSetTransportadoras = m_cls_dba_ConnectionDB.GetTbTransportadoras(null,null,null,null,null);
			}

			private void vCarregaDadosTransportadorasContatos()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTransportadorasContatos = m_cls_dba_ConnectionDB.GetTbTransportadorasContatos(null,null,null,null,null);
			}

			private void vCarregaDadosTransportadorasMotoristas()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typDatSetTransportadorasMotoristas = m_cls_dba_ConnectionDB.GetTbTransportadorasMotoristas(null,null,null,null,null);
			}

			private void vCarregaDadosTransportadorasVeiculos()
			{
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
				m_typdatSetTransportadorasVeiculos = m_cls_dba_ConnectionDB.GetTbTransportadorasVeiculos(null,null,null,null,null);
			}
		#endregion
		#region Salvamento dos Dados
			private bool bSalvaDados()
			{
				bool bRetorno = false;
				if (bSalvaDadosPe())
					if (bSalvaDadosContainers())
						if (bSalvaDadosTransportadorasVeiculos())
							if (bSalvaDadosTransportadorasMotoristas())
								if (bSalvaDadosTransportadorasContatos())
									m_bModificado = bRetorno = bSalvaDadosTransportadoras();
				return(bRetorno);
			}

			private bool bSalvaDadosPe()
			{
				if (m_strIdPe != "")
				{
					m_cls_dba_ConnectionDB.SetTbPes(m_typDatSetPes);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				else
				{
					return(true);
				}
			}

			private bool bSalvaDadosContainers()
			{
				if (m_nIdContainer != -1)
				{
					m_cls_dba_ConnectionDB.SetTbProcessosContainers(m_typDatSetProcessosContainers);
					return(m_cls_dba_ConnectionDB.Erro == null);
				}
				else
				{
					return(true);
				}
			}


			private bool bSalvaDadosTransportadoras()
			{
				m_cls_dba_ConnectionDB.SetTbTransportadoras(m_typdatSetTransportadoras);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosTransportadorasContatos()
			{
				m_cls_dba_ConnectionDB.SetTbTransportadorasContatos(m_typDatSetTransportadorasContatos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosTransportadorasMotoristas()
			{
				m_cls_dba_ConnectionDB.SetTbTransportadorasMotoristas(m_typDatSetTransportadorasMotoristas);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}

			private bool bSalvaDadosTransportadorasVeiculos()
			{
				m_cls_dba_ConnectionDB.SetTbTransportadorasVeiculos(m_typdatSetTransportadorasVeiculos);
				return(m_cls_dba_ConnectionDB.Erro == null);
			}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				Formularios.frmFTransportadoras formFTransportadoras = new mdlTransportadoras.Formularios.frmFTransportadoras(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFTransportadoras);
				formFTransportadoras.ShowDialog();
			}

			private void vInitializeEvents(ref Formularios.frmFTransportadoras formFTransportadoras)
			{
				// Transportadoras Refresh
				formFTransportadoras.eCallTransportadorasRefresh += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadorasRefresh(vTransportadorasRefresh);

				// Transportadora Carrega Selecionada
				formFTransportadoras.eCallTransportadoraCarregaSelecionada += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadoraCarregaSelecionada(vCarregaDadosTransportadoraSelecionada);

				// Transportadora Salva Selecionada
				formFTransportadoras.eCallTransportadoraSalvaSelecionada += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadoraSalvaSelecionada(vSalvaDadosTransportadoraSelecionada);

				// Transportadora Nova
				formFTransportadoras.eCallTransportadorasNova += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadorasNova(ShowDialogNova);

				// Transportadora Editar
				formFTransportadoras.eCallTransportadorasEditar += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadorasEditar(ShowDialogEditar);

				// Transportadoras Excluir 
				formFTransportadoras.eCallTransportadorasExcluir += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallTransportadorasExcluir(bTransportadorasExclui);

				// ShowDialog Contatos
				formFTransportadoras.eCallShowDialogContatos += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallShowDialogContatos(ShowDialogContatos);
				
				// ShowDialog Motoristas
				formFTransportadoras.eCallShowDialogMotoristas += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallShowDialogMotoristas(ShowDialogMotoristas);

				// ShowDialog Veiculos
				formFTransportadoras.eCallShowDialogVeiculos += new mdlTransportadoras.Formularios.frmFTransportadoras.delCallShowDialogVeiculos(ShowDialogVeiculos);

				// Salva Dados
				formFTransportadoras.eCallSalvaDados +=	new mdlTransportadoras.Formularios.frmFTransportadoras.delCallSalvaDados(bSalvaDados);
			}
		#endregion
		#region ShowDialogNova
			private bool ShowDialogNova()
			{
				Formularios.frmFTransportadorasEdicao formFTransportadoraEdicao = new mdlTransportadoras.Formularios.frmFTransportadorasEdicao(m_strEnderecoExecutavel);
				vInitializeEvents(ref formFTransportadoraEdicao);
				formFTransportadoraEdicao.ShowDialog();
				return(formFTransportadoraEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFTransportadorasEdicao formFTransportadoraEdicao)
			{
				// Refresh Estados Brasileiros
				formFTransportadoraEdicao.eCallCarregaDadosEstadosBrasileiros += new mdlTransportadoras.Formularios.frmFTransportadorasEdicao.delCallCarregaDadosEstadosBrasileiros(vRefreshEstadosBrasileiros);

				// Carrega dados
				formFTransportadoraEdicao.eCallCarregaDados += new mdlTransportadoras.Formularios.frmFTransportadorasEdicao.delCallCarregaDados(vCarregaDadosTransportadora);

				// Salva dados
				formFTransportadoraEdicao.eCallSalvaDados += new mdlTransportadoras.Formularios.frmFTransportadorasEdicao.delCallSalvaDados(bSalvaDadosTransportadora);

			}
		#endregion
		#region ShowDialogEditar
			private bool ShowDialogEditar(int nIdTransportadora)
			{
				Formularios.frmFTransportadorasEdicao formFTransportadoraEdicao = new mdlTransportadoras.Formularios.frmFTransportadorasEdicao(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFTransportadoraEdicao);
				formFTransportadoraEdicao.ShowDialog();
				return(formFTransportadoraEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogContatos
			public void ShowDialogContatos()
			{
				int nIdTransportadora;
				vCarregaDadosTransportadoraSelecionada(out nIdTransportadora);
				if (nIdTransportadora == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogContatos(nIdTransportadora))
						bSalvaDados();
				}
			}

			private bool ShowDialogContatos(int nIdTransportadora)
			{
				m_typDatSetTransportadorasContatosCopy = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos)m_typDatSetTransportadorasContatos.Copy();
				Formularios.frmFContatos formFContatos = new mdlTransportadoras.Formularios.frmFContatos(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFContatos);
				formFContatos.ShowDialog();
				if (!formFContatos.m_bModificado)
					m_typDatSetTransportadorasContatos = m_typDatSetTransportadorasContatosCopy;
				return(formFContatos.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFContatos formFContatos)
			{
				// Contatos Refresh
				formFContatos.eCallContatosRefresh += new mdlTransportadoras.Formularios.frmFContatos.delCallContatosRefresh(vContatosRefresh);

				// Contatos Carrega Selecionado
				formFContatos.eCallContatosCarregaSelecionado += new mdlTransportadoras.Formularios.frmFContatos.delCallContatosCarregaSelecionado(vCarregaDadosTransportadoraContatoSelecionado);

				// Contatos Salva Selecionado
				formFContatos.eCallContatosSalvaSelecionado += new mdlTransportadoras.Formularios.frmFContatos.delCallContatosSalvaSelecionado(vSalvaDadosTransportadoraContatoSelecionado);

				// Contato Novo
				formFContatos.eCallContatoNovo += new mdlTransportadoras.Formularios.frmFContatos.delCallContatoNovo(ShowDialogContatoNovo);

				// Contato Editar
				formFContatos.eCallContatoEditar += new mdlTransportadoras.Formularios.frmFContatos.delCallContatoEditar(ShowDialogContatoEditar);

				// Contato Exclui
				formFContatos.eCallContatosExcluir += new mdlTransportadoras.Formularios.frmFContatos.delCallContatosExcluir(bTransportadoraContatoExclui);
			}
		#endregion
		#region ShowDialogContatosNovo
			private bool ShowDialogContatoNovo(int nIdTransportadora)
			{
				Formularios.frmFContatosEdicao formFContatoEdicao = new mdlTransportadoras.Formularios.frmFContatosEdicao(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}
			
			private void vInitializeEvents(ref Formularios.frmFContatosEdicao formFContatoEdicao)
			{
				// Carrega Dados
				formFContatoEdicao.eCallCarregaDados += new mdlTransportadoras.Formularios.frmFContatosEdicao.delCallCarregaDados(vCarregaDadosTransportadoraContato);

				// Salva Dados
				formFContatoEdicao.eCallSalvaDados += new mdlTransportadoras.Formularios.frmFContatosEdicao.delCallSalvaDados(bSalvaDadosTransportadoraContato);
			}
		#endregion
		#region ShowDialogContatosEditar
			private bool ShowDialogContatoEditar(int nIdTransportadora,int nIdContato)
			{
				Formularios.frmFContatosEdicao formFContatoEdicao = new mdlTransportadoras.Formularios.frmFContatosEdicao(m_strEnderecoExecutavel,nIdTransportadora,nIdContato);
				vInitializeEvents(ref formFContatoEdicao);
				formFContatoEdicao.ShowDialog();
				return(formFContatoEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogMotoristas
			public void ShowDialogMotoristas()
			{
				int nIdTransportadora;
				vCarregaDadosTransportadoraSelecionada(out nIdTransportadora);
				if (nIdTransportadora == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogMotoristas(nIdTransportadora))
						bSalvaDados();
				}
			}

			private bool ShowDialogMotoristas(int nIdTransportadora)
			{
				m_typDatSetTransportadorasMotoristasCopy = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas)m_typDatSetTransportadorasMotoristas.Copy();
				Formularios.frmFMotoristas formFMotoristas = new mdlTransportadoras.Formularios.frmFMotoristas(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFMotoristas);
				formFMotoristas.ShowDialog();
				if (!formFMotoristas.m_bModificado)
					m_typDatSetTransportadorasMotoristas = m_typDatSetTransportadorasMotoristasCopy;
				return(formFMotoristas.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFMotoristas formFMotoristas)
			{
				// Motoristas Refresh
				formFMotoristas.eCallMotoristasRefresh += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasRefresh(vMotoristasRefresh);

				// Motoristas Carrega Selecionado
				formFMotoristas.eCallMotoristasCarregaSelecionado += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasCarregaSelecionado(vCarregaDadosTransportadoraMotoristaSelecionado);

				// Motoristas Salva Selecionado
				formFMotoristas.eCallMotoristasSalvaSelecionado += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasSalvaSelecionado(vSalvaDadosTransportadoraMotoristaSelecionado);

				// Motoristas Novo
				formFMotoristas.eCallMotoristasNovo += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasNovo(ShowDialogMotoristasNovo);

				// Motoristas Editar
				formFMotoristas.eCallMotoristasEditar += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasEditar(ShowDialogMotoristasEditar);

				// Motoristas Excluir
				formFMotoristas.eCallMotoristasExcluir += new mdlTransportadoras.Formularios.frmFMotoristas.delCallMotoristasExcluir(bTransportadoraMotoristaExclui);
			}
		#endregion
		#region ShowDialogMotoristasNovo
			private bool ShowDialogMotoristasNovo(int nIdTransportadora)
			{
				Formularios.frmFMotoristasEdicao formFMotoristaEdicao = new mdlTransportadoras.Formularios.frmFMotoristasEdicao(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFMotoristaEdicao);
				formFMotoristaEdicao.ShowDialog();
				return(formFMotoristaEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFMotoristasEdicao formFMotoristaEdicao)
			{
				// Carrega Dados
				formFMotoristaEdicao.eCallCarregaDados += new mdlTransportadoras.Formularios.frmFMotoristasEdicao.delCallCarregaDados(vCarregaDadosTransportadoraMotorista);
			
				// Salva Dados
				formFMotoristaEdicao.eCallSalvaDados += new mdlTransportadoras.Formularios.frmFMotoristasEdicao.delCallSalvaDados(bSalvaDadosTransportadoraMotorista);

			}
		#endregion
		#region ShowDialogMotoristasEditar
			private bool ShowDialogMotoristasEditar(int nIdTransportadora,int nIdMotorista)
			{
				Formularios.frmFMotoristasEdicao formFMotoristaEdicao = new mdlTransportadoras.Formularios.frmFMotoristasEdicao(m_strEnderecoExecutavel,nIdTransportadora,nIdMotorista);
				vInitializeEvents(ref formFMotoristaEdicao);
				formFMotoristaEdicao.ShowDialog();
				return(formFMotoristaEdicao.m_bModificado);
			}
		#endregion
		#region ShowDialogVeiculos
			public void ShowDialogVeiculos()
			{
				int nIdTransportadora;
				vCarregaDadosTransportadoraSelecionada(out nIdTransportadora);
				if (nIdTransportadora == -1)
				{
					ShowDialog();
				}
				else
				{
					if(ShowDialogVeiculos(nIdTransportadora))
						bSalvaDados();
				}
			}

			private bool ShowDialogVeiculos(int nIdTransportadora)
			{
				m_typdatSetTransportadorasVeiculosCopy = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos)m_typdatSetTransportadorasVeiculos.Copy();
				Formularios.frmFVeiculos formFVeiculos = new mdlTransportadoras.Formularios.frmFVeiculos(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFVeiculos);
				formFVeiculos.ShowDialog();
				if (!formFVeiculos.m_bModificado)
					m_typdatSetTransportadorasVeiculos = m_typdatSetTransportadorasVeiculosCopy;
				return(formFVeiculos.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFVeiculos formFVeiculos)
			{
				// Veiculos Refresh
				formFVeiculos.eCallVeiculosRefresh += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosRefresh(vVeiculosRefresh);

				// Veiculos Carrega Selecionado
				formFVeiculos.eCallVeiculosCarregaSelecionado += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosCarregaSelecionado(vCarregaDadosTransportadoraVeiculoSelecionado);

				// Veiculos Salva Selecionado
				formFVeiculos.eCallVeiculosSalvaSelecionado += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosSalvaSelecionado(vSalvaDadosTransportadoraVeiculoSelecionado);

				// Veiculos Novo
				formFVeiculos.eCallVeiculosNovo += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosNovo(ShowDialogVeiculosNovo);

				// Veiculos Editar
				formFVeiculos.eCallVeiculosEditar += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosEditar(ShowDialogVeiculosEditar);

				// Veiculos Excluir
				formFVeiculos.eCallVeiculosExcluir += new mdlTransportadoras.Formularios.frmFVeiculos.delCallVeiculosExcluir(bTransportadoraVeiculoExclui);
			}
		#endregion
		#region ShowDialogVeiculosNovo
			private bool ShowDialogVeiculosNovo(int nIdTransportadora)
			{
				Formularios.frmFVeiculosEdicao formFVeiculoEdicao = new Formularios.frmFVeiculosEdicao(m_strEnderecoExecutavel,nIdTransportadora);
				vInitializeEvents(ref formFVeiculoEdicao);
				formFVeiculoEdicao.ShowDialog();
				return(formFVeiculoEdicao.m_bModificado);
			}

			private void vInitializeEvents(ref Formularios.frmFVeiculosEdicao formFVeiculoEdicao)
			{
				// Carrega Dados
				formFVeiculoEdicao.eCallCarregaDados += new mdlTransportadoras.Formularios.frmFVeiculosEdicao.delCallCarregaDados(vCarregaDadosTransportadoraVeiculo);

				// Salva Dados
				formFVeiculoEdicao.eCallSalvaDados += new mdlTransportadoras.Formularios.frmFVeiculosEdicao.delCallSalvaDados(bSalvaDadosTransportadoraVeiculo);

			}
		#endregion
		#region ShowDialogVeiculosEditar
			private bool ShowDialogVeiculosEditar(int nIdTransportadora,int nIdVeiculo)
			{
				Formularios.frmFVeiculosEdicao formFVeiculoEdicao = new Formularios.frmFVeiculosEdicao(m_strEnderecoExecutavel,nIdTransportadora,nIdVeiculo);
				vInitializeEvents(ref formFVeiculoEdicao);
				formFVeiculoEdicao.ShowDialog();
				return(formFVeiculoEdicao.m_bModificado);
			}
		#endregion

		#region Selecao Transportadoras
			private void vCarregaDadosTransportadoraSelecionada(out int nIdTransportadora)
			{
				nIdTransportadora = -1;
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					if (!dtrwContainer.IsnIdTransportadoraNull())
						nIdTransportadora = dtrwContainer.nIdTransportadora;
				}
			}

			private void vSalvaDadosTransportadoraSelecionada(int nIdTransportadora)
			{
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					dtrwContainer.nIdTransportadora = nIdTransportadora;
				}
			}
		#endregion
		#region Transportadoras
			private void vTransportadorasRefresh(ref System.Windows.Forms.ListView lvTransportadoras)
			{
				lvTransportadoras.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListTransportadoras = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwTransportadora in m_typdatSetTransportadoras.tbTransportadoras.Rows)
					if ((dtrwTransportadora.RowState != System.Data.DataRowState.Deleted) && (!dtrwTransportadora.IsstrNomeNull()))
						if (!sortListTransportadoras.ContainsKey(dtrwTransportadora.strNome))
							sortListTransportadoras.Add(dtrwTransportadora.strNome,dtrwTransportadora);

				// Insert
				for(int i = 0; i < sortListTransportadoras.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwTransportadoraInserir = (mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow)sortListTransportadoras.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvTransportadoras.Items.Add(dtrwTransportadoraInserir.strNome);
					lviInsert.Tag = dtrwTransportadoraInserir.nIdTransportadora;
					if ((m_nIdSelect != -1) && (dtrwTransportadoraInserir.nIdTransportadora == m_nIdSelect))
					{
						lviInsert.Selected = true;
						m_nIdSelect = -1;
					}
				}
			}

			private void vCarregaDadosTransportadora(int nIdTransportadora,out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out int nIdEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strTelefone = strFax = strEmail = strSite = "";
				nIdEstado = -1;

				mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwTransportadora = m_typdatSetTransportadoras.tbTransportadoras.FindBynIdTransportadora(nIdTransportadora);
				if ((dtrwTransportadora != null) && (dtrwTransportadora.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwTransportadora.IsstrNomeNull())
						strNome = dtrwTransportadora.strNome;
					//strEndereco 
					if (!dtrwTransportadora.IsmstrEnderecoNull())
						strEndereco = dtrwTransportadora.mstrEndereco;
					//strCEP 
					if (!dtrwTransportadora.IsstrCEPNull())
						strCEP = dtrwTransportadora.strCEP;
					//strBairro 
					if (!dtrwTransportadora.IsstrBairroNull())
						strBairro = dtrwTransportadora.strBairro;
					//strCidade 
					if (!dtrwTransportadora.IsmstrCidadeNull())
						strCidade = dtrwTransportadora.mstrCidade;
					//nIdEstado
					if (!dtrwTransportadora.IsnIdEstadoNull())
						nIdEstado = dtrwTransportadora.nIdEstado;
					//strTelefone
					if (!dtrwTransportadora.IsstrTelefoneNull())
						strTelefone = dtrwTransportadora.strTelefone;
					//strFax 
					if (!dtrwTransportadora.IsstrFaxNull())
						strFax = dtrwTransportadora.strFax;
					//strEmail 
					if (!dtrwTransportadora.IsstrEmailNull())
						strEmail = dtrwTransportadora.strEmail;
					//strSite 
					if (!dtrwTransportadora.IsstrSiteNull())
						strSite = dtrwTransportadora.strSite;
				}
			}

			private bool bSalvaDadosTransportadora(int nIdTransportadora,string strNome,string strEndereco,string strCEP,string strBairro,string strCidade,int nIdEstado,string strTelefone,string strFax,string strEmail,string strSite)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome da transportadora.");
					return(false);
				}

				if (nIdEstado == -2)
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher corretamente o campo Estado.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwTransportadora = m_typdatSetTransportadoras.tbTransportadoras.FindBynIdTransportadora(nIdTransportadora);
				if (bAdd = (dtrwTransportadora == null))
				{
					dtrwTransportadora = m_typdatSetTransportadoras.tbTransportadoras.NewtbTransportadorasRow();
					dtrwTransportadora.nIdTransportadora = nNextIdTransportadora();
				}
				dtrwTransportadora.strNome = strNome;
				dtrwTransportadora.mstrEndereco = strEndereco;
				dtrwTransportadora.strCEP = strCEP;
				dtrwTransportadora.strBairro = strBairro;
				dtrwTransportadora.mstrCidade = strCidade;
				dtrwTransportadora.nIdEstado = nIdEstado;
				dtrwTransportadora.strTelefone = strTelefone;
				dtrwTransportadora.strFax = strFax;
				dtrwTransportadora.strEmail = strEmail;
				dtrwTransportadora.strSite = strSite;

				m_nIdSelect = dtrwTransportadora.nIdTransportadora;

				if (bAdd)
					m_typdatSetTransportadoras.tbTransportadoras.AddtbTransportadorasRow(dtrwTransportadora);
				return(true);
			}
				
			private int nNextIdTransportadora()
			{
				int nRetorno = 1;
				while(m_typdatSetTransportadoras.tbTransportadoras.FindBynIdTransportadora(nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTransportadorasExclui(ref System.Collections.ArrayList arlTransportadoras,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir esta(s) transportadora(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Transportadoras
				for(int i = m_typdatSetTransportadoras.tbTransportadoras.Rows.Count - 1; i >= 0; i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow dtrwTransportadora = (mdlDataBaseAccess.Tabelas.XsdTbTransportadoras.tbTransportadorasRow)m_typdatSetTransportadoras.tbTransportadoras.Rows[i];
					if (dtrwTransportadora.RowState != System.Data.DataRowState.Deleted)
						if (arlTransportadoras.Contains(dtrwTransportadora.nIdTransportadora))
							dtrwTransportadora.Delete();
				}

				// Contatos
				for(int i = m_typDatSetTransportadorasContatos.tbTransportadorasContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow)m_typDatSetTransportadorasContatos.tbTransportadorasContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (arlTransportadoras.Contains(dtrwContato.nIdTransportadora)))
						dtrwContato.Delete();
				}

				// Motoristas
				for(int i = m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotorista = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow)m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.Rows[i];
					if ((dtrwMotorista.RowState != System.Data.DataRowState.Deleted) && (arlTransportadoras.Contains(dtrwMotorista.nIdTransportadora)))
						dtrwMotorista.Delete();
				}

				// Veiculos
				for(int i = m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculo = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow)m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.Rows[i];
					if ((dtrwVeiculo.RowState != System.Data.DataRowState.Deleted) && (arlTransportadoras.Contains(dtrwVeiculo.nIdTransportadora)))
						dtrwVeiculo.Delete();
				}

				return(true);
			}
		#endregion
		#region Selecao Contatos
			private void vCarregaDadosTransportadoraContatoSelecionado(out int nIdContato)
			{
				nIdContato = -1;
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					if (!dtrwContainer.IsnIdTransportadoraContatoNull())
						nIdContato = dtrwContainer.nIdTransportadoraContato;
				}
			}

			private void vSalvaDadosTransportadoraContatoSelecionado(int nIdContato)
			{
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					dtrwContainer.nIdTransportadoraContato = nIdContato;
				}
			}
		#endregion
		#region Contatos
			private void vContatosRefresh(int nIdTransportadora,ref System.Windows.Forms.ListView lvContatos)
			{
				lvContatos.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListContatos = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContato in m_typDatSetTransportadorasContatos.tbTransportadorasContatos.Rows)
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdTransportadora == nIdTransportadora) && (!dtrwContato.IsstrNomeNull()))
						if (!sortListContatos.ContainsKey(dtrwContato.strNome))
							sortListContatos.Add(dtrwContato.strNome,dtrwContato);

				// Insert
				for(int i = 0; i < sortListContatos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContatoInserir = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow)sortListContatos.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvContatos.Items.Add(dtrwContatoInserir.strNome);
					lviInsert.Tag = dtrwContatoInserir.nIdContato;
					if ((m_nIdSelectContato != -1) && (dtrwContatoInserir.nIdContato == m_nIdSelectContato))
					{
						lviInsert.Selected = true;
						m_nIdSelectContato = -1;
					}
				}
			}

			private void vCarregaDadosTransportadoraContato(int nIdTransportadora,int nIdContato,out string strNome,out string strTelefone,out string strFax,out string strEmail)
			{
				strNome = strTelefone = strFax = strEmail = "";

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContato = m_typDatSetTransportadorasContatos.tbTransportadorasContatos.FindBynIdTransportadoranIdContato(nIdTransportadora,nIdContato);
				if ((dtrwContato != null) && (dtrwContato.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwContato.IsstrNomeNull())
						strNome = dtrwContato.strNome;
					//strTelefone
					if (!dtrwContato.IsstrTelefoneNull())
						strTelefone = dtrwContato.strTelefone;
					//strFax 
					if (!dtrwContato.IsstrFaxNull())
						strFax = dtrwContato.strFax;
					//strEmail 
					if (!dtrwContato.IsstrEmailNull())
						strEmail = dtrwContato.strEmail;
				}
			}

			private bool bSalvaDadosTransportadoraContato(int nIdTransportadora,int nIdContato,string strNome,string strTelefone,string strFax,string strEmail)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do contato.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContato = m_typDatSetTransportadorasContatos.tbTransportadorasContatos.FindBynIdTransportadoranIdContato(nIdTransportadora,nIdContato);
				if (bAdd = (dtrwContato == null))
				{
					dtrwContato = m_typDatSetTransportadorasContatos.tbTransportadorasContatos.NewtbTransportadorasContatosRow();
					dtrwContato.nIdTransportadora = nIdTransportadora;
					dtrwContato.nIdContato = nNextIdTransportadoraContato(nIdTransportadora);
				}
				dtrwContato.strNome = strNome;
				dtrwContato.strTelefone = strTelefone;
				dtrwContato.strFax = strFax;
				dtrwContato.strEmail = strEmail;

				m_nIdSelectContato = dtrwContato.nIdContato;

				if (bAdd)
					m_typDatSetTransportadorasContatos.tbTransportadorasContatos.AddtbTransportadorasContatosRow(dtrwContato);
				return(true);
			}
					
			private int nNextIdTransportadoraContato(int nIdTransportadora)
			{
				int nRetorno = 1;
				while(m_typDatSetTransportadorasContatos.tbTransportadorasContatos.FindBynIdTransportadoranIdContato(nIdTransportadora,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTransportadoraContatoExclui(int nIdTransportadora,ref System.Collections.ArrayList arlContatos,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) contato(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Contatos
				for(int i = m_typDatSetTransportadorasContatos.tbTransportadorasContatos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow dtrwContato = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasContatos.tbTransportadorasContatosRow)m_typDatSetTransportadorasContatos.tbTransportadorasContatos.Rows[i];
					if ((dtrwContato.RowState != System.Data.DataRowState.Deleted) && (dtrwContato.nIdTransportadora == nIdTransportadora))
						if (arlContatos.Contains(dtrwContato.nIdContato))
							dtrwContato.Delete();
				}
				return(true);
			}
		#endregion
		#region Selecao Motoristas
			private void vCarregaDadosTransportadoraMotoristaSelecionado(out int nIdMotorista)
			{
				nIdMotorista = -1;
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					if (!dtrwContainer.IsnIdTransportadoraMotoristaNull())
						nIdMotorista = dtrwContainer.nIdTransportadoraMotorista;
				}
			}

			private void vSalvaDadosTransportadoraMotoristaSelecionado(int nIdMotorista)
			{
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					dtrwContainer.nIdTransportadoraMotorista = nIdMotorista;
				}
			}
		#endregion
		#region Motoristas
			private void vMotoristasRefresh(int nIdTransportadora,ref System.Windows.Forms.ListView lvMotoristas)
			{
				lvMotoristas.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListMotoristas = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotorista in m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.Rows)
					if ((dtrwMotorista.RowState != System.Data.DataRowState.Deleted) && (dtrwMotorista.nIdTransportadora == nIdTransportadora) && (!dtrwMotorista.IsstrNomeNull()))
						if (!sortListMotoristas.ContainsKey(dtrwMotorista.strNome))
							sortListMotoristas.Add(dtrwMotorista.strNome,dtrwMotorista);

				// Insert
				for(int i = 0; i < sortListMotoristas.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotoristasInserir = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow)sortListMotoristas.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviInsert = lvMotoristas.Items.Add(dtrwMotoristasInserir.strNome);
					lviInsert.Tag = dtrwMotoristasInserir.nIdMotorista;
					if ((m_nIdSelectMotorista != -1) && (dtrwMotoristasInserir.nIdMotorista == m_nIdSelectMotorista))
					{
						lviInsert.Selected = true;
						m_nIdSelectMotorista = -1;
					}
				}
			}

			private void vCarregaDadosTransportadoraMotorista(int nIdTransportadora,int nIdMotorista,out string strNome,out string strTelefone)
			{
				strNome = strTelefone = "";

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotorista = m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.FindBynIdTransportadoranIdMotorista(nIdTransportadora,nIdMotorista);
				if ((dtrwMotorista != null) && (dtrwMotorista.RowState != System.Data.DataRowState.Deleted))
				{
					//strNome 
					if (!dtrwMotorista.IsstrNomeNull())
						strNome = dtrwMotorista.strNome;
					//strTelefone
					if (!dtrwMotorista.IsstrTelefoneNull())
						strTelefone = dtrwMotorista.strTelefone;
				}
			}

			private bool bSalvaDadosTransportadoraMotorista(int nIdTransportadora,int nIdMotorista,string strNome,string strTelefone)
			{
				bool bAdd = false;

				if (strNome == "")
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher o nome do motorista.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotorista = m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.FindBynIdTransportadoranIdMotorista(nIdTransportadora,nIdMotorista);
				if (bAdd = (dtrwMotorista == null))
				{
					dtrwMotorista = m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.NewtbTransportadorasMotoristasRow();
					dtrwMotorista.nIdTransportadora = nIdTransportadora;
					dtrwMotorista.nIdMotorista = nNextIdTransportadoraMotorista(nIdTransportadora);
				}
				dtrwMotorista.strNome = strNome;
				dtrwMotorista.strTelefone = strTelefone;

				m_nIdSelectMotorista = dtrwMotorista.nIdMotorista;

				if (bAdd)
					m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.AddtbTransportadorasMotoristasRow(dtrwMotorista);
				return(true);
			}
						
			private int nNextIdTransportadoraMotorista(int nIdTransportadora)
			{
				int nRetorno = 1;
				while(m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.FindBynIdTransportadoranIdMotorista(nIdTransportadora,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTransportadoraMotoristaExclui(int nIdTransportadora,ref System.Collections.ArrayList arlMotoristas,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) motorista(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Motorista
				for(int i = m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow dtrwMotorista = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasMotoristas.tbTransportadorasMotoristasRow)m_typDatSetTransportadorasMotoristas.tbTransportadorasMotoristas.Rows[i];
					if ((dtrwMotorista.RowState != System.Data.DataRowState.Deleted) && (dtrwMotorista.nIdTransportadora == nIdTransportadora))
						if (arlMotoristas.Contains(dtrwMotorista.nIdMotorista))
							dtrwMotorista.Delete();
				}
				return(true);
			}
		#endregion
		#region Selecao Veiculos
			private void vCarregaDadosTransportadoraVeiculoSelecionado(out int nIdVeiculo)
			{
				nIdVeiculo = -1;
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					if (!dtrwContainer.IsnIdTransportadoraVeiculoNull())
						nIdVeiculo = dtrwContainer.nIdTransportadoraVeiculo;
				}
			}

			private void vSalvaDadosTransportadoraVeiculoSelecionado(int nIdVeiculo)
			{
				if ((m_typDatSetProcessosContainers != null) && (m_typDatSetProcessosContainers.tbProcessosContainers.Rows.Count > 0 ))
				{
					mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow dtrwContainer = (mdlDataBaseAccess.Tabelas.XsdTbProcessosContainers.tbProcessosContainersRow)m_typDatSetProcessosContainers.tbProcessosContainers.Rows[0];
					dtrwContainer.nIdTransportadoraVeiculo = nIdVeiculo;
				}
			}
		#endregion
		#region Veiculos
			private void vVeiculosRefresh(int nIdTransportadora,ref System.Windows.Forms.ListView lvVeiculos)
			{
				lvVeiculos.Items.Clear();

				// Sorting
				System.Collections.SortedList sortListVeiculos = new System.Collections.SortedList();
				foreach(mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculo in m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.Rows)
					if ((dtrwVeiculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVeiculo.nIdTransportadora == nIdTransportadora) && (!dtrwVeiculo.IsstrDescricaoNull()))
						if (!sortListVeiculos.ContainsKey(dtrwVeiculo.strDescricao))
							sortListVeiculos.Add(dtrwVeiculo.strDescricao,dtrwVeiculo);

				// Insert
				for(int i = 0; i < sortListVeiculos.Count;i++)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculoInserir = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow)sortListVeiculos.GetByIndex(i);
					System.Windows.Forms.ListViewItem lviVeiculo = lvVeiculos.Items.Add(dtrwVeiculoInserir.strIdentificacao);
					lviVeiculo.SubItems.Add(dtrwVeiculoInserir.strDescricao);
					lviVeiculo.Tag = dtrwVeiculoInserir.nIdVeiculo;
					if ((m_nIdSelectVeiculo != -1) && (dtrwVeiculoInserir.nIdVeiculo == m_nIdSelectVeiculo))
					{
						lviVeiculo.Selected = true;
						m_nIdSelectVeiculo = -1;
					}
				}
			}

			private void vCarregaDadosTransportadoraVeiculo(int nIdTransportadora,int nIdVeiculo,out string strDescricao,out string strIdentificacao)
			{
				strDescricao = strIdentificacao = "";

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculo = m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.FindBynIdTransportadoranIdVeiculo(nIdTransportadora,nIdVeiculo);
				if ((dtrwVeiculo != null) && (dtrwVeiculo.RowState != System.Data.DataRowState.Deleted))
				{
					//strDescricao
					if (!dtrwVeiculo.IsstrDescricaoNull())
						strDescricao = dtrwVeiculo.strDescricao;
					//strTelefone
					if (!dtrwVeiculo.IsstrIdentificacaoNull())
						strIdentificacao = dtrwVeiculo.strIdentificacao;
				}
			}

			private bool bSalvaDadosTransportadoraVeiculo(int nIdTransportadora,int nIdVeiculo,string strDescricao,string strIdentificacao)
			{
				bool bAdd = false;

				if ((strDescricao == "") && (strIdentificacao == ""))
				{
					mdlMensagens.clsMensagens.ShowInformation("Você deve preencher pelo menos alguma informação sobre o veículo.");
					return(false);
				}

				mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculo = m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.FindBynIdTransportadoranIdVeiculo(nIdTransportadora,nIdVeiculo);
				if (bAdd = (dtrwVeiculo == null))
				{
					dtrwVeiculo = m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.NewtbTransportadorasVeiculosRow();
					dtrwVeiculo.nIdTransportadora = nIdTransportadora;
					dtrwVeiculo.nIdVeiculo = nNextIdTransportadoraVeiculo(nIdTransportadora);
				}
				dtrwVeiculo.nIdTipoVeiculo = 1; // Carro
				dtrwVeiculo.strDescricao = strDescricao;
				dtrwVeiculo.strIdentificacao = strIdentificacao;

				m_nIdSelectVeiculo = dtrwVeiculo.nIdVeiculo;

				if (bAdd)
					m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.AddtbTransportadorasVeiculosRow(dtrwVeiculo);
				return(true);
			}
							
			private int nNextIdTransportadoraVeiculo(int nIdTransportadora)
			{
				int nRetorno = 1;
				while(m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.FindBynIdTransportadoranIdVeiculo(nIdTransportadora,nRetorno) != null)
					nRetorno++;
				return(nRetorno);
			}

			private bool bTransportadoraVeiculoExclui(int nIdTransportadora,ref System.Collections.ArrayList arlVeiculos,bool bSilent)
			{
				if (!bSilent)
					if (mdlMensagens.clsMensagens.ShowInformation("Siscobras","Deseja mesmo excluir este(s) veiculo(s) ?",System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						return(false);

				// Veiculo
				for(int i = m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.Rows.Count - 1; i >= 0;i--)
				{
					mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow dtrwVeiculo = (mdlDataBaseAccess.Tabelas.XsdTbTransportadorasVeiculos.tbTransportadorasVeiculosRow)m_typdatSetTransportadorasVeiculos.tbTransportadorasVeiculos.Rows[i];
					if ((dtrwVeiculo.RowState != System.Data.DataRowState.Deleted) && (dtrwVeiculo.nIdTransportadora == nIdTransportadora))
						if (arlVeiculos.Contains(dtrwVeiculo.nIdVeiculo))
							dtrwVeiculo.Delete();
				}
				return(true);
			}
		#endregion
		#region Estados Brasileiros
			private void vRefreshEstadosBrasileiros(ref mdlComponentesGraficos.ComboBox cbEstadosBrasileiros)
			{
				cbEstadosBrasileiros.Clear();
	                
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros typDatSetEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,null,null);
				foreach(mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwEstadoBrasileiro in typDatSetEstadosBrasileiros.tbEstadosBrasileiros.Rows)
					cbEstadosBrasileiros.AddItem(dtrwEstadoBrasileiro.strNome,dtrwEstadoBrasileiro.nIdEstado);
			}

			private string strRetornaSiglaEstadoBrasileiro(int nIdEstado)
			{
				string strReturn = "";
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros typDatSetEstadosBrasileiros = m_cls_dba_ConnectionDB.GetTbEstadosBrasileiros(null,null,null,null,null);
				mdlDataBaseAccess.Tabelas.XsdTbEstadosBrasileiros.tbEstadosBrasileirosRow dtrwEstado = typDatSetEstadosBrasileiros.tbEstadosBrasileiros.FindBynIdEstado(nIdEstado);
				if (dtrwEstado != null)
					strReturn = dtrwEstado.strSigla;
				return(strReturn);
			}
		#endregion

		#region Retorno
			public void vRetornaValores(out string strNome,out string strEndereco,out string strCEP,out string strBairro,out string strCidade,out string strEstado,out string strTelefone,out string strFax,out string strEmail,out string strSite,out string strContatoNome,out string strContatoTelefone,out string strContatoFax,out string strContatoEmail,out string strMotoristaNome,out string strMotoristaTelefone,out string strVeiculoDescricao,out string strVeiculoIdentificacao)
			{
				strNome = strEndereco = strCEP = strBairro = strCidade = strEstado = strTelefone = strFax = strEmail = strSite = strContatoNome = strContatoTelefone = strContatoFax = strContatoEmail = strMotoristaNome = strMotoristaTelefone = strVeiculoDescricao = strVeiculoIdentificacao = "";
				int nIdTransportadora;
				vCarregaDadosTransportadoraSelecionada(out nIdTransportadora);
				if (nIdTransportadora != -1)
				{
					int nIdEstado;
					vCarregaDadosTransportadora(nIdTransportadora,out strNome,out strEndereco,out strCEP,out strBairro,out strCidade,out nIdEstado,out strTelefone,out strFax,out strEmail,out strSite);
					strEstado = strRetornaSiglaEstadoBrasileiro(nIdEstado);

					// Contato
					int nIdContato;
					vCarregaDadosTransportadoraContatoSelecionado(out nIdContato);
					if (nIdContato != -1)
						vCarregaDadosTransportadoraContato(nIdTransportadora,nIdContato,out strContatoNome,out strContatoTelefone,out strContatoFax,out strContatoEmail);

					// Motorista
					int nIdMotorista;
					vCarregaDadosTransportadoraMotoristaSelecionado(out nIdMotorista);
					if (nIdMotorista != -1)
						vCarregaDadosTransportadoraMotorista(nIdTransportadora,nIdMotorista,out strMotoristaNome,out strMotoristaTelefone);

					// Veiculo
					int nIdVeiculo;
					vCarregaDadosTransportadoraVeiculoSelecionado(out nIdVeiculo);
					if (nIdVeiculo != -1)
						vCarregaDadosTransportadoraVeiculo(nIdTransportadora,nIdVeiculo,out strVeiculoDescricao,out strVeiculoIdentificacao);
				}
			}
		#endregion
	}
}
