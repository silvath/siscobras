using System;

namespace mdlPreferencias
{
	public enum FREQUENCIABACKUP { NUNCA = 0, DIARIAMENTE, SEMANALMENTE, MENSALMENTE };
	/// <summary>
	/// Summary description for clsPreferencias.
	/// </summary>
	public class clsPreferencias
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_ConnectionBD = null;
		private string m_strEnderecoExecutavel = "";
		private string m_strLinkImagemInternet = "";

		private bool m_bNeedShowUpdates = false;

		private mdlControladoraWindowsServices.clsManagerWSSiscoMensagem m_cls_mws_SiscoMensagem = null;

		private string m_strUltimaOpcaoPreferencias = "Global";

		private bool m_bCoresModificadas = false;
		public bool m_bModificado = false;

		private mdlManipuladorArquivo.clsManipuladorArquivoIni m_clsArquivoSiscoIni = null;

		private int m_nIdUsuario = -1;
		#region Entrada
		private bool m_bIniciarPE = false;
		private bool m_bIniciarPEInfoOuFatura = false;
		private bool m_bIniciarCotacoesOuPEs = false;
		#endregion
		#region Backup
		private string m_strEnderecoBackup = "";
		private FREQUENCIABACKUP m_enumFrequencia = FREQUENCIABACKUP.DIARIAMENTE;
		private int m_nQtdeBackups = 5;
		private bool m_bPerguntarBackup = false;

		protected string[] m_strarrFiles = null;
		#endregion
		#region Cores
		private System.Drawing.Color m_clPrimaria = System.Drawing.Color.White;
		private System.Drawing.Color m_clSecundaria = System.Drawing.Color.White;
		#endregion
		// Relatorios
		public bool m_bRelatorioFaturaComercialRecarregar = false;
		public bool m_bRelatorioRomaneioRecarregar = false;

		private int m_nFaturaComercialPrecisaoPesoLiquidoTotal;
		private int m_nFaturaComercialPrecisaoPesoBrutoTotal;
		private bool m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar = true;
		private bool m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar = true;
		private bool m_bCanEditProducts = true;

		private int m_nRomaneioPrecisaoPesoLiquidoItens;
		private int m_nRomaneioPrecisaoPesoLiquidoTotal;
		private int m_nRomaneioPrecisaoPesoBrutoItens;
		private int m_nRomaneioPrecisaoPesoBrutoTotal;
		private bool m_bRomaneioPrecisaoPesoLiquidoItensArredondar = true;
		private bool m_bRomaneioPrecisaoPesoLiquidoTotalArredondar = true;
		private bool m_bRomaneioPrecisaoPesoBrutoItensArredondar = true;
		private bool m_bRomaneioPrecisaoPesoBrutoTotalArredondar = true;
		#region Global
		private bool m_bMostrarBaloes = true;
		private bool m_bMostrarAssistentes = true;
		#endregion

		private frmFPreferencias m_formFPreferencias = null;
		#endregion
		#region Properties
			public bool CoresModificadas
			{
				set
				{
					m_bCoresModificadas = value;
				}
				get
				{
					return(m_bCoresModificadas);
				}
			}
		#endregion
		#region Construtors and Destrutors
		public clsPreferencias(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, ref mdlDataBaseAccess.clsDataBaseAccess ConnectionDB,string EnderecoExecutavel)
		{
			m_cls_ter_tratadorErro = tratadorErro;
			m_cls_dba_ConnectionBD = ConnectionDB;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_nIdUsuario = mdlUsuarios.clsUsuario.New(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel).IdUsuario;
			m_clsArquivoSiscoIni = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "sisco.ini");
			carregaDadosBD();

