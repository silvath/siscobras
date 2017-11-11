using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlData
{
	/// <summary>
	/// Summary description for frmFDataConfiguracao.
	/// </summary>
	internal class frmFDataConfiguracao : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallLoadInterface(out System.DateTime dtDate,out string strFormat);
			public delegate bool delCallLoadDate(System.DateTime dtDate,string strFormat,out string strDate);
			public delegate bool delCallSaveInterface(string strFormat);
		#endregion
		#region Events
			public event delCallLoadInterface eCallLoadInterface;
			public event delCallLoadDate eCallLoadDate;
			public event delCallSaveInterface eCallSaveInterface;
		#endregion
		#region Events Methods
			protected virtual void OnCallLoadInterface()
			{
				if (eCallLoadInterface != null)
				{
					string strFormat;
					eCallLoadInterface(out m_dtDate,out strFormat);
					m_txtFormat.Text = strFormat;
				}
			}
			protected virtual bool OnCallLoadDate()
			{
				bool bReturn = false;
				if (eCallLoadDate != null)
				{
					string strDate = "";
					bReturn = eCallLoadDate(m_dtDate,m_txtFormat.Text,out strDate);
					if (!bReturn)
						strDate = "Formato Inválido";
					m_txtDate.Text = strDate;
				}
				return(bReturn);
			}
			protected virtual bool OnCallSaveInterface()
			{
				bool bReturn = false;
				if (eCallSaveInterface != null)
					bReturn = eCallSaveInterface(m_txtFormat.Text);
				return(bReturn);
			}
		#endregion

		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			private System.DateTime m_dtDate;

			public bool m_bModificado = false;
			public bool m_bFrameExtendido = false;

			private System.Windows.Forms.GroupBox m_gbFrame;
			internal System.Windows.Forms.Button m_btTrocarCor;
			private System.Windows.Forms.Label m_lSugestao;
			private System.Windows.Forms.Button m_btDownUp;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbPadroes;
			private System.Windows.Forms.Label m_lFormatoDia;
			private System.Windows.Forms.Label m_lDia;
			private System.Windows.Forms.Label m_lMes;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Label m_lVisualizar;
			private System.Windows.Forms.Label m_lFormato;
			private System.Windows.Forms.ImageList m_ilDownUp;
			private System.Windows.Forms.ToolTip m_ttConfiguracao;
			private System.Windows.Forms.Label m_lFormatoAno;
			private System.Windows.Forms.Label m_lAno;
			private System.Windows.Forms.Label m_lFormatoMes;
			private System.Windows.Forms.Label m_lbHora;
			private System.Windows.Forms.Label m_lbMinuto;
			private System.Windows.Forms.Label m_lbFormatoHora;
			private System.Windows.Forms.Label m_lbFormatoMinuto;
			private mdlComponentesGraficos.TextBox m_txtDate;
			private mdlComponentesGraficos.TextBox m_txtFormat;
			private System.ComponentModel.IContainer components = null;
		#endregion
		#region Construtors and Destructors
			public frmFDataConfiguracao(ref mdlTratamentoErro.clsTratamentoErro cls_ter_tratadorErro, string strEnderecoExecutavel)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = cls_ter_tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFDataConfiguracao));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_lSugestao = new System.Windows.Forms.Label();
			this.m_btDownUp = new System.Windows.Forms.Button();
			this.m_ilDownUp = new System.Windows.Forms.ImageList(this.components);
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbPadroes = new System.Windows.Forms.GroupBox();
			this.m_lbFormatoHora = new System.Windows.Forms.Label();
			this.m_lbHora = new System.Windows.Forms.Label();
			this.m_lbFormatoMinuto = new System.Windows.Forms.Label();
			this.m_lbMinuto = new System.Windows.Forms.Label();
			this.m_lFormatoAno = new System.Windows.Forms.Label();
			this.m_lAno = new System.Windows.Forms.Label();
			this.m_lFormatoDia = new System.Windows.Forms.Label();
			this.m_lDia = new System.Windows.Forms.Label();
			this.m_lFormatoMes = new System.Windows.Forms.Label();
			this.m_lMes = new System.Windows.Forms.Label();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_txtDate = new mdlComponentesGraficos.TextBox();
			this.m_txtFormat = new mdlComponentesGraficos.TextBox();
			this.m_lVisualizar = new System.Windows.Forms.Label();
			this.m_lFormato = new System.Windows.Forms.Label();
			this.m_ttConfiguracao = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(246, 413);
			this.m_gbFrame.TabIndex = 1;
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
			this.m_ttConfiguracao.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_lSugestao
			// 
			this.m_lSugestao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lSugestao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lSugestao.Location = new System.Drawing.Point(23, 393);
			this.m_lSugestao.Name = "m_lSugestao";
			this.m_lSugestao.Size = new System.Drawing.Size(200, 16);
			this.m_lSugestao.TabIndex = 0;
			this.m_lSugestao.Text = "Exemplo: dd/MM/aaaa";
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
			this.m_ttConfiguracao.SetToolTip(this.m_btDownUp, "Mostrar instruções de padrão");
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
			this.m_ttConfiguracao.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_ttConfiguracao.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbPadroes
			// 
			this.m_gbPadroes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPadroes.Controls.Add(this.m_lbFormatoHora);
			this.m_gbPadroes.Controls.Add(this.m_lbHora);
			this.m_gbPadroes.Controls.Add(this.m_lbFormatoMinuto);
			this.m_gbPadroes.Controls.Add(this.m_lbMinuto);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoAno);
			this.m_gbPadroes.Controls.Add(this.m_lAno);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoDia);
			this.m_gbPadroes.Controls.Add(this.m_lDia);
			this.m_gbPadroes.Controls.Add(this.m_lFormatoMes);
			this.m_gbPadroes.Controls.Add(this.m_lMes);
			this.m_gbPadroes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPadroes.Location = new System.Drawing.Point(16, 144);
			this.m_gbPadroes.Name = "m_gbPadroes";
			this.m_gbPadroes.Size = new System.Drawing.Size(214, 248);
			this.m_gbPadroes.TabIndex = 0;
			this.m_gbPadroes.TabStop = false;
			this.m_gbPadroes.Text = "Padrões";
			// 
			// m_lbFormatoHora
			// 
			this.m_lbFormatoHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lbFormatoHora.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFormatoHora.Location = new System.Drawing.Point(50, 184);
			this.m_lbFormatoHora.Name = "m_lbFormatoHora";
			this.m_lbFormatoHora.Size = new System.Drawing.Size(159, 11);
			this.m_lbFormatoHora.TabIndex = 6;
			this.m_lbFormatoHora.Text = "hh - 14";
			this.m_lbFormatoHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbHora
			// 
			this.m_lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lbHora.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbHora.Location = new System.Drawing.Point(38, 160);
			this.m_lbHora.Name = "m_lbHora";
			this.m_lbHora.Size = new System.Drawing.Size(86, 11);
			this.m_lbHora.TabIndex = 1;
			this.m_lbHora.Text = "h - Hora";
			this.m_lbHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbFormatoMinuto
			// 
			this.m_lbFormatoMinuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lbFormatoMinuto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbFormatoMinuto.Location = new System.Drawing.Point(50, 222);
			this.m_lbFormatoMinuto.Name = "m_lbFormatoMinuto";
			this.m_lbFormatoMinuto.Size = new System.Drawing.Size(159, 16);
			this.m_lbFormatoMinuto.TabIndex = 2;
			this.m_lbFormatoMinuto.Text = "mm - 03 ";
			this.m_lbFormatoMinuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lbMinuto
			// 
			this.m_lbMinuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lbMinuto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbMinuto.Location = new System.Drawing.Point(38, 202);
			this.m_lbMinuto.Name = "m_lbMinuto";
			this.m_lbMinuto.Size = new System.Drawing.Size(92, 16);
			this.m_lbMinuto.TabIndex = 3;
			this.m_lbMinuto.Text = "m - Minuto";
			this.m_lbMinuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoAno
			// 
			this.m_lFormatoAno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoAno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoAno.Location = new System.Drawing.Point(47, 137);
			this.m_lFormatoAno.Name = "m_lFormatoAno";
			this.m_lFormatoAno.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoAno.TabIndex = 0;
			this.m_lFormatoAno.Text = "aaaa - 2003";
			this.m_lFormatoAno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lAno
			// 
			this.m_lAno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lAno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAno.Location = new System.Drawing.Point(35, 117);
			this.m_lAno.Name = "m_lAno";
			this.m_lAno.Size = new System.Drawing.Size(48, 16);
			this.m_lAno.TabIndex = 0;
			this.m_lAno.Text = "a - Ano";
			this.m_lAno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoDia
			// 
			this.m_lFormatoDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoDia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoDia.Location = new System.Drawing.Point(47, 45);
			this.m_lFormatoDia.Name = "m_lFormatoDia";
			this.m_lFormatoDia.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoDia.TabIndex = 0;
			this.m_lFormatoDia.Text = "dd - 31 (31/03/2003)";
			this.m_lFormatoDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lDia
			// 
			this.m_lDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lDia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lDia.Location = new System.Drawing.Point(35, 25);
			this.m_lDia.Name = "m_lDia";
			this.m_lDia.Size = new System.Drawing.Size(44, 16);
			this.m_lDia.TabIndex = 0;
			this.m_lDia.Text = "d - Dia";
			this.m_lDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lFormatoMes
			// 
			this.m_lFormatoMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormatoMes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormatoMes.Location = new System.Drawing.Point(47, 91);
			this.m_lFormatoMes.Name = "m_lFormatoMes";
			this.m_lFormatoMes.Size = new System.Drawing.Size(159, 16);
			this.m_lFormatoMes.TabIndex = 0;
			this.m_lFormatoMes.Text = "MM - 03 (Março)";
			this.m_lFormatoMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_txtDate);
			this.m_gbFields.Controls.Add(this.m_txtFormat);
			this.m_gbFields.Controls.Add(this.m_lVisualizar);
			this.m_gbFields.Controls.Add(this.m_lFormato);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(230, 88);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Configuração";
			// 
			// m_txtDate
			// 
			this.m_txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDate.BackColor = System.Drawing.SystemColors.HighlightText;
			this.m_txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtDate.Enabled = false;
			this.m_txtDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDate.Location = new System.Drawing.Point(75, 57);
			this.m_txtDate.Name = "m_txtDate";
			this.m_txtDate.Size = new System.Drawing.Size(145, 20);
			this.m_txtDate.TabIndex = 0;
			this.m_txtDate.Text = "";
			this.m_txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_txtFormat
			// 
			this.m_txtFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtFormat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtFormat.Location = new System.Drawing.Point(75, 26);
			this.m_txtFormat.Name = "m_txtFormat";
			this.m_txtFormat.Size = new System.Drawing.Size(145, 20);
			this.m_txtFormat.TabIndex = 1;
			this.m_txtFormat.Text = "";
			this.m_txtFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.m_txtFormat.TextChanged += new System.EventHandler(this.m_ctbFormato_TextChanged);
			// 
			// m_lVisualizar
			// 
			this.m_lVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lVisualizar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lVisualizar.Location = new System.Drawing.Point(8, 57);
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
			this.m_lFormato.Location = new System.Drawing.Point(8, 26);
			this.m_lFormato.Name = "m_lFormato";
			this.m_lFormato.Size = new System.Drawing.Size(54, 18);
			this.m_lFormato.TabIndex = 0;
			this.m_lFormato.Text = "Formato:";
			this.m_lFormato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttConfiguracao
			// 
			this.m_ttConfiguracao.AutomaticDelay = 100;
			this.m_ttConfiguracao.AutoPopDelay = 5000;
			this.m_ttConfiguracao.InitialDelay = 100;
			this.m_ttConfiguracao.ReshowDelay = 20;
			// 
			// frmFDataConfiguracao
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 415);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFDataConfiguracao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Siscobras";
			this.Load += new System.EventHandler(this.frmFDataConfiguracao_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbPadroes.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFDataConfiguracao_Load(object sender, System.EventArgs e)
				{
					try
					{
						vMostraCor();
						if (this.Bounds.Height > 170)
						{
							m_bFrameExtendido = true;
							m_btDownUp.ImageIndex = 0;
							this.m_ttConfiguracao.SetToolTip(this.m_btDownUp,"Esconder instruções de padrão");
						}
						OnCallLoadInterface();
						OnCallLoadDate();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region TextBoxes
				private void m_ctbFormato_TextChanged(object sender, System.EventArgs e)
				{
					OnCallLoadDate();
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try
					{
						vShowColor();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btDownUp_Click(object sender, System.EventArgs e)
				{
					if (m_bFrameExtendido == false)
					{
						this.m_btDownUp.ImageIndex = 0;
						this.SetBounds(this.Bounds.X,this.Bounds.Y,this.Bounds.Width,440);
						this.m_ttConfiguracao.SetToolTip(this.m_btDownUp,"Esconder instruções de padrão");
						m_bFrameExtendido = true;
					}
					else
					{
						this.m_btDownUp.ImageIndex = 1;
						this.SetBounds(this.Bounds.X,this.Bounds.Y,this.Bounds.Width,170);
						this.m_ttConfiguracao.SetToolTip(this.m_btDownUp,"Mostrar instruções de padrão");
						m_bFrameExtendido = false;
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (m_bModificado = OnCallSaveInterface())
							this.Close();
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
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vShowColor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				clsPaletaCores.mostraCorAtual();
				vMostraCor();
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion
	}
}
