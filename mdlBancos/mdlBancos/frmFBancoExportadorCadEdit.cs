using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlBancos
{
	/// <summary>
	/// Summary description for frmFBancoExportadorCadEdit.
	/// </summary>
	internal class frmFBancoExportadorCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private frmFBancoExportador m_formFBancoExportador = null;

		public bool m_bModificado = false;
		protected bool m_bCadastraNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lBanco;
		private mdlComponentesGraficos.TextBox m_tbBanco;
		private mdlComponentesGraficos.ComboBox m_cbBanco;
		private System.Windows.Forms.Label m_lAgencia;
		private System.Windows.Forms.Label m_lConta;
		private mdlComponentesGraficos.TextBox m_tbAgencia;
		private mdlComponentesGraficos.TextBox m_tbConta;
		private mdlComponentesGraficos.ComboBox m_cbAgencia;
		private mdlComponentesGraficos.TextBox m_tbEndereco;
		private System.Windows.Forms.Label m_lEndereco;
		private mdlComponentesGraficos.TextBox m_tbBairro;
		private System.Windows.Forms.Label m_lBairro;
		private mdlComponentesGraficos.TextBox m_tbCidade;
		private System.Windows.Forms.Label m_lCidade;
		private mdlComponentesGraficos.ComboBox m_cbEstado;
		private mdlComponentesGraficos.TextBox m_tbCEP;
		private System.Windows.Forms.Label m_lCEP;
		private System.Windows.Forms.Label m_lEstado;
		private System.Windows.Forms.Label m_lInstrucoesPagamento;
		private System.Windows.Forms.Label m_lObs;
		private System.Windows.Forms.TextBox m_tbInstrucoesPagamento;
		private System.Windows.Forms.TextBox m_tbObs;
		private System.Windows.Forms.Label m_lTelefone;
		private System.Windows.Forms.Label m_lFax;
		private mdlComponentesGraficos.TextBox m_tbTelefone;
		private mdlComponentesGraficos.ComboBox m_cbConta;
		private mdlComponentesGraficos.TextBox m_tbFax;
		private System.Windows.Forms.ToolTip m_ttCadastroBanco;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFBancoExportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}
		public frmFBancoExportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel,ref frmFBancoExportador formFBancoExportador)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFBancoExportador = formFBancoExportador;
		}

		public frmFBancoExportadorCadEdit(ref mdlTratamentoErro.clsTratamentoErro tratadorErro,string EnderecoExecutavel, ref frmFBancoExportador formFBancoExportador, bool cadastraNovo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_formFBancoExportador = formFBancoExportador;
			m_bCadastraNovo = cadastraNovo;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbBanco,ref mdlComponentesGraficos.TextBox ctbAgencia,ref mdlComponentesGraficos.TextBox ctbConta,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbBairro,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.ComboBox cbEstado,ref mdlComponentesGraficos.TextBox ctbCEP,ref System.Windows.Forms.TextBox tbInstrucoes,ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox ctbTelefone, ref mdlComponentesGraficos.TextBox ctbFax);
		public delegate void delCallCarregaDadosInterfaceCadastro(ref mdlComponentesGraficos.ComboBox cbBancos,ref mdlComponentesGraficos.ComboBox cbEstados);
		public delegate void delCallCarregaDadosInterfaceComboBoxAgencias(ref mdlComponentesGraficos.ComboBox cbBancos, ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.TextBox ctbEndereco, ref mdlComponentesGraficos.TextBox ctbBairro, ref mdlComponentesGraficos.TextBox ctbCidade, ref mdlComponentesGraficos.TextBox ctbTelefone, ref mdlComponentesGraficos.TextBox ctbFax, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox ctbCEP, ref System.Windows.Forms.TextBox ctbInstrucoesPagamento, ref System.Windows.Forms.TextBox ctbObs);
		public delegate void delCallCarregaDadosInterfaceComboBoxContas(ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.ComboBox cbContas, ref mdlComponentesGraficos.TextBox ctbEndereco, ref mdlComponentesGraficos.TextBox ctbBairro, ref mdlComponentesGraficos.TextBox ctbCidade, ref mdlComponentesGraficos.TextBox ctbTelefone, ref mdlComponentesGraficos.TextBox ctbFax, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox ctbCEP, ref System.Windows.Forms.TextBox ctbInstrucoesPagamento, ref System.Windows.Forms.TextBox ctbObs);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbBanco,ref mdlComponentesGraficos.TextBox ctbAgencia,ref mdlComponentesGraficos.TextBox ctbConta,ref mdlComponentesGraficos.TextBox ctbEndereco,ref mdlComponentesGraficos.TextBox ctbBairro,ref mdlComponentesGraficos.TextBox ctbCidade,ref mdlComponentesGraficos.ComboBox cbEstado,ref mdlComponentesGraficos.TextBox ctbCEP,ref System.Windows.Forms.TextBox tbInstrucoes,ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox ctbTelefone, ref mdlComponentesGraficos.TextBox ctbFax);
		public delegate void delCallSalvaDadosInterfaceCadastro(ref mdlComponentesGraficos.ComboBox cbBancos, ref mdlComponentesGraficos.ComboBox cbAgencias, ref mdlComponentesGraficos.ComboBox cbContas, ref mdlComponentesGraficos.TextBox ctbEndereco, ref mdlComponentesGraficos.TextBox ctbBairro, ref mdlComponentesGraficos.TextBox ctbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox ctbCEP, ref System.Windows.Forms.TextBox tbInstrucoes, ref System.Windows.Forms.TextBox tbObs, ref mdlComponentesGraficos.TextBox ctbTelefone, ref mdlComponentesGraficos.TextBox ctbFax);
		public delegate void delCallSalvaDadosBD(bool cadastraNovo);
		public delegate void delCallSalvaDadosBDCadastro(bool cadastraNovo);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfaceCadastro eCallCarregaDadosInterfaceCadastro;
		public event delCallCarregaDadosInterfaceComboBoxAgencias eCallCarregaDadosInterfaceComboBoxAgencias;
		public event delCallCarregaDadosInterfaceComboBoxContas eCallCarregaDadosInterfaceComboBoxContas;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosInterfaceCadastro eCallSalvaDadosInterfaceCadastro;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallSalvaDadosBDCadastro eCallSalvaDadosBDCadastro;
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
				eCallCarregaDadosInterface(ref this.m_tbBanco,ref this.m_tbAgencia, ref this.m_tbConta, ref this.m_tbEndereco, ref this.m_tbBairro, ref this.m_tbCidade, ref this.m_cbEstado,ref this.m_tbCEP,ref this.m_tbInstrucoesPagamento,ref this.m_tbObs, ref this.m_tbTelefone, ref this.m_tbFax);
		}
		protected virtual void OnCallCarregaDadosInterfaceCadastro()
		{
			if (eCallCarregaDadosInterfaceCadastro != null)
				eCallCarregaDadosInterfaceCadastro(ref this.m_cbBanco,ref this.m_cbEstado);
		}
		protected virtual void OnCallCarregaDadosInterfaceComboBoxAgencias()
		{
			if (eCallCarregaDadosInterfaceComboBoxAgencias != null)
				eCallCarregaDadosInterfaceComboBoxAgencias(ref this.m_cbBanco, ref this.m_cbAgencia, ref this.m_tbEndereco, ref this.m_tbBairro, ref this.m_tbCidade, ref this.m_tbTelefone, ref this.m_tbFax, ref this.m_cbEstado, ref this.m_tbCEP, ref this.m_tbInstrucoesPagamento, ref this.m_tbObs);
		}
		protected virtual void OnCallCarregaDadosInterfaceComboBoxContas()
		{
			if (eCallCarregaDadosInterfaceComboBoxContas != null)
				eCallCarregaDadosInterfaceComboBoxContas(ref this.m_cbAgencia, ref this.m_cbConta, ref this.m_tbEndereco, ref this.m_tbBairro, ref this.m_tbCidade, ref this.m_tbTelefone, ref this.m_tbFax, ref this.m_cbEstado, ref this.m_tbCEP, ref this.m_tbInstrucoesPagamento, ref this.m_tbObs);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbBanco,ref this.m_tbAgencia, ref this.m_tbConta, ref this.m_tbEndereco, ref this.m_tbBairro, ref this.m_tbCidade, ref this.m_cbEstado,ref this.m_tbCEP,ref this.m_tbInstrucoesPagamento,ref this.m_tbObs,ref this.m_tbTelefone, ref this.m_tbFax);
		} 

		protected virtual void OnCallSalvaDadosInterfaceCadastro()
		{
			if (eCallSalvaDadosInterfaceCadastro != null)
				eCallSalvaDadosInterfaceCadastro(ref this.m_cbBanco,ref this.m_cbAgencia,ref this.m_cbConta,ref this.m_tbEndereco,ref this.m_tbBairro,ref this.m_tbCidade,ref this.m_cbEstado,ref this.m_tbCEP,ref this.m_tbInstrucoesPagamento,ref this.m_tbObs,ref this.m_tbTelefone, ref this.m_tbFax);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastraNovo);
		}
		protected virtual void OnCallSalvaDadosBDCadastro()
		{
			if (eCallSalvaDadosBDCadastro != null)
				eCallSalvaDadosBDCadastro(this.m_bCadastraNovo);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBancoExportadorCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lTelefone = new System.Windows.Forms.Label();
			this.m_tbFax = new mdlComponentesGraficos.TextBox();
			this.m_lFax = new System.Windows.Forms.Label();
			this.m_tbTelefone = new mdlComponentesGraficos.TextBox();
			this.m_tbObs = new System.Windows.Forms.TextBox();
			this.m_tbInstrucoesPagamento = new System.Windows.Forms.TextBox();
			this.m_lObs = new System.Windows.Forms.Label();
			this.m_lInstrucoesPagamento = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_tbCEP = new mdlComponentesGraficos.TextBox();
			this.m_lCEP = new System.Windows.Forms.Label();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_tbCidade = new mdlComponentesGraficos.TextBox();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_tbBairro = new mdlComponentesGraficos.TextBox();
			this.m_lBairro = new System.Windows.Forms.Label();
			this.m_tbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_cbConta = new mdlComponentesGraficos.ComboBox();
			this.m_cbAgencia = new mdlComponentesGraficos.ComboBox();
			this.m_tbConta = new mdlComponentesGraficos.TextBox();
			this.m_tbAgencia = new mdlComponentesGraficos.TextBox();
			this.m_lConta = new System.Windows.Forms.Label();
			this.m_lAgencia = new System.Windows.Forms.Label();
			this.m_cbBanco = new mdlComponentesGraficos.ComboBox();
			this.m_tbBanco = new mdlComponentesGraficos.TextBox();
			this.m_lBanco = new System.Windows.Forms.Label();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
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
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(382, 361);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(131, 330);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 16;
			this.m_ttCadastroBanco.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(195, 330);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 17;
			this.m_ttCadastroBanco.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lTelefone);
			this.m_gbFields.Controls.Add(this.m_tbFax);
			this.m_gbFields.Controls.Add(this.m_lFax);
			this.m_gbFields.Controls.Add(this.m_tbTelefone);
			this.m_gbFields.Controls.Add(this.m_tbObs);
			this.m_gbFields.Controls.Add(this.m_tbInstrucoesPagamento);
			this.m_gbFields.Controls.Add(this.m_lObs);
			this.m_gbFields.Controls.Add(this.m_lInstrucoesPagamento);
			this.m_gbFields.Controls.Add(this.m_cbEstado);
			this.m_gbFields.Controls.Add(this.m_tbCEP);
			this.m_gbFields.Controls.Add(this.m_lCEP);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_tbCidade);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_tbBairro);
			this.m_gbFields.Controls.Add(this.m_lBairro);
			this.m_gbFields.Controls.Add(this.m_tbEndereco);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Controls.Add(this.m_cbConta);
			this.m_gbFields.Controls.Add(this.m_cbAgencia);
			this.m_gbFields.Controls.Add(this.m_tbConta);
			this.m_gbFields.Controls.Add(this.m_tbAgencia);
			this.m_gbFields.Controls.Add(this.m_lConta);
			this.m_gbFields.Controls.Add(this.m_lAgencia);
			this.m_gbFields.Controls.Add(this.m_cbBanco);
			this.m_gbFields.Controls.Add(this.m_tbBanco);
			this.m_gbFields.Controls.Add(this.m_lBanco);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(366, 318);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_lTelefone
			// 
			this.m_lTelefone.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone.Location = new System.Drawing.Point(8, 145);
			this.m_lTelefone.Name = "m_lTelefone";
			this.m_lTelefone.Size = new System.Drawing.Size(56, 16);
			this.m_lTelefone.TabIndex = 0;
			this.m_lTelefone.Text = "Telefone:";
			// 
			// m_tbFax
			// 
			this.m_tbFax.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbFax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFax.Location = new System.Drawing.Point(194, 137);
			this.m_tbFax.Name = "m_tbFax";
			this.m_tbFax.TabIndex = 11;
			this.m_tbFax.Text = "";
			// 
			// m_lFax
			// 
			this.m_lFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFax.Location = new System.Drawing.Point(167, 141);
			this.m_lFax.Name = "m_lFax";
			this.m_lFax.Size = new System.Drawing.Size(29, 16);
			this.m_lFax.TabIndex = 0;
			this.m_lFax.Text = "Fax:";
			// 
			// m_tbTelefone
			// 
			this.m_tbTelefone.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbTelefone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTelefone.Location = new System.Drawing.Point(80, 137);
			this.m_tbTelefone.Name = "m_tbTelefone";
			this.m_tbTelefone.Size = new System.Drawing.Size(85, 20);
			this.m_tbTelefone.TabIndex = 10;
			this.m_tbTelefone.Text = "";
			// 
			// m_tbObs
			// 
			this.m_tbObs.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbObs.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbObs.Location = new System.Drawing.Point(80, 247);
			this.m_tbObs.Multiline = true;
			this.m_tbObs.Name = "m_tbObs";
			this.m_tbObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_tbObs.Size = new System.Drawing.Size(279, 61);
			this.m_tbObs.TabIndex = 15;
			this.m_tbObs.Text = "";
			// 
			// m_tbInstrucoesPagamento
			// 
			this.m_tbInstrucoesPagamento.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbInstrucoesPagamento.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbInstrucoesPagamento.Location = new System.Drawing.Point(80, 184);
			this.m_tbInstrucoesPagamento.Multiline = true;
			this.m_tbInstrucoesPagamento.Name = "m_tbInstrucoesPagamento";
			this.m_tbInstrucoesPagamento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_tbInstrucoesPagamento.Size = new System.Drawing.Size(279, 61);
			this.m_tbInstrucoesPagamento.TabIndex = 14;
			this.m_tbInstrucoesPagamento.Text = "";
			// 
			// m_lObs
			// 
			this.m_lObs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lObs.Location = new System.Drawing.Point(8, 252);
			this.m_lObs.Name = "m_lObs";
			this.m_lObs.Size = new System.Drawing.Size(34, 16);
			this.m_lObs.TabIndex = 0;
			this.m_lObs.Text = "Obs.:";
			// 
			// m_lInstrucoesPagamento
			// 
			this.m_lInstrucoesPagamento.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lInstrucoesPagamento.Location = new System.Drawing.Point(8, 192);
			this.m_lInstrucoesPagamento.Name = "m_lInstrucoesPagamento";
			this.m_lInstrucoesPagamento.Size = new System.Drawing.Size(71, 41);
			this.m_lInstrucoesPagamento.TabIndex = 0;
			this.m_lInstrucoesPagamento.Text = "Instruções de Pagamento:";
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbEstado.AutoCompleteCaseSensitive = false;
			this.m_cbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbEstado.GoToNextControlWithEnter = true;
			this.m_cbEstado.Location = new System.Drawing.Point(80, 160);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(50, 22);
			this.m_cbEstado.TabIndex = 12;
			this.m_ttCadastroBanco.SetToolTip(this.m_cbEstado, "Selecione o estado");
			// 
			// m_tbCEP
			// 
			this.m_tbCEP.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbCEP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCEP.Location = new System.Drawing.Point(237, 160);
			this.m_tbCEP.Mask = true;
			this.m_tbCEP.MaskText = "NNNNN-NNN";
			this.m_tbCEP.Name = "m_tbCEP";
			this.m_tbCEP.Size = new System.Drawing.Size(122, 20);
			this.m_tbCEP.TabIndex = 13;
			this.m_tbCEP.Text = "";
			this.m_tbCEP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbCEP_KeyUp);
			// 
			// m_lCEP
			// 
			this.m_lCEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCEP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCEP.Location = new System.Drawing.Point(198, 165);
			this.m_lCEP.Name = "m_lCEP";
			this.m_lCEP.Size = new System.Drawing.Size(33, 16);
			this.m_lCEP.TabIndex = 0;
			this.m_lCEP.Text = "CEP:";
			// 
			// m_lEstado
			// 
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(8, 168);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(48, 16);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			// 
			// m_tbCidade
			// 
			this.m_tbCidade.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCidade.Location = new System.Drawing.Point(80, 114);
			this.m_tbCidade.Name = "m_tbCidade";
			this.m_tbCidade.Size = new System.Drawing.Size(279, 20);
			this.m_tbCidade.TabIndex = 9;
			this.m_tbCidade.Text = "";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 121);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(48, 16);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			// 
			// m_tbBairro
			// 
			this.m_tbBairro.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbBairro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbBairro.Location = new System.Drawing.Point(80, 92);
			this.m_tbBairro.Name = "m_tbBairro";
			this.m_tbBairro.Size = new System.Drawing.Size(279, 20);
			this.m_tbBairro.TabIndex = 8;
			this.m_tbBairro.Text = "";
			// 
			// m_lBairro
			// 
			this.m_lBairro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBairro.Location = new System.Drawing.Point(8, 97);
			this.m_lBairro.Name = "m_lBairro";
			this.m_lBairro.Size = new System.Drawing.Size(41, 16);
			this.m_lBairro.TabIndex = 0;
			this.m_lBairro.Text = "Bairro:";
			// 
			// m_tbEndereco
			// 
			this.m_tbEndereco.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbEndereco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEndereco.Location = new System.Drawing.Point(80, 70);
			this.m_tbEndereco.Name = "m_tbEndereco";
			this.m_tbEndereco.Size = new System.Drawing.Size(279, 20);
			this.m_tbEndereco.TabIndex = 7;
			this.m_tbEndereco.Text = "";
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEndereco.Location = new System.Drawing.Point(8, 74);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(61, 16);
			this.m_lEndereco.TabIndex = 0;
			this.m_lEndereco.Text = "Endereço:";
			// 
			// m_cbConta
			// 
			this.m_cbConta.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbConta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbConta.GoToNextControlWithEnter = true;
			this.m_cbConta.ItemHeight = 14;
			this.m_cbConta.Location = new System.Drawing.Point(224, 46);
			this.m_cbConta.Name = "m_cbConta";
			this.m_cbConta.Size = new System.Drawing.Size(135, 22);
			this.m_cbConta.TabIndex = 5;
			this.m_ttCadastroBanco.SetToolTip(this.m_cbConta, "Cadastre uma nova conta, ou selecione uma existente");
			// 
			// m_cbAgencia
			// 
			this.m_cbAgencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbAgencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbAgencia.GoToNextControlWithEnter = true;
			this.m_cbAgencia.Location = new System.Drawing.Point(80, 46);
			this.m_cbAgencia.Name = "m_cbAgencia";
			this.m_cbAgencia.Size = new System.Drawing.Size(101, 22);
			this.m_cbAgencia.TabIndex = 3;
			this.m_ttCadastroBanco.SetToolTip(this.m_cbAgencia, "Cadastre uma nova agência, ou selecione uma existente");
			this.m_cbAgencia.TextChanged += new System.EventHandler(this.m_cbAgencia_TextChanged);
			// 
			// m_tbConta
			// 
			this.m_tbConta.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbConta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbConta.Location = new System.Drawing.Point(224, 46);
			this.m_tbConta.Name = "m_tbConta";
			this.m_tbConta.Size = new System.Drawing.Size(135, 20);
			this.m_tbConta.TabIndex = 6;
			this.m_tbConta.Text = "";
			this.m_tbConta.Visible = false;
			// 
			// m_tbAgencia
			// 
			this.m_tbAgencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbAgencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbAgencia.Location = new System.Drawing.Point(80, 46);
			this.m_tbAgencia.Name = "m_tbAgencia";
			this.m_tbAgencia.Size = new System.Drawing.Size(101, 20);
			this.m_tbAgencia.TabIndex = 4;
			this.m_tbAgencia.Text = "";
			this.m_tbAgencia.Visible = false;
			// 
			// m_lConta
			// 
			this.m_lConta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lConta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lConta.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lConta.Location = new System.Drawing.Point(183, 48);
			this.m_lConta.Name = "m_lConta";
			this.m_lConta.Size = new System.Drawing.Size(41, 16);
			this.m_lConta.TabIndex = 0;
			this.m_lConta.Text = "Conta:";
			// 
			// m_lAgencia
			// 
			this.m_lAgencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAgencia.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lAgencia.Location = new System.Drawing.Point(8, 51);
			this.m_lAgencia.Name = "m_lAgencia";
			this.m_lAgencia.Size = new System.Drawing.Size(53, 16);
			this.m_lAgencia.TabIndex = 0;
			this.m_lAgencia.Text = "Agência:";
			// 
			// m_cbBanco
			// 
			this.m_cbBanco.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_cbBanco.AutoCompleteCaseSensitive = false;
			this.m_cbBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbBanco.GoToNextControlWithEnter = true;
			this.m_cbBanco.Location = new System.Drawing.Point(80, 22);
			this.m_cbBanco.Name = "m_cbBanco";
			this.m_cbBanco.Size = new System.Drawing.Size(279, 22);
			this.m_cbBanco.TabIndex = 1;
			this.m_ttCadastroBanco.SetToolTip(this.m_cbBanco, "Cadastre um novo banco, ou selecione um existente");
			this.m_cbBanco.TextChanged += new System.EventHandler(this.m_cbBanco_TextChanged);
			// 
			// m_tbBanco
			// 
			this.m_tbBanco.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbBanco.Location = new System.Drawing.Point(80, 22);
			this.m_tbBanco.Name = "m_tbBanco";
			this.m_tbBanco.Size = new System.Drawing.Size(279, 20);
			this.m_tbBanco.TabIndex = 2;
			this.m_tbBanco.Text = "";
			this.m_tbBanco.Visible = false;
			// 
			// m_lBanco
			// 
			this.m_lBanco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBanco.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.m_lBanco.Location = new System.Drawing.Point(8, 27);
			this.m_lBanco.Name = "m_lBanco";
			this.m_lBanco.Size = new System.Drawing.Size(43, 16);
			this.m_lBanco.TabIndex = 0;
			this.m_lBanco.Text = "Banco:";
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(6, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 18;
			this.m_ttCadastroBanco.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_ttCadastroBanco
			// 
			this.m_ttCadastroBanco.AutomaticDelay = 100;
			this.m_ttCadastroBanco.AutoPopDelay = 5000;
			this.m_ttCadastroBanco.InitialDelay = 100;
			this.m_ttCadastroBanco.ReshowDelay = 20;
			// 
			// frmFBancoExportadorCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 363);
			this.Controls.Add(this.m_btTrocarCor);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBancoExportadorCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Banco do Exportador";
			this.Load += new System.EventHandler(this.frmFBancoExportadorCadEdit_Load);
			this.Activated += new System.EventHandler(this.frmFBancoExportadorCadEdit_Activated);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
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
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				if (m_formFBancoExportador != null)
					m_formFBancoExportador.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFBancoExportadorCadEdit_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				if (m_bCadastraNovo == false)
				{
					this.m_tbAgencia.Visible = true;
					this.m_cbAgencia.Visible = false;
					this.m_tbConta.Visible = true;
					this.m_cbConta.Visible = false;
					this.m_tbBanco.Visible = true;
					this.m_cbBanco.Visible = false;
					OnCallCarregaDadosInterface();
				} 
				else
				{
					this.m_tbAgencia.Visible = false;
					this.m_cbAgencia.Visible = true;
					this.m_tbConta.Visible = false;
					this.m_cbConta.Visible = true;
					this.m_tbBanco.Visible = false;
					this.m_cbBanco.Visible = true;
					OnCallCarregaDadosInterfaceCadastro();
				}
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banco
		private void m_cbBanco_TextChanged(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterfaceComboBoxAgencias();
			OnCallCarregaDadosInterfaceComboBoxContas();
		}
		#endregion
		#region Agencia
		private void m_cbAgencia_TextChanged(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterfaceComboBoxContas();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_bCadastraNovo == true)
				{
					#region Cadastrando Novo
					if (this.m_cbBanco.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarBanco));
						this.m_tbBanco.Focus();
					}
					else if (this.m_cbAgencia.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarAgencia));
						this.m_tbAgencia.Focus();
					}
					else if (this.m_cbConta.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_CadastrarSelecionarConta));
						this.m_tbConta.Focus();
					} 
					else if ((!this.m_tbCEP.bTextValidWithTheMask()) && (this.m_tbCEP.Text.Trim() != ""))
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_CorrigirCEP));
						this.m_tbCEP.Focus();
					}
					else
					{
						OnCallSalvaDadosInterfaceCadastro();
						OnCallSalvaDadosBDCadastro();
						this.Close();
					}
					#endregion
				} 
				else 
				{
					#region Editando um Banco/Agência/Conta existente
					if (this.m_tbBanco.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_EditarBanco));
						//MessageBox.Show("Digite o nome do banco desejado.",this.Text);
						this.m_tbBanco.Focus();
					}
					else if (this.m_tbAgencia.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_EditarAgencia));
						//MessageBox.Show("Digite a identificação da agência.",this.Text);
						this.m_tbAgencia.Focus();
					}
					else if (this.m_tbConta.Text == "")
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_EditarConta));
						//MessageBox.Show("Digite a identicação da conta.",this.Text);
						this.m_tbConta.Focus();
					} 
