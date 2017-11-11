using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRegistroCategoriaPJExportadorUsuario.
	/// </summary>
	internal class frmFRegistroCategoriaPJExportadorUsuario : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallRefreshSexo(ref mdlComponentesGraficos.ComboBox cbSexo);
			public delegate void delCallRefreshFuncao(ref mdlComponentesGraficos.ComboBox cbFuncao);
			public delegate void delCallCarregaDados(out string strNome,out string strCPF,out bool bSexoMasculino,out System.DateTime dtDataNascimento,out int nFuncao,out string strTelefone,out string strTelefoneDDD,out string strEmail,out string strRamal ,out string strFax,out string strFaxDDD);
			public delegate void delCallSalvaDados(string strNome,string strCPF,bool bSexoMasculino, System.DateTime dtDataNascimento,int nFuncao,string strTelefone,string strTelefoneDDD,string strEmail,string strRamal ,string strFax,string strFaxDDD);
		#endregion
		#region Events
			public event delCallRefreshSexo eCallRefreshSexo;
			public event delCallRefreshFuncao eCallRefreshFuncao;
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallRefreshSexo()
			{
				if (eCallRefreshSexo != null)
				{
					eCallRefreshSexo(ref m_cbSexo);
				}
			}

			protected virtual void OnCallRefreshFuncao()
			{
				if (eCallRefreshFuncao != null)
				{
					eCallRefreshFuncao(ref m_cbFuncao);
				}
			}

			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					eCallCarregaDados(out m_strNome,out m_strCPF,out m_bSexoMasculino,out m_dtDataNascimento,out m_nFuncao,out m_strTelefone,out m_strTelefoneDDD,out m_strEmail,out m_strRamal ,out m_strFax,out m_strFaxDDD);
				}
			}

			protected virtual void OnCallSalvaDados()
			{
				if (eCallSalvaDados != null)
				{
					eCallSalvaDados(m_strNome,m_strCPF,m_bSexoMasculino,m_dtDataNascimento,m_nFuncao,m_strTelefone,m_strTelefoneDDD,m_strEmail,m_strRamal ,m_strFax,m_strFaxDDD);
				}
			}
		#endregion
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			// Dados
			private string m_strNome = "";
			private string m_strCPF = "";
			private bool m_bSexoMasculino = false;
			private System.DateTime m_dtDataNascimento = new System.DateTime(1800,1,1);
			private int m_nFuncao = 0;
			private string m_strTelefone = "";
			private string m_strTelefoneDDD = "";
			private string m_strEmail = "";
			private string m_strRamal = "";
			private string m_strFax = "";
			private string m_strFaxDDD = "";
                                
			internal mdlRegistro.Resposta m_enumResposta = mdlRegistro.Resposta.Cancelar;

			private System.Windows.Forms.GroupBox m_gbGeral;
			public System.Windows.Forms.Label m_lbInfoCamposObrigatorios;
			private System.Windows.Forms.GroupBox m_gbMeioComunicação;
			private mdlComponentesGraficos.TextBox m_txtTelefone;
			public System.Windows.Forms.Label m_lbTelefone;
			public System.Windows.Forms.Label m_lbFax;
			public System.Windows.Forms.Label m_lbSite;
			private System.Windows.Forms.GroupBox m_gbIdentificacao;
			internal System.Windows.Forms.Button m_btVoltar;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbImage;
			private System.Windows.Forms.PictureBox pictureBox1;
			private System.Windows.Forms.PictureBox m_picImagem;
			internal System.Windows.Forms.Button m_btContinuar;
			private mdlComponentesGraficos.ComboBox m_cbFuncao;
			private mdlComponentesGraficos.TextBox m_txtFax;
			private mdlComponentesGraficos.TextBox m_txtRamal;
			private mdlComponentesGraficos.TextBox m_txtEmail;
			public System.Windows.Forms.Label m_lbRamal;
			public System.Windows.Forms.Label m_lbFuncao;
			public System.Windows.Forms.Label m_lbSexo;
			private mdlComponentesGraficos.TextBox m_txtNome;
			private System.Windows.Forms.Label m_lbCpf;
			public System.Windows.Forms.Label m_lbDataNascimento;
			private System.Windows.Forms.Label m_lbNome;
			private mdlComponentesGraficos.TextBox m_txtCPF;
			private mdlComponentesGraficos.ComboBox m_cbSexo;
			private System.Windows.Forms.DateTimePicker m_dpDataNascimento;
			private System.Windows.Forms.ToolTip m_ttDica;
		public System.Windows.Forms.Label m_lbTelefoneParEsquerdo;
		private mdlComponentesGraficos.TextBox m_txtTelefoneDDD;
		public System.Windows.Forms.Label m_lbTelefoneParDireito;
		private mdlComponentesGraficos.TextBox m_txtFaxDDD;
		public System.Windows.Forms.Label m_lbFaxParEsquerdo;
		public System.Windows.Forms.Label m_lbFaxParDireito;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
		public frmFRegistroCategoriaPJExportadorUsuario(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
		{
			m_cls_ter_TratadorErro = cls_ter_TratadorErro;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistroCategoriaPJExportadorUsuario));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbImage = new System.Windows.Forms.GroupBox();
			this.m_picImagem = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_lbInfoCamposObrigatorios = new System.Windows.Forms.Label();
			this.m_gbMeioComunicação = new System.Windows.Forms.GroupBox();
			this.m_txtFaxDDD = new mdlComponentesGraficos.TextBox();
			this.m_lbFaxParEsquerdo = new System.Windows.Forms.Label();
			this.m_lbFaxParDireito = new System.Windows.Forms.Label();
			this.m_lbTelefoneParEsquerdo = new System.Windows.Forms.Label();
			this.m_txtTelefoneDDD = new mdlComponentesGraficos.TextBox();
			this.m_lbTelefoneParDireito = new System.Windows.Forms.Label();
			this.m_txtFax = new mdlComponentesGraficos.TextBox();
			this.m_txtRamal = new mdlComponentesGraficos.TextBox();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_lbRamal = new System.Windows.Forms.Label();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_lbFax = new System.Windows.Forms.Label();
			this.m_lbSite = new System.Windows.Forms.Label();
			this.m_gbIdentificacao = new System.Windows.Forms.GroupBox();
			this.m_dpDataNascimento = new System.Windows.Forms.DateTimePicker();
			this.m_cbFuncao = new mdlComponentesGraficos.ComboBox();
			this.m_lbFuncao = new System.Windows.Forms.Label();
			this.m_cbSexo = new mdlComponentesGraficos.ComboBox();
			this.m_lbSexo = new System.Windows.Forms.Label();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_txtCPF = new mdlComponentesGraficos.TextBox();
			this.m_lbCpf = new System.Windows.Forms.Label();
			this.m_lbDataNascimento = new System.Windows.Forms.Label();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_btVoltar = new System.Windows.Forms.Button();
			this.m_btContinuar = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbImage.SuspendLayout();
			this.m_gbMeioComunicação.SuspendLayout();
			this.m_gbIdentificacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbImage);
			this.m_gbGeral.Controls.Add(this.m_lbInfoCamposObrigatorios);
			this.m_gbGeral.Controls.Add(this.m_gbMeioComunicação);
			this.m_gbGeral.Controls.Add(this.m_gbIdentificacao);
			this.m_gbGeral.Controls.Add(this.m_btVoltar);
			this.m_gbGeral.Controls.Add(this.m_btContinuar);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(421, 368);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbImage
			// 
			this.m_gbImage.Controls.Add(this.m_picImagem);
			this.m_gbImage.Controls.Add(this.pictureBox1);
			this.m_gbImage.Location = new System.Drawing.Point(5, 8);
			this.m_gbImage.Name = "m_gbImage";
			this.m_gbImage.Size = new System.Drawing.Size(408, 144);
			this.m_gbImage.TabIndex = 0;
			this.m_gbImage.TabStop = false;
			// 
			// m_picImagem
			// 
			this.m_picImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagem.Image")));
			this.m_picImagem.Location = new System.Drawing.Point(7, 13);
			this.m_picImagem.Name = "m_picImagem";
			this.m_picImagem.Size = new System.Drawing.Size(393, 123);
			this.m_picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picImagem.TabIndex = 17;
			this.m_picImagem.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(392, 104);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// m_lbInfoCamposObrigatorios
			// 
			this.m_lbInfoCamposObrigatorios.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbInfoCamposObrigatorios.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbInfoCamposObrigatorios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.Location = new System.Drawing.Point(84, 315);
			this.m_lbInfoCamposObrigatorios.Name = "m_lbInfoCamposObrigatorios";
			this.m_lbInfoCamposObrigatorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbInfoCamposObrigatorios.Size = new System.Drawing.Size(256, 16);
			this.m_lbInfoCamposObrigatorios.TabIndex = 52;
			this.m_lbInfoCamposObrigatorios.Text = "Obs.: Campos em vermelho são obrigatórios.";
			// 
			// m_gbMeioComunicação
			// 
			this.m_gbMeioComunicação.Controls.Add(this.m_txtFaxDDD);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFaxParEsquerdo);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFaxParDireito);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParEsquerdo);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefoneDDD);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParDireito);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtFax);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtRamal);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtEmail);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefone);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbRamal);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefone);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbFax);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbSite);
			this.m_gbMeioComunicação.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMeioComunicação.Location = new System.Drawing.Point(6, 246);
			this.m_gbMeioComunicação.Name = "m_gbMeioComunicação";
			this.m_gbMeioComunicação.Size = new System.Drawing.Size(409, 64);
			this.m_gbMeioComunicação.TabIndex = 2;
			this.m_gbMeioComunicação.TabStop = false;
			this.m_gbMeioComunicação.Text = "Meio de Comunicação";
			// 
			// m_txtFaxDDD
			// 
			this.m_txtFaxDDD.Location = new System.Drawing.Point(239, 39);
			this.m_txtFaxDDD.Name = "m_txtFaxDDD";
			this.m_txtFaxDDD.Size = new System.Drawing.Size(25, 20);
			this.m_txtFaxDDD.TabIndex = 4;
			this.m_txtFaxDDD.Text = "";
			// 
			// m_lbFaxParEsquerdo
			// 
			this.m_lbFaxParEsquerdo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFaxParEsquerdo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFaxParEsquerdo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFaxParEsquerdo.ForeColor = System.Drawing.Color.Black;
			this.m_lbFaxParEsquerdo.Location = new System.Drawing.Point(231, 39);
			this.m_lbFaxParEsquerdo.Name = "m_lbFaxParEsquerdo";
			this.m_lbFaxParEsquerdo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFaxParEsquerdo.Size = new System.Drawing.Size(12, 16);
			this.m_lbFaxParEsquerdo.TabIndex = 50;
			this.m_lbFaxParEsquerdo.Text = "(";
			// 
			// m_lbFaxParDireito
			// 
			this.m_lbFaxParDireito.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFaxParDireito.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFaxParDireito.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFaxParDireito.ForeColor = System.Drawing.Color.Black;
			this.m_lbFaxParDireito.Location = new System.Drawing.Point(263, 39);
			this.m_lbFaxParDireito.Name = "m_lbFaxParDireito";
			this.m_lbFaxParDireito.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFaxParDireito.Size = new System.Drawing.Size(12, 16);
			this.m_lbFaxParDireito.TabIndex = 49;
			this.m_lbFaxParDireito.Text = ")";
			// 
			// m_lbTelefoneParEsquerdo
			// 
			this.m_lbTelefoneParEsquerdo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefoneParEsquerdo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefoneParEsquerdo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefoneParEsquerdo.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefoneParEsquerdo.Location = new System.Drawing.Point(64, 16);
			this.m_lbTelefoneParEsquerdo.Name = "m_lbTelefoneParEsquerdo";
			this.m_lbTelefoneParEsquerdo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParEsquerdo.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParEsquerdo.TabIndex = 0;
			this.m_lbTelefoneParEsquerdo.Text = "(";
			// 
			// m_txtTelefoneDDD
			// 
			this.m_txtTelefoneDDD.Location = new System.Drawing.Point(72, 16);
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
			this.m_lbTelefoneParDireito.Location = new System.Drawing.Point(96, 16);
			this.m_lbTelefoneParDireito.Name = "m_lbTelefoneParDireito";
			this.m_lbTelefoneParDireito.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParDireito.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParDireito.TabIndex = 43;
			this.m_lbTelefoneParDireito.Text = ") ";
			// 
			// m_txtFax
			// 
			this.m_txtFax.Location = new System.Drawing.Point(272, 38);
			this.m_txtFax.Name = "m_txtFax";
			this.m_txtFax.Size = new System.Drawing.Size(128, 20);
			this.m_txtFax.TabIndex = 5;
			this.m_txtFax.Text = "";
			// 
			// m_txtRamal
			// 
			this.m_txtRamal.Location = new System.Drawing.Point(70, 38);
			this.m_txtRamal.Name = "m_txtRamal";
			this.m_txtRamal.Size = new System.Drawing.Size(120, 20);
			this.m_txtRamal.TabIndex = 3;
			this.m_txtRamal.Text = "";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Location = new System.Drawing.Point(240, 15);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(160, 20);
			this.m_txtEmail.TabIndex = 2;
			this.m_txtEmail.Text = "";
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Location = new System.Drawing.Point(104, 16);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(80, 20);
			this.m_txtTelefone.TabIndex = 1;
			this.m_txtTelefone.Text = "";
			// 
			// m_lbRamal
			// 
			this.m_lbRamal.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbRamal.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbRamal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbRamal.ForeColor = System.Drawing.Color.Black;
			this.m_lbRamal.Location = new System.Drawing.Point(12, 39);
			this.m_lbRamal.Name = "m_lbRamal";
			this.m_lbRamal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbRamal.Size = new System.Drawing.Size(51, 16);
			this.m_lbRamal.TabIndex = 36;
			this.m_lbRamal.Text = "Ramal:";
			// 
			// m_lbTelefone
			// 
			this.m_lbTelefone.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefone.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefone.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbTelefone.Location = new System.Drawing.Point(10, 19);
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
			this.m_lbFax.Location = new System.Drawing.Point(195, 40);
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
			this.m_lbSite.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbSite.Location = new System.Drawing.Point(195, 20);
			this.m_lbSite.Name = "m_lbSite";
			this.m_lbSite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbSite.Size = new System.Drawing.Size(48, 16);
			this.m_lbSite.TabIndex = 31;
			this.m_lbSite.Text = "E-mail:";
			// 
			// m_gbIdentificacao
			// 
			this.m_gbIdentificacao.Controls.Add(this.m_dpDataNascimento);
			this.m_gbIdentificacao.Controls.Add(this.m_cbFuncao);
			this.m_gbIdentificacao.Controls.Add(this.m_lbFuncao);
			this.m_gbIdentificacao.Controls.Add(this.m_cbSexo);
			this.m_gbIdentificacao.Controls.Add(this.m_lbSexo);
			this.m_gbIdentificacao.Controls.Add(this.m_txtNome);
			this.m_gbIdentificacao.Controls.Add(this.m_txtCPF);
			this.m_gbIdentificacao.Controls.Add(this.m_lbCpf);
			this.m_gbIdentificacao.Controls.Add(this.m_lbDataNascimento);
			this.m_gbIdentificacao.Controls.Add(this.m_lbNome);
			this.m_gbIdentificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIdentificacao.Location = new System.Drawing.Point(7, 150);
			this.m_gbIdentificacao.Name = "m_gbIdentificacao";
			this.m_gbIdentificacao.Size = new System.Drawing.Size(408, 96);
			this.m_gbIdentificacao.TabIndex = 1;
			this.m_gbIdentificacao.TabStop = false;
			this.m_gbIdentificacao.Text = "Identificação Usuário";
			// 
			// m_dpDataNascimento
			// 
			this.m_dpDataNascimento.CustomFormat = "";
			this.m_dpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpDataNascimento.Location = new System.Drawing.Point(314, 37);
			this.m_dpDataNascimento.Name = "m_dpDataNascimento";
			this.m_dpDataNascimento.Size = new System.Drawing.Size(88, 20);
			this.m_dpDataNascimento.TabIndex = 3;
			// 
			// m_cbFuncao
			// 
			this.m_cbFuncao.Location = new System.Drawing.Point(72, 60);
			this.m_cbFuncao.Name = "m_cbFuncao";
			this.m_cbFuncao.Size = new System.Drawing.Size(328, 22);
			this.m_cbFuncao.TabIndex = 4;
			// 
			// m_lbFuncao
			// 
			this.m_lbFuncao.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFuncao.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFuncao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFuncao.ForeColor = System.Drawing.Color.Black;
			this.m_lbFuncao.Location = new System.Drawing.Point(6, 63);
			this.m_lbFuncao.Name = "m_lbFuncao";
			this.m_lbFuncao.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFuncao.Size = new System.Drawing.Size(66, 17);
			this.m_lbFuncao.TabIndex = 48;
			this.m_lbFuncao.Text = "Função:";
			// 
			// m_cbSexo
			// 
			this.m_cbSexo.Location = new System.Drawing.Point(203, 36);
			this.m_cbSexo.Name = "m_cbSexo";
			this.m_cbSexo.Size = new System.Drawing.Size(48, 22);
			this.m_cbSexo.TabIndex = 2;
			// 
			// m_lbSexo
			// 
			this.m_lbSexo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbSexo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbSexo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSexo.ForeColor = System.Drawing.Color.Black;
			this.m_lbSexo.Location = new System.Drawing.Point(165, 41);
			this.m_lbSexo.Name = "m_lbSexo";
			this.m_lbSexo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbSexo.Size = new System.Drawing.Size(45, 17);
			this.m_lbSexo.TabIndex = 43;
			this.m_lbSexo.Text = "Sexo:";
			// 
			// m_txtNome
			// 
			this.m_txtNome.Location = new System.Drawing.Point(72, 14);
			this.m_txtNome.Name = "m_txtNome";
			this.m_txtNome.Size = new System.Drawing.Size(328, 20);
			this.m_txtNome.TabIndex = 0;
			this.m_txtNome.Text = "";
			// 
			// m_txtCPF
			// 
			this.m_txtCPF.Location = new System.Drawing.Point(72, 37);
			this.m_txtCPF.Mask = true;
			this.m_txtCPF.MaskAutomaticSpecialCharacters = true;
			this.m_txtCPF.MaskText = "NNN.NNN.NNN-NN";
			this.m_txtCPF.Name = "m_txtCPF";
			this.m_txtCPF.Size = new System.Drawing.Size(88, 20);
			this.m_txtCPF.TabIndex = 1;
			this.m_txtCPF.Text = "";
			// 
			// m_lbCpf
			// 
			this.m_lbCpf.ForeColor = System.Drawing.Color.Black;
			this.m_lbCpf.Location = new System.Drawing.Point(7, 40);
			this.m_lbCpf.Name = "m_lbCpf";
			this.m_lbCpf.Size = new System.Drawing.Size(44, 16);
			this.m_lbCpf.TabIndex = 17;
			this.m_lbCpf.Text = "CPF:";
			// 
			// m_lbDataNascimento
			// 
			this.m_lbDataNascimento.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbDataNascimento.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbDataNascimento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDataNascimento.ForeColor = System.Drawing.Color.Black;
			this.m_lbDataNascimento.Location = new System.Drawing.Point(253, 40);
			this.m_lbDataNascimento.Name = "m_lbDataNascimento";
			this.m_lbDataNascimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbDataNascimento.Size = new System.Drawing.Size(67, 17);
			this.m_lbDataNascimento.TabIndex = 40;
			this.m_lbDataNascimento.Text = "Data Nasc:";
			// 
			// m_lbNome
			// 
			this.m_lbNome.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbNome.Location = new System.Drawing.Point(5, 18);
			this.m_lbNome.Name = "m_lbNome";
			this.m_lbNome.Size = new System.Drawing.Size(43, 16);
			this.m_lbNome.TabIndex = 15;
			this.m_lbNome.Text = "Nome:";
			// 
			// m_btVoltar
			// 
			this.m_btVoltar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVoltar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVoltar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVoltar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVoltar.Image")));
			this.m_btVoltar.Location = new System.Drawing.Point(122, 335);
			this.m_btVoltar.Name = "m_btVoltar";
			this.m_btVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVoltar.Size = new System.Drawing.Size(57, 25);
			this.m_btVoltar.TabIndex = 4;
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
			this.m_btContinuar.Location = new System.Drawing.Point(250, 335);
			this.m_btContinuar.Name = "m_btContinuar";
			this.m_btContinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContinuar.Size = new System.Drawing.Size(57, 25);
			this.m_btContinuar.TabIndex = 3;
			this.m_ttDica.SetToolTip(this.m_btContinuar, "Continuar");
			this.m_btContinuar.Click += new System.EventHandler(this.m_btConcluir_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(186, 335);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 5;
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
			// frmFRegistroCategoriaPJExportadorUsuario
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 376);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistroCategoriaPJExportadorUsuario";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Identificação do Usuário";
			this.Load += new System.EventHandler(this.frmFRegistroCategoriaPJExportadorUsuario_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbImage.ResumeLayout(false);
			this.m_gbMeioComunicação.ResumeLayout(false);
			this.m_gbIdentificacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dos Dados Interface
			private void vCarregaDadosInterface()
			{
				m_txtNome.Text = m_strNome;
				m_txtCPF.Text = m_strCPF;
				if (m_bSexoMasculino)
					m_cbSexo.Text = "M";
				else
					m_cbSexo.Text = "F";
				m_dpDataNascimento.Value = m_dtDataNascimento;  
				m_cbFuncao.SelectItem(m_nFuncao);
				m_txtTelefone.Text = m_strTelefone; 
				m_txtTelefoneDDD.Text = m_strTelefoneDDD; 
				m_txtEmail.Text = m_strEmail; 
				m_txtRamal.Text = m_strRamal;
				m_txtFax.Text = m_strFax; 
				m_txtFaxDDD.Text = m_strFaxDDD; 
			}
		#endregion
		#region Salvamento dos Dados da Interface
			private bool bSalvaDadosInterface()
			{
				object obj = null;

				// Nome
				if (m_txtNome.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarNome));
					return(false);
				}
				else
				{
					m_strNome = m_txtNome.Text.Trim();
				}

				// CPF
				m_strCPF = m_txtCPF.Text.Trim();

				// CPF Corretamente 
				if (m_strCPF != "")
				{
					if (!mdlValidacao.clsCPF.bCheckCPF(m_strCPF))
					{
						mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_IncorretoCPF));
						return(false);
					}
				}

				// Sexo
				obj = m_cbSexo.ReturnObjectSelectedItem();
				if (obj == null)
				{
					if (Int32.Parse(obj.ToString()) == 0)
					{
						m_bSexoMasculino = false;
					}else{
						m_bSexoMasculino = true;
					}
				}

				// Data Nascimento
				m_dtDataNascimento = m_dpDataNascimento.Value;
				
				// Funcao
				obj = m_cbFuncao.ReturnObjectSelectedItem();
				if (obj != null)
				{
					m_nFuncao = Int32.Parse(obj.ToString());
				}else{
					m_nFuncao = 0;
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

				// Ramal
				m_strRamal = m_txtRamal.Text.Trim();

				// Fax
				m_strFax = m_txtFax.Text.Trim();

				// Fax DDD
				m_strFaxDDD = m_txtFaxDDD.Text.Trim();

				return(true);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFRegistroCategoriaPJExportadorUsuario_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDados();
					OnCallRefreshSexo();
					OnCallRefreshFuncao();
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

				private void m_btConcluir_Click(object sender, System.EventArgs e)
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
