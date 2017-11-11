using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRegistroCategoriaACProfessor.
	/// </summary>
	internal class frmFRegistroCategoriaACProfessor : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallRefreshSexo(ref mdlComponentesGraficos.ComboBox cbSexo);
			public delegate void delCallRefreshEstado(ref mdlComponentesGraficos.ComboBox cbFuncao);
			public delegate void delCallCarregaDados(out string strNome ,out string strCPF,out bool bSexoMasculino ,out System.DateTime dtDataNascimento,out string strEmail,out string strTelefone,out string strTelefoneDDD,out string strInstituicaoEnsino ,out string strCurso ,out string strFase ,out string strLogradouro ,out string strComplemento ,out string strBairro ,out string strCidade ,out int nEstado ,out string strCEP);
			public delegate void delCallSalvaDados(string strNome ,string strCPF,bool bSexoMasculino ,System.DateTime dtDataNascimento,string strEmail,string strTelefone,string strTelefoneDDD,string strInstituicaoEnsino ,string strCurso ,string strFase ,string strLogradouro ,string strComplemento ,string strBairro ,string strCidade ,int nEstado ,string strCEP );
		#endregion
		#region Events 
			public event delCallRefreshSexo eCallRefreshSexo;
			public event delCallRefreshEstado eCallRefreshEstado;
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

			protected virtual void OnCallRefreshEstado()
			{
				if (eCallRefreshEstado != null)
				{
					eCallRefreshEstado(ref m_cbEstado);
				}
			}

			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					eCallCarregaDados(out m_strNome ,out m_strCPF,out m_bSexoMasculino ,out m_dtDataNascimento,out m_strEmail,out m_strTelefone,out m_strTelefoneDDD,out m_strInstituicaoEnsino ,out m_strCurso ,out m_strFase ,out m_strLogradouro ,out m_strComplemento ,out m_strBairro ,out m_strCidade ,out m_nEstado ,out m_strCEP);
				}
			}

			protected virtual void OnCallSalvaDados()
			{
				if (eCallSalvaDados != null)
				{
					eCallSalvaDados(m_strNome ,m_strCPF,m_bSexoMasculino ,m_dtDataNascimento,m_strEmail,m_strTelefone,m_strTelefoneDDD,m_strInstituicaoEnsino ,m_strCurso ,m_strFase ,m_strLogradouro ,m_strComplemento ,m_strBairro ,m_strCidade ,m_nEstado ,m_strCEP);
				}
			}
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			// Dados 
			private string m_strNome = "";
			private string m_strCPF = "";
			private bool m_bSexoMasculino = false;
			private System.DateTime m_dtDataNascimento = new DateTime(1800,1,1);
			private string m_strEmail = "";
			private string m_strTelefone = "";
			private string m_strTelefoneDDD = "";
			private string m_strInstituicaoEnsino = "";
			private string m_strCurso = "";
			private string m_strFase = "";
			private string m_strLogradouro = "";
			private string m_strComplemento = "";
			private string m_strBairro = "";
			private string m_strCidade = "";
			private int m_nEstado = 0;
			private string m_strCEP = "";

			internal mdlRegistro.Resposta m_enumResposta = mdlRegistro.Resposta.Cancelar;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbIdentificacao;
			public System.Windows.Forms.Label m_lbInfoCamposObrigatorios;
			private System.Windows.Forms.GroupBox m_gbMeioComunicação;
			private mdlComponentesGraficos.TextBox m_txtEmail;
			private mdlComponentesGraficos.TextBox m_txtTelefone;
			public System.Windows.Forms.Label m_lbEmail;
			public System.Windows.Forms.Label m_lbTelefone;
			internal System.Windows.Forms.Button m_btVoltar;
			internal System.Windows.Forms.Button m_btContinuar;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbEspecificos;
			public System.Windows.Forms.Label m_lbEstado;
			private mdlComponentesGraficos.ComboBox m_cbEstado;
			public System.Windows.Forms.Label m_lbCep;
			private mdlComponentesGraficos.TextBox m_txtCep;
			public System.Windows.Forms.Label m_lbCidade;
			public System.Windows.Forms.Label m_lbLogradouro;
			private mdlComponentesGraficos.TextBox m_txtLogradouro;
			private mdlComponentesGraficos.TextBox m_txtBairro;
			public System.Windows.Forms.Label m_lbBairro;
			private mdlComponentesGraficos.TextBox m_txtCidade;
			public System.Windows.Forms.Label m_lbInstituicao;
			private mdlComponentesGraficos.ComboBox m_cbFase;
			public System.Windows.Forms.Label m_lbDataNascimento;
			private System.Windows.Forms.DateTimePicker m_dpDataNascimento;
			private mdlComponentesGraficos.ComboBox m_cbSexo;
			public System.Windows.Forms.Label m_lbSexo;
			private mdlComponentesGraficos.TextBox m_txtNome;
			private mdlComponentesGraficos.TextBox m_txtCPF;
			private System.Windows.Forms.Label m_lbCPF;
			private System.Windows.Forms.Label m_lbNome;
			private mdlComponentesGraficos.ComboBox m_cbCurso;
			public System.Windows.Forms.Label m_lbCurso;
			public System.Windows.Forms.Label m_lbFase;
			private mdlComponentesGraficos.TextBox m_txtComplemento;
			public System.Windows.Forms.Label m_lbComplemento;
			private mdlComponentesGraficos.ComboBox m_cbInstituicaoEnsino;
			private System.Windows.Forms.ToolTip m_ttDica;
		public System.Windows.Forms.Label m_lbTelefoneParEsquerdo;
		private mdlComponentesGraficos.TextBox m_txtTelefoneDDD;
		public System.Windows.Forms.Label m_lbTelefoneParDireito;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFRegistroCategoriaACProfessor(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistroCategoriaACProfessor));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbEspecificos = new System.Windows.Forms.GroupBox();
			this.m_cbCurso = new mdlComponentesGraficos.ComboBox();
			this.m_cbInstituicaoEnsino = new mdlComponentesGraficos.ComboBox();
			this.m_lbInstituicao = new System.Windows.Forms.Label();
			this.m_cbFase = new mdlComponentesGraficos.ComboBox();
			this.m_lbCurso = new System.Windows.Forms.Label();
			this.m_lbFase = new System.Windows.Forms.Label();
			this.m_lbEstado = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_lbCep = new System.Windows.Forms.Label();
			this.m_txtCep = new mdlComponentesGraficos.TextBox();
			this.m_lbCidade = new System.Windows.Forms.Label();
			this.m_txtComplemento = new mdlComponentesGraficos.TextBox();
			this.m_lbComplemento = new System.Windows.Forms.Label();
			this.m_lbLogradouro = new System.Windows.Forms.Label();
			this.m_txtLogradouro = new mdlComponentesGraficos.TextBox();
			this.m_txtBairro = new mdlComponentesGraficos.TextBox();
			this.m_lbBairro = new System.Windows.Forms.Label();
			this.m_txtCidade = new mdlComponentesGraficos.TextBox();
			this.m_gbIdentificacao = new System.Windows.Forms.GroupBox();
			this.m_lbDataNascimento = new System.Windows.Forms.Label();
			this.m_dpDataNascimento = new System.Windows.Forms.DateTimePicker();
			this.m_cbSexo = new mdlComponentesGraficos.ComboBox();
			this.m_lbSexo = new System.Windows.Forms.Label();
			this.m_txtNome = new mdlComponentesGraficos.TextBox();
			this.m_txtCPF = new mdlComponentesGraficos.TextBox();
			this.m_lbCPF = new System.Windows.Forms.Label();
			this.m_lbNome = new System.Windows.Forms.Label();
			this.m_lbInfoCamposObrigatorios = new System.Windows.Forms.Label();
			this.m_gbMeioComunicação = new System.Windows.Forms.GroupBox();
			this.m_lbTelefoneParEsquerdo = new System.Windows.Forms.Label();
			this.m_txtTelefoneDDD = new mdlComponentesGraficos.TextBox();
			this.m_lbTelefoneParDireito = new System.Windows.Forms.Label();
			this.m_txtEmail = new mdlComponentesGraficos.TextBox();
			this.m_lbEmail = new System.Windows.Forms.Label();
			this.m_lbTelefone = new System.Windows.Forms.Label();
			this.m_txtTelefone = new mdlComponentesGraficos.TextBox();
			this.m_btVoltar = new System.Windows.Forms.Button();
			this.m_btContinuar = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbEspecificos.SuspendLayout();
			this.m_gbIdentificacao.SuspendLayout();
			this.m_gbMeioComunicação.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbEspecificos);
			this.m_gbGeral.Controls.Add(this.m_gbIdentificacao);
			this.m_gbGeral.Controls.Add(this.m_lbInfoCamposObrigatorios);
			this.m_gbGeral.Controls.Add(this.m_gbMeioComunicação);
			this.m_gbGeral.Controls.Add(this.m_btVoltar);
			this.m_gbGeral.Controls.Add(this.m_btContinuar);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(5, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(427, 377);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbEspecificos
			// 
			this.m_gbEspecificos.Controls.Add(this.m_cbCurso);
			this.m_gbEspecificos.Controls.Add(this.m_cbInstituicaoEnsino);
			this.m_gbEspecificos.Controls.Add(this.m_lbInstituicao);
			this.m_gbEspecificos.Controls.Add(this.m_cbFase);
			this.m_gbEspecificos.Controls.Add(this.m_lbCurso);
			this.m_gbEspecificos.Controls.Add(this.m_lbFase);
			this.m_gbEspecificos.Controls.Add(this.m_lbEstado);
			this.m_gbEspecificos.Controls.Add(this.m_cbEstado);
			this.m_gbEspecificos.Controls.Add(this.m_lbCep);
			this.m_gbEspecificos.Controls.Add(this.m_txtCep);
			this.m_gbEspecificos.Controls.Add(this.m_lbCidade);
			this.m_gbEspecificos.Controls.Add(this.m_txtComplemento);
			this.m_gbEspecificos.Controls.Add(this.m_lbComplemento);
			this.m_gbEspecificos.Controls.Add(this.m_lbLogradouro);
			this.m_gbEspecificos.Controls.Add(this.m_txtLogradouro);
			this.m_gbEspecificos.Controls.Add(this.m_txtBairro);
			this.m_gbEspecificos.Controls.Add(this.m_lbBairro);
			this.m_gbEspecificos.Controls.Add(this.m_txtCidade);
			this.m_gbEspecificos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbEspecificos.Location = new System.Drawing.Point(9, 149);
			this.m_gbEspecificos.Name = "m_gbEspecificos";
			this.m_gbEspecificos.Size = new System.Drawing.Size(409, 176);
			this.m_gbEspecificos.TabIndex = 2;
			this.m_gbEspecificos.TabStop = false;
			this.m_gbEspecificos.Text = "Ensino";
			// 
			// m_cbCurso
			// 
			this.m_cbCurso.AutoCompleteCaseSensitive = false;
			this.m_cbCurso.GoToNextControlWithEnter = true;
			this.m_cbCurso.Location = new System.Drawing.Point(107, 48);
			this.m_cbCurso.Name = "m_cbCurso";
			this.m_cbCurso.Size = new System.Drawing.Size(109, 22);
			this.m_cbCurso.TabIndex = 1;
			// 
			// m_cbInstituicaoEnsino
			// 
			this.m_cbInstituicaoEnsino.AutoCompleteCaseSensitive = false;
			this.m_cbInstituicaoEnsino.GoToNextControlWithEnter = true;
			this.m_cbInstituicaoEnsino.Location = new System.Drawing.Point(133, 18);
			this.m_cbInstituicaoEnsino.Name = "m_cbInstituicaoEnsino";
			this.m_cbInstituicaoEnsino.Size = new System.Drawing.Size(267, 22);
			this.m_cbInstituicaoEnsino.TabIndex = 0;
			// 
			// m_lbInstituicao
			// 
			this.m_lbInstituicao.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbInstituicao.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbInstituicao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInstituicao.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInstituicao.Location = new System.Drawing.Point(8, 24);
			this.m_lbInstituicao.Name = "m_lbInstituicao";
			this.m_lbInstituicao.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbInstituicao.Size = new System.Drawing.Size(128, 16);
			this.m_lbInstituicao.TabIndex = 54;
			this.m_lbInstituicao.Text = "Instituição de Ensino:";
			// 
			// m_cbFase
			// 
			this.m_cbFase.AutoCompleteCaseSensitive = false;
			this.m_cbFase.GoToNextControlWithEnter = true;
			this.m_cbFase.Location = new System.Drawing.Point(270, 48);
			this.m_cbFase.Name = "m_cbFase";
			this.m_cbFase.Size = new System.Drawing.Size(128, 22);
			this.m_cbFase.TabIndex = 2;
			// 
			// m_lbCurso
			// 
			this.m_lbCurso.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCurso.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCurso.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCurso.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCurso.Location = new System.Drawing.Point(11, 50);
			this.m_lbCurso.Name = "m_lbCurso";
			this.m_lbCurso.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCurso.Size = new System.Drawing.Size(43, 16);
			this.m_lbCurso.TabIndex = 35;
			this.m_lbCurso.Text = "Curso:";
			// 
			// m_lbFase
			// 
			this.m_lbFase.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbFase.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbFase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFase.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbFase.Location = new System.Drawing.Point(224, 49);
			this.m_lbFase.Name = "m_lbFase";
			this.m_lbFase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbFase.Size = new System.Drawing.Size(41, 16);
			this.m_lbFase.TabIndex = 34;
			this.m_lbFase.Text = "Fase:";
			// 
			// m_lbEstado
			// 
			this.m_lbEstado.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbEstado.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEstado.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbEstado.Location = new System.Drawing.Point(10, 144);
			this.m_lbEstado.Name = "m_lbEstado";
			this.m_lbEstado.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbEstado.Size = new System.Drawing.Size(52, 16);
			this.m_lbEstado.TabIndex = 36;
			this.m_lbEstado.Text = "Estado:";
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.GoToNextControlWithEnter = true;
			this.m_cbEstado.Location = new System.Drawing.Point(106, 144);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(48, 22);
			this.m_cbEstado.TabIndex = 7;
			// 
			// m_lbCep
			// 
			this.m_lbCep.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCep.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCep.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCep.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCep.Location = new System.Drawing.Point(218, 147);
			this.m_lbCep.Name = "m_lbCep";
			this.m_lbCep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCep.Size = new System.Drawing.Size(48, 17);
			this.m_lbCep.TabIndex = 38;
			this.m_lbCep.Text = "CEP:";
			// 
			// m_txtCep
			// 
			this.m_txtCep.Location = new System.Drawing.Point(282, 147);
			this.m_txtCep.Mask = true;
			this.m_txtCep.MaskAutomaticSpecialCharacters = true;
			this.m_txtCep.MaskText = "NNNNN-NNN";
			this.m_txtCep.Name = "m_txtCep";
			this.m_txtCep.Size = new System.Drawing.Size(120, 20);
			this.m_txtCep.TabIndex = 8;
			this.m_txtCep.Text = "";
			// 
			// m_lbCidade
			// 
			this.m_lbCidade.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbCidade.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCidade.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCidade.Location = new System.Drawing.Point(218, 123);
			this.m_lbCidade.Name = "m_lbCidade";
			this.m_lbCidade.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbCidade.Size = new System.Drawing.Size(56, 17);
			this.m_lbCidade.TabIndex = 39;
			this.m_lbCidade.Text = "Cidade:";
			// 
			// m_txtComplemento
			// 
			this.m_txtComplemento.Location = new System.Drawing.Point(106, 99);
			this.m_txtComplemento.Name = "m_txtComplemento";
			this.m_txtComplemento.Size = new System.Drawing.Size(296, 20);
			this.m_txtComplemento.TabIndex = 4;
			this.m_txtComplemento.Text = "";
			// 
			// m_lbComplemento
			// 
			this.m_lbComplemento.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbComplemento.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbComplemento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbComplemento.ForeColor = System.Drawing.Color.Black;
			this.m_lbComplemento.Location = new System.Drawing.Point(9, 103);
			this.m_lbComplemento.Name = "m_lbComplemento";
			this.m_lbComplemento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbComplemento.Size = new System.Drawing.Size(84, 16);
			this.m_lbComplemento.TabIndex = 48;
			this.m_lbComplemento.Text = "Complemento:";
			// 
			// m_lbLogradouro
			// 
			this.m_lbLogradouro.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbLogradouro.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbLogradouro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLogradouro.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbLogradouro.Location = new System.Drawing.Point(11, 79);
			this.m_lbLogradouro.Name = "m_lbLogradouro";
			this.m_lbLogradouro.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbLogradouro.Size = new System.Drawing.Size(84, 16);
			this.m_lbLogradouro.TabIndex = 37;
			this.m_lbLogradouro.Text = "Logradouro:";
			// 
			// m_txtLogradouro
			// 
			this.m_txtLogradouro.Location = new System.Drawing.Point(106, 75);
			this.m_txtLogradouro.Name = "m_txtLogradouro";
			this.m_txtLogradouro.Size = new System.Drawing.Size(296, 20);
			this.m_txtLogradouro.TabIndex = 3;
			this.m_txtLogradouro.Text = "";
			// 
			// m_txtBairro
			// 
			this.m_txtBairro.Location = new System.Drawing.Point(106, 123);
			this.m_txtBairro.Name = "m_txtBairro";
			this.m_txtBairro.Size = new System.Drawing.Size(112, 20);
			this.m_txtBairro.TabIndex = 5;
			this.m_txtBairro.Text = "";
			// 
			// m_lbBairro
			// 
			this.m_lbBairro.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbBairro.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbBairro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbBairro.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbBairro.Location = new System.Drawing.Point(10, 123);
			this.m_lbBairro.Name = "m_lbBairro";
			this.m_lbBairro.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbBairro.Size = new System.Drawing.Size(47, 16);
			this.m_lbBairro.TabIndex = 33;
			this.m_lbBairro.Text = "Bairro:";
			// 
			// m_txtCidade
			// 
			this.m_txtCidade.Location = new System.Drawing.Point(282, 123);
			this.m_txtCidade.Name = "m_txtCidade";
			this.m_txtCidade.Size = new System.Drawing.Size(120, 20);
			this.m_txtCidade.TabIndex = 6;
			this.m_txtCidade.Text = "";
			// 
			// m_gbIdentificacao
			// 
			this.m_gbIdentificacao.Controls.Add(this.m_lbDataNascimento);
			this.m_gbIdentificacao.Controls.Add(this.m_dpDataNascimento);
			this.m_gbIdentificacao.Controls.Add(this.m_cbSexo);
			this.m_gbIdentificacao.Controls.Add(this.m_lbSexo);
			this.m_gbIdentificacao.Controls.Add(this.m_txtNome);
			this.m_gbIdentificacao.Controls.Add(this.m_txtCPF);
			this.m_gbIdentificacao.Controls.Add(this.m_lbCPF);
			this.m_gbIdentificacao.Controls.Add(this.m_lbNome);
			this.m_gbIdentificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIdentificacao.Location = new System.Drawing.Point(8, 8);
			this.m_gbIdentificacao.Name = "m_gbIdentificacao";
			this.m_gbIdentificacao.Size = new System.Drawing.Size(408, 64);
			this.m_gbIdentificacao.TabIndex = 0;
			this.m_gbIdentificacao.TabStop = false;
			this.m_gbIdentificacao.Text = "Identificação";
			// 
			// m_lbDataNascimento
			// 
			this.m_lbDataNascimento.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbDataNascimento.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbDataNascimento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbDataNascimento.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbDataNascimento.Location = new System.Drawing.Point(258, 40);
			this.m_lbDataNascimento.Name = "m_lbDataNascimento";
			this.m_lbDataNascimento.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbDataNascimento.Size = new System.Drawing.Size(64, 17);
			this.m_lbDataNascimento.TabIndex = 51;
			this.m_lbDataNascimento.Text = "Data nasc:";
			// 
			// m_dpDataNascimento
			// 
			this.m_dpDataNascimento.CustomFormat = "";
			this.m_dpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dpDataNascimento.Location = new System.Drawing.Point(320, 37);
			this.m_dpDataNascimento.Name = "m_dpDataNascimento";
			this.m_dpDataNascimento.Size = new System.Drawing.Size(80, 20);
			this.m_dpDataNascimento.TabIndex = 3;
			// 
			// m_cbSexo
			// 
			this.m_cbSexo.GoToNextControlWithEnter = true;
			this.m_cbSexo.Location = new System.Drawing.Point(208, 36);
			this.m_cbSexo.Name = "m_cbSexo";
			this.m_cbSexo.Size = new System.Drawing.Size(48, 22);
			this.m_cbSexo.TabIndex = 2;
			// 
			// m_lbSexo
			// 
			this.m_lbSexo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbSexo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbSexo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbSexo.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbSexo.Location = new System.Drawing.Point(170, 41);
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
			this.m_txtCPF.Size = new System.Drawing.Size(96, 20);
			this.m_txtCPF.TabIndex = 1;
			this.m_txtCPF.Text = "";
			// 
			// m_lbCPF
			// 
			this.m_lbCPF.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbCPF.Location = new System.Drawing.Point(6, 38);
			this.m_lbCPF.Name = "m_lbCPF";
			this.m_lbCPF.Size = new System.Drawing.Size(44, 16);
			this.m_lbCPF.TabIndex = 17;
			this.m_lbCPF.Text = "CPF:";
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
			// m_lbInfoCamposObrigatorios
			// 
			this.m_lbInfoCamposObrigatorios.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbInfoCamposObrigatorios.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbInfoCamposObrigatorios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbInfoCamposObrigatorios.Location = new System.Drawing.Point(75, 328);
			this.m_lbInfoCamposObrigatorios.Name = "m_lbInfoCamposObrigatorios";
			this.m_lbInfoCamposObrigatorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbInfoCamposObrigatorios.Size = new System.Drawing.Size(256, 16);
			this.m_lbInfoCamposObrigatorios.TabIndex = 52;
			this.m_lbInfoCamposObrigatorios.Text = "Obs.: Campos em vermelho são obrigatórios.";
			// 
			// m_gbMeioComunicação
			// 
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParEsquerdo);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefoneDDD);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefoneParDireito);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtEmail);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbEmail);
			this.m_gbMeioComunicação.Controls.Add(this.m_lbTelefone);
			this.m_gbMeioComunicação.Controls.Add(this.m_txtTelefone);
			this.m_gbMeioComunicação.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMeioComunicação.Location = new System.Drawing.Point(8, 74);
			this.m_gbMeioComunicação.Name = "m_gbMeioComunicação";
			this.m_gbMeioComunicação.Size = new System.Drawing.Size(409, 70);
			this.m_gbMeioComunicação.TabIndex = 1;
			this.m_gbMeioComunicação.TabStop = false;
			this.m_gbMeioComunicação.Text = "Meio de Comunicação";
			// 
			// m_lbTelefoneParEsquerdo
			// 
			this.m_lbTelefoneParEsquerdo.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefoneParEsquerdo.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefoneParEsquerdo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefoneParEsquerdo.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefoneParEsquerdo.Location = new System.Drawing.Point(67, 40);
			this.m_lbTelefoneParEsquerdo.Name = "m_lbTelefoneParEsquerdo";
			this.m_lbTelefoneParEsquerdo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParEsquerdo.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParEsquerdo.TabIndex = 44;
			this.m_lbTelefoneParEsquerdo.Text = "(";
			// 
			// m_txtTelefoneDDD
			// 
			this.m_txtTelefoneDDD.Location = new System.Drawing.Point(75, 40);
			this.m_txtTelefoneDDD.Name = "m_txtTelefoneDDD";
			this.m_txtTelefoneDDD.Size = new System.Drawing.Size(25, 20);
			this.m_txtTelefoneDDD.TabIndex = 1;
			this.m_txtTelefoneDDD.Text = "";
			// 
			// m_lbTelefoneParDireito
			// 
			this.m_lbTelefoneParDireito.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbTelefoneParDireito.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbTelefoneParDireito.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbTelefoneParDireito.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefoneParDireito.Location = new System.Drawing.Point(103, 40);
			this.m_lbTelefoneParDireito.Name = "m_lbTelefoneParDireito";
			this.m_lbTelefoneParDireito.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefoneParDireito.Size = new System.Drawing.Size(8, 16);
			this.m_lbTelefoneParDireito.TabIndex = 43;
			this.m_lbTelefoneParDireito.Text = ") ";
			// 
			// m_txtEmail
			// 
			this.m_txtEmail.Location = new System.Drawing.Point(71, 16);
			this.m_txtEmail.Name = "m_txtEmail";
			this.m_txtEmail.Size = new System.Drawing.Size(328, 20);
			this.m_txtEmail.TabIndex = 0;
			this.m_txtEmail.Text = "";
			// 
			// m_lbEmail
			// 
			this.m_lbEmail.BackColor = System.Drawing.SystemColors.Control;
			this.m_lbEmail.Cursor = System.Windows.Forms.Cursors.Default;
			this.m_lbEmail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEmail.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lbEmail.Location = new System.Drawing.Point(12, 19);
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
			this.m_lbTelefone.ForeColor = System.Drawing.Color.Black;
			this.m_lbTelefone.Location = new System.Drawing.Point(9, 41);
			this.m_lbTelefone.Name = "m_lbTelefone";
			this.m_lbTelefone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_lbTelefone.Size = new System.Drawing.Size(61, 16);
			this.m_lbTelefone.TabIndex = 35;
			this.m_lbTelefone.Text = "Telefone:";
			// 
			// m_txtTelefone
			// 
			this.m_txtTelefone.Location = new System.Drawing.Point(112, 40);
			this.m_txtTelefone.Name = "m_txtTelefone";
			this.m_txtTelefone.Size = new System.Drawing.Size(288, 20);
			this.m_txtTelefone.TabIndex = 2;
			this.m_txtTelefone.Text = "";
			// 
			// m_btVoltar
			// 
			this.m_btVoltar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVoltar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVoltar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVoltar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVoltar.Image")));
			this.m_btVoltar.Location = new System.Drawing.Point(120, 344);
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
			this.m_btContinuar.Location = new System.Drawing.Point(248, 344);
			this.m_btContinuar.Name = "m_btContinuar";
			this.m_btContinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContinuar.Size = new System.Drawing.Size(57, 25);
			this.m_btContinuar.TabIndex = 3;
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
			this.m_btCancelar.Location = new System.Drawing.Point(184, 344);
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
			// frmFRegistroCategoriaACProfessor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 384);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistroCategoriaACProfessor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Meio Acadêmico: Professor";
			this.Load += new System.EventHandler(this.frmFRegistroCategoriaACProfessor_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbEspecificos.ResumeLayout(false);
			this.m_gbIdentificacao.ResumeLayout(false);
			this.m_gbMeioComunicação.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dos Dados Interface
			private void vCarregaDadosInterface()
			{
				m_txtNome.Text = m_strNome;
				m_txtCPF.Text = m_strCPF;
				if (m_bSexoMasculino)
				{
					m_cbSexo.Text = "M";
				}
				else
				{
					m_cbSexo.Text = "F";
				}
				m_dpDataNascimento.Value = m_dtDataNascimento;
				m_txtEmail.Text = m_strEmail; 
				m_txtTelefone.Text = m_strTelefone;
				m_txtTelefoneDDD.Text = m_strTelefoneDDD;
				m_cbInstituicaoEnsino.Text = m_strInstituicaoEnsino; 
				m_cbCurso.Text = m_strCurso;
				m_cbFase.Text = m_strFase; 
				m_txtLogradouro.Text = m_strLogradouro;
				m_txtComplemento.Text = m_strComplemento;
				m_txtBairro.Text = m_strBairro;
				m_txtCidade.Text = m_strCidade;  
				m_cbEstado.SelectItem(m_nEstado);
				m_txtCep.Text = m_strCEP; 
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
				if (m_txtCPF.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCPF));
					return(false);
				}
				m_strCPF = m_txtCPF.Text.Trim();

				// CPF Corretamente 
				if (!mdlValidacao.clsCPF.bCheckCPF(m_strCPF))
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_IncorretoCPF));
					return(false);
				}

				// Sexo
				obj = m_cbSexo.ReturnObjectSelectedItem();
				if (obj != null)
				{
					if (Int32.Parse(obj.ToString()) == 0)
					{
						m_bSexoMasculino = false;
					}
					else
					{
						m_bSexoMasculino = true;
					}
				}

				// Data Nascimento
				m_dtDataNascimento = m_dpDataNascimento.Value;

				// Telefone 
				m_strTelefone = m_txtTelefone.Text.Trim();

				// TelefoneDDD 
				m_strTelefoneDDD = m_txtTelefoneDDD.Text.Trim();

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

				// Instituicao Ensino
				if (m_cbInstituicaoEnsino.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarInstituicaoEnsino));
					return(false);
				}
				m_strInstituicaoEnsino = m_cbInstituicaoEnsino.Text.Trim();

				// Curso 
				if (m_cbCurso.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCurso));
					return(false);
				}
				m_strCurso = m_cbCurso.Text.Trim();

				// Fase 
				if (m_cbFase.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarFase));
					return(false);
				}
				m_strFase = m_cbFase.Text.Trim();

				// Logradouro
				if (m_txtLogradouro.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarLogradouro));
					return(false);
				}
				m_strLogradouro = m_txtLogradouro.Text.Trim();

				// Complemento
				m_strComplemento = m_txtComplemento.Text.Trim();

				// Bairro
				if (m_txtBairro.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarBairro));
					return(false);
				}
				m_strBairro = m_txtBairro.Text.Trim();

				// Cidade
				if (m_txtCidade.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCidade));
					return(false);
				}
				m_strCidade = m_txtCidade.Text.Trim();

				// Estado
				obj = m_cbEstado.ReturnObjectSelectedItem();
				if (obj == null)
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarEstado));
					return(false);
				}
				else
				{
					m_nEstado = Int32.Parse(obj.ToString());
				}

				// CEP
				if (m_txtCep.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlRegistro_frmFRegistroCategoriaACEstudante_InformarCEP));
					return(false);
				}
				m_strCEP = m_txtCep.Text.Trim();
					
				return(true);
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFRegistroCategoriaACProfessor_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDados();
					OnCallRefreshSexo();
					OnCallRefreshEstado();
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
