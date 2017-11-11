using System;

namespace mdlImportador
{
	/// <summary>
	/// Summary description for clsImportador.
	/// </summary>
	public abstract class clsImportador
	{
		#region Atributos
		// ***************************************************************************************************
		// Atributos 
		// ***************************************************************************************************
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionDB;
		protected string m_strEnderecoExecutavel;

		private bool m_bMostrarBaloes = true;

		protected mdlComponentesGraficos.MessageBalloon m_mgblBalaoToolTip = null;
		
		private frmFImportador m_formFImportador = null;
		private frmFImportadorCadEdit m_formFImportadorCadEdit = null;
		private mdlEnderecoEntrega.clsEnderecoEntregaImportador m_cls_end_EnderecoEntregaImportador = null;
		private mdlBancos.clsBancoImportador m_cls_bnc_BancoImportador = null;

		public bool m_bModificado = false;
		protected int m_nIdExportador = -1;
		protected int m_nIdImportador = -1;

		protected string m_strCaptionFrame = "Importadores";

		//public bool desativa = false;

		protected string m_strImportador = "";
		// Campos BD Tabela Importador
		protected string m_strEndereco = "";
		protected string m_strCidade = "";
		protected string m_strEstado = "";
		protected string m_strTelefone = "";
		protected string m_strFax = "";
		protected string m_strEMail = "";
		protected string m_strSite = "";
		protected string m_strObs = "";

		protected int m_nIdPais = -1;
		protected string m_strPais = "";
		
		// Bandeiras
		private System.Windows.Forms.ImageList m_ilBandeiras;

		protected mdlDataBaseAccess.Tabelas.XsdTbExportadores m_typDatSetTbExportadores;

		protected mdlDataBaseAccess.Tabelas.XsdTbImportadores m_typDatSetTbImportadores;
		protected mdlDataBaseAccess.Tabelas.XsdTbPaises m_typDatSetTbPaises;
		private mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega m_typDatSetTbImportadoresEndEntrega;
		//' ***************************************************************************************************
		#endregion
		
