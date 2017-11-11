using System;
using System.Collections;
//using System.Windows.Forms;

namespace mdlNumero
{
	/// <summary>
	/// Summary description for frmFNumeroConfiguracao.
	/// </summary>
	internal class frmFNumeroConfiguracao : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		// Frame Size: Maior == 478; Menor == 164
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bFrameExtendido = false;

		public bool m_bModificado = false;

		private frmFNumero m_formFNumeroConfiguracao = null;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.GroupBox m_gbPadroes;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.ImageList m_ilDownUp;
		private System.Windows.Forms.Label m_lFormato;
		private System.Windows.Forms.Label m_lVisualizar;
		private mdlComponentesGraficos.TextBox m_ctbFormato;
		private System.Windows.Forms.Button m_btDownUp;
		private mdlComponentesGraficos.TextBox m_ctbVisualizar;
		private System.Windows.Forms.Label m_lPais;
		private System.Windows.Forms.Label m_lFormatoPais;
		private System.Windows.Forms.Label m_lMes;
		private System.Windows.Forms.Label m_lFormatoMesNumero;
		private System.Windows.Forms.Label m_lFormatoMesExtenso;
		private System.Windows.Forms.ToolTip m_ttNumeroConfiguracao;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lSugestao;
		private System.Windows.Forms.Label m_lFormatoNumeroPE;
		private System.Windows.Forms.Label m_lNumeroPE;
		private System.Windows.Forms.Label m_lFormatoDia;
		private System.Windows.Forms.Label m_lDia;
		private System.Windows.Forms.Label m_lFormatoNumeroAleatorio;
		private System.Windows.Forms.Label m_lNumeroAleatorio;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Construtores & Destrutores
		public frmFNumeroConfiguracao(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, ref frmFNumero formFNumero)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
			m_formFNumeroConfiguracao = formFNumero;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizacao,ref System.Windows.Forms.Label lPais, ref System.Windows.Forms.Label lMesNumero, ref System.Windows.Forms.Label lMesAbreviado, ref System.Windows.Forms.Label lDia, ref System.Windows.Forms.Label lPE, ref System.Windows.Forms.Label lAleatorio, ref System.Windows.Forms.Label lSugestao);
		public delegate void delCallManipulaFormato(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizar);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox ctbFormato, ref mdlComponentesGraficos.TextBox ctbVisualizar);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallManipulaFormato eCallManipulaFormato;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_ctbFormato, ref this.m_ctbVisualizar, ref this.m_lFormatoPais, ref this.m_lFormatoMesNumero, ref this.m_lFormatoMesExtenso, ref this.m_lFormatoDia, ref this.m_lFormatoNumeroPE, ref this.m_lFormatoNumeroAleatorio, ref this.m_lSugestao);
		}
		protected virtual void OnCallManipulaFormato()
		{
			if (eCallManipulaFormato != null)
				eCallManipulaFormato(ref this.m_ctbFormato, ref this.m_ctbVisualizar);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_ctbFormato, ref this.m_ctbVisualizar);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNumeroConfiguracao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_lSugestao = new System.Windows.Forms.Label();
			this.m_btDownUp = new System.Windows.Forms.Button();
			this.m_ilDownUp = new System.Windows.Forms.ImageList(this.components);
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbPadroes = new System.Windows.Forms.GroupBox();
			this.m_lFormatoNumeroAleatorio = new System.Windows.Forms.Label();
			this.m_lNumeroAleatorio = new System.Windows.Forms.Label();
			this.m_lFormatoNumeroPE = new System.Windows.Forms.Label();
			this.m_lNumeroPE = new System.Windows.Forms.Label();
			this.m_lFormatoDia = new System.Windows.Forms.Label();
			this.m_lDia = new System.Windows.Forms.Label();
			this.m_lFormatoMesExtenso = new System.Windows.Forms.Label();
			this.m_lFormatoMesNumero = new System.Windows.Forms.Label();
			this.m_lMes = new System.Windows.Forms.Label();
			this.m_lFormatoPais = new System.Windows.Forms.Label();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_ctbVisualizar = new mdlComponentesGraficos.TextBox();
			this.m_ctbFormato = new mdlComponentesGraficos.TextBox();
			this.m_lVisualizar = new System.Windows.Forms.Label();
			this.m_lFormato = new System.Windows.Forms.Label();
			this.m_ttNumeroConfiguracao = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbPadroes.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_lSugestao);
			this.m_gbFrame.Controls.Add(this.m_btDownUp);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbPadroes);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 137);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 5;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_lSugestao
			// 
			this.m_lSugestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSugestao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSugestao.Location = new System.Drawing.Point(23, 425);
			this.m_lSugestao.Name = "m_lSugestao";
			this.m_lSugestao.Size = new System.Drawing.Size(200, 16);
			this.m_lSugestao.TabIndex = 0;
			this.m_lSugestao.Text = "Sugerimos: PPP.MMDD.NNN";
			this.m_lSugestao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btDownUp
			// 
			this.m_btDownUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btDownUp.ForeColor = System.Drawing.SystemColors.Control;
			this.m_btDownUp.ImageIndex = 1;
			this.m_btDownUp.ImageList = this.m_ilDownUp;
			this.m_btDownUp.Location = new System.Drawing.Point(191, 102);
			this.m_btDownUp.Name = "m_btDownUp";
			this.m_btDownUp.Size = new System.Drawing.Size(30, 27);
			this.m_btDownUp.TabIndex = 4;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_btDownUp, "Mostrar instruções de padrões");
			this.m_btDownUp.Click += new System.EventHandler(this.m_btDownUp_Click);
			// 
			// m_ilDownUp
			// 
			this.m_ilDownUp.ImageSize = new System.Drawing.Size(12, 12);
			this.m_ilDownUp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilDownUp.ImageStream")));
			this.m_ilDownUp.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 102);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 2;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 102);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 3;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbPadroes
			// 
			this.m_gbPadroes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPadroes.Controls.Add(this.m_lFormatoNumeroAleatorio);
			this.m_gbPadroes.Controls.Add(this.m_lNumeroAleatorio);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoNumeroPE);
			this.m_gbPadroes.Controls.Add(this.m_lNumeroPE);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoDia);
			this.m_gbPadroes.Controls.Add(this.m_lDia);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoMesExtenso);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoMesNumero);
			this.m_gbPadroes.Controls.Add(this.m_lMes);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoPais);
			this.m_gbPadroes.Controls.Add(this.m_lPais);
			this.m_gbPadroes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPadroes.Location = new System.Drawing.Point(16, 144);
			this.m_gbPadroes.Name = "m_gbPadroes";
			this.m_gbPadroes.Size = new System.Drawing.Size(214, 275);
			this.m_gbPadroes.TabIndex = 0;
			this.m_gbPadroes.TabStop = false;
			this.m_gbPadroes.Text = "Padrões";
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_gbPadroes, "Para usar algum desses caracteres literais, inserí-los no formato entre aspas(\")");
			// 
			// m_lFormatoNumeroAleatorio
			// 
			this.m_lFormatoNumeroAleatorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoNumeroAleatorio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoNumeroAleatorio.Location = new System.Drawing.Point(47, 249);
			this.m_lFormatoNumeroAleatorio.Name = "m_lFormatoNumeroAleatorio";
			this.m_lFormatoNumeroAleatorio.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoNumeroAleatorio.TabIndex = 2;
			this.m_lFormatoNumeroAleatorio.Text = "AAA - 472";
			this.m_lFormatoNumeroAleatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lNumeroAleatorio
			// 
			this.m_lNumeroAleatorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lNumeroAleatorio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNumeroAleatorio.Location = new System.Drawing.Point(35, 229);
			this.m_lNumeroAleatorio.Name = "m_lNumeroAleatorio";
			this.m_lNumeroAleatorio.Size = new System.Drawing.Size(128, 16);
			this.m_lNumeroAleatorio.TabIndex = 1;
			this.m_lNumeroAleatorio.Text = "A - Número Aleatório";
			this.m_lNumeroAleatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoNumeroPE
			// 
			this.m_lFormatoNumeroPE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoNumeroPE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoNumeroPE.Location = new System.Drawing.Point(47, 203);
			this.m_lFormatoNumeroPE.Name = "m_lFormatoNumeroPE";
			this.m_lFormatoNumeroPE.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoNumeroPE.TabIndex = 0;
			this.m_lFormatoNumeroPE.Text = "NNN - 021 (PE021)";
			this.m_lFormatoNumeroPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lNumeroPE
			// 
			this.m_lNumeroPE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lNumeroPE.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lNumeroPE.Location = new System.Drawing.Point(35, 183);
			this.m_lNumeroPE.Name = "m_lNumeroPE";
			this.m_lNumeroPE.Size = new System.Drawing.Size(110, 16);
			this.m_lNumeroPE.TabIndex = 0;
			this.m_lNumeroPE.Text = "N - Número do PE";
			this.m_lNumeroPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoDia
			// 
			this.m_lFormatoDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoDia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoDia.Location = new System.Drawing.Point(47, 157);
			this.m_lFormatoDia.Name = "m_lFormatoDia";
			this.m_lFormatoDia.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoDia.TabIndex = 0;
			this.m_lFormatoDia.Text = "DD - 31 (31/03/2003)";
			this.m_lFormatoDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lDia
			// 
			this.m_lDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lDia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDia.Location = new System.Drawing.Point(35, 137);
			this.m_lDia.Name = "m_lDia";
			this.m_lDia.Size = new System.Drawing.Size(44, 16);
			this.m_lDia.TabIndex = 0;
			this.m_lDia.Text = "D - Dia";
			this.m_lDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoMesExtenso
			// 
			this.m_lFormatoMesExtenso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoMesExtenso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoMesExtenso.Location = new System.Drawing.Point(47, 111);
			this.m_lFormatoMesExtenso.Name = "m_lFormatoMesExtenso";
			this.m_lFormatoMesExtenso.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoMesExtenso.TabIndex = 0;
			this.m_lFormatoMesExtenso.Text = "MMM - mar (Março)";
			this.m_lFormatoMesExtenso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoMesNumero
			// 
			this.m_lFormatoMesNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoMesNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoMesNumero.Location = new System.Drawing.Point(47, 91);
			this.m_lFormatoMesNumero.Name = "m_lFormatoMesNumero";
			this.m_lFormatoMesNumero.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoMesNumero.TabIndex = 0;
			this.m_lFormatoMesNumero.Text = "MM - 03 (Março)";
			this.m_lFormatoMesNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lMes
			// 
			this.m_lMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lMes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lMes.Location = new System.Drawing.Point(35, 71);
			this.m_lMes.Name = "m_lMes";
			this.m_lMes.Size = new System.Drawing.Size(56, 16);
			this.m_lMes.TabIndex = 0;
			this.m_lMes.Text = "M - Mês";
			this.m_lMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoPais
			// 
			this.m_lFormatoPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoPais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoPais.Location = new System.Drawing.Point(47, 45);
			this.m_lFormatoPais.Name = "m_lFormatoPais";
			this.m_lFormatoPais.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoPais.TabIndex = 0;
			this.m_lFormatoPais.Text = "PPP - ESP (ESPanha)";
			this.m_lFormatoPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lPais
			// 
			this.m_lPais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lPais.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPais.Location = new System.Drawing.Point(35, 25);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(54, 16);
			this.m_lPais.TabIndex = 0;
			this.m_lPais.Text = "P - País";
			this.m_lPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_ctbVisualizar);
			this.m_gbFields.Controls.Add(this.m_ctbFormato);
			this.m_gbFields.Controls.Add(this.m_lVisualizar);
			this.m_gbFields.Controls.Add(this.m_lFormato);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(230, 88);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_ctbVisualizar
			// 
			this.m_ctbVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbVisualizar.BackColor = System.Drawing.SystemColors.HighlightText;
			this.m_ctbVisualizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_ctbVisualizar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.m_ctbVisualizar.Enabled = false;
			this.m_ctbVisualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbVisualizar.Location = new System.Drawing.Point(75, 58);
			this.m_ctbVisualizar.Name = "m_ctbVisualizar";
			this.m_ctbVisualizar.Size = new System.Drawing.Size(145, 20);
			this.m_ctbVisualizar.TabIndex = 0;
			this.m_ctbVisualizar.Text = "";
			this.m_ctbVisualizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_ctbVisualizar, "Máscara aplicada");
			// 
			// m_ctbFormato
			// 
			this.m_ctbFormato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctbFormato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.m_ctbFormato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ctbFormato.Location = new System.Drawing.Point(75, 27);
			this.m_ctbFormato.Name = "m_ctbFormato";
			this.m_ctbFormato.Size = new System.Drawing.Size(145, 20);
			this.m_ctbFormato.TabIndex = 1;
			this.m_ctbFormato.Text = "";
			this.m_ctbFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_ttNumeroConfiguracao.SetToolTip(this.m_ctbFormato, "Máscara");
			this.m_ctbFormato.TextChanged += new System.EventHandler(this.m_ctbFormato_TextChanged);
			// 
			// m_lVisualizar
			// 
			this.m_lVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lVisualizar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lVisualizar.Location = new System.Drawing.Point(8, 58);
			this.m_lVisualizar.Name = "m_lVisualizar";
			this.m_lVisualizar.Size = new System.Drawing.Size(62, 18);
			this.m_lVisualizar.TabIndex = 0;
			this.m_lVisualizar.Text = "Visualizar:";
			this.m_lVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormato
			// 
			this.m_lFormato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormato.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormato.Location = new System.Drawing.Point(8, 27);
			this.m_lFormato.Name = "m_lFormato";
			this.m_lFormato.Size = new System.Drawing.Size(54, 18);
			this.m_lFormato.TabIndex = 0;
			this.m_lFormato.Text = "Formato:";
			this.m_lFormato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttNumeroConfiguracao
			// 
			this.m_ttNumeroConfiguracao.AutomaticDelay = 100;
			this.m_ttNumeroConfiguracao.AutoPopDelay = 5000;
			this.m_ttNumeroConfiguracao.InitialDelay = 100;
			this.m_ttNumeroConfiguracao.ReshowDelay = 20;
			// 
			// frmFNumeroConfiguracao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 139);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNumeroConfiguracao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Identificação";
			this.Load += new System.EventHandler(this.frmFNumeroConfiguracao_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbPadroes.ResumeLayout(false);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
							for (int cont4 = 0; cont4 < this.Controls[cont].Controls[cont2].Controls[cont3].Controls.Count; cont4++)
							{
								if ((this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].GetType().ToString() != 
									"System.Windows.Forms.TextBox") &&
									(this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].GetType().ToString() != 
									"mdlComponentesGraficos.TextBox"))
								{
									this.Controls[cont].Controls[cont2].Controls[cont3].Controls[cont4].BackColor = this.BackColor;
								}
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

		#region Eventos
		#region UpDownFrame
		private void m_btDownUp_Click(object sender, System.EventArgs e)
		{
			if (m_bFrameExtendido == false)
			{
				this.m_btDownUp.ImageIndex = 0;
				this.SetBounds(this.Bounds.X,this.Bounds.Y,this.Bounds.Width,478);
				this.m_ttNumeroConfiguracao.SetToolTip(this.m_btDownUp,"Esconder instruções de padrão");
				m_bFrameExtendido = true;
			}
			else
			{
				this.m_btDownUp.ImageIndex = 1;
				this.SetBounds(this.Bounds.X,this.Bounds.Y,this.Bounds.Width,164);
				this.m_ttNumeroConfiguracao.SetToolTip(this.m_btDownUp,"Mostrar instruções de padrão");
				m_bFrameExtendido = false;
			}
		}
		#endregion
		#region Load
		private void frmFNumeroConfiguracao_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				if (this.Bounds.Height > 164)
				{
					m_bFrameExtendido = true;
					m_btDownUp.ImageIndex = 0;
					this.m_ttNumeroConfiguracao.SetToolTip(this.m_btDownUp,"Esconder instruções de padrão");
				}
				OnCallCarregaDadosInterface();
				OnCallManipulaFormato();
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
				this.mostraCor();
				m_formFNumeroConfiguracao.mostraCor();
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
		#region Formato Changed
		private void m_ctbFormato_TextChanged(object sender, System.EventArgs e)
		{
			OnCallManipulaFormato();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.m_bModificado = true;
				OnCallSalvaDadosInterface();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
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
