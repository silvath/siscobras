using System;
using System.Collections;
//using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContas
{
	/// <summary>
	/// Summary description for frmFContasCadEdit.
	/// </summary>
	internal class frmFContasCadEdit : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		public bool m_bModificado = false;

		private bool m_bAtivado = true;

		private bool m_bCadastraNovo = false;

		private frmFContas m_formFContas = null;

		private System.Windows.Forms.GroupBox m_gbFrame;
		internal System.Windows.Forms.Button m_btTrocarCor;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lEstado;
		private System.Windows.Forms.Label m_lTelefone1;
		private System.Windows.Forms.Label m_lLogradouro;
		private System.Windows.Forms.Label m_lBairro;
		private System.Windows.Forms.Label m_lNomeFantasia;
		private System.Windows.Forms.Label m_lExportador;
		private System.Windows.Forms.Label m_lFax;
		private System.Windows.Forms.Label m_lEMail;
		private System.Windows.Forms.Label m_lSite;
		private System.Windows.Forms.Label m_lCNPJ;
		private System.Windows.Forms.Label m_lCEP;
		private mdlComponentesGraficos.ComboBox m_cbEstado;
		private System.Windows.Forms.Label m_lCidade;
		private System.Windows.Forms.Label m_lTelefone2;
		private System.Windows.Forms.Label m_lCelular;
		private mdlComponentesGraficos.TextBox m_tbExportador;
		private mdlComponentesGraficos.TextBox m_tbLogradouro;
		private mdlComponentesGraficos.TextBox m_tbEMail;
		private mdlComponentesGraficos.TextBox m_tbSite;
		private mdlComponentesGraficos.TextBox m_tbNomeFantasia;
		private mdlComponentesGraficos.TextBox m_tbBairro;
		private mdlComponentesGraficos.TextBox m_tbCidade;
		private mdlComponentesGraficos.TextBox m_tbTelefone1;
		private mdlComponentesGraficos.TextBox m_tbFax;
		private mdlComponentesGraficos.TextBox m_tbCNPJ;
		private mdlComponentesGraficos.TextBox m_tbCEP;
		private mdlComponentesGraficos.TextBox m_tbTelefone2;
		private mdlComponentesGraficos.TextBox m_tbCelular;
		private System.Windows.Forms.ToolTip m_ttConta;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFContasCadEdit(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, ref frmFContas formContas)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_formFContas = formContas;
		}
		public frmFContasCadEdit(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, ref frmFContas formContas, bool CadastraNovo)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_formFContas = formContas;
			m_bCadastraNovo = CadastraNovo;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try
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
			catch
			{
			}
		}

		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbExportador, ref mdlComponentesGraficos.TextBox tbNomeFantasia, ref mdlComponentesGraficos.TextBox tbCNPJ, ref mdlComponentesGraficos.TextBox tbLogradouro, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCep, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbTel1, ref mdlComponentesGraficos.TextBox tbTel2, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.TextBox tbCelular, ref mdlComponentesGraficos.TextBox tbEMail, ref mdlComponentesGraficos.TextBox tbSite);
		public delegate void delCallCarregaDadosInterfaceEstados(ref mdlComponentesGraficos.ComboBox cbEstados);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbExportador, ref mdlComponentesGraficos.TextBox tbNomeFantasia, ref mdlComponentesGraficos.TextBox tbCNPJ, ref mdlComponentesGraficos.TextBox tbLogradouro, ref mdlComponentesGraficos.TextBox tbBairro, ref mdlComponentesGraficos.TextBox tbCep, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbEstado, ref mdlComponentesGraficos.TextBox tbTel1, ref mdlComponentesGraficos.TextBox tbTel2, ref mdlComponentesGraficos.TextBox tbFax, ref mdlComponentesGraficos.TextBox tbCelular, ref mdlComponentesGraficos.TextBox tbEMail, ref mdlComponentesGraficos.TextBox tbSite);
		public delegate void delCallSalvaDadosBD(bool cadastraNovo);
		// Testando
		public delegate void delCallSugereNomeFantasia(ref mdlComponentesGraficos.TextBox tbRazaoSocial, ref mdlComponentesGraficos.TextBox tbNomeFantasia);
		#endregion
		#region Events
		// Events BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallCarregaDadosInterfaceEstados eCallCarregaDadosInterfaceEstados;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Testando
		public event delCallSugereNomeFantasia eCallSugereNomeFantasia;
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
				eCallCarregaDadosInterface(ref this.m_tbExportador, ref this.m_tbNomeFantasia, ref this.m_tbCNPJ, ref this.m_tbLogradouro, ref this.m_tbBairro, ref this.m_tbCEP, ref this.m_tbCidade, ref this.m_cbEstado, ref this.m_tbTelefone1, ref this.m_tbTelefone2, ref this.m_tbFax, ref this.m_tbCelular, ref this.m_tbEMail, ref this.m_tbSite);
		}
		protected virtual void OnCallCarregaDadosInterfaceEstados()
		{
			if (eCallCarregaDadosInterfaceEstados != null)
				eCallCarregaDadosInterfaceEstados(ref this.m_cbEstado);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}

		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_tbExportador, ref this.m_tbNomeFantasia, ref this.m_tbCNPJ, ref this.m_tbLogradouro, ref this.m_tbBairro, ref this.m_tbCEP, ref this.m_tbCidade, ref this.m_cbEstado, ref this.m_tbTelefone1, ref this.m_tbTelefone2, ref this.m_tbFax, ref this.m_tbCelular, ref this.m_tbEMail, ref this.m_tbSite);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bCadastraNovo);
		}
		protected virtual void OnCallSugereNomeFantasia()
		{
			if (eCallSugereNomeFantasia != null)
				eCallSugereNomeFantasia(ref m_tbExportador, ref m_tbNomeFantasia);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContasCadEdit));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbCelular = new mdlComponentesGraficos.TextBox();
			this.m_tbTelefone2 = new mdlComponentesGraficos.TextBox();
			this.m_tbCEP = new mdlComponentesGraficos.TextBox();
			this.m_tbCNPJ = new mdlComponentesGraficos.TextBox();
			this.m_tbFax = new mdlComponentesGraficos.TextBox();
			this.m_tbTelefone1 = new mdlComponentesGraficos.TextBox();
			this.m_tbCidade = new mdlComponentesGraficos.TextBox();
			this.m_tbBairro = new mdlComponentesGraficos.TextBox();
			this.m_tbNomeFantasia = new mdlComponentesGraficos.TextBox();
			this.m_tbSite = new mdlComponentesGraficos.TextBox();
			this.m_tbEMail = new mdlComponentesGraficos.TextBox();
			this.m_tbLogradouro = new mdlComponentesGraficos.TextBox();
			this.m_tbExportador = new mdlComponentesGraficos.TextBox();
			this.m_lCelular = new System.Windows.Forms.Label();
			this.m_lTelefone2 = new System.Windows.Forms.Label();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_cbEstado = new mdlComponentesGraficos.ComboBox();
			this.m_lCEP = new System.Windows.Forms.Label();
			this.m_lCNPJ = new System.Windows.Forms.Label();
			this.m_lSite = new System.Windows.Forms.Label();
			this.m_lEMail = new System.Windows.Forms.Label();
			this.m_lFax = new System.Windows.Forms.Label();
			this.m_lTelefone1 = new System.Windows.Forms.Label();
			this.m_lLogradouro = new System.Windows.Forms.Label();
			this.m_lEstado = new System.Windows.Forms.Label();
			this.m_lBairro = new System.Windows.Forms.Label();
			this.m_lNomeFantasia = new System.Windows.Forms.Label();
			this.m_lExportador = new System.Windows.Forms.Label();
			this.m_ttConta = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(446, 293);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 17;
			this.m_ttConta.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(163, 263);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 24);
			this.m_btOk.TabIndex = 15;
			this.m_ttConta.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(227, 263);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 24);
			this.m_btCancelar.TabIndex = 16;
			this.m_ttConta.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			this.m_btCancelar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btCancelar_MouseUp);
			this.m_btCancelar.MouseEnter += new System.EventHandler(this.m_btCancelar_MouseEnter);
			this.m_btCancelar.MouseLeave += new System.EventHandler(this.m_btCancelar_MouseLeave);
			this.m_btCancelar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_btCancelar_MouseDown);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbCelular);
			this.m_gbFields.Controls.Add(this.m_tbTelefone2);
			this.m_gbFields.Controls.Add(this.m_tbCEP);
			this.m_gbFields.Controls.Add(this.m_tbCNPJ);
			this.m_gbFields.Controls.Add(this.m_tbFax);
			this.m_gbFields.Controls.Add(this.m_tbTelefone1);
			this.m_gbFields.Controls.Add(this.m_tbCidade);
			this.m_gbFields.Controls.Add(this.m_tbBairro);
			this.m_gbFields.Controls.Add(this.m_tbNomeFantasia);
			this.m_gbFields.Controls.Add(this.m_tbSite);
			this.m_gbFields.Controls.Add(this.m_tbEMail);
			this.m_gbFields.Controls.Add(this.m_tbLogradouro);
			this.m_gbFields.Controls.Add(this.m_tbExportador);
			this.m_gbFields.Controls.Add(this.m_lCelular);
			this.m_gbFields.Controls.Add(this.m_lTelefone2);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_cbEstado);
			this.m_gbFields.Controls.Add(this.m_lCEP);
			this.m_gbFields.Controls.Add(this.m_lCNPJ);
			this.m_gbFields.Controls.Add(this.m_lSite);
			this.m_gbFields.Controls.Add(this.m_lEMail);
			this.m_gbFields.Controls.Add(this.m_lFax);
			this.m_gbFields.Controls.Add(this.m_lTelefone1);
			this.m_gbFields.Controls.Add(this.m_lLogradouro);
			this.m_gbFields.Controls.Add(this.m_lEstado);
			this.m_gbFields.Controls.Add(this.m_lBairro);
			this.m_gbFields.Controls.Add(this.m_lNomeFantasia);
			this.m_gbFields.Controls.Add(this.m_lExportador);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(430, 250);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbCelular
			// 
			this.m_tbCelular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCelular.Location = new System.Drawing.Point(280, 169);
			this.m_tbCelular.Name = "m_tbCelular";
			this.m_tbCelular.Size = new System.Drawing.Size(136, 20);
			this.m_tbCelular.TabIndex = 12;
			this.m_tbCelular.Text = "";
			// 
			// m_tbTelefone2
			// 
			this.m_tbTelefone2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTelefone2.Location = new System.Drawing.Point(280, 145);
			this.m_tbTelefone2.Name = "m_tbTelefone2";
			this.m_tbTelefone2.Size = new System.Drawing.Size(136, 20);
			this.m_tbTelefone2.TabIndex = 10;
			this.m_tbTelefone2.Text = "";
			// 
			// m_tbCEP
			// 
			this.m_tbCEP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCEP.Location = new System.Drawing.Point(280, 97);
			this.m_tbCEP.Mask = true;
			this.m_tbCEP.MaskText = "NNNNN-NNN";
			this.m_tbCEP.Name = "m_tbCEP";
			this.m_tbCEP.Size = new System.Drawing.Size(136, 20);
			this.m_tbCEP.TabIndex = 6;
			this.m_tbCEP.Text = "";
			this.m_tbCEP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbCEP_KeyUp);
			// 
			// m_tbCNPJ
			// 
			this.m_tbCNPJ.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCNPJ.Location = new System.Drawing.Point(280, 49);
			this.m_tbCNPJ.Mask = true;
			this.m_tbCNPJ.MaskText = "NN.NNN.NNN/NNNN-NN";
			this.m_tbCNPJ.Name = "m_tbCNPJ";
			this.m_tbCNPJ.Size = new System.Drawing.Size(136, 20);
			this.m_tbCNPJ.TabIndex = 3;
			this.m_tbCNPJ.Text = "";
			this.m_tbCNPJ.Leave += new System.EventHandler(this.m_tbCNPJ_Leave);
			this.m_tbCNPJ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tbCNPJ_KeyUp);
			// 
			// m_tbFax
			// 
			this.m_tbFax.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFax.Location = new System.Drawing.Point(104, 169);
			this.m_tbFax.Name = "m_tbFax";
			this.m_tbFax.Size = new System.Drawing.Size(120, 20);
			this.m_tbFax.TabIndex = 11;
			this.m_tbFax.Text = "";
			// 
			// m_tbTelefone1
			// 
			this.m_tbTelefone1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbTelefone1.Location = new System.Drawing.Point(104, 145);
			this.m_tbTelefone1.Name = "m_tbTelefone1";
			this.m_tbTelefone1.Size = new System.Drawing.Size(120, 20);
			this.m_tbTelefone1.TabIndex = 9;
			this.m_tbTelefone1.Text = "";
			// 
			// m_tbCidade
			// 
			this.m_tbCidade.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbCidade.Location = new System.Drawing.Point(104, 121);
			this.m_tbCidade.Name = "m_tbCidade";
			this.m_tbCidade.Size = new System.Drawing.Size(120, 20);
			this.m_tbCidade.TabIndex = 7;
			this.m_tbCidade.Text = "";
			// 
			// m_tbBairro
			// 
			this.m_tbBairro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbBairro.Location = new System.Drawing.Point(104, 97);
			this.m_tbBairro.Name = "m_tbBairro";
			this.m_tbBairro.Size = new System.Drawing.Size(120, 20);
			this.m_tbBairro.TabIndex = 5;
			this.m_tbBairro.Text = "";
			// 
			// m_tbNomeFantasia
			// 
			this.m_tbNomeFantasia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbNomeFantasia.Location = new System.Drawing.Point(104, 49);
			this.m_tbNomeFantasia.Name = "m_tbNomeFantasia";
			this.m_tbNomeFantasia.Size = new System.Drawing.Size(120, 20);
			this.m_tbNomeFantasia.TabIndex = 2;
			this.m_tbNomeFantasia.Text = "";
			// 
			// m_tbSite
			// 
			this.m_tbSite.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbSite.Location = new System.Drawing.Point(104, 217);
			this.m_tbSite.Name = "m_tbSite";
			this.m_tbSite.Size = new System.Drawing.Size(312, 20);
			this.m_tbSite.TabIndex = 14;
			this.m_tbSite.Text = "";
			// 
			// m_tbEMail
			// 
			this.m_tbEMail.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbEMail.Location = new System.Drawing.Point(104, 193);
			this.m_tbEMail.Name = "m_tbEMail";
			this.m_tbEMail.Size = new System.Drawing.Size(312, 20);
			this.m_tbEMail.TabIndex = 13;
			this.m_tbEMail.Text = "";
			// 
			// m_tbLogradouro
			// 
			this.m_tbLogradouro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbLogradouro.Location = new System.Drawing.Point(104, 73);
			this.m_tbLogradouro.Name = "m_tbLogradouro";
			this.m_tbLogradouro.Size = new System.Drawing.Size(312, 20);
			this.m_tbLogradouro.TabIndex = 4;
			this.m_tbLogradouro.Text = "";
			// 
			// m_tbExportador
			// 
			this.m_tbExportador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbExportador.Location = new System.Drawing.Point(104, 25);
			this.m_tbExportador.Name = "m_tbExportador";
			this.m_tbExportador.Size = new System.Drawing.Size(312, 20);
			this.m_tbExportador.TabIndex = 1;
			this.m_tbExportador.Text = "";
			this.m_tbExportador.Leave += new System.EventHandler(this.m_tbExportador_Leave);
			// 
			// m_lCelular
			// 
			this.m_lCelular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCelular.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCelular.Location = new System.Drawing.Point(229, 167);
			this.m_lCelular.Name = "m_lCelular";
			this.m_lCelular.Size = new System.Drawing.Size(47, 15);
			this.m_lCelular.TabIndex = 0;
			this.m_lCelular.Text = "Celular:";
			// 
			// m_lTelefone2
			// 
			this.m_lTelefone2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lTelefone2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone2.Location = new System.Drawing.Point(229, 143);
			this.m_lTelefone2.Name = "m_lTelefone2";
			this.m_lTelefone2.Size = new System.Drawing.Size(39, 15);
			this.m_lTelefone2.TabIndex = 0;
			this.m_lTelefone2.Text = "Tel. 2:";
			// 
			// m_lCidade
			// 
			this.m_lCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCidade.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCidade.Location = new System.Drawing.Point(8, 119);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(47, 15);
			this.m_lCidade.TabIndex = 0;
			this.m_lCidade.Text = "Cidade:";
			// 
			// m_cbEstado
			// 
			this.m_cbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbEstado.AutoCompleteCaseSensitive = false;
			this.m_cbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbEstado.GoToNextControlWithEnter = true;
			this.m_cbEstado.Location = new System.Drawing.Point(280, 119);
			this.m_cbEstado.Name = "m_cbEstado";
			this.m_cbEstado.Size = new System.Drawing.Size(45, 22);
			this.m_cbEstado.TabIndex = 8;
			// 
			// m_lCEP
			// 
			this.m_lCEP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCEP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCEP.Location = new System.Drawing.Point(229, 95);
			this.m_lCEP.Name = "m_lCEP";
			this.m_lCEP.Size = new System.Drawing.Size(33, 15);
			this.m_lCEP.TabIndex = 0;
			this.m_lCEP.Text = "CEP:";
			// 
			// m_lCNPJ
			// 
			this.m_lCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lCNPJ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lCNPJ.Location = new System.Drawing.Point(229, 47);
			this.m_lCNPJ.Name = "m_lCNPJ";
			this.m_lCNPJ.Size = new System.Drawing.Size(41, 15);
			this.m_lCNPJ.TabIndex = 0;
			this.m_lCNPJ.Text = "CNPJ:";
			// 
			// m_lSite
			// 
			this.m_lSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSite.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSite.Location = new System.Drawing.Point(8, 215);
			this.m_lSite.Name = "m_lSite";
			this.m_lSite.Size = new System.Drawing.Size(29, 15);
			this.m_lSite.TabIndex = 0;
			this.m_lSite.Text = "Site:";
			// 
			// m_lEMail
			// 
			this.m_lEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lEMail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEMail.Location = new System.Drawing.Point(8, 191);
			this.m_lEMail.Name = "m_lEMail";
			this.m_lEMail.Size = new System.Drawing.Size(43, 15);
			this.m_lEMail.TabIndex = 0;
			this.m_lEMail.Text = "E-mail:";
			// 
			// m_lFax
			// 
			this.m_lFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFax.Location = new System.Drawing.Point(8, 167);
			this.m_lFax.Name = "m_lFax";
			this.m_lFax.Size = new System.Drawing.Size(29, 15);
			this.m_lFax.TabIndex = 0;
			this.m_lFax.Text = "Fax:";
			// 
			// m_lTelefone1
			// 
			this.m_lTelefone1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lTelefone1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTelefone1.Location = new System.Drawing.Point(8, 143);
			this.m_lTelefone1.Name = "m_lTelefone1";
			this.m_lTelefone1.Size = new System.Drawing.Size(66, 15);
			this.m_lTelefone1.TabIndex = 0;
			this.m_lTelefone1.Text = "Telefone 1:";
			// 
			// m_lLogradouro
			// 
			this.m_lLogradouro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lLogradouro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lLogradouro.Location = new System.Drawing.Point(8, 71);
			this.m_lLogradouro.Name = "m_lLogradouro";
			this.m_lLogradouro.Size = new System.Drawing.Size(71, 15);
			this.m_lLogradouro.TabIndex = 0;
			this.m_lLogradouro.Text = "Logradouro:";
			// 
			// m_lEstado
			// 
			this.m_lEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lEstado.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEstado.Location = new System.Drawing.Point(229, 119);
			this.m_lEstado.Name = "m_lEstado";
			this.m_lEstado.Size = new System.Drawing.Size(48, 15);
			this.m_lEstado.TabIndex = 0;
			this.m_lEstado.Text = "Estado:";
			// 
			// m_lBairro
			// 
			this.m_lBairro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lBairro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBairro.Location = new System.Drawing.Point(8, 95);
			this.m_lBairro.Name = "m_lBairro";
			this.m_lBairro.Size = new System.Drawing.Size(41, 15);
			this.m_lBairro.TabIndex = 0;
			this.m_lBairro.Text = "Bairro:";
			// 
			// m_lNomeFantasia
			// 
			this.m_lNomeFantasia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lNomeFantasia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNomeFantasia.Location = new System.Drawing.Point(8, 47);
			this.m_lNomeFantasia.Name = "m_lNomeFantasia";
			this.m_lNomeFantasia.Size = new System.Drawing.Size(92, 16);
			this.m_lNomeFantasia.TabIndex = 0;
			this.m_lNomeFantasia.Text = "Nome Fantasia:";
			// 
			// m_lExportador
			// 
			this.m_lExportador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lExportador.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lExportador.Location = new System.Drawing.Point(8, 23);
			this.m_lExportador.Name = "m_lExportador";
			this.m_lExportador.Size = new System.Drawing.Size(68, 16);
			this.m_lExportador.TabIndex = 0;
			this.m_lExportador.Text = "Exportador:";
			// 
			// m_ttConta
			// 
			this.m_ttConta.AutomaticDelay = 100;
			this.m_ttConta.AutoPopDelay = 5000;
			this.m_ttConta.InitialDelay = 100;
			this.m_ttConta.ReshowDelay = 20;
			// 
			// frmFContasCadEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(450, 295);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContasCadEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Conta Exportador";
			this.Load += new System.EventHandler(this.frmFContasCadEdit_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
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
		#endregion
		#region Mostrar Cor
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
								"mdlComponentes.compTextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
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
		#endregion

		#region Verifica TextBoxes
		private bool verificaCEP()
		{
			bool bRetorno = false;
			string strCepTemp = "";
			try
			{
				if (m_tbCEP.Text.Trim() != "")
				{
					if (m_tbCEP.Text.Length == 8 && m_tbCEP.Text.IndexOf("-") == -1)
					{
						strCepTemp = m_tbCEP.Text.Substring(0,5);
						strCepTemp += "-" + m_tbCEP.Text.Substring(5);
						m_tbCEP.Text = strCepTemp;
						bRetorno = true;
					}
					else
					{
						bRetorno = m_tbCEP.bTextValidWithTheMask();
					}
				}
				else
				{
					bRetorno = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return bRetorno;
		}
		private bool verificaCNPJ()
		{
			bool bRetorno = false;
			string strCnpjTemp = "";
			try
			{
				if (m_tbCNPJ.Text.Trim() != "")
				{
					if (m_tbCNPJ.Text.Length == 14 && m_tbCNPJ.Text.IndexOf("-") == -1 && m_tbCEP.Text.IndexOf("/") == -1)
					{
						strCnpjTemp = m_tbCNPJ.Text.Substring(0,2);
						strCnpjTemp += "." + m_tbCNPJ.Text.Substring(2,3);
						strCnpjTemp += "." + m_tbCNPJ.Text.Substring(5,3);
						strCnpjTemp += "/" + m_tbCNPJ.Text.Substring(8,4);
						strCnpjTemp += "-" + m_tbCNPJ.Text.Substring(12,2);
						m_tbCNPJ.Text = strCnpjTemp;
						bRetorno = true;
					}
					else
					{
						bRetorno = m_tbCNPJ.bTextValidWithTheMask();
					}
				}
				else
				{
					bRetorno = true;
				}
				if (bRetorno)
					bRetorno = mdlValidacao.clsCNPJ.validaCNPJ(m_tbCNPJ.Text);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return bRetorno;
		}
		private bool verificaTextBoxes()
		{
			try
			{
				if (this.m_tbExportador.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_NomeExportadorInvalido));
					//System.Windows.Forms.MessageBox.Show("Digite o nome do Exportador.",this.Text);
					this.m_tbExportador.Text = "Novo Exportador";
					this.m_tbExportador.Focus();
					return false;
				}
				if (this.m_tbNomeFantasia.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_NomeFantasiaInvalido));
					//System.Windows.Forms.MessageBox.Show("Digite o nome fantasia do Exportador.",this.Text);
					this.m_tbNomeFantasia.Text = this.m_tbExportador.Text;
					this.m_tbNomeFantasia.Focus();
					return false;
				}					
				if (!verificaCNPJ())
				{
					if (m_tbCNPJ.Text.Length != 18)
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJFormatoInvalido));
						//System.Windows.Forms.MessageBox.Show("Digite o CNPJ no formato XX.XXX.XXX/XXXX-XX.",this.Text);
					}
					else if ((m_tbCNPJ.Text.Length == 18) && ((m_tbCNPJ.Text.IndexOf(".",0) != 2) || (m_tbCNPJ.Text.IndexOf(".",3) != 6) || (m_tbCNPJ.Text.IndexOf("/",7) != 10) || (m_tbCNPJ.Text.IndexOf("-",11) != 15)))
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJFormatoInvalido));
						//System.Windows.Forms.MessageBox.Show("Digite o CNPJ no formato XX.XXX.XXX/XXXX-XX.",this.Text);
					}
					else
					{
						mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJInvalido));
						//System.Windows.Forms.MessageBox.Show("CNPJ Inválido. Verifique sua digitação.",this.Text);
					}
					this.m_tbCNPJ.Focus();
					return false;
				}					
				if (this.m_tbLogradouro.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_LogradouroInvalido));
					//System.Windows.Forms.MessageBox.Show("Digite o logradouro do Exportador.",this.Text);
					this.m_tbLogradouro.Focus();
					return false;
				}