			// Manager Windows Service SiscoMensagem
			m_cls_mws_SiscoMensagem = new mdlControladoraWindowsServices.clsManagerWSSiscoMensagem(m_strEnderecoExecutavel);
		}
		#endregion

		#region ShowDialog
			public void ShowDialog()
			{
				m_formFPreferencias = new frmFPreferencias(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel, m_strUltimaOpcaoPreferencias);
				vInitializeEvents(ref m_formFPreferencias);
				m_formFPreferencias.ShowDialog();
			}

			private void vInitializeEvents(ref frmFPreferencias formFPreferencias)
			{
				formFPreferencias.eCallNeedShowPreferences += new mdlPreferencias.frmFPreferencias.delCallNeedShowPreferences(formFPreferencias_eCallNeedShowPreferences);

				formFPreferencias.eCallInitialiazeEventsControlEntrada += new frmFPreferencias.delCallInitialiazeEventsControlEntrada(InitializeEventsFormEntrada);

				formFPreferencias.eCallInitialiazeEventsControlBackup += new frmFPreferencias.delCallInitialiazeEventsControlBackup(InitializeEventsFormBackup);

				formFPreferencias.eCallInitialiazeEventsControlCores += new frmFPreferencias.delCallInitialiazeEventsControlCores(InitializeEventsFormCores);

				formFPreferencias.eCallInitialiazeEventsControlRelatorios += new mdlPreferencias.frmFPreferencias.delCallInitialiazeEventsControlRelatorios(vInitializeEvents);

				formFPreferencias.eCallInitialiazeEventsControlGlobal += new frmFPreferencias.delCallInitialiazeEventsControlGlobal(InitializeEventsFormGlobal);

				formFPreferencias.eCallInitialiazeEventsControlMensagens += new mdlPreferencias.frmFPreferencias.delCallInitialiazeEventsControlMensagens(vInitializeEvents);

				formFPreferencias.eCallInitialiazeEventsControlAtualizacoes += new mdlPreferencias.frmFPreferencias.delCallInitialiazeEventsControlAtualizacoes(vInitializeEvents);

				formFPreferencias.eCallConfiguraBancoDados += new frmFPreferencias.delCallConfiguraBancoDados(configuraBancoDados);

				formFPreferencias.eCallSalvaDadosBD += new frmFPreferencias.delCallSalvaDadosBD(salvaDadosBD);

				formFPreferencias.eCallShowDialogEnviaErros += new mdlPreferencias.frmFPreferencias.delCallShowDialogEnviaErros(ShowDialogEnviaErros);

				formFPreferencias.eCallCarregaVersoes += new mdlPreferencias.frmFPreferencias.delCallCarregaVersoes(vCarregaVersoes);
			}
		#endregion
		#region ShowDialogNeeded
			public void ShowDialogNeeded()
			{
				m_bNeedShowUpdates = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.FIELDNEEDSHOWPREFERENCES,false);
				if (m_bNeedShowUpdates)
				{
					ShowDialog();
					m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.FIELDNEEDSHOWPREFERENCES,false.ToString());
					m_bNeedShowUpdates = false;
				}
			}

			private bool formFPreferencias_eCallNeedShowPreferences()
			{
				return(m_bNeedShowUpdates);
			}
		#endregion

		#region InitializeEventsFormEntrada
		private void InitializeEventsFormEntrada(ref Entrada.usrCtrlEntrada UserCtrlEntrada)
		{
			// Carrega Dados
			UserCtrlEntrada.eCallCarregaDados +=new mdlPreferencias.Entrada.usrCtrlEntrada.delCallCarregaDados(vCarregaDadosEntrada);

			// Prestador de Servico
			UserCtrlEntrada.eCallPrestadorServico += new mdlPreferencias.Entrada.usrCtrlEntrada.delCallPrestadorServico(bPrestadorServico);
			
			// Salva Dados
			UserCtrlEntrada.eCallSalvaDados += new mdlPreferencias.Entrada.usrCtrlEntrada.delCallSalvaDados(bSalvaDadosEntrada);
			
		}
		#endregion
		#region InitializeEventsFormBackup
		private void InitializeEventsFormBackup(ref Backup.usrCtrlBackup UserCtrlBackup)
		{
			UserCtrlBackup.eCallCarregaDadosInterface += new Backup.usrCtrlBackup.delCallCarregaDadosInterface(carregaDadosInterfaceBackup);

			UserCtrlBackup.eCallTrocaDiretorioBackup += new Backup.usrCtrlBackup.delCallTrocaDiretorioBackup(trocaPastaBackup);

			UserCtrlBackup.eCallHabilitaCamposBackup += new Backup.usrCtrlBackup.delCallHabilitaCamposBackup(habilitaCamposBackup);

			UserCtrlBackup.eCallCriaBackup += new Backup.usrCtrlBackup.delCallCriaBackup(criaBackup);

			UserCtrlBackup.eCallSalvaBackupCriado += new Backup.usrCtrlBackup.delCallSalvaBackupCriado(salvaBackupCriado);

			UserCtrlBackup.eCallRestauraBackup += new Backup.usrCtrlBackup.delCallRestauraBackup(restauraBackup);

			UserCtrlBackup.eCallSalvaDadosInterface += new Backup.usrCtrlBackup.delCallSalvaDadosInterface(salvaDadosInterfaceBackup);
		}
		#endregion
		#region InitializeEventsFormCores
		private void InitializeEventsFormCores(ref Cores.usrCtrlCores UserCtrlCores)
		{
			UserCtrlCores.eCallCarregaDadosInterface += new Cores.usrCtrlCores.delCallCarregaDadosInterface(carregaDadosInterfaceCores);

			UserCtrlCores.eCallAlteraCorPrimaria += new Cores.usrCtrlCores.delCallAlteraCorPrimaria(alteraCorPrimaria);

			UserCtrlCores.eCallAlteraCorSecundaria += new Cores.usrCtrlCores.delCallAlteraCorSecundaria(alteraCorSecundaria);

			UserCtrlCores.eCallAlteraBanner += new Cores.usrCtrlCores.delCallAlteraBanner(alteraBanner);

			UserCtrlCores.eCallClickBanner += new Cores.usrCtrlCores.delCallClickBanner(clickBanner);
		}
		#endregion
		#region InitializeEventsFormGlobal
		private void InitializeEventsFormGlobal(ref Global.usrCtrlGlobal UserCtrlGlobal)
		{
			UserCtrlGlobal.eCallCarregaDadosInterface += new Global.usrCtrlGlobal.delCallCarregaDadosInterface(carregaDadosInterfaceGlobal);

			UserCtrlGlobal.eCallSalvaDadosInterface += new Global.usrCtrlGlobal.delCallSalvaDadosInterface(salvaDadosInterfaceGlobal);
		}
		#endregion

		#region Carregamento dos Dados
		#region Banco de Dados
		private void carregaDadosBD()
		{
			try
			{
				#region Opção
				m_strUltimaOpcaoPreferencias = m_clsArquivoSiscoIni.retornaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.ULTIMAOPCAOPREFERENCIAS, "Global");
				m_bCanEditProducts = m_clsArquivoSiscoIni.retornaValor(mdlConstantes.clsConstantes.DEFAULT_SESSION_SISCOBRAS,"CanEditProducts",true);
				#endregion
				#region Backup
				m_strEnderecoBackup = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOENDERECOBACKUP,m_strEnderecoExecutavel/* + "Backup\\"*/);
				m_enumFrequencia = (FREQUENCIABACKUP)m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOFREQUENCIABACKUP,(int)FREQUENCIABACKUP.DIARIAMENTE);
				m_nQtdeBackups = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOQUANTIDADEBACKUP,m_nQtdeBackups);
				m_bPerguntarBackup = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOPERGUNTARBACKUP,m_bPerguntarBackup);
				mdlBackup.clsBackup.verificarQtdeBackup(ref m_cls_dba_ConnectionBD, m_strEnderecoBackup);
				#endregion
				#region Cores
				mdlPaletaDeCores.clsPaletaDeCores obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				m_clSecundaria = obj.retornaCorAtual();
				obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "CoresPrimarias");
				m_clPrimaria = obj.retornaCorAtual();
				#endregion

				// Relatorios

					// Fatura Comercial
					m_nFaturaComercialPrecisaoPesoLiquidoTotal = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,2);
					m_nFaturaComercialPrecisaoPesoBrutoTotal = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL,2);
					m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,true);
					m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,true);

					// Romaneio
					m_nRomaneioPrecisaoPesoLiquidoItens = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS,2);
					m_nRomaneioPrecisaoPesoLiquidoTotal = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,2);
					m_nRomaneioPrecisaoPesoBrutoItens = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS,2);
					m_nRomaneioPrecisaoPesoBrutoTotal = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL,2);
					m_bRomaneioPrecisaoPesoLiquidoItensArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS_ARREDONDAR,true);
					m_bRomaneioPrecisaoPesoLiquidoTotalArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,true);
					m_bRomaneioPrecisaoPesoBrutoItensArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS_ARREDONDAR,true);
					m_bRomaneioPrecisaoPesoBrutoTotalArredondar = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,true);
				#region Global
				m_bMostrarBaloes = m_clsArquivoSiscoIni.retornaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL,m_bMostrarBaloes);
				m_bMostrarAssistentes = m_clsArquivoSiscoIni.retornaValor(mdlConstantes.clsConstantes.SHOW_ASSISTENTE_SESSAO, mdlConstantes.clsConstantes.SHOW_ASSISTENTE_VARIAVEL,m_bMostrarAssistentes);
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Entrada
		private void carregaDadosInterfaceEntrada(ref System.Windows.Forms.RadioButton rbIniciarPE, ref System.Windows.Forms.RadioButton rbPE, ref System.Windows.Forms.RadioButton rbFaturaComercial, ref System.Windows.Forms.RadioButton rbIniciarBibliotecas, ref System.Windows.Forms.RadioButton rbBiblioCotacoes, ref System.Windows.Forms.RadioButton rbBiblioPEs)
		{
			try
			{
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Backup
		private void carregaDadosInterfaceBackup(ref mdlComponentesGraficos.TextBox tbPastas, ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref System.Windows.Forms.RadioButton rbNunca, ref System.Windows.Forms.RadioButton rbDiariamente, ref System.Windows.Forms.RadioButton rbSemanalmente, ref System.Windows.Forms.RadioButton rbMensalmente, ref mdlComponentesGraficos.TextBox tbNumeroBackups, ref System.Windows.Forms.CheckBox ckbxPerguntar, ref System.Windows.Forms.Label lManter, ref System.Windows.Forms.Label lPermitir, ref mdlComponentesGraficos.ListView lvBackups)
		{
			try
			{
				System.Collections.SortedList srlArquivos = new System.Collections.SortedList();
				System.DateTime dtCriacaoArquivo = System.DateTime.Now;
				System.Windows.Forms.ListViewItem lvItemArquivo = null;
				lvBackups.Items.Clear();
				tbPastas.Text = m_strEnderecoBackup;
				flBrDlgPastas.SelectedPath = m_strEnderecoBackup;
				if (System.IO.Directory.Exists(m_strEnderecoBackup))
				{
					m_strarrFiles = System.IO.Directory.GetFiles(tbPastas.Text, "*.bkp");
					foreach(string strFiles in m_strarrFiles)
					{
						//lvItemArquivo = lvBackups.Items.Add(strFiles.Substring(strFiles.LastIndexOf("\\") + 1), 0);
						//lvItemArquivo.Tag = strFiles;
						dtCriacaoArquivo = System.IO.File.GetCreationTime(strFiles);
						//lvItemArquivo.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
						srlArquivos.Add(dtCriacaoArquivo, strFiles);
					}
					string strArquivosSorted = "";
					for(int nCount = srlArquivos.Count - 1; nCount >= 0; nCount--)
					{
						strArquivosSorted = (string)srlArquivos.GetByIndex(nCount);
						dtCriacaoArquivo = System.IO.File.GetCreationTime(strArquivosSorted);
						lvItemArquivo = lvBackups.Items.Add(strArquivosSorted.Substring(strArquivosSorted.LastIndexOf("\\") + 1), 0);
						lvItemArquivo.Tag = strArquivosSorted;
						lvItemArquivo.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
					}
				}
				else
				{
					System.IO.Directory.CreateDirectory(m_strEnderecoBackup);
				}
				switch (m_enumFrequencia)
				{
					case FREQUENCIABACKUP.NUNCA: rbNunca.Checked = true;
						tbNumeroBackups.Enabled = false;
						ckbxPerguntar.Enabled = false;
						lManter.Enabled = false;
						lPermitir.Enabled = false;
						break;
					case FREQUENCIABACKUP.DIARIAMENTE: rbDiariamente.Checked = true;
						tbNumeroBackups.Enabled = true;
						ckbxPerguntar.Enabled = true;
						lManter.Enabled = true;
						lPermitir.Enabled = true;
						break;
					case FREQUENCIABACKUP.SEMANALMENTE: rbSemanalmente.Checked = true;
						tbNumeroBackups.Enabled = true;
						ckbxPerguntar.Enabled = true;
						lManter.Enabled = true;
						lPermitir.Enabled = true;
						break;
					case FREQUENCIABACKUP.MENSALMENTE: rbMensalmente.Checked = true;
						tbNumeroBackups.Enabled = true;
						ckbxPerguntar.Enabled = true;
						lManter.Enabled = true;
						lPermitir.Enabled = true;
						break;
				}
				tbNumeroBackups.Text = m_nQtdeBackups.ToString();
				ckbxPerguntar.Checked = m_bPerguntarBackup;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cores
		private void carregaDadosInterfaceCores(ref System.Windows.Forms.Button btPrimarias, ref System.Windows.Forms.Button btSecundarias)
		{
			try
			{
				
				btSecundarias.BackColor = m_clSecundaria;
				btPrimarias.BackColor = m_clPrimaria;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Global
		private void carregaDadosInterfaceGlobal(ref System.Windows.Forms.CheckBox ckbxBaloes, ref System.Windows.Forms.CheckBox ckbxAssistentes)
		{
			try
			{
				ckbxBaloes.Checked = m_bMostrarBaloes;
				ckbxAssistentes.Checked = m_bMostrarAssistentes;
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
		#region Paleta de Cores
		private void alteraCorPrimaria(ref System.Windows.Forms.Button btPrimaria)
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores obj = new mdlPaletaDeCores.clsPaletaDeCores(m_clPrimaria);
				obj.mostraCorAtual();
				m_clPrimaria = obj.retornaCorAtual();
				btPrimaria.BackColor = m_clPrimaria;
				this.CoresModificadas = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void alteraCorSecundaria(ref System.Windows.Forms.Button btSecundaria)
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores obj = new mdlPaletaDeCores.clsPaletaDeCores(m_clSecundaria);
				obj.mostraCorAtual();
				m_clSecundaria = obj.retornaCorAtual();
				btSecundaria.BackColor = m_clSecundaria;
				this.CoresModificadas = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface Backup
		private void trocaPastaBackup(ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref mdlComponentesGraficos.TextBox tbPastas, ref mdlComponentesGraficos.ListView lvBackups)
		{
			try
			{
				System.Collections.SortedList srlArquivos = new System.Collections.SortedList();
				System.DateTime dtCriacaoArquivo = System.DateTime.Now;
				System.Windows.Forms.ListViewItem lvItemBackup = null;
				flBrDlgPastas.SelectedPath = m_strEnderecoBackup;
				lvBackups.Items.Clear();
				if (flBrDlgPastas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					tbPastas.Text = flBrDlgPastas.SelectedPath;
					m_strEnderecoBackup = flBrDlgPastas.SelectedPath;
					mdlBackup.clsBackup.verificarQtdeBackup(ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel);
				}

				m_strarrFiles = System.IO.Directory.GetFiles(tbPastas.Text, "*.bkp");
				foreach(string strFiles in m_strarrFiles)
				{
					//lvItemArquivo = lvBackups.Items.Add(strFiles.Substring(strFiles.LastIndexOf("\\") + 1), 0);
					//lvItemArquivo.Tag = strFiles;
					dtCriacaoArquivo = System.IO.File.GetCreationTime(strFiles);
					//lvItemArquivo.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
					srlArquivos.Add(dtCriacaoArquivo, strFiles);
				}
				string strArquivosSorted = "";
				for(int nCount = srlArquivos.Count - 1; nCount >= 0; nCount--)
				{
					strArquivosSorted = (string)srlArquivos.GetByIndex(nCount);
					dtCriacaoArquivo = System.IO.File.GetCreationTime(strArquivosSorted);
					lvItemBackup = lvBackups.Items.Add(strArquivosSorted.Substring(strArquivosSorted.LastIndexOf("\\") + 1), 0);
					lvItemBackup.Tag = strArquivosSorted;
					lvItemBackup.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void habilitaCamposBackup(FREQUENCIABACKUP enumFrequencia, ref System.Windows.Forms.Label lManter, ref mdlComponentesGraficos.TextBox tbManter, ref System.Windows.Forms.Label lBackup, ref System.Windows.Forms.CheckBox ckbxPermitir)
		{
			try
			{
				switch (enumFrequencia)
				{
					case FREQUENCIABACKUP.NUNCA:
						lBackup.Enabled = false;
						lManter.Enabled = false;
						tbManter.Enabled = false;
						ckbxPermitir.Enabled = false;
						break;
					default:
						lBackup.Enabled = true;
						lManter.Enabled = true;
						tbManter.Enabled = true;
						ckbxPermitir.Enabled = true;
						break;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private bool criaBackup(ref System.Windows.Forms.SaveFileDialog svFlDlgBackup)
		{
			try
			{
				svFlDlgBackup.InitialDirectory = m_strEnderecoBackup;
				svFlDlgBackup.FileName = "Becape" + System.DateTime.Now.ToString("dd_MM_yyyy");
				if (svFlDlgBackup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return false;
		}
		private void salvaBackupCriado(ref mdlComponentesGraficos.ListView lvBackups, ref System.Windows.Forms.SaveFileDialog svFlDlgBackup, ref mdlComponentesGraficos.TextBox tbPastas)
		{
			try
			{
				System.Collections.SortedList srlArquivos = new System.Collections.SortedList();
				m_strEnderecoBackup = svFlDlgBackup.FileName.Substring(0, svFlDlgBackup.FileName.LastIndexOf("\\"));
				tbPastas.Text = m_strEnderecoBackup;
				System.DateTime dtCriacaoArquivo = System.DateTime.Now;
				System.Windows.Forms.ListViewItem lvItemBackup = null;
				string strNomeArquivoBackup = "";
				if (svFlDlgBackup.FileName.IndexOf(".") == -1)
				{
					if (svFlDlgBackup.FileName.IndexOf("\\") == -1)
						strNomeArquivoBackup = svFlDlgBackup.FileName;
					else
						strNomeArquivoBackup = svFlDlgBackup.FileName.Substring(svFlDlgBackup.FileName.LastIndexOf("\\") + 1);
				}
				else
				{
					if (svFlDlgBackup.FileName.IndexOf("\\") == -1)
						strNomeArquivoBackup = svFlDlgBackup.FileName.Substring(0, svFlDlgBackup.FileName.IndexOf("."));
					else
					{
						string strTemp = svFlDlgBackup.FileName.Substring(svFlDlgBackup.FileName.LastIndexOf("\\") + 1);
						strNomeArquivoBackup = strTemp.Substring(0, strTemp.IndexOf("."));
					}
				}
				mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel, m_strEnderecoBackup, strNomeArquivoBackup);
				obj.IncluirModulos = ((System.Windows.Forms.Form.ModifierKeys & System.Windows.Forms.Keys.Control) != System.Windows.Forms.Keys.Control);
				if (obj.bCriaBackup())
				{
					mdlBackup.clsBackup.verificarQtdeBackup(ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel);
					lvBackups.Items.Clear();
					m_strarrFiles = System.IO.Directory.GetFiles(tbPastas.Text, "*.bkp");
					foreach(string strFiles in m_strarrFiles)
					{
						//lvItemArquivo = lvBackups.Items.Add(strFiles.Substring(strFiles.LastIndexOf("\\") + 1), 0);
						//lvItemArquivo.Tag = strFiles;
						dtCriacaoArquivo = System.IO.File.GetCreationTime(strFiles);
						//lvItemArquivo.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
						srlArquivos.Add(dtCriacaoArquivo, strFiles);
					}
					string strArquivosSorted = "";
					for(int nCount = srlArquivos.Count - 1; nCount >= 0; nCount--)
					{
						strArquivosSorted = (string)srlArquivos.GetByIndex(nCount);
						dtCriacaoArquivo = System.IO.File.GetCreationTime(strArquivosSorted);
						lvItemBackup = lvBackups.Items.Add(strArquivosSorted.Substring(strArquivosSorted.LastIndexOf("\\") + 1), 0);
						lvItemBackup.Tag = strArquivosSorted;
						lvItemBackup.SubItems.Add(dtCriacaoArquivo.ToString("dd/MM/yyyy HH:mm:ss"));
					}
				}
				else
				{
				}
			}
			catch (Exception erro)
			{
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosInterfaceBackup(ref mdlComponentesGraficos.TextBox tbPastas, ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref System.Windows.Forms.RadioButton rbNunca, ref System.Windows.Forms.RadioButton rbDiariamente, ref System.Windows.Forms.RadioButton rbSemanalmente, ref System.Windows.Forms.RadioButton rbMensalmente, ref mdlComponentesGraficos.TextBox tbNumeroBackups, ref System.Windows.Forms.CheckBox ckbxPerguntar)
		{
			try
			{
				m_strEnderecoBackup = flBrDlgPastas.SelectedPath;
				tbPastas.Text = m_strEnderecoBackup;
				if (rbNunca.Checked)
				{
					m_enumFrequencia = FREQUENCIABACKUP.NUNCA;
				}
				else if (rbDiariamente.Checked)
				{
					m_enumFrequencia = FREQUENCIABACKUP.DIARIAMENTE;
				}
				else if (rbSemanalmente.Checked)
				{
					m_enumFrequencia = FREQUENCIABACKUP.SEMANALMENTE;
				}
				else if (rbMensalmente.Checked)
				{
					m_enumFrequencia = FREQUENCIABACKUP.MENSALMENTE;
				}
				m_nQtdeBackups = Int32.Parse((tbNumeroBackups.Text.Trim() != "" ? tbNumeroBackups.Text : "0"));
				m_bPerguntarBackup = ckbxPerguntar.Checked;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void restauraBackup(ref mdlComponentesGraficos.ListView lvBackup)
		{
			try
			{
				string strArquivoBackup = lvBackup.SelectedItems[0].Text.Substring(0, lvBackup.SelectedItems[0].Text.IndexOf("."));
				mdlBackup.clsBackup obj = new mdlBackup.clsBackup(ref m_cls_ter_tratadorErro, ref m_cls_dba_ConnectionBD, m_strEnderecoExecutavel, m_strEnderecoBackup, strArquivoBackup);
				obj.bRestauraBackup();
			}
			catch (Exception erro)
			{
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Interface Global
		private void salvaDadosInterfaceGlobal(ref System.Windows.Forms.CheckBox ckbxBaloes, ref System.Windows.Forms.CheckBox ckbxAssistentes)
		{
			try
			{
				m_bMostrarBaloes = ckbxBaloes.Checked;
				m_bMostrarAssistentes = ckbxAssistentes.Checked;
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Banco de Dados
		private void salvaDadosBD(bool bModificado, ref mdlComponentesGraficos.TreeView tvPreferencias)
		{
			try
			{
				#region Última Preferência
				System.Windows.Forms.TreeNode tnPreferencia = null;
				if (tvPreferencias.SelectedNode != null)
					tnPreferencia = tvPreferencias.SelectedNode;
				if (tnPreferencia != null)
				{
					m_strUltimaOpcaoPreferencias = tnPreferencia.Text;
					m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.ULTIMAOPCAOPREFERENCIAS, m_strUltimaOpcaoPreferencias);
				}
				#endregion
				#region Entrada
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARFATURAOUBIBLIOTECA, m_bIniciarPE.ToString());
				if (m_bIniciarPE)
				{
					m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA, m_bIniciarPEInfoOuFatura.ToString());
				}
				else
				{
					m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA, m_bIniciarCotacoesOuPEs.ToString());
				}
				#endregion
				#region Backup
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOENDERECOBACKUP,m_strEnderecoBackup);
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOFREQUENCIABACKUP,((int)m_enumFrequencia).ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOQUANTIDADEBACKUP,m_nQtdeBackups.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOPERGUNTARBACKUP,m_bPerguntarBackup.ToString());
				#endregion
				#region Cores
				mdlPaletaDeCores.clsPaletaDeCores obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				obj.COR = m_clSecundaria;
				obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "CoresPrimarias");
				obj.COR = m_clPrimaria;
				#endregion
				//Relatorios
				// Fatura Comercial
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.DEFAULT_SESSION_SISCOBRAS,"CanEditProducts",m_bCanEditProducts.ToString());

				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,m_nFaturaComercialPrecisaoPesoLiquidoTotal.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL,m_nFaturaComercialPrecisaoPesoBrutoTotal.ToString());   
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_FATURACOMERCIAL_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar.ToString());

				// Romaneio
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS,m_nRomaneioPrecisaoPesoLiquidoItens.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL,m_nRomaneioPrecisaoPesoLiquidoTotal.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS,m_nRomaneioPrecisaoPesoBrutoItens.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL,m_nRomaneioPrecisaoPesoBrutoTotal.ToString());   
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_ITENS_ARREDONDAR,m_bRomaneioPrecisaoPesoLiquidoItensArredondar.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOLIQUIDO_TOTAL_ARREDONDAR,m_bRomaneioPrecisaoPesoLiquidoTotalArredondar.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_ITENS_ARREDONDAR,m_bRomaneioPrecisaoPesoBrutoItensArredondar.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPO_ROMANEIO_CASAS_DECIMAIS_PESOBRUTO_TOTAL_ARREDONDAR,m_bRomaneioPrecisaoPesoBrutoTotalArredondar.ToString());
				#region Global
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, m_bMostrarBaloes.ToString());
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.SHOW_ASSISTENTE_SESSAO, mdlConstantes.clsConstantes.SHOW_ASSISTENTE_VARIAVEL, m_bMostrarAssistentes.ToString());
				#endregion
				m_bModificado = true;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void salvaDadosBD(string strUltimaPreferencia)
		{
			try
			{
				#region Última Preferência
				m_strUltimaOpcaoPreferencias = strUltimaPreferencia;
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.ULTIMAOPCAOPREFERENCIAS, m_strUltimaOpcaoPreferencias);
				#endregion
				#region Entrada
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARFATURAOUBIBLIOTECA, m_bIniciarPE.ToString());
				if (m_bIniciarPE)
				{
					m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA, m_bIniciarPEInfoOuFatura.ToString());
				}
				else
				{
					m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.PREFERENCIAS + m_nIdUsuario.ToString(), mdlConstantes.clsConstantes.CAMPOINICIARPEINFOOUFATURAEEXPORTADOROUBIBLIOTECA, m_bIniciarCotacoesOuPEs.ToString());
				}
				#endregion
				#region Backup
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOENDERECOBACKUP,m_strEnderecoBackup);
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOFREQUENCIABACKUP,((int)m_enumFrequencia).ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOQUANTIDADEBACKUP,m_nQtdeBackups.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.CAMPOPERGUNTARBACKUP,m_bPerguntarBackup.ToString());
				#endregion
				#region Cores
				mdlPaletaDeCores.clsPaletaDeCores obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				obj.COR = m_clSecundaria;
				obj = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "CoresPrimarias");
				obj.COR = m_clPrimaria;
				#endregion
				#region Global
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.SHOW_BALLOONTIP_SESSAO, mdlConstantes.clsConstantes.SHOW_BALLOONTIP_VARIAVEL, m_bMostrarBaloes.ToString());
				m_clsArquivoSiscoIni.colocaValor(mdlConstantes.clsConstantes.SHOW_ASSISTENTE_SESSAO, mdlConstantes.clsConstantes.SHOW_ASSISTENTE_VARIAVEL, m_bMostrarAssistentes.ToString());
				#endregion
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Versoes
			private void vCarregaVersoes(out string strVersaoServidor,out string strVersaoCliente)
			{
				strVersaoServidor = strVersaoCliente = "";

				try
				{
					mdlManipuladorArquivo.clsManipuladorArquivoIni cls_ini_File = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + "Sisco.ini");
					strVersaoCliente = cls_ini_File.retornaValor("Siscobras","VersaoCliente","");
				}catch{
				}
				if (m_cls_dba_ConnectionBD != null)
				{
					try
					{
						strVersaoServidor = m_cls_dba_ConnectionBD.GetConfiguracao("STRVERSION","");
					}catch{

					}
				}
			}
		#endregion
		#region Relatorios
			private void vInitializeEvents(ref usrCtrlRelatorios UserCtrlRelatorios)
			{
				// Carrega Dados Relatorios
				UserCtrlRelatorios.eCallCarregaDadosInterface += new mdlPreferencias.usrCtrlRelatorios.delCallCarregaDadosInterface(vCarregaDadosRelatorios);

				// Salva Dados Relatorios
				UserCtrlRelatorios.eCallSalvaDadosInterface += new mdlPreferencias.usrCtrlRelatorios.delCallSalvaDadosInterface(vSalvaDadosRelatorios);

			}

			private void vCarregaDadosRelatorios(out int nFaturaComercialPrecisaoPesoLiquidoTotal,out int nFaturaComercialPrecisaoPesoBrutoTotal,out bool bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,out bool bFaturaComercialPrecisaoPesoBrutoTotalArredondar,out int nRomaneioPrecisaoPesoLiquidoItens,out int nRomaneioPrecisaoPesoLiquidoTotal,out int nRomaneioPrecisaoPesoBrutoItens,out int nRomaneioPrecisaoPesoBrutoTotal,out bool bRomaneioPrecisaoPesoLiquidoItensArredondar,out bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bool bRomaneioPrecisaoPesoBrutoItensArredondar,out bool bRomaneioPrecisaoPesoBrutoTotalArredondar,out bool bCanEditProducts)
			{
				nFaturaComercialPrecisaoPesoLiquidoTotal = m_nFaturaComercialPrecisaoPesoLiquidoTotal;
				nFaturaComercialPrecisaoPesoBrutoTotal = m_nFaturaComercialPrecisaoPesoBrutoTotal;
				bFaturaComercialPrecisaoPesoLiquidoTotalArredondar = m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar;
				bFaturaComercialPrecisaoPesoBrutoTotalArredondar = m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar;
				nRomaneioPrecisaoPesoLiquidoItens = m_nRomaneioPrecisaoPesoLiquidoItens;
				nRomaneioPrecisaoPesoLiquidoTotal = m_nRomaneioPrecisaoPesoLiquidoTotal;
				nRomaneioPrecisaoPesoBrutoItens = m_nRomaneioPrecisaoPesoBrutoItens;
				nRomaneioPrecisaoPesoBrutoTotal = m_nRomaneioPrecisaoPesoBrutoTotal;
				bRomaneioPrecisaoPesoLiquidoItensArredondar = m_bRomaneioPrecisaoPesoLiquidoItensArredondar;
				bRomaneioPrecisaoPesoLiquidoTotalArredondar = m_bRomaneioPrecisaoPesoLiquidoTotalArredondar;
				bRomaneioPrecisaoPesoBrutoItensArredondar = m_bRomaneioPrecisaoPesoBrutoItensArredondar;
				bRomaneioPrecisaoPesoBrutoTotalArredondar = m_bRomaneioPrecisaoPesoBrutoTotalArredondar;
				bCanEditProducts = m_bCanEditProducts;
			}

			private void vSalvaDadosRelatorios(int nFaturaComercialPrecisaoPesoLiquidoTotal,int nFaturaComercialPrecisaoPesoBrutoTotal,bool bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,bool bFaturaComercialPrecisaoPesoBrutoTotalArredondar,int nRomaneioPrecisaoPesoLiquidoItens,int nRomaneioPrecisaoPesoLiquidoTotal,int nRomaneioPrecisaoPesoBrutoItens,int nRomaneioPrecisaoPesoBrutoTotal,bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,bool bRomaneioPrecisaoPesoBrutoItensArredondar,bool bRomaneioPrecisaoPesoBrutoTotalArredondar,bool bCanEditProducts)
			{

				// Fatura Comercial
				
				if (m_nFaturaComercialPrecisaoPesoLiquidoTotal != nFaturaComercialPrecisaoPesoLiquidoTotal)
					m_bRelatorioFaturaComercialRecarregar = true;
				if (m_nFaturaComercialPrecisaoPesoBrutoTotal != nFaturaComercialPrecisaoPesoBrutoTotal)
					m_bRelatorioFaturaComercialRecarregar = true;
				if (m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar != bFaturaComercialPrecisaoPesoLiquidoTotalArredondar)
					m_bRelatorioFaturaComercialRecarregar = true;
				if (m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar != bFaturaComercialPrecisaoPesoBrutoTotalArredondar)
					m_bRelatorioFaturaComercialRecarregar = true;

				m_bCanEditProducts = bCanEditProducts;
				m_nFaturaComercialPrecisaoPesoLiquidoTotal = nFaturaComercialPrecisaoPesoLiquidoTotal;
				m_nFaturaComercialPrecisaoPesoBrutoTotal = nFaturaComercialPrecisaoPesoBrutoTotal;
				m_bFaturaComercialPrecisaoPesoLiquidoTotalArredondar = bFaturaComercialPrecisaoPesoLiquidoTotalArredondar;
				m_bFaturaComercialPrecisaoPesoBrutoTotalArredondar = bFaturaComercialPrecisaoPesoBrutoTotalArredondar;

				// Romaneio
				if (m_nRomaneioPrecisaoPesoLiquidoItens != nRomaneioPrecisaoPesoLiquidoItens)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_nRomaneioPrecisaoPesoLiquidoTotal != nRomaneioPrecisaoPesoLiquidoTotal)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_nRomaneioPrecisaoPesoBrutoItens != nRomaneioPrecisaoPesoBrutoItens)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_nRomaneioPrecisaoPesoBrutoTotal != nRomaneioPrecisaoPesoBrutoTotal)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_bRomaneioPrecisaoPesoLiquidoItensArredondar != bRomaneioPrecisaoPesoLiquidoItensArredondar)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_bRomaneioPrecisaoPesoLiquidoTotalArredondar != bRomaneioPrecisaoPesoLiquidoTotalArredondar)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_bRomaneioPrecisaoPesoBrutoItensArredondar != bRomaneioPrecisaoPesoBrutoItensArredondar)
					m_bRelatorioRomaneioRecarregar = true;
				if (m_bRomaneioPrecisaoPesoBrutoTotalArredondar != bRomaneioPrecisaoPesoBrutoTotalArredondar)
					m_bRelatorioRomaneioRecarregar = true;

				m_nRomaneioPrecisaoPesoLiquidoItens = nRomaneioPrecisaoPesoLiquidoItens;
				m_nRomaneioPrecisaoPesoLiquidoTotal = nRomaneioPrecisaoPesoLiquidoTotal;
				m_nRomaneioPrecisaoPesoBrutoItens = nRomaneioPrecisaoPesoBrutoItens;
				m_nRomaneioPrecisaoPesoBrutoTotal = nRomaneioPrecisaoPesoBrutoTotal;
				m_bRomaneioPrecisaoPesoLiquidoItensArredondar = bRomaneioPrecisaoPesoLiquidoItensArredondar;
				m_bRomaneioPrecisaoPesoLiquidoTotalArredondar = bRomaneioPrecisaoPesoLiquidoTotalArredondar;
				m_bRomaneioPrecisaoPesoBrutoItensArredondar = bRomaneioPrecisaoPesoBrutoItensArredondar;
				m_bRomaneioPrecisaoPesoBrutoTotalArredondar = bRomaneioPrecisaoPesoBrutoTotalArredondar;
			}
		#endregion
		#region Mensagens
			private void vInitializeEvents(ref usrCtrlMensagens UserCtrlMensagens)
			{
				//SiscoMensagem Init 
				UserCtrlMensagens.eCallCarregaDadosSiscoMensagemInicializacao += new mdlPreferencias.usrCtrlMensagens.delCallCarregaDadosSiscoMensagemInicializacao(enumSiscoMensagemInit);

				//Salva Dados
				UserCtrlMensagens.eCallSalvaDadosSiscoMensagemInicializacao += new mdlPreferencias.usrCtrlMensagens.delCallSalvaDadosSiscoMensagemInicializacao(vSalvaDadosSiscoMensagemInit);

				//SiscoMensagem State
				UserCtrlMensagens.eCallCarregaDadosSiscoMensagemEstado +=new mdlPreferencias.usrCtrlMensagens.delCallCarregaDadosSiscoMensagemEstado(enumSiscoMensagemState);

				//SiscoMensagem Iniciar
				UserCtrlMensagens.eCallSiscoMensagemIniciar += new mdlPreferencias.usrCtrlMensagens.delCallSiscoMensagemIniciar(bSiscoMensagemStart);

				//SiscoMensagem Pausar
				UserCtrlMensagens.eCallSiscoMensagemPausar += new mdlPreferencias.usrCtrlMensagens.delCallSiscoMensagemPausar(bSiscoMensagemPause);

				//SiscoMensagem Continuar
				UserCtrlMensagens.eCallSiscoMensagemContinuar += new mdlPreferencias.usrCtrlMensagens.delCallSiscoMensagemContinuar(bSiscoMensagemContinue);

				//SiscoMensagem Parar
				UserCtrlMensagens.eCallSiscoMensagemParar += new mdlPreferencias.usrCtrlMensagens.delCallSiscoMensagemParar(bSiscoMensagemStop);

				//SiscoMensagem Fechar
				UserCtrlMensagens.eCallSiscoMensagemFechar += new mdlPreferencias.usrCtrlMensagens.delCallSiscoMensagemFechar(bSiscoMensagemClose);

			}

			private mdlConstantes.SiscoMensagemInit enumSiscoMensagemInit()
			{
				return(m_cls_mws_SiscoMensagem.Initialization);
			}

			private void vSalvaDadosSiscoMensagemInit(mdlConstantes.SiscoMensagemInit enumSiscoMensagemInit)
			{
				m_cls_mws_SiscoMensagem.Initialization = enumSiscoMensagemInit;
			}

			private mdlConstantes.SiscoMensagemState enumSiscoMensagemState()
			{
				return(m_cls_mws_SiscoMensagem.State);
			}

			private bool bSiscoMensagemStart()
			{
				return(m_cls_mws_SiscoMensagem.bStart());
			}

			private bool bSiscoMensagemPause()
			{
				return(m_cls_mws_SiscoMensagem.bPause());
			}

			private bool bSiscoMensagemContinue()
			{
				return(m_cls_mws_SiscoMensagem.bContinue());
			}

			private bool bSiscoMensagemStop()
			{
				return(m_cls_mws_SiscoMensagem.bStop());
			}

			private bool bSiscoMensagemClose()
			{
				return(m_cls_mws_SiscoMensagem.bClose());
			}
		#endregion
		#region Atualizacoes
			private void vInitializeEvents(ref usrCtrlAtualizacoes UserCtrlAtualizacoes)
			{
				UserCtrlAtualizacoes.eCallCarregaDados += new mdlPreferencias.usrCtrlAtualizacoes.delCallCarregaDados(strtCarregaDadosAtualizacoes);
			}

			private string strtCarregaDadosAtualizacoes()
			{
				string strReturn = "";
				System.Data.DataSet dtstUpdates = clsConfigurations.dtstUpdateInformation();
				if (dtstUpdates != null)
				{
					System.Collections.SortedList sortListRevisions = new System.Collections.SortedList();
					foreach(System.Data.DataTable dttbRevision in dtstUpdates.Tables)
						sortListRevisions.Add(dttbRevision.TableName,dttbRevision);
					for(int i = sortListRevisions.Count - 1; i >= 0;i--)
					{
						System.Data.DataTable dttbRevision = (System.Data.DataTable)sortListRevisions.GetByIndex(i);
						strReturn = strReturn + strReturnRevisionText(ref dttbRevision,i + 1) + System.Environment.NewLine;
					}
				}
				return(strReturn);
			}

			private string strReturnRevisionText(ref System.Data.DataTable dttbRevision,int nRevision)
			{
				string strReturn = "";
				strReturn = strReturn + "------------------------------------------------------------------------------------------" + System.Environment.NewLine;
				// Number 
				strReturn = strReturn + "Revisão: " + nRevision.ToString() + System.Environment.NewLine;
				// Name
				foreach(System.Data.DataRow dtrwName in dttbRevision.Rows)
				{
					if (dtrwName["Name"] != System.DBNull.Value)
					{
						strReturn = strReturn + "Versão: " + dtrwName["Name"].ToString() + System.Environment.NewLine;
						break;
					}
				}
				// Date
				foreach(System.Data.DataRow dtrwName in dttbRevision.Rows)
				{
					if (dtrwName["Date"] != System.DBNull.Value)
					{
						strReturn = strReturn + "Data: " + dtrwName["Date"].ToString() + System.Environment.NewLine;
						break;
					}
				}

				strReturn = strReturn + System.Environment.NewLine;

				// Updates
				foreach(System.Data.DataRow dtrwName in dttbRevision.Rows)
				{
					if (dtrwName["Update"] != System.DBNull.Value)
						strReturn = strReturn + dtrwName["Update"].ToString() + System.Environment.NewLine;
				}
               
				//strReturn = strReturn + "*******************************************************************************" + System.Environment.NewLine;
				return(strReturn);
			}
		#endregion

		#region Configura Banco de Dados
		private void configuraBancoDados()
		{
			try
			{
				if (mdlMensagens.clsMensagens.ShowQuestion("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPreferencias_clsPreferencias_ConfiguraBancoDeDados.ToString()), System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					salvaDadosBD(m_formFPreferencias.PREFERENCIASELECIONADA);
					mdlDataBaseConfig.clsDataBaseConfig obj = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_tratadorErro, m_strEnderecoExecutavel);
					obj.ShowDataBaseConfig();
					if (obj.bDataBaseConfiguratedRight())
					{
						obj.ReturnDataBaseAccess(out m_cls_dba_ConnectionBD);
						System.Environment.Exit(0);
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Altera Banner
		protected void alteraBanner(ref System.Windows.Forms.PictureBox pbBanner)
		{
			try
			{
				pbBanner.Image = mdlControladoraImagens.clsControladoraImagens.retornaImagem(mdlControladoraImagens.LOCALIMAGEM.PREFERENCIAS);
				m_strLinkImagemInternet = mdlControladoraImagens.clsControladoraImagens.LINKINTERNET;
				m_formFPreferencias.setToolTipBanner(mdlControladoraImagens.clsControladoraImagens.TOOLTIPIMAGEM);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region ClickBanner
		private void clickBanner()
		{
			try
			{
				if (m_strLinkImagemInternet != "")
					System.Diagnostics.Process.Start(m_strLinkImagemInternet);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Entrada
			private void vCarregaDadosEntrada(out bool bEntrarUltimaConta,out bool bEntrarUltimoPe,out bool bEntrarUltimoDocumento,out int nIdDocumento)
			{
				bEntrarUltimaConta = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMA_CONTA,false);
				bEntrarUltimoPe = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_PE,false);
				bEntrarUltimoDocumento = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_DOCUMENTO,false);
				nIdDocumento = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_QUAL_DOCUMENTO,-1);
			}

			private bool bSalvaDadosEntrada(bool bEntrarUltimaConta,bool bEntrarUltimoPe,bool bEntrarUltimoDocumento,int nIdDocumento)
			{
				bool bRetorno = false;
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMA_CONTA,bEntrarUltimaConta.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_PE,bEntrarUltimoPe.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_ULTIMO_DOCUMENTO,bEntrarUltimoDocumento.ToString());
				m_cls_dba_ConnectionBD.SetConfiguracao(mdlConstantes.clsConstantes.VARIAVEL_ENTRAR_QUAL_DOCUMENTO,nIdDocumento.ToString());
				return(bRetorno);
			}
		#endregion
		#region PrestadorServico
			private bool bPrestadorServico()
			{
				bool bRetorno = false;
				string strCodigoCliente = m_cls_dba_ConnectionBD.GetConfiguracao(mdlConstantes.clsConstantes.CAMPOIDCLIENTE,"");
				if (strCodigoCliente != "")
				{
					strCodigoCliente = strCodigoCliente.Substring(0,2);
					if ((strCodigoCliente == "12") || (strCodigoCliente == "22"))
						bRetorno = true;
				}
				return(bRetorno);
			}
		#endregion

		#region EnvioErros
			private void ShowDialogEnviaErros()
			{
				mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros cls_wbsvEnviaDados = new mdlWebServiceEnviaDados.clsWebServiceEnviaDadosErros(ref m_cls_ter_tratadorErro,ref m_cls_dba_ConnectionBD,m_strEnderecoExecutavel);
				if (cls_wbsvEnviaDados.bEnviaDados())
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlControladoraModulos_clsControladoraModulos_EnvioErrosSucesso));
				else
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlControladoraModulos_clsControladoraModulos_EnvioErrosFalha));
			}
		#endregion
	}
}
