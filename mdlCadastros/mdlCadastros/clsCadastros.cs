using System;

namespace mdlCadastros
{
	#region Enums
		internal enum Cadastro
		{
			Exportador = 0,
			Importadores = 1,
			Produtos = 2,
			Bancos = 3,
			Armadores = 4,
			AgentesCarga = 5,
			Transportadoras = 6,
			Terminais = 7,
			Despachantes = 8
		}
	#endregion

	/// <summary>
	/// Summary description for clsCadastros.
	/// </summary>
	public class clsCadastros
	{
		#region Constants
			private const int WIDTH = 201;
			private const int HEIGHT = 223;
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB = null;
			protected string m_strEnderecoExecutavel = "";
	        
			private bool m_bPrestadorServico = false;
			private int m_nIdExportador = -1;
			private string m_strIdPe = "";

			protected System.Windows.Forms.ImageList m_ilBandeiras;
			// Formularios
			protected System.Windows.Forms.Form m_formParent;
			protected Formularios.frmCadastros m_formFCadastros;
		#endregion
		#region Properties
			public System.Windows.Forms.ImageList Bandeiras
			{
				set
				{
					m_ilBandeiras = value;
				}
			}
		#endregion
		#region Constructors and Destructor
			public clsCadastros(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess cls_dba_ConnectionDB,string strEnderecoExecutavel,ref System.Windows.Forms.Form formParent,bool bPrestadorServico,int nIdExportador,string strIdPe)
			{
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_cls_dba_ConnectionDB = cls_dba_ConnectionDB;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_formParent = formParent;
				m_bPrestadorServico = bPrestadorServico;
				m_nIdExportador = nIdExportador;
				m_strIdPe = strIdPe;
			}
		#endregion

		#region Show
			public void Show()
			{
				m_formFCadastros = new mdlCadastros.Formularios.frmCadastros(m_strEnderecoExecutavel);
				m_formFCadastros.MdiParent = m_formParent;
				vInitializeEvents(ref m_formFCadastros);
				m_formFCadastros.Show();
				m_formFCadastros.BringToFront();
			}

			private void vInitializeEvents(ref Formularios.frmCadastros formFCadastros)
			{
				// Carrega Interface 
				formFCadastros.eCallCarregaInterface += new mdlCadastros.Formularios.frmCadastros.delCallCarregaInterface(formFCadastros_eCallCarregaInterface);

				// Carrega Botoes
				formFCadastros.eCallCarregaBotoes +=new mdlCadastros.Formularios.frmCadastros.delCallCarregaBotoes(formFCadastros_eCallCarregaBotoes);
			}

			private void formFCadastros_eCallCarregaInterface(out string strMainText)
			{
				if (m_bPrestadorServico)
					if (m_nIdExportador == -1)
						strMainText = "Cadastros Compartilhados entre Contas";
					else
						strMainText = "Cadastros desta Conta";
				else
					strMainText = "Cadastros";
			}

			public void Close()
			{
				if (m_formFCadastros != null)
					m_formFCadastros.Close();
			}

		#endregion

		#region Carrega Botoes
			private void formFCadastros_eCallCarregaBotoes(ref System.Windows.Forms.ToolTip ttDicas,out System.Collections.ArrayList arlBotoes)
			{
				if (m_bPrestadorServico)
					if (m_nIdExportador == -1)
						vCarregaBotoesPrestadorServicoPrestadorServico(ref ttDicas,out arlBotoes);
					else
						vCarregaBotoesPrestadorServicoExportador(ref ttDicas,out arlBotoes);
				else
					vCarregaBotoesExportador(ref ttDicas,out arlBotoes);
			}

