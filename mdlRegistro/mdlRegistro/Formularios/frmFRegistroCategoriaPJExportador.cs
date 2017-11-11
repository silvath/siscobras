using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRegistroCategoriaPJExportador.
	/// </summary>
	internal class frmFRegistroCategoriaPJExportador : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallRefreshEstados(ref mdlComponentesGraficos.ComboBox cbEstados);
			public delegate void delCallCarregaDados(out string strRazaoSocial,out string strNomeFantasia,out string strCNPJ,out string strLogradouro,out string strComplemento,out string strBairro,out string strCidade,out int nEstado,out string strCEP,out string strTelefone,out string strTelefoneDDD,out string strFax,out string strFaxDDD,out string strEmail, out string strSite,out string m_strSetorAtividade,out int m_nQuantidadeExportacoesAnuais,out int m_nQuantidadeFuncionarios,out int m_nExportaQuantosAnos ,out bool m_bRealizaImportacao);
			public delegate void delCallSalvaDados(string strRazaoSocial,string strNomeFantasia,string strCNPJ,string strLogradouro,string strComplemento,string strBairro,string strCidade,int nEstado,string strCEP,string strTelefone,string strTelefoneDDD,string strFax,string strFaxDDD,string strEmail,string strSite,string m_strSetorAtividade,int m_nQuantidadeExportacoesAnuais,int m_nQuantidadeFuncionarios,int m_nExportaQuantosAnos ,bool m_bRealizaImportacao);
		#endregion
		#region Events
			public event delCallRefreshEstados eCallRefreshEstados;

			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallRefreshEstados()
			{
				if (eCallRefreshEstados != null)
				{
					eCallRefreshEstados(ref m_cbEstado);
				}
			}

			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					eCallCarregaDados(out m_strRazaoSocial,out m_strNomeFantasia,out m_strCNPJ,out m_strLogradouro,out m_strComplemento,out m_strBairro,out m_strCidade,out m_nEstado,out m_strCEP,out m_strTelefone,out m_strTelefoneDDD,out m_strFax,out m_strFaxDDD,out m_strEmail,out m_strSite,out m_strSetorAtividade,out m_nQuantidadeExportacoesAnuais,out m_nQuantidadeFuncionarios,out m_nExportaQuantosAnos ,out m_bRealizaImportacao);
				}
			}

			protected virtual void OnCallSalvaDados()
			{
				if (eCallSalvaDados != null)
				{
					eCallSalvaDados(m_strRazaoSocial,m_strNomeFantasia,m_strCNPJ,m_strLogradouro,m_strComplemento,m_strBairro,m_strCidade,m_nEstado,m_strCEP,m_strTelefone,m_strTelefoneDDD,m_strFax,m_strFaxDDD,m_strEmail,m_strSite,m_strSetorAtividade,m_nQuantidadeExportacoesAnuais,m_nQuantidadeFuncionarios,m_nExportaQuantosAnos ,m_bRealizaImportacao);
				}
			}
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			// Dados
			string m_strRazaoSocial = "";
			string m_strNomeFantasia = "";
			string m_strCNPJ = "";
			string m_strLogradouro = "";
			string m_strComplemento = "";
			string m_strBairro = "";
			string m_strCidade = "";
			int m_nEstado = 0;
			string m_strCEP = "";
			string m_strTelefone = "";
			string m_strTelefoneDDD = "";
			string m_strFax = "";
			string m_strFaxDDD = "";
			string m_strEmail = ""; 
			string m_strSite = "";
			string m_strSetorAtividade = "";
			int m_nQuantidadeExportacoesAnuais = 0;
		    int m_nQuantidadeFuncionarios = 0;
			int m_nExportaQuantosAnos = 0;
			bool m_bRealizaImportacao = false;
        
			internal mdlRegistro.Resposta m_enumResposta = mdlRegistro.Resposta.Cancelar;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btContinuar;
			internal System.Windows.Forms.Button m_btVoltar;
			private System.Windows.Forms.Label m_lbRazaoSocial;
			private mdlComponentesGraficos.TextBox m_txtRazaoSocial;
			public System.Windows.Forms.Label m_lbCNPJ;
			public System.Windows.Forms.Label m_lbCidade;
			public System.Windows.Forms.Label m_lbCep;
			public System.Windows.Forms.Label m_lbEstado;
			public System.Windows.Forms.Label m_lbFax;
			public System.Windows.Forms.Label m_lbBairro;
			public System.Windows.Forms.Label m_lbSite;
			private System.Windows.Forms.GroupBox m_gbIdentificacao;
			private System.Windows.Forms.GroupBox m_gbMeioComunicação;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.Windows.Forms.GroupBox m_gbEspecificos;
			private System.Windows.Forms.Label m_lbNomeFantasia;
			public System.Windows.Forms.Label m_lbInfoCamposObrigatorios;
			private mdlComponentesGraficos.TextBox m_txtNumeroEmpregados;
			private mdlComponentesGraficos.TextBox m_txtVolumeExportacao;
			public System.Windows.Forms.Label m_lbEmpregados;
			public System.Windows.Forms.Label m_lbArea;
			public System.Windows.Forms.Label m_lbVolume;
			private mdlComponentesGraficos.TextBox m_txtSite;
			private mdlComponentesGraficos.TextBox m_txtEmail;
			private mdlComponentesGraficos.TextBox m_txtFax;
			private mdlComponentesGraficos.TextBox m_txtTelefone;
			public System.Windows.Forms.Label m_lbEmail;
			public System.Windows.Forms.Label m_lbTelefone;
			private System.Windows.Forms.GroupBox m_gbEndereço;
			public System.Windows.Forms.Label m_lbLogradouro;
			private mdlComponentesGraficos.TextBox m_txtLogradouro;
			private mdlComponentesGraficos.TextBox m_txtBairro;
			private mdlComponentesGraficos.TextBox m_txtCidade;
			private mdlComponentesGraficos.ComboBox m_cbEstado;
			private mdlComponentesGraficos.TextBox m_txtCep;
			private mdlComponentesGraficos.TextBox m_txtNomeFantasia;
			private mdlComponentesGraficos.TextBox m_txtCNPJ;
			private System.Windows.Forms.CheckBox m_ckImportacao;
			public System.Windows.Forms.Label m_lbTexto;
			private mdlComponentesGraficos.TextBox m_txtComplemento;
			public System.Windows.Forms.Label m_lbComplemento;
		private mdlComponentesGraficos.TextBox m_txtExportaQuantosAnos;
		public System.Windows.Forms.Label m_lbTexto2;
		private mdlComponentesGraficos.TextBox m_txtArea;
		private mdlComponentesGraficos.TextBox m_txtTelefoneDDD;
		private mdlComponentesGraficos.TextBox m_txtFaxDDD;
		public System.Windows.Forms.Label m_lbTelefoneParDireito;
		public System.Windows.Forms.Label m_lbTelefoneParEsquerdo;
		public System.Windows.Forms.Label m_lbFaxParDireito;
		public System.Windows.Forms.Label m_lbFaxParEsquerdo;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
		public frmFRegistroCategoriaPJExportador(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
		{
			m_cls_ter_TratadorErro = cls_ter_TratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistroCategoriaPJExportador));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_lbInfoCamposObrigatorios = new System.Windows.Forms.Label();
			this.m_gbEspecificos = new System.Windows.Forms.GroupBox();
			this.m_txtArea = new mdlComponentesGraficos.TextBox();
			this.m_lbTexto2 = new System.Windows.Forms.Label();
			this.m_lbTexto = new System.Windows.Forms.Label();
			this.m_ckImportacao = new System.Windows.Forms.CheckBox();
			this.m_txtExportaQuantosAnos = new mdlComponentesGraficos.TextBox();
			this.m_txtNumeroEmpregados = new mdlComponentesGraficos.TextBox();
			this.m_txtVolumeExportacao = new mdlComponentesGraficos.TextBox();
			this.m_lbEmpregados = new System.Windows.Forms.Label();
			this.m_lbArea = new System.Windows.Forms.Label();
			this.m_lbVolume = new System.Windows.Forms.Label();
			this.m_gbMeioComunicação = new System.Windows.Forms.GroupBox();
			this.m_txtFaxDDD = new mdlComponentesGraficos.TextBox();
			this.m_lbFaxParEsquerdo = new System.Windows.Forms.Label();
			this.m_lbTelefoneParEsquerdo = new System.Windows.Forms.Label();
			this.m_txtFax = new mdlComponentesGraficos.TextBox();
			this.m_lbFaxParDireito = new System.Windows.Forms.Label();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_txtTelefoneDDD = new mdlComponentesGraficos.TextBox();
			this.m_lbTelefoneParDireito = new System.Windows.Forms.Label();
			this.m_txtSite = new mdlComponentesGraficos.TextBox();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_lbEmail = new System.Windows.Forms.Label();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_lbFax = new System.Windows.Forms.Label();
			this.m_lbSite = new System.Windows.Forms.Label();
			this.m_gbEndereço = new System.Windows.Forms.GroupBox();
			this.m_lbComplemento = new System.Windows.Forms.Label();
			this.m_txtComplemento = new mdlComponentesGraficos.TextBox();
			this.m_lbLogradouro = new System.Windows.Forms.Label();
			this.m_txtLogradouro = new mdlComponentesGraficos.TextBox();
			this.m_txtBairro = new mdlComponentesGraficos.TextBox();
			this.m_lbBairro = new System.Windows.Forms.Label();
			this.m_txtCidade = new mdlComponentesGraficos.TextBox();
			this.m_lbEstado = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_lbCep = new System.Windows.Forms.Label();
			this.m_txtCep = new mdlComponentesGraficos.TextBox();
			this.m_lbCidade = new System.Windows.Forms.Label();
			this.m_gbIdentificacao = new System.Windows.Forms.GroupBox();
			this.m_txtRazaoSocial = new mdlComponentesGraficos.TextBox();
			this.m_txtNomeFantasia = new mdlComponentesGraficos.TextBox();
			this.m_lbNomeFantasia = new System.Windows.Forms.Label();
			this.m_txtCNPJ = new mdlComponentesGraficos.TextBox();
			this.m_lbCNPJ = new System.Windows.Forms.Label();
			this.m_lbRazaoSocial = new System.Windows.Forms.Label();
			this.m_btVoltar = new System.Windows.Forms.Button();
			this.m_btContinuar = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbEspecificos.SuspendLayout();
			this.m_gbMeioComunicação.SuspendLayout();
			this.m_gbEndereço.SuspendLayout();
			this.m_gbIdentificacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_lbInfoCamposObrigatorios);
			this.m_gbGeral.Controls.Add(this.m_gbEspecificos);
			this.m_gbGeral.Controls.Add(this.m_gbMeioComunicação);
			this.m_gbGeral.Controls.Add(this.m_gbEndereço);
			this.m_gbGeral.Controls.Add(this.m_gbIdentificacao);
			this.m_gbGeral.Controls.Add(this.m_btVoltar);
			this.m_gbGeral.Controls.Add(this.m_btContinuar);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(428, 415);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_lbInfoCamposObrigatorios
			// 
			this.m_lbInfoCamposObrigatorios.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbInfoCamposObrigatorios.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbInfoCamposObrigatorios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.Location = new System.Drawing.Point(88, 360);
			this.m_lbInfoCamposObrigatorios.Name = "m_lbInfoCamposObrigatorios";
			this.m_lbInfoCamposObrigatorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbInfoCamposObrigatorios.Size = new System.Drawing.Size(256, 16);
			this.m_lbInfoCamposObrigatorios.TabIndex = 52;
			this.m_lbInfoCamposObrigatorios.Text = "Obs.: Campos em vermelho são obrigatórios.";
			// 
			// m_gbEspecificos
			// 
			this.m_gbEspecificos.Controls.Add(this.m_txtArea);
			this.m_gbEspecificos.Controls.Add(this.m_lbTexto2);
			this.m_gbEspecificos.Controls.Add(this.m_lbTexto);
			this.m_gbEspecificos.Controls.Add(this.m_ckImportacao);
			this.m_gbEspecificos.Controls.Add(this.m_txtExportaQuantosAnos);
			this.m_gbEspecificos.Controls.Add(this.m_txtNumeroEmpregados);
			this.m_gbEspecificos.Controls.Add(this.m_txtVolumeExportacao);
			this.m_gbEspecificos.Controls.Add(this.m_lbEmpregados);
			this.m_gbEspecificos.Controls.Add(this.m_lbArea);
			this.m_gbEspecificos.Controls.Add(this.m_lbVolume);
			this.m_gbEspecificos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbEspecificos.Location = new System.Drawing.Point(5, 273);
			this.m_gbEspecificos.Name = "m_gbEspecificos";
			this.m_gbEspecificos.Size = new System.Drawing.Size(409, 84);
			this.m_gbEspecificos.TabIndex = 3;
			this.m_gbEspecificos.TabStop = false;
			this.m_gbEspecificos.Text = "Empresa";
			// 
			// m_txtArea
			// 
			this.m_txtArea.Location = new System.Drawing.Point(120, 13);
			this.m_txtArea.Name = "m_txtArea";
			this.m_txtArea.Size = new System.Drawing.Size(280, 20);
			this.m_txtArea.TabIndex = 0;
			this.m_txtArea.Text = "";
			// 
			// m_lbTexto2
			// 
			this.m_lbTexto2.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTexto2.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTexto2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTexto2.ForeColor = System.Drawing.Color.Black;
			this.m_lbTexto2.Location = new System.Drawing.Point(129, 60);
			this.m_lbTexto2.Name = "m_lbTexto2";
			this.m_lbTexto2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTexto2.Size = new System.Drawing.Size(40, 16);
			this.m_lbTexto2.TabIndex = 54;
			this.m_lbTexto2.Text = "anos.";
			// 
			// m_lbTexto
			// 
			this.m_lbTexto.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTexto.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTexto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTexto.ForeColor = System.Drawing.Color.Black;
			this.m_lbTexto.Location = new System.Drawing.Point(5, 60);
			this.m_lbTexto.Name = "m_lbTexto";
			this.m_lbTexto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTexto.Size = new System.Drawing.Size(83, 16);
			this.m_lbTexto.TabIndex = 53;
			this.m_lbTexto.Text = "Exportamos a ";
			// 
			// m_ckImportacao
			// 
			this.m_ckImportacao.Location = new System.Drawing.Point(239, 62);
			this.m_ckImportacao.Name = "m_ckImportacao";
			this.m_ckImportacao.Size = new System.Drawing.Size(168, 16);
			this.m_ckImportacao.TabIndex = 4;
			this.m_ckImportacao.Text = "Realizamos importações.";
			// 
			// m_txtExportaQuantosAnos
			// 
			this.m_txtExportaQuantosAnos.Location = new System.Drawing.Point(89, 57);
			this.m_txtExportaQuantosAnos.Name = "m_txtExportaQuantosAnos";
			this.m_txtExportaQuantosAnos.OnlyNumbers = true;
			this.m_txtExportaQuantosAnos.Size = new System.Drawing.Size(32, 20);
			this.m_txtExportaQuantosAnos.TabIndex = 3;
			this.m_txtExportaQuantosAnos.Text = "";
			this.m_txtExportaQuantosAnos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtNumeroEmpregados
			// 
			this.m_txtNumeroEmpregados.Location = new System.Drawing.Point(120, 37);
			this.m_txtNumeroEmpregados.Name = "m_txtNumeroEmpregados";
			this.m_txtNumeroEmpregados.OnlyNumbers = true;
			this.m_txtNumeroEmpregados.Size = new System.Drawing.Size(64, 20);
			this.m_txtNumeroEmpregados.TabIndex = 1;
			this.m_txtNumeroEmpregados.Text = "";
			// 
			// m_txtVolumeExportacao
			// 
			this.m_txtVolumeExportacao.Location = new System.Drawing.Point(336, 36);
			this.m_txtVolumeExportacao.Name = "m_txtVolumeExportacao";
			this.m_txtVolumeExportacao.OnlyNumbers = true;
			this.m_txtVolumeExportacao.Size = new System.Drawing.Size(64, 20);
			this.m_txtVolumeExportacao.TabIndex = 2;
			this.m_txtVolumeExportacao.Text = "";
			// 
			// m_lbEmpregados
			// 
			this.m_lbEmpregados.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbEmpregados.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbEmpregados.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEmpregados.ForeColor = System.Drawing.Color.Black;
			this.m_lbEmpregados.Location = new System.Drawing.Point(5, 38);
			this.m_lbEmpregados.Name = "m_lbEmpregados";
			this.m_lbEmpregados.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbEmpregados.Size = new System.Drawing.Size(105, 16);
			this.m_lbEmpregados.TabIndex = 36;
			this.m_lbEmpregados.Text = "Qtde funcionários:";
			// 
			// m_lbArea
			// 
			this.m_lbArea.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbArea.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbArea.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbArea.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbArea.Location = new System.Drawing.Point(4, 19);
			this.m_lbArea.Name = "m_lbArea";
			this.m_lbArea.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbArea.Size = new System.Drawing.Size(116, 16);
			this.m_lbArea.TabIndex = 35;
			this.m_lbArea.Text = "Setor de Atividade:";
			// 
			// m_lbVolume
			// 
			this.m_lbVolume.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbVolume.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbVolume.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbVolume.ForeColor = System.Drawing.Color.Black;
			this.m_lbVolume.Location = new System.Drawing.Point(186, 40);
			this.m_lbVolume.Name = "m_lbVolume";
			this.m_lbVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbVolume.Size = new System.Drawing.Size(150, 16);
			this.m_lbVolume.TabIndex = 34;
			this.m_lbVolume.Text = "Qtde Exportações anuais:";
			// 
			// m_gbMeioComunicação
			// 
			this.m_gbMeioComunicação.Controls.Add(this.m_txtFaxDDD);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFaxParEsquerdo);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParEsquerdo);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtFax);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFaxParDireito);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefone);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefoneDDD);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParDireito);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtSite);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtEmail);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbEmail);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefone);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFax);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbSite);
			this.m_gbMeioComunicação.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMeioComunicação.Location = new System.Drawing.Point(5, 181);
			this.m_gbMeioComunicação.Name = "m_gbMeioComunicação";
			this.m_gbMeioComunicação.Size = new System.Drawing.Size(409, 91);
			this.m_gbMeioComunicação.TabIndex = 2;
			this.m_gbMeioComunicação.TabStop = false;
			this.m_gbMeioComunicação.Text = "Meio de Comunicação";
			// 
			// m_txtFaxDDD
			// 
			this.m_txtFaxDDD.Location = new System.Drawing.Point(254, 16);
			this.m_txtFaxDDD.Name = "m_txtFaxDDD";
			this.m_txtFaxDDD.Size = new System.Drawing.Size(25, 20);
			this.m_txtFaxDDD.TabIndex = 2;
			this.m_txtFaxDDD.Text = "";
			// 
			// m_lbFaxParEsquerdo
			// 
			this.m_lbFaxParEsquerdo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFaxParEsquerdo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFaxParEsquerdo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFaxParEsquerdo.ForeColor = System.Drawing.Color.Black;
			this.m_lbFaxParEsquerdo.Location = new System.Drawing.Point(246, 16);
			this.m_lbFaxParEsquerdo.Name = "m_lbFaxParEsquerdo";
			this.m_lbFaxParEsquerdo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFaxParEsquerdo.Size = new System.Drawing.Size(12, 16);
			this.m_lbFaxParEsquerdo.TabIndex = 42;
			this.m_lbFaxParEsquerdo.Text = "(";
			// 
			// m_lbTelefoneParEsquerdo
			// 
			this.m_lbTelefoneParEsquerdo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefoneParEsquerdo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefoneParEsquerdo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefoneParEsquerdo.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefoneParEsquerdo.Location = new System.Drawing.Point(97, 16);
			this.m_lbTelefoneParEsquerdo.Name = "m_lbTelefoneParEsquerdo";
			this.m_lbTelefoneParEsquerdo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParEsquerdo.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParEsquerdo.TabIndex = 1;
			this.m_lbTelefoneParEsquerdo.Text = "(";
			// 
			// m_txtFax
			// 
			this.m_txtFax.Location = new System.Drawing.Point(288, 15);
			this.m_txtFax.Name = "m_txtFax";
			this.m_txtFax.Size = new System.Drawing.Size(112, 20);
			this.m_txtFax.TabIndex = 3;
			this.m_txtFax.Text = "";
			// 
			// m_lbFaxParDireito
			// 
			this.m_lbFaxParDireito.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFaxParDireito.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFaxParDireito.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFaxParDireito.ForeColor = System.Drawing.Color.Black;
			this.m_lbFaxParDireito.Location = new System.Drawing.Point(278, 16);
			this.m_lbFaxParDireito.Name = "m_lbFaxParDireito";
			this.m_lbFaxParDireito.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFaxParDireito.Size = new System.Drawing.Size(12, 16);
			this.m_lbFaxParDireito.TabIndex = 40;
			this.m_lbFaxParDireito.Text = ")";
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Location = new System.Drawing.Point(136, 16);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(80, 20);
			this.m_txtTelefone.TabIndex = 1;
			this.m_txtTelefone.Text = "";
			// 
			// m_txtTelefoneDDD
			// 
			this.m_txtTelefoneDDD.Location = new System.Drawing.Point(104, 16);
			this.m_txtTelefoneDDD.Name = "m_txtTelefoneDDD";
			this.m_txtTelefoneDDD.Size = new System.Drawing.Size(25, 20);
			this.m_txtTelefoneDDD.TabIndex = 0;
			this.m_txtTelefoneDDD.Text = "";
			// 
			// m_lbTelefoneParDireito
			// 
			this.m_lbTelefoneParDireito.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefoneParDireito.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefoneParDireito.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefoneParDireito.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefoneParDireito.Location = new System.Drawing.Point(128, 16);
			this.m_lbTelefoneParDireito.Name = "m_lbTelefoneParDireito";
			this.m_lbTelefoneParDireito.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParDireito.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParDireito.TabIndex = 38;
			this.m_lbTelefoneParDireito.Text = ") ";
			// 
			// m_txtSite
			// 
			this.m_txtSite.Location = new System.Drawing.Point(104, 61);
			this.m_txtSite.Name = "m_txtSite";
			this.m_txtSite.Size = new System.Drawing.Size(296, 20);
			this.m_txtSite.TabIndex = 5;
			this.m_txtSite.Text = "";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Location = new System.Drawing.Point(104, 38);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(296, 20);
			this.m_txtEmail.TabIndex = 4;
			this.m_txtEmail.Text = "";
			// 
			// m_lbEmail
			// 
			this.m_lbEmail.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbEmail.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEmail.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbEmail.Location = new System.Drawing.Point(13, 39);
			this.m_lbEmail.Name = "m_lbEmail";
			this.m_lbEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbEmail.Size = new System.Drawing.Size(40, 16);
			this.m_lbEmail.TabIndex = 36;
			this.m_lbEmail.Text = "Email:";
			// 
			// m_lbTelefone
			// 
			this.m_lbTelefone.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefone.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefone.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTelefone.Location = new System.Drawing.Point(11, 19);
			this.m_lbTelefone.Name = "m_lbTelefone";
			this.m_lbTelefone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefone.Size = new System.Drawing.Size(61, 16);
			this.m_lbTelefone.TabIndex = 35;
			this.m_lbTelefone.Text = "Telefone:";
			// 
			// m_lbFax
			// 
			this.m_lbFax.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFax.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFax.ForeColor = System.Drawing.Color.Black;
			this.m_lbFax.Location = new System.Drawing.Point(222, 19);
			this.m_lbFax.Name = "m_lbFax";
			this.m_lbFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFax.Size = new System.Drawing.Size(33, 16);
			this.m_lbFax.TabIndex = 34;
			this.m_lbFax.Text = "Fax:";
			// 
			// m_lbSite
			// 
			this.m_lbSite.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbSite.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSite.ForeColor = System.Drawing.Color.Black;
			this.m_lbSite.Location = new System.Drawing.Point(14, 61);
			this.m_lbSite.Name = "m_lbSite";
			this.m_lbSite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbSite.Size = new System.Drawing.Size(32, 16);
			this.m_lbSite.TabIndex = 31;
			this.m_lbSite.Text = "Site:";
			// 
			// m_gbEndereço
			// 
			this.m_gbEndereço.Controls.Add(this.m_lbComplemento);
			this.m_gbEndereço.Controls.Add(this.m_txtComplemento);
			this.m_gbEndereço.Controls.Add(this.m_lbLogradouro);
			this.m_gbEndereço.Controls.Add(this.m_txtLogradouro);
			this.m_gbEndereço.Controls.Add(this.m_txtBairro);
			this.m_gbEndereço.Controls.Add(this.m_lbBairro);
			this.m_gbEndereço.Controls.Add(this.m_txtCidade);
			this.m_gbEndereço.Controls.Add(this.m_lbEstado);
			this.m_gbEndereço.Controls.Add(this.m_cbEstado);
			this.m_gbEndereço.Controls.Add(this.m_lbCep);
			this.m_gbEndereço.Controls.Add(this.m_txtCep);
			this.m_gbEndereço.Controls.Add(this.m_lbCidade);
			this.m_gbEndereço.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbEndereço.Location = new System.Drawing.Point(6, 71);
			this.m_gbEndereço.Name = "m_gbEndereço";
			this.m_gbEndereço.Size = new System.Drawing.Size(408, 105);
			this.m_gbEndereço.TabIndex = 1;
			this.m_gbEndereço.TabStop = false;
			this.m_gbEndereço.Text = "Endereço";
			// 
			// m_lbComplemento
			// 
			this.m_lbComplemento.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbComplemento.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbComplemento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbComplemento.ForeColor = System.Drawing.Color.Black;
			this.m_lbComplemento.Location = new System.Drawing.Point(8, 44);
			this.m_lbComplemento.Name = "m_lbComplemento";
			this.m_lbComplemento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbComplemento.Size = new System.Drawing.Size(84, 16);
			this.m_lbComplemento.TabIndex = 48;
			this.m_lbComplemento.Text = "Complemento:";
			// 
			// m_txtComplemento
			// 
			this.m_txtComplemento.Location = new System.Drawing.Point(104, 38);
			this.m_txtComplemento.Name = "m_txtComplemento";
			this.m_txtComplemento.Size = new System.Drawing.Size(296, 20);
			this.m_txtComplemento.TabIndex = 1;
			this.m_txtComplemento.Text = "";
			// 
			// m_lbLogradouro
			// 
			this.m_lbLogradouro.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbLogradouro.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbLogradouro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLogradouro.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbLogradouro.Location = new System.Drawing.Point(8, 21);
			this.m_lbLogradouro.Name = "m_lbLogradouro";
			this.m_lbLogradouro.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbLogradouro.Size = new System.Drawing.Size(84, 16);
			this.m_lbLogradouro.TabIndex = 37;
			this.m_lbLogradouro.Text = "Logradouro:";
			// 
			// m_txtLogradouro
			// 
			this.m_txtLogradouro.Location = new System.Drawing.Point(104, 16);
			this.m_txtLogradouro.Name = "m_txtLogradouro";
			this.m_txtLogradouro.Size = new System.Drawing.Size(296, 20);
			this.m_txtLogradouro.TabIndex = 0;
			this.m_txtLogradouro.Text = "";
			// 
			// m_txtBairro
			// 
			this.m_txtBairro.Location = new System.Drawing.Point(104, 58);
			this.m_txtBairro.Name = "m_txtBairro";
			this.m_txtBairro.Size = new System.Drawing.Size(112, 20);
			this.m_txtBairro.TabIndex = 2;
			this.m_txtBairro.Text = "";
			// 
			// m_lbBairro
			// 
			this.m_lbBairro.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbBairro.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbBairro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbBairro.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbBairro.Location = new System.Drawing.Point(11, 63);
			this.m_lbBairro.Name = "m_lbBairro";
			this.m_lbBairro.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbBairro.Size = new System.Drawing.Size(47, 16);
			this.m_lbBairro.TabIndex = 33;
			this.m_lbBairro.Text = "Bairro:";
			// 
			// m_txtCidade
			// 
			this.m_txtCidade.Location = new System.Drawing.Point(279, 59);
			this.m_txtCidade.Name = "m_txtCidade";
			this.m_txtCidade.Size = new System.Drawing.Size(120, 20);
			this.m_txtCidade.TabIndex = 3;
			this.m_txtCidade.Text = "";
			// 
			// m_lbEstado
			// 
			this.m_lbEstado.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbEstado.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEstado.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbEstado.Location = new System.Drawing.Point(11, 82);
			this.m_lbEstado.Name = "m_lbEstado";
			this.m_lbEstado.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbEstado.Size = new System.Drawing.Size(52, 16);
			this.m_lbEstado.TabIndex = 36;
			this.m_lbEstado.Text = "Estado:";
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.Location = new System.Drawing.Point(104, 79);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(48, 22);
			this.m_cbEstado.TabIndex = 4;
			// 
			// m_lbCep
			// 
			this.m_lbCep.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCep.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCep.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCep.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCep.Location = new System.Drawing.Point(221, 86);
			this.m_lbCep.Name = "m_lbCep";
			this.m_lbCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCep.Size = new System.Drawing.Size(48, 17);
			this.m_lbCep.TabIndex = 38;
			this.m_lbCep.Text = "CEP:";
			// 
			// m_txtCep
			// 
			this.m_txtCep.Location = new System.Drawing.Point(279, 81);
			this.m_txtCep.Mask = true;
			this.m_txtCep.MaskAutomaticSpecialCharacters = true;
			this.m_txtCep.MaskText = "NNNNN-NNN";
			this.m_txtCep.Name = "m_txtCep";
			this.m_txtCep.Size = new System.Drawing.Size(120, 20);
			this.m_txtCep.TabIndex = 5;
			this.m_txtCep.Text = "";
			// 
			// m_lbCidade
			// 
			this.m_lbCidade.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCidade.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCidade.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCidade.Location = new System.Drawing.Point(220, 62);
			this.m_lbCidade.Name = "m_lbCidade";
			this.m_lbCidade.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCidade.Size = new System.Drawing.Size(56, 17);
			this.m_lbCidade.TabIndex = 39;
			this.m_lbCidade.Text = "Cidade:";
			// 
			// m_gbIdentificacao
			// 
			this.m_gbIdentificacao.Controls.Add(this.m_txtRazaoSocial);
			this.m_gbIdentificacao.Controls.Add(this.m_txtNomeFantasia);
			this.m_gbIdentificacao.Controls.Add(this.m_lbNomeFantasia);
			this.m_gbIdentificacao.Controls.Add(this.m_txtCNPJ);
			this.m_gbIdentificacao.Controls.Add(this.m_lbCNPJ);
			this.m_gbIdentificacao.Controls.Add(this.m_lbRazaoSocial);
			this.m_gbIdentificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIdentificacao.Location = new System.Drawing.Point(6, 8);
			this.m_gbIdentificacao.Name = "m_gbIdentificacao";
			this.m_gbIdentificacao.Size = new System.Drawing.Size(408, 64);
			this.m_gbIdentificacao.TabIndex = 0;
			this.m_gbIdentificacao.TabStop = false;
			this.m_gbIdentificacao.Text = "Identificação";
			// 
			// m_txtRazaoSocial
			// 
			this.m_txtRazaoSocial.Location = new System.Drawing.Point(104, 14);
			this.m_txtRazaoSocial.Name = "m_txtRazaoSocial";
			this.m_txtRazaoSocial.Size = new System.Drawing.Size(296, 20);
			this.m_txtRazaoSocial.TabIndex = 0;
			this.m_txtRazaoSocial.Text = "";
			this.m_ttDica.SetToolTip(this.m_txtRazaoSocial, "Razão Social de sua empresa.");
			// 
			// m_txtNomeFantasia
			// 
			this.m_txtNomeFantasia.Location = new System.Drawing.Point(104, 37);
			this.m_txtNomeFantasia.Name = "m_txtNomeFantasia";
			this.m_txtNomeFantasia.Size = new System.Drawing.Size(112, 20);
			this.m_txtNomeFantasia.TabIndex = 1;
			this.m_txtNomeFantasia.Text = "";
			this.m_ttDica.SetToolTip(this.m_txtNomeFantasia, "Nome Fantasia de sua empresa.");
			// 
			// m_lbNomeFantasia
			// 
			this.m_lbNomeFantasia.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbNomeFantasia.Location = new System.Drawing.Point(4, 37);
			this.m_lbNomeFantasia.Name = "m_lbNomeFantasia";
			this.m_lbNomeFantasia.Size = new System.Drawing.Size(96, 16);
			this.m_lbNomeFantasia.TabIndex = 17;
			this.m_lbNomeFantasia.Text = "Nome Fantasia:";
			this.m_ttDica.SetToolTip(this.m_lbNomeFantasia, "Nome Fantasia de sua empresa.");
			// 
			// m_txtCNPJ
			// 
			this.m_txtCNPJ.Location = new System.Drawing.Point(280, 37);
			this.m_txtCNPJ.Mask = true;
			this.m_txtCNPJ.MaskAutomaticSpecialCharacters = true;
			this.m_txtCNPJ.MaskText = "NN.NNN.NNN/NNNN-NN";
			this.m_txtCNPJ.Name = "m_txtCNPJ";
			this.m_txtCNPJ.Size = new System.Drawing.Size(120, 20);
			this.m_txtCNPJ.TabIndex = 2;
			this.m_txtCNPJ.Text = "";
			this.m_ttDica.SetToolTip(this.m_txtCNPJ, "CNPJ de sua empresa.");
			// 
			// m_lbCNPJ
			// 
			this.m_lbCNPJ.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCNPJ.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCNPJ.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCNPJ.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCNPJ.Location = new System.Drawing.Point(219, 40);
			this.m_lbCNPJ.Name = "m_lbCNPJ";
			this.m_lbCNPJ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCNPJ.Size = new System.Drawing.Size(56, 17);
			this.m_lbCNPJ.TabIndex = 40;
			this.m_lbCNPJ.Text = "CNPJ :";
			this.m_ttDica.SetToolTip(this.m_lbCNPJ, "CNPJ de sua empresa.");
			// 
			// m_lbRazaoSocial
			// 
			this.m_lbRazaoSocial.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbRazaoSocial.Location = new System.Drawing.Point(5, 18);
			this.m_lbRazaoSocial.Name = "m_lbRazaoSocial";
			this.m_lbRazaoSocial.Size = new System.Drawing.Size(80, 16);
			this.m_lbRazaoSocial.TabIndex = 15;
			this.m_lbRazaoSocial.Text = "Razão Social:";
			this.m_ttDica.SetToolTip(this.m_lbRazaoSocial, "Razão Social de sua empresa.");
			// 
			// m_btVoltar
			// 
			this.m_btVoltar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVoltar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVoltar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVoltar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVoltar.Image")));
			this.m_btVoltar.Location = new System.Drawing.Point(119, 376);
			this.m_btVoltar.Name = "m_btVoltar";
			this.m_btVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVoltar.Size = new System.Drawing.Size(57, 25);
			this.m_btVoltar.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btVoltar, "Voltar");
			this.m_btVoltar.Click += new System.EventHandler(this.m_btVoltar_Click);
			// 
			// m_btContinuar
			// 
			this.m_btContinuar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContinuar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContinuar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContinuar.Image = ((System.Drawing.Image)(resources.GetObject("m_btContinuar.Image")));
			this.m_btContinuar.Location = new System.Drawing.Point(247, 376);
			this.m_btContinuar.Name = "m_btContinuar";
			this.m_btContinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContinuar.Size = new System.Drawing.Size(57, 25);
			this.m_btContinuar.TabIndex = 4;
			this.m_ttDica.SetToolTip(this.m_btContinuar, "Continuar");
			this.m_btContinuar.Click += new System.EventHandler(this.m_btContinuar_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(183, 376);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFRegistroCategoriaPJExportador
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 424);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistroCategoriaPJExportador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pessoa Jurídica: Exportador";
			this.Load += new System.EventHandler(this.frmFRegistroCategoriaPJExportador_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbEspecificos.ResumeLayout(false);
			this.m_gbMeioComunicação.ResumeLayout(false);
			this.m_gbEndereço.ResumeLayout(false);
			this.m_gbIdentificacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dos Dados Interface
			private void vCarregaDadosInterface()
			{
				m_txtRazaoSocial.Text = m_strRazaoSocial;
				m_txtNomeFantasia.Text = m_strNomeFantasia;
				m_txtCNPJ.Text = m_strCNPJ;
				m_txtLogradouro.Text = m_strLogradouro;
				m_txtComplemento.Text = m_strComplemento;
				m_txtBairro.Text = m_strBairro;
				m_txtCidade.Text = m_strCidade;
				m_cbEstado.SelectItem(m_nEstado);
				m_txtCep.Text = m_strCEP;
				m_txtTelefone.Text = m_strTelefone;
				m_txtTelefoneDDD.Text = m_strTelefoneDDD;
				m_txtFax.Text = m_strFax;
				m_txtFaxDDD.Text = m_strFaxDDD;
				m_txtEmail.Text = m_strEmail;
				m_txtSite.Text = m_strSite;
				m_txtArea.Text = m_strSetorAtividade;
				m_txtVolumeExportacao.Text = m_nQuantidadeExportacoesAnuais.ToString();
				m_txtNumeroEmpregados.Text = m_nQuantidadeFuncionarios.ToString();
				m_txtExportaQuantosAnos.Text = m_nExportaQuantosAnos.ToString();
				m_ckImportacao.Checked = m_bRealizaImportacao;
			}
		#endregion
		#region Salvamento dos Dados da Interface
			private bool bSalvaDadosInterface()
			{
				// Razao Social
				if (m_txtRazaoSocial.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPJExportador_InformarRazaoSocial));
					return(false);
				}else{
					m_strRazaoSocial = m_txtRazaoSocial.Text.Trim();
				}

				// Nome Fantasia 
				if (m_txtNomeFantasia.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPJExportador_InformarNomeFantasia));
					return(false);
				}
				else
				{
					m_strNomeFantasia = m_txtNomeFantasia.Text.Trim();
				}

				// CNPJ
				if (m_txtCNPJ.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPJExportador_InformarCNPJ));
					return(false);
				}
				else
				{
					m_strCNPJ = m_txtCNPJ.Text.Trim();
				}

				// CNPJ Corretamente 
				if (m_strCNPJ != "")
				{
					if (!mdlValidacao.clsCNPJ.validaCNPJ(m_strCNPJ))
					{
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPJExportador_IncorretoCNPJ));
						return(false);
					}
				}

				// Logradouro
				if (m_txtLogradouro.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarLogradouro));
					return(false);
				}
				else
				{
					m_strLogradouro = m_txtLogradouro.Text.Trim();
				}

				// Complemento
				m_strComplemento = m_txtComplemento.Text.Trim();

				// Bairro
				if (m_txtBairro.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarBairro));
					return(false);
				}
				else
				{
					m_strBairro = m_txtBairro.Text.Trim();
				}

				// Cidade 
				if (m_txtCidade.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCidade));
					return(false);
				}
				else
				{
					m_strCidade = m_txtCidade.Text.Trim();
				}

				// Estado
				object obj = m_cbEstado.ReturnObjectSelectedItem();
				if (obj == null)
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarEstado));
					return(false);
				}else{
					m_nEstado = Int32.Parse(obj.ToString());
				}

				// CEP
				if (m_txtCep.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCEP));
					return(false);
				}else{
					m_strCEP = m_txtCep.Text.Trim();
				}

				// Telefone 
				if (m_txtTelefone.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPJExportador_Telefone));
					return(false);
				}
				else
				{
					m_strTelefone = m_txtTelefone.Text.Trim();
				}

				// Telefone DDD 
				if (m_txtTelefoneDDD.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarDDDTelefone));
					return(false);
				}else{
					m_strTelefoneDDD = m_txtTelefoneDDD.Text.Trim();
				}

				// Fax
				m_strFax = m_txtFax.Text.Trim();

				// Fax DDD
				m_strFaxDDD = m_txtFaxDDD.Text.Trim();

				// Email
				if (m_txtEmail.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarEmail));
					return(false);
				}
				else
				{
					m_strEmail = m_txtEmail.Text.Trim();
				}

				// Site
				m_strSite = m_txtSite.Text.Trim();

				// Setor de Atividade
				if (m_txtArea.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaPFExportador_InformarSetorAtividade));
					return(false);
				}
				else
				{
					m_strSetorAtividade = m_txtArea.Text.Trim();
				}

				// Quantidade de Exportacoes Anuais 
				try
				{
					m_nQuantidadeExportacoesAnuais = Int32.Parse(m_txtVolumeExportacao.Text);
				}catch{
					m_nQuantidadeExportacoesAnuais = 0;
				}

				// Quantidade de Funcionarios 
				try
				{
					m_nQuantidadeFuncionarios = Int32.Parse(m_txtNumeroEmpregados.Text);
				}catch{
					m_nQuantidadeFuncionarios = 0;
				}

				// Exporta a quantos anos 
				try
				{
					m_nExportaQuantosAnos = Int32.Parse(m_txtExportaQuantosAnos.Text);
				}catch{
					m_nExportaQuantosAnos = 0;
				}

				// Realiza Importacao
				m_bRealizaImportacao = m_ckImportacao.Checked;

				return(true);
			}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRegistroCategoriaPJExportador_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDados();
					OnCallRefreshEstados();
					vCarregaDadosInterface();
				}
			#endregion
			#region Botoes
				private void m_btVoltar_Click(object sender, System.EventArgs e)
				{
                    m_enumResposta = mdlRegistro.Resposta.Voltar; 			
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_enumResposta = mdlRegistro.Resposta.Cancelar; 			
					this.Close();
				}

				private void m_btContinuar_Click(object sender, System.EventArgs e)
				{
					if (bSalvaDadosInterface())
					{
						OnCallSalvaDados();
						m_enumResposta = mdlRegistro.Resposta.Continuar; 			
						this.Close();
					}
				}
			#endregion
		#endregion
		#region Cores
			private void MostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ComboBox"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion

	}
}