//				if (this.m_tbBairro.Text.Trim() == "")
//				{
//					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_BairroInvalido));
//					//System.Windows.Forms.MessageBox.Show("Digite o bairro do Exportador.",this.Text);
//					this.m_tbBairro.Focus();
//					return false;
//				}
				if (this.m_tbCidade.Text.Trim() == "")
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CidadeInvalida));
					//System.Windows.Forms.MessageBox.Show("Digite a cidade do Exportador.",this.Text);
					this.m_tbCidade.Focus();
					return false;
				}
				if (this.m_cbEstado.ReturnObjectSelectedItem() == null)
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_EstadoInvalido));
					//System.Windows.Forms.MessageBox.Show("Não há nenhum Estado selecionado.",this.Text);
					this.m_cbEstado.SelectedIndex = 0;
					this.m_cbEstado.Focus();
					return false;
				}
				if (!verificaCEP())
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CEPFormatoInvalido));
					//System.Windows.Forms.MessageBox.Show("Digite o CEP no formato XXXXX-XXX.",this.Text);
					this.m_tbCEP.Focus();
					return false;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
			return true;
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
				if (m_formFContas != null)
					m_formFContas.mostraCor();
			} 
			catch (Exception err) 
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFContasCadEdit_Load(object sender, System.EventArgs e)
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
					OnCallCarregaDadosInterfaceEstados();
					//this.m_gbFields.Text = "Cadastro";
					m_lExportador.ForeColor = System.Drawing.Color.Red;
					m_lNomeFantasia.ForeColor = System.Drawing.Color.Red;
					m_lCNPJ.ForeColor = System.Drawing.Color.Red;
					m_lLogradouro.ForeColor = System.Drawing.Color.Red;
					//m_lBairro.ForeColor = System.Drawing.Color.Red;
					m_lCidade.ForeColor = System.Drawing.Color.Red;
					m_lEstado.ForeColor = System.Drawing.Color.Red;
					//m_lCEP.ForeColor = System.Drawing.Color.Red;
				}
				this.m_tbExportador.Focus();
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region OK
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (verificaTextBoxes())
				{
					this.m_bModificado = true;
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					if (m_formFContas != null)
						this.m_formFContas.refreshAll();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.Close();
				} 
			} 
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region CNPJ Key UP
		private void m_tbCNPJ_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if ((e.KeyData != System.Windows.Forms.Keys.Delete) && (e.KeyData != System.Windows.Forms.Keys.Back) && (!e.Shift) && (!e.Control))
				{
					if ((m_tbCNPJ.Text.Length > 0) && (m_tbCNPJ.Text.Length < 19))// && (e.KeyCode != System.Windows.Forms.Keys.Back)))
					{
						switch (m_tbCNPJ.Text.Length)
						{
							case 2: if (m_tbCNPJ.Text.IndexOf(".",0) == -1)
									{
										m_tbCNPJ.Text += ".";
										m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									}
									else
									{
										m_tbCNPJ.Text = "";
										m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									}
								break;
							case 6: if ((m_tbCNPJ.Text.IndexOf(".",0) == 2) && (m_tbCNPJ.Text.IndexOf(".",3) == -1))
									{
										m_tbCNPJ.Text += ".";
										m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									}
									else
									{
										m_tbCNPJ.Text = "";
										m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									}
								break;
							case 10: if ((m_tbCNPJ.Text.IndexOf(".",0) == 2) && (m_tbCNPJ.Text.IndexOf(".",3) == 6) && (m_tbCNPJ.Text.IndexOf("/",7) == -1))
									 {
									 	 m_tbCNPJ.Text += "/";
										 m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									 }
									 else
									 {
										 m_tbCNPJ.Text = "";
										 m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									 }
								break;
							case 15: if ((m_tbCNPJ.Text.IndexOf(".",0) == 2) && (m_tbCNPJ.Text.IndexOf(".",3) == 6) && (m_tbCNPJ.Text.IndexOf("/",7) == 10) && (m_tbCNPJ.Text.IndexOf("-",11) == -1))
									 {
										 m_tbCNPJ.Text += "-";
										 m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									 }
									 else
									 {
										 m_tbCNPJ.Text = "";
										 m_tbCNPJ.SelectionStart = m_tbCNPJ.Text.Length;
									 }
								break;
							case 18: if ((m_tbCNPJ.SelectionStart == m_tbCNPJ.Text.Length) && ((!e.Shift) && (e.KeyData != System.Windows.Forms.Keys.ShiftKey) && (e.KeyData != System.Windows.Forms.Keys.Tab) && (e.KeyData != System.Windows.Forms.Keys.End)))
									 {
										 if (m_tbCNPJ.bTextValidWithTheMask())
										 {
											 m_tbLogradouro.Focus();
										 }
										 else
										 {
											 mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJFormatoInvalido));
											 //MessageBox.Show("O CNPJ precisa estar no formato XX.XXX.XXX/XXXX-XX",this.Text,System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
											 m_tbCNPJ.Text = "";
											 m_tbCNPJ.Focus();
										 }
									 }
								break;
						}
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
		#region CEP Key UP
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
		#region CNPJ Leave
		private void m_tbCNPJ_Leave(object sender, System.EventArgs e)
		{
			if ((m_tbCNPJ.Text.Trim() != "") && (m_bAtivado))
			{
				m_bAtivado = false;
				try
				{
					if (!verificaCNPJ())
					{
						if (m_tbCNPJ.Text.Length != 18)
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJFormatoInvalido));
							//System.Windows.Forms.MessageBox.Show("Digite o CNPJ no formato XX.XXX.XXX/XXXX-XX.",this.Text);
						}
						else if ((m_tbCNPJ.Text.Length == 18) && ((m_tbCNPJ.Text.IndexOf(".",0) != 2) || (m_tbCNPJ.Text.IndexOf(".",3) != 6) || (m_tbCNPJ.Text.IndexOf("/",7) != 10) || (m_tbCNPJ.Text.IndexOf("-",11) != 15)))
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJFormatoInvalido));
							//System.Windows.Forms.MessageBox.Show("Digite o CNPJ no formato XX.XXX.XXX/XXXX-XX.",this.Text);
						}
						else
						{
							mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlContas_frmFContasCadEdit_CNPJInvalido));
							//System.Windows.Forms.MessageBox.Show("CNPJ Inválido. Verifique sua digitação.",this.Text);
						}
					}
				}
				catch (Exception err)
				{
					Object erro = err;
					m_cls_ter_tratadorErro.trataErro(ref erro);
				}
				m_bAtivado = true;
			}
		}
		#endregion
		#region Cancelar Mouse Down-Up-Enter-Leave
		private void m_btCancelar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_bAtivado = false;
		}
		private void m_btCancelar_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//m_bAtivado = true;
		}
		private void m_btCancelar_MouseEnter(object sender, System.EventArgs e)
		{
			m_bAtivado = false;
		}
		private void m_btCancelar_MouseLeave(object sender, System.EventArgs e)
		{
			if (m_bAtivado == false)
				m_bAtivado = true;
		}
		#endregion
		#region Leave
		private void m_tbExportador_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if ((m_bAtivado) && (m_tbNomeFantasia.Text.Trim() == ""))
				{
					m_bAtivado = false;
					OnCallSugereNomeFantasia();
					m_bAtivado = true;
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