		#region Construtores e Destrutores
		public clsImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,int nIdImportador,ref System.Windows.Forms.ImageList bandeiras)
		{
			try
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_nIdImportador = nIdImportador;
				m_ilBandeiras = bandeiras;
				mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		public clsImportador(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel,int nIdExportador,ref System.Windows.Forms.ImageList bandeiras)
		{
			try
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_cls_dba_ConnectionDB = ConnectionDB;
				m_strEnderecoExecutavel = EnderecoExecutavel;
				m_nIdExportador = nIdExportador;
				m_ilBandeiras = bandeiras;
				mdlManipuladorArquivo.clsManipuladorArquivoIni obj = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
				m_bMostrarBaloes = obj.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, true);
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Inicializa as variáveis m_typDatSet*
		protected void inicializaTypDatSet()
		{
			// Cria os Arrays para pesquisa no Banco de Dados
			System.Collections.ArrayList arlCondicoesCampo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesComparador = new System.Collections.ArrayList();
			System.Collections.ArrayList arlCondicoesValor = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
			System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
			arlCondicoesCampo.Add("idExportador");
			arlCondicoesComparador.Add(mdlDataBaseAccess.Comparador.Igual);
			arlCondicoesValor.Add(m_nIdExportador);
			arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
			arlOrdenacaoValor.Add("nmCli");
			// Executa a pesquisa
			m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			m_typDatSetTbImportadores = m_cls_dba_ConnectionDB.GetTbImportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
				
			arlOrdenacaoValor.Clear();
			arlOrdenacaoValor.Add("idEndEntrega");
			// Executa a pesquisa
			m_typDatSetTbImportadoresEndEntrega = m_cls_dba_ConnectionDB.GetTbImportadoresEndEntrega(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,arlOrdenacaoValor,arlOrdenacaoTipo);

			// Executa a pesquisa
			m_typDatSetTbExportadores = m_cls_dba_ConnectionDB.GetTbExportadores(arlCondicoesCampo,arlCondicoesComparador,arlCondicoesValor,null,null);
		}
		#endregion
		#region InitializeEventsFormImportador
		private void InitializeEventsFormImportador()
		{
			try 
			{
				// Carrega Dados BD
				m_formFImportador.eCallCarregaDadosBD += new frmFImportador.delCallCarregaDadosBD(carregaDadosBD);
			
				// Carrega Dados Interface
				m_formFImportador.eCallCarregaDadosInterface += new frmFImportador.delCallCarregaDadosInterface(carregaDadosInterface);

				// Carrega Dados Importadores Interface
				m_formFImportador.eCallCarregaDadosImportadorInterface += new frmFImportador.delCallCarregaDadosImportadorInterface(carregaDadosImportadorInterface);

				// Carrega Dados BD Importadores
				m_formFImportador.eCallCarregaDadosBDImportadores += new frmFImportador.delCallCarregaDadosBDImportadores(carregaDadosBDImportadores);

				// Salva Dados BD
				m_formFImportador.eCallSalvaDadosBD += new frmFImportador.delCallSalvaDadosBD(salvaDadosBD);

				// Editar Importador
				m_formFImportador.eCallEditaImportador += new frmFImportador.delCallEditaImportador(editaImportador);

				// Cadastra Importador
				m_formFImportador.eCallCadastraImportador += new frmFImportador.delCallCadastraImportador(cadastraImportador);

				// Remove Importador
				m_formFImportador.eCallRemoveImportador += new frmFImportador.delCallRemoveImportador(removeImportador);

				// Mostra Endereço Entrega Importador
				m_formFImportador.eCallMostraEnderecoEntrega += new frmFImportador.delCallMostraEnderecoEntrega(mostraEnderecoEntrega);

				// Mostra Banco Importador
				m_formFImportador.eCallMostraBancoImportador += new frmFImportador.delCallMostraBancoImportador(mostraBanco);
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region InitializeEventsFormImportadorCadEdit
		private void InitializeEventsFormImportadorCadEdit()
		{
			// Carrega Dados BD CadEdit
			m_formFImportadorCadEdit.eCallCarregaDadosBD += new frmFImportadorCadEdit.delCallCarregaDadosBD(carregaDadosBDCadEdit);

			// Carrega Dados Interface
			m_formFImportadorCadEdit.eCallCarregaDadosInterface += new frmFImportadorCadEdit.delCallCarregaDadosInterface(carregaDadosInterfaceCadEdit);

			//Carrega Dados Interface Paises
			m_formFImportadorCadEdit.eCallCarregaDadosInterfacePaises += new frmFImportadorCadEdit.delCallCarregaDadosInterfacePaises(carregaDadosInterfacePaises);

			// Salva Dados Interface
			m_formFImportadorCadEdit.eCallSalvaDadosInterface += new frmFImportadorCadEdit.delCallSalvaDadosInterface(salvaDadosInterfaceImportador);

			// Salva Dados BD
			m_formFImportadorCadEdit.eCallSalvaDadosBD += new frmFImportadorCadEdit.delCallSalvaDadosBD(salvaDadosBDImportador);
		}
		#endregion

		#region ShowDialog
		/// <summary>
		/// Método para mostrar o frame para listagem de Importadores
		/// </summary>
		public void ShowDialog()
		{
			try
			{
				m_formFImportador = new frmFImportador(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel, ref m_ilBandeiras);
				InitializeEventsFormImportador();
				m_formFImportador.setaCaptionFrame(m_strCaptionFrame);
				m_formFImportador.ShowDialog();
				m_bModificado = m_formFImportador.m_bModificado;
				m_formFImportador.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region ShowDialog Importador CadEdit
		/// <summary>
		/// Método para cadastro e edição de Importadores
		/// </summary>
		public void ShowDialogImportadorCadEdit()
		{
			try
			{
				m_formFImportadorCadEdit = new frmFImportadorCadEdit(ref m_cls_ter_tratadorErro,m_strEnderecoExecutavel);
				InitializeEventsFormImportadorCadEdit();
				m_formFImportadorCadEdit.ShowDialog();
				m_bModificado = m_formFImportadorCadEdit.m_bModificado;
				m_formFImportadorCadEdit.Dispose();
			}
			catch (Exception erro)
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Editar Importador
		protected void editaImportador()
		{
			try
			{
				m_formFImportadorCadEdit = new frmFImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_ilBandeiras, ref m_formFImportador);
				InitializeEventsFormImportadorCadEdit();
				m_formFImportadorCadEdit.setTextoGroupBox("Edição");
				m_formFImportadorCadEdit.ShowDialog();
				m_formFImportadorCadEdit.Dispose();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cadastrar Importador
		protected void cadastraImportador()
		{
			try
			{
				m_formFImportadorCadEdit = new frmFImportadorCadEdit(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, ref m_ilBandeiras, ref m_formFImportador, true);
				InitializeEventsFormImportadorCadEdit();
				m_formFImportadorCadEdit.setTextoGroupBox("Cadastro");
				m_formFImportadorCadEdit.ShowDialog();
				m_formFImportadorCadEdit = null;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Remove Importador
		protected void removeImportador(ref mdlComponentesGraficos.ListView lvImportadores)
		{
			mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
			mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowTbImportadoresEndEntrega;
			int nIdImportador = -1;
			int nIdEndEntrega = 0;
			if (lvImportadores.SelectedItems.Count > 0)
			{
				System.Windows.Forms.DialogResult drApaga = mdlMensagens.clsMensagens.ShowQuestion("Importadores",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlImportador_clsImportador_ApagarImportador).Replace("TAG",lvImportadores.SelectedItems.Count.ToString()),System.Windows.Forms.MessageBoxButtons.YesNo);
				//System.Windows.Forms.DialogResult drApaga = System.Windows.Forms.MessageBox.Show("Você tem certeza que deseja excluir " + lvImportadores.SelectedItems.Count.ToString() + " importadore(s)?","Importadores",System.Windows.Forms.MessageBoxButtons.YesNo);
				while (lvImportadores.SelectedItems.Count > 0 && drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdImportador = Int32.Parse(lvImportadores.SelectedItems[0].Tag.ToString());
					dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,nIdImportador);
					dtrwRowTbImportadores.Delete();
					dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,nIdImportador,nIdEndEntrega);
					while (dtrwRowTbImportadoresEndEntrega != null) 
					{
						m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.RemovetbImportadoresEndEntregaRow(dtrwRowTbImportadoresEndEntrega);
						nIdEndEntrega++;
						dtrwRowTbImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,nIdImportador,nIdEndEntrega);
					}
					lvImportadores.SelectedItems[0].Selected = false;
				}
				if (drApaga == System.Windows.Forms.DialogResult.Yes)
				{
					nIdImportador = -1;
					m_strImportador = "";
					m_strEndereco = "";
					m_strCidade = "";
					m_strEstado = "";
					m_nIdPais = -1;
					m_strTelefone = "";
					m_strFax = "";
					m_strEMail = "";
					m_strSite = "";
					m_strObs = "";
				}
			}
		}
		#endregion

		#region Mostrar Endereços de Entrega do Importador
		protected void mostraEnderecoEntrega()
		{
			try
			{
				m_cls_end_EnderecoEntregaImportador = new mdlEnderecoEntrega.clsEnderecoEntregaImportadorGeral(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_nIdImportador);
				m_cls_end_EnderecoEntregaImportador.ShowDialog();
				m_formFImportador.mostraCor();
				m_cls_end_EnderecoEntregaImportador = null;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Mostrar Bancos do Importador
		protected void mostraBanco()
		{
			try
			{
				m_cls_bnc_BancoImportador = new mdlBancos.BancoImportador.clsBancoImportadorGeral(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionDB, m_strEnderecoExecutavel, m_nIdExportador, m_nIdImportador);
				m_cls_bnc_BancoImportador.ShowDialog();
				m_formFImportador.mostraCor();
				m_cls_bnc_BancoImportador = null;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Carregamento de Dados Importador
			#region Banco de Dados
			protected void carregaDadosBDCadEdit()
			{
				#region Pesquisa
				if (m_typDatSetTbPaises == null)
					carregaDadosBDPaises();
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
				mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwTbPaises;
				dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
				if (dtrwRowTbImportadores != null)
				{
					if (!dtrwRowTbImportadores.IsnmCliNull())
                        m_strImportador = dtrwRowTbImportadores.nmCli;
					if (!dtrwRowTbImportadores.IsidPaisCliNull())
                        m_nIdPais = dtrwRowTbImportadores.idPaisCli;
					#endregion

					#region Salvando os items nos atributos de classe
					if (dtrwRowTbImportadores != null)
					{
						if (!dtrwRowTbImportadores.IsnmCliNull())
						{
							m_strImportador = dtrwRowTbImportadores.nmCli;
						}
						if (!dtrwRowTbImportadores.IsmstrEndCliNull())
						{
							m_strEndereco = dtrwRowTbImportadores.mstrEndCli;
						}
						if (!dtrwRowTbImportadores.IscidadeCliNull())
						{
							m_strCidade = dtrwRowTbImportadores.cidadeCli;
						}
						if (!dtrwRowTbImportadores.IsestadoCliNull())
						{
							m_strEstado = dtrwRowTbImportadores.estadoCli;
						}					
						if (!dtrwRowTbImportadores.IsmstrTelCliNull())
						{
							m_strTelefone = dtrwRowTbImportadores.mstrTelCli;
						}
						if (!dtrwRowTbImportadores.IsmstrFaxCliNull())
						{
							m_strFax = dtrwRowTbImportadores.mstrFaxCli;
						}
						if (!dtrwRowTbImportadores.IsmstrEmailCliNull())
						{
							m_strEMail = dtrwRowTbImportadores.mstrEmailCli;
						}
						if (!dtrwRowTbImportadores.IsmstrSiteCliNull())
						{
							m_strSite = dtrwRowTbImportadores.mstrSiteCli;
						}
						if (!dtrwRowTbImportadores.IsmstrObsCliNull())
						{
							m_strObs = dtrwRowTbImportadores.mstrObsCli;
						}
						dtrwTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
						if ((dtrwTbPaises != null) && (!dtrwTbPaises.IsnmPaisNull()))
							m_strPais = dtrwTbPaises.nmPais;
					}
					#endregion
				}
			}
			#endregion
			#region Interface
			protected void carregaDadosInterfaceCadEdit(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref mdlComponentesGraficos.TextBox ctbTelefone,ref mdlComponentesGraficos.TextBox ctbFax,ref mdlComponentesGraficos.TextBox ctbEMail,ref mdlComponentesGraficos.TextBox ctbSite,ref System.Windows.Forms.TextBox ctbObs)
			{
				try
				{
					#region Pesquisa
					System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
					System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
					arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
					arlOrdenacaoValor.Clear();
					arlOrdenacaoValor.Add("nmPais");

					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
					m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
					m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
							
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
					System.Collections.SortedList srlPaises = new System.Collections.SortedList();
					foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
					{
						srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
					}
					#endregion

					#region Adicionando Items ao Formulário
					ctbNome.Text = m_strImportador;
					ctbEndereco.Text = m_strEndereco;
					ctbCidade.Text = m_strCidade;
					ctbEstado.Text = m_strEstado;
					if (srlPaises != null)
					{
						for (int nCont = 0 ; nCont < srlPaises.Count ; nCont++)
						{
							dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCont);
							cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
							if (dtrwRowTbPaises.idPais == m_nIdPais)
							{
								cbPaises.SelectedIndex = nCont;
								m_strPais = dtrwRowTbPaises.nmPais;
							}
						}
					}
					ctbTelefone.Text = m_strTelefone;
					ctbFax.Text = m_strFax;
					ctbEMail.Text = m_strEMail;
					ctbSite.Text = m_strSite;
					ctbObs.Text = m_strObs;
					#endregion
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected void carregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises)
			{                
				#region Adiciona a ComboBox
				System.Collections.SortedList srlPaises = new System.Collections.SortedList();
				mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;
				foreach(mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaisesSorted in m_typDatSetTbPaises.tbPaises.Rows)
				{
					srlPaises.Add(dtrwRowTbPaisesSorted.nmPais, dtrwRowTbPaisesSorted);
				}

				if (srlPaises != null)
				{
					for (int nCont = 0 ; nCont < srlPaises.Count ; nCont++)
					{
						dtrwRowTbPaises = (mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow)srlPaises.GetByIndex(nCont);
						cbPaises.AddItem(dtrwRowTbPaises.nmPais, dtrwRowTbPaises.idPais);
					}
				}
				#endregion
			}
			#endregion
		#endregion
		#region Salvamento de Dados Importador
			#region Interface
			protected void salvaDadosInterfaceImportador(ref mdlComponentesGraficos.TextBox ctbNome,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.TextBox ctbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref mdlComponentesGraficos.TextBox ctbTelefone,ref mdlComponentesGraficos.TextBox ctbFax,ref mdlComponentesGraficos.TextBox ctbEMail,ref mdlComponentesGraficos.TextBox ctbSite,ref System.Windows.Forms.TextBox ctbObs)
			{
				try
				{
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowPaises;

					m_strImportador = ctbNome.Text;
					m_strEndereco = ctbEndereco.Text;
					m_strCidade = ctbCidade.Text;
					m_strEstado = ctbEstado.Text;

					m_nIdPais = Int32.Parse(cbPaises.ReturnObjectSelectedItem().ToString());
					dtrwRowPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					m_strPais = dtrwRowPaises.nmPais;

					m_strTelefone = ctbTelefone.Text;
					m_strFax = ctbFax.Text;
					m_strEMail = ctbEMail.Text;
					m_strSite = ctbSite.Text;
					m_strObs = ctbObs.Text;
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
			#region Banco de Dados
			protected void salvaDadosBDImportador(bool cadastraNovo)
			{
				try
				{
					#region Pesquisa ou Criação do Registro
					int nIdImportador = 1;
					bool bNaoPossuiEndCadastrado = false;
					// Cria a variável para conter o registro corrente
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
					mdlDataBaseAccess.Tabelas.XsdTbImportadoresEndEntrega.tbImportadoresEndEntregaRow dtrwRowImportadoresEndEntrega;
					if (cadastraNovo == false) 
					{
						// Executa a pesquisa
						dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
						nIdImportador = m_nIdImportador;
						// Importadores TbImportadoresEndEntrega
						dtrwRowImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.FindByidExportadoridImportadoridEndEntrega(m_nIdExportador,m_nIdImportador,0);
						if (dtrwRowImportadoresEndEntrega == null)
						{
							bNaoPossuiEndCadastrado = true;
							dtrwRowImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.NewtbImportadoresEndEntregaRow();
						}
					} 
					else
					{
						while (m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,nIdImportador) != null)
							nIdImportador++;

						dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.NewtbImportadoresRow();
						dtrwRowTbImportadores.idExportador = m_nIdExportador;

						dtrwRowImportadoresEndEntrega = m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.NewtbImportadoresEndEntregaRow();
					}
					#endregion

					#region Salvando os Dados TbImportadores
					dtrwRowTbImportadores.idImportador = nIdImportador;
					dtrwRowTbImportadores.nmCli = m_strImportador;
					dtrwRowTbImportadores.mstrEndCli = m_strEndereco;
					dtrwRowTbImportadores.cidadeCli = m_strCidade;
					dtrwRowTbImportadores.estadoCli = m_strEstado;
					dtrwRowTbImportadores.idPaisCli = m_nIdPais;
					dtrwRowTbImportadores.mstrTelCli = m_strTelefone;
					dtrwRowTbImportadores.mstrFaxCli = m_strFax;
					dtrwRowTbImportadores.mstrEmailCli = m_strEMail;
					dtrwRowTbImportadores.mstrSiteCli = m_strSite;
					dtrwRowTbImportadores.mstrObsCli = m_strObs;
					#endregion
					#region Salvando os Dados TbImportadoresEndEntrega
					dtrwRowImportadoresEndEntrega.idEndEntrega = 0;
					dtrwRowImportadoresEndEntrega.idExportador = m_nIdExportador;
					dtrwRowImportadoresEndEntrega.idImportador = nIdImportador;
					dtrwRowImportadoresEndEntrega.mstrEndEntrCli = m_strEndereco;
					dtrwRowImportadoresEndEntrega.mstrCidadeEntrCli = m_strCidade;
					dtrwRowImportadoresEndEntrega.idPaisEntrCli = m_nIdPais;
					dtrwRowImportadoresEndEntrega.mstrEstadoEntrCli = m_strEstado;
					#endregion

					m_nIdImportador = nIdImportador;
					if (cadastraNovo == true)
					{
						m_typDatSetTbImportadores.tbImportadores.AddtbImportadoresRow(dtrwRowTbImportadores);
						m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.AddtbImportadoresEndEntregaRow(dtrwRowImportadoresEndEntrega);
					} 
					else if (bNaoPossuiEndCadastrado == true)
					{
						m_typDatSetTbImportadoresEndEntrega.tbImportadoresEndEntrega.AddtbImportadoresEndEntregaRow(dtrwRowImportadoresEndEntrega);
					}
					m_cls_dba_ConnectionDB.SetTbImportadores(m_typDatSetTbImportadores);
					m_cls_dba_ConnectionDB.SetTbImportadoresEndEntrega(m_typDatSetTbImportadoresEndEntrega);
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			#endregion
		#endregion

		#region Carregamento de Dados
			#region Ordenando
			private System.Collections.SortedList retornaImportadoresOrdenados()
			{
				System.Collections.SortedList srlImportadores = new System.Collections.SortedList();
				try
				{
					foreach(mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores in m_typDatSetTbImportadores.tbImportadores.Rows)
					{
						if (dtrwRowTbImportadores.RowState != System.Data.DataRowState.Deleted)
						{
							if (!srlImportadores.ContainsKey(dtrwRowTbImportadores.nmCli + dtrwRowTbImportadores.idImportador.ToString()))
								srlImportadores.Add(dtrwRowTbImportadores.nmCli + dtrwRowTbImportadores.idImportador.ToString(), dtrwRowTbImportadores);
						}
					}
				}
				catch (Exception err)
				{
					m_cls_ter_tratadorErro.trataErro(ref err);
				}
				return srlImportadores;
			}
		#endregion
			#region Banco de Dados
			protected void carregaDadosBD()
			{
				carregaDadosBDPaises();
				carregaDadosBDEspecificos();
			}
			protected void carregaDadosBDImportadores(ref mdlComponentesGraficos.ListView lvImportadores)
			{
				#region Pesquisa
				if (lvImportadores.SelectedItems.Count > 0)
					m_nIdImportador = Int32.Parse(lvImportadores.SelectedItems[0].Tag.ToString());
				// Cria a variável para conter o registro corrente
				mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores = null;
				if (m_nIdExportador != -1 && m_nIdImportador != -1)
                    dtrwRowTbImportadores = m_typDatSetTbImportadores.tbImportadores.FindByidExportadoridImportador(m_nIdExportador,m_nIdImportador);
				if (dtrwRowTbImportadores != null )
				{
					if (!dtrwRowTbImportadores.IsnmCliNull())
                        m_strImportador = dtrwRowTbImportadores.nmCli;

					if (!dtrwRowTbImportadores.IsidPaisCliNull())
                        m_nIdPais = dtrwRowTbImportadores.idPaisCli;
							
					mdlDataBaseAccess.Tabelas.XsdTbPaises.tbPaisesRow dtrwRowTbPaises;

					dtrwRowTbPaises = m_typDatSetTbPaises.tbPaises.FindByidPais(m_nIdPais);
					if (dtrwRowTbPaises != null)
						m_strPais = dtrwRowTbPaises.nmPais;
				#endregion

				#region Salvando os items nos atributos de classe
					if (!dtrwRowTbImportadores.IsnmCliNull())
					{
						m_strImportador = dtrwRowTbImportadores.nmCli;
					}
					if (!dtrwRowTbImportadores.IsmstrEndCliNull())
					{
						m_strEndereco = dtrwRowTbImportadores.mstrEndCli;
					}
					if (!dtrwRowTbImportadores.IscidadeCliNull())
					{
						m_strCidade = dtrwRowTbImportadores.cidadeCli;
					}
					if (!dtrwRowTbImportadores.IsestadoCliNull())
					{
						m_strEstado = dtrwRowTbImportadores.estadoCli;
					}					
					if (!dtrwRowTbImportadores.IsmstrTelCliNull())
					{
						m_strTelefone = dtrwRowTbImportadores.mstrTelCli;
					}
					if (!dtrwRowTbImportadores.IsmstrFaxCliNull())
					{
						m_strFax = dtrwRowTbImportadores.mstrFaxCli;
					}
					if (!dtrwRowTbImportadores.IsmstrEmailCliNull())
					{
						m_strEMail = dtrwRowTbImportadores.mstrEmailCli;
					}
					if (!dtrwRowTbImportadores.IsmstrSiteCliNull())
					{
						m_strSite = dtrwRowTbImportadores.mstrSiteCli;
					}
					if (!dtrwRowTbImportadores.IsmstrObsCliNull())
					{
						m_strObs = dtrwRowTbImportadores.mstrObsCli;
					}
				}
				else
				{
					m_strImportador = "";
					m_strEndereco = "";
					m_strCidade = "";
					m_strEstado = "";
					m_strTelefone = "";
					m_strFax = "";
					m_strEMail = "";
					m_strSite = "";
					m_strObs = "";
					m_nIdPais = -1;
					m_strPais = "";
				}
				#endregion
			}
			protected void carregaDadosBDPaises()
			{
				System.Collections.ArrayList arlOrdenacaoTipo = new System.Collections.ArrayList();
				System.Collections.ArrayList arlOrdenacaoValor = new System.Collections.ArrayList();
				arlOrdenacaoTipo.Add(mdlDataBaseAccess.TipoOrdenacao.Crescente);
				arlOrdenacaoValor.Add("nmPais");

				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.Resource;
				m_typDatSetTbPaises = m_cls_dba_ConnectionDB.GetTbPaises(null,null,null,/*arlOrdenacaoValor,arlOrdenacaoTipo*/null,null);
				m_cls_dba_ConnectionDB.FonteDosDados = mdlDataBaseAccess.FonteDados.DataBase;
			}
			protected abstract void carregaDadosBDEspecificos();
			#endregion
			#region Interface
			protected void carregaDadosInterface(ref mdlComponentesGraficos.ListView lvImportadores, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo)
			{
				try 
				{
					System.Collections.SortedList srlImportadores = retornaImportadoresOrdenados();
					// List View Item
					System.Windows.Forms.ListViewItem lvItemImportador;
					// Limpa os Items da List View
					lvImportadores.Items.Clear();
					mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow dtrwRowTbImportadores;
					// Preenche os itens da List View
					for (int nCont = 0 ; nCont < srlImportadores.Count ; nCont++)
					{
						dtrwRowTbImportadores = (mdlDataBaseAccess.Tabelas.XsdTbImportadores.tbImportadoresRow)srlImportadores.GetByIndex(nCont);
						if ((dtrwRowTbImportadores.RowState != System.Data.DataRowState.Deleted) && (!dtrwRowTbImportadores.IsnmCliNull()))
						{
							lvItemImportador = lvImportadores.Items.Add(dtrwRowTbImportadores.nmCli);
							lvItemImportador.Tag = dtrwRowTbImportadores.idImportador;
							if ((int)lvItemImportador.Tag == m_nIdImportador)
							{
								lvItemImportador.Selected = true;
							}
						}
					}
					if (lvImportadores.Items.Count == 0)
					{
						btEditar.Enabled = false;
						btExcluir.Enabled = false;
						if (m_bMostrarBaloes)
						{
							m_mgblBalaoToolTip = new mdlComponentesGraficos.MessageBalloon();
							m_mgblBalaoToolTip.Caption = mdlConstantes.clsConstantes.BALLONTIP_DEFAULT_CAPTION;
							m_mgblBalaoToolTip.Content = mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.BALLOONTIP_mdlImportador_clsImportador_NovoImportador.ToString());
							m_mgblBalaoToolTip.Icon = System.Drawing.SystemIcons.Information;
							m_mgblBalaoToolTip.CloseOnMouseClick = true;
							m_mgblBalaoToolTip.CloseOnDeactivate = true;
							m_mgblBalaoToolTip.CloseOnKeyPress = true;
							m_mgblBalaoToolTip.ShowBalloon((System.Windows.Forms.Control)btNovo);
							//m_mgblBalaoToolTip.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
							//m_mgblBalaoToolTip.SetBounds((int)(btNovo.Bounds.Height / 2), (int)(btNovo.Bounds.Width / 2), m_mgblBalaoToolTip.Bounds.Width, m_mgblBalaoToolTip.Bounds.Height);
						}
					} 
					else
					{
						btEditar.Enabled = true;
						btExcluir.Enabled = true;
						if (lvImportadores.SelectedItems.Count == 0)
						{
							lvItemImportador = lvImportadores.Items[0];
							lvItemImportador.Selected = true;
							m_nIdImportador = (int)lvItemImportador.Tag;
						}
					}
				} 
				catch (Exception err) 
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
			}
			protected abstract void carregaDadosInterfaceEspecifico();
			protected void carregaDadosImportadorInterface(ref mdlComponentesGraficos.ListView lvDadosImportador)
			{
				try
				{
					// List View Item
					System.Windows.Forms.ListViewItem lvItemDadosImportador;
					// Limpa os Items da List View
					lvDadosImportador.Items.Clear();
					string ObsSemNovaLinha = m_strObs.Replace(System.Environment.NewLine," ");

					#region Adicionando Items à ListView
					lvDadosImportador.Items.Clear();
					#region Importador
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Importador: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador  = lvDadosImportador.Items.Add(m_strImportador);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion				
					#region Endereço
//					lvItemDadosImportador = lvDadosImportador.Items.Add("End.: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strEndereco);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Cidade
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Cidade: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strCidade);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Estado
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Estado: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strEstado);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Pais
//					lvItemDadosImportador = lvDadosImportador.Items.Add("País: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strPais);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Telefone
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Tel.: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strTelefone);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Fax
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Fax: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strFax);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region E-mail
//					lvItemDadosImportador = lvDadosImportador.Items.Add("E-mail: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strEMail);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Site
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Site: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(m_strSite);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#region Obs
//					lvItemDadosImportador = lvDadosImportador.Items.Add("Obs.: ");
//					lvItemDadosImportador.ForeColor = System.Drawing.Color.Red;
//					lvItemDadosImportador.UseItemStyleForSubItems = false;
//					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = lvDadosImportador.Items.Add(ObsSemNovaLinha);
					lvItemDadosImportador.Font = new System.Drawing.Font(lvItemDadosImportador.Font, System.Drawing.FontStyle.Regular);
					lvItemDadosImportador = null;
					#endregion
					#endregion
				} 
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}				
			}
			#endregion
		#endregion
		#region Salvamento de Dados
			#region Banco de Dados
			protected void salvaDadosBD(bool bModificado)
			{
				m_bModificado = bModificado;
				salvaDadosBDEspecifico();
				if (m_typDatSetTbImportadores != null)
				{
					m_cls_dba_ConnectionDB.SetTbImportadores(m_typDatSetTbImportadores);
				}
				if (m_typDatSetTbImportadoresEndEntrega != null)
				{
					m_cls_dba_ConnectionDB.SetTbImportadoresEndEntrega(m_typDatSetTbImportadoresEndEntrega);
				}
			}
			protected abstract void salvaDadosBDEspecifico();
			#endregion
		#endregion

		#region Retorno de Valores
		public void retornaValores(out int nIdImportador, out string strImportador, out string strEndereco, out string strCidade, out string strEstado, out string strPais, out string strTelefone, out string strFax, out string strEMail, out string strSite, out string strObs)
		{
			nIdImportador = m_nIdImportador;
			strImportador = m_strImportador;

			strEndereco = m_strEndereco;
			strCidade = m_strCidade;
			strEstado = m_strEstado;
			strPais = m_strPais;
			strTelefone = m_strTelefone;
			strFax = m_strFax;
			strEMail = m_strEMail;
			strSite = m_strSite;
			strObs = m_strObs;
		}
		#endregion
	}
}
