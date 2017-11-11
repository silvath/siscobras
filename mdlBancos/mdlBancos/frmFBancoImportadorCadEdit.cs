using System;
using System.Collections;

namespace mdlBancos
{
	/// <summary>
	/// Summary description for frmFBancoImportadorCadEdit.
	/// </summary>
	internal class frmFBancoImportadorCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private frmFBancoImportador m_formFBancoImportador = null;

		public bool m_bModificado = false;
		protected bool m_bCadastraNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		internal System.Windows.Forms.Button m_btTrocarCor;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lObs;
		private mdlComponentesGraficos.TextBox m_tbComplemento;
		private System.Windows.Forms.Label m_lComplemento;
		private mdlComponentesGraficos.ComboBox m_cbPais;
		private mdlComponentesGraficos.TextBox m_tbEstado;
		private System.Windows.Forms.Label m_lPais;
		private System.Windows.Forms.Label m_lEstado;
		private mdlComponentesGraficos.TextBox m_tbCidade;
		private System.Windows.Forms.Label m_lCidade;
		private mdlComponentesGraficos.TextBox m_tbEndereco;
		private System.Windows.Forms.Label m_lEndereco;
		private mdlComponentesGraficos.TextBox m_tbNome;
		private System.Windows.Forms.Label m_lNome;
		private System.Windows.Forms.TextBox m_tbObs;
		private System.Windows.Forms.ToolTip m_ttCadastroBanco;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFBancoImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}

		public frmFBancoImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel,ref frmFBancoImportador formFBancoImportador)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFBancoImportador = formFBancoImportador;
		}

		public frmFBancoImportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel,ref frmFBancoImportador formFBancoImportador, bool CadastraNovo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFBancoImportador = formFBancoImportador;
			m_bCadastraNovo = CadastraNovo;
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

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome,ref mdlComponentesGraficos.TextBox tbEndereco,ref mdlComponentesGraficos.TextBox tbComplemento,ref mdlComponentesGraficos.TextBox tbCidade,ref mdlComponentesGraficos.TextBox tbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref System.Windows.Forms.TextBox ctbObs);
		public delegate void delCallCarregaDadosInterfacePaises(ref mdlComponentesGraficos.ComboBox cbPaises);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome,ref mdlComponentesGraficos.TextBox tbEndereco,ref mdlComponentesGraficos.TextBox tbComplemento,ref mdlComponentesGraficos.TextBox tbCidade,ref mdlComponentesGraficos.TextBox tbEstado,ref mdlComponentesGraficos.ComboBox cbPaises,ref System.Windows.Forms.TextBox ctbObs);
		public delegate void delCallSalvaDadosBD(bool cadastraNovo);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfacePaises eCallCarregaDadosInterfacePaises;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_tbNome,ref this.m_tbEndereco, ref this.m_tbComplemento, ref this.m_tbCidade, ref this.m_tbEstado, ref this.m_cbPais, ref this.m_tbObs);
		}
		protected virtual void OnCallCarregaDadosInterfacePaises()
		{
			if (eCallCarregaDadosInterfacePaises != null)
				eCallCarregaDadosInterfacePaises(ref this.m_cbPais);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbNome,ref this.m_tbEndereco, ref this.m_tbComplemento, ref this.m_tbCidade, ref this.m_tbEstado, ref this.m_cbPais, ref this.m_tbObs);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastraNovo);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBancoImportadorCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbObs = new System.Windows.Forms.TextBox();
			this.m_lObs = new System.Windows.Forms.Label();
			this.m_tbComplemento = new mdlComponentesGraficos.TextBox();
			this.m_lComplemento = new System.Windows.Forms.Label();
			this.m_cbPais = new mdlComponentesGraficos.ComboBox();
			this.m_tbEstado = new mdlComponentesGraficos.TextBox();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_tbCidade = new mdlComponentesGraficos.TextBox();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_tbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_tbNome = new mdlComponentesGraficos.TextBox();
			this.m_lNome = new System.Windows.Forms.Label();
			this.m_ttCadastroBanco = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 260);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 10;
			this.m_ttCadastroBanco.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 229);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 8;
			this.m_ttCadastroBanco.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 229);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 9;
			this.m_ttCadastroBanco.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbObs);
			this.m_gbFields.Controls.Add(this.m_lObs);
			this.m_gbFields.Controls.Add(this.m_tbComplemento);
			this.m_gbFields.Controls.Add(this.m_lComplemento);
			this.m_gbFields.Controls.Add(this.m_cbPais);
			this.m_gbFields.Controls.Add(this.m_tbEstado);
			this.m_gbFields.Controls.Add(this.m_lPais);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_tbCidade);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_tbEndereco);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Controls.Add(this.m_tbNome);
			this.m_gbFields.Controls.Add(this.m_lNome);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 217);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbObs
			// 
			this.m_tbObs.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbObs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbObs.Location = new System.Drawing.Point(71, 143);
			this.m_tbObs.Multiline = true;
			this.m_tbObs.Name = "m_tbObs";
			this.m_tbObs.Size = new System.Drawing.Size(286, 61);
			this.m_tbObs.TabIndex = 7;
			this.m_tbObs.Text = "";
			// 
			// m_lObs
			// 
			this.m_lObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lObs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lObs.Location = new System.Drawing.Point(8, 142);
			this.m_lObs.Name = "m_lObs";
			this.m_lObs.Size = new System.Drawing.Size(34, 19);
			this.m_lObs.TabIndex = 0;
			this.m_lObs.Text = "Obs.:";
			// 
			// m_tbComplemento
			// 
			this.m_tbComplemento.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbComplemento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbComplemento.Location = new System.Drawing.Point(71, 71);
			this.m_tbComplemento.Name = "m_tbComplemento";
			this.m_tbComplemento.Size = new System.Drawing.Size(286, 20);
			this.m_tbComplemento.TabIndex = 3;
			this.m_tbComplemento.Text = "";
			// 
			// m_lComplemento
			// 
			this.m_lComplemento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lComplemento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lComplemento.Location = new System.Drawing.Point(8, 70);
			this.m_lComplemento.Name = "m_lComplemento";
			this.m_lComplemento.Size = new System.Drawing.Size(47, 19);
			this.m_lComplemento.TabIndex = 0;
			this.m_lComplemento.Text = "Compl.:";
			// 
			// m_cbPais
			// 
			this.m_cbPais.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cbPais.AutoCompleteCaseSensitive = false;
			this.m_cbPais.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbPais.GoToNextControlWithEnter = true;
			this.m_cbPais.Location = new System.Drawing.Point(220, 119);
			this.m_cbPais.Name = "m_cbPais";
			this.m_cbPais.Size = new System.Drawing.Size(137, 22);
			this.m_cbPais.TabIndex = 6;
			this.m_ttCadastroBanco.SetToolTip(this.m_cbPais, "Selecionar país");
			// 
			// m_tbEstado
			// 
			this.m_tbEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEstado.Location = new System.Drawing.Point(71, 119);
			this.m_tbEstado.Name = "m_tbEstado";
			this.m_tbEstado.Size = new System.Drawing.Size(111, 20);
			this.m_tbEstado.TabIndex = 5;
			this.m_tbEstado.Text = "";
			// 
			// m_lPais
			// 
			this.m_lPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lPais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPais.Location = new System.Drawing.Point(187, 118);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(33, 19);
			this.m_lPais.TabIndex = 34;
			this.m_lPais.Text = "País:";
			// 
			// m_lEstado
			// 
			this.m_lEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(8, 118);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(48, 19);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			// 
			// m_tbCidade
			// 
			this.m_tbCidade.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCidade.Location = new System.Drawing.Point(71, 95);
			this.m_tbCidade.Name = "m_tbCidade";
			this.m_tbCidade.Size = new System.Drawing.Size(286, 20);
			this.m_tbCidade.TabIndex = 4;
			this.m_tbCidade.Text = "";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 94);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(48, 19);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			// 
			// m_tbEndereco
			// 
			this.m_tbEndereco.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbEndereco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEndereco.Location = new System.Drawing.Point(71, 47);
			this.m_tbEndereco.Name = "m_tbEndereco";
			this.m_tbEndereco.Size = new System.Drawing.Size(286, 20);
			this.m_tbEndereco.TabIndex = 2;
			this.m_tbEndereco.Text = "";
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lEndereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEndereco.Location = new System.Drawing.Point(8, 46);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(61, 19);
			this.m_lEndereco.TabIndex = 0;
			this.m_lEndereco.Text = "Endereço:";
			// 
			// m_tbNome
			// 
			this.m_tbNome.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_tbNome.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNome.Location = new System.Drawing.Point(71, 23);
			this.m_tbNome.Name = "m_tbNome";
			this.m_tbNome.Size = new System.Drawing.Size(286, 20);
			this.m_tbNome.TabIndex = 1;
			this.m_tbNome.Text = "";
			// 
			// m_lNome
			// 
			this.m_lNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lNome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNome.Location = new System.Drawing.Point(8, 22);
			this.m_lNome.Name = "m_lNome";
			this.m_lNome.Size = new System.Drawing.Size(41, 19);
			this.m_lNome.TabIndex = 0;
			this.m_lNome.Text = "Nome:";
			// 
			// m_ttCadastroBanco
			// 
			this.m_ttCadastroBanco.AutomaticDelay = 100;
			this.m_ttCadastroBanco.AutoPopDelay = 5000;
			this.m_ttCadastroBanco.InitialDelay = 100;
			this.m_ttCadastroBanco.ReshowDelay = 20;
			// 
			// frmFBancoImportadorCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 261);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBancoImportadorCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Banco do Importador";
			this.Load += new System.EventHandler(this.frmFBancoImportadorCadEdit_Load);
			this.Activated += new System.EventHandler(this.frmFBancoImportadorCadEdit_Activated);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFBancoImportadorCadEdit_Load(object sender, System.EventArgs e)
		{
			try 
			{
				this.mostraCor();
				if (this.m_bCadastraNovo == false)
				{
					OnCallCarregaDadosBD();
					OnCallCarregaDadosInterface();
				} 
				else 
				{
					OnCallCarregaDadosInterfacePaises();
				}
				this.m_tbNome.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				if (m_formFBancoImportador != null)
					m_formFBancoImportador.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Click's
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_tbNome.Text == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoImportadorCadEdit_DigitarNomeBanco));
					//MessageBox.Show("Digite o nome do banco.",this.Text);
					m_tbNome.Focus();
				}
				else if (m_cbPais.ReturnObjectSelectedItem() == null)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoImportadorCadEdit_SelecionarPais));
					//MessageBox.Show("Selecione um país.",this.Text);
					this.m_cbPais.SelectedIndex = 0;
					this.m_cbPais.Focus();
				}
				else 
				{
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Activated
		private void frmFBancoImportadorCadEdit_Activated(object sender, System.EventArgs e)
		{
			try
			{
				m_tbNome.Focus();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#endregion
	}
}