//					else if (this.m_cbEstado.ReturnObjectSelectedItem() == null)
//					{
//						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_SelecionarEstado));
//						//MessageBox.Show("Selecione um estado.",this.Text);
//						this.m_cbEstado.SelectedIndex = 0;
//						this.m_cbEstado.Focus();
//					}
					else if ((!this.m_tbCEP.bTextValidWithTheMask()) && (this.m_tbCEP.Text.Trim() != ""))
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBancos_frmFBancoExportadorCadEdit_CorrigirCEP));
						//MessageBox.Show("CEP no formato XXXXX-XX.",this.Text);
						this.m_tbCEP.Focus();
					}
					else
					{
						OnCallSalvaDadosInterface();
						OnCallSalvaDadosBDCadastro();
						this.Close();
					}
					#endregion
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Activated
		private void frmFBancoExportadorCadEdit_Activated(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bCadastraNovo == false)
					m_tbBanco.Focus();
				else
					m_cbBanco.Focus();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region CEP Key Up
		private void m_tbCEP_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (m_tbCEP.Text.Length > 0 && (e.KeyCode != System.Windows.Forms.Keys.Back))
				{
					switch (m_tbCEP.Text.Length)
					{
						case 5: m_tbCEP.Text += "-";
							break;
					}
					m_tbCEP.SelectionStart = m_tbCEP.Text.Length;
				}
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