			private void vCarregaBotoesPrestadorServicoPrestadorServico(ref System.Windows.Forms.ToolTip ttDicas,out System.Collections.ArrayList arlBotoes)
			{
				arlBotoes = new System.Collections.ArrayList();
				System.Windows.Forms.Button btCurrent;
				string strCurrent;

				// Agentes Carga
				btCurrent = btRetornaBotaoAgentesCarga(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,20);
				arlBotoes.Add(btCurrent);
				// Armadores
				btCurrent = btRetornaBotaoArmadores(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,20);
				arlBotoes.Add(btCurrent);
				// Transportadoras
				btCurrent = btRetornaBotaoTransportadoras(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(410,20);
				arlBotoes.Add(btCurrent);
				// Terminais
				btCurrent = btRetornaBotaoTerminais(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,243);
				arlBotoes.Add(btCurrent);
				// Despachantes
				btCurrent = btRetornaBotaoDespachantes(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,243);
				arlBotoes.Add(btCurrent);
			}

			private void vCarregaBotoesPrestadorServicoExportador(ref System.Windows.Forms.ToolTip ttDicas,out System.Collections.ArrayList arlBotoes)
			{
				arlBotoes = new System.Collections.ArrayList();
				System.Windows.Forms.Button btCurrent;
				string strCurrent;

				// Bancos
				btCurrent = btRetornaBotaoBancos(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,20);
				arlBotoes.Add(btCurrent);
				// Importador
				btCurrent = btRetornaBotaoImportador(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,20);
				arlBotoes.Add(btCurrent);
				// Produtos
				btCurrent = btRetornaBotaoProdutos(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(410,20);
				arlBotoes.Add(btCurrent);
			}

			private void vCarregaBotoesExportador(ref System.Windows.Forms.ToolTip ttDicas,out System.Collections.ArrayList arlBotoes)
			{
				arlBotoes = new System.Collections.ArrayList();
				System.Windows.Forms.Button btCurrent;
				string strCurrent;

				// Exportador
				btCurrent = btRetornaBotaoExportador(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,20);
				arlBotoes.Add(btCurrent);
				// Bancos
				btCurrent = btRetornaBotaoBancos(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,20);
				arlBotoes.Add(btCurrent);
				// Importador
				btCurrent = btRetornaBotaoImportador(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(410,20);
				arlBotoes.Add(btCurrent);
				// Produtos
				btCurrent = btRetornaBotaoProdutos(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,243);
				arlBotoes.Add(btCurrent);
				// Agentes Carga
				btCurrent = btRetornaBotaoAgentesCarga(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,243);
				arlBotoes.Add(btCurrent);
				// Armadores
				btCurrent = btRetornaBotaoArmadores(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(410,243);
				arlBotoes.Add(btCurrent);
				// Transportadoras
				btCurrent = btRetornaBotaoTransportadoras(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(10,466);
				arlBotoes.Add(btCurrent);
				// Terminais
				btCurrent = btRetornaBotaoTerminais(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(210,466);
				arlBotoes.Add(btCurrent);
				// Despachantes
				btCurrent = btRetornaBotaoDespachantes(out strCurrent);
				ttDicas.SetToolTip(btCurrent,strCurrent);
				btCurrent.Location = new System.Drawing.Point(410,466);
				arlBotoes.Add(btCurrent);
			}
		#endregion
		#region Cadastros
			#region Button
				private System.Windows.Forms.Button btButton()
				{
					System.Windows.Forms.Button btReturn = new System.Windows.Forms.Button();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
					return(btReturn);
				}
			#endregion

			#region Exportador
				private System.Windows.Forms.Button btRetornaBotaoExportador(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.ImageIndex = (int)Cadastro.Exportador;
					btReturn.Click += new EventHandler(vShowExportador);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Dados do exportador";
					return(btReturn);
				}
				private void vShowExportador(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					System.Windows.Forms.Form formParent = (System.Windows.Forms.Form)m_formFCadastros;
					mdlContas.clsContas cls_Exportador = new mdlContas.clsContas(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,ref formParent,m_nIdExportador);
					cls_Exportador.editaConta();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Importador
				private System.Windows.Forms.Button btRetornaBotaoImportador(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Importadores;
					btReturn.Click += new EventHandler(vShowImportador);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos importadores";
					return(btReturn);
				}
				private void vShowImportador(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlImportador.clsImportador cls_Importador = new mdlImportador.clsImportadorExportador(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,ref m_ilBandeiras);
					cls_Importador.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
 				}
			#endregion
			#region Produtos
				private System.Windows.Forms.Button btRetornaBotaoProdutos(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Produtos;
					btReturn.Click += new EventHandler(vShowProdutos);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos produtos";
					return(btReturn);
				}

				private void vShowProdutos(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlProdutosGeral.clsProdutos cls_Produtos = new mdlProdutosGeral.clsProdutos(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,1,ref m_ilBandeiras);
					if (m_strIdPe != "")
					{
						cls_Produtos.Codigo = m_strIdPe;
						cls_Produtos.DataSourceCodigo = mdlProdutosGeral.DataSource.FaturaComercial;
					}
					cls_Produtos.ShowDialogProdutos();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Bancos
				private System.Windows.Forms.Button btRetornaBotaoBancos(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Bancos;
					btReturn.Click += new EventHandler(vShowBancos);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos bancos do exportador";
					return(btReturn);
				}

				private void  vShowBancos(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlBancos.clsBancoExportador cls_Bancos = new mdlBancos.BancoExportador.clsBancoExportadorGeral(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
					cls_Bancos.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Armadores
				private System.Windows.Forms.Button btRetornaBotaoArmadores(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Armadores;
					btReturn.Click += new EventHandler(vShowArmadores);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos armadores";
					return(btReturn);
				}

				private void  vShowArmadores(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlArmadores.clsArmador cls_Armador = new mdlArmadores.clsArmador(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
					cls_Armador.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region AgentesCarga
				private System.Windows.Forms.Button btRetornaBotaoAgentesCarga(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.AgentesCarga;
					btReturn.Click += new EventHandler(vShowAgentesCarga);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos agentes de cargas";
					return(btReturn);
				}

				private void  vShowAgentesCarga(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlAgentes.clsAgenteCarga cls_AgenteCarga = new mdlAgentes.clsAgenteCarga(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
					cls_AgenteCarga.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Transportadoras
				private System.Windows.Forms.Button btRetornaBotaoTransportadoras(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Transportadoras;
					btReturn.Click += new EventHandler(vShowTransportadoras);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro das transportadoras";
					return(btReturn);
				}

				private void  vShowTransportadoras(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlTransportadoras.clsTransportadora cls_Transportadora = new mdlTransportadoras.clsTransportadora(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
					cls_Transportadora.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Terminais
				private System.Windows.Forms.Button btRetornaBotaoTerminais(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Terminais;
					btReturn.Click += new EventHandler(vShowTerminais);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro dos terminais";
					return(btReturn);
				}

				private void vShowTerminais(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlArmadores.clsTerminal cls_Terminal = new mdlArmadores.clsTerminal(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador,m_strIdPe);
					cls_Terminal.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
			#region Despachantes
				private System.Windows.Forms.Button btRetornaBotaoDespachantes(out string strToolTip)
				{
					System.Windows.Forms.Button btReturn = btButton();
					btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
					btReturn.ImageIndex = (int)Cadastro.Despachantes;
					btReturn.Click += new EventHandler(vShowDespachantes);
					btReturn.Size = new System.Drawing.Size(WIDTH,HEIGHT);
					strToolTip = "Cadastro das Comissárias de Despacho";
					return(btReturn);
				}

				private void vShowDespachantes(object sender, EventArgs e)
				{
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					mdlDespachante.clsDespachante cls_Despachante = new mdlDespachante.clsDespachante(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionDB,m_strEnderecoExecutavel,m_nIdExportador);
					cls_Despachante.ShowDialog();
					m_formFCadastros.Cursor = System.Windows.Forms.Cursors.Default;
				}
			#endregion
		#endregion
	}
}
