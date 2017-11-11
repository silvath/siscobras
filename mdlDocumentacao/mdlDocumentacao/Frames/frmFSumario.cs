using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlDocumentacao.Frames
{
	/// <summary>
	/// Summary description for frmFSumario.
	/// </summary>
	internal class frmFSumario : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private bool m_bAtivado = true;
		private bool m_bModificado = false;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lIdentificar;
		private System.Windows.Forms.Label m_lDataEmissao;
		private System.Windows.Forms.Label m_lSeguro;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoSeguro;
		private System.Windows.Forms.DateTimePicker m_dtpkEmissaoSeguro;
		private System.Windows.Forms.Label m_lFitoSanitario;
		private System.Windows.Forms.Label m_lPeso;
		private System.Windows.Forms.Label m_lAnalise;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoFitossanitario;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoPeso;
		private mdlComponentesGraficos.TextBox m_tbIdentificacaoAnalise;
		private System.Windows.Forms.DateTimePicker m_dtpkEmissaoFitossanitario;
		private System.Windows.Forms.DateTimePicker m_dtpkEmissaoPeso;
		private System.Windows.Forms.DateTimePicker m_dtpkEmissaoAnalise;
		#endregion
		private System.Windows.Forms.ToolTip m_ttSumario;
		private System.ComponentModel.IContainer components;

		#region Construtores & Destrutores
		public frmFSumario(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbSeguro, ref System.Windows.Forms.DateTimePicker dtpkSeguro, ref mdlComponentesGraficos.TextBox tbFito, ref System.Windows.Forms.DateTimePicker dtpkFito, ref mdlComponentesGraficos.TextBox tbPeso, ref System.Windows.Forms.DateTimePicker dtpkPeso, ref mdlComponentesGraficos.TextBox tbAnalise, ref System.Windows.Forms.DateTimePicker dtpkAnalise);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbSeguro, ref System.Windows.Forms.DateTimePicker dtpkSeguro, ref mdlComponentesGraficos.TextBox tbFito, ref System.Windows.Forms.DateTimePicker dtpkFito, ref mdlComponentesGraficos.TextBox tbPeso, ref System.Windows.Forms.DateTimePicker dtpkPeso, ref mdlComponentesGraficos.TextBox tbAnalise, ref System.Windows.Forms.DateTimePicker dtpkAnalise);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbIdentificacaoSeguro, ref m_dtpkEmissaoSeguro, ref m_tbIdentificacaoFitossanitario, ref m_dtpkEmissaoFitossanitario, ref m_tbIdentificacaoPeso, ref m_dtpkEmissaoPeso, ref m_tbIdentificacaoAnalise, ref m_dtpkEmissaoAnalise);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbIdentificacaoSeguro, ref m_dtpkEmissaoSeguro, ref m_tbIdentificacaoFitossanitario, ref m_dtpkEmissaoFitossanitario, ref m_tbIdentificacaoPeso, ref m_dtpkEmissaoPeso, ref m_tbIdentificacaoAnalise, ref m_dtpkEmissaoAnalise);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSumario));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_dtpkEmissaoAnalise = new System.Windows.Forms.DateTimePicker();
			this.m_dtpkEmissaoPeso = new System.Windows.Forms.DateTimePicker();
			this.m_dtpkEmissaoFitossanitario = new System.Windows.Forms.DateTimePicker();
			this.m_tbIdentificacaoAnalise = new mdlComponentesGraficos.TextBox();
			this.m_tbIdentificacaoPeso = new mdlComponentesGraficos.TextBox();
			this.m_tbIdentificacaoFitossanitario = new mdlComponentesGraficos.TextBox();
			this.m_lAnalise = new System.Windows.Forms.Label();
			this.m_lPeso = new System.Windows.Forms.Label();
			this.m_lFitoSanitario = new System.Windows.Forms.Label();
			this.m_dtpkEmissaoSeguro = new System.Windows.Forms.DateTimePicker();
			this.m_tbIdentificacaoSeguro = new mdlComponentesGraficos.TextBox();
			this.m_lSeguro = new System.Windows.Forms.Label();
			this.m_lDataEmissao = new System.Windows.Forms.Label();
			this.m_lIdentificar = new System.Windows.Forms.Label();
			this.m_ttSumario = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(398, 190);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttSumario.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(139, 159);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttSumario.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(203, 159);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttSumario.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_dtpkEmissaoAnalise);
			this.m_gbFields.Controls.Add(this.m_dtpkEmissaoPeso);
			this.m_gbFields.Controls.Add(this.m_dtpkEmissaoFitossanitario);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoAnalise);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoPeso);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoFitossanitario);
			this.m_gbFields.Controls.Add(this.m_lAnalise);
			this.m_gbFields.Controls.Add(this.m_lPeso);
			this.m_gbFields.Controls.Add(this.m_lFitoSanitario);
			this.m_gbFields.Controls.Add(this.m_dtpkEmissaoSeguro);
			this.m_gbFields.Controls.Add(this.m_tbIdentificacaoSeguro);
			this.m_gbFields.Controls.Add(this.m_lSeguro);
			this.m_gbFields.Controls.Add(this.m_lDataEmissao);
			this.m_gbFields.Controls.Add(this.m_lIdentificar);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(382, 146);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Identificar e datar";
			// 
			// m_dtpkEmissaoAnalise
			// 
			this.m_dtpkEmissaoAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkEmissaoAnalise.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissaoAnalise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissaoAnalise.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissaoAnalise.Location = new System.Drawing.Point(286, 109);
			this.m_dtpkEmissaoAnalise.Name = "m_dtpkEmissaoAnalise";
			this.m_dtpkEmissaoAnalise.Size = new System.Drawing.Size(88, 21);
			this.m_dtpkEmissaoAnalise.TabIndex = 8;
			this.m_ttSumario.SetToolTip(this.m_dtpkEmissaoAnalise, "Identificar e datar");
			// 
			// m_dtpkEmissaoPeso
			// 
			this.m_dtpkEmissaoPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkEmissaoPeso.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissaoPeso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissaoPeso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissaoPeso.Location = new System.Drawing.Point(286, 85);
			this.m_dtpkEmissaoPeso.Name = "m_dtpkEmissaoPeso";
			this.m_dtpkEmissaoPeso.Size = new System.Drawing.Size(88, 21);
			this.m_dtpkEmissaoPeso.TabIndex = 6;
			this.m_ttSumario.SetToolTip(this.m_dtpkEmissaoPeso, "Identificar e datar");
			// 
			// m_dtpkEmissaoFitossanitario
			// 
			this.m_dtpkEmissaoFitossanitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkEmissaoFitossanitario.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissaoFitossanitario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissaoFitossanitario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissaoFitossanitario.Location = new System.Drawing.Point(286, 61);
			this.m_dtpkEmissaoFitossanitario.Name = "m_dtpkEmissaoFitossanitario";
			this.m_dtpkEmissaoFitossanitario.Size = new System.Drawing.Size(88, 21);
			this.m_dtpkEmissaoFitossanitario.TabIndex = 4;
			this.m_ttSumario.SetToolTip(this.m_dtpkEmissaoFitossanitario, "Identificar e datar");
			// 
			// m_tbIdentificacaoAnalise
			// 
			this.m_tbIdentificacaoAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoAnalise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoAnalise.Location = new System.Drawing.Point(155, 109);
			this.m_tbIdentificacaoAnalise.Name = "m_tbIdentificacaoAnalise";
			this.m_tbIdentificacaoAnalise.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoAnalise.TabIndex = 7;
			this.m_tbIdentificacaoAnalise.Text = "";
			this.m_ttSumario.SetToolTip(this.m_tbIdentificacaoAnalise, "Identificar e datar");
			// 
			// m_tbIdentificacaoPeso
			// 
			this.m_tbIdentificacaoPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoPeso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoPeso.Location = new System.Drawing.Point(155, 85);
			this.m_tbIdentificacaoPeso.Name = "m_tbIdentificacaoPeso";
			this.m_tbIdentificacaoPeso.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoPeso.TabIndex = 5;
			this.m_tbIdentificacaoPeso.Text = "";
			this.m_ttSumario.SetToolTip(this.m_tbIdentificacaoPeso, "Identificar e datar");
			// 
			// m_tbIdentificacaoFitossanitario
			// 
			this.m_tbIdentificacaoFitossanitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoFitossanitario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoFitossanitario.Location = new System.Drawing.Point(155, 61);
			this.m_tbIdentificacaoFitossanitario.Name = "m_tbIdentificacaoFitossanitario";
			this.m_tbIdentificacaoFitossanitario.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoFitossanitario.TabIndex = 3;
			this.m_tbIdentificacaoFitossanitario.Text = "";
			this.m_ttSumario.SetToolTip(this.m_tbIdentificacaoFitossanitario, "Identificar e datar");
			// 
			// m_lAnalise
			// 
			this.m_lAnalise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAnalise.Location = new System.Drawing.Point(8, 114);
			this.m_lAnalise.Name = "m_lAnalise";
			this.m_lAnalise.Size = new System.Drawing.Size(128, 16);
			this.m_lAnalise.TabIndex = 0;
			this.m_lAnalise.Text = "Certificado de Análise:";
			this.m_lAnalise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lPeso
			// 
			this.m_lPeso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPeso.Location = new System.Drawing.Point(8, 88);
			this.m_lPeso.Name = "m_lPeso";
			this.m_lPeso.Size = new System.Drawing.Size(116, 16);
			this.m_lPeso.TabIndex = 0;
			this.m_lPeso.Text = "Certificado de Peso:";
			this.m_lPeso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFitoSanitario
			// 
			this.m_lFitoSanitario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFitoSanitario.Location = new System.Drawing.Point(8, 64);
			this.m_lFitoSanitario.Name = "m_lFitoSanitario";
			this.m_lFitoSanitario.Size = new System.Drawing.Size(144, 16);
			this.m_lFitoSanitario.TabIndex = 0;
			this.m_lFitoSanitario.Text = "Certificado Fitossanitário:";
			this.m_lFitoSanitario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_dtpkEmissaoSeguro
			// 
			this.m_dtpkEmissaoSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpkEmissaoSeguro.CustomFormat = "dd/MM/yyyy";
			this.m_dtpkEmissaoSeguro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpkEmissaoSeguro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpkEmissaoSeguro.Location = new System.Drawing.Point(286, 37);
			this.m_dtpkEmissaoSeguro.Name = "m_dtpkEmissaoSeguro";
			this.m_dtpkEmissaoSeguro.Size = new System.Drawing.Size(88, 21);
			this.m_dtpkEmissaoSeguro.TabIndex = 2;
			this.m_ttSumario.SetToolTip(this.m_dtpkEmissaoSeguro, "Identificar e datar");
			// 
			// m_tbIdentificacaoSeguro
			// 
			this.m_tbIdentificacaoSeguro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbIdentificacaoSeguro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbIdentificacaoSeguro.Location = new System.Drawing.Point(155, 37);
			this.m_tbIdentificacaoSeguro.Name = "m_tbIdentificacaoSeguro";
			this.m_tbIdentificacaoSeguro.Size = new System.Drawing.Size(125, 21);
			this.m_tbIdentificacaoSeguro.TabIndex = 1;
			this.m_tbIdentificacaoSeguro.Text = "";
			this.m_ttSumario.SetToolTip(this.m_tbIdentificacaoSeguro, "Identificar e datar");
			// 
			// m_lSeguro
			// 
			this.m_lSeguro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSeguro.Location = new System.Drawing.Point(8, 38);
			this.m_lSeguro.Name = "m_lSeguro";
			this.m_lSeguro.Size = new System.Drawing.Size(48, 16);
			this.m_lSeguro.TabIndex = 0;
			this.m_lSeguro.Text = "Seguro:";
			this.m_lSeguro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lDataEmissao
			// 
			this.m_lDataEmissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lDataEmissao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDataEmissao.Location = new System.Drawing.Point(286, 16);
			this.m_lDataEmissao.Name = "m_lDataEmissao";
			this.m_lDataEmissao.Size = new System.Drawing.Size(88, 16);
			this.m_lDataEmissao.TabIndex = 1;
			this.m_lDataEmissao.Text = "Emissão";
			this.m_lDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lIdentificar
			// 
			this.m_lIdentificar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lIdentificar.Location = new System.Drawing.Point(155, 18);
			this.m_lIdentificar.Name = "m_lIdentificar";
			this.m_lIdentificar.Size = new System.Drawing.Size(125, 16);
			this.m_lIdentificar.TabIndex = 0;
			this.m_lIdentificar.Text = "Identificação";
			this.m_lIdentificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_ttSumario
			// 
			this.m_ttSumario.AutomaticDelay = 100;
			this.m_ttSumario.AutoPopDelay = 5000;
			this.m_ttSumario.InitialDelay = 100;
			this.m_ttSumario.ReshowDelay = 20;
			// 
			// frmFSumario
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(402, 192);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSumario";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Documentos";
			this.Load += new System.EventHandler(this.frmFSumario_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"System.Windows.Forms.DateTimePicker"))
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

		#region Eventos
		#region Load
		private void frmFSumario_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			OnCallCarregaDadosInterface();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_bModificado = true;
			OnCallSalvaDadosInterface();
			OnCallSalvaDadosBD();
			this.Close();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#endregion
	}
}
