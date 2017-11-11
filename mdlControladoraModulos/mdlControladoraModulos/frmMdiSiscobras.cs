using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlControladoraModulos
{
	/// <summary>
	/// Summary description for frmMdiSiscobras.
	/// </summary>
	internal class frmMdiSiscobras : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallShowStart();

			public delegate void delCallShowContas();
			public delegate void delCallShowPrestadorServicoCadastros();
			public delegate void delCallShowExportadorCadastros();	
			public delegate void delCallShowBibliotecas();
			public delegate void delCallShowCotacoes();
			
			public delegate void delCallShowDialogImportadores();
			public delegate void delCallShowDialogProdutos();
			public delegate void delCallShowDialogBancos();
			public delegate void delCallShowDialogContratosCambio();

			public delegate void delCallShowDialogSumario();
			public delegate void delCallShowDialogFaturaProforma();
			public delegate void delCallShowDialogFaturaComercial();
			public delegate void delCallShowDialogCertificadoOrigem();
			public delegate void delCallShowDialogRomaneio();
			public delegate void delCallShowDialogSaque();
			public delegate void delCallShowDialogInstrucaoEmbarque();
			public delegate void delCallShowDialogBordero();
			public delegate void delCallRefreshBordero();
			public delegate void delCallShowDialogRelatorioIndefinido();

			public delegate void delCallShowDialogExportacaoDocumentos();

			public delegate void delCallShowDialogSiscoEstatistico();
			public delegate void delCallShowDialogPesquisarClassificacaoTarifaria();
			public delegate void delCallShowDialogPreferencias();
			public delegate void delCallShowDialogPreferencesNeeded();
			public delegate void delCallShowDialogBancoDados();
			public delegate void delCallShowDialogEnviaErros();
			public delegate void delCallShowDialogAtualizacao();

			public delegate bool delCallExisteFaturaComercial();
			public delegate bool delCallExisteCertificadoOrigem();
			public delegate bool delCallExisteRomaneio();
			public delegate bool delCallExisteSaque();
			public delegate bool delCallExisteInstrucaoEmbarque();
			public delegate bool delCallExisteBordero();
			public delegate bool delCallExisteSumario();
		#endregion
		#region Events
			public event delCallShowStart eCallShowStart;

			public event delCallShowContas eCallShowContas;
			public event delCallShowPrestadorServicoCadastros eCallShowPrestadorServicoCadastros;
			public event delCallShowExportadorCadastros eCallShowExportadorCadastros;

			public event delCallShowBibliotecas eCallShowBibliotecas;
			public event delCallShowCotacoes eCallShowCotacoes;

			public event delCallShowDialogImportadores eCallShowDialogImportadores;
			public event delCallShowDialogProdutos eCallShowDialogProdutos;
			public event delCallShowDialogBancos eCallShowDialogBancos;
			public event delCallShowDialogContratosCambio eCallShowDialogContratosCambio;
		
			public event delCallShowDialogSumario eCallShowDialogSumario;
			public event delCallShowDialogFaturaProforma eCallShowDialogFaturaProforma;
			public event delCallShowDialogFaturaComercial eCallShowDialogFaturaComercial;
			public event delCallShowDialogCertificadoOrigem eCallShowDialogCertificadoOrigem;
			public event delCallShowDialogRomaneio eCallShowDialogRomaneio;
			public event delCallShowDialogSaque eCallShowDialogSaque;
			public event delCallShowDialogInstrucaoEmbarque eCallShowDialogInstrucaoEmbarque;
			public event delCallShowDialogBordero eCallShowDialogBordero;
			public event delCallRefreshBordero eCallRefreshBordero;
			public event delCallShowDialogRelatorioIndefinido eCallShowDialogRelatorioIndefinido;

			public event delCallShowDialogExportacaoDocumentos eCallShowDialogExportacaoDocumentos;

			public event delCallShowDialogSiscoEstatistico eCallShowDialogSiscoEstatistico;
			public event delCallShowDialogPesquisarClassificacaoTarifaria eCallShowDialogPesquisarClassificacaoTarifaria;
			public event delCallShowDialogPreferencias eCallShowDialogPreferencias;
			public event delCallShowDialogPreferencesNeeded eCallShowDialogPreferencesNeeded;
			public event delCallShowDialogBancoDados eCallShowDialogBancoDados;
			public event delCallShowDialogEnviaErros eCallShowDialogEnviaErros;
			public event delCallShowDialogAtualizacao eCallShowDialogAtualizacao;

			public event delCallExisteFaturaComercial eCallExisteFaturaComercial;
			public event delCallExisteCertificadoOrigem eCallExisteCertificadoOrigem;
			public event delCallExisteRomaneio eCallExisteRomaneio;
			public event delCallExisteSaque eCallExisteSaque;
			public event delCallExisteInstrucaoEmbarque eCallExisteInstrucaoEmbarque;
			public event delCallExisteBordero eCallExisteBordero;
			public event delCallExisteSumario eCallExisteSumario;
		#endregion
		#region Events Methods
			protected virtual void OnCallShowStart()
			{
				if (eCallShowStart != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowStart();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowContas()
			{
				if (eCallShowContas != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowContas();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowPrestadorServicoCadastros()
			{
				if (eCallShowPrestadorServicoCadastros != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowPrestadorServicoCadastros();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowExportadorCadastros()
			{
				if (eCallShowExportadorCadastros != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowExportadorCadastros();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowBibliotecas()
			{
				if (eCallShowBibliotecas != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowBibliotecas();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowCotacoes()
			{
				if (eCallShowCotacoes != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowCotacoes();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogImportadores()
			{
				if (eCallShowDialogImportadores != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogImportadores();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogProdutos()
			{
				if (eCallShowDialogProdutos != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogProdutos();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogBancos()
			{
				if (eCallShowDialogBancos != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogBancos();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogContratosCambio()
			{
				if (eCallShowDialogContratosCambio != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogContratosCambio();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogSumario()
			{
				if (eCallShowDialogSumario != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogSumario();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogFaturaProforma()
			{
				if (eCallShowDialogFaturaProforma != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogFaturaProforma();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogFaturaComercial()
			{
				if (eCallShowDialogFaturaComercial != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogFaturaComercial();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogCertificadoOrigem()
			{
				if (eCallShowDialogCertificadoOrigem != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogCertificadoOrigem();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			protected virtual void OnCallShowDialogRomaneio()
			{
				if (eCallShowDialogRomaneio != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogRomaneio();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			protected virtual void OnCallShowDialogSaque()
			{
				if (eCallShowDialogSaque != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogSaque();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			protected virtual void OnCallShowDialogInstrucaoEmbarque()
			{
				if (eCallShowDialogInstrucaoEmbarque != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogInstrucaoEmbarque();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			protected virtual void OnCallShowDialogBordero()
			{
				if (eCallShowDialogBordero != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogBordero();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallRefreshBordero()
			{
				if (eCallRefreshBordero != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallRefreshBordero();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogRelatorioIndefinido()
			{
				if (eCallShowDialogRelatorioIndefinido != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogRelatorioIndefinido();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogExportacaoDocumentos()
			{
				if (eCallShowDialogExportacaoDocumentos != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogExportacaoDocumentos();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogSiscoEstatistico()
			{
				if (eCallShowDialogSiscoEstatistico != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogSiscoEstatistico();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogPesquisarClassificacaoTarifaria()
			{
				if (eCallShowDialogPesquisarClassificacaoTarifaria != null)
				{
					eCallShowDialogPesquisarClassificacaoTarifaria();
				}
			}

			protected virtual void OnCallShowDialogPreferencias()
			{
				if (eCallShowDialogPreferencias != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogPreferencias();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogPreferencesNeeded()
			{
				if (eCallShowDialogPreferencesNeeded != null)
					eCallShowDialogPreferencesNeeded();
			}

			protected virtual void OnCallShowDialogBancoDados()
			{
				if (eCallShowDialogBancoDados!= null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogBancoDados();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogEnviaErros()
			{
				if (eCallShowDialogEnviaErros != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogEnviaErros();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual void OnCallShowDialogAtualizacao()
			{
				if (eCallShowDialogAtualizacao != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallShowDialogAtualizacao();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}

			protected virtual bool OnCallExisteFaturaComercial()
			{
				bool bRetorno = false;
				if (eCallExisteFaturaComercial != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteFaturaComercial();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteCertificadoOrigem()
			{
				bool bRetorno = false;
				if (eCallExisteCertificadoOrigem != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteCertificadoOrigem();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteRomaneio()
			{
				bool bRetorno = false;
				if (eCallExisteRomaneio != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteRomaneio();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteSaque()
			{
				bool bRetorno = false;
				if (eCallExisteSaque != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteSaque();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteInstrucaoEmbarque()
			{
				bool bRetorno = false;
				if (eCallExisteInstrucaoEmbarque != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteInstrucaoEmbarque();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteBordero()
			{
				bool bRetorno = false;
				if (eCallExisteBordero != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteBordero();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

			protected virtual bool OnCallExisteSumario()
			{
				bool bRetorno = false;
				if (eCallExisteSumario != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					bRetorno = eCallExisteSumario();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
				return(bRetorno);
			}

		#endregion

		#region Atributos
			private string m_strEnderecoExecutavel;
			private System.Drawing.Color m_clrDocumentoExistente = System.Drawing.Color.LightGreen;
			private System.Drawing.Color m_clrDocumentoInexistente = System.Drawing.Color.Tomato;

			private System.Windows.Forms.ToolTip m_ttDica;
			public System.Windows.Forms.ImageList m_ilBandeiras;
			internal System.Windows.Forms.Button m_btTrocarConta;
			internal System.Windows.Forms.GroupBox m_gbPe;
			public System.Windows.Forms.Button m_btBordero;
			public System.Windows.Forms.Button m_btInstrucaoEmbarque;
			public System.Windows.Forms.Button m_btFaturaProforma;
			public System.Windows.Forms.Button m_btRomaneio;
			public System.Windows.Forms.Button m_btSaque;
			public System.Windows.Forms.Button m_btFaturaComercial;
			public System.Windows.Forms.Button m_btCertificadoOrigens;
			public System.Windows.Forms.Button m_btSumario;
			public System.Windows.Forms.GroupBox m_pnEsquerda;
			internal System.Windows.Forms.Button m_btTrocarCor;
			internal System.Windows.Forms.GroupBox m_gbUtilitarios;
			public System.Windows.Forms.Button m_btPreferencias;
			public System.Windows.Forms.Button m_btRelatorioIndefinido;
			public System.Windows.Forms.Button m_btContratosCambio;
			public System.Windows.Forms.Button m_btAtualizar;
			internal System.Windows.Forms.GroupBox m_gbDocumentos;
			public System.Windows.Forms.Button m_btDataBase;
			public System.Windows.Forms.Button m_btPrestadorServicoCadastros;
			public System.Windows.Forms.Button m_btExportadorCadastros;
			internal System.Windows.Forms.Button m_btExportadorProcessos;
			public System.Windows.Forms.Button m_btExportadorCotacoes;
		internal System.Windows.Forms.GroupBox m_gbPrestadorServico;
		internal System.Windows.Forms.GroupBox m_gbExportador;
		private System.Windows.Forms.Timer m_tTimer;
		private System.Windows.Forms.GroupBox m_gbPeControle;
		public System.Windows.Forms.Button m_btOutrosExportarDocumento;
		private System.Windows.Forms.ImageList m_ilIcons;
		public System.Windows.Forms.Button m_btSiscoEstatistico;
		public System.Windows.Forms.Button m_btPesquisarClassificacaoTarifaria;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool VisibilidadeFaturaProforma
			{
				set
				{
					m_btFaturaProforma.Visible = value;
				}
			}
		#endregion
		#region Constructor and Desctructors
		public frmMdiSiscobras(string strEnderecoExecutavel)
		{
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMdiSiscobras));
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_btTrocarConta = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btAtualizar = new System.Windows.Forms.Button();
			this.m_btPreferencias = new System.Windows.Forms.Button();
			this.m_btBordero = new System.Windows.Forms.Button();
			this.m_btInstrucaoEmbarque = new System.Windows.Forms.Button();
			this.m_btFaturaProforma = new System.Windows.Forms.Button();
			this.m_btRomaneio = new System.Windows.Forms.Button();
			this.m_btSaque = new System.Windows.Forms.Button();
			this.m_btFaturaComercial = new System.Windows.Forms.Button();
			this.m_btCertificadoOrigens = new System.Windows.Forms.Button();
			this.m_btSumario = new System.Windows.Forms.Button();
			this.m_btRelatorioIndefinido = new System.Windows.Forms.Button();
			this.m_btContratosCambio = new System.Windows.Forms.Button();
			this.m_btDataBase = new System.Windows.Forms.Button();
			this.m_btPrestadorServicoCadastros = new System.Windows.Forms.Button();
			this.m_btExportadorCadastros = new System.Windows.Forms.Button();
			this.m_btExportadorProcessos = new System.Windows.Forms.Button();
			this.m_btExportadorCotacoes = new System.Windows.Forms.Button();
			this.m_btOutrosExportarDocumento = new System.Windows.Forms.Button();
			this.m_btSiscoEstatistico = new System.Windows.Forms.Button();
			this.m_ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.m_btPesquisarClassificacaoTarifaria = new System.Windows.Forms.Button();
			this.m_pnEsquerda = new System.Windows.Forms.GroupBox();
			this.m_gbPrestadorServico = new System.Windows.Forms.GroupBox();
			this.m_gbUtilitarios = new System.Windows.Forms.GroupBox();
			this.m_gbDocumentos = new System.Windows.Forms.GroupBox();
			this.m_gbPeControle = new System.Windows.Forms.GroupBox();
			this.m_gbPe = new System.Windows.Forms.GroupBox();
			this.m_gbExportador = new System.Windows.Forms.GroupBox();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_tTimer = new System.Windows.Forms.Timer(this.components);
			this.m_pnEsquerda.SuspendLayout();
			this.m_gbPrestadorServico.SuspendLayout();
			this.m_gbUtilitarios.SuspendLayout();
			this.m_gbDocumentos.SuspendLayout();
			this.m_gbPeControle.SuspendLayout();
			this.m_gbPe.SuspendLayout();
			this.m_gbExportador.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btTrocarConta
			// 
			this.m_btTrocarConta.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarConta.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.m_btTrocarConta.Image = ((System.Drawing.Image)(resources.GetObject("m_btTrocarConta.Image")));
			this.m_btTrocarConta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btTrocarConta.Location = new System.Drawing.Point(7, 15);
			this.m_btTrocarConta.Name = "m_btTrocarConta";
			this.m_btTrocarConta.Size = new System.Drawing.Size(50, 25);
			this.m_btTrocarConta.TabIndex = 58;
			this.m_btTrocarConta.TabStop = false;
			this.m_btTrocarConta.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.m_ttDica.SetToolTip(this.m_btTrocarConta, "Exportadores");
			this.m_btTrocarConta.Click += new System.EventHandler(this.m_btTrocarConta_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btTrocarCor.Location = new System.Drawing.Point(2, 8);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 53;
			this.m_ttDica.SetToolTip(this.m_btTrocarCor, "Troca a cor primária do sistema");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btAtualizar
			// 
			this.m_btAtualizar.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btAtualizar.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btAtualizar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("m_btAtualizar.Image")));
			this.m_btAtualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btAtualizar.Location = new System.Drawing.Point(33, 59);
			this.m_btAtualizar.Name = "m_btAtualizar";
			this.m_btAtualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btAtualizar.Size = new System.Drawing.Size(25, 25);
			this.m_btAtualizar.TabIndex = 33;
			this.m_btAtualizar.TabStop = false;
			this.m_btAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btAtualizar, "Atualiza Sistema");
			this.m_btAtualizar.Click += new System.EventHandler(this.m_btAtualizar_Click);
			// 
			// m_btPreferencias
			// 
			this.m_btPreferencias.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btPreferencias.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPreferencias.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btPreferencias.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btPreferencias.Image = ((System.Drawing.Image)(resources.GetObject("m_btPreferencias.Image")));
			this.m_btPreferencias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btPreferencias.Location = new System.Drawing.Point(33, 35);
			this.m_btPreferencias.Name = "m_btPreferencias";
			this.m_btPreferencias.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btPreferencias.Size = new System.Drawing.Size(25, 25);
			this.m_btPreferencias.TabIndex = 31;
			this.m_btPreferencias.TabStop = false;
			this.m_btPreferencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btPreferencias, "Preferências");
			this.m_btPreferencias.Click += new System.EventHandler(this.m_btPreferencias_Click);
			// 
			// m_btBordero
			// 
			this.m_btBordero.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btBordero.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btBordero.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btBordero.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btBordero.Image = ((System.Drawing.Image)(resources.GetObject("m_btBordero.Image")));
			this.m_btBordero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btBordero.Location = new System.Drawing.Point(29, 90);
			this.m_btBordero.Name = "m_btBordero";
			this.m_btBordero.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btBordero.Size = new System.Drawing.Size(25, 25);
			this.m_btBordero.TabIndex = 36;
			this.m_btBordero.TabStop = false;
			this.m_btBordero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btBordero, "Borderô");
			this.m_btBordero.Click += new System.EventHandler(this.m_btBordero_Click);
			// 
			// m_btInstrucaoEmbarque
			// 
			this.m_btInstrucaoEmbarque.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btInstrucaoEmbarque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInstrucaoEmbarque.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btInstrucaoEmbarque.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btInstrucaoEmbarque.Image = ((System.Drawing.Image)(resources.GetObject("m_btInstrucaoEmbarque.Image")));
			this.m_btInstrucaoEmbarque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btInstrucaoEmbarque.Location = new System.Drawing.Point(4, 90);
			this.m_btInstrucaoEmbarque.Name = "m_btInstrucaoEmbarque";
			this.m_btInstrucaoEmbarque.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btInstrucaoEmbarque.Size = new System.Drawing.Size(25, 25);
			this.m_btInstrucaoEmbarque.TabIndex = 34;
			this.m_btInstrucaoEmbarque.TabStop = false;
			this.m_btInstrucaoEmbarque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btInstrucaoEmbarque, "Instruções de Embarque");
			this.m_btInstrucaoEmbarque.Click += new System.EventHandler(this.m_btInstrucaoEmbarque_Click);
			// 
			// m_btFaturaProforma
			// 
			this.m_btFaturaProforma.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btFaturaProforma.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFaturaProforma.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btFaturaProforma.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFaturaProforma.Image = ((System.Drawing.Image)(resources.GetObject("m_btFaturaProforma.Image")));
			this.m_btFaturaProforma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btFaturaProforma.Location = new System.Drawing.Point(4, 15);
			this.m_btFaturaProforma.Name = "m_btFaturaProforma";
			this.m_btFaturaProforma.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFaturaProforma.Size = new System.Drawing.Size(25, 25);
			this.m_btFaturaProforma.TabIndex = 33;
			this.m_btFaturaProforma.TabStop = false;
			this.m_btFaturaProforma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btFaturaProforma, "Fatura Proforma");
			this.m_btFaturaProforma.Click += new System.EventHandler(this.m_btFaturaProforma_Click);
			// 
			// m_btRomaneio
			// 
			this.m_btRomaneio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btRomaneio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRomaneio.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btRomaneio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRomaneio.Image = ((System.Drawing.Image)(resources.GetObject("m_btRomaneio.Image")));
			this.m_btRomaneio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btRomaneio.Location = new System.Drawing.Point(4, 65);
			this.m_btRomaneio.Name = "m_btRomaneio";
			this.m_btRomaneio.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRomaneio.Size = new System.Drawing.Size(25, 25);
			this.m_btRomaneio.TabIndex = 31;
			this.m_btRomaneio.TabStop = false;
			this.m_btRomaneio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btRomaneio, "Romaneio / Packing List");
			this.m_btRomaneio.Click += new System.EventHandler(this.m_btRomaneio_Click);
			// 
			// m_btSaque
			// 
			this.m_btSaque.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btSaque.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSaque.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btSaque.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSaque.Image = ((System.Drawing.Image)(resources.GetObject("m_btSaque.Image")));
			this.m_btSaque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btSaque.Location = new System.Drawing.Point(28, 65);
			this.m_btSaque.Name = "m_btSaque";
			this.m_btSaque.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSaque.Size = new System.Drawing.Size(25, 25);
			this.m_btSaque.TabIndex = 28;
			this.m_btSaque.TabStop = false;
			this.m_btSaque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btSaque, "Saque");
			this.m_btSaque.Click += new System.EventHandler(this.m_btSaque_Click);
			// 
			// m_btFaturaComercial
			// 
			this.m_btFaturaComercial.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btFaturaComercial.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btFaturaComercial.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btFaturaComercial.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btFaturaComercial.Image = ((System.Drawing.Image)(resources.GetObject("m_btFaturaComercial.Image")));
			this.m_btFaturaComercial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btFaturaComercial.Location = new System.Drawing.Point(4, 40);
			this.m_btFaturaComercial.Name = "m_btFaturaComercial";
			this.m_btFaturaComercial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btFaturaComercial.Size = new System.Drawing.Size(25, 25);
			this.m_btFaturaComercial.TabIndex = 30;
			this.m_btFaturaComercial.TabStop = false;
			this.m_btFaturaComercial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btFaturaComercial, "Fatura Comercial");
			this.m_btFaturaComercial.Click += new System.EventHandler(this.m_btFaturaComercial_Click);
			// 
			// m_btCertificadoOrigens
			// 
			this.m_btCertificadoOrigens.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btCertificadoOrigens.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCertificadoOrigens.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btCertificadoOrigens.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCertificadoOrigens.Image = ((System.Drawing.Image)(resources.GetObject("m_btCertificadoOrigens.Image")));
			this.m_btCertificadoOrigens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btCertificadoOrigens.Location = new System.Drawing.Point(29, 39);
			this.m_btCertificadoOrigens.Name = "m_btCertificadoOrigens";
			this.m_btCertificadoOrigens.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCertificadoOrigens.Size = new System.Drawing.Size(25, 25);
			this.m_btCertificadoOrigens.TabIndex = 29;
			this.m_btCertificadoOrigens.TabStop = false;
			this.m_btCertificadoOrigens.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btCertificadoOrigens, "Certificado de Origem");
			this.m_btCertificadoOrigens.Click += new System.EventHandler(this.m_btCertificadoOrigens_Click);
			// 
			// m_btSumario
			// 
			this.m_btSumario.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btSumario.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSumario.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btSumario.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSumario.Image = ((System.Drawing.Image)(resources.GetObject("m_btSumario.Image")));
			this.m_btSumario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btSumario.Location = new System.Drawing.Point(4, 115);
			this.m_btSumario.Name = "m_btSumario";
			this.m_btSumario.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSumario.Size = new System.Drawing.Size(25, 25);
			this.m_btSumario.TabIndex = 35;
			this.m_btSumario.TabStop = false;
			this.m_btSumario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btSumario, "Sumário ");
			this.m_btSumario.Click += new System.EventHandler(this.m_btSumario_Click);
			// 
			// m_btRelatorioIndefinido
			// 
			this.m_btRelatorioIndefinido.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btRelatorioIndefinido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRelatorioIndefinido.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btRelatorioIndefinido.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRelatorioIndefinido.Image = ((System.Drawing.Image)(resources.GetObject("m_btRelatorioIndefinido.Image")));
			this.m_btRelatorioIndefinido.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btRelatorioIndefinido.Location = new System.Drawing.Point(29, 115);
			this.m_btRelatorioIndefinido.Name = "m_btRelatorioIndefinido";
			this.m_btRelatorioIndefinido.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRelatorioIndefinido.Size = new System.Drawing.Size(25, 25);
			this.m_btRelatorioIndefinido.TabIndex = 37;
			this.m_btRelatorioIndefinido.TabStop = false;
			this.m_btRelatorioIndefinido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btRelatorioIndefinido, "Personalizáveis");
			this.m_btRelatorioIndefinido.Click += new System.EventHandler(this.m_btRelatorioIndefinido_Click);
			// 
			// m_btContratosCambio
			// 
			this.m_btContratosCambio.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btContratosCambio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContratosCambio.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btContratosCambio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContratosCambio.Image = ((System.Drawing.Image)(resources.GetObject("m_btContratosCambio.Image")));
			this.m_btContratosCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btContratosCambio.Location = new System.Drawing.Point(33, 15);
			this.m_btContratosCambio.Name = "m_btContratosCambio";
			this.m_btContratosCambio.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContratosCambio.Size = new System.Drawing.Size(25, 25);
			this.m_btContratosCambio.TabIndex = 20;
			this.m_btContratosCambio.TabStop = false;
			this.m_btContratosCambio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btContratosCambio, "Contratos de Câmbio");
			this.m_btContratosCambio.Click += new System.EventHandler(this.m_btContratosCambio_Click);
			// 
			// m_btDataBase
			// 
			this.m_btDataBase.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDataBase.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDataBase.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDataBase.Image = ((System.Drawing.Image)(resources.GetObject("m_btDataBase.Image")));
			this.m_btDataBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btDataBase.Location = new System.Drawing.Point(6, 59);
			this.m_btDataBase.Name = "m_btDataBase";
			this.m_btDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDataBase.Size = new System.Drawing.Size(25, 25);
			this.m_btDataBase.TabIndex = 34;
			this.m_btDataBase.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btDataBase, "Banco de Dados");
			this.m_btDataBase.Click += new System.EventHandler(this.m_btDataBase_Click);
			// 
			// m_btPrestadorServicoCadastros
			// 
			this.m_btPrestadorServicoCadastros.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btPrestadorServicoCadastros.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPrestadorServicoCadastros.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btPrestadorServicoCadastros.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btPrestadorServicoCadastros.Image = ((System.Drawing.Image)(resources.GetObject("m_btPrestadorServicoCadastros.Image")));
			this.m_btPrestadorServicoCadastros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btPrestadorServicoCadastros.Location = new System.Drawing.Point(7, 41);
			this.m_btPrestadorServicoCadastros.Name = "m_btPrestadorServicoCadastros";
			this.m_btPrestadorServicoCadastros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btPrestadorServicoCadastros.Size = new System.Drawing.Size(25, 25);
			this.m_btPrestadorServicoCadastros.TabIndex = 60;
			this.m_btPrestadorServicoCadastros.TabStop = false;
			this.m_btPrestadorServicoCadastros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btPrestadorServicoCadastros, "Cadastro");
			this.m_btPrestadorServicoCadastros.Click += new System.EventHandler(this.m_btPrestadorServicoCadastros_Click);
			// 
			// m_btExportadorCadastros
			// 
			this.m_btExportadorCadastros.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btExportadorCadastros.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExportadorCadastros.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btExportadorCadastros.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExportadorCadastros.Image = ((System.Drawing.Image)(resources.GetObject("m_btExportadorCadastros.Image")));
			this.m_btExportadorCadastros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btExportadorCadastros.Location = new System.Drawing.Point(7, 15);
			this.m_btExportadorCadastros.Name = "m_btExportadorCadastros";
			this.m_btExportadorCadastros.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExportadorCadastros.Size = new System.Drawing.Size(25, 25);
			this.m_btExportadorCadastros.TabIndex = 21;
			this.m_btExportadorCadastros.TabStop = false;
			this.m_btExportadorCadastros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btExportadorCadastros, "Cadastro");
			this.m_btExportadorCadastros.Click += new System.EventHandler(this.m_btExportadorCadastros_Click);
			// 
			// m_btExportadorProcessos
			// 
			this.m_btExportadorProcessos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExportadorProcessos.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.m_btExportadorProcessos.Image = ((System.Drawing.Image)(resources.GetObject("m_btExportadorProcessos.Image")));
			this.m_btExportadorProcessos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btExportadorProcessos.Location = new System.Drawing.Point(33, 41);
			this.m_btExportadorProcessos.Name = "m_btExportadorProcessos";
			this.m_btExportadorProcessos.Size = new System.Drawing.Size(25, 25);
			this.m_btExportadorProcessos.TabIndex = 60;
			this.m_btExportadorProcessos.TabStop = false;
			this.m_btExportadorProcessos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_ttDica.SetToolTip(this.m_btExportadorProcessos, "PE");
			this.m_btExportadorProcessos.Visible = false;
			this.m_btExportadorProcessos.Click += new System.EventHandler(this.m_btExportadorProcessos_Click);
			// 
			// m_btExportadorCotacoes
			// 
			this.m_btExportadorCotacoes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btExportadorCotacoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExportadorCotacoes.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btExportadorCotacoes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExportadorCotacoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btExportadorCotacoes.Image")));
			this.m_btExportadorCotacoes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btExportadorCotacoes.Location = new System.Drawing.Point(7, 41);
			this.m_btExportadorCotacoes.Name = "m_btExportadorCotacoes";
			this.m_btExportadorCotacoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExportadorCotacoes.Size = new System.Drawing.Size(25, 25);
			this.m_btExportadorCotacoes.TabIndex = 61;
			this.m_btExportadorCotacoes.TabStop = false;
			this.m_btExportadorCotacoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btExportadorCotacoes, "Cotações");
			this.m_btExportadorCotacoes.Visible = false;
			this.m_btExportadorCotacoes.Click += new System.EventHandler(this.m_btExportadorCotacoes_Click);
			// 
			// m_btOutrosExportarDocumento
			// 
			this.m_btOutrosExportarDocumento.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btOutrosExportarDocumento.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOutrosExportarDocumento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOutrosExportarDocumento.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOutrosExportarDocumento.Image = ((System.Drawing.Image)(resources.GetObject("m_btOutrosExportarDocumento.Image")));
			this.m_btOutrosExportarDocumento.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.m_btOutrosExportarDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btOutrosExportarDocumento.Location = new System.Drawing.Point(4, 11);
			this.m_btOutrosExportarDocumento.Name = "m_btOutrosExportarDocumento";
			this.m_btOutrosExportarDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOutrosExportarDocumento.Size = new System.Drawing.Size(25, 25);
			this.m_btOutrosExportarDocumento.TabIndex = 34;
			this.m_btOutrosExportarDocumento.TabStop = false;
			this.m_ttDica.SetToolTip(this.m_btOutrosExportarDocumento, "Exportar Documentos");
			this.m_btOutrosExportarDocumento.Click += new System.EventHandler(this.m_btOutrosExportarDocumento_Click);
			// 
			// m_btSiscoEstatistico
			// 
			this.m_btSiscoEstatistico.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btSiscoEstatistico.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSiscoEstatistico.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btSiscoEstatistico.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSiscoEstatistico.Image = ((System.Drawing.Image)(resources.GetObject("m_btSiscoEstatistico.Image")));
			this.m_btSiscoEstatistico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btSiscoEstatistico.Location = new System.Drawing.Point(6, 10);
			this.m_btSiscoEstatistico.Name = "m_btSiscoEstatistico";
			this.m_btSiscoEstatistico.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSiscoEstatistico.Size = new System.Drawing.Size(25, 25);
			this.m_btSiscoEstatistico.TabIndex = 35;
			this.m_btSiscoEstatistico.TabStop = false;
			this.m_btSiscoEstatistico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDica.SetToolTip(this.m_btSiscoEstatistico, "Gerenciador Estatístico");
			this.m_btSiscoEstatistico.Click += new System.EventHandler(this.m_btSiscoEstatistico_Click);
			// 
			// m_ilIcons
			// 
			this.m_ilIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilIcons.ImageStream")));
			this.m_ilIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btPesquisarClassificacaoTarifaria
			// 
			this.m_btPesquisarClassificacaoTarifaria.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_btPesquisarClassificacaoTarifaria.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPesquisarClassificacaoTarifaria.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btPesquisarClassificacaoTarifaria.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btPesquisarClassificacaoTarifaria.Image = ((System.Drawing.Image)(resources.GetObject("m_btPesquisarClassificacaoTarifaria.Image")));
			this.m_btPesquisarClassificacaoTarifaria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btPesquisarClassificacaoTarifaria.Location = new System.Drawing.Point(33, 10);
			this.m_btPesquisarClassificacaoTarifaria.Name = "m_btPesquisarClassificacaoTarifaria";
			this.m_btPesquisarClassificacaoTarifaria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btPesquisarClassificacaoTarifaria.Size = new System.Drawing.Size(25, 25);
			this.m_btPesquisarClassificacaoTarifaria.TabIndex = 36;
			this.m_btPesquisarClassificacaoTarifaria.TabStop = false;
			this.m_btPesquisarClassificacaoTarifaria.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.m_ttDica.SetToolTip(this.m_btPesquisarClassificacaoTarifaria, "Pesquisar Classificação Tarifária");
			this.m_btPesquisarClassificacaoTarifaria.Click += new System.EventHandler(this.m_btPesquisarClassificacaoTarifaria_Click);
			// 
			// m_pnEsquerda
			// 
			this.m_pnEsquerda.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_pnEsquerda.Controls.Add(this.m_gbPrestadorServico);
			this.m_pnEsquerda.Controls.Add(this.m_gbUtilitarios);
			this.m_pnEsquerda.Controls.Add(this.m_gbDocumentos);
			this.m_pnEsquerda.Controls.Add(this.m_gbExportador);
			this.m_pnEsquerda.Font = new System.Drawing.Font("Arial", 8.25F);
			this.m_pnEsquerda.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_pnEsquerda.Location = new System.Drawing.Point(0, 0);
			this.m_pnEsquerda.Name = "m_pnEsquerda";
			this.m_pnEsquerda.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_pnEsquerda.Size = new System.Drawing.Size(70, 536);
			this.m_pnEsquerda.TabIndex = 9;
			this.m_pnEsquerda.TabStop = false;
			// 
			// m_gbPrestadorServico
			// 
			this.m_gbPrestadorServico.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_gbPrestadorServico.Controls.Add(this.m_btPrestadorServicoCadastros);
			this.m_gbPrestadorServico.Controls.Add(this.m_btTrocarConta);
			this.m_gbPrestadorServico.Controls.Add(this.m_btTrocarCor);
			this.m_gbPrestadorServico.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPrestadorServico.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_gbPrestadorServico.Location = new System.Drawing.Point(3, 7);
			this.m_gbPrestadorServico.Name = "m_gbPrestadorServico";
			this.m_gbPrestadorServico.Size = new System.Drawing.Size(64, 73);
			this.m_gbPrestadorServico.TabIndex = 55;
			this.m_gbPrestadorServico.TabStop = false;
			this.m_gbPrestadorServico.Text = "Prestador";
			// 
			// m_gbUtilitarios
			// 
			this.m_gbUtilitarios.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_gbUtilitarios.Controls.Add(this.m_btPreferencias);
			this.m_gbUtilitarios.Controls.Add(this.m_btPesquisarClassificacaoTarifaria);
			this.m_gbUtilitarios.Controls.Add(this.m_btSiscoEstatistico);
			this.m_gbUtilitarios.Controls.Add(this.m_btDataBase);
			this.m_gbUtilitarios.Controls.Add(this.m_btAtualizar);
			this.m_gbUtilitarios.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.m_gbUtilitarios.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_gbUtilitarios.Location = new System.Drawing.Point(3, 439);
			this.m_gbUtilitarios.Name = "m_gbUtilitarios";
			this.m_gbUtilitarios.Size = new System.Drawing.Size(64, 90);
			this.m_gbUtilitarios.TabIndex = 54;
			this.m_gbUtilitarios.TabStop = false;
			// 
			// m_gbDocumentos
			// 
			this.m_gbDocumentos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_gbDocumentos.Controls.Add(this.m_gbPeControle);
			this.m_gbDocumentos.Controls.Add(this.m_gbPe);
			this.m_gbDocumentos.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDocumentos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_gbDocumentos.Location = new System.Drawing.Point(4, 151);
			this.m_gbDocumentos.Name = "m_gbDocumentos";
			this.m_gbDocumentos.Size = new System.Drawing.Size(64, 203);
			this.m_gbDocumentos.TabIndex = 53;
			this.m_gbDocumentos.TabStop = false;
			this.m_gbDocumentos.Text = "PE";
			this.m_gbDocumentos.Visible = false;
			// 
			// m_gbPeControle
			// 
			this.m_gbPeControle.Controls.Add(this.m_btOutrosExportarDocumento);
			this.m_gbPeControle.Location = new System.Drawing.Point(3, 158);
			this.m_gbPeControle.Name = "m_gbPeControle";
			this.m_gbPeControle.Size = new System.Drawing.Size(58, 42);
			this.m_gbPeControle.TabIndex = 52;
			this.m_gbPeControle.TabStop = false;
			this.m_gbPeControle.Text = "Outros";
			// 
			// m_gbPe
			// 
			this.m_gbPe.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_gbPe.Controls.Add(this.m_btRelatorioIndefinido);
			this.m_gbPe.Controls.Add(this.m_btBordero);
			this.m_gbPe.Controls.Add(this.m_btInstrucaoEmbarque);
			this.m_gbPe.Controls.Add(this.m_btFaturaProforma);
			this.m_gbPe.Controls.Add(this.m_btRomaneio);
			this.m_gbPe.Controls.Add(this.m_btSaque);
			this.m_gbPe.Controls.Add(this.m_btFaturaComercial);
			this.m_gbPe.Controls.Add(this.m_btCertificadoOrigens);
			this.m_gbPe.Controls.Add(this.m_btSumario);
			this.m_gbPe.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPe.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_gbPe.Location = new System.Drawing.Point(3, 12);
			this.m_gbPe.Name = "m_gbPe";
			this.m_gbPe.Size = new System.Drawing.Size(58, 145);
			this.m_gbPe.TabIndex = 51;
			this.m_gbPe.TabStop = false;
			this.m_gbPe.Text = "Docs";
			// 
			// m_gbExportador
			// 
			this.m_gbExportador.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_gbExportador.Controls.Add(this.m_btExportadorCotacoes);
			this.m_gbExportador.Controls.Add(this.m_btExportadorProcessos);
			this.m_gbExportador.Controls.Add(this.m_btExportadorCadastros);
			this.m_gbExportador.Controls.Add(this.m_btContratosCambio);
			this.m_gbExportador.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbExportador.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_gbExportador.Location = new System.Drawing.Point(2, 79);
			this.m_gbExportador.Name = "m_gbExportador";
			this.m_gbExportador.Size = new System.Drawing.Size(64, 73);
			this.m_gbExportador.TabIndex = 49;
			this.m_gbExportador.TabStop = false;
			this.m_gbExportador.Text = "Exportador";
			this.m_gbExportador.Visible = false;
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_tTimer
			// 
			this.m_tTimer.Enabled = true;
			this.m_tTimer.Interval = 2000;
			this.m_tTimer.Tick += new System.EventHandler(this.m_tTimer_Tick);
			// 
			// frmMdiSiscobras
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(850, 536);
			this.Controls.Add(this.m_pnEsquerda);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MaximizeBox = false;
			this.Name = "frmMdiSiscobras";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Siscobras";
			this.Load += new System.EventHandler(this.frmMdiSiscobras_Load);
			this.m_pnEsquerda.ResumeLayout(false);
			this.m_gbPrestadorServico.ResumeLayout(false);
			this.m_gbUtilitarios.ResumeLayout(false);
			this.m_gbDocumentos.ResumeLayout(false);
			this.m_gbPeControle.ResumeLayout(false);
			this.m_gbPe.ResumeLayout(false);
			this.m_gbExportador.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmMdiSiscobras_Load(object sender, System.EventArgs e)
				{
					ResizeForm();	
					vMostraCor();
					OnCallShowStart();
				}
			#endregion
			#region Timer
				private void m_tTimer_Tick(object sender, System.EventArgs e)
				{
					m_tTimer.Enabled = false;
					OnCallShowDialogPreferencesNeeded();
				}
			#endregion
			#region Botoes
				#region Menu Vertical
					#region Prestador de Servico
						private void m_btTrocarCor_Click(object sender, System.EventArgs e)
						{
							TrocaCor();
						}

						private void m_btTrocarConta_Click(object sender, System.EventArgs e)
						{
							OnCallShowContas();
						}

						private void m_btPrestadorServicoCadastros_Click(object sender, System.EventArgs e)
						{
							OnCallShowPrestadorServicoCadastros();
						}
					#endregion
					#region Exportador (Conta)
						private void m_btExportadorCadastros_Click(object sender, System.EventArgs e)
						{
							OnCallShowExportadorCadastros();
						}

						private void m_btContratosCambio_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogContratosCambio();
						}

						private void m_btExportadorCotacoes_Click(object sender, System.EventArgs e)
						{
							OnCallShowCotacoes();
						}

						private void m_btExportadorProcessos_Click(object sender, System.EventArgs e)
						{
							OnCallShowBibliotecas();
						}
					#endregion
					#region PE
						private void m_btSumario_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogSumario();
						}

						private void m_btFaturaProforma_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogFaturaProforma();
						}

						private void m_btFaturaComercial_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogFaturaComercial();
						}

						private void m_btCertificadoOrigens_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogCertificadoOrigem();
						}

						private void m_btRomaneio_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogRomaneio();						
						}

						private void m_btSaque_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogSaque();						
						}

						private void m_btInstrucaoEmbarque_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogInstrucaoEmbarque();						
						}

						private void m_btBordero_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogBordero();												
						}

						private void m_btRelatorioIndefinido_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogRelatorioIndefinido();
						}
					#endregion
					#region Outros
						private void m_btOutrosExportarDocumento_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogExportacaoDocumentos();
						}
					#endregion
					#region Configuracoes
						private void m_btSiscoEstatistico_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogSiscoEstatistico();
						}

						private void m_btPesquisarClassificacaoTarifaria_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogPesquisarClassificacaoTarifaria();
						}

						private void m_btPreferencias_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogPreferencias();
						}

						private void m_btDataBase_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogBancoDados();
						}

						private void m_btAtualizar_Click(object sender, System.EventArgs e)
						{
							OnCallShowDialogAtualizacao();
						}
					#endregion
				#endregion
			#endregion
		#endregion

		#region Métodos
			#region Resize
			private void ResizeForm()
			{
				//---------------------------------------------------------------------------------------------------------
				// Resizing da Tela 
				this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width;
				this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height;
				//---------------------------------------------------------------------------------------------------------
				//Ajustando Caixas 
				//---------------------------------------------------------------------------------------------------------
				this.m_pnEsquerda.Size = new System.Drawing.Size(this.m_pnEsquerda.Size.Width, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - 34);
				//---------------------------------------------------------------------------------------------------------
				this.m_gbUtilitarios.Location = new System.Drawing.Point(this.m_gbUtilitarios.Location.X, this.m_pnEsquerda.Size.Height - (this.m_gbUtilitarios.Size.Height + 5));
				//---------------------------------------------------------------------------------------------------------
			}
		#endregion
			#region Cores
				private void TrocaCor()
				{
					mdlPaletaDeCores.clsPaletaDeCores cls_pal_PaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresPrimarias");
					cls_pal_PaletaCores.mostraCorAtual();
					vMostraCor();
				}

				public void vMostraCor()
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresPrimarias");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					System.Windows.Forms.Control ctrControleChild;
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						ctrControleChild = this.Controls[nCont];
						vPaintControl(ref ctrControleChild,this.BackColor);
					}
					vMostraCorRelatorios();
				}

				public void vMostraCorRelatorios()
				{
					// Fatura Comercial 
					if (OnCallExisteFaturaComercial())
						m_btFaturaComercial.BackColor = this.BackColor; 
					else
						m_btFaturaComercial.BackColor = m_clrDocumentoInexistente;

					// Certificado Origem
					if (OnCallExisteCertificadoOrigem())
						m_btCertificadoOrigens.BackColor = this.BackColor; 
					else
						m_btCertificadoOrigens.BackColor = m_clrDocumentoInexistente;

					// Romaneio
					if (OnCallExisteRomaneio())
						m_btRomaneio.BackColor = this.BackColor; 
					else
						m_btRomaneio.BackColor = m_clrDocumentoInexistente;

					// Saque
					if (OnCallExisteSaque()) 
						m_btSaque.BackColor = this.BackColor; 
					else
						m_btSaque.BackColor = m_clrDocumentoInexistente;

					// Instrucao Embarque
					if (OnCallExisteInstrucaoEmbarque()) 
						m_btInstrucaoEmbarque.BackColor = this.BackColor; 
					else
						m_btInstrucaoEmbarque.BackColor = m_clrDocumentoInexistente;
						
					// Bordero
					if (OnCallExisteBordero()) 
						m_btBordero.BackColor = this.BackColor; 
					else
						m_btBordero.BackColor = m_clrDocumentoInexistente;
					
					// Sumario
					if (OnCallExisteSumario()) 
						m_btSumario.BackColor = this.BackColor; 
					else
						m_btSumario.BackColor = m_clrDocumentoInexistente;
				}

				private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
				{
					bool bExit = false;
					switch(ctrControle.GetType().ToString())
					{
						case "mdlComponentesGraficos.ListView":
						case "mdlComponentesGraficos.ComboBox":
						case "mdlComponentesGraficos.TextBox":
							break;
						default:
							if (bIsFormDescendent(ref ctrControle))
							{
								bExit = true;
							}else{
								ctrControle.BackColor = clrBackColor;
							}
							break;
					}
					if (!bExit)
					{
						System.Windows.Forms.Control ctrControleChild;
						for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
						{
							ctrControleChild = ctrControle.Controls[nCont];
							vPaintControl(ref ctrControleChild,clrBackColor);
						}
					}
				}

				private bool bIsFormDescendent(ref System.Windows.Forms.Control ctrControle)
				{
					bool bRetorno = false;
					try
					{
						System.Windows.Forms.Form form = (System.Windows.Forms.Form)ctrControle;
						bRetorno = true;
					}catch{
						bRetorno = false;
					}
					return(bRetorno);
				}
			#endregion
			#region Mode
				public void vSetModeExportador()
				{
					m_gbPrestadorServico.Visible = false;
					m_gbExportador.Top = m_gbPrestadorServico.Top;
					m_gbDocumentos.Top = m_gbExportador.Top + m_gbExportador.Height + 2;
				}

				public void vSetModePrestadorServico()
				{
				}
			#endregion
		#endregion
	}
}
